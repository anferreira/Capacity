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
class DemandWeek : BusinessObject {

private int id;
private string plant;
private string source;
private string tPartner;
private string oldRelNum;
private string newRelNum;
private DateTime relDate;
private string shipLoc;
private string part;
private DateTime fromDate;
private decimal weekShip;
private decimal pastDue;
private decimal monday;
private decimal tuesday;
private decimal wednesday;
private decimal thursday;
private decimal friday;
private decimal saturday;
private decimal sunday;
private decimal totWeekReq;

private decimal orderNum;
private decimal item;
private decimal trlpKeyId;

#if !WEB
internal
#else
public
#endif
DemandWeek(){
	this.id = 0;
	this.plant = "";
	this.source = "";
	this.tPartner = "";
	this.oldRelNum = "";
	this.newRelNum = "";
    this.relDate = DateTime.MinValue;
	this.shipLoc = "";
	this.part = "";
    this.fromDate = DateUtil.MinValue;
    this.weekShip = 0;
	this.pastDue = 0;
	this.monday = 0;
	this.tuesday = 0;
	this.wednesday = 0;
	this.thursday = 0;
	this.friday = 0;
	this.saturday = 0;
	this.sunday = 0;
	this.totWeekReq = 0;

    this.orderNum  =0;
    this.item =0;
    this.trlpKeyId =0;
}

internal
DemandWeek(
	int id,
	string plant,
	string source,
	string tPartner,
	string oldRelNum,
	string newRelNum,
    DateTime relDate,
	string shipLoc,
	string part,
    DateTime fromDate,
    decimal weekShip,
	decimal pastDue,
	decimal monday,
	decimal tuesday,
	decimal wednesday,
	decimal thursday,
	decimal friday,
	decimal saturday,
	decimal sunday,
	decimal totWeekReq,
    decimal orderNum,
    decimal item,
    decimal trlpKeyId){
	this.id = id;
	this.plant = plant;
	this.source = source;
	this.tPartner = tPartner;
	this.oldRelNum = oldRelNum;
	this.newRelNum = newRelNum;
    this.relDate   = relDate;
	this.shipLoc = shipLoc;
	this.part = part;
    this.fromDate = fromDate;
    this.weekShip = weekShip;
	this.pastDue = pastDue;
	this.monday = monday;
	this.tuesday = tuesday;
	this.wednesday = wednesday;
	this.thursday = thursday;
	this.friday = friday;
	this.saturday = saturday;
	this.sunday = sunday;
	this.totWeekReq = totWeekReq;

    this.orderNum= orderNum;
    this.item   =item;
    this.trlpKeyId =trlpKeyId;
}

[System.Runtime.Serialization.DataMember]
public
int Id {
	get { return id;}
	set { if (this.id != value){
			this.id = value;
			Notify("Id");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Plant {
	get { return plant;}
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
string OldRelNum {
	get { return oldRelNum;}
	set { if (this.oldRelNum != value){
			this.oldRelNum = value;
			Notify("OldRelNum");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string NewRelNum {
	get { return newRelNum;}
	set { if (this.newRelNum != value){
			this.newRelNum = value;
			Notify("NewRelNum");
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
DateTime FromDate {
	get { return fromDate; }
	set { if (this.fromDate != value){
			this.fromDate = value;
			Notify("FromDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal WeekShip {
	get { return weekShip;}
	set { if (this.weekShip != value){
			this.weekShip = value;
			Notify("WeekShip");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal PastDue {
	get { return pastDue;}
	set { if (this.pastDue != value){
			this.pastDue = value;
			Notify("PastDue");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Monday {
	get { return monday;}
	set { if (this.monday != value){
			this.monday = value;
			Notify("Monday");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Tuesday {
	get { return tuesday;}
	set { if (this.tuesday != value){
			this.tuesday = value;
			Notify("Tuesday");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Wednesday {
	get { return wednesday;}
	set { if (this.wednesday != value){
			this.wednesday = value;
			Notify("Wednesday");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Thursday {
	get { return thursday;}
	set { if (this.thursday != value){
			this.thursday = value;
			Notify("Thursday");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Friday {
	get { return friday;}
	set { if (this.friday != value){
			this.friday = value;
			Notify("Friday");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Saturday {
	get { return saturday;}
	set { if (this.saturday != value){
			this.saturday = value;
			Notify("Saturday");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Sunday {
	get { return sunday;}
	set { if (this.sunday != value){
			this.sunday = value;
			Notify("Sunday");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal TotWeekReq {
	get { return totWeekReq;}
	set { if (this.totWeekReq != value){
			this.totWeekReq = value;
			Notify("TotWeekReq");
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
	get { return item; }
	set { if (this.item != value){
			this.item = value;
			Notify("Item");
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

public override
bool Equals(object obj){
	if (obj is DemandWeek)
		return	this.id.Equals(((DemandWeek)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void setQtyByDate(DateTime dateFilter,decimal dqty){
     
    if (dateFilter < DateUtil.minorHour(FromDate))
        pastDue = dqty;
    else if (DateUtil.sameDate(dateFilter,FromDate))
        monday= dqty;
    else if (DateUtil.sameDate(dateFilter,FromDate.AddDays(1)))
        tuesday= dqty;
    else if (DateUtil.sameDate(dateFilter,FromDate.AddDays(2)))
        wednesday= dqty;
    else if (DateUtil.sameDate(dateFilter,FromDate.AddDays(3)))
        thursday= dqty;
    else if (DateUtil.sameDate(dateFilter,FromDate.AddDays(4)))
        friday= dqty;
    else if (DateUtil.sameDate(dateFilter,FromDate.AddDays(5)))
        saturday= dqty;
    else if (DateUtil.sameDate(dateFilter,FromDate.AddDays(6)))
        sunday= dqty;
}

public
decimal getQtyByDate(DateTime dateFilter){
    decimal dqty =0;

    if (dateFilter < DateUtil.minorHour(FromDate))
        dqty = pastDue;
    else if (DateUtil.sameDate(dateFilter,FromDate))
        dqty = monday;
    else if (DateUtil.sameDate(dateFilter,FromDate.AddDays(1)))
        dqty = tuesday;
    else if (DateUtil.sameDate(dateFilter,FromDate.AddDays(2)))
        dqty = wednesday;
    else if (DateUtil.sameDate(dateFilter,FromDate.AddDays(3)))
        dqty = thursday;
    else if (DateUtil.sameDate(dateFilter,FromDate.AddDays(4)))
        dqty = friday;
    else if (DateUtil.sameDate(dateFilter,FromDate.AddDays(5)))
        dqty = saturday;
    else if (DateUtil.sameDate(dateFilter,FromDate.AddDays(6)))
        dqty = sunday;

    return dqty;
}

public
void setSummarizeQtyByDate(DateTime dateFilter,decimal dqty){
                 
    if (dateFilter < DateUtil.minorHour(FromDate))
        pastDue+= dqty;
    else if (DateUtil.sameDate(dateFilter,FromDate))
        monday+= dqty;
    else if (DateUtil.sameDate(dateFilter,FromDate.AddDays(1)))
        tuesday+= dqty;
    else if (DateUtil.sameDate(dateFilter,FromDate.AddDays(2)))
        wednesday+= dqty;
    else if (DateUtil.sameDate(dateFilter,FromDate.AddDays(3)))
        thursday+= dqty;
    else if (DateUtil.sameDate(dateFilter,FromDate.AddDays(4)))
        friday+= dqty;
    else if (DateUtil.sameDate(dateFilter,FromDate.AddDays(5)))
        saturday+= dqty;
    else if (DateUtil.sameDate(dateFilter,FromDate.AddDays(6)))
        sunday+= dqty;
}

public
void calcTotWeekReq(){
    TotWeekReq = monday + tuesday + wednesday + thursday + friday + saturday + sunday;
}

} // class
} // package