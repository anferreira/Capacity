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
class LabourPlanningNewHireShift : BusinessObject {

private     DateTime    startDate;
private     DateTime    endDate;
private     decimal     remainsToDistribute;  
private     decimal     netDistribute;

private     LabourPlanningReportShiftViewContainer labourPlanningReportShiftViewContainer;

public
LabourPlanningNewHireShift(): base(){
    this.startDate = DateUtil.MinValue;
    this.endDate = DateUtil.MinValue;

    this.remainsToDistribute = 0;
    this.netDistribute = 0;

    labourPlanningReportShiftViewContainer = new LabourPlanningReportShiftViewContainer();
}

[System.Runtime.Serialization.DataMember]
public
DateTime StartDate{
	get { return startDate; }
	set { if (this.startDate != value){
			this.startDate = value;
			Notify("StartDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime EndDate{
	get { return endDate; }
	set { if (this.endDate != value){
			this.endDate = value;
			Notify("EndDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RemainsToDistribute{
	get { return remainsToDistribute; }
	set { if (this.remainsToDistribute != value){
			this.remainsToDistribute = value;
			Notify("RemainsToDistribute");
            Notify("NetDistribute");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal NetDistribute{
	get { return netDistribute; }
	set { if (this.netDistribute != value){
			this.netDistribute = value;
			Notify("NetDistribute");            
		}
	}
}


public
string SDate {
	get { return DateUtil.getDateRepresentation(StartDate,DateUtil.MMDDYYYY).Substring(0,5);}
	set { 
	}
}

public
string SProdWeek {
	get { return "Wk#" + DateUtil.weekNumber(StartDate).ToString("00");}
	set { 
	}
}      

public
string STitDate {
	get {
        return SDate + "\n" + SProdWeek;}
	set { 
	}
} 
        /*
[System.Runtime.Serialization.DataMember]
public
decimal TotalNewHires{
	get {
        decimal dtot =0;

        foreach(CellPlanningLabType cellPlanningLabType in arrayList)
            dtot+= cellPlanningLabType.Net;  

        return  dtot;
    } set { 		
        Notify("TotalShfits");
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal TotalShfitsNewHire{
	get {
        decimal dtot =0;

        foreach(LabourPlanningReportShiftView labourPlanningReportShiftView in labourPlanningReportShiftViewContainer) {         
            foreach(CellPlanningLabType cellPlanningLabType in labourPlanningReportShiftView.A)
                dtot+= cellPlanningLabType.NewHire;  
        }
        return  dtot;
    } set { 		
        Notify("TotalShfitsNewHire");
	}
}
        */
        /*
[System.Runtime.Serialization.DataMember]
public
decimal TotalNet{
	get {        
        return TotalShfits - TotDirectLabour;
    } set { 		
        Notify("TotalNet");
	}
}

public
void fillRedundances(){
    CellPlanningLabType cellPlanningLabType = null;
	
    for (int i=0; i < arrayList.Count; i++) {
        cellPlanningLabType = (CellPlanningLabType)arrayList[i];	

        cellPlanningLabType.StartDate=StartDate;
        cellPlanningLabType.EndDate=EndDate;		
	}
}

public
void recalcTotals(){
    TotalShfits = TotalShfits;
    TotalNet = TotalNet;
    TotalShfitsNewHire = TotalShfitsNewHire;
}

public
void clean(){
    CellPlanningLabType cellPlanningLabType = null;
	
    for (int i=0; i < arrayList.Count; i++) {
        cellPlanningLabType = (CellPlanningLabType)arrayList[i];	
        cellPlanningLabType.clean();        
           
	}
}
*/
} // class
} // package