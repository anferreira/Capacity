using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.WinForms.Reports.WipbReport{

public 
class rptWipbReport : ActiveReport3{

public 
rptWipbReport(){
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
		private DataDynamics.ActiveReports.ReportHeader ReportHeader;
		private DataDynamics.ActiveReports.Label Label1;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.Label dateLbl;
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label Label2;
		private DataDynamics.ActiveReports.Label Label3;
		private DataDynamics.ActiveReports.Label Label4;
		private DataDynamics.ActiveReports.Label Label5;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox partText;
		private DataDynamics.ActiveReports.TextBox seqText;
		private DataDynamics.ActiveReports.TextBox descText;
		private DataDynamics.ActiveReports.TextBox qohText;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.Label pageLbl;
		private DataDynamics.ActiveReports.Label Label7;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Reports.WipbReport.rptWipbReport.rpx");
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
