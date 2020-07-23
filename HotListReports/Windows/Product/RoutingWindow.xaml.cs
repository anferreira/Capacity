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
using Nujit.NujitERP.ClassLib.Core.Machines;


namespace HotListReports.Windows.Products{
/// <summary>
/// Interaction logic for RoutingWindow.xaml
/// </summary>
/// 
public partial 
class RoutingWindow : Window{

private RoutingModel model;
private int itabIndex;
private Routing routing;
private bool baddDtl;
private bool bmodeSelect;
private string splantFilter;
private Machine machineFilter;
private Product productFilter;

public RoutingWindow(bool bmodeSelect,string splantFilter,Machine machineFilter=null,Product productFilter=null){
    InitializeComponent();
    this.model = new RoutingModel(this);
    this.itabIndex =0;
    this.routing = null;
    this.baddDtl = false;
    this.bmodeSelect = bmodeSelect;
    this.splantFilter = splantFilter;
    this.machineFilter = machineFilter;
    this.productFilter = productFilter;
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
        model.addButtonsListViewFunctions(this.hdrListView,firstButton,prevButton,nextButton,lastButton);
        model.addButtonsListViewFunctions(this.dtlListView, firstDButton,prevDButton,nextDButton,lastDButton);
        model.loadSearchByCombo(searchByComboBox);
        model.loadColumnsOnHeaderGrid(hdrListView);
        model.loadColumnsOnDetailsGrid(dtlListView);
        model.loadTypeComboBox(typeComboBox);
        //model.loadLabourComboBox(labourComboBox);

        model.loadShiftTaskComboBox(labourComboBox,false);
        model.loadToolComboBox(toolComboBox);
        model.loadRoutingTypeComboBox(routingTypeComboBox);

        model.loadPlantCombo(plantComboBox,true);        
        model.setSelectedComboBoxItem(plantComboBox,splantFilter);
        processFilter();
        
        model.screenFullArea();
        search();
        
    }catch (Exception ex){
        MessageBox.Show("initialize Exception: " + ex.Message);
    }
}

private
void processFilter(){
    try{
        if (machineFilter!= null){
            if (searchByComboBox.Items.Count >1)
                searchByComboBox.SelectedIndex = 1;
            model.setSelectedComboBoxItem(plantComboBox,machineFilter.Plt);
            model.setSelectedComboBoxItem(deptComboBox,machineFilter.Dept);
            searchForTextBox.Text = machineFilter.Mach;
        }        

        if (productFilter!= null)
            searchForTextBox.Text = productFilter.ProdID;

    }catch (Exception ex){
        MessageBox.Show("processFilter Exception: " + ex.Message);
    }
}

public
Routing getSelected(){
    return routing;
}

private 
void hdrListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    if (bmodeSelect){
        routing = (Routing)model.getSelected(hdrListView);
        DialogResult = true;
        Close();
    }else
        mainTabControl.SelectedItem = this.dtlTabItem;
}

private 
void dtlListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    modifyLabTool();
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
                       
            if (indexSel == 0){                
                search();
            }else if (indexSel == 1){
                                               
                if (ipriorIndex == 0){
                    routing =  (Routing)model.getSelected(hdrListView);                                             
                        
                    if (routing != null)
                        loadRouting(routing.Id);
                    else
                        mainTabControl.SelectedItem = this.hdrTabItem;
                }
                      
            }else if (indexSel == 2){
                if (ipriorIndex == 0)
                    mainTabControl.SelectedItem = this.hdrTabItem;
                else{
                    if (!baddDtl){
                        RoutingLabTool routingLabTool =(RoutingLabTool)model.getSelected(dtlListView);
                        if (routingLabTool!=null)
                            loadRoutingLabTool(routingLabTool);
                        else
                            mainTabControl.SelectedItem = this.dtlTabItem;
                    }
                }
            }
        }        
         
    } catch (Exception ex) {        
        MessageBox.Show("mainTabControlSelectionChanged Exception: " + ex.Message);  
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
        string      spart       =searchByComboBox.SelectedIndex == 0 ? searchForTextBox.Text : ""; 
        string      smach       =searchByComboBox.SelectedIndex == 1 ? searchForTextBox.Text : ""; 
        string      splant      =model.getSelectedComboBoxItemString(plantComboBox); 
        string      sdept       =model.getSelectedComboBoxItemString(deptComboBox);      
        string      sroutType   =model.getSelectedComboBoxItemString(routingTypeComboBox);                      
        int         seq=-1;

        if (!string.IsNullOrEmpty(spart))        
            spart = spart + "%";                  
        if (!string.IsNullOrEmpty(smach))        
            smach = smach + "%";    
        
        RoutingContainer routingContainer = model.getCoreFactory().readRoutingByFilters(spart,splant,sdept,seq,smach, sroutType,false,false, irows);        
        model.setDataContextListView(hdrListView,routingContainer);                
        model.setSelected(hdrListView,routing);

        this.searchForTextBox.Focus();
            
    }catch (Exception ex){
        MessageBox.Show("search Exception: " + ex.Message);
    }finally{
        subDtlTabItem.DataContext = null; //clare info
    }
}

private 
void addDButton_Click(object sender, RoutedEventArgs e){
     addLabTool();
}

private 
void modifyLabTool(){
    baddDtl=false;
    mainTabControl.SelectedItem = subDtlTabItem;
}

