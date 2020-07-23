using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.WinForms.Reports.MaterialsReport
{
	
	public 
		class rptMaterialsReportGroupByDateVendorExc : ActiveReport3
	{

		private string label;
		private string[] logData = null;

		public 
			rptMaterialsReportGroupByDateVendorExc()
		{
			logData = UtilCoreFactory.createCoreFactory().getHotListLogData();
			InitializeReport();
		}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.Label Label1 = null;
		private DataDynamics.ActiveReports.Label dateLbl = null;
		private DataDynamics.ActiveReports.Label Label22 = null;
		private DataDynamics.ActiveReports.Label Label23 = null;
		private DataDynamics.ActiveReports.TextBox beginTextBox = null;
		private DataDynamics.ActiveReports.TextBox endTextBox = null;
		private DataDynamics.ActiveReports.Label Label32 = null;
		private DataDynamics.ActiveReports.Label Label2 = null;
		private DataDynamics.ActiveReports.Label Label11 = null;
		private DataDynamics.ActiveReports.Label Label12 = null;
		private DataDynamics.ActiveReports.Label Label13 = null;
		private DataDynamics.ActiveReports.Label Label14 = null;
		private DataDynamics.ActiveReports.Label Label15 = null;
		private DataDynamics.ActiveReports.Label Label16 = null;
		private DataDynamics.ActiveReports.Label Label17 = null;
		private DataDynamics.ActiveReports.Label Label20 = null;
		private DataDynamics.ActiveReports.Label Label21 = null;
		private DataDynamics.ActiveReports.Label Label24 = null;
		private DataDynamics.ActiveReports.Label Label25 = null;
		private DataDynamics.ActiveReports.Label Label26 = null;
		private DataDynamics.ActiveReports.Label Label27 = null;
		private DataDynamics.ActiveReports.Label Label28 = null;
		private DataDynamics.ActiveReports.Label Label29 = null;
		private DataDynamics.ActiveReports.Label Label30 = null;
		private DataDynamics.ActiveReports.Label Label33 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
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
		private DataDynamics.ActiveReports.TextBox Ent11 = null;
		private DataDynamics.ActiveReports.TextBox Ent21 = null;
		private DataDynamics.ActiveReports.TextBox Ent31 = null;
		private DataDynamics.ActiveReports.TextBox Ent41 = null;
		private DataDynamics.ActiveReports.TextBox Ent51 = null;
		private DataDynamics.ActiveReports.TextBox Ent61 = null;
		private DataDynamics.ActiveReports.TextBox Ent71 = null;
		private DataDynamics.ActiveReports.TextBox supplierText = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Reports.MaterialsReport.rptMaterialsReportGroupByDateVend" +
	"orExc.rpx");
			this.ReportHeader = ((DataDynamics.ActiveReports.ReportHeader)(this.Sections["ReportHeader"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.ReportFooter = ((DataDynamics.ActiveReports.ReportFooter)(this.Sections["ReportFooter"]));
			this.Label1 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[0]));
			this.dateLbl = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[1]));
			this.Label22 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[2]));
			this.Label23 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[3]));
			this.beginTextBox = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[4]));
			this.endTextBox = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[5]));
			this.Label32 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[6]));
			this.Label2 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[7]));
			this.Label11 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[8]));
			this.Label12 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[9]));
			this.Label13 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[10]));
			this.Label14 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[11]));
			this.Label15 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[12]));
			this.Label16 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[13]));
			this.Label17 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[14]));
			this.Label20 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[15]));
			this.Label21 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[16]));
			this.Label24 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[17]));
			this.Label25 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[18]));
			this.Label26 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[19]));
			this.Label27 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[20]));
			this.Label28 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[21]));
			this.Label29 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[22]));
			this.Label30 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[23]));
			this.Label33 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[24]));
			this.PastDue = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.Product = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.E1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.E2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.E3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
			this.E4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
			this.E5 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
			this.E6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
			this.E7 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
			this.qohTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[9]));
			this.Ent11 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[10]));
			this.Ent21 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[11]));
			this.Ent31 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[12]));
			this.Ent41 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[13]));
			this.Ent51 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[14]));
			this.Ent61 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[15]));
			this.Ent71 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[16]));
			this.supplierText = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[17]));
			// Attach Report Events
			this.Detail.Format += new System.EventHandler(this.Detail_Format);
			this.ReportHeader.Format += new System.EventHandler(this.ReportHeader_Format);
		}

		#endregion

		public 
			void setLabel(string label)
		{
			this.label = label;
		}

		private 
			void Detail_Format(object sender, System.EventArgs eArgs)
		{
		}

		private 
			void ReportHeader_Format(object sender, System.EventArgs eArgs)
		{
			this.dateLbl.Text = DateTime.Today.ToShortDateString();

			string[] v = UtilCoreFactory.createCoreFactory().getHotListLogData();

			beginTextBox.Text = v[0];
			endTextBox.Text = v[1];

			DateTime begin = DateUtil.parseCompleteDate(logData[0], DateUtil.MMDDYYYY);

			if (label.Trim().Equals("Day"))
			{
				Label12.Text = begin.AddDays(0).ToShortDateString();
				Label13.Text = begin.AddDays(1).ToShortDateString();
				Label14.Text = begin.AddDays(2).ToShortDateString();
				Label15.Text = begin.AddDays(3).ToShortDateString();
				Label16.Text = begin.AddDays(4).ToShortDateString();
				Label17.Text = begin.AddDays(5).ToShortDateString();
				Label20.Text = begin.AddDays(6).ToShortDateString();
				Label24.Text = begin.AddDays(7).ToShortDateString();
				Label25.Text = begin.AddDays(8).ToShortDateString();
				Label26.Text = begin.AddDays(9).ToShortDateString();
				Label27.Text = begin.AddDays(10).ToShortDateString();
				Label28.Text = begin.AddDays(11).ToShortDateString();
				Label29.Text = begin.AddDays(12).ToShortDateString();
				Label30.Text = begin.AddDays(13).ToShortDateString();
			}
			else
			{
				DateTime end = begin.AddDays(6);
				Label12.Text = "Week1";

				begin = end.AddDays(1);
				end = begin.AddDays(6);
				Label13.Text = "Week2";
		
				begin = end.AddDays(1);
				end = begin.AddDays(6);
				Label14.Text = "Week3";
		
				begin = end.AddDays(1);
				end = begin.AddDays(6);
				Label15.Text = "Week4";
		
				begin = end.AddDays(1);
				end = begin.AddDays(6);
				Label16.Text = "Week5";
		
				begin = end.AddDays(1);
				end = begin.AddDays(6);
				Label17.Text = "Week6";
		
				begin = end.AddDays(1);
				end = begin.AddDays(6);
				Label20.Text = "Week7";

				begin = end.AddDays(1);
				end = begin.AddDays(6);
				Label24.Text = "Week8";
	
				begin = end.AddDays(1);
				end = begin.AddDays(6);
				Label25.Text = "Week9";
	
				begin = end.AddDays(1);
				end = begin.AddDays(6);
				Label26.Text = "Week10";
	
				begin = end.AddDays(1);
				end = begin.AddDays(6);
				Label27.Text = "Week11";
	
				begin = end.AddDays(1);
				end = begin.AddDays(6);
				Label28.Text = "Week12";
	
				begin = end.AddDays(1);
				end = begin.AddDays(6);
				Label29.Text = "Week13";
	
				begin = end.AddDays(1);
				end = begin.AddDays(6);
				Label30.Text = "Week14";
			}
		}

		private 
			void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
		}

		private 
			void GroupFooter1_AfterPrint(object sender, System.EventArgs eArgs)
		{
		}

		private 
			void GroupFooter1_Format(object sender, System.EventArgs eArgs)
		{
		}

	}

}
