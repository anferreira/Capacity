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
class CapacityViewHdr : CapacityViewBase {


private CapacityViewContainer capacityViewContainer;
private CapacityViewContainer capacityViewContainerMachShiftHours;
private CapacityViewContainer capacityViewContainerCumShifts;
private CapacityViewContainer capacityViewContainerCumMachShiftHours;       
private CapacityViewContainer capacityViewContainerAvailCapacity;
private CapacityViewContainer capacityViewContainerCumAvailCapacity;
private CapacityViewContainer capacityViewContainerScheduleTime;


#if !WEB
internal
#else
public
#endif
CapacityViewHdr() : base(){
    init();
}

private
void init(){
    this.capacityViewContainer = new CapacityViewContainer();
    this.capacityViewContainerMachShiftHours = new CapacityViewContainer();
    this.capacityViewContainerCumShifts = new CapacityViewContainer();
    this.capacityViewContainerCumMachShiftHours = new CapacityViewContainer();	
    this.capacityViewContainerAvailCapacity = new CapacityViewContainer();
    this.capacityViewContainerCumAvailCapacity = new CapacityViewContainer();
    this.capacityViewContainerScheduleTime = new CapacityViewContainer();
}



internal
CapacityViewHdr(
	string plant,
	string dept,
    int reqId,
	string reqType,
	string machine,
	string labour,
	string tool) : base (plant,	dept,reqId,reqType,machine,labour,tool){
	init();
}

[System.Runtime.Serialization.DataMember]
public
CapacityViewContainer CapacityViewContainer {
	get { return capacityViewContainer; }
	set { if (this.capacityViewContainer != value){
			this.capacityViewContainer = value;
			Notify("CapacityViewContainer");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CapacityViewContainer CapacityViewContainerMachShiftHours {
	get { return capacityViewContainerMachShiftHours; }
	set { if (this.capacityViewContainerMachShiftHours != value){
			this.capacityViewContainerMachShiftHours = value;
			Notify("CapacityViewContainerMachShiftHours");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
CapacityViewContainer CapacityViewContainerCumShifts {
	get { return capacityViewContainerCumShifts; }
	set { if (this.capacityViewContainerCumShifts != value){
			this.capacityViewContainerCumShifts = value;
			Notify("CapacityViewContainerCumShifts");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CapacityViewContainer CapacityViewContainerCumMachShiftHours {
	get { return capacityViewContainerCumMachShiftHours; }
	set { if (this.capacityViewContainerCumMachShiftHours != value){
			this.capacityViewContainerCumMachShiftHours = value;
			Notify("CapacityViewContainerCumMachShiftHours");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CapacityViewContainer CapacityViewContainerAvailCapacity {
	get { return capacityViewContainerAvailCapacity; }
	set { if (this.capacityViewContainerAvailCapacity != value){
			this.capacityViewContainerAvailCapacity = value;
			Notify("CapacityViewContainerAvailCapacity");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CapacityViewContainer CapacityViewContainerCumAvailCapacity {
	get { return capacityViewContainerCumAvailCapacity; }
	set { if (this.capacityViewContainerCumAvailCapacity != value){
			this.capacityViewContainerCumAvailCapacity = value;
			Notify("CapacityViewContainerCumAvailCapacity");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CapacityViewContainer CapacityViewContainerScheduleTime {
	get { return capacityViewContainerScheduleTime; }
	set { if (this.capacityViewContainerScheduleTime != value){
			this.capacityViewContainerScheduleTime = value;
			Notify("CapacityViewContainerScheduleTime");
		}
	}
}

public
void addToList(CapacityView capacityView){
    switch(capacityView.ShowType){
        case CapacityView.SHOW_TYPE.TYPE_NORMAL:
            capacityViewContainer.Add(capacityView);
            break;
        case CapacityView.SHOW_TYPE.TYPE_MACHSHIFTHOURS:
            capacityViewContainerMachShiftHours.Add(capacityView);
            break;
        case CapacityView.SHOW_TYPE.CUMULATIVE_SHIFTS:
            capacityViewContainerCumShifts.Add(capacityView);
            break;
        case CapacityView.SHOW_TYPE.CUMULATIVE_MACHSHIFTHOURS:
            capacityViewContainerCumMachShiftHours.Add(capacityView);
            break;        
        case CapacityView.SHOW_TYPE.PERCENTAGE:
            capacityViewContainerAvailCapacity.Add(capacityView);
            break;
        case CapacityView.SHOW_TYPE.CUMULATIVE_PERCENTAGE:            
            capacityViewContainerCumAvailCapacity.Add(capacityView);
            break;       
        case CapacityView.SHOW_TYPE.SCHEDULE_TIME:            
            capacityViewContainerScheduleTime.Add(capacityView);
            break;                                    
    }
}

public
CapacityViewContainer getList(CapacityView.SHOW_TYPE showType){    
    switch(showType){
        case CapacityView.SHOW_TYPE.TYPE_NORMAL:
            return capacityViewContainer;
        case CapacityView.SHOW_TYPE.TYPE_MACHSHIFTHOURS:                        
            return capacityViewContainerMachShiftHours;
        case CapacityView.SHOW_TYPE.CUMULATIVE_SHIFTS:            
            return capacityViewContainerCumShifts;
        case CapacityView.SHOW_TYPE.CUMULATIVE_MACHSHIFTHOURS:            
            return capacityViewContainerCumMachShiftHours;
        case CapacityView.SHOW_TYPE.PERCENTAGE:            
            return capacityViewContainerAvailCapacity; 
        case CapacityView.SHOW_TYPE.CUMULATIVE_PERCENTAGE:            
            return capacityViewContainerCumAvailCapacity;      
        case CapacityView.SHOW_TYPE.SCHEDULE_TIME:            
            return capacityViewContainerScheduleTime;                                            
    }
    return null;
}


} // class
} // package