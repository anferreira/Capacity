using System;
using System.Collections;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.ClassLib.Reports{
	

public 
class GenerateTotalsHotList{


public 
GenerateTotalsHotList(){
}

~GenerateTotalsHotList(){
}
	
public static 
string generate(System.Data.DataSet dataSet, int id1, int id2, ArrayList fields){
	rptHotListTotal rpt = new rptHotListTotal();
	rpt.setFields(fields);
	return GenerateReportFormat.generateReport(rpt, dataSet, "hotListTotals", Nujit.NujitERP.ClassLib.Common.Constants.PDF_FORMAT, false);
}

} // class

} // namespace
