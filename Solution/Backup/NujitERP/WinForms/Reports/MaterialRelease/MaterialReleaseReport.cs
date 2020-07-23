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
using  Nujit.NujitERP.WinForms.Reports.MaterialRelease;

namespace Nujit.NujitERP.WinForms.Reports.MaterialRelease {
	
public class MaterialReleaseReport : GenericReport	{

private rptMaterialRelease rpt = new rptMaterialRelease();

public MaterialReleaseReport(DataSet dataSet):base(dataSet, "Material Release from AS400", false)	{
	runReport();
}

protected override ActiveReport getActiveReport(bool lessDays){
	rpt.DataMember = "materialRelease";
	return rpt;
}


protected override void runReport(){
	rpt.Run();
}
}
}
