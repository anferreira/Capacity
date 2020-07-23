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
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core.Machines;

namespace HotListReports.Windows.Demand{
/// <summary>
/// Interaction logic for CapacityHdrWindow.xaml
/// </summary>
public 
partial class CapacityHdrWindow : Window{

private CapacityHdrModel        model;
private ReportTypeViewsModel    reportTypeViewsModel;
    
private int         itabIndex;
private bool        badding;
private CapacityHdr capacityHdr;
private string      splant;
private Machine     machineFilter;

public 
CapacityHdrWindow(string splant="",Machine machineFilter=null){
    InitializeComponent();

    this.itabIndex = 0;   
    this.badding = false;
    this.capacityHdr = null;
    this.machineFilter = machineFilter;

    this.splant = splant;
    if (string.IsNullOrEmpty(splant))
        this.splant = Configuration.DftPlant;

    this.model = new CapacityHdrModel(this);       
    this.reportTypeViewsModel = new ReportTypeViewsModel(this);
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
    try {            
        model.addButtonsListViewFunctions(this.hdrListView,firstButton,prevButton,nextButton,lastButton);
        model.addButtonsListViewFunctions(this.dtlListView, firstDButton,prevDButton,nextDButton,lastDButton);
        model.addButtonsListViewFunctions(this.machCapacityListView, firstMCButton,prevMCButton,nextMCButton,lastMCButton);
        model.removeTabItem(mainTabControl,machPriorityTabItem);  

        this.recordsTextBox.Text = Configuration.SearchDefaultMaxRecords; 
        model.Cursor = this.Cursor;
        model.loadSearchByCombo(searchByComboBox);       
        model.loadPlantCombo(plantComboBox,true); model.setSelectedComboBoxItem(plantComboBox,splant);
        model.loadColumnsOnHeaderGrid(hdrListView);    
        model.loadColumnsOnDetailsGrid(dtlListView);
        model.loadColumnsOnPartDetailsGrid(partDtlListView);
        model.loadColumnsOnRequirementGrid(reqlListView);
        model.loadColumnsOnMachCapacityGrid(machCapacityListView);
        model.screenFullArea();
        search();    

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }
}

private 
void hdrListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    mainTabControl.SelectedItem = this.dtlTabItem;
}

private 
void dtlListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    loadCapacityPart();  
}

private 
void dtlListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
    loadCapacityPart();  
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
            
            if (indexSel < 3)
                model.removeTabItem(mainTabControl,machPriorityTabItem);                        

            if (indexSel == 0){
                capacityHdr=null;                      
                search();
            }else if (indexSel == 1){                            
                if (ipriorIndex == 0){
                    capacityHdr = (CapacityHdr)model.getSelected(hdrListView);                                             
                    if (capacityHdr != null)
                        loadCapacityH(capacityHdr);
                    else
                        mainTabControl.SelectedItem = this.hdrTabItem;
                }

            }else if (indexSel >= 2){      
                if (ipriorIndex == 0)
                    mainTabControl.SelectedItem =  this.hdrTabItem;
                else
                    loadMachineCapacity(capacityHdr);
            }       
        }
                 
    } catch (Exception ex) {
        MessageBox.Show(ex.Message);
    }

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
        string      status  = model.getSelectedComboBoxItemString(stsComboBox);
        string      splant  = model.getSelectedComboBoxItemString(plantComboBox);
        DateTime    fromDate= model.getSelectedDateTime(fromDatePicker);
        DateTime    toDate  = model.getSelectedDateTime(toDatePicker);          
        
        if (!string.IsNullOrEmpty(sid))        
            sid = sid + "%";        

        CapacityHdrContainer capacityHdrContainer = model.getCoreFactory().readCapacityHdrByFilters(sid, splant, status,fromDate, toDate,true, machineFilter!=null ? 1 : irows);

        model.setDataContextListView(hdrListView,capacityHdrContainer);        
        this.searchForTextBox.Focus();

        if (machineFilter!= null && capacityHdrContainer.Count > 0){ //navigate to machine priority
            mainTabControl.SelectedItem = dtlTabItem;
            mainTabControl.SelectedItem = machTabItem;
        }
            
    }catch (Exception ex){
        MessageBox.Show("search Exception: " + ex.Message);
    } finally{
        machineFilter = null;            
    }                                      
}  

private 
void loadCapacityH(CapacityHdr capacityHdrAux){
    try{        
        //this.capacityHdr = null;
        this.badding = false;
        CapacityPartContainer capacityPartContainer = null;
        CapacityMachPriorityContainer capacityMachPriorityContainer = null;

        capacityHdr = model.getCoreFactory().readCapacityHdr(capacityHdrAux.Id);
        dtlTopCanvas.DataContext = capacityHdr;

        idTextBox.Text = statusTextBox.Text = dateTimeTextBox.Text = ""; 
        
        if (capacityHdr != null){                    
            capacityPartContainer        = capacityHdr.CapacityPartContainer;
            capacityMachPriorityContainer= capacityHdr.CapacityMachPriorityContainer;

            idTextBox.Text = Convert.ToInt64(capacityHdrAux.Id).ToString();
            statusTextBox.Text = capacityHdrAux.Status;            
            dateTimeTextBox.Text = DateUtil.getCompleteDateRepresentation(capacityHdrAux.DateCreated,DateUtil.MMDDYYYY);                                    
        }  
                
        model.setDataContextListView(machCapacityListView,capacityMachPriorityContainer);
        model.setDataContextListView(dtlListView,capacityPartContainer);
                          
    }catch (Exception ex){
        MessageBox.Show("loadCapacityH Exception: " + ex.Message);
    }
}

