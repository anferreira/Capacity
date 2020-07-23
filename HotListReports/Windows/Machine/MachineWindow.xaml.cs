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
using HotListReports.Windows.Products;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core.Machines;

namespace HotListReports.Windows.Machines{
    
/// <summary>
/// Interaction logic for MachineWindow.xaml
/// </summary>
public partial class MachineWindow : Window{

private MachineModel model;

private string  splant;
private int     itabIndex;
private Machine machine;
private bool    bmodeSelect;


public MachineWindow(bool bmodeSelect,string splant,Machine machine=null){
    InitializeComponent();

    this.bmodeSelect = bmodeSelect;        
    this.model = new MachineModel(this, hdrListView);        
    this.splant = splant;
    this.machine= machine;
    this.itabIndex = 0;   
}
      
public
Machine getSelected(){
    Machine machine = (Machine)model.getSelected(this.hdrListView);
    return machine;
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
    ok();
}

private 
void ok(){
    if (bmodeSelect){ 
        this.DialogResult = true;
        Close();
    }else
        mainTabControl.SelectedItem = defaultTabItem;
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
                loadDefaults();
        }        
         
    } catch (Exception ex) {
        MessageBox.Show("mainTabControlSelectionChanged error:" + ex.Message);
    }    
}

private 
void initialize(){        
    try {                
        model.addButtonsListViewFunctions(this.hdrListView,firstButton,prevButton,nextButton,lastButton);

        ContextMenuListViewFunctions contextMenuListView = model.addContextMenuListViewFunctions(hdrListView);
        model.addContextMenuItem(Constants.OPTIONS_ROUTINGS);
        model.addContextMenuItem(Constants.OPTIONS_CAPACITY);
        model.addContextMenuItem(Constants.OPTIONS_CAPACITY_REPORT);
        model.addContextMenuItem(Constants.OPTIONS_MACHINE_VIEWS);                
        contextMenuListView.contextMenuListViewEventHandler += new ContextMenuListViewEventHandler(contextMenuListViewEventHandlerEvent);
        
        this.recordsTextBox.Text = Configuration.SearchDefaultMaxRecords;
        planDatePicker.SelectedDate = DateTime.Now;
        model.Cursor = this.Cursor;
        model.loadCombo(searchByComboBox,"Machine","Description 1");                    
        model.loadPlantCombo(plantComboBox,false);
        model.loadYesNoComboBox(scheduledComboBox,true);
        model.loadYesNoComboBox(showOnTvReportComboBox,false);                
        model.setSelectedComboBoxItem(plantComboBox,Configuration.DftPlant);
        model.loadColumnsOnHeaderGrid(hdrListView);   
        model.screenFullArea();
        
        if (!string.IsNullOrEmpty(splant))
            model.setSelectedComboBoxItem(plantComboBox,splant);

        if (!bmodeSelect)
            model.setSelectedComboBoxItem(scheduledComboBox,Constants.STRING_YES);            

        applyFilters();
        search();    

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }
}

private 
void applyFilters(){    
    if (machine != null){
        model.setSelectedComboBoxItem(plantComboBox,machine.Plt);
        searchForTextBox.Text = machine.Mach;

        MachineContainer machineContainer = model.getCoreFactory().createMachineContainer();
        machineContainer.Add(machine);
        model.setDataContextListView(hdrListView,machineContainer);
        mainTabControl.SelectedItem = mainTabControl.SelectedItem = defaultTabItem;
    }
}  


private
void contextMenuListViewEventHandlerEvent(object sender, string optionSelected){
    Machine machine = (Machine)model.getSelected(hdrListView);

    switch (optionSelected){        
        case Nujit.NujitWms.ClassLib.Common.Constants.OPTION_CANCEL:
            cancel();                                
            break;
        case Nujit.NujitWms.ClassLib.Common.Constants.OPTION_REFRESH:
            search();
            break;
        case Constants.OPTIONS_ROUTINGS:
            routings();
            break;
        case Constants.OPTIONS_CAPACITY:
            if (machine!= null)
                model.navigateCapacity(machine.Plt);   
            break;

        case Constants.OPTIONS_CAPACITY_REPORT:
            if (machine!= null)
                model.navigateCapacityReport(machine.Plt);   
            break;
        case Constants.OPTIONS_MACHINE_VIEWS:
            if (machine!= null)
                model.navigateMachineViews(machine);   
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
        int         irows   = model.getRecords(recordsTextBox);
        string      smachine= searchByComboBox.SelectedIndex == 0 ? searchForTextBox.Text : ""; 
        string      sdes1   = searchByComboBox.SelectedIndex == 1 ? searchForTextBox.Text : "";
        string      splant  = model.getSelectedComboBoxItemString(plantComboBox);
        string      sdept   = model.getSelectedComboBoxItemString(deptComboBox);
        string      schedule= model.getSelectedComboBoxItemString(scheduledComboBox);
        DateTime    planDate= (bool)planDateCheckBox.IsChecked && planDatePicker.SelectedDate != null ? (DateTime)planDatePicker.SelectedDate : DateUtil.MinValue;

        model.PlannedHdr = model.getCoreFactory().readPlannedHdrLastDateCheck(model.PlannedHdr,splant);

        if (!string.IsNullOrEmpty(smachine))        
            smachine = smachine + "%";  
         if (!string.IsNullOrEmpty(sdes1))        
            sdes1 = sdes1 + "%";                  
               
        MachineContainer machineContainer = model.getCoreFactory().readMachinesViewByFilters(smachine,sdes1,splant,sdept,schedule, planDate,new ArrayList(),false, irows);
        model.loadShiftRemaining(machineContainer,(bool)includeProductionCheckBox.IsChecked);

        model.setDataContextListView(hdrListView,machineContainer);
        model.setSelected(hdrListView,this.machine);
        
        this.searchForTextBox.Focus();
            
    }catch (Exception ex){
        MessageBox.Show("search Exception: " + ex.Message);
    }                       
}  


