using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.WinForms.Reports.MaterialsReport
{
public class rptMaterialsReport : ActiveReport3
{
public rptMaterialsReport(){
	InitializeReport();
}

private void PageFooter_Format(object sender, System.EventArgs eArgs){
	this.lblPage.Text = "Page: " + this.PageNumber.ToString();
}

private 
void PageHeader_Format(object sender, System.EventArgs eArgs){
	this.lblDateHour.Text +=" " + DateUtil.getCompleteDateRepresentation(DateTime.Now,DateUtil.MMDDYYYY);
}

#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.Label Label1 = null;
		private DataDynamics.ActiveReports.Line Line4 = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Label Label17 = null;
		private DataDynamics.ActiveReports.Label Label14 = null;
		private DataDynamics.ActiveReports.Label Label18 = null;
		private DataDynamics.ActiveReports.Label Label11 = null;
		private DataDynamics.ActiveReports.Label Label15 = null;
		private DataDynamics.ActiveReports.Label Label16 = null;
		private DataDynamics.ActiveReports.Label Label13 = null;
		private DataDynamics.ActiveReports.Label lblDateHour = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1 = null;
		private DataDynamics.ActiveReports.TextBox txtParentPart = null;
		private DataDynamics.ActiveReports.Label Label19 = null;
		private DataDynamics.ActiveReports.TextBox txtMaterial = null;
		private DataDynamics.ActiveReports.TextBox txtMaterialDescription = null;
		private DataDynamics.ActiveReports.TextBox LeadTime = null;
		private DataDynamics.ActiveReports.Label leadTimeLabel = null;
		private DataDynamics.ActiveReports.Label daysLabel = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader2 = null;
		private DataDynamics.ActiveReports.TextBox DateRequired1 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox txtAllocatedQty = null;
		private DataDynamics.ActiveReports.TextBox txtQtyReq = null;
		private DataDynamics.ActiveReports.TextBox Material3 = null;
		private DataDynamics.ActiveReports.TextBox DateRequired2 = null;
		private DataDynamics.ActiveReports.TextBox txtSchMatReq = null;
		private DataDynamics.ActiveReports.TextBox qohTextBox = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter2 = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.Label lblPage = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Reports.MaterialsReport.rptMaterialsReport.rpx");
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
			this.Line4 = ((DataDynamics.ActiveReports.Line)(this.ReportHeader.Controls[1]));
			this.Label17 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
			this.Label14 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
			this.Label18 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
			this.Label11 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
			this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
			this.Label16 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
			this.Label13 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
			this.lblDateHour = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
			this.txtParentPart = ((DataDynamics.ActiveReports.TextBox)(this.GroupHeader1.Controls[0]));
			this.Label19 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[1]));
			this.txtMaterial = ((DataDynamics.ActiveReports.TextBox)(this.GroupHeader1.Controls[2]));
			this.txtMaterialDescription = ((DataDynamics.ActiveReports.TextBox)(this.GroupHeader1.Controls[3]));
			this.LeadTime = ((DataDynamics.ActiveReports.TextBox)(this.GroupHeader1.Controls[4]));
			this.leadTimeLabel = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[5]));
			this.daysLabel = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[6]));
			this.DateRequired1 = ((DataDynamics.ActiveReports.TextBox)(this.GroupHeader2.Controls[0]));
			this.txtAllocatedQty = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.txtQtyReq = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.Material3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.DateRequired2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.txtSchMatReq = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
			this.qohTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
			this.lblPage = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
			// Attach Report Events
			this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
		}

#endregion
}
}
