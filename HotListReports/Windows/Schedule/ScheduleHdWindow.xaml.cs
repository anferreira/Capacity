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
using HotListReports.Windows.Labour;
using HotListReports.Windows.Schedule;
using NujitWPFUtilities.Gantt;
using System.Collections;
using System.Windows.Data;
using System.Data;
using Nujit.NujitERP.ClassLib.Core.Machines;

namespace HotListReports.Windows.Demand{

/// <summary>
/// Interaction logic for ScheduleHdWindow.xaml
/// </summary>
public partial 
class ScheduleHdWindow : Window{

private ScheduleHdModel model;
private LabourViewsModel labourViewsModel;
private ScheduleHdr scheduleHdr;
private ScheduleHdr scheduleHdrFilter;
private int imachIdFilter;
private SchedulePart schedulePartFilter;
private int itabIndex;
private int ihotListTabIndex;
private bool badding;
private bool baddingDtl;    
private bool baddingReq;   
private bool baddingSubDtl;    

private HotListViewContainer hotListViewContainer;
private bool bprocessHotList=false;

private bool bcontrol = false;

public 
ScheduleHdWindow(ScheduleHdr scheduleHdrFilter,int imachIdFilter, SchedulePart schedulePartFilter){
    InitializeComponent();

    init();    
    this.scheduleHdrFilter  = scheduleHdrFilter;
    this.imachIdFilter      = imachIdFilter;
    this.schedulePartFilter = schedulePartFilter;    
}

public 
ScheduleHdWindow(){
    InitializeComponent();
    init();
}

private
void init(){    
    model = new ScheduleHdModel(this);
    labourViewsModel = new LabourViewsModel(this, labourTypeView);
    this.hotListViewContainer = model.getCoreFactory().createHotListViewContainer();
    this.scheduleHdrFilter = null;
    this.scheduleHdr=null;
    this.itabIndex = 0;    
    this.ihotListTabIndex = 0;
    this.badding = this.baddingDtl = this.baddingReq = baddingSubDtl= false;         
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){
    initialize();
}

private 
void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e){    
}

private
DateTime getMondayThisWeek(){
    DateTime    dateTime = DateTime.Now;
    DateTime    priorMonday = DateTime.Now;
    DateTime    nextSunday = DateTime.Now;
        
    DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now, out priorMonday, out nextSunday);
    return priorMonday;
}

private 
void initialize(){        
    try {                
        setTimeInterVals(new TimeSpan(0, 30, 0)); //time intervals each 30 mins

        hotListTabControl.SelectionChanged-= hotListTabControl_SelectionChanged;
        hotListTabControl.SelectedIndex=0;

        filterGroup.DataContext = model;        
        setListViewScrollsButtons();//list view scrolls
               
        this.recordsTextBox.Text = Configuration.SearchDefaultMaxRecords;
        model.Cursor = this.Cursor;
        model.loadSearchByCombo(searchByComboBox);
        model.loadSearchByHotListCombo(searchByHotListComboBox);
        model.loadPlantCombo(plantFilterComboBox,true);model.setSelectedComboBoxItem(plantFilterComboBox, scheduleHdrFilter!=null ? scheduleHdrFilter.Plant:Configuration.DftPlant);

        //grid columns
        model.loadColumnsOnHeaderGrid(hdrListView);
        model.loadColumnsOnRequirementGrid(reqListView);
        model.loadColumnsOnPartGrid(partReqDtlListView);
        model.loadColumnsOnMaterialGrid(materialsListView);                
        model.loadColumnsOnPackGrid(packagingListView);                                 
        model.loadColumnsOnTaskGrid(taskListView);
                                                                        
        model.loadColumnsOnPartDetailsGrid(partDtlListView);
        model.loadColumnsOnReceiptPartGrid(partReceiptsListView);                        
        model.loadColumnsOnReceiptPartGrid(partReceiptsDtlListView);   
        model.loadColumnsOnMaterialConsumitionGrid(matConsumListView);
        model.loadColumnsOnMaterialConsumitionGrid(matConsumDtlListView);

        model.loadColumnsOnHotListDateOnTopGrid(hotListDatesView,0,Configuration.DftPlant,7);

        //hotlist
        model.loadPlantCombo(plantHComboBox,true);
        model.loadDeptCombo(deptHComboBox,"","");

        //load status
        model.loadStatus(stsComboBox,true);        
        model.loadStatus(statusComboBox,false);
                
        model.loadReqTypes(reqTypeComboBox);
        model.loadShiftTaskComboBox(shiftTaskComboBox);
        //load shifts        
        model.loadShiftNumComboBox(this.shiftFilterComboBox, Constants.MAX_SHIFTS,false);
        model.loadShiftNumComboBox(this.partShiftComboBox,Constants.MAX_SHIFTS,false);
        model.loadShiftNumComboBox(this.tasksShiftComboBox,Constants.MAX_SHIFTS,false);                

        //priority
        model.loadPriority(priorityPartComboBox,false);
        model.loadPriority(priorityTaskComboBox, false);
                
        //filters
        model.loadReqFilter(this.reqFilterComboBox);
        removeAllTabs();        
        model.screenFullArea();
        
        model.loadPlantCombo(plantComboBox,false);//plant
        model.loadYesNoComboBox(reportedPointComboBox, true);//reported point
        model.loadFamilyPartComboBox(familyPartComboBox,true);
        model.loadPartGLExps(glExpsComboBox);

        //down
        model.loadDownType(downComboBox);
        model.loadDownTypeNames(downTypeComboBox);
        model.loadShiftNumComboBox(this.downShiftComboBox,Constants.MAX_SHIFTS,false);   
                
        //hotListTabControl.Items.Remove(labourTypeTab);
        daysWithQoTextBox.DataContext= model.DaysWithQohs;
        
        search();    

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }finally{
        hotListTabControl.SelectionChanged+= hotListTabControl_SelectionChanged;
    }
}

private
void setListViewScrollsButtons(){
    model.addButtonsListViewFunctions(this.hdrListView,firstButton,prevButton,nextButton,lastButton);
    model.addButtonsListViewFunctions(this.reqListView,firstRButton,prevRButton,nextRButton,lastRButton);
    model.addButtonsListViewFunctions(this.partReqDtlListView, firstPButton,prevPButton,nextPButton,lastPButton);
    model.addButtonsListViewFunctions(this.taskListView,firstTButton,prevTButton,nextTButton,lastTButton);
    model.addButtonsListViewFunctions(this.partDtlListView, firstPDButton, prevPDButton, nextPDButton, lastPDButton);
    model.addButtonsListViewFunctions(this.materialsListView, firstMatButton, prevMatButton, nextMatButton, lastMatButton);
    model.addButtonsListViewFunctions(this.packagingListView, firstPacButton, prevPacButton, nextPacButton, lastPacButton);
    model.addButtonsListViewFunctions(this.partReceiptsListView, firstPRecButton, prevPRecButton, nextPRecButton, lastPRecButton);
    model.addButtonsListViewFunctions(this.partReceiptsDtlListView, firstPRecDtlButton, prevPRecDtlButton, nextPRecDtlButton, lastPRecDtlButton);

    model.addButtonsListViewFunctions(this.hotListDatesView,                firstHButton, prevHButton, nextHButton, lastHButton);
    model.addButtonsListViewFunctions(this.hotListDatesConsumView,          firstH1Button,prevH1Button,nextH1Button,lastH1Button);
    model.addButtonsListViewFunctions(this.inventoryView,                   firstH2Button,prevH2Button,nextH2Button,lastH2Button);
    model.addButtonsListViewFunctions(this.labourTypeView,                  firstH3Button,prevH3Button,nextH3Button,lastH3Button);
    model.addButtonsListViewFunctions(this.futureInventoryView,             firstH4Button,prevH4Button,nextH4Button,lastH4Button);
    model.addButtonsListViewFunctions(this.inventoryObjetivesInventoryView, firstH5Button,prevH5Button,nextH5Button,lastH5Button);
                
    model.addButtonsListViewFunctions(this.matConsumListView, firstMCButton, prevMCButton, nextMCButton, lastMCButton);
    model.addButtonsListViewFunctions(this.matConsumDtlListView, firstMCDButton, prevMCDButton, nextMCDButton, lastMCDButton);            
}       

private
void setTimeInterVals(TimeSpan timeSpan){
    this.startDateTimePRadDateTimePicker.TimeInterval = this.endDateTimePRadDateTimePicker.TimeInterval =
    this.startDateTimeTRadDateTimePicker.TimeInterval = this.endDateTimeTRadDateTimePicker.TimeInterval = timeSpan;
}

private 
void searchButton_Click(object sender, RoutedEventArgs e){
    search();
}

private 
void searchHotListButton_Click(object sender, RoutedEventArgs e){
    searchHotList(0);
}
        
private 
void applyFilterButton_Click(object sender, RoutedEventArgs e){
    applyFilters();
}

private 
void search(){    
    try{  
        int         irows   = model.getRecords(recordsTextBox);
        string      sid     = searchByComboBox.SelectedIndex == 0 ? searchForTextBox.Text : "";
        string      status  = model.getSelectedComboBoxItemString(stsComboBox);
        string      splant  = model.getSelectedComboBoxItemString(plantFilterComboBox); 
        DateTime    fromDate= model.getSelectedDateTime(fromDatePicker);
        DateTime    toDate  = model.getSelectedDateTime(toDatePicker);
        
        if (!string.IsNullOrEmpty(sid))        
            sid = sid + "%";        
                            
        ScheduleHdrContainer scheduleHdrContainer = model.getCoreFactory().createScheduleHdrContainer();
        if (scheduleHdrFilter!= null)
            scheduleHdrContainer.Add(scheduleHdrFilter);
        else
            scheduleHdrContainer = model.getCoreFactory().readScheduleHdrByFilters(sid, splant, status,0,0,fromDate, toDate,true, irows);

        model.setDataContextListView(hdrListView, scheduleHdrContainer);                
        this.searchForTextBox.Focus();

        if (scheduleHdrFilter !=null)             
            mainTabControl.SelectedItem = dtlTabItem;                     
            
    }catch (Exception ex){
        MessageBox.Show("search Exception: " + ex.Message);
    }finally      {
        scheduleHdrFilter=null;
    }              
}  

