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
class ScheduleHdrContainer : ObservableCollection<ScheduleHdr> { 
#else
class ScheduleHdrContainer : Collection<ScheduleHdr> { 
#endif

internal
ScheduleHdrContainer() : base(){
}

public
ScheduleHdr getByKey(int id){
	ScheduleHdr scheduleHdr = null;
	int i = 0;
	while ((i < this.Count) && (scheduleHdr == null)){
		if (id.Equals(this[i].Id))
			scheduleHdr = this[i];
		i++;
	}
	return scheduleHdr;
}

public
SchedulePart getScheduleReqByCapacity(int imachId,int icapacityHdr){
	SchedulePart schedulePart = null;   
             
    for (int i=0; i < this.Count && schedulePart==null; i++)  
		schedulePart = this[i].SchedulePartContainer.getFirstByMachCapacity(imachId, icapacityHdr);        
    
	return schedulePart;
}


public
SchedulePart getSchedulePartByCapacity(string stype,int imachId,string spart,int seq,int icapacityHdr){
	SchedulePart schedulePart = null;
    
	int i = 0;
	while ((i < this.Count) && (schedulePart == null)){
        schedulePart =  this[i].SchedulePartContainer.getByMachPartSeqCapacity(imachId, spart,seq,icapacityHdr);        
        i++;
    }
	return schedulePart;
}
} // class
} // package