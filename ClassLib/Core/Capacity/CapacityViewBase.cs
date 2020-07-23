/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////


using System;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class CapacityViewBase : BusinessObject {

protected string plant;
protected string dept;
protected int reqId;
protected string reqType;
protected string machine;
protected string labour;
protected string tool;

#if !WEB
internal
#else
public
#endif
CapacityViewBase(){    
	this.plant = "";
	this.dept = "";
    this.reqId = 0;
    this.reqType = "";
	this.machine = "";
	this.labour = "";
	this.tool = "";	
}

internal
CapacityViewBase(
	string plant,
	string dept,
    int reqId,
    string reqType,
	string machine,
	string labour,
	string tool){
	this.plant = plant;
	this.dept = dept;
    this.reqId = reqId;
    this.reqType = reqType;
	this.machine = machine;
	this.labour = labour;
	this.tool = tool;
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
string Dept {
	get { return dept;}
	set { if (this.dept != value){
			this.dept = value;
			Notify("Dept");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int ReqId {
	get { return reqId;}
	set { if (this.reqId != value){
			this.reqId = value;
			Notify("ReqId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ReqType {
	get { return reqType;}
	set { if (this.reqType != value){
			this.reqType = value;
			Notify("ReqType");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Machine {
	get { return machine;}
	set { if (this.machine != value){
			this.machine = value;
			Notify("Machine");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Labour {
	get { return labour;}
	set { if (this.labour != value){
			this.labour = value;
			Notify("Labour");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Tool {
	get { return tool;}
	set { if (this.tool != value){
			this.tool = value;
			Notify("Tool");
		}
	}
}

public
string ReqName {
	get {
        switch(reqType){
          case CapacityReq.REQUIREMENT_MACHINE:      
                return machine;
            case CapacityReq.REQUIREMENT_LABOUR:      
                return string.IsNullOrEmpty(labour)? "Labour" : labour;
            case CapacityReq.REQUIREMENT_TOOL:      
                return string.IsNullOrEmpty(tool)? "Tool" : tool;
        }
        return "";
    } set {
        switch (reqType){
            case CapacityReq.REQUIREMENT_MACHINE:
                this.machine = value;break;
            case CapacityReq.REQUIREMENT_LABOUR:
                this.labour = value;break;                
            case CapacityReq.REQUIREMENT_TOOL:
                this.tool = value;break;                
        }
        Notify("ReqName");		
	}
}

public
string PlantDept {
	get {
        string saux=this.plant;
        saux+= string.IsNullOrEmpty(saux) ? dept : "\\" + dept;        
        return saux;
    } set { 
			Notify("PlantDept");		
	}
}

public override
bool Equals(object obj){
	if (obj is CapacityViewBase)
		return	this.plant.Equals(((CapacityViewBase)obj).Plant) &&
				this.dept.Equals(((CapacityViewBase)obj).Dept) &&
				this.reqType.Equals(((CapacityViewBase)obj).ReqType) &&
				this.machine.Equals(((CapacityViewBase)obj).Machine) &&
				this.labour.Equals(((CapacityViewBase)obj).Labour) &&
				this.tool.Equals(((CapacityViewBase)obj).Tool);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(CapacityViewBase capacityViewBase){ 
    this.Plant = capacityViewBase.Plant;
    this.Dept = capacityViewBase.Dept;
    this.ReqId = capacityViewBase.ReqId;
    this.ReqType = capacityViewBase.ReqType;
    this.Machine = capacityViewBase.Machine;
    this.Labour = capacityViewBase.Labour;
    this.Tool = capacityViewBase.Tool;
} 

} // class
} // package