/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.Sales.PackSlips{


#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class PackSlip : BusinessObject {

private int id;
private int exernalId;
private string plant;
private string billTo;
private string shipTo;
private DateTime dateCreated;
private DateTime shipDate;
private DateTime datePosted;
private string status;

private PackSlipDtlContainer packSlipDtlContainer;

#if !WEB
internal
#else
public
#endif
PackSlip(){
	this.id = 0;
	this.exernalId = 0;
    this.plant = "";
    this.billTo = "";
	this.shipTo = "";
	this.dateCreated = DateTime.Now;
	this.shipDate = DateUtil.MinValue;
	this.datePosted = DateUtil.MinValue;
	this.status = "";
    this.packSlipDtlContainer = new PackSlipDtlContainer();
}

internal
PackSlip(
	int id,
	int exernalId,
    string plant,
	string billTo,
	string shipTo,
	DateTime dateCreated,
	DateTime shipDate,
	DateTime datePosted,
	string status)
{
	this.id = id;
	this.exernalId = exernalId;
    this.plant = plant;
	this.billTo = billTo;
	this.shipTo = shipTo;
	this.dateCreated = dateCreated;
	this.shipDate = shipDate;
	this.datePosted = datePosted;
	this.status = status;
    this.packSlipDtlContainer = new PackSlipDtlContainer();
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
int ExernalId {
	get { return exernalId;}
	set { if (this.exernalId != value){
			this.exernalId = value;
			Notify("ExernalId");
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
DateTime DateCreated {
	get { return dateCreated;}
	set { if (this.dateCreated != value){
			this.dateCreated = value;
			Notify("DateCreated");
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
DateTime DatePosted {
	get { return datePosted;}
	set { if (this.datePosted != value){
			this.datePosted = value;
			Notify("DatePosted");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Status {
	get { return status;}
	set { if (this.status != value){
			this.status = value;
			Notify("Status");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
PackSlipDtlContainer PackSlipDtlContainer {
	get { return packSlipDtlContainer; }
	set { if (this.packSlipDtlContainer != value){
			this.packSlipDtlContainer = value;
			Notify("PackSlipDtlContainer");
		}
	}
}

         
public
void fillRedundances(){
    for (int i=0;i < packSlipDtlContainer.Count;i++){
        PackSlipDtl packSlipDtl = packSlipDtlContainer[i];
        packSlipDtl.HdrId = this.id;
        packSlipDtl.Detail = i+1;        
    }    
}

public override
bool Equals(object obj){
	if (obj is PackSlip)
		return	this.id.Equals(((PackSlip)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package