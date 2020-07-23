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
using Nujit.NujitERP.ClassLib.Core.ScheduleDemand;

using Nujit.NujitWms.WinForms.Util.Grids;
using Nujit.NujitWms.WinForms.Util.Converters;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using System.Collections.ObjectModel;
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Common;

namespace HotListReports.Windows.Demand{

/// <summary>
/// Interaction logic for ScheduleHdrWindow.xaml
/// </summary>
public partial class ScheduleHdrWindow : Window{

private ScheduleHdrModel scheduleHdrModel;
private int itabIndex;
private ScheduleHdr scheduleHdr;
private bool badding;
private bool baddingDtl;    
private bool baddingReq;    
private ButtonsListViewFunctions buttonsListViewFunctions;
private ButtonsListViewFunctions buttonsListViewPFunctions;
private ButtonsListViewFunctions buttonsListViewTFunctions;
private ButtonsListViewFunctions buttonsListViewRPFunctions;
private ButtonsListViewFunctions buttonsListViewRTFunctions;

private ButtonsListViewFunctions buttonsListViewR1Functions;    

public ScheduleHdrWindow(){
    InitializeComponent();
    
    this.itabIndex = 0;
    this.scheduleHdr = null;     
    this.badding = this.baddingDtl = this.baddingReq = false;
    this.scheduleHdrModel = new ScheduleHdrModel();          
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){        
    initialize();
}

private 
void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e){
    closing();
}

private 
void closing(){
    if (scheduleHdrModel != null)
        scheduleHdrModel.Dispose();
}

private 
void initialize(){        
    try {
        //list view scrolls
        buttonsListViewFunctions = new ButtonsListViewFunctions(this.hdrListView,firstButton,prevButton,nextButton,lastButton);        
        buttonsListViewPFunctions = new ButtonsListViewFunctions(this.dtlListView,firstPButton,prevPButton,nextPButton,lastPButton);
        buttonsListViewTFunctions = new ButtonsListViewFunctions(this.sheduleTaskListView, firstSButton,prevSButton,nextSButton,lastSButton);
        buttonsListViewRPFunctions = new ButtonsListViewFunctions(this.reqPartListView, firstRPButton, prevRPButton, nextRPButton, lastRPButton);
        buttonsListViewRTFunctions = new ButtonsListViewFunctions(this.reqTaskListView, firstRTButton, prevRTButton, nextRTButton, lastRTButton);

        buttonsListViewR1Functions = new ButtonsListViewFunctions(this.req1lListView, firstR1Button, prevR1Button, nextR1Button, lastR1Button);        
                

        this.recordsTextBox.Text = "50";
        scheduleHdrModel.setCursor(this.Cursor);
        scheduleHdrModel.loadSearchByCombo(searchByComboBox);
        //grid columns
        scheduleHdrModel.loadColumnsOnHeaderGrid(hdrListView);            
        scheduleHdrModel.loadColumnsOnPartGrid(dtlListView);
        scheduleHdrModel.loadColumnsOnPartDetailsGrid(partDtlListView);
        scheduleHdrModel.loadColumnsOnTaskGrid(sheduleTaskListView);
        scheduleHdrModel.loadColumnsOnRequirementGrid(req1lListView);        
        scheduleHdrModel.loadColumnsOnRequirementGrid(reqPartListView);
        scheduleHdrModel.loadColumnsOnRequirementGrid(reqTaskListView);
        //load status
        scheduleHdrModel.loadStatus(stsComboBox,true);
        scheduleHdrModel.loadStatus(statusComboBox,false);
                
        scheduleHdrModel.loadReqTypes(reqTypeComboBox);                
        //load shifts
        scheduleHdrModel.loadShiftNumComboBox(this.partShiftComboBox,Constants.MAX_SHIFTS,false);
        scheduleHdrModel.loadShiftNumComboBox(this.taskShiftComboBox,Constants.MAX_SHIFTS,false);

        removeAllTabs();
        search();    

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }
}

private
void removeAllTabs(){
    removeSchedulePartTabItem();
    removeScheduleTaskTabItem();
    removeRequirmentTabItem();
}

private
void removeSchedulePartTabItem(){
    if (mainTabControl.Items.IndexOf(schedulePartTabItem) >= 0)
        mainTabControl.Items.Remove(schedulePartTabItem); 
}

private
void removeScheduleTaskTabItem(){
    if (mainTabControl.Items.IndexOf(scheduleTaskTabItem) >=0)
        mainTabControl.Items.Remove(this.scheduleTaskTabItem); 
}

private
void removeRequirmentTabItem(){
    if (mainTabControl.Items.IndexOf(requirmentTabItem) >= 0)
        mainTabControl.Items.Remove(this.requirmentTabItem);  
} 

private 
void hdrListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    badding=false;
    mainTabControl.SelectedItem = this.dtlTabItem;
}