private 
void loadMachineCapacity(CapacityHdr capacityHdr){
    try { 
        CapacityMachPriorityContainer capacityMachPriorityContainer = null;

        if (capacityHdr != null)                                
            capacityMachPriorityContainer= capacityHdr.CapacityMachPriorityContainer;

        model.setDataContextListView(machCapacityListView,capacityMachPriorityContainer);

        if (machineFilter != null && capacityMachPriorityContainer != null) { 
            CapacityMachPriority capacityMachPriority = capacityMachPriorityContainer.getByMachine(machineFilter.Id);
            if (capacityMachPriority!= null)
                model.setSelected(machCapacityListView,capacityMachPriority);
        }

    }catch (Exception ex){
        MessageBox.Show("loadMachineCapacity Exception: " + ex.Message);
    }
}


private 
void loadCapacityPart(){
    try{        
        CapacityPart                capacityPart = (CapacityPart)model.getSelected(this.dtlListView);
        CapacityPartDtlContainer    capacityPartDtlContainer = null;
        CapacityReqContainer        capacityReqContainer = null;

        if (capacityPart!= null){
            capacityPartDtlContainer = capacityPart.CapacityPartDtlContainer;            
            capacityReqContainer = capacityPart.CapacityReqContainer;
        }

        model.setDataContextListView(partDtlListView,capacityPartDtlContainer);
        model. loadReqDescription(capacityReqContainer);
        model.setDataContextListView(reqlListView, capacityReqContainer);
                                         
    }catch (Exception ex){
        MessageBox.Show("loadCapacityPart Exception: " + ex.Message);
    }
}

#region Buttons

private 
void firstButton_Click(object sender, RoutedEventArgs e){
    
}

private 
void prevButton_Click(object sender, RoutedEventArgs e){
    
}

private 
void nextButton_Click(object sender, RoutedEventArgs e){
    
}

private 
void lastButton_Click(object sender, RoutedEventArgs e){
   
}

private 
void firstDButton_Click(object sender, RoutedEventArgs e){
   
}

private 
void prevDButton_Click(object sender, RoutedEventArgs e){
   
}

private 
void nextDButton_Click(object sender, RoutedEventArgs e){
   
}

private 
void lastDButton_Click(object sender, RoutedEventArgs e){

}


#endregion Buttons

private 
void detailButton_Click(object sender, RoutedEventArgs e){
    //editDtl();
}

private 
void saveButton_Click(object sender, RoutedEventArgs e){
    //saveDemand();
}


private 
void showReportButton_Click(object sender, RoutedEventArgs e){
    showReport();
}

private 
void showReport(){
    model.showReport(hdrListView);
}

private 
void createCapacityButton_Click(object sender, RoutedEventArgs e){
    createCapacity();
}

private 
void createCapacity(){
    if (model.createCapacity())
        search();        
}

private 
void delButton_Click(object sender, RoutedEventArgs e){
    delete();
}

private 
void delete(){
    if (model.delete(hdrListView))
        search();
}

private 
void searchDtlButton_Click(object sender, RoutedEventArgs e){
    searchDtl();
}

private 
void searchDtl(){
    try{                        
        CapacityPartContainer   capacityPartContainer = model.getCoreFactory().createCapacityPartContainer();
        string                  spart   = this.searchForPartTextBox.Text;

        if (capacityHdr!= null){
            if (!string.IsNullOrEmpty(spart))        
                spart = spart + "%";
            capacityPartContainer = capacityHdr.CapacityPartContainer.getByFilters(spart);
        }
        model.setDataContextListView(dtlListView,capacityPartContainer);        
                            
    }catch (Exception ex){
        MessageBox.Show("searchDtl Exception: " + ex.Message);
    }                       
}  

private 
void searchMachButton_Click(object sender, RoutedEventArgs e){
    searchMachine();
}

private 
void searchMachine(){
    try{                        
        CapacityMachPriorityContainer   capacityMachPriorityContainer = model.getCoreFactory().createCapacityMachPriorityContainer();
        string                          smachine = this.searchForMachineTextBox.Text;

        if (capacityHdr!= null){
            if (!string.IsNullOrEmpty(smachine))
                smachine = smachine + "%";
            capacityMachPriorityContainer = capacityHdr.CapacityMachPriorityContainer.getByFilters(smachine);
        }
        model.setDataContextListView(machCapacityListView,capacityMachPriorityContainer);        
                            
    }catch (Exception ex){
        MessageBox.Show("searchMachine Exception: " + ex.Message);
    }                       
} 

