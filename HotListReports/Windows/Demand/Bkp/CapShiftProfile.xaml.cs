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
using Nujit.NujitERP.ClassLib.Core.Machines;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core.Cms;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;

using Nujit.NujitWms.WinForms.Util.Grids;
using Nujit.NujitWms.WinForms.Util.Converters;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using System.Collections.ObjectModel;
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Common;
using System.Collections;
using Nujit.NujitERP.ClassLib.Core.Planned;

namespace HotListReports.Windows.Demand{

    
/// <summary>
/// Interaction logic for CapShiftProfileWindow.xaml
/// </summary>
public partial 
class CapShiftProfileWindow : Window{

private CapShiftProfileModel model;
private CapacityReportModel capacityReportModel;

private int itabIndex;
private int itabMaxPlanIndex;
private CapShiftProfile capShiftProfile;
private CapShiftProfileDtl capShiftProfileDtl;
private CapShiftProfileMachPlan capShiftProfileMachPlan;
private ListView editListView;
private ButtonsListViewFunctions buttonsListViewFunctions;
private ButtonsListViewFunctions buttonsListViewDetailsFunctions;
private bool badding;
private bool baddingDtl;

private PlannedHdr  plannedHdrSelected;
private PlannedPart plannedPartSelected;

public 
CapShiftProfileWindow(PlannedHdr plannedHdrSelected = null,PlannedPart plannedPartSelected=null){
    InitializeComponent();

    this.itabIndex = 0;
    this.itabMaxPlanIndex  =0;
    this.capShiftProfile = null;      
    this.capShiftProfileDtl = null;
    this.capShiftProfileMachPlan = null;    
    this.badding=false;
    this.baddingDtl = false;
    
    this.model = new CapShiftProfileModel(this,addShiftsListView,addShiftsRListView, addShiftsTotalRListView,addMachPlanListView,addMachPlanEmployeeListView,machPlanEmployeeListView,machPlanEmployeeTopLabel);
    this.capacityReportModel = new CapacityReportModel(this,null,null);
    this.editListView = null;        

    this.plannedHdrSelected = plannedHdrSelected;
    this.plannedPartSelected = plannedPartSelected;
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
        enableDatesComboEvent(false);  
        statusComboBox.SelectionChanged-= statusComboBox_SelectionChanged;
        
        buttonsListViewFunctions = new ButtonsListViewFunctions(this.hdrListView,firstButton,prevButton,nextButton,lastButton);

        model.removeTabItem(mainTabControl,dtlsTabItem);
        model.removeTabItem(mainTabControl,machPlanTabItem);
        model.removeTabItem(addMachPlanTabControl, addMachPlanEmployeeTabItem);                

        model.addButtonsListViewFunctions(this.dayLabourShift1ListView,     firstS1Button,   prevS1Button, nextS1Button, lastS1Button);
        model.addButtonsListViewFunctions(this.dayLabourShift2ListView,     firstS2Button,   prevS2Button, nextS2Button, lastS2Button);
        model.addButtonsListViewFunctions(this.dayLabourShift3ListView,     firstS3Button,   prevS3Button, nextS3Button, lastS3Button);
        model.addButtonsListViewFunctions(this.addShiftsListView,           firstASButton,   prevASButton, nextASButton, lastASButton);
        model.addButtonsListViewFunctions(this.addShiftsRListView,          firstASRButton,  prevASRButton,nextASRButton,lastASRButton);
        model.addButtonsListViewFunctions(this.addMachPlanListView,         firstMPButton,   prevMPButton, nextMPButton, lastMPButton);
        model.addButtonsListViewFunctions(this.addMachPlanEmployeeListView, firstMPEButton,  prevMPEButton,nextMPEButton,lastMPEButton);
        model.addButtonsListViewFunctions(this.machPlanEmployeeListView,    firstMPEMPButton,prevMPEMPButton, nextMPEMPButton, lastMPEMPButton);
                
        this.recordsTextBox.Text = Configuration.SearchDefaultMaxRecords;
        model.loadSearchByCombo(searchByComboBox);

        model.loadStatusComboBox(statusFilterComboBox,true);
        model.loadShiftNumComboBox(shiftNumFilterComboBox,3,true);
                
        model.loadPlantCombo(plantComboBox,false);model.setSelectedComboBoxItem(plantComboBox,Configuration.DftPlant);

        model.loadColumnsOnPlannedVsShiftProfileListView(plannedVsShiftProfileListView,true);
        model.loadColumnsOnPlannedVsShiftProfileListView(dtPlannedVsShiftProfileListView,false);

        dtPlannedVsShiftProfileListView.GroupStyle.Add(model.generateListViewGroupStyle("Name",18,Colors.Gold,Colors.Silver,12,2,1));
        model.loadColumnsOnPlannedVsShiftProfileListView(dtPlannedVsShiftProfileListView,false);
        //capacityReportModel.loadColumnsOnAvailableLabourListViewGrid(availableLabourListView);

        model.loadColumnsOnHeaderGrid(hdrListView);           
        model.loadShiftTaskComboBox(shiftTaskComboBox,false);        
                
        model.loadPlantCombo(plantWeekComboBox,false);model.setSelectedComboBoxItem(plantWeekComboBox, Configuration.DftPlant);
        model.loadStatusComboBox(statusComboBox,false);model.setSelectedComboBoxItem(statusComboBox, Constants.STATUS_ACTIVE);
        DateTime startDate= DateTime.Now;
        DateTime endDate= DateTime.Now;
        DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now,out startDate,out endDate);        
        model.loadDatesCombos(shift1StComboBox,shift1EndComboBox, startDate);
        model.loadDatesCombos(shift2StComboBox,shift2EndComboBox, startDate);
        model.loadDatesCombos(shift3StComboBox,shift3EndComboBox, startDate);
        setComboDates(startDate,endDate);
        
