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
class StxhContainer : ObservableCollection<Stxh> { 
#else
class StxhContainer : Collection<Stxh> { 
#endif

internal
StxhContainer() : base(){
}

public
Stxh getByKey(decimal oYLOG, decimal oYENT){
	Stxh stxh = null;
	int i = 0;
	while ((i < this.Count) && (stxh == null)){
		if (oYLOG.Equals(this[i].OYLOG) && oYENT.Equals(this[i].OYENT))
			stxh = this[i];
		i++;
	}
	return stxh;
}

} // class
} // package