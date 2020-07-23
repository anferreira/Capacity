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
class CapacityPartDtl : BusinessObject {

private int hdrId;
private int detail;
private int subDetail;
private int cPHdrID;
private int cPDtlID;
private string part;
private int seq;
private decimal qty;

#if !WEB
internal
#else
public
#endif
CapacityPartDtl(){
	this.hdrId = 0;
	this.detail = 0;
	this.subDetail = 0;
	this.cPHdrID = 0;
	this.cPDtlID = 0;
	this.part = "";
    this.seq = 0;
	this.qty = 0;
}

internal
CapacityPartDtl(
	int hdrId,
	int detail,
	int subDetail,
	int cPHdrID,
	int cPDtlID,
	string part,
    int seq,
	decimal qty)
{
	this.hdrId = hdrId;
	this.detail = detail;
	this.subDetail = subDetail;
	this.cPHdrID = cPHdrID;
	this.cPDtlID = cPDtlID;
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
int CPHdrID {
	get { return cPHdrID;}
	set { if (this.cPHdrID != value){
			this.cPHdrID = value;
			Notify("CPHdrID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int CPDtlID {
	get { return cPDtlID;}
	set { if (this.cPDtlID != value){
			this.cPDtlID = value;
			Notify("CPDtlID");
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
	if (obj is CapacityPartDtl)
		return	this.hdrId.Equals(((CapacityPartDtl)obj).HdrId) &&
				this.detail.Equals(((CapacityPartDtl)obj).Detail) &&
				this.subDetail.Equals(((CapacityPartDtl)obj).SubDetail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(CapacityPartDtl capacityPartDtl){
	this.HdrId=capacityPartDtl.HdrId;
	this.Detail=capacityPartDtl.Detail;
	this.SubDetail=capacityPartDtl.SubDetail;
	this.CPHdrID=capacityPartDtl.CPHdrID;
	this.CPDtlID=capacityPartDtl.CPDtlID;
	this.Part=capacityPartDtl.Part;
    this.Seq = capacityPartDtl.Seq;
	this.Qty=capacityPartDtl.Qty;	
}

} // class
} // package