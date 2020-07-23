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
using Nujit.NujitERP.ClassLib.Core.Machines;
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
using Nujit.NujitERP.ClassLib.Core.Planned;
using Nujit.NujitERP.ClassLib.Core.ScheduleDemand;
using Nujit.NujitWms.WinForms.Util.Controllers;


namespace HotListReports.Windows.Demand{


class  CapShiftProfileModel : BaseModel2{

public const string PLANNED = "Planned";
public const string NOT_PLANNED = "NotPlanned";

private Hashtable   hashMachines;
private Hashtable   hashMachinesById;
private Hashtable   hashRoutings;
private Hashtable   hashTasks;
private PlannedHdr  plannedHdr;
private ScheduleHdr scheduleHdr;

private ListView    addShiftsListView;
private ListView    addShiftsRListView;
private ListView    addShiftsTotalRListView;
private ListView    addMachPlanListView;
private ListView    addMachPlanEmployeeListView;
private ListView    machPlanEmployeeListView;
private ListView    sheduleHdrListView;
private ListView    sheduleDtlListView;
private ListView    scheduleDtlEmployeeListView;
private ListView    scheduleDtlMachineListView;
private Label       machPlanEmployeeTopLabel;

private EmpShiftScheduleHdr empShiftScheduleHdr;
private EmpShiftScheduleDtl empShiftScheduleDtl;
private Employee            employeeCreatedBy;
private double              dmaxDropDownHeight;

private CapacityHdr         capacityHdr;
private EmployeeContainer   employeeContainer;

private CapShiftProfileContainer sumCapShiftProfileContainer;

public CapShiftProfileModel(Window window,ListView addShiftsListView,ListView addShiftsRListView,ListView addShiftsTotalRListView,ListView addMachPlanListView,ListView addMachPlanEmployeeListView,ListView machPlanEmployeeListView,ListView sheduleHdrListView,ListView sheduleDtlListView, ListView scheduleDtlEmployeeListView, ListView scheduleDtlMachineListView, Label machPlanEmployeeTopLabel) : base(window){    
    hashMachines= new Hashtable();
    hashMachinesById = new Hashtable();
    hashRoutings= new Hashtable();
    hashTasks   = new Hashtable();
    plannedHdr  = null;
    scheduleHdr = null;

    this.addShiftsListView          = addShiftsListView;
    this.addShiftsRListView         = addShiftsRListView;
    this.addShiftsTotalRListView    = addShiftsTotalRListView;
    this.addMachPlanListView        = addMachPlanListView;
    this.addMachPlanEmployeeListView= addMachPlanEmployeeListView;
    this.machPlanEmployeeListView   = machPlanEmployeeListView;

    this.sheduleHdrListView         = sheduleHdrListView;
    this.sheduleDtlListView         = sheduleDtlListView;
    this.scheduleDtlEmployeeListView= scheduleDtlEmployeeListView;
    this.scheduleDtlMachineListView = scheduleDtlMachineListView;
    this.machPlanEmployeeTopLabel   = machPlanEmployeeTopLabel;

    sumCapShiftProfileContainer = getCoreFactory().createCapShiftProfileContainer();

    this.empShiftScheduleHdr = null;
    this.empShiftScheduleDtl = null;
    this.employeeCreatedBy   = null;

    this.dmaxDropDownHeight = 400;
    this.capacityHdr        = null;
    this.employeeContainer  = getCoreFactory().createEmployeeContainer();   
}

public
EmpShiftScheduleHdr EmpShiftScheduleHdr {
	get { return empShiftScheduleHdr; }
	set { if (this.empShiftScheduleHdr != value){
			this.empShiftScheduleHdr = value;			
		}
	}
}

public
Employee EmployeeCreatedBy {
	get { return employeeCreatedBy; }
	set { if (this.employeeCreatedBy != value){
			this.employeeCreatedBy = value;			
		}
	}
}

public
EmployeeContainer EmployeeContainer {
	get { return employeeContainer; }
	set { 
        this.employeeContainer = value;
	}
}
                
public
void loadSearchByCombo(ComboBox searchByComboBox){
    loadCombo(searchByComboBox,"Id");      
}

public
void loadStatusComboBox(ComboBox comboBox,bool ball){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        

        if (ball)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("All",""));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Active", "A"));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Overtime", "O"));     
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Inactive", "I"));     
                               
        comboBox.ItemsSource = list;
        if (comboBox.Items.Count > 0)
            comboBox.SelectedIndex = 0;        

    } catch (Exception ex) {
        MessageBox.Show("loadStatusComboBox Exception: " + ex.Message);        
    }
}

public
void loadShiftTypesComboBox(ComboBox comboBox){
    try {         
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();

        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(Constants.SHIFT_TYPE_OVERTIME, Constants.SHIFT_TYPE_OVERTIME));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(Constants.SHIFT_TYPE_REGULAR, Constants.SHIFT_TYPE_REGULAR));      
                       
        comboBox.ItemsSource = list;
        if (comboBox.Items.Count > 0)
            comboBox.SelectedIndex = 0;        

    } catch (Exception ex) {
        MessageBox.Show("loadYesNoComboBox Exception: " + ex.Message);        
    }
}

public
bool loadDatesCombos(ComboBox startcombo,ComboBox endCombo){
    bool            bresult=false;
    try{                
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list1 = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list2 = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        int             icurrYear = DateTime.Now.Year;
        DateTime        startDate= new DateTime(icurrYear,1,1);
        DateTime        endDate= new DateTime(icurrYear,12,31);

        DateTime        priorMonday = startDate;
        DateTime        nextSunday = startDate;
        int             icountRecords=0;
        string          sdate1 = "";
        string          sdate2 = "";

        for (int i=0; i <= 365; icountRecords++){                    
            DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday,out nextSunday);
                    
            sdate1 = DateUtil.getDateRepresentation(priorMonday,DateUtil.MMDDYYYY);
            sdate2 = DateUtil.getDateRepresentation(nextSunday, DateUtil.MMDDYYYY);

            list1.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(sdate1, sdate1));
            list2.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(sdate2, sdate2));
          
            i = i + 7;
            priorMonday = priorMonday.AddDays(7);                    
        }

        startcombo.ItemsSource = list1;
        endCombo.ItemsSource = list2;
        bresult=true;        

    } catch (Exception ex) {
        MessageBox.Show("loadDatesCombos Exception: " + ex.Message);        
    }
    return bresult;                   
}


public
bool loadDatesCombos(ComboBox startcombo,ComboBox endCombo,DateTime sinceDate){
    bool            bresult=false;
    try{                    
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list1 = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list2 = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
        int             icurrYear = DateTime.Now.Year;
        DateTime        startDate= sinceDate.AddYears(-1);
        DateTime        endDate= sinceDate.AddYears(1);

        DateTime        priorMonday = startDate;
        DateTime        nextSunday = startDate;
        int             icountRecords=0;
        string          sdate1 = "";
        string          sdate2 = "";

        for (int i=0; priorMonday < endDate; icountRecords++){                    
            DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);
                    
            sdate1 = DateUtil.getDateRepresentation(priorMonday,DateUtil.MMDDYYYY);
            sdate2 = DateUtil.getDateRepresentation(nextSunday, DateUtil.MMDDYYYY);

            list1.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(sdate1, sdate1));
            list2.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(sdate2, sdate2));
          
            i = i + 7;
            priorMonday = priorMonday.AddDays(7);                    
        }

        startcombo.ItemsSource = list1;
        endCombo.ItemsSource = list2;
        bresult=true;        

    } catch (Exception ex) {
        MessageBox.Show("loadDatesCombos Exception: " + ex.Message);        
    }
    return bresult;                   
}

public
void loadColumnsOnPlannedVsShiftProfileListView(ListView listView,bool bpaintTitle){
     try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;                
        string                  sbinding = "";
        string                  sweekTitle = "";                    
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));     
                
        textBlockColumnListView = new TextBlockColumnListView("Description", "Name", BindingMode.OneWay,120, listView);
        if (bpaintTitle) { 
            textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
            textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        }
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());   

        ArrayList   arrayWeeks      = CapacityView.getArrayWeeeksBy2Titles(false);
        ArrayList   arrayTitleNames = CapacityView.getArrayWeeeksByTitle(false);
                
        for (int i=0; i < CapacityView.TITLE_COUNTS && i < arrayWeeks.Count;i++){                                         
            sbinding    = (string)arrayTitleNames[i];
            sweekTitle  = (string)arrayWeeks[i];        
            sweekTitle  = sweekTitle.Replace("Week0",CapacityView.TITLE_WEEK0);
                    
            textBlockColumnListView = new TextBlockColumnListView(sweekTitle, sbinding, BindingMode.OneWay,50, listView);            
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;            
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            textBlockColumnListView.setBinding(sbinding, BindingMode.OneWay, TextBlock.TextProperty);         
            textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"0.0");
            textBlockColumnListView.process();

            gridView.Columns.Add(textBlockColumnListView.process());                           
        }
                
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnMachineListView Exception: " + ex.Message);        
    }    
}

public
void loadColumnsOnHeaderGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                
        textBlockColumnListView = new TextBlockColumnListView("Id", "Id", BindingMode.OneWay, 70, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());   

        textBlockColumnListView = new TextBlockColumnListView("Plant", "Plant", BindingMode.OneWay,85, listView);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Shift", "ShiftNum", BindingMode.OneWay,40, listView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());  

        textBlockColumnListView = new TextBlockColumnListView("Status", "Status", BindingMode.OneWay,50, listView);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Start Date", "StartDate", BindingMode.OneWay, 70, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("End Date", "EndDate", BindingMode.OneWay, 70, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ShiftStart", "ShiftStart", BindingMode.OneWay,60, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ShiftEnd", "ShiftEnd", BindingMode.OneWay,60, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());
                        
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnDetailGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
  
        textBlockColumnListView = new TextBlockColumnListView("Dtl#", "Detail", BindingMode.OneWay,50, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());   

        textBlockColumnListView = new TextBlockColumnListView("TaskId", "ShiftTaskId", BindingMode.OneWay, 70, listView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());  

        textBlockColumnListView = new TextBlockColumnListView("Task Name", "TaskNameShow", BindingMode.OneWay,100, listView);        
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());     
                
        textBlockColumnListView = new TextBlockColumnListView("Dir/Ind", "DirIndShow", BindingMode.OneWay,50, listView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());                         

        textBlockColumnListView = new TextBlockColumnListView("Num People", "NumPeople", BindingMode.OneWay,60, listView);                
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());  

        textBlockColumnListView = new TextBlockColumnListView("New People", "NewPeople", BindingMode.OneWay,60, listView);                
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());  
        
        textBlockColumnListView = new TextBlockColumnListView("Hours", "Hours", BindingMode.OneWay,60, listView);                
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 
                        
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnDetailGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnAddLeftDetailGrid(ListView listView,string splant,DateTime date){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        TextColumnListView      textColumnListView = null;
        CheckColumnListView     checkColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                
        textBlockColumnListView = new TextBlockColumnListView("Shf", "ShiftNum", BindingMode.OneWay,20, listView); 
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        gridView.Columns.Add(textBlockColumnListView.process());   

        textColumnListView = new TextColumnListView("ShfId", "ShiftNumId", BindingMode.TwoWay,40, listView); 
        textColumnListView.setEvent(TextBox.LostFocusEvent, new RoutedEventHandler(shiftNumIdLostFocusEvent)); 
        textColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);        

        textColumnListView.setProperty(TextBox.MinHeightProperty, (double)10);
        textColumnListView.setProperty(TextBox.HeightProperty, (double)17);
        textColumnListView.setProperty(TextBox.FontSizeProperty, (double)14);
        textColumnListView.setProperty(TextBox.PaddingProperty, new Thickness(0));
        gridView.Columns.Add(textColumnListView.process());   

        textBlockColumnListView = new TextBlockColumnListView("Typ","ShiftType", BindingMode.OneWay,15, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());    

        RadTimePickerColumnListView radTimePickerColumnListView = new RadTimePickerColumnListView("ShiftStart", "ShiftStart", BindingMode.TwoWay,63, listView);
        radTimePickerColumnListView.setProperty(Telerik.Windows.Controls.RadTimePicker.InputModeProperty,Telerik.Windows.Controls.InputMode.TimePicker);
        radTimePickerColumnListView.setProperty(Telerik.Windows.Controls.RadTimePicker.HeightProperty, (double)17); 
        radTimePickerColumnListView.setEvent(Telerik.Windows.Controls.RadTimePicker.LostFocusEvent, new RoutedEventHandler(timeLostFocusEvent)); 
        gridView.Columns.Add(radTimePickerColumnListView.process()); 

        radTimePickerColumnListView = new RadTimePickerColumnListView("ShiftEnd", "ShiftEnd", BindingMode.TwoWay,63, listView);
        radTimePickerColumnListView.setProperty(Telerik.Windows.Controls.RadTimePicker.InputModeProperty,Telerik.Windows.Controls.InputMode.TimePicker);
        radTimePickerColumnListView.setProperty(Telerik.Windows.Controls.RadTimePicker.HeightProperty, (double)17); 
        radTimePickerColumnListView.setEvent(Telerik.Windows.Controls.RadTimePicker.LostFocusEvent, new RoutedEventHandler(timeLostFocusEvent)); 
        gridView.Columns.Add(radTimePickerColumnListView.process()); 
                /*
        textBlockColumnListView = new TextBlockColumnListView("ShiftStart", "ShiftStart", BindingMode.OneWay,45, listView);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ShiftEnd", "ShiftEnd", BindingMode.OneWay,45, listView);
        gridView.Columns.Add(textBlockColumnListView.process());*/

        checkColumnListView = new CheckColumnListView("Dft","ShiftDefault", BindingMode.TwoWay,20,listView);
        checkColumnListView.setProperty(CheckBox.FontWeightProperty, FontWeights.Black);
        checkColumnListView.setConverter(new ConstantYesNoToBoolConverterNew(), "");
        checkColumnListView.setEvent(CheckBox.ClickEvent, new RoutedEventHandler(flagClickEvent));
        checkColumnListView.getColumn().HeaderContainerStyle = cell;                    
        gridView.Columns.Add(checkColumnListView.process());

        DateTime    priorMonday = DateTime.Now;
        DateTime    nextSunday = DateTime.Now;
        DateUtil.getPriorMondayNextSundayFromDate(date,out priorMonday,out nextSunday);
        do {
            string sdayShort= priorMonday.DayOfWeek.ToString().Substring(0, 3);
            string sbind    = sdayShort + "Work";
    
            CapProfileHolidayContainer capProfileHolidayContainer  = DateUtil.isWeekendDate(priorMonday)?   getCoreFactory().createCapProfileHolidayContainer() : 
                                                                                                            getCoreFactory().readIfHoliday(splant,priorMonday,1);

            checkColumnListView = new CheckColumnListView(sdayShort + "\n" + DateUtil.getDateRepresentation(priorMonday, DateUtil.MMDDYYYY).Substring(0,5),sbind, BindingMode.TwoWay,28, listView);
            checkColumnListView.setProperty(CheckBox.FontWeightProperty, FontWeights.Black);
            checkColumnListView.setConverter(new ConstantYesNoToBoolConverterNew(), "");
            checkColumnListView.setEvent(CheckBox.ClickEvent, new RoutedEventHandler(flagClickEvent));
            checkColumnListView.getColumn().HeaderContainerStyle = cell;                    
            gridView.Columns.Add(checkColumnListView.process());
            
            if (capProfileHolidayContainer.Count > 0)
                checkColumnListView.setProperty(CheckBox.BackgroundProperty, new SolidColorBrush(Colors.Red));
            priorMonday  = priorMonday.AddDays(1);

        } while (priorMonday.DayOfWeek != DayOfWeek.Monday);

        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnDetailGrid Exception: " + ex.Message);        
    }
}

