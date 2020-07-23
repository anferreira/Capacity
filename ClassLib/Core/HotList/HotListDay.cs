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

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class HotListDay : BusinessObject {

private DateTime    dateTime;
private decimal qty;

#if !WEB
internal
#else
public
#endif
HotListDay(){	
	this.dateTime = DateUtil.MinValue;	
	this.qty = 0;	
}

public
HotListDay(
	DateTime dateTime,
	decimal qty){	

	this.dateTime = dateTime;
	this.qty = qty;	
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
} // class
} // package