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
class EmpShiftScheduleDtlView : EmpShiftScheduleDtl {

private string empFirstName;
private string empLastName;

#if !WEB
internal
#else
public
#endif
EmpShiftScheduleDtlView() : base(){
    init();
}

public
EmpShiftScheduleDtlView(EmpShiftScheduleDtl empShiftScheduleDtl) : base(){
    copy(empShiftScheduleDtl);
    init();        
}

private
void init(){
    this.empFirstName = "";	
	this.empLastName = "";	
}

[System.Runtime.Serialization.DataMember]
public
string EmpFirstName {
	get { return empFirstName; }
	set { if (this.empFirstName != value){
			this.empFirstName = value;
			Notify("EmpFirstName");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string EmpLastName {
	get { return empLastName; }
	set { if (this.empLastName != value){
			this.empLastName = value;
			Notify("EmpLastName");
		}
	}
}

} // class
} // package