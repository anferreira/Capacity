using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.WinForms.Reports.SchedulingView;
using Nujit.NujitERP.ClassLib.Common;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.WinForms.Reports;


namespace NujitERP.WinForms.Reports.SchedulingView{

public class SchedulingViewReport : GenericReport{
	
	public const int DAYS = 14;
	private rptSchedulingReport rpt = new rptSchedulingReport();
	

public SchedulingViewReport(DataSet dataSet):base(dataSet, "Scheduling Report", false){
	runReport();
}

protected override ActiveReport3 getActiveReport(bool lessDays){
	rpt.DataMember = "schedule";
	return rpt;
}

protected override void runReport(){
	rpt.Run();
}


}//end class
}//end Namespace
