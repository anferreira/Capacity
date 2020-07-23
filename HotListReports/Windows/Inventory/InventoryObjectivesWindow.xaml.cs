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
using Nujit.NujitERP.ClassLib.Common;
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Util;
using FarsiLibrary.FX.Win.Controls;

namespace HotListReports.Windows.Inventories{
/// <summary>
/// Interaction logic for InventoryObjectivesWindow.xaml
/// </summary>
public partial
class InventoryObjectivesWindow : Window{

private InventoryObjectivesModel model;
private InventoryObjectiveHdr inventoryObjectiveHdr;
private int itabIndex;
private int ipartDtlTabIndex;
private bool badding;
private bool baddingDtl;
private ButtonsListViewFunctions buttonsListViewFunctionsPart;
private bool bforceMoveDirectlyDetail;


public InventoryObjectivesWindow(){
    InitializeComponent();
    
    model = new InventoryObjectivesModel(this,partsListView,partsDtlListView,bomListListView);
    inventoryObjectiveHdr = null;
    baddingDtl = badding = false;
    itabIndex  = ipartDtlTabIndex = 0;
    buttonsListViewFunctionsPart= null;
    bforceMoveDirectlyDetail = true;
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){
    initialize();
}

private 
void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e){    
}

private 
void initialize(){
    try{
        //model.getCoreFactory().getPlannedPartViewByFilters(Configuration.DftPlant,"",-1);

        model.loadColumnsOnHeaderGrid(hdrListView);
        model.loadColumnsOnPartGrid(partsListView);
        model.loadColumnsOnPartsDtlGrid(partsDtlListView);
        model.loadColumnsOnBomGrid(bomListListView);

        model.loadPlantCombo(plantFilterComboBox,true); model.setSelectedComboBoxItem(plantFilterComboBox,Configuration.DftPlant);
        model.loadPlantCombo(plantComboBox,false);

        model.loadStatusComboBox(statusFilterComboBox,true);
        model.loadStatusComboBox(statusComboBox,false);
        setListViewScrollsButtons();

        model.screenFullArea();
        model.removeTabItem(mainTabControl,partSeqTabItem);
        model.removeTabItem(mainTabControl,partDtlTabItem);

        searchDateObjectivePicker.SelectedDate = DateUtil.getNextFridayFromDate(DateTime.Now);
        model.loadYesNoComboBox(obectivesAutomaticCalcComboBox,false);
  
        search();
        
    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }
}

private
void setListViewScrollsButtons(){
    model.addButtonsListViewFunctions(this.hdrListView,firstButton,prevButton,nextButton,lastButton);
    buttonsListViewFunctionsPart = new ButtonsListViewFunctions(this.partsListView,firstPButton,prevPButton,nextPButton,lastPButton);
    model.addButtonsListViewFunctions(this.partsDtlListView,firstPDButton,prevPDButton,nextPDButton,lastPDButton);  
    model.addButtonsListViewFunctions(this.bomListListView,firstPDBButton,prevPDBButton,nextPDBButton,lastPDBButton);                    

    hideShowDtlNavigateButtons(0);
} 

private
void hideShowDtlNavigateButtons(int index) {
    firstPDButton.Visibility    = prevPDButton.Visibility =nextPDButton.Visibility = lastPDButton.Visibility  = addPDButton.Visibility = delPDButton.Visibility = index == 0 ? Visibility.Visible : Visibility.Hidden;    
    firstPDBButton.Visibility   = prevPDBButton.Visibility =nextPDBButton.Visibility = lastPDBButton.Visibility = index == 1 ? Visibility.Visible : Visibility.Hidden;
}

private 
void searchButton_Click(object sender, RoutedEventArgs e){
    search();
}

private 
void search(){    
    try{  
        int         irows   = model.getRecords(recordsTextBox);
        string      sid     = searchByComboBox.SelectedIndex == 0 ? searchForTextBox.Text : "";
        string      status  = model.getSelectedComboBoxItemString(statusFilterComboBox);
        string      splant  = model.getSelectedComboBoxItemString(plantFilterComboBox); 
        DateTime    fromDate= model.getSelectedDateTime(fromDatePicker);
        DateTime    toDate  = model.getSelectedDateTime(toDatePicker);
        
        if (!string.IsNullOrEmpty(sid))        
            sid = sid + "%";        
                                            
        InventoryObjectiveHdrContainer inventoryObjectiveHdrContainer = model.getCoreFactory().createInventoryObjectiveHdrContainer();
        inventoryObjectiveHdrContainer = model.getCoreFactory().readInventoryObjectiveHdrByFilters(sid, splant, status,fromDate, toDate,true, bforceMoveDirectlyDetail ? 1 : irows);

        model.setDataContextListView(hdrListView,inventoryObjectiveHdrContainer);                
        this.searchForTextBox.Focus();

        if (bforceMoveDirectlyDetail && inventoryObjectiveHdrContainer.Count > 0)
            mainTabControl.SelectedItem = dtlTabItem;                                
            
    }catch (Exception ex){
        MessageBox.Show("search Exception: " + ex.Message);
    }finally{        
        bforceMoveDirectlyDetail=false;
    }              
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
        int icountTabs  = 0;
                
        if (indexSel != itabIndex){
            this.itabIndex = indexSel;
            icountTabs  = mainTabControl.Items.Count;
                                  
            if (indexSel == 0){

                if (icountTabs > 2)
                    mainTabControl.SelectedIndex = (icountTabs-1);
                else { 
                    this.inventoryObjectiveHdr = null;
                    baddingDtl = this.badding = false;
                    search();
                }
            }else if (indexSel == 1){

                if (icountTabs > 2)
                    mainTabControl.SelectedIndex = (icountTabs-1);
                else if (ipriorIndex == 0) { 
                    if (!badding && inventoryObjectiveHdr==null)
                        hdrDoubleClick();
                    model.InventoryObjectiveHdr = inventoryObjectiveHdr;               

                    if (inventoryObjectiveHdr != null)
                        loadHeader();                      
                    else
                        mainTabControl.SelectedItem = viewTabItem;
                }
            } 
        }
                 
    } catch (Exception ex) {        
        MessageBox.Show("mainTabControlSelectionChanged Exception: " + ex.Message);  
    }

}

