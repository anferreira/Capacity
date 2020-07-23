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

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class LabourTypeRequired : HotListDays {

private int id;
private string code;
private string labName;
private string dirInd;
private decimal totEmployees;

#if !WEB
internal
#else
public
#endif
LabourTypeRequired() : base(){
	this.id = 0;
	this.code = "";
	this.labName = "";
	this.dirInd = Constants.TASK_INDIRECT;
    this.totEmployees = 0;
}

internal
LabourTypeRequired(
	int id,
	string code,
	string labName,
	string dirInd,
    decimal totEmployees) : base(){

	this.id = id;
	this.code = code;
	this.labName = labName;
	this.dirInd = dirInd;
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
string Code {
	get { return code;}
	set { if (this.code != value){
			this.code = value;
			Notify("Code");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string LabName {
	get { return labName;}
	set { if (this.labName != value){
			this.labName = value;
			Notify("LabName");
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
decimal TotEmployees {
	get { return totEmployees;}
	set { if (this.totEmployees != value){
			this.totEmployees = value;
			Notify("TotEmployees");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is LabourTypeRequired)
		return	this.id.Equals(((LabourTypeRequired)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(LabourTypeRequired labourTypeRequired){	
	Id= labourTypeRequired.Id;
	Code= labourTypeRequired.Code;
	LabName= labourTypeRequired.LabName;
	DirInd= labourTypeRequired.DirInd;	
    TotEmployees = labourTypeRequired.TotEmployees;
}

} // class
} // package