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
using Nujit.NujitERP.ClassLib.Core.Planned;
using Nujit.NujitERP.ClassLib.Common;


namespace HotListReports.Windows.Labour { 

class LabourViewsModel : HotListReports.Windows.Util.ReportTypeViewsModel /*ReportTypeViewsModel*/  {
        
private ListView    labourPlanningListView;
private Hashtable   hashMachines;
private Hashtable   hashRoutings;
private Hashtable   hashMachinesById;
private Hashtable   hashTasks;
private Hashtable   hashProfilesByDates;

private Hashtable       hashPrHistSum;
private DateTime        prHistDateTimeChecked;

private LabourPlanningReportViewContainer       labourPlanningReportViewContainer;
private LabourPlanningReportView                labourPlanningReportViewSel;
private LabourPlanningReportView                labourPlanningReportViewSum;
private LabourPlanningReportShiftViewContainer  labourPlanningReportShiftViewContainer;
private LabourPlanningReportShiftViewContainer  labourPlanningReportShiftViewSumContainer;
private TextBox                                 textBoxShiftLastFocused;
private EmployeeContainer                       employeeContainer;
private ArrayList                               arrayPlanningReportShiftView;

private LabourPlanningReportViewContainer       labourPlanningReportViewAllMachinesContainer;//store just to not load again, if not needed
private HotListHdr                              hotListHdrAllMachines;


public LabourViewsModel(Window window,ListView labourPlanningListView) : base(window){    
    this.labourPlanningListView = labourPlanningListView;
    this.hashMachines       = new Hashtable();
    this.hashRoutings       = new Hashtable();
    this.hashMachinesById   = new Hashtable();
    this.hashTasks          = new Hashtable();
    this.hashProfilesByDates= new Hashtable();

    this.hashPrHistSum      = new Hashtable();
    this.prHistDateTimeChecked = DateUtil.MinValue;

    this.labourPlanningReportViewContainer = getCoreFactory().createLabourPlanningReportViewContainer();    
    this.labourPlanningReportViewSel=null;
    this.labourPlanningReportViewSum=null;
    this.labourPlanningReportShiftViewContainer = getCoreFactory().createLabourPlanningReportShiftViewContainer();
    this.labourPlanningReportShiftViewSumContainer = getCoreFactory().createLabourPlanningReportShiftViewContainer();
    this.textBoxShiftLastFocused = null;
    this.employeeContainer = getCoreFactory().createEmployeeContainer();
    this.arrayPlanningReportShiftView = new ArrayList();

    this.labourPlanningReportViewAllMachinesContainer = getCoreFactory().createLabourPlanningReportViewContainer(); 
    this.hotListHdrAllMachines = null;
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
EmployeeContainer EmployeeContainer{
	get { return employeeContainer; }
	set {
        this.employeeContainer = value;					
	}
}

public
LabourPlanningReportViewContainer LabourPlanningReportViewAllMachinesContainer{
	get { return labourPlanningReportViewAllMachinesContainer; }
	set { 
        this.labourPlanningReportViewAllMachinesContainer = value;
    }
}

public
HotListHdr HotListHdrAllMachines{
	get { return hotListHdrAllMachines; }
	set { 
        this.hotListHdrAllMachines = value;
    }
}

public
void reloadAllHashTasks(){
    reloadAllTasks(hashTasks);
}

public
bool checkIfNeedToReloadAllMachinesRequired(string splant){
    bool            bresult=true;    
    try { 
        HotListHdr      hotListHdr = getCoreFactory().readLastHotList(splant);

        //could change plan or hotlisthdr or dates already processed
        if (hotListHdrAllMachines!= null && hotListHdr!= null && hotListHdr.Id == hotListHdrAllMachines.Id){//check if HotList already process, does not change id

            if (labourPlanningReportViewAllMachinesContainer.Count > 0){ //check if current datetime on range date already processed
                LabourPlanningReportView    labourPlanningReportView    = labourPlanningReportViewAllMachinesContainer[0];
                CellPlanningLabType         weekCell0                   = labourPlanningReportView.WeekCell0;
            
                if (weekCell0 != null && weekCell0.StartDate <= DateTime.Now && DateTime.Now <= weekCell0.EndDate)                        
                    bresult=false;
            }
        }

    } catch (Exception ex) {
        MessageBox.Show("checkIfNeedToReloadAllMachinesRequired Exception: " + ex.Message);        
    }
    return bresult;
}

public
ArrayList ArrayPlanningReportShiftView {
	get { return arrayPlanningReportShiftView; }
	set {
        this.arrayPlanningReportShiftView = value;					
	}
}

public
void loadColumnsOnHeaderGrid(ListView hdrListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));

