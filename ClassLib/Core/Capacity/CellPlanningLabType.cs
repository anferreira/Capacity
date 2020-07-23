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
using Nujit.NujitERP.ClassLib.Core.Planned;

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class CellPlanningLabType : CellMachinePart {

private int shiftNum;
private decimal temp;
private decimal overtime;
private decimal newHire;
private decimal vacation;
private decimal sickAbsent;
private decimal daysPerWeek;


private PlannedLabourContainer plannedLabourContainer;

public
CellPlanningLabType(): base(){            
    this.shiftNum = 0;
    this.temp = 0;
    this.overtime = 0;
    this.newHire =0;
    this.vacation=0;
    this.sickAbsent =0;
    this.daysPerWeek = 5;
    this.plannedLabourContainer = new PlannedLabourContainer();
}

[System.Runtime.Serialization.DataMember]
public
int ShiftNum {
	get { return shiftNum; }
	set { if (this.shiftNum != value){
			this.shiftNum = value;
			Notify("ShiftNum");                        
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Temp {
	get { return temp; }
	set { if (this.temp != value){
			this.temp = value;
			Notify("Temp");            
            Notify("Net");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Overtime {
	get { return overtime; }
	set { if (this.overtime != value){
			this.overtime = value;            
			Notify("Overtime");       
            Notify("Net");                                
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal NewHire {
	get { return newHire; }
	set { if (this.newHire != value){
			this.newHire = value;            
			Notify("NewHire");       
            Notify("Net");                                
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Vacation {
	get { return vacation; }
	set { if (this.vacation != value){
			this.vacation = value;            
			Notify("Vacation");       
            Notify("Net");                                
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal SickAbsent {
	get { return sickAbsent; }
	set { if (this.sickAbsent != value){
			this.sickAbsent = value;            
			Notify("SickAbsent");       
            Notify("Net");                                
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal DaysPerWeek {
	get { return daysPerWeek; }
	set { if (this.daysPerWeek != value){
			this.daysPerWeek = value;            
			Notify("DaysPerWeek");                   
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Net {
	get {    
        //Required - Planned + temp + New Hires - Vacations - Sicks = Net                 
        //net = (Planned + Overtime + Temp) - Required;                         
        net = (Planned + Overtime + Temp + NewHire) - Required - SickAbsent - Vacation;                         
        return  net;
    } set { if (this.net != value){
			this.net = value;
			Notify("Net");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
PlannedLabourContainer PlannedLabourContainer{
	get {                   
        return  plannedLabourContainer;
    } set { 
			this.plannedLabourContainer = value;
			Notify("PlannedLabourContainer");		
	}
}

public
void loadTotValuesBasedLabourContainer(){
    foreach(PlannedLabour plannedLabour in plannedLabourContainer){
        Planned+=   plannedLabour.TotEmployPlan;
        Temp+=      plannedLabour.TotEmployTemp;
        Overtime+=  plannedLabour.TotEmployOver;
        NewHire+=   plannedLabour.TotEmployHire;
        Vacation+=  plannedLabour.TotEmployVacation;
        SickAbsent+=plannedLabour.TotEmployAbsent;             
    }
}

public
void clean(){
    plannedLabourContainer.Clear();    
    Planned=
    Temp =
    Overtime =
    NewHire =
    Vacation =
    SickAbsent = 0;        
}

} // class
} // package