private 
void dtlListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    modifyPart();  
}
    
private 
void addR1Button_Click(object sender, RoutedEventArgs e){
    modifyPart();
}

private 
void addR2Button_Click(object sender, RoutedEventArgs e){
    modifyTask();
}

private 
void delR1Button_Click(object sender, RoutedEventArgs e){
     scheduleHdrModel.delRequirment(this.req1lListView,(SchedulePart)scheduleHdrModel.getSelected(dtlListView));
}

private 
void dtlListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
    scheduleHdrModel.loadRequirmentGrid((SchedulePart)scheduleHdrModel.getSelected(dtlListView),req1lListView);    
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
                this.badding=false;
                this.scheduleHdr = null;
                removeAllTabs();
                search();
            }else if (indexSel == 1){
                 removeAllTabs();
                 if (ipriorIndex == 0){
                    if (!badding){
                        scheduleHdr = (ScheduleHdr)scheduleHdrModel.getSelected(hdrListView);
                        if (scheduleHdr!=null)
                            scheduleHdr = scheduleHdrModel.getCoreFactory().readScheduleHdr(scheduleHdr.Id);                        
                    }
                    
                    if (scheduleHdr != null)
                        loadScheduleH(scheduleHdr);
                    else
                        mainTabControl.SelectedItem = this.hdrTabItem;
                }                                               

            }else if (indexSel == 2){//schedule part
                removeRequirmentTabItem();
            }
        }
        this.itabIndex = indexSel;
         
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
        int         irows   = scheduleHdrModel.getRecords(recordsTextBox);
        string      sid     = searchByComboBox.SelectedIndex == 0 ? searchForTextBox.Text : "";
        string      status  = stsComboBox.SelectedItem != null ? ((Nujit.NujitWms.WinForms.Util.ComboBoxItem)stsComboBox.SelectedItem).Content.ToString() : "";
        DateTime    fromDate= fromDatePicker.SelectedDate != null ? (DateTime)fromDatePicker.SelectedDate : DateUtil.MinValue;
        DateTime    toDate  = toDatePicker.SelectedDate != null ?   (DateTime)toDatePicker.SelectedDate : DateUtil.MinValue;          
        
        if (!string.IsNullOrEmpty(sid))        
            sid = sid + "%";        

        ScheduleHdrContainer scheduleHdrContainer = scheduleHdrModel.getCoreFactory().readScheduleHdrByFilters(sid, status,fromDate, toDate,true, irows);

        this.hdrListView.DataContext= scheduleHdrContainer;                
        this.hdrListView.ItemsSource= scheduleHdrContainer;   
        if (hdrListView.Items.Count > 0)
            hdrListView.SelectedIndex=0;
        
        this.searchForTextBox.Focus();
            
    }catch (Exception ex){
        MessageBox.Show("search Exception: " + ex.Message);
    }                       
}  

