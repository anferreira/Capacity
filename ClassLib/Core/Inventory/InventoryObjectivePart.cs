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
class InventoryObjectivePart : BusinessObject {

private int hdrId;
private int detail;
private string part;
private int seq;
private string master;
private string obectivesAutomaticCalc;

private decimal qohShow=0;
private decimal daysOnHandShow=0;

private InventoryObjectivePartDtlContainer inventoryObjectivePartDtlContainer;

#if !WEB
internal
#else
public
#endif
InventoryObjectivePart(){
	this.hdrId = 0;
	this.detail = 0;
	this.part = "";
	this.seq = 0;
	this.master = Constants.STRING_YES;
    this.obectivesAutomaticCalc = Constants.STRING_YES;
    this.inventoryObjectivePartDtlContainer = new InventoryObjectivePartDtlContainer();
}

internal
InventoryObjectivePart(
	int hdrId,
	int detail,
	string part,
	int seq,
	string master,
    string obectivesAutomaticCalc){
	this.hdrId = hdrId;
	this.detail = detail;
	this.part = part;
	this.seq = seq;
	this.master = master;
    this.obectivesAutomaticCalc = obectivesAutomaticCalc;
    this.inventoryObjectivePartDtlContainer = new InventoryObjectivePartDtlContainer();
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
int Seq {
	get { return seq;}
	set { if (this.seq != value){
			this.seq = value;
			Notify("Seq");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Master {
	get { return master;}
	set { if (this.master != value){
			this.master = value;
			Notify("Master");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ObectivesAutomaticCalc {
	get { return obectivesAutomaticCalc; }
	set { if (this.obectivesAutomaticCalc != value){
			this.obectivesAutomaticCalc = value;
			Notify("ObectivesAutomaticCalc");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QohShow {
	get { return qohShow; }
	set { if (this.qohShow != value){
			this.qohShow = value;
			Notify("QohShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal DaysOnHandShow {
	get {       
        return daysOnHandShow;
    }set { if (this.daysOnHandShow != value){
			this.daysOnHandShow = value;		
            Notify("DaysOnHandShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
InventoryObjectivePartDtlContainer InventoryObjectivePartDtlContainer {
	get { return inventoryObjectivePartDtlContainer; }
	set { if (this.inventoryObjectivePartDtlContainer != value){
			this.inventoryObjectivePartDtlContainer = value;
			Notify("InventoryObjectivePartDtlContainer");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is InventoryObjectivePart)
		return	this.hdrId.Equals(((InventoryObjectivePart)obj).HdrId) &&
				this.detail.Equals(((InventoryObjectivePart)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void fillRedundances(){    
    for (int i=0;i < inventoryObjectivePartDtlContainer.Count;i++){
        InventoryObjectivePartDtl inventoryObjectivePartDtl = inventoryObjectivePartDtlContainer[i];
        
        inventoryObjectivePartDtl.HdrId =this.HdrId;
        inventoryObjectivePartDtl.Detail=this.Detail;      
        inventoryObjectivePartDtl.SubDtl=i+1;              

        inventoryObjectivePartDtl.PartShow = this.Part;
        inventoryObjectivePartDtl.SeqShow = this.Seq;
    }    
}

public
void copy(InventoryObjectivePart inventoryObjectivePart){   
	this.HdrId=inventoryObjectivePart.HdrId;
	this.Detail=inventoryObjectivePart.Detail;
	this.Part=inventoryObjectivePart.Part;
	this.Seq=inventoryObjectivePart.Seq;
	this.Master=inventoryObjectivePart.Master;
    this.ObectivesAutomaticCalc = inventoryObjectivePart.ObectivesAutomaticCalc;

    this.inventoryObjectivePartDtlContainer.Clear();
    foreach(InventoryObjectivePartDtl inventoryObjectivePartDtl in inventoryObjectivePart.InventoryObjectivePartDtlContainer){ 
        InventoryObjectivePartDtl inventoryObjectivePartDtlNew = new InventoryObjectivePartDtl();
        inventoryObjectivePartDtlNew.copy(inventoryObjectivePartDtl);
    }
}


} // class
} // package