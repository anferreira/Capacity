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
using System.Collections;
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Common;
using HotListReports.Windows.Demand;
using Nujit.NujitERP.ClassLib.Core.Planned;
using Nujit.NujitERP.ClassLib.Core.Machines;


namespace  HotListReports.Windows.Util { 

class ReportTypeViewsModel : BaseModelDatesReport {

private CapacityViewHdrContainer    capacityViewHdrContainer;
private Hashtable                   hashRouting;
private CapacityViewContainer       capacityViewContainer;                    

private Hashtable       hashPrHistSum;
private DateTime        prHistDateTimeChecked;
           
public ReportTypeViewsModel(Window window) : base(window){    
    this.hashRouting = new Hashtable();
    this.capacityViewContainer = getCoreFactory().createCapacityViewContainer();

    this.hashPrHistSum = new Hashtable();
    this.prHistDateTimeChecked = DateUtil.MinValue;
}

public
CapacityViewContainer CapacityViewContainer {
	get { return capacityViewContainer; }
	set { if (this.capacityViewContainer != value){
			this.capacityViewContainer = value;		
		}
	}
}

public
Hashtable HashPrHistSum {
	get { return hashPrHistSum; }
	set { if (this.hashPrHistSum != value){
			this.hashPrHistSum = value;			
		}
	}
}

public
void loadColumnsOnShiftListView(ListView listView,bool bfromMachineView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
        int                     iwith = 55;
                                                                     
        textBlockColumnListView = new TextBlockColumnListView("Description", "Target", BindingMode.OneWay, bfromMachineView?485:285, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));  
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        /*
        textBlockColumnListView = new TextBlockColumnListView(CapacityView.TITLE_PASTDUE, CapacityView.TITLE_WEEKNUM + CapacityView.TITLE_PASTDUE, BindingMode.OneWay, iwith, listView);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;    
        gridView.Columns.Add(textBlockColumnListView.process());*/

        DateTime priorMonday = DateTime.Now;
        DateTime nextSunday = DateTime.Now;                           

        for (int i=0; i < CapacityView.TITLE_COUNTS;i++,priorMonday = priorMonday.AddDays(7)){       //load for each week  
                                
            DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);
            string sdate = DateUtil.getDateRepresentation(priorMonday, DateUtil.MMDDYYYY).Substring(0,5);                

            string sbinding =i < 0 ? CapacityView.TITLE_PASTDUE : CapacityView.TITLE_WEEKNUM+i.ToString();  
            string sweek    = i== 0? CapacityView.TITLE_WEEK0 : sbinding; 
                                        
            textBlockColumnListView = new TextBlockColumnListView(sweek + "\n" + sdate, sbinding, BindingMode.OneWay,iwith,listView);
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;    
            gridView.Columns.Add(textBlockColumnListView.process());
        }
        
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnShiftListView Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnHeaderView3Grid(ListView view3ListView,bool bloadType){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                     
        textBlockColumnListView = new TextBlockColumnListView("Department", "[1]", BindingMode.OneWay,160, view3ListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Requirm.", "[2]", BindingMode.OneWay,150, view3ListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        loadColumnsOnHeaderGeneric2(view3ListView, gridView,cell);        
        view3ListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderView2Grid Exception: " + ex.Message);        
    }
}

public 
void loadColumnsOnHeaderGeneric2(ListView listView,GridView gridView,Style cell){
     try {        
        TextBlockColumnListView textBlockColumnListView = null;
        int                     iwith = 55;

        textBlockColumnListView = new TextBlockColumnListView(CapacityView.TITLE_PASTDUE, "[3]", BindingMode.OneWay, iwith, listView);                                  
        textBlockColumnListView.setBinding("[3]", BindingMode.OneWay, TextBlock.ForegroundProperty);
        textBlockColumnListView.setConverter(new CapacityValueColorConverter(), "C");                    
        textBlockColumnListView.process();
        textBlockColumnListView.setBinding("[3]", BindingMode.OneWay, TextBlock.TextProperty);
        textBlockColumnListView.setConverter(new CapacityValueColorConverter(), "V");                    
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.process();        

        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;    
        gridView.Columns.Add(textBlockColumnListView.process());

        DateTime priorMonday = DateTime.Now;
        DateTime nextSunday = DateTime.Now;

        for (int i=0; i < CapacityView.TITLE_COUNTS;i++,priorMonday = priorMonday.AddDays(7)){         
                                
            DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);
            string sdate = DateUtil.getDateRepresentation(priorMonday, DateUtil.MMDDYYYY).Substring(0,5);                

            string sbinding = "[" + (i + 4) + "]";                   
            textBlockColumnListView = new TextBlockColumnListView(CapacityView.TITLE_WEEKNUM + i.ToString() + "\n" + sdate, sbinding, BindingMode.OneWay, iwith, listView);                        

            textBlockColumnListView.setBinding(sbinding, BindingMode.OneWay, TextBlock.TextProperty);
            textBlockColumnListView.setConverter(new CapacityValueColorConverter(), "V");            
            textBlockColumnListView.process();

            textBlockColumnListView.setBinding(sbinding, BindingMode.OneWay, TextBlock.ForegroundProperty);
            textBlockColumnListView.setConverter(new CapacityValueColorConverter(), "C");                    
            textBlockColumnListView.process();
           
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;    
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            gridView.Columns.Add(textBlockColumnListView.process());
        }

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGeneric2 Exception: " + ex.Message);        
    }

}

