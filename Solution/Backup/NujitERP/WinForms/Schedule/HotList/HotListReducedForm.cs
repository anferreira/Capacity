using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Engine;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using System.Data;
using System.Data.SqlClient;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.WinForms.Reports.HotList_Report;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.WinForms.Reports.DemandReport;
using Nujit.NujitERP.WinForms.Schedule.HotList;
using Nujit.NujitERP.WinForms.Schedule.LoadUpLoad.GeneratedRecords;


namespace Nujit.NujitERP.WinForms.Schedule.HotList{


public 
class HotListReducedForm : System.Windows.Forms.Form{

private System.Windows.Forms.TabControl tabHotList;
private System.Windows.Forms.DataGrid gridHotList;
private System.Windows.Forms.TabPage tabPage1;
private System.Windows.Forms.TabPage tabPage2;
private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private System.Windows.Forms.StatusBar statusBarMessage;
private FormMain formMainParent;
private string[][] deptFilter;
private string[][] partFilter;
private string[][] mgFilter;
private string[][] stkbFilter;
private string[][] wipbFilter;

private DataSet dsHotList = new DataSet();
private DataTable hotListDataTable = new DataTable();

private int w = 934;
private int h = 598;
	private System.Windows.Forms.GroupBox groupBox1;
	private System.Windows.Forms.GroupBox groupBox2;
	private System.Windows.Forms.Button button1;
	private System.Windows.Forms.Button button3;
	private System.Windows.Forms.Button filterdeptButton;
	private System.Windows.Forms.Button filterPartButton;
	private System.Windows.Forms.Button demandButton;
	private System.Windows.Forms.Button reportButton;
	private System.Windows.Forms.CheckBox LicheckBox;
	private System.Windows.Forms.CheckBox onlyDemand;
	private System.Windows.Forms.Button allButton;
	private System.Windows.Forms.CheckedListBox listBox;
	private System.Windows.Forms.Button btnTab2Refresh;
	private System.Windows.Forms.CheckBox orderByMGCheckBox;
	private System.Windows.Forms.Button filterMGButton;
	private System.Windows.Forms.CheckBox mainMatCheckBox;
    private System.Windows.Forms.CheckBox cboxSunSatToFriday;
	private System.Windows.Forms.CheckBox onlyReportingPointCheckBox;
	private System.Windows.Forms.CheckBox hoursCheckBox;
	private System.Windows.Forms.GroupBox groupBox3;
	private System.Windows.Forms.CheckBox orderByResCheckBox;
	private System.Windows.Forms.CheckBox labourCheckBox;
	private System.Windows.Forms.CheckBox majorMinorGroupCheckBox;
	private System.Windows.Forms.CheckBox noZeroesCheckBox;
	private System.Windows.Forms.CheckBox lastVersionCheckBox;
	private System.Windows.Forms.Button compareButton;
	private System.Windows.Forms.Button resumeButton;
	private System.Windows.Forms.Button hlBomButton;
	private System.Windows.Forms.CheckBox partCheckBox;
	private System.Windows.Forms.CheckBox includeInactivePartsCheckBox;
/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;

public 
HotListReducedForm(FormMain formParent){
	InitializeComponent();
	
	this.MdiParent = formParent;
	this.formMainParent = formParent;

	loadFilterDept();
	loadFilterPart();
	loadFilterMG();
	
	this.Width = w;
	this.Height = h;

	loadGridHotList();
	setStyles();
	this.Refresh();
}

public 
HotListReducedForm(){
	InitializeComponent();
	loadFilterDept();
	loadFilterPart();
	loadFilterMG();

	this.Width = w;
	this.Height = h;
	
	loadGridHotList();
	setStyles();
	this.Refresh();
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
	this.hlBomButton = new System.Windows.Forms.Button();
	this.resumeButton = new System.Windows.Forms.Button();
	this.compareButton = new System.Windows.Forms.Button();
	this.lastVersionCheckBox = new System.Windows.Forms.CheckBox();
	this.noZeroesCheckBox = new System.Windows.Forms.CheckBox();
	this.labourCheckBox = new System.Windows.Forms.CheckBox();
	this.hoursCheckBox = new System.Windows.Forms.CheckBox();
	this.onlyReportingPointCheckBox = new System.Windows.Forms.CheckBox();
	this.mainMatCheckBox = new System.Windows.Forms.CheckBox();
	this.btnTab2Refresh = new System.Windows.Forms.Button();
	this.listBox = new System.Windows.Forms.CheckedListBox();
	this.allButton = new System.Windows.Forms.Button();
	this.button3 = new System.Windows.Forms.Button();
	this.button1 = new System.Windows.Forms.Button();
	this.cboxSunSatToFriday = new System.Windows.Forms.CheckBox();
	this.groupBox3 = new System.Windows.Forms.GroupBox();
	this.partCheckBox = new System.Windows.Forms.CheckBox();
	this.majorMinorGroupCheckBox = new System.Windows.Forms.CheckBox();
	this.orderByResCheckBox = new System.Windows.Forms.CheckBox();
	this.orderByMGCheckBox = new System.Windows.Forms.CheckBox();
	this.tabPage2 = new System.Windows.Forms.TabPage();
	this.groupBox2 = new System.Windows.Forms.GroupBox();
	this.filterMGButton = new System.Windows.Forms.Button();
	this.LicheckBox = new System.Windows.Forms.CheckBox();
	this.filterdeptButton = new System.Windows.Forms.Button();
	this.filterPartButton = new System.Windows.Forms.Button();
	this.groupBox1 = new System.Windows.Forms.GroupBox();
	this.demandButton = new System.Windows.Forms.Button();
	this.onlyDemand = new System.Windows.Forms.CheckBox();
	this.reportButton = new System.Windows.Forms.Button();
	this.gridHotList = new System.Windows.Forms.DataGrid();
	this.statusBarMessage = new System.Windows.Forms.StatusBar();
	this.includeInactivePartsCheckBox = new System.Windows.Forms.CheckBox();
	this.tabHotList.SuspendLayout();
	this.tabPage1.SuspendLayout();
	this.groupBox3.SuspendLayout();
	this.tabPage2.SuspendLayout();
	this.groupBox2.SuspendLayout();
	this.groupBox1.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.gridHotList)).BeginInit();
	this.SuspendLayout();
	// 
	// tabHotList
	// 
	this.tabHotList.Controls.Add(this.tabPage1);
	this.tabHotList.Controls.Add(this.tabPage2);
	this.tabHotList.Location = new System.Drawing.Point(16, 8);
	this.tabHotList.Name = "tabHotList";
	this.tabHotList.SelectedIndex = 0;
	this.tabHotList.Size = new System.Drawing.Size(904, 184);
	this.tabHotList.TabIndex = 0;
	// 
	// tabPage1
	// 
	this.tabPage1.Controls.Add(this.hlBomButton);
	this.tabPage1.Controls.Add(this.resumeButton);
	this.tabPage1.Controls.Add(this.compareButton);
	this.tabPage1.Controls.Add(this.lastVersionCheckBox);
	this.tabPage1.Controls.Add(this.noZeroesCheckBox);
	this.tabPage1.Controls.Add(this.labourCheckBox);
	this.tabPage1.Controls.Add(this.hoursCheckBox);
	this.tabPage1.Controls.Add(this.onlyReportingPointCheckBox);
	this.tabPage1.Controls.Add(this.mainMatCheckBox);
	this.tabPage1.Controls.Add(this.btnTab2Refresh);
	this.tabPage1.Controls.Add(this.listBox);
	this.tabPage1.Controls.Add(this.allButton);
	this.tabPage1.Controls.Add(this.button3);
	this.tabPage1.Controls.Add(this.button1);
	this.tabPage1.Controls.Add(this.cboxSunSatToFriday);
	this.tabPage1.Controls.Add(this.groupBox3);
	this.tabPage1.Location = new System.Drawing.Point(4, 22);
	this.tabPage1.Name = "tabPage1";
	this.tabPage1.Size = new System.Drawing.Size(896, 158);
	this.tabPage1.TabIndex = 0;
	this.tabPage1.Text = "Hot List Reports Functions";
	// 
	// hlBomButton
	// 
	this.hlBomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.hlBomButton.Location = new System.Drawing.Point(504, 16);
	this.hlBomButton.Name = "hlBomButton";
	this.hlBomButton.Size = new System.Drawing.Size(88, 24);
	this.hlBomButton.TabIndex = 18;
	this.hlBomButton.Text = "HL Bom";
	this.hlBomButton.Click += new System.EventHandler(this.hlBomButton_Click);
	// 
	// resumeButton
	// 
	this.resumeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.resumeButton.Location = new System.Drawing.Point(400, 16);
	this.resumeButton.Name = "resumeButton";
	this.resumeButton.Size = new System.Drawing.Size(104, 24);
	this.resumeButton.TabIndex = 17;
	this.resumeButton.Text = "Comp HL Res";
	this.resumeButton.Click += new System.EventHandler(this.resumeButton_Click);
	// 
	// compareButton
	// 
	this.compareButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.compareButton.Location = new System.Drawing.Point(312, 16);
	this.compareButton.Name = "compareButton";
	this.compareButton.Size = new System.Drawing.Size(88, 24);
	this.compareButton.TabIndex = 16;
	this.compareButton.Text = "Comp HL";
	this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
	// 
	// lastVersionCheckBox
	// 
	this.lastVersionCheckBox.Checked = true;
	this.lastVersionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
	this.lastVersionCheckBox.Location = new System.Drawing.Point(392, 120);
	this.lastVersionCheckBox.Name = "lastVersionCheckBox";
	this.lastVersionCheckBox.TabIndex = 15;
	this.lastVersionCheckBox.Text = "Last Version";
	// 
	// noZeroesCheckBox
	// 
	this.noZeroesCheckBox.Checked = true;
	this.noZeroesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
	this.noZeroesCheckBox.Location = new System.Drawing.Point(248, 112);
	this.noZeroesCheckBox.Name = "noZeroesCheckBox";
	this.noZeroesCheckBox.Size = new System.Drawing.Size(96, 16);
	this.noZeroesCheckBox.TabIndex = 14;
	this.noZeroesCheckBox.Text = "Non Zeroes";
	// 
	// labourCheckBox
	// 
	this.labourCheckBox.Location = new System.Drawing.Point(392, 104);
	this.labourCheckBox.Name = "labourCheckBox";
	this.labourCheckBox.Size = new System.Drawing.Size(128, 24);
	this.labourCheckBox.TabIndex = 11;
	this.labourCheckBox.Text = "Hot List Labour";
	this.labourCheckBox.CheckedChanged += new System.EventHandler(this.labourCheckBox_CheckedChanged);
	// 
	// hoursCheckBox
	// 
	this.hoursCheckBox.Location = new System.Drawing.Point(392, 88);
	this.hoursCheckBox.Name = "hoursCheckBox";
	this.hoursCheckBox.Size = new System.Drawing.Size(128, 24);
	this.hoursCheckBox.TabIndex = 10;
	this.hoursCheckBox.Text = "Hot List Hours";
	this.hoursCheckBox.CheckedChanged += new System.EventHandler(this.hoursCheckBox_CheckedChanged);
	// 
	// onlyReportingPointCheckBox
	// 
	this.onlyReportingPointCheckBox.Location = new System.Drawing.Point(248, 88);
	this.onlyReportingPointCheckBox.Name = "onlyReportingPointCheckBox";
	this.onlyReportingPointCheckBox.Size = new System.Drawing.Size(128, 24);
	this.onlyReportingPointCheckBox.TabIndex = 9;
	this.onlyReportingPointCheckBox.Text = "Only Reporting Point";
	// 
	// mainMatCheckBox
	// 
	this.mainMatCheckBox.Location = new System.Drawing.Point(248, 72);
	this.mainMatCheckBox.Name = "mainMatCheckBox";
	this.mainMatCheckBox.Size = new System.Drawing.Size(96, 16);
	this.mainMatCheckBox.TabIndex = 7;
	this.mainMatCheckBox.Text = "Main Material";
	// 
	// btnTab2Refresh
	// 
	this.btnTab2Refresh.Location = new System.Drawing.Point(8, 128);
	this.btnTab2Refresh.Name = "btnTab2Refresh";
	this.btnTab2Refresh.Size = new System.Drawing.Size(120, 24);
	this.btnTab2Refresh.TabIndex = 5;
	this.btnTab2Refresh.Text = "Refresh Grid";
	this.btnTab2Refresh.Click += new System.EventHandler(this.btnTab2Refresh_Click_1);
	// 
	// listBox
	// 
	this.listBox.CheckOnClick = true;
	this.listBox.Location = new System.Drawing.Point(616, 8);
	this.listBox.Name = "listBox";
	this.listBox.Size = new System.Drawing.Size(248, 139);
	this.listBox.TabIndex = 3;
	// 
	// allButton
	// 
	this.allButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.allButton.Location = new System.Drawing.Point(208, 16);
	this.allButton.Name = "allButton";
	this.allButton.Size = new System.Drawing.Size(104, 24);
	this.allButton.TabIndex = 2;
	this.allButton.Text = "All Products";
	this.allButton.Click += new System.EventHandler(this.allButton_Click);
	// 
	// button3
	// 
	this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.button3.Location = new System.Drawing.Point(112, 16);
	this.button3.Name = "button3";
	this.button3.Size = new System.Drawing.Size(96, 24);
	this.button3.TabIndex = 1;
	this.button3.Text = "FG  Report";
	this.button3.Click += new System.EventHandler(this.button3_Click_1);
	// 
	// button1
	// 
	this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.button1.Location = new System.Drawing.Point(8, 16);
	this.button1.Name = "button1";
	this.button1.Size = new System.Drawing.Size(104, 24);
	this.button1.TabIndex = 0;
	this.button1.Text = "WIP Report";
	this.button1.Click += new System.EventHandler(this.button1_Click_1);
	// 
	// cboxSunSatToFriday
	// 
	this.cboxSunSatToFriday.Location = new System.Drawing.Point(392, 72);
	this.cboxSunSatToFriday.Name = "cboxSunSatToFriday";
	this.cboxSunSatToFriday.Size = new System.Drawing.Size(216, 24);
	this.cboxSunSatToFriday.TabIndex = 8;
	this.cboxSunSatToFriday.Text = "Move Sunday to Saturday and Friday";
	// 
	// groupBox3
	// 
	this.groupBox3.Controls.Add(this.partCheckBox);
	this.groupBox3.Controls.Add(this.majorMinorGroupCheckBox);
	this.groupBox3.Controls.Add(this.orderByResCheckBox);
	this.groupBox3.Controls.Add(this.orderByMGCheckBox);
	this.groupBox3.Location = new System.Drawing.Point(8, 56);
	this.groupBox3.Name = "groupBox3";
	this.groupBox3.Size = new System.Drawing.Size(224, 72);
	this.groupBox3.TabIndex = 3;
	this.groupBox3.TabStop = false;
	this.groupBox3.Text = "Order By";
	// 
	// partCheckBox
	// 
	this.partCheckBox.Location = new System.Drawing.Point(120, 16);
	this.partCheckBox.Name = "partCheckBox";
	this.partCheckBox.Size = new System.Drawing.Size(56, 16);
	this.partCheckBox.TabIndex = 10;
	this.partCheckBox.Text = "Part";
	// 
	// majorMinorGroupCheckBox
	// 
	this.majorMinorGroupCheckBox.Location = new System.Drawing.Point(16, 48);
	this.majorMinorGroupCheckBox.Name = "majorMinorGroupCheckBox";
	this.majorMinorGroupCheckBox.Size = new System.Drawing.Size(120, 16);
	this.majorMinorGroupCheckBox.TabIndex = 9;
	this.majorMinorGroupCheckBox.Text = "Major/Minor Group";
	this.majorMinorGroupCheckBox.CheckedChanged += new System.EventHandler(this.majorMinorGroupCheckBox_CheckedChanged);
	// 
	// orderByResCheckBox
	// 
	this.orderByResCheckBox.Location = new System.Drawing.Point(16, 32);
	this.orderByResCheckBox.Name = "orderByResCheckBox";
	this.orderByResCheckBox.Size = new System.Drawing.Size(96, 16);
	this.orderByResCheckBox.TabIndex = 8;
	this.orderByResCheckBox.Text = "Resource";
	this.orderByResCheckBox.CheckedChanged += new System.EventHandler(this.orderByResCheckBox_CheckedChanged);
	// 
	// orderByMGCheckBox
	// 
	this.orderByMGCheckBox.Location = new System.Drawing.Point(16, 16);
	this.orderByMGCheckBox.Name = "orderByMGCheckBox";
	this.orderByMGCheckBox.Size = new System.Drawing.Size(96, 16);
	this.orderByMGCheckBox.TabIndex = 6;
	this.orderByMGCheckBox.Text = "Minor Group";
	this.orderByMGCheckBox.CheckedChanged += new System.EventHandler(this.orderByMGCheckBox_CheckedChanged);
	// 
	// tabPage2
	// 
	this.tabPage2.Controls.Add(this.groupBox2);
	this.tabPage2.Controls.Add(this.groupBox1);
	this.tabPage2.Location = new System.Drawing.Point(4, 22);
	this.tabPage2.Name = "tabPage2";
	this.tabPage2.Size = new System.Drawing.Size(896, 158);
	this.tabPage2.TabIndex = 1;
	this.tabPage2.Text = "Hot List Options";
	// 
	// groupBox2
	// 
	this.groupBox2.Controls.Add(this.includeInactivePartsCheckBox);
	this.groupBox2.Controls.Add(this.filterMGButton);
	this.groupBox2.Controls.Add(this.LicheckBox);
	this.groupBox2.Controls.Add(this.filterdeptButton);
	this.groupBox2.Controls.Add(this.filterPartButton);
	this.groupBox2.Location = new System.Drawing.Point(304, 9);
	this.groupBox2.Name = "groupBox2";
	this.groupBox2.Size = new System.Drawing.Size(344, 141);
	this.groupBox2.TabIndex = 6;
	this.groupBox2.TabStop = false;
	this.groupBox2.Text = "Filters";
	// 
	// filterMGButton
	// 
	this.filterMGButton.Location = new System.Drawing.Point(16, 88);
	this.filterMGButton.Name = "filterMGButton";
	this.filterMGButton.Size = new System.Drawing.Size(120, 23);
	this.filterMGButton.TabIndex = 6;
	this.filterMGButton.Text = "by Minor Group";
	this.filterMGButton.Click += new System.EventHandler(this.filterMGButton_Click);
	// 
	// LicheckBox
	// 
	this.LicheckBox.Location = new System.Drawing.Point(152, 24);
	this.LicheckBox.Name = "LicheckBox";
	this.LicheckBox.Size = new System.Drawing.Size(128, 24);
	this.LicheckBox.TabIndex = 5;
	this.LicheckBox.Text = "Include LI* Parts";
	// 
	// filterdeptButton
	// 
	this.filterdeptButton.Location = new System.Drawing.Point(16, 24);
	this.filterdeptButton.Name = "filterdeptButton";
	this.filterdeptButton.Size = new System.Drawing.Size(120, 24);
	this.filterdeptButton.TabIndex = 2;
	this.filterdeptButton.Text = " by Dept";
	this.filterdeptButton.Visible = false;
	this.filterdeptButton.Click += new System.EventHandler(this.filterdeptButton_Click);
	// 
	// filterPartButton
	// 
	this.filterPartButton.Location = new System.Drawing.Point(16, 56);
	this.filterPartButton.Name = "filterPartButton";
	this.filterPartButton.Size = new System.Drawing.Size(120, 23);
	this.filterPartButton.TabIndex = 3;
	this.filterPartButton.Text = " by Part";
	this.filterPartButton.Click += new System.EventHandler(this.filterPartButton_Click);
	// 
	// groupBox1
	// 
	this.groupBox1.Controls.Add(this.demandButton);
	this.groupBox1.Controls.Add(this.onlyDemand);
	this.groupBox1.Controls.Add(this.reportButton);
	this.groupBox1.Location = new System.Drawing.Point(8, 8);
	this.groupBox1.Name = "groupBox1";
	this.groupBox1.Size = new System.Drawing.Size(248, 141);
	this.groupBox1.TabIndex = 5;
	this.groupBox1.TabStop = false;
	this.groupBox1.Text = "Report Formats";
	// 
	// demandButton
	// 
	this.demandButton.Location = new System.Drawing.Point(72, 80);
	this.demandButton.Name = "demandButton";
	this.demandButton.Size = new System.Drawing.Size(120, 24);
	this.demandButton.TabIndex = 5;
	this.demandButton.Text = "Demand";
	this.demandButton.Click += new System.EventHandler(this.demandButton_Click_1);
	// 
	// onlyDemand
	// 
	this.onlyDemand.Checked = true;
	this.onlyDemand.CheckState = System.Windows.Forms.CheckState.Checked;
	this.onlyDemand.Location = new System.Drawing.Point(16, 24);
	this.onlyDemand.Name = "onlyDemand";
	this.onlyDemand.Size = new System.Drawing.Size(152, 16);
	this.onlyDemand.TabIndex = 3;
	this.onlyDemand.Text = "Show only Demand Parts";
	// 
	// reportButton
	// 
	this.reportButton.Location = new System.Drawing.Point(72, 48);
	this.reportButton.Name = "reportButton";
	this.reportButton.Size = new System.Drawing.Size(120, 24);
	this.reportButton.TabIndex = 1;
	this.reportButton.Text = "Report";
	this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
	// 
	// gridHotList
	// 
	this.gridHotList.DataMember = "";
	this.gridHotList.HeaderForeColor = System.Drawing.SystemColors.ControlText;
	this.gridHotList.Location = new System.Drawing.Point(16, 208);
	this.gridHotList.Name = "gridHotList";
	this.gridHotList.ReadOnly = true;
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
	// includeInactivePartsCheckBox
	// 
	this.includeInactivePartsCheckBox.Checked = true;
	this.includeInactivePartsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
	this.includeInactivePartsCheckBox.Location = new System.Drawing.Point(152, 48);
	this.includeInactivePartsCheckBox.Name = "includeInactivePartsCheckBox";
	this.includeInactivePartsCheckBox.Size = new System.Drawing.Size(152, 24);
	this.includeInactivePartsCheckBox.TabIndex = 11;
	this.includeInactivePartsCheckBox.Text = "Include Inactive Parts";
	// 
	// HotListReducedForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(926, 504);
	this.Controls.Add(this.statusBarMessage);
	this.Controls.Add(this.gridHotList);
	this.Controls.Add(this.tabHotList);
	this.Name = "HotListReducedForm";
	this.Text = "Hot List";
	this.Closing += new System.ComponentModel.CancelEventHandler(this.HotListReducedForm_Closing);
	this.SizeChanged += new System.EventHandler(this.HotListForm_SizeChanged);
	this.Closed += new System.EventHandler(this.OnClose);
	this.tabHotList.ResumeLayout(false);
	this.tabPage1.ResumeLayout(false);
	this.groupBox3.ResumeLayout(false);
	this.tabPage2.ResumeLayout(false);
	this.groupBox2.ResumeLayout(false);
	this.groupBox1.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.gridHotList)).EndInit();
	this.ResumeLayout(false);

}
#endregion


