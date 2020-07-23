using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.WinForms.Reports;
using System.Data;


namespace Nujit.NujitERP.WinForms.Reports.ShortageReport{
	
public class ShortageReport :  GenericReport	{

private rptShortageReport rpt = new rptShortageReport();


public ShortageReport(DataSet dataSet,DateTime dateFrom):base(dataSet, "Shortage Report", false){
	rpt.setDateFrom(dateFrom);
	runReport();
}

protected override ActiveReport3 getActiveReport(bool lessDays){
	rpt.DataMember = "shortageReport";
	return rpt;
}


protected override void runReport(){
	rpt.Run();
}



	
}
}
