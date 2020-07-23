using System;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core.ScheduleDemand{

public
class ScheduleReqView : SchedulePart  {

private string scheduleType;
private int taskId;
private string description;
private string typeDesc;
private decimal hours;

public const string SCHEDULE_TYPE_PART= "P";
public const string SCHEDULE_TYPE_TASK= "K";
public const string SCHEDULE_TYPE_SUBTOTAL= "ST";
public const string SCHEDULE_TYPE_DOWN= "D";

public
ScheduleReqView() : base(){
    this.scheduleType= "";
    this.taskId = 0;
    this.description= "";
    this.typeDesc = "";
    this.hours=0;
}

public
ScheduleReqView(ScheduleReqView scheduleReqView) : base(scheduleReqView.HdrId,
                                                    scheduleReqView.Detail,                                                    
                                                    scheduleReqView.Part,
                                                    scheduleReqView.IsFamily,
                                                    scheduleReqView.Seq,
                                                    scheduleReqView.Qty,
                                                    scheduleReqView.QtyReported,
                                                    scheduleReqView.StartDate,
                                                    scheduleReqView.EndDate,
                                                    scheduleReqView.StartShift,
                                                    scheduleReqView.Priority,
                                                    scheduleReqView.Queue,
                                                    scheduleReqView.RunStd,
                                                    scheduleReqView.CavityNum,
                                                    scheduleReqView.Uom,
                                                    scheduleReqView.CapacityHdrId,
                                                    scheduleReqView.HotListId,
                                                    scheduleReqView.MachId,
                                                    scheduleReqView.SchNonChargeDT,
                                                    scheduleReqView.SchChargeDT,    
                                                    scheduleReqView.MaterialFlag,
                                                    scheduleReqView.RetContFlag,
                                                    scheduleReqView.ToolFlag,
                                                    scheduleReqView.HotListScheduleDate){

    this.scheduleType   = scheduleReqView.ScheduleType;
    this.taskId         = scheduleReqView.TaskId; ;
    this.description    = scheduleReqView.Description;
    this.typeDesc       = scheduleReqView.TypeDesc;
    this.hours          = scheduleReqView.Hours;
}

[System.Runtime.Serialization.DataMember]
public
string ScheduleType {
	get { return scheduleType; }
	set { if (this.scheduleType != value){
			this.scheduleType = value;
			Notify("ScheduleType");
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
string Description {
	get { return description;}
	set { if (this.description != value){
			this.description = value;
			Notify("Description");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string TypeDesc {
	get { return typeDesc; }
	set { if (this.typeDesc != value){
			this.typeDesc = value;
			Notify("TypeDesc");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Hours {
	get { return hours; }
	set { if (this.hours != value){
			this.hours = value;
			Notify("Hours");
		}
	}
}

public
string TypeDescription {
	get {
        string saux = "";

        switch(scheduleType){
            case ScheduleReqView.SCHEDULE_TYPE_PART:
                saux = "MP(" + Part + ")";
                break;    
            case ScheduleReqView.SCHEDULE_TYPE_TASK:
                saux = "Task";
                break;    
            case ScheduleReqView.SCHEDULE_TYPE_DOWN:
                saux = Constants.getDownTypeShow(TypeDesc);
                break;    
        }
        return saux;
    }
	set {
	}
}

public
string TypeDescription2 {
	get {
        string saux = "";

        switch(scheduleType){
            case ScheduleReqView.SCHEDULE_TYPE_PART:
                saux = "Run";
                break;    
            case ScheduleReqView.SCHEDULE_TYPE_TASK:
                saux = Description;
                break;    
            case ScheduleReqView.SCHEDULE_TYPE_DOWN:
                saux = Description;
                break;    
        }
        return saux;
    }
	set {
	}
}


public
string getScheduleTypeDescription(){
    string saux = "";

    switch(scheduleType){
        case ScheduleReqView.SCHEDULE_TYPE_PART:
            saux = "Build Part";
            break;    
        case ScheduleReqView.SCHEDULE_TYPE_TASK:
            saux = "Task";
            break;    
        case ScheduleReqView.SCHEDULE_TYPE_SUBTOTAL:
            saux = "SubTotal";
            break;    
        case ScheduleReqView.SCHEDULE_TYPE_DOWN:
            saux = TypeDesc;
            break;  
    }
    return saux;
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


public
int EndShift{
	get {                
        return DateUtil.getShiftNum(EndDate);
     }
	set { 		
	}
}

public
string DatesShow {
	get {
        string saux =  "";          
        if (scheduleType.Equals(SCHEDULE_TYPE_SUBTOTAL))
            saux =  Hours.ToString("0.00");  
        else
            saux =   DateUtil.getCompleteDateRepresentationWithoutSS(StartDate,DateUtil.MMDDYYYY)+ "-" +
                     DateUtil.getCompleteDateRepresentationWithoutSS(EndDate, DateUtil.MMDDYYYY);
        return saux;
     }
	set { 		
	}
}

public
void copy(SchedulePart schedulePart){
    base.copy(schedulePart);
    this.ScheduleType = SCHEDULE_TYPE_PART;
    this.TypeDesc = "";    
}

public
void copy(ScheduleTask scheduleTask){
    this.ScheduleType = SCHEDULE_TYPE_TASK;
    this.Detail = scheduleTask.Detail;    
    this.StartDate= scheduleTask.StartDate;
    this.EndDate = scheduleTask.EndDate;
    this.StartShift = scheduleTask.StartShift;
    this.TaskId = scheduleTask.TaskId;

    this.Hours = scheduleTask.Hours;
    //this.TotEmployees = scheduleTask.TotEmployees;
    //this.EmployeeHours = scheduleTask.EmployeeHours;
    this.Description = scheduleTask.TaskDescription;
    this.Priority = scheduleTask.Priority;
    this.IsFamily = "";
    this.TypeDesc = "";

    this.MaterialFlag  = "";
    this.RetContFlag  = "";
    this.ToolFlag  = "";    
    this.Queue = scheduleTask.Queue;

    copy((ScheduleMachine)scheduleTask);    
}

public
void copy(ScheduleDown scheduleDown){
    this.ScheduleType   = SCHEDULE_TYPE_DOWN;
    this.Detail         = scheduleDown.Detail;    
    this.StartDate      = scheduleDown.StartDate;
    this.EndDate        = scheduleDown.EndDate;
    this.StartShift     = scheduleDown.StartShift;
    
    this.Hours          = scheduleDown.Hours;
    //this.TotEmployees   = scheduleDown.TotEmployees;
    //this.EmployeeHours  = scheduleDown.EmployeeHours;
    this.TypeDesc       = scheduleDown.Type;
    this.Description    = scheduleDown.TypeName;
    this.Priority       = scheduleDown.Priority;
    this.IsFamily       = "";

    this.MaterialFlag   = "";
    this.RetContFlag    = "";
    this.ToolFlag       = "";    
    this.Queue          = scheduleDown.Queue;
       
    copy((ScheduleMachine)scheduleDown);
}

public
void copy(ScheduleMachine scheduleMachine){  
    this.MachId     = scheduleMachine.MachId;
    this.MachShow   = scheduleMachine.MachShow;
}

public override
bool Equals(object obj){
	if (obj is ScheduleReqView)
		return	this.HdrId.Equals(((ScheduleReqView)obj).HdrId) &&
				this.Detail.Equals(((ScheduleReqView)obj).Detail) &&                
                this.ScheduleType.Equals(((ScheduleReqView)obj).ScheduleType);
	else
		return false;
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
decimal HoursSubtractShow{
	get {                
        decimal dhours = HoursSubtract;
        if (scheduleType.Equals(SCHEDULE_TYPE_SUBTOTAL))
            dhours= Hours;
        return dhours;
     }
	set { 		
	}
} 

public
int StartShiftShow{
	get {                
        if (scheduleType.Equals(SCHEDULE_TYPE_SUBTOTAL))
        return 0;        
    return StartShift;
     }set { 		
	}
} 

public
string ScheduledShow{
	get {                
        string saux= "";
        if (scheduleType.Equals(SCHEDULE_TYPE_PART))
            saux = Convert.ToInt32(Qty).ToString();
        else if (scheduleType.Equals(SCHEDULE_TYPE_TASK))
            saux= Hours.ToString("0.00");

        return saux;
     }
	set { 		
	}
} 

public
string ReportedShow{
	get {                
        string saux="";
        if (scheduleType.Equals(SCHEDULE_TYPE_PART))
            saux = Convert.ToInt32(QtyReported).ToString();
        return saux;
     }
	set { 		
	}
}

public
string RunStdShow{
	get {                
        string saux= "";
        if (scheduleType.Equals(SCHEDULE_TYPE_PART))
            saux= Convert.ToInt64(RunStd).ToString();        
        return saux;
     }
	set { 		
	}
} 

public
string CavityNumShow{
	get {                
        string saux= "";
        if (scheduleType.Equals(SCHEDULE_TYPE_PART))            
            saux= Convert.ToInt64(CavityNum).ToString();      
        return saux;
     }
	set { 		
	}
} 

public
string QtyToCompleteShow{
	get {                
        string saux= "";
        if (scheduleType.Equals(SCHEDULE_TYPE_PART))
            saux=  Convert.ToInt64((Qty - QtyReported)).ToString();        
        return saux;
     }
	set { 		
	}
} 

public
void  calculateShift(){
    StartShift = DateUtil.getShiftNum(StartDate);    
} 

public
double DurationHours(){
    double duration=0;

    switch(scheduleType){
        case ScheduleReqView.SCHEDULE_TYPE_PART:
            if (EndDate < StartDate)                
                EndDate = calculateEndDataMachineBuild();            
            break;    
        case ScheduleReqView.SCHEDULE_TYPE_TASK:                        
        case ScheduleReqView.SCHEDULE_TYPE_DOWN:        
            break;  
    }
    duration =(EndDate - StartDate).TotalHours;

    return duration;
}

}
}
