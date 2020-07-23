using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.WinForms.Reports;

namespace Nujit.NujitERP.WinForms.Reports.ProductsReport{

public class ProductReport : GenericReport{
	

private rptProductReport rpt = new rptProductReport();

public ProductReport(DataSet dataSet,string infMayG,string supMayG):base(dataSet, "Products Report", false){
	
	rpt.setLabels(infMayG,supMayG);
	runReport();
}


protected override ActiveReport getActiveReport(bool lessDays){
	rpt.DataMember = "products";
	return rpt;
}

protected override void runReport(){
	rpt.Run();
}



}//end Class
}//end namespace
