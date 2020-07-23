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
class EmployeeLabourContainer : ObservableCollection<EmployeeLabour> { 
#else
class EmployeeLabourContainer : Collection<EmployeeLabour> { 
#endif

internal
EmployeeLabourContainer() : base(){
}

public
EmployeeLabour getByKey(int id){
	EmployeeLabour employeeLabour = null;
	int i = 0;
	while ((i < this.Count) && (employeeLabour == null)){
		if (id.Equals(this[i].Id))
			employeeLabour = this[i];
		i++;
	}
	return employeeLabour;
}

public
EmployeeLabour getByLabourTypeId(int ilabourTypeId){
	EmployeeLabour employeeLabour = null;
	int i = 0;
	while ((i < this.Count) && (employeeLabour == null)){
		if (ilabourTypeId.Equals(this[i].LabourTypeId))
			employeeLabour = this[i];
		i++;
	}
	return employeeLabour;
}

} // class
} // package