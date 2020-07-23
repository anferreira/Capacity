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
class DemTransformOptions : BusinessObject {

private DemandH demandH;
private string  weekMode;
private string  monthMode;


#if !WEB
internal
#else
public
#endif
DemTransformOptions(){
	this.demandH = null;
	this.weekMode = Constants.TIME_CODE_WEEKLY;
    this.monthMode = Constants.TIME_CODE_MONTHLY;	
}

[System.Runtime.Serialization.DataMember]
public
DemandH DemandH {
	get { return demandH; }
	set {
        this.demandH = value;		
	}
}

[System.Runtime.Serialization.DataMember]
public
string WeekMode {
	get { return weekMode; }
	set { if (this.weekMode != value){
			this.weekMode = value;
			Notify("WeekMode");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MonthMode {
	get { return monthMode; }
	set { if (this.monthMode != value){
			this.monthMode = value;
			Notify("MonthMode");
		}
	}
}

} // class
} // package