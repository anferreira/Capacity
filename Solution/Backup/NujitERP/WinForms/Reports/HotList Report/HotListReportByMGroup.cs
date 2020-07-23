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
class HotListReportByMGroup : GenericReport {

private rptHotListMinGroupMartinRea rptHotListMinGroup = new rptHotListMinGroupMartinRea();
private rptHotListMinGroup rptHotListMinGroup2 = new rptHotListMinGroup();

private string title = "";
private bool noZeros;
private bool lessDays;

public 
HotListReportByMGroup(DataSet dataSet, string title, bool isHoursReport, 
		bool labourReport, bool noZeros, string generated,
		string exploded, bool hotListBom, bool lessDays) : base(dataSet, "Hot List", lessDays){

	this.title = title;
	this.noZeros = noZeros;
	this.lessDays = lessDays;

	if (lessDays)
	{
		rptHotListMinGroup.setHoursPartsHL(isHoursReport);
		rptHotListMinGroup.setLabourReport(labourReport);
		rptHotListMinGroup.setNonZeroes(noZeros);
		rptHotListMinGroup.setGenerated(generated);
		rptHotListMinGroup.setExploded(exploded);
		rptHotListMinGroup.SetTitle(title);
		rptHotListMinGroup.setBomReport(hotListBom);
	}
	else
	{
		rptHotListMinGroup2.setHoursPartsHL(isHoursReport);
		rptHotListMinGroup2.setLabourReport(labourReport);
		rptHotListMinGroup2.setNonZeroes(noZeros);
		rptHotListMinGroup2.setGenerated(generated);
		rptHotListMinGroup2.setExploded(exploded);
		rptHotListMinGroup2.SetTitle(title);
		rptHotListMinGroup2.setBomReport(hotListBom);
	}
	this.runReport();
}

public 
HotListReportByMGroup(DataSet dataSet, string title, bool accumOnFridays, 
		bool isHoursReport, bool labourReport, bool noZeros, 
		string generated, string exploded, bool hotListBom, bool lessDays) : base(dataSet, "Hot List", lessDays){

	this.title = title;
	this.noZeros = noZeros;
	this.lessDays = lessDays;

	if (lessDays)
	{
		rptHotListMinGroup.setAccumOnFridays(accumOnFridays);
		rptHotListMinGroup.setHoursPartsHL(isHoursReport);
		rptHotListMinGroup.setLabourReport(labourReport);
		rptHotListMinGroup.setNonZeroes(noZeros);
		rptHotListMinGroup.setGenerated(generated);
		rptHotListMinGroup.setExploded(exploded);
		rptHotListMinGroup.SetTitle(title);
		rptHotListMinGroup.setBomReport(hotListBom);
	}
	else
	{
		rptHotListMinGroup2.setAccumOnFridays(accumOnFridays);
		rptHotListMinGroup2.setHoursPartsHL(isHoursReport);
		rptHotListMinGroup2.setLabourReport(labourReport);
		rptHotListMinGroup2.setNonZeroes(noZeros);
		rptHotListMinGroup2.setGenerated(generated);
		rptHotListMinGroup2.setExploded(exploded);
		rptHotListMinGroup2.SetTitle(title);
		rptHotListMinGroup2.setBomReport(hotListBom);
	}

	this.runReport();
}

protected override 
ActiveReport getActiveReport(bool lessDays){
	ActiveReport rptHotListMinGroupAux = null;

	if (lessDays)
	{
		rptHotListMinGroup.DataMember = "hotListReport";
		rptHotListMinGroupAux = rptHotListMinGroup;
	}
	else
	{
		rptHotListMinGroup2.DataMember = "hotListReport";
		rptHotListMinGroupAux = rptHotListMinGroup2;
	}

	return rptHotListMinGroupAux;
}

protected override 
void runReport(){
	if (lessDays)
		rptHotListMinGroup.Run();
	else
		rptHotListMinGroup2.Run();
}

} // class

} // namespace
