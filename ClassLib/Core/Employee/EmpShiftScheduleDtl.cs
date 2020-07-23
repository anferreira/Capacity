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
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class EmpShiftScheduleDtl : BusinessObject {

private int hdrId;
private int detail;
private string empId;
private int machId;
private int labourTypeId;
private decimal labMultiplier;
private string absent;

private string machineShow="";
private string machineDescShow="";
private string labourTypeShow="";
private string empFirstNameShow="";
private string empLastNameShow="";

#if !WEB
internal
#else
public
#endif
EmpShiftScheduleDtl(){
	this.hdrId = 0;
	this.detail = 0;
	this.empId = "";
	this.machId = 0;
	this.labourTypeId = 0;
    this.labMultiplier = 0;
    this.absent = Constants.STRING_NO;
}

internal
EmpShiftScheduleDtl(
	int hdrId,
	int detail,
	string empId,
	int machId,
	int labourTypeId,
    decimal labMultiplier,
    string absent){
	this.hdrId = hdrId;
	this.detail = detail;
	this.empId = empId;
	this.machId = machId;
	this.labourTypeId = labourTypeId;
    this.labMultiplier = labMultiplier;
    this.absent = absent;
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
decimal LabMultiplier {
	get { return labMultiplier; }
	set { if (this.labMultiplier != value){
			this.labMultiplier = value;
			Notify("LabMultiplier");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MachineShow {
	get { return machineShow; }
	set { if (this.machineShow != value){
			this.machineShow = value;
			Notify("MachineShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MachineDescShow {
	get { return machineDescShow; }
	set { if (this.machineDescShow != value){
			this.machineDescShow = value;
			Notify("MachineDescShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string LabourTypeShow {
	get { return labourTypeShow; }
	set { if (this.labourTypeShow != value){
			this.labourTypeShow = value;
			Notify("LabourTypeShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string EmpFirstNameShow {
	get { return empFirstNameShow; }
	set { if (this.empFirstNameShow != value){
			this.empFirstNameShow = value;
			Notify("EmpFirstNameShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string EmpLastNameShow {
	get { return empLastNameShow; }
	set { if (this.empLastNameShow != value){
			this.empLastNameShow = value;
			Notify("EmpLastNameShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Absent {
	get { return absent; }
	set { if (this.absent != value){
			this.absent = value;
			Notify("Absent");
		}
	}
}

public
void copy(EmpShiftScheduleDtl empShiftScheduleDtl){
	this.HdrId=empShiftScheduleDtl.HdrId;
	this.Detail=empShiftScheduleDtl.Detail;
	this.EmpId=empShiftScheduleDtl.EmpId;
	this.MachId=empShiftScheduleDtl.MachId;
	this.LabourTypeId=empShiftScheduleDtl.LabourTypeId;
    this.LabMultiplier=empShiftScheduleDtl.LabMultiplier;	
    this.Absent = empShiftScheduleDtl.Absent;

    this.MachineShow        =empShiftScheduleDtl.MachineShow;
    this.MachineDescShow    =empShiftScheduleDtl.MachineDescShow;
    this.LabourTypeShow     =empShiftScheduleDtl.LabourTypeShow;
    this.EmpFirstNameShow   =empShiftScheduleDtl.EmpFirstNameShow;
    this.EmpLastNameShow    =empShiftScheduleDtl.EmpLastNameShow;
}

public override
bool Equals(object obj){
	if (obj is EmpShiftScheduleDtl)
		return	this.hdrId.Equals(((EmpShiftScheduleDtl)obj).HdrId) &&
				this.detail.Equals(((EmpShiftScheduleDtl)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package