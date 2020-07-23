using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using ClassLib.util;

namespace Nujit.NujitERP.WinForms.Reports.InventoryReport
{
public class rptInventoryReport : ActiveReport{


public rptInventoryReport(){
	InitializeReport();
	loadLabels();
}

#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.Label labelTitle = null;
		private DataDynamics.ActiveReports.TextBox txtProdId = null;
		private DataDynamics.ActiveReports.TextBox txtDes1 = null;
		private DataDynamics.ActiveReports.TextBox txtDataHour = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Label Label12 = null;
		private DataDynamics.ActiveReports.Label Label13 = null;
		private DataDynamics.ActiveReports.Label Label14 = null;
		private DataDynamics.ActiveReports.Label Label15 = null;
		private DataDynamics.ActiveReports.Label Label16 = null;
		private DataDynamics.ActiveReports.Label Label17 = null;
		private DataDynamics.ActiveReports.Label Label18 = null;
		private DataDynamics.ActiveReports.Label Label19 = null;
		private DataDynamics.ActiveReports.Label Label20 = null;
		private DataDynamics.ActiveReports.Label Label21 = null;
		private DataDynamics.ActiveReports.Line Line2 = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1 = null;
		private DataDynamics.ActiveReports.TextBox IPL_Seq1 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox txtSeq = null;
		private DataDynamics.ActiveReports.TextBox txtLotID = null;
		private DataDynamics.ActiveReports.TextBox txtStkLoc = null;
		private DataDynamics.ActiveReports.TextBox txtQoh = null;
		private DataDynamics.ActiveReports.TextBox txtQohAvail = null;
		private DataDynamics.ActiveReports.TextBox txtUom = null;
		private DataDynamics.ActiveReports.TextBox txtQoh2 = null;
		private DataDynamics.ActiveReports.TextBox txtQohAvail2 = null;
		private DataDynamics.ActiveReports.TextBox txtUom2 = null;
		private DataDynamics.ActiveReports.TextBox txtProd2 = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1 = null;
		private DataDynamics.ActiveReports.Label Label22 = null;
		private DataDynamics.ActiveReports.TextBox TextBox1 = null;
		private DataDynamics.ActiveReports.TextBox TextBox2 = null;
		private DataDynamics.ActiveReports.TextBox TextBox3 = null;
		private DataDynamics.ActiveReports.TextBox TextBox4 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Reports.InventoryReport.rptInventoryReport.rpx");
			this.ReportHeader = ((DataDynamics.ActiveReports.ReportHeader)(this.Sections["ReportHeader"]));
			this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
			this.GroupHeader1 = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["GroupHeader1"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.GroupFooter1 = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["GroupFooter1"]));
			this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
			this.ReportFooter = ((DataDynamics.ActiveReports.ReportFooter)(this.Sections["ReportFooter"]));
			this.labelTitle = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[0]));
			this.txtProdId = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[1]));
			this.txtDes1 = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[2]));
			this.txtDataHour = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[3]));
			this.Label12 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
			this.Label13 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
			this.Label14 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
			this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
			this.Label16 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
			this.Label17 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
			this.Label18 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
			this.Label19 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
			this.Label20 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
			this.Label21 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
			this.Line2 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[10]));
			this.IPL_Seq1 = ((DataDynamics.ActiveReports.TextBox)(this.GroupHeader1.Controls[0]));
			this.txtSeq = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.txtLotID = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.txtStkLoc = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.txtQoh = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.txtQohAvail = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
			this.txtUom = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
			this.txtQoh2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
			this.txtQohAvail2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
			this.txtUom2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
			this.txtProd2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[9]));
			this.Label22 = ((DataDynamics.ActiveReports.Label)(this.GroupFooter1.Controls[0]));
			this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[1]));
			this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[2]));
			this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[3]));
			this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[4]));
		}

#endregion


private void loadLabels(){

	this.labelTitle.Text += this.txtProdId + " - " + this.txtDes1;
	this.txtDataHour.Text = DateUtil.getCompleteDateRepresentation(DateTime.Now, DateUtil.MMDDYYYY);

}


}//end class
}//end namespace
