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
using System.Collections;
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core.ScheduleDemand;
using Nujit.NujitERP.ClassLib.Core.Machines;


namespace HotListReports.Windows.Demand{

class CapacitySelMachineModel : BaseModel2{

public CapacitySelMachineModel(Window window) : base(window){    
}

public
MachineContainer createMachineSelList(MachineContainer machineContainer){

    MachineContainer machineContainerAux = getCoreFactory().createMachineContainer();;

    foreach (Machine machine in machineContainer){
        MachineSel machineSel = new MachineSel(machine);
        machineContainerAux.Add(machineSel);
    }
    return machineContainerAux;
}


public
void loadColumnsOnHeaderGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        CheckColumnListView     checkColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));

        checkColumnListView = new CheckColumnListView("Select", "IsChecked", BindingMode.TwoWay,50,listView);
        gridView.Columns.Add(checkColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Plant", "Plt", BindingMode.OneWay,50, listView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Dept", "Dept", BindingMode.OneWay,50, listView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Machine", "Mach", BindingMode.OneWay,70, listView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Parts", "Des4", BindingMode.OneWay,400, listView);
        gridView.Columns.Add(textBlockColumnListView.process());
                                
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

public
void loadWeekCombos(ComboBox comboBox1, ComboBox comboBox2, ArrayList arraList){       
    try {
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list1 = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list2 = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        DateTime    priorMonday = DateTime.Now;
        DateTime    nextSunday = DateTime.Now;
        string      saux="";
        
        for (int j = 0; j < arraList.Count; j++){
            priorMonday = (DateTime)arraList[j];
            DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);

            saux = "WK" + j.ToString() + "-" +DateUtil.getDateRepresentation(priorMonday,DateUtil.MMDDYYYY);
            list1.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(saux, priorMonday));                         

            saux = "WK" + j.ToString() +  "-" + DateUtil.getDateRepresentation(nextSunday, DateUtil.MMDDYYYY);
            list2.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(saux, nextSunday));                         
        }
                       
        comboBox1.ItemsSource = list1;
        if (comboBox1.Items.Count > 0)
            comboBox1.SelectedIndex = 0;      
        
        comboBox2.ItemsSource = list2;
        if (comboBox2.Items.Count > 0)
            comboBox2.SelectedIndex = 0;                

    } catch (Exception ex) {
        MessageBox.Show("loadWeekCombos Exception: " + ex.Message);        
    }
}

public
void loadMachineView(ListView listView,MachineContainer machineContainer){
    try {
        setDataContextListView(listView, machineContainer);        
    } catch (Exception ex) {
        MessageBox.Show("loadMachineView Exception: " + ex.Message);        
    }
}

public
void syncBasedOnStartDate(ComboBox startDateComboBox, ComboBox endtDateComboBox){           
    try {                
        if (startDateComboBox.SelectedIndex > endtDateComboBox.SelectedIndex && startDateComboBox.SelectedIndex < endtDateComboBox.Items.Count)
            endtDateComboBox.SelectedIndex = startDateComboBox.SelectedIndex;
    } catch (Exception ex) {
        MessageBox.Show("syncBasedOnStartDate Exception: " + ex.Message);        
    }
}

public
void syncBasedOnEndDate(ComboBox startDateComboBox, ComboBox endtDateComboBox){           
    try{                
        if (endtDateComboBox.SelectedIndex < startDateComboBox.SelectedIndex && endtDateComboBox.SelectedIndex < startDateComboBox.Items.Count)
            startDateComboBox.SelectedIndex = endtDateComboBox.SelectedIndex;
    } catch (Exception ex) {
        MessageBox.Show("syncBasedOnEndDate Exception: " + ex.Message);        
    }
}

public
void getDatesSelected(ComboBox startDateComboBox,ComboBox endtDateComboBox,out DateTime startDate,out DateTime endDate){
    startDate = DateUtil.MinValue;    
    endDate = DateUtil.MinValue;    

   try {                
        if (getSelectedComboBoxItem(startDateComboBox)!= null)
            startDate = (DateTime)getSelectedComboBoxItem(startDateComboBox);             
        if (getSelectedComboBoxItem(endtDateComboBox)!= null)
            endDate = (DateTime)getSelectedComboBoxItem(endtDateComboBox);

    } catch (Exception ex) {
        MessageBox.Show("loadMachineView Exception: " + ex.Message);        
    }
}


public
void selUnSellList(ListView machineListView,bool bselect){
    try{
        MachineContainer machineContainerAux = (MachineContainer) machineListView.DataContext;
    
        if (machineContainerAux != null){
            //empty grid first
            loadMachineView(machineListView, getCoreFactory().createMachineContainer());   

            for (int i=0; i < machineContainerAux.Count;i++){
                MachineSel machineSel =(MachineSel)machineContainerAux[i];
                machineSel.IsChecked = bselect;
            }     
            loadMachineView(machineListView, machineContainerAux);//reload grid
        }

    } catch (Exception ex) {
        MessageBox.Show("selUnSellList Exception: " + ex.Message);        
    }
}

