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
using Nujit.NujitERP.ClassLib.Core.Planned;


namespace HotListReports.Windows.Machines{

class MachineModel : ReportTypeViewsModel {

private MachineViewsModel   machineViewsModel;
private ListView            hdrListView;

public 
MachineModel(Window window,ListView hdrListView) : base(window){    
    this.hdrListView= hdrListView;
    this.machineViewsModel = new MachineViewsModel(window);
}
                
public
void loadColumnsOnHeaderGrid(ListView hdrListView){
    try {
        GridView                gridView = new GridView();
        TextBlockColumnListView textBlockColumnListView = null;
        TextColumnListView      textColumnListView = null;
        Style                   cell = new Style(typeof(GridViewColumnHeader));
        cell.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));

        Style                   cell2 = new Style(typeof(GridViewColumnHeader));
        cell2.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Black));  
        cell2.Setters.Add(new Setter(Control.BackgroundProperty, new SolidColorBrush(UIColors.COLOR_SELECT)));

        textBlockColumnListView = new TextBlockColumnListView("Id", "Id", BindingMode.OneWay,35, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Plt", "Plt", BindingMode.OneWay,50, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Dept", "Dept", BindingMode.OneWay,50, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Machine", "Mach", BindingMode.OneWay,80, hdrListView);                
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;        
        textBlockColumnListView.setProperty(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Description 1", "Des1", BindingMode.OneWay,200, hdrListView);
        textBlockColumnListView.setProperty(TextBlock.FontWeightProperty, FontWeights.Black);
        textBlockColumnListView.getColumn().HeaderContainerStyle = cell;                
        gridView.Columns.Add(textBlockColumnListView.process());
                
        textColumnListView = new TextColumnListView("Priority", "Priority", BindingMode.TwoWay,40, hdrListView);
        textColumnListView.setProperty(TextBox.HorizontalAlignmentProperty, HorizontalAlignment.Right);
        textColumnListView.setProperty(TextBox.TextAlignmentProperty, TextAlignment.Right);        
        textColumnListView.setProperty(TextBox.MaxLengthProperty,6);
        textColumnListView.setProperty(TextBox.MinHeightProperty,(double)10);
        textColumnListView.setProperty(TextBox.HeightProperty, (double)17);
        textColumnListView.setProperty(TextBox.FontSizeProperty,(double)14);
        textColumnListView.setProperty(TextBox.PaddingProperty, new Thickness(0));                
        textColumnListView.setConverter(new DecimalToStringConverterNew(),"int");    
        textColumnListView.setEvent(TextBox.LostFocusEvent, new RoutedEventHandler(priorityTextBoxLostFocus));
        gridView.Columns.Add(textColumnListView.process());
        
        textBlockColumnListView = new TextBlockColumnListView("Shifts Remains" + "\n" + "This Week", "RemainsShifts", BindingMode.OneWay,70, hdrListView);                
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Shifts Available" + "\n" + "This Week", "AvailableShifts", BindingMode.OneWay,70, hdrListView);                
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Curr.Job","CurrentJob", BindingMode.OneWay,60,hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Next Job","NextJob", BindingMode.OneWay,60,hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Sched","Scheduled", BindingMode.OneWay,30, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());

        textBlockColumnListView = new TextBlockColumnListView("Last Planned", "DateLastPlanned", BindingMode.OneWay,110, hdrListView);        
        textBlockColumnListView.setConverter(new DateTimeToStringConverter(), "DateTimeMinValue");
        gridView.Columns.Add(textBlockColumnListView.process());       

        textBlockColumnListView = new TextBlockColumnListView("HrsPerShift", "DirectHoursToShifts", BindingMode.OneWay,50, hdrListView);        
        textBlockColumnListView.setConverter(new DecimalToStringConverter(), "");
        textBlockColumnListView.setProperty(TextBlock.TextAlignmentProperty, TextAlignment.Right);
        gridView.Columns.Add(textBlockColumnListView.process());
                
        textBlockColumnListView = new TextBlockColumnListView("MachType", "MachTyp", BindingMode.OneWay,70, hdrListView);        
        gridView.Columns.Add(textBlockColumnListView.process());                        
    
        hdrListView.View = gridView;        

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

private 
void priorityTextBoxLostFocus(object sender, RoutedEventArgs e){
    priorityTextBoxLostFocus((TextBox)sender);    
}

private 
void priorityTextBoxLostFocus(TextBox textBox){
    try { 
        MachineView machineView= (MachineView)textBox.DataContext;
        if (machineView != null && getCoreFactory()!= null){
            capacityHdr = getCoreFactory().readCapacityHdrLastDateCheck(capacityHdr,getPlant());

            if (capacityHdr!= null){
                CapacityMachPriority capacityMachPriority = capacityHdr.CapacityMachPriorityContainer.getByMachine(machineView.Id);

                if (capacityMachPriority == null){
                    capacityMachPriority = getCoreFactory().createCapacityMachPriority();
                    capacityMachPriority.MachineId = machineView.Id;
                    if (machineView.RemainsShifts > 0)
                        capacityMachPriority.Planned = Constants.STRING_YES;
                    capacityHdr.CapacityMachPriorityContainer.Add(capacityMachPriority);
                }

                if (capacityMachPriority.Priority != machineView.Priority){
                    capacityMachPriority.Priority = machineView.Priority;
                    capacityHdr.CapacityMachPriorityContainer.adjustPriorities(capacityMachPriority);
                    getCoreFactory().updateCapacityHdrOnlyMachinePriority(capacityHdr);
                    
                    reloadMachPriorities(machineView);
                }                
            }
        }

    } catch (Exception ex) {
        MessageBox.Show("loadColumnsOnHeaderGrid Exception: " + ex.Message);        
    }
}

private 
void reloadMachPriorities(MachineView machineViewSelected){
    try { 
        MachineContainer        machineContainer = (MachineContainer)hdrListView.DataContext;
        CapacityMachPriority    capacityMachPriority = null;
        MachineContainer        machineContainerNew = getCoreFactory().createMachineContainer();
        
        if (capacityHdr!= null && machineContainer!=null){
        
            for (int i=0; i < machineContainer.Count; i++){
                MachineView machineView = (MachineView)machineContainer[i];
            
                capacityMachPriority = capacityHdr.CapacityMachPriorityContainer.getByMachine(machineView.Id);
                if (capacityMachPriority!= null)
                    machineView.Priority= capacityMachPriority.Priority;

                machineContainerNew.Add(machineView);
            }
                        
            setDataContextListView(hdrListView,machineContainerNew);
            setSelected(hdrListView,machineViewSelected);
        }

    } catch (Exception ex) {
        MessageBox.Show("reloadMachPriorities Exception: " + ex.Message);        
    }
}


public
Machine loadDefaults(ListView hdrListView,TabControl mainTabControl,GroupBox machineTopGroupBox){
    Machine machine = null;
    try{ 
        Machine machineSel = (Machine)getSelected(hdrListView);       
        TabItem hdrTabItem = (TabItem)mainTabControl.Items[0];
        TabItem defaultTabItem = (TabItem)mainTabControl.Items[1];
                        
        if (machineSel!= null){
            machine = getCoreFactory().readMachineById(machineSel.Id);
        
            if (machine!= null){
                machineTopGroupBox.DataContext  = 
                defaultTabItem.DataContext      = null;
                
                if (machine.MachineDef == null){
                    machine.MachineDef = getCoreFactory().createMachineDef();
                    machine.MachineDef.MachId = machine.Id;
                    machine.MachineDef.DirectHoursToShifts = machine.DirectHoursToShifts;
                }
                machine.MachineDef.MachShow = machine.Mach;
                machine.MachineDef.MachDes1Show = machine.Des1;

                machineTopGroupBox.DataContext = machine;
                defaultTabItem.DataContext = machine.MachineDef;

            }else{
                mainTabControl.SelectedItem = hdrTabItem;
                MessageBox.Show("Sorry, Can Not Find Machine :" + machineSel.Mach + ".");
            }
        }else{
            mainTabControl.SelectedItem = hdrTabItem;
            MessageBox.Show("Please, Select Item Machine First.");
        }            

    } catch (Exception ex) {
        MessageBox.Show("loadDefaults Exception: " + ex.Message);        
    }
    return machine;
}

public
bool autoPlan(){
    bool bresult=false;
    try{        
        ArrayList   arrayMachines = getSelecteds(hdrListView);          

        if (arrayMachines.Count > 0){
            
            if (System.Windows.Forms.MessageBox.Show("Do You Want To Process Auto Planned For Machine/s Selected (" + arrayMachines.Count + ") ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes){                                

                cursorWait();
                machineViewsModel.processAutoPlanForMachines(arrayMachines);                
                plannedHdr = machineViewsModel.PlannedHdr;
                bresult =true;
                cursorNormal();

                MessageBox.Show("Auto Planned Processed For Machine/s" + ".");
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
