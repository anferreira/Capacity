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
class ReportWeeksView : CapacityView {

public string name;
public string target;

private decimal weekPastDue;
private decimal week0;
private decimal week1;
private decimal week2;
private decimal week3;
private decimal week4;
private decimal week5;
private decimal week6;
private decimal week7;
private decimal week8;
private decimal week9;
private decimal week10;
private decimal week11;
private decimal week12;
private decimal week13;


public
ReportWeeksView(): base(){        
    this.name = "";
    this.target = "";

    this.weekPastDue =0;
    this.week0=0;
    this.week1=0;
    this.week2=0;
    this.week3=0;
    this.week4=0;
    this.week5=0;
    this.week6=0;
    this.week7=0;
    this.week8=0;
    this.week9=0;
    this.week10=0;
    this.week11=0;
    this.week12=0;
    this.week13=0;
}

[System.Runtime.Serialization.DataMember]
public
string Name {
	get { return name; }
	set { if (this.name != value){
			this.name = value;
			Notify("Name");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Target {
	get { return target; }
	set { if (this.target != value){
			this.target = value;
			Notify("Target");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal WeekPastDue {
	get { return weekPastDue; }
	set { if (this.weekPastDue != value){
			this.weekPastDue = value;
			Notify("WeekPastDue");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Week0 {
	get { return week0; }
	set { if (this.week0 != value){
			this.week0 = value;
			Notify("Week0");
		}
	}
}
        
[System.Runtime.Serialization.DataMember]
public
decimal Week1 {
	get { return week1; }
	set { if (this.week1 != value){
			this.week1 = value;
			Notify("Week1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Week2 {
	get { return week2; }
	set { if (this.week2 != value){
			this.week2 = value;
			Notify("Week2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Week3 {
	get { return week3; }
	set { if (this.week3 != value){
			this.week3 = value;
			Notify("Week3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Week4 {
	get { return week4; }
	set { if (this.week4 != value){
			this.week4 = value;
			Notify("Week4");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Week5 {
	get { return week5; }
	set { if (this.week5 != value){
			this.week5 = value;
			Notify("Week5");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Week6 {
	get { return week6; }
	set { if (this.week6 != value){
			this.week6 = value;
			Notify("Week6");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Week7 {
	get { return week7; }
	set { if (this.week7 != value){
			this.week7 = value;
			Notify("Week7");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Week8 {
	get { return week8; }
	set { if (this.week8 != value){
			this.week8 = value;
			Notify("Week8");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Week9 {
	get { return week9; }
	set { if (this.week9 != value){
			this.week9 = value;
			Notify("Week9");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Week10 {
	get { return week10; }
	set { if (this.week10 != value){
			this.week10 = value;
			Notify("Week10");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Week11 {
	get { return week11; }
	set { if (this.week11 != value){
			this.week11 = value;
			Notify("Week11");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Week12 {
	get { return week12; }
	set { if (this.week12 != value){
			this.week12 = value;
			Notify("Week12");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Week13 {
	get { return week13; }
	set { if (this.week13 != value){
			this.week13 = value;
			Notify("Week13");
		}
	}
}

public
void copy(CapacityView capacityView){
    base.copy(capacityView);    
}

public
void copy(MachineReportView machineReportView){
    base.copy(machineReportView);

    this.Name = machineReportView.Name;
    this.Target = machineReportView.Target;

    this.WeekPastDue = machineReportView.WeekPastDue;
    this.Week0 = machineReportView.Week0;
    this.Week1 = machineReportView.Week1;
    this.Week2 = machineReportView.Week2;
    this.Week3 = machineReportView.Week3;
    this.Week4 = machineReportView.Week4;
    this.Week5 = machineReportView.Week5;
    this.Week6 = machineReportView.Week6;
    this.Week7 = machineReportView.Week7;
    this.Week8 = machineReportView.Week8;
    this.Week9 = machineReportView.Week9;
    this.Week10 = machineReportView.Week10;
    this.Week11 = machineReportView.Week11;
    this.Week12 = machineReportView.Week12;
    this.Week13 = machineReportView.Week13;    
}

public
void sumWeek(){
    string  sweek = CapacityView.getTitleWeeekByDate(this.SDate);
    int     iweek =0;

    if (sweek.Equals(CapacityView.TITLE_PASTDUE)){        
        iweek = -1;
        weekPastDue = getCellValueNum();
    }
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"0")){        
        iweek=0;
        AvailableCapacity =  getHoursForSimpleCalcs(iweek);
        week0 = getCellValueNum();        
    }
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"1")){        
        iweek=1;
        AvailableCapacity =  getHoursForSimpleCalcs(iweek);
        week1 = getCellValueNum(); 
    }
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"2")){        
        iweek=2;
        AvailableCapacity =  getHoursForSimpleCalcs(iweek);
        week2 = getCellValueNum(); 
    }
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"3")){        
        iweek=3;
        AvailableCapacity =  getHoursForSimpleCalcs(iweek);
        week3 = getCellValueNum(); 
    }
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"4")){      
        iweek=4;
        AvailableCapacity =  getHoursForSimpleCalcs(iweek);
        week4 = getCellValueNum(); 
    }
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"5")){        
        iweek=5;
        AvailableCapacity =  getHoursForSimpleCalcs(iweek);
        week5 = getCellValueNum(); 
    }
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"6")){ 
        iweek=6;
        AvailableCapacity =  getHoursForSimpleCalcs(iweek);
        week6 = getCellValueNum(); 
    }
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"7")){        
        iweek=7;
        AvailableCapacity =  getHoursForSimpleCalcs(iweek);
        week7 = getCellValueNum();  
    }
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"8")){        
        iweek=8;
        AvailableCapacity =  getHoursForSimpleCalcs(iweek);
        week8 = getCellValueNum();  
    }
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"9")){    
        iweek=9;
        AvailableCapacity = getHoursForSimpleCalcs(iweek);
        week9 = getCellValueNum();  
    }
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"10")){        
        iweek=10;
        AvailableCapacity =  getHoursForSimpleCalcs(iweek);
        week10 = getCellValueNum();  
    }
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"11")){        
        iweek=11;
        AvailableCapacity =  getHoursForSimpleCalcs(iweek);
        week11 = getCellValueNum();  
    }
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"12")){        
        iweek=12;
        AvailableCapacity =  getHoursForSimpleCalcs(iweek);
        week12 = getCellValueNum();  
    }
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"13")){        
        iweek=13;
        AvailableCapacity =  getHoursForSimpleCalcs(iweek);
        week13 = getCellValueNum();  
    }            
}

        /*
public
void calcPercentage(CapacityViewContainer ){
    string sweek = CapacityView.getTitleWeeekByDate(this.SDate);
    AvailableCapacity = CapacityView.getHoursForSimpleCalcs(i);

    if (sweek.Equals(CapacityView.TITLE_PASTDUE))
        weekPastDue+=Hours;
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"0"))
        week0+=Hours;
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"1"))
        week1+=Hours;
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"2"))
        week2+=Hours;
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"3"))
        week3+=Hours;
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"4"))
        week4+=Hours;
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"5"))
        week5+=Hours; 
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"6"))
        week6+=Hours;     
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"7"))
        week7+=Hours;     
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"8"))
        week8+=Hours;     
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"9"))
        week9+=Hours;     
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"10"))
        week10+=Hours;     
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"11"))
        week11+=Hours;     
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"12"))
        week12+=Hours;     
    if (sweek.Equals(CapacityView.TITLE_WEEKNUM+"13"))
        week13+=Hours;     
}
*/

public
string getCellValue(decimal dvalue){
    string stext = "";
    string stextShowType = ((int)ShowType).ToString();

    switch (this.ShowType){
        case SHOW_TYPE.TYPE_NORMAL:
            stext = Convert.ToInt64(dvalue) + Constants.DEFAULT_SEP + stextShowType;
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

private
string getStringValue(decimal daux){     
    return daux.ToString("0.00") + Nujit.NujitERP.ClassLib.Common.Constants.DEFAULT_SEP + (int)this.ShowType;
}

public
string WSeekPastDue {
	get { return getStringValue(weekPastDue);}
	set { 		
	}
}

[System.Runtime.Serialization.DataMember]
public
string WSeek0 {
	get { return getStringValue(week0);}
	set { 		
	}
}

[System.Runtime.Serialization.DataMember]
public
string WSeek1 {
	get { return getStringValue(week1);}
	set { 		
	}
}

[System.Runtime.Serialization.DataMember]
public
string WSeek2 {
	get { return getStringValue(week2);}
	set { 	
	}
}

[System.Runtime.Serialization.DataMember]
public
string WSeek3 {
	get { return getStringValue(week3);}
	set { 	
	}
}

[System.Runtime.Serialization.DataMember]
public
string WSeek4 {
	get { return getStringValue(week4);}
	set { 	
	}
}

[System.Runtime.Serialization.DataMember]
public
string WSeek5 {
	get { return getStringValue(week5);}
	set { 	
	}
}

[System.Runtime.Serialization.DataMember]
public
string WSeek6 {
	get { return getStringValue(week6);}
	set { 	
	}
}

[System.Runtime.Serialization.DataMember]
public
string WSeek7 {
	get { return getStringValue(week7);}
	set { 	
	}
}

[System.Runtime.Serialization.DataMember]
public
string WSeek8 {
	get { return getStringValue(week8);}
	set { 	
	}
}

[System.Runtime.Serialization.DataMember]
public
string WSeek9 {
	get { return getStringValue(week9);}
	set { 	
	}
}

[System.Runtime.Serialization.DataMember]
public
string WSeek10 {
	get { return getStringValue(week10);}
	set { 	
	}
}

[System.Runtime.Serialization.DataMember]
public
string WSeek11 {
	get { return getStringValue(week11);}
	set { 	
	}
}

[System.Runtime.Serialization.DataMember]
public
string WSeek12 {
	get { return getStringValue(week12);}
	set { 	
	}
}

[System.Runtime.Serialization.DataMember]
public
string WSeek13 {
	get { return getStringValue(week13);}
	set { 	
	}
}

public
void setSameValues(decimal dvalue){
    weekPastDue=
    week0=
    week1=
    week2=
    week3=
    week4=
    week5=
    week6=
    week7=
    week8=
    week9=
    week10=
    week11=
    week12=
    week13= dvalue;
}

public
void setCellWeek(int icellIndex,decimal dvalue){ 
    switch(icellIndex){
        case    -1:    weekPastDue = dvalue;break;
        case    0:     week0 = dvalue;break;
        case    1:     week1 = dvalue;break;
        case    2:     week2 = dvalue;break;
        case    3:     week3 = dvalue;break;
        case    4:     week4 = dvalue;break;
        case    5:     week5 = dvalue;break;
        case    6:     week6 = dvalue;break;
        case    7:     week7 = dvalue;break;
        case    8:     week8 = dvalue;break;
        case    9:     week9 = dvalue;break;
        case    10:    week10 = dvalue;break;
        case    11:    week11 = dvalue;break;
        case    12:    week12 = dvalue;break;
        case    13:    week13 = dvalue;break;       
    }
}

public
void setSumCellWeek(int icellIndex,decimal dvalue){ 
    switch(icellIndex){
        case    -1:    weekPastDue+= dvalue;break;
        case    0:     week0 += dvalue;break;
        case    1:     week1 += dvalue;break;
        case    2:     week2 += dvalue;break;
        case    3:     week3 += dvalue;break;
        case    4:     week4 += dvalue;break;
        case    5:     week5 += dvalue;break;
        case    6:     week6 += dvalue;break;
        case    7:     week7 += dvalue;break;
        case    8:     week8 += dvalue;break;
        case    9:     week9 += dvalue;break;
        case    10:    week10 += dvalue;break;
        case    11:    week11 += dvalue;break;
        case    12:    week12 += dvalue;break;
        case    13:    week13 += dvalue;break;       
    }
}

public
decimal getCellWeek(int icellIndex){ 
    decimal dvalue = 0;
    switch(icellIndex){
        case    -1:    dvalue= weekPastDue; break;
        case    0:     dvalue= week0;break;
        case    1:     dvalue= week1;break;
        case    2:     dvalue= week2;break;
        case    3:     dvalue= week3;break;
        case    4:     dvalue= week4;break;
        case    5:     dvalue= week5;break;
        case    6:     dvalue= week6;break;
        case    7:     dvalue= week7;break;
        case    8:     dvalue= week8;break;
        case    9:     dvalue= week9;break;
        case    10:    dvalue= week10;break;
        case    11:    dvalue= week11;break;
        case    12:    dvalue= week12;break;
        case    13:    dvalue= week13;break;
    }
    return dvalue;
}

} // class
} // package