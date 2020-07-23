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
using Nujit.NujitERP.ClassLib.Core.Planned;

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class CellMachinePart : BusinessObject {

protected decimal required;
protected decimal planned;
protected decimal plannedOther;
protected decimal plannedOtherCurrAlter;
protected decimal plannedQtyChange;
protected decimal plannedOvertime;
protected decimal invObjectives;
protected decimal employeesShiftSchedule;
protected decimal net;
protected CapacityPartContainer capacityPartContainer;
protected PlannedPartContainer plannedPartContainer;
protected PlannedPartContainer plannedPartOtherContainer;
protected InventoryObjectivePartDtlContainer inventoryObjectivePartDtlContainer;
protected DateTime startDate;
protected DateTime endDate;
protected int index;
protected int xindex;
private int requiredOther;

private decimal priorWeekNet;

public
CellMachinePart(): base(){            
    this.required = 0;
    this.planned = 0;
    this.plannedOther = 0;
    this.plannedOtherCurrAlter = 0;
    this.plannedQtyChange = 0;
    this.plannedOvertime = 0;
    this.invObjectives = 0;
    this.employeesShiftSchedule = 0;
    this.net = 0;  
    this.requiredOther = 0;
    this.index =0;
    this.xindex = 0;
    this.priorWeekNet = 0;
    this.capacityPartContainer = new CapacityPartContainer();
    this.plannedPartContainer = new PlannedPartContainer();
    this.plannedPartOtherContainer = new PlannedPartContainer();
    this.inventoryObjectivePartDtlContainer = new InventoryObjectivePartDtlContainer();

    this.startDate = DateUtil.MinValue;
    this.endDate = DateUtil.MinValue;
}

[System.Runtime.Serialization.DataMember]
public
decimal Required {
	get { return required; }
	set { if (this.required != value){
			this.required = value;
			Notify("Required");
            Notify("Net");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Planned {
	get { return planned; }
	set { if (this.planned != value){
			this.planned = value;            
			Notify("Planned");
            Notify("Net");
            Notify("NetShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal PlannedOther {
	get { return plannedOther; }
	set { if (this.plannedOther != value){
			this.plannedOther = value;            
			Notify("PlannedOther");
            Notify("Net");
            Notify("NetShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal PlannedOtherCurrAlter {
	get { return plannedOtherCurrAlter; }
	set { if (this.plannedOtherCurrAlter != value){
			this.plannedOtherCurrAlter = value;            
			Notify("PlannedOtherCurrAlter");
            Notify("Net");
            Notify("NetShow");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
decimal PlannedQtyChange {
	get { return plannedQtyChange; }
	set { if (this.plannedQtyChange != value){
			this.plannedQtyChange = value;            
			Notify("PlannedQtyChange");            
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal PlannedOvertime {
	get { return plannedOvertime; }
	set { if (this.plannedOvertime != value){
			this.plannedOvertime = value;            
			Notify("PlannedOvertime");           
            Notify("Net");
            Notify("NetShow");                     
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal InvObjectives {
	get { return invObjectives; }
	set { if (this.invObjectives != value){
			this.invObjectives = value;            
			Notify("InvObjectives");
            Notify("Net");
            Notify("NetShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal EmployeesShiftSchedule {
	get { return employeesShiftSchedule; }
	set { if (this.employeesShiftSchedule != value){
			this.employeesShiftSchedule = value;            
			Notify("EmployeesShiftSchedule");
            Notify("Net");
            Notify("NetShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Net {
	get {        
        //net = Required + Planned - InvObjectives + PriorWeekNet; //we add because Required is negative on hotlist       
        //PriorNet - Required + Planned
        net = PriorWeekNet + Required  + Planned + EmployeesShiftSchedule + PlannedOvertime + PlannedOther + PlannedOtherCurrAlter - InvObjectives;
        return net;

    } set { if (this.net != value){
			this.net = value;
			Notify("Net");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal PriorWeekNet {
	get { return priorWeekNet; }
	set { if (this.priorWeekNet != value){
			this.priorWeekNet = value;
			Notify("PriorWeekNet");
            Notify("Net");
            Notify("NetShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int RequiredOther {
	get { return requiredOther; }
	set { if (this.requiredOther != value){
			this.requiredOther = value;
			Notify("RequiredOther");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CapacityPartContainer CapacityPartContainer {
	get { return capacityPartContainer; }
	set { if (this.capacityPartContainer != value){
			this.capacityPartContainer = value;
			Notify("CapacityPartContainer");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal NetShow {
	get {        
        //PriorNet - Required + Planned        
        return PriorWeekNet + Required + Planned + EmployeesShiftSchedule + PlannedOvertime + PlannedOther + PlannedOtherCurrAlter;

    } set {           
        decimal daux = PriorWeekNet + Required + Planned  + EmployeesShiftSchedule + PlannedOvertime + PlannedOther + PlannedOtherCurrAlter;                                                     
        if (daux != value){
			daux = value;
			Notify("NetShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
PlannedPartContainer PlannedPartContainer {
	get { return plannedPartContainer; }
	set { if (this.plannedPartContainer != value){
			this.plannedPartContainer = value;
			Notify("PlannedPartContainer");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
PlannedPartContainer PlannedPartOtherContainer {
	get { return plannedPartOtherContainer; }
	set { if (this.plannedPartOtherContainer != value){
			this.plannedPartOtherContainer = value;
			Notify("PlannedPartOtherContainer");
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

[System.Runtime.Serialization.DataMember]
public
DateTime StartDate {
	get { return startDate;}
	set { if (this.startDate != value){
			this.startDate = value;
			Notify("StartDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime EndDate {
	get { return endDate;}
	set { if (this.endDate != value){
			this.endDate = value;
			Notify("EndDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int Index {
	get { return index;}
	set { if (this.index != value){
			this.index = value;
			Notify("Index");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int XIndex {
	get { return xindex; }
	set { if (this.xindex != value){
			this.xindex = value;
			Notify("xindex");
		}
	}
}

public
void copy(CellMachinePart cellMachinePart){
    this.Required = cellMachinePart.Required;
    this.Planned = cellMachinePart.Planned;
    this.PlannedOther = cellMachinePart.PlannedOther;
    this.PlannedOvertime = cellMachinePart.PlannedOvertime;
    this.PlannedOtherCurrAlter = cellMachinePart.PlannedOtherCurrAlter;
    this.InvObjectives = cellMachinePart.InvObjectives;
    this.EmployeesShiftSchedule = cellMachinePart.EmployeesShiftSchedule;
    this.Net = cellMachinePart.Net;
    this.Required = cellMachinePart.Required;
    this.RequiredOther = cellMachinePart.RequiredOther;

    this.StartDate = cellMachinePart.StartDate;
    this.EndDate = cellMachinePart.EndDate;
    this.Index = cellMachinePart.Index;
    this.XIndex = cellMachinePart.XIndex;
    this.RequiredOther = cellMachinePart.RequiredOther;
    this.StartDate = cellMachinePart.StartDate;
    this.StartDate = cellMachinePart.StartDate;
}


} // class
} // package