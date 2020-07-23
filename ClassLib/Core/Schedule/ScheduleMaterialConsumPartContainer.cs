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


namespace Nujit.NujitERP.ClassLib.Core.ScheduleDemand{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class ScheduleMaterialConsumPartContainer : ObservableCollection<ScheduleMaterialConsumPart> { 
#else
class ScheduleMaterialConsumPartContainer : Collection<ScheduleMaterialConsumPart> { 
#endif

internal
ScheduleMaterialConsumPartContainer() : base(){
}

public
ScheduleMaterialConsumPart getByKey(int hdrId, int detail, int subDetail, int subSubDetail){
	ScheduleMaterialConsumPart scheduleMaterialConsumPart = null;
	int i = 0;
	while ((i < this.Count) && (scheduleMaterialConsumPart == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail) && subDetail.Equals(this[i].SubDetail) && subSubDetail.Equals(this[i].SubSubDetail))
			scheduleMaterialConsumPart = this[i];
		i++;
	}
	return scheduleMaterialConsumPart;
}

public
decimal getTotalRemainsQty(string smatPart, int imatSeq){
    decimal dtotRemains=0;
    foreach(ScheduleMaterialConsumPart scheduleMaterialConsumPart in this) { 
        if (scheduleMaterialConsumPart.MatPart.ToUpper().Equals(smatPart.ToUpper()) && imatSeq == scheduleMaterialConsumPart.MatSeq)
            dtotRemains+= scheduleMaterialConsumPart.RemainsQty; 
    }
    return dtotRemains;
}

public
ScheduleMaterialConsumPart getFirstByPartSeqRecDate(string smatPart,int seq,DateTime starDate){
	ScheduleMaterialConsumPart scheduleMaterialConsumPart = null;
	int i = 0;
	while ((i < this.Count) && (scheduleMaterialConsumPart == null)){
		if (smatPart.ToUpper().Equals(this[i].MatPart.ToUpper()) && seq == this[i].MatSeq && DateUtil.sameDate(starDate, this[i].StartDate))
			scheduleMaterialConsumPart = this[i];
		i++;
	}
	return scheduleMaterialConsumPart;
}

public
ScheduleMaterialConsumPart getSummarizedByPartSeqMinorThanRecDate(string smatPart, int seq,DateTime starDate){
	ScheduleMaterialConsumPart  scheduleMaterialConsumPart = null;
	int                         i = 0;    
    
	while ((i < this.Count)){
		if (smatPart.ToUpper().Equals(this[i].MatPart.ToUpper()) && seq == this[i].MatSeq && this[i].StartDate <= starDate){
            if (scheduleMaterialConsumPart == null)
                scheduleMaterialConsumPart= new ScheduleMaterialConsumPart();

            scheduleMaterialConsumPart.MatPart = smatPart;
            scheduleMaterialConsumPart.MatSeq = seq;
            scheduleMaterialConsumPart.QtyConsum+= this[i].QtyConsum;
            scheduleMaterialConsumPart.QtyReported+= this[i].QtyReported;
        }
		i++;
	}
	return scheduleMaterialConsumPart;
}

} // class
} // package