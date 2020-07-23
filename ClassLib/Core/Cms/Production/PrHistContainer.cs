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
class PrHistContainer : ObservableCollection<PrHist> { 
#else
class PrHistContainer : Collection<PrHist> { 
#endif

internal
PrHistContainer() : base(){
}

public
decimal getSumQtyByDate(DateTime date){	
	PrHist      prHist = null;
    decimal     dqty =0;

	for (int i=0; i < this.Count;i++){
        prHist = this[i];        
        if (DateUtil.sameDate(prHist.DWDATE,date))
			dqty+= prHist.DWQTYC;		
	}
	return dqty;
}

} // class
} // package