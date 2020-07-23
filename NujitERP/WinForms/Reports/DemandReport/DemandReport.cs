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

namespace Nujit.NujitERP.WinForms.Reports.DemandReport{

public 
class DemandReport : GenericReport{

private rptDemandReport rpt = new rptDemandReport();
private string generationDate;

public 
DemandReport(DataSet dataSet, string generationDate) : base(dataSet, "Demand Report", false){
	this.generationDate = generationDate;

	runReport();
}

protected override 
ActiveReport3 getActiveReport(bool lessDays){
	rpt.DataMember = "demand";
	return rpt;
}

protected override 
void runReport(){
	rpt.setGenerationDate(generationDate);
	rpt.Run();
}


}//end Class
}//end namespace
