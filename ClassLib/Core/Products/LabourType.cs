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
class LabourType : BusinessObject {

private int id;
private string code;
private string labName;
private string dirInd;

#if !WEB
internal
#else
public
#endif
LabourType(){
	this.id = 0;
	this.code = "";
	this.labName = "";
	this.dirInd = Constants.TASK_INDIRECT;
}

internal
LabourType(
	int id,
	string code,
	string labName,
	string dirInd)
{
	this.id = id;
	this.code = code;
	this.labName = labName;
	this.dirInd = dirInd;
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

public override
bool Equals(object obj){
	if (obj is LabourType)
		return	this.id.Equals(((LabourType)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(LabourType labourType){	
	Id=labourType.Id;
	Code=labourType.Code;
	LabName=labourType.LabName;
	DirInd=labourType.DirInd;	
}

public 
bool isOvertime(){
	bool bresult = !string.IsNullOrEmpty(LabName) && LabName.ToUpper().IndexOf("OVERTIME") >=0 ? true :false;
    return bresult;
}

public 
bool isTemp(){
	bool bresult = !string.IsNullOrEmpty(LabName) && LabName.ToUpper().IndexOf("TEMP") >=0 ? true :false;
    return bresult;
}

} // class
} // package