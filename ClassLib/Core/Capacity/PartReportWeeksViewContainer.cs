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
class PartReportWeeksViewContainer : ObservableCollection<PartReportWeeksView> { 

internal
PartReportWeeksViewContainer() : base(){
}

public
PartReportWeeksView getByKey(string reqType,int ireqId){
	PartReportWeeksView partReportWeeksView = null;
	int i = 0;
	while ((i < this.Count) && (partReportWeeksView == null)){
		if (reqType.Equals(this[i].ReqType) && ireqId.Equals(this[i].ReqId))
            partReportWeeksView = this[i];
		i++;
	}
	return partReportWeeksView;
}

public
PartReportWeeksView getByPartSeq(string spart,int iseq){
	PartReportWeeksView partReportWeeksView = null;
	int i = 0;
	while ((i < this.Count) && (partReportWeeksView == null)){
		if (spart.ToUpper().Equals(this[i].Part.ToUpper()) && iseq.Equals(this[i].Seq))
            partReportWeeksView = this[i];
		i++;
	}
	return partReportWeeksView;
}

} // class
} // package