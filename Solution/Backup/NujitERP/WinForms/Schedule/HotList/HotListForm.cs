using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Engine;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using System.Data;
using System.Data.SqlClient;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.WinForms;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.WinForms.Reports.DemandReport;
using Nujit.NujitERP.WinForms.Reports.HotList_Report;
using Nujit.NujitERP.WinForms.Schedule.LoadUpLoad.GeneratedRecords;
using  Nujit.NujitERP.ClassLib.Core.Utility;
using Nujit.NujitERP.WinForms.Schedule.LoadUpLoad;
using Nujit.NujitERP.WinForms.Schedule.HotList;


namespace Nujit.NujitERP.WinForms.Schedule.HotList{


public 
class HotListForm : System.Windows.Forms.Form{

private System.Windows.Forms.TabControl tabHotList;
private System.Windows.Forms.DataGrid gridHotList;
private System.Windows.Forms.TabPage tabPage1;
private System.Windows.Forms.TabPage tabPage2;
private System.Windows.Forms.GroupBox groupBox1;
private System.Windows.Forms.GroupBox groupBox2;
private System.Windows.Forms.Button btnGenerate;
private System.Windows.Forms.Button btnFinishedGoods;
private System.Windows.Forms.Button btnWipGoods;
private System.Windows.Forms.Label label1;
private System.Windows.Forms.Label label2;
private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private System.Windows.Forms.Button btmReport;
private System.Windows.Forms.StatusBar statusBarMessage;
private FormMain formMainParent;
private string[][] deptFilter;
private string[][] partFilter;
private string[][] mgFilter;
private string[][] stkbFilter;
private string[][] wipbFilter;
private string[][] matbFilter;
private System.Windows.Forms.Button btnFilters;
private System.Windows.Forms.Button button1;
private System.Windows.Forms.GroupBox groupBox3;
private System.Windows.Forms.Button button3;
private System.Windows.Forms.Button btnTab2Refresh;
private System.Windows.Forms.Button materialsButton;

private System.Windows.Forms.CheckBox onlyDemand;
private System.Windows.Forms.CheckBox LicheckBox;
private System.Windows.Forms.Button releasesButton;
private System.Windows.Forms.CheckBox finalizedsCheckBox;
private System.Windows.Forms.CheckBox componentsCheckBox;
private System.Windows.Forms.Button demandButton;
private System.Windows.Forms.TabPage tabPage3;
private System.Windows.Forms.Label label3;
private System.Windows.Forms.CheckBox autoTransferCheckBox;
private System.Windows.Forms.Button startButton;
private System.Windows.Forms.GroupBox groupBox4;


private int w = 934;
private int h = 598;
private System.Windows.Forms.TextBox adicionalInfoTextBox;
private System.Windows.Forms.Label label4;
private System.Windows.Forms.Button refreshTaskButton;
private System.Windows.Forms.Button hotListHoursButton;
private System.Windows.Forms.Label label5;
private System.Windows.Forms.Label label6;
private System.Windows.Forms.NumericUpDown minutesUpDown;
private System.Windows.Forms.NumericUpDown noRunStartHourUpDown;
private System.Windows.Forms.NumericUpDown noRunStartMinUpDown;
private System.Windows.Forms.NumericUpDown noRunEndHourUpDown;
private System.Windows.Forms.NumericUpDown noRunEndMinUpDown;
private System.Windows.Forms.CheckBox orderByMGCheckBox;
private System.Windows.Forms.Button btnFilterMG;
	
/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;
private System.Windows.Forms.Button matCalcButton;
private System.Windows.Forms.CheckBox cboxSunSatToFriday;
private System.Windows.Forms.CheckBox mainMatCheckBox;
private DateTime lastHLCreated;
private System.Windows.Forms.CheckBox reportingPointCheckBox;
private System.Windows.Forms.CheckBox hoursReportCheckBox;
private System.Windows.Forms.GroupBox groupBox5;
private System.Windows.Forms.CheckBox orderByResCheckBox;
private System.Windows.Forms.CheckBox labourCheckBox;
private System.Windows.Forms.CheckBox majorMinorCheckBox;
private System.Windows.Forms.CheckBox noZeroesCheckBox;
private System.Windows.Forms.Button totalsButton;
private System.Windows.Forms.CheckBox lastVersionCheckBox;
private System.Windows.Forms.Button compareButton;
private System.Windows.Forms.Button resumeButton;
private System.Windows.Forms.Button hotListBomButton;
private System.Windows.Forms.CheckBox partCheckBox;
private System.Windows.Forms.Button generateHotListButton;
private System.Windows.Forms.CheckBox includeInactivePartsCheckBox;
private System.Windows.Forms.TextBox dftPlantTextBox;
private System.Windows.Forms.Label label7;
	private System.Windows.Forms.Label label8;
	private System.Windows.Forms.Button matLocButton;
    private CheckBox daysCheckBox;
private DateTime lastMatExplosion;

public 
HotListForm(FormMain formParent){
	InitializeComponent();

	this.MdiParent = formParent;
	this.formMainParent = formParent;

	loadCuartos();
	loadFilterDept();
	loadFilterPart();
	loadFilterMG();
	
	this.Width = w;
	this.Height = h;

	setAutoRunInfo();

	loadGridHotList();
	setStyles();

	this.dftPlantTextBox.Text = Configuration.DftPlant;

	this.Refresh();
}

public 
HotListForm(){
	InitializeComponent();
	
	loadCuartos();
	loadFilterDept();
	loadFilterPart();
	loadFilterMG();

	this.Width = w;
	this.Height = h;

	setAutoRunInfo();

	loadGridHotList();
	setStyles();

	this.dftPlantTextBox.Text = Configuration.DftPlant;

	this.Refresh();
}

private 
void setAutoRunInfo(){
	adicionalInfoTextBox.Enabled = false;
	if (coreFactory.getAutimaticDelay() == 0){
		autoTransferCheckBox.Checked = false;
		minutesUpDown.Value = 0;

		this.noRunStartHourUpDown.Value = 0;
		this.noRunStartMinUpDown.Value = 0;
		this.noRunStartHourUpDown.Enabled = false;
		this.noRunStartMinUpDown.Enabled = false;

		this.noRunEndHourUpDown.Value = 0;
		this.noRunEndMinUpDown.Value = 0;
		this.noRunEndHourUpDown.Enabled = false;
		this.noRunEndMinUpDown.Enabled = false;

		minutesUpDown.Enabled = false;
		adicionalInfoTextBox.Text = "No entries";
	}else{
		autoTransferCheckBox.Checked = true;
		
		minutesUpDown.Value = coreFactory.getAutimaticDelay();
		minutesUpDown.Enabled = true;
		string noRunStart = coreFactory.getNoRunStart();
		string noRunEnd = coreFactory.getNoRunEnd();

		if (noRunStart != null){
			this.noRunStartHourUpDown.Value = DateUtil.getItemFromTime(noRunStart, DateUtil.HOUR_ITEM);
			this.noRunStartMinUpDown.Value = DateUtil.getItemFromTime(noRunStart, DateUtil.MIN_ITEM);;
			this.noRunStartHourUpDown.Enabled = true;
			this.noRunStartMinUpDown.Enabled = true;
		}
		if (noRunEnd != null){
			this.noRunEndHourUpDown.Value = DateUtil.getItemFromTime(noRunEnd, DateUtil.HOUR_ITEM);
			this.noRunEndMinUpDown.Value = DateUtil.getItemFromTime(noRunEnd, DateUtil.MIN_ITEM);;
			this.noRunEndHourUpDown.Enabled = true;
			this.noRunEndMinUpDown.Enabled = true;
		}
	}
	setAdicionalTaskData();
}

private 
void setAdicionalTaskData(){
	string[][] v = Engine.getInstance().getRunningTaskInformation();
	for(int i = 0; i < v.Length; i++){
		if (int.Parse(v[i][0]) == Task.TASK_GENERATE_HOTLIST){
			if (v[i][2].Equals(Task.TASK_PENDING))
				adicionalInfoTextBox.Text = "Pending, init at " + v[i][3];
			if (v[i][2].Equals(Task.TASK_RUNNING))
				adicionalInfoTextBox.Text = "Now Running, from " + v[i][3];
		}
	}
}

private 
bool hotLisBlocked(){
	return this.coreFactory.isHotListBlocked();
}

/// <summary>
/// Clean up any resources being used.
/// </summary>
protected override 
void Dispose(bool disposing){
	if (disposing){
		if (components != null){
			components.Dispose();
		}
	}
	base.Dispose(disposing);
}

#region Windows Form Designer generated code
/// <summary>
/// Required method for Designer support - do not modify
/// the contents of this method with the code editor.
/// </summary>
private 
void InitializeComponent(){
    this.tabHotList = new System.Windows.Forms.TabControl();
    this.tabPage1 = new System.Windows.Forms.TabPage();
    this.groupBox5 = new System.Windows.Forms.GroupBox();
    this.partCheckBox = new System.Windows.Forms.CheckBox();
    this.majorMinorCheckBox = new System.Windows.Forms.CheckBox();
    this.orderByResCheckBox = new System.Windows.Forms.CheckBox();
    this.orderByMGCheckBox = new System.Windows.Forms.CheckBox();
    this.groupBox2 = new System.Windows.Forms.GroupBox();
    this.noZeroesCheckBox = new System.Windows.Forms.CheckBox();
    this.labourCheckBox = new System.Windows.Forms.CheckBox();
    this.hoursReportCheckBox = new System.Windows.Forms.CheckBox();
    this.reportingPointCheckBox = new System.Windows.Forms.CheckBox();
    this.cboxSunSatToFriday = new System.Windows.Forms.CheckBox();
    this.mainMatCheckBox = new System.Windows.Forms.CheckBox();
    this.releasesButton = new System.Windows.Forms.Button();
    this.onlyDemand = new System.Windows.Forms.CheckBox();
    this.groupBox1 = new System.Windows.Forms.GroupBox();
    this.hotListBomButton = new System.Windows.Forms.Button();
    this.resumeButton = new System.Windows.Forms.Button();
    this.compareButton = new System.Windows.Forms.Button();
    this.matCalcButton = new System.Windows.Forms.Button();
    this.btnGenerate = new System.Windows.Forms.Button();
    this.materialsButton = new System.Windows.Forms.Button();
    this.demandButton = new System.Windows.Forms.Button();
    this.btmReport = new System.Windows.Forms.Button();
    this.groupBox3 = new System.Windows.Forms.GroupBox();
    this.includeInactivePartsCheckBox = new System.Windows.Forms.CheckBox();
    this.lastVersionCheckBox = new System.Windows.Forms.CheckBox();
    this.btnFilterMG = new System.Windows.Forms.Button();
    this.hotListHoursButton = new System.Windows.Forms.Button();
    this.LicheckBox = new System.Windows.Forms.CheckBox();
    this.button3 = new System.Windows.Forms.Button();
    this.btnFilters = new System.Windows.Forms.Button();
    this.button1 = new System.Windows.Forms.Button();
    this.finalizedsCheckBox = new System.Windows.Forms.CheckBox();
    this.componentsCheckBox = new System.Windows.Forms.CheckBox();
    this.tabPage2 = new System.Windows.Forms.TabPage();
    this.label8 = new System.Windows.Forms.Label();
    this.matLocButton = new System.Windows.Forms.Button();
    this.label7 = new System.Windows.Forms.Label();
    this.dftPlantTextBox = new System.Windows.Forms.TextBox();
    this.btnTab2Refresh = new System.Windows.Forms.Button();
    this.label2 = new System.Windows.Forms.Label();
    this.label1 = new System.Windows.Forms.Label();
    this.btnWipGoods = new System.Windows.Forms.Button();
    this.btnFinishedGoods = new System.Windows.Forms.Button();
    this.tabPage3 = new System.Windows.Forms.TabPage();
    this.groupBox4 = new System.Windows.Forms.GroupBox();
    this.generateHotListButton = new System.Windows.Forms.Button();
    this.totalsButton = new System.Windows.Forms.Button();
    this.noRunEndMinUpDown = new System.Windows.Forms.NumericUpDown();
    this.noRunEndHourUpDown = new System.Windows.Forms.NumericUpDown();
    this.noRunStartMinUpDown = new System.Windows.Forms.NumericUpDown();
    this.noRunStartHourUpDown = new System.Windows.Forms.NumericUpDown();
    this.minutesUpDown = new System.Windows.Forms.NumericUpDown();
    this.label6 = new System.Windows.Forms.Label();
    this.label5 = new System.Windows.Forms.Label();
    this.refreshTaskButton = new System.Windows.Forms.Button();
    this.label4 = new System.Windows.Forms.Label();
    this.adicionalInfoTextBox = new System.Windows.Forms.TextBox();
    this.autoTransferCheckBox = new System.Windows.Forms.CheckBox();
    this.label3 = new System.Windows.Forms.Label();
    this.startButton = new System.Windows.Forms.Button();
    this.gridHotList = new System.Windows.Forms.DataGrid();
    this.statusBarMessage = new System.Windows.Forms.StatusBar();
    this.daysCheckBox = new System.Windows.Forms.CheckBox();
    this.tabHotList.SuspendLayout();
    this.tabPage1.SuspendLayout();
    this.groupBox5.SuspendLayout();
    this.groupBox2.SuspendLayout();
    this.groupBox1.SuspendLayout();
    this.groupBox3.SuspendLayout();
    this.tabPage2.SuspendLayout();
    this.tabPage3.SuspendLayout();
    this.groupBox4.SuspendLayout();
    ((System.ComponentModel.ISupportInitialize)(this.noRunEndMinUpDown)).BeginInit();
    ((System.ComponentModel.ISupportInitialize)(this.noRunEndHourUpDown)).BeginInit();
    ((System.ComponentModel.ISupportInitialize)(this.noRunStartMinUpDown)).BeginInit();
    ((System.ComponentModel.ISupportInitialize)(this.noRunStartHourUpDown)).BeginInit();
    ((System.ComponentModel.ISupportInitialize)(this.minutesUpDown)).BeginInit();
    ((System.ComponentModel.ISupportInitialize)(this.gridHotList)).BeginInit();
    this.SuspendLayout();
    // 
    // tabHotList
    // 
    this.tabHotList.Controls.Add(this.tabPage1);
    this.tabHotList.Controls.Add(this.tabPage2);
    this.tabHotList.Controls.Add(this.tabPage3);
    this.tabHotList.Location = new System.Drawing.Point(16, 8);
    this.tabHotList.Name = "tabHotList";
    this.tabHotList.SelectedIndex = 0;
    this.tabHotList.Size = new System.Drawing.Size(904, 184);
    this.tabHotList.TabIndex = 0;
    // 
    // tabPage1
    // 
    this.tabPage1.Controls.Add(this.groupBox5);
    this.tabPage1.Controls.Add(this.groupBox2);
    this.tabPage1.Controls.Add(this.groupBox1);
    this.tabPage1.Controls.Add(this.groupBox3);
    this.tabPage1.Location = new System.Drawing.Point(4, 22);
    this.tabPage1.Name = "tabPage1";
    this.tabPage1.Size = new System.Drawing.Size(896, 158);
    this.tabPage1.TabIndex = 0;
    this.tabPage1.Text = "Hot List Reports Functions";
    // 
    // groupBox5
    // 
    this.groupBox5.Controls.Add(this.partCheckBox);
    this.groupBox5.Controls.Add(this.majorMinorCheckBox);
    this.groupBox5.Controls.Add(this.orderByResCheckBox);
    this.groupBox5.Controls.Add(this.orderByMGCheckBox);
    this.groupBox5.Location = new System.Drawing.Point(288, 104);
    this.groupBox5.Name = "groupBox5";
    this.groupBox5.Size = new System.Drawing.Size(310, 48);
    this.groupBox5.TabIndex = 5;
    this.groupBox5.TabStop = false;
    this.groupBox5.Text = "Order By";
    // 
    // partCheckBox
    // 
    this.partCheckBox.Location = new System.Drawing.Point(120, 32);
    this.partCheckBox.Name = "partCheckBox";
    this.partCheckBox.Size = new System.Drawing.Size(48, 14);
    this.partCheckBox.TabIndex = 9;
    this.partCheckBox.Text = "Part";
    // 
    // majorMinorCheckBox
    // 
    this.majorMinorCheckBox.Location = new System.Drawing.Point(120, 16);
    this.majorMinorCheckBox.Name = "majorMinorCheckBox";
    this.majorMinorCheckBox.Size = new System.Drawing.Size(120, 14);
    this.majorMinorCheckBox.TabIndex = 8;
    this.majorMinorCheckBox.Text = "Major/Minor Group";
    this.majorMinorCheckBox.CheckedChanged += new System.EventHandler(this.majorMinorCheckBox_CheckedChanged);
    // 
    // orderByResCheckBox
    // 
    this.orderByResCheckBox.Location = new System.Drawing.Point(16, 32);
    this.orderByResCheckBox.Name = "orderByResCheckBox";
    this.orderByResCheckBox.Size = new System.Drawing.Size(80, 14);
    this.orderByResCheckBox.TabIndex = 7;
    this.orderByResCheckBox.Text = "Resource";
    this.orderByResCheckBox.CheckedChanged += new System.EventHandler(this.orderByResCheckBox_CheckedChanged);
    // 
    // orderByMGCheckBox
    // 
    this.orderByMGCheckBox.Location = new System.Drawing.Point(16, 16);
    this.orderByMGCheckBox.Name = "orderByMGCheckBox";
    this.orderByMGCheckBox.Size = new System.Drawing.Size(88, 14);
    this.orderByMGCheckBox.TabIndex = 6;
    this.orderByMGCheckBox.Text = "Minor Group";
    this.orderByMGCheckBox.CheckedChanged += new System.EventHandler(this.orderByMGCheckBox_CheckedChanged);
    // 
    // groupBox2
    // 
    this.groupBox2.Controls.Add(this.daysCheckBox);
    this.groupBox2.Controls.Add(this.noZeroesCheckBox);
    this.groupBox2.Controls.Add(this.labourCheckBox);
    this.groupBox2.Controls.Add(this.hoursReportCheckBox);
    this.groupBox2.Controls.Add(this.reportingPointCheckBox);
    this.groupBox2.Controls.Add(this.cboxSunSatToFriday);
    this.groupBox2.Controls.Add(this.mainMatCheckBox);
    this.groupBox2.Controls.Add(this.releasesButton);
    this.groupBox2.Controls.Add(this.onlyDemand);
    this.groupBox2.Location = new System.Drawing.Point(288, 0);
    this.groupBox2.Name = "groupBox2";
    this.groupBox2.Size = new System.Drawing.Size(310, 104);
    this.groupBox2.TabIndex = 1;
    this.groupBox2.TabStop = false;
    this.groupBox2.Text = "Report Formats";
    // 
    // noZeroesCheckBox
    // 
    this.noZeroesCheckBox.Checked = true;
    this.noZeroesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
    this.noZeroesCheckBox.Location = new System.Drawing.Point(211, 64);
    this.noZeroesCheckBox.Name = "noZeroesCheckBox";
    this.noZeroesCheckBox.Size = new System.Drawing.Size(90, 16);
    this.noZeroesCheckBox.TabIndex = 13;
    this.noZeroesCheckBox.Text = "Non Zeroes";
    // 
    // labourCheckBox
    // 
    this.labourCheckBox.Location = new System.Drawing.Point(211, 80);
    this.labourCheckBox.Name = "labourCheckBox";
    this.labourCheckBox.Size = new System.Drawing.Size(96, 16);
    this.labourCheckBox.TabIndex = 12;
    this.labourCheckBox.Text = "Labour Report";
    this.labourCheckBox.CheckedChanged += new System.EventHandler(this.labourCheckBox_CheckedChanged);
    // 
    // hoursReportCheckBox
    // 
    this.hoursReportCheckBox.Location = new System.Drawing.Point(8, 80);
    this.hoursReportCheckBox.Name = "hoursReportCheckBox";
    this.hoursReportCheckBox.Size = new System.Drawing.Size(96, 16);
    this.hoursReportCheckBox.TabIndex = 11;
    this.hoursReportCheckBox.Text = "Hot List Hours";
    this.hoursReportCheckBox.CheckedChanged += new System.EventHandler(this.hoursReportCheckBox_CheckedChanged);
    // 
    // reportingPointCheckBox
    // 
    this.reportingPointCheckBox.Location = new System.Drawing.Point(8, 64);
    this.reportingPointCheckBox.Name = "reportingPointCheckBox";
    this.reportingPointCheckBox.Size = new System.Drawing.Size(128, 16);
    this.reportingPointCheckBox.TabIndex = 10;
    this.reportingPointCheckBox.Text = "Only Reporting Point";
    // 
    // cboxSunSatToFriday
    // 
    this.cboxSunSatToFriday.Location = new System.Drawing.Point(8, 48);
    this.cboxSunSatToFriday.Name = "cboxSunSatToFriday";
    this.cboxSunSatToFriday.Size = new System.Drawing.Size(216, 16);
    this.cboxSunSatToFriday.TabIndex = 9;
    this.cboxSunSatToFriday.Text = "Move Sunday to Saturday and Friday";
    // 
    // mainMatCheckBox
    // 
    this.mainMatCheckBox.Location = new System.Drawing.Point(8, 32);
    this.mainMatCheckBox.Name = "mainMatCheckBox";
    this.mainMatCheckBox.Size = new System.Drawing.Size(104, 16);
    this.mainMatCheckBox.TabIndex = 8;
    this.mainMatCheckBox.Text = "Main Material";
    // 
    // releasesButton
    // 
    this.releasesButton.Enabled = false;
    this.releasesButton.Location = new System.Drawing.Point(184, 8);
    this.releasesButton.Name = "releasesButton";
    this.releasesButton.Size = new System.Drawing.Size(56, 32);
    this.releasesButton.TabIndex = 4;
    this.releasesButton.Text = "Releases";
    this.releasesButton.Visible = false;
    this.releasesButton.Click += new System.EventHandler(this.releasesButton_Click);
    // 
    // onlyDemand
    // 
    this.onlyDemand.Checked = true;
    this.onlyDemand.CheckState = System.Windows.Forms.CheckState.Checked;
    this.onlyDemand.Location = new System.Drawing.Point(8, 16);
    this.onlyDemand.Name = "onlyDemand";
    this.onlyDemand.Size = new System.Drawing.Size(152, 16);
    this.onlyDemand.TabIndex = 3;
    this.onlyDemand.Text = "Show only Demand Parts";
    // 
    // groupBox1
    // 
    this.groupBox1.Controls.Add(this.hotListBomButton);
    this.groupBox1.Controls.Add(this.resumeButton);
    this.groupBox1.Controls.Add(this.compareButton);
    this.groupBox1.Controls.Add(this.matCalcButton);
    this.groupBox1.Controls.Add(this.btnGenerate);
    this.groupBox1.Controls.Add(this.materialsButton);
    this.groupBox1.Controls.Add(this.demandButton);
    this.groupBox1.Controls.Add(this.btmReport);
    this.groupBox1.Location = new System.Drawing.Point(16, 0);
    this.groupBox1.Name = "groupBox1";
    this.groupBox1.Size = new System.Drawing.Size(266, 152);
    this.groupBox1.TabIndex = 0;
    this.groupBox1.TabStop = false;
    // 
    // hotListBomButton
    // 
    this.hotListBomButton.Location = new System.Drawing.Point(14, 50);
    this.hotListBomButton.Name = "hotListBomButton";
    this.hotListBomButton.Size = new System.Drawing.Size(120, 24);
    this.hotListBomButton.TabIndex = 10;
    this.hotListBomButton.Text = "Hot List Bom";
    this.hotListBomButton.Click += new System.EventHandler(this.hotListBomButton_Click);
    // 
    // resumeButton
    // 
    this.resumeButton.Location = new System.Drawing.Point(134, 114);
    this.resumeButton.Name = "resumeButton";
    this.resumeButton.Size = new System.Drawing.Size(120, 24);
    this.resumeButton.TabIndex = 9;
    this.resumeButton.Text = "Compare HL Res";
    this.resumeButton.Click += new System.EventHandler(this.resumeButton_Click);
    // 
    // compareButton
    // 
    this.compareButton.Location = new System.Drawing.Point(14, 114);
    this.compareButton.Name = "compareButton";
    this.compareButton.Size = new System.Drawing.Size(120, 24);
    this.compareButton.TabIndex = 8;
    this.compareButton.Text = "Compare HL";
    this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
    // 
    // matCalcButton
    // 
    this.matCalcButton.Location = new System.Drawing.Point(134, 82);
    this.matCalcButton.Name = "matCalcButton";
    this.matCalcButton.Size = new System.Drawing.Size(120, 24);
    this.matCalcButton.TabIndex = 7;
    this.matCalcButton.Text = "Material Calculus";
    this.matCalcButton.Click += new System.EventHandler(this.matCalcButton_Click);
    // 
    // btnGenerate
    // 
    this.btnGenerate.Location = new System.Drawing.Point(14, 18);
    this.btnGenerate.Name = "btnGenerate";
    this.btnGenerate.Size = new System.Drawing.Size(120, 24);
    this.btnGenerate.TabIndex = 0;
    this.btnGenerate.Text = "Create Hot-List";
    this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
    // 
    // materialsButton
    // 
    this.materialsButton.Location = new System.Drawing.Point(14, 82);
    this.materialsButton.Name = "materialsButton";
    this.materialsButton.Size = new System.Drawing.Size(120, 24);
    this.materialsButton.TabIndex = 5;
    this.materialsButton.Text = "Materials";
    this.materialsButton.Click += new System.EventHandler(this.materialsButton_Click);
    // 
    // demandButton
    // 
    this.demandButton.Location = new System.Drawing.Point(134, 50);
    this.demandButton.Name = "demandButton";
    this.demandButton.Size = new System.Drawing.Size(120, 24);
    this.demandButton.TabIndex = 5;
    this.demandButton.Text = "Demand";
    this.demandButton.Click += new System.EventHandler(this.demandButton_Click);
    // 
    // btmReport
    // 
    this.btmReport.Location = new System.Drawing.Point(134, 18);
    this.btmReport.Name = "btmReport";
    this.btmReport.Size = new System.Drawing.Size(120, 24);
    this.btmReport.TabIndex = 1;
    this.btmReport.Text = "Report";
    this.btmReport.Click += new System.EventHandler(this.btmReport_Click);
    // 
    // groupBox3
    // 
    this.groupBox3.Controls.Add(this.includeInactivePartsCheckBox);
    this.groupBox3.Controls.Add(this.lastVersionCheckBox);
    this.groupBox3.Controls.Add(this.btnFilterMG);
    this.groupBox3.Controls.Add(this.hotListHoursButton);
    this.groupBox3.Controls.Add(this.LicheckBox);
    this.groupBox3.Controls.Add(this.button3);
    this.groupBox3.Controls.Add(this.btnFilters);
    this.groupBox3.Controls.Add(this.button1);
    this.groupBox3.Controls.Add(this.finalizedsCheckBox);
    this.groupBox3.Controls.Add(this.componentsCheckBox);
    this.groupBox3.Location = new System.Drawing.Point(604, 0);
    this.groupBox3.Name = "groupBox3";
    this.groupBox3.Size = new System.Drawing.Size(285, 152);
    this.groupBox3.TabIndex = 4;
    this.groupBox3.TabStop = false;
    this.groupBox3.Text = "Filters";
    // 
    // includeInactivePartsCheckBox
    // 
    this.includeInactivePartsCheckBox.Checked = true;
    this.includeInactivePartsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
    this.includeInactivePartsCheckBox.Location = new System.Drawing.Point(152, 48);
    this.includeInactivePartsCheckBox.Name = "includeInactivePartsCheckBox";
    this.includeInactivePartsCheckBox.Size = new System.Drawing.Size(129, 24);
    this.includeInactivePartsCheckBox.TabIndex = 10;
    this.includeInactivePartsCheckBox.Text = "Include Inactive Parts";
    // 
    // lastVersionCheckBox
    // 
    this.lastVersionCheckBox.Checked = true;
    this.lastVersionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
    this.lastVersionCheckBox.Location = new System.Drawing.Point(32, 128);
    this.lastVersionCheckBox.Name = "lastVersionCheckBox";
    this.lastVersionCheckBox.Size = new System.Drawing.Size(104, 20);
    this.lastVersionCheckBox.TabIndex = 9;
    this.lastVersionCheckBox.Text = "Last Version";
    // 
    // btnFilterMG
    // 
    this.btnFilterMG.Location = new System.Drawing.Point(16, 64);
    this.btnFilterMG.Name = "btnFilterMG";
    this.btnFilterMG.Size = new System.Drawing.Size(120, 23);
    this.btnFilterMG.TabIndex = 8;
    this.btnFilterMG.Text = " by Minor Group";
    this.btnFilterMG.Click += new System.EventHandler(this.btnFilterMG_Click);
    // 
    // hotListHoursButton
    // 
    this.hotListHoursButton.Location = new System.Drawing.Point(184, 112);
    this.hotListHoursButton.Name = "hotListHoursButton";
    this.hotListHoursButton.Size = new System.Drawing.Size(88, 23);
    this.hotListHoursButton.TabIndex = 7;
    this.hotListHoursButton.Text = "Hot List Hours";
    this.hotListHoursButton.Click += new System.EventHandler(this.hotListHoursButton_Click);
    // 
    // LicheckBox
    // 
    this.LicheckBox.Checked = true;
    this.LicheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
    this.LicheckBox.Location = new System.Drawing.Point(152, 24);
    this.LicheckBox.Name = "LicheckBox";
    this.LicheckBox.Size = new System.Drawing.Size(123, 24);
    this.LicheckBox.TabIndex = 5;
    this.LicheckBox.Text = "Include LI* Parts";
    // 
    // button3
    // 
    this.button3.Location = new System.Drawing.Point(184, 88);
    this.button3.Name = "button3";
    this.button3.Size = new System.Drawing.Size(88, 23);
    this.button3.TabIndex = 4;
    this.button3.Text = "Refresh Grid";
    this.button3.Click += new System.EventHandler(this.button3_Click);
    // 
    // btnFilters
    // 
    this.btnFilters.Location = new System.Drawing.Point(16, 16);
    this.btnFilters.Name = "btnFilters";
    this.btnFilters.Size = new System.Drawing.Size(120, 24);
    this.btnFilters.TabIndex = 2;
    this.btnFilters.Text = " by Dept";
    this.btnFilters.Click += new System.EventHandler(this.btnFilters_Click);
    // 
    // button1
    // 
    this.button1.Location = new System.Drawing.Point(16, 40);
    this.button1.Name = "button1";
    this.button1.Size = new System.Drawing.Size(120, 23);
    this.button1.TabIndex = 3;
    this.button1.Text = " by Part";
    this.button1.Click += new System.EventHandler(this.button1_Click);
    // 
    // finalizedsCheckBox
    // 
    this.finalizedsCheckBox.Checked = true;
    this.finalizedsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
    this.finalizedsCheckBox.Location = new System.Drawing.Point(32, 96);
    this.finalizedsCheckBox.Name = "finalizedsCheckBox";
    this.finalizedsCheckBox.Size = new System.Drawing.Size(104, 16);
    this.finalizedsCheckBox.TabIndex = 6;
    this.finalizedsCheckBox.Text = "Finished Parts";
    // 
    // componentsCheckBox
    // 
    this.componentsCheckBox.Checked = true;
    this.componentsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
    this.componentsCheckBox.Location = new System.Drawing.Point(32, 112);
    this.componentsCheckBox.Name = "componentsCheckBox";
    this.componentsCheckBox.Size = new System.Drawing.Size(104, 16);
    this.componentsCheckBox.TabIndex = 5;
    this.componentsCheckBox.Text = "WIP Parts";
    // 
    // tabPage2
    // 
    this.tabPage2.Controls.Add(this.label8);
    this.tabPage2.Controls.Add(this.matLocButton);
    this.tabPage2.Controls.Add(this.label7);
    this.tabPage2.Controls.Add(this.dftPlantTextBox);
    this.tabPage2.Controls.Add(this.btnTab2Refresh);
    this.tabPage2.Controls.Add(this.label2);
    this.tabPage2.Controls.Add(this.label1);
    this.tabPage2.Controls.Add(this.btnWipGoods);
    this.tabPage2.Controls.Add(this.btnFinishedGoods);
    this.tabPage2.Location = new System.Drawing.Point(4, 22);
    this.tabPage2.Name = "tabPage2";
    this.tabPage2.Size = new System.Drawing.Size(896, 158);
    this.tabPage2.TabIndex = 1;
    this.tabPage2.Text = "Hot List Filters";
    // 
    // label8
    // 
    this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    this.label8.Location = new System.Drawing.Point(160, 108);
    this.label8.Name = "label8";
    this.label8.Size = new System.Drawing.Size(248, 16);
    this.label8.TabIndex = 8;
    this.label8.Text = "Filter Materials Stock Locations";
    // 
    // matLocButton
    // 
    this.matLocButton.Location = new System.Drawing.Point(24, 103);
    this.matLocButton.Name = "matLocButton";
    this.matLocButton.Size = new System.Drawing.Size(120, 23);
    this.matLocButton.TabIndex = 7;
    this.matLocButton.Text = "Materials Locations";
    this.matLocButton.Click += new System.EventHandler(this.matLocButton_Click);
    // 
    // label7
    // 
    this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    this.label7.Location = new System.Drawing.Point(448, 31);
    this.label7.Name = "label7";
    this.label7.Size = new System.Drawing.Size(80, 16);
    this.label7.TabIndex = 6;
    this.label7.Text = "Default Plant";
    // 
    // dftPlantTextBox
    // 
    this.dftPlantTextBox.Enabled = false;
    this.dftPlantTextBox.Location = new System.Drawing.Point(535, 27);
    this.dftPlantTextBox.Name = "dftPlantTextBox";
    this.dftPlantTextBox.Size = new System.Drawing.Size(100, 20);
    this.dftPlantTextBox.TabIndex = 5;
    // 
    // btnTab2Refresh
    // 
    this.btnTab2Refresh.Location = new System.Drawing.Point(720, 112);
    this.btnTab2Refresh.Name = "btnTab2Refresh";
    this.btnTab2Refresh.Size = new System.Drawing.Size(120, 24);
    this.btnTab2Refresh.TabIndex = 4;
    this.btnTab2Refresh.Text = "Refresh Grid";
    this.btnTab2Refresh.Click += new System.EventHandler(this.btnTab2Refresh_Click);
    // 
    // label2
    // 
    this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    this.label2.Location = new System.Drawing.Point(160, 68);
    this.label2.Name = "label2";
    this.label2.Size = new System.Drawing.Size(248, 16);
    this.label2.TabIndex = 3;
    this.label2.Text = "Filter WIP Goods by Stock Location";
    // 
    // label1
    // 
    this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    this.label1.Location = new System.Drawing.Point(160, 28);
    this.label1.Name = "label1";
    this.label1.Size = new System.Drawing.Size(248, 16);
    this.label1.TabIndex = 2;
    this.label1.Text = "Filter Finished Goods by Stock Location";
    // 
    // btnWipGoods
    // 
    this.btnWipGoods.Location = new System.Drawing.Point(24, 63);
    this.btnWipGoods.Name = "btnWipGoods";
    this.btnWipGoods.Size = new System.Drawing.Size(120, 23);
    this.btnWipGoods.TabIndex = 1;
    this.btnWipGoods.Text = "Wip Goods";
    this.btnWipGoods.Click += new System.EventHandler(this.btnWipGoods_Click);
    // 
    // btnFinishedGoods
    // 
    this.btnFinishedGoods.Location = new System.Drawing.Point(24, 23);
    this.btnFinishedGoods.Name = "btnFinishedGoods";
    this.btnFinishedGoods.Size = new System.Drawing.Size(120, 23);
    this.btnFinishedGoods.TabIndex = 0;
    this.btnFinishedGoods.Text = "Finished Goods";
    this.btnFinishedGoods.Click += new System.EventHandler(this.btnFinishedGoods_Click);
    // 
    // tabPage3
    // 
    this.tabPage3.Controls.Add(this.groupBox4);
    this.tabPage3.Location = new System.Drawing.Point(4, 22);
    this.tabPage3.Name = "tabPage3";
    this.tabPage3.Size = new System.Drawing.Size(896, 158);
    this.tabPage3.TabIndex = 2;
    this.tabPage3.Text = "Automate Transfer";
    // 
    // groupBox4
    // 
    this.groupBox4.Controls.Add(this.generateHotListButton);
    this.groupBox4.Controls.Add(this.totalsButton);
    this.groupBox4.Controls.Add(this.noRunEndMinUpDown);
    this.groupBox4.Controls.Add(this.noRunEndHourUpDown);
    this.groupBox4.Controls.Add(this.noRunStartMinUpDown);
    this.groupBox4.Controls.Add(this.noRunStartHourUpDown);
    this.groupBox4.Controls.Add(this.minutesUpDown);
    this.groupBox4.Controls.Add(this.label6);
    this.groupBox4.Controls.Add(this.label5);
    this.groupBox4.Controls.Add(this.refreshTaskButton);
    this.groupBox4.Controls.Add(this.label4);
    this.groupBox4.Controls.Add(this.adicionalInfoTextBox);
    this.groupBox4.Controls.Add(this.autoTransferCheckBox);
    this.groupBox4.Controls.Add(this.label3);
    this.groupBox4.Controls.Add(this.startButton);
    this.groupBox4.Location = new System.Drawing.Point(8, 16);
    this.groupBox4.Name = "groupBox4";
    this.groupBox4.Size = new System.Drawing.Size(880, 120);
    this.groupBox4.TabIndex = 4;
    this.groupBox4.TabStop = false;
    this.groupBox4.Text = "Auto-Run Data";
    // 
    // generateHotListButton
    // 
    this.generateHotListButton.Location = new System.Drawing.Point(408, 16);
    this.generateHotListButton.Name = "generateHotListButton";
    this.generateHotListButton.Size = new System.Drawing.Size(96, 23);
    this.generateHotListButton.TabIndex = 17;
    this.generateHotListButton.Text = "Gen HotList";
    this.generateHotListButton.Click += new System.EventHandler(this.generateHotListButton_Click);
    // 
    // totalsButton
    // 
    this.totalsButton.Enabled = false;
    this.totalsButton.Location = new System.Drawing.Point(272, 16);
    this.totalsButton.Name = "totalsButton";
    this.totalsButton.Size = new System.Drawing.Size(96, 23);
    this.totalsButton.TabIndex = 16;
    this.totalsButton.Text = "Totals Report";
    this.totalsButton.Click += new System.EventHandler(this.totalsButton_Click);
    // 
    // noRunEndMinUpDown
    // 
    this.noRunEndMinUpDown.Location = new System.Drawing.Point(608, 88);
    this.noRunEndMinUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
    this.noRunEndMinUpDown.Name = "noRunEndMinUpDown";
    this.noRunEndMinUpDown.Size = new System.Drawing.Size(40, 20);
    this.noRunEndMinUpDown.TabIndex = 15;
    // 
    // noRunEndHourUpDown
    // 
    this.noRunEndHourUpDown.Location = new System.Drawing.Point(568, 88);
    this.noRunEndHourUpDown.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
    this.noRunEndHourUpDown.Name = "noRunEndHourUpDown";
    this.noRunEndHourUpDown.Size = new System.Drawing.Size(40, 20);
    this.noRunEndHourUpDown.TabIndex = 14;
    // 
    // noRunStartMinUpDown
    // 
    this.noRunStartMinUpDown.Location = new System.Drawing.Point(608, 64);
    this.noRunStartMinUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
    this.noRunStartMinUpDown.Name = "noRunStartMinUpDown";
    this.noRunStartMinUpDown.Size = new System.Drawing.Size(40, 20);
    this.noRunStartMinUpDown.TabIndex = 13;
    // 
    // noRunStartHourUpDown
    // 
    this.noRunStartHourUpDown.Location = new System.Drawing.Point(568, 64);
    this.noRunStartHourUpDown.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
    this.noRunStartHourUpDown.Name = "noRunStartHourUpDown";
    this.noRunStartHourUpDown.Size = new System.Drawing.Size(40, 20);
    this.noRunStartHourUpDown.TabIndex = 12;
    // 
    // minutesUpDown
    // 
    this.minutesUpDown.Location = new System.Drawing.Point(160, 64);
    this.minutesUpDown.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
    this.minutesUpDown.Name = "minutesUpDown";
    this.minutesUpDown.Size = new System.Drawing.Size(120, 20);
    this.minutesUpDown.TabIndex = 11;
    // 
    // label6
    // 
    this.label6.Location = new System.Drawing.Point(440, 88);
    this.label6.Name = "label6";
    this.label6.Size = new System.Drawing.Size(120, 16);
    this.label6.TabIndex = 8;
    this.label6.Text = "No Run End Time";
    // 
    // label5
    // 
    this.label5.Location = new System.Drawing.Point(440, 64);
    this.label5.Name = "label5";
    this.label5.Size = new System.Drawing.Size(120, 16);
    this.label5.TabIndex = 7;
    this.label5.Text = "No Run Start Time";
    // 
    // refreshTaskButton
    // 
    this.refreshTaskButton.Location = new System.Drawing.Point(776, 56);
    this.refreshTaskButton.Name = "refreshTaskButton";
    this.refreshTaskButton.Size = new System.Drawing.Size(75, 23);
    this.refreshTaskButton.TabIndex = 6;
    this.refreshTaskButton.Text = "Refresh";
    this.refreshTaskButton.Click += new System.EventHandler(this.refreshTaskButton_Click);
    // 
    // label4
    // 
    this.label4.Location = new System.Drawing.Point(24, 92);
    this.label4.Name = "label4";
    this.label4.Size = new System.Drawing.Size(120, 16);
    this.label4.TabIndex = 5;
    this.label4.Text = "Aditional Information";
    // 
    // adicionalInfoTextBox
    // 
    this.adicionalInfoTextBox.Location = new System.Drawing.Point(160, 88);
    this.adicionalInfoTextBox.Name = "adicionalInfoTextBox";
    this.adicionalInfoTextBox.Size = new System.Drawing.Size(240, 20);
    this.adicionalInfoTextBox.TabIndex = 4;
    // 
    // autoTransferCheckBox
    // 
    this.autoTransferCheckBox.Location = new System.Drawing.Point(24, 32);
    this.autoTransferCheckBox.Name = "autoTransferCheckBox";
    this.autoTransferCheckBox.Size = new System.Drawing.Size(160, 24);
    this.autoTransferCheckBox.TabIndex = 0;
    this.autoTransferCheckBox.Text = "Automate Transfer enabled";
    this.autoTransferCheckBox.CheckedChanged += new System.EventHandler(this.autoTransferCheckBox_CheckedChanged);
    // 
    // label3
    // 
    this.label3.Location = new System.Drawing.Point(24, 64);
    this.label3.Name = "label3";
    this.label3.Size = new System.Drawing.Size(128, 16);
    this.label3.TabIndex = 2;
    this.label3.Text = "Elapsed Time (minutes)";
    // 
    // startButton
    // 
    this.startButton.Location = new System.Drawing.Point(776, 24);
    this.startButton.Name = "startButton";
    this.startButton.Size = new System.Drawing.Size(75, 23);
    this.startButton.TabIndex = 3;
    this.startButton.Text = "Ok";
    this.startButton.Click += new System.EventHandler(this.startButton_Click);
    // 
    // gridHotList
    // 
    this.gridHotList.DataMember = "";
    this.gridHotList.HeaderForeColor = System.Drawing.SystemColors.ControlText;
    this.gridHotList.Location = new System.Drawing.Point(16, 208);
    this.gridHotList.Name = "gridHotList";
    this.gridHotList.ReadOnly = true;
    this.gridHotList.Size = new System.Drawing.Size(130, 80);
    this.gridHotList.TabIndex = 1;
    this.gridHotList.Click += new System.EventHandler(this.gridHotList_Click);
    // 
    // statusBarMessage
    // 
    this.statusBarMessage.Location = new System.Drawing.Point(0, 482);
    this.statusBarMessage.Name = "statusBarMessage";
    this.statusBarMessage.Size = new System.Drawing.Size(926, 22);
    this.statusBarMessage.TabIndex = 2;
    // 
    // daysCheckBox
    // 
    this.daysCheckBox.Checked = true;
    this.daysCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
    this.daysCheckBox.Location = new System.Drawing.Point(211, 48);
    this.daysCheckBox.Name = "daysCheckBox";
    this.daysCheckBox.Size = new System.Drawing.Size(90, 16);
    this.daysCheckBox.TabIndex = 14;
    this.daysCheckBox.Text = "10 days";
    // 
    // HotListForm
    // 
    this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
    this.ClientSize = new System.Drawing.Size(926, 504);
    this.Controls.Add(this.statusBarMessage);
    this.Controls.Add(this.gridHotList);
    this.Controls.Add(this.tabHotList);
    this.Name = "HotListForm";
    this.Text = "Hot List";
    this.SizeChanged += new System.EventHandler(this.HotListForm_SizeChanged);
    this.Closed += new System.EventHandler(this.OnClose);
    this.Closing += new System.ComponentModel.CancelEventHandler(this.HotListForm_Closing);
    this.tabHotList.ResumeLayout(false);
    this.tabPage1.ResumeLayout(false);
    this.groupBox5.ResumeLayout(false);
    this.groupBox2.ResumeLayout(false);
    this.groupBox1.ResumeLayout(false);
    this.groupBox3.ResumeLayout(false);
    this.tabPage2.ResumeLayout(false);
    this.tabPage2.PerformLayout();
    this.tabPage3.ResumeLayout(false);
    this.groupBox4.ResumeLayout(false);
    this.groupBox4.PerformLayout();
    ((System.ComponentModel.ISupportInitialize)(this.noRunEndMinUpDown)).EndInit();
    ((System.ComponentModel.ISupportInitialize)(this.noRunEndHourUpDown)).EndInit();
    ((System.ComponentModel.ISupportInitialize)(this.noRunStartMinUpDown)).EndInit();
    ((System.ComponentModel.ISupportInitialize)(this.noRunStartHourUpDown)).EndInit();
    ((System.ComponentModel.ISupportInitialize)(this.minutesUpDown)).EndInit();
    ((System.ComponentModel.ISupportInitialize)(this.gridHotList)).EndInit();
    this.ResumeLayout(false);

}
#endregion


private 
void gridHotList_Click(object sender, System.EventArgs e){
	if (gridHotList.TableStyles.Count > 0){
		gridHotList.PreferredRowHeight = 10;
		DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();
		dgdtblStyle = gridHotList.TableStyles[0];
		dgdtblStyle.PreferredRowHeight = 10;
	}
}

private 
string[] loadFilterPartSql(){
	int countPart = 0;

	for(int i = 0; i < partFilter.Length; i++){
		if (partFilter[i][1].Equals("true")){
			if (partFilter[i][0].StartsWith("LI")){
				if (LicheckBox.Checked)
					countPart++;
			}else{
				countPart++;
			}
		}
	}



	int indexPart = 0;
	string[] partFilterAux = new String[countPart];

	for(int i = 0; i <partFilter.Length; i++){
		if (partFilter[i][1].Equals("true")){
			if (partFilter[i][0].StartsWith("LI")){
				if (LicheckBox.Checked){
					partFilterAux[indexPart] = partFilter[i][0];
					indexPart++;
				}
			}else{
				partFilterAux[indexPart] = partFilter[i][0];
				indexPart++;
			}
		}
	}

	return partFilterAux;
}

private 
string[] loadFilterDeptSql(){
	int countDept = 0;
	for(int i = 0; i < deptFilter.Length; i++)
		if (deptFilter[i][1].Equals("true"))
			countDept++;
	int indexDept = 0;
	string[] deptFilterAux = new String[countDept];

	for(int i = 0; i <deptFilter.Length; i++){
		if (deptFilter[i][1].Equals("true")){
			string aux = deptFilter[i][0];
			deptFilterAux[indexDept] = deptFilter[i][0];
			indexDept++;
		}
	}
	return deptFilterAux;
}

private 
string[] loadFilterMgSql(){
	int countMg = 0;
	for(int i = 0; i < mgFilter.Length; i++)
		if (mgFilter[i][1].Equals("true"))
			countMg++;
	int indexMg = 0;
	string[] mgFilterAux = new String[countMg];

	for(int i = 0; i < mgFilter.Length; i++){
		if (mgFilter[i][1].Equals("true")){
			string aux = mgFilter[i][0];
			mgFilterAux[indexMg] = mgFilter[i][0];
			indexMg++;
		}
	}
	return mgFilterAux;
}

public
void loadGridHotList(){
	lock(this){
		string[] vecFilterPart = loadFilterPartSql();
		string[] vecFilterDept = loadFilterDeptSql();
		string[] vecFilterMg = loadFilterMgSql();
		string type = getPartType();

		int hlid = 0;
		string generated = "";
		string exploded = "";

		if (!lastVersionCheckBox.Checked){
			HotListVersionForm hotListVersionForm = new HotListVersionForm(false);
			hotListVersionForm.ShowDialog();

			if (hotListVersionForm.DialogResult == DialogResult.OK){
				hlid = int.Parse(hotListVersionForm.getSelected()[0][0]);
				generated = hotListVersionForm.getSelected()[0][1];
				exploded = hotListVersionForm.getSelected()[0][2];
			}else{
				return;
			}
		}

		DataSet dsHotList = LoadHotListGrid.generateHotListDataSet(vecFilterDept, vecFilterPart, vecFilterMg, false, type, hlid);

		if (dsHotList != null && dsHotList.Tables.Count >0 ){
			this.gridHotList.DataSource = dsHotList.Tables[0];

			int numRows = 0;
			if (dsHotList.Tables.Count>0)
				numRows = dsHotList.Tables[0].Rows.Count;

			if (hlid == 0){
				string[] v = coreFactory.getHotListLogData();
				this.lastHLCreated = DateUtil.parseCompleteDate(v[0],DateUtil.MMDDYYYY);
				this.lastMatExplosion = DateUtil.parseCompleteDate(v[1],DateUtil.MMDDYYYY);

				gridHotList.CaptionText = numRows.ToString() + " records generated, " + 
					"Hotlist Generated on : " + v[0] + ", Material Explosion on : " + v[1];
			}else{
				this.lastHLCreated = DateUtil.parseCompleteDate(generated, DateUtil.MMDDYYYY);
				this.lastMatExplosion = DateUtil.parseCompleteDate(exploded, DateUtil.MMDDYYYY);

				gridHotList.CaptionText = numRows.ToString() + " records generated, " + 
					"Hotlist Generated on : " + generated + ", Material Explosion on : " + exploded;
			}

			gridHotList = LoadHotListGrid.initializeItemsGrid(dsHotList, gridHotList);
			gridHotList.Refresh();
		}
		else{
			this.gridHotList.DataSource = null;
			MessageBox.Show("HotList is empty or something wrong");
		}
		this.Cursor = Cursors.Default;
	}
}//end loadGridHotList

private 
void btnGenerate_Click(object sender, System.EventArgs e){
	if (hotLisBlocked())
	{
		DialogResult deleteConfirm = MessageBox.Show("This function is blocked, continue ?", "Hot List", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (deleteConfirm == DialogResult.No)
			return;
	}

	try{
		string[][] badWipb = null;
		badWipb = generateHotList();

		loadFilterPart();
		loadFilterDept();
		getNewFilterMG();
		loadGridHotList();

		if (badWipb.Length > 0){
			DialogResult deleteConfirm = MessageBox.Show("There are parts in Wipb with inventory, do you want to see ?", "Finalized parts ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (deleteConfirm == DialogResult.Yes){
				DiscardWipbForm discardWipbForm = new DiscardWipbForm(badWipb);
				discardWipbForm.ShowDialog();
				discardWipbForm.Dispose();
			}
		}

		string[][] vecErrorsBom = coreFactory.getErrorsBom();
		if (vecErrorsBom.Length > 0){
			DialogResult confirm = MessageBox.Show("There are errors in Bom Proccess, do you want to see ?", "Bom parts ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (confirm == DialogResult.Yes){
				DiscardBomForm discardBomForm = new DiscardBomForm(vecErrorsBom);
				discardBomForm.ShowDialog();
				discardBomForm.Dispose();
			}
		}
	}catch(NujitException nexc){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		FormException formException = new FormException(nexc);
		formException.ShowDialog();
	}
}

private 
string[][] generateHotList(){
	string[][] badWipb = new string[0][];
	
	if (formMainParent != null)
		this.formMainParent.statusBarPanelMessage.Text	= "Generating Inventory...";
	this.Cursor = Cursors.WaitCursor;

	int countWipb = 0;
	int countStkb = 0;

	for(int i = 0; i < wipbFilter.Length; i++)
		if (wipbFilter[i][1].Equals("true"))
			countWipb++;
	for(int i = 0; i < stkbFilter.Length; i++)
		if (stkbFilter[i][1].Equals("true"))
			countStkb++;
	
	int indexWipb = 0;
	int indexStkb = 0;
	
	string[] stkbFilterAux = new String[countStkb];
	for(int i = 0; i < stkbFilter.Length; i++){
		if (stkbFilter[i][1].Equals("true")){
			stkbFilterAux[indexStkb] = stkbFilter[i][0];
			int beginIndex = stkbFilterAux[indexStkb].IndexOfAny(",".ToCharArray());
			stkbFilterAux[indexStkb] = stkbFilterAux[indexStkb].Substring(0, beginIndex);
			indexStkb++;
		}
	}

	string[] wipbFilterAux = new String[countWipb];
	for(int i = 0; i < wipbFilter.Length; i++){
		if (wipbFilter[i][1].Equals("true")){
			wipbFilterAux[indexWipb] = wipbFilter[i][0];
			int beginIndex = wipbFilterAux[indexWipb].IndexOfAny(",".ToCharArray());
			wipbFilterAux[indexWipb] = wipbFilterAux[indexWipb].Substring(0, beginIndex);
			indexWipb++;
		}
	}
	
	try{
		coreFactory.createHotList(stkbFilterAux, wipbFilterAux, badWipb);
	}catch(NujitException nexc){
		FormException formException = new FormException(nexc);
		formException.ShowDialog();
	}

	this.Cursor = System.Windows.Forms.Cursors.Default;
	if (this.Parent != null)
		this.formMainParent.statusBarPanelMessage.Text	= "Done!";

	return badWipb;
}//end btnGenerate_Click

private 
void btmReport_Click(object sender, System.EventArgs e){
	callHotListReport(false, this.daysCheckBox.Checked);
}

private 
void callHotListReport(bool hotListBom, bool lessDays){
	if (hotLisBlocked()){
		DialogResult deleteConfirm = MessageBox.Show("This function is blocked, continue ?", "Hot List", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (deleteConfirm == DialogResult.No)
			return;
	}

	try{	
	    if (!showNewDataHotList())	
		    generateHotListReport(hotListBom, lessDays);
	}catch(Exception men){
		FormException formException = new FormException(men);
		formException.ShowDialog();
	}
}

private 
void generateHotListReport(bool hotListBom, bool lessDays){
	bool hoursReport = hoursReportCheckBox.Checked;
	bool labourReport = labourCheckBox.Checked;
	string[] filterPart = loadFilterPartSql();
	string[] filterDept = loadFilterDeptSql();
	string[] filterMg = loadFilterMgSql();
	string type = getPartType();

	int hlid = 0;
	string generated = "";
	string exploded = "";
	if (!lastVersionCheckBox.Checked){
		HotListVersionForm hotListVersionForm = new HotListVersionForm(false);
		hotListVersionForm.ShowDialog();

		if (hotListVersionForm.DialogResult == DialogResult.OK){
			hlid = int.Parse(hotListVersionForm.getSelected()[0][0]);
			generated = hotListVersionForm.getSelected()[0][1];
			exploded = hotListVersionForm.getSelected()[0][2];
		}else{
			return;
		}
	}

	DataSet dsReport = generateReportDataSet(filterDept, filterPart, filterMg, type,
		orderByMGCheckBox.Checked, cboxSunSatToFriday.Checked, reportingPointCheckBox.Checked,
			hoursReport, orderByResCheckBox.Checked, labourReport, majorMinorCheckBox.Checked, 
			hlid, hotListBom);

	 if (dsReport.Tables["hotListReport"].Rows.Count == 0) {
		this.Cursor = System.Windows.Forms.Cursors.Default;
		if (formMainParent != null)
			this.formMainParent.statusBarPanelMessage.Text	= " ";
		MessageBox.Show("There is no information to display");
	}else{
		try{
			string title = "";
			if (getPartType().Equals("B"))
				title = "All Products Hotlist";
			if (getPartType().Equals("Y"))
				title = "Finished Products Hotlist";
			if (getPartType().Equals("N"))
				title = "WIPB Products Hotlist";
            
            if (cboxSunSatToFriday.Checked)//The option for exclude Sat/Sun is selected
                title += " Exclude Sat/Sun";
            
			if (hotListBom){
				HotListBomReport hotListBomReport = new HotListBomReport(dsReport, title,
						cboxSunSatToFriday.Checked, hoursReport, labourReport, noZeroesCheckBox.Checked,
						generated, exploded, hotListBom, lessDays);
				hotListBomReport.Show();
				return;
			}

			if (mainMatCheckBox.Checked){
				if (orderByMGCheckBox.Checked){
					HotListReportByMGroupMainMat hlmgmm = new HotListReportByMGroupMainMat(dsReport, title,
						cboxSunSatToFriday.Checked, hoursReport, labourReport, noZeroesCheckBox.Checked,
                        generated, exploded, hotListBom, lessDays);
					hlmgmm.Show();
				}else{
					HotListReportMainMaterial hlr = new HotListReportMainMaterial(dsReport, title,
						cboxSunSatToFriday.Checked, hoursReport, labourReport, noZeroesCheckBox.Checked,
                        generated, exploded, hotListBom, lessDays);
					hlr.Show();
				}
			}else{
			    if (orderByMGCheckBox.Checked){
					    HotListReportByMGroup hlr2 = new HotListReportByMGroup(dsReport, title, 
							cboxSunSatToFriday.Checked, hoursReport, labourReport,
                            noZeroesCheckBox.Checked, generated, exploded, hotListBom, lessDays);
					    hlr2.Show();
				}else{
					if (orderByResCheckBox.Checked){
						HotListReportByResource hotListReportByResource = new HotListReportByResource(dsReport, 
							title, hoursReport, labourReport, noZeroesCheckBox.Checked,
                            cboxSunSatToFriday.Checked, generated, exploded, hotListBom, lessDays);
						hotListReportByResource.Show();
					}else{
						if (majorMinorCheckBox.Checked){
							HotListReportByMajorMinorGroup hlrMajorMinor = new HotListReportByMajorMinorGroup(dsReport, title.Trim() + " By Major - Minor Group", 
								cboxSunSatToFriday.Checked, hoursReport, labourReport,
                                noZeroesCheckBox.Checked, generated, exploded, hotListBom, lessDays);
							hlrMajorMinor.Show();
						}else{
							HotListReport hlr = new HotListReport(dsReport, title, 
									cboxSunSatToFriday.Checked, hoursReport, labourReport,
                                    noZeroesCheckBox.Checked, generated, exploded, hotListBom, lessDays);
							hlr.Show();
						}
					}
				}
			}
		}catch(Exception men){
			FormException formException = new FormException(men);
			formException.ShowDialog();
		}
	}
}

private	
void loadCuartos(){
	string[][] auxVec = coreFactory.getAllPltInvLocAsString();
	stkbFilter = new string[auxVec.Length][];
	wipbFilter = new string[auxVec.Length][];
	matbFilter = new string[auxVec.Length][];

	for(int i = 0; i < auxVec.Length; i++){
		string[] v1 = new string[2];
		string[] v2 = new string[2];
		string[] v3 = new string[2];
		
		v1[0] = auxVec[i][0] + ", " + auxVec[i][1];
		v2[0] = auxVec[i][0] + ", " + auxVec[i][1];
		v3[0] = auxVec[i][0] + ", " + auxVec[i][1];

		if (auxVec[i][2].Equals("Y")){
			v1[1] = "true";
			v2[1] = "true";
		}else{
			v1[1] = "false";
			v2[1] = "false";
		}
		
		v3[1] = "false";
		string stkLocsTxt = Nujit.NujitERP.ClassLib.Common.Configuration.StkLocsMaterials;
		string[] stklocs = stkLocsTxt.Split(',');
		for(int j=0;j<stklocs.Length;j++){
			if (auxVec[i][0].Equals(stklocs[j]))
				v3[1] = "true";
		}

		wipbFilter[i] = v1;
		stkbFilter[i] = v2;
		matbFilter[i] = v3;
	}
}//end loadCuartos

private	
void loadFilterPart(){
	bool inactive = this.includeInactivePartsCheckBox.Checked;
	string[] vecAux = coreFactory.getAllPartFromHotListAsString(0, inactive);//CM 11/10/2005
	partFilter = new string[vecAux.Length][];
	for(int i = 0; i < vecAux.Length; i++){
		string[] v = new string[2];
		v[0] = vecAux[i];
		v[1] = "true";		
		partFilter[i] = v;
	}
}

private	
void loadFilterMG(){
	string[] vecAux = coreFactory.getAllMGFromHotListAsString(0);//CM 11/10/2005
	mgFilter = new string[vecAux.Length][];
	for(int i = 0; i < vecAux.Length; i++){
		string[] v = new string[2];
		v[0] = vecAux[i];
		v[1] = "true";		
		mgFilter[i] = v;
	}
}

private	
void loadFilterDept(){
	string[] vecAux = coreFactory.getAllDeptFromHotListAsString();
	deptFilter = new string[vecAux.Length][] ;
	for(int i = 0; i < vecAux.Length; i++){
		string[] v = new string[2];
		v[0] = vecAux[i];
		v[1] = "true";		
		deptFilter[i] = v;
	}
}//end loadFilterDept

private 
void btnFinishedGoods_Click(object sender, System.EventArgs e){
	FilterForm filterForm = new FilterForm(stkbFilter);
	filterForm.ShowDialog();
			
	if (filterForm.DialogResult == DialogResult.OK)
		stkbFilter = filterForm.getItems();
}//end btnFinishedGoods_Click


private 
void btnFilters_Click(object sender, System.EventArgs e){
	FilterForm filterForm = new FilterForm(deptFilter);
	filterForm.ShowDialog();

	if (filterForm.DialogResult == DialogResult.OK)
		deptFilter = filterForm.getItems();
}

private 
void btnWipGoods_Click(object sender, System.EventArgs e){
	FilterForm filterForm = new FilterForm(wipbFilter);
	filterForm.ShowDialog();

	if (filterForm.DialogResult == DialogResult.OK)
		wipbFilter = filterForm.getItems();
}

private 
void button3_Click(object sender, System.EventArgs e){
	if (hotLisBlocked()){
		DialogResult deleteConfirm = MessageBox.Show("This function is blocked, continue ?", "Hot List", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (deleteConfirm == DialogResult.No)
			return;
	}

	this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
	if (formMainParent != null)
		formMainParent.statusBarPanelMessage.Text	= "Loading grid...";
	
	loadGridHotList();
	
	this.Cursor = System.Windows.Forms.Cursors.Default;
	if (formMainParent != null)
		formMainParent.statusBarPanelMessage.Text	= "Done!";
}

private 
void button1_Click(object sender, System.EventArgs e){
	FilterForm filterForm = new FilterForm(partFilter);
	filterForm.ShowDialog();

	if (filterForm.DialogResult == DialogResult.OK)
		partFilter = filterForm.getItems();
		
	filterForm.Dispose();
}

private 
void btnFilterMG_Click(object sender, System.EventArgs e){
	if (!showNewDataHotList()){
	    FilterForm filterForm = new FilterForm(mgFilter);
	    filterForm.ShowDialog();

	    if (filterForm.DialogResult == DialogResult.OK)
		    mgFilter = filterForm.getItems();
    		
	    filterForm.Dispose();
	}
}

private 
void btnTab2Refresh_Click(object sender, System.EventArgs e){
	if (hotLisBlocked()){
		DialogResult deleteConfirm = MessageBox.Show("This function is blocked, continue ?", "Hot List", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (deleteConfirm == DialogResult.No)
			return;
	}

	if (formMainParent != null)
		this.formMainParent.statusBarPanelMessage.Text	= "Loading grid...";
	
	loadGridHotList();
	
	if (formMainParent != null)
		this.formMainParent.statusBarPanelMessage.Text	= "Done!";
}

private 
void OnClose(object sender, System.EventArgs e){
	if (this.formMainParent != null){
		this.formMainParent.RemoveTab(this.Tag);
		this.formMainParent.SetButtons();

		this.coreFactory = null;
		this.Hide();
		this.Dispose();
	}	
}

private 
void HotListForm_Closing(object sender, System.ComponentModel.CancelEventArgs e){
	if (this.formMainParent != null){
		this.formMainParent.RemoveTab(this.Tag);
		this.formMainParent.SetButtons();
	}	
	this.coreFactory = null;
	this.Dispose();
}

private 
void materialsButton_Click(object sender, System.EventArgs e){
	if (hotLisBlocked()){
		DialogResult deleteConfirm = MessageBox.Show("This function is blocked, continue ?", "Hot List", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (deleteConfirm == DialogResult.No)
			return;
	}

	MaterialsForm materialsForm = new MaterialsForm(depureFilter(partFilter), depureFilter(deptFilter), depureFilter(matbFilter), this.daysCheckBox.Checked);
	materialsForm.Show();
}

private 
string[] depureFilter(string[][] filter){
	int counter = 0;
	for(int i = 0; i < filter.Length; i++)
		if (filter[i][1].Equals("true"))
			counter++;
	
	int index = 0;
	string[] filterAux = new String[counter];

	for(int i = 0; i < filter.Length; i++){
		if (filter[i][1].Equals("true")){
			string aux = filter[i][0];
			filterAux[index] = filter[i][0];
			index++;
		}
	}
	return filterAux;
}

private 
void HotListForm_SizeChanged(object sender, System.EventArgs e){
	w = this.Size.Width;
	h = this.Size.Height;

	this.gridHotList.Width = w - 40;
	this.gridHotList.Height = h - 300;
	this.gridHotList.Refresh();
}

private 
void releaseButton_Click(object sender, System.EventArgs e){
	GenerateReleasesForm generateReleasesForm = new GenerateReleasesForm();
	generateReleasesForm.ShowDialog();
}

private 
void releasesButton_Click(object sender, System.EventArgs e){
	VendorReleaseInquiryForm vendorReleaseInquiryForm = new VendorReleaseInquiryForm();
	vendorReleaseInquiryForm.ShowDialog();
}

private
string getPartType(){
	string type = "";

	if ((finalizedsCheckBox.Checked) && (componentsCheckBox.Checked)){
		type = "B";
	}else{
		if (finalizedsCheckBox.Checked){
			type = "Y";
		}else{
			if (componentsCheckBox.Checked){
				type = "N";
			}
		}
	}
	return type;
}


private 
void demandButton_Click(object sender, System.EventArgs e){
	string[] vecFilterPart = loadFilterPartSql();
	string[][] vec = coreFactory.getDemandAsString(vecFilterPart);

	DataTable dataTable = new DataTable();

	dataTable.TableName = "demand";
	dataTable.Columns.Add(new DataColumn("Part", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Qty", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Qoh", typeof(string)));

	string lastPart = "";
	for(int i = 0; i < vec.Length; i++){
		DataRow dataRow;
		dataRow = dataTable.NewRow();

		dataRow[0] = vec[i][0];
		dataRow[1] = vec[i][1];
		dataRow[2] = vec[i][2];
		dataRow[3] = vec[i][3];
		if (vec[i][0].Equals(lastPart)){
			dataRow[0] = "";
			dataRow[1] = vec[i][1];
			dataRow[2] = vec[i][2];
			dataRow[3] = "";
		}
		lastPart = vec[i][0];
		dataTable.Rows.Add(dataRow);
	}

	DataSet demandDataSet = new DataSet();
	demandDataSet.Tables.Add(dataTable);

	string[] v = coreFactory.getHotListLogData();
	string genDate = "Hotlist Generated on : " + v[0] + 
		", Material Explosion on : " + v[1];
	
	DemandReport demandReport = new DemandReport(demandDataSet, genDate);
	demandReport.Show();
}


public 
DataSet generateReportDataSet(string[] filterDept, string[] filterPart, string[] filterMg, string type,
			bool byMinorGroup, bool accumOnFridays, bool onlyReportingPoint, bool hoursReport,
			bool orderByResource, bool labourReport, bool orderByMajorMinorGrp, int hlid, bool hotListBom){

	DataTable hotListReportDataTable = new DataTable();
	DataRow dataRow;
	
	hotListReportDataTable.TableName = "hotListReport";	
	hotListReportDataTable = addColumns(hotListReportDataTable);
		
	bool demand = false;
	if (this.onlyDemand.Checked)
		demand = true;

	string[][] vec = null;
	if (!hotListBom){
		vec = coreFactory.getHotListReport(hlid, filterDept, filterPart, filterMg, demand, type,
			byMinorGroup, accumOnFridays, onlyReportingPoint, hoursReport, orderByResource, 
			labourReport, orderByMajorMinorGrp);
	}else{
		vec = coreFactory.getHotListBomReport(hlid, filterDept, filterPart, filterMg, demand,
			byMinorGroup, accumOnFridays, onlyReportingPoint, hoursReport, orderByResource, 
			labourReport, orderByMajorMinorGrp, partCheckBox.Checked);
	}

	for(int x = 0; x < vec.Length; x++){
		dataRow = hotListReportDataTable.NewRow();
		dataRow.ItemArray = vec[x];
		hotListReportDataTable.Rows.Add(dataRow);
	}

	DataSet hotListReportDataSet = new DataSet();
	hotListReportDataSet.Tables.Add(hotListReportDataTable);
	
	return hotListReportDataSet;
}

public static 
DataTable addColumns(DataTable hotListReportDT) {
	hotListReportDT.Columns.Add(new DataColumn("HOT_ProdID", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_ActID", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Seq", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Uom", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Dept", typeof(string)));			
	hotListReportDT.Columns.Add(new DataColumn("HOT_Mach", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_MachCyc", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Qoh", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_QohCml", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_PastDue",typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day001", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day002", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day003", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day004", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day005", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day006", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day007", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day008", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day009", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day010", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day011", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day012", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day013", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day014", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day015", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day016", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day017", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day018", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day019", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day020", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day021", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day022", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day023", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day024", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day025", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day026", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day027", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day028", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day029", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day030", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day031", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day032", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day033", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day034", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day035", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day036", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day037", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day038", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day039", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day040", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day041", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day042", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day043", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day044", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day045", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day046", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day047", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day048", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day049", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day050", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day051", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day052", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day053", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day054", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day055", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day056", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day057", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day058", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day059", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Day060", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_MajorGroup", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_MinorGroup", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Finalized", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_MinorGroupDesc", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_MainMaterial", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_MainMaterialSeq", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_MainMaterialQoh", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("MajorAndMinor", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("Hot_Id", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_MachDesc", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("HOT_Level", typeof(string)));
	hotListReportDT.Columns.Add(new DataColumn("MaterialDescription", typeof(string)));
	return hotListReportDT;
}

private 
void autoTransferCheckBox_CheckedChanged(object sender, System.EventArgs e){
	if (autoTransferCheckBox.Checked){
		minutesUpDown.Enabled = true;

		this.noRunEndHourUpDown.Enabled = true;
		this.noRunEndMinUpDown.Enabled = true;
		
		this.noRunStartHourUpDown.Enabled = true;
		this.noRunStartMinUpDown.Enabled = true;
	}else{
		minutesUpDown.Value = 0;
		minutesUpDown.Enabled = false;

		this.noRunEndHourUpDown.Value = 0;
		this.noRunEndMinUpDown.Value = 0;
		this.noRunEndHourUpDown.Enabled = false;
		this.noRunEndMinUpDown.Enabled = false;

		this.noRunStartHourUpDown.Value = 0;
		this.noRunStartMinUpDown.Value = 0;
		this.noRunStartHourUpDown.Enabled = false;
		this.noRunStartMinUpDown.Enabled = false;
	}
}

private 
void startButton_Click(object sender, System.EventArgs e){
	if (!autoTransferCheckBox.Checked){
		this.coreFactory.setAutimaticDelay(0);
		this.coreFactory.setNoRunStart(null);
		this.coreFactory.setNoRunEnd(null);
		return;
	}

	if (minutesUpDown.Value == 0){
		MessageBox.Show("Must enter a valid integer number in the minute box, please re-enter");
		return;
	}

	int countWipb = 0;
	int countStkb = 0;

	for(int i = 0; i < wipbFilter.Length; i++)
		if (wipbFilter[i][1].Equals("true"))
			countWipb++;
	for(int i = 0; i < stkbFilter.Length; i++)
		if (stkbFilter[i][1].Equals("true"))
			countStkb++;
	
	int indexWipb = 0;
	int indexStkb = 0;
	
	string[] stkbFilterAux = new String[countStkb];
	for(int i = 0; i < stkbFilter.Length; i++){
		if (stkbFilter[i][1].Equals("true")){
			stkbFilterAux[indexStkb] = stkbFilter[i][0];
			int beginIndex = stkbFilterAux[indexStkb].IndexOfAny(",".ToCharArray());
			stkbFilterAux[indexStkb] = stkbFilterAux[indexStkb].Substring(0, beginIndex);
			indexStkb++;
		}
	}

	string[] wipbFilterAux = new String[countWipb];
	for(int i = 0; i < wipbFilter.Length; i++){
		if (wipbFilter[i][1].Equals("true")){
			wipbFilterAux[indexWipb] = wipbFilter[i][0];
			int beginIndex = wipbFilterAux[indexWipb].IndexOfAny(",".ToCharArray());
			wipbFilterAux[indexWipb] = wipbFilterAux[indexWipb].Substring(0, beginIndex);
			indexWipb++;
		}
	}
	
	// millisec was zero, must re start engine
	if (coreFactory.getAutimaticDelay() == 0){
		int min = decimal.ToInt32(minutesUpDown.Value);
		this.coreFactory.setAutimaticDelay(min);
		
		string hourStart = this.noRunStartHourUpDown.Value.ToString();
		if (hourStart.Length == 1)
			hourStart = "0" + hourStart;
		string minStart = this.noRunStartMinUpDown.Value.ToString();
		if (minStart.Length == 1)
			minStart = "0" + minStart;
		this.coreFactory.setNoRunStart(hourStart + ":" + minStart);

		string hourEnd = this.noRunEndHourUpDown.Value.ToString();
		if (hourEnd.Length == 1)
			hourEnd = "0" + hourEnd;
		string minEnd = this.noRunEndMinUpDown.Value.ToString();
		if (minEnd.Length == 1)
			minEnd = "0" + minEnd;
		this.coreFactory.setNoRunEnd(hourEnd + ":" + minEnd);
		
		this.coreFactory.setFilters(stkbFilterAux, wipbFilterAux);

		this.coreFactory.insertTaskEngine(Task.TASK_GENERATE_HOTLIST, min.ToString());
	}else{
		// millisec was not zero, not re start engine, only change value
		
//		int milliseconds = decimal.ToInt32(minutesUpDown.Value) * 60 * 1000;
		this.coreFactory.setAutimaticDelay(decimal.ToInt32(minutesUpDown.Value));

		string hourStart = this.noRunStartHourUpDown.Value.ToString();
		if (hourStart.Length == 1)
			hourStart = "0" + hourStart;
		string minStart = this.noRunStartMinUpDown.Value.ToString();
		if (minStart.Length == 1)
			minStart = "0" + minStart;
		this.coreFactory.setNoRunStart(hourStart + ":" + minStart);

		string hourEnd = this.noRunEndHourUpDown.Value.ToString();
		if (hourEnd.Length == 1)
			hourEnd = "0" + hourEnd;
		string minEnd = this.noRunEndMinUpDown.Value.ToString();
		if (minEnd.Length == 1)
			minEnd = "0" + minEnd;
		this.coreFactory.setNoRunEnd(hourEnd + ":" + minEnd);

		this.coreFactory.setFilters(stkbFilterAux, wipbFilterAux);
	}

	MessageBox.Show("Auto-run Data entered correctly !!!");
	setAdicionalTaskData();
}

private 
void setStyles(){
	if (gridHotList.TableStyles.Count > 0){
		gridHotList.PreferredRowHeight = 10;
		DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();
		dgdtblStyle = gridHotList.TableStyles[0];
		dgdtblStyle.PreferredRowHeight = 10;
	}
}

private 
void refreshTaskButton_Click(object sender, System.EventArgs e){
	setAutoRunInfo();
}

private 
void hotListHoursButton_Click(object sender, System.EventArgs e){
	HotListMachineHours hotListMachineHours = new HotListMachineHours();
	hotListMachineHours.Show();
}

private 
void mainMatReportButton_Click(object sender, System.EventArgs e){
	if (hotLisBlocked()){
		DialogResult deleteConfirm = MessageBox.Show("This function is blocked, continue ?", "Hot List", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (deleteConfirm == DialogResult.No)
			return;
	}

	try{		
		generateHotListReport(false, this.daysCheckBox.Checked);
	}catch(Exception men){
		FormException formException = new FormException(men);
		formException.ShowDialog();
	}
}

private 
void matCalcButton_Click(object sender, System.EventArgs e){
	PossibleMaterialsForm possibleMaterialsForm = new PossibleMaterialsForm();
	possibleMaterialsForm.ShowDialog();
}

private 
bool showNewDataHotList(){
	try{
		bool returnValue = true;
	    
		if (newData()){//New data for hotlist is detected
			if (newFilter()){ //A new filter is detected with the new data
				DialogResult newFilterMsg = MessageBox.Show("There is new filter for Minor Group. Do you whant to change it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (newFilterMsg == DialogResult.Yes){ //Change the filter and show the new info in the grid
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					getNewFilterMG();
					loadGridHotList();
					this.Cursor = System.Windows.Forms.Cursors.Default;
					returnValue = false; //set in false so the filters forms is show up
				}else{
					DialogResult newDataMsg = MessageBox.Show("There is now data for show. Do you whant to see it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (newDataMsg == DialogResult.Yes){
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						loadGridHotList();
						this.Cursor = System.Windows.Forms.Cursors.Default;
					}else
						returnValue = false;
				}    
			}else{
				DialogResult newDataMsg = MessageBox.Show("There is now data for show. Do you whant to see it?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (newDataMsg == DialogResult.Yes){
    				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					loadGridHotList();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}else
					returnValue = false;
			}
		}else
			returnValue = false;

		return returnValue;
	}catch(NujitException nexc){
		FormException formException = new FormException(nexc);
		formException.ShowDialog();
		return false;
	}
}

private 
bool newData(){
    try{
        bool returnValue = false;
        string[] v = coreFactory.getHotListLogData();
        
	    if ((DateTime.Compare(DateUtil.parseCompleteDate(v[0],DateUtil.MMDDYYYY),lastHLCreated) != 0) &&
	        (DateTime.Compare(DateUtil.parseCompleteDate(v[1],DateUtil.MMDDYYYY),lastMatExplosion) != 0)){
    	    returnValue = true;
    	}
    	return returnValue;
    }catch(NujitException nexc){
		FormException formException = new FormException(nexc);
		formException.ShowDialog();
		return false;
	}
}

private 
void setValuesForFilter(string[][] oldFilter,string[][] newFilter){
    for(int i = 0; i < oldFilter.Length; i++){
		if (oldFilter[i][1].Equals("false")){ //This filter is set in false;
		    int posInNew = getPosition(oldFilter[i][0],newFilter);
		    if (posInNew != -1) //if the filter is not in the newone we get -1
		        newFilter[posInNew][1] = "false";
		}
   }
}

private 
int getPosition(string theValue,string[][] newFilter){
    int returnValue =-1;
    
    for (int i=0; i<newFilter.Length;i++){
        if(newFilter[i][0].Equals(theValue))        
            return i;
    }
    return returnValue;
}

private 
bool newFilter(){
    try{
        bool returnValue = true;
        string[] vecAux = coreFactory.getAllMGFromHotListAsString(0);//CM 11/10/2005
        if (vecAux.Length == this.mgFilter.Length){ //the filters has different lenght so they are not the same
            string[] vecMgFilter = new string[mgFilter.Length];
            for(int i = 0; i < mgFilter.Length; i++){
	            vecMgFilter[i] = vecAux[i];
            }
            if (!vecMgFilter.Equals(vecAux))
                 returnValue = false;
        }
        return returnValue;
    }catch(NujitException nexc){
		    FormException formException = new FormException(nexc);
		    formException.ShowDialog();
		    return false;
    }    
}

private 
void getNewFilterMG(){
    string[][] oldFilter = mgFilter;
    loadFilterMG();
    setValuesForFilter(oldFilter, mgFilter);
}

private 
void hoursReportButton_Click(object sender, System.EventArgs e){
	try{
		HotListHourContainer hotListHourContainer = coreFactory.getHotListHoursDays(0);//CM 11/10/2005

		DataTable dataTable = new DataTable();

		dataTable.TableName = "hotListHour";
		dataTable.Columns.Add(new DataColumn("HOT_Mach", typeof(string)));
		dataTable.Columns.Add(new DataColumn("HOT_PastDue", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day001", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day002", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day003", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day004", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day005", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day006", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day007", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day008", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day009", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day010", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day011", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day012", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day013", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day014", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day015", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day016", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day017", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day018", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day019", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day020", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day021", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day022", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day023", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day024", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day025", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day026", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day027", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day028", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day029", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day030", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day031", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day032", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day033", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day034", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day035", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day036", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day037", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day038", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day039", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day040", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day041", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day042", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day043", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day044", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day045", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day046", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day047", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day048", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day049", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day050", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day051", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day052", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day053", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day054", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day055", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day056", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day057", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day058", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day059", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day060", typeof(decimal)));
		
		dataTable.Columns.Add(new DataColumn("HOT_Day061", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day062", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day063", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day064", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day065", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day066", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day067", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day068", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day069", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day070", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day071", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day072", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day073", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day074", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day075", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day076", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day077", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day078", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day079", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day080", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day081", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day082", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day083", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day084", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day085", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day086", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day087", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day088", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day089", typeof(decimal)));
		dataTable.Columns.Add(new DataColumn("HOT_Day090", typeof(decimal)));


		
		for(int i = 0; i < hotListHourContainer.Count; i++){
			HotListHour hotListHour = (HotListHour)hotListHourContainer[i];

			string mach = hotListHour.getConfiguration();

//getHourDemand(int day)
		}

		DataSet dataSet = new DataSet();
		dataSet.Tables.Add(dataTable);

//		HotListHourReport hotListHourReport = new HotListHourReport(dataSet);
//		hotListHourReport.Show();
	}catch(NujitException nexc){
		FormException formException = new FormException(nexc);
		formException.ShowDialog();
    }    
}

private 
void hoursReportPartbutton_Click(object sender, System.EventArgs e){
	callHotListReport(false, this.daysCheckBox.Checked);
}

private 
void orderByMGCheckBox_CheckedChanged(object sender, System.EventArgs e){
	if (orderByMGCheckBox.Checked){
		orderByResCheckBox.Checked = false;

		mainMatCheckBox.Enabled = true;
		cboxSunSatToFriday.Enabled = true;
		reportingPointCheckBox.Enabled = true;
		hoursReportCheckBox.Enabled = true;
	}
}

private 
void orderByResCheckBox_CheckedChanged(object sender, System.EventArgs e){
	if (orderByResCheckBox.Checked){
		orderByMGCheckBox.Checked = false;
		majorMinorCheckBox.Checked = false;

		// not implemented options
		mainMatCheckBox.Checked = false;
		hoursReportCheckBox.Checked = false;

		mainMatCheckBox.Enabled = false;
		hoursReportCheckBox.Enabled = false;
	}else{
		mainMatCheckBox.Enabled = true;
		cboxSunSatToFriday.Enabled = true;
		reportingPointCheckBox.Enabled = true;
		hoursReportCheckBox.Enabled = true;
	}
}

private 
void labourCheckBox_CheckedChanged(object sender, System.EventArgs e){
	if (labourCheckBox.Checked)
		hoursReportCheckBox.Checked = false;
}

private 
void hoursReportCheckBox_CheckedChanged(object sender, System.EventArgs e){
	if (hoursReportCheckBox.Checked)
		labourCheckBox.Checked = false;
}

private 
void majorMinorCheckBox_CheckedChanged(object sender, System.EventArgs e){
	if (majorMinorCheckBox.Checked){
		orderByMGCheckBox.Checked = false;
		orderByResCheckBox.Checked = false;

		// not implemented options
		mainMatCheckBox.Checked = false;
		cboxSunSatToFriday.Checked = false;
		reportingPointCheckBox.Checked = false;
		hoursReportCheckBox.Checked = false;

		mainMatCheckBox.Enabled = false;
		cboxSunSatToFriday.Enabled = false;
		reportingPointCheckBox.Enabled = false;
		hoursReportCheckBox.Enabled = false;
	}else{
		mainMatCheckBox.Enabled = true;
		cboxSunSatToFriday.Enabled = true;
		reportingPointCheckBox.Enabled = true;
		hoursReportCheckBox.Enabled = true;
	}
}

private 
void totalsButton_Click(object sender, System.EventArgs e){
	AutomateDateForm automateDateForm = new AutomateDateForm("Totals HL", Task.TASK_GENERATE_TOTALS_HL);
	automateDateForm.ShowDialog();
}

private 
void compareButton_Click(object sender, System.EventArgs e){
	HotListVersionForm hotListVersionForm = new HotListVersionForm(true);
	hotListVersionForm.ShowDialog();

	if (hotListVersionForm.DialogResult == DialogResult.OK){
		int hlid1 = int.Parse(hotListVersionForm.getSelected()[0][0]);
		int hlid2 = int.Parse(hotListVersionForm.getSelected()[1][0]);
		ArrayList fields = new ArrayList();

		DataSet dataSet = generateHLTotalsDataSet(this.coreFactory, hlid1, hlid2, fields);

		string title = "Hot List Compare, Dates : " + 
			hotListVersionForm.getSelected()[0][1] + " = " + 
			hotListVersionForm.getSelected()[1][1];

		string d1 = hotListVersionForm.getSelected()[0][1].Substring(0, 10);
		string d2 = hotListVersionForm.getSelected()[1][1].Substring(0, 10);

		HotListTotals hotListTotals = new HotListTotals(dataSet, title, fields);
		hotListTotals.Show();
	}
}

private 
void resumeButton_Click(object sender, System.EventArgs e){
	HotListVersionForm hotListVersionForm = new HotListVersionForm(true);
	hotListVersionForm.ShowDialog();

	if (hotListVersionForm.DialogResult == DialogResult.OK){
		int hlid1 = int.Parse(hotListVersionForm.getSelected()[0][0]);
		int hlid2 = int.Parse(hotListVersionForm.getSelected()[1][0]);

		DataSet dataSet = generateHLTotalsResumeDataSet(this.coreFactory, hlid1, hlid2);

		string title = "Hot List Compare - Res, Dates : " + 
			hotListVersionForm.getSelected()[0][1] + " = " + 
			hotListVersionForm.getSelected()[1][1];

		string d1 = hotListVersionForm.getSelected()[0][1].Substring(0, 10);
		string d2 = hotListVersionForm.getSelected()[1][1].Substring(0, 10);

		HotListTotalsResume hotListTotals = new HotListTotalsResume(dataSet, title);
		hotListTotals.Show();
	}
}

private
DataSet generateHLTotalsDataSet(CoreFactory coreFactory, int id1, int id2, ArrayList fields){
	DataTable dataTable = new DataTable();
	dataTable.TableName = "hotListTotals";

	dataTable.Columns.Add(new DataColumn("HOT_Dept", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Mach", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Qoh", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_QohCml", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_PastDue", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day001", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day002", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day003", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day004", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day005", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day006", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day007", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day008", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day009", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day010", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day011", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day012", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day013", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day014", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_DayGreater", typeof(string)));

	string[][] vec = coreFactory.geHotListTotals(id1, id2);

	for(int x = 0; x < vec.Length; x++){
		DataRow dataRow = dataTable.NewRow();
		dataRow[0]  = vec[x][0];
		dataRow[1]  = vec[x][1];
		dataRow[2]  = vec[x][2];
		dataRow[3]  = vec[x][3];
		dataRow[4]  = vec[x][4];
		dataRow[5]  = vec[x][5];
		dataRow[6]  = vec[x][6];
		dataRow[7]  = vec[x][7];
		dataRow[8]  = vec[x][8];
		dataRow[9]  = vec[x][9];
		dataRow[10]  = vec[x][10];
		dataRow[11]  = vec[x][11];
		dataRow[12]  = vec[x][12];
		dataRow[13]  = vec[x][13];
		dataRow[14]  = vec[x][14];
		dataRow[15]  = vec[x][15];
		dataRow[16]  = vec[x][16];
		dataRow[17]  = vec[x][17];
		dataRow[18]  = vec[x][18];

		decimal hotDayGreater = 0;
		for(int z = 19; z < vec[x].Length; z++){
			hotDayGreater += decimal.Parse(vec[x][z]);
		}

		dataRow[19]  = hotDayGreater.ToString(); // greater

		string[] vecField = new string[24];
		vecField[0] = vec[x][0];
		vecField[1] = vec[x][1];
		vecField[2] = vec[x][2];
		vecField[3] = vec[x][3];
		vecField[4] = vec[x][4];
		vecField[5] = vec[x][5];
		vecField[6] = vec[x][6];
		vecField[7] = vec[x][7];
		vecField[8] = vec[x][8];
		vecField[9] = vec[x][9];
		vecField[10] = vec[x][10];
		vecField[11] = vec[x][11];
		vecField[12] = vec[x][12];
		vecField[13] = vec[x][13];
		vecField[14] = vec[x][14];
		vecField[15] = vec[x][15];
		vecField[16] = vec[x][16];
		vecField[17] = vec[x][17];
		vecField[18] = vec[x][18];
		vecField[19] = hotDayGreater.ToString(); // greater

		fields.Add(vecField);

		dataTable.Rows.Add(dataRow);
	}

	DataSet dataSet = new DataSet();
	dataSet.Tables.Add(dataTable);

	return dataSet;
}

private 
DataSet generateHLTotalsResumeDataSet(CoreFactory coreFactory, int id1, int id2){
	DataTable dataTable = new DataTable();
	dataTable.TableName = "hotListTotalsResume";

	dataTable.Columns.Add(new DataColumn("HOT_Key", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Dept", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Mach", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Qoh", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_QohCml", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_PastDue", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day001", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day002", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day003", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day004", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day005", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day006", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day007", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day008", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day009", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day010", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day011", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day012", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day013", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day014", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day1-14", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_Day15-90", typeof(string)));
	dataTable.Columns.Add(new DataColumn("HOT_DayTotal", typeof(string)));

	string[][] vec = coreFactory.geHotListTotals(id1, id2);

	int x = 0;
	while(x < vec.Length){
		DataRow dataRow = dataTable.NewRow();

		string dept = vec[x][0];
		string mach = vec[x][1];

		string key = dept + "_" + mach;
		
		decimal qoh_1 = decimal.Parse(vec[x][2]);
		decimal qoh_2 = decimal.Parse(vec[x + 1][2]);
		decimal qoh_prog = qoh_2 - qoh_1;

		decimal qohCml_1 = decimal.Parse(vec[x][3]);
		decimal qohCml_2 = decimal.Parse(vec[x + 1][3]);
		decimal qohCml_prog = qohCml_1 - qohCml_2;
		
		decimal pastDue_1 = decimal.Parse(vec[x][4]);
		decimal pastDue_2 = decimal.Parse(vec[x + 1][4]);
		decimal pastDue_prog = pastDue_1 - pastDue_2;
		
		decimal day001_1 = decimal.Parse(vec[x][5]);
		decimal day001_2 = decimal.Parse(vec[x + 1][5]);
		decimal day001_prog = day001_1 - day001_2;
		
		decimal day002_1 = decimal.Parse(vec[x][6]);
		decimal day002_2 = decimal.Parse(vec[x + 1][6]);
		decimal day002_prog = day002_1 - day002_2;
		
		decimal day003_1 = decimal.Parse(vec[x][7]);
		decimal day003_2 = decimal.Parse(vec[x + 1][7]);
		decimal day003_prog = day003_1 - day003_2;
		
		decimal day004_1 = decimal.Parse(vec[x][8]);
		decimal day004_2 = decimal.Parse(vec[x + 1][8]);
		decimal day004_prog = day004_1 - day004_2;
		
		decimal day005_1 = decimal.Parse(vec[x][9]);
		decimal day005_2 = decimal.Parse(vec[x + 1][9]);
		decimal day005_prog = day005_1 - day005_2;
		
		decimal day006_1 = decimal.Parse(vec[x][10]);
		decimal day006_2 = decimal.Parse(vec[x + 1][10]);
		decimal day006_prog = day006_1 - day006_2;
		
		decimal day007_1 = decimal.Parse(vec[x][11]);
		decimal day007_2 = decimal.Parse(vec[x + 1][11]);
		decimal day007_prog = day007_1 - day007_2;
		
		decimal day008_1 = decimal.Parse(vec[x][12]);
		decimal day008_2 = decimal.Parse(vec[x + 1][12]);
		decimal day008_prog = day008_1 - day008_2;
		
		decimal day009_1 = decimal.Parse(vec[x][13]);
		decimal day009_2 = decimal.Parse(vec[x + 1][13]);
		decimal day009_prog = day009_1 - day009_2;
		
		decimal day010_1 = decimal.Parse(vec[x][14]);
		decimal day010_2 = decimal.Parse(vec[x + 1][14]);
		decimal day010_prog = day010_1 - day010_2;
		
		decimal day011_1 = decimal.Parse(vec[x][15]);
		decimal day011_2 = decimal.Parse(vec[x + 1][15]);
		decimal day011_prog = day011_1 - day011_2;
		
		decimal day012_1 = decimal.Parse(vec[x][16]);
		decimal day012_2 = decimal.Parse(vec[x + 1][16]);
		decimal day012_prog = day012_1 - day012_2;
		
		decimal day013_1 = decimal.Parse(vec[x][17]);
		decimal day013_2 = decimal.Parse(vec[x + 1][17]);
		decimal day013_prog = day013_1 - day013_2;
		
		decimal day014_1 = decimal.Parse(vec[x][18]);
		decimal day014_2 = decimal.Parse(vec[x + 1][18]);
		decimal day014_prog = day014_1 - day014_2;
		
		decimal day1_1_14 = pastDue_1 + day001_1 + day002_1 + day003_1 + day004_1 +
			day005_1 + day006_1 + day007_1 + day008_1 + day009_1 + day010_1 + day011_1 +
			day012_1 + day013_1 + day014_1;

		decimal day2_1_14 = pastDue_2 + day001_2 + day002_2 + day003_2 + day004_2 +
			day005_2 + day006_2 + day007_2 + day008_2 + day009_2 + day010_2 + day011_2 +
			day012_2 + day013_2 + day014_2;

		decimal day_1_14_prog = day1_1_14 - day2_1_14;

		decimal day1_15_90 = decimal.Parse(vec[x][19]) + decimal.Parse(vec[x][20]) + 
			decimal.Parse(vec[x][21]) + decimal.Parse(vec[x][22]) + decimal.Parse(vec[x][23]) + 
			decimal.Parse(vec[x][24]) + decimal.Parse(vec[x][25]) + decimal.Parse(vec[x][26]) + 
			decimal.Parse(vec[x][27]) + decimal.Parse(vec[x][28]) + decimal.Parse(vec[x][29]) + 
			decimal.Parse(vec[x][30]) + decimal.Parse(vec[x][31]) + decimal.Parse(vec[x][32]) + 
			decimal.Parse(vec[x][33]) + decimal.Parse(vec[x][34]) + decimal.Parse(vec[x][35]) + 
			decimal.Parse(vec[x][36]) + decimal.Parse(vec[x][37]) + decimal.Parse(vec[x][38]) + 
			decimal.Parse(vec[x][39]) + decimal.Parse(vec[x][40]) + decimal.Parse(vec[x][41]) + 
			decimal.Parse(vec[x][42]) + decimal.Parse(vec[x][43]) + decimal.Parse(vec[x][44]) + 
			decimal.Parse(vec[x][45]) + decimal.Parse(vec[x][46]) + decimal.Parse(vec[x][47]) + 
			decimal.Parse(vec[x][48]) + decimal.Parse(vec[x][49]) + decimal.Parse(vec[x][50]) + 
			decimal.Parse(vec[x][51]) + decimal.Parse(vec[x][52]) + decimal.Parse(vec[x][53]) + 
			decimal.Parse(vec[x][54]) + decimal.Parse(vec[x][55]) + decimal.Parse(vec[x][56]) + 
			decimal.Parse(vec[x][57]) + decimal.Parse(vec[x][58]) + decimal.Parse(vec[x][59]) + 
			decimal.Parse(vec[x][60]) + decimal.Parse(vec[x][61]) + decimal.Parse(vec[x][62]) + 
			decimal.Parse(vec[x][63]) + decimal.Parse(vec[x][64]) + decimal.Parse(vec[x][65]) + 
			decimal.Parse(vec[x][66]) + decimal.Parse(vec[x][67]) + decimal.Parse(vec[x][68]) + 
			decimal.Parse(vec[x][69]) + decimal.Parse(vec[x][70]) + decimal.Parse(vec[x][71]) + 
			decimal.Parse(vec[x][72]) + decimal.Parse(vec[x][73]) + decimal.Parse(vec[x][74]) + 
			decimal.Parse(vec[x][75]) + decimal.Parse(vec[x][76]) + decimal.Parse(vec[x][77]) + 
			decimal.Parse(vec[x][78]) + decimal.Parse(vec[x][79]) + decimal.Parse(vec[x][80]) + 
			decimal.Parse(vec[x][81]) + decimal.Parse(vec[x][82]) + decimal.Parse(vec[x][83]) + 
			decimal.Parse(vec[x][84]) + decimal.Parse(vec[x][85]) + decimal.Parse(vec[x][86]) + 
			decimal.Parse(vec[x][87]) + decimal.Parse(vec[x][88]) + decimal.Parse(vec[x][89]) + 
			decimal.Parse(vec[x][90]) + decimal.Parse(vec[x][91]) + decimal.Parse(vec[x][92]) + 
			decimal.Parse(vec[x][93]) + decimal.Parse(vec[x][94]);

		decimal day2_15_90 = decimal.Parse(vec[x + 1][19]) + decimal.Parse(vec[x + 1][20]) + 
			decimal.Parse(vec[x + 1][21]) + decimal.Parse(vec[x + 1][22]) + decimal.Parse(vec[x + 1][23]) + 
			decimal.Parse(vec[x + 1][24]) + decimal.Parse(vec[x + 1][25]) + decimal.Parse(vec[x + 1][26]) + 
			decimal.Parse(vec[x + 1][27]) + decimal.Parse(vec[x + 1][28]) + decimal.Parse(vec[x + 1][29]) + 
			decimal.Parse(vec[x + 1][30]) + decimal.Parse(vec[x + 1][31]) + decimal.Parse(vec[x + 1][32]) + 
			decimal.Parse(vec[x + 1][33]) + decimal.Parse(vec[x + 1][34]) + decimal.Parse(vec[x + 1][35]) + 
			decimal.Parse(vec[x + 1][36]) + decimal.Parse(vec[x + 1][37]) + decimal.Parse(vec[x + 1][38]) + 
			decimal.Parse(vec[x + 1][39]) + decimal.Parse(vec[x + 1][40]) + decimal.Parse(vec[x + 1][41]) + 
			decimal.Parse(vec[x + 1][42]) + decimal.Parse(vec[x + 1][43]) + decimal.Parse(vec[x + 1][44]) + 
			decimal.Parse(vec[x + 1][45]) + decimal.Parse(vec[x + 1][46]) + decimal.Parse(vec[x + 1][47]) + 
			decimal.Parse(vec[x + 1][48]) + decimal.Parse(vec[x + 1][49]) + decimal.Parse(vec[x + 1][50]) + 
			decimal.Parse(vec[x + 1][51]) + decimal.Parse(vec[x + 1][52]) + decimal.Parse(vec[x + 1][53]) + 
			decimal.Parse(vec[x + 1][54]) + decimal.Parse(vec[x + 1][55]) + decimal.Parse(vec[x + 1][56]) + 
			decimal.Parse(vec[x + 1][57]) + decimal.Parse(vec[x + 1][58]) + decimal.Parse(vec[x + 1][59]) + 
			decimal.Parse(vec[x + 1][60]) + decimal.Parse(vec[x + 1][61]) + decimal.Parse(vec[x + 1][62]) + 
			decimal.Parse(vec[x + 1][63]) + decimal.Parse(vec[x + 1][64]) + decimal.Parse(vec[x + 1][65]) + 
			decimal.Parse(vec[x + 1][66]) + decimal.Parse(vec[x + 1][67]) + decimal.Parse(vec[x + 1][68]) + 
			decimal.Parse(vec[x + 1][69]) + decimal.Parse(vec[x + 1][70]) + decimal.Parse(vec[x + 1][71]) + 
			decimal.Parse(vec[x + 1][72]) + decimal.Parse(vec[x + 1][73]) + decimal.Parse(vec[x + 1][74]) + 
			decimal.Parse(vec[x + 1][75]) + decimal.Parse(vec[x + 1][76]) + decimal.Parse(vec[x + 1][77]) + 
			decimal.Parse(vec[x + 1][78]) + decimal.Parse(vec[x + 1][79]) + decimal.Parse(vec[x + 1][80]) + 
			decimal.Parse(vec[x + 1][81]) + decimal.Parse(vec[x + 1][82]) + decimal.Parse(vec[x + 1][83]) + 
			decimal.Parse(vec[x + 1][84]) + decimal.Parse(vec[x + 1][85]) + decimal.Parse(vec[x + 1][86]) + 
			decimal.Parse(vec[x + 1][87]) + decimal.Parse(vec[x + 1][88]) + decimal.Parse(vec[x + 1][89]) + 
			decimal.Parse(vec[x + 1][90]) + decimal.Parse(vec[x + 1][91]) + decimal.Parse(vec[x + 1][92]) + 
			decimal.Parse(vec[x + 1][93]) + decimal.Parse(vec[x + 1][94]);

		decimal day_15_90_prog = day1_15_90 - day2_15_90;

		decimal day_0_90_prog = day_1_14_prog + day_15_90_prog;

		dataRow[0]  = key;
		dataRow[1]  = dept;
		dataRow[2]  = mach;
		dataRow[3]  = qoh_prog.ToString();
		dataRow[4]  = qohCml_prog.ToString();
		dataRow[5]  = pastDue_prog.ToString();
		dataRow[6]  = day001_prog.ToString();
		dataRow[7]  = day002_prog.ToString();
		dataRow[8]  = day003_prog.ToString();
		dataRow[9]  = day004_prog.ToString();
		dataRow[10]  = day005_prog.ToString();
		dataRow[11]  = day006_prog.ToString();
		dataRow[12]  = day007_prog.ToString();
		dataRow[13]  = day008_prog.ToString();
		dataRow[14]  = day009_prog.ToString();
		dataRow[15]  = day010_prog.ToString();
		dataRow[16]  = day011_prog.ToString();
		dataRow[17]  = day012_prog.ToString();
		dataRow[18]  = day013_prog.ToString();
		dataRow[19]  = day014_prog.ToString();
		dataRow[20]  = day_1_14_prog.ToString();
		dataRow[21]  = day_15_90_prog.ToString();
		dataRow[22]  = day_0_90_prog.ToString();

		dataTable.Rows.Add(dataRow);

		x += 2;
	}

	DataSet dataSet = new DataSet();
	dataSet.Tables.Add(dataTable);

	return dataSet;
}

private 
void hotListBomButton_Click(object sender, System.EventArgs e){
	callHotListReport(true, this.daysCheckBox.Checked);
}

private 
void generateHotListButton_Click(object sender, System.EventArgs e){
	AutomateDateForm automateDateForm = new AutomateDateForm("HL Report", Task.TASK_GENERATE_HOTLIST_REPORT);
	automateDateForm.ShowDialog();
}

private 
void matLocButton_Click(object sender, System.EventArgs e){
	FilterForm filterForm = new FilterForm(matbFilter);
	filterForm.ShowDialog();

	if (filterForm.DialogResult == DialogResult.OK)
		matbFilter = filterForm.getItems();
}


}//end class

} // namespace
