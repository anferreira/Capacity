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
class ShipExportContainer : ObservableCollection<ShipExport> { 
#else
class ShipExportContainer : Collection<ShipExport> { 
#endif

internal
ShipExportContainer() : base(){
}

public
ShipExport getByKey(string site, decimal bol, decimal bolItem){
	ShipExport shipExport = null;
	int i = 0;
	while ((i < this.Count) && (shipExport == null)){
		if (site.Equals(this[i].Site) && bol.Equals(this[i].Bol) && bolItem.Equals(this[i].BolItem))
			shipExport = this[i];
		i++;
	}
	return shipExport;
}

} // class
} // package