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

using Nujit.NujitWms.WinForms.Util.Grids;
using Nujit.NujitWms.WinForms.Util.Converters;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using System.Collections.ObjectModel;
using System.Collections;
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Common;



namespace HotListReports.Windows.Demand{
class CapShiftTaskModel : BaseModel2{
public CapShiftTaskModel(Window window) : base(window){    
}

                
public
void loadSearchByCombo(ComboBox searchByComboBox){
    loadCombo(searchByComboBox, "Id","Task Name");
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

        textBlockColumnListView = new TextBlockColumnListView("Task Name", "TaskName", BindingMode.OneWay, 200, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Dir/Ind", "DirInd", BindingMode.OneWay,50, hdrListView);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("RatePerHr", "RatePerHr", BindingMode.OneWay,60, hdrListView);        
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        textBlockColumnListView.setConverter(new DecimalToStringConverterNew(),"");
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Manufact", "ManufactProcess", BindingMode.OneWay,50, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("EmpTempCanPerf.", "EmpTempCanPerform", BindingMode.OneWay,90, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());
                        
        hdrListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

public 
void add(out CapShiftTask capShiftTask){    
    capShiftTask = coreFactory.createCapShiftTask();        
    try{            
        capShiftTask.DirInd = Constants.TASK_DIRECT;                                                   
    }catch (Exception ex){
        MessageBox.Show("add Exception: " + ex.Message);
    }                       
}

public 
bool del(ListView hdrListView){    
    bool bresult=false;
    try{
        CapShiftTask capShiftTask = (CapShiftTask)deleltedSelected(hdrListView);

        if (capShiftTask != null){
            CapShiftProfileContainer capShiftProfileContainer = coreFactory.readCapShiftProfileByFilters("","",0, "", DateUtil.MinValue, DateUtil.MinValue, capShiftTask.Id,"", true,1);             
            if (capShiftProfileContainer.Count > 0)
                 MessageBox.Show("Sorry, Can Not Delete Capacity Shift Task , Already In Use On Capacity Profile :" + capShiftProfileContainer[0].Id + ".");
            else{ 
                coreFactory.deleteCapShiftTask(capShiftTask.Id);
                bresult=true;                                  
            }
        }
            
    }catch (Exception ex){
        MessageBox.Show("del Exception: " + ex.Message);
    }      
    return bresult;                              
}

public 
bool dataOK(CapShiftTask capShiftTask, TextBox taskNameTextBox,ComboBox dirIndDtlComboBox){    
    bool bresult=true;
    
    capShiftTask.TaskName = taskNameTextBox.Text; 
    if (string.IsNullOrEmpty(capShiftTask.TaskName)){
        MessageBox.Show("Please, Enter Task Name.");
        taskNameTextBox.Focus();
        bresult=false;
    }

    capShiftTask.DirInd = dirIndDtlComboBox.SelectedItem != null ? ((Nujit.NujitWms.WinForms.Util.ComboBoxItem)dirIndDtlComboBox.SelectedItem).Content.ToString() : "";
    if (string.IsNullOrEmpty(capShiftTask.DirInd)){
        MessageBox.Show("Please, Enter Direct/Indirect.");
        dirIndDtlComboBox.Focus();
        bresult=false;
    }

    return bresult;
} 

public 
bool save(CapShiftTask capShiftTask, TextBox taskNameTextBox,ComboBox dirIndDtlComboBox){    
    bool bresult=false;
    try{        
        if (dataOK(capShiftTask, taskNameTextBox, dirIndDtlComboBox)){
            //MessageBox.Show("ID:" + capShiftTask.Id + "\n Task Name:" + capShiftTask.TaskName + "\nDirInd:"+ capShiftTask.DirInd);

            if (capShiftTask.Id > 0)
                coreFactory.updateCapShiftTask(capShiftTask);
            else
                coreFactory.writeCapShiftTask(capShiftTask);      

            MessageBox.Show("Capacity Task Saved Properly.");
            bresult=true;                                     
        }                           
    }catch (Exception ex){
        MessageBox.Show("save Exception: " + ex.Message);
    }       
    return bresult;                            
}          


}
}