private 
void loadScheduleH(ScheduleHdr scheduleHdr){
    try{                
        SchedulePartContainer schedulePartContainer = null;
        ScheduleTaskContainer scheduleTaskContainer= null;

        MessageBox.Show("scheduleHdr:" + scheduleHdr .Id + "\n Status:"+ scheduleHdr.Status);                        
        dtlTopCanvas.DataContext = scheduleHdr;

        idTextBox.Text = dateTimeTextBox.Text = ""; 
        
        if (scheduleHdr != null){                    
            schedulePartContainer = scheduleHdr.SchedulePartContainer;

            idTextBox.Text = Convert.ToInt64(scheduleHdr.Id).ToString();
            //statusTextBox.Text = scheduleHdr.Status;            
            dateTimeTextBox.Text = DateUtil.getCompleteDateRepresentation(scheduleHdr.DateCreated,DateUtil.MMDDYYYY);                                    

            scheduleTaskContainer = scheduleHdr.ScheduleTaskContainer;
        }  
        
        MessageBox.Show("schedulePartContainer="+ schedulePartContainer.Count + "\n" + "scheduleTaskContainer=" + scheduleTaskContainer.Count); 
        //schedule part
        this.dtlListView.DataContext= schedulePartContainer;
        this.dtlListView.ItemsSource= schedulePartContainer;
              
        if (dtlListView.Items.Count > 0)
            this.dtlListView.SelectedIndex = 0;


        //schedule task
        this.sheduleTaskListView.DataContext= scheduleTaskContainer;
        this.sheduleTaskListView.ItemsSource= scheduleTaskContainer;
              
        if (sheduleTaskListView.Items.Count > 0)
            this.sheduleTaskListView.SelectedIndex = 0;
    
                          
    }catch (Exception ex){
        MessageBox.Show("loadScheduleH Exception: " + ex.Message);
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
    this.badding = false;
    mainTabControl.SelectedItem = hdrTabItem;
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
void add(){    
    try{
        this.badding=true;
        this.scheduleHdrModel.add(out scheduleHdr);         
        mainTabControl.SelectedItem = dtlTabItem;
                                           
    }catch (Exception ex){
        MessageBox.Show("add Exception: " + ex.Message);
    }                       
}

private 
void del(){    
    try{
        if (scheduleHdrModel.del(hdrListView))
            search();                                                       
    }catch (Exception ex){
        MessageBox.Show("del Exception: " + ex.Message);
    }                       
}

private 
void save(){    
    scheduleHdrModel.save(scheduleHdr);    
}

private 
void partSearchButton_Click(object sender, RoutedEventArgs e){
    partSearch();
}  

private 
void partSearch(){    
    try{
        scheduleHdrModel.partSearch(partTextBox,(SchedulePart)schedulePartTabItem.DataContext);
                                                   
    }catch (Exception ex){
        MessageBox.Show("partSearch Exception: " + ex.Message);
    }                       
}

private
void modifyPart(){
    try{
        this.baddingDtl = false;    
        SchedulePart schedulePart = (SchedulePart)scheduleHdrModel.getSelected(this.dtlListView);
        loadPart(schedulePart);        
    }catch (Exception ex){
        MessageBox.Show("modifyPart Exception: " + ex.Message);
    }    

} 

private 
void addPart(){    
    try{
        this.baddingDtl = true;
        SchedulePart schedulePart = scheduleHdrModel.getCoreFactory().createSchedulePart();
        loadPart(schedulePart);
    }catch (Exception ex){
        MessageBox.Show("addPart Exception: " + ex.Message);
    }                       
}

private
void loadPart(SchedulePart schedulePart){    
    try{       
        addCustPartTabItem(schedulePart); 
        if (schedulePart!=null){
            scheduleHdrModel.loadPartDetails(partDtlListView, schedulePart.SchedulePartDtlContainer);  
            scheduleHdrModel.loadRequirmentGrid(reqPartListView, schedulePart.ScheduleReqContainer);            
        }
    }catch (Exception ex){
        MessageBox.Show("loadPart Exception: " + ex.Message);
    }                       
}

private
SchedulePart getSelectedPart(){ 
    return (SchedulePart)schedulePartTabItem.DataContext;
}

private
ScheduleTask getSelectedTask(){ 
    return (ScheduleTask)scheduleTaskTabItem.DataContext;
}

private 
bool dataOkPart(){    
    bool            bresult=true;
    SchedulePart    schedulePart = getSelectedPart();    

    if (!scheduleHdrModel.validProduct(schedulePart,partTextBox))
        bresult= false;

    if (schedulePart.EndDate > schedulePart.StartDate){
        MessageBox.Show("End Date Might Be Bigger Than Start Date.");
        this.startDatePicker.Focus();
        bresult= false;                        
    }
    return bresult;
}

private
void savePart(){
    try{
        SchedulePart schedulePart  = getSelectedPart();
        if (dataOkPart()){
            if (baddingDtl){
                this.scheduleHdr.SchedulePartContainer.Add(schedulePart);                               
            }        
            this.scheduleHdr.fillRedundances();
            loadScheduleH(scheduleHdr);   
            removeSchedulePartTabItem();                                  
        }
    }catch (Exception ex){
        MessageBox.Show("savePart Exception: " + ex.Message);
    }  
}  

private 
void okPartButton_Click(object sender, RoutedEventArgs e){
    savePart();
}  

private 
void cancelPartButton_Click(object sender, RoutedEventArgs e){
    cancelDtl(schedulePartTabItem);              
}
 
private
void addCustPartTabItem(SchedulePart schedulePart){
    if (mainTabControl.Items.IndexOf(schedulePartTabItem) < 0)
        mainTabControl.Items.Add(schedulePartTabItem);        
    mainTabControl.SelectedItem =schedulePartTabItem;
    schedulePartTabItem.DataContext =schedulePart;
}

private
void addShiftTaskTabItem(ScheduleTask scheduleTask){
    if (mainTabControl.Items.IndexOf(scheduleTaskTabItem) < 0)
        mainTabControl.Items.Add(scheduleTaskTabItem);        
    mainTabControl.SelectedItem = scheduleTaskTabItem;
    scheduleTaskTabItem.DataContext = scheduleTask;
}
       
private 
void addPButton_Click(object sender, RoutedEventArgs e){
    addPart();
} 

private 
void delPButton_Click(object sender, RoutedEventArgs e){
    delPart();
}
private 
void delPart(){
    this.baddingDtl = false;    
    scheduleHdrModel.deleteSchedulePart(this.scheduleHdr, dtlListView);    
}

private 
void addSButton_Click(object sender, RoutedEventArgs e){
    addTask();
}

private 
void delSButton_Click(object sender, RoutedEventArgs e){
    delTask();
}

private 
void delTask(){
    this.baddingDtl = false;    
    scheduleHdrModel.deleteScheduleTask(this.scheduleHdr,sheduleTaskListView);
}

private 
void okSheduleTaskButton_Click(object sender, RoutedEventArgs e){
    saveTask();
}

private 
void cancelScheduleTaskButton_Click(object sender, RoutedEventArgs e){
    cancelDtl(this.scheduleTaskTabItem);
}

private 
void cancelDtl(TabItem tabItem){    
    try{
        this.baddingDtl = false;
        if (mainTabControl.Items.IndexOf(tabItem) < 0)
            mainTabControl.Items.Remove(tabItem);
        mainTabControl.SelectedItem = dtlTabItem;        
    }catch (Exception ex){
        MessageBox.Show("cancelDtl Exception: " + ex.Message);
    }                       
}

private 
void addTask(){    
    try{
        this.baddingDtl = true;
        ScheduleTask scheduleTask = scheduleHdrModel.getCoreFactory().createScheduleTask();
        loadTask(scheduleTask);            
    }catch (Exception ex){
        MessageBox.Show("addTask Exception: " + ex.Message);
    }                       
}

private
void modifyTask(){
    try{
        this.baddingDtl = false;            
        ScheduleTask scheduleTask = (ScheduleTask)scheduleHdrModel.getSelected(this.sheduleTaskListView);
        loadTask(scheduleTask);        
    }catch (Exception ex){
        MessageBox.Show("modifyTask Exception: " + ex.Message);
    }    

} 

private
void loadTask(ScheduleTask scheduleTask){    
    try{       
        addShiftTaskTabItem(scheduleTask);  
        if (scheduleTask != null)
            scheduleHdrModel.loadRequirmentGrid(reqTaskListView, scheduleTask.ScheduleReqContainer);                                                            
    }catch (Exception ex){
        MessageBox.Show("loadTask Exception: " + ex.Message);
    }                       
}

private 
bool dataOkTask(){    
    bool            bresult=true;
    ScheduleTask    scheduleTask = (ScheduleTask)scheduleTaskTabItem.DataContext;    
 
    if (scheduleTask.EndDate > scheduleTask.StartDate){
        MessageBox.Show("End Date Might Be Bigger Than Start Date.");
        this.startSDatePicker.Focus();
        bresult= false;                                
    }
    return bresult;
}

private
void saveTask(){
    try{
        ScheduleTask    scheduleTask = (ScheduleTask)scheduleTaskTabItem.DataContext;    

        MessageBox.Show("saveTask 1");
        if (dataOkTask()){

            MessageBox.Show("saveTask 2");

            if (baddingDtl){
                MessageBox.Show("saveTask 3");
                this.scheduleHdr.ScheduleTaskContainer.Add(scheduleTask);                     
                MessageBox.Show("saveTask 3 ScheduleTaskContainer:" + this.scheduleHdr.ScheduleTaskContainer.Count);                              
            }        
            this.scheduleHdr.fillRedundances();
            loadScheduleH(scheduleHdr);
            MessageBox.Show("saveTask 4");                        
            removeScheduleTaskTabItem();
        }

    }catch (Exception ex){
        MessageBox.Show("saveTask Exception: " + ex.Message);
    }  
}


private 
void sheduleTaskListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    modifyTask();  
}

/************************ Requirment    *****************************************************************/

private
bool partInvolved() {
     return (mainTabControl.Items.IndexOf(schedulePartTabItem) >=0);
}

private
bool taskInvolved() {
     return (mainTabControl.Items.IndexOf(scheduleTaskTabItem) >=0);
}

private 
void reqPartListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    modifyRequirment();  
}

