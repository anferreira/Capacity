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

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class EmployeeLabour : BusinessObject {

private int id;
private string empId;
private int labourTypeId;

private DateTime approvDate;
private DateTime approvUntilDate;
private string  approvByEmpId;
private int     approvLevel;

#if !WEB
internal
#else
public
#endif
EmployeeLabour(){
	this.id = 0;
	this.empId = "";
	this.labourTypeId = 0;

    this.approvDate = DateUtil.MinValue;
    this.approvUntilDate = DateUtil.MinValue;
    this.approvByEmpId = "";
    this.approvLevel=0;
}

internal
EmployeeLabour(
	int id,
	string empId,
	int labourTypeId,
    DateTime approvDate,
    DateTime approvUntilDate,
    string approvByEmpId,
    int approvLevel){
	this.id = id;
	this.empId = empId;
	this.labourTypeId = labourTypeId;

    this.approvDate       = approvDate;
    this.approvUntilDate  = approvUntilDate;
    this.approvByEmpId    = approvByEmpId;
    this.approvLevel      = approvLevel;   
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
int LabourTypeId {
	get { return labourTypeId;}
	set { if (this.labourTypeId != value){
			this.labourTypeId = value;
			Notify("LabourTypeId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime ApprovDate {
	get { return approvDate; }
	set { if (this.approvDate != value){
			this.approvDate = value;
			Notify("ApprovDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime ApprovUntilDate {
	get { return approvUntilDate; }
	set { if (this.approvUntilDate != value){
			this.approvUntilDate = value;
			Notify("ApprovUntilDate");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
string ApprovByEmpId {
	get { return approvByEmpId; }
	set { if (this.approvByEmpId != value){
			this.approvByEmpId = value;
			Notify("ApprovByEmpId");
		}
	}
}
  
[System.Runtime.Serialization.DataMember]
public
int ApprovLevel {
	get { return approvLevel; }
	set { if (this.approvLevel != value){
			this.approvLevel = value;
			Notify("ApprovLevel");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is EmployeeLabour)
		return	this.id.Equals(((EmployeeLabour)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package