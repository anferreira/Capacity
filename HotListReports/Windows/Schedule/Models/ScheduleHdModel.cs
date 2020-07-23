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
using HotListReports.Windows.Products;
using HotListReports.Windows.Machines;
using Telerik.Windows.Controls;
using Nujit.NujitERP.ClassLib.Core.Machines;
using Nujit.NujitWms.WinForms;

namespace HotListReports.Windows.Demand{
class ScheduleHdModel : HotListModel{

private ScheduleReqView             scheduleReqViewActive;
private ScheduleReqViewContainer    scheduleReqViewContainer;
private ScheduleReqViewContainer    scheduleReqViewContainerFiltered;

private ScheduleReqView scheduleReqViewFilter;
private DateTime        startDateFilter;
private DateTime        stopDateFilter;

private SchedulePart        schedulePartCloneBkp=null;
private ScheduleTask        scheduleTaskCloneBkp=null;
private ScheduleDown        scheduleDownCloneBkp=null;
private ScheduleReceiptPart scheduleReceiptPartCloneBkp=null;
private Hashtable           hashMachinesById;
private DaysWithQoh         daysWithQoh;

public class DaysWithQoh {
    public int Days { get; set; }    
}

public ScheduleHdModel(Window window) : base(window){    
    scheduleHdr= getCoreFactory().createScheduleHdr();
    this.scheduleReqViewActive = null;
    this.hashMachinesById = new Hashtable();
    scheduleReqViewContainer = getCoreFactory().createScheduleReqViewContainer();
    scheduleReqViewContainerFiltered = getCoreFactory().createScheduleReqViewContainer();        

    scheduleReqViewFilter = getCoreFactory().createScheduleReqView();
    loadDefaultStartStopDates();   

    this.daysWithQoh = new DaysWithQoh();
    this.daysWithQoh.Days=7;
}   

private
void loadDefaultStartStopDates(){ 
    DateTime dstartAux= DateTime.Now.AddDays(-7);
    startDateFilter = new DateTime(dstartAux.Year, dstartAux.Month, dstartAux.Day,0,0,0);
    dstartAux=  DateTime.Now.AddDays(7);
    stopDateFilter   = new DateTime(dstartAux.Year, dstartAux.Month, dstartAux.Day,23,59,59);
}


public
ScheduleReqViewContainer reloadFilters(){
    scheduleReqViewContainer = scheduleHdr.buildReqContainer();    
    scheduleReqViewContainerFiltered = scheduleHdr.applyFiltersReqContainer(scheduleReqViewContainer,scheduleReqViewFilter, StartDateFilter,StopDateFilter);

    return scheduleReqViewContainerFiltered;
}

public
void initializeFilters(ComboBox comboBox){
    try{
        ScheduleHdr scheduleHdr = getCoreFactory().createScheduleHdr();
        ScheduleHdr = scheduleHdr;
        ScheduleReqViewFilter = getCoreFactory().createScheduleReqView();    
        loadReqFilter(comboBox);         
            
    } catch (Exception ex) {
        MessageBox.Show("initializeFilters Exception: " + ex.Message);        
    }                       
}

public
DaysWithQoh DaysWithQohs{
	get { return daysWithQoh; }
	set { if (this.daysWithQoh != value){
			this.daysWithQoh = value;			
		}
	}
}

public
ScheduleHdr ScheduleHdr {
	get { return scheduleHdr; }
	set { if (this.scheduleHdr != value){
			this.scheduleHdr = value;			
		}
	}
}

public
ScheduleReqView ScheduleReqViewActive {
	get { return scheduleReqViewActive; }
	set { if (this.scheduleReqViewActive != value){
			this.scheduleReqViewActive = value;			
		}
	}
}

public
ScheduleReqView ScheduleReqViewFilter{
	get { return this.scheduleReqViewFilter; }
	set {
        ScheduleReqView raux = value;
        if (raux == null)
            raux = getCoreFactory().createScheduleReqView();

        if (this.scheduleReqViewFilter != raux){
			this.scheduleReqViewFilter = raux;			
		}
	}
}

public
DateTime StartDateFilter{
	get { return startDateFilter; }
	set { if (this.startDateFilter != value){
			this.startDateFilter = value;			
		}
	}
}

public
DateTime StopDateFilter{
	get { return stopDateFilter; }
	set { if (this.stopDateFilter != value){
			this.stopDateFilter = value;			
		}
	}
}

public
ScheduleReqViewContainer ScheduleReqViewContainer {
	get { return scheduleReqViewContainer; }
	set { if (this.scheduleReqViewContainer != value){
			this.scheduleReqViewContainer = value;			
		}
	}
}

public
ScheduleReqViewContainer ScheduleReqViewContainerFiltered {
	get { return scheduleReqViewContainerFiltered; }
	set { if (this.scheduleReqViewContainerFiltered != value){
			this.scheduleReqViewContainerFiltered = value;			
		}
	}
}

public
SchedulePart SchedulePartCloneBkp {
	get { return schedulePartCloneBkp; }
	set { if (this.schedulePartCloneBkp != value){
			this.schedulePartCloneBkp = value;			
		}
	}
}

public
ScheduleHdr readHdr(int id){
    ScheduleHdr scheduleHdr = null;
    try {
        if (id  > 0){
            scheduleHdr = getCoreFactory().readScheduleHdr(id);                        
            if (scheduleHdr!= null)
                getCoreFactory().loadScheduleHdrAdditionalInfo(scheduleHdr,hashMachinesById);
        }
       
    } catch (Exception ex) {
        MessageBox.Show("readHdr Exception: " + ex.Message);        
    }
    return scheduleHdr;
}

public
void loadSearchByCombo(ComboBox searchByComboBox){
    loadCombo(searchByComboBox,"Id");    
}

public
void loadSearchByHotListCombo(ComboBox searchByComboBox){
    loadCombo(searchByComboBox, "Machine");        
}

public
void loadReqFilter(ComboBox comboBox){    
    try {
        ObservableCollection <Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        ArrayList                   arrayList = scheduleHdr!= null ? scheduleHdr.getDifferentsRequirment() : new ArrayList();
        ScheduleReqView             scheduleReqView = null;
        ScheduleReqView             scheduleReqAll = getCoreFactory().createScheduleReqView();
        ScheduleReqView             scheduleReqAlrSelected = null;
        ScheduleReqViewContainer    scheduleReqViewContainer = getCoreFactory().createScheduleReqViewContainer();
        
        if (comboBox.SelectedItem != null)
            scheduleReqAlrSelected = (ScheduleReqView)((Nujit.NujitWms.WinForms.Util.ComboBoxItem)comboBox.SelectedItem).Content;
    
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All", scheduleReqAll));            
        for (int i=0; i < arrayList.Count;i++) {    //load mach info
            scheduleReqView = (ScheduleReqView)arrayList[i];            
            loadMachineInfo(scheduleReqView);            
            scheduleReqViewContainer.Add(scheduleReqView);            
        }

        scheduleReqViewContainer.sortByMachine();   //show sorted by machine
        for (int i=0; i < scheduleReqViewContainer.Count;i++) {
            scheduleReqView = scheduleReqViewContainer[i];
            scheduleReqView.Detail=i+1;
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(scheduleReqView.MachShow,scheduleReqView));
        }
                
        comboBox.ItemsSource = list;
        if (scheduleReqAlrSelected != null)
            setSelectedComboBoxItem(comboBox, scheduleReqAlrSelected);
        else
            setSelectedComboBoxItem(comboBox, scheduleReqAll);
            
    } catch (Exception ex) {
        MessageBox.Show("loadReqFilter Exception: " + ex.Message);        
    }
}
        
public
void loadStatus(ComboBox comboBox,bool ball){
    try {         
        ObservableCollection <Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
            
        if (ball)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Active",Constants.STATUS_ACTIVE));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Inactive",Constants.STATUS_INACTIVE));
                       
        comboBox.ItemsSource = list;

        if (ball && comboBox.Items.Count > 0)            
            comboBox.SelectedIndex=0;
        
    } catch (Exception ex) {
        MessageBox.Show("loadStatus Exception: " + ex.Message);        
    }
}

public
void loadPriority(ComboBox comboBox,bool ball){
    try {         
        ObservableCollection <Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
            
        if (ball)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Slow","0"));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Normal","1"));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("High","2"));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Urgent","3"));

        comboBox.ItemsSource = list;

        if (ball && comboBox.Items.Count > 0)            
            comboBox.SelectedIndex=0;
        
    } catch (Exception ex) {
        MessageBox.Show("loadStatus Exception: " + ex.Message);        
    }
}

