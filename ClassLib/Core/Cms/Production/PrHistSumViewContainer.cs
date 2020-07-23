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
class PrHistSumViewContainer : ObservableCollection<PrHistSumView> {
#else
class PrHistSumViewContainer : Collection<PrHistSumView> { 
#endif
internal
PrHistSumViewContainer() : base(){
}
        /*
public
decimal getSumQtyByDate(DateTime date){	
	PrHistSumView      PrHistSumView = null;
    decimal     dqty =0;

	for (int i=0; i < this.Count;i++){
        PrHistSumView = this[i];        
        if (DateUtil.sameDate(PrHistSumView.DWDATE,date))
			dqty+= PrHistSumView.DWQTYC;		
	}
	return dqty;
}
*/
} // class
} // package