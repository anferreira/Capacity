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
class CustParts : BusinessObject {

private int iD;
private string db;
private string prodID;
private string prodIDAlias;
private string billToCust;
private string shipToCust;
private string dropShipCust;
private string custPart;
private string custPartRev;
private DateTime custPartRevDate;
private string custPartDes1;
private string custPartDes2;
private string custPartDes3;
private string consignment;
private decimal stdPackQty;
private string stdPackUnit;
private string stdPackCont;
private string stdPackSkidCode;
private decimal stdPackSkidQty;
private string stdPackSkidUom;
private int leadTime;
private int weeklyQtyCommit;

#if !WEB
internal
#else
public
#endif
CustParts(){
	this.iD = 0;
	this.db = "";
	this.prodID = "";
	this.prodIDAlias = "";
	this.billToCust = "";
	this.shipToCust = "";
	this.dropShipCust = "";
	this.custPart = "";
	this.custPartRev = "";
	this.custPartRevDate = DateUtil.MinValue;
	this.custPartDes1 = "";
	this.custPartDes2 = "";
	this.custPartDes3 = "";
	this.consignment = "";
	this.stdPackQty = 0;
	this.stdPackUnit = "";
	this.stdPackCont = "";
	this.stdPackSkidCode = "";
	this.stdPackSkidQty = 0;
	this.stdPackSkidUom = "";
	this.leadTime = 0;
	this.weeklyQtyCommit = 0;
}

internal
CustParts(
	int iD,
	string db,
	string prodID,
	string prodIDAlias,
	string billToCust,
	string shipToCust,
	string dropShipCust,
	string custPart,
	string custPartRev,
	DateTime custPartRevDate,
	string custPartDes1,
	string custPartDes2,
	string custPartDes3,
	string consignment,
	decimal stdPackQty,
	string stdPackUnit,
	string stdPackCont,
	string stdPackSkidCode,
	decimal stdPackSkidQty,
	string stdPackSkidUom,
	int leadTime,
	int weeklyQtyCommit)
{
	this.iD = iD;
	this.db = db;
	this.prodID = prodID;
	this.prodIDAlias = prodIDAlias;
	this.billToCust = billToCust;
	this.shipToCust = shipToCust;
	this.dropShipCust = dropShipCust;
	this.custPart = custPart;
	this.custPartRev = custPartRev;
	this.custPartRevDate = custPartRevDate;
	this.custPartDes1 = custPartDes1;
	this.custPartDes2 = custPartDes2;
	this.custPartDes3 = custPartDes3;
	this.consignment = consignment;
	this.stdPackQty = stdPackQty;
	this.stdPackUnit = stdPackUnit;
	this.stdPackCont = stdPackCont;
	this.stdPackSkidCode = stdPackSkidCode;
	this.stdPackSkidQty = stdPackSkidQty;
	this.stdPackSkidUom = stdPackSkidUom;
	this.leadTime = leadTime;
	this.weeklyQtyCommit = weeklyQtyCommit;
}

[System.Runtime.Serialization.DataMember]
public
int ID {
	get { return iD;}
	set { if (this.iD != value){
			this.iD = value;
			Notify("ID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Db {
	get { return db;}
	set { if (this.db != value){
			this.db = value;
			Notify("Db");
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
string ProdIDAlias {
	get { return prodIDAlias;}
	set { if (this.prodIDAlias != value){
			this.prodIDAlias = value;
			Notify("ProdIDAlias");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BillToCust {
	get { return billToCust;}
	set { if (this.billToCust != value){
			this.billToCust = value;
			Notify("BillToCust");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ShipToCust {
	get { return shipToCust;}
	set { if (this.shipToCust != value){
			this.shipToCust = value;
			Notify("ShipToCust");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string DropShipCust {
	get { return dropShipCust;}
	set { if (this.dropShipCust != value){
			this.dropShipCust = value;
			Notify("DropShipCust");
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
string CustPartRev {
	get { return custPartRev;}
	set { if (this.custPartRev != value){
			this.custPartRev = value;
			Notify("CustPartRev");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime CustPartRevDate {
	get { return custPartRevDate;}
	set { if (this.custPartRevDate != value){
			this.custPartRevDate = value;
			Notify("CustPartRevDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string CustPartDes1 {
	get { return custPartDes1;}
	set { if (this.custPartDes1 != value){
			this.custPartDes1 = value;
			Notify("CustPartDes1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string CustPartDes2 {
	get { return custPartDes2;}
	set { if (this.custPartDes2 != value){
			this.custPartDes2 = value;
			Notify("CustPartDes2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string CustPartDes3 {
	get { return custPartDes3;}
	set { if (this.custPartDes3 != value){
			this.custPartDes3 = value;
			Notify("CustPartDes3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Consignment {
	get { return consignment;}
	set { if (this.consignment != value){
			this.consignment = value;
			Notify("Consignment");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal StdPackQty {
	get { return stdPackQty;}
	set { if (this.stdPackQty != value){
			this.stdPackQty = value;
			Notify("StdPackQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string StdPackUnit {
	get { return stdPackUnit;}
	set { if (this.stdPackUnit != value){
			this.stdPackUnit = value;
			Notify("StdPackUnit");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string StdPackCont {
	get { return stdPackCont;}
	set { if (this.stdPackCont != value){
			this.stdPackCont = value;
			Notify("StdPackCont");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string StdPackSkidCode {
	get { return stdPackSkidCode;}
	set { if (this.stdPackSkidCode != value){
			this.stdPackSkidCode = value;
			Notify("StdPackSkidCode");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal StdPackSkidQty {
	get { return stdPackSkidQty;}
	set { if (this.stdPackSkidQty != value){
			this.stdPackSkidQty = value;
			Notify("StdPackSkidQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string StdPackSkidUom {
	get { return stdPackSkidUom;}
	set { if (this.stdPackSkidUom != value){
			this.stdPackSkidUom = value;
			Notify("StdPackSkidUom");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int LeadTime {
	get { return leadTime;}
	set { if (this.leadTime != value){
			this.leadTime = value;
			Notify("LeadTime");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int WeeklyQtyCommit {
	get { return weeklyQtyCommit;}
	set { if (this.weeklyQtyCommit != value){
			this.weeklyQtyCommit = value;
			Notify("WeeklyQtyCommit");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is CustParts)
		return	this.prodID.Equals(((CustParts)obj).ProdID) &&
				this.billToCust.Equals(((CustParts)obj).BillToCust) &&
				this.shipToCust.Equals(((CustParts)obj).ShipToCust);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package