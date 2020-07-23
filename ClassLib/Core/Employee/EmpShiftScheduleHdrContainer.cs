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
class EmpShiftScheduleHdrContainer : ObservableCollection<EmpShiftScheduleHdr> { 
#else
class EmpShiftScheduleHdrContainer : Collection<EmpShiftScheduleHdr> { 
#endif

internal
EmpShiftScheduleHdrContainer() : base(){
}

public
EmpShiftScheduleHdr getByKey(int id){
	EmpShiftScheduleHdr empShiftScheduleHdr = null;
	int i = 0;
	while ((i < this.Count) && (empShiftScheduleHdr == null)){
		if (id.Equals(this[i].Id))
			empShiftScheduleHdr = this[i];
		i++;
	}
	return empShiftScheduleHdr;
}

} // class
} // package