using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Sales.PackSlips;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core.Cms;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;

using Nujit.NujitWms.WinForms.Util.Grids;
using Nujit.NujitWms.WinForms.Util.Converters;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using System.Collections.ObjectModel;
using HotListReports.Windows.Util;
using System.Collections;
using System.Data;
using Nujit.NujitERP.ClassLib.Common;

namespace HotListReports.Windows.Products{
    /// <summary>
/// Interaction logic for ProductWindow.xaml
/// </summary>
public partial 
class ProductWindow : Window{

private ProductModel    model;
private int             imachineIdFilter;
private int             itabIndex;
private bool            bmodeSelect;

public ProductWindow(bool bmodeSelect = true){
    InitializeComponent();
    
    this.model = new ProductModel(this);
    this.imachineIdFilter=0;
    this.itabIndex  =0;
    this.bmodeSelect = bmodeSelect;
}

public
void setMachineIdFilter(int imachineIdFilter){
   this.imachineIdFilter = imachineIdFilter;
}

public
Product getSelected(){
    Product product = (Product)model.getSelected(this.hdrListView);
    return product;
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){    
    initialize();
}

private 
void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e){
    
}

private 
void hdrListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    if (bmodeSelect) { 
        this.DialogResult = true;
        Close();
    }else
        mainTabControl.SelectedItem = detailTabItem;
}

private 
void mainTabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e){
    mainTabControlSelectionChanged();
}

private 
void mainTabControlSelectionChanged(){    
    try {
        int indexSel    = mainTabControl.SelectedIndex;
        int ipriorIndex = itabIndex;
                
        if (indexSel != itabIndex){
            this.itabIndex = indexSel;                                                   
            
            if (indexSel == 0)
                search();
            else
                model.loadPart(hdrListView,mainTabControl,daysOnHandTextBox);
        }        
         
    } catch (Exception ex) {
        MessageBox.Show("mainTabControlSelectionChanged error:" + ex.Message);
    }    
}

private 
void initialize(){        
    try {                
        model.addButtonsListViewFunctions(this.hdrListView,firstButton,prevButton,nextButton,lastButton);        

        this.recordsTextBox.Text = Configuration.SearchDefaultMaxRecords;
        model.Cursor = this.Cursor;
        model.loadSearchByCombo(searchByComboBox);             
        model.loadPlantCombo(plantComboBox,false);model.setSelectedComboBoxItem(plantComboBox,Configuration.DftPlant);
        model.loadDifferentsMajorGroup(majorGroupComboBox);                   
        model.loadTypePartComboBox(typeComboBox,true);
        model.loadColumnsOnHeaderGrid(hdrListView);   
        model.loadYesNoComboBox(obectivesAutomaticCalcComboBox,false);
        model.loadYesNoComboBox(schMaterialAvailComboBox,true);
                
        ContextMenuListViewFunctions contextMenuListView = model.addContextMenuListViewFunctions(hdrListView);
        model.addContextMenuItem(Constants.OPTIONS_ROUTINGS);
        contextMenuListView.contextMenuListViewEventHandler += new ContextMenuListViewEventHandler(contextMenuListViewEventHandlerEvent);

        model.screenFullArea();
        search();    

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }
}

private
void contextMenuListViewEventHandlerEvent(object sender, string optionSelected){
    Product product = (Product)model.getSelected(hdrListView);

    switch (optionSelected){        
        case Nujit.NujitWms.ClassLib.Common.Constants.OPTION_CANCEL:
            model.close();                                
            break;
        case Nujit.NujitWms.ClassLib.Common.Constants.OPTION_REFRESH:
            search();
            break;
        case Constants.OPTIONS_ROUTINGS:
            model.routings(product);
            break;        
    }
}

private 
void searchButton_Click(object sender, RoutedEventArgs e){
    search();
}

private 
void search(){    
    try{
        int         irows       = model.getRecords(recordsTextBox); 
        string      splant      = model.getSelectedComboBoxItemString(plantComboBox);
        string      sprodId     = searchByComboBox.SelectedIndex == 0 ? searchForTextBox.Text : ""; 
        string      sdes1       = searchByComboBox.SelectedIndex == 1 ? searchForTextBox.Text : "";        
        string      smajGroup   = model.getSelectedComboBoxItemString(majorGroupComboBox);
        string      stype       = model.getSelectedComboBoxItemString(typeComboBox);
        string      smatPlanned = model.getSelectedComboBoxItemString(schMaterialAvailComboBox);

        if (!string.IsNullOrEmpty(sprodId))        
            sprodId = sprodId + "%";  
         if (!string.IsNullOrEmpty(sdes1))        
            sdes1 = sdes1 + "%";        
        
        ProductContainer productContainer = model.getCoreFactory().readProductViewByFilters(splant,sprodId, sdes1,imachineIdFilter,smajGroup,stype,smatPlanned,irows);
        model.setDataContextListView(hdrListView,productContainer);        
        this.searchForTextBox.Focus();
            
    }catch (Exception ex){
        MessageBox.Show("search Exception: " + ex.Message);
    }finally{
        imachineIdFilter=0; //machine filter only used once                                   
    }  
}


private 
void okButton_Click(object sender, RoutedEventArgs e){
    save();
}

private 
void cancelButton_Click(object sender, RoutedEventArgs e){
    cancel();
}


private
void cancel(){
    try{ 
        if (model.cancel()){
            mainTabControl.SelectedItem = hdrTabItem;            
        } 
    }catch (Exception ex){
        MessageBox.Show("cancel Exception: " + ex.Message);
    } 
}

private
Product getCurrPart(){
    return (Product) detailTabItem.DataContext;
}
        
private 
bool dataOk(){    
    bool            bresult=true;
    
    if (getCurrPart() == null)  {                          
        MessageBox.Show("Sorry, Can Not Find Part.");
        bresult=false;
    }
         
    if (bresult)
        bresult = model.getValidNumericFromAlpha(daysOnHandTextBox, "Days On Hand");
    
    return bresult;
}

private
void save(){
    try{         
        if (dataOk()){
            model.getCoreFactory().updateProduct(getCurrPart());
            MessageBox.Show("Product Updated.");
            mainTabControl.SelectedItem = hdrTabItem;
        } 
    }catch (Exception ex){
        MessageBox.Show("save Exception: " + ex.Message);
    } 
}

private 
void matAvailabilitytButton_Click(object sender, RoutedEventArgs e){
    matAvailability();
}

private 
void matAvailability(){
    model.processShMaterial(hdrListView);
}

private 
void recalcLevelButton_Click(object sender, RoutedEventArgs e){
    recalcLevel();
}

private
void recalcLevel(){
    try{
        model.cursorWait();
        model.getCoreFactory().recalcAllPartsLevel();
        model.cursorNormal();
        MessageBox.Show("Parts Levels Were Calculated.");            
    }catch (Exception ex){
        MessageBox.Show("recalcLevel Exception: " + ex.Message);
    }finally{
        model.cursorNormal();                 
    }
}

}
}
