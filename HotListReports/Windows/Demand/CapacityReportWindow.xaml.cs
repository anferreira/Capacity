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
using Nujit.NujitERP.ClassLib.Core.ScheduleDemand;
using Nujit.NujitERP.ClassLib.Core.Machines;


namespace HotListReports.Windows.Demand{


/// <summary>
/// Interaction logic for CapacityReportWindow.xaml
/// </summary>
public partial class CapacityReportWindow : Window{

private CapacityReportModel model;
private ButtonsListViewFunctions buttonsListViewFunctions;
private CapacityHdr capacityHdr;
private int icapacityHdr;
private int itabIndex;
private bool  bradioButtonIsEnable=false;
private CapacityViewContainer capacityViewContainerSearch;
private HotListViewContainer hotListViewMachineContainer;
private HotListViewContainer hotListViewContainer;

        
public class CumulaticePercent {
    public decimal CumPercent { get; set; }    
}

public CapacityReportWindow(CapacityHdr capacityHdr){
    InitializeComponent();

    this.model = new CapacityReportModel(this,capacityHdr,labourPlanningListView);
    this.capacityViewContainerSearch = model.getCoreFactory().createCapacityViewContainer();
    this.hotListViewMachineContainer = model.getCoreFactory().createHotListViewContainer();
    this.hotListViewContainer = model.getCoreFactory().createHotListViewContainer();
    this.capacityHdr = capacityHdr;
    this.icapacityHdr = capacityHdr.Id;
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
        cumulativePercentTextBox.Text="0";
        buttonsListViewFunctions = new ButtonsListViewFunctions(this.mainListView,firstButton,prevButton,nextButton,lastButton);
        model.loadSearchByCombo(searchByComboBox);
        model.loadPlantCombo(plantComboBox,true);
        model.loadDeptCombo(deptComboBox,"","");
        model.loadTypeCombo(typeComboBox); model.setSelectedComboBoxItem(typeComboBox, CapacityReq.REQUIREMENT_MACHINE);
        model.loadWeekCombo(weekComboBox);
        model.loadYesNoComboBox(reportedPointComboBox,true);

        model.loadColumnsOnAvailableLabourListViewGrid(availableLabourListView);
        model.loadColumnsOnHeaderGrid(mainListView);
        model.loadColumnsOnHeaderView3Grid(view2ListView, true);
        model.loadColumnsOnHeaderView3Grid(view3ListView, true);        
        model.loadColumnsOnHeaderView3Grid(labourListView, true);
        model.loadColumnsOnHeaderView3Grid(percentagesListView, true);
        model.loadColumnsOnHeaderView3Grid(hotListMachineView, false);
        model.loadColumnsOnHotListGrid(hotListView);
        model.loadColumnsOnHotListDateOnTopGrid(hotListDatesView,0,this.capacityHdr.Plant,7);
                
        model.screenFullArea();        

        mainTabControl.SelectedItem = this.view3TabItem;    
                           
        CumulaticePercent cumulaticePercent = new CumulaticePercent { CumPercent=0};
        cumulativePercentTextBox.DataContext = cumulaticePercent;
        //search();    

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }finally{
        bradioButtonIsEnable=true;
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

            qtyCumulativeHotListCheckBox.Visibility = mainTabControl.SelectedItem.Equals(hotListDatesTabItem) ? Visibility.Visible : Visibility.Collapsed;
            sortGroupBox.Visibility = mainTabControl.SelectedItem.Equals(hotListDatesTabItem) ? Visibility.Collapsed : Visibility.Visible;
            
            search();            
        }
                 
    } catch (Exception ex) {
        MessageBox.Show("mainTabControlSelectionChanged error:" + ex.Message);
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
        string  splantHotList= capacityHdr.Plant;
        string  splant       = model.getSelectedComboBoxItemString(plantComboBox);
        string  sdept        = model.getSelectedComboBoxItemString(deptComboBox);
        string  srequirment  = searchByComboBox.SelectedIndex == 0 && !string.IsNullOrEmpty(searchForTextBox.Text) ? searchForTextBox.Text + "%" : "";        
        string  spart        = searchByComboBox.SelectedIndex == 1 && !string.IsNullOrEmpty(searchForTextBox.Text) ? searchForTextBox.Text : "";           
        string  stype        = model.getSelectedComboBoxItemString(typeComboBox);
        string  srepPoint    = model.getSelectedComboBoxItemString(reportedPointComboBox);
        string  sprodFamily  = "";
        decimal dcumPercent  = 0;
        DateTime dateWeek    = DateUtil.MinValue;
        

        if (!string.IsNullOrEmpty(patTextBox.Text))
            spart= patTextBox.Text;
        if (!string.IsNullOrEmpty(spart))
            spart+="%";

        if (!model.getValidNumericFromAlpha(cumulativePercentTextBox,"Cumulative Percent"))
            dcumPercent=0;
        else
            dcumPercent=Convert.ToDecimal(cumulativePercentTextBox.Text);

        if (weekComboBox.SelectedItem!=null)    
            dateWeek = DateUtil.parseDate(((Nujit.NujitWms.WinForms.Util.ComboBoxItem)weekComboBox.SelectedItem).Content.ToString(), DateUtil.MMDDYYYY);

        CapacityViewContainer   capacityViewContainer = model.getCoreFactory().createCapacityViewContainer();
        ListView                listView = mainListView;
        CapacityView.SORT_TYPE sortType = (bool)deptReqIdRadioButton.IsChecked ? CapacityView.SORT_TYPE.DEPT_REQUIRMENT : CapacityView.SORT_TYPE.REQUIRMENT;

        if (!string.IsNullOrEmpty(srequirment))        
            srequirment = srequirment + "%";  

        if (mainTabControl.SelectedItem.Equals(view1TabItem)){
            listView = mainListView;
            capacityViewContainer= model.getCoreFactory().processCapacityReport(this.icapacityHdr,splant,sdept,srequirment,stype,spart);
            model.loadValuesOnGrid(listView,capacityViewContainer);
        }else if (mainTabControl.SelectedItem.Equals(view2TabItem)){
            capacityViewContainer= model.getCoreFactory().processCapacityReportGroupByReqTypeDept(this.icapacityHdr,splant,sdept,srequirment,-1,stype, spart, dateWeek,sortType);
            listView = view2ListView;
            model.loadValuesOnViewByReqType(listView, icapacityHdr,capacityViewContainer, dcumPercent,sortType, CapacityView.GENERIC_SHOW_TYPE.ALL);
        }else if (mainTabControl.SelectedItem.Equals(view3TabItem)){          
                      
            model.loadAvailableLabours(availableLabourListView,splant);
            capacityViewContainer = model.getCoreFactory().processCapacityReportGroupByReqTypeDept(this.icapacityHdr,splant,sdept,srequirment, -1, stype, spart, dateWeek,sortType);
            listView = view3ListView;
            model.loadValuesOnViewByReqType(listView, icapacityHdr,capacityViewContainer, dcumPercent,sortType, CapacityView.GENERIC_SHOW_TYPE.ALL);         
            capacityViewContainerSearch = capacityViewContainer; //store capacityViewContainer used on schedule

        }else if (mainTabControl.SelectedItem.Equals(view4TabItem)){  
            capacityViewContainer = model.getCoreFactory().processCapacityReportGroupByReqTypeDept(this.icapacityHdr,splant,sdept,srequirment, -1, stype, spart, dateWeek,sortType);
            listView = percentagesListView;
            model.loadValuesOnViewByReqType(listView, icapacityHdr,capacityViewContainer,dcumPercent,sortType, CapacityView.GENERIC_SHOW_TYPE.PERCENTAGES);
        } else if (mainTabControl.SelectedItem.Equals(labourTabItem)){  
                            
            capacityViewContainer = model.getCoreFactory().processCapacityReportGroupByReqTypeDept(this.icapacityHdr,splant,sdept,srequirment, -1, CapacityReq.REQUIREMENT_LABOUR,spart, dateWeek,sortType);
            listView = labourListView;
            model.loadValuesOnViewByReqType(listView, icapacityHdr, capacityViewContainer, dcumPercent,sortType, CapacityView.GENERIC_SHOW_TYPE.ALL);         
        } else if (mainTabControl.SelectedItem.Equals(hotListMachineTabItem)){ 

            HotListViewContainer hotListViewContainerAux = model.getCoreFactory().createHotListViewContainer();
            listView = hotListMachineView;            
            if (hotListViewMachineContainer.Count < 1)
                hotListViewMachineContainer = model.getCoreFactory().processHotListSchedule(0, splantHotList,"", "","",-1,srepPoint);

            if (!string.IsNullOrEmpty(splant) || !string.IsNullOrEmpty(sdept) || !string.IsNullOrEmpty(srequirment) || dateWeek != DateUtil.MinValue)
                hotListViewContainerAux = hotListViewMachineContainer.applyFilters(splant, sdept,srequirment, dateWeek);
            else
                hotListViewContainerAux = hotListViewMachineContainer;

            model.loadValuesOnHotListView(listView, hotListViewContainerAux, dcumPercent,sortType);
            
        } else if (mainTabControl.SelectedItem.Equals(hotListTabItem)){

            HotListViewContainer hotListViewContainerAux = model.getCoreFactory().createHotListViewContainer();
            listView = hotListView;
            if (hotListViewContainer.Count < 1)
                hotListViewContainer = model.getCoreFactory().getHotListOrderedByDate(0,splantHotList,"","");

            if (!string.IsNullOrEmpty(splant) || !string.IsNullOrEmpty(sdept) || !string.IsNullOrEmpty(srequirment) || dateWeek != DateUtil.MinValue)
                hotListViewContainerAux = hotListViewContainer.applyFilters(splant, sdept, srequirment, dateWeek);
            else
                hotListViewContainerAux = hotListViewContainer;

            listView.DataContext = hotListViewContainerAux;
            listView.ItemsSource = hotListViewContainerAux;       
                         
        } else if (mainTabControl.SelectedItem.Equals(hotListDatesTabItem)){                           
            listView = hotListDatesView;                         
            model.searchHotList(listView,capacityHdr.Plant, splant, sdept, srequirment, 0, spart,"",srepPoint,sprodFamily,0,(bool)qtyCumulativeHotListCheckBox.IsChecked,false,true,false, 0);                      

        } else if (mainTabControl.SelectedItem.Equals(labourPlanningTabItem)){
            listView = labourPlanningListView;
            LabourPlanningReportViewContainer labourPlanningReportViewContainer = model.loadLabourTypePlanning(labourPlanningListView, labourPlanningTabItem, capacityHdr, splant,sdept,srequirment,spart, dateWeek);                        
        }
                                
        if (listView.Items.Count > 0)
            listView.SelectedIndex=0;
        buttonsListViewFunctions = new ButtonsListViewFunctions(listView, firstButton,prevButton,nextButton,lastButton);                   

        timeLabel.Content = model.ProcessEndAndTex(listView.Items.Count);

    } catch (Exception ex) {
       MessageBox.Show("search Exception: " + ex.Message); 
    }finally {
        this.Cursor = cursor;    
    }            
}  