public
MachineReportViewContainer loadCapacityByShifts(ListView listView,string splant,int icapacityHdr,CapacityViewContainer capacityViewContainer,Hashtable hashPrHistSumCurrWeek,bool bfromMachineView){
    MachineReportViewContainer      machineReportViewContainer = getCoreFactory().createMachineReportViewContainer();
    try { 
        MachineReportView               machineReportView       = null;        
        MachineReportView               machineReportCapacity   = null;        
        MachineReportView               machineReportPlanned    = null;        
        CapacityView                    capacityView            = null;
        decimal                         dhoursPerShift          = getHrsPerShift();
        decimal                         dshiftPerWeek           = getStdShiftPerWeek();
        string                          stitle                  ="";        
        ArrayList                       arrayTitleWeek          = CapacityView.getArrayWeeeksByTitle();
        bool                            buseMachineCapacity     =true;
        ArrayList                       arrayDateTimeList       = CapacityView.getDateTimeWeekList(false);    
        ArrayList                       arrayDateTimeSundayList = CapacityView.getDateTimeWeekSundayList(false);
        CapShiftProfileContainer        capShiftProfileContainer= getCoreFactory().createCapShiftProfileContainer();
        int                             imachineId              = machine!= null ? machine.Id : 0;
        
        //this is capacity hours for 1 machine, so we create 'netshifts'
        machineReportView  = getCoreFactory().createMachineReportView();
        machineReportView.Target = "Available Capacity Shift";
        machineReportViewContainer.Add(machineReportView);
        for (int i=0; i < CapacityView.TITLE_COUNTS; i++) {         //load for each week, searching by title
            stitle= i < 0 ? CapacityView.TITLE_PASTDUE : CapacityView.TITLE_WEEKNUM+i.ToString();

            //double totalDays = getCoreFactory().getCapProfileHolidayDatesAffects(splant,(DateTime)arrayDateTimeList[i], (DateTime)arrayDateTimeSundayList[i]);

            capShiftProfileContainer = getCoreFactory().readCapShiftProfilesForWeek(splant,Constants.STATUS_ACTIVE, (DateTime)arrayDateTimeList[i],false);
            if (capShiftProfileContainer.Count > 0) 
                dshiftPerWeek = (i==0 ? capShiftProfileContainer.getRemainsShifts(DateTime.Now, Constants.STRING_YES)  : capShiftProfileContainer.getTotalShiftPerWeek()) + //on current week we show remains shifts
                                capShiftProfileContainer.getTotalShiftPerWeekByMachinePlan(imachineId);
            else
                dshiftPerWeek = getStdShiftPerWeek();

            if (buseMachineCapacity) { 
                machineReportView.setCellWeek(i, dshiftPerWeek);
            }else { 
                capacityView = capacityViewContainer.getByFirstTitle(stitle);
                if (capacityView!= null)
                    machineReportView.setCellWeek(i, capacityView.Hours / dhoursPerShift);
            }
        }
        machineReportCapacity= machineReportView;
        sumShiftsHours(machineReportViewContainer,machineReportView, "Sum Available Capacity Shift"); //summary capacity shifts
                
        plannedHdr = getCoreFactory().readPlannedHdrLastDateCheck(plannedHdr,splant);//read planned        
      
        machineReportView  = getCoreFactory().createMachineReportView();
        machineReportView.Target = "Net Planned Shift";
        machineReportViewContainer.Add(machineReportView);
        //load planned for specific machine(machine view) or for all machines(labour view)
        if (bfromMachineView)            
            loadCapacityByShiftsProcessMachinePlannedReq(machineReportView,arrayDateTimeList,hashPrHistSumCurrWeek,imachineId,dhoursPerShift);
        else
            loadCapacityByShiftsProcessAllPlannedReq(machineReportView,arrayDateTimeList,hashPrHistSumCurrWeek,dhoursPerShift);
        
        machineReportPlanned= machineReportView;
        sumShiftsHours(machineReportViewContainer, machineReportView, "Sum Planned Shift"); //summary planned shifts

        //Capacity - Planned
        machineReportView  = getCoreFactory().createMachineReportView();
        machineReportView.Target = "Net Planned - Capacity Shift";
        machineReportViewContainer.Add(machineReportView);
        for (int i=0; i < arrayDateTimeList.Count; i++) {              
            
            decimal dplanned = machineReportPlanned.getCellWeek(i);
            decimal dcapacity = machineReportCapacity.getCellWeek(i);
            decimal dshowDiff =0;

            if (dcapacity - dplanned > 0 )  dshowDiff =0;
            else                            dshowDiff = dcapacity - dplanned;            
            machineReportView.setCellWeek(i, dshowDiff);
        }

        sumShiftsHours(machineReportViewContainer,machineReportView, "Sum Net Planned - Capacity Shift"); //summary 
        setDataContextListView(listView,machineReportViewContainer);
                
    } catch (Exception ex) {
        MessageBox.Show("loadCapacityByShifts Exception: " + ex.Message);        
    }
    return machineReportViewContainer;
}

