using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.WinForms.Reports.SchedulingView
{
	public class rptNotScheduledDemands : ActiveReport
	{
		private DateTime dateFrom;
		private DateTime dateTo;
		private string version;
		private string plant;

		public rptNotScheduledDemands()
		{
			InitializeReport();
		}

		public void setValues (DateTime dateFrom, DateTime dateTo, string version, string plant)
		{
			this.dateFrom = dateFrom;
			this.dateTo = dateTo;
			this.version = version;
			this.plant = plant;
		}

		private void ReportHeader_Format(object sender, System.EventArgs eArgs)
		{
			this.txtDateFrom.Text = DateUtil.getDateRepresentation(dateFrom, DateUtil.MMDDYYYY);
			this.txtDateTo.Text = DateUtil.getDateRepresentation(dateTo, DateUtil.MMDDYYYY);
			this.txtPlant.Text = plant;
			this.txtVersion.Text = version;
		}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader;
		private DataDynamics.ActiveReports.Label Label4;
		private DataDynamics.ActiveReports.Label Label5;
		private DataDynamics.ActiveReports.Label Label6;
		private DataDynamics.ActiveReports.TextBox txtDateFrom;
		private DataDynamics.ActiveReports.TextBox txtDateTo;
		private DataDynamics.ActiveReports.Label Label9;
		private DataDynamics.ActiveReports.TextBox txtPlant;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.Line Line2;
		private DataDynamics.ActiveReports.Line Line3;
		private DataDynamics.ActiveReports.Line Line4;
		private DataDynamics.ActiveReports.Label Label19;
		private DataDynamics.ActiveReports.Label Label20;
		private DataDynamics.ActiveReports.TextBox txtVersion;
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label Label21;
		private DataDynamics.ActiveReports.Label Label22;
		private DataDynamics.ActiveReports.Label Label23;
		private DataDynamics.ActiveReports.Label Label24;
		private DataDynamics.ActiveReports.Label Label26;
		private DataDynamics.ActiveReports.Label Label11;
		private DataDynamics.ActiveReports.Label Label12;
		private DataDynamics.ActiveReports.Label Label27;
		private DataDynamics.ActiveReports.Line Line5;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox txtOrderID;
		private DataDynamics.ActiveReports.TextBox txtItemID;
		private DataDynamics.ActiveReports.TextBox txtReleaseID;
		private DataDynamics.ActiveReports.TextBox txtCustomerID;
		private DataDynamics.ActiveReports.TextBox txtCustomerName;
		private DataDynamics.ActiveReports.TextBox txtProdID;
		private DataDynamics.ActiveReports.TextBox txtQty;
		private DataDynamics.ActiveReports.TextBox txtSeq;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Reports.SchedulingView.rptNotScheduledDemands.rpx");
			this.ReportHeader = ((DataDynamics.ActiveReports.ReportHeader)(this.Sections["ReportHeader"]));
			this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
			this.ReportFooter = ((DataDynamics.ActiveReports.ReportFooter)(this.Sections["ReportFooter"]));
			this.Label4 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[0]));
			this.Label5 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[1]));
			this.Label6 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[2]));
			this.txtDateFrom = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[3]));
			this.txtDateTo = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[4]));
			this.Label9 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[5]));
			this.txtPlant = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[6]));
			this.Line1 = ((DataDynamics.ActiveReports.Line)(this.ReportHeader.Controls[7]));
			this.Line2 = ((DataDynamics.ActiveReports.Line)(this.ReportHeader.Controls[8]));
			this.Line3 = ((DataDynamics.ActiveReports.Line)(this.ReportHeader.Controls[9]));
			this.Line4 = ((DataDynamics.ActiveReports.Line)(this.ReportHeader.Controls[10]));
			this.Label19 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[11]));
			this.Label20 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[12]));
			this.txtVersion = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[13]));
			this.Label21 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
			this.Label22 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
			this.Label23 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
			this.Label24 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
			this.Label26 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
			this.Label11 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
			this.Label12 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
			this.Label27 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
			this.Line5 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[8]));
			this.txtOrderID = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.txtItemID = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.txtReleaseID = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.txtCustomerID = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.txtCustomerName = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
			this.txtProdID = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
			this.txtQty = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
			this.txtSeq = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
			// Attach Report Events
			this.ReportHeader.Format += new System.EventHandler(this.ReportHeader_Format);
		}

		#endregion
	}
}
