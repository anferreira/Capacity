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

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class ProductPlanDt : BusinessObject {

private string famCfg;
private int famSeq;
private string prodID;
private int seq;
private decimal qty;
private string invUOM;
private decimal qtyAvail;
private string shutYN;
private decimal minQty;
private decimal maxQty;

#if !WEB
internal
#else
public
#endif
ProductPlanDt(){
	this.famCfg = "";
	this.famSeq = 0;
	this.prodID = "";
	this.seq = 0;
	this.qty = 0;
	this.invUOM = "";
	this.qtyAvail = 0;
	this.shutYN = "";
	this.minQty = 0;
	this.maxQty = 0;
}

internal
ProductPlanDt(
	string famCfg,
	int famSeq,
	string prodID,
	int seq,
	decimal qty,
	string invUOM,
	decimal qtyAvail,
	string shutYN,
	decimal minQty,
	decimal maxQty)
{
	this.famCfg = famCfg;
	this.famSeq = famSeq;
	this.prodID = prodID;
	this.seq = seq;
	this.qty = qty;
	this.invUOM = invUOM;
	this.qtyAvail = qtyAvail;
	this.shutYN = shutYN;
	this.minQty = minQty;
	this.maxQty = maxQty;
}

[System.Runtime.Serialization.DataMember]
public
string FamCfg {
	get { return famCfg;}
	set { if (this.famCfg != value){
			this.famCfg = value;
			Notify("FamCfg");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int FamSeq {
	get { return famSeq;}
	set { if (this.famSeq != value){
			this.famSeq = value;
			Notify("FamSeq");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ProdID {
	get { return prodID;}
	set { if (this.prodID != value){
			this.prodID = value;
			Notify("ProdID");
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
decimal Qty {
	get { return qty;}
	set { if (this.qty != value){
			this.qty = value;
			Notify("Qty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string InvUOM {
	get { return invUOM;}
	set { if (this.invUOM != value){
			this.invUOM = value;
			Notify("InvUOM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyAvail {
	get { return qtyAvail;}
	set { if (this.qtyAvail != value){
			this.qtyAvail = value;
			Notify("QtyAvail");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ShutYN {
	get { return shutYN;}
	set { if (this.shutYN != value){
			this.shutYN = value;
			Notify("ShutYN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal MinQty {
	get { return minQty;}
	set { if (this.minQty != value){
			this.minQty = value;
			Notify("MinQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal MaxQty {
	get { return maxQty;}
	set { if (this.maxQty != value){
			this.maxQty = value;
			Notify("MaxQty");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is ProductPlanDt)
		return	this.famCfg.Equals(((ProductPlanDt)obj).FamCfg) &&
				this.famSeq.Equals(((ProductPlanDt)obj).FamSeq) &&
				this.prodID.Equals(((ProductPlanDt)obj).ProdID) &&
				this.seq.Equals(((ProductPlanDt)obj).Seq);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package