        textBlockColumnListView = new TextBlockColumnListView("Id", "Id", BindingMode.OneWay, 50, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Plt", "Plt", BindingMode.OneWay,50, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Dept", "Dept", BindingMode.OneWay,50, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Machine", "Mach", BindingMode.OneWay,100, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Description 1", "Des1", BindingMode.OneWay,180, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Description 2", "Des2", BindingMode.OneWay,180, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("MachType", "MachTyp", BindingMode.OneWay,70, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Dir.Hrs.Shift", "DirectHoursToShifts", BindingMode.OneWay,70, hdrListView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        gridView.Columns.Add(textBlockColumnListView.process());

        hdrListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}
   
/************************************* Labour Planning *********************************************************************/
public
LabourPlanningReportViewContainer loadLabourTypePlanning(out HotListHdr hotListHdr,ListView listView,TabItem tabItem,
                                                        string splant,string sdept,string srequirment,int imachineId,string spart, DateTime dateWeek){
    hotListHdr = null;
    labourPlanningReportViewContainer = getCoreFactory().createLabourPlanningReportViewContainer();
    try{                 
        labourPlanningReportViewSel = (LabourPlanningReportView)getSelected(listView);
        hotListHdr = getCoreFactory().readLastHotList(splant);
        scheduleHdr = getCoreFactory().readScheduleHdrLastDateCheck(scheduleHdr,splant);
        LabourTypeRequiredContainer         labourTypeRequiredContainer = getCoreFactory().createLabourTypeRequiredContainer();
        plannedHdr = getCoreFactory().readPlannedHdrLastDateCheck(plannedHdr,splant);

        loadAllTasks(hashTasks);

        hashProfilesByDates = getCoreFactory().readCapShiftProfilesForWeekHash(splant,Constants.STATUS_ACTIVE,DateTime.Now,DateTime.Now.AddDays(90), imachineId,false);
                                        
        realodWeeksRanges();        
        rewriteLabourTypePlanningListView(listView);

        if (hotListHdr!= null) {

            //Required - Planned + temp + New Hires - Vacations - Sicks = Net
            /*
            Required
            Planned
            Summary
            Temp
            New Hire
            OT
            Vacation
            Sick/Absent*/

            loadLabourTypePlaningRequired(labourPlanningReportViewContainer, hotListHdr,splant, sdept, srequirment, imachineId, spart, dateWeek);
            loadLabourTypePlanningPlanned(labourPlanningReportViewContainer, plannedHdr, splant, sdept, srequirment, imachineId, spart, dateWeek);
            loadLabourTypePlaningNet(labourPlanningReportViewContainer);
            loadLabourTypeDaysPerWeek(labourPlanningReportViewContainer,imachineId);
            loadLabourTypeSummary(labourPlanningReportViewContainer);
        }
        
        setDataContextListView(listView,labourPlanningReportViewContainer);    
        setSelected(listView,labourPlanningReportViewSel);                    
        
    } catch (Exception ex) {
        MessageBox.Show("loadLabourTypePlanning Exception: " + ex.Message);        
    }
    return labourPlanningReportViewContainer;
}

private
CellPlanningLabType createCellPlanningLabType(CellPlanningLabType cellPlanningLabType,int i,int j){    
    cellPlanningLabType.Overtime = (i * 3) + j + 9;
    cellPlanningLabType.Temp = (i * 2);
    cellPlanningLabType.Required = ((i + 3) * 2) * j;
    cellPlanningLabType.Planned = ((i + 7) * 2) * j + 10;
    cellPlanningLabType.Net = ( (i * 2) + 5) * 2 + j + 6;
    cellPlanningLabType.Index = i;

    return  cellPlanningLabType;
}

private
void rewriteLabourTypePlanningListView(ListView listView){
    try { 
        createListViewColumns(listView, CapacityView.TITLE_COUNTS+3);
        GridView                view = (GridView)listView.View;        
        string                  sweek ="";
        string                  space ="   ";
        double                  dcornerRadius = 6;
        double                  dwith =60;
        double                  dheight =20;
        double                  dfonSize =12;
        string                  sbindPanel = "";
        int                     icolumnIndex = 3;
        FontWeight              fontWeight = FontWeights.UltraBold;        
        ListViewCol             listViewCol = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
        cell.Setters.Add(new Setter(Control.FontSizeProperty, dfonSize));
        Setter          textAlignSetter = new Setter(Control.HorizontalContentAlignmentProperty, HorizontalAlignment.Left);
        cell.Setters.Add(textAlignSetter);      
                    
        for (int i=0; i < view.Columns.Count;i++){
            GridViewColumn column = (GridViewColumn)view.Columns.ElementAt(i);
        
            listViewCol = new ListViewCol();
            sbindPanel = "";
            if (i > 1) { 
                fontWeight = FontWeights.Bold;
                dcornerRadius = 0;
                sweek = i > 2  ? "Week" + (i- icolumnIndex) : "PastDue";
                sweek = (i - icolumnIndex) == 0 ? CapacityView.TITLE_WEEK0 : sweek;                
                sbindPanel = i > 2 ? "WeekCell" + (i - icolumnIndex) : "WeekCellPastDue";         

                listViewCol.addTextBox("Required",  false,true ,dwith, dheight, dfonSize,fontWeight,TextAlignment.Left,Colors.Black,Colors.Gray);            
                listViewCol.setConverter( new DecimalToStringConverterNew(),"0.0");                                  
                listViewCol.addTextBox("Planned",  false,true ,dwith, dheight, dfonSize,fontWeight,TextAlignment.Left,Colors.Black,Colors.Gray);            
                listViewCol.setConverter( new DecimalToStringConverterNew(),"0.0");
                createdEditableTextBoxOnListView(listView,listViewCol,"Temp",       dwith,dheight,dfonSize,fontWeight,"T");
                listViewCol.setConverter( new DecimalToStringConverterNew(),"int");

                createdEditableTextBoxOnListView(listView,listViewCol,"NewHire",    dwith,dheight,dfonSize,fontWeight,"H");
                listViewCol.setConverter( new DecimalToStringConverterNew(),"int");
                createdEditableTextBoxOnListView(listView,listViewCol,"Vacation",   dwith,dheight,dfonSize,fontWeight,"V");
                listViewCol.setConverter(new DecimalToStringConverterNew(),"int");                                       
                createdEditableTextBoxOnListView(listView,listViewCol,"SickAbsent", dwith,dheight,dfonSize,fontWeight,"A");                
                listViewCol.setConverter(new DecimalToStringConverterNew(),"int");
                createdEditableTextBoxOnListView(listView,listViewCol,"Overtime",   dwith,dheight,dfonSize,fontWeight,"O");
                listViewCol.setConverter(new DecimalToStringConverterNew(),"int");

                listViewCol.addTextBox("Net", false, true, dwith, dheight, dfonSize, fontWeight, TextAlignment.Left, Colors.Black, Colors.Gray);
                listViewCol.setConverter( new DecimalToStringConverterNew(),"0.0");                              
            }
            
            column.HeaderContainerStyle = cell;        
            if (i == 2) column.Width = 0;       //set past due Width =0
            else        column.Width = dwith+10;
                
            switch (i){
                case 0:                    
                    column.Header = space + "Id" + "\n" + space +"Name" + "\n" + space + "DirInd";                
                    column.Width = 200;
                    listViewCol.addTextBlock("ReqId"  ,180,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_SELECT_FONT,UIColors.COLOR_STACK_SELECT);
                    listViewCol.addTextBlock("LabName",180,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_SELECT_FONT,UIColors.COLOR_STACK_SELECT);
                    listViewCol.addTextBlock("DirInd", 180,dheight,dfonSize, fontWeight,TextAlignment.Left,UIColors.COLOR_STACK_SELECT_FONT,UIColors.COLOR_STACK_SELECT);
                    for (int j=0;j < 5;j++)
                        listViewCol.addTextBlock(j.ToString(),180,dheight,dfonSize, fontWeight,TextAlignment.Left, UIColors.COLOR_STACK_SELECT_FONT, UIColors.COLOR_STACK_SELECT);
                    break;
                case 1:
                    column.Header = space + "Desc";
                    sbindPanel = "CellTitles";                
                    column.Width = 100;
                    listViewCol.addTextBlock("Title1",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left, UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);
                    listViewCol.addTextBlock("Title2",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left, UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);
                    listViewCol.addTextBlock("Title3",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left, UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);     
                    listViewCol.addTextBlock("Title4",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left, UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);
                    listViewCol.addTextBlock("Title5",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left, UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);     
                    listViewCol.addTextBlock("Title6",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left, UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);     
                    listViewCol.addTextBlock("Title7",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left, UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);
                    listViewCol.addTextBlock("Title8",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left, UIColors.COLOR_STACK_FONT, Colors.AntiqueWhite);
                    break;
                case 2:
                    column.Header = space + sweek;
                    break;
                default:                            
                    column.Header = space + sweek + "\n" + space + DateUtil.getDateRepresentation(this.dSweek0.AddDays(7*(i- icolumnIndex)),DateUtil.MMDDYYYY).Substring(0,5);
                    break;              
            }                  
            column.CellTemplate = listViewCol.getDataTemplate(sbindPanel,dcornerRadius,1,Colors.Silver);                                             
        }    

    } catch (Exception ex) {
        MessageBox.Show("rewriteLabourTypePlanningListView Exception: " + ex.Message);        
    }
}

private
FrameworkElementFactory createdEditableTextBoxOnListView(ListView listView,ListViewCol listViewCol,string sbind,double dwith,double dheight,double dfonSize,FontWeight fontWeight,string stype) {
    FrameworkElementFactory frameworkElementFactoryTextBox = listViewCol.addTextBox(sbind,true,false,dwith, dheight, dfonSize,fontWeight,TextAlignment.Left, Colors.Black,Colors.White);
    frameworkElementFactoryTextBox.SetValue(TextBox.MaxLengthProperty, Int32.MaxValue.ToString().Length-1);
    listViewCol.setConverter( new DecimalToStringConverterNew(), "0.0"); //sending format only 1 decimal

    switch (stype) {        
        default:
            frameworkElementFactoryTextBox.AddHandler(TextBox.LostFocusEvent, new RoutedEventHandler(plannedLabourTypeTextBox_LostFocus));
            break;
    }    
    frameworkElementFactoryTextBox.AddHandler(TextBox.GotFocusEvent, new RoutedEventHandler(plannedLabourTypeTextBox_GotFocus));

    return frameworkElementFactoryTextBox;
}


private 
void plannedLabourTypeTextBox_LostFocus(object sender, RoutedEventArgs e){
    plannedLabourTypeTextBox((TextBox)sender);    
}

private 
void plannedLabourTypeTextBox_GotFocus(object sender, RoutedEventArgs e){
    plannedLabourTypeTextBoxGotFocus((TextBox)sender);    
}


private 
bool plannedLabourTypeTextBox(TextBox textBox){
    bool    bresult=false;
    try {         
        Panel   panel = null;

        if (textBox!= null && textBox.Parent!= null && getCoreFactory()!=null){
            panel = (Panel)textBox.Parent;
            CellPlanningLabType cellPlanningLabType = (CellPlanningLabType)panel.DataContext;
            if (cellPlanningLabType != null) { 
                PlannedLabourContainer      plannedLabourContainer= cellPlanningLabType.PlannedLabourContainer;
                LabourPlanningReportView    machineReportPartView = (LabourPlanningReportView)getSelected(this.labourPlanningListView);                            
                PlannedLabour               plannedLabour= plannedLabourContainer.Count > 0? plannedLabourContainer[0] : null;
                bool                        bprocess =true;

                if (plannedLabour == null && cellPlanningLabType.Overtime == 0 && cellPlanningLabType.Temp == 0 
                                          && cellPlanningLabType.NewHire == 0 && cellPlanningLabType.SickAbsent== 0 && cellPlanningLabType.Vacation == 0)
                    bprocess =false;

                if (plannedLabour != null &&  plannedLabour.TotEmployOver == cellPlanningLabType.Overtime && 
                    plannedLabour.TotEmployTemp == cellPlanningLabType.Temp && plannedLabour.TotEmployHire == cellPlanningLabType.NewHire && 
                    plannedLabour.TotEmployAbsent == cellPlanningLabType.SickAbsent && plannedLabour.TotEmployVacation  == cellPlanningLabType.Vacation) //check if any value changed
                    bprocess =false;                

                if (machineReportPartView!= null && bprocess){
                   plannedLabour = getCoreFactory().generateNewPlannedLabourBasedPlanned(plannedHdr,plannedHdr.Plant, machine!= null ? machine.Id:0,0,machineReportPartView,cellPlanningLabType);
                   cellPlanningLabType.PlannedLabourContainer.Remove(plannedLabour);
                   cellPlanningLabType.PlannedLabourContainer.Add(plannedLabour);
                }                 
            }
        }        

    } catch (Exception ex) {
        MessageBox.Show("plannedLabourTypeTextBox Exception: " + ex.Message);        
    }
    return bresult;
}

private 
bool plannedLabourTypeTextBoxGotFocus(TextBox textBox){
    bool    bresult=false;
    try {         
        Panel   panel = null;

        if (textBox!= null && textBox.Parent!= null && getCoreFactory()!=null){
            panel = (Panel)textBox.Parent;
            CellPlanningLabType cellPlanningLabType = (CellPlanningLabType)panel.DataContext;
            
            if (cellPlanningLabType != null && cellPlanningLabType.Index < this.labourPlanningListView.Items.Count) { 
                this.labourPlanningListView.SelectedIndex = cellPlanningLabType.Index;
            }
        }        

    } catch (Exception ex) {
        MessageBox.Show("plannedTextBoxGotFocus Exception: " + ex.Message);        
    }
    return bresult;
}

private
void loadLabourTypePlaningRequired(LabourPlanningReportViewContainer labourPlanningReportViewContainer, HotListHdr hotListHdr,string splant, string sdept, string srequirment,int imachineId,string spart, DateTime dateWeek){
    try{
        LabourTypeRequiredContainer labourTypeRequiredContainer  = getCoreFactory().createLabourTypeRequiredContainer();
        LabourTypeRequired          labourTypeRequired = null;
        LabourPlanningReportView    labourPlanningReportView = null;

        if (hotListHdr!= null) { 
            labourTypeRequiredContainer = getCoreFactory().getHotListLabourType2(hashMachines,hashRoutings,hashTasks,scheduleHdr, hotListHdr.Id, hotListHdr.Plant,splant,sdept,srequirment, imachineId,spart,-1,"","","",true,false,false,false,0);
        
            for (int i=0; i < labourTypeRequiredContainer.Count;i++)  {          
                labourTypeRequired = labourTypeRequiredContainer[i];                
            
                labourPlanningReportView = getCoreFactory().createLabourPlanningReportView();

                labourPlanningReportView.ReqId  = labourTypeRequired.Id;
                labourPlanningReportView.Labour = labourTypeRequired.Code;
                labourPlanningReportView.LabName= labourTypeRequired.LabName;
                labourPlanningReportView.DirInd = labourTypeRequired.DirInd; 
                labourPlanningReportView.ReqType= Constants.TYPE_LABOUR;

                labourPlanningReportView.WeekCellPastDue.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dPastDue,dPastDue);
                labourPlanningReportView.WeekCell0.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek0,dEweek0);
                labourPlanningReportView.WeekCell1.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek1,dEweek1);
                labourPlanningReportView.WeekCell2.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek2,dEweek2);

                labourPlanningReportView.WeekCell3.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek3,dEweek3);
                labourPlanningReportView.WeekCell4.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek4,dEweek4);
                labourPlanningReportView.WeekCell5.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek5,dEweek5);
                labourPlanningReportView.WeekCell6.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek6,dEweek6);
                labourPlanningReportView.WeekCell7.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek7,dEweek7);
                labourPlanningReportView.WeekCell8.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek8,dEweek8);
                labourPlanningReportView.WeekCell9.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek9,dEweek9);
                labourPlanningReportView.WeekCell10.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek10,dEweek10);
                labourPlanningReportView.WeekCell11.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek11,dEweek11);
                labourPlanningReportView.WeekCell12.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek12,dEweek12);
                labourPlanningReportView.WeekCell13.Required+= labourTypeRequired.getQtyByRangeDate(hotListHdr.HotlistRunDate,dSweek13,dEweek13);                
                
                labourPlanningReportViewContainer.Add(labourPlanningReportView);
            }
        }


    } catch (Exception ex) {
        MessageBox.Show("loadLabourTypePlaningRequired Exception: " + ex.Message);        
    }
}

private
void loadLabourTypePlanningPlanned(LabourPlanningReportViewContainer labourPlanningReportViewContainer,PlannedHdr plannedHdr, string splant, string sdept, string srequirment,int imachineId,string spart, DateTime dateWeek){
    try{
        LabourTypeRequiredContainer labourTypeRequiredContainer  = getCoreFactory().createLabourTypeRequiredContainer();        
        CapShiftTaskContainer       capShiftTaskContainer = getCoreFactory().createCapShiftTaskContainer();
        
        if (plannedHdr != null) {
            getCoreFactory().getPlannedLabourType(labourPlanningReportViewContainer,plannedHdr,hashMachinesById,hashRoutings,hashTasks,splant,sdept,imachineId, spart, -1,"",true,-1);
        }

    } catch (Exception ex) {
        MessageBox.Show("loadLabourTypePlanningPlanned Exception: " + ex.Message);        
    }
}

private
void loadLabourCell(CellPlanningLabType cellPlanningLabType, PlannedLabour plannedLabour,CapShiftTask capShiftTask,
                    DateTime startDate,DateTime endDate){

    bool        bisOverTime= capShiftTask != null ? capShiftTask.isOvertime()   :false;
    bool        bisTemp    = capShiftTask != null ? capShiftTask.isTemp()       :false;
    
    if (plannedLabour.betweenRange(startDate, endDate)) { 
        cellPlanningLabType.PlannedLabourContainer.Add(plannedLabour);

        cellPlanningLabType.Planned     += plannedLabour.TotEmployPlan;
        cellPlanningLabType.Overtime    += plannedLabour.TotEmployOver;            
        cellPlanningLabType.Temp        += plannedLabour.TotEmployTemp;        

        cellPlanningLabType.NewHire     += plannedLabour.TotEmployHire;
        cellPlanningLabType.SickAbsent  += plannedLabour.TotEmployAbsent;            
        cellPlanningLabType.Vacation    += plannedLabour.TotEmployVacation;      
    }
}

