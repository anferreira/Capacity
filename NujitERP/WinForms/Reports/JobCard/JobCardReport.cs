using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.WinForms.Reports;
using Nujit.NujitERP.WinForms.Reports.MaterialRelease;

namespace Nujit.NujitERP.WinForms.Reports.JobCard{

public 
class JobCardReport : GenericReport{

private rptJobCard rpt = new rptJobCard();

public JobCardReport(DataSet dataSet):base(dataSet, "Job Card", false){
	runReport();
}

protected override ActiveReport3 getActiveReport(bool lessDays){
	rpt.DataMember = "jobCard";
	return rpt;
}

protected override void runReport(){
	rpt.Run();
}

}//end class
}//end namespace