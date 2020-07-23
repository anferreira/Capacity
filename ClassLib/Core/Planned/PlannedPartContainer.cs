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
class PlannedPartContainer : ObservableCollection<PlannedPart> { 
#else
class PlannedPartContainer : Collection<PlannedPart> { 
#endif

internal
PlannedPartContainer() : base(){
}

public
PlannedPart getByKey(int hdrId, int detail, int subDetail){
	PlannedPart plannedPart = null;
	int i = 0;
	while ((i < this.Count) && (plannedPart == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail) && subDetail.Equals(this[i].SubDetail))
			plannedPart = this[i];
		i++;
	}
	return plannedPart;
}

public
PlannedPart getByPartSeqDateRangeWeek(string spart,int seq,DateTime date){    
	PlannedPart plannedPart = null;
            
    for (int i=(this.Count-1); i >=0 && plannedPart == null;i--){ //better to find from top to bottom
        if (spart.ToUpper().Equals(this[i].Part.ToUpper()) && seq == this[i].Seq &&
            (date >= this[i].StartDate && date <= this[i].EndDate))
            plannedPart = this[i];		
	}
	return plannedPart;
}

public
decimal getByPartSeqDateRangeWeek(string spart,int seq,DateTime startDate,DateTime endDate){    	
    decimal         dplanned =0;
            
    for (int i=0; i < this.Count;i++){
        if (spart.ToUpper().Equals(this[i].Part.ToUpper()) && seq == this[i].Seq &&
            (this[i].StartDate >= startDate && this[i].EndDate <= endDate))
            dplanned+= this[i].QtyPlanned;		
	}
	return dplanned;
}

} // class
} // package