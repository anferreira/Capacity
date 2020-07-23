using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.ClassLib.Util;


namespace Nujit.NujitERP.WinForms.Reports.ShortageReport{

public class rptShortageReport : ActiveReport{

private DateTime dateFrom;	
private DateTime dateTo;
private DateTime[] weeks = new DateTime[4];

public 
rptShortageReport(){
	InitializeReport();
}

private 
void PageFooter_Format(object sender, System.EventArgs eArgs){
	this.lPageNum.Text ="Page: " + this.PageNumber.ToString();
}

private 
void ReportHeader_Format(object sender, System.EventArgs eArgs){
	this.tBoxDateFrom.Text = "From Date: " + this.dateFrom.ToShortDateString();
	loadWeeksLabels();
}

private 
void PageHeader_Format(object sender, System.EventArgs eArgs){
	this.tBoxDate.Text = "Date: " + DateTime.Now.ToShortDateString();
}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader;
		private DataDynamics.ActiveReports.Label Label1;
		private DataDynamics.ActiveReports.TextBox tBoxDateFrom;
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label Label2;
		private DataDynamics.ActiveReports.Label Label3;
		private DataDynamics.ActiveReports.Label Label4;
		private DataDynamics.ActiveReports.Label Label5;
		private DataDynamics.ActiveReports.Label Label6;
		private DataDynamics.ActiveReports.Label Label7;
		private DataDynamics.ActiveReports.Label Label13;
		private DataDynamics.ActiveReports.Label Label16;
		private DataDynamics.ActiveReports.Label Label17;
		private DataDynamics.ActiveReports.Label Label18;
		private DataDynamics.ActiveReports.Label Label10;
		private DataDynamics.ActiveReports.Label Label9;
		private DataDynamics.ActiveReports.Label Label15;
		private DataDynamics.ActiveReports.Label Label25;
		private DataDynamics.ActiveReports.Label Label24;
		private DataDynamics.ActiveReports.Label Label23;
		private DataDynamics.ActiveReports.Label Label22;
		private DataDynamics.ActiveReports.Label Label21;
		private DataDynamics.ActiveReports.Label Label20;
		private DataDynamics.ActiveReports.Label labelWeek1;
		private DataDynamics.ActiveReports.Label labelWeek2;
		private DataDynamics.ActiveReports.Label labelWeek3;
		private DataDynamics.ActiveReports.Label labelWeek4;
		private DataDynamics.ActiveReports.TextBox tBoxDate;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox TextBox1;
		private DataDynamics.ActiveReports.TextBox TextBox2;
		private DataDynamics.ActiveReports.TextBox TextBox3;
		private DataDynamics.ActiveReports.TextBox TextBox4;
		private DataDynamics.ActiveReports.TextBox TextBox5;
		private DataDynamics.ActiveReports.TextBox TextBox6;
		private DataDynamics.ActiveReports.TextBox TextBox7;
		private DataDynamics.ActiveReports.TextBox TextBox8;
		private DataDynamics.ActiveReports.TextBox TextBox9;
		private DataDynamics.ActiveReports.TextBox TextBox10;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.Label lPageNum;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter;
		private DataDynamics.ActiveReports.TextBox TextBox15;
		private DataDynamics.ActiveReports.TextBox TextBox16;
		private DataDynamics.ActiveReports.TextBox TextBox17;
		private DataDynamics.ActiveReports.TextBox TextBox18;
		private DataDynamics.ActiveReports.Label Label19;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Reports.ShortageReport.rptShortageReport.rpx");
			this.ReportHeader = ((DataDynamics.ActiveReports.ReportHeader)(this.Sections["ReportHeader"]));
			this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
			this.ReportFooter = ((DataDynamics.ActiveReports.ReportFooter)(this.Sections["ReportFooter"]));
			this.Label1 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[0]));
			this.tBoxDateFrom = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[1]));
			this.Label2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
			this.Label3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
			this.Label4 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
			this.Label5 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
			this.Label6 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
			this.Label7 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
			this.Label13 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
			this.Label16 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
			this.Label17 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
			this.Label18 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
			this.Label10 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
			this.Label9 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
			this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
			this.Label25 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
			this.Label24 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[14]));
			this.Label23 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[15]));
			this.Label22 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[16]));
			this.Label21 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[17]));
			this.Label20 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[18]));
			this.labelWeek1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[19]));
			this.labelWeek2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[20]));
			this.labelWeek3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[21]));
			this.labelWeek4 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[22]));
			this.tBoxDate = ((DataDynamics.ActiveReports.TextBox)(this.PageHeader.Controls[23]));
			this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.TextBox3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.TextBox4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.TextBox5 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
			this.TextBox6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
			this.TextBox7 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
			this.TextBox8 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
			this.TextBox9 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
			this.TextBox10 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[9]));
			this.lPageNum = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
			this.TextBox15 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[0]));
			this.TextBox16 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[1]));
			this.TextBox17 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[2]));
			this.TextBox18 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[3]));
			this.Label19 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[4]));
			// Attach Report Events
			this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
			this.ReportHeader.Format += new System.EventHandler(this.ReportHeader_Format);
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
		}

		#endregion
	
public void setDateFrom(DateTime dateFrom)	 {
    this.dateFrom =dateFrom;
    loadWeeks(dateFrom);
   
}

public void setDateTo(DateTime dateTo)	 {
    this.dateTo = dateTo;

}

private void loadWeeks(DateTime startDate){

    DayOfWeek  startDay = startDate.DayOfWeek;
    weeks[0] = startDate;
    for (int i=1; i<weeks.Length;i++)
               weeks[i] = weeks[i-1].AddDays(-7); 
}

private void loadWeeksLabels(){
    this.labelWeek1.Text = weeks[0].Day.ToString("00") +" " +DateUtil.getMonthName(weeks[0].Month) + "-" + 
                           weeks[1].Day.ToString("00") + DateUtil.getMonthName(weeks[1].Month);
    this.labelWeek2.Text = weeks[1].AddDays(-1).Day.ToString("00") +" " +DateUtil.getMonthName(weeks[1].Month) + "-" + 
                           weeks[2].Day.ToString("00") +" " +DateUtil.getMonthName(weeks[0].Month);
    this.labelWeek3.Text = weeks[2].AddDays(-1).Day.ToString("00") +" " +DateUtil.getMonthName(weeks[2].Month) + "-" + 
                           weeks[3].Day.ToString("00") +" " +DateUtil.getMonthName(weeks[3].Month);
    this.labelWeek4.Text = weeks[3].AddDays(-1).Day.ToString("00") +" " +DateUtil.getMonthName(weeks[3].Month) + "-" + 
                           weeks[3].AddDays(-7).Day.ToString("00") +" " +DateUtil.getMonthName(weeks[3].Month);
}


}
}
