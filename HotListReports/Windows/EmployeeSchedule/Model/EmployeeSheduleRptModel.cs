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


namespace HotListReports.Windows.EmployeeSchedule{


class EmployeeSheduleRptModel : SheduleRptModel{

public EmployeeSheduleRptModel(Window window,ListView listView,int imaxScrollRows) : base(window,listView,imaxScrollRows){    

}
 
public
void loadColumnsOnListView(ListView listView){
  try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));                                                                         
        cell.Setters.Add(new Setter(Control.FontSizeProperty,(double)30));                                                                         

        textBlockColumnListView = new TextBlockColumnListView("Employee Names", "FullName", BindingMode.OneWay,250, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Emp#", "EmpId", BindingMode.OneWay,90, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Mach#", "Mach", BindingMode.OneWay,90, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());        
                
          
        listView.View = gridView;     

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnListView Exception: " + ex.Message);        
    }
}
 
public
void loadColumnsOnListView2(ListView listView){
  try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));                                                                         

        for (int i=1; i <= 2; i++) { 
            textBlockColumnListView = new TextBlockColumnListView("Employee Names", "FullName"+i.ToString(), BindingMode.OneWay,250, listView);
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            gridView.Columns.Add(textBlockColumnListView.process());

            textBlockColumnListView = new TextBlockColumnListView("Emp#", "EmpId" + i.ToString(), BindingMode.OneWay,90, listView);
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            gridView.Columns.Add(textBlockColumnListView.process());
        
            textBlockColumnListView = new TextBlockColumnListView("Mach#", "Mach" + i.ToString(), BindingMode.OneWay,90, listView);
            textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
            textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
            gridView.Columns.Add(textBlockColumnListView.process());        
        }                
          
        listView.View = gridView;     

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnListView2 Exception: " + ex.Message);        
    }
}

public
void loadColumnsOnListView3(ListView listView,string[][] items){
  try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
        cell.Setters.Add(new Setter(Control.FontSizeProperty,(double)25));                                                                                             

        string[] item = (items!= null && items.Length > 0 ) ? items[0] : new string[3];

        for (int j=0; j < item.Length; j++) {
            textBlockColumnListView = new TextBlockColumnListView("Employee Names", "["+ j.ToString() + "]", BindingMode.OneWay,300, listView);
            adjustFontAndColours(textBlockColumnListView,cell);                 
            gridView.Columns.Add(textBlockColumnListView.process());    
            j++;
            textBlockColumnListView = new TextBlockColumnListView("Emp#", "[" + j.ToString() + "]", BindingMode.OneWay,150, listView);
            adjustFontAndColours(textBlockColumnListView,cell);                 
            gridView.Columns.Add(textBlockColumnListView.process());    
            j++;
            textBlockColumnListView = new TextBlockColumnListView("Mach#", "[" + j.ToString() + "]", BindingMode.OneWay,150, listView);
            adjustFontAndColours2(textBlockColumnListView,cell);                 
            gridView.Columns.Add(textBlockColumnListView.process());        
        }
                        
          
        listView.View = gridView;     

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnListView3 Exception: " + ex.Message);        
    }
}

private
void adjustFontAndColours(TextBlockColumnListView textBlockColumnListView,Style cell){
    textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
    textBlockColumnListView.setProperty(TextBlock.FontSizeProperty,(double)25);
    textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(Colors.DarkBlue));
    textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(Colors.White));
    textBlockColumnListView.getColumn().HeaderContainerStyle = cell;     
}

private
void adjustFontAndColours2(TextBlockColumnListView textBlockColumnListView,Style cell){
    textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
    textBlockColumnListView.setProperty(TextBlock.FontSizeProperty,(double)25);
    textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(Colors.Blue));
    textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(Colors.White));
    textBlockColumnListView.getColumn().HeaderContainerStyle = cell;     
}

public
EmpShiftScheduleReportTransformViewContainer transformEmpShiftScheduleReport(EmpShiftScheduleReportViewContainer empShiftScheduleReportViewContainer){
    EmpShiftScheduleReportTransformViewContainer    empShiftScheduleReportTransformViewContainer = getCoreFactory().createEmpShiftScheduleReportTransformViewContainer();
    try{
        EmpShiftScheduleReportView                      empShiftScheduleReportView=null;
        EmpShiftScheduleReportTransformView             empShiftScheduleReportTransformView= null;

        for (int i=0; i < empShiftScheduleReportViewContainer.Count; i++){
            empShiftScheduleReportView= empShiftScheduleReportViewContainer[i];

            empShiftScheduleReportTransformView   = getCoreFactory().createEmpShiftScheduleReportTransformView();
            empShiftScheduleReportTransformView.EmpShiftScheduleReportView1 = empShiftScheduleReportView;

            i++;
            if (i < empShiftScheduleReportViewContainer.Count){
                empShiftScheduleReportView= empShiftScheduleReportViewContainer[i];
                empShiftScheduleReportTransformView.EmpShiftScheduleReportView2 = empShiftScheduleReportView;
            }
            empShiftScheduleReportTransformViewContainer.Add(empShiftScheduleReportTransformView);
        }

    } catch (Exception ex) {
        MessageBox.Show("transformEmpShiftScheduleReport Exception: " + ex.Message);        
    }
    return empShiftScheduleReportTransformViewContainer;
}

public
string[][] transformEmpShiftScheduleReport2(EmpShiftScheduleReportViewContainer empShiftScheduleReportViewContainer,int imaxCols){    
    string[][]  items=null;
    try{
        EmpShiftScheduleReportView  empShiftScheduleReportView=null;
        string[]                    item=new string[imaxCols*3];
        int                         icount = Convert.ToInt32(empShiftScheduleReportViewContainer.Count / imaxCols) + 1;
        int                         ix=0;
        int                         iy=0;

        if (empShiftScheduleReportViewContainer.Count > 0 && (empShiftScheduleReportViewContainer.Count % imaxCols) == 0)
            icount--; //because exactly value

        items= new string[icount][];
        items[iy] = item;
        initStringVec(item);

        for (int i=0; i < empShiftScheduleReportViewContainer.Count; i++){
            empShiftScheduleReportView= empShiftScheduleReportViewContainer[i];
     
            if (( i % imaxCols) == 0) { 
                ix=0;
                if (i > 0)
                    iy++;
                item=new string[imaxCols*3];
                initStringVec(item);
                items[iy] = item;
            }

            item[ix]= empShiftScheduleReportView.FullName;
            item[ix+1]= empShiftScheduleReportView.EmpId;
            item[ix+2]= empShiftScheduleReportView.Mach;
            ix = ix+3;        
        }

    } catch (Exception ex) {
        MessageBox.Show("transformEmpShiftScheduleReport2 Exception: " + ex.Message);        
    }
    return items;
}

private
void initStringVec(string[] item){
    for (int i=0; item!= null && i < item.Length; i++)
        item[0]="";
}

}
}