private 
void partDtlTabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e){
    partDtlTabControlSelectionChanged();
}

private 
void partDtlTabControlSelectionChanged(){
    try {
        int indexSel    = partDtlTabControl.SelectedIndex;
        int ipriorIndex = ipartDtlTabIndex;
                        
        if (indexSel != ipartDtlTabIndex){            
            this.ipartDtlTabIndex = indexSel;            
                                  
            if (indexSel == 0){

            }else if (indexSel == 1){
                model.generateListBom(true,"");                
            }

            hideShowDtlNavigateButtons(ipartDtlTabIndex);
        }
                 
    } catch (Exception ex) {        
        MessageBox.Show("partDtlTabControlSelectionChanged Exception: " + ex.Message);  
    }

}

private 
void hdrListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    hdrDoubleClick();
}

private
void hdrDoubleClick(){
    try { 
        badding = false;
        inventoryObjectiveHdr = (InventoryObjectiveHdr)model.getSelected(hdrListView);

        if (inventoryObjectiveHdr!= null){
            inventoryObjectiveHdr = model.getCoreFactory().readInventoryObjectiveHdr(inventoryObjectiveHdr.Id);//read full object
            if (inventoryObjectiveHdr!= null){                
                mainTabControl.SelectedItem = this.dtlTabItem;
            }
        }

    } catch (Exception ex) {        
        MessageBox.Show("mainTabControlSelectionChanged Exception: " + ex.Message);  
    }
}

private 
void addButton_Click(object sender, RoutedEventArgs e){
    add();   
}

private 
void delButton_Click(object sender, RoutedEventArgs e){
    del();   
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
        mainTabControl.SelectedItem = viewTabItem;            
    }catch (Exception ex){
        MessageBox.Show("cancel Exception: " + ex.Message);
    }                       
} 

private 
bool dataOK(){    
    bool bresult=true;
     
    if (string.IsNullOrEmpty(inventoryObjectiveHdr.Plant)){
        MessageBox.Show("Please, Select Plant.");
        this.plantComboBox.Focus();
        bresult=false;
    }
            
    return bresult;
} 

private 
void save(){    
    try{        
        if (dataOK()) { 
           model.save();
           MessageBox.Show("Saved Ok.");                                    
        }                                                       
    }catch (Exception ex){
        MessageBox.Show("save Exception: " + ex.Message);
    }                       
}          


private 
void add(){
    try { 
        inventoryObjectiveHdr = model.createInventoryObjectives();   
        loadHeader();
        mainTabControl.SelectedItem = dtlTabItem;
    }catch (Exception ex){
        MessageBox.Show("add Exception: " + ex.Message);
    }
}

private 
void del(){
    try { 
        if (model.del(hdrListView))
            search();
    }catch (Exception ex){
        MessageBox.Show("del Exception: " + ex.Message);
    }
}


