/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.ObjectModel;
using System.Collections;

namespace Nujit.NujitERP.ClassLib.Core{


#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class HotListHdrContainer : ObservableCollection<HotListHdr> { 
#else
class HotListHdrContainer : Collection<HotListHdr> { 
#endif

internal
HotListHdrContainer() : base(){
}

public
HotListHdr getByKey(int id){
	HotListHdr hotListHdr = null;
	int i = 0;
	while ((i < this.Count) && (hotListHdr == null)){
		if (id.Equals(this[i].Id))
			hotListHdr = this[i];
		i++;
	}
	return hotListHdr;
}

} // class
} // package