private 
void qtyCumulativeHotListCheckBox_Click(object sender, RoutedEventArgs e){
    search();
}

private 
void deptReqIdRadioButton_Checked(object sender, RoutedEventArgs e){
    if (bradioButtonIsEnable && (bool)deptReqIdRadioButton.IsChecked)
        search();
}

private 
void reqIdRadioButton_Checked(object sender, RoutedEventArgs e){
    if (bradioButtonIsEnable && (bool)reqIdRadioButton.IsChecked)
        search();
}

private 
void cumulativePercentTextBox_KeyDown(object sender, KeyEventArgs e){
   
}

private 
void createScheduleButton_Click(object sender, RoutedEventArgs e){
    if (mainTabControl.SelectedItem.Equals(hotListDatesTabItem))
         createScheduleHotList();
    else if (mainTabControl.SelectedItem.Equals(hotListTabItem))
        model.createScheduleHotList(hotListView,capacityHdr.Plant);    
    else
        createSchedule();
}


private 
void createSchedule(){            
    try{        
        bool                bhotList = mainTabControl.SelectedItem.Equals(hotListMachineTabItem);
        MachineContainer    machineContainer = model.getCoreFactory().createMachineContainer();

        if (bhotList)
            machineContainer = model.getMachineList(hotListViewMachineContainer);
        else
            machineContainer = model.getMachineList(this.capacityViewContainerSearch);
        machineContainer.sortByMachine();     


        if (bhotList){
            CapSelMachineHotListWindow capSelMachineHotListWindow = new CapSelMachineHotListWindow(icapacityHdr,"", hotListViewMachineContainer, machineContainer, model.getWeekList());            
             if ((bool)capSelMachineHotListWindow.ShowDialog()){
                    machineContainer = capSelMachineHotListWindow.MachineContainer;                
                    model.createSchedule(this.icapacityHdr, hotListViewMachineContainer, machineContainer, capSelMachineHotListWindow.getStartDate(), capSelMachineHotListWindow.getEndDate());                
             }
        }else{
            CapSelMachineWindow capSelMachineWindow = new CapSelMachineWindow(icapacityHdr, this.capacityViewContainerSearch, machineContainer, model.getWeekList());
            if ((bool)capSelMachineWindow.ShowDialog()){
                machineContainer = capSelMachineWindow.MachineContainer;
                model.createSchedule(icapacityHdr,machineContainer, capSelMachineWindow.getStartDate(), capSelMachineWindow.getEndDate());
            }
        }

    } catch (Exception ex) {
       MessageBox.Show("createSchedule Exception: " + ex.Message); 
    }
           
}
 
