using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.WinForms.Reports.SchedulingView
{
	public class rptScheduleInMachineReport : ActiveReport3
	{
		private DateTime dateFrom;
		private DateTime dateTo;
		private string version;
		private string plant;
		private string department;
		private string machine;

		public rptScheduleInMachineReport()
		{
			InitializeReport();
		}

		public void setValues (DateTime dateFrom, DateTime dateTo, string version, string plant, string department, string machine)
		{
			this.dateFrom = dateFrom;
			this.dateTo = dateTo;
			this.version = version;
			this.plant = plant;
			this.department = department;
			this.machine = machine;
		}

		private void ReportHeader_Format(object sender, System.EventArgs eArgs)
		{
			this.txtDateFrom.Text = DateUtil.getDateRepresentation(dateFrom, DateUtil.MMDDYYYY);
			this.txtDateTo.Text = DateUtil.getDateRepresentation(dateTo, DateUtil.MMDDYYYY);
			this.txtPlant.Text = plant;
			this.txtVersion.Text = version;
			this.txtDept.Text = department;
			this.txtMachine.Text = machine;
		}

		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
			double perc = 0;
			if ((this.Fields["QtyAcumulated"].Value != null) && (this.Fields["QtyGoal"].Value != null))
			{
				if ((double)this.Fields["QtyGoal"].Value > 0)
				{
					perc = (double)this.Fields["QtyAcumulated"].Value / (double)this.Fields["QtyGoal"].Value * 100;
					this.txtPercentage.Text = perc.ToString ("0.00") + " %";
				}
				else
					this.txtPercentage.Text = "--------";
			}
		}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader;
		private DataDynamics.ActiveReports.Label Label4;
		private DataDynamics.ActiveReports.Label Label5;
		private DataDynamics.ActiveReports.Label Label6;
		private DataDynamics.ActiveReports.TextBox txtDateFrom;
		private DataDynamics.ActiveReports.TextBox txtDateTo;
		private DataDynamics.ActiveReports.Label Label7;
		private DataDynamics.ActiveReports.Label Label8;
		private DataDynamics.ActiveReports.Label Label9;
		private DataDynamics.ActiveReports.TextBox txtPlant;
		private DataDynamics.ActiveReports.TextBox txtDept;
		private DataDynamics.ActiveReports.TextBox txtMachine;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.Line Line2;
		private DataDynamics.ActiveReports.Line Line3;
		private DataDynamics.ActiveReports.Line Line4;
		private DataDynamics.ActiveReports.Label Label19;
		private DataDynamics.ActiveReports.Label Label20;
		private DataDynamics.ActiveReports.TextBox txtVersion;
		private DataDynamics.ActiveReports.GroupHeader ghDate;
		private DataDynamics.ActiveReports.Label Label10;
		private DataDynamics.ActiveReports.TextBox txtCurrentDay;
		private DataDynamics.ActiveReports.Label Label11;
		private DataDynamics.ActiveReports.Label Label12;
		private DataDynamics.ActiveReports.Label Label13;
		private DataDynamics.ActiveReports.Label lblTo;
		private DataDynamics.ActiveReports.Label lblHours;
		private DataDynamics.ActiveReports.Label Label18;
		private DataDynamics.ActiveReports.Label Label22;
		private DataDynamics.ActiveReports.Label Label23;
		private DataDynamics.ActiveReports.Line Line6;
		private DataDynamics.ActiveReports.Label Label24;
		private DataDynamics.ActiveReports.Label Label21;
		private DataDynamics.ActiveReports.Line Line5;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox txtPart;
		private DataDynamics.ActiveReports.TextBox txtSeq;
		private DataDynamics.ActiveReports.TextBox txtFrom;
		private DataDynamics.ActiveReports.TextBox txtTo;
		private DataDynamics.ActiveReports.TextBox txtHours;
		private DataDynamics.ActiveReports.TextBox txtProduced;
		private DataDynamics.ActiveReports.TextBox txtAcumulated;
		private DataDynamics.ActiveReports.TextBox txtPercentage;
		private DataDynamics.ActiveReports.TextBox txtGoal;
		private DataDynamics.ActiveReports.GroupFooter gfDate;
		private DataDynamics.ActiveReports.Line Line7;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Reports.SchedulingView.rptScheduleInMachineReport.rpx");
			this.ReportHeader = ((DataDynamics.ActiveReports.ReportHeader)(this.Sections["ReportHeader"]));
			this.ghDate = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghDate"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.gfDate = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfDate"]));
			this.ReportFooter = ((DataDynamics.ActiveReports.ReportFooter)(this.Sections["ReportFooter"]));
			this.Label4 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[0]));
			this.Label5 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[1]));
			this.Label6 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[2]));
			this.txtDateFrom = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[3]));
			this.txtDateTo = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[4]));
			this.Label7 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[5]));
			this.Label8 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[6]));
			this.Label9 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[7]));
			this.txtPlant = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[8]));
			this.txtDept = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[9]));
			this.txtMachine = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[10]));
			this.Line1 = ((DataDynamics.ActiveReports.Line)(this.ReportHeader.Controls[11]));
			this.Line2 = ((DataDynamics.ActiveReports.Line)(this.ReportHeader.Controls[12]));
			this.Line3 = ((DataDynamics.ActiveReports.Line)(this.ReportHeader.Controls[13]));
			this.Line4 = ((DataDynamics.ActiveReports.Line)(this.ReportHeader.Controls[14]));
			this.Label19 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[15]));
			this.Label20 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[16]));
			this.txtVersion = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[17]));
			this.Label10 = ((DataDynamics.ActiveReports.Label)(this.ghDate.Controls[0]));
			this.txtCurrentDay = ((DataDynamics.ActiveReports.TextBox)(this.ghDate.Controls[1]));
			this.Label11 = ((DataDynamics.ActiveReports.Label)(this.ghDate.Controls[2]));
			this.Label12 = ((DataDynamics.ActiveReports.Label)(this.ghDate.Controls[3]));
			this.Label13 = ((DataDynamics.ActiveReports.Label)(this.ghDate.Controls[4]));
			this.lblTo = ((DataDynamics.ActiveReports.Label)(this.ghDate.Controls[5]));
			this.lblHours = ((DataDynamics.ActiveReports.Label)(this.ghDate.Controls[6]));
			this.Label18 = ((DataDynamics.ActiveReports.Label)(this.ghDate.Controls[7]));
			this.Label22 = ((DataDynamics.ActiveReports.Label)(this.ghDate.Controls[8]));
			this.Label23 = ((DataDynamics.ActiveReports.Label)(this.ghDate.Controls[9]));
			this.Line6 = ((DataDynamics.ActiveReports.Line)(this.ghDate.Controls[10]));
			this.Label24 = ((DataDynamics.ActiveReports.Label)(this.ghDate.Controls[11]));
			this.Label21 = ((DataDynamics.ActiveReports.Label)(this.ghDate.Controls[12]));
			this.Line5 = ((DataDynamics.ActiveReports.Line)(this.ghDate.Controls[13]));
			this.txtPart = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.txtSeq = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.txtFrom = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.txtTo = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.txtHours = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
			this.txtProduced = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
			this.txtAcumulated = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
			this.txtPercentage = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
			this.txtGoal = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
			this.Line7 = ((DataDynamics.ActiveReports.Line)(this.gfDate.Controls[0]));
			// Attach Report Events
			this.ReportHeader.Format += new System.EventHandler(this.ReportHeader_Format);
			this.Detail.Format += new System.EventHandler(this.Detail_Format);
		}

		#endregion
	}
}