private
void addRequirmentTabItem(ScheduleReq scheduleReq){
    if (mainTabControl.Items.IndexOf(requirmentTabItem) < 0)
        mainTabControl.Items.Add(requirmentTabItem);        
    mainTabControl.SelectedItem = requirmentTabItem;
    requirmentTabItem.DataContext = scheduleReq;
}

private
ScheduleReq getSelectedReq(){ 
    return (ScheduleReq)requirmentTabItem.DataContext;
}

private 
void addRPButton_Click(object sender, RoutedEventArgs e){
    addRequirment();
}

private 
void delRPButton_Click(object sender, RoutedEventArgs e){
    delRequirment();
}
        

private 
void addRequirment(){    
    try{
        this.baddingReq = true;
        ScheduleReq scheduleReq = scheduleHdrModel.getCoreFactory().createScheduleReq();
        addRequirmentTabItem(scheduleReq);             
    }catch (Exception ex){
        MessageBox.Show("addRequirment Exception: " + ex.Message);
    }    
}

private 
void delRequirment(){    
    if (partInvolved())
        scheduleHdrModel.delRequirment(reqPartListView, getSelectedPart());
    else if (taskInvolved())
        scheduleHdrModel.delRequirment(reqTaskListView, getSelectedTask());
}

private 
void reqIdButton_Click(object sender, RoutedEventArgs e){
    scheduleHdrModel.searchReqId(getSelectedReq());
}

