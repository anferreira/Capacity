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


namespace Nujit.NujitERP.ClassLib.Core.Cms{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class DemandWeekContainer : ObservableCollection<DemandWeek> { 
#else
class DemandWeekContainer : Collection<DemandWeek> { 
#endif

internal
DemandWeekContainer() : base(){
}

public
DemandWeek getByKey(int id){
	DemandWeek demandWeek = null;
	int i = 0;
	while ((i < this.Count) && (demandWeek == null)){
		if (id.Equals(this[i].Id))
			demandWeek = this[i];
		i++;
	}
	return demandWeek;
}

public
DemandWeek getByFilters(string splant,string stPartner,string shipLoc,string part,DateTime monday){
	DemandWeek demandWeekResult = null;

    for (int i=0; i < this.Count && demandWeekResult==null; i++){
        DemandWeek demandWeek = this[i];

        if (demandWeek.Plant.ToUpper().Equals(splant.ToUpper()) && 
            demandWeek.TPartner.ToUpper().Equals(stPartner.ToUpper()) && 
            demandWeek.ShipLoc.ToUpper().Equals(shipLoc.ToUpper()) && 
            demandWeek.Part.ToUpper().Equals(part.ToUpper()) &&
            DateUtil.sameDate(demandWeek.FromDate,monday))
            demandWeekResult = demandWeek;
    }
	
	return demandWeekResult;
}

} // class
} // package