private
void loadLabourTypePlaningNet(LabourPlanningReportViewContainer labourPlanningReportViewContainer){
    try{
        LabourPlanningReportView labourPlanningReportView = null;                            
        for (int i=0; i < labourPlanningReportViewContainer.Count;i++) {                
            labourPlanningReportView = (LabourPlanningReportView)labourPlanningReportViewContainer[i];
    
            //Required + Planned, because required is negative on hotlist , no matter Net is calculated on Net get            
            labourPlanningReportView.WeekCellPastDue.StartDate = labourPlanningReportView.WeekCellPastDue.EndDate = dPastDue;
            labourPlanningReportView.WeekCellPastDue.Index = i;
            
            labourPlanningReportView.WeekCell0.StartDate   = this.dSweek0;
            labourPlanningReportView.WeekCell0.EndDate     = this.dEweek0;
            labourPlanningReportView.WeekCell0.Index = i;
            
            labourPlanningReportView.WeekCell1.StartDate   = this.dSweek1;
            labourPlanningReportView.WeekCell1.EndDate     = this.dEweek1;
            labourPlanningReportView.WeekCell1.Index = i;

            labourPlanningReportView.WeekCell2.StartDate   = this.dSweek2;
            labourPlanningReportView.WeekCell2.EndDate     = this.dEweek2;
            labourPlanningReportView.WeekCell2.Index = i;

            labourPlanningReportView.WeekCell3.StartDate   = this.dSweek3;
            labourPlanningReportView.WeekCell3.EndDate     = this.dEweek3;
            labourPlanningReportView.WeekCell3.Index = i;

            labourPlanningReportView.WeekCell4.StartDate   = this.dSweek4;
            labourPlanningReportView.WeekCell4.EndDate     = this.dEweek4;
            labourPlanningReportView.WeekCell4.Index = i;

            labourPlanningReportView.WeekCell5.StartDate   = this.dSweek5;
            labourPlanningReportView.WeekCell5.EndDate     = this.dEweek5;
            labourPlanningReportView.WeekCell5.Index = i;

            labourPlanningReportView.WeekCell6.StartDate   = this.dSweek6;
            labourPlanningReportView.WeekCell6.EndDate     = this.dEweek6;
            labourPlanningReportView.WeekCell6.Index = i;

            labourPlanningReportView.WeekCell7.StartDate   = this.dSweek7;
            labourPlanningReportView.WeekCell7.EndDate     = this.dEweek7;
            labourPlanningReportView.WeekCell7.Index = i;

            labourPlanningReportView.WeekCell8.StartDate   = this.dSweek8;
            labourPlanningReportView.WeekCell8.EndDate     = this.dEweek8;
            labourPlanningReportView.WeekCell8.Index = i;

            labourPlanningReportView.WeekCell9.StartDate   = this.dSweek9;
            labourPlanningReportView.WeekCell9.EndDate     = this.dEweek9;
            labourPlanningReportView.WeekCell9.Index = i;

            labourPlanningReportView.WeekCell10.StartDate   = this.dSweek10;
            labourPlanningReportView.WeekCell10.EndDate     = this.dEweek10;
            labourPlanningReportView.WeekCell10.Index = i;
            
            labourPlanningReportView.WeekCell11.StartDate   = this.dSweek11;
            labourPlanningReportView.WeekCell11.EndDate     = this.dEweek11;
            labourPlanningReportView.WeekCell11.Index = i;

            labourPlanningReportView.WeekCell12.StartDate   = this.dSweek12;
            labourPlanningReportView.WeekCell12.EndDate     = this.dEweek12;
            labourPlanningReportView.WeekCell12.Index = i;

            labourPlanningReportView.WeekCell13.StartDate   = this.dSweek13;
            labourPlanningReportView.WeekCell13.EndDate     = this.dEweek13;
            labourPlanningReportView.WeekCell13.Index = i;
        }

    } catch (Exception ex) {
        MessageBox.Show("loadMachinePartsNet Exception: " + ex.Message);        
    }
}

private
void loadLabourTypeDaysPerWeek(LabourPlanningReportViewContainer labourPlanningReportViewContainer,int imachineId){
    try{
        Hashtable hashProfilesAux = new Hashtable();

        foreach (DictionaryEntry pair in hashProfilesByDates){
            DateTime date = (DateTime)pair.Key;
            hashProfilesAux.Add(date,getDaysPerWeek(date,imachineId));            
        }

        LabourPlanningReportView labourPlanningReportView = null;                            
        for (int i=0; i < labourPlanningReportViewContainer.Count;i++) {                
            labourPlanningReportView = (LabourPlanningReportView)labourPlanningReportViewContainer[i];
    
            labourPlanningReportView.WeekCell0.DaysPerWeek  = getDaysPerWeek(labourPlanningReportView.WeekCell0.StartDate,hashProfilesAux);
            labourPlanningReportView.WeekCell1.DaysPerWeek  = getDaysPerWeek(labourPlanningReportView.WeekCell1.StartDate,hashProfilesAux);
            labourPlanningReportView.WeekCell2.DaysPerWeek  = getDaysPerWeek(labourPlanningReportView.WeekCell2.StartDate,hashProfilesAux);
            labourPlanningReportView.WeekCell3.DaysPerWeek  = getDaysPerWeek(labourPlanningReportView.WeekCell3.StartDate,hashProfilesAux);
            labourPlanningReportView.WeekCell4.DaysPerWeek  = getDaysPerWeek(labourPlanningReportView.WeekCell4.StartDate,hashProfilesAux);
            labourPlanningReportView.WeekCell5.DaysPerWeek  = getDaysPerWeek(labourPlanningReportView.WeekCell5.StartDate,hashProfilesAux);
            labourPlanningReportView.WeekCell6.DaysPerWeek  = getDaysPerWeek(labourPlanningReportView.WeekCell6.StartDate,hashProfilesAux);
            labourPlanningReportView.WeekCell7.DaysPerWeek  = getDaysPerWeek(labourPlanningReportView.WeekCell7.StartDate,hashProfilesAux);
            labourPlanningReportView.WeekCell8.DaysPerWeek  = getDaysPerWeek(labourPlanningReportView.WeekCell8.StartDate,hashProfilesAux);
            labourPlanningReportView.WeekCell9.DaysPerWeek  = getDaysPerWeek(labourPlanningReportView.WeekCell9.StartDate,hashProfilesAux);
            labourPlanningReportView.WeekCell10.DaysPerWeek = getDaysPerWeek(labourPlanningReportView.WeekCell10.StartDate,hashProfilesAux);
            labourPlanningReportView.WeekCell11.DaysPerWeek = getDaysPerWeek(labourPlanningReportView.WeekCell11.StartDate,hashProfilesAux);
            labourPlanningReportView.WeekCell12.DaysPerWeek = getDaysPerWeek(labourPlanningReportView.WeekCell12.StartDate,hashProfilesAux);
            labourPlanningReportView.WeekCell13.DaysPerWeek = getDaysPerWeek(labourPlanningReportView.WeekCell13.StartDate,hashProfilesAux);

            labourPlanningReportView.WeekCell0.Required = labourPlanningReportView.WeekCell0.Required  / labourPlanningReportView.WeekCell0.DaysPerWeek;
            labourPlanningReportView.WeekCell1.Required = labourPlanningReportView.WeekCell1.Required  / labourPlanningReportView.WeekCell1.DaysPerWeek;
            labourPlanningReportView.WeekCell2.Required = labourPlanningReportView.WeekCell2.Required  / labourPlanningReportView.WeekCell2.DaysPerWeek;
            labourPlanningReportView.WeekCell3.Required = labourPlanningReportView.WeekCell3.Required  / labourPlanningReportView.WeekCell3.DaysPerWeek;
            labourPlanningReportView.WeekCell4.Required = labourPlanningReportView.WeekCell4.Required  / labourPlanningReportView.WeekCell4.DaysPerWeek;
            labourPlanningReportView.WeekCell5.Required = labourPlanningReportView.WeekCell5.Required  / labourPlanningReportView.WeekCell5.DaysPerWeek;
            labourPlanningReportView.WeekCell6.Required = labourPlanningReportView.WeekCell6.Required  / labourPlanningReportView.WeekCell6.DaysPerWeek;
            labourPlanningReportView.WeekCell7.Required = labourPlanningReportView.WeekCell7.Required  / labourPlanningReportView.WeekCell7.DaysPerWeek;
            labourPlanningReportView.WeekCell8.Required = labourPlanningReportView.WeekCell8.Required  / labourPlanningReportView.WeekCell8.DaysPerWeek;
            labourPlanningReportView.WeekCell9.Required = labourPlanningReportView.WeekCell9.Required  / labourPlanningReportView.WeekCell9.DaysPerWeek;
            labourPlanningReportView.WeekCell10.Required = labourPlanningReportView.WeekCell10.Required/ labourPlanningReportView.WeekCell10.DaysPerWeek;
            labourPlanningReportView.WeekCell11.Required = labourPlanningReportView.WeekCell11.Required/ labourPlanningReportView.WeekCell11.DaysPerWeek;
            labourPlanningReportView.WeekCell12.Required = labourPlanningReportView.WeekCell12.Required/ labourPlanningReportView.WeekCell12.DaysPerWeek;
            labourPlanningReportView.WeekCell13.Required = labourPlanningReportView.WeekCell13.Required/ labourPlanningReportView.WeekCell13.DaysPerWeek;            
                    
            labourPlanningReportView.WeekCell0.Planned = labourPlanningReportView.WeekCell0.Planned  / labourPlanningReportView.WeekCell0.DaysPerWeek;
            labourPlanningReportView.WeekCell1.Planned = labourPlanningReportView.WeekCell1.Planned  / labourPlanningReportView.WeekCell1.DaysPerWeek;
            labourPlanningReportView.WeekCell2.Planned = labourPlanningReportView.WeekCell2.Planned  / labourPlanningReportView.WeekCell2.DaysPerWeek;
            labourPlanningReportView.WeekCell3.Planned = labourPlanningReportView.WeekCell3.Planned  / labourPlanningReportView.WeekCell3.DaysPerWeek;
            labourPlanningReportView.WeekCell4.Planned = labourPlanningReportView.WeekCell4.Planned  / labourPlanningReportView.WeekCell4.DaysPerWeek;
            labourPlanningReportView.WeekCell5.Planned = labourPlanningReportView.WeekCell5.Planned  / labourPlanningReportView.WeekCell5.DaysPerWeek;
            labourPlanningReportView.WeekCell6.Planned = labourPlanningReportView.WeekCell6.Planned  / labourPlanningReportView.WeekCell6.DaysPerWeek;
            labourPlanningReportView.WeekCell7.Planned = labourPlanningReportView.WeekCell7.Planned  / labourPlanningReportView.WeekCell7.DaysPerWeek;
            labourPlanningReportView.WeekCell8.Planned = labourPlanningReportView.WeekCell8.Planned  / labourPlanningReportView.WeekCell8.DaysPerWeek;
            labourPlanningReportView.WeekCell9.Planned = labourPlanningReportView.WeekCell9.Planned  / labourPlanningReportView.WeekCell9.DaysPerWeek;
            labourPlanningReportView.WeekCell10.Planned = labourPlanningReportView.WeekCell10.Planned/ labourPlanningReportView.WeekCell10.DaysPerWeek;
            labourPlanningReportView.WeekCell11.Planned = labourPlanningReportView.WeekCell11.Planned/ labourPlanningReportView.WeekCell11.DaysPerWeek;
            labourPlanningReportView.WeekCell12.Planned = labourPlanningReportView.WeekCell12.Planned/ labourPlanningReportView.WeekCell12.DaysPerWeek;
            labourPlanningReportView.WeekCell13.Planned = labourPlanningReportView.WeekCell13.Planned/ labourPlanningReportView.WeekCell13.DaysPerWeek;            

            labourPlanningReportView.WeekCell0.NewHire = labourPlanningReportView.WeekCell0.NewHire;
            labourPlanningReportView.WeekCell1.NewHire = labourPlanningReportView.WeekCell1.NewHire;
            labourPlanningReportView.WeekCell2.NewHire = labourPlanningReportView.WeekCell2.NewHire;
            labourPlanningReportView.WeekCell3.NewHire = labourPlanningReportView.WeekCell3.NewHire;
            labourPlanningReportView.WeekCell4.NewHire = labourPlanningReportView.WeekCell4.NewHire;
            labourPlanningReportView.WeekCell5.NewHire = labourPlanningReportView.WeekCell5.NewHire;
            labourPlanningReportView.WeekCell6.NewHire = labourPlanningReportView.WeekCell6.NewHire;
            labourPlanningReportView.WeekCell7.NewHire = labourPlanningReportView.WeekCell7.NewHire;
            labourPlanningReportView.WeekCell8.NewHire = labourPlanningReportView.WeekCell8.NewHire;
            labourPlanningReportView.WeekCell9.NewHire = labourPlanningReportView.WeekCell9.NewHire;
            labourPlanningReportView.WeekCell10.NewHire = labourPlanningReportView.WeekCell10.NewHire;
            labourPlanningReportView.WeekCell11.NewHire = labourPlanningReportView.WeekCell11.NewHire;
            labourPlanningReportView.WeekCell12.NewHire = labourPlanningReportView.WeekCell12.NewHire;
            labourPlanningReportView.WeekCell13.NewHire = labourPlanningReportView.WeekCell13.NewHire;            

            labourPlanningReportView.WeekCell0.Vacation = labourPlanningReportView.WeekCell0.Vacation;
            labourPlanningReportView.WeekCell1.Vacation = labourPlanningReportView.WeekCell1.Vacation;
            labourPlanningReportView.WeekCell2.Vacation = labourPlanningReportView.WeekCell2.Vacation;
            labourPlanningReportView.WeekCell3.Vacation = labourPlanningReportView.WeekCell3.Vacation;
            labourPlanningReportView.WeekCell4.Vacation = labourPlanningReportView.WeekCell4.Vacation;
            labourPlanningReportView.WeekCell5.Vacation = labourPlanningReportView.WeekCell5.Vacation;
            labourPlanningReportView.WeekCell6.Vacation = labourPlanningReportView.WeekCell6.Vacation;
            labourPlanningReportView.WeekCell7.Vacation = labourPlanningReportView.WeekCell7.Vacation;
            labourPlanningReportView.WeekCell8.Vacation = labourPlanningReportView.WeekCell8.Vacation;
            labourPlanningReportView.WeekCell9.Vacation = labourPlanningReportView.WeekCell9.Vacation;
            labourPlanningReportView.WeekCell10.Vacation = labourPlanningReportView.WeekCell10.Vacation;
            labourPlanningReportView.WeekCell11.Vacation = labourPlanningReportView.WeekCell11.Vacation;
            labourPlanningReportView.WeekCell12.Vacation = labourPlanningReportView.WeekCell12.Vacation;
            labourPlanningReportView.WeekCell13.Vacation = labourPlanningReportView.WeekCell13.Vacation;            

            labourPlanningReportView.WeekCell0.SickAbsent = labourPlanningReportView.WeekCell0.SickAbsent;
            labourPlanningReportView.WeekCell1.SickAbsent = labourPlanningReportView.WeekCell1.SickAbsent;
            labourPlanningReportView.WeekCell2.SickAbsent = labourPlanningReportView.WeekCell2.SickAbsent;
            labourPlanningReportView.WeekCell3.SickAbsent = labourPlanningReportView.WeekCell3.SickAbsent;
            labourPlanningReportView.WeekCell4.SickAbsent = labourPlanningReportView.WeekCell4.SickAbsent;
            labourPlanningReportView.WeekCell5.SickAbsent = labourPlanningReportView.WeekCell5.SickAbsent;
            labourPlanningReportView.WeekCell6.SickAbsent = labourPlanningReportView.WeekCell6.SickAbsent;
            labourPlanningReportView.WeekCell7.SickAbsent = labourPlanningReportView.WeekCell7.SickAbsent;
            labourPlanningReportView.WeekCell8.SickAbsent = labourPlanningReportView.WeekCell8.SickAbsent;
            labourPlanningReportView.WeekCell9.SickAbsent = labourPlanningReportView.WeekCell9.SickAbsent;
            labourPlanningReportView.WeekCell10.SickAbsent = labourPlanningReportView.WeekCell10.SickAbsent;
            labourPlanningReportView.WeekCell11.SickAbsent = labourPlanningReportView.WeekCell11.SickAbsent;
            labourPlanningReportView.WeekCell12.SickAbsent = labourPlanningReportView.WeekCell12.SickAbsent;
            labourPlanningReportView.WeekCell13.SickAbsent = labourPlanningReportView.WeekCell13.SickAbsent;            

            labourPlanningReportView.WeekCell0.Overtime = labourPlanningReportView.WeekCell0.Overtime;
            labourPlanningReportView.WeekCell1.Overtime = labourPlanningReportView.WeekCell1.Overtime;
            labourPlanningReportView.WeekCell2.Overtime = labourPlanningReportView.WeekCell2.Overtime;
            labourPlanningReportView.WeekCell3.Overtime = labourPlanningReportView.WeekCell3.Overtime;
            labourPlanningReportView.WeekCell4.Overtime = labourPlanningReportView.WeekCell4.Overtime;
            labourPlanningReportView.WeekCell5.Overtime = labourPlanningReportView.WeekCell5.Overtime;
            labourPlanningReportView.WeekCell6.Overtime = labourPlanningReportView.WeekCell6.Overtime;
            labourPlanningReportView.WeekCell7.Overtime = labourPlanningReportView.WeekCell7.Overtime;
            labourPlanningReportView.WeekCell8.Overtime = labourPlanningReportView.WeekCell8.Overtime;
            labourPlanningReportView.WeekCell9.Overtime = labourPlanningReportView.WeekCell9.Overtime;
            labourPlanningReportView.WeekCell10.Overtime = labourPlanningReportView.WeekCell10.Overtime;
            labourPlanningReportView.WeekCell11.Overtime = labourPlanningReportView.WeekCell11.Overtime;
            labourPlanningReportView.WeekCell12.Overtime = labourPlanningReportView.WeekCell12.Overtime;
            labourPlanningReportView.WeekCell13.Overtime = labourPlanningReportView.WeekCell13.Overtime;            
                
        }

    } catch (Exception ex) {
        MessageBox.Show("loadMachinePartsNet Exception: " + ex.Message);        
    }
}