private 
void createScheduleHotList(){            
    try{        
        string []               item   =  (string[])model.getSelected(hotListDatesView);
        HotListViewContainer    hotListViewContainerAux = model.getCoreFactory().createHotListViewContainer();
        MachineContainer        machineContainer = model.getCoreFactory().createMachineContainer();

        if (item!= null){
            string  sdept    = item[0];
            string  smachine = item[7];
            string  spart    = item[4];
            int     iseq     = Convert.ToInt32(item[5]);

            if (!string.IsNullOrEmpty(smachine)){   
                hotListViewContainerAux = model.getCoreFactory().processHotListSchedule(0,this.capacityHdr.Plant,sdept,smachine,spart, iseq,"");
                machineContainer = model.getMachineList(hotListViewContainerAux);

                CapSelMachineHotListWindow capSelMachineHotListWindow = new CapSelMachineHotListWindow(icapacityHdr,spart,hotListViewContainerAux, machineContainer, model.getWeekList());            
                if ((bool)capSelMachineHotListWindow.ShowDialog()){
                    machineContainer = capSelMachineHotListWindow.MachineContainer;                
                    if (model.createSchedule(this.icapacityHdr, hotListViewContainerAux, machineContainer, capSelMachineHotListWindow.getStartDate(), capSelMachineHotListWindow.getEndDate()))
                        search();      //search again , so info on HotList grid will be updated                                          
                }
            }else
                MessageBox.Show("Sorry, There Is Not Machine To Build That Part.");
            
        }else
            MessageBox.Show("Please, Select Item First.");       

    } catch (Exception ex) {
       MessageBox.Show("createScheduleHotList Exception: " + ex.Message); 
    }
           
}

private 
void plantComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
   model.plantComboBoxSelectionChanged(plantComboBox,deptComboBox);
}

}
}
