/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Util;
using System.Collections.ObjectModel;

namespace Nujit.NujitERP.ClassLib.Core.Cms{


#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class LastExportedContainer : ObservableCollection<LastExported> { 
#else
class LastExportedContainer : Collection<LastExported> { 
#endif

internal
LastExportedContainer() : base(){
}

public
LastExported getByKey(string code){
	LastExported lastExported = null;
	int i = 0;
	while ((i < this.Count) && (lastExported == null)){
		if (code.Equals(this[i].Code))
			lastExported = this[i];
		i++;
	}
	return lastExported;
}

} // class
} // package