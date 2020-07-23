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
class PlannedHdrContainer : ObservableCollection<PlannedHdr> { 
#else
class PlannedHdrContainer : Collection<PlannedHdr> { 
#endif

internal
PlannedHdrContainer() : base(){
}

public
PlannedHdr getByKey(int id){
	PlannedHdr plannedHdr = null;
	int i = 0;
	while ((i < this.Count) && (plannedHdr == null)){
		if (id.Equals(this[i].Id))
			plannedHdr = this[i];
		i++;
	}
	return plannedHdr;
}

} // class
} // package