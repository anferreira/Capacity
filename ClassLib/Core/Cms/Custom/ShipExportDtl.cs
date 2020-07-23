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
class ShipExportDtl : BusinessObject {

private string site;
private decimal bol;
private decimal bolItem;
private int detail;
private decimal orderNum;
private decimal item;
private string release;
private string timeStamp;
private string action;
private DateTime relDate;
private decimal relQtyInvUnit;
private decimal qtyShippedInv;
private decimal qtyBackInv;
private DateTime dateRequest;
private DateTime shipDate;
private string ran;

private string user;
private decimal qtyChange;
private DateTime dateChange;
private int daysShipChanged;
private string delete;

#if !WEB
internal
#else
public
#endif
ShipExportDtl(){
	this.site = "";
	this.bol = 0;
	this.bolItem = 0;
	this.detail = 0;
	this.orderNum = 0;
	this.item = 0;
	this.release = "";
	this.timeStamp = "";
	this.action = "";
	this.relDate = DateUtil.MinValue;
	this.relQtyInvUnit = 0;
	this.qtyShippedInv = 0;
	this.qtyBackInv = 0;
	this.dateRequest = DateUtil.MinValue;
	this.shipDate = DateUtil.MinValue;
	this.ran = "";
    this.user = "";
    this.qtyChange = 0;
    this.dateChange = DateUtil.MinValue;
    this.daysShipChanged = 0;

    this.delete = Constants.STRING_NO;
}

internal
ShipExportDtl(
	string site,
	decimal bol,
	decimal bolItem,
	int detail,
	decimal orderNum,
	decimal item,
	string release,
	string timeStamp,
	string action,
	DateTime relDate,
	decimal relQtyInvUnit,
	decimal qtyShippedInv,
	decimal qtyBackInv,
	DateTime dateRequest,
	DateTime shipDate,
	string ran,
    string user,
    decimal qtyChange,
    DateTime dateChange,
    int daysShipChanged){
	this.site = site;
	this.bol = bol;
	this.bolItem = bolItem;
	this.detail = detail;
	this.orderNum = orderNum;
	this.item = item;
	this.release = release;
	this.timeStamp = timeStamp;
	this.action = action;
	this.relDate = relDate;
	this.relQtyInvUnit = relQtyInvUnit;
	this.qtyShippedInv = qtyShippedInv;
	this.qtyBackInv = qtyBackInv;
	this.dateRequest = dateRequest;
	this.shipDate = shipDate;
	this.ran = ran;
    this.user = user;
    this.qtyChange = qtyChange;
    this.dateChange = dateChange;
    this.daysShipChanged = daysShipChanged;
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
decimal OrderNum {
	get { return orderNum;}
	set { if (this.orderNum != value){
			this.orderNum = value;
			Notify("OrderNum");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Item {
	get { return item;}
	set { if (this.item != value){
			this.item = value;
			Notify("Item");
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
string TimeStamp {
	get { return timeStamp;}
	set { if (this.timeStamp != value){
			this.timeStamp = value;
			Notify("TimeStamp");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Action {
	get { return action;}
	set { if (this.action != value){
			this.action = value;
			Notify("Action");
		}
	}
}

public
string ActionDesc {
	get {
        string scode = "";
        switch(action){
            case "1": scode = "BUpd";break;
            case "2": scode = "AUpd";break;
            case "3": scode = "Del";break;
            case "4": scode = "Add";break;
        }
        return scode;
    } set { 
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
decimal RelQtyInvUnit {
	get { return relQtyInvUnit;}
	set { if (this.relQtyInvUnit != value){
			this.relQtyInvUnit = value;
			Notify("RelQtyInvUnit");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyShippedInv {
	get { return qtyShippedInv;}
	set { if (this.qtyShippedInv != value){
			this.qtyShippedInv = value;
			Notify("QtyShippedInv");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyBackInv {
	get { return qtyBackInv;}
	set { if (this.qtyBackInv != value){
			this.qtyBackInv = value;
			Notify("QtyBackInv");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime DateRequest {
	get { return dateRequest;}
	set { if (this.dateRequest != value){
			this.dateRequest = value;
			Notify("DateRequest");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime ShipDate {
	get { return shipDate;}
	set { if (this.shipDate != value){
			this.shipDate = value;
			Notify("ShipDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Ran {
	get { return ran;}
	set { if (this.ran != value){
			this.ran = value;
			Notify("Ran");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string User {
	get { return user;}
	set { if (this.user != value){
			this.user = value;
			Notify("User");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyChange {
	get { return qtyChange; }
	set { if (this.qtyChange != value){
			this.qtyChange = value;
			Notify("qtyChange");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime DateChange {
	get { return dateChange; }
	set { if (this.dateChange != value){
			this.dateChange = value;
			Notify("DateChange");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int DaysShipChanged {
	get { return daysShipChanged; }
	set { if (this.daysShipChanged != value){
			this.daysShipChanged = value;
			Notify("DaysShipChanged");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Delete {
	get { return delete; }
	set { if (this.delete != value){
			this.delete = value;
			Notify("Delete");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is ShipExportDtl)
		return	this.site.Equals(((ShipExportDtl)obj).Site) &&
				this.bol.Equals(((ShipExportDtl)obj).Bol) &&
				this.bolItem.Equals(((ShipExportDtl)obj).BolItem) &&
				this.detail.Equals(((ShipExportDtl)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
DateTime getTimeStampAsDate(){
    DateTime dateAux =  DateUtil.parseDateFromStringAS400(timeStamp);
    return dateAux;
}




} // class
} // package