public
void loadReqTypes(ComboBox comboBox){
    try {         
        ObservableCollection <Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
            
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Labour", CapacityReq.REQUIREMENT_LABOUR));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Machine", CapacityReq.REQUIREMENT_MACHINE));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Task", CapacityReq.REQUIREMENT_TASK));                    
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Tool", CapacityReq.REQUIREMENT_TOOL));                    
                       
        comboBox.ItemsSource = list;
        
    } catch (Exception ex) {
        MessageBox.Show("loadReqTypes Exception: " + ex.Message);        
    }
}

public
void loadShiftTaskComboBox(ComboBox shiftTaskComboBox){
    try { 
        CapShiftTaskContainer   capShiftTaskContainer = coreFactory.readCapShiftTaskByFilters("", "", "", 0);
        ObservableCollection <Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        string                  saux = "";
    
        foreach(CapShiftTask capShiftTask in capShiftTaskContainer){
            saux = capShiftTask.DirInd + " - " + capShiftTask.TaskName; 
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(saux, capShiftTask.Id.ToString()));
        }
                       
        shiftTaskComboBox.ItemsSource = list;
        if (shiftTaskComboBox.Items.Count > 0)
            shiftTaskComboBox.SelectedIndex = 0;        

    } catch (Exception ex) {
        MessageBox.Show("loadShiftTaskComboBox Exception: " + ex.Message);        
    }
}

public
void loadDownType(ComboBox comboBox){
    try {         
        ObservableCollection <Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();

        string[][] items = Constants.getDownTypeList();
        for (int i=0; i < items.Length;i++)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(items[i][0], items[i][1]));                                
        
        setDataContextCombo(comboBox,list);
                
    } catch (Exception ex) {
        MessageBox.Show("loadDownType Exception: " + ex.Message);        
    }
}

public
void loadDownTypeNames(ComboBox comboBox){
    try {         
        ObservableCollection <Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Down"           , "Down"));                                
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("NonScheduled"   , "NonScheduled"));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Maintenance"    , "Maintenance"));
                               
        comboBox.ItemsSource = list;
        
    } catch (Exception ex) {
        MessageBox.Show("loadDownTypeNames Exception: " + ex.Message);        
    }
}

public 
void save(){    
    try{
        reloadFilters();

        if (scheduleHdr.Id > 0)
            getCoreFactory().updateScheduleHdr(scheduleHdr);
        else
            getCoreFactory().writeScheduleHdr(scheduleHdr);
                                                   
    }catch (Exception ex){
        MessageBox.Show("save Exception: " + ex.Message);
    }                       
}
                
public
void loadColumnsOnHeaderGrid(ListView hdrListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("Id", "Id", BindingMode.OneWay, 70, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Date Created", "DateCreated", BindingMode.OneWay, 70, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Status", "Status", BindingMode.OneWay, 50, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Plant", "Plant", BindingMode.OneWay,90, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());
                        
        hdrListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

public        
void loadColumnsOnRequirementGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
    
        textBlockColumnListView = new TextBlockColumnListView("Request", "MachShow", BindingMode.OneWay,55, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());
               
        textBlockColumnListView = new TextBlockColumnListView("ID", "TypeDescription", BindingMode.OneWay,120, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Type", "TypeDescription2", BindingMode.OneWay,100, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Start DateTime", "StartDateShow", BindingMode.OneWay,100, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Left);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("End DateTime", "EndDateShow", BindingMode.OneWay,100, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Left);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Hrs", "HoursSubtractShow", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("StShf", "StartShiftShow", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("EnShf", "EndShift", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Priority", "Priority", BindingMode.OneWay,35, listView);
        textBlockColumnListView.setConverter(new PriorityConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Queue", "Queue", BindingMode.OneWay,30, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("F/P", "IsFamily", BindingMode.OneWay,10, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Scheduled", "ScheduledShow", BindingMode.OneWay,55, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Reported", "ReportedShow", BindingMode.OneWay,40, listView);        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Remains", "QtyToCompleteShow", BindingMode.OneWay,40, listView);        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
                
        textBlockColumnListView = new TextBlockColumnListView("Uom", "Uom", BindingMode.OneWay,20, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Mat", "MaterialFlag", BindingMode.OneWay,20, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("RetCnt", "RetContFlag", BindingMode.OneWay,30, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Tools", "ToolFlag", BindingMode.OneWay,20, listView);                
        gridView.Columns.Add(textBlockColumnListView.process());        

        textBlockColumnListView = new TextBlockColumnListView("RunStd", "RunStdShow", BindingMode.OneWay,30, listView);        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("CavNum", "CavityNumShow", BindingMode.OneWay,30, listView);        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
              
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnRequirementGrid Exception: " + ex.Message);        
    }
}

