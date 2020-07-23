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


namespace Nujit.NujitERP.ClassLib.Core.ScheduleDemand{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class ScheduleReqViewContainer : ObservableCollection<ScheduleReqView> { 
#else
class ScheduleReqViewContainer : Collection<ScheduleReqView> { 
#endif

internal
ScheduleReqViewContainer() : base(){
}

public
ScheduleReqView getByKey(int hdrId, int detail,string scheduleType){
	ScheduleReqView ScheduleReqView = null;
	int i = 0;
	while ((i < this.Count) && (ScheduleReqView == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail) && scheduleType.Equals(this[i].ScheduleType))
			ScheduleReqView = this[i];
		i++;
	}
	return ScheduleReqView;
}

public
int getIndexFound(int hdrId, int detail,string scheduleType){	
	int indexFound=-1;

    for (int i=0; i < this.Count && indexFound < 0; i++) { 
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail) && scheduleType.Equals(this[i].ScheduleType))
            indexFound = i;		
	}
	return indexFound;
}

public
ScheduleReqView getAlreadyPartFromDateRange(bool badding,ScheduleReqView scheduleReqView){   
    ScheduleReqView scheduleReqViewRet = null;
    ScheduleReqView scheduleReqAux = null;
    bool            bdateOk = false;

    for (int i=0; i < this.Count && scheduleReqViewRet==null; i++){
        scheduleReqAux = this[i];

        if (scheduleReqAux.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_SUBTOTAL) || //not totals
            string.IsNullOrEmpty(scheduleReqAux.ScheduleType) || //schedule Type empty so not Part and not Task
            scheduleReqAux.MachId != scheduleReqView.MachId || //not same requirment
            (!badding && scheduleReqAux.Equals(scheduleReqView)))//same record, so continue with next 
             continue;        
        
        bdateOk = false;

        if (scheduleReqView.EndDate <= scheduleReqAux.StartDate)
            bdateOk = true;
        if (scheduleReqView.StartDate >= scheduleReqAux.EndDate)
            bdateOk = true;

        /*
        if (scheduleReqView.StartDate > scheduleReqAux.StartDate &&
            scheduleReqView.StartDate < scheduleReqAux.EndDate)
            bdateOk = false;

        if (scheduleReqAux.StartDate > scheduleReqView.StartDate &&
            scheduleReqAux.StartDate < scheduleReqView.EndDate)
            bdateOk = false;

         if (scheduleReqView.EndDate > scheduleReqAux.StartDate &&
             scheduleReqView.EndDate < scheduleReqAux.EndDate)
            bdateOk = false;

         if (scheduleReqAux.EndDate > scheduleReqView.StartDate &&
             scheduleReqAux.EndDate < scheduleReqView.EndDate)
            bdateOk = false;
       -*/

        if (!bdateOk)
            scheduleReqViewRet= scheduleReqAux;
    }
    return scheduleReqViewRet;
}


public
ScheduleReqView getTotalByMachId(int imachId){   
    ScheduleReqView scheduleReqViewRet = null;
    ScheduleReqView scheduleReqView = null;    
    DateTime        dateTime= DateTime.MinValue;

    for (int i=0; i < this.Count; i++){
        scheduleReqView = this[i];
        if ( (scheduleReqView.MachId == imachId || imachId == 0)){
            if (scheduleReqViewRet == null){
                scheduleReqViewRet = new ScheduleReqView(scheduleReqView);
                scheduleReqViewRet.Hours = 0;
                scheduleReqViewRet.ScheduleType = ScheduleReqView.SCHEDULE_TYPE_SUBTOTAL;
            } 
            scheduleReqViewRet.Hours+= Convert.ToDecimal((scheduleReqView.EndDate - scheduleReqView.StartDate).TotalHours); 
        }                  
    }
    
    return scheduleReqViewRet;
}

public
void fillQueue(){	
    string  skey= "";
    string  skeyCurrent= "";
    int     icounter=1;    
                        
    for (int i=0; i < this.Count;i++){
        ScheduleReqView scheduleReqView  = this[i];		

        skey= scheduleReqView.MachId.ToString();
        if (skey.CompareTo(skeyCurrent) !=0){
            skeyCurrent= skey;
            icounter=1;    
        }else
            icounter++;    
        scheduleReqView.Queue = icounter;
	}
}

public
void sortByMachineDate(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new ScheduleDateComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((ScheduleReqView)arrayToSort[i]);

    fillQueue();	
}

public
void sortByStartDate(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new ScheduleStartDateComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((ScheduleReqView)arrayToSort[i]);

    fillQueue();	
}

public
void sortByMachine(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new ScheduleMachineComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((ScheduleReqView)arrayToSort[i]);    
}

#region ScheduleDateComparer
private
class ScheduleDateComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is ScheduleReqView) && (y is ScheduleReqView)){
            ScheduleReqView v1 = (ScheduleReqView)x;
            ScheduleReqView v2 = (ScheduleReqView)y;

            string saux1 = v1.MachShow + Constants.DEFAULT_SEP + DateUtil.getCompleteDateRepresentation(v1.StartDate,DateUtil.YYYYMMDD);
            string saux2 = v2.MachShow + Constants.DEFAULT_SEP + DateUtil.getCompleteDateRepresentation(v2.StartDate,DateUtil.YYYYMMDD);
            return saux1.CompareTo(saux2);
        }else
            return -1;
    }
}
#endregion ScheduleDateComparer

#region ScheduleStartDateComparer
private
class ScheduleStartDateComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is ScheduleReqView) && (y is ScheduleReqView)){
            ScheduleReqView v1 = (ScheduleReqView)x;
            ScheduleReqView v2 = (ScheduleReqView)y;

            return v1.StartDate.CompareTo(v2.StartDate);
        }else
            return -1;
    }
}

#endregion ScheduleStartDateComparer

#region ScheduleMachineComparer
private
class ScheduleMachineComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is ScheduleMachine) && (y is ScheduleMachine)){
            ScheduleMachine v1 = (ScheduleMachine)x;
            ScheduleMachine v2 = (ScheduleMachine)y;

            string saux1 = v1.MachShow;
            string saux2 = v2.MachShow;
            return saux1.CompareTo(saux2);
        }else
            return -1;
    }
}
#endregion ScheduleMachineComparer


} // class
} // package