private
void loadCapacityByShiftsProcessPlannedReq(MachineReportView machineReportView, ArrayList arrayDateTimeList,Hashtable hashPrHistSumCurrWeek,int imachineId,decimal dhoursPerShift,PlannedReq plannedReq){
    DateTime    startDate   = DateTime.Now;
    DateTime    endDate     = DateTime.Now;
    decimal     dshiftHours =0;
                                 
    for (int i=0; i < arrayDateTimeList.Count && plannedReq!= null; i++) { 
        DateTime currDate    = (DateTime)arrayDateTimeList[i];
        DateUtil.getPriorMondayNextSundayFromDate(currDate, out startDate, out endDate); 

        dshiftHours = getCoreFactory().loadPlannedHdrHoursByMachineRangeDate(plannedHdr, i==0? hashPrHistSumCurrWeek : new Hashtable(), imachineId,startDate,endDate,hashRouting) / dhoursPerShift;
        machineReportView.setSumCellWeek(i,dshiftHours);
    }
}

private
void loadCapacityByShiftsProcessMachinePlannedReq(MachineReportView machineReportView,ArrayList arrayDateTimeList,Hashtable hashPrHistSumCurrWeek,int imachineId,decimal dhoursPerShift){
    PlannedReq plannedReq = null;
    if (plannedHdr != null)
        plannedReq = plannedHdr.PlannedReqContainer.getByRequirment(Constants.TYPE_MACHINE, machine != null ? machine.Id : 0);

    loadCapacityByShiftsProcessPlannedReq(machineReportView,arrayDateTimeList,hashPrHistSumCurrWeek,imachineId,dhoursPerShift,plannedReq);
}

private
void loadCapacityByShiftsProcessAllPlannedReq(MachineReportView machineReportView, ArrayList arrayDateTimeList,Hashtable hashPrHistSumCurrWeek,decimal dhoursPerShift){    
    PlannedReq  plannedReq  = null;
                              
    for (int i=0; plannedHdr!=null && i < plannedHdr.PlannedReqContainer.Count; i++) { 
        plannedReq = plannedHdr.PlannedReqContainer[i];     
        if (plannedReq.Type.Equals(Constants.TYPE_MACHINE))
            loadCapacityByShiftsProcessPlannedReq(machineReportView,arrayDateTimeList,hashPrHistSumCurrWeek, plannedReq.ReqID,dhoursPerShift,plannedReq);
    }
}

