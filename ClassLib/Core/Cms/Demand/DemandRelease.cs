/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using Nujit.NujitERP.ClassLib.Util;
using System.Collections;

namespace Nujit.NujitERP.ClassLib.Core.Cms{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class DemandRelease : BusinessObject {

private string      release;
private DateTime    dateTime;
private decimal     qty;


#if !WEB
internal
#else
public
#endif
DemandRelease(){	
    this.release    = "";
	this.dateTime   = DateUtil.MinValue;		
    this.qty        = 0;
}

public
DemandRelease(
    string      release,
	DateTime    dateTime,
    decimal     qty){	
	this.release    = release;
	this.dateTime   = dateTime;	
    this.qty        = qty;
}

[System.Runtime.Serialization.DataMember]
public
string Release {
	get { return release; }
	set { if (this.release != value){
			this.release = value;
			Notify("Release");
		}
	}
} 

[System.Runtime.Serialization.DataMember]
public
DateTime DateTime {
	get { return dateTime; }
	set { if (this.dateTime != value){
			this.dateTime = value;
			Notify("DateTime");
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

public
void copy(DemandDCompareView demandDCompareView,decimal qty){     
    Release     = demandDCompareView.RelNum;
    DateTime    = demandDCompareView.RelDate;                    
    this.qty    = qty;
}
       
} // class
} // package