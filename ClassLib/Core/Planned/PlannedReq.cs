/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.Planned{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class PlannedReq : BusinessObject {

private int hdrId;
private int detail;
private string type;
private int reqID;

private PlannedPartContainer plannedPartContainer;
private PlannedLabourContainer plannedLabourContainer;


#if !WEB
internal
#else
public
#endif
PlannedReq(){
	this.hdrId = 0;
	this.detail = 0;
	this.type = "";
	this.reqID = 0;
    this.plannedPartContainer = new PlannedPartContainer();
    this.plannedLabourContainer = new PlannedLabourContainer();
}

internal
PlannedReq(
	int hdrId,
	int detail,
	string type,
	int reqID)
{
	this.hdrId = hdrId;
	this.detail = detail;
	this.type = type;
	this.reqID = reqID;
    this.plannedPartContainer = new PlannedPartContainer();
    this.plannedLabourContainer = new PlannedLabourContainer();
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
string Type {
	get { return type;}
	set { if (this.type != value){
			this.type = value;
			Notify("Type");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int ReqID {
	get { return reqID;}
	set { if (this.reqID != value){
			this.reqID = value;
			Notify("ReqID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
PlannedPartContainer PlannedPartContainer {
	get { return plannedPartContainer;}
	set { if (this.plannedPartContainer != value){
			this.plannedPartContainer = value;
			Notify("PlannedPartContainer");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
PlannedLabourContainer PlannedLabourContainer {
	get { return plannedLabourContainer; }
	set { if (this.plannedLabourContainer != value){
			this.plannedLabourContainer = value;
			Notify("PlannedLabourContainer");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is PlannedReq)
		return	this.hdrId.Equals(((PlannedReq)obj).HdrId) &&
				this.detail.Equals(((PlannedReq)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(PlannedReq plannedReq){	
	this.HdrId=plannedReq.HdrId;
	this.Detail=plannedReq.Detail;
	this.Type=plannedReq.Type;
	this.ReqID=plannedReq.ReqID;	

    this.PlannedPartContainer.Clear();
    for (int i=0; i < plannedReq.PlannedPartContainer.Count;i++){
        PlannedPart plannedPart = new PlannedPart();
        plannedPart.copy(plannedReq.PlannedPartContainer[i]);    
    }      
}

public
void fillRedundances(){    
    for (int i=0;i < plannedPartContainer.Count;i++){
        PlannedPart plannedPart = plannedPartContainer[i];        
        plannedPart.HdrId = this.HdrId;
        plannedPart.Detail= this.Detail;              
        plannedPart.SubDetail= i+1;                  
    }

    for (int i=0;i < plannedLabourContainer.Count;i++){
        PlannedLabour plannedLabour = plannedLabourContainer[i];        
        plannedLabour.HdrId = this.HdrId;
        plannedLabour.Detail= this.Detail;              
        plannedLabour.SubDetail= i+1;                  
    }
}

} // class
} // package