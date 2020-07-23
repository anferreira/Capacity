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

namespace Nujit.NujitERP.ClassLib.Core.ScheduleDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class ScheduleMachine : BusinessObject {

private int     machId;
private string  machShow;
private string  machDescShow;

#if !WEB
internal
#else
public
#endif
ScheduleMachine(){
	this.machId = 0;
	this.machShow = "";	
    this.machDescShow = "";
}

internal
ScheduleMachine(	
    int machId,
    string machShow,
    string machDescShow){
	this.machId = machId;
    this.machShow = machShow;   
    this.machDescShow = machDescShow;
}

[System.Runtime.Serialization.DataMember]
public
int MachId {
	get { return machId; }
	set { if (this.machId != value){
			this.machId = value;
			Notify("MachId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MachShow {
	get { return machShow; }
	set { if (this.machShow != value){
			this.machShow = value;
			Notify("MachShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MachDescShow {
	get { return machDescShow; }
	set { if (this.machDescShow != value){
			this.machDescShow = value;
			Notify("MachDescShow");
		}
	}
}

public
void copy(ScheduleMachine scheduleMachine){       
    this.MachId = scheduleMachine.MachId;
    this.MachShow = scheduleMachine.MachShow;
    this.MachDescShow = scheduleMachine.MachDescShow;
}


} // class
} // package