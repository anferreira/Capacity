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
class CapacityPart : BusinessObject {

private int hdrId;
private int detail;
private int hotListID;
private string part;
private string isFamily;
private int seq;
private decimal qty;
private DateTime startDate;
private DateTime endDate;
private string plant;
private string dept;
private decimal qtyPlanned;

private CapacityPartDtlContainer capacityPartDtlContainer;
private CapacityReqContainer capacityReqContainer;

#if !WEB
internal
#else
public
#endif
CapacityPart(){
	this.hdrId = 0;
	this.detail = 0;
	this.hotListID = 0;
	this.part = "";
	this.isFamily = Nujit.NujitERP.ClassLib.Common.Constants.STRING_NO;
	this.seq = 0;
	this.qty = 0;
	this.startDate = DateUtil.MinValue;
	this.endDate = DateUtil.MinValue;
    this.plant = "";
    this.dept = "";
    this.qtyPlanned = 0;
    this.capacityPartDtlContainer = new CapacityPartDtlContainer();
    this.capacityReqContainer = new CapacityReqContainer();
}

internal
CapacityPart(
	int hdrId,
	int detail,
	int hotListID,
	string part,
	string isFamily,
	int seq,
	decimal qty,
	DateTime startDate,
	DateTime endDate,
    string plant,
    string dept,
    decimal qtyPlanned){
	this.hdrId = hdrId;
	this.detail = detail;
	this.hotListID = hotListID;
	this.part = part;
	this.isFamily = isFamily;
	this.seq = seq;
	this.qty = qty;
	this.startDate = startDate;
	this.endDate = endDate;
    this.plant = plant;
    this.dept = dept;
    this.qtyPlanned = qtyPlanned;
    this.capacityPartDtlContainer = new CapacityPartDtlContainer();
    this.capacityReqContainer = new CapacityReqContainer();
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
int HotListID {
	get { return hotListID;}
	set { if (this.hotListID != value){
			this.hotListID = value;
			Notify("HotListID");
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
			Notify("Qty");
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
string Plant {
	get { return plant; }
	set { if (this.plant != value){
			this.plant = value;
			Notify("Plant");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Dept {
	get { return dept; }
	set { if (this.dept != value){
			this.dept = value;
			Notify("Dept");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyPlanned {
	get { return qtyPlanned; }
	set { if (this.qtyPlanned != value){
			this.qtyPlanned = value;
			Notify("QtyPlanned");
		}
	}
}
       
public override
bool Equals(object obj){
	if (obj is CapacityPart)
		return	this.hdrId.Equals(((CapacityPart)obj).HdrId) &&
				this.detail.Equals(((CapacityPart)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

[System.Runtime.Serialization.DataMember]
public
CapacityPartDtlContainer CapacityPartDtlContainer{
	get { return capacityPartDtlContainer;}
	set { if (this.capacityPartDtlContainer != value){
			this.capacityPartDtlContainer = value;
			Notify("CapacityPartDtlContainer");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CapacityReqContainer CapacityReqContainer{
	get { return capacityReqContainer; }
	set { if (this.capacityReqContainer != value){
			this.capacityReqContainer = value;
			Notify("CapacityReqContainer");
		}
	}
}
        
public
void fillRedundances(){    
    for (int i=0;i < capacityPartDtlContainer.Count;i++){
        CapacityPartDtl capacityPartDtl = capacityPartDtlContainer[i];
        
        capacityPartDtl.HdrId = this.HdrId;
        capacityPartDtl.Detail =this.Detail;        
        capacityPartDtl.SubDetail = i+1;
    }

    for (int i=0;i < capacityReqContainer.Count;i++){
        CapacityReq capacityReq = capacityReqContainer[i];
        
        capacityReq.HdrId = this.HdrId;
        capacityReq.Detail =this.Detail;        
        capacityReq.SubDetail = i+1;
    }
}

public
void copy(CapacityPart capacityPart){
    this.HdrId=capacityPart.HdrId;
	this.Detail=capacityPart.Detail;
	this.HotListID=capacityPart.HotListID;
	this.Part=capacityPart.Part;
	this.IsFamily=capacityPart.IsFamily;
	this.Seq=capacityPart.Seq;
	this.Qty=capacityPart.Qty;
	this.StartDate=capacityPart.StartDate;
	this.EndDate=capacityPart.EndDate;
    this.Plant=capacityPart.Plant;
    this.Dept=capacityPart.Dept;
    this.QtyPlanned = capacityPart.QtyPlanned;   

    capacityPartDtlContainer.Clear();
    foreach(CapacityPartDtl capacityPartDtl in capacityPart.CapacityPartDtlContainer){
        CapacityPartDtl capacityPartDtlNew = new CapacityPartDtl(); 
        capacityPartDtlNew.copy(capacityPartDtl);
        this.CapacityPartDtlContainer.Add(capacityPartDtlNew);
    }

    capacityReqContainer.Clear();
    foreach(CapacityReq capacityReq in capacityPart.CapacityReqContainer){
        CapacityReq capacityReqNew = new CapacityReq(); 
        capacityReqNew.copy(capacityReq);
        this.CapacityReqContainer.Add(capacityReqNew);
    }
}

} // class
} // package