private 
void searchHotList(int imachineId){    
    if (bprocessHotList)
        return;
    else
        bprocessHotList=true;
    
    try{
        //MessageBox.Show("searchHotList");        

        model.cursorWait();        
        bcontrol=false;
        model.startCellSelect();

        model.ProcessStart();
        string      splantHotList = scheduleHdr!= null ? scheduleHdr.Plant : Configuration.DftPlant;
        string      smachine    = searchByHotListComboBox.SelectedIndex == 0 ? searchForHotListTextBox.Text : "";        
        string      spart       = searchForHotListPartTextBox.Text;        
        string      splant      = model.getSelectedComboBoxItemString(plantHComboBox);
        string      sdept       = model.getSelectedComboBoxItemString(deptHComboBox);
        string      sglExp      = model.getSelectedComboBoxItemString(glExpsComboBox);
        string      srepPoint   = model.getSelectedComboBoxItemString(reportedPointComboBox);
        string      sprodFamily = model.getSelectedComboBoxItemString(familyPartComboBox);
        bool        baddMaterialConsumPart = false;
        bool        bhotList        = true;
        ListView    listView        = hotListDatesView;
        DateTime    startDate       = getMondayThisWeek();
        bool        bqtyCumulative  = (bool)qtyCumulativeHotListCheckBox.IsChecked;
        bool        bqohAffects     = (bool)qohAffectsCheckBox.IsChecked;
        string[][]  items = null;
        
        if (!string.IsNullOrEmpty(smachine))        
            smachine = smachine + "%";        
        if (!string.IsNullOrEmpty(spart))        
            spart = spart + "%";                               

        if (hotListTabControl.SelectedItem!= null) {
            //if (hotListTabControl.SelectedItem.Equals(hotListReceiptsPartsTab))
               // model.loadColumnsOnHotListDateOnTopGrid(hotListDatesView,0,splantHotList);

            if (hotListTabControl.SelectedItem.Equals(hotListConsumPartsTab)){
                listView = hotListDatesConsumView;
                //model.loadColumnsOnHotListDateOnTopGrid(hotListDatesConsumView,0,splantHotList);
                baddMaterialConsumPart = true;
            }

            if (hotListTabControl.SelectedItem.Equals(inventoryTab)){
                listView = inventoryView;     
                model.loadColumnsOnInventoryGrid(inventoryView, getMondayThisWeek());   
                model.searchInventory(inventoryView,splantHotList,spart, -1,"", smachine, imachineId,sglExp,srepPoint, sprodFamily,startDate, startDate.AddDays(90), bqtyCumulative,true, 0);
                bhotList = false;                                   
            }

            if (hotListTabControl.SelectedItem.Equals(labourTypeTab)){
                listView = labourTypeView;     
                bhotList = false;              
                model.loadColumnsOnLabourTypeGrid2(labourTypeView,splantHotList);                                
                LabourTypeRequiredContainer labourTypeRequiredContainer = labourViewsModel.searchHotListLabourType(splantHotList,sdept,smachine,imachineId,spart);
                model.setDataContextListView(labourTypeView,labourTypeRequiredContainer);
            }

            if (hotListTabControl.SelectedItem.Equals(futureInventoryTab)){
                listView = futureInventoryView;     
                bhotList = false;      
                model.loadColumnsOnFutureInventoryGrid(futureInventoryView,DateTime.Now, DateTime.Now.AddDays(90));
                DateTime    priorMonday = DateTime.Now,priorMondayAux = DateTime.Now,nextSunday  = DateTime.Now;                
                DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now,out priorMonday, out nextSunday);
                DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now.AddDays(90),out priorMondayAux, out nextSunday);
                
                items = model.getCoreFactory().getFutureInventoryByWeek(scheduleHdr!=null ? scheduleHdr.Id:0,splantHotList,spart, -1,smachine, imachineId,sglExp,priorMonday, nextSunday,0);
                model.setDataContextListView(listView,items);                
            }
        } 
                             
        model.DaysWithQohs.Days  = model.DaysWithQohs.Days > Constants.MAX_HOTLIST_DAYS ? Constants.MAX_HOTLIST_DAYS : model.DaysWithQohs.Days;                                      

        if (bhotList) { 
            model.searchHotList(listView, splantHotList, splant,sdept,smachine, imachineId, spart,sglExp,srepPoint, sprodFamily, model.DaysWithQohs.Days,bqtyCumulative, bqohAffects,true, baddMaterialConsumPart, 0);
           /* if (imachineId > 0 && listView.Items.Count < 1) { 
                bprocessHotList=false;
                searchHotList(0);
            }*/
        }
                
        timeLabel.Content = model.ProcessEndAndTex(listView.Items.Count);
        this.searchForHotListTextBox.Focus();
                      
    }catch (Exception ex){
        MessageBox.Show("searchHotList Exception: " + ex.Message);
    }finally{
        model.cursorNormal();            
        bprocessHotList=false;
    }                         
                         
}

private 
void qtyCumulativeHotListCheckBox_Click(object sender, RoutedEventArgs e){
    searchHotList(0);
}

private 
void qohAffectsCheckBox_Click(object sender, RoutedEventArgs e){
    searchHotList(0);
}

private 
void applyFilters(){    
    model.applyFilters(reqListView, reqFilterComboBox);    
}  

private
void removeAllTabs(){
    removeSchedulePartTabItem();
    removeScheduleTaskTabItem();
    removeRequirmentTabItem();
    removeReceiptPartTabItem();
    removeScheduleDownTabItem();
    //model.removeTabItem(mainTabControl,this.ganttTab); //remove
}

private
void moveToDetailTabItem(){
    mainTabControl.SelectedItem = this.dtlTabItem;
}

private
void removeSchedulePartTabItem(){
    model.removeTabItem(mainTabControl, schedulePartTabItem);
}

private
void removeScheduleTaskTabItem(){
    model.removeTabItem(mainTabControl, scheduleTaskTabItem);    
}

private
void removeScheduleDownTabItem(){
    model.removeTabItem(mainTabControl, scheduleDownTabItem);    
}


private
void removeRequirmentTabItem(){
    model.removeTabItem(mainTabControl, requirmentTabItem);    
}

private
void removeReceiptPartTabItem(){
    model.removeTabItem(mainTabControl,receiptPartTabItem);
}

private
void addRequirmentTabItem(ScheduleReqView scheduleReqView){
    if (mainTabControl.Items.IndexOf(requirmentTabItem) < 0)
        mainTabControl.Items.Add(requirmentTabItem);        
    mainTabControl.SelectedItem = requirmentTabItem;
    requirmentTabItem.DataContext = scheduleReqView;
}

private
void addPartTabItem(SchedulePart schedulePart){
    if (mainTabControl.Items.IndexOf(schedulePartTabItem) < 0)
        mainTabControl.Items.Add(schedulePartTabItem);        
    mainTabControl.SelectedItem =schedulePartTabItem;
    schedulePartTabItem.DataContext =null; //clear info
    schedulePartTabItem.DataContext =schedulePart;
}

private 
bool saveLoad(bool badded,SchedulePart schedulePart,ScheduleTask scheduleTask,ScheduleDown scheduleDown){
    bool bresult=false;
    try{
        this.scheduleHdr.fillRedundances();
        model.save();
        loadScheduleH(scheduleHdr);
        if (badded)
            model.setSelected(reqListView, model.createScheduleReqView(schedulePart, scheduleTask, scheduleDown));

    }catch (Exception ex){
        MessageBox.Show("saveLoad Exception: " + ex.Message);
    }  
    return bresult;
}