public
LabourPlanningReportView loadLabourTypeSummary(LabourPlanningReportViewContainer labourPlanningReportViewContainer){
    labourPlanningReportViewSum = getCoreFactory().createLabourPlanningReportView();
    try { 

        foreach(LabourPlanningReportView labourPlanningReportViewAux in labourPlanningReportViewContainer){
            labourPlanningReportViewSum.summarizeAll(labourPlanningReportViewAux);
        }

    } catch (Exception ex) {
        MessageBox.Show("loadLabourTypeSummary Exception: " + ex.Message);        
    }
    return labourPlanningReportViewSum;
}


public
decimal getDaysPerWeek(DateTime startDate,int imachineId){
    decimal                     daysPerWeek = 5; // 5 days per week by default
    CapShiftProfileContainer    capShiftProfileContainer = getCoreFactory().createCapShiftProfileContainer();
    
    if (hashProfilesByDates.Contains(startDate)) { 
        capShiftProfileContainer = (CapShiftProfileContainer)hashProfilesByDates[startDate];
        daysPerWeek = capShiftProfileContainer.getTotalDaysPerWeek(imachineId);
    }

    if (daysPerWeek <=0)
        daysPerWeek =1;

    return daysPerWeek;
}

public
decimal getDaysPerWeek(DateTime date,Hashtable hashProfilesByDatesAux){
    decimal daysPerWeek = 5;

    if (hashProfilesByDatesAux.Contains(date))
        daysPerWeek = (decimal)hashProfilesByDatesAux[date];
        
    if (daysPerWeek <=0)
        daysPerWeek =1;

    return daysPerWeek;
}

public
LabourTypeRequiredContainer searchHotListLabourType(string splant,string sdept,string srequirment,int imachineId,string spart){
    LabourTypeRequiredContainer         labourTypeRequiredContainer = getCoreFactory().createLabourTypeRequiredContainer();
    try{ 
        HotListHdr                          hotListHdr = getCoreFactory().readLastHotList(splant);
        scheduleHdr = getCoreFactory().readScheduleHdrLastDateCheck(scheduleHdr,splant);

        if (hotListHdr!= null) { 
            labourTypeRequiredContainer = getCoreFactory().getHotListLabourType2(hashMachines,hashRoutings,hashTasks,scheduleHdr, hotListHdr.Id, hotListHdr.Plant,splant,sdept,srequirment, imachineId,spart,-1,"","","",true,false,false,false,0);
        }

    } catch (Exception ex) {
        MessageBox.Show("searchHotListLabourType Exception: " + ex.Message);        
    }
    return labourTypeRequiredContainer;
}

public
void loadProduction(){
    getProductionPrHistSum(ref hashPrHistSum, ref prHistDateTimeChecked, "", -1, getPlant(), dSweek0, dEweek0);//check production
}    

public 
void createTopGrid(StackPanel mainStack,LabourPlanningReportView labourPlanningReportView){    
    labourPlanningReportShiftViewContainer = getCoreFactory().createLabourPlanningReportShiftViewContainer();
    arrayPlanningReportShiftView.Add(labourPlanningReportShiftViewContainer);
                            
    this.textBoxShiftLastFocused=null;
    
    labourPlanningReportViewSel = labourPlanningReportView;

    mainStack.Orientation = Orientation.Horizontal;
    mainStack.Children.Clear();
    
    topGridTitles(mainStack);

    int         ilabourId = labourPlanningReportView!= null ? labourPlanningReportView.ReqId : 0;
    DateTime    mon = DateTime.Now;
    DateTime    sun = DateTime.Now;
    DateTime    date=DateTime.Now;
    
    DateUtil.getPriorMondayNextSundayFromDate(mon,out mon,out sun);

    CellPlanningLabType cellPlanningLabType = null;
    Hashtable           hashtableDateShiftNum = plannedHdr!= null ? plannedHdr.groupLabourByDateShiftNum(ilabourId) : new Hashtable();       

    for (int i=0; i < 14; i++) {              
        cellPlanningLabType = labourPlanningReportView.getCellWeekByDate(mon,sun,false);

        topGridColumn(mainStack,labourPlanningReportShiftViewContainer, cellPlanningLabType, ilabourId,mon, sun, i,true);
        mon = mon.AddDays(7);
        DateUtil.getPriorMondayNextSundayFromDate(mon,out mon,out sun);    
    }    

    loadShiftValuesBasesPlannedHash(hashtableDateShiftNum,labourPlanningReportShiftViewContainer);    
    autoFillActualsShifts(ilabourId,labourPlanningReportShiftViewContainer);
}

private
void loadShiftValuesBasesPlannedHash(Hashtable hashtableDateShiftNum,LabourPlanningReportShiftViewContainer labourPlanningReportShiftViewContainer){    
    DateTime                        date=DateTime.Now;
    int                             ishiftNum=0;
    string[]                        items = null;
    CellPlanningLabType             cellPlanningLabType=null;
    LabourPlanningReportShiftView   labourPlanningReportShiftView=null;

    labourPlanningReportShiftViewContainer.clean(); //empty shift values info so will be filled again
                
    foreach (DictionaryEntry pair in hashtableDateShiftNum){
        items = ((string)pair.Key).Split(Constants.DEFAULT_SEP);
        if (items.Length > 0){ 
            date        = DateUtil.parseDate(items[0],DateUtil.MMDDYYYY);
            ishiftNum   = Convert.ToInt32(items[1]);

            PlannedLabourContainer plannedLabourContainer = (PlannedLabourContainer)pair.Value; //supposed 1 record, but we process container  
            labourPlanningReportShiftView = labourPlanningReportShiftViewContainer.getByDate(date);
            if (labourPlanningReportShiftView != null){
                cellPlanningLabType = labourPlanningReportShiftView.getCellPlanningLabTypeByIndex(ishiftNum-1);
                if (cellPlanningLabType!= null) { 
                    cellPlanningLabType.PlannedLabourContainer = plannedLabourContainer;
                    cellPlanningLabType.loadTotValuesBasedLabourContainer();
                }
            }
        }
    }
}
 
