using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.WinForms;
using Nujit.NujitERP.ClassLib.ErpException;

namespace Nujit.NujitERP.WinForms.Schedule.LoadUpLoad{

public 
class AutomateDateForm : System.Windows.Forms.Form{


private System.Windows.Forms.Label label1;
private System.Windows.Forms.GroupBox groupBox1;
private System.Windows.Forms.GroupBox groupBox2;
private System.Windows.Forms.Button btnOk;
private System.Windows.Forms.Button btnCancel;
private System.Windows.Forms.Label label2;
private System.Windows.Forms.TextBox nextRunTextBox;
private System.Windows.Forms.Button btnStopAll;
private System.Windows.Forms.NumericUpDown hourUpDown;
private System.Windows.Forms.NumericUpDown minUpDown;
private System.Windows.Forms.CheckBox automaticRestartCheckBox;
private System.ComponentModel.Container components = null;
private System.Windows.Forms.Button button1;
private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private TaskConfiguration taskConfiguration = null;
private System.Windows.Forms.ComboBox taskTypeComboBox;
private System.Windows.Forms.Label label3;
private System.Windows.Forms.NumericUpDown dayUpDown;
private System.Windows.Forms.Label label4;
private System.Windows.Forms.Label label5;
private System.Windows.Forms.NumericUpDown minutesDown;
private System.Windows.Forms.NumericUpDown monthUpDown;
private System.Windows.Forms.NumericUpDown dayOfMonthUpDown;
private System.Windows.Forms.Label label6;
private System.Windows.Forms.Label label7;
private System.Windows.Forms.Label label8;
private System.Windows.Forms.TabControl tabControl1;
private System.Windows.Forms.TabPage loopPage;
private System.Windows.Forms.TabPage dailyPage;
private System.Windows.Forms.TabPage monthlyPage;
private System.Windows.Forms.TabPage annualPage;
private System.Windows.Forms.TabPage oncePage;
private System.Windows.Forms.Label label9;
private System.Windows.Forms.Label label10;
private System.Windows.Forms.Label label11;
private System.Windows.Forms.MonthCalendar calendar;
private System.Windows.Forms.NumericUpDown annualHourUpDown;
private System.Windows.Forms.NumericUpDown annualMinUpDown;
private System.Windows.Forms.NumericUpDown monthlyHourUpDown;
private System.Windows.Forms.NumericUpDown monthlyMinUpDown;
private System.Windows.Forms.NumericUpDown onceHourUpDown;
private System.Windows.Forms.NumericUpDown onceMinUpDown;
private System.Windows.Forms.TabPage tabFiscalPeriod;

private int taskCode;


public 
AutomateDateForm(string title, int taskCode){
	InitializeComponent();

	this.Text = title;
	this.taskCode = taskCode;
	this.DialogResult = DialogResult.Cancel;
	
	initializeFields();
	
}

private 
void initializeFields(){
	this.nextRunTextBox.ReadOnly = true;
	this.nextRunTextBox.Text = "";

	this.hourUpDown.Value = 0;
	this.minUpDown.Value = 0;

	this.taskConfiguration = coreFactory.readTaskConfiguration(taskCode);

	automaticRestartCheckBox.Checked = false;

	string[][] v = TaskConfiguration.getTastTypes();
	for(int i = 0; i < v.Length; i++)
		this.taskTypeComboBox.Items.Add(v[i][1]);

	if (taskConfiguration != null){
		this.taskTypeComboBox.SelectedIndex = (int)taskConfiguration.getTaskType();

		switch(taskConfiguration.getTaskType()){
		case TaskConfiguration.TaskType.TASK_LOOP:
			if (taskConfiguration.getTaskParameter().Equals(""))
				minutesDown.Value = 0;
			else
				minutesDown.Value = decimal.Parse(taskConfiguration.getTaskParameter());
			break;
		case TaskConfiguration.TaskType.TASK_DAILY:
			if (!taskConfiguration.getTaskParameter().Equals("")){
				this.hourUpDown.Value = DateUtil.getItemFromTime(taskConfiguration.getTaskParameter(), DateUtil.HOUR_ITEM);
				this.minUpDown.Value = DateUtil.getItemFromTime(taskConfiguration.getTaskParameter(), DateUtil.MIN_ITEM);
			}
			break;
		case TaskConfiguration.TaskType.TASK_MONTHLY:
			// day hour:min => format example "10 10:00"
			this.dayUpDown.Value = decimal.Parse(taskConfiguration.getTaskParameter().Substring(0, 2));

			monthlyHourUpDown.Value = decimal.Parse(taskConfiguration.getTaskParameter().Substring(3, 2));
			monthlyMinUpDown.Value = decimal.Parse(taskConfiguration.getTaskParameter().Substring(6, 2));
			
			break;
		case TaskConfiguration.TaskType.TASK_ANNUAL:
			// month/day hour:min => format example "12/10 10:00"
			string p = taskConfiguration.getTaskParameter();
			
			string monthDay = p.Substring(0, 5);
			this.monthUpDown.Value = decimal.Parse(monthDay.Substring(0, 2));
			this.dayOfMonthUpDown.Value = decimal.Parse(monthDay.Substring(3, 2));

			string hourMin = p.Substring(6, 5);
			this.annualHourUpDown.Value = decimal.Parse(hourMin.Substring(0, 2));
			this.annualMinUpDown.Value = decimal.Parse(hourMin.Substring(3, 2));

			break;
		case TaskConfiguration.TaskType.TASK_ONCE:
			// date hour:min => format example "12/10/2005 10:00"
			string dateAux = taskConfiguration.getTaskParameter();
			DateTime cDate = DateUtil.parseCompleteDate(dateAux, DateUtil.MMDDYYYY);
			calendar.SetDate(cDate);

			string time = DateUtil.getTimeRepresentation(cDate);
			int h = DateUtil.getItemFromTime(time, DateUtil.HOUR_ITEM);
			int m = DateUtil.getItemFromTime(time, DateUtil.MIN_ITEM);
			this.onceHourUpDown.Value = h;
			this.onceMinUpDown.Value = m;

			break;
		}
		
		if (taskConfiguration.getAutomaticRestart().Equals("Y"))
			automaticRestartCheckBox.Checked = true;
	}

	this.nextRunTextBox.Text = coreFactory.getNextRunTaskInformation(taskCode);
}

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

private 
void InitializeComponent(){
	this.btnOk = new System.Windows.Forms.Button();
	this.btnCancel = new System.Windows.Forms.Button();
	this.label1 = new System.Windows.Forms.Label();
	this.groupBox1 = new System.Windows.Forms.GroupBox();
	this.tabControl1 = new System.Windows.Forms.TabControl();
	this.loopPage = new System.Windows.Forms.TabPage();
	this.label5 = new System.Windows.Forms.Label();
	this.minutesDown = new System.Windows.Forms.NumericUpDown();
	this.dailyPage = new System.Windows.Forms.TabPage();
	this.hourUpDown = new System.Windows.Forms.NumericUpDown();
	this.minUpDown = new System.Windows.Forms.NumericUpDown();
	this.monthlyPage = new System.Windows.Forms.TabPage();
	this.monthlyHourUpDown = new System.Windows.Forms.NumericUpDown();
	this.monthlyMinUpDown = new System.Windows.Forms.NumericUpDown();
	this.label11 = new System.Windows.Forms.Label();
	this.label4 = new System.Windows.Forms.Label();
	this.dayUpDown = new System.Windows.Forms.NumericUpDown();
	this.annualPage = new System.Windows.Forms.TabPage();
	this.annualHourUpDown = new System.Windows.Forms.NumericUpDown();
	this.annualMinUpDown = new System.Windows.Forms.NumericUpDown();
	this.label10 = new System.Windows.Forms.Label();
	this.monthUpDown = new System.Windows.Forms.NumericUpDown();
	this.dayOfMonthUpDown = new System.Windows.Forms.NumericUpDown();
	this.label7 = new System.Windows.Forms.Label();
	this.label8 = new System.Windows.Forms.Label();
	this.oncePage = new System.Windows.Forms.TabPage();
	this.onceHourUpDown = new System.Windows.Forms.NumericUpDown();
	this.onceMinUpDown = new System.Windows.Forms.NumericUpDown();
	this.label9 = new System.Windows.Forms.Label();
	this.calendar = new System.Windows.Forms.MonthCalendar();
	this.label6 = new System.Windows.Forms.Label();
	this.tabFiscalPeriod = new System.Windows.Forms.TabPage();
	this.label3 = new System.Windows.Forms.Label();
	this.taskTypeComboBox = new System.Windows.Forms.ComboBox();
	this.automaticRestartCheckBox = new System.Windows.Forms.CheckBox();
	this.nextRunTextBox = new System.Windows.Forms.TextBox();
	this.label2 = new System.Windows.Forms.Label();
	this.groupBox2 = new System.Windows.Forms.GroupBox();
	this.button1 = new System.Windows.Forms.Button();
	this.btnStopAll = new System.Windows.Forms.Button();
	this.groupBox1.SuspendLayout();
	this.tabControl1.SuspendLayout();
	this.loopPage.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.minutesDown)).BeginInit();
	this.dailyPage.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.hourUpDown)).BeginInit();
	((System.ComponentModel.ISupportInitialize)(this.minUpDown)).BeginInit();
	this.monthlyPage.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.monthlyHourUpDown)).BeginInit();
	((System.ComponentModel.ISupportInitialize)(this.monthlyMinUpDown)).BeginInit();
	((System.ComponentModel.ISupportInitialize)(this.dayUpDown)).BeginInit();
	this.annualPage.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.annualHourUpDown)).BeginInit();
	((System.ComponentModel.ISupportInitialize)(this.annualMinUpDown)).BeginInit();
	((System.ComponentModel.ISupportInitialize)(this.monthUpDown)).BeginInit();
	((System.ComponentModel.ISupportInitialize)(this.dayOfMonthUpDown)).BeginInit();
	this.oncePage.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.onceHourUpDown)).BeginInit();
	((System.ComponentModel.ISupportInitialize)(this.onceMinUpDown)).BeginInit();
	this.groupBox2.SuspendLayout();
	this.SuspendLayout();
	// 
	// btnOk
	// 
	this.btnOk.Location = new System.Drawing.Point(104, 16);
	this.btnOk.Name = "btnOk";
	this.btnOk.TabIndex = 0;
	this.btnOk.Text = "Init / Save";
	this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
	// 
	// btnCancel
	// 
	this.btnCancel.Location = new System.Drawing.Point(264, 16);
	this.btnCancel.Name = "btnCancel";
	this.btnCancel.TabIndex = 1;
	this.btnCancel.Text = "Cancel";
	this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
	// 
	// label1
	// 
	this.label1.Location = new System.Drawing.Point(16, 48);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(80, 16);
	this.label1.TabIndex = 3;
	this.label1.Text = "Transfer Hour";
	// 
	// groupBox1
	// 
	this.groupBox1.Controls.Add(this.tabControl1);
	this.groupBox1.Controls.Add(this.label3);
	this.groupBox1.Controls.Add(this.taskTypeComboBox);
	this.groupBox1.Controls.Add(this.automaticRestartCheckBox);
	this.groupBox1.Controls.Add(this.nextRunTextBox);
	this.groupBox1.Controls.Add(this.label2);
	this.groupBox1.Location = new System.Drawing.Point(8, 8);
	this.groupBox1.Name = "groupBox1";
	this.groupBox1.Size = new System.Drawing.Size(400, 392);
	this.groupBox1.TabIndex = 4;
	this.groupBox1.TabStop = false;
	// 
	// tabControl1
	// 
	this.tabControl1.Controls.Add(this.loopPage);
	this.tabControl1.Controls.Add(this.dailyPage);
	this.tabControl1.Controls.Add(this.monthlyPage);
	this.tabControl1.Controls.Add(this.annualPage);
	this.tabControl1.Controls.Add(this.oncePage);
	this.tabControl1.Controls.Add(this.tabFiscalPeriod);
	this.tabControl1.Location = new System.Drawing.Point(8, 64);
	this.tabControl1.Name = "tabControl1";
	this.tabControl1.SelectedIndex = 0;
	this.tabControl1.Size = new System.Drawing.Size(376, 248);
	this.tabControl1.TabIndex = 17;
	// 
	// loopPage
	// 
	this.loopPage.Controls.Add(this.label5);
	this.loopPage.Controls.Add(this.minutesDown);
	this.loopPage.Location = new System.Drawing.Point(4, 22);
	this.loopPage.Name = "loopPage";
	this.loopPage.Size = new System.Drawing.Size(368, 222);
	this.loopPage.TabIndex = 0;
	this.loopPage.Text = "Loop";
	// 
	// label5
	// 
	this.label5.Location = new System.Drawing.Point(24, 48);
	this.label5.Name = "label5";
	this.label5.Size = new System.Drawing.Size(48, 16);
	this.label5.TabIndex = 16;
	this.label5.Text = "Minutes";
	// 
	// minutesDown
	// 
	this.minutesDown.Location = new System.Drawing.Point(80, 40);
	this.minutesDown.Maximum = new System.Decimal(new int[] {
																900000,
																0,
																0,
																0});
	this.minutesDown.Name = "minutesDown";
	this.minutesDown.Size = new System.Drawing.Size(72, 20);
	this.minutesDown.TabIndex = 16;
	// 
	// dailyPage
	// 
	this.dailyPage.Controls.Add(this.hourUpDown);
	this.dailyPage.Controls.Add(this.minUpDown);
	this.dailyPage.Controls.Add(this.label1);
	this.dailyPage.Location = new System.Drawing.Point(4, 22);
	this.dailyPage.Name = "dailyPage";
	this.dailyPage.Size = new System.Drawing.Size(368, 222);
	this.dailyPage.TabIndex = 1;
	this.dailyPage.Text = "Daily";
	// 
	// hourUpDown
	// 
	this.hourUpDown.Location = new System.Drawing.Point(112, 48);
	this.hourUpDown.Maximum = new System.Decimal(new int[] {
															   23,
															   0,
															   0,
															   0});
	this.hourUpDown.Name = "hourUpDown";
	this.hourUpDown.Size = new System.Drawing.Size(40, 20);
	this.hourUpDown.TabIndex = 6;
	// 
	// minUpDown
	// 
	this.minUpDown.Location = new System.Drawing.Point(152, 48);
	this.minUpDown.Maximum = new System.Decimal(new int[] {
															  59,
															  0,
															  0,
															  0});
	this.minUpDown.Name = "minUpDown";
	this.minUpDown.Size = new System.Drawing.Size(40, 20);
	this.minUpDown.TabIndex = 7;
	// 
	// monthlyPage
	// 
	this.monthlyPage.Controls.Add(this.monthlyHourUpDown);
	this.monthlyPage.Controls.Add(this.monthlyMinUpDown);
	this.monthlyPage.Controls.Add(this.label11);
	this.monthlyPage.Controls.Add(this.label4);
	this.monthlyPage.Controls.Add(this.dayUpDown);
	this.monthlyPage.Location = new System.Drawing.Point(4, 22);
	this.monthlyPage.Name = "monthlyPage";
	this.monthlyPage.Size = new System.Drawing.Size(368, 222);
	this.monthlyPage.TabIndex = 2;
	this.monthlyPage.Text = "Monthly";
	// 
	// monthlyHourUpDown
	// 
	this.monthlyHourUpDown.Location = new System.Drawing.Point(136, 101);
	this.monthlyHourUpDown.Maximum = new System.Decimal(new int[] {
																	  23,
																	  0,
																	  0,
																	  0});
	this.monthlyHourUpDown.Name = "monthlyHourUpDown";
	this.monthlyHourUpDown.Size = new System.Drawing.Size(40, 20);
	this.monthlyHourUpDown.TabIndex = 18;
	// 
	// monthlyMinUpDown
	// 
	this.monthlyMinUpDown.Location = new System.Drawing.Point(176, 101);
	this.monthlyMinUpDown.Maximum = new System.Decimal(new int[] {
																	 59,
																	 0,
																	 0,
																	 0});
	this.monthlyMinUpDown.Name = "monthlyMinUpDown";
	this.monthlyMinUpDown.Size = new System.Drawing.Size(40, 20);
	this.monthlyMinUpDown.TabIndex = 19;
	// 
	// label11
	// 
	this.label11.Location = new System.Drawing.Point(40, 101);
	this.label11.Name = "label11";
	this.label11.Size = new System.Drawing.Size(80, 16);
	this.label11.TabIndex = 17;
	this.label11.Text = "Transfer Hour";
	// 
	// label4
	// 
	this.label4.Location = new System.Drawing.Point(40, 56);
	this.label4.Name = "label4";
	this.label4.Size = new System.Drawing.Size(48, 16);
	this.label4.TabIndex = 16;
	this.label4.Text = "Day";
	// 
	// dayUpDown
	// 
	this.dayUpDown.Location = new System.Drawing.Point(104, 48);
	this.dayUpDown.Maximum = new System.Decimal(new int[] {
															  28,
															  0,
															  0,
															  0});
	this.dayUpDown.Minimum = new System.Decimal(new int[] {
															  1,
															  0,
															  0,
															  0});
	this.dayUpDown.Name = "dayUpDown";
	this.dayUpDown.Size = new System.Drawing.Size(48, 20);
	this.dayUpDown.TabIndex = 0;
	this.dayUpDown.Value = new System.Decimal(new int[] {
															1,
															0,
															0,
															0});
	// 
	// annualPage
	// 
	this.annualPage.Controls.Add(this.annualHourUpDown);
	this.annualPage.Controls.Add(this.annualMinUpDown);
	this.annualPage.Controls.Add(this.label10);
	this.annualPage.Controls.Add(this.monthUpDown);
	this.annualPage.Controls.Add(this.dayOfMonthUpDown);
	this.annualPage.Controls.Add(this.label7);
	this.annualPage.Controls.Add(this.label8);
	this.annualPage.Location = new System.Drawing.Point(4, 22);
	this.annualPage.Name = "annualPage";
	this.annualPage.Size = new System.Drawing.Size(368, 222);
	this.annualPage.TabIndex = 3;
	this.annualPage.Text = "Annual";
	// 
	// annualHourUpDown
	// 
	this.annualHourUpDown.Location = new System.Drawing.Point(120, 96);
	this.annualHourUpDown.Maximum = new System.Decimal(new int[] {
																	 23,
																	 0,
																	 0,
																	 0});
	this.annualHourUpDown.Name = "annualHourUpDown";
	this.annualHourUpDown.Size = new System.Drawing.Size(40, 20);
	this.annualHourUpDown.TabIndex = 19;
	// 
	// annualMinUpDown
	// 
	this.annualMinUpDown.Location = new System.Drawing.Point(160, 96);
	this.annualMinUpDown.Maximum = new System.Decimal(new int[] {
																	59,
																	0,
																	0,
																	0});
	this.annualMinUpDown.Name = "annualMinUpDown";
	this.annualMinUpDown.Size = new System.Drawing.Size(40, 20);
	this.annualMinUpDown.TabIndex = 20;
	// 
	// label10
	// 
	this.label10.Location = new System.Drawing.Point(24, 96);
	this.label10.Name = "label10";
	this.label10.Size = new System.Drawing.Size(80, 16);
	this.label10.TabIndex = 18;
	this.label10.Text = "Transfer Hour";
	// 
	// monthUpDown
	// 
	this.monthUpDown.Location = new System.Drawing.Point(72, 56);
	this.monthUpDown.Maximum = new System.Decimal(new int[] {
																12,
																0,
																0,
																0});
	this.monthUpDown.Minimum = new System.Decimal(new int[] {
																1,
																0,
																0,
																0});
	this.monthUpDown.Name = "monthUpDown";
	this.monthUpDown.Size = new System.Drawing.Size(48, 20);
	this.monthUpDown.TabIndex = 16;
	this.monthUpDown.Value = new System.Decimal(new int[] {
															  1,
															  0,
															  0,
															  0});
	// 
	// dayOfMonthUpDown
	// 
	this.dayOfMonthUpDown.Location = new System.Drawing.Point(184, 56);
	this.dayOfMonthUpDown.Maximum = new System.Decimal(new int[] {
																	 31,
																	 0,
																	 0,
																	 0});
	this.dayOfMonthUpDown.Minimum = new System.Decimal(new int[] {
																	 1,
																	 0,
																	 0,
																	 0});
	this.dayOfMonthUpDown.Name = "dayOfMonthUpDown";
	this.dayOfMonthUpDown.Size = new System.Drawing.Size(48, 20);
	this.dayOfMonthUpDown.TabIndex = 17;
	this.dayOfMonthUpDown.Value = new System.Decimal(new int[] {
																   1,
																   0,
																   0,
																   0});
	// 
	// label7
	// 
	this.label7.Location = new System.Drawing.Point(24, 56);
	this.label7.Name = "label7";
	this.label7.Size = new System.Drawing.Size(40, 16);
	this.label7.TabIndex = 17;
	this.label7.Text = "Month";
	// 
	// label8
	// 
	this.label8.Location = new System.Drawing.Point(136, 56);
	this.label8.Name = "label8";
	this.label8.Size = new System.Drawing.Size(32, 16);
	this.label8.TabIndex = 17;
	this.label8.Text = "Day";
	// 
	// oncePage
	// 
	this.oncePage.Controls.Add(this.onceHourUpDown);
	this.oncePage.Controls.Add(this.onceMinUpDown);
	this.oncePage.Controls.Add(this.label9);
	this.oncePage.Controls.Add(this.calendar);
	this.oncePage.Controls.Add(this.label6);
	this.oncePage.Location = new System.Drawing.Point(4, 22);
	this.oncePage.Name = "oncePage";
	this.oncePage.Size = new System.Drawing.Size(368, 222);
	this.oncePage.TabIndex = 4;
	this.oncePage.Text = "Once Time";
	// 
	// onceHourUpDown
	// 
	this.onceHourUpDown.Location = new System.Drawing.Point(120, 184);
	this.onceHourUpDown.Maximum = new System.Decimal(new int[] {
																   23,
																   0,
																   0,
																   0});
	this.onceHourUpDown.Name = "onceHourUpDown";
	this.onceHourUpDown.Size = new System.Drawing.Size(40, 20);
	this.onceHourUpDown.TabIndex = 9;
	// 
	// onceMinUpDown
	// 
	this.onceMinUpDown.Location = new System.Drawing.Point(160, 184);
	this.onceMinUpDown.Maximum = new System.Decimal(new int[] {
																  59,
																  0,
																  0,
																  0});
	this.onceMinUpDown.Name = "onceMinUpDown";
	this.onceMinUpDown.Size = new System.Drawing.Size(40, 20);
	this.onceMinUpDown.TabIndex = 10;
	// 
	// label9
	// 
	this.label9.Location = new System.Drawing.Point(24, 184);
	this.label9.Name = "label9";
	this.label9.Size = new System.Drawing.Size(80, 16);
	this.label9.TabIndex = 8;
	this.label9.Text = "Transfer Hour";
	// 
	// calendar
	// 
	this.calendar.Location = new System.Drawing.Point(104, 8);
	this.calendar.MaxSelectionCount = 1;
	this.calendar.Name = "calendar";
	this.calendar.TabIndex = 3;
	// 
	// label6
	// 
	this.label6.Location = new System.Drawing.Point(24, 24);
	this.label6.Name = "label6";
	this.label6.Size = new System.Drawing.Size(48, 16);
	this.label6.TabIndex = 0;
	this.label6.Text = "Date";
	// 
	// tabFiscalPeriod
	// 
	this.tabFiscalPeriod.Location = new System.Drawing.Point(4, 22);
	this.tabFiscalPeriod.Name = "tabFiscalPeriod";
	this.tabFiscalPeriod.Size = new System.Drawing.Size(368, 222);
	this.tabFiscalPeriod.TabIndex = 5;
	this.tabFiscalPeriod.Text = "Fiscal Period End";
	// 
	// label3
	// 
	this.label3.Location = new System.Drawing.Point(40, 32);
	this.label3.Name = "label3";
	this.label3.Size = new System.Drawing.Size(64, 16);
	this.label3.TabIndex = 11;
	this.label3.Text = "Type";
	// 
	// taskTypeComboBox
	// 
	this.taskTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.taskTypeComboBox.Location = new System.Drawing.Point(112, 24);
	this.taskTypeComboBox.Name = "taskTypeComboBox";
	this.taskTypeComboBox.Size = new System.Drawing.Size(121, 21);
	this.taskTypeComboBox.TabIndex = 10;
	this.taskTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.taskTypeComboBox_SelectedIndexChanged);
	// 
	// automaticRestartCheckBox
	// 
	this.automaticRestartCheckBox.Location = new System.Drawing.Point(40, 328);
	this.automaticRestartCheckBox.Name = "automaticRestartCheckBox";
	this.automaticRestartCheckBox.Size = new System.Drawing.Size(224, 16);
	this.automaticRestartCheckBox.TabIndex = 9;
	this.automaticRestartCheckBox.Text = "Automatic restart when the system load";
	// 
	// nextRunTextBox
	// 
	this.nextRunTextBox.Location = new System.Drawing.Point(128, 360);
	this.nextRunTextBox.Name = "nextRunTextBox";
	this.nextRunTextBox.Size = new System.Drawing.Size(152, 20);
	this.nextRunTextBox.TabIndex = 5;
	this.nextRunTextBox.Text = "";
	// 
	// label2
	// 
	this.label2.Location = new System.Drawing.Point(40, 360);
	this.label2.Name = "label2";
	this.label2.Size = new System.Drawing.Size(80, 16);
	this.label2.TabIndex = 4;
	this.label2.Text = "Next Run";
	// 
	// groupBox2
	// 
	this.groupBox2.Controls.Add(this.button1);
	this.groupBox2.Controls.Add(this.btnStopAll);
	this.groupBox2.Controls.Add(this.btnOk);
	this.groupBox2.Controls.Add(this.btnCancel);
	this.groupBox2.Location = new System.Drawing.Point(8, 400);
	this.groupBox2.Name = "groupBox2";
	this.groupBox2.Size = new System.Drawing.Size(400, 48);
	this.groupBox2.TabIndex = 5;
	this.groupBox2.TabStop = false;
	// 
	// button1
	// 
	this.button1.Location = new System.Drawing.Point(24, 16);
	this.button1.Name = "button1";
	this.button1.TabIndex = 3;
	this.button1.Text = "Save";
	this.button1.Click += new System.EventHandler(this.button1_Click);
	// 
	// btnStopAll
	// 
	this.btnStopAll.Location = new System.Drawing.Point(184, 16);
	this.btnStopAll.Name = "btnStopAll";
	this.btnStopAll.TabIndex = 2;
	this.btnStopAll.Text = "Stop All";
	this.btnStopAll.Click += new System.EventHandler(this.btnStopAll_Click);
	// 
	// AutomateDateForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(416, 462);
	this.Controls.Add(this.groupBox2);
	this.Controls.Add(this.groupBox1);
	this.Name = "AutomateDateForm";
	this.Text = "AutomateDateForm";
	this.Closing += new System.ComponentModel.CancelEventHandler(this.AutomateDateForm_Closing);
	this.groupBox1.ResumeLayout(false);
	this.tabControl1.ResumeLayout(false);
	this.loopPage.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.minutesDown)).EndInit();
	this.dailyPage.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.hourUpDown)).EndInit();
	((System.ComponentModel.ISupportInitialize)(this.minUpDown)).EndInit();
	this.monthlyPage.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.monthlyHourUpDown)).EndInit();
	((System.ComponentModel.ISupportInitialize)(this.monthlyMinUpDown)).EndInit();
	((System.ComponentModel.ISupportInitialize)(this.dayUpDown)).EndInit();
	this.annualPage.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.annualHourUpDown)).EndInit();
	((System.ComponentModel.ISupportInitialize)(this.annualMinUpDown)).EndInit();
	((System.ComponentModel.ISupportInitialize)(this.monthUpDown)).EndInit();
	((System.ComponentModel.ISupportInitialize)(this.dayOfMonthUpDown)).EndInit();
	this.oncePage.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.onceHourUpDown)).EndInit();
	((System.ComponentModel.ISupportInitialize)(this.onceMinUpDown)).EndInit();
	this.groupBox2.ResumeLayout(false);
	this.ResumeLayout(false);

}
#endregion