private 
void okRequirmentButton_Click(object sender, RoutedEventArgs e){
    okRequirment();
}

private 
void okRequirment(){  
    if (partInvolved())
        savePartRequirment();
    else if (taskInvolved())
        saveTaskRequirment();        
}

private 
void cancelRequirmentButton_Click(object sender, RoutedEventArgs e){
    cancelRequirment();
}

private 
void cancelRequirment(){
    if (partInvolved())
        cancelRequirment(schedulePartTabItem);
    else if (taskInvolved())
        cancelRequirment(scheduleTaskTabItem);    
}   

private
void cancelRequirment(TabItem tabItem){    
    try{
        this.baddingReq = false;
        removeRequirmentTabItem();        
        if (mainTabControl.Items.IndexOf(tabItem) >=0)
            mainTabControl.SelectedItem = tabItem;        
    }catch (Exception ex){
        MessageBox.Show("cancelRequirment Exception: " + ex.Message);
    }                       
}
                    
private
void modifyRequirment(){
    try{
        this.baddingReq = false;    
        ScheduleReq scheduleReq = null;

        if (partInvolved())
            scheduleReq = (ScheduleReq)scheduleHdrModel.getSelected(reqPartListView);
        else if (taskInvolved())
            scheduleReq = (ScheduleReq)scheduleHdrModel.getSelected(reqTaskListView);
        
        addRequirmentTabItem(scheduleReq);               
    }catch (Exception ex){
        MessageBox.Show("modifyRequirment Exception: " + ex.Message);
    }    

}           
        