private
void sumShiftsHours(MachineReportViewContainer machineReportViewContainer,MachineReportView machineReportView, string stitle){
    decimal             dshiftHours=0;
    decimal             dshiftSumHours=0;
    MachineReportView   machineReportViewSum = new MachineReportView();
    machineReportViewSum.Target = stitle;
    machineReportViewContainer.Add(machineReportViewSum);

    for (int i = 0; i<CapacityView.TITLE_COUNTS; i++) {         //summary for each week
        dshiftHours = machineReportView.getCellWeek(i);
        dshiftSumHours+= dshiftHours;
        machineReportViewSum.setCellWeek(i,dshiftSumHours);
    }
}

public
void loadValuesOnViewByReqType(ListView listView,int icapacityHdr,CapacityViewContainer capacityViewContainer, decimal dcumPercent, CapacityView.SORT_TYPE sortType, CapacityView.GENERIC_SHOW_TYPE genericShowType) {

    int                     i = 0;
    int                     j = 0;
    string                  sweeK = "";
    string                  splantDeptResource = "";    
    
    CapacityViewContainer   capacityViewContainerByReqType = coreFactory.createCapacityViewContainer();
    CapacityViewContainer   capacityViewContainerSum = coreFactory.createCapacityViewContainer();
    CapacityViewContainer   capacityViewContainerForRequirment = coreFactory.createCapacityViewContainer();
    CapacityViewContainer   capacityViewContainerAvailCapacity = loadAvailableCapacity();

    ArrayList               arrayColumns = new ArrayList();
    ArrayList               arrayRes = new ArrayList();
    ArrayList               arrayReqType = new ArrayList();
    CapacityView            capacityView=null;    
        
    Hashtable               hashRes = new Hashtable();              //get differents resource/reqname per plant/dept
            
    if (genericShowType == CapacityView.GENERIC_SHOW_TYPE.ALL)
        arrayReqType = capacityViewContainer.getDifferentsReqType(); //show differents requirments
    else
        arrayReqType.Add(CapacityReq.REQUIREMENT_MACHINE);          //show only Machine requirment

    this.capacityViewHdrContainer = coreFactory.createCapacityViewHdrContainer();

    loadColumnsOnHeaderView3Grid(listView,true);
    listView.Items.Clear(); 
                             
    arrayColumns.Add(CapacityView.TITLE_PASTDUE);//generate columns for Weeks/Title
    addSummaryCapacityView(capacityViewContainerSum, CapacityView.TITLE_PASTDUE);    
    for (i=0; i < CapacityView.TITLE_COUNTS;i++){
        sweeK= CapacityView.TITLE_WEEKNUM + i.ToString();
        arrayColumns.Add(sweeK);

        addSummaryCapacityView(capacityViewContainerSum,sweeK);    //add to summarize container
    }

    ScheduleHdr scheduleHdr = getCoreFactory().getIfAlreadyScheduled(0, icapacityHdr);
        
    for (int ireqType=0; ireqType < arrayReqType.Count; ireqType++){ //loop by reqtype
        string sreqType = (string)arrayReqType[ireqType];   
               
        capacityViewContainerByReqType = capacityViewContainer.getListByReqType(sreqType);
        if (sortType == CapacityView.SORT_TYPE.REQUIRMENT)
            capacityViewContainerByReqType.sortByRequirment();
        else
            capacityViewContainerByReqType.sortByView1();        

        //get differents plant/dept/resource 
        arrayRes = capacityViewContainerByReqType.getDifferentsPlantDeptResource(out hashRes);
                                            
        for (j=0; j < arrayRes.Count;j++) { //loop on list of differents resource/requirments
            splantDeptResource= (string)arrayRes[j]; //current plant/dept/resource/requirment
            
            CapacityView capacityViewAux = (CapacityView)hashRes[splantDeptResource];                                         
            
            capacityViewContainerForRequirment = coreFactory.createCapacityViewContainer();
            for (int k =0; k < arrayColumns.Count; k++){ 
                sweeK= (string)arrayColumns[k];  //current week/title

                capacityView = capacityViewContainerByReqType.getForMatrixByPlantDeptResoure(splantDeptResource, sweeK);
                if (capacityView !=null){ //found for shift   
                    capacityViewContainerForRequirment.Add(capacityView);                                                                                 
                }else{                    //not found for shift 
                    CapacityView capacityViewZero = coreFactory.cloneCapacityView(capacityViewAux);
                    capacityViewZero.Hours=0;
                    capacityViewZero.Title = sweeK;
                    capacityViewContainerForRequirment.Add(capacityViewZero);
                }
            }
            loadRequirmentInfo(capacityViewAux,capacityViewContainerForRequirment,capacityViewContainerAvailCapacity,scheduleHdr); //load requirment info            
        }                                                    
    }

    //show info processed on screen
    CapacityViewHdrContainer capacityViewHdrAuxContainer = this.capacityViewHdrContainer;
   // if (dcumPercent > 0) 
     //   capacityViewHdrAuxContainer = applyCustomFilters(capacityViewContainer, dcumPercent);

    loadListViewWithContainer(listView,genericShowType,sortType, capacityViewHdrAuxContainer,capacityViewContainer,capacityViewContainerSum);    
}  

