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
class ShipExportBase : LeadTimeBase {

private decimal orderNum;
private decimal item;
private string release;
private string site;
private string billTo;
private string custPO;
private string ordType;
private string product;
private DateTime dateRequest;
private DateTime changeDate;
private DateTime shipDate;

private string majGroup;
private string minGroup;
private string minSales;
private string majSales;
private string ppap;
private decimal qtyOrder;
private decimal qtyShipped;
private decimal cumQty;
private decimal qtyOrderedFromCum;

private string shipTo;
private DateTime createDate;
private string tradPartner;

#if !WEB
internal
#else
public
#endif
ShipExportBase() : base(){
	this.orderNum   = 0;
	this.item       = 0;
	this.release    = "";
    this.site       = "";
    this.billTo     = "";
	this.custPO     = "";
	this.ordType    = "";
	this.product    = "";
	this.dateRequest= DateUtil.MinValue;
	this.changeDate = DateUtil.MinValue;
	this.shipDate   = DateUtil.MinValue;
            	
    this.majGroup   = "";
    this.minGroup   = "";
	this.minSales   = "";
	this.majSales   = "";
	this.ppap       = "";
	this.qtyOrder   = 0;
	this.qtyShipped = 0;    
    this.cumQty     = 0;
    this.qtyOrderedFromCum = 0;

    this.shipTo     = "";
    this.createDate = DateUtil.MinValue;
    this.tradPartner= "";
}

internal
ShipExportBase(
	decimal orderNum,
	decimal item,
	string release,
    string site,
    string billTo,
	string custPO,
	string ordType,
	string product,
	DateTime dateRequest,
	DateTime changeDate,
	DateTime shipDate,
	
    string majGroup,
    string minGroup,
	string minSales,
	string majSales,
	string ppap,
	decimal qtyOrder,
	decimal qtyShipped,
    int leadTime,
    int leadTime2,
    int leadTime3,decimal cumQty,decimal qtyOrderedFromCum,
    string shipTo,DateTime createDate,string tradPartner) : base (leadTime,leadTime2,leadTime3){
	this.orderNum = orderNum;
	this.item = item;
	this.release = release;
    this.site   = site;
	this.billTo = billTo;
	this.custPO = custPO;
	this.ordType = ordType;
	this.product = product;
	this.dateRequest = dateRequest;
	this.changeDate = changeDate;
	this.shipDate = shipDate;
	
    this.majGroup = majGroup;
    this.minGroup = minGroup;    
    this.minSales = minSales;
	this.majSales = majSales;
	this.ppap = ppap;
	this.qtyOrder = qtyOrder;
	this.qtyShipped = qtyShipped;	
    this.cumQty     = cumQty;
    this.qtyOrderedFromCum = qtyOrderedFromCum;

    this.shipTo     = shipTo;
    this.createDate = createDate;
    this.tradPartner= tradPartner;
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
string CustPO {
	get { return custPO;}
	set { if (this.custPO != value){
			this.custPO = value;
			Notify("CustPO");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OrdType {
	get { return ordType;}
	set { if (this.ordType != value){
			this.ordType = value;
			Notify("OrdType");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Product {
	get { return product;}
	set { if (this.product != value){
			this.product = value;
			Notify("Product");
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
DateTime ChangeDate {
	get { return changeDate;}
	set { if (this.changeDate != value){
			this.changeDate = value;
			Notify("ChangeDate");
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
string MajGroup {
	get { return majGroup; }
	set { if (this.majGroup != value){
			this.majGroup = value;
			Notify("MajGroup");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MinGroup {
	get { return minGroup; }
	set { if (this.minGroup != value){
			this.minGroup = value;
			Notify("MinGroup");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MinSales {
	get { return minSales;}
	set { if (this.minSales != value){
			this.minSales = value;
			Notify("MinSales");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MajSales {
	get { return majSales;}
	set { if (this.majSales != value){
			this.majSales = value;
			Notify("MajSales");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Ppap {
	get { return ppap;}
	set { if (this.ppap != value){
			this.ppap = value;
			Notify("Ppap");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyOrder {
	get { return qtyOrder;}
	set { if (this.qtyOrder != value){
			this.qtyOrder = value;
			Notify("QtyOrder");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyShipped {
	get { return qtyShipped;}
	set { if (this.qtyShipped != value){
			this.qtyShipped = value;
			Notify("QtyShipped");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CumQty {
	get { return cumQty; }
	set { if (this.cumQty != value){
			this.cumQty = value;
			Notify("CumQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyOrderedFromCum {
	get { return qtyOrderedFromCum; }
	set { if (this.qtyOrderedFromCum != value){
			this.qtyOrderedFromCum = value;
			Notify("QtyOrderedFromCum");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ShipTo {
	get { return shipTo; }
	set { if (this.shipTo != value){
			this.shipTo = value;
			Notify("ShipTo");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime CreateDate {
	get { return createDate; }
	set { if (this.createDate != value){
			this.createDate = value;
			Notify("CreateDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string TradPartner {
	get { return tradPartner; }
	set { if (this.tradPartner != value){
			this.tradPartner = value;
			Notify("TradPartner");
		}
	}
}
 
public override
bool Equals(object obj){
	if (obj is ShipExportBase)
		return	this.orderNum.Equals(((ShipExportBase)obj).OrderNum) &&
				this.item.Equals(((ShipExportBase)obj).Item) &&
				this.release.Equals(((ShipExportBase)obj).Release);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

[System.Runtime.Serialization.DataMember]
public
ShipExportBase Object{
	get { return this;}
	set { if (this != value){			
			Notify("Object");
		}
	}
}


} // class
} // package