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
class CapShiftProfileView : CapShiftProfile {

int totDirectPeopleView;
int totIndirectPeopleView;
decimal totAvailableDirectHoursView;

#if !WEB
internal
#else
public
#endif
CapShiftProfileView():base(){	
    totDirectPeopleView = 0;
    totIndirectPeopleView=0;
    totAvailableDirectHoursView=0;
}

internal
CapShiftProfileView(CapShiftProfile capShiftProfile) : base (   capShiftProfile.Id,
                                                                capShiftProfile.ShiftNum, 
                                                                capShiftProfile.Status, 
                                                                capShiftProfile.StartDate, 
                                                                capShiftProfile.EndDate,
                                                                capShiftProfile.Plant,
                                                                capShiftProfile.ShiftStart,capShiftProfile.ShiftEnd){
    totDirectPeopleView = 0;
    totIndirectPeopleView=0;
    totAvailableDirectHoursView=0;    
}

public
int TotDirectPeopleView {
    get { return totDirectPeopleView; }
	set { if (this.totDirectPeopleView != value){
			this.totDirectPeopleView = value;
			Notify("TotDirectPeopleView");
		}
	}
}

public
int TotIndirectPeopleView {
    get { return totIndirectPeopleView; }
	set { if (this.totIndirectPeopleView != value){
			this.totIndirectPeopleView = value;
			Notify("TotIndirectPeopleView");
		}
	}
}

public
decimal TotAvailableDirectHoursView {
	 get { return totAvailableDirectHoursView; }
	set { if (this.totAvailableDirectHoursView != value){
			this.totAvailableDirectHoursView = value;
			Notify("TotAvailableDirectHoursView");
		}
	}
}

} // class
} // package