private 
void loadScheduleH(ScheduleHdr scheduleHdr){
    try{
        reqListView.SelectionChanged-= reqListView_SelectionChanged;

        plantComboBox.IsEnabled = scheduleHdr.Id > 0 ? false:true; //disable 

        model.ScheduleHdr = scheduleHdr;        
        dtlTopCanvas.DataContext = scheduleHdr;
                                
        //requirment Parts/Tasks
        model.loadRequirmentGrid(reqListView);        
        model.loadReqFilter(reqFilterComboBox);

        //load PartDtls and Tasks        
        ScheduleReqView             scheduleReqView = (ScheduleReqView)model.getSelected(reqListView);        
        ScheduleTaskContainer       scheduleTaskContainer = model.getCoreFactory().createScheduleTaskContainer();
        
        if (imachIdFilter > 0)            
            scheduleTaskContainer = scheduleHdr.ScheduleTaskContainer.getByMachId(imachIdFilter);            
        
        model.loadPartGrid(partReqDtlListView, scheduleReqView);
        model.loadTaskGrid(taskListView, scheduleTaskContainer);
        loadSelRequirment();                        
        model.setSelectedComboBoxItem(plantHComboBox,scheduleHdr.Plant);

        if (imachIdFilter > 0){
            SchedulePart schedulePartAux  = scheduleHdr.SchedulePartContainer.getFirstByMach(imachIdFilter);
            if (model.setSelected(reqListView, model.createScheduleReqView(schedulePartAux, null,null)))
                loadSelRequirment();            
            imachIdFilter = 0;
        }
            
        if (this.schedulePartFilter != null){ //if part filter , need to show it as mode to be added
            modifyPart(schedulePartFilter);
            baddingDtl = true;
            schedulePartFilter = null;
        }
                          
    }catch (Exception ex){
        MessageBox.Show("loadScheduleH Exception: " + ex.Message);
    }finally{
        reqListView.SelectionChanged+= reqListView_SelectionChanged;
        imachIdFilter = 0;   
        schedulePartFilter = null;
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
                
        if (indexSel != itabIndex){
            this.itabIndex = indexSel;                         
                                                     
            if (indexSel == 0){
                this.badding = this.baddingDtl = this.baddingReq = baddingSubDtl = false;  
                this.scheduleHdr = null;
                removeAllTabs();
                search();
            }else if (indexSel == 1){

               if (mainTabControl.Items.Count > 3){
                    this.itabIndex = mainTabControl.Items.Count - 1;
                    mainTabControl.SelectedIndex = (mainTabControl.Items.Count-1);                    
                    return;
                }  
                
                this.baddingDtl = this.baddingReq = baddingSubDtl = false;                             
                removeAllTabs();
                if (ipriorIndex == 0){
                    model.initializeFilters(reqFilterComboBox);

                    if (!badding){
                        scheduleHdr = (ScheduleHdr)model.getSelected(hdrListView);
                        if (scheduleHdr!=null)
                            scheduleHdr = model.readHdr(scheduleHdr.Id);                        
                    }
                    
                    if (scheduleHdr != null)
                        loadScheduleH(scheduleHdr);
                    else
                        mainTabControl.SelectedItem = this.hdrTabItem;
                }                     
                
                if (ipriorIndex == 2 && scheduleHdr == null){                          
                    mainTabControl.SelectedItem = this.hdrTabItem;
                }                     
                
            }else if (indexSel == 2){//hotlist                        
                model.setSelectedComboBoxItem(plantHComboBox, scheduleHdr!= null ? scheduleHdr.Plant:Configuration.DftPlant);

                bool bsearchHotList=true;                                
                if ( (ipriorIndex > 2 || ipriorIndex < 0) && mainTabControl.Items.Count <= 3)
                    bsearchHotList=false;                
                if (bsearchHotList) { 

                    if (mainTabControl.Items.Count > 3){
                        if (mainTabControl.Items[mainTabControl.Items.Count-1].Equals(schedulePartTabItem) && getCurrentPart()!= null)
                            searchHotList(getCurrentPart().MachId);
                        if (mainTabControl.Items[mainTabControl.Items.Count-1].Equals(scheduleTaskTabItem) && getCurrentTask()!= null)
                            searchHotList(getCurrentTask().MachId);
                    }else                                                                                            
                        searchHotList(getMachineIdFromSelRequirment());
                }

            }else if (indexSel == 3){//schedule part
                       
                /*
                if (ipriorIndex== 2 && mainTabControl.SelectedItem!= null && mainTabControl.SelectedItem.Equals(schedulePartTabItem)){
                    string[]     items = (string[])model.getSelected(hotListDatesView);
                    SchedulePart schedulePart = getCurrentPart();
                    ScheduleReq  scheduleReq = getCurrentOriginalReq();

                    if (items!= null && items.Length > 0 && scheduleReq!= null && schedulePart != null && string.IsNullOrEmpty(schedulePart.Part)){
                        Machine machine = model.getCoreFactory().readMachine(items[106], items[0], items[7]);
                        if (machine!= null && machine.Id == scheduleReq.ReqID)  {                                  

                            schedulePart.Part = items[0];
                            schedulePart.Seq  = Convert.ToInt32(items[0]);
                            if (model.loadBuildMachineValues(getCurrentOriginalReq(), schedulePart)){

                            } 
                        }  
                    }                
                }*/
                if (mainTabControl.Items.Count > 3){
                    this.itabIndex = mainTabControl.Items.Count - 1;
                    mainTabControl.SelectedIndex = (mainTabControl.Items.Count-1);                    
                    return;
                } 

            } 
        }
                 
    } catch (Exception ex) {
        MessageBox.Show(ex.Message);
    }
}

private
int getMachineIdFromSelRequirment(){
    int imachineId =0;                
    ScheduleMachine scheduleMachine = getCurrentScheduleMachine();
    if (scheduleMachine != null)
        imachineId= scheduleMachine.MachId;

    return imachineId;
}

private 
void hdrListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    badding = false;
    mainTabControl.SelectedItem = this.dtlTabItem;
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
   model.save();
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
void add(){    
    try{
        this.badding=true;
        scheduleHdr = this.model.createHdr();         
      

        mainTabControl.SelectedItem = dtlTabItem;
                                           
    }catch (Exception ex){
        MessageBox.Show("add Exception: " + ex.Message);
    }                       
}

private 
void del(){    
    try{
        if (model.del(hdrListView))
            search();                                                       
    }catch (Exception ex){
        MessageBox.Show("del Exception: " + ex.Message);
    }                       
}

private 
void addPButton_Click(object sender, RoutedEventArgs e){
    addPart();  
} 

/************************************************ Requirment *****************************************************************/
private
void modifyRequirmentView(){
    try{
        ScheduleReqView scheduleReqView = (ScheduleReqView)model.getSelected(reqListView);        
        if (scheduleReqView!= null){
            model.ScheduleReqViewActive = scheduleReqView;

            SchedulePart schedulePart = model.getSchedulePart(scheduleReqView);
            ScheduleTask scheduleTask = model.getScheduleTask(scheduleReqView);
            ScheduleDown scheduleDown = model.getScheduleDown(scheduleReqView);

            if (schedulePart!=null)
                modifyPart(schedulePart);
            else if (scheduleTask != null && model.setSelected(taskListView,scheduleTask))
                modifyTask();
            else if (scheduleDown != null)
                modifyDown(scheduleDown);            
        } 
    }catch (Exception ex){
        MessageBox.Show("modifyRequirmentView Exception: " + ex.Message);
    }    

}

private
void delRequirmentView(){
    try{
        ScheduleReqView scheduleReqView = model.getScheduleReqView(reqListView);        
        if (scheduleReqView!= null){
            model.ScheduleReqViewActive = scheduleReqView;

            SchedulePart schedulePart = model.getSchedulePart(scheduleReqView);
            ScheduleTask scheduleTask = model.getScheduleTask(scheduleReqView);
            ScheduleDown scheduleDown = model.getScheduleDown(scheduleReqView);
      
            if (schedulePart!=null)
                model.deleteSchedulePart(reqListView,schedulePart);
            else if (scheduleTask != null && model.setSelected(taskListView,scheduleTask))
                delTask();    
            else if (scheduleDown != null)
                model.deleteScheduleDown(reqListView,scheduleDown);           
        } 
    }catch (Exception ex){
        MessageBox.Show("modifyRequirmentView Exception: " + ex.Message);
    }    

}

private 
void reqListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    modifyRequirmentView();    
}

private 
void reqListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
   loadSelRequirment();
}

private 
void loadSelRequirment() {
    this.model.loadSelRequirment(reqListView, partReqDtlListView, taskListView,materialsListView,packagingListView, partReceiptsDtlListView, matConsumDtlListView);    
}

private 
void addRButton_Click(object sender, RoutedEventArgs e){
    //addRequirment();    
} 

private 
void delRButton_Click(object sender, RoutedEventArgs e){
    //delRequirment();
}

private
ScheduleReqView getSelectedReq(){ 
    return (ScheduleReqView)requirmentTabItem.DataContext;
}

private 
void reqTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
    
}

private
void reqHoursTextBox_LostFocus(object sender, RoutedEventArgs e){
   
}
      
private
void reqTotEmployeesTextBox_LostFocus(object sender, RoutedEventArgs e){

}
          
private 
void reqIdButton_Click(object sender, RoutedEventArgs e){
   
}
private 
void okRequirmentButton_Click(object sender, RoutedEventArgs e){
    okRequirment();
}

private 
void okRequirment(){      
    //saveRequirment(); 
}

private 
void cancelRequirmentButton_Click(object sender, RoutedEventArgs e){
    cancelRequirment();
}

private 
void cancelRequirment(){   
    if (model.cancel()){
        baddingReq=false;
        removeRequirmentTabItem();
        moveToDetailTabItem();    
    }
}
    
/*************************************************** Part ****************************************************************/
private
void modifyPart(SchedulePart schedulePart){
    try{
        this.baddingDtl = false;           
        loadPart(model.cloneToModifyPart(schedulePart),false);        
    }catch (Exception ex){
        MessageBox.Show("modifyPart Exception: " + ex.Message);
    }    

} 

private 
void delPButton_Click(object sender, RoutedEventArgs e){
    delRequirmentView();
}

private
SchedulePart getCurrentPart(){ 
    return (SchedulePart)schedulePartTabItem.DataContext;
}

private
ScheduleReceiptPart getCurrentReceiptPart(){ 
    return (ScheduleReceiptPart)receiptPartTabItem.DataContext;
}

private 
void addPart(){    
    try{        
        ScheduleReqView scheduleReqView = model.validRequirment(reqListView);
      
        model.ScheduleReqViewActive = scheduleReqView;
        this.baddingDtl = true;        
        loadPart(model.createPart(scheduleReqView!= null ? scheduleReqView.MachId:0),false);            
                    
    }catch (Exception ex){
        MessageBox.Show("addPart Exception: " + ex.Message);
    }                       
}

