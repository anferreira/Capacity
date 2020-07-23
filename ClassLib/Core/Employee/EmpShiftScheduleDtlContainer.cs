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

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class EmpShiftScheduleDtlContainer : ObservableCollection<EmpShiftScheduleDtl> { 
#else
class EmpShiftScheduleDtlContainer : Collection<EmpShiftScheduleDtl> { 
#endif

internal
EmpShiftScheduleDtlContainer() : base(){
}

public
EmpShiftScheduleDtl getByKey(int hdrId, int detail){
	EmpShiftScheduleDtl empShiftScheduleDtl = null;
	int i = 0;
	while ((i < this.Count) && (empShiftScheduleDtl == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail))
			empShiftScheduleDtl = this[i];
		i++;
	}
	return empShiftScheduleDtl;
}

public
EmpShiftScheduleDtlContainer getByFilters(string sempId,int imachineId,int ilabourTypeId){
	EmpShiftScheduleDtlContainer empShiftScheduleDtlContainer = new EmpShiftScheduleDtlContainer();
	
	for (int i=0; i < this.Count;i++){
        if (    (string.IsNullOrEmpty(sempId)|| (sempId.ToUpper().Equals(this[i].EmpId.ToUpper()) && 
                (imachineId <= 0             || imachineId == this[i].MachId) &&
                (ilabourTypeId <= 0          || ilabourTypeId == this[i].LabourTypeId))))
            empShiftScheduleDtlContainer.Add(this[i]);		
	}
	return empShiftScheduleDtlContainer;
}

public
Hashtable getHashMachines(){	
    Hashtable	hashMachines = new Hashtable();

	for (int i=0; i < this.Count;i++){
        if (!hashMachines.Contains(this[i].MachId))
           hashMachines.Add(this[i].MachId,this[i]); 		
	}
	return hashMachines;
}

public
Hashtable getHashEmployees(){	
    Hashtable   hashEmployees = new Hashtable();
    string      sempId= "";

	for (int i=0; i < this.Count;i++){
        sempId= this[i].EmpId.ToUpper();
        if (!hashEmployees.Contains(sempId))
            hashEmployees.Add(sempId,this[i]); 		
	}
	return hashEmployees;
}

public
Hashtable getHashEmployeesAbsent(){	
    Hashtable   hashEmployees = new Hashtable();
    string      sempId= "";

	for (int i=0; i < this.Count;i++){
        sempId= this[i].EmpId.ToUpper();
        if (this[i].Absent.Equals(Constants.STRING_YES) && !hashEmployees.Contains(sempId))
            hashEmployees.Add(sempId,this[i]); 		
	}
	return hashEmployees;
}

} // class
} // package