private 
void loadHeader(){
    try { 
        dtlTabItem.DataContext = null;
        dtlTabItem.DataContext = inventoryObjectiveHdr;

        string  spartLike = string.IsNullOrEmpty(searchForPartTextBox.Text) ? "" : searchForPartTextBox.Text + "%";

        InventoryObjectivePartContainer inventoryObjectivePartContainer = model.getCoreFactory().createInventoryObjectivePartContainer();
        if (inventoryObjectiveHdr!= null)
            inventoryObjectivePartContainer = inventoryObjectiveHdr.searchByPart(spartLike);

        plantComboBox.IsEnabled = !(inventoryObjectiveHdr!= null && inventoryObjectiveHdr.Id > 0);

        model.setDataContextListView(partsListView, model.loadPartQoh(inventoryObjectivePartContainer,inventoryObjectiveHdr!= null ? inventoryObjectiveHdr.Plant:Configuration.DftPlant));
        model.loadPartsDtl(partsListView,partsDtlListView);
        
    }catch (Exception ex){
        MessageBox.Show("loadHeader Exception: " + ex.Message);
    }
}


/********************************************* Parts ****************************************************************/
private
InventoryObjectivePart getCurrPart(){
    return (InventoryObjectivePart)partSeqTabItem.DataContext;
}

private 
void partsListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
   modifyPart();
}

private 
void modifyPart(){
    baddingDtl = false;                        
    partSearchButton.IsEnabled=false;
    InventoryObjectivePart inventoryObjectivePartClone = model.modifyPart(partsListView,seqComboBox);
    if (inventoryObjectivePartClone != null)
        model.addTabItem(mainTabControl,partSeqTabItem,inventoryObjectivePartClone);    
}


private 
void partsListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
   model.loadPartsDtl(partsListView,partsDtlListView);
}

private 
void seqComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
  
}

private
void okPartPartButton_Click(object sender, RoutedEventArgs e){
    savePart();        
}

private
void cancelPartPartButton_Click(object sender, RoutedEventArgs e){
    model.removeTabItem(mainTabControl,partSeqTabItem);
}

private
void addPButton_Click(object sender, RoutedEventArgs e){
    addPart();    
}

private
void delPButton_Click(object sender, RoutedEventArgs e){
    removePart();
}

private
void savePButton_Click(object sender, RoutedEventArgs e){
    
}

private
void searchPartButton_Click(object sender, RoutedEventArgs e){
    loadHeader();
}
     
private
void savePart(){
    try{ 
        if (dataOkPart()) {             
            model.loadModifyPart(baddingDtl, partsListView, getCurrPart());            
            baddingDtl=false;
            model.removeTabItem(mainTabControl,partSeqTabItem);            
        }    

    }catch (Exception ex){
        MessageBox.Show("savePart Exception: " + ex.Message);
    }                       
}       
        
private
bool dataOkPart(){    
    bool                        bresult=true;
    InventoryObjectivePart      inventoryObjectivePart      = getCurrPart();        
    InventoryObjectivePart      inventoryObjectivePartFound = null;        
    
    if (inventoryObjectivePart == null)
        return false;        

    if (!model.validProduct(partPartTextBox))
        bresult= false;

    if (bresult && baddingDtl){
        inventoryObjectivePartFound = this.inventoryObjectiveHdr.InventoryObjectivePartContainer.getByPartSeq(inventoryObjectivePart.Part,inventoryObjectivePart.Seq);
        if (inventoryObjectivePartFound != null){
            MessageBox.Show("Sorry, Part :" + inventoryObjectivePartFound.Part + " and Seq :" + inventoryObjectivePartFound.Seq.ToString() + " Already Added, Please Reenter.");            
            bresult= false;
        }
    }  
        
    return bresult;
}
     
private
void addPart(){    
    baddingDtl = true;          
    partSearchButton.IsEnabled=true;                          
    InventoryObjectivePart inventoryObjectivePart = model.getCoreFactory().createInventoryObjectivePart();
    model.addTabItem(mainTabControl, partSeqTabItem,inventoryObjectivePart);    
}

private
void removePart(){       
    if (model.removePart(partsListView))
        loadHeader();           
}

private 
void partSearchButton_Click(object sender, RoutedEventArgs e){
    partSearch();
}  

