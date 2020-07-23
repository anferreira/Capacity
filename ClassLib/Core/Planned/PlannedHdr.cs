/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using Nujit.NujitERP.ClassLib.Util;
using System.Collections;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core.Planned{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class PlannedHdr : BusinessObject {

private int id;
private DateTime dateCreated;
private string status;
private string plant;
private int totMachines;
private int machPlanned;
private int lastMachPlannedId;
private DateTime dateTimeStamp;


private PlannedReqContainer plannedReqContainer;

#if !WEB
internal
#else
public
#endif
PlannedHdr(){
	this.id = 0;
	this.dateCreated = DateTime.Now;
	this.status = "";
	this.plant = "";
	this.totMachines = 0;
	this.machPlanned = 0;
	this.lastMachPlannedId = 0;
    this.dateTimeStamp = DateUtil.MinValue;

    this.plannedReqContainer = new PlannedReqContainer();
}

internal
PlannedHdr(
	int id,
	DateTime dateCreated,
	string status,
	string plant,
	int totMachines,
	int machPlanned,
	int lastMachPlannedId,
    DateTime dateTimeStamp){
	this.id = id;
	this.dateCreated = dateCreated;
	this.status = status;
	this.plant = plant;
	this.totMachines = totMachines;
	this.machPlanned = machPlanned;
	this.lastMachPlannedId = lastMachPlannedId;
    this.dateTimeStamp = dateTimeStamp;

    this.plannedReqContainer = new PlannedReqContainer();
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
	get { return plant;}
	set { if (this.plant != value){
			this.plant = value;
			Notify("Plant");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int TotMachines {
	get { return totMachines;}
	set { if (this.totMachines != value){
			this.totMachines = value;
			Notify("TotMachines");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int MachPlanned {
	get { return machPlanned;}
	set { if (this.machPlanned != value){
			this.machPlanned = value;
			Notify("MachPlanned");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int LastMachPlannedId {
	get { return lastMachPlannedId;}
	set { if (this.lastMachPlannedId != value){
			this.lastMachPlannedId = value;
			Notify("LastMachPlannedId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
PlannedReqContainer PlannedReqContainer {
	get { return plannedReqContainer; }
	set { if (this.plannedReqContainer != value){
			this.plannedReqContainer = value;
			Notify("PlannedReqContainer");
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


public override
bool Equals(object obj){
	if (obj is PlannedHdr)
		return	this.id.Equals(((PlannedHdr)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void fillRedundances(){
    int itotMachines = 0;
    for (int i=0;i < plannedReqContainer.Count;i++){
        PlannedReq plannedReq = plannedReqContainer[i];
        
        plannedReq.HdrId = this.Id;
        plannedReq.Detail = i+1;              
        plannedReq.fillRedundances();

        if (plannedReq.Type.Equals(Nujit.NujitERP.ClassLib.Common.Constants.TYPE_MACHINE))
            itotMachines++;
    }
    this.TotMachines = itotMachines;
}

public
void copy(PlannedHdr plannedHdr){
	this.Id=plannedHdr.Id;
	this.DateCreated=plannedHdr.DateCreated;
	this.Status=plannedHdr.Status;
	this.Plant=plannedHdr.Plant;
	this.TotMachines=plannedHdr.TotMachines;
	this.MachPlanned=plannedHdr.MachPlanned;
	this.LastMachPlannedId=plannedHdr.LastMachPlannedId;
    this.DateTimeStamp = plannedHdr.DateTimeStamp;

    this.PlannedReqContainer.Clear();

    for (int i=0; i < plannedHdr.PlannedReqContainer.Count;i++){
        PlannedReq plannedReq = new PlannedReq();
        plannedReq.copy(plannedHdr.PlannedReqContainer[i]);    
    }        
}

public
PlannedPart getByReqPartDate(string stype,int ireqId,string spart,int seq,DateTime date){
    PlannedPart plannedPart = null;
    PlannedReq  plannedReq = this.PlannedReqContainer.getByRequirment(stype,ireqId);

    if (plannedReq!= null)
        plannedPart = plannedReq.PlannedPartContainer.getByPartSeqDateRangeWeek(spart, seq, date);

    return plannedPart;
}

public
PlannedLabourContainer getPlannedLabourContainerList(DateTime  startDate,DateTime endDate){
    PlannedLabourContainer plannedLabourContainer = new PlannedLabourContainer();

    for (int i=0; i < PlannedReqContainer.Count;i++){
        PlannedReq plannedReq = PlannedReqContainer[i];

        for (int j=0; j < plannedReq.PlannedLabourContainer.Count;j++){
            PlannedLabour plannedLabour = plannedReq.PlannedLabourContainer[j];
            if (plannedLabour.StartDate >= startDate && plannedLabour.EndDate <= endDate)
                plannedLabourContainer.Add(plannedLabour);
        }                       
    }  
    return plannedLabourContainer;
}

public
decimal getPlannedLabourTotEmployee(DateTime  startDate,DateTime endDate){
    decimal dtotEmployee=0;

    for (int i=0; i < PlannedReqContainer.Count;i++){
        PlannedReq plannedReq = PlannedReqContainer[i];

        for (int j=0; j < plannedReq.PlannedLabourContainer.Count;j++){
            PlannedLabour plannedLabour = plannedReq.PlannedLabourContainer[j];
            if (plannedLabour.StartDate >= startDate && plannedLabour.EndDate <= endDate){
                dtotEmployee+= plannedLabour.TotEmployPlan;                
            }
        }                       
    }  
    return dtotEmployee;
}

public
decimal getPlannedOverTimeTotEmployee(DateTime  startDate,DateTime endDate){
    decimal dtotEmployee=0;

    for (int i=0; i < PlannedReqContainer.Count;i++){
        PlannedReq plannedReq = PlannedReqContainer[i];

        for (int j=0; j < plannedReq.PlannedLabourContainer.Count;j++){
            PlannedLabour plannedLabour = plannedReq.PlannedLabourContainer[j];
            if (plannedLabour.StartDate >= startDate && plannedLabour.EndDate <= endDate){
                dtotEmployee+= plannedLabour.TotEmployOver;                
            }
        }                       
    }  
    return dtotEmployee;
}

public
Hashtable groupByPartSeq(int inotReqId=0,string snotType="",int inotReqId2=0,string snotType2=""){
    Hashtable               hashtable = new Hashtable();
    string                  skey= "";
    PlannedPartContainer    plannedPartContainer = null;
    bool                    bprocessReq=true;

    for (int i=0; i < PlannedReqContainer.Count;i++){
        PlannedReq plannedReq = PlannedReqContainer[i];

        bprocessReq=true;
        if (inotReqId > 0 && !string.IsNullOrEmpty(snotType) && plannedReq.ReqID == inotReqId && plannedReq.Type.Equals(snotType))
            bprocessReq=false;
        if (inotReqId2 > 0 && !string.IsNullOrEmpty(snotType2) && plannedReq.ReqID == inotReqId2 && plannedReq.Type.Equals(snotType2))
            bprocessReq=false;

        for (int j=0; bprocessReq && j < plannedReq.PlannedPartContainer.Count;j++){

            PlannedPart plannedPart = plannedReq.PlannedPartContainer[j];
            skey= plannedPart.Part.ToUpper()+ Constants.DEFAULT_SEP + plannedPart.Seq;

            if (hashtable.Contains(skey))
                plannedPartContainer = (PlannedPartContainer)hashtable[skey];
            else { 
                plannedPartContainer = new PlannedPartContainer();
                hashtable.Add(skey,plannedPartContainer);
            }

            plannedPartContainer.Add(plannedPart);
        }                       
    }  
    return hashtable;
}

public
decimal getPlannedQtyByPartSeqRangeDateBasedHash(Hashtable hashtable,string spart,int seq,DateTime startDate,DateTime endDate){        
    decimal                 dplanned=0;
    string                  skey= spart.ToUpper()+ Constants.DEFAULT_SEP + seq;
    PlannedPartContainer    plannedPartContainer = null;

    if (hashtable.Contains(skey)){ 
        plannedPartContainer = (PlannedPartContainer)hashtable[skey];
        dplanned = plannedPartContainer.getByPartSeqDateRangeWeek(spart,seq,startDate,endDate);
    }
    
    return dplanned;
}


public
Hashtable groupLabourByDateShiftNum(int ireqId){
    Hashtable               hashtable = new Hashtable();
    string                  skey= "";    
    PlannedReq              plannedReq = PlannedReqContainer.getByRequirment(Constants.TYPE_LABOUR,ireqId);
    DateTime                startDate = DateTime.Now;
    DateTime                endDate = DateTime.Now;
    PlannedLabourContainer  plannedLabourContainer=null;

    for (int i=0; plannedReq!= null && i < plannedReq.PlannedLabourContainer.Count; i++){
        PlannedLabour plannedLabour = plannedReq.PlannedLabourContainer[i];

        DateUtil.getPriorMondayNextSundayFromDate(plannedLabour.StartDate,out startDate,out endDate);

        skey= DateUtil.getDateRepresentation(startDate,DateUtil.MMDDYYYY) + Constants.DEFAULT_SEP + plannedLabour.ShiftNum;
        if (hashtable.Contains(skey))
            plannedLabourContainer = (PlannedLabourContainer)hashtable[skey];
        else { 
            plannedLabourContainer = new PlannedLabourContainer();
            hashtable.Add(skey, plannedLabourContainer);
        }

        plannedLabourContainer.Add(plannedLabour);                                       
    }  
    return hashtable;
}

public
Hashtable groupLabourByDateShiftNum(){
    Hashtable               hashtable = new Hashtable();
    string                  skey= "";    
    PlannedReq              plannedReq = null;
    DateTime                startDate = DateTime.Now;
    DateTime                endDate = DateTime.Now;
    PlannedLabourContainer  plannedLabourContainer=null;

    for (int j=0; j < this.PlannedReqContainer.Count;j++){
        plannedReq = this.PlannedReqContainer[j];

        for (int i=0; plannedReq.Type.Equals(Constants.TYPE_LABOUR) && i < plannedReq.PlannedLabourContainer.Count; i++){
            PlannedLabour plannedLabour = plannedReq.PlannedLabourContainer[i];

            DateUtil.getPriorMondayNextSundayFromDate(plannedLabour.StartDate,out startDate,out endDate);

            skey= DateUtil.getDateRepresentation(startDate,DateUtil.MMDDYYYY) + Constants.DEFAULT_SEP + plannedLabour.ShiftNum;
            if (hashtable.Contains(skey))
                plannedLabourContainer = (PlannedLabourContainer)hashtable[skey];
            else { 
                plannedLabourContainer = new PlannedLabourContainer();
                hashtable.Add(skey, plannedLabourContainer);
            }

            plannedLabourContainer.Add(plannedLabour);                                       
        }  
    }
    return hashtable;
}

} // class
} // package