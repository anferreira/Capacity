/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.ObjectModel;

namespace Nujit.NujitERP.ClassLib.Core.Reports{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class RP1268DContainer : ObservableCollection<RP1268D> { 
#else
class RP1268DContainer : Collection<RP1268D> { 
#endif

internal
RP1268DContainer() : base(){
}

public
RP1268D getByKey(int hdrId, int detail){
	RP1268D rP1268D = null;
	int i = 0;
	while ((i < this.Count) && (rP1268D == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail))
			rP1268D = this[i];
		i++;
	}
	return rP1268D;
}

} // class
} // package