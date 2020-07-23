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

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class CapacityMachPriority : BusinessObject {

private int hdrId;
private int detail;
private int machineId;
private int priority;
private string planned;
private string labour;
private string part;
private decimal qty;

private string machineShow;

#if !WEB
internal
#else
public
#endif
CapacityMachPriority(){
	this.hdrId = 0;
	this.detail = 0;
	this.machineId = 0;
	this.priority = 0;
	this.planned = Constants.STRING_NO;
	this.labour = Constants.STRING_NO;
	this.part = "";
	this.qty = 0;
    this.machineShow = "";
}

internal
CapacityMachPriority(
	int hdrId,
	int detail,
	int machineId,
	int priority,
	string planned,
	string labour,
	string part,
	decimal qty)
{
	this.hdrId = hdrId;
	this.detail = detail;
	this.machineId = machineId;
	this.priority = priority;
	this.planned = planned;
	this.labour = labour;
	this.part = part;
	this.qty = qty;
    this.machineShow= "";
}

[System.Runtime.Serialization.DataMember]
public
int HdrId {
	get { return hdrId;}
	set { if (this.hdrId != value){
			this.hdrId = value;
			Notify("HdrId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int Detail {
	get { return detail;}
	set { if (this.detail != value){
			this.detail = value;
			Notify("Detail");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int MachineId {
	get { return machineId;}
	set { if (this.machineId != value){
			this.machineId = value;
			Notify("MachineId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int Priority {
	get { return priority;}
	set { if (this.priority != value){
			this.priority = value;
			Notify("Priority");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Planned {
	get { return planned;}
	set { if (this.planned != value){
			this.planned = value;
			Notify("Planned");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Labour {
	get { return labour;}
	set { if (this.labour != value){
			this.labour = value;
			Notify("Labour");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Part {
	get { return part;}
	set { if (this.part != value){
			this.part = value;
			Notify("Part");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Qty {
	get { return qty;}
	set { if (this.qty != value){
			this.qty = value;
			Notify("Qty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MachineShow {
	get { return machineShow;}
	set { if (this.machineShow != value){
			this.machineShow = value;
			Notify("MachineShow");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is CapacityMachPriority)
		return	this.hdrId.Equals(((CapacityMachPriority)obj).HdrId) &&
				this.detail.Equals(((CapacityMachPriority)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(CapacityMachPriority capacityMachPriority){	
	this.HdrId=capacityMachPriority.HdrId;
	this.Detail=capacityMachPriority.Detail;
	this.MachineId=capacityMachPriority.MachineId;
	this.Priority=capacityMachPriority.Priority;
	this.Planned=capacityMachPriority.Planned;
	this.Labour=capacityMachPriority.Labour;
	this.Part=capacityMachPriority.Part;
	this.Qty=capacityMachPriority.Qty;
    this.MachineShow = capacityMachPriority.MachineShow;	
}

} // class
} // package