        model.loadColumnsOnDetailGrid(dayLabourShift1ListView);
        model.loadColumnsOnDetailGrid(dayLabourShift2ListView);
        model.loadColumnsOnDetailGrid(dayLabourShift3ListView);
        model.loadColumnsOnMachinePlanGrid(addMachPlanListView);
        model.loadColumnsOnMachinePlanEmployeeGrid(addMachPlanEmployeeListView);
        model.loadColumnsOnEmployeeGrid(machPlanEmployeeListView);

        model.loadHolidayType(holidayTypeComboBox,false);

        //add
        model.loadColumnsOnAddDetailGrid(addShiftsRListView);
        model.loadColumnsOnAddDetailGrid(addShiftsTotalRListView,true);
        model.loadDatesCombos(shiftAddStComboBox,shiftAddEndComboBox, startDate);
        model.loadPlantCombo(plantAddWeekComboBox, false);model.setSelectedComboBoxItem(plantAddWeekComboBox,Configuration.DftPlant);
        model.loadStatusComboBox(statusAddComboBox,false);
        setComboDates(startDate,endDate);
        setComboDate(shiftAddStComboBox, startDate);
        setComboDate(shiftAddEndComboBox, endDate);

        model.loadColumnsOnAddLeftDetailGrid(addShiftsListView,Configuration.DftPlant, startDate);
        // model.removeTabItem(mainTabControl,addTabItem);
        model.removeTabItem(mainTabControl, dayLabourTabItem);

        model.loadYesNoComboBox(fullShiftComboBox,false);
        model.loadShiftTypesComboBox(shiftTypeComboBox);                

        model.screenFullArea();

        if (!applyFilter())
            search();           
        
    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }finally{        
        statusComboBox.SelectionChanged+= statusComboBox_SelectionChanged;
        enableDatesComboEvent(true);                      
    }
}

private
bool applyFilter(){    
    bool bexitsFilter=false;
    try{
        if (plannedHdrSelected!= null && plannedPartSelected != null){        
            bexitsFilter=true;

            mainTabControl.SelectedItem = addTabItem;
            model.setSelectedComboBoxItem(shiftAddStComboBox,DateUtil.getDateRepresentation(plannedPartSelected.StartDate,DateUtil.MMDDYYYY));        
        
            CapShiftProfile         capShiftProfile = model.getCoreFactory().readCapShiftProfile(plannedPartSelected.ProfMachPlanHdrId);
            CapShiftProfileMachPlan capShiftProfileMachPlan = null;

            if (capShiftProfile!= null){
                model.setSelected(addShiftsListView,capShiftProfile);
            
                capShiftProfileMachPlan = capShiftProfile.CapShiftProfileMachPlanContainer.getByKey(plannedPartSelected.ProfMachPlanHdrId, plannedPartSelected.ProfMachPlanHdrDtl);
                if (capShiftProfileMachPlan!= null)
                    model.setSelected(addMachPlanListView,capShiftProfileMachPlan);
            }           
        }
    } catch (Exception ex) {
        MessageBox.Show("applyFilter Exception: " + ex.Message);        
    }
    return bexitsFilter;
}

private
void setComboDates(DateTime startDate,DateTime endDate){
    model.setSelectedComboBoxItem(shift1StComboBox,DateUtil.getDateRepresentation(startDate,DateUtil.MMDDYYYY));
    model.setSelectedComboBoxItem(shift1EndComboBox,DateUtil.getDateRepresentation(endDate, DateUtil.MMDDYYYY));

    model.setSelectedComboBoxItem(shift2StComboBox,DateUtil.getDateRepresentation(startDate,DateUtil.MMDDYYYY));
    model.setSelectedComboBoxItem(shift2EndComboBox,DateUtil.getDateRepresentation(endDate, DateUtil.MMDDYYYY));

    model.setSelectedComboBoxItem(shift3StComboBox,DateUtil.getDateRepresentation(startDate,DateUtil.MMDDYYYY));
    model.setSelectedComboBoxItem(shift3EndComboBox,DateUtil.getDateRepresentation(endDate, DateUtil.MMDDYYYY));

    model.setSelectedComboBoxItem(shiftAddStComboBox,DateUtil.getDateRepresentation(startDate,DateUtil.MMDDYYYY));
    model.setSelectedComboBoxItem(shiftAddEndComboBox,DateUtil.getDateRepresentation(endDate, DateUtil.MMDDYYYY));
}

