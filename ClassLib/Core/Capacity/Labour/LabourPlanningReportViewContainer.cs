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
class LabourPlanningReportViewContainer : ObservableCollection<LabourPlanningReportView> { 

internal
LabourPlanningReportViewContainer() : base(){
}

public
LabourPlanningReportView getByKey(string reqType,int ireqId){
    LabourPlanningReportView labourPlanningReportView = null;
	int i = 0;
	while ((i < this.Count) && (labourPlanningReportView == null)){
		if (reqType.Equals(this[i].ReqType) && ireqId.Equals(this[i].ReqId))
            labourPlanningReportView = this[i];
		i++;
	}
	return labourPlanningReportView;
}


} // class
} // package