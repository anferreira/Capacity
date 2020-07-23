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
class RP1268HContainer : ObservableCollection<RP1268H> { 
#else
class RP1268HContainer : Collection<RP1268H> { 
#endif

internal
RP1268HContainer() : base(){
}

public
RP1268H getByKey(int id){
	RP1268H rP1268H = null;
	int i = 0;
	while ((i < this.Count) && (rP1268H == null)){
		if (id.Equals(this[i].Id))
			rP1268H = this[i];
		i++;
	}
	return rP1268H;
}

} // class
} // package