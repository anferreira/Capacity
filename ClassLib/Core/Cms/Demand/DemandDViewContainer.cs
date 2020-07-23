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
class DemandDViewContainer : ObservableCollection<DemandDView>{
#else
class DemandDViewContainer : Collection<DemandDView> { 
#endif


internal
DemandDViewContainer() : base(){
}


public
DemandDViewContainer getByFilters(string source,string stimeCode,string sbillTo,string shipTo,string spart){  
    DemandDViewContainer demandDViewContainerReturn = new DemandDViewContainer();
		
	for (int i=0; i < this.Count; i++){
        DemandDView demandDView = this[i];

		if ( (string.IsNullOrEmpty(source)   || (StringUtil.ifMatch(demandDView.Source.ToUpper(),source.ToUpper()))) &&
             (string.IsNullOrEmpty(stimeCode)|| (StringUtil.ifMatch(demandDView.TimeCode.ToUpper(), stimeCode.ToUpper()))) &&
             (string.IsNullOrEmpty(spart)    || (StringUtil.ifMatch(demandDView.Part.ToUpper(), spart.ToUpper()))) &&
             (string.IsNullOrEmpty(sbillTo)  || (StringUtil.ifMatch(demandDView.BillTo.ToUpper(),sbillTo.ToUpper()))) &&
             (string.IsNullOrEmpty(shipTo)   || (StringUtil.ifMatch(demandDView.ShipTo.ToUpper(),shipTo.ToUpper())))
             )
            demandDViewContainerReturn.Add(demandDView);        
	}	
    return demandDViewContainerReturn;
}

} // class
} // package