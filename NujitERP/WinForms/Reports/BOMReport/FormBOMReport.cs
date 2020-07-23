using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Nujit.NujitERP.WinForms.Reports.HotList_Report;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Util;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.WinForms.Reports;

namespace Nujit.NujitERP.WinForms.Reports.BOMReport{
	
public class FormBOMReport : GenericReport{

private BOMReport rpt = new BOMReport();

public 
FormBOMReport(DataSet dataSet, string prodId, int seqId, decimal Qoh, bool final):base(dataSet, "Bom Report", false){
	rpt.setValues(prodId,seqId, Qoh, final);
	runReport();	
}
protected override ActiveReport3 getActiveReport(bool lessDays){
	rpt.DataMember = "parentMaterials";
	return rpt;
}

protected override void runReport(){
	rpt.Run();
}

}
}
