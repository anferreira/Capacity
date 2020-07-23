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
using System.Collections;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
    [System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class CapShiftProfileContainer : ObservableCollection<CapShiftProfile> { 
#else
class CapShiftProfileContainer : Collection<CapShiftProfile> { 
#endif

internal
CapShiftProfileContainer() : base(){
}

public
CapShiftProfile getByKey(int id){
	CapShiftProfile capShiftProfile = null;
	int i = 0;
	while ((i < this.Count) && (capShiftProfile == null)){
		if (id.Equals(this[i].Id))
			capShiftProfile = this[i];
		i++;
	}
	return capShiftProfile;
}


public
CapShiftProfile getByShiftExactlyDates(int ishiftNum,DateTime startDate,DateTime endDate){
	CapShiftProfile capShiftProfile = null;
    DateTime        startDateCurrent = startDate;
    DateTime        endDateCurrent = startDate;

    int i = 0;
	while ((i < this.Count) && (capShiftProfile == null)){
        startDateCurrent = this[i].StartDate;
        endDateCurrent = this[i].EndDate; 

		if (ishiftNum.Equals(this[i].ShiftNum) && 
            startDate.Year == startDateCurrent.Year && startDate.Month == startDateCurrent.Month && startDate.Day == startDateCurrent.Day &&
            endDate.Year   == endDateCurrent.Year   && endDate.Month   == endDateCurrent.Month   && endDate.Day   == endDateCurrent.Day)
			capShiftProfile = this[i];
		i++;
	}
	return capShiftProfile;
}

public
CapShiftProfile getByShiftNum(int shiftNum){
	CapShiftProfile capShiftProfile = null;
	int i = 0;
	while ((i < this.Count) && (capShiftProfile == null)){
		if (shiftNum.Equals(this[i].ShiftNum))
			capShiftProfile = this[i];
		i++;
	}
	return capShiftProfile;
}

public
int getMaxSiftNum(){
    int     ishiftNum =0;
	
    for (int i=0; i < this.Count; i++){
        if (this[i].ShiftNum > ishiftNum)
            ishiftNum = this[i].ShiftNum;
    }
	
	return ishiftNum;
}

public
int getTotalShiftPerWeek(){
    int             itotShifts =0;
    CapShiftProfile capShiftProfile = null;
    int             icountShifts= this.Count;

    itotShifts = icountShifts * 7;

    for (int i=0; i < this.Count;i++){
        capShiftProfile = this[i];          
        itotShifts-= capShiftProfile.getCountOfDaysWork(Constants.STRING_NO);        
    }
    return itotShifts;
}

public
decimal getTotalShiftPerWeekByMachinePlan(int imachineId){
    decimal         dtotShifts =0;
    CapShiftProfile capShiftProfile = null;
  
    for (int i=0; i < this.Count;i++){
        capShiftProfile = this[i];                  
        dtotShifts+=capShiftProfile.CapShiftProfileMachPlanContainer.getTotalShiftPerWeek(imachineId);
    }
    return dtotShifts;
}

public
int getRemainsShifts(DateTime dateTime,string svalue){
    CapShiftProfile capShiftProfile = null;
    int             itotShifts=0;

    for (int i=0; i < this.Count;i++){
        capShiftProfile = this[i];          
        itotShifts+= capShiftProfile.getRemainsShifts(dateTime,Constants.STRING_YES);        
    }
    return itotShifts;
}


public
void sortByShiftNum(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new CapShiftProfileShiftNumComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((CapShiftProfile)arrayToSort[i]);	
}

private
class CapShiftProfileShiftNumComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is CapShiftProfile) && (y is CapShiftProfile)){
            CapShiftProfile v1 = (CapShiftProfile)x;
            CapShiftProfile v2 = (CapShiftProfile)y;            
            return v1.ShiftNum.CompareTo(v2.ShiftNum);
        }else
            return -1;
    }
}

public
CapShiftProfileMachPlan getByMachPlanByFirstMachine(int imachineId){
	CapShiftProfile             capShiftProfile = null;
    CapShiftProfileMachPlan     capShiftProfileMachPlan = null;
    
    for (int i=0; i < this.Count && capShiftProfileMachPlan==null; i++){
        capShiftProfile = this[i];          
        capShiftProfileMachPlan = capShiftProfile.CapShiftProfileMachPlanContainer.getByFirstMachine(imachineId);
    }

	return capShiftProfileMachPlan;
}


public
decimal getTotalDaysPerWeek(int imachineId=0){
    decimal         dtotDays =0;    
    CapShiftProfile capShiftProfile = null;
        
    for (int i=0; i < this.Count;i++){
        capShiftProfile = this[i];          
        dtotDays+= capShiftProfile.getCountOfDaysWork(Constants.STRING_YES) / (decimal)Constants.MAX_SHIFTS;              

        if (imachineId > 0) //check if some overtime for machine
            dtotDays+= capShiftProfile.CapShiftProfileMachPlanContainer.getTotalShiftPerWeek(imachineId) / (decimal)Constants.MAX_SHIFTS;
    }
    return dtotDays;
}

} // class
} // package