private
void loadPart(SchedulePart schedulePart,bool bforceLoadSeq){    
    try{       
        seqComboBox.SelectionChanged-= seqComboBox_SelectionChanged;

        addPartTabItem(schedulePart);
                /*
        partTextBox.Text        = schedulePart!= null ? schedulePart.Part :"";
        quantityTextBox.Text    = schedulePart!= null ? schedulePart.QtyInt64.ToString()   :"0";
        qtyReportedTextBox.Text = schedulePart!= null ? schedulePart.QtyReportedInt64.ToString():"0";
        qtyRemainsTextBox.Text  = schedulePart!= null ? Convert.ToInt64(schedulePart.RemainsQty).ToString():"0";
        cavityNumTextBox.Text   = schedulePart!= null ? Convert.ToInt64(schedulePart.CavityNum).ToString():"0";

        queuePartTextBox.Text   = schedulePart!= null ? Convert.ToInt64(schedulePart.Queue).ToString():"0";
        uomTextBox.Text         = schedulePart!= null ? schedulePart.Uom.ToString():"0";
        runStdTextBox.Text      = schedulePart!= null ? Convert.ToInt64(schedulePart.RunStd).ToString() : "0";
        */
        partShiftComboBox.DataContext = schedulePart;
        seqComboBox.DataContext = schedulePart;
        if (schedulePart!=null){
             if (!baddingDtl || bforceLoadSeq)
                model.loadPartSequences(seqComboBox, schedulePart);                               
            model.loadGrid(partDtlListView, schedulePart.SchedulePartDtlContainer);              
            model.loadGrid(partReceiptsListView, schedulePart.ScheduleReceiptPartContainer);
            model.loadMaterialConsumitionGrid(matConsumListView,schedulePart);

            if (baddingDtl){
                Machine machine = model.getCoreFactory().readMachineById(schedulePart.MachId);
                if (machine!= null) { 
                    Departament departament = model.getCoreFactory().readDepartament(machine.Plt, machine.Dept);
                    if (departament!= null)
                        schedulePart.SchNonChargeDT = departament.NonScheduledDT;
                }
            }

        }        
    }catch (Exception ex){
        MessageBox.Show("loadPart Exception: " + ex.Message);
    }finally{
        seqComboBox.SelectionChanged+= seqComboBox_SelectionChanged;
    }
}

private 
void partSearchButton_Click(object sender, RoutedEventArgs e){
    partSearch();
}  

private 
void partSearch(){    
    try{
        SchedulePart schedulePart = getCurrentPart();
        if (model.partSearch(partTextBox,schedulePart.MachId,schedulePart)){
            model.loadPartSequences(seqComboBox,schedulePart);            
            model.generateAutomaticReceiptPart(schedulePart, (bool)createAutomaticReceiptsCheckBox.IsChecked,matConsumListView);
        }
                                                   
    }catch (Exception ex){
        MessageBox.Show("partSearch Exception: " + ex.Message);
    }                       
}

private 
void machineSearchButton_Click(object sender, RoutedEventArgs e){
    machineSearch();
}  

private 
void machineSearchTButton_Click(object sender, RoutedEventArgs e){
    machineTaskSearch();
}  

private 
void machineSearch(){    
    try{
        SchedulePart schedulePart = getCurrentPart();
        if (schedulePart!= null && model.machineSearch(schedulePart))
            model.loadPartSequences(seqComboBox,schedulePart);            
                                                   
    }catch (Exception ex){
        MessageBox.Show("machineSearch Exception: " + ex.Message);
    }                       
}

private 
void machineTaskSearch(){    
    try{
        ScheduleTask scheduleTask = getCurrentTask();
        if (scheduleTask!= null)
            model.machineSearch(scheduleTask);                                                               
    }catch (Exception ex){
        MessageBox.Show("machineTaskSearch Exception: " + ex.Message);
    }                       
}
        
private 
void seqComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
   seqComboBoxSelectionChanged();
}

private 
void seqComboBoxSelectionChanged() {
   try{
        SchedulePart    schedulePart= getCurrentPart();
        
        if (model.ScheduleReqViewActive != null && schedulePart != null) { 
            model.loadBuildMachineValues(model.ScheduleReqViewActive.MachId, schedulePart);            
            model.calculatePartEndDate(getCurrentPart(),quantityTextBox,createAutomaticReceiptsCheckBox, matConsumListView);
        }
                                                   
    }catch (Exception ex){
        MessageBox.Show("partSearch Exception: " + ex.Message);
    } 
}
        
private 
bool dataOkPart(){    
    bool                        bresult=true;
    SchedulePart                schedulePart = getCurrentPart();        
    ScheduleReqView             scheduleReqView = model.getCoreFactory().createScheduleReqView();
    ScheduleReqView             scheduleReqViewFound = null;

    if (!model.validMachine(schedulePart,machineTextBox))
        bresult= false;

    if (!model.validProduct(schedulePart,partTextBox))
        bresult= false;

    if (schedulePart.EndDate < schedulePart.StartDate){
        MessageBox.Show("End Date Might Be Bigger Than Start Date.");
        this.endDateTimePRadDateTimePicker.Focus();
        bresult= false;                        
    }

    if (bresult)
        bresult = model.getValidNumericFromAlpha(this.quantityTextBox, "Quantity");
    if (bresult)
        bresult = model.getValidNumericFromAlpha(this.qtyReportedTextBox, "Quantity Reported");
                   
    if (bresult && schedulePart.QtyReported > schedulePart.Qty){
        MessageBox.Show("Quantity Reported Might Not Be Bigger Than Quantity Scheduled.");
        schedulePart.QtyReported = schedulePart.Qty;
        this.qtyReportedTextBox.Focus();
        bresult= false;                        
    }

    scheduleReqViewFound = model.getAlreadySameDates( baddingDtl,schedulePart);                                    

    if (bresult && scheduleReqViewFound != null){                
        string smess = "Sorry, Already Exist "  + scheduleReqViewFound.getScheduleTypeDescription() + " On Similar Range Dates\n" +
                        (scheduleReqViewFound.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_PART) ? "Part:" + scheduleReqViewFound.Part : "") +
                        (scheduleReqViewFound.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_TASK) ? "Task:" + scheduleReqViewFound.Description : "") + "\n" +
                        "Start:" + DateUtil.getCompleteDateRepresentationWithoutSS(scheduleReqViewFound.StartDate,DateUtil.MMDDYYYY) + "\n" +
                        "End  :" + DateUtil.getCompleteDateRepresentationWithoutSS(scheduleReqViewFound.EndDate, DateUtil.MMDDYYYY);        
        if (System.Windows.Forms.MessageBox.Show(smess + " , Continue Anyway ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
            bresult= false;
        //ScheduleReqView scheduleReqViewFly = model.createScheduleReqView(getCurrentOriginalReq(), schedulePart, null);        
        //model.getCoreFactory().moveDatesFromSchedulePartTask(scheduleHdr, model.ScheduleReqViewContainer, scheduleReqViewFly);
    }
    return bresult;
}