private 
void shiftNumIdLostFocusEvent(object sender, RoutedEventArgs e){            
    shiftNumIdLostFocusEvent((TextBox)sender);
}

private 
void shiftNumIdLostFocusEvent(TextBox textBox){            
    try{        
        if (textBox != null) {             
            CapShiftProfile capShiftProfile = (CapShiftProfile)textBox.DataContext;    
    
            if (capShiftProfile!= null)                 
                save(capShiftProfile);                 
        }

    } catch (Exception ex) {
        MessageBox.Show("shiftNumIdLostFocusEvent Exception: " + ex.Message);        
    }
}

private 
void timeLostFocusEvent(object sender, RoutedEventArgs e){
    timeLostFocusEvent((Telerik.Windows.Controls.RadTimePicker)sender);
}

private 
void timeLostFocusEvent(Telerik.Windows.Controls.RadTimePicker radTimePicker){   
    try{        
        if (radTimePicker != null) {             
            CapShiftProfile capShiftProfile = (CapShiftProfile)radTimePicker.DataContext;    
    
            if (capShiftProfile!= null){                 
                save(capShiftProfile);    
            } 
        }

    } catch (Exception ex) {
        MessageBox.Show("timeLostFocusEvent Exception: " + ex.Message);        
    }
}
   

private 
void flagClickEvent(object sender, RoutedEventArgs e){   
    flagClickEvent(sender);
}

private 
void flagClickEvent(object sender){   
    try{        
        if (sender!= null) { 
            CheckBox        checkBox = (CheckBox)sender;
            CapShiftProfile capShiftProfile = (CapShiftProfile)checkBox.DataContext;    
    
            if (capShiftProfile!= null && getCoreFactory()!= null) { 
                checkIfAnyHoliday(capShiftProfile,false);
                save(capShiftProfile);    
            } 
        }

    } catch (Exception ex) {
        MessageBox.Show("flagClickEvent Exception: " + ex.Message);        
    }
}
                        
public
void loadColumnsOnAddDetailGrid(ListView listView,bool btotals=false){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));

        if (!btotals) { 
            textBlockColumnListView = new TextBlockColumnListView("Shift", "ShiftNumShow", BindingMode.OneWay,40, listView);
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
            textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
            textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            gridView.Columns.Add(textBlockColumnListView.process());   
  
            textBlockColumnListView = new TextBlockColumnListView("Dtl#", "Detail", BindingMode.OneWay,30, listView);        
            textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
            textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
            textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
            gridView.Columns.Add(textBlockColumnListView.process());   
        }

        textBlockColumnListView = new TextBlockColumnListView("TaskId", "ShiftTaskId", BindingMode.OneWay,btotals? 140:40, listView);                
        if (btotals)
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());  

        textBlockColumnListView = new TextBlockColumnListView("Task Name", "TaskNameShow", BindingMode.OneWay,200, listView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());     
                        
        textBlockColumnListView = new TextBlockColumnListView("Dir/Ind", "DirIndShow", BindingMode.OneWay,40, listView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());                         
        
        textBlockColumnListView = new TextBlockColumnListView("NumPeople", "NumPeople", BindingMode.OneWay,60, listView);                
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());  

        textBlockColumnListView = new TextBlockColumnListView("NewPeople", "NewPeople", BindingMode.OneWay,60, listView);                
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 
        
        textBlockColumnListView = new TextBlockColumnListView("Hours", "Hours", BindingMode.OneWay,60, listView);                
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 

                            
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnDetailGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnMachinePlanGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
  
        textBlockColumnListView = new TextBlockColumnListView("Shf", "ShiftNumShow", BindingMode.OneWay,20, listView); 
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());   

        textBlockColumnListView = new TextBlockColumnListView("Typ","ShiftType", BindingMode.OneWay,15, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());    

        textBlockColumnListView = new TextBlockColumnListView("MachId", "MachId", BindingMode.OneWay,60, listView);                
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);        
        gridView.Columns.Add(textBlockColumnListView.process());   

        textBlockColumnListView = new TextBlockColumnListView("Machine", "MachShow", BindingMode.OneWay,90, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        gridView.Columns.Add(textBlockColumnListView.process());   
        
        textBlockColumnListView = new TextBlockColumnListView("Machine Name", "MachNameShow", BindingMode.OneWay,180, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());     

        textBlockColumnListView = new TextBlockColumnListView("Date", "Date", BindingMode.OneWay,70, listView);                
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());
                       
        textBlockColumnListView = new TextBlockColumnListView("FullShf", "FullShift", BindingMode.OneWay,30, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());                         

                                
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnMachinePlanGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnMachinePlanEmployeeGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
  
        textBlockColumnListView = new TextBlockColumnListView("SubDtl#", "SubDetail", BindingMode.OneWay,30, listView);         
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());   

        textBlockColumnListView = new TextBlockColumnListView("Employee", "EmpId", BindingMode.OneWay,80, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());    

        textBlockColumnListView = new TextBlockColumnListView("Employee Name", "EmpNameShow", BindingMode.OneWay,200, listView);                        
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        gridView.Columns.Add(textBlockColumnListView.process());   
                                        
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnMachinePlanEmployeeGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnEmployeeGrid(ListView hdrListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("Employ.Id", "Id", BindingMode.OneWay,70, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("First Name", "FirstName", BindingMode.OneWay,70, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Last Name", "LastName", BindingMode.OneWay,70, hdrListView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Shf","AssignShift", BindingMode.OneWay,20, hdrListView);                                
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("OTShf", "AssignOTShift", BindingMode.OneWay,20, hdrListView);                        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Dft.Dept", "DftDept", BindingMode.OneWay,80, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Dft.Labour", "DftLabourTypeNameShow", BindingMode.OneWay,100,hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());    
      
        textBlockColumnListView = new TextBlockColumnListView("Approv.Date", "ApprovDateShow", BindingMode.OneWay,80, hdrListView);
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "DateMinValue");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Approv.Until", "ApprovUntilDateShow", BindingMode.OneWay,80, hdrListView);
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "DateMinValue");
        gridView.Columns.Add(textBlockColumnListView.process());            

        textBlockColumnListView = new TextBlockColumnListView("Last LabDate", "LastLabourDate", BindingMode.OneWay,80, hdrListView);
        textBlockColumnListView.setConverter(new DateTimeToStringConverterNew(), "DateMinValue");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Sts", "Status", BindingMode.OneWay,20, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());       

        textBlockColumnListView = new TextBlockColumnListView("HomePhone", "HomePhone", BindingMode.OneWay,90, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("CellPhone", "CellPhone", BindingMode.OneWay,90, hdrListView);                
        gridView.Columns.Add(textBlockColumnListView.process());

      
        hdrListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnEmployeeGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnEmplShiftScheduleGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));

        Style                   cellLeftAlign = new Style(typeof(GridViewColumnHeader));
        cellLeftAlign.Setters.Add(new Setter(Control.HorizontalContentAlignmentProperty, System.Windows.HorizontalAlignment.Left));
  
        textBlockColumnListView = new TextBlockColumnListView("ID", "Id", BindingMode.OneWay,40, listView);         
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());   

        textBlockColumnListView = new TextBlockColumnListView("Plant", "Plant", BindingMode.OneWay,60, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());    

        textBlockColumnListView = new TextBlockColumnListView("Dept", "Dept", BindingMode.OneWay,60, listView);        
        gridView.Columns.Add(textBlockColumnListView.process()); 

        textBlockColumnListView = new TextBlockColumnListView("Shf", "ShiftNum", BindingMode.OneWay,15, listView);                        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;   
        gridView.Columns.Add(textBlockColumnListView.process()); 

        textBlockColumnListView = new TextBlockColumnListView("Date", "Date", BindingMode.OneWay,68, listView);                        
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(),"Date");
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;   
        gridView.Columns.Add(textBlockColumnListView.process()); 
                
        textBlockColumnListView = new TextBlockColumnListView("Created By", "CreatedByEmpNameShow", BindingMode.OneWay,90, listView);        
        gridView.Columns.Add(textBlockColumnListView.process());                 

        textBlockColumnListView = new TextBlockColumnListView("Schedule Shift Notes", "Notes", BindingMode.OneWay,1000, listView);
        textBlockColumnListView.setProperty(TextBlock.MaxHeightProperty,(double)20); //added because notes will resize height cells 
        textBlockColumnListView.getColumn().HeaderContainerStyle = cellLeftAlign;  
        gridView.Columns.Add(textBlockColumnListView.process());                 
                                                          
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnEmplShiftScheduleGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnEmplShiftScheduleDtlGrid(ListView listView,EmpShiftScheduleHdr empShiftScheduleHdr){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;      
        CheckColumnListView     checkColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                
        textBlockColumnListView = new TextBlockColumnListView("Dt#", "Detail", BindingMode.OneWay,15, listView);         
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        //employee                
        /*
        EmployeeComboColumnListView employeeComboColumnListView = new EmployeeComboColumnListView("Employee", "EmpId", BindingMode.TwoWay,80, listView);
        employeeComboColumnListView.loadValues(getCoreFactory(), ComboDisplayFormat.Code, "", "", "",Constants.STATUS_ACTIVE,empShiftScheduleHdr != null ? empShiftScheduleHdr.ShiftNum : 0,"",0);        
        employeeComboColumnListView.setEvent(ComboBox.SelectionChangedEvent, new SelectionChangedEventHandler(employeeSelectionChangedEvent));                
        employeeComboColumnListView.setProperty(ComboBox.FontWeightProperty, FontWeights.Black);
        employeeComboColumnListView.getColumn().HeaderContainerStyle = cell;
        employeeComboColumnListView.setProperty(ComboBox.MaxDropDownHeightProperty,dmaxDropDownHeight);
        gridView.Columns.Add(employeeComboColumnListView.process());  
        */
        textBlockColumnListView = new TextBlockColumnListView("Employee","EmpId", BindingMode.OneWay,0, listView);                 
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());


        textBlockColumnListView = new TextBlockColumnListView("First Name", "EmpFirstNameShow", BindingMode.OneWay,85, listView);                 
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Last Name", "EmpLastNameShow", BindingMode.OneWay,85, listView);                 
        gridView.Columns.Add(textBlockColumnListView.process());

        //machine
        textBlockColumnListView = new TextBlockColumnListView("Machine", "MachineShow", BindingMode.OneWay,0, listView);                 
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Mach Desc.", "MachineDescShow", BindingMode.OneWay,100, listView);                 
        gridView.Columns.Add(textBlockColumnListView.process());

                /*
        MachineComboColumnListView machineComboColumnListView = new MachineComboColumnListView("Machine", "MachId", BindingMode.TwoWay,180,listView);
        machineComboColumnListView.loadValues(getCoreFactory(), "", "", empShiftScheduleHdr != null ? empShiftScheduleHdr.Plant : "", empShiftScheduleHdr != null ? empShiftScheduleHdr.Dept : "", true, 0);
        machineComboColumnListView.setProperty(ComboBox.FontWeightProperty, FontWeights.Black);
        machineComboColumnListView.getColumn().HeaderContainerStyle = cell;
        machineComboColumnListView.setProperty(ComboBox.MaxDropDownHeightProperty,dmaxDropDownHeight);
        gridView.Columns.Add(machineComboColumnListView.process());*/

        //labour
        /*
        ShiftTaskComboColumnListView shiftTaskComboColumnListView = new ShiftTaskComboColumnListView("Labour/Task", "LabourTypeId", BindingMode.TwoWay,120,listView);
        shiftTaskComboColumnListView.loadValues(getCoreFactory());
        shiftTaskComboColumnListView.setProperty(ComboBox.FontWeightProperty, FontWeights.Black);
        shiftTaskComboColumnListView.getColumn().HeaderContainerStyle = cell;   
        shiftTaskComboColumnListView.setProperty(ComboBox.MaxDropDownHeightProperty,dmaxDropDownHeight);
        gridView.Columns.Add(shiftTaskComboColumnListView.process());  
        */
        textBlockColumnListView = new TextBlockColumnListView("Labour","LabourTypeShow", BindingMode.OneWay,120, listView);                 
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());
          
        textBlockColumnListView = new TextBlockColumnListView("Multi", "LabMultiplier", BindingMode.OneWay,30, listView);         
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"");
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;  
        gridView.Columns.Add(textBlockColumnListView.process());

        checkColumnListView = new CheckColumnListView("Absent", "Absent", BindingMode.OneWay,35, listView); 
        checkColumnListView.setConverter(new ConstantYesNoToBoolConverterNew(), "");                       
        checkColumnListView.setEvent(CheckBox.ClickEvent, new RoutedEventHandler(absentClickEvent));
        checkColumnListView.setProperty(CheckBox.FontWeightProperty, FontWeights.Black);
        checkColumnListView.getColumn().HeaderContainerStyle = cell;        
        gridView.Columns.Add(checkColumnListView.process());      
                                                                          
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnEmplShiftScheduleDtlGrid Exception: " + ex.Message);        
    }
}

