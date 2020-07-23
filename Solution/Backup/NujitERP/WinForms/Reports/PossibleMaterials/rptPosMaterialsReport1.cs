using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.ClassLib.Util;


namespace Nujit.NujitERP.WinForms.Reports.PossibleMaterials{


public 
class rptPosMaterialsReport : ActiveReport{

private string product;
private int sequence;
private decimal possible;


public 
rptPosMaterialsReport(){
	this.product = "";
	this.sequence = 0;
	this.possible = 0;

	InitializeReport();
}

private 
void ReportHeader_BeforePrint(object sender, System.EventArgs eArgs){
	loadLabels();
}

private 
void PageHeader_Format(object sender, System.EventArgs eArgs){
	txtDataHour.Text = DateTime.Now.ToShortDateString();
}

#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader;
		private DataDynamics.ActiveReports.Label labelTitle;
		private DataDynamics.ActiveReports.Label Label20;
		private DataDynamics.ActiveReports.TextBox nroPartsTextBox;
		private DataDynamics.ActiveReports.TextBox productTextBox;
		private DataDynamics.ActiveReports.TextBox sequenceTextBox;
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label Label12;
		private DataDynamics.ActiveReports.Label Label13;
		private DataDynamics.ActiveReports.Label Label14;
		private DataDynamics.ActiveReports.Label Label15;
		private DataDynamics.ActiveReports.Label Label16;
		private DataDynamics.ActiveReports.Label Label19;
		private DataDynamics.ActiveReports.Line Line2;
		private DataDynamics.ActiveReports.TextBox txtDataHour;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox txtType;
		private DataDynamics.ActiveReports.TextBox txtDepartament;
		private DataDynamics.ActiveReports.TextBox txtPart;
		private DataDynamics.ActiveReports.TextBox txtSequence;
		private DataDynamics.ActiveReports.TextBox txtQtyRel;
		private DataDynamics.ActiveReports.TextBox txtQoh;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.WinForms.Reports.PossibleMaterials.rptPosMaterialsReport.rpx");
			this.ReportHeader = ((DataDynamics.ActiveReports.ReportHeader)(this.Sections["ReportHeader"]));
			this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
			this.ReportFooter = ((DataDynamics.ActiveReports.ReportFooter)(this.Sections["ReportFooter"]));
			this.labelTitle = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[0]));
			this.Label20 = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[1]));
			this.nroPartsTextBox = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[2]));
			this.productTextBox = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[3]));
			this.sequenceTextBox = ((DataDynamics.ActiveReports.TextBox)(this.ReportHeader.Controls[4]));
			this.Label12 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
			this.Label13 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
			this.Label14 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
			this.Label15 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
			this.Label16 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
			this.Label19 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
			this.Line2 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[6]));
			this.txtDataHour = ((DataDynamics.ActiveReports.TextBox)(this.PageHeader.Controls[7]));
			this.txtType = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.txtDepartament = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.txtPart = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.txtSequence = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.txtQtyRel = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
			this.txtQoh = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
			// Attach Report Events
			this.ReportHeader.BeforePrint += new System.EventHandler(this.ReportHeader_BeforePrint);
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
		}

#endregion

private 
void loadLabels(){
	nroPartsTextBox.Text = decimal.Round(possible, 4).ToString();
	txtPart.Text = product;
	txtSequence.Text = sequence.ToString();

	productTextBox.Text = product;
	sequenceTextBox.Text = sequence.ToString();
}

public void setProduct(string product){
	this.product = product;
}

public void setSequence(int sequence){
	this.sequence = sequence;
}

public void setPossible(decimal possible){
	this.possible = possible;
}


}//end class

}//end namespace
