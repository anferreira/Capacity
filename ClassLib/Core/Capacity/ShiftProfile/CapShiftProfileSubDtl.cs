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
class CapShiftProfileSubDtl : BusinessObject {

private int id;
private int hdrId;
private int detail;
private int subDetail;
private string type;
private int reqId;
private int totEmployees;

#if !WEB
internal
#else
public
#endif
CapShiftProfileSubDtl(){
	this.id = 0;
	this.hdrId = 0;
	this.detail = 0;
	this.subDetail = 0;
	this.type = "";
	this.reqId = 0;
	this.totEmployees = 0;
}

internal
CapShiftProfileSubDtl(
	int id,
	int hdrId,
	int detail,
	int subDetail,
	string type,
	int reqId,
	int totEmployees)
{
	this.id = id;
	this.hdrId = hdrId;
	this.detail = detail;
	this.subDetail = subDetail;
	this.type = type;
	this.reqId = reqId;
	this.totEmployees = totEmployees;
}

[System.Runtime.Serialization.DataMember]
public
int Id {
	get { return id;}
	set { if (this.id != value){
			this.id = value;
			Notify("Id");
		}
	}
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
string Type {
	get { return type;}
	set { if (this.type != value){
			this.type = value;
			Notify("Type");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int ReqId {
	get { return reqId;}
	set { if (this.reqId != value){
			this.reqId = value;
			Notify("ReqId");
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

public override
bool Equals(object obj){
	if (obj is CapShiftProfileSubDtl)
		return	this.hdrId.Equals(((CapShiftProfileSubDtl)obj).HdrId) &&
				this.detail.Equals(((CapShiftProfileSubDtl)obj).Detail) &&
				this.subDetail.Equals(((CapShiftProfileSubDtl)obj).SubDetail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package