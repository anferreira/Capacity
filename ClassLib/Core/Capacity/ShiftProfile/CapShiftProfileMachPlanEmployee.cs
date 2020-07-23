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

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class CapShiftProfileMachPlanEmployee : BusinessObject {

private int hdrId;
private int detail;
private int subDetail;
private string empId;

private string empNameShow="";

#if !WEB
internal
#else
public
#endif
CapShiftProfileMachPlanEmployee(){
	this.hdrId = 0;
	this.detail = 0;
	this.subDetail = 0;
	this.empId = "";
}

internal
CapShiftProfileMachPlanEmployee(
	int hdrId,
	int detail,
	int subDetail,
	string empId)
{
	this.hdrId = hdrId;
	this.detail = detail;
	this.subDetail = subDetail;
	this.empId = empId;
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
string EmpId {
	get { return empId;}
	set { if (this.empId != value){
			this.empId = value;
			Notify("EmpId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string EmpNameShow {
	get { return empNameShow; }
	set { if (this.empNameShow != value){
			this.empNameShow = value;
			Notify("EmpNameShow");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is CapShiftProfileMachPlanEmployee)
		return	this.hdrId.Equals(((CapShiftProfileMachPlanEmployee)obj).HdrId) &&
				this.detail.Equals(((CapShiftProfileMachPlanEmployee)obj).Detail) &&
				this.subDetail.Equals(((CapShiftProfileMachPlanEmployee)obj).SubDetail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package