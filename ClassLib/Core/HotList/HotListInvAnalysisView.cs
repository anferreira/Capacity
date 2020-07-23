/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class HotListInvAnalysisView : HotListPlanned {

private string  description;
private decimal virtKanManDem;
private string  partType;
private decimal level;
private decimal daysOnHand;
private decimal matQty;
private decimal optRunQty;

private decimal  qty;
private DateTime dateTime;

#if !WEB
public
#else
public
#endif
HotListInvAnalysisView(){
    this.description = "";
    this.virtKanManDem = 0;
    this.partType = "";
    this.level = 0;
    this.daysOnHand = 0;    
    this.matQty = 0;
    this.optRunQty = 0;

    this.qty = 0;
    this.dateTime  = DateUtil.MinValue;
}

[System.Runtime.Serialization.DataMember]
public
string Description {
	get { return description; }
	set { if (this.description != value){
			this.description = value;
			Notify("Description");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal DaysOnHand {
	get {
        this.daysOnHand = (virtKanManDem!=0 ? Qoh / virtKanManDem : 0);
        return daysOnHand; }
	set { if (this.daysOnHand != value){
			this.daysOnHand = value;
			Notify("DaysOnHand");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal VirtKanManDem {
	get { return virtKanManDem; }
	set { if (this.virtKanManDem != value){
			this.virtKanManDem = value;
			Notify("VirtKanManDem");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string PartType {
	get { return partType; }
	set { if (this.partType != value){
			this.partType = value;
			Notify("PartType");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Level {
	get { return level; }
	set { if (this.level != value){
			this.level = value;
			Notify("Level");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal MatQty {
	get {        
        return matQty; }
	set { if (this.matQty != value){
			this.matQty = value;
			Notify("MatQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal OptRunQty {
	get {        
        return optRunQty; }
	set { if (this.optRunQty != value){
			this.optRunQty = value;
			Notify("OptRunQty");
		}
	}
}

public
decimal Qty {
	get { return qty; }
	set { if (this.qty != value){
			this.qty = value;			
            Notify("Qty");
            Notify("Hours");
		}
	}
}

public
DateTime DateTime {
	get { return dateTime; }
	set { if (this.dateTime != value){
			this.dateTime = value;			
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Hours {
	get {
        decimal daux =  MachCyc !=0  ? Qty / MachCyc : Qty;
        return daux;
    }set { 
	}
}

public
void copy(HotListInvAnalysisView hotListInvAnalysisView){
    this.Description    = hotListInvAnalysisView.Description;
    this.VirtKanManDem  = hotListInvAnalysisView.VirtKanManDem;
    this.DaysOnHand     = hotListInvAnalysisView.DaysOnHand;
    this.MatQty         = hotListInvAnalysisView.MatQty;
    this.OptRunQty      = hotListInvAnalysisView.OptRunQty;

    this.Qty            = hotListInvAnalysisView.Qty;
    this.DateTime       = hotListInvAnalysisView.DateTime;

    base.copy(hotListInvAnalysisView);
}

} // class
} // package