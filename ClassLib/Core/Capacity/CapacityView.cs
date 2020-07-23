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

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class CapacityView : CapacityViewBase {

private string title;
private decimal hours;
private DateTime sDate;
private decimal directHoursToShifts;

private SHOW_TYPE showType;
private decimal availableCapacity;

protected decimal hrsPerShift;
protected decimal stdShiftPerWeek;

public enum SHOW_TYPE : int {
	TYPE_NORMAL	= 0,
	TYPE_MACHSHIFTHOURS= 1,          
    CUMULATIVE_SHIFTS = 2,
    CUMULATIVE_MACHSHIFTHOURS= 3,
    PERCENTAGE = 4,
    CUMULATIVE_PERCENTAGE = 5,
    SCHEDULE_TIME  = 6,
    TYPE_TOTAL = 7 ,
    DEMAND = 8
}

public enum GENERIC_SHOW_TYPE : int {
	ALL	= 0,
	PERCENTAGES = 1
}

public enum SORT_TYPE : int {
	DEPT_REQUIRMENT	= 0,
    REQUIRMENT = 1
}

public const string TITLE_PASTDUE="PastDue";
public const string TITLE_WEEKNUM ="Week";
public const string TITLE_WEEK0   ="CurrWk";
public const int TITLE_COUNTS =13;

#if !WEB
internal
#else
public
#endif
CapacityView(): base(){    
	this.title = "";
	this.hours = 0;
	this.sDate = DateUtil.MinValue;
    this.directHoursToShifts=0;
    this.showType = SHOW_TYPE.TYPE_NORMAL;
    this.availableCapacity=0;
    this.hrsPerShift = (decimal)7.25;
    this.stdShiftPerWeek = ( 5 * 3); //5 days per 3 shift a day
}

internal
CapacityView(
	string plant,
	string dept,
    int reqId,
	string reqType,
	string machine,
	string labour,
	string tool,
	string title,
	decimal hours,
	DateTime sDate,
    decimal directHoursToShifts,
    decimal availableCapacity,
    decimal hrsPerShift,
    decimal stdShiftPerWeek) { //5 days per 3 shift a day) : base (plant,dept, reqId,reqType, machine,labour,tool){
	
	this.title = title;
	this.hours = hours;
	this.sDate = sDate;
    this.directHoursToShifts = directHoursToShifts;
    this.showType = SHOW_TYPE.TYPE_NORMAL;
    this.availableCapacity = availableCapacity;
    this.hrsPerShift = hrsPerShift;
    this.stdShiftPerWeek = stdShiftPerWeek;
}

[System.Runtime.Serialization.DataMember]
public
string Title {
	get { return title;}
	set { if (this.title != value){
			this.title = value;
			Notify("Title");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Hours {
	get { return hours;}
	set { if (this.hours != value){
			this.hours = value;
			Notify("Hours");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime SDate {
	get { return sDate;}
	set { if (this.sDate != value){
			this.sDate = value;
			Notify("SDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal DirectHoursToShifts {
	get { return directHoursToShifts; }
	set { if (this.directHoursToShifts != value){
			this.directHoursToShifts = value;
			Notify("DirectHoursToShifts");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
SHOW_TYPE ShowType {
	get { return showType; }
	set { if (this.showType != value){
			this.showType = value;
			Notify("ShowType");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal AvailableCapacity {
	get { return availableCapacity; }
	set { if (this.availableCapacity != value){
			this.availableCapacity = value;
			Notify("AvailableCapacity");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal HrsPerShift {
	get { return hrsPerShift; }
	set { if (this.hrsPerShift != value){
			this.hrsPerShift = value;
			Notify("HrsPerShift");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal StdShiftPerWeek {
	get { return stdShiftPerWeek; }
	set { if (this.stdShiftPerWeek != value){
			this.stdShiftPerWeek = value;
			Notify("StdShiftPerWeek");
		}
	}
}
        
public
string AllFields {
	get {              
        string sallFields = plant                   + Constants.DEFAULT_SEP +
                            dept                    + Constants.DEFAULT_SEP +
                            reqType                 + Constants.DEFAULT_SEP +

                            machine                 + Constants.DEFAULT_SEP +
                            labour                  + Constants.DEFAULT_SEP +
                            tool                    + Constants.DEFAULT_SEP +

                            title                   + Constants.DEFAULT_SEP +
                            Convert.ToString(hours) + Constants.DEFAULT_SEP +
                            DateUtil.getDateRepresentation(sDate, DateUtil.MMDDYYYY) + Constants.DEFAULT_SEP +

                            Convert.ToString(directHoursToShifts) + Constants.DEFAULT_SEP +
                            (int)showType           + Constants.DEFAULT_SEP;        
        return sallFields;
    } set { 
			Notify("AllFields");		
	}
}
     
public override
bool Equals(object obj){
	if (obj is CapacityView)
		return	this.plant.Equals(((CapacityView)obj).Plant) &&
				this.dept.Equals(((CapacityView)obj).Dept) &&
				this.reqType.Equals(((CapacityView)obj).ReqType) &&
				this.machine.Equals(((CapacityView)obj).Machine) &&
				this.labour.Equals(((CapacityView)obj).Labour) &&
				this.tool.Equals(((CapacityView)obj).Tool) &&
				this.title.Equals(((CapacityView)obj).Title);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
decimal getRecalcMachineShiftHours(){
    decimal     dresult=0;
    
    if (reqType.Equals(CapacityReq.REQUIREMENT_MACHINE)){        
        dresult = hours /  (directHoursToShifts != 0 ? directHoursToShifts : 8);                                
    }

    return dresult;
}

public
string getHourShowType(){
    return this.Hours.ToString("0.00") + Nujit.NujitERP.ClassLib.Common.Constants.DEFAULT_SEP + (int)this.ShowType;
}

public
string getRecalcMachineShiftHoursShowType(){
    return getRecalcMachineShiftHours().ToString("0.00") + Nujit.NujitERP.ClassLib.Common.Constants.DEFAULT_SEP + (int)this.ShowType;
}

public
decimal getCumulativePercentage(){
    decimal daux = 0;

    if (AvailableCapacity !=0)
        daux = (Hours / (AvailableCapacity !=0? AvailableCapacity : 1)) * 100;
    
    return daux;                        
}

public
string getCellValue(){
    string stext = "";

    switch(showType){
        case SHOW_TYPE.TYPE_NORMAL:
            stext = this.getHourShowType();
            break;
        case SHOW_TYPE.TYPE_MACHSHIFTHOURS:
        case SHOW_TYPE.CUMULATIVE_MACHSHIFTHOURS:
            stext = this.getRecalcMachineShiftHoursShowType();
            break;
        case SHOW_TYPE.TYPE_TOTAL:
            stext = this.getHourShowType();
            break;
        case SHOW_TYPE.CUMULATIVE_SHIFTS:
            stext = this.getHourShowType();
            break;
        case SHOW_TYPE.PERCENTAGE:
        case SHOW_TYPE.CUMULATIVE_PERCENTAGE:
            stext = getCumulativePercentage().ToString("0.00") + Nujit.NujitERP.ClassLib.Common.Constants.DEFAULT_SEP + (int)this.ShowType;                    
            break;
        case SHOW_TYPE.SCHEDULE_TIME:
            stext = this.getHourShowType();
            break;
    }

    return stext;        
}

public
decimal getCellValueNum(){
    decimal dvalue = 0;

    switch(showType){
        case SHOW_TYPE.TYPE_NORMAL:
            dvalue = this.Hours;
            break;
        case SHOW_TYPE.TYPE_MACHSHIFTHOURS:
        case SHOW_TYPE.CUMULATIVE_MACHSHIFTHOURS:
            dvalue = getRecalcMachineShiftHours();
            break;
        case SHOW_TYPE.TYPE_TOTAL:
            dvalue = this.Hours;
            break;
        case SHOW_TYPE.CUMULATIVE_SHIFTS:
            dvalue = this.Hours;
            break;
        case SHOW_TYPE.PERCENTAGE:
        case SHOW_TYPE.CUMULATIVE_PERCENTAGE:
            dvalue = getCumulativePercentage();                    
            break;
        case SHOW_TYPE.SCHEDULE_TIME:
            dvalue = this.Hours; 
            break;
    }

    return dvalue;        
}

public static
decimal getHoursForCumCalcs(int iweekNum,decimal dcumPercent){
    decimal dreturn = getHoursForCumCalcs(iweekNum);    

    return dreturn * (dcumPercent/100);
}

public static
decimal getHoursForCumCalcs(int iweekNum){
    decimal dreturn =0;    
    decimal dminutes= DateTime.Now.Minute!= 0 ? DateTime.Now.Minute :1; 
    decimal drestHoursDay = (24 - DateTime.Now.Hour) +  (decimal) 1 /  (dminutes * (100/60)); 
    decimal dcurrHoursWeek=0;
    decimal daysCount = DateUtil.getDayOfWeek(DateTime.Now);
   
    if (daysCount< 2 || daysCount> 6)
        daysCount= 0;
    else
        daysCount = 6 - daysCount;

    dcurrHoursWeek   = drestHoursDay + (24 * daysCount);

    dreturn = dcurrHoursWeek;
    if (iweekNum >= 1)
        dreturn+= ( (iweekNum * 5) * 24);

    return dreturn;
}

public 
decimal getHoursForSimpleCalcs(int iweekNum){
    decimal dnormalWeek   = (this.hrsPerShift * this.stdShiftPerWeek); //configurated on machine default
    decimal dreturn = iweekNum == 0 ? getHoursForCumCalcs(iweekNum) : dnormalWeek;    
    
    return dreturn;
}

public
void copy(CapacityView capacityView){ 
    base.copy(capacityView);            
	this.Title=capacityView.Title;
	this.Hours=capacityView.Hours;
	this.SDate=capacityView.SDate;
    this.DirectHoursToShifts=capacityView.DirectHoursToShifts;
    this.ShowType = capacityView.ShowType;
    this.AvailableCapacity = capacityView.AvailableCapacity;
} 


public static
ArrayList getArrayWeeeksByTitle(bool baddPastDue=true){ 
    ArrayList   arrayColumns = new ArrayList();
    string      sweeK= "";

    if (baddPastDue)
        arrayColumns.Add(CapacityView.TITLE_PASTDUE);//generate columns for Weeks/Title    
    for (int i=0; i <= CapacityView.TITLE_COUNTS;i++){
        sweeK= CapacityView.TITLE_WEEKNUM + i.ToString();
        arrayColumns.Add(sweeK);

    }
    return arrayColumns;
}

public static
string getTitleWeeekByDate(DateTime dateTime){ 
    ArrayList   arrayDateTimeWeek   = getDateTimeWeekList();
    ArrayList   arrayTitleWeek      = getArrayWeeeksByTitle();
    string      sweeK= "";
    DateTime    dateTimeWeek=DateTime.Now;
    DateTime    priorMonday = DateTime.Now;
    DateTime    nextSunday = DateTime.Now;
    
    for (int i=0; i < arrayDateTimeWeek.Count && string.IsNullOrEmpty(sweeK);i++){
        dateTimeWeek = (DateTime)arrayDateTimeWeek[i];
        if ( i == 0 ){
            if (dateTime <= dateTimeWeek)
                sweeK = (string)arrayTitleWeek[i];
        } else{
            DateUtil.getPriorMondayNextSundayFromDate(dateTimeWeek, out priorMonday, out nextSunday);
            if (dateTime >= priorMonday && dateTime <= nextSunday)
                sweeK = (string)arrayTitleWeek[i];
        }
    }
    return sweeK;
}

public static
string getTitleWeeekByDateInfinite(DateTime dateTime){ 
    string      sweeK= "";
    DateTime    dateTimeWeek=DateTime.Now;
    DateTime    priorMonday = DateTime.Now;
    DateTime    nextSunday  = DateTime.Now;
                
    DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now,out priorMonday,out nextSunday);
    if (dateTime < priorMonday)
        sweeK = TITLE_PASTDUE;

    for (int i=0; string.IsNullOrEmpty(sweeK);i++,priorMonday = priorMonday.AddDays(7)){
        DateUtil.getPriorMondayNextSundayFromDate(priorMonday,out priorMonday,out nextSunday);         
        if (dateTime>= priorMonday && dateTime<= nextSunday)
            sweeK = i == 0 ? TITLE_WEEK0 : TITLE_WEEKNUM + i.ToString();        
    }
    return sweeK;
}

public static
DateTime getDateWeeekByDate(DateTime dateTime){ 
    ArrayList   arrayDateTimeWeek   = getDateTimeWeekList();
    ArrayList   arrayTitleWeek      = getArrayWeeeksByTitle();    
    DateTime    dateTimeWeek=DateTime.Now;
    DateTime    priorMonday = DateTime.Now;
    DateTime    nextSunday = DateTime.Now;
    DateTime    dateReturn = DateUtil.MinValue;
    
    for (int i=0; i < arrayDateTimeWeek.Count && dateReturn == DateUtil.MinValue; i++){
        dateTimeWeek = (DateTime)arrayDateTimeWeek[i];
        if ( i == 0 ){
            if (dateTime <= dateTimeWeek)
                dateReturn = dateTimeWeek;
        } else{
            DateUtil.getPriorMondayNextSundayFromDate(dateTimeWeek, out priorMonday, out nextSunday);
            if (dateTime >= priorMonday && dateTime <= nextSunday)
                dateReturn = dateTimeWeek;
        }
    }
    return dateReturn;
}

public static
ArrayList getDateTimeWeekList(bool baddPastDue=true){ 
    ArrayList   arrayList = new ArrayList();
    DateTime    priorMonday = DateTime.Now;
    DateTime    nextSunday = DateTime.Now;
    DateTime    pastDue = DateTime.Now;        

    DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now, out pastDue, out nextSunday);        
    pastDue = nextSunday.AddDays(-7);        
    if (baddPastDue)        
        arrayList.Add(pastDue);
                           
    for (int j = 0; j <= CapacityView.TITLE_COUNTS; j++, priorMonday = priorMonday.AddDays(7)){
        DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);   
        arrayList.Add(priorMonday);
    }
    return arrayList;
}

public static
ArrayList getDateTimeWeekSundayList(bool baddPastDue=true){ 
    ArrayList   arrayList = new ArrayList();
    DateTime    priorMonday = DateTime.Now;
    DateTime    nextSunday = DateTime.Now;
    DateTime    pastDue = DateTime.Now;        

    DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now, out pastDue, out nextSunday);        
    pastDue = nextSunday.AddDays(-7);        
    if (baddPastDue)        
        arrayList.Add(pastDue);
                           
    for (int j = 0; j <= CapacityView.TITLE_COUNTS; j++, priorMonday = priorMonday.AddDays(7)){
        DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);   
        arrayList.Add(nextSunday);
    }
    return arrayList;
}

public static
ArrayList getArrayWeeeksBy2Titles(bool baddPastDue=true){
    ArrayList   arrayDateTimeWeek   = CapacityView.getDateTimeWeekList();
    ArrayList   arrayTitleWeek      = CapacityView.getArrayWeeeksByTitle();
    ArrayList   arrayReturn         = new ArrayList();    
    string      sline               = "";

    if (!baddPastDue){
        if (arrayDateTimeWeek.Count > 0)
            arrayDateTimeWeek.RemoveAt(0);
        if (arrayTitleWeek.Count > 0)
            arrayTitleWeek.RemoveAt(0);
    }

    for (int i=0; i < arrayDateTimeWeek.Count && i < arrayTitleWeek.Count;i++){
        sline = arrayTitleWeek[i] + "\n" + DateUtil.getDateRepresentation((DateTime)arrayDateTimeWeek[i], DateUtil.MMDDYYYY).Substring(0,5);
        arrayReturn.Add(sline);        
    }
    
    return arrayReturn;
}

public static 
void loadWeeksDates(    out DateTime dPastDue,
                        out DateTime dSweek0, out DateTime dEweek0,
                        out DateTime dSweek1, out DateTime dEweek1,
                        out DateTime dSweek2, out DateTime dEweek2,
                        out DateTime dSweek3, out DateTime dEweek3,
                        out DateTime dSweek4, out DateTime dEweek4,
                        out DateTime dSweek5, out DateTime dEweek5,
                        out DateTime dSweek6, out DateTime dEweek6,
                        out DateTime dSweek7, out DateTime dEweek7,
                        out DateTime dSweek8, out DateTime dEweek8,
                        out DateTime dSweek9, out DateTime dEweek9,
                        out DateTime dSweek10,out DateTime dEweek10,
                        out DateTime dSweek11,out DateTime dEweek11,
                        out DateTime dSweek12,out DateTime dEweek12,
                        out DateTime dSweek13,out DateTime dEweek13){

        dPastDue=
        dSweek0 = dEweek0 = 
        dSweek1 = dEweek1 = 
        dSweek2 = dEweek2 = 
        dSweek3 = dEweek3 = 
        dSweek4 = dEweek4 = 
        dSweek5 = dEweek5 = 
        dSweek6 = dEweek6 = 
        dSweek7 = dEweek7 = 
        dSweek8 = dEweek8 = 
        dSweek9 = dEweek9 = 
        dSweek10= dEweek10= 
        dSweek11= dEweek11= 
        dSweek12= dEweek12= 
        dSweek13= dEweek13= DateTime.Now;
        
        //dates
        DateTime    priorMonday = DateTime.Now;
        DateTime    nextSunday = DateTime.Now;
                
        DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now, out dPastDue, out nextSunday);        
        dPastDue = nextSunday.AddDays(-7);        
                                   
        for (int j = 0; j <= CapacityView.TITLE_COUNTS; j++, priorMonday = priorMonday.AddDays(7)){
            DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);   
        
            switch (j) { 
                case 0:    dSweek0 = priorMonday;  dEweek0 = nextSunday; break;
                case 1:    dSweek1 = priorMonday;  dEweek1 = nextSunday; break;
                case 2:    dSweek2 = priorMonday;  dEweek2 = nextSunday; break;                        
                case 3:    dSweek3 = priorMonday;  dEweek3 = nextSunday; break;
                case 4:    dSweek4 = priorMonday;  dEweek4 = nextSunday; break;
                case 5:    dSweek5 = priorMonday;  dEweek5 = nextSunday; break;                        
                case 6:    dSweek6 = priorMonday;  dEweek6 = nextSunday; break;
                case 7:    dSweek7 = priorMonday;  dEweek7 = nextSunday; break;
                case 8:    dSweek8 = priorMonday;  dEweek8 = nextSunday; break;                        
                case 9:    dSweek9 = priorMonday;  dEweek9 = nextSunday; break;
                case 10:   dSweek10 = priorMonday; dEweek10 = nextSunday; break;
                case 11:   dSweek11 = priorMonday; dEweek11 = nextSunday; break;
                case 12:   dSweek12 = priorMonday; dEweek12 = nextSunday; break;                        
                case 13:   dSweek13 = priorMonday; dEweek13 = nextSunday; break;                
            }            
        }
 }

} // class
} // package