private 
bool dataOkRequirment(ScheduleReq scheduleReq){    
    bool            bresult=true;
     
    if (scheduleReq.ReqID <= 0){
        MessageBox.Show("Please, Select Requirment.");        
        bresult= false;                                
    }

    if (scheduleReq.Hours <= 0){
        MessageBox.Show("Please, Entry Hours.");
        this.reqHourTextBox.Focus();
        bresult= false;                                
    }
    
    return bresult;
}
                                       
    
private
void savePartRequirment(){
     try{
        ScheduleReq     scheduleReq = getSelectedReq();
        SchedulePart    schedulePart= getSelectedPart();

        MessageBox.Show("saveRequirment 1");
        if (schedulePart!= null && dataOkRequirment(scheduleReq)){

            MessageBox.Show("saveRequirment 2");

            if (baddingReq){
                MessageBox.Show("saveRequirment 3");
                schedulePart.ScheduleReqContainer.Add(scheduleReq);                                    
                MessageBox.Show("saveRequirment 3 ScheduleReqContainer:" + schedulePart.ScheduleReqContainer.Count);                              
            }
            baddingReq=false;
            this.scheduleHdr.fillRedundances();
            scheduleHdrModel.loadRequirmentGrid(reqPartListView, schedulePart.ScheduleReqContainer);        
            removeRequirmentTabItem();
            MessageBox.Show("saveRequirment 4");                
        
        }

    }catch (Exception ex){
        MessageBox.Show("savePartRequirment Exception: " + ex.Message);
    }  
}           
        
private
void saveTaskRequirment(){
    try{
        ScheduleReq     scheduleReq = getSelectedReq();
        ScheduleTask    scheduleTask = getSelectedTask();

        MessageBox.Show("saveTaskRequirment 1");
        if (scheduleTask != null && dataOkRequirment(scheduleReq)){

            MessageBox.Show("saveTaskRequirment 2");

            if (baddingReq){
                MessageBox.Show("saveTaskRequirment 3");
                scheduleTask.ScheduleReqContainer.Add(scheduleReq);                                    
                MessageBox.Show("saveTaskRequirment 3 ScheduleReqContainer:" + scheduleTask.ScheduleReqContainer.Count);                              
            }
            baddingReq=false;
            this.scheduleHdr.fillRedundances();
            scheduleHdrModel.loadRequirmentGrid(reqTaskListView, scheduleTask.ScheduleReqContainer);        
            MessageBox.Show("saveTaskRequirment 4");
            removeRequirmentTabItem();
        }
    }catch (Exception ex){
        MessageBox.Show("saveTaskRequirment Exception: " + ex.Message);
    }  

}              

private 
void reqTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
    reqTypeSeleacted();
}

private 
void reqTypeSeleacted() {
    try{
        string      stype = reqTypeComboBox.SelectedItem != null ? ((Nujit.NujitWms.WinForms.Util.ComboBoxItem)reqTypeComboBox.SelectedItem).Content.ToString() : "";
        ScheduleReq scheduleReq = getSelectedReq();

        this.reqHourTextBox.IsEnabled = true;
        this.reqEmployeeHoursTextBox.IsEnabled = this.reqTotEmployeesTextBox.IsEnabled = false;        

        if (scheduleReq!=null){
            scheduleReq.Type = stype;

            switch(scheduleReq.Type){
                case CapacityReq.REQUIREMENT_LABOUR:
                    scheduleReq.ReqID =1;

                    this.reqHourTextBox.IsEnabled = false;
                    this.reqEmployeeHoursTextBox.IsEnabled = this.reqTotEmployeesTextBox.IsEnabled = true;
                    this.reqTotEmployeesTextBox.Focus();
                    break;
                case CapacityReq.REQUIREMENT_MACHINE:            
                    break;
                case CapacityReq.REQUIREMENT_TASK:            
                    break;
                case CapacityReq.REQUIREMENT_TOOL:            
                    break;
            }
        }   

    }catch (Exception ex){
        MessageBox.Show("reqTypeSeleacted Exception: " + ex.Message);
    }  
}

private
void reqHoursTextBox_LostFocus(object sender, RoutedEventArgs e){
    calcLabourHours();   
}

private
void reqTotEmployeesTextBox_LostFocus(object sender, RoutedEventArgs e){
    calcLabourHours();
}

private
void calcLabourHours(){
    try{
        ScheduleReq scheduleReq = getSelectedReq();    
        if (scheduleReq!=null)
            scheduleReq.Hours = scheduleReq.TotEmployees * scheduleReq.EmployeeHours;
    }catch (Exception ex){
        MessageBox.Show("calcLabourHours Exception: " + ex.Message);
    } 
}

private 
void reqTaskListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    modifyRequirment();  
}


private 
void addRTButton_Click(object sender, RoutedEventArgs e){
    addRequirment();
}

private 
void delRTButton_Click(object sender, RoutedEventArgs e){
    delRequirment();
}

}
}
