using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.WinForms.Charts{

public 
class rptChartReport : ActiveReport3{

private System.Drawing.Image[] images;
private int index = 0;

public 
rptChartReport(System.Drawing.Image[] images){
	InitializeReport();
	//this.picture.Image = image;
	this.images = images;
}

private 
void PageFooter_Format(object sender, System.EventArgs eArgs){
}

private 
void ReportHeader_Format(object sender, System.EventArgs eArgs){
}

private 
void Detail_BeforePrint(object sender, System.EventArgs eArgs){
	this.picture1.Visible = false;
	this.picture2.Visible = false;
	this.picture3.Visible = false;

	if ((images.Length > index) && (images[index] != null)){
		this.picture1.Visible = true;
		this.picture1.Image = images[index];

		if (images.Length == 1)
			this.picture1.Height = this.picture1.Height * 3;
	}
	index++;
	
	if ((images.Length > index) && (images[index] != null)){
		this.picture2.Visible = true;
		this.picture2.Image = images[index];
	}
	index++;
	
	if ((images.Length > index) && (images[index] != null)){
		this.picture3.Visible = true;
		this.picture3.Image = images[index];
	}
	index++;
}

#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox TextBox1 = null;
		private DataDynamics.ActiveReports.Picture picture1 = null;
		private DataDynamics.ActiveReports.Picture picture2 = null;
		private DataDynamics.ActiveReports.Picture picture3 = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Charts.rptChartReport.rpx");
			this.ReportHeader = ((DataDynamics.ActiveReports.ReportHeader)(this.Sections["ReportHeader"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.ReportFooter = ((DataDynamics.ActiveReports.ReportFooter)(this.Sections["ReportFooter"]));
			this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.picture1 = ((DataDynamics.ActiveReports.Picture)(this.Detail.Controls[1]));
			this.picture2 = ((DataDynamics.ActiveReports.Picture)(this.Detail.Controls[2]));
			this.picture3 = ((DataDynamics.ActiveReports.Picture)(this.Detail.Controls[3]));
			// Attach Report Events
			this.ReportHeader.Format += new System.EventHandler(this.ReportHeader_Format);
			this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
		}

#endregion

}//end class

}//end namespace
