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

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class CapShiftTaskContainer : ObservableCollection<CapShiftTask> { 
#else
class CapShiftTaskContainer : Collection<CapShiftTask> { 
#endif

internal
CapShiftTaskContainer() : base(){
}

public
CapShiftTask getByKey(int id){
	CapShiftTask capShiftTask = null;
	int i = 0;
	while ((i < this.Count) && (capShiftTask == null)){
		if (id.Equals(this[i].Id))
			capShiftTask = this[i];
		i++;
	}
	return capShiftTask;
}

} // class
} // package