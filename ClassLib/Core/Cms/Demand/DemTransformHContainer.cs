/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.ObjectModel;

namespace Nujit.NujitERP.ClassLib.Core.Cms{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class DemTransformHContainer : ObservableCollection<DemTransformH> { 
#else
class DemTransformHContainer : Collection<DemTransformH> { 
#endif

internal
DemTransformHContainer() : base(){
}

public
DemTransformH getByKey(int id){
	DemTransformH demTransformH = null;
	int i = 0;
	while ((i < this.Count) && (demTransformH == null)){
		if (id.Equals(this[i].Id))
			demTransformH = this[i];
		i++;
	}
	return demTransformH;
}

} // class
} // package