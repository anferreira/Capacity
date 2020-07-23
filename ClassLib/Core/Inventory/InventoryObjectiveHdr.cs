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
class InventoryObjectiveHdr : BusinessObject {

private int id;
private DateTime dateCreated;
private string status;
private string plant;
private DateTime dateTimeStamp;

private InventoryObjectivePartContainer inventoryObjectivePartContainer;

#if !WEB
internal
#else
public
#endif
InventoryObjectiveHdr(){
	this.id = 0;
	this.dateCreated = DateTime.Now;
	this.status = Constants.STATUS_ACTIVE;
	this.plant = Configuration.DftPlant;
    this.dateTimeStamp = DateUtil.MinValue;
    this.inventoryObjectivePartContainer = new InventoryObjectivePartContainer();
}

internal
InventoryObjectiveHdr(
	int id,
	DateTime dateCreated,
	string status,
	string plant,
    DateTime dateTimeStamp){
	this.id = id;
	this.dateCreated = dateCreated;
	this.status = status;
	this.plant = plant;
    this.dateTimeStamp = dateTimeStamp;
    this.inventoryObjectivePartContainer = new InventoryObjectivePartContainer();
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
InventoryObjectivePartContainer InventoryObjectivePartContainer {
	get { return inventoryObjectivePartContainer; }
	set { if (this.inventoryObjectivePartContainer != value){
			this.inventoryObjectivePartContainer = value;
			Notify("InventoryObjectivePartContainer");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime DateTimeStamp {
	get { return dateTimeStamp; }
	set { if (this.dateTimeStamp != value){
			this.dateTimeStamp = value;
			Notify("DateTimeStamp");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is InventoryObjectiveHdr)
		return	this.id.Equals(((InventoryObjectiveHdr)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void fillRedundances(){    
    for (int i=0;i < inventoryObjectivePartContainer.Count;i++){
        InventoryObjectivePart inventoryObjectivePart = inventoryObjectivePartContainer[i];
        
        inventoryObjectivePart.HdrId = this.Id;
        inventoryObjectivePart.Detail = i+1;      
        inventoryObjectivePart.fillRedundances();
    }    
}

public
InventoryObjectivePartContainer searchByPart(string spartLike){
    InventoryObjectivePartContainer inventoryObjectivePartContainer = new InventoryObjectivePartContainer();

    for (int i=0; i < this.InventoryObjectivePartContainer.Count;i++){        
        InventoryObjectivePart inventoryObjectivePart = this.InventoryObjectivePartContainer[i];
                
        if (!string.IsNullOrEmpty(spartLike)){ //if part as filte, check if match
            if (!StringUtil.ifMatch(inventoryObjectivePart.Part.ToUpper(), spartLike.ToUpper()))                
                continue;
        }
        inventoryObjectivePartContainer.Add(inventoryObjectivePart);
    }
    return inventoryObjectivePartContainer;
}
                   

} // class
} // package