public 
string getLoopParameter(){
	return this.minutesDown.Value.ToString();
}

public 
string getDailyParameter(){
	string hour = decimal.ToInt32(hourUpDown.Value).ToString();
	string min = decimal.ToInt32(minUpDown.Value).ToString();

	if (hour.Length < 2)
		hour = "0" + hour;
	if (min.Length < 2)
		min = "0" + min;
	
	return hour + ":" + min;
}

public 
string getMonthlyParameter(){
// day hour:min => format example "12 10:00"
	string day = this.dayUpDown.Value.ToString();
	if (day.Length < 2)
		day = "0" + day;
	
	string hour = monthlyHourUpDown.Value.ToString();
	if (hour.Length < 2)
		hour = "0" + hour;

	string min = monthlyMinUpDown.Value.ToString();
	if (min.Length < 2)
		min = "0" + min;

	return day + " " + hour + ":" + min;
}

public 
string getAnnualParameter(){
// month/day hour:min => format example "12/10 10:00"
	string day = dayOfMonthUpDown.Value.ToString();
	string month = monthUpDown.Value.ToString();
	
	if (day.Length < 2)
		day = "0" + day;
	if (month.Length < 2)
		month = "0" + month;

	string hour = annualHourUpDown.Value.ToString();
	if (hour.Length < 2)
		hour = "0" + hour;

	string min = annualMinUpDown.Value.ToString();
	if (min.Length < 2)
		min = "0" + min;

	return month + "/" + day + " " + hour + ":" + min;
}

