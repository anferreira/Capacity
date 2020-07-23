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
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;
using HotListReports.Windows.Util;
using HotListReports.Windows.Labour;
using Nujit.NujitERP.ClassLib.Core.Machines;
using Nujit.NujitERP.ClassLib.Core.Planned;

namespace HotListReports.Windows.Machines{

/// <summary>
/// Interaction logic for MachineViewWindow.xaml
/// </summary>
public partial 
class MachineViewsWindow : Window{

private MachineViewsModel model;
private LabourViewsModel labourViewsModel;
private ButtonsListViewFunctions buttonsListViewFunctions;
private int itabIndex;
private Machine machineFilter;

public 
MachineViewsWindow(Machine machine){
    InitializeComponent();

    this.model = new MachineViewsModel(this,machineShiftListView,machinePartsListView);
    this.labourViewsModel = new LabourViewsModel(this,labourPlanningListView);   

    this.itabIndex = 0;
    this.machineFilter = machine != null ? model.getCoreFactory().readMachineById(machine.Id): null;    
    this.labourViewsModel.Machine = machineFilter;
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
        buttonsListViewFunctions = new ButtonsListViewFunctions(this.machineListView,firstButton,prevButton,nextButton,lastButton);
        model.loadSearchByCombo(searchByComboBox);
        model.loadPlantCombo(plantComboBox,false);        
        
        machineListView.GroupStyle.Add(model.generateListViewGroupStyle("Name",18,UIColors.COLOR_SELECT,Colors.Silver,12,2,1));
        model.loadColumnsOnMachineListView(machineListView);
        applyFilter();      

        //shift/planning        
        model.loadColumnsOnShiftListView(machineShiftListView,true);
        ContextMenuListViewFunctions contextMenuListView = model.addContextMenuListViewFunctions(machineShiftListView);
        model.addContextMenuItem(Constants.OPTIONS_MACHINE_DEFAULT);
        model.addContextMenuItem(Constants.OPTIONS_CAPACITY_MACHPRIORITY);        
        contextMenuListView.contextMenuListViewEventHandler += new ContextMenuListViewEventHandler(contextMenuListViewEventHandlerEvent);
 

        model.screenFullArea();        

        search();        
    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }finally{        
    }
}

public 
void applyFilter(){    
    try{        
        if (machineFilter != null){
            model.setSelectedComboBoxItem(plantComboBox, machineFilter.Plt);
            model.setSelectedComboBoxItem(deptComboBox, machineFilter.Dept);
            if (searchByComboBox.Items.Count > 0)
                searchByComboBox.SelectedIndex =0;
            searchForTextBox.Text = machineFilter.Mach;
        }else
            model.setSelectedComboBoxItem(plantComboBox,Configuration.DftPlant);
    }catch (Exception ex){
        MessageBox.Show("applyFilter Exception: " + ex.Message);
    }                                        
}  
        
private
void contextMenuListViewEventHandlerEvent(object sender, string optionSelected){
    Machine machine = model.Machine;

    switch (optionSelected){        
        case Nujit.NujitWms.ClassLib.Common.Constants.OPTION_CANCEL:
            model.close();                                
            break;
        case Nujit.NujitWms.ClassLib.Common.Constants.OPTION_REFRESH:
            search();
            break;        
        case Constants.OPTIONS_MACHINE_DEFAULT:
            machineDefault();
            break;        
        case Constants.OPTIONS_CAPACITY_MACHPRIORITY:
            machinePriority();
            break;        
    }
}

private 
void plantComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
   model.plantComboBoxSelectionChanged(plantComboBox,deptComboBox);
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
            autoPlanButton.Visibility = clearPlanButton.Visibility = mainTabControl.SelectedItem!= null && (mainTabControl.SelectedItem.Equals(machineShiftPlanTabItem) || mainTabControl.SelectedItem.Equals(machinePartsTabItem)) ? Visibility.Visible : Visibility.Hidden;
            search();                   
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
void machAlternativeButton_Click(object sender, RoutedEventArgs e){    
    machAlternative();
}

private 
void search(){    
     Cursor cursor = this.Cursor;
    try {        
        model.ProcessStart();
        this.Cursor = System.Windows.Input.Cursors.Wait;        
        string      splant      = model.getSelectedComboBoxItemString(plantComboBox);
        string      sdept       = model.getSelectedComboBoxItemString(deptComboBox);
        string      smachine    = searchByComboBox.SelectedIndex == 0 && !string.IsNullOrEmpty(searchForTextBox.Text) ? searchForTextBox.Text : "";        
        string      smachineDesc= searchByComboBox.SelectedIndex == 1 && !string.IsNullOrEmpty(searchForTextBox.Text) ? searchForTextBox.Text + "%" : "";
        string      spart       = partTextBox.Text;
        int         imachineId  = machineFilter != null ? machineFilter.Id : 0;
        ListView    listView    = machineListView;
        CapacityHdr capacityHdr = model.getCoreFactory().readCapacityHdrLast(splant,true);
        HotListHdr  hotListHdr  = null;
        MachineReportViewContainer machineReportViewContainer = model.getCoreFactory().createMachineReportViewContainer();
        MachineContainer        machineContainer = model.getCoreFactory().createMachineContainer();
        RoutingContainer        routingContainer = model.getCoreFactory().createRoutingContainer();
        Machine                 machine= null;

        if (capacityHdr==null)
            return;
        model.CapacityHdr = capacityHdr;

        if (machineFilter == null && !string.IsNullOrEmpty(smachine))
            smachine+="%";
        if (!string.IsNullOrEmpty(spart))
            spart+="%";
        
        machine = model.getMachineByFilters(smachine,"",out routingContainer,splant,sdept,"");            
        if (machine!= null) { 
            imachineId  = machine != null ? machine.Id : 0;

            splant= machine.Plt;
            sdept = machine.Dept;
            smachine = machine.Mach;
        }
        this.labourViewsModel.Machine = machine;
        this.model.Machine = machine;
        
        if (mainTabControl.SelectedItem.Equals(machineShiftPlanTabItem)){                                               
            listView = planningListView;                                                    
            machineReportViewContainer = model.loadMachineParts(listView, machineShiftPlanTabItem, capacityHdr, splant,sdept, smachine, smachineDesc,spart, DateUtil.MinValue,(bool)includeProductionCheckBox.IsChecked,(bool)includeZeroQtyCheckBox.IsChecked,(bool)includePlannedCheckBox.IsChecked);
    
            //top grid , shifts info available capaciry and planned
            model.CapacityViewContainer= model.getCoreFactory().createCapacityViewContainer();
            machineReportViewContainer = model.loadCapacityByShifts(machineShiftListView, capacityHdr!= null? capacityHdr.Plant:splant, capacityHdr!= null? capacityHdr.Id:0, model.CapacityViewContainer,model.HashPrHistSum,true);

        }if (mainTabControl.SelectedItem.Equals(machineTabItem)){
            listView = machineListView;    
            machineReportViewContainer = model.loadMachine(machineListView, machineTabItem,machine,routingContainer,capacityHdr, splant,sdept, smachine, smachineDesc, spart, DateUtil.MinValue);                    

        } else if (mainTabControl.SelectedItem.Equals(machinePartsTabItem)){
            listView = machinePartsListView;                                                    
            machineReportViewContainer = model.loadMachineParts(machinePartsListView, machinePartsTabItem, capacityHdr, splant,sdept, smachine, smachineDesc,spart, DateUtil.MinValue,(bool)includeProductionCheckBox.IsChecked,(bool)includeZeroQtyCheckBox.IsChecked,(bool)includePlannedCheckBox.IsChecked);

        }  if (mainTabControl.SelectedItem.Equals(labourPlanningTabItem)){
            listView = labourPlanningListView;
            LabourPlanningReportViewContainer labourPlanningReportViewContainer =  this.labourViewsModel.loadLabourTypePlanning(out hotListHdr,labourPlanningListView, labourPlanningTabItem,splant,sdept,smachine,imachineId,spart, DateUtil.MinValue);                        
        }
        
        buttonsListViewFunctions = new ButtonsListViewFunctions(listView,firstButton,prevButton,nextButton,lastButton);
        timeLabel.Content = model.ProcessEndAndTex(listView.Items.Count);

    } catch (Exception ex) {
       MessageBox.Show("search Exception: " + ex.Message); 
    }finally {        
        machineFilter = null;
        this.Cursor = cursor;    
    }            
}  

private 
void machAlternative(){    
    try {
        ListView                listView = null;

        if (mainTabControl.SelectedItem != null && mainTabControl.SelectedItem.Equals(machineShiftPlanTabItem))
            listView = planningListView;
        if (mainTabControl.SelectedItem != null && mainTabControl.SelectedItem.Equals(machinePartsTabItem))
            listView = machinePartsListView;
        if (listView==null)
            MessageBox.Show("Please, Select Item First.");
        else { 
            Object                  obj=  (Object)model.getSelected(listView);
            CellMachinePart         cellSelected = model.getCellMachinePartSelected();
            MachineReportPartView   machineReportPartView = (MachineReportPartView)model.getSelected(listView);
            
            if (machineReportPartView!= null) { 
                if (model.alternativeMachinePlanned(machineReportPartView, cellSelected)) { 
                    search();
                    model.setSelected(listView, machineReportPartView);//try to select cell recently updated
                }
            }else
                MessageBox.Show("Please, Select Item First.");
        }

    } catch (Exception ex) {
        MessageBox.Show(ex.Message);
    }
}

private 
void machineDefButton_Click(object sender, RoutedEventArgs e){    
    machineDefault();
}

private 
void machPriorityButton_Click(object sender, RoutedEventArgs e){    
    machinePriority();
}

private 
void machineDefault(){    
    try{
        Machine machine = model.Machine;    
        if (machine!= null) { 
            model.navigateMachine(false,machine.Plt,machine);

            reloadMachineAfterNavigate(machine);
        }

    }catch (Exception ex){
        MessageBox.Show("machineDefault Exception: " + ex.Message);
    } 
}

private 
void reloadMachineAfterNavigate(Machine machine){    
    try{
        if (machine!= null) { 
            model.Machine = model.getCoreFactory().readMachine(machine.Plt, machine.Dept, machine.Mach);  
            this.machineFilter = model.Machine;
            applyFilter();
            search();
        }

    }catch (Exception ex){
        MessageBox.Show("reloadMachineAfterNavigate Exception: " + ex.Message);
    } 
}

private 
void machinePriority(){    
    try{
        Machine     machine = model.Machine;    
        string      splant  = model.getSelectedComboBoxItemString(plantComboBox);

        if (machine!= null) {            
            model.navigateCapacity(splant, machine);     
            reloadMachineAfterNavigate(machine);
        }

    }catch (Exception ex){
        MessageBox.Show("machineDefault Exception: " + ex.Message);
    } 
}

private 
void autoPlanButton_Click(object sender, RoutedEventArgs e){
    automaticPlanned();
}

private 
void clearPlanButton_Click(object sender, RoutedEventArgs e){
    clearPlanned();
}
       
private 
void automaticPlanned(){    
    try{
        model.ProcessStart();
        string  splant  = model.getPlant();
        model.automaticPlanned(splant);
        search();

        timeLabel.Content = model.ProcessEndAndTex(0);
        MessageBox.Show("Automatic Planned Creation Finished.");

    } catch (Exception ex) {
       MessageBox.Show("automaticPlanned Exception: " + ex.Message); 
    }
}

private 
void clearPlanned(){    
    try{
        model.ProcessStart();
        string  splant  = model.getPlant();
        model.clearPlanned(splant);
        search();

        timeLabel.Content = model.ProcessEndAndTex(0);
        MessageBox.Show("Automatic Planned Clear Finished.");

    } catch (Exception ex) {
       MessageBox.Show("clearPlanned Exception: " + ex.Message); 
    }
}

private 
void includeProductionCheckBox_Click(object sender, RoutedEventArgs e){
    search();
}

private 
void includeZeroQtyCheckBox_Click(object sender, RoutedEventArgs e){
    if (isMachinePartsTab())
        search();
}

private 
void includePlannedCheckBox_Click(object sender, RoutedEventArgs e){
    if (isMachinePartsTab())
        search();
}

private
bool isMachinePartsTab(){
    bool bisMachinePartsTab=false;
    if (itabIndex==0 || itabIndex == 2)
        bisMachinePartsTab=true;
    return bisMachinePartsTab;
}

private 
void moveQtyChangeButton_Click(object sender, RoutedEventArgs e){    
    if (isMachinePartsTab())
        model.moveQtyChange();
}

private 
void addOTShiftButton_Click(object sender, RoutedEventArgs e){    
    if (isMachinePartsTab())
        model.addOTShift();
}

}
}