private 
void partSearch(){    
    try{    
        InventoryObjectivePart inventoryObjectivePart = getCurrPart();
        if (inventoryObjectivePart!= null) { 
            Product product = model.partSearch(partPartTextBox);
            if (product!= null){
                inventoryObjectivePart.Part = product.ProdID;
                inventoryObjectivePart.ObectivesAutomaticCalc = product.ObectivesAutomaticCalc;
                inventoryObjectivePart.DaysOnHandShow = product.DaysOnHand;
                model.loadPartSequences(seqComboBox,inventoryObjectivePart);                                           
            }
        }
                                                   
    }catch (Exception ex){
        MessageBox.Show("partSearch Exception: " + ex.Message);
    }                       
}

private 
void partDtlDateObjectiveDatePicker_LostFocus(object sender, RoutedEventArgs e){
    if (sender!=null){        
        model.partDtlDateObjectiveDatePickerLostFocus((DatePicker)sender);        
    }
}

private 
void autoCalcButton_Click(object sender, RoutedEventArgs e){
    model.automaticObjectivesCalc(plantFilterComboBox);
}

/******************************************* PartsDtls ****************************************************************/
private 
void partsDtlListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
    model.generateListBom(true,"");
}

private
InventoryObjectivePartDtl getCurrPartDtl(){
    return (InventoryObjectivePartDtl)partDtlTabItem.DataContext;
}

private
void addPDButton_Click(object sender, RoutedEventArgs e){
    addDtl();
}

private
void delPDButton_Click(object sender, RoutedEventArgs e){
    removeDtl();
}

private
void searchPartDtlButton_Click(object sender, RoutedEventArgs e){
    searchPartDtl();    
}

private
void okPartDtlButton_Click(object sender, RoutedEventArgs e){
    savePartDtl();
}

private
void cancelPartDtlButton_Click(object sender, RoutedEventArgs e){
    model.removeTabItem(mainTabControl,partDtlTabItem);    
}

private
void addDtl(){    
    baddingDtl = true;                        
    InventoryObjectivePartDtl   inventoryObjectivePartDtl = model.createDtl(partsListView);

    if (inventoryObjectivePartDtl != null){     
        model.addTabItem(mainTabControl, partDtlTabItem, inventoryObjectivePartDtl);    
    }
}

private
void removeDtl(){       
   model.removeDtl(partsListView,partsDtlListView);        
}

               
private
bool dataOkDtl(){    
    bool                        bresult=true;
    InventoryObjectivePartDtl   inventoryObjectivePartDtl   = getCurrPartDtl();        
    InventoryObjectivePartDtl   inventoryObjectivePartDtlFound = null;        

    if (inventoryObjectivePartDtl == null)
        return false;
    
    if (bresult)
        bresult = model.getValidNumericFromAlpha(this.quantityTextBox, "Required");
    if (bresult)
        bresult = model.getValidNumericFromAlpha(this.qtyReportedTextBox, "Reported");
                   
    if (bresult && inventoryObjectivePartDtl.QtyReported > inventoryObjectivePartDtl.Qty){
        MessageBox.Show("Quantity Reported Might Not Be Bigger Than Objective Quantity.");
        inventoryObjectivePartDtl.QtyReported = inventoryObjectivePartDtl.Qty;
        this.qtyReportedTextBox.Focus();
        bresult= false;                        
    }

    if (bresult)
        bresult = model.getValidNumericFromAlpha(this.partDtlDayOnHandTextBox, "Days On Hand");

    if (bresult && inventoryObjectivePartDtlFound != null){                
        string smess = "Sorry, Already Exist That Part Seq.";        
        MessageBox.Show(smess);
                
    }

    return bresult;
}             

private
void savePartDtl(){
    try{ 
        if (dataOkDtl()) {                         
            if (model.loadModifyPartDtl(baddingDtl,partsListView,partsDtlListView,getCurrPartDtl()) != null){ 
                baddingDtl=false;
                model.removeTabItem(mainTabControl,partDtlTabItem);
            }                        
        }    

    }catch (Exception ex){
        MessageBox.Show("savePartDtl Exception: " + ex.Message);
    }                       
} 

private 
void searchDateObjectiveCheckBox_Click(object sender, RoutedEventArgs e){
    searchDateObjective();
}

private 
void searchDateObjective(){
    searchDateObjectivePicker.IsEnabled = (bool)searchDateObjectiveCheckBox.IsChecked;
}
 
private
void searchPartDtl(){
    try{                                                 
        if ((bool)searchDateObjectiveCheckBox.IsChecked)
            model.searchPartDtl(partsDtlListView,(InventoryObjectivePart)model.getSelected(partsListView),(DateTime)searchDateObjectivePicker.SelectedDate);

    }catch (Exception ex){
        MessageBox.Show("searchPartDtl Exception: " + ex.Message);
    }                       
} 



}
}
