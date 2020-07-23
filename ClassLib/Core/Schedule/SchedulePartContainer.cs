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
class SchedulePartContainer : ObservableCollection<SchedulePart> { 
#else
class SchedulePartContainer : Collection<SchedulePart> { 
#endif

internal
SchedulePartContainer() : base(){
}

public
SchedulePart getByKey(int hdrId, int detail){
	SchedulePart schedulePart = null;
	int i = 0;
	while ((i < this.Count) && (schedulePart == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail))
			schedulePart = this[i];
		i++;
	}
	return schedulePart;
}

public
SchedulePart getByDetail(int idetail){
	SchedulePart schedulePart = null;
	int i = 0;
	while ((i < this.Count) && (schedulePart == null)){
		if (idetail.Equals(this[i].Detail))
			schedulePart = this[i];
		i++;
	}
	return schedulePart;
}

public
SchedulePart getFirstByMachCapacity(int imachId,int icapacityHdr){
	SchedulePart schedulePart = null;

    for (int i=0; i < this.Count && schedulePart==null; i++){ 
        if (imachId.Equals(this[i].MachId) && icapacityHdr.Equals(this[i].CapacityHdrId))
            schedulePart = this[i]; 
	}
	return schedulePart;
}

public
SchedulePart getFirstByMach(int imachId){
	SchedulePart schedulePart = null;

    for (int i=0; i < this.Count && schedulePart==null; i++){ 
        if (imachId.Equals(this[i].MachId))
            schedulePart = this[i]; 
	}
	return schedulePart;
}

public
SchedulePart getByPartSeqDate(string spart,int seq,DateTime startDate){
	SchedulePart schedulePart = null;
	int i = 0;
	while ((i < this.Count) && (schedulePart == null)){
		if (spart.Equals(this[i].Part) && seq.Equals(this[i].Seq) && startDate.Equals(this[i].StartDate))
			schedulePart = this[i];
		i++;
	}
	return schedulePart;
}

public
SchedulePart getByMachinePartSeqDate(int imachId,string spart,int seq,DateTime startDate){
	SchedulePart schedulePart = null;
	int i = 0;
	while ((i < this.Count) && (schedulePart == null)){
		if (imachId.Equals(this[i].MachId) && spart.Equals(this[i].Part) && seq.Equals(this[i].Seq) && startDate.Equals(this[i].StartDate))
			schedulePart = this[i];
		i++;
	}
	return schedulePart;
}


public
SchedulePart getByMachinePartSeqSameDateBelongsToHotList(int imachId,string spart,int seq,DateTime startDate){
	SchedulePart schedulePart = null;
	int i = 0;
	while ((i < this.Count) && (schedulePart == null)){
		if (imachId.Equals(this[i].MachId) && spart.ToUpper().Equals(this[i].Part.ToUpper()) && seq.Equals(this[i].Seq) &&  
            DateUtil.sameDate(startDate,this[i].StartDate) && this[i].HotListId > 0)
			schedulePart = this[i];
		i++;
	}
	return schedulePart;
}

public
SchedulePart getByPartSeqQtyRangeDate(string spart,int seq,decimal dqty,DateTime startDate){
	SchedulePart    schedulePart = null;
    DateTime        date1=DateTime.Now,date2=DateTime.Now;
    DateUtil.getPriorMondayNextSundayFromDate(startDate, out date1,out date2);
              
	int i = 0;
	while ((i < this.Count) && (schedulePart == null)){
		if (spart.Equals(this[i].Part) && seq.Equals(this[i].Seq) && dqty == this[i].Qty &&
            (this[i].StartDate >= date1 && this[i].StartDate <= date2))  //range date                    
			schedulePart = this[i];
		i++;
	}
	return schedulePart;
}

public
SchedulePart getByMachinePartSeqQtyRangeDate(int imachId,string spart,int seq,decimal dqty,DateTime startDate){
	SchedulePart    schedulePart = null;
    DateTime        date1=DateTime.Now,date2=DateTime.Now;
    DateUtil.getPriorMondayNextSundayFromDate(startDate, out date1,out date2);
              
	int i = 0;
	while ((i < this.Count) && (schedulePart == null)){
		if (imachId.Equals(this[i].MachId) && spart.Equals(this[i].Part) && seq.Equals(this[i].Seq) && dqty == this[i].Qty &&
            (this[i].StartDate >= date1 && this[i].StartDate <= date2))  //range date                    
			schedulePart = this[i];
		i++;
	}
	return schedulePart;
}

public
SchedulePart getByPartSeqCapacity(string spart,int seq,int capacityHdrId){
	SchedulePart schedulePart = null;
	int i = 0;
	while ((i < this.Count) && (schedulePart == null)){
		if (spart.Equals(this[i].Part) && seq.Equals(this[i].Seq) && capacityHdrId.Equals(this[i].CapacityHdrId))
			schedulePart = this[i];
		i++;
	}
	return schedulePart;
}

public
SchedulePart getByMachPartSeqCapacity(int imachId,string spart,int seq,int capacityHdrId){
	SchedulePart schedulePart = null;
	int i = 0;
	while ((i < this.Count) && (schedulePart == null)){
		if (imachId.Equals(this[i].MachId) && spart.Equals(this[i].Part) && seq.Equals(this[i].Seq) && capacityHdrId.Equals(this[i].CapacityHdrId))
			schedulePart = this[i];
		i++;
	}
	return schedulePart;
}

public
int applyFilters(DateTime startDateFilter, DateTime stopDateFilter){
    int icounRemoved=0;                    
    for (int i=0; i < this.Count;i++){ 
        SchedulePart schedulePart = this[i]; 

        if (schedulePart.StartDate < startDateFilter || schedulePart.StartDate > stopDateFilter || schedulePart.EndDate > stopDateFilter){
            this.RemoveAt(i);
            icounRemoved++;
            i--;                        
        }
    }
    return icounRemoved;
}


public
decimal getHoursFromDateRange(DateTime startDate, DateTime endDate){
    decimal dhours=0;
    decimal dhoursAux=0;

    for (int i=0; i < this.Count;i++){ 
        SchedulePart schedulePart = this[i]; 

        DateUtil.inDates(startDate, endDate, schedulePart.StartDate, schedulePart.EndDate,out dhoursAux);
        dhours+= dhoursAux;

                /*
        if (startDate <= schedulePart.StartDate && schedulePart.EndDate <= endDate)  //inside hrs
           dhours+= schedulePart.HoursSubtract;
        else if (schedulePart.StartDate >= startDate && schedulePart.StartDate < endDate && schedulePart.EndDate > endDate) //part of hour
           dhours+= Convert.ToDecimal((schedulePart.StartDate- endDate).TotalHours);     

        else if (schedulePart.EndDate > startDate && schedulePart.EndDate <  endDate ) //part of hour
           dhours+= Convert.ToDecimal((schedulePart.EndDate-startDate).TotalHours);     */
    }
    return dhours;
}

public
decimal getHoursFromMachDateRange(int imachId,DateTime startDate, DateTime endDate){
    decimal dhours=0;
    decimal dhoursAux=0;

    for (int i=0; i < this.Count;i++){ 
        SchedulePart schedulePart = this[i]; 

        if (schedulePart.MachId == imachId) { 
            DateUtil.inDates(startDate, endDate, schedulePart.StartDate, schedulePart.EndDate,out dhoursAux);
            dhours+= dhoursAux;
        }                
    }
    return dhours;
}

public
void add(SchedulePartContainer schedulePartContainer){    
    for (int i=0; i < schedulePartContainer.Count;i++)         
        this.Add(schedulePartContainer[i]);
}

public
void sortByDate(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new ScheduleDateComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((SchedulePart)arrayToSort[i]);
	
}

#region ScheduleDateComparer
private
class ScheduleDateComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is SchedulePart) && (y is SchedulePart)){
            SchedulePart v1 = (SchedulePart)x;
            SchedulePart v2 = (SchedulePart)y;

