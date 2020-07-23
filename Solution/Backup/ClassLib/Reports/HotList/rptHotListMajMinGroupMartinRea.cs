using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Reports.UtilReports;
using Nujit.NujitERP.ClassLib.Core;


namespace Nujit.NujitERP.ClassLib.Reports.HotList{
	

public 
class rptHotListMajMinGroupMartinRea : ActiveReport{

private string[] logVector = null;
private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private bool accumOnFridays = false;
private bool hoursPartsHL = false;
private bool labourReport = false;
private bool nonZeroes = false;
private string generated = "";
private string exploded = "";
private bool hotListBom = false;


public 
rptHotListMajMinGroupMartinRea(){		
	logVector = coreFactory.getHotListLogData();

	InitializeReport();
}

~rptHotListMajMinGroupMartinRea(){
	coreFactory = null;
}
	
public 
void setAccumOnFridays(bool accumOnFridays){
    this.accumOnFridays = accumOnFridays;
}

public
void setHoursPartsHL(bool hoursPartsHL){
    this.hoursPartsHL = hoursPartsHL;
}

public 
void setLabourReport(bool labourReport){
    this.labourReport = labourReport;
}

public 
void setNonZeroes(bool nonZeroes){
    this.nonZeroes = nonZeroes;
}

public
void setBomReport(bool hotListBom){
	this.hotListBom = hotListBom;

	lvlTitle.Visible = hotListBom;
	lvlTextBox.Visible = hotListBom;
}

private 
void ReportFooter_Format(object sender, System.EventArgs eArgs)	{
	try{
		 this.setDayLabelsFooter();
		
		decimal val1 =decimal.Parse(this.TextBox5.Text);
		decimal val2 =0;
		decimal total=val1 + val2;
		this.TextBox15.Value= total;

		val1 =decimal.Parse(this.TextBox15.Text);
		val2 =0;
		total = val1 + val2;
		this.TextBox16.Value=total;
		
		val1 =decimal.Parse(this.TextBox16.Text);
		val2 =0;
		total = val1 + val2;
		this.TextBox17.Value= total;

		val1 =decimal.Parse(this.TextBox17.Text);
		val2 =0;
		total = val1 + val2;
		this.TextBox18.Value= total;

		val1 =decimal.Parse(this.TextBox18.Text);
		val2 =0;
		total = val1 + val2;
		this.TextBox19.Value= total;

		val1 =decimal.Parse(this.TextBox19.Text);
		val2 =0;
		total = val1 + val2;
		this.TextBox20.Value= total;

		val1 =decimal.Parse(this.TextBox20.Text);
		val2 =0;
		total = val1 + val2;
		this.TextBox21.Value= total;

		val1 =decimal.Parse(this.TextBox21.Text);
		val2 =0;
		total = val1 + val2;
		this.TextBox22.Value= total;

		val1 =decimal.Parse(this.TextBox22.Text);
		val2 = 0;
		total = val1 + val2;
		this.TextBox23.Value= total;
		
		val1 =decimal.Parse(this.TextBox23.Text);
		val2 = 0;
		total = val1 + val2;
		this.TextBox24.Value= total;

		val1 = decimal.Parse(this.TextBox24.Text);
		val2 = 0;
		total = val1 + val2;
		this.TextBox25.Value= total;

		val1 =decimal.Parse(this.TextBox25.Text);
		val2 = 0;
		total = val1 + val2;
		this.TextBox26.Value= total;

		val1 =decimal.Parse(this.TextBox26.Text);
		val2 = 0;
		total = val1 + val2;
		this.TextBox27.Value= total;

		val1 =decimal.Parse(this.TextBox27.Text);
		val2 = 0;
		total = val1 + val2;
		this.TextBox28.Value= total;
	}catch (Exception e){
		System.Console.WriteLine("Error when generating the report!!!"+e.Message);
	}
}

private 
void Detail_Format(object sender, System.EventArgs eArgs){
	if (hoursPartsHL || labourReport){
		this.HOT_Day012.OutputFormat = "0.00";
		this.HOT_Day0125.OutputFormat = "0.00";
		this.HOT_Day0132.OutputFormat = "0.00";
		this.HOT_Day013.OutputFormat = "0.00";
		this.HOT_Day014.OutputFormat = "0.00";

		this.HOT_Day001.OutputFormat = "0.00";
		this.HOT_Day0021.OutputFormat = "0.00";
		this.HOT_Day003.OutputFormat = "0.00";
		this.HOT_Day004.OutputFormat = "0.00";
		this.HOT_Day005.OutputFormat = "0.00";
		this.HOT_Day006.OutputFormat = "0.00";
		this.HOT_Day007.OutputFormat = "0.00";
		this.HOT_Day008.OutputFormat = "0.00";
		this.HOT_Day009.OutputFormat = "0.00";
		this.HOT_Day010.OutputFormat = "0.00";
		this.HOT_Day011.OutputFormat = "0.00";
		this.txtHOT_PastDue.OutputFormat = "0.00";

		this.HOT_PastDue1.OutputFormat = "0.00";
		this.HOT_Day0011.OutputFormat = "0.00";
		this.HOT_Day0022.OutputFormat = "0.00";
		this.HOT_Day0031.OutputFormat = "0.00";
		this.HOT_Day0045.OutputFormat = "0.00";
		this.HOT_Day0051.OutputFormat = "0.00";
		this.HOT_Day0061.OutputFormat = "0.00";
		this.HOT_Day0071.OutputFormat = "0.00";
		this.HOT_Day0082.OutputFormat = "0.00";
		this.HOT_Day0093.OutputFormat = "0.00";
		this.HOT_Day0101.OutputFormat = "0.00";
		this.HOT_Day0112.OutputFormat = "0.00";

		this.TextBox5.OutputFormat = "0.00";
		this.TextBox15.OutputFormat = "0.00";
		this.TextBox16.OutputFormat = "0.00";
		this.TextBox17.OutputFormat = "0.00";
		this.TextBox18.OutputFormat = "0.00";
		this.TextBox19.OutputFormat = "0.00";
		this.TextBox20.OutputFormat = "0.00";
		this.TextBox21.OutputFormat = "0.00";
		this.TextBox22.OutputFormat = "0.00";
		this.TextBox23.OutputFormat = "0.00";
		this.TextBox24.OutputFormat = "0.00";
		this.TextBox25.OutputFormat = "0.00";
	}
	if (nonZeroes){
		this.HOT_Day001.OutputFormat = "0";
		if (this.HOT_Day001.Text.Equals("0"))
			this.HOT_Day001.Visible = false;
		else
			this.HOT_Day001.Visible = true;

		this.HOT_Day0021.OutputFormat = "0";
		if (this.HOT_Day0021.Text.Equals("0"))
			this.HOT_Day0021.Visible = false;
		else
			this.HOT_Day0021.Visible = true;

		this.HOT_Day003.OutputFormat = "0";
		if (this.HOT_Day003.Text.Equals("0"))
			this.HOT_Day003.Visible = false;
		else
			this.HOT_Day003.Visible = true;

		this.HOT_Day004.OutputFormat = "0";
		if (this.HOT_Day004.Text.Equals("0"))
			this.HOT_Day004.Visible = false;
		else
			this.HOT_Day004.Visible = true;

		this.HOT_Day005.OutputFormat = "0";
		if (this.HOT_Day005.Text.Equals("0"))
			this.HOT_Day005.Visible = false;
		else
			this.HOT_Day005.Visible = true;

		this.HOT_Day006.OutputFormat = "0";
		if (this.HOT_Day006.Text.Equals("0"))
			this.HOT_Day006.Visible = false;
		else
			this.HOT_Day006.Visible = true;

		this.HOT_Day007.OutputFormat = "0";
		if (this.HOT_Day007.Text.Equals("0"))
			this.HOT_Day007.Visible = false;
		else
			this.HOT_Day007.Visible = true;

		this.HOT_Day008.OutputFormat = "0";
		if (this.HOT_Day008.Text.Equals("0"))
			this.HOT_Day008.Visible = false;
		else
			this.HOT_Day008.Visible = true;

		this.HOT_Day009.OutputFormat = "0";
		if (this.HOT_Day009.Text.Equals("0"))
			this.HOT_Day009.Visible = false;
		else
			this.HOT_Day009.Visible = true;

		this.HOT_Day010.OutputFormat = "0";
		if (this.HOT_Day010.Text.Equals("0"))
			this.HOT_Day010.Visible = false;
		else
			this.HOT_Day010.Visible = true;

		this.HOT_Day011.OutputFormat = "0";
		if (this.HOT_Day011.Text.Equals("0"))
			this.HOT_Day011.Visible = false;
		else
			this.HOT_Day011.Visible = true;

		this.txtHOT_PastDue.OutputFormat = "0";
		if (this.txtHOT_PastDue.Text.Equals("0"))
			this.txtHOT_PastDue.Visible = false;
		else
			this.txtHOT_PastDue.Visible = true;

		this.HOT_PastDue1.OutputFormat = "0";
		if (this.HOT_PastDue1.Text.Equals("0"))
			this.HOT_PastDue1.Visible = false;
		else
			this.HOT_PastDue1.Visible = true;

		this.HOT_Day012.OutputFormat = "0";
		if (this.HOT_Day012.Text.Equals("0"))
			this.HOT_Day012.Visible = false;
		else
			this.HOT_Day012.Visible = true;

		this.HOT_Day0125.OutputFormat = "0";
		if (this.HOT_Day0125.Text.Equals("0"))
			this.HOT_Day0125.Visible = false;
		else
			this.HOT_Day0125.Visible = true;

		this.HOT_Day0132.OutputFormat = "0";
		if (this.HOT_Day0132.Text.Equals("0"))
			this.HOT_Day0132.Visible = false;
		else
			this.HOT_Day0132.Visible = true;

		this.HOT_Day013.OutputFormat = "0";
		if (this.HOT_Day013.Text.Equals("0"))
			this.HOT_Day013.Visible = false;
		else
			this.HOT_Day013.Visible = true;

		this.HOT_Day014.OutputFormat = "0";
		if (this.HOT_Day014.Text.Equals("0"))
			this.HOT_Day014.Visible = false;
		else
			this.HOT_Day014.Visible = true;

		this.HOT_Day0022.OutputFormat = "0";
		if (this.HOT_Day0022.Text.Equals("0"))
			this.HOT_Day0022.Visible = false;
		else
			this.HOT_Day0022.Visible = true;

		this.HOT_Day0031.OutputFormat = "0";
		if (this.HOT_Day0031.Text.Equals("0"))
			this.HOT_Day0031.Visible = false;
		else
			this.HOT_Day0031.Visible = true;

		this.HOT_Day0045.OutputFormat = "0";
		if (this.HOT_Day0045.Text.Equals("0"))
			this.HOT_Day0045.Visible = false;
		else
			this.HOT_Day0045.Visible = true;

		this.HOT_Day0051.OutputFormat = "0";
		if (this.HOT_Day0051.Text.Equals("0"))
			this.HOT_Day0051.Visible = false;
		else
			this.HOT_Day0051.Visible = true;

		this.HOT_Day0061.OutputFormat = "0";
		if (this.HOT_Day0061.Text.Equals("0"))
			this.HOT_Day0061.Visible = false;
		else
			this.HOT_Day0061.Visible = true;

		this.HOT_Day0071.OutputFormat = "0";
		if (this.HOT_Day0071.Text.Equals("0"))
			this.HOT_Day0071.Visible = false;
		else
			this.HOT_Day0071.Visible = true;

		this.HOT_Day0082.OutputFormat = "0";
		if (this.HOT_Day0082.Text.Equals("0"))
			this.HOT_Day0082.Visible = false;
		else
			this.HOT_Day0082.Visible = true;

		this.HOT_Day0093.OutputFormat = "0";
		if (this.HOT_Day0093.Text.Equals("0"))
			this.HOT_Day0093.Visible = false;
		else
			this.HOT_Day0093.Visible = true;

		this.HOT_Day0101.OutputFormat = "0";
		if (this.HOT_Day0101.Text.Equals("0"))
			this.HOT_Day0101.Visible = false;
		else
			this.HOT_Day0101.Visible = true;

		this.HOT_Day0112.OutputFormat = "0";
		if (this.HOT_Day0112.Text.Equals("0"))
			this.HOT_Day0112.Visible = false;
		else
			this.HOT_Day0112.Visible = true;

		this.TextBox5.OutputFormat = "0";
		if (this.TextBox5.Text.Equals("0"))
			this.TextBox5.Visible = false;
		else
			this.TextBox5.Visible = true;

		this.TextBox15.OutputFormat = "0";
		if (this.TextBox15.Text.Equals("0"))
			this.TextBox15.Visible = false;
		else
			this.TextBox15.Visible = true;

		this.TextBox16.OutputFormat = "0";
		if (this.TextBox16.Text.Equals("0"))
			this.TextBox16.Visible = false;
		else
			this.TextBox16.Visible = true;

		this.TextBox17.OutputFormat = "0";
		if (this.TextBox17.Text.Equals("0"))
			this.TextBox17.Visible = false;
		else
			this.TextBox17.Visible = true;

		this.TextBox18.OutputFormat = "0";
		if (this.TextBox18.Text.Equals("0"))
			this.TextBox18.Visible = false;
		else
			this.TextBox18.Visible = true;

		this.TextBox19.OutputFormat = "0";
		if (this.TextBox19.Text.Equals("0"))
			this.TextBox19.Visible = false;
		else
			this.TextBox19.Visible = true;

		this.TextBox20.OutputFormat = "0";
		if (this.TextBox20.Text.Equals("0"))
			this.TextBox20.Visible = false;
		else
			this.TextBox20.Visible = true;

		this.TextBox21.OutputFormat = "0";
		if (this.TextBox21.Text.Equals("0"))
			this.TextBox21.Visible = false;
		else
			this.TextBox21.Visible = true;

		this.TextBox22.OutputFormat = "0";
		if (this.TextBox22.Text.Equals("0"))
			this.TextBox22.Visible = false;
		else
			this.TextBox22.Visible = true;

		this.TextBox23.OutputFormat = "0";
		if (this.TextBox23.Text.Equals("0"))
			this.TextBox23.Visible = false;
		else
			this.TextBox23.Visible = true;

		this.TextBox24.OutputFormat = "0";
		if (this.TextBox24.Text.Equals("0"))
			this.TextBox24.Visible = false;
		else
			this.TextBox24.Visible = true;

		this.TextBox25.OutputFormat = "0";
		if (this.TextBox25.Text.Equals("0"))
			this.TextBox25.Visible = false;
		else
			this.TextBox25.Visible = true;

		HOT_PastDue1.Visible = true;
		HOT_Day0011.Visible = true;
		HOT_Day0022.Visible = true;
		HOT_Day0031.Visible = true;
		HOT_Day0045.Visible = true;
		HOT_Day0051.Visible = true;
		HOT_Day0061.Visible = true;
		HOT_Day0071.Visible = true;
		HOT_Day0082.Visible = true;
		HOT_Day0093.Visible = true;
		HOT_Day0101.Visible = true;
		HOT_Day0112.Visible = true;
		HOT_Day0125.Visible = true;
		HOT_Day0132.Visible = true;
		HOT_Day0133.Visible = true;
	}
}

private 
void PageHeader_Format(object sender, System.EventArgs eArgs){
	if (generated.Length == 0){
		lblTit1.Text = "Hotlist Generated on : " + logVector[0];
		lblTit2.Text = "Material Explosion on : " + logVector[1];
	}else{
		lblTit1.Text = "Hotlist Generated on : " + generated;
		lblTit2.Text = "Material Explosion on : " + exploded;
	}
}

private 
void GroupHeader1_BeforePrint(object sender, System.EventArgs eArgs){
	string deptDesc = coreFactory.getDepartamentDescription(TextBox29.Text);
	//lblDescDeptHeader.Text = deptDesc;
	lblDescDept.Text = deptDesc;
	this.setDayLabelsHeader();
}

private 
void PageFooter_BeforePrint(object sender, System.EventArgs eArgs){
	pageTextBox.Text = this.PageNumber.ToString();
	
}

#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.Label lblHeader = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Label Label1 = null;
		private DataDynamics.ActiveReports.Label Label3 = null;
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
		private DataDynamics.ActiveReports.TextBox TextBox2 = null;
		private DataDynamics.ActiveReports.Label Label4 = null;
		private DataDynamics.ActiveReports.Line Line1 = null;
		private DataDynamics.ActiveReports.Label Label30 = null;
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
		private DataDynamics.ActiveReports.Label lvlTitle = null;
		private DataDynamics.ActiveReports.Label lblTit1 = null;
		private DataDynamics.ActiveReports.Label lblTit2 = null;
		private DataDynamics.ActiveReports.Label Label47 = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1 = null;
		private DataDynamics.ActiveReports.Label Label13 = null;
		private DataDynamics.ActiveReports.TextBox TextBox29 = null;
		private DataDynamics.ActiveReports.Label Label32 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox txtHOT_Mach = null;
		private DataDynamics.ActiveReports.TextBox txtHOT_PastDue = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day001 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day003 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day004 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day005 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day006 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day007 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day008 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day009 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day010 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day011 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day012 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day013 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day014 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Seq2 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0021 = null;
		private DataDynamics.ActiveReports.TextBox TextBox30 = null;
		private DataDynamics.ActiveReports.TextBox HOT_ProdID2 = null;
		private DataDynamics.ActiveReports.TextBox TextBox31 = null;
		private DataDynamics.ActiveReports.TextBox typeTextBox = null;
		private DataDynamics.ActiveReports.TextBox lvlTextBox = null;
		private DataDynamics.ActiveReports.TextBox MaterialDescription = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1 = null;
		private DataDynamics.ActiveReports.TextBox TextBox32 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Dept1 = null;
		private DataDynamics.ActiveReports.TextBox HOT_PastDue1 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0011 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0031 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0045 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0051 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0061 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0071 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0082 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0093 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0101 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0112 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0125 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0132 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0133 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0022 = null;
		private DataDynamics.ActiveReports.Label lblDescDept = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.Label Label29 = null;
		private DataDynamics.ActiveReports.TextBox pageTextBox = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		private DataDynamics.ActiveReports.Label Label10 = null;
		private DataDynamics.ActiveReports.Label Label11 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0121 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0122 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0123 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0124 = null;
		private DataDynamics.ActiveReports.TextBox HOT_Day0131 = null;
		private DataDynamics.ActiveReports.Line Line2 = null;
		private DataDynamics.ActiveReports.TextBox TextBox5 = null;
		private DataDynamics.ActiveReports.TextBox TextBox15 = null;
		private DataDynamics.ActiveReports.TextBox TextBox16 = null;
		private DataDynamics.ActiveReports.TextBox TextBox17 = null;
		private DataDynamics.ActiveReports.TextBox TextBox18 = null;
		private DataDynamics.ActiveReports.TextBox TextBox19 = null;
		private DataDynamics.ActiveReports.TextBox TextBox20 = null;
		private DataDynamics.ActiveReports.TextBox TextBox21 = null;
		private DataDynamics.ActiveReports.TextBox TextBox22 = null;
		private DataDynamics.ActiveReports.TextBox TextBox23 = null;
		private DataDynamics.ActiveReports.TextBox TextBox24 = null;
		private DataDynamics.ActiveReports.TextBox TextBox25 = null;
		private DataDynamics.ActiveReports.TextBox TextBox26 = null;
		private DataDynamics.ActiveReports.TextBox TextBox27 = null;
		private DataDynamics.ActiveReports.TextBox TextBox28 = null;
		private DataDynamics.ActiveReports.Label Label14 = null;
		private DataDynamics.ActiveReports.Label Label15 = null;
		private DataDynamics.ActiveReports.Label Label16 = null;
		private DataDynamics.ActiveReports.Label Label17 = null;
		private DataDynamics.ActiveReports.Label Label18 = null;
		private DataDynamics.ActiveReports.Label Label19 = null;
		private DataDynamics.ActiveReports.Label Label20 = null;
		private DataDynamics.ActiveReports.Label Label21 = null;
		private DataDynamics.ActiveReports.Label Label22 = null;
		private DataDynamics.ActiveReports.Label Label23 = null;
		private DataDynamics.ActiveReports.Label Label24 = null;
		private DataDynamics.ActiveReports.Label Label25 = null;
		private DataDynamics.ActiveReports.Label Label26 = null;
		private DataDynamics.ActiveReports.Label Label27 = null;
		private DataDynamics.ActiveReports.Label Label28 = null;
		private DataDynamics.ActiveReports.Line Line3 = null;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "Nujit.NujitERP.ClassLib.Reports.HotList.rptHotListMajMinGroupMartinRea.rpx");
			this.ReportHeader = ((DataDynamics.ActiveReports.ReportHeader)(this.Sections["ReportHeader"]));
			this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
			this.GroupHeader1 = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["GroupHeader1"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.GroupFooter1 = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["GroupFooter1"]));
			this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
			this.ReportFooter = ((DataDynamics.ActiveReports.ReportFooter)(this.Sections["ReportFooter"]));
			this.lblHeader = ((DataDynamics.ActiveReports.Label)(this.ReportHeader.Controls[0]));
			this.Label1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[0]));
			this.Label3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
			this.Label5 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[2]));
			this.lblPastDue = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
			this.Label9 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
			this.lblDay002 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
			this.lblDay003 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
			this.lblDay004 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
			this.lblDay005 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
			this.lblDay006 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
			this.lblDay007 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
			this.lblDay008 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
			this.lblDay009 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
			this.lblDay010 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
			this.lblDay011 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[14]));
			this.lblDay012 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[15]));
			this.lblDay013 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[16]));
			this.lblDay014 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[17]));
			this.TextBox2 = ((DataDynamics.ActiveReports.TextBox)(this.PageHeader.Controls[18]));
			this.Label4 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[19]));
			this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[20]));
			this.Label30 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[21]));
			this.lblTitulo = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[22]));
			this.Label33 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[23]));
			this.Label34 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[24]));
			this.Label35 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[25]));
			this.Label36 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[26]));
			this.Label37 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[27]));
			this.Label38 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[28]));
			this.Label39 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[29]));
			this.Label40 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[30]));
			this.Label41 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[31]));
			this.Label42 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[32]));
			this.Label43 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[33]));
			this.Label44 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[34]));
			this.Label45 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[35]));
			this.Label46 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[36]));
			this.lvlTitle = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[37]));
			this.lblTit1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[38]));
			this.lblTit2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[39]));
			this.Label47 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[40]));
			this.Label13 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[0]));
			this.TextBox29 = ((DataDynamics.ActiveReports.TextBox)(this.GroupHeader1.Controls[1]));
			this.Label32 = ((DataDynamics.ActiveReports.Label)(this.GroupHeader1.Controls[2]));
			this.txtHOT_Mach = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.txtHOT_PastDue = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.HOT_Day001 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.HOT_Day003 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.HOT_Day004 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
			this.HOT_Day005 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
			this.HOT_Day006 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[6]));
			this.HOT_Day007 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[7]));
			this.HOT_Day008 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[8]));
			this.HOT_Day009 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[9]));
			this.HOT_Day010 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[10]));
			this.HOT_Day011 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[11]));
			this.HOT_Day012 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[12]));
			this.HOT_Day013 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[13]));
			this.HOT_Day014 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[14]));
			this.HOT_Seq2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[15]));
			this.HOT_Day0021 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[16]));
			this.TextBox30 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[17]));
			this.HOT_ProdID2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[18]));
			this.TextBox31 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[19]));
			this.typeTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[20]));
			this.lvlTextBox = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[21]));
			this.MaterialDescription = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[22]));
			this.TextBox32 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[0]));
			this.HOT_Dept1 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[1]));
			this.HOT_PastDue1 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[2]));
			this.HOT_Day0011 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[3]));
			this.HOT_Day0031 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[4]));
			this.HOT_Day0045 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[5]));
			this.HOT_Day0051 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[6]));
			this.HOT_Day0061 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[7]));
			this.HOT_Day0071 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[8]));
			this.HOT_Day0082 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[9]));
			this.HOT_Day0093 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[10]));
			this.HOT_Day0101 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[11]));
			this.HOT_Day0112 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[12]));
			this.HOT_Day0125 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[13]));
			this.HOT_Day0132 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[14]));
			this.HOT_Day0133 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[15]));
			this.HOT_Day0022 = ((DataDynamics.ActiveReports.TextBox)(this.GroupFooter1.Controls[16]));
			this.lblDescDept = ((DataDynamics.ActiveReports.Label)(this.GroupFooter1.Controls[17]));
			this.Label29 = ((DataDynamics.ActiveReports.Label)(this.PageFooter.Controls[0]));
			this.pageTextBox = ((DataDynamics.ActiveReports.TextBox)(this.PageFooter.Controls[1]));
			this.Label10 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[0]));
			this.Label11 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[1]));
			this.HOT_Day0121 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[2]));
			this.HOT_Day0122 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[3]));
			this.HOT_Day0123 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[4]));
			this.HOT_Day0124 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[5]));
			this.HOT_Day0131 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[6]));
			this.Line2 = ((DataDynamics.ActiveReports.Line)(this.ReportFooter.Controls[7]));
			this.TextBox5 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[8]));
			this.TextBox15 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[9]));
			this.TextBox16 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[10]));
			this.TextBox17 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[11]));
			this.TextBox18 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[12]));
			this.TextBox19 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[13]));
			this.TextBox20 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[14]));
			this.TextBox21 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[15]));
			this.TextBox22 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[16]));
			this.TextBox23 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[17]));
			this.TextBox24 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[18]));
			this.TextBox25 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[19]));
			this.TextBox26 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[20]));
			this.TextBox27 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[21]));
			this.TextBox28 = ((DataDynamics.ActiveReports.TextBox)(this.ReportFooter.Controls[22]));
			this.Label14 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[23]));
			this.Label15 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[24]));
			this.Label16 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[25]));
			this.Label17 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[26]));
			this.Label18 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[27]));
			this.Label19 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[28]));
			this.Label20 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[29]));
			this.Label21 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[30]));
			this.Label22 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[31]));
			this.Label23 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[32]));
			this.Label24 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[33]));
			this.Label25 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[34]));
			this.Label26 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[35]));
			this.Label27 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[36]));
			this.Label28 = ((DataDynamics.ActiveReports.Label)(this.ReportFooter.Controls[37]));
			this.Line3 = ((DataDynamics.ActiveReports.Line)(this.ReportFooter.Controls[38]));
			// Attach Report Events
			this.ReportFooter.Format += new System.EventHandler(this.ReportFooter_Format);
			this.Detail.Format += new System.EventHandler(this.Detail_Format);
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
			this.GroupHeader1.BeforePrint += new System.EventHandler(this.GroupHeader1_BeforePrint);
			this.PageFooter.BeforePrint += new System.EventHandler(this.PageFooter_BeforePrint);
		}

