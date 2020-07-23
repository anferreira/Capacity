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
class DemandDCompareLeftView : HotListDays {

private int hdrId;
private string source;
private string tPartner;
private DateTime relDate;
private string relNum;
private string shipLoc;
private string part;
private DateTime sDate;
private decimal netQty;

private ArrayList arrayRelease;
        
internal
DemandDCompareLeftView(): base(){
    this.hdrId = 0;
    this.source = "";
	this.tPartner = "";
    this.relDate = DateUtil.MinValue;
    this.relNum = "";
	this.shipLoc = "";
	this.part = "";
	this.sDate = DateUtil.MinValue;
	this.netQty = 0;    

    this.arrayRelease = new ArrayList();
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

public override
bool Equals(object obj){
	if (obj is DemandDCompareLeftView)
		return  this.Source.ToUpper().Equals(((DemandDCompareLeftView)obj).Source.ToUpper()) &&
                this.TPartner.ToUpper().Equals(((DemandDCompareLeftView)obj).TPartner.ToUpper()) &&
                this.RelNum.ToUpper().Equals(((DemandDCompareLeftView)obj).RelNum.ToUpper()) &&                
                this.ShipLoc.ToUpper().Equals(((DemandDCompareLeftView)obj).ShipLoc.ToUpper()) &&                
                this.Part.ToUpper().Equals(((DemandDCompareLeftView)obj).Part);
    else
		return false;
}

public 
bool Equals862(object obj){
	if (obj is DemandDCompareLeftView) 
		return this.HdrId == ((DemandDCompareLeftView)obj).HdrId && Equals(obj);
    else
		return false;
}
       
public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(DemandDCompareLeftView DemandDCompareLeftView){	

    this.HdrId      = DemandDCompareLeftView.HdrId;
    this.Source     = DemandDCompareLeftView.Source;
    this.TPartner   = DemandDCompareLeftView.TPartner;
    this.RelDate    = DemandDCompareLeftView.RelDate;
    this.RelNum     = DemandDCompareLeftView.RelNum;
    this.ShipLoc    = DemandDCompareLeftView.ShipLoc;
    this.Part       = DemandDCompareLeftView.Part;
    this.SDate      = DemandDCompareLeftView.SDate;
    this.NetQty     = DemandDCompareLeftView.NetQty;

    base.copy(DemandDCompareLeftView);
}

public
Decimal getQtyByDateUntilFoundQty(DateTime runDate, DateTime dateFilter){
    decimal dqty= 0; //try to get prior qty, but get until qty bigger than 0
    int     k   = 0;
    do {
        dqty = this.getQtyByDate(runDate, dateFilter.AddDays(k));
        k--;
    } while (dateFilter.AddDays(k) >= runDate && dqty == 0);

    return dqty;
}

public
void calculateNetsQty(DateTime runDate){
    decimal dqty        =0;
    decimal dpriorQty   =0;

    for (int i= Constants.MAX_HOTLIST_DAYS; i >= -1;i--){ //-1 Pastdue        
        dqty = this.getQtyByDateUntilFoundQty(runDate,runDate.AddDays(i));

        if (dqty !=  0){
             dpriorQty = this.getQtyByDateUntilFoundQty(runDate,runDate.AddDays(i-1));
            this.setQtyByDate(runDate, runDate.AddDays(i),dqty -dpriorQty);
        }        
    }    
}

public
DemandRelease getDemandReleaseByIndex(int index){
    DemandRelease demandRelease = null;
    if (index >= 0 && index < arrayRelease.Count)
        demandRelease = (DemandRelease)arrayRelease[index];
    return demandRelease;
}

[System.Runtime.Serialization.DataMember]
public
DemandRelease DemandRelease1{
    get {
        DemandRelease demandRelease = getDemandReleaseByIndex(0);
        return demandRelease;
    }
	set {
        DemandRelease demandRelease = getDemandReleaseByIndex(0);
        if (demandRelease == null) { 
            demandRelease = value;
            arrayRelease.Add(demandRelease);
        }        
        if (demandRelease != value){
            demandRelease = value;
            Notify("DemandRelease1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DemandRelease DemandRelease2{
    get {
        DemandRelease demandRelease = getDemandReleaseByIndex(1);
        return demandRelease;
    }
	set {
        DemandRelease demandRelease = getDemandReleaseByIndex(1);
        if (demandRelease == null) { 
            demandRelease = value;
            arrayRelease.Add(demandRelease);
        }        
        if (demandRelease != value){
            demandRelease = value;
            Notify("DemandRelease2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal DemandRelease1Qty {
    get {
            decimal qty = 0;
            DemandRelease demandRelease = getDemandReleaseByIndex(0);
            if (demandRelease!= null)
                qty = demandRelease.Qty;
            return qty;            
        }
	set {
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal DemandRelease2Qty {
    get {
            decimal qty = 0;
            DemandRelease demandRelease = getDemandReleaseByIndex(1);
            if (demandRelease!= null)
                qty = demandRelease.Qty;
            return qty;            
        }
	set {
	}
}

} // class
} // package