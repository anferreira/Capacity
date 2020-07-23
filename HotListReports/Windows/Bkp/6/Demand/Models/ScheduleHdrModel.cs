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
using Nujit.NujitERP.ClassLib.Core.Machines;


namespace HotListReports.Windows.Demand{
class ScheduleHdrModel : BaseModel2{

public ScheduleHdrModel(Window window) : base(window){    
}


public
void loadSearchByCombo(ComboBox searchByComboBox){
    loadCombo(searchByComboBox,"Id","Status");
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
void loadReqTypes(ComboBox comboBox){
    try {         
        ObservableCollection <Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        
            
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Labour", CapacityReq.REQUIREMENT_LABOUR));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Machine", CapacityReq.REQUIREMENT_MACHINE));
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Task", CapacityReq.REQUIREMENT_TASK));                    
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem("Tool", CapacityReq.REQUIREMENT_TOOL));                    
                       
        comboBox.ItemsSource = list;
        
    } catch (Exception ex) {
        MessageBox.Show("loadShiftTaskComboBox Exception: " + ex.Message);        
    }
}

public 
void save(ScheduleHdr scheduleHdr){    
    try{
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
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Date Created", "DateCreated", BindingMode.OneWay, 70, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Status", "Status", BindingMode.OneWay, 50, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());
                        
        hdrListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

public        
void loadColumnsOnPartGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                          
        textBlockColumnListView = new TextBlockColumnListView("Dtl#", "Detail", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Part", "Part", BindingMode.OneWay,120, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("IsFam", "IsFamily", BindingMode.OneWay,30, listView);
        gridView.Columns.Add(textBlockColumnListView.process());
                                
        textBlockColumnListView = new TextBlockColumnListView("Seq", "Seq", BindingMode.OneWay,20, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Qty", "Qty", BindingMode.OneWay,30, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 

        textBlockColumnListView = new TextBlockColumnListView("StartDate", "StartDate", BindingMode.OneWay, 65, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("EndDate", "EndDate", BindingMode.OneWay, 65, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Shift", "StartShift", BindingMode.OneWay,30, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
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
                                
        textBlockColumnListView = new TextBlockColumnListView("SubDtl#", "SubDetail", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Part", "Part", BindingMode.OneWay,120, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
                
        textBlockColumnListView = new TextBlockColumnListView("Seq", "Seq", BindingMode.OneWay,30, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 
        
        textBlockColumnListView = new TextBlockColumnListView("Qty", "Qty", BindingMode.OneWay, 50, listView);
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
void loadColumnsOnTaskGrid(ListView listView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                          
        textBlockColumnListView = new TextBlockColumnListView("Dtl#", "Detail", BindingMode.OneWay,40, listView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("StartDate", "StartDate", BindingMode.OneWay, 65, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("EndDate", "EndDate", BindingMode.OneWay, 65, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "Date");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Shift", "StartShift", BindingMode.OneWay,30, listView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "int");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 
                                                
        listView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnTaskGrid Exception: " + ex.Message);        
    }
}
public        
void loadColumnsOnRequirementGrid(ListView reqlListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));
                                                                          
        textBlockColumnListView = new TextBlockColumnListView("Sub#", "SubDetail", BindingMode.OneWay,20, reqlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Type", "TypeDesc", BindingMode.OneWay,50, reqlListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("ReqID", "ReqID", BindingMode.OneWay,50, reqlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Description", "ReqDescription", BindingMode.OneWay,70, reqlListView);        
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Time", "Time", BindingMode.OneWay,50, reqlListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process()); 

        textBlockColumnListView = new TextBlockColumnListView("Hours", "Hours", BindingMode.OneWay,50, reqlListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());                 
                                                
        textBlockColumnListView = new TextBlockColumnListView("TotEmploy.", "TotEmployees", BindingMode.OneWay,60, reqlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Employ.Hrs", "EmployeeHours", BindingMode.OneWay,60, reqlListView);
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        gridView.Columns.Add(textBlockColumnListView.process());

        reqlListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnRequirementGrid Exception: " + ex.Message);        
    }
}

public 
void add(out ScheduleHdr scheduleHdr){    
    scheduleHdr = coreFactory.createScheduleHdr();        
    try{            
       
    }catch (Exception ex){
        MessageBox.Show("add Exception: " + ex.Message);
    }                       
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
void partSearch(TextBox partTextBox,SchedulePart schedulePart){        
    try{            
        ProductWindow productWindow = new ProductWindow();
        if ((bool)productWindow.ShowDialog()) {        
            Product product = productWindow.getSelected();
            if (product!=null){
                schedulePart.SchedulePartDtlContainer.Clear(); //empty just in case, already filled

                schedulePart.Part =
                partTextBox.Text = product.ProdID;

                schedulePart.IsFamily = product.FamProd;
                schedulePart.Seq = product.SeqLast;
                if (schedulePart.IsFamily.Equals("F")) //if is family
                    addFamilyChildParts(schedulePart);
            }
        }
       
    }catch (Exception ex){
        MessageBox.Show("partSearch Exception: " + ex.Message);
    }                       
}

private
void addFamilyChildParts(SchedulePart schedulePart){         
    string[][] forSeek = coreFactory.getComponentsFromFamily(schedulePart.Part);
    SchedulePartDtl schedulePartDtl=null;

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
        MessageBox.Show("Part." + schedulePartDtl.Part + "\n Seq." + schedulePartDtl.Seq + "\n Qty." + schedulePartDtl.Qty.ToString("0.00"));
    }
}
        /*
public
void deleteSchedulePart(ScheduleHdr scheduleHdr,ListView listView){ 
    try{ 
        SchedulePart schedulePart = (SchedulePart)deleltedSelected(listView); 
        if (schedulePart!=null){
            scheduleHdr.SchedulePartContainer.Remove(schedulePart);          
            scheduleHdr.fillRedundances();
        }
    }catch (Exception ex){
        MessageBox.Show("deleteSchedulePart Exception: " + ex.Message);
    }    
}

public
void deleteScheduleTask(ScheduleHdr scheduleHdr,ListView listView){ 
    try{ 
        ScheduleTask scheduleTask = (ScheduleTask)deleltedSelected(listView); 
        if (scheduleTask != null){
            scheduleHdr.ScheduleTaskContainer.Remove(scheduleTask);          
            scheduleHdr.fillRedundances();
        }

    }catch (Exception ex){
        MessageBox.Show("deleteScheduleTask Exception: " + ex.Message);
    } 
}
*/
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
        /*
public
void loadRequirmentGrid(SchedulePart schedulePart, ListView listView){ 
    try{ 
        ScheduleReqContainer    scheduleReqContainer = getCoreFactory().createScheduleReqContainer();
    
        if (schedulePart!=null)
            scheduleReqContainer = schedulePart.ScheduleReqContainer;
    
        loadRequirmentGrid(listView,scheduleReqContainer);    

    }catch (Exception ex){
        MessageBox.Show("loadRequirmentGrid Exception: " + ex.Message);
    } 
}*/

/*
public
void loadRequirmentGrid(ScheduleTask scheduleTask, ListView listView){ 
    try{
        ScheduleReqContainer    scheduleReqContainer = getCoreFactory().createScheduleReqContainer();
    
        if (scheduleTask != null)
            scheduleReqContainer = scheduleTask.ScheduleReqContainer;
    
        loadRequirmentGrid(listView,scheduleReqContainer);  
    
    }catch (Exception ex){
        MessageBox.Show("loadRequirmentGrid Exception: " + ex.Message);
    }                           
}*/

public
void loadRequirmentGrid(ListView listView,ScheduleReqViewContainer scheduleReqViewContainer){
    try{
        listView.DataContext = scheduleReqViewContainer;
        listView.ItemsSource = scheduleReqViewContainer; 
        if (listView.Items.Count > 0)
            listView.SelectedIndex = 0;

    }catch (Exception ex){
        MessageBox.Show("loadRequirmentGrid Exception: " + ex.Message);
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
    

}
}