public        
void loadColumnsOnPartGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                          
        textBlockColumnListView = new TextBlockColumnListView("Dt#", "Detail", BindingMode.OneWay,15, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Part", "Part", BindingMode.OneWay,150, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
                
        textBlockColumnListView = new TextBlockColumnListView("Seq", "Seq", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 
        
        textBlockColumnListView = new TextBlockColumnListView("Qty", "Qty", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 
                       
        listView.View = gridView;   
    
    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnPartGrid Exception: " + ex.Message);        
    }
}

public        
void loadColumnsOnPartDetailsGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                
        textBlockColumnListView = new TextBlockColumnListView("Dt#", "SubDetail", BindingMode.OneWay,15, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Part", "Part", BindingMode.OneWay,150, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
                
        textBlockColumnListView = new TextBlockColumnListView("Seq", "Seq", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 
        
        textBlockColumnListView = new TextBlockColumnListView("Qty", "Qty", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 
                                                    
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnPartDetailsGrid Exception: " + ex.Message);        
    }
} 

public        
void loadColumnsOnReceiptPartGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                
        textBlockColumnListView = new TextBlockColumnListView("Dt#", "SubDetail", BindingMode.OneWay,15, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Start Date", "StartDate", BindingMode.OneWay,120, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;          
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "DateTime");                      
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Receipt Date", "RecDate", BindingMode.OneWay,120, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;          
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "DateTime");                      
        gridView.Columns.Add(textBlockColumnListView.process());
                
        textBlockColumnListView = new TextBlockColumnListView("Shf", "RecShift", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 
        
        textBlockColumnListView = new TextBlockColumnListView("QtyReq.", "RecQty", BindingMode.OneWay,50, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 

        textBlockColumnListView = new TextBlockColumnListView("QtyRep.", "RepQty", BindingMode.OneWay,50, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 

        textBlockColumnListView = new TextBlockColumnListView("Remains", "RemainsQty", BindingMode.OneWay,50, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 
                                                    
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnPartDetailsGrid Exception: " + ex.Message);        
    }
} 

public        
void loadColumnsOnMaterialConsumitionGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                
        textBlockColumnListView = new TextBlockColumnListView("Dt#", "SubSubDetail", BindingMode.OneWay,15, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Start Date", "StartDate", BindingMode.OneWay,120, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;          
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "DateTime");                      
        gridView.Columns.Add(textBlockColumnListView.process());
                
        textBlockColumnListView = new TextBlockColumnListView("Shf", "StartShift", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 

        textBlockColumnListView = new TextBlockColumnListView("Material", "MatPart", BindingMode.OneWay,150, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process()); 
        
        textBlockColumnListView = new TextBlockColumnListView("Seq", "MatSeq", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 

        textBlockColumnListView = new TextBlockColumnListView("QtyReq.", "QtyReq", BindingMode.OneWay,50, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 

        textBlockColumnListView = new TextBlockColumnListView("Consume", "QtyConsum", BindingMode.OneWay,50, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Reported", "QtyReported", BindingMode.OneWay,50, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());       

        textBlockColumnListView = new TextBlockColumnListView("Remains", "RemainsQty", BindingMode.OneWay,50, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 

        textBlockColumnListView = new TextBlockColumnListView("Type", "MatTypeDesc", BindingMode.OneWay,70, listView);
        gridView.Columns.Add(textBlockColumnListView.process());
                                                    
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnMaterialConsumitionGrid Exception: " + ex.Message);        
    }
} 

public        
void loadColumnsOnTaskGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                          
        textBlockColumnListView = new TextBlockColumnListView("Dtl#", "Detail", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Task", "TaskDescription", BindingMode.OneWay,150, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Start DateTime", "StartDateShow", BindingMode.OneWay,100, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Left);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("End DateTime", "EndDateShow", BindingMode.OneWay,100, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Left);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Hrs", "HoursSubtract", BindingMode.OneWay,30, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("StShf", "StartShift", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("EnShf", "EndShift", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Employee", "TotEmployees", BindingMode.OneWay,40, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("EmplHr", "EmployeeHours", BindingMode.OneWay,40, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());  

        textBlockColumnListView = new TextBlockColumnListView("Tot.Hrs", "Hours", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Priority", "Priority", BindingMode.OneWay,35, listView);
        textBlockColumnListView.setConverter(new PriorityConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);            
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Queue", "Queue", BindingMode.OneWay,30, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
                                                
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnTaskGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnMaterialGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));              

        textBlockColumnListView = new TextBlockColumnListView("Material", "MatID", BindingMode.OneWay,150, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Seq", "MatSeq", BindingMode.OneWay,20, listView);  
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);              
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;     
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "int");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Description", "MatDescShow", BindingMode.OneWay,180, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Qty.Req.", "MatQty", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Inventory", "MatQohShow", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Type", "MatTypeDescShow", BindingMode.OneWay,70, listView);
        gridView.Columns.Add(textBlockColumnListView.process());
                        
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnMaterialGrid Exception: " + ex.Message);        
    }
}

public
ScheduleHdr createHdr(){        
    try{            
        scheduleHdr = coreFactory.createScheduleHdr();            
        scheduleHdr.Plant = Configuration.DftPlant;

        HotListHdrContainer hotListHdrContainer  = getCoreFactory().readLastHotListHdrDifferentsPlants();        
        if (hotListHdrContainer.Count > 0)
            scheduleHdr.Plant = hotListHdrContainer[0].Plant;

    }catch (Exception ex){
        MessageBox.Show("createHdr Exception: " + ex.Message);
    }     
    return scheduleHdr;
}

public
SchedulePart createPart(int imachId){
    SchedulePart schedulePart = getCoreFactory().createSchedulePart();            
    try{                                        
        DateTime dhourLater = DateTime.Now.AddHours(1);                                         
        schedulePart.StartDate= new DateTime(dhourLater.Year, dhourLater.Month, dhourLater.Day, dhourLater.Hour, 0, 0);

        dhourLater = schedulePart.StartDate.AddHours(1);
        schedulePart.EndDate  = new DateTime(dhourLater.Year, dhourLater.Month, dhourLater.Day, dhourLater.Hour,0,0);               

        schedulePart.MachId= imachId;
        loadMachineInfo(schedulePart);        
        assignDates(schedulePart);
    }catch (Exception ex){
        MessageBox.Show("createPart Exception: " + ex.Message);
    }         
    return schedulePart;                            
}

public
void loadMachineInfo(ScheduleMachine scheduleMachine){
    try { 
        if (scheduleMachine!= null){
            Machine machine = getMachineById(hashMachinesById,scheduleMachine.MachId);
            loadMachineInfo(scheduleMachine,machine);            
        }
    }catch (Exception ex){
        MessageBox.Show("loadMachineInfo Exception: " + ex.Message);
    } 
}

public
void loadMachineInfo(ScheduleMachine scheduleMachine,Machine machine){
    try { 
        if (scheduleMachine!= null && machine!= null){
            scheduleMachine.MachId      = machine.Id;
            scheduleMachine.MachShow    = machine.Mach;
            scheduleMachine.MachDescShow= machine.Des1;            
        }
    }catch (Exception ex){
        MessageBox.Show("loadMachineInfo Exception: " + ex.Message);
    } 
}

public
ScheduleReqView createRequirment(int ireqId){
    ScheduleReqView scheduleReqView = getCoreFactory().createScheduleReqView();            
    try{                                        
        scheduleReqView.ScheduleType= CapacityReq.REQUIREMENT_MACHINE;
        scheduleReqView.MachId      = ireqId;

        loadMachineInfo(scheduleReqView);
    }catch (Exception ex){
        MessageBox.Show("createRequirment Exception: " + ex.Message);
    }         
    return scheduleReqView;                            
}

public
SchedulePart cloneToModifyPart(SchedulePart schedulePart){    
    schedulePartCloneBkp = schedulePart != null ? getCoreFactory().cloneSchedulePart(schedulePart) : null;
    return schedulePartCloneBkp;// schedulePart;
}

public
void cancelPart(SchedulePart schedulePart){
    if (schedulePart!= null && schedulePartCloneBkp != null)
        schedulePart.copy(schedulePartCloneBkp);       
}

public
SchedulePart copyPart(SchedulePart schedulePart){
    SchedulePart schedulePartOriginal = null;            
    try{
        schedulePartOriginal = getSchedulePart(schedulePart);        
        if (schedulePartOriginal!= null)
            schedulePartOriginal.copy(schedulePart);
    }catch (Exception ex){
        MessageBox.Show("copyPart Exception: " + ex.Message);
    }         
    return schedulePartOriginal;                            
}
        
public
ScheduleTask createTask(int imachineId){
    ScheduleTask scheduleTask = getCoreFactory().createScheduleTask();            
    try{               
        DateTime dhourLater = DateTime.Now.AddHours(1);                                         
        scheduleTask.StartDate= new DateTime(dhourLater.Year, dhourLater.Month, dhourLater.Day, dhourLater.Hour, 0, 0);

        dhourLater = scheduleTask.StartDate.AddHours(1);
        scheduleTask.EndDate  = new DateTime(dhourLater.Year, dhourLater.Month, dhourLater.Day, dhourLater.Hour,0,0);               

        scheduleTask.MachId = imachineId;
        loadMachineInfo(scheduleTask);
        assignDates(scheduleTask);
    }catch (Exception ex){
        MessageBox.Show("createTask Exception: " + ex.Message);
    }         
    return scheduleTask;                            
}

        
public
ScheduleTask createDownTimeTask(ScheduleReqView scheduleReqView){
    ScheduleTask scheduleTask = getCoreFactory().createScheduleTask();            
    try{    
        scheduleTask = createTask(scheduleReqView!= null ? scheduleReqView.MachId:0);        
        CapShiftTask capShiftTask= getDownTimeTask();

        if (capShiftTask!= null){            
            scheduleTask.TaskId = capShiftTask.Id;
            scheduleTask.TaskDescription = capShiftTask.TaskName;
        }

    }catch (Exception ex){
        MessageBox.Show("createDownTimeTask Exception: " + ex.Message);
    }         
    return scheduleTask;                            
}
   
        
public
ScheduleTask cloneToModifyTask(ListView taskListView){
    ScheduleTask scheduleTask = (ScheduleTask)getSelected(taskListView);
    scheduleTaskCloneBkp = scheduleTask != null ? getCoreFactory().cloneScheduleTask(scheduleTask) : null;
    return scheduleTaskCloneBkp;  //scheduleTask;       
}

public
void cancelTask(ScheduleTask scheduleTask){
    if (scheduleTask != null && scheduleTaskCloneBkp != null)
        scheduleTask.copy(scheduleTaskCloneBkp);       
}

public
ScheduleTask copyTask(ScheduleReqView scheduleReqview, ScheduleTask scheduleTask){
    ScheduleTask scheduleTaskOriginal = null;            
    try{
        scheduleTaskOriginal = getScheduleTask(scheduleReqview);
        if (scheduleTaskOriginal != null)
            scheduleTaskOriginal.copy(scheduleTask);
    }catch (Exception ex){
        MessageBox.Show("copyTask Exception: " + ex.Message);
    }         
    return scheduleTaskOriginal;                            
}

public
ScheduleTask copyTask(ScheduleTask scheduleTask){
    ScheduleTask scheduleTaskOriginal = null;            
    try{
        scheduleTaskOriginal = getScheduleTask(scheduleTask);
        if (scheduleTaskOriginal != null)
            scheduleTaskOriginal.copy(scheduleTask);
    }catch (Exception ex){
        MessageBox.Show("copyTask Exception: " + ex.Message);
    }         
    return scheduleTaskOriginal;                            
}
       

public 
bool del(ListView listView){
    bool bresult=false;
    try{            
        ScheduleHdr scheduleHdr = (ScheduleHdr)getSelected(listView);           

        if (scheduleHdr!= null){
            if (System.Windows.Forms.MessageBox.Show("Do You Want To Delete Item ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes){
                getCoreFactory().deleteScheduleHdr(scheduleHdr.Id);                                
                MessageBox.Show("Schedule Deleted, Id :" + scheduleHdr.Id + ".");
                bresult = true;
            }
        }else
            MessageBox.Show("To Delete Item, Select Item First.");

    }catch (Exception ex){
        MessageBox.Show("del Exception: " + ex.Message);
    }                       
    return bresult;
}

public
ScheduleReqView validRequirment(ListView listView){
    ScheduleReqView scheduleReqView = (ScheduleReqView)getSelected(listView);
    if (scheduleReqView!= null && scheduleReqView.MachId <=0)
        scheduleReqView= null;
    
    return scheduleReqView;
}

public 
bool partSearch(TextBox partTextBox,int imachId, SchedulePart schedulePart){        
    bool bresult=false;
    try{            
        ProductWindow productWindow = new ProductWindow();
        productWindow.setMachineIdFilter(imachId);//machine filter

        if ((bool)productWindow.ShowDialog()) {        
            Product product = productWindow.getSelected();
            bresult = loadPartInfo(product, imachId,schedulePart,true,partTextBox);
        }
       
    }catch (Exception ex){
        MessageBox.Show("partSearch Exception: " + ex.Message);
    }  
    return bresult;
}

public 
bool machineSearch(ScheduleMachine scheduleMachine){        
    bool bresult=false;
    try{            
        Machine machine = searchMachine(scheduleHdr!= null ? scheduleHdr.Plant:"");
        
        if (machine!= null){        
            loadMachineInfo(scheduleMachine, machine);            
            bresult=true;
        }
       
    }catch (Exception ex){
        MessageBox.Show("machineSearch Exception: " + ex.Message);
    }  
    return bresult;
}

public 
bool loadPartInfo(Product product,int imachId,SchedulePart schedulePart,bool btryLoadSeq,TextBox partTextBox){
   bool bresult=false;

    if (product!=null){                
            schedulePart.SchedulePartDtlContainer.Clear(); //empty just in case, already filled

            schedulePart.Part =
            partTextBox.Text = product.ProdID;//prod id
        
            schedulePart.Uom = product.StdPackUnit;//uom
            if (string.IsNullOrEmpty(schedulePart.Uom))
                schedulePart.Uom= Constants.DEFAULT_UOM;

            schedulePart.IsFamily = product.FamProd;
            if (btryLoadSeq)  
                schedulePart.Seq = product.SeqLast;
            if (schedulePart.IsFamily.Equals("F")) //if is family add part childs
                addFamilyChildParts(schedulePart);
            
            if (btryLoadSeq)  
                schedulePart.Seq=-1; //-1 trying to find sequence                
            if (!loadBuildMachineValues(imachId, schedulePart))                                      
                schedulePart.Seq = product.SeqLast;
            
            fillIfHasMaterials(schedulePart);                    
            bresult=true;
    }
    return bresult;
}

public
bool loadBuildMachineValues(int imachId,SchedulePart schedulePart){
    bool bresult=false;
    try{
        if (schedulePart != null){
            RoutingContainer routingContainer = getCoreFactory().getBuildByFilters(this.scheduleHdr.Plant,schedulePart.Part,schedulePart.Seq, imachId, true,false);
            if  (routingContainer.Count > 0) {
                Routing routing = routingContainer[0];

                schedulePart.Seq = routing.Seq;
                schedulePart.RunStd= routing.RunStd;
                schedulePart.CavityNum= routing.CavityNum;
                schedulePart.Qty = schedulePart.calculateHourMachineBuild();

                bresult=true;  
            }                    
        }
                     
    }catch (Exception ex){
        MessageBox.Show("loadBuildMachineValues Exception: " + ex.Message);
    }    
    return bresult;                      
}


private
void addFamilyChildParts(SchedulePart schedulePart){         
    string[][] forSeek = coreFactory.getComponentsFromFamily(schedulePart.Part);
    SchedulePartDtl schedulePartDtl=null;

    schedulePart.SchedulePartDtlContainer.Clear();
    for (int i=0; i < forSeek.Length;i++){ 		
		string[] line = forSeek[i];
        string spart =line[0];
        int iseq =int.Parse(line[1]);

        schedulePartDtl = schedulePart.SchedulePartDtlContainer.getByPartSeq(spart,iseq);
        if (schedulePartDtl==null){ 
            schedulePartDtl = coreFactory.createSchedulePartDtl();        
            schedulePartDtl.Part = line[0];
            schedulePartDtl.Seq = int.Parse(line[1]);		
            schedulePartDtl.Qty = decimal.Parse(line[2]);
            schedulePart.SchedulePartDtlContainer.Add(schedulePartDtl);
        }
        schedulePart.fillRedundances();//sample family Part=FTENCC1992HLAB
        //MessageBox.Show("Part." + schedulePartDtl.Part + "\n Seq." + schedulePartDtl.Seq + "\n Qty." + schedulePartDtl.Qty.ToString("0.00"));
    }
}

public
void deleteSchedulePart(ListView reqListView, SchedulePart schedulePart){     
    try{
        ScheduleReqView         scheduleReqView = (ScheduleReqView)deleltedSelected(reqListView);
        
        if (scheduleHdr!= null && scheduleReqView != null){
            if (schedulePart!= null)
                scheduleHdr.SchedulePartContainer.Remove(schedulePart);      
                
            scheduleHdr.fillRedundances();            
            loadRequirmentGrid(reqListView);
            save();
        }        
        
    }catch (Exception ex){
        MessageBox.Show("deleteSchedulePart Exception: " + ex.Message);
    }    
}

public
void deleteScheduleTask(ListView reqListView, ListView listView){ 
    try{         
        ScheduleTask            scheduleTask = (ScheduleTask)deleltedSelected(listView); 
        
        if (scheduleHdr != null && scheduleTask != null){            
            scheduleHdr.ScheduleTaskContainer.Remove(scheduleTask);          
            scheduleHdr.fillRedundances();
                        
            loadRequirmentGrid(reqListView);
            save();
        }        
        
    }catch (Exception ex){
        MessageBox.Show("deleteScheduleTask Exception: " + ex.Message);
    }    
}

public
bool validProduct(SchedulePart schedulePart,TextBox partTextBox){ 
    bool    bresult=false;
    try{ 
        Product product= null; 

        if (string.IsNullOrEmpty(schedulePart.Part)){ 
            MessageBox.Show("Please, Enter Part Value.");
            partTextBox.Focus();
        } else{ 
            product = coreFactory.readProduct(schedulePart.Part); 
            if (product==null){
                MessageBox.Show("Please, Enter Valid Part Value.");
                partTextBox.Focus();
            }else
                bresult=true;
        }

    }catch (Exception ex){
        MessageBox.Show("validProduct Exception: " + ex.Message);
    } 

    return bresult;
}

public
bool validMachine(ScheduleMachine scheduleMachine, TextBox machTextBox){ 
    bool    bresult=false;
    try{ 
        Machine machine = null; 

        if (scheduleMachine.MachId <= 0){ 
            MessageBox.Show("Please, Enter Machine Value.");
            machTextBox.Focus();
        } else{ 
            machine = coreFactory.readMachineById(scheduleMachine.MachId); 
            if (machine == null){
                MessageBox.Show("Please, Enter Valid Machine Value.");
                machTextBox.Focus();
            }else{                
                bresult=true;
                loadMachineInfo(scheduleMachine,machine);
            }
        }

    }catch (Exception ex){
        MessageBox.Show("validMachine Exception: " + ex.Message);
    } 

    return bresult;
}

public
bool validTask(ScheduleTask scheduleTask){ 
    bool    bresult=false;
    try{ 
        CapShiftTask capShiftTask = null; 

        if (scheduleTask.TaskId <= 0){ 
            MessageBox.Show("Please, Select Task Value.");            
        } else{ 
            capShiftTask = coreFactory.readCapShiftTask(scheduleTask.TaskId); 
            if (capShiftTask == null){
                MessageBox.Show("Please, Enter Valid Task Value.");               
            }else{
                bresult=true;     
                scheduleTask.TaskDescription = capShiftTask.TaskName;
            }                           
        }

    }catch (Exception ex){
        MessageBox.Show("validTask Exception: " + ex.Message);
    } 

    return bresult;
}

public
ScheduleReqView loadSelRequirment(ListView reqlistView,ListView partDtlListView,ListView taskListView,ListView materialsListView,ListView packagingListView,ListView partReceiptsDtlListView,ListView matConsumDtlListView){ 
    ScheduleReqView         scheduleReqView = null;        
    try{
        scheduleReqView = (ScheduleReqView)getSelected(reqlistView);        
        ScheduleTaskContainer       scheduleTaskContainer = getCoreFactory().createScheduleTaskContainer();        
        
        if (scheduleHdr != null && scheduleReqView!= null)            
           scheduleTaskContainer = scheduleHdr.ScheduleTaskContainer.getByMachId(scheduleReqView.MachId);    
        
        loadPartGrid(partDtlListView, scheduleReqView);  
        loadTaskGrid(taskListView, scheduleTaskContainer, scheduleReqView);  
        loadMaterialGrid(materialsListView,scheduleReqView);
        loadPackGrid(packagingListView,scheduleReqView);
        loadGrid(partReceiptsDtlListView, scheduleReqView != null ? scheduleReqView.ScheduleReceiptPartContainer: null);
        
        loadMaterialConsumitionGrid(matConsumDtlListView,getSchedulePart(scheduleReqView));
    
    }catch (Exception ex){
        MessageBox.Show("loadRequirmentGrid Exception: " + ex.Message);
    }                           
    return scheduleReqView;
}

public
void loadPartGrid(ListView listView,ScheduleReqView scheduleReqView){
    try{
        SchedulePartDtlContainer    schedulePartDtlContainer = getCoreFactory().createSchedulePartDtlContainer();
        SchedulePart                schedulePart = getSchedulePart(scheduleReqView);

        if (schedulePart!= null){      
            if (schedulePart.SchedulePartDtlContainer.Count > 0)
                schedulePartDtlContainer = schedulePart.SchedulePartDtlContainer;

            if (schedulePartDtlContainer.Count < 1){
                //if not family part records, we create like Part record on the fly
                SchedulePartDtl schedulePartDtl = getCoreFactory().createSchedulePartDtl();
                schedulePartDtl.Detail = schedulePart.Detail;
                schedulePartDtl.Part = schedulePart.Part;
                schedulePartDtl.Seq = schedulePart.Seq;
                schedulePartDtl.Qty = schedulePart.Qty;
                schedulePartDtlContainer.Add(schedulePartDtl);
            }
        }

        listView.DataContext = schedulePartDtlContainer;
        listView.ItemsSource = schedulePartDtlContainer; 
                
        if (listView.Items.Count > 0)
            listView.SelectedIndex = 0;        
        
    }catch (Exception ex){
        MessageBox.Show("loadPartGrid Exception: " + ex.Message);
    } 

}

public
void loadTaskGrid(ListView listView, ScheduleTaskContainer scheduleTaskContainer){
    loadTaskGrid(listView, scheduleTaskContainer, null);
}

public
void loadTaskGrid(ListView listView,ScheduleTaskContainer scheduleTaskContainer, ScheduleReqView scheduleReqView){
    try{
        ScheduleTask            scheduleTask = getScheduleTask(scheduleReqView);
        ScheduleTaskContainer   scheduleTaskContainerFiltered = getCoreFactory().createScheduleTaskContainer();
                
        scheduleTaskContainerFiltered.add(scheduleTaskContainer);
        scheduleTaskContainerFiltered.applyFilters(startDateFilter,stopDateFilter);

        listView.DataContext = scheduleTaskContainerFiltered;
        listView.ItemsSource = scheduleTaskContainerFiltered; 
         if (scheduleTask != null)
            setSelected(listView, scheduleTask);
        else if (listView.Items.Count > 0)
            listView.SelectedIndex = 0;  
        
    }catch (Exception ex){
        MessageBox.Show("loadTaskGrid Exception: " + ex.Message);
    } 
}

public
void loadPartDetails(ListView listView,SchedulePartDtlContainer schedulePartDtlContainer){
    try{
        listView.DataContext = schedulePartDtlContainer;
        listView.ItemsSource = schedulePartDtlContainer; 
        if (listView.Items.Count > 0)
            listView.SelectedIndex = 0;

    }catch (Exception ex){
        MessageBox.Show("loadPartDetails Exception: " + ex.Message);
    } 

}

public
ScheduleReqView getScheduleReqView(ListView listView){    
    ScheduleReqView scheduleReqView = (ScheduleReqView)getSelected(listView);        
    return scheduleReqView;
}

public
SchedulePart getSchedulePart(ScheduleReqView scheduleReqView){
    SchedulePart    schedulePart=null;
        
    if (scheduleReqView != null && scheduleReqView.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_PART)  && scheduleHdr!=null){
        schedulePart = scheduleHdr.SchedulePartContainer.getByDetail(scheduleReqView.Detail);
    }
    return schedulePart;
}

public
SchedulePart getSchedulePart(SchedulePart schedulePartNew){
    SchedulePart schedulePart = null;
        
    if (schedulePartNew != null && scheduleHdr!=null){
        schedulePart = scheduleHdr.SchedulePartContainer.getByDetail(schedulePartNew.Detail);
    }
    return schedulePart;
}

public
ScheduleTask getScheduleTask(ScheduleReqView scheduleReqView){
    ScheduleTask    scheduleTask = null;
        
    if (scheduleReqView != null && scheduleReqView.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_TASK)  && scheduleHdr!=null){
        scheduleTask = scheduleHdr.ScheduleTaskContainer.getByDetail(scheduleReqView.Detail);
    }
    return scheduleTask;
}

