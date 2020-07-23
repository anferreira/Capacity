using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.WinForms.Reports.ProductsReport{

public class rptProductReport : ActiveReport3 {

public rptProductReport(){
			InitializeReport();
			
}

#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader;
		private DataDynamics.ActiveReports.Label Label1;
		private DataDynamics.ActiveReports.Label Label2;
		private DataDynamics.ActiveReports.TextBox txtMinMajorG;
		private DataDynamics.ActiveReports.Label Label3;
		private DataDynamics.ActiveReports.TextBox txtMaxMajorGroup;
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1;
		private DataDynamics.ActiveReports.Label Label4;
		private DataDynamics.ActiveReports.TextBox txtPFS_MajorGroup;
		private DataDynamics.ActiveReports.Label Label6;
		private DataDynamics.ActiveReports.Label Label7;
		private DataDynamics.ActiveReports.Label Label8;
		private DataDynamics.ActiveReports.Label Label9;
		private DataDynamics.ActiveReports.Label Label10;
		private DataDynamics.ActiveReports.Label Label11;
		private DataDynamics.ActiveReports.Label Label12;
		private DataDynamics.ActiveReports.Label Label13;
		private DataDynamics.ActiveReports.Label Label14;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader2;
		private DataDynamics.ActiveReports.Label Label15;
		private DataDynamics.ActiveReports.Label Label16;
		private DataDynamics.ActiveReports.Label Label17;
		private DataDynamics.ActiveReports.Label Label18;
		private DataDynamics.ActiveReports.Label Label19;
		private DataDynamics.ActiveReports.Label Label20;
		private DataDynamics.ActiveReports.Label Label21;
		private DataDynamics.ActiveReports.Label Label22;
		private DataDynamics.ActiveReports.Label Label23;
		private DataDynamics.ActiveReports.Line Line2;
		private DataDynamics.ActiveReports.TextBox txtPFS_MinorGroup;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox txtPFS_ProdID;
		private DataDynamics.ActiveReports.TextBox TextBox3;
		private DataDynamics.ActiveReports.TextBox TextBox4;
		private DataDynamics.ActiveReports.TextBox TextBox5;
		private DataDynamics.ActiveReports.TextBox TextBox6;
		private DataDynamics.ActiveReports.TextBox TextBox7;
		private DataDynamics.ActiveReports.TextBox TextBox8;
		private DataDynamics.ActiveReports.TextBox TextBox9;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter2;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Reports.ProductsReport.rptProductReport.rpx");
			this.ReportHeader = ((DataDynamics.ActiveReports.ReportHeader)(this.Sections["ReportHeader"]));
			this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
			this.GroupHeader1 = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["GroupHeader1"]));
			this.GroupHeader2 = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["GroupHeader2"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.GroupFooter2 = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["GroupFooter2"]));
			this.GroupFooter1 = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["GroupFooter1"]));
			this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
			this.ReportFooter = ((DataDynamics.ActiveReports.ReportFooter)(this.Sections["ReportFooter"]));
			this.Label1 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[0]));
			this.Label2 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[1]));
			this.txtMinMajorG = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[2]));
			this.Label3 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[3]));
			this.txtMaxMajorGroup = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[4]));
			this.Label4 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[0]));
			this.txtPFS_MajorGroup = ((DataDynamics.ActiveReports.TextBox)(this.GroupHeader1.Controls[1]));
			this.Label6 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[2]));
			this.Label7 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[3]));
			this.Label8 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[4]));
			this.Label9 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[5]));
			this.Label10 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[6]));
			this.Label11 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[7]));
			this.Label12 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[8]));
			this.Label13 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[9]));
			this.Label14 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[10]));
			this.Line1 = ((DataDynamics.ActiveReports.Line)(this.GroupHeader1.Controls[11]));
			this.Label15 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader2.Controls[0]));
			this.Label16 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader2.Controls[1]));
			this.Label17 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader2.Controls[2]));
			this.Label18 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader2.Controls[3]));
			this.Label19 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader2.Controls[4]));
			this.Label20 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader2.Controls[5]));
			this.Label21 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader2.Controls[6]));
			this.Label22 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader2.Controls[7]));
			this.Label23 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader2.Controls[8]));
			this.Line2 = ((DataDynamics.ActiveReports.Line)(this.GroupHeader2.Controls[9]));
			this.txtPFS_MinorGroup = ((DataDynamics.ActiveReports.TextBox)(this.GroupHeader2.Controls[10]));
			this.txtPFS_ProdID = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.TextBox5 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.TextBox6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
			this.TextBox7 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
			this.TextBox8 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
			this.TextBox9 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
		}

#endregion

public void setLabels(string infMajorG,string supMajorG){

	this.txtMinMajorG.Text = infMajorG;
	this.txtMaxMajorGroup.Text = supMajorG;
	
}

}//end class
}//end namespace
