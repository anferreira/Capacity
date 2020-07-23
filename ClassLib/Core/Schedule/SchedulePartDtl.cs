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
class SchedulePartDtl : BusinessObject {

private int hdrId;
private int detail;
private int subDetail;
private string part;
private int seq;
private decimal qty;

#if !WEB
internal
#else
public
#endif
SchedulePartDtl(){
	this.hdrId = 0;
	this.detail = 0;
	this.subDetail = 0;    
    this.part = "";
	this.seq = 0;
	this.qty = 0;
}

internal
SchedulePartDtl(
	int hdrId,
	int detail,
	int subDetail,
    int subSubdDetail,
    string part,
	int seq,
	decimal qty)
{
	this.hdrId = hdrId;
	this.detail = detail;
	this.subDetail = subDetail;    
    this.part = part;
	this.seq = seq;
	this.qty = qty;
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
decimal Qty {
	get { return qty;}
	set { if (this.qty != value){
			this.qty = value;
			Notify("Qty");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is SchedulePartDtl)
		return	this.hdrId.Equals(((SchedulePartDtl)obj).HdrId) &&
				this.detail.Equals(((SchedulePartDtl)obj).Detail) &&
				this.subDetail.Equals(((SchedulePartDtl)obj).SubDetail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(SchedulePartDtl schedulePartDtl){	
	this.HdrId=schedulePartDtl.HdrId;
	this.Detail=schedulePartDtl.Detail;
	this.SubDetail=schedulePartDtl.SubDetail;    
	this.Part=schedulePartDtl.Part;
	this.Seq=schedulePartDtl.Seq;
	this.Qty=schedulePartDtl.Qty;	
}

} // class
} // package