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
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class CapShiftProfileMachPlanEmployeeContainer : ObservableCollection<CapShiftProfileMachPlanEmployee> { 
#else
class CapShiftProfileMachPlanEmployeeContainer : Collection<CapShiftProfileMachPlanEmployee> { 
#endif

internal
CapShiftProfileMachPlanEmployeeContainer() : base(){
}

public
CapShiftProfileMachPlanEmployee getByKey(int hdrId, int detail, int subDetail){
	CapShiftProfileMachPlanEmployee capShiftProfileMachPlanEmployee = null;
	int i = 0;
	while ((i < this.Count) && (capShiftProfileMachPlanEmployee == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail) && subDetail.Equals(this[i].SubDetail))
			capShiftProfileMachPlanEmployee = this[i];
		i++;
	}
	return capShiftProfileMachPlanEmployee;
}

public
CapShiftProfileMachPlanEmployee getByEmpId(string sempId){
	CapShiftProfileMachPlanEmployee capShiftProfileMachPlanEmployee = null;
	int i = 0;
	while ((i < this.Count) && (capShiftProfileMachPlanEmployee == null)){
		if (sempId.ToUpper().Equals(this[i].EmpId.ToUpper()))
			capShiftProfileMachPlanEmployee = this[i];
		i++;
	}
	return capShiftProfileMachPlanEmployee;
}

} // class
} // package