private
void setComboDate(ComboBox combo,DateTime date){
    model.setSelectedComboBoxItem(combo, DateUtil.getDateRepresentation(date, DateUtil.MMDDYYYY));    
}

private 
void hdrListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    badding=false;
    baddingDtl=false;
    //mainTabControl.SelectedItem = this.dtlTabItem;
}

private 
void detailsListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    baddingDtl=false;
    mainTabControl.SelectedItem = this.dtlsTabItem;
}

private 
void searchButton_Click(object sender, RoutedEventArgs e){
    search();
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

            if (indexSel>=0 && indexSel <=1 && mainTabControl.Items.Count > 2){
                this.itabIndex = mainTabControl.Items.Count - 1;
                mainTabControl.SelectedIndex = (mainTabControl.Items.Count-1);                    
                return;
            }  
                       
            if (indexSel == 0){
                this.capShiftProfile = null;
                search();
            }else if (indexSel == 1){                
                CapShiftProfile capShiftProfileAux = null;
                if (ipriorIndex !=0)                   
                    capShiftProfileAux = capShiftProfile;                                  
                loadAddLabour();

                if (ipriorIndex !=0 && capShiftProfileAux != null) { 
                   model.setSelected(addShiftsListView,capShiftProfileAux); //select profile recently added/changed
                   model.setSelected(addShiftsRListView,capShiftProfileDtl);     
                }                                                             
    
            }else if (indexSel == 2){
                                
                if (true /*ipriorIndex == 1*/){
                    if (baddingDtl)
                        capShiftProfileDtl = (CapShiftProfileDtl)dtlsTabItem.DataContext ;
                    
                    if (capShiftProfileDtl != null)
                        loadCapacityD(capShiftProfileDtl);
                    else
                        mainTabControl.SelectedItem = this.dayLabourTabItem;
                }else
                     mainTabControl.SelectedItem = this.viewTabItem;

            } 
        }
                 
    } catch (Exception ex) {        
        MessageBox.Show("mainTabControlSelectionChanged Exception: " + ex.Message);  
    }

}

private
void  loadCapacityH(){
    //show details     
    //model.setDataContextListView(this.detailsListView, capShiftProfile.CapShiftProfileDtlContainer);       
    //showDtl(editListView,capShiftProfile,capShiftProfileDtl);
    this.badding=false;
    this.baddingDtl = false;
    model.showDtlNew(addShiftsRListView);
}

private
void  loadCapacityD(CapShiftProfileDtl capShiftProfileDtl){
    this.dtlsTabItem.DataContext = null; //clear info       
    if (baddingDtl)
        this.dtlsTabItem.DataContext = capShiftProfileDtl;
    else
        this.dtlsTabItem.DataContext = capShiftProfileDtl!= null ? model.getCoreFactory().cloneCapShiftProfileDtl(capShiftProfileDtl) :null;    
    this.numPeopleTextBox.Focus();        
}

private 
void search(){
    Cursor cursor = this.Cursor;
    try {        
        model.ProcessStart();
        
        string      splant      = model.getSelectedComboBoxItemString(plantComboBox);        
        model.loadPlannedVsShifProfile(this.plannedVsShiftProfileListView, dtPlannedVsShiftProfileListView,splant);
                                     
        model.search(recordsTextBox, searchByComboBox, searchForTextBox,plantComboBox,
                    statusFilterComboBox,shiftNumFilterComboBox,hdrListView);                            

        timeLabel.Content = model.ProcessEndAndTex(hdrListView.Items.Count);

    } catch (Exception ex) {
       MessageBox.Show("search Exception: " + ex.Message); 
    }finally {
        this.Cursor = cursor;    
    }            
} 
     
private 
void addButton_Click(object sender, RoutedEventArgs e){
    mainTabControl.SelectedItem = this.dayLabourTabItem;    
}

private 
void delButton_Click(object sender, RoutedEventArgs e){
    del();
}