private
void loadShiftValuesBasesEmpShiftScheduleHash(Hashtable hashtableDateShiftNum, LabourPlanningReportShiftViewContainer labourPlanningReportShiftViewContainer){    
    DateTime                        date=DateTime.Now;
    int                             ishiftNum=0;
    string[]                        items = null;
    CellPlanningLabType             cellPlanningLabType=null;
    LabourPlanningReportShiftView   labourPlanningReportShiftView=null;    
                
    foreach (DictionaryEntry pair in hashtableDateShiftNum){
        items = ((string)pair.Key).Split(Constants.DEFAULT_SEP);
        if (items.Length > 0){ 
            date        = DateUtil.parseDate(items[0],DateUtil.MMDDYYYY);
            ishiftNum   = Convert.ToInt32(items[1]);

            EmpShiftScheduleHdrSumView empShiftScheduleHdrSumView = (EmpShiftScheduleHdrSumView)pair.Value; 
            
            labourPlanningReportShiftView = labourPlanningReportShiftViewContainer.getByDate(date);
            if (labourPlanningReportShiftView != null){
                cellPlanningLabType = labourPlanningReportShiftView.getCellPlanningLabTypeByIndex(ishiftNum-1);
                if (cellPlanningLabType!= null) { 
                    cellPlanningLabType.Planned = 
                    cellPlanningLabType.EmployeesShiftSchedule+= empShiftScheduleHdrSumView.EmployeeCount;                    
                }
            }
        }
    }
}

public 
void createTopGrid(StackPanel mainStack){    
    labourPlanningReportShiftViewSumContainer = getCoreFactory().createLabourPlanningReportShiftViewContainer();
    this.textBoxShiftLastFocused=null;
        
    mainStack.Orientation = Orientation.Horizontal;
    mainStack.Children.Clear();
    topGridTitles(mainStack);

    int         ilabourId=0;
    DateTime    mon = DateTime.Now;
    DateTime    sun = DateTime.Now;
    DateTime    date=DateTime.Now;    
    DateUtil.getPriorMondayNextSundayFromDate(mon,out mon,out sun);

    CellPlanningLabType cellPlanningLabType = null;
    Hashtable           hashtableDateShiftNum = plannedHdr!= null ? plannedHdr.groupLabourByDateShiftNum() : new Hashtable();       
    
    for (int i=0; i < 14; i++) {              
        cellPlanningLabType = labourPlanningReportViewSum!= null ? labourPlanningReportViewSum.getCellWeekByDate(mon,sun,false) : null;

        topGridColumn(mainStack, labourPlanningReportShiftViewSumContainer, cellPlanningLabType, ilabourId,mon, sun, i,false);
        mon = mon.AddDays(7);
        DateUtil.getPriorMondayNextSundayFromDate(mon,out mon,out sun);    
    }    

    loadShiftValuesBasesPlannedHash(hashtableDateShiftNum, labourPlanningReportShiftViewSumContainer);
    autoFillActualsShifts(); //Actuals=Planned como from Employee Active per shift
}

private 
void topGridColumn(StackPanel mainStack,LabourPlanningReportShiftViewContainer labourPlanningReportShiftViewContainer,CellPlanningLabType cellPlanningLabTypeMain,int ilabourId,DateTime starDate, DateTime endDate,int index,bool beditable){    
    double                          dwith               = 95;
    double                          dwithMin            = dwith / 3;
    double                          dheight             = 25;
    double                          dheightMin          = 5;
    double                          dfonSize            = 12;
    FontWeight                      fontWeight          = FontWeights.UltraBold;        
    ListViewColManual               listViewCol         = new ListViewColManual();    
    TextBox                         textBox             = new TextBox();
    Label                           label               = new Label();
    CellPlanningLabType             cellPlanningLabType = null;
    LabourPlanningReportShiftView   labourPlanningReportShiftView = getCoreFactory().createLabourPlanningReportShiftView();
    CapShiftTask                    capShiftTask        = (CapShiftTask)getFromHashTable(hashTasks, ilabourId); //read to check if avoid temporary employee
    string                          sempTempCanPerform  = capShiftTask != null ? capShiftTask.EmpTempCanPerform : Constants.STRING_NO;
            
    labourPlanningReportShiftViewContainer.Add(labourPlanningReportShiftView);
    labourPlanningReportShiftView.ReqType   = Constants.TYPE_LABOUR;
    labourPlanningReportShiftView.ReqId     = ilabourId;
    labourPlanningReportShiftView.StartDate = starDate;      //set date
    labourPlanningReportShiftView.EndDate   = endDate;
    labourPlanningReportShiftView.TotDirectLabour = cellPlanningLabTypeMain!= null ? cellPlanningLabTypeMain.Required : 0;
    labourPlanningReportShiftView.fillRedundances();

    StackPanel newStackPanel= listViewCol.createStackPanel();
                 
    //start capacity required                               
    StackPanel colCapacityRequired = listViewCol.createStackPanel();
    textBox = listViewCol.createTextBox("STitDate", true, true, dwith, dheight + 10, 12, fontWeight, TextAlignment.Center, VerticalAlignment.Center, Colors.Black, Colors.Lavender,"Arial");        
    colCapacityRequired.Children.Add(listViewCol.addBorder(textBox));
 
    textBox =  listViewCol.createTextBox("",true,true, dwith, dheight,0, fontWeight,TextAlignment.Center, VerticalAlignment.Center,Colors.Black,Colors.Lavender);        
    textBox.Text = "Monday";
    colCapacityRequired.Children.Add(listViewCol.addBorder(textBox));
    
    textBox =  listViewCol.createTextBox("TotDirectLabourCeiling", true,true, dwith, dheight,0,fontWeight,TextAlignment.Center, VerticalAlignment.Center,Colors.Black,Colors.LightYellow, new DecimalToStringConverterNew(),"int","");        
    colCapacityRequired.Children.Add(listViewCol.addBorder(textBox));

    label = listViewCol.createLabel("","",dwith, dheightMin, dfonSize,fontWeight, HorizontalAlignment.Center,VerticalAlignment.Center, Colors.White, Colors.Lavender);          
    colCapacityRequired.Children.Add(listViewCol.addBorder(label));

    //start shift
    StackPanel stackShiftTitleCol = listViewCol.createStackPanel(Orientation.Horizontal);      //Shift title 1/2/3     
    for (int i=0; i < Constants.MAX_SHIFTS; i++) {      
        cellPlanningLabType = labourPlanningReportShiftView.getCellPlanningLabTypeByIndex(i);

        textBox =  listViewCol.createTextBox("ShiftNum",true,true, dwithMin, dheight, dfonSize, fontWeight,TextAlignment.Center, VerticalAlignment.Center,Colors.Black,Colors.LightYellow, Constants.FONT_FAMILY_SEGEOEUI);                        
        stackShiftTitleCol.Children.Add(listViewCol.addBorder(textBox));

        textBox.DataContext = cellPlanningLabType;
    }

    ArrayList   arrayStackShifts = new ArrayList();
    StackPanel  stackShiftValuesCol = null;      //Shift values                            

    for (int i=0; i < 6; i++) {   
        stackShiftValuesCol = listViewCol.createStackPanel(Orientation.Horizontal);
        arrayStackShifts.Add(stackShiftValuesCol);  
    }

    for (int i=0; i < Constants.MAX_SHIFTS; i++) {                           
        createShiftTextBox(labourPlanningReportShiftView, listViewCol,(StackPanel)arrayStackShifts[0], "Planned",   i,dwithMin,dheight,dfonSize,beditable);
        //createShiftTextBox(labourPlanningReportShiftView, listViewCol,(StackPanel)arrayStackShifts[0], "EmployeesShiftSchedule",   i,dwithMin,dheight,dfonSize,beditable);
        createShiftTextBox(labourPlanningReportShiftView, listViewCol,(StackPanel)arrayStackShifts[1], "Temp",      i,dwithMin,dheight,dfonSize,beditable && sempTempCanPerform.Equals(Constants.STRING_YES));        
        createShiftTextBox(labourPlanningReportShiftView, listViewCol,(StackPanel)arrayStackShifts[2], "NewHire",   i,dwithMin,dheight,dfonSize,beditable);        
        createShiftTextBox(labourPlanningReportShiftView, listViewCol,(StackPanel)arrayStackShifts[3], "Vacation",  i,dwithMin,dheight,dfonSize,beditable);        
        createShiftTextBox(labourPlanningReportShiftView, listViewCol,(StackPanel)arrayStackShifts[4], "SickAbsent",i,dwithMin,dheight,dfonSize,beditable);
        createShiftTextBox(labourPlanningReportShiftView, listViewCol,(StackPanel)arrayStackShifts[5], "Overtime",  i,dwithMin,dheight,dfonSize,beditable);                
    }
    
    StackPanel stackShiftActiveCol = listViewCol.createStackPanel(Orientation.Horizontal);      //Active Net
    for (int i=0; i < Constants.MAX_SHIFTS; i++) {      
        cellPlanningLabType = labourPlanningReportShiftView.getCellPlanningLabTypeByIndex(i);

        textBox =  listViewCol.createTextBox("Net", true, true, dwithMin, dheight, dfonSize, FontWeights.UltraBlack, TextAlignment.Right,VerticalAlignment.Center,Colors.Black,Colors.LightYellow, new DecimalToStringConverterNew(),"int",Constants.FONT_FAMILY_SEGEOEUI);                        
        stackShiftActiveCol.Children.Add(listViewCol.addBorder(textBox));

        textBox.DataContext = cellPlanningLabType;
    }
        
    StackPanel stackTotalsCol = listViewCol.createStackPanel();    //Totals
    textBox =  listViewCol.createTextBox("TotalShfits", true,true, dwith, dheight,0, fontWeight,TextAlignment.Center, VerticalAlignment.Center,Colors.Black,Colors.Lavender, new DecimalToStringConverterNew(),"int");                    
    stackTotalsCol.Children.Add(listViewCol.addBorder(textBox));

    label = listViewCol.createLabel("","",dwith, dheightMin, dfonSize,fontWeight, HorizontalAlignment.Center,VerticalAlignment.Center, Colors.White, Colors.White);          
    stackTotalsCol.Children.Add(listViewCol.addBorder(label));            

    textBox =  listViewCol.createTextBox("TotalNet", true,true, dwith, dheight, 0, fontWeight,TextAlignment.Center,VerticalAlignment.Center,Colors.Black,Colors.Lavender, new DecimalToStringConverterNew(),"int");  
    stackTotalsCol.Children.Add(listViewCol.addBorder(textBox));
                                      
    newStackPanel.Children.Add(colCapacityRequired);
    newStackPanel.Children.Add(stackShiftTitleCol);
    foreach(StackPanel stackShiftValuesColAux in arrayStackShifts)
        newStackPanel.Children.Add(stackShiftValuesColAux);
    newStackPanel.Children.Add(stackShiftActiveCol);
    newStackPanel.Children.Add(stackTotalsCol);
    mainStack.Children.Add(newStackPanel);

    stackShiftActiveCol.DataContext = labourPlanningReportShiftView;    
    stackTotalsCol.DataContext = labourPlanningReportShiftView;    
    newStackPanel.DataContext = labourPlanningReportShiftView;    
}

private
void createShiftTextBox(LabourPlanningReportShiftView labourPlanningReportShiftView,ListViewColManual listViewCol,
                        StackPanel stackShiftValuesCol, string sbindName,int index,double dwithMin,double dheight,double dfonSize,bool beditable){
    CellPlanningLabType cellPlanningLabType = labourPlanningReportShiftView.getCellPlanningLabTypeByIndex(index);

    TextBox textBox = listViewCol.createTextBox(sbindName, true,!beditable, dwithMin, dheight, dfonSize, FontWeights.Bold, TextAlignment.Right, VerticalAlignment.Center,Colors.Black,beditable? Colors.White: Colors.LightYellow, new DecimalToStringConverterNew(),"int",Constants.FONT_FAMILY_SEGEOEUI);                        
    stackShiftValuesCol.Children.Add(listViewCol.addBorder(textBox));
    if (beditable) { 
        textBox.AddHandler(TextBox.LostFocusEvent, new RoutedEventHandler(topPlanned_LostFocusEvent)); 
        textBox.AddHandler(TextBox.GotFocusEvent, new RoutedEventHandler(topPlanned_GotFocus));                      
    }
    textBox.DataContext = cellPlanningLabType;
}