public
ScheduleTask getScheduleTask(ScheduleTask scheduleTaskNew){
    ScheduleTask scheduleTask = null;
        
    if (scheduleTaskNew != null && scheduleHdr!=null){
        scheduleTask = scheduleHdr.ScheduleTaskContainer.getByDetail(scheduleTaskNew.Detail);
    }
    return scheduleTask;
}

public
ScheduleDown getScheduleDown(ScheduleReqView scheduleReqView){
    ScheduleDown    scheduleDown = null;
        
    if (scheduleReqView != null && scheduleReqView.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_DOWN) && scheduleHdr!=null){
        scheduleDown = scheduleHdr.ScheduleDownContainer.getByDetail(scheduleReqView.Detail);
    }
    return scheduleDown;
}

public
ScheduleDown getScheduleDown(ScheduleDown scheduleDownNew){
    ScheduleDown    scheduleDown = null;
        
    if (scheduleDownNew != null && scheduleHdr!=null){
        scheduleDown = scheduleHdr.ScheduleDownContainer.getByDetail(scheduleDownNew.Detail);
    }
    return scheduleDown;
}

public
void loadRequirmentGrid(ListView listView){
    try{
        ScheduleReqView             scheduleReqViewSel = (ScheduleReqView)getSelected(listView);
        ScheduleReqViewContainer    scheduleReqViewContainer = reloadFilters();

        listView.DataContext= scheduleReqViewContainer;
        listView.ItemsSource= scheduleReqViewContainer;
         
        if (scheduleReqViewSel!= null)               //if item already selected, try to seelect it again  
            setSelected(listView,scheduleReqViewSel);
        if (listView.SelectedIndex < 0 && listView.Items.Count > 0)//if no item selected, select firt
            listView.SelectedIndex = 0;        

    }catch (Exception ex){
        MessageBox.Show("loadRequirmentGrid Exception: " + ex.Message);
    } 
}

