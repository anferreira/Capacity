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
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;


namespace HotListReports.Windows.Employees{
/// <summary>
/// Interaction logic for EmployeeWindow.xaml
/// </summary>
public partial 
class EmployeeWindow : Window{

private EmployeeModel model;
private int itabIndex;
private int itabDtlIndex;
private bool bmodeSelect;
private int ishiftFilter;

public EmployeeWindow(bool bmodeSelect=false,int ishiftFilter=0){
    InitializeComponent();

    this.bmodeSelect = bmodeSelect;
    this.ishiftFilter= ishiftFilter;

    model = new EmployeeModel(this,hdrListView, shiftListView,labourListView,deptComboBox,machComboBox);    
    itabIndex = itabDtlIndex =0;
}


private 
void Window_Loaded(object sender, RoutedEventArgs e){    
    initialize();
}

      
public
Employee getSelected(){    
    return (Employee)model.getSelected(this.hdrListView); 
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
            
            if (indexSel == 0)
                search();
            else  if (indexSel == 1)
                loadEmployee();
        }                 
    } catch (Exception ex) {
        MessageBox.Show("mainTabControlSelectionChanged error:" + ex.Message);
    }    
}

private 
void hdrListView_MouseDoubleClick(object sender, MouseButtonEventArgs e){
    if (bmodeSelect) { 
        this.DialogResult = true;
        Close();
    }else
        mainTabControl.SelectedItem = detailTabItem;
}

private 
void initialize(){        
    try {                
        deptComboBox.SelectionChanged-= deptComboBox_SelectionChanged;

        model.addButtonsListViewFunctions(this.hdrListView,     firstButton,prevButton,nextButton,lastButton);
        model.addButtonsListViewFunctions(this.shiftListView,   firstSButton,prevSButton,nextSButton,lastSButton);
        model.addButtonsListViewFunctions(this.labourListView,  firstLButton,prevLButton,nextLButton,lastLButton);
                
        this.recordsTextBox.Text = Configuration.SearchDefaultMaxRecords;        
        model.Cursor = this.Cursor;

        model.loadColumnsOnHeaderGrid(hdrListView);
        model.loadColumnsOnShiftsGrid(shiftListView);
        model.loadColumnsOnLabourGrid();
        model.loadSearchByCombo(searchByComboBox);          
        model.loadStatusComboBox(stsComboBox,true);model.setSelectedComboBoxItem(stsComboBox,Constants.STATUS_ACTIVE);
        model.loadDeptCombo(deptFilterComboBox,"","");
        model.loadDeptCombo(deptComboBox,"","",false);
                
        model.loadShiftTaskComboBox(dftLabourFilterComboBox,true);  
        model.loadShiftTaskComboBox(dftLabourComboBox,false);  

        model.loadShiftNumComboBox(assignShiftFComboBox,Constants.MAX_SHIFTS,true);
        model.setSelectedComboBoxItem(assignShiftFComboBox,ishiftFilter.ToString());
        
        model.loadShiftNumComboBox(assignShiftComboBox,Constants.MAX_SHIFTS,false);
        model.loadShiftNumComboBox(assignOTShiftComboBox, Constants.MAX_SHIFTS,false);   
        
        model.screenFullArea();
        search();    

    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    } finally{ 
        deptComboBox.SelectionChanged+= deptComboBox_SelectionChanged;
    }
}

private 
void searchButton_Click(object sender, RoutedEventArgs e){
    search();
}

