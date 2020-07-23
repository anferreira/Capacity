using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Util;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.WinForms.Reports;
using Nujit.NujitERP.ClassLib.Reports.HotList;


namespace Nujit.NujitERP.WinForms.Reports.HotList_Report{


public
class HotListReportByMGroupMainMat : GenericReport{

private rptHotListMinGroupMMMartinRea rptHotListMinGroupMM = new rptHotListMinGroupMMMartinRea();
private rptHotListMinGroupMM rptHotListMinGroupMM2 = new rptHotListMinGroupMM();

private bool noZeros = false;
private string title = "";
private bool lessDays;

public 
HotListReportByMGroupMainMat(DataSet dataSet, string title, bool isHoursReport,
			bool labourReport, bool noZeros, string generated, string exploded,
			bool hotListBom, bool lessDays) : base(dataSet, "Hot List", lessDays){

	this.title = title;
	this.noZeros = noZeros;
	this.lessDays = lessDays;

	if (lessDays)
	{
		rptHotListMinGroupMM.setHoursPartsHL(isHoursReport);
		rptHotListMinGroupMM.setLabourReport(labourReport);
		rptHotListMinGroupMM.setNonZeroes(noZeros);
		rptHotListMinGroupMM.setGenerated(generated);
		rptHotListMinGroupMM.setExploded(exploded);
		rptHotListMinGroupMM.SetTitle(title);
		rptHotListMinGroupMM.setBomReport(hotListBom);
	}
	else
	{
		rptHotListMinGroupMM2.setHoursPartsHL(isHoursReport);
		rptHotListMinGroupMM2.setLabourReport(labourReport);
		rptHotListMinGroupMM2.setNonZeroes(noZeros);
		rptHotListMinGroupMM2.setGenerated(generated);
		rptHotListMinGroupMM2.setExploded(exploded);
		rptHotListMinGroupMM2.SetTitle(title);
		rptHotListMinGroupMM2.setBomReport(hotListBom);
	}

	this.runReport();
}

public 
HotListReportByMGroupMainMat(DataSet dataSet, string title, 
		bool accumOnFridays, bool isHoursReport, bool labourReport, 
		bool noZeros, string generated, string exploded,
		bool hotListBom, bool lessDays) : base(dataSet, "Hot List", lessDays){

	this.title = title;
	this.noZeros = noZeros;
	this.lessDays = lessDays;

	if (lessDays)
	{
		rptHotListMinGroupMM.setAccumOnFridays(accumOnFridays);           
		rptHotListMinGroupMM.setHoursPartsHL(isHoursReport);
		rptHotListMinGroupMM.setLabourReport(labourReport);
		rptHotListMinGroupMM.setNonZeroes(noZeros);
		rptHotListMinGroupMM.setGenerated(generated);
		rptHotListMinGroupMM.setExploded(exploded);
		rptHotListMinGroupMM.SetTitle(title);
		rptHotListMinGroupMM.setBomReport(hotListBom);
	}
	else
	{
		rptHotListMinGroupMM2.setAccumOnFridays(accumOnFridays);           
		rptHotListMinGroupMM2.setHoursPartsHL(isHoursReport);
		rptHotListMinGroupMM2.setLabourReport(labourReport);
		rptHotListMinGroupMM2.setNonZeroes(noZeros);
		rptHotListMinGroupMM2.setGenerated(generated);
		rptHotListMinGroupMM2.setExploded(exploded);
		rptHotListMinGroupMM2.SetTitle(title);
		rptHotListMinGroupMM2.setBomReport(hotListBom);
	}

	this.runReport();
}

protected override 
ActiveReport getActiveReport(bool lessDays){
	ActiveReport rptHotListMinGroupMMAux = null;

	if (lessDays)
	{
		rptHotListMinGroupMM.DataMember = "hotListReport";
		rptHotListMinGroupMMAux = rptHotListMinGroupMM;
	}
	else
	{
		rptHotListMinGroupMM2.DataMember = "hotListReport";
		rptHotListMinGroupMMAux = rptHotListMinGroupMM2;
	}

	return rptHotListMinGroupMMAux;
}

protected override 
void runReport(){
	if (lessDays)
		rptHotListMinGroupMM.Run();
	else
		rptHotListMinGroupMM2.Run();
}
	
} // class

} // namespace
