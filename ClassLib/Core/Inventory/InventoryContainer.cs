using System;

using System.Collections;

namespace Nujit.NujitERP.ClassLib.Core{

public 
class InventoryContainer : ArrayList{

public 
InventoryContainer() : base(){
}

public 
Inventory getInventory(string product){
	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		Inventory inventory = (Inventory)en.Current;

		if (inventory.getProdID().Equals(product))
			return inventory;
	}
	return null;
}

} // class

} // namespace
