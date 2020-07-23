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
class DemandDayContainer : ObservableCollection<DemandDay> { 
#else
class DemandDayContainer : Collection<DemandDay> { 
#endif

internal
DemandDayContainer() : base(){
}

public
DemandDay getByKey(int id){
	DemandDay demandDay = null;
	int i = 0;
	while ((i < this.Count) && (demandDay == null)){
		if (id.Equals(this[i].Id))
			demandDay = this[i];
		i++;
	}
	return demandDay;
}

public
DemandDay getIfOldRelAdded(DemandDay demandDay){
	DemandDay demandDayFound = null;

    for (int i=0; i < this.Count; i++) { 

        if (getSameGenericKeys(this[i],demandDay)  &&                    
            this[i].OldRelNum.ToUpper().Equals(demandDay.NewRelNum.ToUpper()) &&
            DateUtil.sameDate(this[i].RelDate,demandDay.RelDate))
            demandDayFound= this[i];	
	}
	return demandDayFound;
}

private
bool getSameGenericKeys(DemandDay demandDay,DemandDay demandDay2){
    bool bresult=false;

    if (demandDay2.Plant.ToUpper().Equals(demandDay.Plant.ToUpper()) && 
        demandDay2.Source.ToUpper().Equals(demandDay.Source.ToUpper()) && 
        demandDay2.TPartner.ToUpper().Equals(demandDay.TPartner.ToUpper()) && 
        demandDay2.ShipLoc.ToUpper().Equals(demandDay.ShipLoc.ToUpper()) && 
        demandDay2.Part.ToUpper().Equals(demandDay.Part.ToUpper()))
        bresult=true;

    return bresult;
}

public
DemandDay getFirstCloseMinorDate(DemandDay demandDay){
	DemandDay demandDayFound = null;

    for (int i=0; i < this.Count && demandDayFound== null; i++) { 

        if (getSameGenericKeys(this[i], demandDay) &&
            this[i].OldRelNum.ToUpper().Equals(demandDay.OldRelNum.ToUpper()) &&
            DateUtil.minorHour(this[i].RelDate) > DateUtil.minorHour(demandDay.RelDate)){

            for (int j = i; j >=0 && demandDayFound == null;j--){

                if (getSameGenericKeys(this[j], demandDay) &&
                    this[j].OldRelNum.ToUpper().Equals(demandDay.OldRelNum.ToUpper()) &&
                    DateUtil.minorHour(this[j].RelDate) <= DateUtil.minorHour(demandDay.RelDate) && this[j].CumRequired != 0)
                    demandDayFound = this[j];
            }
        }
	}
	return demandDayFound;
}

public
DemandDay getMinorRelDate(){
	DemandDay   demandDayFound = null;
    DateTime    dateMinor      = DateTime.MaxValue; 

    for (int i=0; i < this.Count;i++){ 
        if (this[i].RelDate < dateMinor){
            demandDayFound  = this[i];
            dateMinor       = this[i].RelDate;
        }
	}
	return demandDayFound;
}

public
DemandDay getMaxRelDate(){
	DemandDay   demandDayFound  = null;
    DateTime    dateMax         = DateUtil.MinValue; 

    for (int i=0; i < this.Count;i++){ 
        if (this[i].RelDate > dateMax){
            demandDayFound= this[i];
            dateMax       = this[i].RelDate;
        }
	}
	return demandDayFound;
}

} // class
} // package