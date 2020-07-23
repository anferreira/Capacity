/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.ClassLib.Core.Reports{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class RP1268S : BusinessObject {

private int hdrId;
private int detail;
private int subDtl;
private string mainMat;
private decimal qty;
private decimal wK1RECQTY;
private decimal wK2RECQTY;
private decimal wK3RECQTY;
private decimal wK4RECQTY;
private DateTime wK1RECDAT;
private DateTime wK2RECDAT;

#if !WEB
internal
#else
public
#endif
RP1268S(){
	this.hdrId = 0;
	this.detail = 0;
	this.subDtl = 0;
	this.mainMat = "";
	this.qty = 0;

    this.wK1RECQTY= 0;
    this.wK2RECQTY= 0;
    this.wK3RECQTY= 0;
    this.wK4RECQTY= 0;

    this.wK1RECDAT = DateUtil.MinValue;
    this.wK2RECDAT = DateUtil.MinValue;
}

internal
RP1268S(
	int hdrId,
	int detail,
	int subDtl,
	string mainMat,
	decimal qty,
    decimal wK1RECQTY,
    decimal wK2RECQTY,
    decimal wK3RECQTY,
    decimal wK4RECQTY,
    DateTime wK1RECDAT,
    DateTime wK2RECDAT){

	this.hdrId = hdrId;
	this.detail = detail;
	this.subDtl = subDtl;
	this.mainMat = mainMat;
	this.qty = qty;

    this.wK1RECQTY= wK1RECQTY;
    this.wK2RECQTY= wK2RECQTY;
    this.wK3RECQTY= wK3RECQTY;
    this.wK4RECQTY= wK4RECQTY;

    this.wK1RECDAT =wK1RECDAT;
    this.wK2RECDAT =wK2RECDAT;
}

[System.Runtime.Serialization.DataMember]
public
int HdrId {
	get { return hdrId;}
	set { if (this.hdrId != value){
			this.hdrId = value;
			Notify("HdrId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int Detail {
	get { return detail;}
	set { if (this.detail != value){
			this.detail = value;
			Notify("Detail");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int SubDtl {
	get { return subDtl;}
	set { if (this.subDtl != value){
			this.subDtl = value;
			Notify("SubDtl");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MainMat {
	get { return mainMat;}
	set { if (this.mainMat != value){
			this.mainMat = value;
			Notify("MainMat");
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
decimal WK1RECQTY {
	get { return wK1RECQTY; }
	set { if (this.wK1RECQTY != value){
			this.wK1RECQTY = value;
			Notify("WK1RECQTY");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal WK2RECQTY {
	get { return wK2RECQTY; }
	set { if (this.wK2RECQTY != value){
			this.wK2RECQTY = value;
			Notify("WK2RECQTY");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal WK3RECQTY {
	get { return wK3RECQTY; }
	set { if (this.wK3RECQTY != value){
			this.wK3RECQTY = value;
			Notify("WK3RECQTY");
		}
	}
}        

[System.Runtime.Serialization.DataMember]
public
decimal WK4RECQTY {
	get { return wK4RECQTY; }
	set { if (this.wK4RECQTY != value){
			this.wK4RECQTY = value;
			Notify("WK4RECQTY");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime WK1RECDAT {
	get { return wK1RECDAT; }
	set { if (this.wK1RECDAT != value){
			this.wK1RECDAT = value;
			Notify("WK1RECDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime WK2RECDAT {
	get { return wK2RECDAT; }
	set { if (this.wK2RECDAT != value){
			this.wK2RECDAT = value;
			Notify("WK2RECDAT");
		}
	}
}
        
public override
bool Equals(object obj){
	if (obj is RP1268S)
		return	this.hdrId.Equals(((RP1268S)obj).HdrId) &&
				this.detail.Equals(((RP1268S)obj).Detail) &&
				this.subDtl.Equals(((RP1268S)obj).SubDtl);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package