using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.WinForms.Reports.DemandReport
{
	public class rptDemandReport : ActiveReport
	{
		public rptDemandReport()
		{
			InitializeReport();
		}


		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.Label Label1 = null;
		private DataDynamics.ActiveReports.Line Line1 = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Label Label2 = null;
		private DataDynamics.ActiveReports.Label Label3 = null;
		private DataDynamics.ActiveReports.Label Label4 = null;
		private DataDynamics.ActiveReports.Label Label8 = null;
		private DataDynamics.ActiveReports.Label Label9 = null;
		private DataDynamics.ActiveReports.Label Label10 = null;
		private DataDynamics.ActiveReports.Label Label11 = null;
		private DataDynamics.ActiveReports.Label Label12 = null;
		private DataDynamics.ActiveReports.Label Label13 = null;
		private DataDynamics.ActiveReports.Label Label = null;
		private DataDynamics.ActiveReports.Label Label6 = null;
		private DataDynamics.ActiveReports.Label generationDateLabel = null;
		private DataDynamics.ActiveReports.Label dateLbl = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox partText = null;
		private DataDynamics.ActiveReports.TextBox dateText = null;
		private DataDynamics.ActiveReports.TextBox qtyText = null;
		private DataDynamics.ActiveReports.TextBox qohTextBox = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.Label pageLbl = null;
		private DataDynamics.ActiveReports.Label Label7 = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Reports.DemandReport.rptDemandReport.rpx");
			this.ReportHeader = ((DataDynamics.ActiveReports.ReportHeader)(this.Sections["ReportHeader"]));
			this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
			this.ReportFooter = ((DataDynamics.ActiveReports.ReportFooter)(this.Sections["ReportFooter"]));
			this.Label1 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[0]));
			this.Line1 = ((DataDynamics.ActiveReports.Line)(this.ReportHeader.Controls[1]));
			this.Label2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
			this.Label3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
			this.Label4 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
			this.Label8 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
			this.Label9 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
			this.Label10 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
			this.Label11 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
			this.Label12 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
			this.Label13 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
			this.Label = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
			this.Label6 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
			this.generationDateLabel = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
			this.dateLbl = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
			this.partText = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.dateText = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.qtyText = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.qohTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.pageLbl = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
			this.Label7 = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[1]));
			// Attach Report Events
			this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
		}

		#endregion

	
public
void setGenerationDate(string generationDate){
	generationDateLabel.Text = generationDate;
}

private 
void PageFooter_Format(object sender, System.EventArgs eArgs){
	this.pageLbl.Text = this.PageNumber.ToString();
}
	
private 
void PageHeader_Format(object sender, System.EventArgs eArgs){
	dateLbl.Text = DateTime.Today.ToShortDateString();
}
	
	
}


}