/********************************************** CapacityMachPriority*************************************************/
private 
void machCapacityListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    modifyMachCapacity();
}

private 
void modifyMachCapacity(){
    badding = false;
    CapacityMachPriority capacityMachPriority = (CapacityMachPriority)model.getSelected(machCapacityListView);    
    if (capacityMachPriority!= null)
        showMachCapacity(model.getCoreFactory().cloneCapacityMachPriority(capacityMachPriority));
}

private 
void addMCButton_Click(object sender, RoutedEventArgs e){
    addMachCapacity();
}

private 
void delMCButton_Click(object sender, RoutedEventArgs e){
    model.delMachCapacity(machCapacityListView,capacityHdr);
}

private 
void okMCButton_Click(object sender, RoutedEventArgs e){
   saveMachCapacity();
}

private 
void cancelMCButton_Click(object sender, RoutedEventArgs e){
    cancelMachCapacity();
}

private 
void machIdButton_Click(object sender, RoutedEventArgs e){
    model.searchMachineId(capacityHdr,(CapacityMachPriority)machPriorityTabItem.DataContext);    
}

private 
void machPartButton_Click(object sender, RoutedEventArgs e){
    model.searchPartId((CapacityMachPriority)machPriorityTabItem.DataContext);    
}
        
private 
void cancelMachCapacity(){   
    if (model.cancel()){
        badding=false;
        model.removeTabItem(mainTabControl,machPriorityTabItem);        
    }
}

private 
void addMachCapacity(){
    try{        
        badding=true;
        CapacityMachPriority    capacityMachPriority = model.getCoreFactory().createCapacityMachPriority();
        CapacityMachPriority    lastCapacityMachPriority = capacityHdr.CapacityMachPriorityContainer.Count > 0? capacityHdr.CapacityMachPriorityContainer[capacityHdr.CapacityMachPriorityContainer.Count-1] : null;
        int                     ipriority = lastCapacityMachPriority!= null ? lastCapacityMachPriority.Priority+1 : 1;
        capacityMachPriority.Priority = ipriority;    

        showMachCapacity(capacityMachPriority);
                                  
    }catch (Exception ex){
        MessageBox.Show("addMachCapacity Exception: " + ex.Message);
    }
}

private 
void showMachCapacity(CapacityMachPriority capacityMachPriority){
    try{                
        model.addTabItem(mainTabControl,machPriorityTabItem, capacityMachPriority);               
        machIdButton.Visibility = badding ? Visibility.Visible : Visibility.Hidden;            
                                           
    }catch (Exception ex){
        MessageBox.Show("showMachCapacity Exception: " + ex.Message);
    }
}

private 
bool dataOkMachCapacity(CapacityMachPriority capacityMachPriority){
    bool bresult=true;

    if (capacityHdr == null)
        return false;
    if (capacityMachPriority == null)
        return false;
            
    //planning                 
    if (bresult)
        bresult = model.getValidNumericFromAlpha(machPriorityTextBox, "Priority");
    if (bresult)
        bresult = model.getValidNumericFromAlpha(qtyMachTextBox, "Qty");

    if (capacityMachPriority.MachineId < 1){
        MessageBox.Show("Please, Select Machined Id.");
        bresult=false;
    }

    if (bresult){
        if (badding){
            CapacityMachPriority capacityMachPriorityAux = capacityHdr.CapacityMachPriorityContainer.getByMachine(capacityMachPriority.MachineId);
            if (capacityMachPriorityAux!= null){
                MessageBox.Show("Sorry, Machine Already Selected, With Priority " + capacityMachPriorityAux.Priority + ".");
                bresult=false;
            }
        }
    }

    if (bresult)
        capacityHdr.CapacityMachPriorityContainer.adjustPriorities(capacityMachPriority);

    return bresult;
}

private 
void saveMachCapacity(){    
    try{   
        CapacityMachPriority capacityMachPriority = (CapacityMachPriority)machPriorityTabItem.DataContext;

        if (dataOkMachCapacity(capacityMachPriority)){            
            if (model.saveCapacityMachPriority(machCapacityListView, capacityHdr,capacityMachPriority,badding)) { 
                mainTabControl.SelectedItem = machTabItem;    
                model.setSelected(machCapacityListView,capacityMachPriority);                                
            }        
        }   

    }catch (Exception ex){
        MessageBox.Show("saveMachCapacity Exception: " + ex.Message);
    }
}

private 
void recalcPriority_Click(object sender, RoutedEventArgs e){
    recalcPriority();
}

private 
void recalcPriority(){
    try { 
        reportTypeViewsModel.CapacityHdr = capacityHdr;
        reportTypeViewsModel.recalcMachinePriority(false);
        capacityHdr = reportTypeViewsModel.CapacityHdr;
        loadMachineCapacity(capacityHdr);

        MessageBox.Show("Priorities Recalculated.");

    }catch (Exception ex){
        MessageBox.Show("recalcPriority Exception: " + ex.Message);
    }
}
                  
}
}
