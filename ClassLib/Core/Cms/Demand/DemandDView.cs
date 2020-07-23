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

namespace Nujit.NujitERP.ClassLib.Core.Cms{

#if !POCKET_PC
    [System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class DemandDView : HotListDays {

private string source;
private string billTo;
private string shipTo;
private string shipLoc;
private string part;
private int seq;
private string custPart;
private DateTime sDate;
private decimal netQty;
private string timeCode;
private decimal qoh;

private decimal faAutCum;
private decimal maAutCum;

internal
DemandDView(): base(){
	this.source = "";
	this.billTo = "";
	this.shipTo = "";
	this.shipLoc = "";
	this.part = "";
    this.seq = 0;
	this.custPart = "";
	this.sDate = DateUtil.MinValue;
	this.netQty = 0;
    this.timeCode = "";    
    this.qoh = 0;

    this.faAutCum =0;
    this.maAutCum =0;
}

internal
DemandDView(
	string source,
	string billTo,
	string shipTo,
	string shipLoc,
	string part,
    int seq,
	string custPart,
	DateTime sDate,
	decimal netQty,    
    string timeCode,
    decimal qoh,
    decimal faAutCum,
    decimal maAutCum) : base(){
	this.source = source;
	this.billTo = billTo;
	this.shipTo = shipTo;
	this.shipLoc = shipLoc;
	this.part = part;
    this.seq = seq;
	this.custPart = custPart;
	this.sDate = sDate;
	this.netQty = netQty;
    this.timeCode = timeCode;    
    this.qoh = qoh;

    this.faAutCum = faAutCum;
    this.maAutCum = maAutCum;
}

[System.Runtime.Serialization.DataMember]
public
string Source {
	get { return source;}
	set { if (this.source != value){
			this.source = value;
			Notify("Source");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BillTo {
	get { return billTo;}
	set { if (this.billTo != value){
			this.billTo = value;
			Notify("BillTo");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ShipTo {
	get { return shipTo;}
	set { if (this.shipTo != value){
			this.shipTo = value;
			Notify("ShipTo");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ShipLoc {
	get { return shipLoc;}
	set { if (this.shipLoc != value){
			this.shipLoc = value;
			Notify("ShipLoc");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Part {
	get { return part;}
	set { if (this.part != value){
			this.part = value;
			Notify("Part");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int Seq {
	get { return seq;}
	set { if (this.seq != value){
			this.seq = value;
			Notify("Seq");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string CustPart {
	get { return custPart;}
	set { if (this.custPart != value){
			this.custPart = value;
			Notify("CustPart");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime SDate {
	get { return sDate;}
	set { if (this.sDate != value){
			this.sDate = value;
			Notify("SDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal NetQty {
    get { return netQty; }
	set { if (this.netQty != value){
            this.netQty = value;
            Notify("NetQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string TimeCode {
    get { return timeCode; }
	set { if (this.timeCode != value){
			this.timeCode = value;
            Notify("TimeCode");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Qoh {
    get { return qoh; }
	set { if (this.qoh != value){
			this.qoh = value;
            Notify("Qoh");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FaAutCum {
    get { return faAutCum; }
	set { if (this.faAutCum != value){
			this.faAutCum = value;
            Notify("FaAutCum");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal MaAutCum {
    get { return maAutCum; }
	set { if (this.maAutCum != value){
			this.maAutCum = value;
            Notify("MaAutCum");
		}
	}
}


public override
bool Equals(object obj){
	if (obj is DemandDView)
		return	this.BillTo.ToUpper().Equals(((DemandDView)obj).BillTo.ToUpper()) &&
                this.ShipTo.ToUpper().Equals(((DemandDView)obj).ShipTo.ToUpper()) &&
                this.ShipLoc.ToUpper().Equals(((DemandDView)obj).ShipLoc.ToUpper()) &&
                this.Part.ToUpper().Equals(((DemandDView)obj).Part.ToUpper()) &&
                this.Source.ToUpper().Equals(((DemandDView)obj).Source.ToUpper()) &&
                this.TimeCode.ToUpper().Equals(((DemandDView)obj).TimeCode);
    else
		return false;
}

public 
bool EqualsAuhotization(object obj){
	if (obj is DemandDView)
		return	this.FaAutCum == ((DemandDView)obj).FaAutCum &&
                this.MaAutCum == ((DemandDView)obj).MaAutCum;
    else
		return false;
}
       
public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package