private 
void topGridTitles(StackPanel mainStack){    
    double                  dwith =56;
    double                  dwith2=55;
    double                  dheight =25;
    double                  dheightMin =5;
    double                  dfonSize =10.5;
    FontWeight              fontWeight = FontWeights.UltraBold;        
    ListViewColManual       listViewCol = new ListViewColManual();    
    TextBox                 textBox     = null;
    Label                   label       = null;
    
    StackPanel stackPanelLeftCol = listViewCol.createStackPanel();

    label = listViewCol.createLabel("","Capacity" + "\n" + "Required", dwith,50,dfonSize,fontWeight, HorizontalAlignment.Center,VerticalAlignment.Center, UIColors.LABOUR_STACK_TITLE_FONT, UIColors.LABOUR_STACK_TITLE_BACKGROUND);    
    stackPanelLeftCol.Children.Add(label);

    label = listViewCol.createLabel("", "Current" + "\n" + "Labour", dwith,282,dfonSize,fontWeight, HorizontalAlignment.Center,VerticalAlignment.Center, UIColors.LABOUR_STACK_TITLE_FONT, UIColors.LABOUR_STACK_TITLE_BACKGROUND);
    stackPanelLeftCol.Children.Add(label);

    label = listViewCol.createLabel("", "Net Calc", dwith,40,dfonSize,fontWeight, HorizontalAlignment.Center,VerticalAlignment.Center, UIColors.LABOUR_STACK_TITLE_FONT, UIColors.LABOUR_STACK_TITLE_BACKGROUND);
    stackPanelLeftCol.Children.Add(label);
    mainStack.Children.Add(stackPanelLeftCol);
    
    StackPanel newStackPanel= listViewCol.createStackPanel();

    CellTitles c = new CellTitles();    
    c.Title1 = "Week#";
    c.Title2 = "";
    c.Title3 = "TotDirect" + "\n" +"Labour";
    c.Title4 = "Shift";
    c.Title5 = "Actual";
 
    c.Title6 = "Temp";        
    c.Title7 = "NewHires";        
    c.Title8 = "Vacation";        
    c.Title9 = "Sick" + "\n"+ "Absent";        
    c.Title10= "Over Time";
    c.Title11= "Active" + "\n"+ "Net";
    c.Title12= "Totals";
    c.Title13= "Net";

    for (int i=0; i <= 12 ; i++){ //Titles
        if (i == 3 || i== 12){
            label = listViewCol.createLabel("", "", dwith2, dheightMin, dfonSize,fontWeight, HorizontalAlignment.Center,VerticalAlignment.Center, Colors.Black, Colors.White);                
            label.Background = (i == 12) ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.Lavender);
            newStackPanel.Children.Add(listViewCol.addBorder(label));                  
        }

        textBox =  listViewCol.createTextBox("Title" + (i + 1).ToString(), true,true, dwith2, dheight, dfonSize, fontWeight,TextAlignment.Left, VerticalAlignment.Center,Colors.Black,Colors.White,Constants.FONT_FAMILY_SEGEOEUI);
                
        if ( i == 0)
            textBox.Height= dheight+10;        
        if (i >=11)
            textBox.Background = new SolidColorBrush(Colors.Lavender);

        newStackPanel.Children.Add(listViewCol.addBorder(textBox));
    }
    
    mainStack.Children.Add(newStackPanel);
    newStackPanel.DataContext = c;    
}

private 
void topPlanned_LostFocusEvent(object sender, RoutedEventArgs e){
    topPlannedLostFocusEvent((TextBox)sender);
}

private 
void topPlanned_GotFocus(object sender, RoutedEventArgs e){
    topPlannedGotFocus((TextBox)sender);    
}

private 
void topPlannedGotFocus(TextBox textBox){
    this.textBoxShiftLastFocused = textBox;
}

public 
void checkIfNeedProcessShiftLostFocus(){    
    topPlannedLostFocusEvent(textBoxShiftLastFocused);
}

private 
void topPlannedLostFocusEvent(TextBox textBox){    
    try{
        if (textBox!= null && textBox.Parent!= null && getCoreFactory()!=null){
            Object                          panel = (Object)textBox.Parent;
            StackPanel                      stackPanel = null;
            Border                          border=null;
            CellPlanningLabType             cellPlanningLabType = (CellPlanningLabType)textBox.DataContext;
            LabourPlanningReportShiftView   labourPlanningReportShiftView= null;    
            //var binding = BindingOperations.GetBinding(textBox, TextBox.TextProperty);  get binding

            if (panel is Border)
                border = (Border)panel;
            if (border!= null && border.Parent is StackPanel)
                stackPanel = (StackPanel) border.Parent;

            if (stackPanel != null)
                labourPlanningReportShiftView = (LabourPlanningReportShiftView)stackPanel.DataContext;

            if (cellPlanningLabType!= null && labourPlanningReportShiftView!= null){
                PlannedLabour plannedLabour = cellPlanningLabType.PlannedLabourContainer.Count> 0? cellPlanningLabType.PlannedLabourContainer[0]:null;

                bool bprocess = true;

                if (plannedLabour == null && cellPlanningLabType.Overtime == 0 && cellPlanningLabType.Temp == 0 && cellPlanningLabType.Planned == 0 
                                          && cellPlanningLabType.NewHire == 0 && cellPlanningLabType.SickAbsent == 0 && cellPlanningLabType.Vacation == 0)
                    bprocess = false;

                if (plannedLabour != null && plannedLabour.TotEmployOver == cellPlanningLabType.Overtime && plannedLabour.TotEmployPlan == cellPlanningLabType.Planned &&
                    plannedLabour.TotEmployTemp == cellPlanningLabType.Temp && plannedLabour.TotEmployHire == cellPlanningLabType.NewHire &&
                    plannedLabour.TotEmployAbsent == cellPlanningLabType.SickAbsent && plannedLabour.TotEmployVacation == cellPlanningLabType.Vacation) //check if any value changed
                    bprocess = false;

                if (labourPlanningReportShiftView != null && bprocess){
                    plannedLabour = getCoreFactory().generateNewPlannedLabourBasedPlanned(plannedHdr, plannedHdr.Plant, machine != null ? machine.Id : 0,cellPlanningLabType.ShiftNum,labourPlanningReportShiftView, cellPlanningLabType);
                    cellPlanningLabType.PlannedLabourContainer.Remove(plannedLabour);
                    cellPlanningLabType.PlannedLabourContainer.Add(plannedLabour);

                    cellPlanningLabType.Net= cellPlanningLabType.Net;
                    labourPlanningReportShiftView.recalcTotals();

                    //update top view summarized 
                    Hashtable           hashtableDateShiftNum = plannedHdr!= null ? plannedHdr.groupLabourByDateShiftNum() : new Hashtable();       
                    loadShiftValuesBasesPlannedHash(hashtableDateShiftNum,this.labourPlanningReportShiftViewSumContainer);    
                }

            }
        }
    } catch (Exception ex) {
        MessageBox.Show("topPlannedLostFocusEvent Exception: " + ex.Message);        
    }
}


public 
void loadShiftGrid(StackPanel mainStack){
    CapShiftTaskContainer                   capShiftTaskContainer   = getCoreFactory().readCapShiftTaskByFilters("","","",4); 
    CapShiftTask                            capShiftTask = null;
    LabourPlanningReportShiftViewContainer  labourPlanningReportShiftViewContainer  = getCoreFactory().createLabourPlanningReportShiftViewContainer();
    LabourPlanningReportShiftView           labourPlanningReportShiftView           = null;
    CellPlanningLabType                     cellPlanningLabType=null;
    ArrayList                               arrayLabours = new ArrayList();
    int                                     imaxWeeks=4;

    mainStack.Orientation = Orientation.Horizontal;
    mainStack.Children.Clear();
    sumShiftsGridTitles(mainStack,capShiftTaskContainer);

    DateTime    mon = DateTime.Now;
    DateTime    sun = DateTime.Now;
    DateTime    date=DateTime.Now;    
    
    for (int j=0; j < imaxWeeks;j++){   //create container for each week
        labourPlanningReportShiftViewContainer  = getCoreFactory().createLabourPlanningReportShiftViewContainer();
        arrayLabours.Add(labourPlanningReportShiftViewContainer);
        mon = DateTime.Now.AddDays(7*j);
    
        for (int i=0; i < capShiftTaskContainer.Count; i++){    //create for each labour
            DateUtil.getPriorMondayNextSundayFromDate(mon,out mon,out sun);
        
            capShiftTask = capShiftTaskContainer[i];
            labourPlanningReportShiftView = getCoreFactory().createLabourPlanningReportShiftView();
            labourPlanningReportShiftViewContainer.Add(labourPlanningReportShiftView);

            labourPlanningReportShiftView.ReqType   = Constants.TYPE_LABOUR;
            labourPlanningReportShiftView.ReqId     = capShiftTask.Id;
            labourPlanningReportShiftView.StartDate = mon;      //set date
            labourPlanningReportShiftView.EndDate   = sun;    
            labourPlanningReportShiftView.Title     = "Week" + i.ToString();
            labourPlanningReportShiftView.fillRedundances();                    
        }
    }
  
    for (int i=0; i < imaxWeeks && i < arrayLabours.Count; i++){
       labourPlanningReportShiftViewContainer = (LabourPlanningReportShiftViewContainer) arrayLabours[i];
       sumShiftsTotalGridColumn(mainStack,labourPlanningReportShiftViewContainer,i);
    }

    /*
    for (int i=0; i < 4; i++){
        DateUtil.getPriorMondayNextSundayFromDate(mon,out mon,out sun);

        cellPlanningLabType = labourPlanningReportViewSum!= null ? labourPlanningReportViewSum.getCellWeekByDate(mon,sun,false) : null;

        for (int j=0; j < capShiftTaskContainer.Count; j++){
            capShiftTask = capShiftTaskContainer[j];
            sumShiftsTotalGridColumn(mainStack,labourPlanningReportShiftViewContainer,capShiftTask,cellPlanningLabType, mon,sun,j,false);
        }

        mon = mon.AddDays(7);
    }*/
}

