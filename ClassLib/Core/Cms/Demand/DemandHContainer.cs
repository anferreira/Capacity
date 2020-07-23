/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.ObjectModel;

namespace Nujit.NujitERP.ClassLib.Core.Cms{

#if !POCKET_PC
    [System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class DemandHContainer : ObservableCollection<DemandH>{
#else
class DemandHContainer : Collection<DemandH> { 
#endif


internal
DemandHContainer() : base(){
}

public
DemandH getByKey(decimal id){
	DemandH demandH = null;
	int i = 0;
	while ((i < this.Count) && (demandH == null)){
		if (id.Equals(this[i].Id))
			demandH = this[i];
		i++;
	}
	return demandH;
}

} // class
} // package