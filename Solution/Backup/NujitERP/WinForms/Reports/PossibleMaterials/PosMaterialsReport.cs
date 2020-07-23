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


namespace Nujit.NujitERP.WinForms.Reports.PossibleMaterials{


public 
class PosMaterialsReport : GenericReport{


private rptPosMaterialsReport rpt = new rptPosMaterialsReport();

	
public 
PosMaterialsReport(string prodID, int seq, decimal possible, DataSet dataSet) : base(dataSet, "Materials", false){
	rpt.setProduct(prodID);
	rpt.setSequence(seq);
	rpt.setPossible(possible);

	runReport();
}

protected override 
ActiveReport getActiveReport(bool lessDays){
	rpt.DataMember = "materials";
	return rpt;
}

protected override 
void runReport(){
	rpt.Run();
}

}//end class

}//end namespace
