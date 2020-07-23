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
class DemandDCompareView : HotListStringDays {

private int hdrId;
private string plant;
private string source;
private string tPartner;
private DateTime relDate;
private string relNum;
private string shipLoc;
private string part;
private DateTime sDate;
private decimal netQty;

private DateTime relDate2;
private string relNum2;
       
internal
DemandDCompareView(): base(){
    this.hdrId = 0;
    this.plant = "";
    this.source = "";
	this.tPartner = "";
    this.relDate = DateUtil.MinValue;
    this.relNum = "";
	this.shipLoc = "";
	this.part = "";
	this.sDate = DateUtil.MinValue;
	this.netQty = 0;    

    this.relDate2   = DateUtil.MinValue;
    this.relNum2    = "";
}


[System.Runtime.Serialization.DataMember]
public
int HdrId {
	get { return hdrId; }
	set { if (this.hdrId != value){
			this.hdrId = value;
			Notify("HdrId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Plant {
	get { return plant; }
	set { if (this.plant != value){
			this.plant = value;
			Notify("Plant");
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
DateTime RelDate2 {
	get { return relDate2;}
	set { if (this.relDate2 != value){
			this.relDate2 = value;
			Notify("RelDate2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RelNum2 {
	get { return relNum2;}
	set { if (this.relNum2 != value){
			this.relNum2 = value;
			Notify("RelNum2");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is DemandDCompareView)
		return  this.Source.ToUpper().Equals(((DemandDCompareView)obj).Source.ToUpper()) &&
                this.TPartner.ToUpper().Equals(((DemandDCompareView)obj).TPartner.ToUpper()) &&
                this.RelNum.ToUpper().Equals(((DemandDCompareView)obj).RelNum.ToUpper()) &&                
                this.ShipLoc.ToUpper().Equals(((DemandDCompareView)obj).ShipLoc.ToUpper()) &&                
                this.Part.ToUpper().Equals(((DemandDCompareView)obj).Part);
    else
		return false;
}

public 
bool Equals862(object obj){
	if (obj is DemandDCompareView) 
		return this.HdrId == ((DemandDCompareView)obj).HdrId && Equals(obj);
    else
		return false;
}
       
public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(DemandDCompareView demandDCompareView){	

    this.HdrId      = demandDCompareView.HdrId;
    this.Plant      = demandDCompareView.Plant;
    this.Source     = demandDCompareView.Source;
    this.TPartner   = demandDCompareView.TPartner;
    this.RelDate    = demandDCompareView.RelDate;
    this.RelNum     = demandDCompareView.RelNum;
    this.ShipLoc    = demandDCompareView.ShipLoc;
    this.Part       = demandDCompareView.Part;
    this.SDate      = demandDCompareView.SDate;
    this.NetQty     = demandDCompareView.NetQty;

    base.copy(demandDCompareView);
}

public
void copy(DemandDay demandDay){	

    this.HdrId      = demandDay.Id;
    this.Plant      = demandDay.Plant;
    this.Source     = demandDay.Source;
    this.TPartner   = demandDay.TPartner;
    this.RelDate    = demandDay.Created;
    this.RelNum     = demandDay.NewRelNum;
    this.ShipLoc    = demandDay.ShipLoc;
    this.Part       = demandDay.Part;
    this.SDate      = demandDay.RelDate;
    this.NetQty     = demandDay.CumRequired;
    
    this.RelNum2    = demandDay.OldRelNum;
    this.RelDate2   = demandDay.OldRelDate;
}


public
Decimal getQtyByDateBackUntilFoundQty(DateTime runDate, DateTime dateFilter){
    decimal dqty= 0; //try to get prior qty, but get until qty bigger than 0
    int     k   = 0;
    do {
        dqty = this.getQtyByDate(runDate, dateFilter.AddDays(k));
        k--;
    } while (dateFilter.AddDays(k) >= runDate && dqty == 0);

    return dqty;
}

public
Decimal getQtyByDateForwardUntilFoundQty(DateTime runDate, DateTime dateFilter){
    decimal dqty= 0; //try to get prior qty, but get until qty bigger than 0
    int     k   = 0;
    do {
        dqty = this.getQtyByDate(runDate, dateFilter.AddDays(k));
        k++;
    } while (dateFilter.AddDays(k) < runDate.AddDays(Constants.MAX_HOTLIST_DAYS) && dqty == 0);

    return dqty;
}

public
void calculateNetsQty(DateTime runDate){
    decimal dqty        =0;
    decimal dpriorQty   =0;

    for (int i= Constants.MAX_HOTLIST_DAYS; i >= 0;i--){ //-1 Pastdue        
        dqty = this.getQtyByDateBackUntilFoundQty(runDate,runDate.AddDays(i));

        if (dqty !=  0){
            dpriorQty = this.getQtyByDateBackUntilFoundQty(runDate,runDate.AddDays(i-1));
            this.setQtyByDate(runDate, runDate.AddDays(i),dqty -dpriorQty);
        }        
    }    
}



} // class
} // package