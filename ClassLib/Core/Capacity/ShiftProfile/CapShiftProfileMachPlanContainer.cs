/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.ObjectModel;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class CapShiftProfileMachPlanContainer : ObservableCollection<CapShiftProfileMachPlan> { 
#else
class CapShiftProfileMachPlanContainer : Collection<CapShiftProfileMachPlan> { 
#endif

internal
CapShiftProfileMachPlanContainer() : base(){
}

public
CapShiftProfileMachPlan getByKey(int hdrId, int detail){
	CapShiftProfileMachPlan capShiftProfileMachPlan = null;
	int i = 0;
	while ((i < this.Count) && (capShiftProfileMachPlan == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail))
			capShiftProfileMachPlan = this[i];
		i++;
	}
	return capShiftProfileMachPlan;
}

public
CapShiftProfileMachPlan getByMachineDate(int imachineId,DateTime date){
	CapShiftProfileMachPlan capShiftProfileMachPlan = null;
	
	for (int i=0; i < this.Count && capShiftProfileMachPlan == null;i++){
		if (imachineId == this[i].MachId && DateUtil.sameDate(this[i].Date,date))
			capShiftProfileMachPlan = this[i];		
	}
	return capShiftProfileMachPlan;
}

public
int  getMaxDetail(){
	CapShiftProfileMachPlan capShiftProfileMachPlan = null;
    int                     imaxDetail=0;
	
	for (int i=0; i < this.Count && capShiftProfileMachPlan == null;i++){
		if (this[i].Detail > imaxDetail)
            imaxDetail= this[i].Detail;
    }
	return imaxDetail;
}

public
CapShiftProfileMachPlan getByFirstMachine(int imachineId){
	CapShiftProfileMachPlan capShiftProfileMachPlan = null;
	
	for (int i=0; i < this.Count && capShiftProfileMachPlan == null;i++){
		if (imachineId == this[i].MachId)
			capShiftProfileMachPlan = this[i];		
	}
	return capShiftProfileMachPlan;
}

public
decimal getTotalShiftPerWeek(int imachineId){
    decimal                 dtotShifts=0;
		
	for (int i=0; i < this.Count;i++){
		if (imachineId == this[i].MachId)
			dtotShifts+= this[i].FullShift.Equals(Constants.STRING_YES) ? 1 : (decimal)0.5;

    }
	return dtotShifts;
}
 

} // class
} // package