private 
void gridHotList_Click(object sender, System.EventArgs e){
	setStyles();
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
	int cont = 0;
	for(int i = 0; i < listBox.Items.Count; i++){
		if (listBox.GetItemChecked(i))
			cont++;
	}

	string[] deptFilterAux = new String[cont];
	int x = 0;

	for(int i = 0; i < listBox.Items.Count; i++){
		if (listBox.GetItemChecked(i)){
			deptFilterAux[x] = this.deptFilter[i][0];
			x++;
		}
	}

	return deptFilterAux;
}

private 
string[] loadFilterMgSql(){
	int countMg = 0;

	for(int i = 0; i < mgFilter.Length; i++){
		if (mgFilter[i][1].Equals("true")){
			countMg++;
		}
	}

	int indexMg = 0;
	string[] mgFilterAux = new String[countMg];

	for(int i = 0; i < mgFilter.Length; i++){
		if (mgFilter[i][1].Equals("true")){
			mgFilterAux[indexMg] = mgFilter[i][0];
			indexMg++;
		}
	}
	return mgFilterAux;
}

private 
void loadGridHotList(){
	string[] vecFilterPart = loadFilterPartSql();
	string[] vecFilterDept = loadFilterDeptSql();
	string[] vecFilterMg = this.loadFilterMgSql();
	string type = "B";

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

	dsHotList = LoadHotListGrid.generateHotListDataSet(vecFilterDept, vecFilterPart, vecFilterMg, false, type, hlid);
		
	if (dsHotList != null && dsHotList.Tables.Count >0 ){
		this.gridHotList.DataSource = dsHotList.Tables[0];

		int numRows = 0;
		if (dsHotList.Tables.Count>0)
			numRows = dsHotList.Tables[0].Rows.Count;

		if (hlid == 0){
			string[] v = coreFactory.getHotListLogData();
			gridHotList.CaptionText = numRows.ToString() + " records generated, " + 
				"Hotlist Generated on : " + v[0] + ", Material Explosion on : " + v[1];
		}else{
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
}//end loadGridHotList

private 
void btmReport_Click(object sender, System.EventArgs e){
	try{		
		generateHotListReport("B", hoursCheckBox.Checked, labourCheckBox.Checked, false, false);
	}catch(Exception men){
		MessageBox.Show("Error : " + men.Message);
	}
}


private 
void generateHotListReport(string type, bool hotListHours, bool labourReport, bool bomReport, bool lessDays){
	string[] filterPart = loadFilterPartSql();
	string[] filterDept = loadFilterDeptSql();
	string[] filterMg = loadFilterMgSql();
	
	this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
	if (formMainParent != null)
		this.formMainParent.statusBarPanelMessage.Text	= "Generating report, please wait...!";
	
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
		orderByMGCheckBox.Checked, hotListHours, orderByResCheckBox.Checked, labourReport,
		majorMinorGroupCheckBox.Checked, hlid, bomReport);

	this.Cursor = System.Windows.Forms.Cursors.Default;
	
	if (dsReport.Tables["hotListReport"].Rows.Count == 0) {
		this.Cursor = System.Windows.Forms.Cursors.Default;
		if (formMainParent != null)
			this.formMainParent.statusBarPanelMessage.Text	= " ";
		MessageBox.Show("There is no information to display");
	}else{
		try{
			if (formMainParent != null)
				this.formMainParent.statusBarPanelMessage.Text	= "Report Done, Opening Report...";	
			
			string title = "";
			if (type.Equals("B"))
				title = "All Products Hotlist";
			if (type.Equals("Y"))
				title = "Finished Products Hotlist";
			if (type.Equals("N"))
				title = "WIPB Products Hotlist";
             if (cboxSunSatToFriday.Checked)//The option for exclude Sat/Sun is selected
                title += " Exclude Sat/Sun";
                
			if (!orderByMGCheckBox.Checked){
				if (mainMatCheckBox.Checked){
					HotListReportMainMaterial hlmm = new HotListReportMainMaterial(dsReport, title, cboxSunSatToFriday.Checked, 
						hotListHours, noZeroesCheckBox.Checked, generated, exploded, bomReport, lessDays);
					hlmm.Show();
				}else{
					if (!this.orderByResCheckBox.Checked){
						if (!this.majorMinorGroupCheckBox.Checked){
							HotListReport hlr = new HotListReport(dsReport, title, cboxSunSatToFriday.Checked, 
								hotListHours, labourReport, generated, exploded, bomReport, lessDays);
							hlr.Show();
						}else{
							HotListReportByMajorMinorGroup hlrMajorMinor = new HotListReportByMajorMinorGroup(dsReport, title.Trim() + " By Major - Minor Group", 
								cboxSunSatToFriday.Checked, hotListHours, labourReport, generated, exploded, bomReport, lessDays);
							hlrMajorMinor.Show();
						}
					}else{
						HotListReportByResource hotListReportByResource = new HotListReportByResource(dsReport, title, hotListHours, labourReport, 
							noZeroesCheckBox.Checked, cboxSunSatToFriday.Checked, generated, exploded, bomReport, lessDays);
						hotListReportByResource.Show();
					}
				}
			}else{
				if (mainMatCheckBox.Checked){
					HotListReportByMGroupMainMat hlmgmm = new HotListReportByMGroupMainMat(dsReport, title,
						cboxSunSatToFriday.Checked, hotListHours, noZeroesCheckBox.Checked, generated, 
						exploded, bomReport, lessDays);
					hlmgmm.Show();
				}else{
					HotListReportByMGroup hlr2 = new HotListReportByMGroup(dsReport, title, cboxSunSatToFriday.Checked, 
						hotListHours, noZeroesCheckBox.Checked, generated, exploded, bomReport, lessDays);
					hlr2.Show();
				}
			}
			
			if (formMainParent != null)
				this.formMainParent.statusBarPanelMessage.Text	= " ";	
		}catch(Exception men){
			MessageBox.Show("Fatal Error: "+men.Message);
			if (formMainParent != null)
				this.formMainParent.statusBarPanelMessage.Text	= "Report could not be done!";
		}
	}
}

private	
void loadFilterPart(){
	bool inactive = this.includeInactivePartsCheckBox.Checked;
	string[] vecAux = coreFactory.getAllPartFromHotListAsString(0, inactive); //CM 11/10/2005
	partFilter = new string[vecAux.Length][];
	for(int i = 0; i < vecAux.Length; i++){
		string[] v = new string[2];
		v[0] = vecAux[i];
		v[1] = "true";		
		partFilter[i] = v;
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

	for(int i = 0; i < deptFilter.Length; i++)
		listBox.Items.Add(deptFilter[i][0], true);
}//end loadFilterDept

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
	}	
	this.coreFactory = null;
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
		bool byMinorGroup, bool hotListHours, bool orderedByRes, bool labourReport, 
		bool orderedByMajorMinorGroup, int hlid, bool bomReport){

	DataTable hotListReportDataTable = new DataTable();
	DataRow dataRow;
	
	hotListReportDataTable.TableName = "hotListReport";	
	hotListReportDataTable = addColumns(hotListReportDataTable);
		
	bool demand =false;
	if (this.onlyDemand.Checked)
		demand = true;

	string[][] vec = null;
	if (!bomReport){
		vec = coreFactory.getHotListReport(hlid, filterDept, filterPart, filterMg, demand, type, 
			byMinorGroup, cboxSunSatToFriday.Checked, onlyReportingPointCheckBox.Checked, hotListHours, 
			orderedByRes, labourReport, orderedByMajorMinorGroup);
	}else{
		vec = coreFactory.getHotListBomReport(hlid, filterDept, filterPart, filterMg, demand, 
			byMinorGroup, cboxSunSatToFriday.Checked, onlyReportingPointCheckBox.Checked, 
			hotListHours, orderedByRes, labourReport, orderedByMajorMinorGroup, 
			partCheckBox.Checked);
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
DataTable addColumns(DataTable hotListReportDT){
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

	return hotListReportDT;
}

private 
void button1_Click_1(object sender, System.EventArgs e){
	if (hotLisBlocked()){
		DialogResult deleteConfirm = MessageBox.Show("This function is blocked, continue ?", "Hot List", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (deleteConfirm == DialogResult.No)
			return;
	}

	generateHotListReport("N", hoursCheckBox.Checked, labourCheckBox.Checked, false, false);
}

private 
void button3_Click_1(object sender, System.EventArgs e){
	if (hotLisBlocked()){
		DialogResult deleteConfirm = MessageBox.Show("This function is blocked, continue ?", "Hot List", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (deleteConfirm == DialogResult.No)
			return;
	}

	generateHotListReport("Y", hoursCheckBox.Checked, labourCheckBox.Checked, false, false);
}

private 
void reportButton_Click(object sender, System.EventArgs e){
	if (hotLisBlocked()){
		DialogResult deleteConfirm = MessageBox.Show("This function is blocked, continue ?", "Hot List", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (deleteConfirm == DialogResult.No)
			return;
	}

	generateHotListReport("B", hoursCheckBox.Checked, labourCheckBox.Checked, false, false);
}

private 
void demandButton_Click_1(object sender, System.EventArgs e){
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

private 
void filterdeptButton_Click(object sender, System.EventArgs e){
	FilterForm filterForm = new FilterForm(deptFilter);
	filterForm.ShowDialog();

	if (filterForm.DialogResult == DialogResult.OK)
		deptFilter = filterForm.getItems();
}

private 
void filterPartButton_Click(object sender, System.EventArgs e){
	FilterForm filterForm = new FilterForm(partFilter);
	filterForm.ShowDialog();

	if (filterForm.DialogResult == DialogResult.OK)
		partFilter = filterForm.getItems();
		
	filterForm.Dispose();
}

private 
void filterMGButton_Click(object sender, System.EventArgs e){
	FilterForm filterForm = new FilterForm(mgFilter);
	filterForm.ShowDialog();

	if (filterForm.DialogResult == DialogResult.OK)
		mgFilter = filterForm.getItems();
		
	filterForm.Dispose();
}

private 
void allButton_Click(object sender, System.EventArgs e){
	if (hotLisBlocked()){
		DialogResult deleteConfirm = MessageBox.Show("This function is blocked, continue ?", "Hot List", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (deleteConfirm == DialogResult.No)
			return;
	}

	generateHotListReport("B", hoursCheckBox.Checked, labourCheckBox.Checked, false, false);
}

private 
bool hotLisBlocked(){
	return this.coreFactory.isHotListBlocked();

}

private 
void btnTab2Refresh_Click_1(object sender, System.EventArgs e){
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
void HotListReducedForm_Closing(object sender, System.ComponentModel.CancelEventArgs e){
	this.coreFactory = null;
	Close();
}

private 
void orderByMGCheckBox_CheckedChanged(object sender, System.EventArgs e){
	if (orderByMGCheckBox.Checked){
		orderByResCheckBox.Checked = false;

		mainMatCheckBox.Enabled = true;
		cboxSunSatToFriday.Enabled = true;
		onlyReportingPointCheckBox.Enabled = true;
		hoursCheckBox.Enabled = true;
	}
}

private 
void orderByResCheckBox_CheckedChanged(object sender, System.EventArgs e){
	if (orderByResCheckBox.Checked){
		orderByMGCheckBox.Checked = false;
		majorMinorGroupCheckBox.Checked = false;

		// not implemented options
		mainMatCheckBox.Checked = false;
		cboxSunSatToFriday.Checked = false;
		hoursCheckBox.Checked = false;

		mainMatCheckBox.Enabled = false;
		cboxSunSatToFriday.Enabled = false;
		hoursCheckBox.Enabled = false;
	}else{
		mainMatCheckBox.Enabled = true;
		cboxSunSatToFriday.Enabled = true;
		onlyReportingPointCheckBox.Enabled = true;
		hoursCheckBox.Enabled = true;
	}
}

private 
void majorMinorGroupCheckBox_CheckedChanged(object sender, System.EventArgs e){
	if (orderByResCheckBox.Checked){
		orderByMGCheckBox.Checked = false;
		orderByResCheckBox.Checked = false;

		// not implemented options
		mainMatCheckBox.Checked = false;
		cboxSunSatToFriday.Checked = false;
		onlyReportingPointCheckBox.Checked = false;
		hoursCheckBox.Checked = false;

		mainMatCheckBox.Enabled = false;
		cboxSunSatToFriday.Enabled = false;
		onlyReportingPointCheckBox.Enabled = false;
		hoursCheckBox.Enabled = false;
	}else{
		mainMatCheckBox.Enabled = true;
		cboxSunSatToFriday.Enabled = true;
		onlyReportingPointCheckBox.Enabled = true;
		hoursCheckBox.Enabled = true;
	}
}

private 
void labourCheckBox_CheckedChanged(object sender, System.EventArgs e){
	if (labourCheckBox.Checked)
		hoursCheckBox.Checked = false;
}

private 
void hoursCheckBox_CheckedChanged(object sender, System.EventArgs e){
	if (hoursCheckBox.Checked)
		labourCheckBox.Checked = false;
}

private 
void compareButton_Click(object sender, System.EventArgs e){
	HotListVersionForm hotListVersionForm = new HotListVersionForm(true);
	hotListVersionForm.ShowDialog();

	if (hotListVersionForm.DialogResult == DialogResult.OK){
		int hlid1 = int.Parse(hotListVersionForm.getSelected()[0][0]);
		int hlid2 = int.Parse(hotListVersionForm.getSelected()[1][0]);
		ArrayList fields = new ArrayList();
		DataSet dataSet = generateHLTotalsDataSet(coreFactory, hlid1, hlid2, fields);

		string title = "Hot List Compare, Dates : " + 
			hotListVersionForm.getSelected()[0][1] + " = " + 
			hotListVersionForm.getSelected()[1][1];

		HotListTotals hotListTotals = new HotListTotals(dataSet, title, fields);
		hotListTotals.ShowDialog();
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
void hlBomButton_Click(object sender, System.EventArgs e){
	try{		
		generateHotListReport("B", hoursCheckBox.Checked, labourCheckBox.Checked, true, false);
	}catch(Exception men){
		MessageBox.Show("Error : " + men.Message);
	}
}

}//end class

} // namespace
