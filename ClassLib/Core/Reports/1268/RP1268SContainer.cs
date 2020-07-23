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
class RP1268SContainer : ObservableCollection<RP1268S> { 
#else
class RP1268SContainer : Collection<RP1268S> { 
#endif

internal
RP1268SContainer() : base(){
}

public
RP1268S getByKey(int hdrId, int detail, int subDtl){
	RP1268S rP1268S = null;
	int i = 0;
	while ((i < this.Count) && (rP1268S == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail) && subDtl.Equals(this[i].SubDtl))
			rP1268S = this[i];
		i++;
	}
	return rP1268S;
}

} // class
} // package