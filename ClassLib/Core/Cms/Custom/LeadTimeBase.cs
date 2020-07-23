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

namespace Nujit.NujitERP.ClassLib.Core.Cms{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class LeadTimeBase : BusinessObject {

private int leadTime;
private int leadTime2;
private int leadTime3;

#if !WEB
internal
#else
public
#endif
LeadTimeBase(){
    this.leadTime   = 0;
    this.leadTime2  = 0;
    this.leadTime3  = 0;
}

internal
LeadTimeBase(
	int leadTime,
    int leadTime2,
    int leadTime3){	

	this.leadTime = leadTime;
    this.leadTime2 = leadTime2;
    this.leadTime3 = leadTime3;
}

[System.Runtime.Serialization.DataMember]
public
int LeadTime {
	get { return leadTime; }
	set { if (this.leadTime != value){
			this.leadTime = value;
			Notify("LeadTime");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int LeadTime2 {
	get { return leadTime2; }
	set { if (this.leadTime2 != value){
			this.leadTime2 = value;
			Notify("LeadTime2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int LeadTime3 {
	get { return leadTime3; }
	set { if (this.leadTime3 != value){
			this.leadTime3 = value;
			Notify("LeadTime3");
		}
	}
}


} // class
} // package