public
CapShiftTask getCapShiftTask(int id){
    CapShiftTask capShiftTask= null;
    try{
        capShiftTask  = getCoreFactory().readCapShiftTask(id);          
    }catch (Exception ex){
        MessageBox.Show("getCapShiftTask Exception: " + ex.Message);
    }
    return capShiftTask;
}

public
bool loadShiftTaskName(ScheduleTask scheduleTask){    
    bool bresult=false;
    try{
        CapShiftTask capShiftTask = getCapShiftTask(scheduleTask.TaskId); 
        if (capShiftTask!= null)  {                        
            scheduleTask.TaskDescription = capShiftTask.TaskName;
            bresult =true;
        }
    }catch (Exception ex){
        MessageBox.Show("loadShiftTaskName Exception: " + ex.Message);
    }
    return bresult;
}

public
ScheduleReqView createScheduleReqView(SchedulePart schedulePart,ScheduleTask scheduleTask,ScheduleDown scheduleDown){ 
    ScheduleReqView             scheduleReqView = getCoreFactory().createScheduleReqView();

    //build ReqView on the fly    
    if (schedulePart!= null)        
        scheduleReqView.copy(schedulePart);

    if (scheduleTask != null)        
        scheduleReqView.copy(scheduleTask);

    if (scheduleDown != null)        
        scheduleReqView.copy(scheduleDown);
  
    return scheduleReqView;
 }

public
ScheduleReqView getAlreadySameDates(bool badding,SchedulePart schedulePart){    
    ScheduleReqView             scheduleReqView = getCoreFactory().createScheduleReqView();
    ScheduleReqView             scheduleReqViewFound = null;

    if (schedulePart!= null){
        //build ReqView on the fly        
        scheduleReqView.copy(schedulePart);

        scheduleReqViewFound = scheduleReqViewContainer.getAlreadyPartFromDateRange(badding,scheduleReqView);
    }        
    return scheduleReqViewFound;
}

public
ScheduleReqView getAlreadySameDates(bool badding,ScheduleTask scheduleTask){    
    ScheduleReqView             scheduleReqView = getCoreFactory().createScheduleReqView();
    ScheduleReqView             scheduleReqViewFound = null;

    if (scheduleTask != null){
        //build ReqView on the fly        
        scheduleReqView.copy(scheduleTask);

        scheduleReqViewFound = scheduleReqViewContainer.getAlreadyPartFromDateRange(badding,scheduleReqView);
    }        
    return scheduleReqViewFound;
}

public
ScheduleReqView getAlreadySameDates(bool badding,ScheduleDown scheduleDown){    
    ScheduleReqView             scheduleReqView = getCoreFactory().createScheduleReqView();
    ScheduleReqView             scheduleReqViewFound = null;

    if (scheduleDown != null){
        //build ReqView on the fly        
        scheduleReqView.copy(scheduleDown);

        scheduleReqViewFound = scheduleReqViewContainer.getAlreadyPartFromDateRange(badding,scheduleReqView);
    }        
    return scheduleReqViewFound;
}