public
MachineContainer loadMachinesBasedOnDatesSelected(HotListViewContainer hotListViewContainer, MachineContainer machineContainer,int icapacityHdrId, DateTime startDate,DateTime endDate){
    MachineContainer machineContainerAux = getCoreFactory().createMachineContainer();
    try{                        
        HotListView                 hotListViewId = hotListViewContainer.Count > 0 ? hotListViewContainer[0] : null;
        int                         ihotListId = hotListViewId != null ? hotListViewId.HotListId : 0;

        if (startDate != DateUtil.MinValue && endDate != DateUtil.MinValue && endDate >= startDate){

            //check if already exists Schedule created for hotlist/capacityreport
            ScheduleHdr                 scheduleHdrOld = getCoreFactory().createScheduleHdr();
            ScheduleHdrContainer        scheduleHdrContainer = getCoreFactory().readScheduleHdrByFilters("","","",0,ihotListId, DateUtil.MinValue,DateUtil.MinValue,false,1);//try to get if already exist Schedule for that hotList
            if (scheduleHdrContainer.Count < 1)
                scheduleHdrContainer = getCoreFactory().readScheduleHdrByFilters("","","", icapacityHdrId, 0, DateUtil.MinValue,DateUtil.MinValue,false,1);//try to get if already exist Schedule for that capacityreport

            if (scheduleHdrContainer.Count > 0)
                scheduleHdrOld = scheduleHdrContainer[0];
                

            for (int i=0; i < machineContainer.Count;i++)  {  
                MachineSel machineSel =(MachineSel)machineContainer[i];

                HotListViewContainer hotListViewContainerOnRangeMachine = hotListViewContainer.getChildsByDatesRangeAndnMachine(machineSel, startDate, endDate);
                if (hotListViewContainerOnRangeMachine.Count > 0){  //list of part on range
                        string saux="";
                        string skey="";
                        machineContainerAux.Add(machineSel);
                         
                        //show parts                                
                        Hashtable hashtableParts = new Hashtable();
                        foreach (HotListView hotListViewOnRange in hotListViewContainerOnRangeMachine){
                            skey= hotListViewOnRange.ProdID + "-" + hotListViewOnRange.Seq.ToString();

                            if (!hashtableParts.Contains(skey)){
                                hashtableParts.Add(skey, hotListViewOnRange.Qty);
                                saux+=  string.IsNullOrEmpty(saux) ? skey : "/" + skey;
                            }
                        }
                        machineSel.Des4 = saux;

                        if (string.IsNullOrEmpty(machineSel.Des4))
                            machineSel.Des4 = saux;
                }
                  
            }
        }
               
    } catch (Exception ex) {
        MessageBox.Show("loadMachinesBasedOnDatesSelected Exception: " + ex.Message);        
    }
    return machineContainerAux;
}

public
MachineContainer loadMachinesBasedOnDatesSelected(MachineContainer machineContainer,int icapacityHdrId, DateTime startDate,DateTime endDate){
    MachineContainer machineContainerAux = getCoreFactory().createMachineContainer();
    try{                        
        
        if (startDate != DateUtil.MinValue && endDate != DateUtil.MinValue && endDate >= startDate){
            //check if already exists Schedule created for hotlist/capacityreport
            ScheduleHdr           scheduleHdr = getCoreFactory().getIfAlreadyScheduled(0, icapacityHdrId);                
            CapacityViewContainer capacityViewContainerAllMachines = getCoreFactory().readCapacityViewPartByFilters(icapacityHdrId, "", "", "", "", machineContainer, startDate, endDate);            

            for (int i=0; i < machineContainer.Count;i++)  {  
                MachineSel              machineSel =(MachineSel)machineContainer[i];                                
                CapacityViewContainer   capacityViewContainerForMachine = capacityViewContainerAllMachines.getListByReqTypeId(CapacityReq.REQUIREMENT_MACHINE, machineSel.Id);

                if (capacityViewContainerForMachine.Count > 0){  //list of part on range
                        string saux="";
                        string skey="";
                        machineContainerAux.Add(machineSel);
                         
                        //show parts                                
                        Hashtable hashtableParts = new Hashtable();
                        foreach (CapacityViewPart capacityViewPart in capacityViewContainerForMachine){
                            skey= capacityViewPart.Part + "-" + capacityViewPart.Seq.ToString();

                            if (!hashtableParts.Contains(skey)){
                                hashtableParts.Add(skey, capacityViewPart.Qty);
                                saux+=  string.IsNullOrEmpty(saux) ? skey : "/" + skey;
                            }
                        }
                        machineSel.Des4 = saux;

                        if (string.IsNullOrEmpty(machineSel.Des4))
                            machineSel.Des4 = saux;
                }
                  
            }
        }
               
    } catch (Exception ex) {
        MessageBox.Show("loadMachinesBasedOnDatesSelected Exception: " + ex.Message);        
    }
    return machineContainerAux;
}

}
}
