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
class HotListReportMainMaterial : GenericReport{

private rptHotListMainMaterialMartinRea rptHotListMainMaterial = new rptHotListMainMaterialMartinRea();
private rptHotListMainMaterial rptHotListMainMaterial2 = new rptHotListMainMaterial();

private string title = "";
private bool noZeros;
private bool lessDays;

public 
HotListReportMainMaterial(DataSet dataSet, string title, bool accumOnFridays, 
		bool isHoursReport, bool labourReport, bool noZeros, string generated, 
		string exploded, bool hotListBom, bool lessDays) : base(dataSet, "Hot List", lessDays){

	this.title = title;
	this.noZeros = noZeros;
	this.lessDays = lessDays;

	if (lessDays)
	{
		rptHotListMainMaterial.setAccumOnFridays(accumOnFridays);
		rptHotListMainMaterial.setLabourReport(labourReport);
		rptHotListMainMaterial.setNonZeroes(noZeros);
		rptHotListMainMaterial.setGenerated(generated);
		rptHotListMainMaterial.setExploded(exploded);
		rptHotListMainMaterial.SetTitle(title);
		rptHotListMainMaterial.setBomReport(hotListBom);
	}
	else
	{
		rptHotListMainMaterial2.setAccumOnFridays(accumOnFridays);
		rptHotListMainMaterial2.setLabourReport(labourReport);
		rptHotListMainMaterial2.setNonZeroes(noZeros);
		rptHotListMainMaterial2.setGenerated(generated);
		rptHotListMainMaterial2.setExploded(exploded);
		rptHotListMainMaterial2.SetTitle(title);
		rptHotListMainMaterial2.setBomReport(hotListBom);
	}

	this.runReport();
}

public 
HotListReportMainMaterial(DataSet dataSet, string title, 
			bool isHoursReport, bool labourReport, bool noZeros, 
			string generated, string exploded, bool hotListBom, bool lessDays) : base(dataSet, "Hot List", lessDays){

	this.title = title;
	this.noZeros = noZeros;
	this.lessDays = lessDays;

	if (lessDays)
	{
		rptHotListMainMaterial.setGenerated(generated);
		rptHotListMainMaterial.setExploded(exploded);
		rptHotListMainMaterial.setLabourReport(labourReport);
		rptHotListMainMaterial.setNonZeroes(noZeros);
		rptHotListMainMaterial.SetTitle(title);
		rptHotListMainMaterial.setBomReport(hotListBom);
	}
	else
	{
		rptHotListMainMaterial2.setGenerated(generated);
		rptHotListMainMaterial2.setExploded(exploded);
		rptHotListMainMaterial2.setLabourReport(labourReport);
		rptHotListMainMaterial2.setNonZeroes(noZeros);
		rptHotListMainMaterial2.SetTitle(title);
		rptHotListMainMaterial2.setBomReport(hotListBom);
	}

	this.runReport();
}

protected override 
ActiveReport3 getActiveReport(bool lessDays){
	ActiveReport3 rptHotListMainMaterialAux = null;

	if (lessDays)
	{
		rptHotListMainMaterial.DataMember = "hotListReport";
		rptHotListMainMaterialAux = rptHotListMainMaterial;
	}
	else
	{
		rptHotListMainMaterial2.DataMember = "hotListReport";
		rptHotListMainMaterialAux = rptHotListMainMaterial2;
	}

	return rptHotListMainMaterialAux;
}

protected override 
void runReport(){
	if (lessDays)
		rptHotListMainMaterial.Run();
	else
		rptHotListMainMaterial2.Run();
}
	
} // class

} // namespace