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

using Nujit.NujitERP.ClassLib.Core.CapacityDemand;
using Nujit.NujitERP.ClassLib.Core.ScheduleDemand;
using Nujit.NujitWms.WinForms.Util.Grids;
using Nujit.NujitWms.WinForms.Util.Converters;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using System.Collections.ObjectModel;
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Common;
using HotListReports.Windows.Labour;
using HotListReports.Windows.Demand;
using Nujit.NujitERP.ClassLib.Util;

namespace HotListReports.Windows.Schedule{
/// <summary>
/// Interaction logic for AddDownWindow.xaml
/// </summary>
public partial class AddDownWindow : Window{

private ScheduleHdModel model;
private bool            baddingDtl;
private ScheduleReq     scheduleReq;
private ScheduleDown    scheduleDown;

public AddDownWindow(ScheduleReq scheduleReq,ScheduleDown scheduleDown){
    InitializeComponent();

    this.model          = new ScheduleHdModel(this);
    this.baddingDtl     = scheduleDown.HdrId <= 0;
    this.scheduleReq    = scheduleReq;
    this.scheduleDown=   scheduleDown;
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){
    initialize();
}

private 
void initialize(){        
    try {                
        //down
        model.loadDownType(downComboBox);
        model.loadDownTypeNames(downTypeComboBox);
        model.loadShiftNumComboBox(this.downShiftComboBox,Constants.MAX_SHIFTS,false);   

        this.DataContext = scheduleDown;
                
    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }
}


private
void modifyDown(ScheduleDown scheduleDown){
    try{
        this.baddingDtl = false;              
        loadDown(model.cloneToModifyDown(scheduleDown));        
    }catch (Exception ex){
        MessageBox.Show("modifyDown Exception: " + ex.Message);
    }    

} 

private 
void addDown(){    
    try{                
        if (scheduleReq != null){                                   
            model.ScheduleReqActive = scheduleReq;       
                                 
            this.baddingDtl = true;                                                                                
            loadDown(model.createDown(scheduleReq));                
        }                                         
    }catch (Exception ex){
        MessageBox.Show("addDown Exception: " + ex.Message);
    }                       
}


private
void loadDown(ScheduleDown scheduleDown){    
    try{       
       // addShiftDownTabItem(scheduleDown);            
        //tasksShiftComboBox.DataContext=scheduleDown;                                 
    }catch (Exception ex){
        MessageBox.Show("loadDown Exception: " + ex.Message);
    }                       
}
        
private 
bool dataOkDown(){    
    bool            bresult=true;
             
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
        if (scheduleReq != null && scheduleDown != null && dataOkDown()){                  
            if (baddingDtl){                
                scheduleReq.ScheduleDownContainer.Add(scheduleDown);                                     
            }else//update so copy info from clone to original
               model.copyDown(scheduleReq, scheduleDown);                
                           
            DialogResult = true;
            Close();                                                     
            //saveLoad(baddingDtl,scheduleReq, null,null,scheduleDown);                                 
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
        if (scheduleDown != null)
            scheduleDown.Hours = scheduleDown.TotEmployees * scheduleDown.EmployeeHours;
    }catch (Exception ex){
        MessageBox.Show("calcDownLabourHours Exception: " + ex.Message);
    } 
}
/*
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
*/

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
        DialogResult = false;
        Close();        
    }
}


}
}