public 
void sumShiftsGridTitles(StackPanel mainStack,CapShiftTaskContainer capShiftTaskContainer){
    double                          dwith                   = 200;
    double                          dwithMin                = dwith / 2;
    double                          dheight                 = 25;
    double                          dheightMin              = 5;
    double                          dfonSize                = 12;
    FontWeight                      fontWeight              = FontWeights.UltraBold;        
    ListViewColManual               listViewCol             = new ListViewColManual();    
    TextBox                         textBox                 = new TextBox();
    Label                           label                   = new Label();    
    LabourPlanningReportShiftView   labourPlanningReportShiftView = getCoreFactory().createLabourPlanningReportShiftView();    
    CapShiftTask                    capShiftTask            = null;
    string                          stext                   = "";        


    StackPanel newStackPanel= listViewCol.createStackPanel();    

    CellTitles c = new CellTitles();    
    c.Title1 = "New Hire Shift Distribution" + "\n" + "Qty Remaining to Distribute";
    c.Title2 = "New Labour";
    c.Title3 = "Type Required";
    c.Title4 = "Type";
    c.Title5 = "New Hire";
    c.Title6 = "";
     
    c.Title7 = "Total New Hires";        
    c.Title8 = "Distributed Qty";        
    
    textBox =  listViewCol.createTextBox("Title1", true,true,dwith,dheight+10, dfonSize, fontWeight,TextAlignment.Left, VerticalAlignment.Center, UIColors.LABOUR_STACK_TITLE_FONT, UIColors.LABOUR_STACK_TITLE_BACKGROUND);    
    newStackPanel.Children.Add(listViewCol.addBorder(textBox));

    label = listViewCol.createLabel("", "", dwith, dheightMin, dfonSize,fontWeight, HorizontalAlignment.Center,VerticalAlignment.Center, Colors.Black, Colors.White);                
    newStackPanel.Children.Add(listViewCol.addBorder(label));
    
    for (int j=0; j < 2; j++) { 
        StackPanel topStackPanel= listViewCol.createStackPanel(Orientation.Horizontal);    
        textBox =  listViewCol.createTextBox("Title"+(j+2), true,true,dwithMin, dheight, dfonSize, fontWeight,TextAlignment.Left, VerticalAlignment.Center, UIColors.LABOUR_STACK_TITLE_FONT, UIColors.LABOUR_STACK_TITLE_BACKGROUND);    
        topStackPanel.Children.Add(listViewCol.addBorder(textBox));
    
        textBox =  listViewCol.createTextBox("Title"+(j+3), true,true, dwithMin, dheight, dfonSize, fontWeight,TextAlignment.Left, VerticalAlignment.Center, UIColors.LABOUR_STACK_TITLE_FONT, UIColors.LABOUR_STACK_TITLE_BACKGROUND);    
        topStackPanel.Children.Add(listViewCol.addBorder(textBox));
        newStackPanel.Children.Add(topStackPanel);

        if ( j == 1) { //used for shift titles 1/2/3
            textBox =  listViewCol.createTextBox("",true,true, dwith,dheight, dfonSize, fontWeight,TextAlignment.Left, VerticalAlignment.Center,Colors.White, Colors.White);            
            newStackPanel.Children.Add(listViewCol.addBorder(textBox));
        }

        for (int i=0; i < capShiftTaskContainer.Count; i++){
            capShiftTask = capShiftTaskContainer[i];

            topStackPanel= listViewCol.createStackPanel(Orientation.Horizontal);
            textBox = listViewCol.createTextBox("TaskName",true, true, dwithMin, dheight, dfonSize, fontWeight, TextAlignment.Left, VerticalAlignment.Center, Colors.Black, Colors.White);
            topStackPanel.Children.Add(listViewCol.addBorder(textBox));

            textBox = listViewCol.createTextBox("Title" + (j + 4), true, true, dwithMin, dheight, dfonSize, fontWeight, TextAlignment.Left, VerticalAlignment.Center, Colors.Black, Colors.White);            
            topStackPanel.Children.Add(listViewCol.addBorder(textBox));

            topStackPanel.DataContext = capShiftTask;
            newStackPanel.Children.Add(topStackPanel);           
        }

        label = listViewCol.createLabel("", "", dwith, dheightMin, dfonSize,fontWeight, HorizontalAlignment.Center,VerticalAlignment.Center, Colors.Black, Colors.White);                
        newStackPanel.Children.Add(listViewCol.addBorder(label));

        if (j == 0){
            topStackPanel= listViewCol.createStackPanel();
            textBox = listViewCol.createTextBox("Title7", true, true, dwith, dheight, dfonSize, fontWeight, TextAlignment.Left, VerticalAlignment.Center, Colors.Black, Colors.White);
            topStackPanel.Children.Add(listViewCol.addBorder(textBox));
            newStackPanel.Children.Add(topStackPanel);
        }
    }

    textBox =  listViewCol.createTextBox("Title8", true,true,dwith,dheight, dfonSize, fontWeight,TextAlignment.Left, VerticalAlignment.Center, UIColors.LABOUR_STACK_TITLE_FONT, UIColors.LABOUR_STACK_TITLE_BACKGROUND);    
    newStackPanel.Children.Add(listViewCol.addBorder(textBox));

    newStackPanel.DataContext = c;
    mainStack.Children.Add(newStackPanel);    
}

private 
void sumShiftsTotalGridColumn(StackPanel mainStack,LabourPlanningReportShiftViewContainer labourPlanningReportShiftViewContainer,int index){    
    double                          dwith               = 95;
    double                          dwithMin            = dwith / 3;
    double                          dheight             = 25;
    double                          dheightMin          = 5;
    double                          dfonSize            = 12;
    FontWeight                      fontWeight          = FontWeights.UltraBold;        
    ListViewColManual               listViewCol         = new ListViewColManual();    
    TextBox                         textBox             = new TextBox();
    Label                           label               = new Label();
    CellPlanningLabType             cellPlanningLabType = null;
    LabourPlanningReportShiftView   labourPlanningReportShiftView = getCoreFactory().createLabourPlanningReportShiftView();

    StackPanel newStackPanel= listViewCol.createStackPanel();

    //week title
    textBox =  listViewCol.createTextBox("Net", true,true,dwith,dheight+10, dfonSize, fontWeight,TextAlignment.Left, VerticalAlignment.Center,Colors.Black, UIColors.LABOUR_STACK_TITLE_BACKGROUND);    
    newStackPanel.Children.Add(listViewCol.addBorder(textBox));

    label = listViewCol.createLabel("", "", dwith, dheightMin, dfonSize,fontWeight, HorizontalAlignment.Center,VerticalAlignment.Center, Colors.Black, Colors.White);                
    newStackPanel.Children.Add(listViewCol.addBorder(label));
                     
    StackPanel topStackPanel= listViewCol.createStackPanel();    

    textBox =  listViewCol.createTextBox("", true,true,dwith, dheight, dfonSize, fontWeight,TextAlignment.Left, VerticalAlignment.Center, UIColors.LABOUR_STACK_TITLE_FONT, UIColors.LABOUR_STACK_TITLE_BACKGROUND);    
    textBox.Text = "Week" + index.ToString();
    newStackPanel.Children.Add(listViewCol.addBorder(textBox));

    for (int i=0; i < labourPlanningReportShiftViewContainer.Count; i++){     //show week           
        labourPlanningReportShiftView = labourPlanningReportShiftViewContainer[i];
                    
        textBox = listViewCol.createTextBox("TotalShfitsNewHire", true,true, dwith, dheight, dfonSize, fontWeight, TextAlignment.Center, VerticalAlignment.Center, Colors.Black, Colors.White,new DecimalToStringConverterNew(),"int");        
        newStackPanel.Children.Add(listViewCol.addBorder(textBox));
        textBox.DataContext = labourPlanningReportShiftView;        
        
    }
    
    label = listViewCol.createLabel("", "", dwith, dheightMin, dfonSize,fontWeight, HorizontalAlignment.Center,VerticalAlignment.Center, Colors.Black, Colors.White);                
    newStackPanel.Children.Add(listViewCol.addBorder(label));

    textBox =  listViewCol.createTextBox("Net",true,true,dwith, dheight, dfonSize, fontWeight,TextAlignment.Left, VerticalAlignment.Center,Colors.White, Colors.LightYellow);        
    newStackPanel.Children.Add(listViewCol.addBorder(textBox));

    textBox =  listViewCol.createTextBox("", true,true,dwith, dheight, dfonSize, fontWeight,TextAlignment.Center, VerticalAlignment.Center, UIColors.LABOUR_STACK_TITLE_FONT, UIColors.LABOUR_STACK_TITLE_BACKGROUND);    
    textBox.Text = "Shift";
    newStackPanel.Children.Add(listViewCol.addBorder(textBox));
   
    topStackPanel = listViewCol.createStackPanel(Orientation.Horizontal);   
    for (int j=0; j < Constants.MAX_SHIFTS;j++){                     
        textBox = listViewCol.createTextBox("", true,true,dwithMin, dheight, dfonSize, FontWeights.Bold, TextAlignment.Right, VerticalAlignment.Center,Colors.Black,Colors.White,new DecimalToStringConverterNew(),"int");                        
        textBox.Text = (j+1).ToString();
        topStackPanel.Children.Add(listViewCol.addBorder(textBox));                                   
    }
    newStackPanel.Children.Add(topStackPanel);

    for (int i=0; i < labourPlanningReportShiftViewContainer.Count; i++){  //show shifts              
        labourPlanningReportShiftView = labourPlanningReportShiftViewContainer[i];

        topStackPanel = listViewCol.createStackPanel(Orientation.Horizontal);       
        for (int j=0; j < Constants.MAX_SHIFTS;j++){                                                                         
            createNewHireShiftTextBox(labourPlanningReportShiftView, listViewCol,topStackPanel, "NewHire", j, dwithMin, dheight, dfonSize, true);                        
        }

        topStackPanel.DataContext = labourPlanningReportShiftView;          
        newStackPanel.Children.Add(topStackPanel);                
    }

    label = listViewCol.createLabel("", "", dwith, dheightMin,dfonSize,fontWeight, HorizontalAlignment.Center,VerticalAlignment.Center, Colors.Black, Colors.White);                
    newStackPanel.Children.Add(listViewCol.addBorder(label));

    textBox = listViewCol.createTextBox("TotalShfits", true,true,dwith,dheight,dfonSize,fontWeight,TextAlignment.Center, VerticalAlignment.Center, Colors.Black, Colors.LightYellow);
    newStackPanel.Children.Add(listViewCol.addBorder(textBox));       

    mainStack.Children.Add(newStackPanel);    
}

private
void createNewHireShiftTextBox(LabourPlanningReportShiftView labourPlanningReportShiftView,ListViewColManual listViewCol,
                        StackPanel stackShiftValuesCol, string sbindName,int index,double dwithMin,double dheight,double dfonSize,bool beditable){
    CellPlanningLabType cellPlanningLabType = labourPlanningReportShiftView.getCellPlanningLabTypeByIndex(index);

    TextBox textBox = listViewCol.createTextBox(sbindName, true,!beditable, dwithMin, dheight, dfonSize, FontWeights.Bold, TextAlignment.Right, VerticalAlignment.Center,Colors.Black,beditable? Colors.White: Colors.LightYellow, new DecimalToStringConverterNew(),"int",Constants.FONT_FAMILY_SEGEOEUI);                        
    stackShiftValuesCol.Children.Add(listViewCol.addBorder(textBox));
    if (beditable) { 
        textBox.AddHandler(TextBox.LostFocusEvent, new RoutedEventHandler(newHireShift_LostFocusEvent)); 
        textBox.AddHandler(TextBox.GotFocusEvent, new RoutedEventHandler(newHireShift_GotFocus));                      
    }
    textBox.DataContext = cellPlanningLabType;
}

private 
void newHireShift_LostFocusEvent(object sender, RoutedEventArgs e){
    newHireShiftLostFocusEvent((TextBox)sender);
}

private 
void newHireShift_GotFocus(object sender, RoutedEventArgs e){
    
}

private
bool getObjectBasedTextBox(TextBox textBox,out CellPlanningLabType  cellPlanningLabType,out LabourPlanningReportShiftView   labourPlanningReportShiftView){
    bool bresult=false;

    cellPlanningLabType = null;
    labourPlanningReportShiftView= null;   

    if (textBox!= null && textBox.Parent!= null){ 
        Object                          panel = (Object)textBox.Parent;
        StackPanel                      stackPanel = null;
        Border                          border=null;
        cellPlanningLabType = (CellPlanningLabType)textBox.DataContext;        
        //var binding = BindingOperations.GetBinding(textBox, TextBox.TextProperty);  get binding

        if (panel is Border)
            border = (Border)panel;
        if (border!= null && border.Parent is StackPanel)
            stackPanel = (StackPanel) border.Parent;

        if (stackPanel != null)
            labourPlanningReportShiftView = (LabourPlanningReportShiftView)stackPanel.DataContext;

        if (cellPlanningLabType!= null && labourPlanningReportShiftView!= null)
            bresult=true;
    }

    return bresult;
}

