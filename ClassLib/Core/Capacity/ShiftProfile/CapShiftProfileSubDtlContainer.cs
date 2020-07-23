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

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class CapShiftProfileSubDtlContainer : ObservableCollection<CapShiftProfileSubDtl> { 
#else
class CapShiftProfileSubDtlContainer : Collection<CapShiftProfileSubDtl> { 
#endif

internal
CapShiftProfileSubDtlContainer() : base(){
}

public
CapShiftProfileSubDtl getByKey(int hdrId, int detail, int subDetail){
	CapShiftProfileSubDtl capShiftProfileSubDtl = null;
	int i = 0;
	while ((i < this.Count) && (capShiftProfileSubDtl == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail) && subDetail.Equals(this[i].SubDetail))
			capShiftProfileSubDtl = this[i];
		i++;
	}
	return capShiftProfileSubDtl;
}

} // class
} // package