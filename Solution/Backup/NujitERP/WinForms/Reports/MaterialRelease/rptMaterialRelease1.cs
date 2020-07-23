using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Nujit.NujitERP.WinForms.Reports.MaterialRelease{
public class rptMaterialRelease : ActiveReport	{
public rptMaterialRelease()		{
	InitializeReport();
}

private void PageFooter_Format(object sender, System.EventArgs eArgs){ 
    this.tBoxPage.Text = "Page: " + this.PageNumber.ToString();   
}

private 
void PageHeader_Format(object sender, System.EventArgs eArgs){
    this.tBoxDate.Text = DateTime.Today.ToShortDateString();
}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.Label Label1 = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Label Label2 = null;
		private DataDynamics.ActiveReports.Label Label3 = null;
		private DataDynamics.ActiveReports.Label Label4 = null;
		private DataDynamics.ActiveReports.Label Label5 = null;
		private DataDynamics.ActiveReports.Label Label6 = null;
		private DataDynamics.ActiveReports.Label Label7 = null;
		private DataDynamics.ActiveReports.Label Label8 = null;
		private DataDynamics.ActiveReports.Label Label9 = null;
		private DataDynamics.ActiveReports.Label Label10 = null;
		private DataDynamics.ActiveReports.Label Label11 = null;
		private DataDynamics.ActiveReports.Label Label12 = null;
		private DataDynamics.ActiveReports.Label Label13 = null;
		private DataDynamics.ActiveReports.Label Label14 = null;
		private DataDynamics.ActiveReports.Label Label15 = null;
		private DataDynamics.ActiveReports.Label Label16 = null;
		private DataDynamics.ActiveReports.Label Label17 = null;
		private DataDynamics.ActiveReports.Label Label18 = null;
		private DataDynamics.ActiveReports.Label Label19 = null;
		private DataDynamics.ActiveReports.Line Line1 = null;
		private DataDynamics.ActiveReports.TextBox tBoxDate = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox SMSTXL3 = null;
		private DataDynamics.ActiveReports.TextBox TextBox1 = null;
		private DataDynamics.ActiveReports.TextBox tBoxSMPART = null;
		private DataDynamics.ActiveReports.TextBox tBoxPastDue = null;
		private DataDynamics.ActiveReports.TextBox tBoxDay2 = null;
		private DataDynamics.ActiveReports.TextBox tBoxDay1 = null;
		private DataDynamics.ActiveReports.TextBox tBoxDay3 = null;
		private DataDynamics.ActiveReports.TextBox tBoxDay4 = null;
		private DataDynamics.ActiveReports.TextBox tBoxDay5 = null;
		private DataDynamics.ActiveReports.TextBox tBoxDay6 = null;
		private DataDynamics.ActiveReports.TextBox tBoxDay7 = null;
		private DataDynamics.ActiveReports.TextBox tBoxDay8 = null;
		private DataDynamics.ActiveReports.TextBox tBoxDay9 = null;
		private DataDynamics.ActiveReports.TextBox tBoxDay10 = null;
		private DataDynamics.ActiveReports.TextBox tBoxDay12 = null;
		private DataDynamics.ActiveReports.TextBox tBoxDay11 = null;
		private DataDynamics.ActiveReports.TextBox tBoxDay13 = null;
		private DataDynamics.ActiveReports.TextBox tBoxDay14 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.TextBox tBoxPage = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		private DataDynamics.ActiveReports.TextBox TextBox16 = null;
		private DataDynamics.ActiveReports.TextBox TextBox17 = null;
		private DataDynamics.ActiveReports.TextBox TextBox18 = null;
		private DataDynamics.ActiveReports.TextBox TextBox19 = null;
		private DataDynamics.ActiveReports.TextBox TextBox20 = null;
		private DataDynamics.ActiveReports.TextBox TextBox21 = null;
		private DataDynamics.ActiveReports.TextBox TextBox22 = null;
		private DataDynamics.ActiveReports.TextBox TextBox23 = null;
		private DataDynamics.ActiveReports.TextBox TextBox24 = null;
		private DataDynamics.ActiveReports.TextBox TextBox25 = null;
		private DataDynamics.ActiveReports.TextBox TextBox26 = null;
		private DataDynamics.ActiveReports.TextBox TextBox27 = null;
		private DataDynamics.ActiveReports.TextBox TextBox28 = null;
		private DataDynamics.ActiveReports.TextBox TextBox29 = null;
		private DataDynamics.ActiveReports.TextBox TextBox30 = null;
		private DataDynamics.ActiveReports.Label Label20 = null;
		private DataDynamics.ActiveReports.Line Line2 = null;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Reports.MaterialRelease.rptMaterialRelease.rpx");
			this.ReportHeader = ((DataDynamics.ActiveReports.ReportHeader)(this.Sections["ReportHeader"]));
			this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
			this.ReportFooter = ((DataDynamics.ActiveReports.ReportFooter)(this.Sections["ReportFooter"]));
			this.Label1 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[0]));
			this.Label2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
			this.Label3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
			this.Label4 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
			this.Label5 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
			this.Label6 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
			this.Label7 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
			this.Label8 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
			this.Label9 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
			this.Label10 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
			this.Label11 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
			this.Label12 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
			this.Label13 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
			this.Label14 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
			this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
			this.Label16 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[14]));
			this.Label17 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[15]));
			this.Label18 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[16]));
			this.Label19 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[17]));
			this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[18]));
			this.tBoxDate = ((DataDynamics.ActiveReports.TextBox)(this.PageHeader.Controls[19]));
			this.SMSTXL3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.tBoxSMPART = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.tBoxPastDue = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.tBoxDay2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
			this.tBoxDay1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
			this.tBoxDay3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
			this.tBoxDay4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
			this.tBoxDay5 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
			this.tBoxDay6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[9]));
			this.tBoxDay7 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[10]));
			this.tBoxDay8 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[11]));
			this.tBoxDay9 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[12]));
			this.tBoxDay10 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[13]));
			this.tBoxDay12 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[14]));
			this.tBoxDay11 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[15]));
			this.tBoxDay13 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[16]));
			this.tBoxDay14 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[17]));
			this.tBoxPage = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[0]));
			this.TextBox16 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[0]));
			this.TextBox17 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[1]));
			this.TextBox18 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[2]));
			this.TextBox19 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[3]));
			this.TextBox20 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[4]));
			this.TextBox21 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[5]));
			this.TextBox22 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[6]));
			this.TextBox23 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[7]));
			this.TextBox24 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[8]));
			this.TextBox25 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[9]));
			this.TextBox26 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[10]));
			this.TextBox27 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[11]));
			this.TextBox28 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[12]));
			this.TextBox29 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[13]));
			this.TextBox30 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[14]));
			this.Label20 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[15]));
			this.Line2 = ((DataDynamics.ActiveReports.Line)(this.ReportFooter.Controls[16]));
			// Attach Report Events
			this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
		}

		#endregion
	}
}
