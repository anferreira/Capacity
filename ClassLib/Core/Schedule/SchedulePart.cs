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

namespace Nujit.NujitERP.ClassLib.Core.ScheduleDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class SchedulePart : ScheduleMachine {

private int hdrId;
private int detail;
private string part;
private string isFamily;
private int seq;
private decimal qty;
private DateTime startDate;
private DateTime endDate;
private int startShift;
private int priority;
private int queue;
private decimal runStd;
private decimal cavityNum;
private decimal qtyReported;
private string uom;
private int capacityHdrId;
private int hotListId;
private decimal schNonChargeDT;
private decimal schChargeDT;

private string materialFlag;
private string retContFlag;
private string toolFlag;

private DateTime hotListScheduleDate=DateUtil.MinValue;

private SchedulePartDtlContainer schedulePartDtlContainer;
private ScheduleReceiptPartContainer scheduleReceiptPartContainer;

#if !WEB
internal
#else
public
#endif
SchedulePart():base(){
	this.hdrId = 0;
	this.detail = 0;
	this.part = "";
	this.isFamily = "P";
	this.seq = 0;
	this.qty = 0;
    this.qtyReported=0;
    this.uom= "";
    this.startDate = DateTime.Now;
	this.endDate = DateTime.Now;
	this.startShift = 1;
    this.priority = 1;
    this.runStd=0;
    this.queue = 0;
    this.runStd = 1;
    this.cavityNum= 1;
    this.capacityHdrId = 0;
    this.hotListId = 0;
    this.schNonChargeDT =0;
    this.schChargeDT =0;
    
    this.materialFlag = Constants.STRING_NO;
    this.retContFlag = Constants.STRING_NO;
    this.toolFlag = Constants.STRING_NO;
    this.hotListScheduleDate = DateUtil.MinValue;               
    this.schedulePartDtlContainer = new SchedulePartDtlContainer();   
    this.scheduleReceiptPartContainer = new ScheduleReceiptPartContainer();
}

internal
SchedulePart(
	int hdrId,
	int detail,    
    string part,
	string isFamily,
	int seq,
	decimal qty,
    decimal qtyReported,
	DateTime startDate,
	DateTime endDate,
	int startShift,
    int priority,
    int queue,
    decimal runStd,        
    decimal cavityNum,
    string uom,
    int capacityHdrId,
    int hotListId,
    int machId,
    decimal schNonChargeDT,
    decimal schChargeDT,
    string materialFlag,
    string retContFlag,
    string toolFlag,
    DateTime hotListScheduleDate):base(machId,"",""){
	this.hdrId = hdrId;
	this.detail = detail;    
    this.part = part;
	this.isFamily = isFamily;
	this.seq = seq;
	this.qty = qty;
    this.qtyReported = qtyReported;
    this.startDate = startDate;
	this.endDate = endDate;
	this.startShift = startShift;
    this.priority = priority;    
    this.queue = queue;
    this.runStd = runStd;
    this.cavityNum = cavityNum;
    this.uom = uom;
    this.capacityHdrId = capacityHdrId;
    this.hotListId = hotListId;    
    this.schNonChargeDT= schNonChargeDT;
    this.schChargeDT = schChargeDT;

    this.materialFlag= materialFlag;
    this.retContFlag= retContFlag;
    this.toolFlag= toolFlag;
    this.hotListScheduleDate = hotListScheduleDate;
    this.schedulePartDtlContainer = new SchedulePartDtlContainer();    
    this.scheduleReceiptPartContainer = new ScheduleReceiptPartContainer();
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
string IsFamily {
	get { return isFamily;}
	set { if (this.isFamily != value){
			this.isFamily = value;
			Notify("IsFamily");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int Seq {
	get { return seq;}
	set { if (this.seq != value){
			this.seq = value;
			Notify("Seq");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Qty {
	get { return qty;}
	set { if (this.qty != value){
			this.qty = value;
            RemainsQty = RemainsQty;                
            QtyInt64= QtyInt64;
            Notify("Qty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
Int64 QtyInt64 {
	get { return Convert.ToInt64(qty);}
	set { if (this.qty != value){
			this.qty = value;
			Notify("QtyInt64");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyReported {
	get { return qtyReported; }
	set { if (this.qtyReported != value){
			this.qtyReported = value;
            RemainsQty = RemainsQty;
			Notify("QtyReported");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
Int64 QtyReportedInt64 {
	get { return Convert.ToInt64(qtyReported);}
	set { if (this.qtyReported != value){
			this.qtyReported = value;
			Notify("QtyReportedInt64");
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
			Notify("StartShift");
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
SchedulePartDtlContainer SchedulePartDtlContainer {
	get { return schedulePartDtlContainer; }
	set { if (this.schedulePartDtlContainer != value){
			this.schedulePartDtlContainer = value;
			Notify("SchedulePartDtlContainer");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
ScheduleReceiptPartContainer ScheduleReceiptPartContainer {
	get { return scheduleReceiptPartContainer; }
	set { if (this.scheduleReceiptPartContainer != value){
			this.scheduleReceiptPartContainer = value;
			Notify("ScheduleReceiptPartContainer");
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

[System.Runtime.Serialization.DataMember]
public
decimal RunStd {
	get { return runStd; }
	set { if (this.runStd != value){
			this.runStd = value;
			Notify("RunStd");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CavityNum {
	get { return cavityNum; }
	set { if (this.cavityNum != value){
			this.cavityNum = value;
			Notify("CavityNum");
		}
	}
}
    
[System.Runtime.Serialization.DataMember]
public
string Uom {
	get { return uom; }
	set { if (this.uom != value){
			this.uom = value;
			Notify("Uom");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int CapacityHdrId {
	get { return capacityHdrId; }
	set { if (this.capacityHdrId != value){
			this.capacityHdrId = value;
			Notify("CapacityHdrId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int HotListId {
	get { return hotListId; }
	set { if (this.hotListId != value){
			this.hotListId = value;
			Notify("HotListId");
		}
	}
}
    
[System.Runtime.Serialization.DataMember]
public
decimal SchNonChargeDT {
	get { return schNonChargeDT; }
	set { if (this.schNonChargeDT != value){
			this.schNonChargeDT = value;
			Notify("SchNonChargeDT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal SchChargeDT {
	get { return schChargeDT; }
	set { if (this.schChargeDT != value){
			this.schChargeDT = value;
			Notify("SchChargeDT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MaterialFlag {
	get { return materialFlag; }
	set { if (this.materialFlag != value){
			this.materialFlag = value;
			Notify("MaterialFlag");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RetContFlag {
	get { return retContFlag; }
	set { if (this.retContFlag != value){
			this.retContFlag = value;
			Notify("RetContFlag");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ToolFlag {
	get { return toolFlag; }
	set { if (this.toolFlag != value){
			this.toolFlag = value;
			Notify("ToolFlag");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime HotListScheduleDate {
	get { return hotListScheduleDate; }
	set { if (this.hotListScheduleDate != value){
			this.hotListScheduleDate = value;
			Notify("HotListScheduleDate");
		}
	}
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

public override
bool Equals(object obj){
	if (obj is SchedulePart)
		return	this.hdrId.Equals(((SchedulePart)obj).HdrId) &&
				this.detail.Equals(((SchedulePart)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(SchedulePart schedulePart){
    this.HdrId=schedulePart.HdrId;
	this.Detail=schedulePart.Detail;    
	this.Part=schedulePart.Part;
	this.IsFamily=schedulePart.IsFamily;
	this.Seq=schedulePart.Seq;
	this.Qty=schedulePart.Qty;
    this.QtyReported=schedulePart.QtyReported;
	this.StartDate=schedulePart.StartDate;
	this.EndDate=schedulePart.EndDate;
	this.StartShift=schedulePart.StartShift;	
    this.Priority = schedulePart.Priority;
    this.Queue = schedulePart.Queue;
    this.RunStd = schedulePart.RunStd;
    this.CavityNum = schedulePart.CavityNum;
    this.QtyReported = schedulePart.QtyReported;
    this.Uom = schedulePart.Uom;
    this.CapacityHdrId = schedulePart.CapacityHdrId;
    this.HotListId = schedulePart.HotListId;
    this.SchNonChargeDT = schedulePart.SchNonChargeDT;
    this.SchChargeDT = schedulePart.SchChargeDT;
    
    base.copy(schedulePart);

    this.MaterialFlag = schedulePart.MaterialFlag;
    this.RetContFlag = schedulePart.RetContFlag;
    this.ToolFlag = schedulePart.ToolFlag;
    this.HotListScheduleDate = HotListScheduleDate;

    this.SchedulePartDtlContainer.Clear();
    foreach(SchedulePartDtl schedulePartDtl in schedulePart.SchedulePartDtlContainer){
        SchedulePartDtl schedulePartDtlCopy = new SchedulePartDtl();
        schedulePartDtlCopy.copy(schedulePartDtl);
        this.SchedulePartDtlContainer.Add(schedulePartDtlCopy);
    }    

    this.ScheduleReceiptPartContainer.Clear();
    foreach(ScheduleReceiptPart scheduleReceiptPart in schedulePart.ScheduleReceiptPartContainer){
        ScheduleReceiptPart scheduleReceiptPartCopy = new ScheduleReceiptPart();
        scheduleReceiptPartCopy.copy(scheduleReceiptPart);
        this.ScheduleReceiptPartContainer.Add(scheduleReceiptPartCopy);       
    }  
}

public
void fillRedundances(){    
            
    for (int i=0;i < schedulePartDtlContainer.Count;i++){
        SchedulePartDtl schedulePartDtl = schedulePartDtlContainer[i];
        
        schedulePartDtl.HdrId = this.HdrId;
        schedulePartDtl.Detail = this.Detail;      
        schedulePartDtl.SubDetail = i + 1;                
    }

    for (int i=0;i < scheduleReceiptPartContainer.Count;i++){
        ScheduleReceiptPart scheduleReceiptPart = scheduleReceiptPartContainer[i];
        
        scheduleReceiptPart.HdrId = this.HdrId;
        scheduleReceiptPart.Detail = this.Detail;      
        scheduleReceiptPart.SubDetail = i+1;     
        
        scheduleReceiptPart.Part = this.Part;//used to show info on screen            
        scheduleReceiptPart.Seq = this.Seq;      
        scheduleReceiptPart.fillRedundances();
    }
    
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

[System.Runtime.Serialization.DataMember]
public
decimal RemainsQty {
	get { return Qty - QtyReported;}
	set { 	
        Notify("RemainsQty");              	
	}
}

public
void  calculateStartShift(){
    StartShift = DateUtil.getShiftNum(startDate);    
}

public
void  calculateEndShift(){
    EndShift = DateUtil.getShiftNum(endDate);    
}        

public
decimal calculateHourMachineBuild(){
    decimal dqty = HoursSubtract * (runStd != 0 ? runStd : 1);
    return dqty;
} 

public
DateTime calculateEndDataMachineBuild(){
    DateTime endDateTimeAux = startDate;
    decimal  dmins = Qty / (runStd != 0 ? runStd : 1);

    if (runStd!=0)
        dmins = dmins * 60;
        
    endDateTimeAux  = startDate.AddMinutes(Convert.ToInt32(dmins));

    return endDateTimeAux;
} 

} // class
} // package