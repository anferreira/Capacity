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
class HotListViewBase : BusinessObject {

private int hotListIdAut;
private int hotListId;
private int machineId;
private string plant;
private string dept;
private string mach;

#if !WEB
internal
#else
public
#endif
HotListViewBase(){
    hotListIdAut = 0;
    hotListId = 0;
	machineId=0;
    plant="";
    dept="";
    mach="";
}

internal
HotListViewBase(int hotListIdAut,
                int hotListId,
                int machineId,
                string plant,
                string dept,
                string mach){
    this.hotListIdAut = hotListIdAut;
    this.hotListId = hotListId;
    this.machineId = machineId;
	this.plant = plant;
	this.dept = dept;	
	this.mach = mach;	
}


[System.Runtime.Serialization.DataMember]
public
int HotListIdAut {
	get { return hotListIdAut; }
	set { if (this.hotListIdAut != value){
			this.hotListIdAut = value;
			Notify("HotListIdAut");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int HotListId {
	get { return hotListId; }
	set { if (this.hotListId != value){
			this.hotListId = value;
			Notify("HotListId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int MachineId {
	get { return machineId; }
	set { if (this.machineId != value){
			this.machineId = value;
			Notify("MachineId");
		}
	}
}
       
[System.Runtime.Serialization.DataMember]
public
string Plant {
	get { return plant; }
	set { if (this.plant != value){
			this.plant = value;
			Notify("Plant");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Dept {
	get { return dept; }
	set { if (this.dept != value){
			this.dept = value;
			Notify("Dept");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Mach {
	get { return mach; }
	set { if (this.mach != value){
			this.mach = value;
			Notify("Mach");
		}
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
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(HotListViewBase hotListViewBase){ 
    this.HotListId = hotListViewBase.HotListId;
    this.MachineId = hotListViewBase.MachineId;
	this.Plant = hotListViewBase.Plant;
	this.Dept = hotListViewBase.Dept;	
	this.Mach = hotListViewBase.Mach;	
} 



} // class
} // package