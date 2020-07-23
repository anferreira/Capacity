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

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class InventoryObjectivePartDtl : BusinessObject {

private int hdrId;
private int detail;
private int subDtl;
private DateTime dateObjective;
private decimal daysOnHand;
private decimal qty;
private decimal qtyReported;

private string partShow="";
private int seqShow=0;
private decimal qtyHotListShow=0;
private decimal dailyRequiredShow=0;
private decimal qtyDailyHotListShow=0;


#if !WEB
internal
#else
public
#endif
InventoryObjectivePartDtl(){
	this.hdrId = 0;
	this.detail = 0;
	this.subDtl = 0;
	this.dateObjective = DateUtil.MinValue;
	this.daysOnHand = 0;
	this.qty = 0;
	this.qtyReported = 0;
}

internal
InventoryObjectivePartDtl(
	int hdrId,
	int detail,
	int subDtl,
	DateTime dateObjective,
	decimal daysOnHand,
	decimal qty,
	decimal qtyReported)
{
	this.hdrId = hdrId;
	this.detail = detail;
	this.subDtl = subDtl;
	this.dateObjective = dateObjective;
	this.daysOnHand = daysOnHand;
	this.qty = qty;
	this.qtyReported = qtyReported;
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
DateTime DateObjective {
	get { return dateObjective;}
	set { if (this.dateObjective != value){
			this.dateObjective = value;
			Notify("DateObjective");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal DaysOnHand {
	get { return daysOnHand;}
	set { if (this.daysOnHand != value){
			this.daysOnHand = value;
			Notify("DaysOnHand");
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
            DailyRequiredShow= DailyRequiredShow;
            Notify("DailyRequiredShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyReported {
	get { return qtyReported;}
	set { if (this.qtyReported != value){
			this.qtyReported = value;
			Notify("QtyReported");
		}
	}
}

public
string PartShow {
	get { return partShow;}
	set { if (this.partShow != value){
			this.partShow = value;
			Notify("PartShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int SeqShow {
	get { return seqShow;}
	set { if (this.seqShow != value){
			this.seqShow = value;
			Notify("SeqShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyHotListShow {
	get { return qtyHotListShow; }
	set { if (this.qtyHotListShow != value){
			this.qtyHotListShow = value;		
            QtyDailyHotListShow = QtyDailyHotListShow;
            Notify("QtyHotListShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal DailyRequiredShow {
	get {
        dailyRequiredShow = qty / Constants.PRODUCTION_DAYS_PERWEEK;
        return dailyRequiredShow;
    }set { if (this.dailyRequiredShow != value){
			this.dailyRequiredShow = value;		
            Notify("DailyRequiredShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyDailyHotListShow {
	get {
        qtyDailyHotListShow = qtyHotListShow / Constants.PRODUCTION_DAYS_PERWEEK;
        return qtyDailyHotListShow;
    }set { if (this.qtyDailyHotListShow != value){
			this.qtyDailyHotListShow = value;		
            Notify("QtyDailyHotListShow");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is InventoryObjectivePartDtl)
		return	this.hdrId.Equals(((InventoryObjectivePartDtl)obj).HdrId) &&
				this.detail.Equals(((InventoryObjectivePartDtl)obj).Detail) &&
				this.subDtl.Equals(((InventoryObjectivePartDtl)obj).SubDtl);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(InventoryObjectivePartDtl inventoryObjectivePartDtl){	
	this.HdrId=inventoryObjectivePartDtl.HdrId;
	this.Detail=inventoryObjectivePartDtl.Detail;
	this.SubDtl=inventoryObjectivePartDtl.SubDtl;
	this.DateObjective=inventoryObjectivePartDtl.DateObjective;
	this.DaysOnHand=inventoryObjectivePartDtl.DaysOnHand;
	this.Qty=inventoryObjectivePartDtl.Qty;
	this.QtyReported=inventoryObjectivePartDtl.QtyReported;	

    this.PartShow=inventoryObjectivePartDtl.PartShow;
	this.SeqShow=inventoryObjectivePartDtl.SeqShow;	
}



} // class
} // package