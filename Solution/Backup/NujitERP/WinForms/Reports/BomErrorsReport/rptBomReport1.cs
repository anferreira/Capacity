using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.WinForms.Reports.BomErrorsReport{

public 
class rptBomReport : ActiveReport{

public 
rptBomReport(){
	InitializeReport();
}

private 
void PageFooter_Format(object sender, System.EventArgs eArgs){
	this.pageLbl.Text = this.PageNumber.ToString();
}

private 
void ReportHeader_Format(object sender, System.EventArgs eArgs){
	dateLbl.Text = DateTime.Today.ToShortDateString();
}

#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.Label Label1 = null;
		private DataDynamics.ActiveReports.Line Line1 = null;
		private DataDynamics.ActiveReports.Label dateLbl = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Label Label2 = null;
		private DataDynamics.ActiveReports.Label Label3 = null;
		private DataDynamics.ActiveReports.Label Label4 = null;
		private DataDynamics.ActiveReports.Label Label5 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox partText = null;
		private DataDynamics.ActiveReports.TextBox seqText = null;
		private DataDynamics.ActiveReports.TextBox descText = null;
		private DataDynamics.ActiveReports.TextBox qohText = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.Label pageLbl = null;
		private DataDynamics.ActiveReports.Label Label7 = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Reports.BomErrorsReport.rptBomReport.rpx");
			this.ReportHeader = ((DataDynamics.ActiveReports.ReportHeader)(this.Sections["ReportHeader"]));
			this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
			this.ReportFooter = ((DataDynamics.ActiveReports.ReportFooter)(this.Sections["ReportFooter"]));
			this.Label1 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[0]));
			this.Line1 = ((DataDynamics.ActiveReports.Line)(this.ReportHeader.Controls[1]));
			this.dateLbl = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[2]));
			this.Label2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
			this.Label3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
			this.Label4 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
			this.Label5 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
			this.partText = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.seqText = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.descText = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.qohText = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.pageLbl = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
			this.Label7 = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[1]));
			// Attach Report Events
			this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
			this.ReportHeader.Format += new System.EventHandler(this.ReportHeader_Format);
		}

#endregion


}//end class

}//end namespace
