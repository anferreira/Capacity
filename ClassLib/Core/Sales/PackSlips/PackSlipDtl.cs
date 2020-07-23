/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.Sales.PackSlips{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class PackSlipDtl : BusinessObject {

private int hdrId;
private int detail;
private int externalDetail;
private string part;
private string custPart;
private decimal shipQty;
private decimal fGCurCum;
private decimal fGPrevCum;

#if !WEB
internal
#else
public
#endif
PackSlipDtl(){
	this.hdrId = 0;
	this.detail = 0;
	this.externalDetail = 0;
	this.part = "";
	this.custPart = "";
	this.shipQty = 0;
	this.fGCurCum = 0;
	this.fGPrevCum = 0;
}

internal
PackSlipDtl(
	int hdrId,
	int detail,
	int externalDetail,
	string part,
	string custPart,
	decimal shipQty,
	decimal fGCurCum,
	decimal fGPrevCum)
{
	this.hdrId = hdrId;
	this.detail = detail;
	this.externalDetail = externalDetail;
	this.part = part;
	this.custPart = custPart;
	this.shipQty = shipQty;
	this.fGCurCum = fGCurCum;
	this.fGPrevCum = fGPrevCum;
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
int ExternalDetail {
	get { return externalDetail;}
	set { if (this.externalDetail != value){
			this.externalDetail = value;
			Notify("ExternalDetail");
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
string CustPart {
	get { return custPart;}
	set { if (this.custPart != value){
			this.custPart = value;
			Notify("CustPart");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal ShipQty {
	get { return shipQty;}
	set { if (this.shipQty != value){
			this.shipQty = value;
			Notify("ShipQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGCurCum {
	get { return fGCurCum;}
	set { if (this.fGCurCum != value){
			this.fGCurCum = value;
			Notify("FGCurCum");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGPrevCum {
	get { return fGPrevCum;}
	set { if (this.fGPrevCum != value){
			this.fGPrevCum = value;
			Notify("FGPrevCum");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is PackSlipDtl)
		return	this.hdrId.Equals(((PackSlipDtl)obj).HdrId) &&
				this.detail.Equals(((PackSlipDtl)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package