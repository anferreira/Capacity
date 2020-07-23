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

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class CapShiftProfile : BusinessObject {

private int id;
private int shiftNum;
private string status;
private DateTime startDate;
private DateTime endDate;
private string plant;
private string shiftStart;
private string shiftEnd;
private string monWork;
private string tueWork;
private string wedWork;
private string thuWork;
private string friWork;
private string satWork;
private string sunWork;
private string shiftDefault;
private string shiftType;
private string shiftNumId;

private CapShiftProfileDtlContainer capShiftProfileDtlContainer;
private CapShiftProfileMachPlanContainer capShiftProfileMachPlanContainer;

#if !WEB
internal
#else
public
#endif
CapShiftProfile(){
	this.id = 0;
	this.shiftNum = 0;
	this.status = Constants.STATUS_ACTIVE;
	this.startDate = DateUtil.MinValue;
	this.endDate = DateUtil.MinValue;
    this.plant = "";
    this.shiftStart = "";        
    this.shiftEnd = "";
    this.MonWork= 
    this.tueWork= 
    this.wedWork= 
    this.thuWork= 
    this.friWork= Constants.STRING_YES;
    this.satWork= 
    this.sunWork= Constants.STRING_NO;
    this.shiftDefault= Constants.STRING_NO;
    this.shiftType = Constants.SHIFT_TYPE_REGULAR;
    this.shiftNumId = "";
    this.capShiftProfileDtlContainer = new CapShiftProfileDtlContainer();
    this.capShiftProfileMachPlanContainer = new CapShiftProfileMachPlanContainer();
}

internal
CapShiftProfile(
	int id,
	int shiftNum,
	string status,
	DateTime startDate,
	DateTime endDate,
    string plant,
    string shiftStart,
    string shiftEnd){
	this.id = id;
	this.shiftNum = shiftNum;
	this.status = status;
	this.startDate = startDate;
	this.endDate = endDate;
    this.plant = plant;
    this.shiftStart = shiftStart;
    this.shiftEnd = shiftEnd;    
    this.capShiftProfileDtlContainer = new CapShiftProfileDtlContainer();
    this.capShiftProfileMachPlanContainer = new CapShiftProfileMachPlanContainer();
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
int ShiftNum {
	get { return shiftNum;}
	set { if (this.shiftNum != value){
			this.shiftNum = value;
			Notify("ShiftNum");
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
DateTime StartDate {
	get { return startDate;}
	set { if (this.startDate != value){
			this.startDate = value;
			Notify("StartDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime EndDate {
	get { return endDate;}
	set { if (this.endDate != value){
			this.endDate = value;
			Notify("EndDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Plant {
	get { return plant;}
	set { if (this.plant != value){
			this.plant = value;
			Notify("Pant");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
string ShiftStart {
	get { return shiftStart; }
	set { if (this.shiftStart != value){
			this.shiftStart = value;
			Notify("ShiftStart");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ShiftEnd {
	get { return shiftEnd; }
	set { if (this.shiftEnd != value){
			this.shiftEnd = value;
			Notify("ShiftEnd");
		}
	}
}   

[System.Runtime.Serialization.DataMember]
public
string MonWork {
	get { return monWork; }
	set { if (this.monWork != value){
			this.monWork = value;
			Notify("MonWork");
		}
	}
} 

[System.Runtime.Serialization.DataMember]
public
string TueWork {
	get { return tueWork; }
	set { if (this.tueWork != value){
			this.tueWork = value;
			Notify("TueWork");
		}
	}
} 

[System.Runtime.Serialization.DataMember]
public
string WedWork {
	get { return wedWork; }
	set { if (this.wedWork != value){
			this.wedWork = value;
			Notify("WedWork");
		}
	}
} 

[System.Runtime.Serialization.DataMember]
public
string ThuWork {
	get { return thuWork; }
	set { if (this.thuWork != value){
			this.thuWork = value;
			Notify("ThuWork");
		}
	}
} 

[System.Runtime.Serialization.DataMember]
public
string FriWork {
	get { return friWork; }
	set { if (this.friWork != value){
			this.friWork = value;
			Notify("FriWork");
		}
	}
} 

[System.Runtime.Serialization.DataMember]
public
string SatWork {
	get { return satWork; }
	set { if (this.satWork != value){
			this.satWork = value;
			Notify("SatWork");
		}
	}
} 

[System.Runtime.Serialization.DataMember]
public
string SunWork {
	get { return sunWork; }
	set { if (this.sunWork != value){
			this.sunWork = value;
			Notify("SunWork");
		}
	}
} 

[System.Runtime.Serialization.DataMember]
public
string ShiftDefault {
	get { return shiftDefault; }
	set { if (this.shiftDefault != value){
			this.shiftDefault = value;
			Notify("ShiftDefault");
		}
	}
} 

[System.Runtime.Serialization.DataMember]
public
string ShiftType {
	get { return shiftType; }
	set { if (this.shiftType != value){
			this.shiftType = value;
			Notify("ShiftType");
		}
	}
} 

[System.Runtime.Serialization.DataMember]
public
string ShiftNumId {
	get { return shiftNumId; }
	set { if (this.shiftNumId != value){
			this.shiftNumId = value;
			Notify("ShiftNumId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CapShiftProfileDtlContainer CapShiftProfileDtlContainer {
	get { return capShiftProfileDtlContainer; }
	set { if (this.capShiftProfileDtlContainer != value){
			this.capShiftProfileDtlContainer = value;
			Notify("CapShiftProfileDtlContainer");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CapShiftProfileMachPlanContainer CapShiftProfileMachPlanContainer {
	get { return capShiftProfileMachPlanContainer; }
	set { if (this.capShiftProfileMachPlanContainer != value){
			this.capShiftProfileMachPlanContainer = value;
			Notify("CapShiftProfileMachPlanContainer");
		}
	}
}

public
int TotDirectPeople {
	get {
        int itotDirectPeople=0;

        for (int i=0;i < capShiftProfileDtlContainer.Count;i++){
            CapShiftProfileDtl capShiftProfileDtl = capShiftProfileDtlContainer[i];
            if (capShiftProfileDtl.DirIndShow.Equals(Constants.TASK_DIRECT))
                itotDirectPeople+= capShiftProfileDtl.NumPeople;
        }
        return itotDirectPeople;

    } set {             
			Notify("TotDirectPeople");		
	}
}


public
int TotIndirectPeople {
	get {
        int itotIndirectPeople=0;

        for (int i=0;i < capShiftProfileDtlContainer.Count;i++){
            CapShiftProfileDtl capShiftProfileDtl = capShiftProfileDtlContainer[i];
            if (capShiftProfileDtl.DirIndShow.Equals(Constants.TASK_INDIRECT))
                itotIndirectPeople+= capShiftProfileDtl.NumPeople;
        }
        return itotIndirectPeople;

    } set {             
			Notify("TotIndirectPeople");		
	}
}


public
decimal TotAvailableDirectHours {
	get {
        decimal dresult = 5 * 8 * TotDirectPeople; // 5(days on week mon to frid) x 8(hs for now) x 20(direct people)= 800
                
        return dresult;
    } set {             
        Notify("TotCalcHoursDirectPeople");		
	}
}
         
public
void fillRedundances(){
    this.ShiftType= ShiftNum > 3 ? Constants.SHIFT_TYPE_OVERTIME : Constants.SHIFT_TYPE_REGULAR;
    
    TotDirectPeople = TotDirectPeople;//recalc here just to show on screen info upgraded
    TotIndirectPeople = TotIndirectPeople;

    for (int i=0;i < capShiftProfileDtlContainer.Count;i++){
        CapShiftProfileDtl capShiftProfileDtl = capShiftProfileDtlContainer[i];
        
        capShiftProfileDtl.HdrId = this.id;        
        capShiftProfileDtl.Detail = i+1;
        capShiftProfileDtl.ShiftNumShow = this.ShiftNum;
    }    

    //only fill details with zero value which are new, because detail stored on CustomerPart link
    for (int i=0,imaxId= capShiftProfileMachPlanContainer.getMaxDetail(); i < capShiftProfileMachPlanContainer.Count;i++){
        CapShiftProfileMachPlan capShiftProfileMachPlan = capShiftProfileMachPlanContainer[i];        
        capShiftProfileMachPlan.HdrId = this.id;             

        if (capShiftProfileMachPlan.Detail <= 0) { 
            capShiftProfileMachPlan.Detail = imaxId + 1;        
            imaxId++;
        }
        capShiftProfileMachPlan.fillRedundances();
    }
}

public override
bool Equals(object obj){
	if (obj is CapShiftProfile)
		return	this.id.Equals(((CapShiftProfile)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
string StartDateString {
	get {
        string saux = DateUtil.getDateRepresentation(startDate,DateUtil.MMDDYYYY);
        return saux;
    }set {
        string saux = DateUtil.getDateRepresentation(startDate,DateUtil.MMDDYYYY);

        if (saux != value){                       
		    this.startDate = DateUtil.parseDate(value,DateUtil.MMDDYYYY);             
			Notify("StartDate");
            Notify("StartDateString");                    
		}
	}
}

public
string EndDateString {
	get {
        string saux = DateUtil.getDateRepresentation(endDate,DateUtil.MMDDYYYY);
        return saux;
    }set {
        string saux = DateUtil.getDateRepresentation(endDate, DateUtil.MMDDYYYY);

        if (saux != value){                       
		    this.endDate = DateUtil.parseDate(value,DateUtil.MMDDYYYY);             
			Notify("EndDate");
            Notify("EndDateString");                    
		}
	}
}

public
void setDayWork(DayOfWeek dayOfWeek,string svalue){
    switch(dayOfWeek){
        case DayOfWeek.Monday:      MonWork = svalue;break;
        case DayOfWeek.Tuesday:     TueWork = svalue;break;
        case DayOfWeek.Wednesday:   WedWork = svalue;break;
        case DayOfWeek.Thursday:    ThuWork = svalue;break;
        case DayOfWeek.Friday:      FriWork = svalue;break;
        case DayOfWeek.Saturday:    SatWork = svalue;break;
        case DayOfWeek.Sunday:      SunWork = svalue;break;       
    }
}

public
int getCountOfDaysWork(string svalue){
    int idays = 0;

    if (MonWork.Equals(svalue))
        idays++;
    if (TueWork.Equals(svalue))
        idays++;
    if (WedWork.Equals(svalue))
        idays++;
    if (ThuWork.Equals(svalue))
        idays++;
    if (FriWork.Equals(svalue))
        idays++;
    if (SatWork.Equals(svalue))
        idays++;
    if (SunWork.Equals(svalue))
        idays++;
    
    return idays;    
}

public
int getRemainsShifts(DateTime dateTime,string svalue){
    int         idays = 0;
    int         inumDayOfWeek   = DateUtil.getDayOfWeek(dateTime);
    DateTime    dateTimeStart   = DateTime.Now;                
    DateTime    dateTimeEnd     = DateTime.Now;

    try { dateTimeStart = DateUtil.parseDB2Time(ShiftStart, ':');   } catch { };
    try { dateTimeEnd   = DateUtil.parseDB2Time(ShiftEnd,   ':');   } catch { };

    if (ShiftEnd.CompareTo(ShiftStart) < 0)
        dateTimeEnd = dateTimeEnd.AddDays(1);
    
    if (MonWork.Equals(svalue) && (inumDayOfWeek > 1 && inumDayOfWeek <= 2)){ 
        idays++;
        if (inumDayOfWeek == 2 && dateTime > dateTimeStart)//check if shift hour already finished
            idays--;
    }
    if (TueWork.Equals(svalue) && (inumDayOfWeek > 1 && inumDayOfWeek <= 3)){ 
        idays++;
        if (inumDayOfWeek == 3 && dateTime > dateTimeStart)
            idays--;
    }
            
    if (WedWork.Equals(svalue) && (inumDayOfWeek > 1 && inumDayOfWeek <= 4)){ 
        idays++;
        if (inumDayOfWeek == 4 && dateTime > dateTimeStart)
            idays--;
    }     
    if (ThuWork.Equals(svalue) && (inumDayOfWeek > 1 && inumDayOfWeek <= 5)){ 
        idays++;
        if (inumDayOfWeek == 5 && dateTime > dateTimeStart)
            idays--;
    }     
    if (FriWork.Equals(svalue) && (inumDayOfWeek > 1 && inumDayOfWeek <= 6)){ 
        idays++;
        if (inumDayOfWeek == 6 && dateTime > dateTimeStart)
            idays--;
    }     
    if (SatWork.Equals(svalue) && (inumDayOfWeek > 1 && inumDayOfWeek <= 7)){ 
        idays++;
        if (inumDayOfWeek == 7 && dateTime > dateTimeStart)
            idays--;
    }     
        
    if (SunWork.Equals(svalue) && (inumDayOfWeek >= 1 && inumDayOfWeek <= 7)){ 
        idays++;
        if (inumDayOfWeek == 1 && dateTime > dateTimeStart)
            idays--;
    }     
        
    return idays;    
}



} // class
} // package