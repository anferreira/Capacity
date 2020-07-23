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

namespace Nujit.NujitERP.WinForms.Reports.InventoryReport{

public class InventoryReport : GenericReport{

private rptInventoryReport rpt = new rptInventoryReport();
	
	
public InventoryReport(string prodID,DataSet dataSet):base(dataSet, "Inventory Report", false){
			runReport();
}

protected override ActiveReport getActiveReport(bool lessDays){
	rpt.DataMember = "inventory";
	return rpt;
}

protected override void runReport(){
	rpt.Run();
}

}//end class
}//end namespace