private 
void okDefaultButton_Click(object sender, RoutedEventArgs e){
   save();
}

private 
void cancelDefaultButton_Click(object sender, RoutedEventArgs e){
    cancel();
}

private
void loadDefaults(){
    machine = model.loadDefaults(hdrListView,mainTabControl, machineTopGroupBox);    
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
void save(){
    try{ 
        if (dataOkDefaults(machine.MachineDef)){
            model.getCoreFactory().updateMachine(machine);
            MessageBox.Show("Machine Updated.");
            mainTabControl.SelectedItem = hdrTabItem;
        } 
    }catch (Exception ex){
        MessageBox.Show("save Exception: " + ex.Message);
    } 
}

private 
bool dataOkDefaults(MachineDef machineDef){    
    bool            bresult=true;
                
    //planning                 
    if (bresult)
        bresult = model.getValidNumericFromAlpha(planRunHrsTextBox, "PlanRunHrs");
    if (bresult)
        bresult = model.getValidNumericFromAlpha(hrsPerShiftTextBox, "HrsPerShift");
    if (bresult)
        bresult = model.getValidNumericFromAlpha(planDownHrsTextBox, "PlanDownHrs");
    if (bresult)
        bresult = model.getValidNumericFromAlpha(planChanOvHrsTextBox, "PlanChanOvHrs");
    if (bresult)
        bresult = model.getValidNumericFromAlpha(stdShiftPerWeekTextBox, "StdShiftPerWeek");
    if (bresult)
        bresult = model.getValidNumericFromAlpha(unitChanOverTimeTextBox, "UnitChanOverTime");

    //oee                 
    if (bresult)
        bresult = model.getValidNumericFromAlpha(oeeTextBox, "OEE");
    if (bresult)
        bresult = model.getValidNumericFromAlpha(perfOaTextBox, "Perf/OA");
    if (bresult)
        bresult = model.getValidNumericFromAlpha(scrapRateTextBox, "ScrapRate");
    if (bresult)
        bresult = model.getValidNumericFromAlpha(netPressRateTextBox, "NetPressRate");

    //other
    if (bresult)
        bresult = model.getValidNumericFromAlpha(directHoursToShiftTextBox, "DirHrToShift");      

    return bresult;
}

private 
void plantComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
   model.plantComboBoxSelectionChanged(plantComboBox, deptComboBox);
}

private 
void routingsButton_Click(object sender, RoutedEventArgs e){
   routings();
}

private
void routings(){
    try{
        Machine machine = (Machine)model.getSelected(hdrListView);                 

        if (machine!= null){
            RoutingWindow routingWindow = new RoutingWindow(false,machine.Plt,machine);
            routingWindow.ShowDialog();                            
        }else
            MessageBox.Show("Please, Select Item First.");                     
    }catch (Exception ex){
        MessageBox.Show("routings Exception: " + ex.Message);
    } 
}

private 
void planDateCheckBox_Click(object sender, RoutedEventArgs e){
    planDateCheckBoxClick();
}

private 
void planDateCheckBoxClick(){
    planDatePicker.IsEnabled = (bool)planDateCheckBox.IsChecked;    
}

private 
void recalcPriority_Click(object sender, RoutedEventArgs e){
    recalcPriority();
}

private 
void recalcPriority(){
    try { 
        MachineContainer machineContainer = this.model.recalcMachinePriority((bool)includeProductionCheckBox.IsChecked);
        model.setDataContextListView(hdrListView,machineContainer);

    }catch (Exception ex){
        MessageBox.Show("recalcPriority Exception: " + ex.Message);
    } 
}

private 
void includeProductionCheckBox_Click(object sender, RoutedEventArgs e){
   includeProductionCheckBoxClick();
}

private 
void includeProductionCheckBoxClick(){
    if (itabIndex == 0)        
        search();
}

private 
void autoPlanButton_Click(object sender, RoutedEventArgs e){
    autoPlan();
}

private 
void autoPlan(){
    machine = getSelected();
    if (model.autoPlan())
        search();
}


}
}
