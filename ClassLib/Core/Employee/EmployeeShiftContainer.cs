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

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class EmployeeShiftContainer : ObservableCollection<EmployeeShift> { 
#else
class EmployeeShiftContainer : Collection<EmployeeShift> { 
#endif

internal
EmployeeShiftContainer() : base(){
}

public
EmployeeShift getByKey(int id){
	EmployeeShift employeeShift = null;
	int i = 0;
	while ((i < this.Count) && (employeeShift == null)){
		if (id.Equals(this[i].Id))
			employeeShift = this[i];
		i++;
	}
	return employeeShift;
}

} // class
} // package