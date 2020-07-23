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
class CapacityViewPart : CapacityView {

private string part;
private int seq;
private decimal qty;

#if !WEB
internal
#else
public
#endif
CapacityViewPart(): base(){    
	this.part = "";
	this.seq = 0;	
    this.qty = 0;
}

[System.Runtime.Serialization.DataMember]
public
string Part {
	get { return part; }
	set { if (this.part != value){
			this.part = value;
			Notify("Part");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int Seq {
	get { return seq; }
	set { if (this.seq != value){
			this.seq = value;
			Notify("Seq");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Qty {
	get { return qty; }
	set { if (this.qty != value){
			this.qty = value;
			Notify("Qty");
		}
	}
}
        

} // class
} // package