private
CapacityViewContainer loadAvailableCapacity(){
    CapacityViewContainer   capacityViewContainerAvailCapacity = coreFactory.createCapacityViewContainer();
    CapacityView            capacityView = coreFactory.createCapacityView();

    capacityView.Title = CapacityView.TITLE_PASTDUE;
    capacityViewContainerAvailCapacity.Add(capacityView);
              
    for (int i=0; i < CapacityView.TITLE_COUNTS;i++){
        string sweeK= CapacityView.TITLE_WEEKNUM + i.ToString();

        capacityView = coreFactory.createCapacityView();
        capacityView.Title = sweeK;         
        capacityView.AvailableCapacity = capacityView.getHoursForSimpleCalcs(i);
        capacityViewContainerAvailCapacity.Add(capacityView);

        /*
        MessageBox.Show("Week Num :" + sweeK + "\n" +
                        "Hours :" + capacityView.Hours.ToString("0.00"));*/
    }
    return capacityViewContainerAvailCapacity;
}

private
void addSummaryCapacityView(CapacityViewContainer capacityViewContainerSum, string stitle){
    CapacityView capacityView = coreFactory.createCapacityView();

    capacityView.ShowType = CapacityView.SHOW_TYPE.TYPE_TOTAL;
    capacityView.Title = stitle;    
    capacityView.Machine = "Total";    
    capacityViewContainerSum.Add(capacityView);    
}  

private
void loadListViewWithContainer(ListView listView,CapacityView.GENERIC_SHOW_TYPE genericShowType,
                                CapacityView.SORT_TYPE sortType,CapacityViewHdrContainer capacityViewAuxHdrContainer,
                                CapacityViewContainer capacityViewContainer,CapacityViewContainer capacityViewContainerSum){
    CapacityViewHdr     capacityViewHdr = null;
    string              sreqTypeForReport = "";
    string              splantDeptForReport= "";
            bool bshowTotals = false;// for now not show totals (genericShowType == CapacityView.GENERIC_SHOW_TYPE.ALL);

    listView.Items.Clear(); 
           
    for (int i=0; i < capacityViewAuxHdrContainer.Count;i++){
        capacityViewHdr = capacityViewAuxHdrContainer[i];

        //if reqtype showed , changed we show summarize first
        if (bshowTotals && !string.IsNullOrEmpty(sreqTypeForReport) && !sreqTypeForReport.Equals(capacityViewHdr.ReqType))                    
            loadTotalsPerReqType(listView, genericShowType, capacityViewContainer, capacityViewContainerSum,sreqTypeForReport);

        loadRequirmentCell(listView, genericShowType, ref sreqTypeForReport, ref splantDeptForReport,sortType,capacityViewHdr);
    }  

    //load last summary
    if (bshowTotals && !string.IsNullOrEmpty(sreqTypeForReport))
        loadTotalsPerReqType(listView, genericShowType, capacityViewContainer, capacityViewContainerSum,sreqTypeForReport);
}  

