using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Common;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.WinForms.Reports;


namespace Nujit.NujitERP.WinForms.Reports.BomErrorsReport{

public 
class BomReport : GenericReport{

private rptBomReport rpt = new rptBomReport();

public 
BomReport(DataSet dataSet):base(dataSet, "Bom Report Errors", false){
	runReport();
}

protected override ActiveReport getActiveReport(bool lessDays){
	rpt.DataMember = "bom";
	return rpt;
}

protected override void runReport(){
	rpt.Run();
}

}//end Class
}//end namespace
