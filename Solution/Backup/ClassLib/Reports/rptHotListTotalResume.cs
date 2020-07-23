using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using System.Collections;

namespace Nujit.NujitERP.ClassLib.Reports{
	

public 
class rptHotListTotalResume : ActiveReport{


public 
rptHotListTotalResume(){		
	InitializeReport();
}

~rptHotListTotalResume(){
}
	
private 
void ReportFooter_Format(object sender, System.EventArgs eArgs){
}

private 
void Detail_Format(object sender, System.EventArgs eArgs){
}

private 
void PageHeader_Format(object sender, System.EventArgs eArgs){
}

private 
void PageFooter_BeforePrint(object sender, System.EventArgs eArgs){
	pageTextBox.Text = this.PageNumber.ToString();
}

private 
void Detail_AfterPrint(object sender, System.EventArgs eArgs){
}

private 
void Detail_BeforePrint(object sender, System.EventArgs eArgs){
}

#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.Label lblHeader = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Label Label5 = null;
		private DataDynamics.ActiveReports.Label lblPastDue = null;
		private DataDynamics.ActiveReports.Label Label9 = null;
		public DataDynamics.ActiveReports.Label lblDay002 = null;
		public DataDynamics.ActiveReports.Label lblDay003 = null;
		private DataDynamics.ActiveReports.Label lblDay004 = null;
		private DataDynamics.ActiveReports.Label lblDay005 = null;
		private DataDynamics.ActiveReports.Label lblDay006 = null;
		private DataDynamics.ActiveReports.Label lblDay007 = null;
		private DataDynamics.ActiveReports.Label lblDay008 = null;
		private DataDynamics.ActiveReports.Label lblDay009 = null;
		private DataDynamics.ActiveReports.Label lblDay010 = null;
		private DataDynamics.ActiveReports.Label lblDay011 = null;
		private DataDynamics.ActiveReports.Label lblDay012 = null;
		private DataDynamics.ActiveReports.Label lblDay013 = null;
		private DataDynamics.ActiveReports.Label lblDay014 = null;
		private DataDynamics.ActiveReports.Line Line1 = null;
		private DataDynamics.ActiveReports.Label lblTitulo = null;
		private DataDynamics.ActiveReports.Label Label33 = null;
		private DataDynamics.ActiveReports.Label Label34 = null;
		private DataDynamics.ActiveReports.Label Label35 = null;
		private DataDynamics.ActiveReports.Label Label36 = null;
		private DataDynamics.ActiveReports.Label Label37 = null;
		private DataDynamics.ActiveReports.Label Label38 = null;
		private DataDynamics.ActiveReports.Label Label39 = null;
		private DataDynamics.ActiveReports.Label Label40 = null;
		private DataDynamics.ActiveReports.Label Label41 = null;
		private DataDynamics.ActiveReports.Label Label42 = null;
		private DataDynamics.ActiveReports.Label Label43 = null;
		private DataDynamics.ActiveReports.Label Label44 = null;
		private DataDynamics.ActiveReports.Label Label45 = null;
		private DataDynamics.ActiveReports.Label Label46 = null;
		private DataDynamics.ActiveReports.Label Label47 = null;
		private DataDynamics.ActiveReports.Label Label48 = null;
		private DataDynamics.ActiveReports.Label Label49 = null;
		private DataDynamics.ActiveReports.Label Label51 = null;
		private DataDynamics.ActiveReports.Label Label52 = null;
		private DataDynamics.ActiveReports.Label Label53 = null;
		private DataDynamics.ActiveReports.Label lblTit2 = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox pastDueProgressTextBox = null;
		private DataDynamics.ActiveReports.TextBox day001ProgressTextBox = null;
		private DataDynamics.ActiveReports.TextBox day002ProgressTextBox = null;
		private DataDynamics.ActiveReports.TextBox day003ProgressTextBox = null;
		private DataDynamics.ActiveReports.TextBox day004ProgressTextBox = null;
		private DataDynamics.ActiveReports.TextBox day005ProgressTextBox = null;
		private DataDynamics.ActiveReports.TextBox day006ProgressTextBox = null;
		private DataDynamics.ActiveReports.TextBox day007ProgressTextBox = null;
		private DataDynamics.ActiveReports.TextBox day008ProgressTextBox = null;
		private DataDynamics.ActiveReports.TextBox day009ProgressTextBox = null;
		private DataDynamics.ActiveReports.TextBox day010ProgressTextBox = null;
		private DataDynamics.ActiveReports.TextBox day011ProgressTextBox = null;
		private DataDynamics.ActiveReports.TextBox day012ProgressTextBox = null;
		private DataDynamics.ActiveReports.TextBox day013ProgressTextBox = null;
		private DataDynamics.ActiveReports.TextBox day014ProgressTextBox = null;
		private DataDynamics.ActiveReports.TextBox HOT_Mach1 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Dept = null;
		private DataDynamics.ActiveReports.TextBox HOT_DayGreater = null;
		private DataDynamics.ActiveReports.TextBox HOT_DayGreater2 = null;
		private DataDynamics.ActiveReports.TextBox TextBox1 = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1 = null;
		private DataDynamics.ActiveReports.TextBox HOT_PastDue1 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0011 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0021 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0031 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0041 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0051 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0061 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0071 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0081 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0091 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0101 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0111 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0125 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0132 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0141 = null;
		private DataDynamics.ActiveReports.TextBox HOT_DayGreater1 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Dept1 = null;
		private DataDynamics.ActiveReports.Label Label50 = null;
		private DataDynamics.ActiveReports.Line Line2 = null;
		private DataDynamics.ActiveReports.TextBox HOT_DayGreater3 = null;
		private DataDynamics.ActiveReports.TextBox TextBox2 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.Label Label29 = null;
		private DataDynamics.ActiveReports.TextBox pageTextBox = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0121 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0122 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0123 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0124 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0131 = null;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.ClassLib.Reports.rptHotListTotalResume.rpx");
			this.ReportHeader = ((DataDynamics.ActiveReports.ReportHeader)(this.Sections["ReportHeader"]));
			this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
			this.GroupHeader1 = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["GroupHeader1"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.GroupFooter1 = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["GroupFooter1"]));
			this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
			this.ReportFooter = ((DataDynamics.ActiveReports.ReportFooter)(this.Sections["ReportFooter"]));
			this.lblHeader = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[0]));
			this.Label5 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
			this.lblPastDue = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
			this.Label9 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
			this.lblDay002 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
			this.lblDay003 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
			this.lblDay004 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
			this.lblDay005 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
			this.lblDay006 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
			this.lblDay007 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
			this.lblDay008 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
			this.lblDay009 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
			this.lblDay010 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
			this.lblDay011 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
			this.lblDay012 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
			this.lblDay013 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[14]));
			this.lblDay014 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[15]));
			this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[16]));
			this.lblTitulo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[17]));
			this.Label33 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[18]));
			this.Label34 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[19]));
			this.Label35 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[20]));
			this.Label36 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[21]));
			this.Label37 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[22]));
			this.Label38 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[23]));
			this.Label39 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[24]));
			this.Label40 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[25]));
			this.Label41 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[26]));
			this.Label42 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[27]));
			this.Label43 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[28]));
			this.Label44 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[29]));
			this.Label45 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[30]));
			this.Label46 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[31]));
			this.Label47 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[32]));
			this.Label48 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[33]));
			this.Label49 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[34]));
			this.Label51 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[35]));
			this.Label52 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[36]));
			this.Label53 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[37]));
			this.lblTit2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[38]));
			this.pastDueProgressTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.day001ProgressTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.day002ProgressTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.day003ProgressTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.day004ProgressTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
			this.day005ProgressTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
			this.day006ProgressTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
			this.day007ProgressTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
			this.day008ProgressTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
			this.day009ProgressTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[9]));
			this.day010ProgressTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[10]));
			this.day011ProgressTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[11]));
			this.day012ProgressTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[12]));
			this.day013ProgressTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[13]));
			this.day014ProgressTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[14]));
			this.HOT_Mach1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[15]));
			this.HOT_Dept = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[16]));
			this.HOT_DayGreater = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[17]));
			this.HOT_DayGreater2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[18]));
			this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[19]));
			this.HOT_PastDue1 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[0]));
			this.HOT_Day0011 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[1]));
			this.HOT_Day0021 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[2]));
			this.HOT_Day0031 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[3]));
			this.HOT_Day0041 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[4]));
			this.HOT_Day0051 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[5]));
			this.HOT_Day0061 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[6]));
			this.HOT_Day0071 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[7]));
			this.HOT_Day0081 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[8]));
			this.HOT_Day0091 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[9]));
			this.HOT_Day0101 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[10]));
			this.HOT_Day0111 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[11]));
			this.HOT_Day0125 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[12]));
			this.HOT_Day0132 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[13]));
			this.HOT_Day0141 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[14]));
			this.HOT_DayGreater1 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[15]));
			this.HOT_Dept1 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[16]));
			this.Label50 = ((DataDynamics.ActiveReports.Label)(this.GroupFooter1.Controls[17]));
			this.Line2 = ((DataDynamics.ActiveReports.Line)(this.GroupFooter1.Controls[18]));
			this.HOT_DayGreater3 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[19]));
			this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[20]));
			this.Label29 = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
			this.pageTextBox = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[1]));
			this.HOT_Day0121 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[0]));
			this.HOT_Day0122 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[1]));
			this.HOT_Day0123 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[2]));
			this.HOT_Day0124 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[3]));
			this.HOT_Day0131 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[4]));
			// Attach Report Events
			this.ReportFooter.Format += new System.EventHandler(this.ReportFooter_Format);
			this.Detail.Format += new System.EventHandler(this.Detail_Format);
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
			this.PageFooter.BeforePrint += new System.EventHandler(this.PageFooter_BeforePrint);
			this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
			this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
		}