#endregion

public 
void SetTitle(string title){
	this.lblTitulo.Text = title;
	
	lblTit1.Text = "Hotlist Generated on : " + logVector[0];
	lblTit2.Text = "Material Explosion on : " + logVector[1];
}


private 
void setDayLabelsFooter(){
    string space = " ";

	DateTime today = DateUtil.parseDate(logVector[0].Substring(0, 10), DateUtil.MMDDYYYY);

	if (!this.accumOnFridays){
        //Report Footer labels
		this.Label16.Text = space + today.AddDays(1).ToString("ddd MM-dd");
		this.Label17.Text = space + today.AddDays(2).ToString("ddd MM-dd");
		this.Label18.Text = space + today.AddDays(3).ToString("ddd MM-dd");
		this.Label19.Text = space + today.AddDays(4).ToString("ddd MM-dd");
		this.Label20.Text = space + today.AddDays(5).ToString("ddd MM-dd");
		this.Label21.Text = space + today.AddDays(6).ToString("ddd MM-dd");
		this.Label22.Text = space + today.AddDays(7).ToString("ddd MM-dd");
		this.Label23.Text = space + today.AddDays(8).ToString("ddd MM-dd");
		this.Label24.Text = space + today.AddDays(9).ToString("ddd MM-dd");
		this.Label25.Text = space + today.AddDays(10).ToString("ddd MM-dd");
		this.Label26.Text = space + today.AddDays(11).ToString("ddd MM-dd");
		this.Label27.Text = space + today.AddDays(12).ToString("ddd MM-dd");
		this.Label28.Text = space + today.AddDays(13).ToString("ddd MM-dd");
    
    }else{
        switch(today.DayOfWeek.ToString()){
	        case "Monday":
                   
		            //Report Footer labels
		            this.Label16.Text = space + today.AddDays(1).ToString("ddd MM-dd");
		            this.Label17.Text = space + today.AddDays(2).ToString("ddd MM-dd");
		            this.Label18.Text = space + today.AddDays(3).ToString("ddd MM-dd");
		            this.Label19.Text = space + today.AddDays(4).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.Label20.Text = space + today.AddDays(7).ToString("ddd MM-dd");
		            this.Label21.Text = space + today.AddDays(8).ToString("ddd MM-dd");
		            this.Label22.Text = space + today.AddDays(9).ToString("ddd MM-dd");
		            this.Label23.Text = space + today.AddDays(10).ToString("ddd MM-dd");
		            this.Label24.Text = space + today.AddDays(11).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.Label25.Text = space + today.AddDays(14).ToString("ddd MM-dd");
		            this.Label26.Text = space + today.AddDays(15).ToString("ddd MM-dd");
		            this.Label27.Text = space + today.AddDays(16).ToString("ddd MM-dd");
		            this.Label28.Text = space + today.AddDays(17).ToString("ddd MM-dd");
		            break;
            case "Tuesday":
		          
                    //Report footer labels
                    this.Label16.Text = space + today.AddDays(1).ToString("ddd MM-dd");
		            this.Label17.Text = space + today.AddDays(2).ToString("ddd MM-dd");
		            this.Label18.Text = space + today.AddDays(3).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.Label19.Text = space + today.AddDays(6).ToString("ddd MM-dd");
		            this.Label20.Text = space + today.AddDays(7).ToString("ddd MM-dd");
		            this.Label21.Text = space + today.AddDays(8).ToString("ddd MM-dd");
		            this.Label22.Text = space + today.AddDays(9).ToString("ddd MM-dd");
		            this.Label23.Text = space + today.AddDays(10).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.Label24.Text = space + today.AddDays(13).ToString("ddd MM-dd");
		            this.Label25.Text = space + today.AddDays(14).ToString("ddd MM-dd");
		            this.Label26.Text = space + today.AddDays(15).ToString("ddd MM-dd");
		            this.Label27.Text = space + today.AddDays(16).ToString("ddd MM-dd");
		            this.Label28.Text = space + today.AddDays(17).ToString("ddd MM-dd");
		            break;
            case "Wednesday":
		          
                    //Report footer labels
		            this.Label16.Text = space + today.AddDays(1).ToString("ddd MM-dd");
		            this.Label17.Text = space + today.AddDays(2).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.Label18.Text = space + today.AddDays(5).ToString("ddd MM-dd");
		            this.Label19.Text = space + today.AddDays(6).ToString("ddd MM-dd");
		            this.Label20.Text = space + today.AddDays(7).ToString("ddd MM-dd");
		            this.Label21.Text = space + today.AddDays(8).ToString("ddd MM-dd");
		            this.Label22.Text = space + today.AddDays(9).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.Label23.Text = space + today.AddDays(12).ToString("ddd MM-dd");
		            this.Label24.Text = space + today.AddDays(13).ToString("ddd MM-dd");
		            this.Label25.Text = space + today.AddDays(14).ToString("ddd MM-dd");
		            this.Label26.Text = space + today.AddDays(15).ToString("ddd MM-dd");
		            this.Label27.Text = space + today.AddDays(16).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.Label28.Text = space + today.AddDays(19).ToString("ddd MM-dd");
		            break;
            case "Thursday":
		           
		            //Report Footer labels
		          	this.Label16.Text = space + today.AddDays(1).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.Label17.Text = space + today.AddDays(4).ToString("ddd MM-dd");
		            this.Label18.Text = space + today.AddDays(5).ToString("ddd MM-dd");
		            this.Label19.Text = space + today.AddDays(6).ToString("ddd MM-dd");
		            this.Label20.Text = space + today.AddDays(7).ToString("ddd MM-dd");
		            this.Label21.Text = space + today.AddDays(8).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.Label22.Text = space + today.AddDays(11).ToString("ddd MM-dd");
		            this.Label23.Text = space + today.AddDays(12).ToString("ddd MM-dd");
		            this.Label24.Text = space + today.AddDays(13).ToString("ddd MM-dd");
		            this.Label25.Text = space + today.AddDays(14).ToString("ddd MM-dd");
		            this.Label26.Text = space + today.AddDays(15).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.Label27.Text = space + today.AddDays(18).ToString("ddd MM-dd");
		            this.Label28.Text = space + today.AddDays(19).ToString("ddd MM-dd");
    
    	            break;
            case "Friday":
		            //Report Footer Labels
    	            //Saturday - Sunday we skip
		            this.Label16.Text = space + today.AddDays(3).ToString("ddd MM-dd");
	                this.Label17.Text = space + today.AddDays(4).ToString("ddd MM-dd");
		            this.Label18.Text = space + today.AddDays(5).ToString("ddd MM-dd");
		            this.Label19.Text = space + today.AddDays(6).ToString("ddd MM-dd");
		            this.Label20.Text = space + today.AddDays(7).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.Label21.Text = space + today.AddDays(10).ToString("ddd MM-dd");
		            this.Label22.Text = space + today.AddDays(11).ToString("ddd MM-dd");
		            this.Label23.Text = space + today.AddDays(12).ToString("ddd MM-dd");
		            this.Label24.Text = space + today.AddDays(13).ToString("ddd MM-dd");
		            this.Label25.Text = space + today.AddDays(14).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.Label26.Text = space + today.AddDays(17).ToString("ddd MM-dd");
		            this.Label27.Text = space + today.AddDays(18).ToString("ddd MM-dd");
		            this.Label28.Text = space + today.AddDays(19).ToString("ddd MM-dd");
		            break;
            case "Saturday":
				  
    	            //Report Footer Labels
    	            //Saturday - Sunday we skip
		            this.Label16.Text = space + today.AddDays(2).ToString("ddd MM-dd");
	                this.Label17.Text = space + today.AddDays(3).ToString("ddd MM-dd");
		            this.Label18.Text = space + today.AddDays(4).ToString("ddd MM-dd");
		            this.Label19.Text = space + today.AddDays(5).ToString("ddd MM-dd");
		            this.Label20.Text = space + today.AddDays(6).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.Label21.Text = space + today.AddDays(9).ToString("ddd MM-dd");
		            this.Label22.Text = space + today.AddDays(10).ToString("ddd MM-dd");
		            this.Label23.Text = space + today.AddDays(11).ToString("ddd MM-dd");
		            this.Label24.Text = space + today.AddDays(12).ToString("ddd MM-dd");
		            this.Label25.Text = space + today.AddDays(13).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.Label26.Text = space + today.AddDays(16).ToString("ddd MM-dd");
		            this.Label27.Text = space + today.AddDays(17).ToString("ddd MM-dd");
		            this.Label28.Text = space + today.AddDays(18).ToString("ddd MM-dd");
    	           
		            break;
            case "Sunday":
		            //Report Footer labels
		            //Saturday - Sunday we skip
		            this.Label16.Text = space + today.AddDays(1).ToString("ddd MM-dd");
	                this.Label17.Text = space + today.AddDays(2).ToString("ddd MM-dd");
		            this.Label18.Text = space + today.AddDays(3).ToString("ddd MM-dd");
		            this.Label19.Text = space + today.AddDays(4).ToString("ddd MM-dd");
		            this.Label20.Text = space + today.AddDays(5).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.Label21.Text = space + today.AddDays(8).ToString("ddd MM-dd");
		            this.Label22.Text = space + today.AddDays(9).ToString("ddd MM-dd");
		            this.Label23.Text = space + today.AddDays(10).ToString("ddd MM-dd");
		            this.Label24.Text = space + today.AddDays(11).ToString("ddd MM-dd");
		            this.Label25.Text = space + today.AddDays(12).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.Label26.Text = space + today.AddDays(15).ToString("ddd MM-dd");
		            this.Label27.Text = space + today.AddDays(16).ToString("ddd MM-dd");
		            this.Label28.Text = space + today.AddDays(17).ToString("ddd MM-dd");
		            break;
            }
    }
}

