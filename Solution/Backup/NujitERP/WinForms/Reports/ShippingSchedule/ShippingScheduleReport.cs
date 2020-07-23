using System;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Util;
using System.Data;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.WinForms.Reports;
using  Nujit.NujitERP.WinForms.Reports.ShippingSchedule;

namespace Nujit.NujitERP.WinForms.Reports.ShippingSchedule{
	
public class ShippingScheduleReport : GenericReport	{
	
private rptShippingSchAcummulated rpt = new rptShippingSchAcummulated();

public ShippingScheduleReport(DataSet dataSet,bool flag):base(dataSet, "Shipping Schedule Acummulated", false){
	rpt.setLabel(flag);
	runReport();
}

protected override ActiveReport getActiveReport(bool lessDays){
	rpt.DataMember = "shippingSchedule";
	return rpt;
}


protected override void runReport(){
	rpt.Run();
}

}
}