private 
void add(){    
    try{
        this.badding=true;
        model.add(out capShiftProfile,model.getSelectedComboBoxItemString(plantComboBox));                
        
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
void okButton_Click(object sender, RoutedEventArgs e){
    save(true);
}

private 
void save(bool bmove){    
    try{        
        if (dataOK()){                        
            model.save(capShiftProfile);            
            if (bmove){ 
                MessageBox.Show("Capacity Task Saved Properly.");
                mainTabControl.SelectedItem = viewTabItem;                                      
            }
        }                           
    }catch (Exception ex){
        MessageBox.Show("save Exception: " + ex.Message);
    }                       
}          

private 
bool dataOK(){    
    bool bresult=true;
     /*
    if (this.capShiftProfile.ShiftNum <=0){
        MessageBox.Show("Please, Select Shift Num.");
        this.shiftNumComboBox.Focus();
        bresult=false;
    }
    
    if (this.capShiftProfile.StartDate > this.capShiftProfile.EndDate){
        MessageBox.Show("Please, ReEnter EndDate, Might Be Bigger Than Start Date.");
        this.endDatePicker.Focus();
        bresult=false;
    }
    */
    return bresult;
} 

private
void addDtlButton_Click(object sender, RoutedEventArgs e){
    addDtl();
}

private
void delDtlButton_Click(object sender, RoutedEventArgs e){
    //delDtl(this.detailsListView);
}

private
void addDtl(){
    try{        
        if (capShiftProfile!=null){                        
            baddingDtl = true;
            dtlsTabItem.DataContext = capShiftProfileDtl = model.getCoreFactory().createCapShiftProfileDtl();                 
            model.addTabItem(mainTabControl,dtlsTabItem,capShiftProfileDtl);            
        }                           
    }catch (Exception ex){
        MessageBox.Show("addDtl Exception: " + ex.Message);
    }   
}

private
void delDtl(ListView listView){
    try{
        capShiftProfileDtl = (CapShiftProfileDtl)model.getSelected(listView);
        
        if (capShiftProfileDtl != null){            
            if (System.Windows.Forms.MessageBox.Show("Do You Want To Delete Item ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes){
                capShiftProfile.CapShiftProfileDtlContainer.Remove(capShiftProfileDtl);
                capShiftProfile.fillRedundances();                
                showDtl(listView,capShiftProfile,null); 
                save(false);
            }
        }else
            MessageBox.Show("Please, Select Item First.");

    }catch (Exception ex){
        MessageBox.Show("delDtl Exception: " + ex.Message);
    }   

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
void okDtlsButton_Click(object sender, RoutedEventArgs e){
    okDtls();
}

private
void cancelDtlsButton_Click(object sender, RoutedEventArgs e){
    cancelDtls();
}

private
bool dataOkDtl(){
    bool bresult=true;
    try{        
        capShiftProfileDtl  = (CapShiftProfileDtl)this.dtlsTabItem.DataContext;
        CapShiftTask        capShiftTask        =  null;
        string              shiftTaskId         = shiftTaskComboBox.SelectedItem != null ? ((Nujit.NujitWms.WinForms.Util.ComboBoxItem)shiftTaskComboBox.SelectedItem).Content.ToString() : "";
        int                 ishiftTaskId        = !string.IsNullOrEmpty(shiftTaskId) ? Convert.ToInt32(shiftTaskId) : 0;

        if (capShiftProfile!=null && capShiftProfileDtl!=null){
            
            capShiftTask  = ishiftTaskId > 0 ? model.getCoreFactory().readCapShiftTask(ishiftTaskId) : null;//read cap shift task

            if (capShiftTask == null){
                MessageBox.Show("Please, Select Shift Task.");
                shiftTaskComboBox.Focus();
                bresult=false;
            }else if (baddingDtl){
                CapShiftProfileDtl capShiftProfileDtlAux = capShiftProfile.CapShiftProfileDtlContainer.getByShiftTaskId(ishiftTaskId);
                if (capShiftProfileDtlAux!=null){
                    MessageBox.Show("Sorry, Shift Task Id :" + ishiftTaskId + " Already Added, Please Select Other.");
                    shiftTaskComboBox.Focus();
                    bresult=false;
                }
            }    

            if (bresult) { 
                capShiftProfileDtl.ShiftTaskId = capShiftTask != null ? capShiftTask.Id : 0;
                capShiftProfileDtl.TaskNameShow= capShiftTask != null ? capShiftTask.TaskName : "";            
                capShiftProfileDtl.DirIndShow  = capShiftTask != null ? capShiftTask.DirInd : "";

                bool    bvalidNumPeople = model.getValidNumericFromAlpha(this.numPeopleTextBox,"Num. People");
                bool    bvalidPercentaje= model.getValidNumericFromAlpha(this.newPeopleTextBox,"New People");
                bool    bvalidHours     = model.getValidNumericFromAlpha(this.hoursTextBox, "Hours");                    

                bresult= bvalidNumPeople && bvalidPercentaje && bvalidHours;
                if (bvalidNumPeople && bvalidPercentaje && bvalidHours){
                    capShiftProfileDtl.NumPeople= Convert.ToInt32(this.numPeopleTextBox.Text);
                    capShiftProfileDtl.NewPeople= Convert.ToInt32(this.newPeopleTextBox.Text);
                    capShiftProfileDtl.Hours= Convert.ToDecimal(this.hoursTextBox.Text);

                            /*
                    MessageBox.Show("TextBox " +" Num. People :" + this.numPeopleTextBox.Text +
                                                " Percentaje  :" + this.percentajeTextBox.Text +
                                                " Hours  :" + this.hoursTextBox.Text + "\n" +
                                    "New     " +" Num. People :" + capShiftProfileDtl.NumPeople +
                                                " Percentaje  :" + capShiftProfileDtl.Percentaje +
                                                " Hours  :" + capShiftProfileDtl.Hours);*/

                    if (capShiftProfileDtl.Hours <=0){
                        MessageBox.Show("Please, Select Percentaje Or Hours.");
                        this.hoursTextBox.Focus();
                        bresult=false;
                    }
                }                  
            }                  
        }else
            bresult=false;
 
        
    }catch (Exception ex){
        MessageBox.Show("dataOkDtl Exception: " + ex.Message);
        bresult=false;
    }    
    return bresult;
}

private
void okDtls(){
    try{
        capShiftProfileDtl = (CapShiftProfileDtl)this.dtlsTabItem.DataContext;
        CapShiftProfileDtl  capShiftProfileDtlModified = null;
        
        if (dataOkDtl()){
            
            if (baddingDtl) { 
                capShiftProfile.CapShiftProfileDtlContainer.Add(capShiftProfileDtl);
            }else{
                //update, so modify original object
                capShiftProfileDtlModified = capShiftProfile.CapShiftProfileDtlContainer.getByKey(capShiftProfileDtl.HdrId, capShiftProfileDtl.Detail);
                if (capShiftProfileDtlModified!=null)
                    capShiftProfileDtlModified.copy(capShiftProfileDtl);         
                
                capShiftProfileDtl= capShiftProfileDtlModified;
            } 

            capShiftProfile.fillRedundances();
            loadCapacityH();            
            model.save(capShiftProfile);    
            model.removeTabItem(mainTabControl,this.dtlsTabItem);            
        }
 
    }catch (Exception ex){
        MessageBox.Show("okDtls Exception: " + ex.Message);
    }    
}
                        
private
void cancelDtls(){
    try{
        model.removeTabItem(mainTabControl,this.dtlsTabItem);
        mainTabControl.SelectedItem = dayLabourTabItem;
    }catch (Exception ex){
        MessageBox.Show("cancelDtls Exception: " + ex.Message);
    } 
    
}

private
void createCapCurrYearButton_Click(object sender, RoutedEventArgs e){
    createCapRecordsFullCurrYear();
}

private
void createCapRecordsFullCurrYear(){
    if (model.createCapRecordsFullCurrYear(hdrListView))
        search();
}

private 
void shift1StDateRadDateTimePicker_LostFocus(object sender, RoutedEventArgs e){
        
}

private
void addS1Button_Click(object sender, RoutedEventArgs e){    
    addWeekDtl(dayLabourShift1GroupBox,dayLabourShift1ListView);    
}

private
void addS2Button_Click(object sender, RoutedEventArgs e){    
    addWeekDtl(dayLabourShift2GroupBox,dayLabourShift2ListView);    
}

private
void addS3Button_Click(object sender, RoutedEventArgs e){    
    addWeekDtl(dayLabourShift3GroupBox,dayLabourShift3ListView);    
}

private
void delS1Button_Click(object sender, RoutedEventArgs e){
    delWeekDtl(dayLabourShift1GroupBox, dayLabourShift1ListView);    
}

private
void delS2Button_Click(object sender, RoutedEventArgs e){
    delWeekDtl(dayLabourShift2GroupBox, dayLabourShift2ListView);    
}

private
void delS3Button_Click(object sender, RoutedEventArgs e){
    delWeekDtl(dayLabourShift3GroupBox, dayLabourShift3ListView);    
}

private
void loadDayLabour(int ishiftNum=0){
    try{
        enableDatesComboEvent(false);                
        string   splant = model.getSelectedComboBoxItemString(plantAddWeekComboBox);
        string   status = model.getSelectedComboBoxItemString(statusComboBox);
                
        if (ishiftNum == 0 || ishiftNum == 1)
            model.loadDayLabourShift(splant, status,1, dayLabourShift1GroupBox,dayLabourShift1ListView,shift1StComboBox);
        if (ishiftNum == 0 || ishiftNum == 2)
            model.loadDayLabourShift(splant, status,2, dayLabourShift2GroupBox,dayLabourShift2ListView,shift2StComboBox);
        if (ishiftNum == 0 || ishiftNum == 3)
            model.loadDayLabourShift(splant, status,3, dayLabourShift3GroupBox,dayLabourShift3ListView,shift3StComboBox);
       
    }catch (Exception ex){
        MessageBox.Show("loadDayLabour Exception: " + ex.Message);
    } finally{
        enableDatesComboEvent(true);        
    }
    
}

private
void enableDatesComboEvent(bool bvalue){
    if (bvalue){ 
        shift1StComboBox.SelectionChanged+=shift1StComboBox_SelectionChanged;
        shift2StComboBox.SelectionChanged+=shift2StComboBox_SelectionChanged;
        shift3StComboBox.SelectionChanged+=shift3StComboBox_SelectionChanged;
        shiftAddStComboBox.SelectionChanged+=shiftAddStComboBox_SelectionChanged;    
        plantWeekComboBox.SelectionChanged+= plantWeekComboBox_SelectionChanged;                           
    }else{
        shift1StComboBox.SelectionChanged-= shift1StComboBox_SelectionChanged;
        shift2StComboBox.SelectionChanged-= shift2StComboBox_SelectionChanged;
        shift3StComboBox.SelectionChanged-= shift3StComboBox_SelectionChanged;
        shiftAddStComboBox.SelectionChanged-=shiftAddStComboBox_SelectionChanged;                
        plantWeekComboBox.SelectionChanged-= plantWeekComboBox_SelectionChanged;                           
    }
}

private 
void plantWeekComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e){    
    loadAddLabour();
}

private
void addWeekDtl(GroupBox groupBox,ListView listView){
    try{        
        this.capShiftProfile = (CapShiftProfile)groupBox.DataContext;
        this.editListView = listView;
        if (capShiftProfile!=null){                        
            baddingDtl = true;
            dtlsTabItem.DataContext = this.capShiftProfileDtl =model.getCoreFactory().createCapShiftProfileDtl();                 
            model.addTabItem(mainTabControl,dtlsTabItem,capShiftProfileDtl);
        }                           
    }catch (Exception ex){
        MessageBox.Show("addWeekDtl Exception: " + ex.Message);
    }   
}

private
void delWeekDtl(GroupBox groupBox,ListView listView){
    try{        
        this.capShiftProfile = (CapShiftProfile)groupBox.DataContext;
        delDtl(listView);                                   
    }catch (Exception ex){
        MessageBox.Show("delWeekDtl Exception: " + ex.Message);
    }   
}

private 
void shift1StComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e){    
    loadDayLabour(1);
}

private 
void shift2StComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e){    
    loadDayLabour(2);
}

private 
void shift3StComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e){
    loadDayLabour(3);
}

