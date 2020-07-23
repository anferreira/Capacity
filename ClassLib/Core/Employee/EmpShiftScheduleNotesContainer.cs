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
class EmpShiftScheduleNotesContainer : ObservableCollection<EmpShiftScheduleNotes> { 
#else
class EmpShiftScheduleNotesContainer : Collection<EmpShiftScheduleNotes> { 
#endif

internal
EmpShiftScheduleNotesContainer() : base(){
}

public
EmpShiftScheduleNotes getByKey(int hdrId, int detail){
	EmpShiftScheduleNotes empShiftScheduleNotes = null;
	int i = 0;
	while ((i < this.Count) && (empShiftScheduleNotes == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail))
			empShiftScheduleNotes = this[i];
		i++;
	}
	return empShiftScheduleNotes;
}

public
EmpShiftScheduleNotes getByTopic(string stopic){
	EmpShiftScheduleNotes empShiftScheduleNotes = null;
	int i = 0;
	while ((i < this.Count) && (empShiftScheduleNotes == null)){
		if (stopic.ToUpper().Equals(this[i].Topic.ToUpper()))
			empShiftScheduleNotes = this[i];
		i++;
	}
	return empShiftScheduleNotes;
}

} // class
} // package