private 
void absentClickEvent(object sender, RoutedEventArgs e){   
    absentClickEvent(sender);
}

private 
void absentClickEvent(object sender){   
    try{        
        if (sender!= null) { 
            CheckBox                checkBox = (CheckBox)sender;
            EmpShiftScheduleDtl     empShiftScheduleDtl = (EmpShiftScheduleDtl)checkBox.DataContext;
            empShiftScheduleHdr = getSelectedEmpH();

            if (empShiftScheduleHdr!= null && empShiftScheduleDtl != null) {                                 
                empShiftScheduleDtl.Absent = (bool)checkBox.IsChecked ? Constants.STRING_YES : Constants.STRING_NO;
                saveEH(this.empShiftScheduleHdr);
            } 
        }

    } catch (Exception ex) {
        MessageBox.Show("flagClickEvent Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnEmplShiftScheduleDtlEmployeeGrid(ListView hdrListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        CheckColumnListView     checkColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("Employ.Id", "Id", BindingMode.OneWay,70, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("First Name", "FirstName", BindingMode.OneWay,120, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Last Name", "LastName", BindingMode.OneWay,120, hdrListView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Shf","AssignShift", BindingMode.OneWay,20, hdrListView);                                
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("OTShf", "AssignOTShift", BindingMode.OneWay,20, hdrListView);                        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Dft.Labour", "DftLabourTypeNameShow", BindingMode.OneWay,100,hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("DftDept", "DftDept", BindingMode.OneWay,70,hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("DftMach", "MachShow", BindingMode.OneWay,70,hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());
                
        checkColumnListView = new CheckColumnListView("Select", "SelectedShow", BindingMode.OneWay,30, hdrListView);
        checkColumnListView.setProperty(CheckBox.IsEnabledProperty,false);
        checkColumnListView.setProperty(CheckBox.FontWeightProperty, FontWeights.Black);
        checkColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(checkColumnListView.process());                

        checkColumnListView = new CheckColumnListView("Absent", "FlagShow", BindingMode.OneWay,30, hdrListView); 
        checkColumnListView.setConverter(new ConstantYesNoToBoolConverterNew(), "");           
        checkColumnListView.setProperty(CheckBox.FontWeightProperty, FontWeights.Black);
        checkColumnListView.setProperty(CheckBox.IsEnabledProperty,false);
        checkColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(checkColumnListView.process());      

        hdrListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnEmplShiftScheduleDtlEmployeeGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnEmplShiftScheduleDtlMachineGrid(ListView hdrListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        TextColumnListView      textColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));

        Style                   cell2 = new Style(typeof(GridViewColumnHeader));
        cell2.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));  
        cell2.Setters.Add(new Setter(Control.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT)));
                /*
        textBlockColumnListView = new TextBlockColumnListView("Id", "Id", BindingMode.OneWay, 50, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());*/
        
        textBlockColumnListView = new TextBlockColumnListView("Dept", "Dept", BindingMode.OneWay,0,hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Machine", "Mach", BindingMode.OneWay,90, hdrListView);        
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Description 1", "Des1", BindingMode.OneWay,180, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Priority", "PriorityShow", BindingMode.OneWay,30, hdrListView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"int");
        gridView.Columns.Add(textBlockColumnListView.process());
                
        textBlockColumnListView = new TextBlockColumnListView("Planned","Scheduled", BindingMode.OneWay,68, hdrListView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        gridView.Columns.Add(textBlockColumnListView.process());

        hdrListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnEmplShiftScheduleDtlMachineGrid Exception: " + ex.Message);        
    }
}

private 
void employeeSelectionChangedEvent(object sender, SelectionChangedEventArgs e){    
    employeeSelectionChangedEvent((ComboBox)sender);
}

public
bool loadEmployeeNames(EmpShiftScheduleDtl empShiftScheduleDtl){
    bool bresult=false;
    try { 
        Employee employee = EmployeeContainer.getByKey(empShiftScheduleDtl.EmpId);
        if (employee!= null){
            empShiftScheduleDtl.EmpFirstNameShow    = employee.FirstName;
            empShiftScheduleDtl.EmpLastNameShow     = employee.LastName;
        }

    } catch (Exception ex) {
        MessageBox.Show("loadEmployeeNames Exception: " + ex.Message);        
    }
    return bresult;
}

private 
void employeeSelectionChangedEvent(ComboBox employeeCombo){        
    try{
        empShiftScheduleDtl = employeeCombo != null ? (EmpShiftScheduleDtl)employeeCombo.DataContext : null;    
    
        if (empShiftScheduleDtl != null) { //if labour/task not alredy selected try to load default from employee
            Employee employee = getCoreFactory().readEmployee(empShiftScheduleDtl.EmpId);
            if (employee!= null) {
                empShiftScheduleDtl.EmpFirstNameShow= employee.FirstName;
                empShiftScheduleDtl.EmpLastNameShow = employee.LastName;
    
                if (empShiftScheduleDtl.LabourTypeId <= 0)
                    empShiftScheduleDtl.LabourTypeId = employee.DftLabourTypeId;
            }
        }

    }catch (Exception ex){
        MessageBox.Show("employeeSelectionChangedEvent Exception: " + ex.Message);
    }  
}

public 
void search(TextBox recordsTextBox,ComboBox searchByComboBox,TextBox searchForTextBox,ComboBox plantComboBox, ComboBox statusFilterComboBox,ComboBox shiftNumFilterComboBox,ListView hdrListView){    
    try{
        int         irows       = getRecords(recordsTextBox);                    
        string      sid         = searchByComboBox.SelectedIndex == 0 ? searchForTextBox.Text : "";
        string      splant      = getSelectedComboBoxItemString(plantComboBox);
        string      status      = getSelectedComboBoxItemString(statusFilterComboBox);
        string      shiftNum    = getSelectedComboBoxItemString(shiftNumFilterComboBox);
        int         ishiftNum   =0;
        DateTime    startDate   = DateUtil.MinValue;
        DateTime    endDate     = DateUtil.MinValue;

        if (!string.IsNullOrEmpty(sid))        
            sid = sid + "%";  
        if (!string.IsNullOrEmpty(shiftNum))        
            ishiftNum = Convert.ToInt32(shiftNum);        

        CapShiftProfileContainer capShiftProfileContainer = coreFactory.readCapShiftProfileByFilters(sid,splant,ishiftNum, status,startDate, endDate,0,"",true, irows);             
        setDataContextListView(hdrListView, capShiftProfileContainer);        
        searchForTextBox.Focus();
            
    }catch (Exception ex){
        MessageBox.Show("search Exception: " + ex.Message);
    }                       
} 

public
bool createCapRecordsFullCurrYear(ListView listView){
    bool            bresult=false;
    try{        
        CapShiftProfile capShiftProfileBase = (CapShiftProfile)getSelected(listView); 
        CapShiftProfile capShiftProfile = coreFactory.createCapShiftProfile();
        int             icurrYear = DateTime.Now.Year;
        DateTime        startDate= new DateTime(icurrYear,1,1);
        DateTime        endDate= new DateTime(icurrYear,12,31);

        DateTime        priorMonday = startDate;
        DateTime        nextSunday = startDate;
        int             icapShiftProfileId=0;
        int             icountRecords=0;


        if (capShiftProfileBase!= null){
            icapShiftProfileId = capShiftProfileBase.Id;
            capShiftProfileBase = coreFactory.readCapShiftProfile(capShiftProfileBase.Id);

            if (capShiftProfileBase!= null){
                if (System.Windows.Forms.MessageBox.Show("Do You Want To Create Capacity Shift Profile Records For Full Year " + icurrYear + " ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes){

                    capShiftProfile = coreFactory.cloneCapShiftProfile(capShiftProfileBase);                
                    capShiftProfile.Status = Constants.STATUS_ACTIVE;
                    
                    for (int i=0; i <= 365; icountRecords++){                    
                        DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday,out nextSunday);
                    
                                /*
                        MessageBox.Show("Index = " + i.ToString() + 
                                        "Shift = " + capShiftProfile.ShiftNum + "\n"+
                                        "StartDate: " + DateUtil.getDateRepresentation(priorMonday,DateUtil.DDMMYYYY) + "\nEnd Date:" + DateUtil.getDateRepresentation(nextSunday,DateUtil.DDMMYYYY));
                        */

                        capShiftProfile.Id =0;
                        capShiftProfile.StartDate = priorMonday;
                        capShiftProfile.EndDate = nextSunday;

                        coreFactory.writeCapShiftProfile(capShiftProfile);
                        i = i + 7;
                        priorMonday = priorMonday.AddDays(7);                    
                    }
                    bresult=true;
                    MessageBox.Show("Capacity Shift Profile Records Created, Shift: " + capShiftProfile.ShiftNum + ", Total :" + icountRecords+ ".");
                }
            }else
                MessageBox.Show("Sorry, Can Not Find Capacity Shift Profile : " + icapShiftProfileId + ".");
        }else
            MessageBox.Show("Please, Select Capacity Profile As Base Model.");        

    }catch (Exception ex){
        MessageBox.Show("createCapRecordsFullCurrYear Exception: " + ex.Message);
    }     
    return bresult;
}

public 
void add(out CapShiftProfile capShiftProfile,string splant){    
    string          splantAux = string.IsNullOrEmpty(splant) ? Configuration.DftPlant : splant;
    capShiftProfile = coreFactory.createCapShiftProfile();                
    try{        
        DateTime priorMonday = DateTime.Now;
        DateTime nextSunday = DateTime.Now;
        DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday,out nextSunday);

        capShiftProfile.ShiftNum = 1;
        capShiftProfile.Status = Nujit.NujitERP.ClassLib.Common.Constants.STATUS_ACTIVE;
        capShiftProfile.StartDate = priorMonday;
        capShiftProfile.EndDate = nextSunday;
        capShiftProfile.Plant = splantAux;
                                                   
    }catch (Exception ex){
        MessageBox.Show("add Exception: " + ex.Message);
    }                       
}

public 
bool del(ListView hdrListView){    
    bool bresult=false;
    try{     
        ArrayList arrayList = deleltedSelecteds(hdrListView);

        foreach(CapShiftProfile capShiftProfile in arrayList){               
            coreFactory.deleteCapShiftProfile(capShiftProfile.Id);            
            bresult=true;
        }            
    }catch (Exception ex){
        MessageBox.Show("del Exception: " + ex.Message);
    }          
    return bresult;                         
}          
           
public
void save(CapShiftProfile capShiftProfile){
    try{
        if (getCoreFactory()!= null) { 
            if (capShiftProfile.Id > 0)
                getCoreFactory().updateCapShiftProfile(capShiftProfile);
            else
                getCoreFactory().writeCapShiftProfile(capShiftProfile);
        }

    } catch (Exception ex) {
        MessageBox.Show("save Exception: " + ex.Message);        
    }
}

/********************************************     Reports   ****************************************************************/
public
void loadPlannedVsShifProfile(ListView toplistView,ListView bottomListView,string splant){
    try{
        ArrayList       arrayDateTimeList           = CapacityView.getDateTimeWeekList(false);
        DateTime        startDate                   = (DateTime)arrayDateTimeList[0];
        Hashtable       hashtableByShift            = loadShifProfileHash(splant,Constants.STATUS_ACTIVE,startDate);
        Hashtable       hashtableByShiftOverttime   = loadShifProfileHash(splant,Constants.STATUS_OVERTIME,startDate);
        HotListHdr      hotListHdr                  = getCoreFactory().readLastHotList(splant);
        plannedHdr   = getCoreFactory().readPlannedHdrLastDateCheck(plannedHdr,splant);  
        scheduleHdr  = getCoreFactory().readScheduleHdrLastDateCheck(scheduleHdr,splant);  

        loadHdrPlannedVsShifProfile(toplistView     ,splant,arrayDateTimeList,hashtableByShift,hotListHdr,plannedHdr);
        loadDtlPlannedVsShifProfile(bottomListView  ,splant,arrayDateTimeList,hashtableByShift, hashtableByShiftOverttime,hotListHdr, plannedHdr);

    } catch (Exception ex) {
        MessageBox.Show("loadPlannedVsShifProfile Exception: " + ex.Message);        
    }
}

public
Hashtable loadShifProfileHash(string splant,string status,DateTime startDate){
    CapShiftProfileContainer    capShiftProfileContainer= null;        
    Hashtable                   hashtableByShift = new Hashtable();

    //get last active capacityprofile record for each shift, with Active status
    for (int i=1; i <= Constants.MAX_SHIFTS; i++){
        capShiftProfileContainer = coreFactory.readCapShiftProfileByExactlyDatesFilters(splant,i, status, startDate, false, CapacityView.TITLE_COUNTS);
        hashtableByShift.Add(i,capShiftProfileContainer);
    } 
    return hashtableByShift;
}

