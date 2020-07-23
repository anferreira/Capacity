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
class EmployeeShift : BusinessObject {

private int id;
private string plant;
private int shiftNum;
private DateTime startDate;
private DateTime endDate;
private string empId;
private string status;
private string monWork;
private string tueWork;
private string wedWork;
private string thuWork;
private string friWork;
private string satWork;
private string sunWork;

#if !WEB
internal
#else
public
#endif
EmployeeShift(){
	this.id = 0;
	this.plant = "";
	this.shiftNum = 0;
	this.startDate = DateUtil.MinValue;
	this.endDate = DateUtil.MinValue;
	this.empId = "";
	this.status = "";
	this.monWork = "";
	this.tueWork = "";
	this.wedWork = "";
	this.thuWork = "";
	this.friWork = "";
	this.satWork = "";
	this.sunWork = "";
}

internal
EmployeeShift(
	int id,
	string plant,
	int shiftNum,
	DateTime startDate,
	DateTime endDate,
	string empId,
	string status,
	string monWork,
	string tueWork,
	string wedWork,
	string thuWork,
	string friWork,
	string satWork,
	string sunWork)
{
	this.id = id;
	this.plant = plant;
	this.shiftNum = shiftNum;
	this.startDate = startDate;
	this.endDate = endDate;
	this.empId = empId;
	this.status = status;
	this.monWork = monWork;
	this.tueWork = tueWork;
	this.wedWork = wedWork;
	this.thuWork = thuWork;
	this.friWork = friWork;
	this.satWork = satWork;
	this.sunWork = sunWork;
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
string Plant {
	get { return plant;}
	set { if (this.plant != value){
			this.plant = value;
			Notify("Plant");
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
string Status {
	get { return status;}
	set { if (this.status != value){
			this.status = value;
			Notify("Status");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MonWork {
	get { return monWork;}
	set { if (this.monWork != value){
			this.monWork = value;
			Notify("MonWork");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string TueWork {
	get { return tueWork;}
	set { if (this.tueWork != value){
			this.tueWork = value;
			Notify("TueWork");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string WedWork {
	get { return wedWork;}
	set { if (this.wedWork != value){
			this.wedWork = value;
			Notify("WedWork");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ThuWork {
	get { return thuWork;}
	set { if (this.thuWork != value){
			this.thuWork = value;
			Notify("ThuWork");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FriWork {
	get { return friWork;}
	set { if (this.friWork != value){
			this.friWork = value;
			Notify("FriWork");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string SatWork {
	get { return satWork;}
	set { if (this.satWork != value){
			this.satWork = value;
			Notify("SatWork");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string SunWork {
	get { return sunWork;}
	set { if (this.sunWork != value){
			this.sunWork = value;
			Notify("SunWork");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is EmployeeShift)
		return	this.id.Equals(((EmployeeShift)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package