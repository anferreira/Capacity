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
class EmployeeLabourView : EmployeeLabour {

private bool    selected;
private string  taskName;

#if !WEB
internal
#else
public
#endif
EmployeeLabourView(){
	this.selected = false;
	this.taskName = "";	
}

internal
EmployeeLabourView(
	bool selected,
	string taskName){
	this.selected = selected;
	this.taskName = taskName;	
}

[System.Runtime.Serialization.DataMember]
public
bool Selected {
	get { return selected; }
	set { if (this.selected != value){
			this.selected = value;
			Notify("Selected");
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

} // class
} // package