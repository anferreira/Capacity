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
class CapShiftProfileMachPlan : BusinessObject {


private int hdrId;
private int detail;
private DateTime date;
private int machId;
private string fullShift;
private string shiftType;

private int shiftNumShow;
private string machShow;
private string machNameShow;

private CapShiftProfileMachPlanEmployeeContainer capShiftProfileMachPlanEmployeeContainer;

#if !WEB
internal
#else
public
#endif
CapShiftProfileMachPlan(){
	this.hdrId = 0;
	this.detail = 0;
	this.date = DateUtil.MinValue;
	this.machId = 0;
	this.fullShift = Constants.STRING_YES;
    this.shiftType = Constants.SHIFT_TYPE_OVERTIME;
    this.shiftNumShow = 0;
    this.machShow = "";
    this.machNameShow = "";
    this.capShiftProfileMachPlanEmployeeContainer = new CapShiftProfileMachPlanEmployeeContainer();
}

internal
CapShiftProfileMachPlan(
	int hdrId,
	int detail,
	DateTime date,
	int machId,
	string fullShift,
    string shiftType,
    int shiftNumShow,
    string machShow,
    string machNameShow){
	this.hdrId = hdrId;
	this.detail = detail;
	this.date = date;
	this.machId = machId;
	this.fullShift = fullShift;
    this.shiftType = shiftType;
    this.shiftNumShow = shiftNumShow;
    this.machShow = machShow;
    this.machNameShow = machNameShow;
    this.capShiftProfileMachPlanEmployeeContainer = new CapShiftProfileMachPlanEmployeeContainer();
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
DateTime Date {
	get { return date;}
	set { if (this.date != value){
			this.date = value;
			Notify("Date");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string SDate {
	get {
        return DateUtil.getDateRepresentation(date,DateUtil.MMDDYYYY);
    }set {
        DateTime dateAux =  DateUtil.parseDate(value,DateUtil.MMDDYYYY);
        if (!DateUtil.sameDate(dateAux,date)){
			this.date = dateAux;
			Notify("SDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int MachId {
	get { return machId;}
	set { if (this.machId != value){
			this.machId = value;
			Notify("MachId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FullShift {
	get { return fullShift;}
	set { if (this.fullShift != value){
			this.fullShift = value;
			Notify("FullShift");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ShiftType {
	get { return shiftType; }
	set { if (this.shiftType != value){
			this.shiftType = value;
			Notify("ShiftType");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MachNameShow {
	get { return machNameShow; }
	set { if (this.machNameShow != value){
			this.machNameShow = value;
			Notify("MachNameShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MachShow {
	get { return machShow; }
	set { if (this.machShow != value){
			this.machShow = value;
			Notify("MachShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int ShiftNumShow {
	get { return shiftNumShow; }
	set { if (this.shiftNumShow != value){
			this.shiftNumShow = value;
			Notify("ShiftNumShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CapShiftProfileMachPlanEmployeeContainer CapShiftProfileMachPlanEmployeeContainer {
	get { return capShiftProfileMachPlanEmployeeContainer; }
	set { if (this.capShiftProfileMachPlanEmployeeContainer != value){
			this.capShiftProfileMachPlanEmployeeContainer = value;
			Notify("CapShiftProfileMachPlanEmployeeContainer");
		}
	}
}


public override
bool Equals(object obj){
	if (obj is CapShiftProfileMachPlan)
		return	this.hdrId.Equals(((CapShiftProfileMachPlan)obj).HdrId) &&
				this.detail.Equals(((CapShiftProfileMachPlan)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(CapShiftProfileMachPlan capShiftProfileMachPlan){	
	this.HdrId=capShiftProfileMachPlan.HdrId;
	this.Detail=capShiftProfileMachPlan.Detail;
	this.Date=capShiftProfileMachPlan.Date;
	this.MachId=capShiftProfileMachPlan.MachId;
	this.FullShift=capShiftProfileMachPlan.FullShift;
    this.ShiftType=capShiftProfileMachPlan.ShiftType;

    this.ShiftNumShow=capShiftProfileMachPlan.ShiftNumShow;
	this.MachShow=capShiftProfileMachPlan.MachShow;
    this.MachNameShow=capShiftProfileMachPlan.MachNameShow;
}

public
void fillRedundances(){         
    for (int i=0; i < capShiftProfileMachPlanEmployeeContainer.Count;i++){
        CapShiftProfileMachPlanEmployee capShiftProfileMachPlanEmployee = capShiftProfileMachPlanEmployeeContainer[i];        
        capShiftProfileMachPlanEmployee.HdrId = this.HdrId;     
        capShiftProfileMachPlanEmployee.Detail= this.Detail;     
        capShiftProfileMachPlanEmployee.SubDetail= (i+1);             
    }
}

} // class
} // package