public 
string getOnceParameter(){
// date hour:min => format example "12/10/2005 10:00"
	string h = onceHourUpDown.Value.ToString();
	if (h.Length < 2)
		h = "0" + h;

	string m = onceMinUpDown.Value.ToString();
	if (m.Length < 2)
		m = "0" + m;
	return DateUtil.getDateRepresentation(calendar.SelectionStart, DateUtil.MMDDYYYY) + " " + h + ":" + m +
		":" + "00";
}

public 
string getAutomaticRestart(){
	if (automaticRestartCheckBox.Checked)
		return "Y";
	return "N";
}

private 
void btnCancel_Click(object sender, System.EventArgs e){
	this.DialogResult = DialogResult.Cancel;
	Close();
}

private 
void btnOk_Click(object sender, System.EventArgs e){
	if (saveConfig()){
		if (coreFactory.getNextRunTaskInformation(taskCode).Equals(""))
			coreFactory.insertTaskEngine(taskCode, taskConfiguration.getTaskParameter());

		coreFactory = null;
		Dispose();
	}
}

private 
void btnStopAll_Click(object sender, System.EventArgs e){
	coreFactory.stopAllPendingTasks(taskCode);

	this.coreFactory = null;
	Dispose();
}

private 
void button1_Click(object sender, System.EventArgs e){
	if (saveConfig()){
		this.coreFactory = null;
		Dispose();
	}
}

