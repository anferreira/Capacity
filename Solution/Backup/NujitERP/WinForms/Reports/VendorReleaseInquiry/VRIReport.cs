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

namespace Nujit.NujitERP.WinForms.Reports.VendorReleaseInquiry{

public 
class VRIReport : GenericReport{

private rptVRIReport rpt = new rptVRIReport();

public 
VRIReport(DataSet dataSet, string type):base(dataSet, "Vendor Release Inquiry Report", false){
	rpt.setLabels(type);
	runReport();
}

protected override ActiveReport getActiveReport(bool lessDays){
	rpt.DataMember = "vri";
	return rpt;
}

protected override void runReport(){
	rpt.Run();
}


}//end Class
}//end namespace
