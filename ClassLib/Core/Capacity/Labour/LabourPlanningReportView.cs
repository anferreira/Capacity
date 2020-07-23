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
class LabourPlanningReportView : CapacityView {

private string labName;
private string dirInd;
private CellPlanningLabType weekCellPastDue;
private CellPlanningLabType weekCell0;
private CellPlanningLabType weekCell1;
private CellPlanningLabType weekCell2;
private CellPlanningLabType weekCell3;
private CellPlanningLabType weekCell4;
private CellPlanningLabType weekCell5;
private CellPlanningLabType weekCell6;
private CellPlanningLabType weekCell7;
private CellPlanningLabType weekCell8;
private CellPlanningLabType weekCell9;
private CellPlanningLabType weekCell10;
private CellPlanningLabType weekCell11;
private CellPlanningLabType weekCell12;
private CellPlanningLabType weekCell13;

private CellTitles cellTitles;

public
LabourPlanningReportView(): base(){        
    this.labName = "";
    this.dirInd = "";
    this.weekCellPastDue = new CellPlanningLabType();
    this.weekCell0 = new CellPlanningLabType();
    this.weekCell1 = new CellPlanningLabType();
    this.weekCell2 = new CellPlanningLabType();
    this.weekCell3 = new CellPlanningLabType();
    this.weekCell4 = new CellPlanningLabType();
    this.weekCell5 = new CellPlanningLabType();
    this.weekCell6 = new CellPlanningLabType();
    this.weekCell7 = new CellPlanningLabType();
    this.weekCell8 = new CellPlanningLabType();
    this.weekCell9 = new CellPlanningLabType();
    this.weekCell10 = new CellPlanningLabType();
    this.weekCell11 = new CellPlanningLabType();
    this.weekCell12 = new CellPlanningLabType();
    this.weekCell13 = new CellPlanningLabType();   
    loadStartEndDates();             

    this.cellTitles = new CellTitles();  
    this.cellTitles.Title1 = "Required";
    this.cellTitles.Title2 = "Planned";
    this.cellTitles.Title3 = "Temp";        

    this.cellTitles.Title4 = "New Hires";                
    this.cellTitles.Title5 = "Vacation";                    
    this.cellTitles.Title6 = "Sick Absent";                    
    this.cellTitles.Title7 = "Over Time";        
    this.cellTitles.Title8 = "Net";    // (Planned + Overtime + Temp + NewHire) - Required - SickAbsent - Vacation; 
}

[System.Runtime.Serialization.DataMember]
public
string LabName {
	get { return labName;}
	set { if (this.labName != value){
			this.labName = value;
			Notify("LabName");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string DirInd {
	get { return dirInd;}
	set { if (this.dirInd != value){
			this.dirInd = value;
			Notify("DirInd");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanningLabType WeekCellPastDue{
	get { return weekCellPastDue; }
	set { if (this.weekCellPastDue != value){
			this.weekCellPastDue = value;
			Notify("WeekCellPastDue");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanningLabType WeekCell0 {
	get { return weekCell0; }
	set { if (this.weekCell0 != value){
			this.weekCell0 = value;
			Notify("WeekCell0");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanningLabType WeekCell1 {
	get { return weekCell1; }
	set { if (this.weekCell1 != value){
			this.weekCell1 = value;
			Notify("WeekCell1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanningLabType WeekCell2 {
	get { return weekCell2; }
	set { if (this.weekCell2 != value){
			this.weekCell2 = value;
			Notify("WeekCell2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanningLabType WeekCell3 {
	get { return weekCell3; }
	set { if (this.weekCell3 != value){
			this.weekCell3 = value;
			Notify("WeekCell3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanningLabType WeekCell4 {
	get { return weekCell4; }
	set { if (this.weekCell4 != value){
			this.weekCell4 = value;
			Notify("WeekCell4");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanningLabType WeekCell5 {
	get { return weekCell5; }
	set { if (this.weekCell5 != value){
			this.weekCell5 = value;
			Notify("WeekCell5");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanningLabType WeekCell6 {
	get { return weekCell6; }
	set { if (this.weekCell6 != value){
			this.weekCell6 = value;
			Notify("WeekCell6");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanningLabType WeekCell7 {
	get { return weekCell7; }
	set { if (this.weekCell7 != value){
			this.weekCell7 = value;
			Notify("WeekCell7");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanningLabType WeekCell8 {
	get { return weekCell8; }
	set { if (this.weekCell8 != value){
			this.weekCell8 = value;
			Notify("WeekCell8");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanningLabType WeekCell9 {
	get { return weekCell9; }
	set { if (this.weekCell9 != value){
			this.weekCell9 = value;
			Notify("WeekCell9");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanningLabType WeekCell10 {
	get { return weekCell10; }
	set { if (this.weekCell10 != value){
			this.weekCell10 = value;
			Notify("WeekCell10");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanningLabType WeekCell11 {
	get { return weekCell11; }
	set { if (this.weekCell11 != value){
			this.weekCell11 = value;
			Notify("WeekCell11");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanningLabType WeekCell12 {
	get { return weekCell12; }
	set { if (this.weekCell12 != value){
			this.weekCell12 = value;
			Notify("WeekCell12");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellPlanningLabType WeekCell13 {
	get { return weekCell13; }
	set { if (this.weekCell13 != value){
			this.weekCell13 = value;
			Notify("WeekCell13");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellTitles CellTitles {
	get { return cellTitles; }
	set { if (this.cellTitles != value){
			this.cellTitles = value;
			Notify("CellTitles");
		}
	}
}

public
void loadStartEndDates(){
    DateTime dPastDue = DateTime.Now;
    DateTime dSweek0 = DateTime.Now, dEweek0 = DateTime.Now;//weeks from/monday  - to/sunday
    DateTime dSweek1 = DateTime.Now, dEweek1 = DateTime.Now;
    DateTime dSweek2 = DateTime.Now, dEweek2 = DateTime.Now;
    DateTime dSweek3 = DateTime.Now, dEweek3 = DateTime.Now;
    DateTime dSweek4 = DateTime.Now, dEweek4 = DateTime.Now;
    DateTime dSweek5 = DateTime.Now, dEweek5 = DateTime.Now;
    DateTime dSweek6 = DateTime.Now, dEweek6 = DateTime.Now;
    DateTime dSweek7 = DateTime.Now, dEweek7 = DateTime.Now;
    DateTime dSweek8 = DateTime.Now, dEweek8 = DateTime.Now;
    DateTime dSweek9 = DateTime.Now, dEweek9 = DateTime.Now;
    DateTime dSweek10 = DateTime.Now, dEweek10 = DateTime.Now;
    DateTime dSweek11 = DateTime.Now, dEweek11 = DateTime.Now;
    DateTime dSweek12 = DateTime.Now, dEweek12 = DateTime.Now;
    DateTime dSweek13 = DateTime.Now, dEweek13 = DateTime.Now;
    
    CapacityView.loadWeeksDates(out  dPastDue,
                                out  dSweek0, out  dEweek0,
                                out  dSweek1, out  dEweek1,
                                out  dSweek2, out  dEweek2,
                                out  dSweek3, out  dEweek3,
                                out  dSweek4, out  dEweek4,
                                out  dSweek5, out  dEweek5,
                                out  dSweek6, out  dEweek6,
                                out  dSweek7, out  dEweek7,
                                out  dSweek8, out  dEweek8,
                                out  dSweek9, out  dEweek9,
                                out  dSweek10,out  dEweek10,
                                out  dSweek11,out  dEweek11,
                                out  dSweek12,out  dEweek12,
                                out  dSweek13,out  dEweek13);
    
    weekCellPastDue.StartDate   = dPastDue;
    weekCellPastDue.EndDate     = dPastDue;
    
    WeekCell0.StartDate   = dSweek0;
    WeekCell0.EndDate     = dEweek0;
                
    WeekCell1.StartDate   = dSweek1;
    WeekCell1.EndDate     = dEweek1;
    
    WeekCell2.StartDate   = dSweek2;
    WeekCell2.EndDate     = dEweek2;
    
    WeekCell3.StartDate   = dSweek3;
    WeekCell3.EndDate     = dEweek3;
    
    WeekCell4.StartDate   = dSweek4;
    WeekCell4.EndDate     = dEweek4;
    
    WeekCell5.StartDate   = dSweek5;
    WeekCell5.EndDate     = dEweek5;
    
    WeekCell6.StartDate   = dSweek6;
    WeekCell6.EndDate     = dEweek6;
    
    WeekCell7.StartDate   = dSweek7;
    WeekCell7.EndDate     = dEweek7;
    
    WeekCell8.StartDate   = dSweek8;
    WeekCell8.EndDate     = dEweek8;
    
    WeekCell9.StartDate   = dSweek9;
    WeekCell9.EndDate     = dEweek9;
    
    WeekCell10.StartDate   = dSweek10;
    WeekCell10.EndDate     = dEweek10;
                
    WeekCell11.StartDate   = dSweek11;
    WeekCell11.EndDate     = dEweek11;
    
    WeekCell12.StartDate   = dSweek12;
    WeekCell12.EndDate     = dEweek12;
    
    WeekCell13.StartDate   = dSweek13;
    WeekCell13.EndDate     = dEweek13;    
}

public
CellPlanningLabType getCellWeekByDate(DateTime startDate,DateTime endDate,bool bincludePastDue){
    CellPlanningLabType cellPlanningLabType = null;

    if (endDate <= weekCellPastDue.EndDate){ 
        if (bincludePastDue)
            cellPlanningLabType=weekCellPastDue;
    }else if (startDate >= weekCell0.StartDate && endDate <= weekCell0.EndDate)
        cellPlanningLabType= weekCell0;
    else if (startDate >= weekCell1.StartDate && endDate <= weekCell1.EndDate)
        cellPlanningLabType= weekCell1;
    else if (startDate >= weekCell2.StartDate && endDate <= weekCell2.EndDate)
        cellPlanningLabType= weekCell2;
    else if (startDate >= weekCell3.StartDate && endDate <= weekCell3.EndDate)
        cellPlanningLabType= weekCell3;
    else if (startDate >= weekCell4.StartDate && endDate <= weekCell4.EndDate)
        cellPlanningLabType= weekCell4;
    else if (startDate >= weekCell5.StartDate && endDate <= weekCell5.EndDate)
        cellPlanningLabType= weekCell5;
    else if (startDate >= weekCell6.StartDate && endDate <= weekCell6.EndDate)
        cellPlanningLabType= weekCell6;
    else if (startDate >= weekCell7.StartDate && endDate <= weekCell7.EndDate)
        cellPlanningLabType= weekCell7;
    else if (startDate >= weekCell8.StartDate && endDate <= weekCell8.EndDate)
        cellPlanningLabType= weekCell8;
    else if (startDate >= weekCell9.StartDate && endDate <= weekCell9.EndDate)
        cellPlanningLabType= weekCell9;
    else if (startDate >= weekCell10.StartDate && endDate <= weekCell10.EndDate)
        cellPlanningLabType= weekCell10;
    else if (startDate >= weekCell11.StartDate && endDate <= weekCell11.EndDate)
        cellPlanningLabType= weekCell11;
    else if (startDate >= weekCell12.StartDate && endDate <= weekCell12.EndDate)
        cellPlanningLabType= weekCell12;
    else if (startDate >= weekCell13.StartDate && endDate <= weekCell13.EndDate)
        cellPlanningLabType= weekCell13;

    return cellPlanningLabType;
}

public
void summarizeAll(LabourPlanningReportView labourPlanningReportView){                
    summarizeWeekCell(WeekCellPastDue, labourPlanningReportView.WeekCellPastDue);
    summarizeWeekCell(WeekCell0, labourPlanningReportView.WeekCell0);
    summarizeWeekCell(WeekCell1, labourPlanningReportView.WeekCell1);
    summarizeWeekCell(WeekCell2, labourPlanningReportView.WeekCell2);
    summarizeWeekCell(WeekCell3, labourPlanningReportView.WeekCell3);
    summarizeWeekCell(WeekCell4, labourPlanningReportView.WeekCell4);
    summarizeWeekCell(WeekCell5, labourPlanningReportView.WeekCell5);
    summarizeWeekCell(WeekCell6, labourPlanningReportView.WeekCell6);
    summarizeWeekCell(WeekCell7, labourPlanningReportView.WeekCell7);
    summarizeWeekCell(WeekCell8, labourPlanningReportView.WeekCell8);
    summarizeWeekCell(WeekCell9, labourPlanningReportView.WeekCell9);
    summarizeWeekCell(WeekCell10, labourPlanningReportView.WeekCell10);
    summarizeWeekCell(WeekCell11, labourPlanningReportView.WeekCell11);
    summarizeWeekCell(WeekCell12, labourPlanningReportView.WeekCell12);
    summarizeWeekCell(WeekCell13, labourPlanningReportView.WeekCell13);    
}

public
void summarizeWeekCell(CellPlanningLabType cellPlanningLabType,CellPlanningLabType cellPlanningLabTypeAux){
    cellPlanningLabType.Required+= cellPlanningLabTypeAux.Required;
    cellPlanningLabType.Planned += cellPlanningLabTypeAux.Planned;
    cellPlanningLabType.Temp+= cellPlanningLabTypeAux.Temp;
    cellPlanningLabType.NewHire += cellPlanningLabTypeAux.NewHire;
    cellPlanningLabType.SickAbsent += cellPlanningLabTypeAux.SickAbsent;
    cellPlanningLabType.Overtime += cellPlanningLabTypeAux.Overtime;            

    foreach(PlannedLabour plannedLabour in cellPlanningLabTypeAux.PlannedLabourContainer)
        cellPlanningLabType.PlannedLabourContainer.Add(plannedLabour);
}

} // class
} // package