private 
void setDayLabelsHeader(){
    string space = " ";

	DateTime today = DateUtil.parseDate(logVector[0].Substring(0, 10), DateUtil.MMDDYYYY);

	if (!accumOnFridays){
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
    
    }else{
     switch(today.DayOfWeek.ToString()){
	        case "Monday":
                    this.lblDay002.Text = space + today.AddDays(1).ToString("ddd MM-dd");
		            this.lblDay003.Text = space + today.AddDays(2).ToString("ddd MM-dd");
		            this.lblDay004.Text = space + today.AddDays(3).ToString("ddd MM-dd");
		            this.lblDay005.Text = space + today.AddDays(4).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.lblDay006.Text = space + today.AddDays(7).ToString("ddd MM-dd");
		            this.lblDay007.Text = space + today.AddDays(8).ToString("ddd MM-dd");
		            this.lblDay008.Text = space + today.AddDays(9).ToString("ddd MM-dd");
		            this.lblDay009.Text = space + today.AddDays(10).ToString("ddd MM-dd");
		            this.lblDay010.Text = space + today.AddDays(11).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.lblDay011.Text = space + today.AddDays(14).ToString("ddd MM-dd");
		            this.lblDay012.Text = space + today.AddDays(15).ToString("ddd MM-dd");
		            this.lblDay013.Text = space + today.AddDays(16).ToString("ddd MM-dd");
		            this.lblDay014.Text = space + today.AddDays(17).ToString("ddd MM-dd");
		         
		            break;
            case "Tuesday":
		            this.lblDay002.Text =  space + today.AddDays(1).ToString("ddd MM-dd");
		            this.lblDay003.Text =  space + today.AddDays(2).ToString("ddd MM-dd");
		            this.lblDay004.Text =  space + today.AddDays(3).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.lblDay005.Text =  space + today.AddDays(6).ToString("ddd MM-dd");
		            this.lblDay006.Text =  space + today.AddDays(7).ToString("ddd MM-dd");
		            this.lblDay007.Text =  space + today.AddDays(8).ToString("ddd MM-dd");
		            this.lblDay008.Text =  space + today.AddDays(9).ToString("ddd MM-dd");
		            this.lblDay009.Text =  space + today.AddDays(10).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.lblDay010.Text =  space + today.AddDays(13).ToString("ddd MM-dd");
		            this.lblDay011.Text =  space + today.AddDays(14).ToString("ddd MM-dd");
		            this.lblDay012.Text =  space + today.AddDays(15).ToString("ddd MM-dd");
		            this.lblDay013.Text =  space + today.AddDays(16).ToString("ddd MM-dd");
		            this.lblDay014.Text =  space + today.AddDays(17).ToString("ddd MM-dd");
              
		            break;
            case "Wednesday":
		           	this.lblDay002.Text =  space + today.AddDays(1).ToString("ddd MM-dd");
		            this.lblDay003.Text =  space + today.AddDays(2).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.lblDay004.Text =  space + today.AddDays(5).ToString("ddd MM-dd");
		            this.lblDay005.Text =  space + today.AddDays(6).ToString("ddd MM-dd");
		            this.lblDay006.Text =  space + today.AddDays(7).ToString("ddd MM-dd");
		            this.lblDay007.Text =  space + today.AddDays(8).ToString("ddd MM-dd");
		            this.lblDay008.Text =  space + today.AddDays(9).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.lblDay009.Text = space + today.AddDays(12).ToString("ddd MM-dd");
		            this.lblDay010.Text = space + today.AddDays(13).ToString("ddd MM-dd");
		            this.lblDay011.Text = space + today.AddDays(14).ToString("ddd MM-dd");
		            this.lblDay012.Text = space + today.AddDays(15).ToString("ddd MM-dd");
		            this.lblDay013.Text = space + today.AddDays(16).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.lblDay014.Text = space + today.AddDays(19).ToString("ddd MM-dd");
                   
		            break;
            case "Thursday":
		           	this.lblDay002.Text =  space + today.AddDays(1).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.lblDay003.Text = space + today.AddDays(4).ToString("ddd MM-dd");
		            this.lblDay004.Text = space + today.AddDays(5).ToString("ddd MM-dd");
		            this.lblDay005.Text = space + today.AddDays(6).ToString("ddd MM-dd");
		            this.lblDay006.Text = space + today.AddDays(7).ToString("ddd MM-dd");
		            this.lblDay007.Text = space + today.AddDays(8).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.lblDay008.Text = space + today.AddDays(11).ToString("ddd MM-dd");
		            this.lblDay009.Text = space + today.AddDays(12).ToString("ddd MM-dd");
		            this.lblDay010.Text = space + today.AddDays(13).ToString("ddd MM-dd");
		            this.lblDay011.Text = space + today.AddDays(14).ToString("ddd MM-dd");
		            this.lblDay012.Text = space + today.AddDays(15).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.lblDay013.Text = space + today.AddDays(18).ToString("ddd MM-dd");
		            this.lblDay014.Text = space + today.AddDays(19).ToString("ddd MM-dd");
		           		           
    	            break;
            case "Friday":
		           	//Saturday - Sunday we skip
		            this.lblDay002.Text = space + today.AddDays(3).ToString("ddd MM-dd");
	                this.lblDay003.Text = space + today.AddDays(4).ToString("ddd MM-dd");
		            this.lblDay004.Text = space + today.AddDays(5).ToString("ddd MM-dd");
		            this.lblDay005.Text = space + today.AddDays(6).ToString("ddd MM-dd");
		            this.lblDay006.Text = space + today.AddDays(7).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.lblDay007.Text = space + today.AddDays(10).ToString("ddd MM-dd");
		            this.lblDay008.Text = space + today.AddDays(11).ToString("ddd MM-dd");
		            this.lblDay009.Text = space + today.AddDays(12).ToString("ddd MM-dd");
		            this.lblDay010.Text = space + today.AddDays(13).ToString("ddd MM-dd");
		            this.lblDay011.Text = space + today.AddDays(14).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.lblDay012.Text = space + today.AddDays(17).ToString("ddd MM-dd");
		            this.lblDay013.Text = space + today.AddDays(18).ToString("ddd MM-dd");
		            this.lblDay014.Text = space + today.AddDays(19).ToString("ddd MM-dd");
    	               	          
		            break;
            case "Saturday":
				    //Saturday - Sunday we skip
		            this.lblDay002.Text = space + today.AddDays(2).ToString("ddd MM-dd");
	                this.lblDay003.Text = space + today.AddDays(3).ToString("ddd MM-dd");
		            this.lblDay004.Text = space + today.AddDays(4).ToString("ddd MM-dd");
		            this.lblDay005.Text = space + today.AddDays(5).ToString("ddd MM-dd");
		            this.lblDay006.Text = space + today.AddDays(6).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.lblDay007.Text = space + today.AddDays(9).ToString("ddd MM-dd");
		            this.lblDay008.Text = space + today.AddDays(10).ToString("ddd MM-dd");
		            this.lblDay009.Text = space + today.AddDays(11).ToString("ddd MM-dd");
		            this.lblDay010.Text = space + today.AddDays(12).ToString("ddd MM-dd");
		            this.lblDay011.Text = space + today.AddDays(13).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.lblDay012.Text = space + today.AddDays(16).ToString("ddd MM-dd");
		            this.lblDay013.Text = space + today.AddDays(17).ToString("ddd MM-dd");
		            this.lblDay014.Text = space + today.AddDays(18).ToString("ddd MM-dd");
    	           
		            break;
            case "Sunday":
		            //Saturday - Sunday we skip
		            this.lblDay002.Text = today.AddDays(1).ToString("ddd MM-dd");
	                this.lblDay003.Text = today.AddDays(2).ToString("ddd MM-dd");
		            this.lblDay004.Text = today.AddDays(3).ToString("ddd MM-dd");
		            this.lblDay005.Text = today.AddDays(4).ToString("ddd MM-dd");
		            this.lblDay006.Text = today.AddDays(5).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.lblDay007.Text = today.AddDays(8).ToString("ddd MM-dd");
		            this.lblDay008.Text = today.AddDays(9).ToString("ddd MM-dd");
		            this.lblDay009.Text = today.AddDays(10).ToString("ddd MM-dd");
		            this.lblDay010.Text = today.AddDays(11).ToString("ddd MM-dd");
		            this.lblDay011.Text = today.AddDays(12).ToString("ddd MM-dd");
		            //Saturday - Sunday we skip
		            this.lblDay012.Text = today.AddDays(15).ToString("ddd MM-dd");
		            this.lblDay013.Text = today.AddDays(16).ToString("ddd MM-dd");
		            this.lblDay014.Text = today.AddDays(17).ToString("ddd MM-dd");
		            break;
            }
      }  

}

public 
void setGenerated(string generated){
	this.generated = generated;
}

public 
void setExploded(string exploded){
	this.exploded = exploded;
}

} // class

} // namespace
