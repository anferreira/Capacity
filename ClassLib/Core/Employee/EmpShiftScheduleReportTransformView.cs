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
class EmpShiftScheduleReportTransformView : BusinessObject {

private EmpShiftScheduleReportView empShiftScheduleReportView1;
private EmpShiftScheduleReportView empShiftScheduleReportView2;

#if !WEB
internal
#else
public
#endif
EmpShiftScheduleReportTransformView(){
	empShiftScheduleReportView1 = new EmpShiftScheduleReportView();
    empShiftScheduleReportView2 = new EmpShiftScheduleReportView();	
}

internal
EmpShiftScheduleReportTransformView(
    EmpShiftScheduleReportView empShiftScheduleReportView1,
    EmpShiftScheduleReportView empShiftScheduleReportView2){
	this.empShiftScheduleReportView1 = empShiftScheduleReportView1;
	this.empShiftScheduleReportView2 = empShiftScheduleReportView2;	
}

[System.Runtime.Serialization.DataMember]
public
EmpShiftScheduleReportView EmpShiftScheduleReportView1{
	get { return empShiftScheduleReportView1; }
	set { 
        empShiftScheduleReportView1=value;
	}
}

[System.Runtime.Serialization.DataMember]
public
EmpShiftScheduleReportView EmpShiftScheduleReportView2{
	get { return empShiftScheduleReportView2; }
	set { 
        empShiftScheduleReportView2=value;
	}
}

[System.Runtime.Serialization.DataMember]
public
int Id1 {
	get { return empShiftScheduleReportView1.Id; }
	set { 
        empShiftScheduleReportView1.Id=value;
	}
}

[System.Runtime.Serialization.DataMember]
public
int Id2 {
	get { return empShiftScheduleReportView2.Id; }
	set { 
        empShiftScheduleReportView2.Id=value;
	}
}

[System.Runtime.Serialization.DataMember]
public
int Detail1 {
	get { return empShiftScheduleReportView1.Detail; }
	set { 
        empShiftScheduleReportView1.Detail = value;
	}
}

[System.Runtime.Serialization.DataMember]
public
int Detail2 {
	get { return empShiftScheduleReportView2.Detail; }
	set { 
        empShiftScheduleReportView2.Detail = value;
	}
}

[System.Runtime.Serialization.DataMember]
public
string Dept1 {
	get { return empShiftScheduleReportView1.Dept; }
	set { 
        empShiftScheduleReportView1.Dept = value;
	}
}

[System.Runtime.Serialization.DataMember]
public
string Dept2 {
	get { return empShiftScheduleReportView2.Dept; }
	set { 
        empShiftScheduleReportView2.Dept = value;
	}
}

[System.Runtime.Serialization.DataMember]
public
int ShiftNum {
	get { return empShiftScheduleReportView1.ShiftNum; }
	set { 
        empShiftScheduleReportView1.ShiftNum = value;
	}
}

[System.Runtime.Serialization.DataMember]
public
int ShiftNum2 {
	get { return empShiftScheduleReportView2.ShiftNum; }
	set { 
        empShiftScheduleReportView2.ShiftNum = value;
	}
}

[System.Runtime.Serialization.DataMember]
public
string EmpId1 {
	get { return empShiftScheduleReportView1.EmpId; }
	set { 
        empShiftScheduleReportView1.EmpId = value;
	}
}

[System.Runtime.Serialization.DataMember]
public
string EmpId2 {
	get { return empShiftScheduleReportView2.EmpId; }
	set { 
        empShiftScheduleReportView2.EmpId = value;
	}
}

[System.Runtime.Serialization.DataMember]
public
string FullName1{
	get { return empShiftScheduleReportView1.LastName + "," + empShiftScheduleReportView1.FirstName; }
	set { 
	}
}

[System.Runtime.Serialization.DataMember]
public
string FullName2{
	get {
        if (string.IsNullOrEmpty(empShiftScheduleReportView2.LastName) && string.IsNullOrEmpty(empShiftScheduleReportView2.FirstName))
            return "";                     
        else
            return empShiftScheduleReportView2.LastName + "," + empShiftScheduleReportView2.FirstName;
    }set { 
	}
}

[System.Runtime.Serialization.DataMember]
public
string Mach1 {
	get { return empShiftScheduleReportView1.Mach; }
	set { 
        empShiftScheduleReportView1.Mach = value;
	}
}

[System.Runtime.Serialization.DataMember]
public
string Mach2 {
	get { return empShiftScheduleReportView2.Mach; }
	set { 
        empShiftScheduleReportView2.Mach = value;
	}
}

public override
bool Equals(object obj){
	if (obj is EmpShiftScheduleReportTransformView)
		return	this.Id1.Equals(((EmpShiftScheduleReportTransformView)obj).Id1) &&
                this.Id2.Equals(((EmpShiftScheduleReportTransformView)obj).Id2) &&
                this.Detail1.Equals(((EmpShiftScheduleReportTransformView)obj).Detail1) &&
                this.Detail2.Equals(((EmpShiftScheduleReportTransformView)obj).Detail2);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package