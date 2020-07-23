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

class MachineAlterPlanModel : BaseModel2 {


private ComboBox    alterMachineComboBox;
private ComboBox    weekComboBox;
private PlannedHdr  plannedHdr;
private Machine     mainMachine;
private MachineReportPartView machineReportPartViewOriginal;

public MachineAlterPlanModel(Window window,ComboBox alterMachineComboBox, ComboBox weekComboBox, PlannedHdr plannedHdr,Machine mainMachine, MachineReportPartView machineReportPartViewOriginal) : base(window){    
    this.alterMachineComboBox = alterMachineComboBox;
    this.weekComboBox = weekComboBox;

    this.plannedHdr = plannedHdr;
    this.mainMachine=mainMachine;
    this.machineReportPartViewOriginal = machineReportPartViewOriginal;
}
                
public
void loadRoutingComboBox(ComboBox comboBox,RoutingContainer routingContainer){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();        

        foreach(Routing routing in routingContainer){
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(StringUtil.AddSpaces(routing.Dept,10,true) + " - " + routing.Cfg,routing));
        }
                               
        setDataContextCombo(comboBox,list);        

    } catch (Exception ex) {
        MessageBox.Show("loadRoutingComboBox Exception: " + ex.Message);        
    }
}

public
void loadWeeksComboBox(ComboBox comboBox,MachineReportPartView machineReportPartView){
    try { 
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();
        CellMachinePart cellMachinePart = null;

        for (int i=0; i <= CapacityView.TITLE_COUNTS; i++){
            cellMachinePart = machineReportPartView.getCellMachinePartByXIndex(i);
            if (cellMachinePart!= null)
                list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(StringUtil.AddSpaces("Week" + i.ToString(),8, true) + " - " + DateUtil.getDateRepresentation(cellMachinePart.StartDate,DateUtil.MMDDYYYY).Substring(0,5), cellMachinePart));
        }                 
        setDataContextCombo(comboBox,list);        

    } catch (Exception ex) {
        MessageBox.Show("loadWeeksComboBox Exception: " + ex.Message);        
    }
}

private
bool dataOK(out Machine machineAlternative){
    bool bresult = true;
    machineAlternative = null;
    

    Routing routing = getRoutingSelected();
    if (getSelectedComboBoxItem(alterMachineComboBox) == null){
        MessageBox.Show("Please, Select Machine.");
        bresult = false;
    }            

    if (routing != null) { 
        machineAlternative = getMachineSelected(routing);
        if (machineAlternative == null){
            MessageBox.Show("Sorry, Can Not Find Machine : " + routing.Cfg + ".");
            bresult = false;
        }
    }
    return bresult;
}

public
bool save(PlannedHdr plannedHdr,string splant,MachineReportPartView machineReportPartView, CellMachinePart cellSelected){
    bool    bresult=false;
    try { 
        Machine machineAlternative = null;

        if (dataOK(out machineAlternative)) { 
            PlannedPart     plannedPart = null;
                
            if (machineReportPartView!= null && cellSelected != null && machineAlternative != null){
                plannedPart = getCoreFactory().generateNewPlannedPartBasedPlanned(plannedHdr,splant, machineAlternative.Id,machineReportPartView.Part, machineReportPartView.Seq,cellSelected.PlannedOtherCurrAlter, cellSelected.PlannedOvertime, cellSelected.StartDate,true);        
                if (plannedPart != null) { 
                    bresult=true;
                    if (plannedHdr== null)
                        plannedHdr = getCoreFactory().readPlannedHdrLast(splant);
                }
            }        
        }

    } catch (Exception ex) {
        MessageBox.Show("save Exception: " + ex.Message);        
    }

    return bresult;
}