public
void loadHdrPlannedVsShifProfile(ListView listView,string splant, ArrayList arrayDateTimeList,Hashtable hashtableByShift,HotListHdr hotListHdr,PlannedHdr plannedHdr){
    try{
        ReportWeeksViewContainer    reportWeeksViewContainer = getCoreFactory().createReportWeeksViewContainer();
        ReportWeeksView             reportWeeksView = null;        
        ReportWeeksView             reportWeeksViewPlanned = null;
        ReportWeeksView             reportWeeksViewOvertime = null;
        ReportWeeksView             reportWeeksViewShProfile= null;

        reportWeeksView = loadRequiredEmployees(arrayDateTimeList,hotListHdr);
        reportWeeksViewContainer.Add(reportWeeksView);

        reportWeeksViewPlanned = loadPlannedEmployees(plannedHdr,arrayDateTimeList);
        reportWeeksViewContainer.Add(reportWeeksViewPlanned);

        reportWeeksViewOvertime = loadPlannedOverEmployees(plannedHdr,arrayDateTimeList);                    
        reportWeeksViewContainer.Add(reportWeeksViewOvertime);

        reportWeeksViewShProfile = loadShifProfileEmployees(hashtableByShift,arrayDateTimeList);
        reportWeeksViewContainer.Add(reportWeeksViewShProfile);

        reportWeeksView= loadPlannedNetEmployees(reportWeeksViewPlanned,reportWeeksViewOvertime,reportWeeksViewShProfile);
        reportWeeksViewContainer.Add(reportWeeksView);
                      
        setDataContextListView(listView,reportWeeksViewContainer);

    } catch (Exception ex) {
        MessageBox.Show("loadPlannedVsShifProfile Exception: " + ex.Message);        
    }
}

private
ReportWeeksView loadPlannedEmployees(PlannedHdr plannedHdr,ArrayList arrayDateTimeList){       
    decimal                     dtotEmployee=0;
    DateTime                    currDate    = DateTime.Now;
    DateTime                    startDate   = DateTime.Now;
    DateTime                    endDate     = DateTime.Now;
    ReportWeeksView             reportWeeksView = getCoreFactory().createReportWeeksView();

    reportWeeksView.Name = "Labour Planned";
    
    if (plannedHdr!=null){                
        for (int i=0; i < arrayDateTimeList.Count; i++) { 
            currDate    = (DateTime)arrayDateTimeList[i];
            DateUtil.getPriorMondayNextSundayFromDate(currDate, out startDate, out endDate); 
                    
            dtotEmployee = plannedHdr.getPlannedLabourTotEmployee(startDate,endDate);
            reportWeeksView.setCellWeek(i,dtotEmployee);
        }
    }
    
    return reportWeeksView;
}

private
ReportWeeksView loadPlannedOverEmployees(PlannedHdr plannedHdr,ArrayList arrayDateTimeList){
    decimal                     dtotEmployee=0;
    DateTime                    currDate    = DateTime.Now;
    DateTime                    startDate   = DateTime.Now;
    DateTime                    endDate     = DateTime.Now;
    ReportWeeksView             reportWeeksView = getCoreFactory().createReportWeeksView();

    reportWeeksView.Name = "Labour OverTime";
    
    if (plannedHdr!=null){                
        for (int i=0; i < arrayDateTimeList.Count; i++) { 
            currDate    = (DateTime)arrayDateTimeList[i];
            DateUtil.getPriorMondayNextSundayFromDate(currDate, out startDate, out endDate); 
                    
            dtotEmployee = plannedHdr.getPlannedOverTimeTotEmployee(startDate,endDate);
            reportWeeksView.setCellWeek(i,dtotEmployee);
        }
    }
    
    return reportWeeksView;
}

private
ReportWeeksView loadPlannedNetEmployees(ReportWeeksView reportWeeksViewPlanned,ReportWeeksView reportWeeksViewOvertime,ReportWeeksView reportWeeksViewShProfile){
    ReportWeeksView     reportWeeksView = getCoreFactory().createReportWeeksView();
    decimal             dplanned    =0;
    decimal             dovertime   =0;
    decimal             dshProfile  =0;
    decimal             dnet        =0;

    reportWeeksView.Name = "Net Labour";

    //Net = Planned - (Shift + OT Shift) 
    for (int i=0; i < CapacityView.TITLE_COUNTS; i++) {
        dplanned    = reportWeeksViewPlanned != null ? reportWeeksViewPlanned.getCellWeek(i) : 0;
        dovertime   = reportWeeksViewOvertime!= null ? reportWeeksViewOvertime.getCellWeek(i) : 0;                
        dshProfile  = reportWeeksViewShProfile!= null? reportWeeksViewShProfile.getCellWeek(i): 0;

        dnet = dplanned - (dshProfile+dovertime);
        reportWeeksView.setCellWeek(i,dnet);
    }
        
    return reportWeeksView;
}

private
ReportWeeksView loadRequiredEmployees(ArrayList arrayDateTimeList, HotListHdr hotListHdr){    
    DateTime                    currDate    = DateTime.Now;
    DateTime                    startDate   = DateTime.Now;
    DateTime                    endDate     = DateTime.Now;   
    DateTime                    dateAux     = DateTime.Now;   
    ReportWeeksView             reportWeeksView = getCoreFactory().createReportWeeksView();        
    bool                        bfoundWeek=false;
    
    reportWeeksView.Name = "Labour Required";
    
    if (hotListHdr != null){                
        LabourTypeRequiredContainer labourTypeRequiredContainer = getCoreFactory().getHotListLabourType2(hashMachines,hashRoutings,hashTasks,scheduleHdr,hotListHdr != null ? hotListHdr.Id:0, hotListHdr!= null ? hotListHdr.Plant:"","","","",0,"",-1,"","","",true,false,false,false,0);

        //every labour type will be summarized
        for (int i=0; i < labourTypeRequiredContainer.Count; i++) { 
            LabourTypeRequired labourTypeRequired = labourTypeRequiredContainer[i];
             
            HotListDayContainer hotListDayContainer = labourTypeRequired.getQtyDatesNonZero(hotListHdr.HotlistRunDate);                                
            foreach( HotListDay hotListDay in hotListDayContainer) {
                currDate = hotListDay.DateTime;               
                bfoundWeek=false;
                        
                for (int j=0; j < arrayDateTimeList.Count && !bfoundWeek; j++) {                     
                    dateAux = (DateTime)arrayDateTimeList[j];
                    DateUtil.getPriorMondayNextSundayFromDate(dateAux, out startDate, out endDate);                             
                    if (currDate >= startDate && currDate <= endDate) { 
                        reportWeeksView.setCellWeek(j,reportWeeksView.getCellWeek(j)+ hotListDay.Qty);
                        bfoundWeek=true;
                    }else if (currDate < dateAux)
                        bfoundWeek=true;
                }
            }            
        }
    }
    
    return reportWeeksView;
}

private
ReportWeeksView loadShifProfileEmployees(Hashtable hashtableByShift,ArrayList arrayDateTimeList){
    CapShiftProfileContainer    capShiftProfileContainer= null;
    CapShiftProfile             capShiftProfile = null;
    int                         i=0;
    
    DateTime                    currDate    =(DateTime)arrayDateTimeList[0];
    DateTime                    startDate   = DateTime.Now;
    DateTime                    endDate     = DateTime.Now;    
    decimal                     dtotEmployee =0;
    ReportWeeksView             reportWeeksView = getCoreFactory().createReportWeeksView();

    reportWeeksView.Name = "Shift Profile";
              
    for (i=1; i <= Constants.MAX_SHIFTS; i++){ //loop on every shift
        capShiftProfileContainer = (CapShiftProfileContainer)hashtableByShift[i]; //always exists
                
        for (int j=0; j < CapacityView.TITLE_COUNTS && j < arrayDateTimeList.Count; j++){
            currDate    =(DateTime)arrayDateTimeList[j];

            DateUtil.getPriorMondayNextSundayFromDate(currDate, out startDate,out endDate);                                        
            capShiftProfile = capShiftProfileContainer.getByShiftExactlyDates(i,startDate,endDate);             
                
            if (capShiftProfile!= null){                         
                dtotEmployee = capShiftProfile.TotDirectPeople + capShiftProfile.TotIndirectPeople;                          
                reportWeeksView.setCellWeek(j,reportWeeksView.getCellWeek(j)+dtotEmployee);
            }
        }      
    }      
    return reportWeeksView;
}

public
void loadDtlPlannedVsShifProfile(ListView listView,string splant,ArrayList arrayDateTimeList,
                                Hashtable hashtableByShift, Hashtable hashtableByShiftOverttime,
                                HotListHdr hotListHdr, PlannedHdr plannedHdr){
    try{
        ReportWeeksViewContainer    reportWeeksViewContainer = getCoreFactory().createReportWeeksViewContainer();                     
        ReportWeeksView             sumRegularReportWeeksView = null;
        ReportWeeksView             sumOvertimeReportWeeksView = null;
        string                      sbindGroupTitle = "Title";

        sumRegularReportWeeksView = loadDtlShifProfileEmployees(reportWeeksViewContainer,splant,arrayDateTimeList,hashtableByShift,"Regular Shifts","Time");
        sumOvertimeReportWeeksView= loadDtlShifProfileEmployees(reportWeeksViewContainer,splant,arrayDateTimeList,hashtableByShiftOverttime,"Additional Time","OT");                
        loadDtlShifProfileTotal(reportWeeksViewContainer, sumRegularReportWeeksView, sumOvertimeReportWeeksView);

        setDataContextListView(listView,reportWeeksViewContainer);       
        CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
        PropertyGroupDescription groupDescription = new PropertyGroupDescription(sbindGroupTitle);
        view.GroupDescriptions.Add(groupDescription);   

    } catch (Exception ex) {
        MessageBox.Show("loadDtlPlannedVsShifProfile Exception: " + ex.Message);        
    }
}

private
ReportWeeksView loadDtlShifProfileEmployees(ReportWeeksViewContainer reportWeeksViewContainer,string splant, ArrayList arrayDateTimeList, Hashtable hashtableByShift,string stitle,string subtitle){
    CapShiftProfileContainer    capShiftProfileContainer= null;
    CapShiftProfile             capShiftProfile = null;
    int                         i=0;    
    DateTime                    currDate    =(DateTime)arrayDateTimeList[0];
    DateTime                    startDate   = DateTime.Now;
    DateTime                    endDate     = DateTime.Now;    
    decimal                     dtotEmployee =0;
    ReportWeeksView             reportWeeksView = null;
    ReportWeeksView             sumReportWeeksView = null;
               
    sumReportWeeksView = getCoreFactory().createReportWeeksView();
    sumReportWeeksView.Title = stitle;
    sumReportWeeksView.Name = "Total";
    sumReportWeeksView.Target = "1";
             
    for (i=1; i <= Constants.MAX_SHIFTS; i++){ //loop on every shift
        capShiftProfileContainer = (CapShiftProfileContainer)hashtableByShift[i]; //always exists

        reportWeeksView = getCoreFactory().createReportWeeksView();
        reportWeeksView.Title = stitle;
        reportWeeksView.Name = "Shift " + i.ToString() + " " + subtitle;
        reportWeeksView.Target = "1";
        reportWeeksViewContainer.Add(reportWeeksView);
                
        for (int j=0; j < CapacityView.TITLE_COUNTS && j < arrayDateTimeList.Count; j++){
            currDate    =(DateTime)arrayDateTimeList[j];

            DateUtil.getPriorMondayNextSundayFromDate(currDate, out startDate,out endDate);                                        
            capShiftProfile = capShiftProfileContainer.getByShiftExactlyDates(i,startDate,endDate);             
                
            if (capShiftProfile!= null){                         
                dtotEmployee = capShiftProfile.TotDirectPeople + capShiftProfile.TotIndirectPeople;                          

                reportWeeksView.setCellWeek(j,reportWeeksView.getCellWeek(j)+dtotEmployee);
                sumReportWeeksView.setCellWeek(j,sumReportWeeksView.getCellWeek(j)+dtotEmployee);//summary
            }
        }      
    }        

    reportWeeksViewContainer.Add(sumReportWeeksView);     
    return sumReportWeeksView;
}

private
ReportWeeksView loadDtlShifProfileOvertimeEmployees(ReportWeeksViewContainer reportWeeksViewContainer,ArrayList arrayDateTimeList){
    
    ReportWeeksView             reportWeeksView = null;
    ReportWeeksView             sumReportWeeksView = null;
    string                      stitle = "Additional Time";

    sumReportWeeksView = getCoreFactory().createReportWeeksView();
    sumReportWeeksView.Title = stitle;
    sumReportWeeksView.Name = "Total";
    sumReportWeeksView.Target = "2";

    for (int i=1; i <= Constants.MAX_SHIFTS; i++){ //loop on every shift
        reportWeeksView = getCoreFactory().createReportWeeksView();
        reportWeeksView.Title = stitle;
        reportWeeksView.Name = "Shift " + i.ToString() + " OT";
        reportWeeksView.Target = "2";

                /*
        for (int j=0; j < CapacityView.TITLE_COUNTS && j < arrayDateTimeList.Count; j++) { 
            reportWeeksView.setCellWeek(j,j);
            sumReportWeeksView.setCellWeek(j,sumReportWeeksView.getCellWeek(j)+ j);//summary
        }*/
        reportWeeksViewContainer.Add(reportWeeksView);
    }        
        
    reportWeeksViewContainer.Add(sumReportWeeksView);
    return sumReportWeeksView;   
}
        
private
ReportWeeksView loadDtlShifProfileTotal(ReportWeeksViewContainer reportWeeksViewContainer, ReportWeeksView sumRegularReportWeeksView, ReportWeeksView sumOvertimeReportWeeksView){
    ReportWeeksView     reportWeeksView = getCoreFactory().createReportWeeksView();
    decimal             dregular    =0;
    decimal             dovertime   =0;
    decimal             dnet        =0;

    reportWeeksView.Title= "Total Time";
    reportWeeksView.Name = "";
    reportWeeksViewContainer.Add(reportWeeksView);

    //Net = Planned - (Shift + OT Shift) 
    for (int i=0; i < CapacityView.TITLE_COUNTS; i++) {
        dregular    = sumRegularReportWeeksView != null ? sumRegularReportWeeksView.getCellWeek(i) : 0;
        dovertime   = sumOvertimeReportWeeksView!= null ? sumOvertimeReportWeeksView.getCellWeek(i) : 0;                
        
        dnet = dregular + dovertime;
        reportWeeksView.setCellWeek(i,dnet);
    }
        
    return reportWeeksView;
}

