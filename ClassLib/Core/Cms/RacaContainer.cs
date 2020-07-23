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
class RacaContainer : ObservableCollection<Raca> { 
#else
class RacaContainer : Collection<Raca> { 
#endif

internal
RacaContainer() : base(){
}

public
Raca getByKey(decimal qFENT){
	Raca raca = null;
	int i = 0;
	while ((i < this.Count) && (raca == null)){
		if (qFENT.Equals(this[i].QFENT))
			raca = this[i];
		i++;
	}
	return raca;
}

} // class
} // package