private
void loadMachineAlternativePlanned(PlannedHdr plannedHdr, MachineReportPartView machineReportPartView){
    PlannedReq              plannedReq= null;
    PlannedPart             plannedPart = null;
    PlannedPartContainer    plannedPartContainer=null;
    bool                    breprocess = true;
    int                     i=0;
    decimal                 dqty=0;
    Routing                 routing = (Routing)getSelectedComboBoxItem(alterMachineComboBox);
    Machine                 machine = null;
    bool                    bfound = false;

    if (routing != null)
        machine = getCoreFactory().readMachine(routing.Plt, routing.Dept, routing.Cfg);

    if (plannedHdr != null && machine != null){
        plannedReq = plannedHdr.PlannedReqContainer.getByRequirment(Constants.TYPE_MACHINE,machine.Id);

        if (plannedReq!= null){
            plannedPartContainer = plannedReq.PlannedPartContainer;                
                                                    
            for (i=0; i < plannedPartContainer.Count;i++)  {          
                plannedPart = plannedPartContainer[i];
                breprocess=false;
                
                if (plannedPart.Part.ToUpper().Equals(machineReportPartView.Part.ToUpper())  && plannedPart.Seq == machineReportPartView.Seq) { 
                    
                    bfound = false;                                    
                    for (int j=0; !bfound && j <= CapacityView.TITLE_COUNTS;j++){ //loop for every week until found (not pastue)
                        CellMachinePart cellMachinePart = machineReportPartView.getCellMachinePartByXIndex(j);
                        if (cellMachinePart!= null) { 
                            if ( j== -1){ 
                                if (plannedPart.StartDate <= cellMachinePart.EndDate) { 
                                    bfound=true;
                                    breprocess = sumCapacityPartCheckIfReprocess(out dqty,cellMachinePart, plannedPart, false);                  
                                }
                            }else if (plannedPart.StartDate >= cellMachinePart.StartDate && plannedPart.StartDate <= cellMachinePart.EndDate){
                                bfound =true;
                                breprocess = sumCapacityPartCheckIfReprocess(out dqty,cellMachinePart, plannedPart, false);
                            }
                        }                
                    }
                                            
                    if (breprocess)
                        i--;
                }
            }
        }
    }
}

private
bool sumCapacityPartCheckIfReprocess(out decimal dqty,CellMachinePart cellMachinePart,PlannedPart plannedPart,bool isPlannedOther=true){
    DateTime    startDate   = cellMachinePart.StartDate;
    DateTime    endDate     = cellMachinePart.EndDate;
    decimal     dminutes    = Convert.ToDecimal((plannedPart.EndDate - plannedPart.StartDate).TotalMinutes);        
    bool        breprocess  = false;
    
    dqty = plannedPart.QtyPlanned;

    if (plannedPart.EndDate > endDate.AddSeconds(1)) { 
        plannedPart.StartDate = endDate.AddSeconds(1); //adjust start date
        decimal dnewMinutes = Convert.ToDecimal((plannedPart.EndDate - plannedPart.StartDate).TotalMinutes);
        decimal dnewQty = dnewMinutes * 100 / (dminutes != 0 ? dminutes : 1);
        
        plannedPart.QtyPlanned = dnewQty;        
        dqty-= dnewQty;
        breprocess = true;
    }

    if (isPlannedOther) { 
       cellMachinePart.PlannedOther+= dqty;    
       cellMachinePart.PlannedPartOtherContainer.Add(plannedPart);
    }else{
       cellMachinePart.PlannedOtherCurrAlter+= dqty;    
       cellMachinePart.PlannedPartOtherContainer.Add(plannedPart);        
    }

    cellMachinePart.StartDate = startDate;
    cellMachinePart.EndDate = endDate;
    return breprocess;
}

