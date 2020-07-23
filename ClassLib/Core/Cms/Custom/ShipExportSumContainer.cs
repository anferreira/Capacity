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
class ShipExportSumContainer : ObservableCollection<ShipExportSum> { 
#else
class ShipExportSumContainer : Collection<ShipExportSum> { 
#endif

internal
ShipExportSumContainer() : base(){
}

public
ShipExportSum getByKey(decimal orderNum, decimal item, string release){
	ShipExportSum shipExportSum = null;
	int i = 0;
	while ((i < this.Count) && (shipExportSum == null)){
		if (orderNum.Equals(this[i].OrderNum) && item.Equals(this[i].Item) && release.Equals(this[i].Release))
			shipExportSum = this[i];
		i++;
	}
	return shipExportSum;
}

} // class
} // package