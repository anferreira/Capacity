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
class CapShiftTask : BusinessObject {

private int id;
private string taskName;
private string dirInd;
private decimal ratePerHr;
private string manufactProcess;
private string empTempCanPerform;


#if !WEB
internal
#else
public
#endif
CapShiftTask(){
	this.id = 0;
	this.taskName = "";
	this.dirInd = "";
    this.ratePerHr = 0;
    this.manufactProcess = Constants.STRING_NO;
    this.empTempCanPerform = Constants.STRING_YES;
}

internal
CapShiftTask(
	int id,
	string taskName,
	string dirInd,
    decimal ratePerHr,
    string manufactProcess,
    string empTempCanPerform){
	this.id = id;
	this.taskName = taskName;
	this.dirInd = dirInd;
    this.ratePerHr = ratePerHr;
    this.manufactProcess = manufactProcess;
    this.empTempCanPerform = empTempCanPerform;
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
string TaskName {
	get { return taskName;}
	set { if (this.taskName != value){
			this.taskName = value;
			Notify("TaskName");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string DirInd {
	get { return dirInd;}
	set { if (this.dirInd != value){
			this.dirInd = value;
			Notify("DirInd");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RatePerHr {
	get { return ratePerHr; }
	set { if (this.ratePerHr != value){
			this.ratePerHr = value;
			Notify("ratePerHr");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ManufactProcess {
	get { return manufactProcess; }
	set { if (this.manufactProcess != value){
			this.manufactProcess = value;
			Notify("ManufactProcess");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string EmpTempCanPerform {
	get { return empTempCanPerform; }
	set { if (this.empTempCanPerform != value){
			this.empTempCanPerform = value;
			Notify("EmpTempCanPerform");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is CapShiftTask)
		return	this.id.Equals(((CapShiftTask)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public 
bool isOvertime(){
	bool bresult = !string.IsNullOrEmpty(TaskName) && TaskName.ToUpper().IndexOf("OVERTIME") >=0 ? true :false;
    return bresult;
}

public 
bool isTemp(){
	bool bresult = !string.IsNullOrEmpty(TaskName) && TaskName.ToUpper().IndexOf("TEMP") >=0 ? true :false;
    return bresult;
}

} // class
} // package