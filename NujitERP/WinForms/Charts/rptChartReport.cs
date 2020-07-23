using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using ClassLib.util;

namespace Nujit.NujitERP.WinForms.Charts{

public 
class rptChartReport : ActiveReport{

public 
rptChartReport(System.Drawing.Image image){
	InitializeReport();
	this.picture.Image = image;
}

private 
void PageFooter_Format(object sender, System.EventArgs eArgs){
}

private 
void ReportHeader_Format(object sender, System.EventArgs eArgs){
}

#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox TextBox1 = null;
		private DataDynamics.ActiveReports.Picture picture = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Charts.rptChartReport.rpx");
			this.ReportHeader = ((DataDynamics.ActiveReports.ReportHeader)(this.Sections["ReportHeader"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.ReportFooter = ((DataDynamics.ActiveReports.ReportFooter)(this.Sections["ReportFooter"]));
			this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.picture = ((DataDynamics.ActiveReports.Picture)(this.Detail.Controls[1]));
			// Attach Report Events
			this.ReportHeader.Format += new System.EventHandler(this.ReportHeader_Format);
		}

#endregion

}//end class

}//end namespace
