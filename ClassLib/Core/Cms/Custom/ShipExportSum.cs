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
class ShipExportSum : ShipExportBase {

public const string SALE_SERVICE_IN     = "IN SL";
public const string SALE_SERVICE_NOT_IN = "NOT IN SL";

public const string CHANGE_NO_REC       = "NO CHANGE_REC";
public const string CHANGE_REC_FOUND    = "CHANGE REC FOUND";

public const string BACKORDER_BACK      = "B";
public const string BACKORDER_ORDER     = "O";      

public const string EXCLUDE_COMM_GOOD   = "GOOD RECORD";
public const string EXCLUDE_COMM_BACK   = "BACKORDER";
public const string EXCLUDE_COMM_NOTHOSE= "NOT HOSE AND TUBE";
public const string EXCLUDE_COMM_GRPNOT = "GROUP CODE NOT INCLUDED";
public const string EXCLUDE_COMM_BAD_REC= "BAD RECORD";

private string dtWkMonthWkDesc;
private decimal qtyOrderSh;
private decimal qtyShippedSh;
private decimal qtyPpm;
private int actualDays;
private string compliance;
private string include;
private string sale;
private string change;
private string backord;
private string excludeComment;
private string parentRelease;

private decimal qtyShippedOnTime;
private decimal qtyShippedLate;
private string fixManual;
private decimal cumQty;
private string  note;
private DateTime dateRequestFromCum;

private ShipExport shipExport;
private ShipExportContainer shipExportContainer;

#if !WEB
internal
#else
public
#endif
ShipExportSum() : base(){
	this.dtWkMonthWkDesc = "";
    this.qtyOrderSh = 0;
	this.qtyShippedSh = 0;
	this.qtyPpm = 0;
	this.actualDays = 0;
	this.compliance     = Constants.STRING_YES;
	this.include        = Constants.STRING_YES;
	this.sale           = SALE_SERVICE_IN;
	this.change         = "";//empty for now
	this.backord        = BACKORDER_ORDER;
	this.excludeComment = EXCLUDE_COMM_GOOD;
	this.parentRelease  = "";    

    this.qtyShippedOnTime   = 0;
    this.qtyShippedLate     = 0;
    this.cumQty             = 0;
    this.fixManual          = Constants.STRING_NO;
    this.note               = "";
    this.dateRequestFromCum = DateUtil.MinValue;

    this.shipExport     = null;
    this.shipExportContainer = new ShipExportContainer();
}

internal
ShipExportSum(
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
	string dtWkMonthWkDesc,
    string majGroup,
    string minGroup,
	string minSales,
	string majSales,
	string ppap,
	decimal qtyOrder,
	decimal qtyShipped,
	decimal qtyOrderSh,
	decimal qtyShippedSh,
	decimal qtyPpm,
	int actualDays,
	string compliance,
	string include,
	string sale,
	string change,
	string backord,
	string excludeComment,
	string parentRelease, 
    int leadTime, int leadTime2, int leadTime3,
    decimal qtyShippedOnTime,decimal qtyShippedLate,string fixManual,decimal cumQty,decimal qtyOrderedFromCum,string note,
    string shipTo,DateTime createDate,string tradPartner,DateTime dateRequestFromCum) : base (orderNum,
                                                item,release,site,billTo,custPO,ordType,product,dateRequest,changeDate,shipDate,
                                                majGroup,minGroup,minSales,majSales,ppap,qtyOrder,qtyShipped,
                                                leadTime,leadTime2,leadTime3,cumQty,qtyOrderedFromCum, shipTo, createDate, tradPartner){
	this.dtWkMonthWkDesc = dtWkMonthWkDesc;
    this.qtyOrderSh = qtyOrderSh;
	this.qtyShippedSh = qtyShippedSh;
	this.qtyPpm = qtyPpm;
	this.actualDays = actualDays;
	this.compliance = compliance;
	this.include = include;
	this.sale = sale;
	this.change = change;
	this.backord = backord;
	this.excludeComment = excludeComment;
	this.parentRelease = parentRelease;    

    this.qtyShippedOnTime = qtyShippedOnTime; 
    this.qtyShippedLate = qtyShippedLate;
    this.fixManual      = fixManual;
    this.note           = note;
    this.dateRequestFromCum = dateRequestFromCum;

    this.shipExport = null;
    this.shipExportContainer = new ShipExportContainer();
}

[System.Runtime.Serialization.DataMember]
public
string DtWkMonthWkDesc {
	get { return dtWkMonthWkDesc;}
	set { if (this.dtWkMonthWkDesc != value){
			this.dtWkMonthWkDesc = value;
			Notify("DtWkMonthWkDesc");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyOrderSh {
	get { return qtyOrderSh;}
	set { if (this.qtyOrderSh != value){
			this.qtyOrderSh = value;
			Notify("QtyOrderSh");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyShippedSh {
	get { return qtyShippedSh;}
	set { if (this.qtyShippedSh != value){
			this.qtyShippedSh = value;
			Notify("QtyShippedSh");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyPpm {
	get { return qtyPpm;}
	set { if (this.qtyPpm != value){
			this.qtyPpm = value;
			Notify("QtyPpm");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int ActualDays {
	get { return actualDays;}
	set { if (this.actualDays != value){
			this.actualDays = value;
			Notify("ActualDays");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Compliance {
	get { return compliance;}
	set { if (this.compliance != value){
			this.compliance = value;
			Notify("Compliance");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Include {
	get { return include;}
	set { if (this.include != value){
			this.include = value;
			Notify("Include");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Sale {
	get { return sale;}
	set { if (this.sale != value){
			this.sale = value;
			Notify("Sale");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Change {
	get { return change;}
	set { if (this.change != value){
			this.change = value;
			Notify("Change");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Backord {
	get { return backord;}
	set { if (this.backord != value){
			this.backord = value;
			Notify("Backord");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ExcludeComment {
	get { return excludeComment;}
	set { if (this.excludeComment != value){
			this.excludeComment = value;
			Notify("ExcludeComment");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ParentRelease {
	get { return parentRelease;}
	set { if (this.parentRelease != value){
			this.parentRelease = value;
			Notify("ParentRelease");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyShippedOnTime {
	get { return qtyShippedOnTime; }
	set { if (this.qtyShippedOnTime != value){
			this.qtyShippedOnTime = value;
			Notify("QtyShippedOnTime");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyShippedLate {
	get { return qtyShippedLate; }
	set { if (this.qtyShippedLate != value){
			this.qtyShippedLate = value;
			Notify("QtyShippedLate");
		}
	}
}    
        
[System.Runtime.Serialization.DataMember]
public
string FixManual {
	get { return fixManual; }
	set { if (this.fixManual != value){
			this.fixManual = value;
			Notify("FixManual");
		}
	}
}         
         
[System.Runtime.Serialization.DataMember]
public
string Note {
	get { return note; }
	set { if (this.note != value){
			this.note = value;
			Notify("Note");
		}
	}
}                

[System.Runtime.Serialization.DataMember]
public
DateTime DateRequestFromCum {
	get { return dateRequestFromCum; }
	set { if (this.dateRequestFromCum != value){
			this.dateRequestFromCum = value;
			Notify("DateRequestFromCum");
		}
	}
} 

[System.Runtime.Serialization.DataMember]
public
ShipExport ShipExport {
	get { return shipExport; }
	set { if (this.shipExport != value){
			this.shipExport = value;
			Notify("ShipExport");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
ShipExportContainer ShipExportContainer {
	get { return shipExportContainer; }
	set {
        this.shipExportContainer = value;
        Notify("ShipExportContainer");		
	}
}

public override
bool Equals(object obj){
	if (obj is ShipExportSum)
		return	this.OrderNum.Equals(((ShipExportSum)obj).OrderNum) &&
				this.Item.Equals(((ShipExportSum)obj).Item) &&
				this.Release.ToUpper().Equals(((ShipExportSum)obj).Release.ToUpper());
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void adjustQtyPpmCalcsValues(){
    QtyPpm      = this.QtyShipped > this.QtyOrder ? 0 : this.QtyOrder - this.QtyShipped; //this is old logic adjust later by new logic on bottom code
    if ( DateUtil.minorHour(DateRequest) < DateUtil.minorHour(ShipDate))
        QtyPpm = QtyShippedLate;

    //if qty ordered > qty shipped and nothing late then PPM = 0    
    if (QtyOrder > QtyShipped && DateUtil.minorHour(DateRequest) <= DateUtil.minorHour(ShipDate))
        QtyPpm=0;
    //if qtyOrdered > qtyshipped, and late PPM equals to only the late quantity
    if (QtyOrder > QtyShipped && DateUtil.minorHour(DateRequest) > DateUtil.minorHour(ShipDate))
        QtyPpm=QtyShippedLate;


     QtyPpm=QtyShippedLate;//for now QtyPpm=QtyShippedLate 
}

public
void adjustCalcsValues(){
    this.DtWkMonthWkDesc=DateUtil.convertToDateDesc(DateRequest);

    adjustQtyPpmCalcsValues();
           
    Backord     = (this.QtyShipped < this.QtyOrder) ? BACKORDER_BACK : BACKORDER_ORDER;
    
    ActualDays  = Convert.ToInt32((  DateUtil.minorHour(DateRequest) - DateUtil.minorHour(ChangeDate)   ).TotalDays);
    
    Sale = (string.IsNullOrEmpty(MinSales) && string.IsNullOrEmpty(MajSales)) ? SALE_SERVICE_NOT_IN : SALE_SERVICE_IN;

    ExcludeComment = EXCLUDE_COMM_GOOD;
    if (Backord.Equals(BACKORDER_BACK))
        ExcludeComment = EXCLUDE_COMM_BACK;
    if (QtyOrder <=0)
        ExcludeComment = EXCLUDE_COMM_BAD_REC;
    if (shipExport!= null && shipExport.QtyOrder <=0)
        ExcludeComment = EXCLUDE_COMM_BAD_REC;

    Compliance = "";    

    //update ShipExportSum set Include = 'Y' where  QtyShippedLate =0
    //update ShipExportSum set Include = 'N' where  QtyShippedLate>0 and ActualDays < LeadTime
    Include = Constants.STRING_YES;     //by default Y , because on update when Empty Include point to Y
    if (QtyShippedLate > 0 && ActualDays < LeadTime)
        Include = Constants.STRING_NO;

    //if (Late) and DateREquest < ChangeDate + leadtime--->Include = N
    if (DateUtil.minorHour(DateRequest) < DateUtil.minorHour(ShipDate) &&      
        DateUtil.minorHour(DateRequest) < DateUtil.minorHour(ChangeDate.AddDays(LeadTime))) { 
        Include = Constants.STRING_NO;
        if (QtyPpm == 0)
            QtyPpm = QtyShipped;
    }
}

public
void copy(ShipExport shipExport){    
    this.ShipExport    = shipExport;
    this.OrderNum      = shipExport.OrderNum;
    this.Item          = shipExport.Item;
    this.Release       = shipExport.OrdType.Equals("B") ? shipExport.ReleaseBase:""; //no matter will be filled later, when found main record
    this.Site          = shipExport.Site;

    this.BillTo        = shipExport.BillTo;
    this.ShipTo        = shipExport.ShipTo;
	this.CustPO        = shipExport.CustPO;
	this.OrdType       = shipExport.OrdType;
	this.Product       = shipExport.Product;
	this.DateRequest   = shipExport.DateRequest;
    this.CreateDate    = shipExport.CreateDate;
    if (OrdType.Equals("S"))
	    this.ChangeDate    = shipExport.ChangeDate != DateUtil.MinValue ? shipExport.ChangeDate: shipExport.CreateDate;  
	this.ShipDate      = shipExport.ShipDate;
    this.MinGroup      = shipExport.MinGroup;
    this.MajGroup      = shipExport.MajGroup;
	this.MinSales      = shipExport.MinGroup;
	this.MajSales      = shipExport.MajSales;
	this.Ppap          = shipExport.Ppap;	        
	this.LeadTime      = shipExport.LeadTime;
    this.LeadTime2     = shipExport.LeadTime2;
    this.LeadTime3     = shipExport.LeadTime3;
    this.CumQty        = shipExport.CumQty;

    this.TradPartner   = shipExport.TradPartner;
}

public
bool sameChildsReleases(){
    bool            ballSameChildRelese = true;
    string          schildRelease       = "";

    for (int i=0; i < shipExportContainer.Count && ballSameChildRelese; i++) {
        ShipExport  shipExportAux = shipExportContainer[i];
        if ( i > 0 && !schildRelease.ToUpper().Equals(shipExportAux.Release))
            ballSameChildRelese = false;
        schildRelease = shipExportAux.Release;
    }

    return ballSameChildRelese;
}

public
ShipExport getLastChildsRelease(string sreleaseBase){
    DateTime    dposted         =DateUtil.MinValue;
    ShipExport  shipExportResult=null;
    
    for (int i=0; i < shipExportContainer.Count; i++) {
        ShipExport  shipExport = shipExportContainer[i];

        if (!shipExport.Release.ToUpper().Equals(sreleaseBase.ToUpper()) && shipExport.PostDate > dposted) { 
            shipExportResult= shipExport;        
            dposted         = shipExport.PostDate;
        }   
    }

    return shipExportResult;
}

public
ShipExport getLastChildsPosted(){
    DateTime    dposted         =DateUtil.MinValue;
    ShipExport  shipExportResult=null;
    
    for (int i=0; i < shipExportContainer.Count; i++) {
        ShipExport  shipExport = shipExportContainer[i];

        if (shipExport.PostDate > dposted) { 
            shipExportResult= shipExport;        
            dposted         = shipExport.PostDate;
        }   
    }

    return shipExportResult;
}

public
string NoteSub {
	get {
        string snoteAux = note;

        if (snoteAux.Length > 10)
            snoteAux = snoteAux.Substring(0,10).Replace("\n","");
        return snoteAux; }
	set {
        Notify("NoteSub");		
	}
}  

public
decimal QtyBack {
	get {
            decimal qtyBack = QtyOrder - QtyShipped;
            if (qtyBack < 0)
                qtyBack=0;
            return qtyBack;
        }
	set { 
			Notify("QtyBack");		
	}
}

} // class
} // package