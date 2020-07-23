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

public class ScheduleInMachineReport : GenericReport{
	
private rptScheduleInMachineReport rpt = new rptScheduleInMachineReport();

public ScheduleInMachineReport(DataSet dataSet, DateTime dateFrom, DateTime dateTo, string version, string plant, string department, string machine):base(dataSet, "Schedule of a Machine - Report", false){
	rpt.setValues(dateFrom, dateTo, version, plant, department, machine);
	runReport();
}

protected override ActiveReport getActiveReport(bool lessDays){
	rpt.DataMember = "scheduleInMachine";
	return rpt;
}

protected override void runReport(){
	rpt.Run();
}


}//end class
}//end Namespace
