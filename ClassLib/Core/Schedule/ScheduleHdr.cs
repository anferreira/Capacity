/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;
using System.Collections;

namespace Nujit.NujitERP.ClassLib.Core.ScheduleDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class ScheduleHdr : BusinessObject {

private int id;
private DateTime dateCreated;
private string status;
private string plant;
DateTime dateTimeStamp;

private SchedulePartContainer schedulePartContainer;
private ScheduleTaskContainer scheduleTaskContainer;
private ScheduleDownContainer scheduleDownContainer;

#if !WEB
internal
#else
public
#endif
ScheduleHdr(){
	this.id = 0;
	this.dateCreated = DateTime.Now;
	this.status = Constants.STATUS_ACTIVE;
    this.plant = "";    
    this.dateTimeStamp = DateUtil.MinValue;

    this.schedulePartContainer = new SchedulePartContainer();
    this.scheduleTaskContainer = new ScheduleTaskContainer();
    this.scheduleDownContainer = new ScheduleDownContainer();
}

internal
ScheduleHdr(
	int id,
	DateTime dateCreated,
	string status,
    string plant,
    DateTime dateTimeStamp){
	this.id = id;
	this.dateCreated = dateCreated;
	this.status = status;
    this.plant = plant;
    this.dateTimeStamp = dateTimeStamp;    

    this.schedulePartContainer = new SchedulePartContainer();
    this.scheduleTaskContainer = new ScheduleTaskContainer();
    this.scheduleDownContainer = new ScheduleDownContainer();
}

[System.Runtime.Serialization.DataMember]
public
int Id {
	get { return id;}
	set { if (this.id != value){
			this.id = value;
			Notify("Id");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime DateCreated {
	get { return dateCreated;}
	set { if (this.dateCreated != value){
			this.dateCreated = value;
			Notify("DateCreated");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Status {
	get { return status;}
	set { if (this.status != value){
			this.status = value;
			Notify("Status");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Plant {
	get { return plant; }
	set { if (this.plant != value){
			this.plant = value;
			Notify("Plant");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime DateTimeStamp {
	get { return dateTimeStamp; }
	set { if (this.dateTimeStamp != value){
			this.dateTimeStamp = value;
			Notify("DateTimeStamp");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
SchedulePartContainer SchedulePartContainer {
	get { return schedulePartContainer; }
	set { if (this.schedulePartContainer != value){
			this.schedulePartContainer = value;
			Notify("SchedulePartContainer");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
ScheduleTaskContainer ScheduleTaskContainer {
	get { return scheduleTaskContainer; }
	set { if (this.scheduleTaskContainer != value){
			this.scheduleTaskContainer = value;
			Notify("ScheduleTaskContainer");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
ScheduleDownContainer ScheduleDownContainer {
	get { return scheduleDownContainer; }
	set { if (this.scheduleDownContainer != value){
			this.scheduleDownContainer = value;
			Notify("ScheduleDownContainer");
		}
	}
}
     
public override
bool Equals(object obj){
	if (obj is ScheduleHdr)
		return	this.id.Equals(((ScheduleHdr)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void fillRedundances(){    
    int i=0;

    schedulePartContainer.sortByDate();
    for (i=0;i < schedulePartContainer.Count;i++){
        SchedulePart schedulePart = schedulePartContainer[i];
        
        schedulePart.HdrId = this.Id;
        schedulePart.Detail = i+1;                  
        schedulePart.fillRedundances();
    }

    scheduleTaskContainer.sortByDate();
    for (i=0;i < scheduleTaskContainer.Count;i++){
        ScheduleTask scheduleTask = scheduleTaskContainer[i];
        
        scheduleTask.HdrId = this.Id;
        scheduleTask.Detail = i+1;        
    }

    scheduleDownContainer.sortByDate();
    for (i=0;i < scheduleDownContainer.Count;i++){
        ScheduleDown scheduleDown = scheduleDownContainer[i];
        
        scheduleDown.HdrId = this.Id;
        scheduleDown.Detail = i+1;        
    }
    
}

public
ScheduleReqViewContainer buildReqContainer(){   
    ScheduleReqViewContainer    scheduleReqViewContainer = new ScheduleReqViewContainer();
    ScheduleReqView             scheduleReqView = new ScheduleReqView();

    fillRedundances();  //proerly filled keys and ordered by date        
    //parts            
    foreach (SchedulePart schedulePart in SchedulePartContainer){
        scheduleReqView = new ScheduleReqView();
        scheduleReqView.copy(schedulePart);
        scheduleReqViewContainer.Add(scheduleReqView);
    }   
    //tasks            
    foreach (ScheduleTask scheduleTask in ScheduleTaskContainer){
        scheduleReqView = new ScheduleReqView();
        scheduleReqView.copy(scheduleTask);
        scheduleReqViewContainer.Add(scheduleReqView);
    }
    //down            
    foreach (ScheduleDown scheduleDown in ScheduleDownContainer){
        scheduleReqView = new ScheduleReqView();
        scheduleReqView.copy(scheduleDown);
        scheduleReqViewContainer.Add(scheduleReqView);
    }
              
    scheduleReqViewContainer.sortByMachineDate();//sort by Requirment/Date (Part/Task)
    fillQueueChilds(scheduleReqViewContainer);

    buildTotals(scheduleReqViewContainer);

    return scheduleReqViewContainer;
}

public
ScheduleReqViewContainer applyFiltersReqContainer(ScheduleReqViewContainer scheduleReqViewContainerOriginal,
                                                  ScheduleReqView scheduleReqViewFilter,DateTime startDateTime,DateTime stopDateTime){   

    ScheduleReqViewContainer    scheduleReqViewContainer = new ScheduleReqViewContainer();
    ScheduleReqView             scheduleReqViewAux = new ScheduleReqView();
    bool                        bvalidRecord=true;
                        
    foreach (ScheduleReqView scheduleReqView in scheduleReqViewContainerOriginal){
        
        bvalidRecord=true;
        if (scheduleReqView.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_SUBTOTAL)) 
            bvalidRecord=false;

        if (scheduleReqViewFilter != null && scheduleReqViewFilter.MachId > 0 && 
            (scheduleReqViewFilter.MachId != scheduleReqView.MachId))
            bvalidRecord=false;

        if (scheduleReqView.StartDate < startDateTime || scheduleReqView.EndDate > stopDateTime)
            bvalidRecord=false;

        if (bvalidRecord)     
            scheduleReqViewContainer.Add(scheduleReqView);
    }
    scheduleReqViewContainer.sortByMachineDate();//sort by Requirment/Date (Part/Task)    
    buildTotals(scheduleReqViewContainer);

    return scheduleReqViewContainer;
}

public
void buildTotals(ScheduleReqViewContainer scheduleReqViewContainer ){ 
    return; //no total for now
    //totals
    int                         imachId=0;
    ScheduleReqViewContainer    scheduleReqViewTotalContainer = new ScheduleReqViewContainer();
    ScheduleReqView             scheduleReqViewTotal=null, scheduleReqView= null;
    ScheduleReqViewContainer    scheduleReqViewContainerNew = new ScheduleReqViewContainer();
    ScheduleReqView             scheduleReqViewGlobalTotal = scheduleReqViewContainer.getTotalByMachId(0); //global total


    for (int i=0; i < scheduleReqViewContainer.Count;i++){
        scheduleReqView = scheduleReqViewContainer[i];
        
        if (i>0){
            if (imachId != scheduleReqView.MachId){
                scheduleReqViewTotal = scheduleReqViewTotalContainer.getTotalByMachId(imachId); 
                if (scheduleReqViewTotal!= null)
                    scheduleReqViewContainerNew.Add(scheduleReqViewTotal);
                //clear and                 
                scheduleReqViewTotalContainer.Clear();
                
            }
        } 
        imachId= scheduleReqView.MachId;
        scheduleReqViewContainerNew.Add(scheduleReqView);
        scheduleReqViewTotalContainer.Add(scheduleReqView);
    }        

    //sumarize last machid
    scheduleReqViewTotal = scheduleReqViewTotalContainer.getTotalByMachId(imachId); 
    if (scheduleReqViewTotal!= null)
        scheduleReqViewContainerNew.Add(scheduleReqViewTotal);
    if (scheduleReqViewGlobalTotal!= null){
        ScheduleReqView  scheduleReqViewGlobalTotalAux = new ScheduleReqView();
        scheduleReqViewGlobalTotalAux.ScheduleType = scheduleReqViewGlobalTotal.ScheduleType;
        scheduleReqViewGlobalTotalAux.Hours = scheduleReqViewGlobalTotal.Hours;
        scheduleReqViewGlobalTotalAux.MachShow = "Total";
        scheduleReqViewContainerNew.Add(scheduleReqViewGlobalTotalAux);
     }  

    scheduleReqViewContainer.Clear();//clear and copy all records with totals
    for (int i=0; i < scheduleReqViewContainerNew.Count;i++)
        scheduleReqViewContainer.Add(scheduleReqViewContainerNew[i]);    
}


/*
public
SchedulePart getAlreadyPartFromDateRange(bool badding,int ireqId,DateTime startdate,DateTime endDate){   
    ScheduleReq     scheduleReq = null;
    SchedulePart    schedulePartRet = null;
    SchedulePart    schedulePartAux = null;
    int             i=0;
    bool            bdateOK = false;

    for (i=0;i < scheduleReqContainer.Count;i++){
        scheduleReq = scheduleReqContainer[i];

        if (scheduleReq.ReqID == ireqId){
            for (int j=0;j < scheduleReq.SchedulePartContainer.Count;i++){              
                schedulePartAux = scheduleReq.SchedulePartContainer[i]; 

                bdateOK = false;
    
                if (!badding && )

                if (badding && )
            }
        }                      
    }    

    return schedulePartRet;
}
 */
public
void fillQueueChilds(ScheduleReqViewContainer scheduleReqViewContainer){    
    ScheduleReqView     scheduleReqView = null;
    
    for (int i=0; i < scheduleReqViewContainer.Count;i++){
        scheduleReqView = scheduleReqViewContainer[i];
               
        if (scheduleReqView.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_PART)){
            SchedulePart schedulePart = this.SchedulePartContainer.getByDetail(scheduleReqView.Detail);
            if (schedulePart!=null)
                schedulePart.Queue = scheduleReqView.Queue;

        }else if (scheduleReqView.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_TASK)){
            ScheduleTask scheduleTask = this.ScheduleTaskContainer.getByDetail(scheduleReqView.Detail);
            if (scheduleTask != null)
                scheduleTask.Queue = scheduleReqView.Queue;
        }else if (scheduleReqView.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_DOWN)){
            ScheduleDown scheduleDown = this.ScheduleDownContainer.getByDetail(scheduleReqView.Detail);
            if (scheduleDown != null)
                scheduleDown.Queue = scheduleReqView.Queue;            
        }        
    }
}

public
decimal getTotalHrsByMachineDateRange(int imachId, DateTime startDate,DateTime endDate){
    decimal dhours =0;

    dhours = SchedulePartContainer.getHoursFromMachDateRange(imachId,startDate,endDate);
    dhours+= ScheduleTaskContainer.getHoursFromMachDateRange(imachId,startDate,endDate);
    dhours+= ScheduleDownContainer.getHoursFromMachDateRange(imachId,startDate,endDate);        
    return  dhours;
}

/*
public
bool getAvailableDateForDate(string stype, int ireqId,DateTime startDate,decimal qty,decimal drunStd){
    decimal dhours =0;

    ScheduleReq scheduleReq =  this.ScheduleReqContainer.getByRequirment(stype, ireqId);
    if (scheduleReq!= null){

        ArrayList arrayList = new ArrayList();
        

        dhours = scheduleReq.SchedulePartContainer.getHoursFromDateRange(startDate,endDate);
        dhours+= scheduleReq.ScheduleTaskContainer.getHoursFromDateRange(startDate,endDate);
    }    
    return  dhours;
}*/

public
SchedulePart getSchedulePart(ScheduleReqView scheduleReqView){
    SchedulePart    schedulePart=null;    
    
    if (scheduleReqView != null && scheduleReqView.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_PART)){
        schedulePart = this.SchedulePartContainer.getByDetail(scheduleReqView.Detail);
    }
    return schedulePart;
}

public
ScheduleTask getScheduleTask(ScheduleReqView scheduleReqView){
    ScheduleTask    scheduleTask = null;
        
    if (scheduleReqView != null && scheduleReqView.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_TASK)){
        scheduleTask = this.ScheduleTaskContainer.getByDetail(scheduleReqView.Detail);
    }
    return scheduleTask;
}

public
Hashtable getHashFullScheduleReceiptParts(){   
    Hashtable                       hashScheduleReceiptPart = new Hashtable();
    ScheduleReceiptPartContainer    scheduleReceiptPartContainer = new ScheduleReceiptPartContainer();
    string                          skey = "";

    //crete hash as key = Part + Seq, loading ScheduleReceiptParts
            
    foreach (SchedulePart schedulePart in this.SchedulePartContainer){   //parts          

        skey = schedulePart.Part.ToUpper() + Constants.DEFAULT_SEP + schedulePart.Seq.ToString();

        if (hashScheduleReceiptPart.Contains(skey))
            scheduleReceiptPartContainer = (ScheduleReceiptPartContainer)hashScheduleReceiptPart[skey];
        else{
            scheduleReceiptPartContainer = new ScheduleReceiptPartContainer();
            hashScheduleReceiptPart.Add(skey,scheduleReceiptPartContainer);
        }
        foreach (ScheduleReceiptPart scheduleReceiptPart in schedulePart.ScheduleReceiptPartContainer){//receipt parts
            scheduleReceiptPartContainer.Add(scheduleReceiptPart);                
        }                   
    }                   
        
    return hashScheduleReceiptPart;
}

public
bool getMaxDates(int imachId,out DateTime startDate,out DateTime endDate){
    bool        bresult = false;
    startDate = endDate = DateUtil.MinValue;

    int i=0;

    schedulePartContainer.sortByDate();
    for (i=0;i < schedulePartContainer.Count;i++){
        SchedulePart schedulePart = schedulePartContainer[i];
        
        if (schedulePart.MachId == imachId) { 
            if (schedulePart.StartDate > startDate)
                startDate = schedulePart.StartDate;
            if (schedulePart.EndDate > endDate)
                endDate = schedulePart.EndDate;        
        }
    }
    
    for (i=0;i < scheduleTaskContainer.Count;i++){
        ScheduleTask scheduleTask = scheduleTaskContainer[i];
        
        if (scheduleTask.MachId == imachId) { 
            if (scheduleTask.StartDate > startDate)
                startDate = scheduleTask.StartDate;
            if (scheduleTask.EndDate > endDate)
                endDate = scheduleTask.EndDate;   
        }
    }

    for (i=0;i < scheduleDownContainer.Count;i++){
        ScheduleDown scheduleDown = scheduleDownContainer[i];
        
        if (scheduleDown.MachId == imachId) { 
            if (scheduleDown.StartDate > startDate)
                startDate = scheduleDown.StartDate;
            if (scheduleDown.EndDate > endDate)
                endDate = scheduleDown.EndDate;   
        }
    }

    bresult = startDate!= DateUtil.MinValue || endDate != DateUtil.MinValue;
    return bresult;
}
        /*
public
ArrayList getDifferentsRequirment(){
    ArrayList       arrayListMachIds = new ArrayList();
    Hashtable       hashTable = new Hashtable(); 
    int             i=0;
    
     for (i=0;i < schedulePartContainer.Count;i++){
        SchedulePart schedulePart = schedulePartContainer[i];
        
        if (!hashTable.ContainsKey(schedulePart.MachId)){         
            hashTable.Add(schedulePart.MachId,schedulePart.MachId);     
            arrayListMachIds.Add(schedulePart.MachId);
        }                                    
    }
    
    for (i=0;i < scheduleTaskContainer.Count;i++){
        ScheduleTask scheduleTask = scheduleTaskContainer[i];
        
        if (!hashTable.ContainsKey(scheduleTask.MachId)){         
            hashTable.Add(scheduleTask.MachId, scheduleTask.MachId);     
            arrayListMachIds.Add(scheduleTask.MachId);
        }   
    }

    for (i=0;i < scheduleDownContainer.Count;i++){
        ScheduleDown scheduleDown = scheduleDownContainer[i];
        
        if (!hashTable.ContainsKey(scheduleDown.MachId)){         
            hashTable.Add(scheduleDown.MachId, scheduleDown.MachId);     
            arrayListMachIds.Add(scheduleDown.MachId);
        }   
    }        
	return arrayListMachIds;
}
*/

public
ArrayList getDifferentsRequirment(){
    ArrayList           arrayListMachIds = new ArrayList();
    Hashtable           hashTable = new Hashtable(); 
    int                 i=0;
    ScheduleReqView     scheduleReqView=null;
    
     for (i=0;i < schedulePartContainer.Count;i++){
        SchedulePart schedulePart = schedulePartContainer[i];
        
        if (!hashTable.ContainsKey(schedulePart.MachId)){         
            hashTable.Add(schedulePart.MachId,schedulePart.MachId);

            scheduleReqView = new ScheduleReqView();
            scheduleReqView.MachId= schedulePart.MachId;
            arrayListMachIds.Add(scheduleReqView);
        }                                    
    }
    
    for (i=0;i < scheduleTaskContainer.Count;i++){
        ScheduleTask scheduleTask = scheduleTaskContainer[i];
        
        if (!hashTable.ContainsKey(scheduleTask.MachId)){         
            hashTable.Add(scheduleTask.MachId, scheduleTask.MachId);     

            scheduleReqView = new ScheduleReqView();
            scheduleReqView.MachId= scheduleTask.MachId;
            arrayListMachIds.Add(scheduleReqView);
        }   
    }

    for (i=0;i < scheduleDownContainer.Count;i++){
        ScheduleDown scheduleDown = scheduleDownContainer[i];
        
        if (!hashTable.ContainsKey(scheduleDown.MachId)){         
            hashTable.Add(scheduleDown.MachId, scheduleDown.MachId);     

            scheduleReqView = new ScheduleReqView();
            scheduleReqView.MachId= scheduleDown.MachId;
            arrayListMachIds.Add(scheduleReqView);
        }   
    }        
	return arrayListMachIds;
}

public
bool getJobDate(ScheduleReqView scheduleReqViewNew){    
    bool                        bresult=false;    
    int                         i=0;
    ScheduleReqViewContainer    scheduleReqViewContainer= new ScheduleReqViewContainer();
    ScheduleReqView             scheduleReqView=null;
    
    fillRedundances();//so records will be ordered by date

    scheduleReqViewNew.HdrId = scheduleReqViewNew.Detail = int.MinValue; 
    scheduleReqViewNew.StartDate = scheduleReqViewNew.StartDate.AddSeconds(1); //adjust time 1 sec after
    scheduleReqViewNew.EndDate = scheduleReqViewNew.StartDate.AddHours(scheduleReqViewNew.DurationHours());

    this.SchedulePartContainer.copyByMachine(scheduleReqViewContainer,scheduleReqViewNew.MachId);
    this.ScheduleDownContainer.copyByMachine(scheduleReqViewContainer,scheduleReqViewNew.MachId);
    this.ScheduleTaskContainer.copyByMachine(scheduleReqViewContainer,scheduleReqViewNew.MachId);

    scheduleReqViewContainer.Add(scheduleReqViewNew);   //add new job and sory by date
    scheduleReqViewContainer.sortByStartDate();

    // option:1-no job for that date (use date , move next jobs if needed)    
    //        2-already exists Job Between dates, so get Prior Job , adjust out new Job to be Scheduled after that Job, and move next job if needed 
    //        3-insert at the end

    int             indexFound  = scheduleReqViewContainer.getIndexFound(scheduleReqViewNew.HdrId,scheduleReqViewNew.Detail,scheduleReqViewNew.ScheduleType);
    ScheduleReqView scheduleReqViewPrior = null;

    scheduleReqViewNew.StartDate= scheduleReqViewNew.StartDate.AddSeconds(-1); //adjust time 1 sec before
    scheduleReqViewNew.EndDate  = scheduleReqViewNew.StartDate.AddHours(scheduleReqViewNew.DurationHours());

    if (indexFound > 0)
        scheduleReqViewPrior = (ScheduleReqView)scheduleReqViewContainer[indexFound-1];
    
    if (indexFound == scheduleReqViewContainer.Count-1){ //at the end             
        if (scheduleReqViewPrior!= null)
            moveNextJobsIfNeeded(scheduleReqViewContainer,indexFound,scheduleReqViewPrior.EndDate);

    }else if (indexFound == 0){ //first
        moveNextJobsIfNeeded(scheduleReqViewContainer,1,scheduleReqViewNew.EndDate);
    }else if (indexFound > 0){  //on middle
                               
        for (i= indexFound-2; i >= 0; i--) { //go back , while continue finding between dates
            scheduleReqView = scheduleReqViewContainer[i];
            //if between dates , position next
            if (scheduleReqView.EndDate > scheduleReqViewNew.StartDate && scheduleReqView.EndDate < scheduleReqViewNew.EndDate)
                scheduleReqViewPrior= scheduleReqView;
        } 

        if (scheduleReqViewPrior!= null){ //position job nex to this job
            indexFound = scheduleReqViewContainer.getIndexFound(scheduleReqViewPrior.HdrId, scheduleReqViewPrior.Detail,scheduleReqViewPrior.ScheduleType);
            moveNextJobsIfNeeded(scheduleReqViewContainer,indexFound+1,scheduleReqViewPrior.EndDate);
        }
    }

    //copy changes on dates    
    this.SchedulePartContainer.copyDates(scheduleReqViewContainer);            
    this.ScheduleDownContainer.copyDates(scheduleReqViewContainer);
    this.ScheduleTaskContainer.copyDates(scheduleReqViewContainer);            
    
    fillRedundances(); //right now fill properly ids for new record
    
    bresult=true;    
    return bresult;
}

private
void moveNextJobsIfNeeded(ScheduleReqViewContainer scheduleReqViewContainer, int indexStart,DateTime lastDate){
    ScheduleReqView scheduleReqView= null;
    bool            bcontinueMoving=true;

    for (int i= indexStart;i >=0 && i < scheduleReqViewContainer.Count && bcontinueMoving; i++){
        scheduleReqView = scheduleReqViewContainer[i];
        
        if (lastDate < scheduleReqView.StartDate)
            bcontinueMoving=false;
        else { 
            double duration = scheduleReqView.DurationHours();
            scheduleReqView.StartDate = lastDate.AddMinutes(1);            
            scheduleReqView.EndDate = scheduleReqView.StartDate.AddHours(duration);            
        }           
        lastDate = scheduleReqView.EndDate;
    }                        
}

} // class
} // package