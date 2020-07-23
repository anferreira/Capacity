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
class PlannedPriorityContainer : ObservableCollection<PlannedPriority> { 
#else
class PlannedPriorityContainer : Collection<PlannedPriority> { 
#endif

internal
PlannedPriorityContainer() : base(){
}

public
PlannedPriority getByKey(int hdrId, int detail){
	PlannedPriority plannedPriority = null;
	int i = 0;
	while ((i < this.Count) && (plannedPriority == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail))
			plannedPriority = this[i];
		i++;
	}
	return plannedPriority;
}

} // class
} // package