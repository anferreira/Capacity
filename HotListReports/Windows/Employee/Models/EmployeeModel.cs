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
using Telerik.Windows.Controls;
using Nujit.NujitWms.WinForms.Util.Controllers;

namespace HotListReports.Windows.Employees{

class EmployeeModel : BaseModel2{

private Employee employee;
private ListView hdrListView;
private ListView shiftListView;
private ListView labourListView;
private ComboBox deptComboBox;
private ComboBox machComboBox;
private string   sdeptFilter;

public EmployeeModel(Window window,ListView hdrListView,ListView shiftListView,ListView labourListView,ComboBox deptComboBox,ComboBox machComboBox) : base(window){    
    this.employee = null;

    this.hdrListView = hdrListView;
    this.shiftListView = shiftListView;
    this.labourListView = labourListView;

    this.deptComboBox = deptComboBox;
    this.machComboBox = machComboBox;
    this.sdeptFilter="";
}

public
Employee Employee {
	get { return employee; }
	set { if (this.employee != value){
			this.employee = value;			
		}
	}
}

public
void loadSearchByCombo(ComboBox searchByComboBox){    
    searchByComboBox.Items.Add("Employ.Id");
    searchByComboBox.Items.Add("FirstName");
    searchByComboBox.Items.Add("LastName");
    
    if (searchByComboBox.Items.Count > 0)
        searchByComboBox.SelectedIndex=0;
}
                
public
void loadColumnsOnHeaderGrid(ListView hdrListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("Employ.Id", "Id", BindingMode.OneWay,90, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("First Name", "FirstName", BindingMode.OneWay,150, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Last Name", "LastName", BindingMode.OneWay,150, hdrListView);        
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Shift","AssignShift", BindingMode.OneWay,50, hdrListView);                                
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("OTShift", "AssignOTShift", BindingMode.OneWay,50, hdrListView);                        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Login", "Login", BindingMode.OneWay,90, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Sts", "Status", BindingMode.OneWay,30, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Tag Number", "tagNumber", BindingMode.OneWay,90, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Dft.Dept", "DftDept", BindingMode.OneWay,80, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Dft.MachId", "DftMachId", BindingMode.OneWay,80, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Last LabDate", "LastLabourDate", BindingMode.OneWay,70, hdrListView);
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Dft.Labour", "DftLabourTypeNameShow", BindingMode.OneWay,120, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("HomePhone", "HomePhone", BindingMode.OneWay,90, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("CellPhone", "CellPhone", BindingMode.OneWay,90, hdrListView);                
        gridView.Columns.Add(textBlockColumnListView.process());

      
        hdrListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

public        
void loadColumnsOnShiftsGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        CheckColumnListView     checkColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                          
        textBlockColumnListView = new TextBlockColumnListView("Shift", "ShiftNum", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("StartDate", "StartDate", BindingMode.OneWay,70, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("EndDate", "EndDate", BindingMode.OneWay,70, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        checkColumnListView = new CheckColumnListView("Mon", "MonWork", BindingMode.TwoWay,20,listView);        
        checkColumnListView.setConverter(new ConstantYesNoToBoolConverterNew(), "");   
        checkColumnListView.setEvent(CheckBox.ClickEvent, new RoutedEventHandler(flagClickEvent));
        gridView.Columns.Add(checkColumnListView.process());

        checkColumnListView = new CheckColumnListView("Tue", "TueWork", BindingMode.TwoWay,20,listView);        
        checkColumnListView.setConverter(new ConstantYesNoToBoolConverterNew(), "");        
        checkColumnListView.setEvent(CheckBox.ClickEvent, new RoutedEventHandler(flagClickEvent));
        gridView.Columns.Add(checkColumnListView.process());

        checkColumnListView = new CheckColumnListView("Wed", "WedWork", BindingMode.TwoWay,20,listView);        
        checkColumnListView.setConverter(new ConstantYesNoToBoolConverterNew(), "");        
        checkColumnListView.setEvent(CheckBox.ClickEvent, new RoutedEventHandler(flagClickEvent));
        gridView.Columns.Add(checkColumnListView.process());

        checkColumnListView = new CheckColumnListView("Thu", "ThuWork", BindingMode.TwoWay,20,listView);        
        checkColumnListView.setConverter(new ConstantYesNoToBoolConverterNew(), "");        
        checkColumnListView.setEvent(CheckBox.ClickEvent, new RoutedEventHandler(flagClickEvent));
        gridView.Columns.Add(checkColumnListView.process());

        checkColumnListView = new CheckColumnListView("Fri", "FriWork", BindingMode.TwoWay,20,listView);        
        checkColumnListView.setConverter(new ConstantYesNoToBoolConverterNew(), "");
        checkColumnListView.setEvent(CheckBox.ClickEvent, new RoutedEventHandler(flagClickEvent));
        gridView.Columns.Add(checkColumnListView.process());

        checkColumnListView = new CheckColumnListView("Sat", "SatWork", BindingMode.TwoWay,20,listView);        
        checkColumnListView.setConverter(new ConstantYesNoToBoolConverterNew(), "");
        checkColumnListView.setEvent(CheckBox.ClickEvent, new RoutedEventHandler(flagClickEvent));
        gridView.Columns.Add(checkColumnListView.process());

        checkColumnListView = new CheckColumnListView("Sun", "SunWork", BindingMode.TwoWay,20,listView);        
        checkColumnListView.setConverter(new ConstantYesNoToBoolConverterNew(), "");
        checkColumnListView.setEvent(CheckBox.ClickEvent, new RoutedEventHandler(flagClickEvent));
        gridView.Columns.Add(checkColumnListView.process());
                                                    
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnShiftsGrid Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnLabourGrid(){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        TextColumnListView      textColumnListView= null;
        CheckColumnListView     checkColumnListView = null;
        DateRadColumnListView   dateRadColumnListView = null;        
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                             
        textBlockColumnListView = new TextBlockColumnListView("Labour Id", "LabourTypeId", BindingMode.OneWay,60, labourListView);        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Labour Name", "TaskName", BindingMode.OneWay,180,labourListView);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));        
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        checkColumnListView = new CheckColumnListView("Assigned", "Selected", BindingMode.TwoWay,50, labourListView);
        checkColumnListView.setProperty(CheckBox.FontWeightProperty, FontWeights.Black);
        checkColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(checkColumnListView.process());
                        
        dateRadColumnListView = new DateRadColumnListView("Approv.Date", "ApprovDate", BindingMode.TwoWay,100, labourListView);
        dateRadColumnListView.setProperty(RadDateTimePicker.InputModeProperty,Telerik.Windows.Controls.InputMode.DatePicker);
        dateRadColumnListView.setProperty(RadDateTimePicker.HeightProperty, (double)17);        
        gridView.Columns.Add(dateRadColumnListView.process());
                /*
        RadDatePickerColumnListView radDatePickerColumnListView = new RadDatePickerColumnListView("Approv.Date", "ApprovDate", BindingMode.TwoWay,100, labourListView);
        radDatePickerColumnListView.setProperty(RadDatePicker.InputModeProperty,Telerik.Windows.Controls.InputMode.DatePicker);
        radDatePickerColumnListView.setProperty(RadDatePicker.HeightProperty, (double)17); 
        //radDatePickerColumnListView.setProperty(RadDatePicker.spe, (double)17);                             
        gridView.Columns.Add(radDatePickerColumnListView.process());
        RadDatePicker radDatePicker = new RadDatePicker();
                radDatePicker.calendar .SpecialDays.Add(holiday);
        */                        

        dateRadColumnListView = new DateRadColumnListView("Approv.Until","ApprovUntilDate", BindingMode.TwoWay,100, labourListView);
        dateRadColumnListView.setProperty(RadDateTimePicker.InputModeProperty,Telerik.Windows.Controls.InputMode.DatePicker);
        dateRadColumnListView.setProperty(RadDateTimePicker.HeightProperty, (double)17);
        gridView.Columns.Add(dateRadColumnListView.process());
  
        //employee                
        EmployeeComboColumnListView employeeComboColumnListView = new EmployeeComboColumnListView("Approved By", "ApprovByEmpId", BindingMode.TwoWay, 200, labourListView);
        employeeComboColumnListView.loadValues(getCoreFactory(), ComboDisplayFormat.CodeDescription,"","", "",Constants.STATUS_ACTIVE,0,"",0);                
        employeeComboColumnListView.setProperty(ComboBox.FontWeightProperty, FontWeights.Black);
        employeeComboColumnListView.getColumn().HeaderContainerStyle = cell;
        employeeComboColumnListView.setProperty(ComboBox.MaxDropDownHeightProperty,(double)400);
        gridView.Columns.Add(employeeComboColumnListView.process());  

        textColumnListView = new TextColumnListView("App.Level", "ApprovLevel", BindingMode.TwoWay,60,1,labourListView);                    
        textColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);     
        textColumnListView.setConverter(new DecimalToStringConverterNew(), "int");  
        textColumnListView.setProperty(TextBox.MaxLengthProperty,2);        
        textColumnListView.setProperty(TextBox.MinHeightProperty,(double)10);
        textColumnListView.setProperty(TextBox.HeightProperty, (double)17);
        textColumnListView.setProperty(TextBox.FontSizeProperty,(double)14);
        textColumnListView.setProperty(TextBox.PaddingProperty, new Thickness(0));                           
        gridView.Columns.Add(textColumnListView.process());
      
        labourListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnLabourGrid Exception: " + ex.Message);        
    }
}

public
Employee loadEmployee(ListView listView, ListView shiftlistView,TabControl mainTabControl){
    employee = null;
    try{ 
        Employee                employeeAux = (Employee)getSelected(listView);       
        TabItem                 viewTabItem= (TabItem)mainTabControl.Items[0];
        TabItem                 dtlTabItem = (TabItem)mainTabControl.Items[1];

        if (employeeAux!= null)
            employee = getCoreFactory().readEmployee(employeeAux.Id,true);  //read employee and full childs

        if (employee != null){       
            dtlTabItem.DataContext = null;                    
            dtlTabItem.DataContext = employee;

            loadEmployeeShift();            
            loadLabours();            

            int imachId= employee.DftMachId;
            loadMachinesFromDept(employee.DftDept);
            employee.DftMachId = imachId;

        }else{
            mainTabControl.SelectedItem = viewTabItem;
            MessageBox.Show("Please, Select Employee First.");
        }            

    } catch (Exception ex) {
        MessageBox.Show("loadEmployee Exception: " + ex.Message);        
    }
    return employee;
}

public
void loadEmployeeShift(){    
    try{                         
        EmployeeShiftContainer employeeShiftContainer=null;
        if (employee != null)
            employeeShiftContainer = getCoreFactory().readEmployeeShiftByFilters(employee!= null ? employee.Id :"",0,DateUtil.MinValue,0);                                       
                    
        setDataContextListView(shiftListView,employeeShiftContainer);    

    } catch (Exception ex) {
        MessageBox.Show("loadEmployeeShift Exception: " + ex.Message);        
    }    
}

public
bool save(){
    bool bresult=false;
    try { 
        if (employee!= null){
            reloadLabours(); //check labours selected

            if (getCoreFactory().existsEmployee(employee.Id))
                getCoreFactory().updateEmployee(employee);
            else
                getCoreFactory().writeEmployee(employee);

            bresult=true;
        }
    } catch (Exception ex) {
        MessageBox.Show("save Exception: " + ex.Message);        
    }    
    return bresult;
}


public
void save(EmployeeShift employeeShift){
    try { 
        if (employeeShift != null){
            if (employeeShift.Id > 0)
                getCoreFactory().updateEmployeeShift(employeeShift);
            else
                getCoreFactory().writeEmployeeShift(employeeShift);
        }
    } catch (Exception ex) {
        MessageBox.Show("save EmployeeShift Exception: " + ex.Message);        
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
            EmployeeShift   employeeShift = (EmployeeShift)checkBox.DataContext;    
    
            if (employeeShift != null) {                 
                save(employeeShift);    
            } 
        }

    } catch (Exception ex) {
        MessageBox.Show("flagClickEvent Exception: " + ex.Message);        
    }
}


public
bool delEmplShift(){
    bool bresult=false;
    try{        
        EmployeeShift employeeShift = (EmployeeShift)deleltedSelected(shiftListView);
        if (employeeShift != null) { 
            getCoreFactory().deleteEmployeeShift(employeeShift.Id);
            loadEmployeeShift();
            bresult=true;
        }

    } catch (Exception ex) {
        MessageBox.Show("delEmplShift Exception: " + ex.Message);        
    }
    return bresult;
}

public
bool import(){
    bool bresult=false;
    try{
        getCoreFactory().generateCMSEmployee();
        bresult=true;

    } catch (Exception ex) {
        MessageBox.Show("import Exception: " + ex.Message);        
    }
    return bresult;
}

public
bool assignShift(){
    bool bresult=false;
    try{
        getCoreFactory().cmsCmsNujitEmployeeAssignShift();
        bresult=true;

    } catch (Exception ex) {
        MessageBox.Show("import Exception: " + ex.Message);        
    }
    return bresult;
}

public
void loadLabours(){   
    try{        
        if (employee != null) { 
            CapShiftTaskContainer       capShiftTaskContainer = getCoreFactory().readCapShiftTaskByFilters("","","",0);
            CapShiftTask                capShiftTask=null;
            EmployeeLabourContainer     employeeLabourContainer = getCoreFactory().createEmployeeLabourContainer();
            EmployeeLabourView          employeeLabourView = null;
            EmployeeLabour              employeeLabour = null;


            for (int i=0; i < capShiftTaskContainer.Count; i++){
                capShiftTask = capShiftTaskContainer[i];

                employeeLabourView = getCoreFactory().createEmployeeLabourView();

                employeeLabourView.EmpId        = employee.Id;
                employeeLabourView.LabourTypeId = capShiftTask.Id;
                employeeLabourView.TaskName     = capShiftTask.TaskName;

                employeeLabour = employee.EmployeeLabourContainer.getByLabourTypeId(employeeLabourView.LabourTypeId);
                employeeLabourView.Selected = employeeLabour != null;

                if (employeeLabour!= null){
                    employeeLabourView.ApprovDate       = employeeLabour.ApprovDate;
                    employeeLabourView.ApprovUntilDate  = employeeLabour.ApprovUntilDate;
                    employeeLabourView.ApprovByEmpId    = employeeLabour.ApprovByEmpId;
                    employeeLabourView.ApprovLevel      = employeeLabour.ApprovLevel;
                }

                employeeLabourContainer.Add(employeeLabourView);
            }
            setDataContextListView(labourListView,employeeLabourContainer);
        }

    } catch (Exception ex) {
        MessageBox.Show("loadLabours Exception: " + ex.Message);        
    }
}

public
void reloadLabours(){   
    try{        
        if (employee != null) { 
            EmployeeLabourContainer     employeeLabourContainer = (EmployeeLabourContainer)labourListView.DataContext;
            EmployeeLabourView          employeeLabourView = null;

            employee.EmployeeLabourContainer.Clear();

            for (int i=0; employeeLabourContainer!= null && i < employeeLabourContainer.Count; i++){
                employeeLabourView = (EmployeeLabourView)employeeLabourContainer[i];
                if (employeeLabourView.Selected)
                    employee.EmployeeLabourContainer.Add(employeeLabourView);
                                
            }            
        }

    } catch (Exception ex) {
        MessageBox.Show("reloadLabours Exception: " + ex.Message);        
    }
}

public
void checkIfNeedLoadDftLabourFromDept(ComboBox deptCombo){   
    try{        
        string  sdept = (string)getSelectedComboBoxItem(deptCombo);

        if (employee != null && employee.DftLabourTypeId < 1) {                        
            Departament departament = getCoreFactory().readDepartament(Configuration.DftPlant,sdept);
            if (departament!= null && departament.DftLabTaskId > 0) { 

                CapShiftTask capShiftTask = getCoreFactory().readCapShiftTask(departament.DftLabTaskId);//read labour/task description
                if (capShiftTask!= null && 
                    System.Windows.Forms.MessageBox.Show("Do You Want To Update Labour/Task " + "\n" + "Based On Default Labour Loaded On Department :" + capShiftTask.TaskName + " ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes){
                    employee.DftLabourTypeId = departament.DftLabTaskId;
                    save();
                }
            }
        }

    } catch (Exception ex) {
        MessageBox.Show("checkIfNeedLoadDftLabourFromDept Exception: " + ex.Message);        
    }
}

public
void loadMachinesFromDept(string sdept){   
    try{                
        if (sdept!= null && !sdeptFilter.Equals(sdept)){ 
            sdeptFilter = sdept;
            loadMachineCombo(machComboBox, "",sdept,true);
        }
    } catch (Exception ex) {
        MessageBox.Show("loadMachinesFromDept Exception: " + ex.Message);        
    }
}


}
}