public
void loadPartSequences(ComboBox comboBox, SchedulePart schedulePart){
    try { 
               
        if (schedulePart != null){
            //string[][]  items = getCoreFactory().getProductPlanAsString(schedulePart.Part);
            string[] items = getCoreFactory().getValidsSeqsForProduct(schedulePart.Part);
            ObservableCollection <Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();                
    
            for (int i=0; i < items.Length;i++)
                list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(items[i], items[i]));
                        
            if (items.Length < 1){ //if not seq list , I will add at least last seq
                Product  product = getCoreFactory().readProduct(schedulePart.Part);                    
                if (product != null)
                    list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(product.SeqLast.ToString(), product.SeqLast.ToString()));
            }
            
            comboBox.ItemsSource = list;
            bool bexists = setSelectedComboBoxItem(comboBox, schedulePart.Seq.ToString());
            if (!bexists){
                list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(schedulePart.Seq.ToString(), schedulePart.Seq.ToString()));                
                comboBox.ItemsSource = list;
            }

        }
        /*
        
        if (schedulePart != null){
            string[][] buildItems= getCoreFactory().getBuildByFilters(schedulePart.Part,-1,0,true);

            for (int i=0; i < buildItems.Length;i++){
                list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(buildItems[i][1], buildItems[i][1]));                
            }

        }*/
        
    } catch (Exception ex) {
        MessageBox.Show("loadPartSequences Exception: " + ex.Message);        
    }
}

public
void assignDates(ScheduleTask scheduleTask){
    DateTime startDateTime = DateTime.Now;
    DateTime endDateTime = DateTime.Now;
    DateTime dateTime = DateTime.Now;

    if (scheduleHdr!= null){
        if (scheduleHdr.getMaxDates(scheduleTask.MachId,out startDateTime,out endDateTime)){        
            scheduleTask.StartDate = endDateTime;
            dateTime = scheduleTask.StartDate.AddHours(1);
            scheduleTask.EndDate = dateTime;
        }
    }
}

public
void assignDates(ScheduleDown scheduleDown){
    DateTime startDateTime = DateTime.Now;
    DateTime endDateTime = DateTime.Now;
    DateTime dateTime = DateTime.Now;

    if (scheduleHdr != null){
        if (scheduleHdr.getMaxDates(scheduleDown.MachId,out startDateTime,out endDateTime)){        
            scheduleDown.StartDate = endDateTime;
            dateTime = scheduleDown.StartDate.AddHours(1);
            scheduleDown.EndDate = dateTime;
        }
    }
}

public
void assignDates(SchedulePart schedulePart){
    DateTime startDateTime = DateTime.Now;
    DateTime endDateTime = DateTime.Now;
    DateTime dateTime = DateTime.Now;

    if (scheduleHdr != null){
        if (scheduleHdr.getMaxDates(schedulePart.MachId,out startDateTime,out endDateTime)){        
            schedulePart.StartDate = endDateTime;
            dateTime = schedulePart.StartDate.AddHours(1);
            schedulePart.EndDate = dateTime;
        }
    }
}

public
void loadMaterialGrid(ListView listView,ScheduleReqView scheduleReqView){
    try { 
        SchedulePart schedulePart = getSchedulePart(scheduleReqView);
        loadMaterialGrid(listView,schedulePart);

    } catch (Exception ex) {
        MessageBox.Show("loadMaterialGrid Exception: " + ex.Message);        
    }
}

public
void loadMaterialGrid(ListView listView,SchedulePart schedulePart){
    try { 
        BomSumContainer bomSumContainer = getCoreFactory().createBomSumContainer();

        if (schedulePart!= null)
            bomSumContainer = getCoreFactory().getSubMaterialsMainLevelAndLowerSeqButNotLowerBom(schedulePart.Part,schedulePart.Seq,scheduleHdr.Plant,Constants.STRING_YES,1);
            
        setDataContextListView(listView,bomSumContainer);        

    } catch (Exception ex) {
        MessageBox.Show("loadMaterialGrid Exception: " + ex.Message);        
    }
}

public
void fillIfHasMaterials(SchedulePart schedulePart){
    try {         
        if (schedulePart!= null){            
            BomSumContainer bomSumContainer = getCoreFactory().getSubMaterialsMainLevelAndLowerSeqButNotLowerBom(schedulePart.Part, schedulePart.Seq,scheduleHdr.Plant,Constants.STRING_YES,1);
            schedulePart.MaterialFlag = bomSumContainer.Count > 0 ? Constants.STRING_YES : Constants.STRING_NO;
        }

    } catch (Exception ex) {
        MessageBox.Show("fillIfHasMaterials Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnPackGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("StdPack", "StdPack", BindingMode.OneWay, 70, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("PackType", "PackType", BindingMode.OneWay, 50, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("SkidQty", "SkidQty", BindingMode.OneWay, 50, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("SkidType", "SkidType", BindingMode.OneWay, 50, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());


        textBlockColumnListView = new TextBlockColumnListView("PackWip", "PackWip", BindingMode.OneWay, 50, listView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(),"");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ContWip", "ContWip", BindingMode.OneWay, 50, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnPackGrid Exception: " + ex.Message);        
    }
}

public
void loadPackGrid(ListView listView,ScheduleReqView scheduleReqView){
    try{
        ProductPlanContainer    productPlanContainer = getCoreFactory().createProductPlanContainer();
        SchedulePart            schedulePart = getSchedulePart(scheduleReqView);
        ProductPlan             productPlan = null;

        if (schedulePart!= null){      
            productPlan = getCoreFactory().readProductPlan(schedulePart.Part, schedulePart.Seq);
            if (productPlan!= null)
                productPlanContainer.Add(productPlan);
        }

        listView.DataContext = productPlanContainer;
        listView.ItemsSource = productPlanContainer; 
                
        if (listView.Items.Count > 0)
            listView.SelectedIndex = 0;        
        
    }catch (Exception ex){
        MessageBox.Show("loadPackGrid Exception: " + ex.Message);
    } 
}

/****************************************** ReceiptPart ********************************************************/
public
ScheduleReceiptPart createReceiptPart(SchedulePart schedulePart){
    ScheduleReceiptPart scheduleReceiptPart = getCoreFactory().createScheduleReceiptPart();            
    try{               
        if (schedulePart!= null){
            scheduleReceiptPart.RecDate = schedulePart.StartDate;
            scheduleReceiptPart.Part = schedulePart.Part;
            scheduleReceiptPart.Seq = schedulePart.Seq;
        } 
    } catch (Exception ex){
        MessageBox.Show("createReceiptPart Exception: " + ex.Message);
    }         
    return scheduleReceiptPart;                            
}

public
ScheduleReceiptPart cloneToModifyReceiptPart(ListView listView){
    ScheduleReceiptPart scheduleReceiptPart = (ScheduleReceiptPart)getSelected(listView);
    scheduleReceiptPartCloneBkp = scheduleReceiptPart != null ? getCoreFactory().cloneScheduleReceiptPart(scheduleReceiptPart) : null;       
    return scheduleReceiptPart;       
}

public
void cancelReceiptPart(ScheduleReceiptPart scheduleReceiptPart){
    if (scheduleReceiptPart != null && scheduleReceiptPartCloneBkp != null)
        scheduleReceiptPart.copy(scheduleReceiptPartCloneBkp);   
}

public
ScheduleReceiptPart copyReceiptPart(SchedulePart schedulePart, ScheduleReceiptPart scheduleReceiptPart){
    ScheduleReceiptPart scheduleReceiptPartOriginal = null;            
    try{
                /*
        scheduleReceiptPartOriginal = scheduleReceiptPart.ScheduleTaskContainer.getBySubDetail(scheduleTask.SubDetail);
        if (scheduleTaskOriginal != null)
            scheduleTaskOriginal.copy(scheduleTask);*/
    }catch (Exception ex){
        MessageBox.Show("copyReceiptPart Exception: " + ex.Message);
    }         
    return scheduleReceiptPartOriginal;                            
}

public
void deleteReceiptPart(ListView receiptPartListView, SchedulePart schedulePart){     
    try{
        ScheduleReceiptPart     scheduleReceiptPart = (ScheduleReceiptPart)deleltedSelected(receiptPartListView);
        
        if (schedulePart != null && scheduleReceiptPart != null){            
            schedulePart.ScheduleReceiptPartContainer.Remove(scheduleReceiptPart);

            schedulePart.fillRedundances();            
            loadGrid(receiptPartListView,schedulePart.ScheduleReceiptPartContainer);            
        }        
        
    }catch (Exception ex){
        MessageBox.Show("deleteReceiptPart Exception: " + ex.Message);
    }    
}