/********************************************** ShiftProfile ********************************************************************/
public
void loadDayLabourShift(string splant,string status,int ishift,GroupBox groupBox,ListView listView,ComboBox dateCombo){    
    string      sdate    = getSelectedComboBoxItemString(dateCombo);
    DateTime    startDate= !string.IsNullOrEmpty(sdate) ? DateUtil.parseDate(sdate,DateUtil.MMDDYYYY) : DateTime.Now;
    DateTime    endDate  = startDate;
    DateUtil.getPriorMondayNextSundayFromDate(startDate,out startDate,out endDate);

    loadColumnsOnAddLeftDetailGrid(addShiftsListView,splant,startDate); //load columns and check holidays to be painted on red

    CapShiftProfileContainer capShiftProfileContainer = getCoreFactory().readCapShiftProfileByExactlyDatesFilters(splant,ishift, status, startDate, false,1);  
    CapShiftProfile          capShiftProfile = null;
                     
    if (capShiftProfileContainer.Count > 0){            
        capShiftProfile = capShiftProfileContainer[0];            
    }

    loadDayLabourShift(capShiftProfile,splant, status,ishift, startDate,endDate,groupBox,listView, dateCombo);            
}

public
void loadDayLabourShift(CapShiftProfile capShiftProfile, string splant,string status,int ishift,DateTime startDate,DateTime endDate,GroupBox groupBox,ListView listView,ComboBox dateCombo){    
    if (capShiftProfile == null){ 
        capShiftProfile = getCoreFactory().createCapShiftProfile();            
        capShiftProfile.ShiftNum = ishift;
        capShiftProfile.Plant = splant;
        capShiftProfile.Status = status;
        capShiftProfile.StartDate = startDate;
        capShiftProfile.EndDate = endDate;
    }        
    groupBox.DataContext = capShiftProfile;
    setDataContextListView(listView,capShiftProfile.CapShiftProfileDtlContainer);        
}

private
void loadSumCapShiftProfile(string splant,string status,DateTime startDate){
    CapShiftProfile capShiftProfile= null;
    sumCapShiftProfileContainer = getCoreFactory().createCapShiftProfileContainer();

    for (int i=1; i < 5; i++) { 

        CapShiftProfileContainer capShiftProfileContainer = getCoreFactory().readCapShiftProfileByExactlyDatesFilters(splant,i,status,startDate,false,0);  
                             
        if (capShiftProfileContainer.Count > 0){            
            capShiftProfile = capShiftProfileContainer[0];
            capShiftProfile.fillRedundances();
            sumCapShiftProfileContainer.Add(capShiftProfile);                                                            
        }        
    }    
}

private
void loadSumCapShiftProfileDefaults(string splant,string status,string shiftDefault,DateTime startDate){
    CapShiftProfile capShiftProfile= null;
    sumCapShiftProfileContainer = getCoreFactory().createCapShiftProfileContainer();

    for (int i=1; i <= Constants.MAX_SHIFTS; i++) { 

        CapShiftProfileContainer capShiftProfileContainer = getCoreFactory().readCapShiftProfileByFilters("",splant,i,status,DateUtil.MinValue,DateUtil.MinValue,-1,shiftDefault, false,1);  
                             
        if (capShiftProfileContainer.Count > 0){            
            capShiftProfile = capShiftProfileContainer[0];
            capShiftProfile.fillRedundances();
            sumCapShiftProfileContainer.Add(capShiftProfile);                                                            
        }        
    }
}

private
void writeSumCapShiftProfileDefaults(DateTime startDate,DateTime endDate){
    CapShiftProfile capShiftProfile= null;
    for (int i=0; i < sumCapShiftProfileContainer.Count; i++) { 
        capShiftProfile = sumCapShiftProfileContainer[i];

        capShiftProfile.Id =0;                              //insert new one
        capShiftProfile.StartDate = startDate;
        capShiftProfile.EndDate = endDate;
        capShiftProfile.ShiftDefault = Constants.STRING_NO; //set no default
        checkIfAnyHoliday(capShiftProfile);                 //check holidays
        save(capShiftProfile);          
    } 
}

public
void loadAddLabourShift(string splant,string status,int ishift,ListView listView,ListView rightListView,ComboBox dateCombo, ComboBox dateEndCombo){        
    DateTime                    startDate= DateTime.Now;
    DateTime                    endDate  = DateTime.Now;
    CapShiftProfileDtlContainer capShiftProfileDtlContainer = getCoreFactory().createCapShiftProfileDtlContainer();
                    
    getDatesSelected(dateCombo,out startDate,out endDate);
    setSelectedComboBoxItem(dateEndCombo, DateUtil.getDateRepresentation(endDate, DateUtil.MMDDYYYY));
    loadColumnsOnAddLeftDetailGrid(addShiftsListView,splant,startDate);
    
    sumCapShiftProfileContainer = getCoreFactory().createCapShiftProfileContainer();    
    loadSumCapShiftProfile(splant,"",startDate); //trying to get shift profiles for exact dates

    if (sumCapShiftProfileContainer.Count < 1) { 
        loadSumCapShiftProfileDefaults(splant,"",Constants.STRING_YES,DateUtil.MinValue);//load defaults shift profile
        if (sumCapShiftProfileContainer.Count > 0)
            writeSumCapShiftProfileDefaults(startDate,endDate);         //write new profiles based on defaults found
    }

    sumCapShiftProfileContainer.sortByShiftNum();
    setDataContextListView(listView, sumCapShiftProfileContainer);    
    showDtlNew(rightListView);    
}

private
void loadTotalsPerTasks(CapShiftProfileDtlContainer capShiftProfileDtlContainer){
    CapShiftProfileDtlContainer capShiftProfileDtlTotalContainer = getCoreFactory().createCapShiftProfileDtlContainer();
    CapShiftProfileDtl          capShiftProfileDtlTotal = null;

    foreach (CapShiftProfileDtl capShiftProfileDtl in capShiftProfileDtlContainer){

        capShiftProfileDtlTotal = capShiftProfileDtlTotalContainer.getByShiftTaskId(capShiftProfileDtl.ShiftTaskId);
        if (capShiftProfileDtlTotal == null){
            capShiftProfileDtlTotal = getCoreFactory().cloneCapShiftProfileDtl(capShiftProfileDtl);
            capShiftProfileDtlTotalContainer.Add(capShiftProfileDtlTotal);
        }else{
            capShiftProfileDtlTotal.NumPeople+= capShiftProfileDtl.NumPeople;
            capShiftProfileDtlTotal.NewPeople+= capShiftProfileDtl.NewPeople;
            capShiftProfileDtlTotal.Hours+= capShiftProfileDtl.Hours;
        }
    }
    capShiftProfileDtlTotalContainer.sortByTaskName();
    setDataContextListView(addShiftsTotalRListView,capShiftProfileDtlTotalContainer);
}

public
void showDtlNew(ListView listView){ 
    CapShiftProfile             capShiftProfile = null;
    CapShiftProfileDtlContainer capShiftProfileDtlContainer = getCoreFactory().createCapShiftProfileDtlContainer();
    
    for (int i=0; i < sumCapShiftProfileContainer.Count; i++) { 
        capShiftProfile = sumCapShiftProfileContainer[i];        
        for (int j=0; j < capShiftProfile.CapShiftProfileDtlContainer.Count; j++) { 
            capShiftProfileDtlContainer.Add(capShiftProfile.CapShiftProfileDtlContainer[j]);
        }        
    }    
    setDataContextListView(listView, capShiftProfileDtlContainer);    
    loadTotalsPerTasks(capShiftProfileDtlContainer);
}

