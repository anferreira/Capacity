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

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class CapacityPartDtlContainer : ObservableCollection<CapacityPartDtl> { 
#else
class CapacityPartDtlContainer : Collection<CapacityPartDtl> { 
#endif

internal
CapacityPartDtlContainer() : base(){
}

public
CapacityPartDtl getByKey(int hdrId, int detail, int subDetail){
	CapacityPartDtl capacityPartDtl = null;
	int i = 0;
	while ((i < this.Count) && (capacityPartDtl == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail) && subDetail.Equals(this[i].SubDetail))
			capacityPartDtl = this[i];
		i++;
	}
	return capacityPartDtl;
}

public
CapacityPartDtl getByPart(string spart){
	CapacityPartDtl capacityPartDtl = null;
	int i = 0;
	while ((i < this.Count) && (capacityPartDtl == null)){
		if (spart.ToUpper().Equals(this[i].Part.ToUpper()))
			capacityPartDtl = this[i];
		i++;
	}
	return capacityPartDtl;
}

} // class
} // package