using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Nujit.NujitERP.WinForms.Reports.ShippingSchedule
{
	public class rptShippingSchAcummulated : ActiveReport3
	{
		public rptShippingSchAcummulated()
		{
			InitializeReport();
		}

private void ReportHeader_Format(object sender, System.EventArgs eArgs)		{
		this.tBoxDate.Text +=System.DateTime.Today.ToShortDateString();

}


private void PageFooter_Format(object sender, System.EventArgs eArgs){
    this.tBoxPage.Text = "Page " +this.PageNumber.ToString();

}
		

private void GroupHeader1_Format(object sender, System.EventArgs eArgs){
 DateTime[] days = new DateTime[15];
    for(int i=0;i<days.Length;i++)
        days[i] = DateTime.Today.AddDays(i);
	this.lday1.Text = days[0].ToShortDateString();
	this.lday2.Text = days[1].ToShortDateString();
	this.lday3.Text = days[2].ToShortDateString();
	this.lday4.Text = days[3].ToShortDateString();
	this.lday5.Text = days[4].ToShortDateString();
	this.lday6.Text = days[5].ToShortDateString();
	this.lday7.Text = days[6].ToShortDateString();
	this.lday8.Text = days[7].ToShortDateString();
	this.lday9.Text = days[8].ToShortDateString();
	this.lday10.Text = days[9].ToShortDateString();
	this.lday11.Text = days[10].ToShortDateString();
	this.lday12.Text = days[11].ToShortDateString();
	this.lday13.Text = days[12].ToShortDateString();
	this.lday14.Text = days[13].ToShortDateString();
	this.lday15.Text = ">" +days[13].ToShortDateString();
	
}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader;
		private DataDynamics.ActiveReports.TextBox tBoxDate;
		private DataDynamics.ActiveReports.Label Label2;
		private DataDynamics.ActiveReports.TextBox tBoxBy;
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1;
		private DataDynamics.ActiveReports.Label Label43;
		private DataDynamics.ActiveReports.Label Label44;
		private DataDynamics.ActiveReports.Label Label45;
		private DataDynamics.ActiveReports.Label Label46;
		private DataDynamics.ActiveReports.Label Label47;
		private DataDynamics.ActiveReports.Label Label48;
		private DataDynamics.ActiveReports.Label Label49;
		private DataDynamics.ActiveReports.Label Label50;
		private DataDynamics.ActiveReports.Label Label51;
		private DataDynamics.ActiveReports.Label Label52;
		private DataDynamics.ActiveReports.Label Label53;
		private DataDynamics.ActiveReports.Label Label54;
		private DataDynamics.ActiveReports.Label Label55;
		private DataDynamics.ActiveReports.Label Label56;
		private DataDynamics.ActiveReports.Label Label57;
		private DataDynamics.ActiveReports.Label Label58;
		private DataDynamics.ActiveReports.Label Label59;
		private DataDynamics.ActiveReports.Label Label60;
		private DataDynamics.ActiveReports.Label Label61;
		private DataDynamics.ActiveReports.Label lday15;
		private DataDynamics.ActiveReports.Label lday1;
		private DataDynamics.ActiveReports.Label lday2;
		private DataDynamics.ActiveReports.Label lday3;
		private DataDynamics.ActiveReports.Label lday4;
		private DataDynamics.ActiveReports.Label lday5;
		private DataDynamics.ActiveReports.Label lday6;
		private DataDynamics.ActiveReports.Label lday7;
		private DataDynamics.ActiveReports.Label lday8;
		private DataDynamics.ActiveReports.Label lday9;
		private DataDynamics.ActiveReports.Label lday10;
		private DataDynamics.ActiveReports.Label lday11;
		private DataDynamics.ActiveReports.Label lday12;
		private DataDynamics.ActiveReports.Label lday13;
		private DataDynamics.ActiveReports.Label lday14;
		private DataDynamics.ActiveReports.Line Line4;
		private DataDynamics.ActiveReports.TextBox SMSTXL3;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox tBoxPastDue;
		private DataDynamics.ActiveReports.TextBox tBoxDay2;
		private DataDynamics.ActiveReports.TextBox tBoxDay1;
		private DataDynamics.ActiveReports.TextBox tBoxDay3;
		private DataDynamics.ActiveReports.TextBox tBoxDay4;
		private DataDynamics.ActiveReports.TextBox tBoxDay5;
		private DataDynamics.ActiveReports.TextBox tBoxDay6;
		private DataDynamics.ActiveReports.TextBox tBoxDay7;
		private DataDynamics.ActiveReports.TextBox tBoxDay8;
		private DataDynamics.ActiveReports.TextBox tBoxDay9;
		private DataDynamics.ActiveReports.TextBox tBoxDay10;
		private DataDynamics.ActiveReports.TextBox tBoxDay12;
		private DataDynamics.ActiveReports.TextBox tBoxDay11;
		private DataDynamics.ActiveReports.TextBox tBoxDay13;
		private DataDynamics.ActiveReports.TextBox tBoxDay14;
		private DataDynamics.ActiveReports.TextBox TextBox1;
		private DataDynamics.ActiveReports.TextBox tBoxSMPART;
		private DataDynamics.ActiveReports.TextBox tBox15;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.TextBox tBoxPage;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Reports.ShippingSchedule.rptShippingSchAcummulated.rpx");
			this.ReportHeader = ((DataDynamics.ActiveReports.ReportHeader)(this.Sections["ReportHeader"]));
			this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
			this.GroupHeader1 = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["GroupHeader1"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.GroupFooter1 = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["GroupFooter1"]));
			this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
			this.ReportFooter = ((DataDynamics.ActiveReports.ReportFooter)(this.Sections["ReportFooter"]));
			this.tBoxDate = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[0]));
			this.Label2 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[1]));
			this.tBoxBy = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[2]));
			this.Label43 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[0]));
			this.Label44 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[1]));
			this.Label45 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[2]));
			this.Label46 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[3]));
			this.Label47 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[4]));
			this.Label48 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[5]));
			this.Label49 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[6]));
			this.Label50 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[7]));
			this.Label51 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[8]));
			this.Label52 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[9]));
			this.Label53 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[10]));
			this.Label54 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[11]));
			this.Label55 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[12]));
			this.Label56 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[13]));
			this.Label57 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[14]));
			this.Label58 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[15]));
			this.Label59 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[16]));
			this.Label60 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[17]));
			this.Label61 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[18]));
			this.lday15 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[19]));
			this.lday1 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[20]));
			this.lday2 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[21]));
			this.lday3 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[22]));
			this.lday4 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[23]));
			this.lday5 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[24]));
			this.lday6 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[25]));
			this.lday7 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[26]));
			this.lday8 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[27]));
			this.lday9 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[28]));
			this.lday10 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[29]));
			this.lday11 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[30]));
			this.lday12 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[31]));
			this.lday13 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[32]));
			this.lday14 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[33]));
			this.Line4 = ((DataDynamics.ActiveReports.Line)(this.GroupHeader1.Controls[34]));
			this.SMSTXL3 = ((DataDynamics.ActiveReports.TextBox)(this.GroupHeader1.Controls[35]));
			this.tBoxPastDue = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.tBoxDay2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.tBoxDay1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.tBoxDay3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.tBoxDay4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
			this.tBoxDay5 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
			this.tBoxDay6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
			this.tBoxDay7 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
			this.tBoxDay8 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
			this.tBoxDay9 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[9]));
			this.tBoxDay10 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[10]));
			this.tBoxDay12 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[11]));
			this.tBoxDay11 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[12]));
			this.tBoxDay13 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[13]));
			this.tBoxDay14 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[14]));
			this.TextBox1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[15]));
			this.tBoxSMPART = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[16]));
			this.tBox15 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[17]));
			this.tBoxPage = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[0]));
			// Attach Report Events
			this.ReportHeader.Format += new System.EventHandler(this.ReportHeader_Format);
			this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
			this.GroupHeader1.Format += new System.EventHandler(this.GroupHeader1_Format);
		}

		#endregion
	
public void setLabel(bool flag){

    if (flag){
        this.tBoxBy.Text +="Requirement on Monday By Part";
    }else
         this.tBoxBy.Text +="Shipping this week By Part";
}	
}
}
