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
class DemandDay : BusinessObject {

private int id;
private string plant;
private string source;
private string tPartner;
private string shipLoc;
private string part;
private DateTime created;
private string oldRelNum;
private string newRelNum;
private DateTime oldRelDate;
private DateTime relDate;
private decimal oldCumRequired;
private decimal cumRequired;
private decimal orderNum;
private decimal item;
private decimal trlpKeyId;
private decimal logNum;

#if !WEB
internal
#else
public
#endif
DemandDay(){
	this.id = 0;
	this.plant = "";
	this.source = "";
	this.tPartner = "";
	this.shipLoc = "";
	this.part = "";
	this.created = DateTime.Now;
	this.oldRelNum = "";
	this.newRelNum = "";
	this.oldRelDate = DateUtil.MinValue;
	this.relDate = DateUtil.MinValue;
	this.oldCumRequired = 0;
	this.cumRequired = 0;
	this.orderNum = 0;
	this.item = 0;
	this.trlpKeyId = 0;
    this.logNum = 0;
}

internal
DemandDay(
	int id,
	string plant,
	string source,
	string tPartner,
	string shipLoc,
	string part,
	DateTime created,
	string oldRelNum,
	string newRelNum,
	DateTime oldRelDate,
	DateTime relDate,
	decimal oldCumRequired,
	decimal cumRequired,
	decimal orderNum,
	decimal item,
	decimal trlpKeyId,
    decimal logNum){
	this.id = id;
	this.plant = plant;
	this.source = source;
	this.tPartner = tPartner;
	this.shipLoc = shipLoc;
	this.part = part;
	this.created = created;
	this.oldRelNum = oldRelNum;
	this.newRelNum = newRelNum;
	this.oldRelDate = oldRelDate;
	this.relDate = relDate;
	this.oldCumRequired = oldCumRequired;
	this.cumRequired = cumRequired;
	this.orderNum = orderNum;
	this.item = item;
	this.trlpKeyId = trlpKeyId;
    this.logNum = logNum;
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
DateTime Created {
	get { return created;}
	set { if (this.created != value){
			this.created = value;
			Notify("Created");
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
DateTime OldRelDate {
	get { return oldRelDate;}
	set { if (this.oldRelDate != value){
			this.oldRelDate = value;
			Notify("OldRelDate");
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
decimal OldCumRequired {
	get { return oldCumRequired;}
	set { if (this.oldCumRequired != value){
			this.oldCumRequired = value;
			Notify("OldCumRequired");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal CumRequired {
	get { return cumRequired;}
	set { if (this.cumRequired != value){
			this.cumRequired = value;
			Notify("CumRequired");
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
decimal TrlpKeyId {
	get { return trlpKeyId;}
	set { if (this.trlpKeyId != value){
			this.trlpKeyId = value;
			Notify("TrlpKeyId");
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

public override
bool Equals(object obj){
	if (obj is DemandDay)
		return	this.id.Equals(((DemandDay)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package