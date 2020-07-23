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

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class InventoryObjectiveHdrContainer : ObservableCollection<InventoryObjectiveHdr> { 
#else
class InventoryObjectiveHdrContainer : Collection<InventoryObjectiveHdr> { 
#endif

internal
InventoryObjectiveHdrContainer() : base(){
}

public
InventoryObjectiveHdr getByKey(int id){
	InventoryObjectiveHdr inventoryObjectiveHdr = null;
	int i = 0;
	while ((i < this.Count) && (inventoryObjectiveHdr == null)){
		if (id.Equals(this[i].Id))
			inventoryObjectiveHdr = this[i];
		i++;
	}
	return inventoryObjectiveHdr;
}

} // class
} // package