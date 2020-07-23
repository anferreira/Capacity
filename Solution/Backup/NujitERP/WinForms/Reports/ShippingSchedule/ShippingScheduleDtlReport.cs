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
	
public class ShippingScheduleDtlReport : GenericReport{
private rptShippingSchDtl rpt  = new rptShippingSchDtl();

public ShippingScheduleDtlReport(DataSet dataSet,bool flag):base(dataSet, "Shipping Schedule Detail", false){
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
