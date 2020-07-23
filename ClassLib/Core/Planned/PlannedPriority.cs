/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.Planned{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class PlannedPriority : BusinessObject {

private int hdrId;
private int detail;
private int machineId;
private int machPriority;
private string planned;
private string labour;
private string part;
private decimal qtyPlanned;

#if !WEB
internal
#else
public
#endif
PlannedPriority(){
	this.hdrId = 0;
	this.detail = 0;
	this.machineId = 0;
	this.machPriority = 0;
	this.planned = "";
	this.labour = "";
	this.part = "";
	this.qtyPlanned = 0;
}

internal
PlannedPriority(
	int hdrId,
	int detail,
	int machineId,
	int machPriority,
	string planned,
	string labour,
	string part,
	decimal qtyPlanned)
{
	this.hdrId = hdrId;
	this.detail = detail;
	this.machineId = machineId;
	this.machPriority = machPriority;
	this.planned = planned;
	this.labour = labour;
	this.part = part;
	this.qtyPlanned = qtyPlanned;
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
int MachPriority {
	get { return machPriority;}
	set { if (this.machPriority != value){
			this.machPriority = value;
			Notify("MachPriority");
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
decimal QtyPlanned {
	get { return qtyPlanned;}
	set { if (this.qtyPlanned != value){
			this.qtyPlanned = value;
			Notify("QtyPlanned");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is PlannedPriority)
		return	this.hdrId.Equals(((PlannedPriority)obj).HdrId) &&
				this.detail.Equals(((PlannedPriority)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package