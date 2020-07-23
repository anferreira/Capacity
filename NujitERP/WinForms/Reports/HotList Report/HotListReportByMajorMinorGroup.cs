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
class HotListReportByMajorMinorGroup : GenericReport{


private rptHotListMajMinGroupMartinRea rptHotListMajMinGroup = new rptHotListMajMinGroupMartinRea();
private rptHotListMajMinGroup rptHotListMajMinGroup2 = new rptHotListMajMinGroup();

private string title = "";
private bool noZeros;
private bool lessDays;

public 
HotListReportByMajorMinorGroup(DataSet dataSet, string title, bool isHoursReport, 
		bool labourReport, bool noZeros, string generated, string exploded,
		bool hotListBom, bool lessDays) : base(dataSet, "Hot List", lessDays){

	this.title = title;
	this.noZeros = noZeros;
	this.lessDays = lessDays;

	if (lessDays)
	{
		rptHotListMajMinGroup.setHoursPartsHL(isHoursReport);
		rptHotListMajMinGroup.setLabourReport(labourReport);
		rptHotListMajMinGroup.setNonZeroes(noZeros);
		rptHotListMajMinGroup.setGenerated(generated);
		rptHotListMajMinGroup.setExploded(exploded);
		rptHotListMajMinGroup.SetTitle(title);
		rptHotListMajMinGroup.setBomReport(hotListBom);
	}
	else
	{
		rptHotListMajMinGroup2.setHoursPartsHL(isHoursReport);
		rptHotListMajMinGroup2.setLabourReport(labourReport);
		rptHotListMajMinGroup2.setNonZeroes(noZeros);
		rptHotListMajMinGroup2.setGenerated(generated);
		rptHotListMajMinGroup2.setExploded(exploded);
		rptHotListMajMinGroup2.SetTitle(title);
		rptHotListMajMinGroup2.setBomReport(hotListBom);
	}

	this.runReport();
}

public 
HotListReportByMajorMinorGroup(DataSet dataSet, string title, bool accumOnFridays, 
		bool isHoursReport, bool labourReport, bool noZeros, string generated, 
		string exploded, bool hotListBom, bool lessDays) : base(dataSet, "Hot List", lessDays){

	this.title = title;
	this.noZeros = noZeros;
	this.lessDays = lessDays;

	if (lessDays)
	{
		rptHotListMajMinGroup.setAccumOnFridays(accumOnFridays);
		rptHotListMajMinGroup.setHoursPartsHL(isHoursReport);
		rptHotListMajMinGroup.setLabourReport(labourReport);
		rptHotListMajMinGroup.setNonZeroes(noZeros);
		rptHotListMajMinGroup.setGenerated(generated);
		rptHotListMajMinGroup.setExploded(exploded);
		rptHotListMajMinGroup.SetTitle(title);
		rptHotListMajMinGroup.setBomReport(hotListBom);
	}
	else
	{
		rptHotListMajMinGroup2.setAccumOnFridays(accumOnFridays);
		rptHotListMajMinGroup2.setHoursPartsHL(isHoursReport);
		rptHotListMajMinGroup2.setLabourReport(labourReport);
		rptHotListMajMinGroup2.setNonZeroes(noZeros);
		rptHotListMajMinGroup2.setGenerated(generated);
		rptHotListMajMinGroup2.setExploded(exploded);
		rptHotListMajMinGroup2.SetTitle(title);
		rptHotListMajMinGroup2.setBomReport(hotListBom);
	}

	this.runReport();
}

protected override 
ActiveReport3 getActiveReport(bool lessDays){
	ActiveReport3 rptHotListMajMinGroupAux = null;

	if (lessDays)
	{
		rptHotListMajMinGroup.DataMember = "hotListReport";
		rptHotListMajMinGroupAux = rptHotListMajMinGroup;
	}
	else
	{
		rptHotListMajMinGroup2.DataMember = "hotListReport";
		rptHotListMajMinGroupAux = rptHotListMajMinGroup2;
	}

	return rptHotListMajMinGroupAux;
}

protected override 
void runReport(){
	if (lessDays)
		rptHotListMajMinGroup.Run();
	else
		rptHotListMajMinGroup2.Run();
}

	
} // class

} // namespace
