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
class CapacityPartContainer : ObservableCollection<CapacityPart> { 
#else
class CapacityPartContainer : Collection<CapacityPart> { 
#endif

internal
CapacityPartContainer() : base(){
}

public
CapacityPart getByKey(int hdrId, int detail){
	CapacityPart capacityPart = null;
	int i = 0;
	while ((i < this.Count) && (capacityPart == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail))
			capacityPart = this[i];
		i++;
	}
	return capacityPart;
}

public
CapacityPart getByPartDate(string spart,DateTime date){
	CapacityPart capacityPart = null;
	int i = 0;
	while ((i < this.Count) && (capacityPart == null)){
		if (spart.ToUpper().Equals(this[i].Part.ToUpper()) && 
        (this[i].StartDate.Year == date.Year && this[i].StartDate.Month == date.Month && this[i].StartDate.Day == date.Day))
			capacityPart = this[i];
		i++;
	}
	return capacityPart;
}

public
CapacityPart getByPartSeqDateRangeWeek(string spart,int seq,string splant,string sdept,DateTime date){    
	CapacityPart    capacityPart = null;
            
    for (int i=(this.Count-1); i >=0 && capacityPart == null;i--){ //better to find from top to bottom
        if (spart.ToUpper().Equals(this[i].Part.ToUpper()) && seq == this[i].Seq &&
            (date >= this[i].StartDate && date <= this[i].EndDate) &&
            splant.ToUpper().Equals(this[i].Plant.ToUpper()) && sdept.ToUpper().Equals(this[i].Dept.ToUpper()))        
			capacityPart = this[i];		
	}
	return capacityPart;
}

public
CapacityPartContainer getByFilters(string spart){  
    CapacityPartContainer capacityPartContainerReturn = new CapacityPartContainer();
		
	for (int i=0; i < this.Count; i++){
        CapacityPart capacityPart = this[i];

		if ( (string.IsNullOrEmpty(spart)  || (StringUtil.ifMatch(capacityPart.Part.ToUpper(), spart.ToUpper()))))             
            capacityPartContainerReturn.Add(capacityPart);        
	}	
    return capacityPartContainerReturn;
}

} // class
} // package