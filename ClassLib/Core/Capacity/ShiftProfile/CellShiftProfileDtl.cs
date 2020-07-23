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
using Nujit.NujitERP.ClassLib.Core.Planned;

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class CellShiftProfileDtl : CellMachinePart {

private decimal temp;
private decimal overtime;
private PlannedLabourContainer plannedLabourContainer;

public
CellShiftProfileDtl(): base(){            
    this.temp = 0;
    this.overtime = 0;    
    this.plannedLabourContainer = new PlannedLabourContainer();
}

[System.Runtime.Serialization.DataMember]
public
decimal Temp {
	get { return temp; }
	set { if (this.temp != value){
			this.temp = value;
			Notify("Temp");            
            Notify("Net");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Overtime {
	get { return overtime; }
	set { if (this.overtime != value){
			this.overtime = value;            
			Notify("Overtime");       
            Notify("Net");                                
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Net {
	get {     
        net = (Planned + Overtime + Temp) - Required;                         
        return  net;
    } set { if (this.net != value){
			this.net = value;
			Notify("Net");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
PlannedLabourContainer PlannedLabourContainer{
	get {                   
        return  plannedLabourContainer;
    } set { if (this.plannedLabourContainer != plannedLabourContainer){
			this.plannedLabourContainer = value;
			Notify("PlannedLabourContainer");
		}
	}
}

} // class
} // package