public
CapShiftProfile delDtlNew(){
    CapShiftProfile     capShiftProfile = null;
    try{
        CapShiftProfileDtl  capShiftProfileDtl = (CapShiftProfileDtl)getSelected(addShiftsRListView);
       
        if (capShiftProfileDtl != null){            

            capShiftProfile = sumCapShiftProfileContainer.getByShiftNum(capShiftProfileDtl.ShiftNumShow);
            if (capShiftProfile != null){                        

                if (System.Windows.Forms.MessageBox.Show("Do You Want To Delete Item ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes){
                    capShiftProfile.CapShiftProfileDtlContainer.Remove(capShiftProfileDtl);                                        
                    save(capShiftProfile);
                    showDtlNew(addShiftsRListView);
                    setSelected(addShiftsListView,capShiftProfile); //select profile
                }
            }
        }else
            MessageBox.Show("Please, Select Item First.");

    }catch (Exception ex){
        MessageBox.Show("delDtlNew Exception: " + ex.Message);
    }   
    return capShiftProfile;
}

public
CapShiftProfile getCapShiftProfileSelected(){
    CapShiftProfile     capShiftProfile = null;
    try{
        capShiftProfile = (CapShiftProfile)getSelected(this.addShiftsListView);
                
    }catch (Exception ex){
        MessageBox.Show("getCapShiftProfileSelected Exception: " + ex.Message);
    }   
    return capShiftProfile;
}

public
CapShiftProfile getCapShiftProfileSelectedDtl(){
    CapShiftProfile     capShiftProfile = null;
    try{
        CapShiftProfileDtl  capShiftProfileDtl = (CapShiftProfileDtl)getSelected(addShiftsRListView);
        
        if (capShiftProfileDtl != null){            
            capShiftProfile = sumCapShiftProfileContainer.getByShiftNum(capShiftProfileDtl.ShiftNumShow);            
        }        

    }catch (Exception ex){
        MessageBox.Show("getCapShiftProfileSeleected Exception: " + ex.Message);
    }   
    return capShiftProfile;
}
        
public
void rewriteCapShiftProfileDtlListViewColumns(ListView listView,DateTime startDate){
    try {         
        createListViewColumns(listView,15);
        GridView                view = (GridView)listView.View;

        string                  sweek ="";
        string                  space ="   ";
        double                  dcornerRadius = 6;
        double                  dwith =60;
        double                  dheight =20;
        double                  dfonSize =12;
        string                  sbindPanel = "";
        FontWeight              fontWeight = FontWeights.UltraBold;
        FrameworkElementFactory frameworkElementFactoryTextBox=null;
        ListViewCol             listViewCol = null;
        int                     indexStartDays=8;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
        cell.Setters.Add(new Setter(Control.FontSizeProperty, dfonSize));
        Setter          textAlignSetter = new Setter(Control.HorizontalContentAlignmentProperty, HorizontalAlignment.Left);
        cell.Setters.Add(textAlignSetter);
            
        for (int i=0; i < view.Columns.Count;i++){
            GridViewColumn column = (GridViewColumn)view.Columns.ElementAt(i);
        
            listViewCol = new ListViewCol();
            sbindPanel = "";
            if (i >= indexStartDays) { 
                fontWeight = FontWeights.Bold;
                dcornerRadius = 0;
                sbindPanel  = "DayCell" + (i- indexStartDays+1);
                                         
                listViewCol.addTextBox("Required",  false,true ,dwith, dheight, dfonSize,fontWeight,TextAlignment.Left,Colors.Black,Colors.DarkBlue);            
                listViewCol.setConverter( new DecimalToStringConverterNew(),"int");

                listViewCol.addTextBox("Planned",  false,true ,dwith, dheight, dfonSize,fontWeight,TextAlignment.Left,Colors.Black,Colors.DarkBlue);            
                listViewCol.setConverter( new DecimalToStringConverterNew(),"int");
            }
            
            column.HeaderContainerStyle = cell;        
            column.Width = dwith+10;
                          
            switch (i){
                case 0:
                    column.Header = "Shift";                
                    column.Width = 50;
                    listViewCol.addTextBlock("ShiftNumShow",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left,Colors.DarkBlue,Colors.LightGreen);                    
                    listViewCol.setConverter( new DecimalToStringConverterNew(), "int");
                    break;   
                case 1:
                    column.Header = "Dtl#";                
                    column.Width = 40;
                    listViewCol.addTextBlock("Detail",column.Width,dheight,dfonSize, fontWeight,TextAlignment.Left,Colors.DarkBlue,Colors.LightGreen);                    
                    listViewCol.setConverter( new DecimalToStringConverterNew(), "int");
                    break;                                            
                case 2:
                    column.Header = space + "Task Id"  + "\n" + space + "Name";                                
                    column.Width = 130;
                    listViewCol.addTextBlock("ShiftTaskId" ,column.Width, dheight,dfonSize, fontWeight,TextAlignment.Left,Colors.DarkBlue,UIColors.COLOR_SELECT);                                        
                    listViewCol.addTextBlock("TaskNameShow",column.Width, dheight,dfonSize, fontWeight,TextAlignment.Left,Colors.DarkBlue,UIColors.COLOR_SELECT);                                        
                    break;            
                case 3:                            
                    column.Header = "Di/In";                
                    column.Width = 40;
                    listViewCol.addTextBlock("DirIndShow", column.Width+10, dheight,dfonSize, fontWeight,TextAlignment.Left,Colors.DarkBlue,Colors.LightGreen);                                        
                    break;
                case 4:                    
                    column.Header = "People";                
                    column.Width = 60;
                    listViewCol.addTextBlock("NumPeople", column.Width+10, dheight,dfonSize, fontWeight,TextAlignment.Left,Colors.DarkBlue,Colors.LightGreen);                                        
                    break;
                case 5:
                    column.Header = "Percent";                
                    column.Width = 60;
                    listViewCol.addTextBlock("Percentaje", column.Width+10, dheight,dfonSize, fontWeight,TextAlignment.Left,Colors.DarkBlue,Colors.LightGreen);                                                            
                    listViewCol.setConverter( new DecimalToStringConverterNew(), "");
                    break;
                case 6:
                    column.Header = "Hours";                
                    column.Width = 60;
                    listViewCol.addTextBlock("Hours", column.Width+10, dheight,dfonSize, fontWeight,TextAlignment.Left,Colors.DarkBlue,Colors.LightGreen);                                                            
                    listViewCol.setConverter( new DecimalToStringConverterNew(), "");
                    break;
                 case 7:
                    column.Header = space + "Desc";
                    sbindPanel = "CellTitles";                
                    column.Width = 80;
                    listViewCol.addTextBlock("Title1",column.Width+10,dheight,dfonSize, fontWeight,TextAlignment.Left, Colors.DarkBlue, Colors.AntiqueWhite);
                    listViewCol.addTextBlock("Title2",column.Width+10,dheight,dfonSize, fontWeight,TextAlignment.Left, Colors.DarkBlue, Colors.AntiqueWhite);                    
                    break;
                case 8:
                    column.Header = space + "Mond" + "\n" + space + DateUtil.getDateRepresentation(startDate, DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 9:
                    column.Header = space + "Tues" + "\n" + space + DateUtil.getDateRepresentation(startDate.AddDays(1), DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 10:
                    column.Header = space + "Wedn" + "\n" + space + DateUtil.getDateRepresentation(startDate.AddDays(2), DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 11:
                    column.Header = space + "Thur" + "\n" + space + DateUtil.getDateRepresentation(startDate.AddDays(3), DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 12:
                    column.Header = space + "Frid" + "\n" + space + DateUtil.getDateRepresentation(startDate.AddDays(4), DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 13:
                    column.Header = space + "Satu" + "\n" + space + DateUtil.getDateRepresentation(startDate.AddDays(5), DateUtil.MMDDYYYY).Substring(0,5);
                    break;
                case 14:
                    column.Header = space + "Sund" + "\n" + space + DateUtil.getDateRepresentation(startDate.AddDays(6), DateUtil.MMDDYYYY).Substring(0,5);
                    break;                                            
            }                  
            column.CellTemplate = listViewCol.getDataTemplate(sbindPanel,dcornerRadius,1,Colors.Silver);                                             
        }    

    } catch (Exception ex) {
        MessageBox.Show("rewriteMachinePartListViewColumns Exception: " + ex.Message);        
    }
}

public
void selectDtlBasedHdr(CapShiftProfile capShiftProfile){
    try { 
        CapShiftProfileDtl capShiftProfileDtl = null;

        if (capShiftProfile!= null && capShiftProfile.CapShiftProfileDtlContainer.Count > 0){
            capShiftProfileDtl  = capShiftProfile.CapShiftProfileDtlContainer[0];
            setSelected(addShiftsRListView, capShiftProfileDtl);
        }

    } catch (Exception ex) {
        MessageBox.Show("rewriteMachinePartListViewColumns Exception: " + ex.Message);        
    }
 
}
        
public
CapShiftProfile addNew(string splant,ComboBox dateCombo){
    CapShiftProfile capShiftProfile = null;
    try {       
        CapShiftProfile             capShiftProfileAux = null;
        CapShiftProfile             capShiftProfileDefault = null;
        CapShiftProfileContainer    capShiftProfileContainerDefault=getCoreFactory().createCapShiftProfileContainer();
        int                         imaxShiftNum = sumCapShiftProfileContainer.getMaxSiftNum();
        DateTime                    startDate   = DateTime.Now;
        DateTime                    endDate     = DateTime.Now;
        DateTime                    currDate    = DateTime.Now;
        bool                        basicShift=false;
      
        getDatesSelected(dateCombo, out startDate,out endDate);
        imaxShiftNum++;

        for (int i=1; i <= Constants.MAX_SHIFTS && !basicShift; i++){ //check if based shift not defined
            capShiftProfileAux = sumCapShiftProfileContainer.getByShiftNum(i);
            if (capShiftProfileAux == null) { 
                imaxShiftNum = i;
                basicShift = true;
            }
        }    

        if (!basicShift && imaxShiftNum >= 3 && sumCapShiftProfileContainer.Count >= Constants.MAX_SHIFTS &&
            System.Windows.Forms.MessageBox.Show("Already Exits At Least 3 Shifts Created, Do You Want To Create New Shift Anyways ? ", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
            return null;        
                
        capShiftProfile = getCoreFactory().createCapShiftProfile();        
        capShiftProfile.ShiftNum = imaxShiftNum;
        capShiftProfile.Plant = splant;
        capShiftProfile.StartDate = startDate;
        capShiftProfile.EndDate = endDate;

        //get default shift profile
        capShiftProfileContainerDefault = getCoreFactory().readCapShiftProfileByFilters("", capShiftProfile.Plant, capShiftProfile.ShiftNum,"",DateUtil.MinValue,DateUtil.MinValue,-1,Constants.STRING_YES,false,1);     
        if (capShiftProfileContainerDefault.Count > 0) { 
            capShiftProfileDefault= capShiftProfileContainerDefault[0];

            capShiftProfileDefault.Id = 0;            
            capShiftProfileDefault.StartDate= capShiftProfile.StartDate;
            capShiftProfileDefault.EndDate  = capShiftProfile.EndDate;
            capShiftProfileDefault.ShiftDefault = Constants.STRING_NO;

            capShiftProfile  = capShiftProfileDefault;            
        }else{
            capShiftProfile.ShiftType = Constants.SHIFT_TYPE_REGULAR;
            switch (imaxShiftNum){
                case 1:
                        capShiftProfile.ShiftStart  = DateUtil.timeSpanToString(DateUtil.TIME_SHIFT1_START);
                        capShiftProfile.ShiftEnd    = DateUtil.timeSpanToString(DateUtil.TIME_SHIFT1_END);
                        break;
                case 2:
                        capShiftProfile.ShiftStart  = DateUtil.timeSpanToString(DateUtil.TIME_SHIFT2_START);
                        capShiftProfile.ShiftEnd    = DateUtil.timeSpanToString(DateUtil.TIME_SHIFT2_END);
                        break;
                case 3:
                        capShiftProfile.ShiftStart  = DateUtil.timeSpanToString(DateUtil.TIME_SHIFT3_START);
                        capShiftProfile.ShiftEnd    = DateUtil.timeSpanToString(DateUtil.TIME_SHIFT3_END);
                        break;      
                default:         
                        capShiftProfile.ShiftType = Constants.SHIFT_TYPE_OVERTIME;
                        capShiftProfile.ShiftStart  = 
                        capShiftProfile.ShiftEnd    = "00:00:00";
                        break;
            }
        }
        
        bool     bholidayNotWeekend=checkIfAnyHoliday(capShiftProfile);             //check holidays
        for (int i=0; bholidayNotWeekend && i < sumCapShiftProfileContainer.Count;i++){ //if found holidays, check holidays for rest of profiles
            capShiftProfileAux = sumCapShiftProfileContainer[i];
            checkIfAnyHoliday(capShiftProfileAux);               
            save(capShiftProfileAux);
        }
            
        save(capShiftProfile);                                                  //save new profile
        sumCapShiftProfileContainer.Add(capShiftProfile);                       //add new profile to list of profiles
        sumCapShiftProfileContainer.sortByShiftNum();                           //sort by shift num
        setDataContextListView(addShiftsListView, sumCapShiftProfileContainer); //show profiles   
        showDtlNew(addShiftsRListView);                                         //show tasks
        setSelected(addShiftsListView,capShiftProfile);                         //select new shift profile
    
    } catch (Exception ex) {
        MessageBox.Show("addNew Exception: " + ex.Message);        
    }
    return capShiftProfile;
}

public
void getDatesSelected(ComboBox dateCombo,out DateTime startDate,out DateTime endDate){
    startDate = endDate = DateTime.Now;                    
    string     sdate    = getSelectedComboBoxItemString(dateCombo);
    startDate= !string.IsNullOrEmpty(sdate) ? DateUtil.parseDate(sdate,DateUtil.MMDDYYYY) : DateTime.Now;    
    DateUtil.getPriorMondayNextSundayFromDate(startDate,out startDate,out endDate);
}

public
bool delNew(){
    bool bresult=false;
    try { 
        CapShiftProfile capShiftProfile = (CapShiftProfile)deleltedSelected(addShiftsListView);

        if (capShiftProfile!= null){
            getCoreFactory().deleteCapShiftProfile(capShiftProfile.Id);
            sumCapShiftProfileContainer.Remove(capShiftProfile);
            
            setDataContextListView(addShiftsListView,sumCapShiftProfileContainer);
            showDtlNew(addShiftsRListView);
            bresult=true;
        }

    } catch (Exception ex) {
        MessageBox.Show("addNew Exception: " + ex.Message);        
    }

    return bresult;            
}
        
public
bool delMachPlan(CapShiftProfile capShiftProfile,ListView addMachPlanListView){    
    bool bresult=false;
    try {         
        if (capShiftProfile!= null){
            CapShiftProfileMachPlan capShiftProfileMachPlan = (CapShiftProfileMachPlan)deleltedSelected(addMachPlanListView);

            if (capShiftProfileMachPlan != null){
                capShiftProfile.CapShiftProfileMachPlanContainer.Remove(capShiftProfileMachPlan);

                getCoreFactory().updateCapShiftProfile(capShiftProfile);
                setDataContextListView(addMachPlanListView,capShiftProfile.CapShiftProfileMachPlanContainer);
                bresult=true;
            }                       
        }

    } catch (Exception ex) {
        MessageBox.Show("delMachPlan Exception: " + ex.Message);        
    }

    return bresult;       

}             

public
bool searchMachine(CapShiftProfileMachPlan capShiftProfileMachPlan){    
    bool bresult=false;
    try{   
        CapShiftProfile capShiftProfile = getCapShiftProfileSelected();
        if (capShiftProfile!= null && capShiftProfileMachPlan != null) { 

            Machine machine = searchMachine(capShiftProfile.Plant);            
            if (machine != null){
                loadMachineInfo(capShiftProfileMachPlan, machine,machine.Id);                        
                bresult=true;
            }
        }             

    }catch (Exception ex){
        MessageBox.Show("searchMachine Exception: " + ex.Message);
    } 
    return bresult;
}

public
bool loadMachineInfo(CapShiftProfileMachPlan capShiftProfileMachPlan,Machine machineAux,int imachineId){
    bool bresult=false;
    try{
        Machine machine = machineAux;

        if (machine == null)
            machine = getCoreFactory().readMachineById(imachineId);
    
        if (machine != null){
            capShiftProfileMachPlan.MachId      = machine.Id;
            capShiftProfileMachPlan.MachShow    = machine.Mach;
            capShiftProfileMachPlan.MachNameShow= machine.Des1;
            bresult=true;
        }

    }catch (Exception ex){
        MessageBox.Show("loadMachineInfo Exception: " + ex.Message);
    } 
    return bresult;
}
        
public
bool loadMachPlan(CapShiftProfileMachPlan capShiftProfileMachPlan,ComboBox dateMachPlanComboBox){    
    bool bresult=false;
    try{   
        CapShiftProfile capShiftProfile = getCapShiftProfileSelected();
        if (capShiftProfile!= null && capShiftProfileMachPlan != null) { 

           loadProfileMachPlanComboBox(dateMachPlanComboBox,capShiftProfile);
        }             

    }catch (Exception ex){
        MessageBox.Show("loadMachPlan Exception: " + ex.Message);
    } 
    return bresult;
}

public
void loadProfileMachPlanComboBox(ComboBox comboBox, CapShiftProfile capShiftProfile){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        

        for (int i=0; capShiftProfile.StartDate.AddDays(i) <= capShiftProfile.EndDate; i++) { 
            DateTime    currDate= capShiftProfile.StartDate.AddDays(i);
            string      sdate   = DateUtil.getDateRepresentation(currDate, DateUtil.MMDDYYYY);
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(sdate, sdate));
        }                       
        comboBox.ItemsSource = list;        
    } catch (Exception ex) {
        MessageBox.Show("loadProfileMachPlanComboBox Exception: " + ex.Message);        
    }
}

public
bool savePlannedPart(PlannedHdr plannedHdr,PlannedPart plannedPart,CapShiftProfile capShiftProfile,CapShiftProfileMachPlan capShiftProfileMachPlan,bool badding){    
    bool bresult=false;
    try{   
        PlannedReq plannedReq = null;

        if (plannedHdr != null && plannedPart != null && capShiftProfile!= null && capShiftProfileMachPlan != null && 
            DateUtil.sameDate(capShiftProfile.StartDate,plannedPart.StartDate)) { //must be same StartDate

            plannedReq = getPlannedReqSelected(plannedHdr,plannedPart,capShiftProfile);

            if (plannedReq!= null &&    //new capShiftProfileMachPlan for same machine, so we store link on PlannedPart
                plannedReq.Type.Equals(Constants.TYPE_MACHINE) && plannedReq.ReqID == capShiftProfileMachPlan.MachId) {

                if (badding) {  //adding/modify
                    plannedPart.ProfMachPlanHdrId = capShiftProfileMachPlan.HdrId;
                    plannedPart.ProfMachPlanHdrDtl= capShiftProfileMachPlan.Detail;
                }else if (  plannedPart.ProfMachPlanHdrId == capShiftProfileMachPlan.HdrId && 
                            plannedPart.ProfMachPlanHdrDtl == capShiftProfileMachPlan.Detail){ //removing

                    plannedPart.ProfMachPlanHdrId = 
                    plannedPart.ProfMachPlanHdrDtl= 0;
                }
                getCoreFactory().updatePlannedPart(plannedHdr,plannedPart);                
            }           
        }             

    }catch (Exception ex){
        MessageBox.Show("savePlannedPart Exception: " + ex.Message);
    } 
    return bresult;
}

public
PlannedReq getPlannedReqSelected(PlannedHdr plannedHdr,PlannedPart plannedPart,CapShiftProfile capShiftProfile){    
    PlannedReq plannedReq = null;
    try{           
        if (plannedHdr != null && plannedPart != null && capShiftProfile != null && 
            DateUtil.sameDate(capShiftProfile.StartDate,plannedPart.StartDate)) { //must be same StartDate

            plannedReq = plannedHdr.PlannedReqContainer.getByKey(plannedPart.HdrId,plannedPart.Detail);             
        }             

    }catch (Exception ex){
        MessageBox.Show("getPlannedReqSelected Exception: " + ex.Message);
    } 
    return plannedReq;
}


public
void loadMachPlanEmployee(CapShiftProfile capShiftProfile){
    try { 
        CapShiftProfileMachPlan                     capShiftProfileMachPlan = (CapShiftProfileMachPlan)getSelected(addMachPlanListView);
        CapShiftProfileMachPlanEmployeeContainer    capShiftProfileMachPlanEmployeeContainer = getCoreFactory().createCapShiftProfileMachPlanEmployeeContainer();
        CapShiftProfileMachPlanEmployee             capShiftProfileMachPlanEmployee=null;
    
        machPlanEmployeeTopLabel.Content = "";

        if (capShiftProfileMachPlan!= null){
            //show title
            string space = StringUtil.AddSpaces("",7,false);
            machPlanEmployeeTopLabel.Content = "Machine : " + capShiftProfileMachPlan.MachShow + "/" + capShiftProfileMachPlan.MachNameShow + space + "Date : " + DateUtil.getDateRepresentation(capShiftProfileMachPlan.Date,DateUtil.MMDDYYYY) +  " Shift : " + capShiftProfile.ShiftNum + space +
                                               "Total Employee/s :" + capShiftProfileMachPlan.CapShiftProfileMachPlanEmployeeContainer.Count.ToString();

            capShiftProfileMachPlanEmployeeContainer = capShiftProfileMachPlan.CapShiftProfileMachPlanEmployeeContainer;            

            //we try to load employee names
            for (int i=0; i < capShiftProfileMachPlanEmployeeContainer.Count; i++){
                capShiftProfileMachPlanEmployee = capShiftProfileMachPlanEmployeeContainer[i];

                if (string.IsNullOrEmpty(capShiftProfileMachPlanEmployee.EmpNameShow)) {  
                    Employee employee = getCoreFactory().readEmployee(capShiftProfileMachPlanEmployee.EmpId);
                    if (employee!= null)
                        capShiftProfileMachPlanEmployee.EmpNameShow = employee.FirstName + " " + employee.LastName;
                }
            }
        }
        setDataContextListView(addMachPlanEmployeeListView,capShiftProfileMachPlanEmployeeContainer);

    }catch (Exception ex){
        MessageBox.Show("loadMachPlanEmployee Exception: " + ex.Message);
    } 
}

public
bool addMachPlanEmployee(CapShiftProfile capShiftProfile){    
    bool bresult=false;
    try {
        CapShiftProfileMachPlan             capShiftProfileMachPlan = (CapShiftProfileMachPlan)getSelected(addMachPlanListView);
        CapShiftProfileMachPlanEmployee     capShiftProfileMachPlanEmployee= null;

        if (capShiftProfile!= null && capShiftProfileMachPlan!= null){
            
            Employee employee = searchEmployee(capShiftProfile.ShiftNum);   //search for employee                
            if (employee!= null){
                capShiftProfileMachPlanEmployee = capShiftProfileMachPlan.CapShiftProfileMachPlanEmployeeContainer.getByEmpId(employee.Id);
                if (capShiftProfileMachPlanEmployee!= null)
                    MessageBox.Show("Sorry, Employee Id : "  + employee.Id + " Name : " + employee.FirstName + " " + employee.LastName + " Already Added.");
                else{
                    capShiftProfileMachPlanEmployee = getCoreFactory().createCapShiftProfileMachPlanEmployee();
                    capShiftProfileMachPlanEmployee.EmpId = employee.Id;
                    capShiftProfileMachPlanEmployee.EmpNameShow = employee.FirstName + " " + employee.LastName;
                    capShiftProfileMachPlan.CapShiftProfileMachPlanEmployeeContainer.Add(capShiftProfileMachPlanEmployee);                    
                    loadMachPlanEmployee(capShiftProfile); 
                    setSelected(addMachPlanEmployeeListView,capShiftProfileMachPlan); //set new value added selected on listview

                    save(capShiftProfile);

                    bresult=true;
                }
            }
        }

    } catch (Exception ex) {
        MessageBox.Show("addMachPlanEmployee Exception: " + ex.Message);        
    }

    return bresult;       
} 

public
bool delMachPlanEmployee(CapShiftProfile capShiftProfile){    
    bool bresult=false;
    try {
        CapShiftProfileMachPlan             capShiftProfileMachPlan = (CapShiftProfileMachPlan)getSelected(addMachPlanListView);
        CapShiftProfileMachPlanEmployee     capShiftProfileMachPlanEmployee= (CapShiftProfileMachPlanEmployee)deleltedSelected(addMachPlanEmployeeListView);
                
        if (capShiftProfile!= null && capShiftProfileMachPlan!= null && capShiftProfileMachPlanEmployee!= null){
            capShiftProfileMachPlan.CapShiftProfileMachPlanEmployeeContainer.Remove(capShiftProfileMachPlanEmployee);            
            loadMachPlanEmployee(capShiftProfile);

            save(capShiftProfile);
            bresult=true;                       
        }

    } catch (Exception ex) {
        MessageBox.Show("delMachPlanEmployee Exception: " + ex.Message);        
    }

    return bresult;       
}

public
bool loadEmployeesByShiftProfile(CapShiftProfile capShiftProfile){    
    bool bresult=false;
    try {
        EmployeeContainer                   employeeContainer = null;
                
        if (capShiftProfile!= null){
            employeeContainer = getCoreFactory().readEmployeeByFilters("","","",Constants.STATUS_ACTIVE,capShiftProfile.ShiftNum,"",-1,false,false,0);
            bresult=true;                       
        }
        setDataContextListView(machPlanEmployeeListView, employeeContainer);

    } catch (Exception ex) {
        MessageBox.Show("loadEmployeesByShiftProfile Exception: " + ex.Message);        
    }

    return bresult;       
}

public 
void searchForEmployee(CapShiftProfile capShiftProfile,ComboBox searchByComboBox, ComboBox deptCombo,TextBox searchForTextBox){
    try{ 
        int         irows           = 0;
        string      sid             = getSearchFromComboBoxString(searchByComboBox,searchForTextBox,0);
        string      sfirsName       = getSearchFromComboBoxString(searchByComboBox,searchForTextBox,1);
        string      slastName       = getSearchFromComboBoxString(searchByComboBox,searchForTextBox,2);
        string      sdept           = (string)getSelectedComboBoxItem(deptCombo);            
        string      status          = Constants.STATUS_ACTIVE;
        int         iassignShift    = capShiftProfile != null ? capShiftProfile.ShiftNum:0;
        
        EmployeeContainer employeeContainer = getCoreFactory().readEmployeeByFilters(sid,sfirsName,slastName, status, iassignShift, sdept,-1,false,false,irows);
        setDataContextListView(machPlanEmployeeListView, employeeContainer);
        
        searchForTextBox.Focus();

    } catch (Exception ex) {
        MessageBox.Show("searchForEmployee Exception: " + ex.Message);        
    }
                   
}

/********************************** EmpShiftSchedule *************************************************************/
public
EmpShiftScheduleHdr getSelectedEmpH(){
    EmpShiftScheduleHdr empShiftScheduleHdr = (EmpShiftScheduleHdr)getSelected(this.sheduleHdrListView);
    return empShiftScheduleHdr;
}

public
EmpShiftScheduleDtl getSelectedEmpDtl(){
    EmpShiftScheduleDtl empShiftScheduleDtl = (EmpShiftScheduleDtl)getSelected(this.sheduleDtlListView);
    return empShiftScheduleDtl;
}

public
void saveEH(EmpShiftScheduleHdr empShiftScheduleHdr){
    try {         
        if (empShiftScheduleHdr!= null){                   
            if (empShiftScheduleHdr.Id > 0)
                getCoreFactory().updateEmpShiftScheduleHdr(empShiftScheduleHdr);
            else
                getCoreFactory().writeEmpShiftScheduleHdr(empShiftScheduleHdr);                
       }  
    
    } catch (Exception ex) {
        MessageBox.Show("saveEH Exception: " + ex.Message);        
    }     
}

public
void saveEDtl(ref bool baddingDtl){
    try { 
        EmpShiftScheduleHdr empShiftScheduleHdr = getSelectedEmpH();
        if (empShiftScheduleHdr!= null){
       
            if (baddingDtl)
                empShiftScheduleHdr.EmpShiftScheduleDtlContainer.Add(empShiftScheduleDtl);
            
            saveEH(empShiftScheduleHdr);        
            baddingDtl=false;
       }   

    } catch (Exception ex) {
        MessageBox.Show("saveEDtl Exception: " + ex.Message);        
    } 
}

public
EmpShiftScheduleDtl addEDtl(){    
    empShiftScheduleDtl = null;
    try { 
        EmpShiftScheduleHdr     empShiftScheduleHdr = getSelectedEmpH(); 
        if (empShiftScheduleHdr!= null){
            empShiftScheduleDtl = getCoreFactory().createEmpShiftScheduleDtl();
            EmpShiftScheduleDtlContainer    empShiftScheduleDtlContainer = (EmpShiftScheduleDtlContainer)sheduleDtlListView.DataContext;

            if (empShiftScheduleDtlContainer==null)
                empShiftScheduleDtlContainer = getCoreFactory().createEmpShiftScheduleDtlContainer();

            empShiftScheduleDtlContainer.Add(empShiftScheduleDtl);
            setDataContextListView(sheduleDtlListView, empShiftScheduleDtlContainer);
            if (sheduleDtlListView.Items.Count > 0)
                sheduleDtlListView.SelectedIndex = sheduleDtlListView.Items.Count-1;//position on last record, to be added
        }    

    } catch (Exception ex) {
        MessageBox.Show("addEDtl Exception: " + ex.Message);        
    }
    return empShiftScheduleDtl;
}


public 
bool delEHdr(){    
    bool                bresult=false;
    try { 
        EmpShiftScheduleHdr empShiftScheduleHdr = (EmpShiftScheduleHdr)deleltedSelected(this.sheduleHdrListView);         

        if (empShiftScheduleHdr!= null){
            getCoreFactory().deleteEmpShiftScheduleHdr(empShiftScheduleHdr.Id);
            bresult=true;
        }     

    } catch (Exception ex) {
        MessageBox.Show("delEHdr Exception: " + ex.Message);        
    }
    return bresult;
}

public 
bool delEDtl(){    
    bool                bresult=false;
    try { 
        EmpShiftScheduleHdr empShiftScheduleHdr = getSelectedEmpH();         

        if (empShiftScheduleHdr!= null){
            ArrayList               arrayDel = deleltedSelecteds(this.sheduleDtlListView);
            EmpShiftScheduleDtl     empShiftScheduleDtl = null;

            if (arrayDel.Count > 0){                
                for (int i=0; i < arrayDel.Count; i++) { 
                    empShiftScheduleDtl = (EmpShiftScheduleDtl)arrayDel[i];
                    empShiftScheduleHdr.EmpShiftScheduleDtlContainer.Remove(empShiftScheduleDtl);                            
                }

                saveEH(empShiftScheduleHdr);
                bresult=true;
            }
        }     

    } catch (Exception ex) {
        MessageBox.Show("delEDtl Exception: " + ex.Message);        
    }
    return bresult;
}

public 
bool dataOKEDtl(bool baddingDtl){
    bool                bresult=true;

    try { 
        empShiftScheduleHdr = getSelectedEmpH();
        EmpShiftScheduleDtl empShiftScheduleDtl = getSelectedEmpDtl();

        if (empShiftScheduleDtl == null){
            MessageBox.Show("Detail Object Not Created.");
            return false;
        }

        if (string.IsNullOrEmpty(empShiftScheduleDtl.EmpId)){
            MessageBox.Show("Please, Select Employee.");
            bresult=false;
        }
        
        if (empShiftScheduleDtl.MachId <= 0){
            MessageBox.Show("Please, Select Machine.");
            bresult=false;
        }

        if (empShiftScheduleDtl.LabourTypeId <= 0){
            MessageBox.Show("Please, Select Labour Type.");
            bresult=false;
        }

        if (baddingDtl){
            EmpShiftScheduleDtlContainer empShiftScheduleDtlContainer = empShiftScheduleHdr.EmpShiftScheduleDtlContainer.getByFilters(empShiftScheduleDtl.EmpId, empShiftScheduleDtl.MachId, empShiftScheduleDtl.LabourTypeId);
            if (empShiftScheduleDtlContainer.Count > 0){
                MessageBox.Show("Sorry, Schedule Empoyee, Already Added, Please Modify.");
                bresult=false;
            }
        }
    
    } catch (Exception ex) {
        MessageBox.Show("dataOKEDtl Exception: " + ex.Message);        
    }
    return bresult;
}

public
bool createdByEHSearch(){
    bool bresult=false;
    try { 
        if (empShiftScheduleHdr!= null) { 
            employeeCreatedBy = this.searchEmployee();     
            if (employeeCreatedBy != null) {
                empShiftScheduleHdr.CreatedByEmpId          = employeeCreatedBy.Id;
                empShiftScheduleHdr.CreatedByEmpNameShow    = employeeCreatedBy.FullName;

                if (string.IsNullOrEmpty(empShiftScheduleHdr.Dept) && empShiftScheduleHdr.EmpShiftScheduleDtlContainer.Count < 1)
                    empShiftScheduleHdr.Dept = employeeCreatedBy.DftDept;
                if (empShiftScheduleHdr.ShiftNum <=0)
                    empShiftScheduleHdr.ShiftNum = employeeCreatedBy.AssignShift;

                bresult =true;
            }
        }
                
    } catch (Exception ex) {
        MessageBox.Show("createdByEHSearch Exception: " + ex.Message);        
    }      
    return bresult;
}

public
void addToMachine(){  
    try {         
        if (empShiftScheduleHdr != null) { 
            ArrayList                       employArray                 = getSelecteds(scheduleDtlEmployeeListView);
            ArrayList                       machineArray                = getSelecteds(scheduleDtlMachineListView);
            EmployeeContainer               employeeContainerShowed     = scheduleDtlEmployeeListView.DataContext!= null?(EmployeeContainer)scheduleDtlEmployeeListView.DataContext:getCoreFactory().createEmployeeContainer();
            MachineContainer                machineContainerShowed      = scheduleDtlMachineListView.DataContext!= null ?(MachineContainer)scheduleDtlMachineListView.DataContext:getCoreFactory().createMachineContainer();
            Employee                        employee                    = null;                          
            Machine                         machine                     = null;                          
            EmpShiftScheduleDtl             empShiftScheduleDtl         = null;            
            EmpShiftScheduleDtlContainer    empShiftScheduleDtlContainer= getCoreFactory().createEmpShiftScheduleDtlContainer();
            EmpShiftScheduleDtlContainer    empShiftScheduleDtlContainerCreated = getCoreFactory().createEmpShiftScheduleDtlContainer();
            EmpShiftScheduleDtlContainer    empShiftScheduleDtlContainerExists  = getCoreFactory().createEmpShiftScheduleDtlContainer();
            

            for (int i=0; i < employArray.Count; i++){
                employee = (Employee)employArray[i];  

                for (int j=0; j < machineArray.Count;j++){
                    machine = (Machine)machineArray[j];  

                    empShiftScheduleDtl = getCoreFactory().createEmpShiftScheduleDtl();
                    empShiftScheduleDtl.EmpId           = employee.Id;
                    empShiftScheduleDtl.LabourTypeId    = employee.DftLabourTypeId;
                    empShiftScheduleDtl.MachId          = machine.Id;

                    empShiftScheduleDtlContainer = empShiftScheduleHdr.EmpShiftScheduleDtlContainer.getByFilters(empShiftScheduleDtl.EmpId, empShiftScheduleDtl.MachId, empShiftScheduleDtl.LabourTypeId);
                    if (empShiftScheduleDtlContainer.Count < 1){ 
                        empShiftScheduleHdr.EmpShiftScheduleDtlContainer.Add(empShiftScheduleDtl);
                        empShiftScheduleDtlContainerCreated.Add(empShiftScheduleDtl);

                        employee.SelectedShow   = true;//show employee and machine as selected/planned
                        machine.Scheduled       = PLANNED;    
                    }else
                        empShiftScheduleDtlContainerExists.Add(empShiftScheduleDtl);
                }                                                
            }
                       
            saveEH(empShiftScheduleHdr);
            MessageBox.Show("Total Schedule Employee Added :"  +    empShiftScheduleDtlContainerCreated.Count + "\n" +
                            "Already Exists :" +                    empShiftScheduleDtlContainerExists.Count);
        }
                            
    } catch (Exception ex) {
        MessageBox.Show("addToMachine Exception: " + ex.Message);        
    }          
}

public
void checkEmployeesAlreadySelected(EmployeeContainer employeeContainer,string showSelected){
    try{ 
        Hashtable                   hashEmployees   = empShiftScheduleHdr.EmpShiftScheduleDtlContainer.getHashEmployees();
        Hashtable                   hashEmployAbsent= empShiftScheduleHdr.EmpShiftScheduleDtlContainer.getHashEmployeesAbsent();
        Employee                    employee        = null;       
        
        for (int i=0; employeeContainer!= null && i < employeeContainer.Count; i++){ //check what employees were already selected/assigned
            employee = employeeContainer[i];                        
            employee.SelectedShow = hashEmployees.Contains(employee.Id.ToUpper());       

            if (hashEmployAbsent.Contains(employee.Id.ToUpper()))	
                employee.FlagShow = Constants.STRING_YES;

            //check show selected condition if filter must applied and item might be removed
            if (!string.IsNullOrEmpty(showSelected) && !showSelected.Equals(Constants.SHOW_ALL)){
                if ((showSelected.Equals(Constants.STRING_YES) && !employee.SelectedShow) ||                    
                    (showSelected.Equals(Constants.STRING_NO)  && employee.SelectedShow)){ 
                    employeeContainer.RemoveAt(i);
                    i--;
                }
            }
        }

    } catch (Exception ex) {
        MessageBox.Show("checkEmployeesAlreadySelected Exception: " + ex.Message);        
    } 
}

public
void checkMachinesAlreadySelected(MachineContainer machineContainer, string showSelected){
    try{ 
        Hashtable       hashMachines= empShiftScheduleHdr.EmpShiftScheduleDtlContainer.getHashMachines();
        Machine         machine     = null;       
        
        for (int i=0; machineContainer != null && i < machineContainer.Count; i++){ //check what employees were already selected/assigned
            machine = machineContainer[i];       
                    
            machine.Scheduled = hashMachines.Contains(machine.Id) ? PLANNED : NOT_PLANNED;            

            //check show selected condition if filter must applied and item might be removed
            if (!string.IsNullOrEmpty(showSelected) && !showSelected.Equals(Constants.SHOW_ALL)){
                if ((showSelected.Equals(Constants.STRING_YES) && machine.Scheduled.Equals(NOT_PLANNED)) ||                    
                    (showSelected.Equals(Constants.STRING_NO)  && machine.Scheduled.Equals(PLANNED))){ 
                    machineContainer.RemoveAt(i);
                    i--;
                }
            }
        }

    } catch (Exception ex) {
        MessageBox.Show("checkMachinesAlreadySelected Exception: " + ex.Message);        
    } 
}

public
void machinesLoadPriorities(MachineContainer machineContainer,string splant){
    try {         
        CapacityHdr  capacityHdr = getCapacityHdr(splant);

        for (int i=0; i < machineContainer.Count; i++){
            Machine machine = machineContainer[i];
            CapacityMachPriority capacityMachPriority = capacityHdr.CapacityMachPriorityContainer.getByMachine(machine.Id);
            if (capacityMachPriority!= null)
                machine.PriorityShow = capacityMachPriority.Priority;
        }
        machineContainer.sortByPriority();

    } catch (Exception ex) {
        MessageBox.Show("machinesLoadPriorities Exception: " + ex.Message);        
    } 
}

public 
void unSelectMachines(){
    scheduleDtlMachineListView.SelectedItem= null; //unselect all items
}         

public 
void unSelectEmployees(){
    scheduleDtlEmployeeListView.SelectedItem= null; //unselect all items
}  

public
CapacityHdr getCapacityHdr(string splant){
    capacityHdr = getCoreFactory().readCapacityHdrLastDateCheck(capacityHdr,splant);
    return capacityHdr;
}
 
public
Machine getMachineById(int imachineId){   
    return getMachineById(hashMachinesById,imachineId);
}               

public
void loadEmployeesMachCode(EmployeeContainer employeeContainer){    
    this.loadEmployeesMachCode(employeeContainer,hashMachinesById);
}
    
/************************************** notes **************************************************************************/
public
void loadColumnsOnEmployeeHdrNotesListView(ListView listView){
     try {
        GridView                gridView = new GridView();
        TextColumnListView      textColumnListView = null;                        
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));     
                
        textColumnListView = new TextColumnListView("Notes Descriptions", "Notes", BindingMode.TwoWay,(int)this.window.Width, listView);                
        textColumnListView.setProperty(TextBox.FontWeightProperty, FontWeights.Black);        
        textColumnListView.getColumn().HeaderContainerStyle = cell;                

        textColumnListView.setProperty(TextBox.VerticalContentAlignmentProperty,VerticalAlignment.Top);
        textColumnListView.setProperty(TextBox.IsEnabledProperty,true);
        textColumnListView.setProperty(TextBox.HeightProperty,(double)100);
        textColumnListView.setProperty(TextBox.AcceptsReturnProperty,true);
        textColumnListView.setProperty(TextBox.AcceptsTabProperty,true);

        textColumnListView.setProperty(TextBox.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto);
        textColumnListView.setProperty(TextBox.HorizontalScrollBarVisibilityProperty,ScrollBarVisibility.Auto);

        gridView.Columns.Add(textColumnListView.process());   
                        
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnEmployeeHdrNotesListView Exception: " + ex.Message);        
    }    
}
        /*
public
void loadHdrNotes(ListView listView,bool brefresh=false){
    try {
        EmpShiftScheduleNotesContainer  empShiftScheduleNotesContainer = getCoreFactory().createEmpShiftScheduleNotesContainer();
        string                          sbindGroupTitle = "Topic";

        if (empShiftScheduleHdr!= null){

            if (empShiftScheduleHdr.EmpShiftScheduleNotesContainer.Count < 1)
                getCoreFactory().createDefaultsEmpShiftScheduleNotes(empShiftScheduleHdr);

            empShiftScheduleNotesContainer = empShiftScheduleHdr.EmpShiftScheduleNotesContainer;

            for (int i=0; i < empShiftScheduleHdr.EmpShiftScheduleNotesContainer.Count; i++){
                EmpShiftScheduleNotes empShiftScheduleNotes = empShiftScheduleHdr.EmpShiftScheduleNotesContainer[i];
                empShiftScheduleNotes.Name = empShiftScheduleNotes.Detail.ToString();
            }
        }        
        setDataContextListView(listView,empShiftScheduleNotesContainer);
        if (!brefresh) { 
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription(sbindGroupTitle);
            view.GroupDescriptions.Add(groupDescription);           
        }
        
    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnEmployeeHdrNotesListView Exception: " + ex.Message);        
    }    
}*/

public
void loadHdrNotes(ListView listView){
    try {
        EmpShiftScheduleNotesContainer  empShiftScheduleNotesContainer = null;
        string                          sbindGroupTitle = "Topic";
        
        if (empShiftScheduleHdr!= null){
            if (empShiftScheduleHdr.EmpShiftScheduleNotesContainer.Count < 1)
                getCoreFactory().createDefaultsEmpShiftScheduleNotes(empShiftScheduleHdr);

            empShiftScheduleNotesContainer = empShiftScheduleHdr.EmpShiftScheduleNotesContainer;

            for (int i=0; i < empShiftScheduleHdr.EmpShiftScheduleNotesContainer.Count; i++){
                EmpShiftScheduleNotes empShiftScheduleNotes = empShiftScheduleHdr.EmpShiftScheduleNotesContainer[i];
                empShiftScheduleNotes.Name = empShiftScheduleNotes.Detail.ToString();
            }
        }                
        setDataContextListView(listView,empShiftScheduleNotesContainer);        
        CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
        view.GroupDescriptions.Clear();        
        PropertyGroupDescription groupDescription = new PropertyGroupDescription(sbindGroupTitle);            
        view.GroupDescriptions.Add(groupDescription);                          
        
    } catch (Exception ex) {
        MessageBox.Show("loadHdrNotes Exception: " + ex.Message);        
    }    
}

public 
void delEHNote(ListView listView){           
    try {
        EmpShiftScheduleNotes   empShiftScheduleNotes =(EmpShiftScheduleNotes)deleltedSelected(listView);

        if (empShiftScheduleHdr!= null && empShiftScheduleNotes!= null){
            empShiftScheduleHdr.EmpShiftScheduleNotesContainer.Remove(empShiftScheduleNotes);            
            empShiftScheduleHdr.fillRedundances();
            loadHdrNotes(listView);
        }        
        
    } catch (Exception ex) {
        MessageBox.Show("delEHNote Exception: " + ex.Message);        
    }    
}

public 
bool addEHNote(ListView listView,TextBox textBox){           
    bool     bresult=false;
    try {                
        EmpShiftScheduleNotes   empShiftScheduleNotes =null;
        string                  stopic = textBox.Text;

        if (empShiftScheduleHdr!= null){
            if (string.IsNullOrEmpty(stopic)){
                MessageBox.Show("Please, Enter New Note Topic.");
                textBox.Focus();
            }else{
                empShiftScheduleNotes = empShiftScheduleHdr.EmpShiftScheduleNotesContainer.getByTopic(stopic);
                if (empShiftScheduleNotes!= null){
                    MessageBox.Show("Topic " + stopic + " Already Adedd.");
                    setSelected(listView,empShiftScheduleNotes);
                }else {
                    empShiftScheduleNotes = getCoreFactory().createEmpShiftScheduleNotes();
                    empShiftScheduleNotes.Topic = stopic;
                    textBox.Text = "";

                    empShiftScheduleHdr.EmpShiftScheduleNotesContainer.Add(empShiftScheduleNotes);
                    empShiftScheduleHdr.fillRedundances();
                    loadHdrNotes(listView);
                    setSelected(listView,empShiftScheduleNotes);   
                    bresult=true;                                             
                }                
            }
        }        
        
    } catch (Exception ex) {
        MessageBox.Show("addEHNote Exception: " + ex.Message);        
    }    
    return bresult;
}

public
EmpShiftScheduleHdr copyEH(){
    EmpShiftScheduleHdr empShiftScheduleHdrNew = getSelectedEmpH();
    try {  
        EmpShiftScheduleHdr empShiftScheduleHdr     = getSelectedEmpH();
               
        if (empShiftScheduleHdr!= null) { 
            empShiftScheduleHdrNew = getCoreFactory().cloneEmpShiftScheduleHdr(empShiftScheduleHdr);
            empShiftScheduleHdrNew.Id=0;
            empShiftScheduleHdrNew.Date = DateTime.Now;
            empShiftScheduleHdrNew.fillRedundances();
        }else
            MessageBox.Show("Please, To Copy, Select Item First.");

    } catch (Exception ex) {
        MessageBox.Show("copyEH Exception: " + ex.Message);        
    }    
    return empShiftScheduleHdrNew;
}


}
}