private
void savePart(){
    try{        
        SchedulePart    schedulePart= getCurrentPart();        

        if (scheduleHdr != null && schedulePart != null && dataOkPart()){
            model.fillIfHasMaterials(schedulePart);

            if (baddingDtl)
                scheduleHdr.SchedulePartContainer.Add(schedulePart);                                               
            else
                schedulePart = model.copyPart(schedulePart);
            
            model.generateAutomaticReceiptPart(schedulePart, (bool)createAutomaticReceiptsCheckBox.IsChecked,matConsumListView);
            model.loadMaterialConsumitionGrid(matConsumDtlListView, schedulePart);
            saveLoad(baddingDtl,schedulePart, null,null);            
            removeSchedulePartTabItem();  
            moveToDetailTabItem();            
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
    cancelPart();
} 

private
void cancelPart(){
    if (model.cancel()){
        //model.cancelPart(getCurrentPart());
        //model.loadMaterialConsumitionGrid(matConsumDtlListView, getCurrentPart());
        cancelDtl(schedulePartTabItem);              
    }   
}                                          

private 
void cancelDtl(TabItem tabItem){    
    try{
        this.baddingDtl = false;
        model.removeTabItem(mainTabControl,tabItem);        
        moveToDetailTabItem();        
    }catch (Exception ex){
        MessageBox.Show("cancelDtl Exception: " + ex.Message);
    }                       
}

private
void quantityTextBox_LostFocus(object sender, RoutedEventArgs e){
    model.calculatePartEndDate(getCurrentPart(),quantityTextBox,createAutomaticReceiptsCheckBox, matConsumListView);
}
      
private 
void startDateTimePRadDateTimePicker_LostFocus(object sender, RoutedEventArgs e){
    model.calculatePartEndDateQty(getCurrentPart(),createAutomaticReceiptsCheckBox, matConsumListView);    
}

private 
void endDateTimePRadDateTimePicker_LostFocus(object sender, RoutedEventArgs e){
    model.calculatePartQty(getCurrentPart(),createAutomaticReceiptsCheckBox, matConsumListView);
}

private
void qtyReportedTextBox_LostFocus(object sender, RoutedEventArgs e){
    model.calculateRemainsQty(getCurrentPart(), qtyReportedTextBox,createAutomaticReceiptsCheckBox, matConsumListView);
}
        

/**************************************** Task ***************************************************************************/
private 
void addDownButton_Click(object sender, RoutedEventArgs e){
    //model.addTabItem(mainTabControl,ganttTab,this.reqListView.DataContext);
    //setGanttData();
    addDown();      
} 

private
ScheduleTask getCurrentTask(){ 
    return (ScheduleTask)scheduleTaskTabItem.DataContext;
}

private
ScheduleMachine getCurrentScheduleMachine(){ 
    return  (ScheduleMachine)model.getSelected(reqListView);
}
       
private 
void taskListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    modifyTask();
}

private
void modifyTask(){
    try{
        this.baddingDtl = false;                                    
        loadTask(model.cloneToModifyTask(taskListView));        
    }catch (Exception ex){
        MessageBox.Show("modifyTask Exception: " + ex.Message);
    }    

} 

private 
void addTaskButton_Click(object sender, RoutedEventArgs e){
    addTask(false);      
}

private 
void addTButton_Click(object sender, RoutedEventArgs e){
    addTask(false);      
} 

private 
void delTButton_Click(object sender, RoutedEventArgs e){
    delTask();
} 

private 
void okSheduleTaskButton_Click(object sender, RoutedEventArgs e){
    saveTask();          
} 

private 
void cancelScheduleTaskButton_Click(object sender, RoutedEventArgs e){
    cancelTask();
}

private 
void cancelTask(){
    if (model.cancel()){
        //model.cancelTask(getCurrentTask());
        cancelDtl(scheduleTaskTabItem);  
    }
}
        
private 
void addTask(bool baddDownTime){    
    try{       
        ScheduleReqView scheduleReqView = model.validRequirment(reqListView);        
        model.ScheduleReqViewActive = scheduleReqView;       
                                 
        this.baddingDtl = true;                                                                                
        if (baddDownTime)
            loadTask(model.createDownTimeTask(scheduleReqView));
        else                    
            loadTask(model.createTask(scheduleReqView!= null ? scheduleReqView.MachId:0));                                               
                                         
    }catch (Exception ex){
        MessageBox.Show("addTask Exception: " + ex.Message);
    }                       
}

private
void addShiftTaskTabItem(ScheduleTask scheduleTask){
    if (mainTabControl.Items.IndexOf(scheduleTaskTabItem) < 0)
        mainTabControl.Items.Add(scheduleTaskTabItem);        
    mainTabControl.SelectedItem = scheduleTaskTabItem;
    scheduleTaskTabItem.DataContext = null;
    scheduleTaskTabItem.DataContext = scheduleTask;
}

private
void loadTask(ScheduleTask scheduleTask){    
    try{       
        addShiftTaskTabItem(scheduleTask);    
        //shiftTaskComboBox.DataContext=scheduleTask;     
        tasksShiftComboBox.DataContext=scheduleTask;                                 
    }catch (Exception ex){
        MessageBox.Show("loadTask Exception: " + ex.Message);
    }                       
}

private 
void delTask(){
    this.baddingDtl = false;    
    model.deleteScheduleTask(reqListView,taskListView);    
}

private 
bool dataOkTask(){    
    bool            bresult=true;
    ScheduleTask    scheduleTask = getCurrentTask();    
         
    calcTaskLabourHours();
    
    bresult=  model.validTask(scheduleTask);            

    if (scheduleTask.EndDate < scheduleTask.StartDate){
        MessageBox.Show("End Date Might Be Bigger Than Start Date.");
        this.endDateTimeTRadDateTimePicker.Focus();
        bresult= false;                                
    }
                
    if (bresult)
        bresult = model.getValidNumericFromAlpha(this.taskTotEmployeesTextBox,"Tot Employees");
    if (bresult)
        bresult = model.getValidNumericFromAlpha(this.taskEmployeeHoursTextBox, "EmployeeHrs");
                      
    if (scheduleTask.StartShift < 1){
        MessageBox.Show("Please, Select Task.");
        this.tasksShiftComboBox.Focus();
        bresult= false;                                
    }

    ScheduleReqView scheduleReqViewFound = model.getAlreadySameDates( baddingDtl,scheduleTask);
    if (bresult && scheduleReqViewFound != null){
        string smess = "Sorry, Already Exist "  + scheduleReqViewFound.getScheduleTypeDescription() + " On Similar Range Dates\n" +
                        (scheduleReqViewFound.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_PART) ? "Part:" + scheduleReqViewFound.Part : "") +
                        (scheduleReqViewFound.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_TASK) ? "Task:" + scheduleReqViewFound.Description : "") + "\n" +
                        "Start:" + DateUtil.getCompleteDateRepresentationWithoutSS(scheduleReqViewFound.StartDate,DateUtil.MMDDYYYY) + "\n" +
                        "End  :" + DateUtil.getCompleteDateRepresentationWithoutSS(scheduleReqViewFound.EndDate, DateUtil.MMDDYYYY);
        if (System.Windows.Forms.MessageBox.Show(smess + " , Continue Anyway ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
            bresult= false;
        //ScheduleReqView scheduleReqViewFly = model.createScheduleReqView(getCurrentOriginalReq(), null,scheduleTask);        
        //model.getCoreFactory().moveDatesFromSchedulePartTask(scheduleHdr,model.ScheduleReqViewContainer,scheduleReqViewFly);
        bresult= true;    
    }
    return bresult;
}

private
void saveTask(){
    try{
        ScheduleTask    scheduleTask= getCurrentTask();    
                        
        if (scheduleHdr != null && scheduleTask != null && dataOkTask()){        
            model.loadShiftTaskName(scheduleTask); //load task description

            if (baddingDtl){                
                scheduleHdr.ScheduleTaskContainer.Add(scheduleTask);                                     
            }else//update so copy info from clone to original
               model.copyTask(scheduleTask);                
                                    
            saveLoad(baddingDtl,null, scheduleTask,null);                     
            removeScheduleTaskTabItem();
            moveToDetailTabItem();
        }

    }catch (Exception ex){
        MessageBox.Show("saveTask Exception: " + ex.Message);
    }  
}

private 
void startDateTimeTRadDateTimePicker_LostFocus(object sender, RoutedEventArgs e){
    startDateTimeTRadDateTimePickerLostFocus();
}

private 
void startDateTimeTRadDateTimePickerLostFocus(){
    ScheduleTask scheduleTask = getCurrentTask();
    if (scheduleTask!=null)
        scheduleTask.EndDate = scheduleTask.StartDate.AddHours(1);
}
    
private
void taskTotEmployeesTextBox_LostFocus(object sender, RoutedEventArgs e){
   // calcLabourHours();
}

private
void taskEmployeeHoursTextBox_LostFocus(object sender, RoutedEventArgs e){
    calcTaskLabourHours();
}

private
void calcTaskLabourHours(){
    try{
        ScheduleTask scheduleTask = getCurrentTask();    
        if (scheduleTask != null)
            scheduleTask.Hours = scheduleTask.TotEmployees * scheduleTask.EmployeeHours;
    }catch (Exception ex){
        MessageBox.Show("calcLabourHours Exception: " + ex.Message);
    } 
}

private 
void shiftFilterCheckBox_Checked(object sender, RoutedEventArgs e){
    
}

private
void shiftFilterCheckBoxChecked(){
    shiftFilterComboBox.IsEnabled = (bool)shiftFilterCheckBox.IsChecked;
    shiftFilterSelected();
}

private 
void shiftFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
   shiftFilterSelected();
}

private 
void shiftFilterCheckBox_Click(object sender, RoutedEventArgs e){
    shiftFilterCheckBoxChecked();
}

private 
void shiftFilterSelected(){
    string  shiftNum  = shiftFilterComboBox.SelectedItem != null ? ((Nujit.NujitWms.WinForms.Util.ComboBoxItem)shiftFilterComboBox.SelectedItem).Content.ToString() : "";
    if (shiftFilterComboBox.IsEnabled && NumberUtil.isIntegerNumber(shiftNum)){
        model.StartDateFilter = DateUtil.getStartDateByShiftNum(Convert.ToInt32(shiftNum), model.StartDateFilter);
        model.StopDateFilter = DateUtil.getEndDateByShiftNum(Convert.ToInt32(shiftNum), model.StopDateFilter);        

        startFilterRadDateTimePicker.SelectedValue = model.StartDateFilter;
        stopFilterRadDateTimePicker.SelectedValue = model.StopDateFilter;
    }
}

/********************************************** ReceiptPart ***********************************************************/
private 
void addPRecButton_Click(object sender, RoutedEventArgs e){
    addReceiptPart();
}

private 
void delPRecButton_Click(object sender, RoutedEventArgs e){
    delReceiptPart();
}

private 
void okReceiptPartButton_Click(object sender, RoutedEventArgs e){
    saveReceiptPart();
}

private 
void cancelReceiptPartButton_Click(object sender, RoutedEventArgs e){
    cancelReceiptPart();
}

private 
void partReceiptsListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
   modifyReceiptPart();
}

private 
void addReceiptPart(){    
    try{            
        SchedulePart schedulePart = getCurrentPart();

        if (schedulePart != null){                                            
            this.baddingSubDtl = true;                                                                                 
            loadReceiptPart(model.createReceiptPart(schedulePart));                                   
        }
                                         
    }catch (Exception ex){
        MessageBox.Show("addReceiptPart Exception: " + ex.Message);
    }                       
}

private
void modifyReceiptPart(){
    try{
        this.baddingSubDtl = false;                                    
        loadReceiptPart(model.cloneToModifyReceiptPart(partReceiptsListView));        
    }catch (Exception ex){
        MessageBox.Show("modifyReceiptPart Exception: " + ex.Message);
    }    

} 

private 
void cancelReceiptPart(){
    if (model.cancel()){
        model.cancelReceiptPart(getCurrentReceiptPart());
        baddingSubDtl = false;
        model.removeTabItem(mainTabControl,receiptPartTabItem);      
    }
}

private
void loadReceiptPart(ScheduleReceiptPart scheduleReceiptPart){    
    try{               
        model.addTabItem(mainTabControl,receiptPartTabItem,scheduleReceiptPart);                          
    }catch (Exception ex){
        MessageBox.Show("loadReceiptPart Exception: " + ex.Message);
    }                       
}

