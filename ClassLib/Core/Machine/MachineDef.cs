/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;

using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.Core.Machines{

#if !POCKET_PC
    [System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class MachineDef : BusinessObject {

private int machId;
private decimal planRunHrs;
private decimal hrsPerShift;
private decimal planDownHrs;
private decimal planChanOvHrs;
private decimal stdShiftPerWeek;
private decimal unitChanOverTime;
private decimal directHoursToShifts;
private decimal oee;
private decimal perfOa;
private decimal scrapRate;
private decimal netPressRate;
private decimal weeklyCapacity;
private decimal downHrsPerShift;
private string  showOnTvReport;
private DateTime dateLastPlanned;

private string machShow="";
private string machDes1Show="";

#if !WEB
internal
#else
public
#endif
MachineDef(){
	this.machId = 0;
	this.planRunHrs = 0;
	this.hrsPerShift = 0;
	this.planDownHrs = 0;
	this.planChanOvHrs = 0;
	this.stdShiftPerWeek = 0;
	this.unitChanOverTime = 0;
	this.directHoursToShifts = 0;
	this.oee = 0;
	this.perfOa = 0;
	this.scrapRate = 0;
	this.netPressRate = 0;
    this.weeklyCapacity =0;
    this.downHrsPerShift = 0;
    this.showOnTvReport = Constants.STRING_YES;
    this.dateLastPlanned = DateUtil.MinValue;
}

internal
MachineDef(
	int machId,
	decimal planRunHrs,
	decimal hrsPerShift,
	decimal planDownHrs,
	decimal planChanOvHrs,
	decimal stdShiftPerWeek,
	decimal unitChanOverTime,
	decimal directHoursToShifts,
	decimal oee,
	decimal perfOa,
	decimal scrapRate,
	decimal netPressRate,
    decimal weeklyCapacity,
    decimal downHrsPerShift,
    string showOnTvReport,
    DateTime dateLastPlanned){
	this.machId = machId;
	this.planRunHrs = planRunHrs;
	this.hrsPerShift = hrsPerShift;
	this.planDownHrs = planDownHrs;
	this.planChanOvHrs = planChanOvHrs;
	this.stdShiftPerWeek = stdShiftPerWeek;
	this.unitChanOverTime = unitChanOverTime;
	this.directHoursToShifts = directHoursToShifts;
	this.oee = oee;
	this.perfOa = perfOa;
	this.scrapRate = scrapRate;
	this.netPressRate = netPressRate;
    this.weeklyCapacity = weeklyCapacity;
    this.downHrsPerShift = downHrsPerShift;
    this.showOnTvReport = showOnTvReport;
    this.dateLastPlanned = dateLastPlanned;
}

[System.Runtime.Serialization.DataMember]
public
int MachId {
	get { return machId;}
	set { if (this.machId != value){
			this.machId = value;
			Notify("MachId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal PlanRunHrs {
	get { return planRunHrs;}
	set { if (this.planRunHrs != value){
			this.planRunHrs = value;
			Notify("PlanRunHrs");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal HrsPerShift {
	get { return hrsPerShift;}
	set { if (this.hrsPerShift != value){
			this.hrsPerShift = value;
			Notify("HrsPerShift");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal PlanDownHrs {
	get { return planDownHrs;}
	set { if (this.planDownHrs != value){
			this.planDownHrs = value;
			Notify("PlanDownHrs");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal PlanChanOvHrs {
	get { return planChanOvHrs;}
	set { if (this.planChanOvHrs != value){
			this.planChanOvHrs = value;
			Notify("PlanChanOvHrs");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal StdShiftPerWeek {
	get { return stdShiftPerWeek;}
	set { if (this.stdShiftPerWeek != value){
			this.stdShiftPerWeek = value;
			Notify("StdShiftPerWeek");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal UnitChanOverTime {
	get { return unitChanOverTime;}
	set { if (this.unitChanOverTime != value){
			this.unitChanOverTime = value;
			Notify("UnitChanOverTime");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal DirectHoursToShifts {
	get { return directHoursToShifts;}
	set { if (this.directHoursToShifts != value){
			this.directHoursToShifts = value;
			Notify("DirectHoursToShifts");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Oee {
	get { return oee;}
	set { if (this.oee != value){
			this.oee = value;
			Notify("Oee");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal PerfOa {
	get { return perfOa;}
	set { if (this.perfOa != value){
			this.perfOa = value;
			Notify("PerfOa");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal ScrapRate {
	get { return scrapRate;}
	set { if (this.scrapRate != value){
			this.scrapRate = value;
			Notify("ScrapRate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal NetPressRate {
	get { return netPressRate;}
	set { if (this.netPressRate != value){
			this.netPressRate = value;
			Notify("NetPressRate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal WeeklyCapacity {
	get { return weeklyCapacity; }
	set { if (this.weeklyCapacity != value){
			this.weeklyCapacity = value;
			Notify("WeeklyCapacity");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal DownHrsPerShift {
	get { return downHrsPerShift; }
	set { if (this.downHrsPerShift != value){
			this.downHrsPerShift = value;
			Notify("DownHrsPerShift");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ShowOnTvReport {
	get { return showOnTvReport; }
	set { if (this.showOnTvReport != value){
			this.showOnTvReport = value;
			Notify("ShowOnTvReport");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime DateLastPlanned {
	get { return dateLastPlanned; }
	set { if (this.dateLastPlanned != value){
			this.dateLastPlanned = value;
			Notify("DateLastPlanned");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MachShow {
	get { return machShow; }
	set { if (this.machShow != value){
			this.machShow = value;
			Notify("MachShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MachDes1Show {
	get { return machDes1Show; }
	set { if (this.machDes1Show != value){
			this.machDes1Show = value;
			Notify("MachDes1Show");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is MachineDef)
		return	this.machId.Equals(((MachineDef)obj).MachId);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package