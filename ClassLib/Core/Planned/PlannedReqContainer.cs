/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.ObjectModel;

namespace Nujit.NujitERP.ClassLib.Core.Planned{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class PlannedReqContainer : ObservableCollection<PlannedReq> { 
#else
class PlannedReqContainer : Collection<PlannedReq> { 
#endif

internal
PlannedReqContainer() : base(){
}

public
PlannedReq getByKey(int hdrId, int detail){
	PlannedReq plannedReq = null;
	int i = 0;
	while ((i < this.Count) && (plannedReq == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail))
			plannedReq = this[i];
		i++;
	}
	return plannedReq;
}

public
PlannedReq getByRequirment(string stype,int ireqID){
	PlannedReq plannedReq = null;
	int i = 0;
	while ((i < this.Count) && (plannedReq == null)){
		if (stype.Equals(this[i].Type) && ireqID.Equals(this[i].ReqID))
			plannedReq = this[i];
		i++;
	}
	return plannedReq;
}

} // class
} // package