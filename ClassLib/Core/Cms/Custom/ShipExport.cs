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
class ShipExport : LeadTimeBase {

public const string EXPORT_830      = "830";
public const string EXPORT_862      = "862";
public const string EXPORT_862_RAN  = "862RAN";
public const string EXPORT_ORDER    = "ORDER";

public const string ORDER_TYPE_BLANK= "B";
public const string ORDER_TYPE_STD  = "S";

public const int IMAX_EXPORT_LOOP_COUNTER =50;

private string site;
private decimal bol;
private decimal bolItem;
private string billTo;
private string shipTo;
private DateTime shipDate;
private DateTime dateRequest;
private DateTime createDate;
private DateTime postDate;
private decimal orderNum;
private decimal item;
private string release;
private string ordType;
private string product;
private string custPart;
private decimal qtyShipped;
private decimal qtyBack;
private decimal qtyExpec;
private decimal qtyOrder;
private string prodType;
private string backFlag;
private DateTime lineBookDate;
private DateTime custReqDate;
private string backOrderFlag;
private string market;
private DateTime exportDate;

private DateTime orderDate;
private decimal firstQty;
private string majGroup;
private string minGroup;
private string minSales;
private string majSales;

private string tradPartner;
private string shipToLoc;
private decimal cumQty;
private string ran;
private DateTime lTBookDate;
private decimal lTBookQty;

private DateTime lastDateChange;
private DateTime lastQtyDateChange;
private decimal lastQtyChange;
private string custPO;
private string ppap;
private string shipExportSource;
private string trlp;
private string ediRelease;

private string releaseBase;
private decimal qtyOrdBase;
private decimal cumRequired;
private decimal qtyOrderedFromCum;

private decimal cumPrior;
private decimal qtyRequired;
private DateTime changeDate;

private ShipExportDtlContainer shipExportDtlContainer;
private ShipExportReleaseContainer shipExportReleaseContainer;


#if !WEB
internal
#else
public
#endif
ShipExport() : base(){
	this.site = "";
	this.bol = 0;
	this.bolItem = 0;
	this.billTo = "";
	this.shipTo = "";
	this.shipDate = DateUtil.MinValue;
	this.dateRequest = DateUtil.MinValue;
	this.createDate = DateUtil.MinValue;
	this.postDate = DateUtil.MinValue;
	this.orderNum = 0;
	this.item = 0;
	this.release = "";
	this.ordType = "";
	this.product = "";
	this.custPart = "";
	this.qtyShipped = 0;
	this.qtyBack = 0;
	this.qtyExpec = 0;
	this.qtyOrder = 0;
	this.prodType = "";
	this.backFlag = "";
	this.lineBookDate = DateUtil.MinValue;
	this.custReqDate = DateUtil.MinValue;
	this.backOrderFlag = "";
	this.market = "";
	this.exportDate= DateUtil.MinValue;

    this.orderDate = DateUtil.MinValue;    
    this.firstQty =0;
    this.majGroup = "";
    this.minGroup = "";
    this.minSales = "";    
    this.majSales = "";

    this.tradPartner = "";
    this.shipToLoc = "";
    this.cumQty = 0;
    this.ran = "";

    this.lTBookDate = DateUtil.MinValue;
    this.lTBookQty  = 0;

    this.lastDateChange     = DateUtil.MinValue;
    this.lastQtyDateChange  = DateUtil.MinValue;
    this.lastQtyChange      = 0;
    this.custPO             = "";
    this.ppap               = Constants.STRING_NO;
    this.shipExportSource   = EXPORT_ORDER;
    this.trlp               = Constants.STRING_NO;
    this.ediRelease         = "";
    
    this.releaseBase        = "";
    this.qtyOrdBase         = 0;
    this.cumRequired        = 0;
    this.qtyOrderedFromCum         = 0;

    this.cumPrior           = 0;
    this.qtyRequired        = 0;
    this.changeDate         = DateUtil.MinValue;

    this.shipExportDtlContainer = new ShipExportDtlContainer();
    this.shipExportReleaseContainer = new ShipExportReleaseContainer();
}
        /*
internal
ShipExport(
	string site,
	decimal bol,
	decimal bolItem,
	string billTo,
	string shipTo,
	DateTime shipDate,
	DateTime dateRequest,
	DateTime createDate,
	DateTime postDate,
	decimal orderNum,
	decimal item,
	string release,
	string ordType,
	string product,
	string custPart,
	decimal qtyShipped,
	decimal qtyBack,
	decimal qtyExpec,
	decimal qtyOrder,
	string prodType,
	string backFlag,
	DateTime lineBookDate,
	DateTime custReqDate,
	string backOrderFlag,
	string market,
	DateTime exportDate,
    DateTime orderDate,
    decimal firstQty,
    string majGroup,
    string minGroup,
    string minSales,
    string majSales,
    string tradPartner,
    string shipToLoc,
    decimal cumQty,
    string ran){
	this.site = site;
	this.bol = bol;
	this.bolItem = bolItem;
	this.billTo = billTo;
	this.shipTo = shipTo;
	this.shipDate = shipDate;
	this.dateRequest = dateRequest;
	this.createDate = createDate;
	this.postDate = postDate;
	this.orderNum = orderNum;
	this.item = item;
	this.release = release;
	this.ordType = ordType;
	this.product = product;
	this.custPart = custPart;
	this.qtyShipped = qtyShipped;
	this.qtyBack = qtyBack;
	this.qtyExpec = qtyExpec;
	this.qtyOrder = qtyOrder;
	this.prodType = prodType;
	this.backFlag = backFlag;
	this.lineBookDate = lineBookDate;
	this.custReqDate = custReqDate;
	this.backOrderFlag = backOrderFlag;
	this.market = market;
	this.exportDate = exportDate;

    this.orderDate = orderDate;
    this.firstQty = firstQty;
    this.majGroup = majGroup;
    this.minGroup = minGroup;
    this.minSales = minSales;    
    this.majSales = majSales;

    this.tradPartner= tradPartner;
    this.shipToLoc  = shipToLoc;
    this.cumQty     = cumQty;
    this.ran        = ran;
}*/

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
DateTime CreateDate {
	get { return createDate;}
	set { if (this.createDate != value){
			this.createDate = value;
			Notify("CreateDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime PostDate {
	get { return postDate;}
	set { if (this.postDate != value){
			this.postDate = value;
			Notify("PostDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal OrderNum {
	get { return orderNum; }
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
decimal QtyBack {
	get { return qtyBack;}
	set { if (this.qtyBack != value){
			this.qtyBack = value;
			Notify("QtyBack");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyExpec {
	get { return qtyExpec;}
	set { if (this.qtyExpec != value){
			this.qtyExpec = value;
			Notify("QtyExpec");
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
string ProdType {
	get { return prodType;}
	set { if (this.prodType != value){
			this.prodType = value;
			Notify("ProdType");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BackFlag {
	get { return backFlag;}
	set { if (this.backFlag != value){
			this.backFlag = value;
			Notify("BackFlag");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime LineBookDate {
	get { return lineBookDate;}
	set { if (this.lineBookDate != value){
			this.lineBookDate = value;
			Notify("LineBookDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime CustReqDate {
	get { return custReqDate;}
	set { if (this.custReqDate != value){
			this.custReqDate = value;
			Notify("CustReqDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BackOrderFlag {
	get { return backOrderFlag;}
	set { if (this.backOrderFlag != value){
			this.backOrderFlag = value;
			Notify("BackOrderFlag");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Market {
	get { return market;}
	set { if (this.market != value){
			this.market = value;
			Notify("Market");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime ExportDate {
	get { return exportDate;}
	set { if (this.exportDate != value){
			this.exportDate = value;
			Notify("ExportDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime OrderDate {
	get { return orderDate; }
	set { if (this.orderDate != value){
			this.orderDate = value;
			Notify("OrderDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FirstQty {
	get { return firstQty; }
	set { if (this.firstQty != value){
			this.firstQty = value;
			Notify("FirstQty");
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
	get { return minSales; }
	set { if (this.minSales != value){
			this.minSales = value;
			Notify("MinSales");
		}
	}
}
       
[System.Runtime.Serialization.DataMember]
public
string MajSales {
	get { return majSales; }
	set { if (this.majSales != value){
			this.majSales = value;
			Notify("majSales");
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

[System.Runtime.Serialization.DataMember]
public
string ShipToLoc {
	get { return shipToLoc; }
	set { if (this.shipToLoc != value){
			this.shipToLoc = value;
			Notify("ShipToLoc");
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
string Ran {
	get { return ran; }
	set { if (this.ran != value){
			this.ran = value;
			Notify("Ran");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime LTBookDate {
	get { return lTBookDate; }
	set { if (this.lTBookDate != value){
			this.lTBookDate = value;
			Notify("LTBookDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal LTBookQty {
	get { return lTBookQty; }
	set { if (this.lTBookQty != value){
			this.lTBookQty = value;
			Notify("LTBookQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime LastDateChange {
	get { return lastDateChange; }
	set { if (this.lastDateChange != value){
			this.lastDateChange = value;
			Notify("LastDateChange");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
DateTime LastQtyDateChange {
	get { return lastQtyDateChange; }
	set { if (this.lastQtyDateChange != value){
			this.lastQtyDateChange = value;
			Notify("LastQtyDateChange");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal LastQtyChange {
	get { return lastQtyChange; }
	set { if (this.lastQtyChange != value){
			this.lastQtyChange = value;
			Notify("LastQtyChange");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string CustPO {
	get { return custPO; }
	set { if (this.custPO != value){
			this.custPO = value;
			Notify("CustPO");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Ppap{
	get { return ppap; }
	set { if (this.ppap != value){
			this.ppap = value;
			Notify("Ppap");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ShipExportSource {
	get { return shipExportSource;}
	set { if (this.shipExportSource != value){
			this.shipExportSource = value;
			Notify("ShipExportSource");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Trlp {
	get { return trlp; }
	set { if (this.trlp != value){
			this.trlp = value;
			Notify("Trlp");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string EdiRelease {
	get { return ediRelease; }
	set { if (this.ediRelease != value){
			this.ediRelease = value;
			Notify("EdiRelease");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
string ReleaseBase {
	get { return releaseBase; }
	set { if (this.releaseBase != value){
			this.releaseBase = value;
			Notify("ReleaseBase");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyOrdBase {
	get { return qtyOrdBase; }
	set { if (this.qtyOrdBase != value){
			this.qtyOrdBase = value;
			Notify("QtyOrdBase");
		}
	}
}
        
[System.Runtime.Serialization.DataMember]
public
decimal CumRequired {
	get { return cumRequired; }
	set { if (this.cumRequired != value){
			this.cumRequired = value;
			Notify("CumRequired");
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
decimal CumPrior {
	get { return cumPrior; }
	set { if (this.cumPrior != value){
			this.cumPrior = value;
			Notify("CumPrior");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyRequired {
	get { return qtyRequired; }
	set { if (this.qtyRequired != value){
			this.qtyRequired = value;
			Notify("QtyRequired");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime ChangeDate {
	get { return changeDate; }
	set { if (this.changeDate != value){
			this.changeDate = value;
			Notify("ChangeDate");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is ShipExport)
		return	this.site.Equals(((ShipExport)obj).Site) &&
				this.bol.Equals(((ShipExport)obj).Bol) &&
				this.bolItem.Equals(((ShipExport)obj).BolItem);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}


[System.Runtime.Serialization.DataMember]
public
ShipExportDtlContainer ShipExportDtlContainer {
	get { return shipExportDtlContainer; }
	set { if (this.shipExportDtlContainer != value){
			this.shipExportDtlContainer = value;
			Notify("ShipExportDtlContainer");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
ShipExportReleaseContainer ShipExportReleaseContainer {
	get { return shipExportReleaseContainer; }
	set { if (this.shipExportReleaseContainer != value){
			this.shipExportReleaseContainer = value;
			Notify("ShipExportReleaseContainer");
		}
	}
}


public
void fillRedundances(){    	
    for (int i=0; i < shipExportDtlContainer.Count; i++) {
        ShipExportDtl shipExportDtl = shipExportDtlContainer[i];

        shipExportDtl.Site      = this.Site;
        shipExportDtl.Bol       = this.Bol;
        shipExportDtl.BolItem   = this.BolItem;
        shipExportDtl.Detail    = i+1;        
	}

    if (this.Trlp.Equals(Constants.STRING_NO)  || this.ShipExportSource.Equals(EXPORT_ORDER))
        shipExportDtlContainer.calculateQtyChange(Release);

    if (!this.OrdType.Equals("B")) //if not blanket
        calculateDateChanged();

    if (LastDateChange == DateUtil.MinValue) // last date change not found, fill created date by default
        LastDateChange = CreateDate;
    if (LastQtyDateChange == DateUtil.MinValue) // last date qty change not found, fill created date by default
        LastQtyDateChange = CreateDate;

    for (int i=0; i < shipExportReleaseContainer.Count; i++) {
        ShipExportRelease shipExportRelease = shipExportReleaseContainer[i];

        shipExportRelease.Site      = this.Site;
        shipExportRelease.Bol       = this.Bol;
        shipExportRelease.BolItem   = this.BolItem;
        shipExportRelease.Detail    = i+1;        
	}

    if (Release.ToUpper().Equals(ReleaseBase.ToUpper()))
        CumRequired = shipExportReleaseContainer.Count > 0 ? shipExportReleaseContainer[0].RelCum : 0;
    QtyRequired         = CumQty        - CumPrior;
    QtyOrderedFromCum   = CumRequired   - CumPrior;   
}


public
void calculateDateChanged(){    	    
    DateTime        lastDateChangeFound     = DateUtil.MinValue;
    DateTime        lastQtyDateChangeFound  = DateUtil.MinValue;
    decimal         lastQtyChangeFound      = 0;
    ShipExportDtl   shipExportDtlPrior      = null;
    
    for (int i=0; i < shipExportDtlContainer.Count; i++) {
        ShipExportDtl shipExportDtl = shipExportDtlContainer[i];

        if (i == 0){
           lastDateChangeFound      = shipExportDtl.getTimeStampAsDate();     //initialize
           lastQtyChangeFound       = shipExportDtl.RelQtyInvUnit;
           lastQtyDateChangeFound   = shipExportDtl.getTimeStampAsDate();                         
        }

        if (shipExportDtlPrior!= null){
            if (shipExportDtl.RelQtyInvUnit != shipExportDtlPrior.RelQtyInvUnit){
                lastQtyChangeFound      = shipExportDtl.RelQtyInvUnit;
                lastQtyDateChangeFound  = shipExportDtl.getTimeStampAsDate();
            }

            if (shipExportDtl.ShipDate != shipExportDtlPrior.ShipDate)
            //if (shipExportDtl.DateRequest != shipExportDtlPrior.DateRequest)
                lastDateChangeFound = shipExportDtl.getTimeStampAsDate();
        }
        
        shipExportDtlPrior = shipExportDtl;        
	}        

    lastDateChange      = lastDateChangeFound;
    lastQtyDateChange   = lastQtyDateChangeFound;
    lastQtyChange       = lastQtyChangeFound;

    if (shipExportDtlContainer.Count > 0){ //check if no changes
        lastDateChangeFound      = shipExportDtlContainer[0].getTimeStampAsDate();
        lastQtyChangeFound       = shipExportDtlContainer[0].RelQtyInvUnit;
        lastQtyDateChangeFound   = shipExportDtlContainer[0].getTimeStampAsDate();        

        if (DateUtil.sameDate(lastDateChange,lastDateChangeFound))
            lastDateChange= DateUtil.MinValue;
        if (DateUtil.sameDate(lastQtyDateChange, lastQtyDateChangeFound)){    
            lastQtyDateChange   = DateUtil.MinValue;
            lastQtyChange       = 0;
        }
    }

}

public
void copy(UpCum01PView upCum01PView){
    this.Site         = upCum01PView.FEPLTC;//plant
    this.Bol          = upCum01PView.FGBOL;
    this.BolItem      = upCum01PView.FGENT; 

    this.BillTo       = upCum01PView.FEBCS;
    this.ShipTo       = upCum01PView.FESCS;
    this.ShipDate     = upCum01PView.FESDAT;
    this.DateRequest  = upCum01PView.UPEXSD;
        
    this.CreateDate   = upCum01PView.FirstDate;
    try{this.PostDate = DateUtil.parseDate(upCum01PView.FEFUTRShow, DateUtil.MMDDYYYY); }catch { this.PostDate = DateUtil.MinValue; };

    this.OrderNum     = upCum01PView.FGORD;
    this.Item         = upCum01PView.FGITEM;
    this.Release      = upCum01PView.FGRLNO;
    this.OrdType      = upCum01PView.DCOTYP;

    this.Product      = upCum01PView.FGPART;
    this.CustPart     = upCum01PView.FGCPT;

    this.QtyShipped   = upCum01PView.FGQSHP;
    this.QtyBack      = upCum01PView.QtyBack;
    this.QtyExpec     = upCum01PView.DDQTBI;
    this.QtyOrder     = upCum01PView.QtyOrder;

    this.ProdType     = "";
    this.BackFlag     = this.QtyBack > 0 ? "Y":"N";
    this.BackOrderFlag= this.BackFlag;
    this.LineBookDate = upCum01PView.DCODAT; //create date
    this.CustReqDate  = upCum01PView.CustDate;
    this.ExportDate   = DateTime.Now;            
    this.Market       = upCum01PView.BVCLAS;

    this.OrderDate    = upCum01PView.FirstDate;
	this.FirstQty     = upCum01PView.FirstQty;
	this.MajGroup     = upCum01PView.AVMAJG;
	this.MinGroup     = upCum01PView.AVMING;
	this.MinSales     = upCum01PView.AVMINS;
    this.MajSales     = upCum01PView.AVMAJS;

    this.TradPartner  = upCum01PView.SMTRPT;
    this.ShipToLoc    = upCum01PView.SMSTXL;
    this.CumQty       = upCum01PView.FGCCUM;
    this.CumPrior     = upCum01PView.FGPCUM;
    this.QtyRequired  = CumQty - CumPrior;
    this.Ran          = upCum01PView.FGRAN;
    this.LTBookDate   = upCum01PView.LTBookDate;
    this.LTBookQty    = upCum01PView.LTBookQty;
    this.CustPO       = upCum01PView.FGCPO;
    this.Ppap         = upCum01PView.Ppap;
    this.ShipExportSource = upCum01PView.ShipExportSource;
    this.Trlp         = upCum01PView.Trlp;
    this.EdiRelease   = upCum01PView.FGCREL;

    this.LeadTime     = upCum01PView.LeadTime;
    this.LeadTime2    = upCum01PView.LeadTime2;
    this.LeadTime3    = upCum01PView.LeadTime3;

    this.ReleaseBase  = upCum01PView.ReleaseBase;
    this.QtyOrdBase   = upCum01PView.QtyOrdBase;
                    
    this.ShipExportDtlContainer       = upCum01PView.ShipExportDtlContainer;
    this.ShipExportReleaseContainer   = upCum01PView.ShipExportReleaseContainer;

    upCum01PView.ExportShow     = Constants.STRING_YES;
    upCum01PView.ExportDateShow = this.ExportDate;

    if (this.OrdType.Equals("B")) {
        this.LastQtyChange    =upCum01PView.LastQtyChange;
        this.LastQtyDateChange=upCum01PView.LastQtyDateChange;                
        this.LastDateChange   =upCum01PView.LastDateChange;
    }
    this.ChangeDate = upCum01PView.ChangeDate;
}

} // class
} // package