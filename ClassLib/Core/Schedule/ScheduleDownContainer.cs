/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.ObjectModel;
using Nujit.NujitERP.ClassLib.Util;


namespace Nujit.NujitERP.ClassLib.Core.ScheduleDemand{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class ScheduleDownContainer : ObservableCollection<ScheduleDown> { 
#else
class ScheduleDownContainer : Collection<ScheduleDown> { 
#endif

internal
ScheduleDownContainer() : base(){
}

public
ScheduleDown getByKey(int hdrId, int detail){
	ScheduleDown scheduleDown = null;
	int i = 0;
	while ((i < this.Count) && (scheduleDown == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail))
			scheduleDown = this[i];
		i++;
	}
	return scheduleDown;
}

public
ScheduleDown getByDetail(int idetail){
	ScheduleDown scheduleDown = null;
	int i = 0;
	while ((i < this.Count) && (scheduleDown == null)){
		if (idetail.Equals(this[i].Detail))
			scheduleDown = this[i];
		i++;
	}
	return scheduleDown;
}
     
public
decimal getHoursFromMachDateRange(int imachId,DateTime startDate, DateTime endDate){
    decimal dhours=0;
    decimal dhoursAux=0;

    for (int i=0; i < this.Count;i++){ 
        ScheduleDown scheduleDown = this[i]; 

        if (scheduleDown.MachId == imachId) { 
            DateUtil.inDates(startDate, endDate, scheduleDown.StartDate, scheduleDown.EndDate,out dhoursAux);
            dhours+= dhoursAux;
        }                
    }
    return dhours;
}
        
public
void sortByDate(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new ScheduleDateComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((ScheduleDown)arrayToSort[i]);
	
}

#region ScheduleDateComparer
private
class ScheduleDateComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is ScheduleDown) && (y is ScheduleDown)){
            ScheduleDown v1 = (ScheduleDown)x;
            ScheduleDown v2 = (ScheduleDown)y;

            string saux1 = DateUtil.getCompleteDateRepresentation(v1.StartDate,DateUtil.YYYYMMDD);
            string saux2 = DateUtil.getCompleteDateRepresentation(v2.StartDate,DateUtil.YYYYMMDD);
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
         ScheduleDown    scheduleDown  = this[i];
        
        if (scheduleDown.MachId == imachId){
            scheduleReqView = new ScheduleReqView();
            scheduleReqView.copy(scheduleDown);
            scheduleReqViewContainer.Add(scheduleReqView);
        }    
    }    
}

public
void copyDates(ScheduleReqViewContainer scheduleReqViewContainer,int imachId=0){	
    for (int i=0; i < this.Count; i++) { 
        ScheduleDown    scheduleDown  = this[i];

        if (imachId == 0 || imachId == scheduleDown.MachId) { 
            ScheduleReqView scheduleReqView = scheduleReqViewContainer.getByKey(scheduleDown.HdrId, scheduleDown.Detail, ScheduleReqView.SCHEDULE_TYPE_DOWN);
            if (scheduleReqView!= null){
                scheduleDown.StartDate  = scheduleReqView.StartDate;
                scheduleDown.EndDate    = scheduleReqView.EndDate;
            }            
        }
	}	
}

} // class
} // package