private 
void addLabTool(){
    RoutingLabTool routingLabTool = model.getCoreFactory().createRoutingLabTool();
    baddDtl=true;    
    loadRoutingLabTool(routingLabTool);
    mainTabControl.SelectedItem = subDtlTabItem;
}

private 
void cancelLabTool(){    
    mainTabControl.SelectedItem = dtlTabItem; //nothing change, just move to detail tab
}

private 
void delDButton_Click(object sender, RoutedEventArgs e){
    model.removeLabTool(routing,dtlListView);    
}

private
void loadRouting(int id){
    routing = model.getCoreFactory().readRouting(id);
    d1Canvas.DataContext = routing;    
    
    baddDtl=false;

    this.dtlListView.DataContext= routing.RoutingLabToolContainer;                
    this.dtlListView.ItemsSource= routing.RoutingLabToolContainer;  
    if (dtlListView.Items.Count > 0)
        dtlListView.SelectedIndex=0;        
}

private
void loadRoutingLabTool(RoutingLabTool routingLabTool){    
    RoutingLabTool routingLabToolAux = routingLabTool;
    if (!baddDtl)
       routingLabToolAux = model.getCoreFactory().cloneRoutingLabTool(routingLabTool);
    
    subDtlTabItem.DataContext = null; //clear info
    subDtlTabItem.DataContext = routingLabToolAux;    
}

private 
void okSubButton_Click(object sender, RoutedEventArgs e){
    saveLabTool();
}

private 
void saveLabTool(){
    try{
        if (dataOkLabTool()){                                        
            string              sdec = model.getSelectedDesc(typeComboBox,labourComboBox,toolComboBox);
            RoutingLabTool      routingLabTool = model.addModifyLabTool(routing, (RoutingLabTool)subDtlTabItem.DataContext, sdec, baddDtl);

            if (routingLabTool!=null){
                model.save(routing);    
                mainTabControl.SelectedItem = this.dtlTabItem;
                loadRouting(routing.Id);
                model.setSelected(dtlListView,routingLabTool);//try to select item 
            }
        }
    }catch (Exception ex){
        MessageBox.Show("saveLabTool Exception: " + ex.Message);
    }
}

private 
bool dataOkLabTool(){    
    bool                bresult=true;
    RoutingLabTool      routingLabTool = (RoutingLabTool)subDtlTabItem.DataContext;
    RoutingLabTool      routingLabToolAux = routing.RoutingLabToolContainer.getByTypeReqId(routingLabTool.Type, routingLabTool.ReqId);
              
    if (string.IsNullOrEmpty(routingLabTool.Type)){
        MessageBox.Show("Please Select Type.");
        bresult=false;   
    }

    if (routingLabTool.ReqId < 1){
        MessageBox.Show("Please Select Labour/Tool.");
        bresult=false;   
    }

    if (bresult){
        if (baddDtl){
            if (routingLabToolAux!=null){ 
                MessageBox.Show("Labour/Tool , Type= " + routingLabTool.Type + " ReqId=" + routingLabTool.ReqId.ToString() + "Already Added, Please Reenter.");
                bresult=false;   
            }
        }else  if (routingLabToolAux!=null && routingLabTool.Detail != routingLabToolAux.Detail){ 
           MessageBox.Show("Labour/Tool , Type= " + routingLabTool.Type + " ReqId=" + routingLabTool.ReqId.ToString() + "Already Added, Please Reenter.");
           bresult=false;   
        }
    }

    if (bresult){
        bresult = model.getValidNumericFromAlpha(this.totEmployeesTextBox, "Total Employees");
        if (!bresult)            
            routingLabTool.TotEmployees = 0;

    }

    return bresult;
} 

private 
void cancelSubButton_Click(object sender, RoutedEventArgs e){
    cancelLabTool();
}

private 
void typeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e){
    showLabTool();
}

private
void showLabTool(){    
    try{
        string      stype  = typeComboBox.SelectedItem != null ? ((Nujit.NujitWms.WinForms.Util.ComboBoxItem)typeComboBox.SelectedItem).Content.ToString() : "";
    
        labourLabel.Visibility = labourComboBox.Visibility = stype.Equals(RoutingLabTool.LABOUR_TYPE)? Visibility.Visible : Visibility.Hidden;
        toolLabel.Visibility = toolComboBox.Visibility = stype.Equals(RoutingLabTool.TOOL_TYPE) ? Visibility.Visible : Visibility.Hidden;

    }catch (Exception ex){
        MessageBox.Show("showLabTool Exception: " + ex.Message);
    }  
}

private 
void copyButton_Click(object sender, RoutedEventArgs e){
    copy();
}

private 
void copy(){
    try{        
        RoutingContainer    routingContainer = model.copy(hdrListView);
                
        if (routingContainer.Count > 0){
            search();
            model.setSelected(hdrListView,routingContainer[0]); //select at list first routing prior selected                         
        }

    }catch (Exception ex){
        MessageBox.Show("copy Exception: " + ex.Message);
    }  
    
}

private 
void plantComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
   model.plantComboBoxSelectionChanged(plantComboBox, deptComboBox);
}

private 
void createDefaultsButton_Click(object sender, RoutedEventArgs e){
    createDefaults();
}

private 
void createDefaults(){    
    if (model.createDefaults())
       search();
}



}
}