public
void addAutomaticReceiptPart(SchedulePart schedulePart){
    try{                
        if (schedulePart != null /*&& schedulePart.ScheduleReceiptPartContainer.Count < 1*/){                    

            decimal             dhours     = schedulePart.HoursSubtract;
            int                 icurrShift = DateUtil.getShiftNum(schedulePart.StartDate);
            int                 ilastShift = -1;
            int                 ihours = 0;
            int                 itotHours= 0;
            ScheduleReceiptPart scheduleReceiptPart = null;
 
            for (int i=0; i < dhours && schedulePart.RunStd != 0; i++,itotHours++){

                if (ilastShift != icurrShift){
                    scheduleReceiptPart = getCoreFactory().createScheduleReceiptPart();                                                          
                    schedulePart.ScheduleReceiptPartContainer.Add(scheduleReceiptPart);                    
                    ilastShift = icurrShift;
                    ihours=0;
                }else
                    ihours++;

                if (scheduleReceiptPart!= null){
                    if ((dhours - itotHours) < 1){
                        scheduleReceiptPart.RecQty = (dhours - itotHours) * schedulePart.RunStd;
                        scheduleReceiptPart.RecDate= schedulePart.StartDate.AddHours(Convert.ToDouble(itotHours + (dhours - itotHours))).AddSeconds(-1);   
                    }else{                    
                        scheduleReceiptPart.RecQty = (ihours+1) * schedulePart.RunStd;
                        scheduleReceiptPart.RecDate= schedulePart.StartDate.AddHours(itotHours+1).AddSeconds(-1);   
                    }
                }
                icurrShift = DateUtil.getShiftNum(schedulePart.StartDate.AddHours(i+1));
            }
            
        }

    }catch (Exception ex){
        MessageBox.Show("saveReceiptPart Exception: " + ex.Message);
    }  
}    

public
void generateAutomaticReceiptPart(SchedulePart schedulePart,bool bautomatic,ListView matConsumListView){
    try{
        if (bautomatic && schedulePart!= null && !string.IsNullOrEmpty(schedulePart.Part) && getCoreFactory()!= null){
            generateAutomaticReceiptPart(schedulePart,bautomatic);            
            loadMaterialConsumitionGrid(matConsumListView, schedulePart);
        }   

    }catch (Exception ex){
        MessageBox.Show("generateAutomaticReceiptPart Exception: " + ex.Message);
    }
}   

public
void generateAutomaticReceiptPart(SchedulePart schedulePart,bool bautomatic=true){
    try{
        if (bautomatic && schedulePart!= null && !string.IsNullOrEmpty(schedulePart.Part) && getCoreFactory()!= null){            
            getCoreFactory().generateAutomaticReceiptPart(schedulePart);
            BomSumContainer matBomSumContainer = getCoreFactory().getSubMaterialsMainLevelAndLowerSeqButNotLowerBom(schedulePart.Part,schedulePart.Seq,scheduleHdr.Plant,Constants.STRING_YES,1);
            getCoreFactory().generateAutomaticMaterialConsumition(schedulePart, matBomSumContainer);            
        }   

    }catch (Exception ex){
        MessageBox.Show("generateAutomaticReceiptPart Exception: " + ex.Message);
    }
} 

public
void calculatePartEndDate(SchedulePart schedulePart,TextBox quantityTextBox,CheckBox createAutomaticReceiptsCheckBox,ListView matConsumListView){    
    try{
        if (schedulePart!= null && NumberUtil.isInteger64Number(quantityTextBox.Text) && schedulePart.RunStd!=0){
            schedulePart.Qty = Convert.ToInt64(quantityTextBox.Text);
            schedulePart.EndDate = schedulePart.StartDate.AddHours(Convert.ToDouble(schedulePart.Qty / (schedulePart.RunStd !=0 ? schedulePart.RunStd:1)));
            generateAutomaticReceiptPart(schedulePart, (bool)createAutomaticReceiptsCheckBox.IsChecked,matConsumListView);
        }
    }catch (Exception ex){
        MessageBox.Show("calculatePartEndDate Exception: " + ex.Message);
    }  
}

public 
void calculatePartEndDateQty(SchedulePart schedulePart,CheckBox createAutomaticReceiptsCheckBox,ListView matConsumListView){    
    try{
        if (schedulePart != null && schedulePart.RunStd!= 0){
            if (schedulePart.Qty == 0)
                schedulePart.Qty = Convert.ToInt64(schedulePart.calculateHourMachineBuild());
            else
                schedulePart.EndDate = schedulePart.StartDate.AddHours(Convert.ToDouble(schedulePart.Qty / (schedulePart.RunStd != 0 ? schedulePart.RunStd : 1)));

            generateAutomaticReceiptPart(schedulePart, (bool)createAutomaticReceiptsCheckBox.IsChecked, matConsumListView);            
        }
    }catch (Exception ex){
        MessageBox.Show("calculatePartEndDateQty Exception: " + ex.Message);
    }
}

public 
void calculatePartQty(SchedulePart schedulePart,CheckBox createAutomaticReceiptsCheckBox,ListView matConsumListView){    
    try{
        if (schedulePart != null){
            schedulePart.Qty = Convert.ToInt64(schedulePart.calculateHourMachineBuild());    
            generateAutomaticReceiptPart(schedulePart, (bool)createAutomaticReceiptsCheckBox.IsChecked,matConsumListView);            
        }

    }catch (Exception ex){
        MessageBox.Show("calculatePartQty Exception: " + ex.Message);
    }
}

public
void calculateRemainsQty(SchedulePart schedulePart,TextBox quantityReportedTextBox,CheckBox createAutomaticReceiptsCheckBox,ListView matConsumListView){    
    try{
        if (schedulePart!= null && NumberUtil.isInteger64Number(quantityReportedTextBox.Text) && schedulePart.RunStd!=0){
            schedulePart.QtyReported = Convert.ToInt64(quantityReportedTextBox.Text);
            schedulePart.EndDate = schedulePart.StartDate.AddHours(Convert.ToDouble(schedulePart.Qty / (schedulePart.RunStd !=0 ? schedulePart.RunStd:1)));
            generateAutomaticReceiptPart(schedulePart, (bool)createAutomaticReceiptsCheckBox.IsChecked,matConsumListView);            
        }
    }catch (Exception ex){
        MessageBox.Show("calculatePartEndDate Exception: " + ex.Message);
    }  
}

public
void loadMaterialConsumitionGrid(ListView listView,SchedulePart schedulePart){
    try{
        ScheduleMaterialConsumPartContainer scheduleMaterialConsumPartContainer = getCoreFactory().createScheduleMaterialConsumPartContainer();

        if (schedulePart!=null){
            foreach(ScheduleReceiptPart scheduleReceiptPart in schedulePart.ScheduleReceiptPartContainer){
                foreach(ScheduleMaterialConsumPart scheduleMaterialConsumPart in scheduleReceiptPart.ScheduleMaterialConsumPartContainer){
                    scheduleMaterialConsumPartContainer.Add(scheduleMaterialConsumPart);
                }
            }        
        }            
        loadGrid(listView, scheduleMaterialConsumPartContainer);                            

    }catch (Exception ex){
        MessageBox.Show("loadMaterialConsumitionGrid Exception: " + ex.Message);
    } 
}

public
bool setSelectedAnyReqId(ListView listView,string stype,int ireqId){
    bool bresult=false;
    try{        
        int index=0;    
        for(int i=0; i < listView.Items.Count && !bresult; i++){
            ScheduleReqView scheduleReqView = (ScheduleReqView)listView.Items[i];        
            if (scheduleReqView != null && scheduleReqView.ScheduleType.Equals(stype) && scheduleReqView.MachId == ireqId) {                   
                listView.SelectedIndex=index;
                listView.ScrollIntoView(scheduleReqView);
                bresult=true;
            } 
            index++;                
        }     

    }catch (Exception ex){
        MessageBox.Show("setSelectedAnyReqId Exception: " + ex.Message);
    }      
    return bresult;   
}

