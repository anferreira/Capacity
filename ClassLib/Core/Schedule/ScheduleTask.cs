/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////


using System;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.ScheduleDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class ScheduleTask : ScheduleMachine {

private int hdrId;
private int detail;
private DateTime startDate;
private DateTime endDate;
private int startShift;
private int taskId;
private decimal hours;
private int totEmployees;
private decimal employeeHours;
private int priority;

private int queue;
private string taskDescription; //used to show description


#if !WEB
internal
#else
public
#endif
ScheduleTask():base(){
	this.hdrId = 0;
	this.detail = 0;    
    this.startDate = DateTime.Now;
	this.endDate = DateTime.Now;
	this.startShift = 1;    
    this.taskId = 0;
    this.hours = 0;
	this.totEmployees = 0;
	this.employeeHours = 0;
    this.priority = 1;
    this.queue = 0;    
    this.taskDescription = "";
}

internal
ScheduleTask(
	int hdrId,
	int detail,    
    DateTime startDate,
	DateTime endDate,
	int startShift,
    int taskId,
    decimal hours,
    int totEmployees,
    decimal employeeHours,
    int priority,
    int queue,
    int machId,
    string taskDescription): base(machId, "",""){
	this.hdrId = hdrId;
	this.detail = detail;    
    this.startDate = startDate;
	this.endDate = endDate;
	this.startShift = startShift;    
    this.taskId = taskId;
    this.hours = hours;
	this.totEmployees = totEmployees;
	this.employeeHours = employeeHours;
    this.priority = priority;
    this.queue = queue;    
    this.taskDescription = taskDescription;
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
            calculateShift();
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
            calculateEndShift();
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
            calculateShift();
			Notify("StartShift");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int TaskId {
	get { return taskId; }
	set { if (this.taskId != value){
			this.taskId = value;
			Notify("TaskId");
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
string TaskDescription {
	get { return taskDescription; }
	set { if (this.taskDescription != value){
			this.taskDescription = value;
			Notify("TaskDescription");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int Queue {
	get { return queue; }
	set { if (this.queue != value){
			this.queue = value;
			Notify("Queue");
		}
	}
}
    
public
string DatesShow {
	get {
        string saux =   DateUtil.getCompleteDateRepresentationWithoutSS(StartDate,DateUtil.MMDDYYYY)+ "-" +
                        DateUtil.getCompleteDateRepresentationWithoutSS(EndDate, DateUtil.MMDDYYYY);
        return saux;
     }
	set { 		
	}
}    
        
public
string StartDateShow {
	get {                
        return DateUtil.getCompleteDateRepresentationWithoutSS(StartDate, DateUtil.MMDDYYYY);
     }
	set { 		
	}
}

public
string EndDateShow {
	get {                
        return DateUtil.getCompleteDateRepresentationWithoutSS(EndDate, DateUtil.MMDDYYYY);
     }
	set { 		
	}
}                

public override
bool Equals(object obj){
	if (obj is ScheduleTask)
		return	this.hdrId.Equals(((ScheduleTask)obj).HdrId) &&
				this.detail.Equals(((ScheduleTask)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(ScheduleTask scheduleTask){    
    this.HdrId = scheduleTask.HdrId;
    this.Detail = scheduleTask.Detail;    
    this.StartDate = scheduleTask.StartDate;
    this.EndDate = scheduleTask.EndDate;
    this.StartShift = scheduleTask.StartShift;
    this.TaskId = scheduleTask.TaskId;
    this.Hours = scheduleTask.Hours;
    this.TotEmployees = scheduleTask.TotEmployees;
    this.EmployeeHours = scheduleTask.EmployeeHours;   
    this.Priority= scheduleTask.Priority;   
    this.Queue = scheduleTask.Queue;
    
    this.TaskDescription = scheduleTask.TaskDescription;
    base.copy(scheduleTask);
}

public
decimal HoursSubtract{
	get {                
        decimal dhours = Convert.ToDecimal((EndDate - StartDate).TotalHours);
        return dhours;
     }
	set { 		
	}
} 

public
void  calculateShift(){
    StartShift = DateUtil.getShiftNum(startDate);    
} 

public
void  calculateEndShift(){
    EndShift = DateUtil.getShiftNum(endDate);    
}  

public
int EndShift{
	get {                
        return DateUtil.getShiftNum(EndDate);
     }
	set { 		
        Notify("EndShift");
	}
}

} // class
} // package