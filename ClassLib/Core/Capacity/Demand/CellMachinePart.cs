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
class CellPlanProduction : BusinessObject {

protected decimal planned;
protected decimal production;
protected decimal daily862;
protected decimal weekly830;
protected decimal shipment;
protected DateTime startDate;
protected DateTime endDate;
protected int index;
protected int xindex;

public
CellPlanProduction(): base(){            
    this.planned = 0;
    this.production = 0;
    this.daily862 = 0;
    this.weekly830 = 0;  
    this.shipment = 0;
    this.index =0;
    this.xindex = 0;
    
    this.startDate = DateUtil.MinValue;
    this.endDate = DateUtil.MinValue;
}

[System.Runtime.Serialization.DataMember]
public
decimal Planned {
	get { return planned; }
	set { if (this.planned != value){
			this.planned = value;            
			Notify("Planned");
            Notify("Net");
            Notify("NetShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Production {
	get { return production; }
	set { if (this.production != value){
			this.production = value;
			Notify("Production");            
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Daily862 {
	get { return daily862; }
	set { if (this.daily862 != value){
			this.daily862 = value;            
			Notify("Daily862");            
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Weekly830 {
	get { return weekly830; }
	set { if (this.weekly830 != value){
			this.weekly830 = value;
			Notify("Weekly830");            
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Shipment {
	get { return shipment; }
	set { if (this.shipment != value){
			this.shipment = value;
			Notify("Shipment");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime StartDate {
	get { return startDate;}
	set { if (this.startDate != value){
			this.startDate = value;
			Notify("StartDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime EndDate {
	get { return endDate;}
	set { if (this.endDate != value){
			this.endDate = value;
			Notify("EndDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int Index {
	get { return index;}
	set { if (this.index != value){
			this.index = value;
			Notify("Index");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int XIndex {
	get { return xindex; }
	set { if (this.xindex != value){
			this.xindex = value;
			Notify("xindex");
		}
	}
}


} // class
} // package