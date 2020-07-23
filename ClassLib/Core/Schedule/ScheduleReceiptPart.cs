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
class ScheduleReceiptPart : BusinessObject {

private int hdrId;
private int detail;
private int subDetail;
private DateTime startDate;
private DateTime recDate;
private int recShift;
private decimal recQty;
private decimal repQty;

private string part;//only used to show on screen
private int seq;

private ScheduleMaterialConsumPartContainer scheduleMaterialConsumPartContainer;

#if !WEB
internal
#else
public
#endif
ScheduleReceiptPart(){
	this.hdrId = 0;
	this.detail = 0;
	this.subDetail = 0;    
    this.startDate = DateUtil.MinValue;
    this.recDate = DateUtil.MinValue;
	this.recShift = 0;
	this.recQty = 0;
    this.repQty = 0;

    this.part = "";
    this.seq =0;        
    this.scheduleMaterialConsumPartContainer = new ScheduleMaterialConsumPartContainer();
}

internal
ScheduleReceiptPart(
	int hdrId,
	int detail,
	int subDetail,    
    DateTime startDate,
    DateTime recDate,
	int recShift,
	decimal recQty,
    decimal repQty){
	this.hdrId = hdrId;
	this.detail = detail;
	this.subDetail = subDetail;    
    this.startDate = startDate;
    this.recDate = recDate;
	this.recShift = recShift;
	this.recQty = recQty;
    this.repQty = repQty;

    this.part = "";
    this.seq =0;     
    this.scheduleMaterialConsumPartContainer = new ScheduleMaterialConsumPartContainer();
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
int SubDetail {
	get { return subDetail;}
	set { if (this.subDetail != value){
			this.subDetail = value;
			Notify("SubDetail");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime StartDate {
	get { return startDate; }
	set { if (this.startDate != value){
			this.startDate = value;            
			Notify("StartDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime RecDate {
	get { return recDate;}
	set { if (this.recDate != value){
			this.recDate = value;
            calculateShift();
			Notify("RecDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int RecShift {
	get { return recShift;}
	set { if (this.recShift != value){
			this.recShift = value;
			Notify("RecShift");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RecQty {
	get { return recQty;}
	set { if (this.recQty != value){
			this.recQty = value;
            RemainsQty = RemainsQty;
			Notify("RecQty");            
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RepQty {
	get { return repQty; }
	set { if (this.repQty != value){
			this.repQty = value;
			RemainsQty = RemainsQty;
            Notify("RepQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RemainsQty {
	get { return RecQty- RepQty; }
	set { 		
         Notify("RemainsQty");
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
ScheduleMaterialConsumPartContainer ScheduleMaterialConsumPartContainer {
	get { return scheduleMaterialConsumPartContainer; }
	set { if (this.scheduleMaterialConsumPartContainer != value){
			this.scheduleMaterialConsumPartContainer = value;
			Notify("ScheduleMaterialConsumPartContainer");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is ScheduleReceiptPart)
		return	this.hdrId.Equals(((ScheduleReceiptPart)obj).HdrId) &&
				this.detail.Equals(((ScheduleReceiptPart)obj).Detail) &&
				this.subDetail.Equals(((ScheduleReceiptPart)obj).SubDetail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(ScheduleReceiptPart scheduleReceiptPart){
    this.HdrId=scheduleReceiptPart.HdrId;
	this.Detail=scheduleReceiptPart.Detail;
	this.SubDetail=scheduleReceiptPart.SubDetail;    
    this.StartDate = scheduleReceiptPart.StartDate;
    this.RecDate=scheduleReceiptPart.RecDate;
	this.RecShift=scheduleReceiptPart.RecShift;
	this.RecQty=scheduleReceiptPart.RecQty;
    this.RepQty=scheduleReceiptPart.RepQty; 

    this.Part = scheduleReceiptPart.Part;
    this.Seq = scheduleReceiptPart.Seq;

    this.ScheduleMaterialConsumPartContainer.Clear();
    foreach(ScheduleMaterialConsumPart scheduleMaterialConsumPart in scheduleReceiptPart.ScheduleMaterialConsumPartContainer){
        ScheduleMaterialConsumPart scheduleMaterialConsumPartCopy = new ScheduleMaterialConsumPart();
        scheduleMaterialConsumPartCopy.copy(scheduleMaterialConsumPart);
        this.ScheduleMaterialConsumPartContainer.Add(scheduleMaterialConsumPartCopy);
    }
}

public
void  calculateShift(){
    RecShift = DateUtil.getShiftNum(recDate);    
}

public
void fillRedundances(){                 
    for (int i=0;i < scheduleMaterialConsumPartContainer.Count;i++){
        ScheduleMaterialConsumPart scheduleMaterialConsumPart = scheduleMaterialConsumPartContainer[i];        
        scheduleMaterialConsumPart.HdrId = this.HdrId;
        scheduleMaterialConsumPart.Detail = this.Detail;      
        scheduleMaterialConsumPart.SubDetail = this.SubDetail;    
        scheduleMaterialConsumPart.SubSubDetail = i + 1;
        
        scheduleMaterialConsumPart.StartDate = this.StartDate;
    }    
}

} // class
} // package