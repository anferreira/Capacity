using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Nujit.NujitERP.WinForms.Reports.BOMReport
{
	public class BOMReport : ActiveReport3
	{
		private string prodId;
		private int seqId;
		private decimal Qoh;
		private bool final;

		public BOMReport()
		{
			InitializeReport();
		}

		public void setValues(string prodId, int seqId, decimal Qoh, bool final){
			this.prodId = prodId;
			this.seqId = seqId;
			this.Qoh = Qoh;
			this.final = final;
		
		}

		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
			//qtySum = qtySum + this.
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			lbDate.Text = "Date: " + DateTime.Now.ToShortDateString();
			lbProdId.Text = prodId;
			lbSeqId.Text = seqId.ToString();
			lbPage.Text = "Page " + this.PageNumber.ToString();
			if (final)
				lbFinalProds.Text = "Report shows final products only";
		}

		private void BOMReport_ReportStart(object sender, System.EventArgs eArgs)
		{
			
		}

		private void ReportFooter_Format(object sender, System.EventArgs eArgs)
		{
			txtQoh.Text = Qoh.ToString();
		}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Label Label1 = null;
		private DataDynamics.ActiveReports.TextBox TextBox1 = null;
		private DataDynamics.ActiveReports.Label Label2 = null;
		private DataDynamics.ActiveReports.Label Label3 = null;
		private DataDynamics.ActiveReports.Label lbDate = null;
		private DataDynamics.ActiveReports.Label lbProdId = null;
		private DataDynamics.ActiveReports.Label lbSeqId = null;
		private DataDynamics.ActiveReports.Label lbPage = null;
		private DataDynamics.ActiveReports.TextBox TextBox4 = null;
		private DataDynamics.ActiveReports.TextBox TextBox2 = null;
		private DataDynamics.ActiveReports.TextBox TextBox3 = null;
		private DataDynamics.ActiveReports.Label lbFinalProds = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox txtProdId = null;
		private DataDynamics.ActiveReports.TextBox txtSeqId = null;
		private DataDynamics.ActiveReports.TextBox txtQty = null;
		private DataDynamics.ActiveReports.TextBox MaterialID1 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		private DataDynamics.ActiveReports.Label Label4 = null;
		private DataDynamics.ActiveReports.TextBox qtySum = null;
		private DataDynamics.ActiveReports.Label Label5 = null;
		private DataDynamics.ActiveReports.TextBox txtMatCount = null;
		private DataDynamics.ActiveReports.Line Line1 = null;
		private DataDynamics.ActiveReports.Label Label6 = null;
		private DataDynamics.ActiveReports.TextBox txtQoh = null;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Reports.BOMReport.BOMReport.rpx");
			this.ReportHeader = ((DataDynamics.ActiveReports.ReportHeader)(this.Sections["ReportHeader"]));
			this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
			this.ReportFooter = ((DataDynamics.ActiveReports.ReportFooter)(this.Sections["ReportFooter"]));
			this.Label1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
			this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.PageHeader.Controls[1]));
			this.Label2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
			this.Label3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
			this.lbDate = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
			this.lbProdId = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
			this.lbSeqId = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
			this.lbPage = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
			this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.PageHeader.Controls[8]));
			this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.PageHeader.Controls[9]));
			this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.PageHeader.Controls[10]));
			this.lbFinalProds = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
			this.txtProdId = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.txtSeqId = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.txtQty = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.MaterialID1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.Label4 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[0]));
			this.qtySum = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[1]));
			this.Label5 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[2]));
			this.txtMatCount = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[3]));
			this.Line1 = ((DataDynamics.ActiveReports.Line)(this.ReportFooter.Controls[4]));
			this.Label6 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[5]));
			this.txtQoh = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[6]));
			// Attach Report Events
			this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
			this.Detail.Format += new System.EventHandler(this.Detail_Format);
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
			this.ReportStart += new System.EventHandler(this.BOMReport_ReportStart);
			this.ReportFooter.Format += new System.EventHandler(this.ReportFooter_Format);
		}

		#endregion
	}
}
