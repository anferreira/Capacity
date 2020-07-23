/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
    [System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class CapacityHdr : BusinessObject {

private int id;
private DateTime dateCreated;
private string status;
private string plant;
private DateTime dateTimeStamp;

private CapacityPartContainer capacityPartContainer;
private CapacityMachPriorityContainer capacityMachPriorityContainer;

#if !WEB
internal
#else
public
#endif
CapacityHdr(){
	this.id = 0;
	this.dateCreated = DateTime.Now;
	this.status = Nujit.NujitERP.ClassLib.Common.Constants.STATUS_ACTIVE;
    this.plant = "";
    this.capacityPartContainer = new CapacityPartContainer();
    this.capacityMachPriorityContainer = new CapacityMachPriorityContainer();
    this.dateTimeStamp = DateUtil.MinValue;
}

internal
CapacityHdr(
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
    this.capacityPartContainer = new CapacityPartContainer();
    this.capacityMachPriorityContainer = new CapacityMachPriorityContainer();
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
	if (obj is CapacityHdr)
		return	this.id.Equals(((CapacityHdr)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

[System.Runtime.Serialization.DataMember]
public
CapacityPartContainer CapacityPartContainer {
    get { return capacityPartContainer; }
	set { if (this.capacityPartContainer != value){
			this.capacityPartContainer = value;
            Notify("CapacityPartContainer");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CapacityMachPriorityContainer CapacityMachPriorityContainer {
    get { return capacityMachPriorityContainer; }
	set { if (this.capacityMachPriorityContainer != value){
			this.capacityMachPriorityContainer = value;
            Notify("CapacityMachPriorityContainer");
		}
	}
}

public
void fillRedundances(){    
    for (int i=0;i < capacityPartContainer.Count;i++){
        CapacityPart capacityPart = capacityPartContainer[i];
        
        capacityPart.HdrId = this.Id;
        capacityPart.Detail = i+1;      
        capacityPart.fillRedundances();
    }

    capacityMachPriorityContainer.sortByPriority();
    for (int i=0;i < capacityMachPriorityContainer.Count;i++){
        CapacityMachPriority capacityMachPriority = capacityMachPriorityContainer[i];
        
        capacityMachPriority.HdrId = this.Id;
        capacityMachPriority.Detail = i+1;              
    }
}

public
void copy(CapacityHdr capacityHdr){
	CapacityHdr capacityHdrClone = new CapacityHdr();

	this.Id=capacityHdr.Id;
	this.DateCreated=capacityHdr.DateCreated;
	this.Status=capacityHdr.Status;
    this.Plant = capacityHdr.Plant;
    this.DateTimeStamp = capacityHdr.DateTimeStamp;
}


} // class
} // package