private 
void dayLabourShift1ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    editDoubleClick(dayLabourShift1GroupBox,dayLabourShift1ListView);    
}

private 
void dayLabourShift2ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
   editDoubleClick(dayLabourShift2GroupBox,dayLabourShift2ListView);    
}

private 
void dayLabourShift3ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    editDoubleClick(dayLabourShift3GroupBox,dayLabourShift3ListView);    
}
 
private 
void editDoubleClick(GroupBox groupBox,ListView  listView){
    try{        
        baddingDtl=false;
        editListView = listView;        
        capShiftProfile = (CapShiftProfile)groupBox.DataContext;
        capShiftProfileDtl =(CapShiftProfileDtl) model.getSelected(listView);
        model.addTabItem(mainTabControl,dtlsTabItem, capShiftProfileDtl);      
    }catch (Exception ex){
        MessageBox.Show("editDoubleClick Exception: " + ex.Message);
    }  
}

public 
void dateSelectionChanged(GroupBox groupBox,ListView listView,ComboBox dateCombo){
   try{        
        this.capShiftProfile = (CapShiftProfile)groupBox.DataContext;
        if (this.capShiftProfile!= null){
            CapShiftProfileContainer capShiftProfileContainer = model.getCoreFactory().readCapShiftProfileByExactlyDatesFilters(capShiftProfile.Plant, capShiftProfile.ShiftNum, Constants.STATUS_ACTIVE,capShiftProfile.StartDate, false,1);
            if (capShiftProfileContainer.Count > 0) {
                this.capShiftProfile = capShiftProfileContainer[0];
                groupBox.DataContext = capShiftProfile;
                model.setDataContextListView(listView,capShiftProfile.CapShiftProfileDtlContainer);    
            }    
        }
    }catch (Exception ex){
        MessageBox.Show("dateSelectionChanged Exception: " + ex.Message);
    }  
}

