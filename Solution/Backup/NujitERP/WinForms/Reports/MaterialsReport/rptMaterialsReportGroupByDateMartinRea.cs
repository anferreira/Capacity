using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.WinForms.Reports.MaterialsReport
{
	public class rptMaterialsReportGroupByDateMartinRea : ActiveReport
	{

		private string label;

		public rptMaterialsReportGroupByDateMartinRea()
		{
			InitializeReport();
		}

		public void setLabel(string label){
			this.label = label;
		}

		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
			barLbl1.Text = "                                                                               " + 
				"                                                " +
				"                                                " + 
				"                                                " +
				"                                   " +
				"        ";

			for(int order = 1; order < 11; order++){
				barLbl1.Text += label + " " + order.ToString() + "            ";
				
				switch(order){
				case 3:
					if (label.Equals("Day"))
						barLbl1.Text += "             ";
					else
						barLbl1.Text += "       ";
					break;
				case 4:
					if (label.Equals("Day"))
						barLbl1.Text += "     ";
					break;
				case 5:
					barLbl1.Text += "     ";
					break;
				case 6:
					if (label.Equals("Day"))
						barLbl1.Text += "        ";
					break;
				case 8:
					if (label.Equals("Day"))
						barLbl1.Text += "        ";
					break;
				case 9:
					barLbl1.Text += "     ";
					break;
				case 10:
					if (label.Equals("Day"))
						barLbl1.Text += "        ";
					break;
				case 13:
					barLbl1.Text += "     ";
					break;
				}
			}
			
			barLbl2.Text = "                                                                               " + 
				"                                                " +
				"                                                " + 
				"                                                " +
				"        " +
				"        ";
			
			string[] v = UtilCoreFactory.createCoreFactory().getHotListLogData();
			DateTime begin = DateUtil.parseCompleteDate(v[0], DateUtil.MMDDYYYY);
			if (label.Trim().Equals("Day")){
				lblEnt1.Text = begin.AddDays(0).ToShortDateString();
				lblEnt2.Text = begin.AddDays(1).ToShortDateString();
				lblEnt3.Text = begin.AddDays(2).ToShortDateString();
				lblEnt4.Text = begin.AddDays(3).ToShortDateString();
				lblEnt5.Text = begin.AddDays(4).ToShortDateString();
				lblEnt6.Text = begin.AddDays(5).ToShortDateString();
				lblEnt7.Text = begin.AddDays(6).ToShortDateString();
				lblEnt8.Text = begin.AddDays(7).ToShortDateString();
				lblEnt9.Text = begin.AddDays(8).ToShortDateString();
				lblEnt10.Text = begin.AddDays(9).ToShortDateString();
			}else{
				DateTime end = begin.AddDays(6);
				lblEnt1.Text = DateUtil.getMonthName(begin.Month) + "-" + DateUtil.getMonthName(end.Month);
				barLbl2.Text += "                           " + begin.Day.ToString("00") + "-" + end.Day.ToString("00") + "                  ";

				begin = end.AddDays(1);
				end = begin.AddDays(6);
				lblEnt2.Text = DateUtil.getMonthName(begin.Month) + "-" + DateUtil.getMonthName(end.Month);
				barLbl2.Text += begin.Day.ToString("00") + "-" + end.Day.ToString("00") + "                  ";
				
				begin = end.AddDays(1);
				end = begin.AddDays(6);
				lblEnt3.Text = DateUtil.getMonthName(begin.Month) + "-" + DateUtil.getMonthName(end.Month);
				barLbl2.Text += begin.Day.ToString("00") + "-" + end.Day.ToString("00") + "                  ";
				
				begin = end.AddDays(1);
				end = begin.AddDays(6);
				lblEnt4.Text = DateUtil.getMonthName(begin.Month) + "-" + DateUtil.getMonthName(end.Month);
				barLbl2.Text += begin.Day.ToString("00") + "-" + end.Day.ToString("00") + "                  ";
				
				begin = end.AddDays(1);
				end = begin.AddDays(6);
				lblEnt5.Text = DateUtil.getMonthName(begin.Month) + "-" + DateUtil.getMonthName(end.Month);
				barLbl2.Text += begin.Day.ToString("00") + "-" + end.Day.ToString("00") + "                  ";
				
				begin = end.AddDays(1);
				end = begin.AddDays(6);
				lblEnt6.Text = DateUtil.getMonthName(begin.Month) + "-" + DateUtil.getMonthName(end.Month);
				barLbl2.Text += begin.Day.ToString("00") + "-" + end.Day.ToString("00") + "                  ";
				
				begin = end.AddDays(1);
				end = begin.AddDays(6);
				lblEnt7.Text = DateUtil.getMonthName(begin.Month) + "-" + DateUtil.getMonthName(end.Month);
				barLbl2.Text += begin.Day.ToString("00") + "-" + end.Day.ToString("00") + "                  ";

				begin = end.AddDays(1);
				end = begin.AddDays(6);
				lblEnt8.Text = DateUtil.getMonthName(begin.Month) + "-" + DateUtil.getMonthName(end.Month);
				barLbl2.Text += begin.Day.ToString("00") + "-" + end.Day.ToString("00") + "                  ";

				begin = end.AddDays(1);
				end = begin.AddDays(6);
				lblEnt9.Text = DateUtil.getMonthName(begin.Month) + "-" + DateUtil.getMonthName(end.Month);
				barLbl2.Text += begin.Day.ToString("00") + "-" + end.Day.ToString("00") + "                  ";

				begin = end.AddDays(1);
				end = begin.AddDays(6);
				lblEnt10.Text = DateUtil.getMonthName(begin.Month) + "-" + DateUtil.getMonthName(end.Month);
				barLbl2.Text += begin.Day.ToString("00") + "-" + end.Day.ToString("00") + "                  ";
			}


		}

		private void ReportHeader_Format(object sender, System.EventArgs eArgs)
		{
			this.dateLbl.Text = DateTime.Today.ToShortDateString();

			string[] v = UtilCoreFactory.createCoreFactory().getHotListLogData();

			beginTextBox.Text = v[0];
			endTextBox.Text = v[1];
		}

		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
			pageLbl.Text = this.PageNumber.ToString();
		}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.Label Label1 = null;
		private DataDynamics.ActiveReports.Line Line1 = null;
		private DataDynamics.ActiveReports.Label dateLbl = null;
		private DataDynamics.ActiveReports.Label Label22 = null;
		private DataDynamics.ActiveReports.Label Label23 = null;
		private DataDynamics.ActiveReports.TextBox beginTextBox = null;
		private DataDynamics.ActiveReports.TextBox endTextBox = null;
		private DataDynamics.ActiveReports.Label Label32 = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Label Label31 = null;
		private DataDynamics.ActiveReports.Label Label33 = null;
		private DataDynamics.ActiveReports.Label Label2 = null;
		private DataDynamics.ActiveReports.Label Label3 = null;
		private DataDynamics.ActiveReports.Label Label8 = null;
		private DataDynamics.ActiveReports.Label Label11 = null;
		private DataDynamics.ActiveReports.Label lblEnt1 = null;
		private DataDynamics.ActiveReports.Label lblEnt2 = null;
		private DataDynamics.ActiveReports.Label lblEnt3 = null;
		private DataDynamics.ActiveReports.Label lblEnt4 = null;
		private DataDynamics.ActiveReports.Label lblEnt5 = null;
		private DataDynamics.ActiveReports.Label lblEnt6 = null;
		private DataDynamics.ActiveReports.Label Label19 = null;
		private DataDynamics.ActiveReports.Label lblEnt7 = null;
		private DataDynamics.ActiveReports.Label Label21 = null;
		private DataDynamics.ActiveReports.Label lblEnt8 = null;
		private DataDynamics.ActiveReports.Label lblEnt9 = null;
		private DataDynamics.ActiveReports.Label lblEnt10 = null;
		private DataDynamics.ActiveReports.Label barLbl1 = null;
		private DataDynamics.ActiveReports.Label barLbl2 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox supplierText = null;
		private DataDynamics.ActiveReports.TextBox seqText = null;
		private DataDynamics.ActiveReports.TextBox PastDue = null;
		private DataDynamics.ActiveReports.TextBox Product = null;
		private DataDynamics.ActiveReports.TextBox E1 = null;
		private DataDynamics.ActiveReports.TextBox E2 = null;
		private DataDynamics.ActiveReports.TextBox E3 = null;
		private DataDynamics.ActiveReports.TextBox E4 = null;
		private DataDynamics.ActiveReports.TextBox E5 = null;
		private DataDynamics.ActiveReports.TextBox E6 = null;
		private DataDynamics.ActiveReports.TextBox E7 = null;
		private DataDynamics.ActiveReports.TextBox qohTextBox = null;
		private DataDynamics.ActiveReports.TextBox Ent8 = null;
		private DataDynamics.ActiveReports.TextBox Ent9 = null;
		private DataDynamics.ActiveReports.TextBox Ent10 = null;
		private DataDynamics.ActiveReports.TextBox MaterialDescription = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.Label pageLbl = null;
		private DataDynamics.ActiveReports.Label Label7 = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Reports.MaterialsReport.rptMaterialsReportGroupByDateMartinRea.rpx");
			this.ReportHeader = ((DataDynamics.ActiveReports.ReportHeader)(this.Sections["ReportHeader"]));
			this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
			this.ReportFooter = ((DataDynamics.ActiveReports.ReportFooter)(this.Sections["ReportFooter"]));
			this.Label1 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[0]));
			this.Line1 = ((DataDynamics.ActiveReports.Line)(this.ReportHeader.Controls[1]));
			this.dateLbl = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[2]));
			this.Label22 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[3]));
			this.Label23 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[4]));
			this.beginTextBox = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[5]));
			this.endTextBox = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[6]));
			this.Label32 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[7]));
			this.Label31 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
			this.Label33 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
			this.Label2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
			this.Label3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
			this.Label8 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
			this.Label11 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
			this.lblEnt1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
			this.lblEnt2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
			this.lblEnt3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
			this.lblEnt4 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
			this.lblEnt5 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
			this.lblEnt6 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
			this.Label19 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
			this.lblEnt7 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
			this.Label21 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[14]));
			this.lblEnt8 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[15]));
			this.lblEnt9 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[16]));
			this.lblEnt10 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[17]));
			this.barLbl1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[18]));
			this.barLbl2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[19]));
			this.supplierText = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.seqText = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.PastDue = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.Product = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.E1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
			this.E2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
			this.E3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
			this.E4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
			this.E5 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
			this.E6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[9]));
			this.E7 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[10]));
			this.qohTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[11]));
			this.Ent8 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[12]));
			this.Ent9 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[13]));
			this.Ent10 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[14]));
			this.MaterialDescription = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[15]));
			this.pageLbl = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
			this.Label7 = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[1]));
			// Attach Report Events
			this.Detail.Format += new System.EventHandler(this.Detail_Format);
			this.ReportHeader.Format += new System.EventHandler(this.ReportHeader_Format);
			this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
		}

		#endregion
	}
}
