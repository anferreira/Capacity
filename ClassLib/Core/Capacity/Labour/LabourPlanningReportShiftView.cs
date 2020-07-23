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
class LabourPlanningReportShiftView : CapacityView {

private     DateTime  startDate;
private     DateTime  endDate;
private     decimal   dtotDirectLabour;  
ArrayList   arrayList;

public
LabourPlanningReportShiftView(): base(){
    this.startDate = DateUtil.MinValue;
    this.endDate = DateUtil.MinValue;
    this.dtotDirectLabour = 0;
    arrayList = new ArrayList();

    for (int i=0; i < Constants.MAX_SHIFTS; i++) { 
        CellPlanningLabType cellPlanningLabType = new CellPlanningLabType();
        cellPlanningLabType.ShiftNum=(i+1);
        arrayList.Add(cellPlanningLabType);
    }    
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
decimal TotDirectLabour{
	get { return dtotDirectLabour; }
	set { if (this.dtotDirectLabour != value){
			this.dtotDirectLabour = value;
			Notify("TotDirectLabour");
            Notify("TotalNet");
            Notify("TotDirectLabour");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal TotDirectLabourCeiling{
	get { return Convert.ToDecimal(Math.Ceiling(TotDirectLabour)); }
	set { 
        TotDirectLabour= value;
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

public
CellPlanningLabType getCellPlanningLabTypeByIndex(int index){
    CellPlanningLabType cellPlanningLabType = null;

    if (index>=0 && arrayList.Count > index)
        cellPlanningLabType = (CellPlanningLabType)arrayList[index];

    return cellPlanningLabType;
}

[System.Runtime.Serialization.DataMember]
public
decimal TotalShfits{
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

        foreach(CellPlanningLabType cellPlanningLabType in arrayList)
            dtot+= cellPlanningLabType.NewHire;  

        return  dtot;
    } set { 		
        Notify("TotalShfitsNewHire");
	}
}

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

} // class
} // package