private
void showDtl(ListView listView, CapShiftProfile capShiftProfile,CapShiftProfileDtl capShiftProfileDtl){        
    try{
        if (listView != null) { 
            model.setDataContextListView(listView, capShiftProfile.CapShiftProfileDtlContainer);                                                    
            if (capShiftProfileDtl!=null)                    
                model.setSelected(listView, capShiftProfileDtl);
        }

    }catch (Exception ex){
        MessageBox.Show("showDtl Exception: " + ex.Message);
    } 
}

private 
void statusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e){
    loadDayLabour();
}

private 
void shiftAddStComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e){
    loadAddLabour();
}

private
void loadAddLabour(){
    try{
        addShiftsListView.SelectionChanged-= addShiftsListView_SelectionChanged;
        enableDatesComboEvent(false);                

        if (mainTabControl.SelectedItem != null && mainTabControl.SelectedItem.Equals(addTabItem)) {         
            string   splant = model.getSelectedComboBoxItemString(plantAddWeekComboBox);
            string   status = model.getSelectedComboBoxItemString(statusAddComboBox);
            
            model.loadAddLabourShift(splant,status,-1, addShiftsListView, addShiftsRListView, shiftAddStComboBox, shiftAddEndComboBox);

            capShiftProfile = (CapShiftProfile) model.getSelected(addShiftsListView);
            loadMachPlans();                          
        }
       
    }catch (Exception ex){
        MessageBox.Show("loadAddLabour Exception: " + ex.Message);
    } finally{
        enableDatesComboEvent(true);        
        addShiftsListView.SelectionChanged+= addShiftsListView_SelectionChanged;
    }
    
}

private 
void addASButton_Click(object sender, RoutedEventArgs e){
    enableDatesComboEvent(false);
    model.addNew(model.getSelectedComboBoxItemString(plantAddWeekComboBox),shiftAddStComboBox);
    enableDatesComboEvent(true);
}

private 
void delASButton_Click(object sender, RoutedEventArgs e){
    enableDatesComboEvent(false);
    model.delNew();
    enableDatesComboEvent(true);
}       
        
