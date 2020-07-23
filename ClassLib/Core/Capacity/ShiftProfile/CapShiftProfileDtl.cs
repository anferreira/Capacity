/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class CapShiftProfileDtl : BusinessObject {

private int hdrId;
private int detail;
private int shiftTaskId;
private int numPeople;
private int newPeople;
private decimal hours;

private string taskNameShow; //only used to show on screen
private string dirIndShow;
private int shiftNumShow;

#if !WEB
internal
#else
public
#endif
CapShiftProfileDtl(){
	this.hdrId = 0;
	this.detail = 0;
	this.shiftTaskId = 0;
	this.numPeople = 0;
	this.newPeople = 0;
	this.hours = 0;
    this.taskNameShow = "";
    this.dirIndShow = ""; 
    this.shiftNumShow = 0;
}

internal
CapShiftProfileDtl(
	int hdrId,
	int detail,
	int shiftTaskId,
	int numPeople,
	int newPeople,
	decimal hours,
    string taskNameShow,
    string dirIndShow,
    int shiftNumShow)
{
	this.hdrId = hdrId;
	this.detail = detail;
	this.shiftTaskId = shiftTaskId;
	this.numPeople = numPeople;
	this.newPeople = newPeople;
	this.hours = hours;
    this.taskNameShow = taskNameShow;
    this.dirIndShow= dirIndShow; 
    this.shiftNumShow = shiftNumShow;
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
int ShiftTaskId {
	get { return shiftTaskId;}
	set { if (this.shiftTaskId != value){
			this.shiftTaskId = value;
			Notify("ShiftTaskId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int NumPeople {
	get { return numPeople;}
	set { if (this.numPeople != value){
			this.numPeople = value;
			Notify("NumPeople");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int NewPeople {
	get { return newPeople;}
	set { if (this.newPeople != value){
			this.newPeople = value;
			Notify("NewPeople");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Hours {
	get { return hours;}
	set { if (this.hours != value){
			this.hours = value;
			Notify("Hours");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string TaskNameShow {
	get { return taskNameShow;}
	set { if (this.taskNameShow != value){
			this.taskNameShow = value;
			Notify("TaskNameShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string DirIndShow {
	get { return dirIndShow; }
	set { if (this.dirIndShow != value){
			this.dirIndShow = value;
			Notify("DirIndShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int ShiftNumShow {
	get { return shiftNumShow; }
	set { if (this.shiftNumShow != value){
			this.shiftNumShow = value;
			Notify("ShiftNumShow");
		}
	}
}

public
void copy(CapShiftProfileDtl capShiftProfileDtl){
    this.HdrId=capShiftProfileDtl.HdrId;
    this.Detail=capShiftProfileDtl.Detail;
    this.ShiftTaskId=capShiftProfileDtl.ShiftTaskId;
    this.NumPeople=capShiftProfileDtl.NumPeople;
    this.NewPeople=capShiftProfileDtl.NewPeople;
    this.Hours=capShiftProfileDtl.Hours;
    this.TaskNameShow =capShiftProfileDtl.TaskNameShow;
    this.DirIndShow = capShiftProfileDtl.DirIndShow;
    this.ShiftNumShow = capShiftProfileDtl.ShiftNumShow;
}

public override
bool Equals(object obj){
	if (obj is CapShiftProfileDtl)
		return	this.hdrId.Equals(((CapShiftProfileDtl)obj).HdrId) &&
				this.detail.Equals(((CapShiftProfileDtl)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package