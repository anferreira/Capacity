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
class CapacityHdrContainer : ObservableCollection<CapacityHdr> { 
#else
class CapacityHdrContainer : Collection<CapacityHdr> { 
#endif

internal
CapacityHdrContainer() : base(){
}

public
CapacityHdr getByKey(int id){
	CapacityHdr capacityHdr = null;
	int i = 0;
	while ((i < this.Count) && (capacityHdr == null)){
		if (id.Equals(this[i].Id))
			capacityHdr = this[i];
		i++;
	}
	return capacityHdr;
}

} // class
} // package