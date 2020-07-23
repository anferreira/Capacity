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
using System.Collections;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core.ScheduleDemand;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;
using Nujit.NujitERP.ClassLib.Core.Machines;

namespace HotListReports.Windows.Demand{

public partial 
class CapSelMachineWindow : Window{


private CapacitySelMachineModel capacitySelMachineModel;
private int icapacityHdrId;
private CapacityViewContainer capacityViewContainer;
private MachineContainer machineContainer;
private ArrayList arrayWeekList;
private ScheduleHdrContainer scheduleHdrContainer;

private DateTime startDate;
private DateTime endDate;


public
CapSelMachineWindow(int icapacityHdrId,CapacityViewContainer capacityViewContainer, MachineContainer machineContainer,ArrayList arrayWeekList){
    InitializeComponent();

    this.capacitySelMachineModel = new CapacitySelMachineModel(this);
    this.icapacityHdrId = icapacityHdrId;
    this.capacityViewContainer = capacityViewContainer;
    this.machineContainer = machineContainer;
    this.arrayWeekList = arrayWeekList;
    this.scheduleHdrContainer = capacitySelMachineModel.getCoreFactory().createScheduleHdrContainer();

    this.startDate = this.endDate = DateUtil.MinValue;
}

public
MachineContainer MachineContainer {
	get {
        machineContainer = (MachineContainer)machineListView.DataContext; //current machines selected
        return machineContainer;
    }
	set { if (this.machineContainer != value){
			this.machineContainer = value;			
		}
	}
}

public
DateTime getStartDate() {
	return startDate;
}

public
DateTime getEndDate() {
	return endDate;
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
        MachineContainer  machineContainerAux = capacitySelMachineModel.createMachineSelList(machineContainer);
        machineContainer = machineContainerAux;
        capacitySelMachineModel.loadColumnsOnHeaderGrid(this.machineListView);

        capacitySelMachineModel.loadWeekCombos(startDateComboBox,endtDateComboBox,this.arrayWeekList);
       
        scheduleHdrContainer = capacitySelMachineModel.getCoreFactory().readScheduleHdrByFilters("","","",icapacityHdrId,0,DateUtil.MinValue,DateUtil.MinValue,false,-1);
        checkIfMachinesAlreadyScheduled(scheduleHdrContainer);
        //capacitySelMachineModel.loadMachineView(machineListView,machineContainer);

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }
}

private 
void checkIfMachinesAlreadyScheduled(ScheduleHdrContainer scheduleHdrContainer){
    try{
        SchedulePart schedulePart = null;
        for (int i=0; i < machineContainer.Count;i++){
            MachineSel machineSel =(MachineSel)machineContainer[i];
        
            schedulePart = scheduleHdrContainer.getScheduleReqByCapacity(machineSel.Id,this.icapacityHdrId);            
            if (schedulePart != null)
                machineSel.IsChecked = false;
        }
        
    } catch (Exception ex) {
        MessageBox.Show("checkIfMachinesAlreadyScheduled Exception: " + ex.Message);        
    }
}


private 
void okButton_Click(object sender, RoutedEventArgs e){
    ok();
}

private 
void cancelButton_Click(object sender, RoutedEventArgs e){
    ok();
}


private 
void ok(){
    if (dataOK()){
        this.DialogResult = true;
        Close();
    }
}
    
private 
void cancel(){
    this.DialogResult = false;
    Close();
}

private 
void selAllButton_Click(object sender, RoutedEventArgs e){
    capacitySelMachineModel.selUnSellList(machineListView,true);
}

private 
void cancelAllButton_Click(object sender, RoutedEventArgs e){
    capacitySelMachineModel.selUnSellList(machineListView,false);
}
        
private
bool dataOK(){ 
    bool        bresult=true;

    capacitySelMachineModel.getDatesSelected(startDateComboBox,endtDateComboBox,out startDate,out endDate);            

    if (startDate == DateUtil.MinValue){
        MessageBox.Show("Please, Select Start Date");
        bresult=false;
    }

    if (endDate == DateUtil.MinValue){
        MessageBox.Show("Please, Select End Date");
        bresult= false;
    }

    if (bresult && startDate > endDate){
        MessageBox.Show("Please, Reenter End Date, Might Be Bigger Than Start Date.");
        bresult= false;
    }
            
    return bresult;                    
}

private
void loadMachinesBasedOnDatesSelected(){
    try{
        MachineContainer machineContainerAux = capacitySelMachineModel.getCoreFactory().createMachineContainer();

        capacitySelMachineModel.getDatesSelected(startDateComboBox,endtDateComboBox,out startDate,out endDate);
        machineContainerAux = capacitySelMachineModel.loadMachinesBasedOnDatesSelected(machineContainer,icapacityHdrId ,startDate, endDate);        
        capacitySelMachineModel.loadMachineView(machineListView, machineContainerAux);//reload grid

    } catch (Exception ex) {
        MessageBox.Show("loadMachinesBasedOnDatesSelected Exception: " + ex.Message);        
    }
}

private 
void startDateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e){
    capacitySelMachineModel.syncBasedOnStartDate(startDateComboBox,endtDateComboBox);
    loadMachinesBasedOnDatesSelected();
}

private 
void endtDateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e){
    capacitySelMachineModel.syncBasedOnEndDate(startDateComboBox,endtDateComboBox);
    loadMachinesBasedOnDatesSelected();
}

}
}
