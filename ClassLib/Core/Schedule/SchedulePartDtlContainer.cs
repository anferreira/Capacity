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


namespace Nujit.NujitERP.ClassLib.Core.ScheduleDemand{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class SchedulePartDtlContainer : ObservableCollection<SchedulePartDtl> { 
#else
class SchedulePartDtlContainer : Collection<SchedulePartDtl> { 
#endif

internal
SchedulePartDtlContainer() : base(){
}

public
SchedulePartDtl getByKey(int hdrId, int detail, int subDetail){
	SchedulePartDtl schedulePartDtl = null;
	int i = 0;
	while ((i < this.Count) && (schedulePartDtl == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail) && subDetail.Equals(this[i].SubDetail))
			schedulePartDtl = this[i];
		i++;
	}
	return schedulePartDtl;
}

public
SchedulePartDtl getByPartSeq(string spart,int iseq){
	SchedulePartDtl schedulePartDtl = null;
	int i = 0;
	while ((i < this.Count) && (schedulePartDtl == null)){
		if (spart.ToUpper().Equals(this[i].Part.ToUpper()) && iseq == this[i].Seq)
			schedulePartDtl = this[i];
		i++;
	}
	return schedulePartDtl;
}

} // class
} // package