using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Util;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.WinForms.Reports;
using Nujit.NujitERP.ClassLib.Reports.HotList;


namespace Nujit.NujitERP.WinForms.Reports.HotList_Report{


public
class HotListBomReport : GenericReport {

private rptHotListBomMartinRea rpt = null;
private rptHotListBom rpt2 = null;

private string title = "";
private bool noZeros;
private bool lessDays;

public 
HotListBomReport(DataSet dataSet, string title, bool isHoursReport, bool labourReport, 
		bool noZeros, string generated, string exploded, bool hotListBom, bool lessDays) : base(dataSet, "Hot List", lessDays){

	this.title = title;
	this.noZeros = noZeros;
	this.lessDays = lessDays;

	if (lessDays)
	{
		rpt = new rptHotListBomMartinRea();
		rpt.setGenerated(generated);
		rpt.setExploded(exploded);
		rpt.setHoursPartsHL(isHoursReport);
		rpt.setLabourReport(labourReport);
		rpt.setNonZeroes(noZeros);
		rpt.SetTitle(title);
		rpt.setBomReport(hotListBom);
	}
	else
	{
		rpt2 = new rptHotListBom();
		rpt2.setGenerated(generated);
		rpt2.setExploded(exploded);
		rpt2.setHoursPartsHL(isHoursReport);
		rpt2.setLabourReport(labourReport);
		rpt2.setNonZeroes(noZeros);
		rpt2.SetTitle(title);
		rpt2.setBomReport(hotListBom);
	}

	this.runReport();
}

public 
HotListBomReport(DataSet dataSet, string title, bool accumOnFridays, bool isHoursReport, 
		bool labourReport, bool noZeros, string generated, string exploded,
		bool hotListBom, bool lessDays) : base(dataSet, "Hot List", lessDays){

	this.title = title;
	this.noZeros = noZeros;
	this.lessDays = lessDays;

	if (lessDays)
	{
		rpt = new rptHotListBomMartinRea();
		rpt.setGenerated(generated);
		rpt.setExploded(exploded);
		rpt.setAccumOnFridays(accumOnFridays);
		rpt.setHoursPartsHL(isHoursReport);
		rpt.setLabourReport(labourReport);
		rpt.setNonZeroes(noZeros);
		rpt.SetTitle(title);
		rpt.setBomReport(hotListBom);
	}
	else
	{
		rpt2 = new rptHotListBom();
		rpt2.setGenerated(generated);
		rpt2.setExploded(exploded);
		rpt2.setAccumOnFridays(accumOnFridays);
		rpt2.setHoursPartsHL(isHoursReport);
		rpt2.setLabourReport(labourReport);
		rpt2.setNonZeroes(noZeros);
		rpt2.SetTitle(title);
		rpt2.setBomReport(hotListBom);
	}

	this.runReport();
}

protected override 
ActiveReport3 getActiveReport(bool lessDays){
	ActiveReport3 rptAux = null;

	if (lessDays)
	{
		rpt.DataMember = "hotListReport";
		rptAux = rpt;
	}
	else
	{
		rpt2.DataMember = "hotListReport";
		rptAux = rpt2;
	}

	return rptAux;
}

protected override 
void runReport(){
	if (lessDays)
		rpt.Run();
	else
		rpt2.Run();
}

	
} // class

} // namespace