            string saux1 = DateUtil.getCompleteDateRepresentation(v1.StartDate,DateUtil.YYYYMMDD);
            string saux2 = DateUtil.getCompleteDateRepresentation(v2.StartDate, DateUtil.YYYYMMDD);
            return saux1.CompareTo(saux2);
        }else
            return -1;
    }
}
#endregion ScheduleDateComparer

public
void copyByMachine(ScheduleReqViewContainer scheduleReqViewContainer,int imachId=0){	
    ScheduleReqView scheduleReqView = null;

    for (int i=0;i < this.Count;i++){
        SchedulePart    schedulePart = this[i];
        
        if (schedulePart.MachId == imachId){
            scheduleReqView = new ScheduleReqView();
            scheduleReqView.copy(schedulePart);
            scheduleReqViewContainer.Add(scheduleReqView);
        }    
    }    
}

public
void copyDates(ScheduleReqViewContainer scheduleReqViewContainer,int imachId=0){	
    for (int i=0; i < this.Count; i++) { 
        SchedulePart    schedulePart = this[i];

        if (imachId == 0 || imachId == schedulePart.MachId) { 
            ScheduleReqView scheduleReqView = scheduleReqViewContainer.getByKey(schedulePart.HdrId, schedulePart.Detail, ScheduleReqView.SCHEDULE_TYPE_PART);
            if (scheduleReqView!= null){
                schedulePart.StartDate  = scheduleReqView.StartDate;
                schedulePart.EndDate    = scheduleReqView.EndDate;
            }            
        }
	}	
}

} // class
} // package