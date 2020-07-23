using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
/// Interaction logic for MachineAlterPlanWindow.xaml
/// </summary>
public partial 
class MachineAlterPlanWindow : Window{

Machine                 mainMachine;
MachineAlterPlanModel   model;
MachineReportPartView   machineReportPartViewOriginal;
MachineReportPartView   machineReportPartView;
CellMachinePart         cellSelected;
RoutingContainer        routingContainer;
PlannedHdr              plannedHdr;
string                  splant;

public MachineAlterPlanWindow(PlannedHdr plannedHdr,string splant,Machine mainMachine, MachineReportPartView machineReportPartViewOriginal, CellMachinePart cellSelected, RoutingContainer routingContainer){
    InitializeComponent();

    this.plannedHdr = plannedHdr;
    this.splant = splant;
    this.mainMachine = mainMachine;
    this.model = new MachineAlterPlanModel(this, alterMachineComboBox,weekComboBox,plannedHdr, mainMachine,machineReportPartViewOriginal);
    this.machineReportPartViewOriginal = machineReportPartViewOriginal;
    this.machineReportPartView = model.getCoreFactory().cloneMachineReportPartView(machineReportPartViewOriginal);
    this.cellSelected = cellSelected;
    this.routingContainer = routingContainer;
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){    
    initialize();
}

private 
void initialize(){        
    try {                            
        model.loadRoutingComboBox(alterMachineComboBox,routingContainer);
        model.loadWeeksComboBox(this.weekComboBox,machineReportPartView);
        if (cellSelected!= null && this.weekComboBox.Items.Count > cellSelected.XIndex) //try to selected date before selected
            this.weekComboBox.SelectedIndex = cellSelected.XIndex;

        this.topCanvas.DataContext = machineReportPartView;

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }finally{        
    }
}

private 
void alterMachine_SelectionChanged(object sender, SelectionChangedEventArgs e){
   machineReportPartView = model.machineChanged();
}

private 
void weekComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e){
    weekComboBoxSelectionChanged();
}

private 
void weekComboBoxSelectionChanged(){
    CellMachinePart cellMachinePart = (CellMachinePart)model.getSelectedComboBoxItem(this.weekComboBox);
    dtlCanvas.DataContext = cellMachinePart;    
}
      
private 
void okButton_Click(object sender, RoutedEventArgs e){
   save();
}

private 
void save(){
    if (model.save(plannedHdr,splant,machineReportPartView, (CellMachinePart)dtlCanvas.DataContext)) {
        DialogResult = true;
        Close();
    }
}

private 
void cancelButton_Click(object sender, RoutedEventArgs e){
    cancel();
}  

private 
void cancel(){
    if (model.cancel()){
        DialogResult = false;
        Close();
    } 
}  

private 
void plannedCurrTextBox_SelectionChanged(object sender, RoutedEventArgs e){
    model.plannedCurrTextBoxSelectionChanged(plannedCurrTextBox,machineReportPartView);
}
   

}
}
