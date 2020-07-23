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
using Nujit.NujitERP.ClassLib.Core.Machines;
using HotListReports.Windows.Machines;

namespace HotListReports.Windows.Location{


class DepartmentModel : BaseModel2 {

private MachineViewsModel machineViewsModel;

public DepartmentModel(Window window) : base(window){    
    machineViewsModel = new MachineViewsModel(window);
}


public
void loadColumnsOnHeaderGrid(ListView hdrListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));

        Style                   cell2 = new Style(typeof(GridViewColumnHeader));
        cell2.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));  
        cell2.Setters.Add(new Setter(Control.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT)));
        
        textBlockColumnListView = new TextBlockColumnListView("Plt", "Plt", BindingMode.OneWay,85, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Dept", "Dept", BindingMode.OneWay,85, hdrListView);        
        textBlockColumnListView.setProperty(TextBlock.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT));
        textBlockColumnListView.setProperty(TextBlock.ForegroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT_FONT));
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Description 1", "Des1", BindingMode.OneWay,250, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("DftLabTask", "DftLabTaskId", BindingMode.OneWay,60, hdrListView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "intNot0");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Lab.Task Name", "TaskNameShow", BindingMode.OneWay,180,hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("NonScheduledDT", "NonScheduledDT", BindingMode.OneWay,80, hdrListView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
        
        hdrListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}
           
public
bool save(Departament departament){
    bool bresult=false;
    try{        
        if (dataOK(departament)){            
            coreFactory.updateDepartament(departament);            
            MessageBox.Show("Department Saved Properly.");
            bresult=true;                                     
        }                           
    }catch (Exception ex){
        MessageBox.Show("save Exception: " + ex.Message);
    }       
    return bresult;     
}

public
bool dataOK(Departament departament){
    bool bresult=true;
    try{        
        
    }catch (Exception ex){
        MessageBox.Show("dataOK Exception: " + ex.Message);
    }       
    return bresult;     
}


public
bool autoPlan(ListView listView){
    bool bresult=true;
    try{        
        Departament departament = (Departament)getSelected(listView);

        if (departament!= null){
            if (System.Windows.Forms.MessageBox.Show("Do You Want To Process Auto Planned For Department " + departament.Plt+"//" + departament.Dept + " ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes){                

                MachineContainer machineContainer = machineViewsModel.processAutoPlanForDept(departament.Plt,departament.Dept);
                MessageBox.Show("Total Machines Auto Planned : " + machineContainer.Count + ".");
            }
        }else
            MessageBox.Show("Please, Select Item First.");
            
    }catch (Exception ex){
        MessageBox.Show("autoPlan Exception: " + ex.Message);
    }finally{
        cursorNormal();
    }  
    return bresult;     
}


}
}