public
bool adjustFiltersToShowRequirment( ComboBox reqFilterComboBox,
                                    RadDateTimePicker startFilterRadDateTimePicker, RadDateTimePicker stopFilterRadDateTimePicker,
                                    ScheduleReqView scheduleReqView){
    bool            bforceApplyFilters=false;    
    DateTime        startDateMax = DateTime.Now;
    DateTime        endDateMax = DateTime.Now;                
    ScheduleReqView scheduleReqViewFilter =(ScheduleReqView)getSelectedComboBoxItem(reqFilterComboBox);

    try{   
        if (scheduleReqViewFilter == null){
            bforceApplyFilters=true;
            reqFilterComboBox.SelectedIndex = 0; //select all
            scheduleReqViewFilter =(ScheduleReqView)getSelectedComboBoxItem(reqFilterComboBox);
        }  

        if (reqFilterComboBox.SelectedIndex != 0){
            if (scheduleReqViewFilter != null && scheduleReqView != null && (!scheduleReqViewFilter.ScheduleType.Equals(scheduleReqView.ScheduleType) || !scheduleReqViewFilter.MachId.Equals(scheduleReqView.MachId))) { 
                bforceApplyFilters= true;
                reqFilterComboBox.SelectedIndex = 0; //select all
            }
        }   

        if (scheduleReqView!= null){
            //just in case, requirment not showed on screen        
            if (scheduleHdr != null &&  !scheduleHdr.getMaxDates(scheduleReqView.MachId,out startDateMax, out endDateMax))
                startDateMax = endDateMax = DateTime.Now;

            if (startDateMax != DateUtil.MinValue && startDateMax < StartDateFilter){ 
                StartDateFilter = startDateMax.AddDays(-1);
                startFilterRadDateTimePicker.SelectedValue = StartDateFilter;
                bforceApplyFilters =true;   
            }
            if (endDateMax != DateUtil.MinValue && StopDateFilter < endDateMax){ 
                StopDateFilter = endDateMax.AddDays(1);
                stopFilterRadDateTimePicker.SelectedValue = StopDateFilter;
                bforceApplyFilters=true;   
            }                               
        }                

    }catch (Exception ex){
        MessageBox.Show("adjustFiltersToShowRequirment Exception: " + ex.Message);
    }  
    
    return bforceApplyFilters;    
}   

public 
void applyFilters(ListView reqListView,ComboBox reqFilterComboBox){    
    try{        
        ScheduleReqView scheduleReqviewFilter =(ScheduleReqView)getSelectedComboBoxItem(reqFilterComboBox);

        ScheduleReqViewFilter= scheduleReqviewFilter;
        loadRequirmentGrid(reqListView);
    }catch (Exception ex){
        MessageBox.Show("applyFilters Exception: " + ex.Message);
    }                                        
}  

public 
bool scheduleHotList(   ListView reqListView,ComboBox reqFilterComboBox,TextBox partTextBox, 
                        RadDateTimePicker startFilterRadDateTimePicker, RadDateTimePicker stopFilterRadDateTimePicker,
                        bool bonlyMachAlternative,string splant,string spart,int iseq,decimal dqty,int imachId,DateTime scheduleDateTime,
                        out  SchedulePart schedulePart){
    bool        bresult=false;
    schedulePart = getCoreFactory().createSchedulePart();
    try {        
        int                 ireqId = 0;
        ScheduleReqView     scheduleReqView= null;
        Routing             routing = null;
                                          
        RoutingContainer    routingContainer = getCoreFactory().getBuildByFilters(splant, spart, iseq, imachId,true, bonlyMachAlternative);//find machine        
        if  (routingContainer.Count > 0) {                                                        
            routing = routingContainer[0];
            ireqId = routing.MachIdShow;
            if (ireqId > 0){

                scheduleReqView = createRequirment(ireqId);                                                                                           
                scheduleHdr.fillRedundances();
                //loadRequirmentGrid(reqListView); //show new requirment on grid                                                                                                                        
                
                        /*
                if (adjustFiltersToShowRequirment(reqFilterComboBox,startFilterRadDateTimePicker,stopFilterRadDateTimePicker,scheduleReq))
                    applyFilters(reqListView,reqFilterComboBox);
                    */
                ScheduleReqViewActive = scheduleReqView;

               // if (setSelectedAnyReqId(reqListView, scheduleReq.Type, scheduleReq.ReqID)){                                                
                    Product product = getCoreFactory().readProduct(spart);
                    if (product!= null){                                    
                        schedulePart = createPart(scheduleReqView.MachId);

                        if (scheduleDateTime!= DateUtil.MinValue) {
                            if (scheduleDateTime < DateTime.Now){                                 
                                schedulePart.StartDate = scheduleDateTime;  
                            }else if (scheduleDateTime > DateTime.Now || DateUtil.sameDate(scheduleDateTime, DateTime.Now)){ 
                                if (!DateUtil.sameDate(schedulePart.StartDate,scheduleDateTime))
                                    schedulePart.StartDate = schedulePart.EndDate = scheduleDateTime;                                         
                            }
                        }                                
                        schedulePart.Part = spart;
                        schedulePart.Seq = iseq;                                
                        loadPartInfo(product, ireqId, schedulePart,false,partTextBox);
                        schedulePart.RunStd = routing.RunStd;
                        schedulePart.CavityNum = routing.CavityNum;
                        schedulePart.Qty = dqty;
                        schedulePart.EndDate = schedulePart.calculateEndDataMachineBuild();                                    
                        bresult=true;
                    }                        
                     
             //   }else
               //     MessageBox.Show("Sorry, Can Not Select Request = " + ireqId.ToString() +  ".");                                                                 
            }else
                MessageBox.Show("Sorry, Can Not Find Machine/Req To Build Part = " + spart +  ".");
        }else
                MessageBox.Show("Sorry, Can Not Find Machine/Routing To Build Part = " + spart +  ".");
        
    } catch (Exception ex) {
        MessageBox.Show("scheduleHotList Exception: " + ex.Message);
    }
    return bresult;
} 

/************************************************* ***************************************************************************/
public
ScheduleDown createDown(int imachId){
    ScheduleDown scheduleDown = getCoreFactory().createScheduleDown();            
    try{               
        DateTime dhourLater = DateTime.Now.AddHours(1);                                         
        scheduleDown.StartDate= new DateTime(dhourLater.Year, dhourLater.Month, dhourLater.Day, dhourLater.Hour, 0, 0);

        dhourLater = scheduleDown.StartDate.AddHours(1);
        scheduleDown.EndDate  = new DateTime(dhourLater.Year, dhourLater.Month, dhourLater.Day, dhourLater.Hour,0,0);               

        scheduleDown.MachId= imachId;
        loadMachineInfo(scheduleDown);
        assignDates(scheduleDown);
    }catch (Exception ex){
        MessageBox.Show("createDown Exception: " + ex.Message);
    }         
    return scheduleDown;                            
}

public
ScheduleDown cloneToModifyDown(ScheduleDown scheduleDown){    
   scheduleDownCloneBkp = scheduleDown != null ? getCoreFactory().cloneScheduleDown(scheduleDown) : null;
   return scheduleDownCloneBkp;// schedulePart;
}

public
void cancelDown(ScheduleDown scheduleDown){
    if (scheduleDown != null && scheduleDownCloneBkp != null)
        scheduleDown.copy(scheduleDownCloneBkp);       
}

public
ScheduleDown copyDown(ScheduleDown scheduleDown){
    ScheduleDown scheduleDownOriginal = null;            
    try{
        scheduleDownOriginal = getScheduleDown(scheduleDown);
        if (scheduleDownOriginal != null)
            scheduleDownOriginal.copy(scheduleDown);
    }catch (Exception ex){
        MessageBox.Show("copyDown Exception: " + ex.Message);
    }         
    return scheduleDownOriginal;                            
}

public
void deleteScheduleDown(ListView reqListView, ScheduleDown scheduleDown){     
    try{
        ScheduleReqView         scheduleReqView = (ScheduleReqView)deleltedSelected(reqListView);
        
        if (scheduleHdr != null && scheduleReqView != null){
            if (scheduleDown != null)
                scheduleHdr.ScheduleDownContainer.Remove(scheduleDown);      
                
            scheduleHdr.fillRedundances();            
            loadRequirmentGrid(reqListView);
            save();
        }        
        
    }catch (Exception ex){
        MessageBox.Show("deleteScheduleDown Exception: " + ex.Message);
    }    
}

public
void generateSchedDwTime(SchedulePart schedulePart){
    
    if (schedulePart!= null){
        Machine             machine = getMachineById(hashMachinesById, schedulePart.MachId);
        decimal             down     =0;
        decimal             dtotMins =0;
        decimal             dpartialMins =0;
        ScheduleReceiptPart scheduleReceiptPart = null;
        TimeSpan            timeSpan=new TimeSpan();

        schedulePart.SchChargeDT =0;

        if (machine!= null && machine.MachineDef!= null) {
           down = machine.MachineDef.DownHrsPerShift; 

            for (int i=0; i < schedulePart.ScheduleReceiptPartContainer.Count; i++){
                scheduleReceiptPart = schedulePart.ScheduleReceiptPartContainer[i];

                timeSpan = (scheduleReceiptPart.RecDate - scheduleReceiptPart.StartDate);
                dtotMins = Convert.ToDecimal(timeSpan.TotalMinutes);

                //100% =
                dpartialMins = dtotMins / (8*60);

                schedulePart.SchChargeDT+= (dpartialMins*down);
            }
        }      
    }
            
}

}
}