private 
void search(){
    try{ 
        int         irows           = model.getRecords(recordsTextBox);
        string      sid             = model.getSearchFromComboBoxString(searchByComboBox,searchForTextBox,0);
        string      sfirsName       = model.getSearchFromComboBoxString(searchByComboBox,searchForTextBox,1);
        string      slastName       = model.getSearchFromComboBoxString(searchByComboBox,searchForTextBox,2);
        string      status          = (string)model.getSelectedComboBoxItem(stsComboBox);
        string      sassignShift    = (string)model.getSelectedComboBoxItem(assignShiftFComboBox);
        int         iassignShift    = string.IsNullOrEmpty(sassignShift) ? 0 : Convert.ToInt32(sassignShift);
        string      sdept           = (string)model.getSelectedComboBoxItem(deptFilterComboBox);            
        int         idftLabour      = model.getSelectedComboBoxItemStringToInt(dftLabourFilterComboBox);

        EmployeeContainer employeeContainer = model.getCoreFactory().readEmployeeByFilters(sid,sfirsName,slastName, status, iassignShift, sdept,idftLabour,false,false,irows);
        model.setDataContextListView(hdrListView,employeeContainer);
        model.setSelected(hdrListView, model.Employee);

        searchForTextBox.Focus();

    } catch (Exception ex) {
        MessageBox.Show("search Exception: " + ex.Message);        
    }
                   
}

private 
void loadEmployee(Employee employee){
    try{
        this.detailTabItem.DataContext = null;                
        this.detailTabItem.DataContext = employee;            

        EmployeeShiftContainer employeeShiftContainer = model.getCoreFactory().readEmployeeShiftByFilters(employee!= null ? employee.Id :"",0,DateUtil.MinValue,0);
        model.setDataContextListView(shiftListView, employeeShiftContainer);                    

    } catch (Exception ex) {
        MessageBox.Show("loadEmployee Exception: " + ex.Message);        
    }
                   
}

private 
void okButton_Click(object sender, RoutedEventArgs e){
    save();
}

private
bool dataOk(){
    bool bresult=true;       
    return bresult;
}

private 
void save(){
     try{
        if (dataOk()){
            if (model.save())
                mainTabControl.SelectedItem = hdrTabItem;    
        }
    } catch (Exception ex) {
        MessageBox.Show("save Exception: " + ex.Message);        
    }
       
}

private 
void cancelButton_Click(object sender, RoutedEventArgs e){
    cancel();
}

private 
void cancel(){
    if (model.cancel())
        mainTabControl.SelectedItem = hdrTabItem;    
}

private 
void addSButton_Click(object sender, RoutedEventArgs e){
    
}

private 
void delSButton_Click(object sender, RoutedEventArgs e){
    model.delEmplShift();
}

private 
void importButton_Click(object sender, RoutedEventArgs e){
    import();
}

private 
void import(){
    if (model.import()) { 
        search();
        MessageBox.Show("Import Done, Information Was Refreshed.");
    }
}

private 
void assignShiftButton_Click(object sender, RoutedEventArgs e){
    assignShift();
}

private 
void assignShift(){
    if (model.assignShift()) { 
        search();
        MessageBox.Show("Assign Shift Done, Information Was Refreshed.");
    }
}

private 
void detailsTabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e){
    detailsTabControlSelectionChanged();
}

private 
void detailsTabControlSelectionChanged(){    
    try {
        int indexSel    = detailsTabControl.SelectedIndex;
        int ipriorIndex = itabDtlIndex;
                
        if (indexSel != itabIndex){
            this.itabDtlIndex = indexSel;                                                   
                       
        }        
         
    } catch (Exception ex) {
        MessageBox.Show("detailsTabControlSelectionChanged error:" + ex.Message);
    }    
}

private 
void deptComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e){
    deptComboBoxSelectionChanged();
}

private 
void deptComboBoxSelectionChanged(){
 try {
        string  sdept = (string)model.getSelectedComboBoxItem(deptComboBox);
        model.checkIfNeedLoadDftLabourFromDept(deptComboBox);
        model.loadMachinesFromDept(sdept);

    } catch (Exception ex) {
        MessageBox.Show("deptComboBoxSelectionChanged error:" + ex.Message);
    }  
}

private 
void loadEmployee(){
    try {
        deptComboBox.SelectionChanged-= deptComboBox_SelectionChanged;
        model.loadEmployee(hdrListView,shiftListView,mainTabControl);

    } catch (Exception ex) {
        MessageBox.Show("loadEmployee error:" + ex.Message);
    } finally{ 
        deptComboBox.SelectionChanged+= deptComboBox_SelectionChanged;
    }
}



}
}
