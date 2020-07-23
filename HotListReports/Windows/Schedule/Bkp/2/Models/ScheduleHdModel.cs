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

namespace HotListReports.Windows.Demand{
class ScheduleHdModel : HotListModel{

private ScheduleHdr                 scheduleHdr;
private ScheduleReq                 scheduleReqActive;
private ScheduleReqViewContainer    scheduleReqViewContainer;
private ScheduleReqViewContainer    scheduleReqViewContainerFiltered;

private ScheduleReq scheduleReqFilter;
private DateTime    startDateFilter;
private DateTime    stopDateFilter;

private SchedulePart        schedulePartCloneBkp=null;
private ScheduleTask        scheduleTaskCloneBkp=null;
private ScheduleDown        scheduleDownCloneBkp=null;
private ScheduleReceiptPart scheduleReceiptPartCloneBkp=null;

public ScheduleHdModel(Window window) : base(window){    
    scheduleHdr= getCoreFactory().createScheduleHdr();
    this.scheduleReqActive = null;
    scheduleReqViewContainer = getCoreFactory().createScheduleReqViewContainer();
    scheduleReqViewContainerFiltered = getCoreFactory().createScheduleReqViewContainer();        

    scheduleReqFilter = getCoreFactory().createScheduleReq();
    loadDefaultStartStopDates()     ;   
 }   

private
void loadDefaultStartStopDates(){ 
    DateTime dstartAux= DateTime.Now.AddDays(-7);
    startDateFilter = new DateTime(dstartAux.Year, dstartAux.Month, dstartAux.Day,0,0,0);
    dstartAux=  DateTime.Now.AddMonths(3);
    stopDateFilter   = new DateTime(dstartAux.Year, dstartAux.Month, dstartAux.Day,23,59,59);
}


public
ScheduleReqViewContainer reloadFilters(){
    scheduleReqViewContainer = scheduleHdr.buildReqContainer();    
    scheduleReqViewContainerFiltered = scheduleHdr.applyFiltersReqContainer(scheduleReqViewContainer,scheduleReqFilter, StartDateFilter,StopDateFilter);

    return scheduleReqViewContainerFiltered;
}

public
void initializeFilters(ComboBox comboBox){
    try{
        ScheduleHdr scheduleHdr = getCoreFactory().createScheduleHdr();
        ScheduleHdr = scheduleHdr;
        ScheduleReqFilter = getCoreFactory().createScheduleReq();    
        loadReqFilter(comboBox);         
            
    } catch (Exception ex) {
        MessageBox.Show("initializeFilters Exception: " + ex.Message);        
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
ScheduleReq ScheduleReqActive {
	get { return scheduleReqActive; }
	set { if (this.scheduleReqActive != value){
			this.scheduleReqActive = value;			
		}
	}
}

public
ScheduleReq ScheduleReqFilter{
	get { return scheduleReqFilter; }
	set {
        ScheduleReq raux = value;
        if (raux == null)
            raux = getCoreFactory().createScheduleReq();

        if (this.scheduleReqFilter != raux){
			this.scheduleReqFilter = raux;			
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
                getCoreFactory().loadScheduleHdrAdditionalInfo(scheduleHdr);
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
        ArrayList       arrayList = scheduleHdr!= null ? scheduleHdr.ScheduleReqContainer.getDifferentsRequirment() : new ArrayList();
        ScheduleReq     scheduleReqAll = getCoreFactory().createScheduleReq();
        ScheduleReq     scheduleReqAlrSelected = null;

        if (comboBox.SelectedItem != null)
            scheduleReqAlrSelected = (ScheduleReq)((Nujit.NujitWms.WinForms.Util.ComboBoxItem)comboBox.SelectedItem).Content;
    
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All", scheduleReqAll));            
        foreach(ScheduleReq scheduleReq in arrayList){
           list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(scheduleReq.ReqDescription,scheduleReq));
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
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Down"   , "Down"));                                
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Holiday", "Holiday"));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Break"  , "Break"));
                               
        comboBox.ItemsSource = list;
        
    } catch (Exception ex) {
        MessageBox.Show("loadDownTypeNames Exception: " + ex.Message);        
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
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(Colors.Gold));
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Date Created", "DateCreated", BindingMode.OneWay, 70, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Status", "Status", BindingMode.OneWay, 50, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Plant", "Plant", BindingMode.OneWay,60, hdrListView);        
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
    
        textBlockColumnListView = new TextBlockColumnListView("Request", "ReqDescription", BindingMode.OneWay,55, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());
               
        textBlockColumnListView = new TextBlockColumnListView("ID", "TypeDescription", BindingMode.OneWay,120, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(Colors.Gold));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Type", "TypeDescription2", BindingMode.OneWay,100, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(Colors.Gold));
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
                                                                          
        textBlockColumnListView = new TextBlockColumnListView("Dt#", "SubSubdDetail", BindingMode.OneWay,15, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Part", "Part", BindingMode.OneWay,150, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(Colors.Gold));
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
                                
        textBlockColumnListView = new TextBlockColumnListView("Dt#", "SubSubdDetail", BindingMode.OneWay,15, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Part", "Part", BindingMode.OneWay,150, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(Colors.Gold));
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
                                
        textBlockColumnListView = new TextBlockColumnListView("Dt#", "SubSubdDetail", BindingMode.OneWay,15, listView);
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
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(Colors.Gold));
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

        textBlockColumnListView = new TextBlockColumnListView("Type", "MatTypeDesc", BindingMode.OneWay,60, listView);
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
                                                                          
        textBlockColumnListView = new TextBlockColumnListView("Dtl#", "SubDetail", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Task", "TaskDescription", BindingMode.OneWay,150, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(Colors.Gold));
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

        textBlockColumnListView = new TextBlockColumnListView("Material", "[0]", BindingMode.OneWay,150, listView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(Colors.Gold));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Seq", "[5]", BindingMode.OneWay,20, listView);  
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);              
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Level", "[1]", BindingMode.OneWay,30, listView);        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Description", "[2]", BindingMode.OneWay,180, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Qty.Req.", "[3]", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Inventory", "[4]", BindingMode.OneWay,60, listView);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Type", "[6]", BindingMode.OneWay,70, listView);
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
SchedulePart createPart(ScheduleReq scheduleReq){
    SchedulePart schedulePart = getCoreFactory().createSchedulePart();            
    try{                                        
        DateTime dhourLater = DateTime.Now.AddHours(1);                                         
        schedulePart.StartDate= new DateTime(dhourLater.Year, dhourLater.Month, dhourLater.Day, dhourLater.Hour, 0, 0);

        dhourLater = schedulePart.StartDate.AddHours(1);
        schedulePart.EndDate  = new DateTime(dhourLater.Year, dhourLater.Month, dhourLater.Day, dhourLater.Hour,0,0);               

        assignDates(scheduleReq, schedulePart);
    }catch (Exception ex){
        MessageBox.Show("createPart Exception: " + ex.Message);
    }         
    return schedulePart;                            
}

public
ScheduleReq createRequirment(){
    ScheduleReq scheduleReq = getCoreFactory().createScheduleReq();            
    try{                                        
        scheduleReq.Type = CapacityReq.REQUIREMENT_MACHINE;
    }catch (Exception ex){
        MessageBox.Show("createRequirment Exception: " + ex.Message);
    }         
    return scheduleReq;                            
}

public
ScheduleReq findRequirment(string stype,int ireqId){
    ScheduleReq scheduleReq = null;            
    try{                                        
        scheduleReq = scheduleHdr.ScheduleReqContainer.getByRequirment(stype,ireqId);
    }catch (Exception ex){
        MessageBox.Show("findRequirment Exception: " + ex.Message);
    }         
    return scheduleReq;                            
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
SchedulePart copyPart(ScheduleReq scheduleReq, SchedulePart schedulePart){
    SchedulePart schedulePartOriginal = null;            
    try{
        schedulePartOriginal = scheduleReq.SchedulePartContainer.getBySubDetail(schedulePart.SubDetail);
        if (schedulePartOriginal!= null)
            schedulePartOriginal.copy(schedulePart);
    }catch (Exception ex){
        MessageBox.Show("copyPart Exception: " + ex.Message);
    }         
    return schedulePartOriginal;                            
}
        
public
ScheduleTask createTask(ScheduleReq scheduleReq){
    ScheduleTask scheduleTask = getCoreFactory().createScheduleTask();            
    try{               
        DateTime dhourLater = DateTime.Now.AddHours(1);                                         
        scheduleTask.StartDate= new DateTime(dhourLater.Year, dhourLater.Month, dhourLater.Day, dhourLater.Hour, 0, 0);

        dhourLater = scheduleTask.StartDate.AddHours(1);
        scheduleTask.EndDate  = new DateTime(dhourLater.Year, dhourLater.Month, dhourLater.Day, dhourLater.Hour,0,0);               

         assignDates(scheduleReq,scheduleTask);
    }catch (Exception ex){
        MessageBox.Show("createTask Exception: " + ex.Message);
    }         
    return scheduleTask;                            
}

        
public
ScheduleTask createDownTimeTask(ScheduleReq scheduleReq){
    ScheduleTask scheduleTask = getCoreFactory().createScheduleTask();            
    try{    
        scheduleTask = createTask(scheduleReq);        
        CapShiftTask            capShiftTask= getDownTimeTask();

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
ScheduleTask copyTask(ScheduleReq scheduleReq, ScheduleTask scheduleTask){
    ScheduleTask scheduleTaskOriginal = null;            
    try{
        scheduleTaskOriginal = scheduleReq.ScheduleTaskContainer.getBySubDetail(scheduleTask.SubDetail);
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
    if (scheduleReqView!= null && scheduleReqView.ReqID <=0)
        scheduleReqView= null;
    
    return scheduleReqView;
}

public 
bool partSearch(TextBox partTextBox,ScheduleReq scheduleReq, SchedulePart schedulePart){        
    bool bresult=false;
    try{            
        ProductWindow productWindow = new ProductWindow();
        productWindow.setMachineIdFilter(scheduleReq!= null ? scheduleReq.ReqID:0);//machine filter

        if ((bool)productWindow.ShowDialog()) {        
            Product product = productWindow.getSelected();
            bresult = loadPartInfo(product,scheduleReq,schedulePart,partTextBox);
        }
       
    }catch (Exception ex){
        MessageBox.Show("partSearch Exception: " + ex.Message);
    }  
    return bresult;
}

public 
bool loadPartInfo(Product product,ScheduleReq scheduleReq,SchedulePart schedulePart,TextBox partTextBox){
   bool bresult=false;

    if (product!=null){                
            schedulePart.SchedulePartDtlContainer.Clear(); //empty just in case, already filled

            schedulePart.Part =
            partTextBox.Text = product.ProdID;//prod id
        
            schedulePart.Uom = product.StdPackUnit;//uom
            if (string.IsNullOrEmpty(schedulePart.Uom))
                schedulePart.Uom= Constants.DEFAULT_UOM;

            schedulePart.IsFamily = product.FamProd;
            schedulePart.Seq = product.SeqLast;
            if (schedulePart.IsFamily.Equals("F")) //if is family add part childs
                addFamilyChildParts(schedulePart);
            
            schedulePart.Seq=-1; //-1 trying to find sequence                
            if (!loadBuildMachineValues(scheduleReq, schedulePart))                                      
                schedulePart.Seq = product.SeqLast;

            fillIfHasMaterials(schedulePart);                    
            bresult=true;
    }
    return bresult;
}

public
bool loadBuildMachineValues(ScheduleReq scheduleReq,SchedulePart schedulePart){
    bool bresult=false;
    try{
        if (scheduleReq!= null && schedulePart != null &&
            scheduleReq.Type.Equals(CapacityReq.REQUIREMENT_MACHINE)){
            RoutingContainer routingContainer = getCoreFactory().getBuildByFilters(this.scheduleHdr.Plant,schedulePart.Part,schedulePart.Seq, scheduleReq.ReqID,true,false);
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
        ScheduleReq             scheduleReq = getScheduleReqOriginal(reqListView);                

        if (scheduleReqView!= null && scheduleReq != null){
            if (schedulePart!= null)
                scheduleReq.SchedulePartContainer.Remove(schedulePart);      
                
            scheduleReq.fillRedundances();            
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
        ScheduleReq             scheduleReq = getScheduleReqOriginal(reqListView);
        ScheduleTask            scheduleTask = (ScheduleTask)deleltedSelected(listView); 
        
        if (scheduleTask!= null && scheduleReq != null){            
            scheduleReq.ScheduleTaskContainer.Remove(scheduleTask);          
            scheduleReq.fillRedundances();
            
            loadTaskGrid(listView,scheduleReq.ScheduleTaskContainer);
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
ScheduleReqView loadSelRequirment(ListView reqlistView,ListView partDtlListView,ListView taskListView,ListView materialsListView,ListView packagingListView,ListView partReceiptsDtlListView,ListView matConsumDtlListView){ 
    ScheduleReqView         scheduleReqView = null;        
    try{
        scheduleReqView = (ScheduleReqView)getSelected(reqlistView);
        ScheduleReq                 scheduleReq = getScheduleReqOriginal(reqlistView);        
        ScheduleTaskContainer       scheduleTaskContainer = getCoreFactory().createScheduleTaskContainer();        
        
        if (scheduleReq != null)            
           scheduleTaskContainer = scheduleReq.ScheduleTaskContainer;    
        
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
                schedulePartDtl.SubSubdDetail = schedulePart.SubDetail;
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
bool delRequirment(ListView listView){    
    bool bresult=false;
    try{
        if (validRequirment(listView) != null){            
            ScheduleReqView         scheduleReqView = (ScheduleReqView)deleltedSelected(listView); 
            ScheduleReq             scheduleReq=null;
        
            if (scheduleReqView!=null && scheduleHdr!= null){                       
                scheduleReq = getScheduleReqOriginal(listView);                                  
                if (scheduleReq!= null)
                    scheduleHdr.ScheduleReqContainer.Remove(scheduleReq);                 
                
                loadRequirmentGrid(listView);   
                save();
                bresult=true;
            } 
        } 
    }catch (Exception ex){
        MessageBox.Show("delRequirment Exception: " + ex.Message);
    } 
    return  bresult;
}

public
void searchReqId(ScheduleReq scheduleReq){ 
    try{
        if (scheduleReq!=null){ 
            switch(scheduleReq.Type){
                case CapacityReq.REQUIREMENT_LABOUR:
                    scheduleReq.ReqID=1;
                    scheduleReq.ReqDescription = "Labour";
                    break;                                        
                case CapacityReq.REQUIREMENT_MACHINE:                        
                    MachineWindow machineWindow = new MachineWindow(true,this.scheduleHdr.Plant);
                    if ((bool)machineWindow.ShowDialog()){
                        Machine machine = machineWindow.getSelected();
                        if (machine != null){
                          scheduleReq.ReqID = machine.Id;
                          scheduleReq.ReqDescription = machine.Mach;
                        }
                    } 
                    break;                                        
                case CapacityReq.REQUIREMENT_TOOL:     
                    scheduleReq.ReqID=1;
                    break;                                                    
                case CapacityReq.REQUIREMENT_TASK:         
                    CapShiftTaskWindow capShiftTaskWindow = new CapShiftTaskWindow(true);
                    if ((bool)capShiftTaskWindow.ShowDialog()){
                        CapShiftTask capShiftTask = capShiftTaskWindow.getCapShiftTask();
                        if (capShiftTask!=null){
                          scheduleReq.ReqID = capShiftTask.Id;
                          scheduleReq.ReqDescription = capShiftTask.TaskName;
                        } 
                    } 
                    break;          
            } 
        }                   

    }catch (Exception ex){
        MessageBox.Show("searchReqId Exception: " + ex.Message);
    } 
}

public
ScheduleReq getScheduleReqOriginal(ListView listView){
    ScheduleReq     scheduleReq = null;
    ScheduleReqView scheduleReqView = (ScheduleReqView)getSelected(listView);        

    if (scheduleReqView!=null && scheduleHdr!=null)
        scheduleReq = scheduleHdr.ScheduleReqContainer.getByKey(scheduleReqView.HdrId, scheduleReqView.Detail);

    return scheduleReq;
}

public
SchedulePart getSchedulePart(ScheduleReqView scheduleReqView){
    SchedulePart    schedulePart=null;
    ScheduleReq     scheduleReq = null;
    
    if (scheduleReqView != null && scheduleReqView.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_PART)  && scheduleHdr!=null){
        scheduleReq = scheduleHdr.ScheduleReqContainer.getByKey(scheduleReqView.HdrId, scheduleReqView.Detail);
        if (scheduleReq != null)
            schedulePart = scheduleReq.SchedulePartContainer.getBySubDetail(scheduleReqView.SubDetail);
    }
    return schedulePart;
}

public
ScheduleTask getScheduleTask(ScheduleReqView scheduleReqView){
    ScheduleTask    scheduleTask = null;
    ScheduleReq     scheduleReq = null;
    
    if (scheduleReqView != null && scheduleReqView.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_TASK)  && scheduleHdr!=null){
        scheduleReq = scheduleHdr.ScheduleReqContainer.getByKey(scheduleReqView.HdrId, scheduleReqView.Detail);
        if (scheduleReq != null)
            scheduleTask = scheduleReq.ScheduleTaskContainer.getBySubDetail(scheduleReqView.SubDetail);
    }
    return scheduleTask;
}

public
ScheduleDown getScheduleDown(ScheduleReqView scheduleReqView){
    ScheduleDown    scheduleDown = null;
    ScheduleReq     scheduleReq = null;
    
    if (scheduleReqView != null && scheduleReqView.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_DOWN)  && scheduleHdr!=null){
        scheduleReq = scheduleHdr.ScheduleReqContainer.getByKey(scheduleReqView.HdrId, scheduleReqView.Detail);
        if (scheduleReq != null)
            scheduleDown = scheduleReq.ScheduleDownContainer.getBySubDetail(scheduleReqView.SubDetail);
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
ScheduleReqView createScheduleReqView(  ScheduleReq scheduleReq,
                                        SchedulePart schedulePart,ScheduleTask scheduleTask,ScheduleDown scheduleDown){ 
    ScheduleReqView             scheduleReqView = getCoreFactory().createScheduleReqView();

    //build ReqView on the fly
    if (scheduleReq != null)        
        scheduleReqView.copy(scheduleReq);

    if (schedulePart!= null)        
        scheduleReqView.copy(schedulePart);

    if (scheduleTask != null)        
        scheduleReqView.copy(scheduleTask);

    if (scheduleDown != null)        
        scheduleReqView.copy(scheduleDown);
  
    return scheduleReqView;
 }

public
ScheduleReqView getAlreadySameDates(bool badding,ScheduleReq scheduleReq,SchedulePart schedulePart){    
    ScheduleReqView             scheduleReqView = getCoreFactory().createScheduleReqView();
    ScheduleReqView             scheduleReqViewFound = null;

    if (schedulePart!= null && scheduleReq != null){

        //build ReqView on the fly
        scheduleReqView.copy(scheduleReq);
        scheduleReqView.copy(schedulePart);

        scheduleReqViewFound = scheduleReqViewContainer.getAlreadyPartFromDateRange(badding,scheduleReqView);
    }        
    return scheduleReqViewFound;
}

public
ScheduleReqView getAlreadySameDates(bool badding,ScheduleReq scheduleReq,ScheduleTask scheduleTask){    
    ScheduleReqView             scheduleReqView = getCoreFactory().createScheduleReqView();
    ScheduleReqView             scheduleReqViewFound = null;

    if (scheduleTask != null && scheduleReq != null){

        //build ReqView on the fly
        scheduleReqView.copy(scheduleReq);
        scheduleReqView.copy(scheduleTask);

        scheduleReqViewFound = scheduleReqViewContainer.getAlreadyPartFromDateRange(badding,scheduleReqView);
    }        
    return scheduleReqViewFound;
}

public
ScheduleReqView getAlreadySameDates(bool badding,ScheduleReq scheduleReq,ScheduleDown scheduleDown){    
    ScheduleReqView             scheduleReqView = getCoreFactory().createScheduleReqView();
    ScheduleReqView             scheduleReqViewFound = null;

    if (scheduleDown != null && scheduleReq != null){

        //build ReqView on the fly
        scheduleReqView.copy(scheduleReq);
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
void assignDates(ScheduleReq scheduleReq,ScheduleTask scheduleTask){
    DateTime startDateTime = DateTime.Now;
    DateTime endDateTime = DateTime.Now;
    DateTime dateTime = DateTime.Now;

    if (scheduleReq!= null){
        if (scheduleReq.getMaxDates(out startDateTime,out endDateTime)){        
            scheduleTask.StartDate = endDateTime;
            dateTime = scheduleTask.StartDate.AddHours(1);
            scheduleTask.EndDate = dateTime;
        }
    }
}

public
void assignDates(ScheduleReq scheduleReq,ScheduleDown scheduleDown){
    DateTime startDateTime = DateTime.Now;
    DateTime endDateTime = DateTime.Now;
    DateTime dateTime = DateTime.Now;

    if (scheduleReq!= null){
        if (scheduleReq.getMaxDates(out startDateTime,out endDateTime)){        
            scheduleDown.StartDate = endDateTime;
            dateTime = scheduleDown.StartDate.AddHours(1);
            scheduleDown.EndDate = dateTime;
        }
    }
}

public
void assignDates(ScheduleReq scheduleReq,SchedulePart schedulePart){
    DateTime startDateTime = DateTime.Now;
    DateTime endDateTime = DateTime.Now;
    DateTime dateTime = DateTime.Now;

    if (scheduleReq!= null){
        if (scheduleReq.getMaxDates(out startDateTime,out endDateTime)){        
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
        string[][] materials = new string[0][];

        if (schedulePart!= null)
            materials = getCoreFactory().getAllMaterialsForProduct(schedulePart.Part, schedulePart.Seq,scheduleHdr.Plant);
    
        if (materials==null)
            materials = new string[0][];

        listView.DataContext = materials;
        listView.ItemsSource = materials; 
                
        if (listView.Items.Count > 0)
            listView.SelectedIndex = 0;

    } catch (Exception ex) {
        MessageBox.Show("loadMaterialGrid Exception: " + ex.Message);        
    }
}

public
void fillIfHasMaterials(SchedulePart schedulePart){
    try { 
        string[][] materials = new string[0][];
        if (schedulePart!= null){
            materials = getCoreFactory().getAllMaterialsForProduct(schedulePart.Part, schedulePart.Seq,scheduleHdr.Plant);            
            schedulePart.MaterialFlag = materials.Length > 0 ? Constants.STRING_YES : Constants.STRING_NO;
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
        if (bautomatic && schedulePart!= null && getCoreFactory()!= null){
            string[][] materials = new string[0][];
            getCoreFactory().generateAutomaticReceiptPart(schedulePart);
            materials = getCoreFactory().getAllMaterialsForProduct(schedulePart.Part, schedulePart.Seq,scheduleHdr.Plant);
            getCoreFactory().generateAutomaticMaterialConsumition(schedulePart,materials);

            loadMaterialConsumitionGrid(matConsumListView, schedulePart);
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
            if (scheduleReqView != null && scheduleReqView.Type.Equals(stype) && scheduleReqView.ReqID == ireqId) {                   
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
                                    ScheduleReq scheduleReq){
    bool           bforceApplyFilters=false;    
    DateTime       startDateMax = DateTime.Now;
    DateTime       endDateMax = DateTime.Now;                
    ScheduleReq    scheduleReqFilter =(ScheduleReq)getSelectedComboBoxItem(reqFilterComboBox);

    try{   
        if (scheduleReqFilter == null){
            bforceApplyFilters=true;
            reqFilterComboBox.SelectedIndex = 0; //select all
            scheduleReqFilter =(ScheduleReq)getSelectedComboBoxItem(reqFilterComboBox);
        }  

        if (reqFilterComboBox.SelectedIndex != 0){
            if (scheduleReqFilter!= null && scheduleReq!= null && (!scheduleReqFilter.Type.Equals(scheduleReq.Type) || !scheduleReqFilter.ReqID.Equals(scheduleReq.ReqID))) { 
                bforceApplyFilters= true;
                reqFilterComboBox.SelectedIndex = 0; //select all
            }
        }   

        if (scheduleReq!= null){
            //just in case, requirment not showed on screen        
            if (!scheduleReq.getMaxDates(out startDateMax, out endDateMax))
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
        ScheduleReq scheduleReqFilter =(ScheduleReq)getSelectedComboBoxItem(reqFilterComboBox);

        ScheduleReqFilter= scheduleReqFilter;
        loadRequirmentGrid(reqListView);
    }catch (Exception ex){
        MessageBox.Show("applyFilters Exception: " + ex.Message);
    }                                        
}  

public 
bool scheduleHotList(   ListView reqListView,ComboBox reqFilterComboBox,TextBox partTextBox, 
                        RadDateTimePicker startFilterRadDateTimePicker, RadDateTimePicker stopFilterRadDateTimePicker,
                        bool bonlyMachAlternative,string splant,string spart,int iseq,decimal dqty,DateTime scheduleDateTime,
                        out  SchedulePart schedulePart){
    bool        bresult=false;
    schedulePart = getCoreFactory().createSchedulePart();
    try {        
        int                 ireqId = 0;
        ScheduleReq         scheduleReq= null;
        Routing             routing = null;
                                          
        RoutingContainer    routingContainer = getCoreFactory().getBuildByFilters(splant, spart, iseq, 0, true, bonlyMachAlternative);//find machine        
        if  (routingContainer.Count > 0) {                                                        
            routing = routingContainer[0];
            ireqId = routing.MachIdShow;
            if (ireqId > 0){

                scheduleReq = findRequirment(CapacityReq.REQUIREMENT_MACHINE,ireqId);
                if (scheduleReq==null){ //requirment does not exist, so add it
                    scheduleReq = createRequirment();
                    scheduleReq.Type  = CapacityReq.REQUIREMENT_MACHINE;
                    scheduleReq.ReqID = ireqId;
                    scheduleReq.ReqDescription = routing.Cfg;//.mbuildItem[7];
                    scheduleHdr.ScheduleReqContainer.Add(scheduleReq);
                    scheduleHdr.fillRedundances();
                    loadRequirmentGrid(reqListView); //show new requirment on grid                                                                                                                        
                }

                if (adjustFiltersToShowRequirment(reqFilterComboBox,startFilterRadDateTimePicker,stopFilterRadDateTimePicker,scheduleReq))
                    applyFilters(reqListView,reqFilterComboBox);

                ScheduleReqActive = scheduleReq;

                if (setSelectedAnyReqId(reqListView, scheduleReq.Type, scheduleReq.ReqID)){                                                
                    Product product = getCoreFactory().readProduct(spart);
                    if (product!= null){                                    
                        schedulePart = createPart(scheduleReq);

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
                        loadPartInfo(product,scheduleReq,schedulePart,partTextBox);
                        schedulePart.RunStd = routing.RunStd;
                        schedulePart.CavityNum = routing.CavityNum;
                        schedulePart.Qty = dqty;
                        schedulePart.EndDate = schedulePart.calculateEndDataMachineBuild();                                    
                        bresult=true;
                    }                        
                     
                }else
                    MessageBox.Show("Sorry, Can Not Select Request = " + ireqId.ToString() +  ".");                                                                 
            }else
                MessageBox.Show("Sorry, Can Not Find Machine/Req To Build Part = " + spart +  ".");
        }else
                MessageBox.Show("Sorry, Can Not Find Machine To Build Part = " + spart +  ".");
        
    } catch (Exception ex) {
        MessageBox.Show("scheduleHotList Exception: " + ex.Message);
    }
    return bresult;
} 

/************************************************* ***************************************************************************/
public
ScheduleDown createDown(ScheduleReq scheduleReq){
    ScheduleDown scheduleDown = getCoreFactory().createScheduleDown();            
    try{               
        DateTime dhourLater = DateTime.Now.AddHours(1);                                         
        scheduleDown.StartDate= new DateTime(dhourLater.Year, dhourLater.Month, dhourLater.Day, dhourLater.Hour, 0, 0);

        dhourLater = scheduleDown.StartDate.AddHours(1);
        scheduleDown.EndDate  = new DateTime(dhourLater.Year, dhourLater.Month, dhourLater.Day, dhourLater.Hour,0,0);               

         assignDates(scheduleReq, scheduleDown);
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
ScheduleDown copyDown(ScheduleReq scheduleReq, ScheduleDown scheduleDown){
    ScheduleDown scheduleDownOriginal = null;            
    try{
        scheduleDownOriginal = scheduleReq.ScheduleDownContainer.getBySubDetail(scheduleDown.SubDetail);
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
        ScheduleReq             scheduleReq = getScheduleReqOriginal(reqListView);                

        if (scheduleReqView!= null && scheduleReq != null){
            if (scheduleDown != null)
                scheduleReq.ScheduleDownContainer.Remove(scheduleDown);      
                
            scheduleReq.fillRedundances();            
            loadRequirmentGrid(reqListView);
            save();
        }        
        
    }catch (Exception ex){
        MessageBox.Show("deleteScheduleDown Exception: " + ex.Message);
    }    
}

}
}
