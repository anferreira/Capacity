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
class CapacityReq : BusinessObject {

private int hdrId;
private int detail;
private int subDetail;
private string type;
private int reqID;
private decimal time;
private decimal hours;
private int totEmployees;
private decimal employeeHours;

private string nameShow="";

public const string REQUIREMENT_MACHINE = "M";
public const string REQUIREMENT_TOOL = "T";
public const string REQUIREMENT_LABOUR = "L";
public const string REQUIREMENT_TASK = "K";

#if !WEB
        internal
#else
public
#endif
CapacityReq(){
	this.hdrId = 0;
	this.detail = 0;
	this.subDetail = 0;
	this.type = "";
	this.reqID = 0;
	this.time = 0;
	this.hours = 0;
    this.totEmployees = 0;
    this.employeeHours = 0;
}

internal
CapacityReq(
	int hdrId,
	int detail,
	int subDetail,
	string type,
	int reqID,
	decimal time,
	decimal hours,
    int totEmployees,
    decimal employeeHours){
	this.hdrId = hdrId;
	this.detail = detail;
	this.subDetail = subDetail;
	this.type = type;
	this.reqID = reqID;
	this.time = time;
	this.hours = hours;

    this.totEmployees = totEmployees;
    this.employeeHours = employeeHours;
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
int ReqID {
	get { return reqID;}
	set { if (this.reqID != value){
			this.reqID = value;
			Notify("ReqID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Time {
	get { return time;}
	set { if (this.time != value){
			this.time = value;
			Notify("Time");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Hours {
	get { return hours;}
	set { if (this.hours != value){
			this.hours = value;
			Notify("Hours");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int TotEmployees {
	get { return totEmployees; }
	set { if (this.totEmployees != value){
			this.totEmployees = value;
			Notify("TotEmployees");
		}
	}
}
    
[System.Runtime.Serialization.DataMember]
public
decimal EmployeeHours {
	get { return employeeHours; }
	set { if (this.employeeHours != value){
			this.employeeHours = value;
			Notify("EmployeeHours");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string NameShow {
	get { return nameShow; }
	set { if (this.nameShow != value){
			this.nameShow = value;
			Notify("NameShow");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is CapacityReq)
		return	this.hdrId.Equals(((CapacityReq)obj).HdrId) &&
				this.detail.Equals(((CapacityReq)obj).Detail) &&
				this.subDetail.Equals(((CapacityReq)obj).SubDetail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(CapacityReq capacityReq){	
	this.HdrId=capacityReq.HdrId;
	this.Detail=capacityReq.Detail;
	this.SubDetail=capacityReq.SubDetail;
	this.Type=capacityReq.Type;
	this.ReqID=capacityReq.ReqID;
	this.Time=capacityReq.Time;
	this.Hours=capacityReq.Hours;
    this.TotEmployees=capacityReq.TotEmployees;
    this.EmployeeHours=capacityReq.EmployeeHours;	
}

} // class
} // package