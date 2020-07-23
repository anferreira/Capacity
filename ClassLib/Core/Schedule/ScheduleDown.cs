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
using System.Collections;

namespace Nujit.NujitERP.ClassLib.Core.ScheduleDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class ScheduleDown : ScheduleMachine {

private int hdrId;
private int detail;
private DateTime startDate;
private DateTime endDate;
private int startShift;
private string type;
private string typeName;
private decimal hours;
private int totEmployees;
private decimal employeeHours;
private int priority;
private int queue;

#if !WEB
internal
#else
public
#endif
ScheduleDown() : base(){
	this.hdrId = 0;
	this.detail = 0;
	this.startDate = DateUtil.MinValue;
	this.endDate = DateUtil.MinValue;
	this.startShift = 1;
	this.type = Constants.DOWN_TYPE;
	this.typeName = "Down";
	this.hours = 0;
	this.totEmployees = 0;
	this.employeeHours = 0;
	this.priority = 1;
	this.queue = 0;    
}

internal
ScheduleDown(
	int hdrId,
	int detail,	
	DateTime startDate,
	DateTime endDate,
	int startShift,
	string type,
	string typeName,
	decimal hours,
	int totEmployees,
	decimal employeeHours,
	int priority,
	int queue,
    int machId) : base(machId,"",""){
	this.hdrId = hdrId;
	this.detail = detail;	
	this.startDate = startDate;
	this.endDate = endDate;
	this.startShift = startShift;
	this.type = type;
	this.typeName = typeName;
	this.hours = hours;
	this.totEmployees = totEmployees;
	this.employeeHours = employeeHours;
	this.priority = priority;
	this.queue = queue;    
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
DateTime StartDate {
	get { return startDate;}
	set { if (this.startDate != value){
			this.startDate = value;
            calculateStartShift();
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
int StartShift {
	get { return startShift;}
	set { if (this.startShift != value){
			this.startShift = value;
			Notify("StartShift");
		}
	}
}

public
void  calculateStartShift(){
    StartShift = DateUtil.getShiftNum(startDate);    
}

[System.Runtime.Serialization.DataMember]
public
string Type {
	get { return type;}
	set { if (this.type != value){
			this.type = value;
			Notify("Type");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string TypeName {
	get { return typeName;}
	set { if (this.typeName != value){
			this.typeName = value;
			Notify("TypeName");
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
int TotEmployees {
	get { return totEmployees;}
	set { if (this.totEmployees != value){
			this.totEmployees = value;
			Notify("TotEmployees");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal EmployeeHours {
	get { return employeeHours;}
	set { if (this.employeeHours != value){
			this.employeeHours = value;
			Notify("EmployeeHours");
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
int Queue {
	get { return queue;}
	set { if (this.queue != value){
			this.queue = value;
			Notify("Queue");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is ScheduleDown)
		return	this.hdrId.Equals(((ScheduleDown)obj).HdrId) &&
				this.detail.Equals(((ScheduleDown)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(ScheduleDown scheduleDown){    
    this.HdrId=scheduleDown.HdrId;
	this.Detail=scheduleDown.Detail;	
	this.StartDate=scheduleDown.StartDate;
	this.EndDate=scheduleDown.EndDate;
	this.StartShift=scheduleDown.StartShift;
	this.Type=scheduleDown.Type;
	this.TypeName=scheduleDown.TypeName;
	this.Hours=scheduleDown.Hours;
	this.TotEmployees=scheduleDown.TotEmployees;
	this.EmployeeHours=scheduleDown.EmployeeHours;
	this.Priority=scheduleDown.Priority;
	this.Queue=scheduleDown.Queue;

    base.copy(scheduleDown);    
}

} // class
} // package