private
void addNewtl(ListView listView){
    try{        
        this.capShiftProfile = model.getCapShiftProfileSelected();
        this.editListView = listView;
        if (capShiftProfile!=null){                        
            baddingDtl = true;
            dtlsTabItem.DataContext = this.capShiftProfileDtl =model.getCoreFactory().createCapShiftProfileDtl();                 
            this.capShiftProfileDtl.ShiftNumShow = capShiftProfile.ShiftNum;
            model.addTabItem(mainTabControl,dtlsTabItem,capShiftProfileDtl);
        }                           
    }catch (Exception ex){
        MessageBox.Show("addWeekDtl Exception: " + ex.Message);
    }   
}       
        
private 
void addShiftsListView_SelectionChanged(object sender, SelectionChangedEventArgs e){
    addShiftsListViewSelectionChanged();
}      
        
private
void addShiftsListViewSelectionChanged(){
    try{        
        this.capShiftProfile = (CapShiftProfile)model.getSelected(addShiftsListView);
        addTopMainCanvas.DataContext = this.capShiftProfile;
        model.selectDtlBasedHdr(capShiftProfile);
        
        loadMachPlans();            
          
    }catch (Exception ex){
        MessageBox.Show("addShiftsListViewSelectionChanged Exception: " + ex.Message);
    }   
}                
 
private 
void addASRButton_Click(object sender, RoutedEventArgs e){       
    addNewtl(addShiftsListView);    
}               

private 
void delASRButton_Click(object sender, RoutedEventArgs e){    
    this.capShiftProfile= model.delDtlNew();
}        
        
private 
void addShiftsRListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    editDoubleClick();
}

private 
void editDoubleClick(){
    try{        
        baddingDtl=false;
        editListView = addShiftsRListView;        
        capShiftProfile = model.getCapShiftProfileSelectedDtl();
        if (capShiftProfile!= null) { 
            capShiftProfileDtl =(CapShiftProfileDtl) model.getSelected(addShiftsRListView);
            model.addTabItem(mainTabControl,dtlsTabItem, capShiftProfileDtl);      
        }
    }catch (Exception ex){
        MessageBox.Show("editDoubleClick Exception: " + ex.Message);
    }
}      

private 
void addMPButton_Click(object sender, RoutedEventArgs e){    
   addNewMachPlan();
}  

private 
void delMPButton_Click(object sender, RoutedEventArgs e){    
    delMP();
}

private
void delMP(){
    try{ 
        CapShiftProfileMachPlan capShiftProfileMachPlan = (CapShiftProfileMachPlan)model.getSelected(addMachPlanListView);                                                       
       
        if (model.delMachPlan(this.capShiftProfile,addMachPlanListView) && capShiftProfileMachPlan!= null && plannedPartSelected != null) 
            model.savePlannedPart(plannedHdrSelected,plannedPartSelected,capShiftProfile,capShiftProfileMachPlan,false);
    }catch (Exception ex){
        MessageBox.Show("delMP Exception: " + ex.Message);
    } 
}

private 
void machIdButton_Click(object sender, RoutedEventArgs e){    
   model.searchMachine((CapShiftProfileMachPlan)machPlanTabItem.DataContext); 
}  


private
void addNewMachPlan(){
    try{        
        this.capShiftProfile = model.getCapShiftProfileSelected();        
        if (capShiftProfile!=null){                        
            baddingDtl = true;
            machPlanTabItem.DataContext=null;
            machPlanTabItem.DataContext = this.capShiftProfileMachPlan = model.getCoreFactory().createCapShiftProfileMachPlan();                 
            this.capShiftProfileMachPlan.Date = capShiftProfile.StartDate.AddDays(5);//saturday same week
            this.capShiftProfileMachPlan.ShiftNumShow = capShiftProfile.ShiftNum;

            //if planned part selected, we point to properly machine
            PlannedReq plannedReq = model.getPlannedReqSelected(plannedHdrSelected,plannedPartSelected,capShiftProfile);
            if (plannedReq!= null)
                model.loadMachineInfo(capShiftProfileMachPlan,null,plannedReq.ReqID);                       

            model.loadMachPlan(capShiftProfileMachPlan,dateMachPlanComboBox);
            model.addTabItem(mainTabControl, machPlanTabItem, capShiftProfileMachPlan);
        }                           
    }catch (Exception ex){
        MessageBox.Show("addNewMachPlan Exception: " + ex.Message);
    }   
} 
        
private
bool dataOkMachPlan(){
    bool bresult=true;
    try{        
        capShiftProfileMachPlan  = (CapShiftProfileMachPlan)this.machPlanTabItem.DataContext;
        Machine     machine=null;
               
        if (capShiftProfile!=null && capShiftProfileMachPlan != null){
            
            if (capShiftProfileMachPlan.MachId > 0)
                machine = model.getCoreFactory().readMachineById(capShiftProfileMachPlan.MachId);

            if (machine == null){
                MessageBox.Show("Please, Select Shift Machine.");                
                bresult=false;
            }else if (baddingDtl){                        
                CapShiftProfileMachPlan capShiftProfileMachPlanAux = capShiftProfile.CapShiftProfileMachPlanContainer.getByMachineDate(capShiftProfileMachPlan.MachId, capShiftProfileMachPlan.Date);
                if (capShiftProfileMachPlanAux != null){
                    MessageBox.Show("Sorry, Machine "+ capShiftProfileMachPlan.MachShow + "(" + capShiftProfileMachPlan.MachId + ")"  + " And Date " + DateUtil.getDateRepresentation(capShiftProfileMachPlan.Date, DateUtil.MMDDYYYY) + "\n Already Added, Please Select Other.");
                    bresult=false;
                }
            }    

            if (bresult) {              
            }                  
        }else
            bresult=false;
 
        
    }catch (Exception ex){
        MessageBox.Show("dataOkMachPlan Exception: " + ex.Message);
        bresult=false;
    }    
    return bresult;
}
      
