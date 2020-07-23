using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Nujit.NujitERP.WinForms.Reports.ShippingSchedule{
	public class rptShippingSchDtl : ActiveReport3{
	
private bool flgFirstLine = true;
private string smstxl;
private string smcpt;
private string smpart;
	
public rptShippingSchDtl(){
	InitializeReport();
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

private void ReportHeader_Format(object sender, System.EventArgs eArgs){
		this.tBoxDate.Text += DateTime.Today.ToShortDateString();
}

private void PageFooter_Format(object sender, System.EventArgs eArgs){
    this.tBoxPage.Text += "Page "+this.PageNumber.ToString();
	
}

private void Detail_Format(object sender, System.EventArgs eArgs){
	if (this.flgFirstLine){
        this.smstxl=this.tBoxSMSTXL.Text;
        this.smcpt= this.tBoxSMCPT.Text;
        this.smpart=this.tBoxSMPART.Text;
        this.flgFirstLine=false;
    }else{
        if ((this.smstxl.Equals(this.tBoxSMSTXL.Text))&&(this.smcpt.Equals(this.tBoxSMCPT.Text))
            &&(this.smpart.Equals(this.tBoxSMPART.Text))){
            this.tBoxSMCPT.Visible=false;
            this.tBoxSMPART.Visible=false;
            this.tBoxSMSTXL.Visible=false;
        }else{
            this.tBoxSMCPT.Visible=true;
            this.tBoxSMPART.Visible=true;
            this.tBoxSMSTXL.Visible=true;
            this.smstxl=this.tBoxSMSTXL.Text;
            this.smcpt= this.tBoxSMCPT.Text;
            this.smpart=this.tBoxSMPART.Text;
        }
    }
}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader;
		private DataDynamics.ActiveReports.TextBox tBoxDate;
		private DataDynamics.ActiveReports.Label Label2;
		private DataDynamics.ActiveReports.TextBox tBoxBy;
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1;
		private DataDynamics.ActiveReports.Label Label24;
		private DataDynamics.ActiveReports.Label Label25;
		private DataDynamics.ActiveReports.Label Label26;
		private DataDynamics.ActiveReports.Label Label27;
		private DataDynamics.ActiveReports.Label Label28;
		private DataDynamics.ActiveReports.Label lday1;
		private DataDynamics.ActiveReports.Label Label29;
		private DataDynamics.ActiveReports.Label lday2;
		private DataDynamics.ActiveReports.Label Label30;
		private DataDynamics.ActiveReports.Label lday3;
		private DataDynamics.ActiveReports.Label Label31;
		private DataDynamics.ActiveReports.Label lday4;
		private DataDynamics.ActiveReports.Label Label32;
		private DataDynamics.ActiveReports.Label lday5;
		private DataDynamics.ActiveReports.Label Label33;
		private DataDynamics.ActiveReports.Label lday6;
		private DataDynamics.ActiveReports.Label lday7;
		private DataDynamics.ActiveReports.Label Label34;
		private DataDynamics.ActiveReports.Label Label35;
		private DataDynamics.ActiveReports.Label lday8;
		private DataDynamics.ActiveReports.Label lday9;
		private DataDynamics.ActiveReports.Label Label36;
		private DataDynamics.ActiveReports.Label Label37;
		private DataDynamics.ActiveReports.Label lday10;
		private DataDynamics.ActiveReports.Label lday11;
		private DataDynamics.ActiveReports.Label Label38;
		private DataDynamics.ActiveReports.Label Label39;
		private DataDynamics.ActiveReports.Label lday12;
		private DataDynamics.ActiveReports.Label lday13;
		private DataDynamics.ActiveReports.Label Label40;
		private DataDynamics.ActiveReports.Label Label41;
		private DataDynamics.ActiveReports.Label lday14;
		private DataDynamics.ActiveReports.Label lday15;
		private DataDynamics.ActiveReports.Label Label42;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.TextBox tBoxSMSTXL;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.Label Label43;
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
		private DataDynamics.ActiveReports.TextBox tBoxSMCPT;
		private DataDynamics.ActiveReports.TextBox tBoxSMPART;
		private DataDynamics.ActiveReports.TextBox tBox15;
		private DataDynamics.ActiveReports.TextBox pastDue1;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.TextBox tBoxPage;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Reports.ShippingSchedule.rptShippingSchDtl.rpx");
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
			this.Label24 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[0]));
			this.Label25 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[1]));
			this.Label26 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[2]));
			this.Label27 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[3]));
			this.Label28 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[4]));
			this.lday1 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[5]));
			this.Label29 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[6]));
			this.lday2 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[7]));
			this.Label30 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[8]));
			this.lday3 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[9]));
			this.Label31 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[10]));
			this.lday4 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[11]));
			this.Label32 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[12]));
			this.lday5 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[13]));
			this.Label33 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[14]));
			this.lday6 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[15]));
			this.lday7 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[16]));
			this.Label34 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[17]));
			this.Label35 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[18]));
			this.lday8 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[19]));
			this.lday9 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[20]));
			this.Label36 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[21]));
			this.Label37 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[22]));
			this.lday10 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[23]));
			this.lday11 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[24]));
			this.Label38 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[25]));
			this.Label39 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[26]));
			this.lday12 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[27]));
			this.lday13 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[28]));
			this.Label40 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[29]));
			this.Label41 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[30]));
			this.lday14 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[31]));
			this.lday15 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[32]));
			this.Label42 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[33]));
			this.Line1 = ((DataDynamics.ActiveReports.Line)(this.GroupHeader1.Controls[34]));
			this.tBoxSMSTXL = ((DataDynamics.ActiveReports.TextBox)(this.GroupHeader1.Controls[35]));
			this.Label43 = ((DataDynamics.ActiveReports.Label)(this.Detail.Controls[0]));
			this.tBoxPastDue = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.tBoxDay2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.tBoxDay1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.tBoxDay3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
			this.tBoxDay4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
			this.tBoxDay5 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
			this.tBoxDay6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
			this.tBoxDay7 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
			this.tBoxDay8 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[9]));
			this.tBoxDay9 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[10]));
			this.tBoxDay10 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[11]));
			this.tBoxDay12 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[12]));
			this.tBoxDay11 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[13]));
			this.tBoxDay13 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[14]));
			this.tBoxDay14 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[15]));
			this.tBoxSMCPT = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[16]));
			this.tBoxSMPART = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[17]));
			this.tBox15 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[18]));
			this.pastDue1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[19]));
			this.tBoxPage = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[0]));
			// Attach Report Events
			this.GroupHeader1.Format += new System.EventHandler(this.GroupHeader1_Format);
			this.ReportHeader.Format += new System.EventHandler(this.ReportHeader_Format);
			this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
			this.Detail.Format += new System.EventHandler(this.Detail_Format);
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
