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
class DemandD : BusinessObject {

public const string SOURCE_830= "830PLAN";
public const string SOURCE_862= "862SHIP";
public const string SOURCE_ORDER= "ORDER";

private int hdrId;
private int detail;
private string source;
private string tPartner;
private DateTime relDate;
private string relNum;
private string billTo;
private string shipTo;
private string shipLoc;
private decimal shipLTim;
private string shipLTUn;
private string part;
private string custPart;
private decimal currCum;
private decimal faAutCum;
private decimal maAutCum;
private string curShDoc;
private DateTime sDate;
private DateTime endDate;
private decimal qtyCum;
private decimal adjNQty;
private decimal netQty;
private string timeCode;
private decimal trlpKeyId;
private string discard;
private decimal logNum;

private bool processTransform;

#if !WEB
internal
#else
public
#endif
DemandD(){
	this.hdrId = 0;
	this.detail = 0;
	this.source = "";
	this.tPartner = "";
	this.relDate = DateUtil.MinValue;
	this.relNum = "";
	this.billTo = "";
	this.shipTo = "";
	this.shipLoc = "";
	this.shipLTim = 0;
	this.shipLTUn = "";
	this.part = "";
	this.custPart = "";
	this.currCum = 0;
	this.faAutCum = 0;
	this.maAutCum = 0;
	this.curShDoc = "";
	this.sDate = DateUtil.MinValue;
	this.endDate = DateUtil.MinValue;
	this.qtyCum = 0;
	this.adjNQty = 0;
    this.netQty = 0;
    this.timeCode = "";
    this.trlpKeyId = 0;
    this.discard = Constants.STRING_NO;
    this.logNum = 0;

    this.processTransform = true;
}

internal
DemandD(
	int hdrId,
    int detail,
	string source,
	string tPartner,
	DateTime relDate,
	string relNum,
	string billTo,
	string shipTo,
	string shipLoc,
	decimal shipLTim,
	string shipLTUn,
	string part,
	string custPart,
	decimal currCum,
	decimal faAutCum,
	decimal maAutCum,
	string curShDoc,
	DateTime sDate,
	DateTime endDate,
	decimal qtyCum,
	decimal adjNQty,
    decimal netQty,    
    string timeCode,
    decimal trlpKeyId,
    string discard){
	this.hdrId = hdrId;
	this.detail = detail;
	this.source = source;
	this.tPartner = tPartner;
	this.relDate = relDate;
	this.relNum = relNum;
	this.billTo = billTo;
	this.shipTo = shipTo;
	this.shipLoc = shipLoc;
	this.shipLTim = shipLTim;
	this.shipLTUn = shipLTUn;
	this.part = part;
	this.custPart = custPart;
	this.currCum = currCum;
	this.faAutCum = faAutCum;
	this.maAutCum = maAutCum;
	this.curShDoc = curShDoc;
	this.sDate = sDate;
	this.endDate = endDate;
	this.qtyCum = qtyCum;
	this.adjNQty = adjNQty;
    this.netQty = netQty;
    this.timeCode = timeCode;
    this.trlpKeyId = trlpKeyId;
    this.discard = discard;
    this.processTransform = true;
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
string TPartner {
	get { return tPartner;}
	set { if (this.tPartner != value){
			this.tPartner = value;
			Notify("TPartner");
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
string RelNum {
	get { return relNum;}
	set { if (this.relNum != value){
			this.relNum = value;
			Notify("RelNum");
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
decimal ShipLTim {
	get { return shipLTim;}
	set { if (this.shipLTim != value){
			this.shipLTim = value;
			Notify("ShipLTim");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ShipLTUn {
	get { return shipLTUn;}
	set { if (this.shipLTUn != value){
			this.shipLTUn = value;
			Notify("ShipLTUn");
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
decimal CurrCum {
	get { return currCum;}
	set { if (this.currCum != value){
			this.currCum = value;
			Notify("CurrCum");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FaAutCum {
	get { return faAutCum;}
	set { if (this.faAutCum != value){
			this.faAutCum = value;
			Notify("FaAutCum");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal MaAutCum {
	get { return maAutCum;}
	set { if (this.maAutCum != value){
			this.maAutCum = value;
			Notify("MaAutCum");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string CurShDoc {
	get { return curShDoc;}
	set { if (this.curShDoc != value){
			this.curShDoc = value;
			Notify("CurShDoc");
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
DateTime EndDate {
	get { return endDate;}
	set { if (this.endDate != value){
			this.endDate = value;
			Notify("EndDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyCum {
	get { return qtyCum;}
	set { if (this.qtyCum != value){
			this.qtyCum = value;
			Notify("QtyCum");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal AdjNQty {
	get { return adjNQty;}
	set { if (this.adjNQty != value){
			this.adjNQty = value;
			Notify("AdjNQty");
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
decimal TrlpKeyId {
    get { return trlpKeyId; }
	set { if (this.trlpKeyId != value){
			this.trlpKeyId = value;
            Notify("TrlpKeyId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Discard {
    get { return discard; }
	set { if (this.discard != value){
			this.discard = value;
            Notify("Discard");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal LogNum {
    get { return logNum; }
	set { if (this.logNum != value){
			this.logNum = value;
            Notify("LogNum");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool ProcessTransform {
    get { return processTransform; }
	set { if (this.processTransform != value){
			this.processTransform = value;
            Notify("ProcessTransform");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is DemandD)
		return	this.hdrId.Equals(((DemandD)obj).HdrId) &&
				this.detail.Equals(((DemandD)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
string ShipLTimStr {
	get { return shipLTim.ToString("0.0");}
	set {
        decimal d = Convert.ToDecimal(value);

        if (this.shipLTim != d){
			this.shipLTim = d;
			Notify("ShipLTimStr");
		}
	}
}

public
string SDateStr {
	get { return DateUtil.getDateRepresentation(SDate,DateUtil.MMDDYYYY);}
	set {
        DateTime d = DateUtil.parseDate(value, DateUtil.MMDDYYYY);

        if (this.SDate != d){
			this.SDate = d;
			Notify("SDateStr");
		}
	}
}

} // class
} // package