/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.ObjectModel;

namespace Nujit.NujitERP.ClassLib.Core.Planned{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class PlannedLabourContainer : ObservableCollection<PlannedLabour> { 
#else
class PlannedLabourContainer : Collection<PlannedLabour> { 
#endif

internal
PlannedLabourContainer() : base(){
}

public
PlannedLabour getByKey(int hdrId, int detail, int subDetail){
	PlannedLabour plannedLabour = null;
	int i = 0;
	while ((i < this.Count) && (plannedLabour == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail) && subDetail.Equals(this[i].SubDetail))
			plannedLabour = this[i];
		i++;
	}
	return plannedLabour;
}

public
PlannedLabour getByLabourTypeDateRangeWeek(int ilabourTypeId,DateTime date){    
	PlannedLabour plannedLabour = null;
            
    for (int i=(this.Count-1); i >=0 && plannedLabour == null;i--){ //better to find from top to bottom
        if (ilabourTypeId.Equals(this[i].LabourTypeId) && (date >= this[i].StartDate && date <= this[i].EndDate))
            plannedLabour = this[i];		
	}
	return plannedLabour;
}

public
PlannedLabour getByLabourTypeShiftDateRangeWeek(int ilabourTypeId,int ishiftNum,DateTime date){    
	PlannedLabour plannedLabour = null;
            
    for (int i=(this.Count-1); i >=0 && plannedLabour == null;i--){ //better to find from top to bottom
        if (ilabourTypeId.Equals(this[i].LabourTypeId) && ishiftNum.Equals(this[i].ShiftNum) && 
            (date >= this[i].StartDate && date <= this[i].EndDate))
            plannedLabour = this[i];		
	}
	return plannedLabour;
}



} // class
} // package