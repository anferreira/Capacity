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
class PlannedPart : BusinessObject {

private int hdrId;
private int detail;
private int subDetail;
private string part;
private int seq;
private string isFamily;
private decimal qtyOriginal;
private decimal qtyPlanned;
private decimal qtyChange;
private decimal qtyOvertime;
private DateTime startDate;
private DateTime endDate;

private int profMachPlanHdrId;
private int profMachPlanHdrDtl;

private decimal hoursShow=0;

#if !WEB
internal
#else
public
#endif
PlannedPart(){
	this.hdrId = 0;
	this.detail = 0;
	this.subDetail = 0;
	this.part = "";
	this.seq = 0;
	this.isFamily = "";
	this.qtyOriginal = 0;
	this.qtyPlanned = 0;
    this.qtyChange = 0;
    this.qtyOvertime = 0;
    this.startDate = DateUtil.MinValue;
	this.endDate = DateUtil.MinValue;

    this.profMachPlanHdrId =0;
    this.profMachPlanHdrDtl=0;
}

internal
PlannedPart(
	int hdrId,
	int detail,
	int subDetail,
	string part,
	int seq,
	string isFamily,
	decimal qtyOriginal,
	decimal qtyPlanned,
    decimal qtyChange,
    decimal qtyOvertime,
    DateTime startDate,
	DateTime endDate,
    int profMachPlanHdrId,
    int profMachPlanHdrDtl){
	this.hdrId = hdrId;
	this.detail = detail;
	this.subDetail = subDetail;
	this.part = part;
	this.seq = seq;
	this.isFamily = isFamily;
	this.qtyOriginal = qtyOriginal;
	this.qtyPlanned = qtyPlanned;
    this.qtyChange = qtyChange;
    this.qtyOvertime = qtyOvertime;
    this.startDate = startDate;
	this.endDate = endDate;
    this.profMachPlanHdrId=0;
    this.profMachPlanHdrDtl = 0;
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
	get { return seq;}
	set { if (this.seq != value){
			this.seq = value;
			Notify("Seq");
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
decimal QtyOriginal {
	get { return qtyOriginal;}
	set { if (this.qtyOriginal != value){
			this.qtyOriginal = value;
			Notify("QtyOriginal");
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

[System.Runtime.Serialization.DataMember]
public
decimal QtyChange {
	get { return qtyChange; }
	set { if (this.qtyChange != value){
			this.qtyChange = value;
			Notify("QtyChange");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyOvertime {
	get { return qtyOvertime; }
	set { if (this.qtyOvertime != value){
			this.qtyOvertime = value;
			Notify("QtyOvertime");
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
decimal HoursShow {
	get { return hoursShow;}
	set { if (this.hoursShow != value){
			this.hoursShow = value;
			Notify("HoursShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int ProfMachPlanHdrId {
	get { return profMachPlanHdrId; }
	set { if (this.profMachPlanHdrId != value){
			this.profMachPlanHdrId = value;
			Notify("ProfMachPlanHdrId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int ProfMachPlanHdrDtl {
	get { return profMachPlanHdrDtl; }
	set { if (this.profMachPlanHdrDtl != value){
			this.profMachPlanHdrDtl = value;
			Notify("ProfMachPlanHdrDtl");
		}
	}
}
  
public override
bool Equals(object obj){
	if (obj is PlannedPart)
		return	this.hdrId.Equals(((PlannedPart)obj).HdrId) &&
				this.detail.Equals(((PlannedPart)obj).Detail) &&
				this.subDetail.Equals(((PlannedPart)obj).SubDetail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(PlannedPart plannedPart){
	this.HdrId=plannedPart.HdrId;
	this.Detail=plannedPart.Detail;
	this.SubDetail=plannedPart.SubDetail;
	this.Part=plannedPart.Part;
	this.Seq=plannedPart.Seq;
	this.IsFamily=plannedPart.IsFamily;
	this.QtyOriginal=plannedPart.QtyOriginal;
	this.QtyPlanned=plannedPart.QtyPlanned;
    this.QtyChange = plannedPart.QtyChange;
    this.QtyOvertime = plannedPart.QtyOvertime;
    this.StartDate=plannedPart.StartDate;
	this.EndDate=plannedPart.EndDate;	
}

} // class
} // package