private
void loadTotalsPerReqType(ListView listView,CapacityView.GENERIC_SHOW_TYPE genericShowType, CapacityViewContainer capacityViewContainer,CapacityViewContainer capacityViewContainerSum,string sreqType){
    CapacityView capacityViewSum = null;
    CapacityView capacityViewSumPrior = null;

    //show summarized
    var rowList = new List<string>();    
    rowList.Add("");//reqTypef
    rowList.Add("");//plant/dept
    rowList.Add("Total");//total
    
    for (int j=0; j < capacityViewContainerSum.Count;j++){
        capacityViewSum= capacityViewContainerSum[j];
        CapacityView capacityView   = capacityViewContainer.getSummarizeByWeek(capacityViewSum.Title,sreqType);        
                
        capacityViewSum.ReqType = sreqType;
        capacityViewSum.ShowType = CapacityView.SHOW_TYPE.TYPE_TOTAL;
        if (capacityView!=null){
            capacityViewSum.Hours= capacityView.Hours; //overwrite totals
            capacityViewSum.SDate= capacityView.SDate;            
        }

        rowList.Add(true ? capacityViewSum.getHourShowType() : capacityViewSum.Hours.ToString("0.00"));        
    }   
    listView.Items.Add(rowList);  

    //now show summarized
    rowList = new List<string>();    
    rowList.Add("");//reqTypef
    rowList.Add("");//plant/dept
    rowList.Add("SumTot");//summarized total                 
    
    for (int j=0; j < capacityViewContainerSum.Count;j++){
        capacityViewSum= capacityViewContainerSum[j];
                               
        if (capacityViewSumPrior != null)
            capacityViewSum.Hours+= capacityViewSumPrior.Hours; //summarize totals            
                
        rowList.Add(true ? capacityViewSum.getHourShowType() : capacityViewSum.Hours.ToString("0.00"));        
        capacityViewSumPrior= capacityViewSum;
    }   
    listView.Items.Add(rowList);      
}  

private
void loadRequirmentCell(ListView listView,CapacityView.GENERIC_SHOW_TYPE genericShowType, ref string sreqTypeForReport,ref string splantDeptForReport,
                        CapacityView.SORT_TYPE sortType,CapacityViewHdr capacityViewHdr){
    int             icountInfoByReq= (int)CapacityView.SHOW_TYPE.SCHEDULE_TIME; 
    int             istartShowIndex = genericShowType == CapacityView.GENERIC_SHOW_TYPE.ALL ? 0 : (int)CapacityView.SHOW_TYPE.PERCENTAGE;
    var             rowList = new List<string>();  
    CapacityView    capacityView = null;    
    bool            bprocess = true;        

    for (int i= 0; i <= icountInfoByReq && bprocess; i++){
        rowList = new List<string>();    

        if (i >= istartShowIndex){ //on list view only will be showed depending if All or Percentages            
            //req type
            if (sreqTypeForReport.Equals(capacityViewHdr.ReqType))
                rowList.Add("");
            else
                rowList.Add(capacityViewHdr.ReqType);
            sreqTypeForReport= capacityViewHdr.ReqType;

            //plant/dept
            if ( i > istartShowIndex || (splantDeptForReport.Equals(capacityViewHdr.PlantDept) && sortType == CapacityView.SORT_TYPE.DEPT_REQUIRMENT ) )
                rowList.Add("");
            else
                rowList.Add(capacityViewHdr.PlantDept);
            splantDeptForReport= capacityViewHdr.PlantDept;
        
            //reqname
            rowList.Add( i== istartShowIndex ? capacityViewHdr.ReqName : "");        

            listView.Items.Add(rowList);
        }

        CapacityViewContainer capacityViewContainer = capacityViewHdr.getList((CapacityView.SHOW_TYPE)i);

        for (int j=0; j < capacityViewContainer.Count;j++){ //loop on every shift
            capacityView= capacityViewContainer[j];
            rowList.Add(capacityView.getCellValue());
        } 
        
        bprocess = capacityViewHdr.ReqType.Equals(CapacityReq.REQUIREMENT_MACHINE);
    }
}

