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
class CapProfileHoliday : BusinessObject {

private int id;
private string plant;
private DateTime startDate;
private DateTime endDate;
private string holidayType;

public const string HOLIDAY_TYPE_WEEKEND = "W";
public const string HOLIDAY_TYPE_HOLIDAY = "H";

#if !WEB
internal
#else
public
#endif
CapProfileHoliday(){
	this.id = 0;
    this.plant = "";
	this.startDate  = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,0,0,0);    
	this.endDate    = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,23,59,59);    
	this.holidayType = HOLIDAY_TYPE_HOLIDAY;
}

internal
CapProfileHoliday(
	int id,
    string plant,
    DateTime startDate,
	DateTime endDate,
	string holidayType)
{
	this.id = id;
    this.plant = plant;
    this.startDate = startDate;
	this.endDate = endDate;
	this.holidayType = holidayType;
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
string HolidayType {
	get { return holidayType;}
	set { if (this.holidayType != value){
			this.holidayType = value;
			Notify("HolidayType");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is CapProfileHoliday)
		return	this.id.Equals(((CapProfileHoliday)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package