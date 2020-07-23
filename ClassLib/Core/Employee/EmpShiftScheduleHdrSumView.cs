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
class EmpShiftScheduleHdrSumView : BusinessObject {

private DateTime date;
private int shiftNum;
private int employeeCount;

#if !WEB
internal
#else
public
#endif
EmpShiftScheduleHdrSumView(){
	this.date = DateUtil.MinValue;
	this.shiftNum = 0;
    this.employeeCount  =0;            	
}

internal
EmpShiftScheduleHdrSumView(
	DateTime date,
	int shiftNum,
    int employeeCount){
	this.date = date;
	this.shiftNum = shiftNum;
	this.employeeCount = employeeCount;
}

[System.Runtime.Serialization.DataMember]
public
DateTime Date {
	get { return date;}
	set { if (this.date != value){
			this.date = value;
			Notify("Date");
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
int EmployeeCount {
	get { return employeeCount;}
	set { if (this.employeeCount != value){
			this.employeeCount = value;
			Notify("EmployeeCount");
		}
	}
}


} // class
} // package