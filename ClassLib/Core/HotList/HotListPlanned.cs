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

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class HotListPlanned : HotList {

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
HotListPlanned(): base(){        
    
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
void setWeek(int index,decimal dvalue){
    switch (index) {
        case -1: pastDue= dvalue;break;
        case 0 : week0  = dvalue;break;
        case 1 : week1  = dvalue;break;
        case 2 : week2  = dvalue;break;
        case 3 : week3  = dvalue;break;
        case 4 : week4  = dvalue;break;
        case 5 : week5  = dvalue;break;
        case 6 : week6  = dvalue;break;
        case 7 : week7  = dvalue;break;
        case 8 : week8  = dvalue;break;
        case 9 : week9  = dvalue;break;
        case 10: week10 = dvalue;break;
        case 11: week11 = dvalue;break;
        case 12: week12 = dvalue;break;
        case 13: week13 = dvalue;break;        
    }
}

public
void copy(HotListPlanned hotListPlanned){
    this.WeekPastDue= hotListPlanned.WeekPastDue;
    this.Week0= hotListPlanned.Week0;
    this.Week1= hotListPlanned.Week1;
    this.Week2= hotListPlanned.Week2;
    this.Week3= hotListPlanned.Week3;
    this.Week4= hotListPlanned.Week4;
    this.Week5= hotListPlanned.Week5;
    this.Week6= hotListPlanned.Week6;
    this.Week7= hotListPlanned.Week7;
    this.Week8= hotListPlanned.Week7;
    this.Week9= hotListPlanned.Week8;
    this.Week10= hotListPlanned.Week10;
    this.Week11= hotListPlanned.Week11;
    this.Week12= hotListPlanned.Week12;
    this.Week13= hotListPlanned.Week13;

    base.copy(hotListPlanned);
}

} // class
} // package