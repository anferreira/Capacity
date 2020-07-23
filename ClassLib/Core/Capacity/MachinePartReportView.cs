/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////


using System;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class MachineReportPartView : MachineReportView {

private string part;
private int seq;
private int seqLast;
private decimal qoh;
private decimal runStd;
private decimal daysOnHand;

private decimal startWeekPlanned;
private decimal production;
private decimal remaintWeekPlanned;

private CellMachinePart weekCellPastDue;
private CellMachinePart weekCell0;
private CellMachinePart weekCell1;
private CellMachinePart weekCell2;
private CellMachinePart weekCell3;
private CellMachinePart weekCell4;
private CellMachinePart weekCell5;
private CellMachinePart weekCell6;
private CellMachinePart weekCell7;
private CellMachinePart weekCell8;
private CellMachinePart weekCell9;
private CellMachinePart weekCell10;
private CellMachinePart weekCell11;
private CellMachinePart weekCell12;
private CellMachinePart weekCell13;

private InventoryObjectivePartDtlContainer inventoryObjectivePartDtlContainer;

private CellTitles cellTitles;
private CellTitles cellTitles2;

public
MachineReportPartView(): base(){        
    this.part = "";
    this.seq = 0;
    this.seqLast = 0;
    this.qoh = 0;
    this.runStd =0;
    this.daysOnHand =0;

    this.startWeekPlanned = 1;
    this.production = 20;
    this.remaintWeekPlanned = 3;
    
    this.inventoryObjectivePartDtlContainer = new InventoryObjectivePartDtlContainer();

    this.weekCellPastDue = new CellMachinePart(); weekCellPastDue.XIndex=-1;
    this.weekCell0 = new CellMachinePart();weekCell0.XIndex=0;
    this.weekCell1 = new CellMachinePart();weekCell1.XIndex=1;
    this.weekCell2 = new CellMachinePart();weekCell2.XIndex=2;
    this.weekCell3 = new CellMachinePart();weekCell3.XIndex=3;
    this.weekCell4 = new CellMachinePart();weekCell4.XIndex=4;
    this.weekCell5 = new CellMachinePart();weekCell5.XIndex=5;
    this.weekCell6 = new CellMachinePart();weekCell6.XIndex=6;
    this.weekCell7 = new CellMachinePart();weekCell7.XIndex=7;
    this.weekCell8 = new CellMachinePart();weekCell8.XIndex=8;
    this.weekCell9 = new CellMachinePart();weekCell9.XIndex=9;
    this.weekCell10 = new CellMachinePart();weekCell10.XIndex=10;
    this.weekCell11 = new CellMachinePart();weekCell11.XIndex=11;
    this.weekCell12 = new CellMachinePart();weekCell12.XIndex=12;
    this.weekCell13 = new CellMachinePart();weekCell13.XIndex=13;

    this.cellTitles = new CellTitles();    
    this.cellTitles.Title1 = "StartInventory";
    this.cellTitles.Title2 = "Required";
    this.cellTitles.Title3 = "Inventory Targ.";    
    this.cellTitles.Title4 = "Planned Qty";        
    this.cellTitles.Title5 = "Qty Change";    
    this.cellTitles.Title6 = "Planned Other";    
    this.cellTitles.Title7 = "End Inventory";

    this.cellTitles2 = new CellTitles();    
    this.cellTitles2.Title1 = "QOH";
    this.cellTitles2.Title2 = "StWkPlanned";
    this.cellTitles2.Title3 = "Production";    
    this.cellTitles2.Title4 = "RemWkPlanned";        
}


public
string PartType {
	get {
        string spartType = seq == seqLast ? "FG" : "WIP";
        return spartType; }
	set { 		
	}
}

[System.Runtime.Serialization.DataMember]
public
string Part {
	get { return part; }
	set { if (this.part != value){
			this.part = value;
			Notify("Part");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int Seq {
	get { return seq; }
	set { if (this.seq != value){
			this.seq = value;
			Notify("Seq");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int SeqLast {
	get { return seqLast; }
	set { if (this.seqLast != value){
			this.seqLast = value;
			Notify("SeqLast");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Qoh {
	get { return qoh; }
	set { if (this.qoh != value){
			this.qoh = value;
			Notify("Qoh");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RunStd {
	get { return runStd; }
	set { if (this.runStd != value){
			this.runStd = value;
			Notify("runStd");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal DaysOnHand {
	get { return daysOnHand; }
	set { if (this.daysOnHand != value){
			this.daysOnHand = value;
			Notify("DaysOnHand");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal StartWeekPlanned {
	get { return startWeekPlanned; }
	set { if (this.startWeekPlanned != value){
			this.startWeekPlanned = value;
			Notify("StartWeekPlanned");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Production {
	get { return production; }
	set { if (this.production != value){
			this.production = value;
			Notify("Production");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RemaintWeekPlanned {
	get { return remaintWeekPlanned; }
	set { if (this.remaintWeekPlanned != value){
			this.remaintWeekPlanned = value;
			Notify("RemaintWeekPlanned");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyPerWeek {
	get {
        decimal dqtyPerWeek = RunStd * HrsPerShift * StdShiftPerWeek;
        return dqtyPerWeek;
        }
	set {
        decimal dqtyPerWeek = RunStd * HrsPerShift * StdShiftPerWeek;                
        if (dqtyPerWeek != value){			
			Notify("QtyPerWeek");
		}
	}
}
    
[System.Runtime.Serialization.DataMember]
public
CellMachinePart WeekCellPastDue{
	get { return weekCellPastDue; }
	set { if (this.weekCellPastDue != value){
			this.weekCellPastDue = value;
			Notify("WeekCellPastDue");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellMachinePart WeekCell0 {
	get { return weekCell0; }
	set { if (this.weekCell0 != value){
			this.weekCell0 = value;
			Notify("WeekCell0");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellMachinePart WeekCell1 {
	get { return weekCell1; }
	set { if (this.weekCell1 != value){
			this.weekCell1 = value;
			Notify("WeekCell1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellMachinePart WeekCell2 {
	get { return weekCell2; }
	set { if (this.weekCell2 != value){
			this.weekCell2 = value;
			Notify("WeekCell2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellMachinePart WeekCell3 {
	get { return weekCell3; }
	set { if (this.weekCell3 != value){
			this.weekCell3 = value;
			Notify("WeekCell3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellMachinePart WeekCell4 {
	get { return weekCell4; }
	set { if (this.weekCell4 != value){
			this.weekCell4 = value;
			Notify("WeekCell4");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellMachinePart WeekCell5 {
	get { return weekCell5; }
	set { if (this.weekCell5 != value){
			this.weekCell5 = value;
			Notify("WeekCell5");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellMachinePart WeekCell6 {
	get { return weekCell6; }
	set { if (this.weekCell6 != value){
			this.weekCell6 = value;
			Notify("WeekCell6");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellMachinePart WeekCell7 {
	get { return weekCell7; }
	set { if (this.weekCell7 != value){
			this.weekCell7 = value;
			Notify("WeekCell7");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellMachinePart WeekCell8 {
	get { return weekCell8; }
	set { if (this.weekCell8 != value){
			this.weekCell8 = value;
			Notify("WeekCell8");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellMachinePart WeekCell9 {
	get { return weekCell9; }
	set { if (this.weekCell9 != value){
			this.weekCell9 = value;
			Notify("WeekCell9");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellMachinePart WeekCell10 {
	get { return weekCell10; }
	set { if (this.weekCell10 != value){
			this.weekCell10 = value;
			Notify("WeekCell10");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellMachinePart WeekCell11 {
	get { return weekCell11; }
	set { if (this.weekCell11 != value){
			this.weekCell11 = value;
			Notify("WeekCell11");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellMachinePart WeekCell12 {
	get { return weekCell12; }
	set { if (this.weekCell12 != value){
			this.weekCell12 = value;
			Notify("WeekCell12");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellMachinePart WeekCell13 {
	get { return weekCell13; }
	set { if (this.weekCell13 != value){
			this.weekCell13 = value;
			Notify("WeekCell13");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellTitles CellTitles {
	get { return cellTitles; }
	set { if (this.cellTitles != value){
			this.cellTitles = value;
			Notify("CellTitles");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellTitles CellTitles2 {
	get { return cellTitles2; }
	set { if (this.cellTitles2 != value){
			this.cellTitles2 = value;
			Notify("CellTitles2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
InventoryObjectivePartDtlContainer InventoryObjectivePartDtlContainer {
	get { return inventoryObjectivePartDtlContainer; }
	set { if (this.inventoryObjectivePartDtlContainer != value){
			this.inventoryObjectivePartDtlContainer = value;
			Notify("InventoryObjectivePartDtlContainer");
		}
	}
}

public
CellMachinePart getCellMachinePartByXIndex(int xind){
    CellMachinePart c = null;

    switch (xind){
        case -1: c = weekCellPastDue;break;
        case 0 : c = weekCell0;break;
        case 1 : c = weekCell1;break;
        case 2 : c = weekCell2;break;
        case 3 : c = weekCell3;break;
        case 4 : c = weekCell4;break;
        case 5 : c = weekCell5;break;
        case 6 : c = weekCell6;break;
        case 7 : c = weekCell7;break;
        case 8 : c = weekCell8;break;
        case 9 : c = weekCell9;break;
        case 10 : c = weekCell10;break;
        case 11 : c = weekCell11;break;
        case 12 : c = weekCell12;break;
        case 13 : c = weekCell13;break;        
    }

    return c;
}

public
void recalcNet(){
    weekCell0.NetShow = weekCell0.NetShow;
    weekCell1.PriorWeekNet = weekCell0.NetShow;
    weekCell2.PriorWeekNet = weekCell1.NetShow;
    weekCell3.PriorWeekNet = weekCell2.NetShow;
    weekCell4.PriorWeekNet = weekCell3.NetShow;
    weekCell5.PriorWeekNet = weekCell4.NetShow;
    weekCell6.PriorWeekNet = weekCell5.NetShow;
    weekCell7.PriorWeekNet = weekCell6.NetShow;
    weekCell8.PriorWeekNet = weekCell7.NetShow;
    weekCell9.PriorWeekNet = weekCell8.NetShow;
    weekCell10.PriorWeekNet = weekCell9.NetShow;
    weekCell11.PriorWeekNet = weekCell10.NetShow;
    weekCell12.PriorWeekNet = weekCell11.NetShow;
    weekCell13.PriorWeekNet = weekCell12.NetShow;
}


public
void recalcNetIncludeInvObjectives(){    
    weekCell0.Net = weekCell0.NetShow - weekCell0.InvObjectives;

    weekCell1.PriorWeekNet = weekCell0.Net;
    weekCell1.Net = weekCell1.NetShow - weekCell1.InvObjectives;

    weekCell2.PriorWeekNet = weekCell1.Net;
    weekCell2.Net = weekCell2.NetShow - weekCell2.InvObjectives;

    weekCell3.PriorWeekNet = weekCell2.Net;
    weekCell3.Net = weekCell3.NetShow - weekCell3.InvObjectives;

    weekCell4.PriorWeekNet = weekCell3.Net;
    weekCell4.Net = weekCell4.NetShow - weekCell4.InvObjectives;

    weekCell5.PriorWeekNet = weekCell4.Net;
    weekCell5.Net = weekCell5.NetShow - weekCell5.InvObjectives;

    weekCell6.PriorWeekNet = weekCell5.Net;
    weekCell6.Net = weekCell6.NetShow - weekCell6.InvObjectives;

    weekCell7.PriorWeekNet = weekCell6.Net;
    weekCell7.Net = weekCell7.NetShow - weekCell7.InvObjectives;

    weekCell8.PriorWeekNet = weekCell7.Net;
    weekCell8.Net = weekCell8.NetShow - weekCell8.InvObjectives;

    weekCell9.PriorWeekNet = weekCell8.Net;
    weekCell9.Net = weekCell9.NetShow - weekCell9.InvObjectives;

    weekCell10.PriorWeekNet = weekCell9.Net;
    weekCell10.Net = weekCell10.NetShow - weekCell10.InvObjectives;

    weekCell11.PriorWeekNet = weekCell10.Net;
    weekCell11.Net = weekCell11.NetShow - weekCell11.InvObjectives;

    weekCell12.PriorWeekNet = weekCell11.Net;
    weekCell12.Net = weekCell12.NetShow - weekCell12.InvObjectives;

    weekCell13.PriorWeekNet = weekCell12.Net;
    weekCell13.Net = weekCell13.NetShow - weekCell13.InvObjectives;            
}

public
void copy(MachineReportPartView machineReportPartView){
    this.Part = machineReportPartView.Part;
    this.Seq = machineReportPartView.Seq;
    this.Qoh = machineReportPartView.Qoh;
    this.RunStd = machineReportPartView.RunStd;
    this.DaysOnHand = machineReportPartView.DaysOnHand;
            
    WeekCellPastDue.copy(machineReportPartView.WeekCellPastDue);
    WeekCell0.copy(machineReportPartView.WeekCell0);
    WeekCell1.copy(machineReportPartView.WeekCell1);
    WeekCell2.copy(machineReportPartView.WeekCell2);
    WeekCell3.copy(machineReportPartView.WeekCell3);
    WeekCell4.copy(machineReportPartView.WeekCell4);
    WeekCell5.copy(machineReportPartView.WeekCell5);
    WeekCell6.copy(machineReportPartView.WeekCell6);
    WeekCell7.copy(machineReportPartView.WeekCell7);
    WeekCell8.copy(machineReportPartView.WeekCell8);
    WeekCell9.copy(machineReportPartView.WeekCell9);
    WeekCell10.copy(machineReportPartView.WeekCell10);
    WeekCell11.copy(machineReportPartView.WeekCell11);
    WeekCell12.copy(machineReportPartView.WeekCell12);
    WeekCell13.copy(machineReportPartView.WeekCell13);    
}

public override
bool Equals(object obj){
	if (obj is MachineReportPartView)
		return	this.Part.ToUpper().Equals(((MachineReportPartView)obj).Part.ToUpper()) &&
				this.Seq.Equals(((MachineReportPartView)obj).Seq);
	else
		return false;
}

public
decimal getTotRequired(bool bevaluatePastDue){
    decimal dtotalRequired = (bevaluatePastDue ? WeekCellPastDue.Required : 0) +    
    WeekCell0.Required +
    WeekCell1.Required +
    WeekCell2.Required +
    WeekCell3.Required +
    WeekCell4.Required +
    WeekCell5.Required +
    WeekCell6.Required +
    WeekCell7.Required +
    WeekCell8.Required +
    WeekCell9.Required +
    WeekCell10.Required +
    WeekCell11.Required +
    WeekCell12.Required +
    WeekCell13.Required;

    return dtotalRequired;
}

} // class
} // package