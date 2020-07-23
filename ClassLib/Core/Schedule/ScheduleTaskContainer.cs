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
class ScheduleTaskContainer : ObservableCollection<ScheduleTask> { 
#else
class ScheduleTaskContainer : Collection<ScheduleTask> { 
#endif

internal
ScheduleTaskContainer() : base(){
}

public
ScheduleTask getByKey(int hdrId, int detail){
	ScheduleTask scheduleTask = null;
	int i = 0;
	while ((i < this.Count) && (scheduleTask == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail))
			scheduleTask = this[i];
		i++;
	}
	return scheduleTask;
}

public
ScheduleTask getByDetail(int idetail){
	ScheduleTask scheduleTask = null;
	int i = 0;
	while ((i < this.Count) && (scheduleTask == null)){
		if (idetail.Equals(this[i].Detail))
			scheduleTask = this[i];
		i++;
	}
	return scheduleTask;
}

public
ScheduleTaskContainer getByMachId(int imachId){
	ScheduleTaskContainer scheduleTaskContainer = new ScheduleTaskContainer();
            	
	for (int i=0; i < this.Count; i++) { 
		if (imachId.Equals(this[i].MachId))
            scheduleTaskContainer.Add(this[i]);	
	}
	return scheduleTaskContainer;
}
        /*
public
ScheduleTask getBySubDetail(int subDetail){
	ScheduleTask scheduleTask = null;
	int i = 0;
	while ((i < this.Count) && (scheduleTask == null)){
		if (subDetail.Equals(this[i].SubDetail))
			scheduleTask = this[i];
		i++;
	}
	return scheduleTask;
}*/

public
int applyFilters(DateTime startDateFilter, DateTime stopDateFilter){
    int icounRemoved=0;                    
    for (int i=0; i < this.Count;i++){ 
        ScheduleTask scheduleTask = this[i]; 

        if (scheduleTask.StartDate < startDateFilter || scheduleTask.StartDate > stopDateFilter || scheduleTask.EndDate > stopDateFilter){
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
        ScheduleTask scheduleTask = this[i]; 
        
        DateUtil.inDates(startDate, endDate, scheduleTask.StartDate, scheduleTask.EndDate,out dhoursAux);
        dhours+= dhoursAux;                             
    }
    return dhours;
}

public
decimal getHoursFromMachDateRange(int imachId,DateTime startDate, DateTime endDate){
    decimal dhours=0;                    
    decimal dhoursAux=0;

    for (int i=0; i < this.Count;i++){ 
        ScheduleTask scheduleTask = this[i]; 
        
        if (scheduleTask.MachId == imachId) { 
            DateUtil.inDates(startDate, endDate, scheduleTask.StartDate, scheduleTask.EndDate,out dhoursAux);
            dhours+= dhoursAux;                             
        }
    }
    return dhours;
}

public
void add(ScheduleTaskContainer scheduleTaskContainer){    
    for (int i=0; i < scheduleTaskContainer.Count;i++)         
        this.Add(scheduleTaskContainer[i]);
}

public
void sortByDate(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new ScheduleDateComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((ScheduleTask)arrayToSort[i]);
	
}

#region ScheduleDateComparer
private
class ScheduleDateComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is ScheduleTask) && (y is ScheduleTask)){
            ScheduleTask v1 = (ScheduleTask)x;
            ScheduleTask v2 = (ScheduleTask)y;

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
        ScheduleTask scheduleTask = this[i];
        
        if (scheduleTask.MachId == imachId){
            scheduleReqView = new ScheduleReqView();
            scheduleReqView.copy(scheduleTask);
            scheduleReqViewContainer.Add(scheduleReqView);
        }    
    }    
}

public
void copyDates(ScheduleReqViewContainer scheduleReqViewContainer,int imachId=0){	
    for (int i=0; i < this.Count; i++) { 
        ScheduleTask    scheduleTask = this[i];

        if (imachId == 0 || imachId == scheduleTask.MachId) { 
            ScheduleReqView scheduleReqView = scheduleReqViewContainer.getByKey(scheduleTask.HdrId, scheduleTask.Detail, ScheduleReqView.SCHEDULE_TYPE_TASK);
            if (scheduleReqView!= null){
                scheduleTask.StartDate  = scheduleReqView.StartDate;
                scheduleTask.EndDate    = scheduleReqView.EndDate;
            }            
        }
	}	
}

} // class
} // package