private
void loadMachinePartsPlannedOther(MachineReportPartView machineReportPartView, Machine machine,Machine alterMachine,PlannedHdr plannedHdr){
    try{         
        CapacityPartContainer   capacityPartContainer = getCoreFactory().createCapacityPartContainer();
        int                     i=0;
        bool                    breprocess=false;
        decimal                 dqty=0;        
        PlannedPartContainer    plannedPartContainer = null;
        PlannedPart             plannedPart = null;
        string                  skey = "";
        bool                    bfound=false;

        //get all planned qty for other machines
        if (plannedHdr != null && machine != null){
            Hashtable  hashPlanPartsSeq = plannedHdr.groupByPartSeq(machine.Id,Constants.TYPE_MACHINE, alterMachine.Id, Constants.TYPE_MACHINE);
                                                             
            skey = machineReportPartView.Part.ToUpper() + Constants.DEFAULT_SEP + machineReportPartView.Seq.ToString();
            if (hashPlanPartsSeq.Contains(skey)) {

                plannedPartContainer = (PlannedPartContainer)hashPlanPartsSeq[skey];
                for (i=0; i < plannedPartContainer.Count;i++)  {          
                    plannedPart = plannedPartContainer[i];
                    breprocess=false;

                    bfound = false;                                    
                    for (int j=0; !bfound && j <= CapacityView.TITLE_COUNTS;j++){ //loop for every week until found (not pastue)
                        CellMachinePart cellMachinePart = machineReportPartView.getCellMachinePartByXIndex(j);
                        if (cellMachinePart!= null) { 
                            if ( j== -1){ 
                                if (plannedPart.StartDate <= cellMachinePart.EndDate) { 
                                    bfound=true;
                                    breprocess = sumCapacityPartCheckIfReprocess(out dqty,cellMachinePart, plannedPart);                  
                                }
                            }else if (plannedPart.StartDate >= cellMachinePart.StartDate && plannedPart.StartDate <= cellMachinePart.EndDate){
                                bfound =true;
                                breprocess = sumCapacityPartCheckIfReprocess(out dqty,cellMachinePart, plannedPart);
                            }
                        }                
                    }
                                            
                    if (breprocess)
                        i--;                    
                }
            }         
        }


    } catch (Exception ex) {
        MessageBox.Show("loadMachinePartsPlanned Exception: " + ex.Message);        
    }
}

private
Routing getRoutingSelected(){
    return (Routing)getSelectedComboBoxItem(alterMachineComboBox);
}

private
Machine getMachineSelected(Routing routing){
    Machine machineSelected = null;                
    if (routing != null)
        machineSelected = getCoreFactory().readMachine(routing.Plt, routing.Dept, routing.Cfg);
    return machineSelected;
}

public
MachineReportPartView machineChanged(){
    Routing                 routing     = getRoutingSelected();
    Machine                 alterMachine= getMachineSelected(routing);
    MachineReportPartView   machineReportPartView = null;

    if (routing!= null && alterMachine != null) { 
        machineReportPartView = getCoreFactory().cloneMachineReportPartView(machineReportPartViewOriginal);
        machineReportPartView.RunStd = routing.RunStd;

        machineReportPartView.WeekCellPastDue.PlannedOther = 
        machineReportPartView.WeekCell0.PlannedOther = 
        machineReportPartView.WeekCell1.PlannedOther =
        machineReportPartView.WeekCell2.PlannedOther =
        machineReportPartView.WeekCell3.PlannedOther =
        machineReportPartView.WeekCell4.PlannedOther = 
        machineReportPartView.WeekCell5.PlannedOther =
        machineReportPartView.WeekCell6.PlannedOther =
        machineReportPartView.WeekCell7.PlannedOther =
        machineReportPartView.WeekCell8.PlannedOther =
        machineReportPartView.WeekCell9.PlannedOther =
        machineReportPartView.WeekCell10.PlannedOther=
        machineReportPartView.WeekCell11.PlannedOther=
        machineReportPartView.WeekCell12.PlannedOther=
        machineReportPartView.WeekCell13.PlannedOther= 0;                

        loadMachinePartsPlannedOther(machineReportPartView, mainMachine, alterMachine,plannedHdr);
        loadMachineAlternativePlanned(plannedHdr, machineReportPartView);
        machineReportPartView.recalcNet();            

        int iweekSelected= weekComboBox.SelectedIndex;
        loadWeeksComboBox(weekComboBox,machineReportPartView);        
        if (weekComboBox.Items.Count > iweekSelected)
            weekComboBox.SelectedIndex = iweekSelected;
    }
    return machineReportPartView;
}
        
public
void plannedCurrTextBoxSelectionChanged(TextBox plannedCurrTextBox,MachineReportPartView machineReportPartView){
    try{ 
        string          sother = plannedCurrTextBox.Text;
        CellMachinePart cellMachinePart = (CellMachinePart)getSelectedComboBoxItem(this.weekComboBox);
        if (cellMachinePart!= null)
            cellMachinePart.PlannedOtherCurrAlter = NumberUtil.isIntegerNumber(sother) ? Convert.ToInt32(sother) : 0;

        if (machineReportPartView!= null)
            machineReportPartView.recalcNet();

    } catch (Exception ex) {
        MessageBox.Show("plannedCurrTextBoxSelectionChanged Exception: " + ex.Message);        
    }
}

}
}