private
bool loadRequirmentInfo(CapacityView capacityViewSample,CapacityViewContainer capacityViewContainer,CapacityViewContainer capacityViewContainerAvailCapacity,ScheduleHdr scheduleHdr){
    //int             icountInfoByReq= (int)CapacityView.SHOW_TYPE.CUMULATIVE_PERCENTAGE;    
    int             icountInfoByReq= (int)CapacityView.SHOW_TYPE.SCHEDULE_TIME;    
    CapacityView    capacityView = null;
    CapacityView    capacityViewAux = null;
    CapacityView    capacityViewCumulativeShift = null;
    CapacityView    capacityViewCumulativeMachineShiftHours = null;
    CapacityView    capacityViewAvailCapacity = null;
    CapacityView    capacityViewPastDue = null;
    CapacityView    capacityViewCumPercent=null;

    CapacityViewHdr capacityViewHdr= coreFactory.createCapacityViewHdr();
    bool            bprocess = true;
    ArrayList       arrayDateTimeWeek = CapacityView.getDateTimeWeekList();
    DateTime        startDate = DateTime.Now;
    DateTime        endDate = DateTime.Now;
            
    capacityViewHdr.copy(capacityViewSample); //copy main requirment fields and then add to list
    this.capacityViewHdrContainer.Add(capacityViewHdr);

    for (int i= 0; i <= icountInfoByReq && bprocess; i++){
          
        for (int j=0; j < capacityViewContainer.Count;j++){ //loop on every shift
            capacityView= capacityViewContainer[j];
            capacityViewAvailCapacity = capacityViewContainerAvailCapacity[j];

            if (j==0)
                capacityViewPastDue = capacityView;//load past due

            switch (i){
                case 0:
                    capacityView.ShowType = CapacityView.SHOW_TYPE.TYPE_NORMAL;      
                    capacityViewHdr.addToList(coreFactory.cloneCapacityView(capacityView));
                    break;
                case 1:                    
                    capacityViewAux = coreFactory.cloneCapacityView(capacityView);
                    capacityViewAux.ShowType = CapacityView.SHOW_TYPE.TYPE_MACHSHIFTHOURS;                                            
                    capacityViewHdr.addToList(coreFactory.cloneCapacityView(capacityViewAux));
                    /*
                    MessageBox.Show("Week :" + capacityViewAux.Title + "\n" +
                                    "ShowType :" + (int)capacityViewAux.ShowType + "\n" +
                                    "Hours :" + capacityViewAux.Hours.ToString("0.00") + "\n" +
                                    "DirectHoursToShifts :" + capacityViewAux.DirectHoursToShifts.ToString("0.00") + "\n" +
                                    "value:" + capacityViewAux.getCellValue());                     */
                    break;

                case 2:                    
                    if (capacityViewCumulativeShift == null){
                        capacityViewCumulativeShift=coreFactory.cloneCapacityView(capacityView);
                        capacityViewCumulativeShift.ShowType = CapacityView.SHOW_TYPE.CUMULATIVE_SHIFTS;
                    }else{
                        capacityViewCumulativeShift.Hours+= capacityView.Hours;                            
                    }                     
                    capacityViewHdr.addToList(coreFactory.cloneCapacityView(capacityViewCumulativeShift));
                    break;

                case 3:                            
                    if (capacityViewCumulativeMachineShiftHours == null){
                        capacityViewCumulativeMachineShiftHours=coreFactory.cloneCapacityView(capacityView);
                        capacityViewCumulativeMachineShiftHours.ShowType = CapacityView.SHOW_TYPE.CUMULATIVE_MACHSHIFTHOURS;
                    }else{
                        capacityViewCumulativeMachineShiftHours.Hours+= capacityView.Hours;                            
                    }                     
                    capacityViewHdr.addToList(coreFactory.cloneCapacityView(capacityViewCumulativeMachineShiftHours));
                    break;

                case 4:  //percentage
                    capacityViewAux = coreFactory.cloneCapacityView(capacityView);
                    if (j==1 && capacityViewPastDue!=null)  //Week0 = Week0 + PastDue
                        capacityViewAux.Hours+= capacityViewPastDue.Hours;

                    capacityViewAux.ShowType = CapacityView.SHOW_TYPE.PERCENTAGE;  
                    capacityViewAux.AvailableCapacity = capacityViewAvailCapacity.AvailableCapacity;    
                                                                
                    capacityViewHdr.addToList(capacityViewAux);
                    break;

                case 5://cumulative percentage                    
                    if (capacityViewCumPercent == null){
                        capacityViewCumPercent = coreFactory.cloneCapacityView(capacityView);
                        capacityViewCumPercent.ShowType = CapacityView.SHOW_TYPE.CUMULATIVE_PERCENTAGE;
                    }else{
                        capacityViewCumPercent.Hours+= capacityView.Hours;                            
                        capacityViewCumPercent.AvailableCapacity+= capacityViewAvailCapacity.AvailableCapacity;
                    }                                            
                    capacityViewHdr.addToList(coreFactory.cloneCapacityView(capacityViewCumPercent));
                    break;

                case 6://schedule time
                    capacityViewAux = coreFactory.cloneCapacityView(capacityView);
                    capacityViewAux.ShowType = CapacityView.SHOW_TYPE.SCHEDULE_TIME;
                    capacityViewAux.Hours = 0;
                                    
                    if (arrayDateTimeWeek.Count > j && scheduleHdr!= null){
                        startDate = (DateTime) arrayDateTimeWeek[j];                                        
                        if (j ==0){  //past due
                            endDate = startDate;
                            startDate = DateUtil.MinValue;
                        }else
                            DateUtil.getPriorMondayNextSundayFromDate(startDate, out startDate, out endDate);   

                        capacityViewAux.Hours=0;
                        if (capacityViewAux.ReqType.Equals(Constants.TYPE_MACHINE))
                            capacityViewAux.Hours = scheduleHdr.getTotalHrsByMachineDateRange(capacityViewAux.ReqId, startDate,endDate);                                                     
                    }
                    capacityViewHdr.addToList(capacityViewAux);
                    break;
             }  
        } 
        
        bprocess = capacityViewSample.ReqType.Equals(CapacityReq.REQUIREMENT_MACHINE);
    }
    return true;
}