private
void okMachPlan(){
    try{
        capShiftProfileMachPlan  = (CapShiftProfileMachPlan)this.machPlanTabItem.DataContext;
        CapShiftProfileMachPlan capShiftProfileMachPlanModified = null;
        
        if (dataOkMachPlan()){
            
            if (baddingDtl) { 
                capShiftProfile.CapShiftProfileMachPlanContainer.Add(capShiftProfileMachPlan);
            }else{
                //update, so modify original object
                capShiftProfileMachPlanModified = capShiftProfile.CapShiftProfileMachPlanContainer.getByKey(capShiftProfileMachPlan.HdrId, capShiftProfileMachPlan.Detail);
                if (capShiftProfileMachPlanModified != null)
                    capShiftProfileMachPlanModified.copy(capShiftProfileMachPlan);         
                
                capShiftProfileMachPlan= capShiftProfileMachPlanModified;
            } 

            capShiftProfile.fillRedundances();
            this.baddingDtl = false;       
            model.save(capShiftProfile);    
            if (plannedHdrSelected!= null)  //check if need to store link to CapShiftProfileMachPlan
                model.savePlannedPart(plannedHdrSelected,plannedPartSelected,capShiftProfile,capShiftProfileMachPlan,true);

            model.removeTabItem(mainTabControl,this.machPlanTabItem);            
        }
 
    }catch (Exception ex){
        MessageBox.Show("okDtls Exception: " + ex.Message);
    }    
}


private 
void okMachPlanButton_Click(object sender, RoutedEventArgs e){    
   okMachPlan();
}

private 
void cancelMachPlanButton_Click(object sender, RoutedEventArgs e){    
    cancelMachPlan();
}
        
private
void cancelMachPlan(){
    try{
        model.removeTabItem(mainTabControl,this.machPlanTabItem);
        mainTabControl.SelectedItem = dayLabourTabItem;
    }catch (Exception ex){
        MessageBox.Show("cancelMachPlan Exception: " + ex.Message);
    } 
    
}
              
private 
void addMachPlanListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    editMPDoubleClick();
}

private
void loadMachPlans(){
    if (capShiftProfile!= null) {           
        model.setDataContextListView(addMachPlanListView,capShiftProfile.CapShiftProfileMachPlanContainer);
        model.setSelected(addMachPlanListView,capShiftProfileMachPlan);
        model.loadMachPlanEmployee(capShiftProfile);        
        model.loadMachPlanEmployee(capShiftProfile);
    }  
}

private 
void editMPDoubleClick(){
    try{        
        baddingDtl=false;        
        capShiftProfile = model.getCapShiftProfileSelectedDtl();
        if (capShiftProfile!= null) {
            capShiftProfileMachPlan = (CapShiftProfileMachPlan) model.getSelected(addMachPlanListView);
            model.loadMachPlan(capShiftProfileMachPlan,dateMachPlanComboBox);
            model.addTabItem(mainTabControl,machPlanTabItem, capShiftProfileMachPlan);      
        }
    }catch (Exception ex){
        MessageBox.Show("editMPDoubleClick Exception: " + ex.Message);
    }
}                               
        
           
private 
void addMachPlanTabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e){
    addMachPlanTabControlSelectionChanged();
}

private 
void addMachPlanTabControlSelectionChanged(){
    try {
        int indexSel    = addMachPlanTabControl.SelectedIndex;
        int ipriorIndex = itabIndex;
                
        if (indexSel != itabMaxPlanIndex){
            this.itabMaxPlanIndex = indexSel;                       
            if (indexSel == 0){
                model.loadEmployeesByShiftProfile(capShiftProfile);
            }else if (indexSel == 1){                
                
            }else if (indexSel == 2){                
                model.loadMachPlanEmployee(capShiftProfile);
            } 
        }
                 
    } catch (Exception ex) {        
        MessageBox.Show("addMachPlanTabControlSelectionChanged Exception: " + ex.Message);  
    }
}    

private 
void addMPEButton_Click(object sender, RoutedEventArgs e){
    model.addMachPlanEmployee(capShiftProfile);
}

private 
void delMPEButton_Click(object sender, RoutedEventArgs e){
    model.delMachPlanEmployee(capShiftProfile);
}

private 
void addMPEMPButtonButton_Click(object sender, RoutedEventArgs e){
    
}

private 
void delMPEMPButtonMPButton_Click(object sender, RoutedEventArgs e){    

}
                                                                                   
}
}
