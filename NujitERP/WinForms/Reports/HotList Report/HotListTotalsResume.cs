using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Util;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.WinForms.Reports;
using Nujit.NujitERP.ClassLib.Reports.HotList;


namespace Nujit.NujitERP.WinForms.Reports.HotList_Report{


public
class HotListTotalsResume : GenericReport{

Nujit.NujitERP.ClassLib.Reports.rptHotListTotalResume rpt = new Nujit.NujitERP.ClassLib.Reports.rptHotListTotalResume();

string title = "";

public 
HotListTotalsResume(DataSet dataSet, string title) : base(dataSet, title, false){
	this.title = title;
	rpt.setTitle(title);
	this.runReport();
}

protected override 
ActiveReport3 getActiveReport(bool lessDays){
	rpt.DataMember = "hotListTotalsResume";
	return rpt;
}

protected override 
void runReport(){
	rpt.Run();
}

	
} // class

} // namespace