public
void loadShiftRemaining(MachineContainer machineContainer,bool bincludeProduction){
    try{ 
        DateTime    startDate   = DateTime.Now;
        DateTime    endDate     = DateTime.Now;        
        Hashtable   hashPrHistSumCurrWeek = new Hashtable();
        decimal     dhours = 0; 
        string      splant = getPlant();
    
        DateUtil.getPriorMondayNextSundayFromDate(startDate,out startDate,out endDate);

        if (bincludeProduction)//production            
            this.getProductionPrHistSum(ref hashPrHistSum, ref prHistDateTimeChecked, "", -1, splant,dSweek0, dEweek0);//check production
     
        for (int i=0; i < machineContainer.Count;i++){
            MachineView machineView  = (MachineView)machineContainer[i];

            dhours = (int)getCoreFactory().loadPlannedHdrHoursByMachineRangeDate(plannedHdr, hashPrHistSumCurrWeek, machineView.Id, startDate, endDate, hashRouting) / machineView.DirectHoursToShifts;
            machineView.RemainsShifts = Convert.ToInt32(dhours);
        }

    } catch (Exception ex) {
        MessageBox.Show("loadShiftRemaining Exception: " + ex.Message);        
    }
}

public
MachineContainer recalcMachinePriority(bool bincludeProduction){
    MachineContainer    machineContainer = getCoreFactory().createMachineContainer();
    try{ 
        string              splant = getPlant();
        Hashtable           hashPrHistSum = new Hashtable();
                                 
        if (bincludeProduction){//production            
            realodWeeksRanges();
            this.getProductionPrHistSum(ref hashPrHistSum, ref prHistDateTimeChecked, "", -1, splant,dSweek0,dEweek0);//check production
        }

        capacityHdr = getCoreFactory().readCapacityHdrLastDateCheck(capacityHdr,splant);
        plannedHdr = getCoreFactory().readPlannedHdrLastDateCheck(plannedHdr,splant);

        machineContainer = getCoreFactory().loadMachinePlannedHdrShiftRemainings(plannedHdr,capacityHdr,splant, hashPrHistSum,hashRouting);        
               
    } catch (Exception ex) {
        MessageBox.Show("recalcMachinePriority Exception: " + ex.Message);        
    }
    return machineContainer;
}
          

}
}
