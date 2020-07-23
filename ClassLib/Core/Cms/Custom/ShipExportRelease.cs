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
class ShipExportRelease : BusinessObject {

private string site;
private decimal bol;
private decimal bolItem;
private int detail;
private string release;
private DateTime relDate;
private decimal relCum;
private decimal relQty;
private decimal ourShipCum;
private decimal oemYtdReq;
private decimal oemYtdShip;
private DateTime stDateCreated;
private string stTranslated;
private DateTime stTranslatedDate;
private string userId;
private string ran;

private bool bqtyChangeShow;         
private bool bdateChangeShow;         

#if !WEB
internal
#else
public
#endif
ShipExportRelease(){
	this.site = "";
	this.bol = 0;
	this.bolItem = 0;
	this.detail = 0;
	this.release = "";
	this.relDate = DateUtil.MinValue;
	this.relCum = 0;
	this.relQty = 0;
	this.ourShipCum = 0;
	this.oemYtdReq = 0;
	this.oemYtdShip = 0;
	this.stDateCreated = DateUtil.MinValue;
	this.stTranslated = "";
	this.stTranslatedDate = DateUtil.MinValue;
    this.userId = "";    
    this.ran = "";
}

internal
ShipExportRelease(
	string site,
	decimal bol,
	decimal bolItem,
	int detail,
	string release,
	DateTime relDate,
	decimal relCum,
	decimal relQty,
	decimal ourShipCum,
	decimal oemYtdReq,
	decimal oemYtdShip,
	DateTime stDateCreated,
	string stTranslated,
	DateTime stTranslatedDate,
    string userId,
    string ran){
	this.site = site;
	this.bol = bol;
	this.bolItem = bolItem;
	this.detail = detail;
	this.release = release;
	this.relDate = relDate;
	this.relCum = relCum;
	this.relQty = relQty;
	this.ourShipCum = ourShipCum;
	this.oemYtdReq = oemYtdReq;
	this.oemYtdShip = oemYtdShip;
	this.stDateCreated = stDateCreated;
	this.stTranslated = stTranslated;
	this.stTranslatedDate = stTranslatedDate;
    this.userId = userId;    
    this.ran = ran;
    this.bqtyChangeShow = false;
    this.bdateChangeShow = false;
}

[System.Runtime.Serialization.DataMember]
public
string Site {
	get { return site;}
	set { if (this.site != value){
			this.site = value;
			Notify("Site");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Bol {
	get { return bol;}
	set { if (this.bol != value){
			this.bol = value;
			Notify("Bol");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal BolItem {
	get { return bolItem;}
	set { if (this.bolItem != value){
			this.bolItem = value;
			Notify("BolItem");
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
string Release {
	get { return release;}
	set { if (this.release != value){
			this.release = value;
			Notify("Release");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime RelDate {
	get { return relDate;}
	set { if (this.relDate != value){
			this.relDate = value;
			Notify("RelDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RelCum {
	get { return relCum;}
	set { if (this.relCum != value){
			this.relCum = value;
			Notify("RelCum");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RelQty {
	get { return relQty;}
	set { if (this.relQty != value){
			this.relQty = value;
			Notify("RelQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal OurShipCum {
	get { return ourShipCum;}
	set { if (this.ourShipCum != value){
			this.ourShipCum = value;
			Notify("OurShipCum");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal OemYtdReq {
	get { return oemYtdReq;}
	set { if (this.oemYtdReq != value){
			this.oemYtdReq = value;
			Notify("OemYtdReq");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal OemYtdShip {
	get { return oemYtdShip;}
	set { if (this.oemYtdShip != value){
			this.oemYtdShip = value;
			Notify("OemYtdShip");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime StDateCreated {
	get { return stDateCreated;}
	set { if (this.stDateCreated != value){
			this.stDateCreated = value;
			Notify("StDateCreated");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string StTranslated {
	get { return stTranslated;}
	set { if (this.stTranslated != value){
			this.stTranslated = value;
			Notify("StTranslated");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime StTranslatedDate {
	get { return stTranslatedDate;}
	set { if (this.stTranslatedDate != value){
			this.stTranslatedDate = value;
			Notify("StTranslatedDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string UserId {
	get { return userId;}
	set { if (this.userId != value){
			this.userId = value;
			Notify("UserId");
		}
	}
} 

[System.Runtime.Serialization.DataMember]
public
string Ran {
	get { return ran;}
	set { if (this.ran != value){
			this.ran = value;
			Notify("ran");
		}
	}
} 

public override
bool Equals(object obj){
	if (obj is ShipExportRelease)
		return	this.site.Equals(((ShipExportRelease)obj).Site) &&
				this.bol.Equals(((ShipExportRelease)obj).Bol) &&
				this.bolItem.Equals(((ShipExportRelease)obj).BolItem) &&
				this.detail.Equals(((ShipExportRelease)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

[System.Runtime.Serialization.DataMember]
public
bool BQtyChangeShow {
	get { return bqtyChangeShow; }
	set { if (this.bqtyChangeShow != value){
			this.bqtyChangeShow = value;
			Notify("BQtyChangeShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool BDateChangeShow {
	get { return bdateChangeShow; }
	set { if (this.bdateChangeShow != value){
			this.bdateChangeShow = value;
			Notify("BDateChangeShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
ShipExportRelease Object{
	get { return this;}
	set { if (this != value){			
			Notify("Object");
		}
	}
}

} // class
} // package