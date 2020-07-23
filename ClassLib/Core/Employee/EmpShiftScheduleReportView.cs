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
class EmpShiftScheduleReportView : BusinessObject {

private int id;
private int detail;
private string dept;
private int shiftNum;
private string empId;
private string firstName;
private string lastName;
private int machId;
private string mach;
private string machDesc;
private int priority;
private string empFullList;


#if !WEB
internal
#else
public
#endif
EmpShiftScheduleReportView(){
	this.id = 0;
	this.detail = 0;
	this.dept = "";
	this.shiftNum = 0;
	this.empId = "";
	this.firstName = "";
	this.lastName = "";
	this.machId = 0;    
	this.mach = "";
    this.machDesc = "";
    this.priority = 0;
    this.empFullList = "";
}

internal
EmpShiftScheduleReportView(
	int id,
	int detail,
	string dept,
	int shiftNum,
	string empId,
	string firstName,
	string lastName,
	int machId,
	string mach,
    string machDesc,
    int priority,
    string empFullList){
	this.id = id;
	this.detail = detail;
	this.dept = dept;
	this.shiftNum = shiftNum;
	this.empId = empId;
	this.firstName = firstName;
	this.lastName = lastName;
	this.machId = machId;
	this.mach = mach;
    this.machDesc = machDesc;
    this.priority = priority;
    this.empFullList = empFullList;
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
string Dept {
	get { return dept;}
	set { if (this.dept != value){
			this.dept = value;
			Notify("Dept");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int ShiftNum {
	get { return shiftNum;}
	set { if (this.shiftNum != value){
			this.shiftNum = value;
			Notify("ShiftNum");
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
string FirstName {
	get { return firstName;}
	set { if (this.firstName != value){
			this.firstName = value;
			Notify("FirstName");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string LastName {
	get { return lastName;}
	set { if (this.lastName != value){
			this.lastName = value;
			Notify("LastName");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int MachId {
	get { return machId;}
	set { if (this.machId != value){
			this.machId = value;
			Notify("MachId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Mach {
	get { return mach;}
	set { if (this.mach != value){
			this.mach = value;
			Notify("Mach");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MachDesc {
	get { return machDesc; }
	set { if (this.machDesc != value){
			this.machDesc = value;
			Notify("MachDesc");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int Priority {
	get { return priority; }
	set { if (this.priority != value){
			this.priority = value;
			Notify("Priority");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string EmpFullList {
	get { return empFullList;}
	set { if (this.empFullList != value){
			this.empFullList = value;
			Notify("EmpFullList");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FullName{
	get { return LastName  + "," + FirstName; }
	set { 
	}
}

public override
bool Equals(object obj){
	if (obj is EmpShiftScheduleReportView)
		return	this.id.Equals(((EmpShiftScheduleReportView)obj).Id) &&
				this.detail.Equals(((EmpShiftScheduleReportView)obj).Detail) &&
                this.machId.Equals(((EmpShiftScheduleReportView)obj).MachId);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package