private 
bool saveConfig(){
	try{
		if (taskConfiguration == null)
			taskConfiguration = new TaskConfiguration();

		TaskConfiguration.TaskType type = (TaskConfiguration.TaskType) this.taskTypeComboBox.SelectedIndex;
		
		taskConfiguration.setTaskId(taskCode);
		taskConfiguration.setAutomaticRestart(getAutomaticRestart());
		taskConfiguration.setTaskType(type);

		switch(type){
		case TaskConfiguration.TaskType.TASK_LOOP:
			taskConfiguration.setTaskParameter(getLoopParameter());
			break;
		case TaskConfiguration.TaskType.TASK_DAILY:
			taskConfiguration.setTaskParameter(getDailyParameter());
			break;
		case TaskConfiguration.TaskType.TASK_MONTHLY:
			taskConfiguration.setTaskParameter(getMonthlyParameter());
			break;
		case TaskConfiguration.TaskType.TASK_ANNUAL:
			taskConfiguration.setTaskParameter(getAnnualParameter());
			break;
		case TaskConfiguration.TaskType.TASK_ONCE:
			taskConfiguration.setTaskParameter(getOnceParameter());
			break;
		}

		this.coreFactory.updateTaskConfiguration(taskConfiguration);

		return true;
	}catch(NujitException e){
		FormException formException = new FormException(e);
		formException.ShowDialog();
	}
	return false;
}

