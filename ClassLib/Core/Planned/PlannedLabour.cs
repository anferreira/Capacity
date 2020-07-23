/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.Planned{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class PlannedLabour : BusinessObject {

private int hdrId;
private int detail;
private int subDetail;
private int labourTypeId;
private decimal hours;
private decimal totEmployPlan;
private decimal totEmployOver;
private decimal totEmployTemp;        
private decimal totEmployHire;
private decimal totEmployVacation;
private decimal totEmployAbsent;
private int shiftNum;


private DateTime startDate;
private DateTime endDate;

#if !WEB
internal
#else
public
#endif
PlannedLabour(){
	this.hdrId = 0;
	this.detail = 0;
	this.subDetail = 0;
	this.labourTypeId = 0;
	this.hours = 0;
    this.totEmployPlan  = 
    this.totEmployOver  = 
    this.totEmployTemp  = 
    this.totEmployHire      =
    this.totEmployVacation  =
    this.totEmployAbsent    =0;
    this.shiftNum = 0;
    this.startDate = DateUtil.MinValue;
	this.endDate = DateUtil.MinValue;
}

internal
PlannedLabour(
	int hdrId,
	int detail,
	int subDetail,
	int labourTypeId,
	decimal hours,
    decimal totEmployPlan,
    decimal totEmployOver,
    decimal totEmployTemp,   
    decimal totEmployHire,
    decimal totEmployVacation,
    decimal totEmployAbsent, 
    int shiftNum,
    DateTime startDate,
	DateTime endDate){
	this.hdrId = hdrId;
	this.detail = detail;
	this.subDetail = subDetail;
	this.labourTypeId = labourTypeId;
	this.hours = hours;
    this.totEmployPlan= totEmployPlan;
    this.totEmployOver= totEmployOver;
    this.totEmployTemp= totEmployTemp;    

    this.totEmployHire      = totEmployHire;
    this.totEmployVacation  = totEmployVacation;
    this.totEmployAbsent    = totEmployAbsent;    
    this.shiftNum = shiftNum;
    this.startDate = startDate;
	this.endDate = endDate;
}

[System.Runtime.Serialization.DataMember]
public
int HdrId {
	get { return hdrId;}
	set { if (this.hdrId != value){
			this.hdrId = value;
			Notify("HdrId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int Detail {
	get { return detail;}
	set { if (this.detail != value){
			this.detail = value;
			Notify("Detail");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int SubDetail {
	get { return subDetail;}
	set { if (this.subDetail != value){
			this.subDetail = value;
			Notify("SubDetail");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int LabourTypeId {
	get { return labourTypeId;}
	set { if (this.labourTypeId != value){
			this.labourTypeId = value;
			Notify("LabourTypeId");
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
decimal TotEmployPlan {
	get { return totEmployPlan; }
	set { if (this.totEmployPlan != value){
			this.totEmployPlan = value;
			Notify("TotEmployPlan");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal TotEmployOver {
	get { return totEmployOver; }
	set { if (this.totEmployOver != value){
			this.totEmployOver = value;
			Notify("TotEmployOver");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal TotEmployTemp {
	get { return totEmployTemp; }
	set { if (this.totEmployTemp != value){
			this.totEmployTemp = value;
			Notify("TotEmployTemp");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal TotEmployHire {
	get { return totEmployHire; }
	set { if (this.totEmployHire != value){
			this.totEmployHire = value;
			Notify("TotEmployHire");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal TotEmployVacation {
	get { return totEmployVacation; }
	set { if (this.totEmployVacation != value){
			this.totEmployVacation = value;
			Notify("TotEmployVacation");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal TotEmployAbsent {
	get { return totEmployAbsent; }
	set { if (this.totEmployAbsent != value){
			this.totEmployAbsent = value;
			Notify("TotEmployAbsent");
		}
	}
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

public override
bool Equals(object obj){
	if (obj is PlannedLabour)
		return	this.hdrId.Equals(((PlannedLabour)obj).HdrId) &&
				this.detail.Equals(((PlannedLabour)obj).Detail) &&
				this.subDetail.Equals(((PlannedLabour)obj).SubDetail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(PlannedLabour plannedLabour){	
	this.HdrId=plannedLabour.HdrId;
	this.Detail=plannedLabour.Detail;
	this.SubDetail=plannedLabour.SubDetail;
	this.LabourTypeId=plannedLabour.LabourTypeId;
	this.Hours=plannedLabour.Hours;
    this.TotEmployPlan = plannedLabour.TotEmployPlan;
    this.TotEmployOver = plannedLabour.TotEmployOver;
    this.TotEmployTemp = plannedLabour.TotEmployTemp;

    this.TotEmployHire      = plannedLabour.TotEmployHire;
    this.TotEmployVacation  = plannedLabour.TotEmployVacation;
    this.TotEmployAbsent    = plannedLabour.TotEmployAbsent;       
    this.ShiftNum           = plannedLabour.ShiftNum;

    this.StartDate=plannedLabour.StartDate;
	this.EndDate=plannedLabour.EndDate;	
}

/*
public
decimal getTotEmployeesByRange(DateTime stD,DateTime endD){
    decimal dtotEmployee=0;

    if (betweenRange(stD,endD))
        dtotEmployee=totEmployees;

    return dtotEmployee;
}*/

public
bool betweenRange(DateTime stD,DateTime endD){
    bool    bresult=false;
    if (stD >= startDate && endD <= endDate)
        bresult=true;

    return bresult;
}

} // class
} // package