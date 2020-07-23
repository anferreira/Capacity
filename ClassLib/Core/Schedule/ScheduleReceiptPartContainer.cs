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
class ScheduleReceiptPartContainer : ObservableCollection<ScheduleReceiptPart> { 
#else
class ScheduleReceiptPartContainer : Collection<ScheduleReceiptPart> { 
#endif

internal
ScheduleReceiptPartContainer() : base(){
}

public
ScheduleReceiptPart getByKey(int hdrId, int detail, int subDetail){
	ScheduleReceiptPart scheduleReceiptPart = null;
	int i = 0;
	while ((i < this.Count) && (scheduleReceiptPart == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail) && subDetail.Equals(this[i].SubDetail))
			scheduleReceiptPart = this[i];
		i++;
	}
	return scheduleReceiptPart;
}

public
decimal getTotalRecQty(){
    decimal drecQty=0;
    foreach(ScheduleReceiptPart scheduleReceiptPart in this)
        drecQty+= scheduleReceiptPart.RecQty;    
    return drecQty;
}

public
decimal getTotalRemainsQty(string spart,int iseq){
    decimal dremainsQty = 0;
    foreach(ScheduleReceiptPart scheduleReceiptPart in this) { 
        if (scheduleReceiptPart.Part.ToUpper().Equals(spart.ToUpper()) && iseq == scheduleReceiptPart.Seq)
            dremainsQty+= scheduleReceiptPart.RemainsQty;    
    }
    return dremainsQty;
}

public
string[][] getdifferentsMaterials(){ //trying to give same results as generateAutomaticMaterialConsumition
    string[][]  items = new string[0][];
    string      skey = "";
    Hashtable   hashtablePartSeq = new Hashtable();
    int         i=0;

    for (i=0; i < this.Count;i++){
        ScheduleReceiptPart scheduleReceiptPart = this[i];

        for (int j=0; j < scheduleReceiptPart.ScheduleMaterialConsumPartContainer.Count;j++){
            ScheduleMaterialConsumPart scheduleMaterialConsumPart = scheduleReceiptPart.ScheduleMaterialConsumPartContainer[i];

            skey = scheduleMaterialConsumPart.MatPart.ToUpper() + "-" + Convert.ToInt32(scheduleMaterialConsumPart.MatSeq).ToString();
            if (!hashtablePartSeq.Contains(skey))
                hashtablePartSeq.Add(skey, scheduleMaterialConsumPart);             
        } 
    }        

    items = new string[hashtablePartSeq.Count][];
    i=0;
    foreach (DictionaryEntry pair in hashtablePartSeq){                
        string[] line = new string[7];  //main values to store are Part/Seq/QtyReq, rest values no matter

        ScheduleMaterialConsumPart scheduleMaterialConsumPart = (ScheduleMaterialConsumPart)pair.Value;
        line[0] = scheduleMaterialConsumPart.MatPart;                               // prod
		line[1] = i.ToString();                                                     // level
		line[2] = "";                                                               // desc
		line[3] = decimal.Round(scheduleMaterialConsumPart.QtyReq, 2).ToString();   // qty req
		line[4] = "0";                                                              // inventory
		line[5] = Convert.ToUInt32(scheduleMaterialConsumPart.MatSeq).ToString();   // sequence
		line[6] = "Manufatured";                                                   // Purchased/Manufatured
        items[i] = line;
        i++;
    }

    return items;
}

public
ScheduleReceiptPart getFirstByPartSeqRecDate(string spart,int seq,DateTime recDate){
	ScheduleReceiptPart scheduleReceiptPart = null;
	int i = 0;
	while ((i < this.Count) && (scheduleReceiptPart == null)){
		if ( spart.ToUpper().Equals(this[i].Part.ToUpper()) && seq == this[i].Seq && DateUtil.sameDate(recDate,this[i].RecDate))
			scheduleReceiptPart = this[i];
		i++;
	}
	return scheduleReceiptPart;
}

public
ScheduleReceiptPart getSummarizedByPartSeqMinorThanRecDate(string spart,int seq,DateTime recDate){
	ScheduleReceiptPart scheduleReceiptPart = null;
	int                 i = 0;    
    
	while ((i < this.Count)){
		if ( spart.ToUpper().Equals(this[i].Part.ToUpper()) && seq == this[i].Seq && this[i].RecDate <= recDate){

            if (scheduleReceiptPart==null)
                scheduleReceiptPart= new ScheduleReceiptPart();

            scheduleReceiptPart.Part = spart;
            scheduleReceiptPart.Seq = seq;
            scheduleReceiptPart.RecQty+= this[i].RecQty;
            scheduleReceiptPart.RepQty+= this[i].RepQty;
        }
		i++;
	}
	return scheduleReceiptPart;
}


public
ScheduleReceiptPart getSummarizedByPartSeqByDate(string spart,int seq,DateTime forDate,int ishift){
	ScheduleReceiptPart scheduleReceiptPart = null;
    ScheduleReceiptPart scheduleReceiptPartAux = null;
	int                 i = 0;    
    decimal             dseconds =0;
    decimal             dtotSeconds =0;
    DateTime            dateAux = new DateTime(forDate.Year, forDate.Month, forDate.Day, 23, 59, 59); //last hour from date parameter
    decimal             drecQty=0;
    decimal             drepQty=0;
    
	while ((i < this.Count)){
		if (spart.ToUpper().Equals(this[i].Part.ToUpper()) && seq == this[i].Seq &&   
            DateUtil.sameDate(forDate, this[i].StartDate) && ishift == this[i].RecShift){

            scheduleReceiptPartAux = this[i];
            if (scheduleReceiptPart==null)
                scheduleReceiptPart= new ScheduleReceiptPart();

            drecQty= scheduleReceiptPartAux.RecQty;
            drepQty= scheduleReceiptPartAux.RepQty;
            
            if (ishift == 3 &&
                scheduleReceiptPartAux.RecDate > scheduleReceiptPartAux.StartDate && 
                !DateUtil.sameDate(scheduleReceiptPartAux.StartDate, scheduleReceiptPartAux.RecDate)){
                        
                //get qty received/reported, for shift 3 and on forDate                                      
                dseconds = Convert.ToInt64((dateAux - scheduleReceiptPartAux.StartDate).TotalSeconds);
                dtotSeconds = Convert.ToInt64((scheduleReceiptPartAux.RecDate - scheduleReceiptPartAux.StartDate).TotalSeconds);
                
                drecQty = (scheduleReceiptPartAux.RecQty * dseconds) / (dtotSeconds!=0? dtotSeconds : 1);
                drepQty = (scheduleReceiptPartAux.RepQty * dseconds) / (dtotSeconds!=0? dtotSeconds : 1);
               
                //adjust qtys and move date , because could be rest to be processed
                scheduleReceiptPartAux.RecQty-= drecQty;
                scheduleReceiptPartAux.RecQty-= drepQty;
                scheduleReceiptPartAux.StartDate = dateAux.AddSeconds(1);                
            }
                 
            scheduleReceiptPart.Part = spart;
            scheduleReceiptPart.Seq = seq;
            scheduleReceiptPart.RecQty+= drecQty;
            scheduleReceiptPart.RepQty+= drepQty;
            scheduleReceiptPart.StartDate = scheduleReceiptPart.RecDate = forDate;
        }
		i++;
	}
	return scheduleReceiptPart;
}

public
ScheduleReceiptPart getSummarizedByPartSeqByRangeDate(string spart,int seq,DateTime start,DateTime end){
	ScheduleReceiptPart scheduleReceiptPart = null;
    ScheduleReceiptPart scheduleReceiptPartAux = null;
	int                 i = 0;    
    
	while ((i < this.Count)){
		if (spart.ToUpper().Equals(this[i].Part.ToUpper()) && seq == this[i].Seq &&   
            this[i].RecDate >= start && this[i].RecDate <= end) { 

            scheduleReceiptPartAux = this[i];

            if (scheduleReceiptPart==null)
                scheduleReceiptPart= new ScheduleReceiptPart();
                          
            scheduleReceiptPart.Part = spart;
            scheduleReceiptPart.Seq = seq;
            scheduleReceiptPart.RecQty+= scheduleReceiptPartAux.RecQty;
            scheduleReceiptPart.RepQty+= scheduleReceiptPartAux.RepQty;
            scheduleReceiptPart.StartDate = scheduleReceiptPart.RecDate;
        }
		i++;
	}
	return scheduleReceiptPart;
}

} // class
} // package