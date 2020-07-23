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
class ReportWeeksViewContainer : ObservableCollection<ReportWeeksView> { 

internal
ReportWeeksViewContainer() : base(){
}

public
ReportWeeksView getByKey(string reqType,int ireqId){
	ReportWeeksView machineReportView = null;
	int i = 0;
	while ((i < this.Count) && (machineReportView == null)){
		if (reqType.Equals(this[i].ReqType) && ireqId.Equals(this[i].ReqId))
            machineReportView = this[i];
		i++;
	}
	return machineReportView;
}
        /*
public
ReportWeeksView getByPartSeq(string spart,int iseq){
    ReportWeeksView machineReportPartView = null;
    ReportWeeksView machineReportPartViewCurr = null;
	int             i = 0;

	while ((i < this.Count) && (machineReportPartView == null)){
        if (this[i] is ReportWeeksView){
            machineReportPartViewCurr =(ReportWeeksView)this[i];

            if (machineReportPartViewCurr.Part.ToUpper().Equals(spart.ToUpper()) && machineReportPartViewCurr.Seq== iseq)
                machineReportPartView= machineReportPartViewCurr;
        }		
		i++;
	}
	return machineReportPartView;
}*/

} // class
} // package