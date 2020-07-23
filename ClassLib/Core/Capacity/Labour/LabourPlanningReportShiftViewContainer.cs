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
class LabourPlanningReportShiftViewContainer : ObservableCollection<LabourPlanningReportShiftView> { 

internal
LabourPlanningReportShiftViewContainer() : base(){
}

public
LabourPlanningReportShiftView getByDate(DateTime date){
    LabourPlanningReportShiftView labourPlanningReportShiftView = null;
	int i = 0;
	while ((i < this.Count) && (labourPlanningReportShiftView == null)){
		if (DateUtil.sameDate(this[i].StartDate,date))
            labourPlanningReportShiftView = this[i];
		i++;
	}
	return labourPlanningReportShiftView;
}


public
void fillRedundances(){    	
    for (int i=0; i < this.Count; i++) 
        this[i].fillRedundances();    
}


public
void clean(){    	
    for (int i=0; i < this.Count; i++){
        LabourPlanningReportShiftView labourPlanningReportShiftView = this[i];
        labourPlanningReportShiftView.clean();        
    }
}


} // class
} // package