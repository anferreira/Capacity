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
using Nujit.NujitERP.ClassLib.Core.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using System.Windows.Threading;
using HotListReports.Windows.Util;

namespace HotListReports.Windows.EmployeeSchedule{
/// <summary>
/// Interaction logic for EmployeeSheduleRptWindow.xaml
/// </summary>
public partial 
class EmployeeSheduleRptWindow : Window{

public const int MAX_SCROLL_ROWS=10;

private EmployeeSheduleRptModel     model;

public 
EmployeeSheduleRptWindow(){
    InitializeComponent();

    model = new EmployeeSheduleRptModel(this,empSheduleListView,MAX_SCROLL_ROWS);    
}

private 
void Window_Loaded(object sender, RoutedEventArgs e){
    initialize();
}

private 
void initialize(){
    try{
        model.addButtonsListViewFunctions(this.empSheduleListView,firstButton,prevButton,nextButton,lastButton);
        model.loadPlantCombo(plantFilterComboBox,false);
        model.setSelectedComboBoxItem(plantFilterComboBox,Configuration.DftPlant);

        model.loadShiftNumComboBox(shiftNumFilterComboBox,Constants.MAX_SHIFTS,true);
        model.setSelectedComboBoxItem(shiftNumFilterComboBox,"");

        datePicker.SelectedDate = DateTime.Now;

        model.loadColumnsOnListView2(empSheduleListView);        
        model.screenFullArea();
        search();
        
    } catch (Exception ex) {
        MessageBox.Show("initialize Exception: " + ex.Message);        
    }
}

private 
void plantFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e){    
    model.plantComboBoxSelectionChanged(plantFilterComboBox, deptFilterComboBox);
}

private 
void searchButton_Click(object sender, RoutedEventArgs e){
    search();
}

private
void search(){            
    try{
        model.stopTimer();

        string      splant  = model.getSelectedComboBoxItemString(plantFilterComboBox); 
        string      sdept   = model.getSelectedComboBoxItemString(deptFilterComboBox); 
        DateTime    date    = model.getSelectedDateTime(datePicker);
        int         ishift  = model.getSelectedComboBoxItemStringToInt(shiftNumFilterComboBox);
        DateTime    fromDate= date;
        DateTime    toDate  = date;
        int         imaxCols= Convert.ToInt32(this.Width / 600); //calculate max 'employee values' could appear        

        if (imaxCols <=0)
            imaxCols=1;

        if (date == DateUtil.MinValue)
            datePicker.SelectedDate = date = DateTime.Now;

        fromDate= new DateTime(date.Year, date.Month, date.Day,0,0,0);
        toDate  = new DateTime(date.Year, date.Month, date.Day,23,59,59);
                
        EmpShiftScheduleReportViewContainer empShiftScheduleReportViewContainer = 
        model.getCoreFactory().readEmpShiftScheduleReportViewByFilters(splant,sdept,fromDate,toDate,ishift, 0);        

        string[][]items=model.transformEmpShiftScheduleReport2(empShiftScheduleReportViewContainer,imaxCols);
        model.loadColumnsOnListView3(empSheduleListView,items);

        model.ObjectCollection = empShiftScheduleReportViewContainer.Count > 0 ? items : null;        
        model.loadListView(model.ObjectCollection);

    }catch (Exception ex){
        MessageBox.Show("search Exception: " + ex.Message);
    }finally{        
        model.startScroll();
    }              
}        

}
}
