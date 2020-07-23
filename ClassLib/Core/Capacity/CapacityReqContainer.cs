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
class CapacityReqContainer : ObservableCollection<CapacityReq> { 
#else
class CapacityReqContainer : Collection<CapacityReq> { 
#endif

internal
CapacityReqContainer() : base(){
}

public
CapacityReq getByKey(int hdrId, int detail, int subDetail){
	CapacityReq capacityReq = null;
	int i = 0;
	while ((i < this.Count) && (capacityReq == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail) && subDetail.Equals(this[i].SubDetail))
			capacityReq = this[i];
		i++;
	}
	return capacityReq;
}

public
CapacityReq getByReqId(string stype,int ireqId){
	CapacityReq capacityReq = null;
	int i = 0;
	while ((i < this.Count) && (capacityReq == null)){
		if (stype.ToUpper().Equals(this[i].Type.ToUpper()) && ireqId.Equals(this[i].ReqID))
			capacityReq = this[i];
		i++;
	}
	return capacityReq;
}

} // class
} // package