private 
void delReceiptPart(){
    this.baddingSubDtl = false;    
    model.deleteReceiptPart(partReceiptsListView,getCurrentPart());
}
          
private 
bool dataOkReceiptPart(){    
    bool                    bresult=true;
    ScheduleReceiptPart     scheduleReceiptPart = getCurrentReceiptPart();

    if (bresult)
        bresult = model.getValidNumericFromAlpha(this.receiptPartQtyTextBox,"Receipt Qty");

    return bresult;
}

private
void saveReceiptPart(){
    try{
        SchedulePart            schedulePart = getCurrentPart();  
        ScheduleReceiptPart     scheduleReceiptPart = getCurrentReceiptPart();
                
        if (schedulePart != null && scheduleReceiptPart != null && dataOkReceiptPart()){                    

            if (baddingSubDtl){                
                schedulePart.ScheduleReceiptPartContainer.Add(scheduleReceiptPart);                                     
            }else//update so copy info from clone to original
                model.copyReceiptPart(schedulePart, scheduleReceiptPart);                
                    
            schedulePart.fillRedundances();            
            model.loadGrid(partReceiptsListView,schedulePart.ScheduleReceiptPartContainer);
            model.removeTabItem(mainTabControl,receiptPartTabItem);            
        }

    }catch (Exception ex){
        MessageBox.Show("saveReceiptPart Exception: " + ex.Message);
    }  
}                   

/**************************************** Material Consumition **************************************************/
private 
void addMCButton_Click(object sender, RoutedEventArgs e){
    
}

private 
void delMCButton_Click(object sender, RoutedEventArgs e){
    
}

private 
void hotListTabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e){
    hotListTabControlSelectionChanged();
}

private 
void hotListTabControlSelectionChanged(){
    try {
        int indexSel    = hotListTabControl.SelectedIndex;
        int ipriorIndex = ihotListTabIndex;                

        /*lock(this)*/{
            if (indexSel != ihotListTabIndex){                        
                this.ihotListTabIndex = indexSel;
                hotListScrollVisibility(indexSel);            
                searchHotList(0);
                this.ihotListTabIndex = indexSel;
            }        
        }
    } catch (Exception ex) {
         MessageBox.Show("hotListTabControlSelectionChanged Exception: " + ex.Message);
    }
}

private
void hotListScrollVisibility(int index){    
    firstHButton.Visibility =prevHButton.Visibility =nextHButton.Visibility =lastHButton.Visibility  = (index==0) ? Visibility.Visible:Visibility.Hidden;
    firstH1Button.Visibility=prevH1Button.Visibility=nextH1Button.Visibility=lastH1Button.Visibility = (index==1) ? Visibility.Visible:Visibility.Hidden;
    firstH2Button.Visibility=prevH2Button.Visibility=nextH2Button.Visibility=lastH2Button.Visibility = (index==2) ? Visibility.Visible:Visibility.Hidden;
    firstH3Button.Visibility=prevH3Button.Visibility=nextH3Button.Visibility=lastH3Button.Visibility = (index==3) ? Visibility.Visible:Visibility.Hidden;
    firstH4Button.Visibility=prevH4Button.Visibility=nextH4Button.Visibility=lastH4Button.Visibility = (index==4) ? Visibility.Visible:Visibility.Hidden;
    firstH5Button.Visibility=prevH5Button.Visibility=nextH5Button.Visibility=lastH5Button.Visibility = (index==5) ? Visibility.Visible:Visibility.Hidden;
}


private
bool checkIfPartSelectedRelatedToMachine(SchedulePart schedulePart){
    bool bresult=false;
    try {        
        string              spart= "";
        int                 iseq = 0;
        decimal             dqty =0;
        DateTime            scheduleDateTime = DateUtil.MinValue;
        ScheduleMachine     scheduleMachine= getCurrentScheduleMachine();  
        
        if (scheduleMachine != null){

            if (getHotListPartSeqSelected(this.scheduleHdr.Plant,out spart, out iseq,out dqty,out scheduleDateTime)){                
                RoutingContainer routingContainer = model.getCoreFactory().getBuildByFilters(this.scheduleHdr.Plant,spart, iseq, scheduleMachine.MachId,true,false);
                if  (routingContainer.Count > 0) {                
                    Product product = model.getCoreFactory().readProduct(spart);
                    if (product!= null){
                        schedulePart.Part = spart;
                        schedulePart.Seq = iseq;
                        model.loadPartInfo(product, schedulePart.MachId,schedulePart,true,partTextBox);
                        bresult=true;
                    }
                    schedulePart.Seq = iseq;
                }
            }
        }
    } catch (Exception ex) {
        MessageBox.Show("checkIfPartSelectedRelatedToMachine Exception: " + ex.Message);
    }
    return bresult;
}

private
bool getHotListPartSeqSelected(string splant,out string spart,out int iseq,out decimal dqty,out DateTime scheduleDateTime){
    bool bresult=false;
    spart= "";
    iseq = 0;
    dqty = 0;
    scheduleDateTime = DateUtil.MinValue;

    try {
        ListView        listView= null;                   
        string[]        item = null;                
                        
        if (hotListTabControl.SelectedItem.Equals(hotListReceiptsPartsTab))
            listView = hotListDatesView;                    //4 / 5                    
        if (hotListTabControl.SelectedItem.Equals(hotListConsumPartsTab))
            listView = hotListDatesConsumView;                    
               
        if (listView != null){
            item = (string[])model.getSelected(listView);
            if (item!=null){
                spart= item[4];
                iseq = Convert.ToInt32(item[5]);
                model.getFirstDateWithQty(splant,item,out dqty,out scheduleDateTime); //try to get first schedule date                
            }
        }

        if (hotListTabControl.SelectedItem.Equals(inventoryTab) || hotListTabControl.SelectedItem.Equals(futureInventoryTab)){
            listView = hotListTabControl.SelectedItem.Equals(inventoryTab)  ? inventoryView : futureInventoryView;    
            item = (string[])model.getSelected(listView); //0 / 1
            if (item!=null){               
                spart= item[0];
                iseq = Convert.ToInt32(item[1]);
            }                        
        }

        if (!string.IsNullOrEmpty(spart)){
            bresult = true;
        }
        
    } catch (Exception ex) {
        MessageBox.Show("getHotListPartSeqSelected Exception: " + ex.Message);
    }
    return bresult;
}


private 
void scheduleHotListButton_Click(object sender, RoutedEventArgs e){
    scheduleHotListNew();
    bcontrol=false;
}

private 
bool scheduleHotList(){
    bool bresult=false;
    try {        
        string          spart= "";        
        decimal         dqty =0;
        DateTime        scheduleDateTime = DateUtil.MinValue;
        int             iseq = 0;                
        SchedulePart    schedulePart = model.getCoreFactory().createSchedulePart();
        bool            bonlyMachAlternative = (bool)this.alternativeMachineCheckBox.IsChecked;
                
        if (mainTabControl.Items.IndexOf(receiptPartTabItem) < 0 && this.scheduleHdr!= null){

            if (getHotListPartSeqSelected(scheduleHdr.Plant,out spart, out iseq,out dqty, out scheduleDateTime)){

                if (model.scheduleHotList(reqListView, reqFilterComboBox, partTextBox,
                                                    startFilterRadDateTimePicker,stopFilterRadDateTimePicker,
                    bonlyMachAlternative,this.scheduleHdr.Plant,spart, iseq, dqty, 0,scheduleDateTime,out schedulePart)){

                    baddingDtl=true;  
                    model.generateAutomaticReceiptPart(schedulePart,(bool)createAutomaticReceiptsCheckBox.IsChecked,matConsumListView);
                    loadPart(schedulePart,true);    
                }
            }else
                MessageBox.Show("Please, Select Item First.");
        }
    } catch (Exception ex) {
        MessageBox.Show("scheduleHotList Exception: " + ex.Message);
    }
    return bresult;
}   

private 
bool scheduleHotListNew(){
    bool bresult=false;
    try {
        HotListCellSel  hotListCellSel = null;                
        SchedulePart    schedulePart = model.getCoreFactory().createSchedulePart();
        bool            bonlyMachAlternative = (bool)this.alternativeMachineCheckBox.IsChecked;

        if (hotListTabControl.SelectedItem.Equals(inventoryTab) || hotListTabControl.SelectedItem.Equals(futureInventoryTab))
            hotListCellSel= model.getHotListCellSelsInventory(this.scheduleHdr, hotListTabControl.SelectedItem.Equals(futureInventoryTab));  
        
        if (hotListTabControl.SelectedItem.Equals(hotListReceiptsPartsTab) || hotListTabControl.SelectedItem.Equals(hotListConsumPartsTab))
            hotListCellSel = model.getHotListCellSels(this.scheduleHdr);

        if (scheduleHdr!= null && hotListCellSel != null){
            if (model.scheduleHotList(  reqListView, reqFilterComboBox, partTextBox,
                                        startFilterRadDateTimePicker,stopFilterRadDateTimePicker,
                                        bonlyMachAlternative,this.scheduleHdr.Plant, hotListCellSel.Part, hotListCellSel.Seq, hotListCellSel.Qty,0, hotListCellSel.DateTime, out schedulePart)){

                baddingDtl=true;  
                model.generateAutomaticReceiptPart(schedulePart,(bool)createAutomaticReceiptsCheckBox.IsChecked,matConsumListView);
                loadPart(schedulePart,true);    
            }
        }

    } catch (Exception ex) {
        MessageBox.Show("scheduleHotListNew Exception: " + ex.Message);
    }
    return bresult;
}   



private 
void createAutomaticReceiptsCheckBox_Click(object sender, RoutedEventArgs e){
    //addPRecButton.IsEnabled= delPRecButton.IsEnabled = !createAutomaticReceiptsCheckBox.IsEnabled;
}

