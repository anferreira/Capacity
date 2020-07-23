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
class HotListReportByResource : GenericReport{

private rptHotListResourceMartinRea rptHotListResource = new rptHotListResourceMartinRea();
private rptHotListResource rptHotListResource2 = new rptHotListResource();

private string title = "";
private bool noZeros = false;
private bool sunSatToFriday = false;
private bool lessDays;

public 
HotListReportByResource(DataSet dataSet, string title, bool isHoursReport, bool labourReport, 
			bool noZeros, bool sunSatToFriday, string generated, string exploded,
			bool hotListBom, bool lessDays) : base(dataSet, "Hot List", lessDays){

	this.title = title;
	this.noZeros = noZeros;
	this.sunSatToFriday = sunSatToFriday;
	this.lessDays = lessDays;

	if (lessDays)
	{
		rptHotListResource.setHoursPartsHL(isHoursReport);
		rptHotListResource.setLabourReport(labourReport);
		rptHotListResource.setNonZeroes(noZeros);
		rptHotListResource.setAccumOnFridays(sunSatToFriday);
		rptHotListResource.setGenerated(generated);
		rptHotListResource.setExploded(exploded);
		rptHotListResource.SetTitle(title);
		rptHotListResource.setBomReport(hotListBom);
	}
	else
	{
		rptHotListResource2.setHoursPartsHL(isHoursReport);
		rptHotListResource2.setLabourReport(labourReport);
		rptHotListResource2.setNonZeroes(noZeros);
		rptHotListResource2.setAccumOnFridays(sunSatToFriday);
		rptHotListResource2.setGenerated(generated);
		rptHotListResource2.setExploded(exploded);
		rptHotListResource2.SetTitle(title);
		rptHotListResource2.setBomReport(hotListBom);
	}
	
	this.runReport();
}

public 
HotListReportByResource(DataSet dataSet, string title, bool accumOnFridays, bool isHoursReport, 
			bool labourReport, bool noZeros, bool sunSatToFriday, string generated, 
			string exploded, bool hotListBom, bool lessDays) : base(dataSet, "Hot List", lessDays){

	this.title = title;
	this.noZeros = noZeros;
	this.sunSatToFriday = sunSatToFriday;
	this.lessDays = lessDays;

	if (lessDays)
	{
		rptHotListResource.setAccumOnFridays(accumOnFridays);
		rptHotListResource.setHoursPartsHL(isHoursReport);
		rptHotListResource.setLabourReport(labourReport);
		rptHotListResource.setNonZeroes(noZeros);
		rptHotListResource.setAccumOnFridays(sunSatToFriday);
		rptHotListResource.setGenerated(generated);
		rptHotListResource.setExploded(exploded);
		rptHotListResource.SetTitle(title);
		rptHotListResource.setBomReport(hotListBom);
	}
	else
	{
		rptHotListResource2.setAccumOnFridays(accumOnFridays);
		rptHotListResource2.setHoursPartsHL(isHoursReport);
		rptHotListResource2.setLabourReport(labourReport);
		rptHotListResource2.setNonZeroes(noZeros);
		rptHotListResource2.setAccumOnFridays(sunSatToFriday);
		rptHotListResource2.setGenerated(generated);
		rptHotListResource2.setExploded(exploded);
		rptHotListResource2.SetTitle(title);
		rptHotListResource2.setBomReport(hotListBom);
	}

	this.runReport();
}

protected override 
ActiveReport3 getActiveReport(bool lessDays){
	ActiveReport3 rptHotListResourceAux = null;

	if (lessDays)
	{
		rptHotListResource.DataMember = "hotListReport";
		rptHotListResourceAux = rptHotListResource;
	}
	else
	{
		rptHotListResource2.DataMember = "hotListReport";
		rptHotListResourceAux = rptHotListResource2;
	}

	return rptHotListResourceAux;
}

protected override 
void runReport(){
	if (lessDays)
		rptHotListResource.Run();
	else
		rptHotListResource2.Run();
}
	

} // class

} // namespace
