using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Util;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.WinForms.Reports;
using Nujit.NujitERP.ClassLib.Reports.HotList;


namespace Nujit.NujitERP.WinForms.Reports.HotList_Report{


public
class HotListTotals : GenericReport{

Nujit.NujitERP.ClassLib.Reports.rptHotListTotal rpt = new Nujit.NujitERP.ClassLib.Reports.rptHotListTotal();

string title = "";

public 
HotListTotals(DataSet dataSet, string title, ArrayList fields) : base(dataSet, title, false){
	this.title = title;
	rpt.setTitle(title);
	rpt.setFields(fields);
	this.runReport();
}

protected override 
ActiveReport3 getActiveReport(bool lessDays){
	rpt.DataMember = "hotListTotals";

	return rpt;
}

protected override 
void runReport(){
	rpt.Run();
}

private 
void HotListReport_SizeChanged(object sender, System.EventArgs e){
}
	
} // class

} // namespace
