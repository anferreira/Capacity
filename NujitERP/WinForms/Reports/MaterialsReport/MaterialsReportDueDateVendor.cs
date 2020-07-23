using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Util;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.WinForms.Reports;
using Nujit.NujitERP.WinForms.Reports.MaterialsReport;

namespace Nujit.NujitERP.WinForms.Reports.MaterialsReport{


public 
class MaterialsReportDueDateVendor : GenericReport{

private rptMaterialsReportGroupByDateVendorMartinRea rpt = new rptMaterialsReportGroupByDateVendorMartinRea();
private rptMaterialsReportGroupByDateVendor rpt2 = new rptMaterialsReportGroupByDateVendor();
private bool lessDays;

public 
MaterialsReportDueDateVendor(DataSet dsMaterials, bool days, bool lessDays) : base(dsMaterials, "Materials Due Date Vendor", lessDays){

	this.lessDays = lessDays;

	if (lessDays)
	{
		if (days)
			rpt.setLabel("Day");
		else
			rpt.setLabel("Week");
	}
	else
	{
		if (days)
			rpt2.setLabel("Day");
		else
			rpt2.setLabel("Week");
	}

	runReport();
}

public 
MaterialsReportDueDateVendor(DataSet dsMaterials, bool lessDays) : base(dsMaterials, lessDays){
	this.lessDays = lessDays;
	runReport();
}
	
protected override 
ActiveReport3 getActiveReport(bool lessDays){
	ActiveReport3 rptAux = null;

	if (lessDays)
	{
		rpt.DataMember = "materials";
		rptAux = rpt;
	}
	else
	{
		rpt2.DataMember = "materials";
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


}//end class

}//end namespace
