/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.Cms{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class DemTransformD : BusinessObject {

private int hdrId;
private int detail;
private int demandHdr;
private int demandDetail;
private DateTime demDate;
private decimal qty;

private DemandD demandD;

#if !WEB
internal
#else
public
#endif
DemTransformD(){
	this.hdrId = 0;
	this.detail = 0;
	this.demandHdr = 0;
	this.demandDetail = 0;
	this.demDate = DateUtil.MinValue;
	this.qty = 0;
    this.demandD = demandD;
}

internal
DemTransformD(
	int hdrId,
	int detail,
	int demandHdr,
	int demandDetail,
	DateTime demDate,
	decimal qty)
{
	this.hdrId = hdrId;
	this.detail = detail;
	this.demandHdr = demandHdr;
	this.demandDetail = demandDetail;
	this.demDate = demDate;
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
int DemandHdr {
	get { return demandHdr;}
	set { if (this.demandHdr != value){
			this.demandHdr = value;
			Notify("DemandHdr");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int DemandDetail {
	get { return demandDetail;}
	set { if (this.demandDetail != value){
			this.demandDetail = value;
			Notify("DemandDetail");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime DemDate {
	get { return demDate;}
	set { if (this.demDate != value){
			this.demDate = value;
			Notify("DemDate");
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
	if (obj is DemTransformD)
		return	this.hdrId.Equals(((DemTransformD)obj).HdrId) &&
				this.detail.Equals(((DemTransformD)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

[System.Runtime.Serialization.DataMember]
public
DemandD DemandD {
	get { return demandD;}
	set { if (this.demandD != value){
			this.demandD = value;
			Notify("DemandD");
		}
	}
}

public
string PartShow {
	get { return demandD!= null ? demandD.Part : ""; }
	set {
        if (this.demandD != null && demandD.Part != value){
            demandD.Part = value;
			Notify("PartShow");
		}
	}
}

} // class
} // package