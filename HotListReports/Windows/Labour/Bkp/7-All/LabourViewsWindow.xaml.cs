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

namespace HotListReports.Windows.Labour{
/// <summary>
/// Interaction logic for LabourViewsWindow.xaml
/// </summary>
public partial 
class LabourViewsWindow : Window{

private LabourViewsModel model;
private int itabIndex;
private ButtonsListViewFunctions buttonsListViewFunctions;

public 
LabourViewsWindow(){
    InitializeComponent();

    this.model = new LabourViewsModel(this, labourPlanningListView);
    this.itabIndex = 0;
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
        buttonsListViewFunctions = new ButtonsListViewFunctions(this.labourListView,firstButton,prevButton,nextButton,lastButton);
        //model.loadSearchByCombo(searchByComboBox);
        model.loadPlantCombo(plantComboBox,false); model.setSelectedComboBoxItem(plantComboBox,Configuration.DftPlant);                
        checkIncludeProductionVisibility();

        model.screenFullArea();        

        search();        
    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }finally{        
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
            checkIncludeProductionVisibility();
            search();                   
        }
                 
    } catch (Exception ex) {
        MessageBox.Show(ex.Message);
    }
}

private
void checkIncludeProductionVisibility(){
    includeProductionCheckBox.Visibility = itabIndex == 1 ? Visibility.Visible : Visibility.Hidden;
}

private 
void plantComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
    try{        
        model.plantComboBoxSelectionChanged(plantComboBox,deptComboBox);        
    }finally{
        deptComboBox.SelectionChanged+= deptComboBox_SelectionChanged;        
    }
}

private 
void deptComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {            
    try{     
        model.deptComboBoxSelectionChanged(plantComboBox,deptComboBox,machineComboBox);        
    }finally{        
    }
}
    
    
private 
void searchButton_Click(object sender, RoutedEventArgs e){
    search();
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
        string      smachineAux = model.getSelectedComboBoxItemString(machineComboBox);
        string      smachineDesc= searchByComboBox.SelectedIndex == 1 && !string.IsNullOrEmpty(searchForTextBox.Text) ? searchForTextBox.Text + "%" : "";
        string      spart       = partTextBox.Text;        
        ListView    listView    = labourListView;
        CapacityViewContainer capacityViewContainer=null;
        CapacityHdr capacityHdr = model.getCoreFactory().readCapacityHdrLast(splant,true);
        int         icapacityHdr = capacityHdr!= null ? capacityHdr.Id : 0;        
        int         imachineId=0;

        if (!string.IsNullOrEmpty(smachine))
            smachine+="%";
        if (!string.IsNullOrEmpty(spart))
            spart+="%";

        if (!string.IsNullOrEmpty(smachineAux))
            imachineId = Convert.ToInt32(smachineAux);

        if (mainTabControl.SelectedItem.Equals(labourTabItem)){                              
            model.loadColumnsOnHeaderView3Grid(labourListView, true);        
            capacityViewContainer = model.getCoreFactory().processCapacityReportGroupByReqTypeDept(icapacityHdr,splant,sdept,smachine, imachineId, CapacityReq.REQUIREMENT_LABOUR,spart, DateUtil.MinValue, CapacityView.SORT_TYPE.DEPT_REQUIRMENT);
            listView = labourListView;
            model.loadValuesOnViewByReqType(listView, icapacityHdr, capacityViewContainer, 0, CapacityView.SORT_TYPE.DEPT_REQUIRMENT, CapacityView.GENERIC_SHOW_TYPE.ALL);         

        } if (mainTabControl.SelectedItem.Equals(labourPlanningTabItem)){
            listView = labourPlanningListView;            
            LabourPlanningReportViewContainer labourPlanningReportViewContainer = model.loadLabourTypePlanning(labourPlanningListView, labourPlanningTabItem,splant,sdept,smachine,imachineId,spart, DateUtil.MinValue);                     
            if ((bool)includeProductionCheckBox.IsChecked)
                model.loadProduction();

            model.createTopGrid(mainStack, labourPlanningReportViewContainer.Count > 0? labourPlanningReportViewContainer[0]:null);
            //model.loadColumnsOnShiftListView(shiftListView,false);
            //MachineReportViewContainer machineReportViewContainer = model.loadCapacityByShifts(shiftListView, capacityHdr!= null? capacityHdr.Plant:splant, capacityHdr!= null? capacityHdr.Id:0, model.CapacityViewContainer,model.HashPrHistSum,false);
        }

        buttonsListViewFunctions = new ButtonsListViewFunctions(listView,firstButton,prevButton,nextButton,lastButton);
        timeLabel.Content = model.ProcessEndAndTex(listView.Items.Count);

    } catch (Exception ex) {
       MessageBox.Show("search Exception: " + ex.Message); 
    }finally {        
        this.Cursor = cursor;    
    }            
}  

private 
void includeProductionCheckBox_Click(object sender, RoutedEventArgs e){
    search(); 
}

private 
void labourPlanningListView_SelectionChanged(object sender, SelectionChangedEventArgs e){
    labourPlanningListViewSelectionChanged();
}

private 
void labourPlanningListViewSelectionChanged(){
    try {
        LabourPlanningReportView labourPlanningReportView = (LabourPlanningReportView)model.getSelected(labourPlanningListView);
        model.createTopGrid(mainStack,labourPlanningReportView);                        
    } catch (Exception ex) {
        MessageBox.Show(ex.Message);
    }
}

}
}