/****************************************** Down **************************************************************************/
private
ScheduleDown getCurrentDown(){ 
    return (ScheduleDown)scheduleDownTabItem.DataContext;
}
        
private 
void modifyDown(ScheduleDown scheduleDown){    
    try{                
        if (model.ScheduleReqViewActive != null){                                                                                              
            AddDownWindow win = new AddDownWindow(model.ScheduleHdr,model.cloneToModifyDown(scheduleDown));
            if ((bool)win.ShowDialog()){
                baddingDtl =false;
                saveLoad(baddingDtl,null,null,scheduleDown);        
            }                                                
        }                                         
    }catch (Exception ex){
        MessageBox.Show("modifyDown Exception: " + ex.Message);
    }                       
}

private 
void addDown(){    
    try{
        ScheduleReqView scheduleReqView = model.validRequirment(reqListView);
        if (scheduleReqView != null){
            ScheduleDown    scheduleDown= null;
            model.ScheduleReqViewActive = scheduleReqView;    
                       
            scheduleDown = model.createDown(scheduleReqView.MachId);         
                               
            AddDownWindow win = new AddDownWindow(model.ScheduleHdr,scheduleDown);
            if ((bool)win.ShowDialog()){
                baddingDtl  =true;
                saveLoad(baddingDtl,null,null,scheduleDown);        
            }                                                            
        }                                 
    }catch (Exception ex){
        MessageBox.Show("addDown Exception: " + ex.Message);
    }                       
}

private
void addShiftDownTabItem(ScheduleDown scheduleDown){
    if (mainTabControl.Items.IndexOf(scheduleDownTabItem) < 0)
        mainTabControl.Items.Add(scheduleDownTabItem);        
    mainTabControl.SelectedItem = scheduleDownTabItem;
    scheduleDownTabItem.DataContext = null;
    scheduleDownTabItem.DataContext = scheduleDown;
}

private
void loadDown(ScheduleDown scheduleDown){    
    try{       
        addShiftDownTabItem(scheduleDown);                    
    }catch (Exception ex){
        MessageBox.Show("loadDown Exception: " + ex.Message);
    }                       
}

private 
bool dataOkDown(){    
    bool            bresult=true;
    ScheduleDown    scheduleDown = getCurrentDown();    
         
    calcDownLabourHours();    
        
    if (string.IsNullOrEmpty(scheduleDown.Type)){
        MessageBox.Show("Please, Select Type.");
       // this.shiftTaskComboBox.Focus();
        bresult= false;                                
    }        

    if (scheduleDown.EndDate < scheduleDown.StartDate){
        MessageBox.Show("End Date Might Be Bigger Than Start Date.");
        this.endDateTimeDRadDateTimePicker.Focus();
        bresult= false;                                
    }
                
    if (bresult)
        bresult = model.getValidNumericFromAlpha(this.downTotEmployeesTextBox,"Tot Employees");
    if (bresult)
        bresult = model.getValidNumericFromAlpha(this.downEmployeeHoursTextBox, "EmployeeHrs");
                      
    if (scheduleDown.StartShift < 1){
        MessageBox.Show("Please, Select Start Shift.");
        this.downShiftComboBox.Focus();
        bresult= false;                                
    }

    /*
    ScheduleReqView scheduleReqViewFound = model.getAlreadySameDates( baddingDtl, getCurrentOriginalReq(),
                                                                                scheduleTask);
    if (bresult && scheduleReqViewFound != null){
        string smess = "Sorry, Already Exist "  + scheduleReqViewFound.getScheduleTypeDescription() + " On Similar Range Dates\n" +
                        (scheduleReqViewFound.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_PART) ? "Part:" + scheduleReqViewFound.Part : "") +
                        (scheduleReqViewFound.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_TASK) ? "Task:" + scheduleReqViewFound.Description : "") + "\n" +
                        "Start:" + DateUtil.getCompleteDateRepresentationWithoutSS(scheduleReqViewFound.StartDate,DateUtil.MMDDYYYY) + "\n" +
                        "End  :" + DateUtil.getCompleteDateRepresentationWithoutSS(scheduleReqViewFound.EndDate, DateUtil.MMDDYYYY);
        if (System.Windows.Forms.MessageBox.Show(smess + " , Continue Anyway ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
            bresult= false;
        //ScheduleReqView scheduleReqViewFly = model.createScheduleReqView(getCurrentOriginalReq(), null,scheduleTask);        
        //model.getCoreFactory().moveDatesFromSchedulePartTask(scheduleHdr,model.ScheduleReqViewContainer,scheduleReqViewFly);
        bresult= true;    
    }*/
    return bresult;
}

private
void saveDown(){
    try{
        ScheduleDown    scheduleDown = getCurrentDown();    
                        
        if (scheduleHdr != null && scheduleDown != null && dataOkDown()){                  
            if (baddingDtl){                
                scheduleHdr.ScheduleDownContainer.Add(scheduleDown);                                     
            }else//update so copy info from clone to original
               model.copyDown(scheduleDown);                
                                                
            saveLoad(baddingDtl,null,null,scheduleDown);                     
            removeScheduleDownTabItem();
            moveToDetailTabItem();
        }

    }catch (Exception ex){
        MessageBox.Show("saveDown Exception: " + ex.Message);
    }  
}

        
private 
void startDateTimeDRadDateTimePicker_LostFocus(object sender, RoutedEventArgs e){
    startDateTimeDRadDateTimePickerLostFocus();
}

private 
void startDateTimeDRadDateTimePickerLostFocus(){
    ScheduleDown scheduleDown = getCurrentDown();
    if (scheduleDown != null) {
        scheduleDown.StartShift =  DateUtil.getShiftNum(scheduleDown.StartDate);
        scheduleDown.EndDate = scheduleDown.StartDate.AddHours(1);
    }
}
 
private
void downTotEmployeesTextBox_LostFocus(object sender, RoutedEventArgs e){
    //calcLabourHours();
}

private
void downEmployeeHoursTextBox_LostFocus(object sender, RoutedEventArgs e){
    calcDownLabourHours();
}

private
void calcDownLabourHours(){
    try{
        ScheduleDown scheduleDown = getCurrentDown();    
        if (scheduleDown != null)
            scheduleDown.Hours = scheduleDown.TotEmployees * scheduleDown.EmployeeHours;
    }catch (Exception ex){
        MessageBox.Show("calcDownLabourHours Exception: " + ex.Message);
    } 
}

private 
void okSheduleDownButton_Click(object sender, RoutedEventArgs e){
    saveDown();          
} 

private 
void cancelScheduleDownButton_Click(object sender, RoutedEventArgs e){
    cancelDown();
}

private 
void cancelDown(){
    if (model.cancel()){
        model.cancelDown(getCurrentDown());
        cancelDtl(scheduleDownTabItem);  
    }
}

/**************************************** *********************************************************************************/
private 
void equipmentCustomizedGantt_SelectedHeaderChanged(object sender, EventArgs e){
            /*
    this.insertingDownTime = false;
    showDownTime(false);

    Label label = (Label)sender;
    ArrayList tag = (ArrayList)label.Tag;
    this.selectedDepartment = (string)tag[22];
    this.selectedMachine = (string)tag[1];
    this.entry = null;*/
}

private void partCustomizedGantt_SelectedItemChanged(object sender, EventArgs e) {
    //selectedItemChanged(sender, null);
}

private void selectedLabelEventHandler(object sender, ScrollViewer scrollViewer) {
    selectedItemChanged(sender, scrollViewer);
}
   
private void selectedItemChanged(object sender, ScrollViewer scrollViewer){
            /*
    if (this.insertingDownTime) {
        this.insertingDownTime = false;
        showDownTime(false);
    }
    Label label = (Label)sender;
    ArrayList tag = (ArrayList)label.Tag;
    int selectedEntry = (int)tag[16];
    this.selectedDepartment = (string)tag[22];
    this.selectedMachine = (string)tag[1];

    if (scrollViewer != null)
    {
        this.labelSender = (Label)sender;
        this.labelSender.Loaded += new RoutedEventHandler(labelSender_Loaded);
        this.scrollViewerSender = scrollViewer;
    }
    jobSelectedMachine = selectedDepartment + "-" + selectedMachine;
    this.jobSelectedJob = getIndexJobsHashTable(selectedEntry, jobSelectedMachine); 
    selectionChange(selectedEntry);
    */
}

private 
void insertJobMenuItem_Click(object sender, RoutedEventArgs e){
}

private void equipmentCustomizedGantt_DragEnter(object sender, System.Windows.DragEventArgs e)
{
	// TODO: Agregar implementación de controlador de eventos aquí.
}

private void equipmentCustomizedGantt_DragLeave(object sender, System.Windows.DragEventArgs e)
{
	// TODO: Agregar implementación de controlador de eventos aquí.
}

private void equipmentCustomizedGantt_DragOver(object sender, System.Windows.DragEventArgs e)
{
	// TODO: Agregar implementación de controlador de eventos aquí.
}