#endregion

public 
void setTitle(string title){
	lblTit2.Text = title;

	setDayLabelsFooter();
	setDayLabelsHeader();
}

private 
void setDayLabelsFooter(){
	string[] dates = lblTit2.Text.Split('=');
	DateTime today = DateUtil.parseDate(dates[1].TrimStart(' ').Substring(0, 10), DateUtil.MMDDYYYY);
}

private 
void setDayLabelsHeader(){
    string space = " ";

	string[] dates = lblTit2.Text.Split('=');
	DateTime today = DateUtil.parseDate(dates[1].TrimStart(' ').Substring(0, 10), DateUtil.MMDDYYYY);

    this.lblDay002.Text = space + today.AddDays(1).ToString("ddd MM-dd");
	this.lblDay003.Text = space + today.AddDays(2).ToString("ddd MM-dd");
	this.lblDay004.Text = space + today.AddDays(3).ToString("ddd MM-dd");
	this.lblDay005.Text = space + today.AddDays(4).ToString("ddd MM-dd");
	this.lblDay006.Text = space + today.AddDays(5).ToString("ddd MM-dd");
	this.lblDay007.Text = space + today.AddDays(6).ToString("ddd MM-dd");
	this.lblDay008.Text = space + today.AddDays(7).ToString("ddd MM-dd");
	this.lblDay009.Text = space + today.AddDays(8).ToString("ddd MM-dd");
	this.lblDay010.Text = space + today.AddDays(9).ToString("ddd MM-dd");
	this.lblDay011.Text = space + today.AddDays(10).ToString("ddd MM-dd");
	this.lblDay012.Text = space + today.AddDays(11).ToString("ddd MM-dd");
	this.lblDay013.Text = space + today.AddDays(12).ToString("ddd MM-dd");
	this.lblDay014.Text = space + today.AddDays(13).ToString("ddd MM-dd");
}


} // class

} // namespace