private 
void AutomateDateForm_Closing(object sender, System.ComponentModel.CancelEventArgs e){
	this.coreFactory = null;
}

private 
void taskTypeComboBox_SelectedIndexChanged(object sender, System.EventArgs e){
	minutesDown.Enabled = false;
	hourUpDown.Enabled = false;
	minUpDown.Enabled = false;
	dayUpDown.Enabled = false;
	monthUpDown.Enabled = false;
	dayOfMonthUpDown.Enabled = false;
	calendar.Enabled = false;
	monthlyHourUpDown.Enabled = false;
	monthlyMinUpDown.Enabled = false;
	annualHourUpDown.Enabled = false;
	annualMinUpDown.Enabled = false;
	onceHourUpDown.Enabled = false;
	onceMinUpDown.Enabled = false;
	
	TaskConfiguration.TaskType type = (TaskConfiguration.TaskType) taskTypeComboBox.SelectedIndex;

	switch(type){
	case TaskConfiguration.TaskType.TASK_LOOP:
		minutesDown.Enabled = true;

		this.tabControl1.SelectedIndex = 0;

		break;
	case TaskConfiguration.TaskType.TASK_DAILY:
		this.hourUpDown.Enabled = true;
		this.minUpDown.Enabled = true;
		
		this.tabControl1.SelectedIndex = 1;
		
		break;
	case TaskConfiguration.TaskType.TASK_MONTHLY:
		dayUpDown.Enabled = true;
		this.monthlyHourUpDown.Enabled = true;
		this.monthlyMinUpDown.Enabled = true;

		this.tabControl1.SelectedIndex = 2;

		break;
	case TaskConfiguration.TaskType.TASK_ANNUAL:
		monthUpDown.Enabled = true;
		dayOfMonthUpDown.Enabled = true;
		this.annualHourUpDown.Enabled = true;
		this.annualMinUpDown.Enabled = true;
		
		this.tabControl1.SelectedIndex = 3;

		break;
	case TaskConfiguration.TaskType.TASK_ONCE:
		this.calendar.Enabled = true;
		onceHourUpDown.Enabled = true;
		onceMinUpDown.Enabled = true;
		
		this.tabControl1.SelectedIndex = 4;
		
		break;
	}
}



} // class

} // namespace
