using System;
using System.Data;
using System.Collections;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Reports.HotList;

namespace Nujit.NujitERP.ClassLib.Reports{
	

public 
class GenerateHotListReport{


public 
GenerateHotListReport(){
}

~GenerateHotListReport(){
}

public static 
string generate(DataSet dataSet, string generated, string exploded, string title){
	rptHotList rpt = new rptHotList();

	rpt.setGenerated(generated);
	rpt.setExploded(exploded);
	rpt.setHoursPartsHL(false);
	rpt.setLabourReport(false);
	rpt.setNonZeroes(false);
	rpt.SetTitle(title);
	rpt.setBomReport(false);
	
	
	return GenerateReportFormat.generateReport(rpt, dataSet, "hotListReport", Constants.PDF_FORMAT, false);
}

} // class

} // namespace
