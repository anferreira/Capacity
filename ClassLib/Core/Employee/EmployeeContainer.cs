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
class EmployeeContainer : ObservableCollection<Employee> { 
#else
class EmployeeContainer : Collection<Employee> { 
#endif

internal
EmployeeContainer() : base(){
}

public
Employee getByKey(string sid){
	Employee employee = null;
	int i = 0;
	while ((i < this.Count) && (employee == null)){
		if (sid.ToUpper().Equals(this[i].getId().ToUpper()))
			employee = this[i];
		i++;
	}
	return employee;
}

public
int getCountPerShift(int ishift,string sexcludeCodesStartWith=""){
	int icountPerShift = 0;

    foreach(Employee employee  in this){
        if (employee.AssignShift == ishift && 
            (string.IsNullOrEmpty(sexcludeCodesStartWith) || (employee.Id.Length < sexcludeCodesStartWith.Length || (employee.Id.Length >= sexcludeCodesStartWith.Length && !employee.Id.Substring(0,sexcludeCodesStartWith.Length).ToUpper().Equals(sexcludeCodesStartWith.ToUpper())))) )
            icountPerShift++;
    }
	return icountPerShift;
}

public
int getCountPerShift(int ishift,int idftLabourTypeId,string sexcludeCodesStartWith=""){
	int icountPerShift = 0;

    foreach(Employee employee  in this){
        if (employee.AssignShift == ishift && employee.DftLabourTypeId == idftLabourTypeId &&
           (string.IsNullOrEmpty(sexcludeCodesStartWith) || (employee.Id.Length < sexcludeCodesStartWith.Length || (employee.Id.Length >= sexcludeCodesStartWith.Length && !employee.Id.Substring(0, sexcludeCodesStartWith.Length).ToUpper().Equals(sexcludeCodesStartWith.ToUpper())))))
            icountPerShift++;
    }
	return icountPerShift;
}
        /*
public
int getCountPerShiftStartWith(int ishift,string startWith){
	int icountPerShift = 0;

    foreach(Employee employee  in this){
        if (employee.AssignShift == ishift && 
            (string.IsNullOrEmpty(startWith) || (employee.Id.Length >= startWith.Length && employee.Id.Substring(0,startWith.Length).ToUpper().Equals(startWith.ToUpper()))) )
            icountPerShift++;
    }
	return icountPerShift;
}
*/
public
int getCountPerShiftStartWith(int ishift,string startWith,int idftLabourTypeId=0){
	int icountPerShift = 0;

    foreach(Employee employee  in this){
        if (employee.AssignShift == ishift && 
            (string.IsNullOrEmpty(startWith) || (employee.Id.Length >= startWith.Length && employee.Id.Substring(0,startWith.Length).ToUpper().Equals(startWith.ToUpper()))) &&
            (employee.DftLabourTypeId == 0 || employee.DftLabourTypeId == idftLabourTypeId) )
            icountPerShift++;
    }
	return icountPerShift;
}


} // class
} // package