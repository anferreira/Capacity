/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.ObjectModel;
using System.Collections;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class HotListDayContainer : ObservableCollection<HotListDay> { 
#else
class HotListDayContainer : Collection<HotListDay> { 
#endif

internal
HotListDayContainer() : base(){
}
       
public
HotListDay getByDate(DateTime dateTime){
	HotListDay hotListDay = null;
	
	for (int i=0; hotListDay== null && i < this.Count;i++){
		if (DateUtil.sameDate(dateTime,this[i].DateTime))
			hotListDay = this[i];		
	}
	return hotListDay;
}

public
HotListDay getBiggerThanDate(DateTime dateTime){
	HotListDay  hotListDay  = null;
    DateTime    dateTimeAux = DateTime.Now;
	
	for (int i=0; hotListDay== null && i < this.Count;i++){
        dateTimeAux = new DateTime(this[i].DateTime.Year, this[i].DateTime.Month, this[i].DateTime.Day,0,0,0);
		if (dateTimeAux > dateTime)
			hotListDay = this[i];		
	}
	return hotListDay;
}

} // class
} // package