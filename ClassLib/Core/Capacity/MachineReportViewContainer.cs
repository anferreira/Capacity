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
class MachineReportViewContainer : ObservableCollection<MachineReportView> { 

internal
MachineReportViewContainer() : base(){
}

public
MachineReportView getByKey(string reqType,int ireqId){
	MachineReportView machineReportView = null;
	int i = 0;
	while ((i < this.Count) && (machineReportView == null)){
		if (reqType.Equals(this[i].ReqType) && ireqId.Equals(this[i].ReqId))
            machineReportView = this[i];
		i++;
	}
	return machineReportView;
}

public
MachineReportPartView getByPartSeq(string spart,int iseq){
    MachineReportPartView   machineReportPartView = null;
    MachineReportPartView   machineReportPartViewCurr = null;
	int                     i = 0;

	while ((i < this.Count) && (machineReportPartView == null)){
        if (this[i] is MachineReportPartView){
            machineReportPartViewCurr =(MachineReportPartView)this[i];

            if (machineReportPartViewCurr.Part.ToUpper().Equals(spart.ToUpper()) && machineReportPartViewCurr.Seq== iseq)
                machineReportPartView= machineReportPartViewCurr;
        }		
		i++;
	}
	return machineReportPartView;
}

public
MachineReportPartView getByFirtPart(string spart){
    MachineReportPartView   machineReportPartView = null;
    MachineReportPartView   machineReportPartViewCurr = null;
	int                     i = 0;

	while ((i < this.Count) && (machineReportPartView == null)){
        if (this[i] is MachineReportPartView){
            machineReportPartViewCurr =(MachineReportPartView)this[i];

            if (machineReportPartViewCurr.Part.ToUpper().Equals(spart.ToUpper()))
                machineReportPartView= machineReportPartViewCurr;
        }		
		i++;
	}
	return machineReportPartView;
}

} // class
} // package