private void equipmentCustomizedGantt_Drop(object sender, System.Windows.DragEventArgs e)
{
	// TODO: Agregar implementación de controlador de eventos aquí.
}
        /*
private
void loadEquipmentListViewColumns() {
    equipmentCustomizedGantt.AddColumn("Dep.");
    equipmentCustomizedGantt.AddColumn("Machine");
    equipmentCustomizedGantt.AddColumn("Priority");
    equipmentCustomizedGantt.ColumnsQty = 1000;
}

private
ArrayList setGridData(){
    ArrayList   arrayList = new ArrayList();
    try{       
        DataTable dataTable = new DataTable("Equipment");
    
        //dataTable.Columns.Add("SCE_Db", typeof(string));
        //dataTable.Columns.Add("SCE_Company", typeof(string));
        //dataTable.Columns.Add("SCE_Plant", typeof(string));
        dataTable.Columns.Add("SCE_Department", typeof(string));
        dataTable.Columns.Add("SMC_Machine", typeof(string));
        dataTable.Columns.Add("SCE_QueuePos", typeof(int));
        dataTable.Columns.Add("PART", typeof(string));
        dataTable.Columns.Add("SEQ", typeof(int));
        dataTable.Columns.Add("SCE_Duration", typeof(TimeSpan));
        dataTable.Columns.Add("QTY", typeof(decimal));
        dataTable.Columns.Add("UOM", typeof(string));

        dataTable.Columns.Add("RUNSTD", typeof(decimal));
        dataTable.Columns.Add("SCE_Date", typeof(DateTime));
        dataTable.Columns.Add("SCE_TimeStart", typeof(TimeSpan));            
        //dataTable.Columns.Add("SCE_ParentEntryId", typeof(int));
        dataTable.Columns.Add("SCE_OTAllowed", typeof(string));
        dataTable.Columns.Add("ISFAMILYPART", typeof(string));
        dataTable.Columns.Add("SMC_HoursProduction", typeof(decimal));
        dataTable.Columns.Add("SMC_UtilPercent", typeof(decimal));
        dataTable.Columns.Add("SMC_TimeCode", typeof(string));
        dataTable.Columns.Add("SCE_SchId", typeof(int));
        dataTable.Columns.Add("SCE_VersionId", typeof(int));
        dataTable.Columns.Add("SCE_Db", typeof(string));
        dataTable.Columns.Add("SCE_Company", typeof(string));
        dataTable.Columns.Add("SCE_Plant", typeof(string));
        dataTable.Columns.Add("SCE_CurrentShift", typeof(string));
        dataTable.Columns.Add("DE_Dept", typeof(string));
        dataTable.Columns.Add("PDM_Priority", typeof(int));
        dataTable.Columns.Add("SCE_Status", typeof(string));
        dataTable.Columns.Add("SCP_QtyReported", typeof(decimal));
        dataTable.Columns.Add("SCP_QtyRemaining", typeof(decimal));
        
        string []   item      = new string[30]; 

        for (int j=0; j < item.Length;j++)
            item[j] = "22";
        arrayList.Add(item);

        for (int i = 0; i < arrayList.Count; i++) {
            ArrayList line = (ArrayList)arrayList[i];
            DataRow dataRow = dataTable.NewRow();
            for (int j = 0; j < line.Count; j++) {            
                dataRow[j] = line[j];
            }
            dataTable.Rows.Add(dataRow);

        }        
     
    } catch (Exception ex) {
       MessageBox.Show("setGridData :" + ex.Message);
    }
    return arrayList;
}

private double getPeriod(TimeSpan timeSpan) {
    return timeSpan.Days*24 + timeSpan.Hours + (timeSpan.Minutes / 60);
}

private TimeSpan getDuration(double period) {
    int hours = (int)Math.Floor(period);
    int minutes = (int)((period - hours)*60);
    return new TimeSpan(hours, minutes, 0);
}


public override void OnApplyTemplate() {
    base.OnApplyTemplate();
    equipmentCustomizedGantt.OnApplyTemplate();
    //loadEquipmentListViewColumns();
    //refreshEquipmentGrid();
}

private 
void setGanttData() {
    try{        
        if (equipmentCustomizedGantt != null) {

            equipmentCustomizedGantt.selectedLabelChanged += new NujitWPFUtilities.SelectedLabelChanged(selectedLabelEventHandler);

            equipmentCustomizedGantt.ClearRows();
            if (equipmentCustomizedGantt.ColumnsQty <= 0)
                loadEquipmentListViewColumns();
            DateTime actualDateTime = DateTime.Now;

            ScheduleReqViewContainer    scheduleReqViewContainer =(ScheduleReqViewContainer)reqListView.DataContext;
            ScheduleReqView             scheduleReqView = null;

            for (int i = 0; i < scheduleReqViewContainer.Count; i++) {
                scheduleReqView = scheduleReqViewContainer[i];

                ArrayList   line = new ArrayList();//setGridData();

                for (int j=0; j < 25;j++)
                    line.Add("0");

                Machine machine = model.getCoreFactory().readMachineById(scheduleReqView.ReqID);

                line[0]         = machine!= null ? machine.Dept :"";
                line[1]         = scheduleReqView.ReqDescription;
                line[23]        = scheduleReqView.HdrId.ToString();
                line[2]         = scheduleReqView.ReqDescription; 
                line[3]         = scheduleReqView.TypeDescription;
                line[12]        = "N";
                line[15]        = "BLUE";                        

                int         queuePos = Convert.ToInt32(line[2]);// (int)line[2];
                string      timeCode = (string)line[15];
                ItemDetail  itemDetail = new ItemDetail();
                itemDetail.Info = (string)line[3];
                itemDetail.Tag = line;
                bool        toAdd = true;
                string      isFamily = (string)line[12];

                TimeSpan durationTimeSpan = scheduleReqView.EndDate.Subtract(scheduleReqView.StartDate);
                itemDetail.Period = getPeriod(durationTimeSpan);

                        /*
                if (isFamily.Equals(Constants.STRING_YES) && !string.IsNullOrEmpty(itemDetail.Info) ) {
                    familyCfgHdr = familyCfgHdrContainer.getByKey(getDefDataBase(), getDefCompany(), getDefPlant(), itemDetail.Info);
                    if (familyCfgHdr == null) {
                        familyCfgHdr = getCoreFactory().readFamilyCfgHdr(getDefDataBase(), getDefCompany(), getDefPlant(), itemDetail.Info);
                        if (familyCfgHdr != null)
                            familyCfgHdrContainer.Add(familyCfgHdr);
                    }
                    if (familyCfgHdr != null) {
                        string partInfo = "";                                                
                        foreach (FamilyCfgDtl familyCfgDtl in familyCfgHdr.FamilyCfgDtlContainer)
                            partInfo += (!string.IsNullOrEmpty(partInfo) ? "," : "") + familyCfgDtl.Part;
                        itemDetail.Info = partInfo;
                    }
                }*/

                        /*
                TimeSpan durationTimeSpan = (TimeSpan)line[5];
                if (scaleNujitWPFComboBox.SelectedIndex == 1) {
                    if (getCoreFactory().existsShift((string)line[18], (string)line[19], (string)line[20], (string)line[0], (string)line[21])) {
                        Shift shift = getCoreFactory().readShift((string)line[18], (string)line[19], (string)line[20], (string)line[0], (string)line[21]);
                        DateTime startPeriod = shift.getStartPeriod();
                        DateTime endPeriod = shift.getEndPeriod();
                        durationTimeSpan = endPeriod.Subtract(startPeriod);
                    } else {
                        double durationInt = getPeriod(durationTimeSpan);
                        double durationShiftInt = durationInt / 8;
                        durationTimeSpan = getDuration(durationShiftInt);
                    }
                }*/

                        /*
                if (scaleNujitWPFComboBox.SelectedIndex == 5){
                    itemDetail.Period = FIXED_PERIOD;
                    if (queuePos < 1)
                        itemDetail.Period = 0;//set 0 so not be showed on grid, only will show machine
                }else{
                    if (remainingTimeNujitWPFComboBox.SelectedIndex == 1)
                        itemDetail.Period = getPeriod(durationTimeSpan);
                    else{
                        DateTime entryDateTime = (DateTime)line[9];
                        entryDateTime = entryDateTime.Add((TimeSpan)line[10]);
                        if (entryDateTime.CompareTo(actualDateTime) > 0){
                            itemDetail.Period = getPeriod(durationTimeSpan);
                        }else{
                            entryDateTime = entryDateTime.Add(durationTimeSpan);
                            if (entryDateTime.CompareTo(actualDateTime) > 0){
                                itemDetail.Period = getPeriod(entryDateTime.Subtract(actualDateTime));
                            }else{
                                toAdd = false;
                            }
                        }
                    }
                }*/

                /*
                //get color                                
                string colorString = MachineWork.getColorByTimeCode(timeCode, queuePos, (decimal)line[24], (decimal)line[25]);
                string[] rgb = colorString.Split(',');
                if (rgb.Length == 3){
                    Color color = Color.FromRgb(byte.Parse(rgb[0]), byte.Parse(rgb[1]), byte.Parse(rgb[2]));
                    itemDetail.Color = color;
                }

                if ( (i % 2) ==0)
                    itemDetail.Color = Colors.Green;
                else
                    itemDetail.Color = Colors.Blue;

                equipmentCustomizedGantt.AddRow(new GantItem(new object[] {"1","1","1"}, line, itemDetail));           
                
                //if (toAdd) equipmentCustomizedGantt.AddRow(new GantItem(new object[] {line[0],line[1],1}, line, itemDetail));           
            }
        }
    }catch (Exception ex){
        MessageBox.Show("setGanttData :" + ex.Message);                
    }
}
    */
private 
void Window_KeyDown(object sender, KeyEventArgs e){
    if (            (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control){
                if (!bcontrol){
                    if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) { 
                        model.startCellSelect();
                        model.addIfCurrCellFocused();
                    }
                    bcontrol=true;
                }
    }
}

private void Window_KeyUp(object sender, KeyEventArgs e){
    if (Keyboard.IsKeyUp(Key.LeftCtrl) || Keyboard.IsKeyUp(Key.RightCtrl)) { 
        bcontrol=false; 
    }
}

}
}