private 
void newHireShiftLostFocusEvent(TextBox textBox){    
    try{
        if (textBox!= null && textBox.Parent!= null && getCoreFactory()!=null){
            CellPlanningLabType             cellPlanningLabType = null;
            LabourPlanningReportShiftView   labourPlanningReportShiftView= null;    
            getObjectBasedTextBox(textBox, out cellPlanningLabType, out labourPlanningReportShiftView);
                     
            if (getObjectBasedTextBox(textBox, out cellPlanningLabType, out labourPlanningReportShiftView)){

                cellPlanningLabType.Net= cellPlanningLabType.Net;
                labourPlanningReportShiftView.recalcTotals();

                        /*
                PlannedLabour plannedLabour = cellPlanningLabType.PlannedLabourContainer.Count> 0? cellPlanningLabType.PlannedLabourContainer[0]:null;

                bool bprocess = true;

                if (plannedLabour == null && cellPlanningLabType.Overtime == 0 && cellPlanningLabType.Temp == 0 && cellPlanningLabType.Planned == 0 
                                          && cellPlanningLabType.NewHire == 0 && cellPlanningLabType.SickAbsent == 0 && cellPlanningLabType.Vacation == 0)
                    bprocess = false;

                if (plannedLabour != null && plannedLabour.TotEmployOver == cellPlanningLabType.Overtime && plannedLabour.TotEmployPlan == cellPlanningLabType.Planned &&
                    plannedLabour.TotEmployTemp == cellPlanningLabType.Temp && plannedLabour.TotEmployHire == cellPlanningLabType.NewHire &&
                    plannedLabour.TotEmployAbsent == cellPlanningLabType.SickAbsent && plannedLabour.TotEmployVacation == cellPlanningLabType.Vacation) //check if any value changed
                    bprocess = false;

                if (labourPlanningReportShiftView != null && bprocess){
                    plannedLabour = getCoreFactory().generateNewPlannedLabourBasedPlanned(plannedHdr, plannedHdr.Plant, machine != null ? machine.Id : 0,cellPlanningLabType.ShiftNum,labourPlanningReportShiftView, cellPlanningLabType);
                    cellPlanningLabType.PlannedLabourContainer.Remove(plannedLabour);
                    cellPlanningLabType.PlannedLabourContainer.Add(plannedLabour);

                    cellPlanningLabType.Net= cellPlanningLabType.Net;
                    labourPlanningReportShiftView.recalcTotals();

                    //update top view summarized 
                    Hashtable           hashtableDateShiftNum = plannedHdr!= null ? plannedHdr.groupLabourByDateShiftNum() : new Hashtable();       
                    loadShiftValuesBasesPlannedHash(hashtableDateShiftNum,this.labourPlanningReportShiftViewSumContainer);    
                }
                */
            }
        }
    } catch (Exception ex) {
        MessageBox.Show("topPlannedLostFocusEvent Exception: " + ex.Message);        
    }
}

public 
void autoFillEmpShiftSchedule(){    
    try{                
        DateTime                fromDate= DateUtil.getPriorMondayCurrWeek();
        DateTime                toDate  = fromDate.AddDays(14*7);                
        Hashtable               hashEmpSchedByDateShift = getCoreFactory().readEmpShiftScheduleHdrSumViewByFilters(getPlant(),fromDate,toDate,0,"", "", 0);    
        CellPlanningLabType     cellPlanningLabType= null;

        //initialize every Planned record, for every shift
        for (int i=0; i < labourPlanningReportShiftViewSumContainer.Count; i++){
            LabourPlanningReportShiftView labourPlanningReportShiftView = labourPlanningReportShiftViewSumContainer[i];
            for (int j=0; j < Constants.MAX_SHIFTS; j++) { 
                cellPlanningLabType = labourPlanningReportShiftView.getCellPlanningLabTypeByIndex(j);
                if (cellPlanningLabType!= null)  
                    cellPlanningLabType.Planned = cellPlanningLabType.EmployeesShiftSchedule= 0;
            }
        }

        //load planned but using employee shift schedule records
        loadShiftValuesBasesEmpShiftScheduleHash(hashEmpSchedByDateShift, labourPlanningReportShiftViewSumContainer);
        for (int i=0; i < labourPlanningReportShiftViewSumContainer.Count; i++)
            labourPlanningReportShiftViewSumContainer[i].recalcTotals();

        MessageBox.Show("Auto Filled Actual Values Based On Employee Shift Scheduled.");

    } catch (Exception ex) {
        MessageBox.Show("autoFillEmpShiftSchedule Exception: " + ex.Message);        
    }
}

public 
void autoFillActualsShifts(){    
    try{                
        CellPlanningLabType     cellPlanningLabType= null;               
        int                     icountEmployeeShift1=0;
        int                     icountEmployeeShift2=0;
        int                     icountEmployeeShift3=0;        
        string                  stempText = "Temp";

        employeeContainer = getCoreFactory().readEmployeeByFilters("","","",Constants.STATUS_ACTIVE,0,"",-1,false,true,0);        
        icountEmployeeShift1=employeeContainer.getCountPerShift(1, stempText);
        icountEmployeeShift2=employeeContainer.getCountPerShift(2, stempText);
        icountEmployeeShift3=employeeContainer.getCountPerShift(3, stempText);
        
        //initialize every Planned record, for every shift
        for (int i=0; i < labourPlanningReportShiftViewSumContainer.Count; i++){
            LabourPlanningReportShiftView labourPlanningReportShiftView = labourPlanningReportShiftViewSumContainer[i];
            for (int j=0; j < Constants.MAX_SHIFTS; j++) { 
                cellPlanningLabType = labourPlanningReportShiftView.getCellPlanningLabTypeByIndex(j);

                if (cellPlanningLabType!= null) { 
                    switch(j+1){       //swich hift
                        case 1:cellPlanningLabType.Planned = icountEmployeeShift1;break;
                        case 2:cellPlanningLabType.Planned = icountEmployeeShift2;break;
                        case 3:cellPlanningLabType.Planned = icountEmployeeShift3;break;
                    }                    
                }
            }
            labourPlanningReportShiftView.recalcTotals();
        }
       
    } catch (Exception ex) {
        MessageBox.Show("autoFillActualsShifts Exception: " + ex.Message);        
    }
}

public 
void autoFillActualsShifts(int ilabourTypeId,LabourPlanningReportShiftViewContainer labourPlanningReportShiftViewContainer){    
    try{                
        CellPlanningLabType     cellPlanningLabType= null;               
        int                     icountEmployeeShift1=0;
        int                     icountEmployeeShift2=0;
        int                     icountEmployeeShift3=0;        
        string                  stempText = "Temp";
        
        if (employeeContainer.Count < 1)
            employeeContainer = getCoreFactory().readEmployeeByFilters("","","",Constants.STATUS_ACTIVE,0,"",-1,true,true,0);        
        icountEmployeeShift1=employeeContainer.getCountPerShift(1, ilabourTypeId, stempText);
        icountEmployeeShift2=employeeContainer.getCountPerShift(2, ilabourTypeId, stempText);
        icountEmployeeShift3=employeeContainer.getCountPerShift(3, ilabourTypeId, stempText);
        
        //initialize every Planned record, for every shift
        for (int i=0; i < labourPlanningReportShiftViewContainer.Count; i++){
            LabourPlanningReportShiftView labourPlanningReportShiftView = labourPlanningReportShiftViewContainer[i];
            for (int j=0; j < Constants.MAX_SHIFTS; j++) { 
                cellPlanningLabType = labourPlanningReportShiftView.getCellPlanningLabTypeByIndex(j);

                if (cellPlanningLabType!= null) { 
                    switch(j+1){       //swich hift
                        case 1:cellPlanningLabType.Planned = icountEmployeeShift1;break;
                        case 2:cellPlanningLabType.Planned = icountEmployeeShift2;break;
                        case 3:cellPlanningLabType.Planned = icountEmployeeShift3;break;
                    }                    
                }
            }
            labourPlanningReportShiftView.recalcTotals();
        }
       
    } catch (Exception ex) {
        MessageBox.Show("autoFillActualsShifts Exception: " + ex.Message);        
    }
}

public 
void autoFillTempShifts(){    
    try{                
        CellPlanningLabType     cellPlanningLabType= null;                       
        int                     icountTempEmployeeShift =0;
        int                     icountTempEmployeeShift1=0;
        int                     icountTempEmployeeShift2=0;
        int                     icountTempEmployeeShift3=0;
        string                  stempText = "Temp";
        
        //employeeContainer already loaded , so we just use it
        icountTempEmployeeShift1=employeeContainer.getCountPerShiftStartWith(1, stempText);
        icountTempEmployeeShift2=employeeContainer.getCountPerShiftStartWith(2, stempText);
        icountTempEmployeeShift3=employeeContainer.getCountPerShiftStartWith(3, stempText);

        //initialize every Planned record, for every shift
        for (int i=0; i < labourPlanningReportShiftViewSumContainer.Count; i++){
            LabourPlanningReportShiftView labourPlanningReportShiftView = labourPlanningReportShiftViewSumContainer[i];
            for (int j=0; j < Constants.MAX_SHIFTS; j++) { 
                cellPlanningLabType = labourPlanningReportShiftView.getCellPlanningLabTypeByIndex(j);                
                if (cellPlanningLabType!= null) { 

                    icountTempEmployeeShift =0;
                    switch(j+1){       //swich hift
                        case 1: icountTempEmployeeShift = icountTempEmployeeShift1; break;
                        case 2: icountTempEmployeeShift = icountTempEmployeeShift2; break;
                        case 3: icountTempEmployeeShift = icountTempEmployeeShift3; break;
                    }          
                            
                    if (cellPlanningLabType.Temp == 0)                                      
                        cellPlanningLabType.Temp = icountTempEmployeeShift;
                }
            }
            labourPlanningReportShiftView.recalcTotals();
        }
       
    } catch (Exception ex) {
        MessageBox.Show("autoFillTempShifts Exception: " + ex.Message);        
    }
}


 
public 
void autoFillTempDtlShifts(){    
    try{                
        CellPlanningLabType         cellPlanningLabType= null;                       
        int                         icountTempEmployeeShift =0;
        int                         icountTempEmployeeShift1=0;
        int                         icountTempEmployeeShift2=0;
        int                         icountTempEmployeeShift3=0;
        string                      stempText = "Temp";        
        LabourPlanningReportView    labourPlanningReportView = null;
        CapShiftTask                capShiftTask = null;
        string                      smpTempCanPerform = Constants.STRING_YES;
        
        reloadAllTasks(hashTasks);//load all task again, just in case any change
                
        employeeContainer = getCoreFactory().readEmployeeByFilters("","","",Constants.STATUS_ACTIVE,0,"",-1,false,true,0); 

        if (labourPlanningReportViewAllMachinesContainer != null && labourPlanningReportViewAllMachinesContainer.Count == arrayPlanningReportShiftView.Count) { 

            for (int imain=0; imain < arrayPlanningReportShiftView.Count; imain++) { 
                labourPlanningReportShiftViewContainer = (LabourPlanningReportShiftViewContainer)arrayPlanningReportShiftView[imain];

                labourPlanningReportView = labourPlanningReportViewAllMachinesContainer[imain];         //so we can get Task Id
                capShiftTask = (CapShiftTask)getFromHashTable(hashTasks,labourPlanningReportView.ReqId);//get if employee temporary can perform task
                smpTempCanPerform = capShiftTask!= null ? capShiftTask.EmpTempCanPerform : Constants.STRING_NO;

                for (int jmain=0; jmain < labourPlanningReportShiftViewContainer.Count; jmain++) { 

                    if (smpTempCanPerform.Equals(Constants.STRING_NO))      //task can not be performed by temporary employee
                        icountTempEmployeeShift1=icountTempEmployeeShift2=icountTempEmployeeShift3=0;
                    else{ 
                        //employeeContainer already loaded , so we just use it
                        icountTempEmployeeShift1=employeeContainer.getCountPerShiftStartWith(1,stempText,labourPlanningReportView.ReqId);
                        icountTempEmployeeShift2=employeeContainer.getCountPerShiftStartWith(2,stempText,labourPlanningReportView.ReqId);
                        icountTempEmployeeShift3=employeeContainer.getCountPerShiftStartWith(3,stempText,labourPlanningReportView.ReqId);
                    }   

                    //initialize every Planned record, for every shift
                    for (int i=0; i < labourPlanningReportShiftViewContainer.Count; i++){
                        LabourPlanningReportShiftView labourPlanningReportShiftView = labourPlanningReportShiftViewContainer[i];

                        for (int j=0; j < Constants.MAX_SHIFTS; j++) { 
                            cellPlanningLabType = labourPlanningReportShiftView.getCellPlanningLabTypeByIndex(j);                
                            if (cellPlanningLabType!= null) { 

                                icountTempEmployeeShift =0;
                                switch(j+1){       //swich hift
                                    case 1: icountTempEmployeeShift = icountTempEmployeeShift1; break;
                                    case 2: icountTempEmployeeShift = icountTempEmployeeShift2; break;
                                    case 3: icountTempEmployeeShift = icountTempEmployeeShift3; break;
                                }                                                                 
                                cellPlanningLabType.Temp = icountTempEmployeeShift;
                            }
                        }            
                    }

                }
            }
        }
       
    } catch (Exception ex) {
        MessageBox.Show("autoFillTempDtlShifts Exception: " + ex.Message);        
    }
}


}
}
