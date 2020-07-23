using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Nujit.NujitERP.WinForms.Reports.VendorReleaseInquiry{

public 
class rptVRIReport : ActiveReport3{

public 
rptVRIReport(){
	InitializeReport();
}

private 
void PageFooter_Format(object sender, System.EventArgs eArgs){
	this.pageLbl.Text = this.PageNumber.ToString();
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
		private DataDynamics.ActiveReports.Label Label8;
		private DataDynamics.ActiveReports.Label Label9;
		private DataDynamics.ActiveReports.Label Label10;
		private DataDynamics.ActiveReports.Label Label11;
		private DataDynamics.ActiveReports.Label Label12;
		private DataDynamics.ActiveReports.Label Label13;
		private DataDynamics.ActiveReports.Label Label14;
		private DataDynamics.ActiveReports.Label Label15;
		private DataDynamics.ActiveReports.Label Label16;
		private DataDynamics.ActiveReports.Label Label17;
		private DataDynamics.ActiveReports.Label Label18;
		private DataDynamics.ActiveReports.Label Label19;
		private DataDynamics.ActiveReports.Label Label20;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox supplierText;
		private DataDynamics.ActiveReports.TextBox seqText;
		private DataDynamics.ActiveReports.TextBox descText;
		private DataDynamics.ActiveReports.TextBox PastDue;
		private DataDynamics.ActiveReports.TextBox Product;
		private DataDynamics.ActiveReports.TextBox Cat;
		private DataDynamics.ActiveReports.TextBox Release;
		private DataDynamics.ActiveReports.TextBox E1;
		private DataDynamics.ActiveReports.TextBox E2;
		private DataDynamics.ActiveReports.TextBox E3;
		private DataDynamics.ActiveReports.TextBox E4;
		private DataDynamics.ActiveReports.TextBox E5;
		private DataDynamics.ActiveReports.TextBox E6;
		private DataDynamics.ActiveReports.TextBox E7;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.Label pageLbl;
		private DataDynamics.ActiveReports.Label Label7;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Reports.VendorReleaseInquiry.rptVRIReport.rpx");
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
			this.Label8 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
			this.Label9 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
			this.Label10 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
			this.Label11 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
			this.Label12 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
			this.Label13 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
			this.Label14 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
			this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
			this.Label16 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
			this.Label17 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
			this.Label18 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
			this.Label19 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[14]));
			this.Label20 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[15]));
			this.supplierText = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.seqText = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.descText = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.PastDue = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.Product = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
			this.Cat = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
			this.Release = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
			this.E1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
			this.E2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
			this.E3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[9]));
			this.E4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[10]));
			this.E5 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[11]));
			this.E6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[12]));
			this.E7 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[13]));
			this.pageLbl = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
			this.Label7 = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[1]));
			// Attach Report Events
			this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
		}

#endregion

public void setLabels(string type){
	Label12.Text = type + "1";
	Label13.Text = type + "2";
	Label14.Text = type + "3";
	Label15.Text = type + "4";
	Label16.Text = type + "5";
	Label17.Text = type + "6";
	Label20.Text = type + "7";
	dateLbl.Text = DateTime.Today.ToShortDateString();
}

} //class
} // namespace
