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

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class CapProfileHolidayContainer : ObservableCollection<CapProfileHoliday> { 
#else
class CapProfileHolidayContainer : Collection<CapProfileHoliday> { 
#endif

internal
CapProfileHolidayContainer() : base(){
}

public
CapProfileHoliday getByKey(int id){
	CapProfileHoliday capProfileHoliday = null;
	int i = 0;
	while ((i < this.Count) && (capProfileHoliday == null)){
		if (id.Equals(this[i].Id))
			capProfileHoliday = this[i];
		i++;
	}
	return capProfileHoliday;
}

public
CapProfileHoliday getByRangeDate(DateTime startDate){
	CapProfileHoliday capProfileHoliday = null;
	int i = 0;

	while ((i < this.Count) && (capProfileHoliday == null)){
		if (startDate >= this[i].StartDate && this[i].EndDate < startDate)
			capProfileHoliday = this[i];
		i++;
	}
	return capProfileHoliday;
}

} // class
} // package