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
class MaterialsReport : GenericReport{

private rptMaterialsReport rpt = new rptMaterialsReport();

public 
MaterialsReport(DataSet dataSet):base(dataSet, "Materials", false){
	runReport();
}

protected override ActiveReport3 getActiveReport(bool lessDays){
	rpt.DataMember = "materials";
	return rpt;
}


protected override void runReport(){
	rpt.Run();
}
}//end class
}//end namespace
