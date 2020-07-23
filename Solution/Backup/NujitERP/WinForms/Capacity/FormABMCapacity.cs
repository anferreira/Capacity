using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using NujitCustomWinControls;

using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;

using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.ClassLib.Common;
using GridScheduling.gui.schedule;

using AGVBN20;

namespace Nujit.NujitERP.WinForms.CapacityModule{

	public 
		class FormABMCapacity : System.Windows.Forms.Form
	{

		#region Attributes

		private CoreFactory coreFactory = null;
		private Capacity capacity = null;
		private Machine machine = null;
		private Shift shift = null;
		private CapacityVersion capacityVersion = null;
		private int[] currentWeekPosition = {0,0};
		private int[] firstWeekPosition = {0,0};
		private int[] lastWeekPosition = {0,0};
		private string[][] copiedWeek = null;
		private bool detailChanging = false;
		private string[] currentDetail = null;
		private string[][][] shiftBounds = null;
		#endregion

		#region Controls

		private System.Windows.Forms.GroupBox grpDepartment;
		private System.Windows.Forms.GroupBox grpDetail;
		private System.Windows.Forms.GroupBox grpCapacity;
		private System.Windows.Forms.GroupBox grpVersion;
		private System.Windows.Forms.GroupBox grpShift;
		private AGVBN20.ActiveGanttVBNCtl ganttCapacity;
		private System.Windows.Forms.Button btnPrevious;
		private System.Windows.Forms.Button btnFirst;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnLast;
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.Button btnPaste;
		private System.Windows.Forms.Button btnImportShift;
		private System.Windows.Forms.Button btnViewShift;
		private System.Windows.Forms.Label lblMachine;
		private System.Windows.Forms.TextBox txtMachine;
		private System.Windows.Forms.TextBox txtPlant;
		private System.Windows.Forms.TextBox txtDepartment;
		private System.Windows.Forms.Label lblPlant;
		private System.Windows.Forms.Label lblDepartment;
		private System.Windows.Forms.Label lblShift;
		private System.Windows.Forms.Label lblScheduledStart;
		private System.Windows.Forms.Label lblScheduledEnd;
		private AGVBN20.ActiveGanttVBNCtl ganttShift;
		private System.Windows.Forms.Label lblStartVersion;
		private System.Windows.Forms.Label lblEndVersion;
		private System.Windows.Forms.TextBox txtVersionStart;
		private System.Windows.Forms.ComboBox cboVersions;
		private System.Windows.Forms.Label lblScheduleVersion;
		private System.Windows.Forms.Label lblYear;
		private System.Windows.Forms.NumericUpDown nudYear;
		private System.Windows.Forms.TextBox txtVersionEnd;
		private System.Windows.Forms.Button btnAddVersion;
		private System.Windows.Forms.Label lblCapacityEnd;
		private System.Windows.Forms.Label lblCapacityStart;
		private System.Windows.Forms.DateTimePicker pkrCapacityStart;
		private System.Windows.Forms.DateTimePicker pkrCapacityEnd;
		private System.Windows.Forms.CheckBox chkAllShifts;
		private System.Windows.Forms.Label label4;
		private NujitCustomWinControls.NumericTextBox numtxtCapacity;
		private System.Windows.Forms.Button btnRecalculate;
		private System.Windows.Forms.ComboBox cboDetailDay;
		private System.Windows.Forms.Label lblDetailDay;
		private System.Windows.Forms.ComboBox cboDetailType;
		private System.Windows.Forms.Label lblDetailType;
		private System.Windows.Forms.Label lblDetailTimeEnd;
		private System.Windows.Forms.Label lblDetailTimeStart;
		private NujitCustomWinControls.TimeCtrl tmeDetailTimeStart;
		private NujitCustomWinControls.TimeCtrl tmeDetailTimeEnd;
		private NujitCustomWinControls.NumericTextBox numtxtDetailHours;
		private System.Windows.Forms.Label lblDetailHours;
		private System.Windows.Forms.CheckBox chkApplyAllWeek;
		private System.Windows.Forms.Button btnDetailDelete;
		private System.Windows.Forms.Button btnDetailClear;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.ComboBox cboShifts;
		private System.Windows.Forms.TextBox txtShiftStart;
		private System.Windows.Forms.TextBox txtShiftEnd;
		private System.Windows.Forms.Button btnDetailAddNew;
		private System.Windows.Forms.Label cover;
		private System.Windows.Forms.Button btnClearWeek;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion
		
		#region Windows Form Designer generated code
		
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormABMCapacity));
			this.grpDepartment = new System.Windows.Forms.GroupBox();
			this.txtDepartment = new System.Windows.Forms.TextBox();
			this.txtPlant = new System.Windows.Forms.TextBox();
			this.txtMachine = new System.Windows.Forms.TextBox();
			this.lblMachine = new System.Windows.Forms.Label();
			this.lblPlant = new System.Windows.Forms.Label();
			this.lblDepartment = new System.Windows.Forms.Label();
			this.grpDetail = new System.Windows.Forms.GroupBox();
			this.btnDetailClear = new System.Windows.Forms.Button();
			this.btnDetailAddNew = new System.Windows.Forms.Button();
			this.btnDetailDelete = new System.Windows.Forms.Button();
			this.chkApplyAllWeek = new System.Windows.Forms.CheckBox();
			this.lblDetailHours = new System.Windows.Forms.Label();
			this.numtxtDetailHours = new NujitCustomWinControls.NumericTextBox();
			this.tmeDetailTimeEnd = new NujitCustomWinControls.TimeCtrl();
			this.tmeDetailTimeStart = new NujitCustomWinControls.TimeCtrl();
			this.lblDetailTimeEnd = new System.Windows.Forms.Label();
			this.lblDetailTimeStart = new System.Windows.Forms.Label();
			this.cboDetailType = new System.Windows.Forms.ComboBox();
			this.lblDetailType = new System.Windows.Forms.Label();
			this.cboDetailDay = new System.Windows.Forms.ComboBox();
			this.lblDetailDay = new System.Windows.Forms.Label();
			this.grpCapacity = new System.Windows.Forms.GroupBox();
			this.btnRecalculate = new System.Windows.Forms.Button();
			this.numtxtCapacity = new NujitCustomWinControls.NumericTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.chkAllShifts = new System.Windows.Forms.CheckBox();
			this.pkrCapacityEnd = new System.Windows.Forms.DateTimePicker();
			this.pkrCapacityStart = new System.Windows.Forms.DateTimePicker();
			this.lblCapacityEnd = new System.Windows.Forms.Label();
			this.lblCapacityStart = new System.Windows.Forms.Label();
			this.grpVersion = new System.Windows.Forms.GroupBox();
			this.cboVersions = new System.Windows.Forms.ComboBox();
			this.lblScheduleVersion = new System.Windows.Forms.Label();
			this.btnAddVersion = new System.Windows.Forms.Button();
			this.txtVersionStart = new System.Windows.Forms.TextBox();
			this.txtVersionEnd = new System.Windows.Forms.TextBox();
			this.lblEndVersion = new System.Windows.Forms.Label();
			this.lblStartVersion = new System.Windows.Forms.Label();
			this.grpShift = new System.Windows.Forms.GroupBox();
			this.cboShifts = new System.Windows.Forms.ComboBox();
			this.txtShiftStart = new System.Windows.Forms.TextBox();
			this.txtShiftEnd = new System.Windows.Forms.TextBox();
			this.lblScheduledEnd = new System.Windows.Forms.Label();
			this.lblScheduledStart = new System.Windows.Forms.Label();
			this.lblShift = new System.Windows.Forms.Label();
			this.ganttCapacity = new AGVBN20.ActiveGanttVBNCtl();
			this.btnPrevious = new System.Windows.Forms.Button();
			this.btnFirst = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnLast = new System.Windows.Forms.Button();
			this.lblYear = new System.Windows.Forms.Label();
			this.nudYear = new System.Windows.Forms.NumericUpDown();
			this.btnCopy = new System.Windows.Forms.Button();
			this.btnPaste = new System.Windows.Forms.Button();
			this.btnImportShift = new System.Windows.Forms.Button();
			this.btnViewShift = new System.Windows.Forms.Button();
			this.ganttShift = new AGVBN20.ActiveGanttVBNCtl();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.cover = new System.Windows.Forms.Label();
			this.btnClearWeek = new System.Windows.Forms.Button();
			this.grpDepartment.SuspendLayout();
			this.grpDetail.SuspendLayout();
			this.grpCapacity.SuspendLayout();
			this.grpVersion.SuspendLayout();
			this.grpShift.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
			this.SuspendLayout();
			// 
			// grpDepartment
			// 
			this.grpDepartment.Controls.Add(this.txtDepartment);
			this.grpDepartment.Controls.Add(this.txtPlant);
			this.grpDepartment.Controls.Add(this.txtMachine);
			this.grpDepartment.Controls.Add(this.lblMachine);
			this.grpDepartment.Controls.Add(this.lblPlant);
			this.grpDepartment.Controls.Add(this.lblDepartment);
			this.grpDepartment.Location = new System.Drawing.Point(8, 8);
			this.grpDepartment.Name = "grpDepartment";
			this.grpDepartment.Size = new System.Drawing.Size(328, 80);
			this.grpDepartment.TabIndex = 0;
			this.grpDepartment.TabStop = false;
			this.grpDepartment.Text = "Department";
			// 
			// txtDepartment
			// 
			this.txtDepartment.Location = new System.Drawing.Point(72, 48);
			this.txtDepartment.Name = "txtDepartment";
			this.txtDepartment.ReadOnly = true;
			this.txtDepartment.Size = new System.Drawing.Size(112, 20);
			this.txtDepartment.TabIndex = 15;
			this.txtDepartment.Text = "";
			// 
			// txtPlant
			// 
			this.txtPlant.Location = new System.Drawing.Point(72, 24);
			this.txtPlant.Name = "txtPlant";
			this.txtPlant.ReadOnly = true;
			this.txtPlant.Size = new System.Drawing.Size(112, 20);
			this.txtPlant.TabIndex = 14;
			this.txtPlant.Text = "";
			// 
			// txtMachine
			// 
			this.txtMachine.Location = new System.Drawing.Point(200, 48);
			this.txtMachine.Name = "txtMachine";
			this.txtMachine.ReadOnly = true;
			this.txtMachine.Size = new System.Drawing.Size(112, 20);
			this.txtMachine.TabIndex = 13;
			this.txtMachine.Text = "";
			// 
			// lblMachine
			// 
			this.lblMachine.Location = new System.Drawing.Point(200, 24);
			this.lblMachine.Name = "lblMachine";
			this.lblMachine.Size = new System.Drawing.Size(64, 20);
			this.lblMachine.TabIndex = 12;
			this.lblMachine.Text = "Machine:";
			this.lblMachine.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lblPlant
			// 
			this.lblPlant.Location = new System.Drawing.Point(8, 24);
			this.lblPlant.Name = "lblPlant";
			this.lblPlant.Size = new System.Drawing.Size(64, 20);
			this.lblPlant.TabIndex = 10;
			this.lblPlant.Text = "Plant:";
			this.lblPlant.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblDepartment
			// 
			this.lblDepartment.Location = new System.Drawing.Point(4, 48);
			this.lblDepartment.Name = "lblDepartment";
			this.lblDepartment.Size = new System.Drawing.Size(68, 20);
			this.lblDepartment.TabIndex = 11;
			this.lblDepartment.Text = "Department:";
			this.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpDetail
			// 
			this.grpDetail.Controls.Add(this.btnDetailClear);
			this.grpDetail.Controls.Add(this.btnDetailAddNew);
			this.grpDetail.Controls.Add(this.btnDetailDelete);
			this.grpDetail.Controls.Add(this.chkApplyAllWeek);
			this.grpDetail.Controls.Add(this.lblDetailHours);
			this.grpDetail.Controls.Add(this.numtxtDetailHours);
			this.grpDetail.Controls.Add(this.tmeDetailTimeEnd);
			this.grpDetail.Controls.Add(this.tmeDetailTimeStart);
			this.grpDetail.Controls.Add(this.lblDetailTimeEnd);
			this.grpDetail.Controls.Add(this.lblDetailTimeStart);
			this.grpDetail.Controls.Add(this.cboDetailType);
			this.grpDetail.Controls.Add(this.lblDetailType);
			this.grpDetail.Controls.Add(this.cboDetailDay);
			this.grpDetail.Controls.Add(this.lblDetailDay);
			this.grpDetail.Location = new System.Drawing.Point(8, 456);
			this.grpDetail.Name = "grpDetail";
			this.grpDetail.Size = new System.Drawing.Size(680, 80);
			this.grpDetail.TabIndex = 1;
			this.grpDetail.TabStop = false;
			this.grpDetail.Text = "Detail";
			// 
			// btnDetailClear
			// 
			this.btnDetailClear.Location = new System.Drawing.Point(496, 48);
			this.btnDetailClear.Name = "btnDetailClear";
			this.btnDetailClear.Size = new System.Drawing.Size(80, 24);
			this.btnDetailClear.TabIndex = 68;
			this.btnDetailClear.Text = "Clear";
			this.btnDetailClear.Click += new System.EventHandler(this.btnDetailClear_Click);
			// 
			// btnDetailAddNew
			// 
			this.btnDetailAddNew.Location = new System.Drawing.Point(584, 48);
			this.btnDetailAddNew.Name = "btnDetailAddNew";
			this.btnDetailAddNew.Size = new System.Drawing.Size(80, 24);
			this.btnDetailAddNew.TabIndex = 67;
			this.btnDetailAddNew.Text = "Add";
			this.btnDetailAddNew.Click += new System.EventHandler(this.btnDetailAddNew_Click);
			// 
			// btnDetailDelete
			// 
			this.btnDetailDelete.Location = new System.Drawing.Point(584, 16);
			this.btnDetailDelete.Name = "btnDetailDelete";
			this.btnDetailDelete.Size = new System.Drawing.Size(80, 24);
			this.btnDetailDelete.TabIndex = 66;
			this.btnDetailDelete.Text = "Delete";
			this.btnDetailDelete.Click += new System.EventHandler(this.btnDetailDelete_Click);
			// 
			// chkApplyAllWeek
			// 
			this.chkApplyAllWeek.Location = new System.Drawing.Point(448, 24);
			this.chkApplyAllWeek.Name = "chkApplyAllWeek";
			this.chkApplyAllWeek.Size = new System.Drawing.Size(116, 20);
			this.chkApplyAllWeek.TabIndex = 65;
			this.chkApplyAllWeek.Text = "Apply to all Week";
			// 
			// lblDetailHours
			// 
			this.lblDetailHours.Location = new System.Drawing.Point(352, 24);
			this.lblDetailHours.Name = "lblDetailHours";
			this.lblDetailHours.Size = new System.Drawing.Size(72, 20);
			this.lblDetailHours.TabIndex = 47;
			this.lblDetailHours.Text = "Detail Hours:";
			this.lblDetailHours.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// numtxtDetailHours
			// 
			this.numtxtDetailHours.DecimalPlaces = 2;
			this.numtxtDetailHours.Location = new System.Drawing.Point(352, 48);
			this.numtxtDetailHours.Maximum = new System.Decimal(new int[] {
																			  24,
																			  0,
																			  0,
																			  0});
			this.numtxtDetailHours.MaxPrecision = 2;
			this.numtxtDetailHours.Minimum = new System.Decimal(new int[] {
																			  0,
																			  0,
																			  0,
																			  0});
			this.numtxtDetailHours.Name = "numtxtDetailHours";
			this.numtxtDetailHours.ReadOnly = true;
			this.numtxtDetailHours.Rounded = true;
			this.numtxtDetailHours.Size = new System.Drawing.Size(80, 20);
			this.numtxtDetailHours.TabIndex = 46;
			this.numtxtDetailHours.Value = new System.Decimal(new int[] {
																			0,
																			0,
																			0,
																			0});
			// 
			// tmeDetailTimeEnd
			// 
			this.tmeDetailTimeEnd.Location = new System.Drawing.Point(264, 48);
			this.tmeDetailTimeEnd.Name = "tmeDetailTimeEnd";
			this.tmeDetailTimeEnd.ShowSeconds = false;
			this.tmeDetailTimeEnd.Size = new System.Drawing.Size(72, 21);
			this.tmeDetailTimeEnd.TabIndex = 24;
			this.tmeDetailTimeEnd.Value = new System.DateTime(2005, 4, 4, 10, 29, 0, 0);
			this.tmeDetailTimeEnd.ValueChanged += new System.EventHandler(this.tmeDetailTimeEnd_ValueChanged);
			// 
			// tmeDetailTimeStart
			// 
			this.tmeDetailTimeStart.Location = new System.Drawing.Point(264, 24);
			this.tmeDetailTimeStart.Name = "tmeDetailTimeStart";
			this.tmeDetailTimeStart.ShowSeconds = false;
			this.tmeDetailTimeStart.Size = new System.Drawing.Size(72, 21);
			this.tmeDetailTimeStart.TabIndex = 23;
			this.tmeDetailTimeStart.Value = new System.DateTime(2005, 4, 4, 10, 29, 0, 0);
			this.tmeDetailTimeStart.ValueChanged += new System.EventHandler(this.tmeDetailTimeStart_ValueChanged);
			// 
			// lblDetailTimeEnd
			// 
			this.lblDetailTimeEnd.Location = new System.Drawing.Point(200, 48);
			this.lblDetailTimeEnd.Name = "lblDetailTimeEnd";
			this.lblDetailTimeEnd.Size = new System.Drawing.Size(64, 20);
			this.lblDetailTimeEnd.TabIndex = 22;
			this.lblDetailTimeEnd.Text = "Time End:";
			this.lblDetailTimeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblDetailTimeStart
			// 
			this.lblDetailTimeStart.Location = new System.Drawing.Point(200, 24);
			this.lblDetailTimeStart.Name = "lblDetailTimeStart";
			this.lblDetailTimeStart.Size = new System.Drawing.Size(64, 20);
			this.lblDetailTimeStart.TabIndex = 21;
			this.lblDetailTimeStart.Text = "Time Start:";
			this.lblDetailTimeStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cboDetailType
			// 
			this.cboDetailType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDetailType.Location = new System.Drawing.Point(48, 48);
			this.cboDetailType.Name = "cboDetailType";
			this.cboDetailType.Size = new System.Drawing.Size(136, 21);
			this.cboDetailType.TabIndex = 20;
			this.cboDetailType.SelectedIndexChanged += new System.EventHandler(this.cboDetailType_SelectedIndexChanged);
			// 
			// lblDetailType
			// 
			this.lblDetailType.Location = new System.Drawing.Point(16, 48);
			this.lblDetailType.Name = "lblDetailType";
			this.lblDetailType.Size = new System.Drawing.Size(32, 20);
			this.lblDetailType.TabIndex = 19;
			this.lblDetailType.Text = "Type:";
			this.lblDetailType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cboDetailDay
			// 
			this.cboDetailDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDetailDay.Location = new System.Drawing.Point(48, 24);
			this.cboDetailDay.Name = "cboDetailDay";
			this.cboDetailDay.Size = new System.Drawing.Size(136, 21);
			this.cboDetailDay.TabIndex = 18;
			this.cboDetailDay.SelectedIndexChanged += new System.EventHandler(this.cboDetailDay_SelectedIndexChanged);
			// 
			// lblDetailDay
			// 
			this.lblDetailDay.Location = new System.Drawing.Point(16, 24);
			this.lblDetailDay.Name = "lblDetailDay";
			this.lblDetailDay.Size = new System.Drawing.Size(32, 20);
			this.lblDetailDay.TabIndex = 17;
			this.lblDetailDay.Text = "Day:";
			this.lblDetailDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpCapacity
			// 
			this.grpCapacity.Controls.Add(this.btnRecalculate);
			this.grpCapacity.Controls.Add(this.numtxtCapacity);
			this.grpCapacity.Controls.Add(this.label4);
			this.grpCapacity.Controls.Add(this.chkAllShifts);
			this.grpCapacity.Controls.Add(this.pkrCapacityEnd);
			this.grpCapacity.Controls.Add(this.pkrCapacityStart);
			this.grpCapacity.Controls.Add(this.lblCapacityEnd);
			this.grpCapacity.Controls.Add(this.lblCapacityStart);
			this.grpCapacity.Location = new System.Drawing.Point(344, 8);
			this.grpCapacity.Name = "grpCapacity";
			this.grpCapacity.Size = new System.Drawing.Size(432, 80);
			this.grpCapacity.TabIndex = 1;
			this.grpCapacity.TabStop = false;
			this.grpCapacity.Text = "Capacity";
			// 
			// btnRecalculate
			// 
			this.btnRecalculate.Location = new System.Drawing.Point(344, 48);
			this.btnRecalculate.Name = "btnRecalculate";
			this.btnRecalculate.Size = new System.Drawing.Size(80, 24);
			this.btnRecalculate.TabIndex = 67;
			this.btnRecalculate.Text = "Recalculate";
			this.btnRecalculate.Click += new System.EventHandler(this.btnRecalculate_Click);
			// 
			// numtxtCapacity
			// 
			this.numtxtCapacity.AllowNull = true;
			this.numtxtCapacity.DecimalPlaces = 2;
			this.numtxtCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.numtxtCapacity.IsNull = true;
			this.numtxtCapacity.Location = new System.Drawing.Point(248, 48);
			this.numtxtCapacity.Maximum = new System.Decimal(new int[] {
																		   1000000,
																		   0,
																		   0,
																		   0});
			this.numtxtCapacity.MaxPrecision = 2;
			this.numtxtCapacity.Minimum = new System.Decimal(new int[] {
																		   0,
																		   0,
																		   0,
																		   0});
			this.numtxtCapacity.Name = "numtxtCapacity";
			this.numtxtCapacity.ReadOnly = true;
			this.numtxtCapacity.Rounded = true;
			this.numtxtCapacity.Size = new System.Drawing.Size(64, 20);
			this.numtxtCapacity.TabIndex = 66;
			this.numtxtCapacity.Value = new System.Decimal(new int[] {
																		 0,
																		 0,
																		 0,
																		 0});
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(192, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 20);
			this.label4.TabIndex = 65;
			this.label4.Text = "Capacity:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkAllShifts
			// 
			this.chkAllShifts.Location = new System.Drawing.Point(200, 24);
			this.chkAllShifts.Name = "chkAllShifts";
			this.chkAllShifts.Size = new System.Drawing.Size(116, 20);
			this.chkAllShifts.TabIndex = 64;
			this.chkAllShifts.Text = "Consider all shifts";
			// 
			// pkrCapacityEnd
			// 
			this.pkrCapacityEnd.Location = new System.Drawing.Point(48, 48);
			this.pkrCapacityEnd.Name = "pkrCapacityEnd";
			this.pkrCapacityEnd.Size = new System.Drawing.Size(136, 20);
			this.pkrCapacityEnd.TabIndex = 17;
			// 
			// pkrCapacityStart
			// 
			this.pkrCapacityStart.Location = new System.Drawing.Point(48, 24);
			this.pkrCapacityStart.Name = "pkrCapacityStart";
			this.pkrCapacityStart.Size = new System.Drawing.Size(136, 20);
			this.pkrCapacityStart.TabIndex = 16;
			// 
			// lblCapacityEnd
			// 
			this.lblCapacityEnd.Location = new System.Drawing.Point(16, 48);
			this.lblCapacityEnd.Name = "lblCapacityEnd";
			this.lblCapacityEnd.Size = new System.Drawing.Size(32, 20);
			this.lblCapacityEnd.TabIndex = 15;
			this.lblCapacityEnd.Text = "End:";
			this.lblCapacityEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblCapacityStart
			// 
			this.lblCapacityStart.Location = new System.Drawing.Point(16, 24);
			this.lblCapacityStart.Name = "lblCapacityStart";
			this.lblCapacityStart.Size = new System.Drawing.Size(32, 20);
			this.lblCapacityStart.TabIndex = 14;
			this.lblCapacityStart.Text = "Start:";
			this.lblCapacityStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpVersion
			// 
			this.grpVersion.Controls.Add(this.cboVersions);
			this.grpVersion.Controls.Add(this.lblScheduleVersion);
			this.grpVersion.Controls.Add(this.btnAddVersion);
			this.grpVersion.Controls.Add(this.txtVersionStart);
			this.grpVersion.Controls.Add(this.txtVersionEnd);
			this.grpVersion.Controls.Add(this.lblEndVersion);
			this.grpVersion.Controls.Add(this.lblStartVersion);
			this.grpVersion.Location = new System.Drawing.Point(8, 96);
			this.grpVersion.Name = "grpVersion";
			this.grpVersion.Size = new System.Drawing.Size(328, 112);
			this.grpVersion.TabIndex = 1;
			this.grpVersion.TabStop = false;
			this.grpVersion.Text = "Version";
			// 
			// cboVersions
			// 
			this.cboVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboVersions.Location = new System.Drawing.Point(120, 24);
			this.cboVersions.Name = "cboVersions";
			this.cboVersions.Size = new System.Drawing.Size(192, 21);
			this.cboVersions.TabIndex = 66;
			this.cboVersions.SelectedIndexChanged += new System.EventHandler(this.cboVersions_SelectedIndexChanged);
			// 
			// lblScheduleVersion
			// 
			this.lblScheduleVersion.Location = new System.Drawing.Point(16, 24);
			this.lblScheduleVersion.Name = "lblScheduleVersion";
			this.lblScheduleVersion.Size = new System.Drawing.Size(100, 20);
			this.lblScheduleVersion.TabIndex = 65;
			this.lblScheduleVersion.Text = "Schedule Version";
			this.lblScheduleVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnAddVersion
			// 
			this.btnAddVersion.Location = new System.Drawing.Point(216, 72);
			this.btnAddVersion.Name = "btnAddVersion";
			this.btnAddVersion.Size = new System.Drawing.Size(80, 24);
			this.btnAddVersion.TabIndex = 64;
			this.btnAddVersion.Text = "Add Version";
			this.btnAddVersion.Click += new System.EventHandler(this.btnAddVersion_Click);
			// 
			// txtVersionStart
			// 
			this.txtVersionStart.Location = new System.Drawing.Point(48, 56);
			this.txtVersionStart.Name = "txtVersionStart";
			this.txtVersionStart.ReadOnly = true;
			this.txtVersionStart.Size = new System.Drawing.Size(136, 20);
			this.txtVersionStart.TabIndex = 16;
			this.txtVersionStart.Text = "";
			// 
			// txtVersionEnd
			// 
			this.txtVersionEnd.Location = new System.Drawing.Point(48, 80);
			this.txtVersionEnd.Name = "txtVersionEnd";
			this.txtVersionEnd.ReadOnly = true;
			this.txtVersionEnd.Size = new System.Drawing.Size(136, 20);
			this.txtVersionEnd.TabIndex = 15;
			this.txtVersionEnd.Text = "";
			// 
			// lblEndVersion
			// 
			this.lblEndVersion.Location = new System.Drawing.Point(16, 80);
			this.lblEndVersion.Name = "lblEndVersion";
			this.lblEndVersion.Size = new System.Drawing.Size(32, 20);
			this.lblEndVersion.TabIndex = 13;
			this.lblEndVersion.Text = "End:";
			this.lblEndVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblStartVersion
			// 
			this.lblStartVersion.Location = new System.Drawing.Point(16, 56);
			this.lblStartVersion.Name = "lblStartVersion";
			this.lblStartVersion.Size = new System.Drawing.Size(32, 20);
			this.lblStartVersion.TabIndex = 12;
			this.lblStartVersion.Text = "Start:";
			this.lblStartVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpShift
			// 
			this.grpShift.Controls.Add(this.cboShifts);
			this.grpShift.Controls.Add(this.txtShiftStart);
			this.grpShift.Controls.Add(this.txtShiftEnd);
			this.grpShift.Controls.Add(this.lblScheduledEnd);
			this.grpShift.Controls.Add(this.lblScheduledStart);
			this.grpShift.Controls.Add(this.lblShift);
			this.grpShift.Location = new System.Drawing.Point(344, 96);
			this.grpShift.Name = "grpShift";
			this.grpShift.Size = new System.Drawing.Size(248, 112);
			this.grpShift.TabIndex = 1;
			this.grpShift.TabStop = false;
			this.grpShift.Text = "Shift";
			// 
			// cboShifts
			// 
			this.cboShifts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboShifts.Location = new System.Drawing.Point(96, 24);
			this.cboShifts.Name = "cboShifts";
			this.cboShifts.Size = new System.Drawing.Size(136, 21);
			this.cboShifts.TabIndex = 16;
			this.cboShifts.SelectedIndexChanged += new System.EventHandler(this.cboShifts_SelectedIndexChanged);
			// 
			// txtShiftStart
			// 
			this.txtShiftStart.Location = new System.Drawing.Point(96, 56);
			this.txtShiftStart.Name = "txtShiftStart";
			this.txtShiftStart.ReadOnly = true;
			this.txtShiftStart.Size = new System.Drawing.Size(136, 20);
			this.txtShiftStart.TabIndex = 15;
			this.txtShiftStart.Text = "";
			// 
			// txtShiftEnd
			// 
			this.txtShiftEnd.Location = new System.Drawing.Point(96, 80);
			this.txtShiftEnd.Name = "txtShiftEnd";
			this.txtShiftEnd.ReadOnly = true;
			this.txtShiftEnd.Size = new System.Drawing.Size(136, 20);
			this.txtShiftEnd.TabIndex = 14;
			this.txtShiftEnd.Text = "";
			// 
			// lblScheduledEnd
			// 
			this.lblScheduledEnd.Location = new System.Drawing.Point(8, 80);
			this.lblScheduledEnd.Name = "lblScheduledEnd";
			this.lblScheduledEnd.Size = new System.Drawing.Size(88, 20);
			this.lblScheduledEnd.TabIndex = 13;
			this.lblScheduledEnd.Text = "Scheduled End:";
			this.lblScheduledEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblScheduledStart
			// 
			this.lblScheduledStart.Location = new System.Drawing.Point(8, 56);
			this.lblScheduledStart.Name = "lblScheduledStart";
			this.lblScheduledStart.Size = new System.Drawing.Size(88, 20);
			this.lblScheduledStart.TabIndex = 12;
			this.lblScheduledStart.Text = "Scheduled Start:";
			this.lblScheduledStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblShift
			// 
			this.lblShift.Location = new System.Drawing.Point(8, 24);
			this.lblShift.Name = "lblShift";
			this.lblShift.Size = new System.Drawing.Size(88, 20);
			this.lblShift.TabIndex = 11;
			this.lblShift.Text = "Shift:";
			this.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ganttCapacity
			// 
			this.ganttCapacity.AddMode = AGVBN20.Globals.E_ADDMODE.AT_GANTTITEMADD;
			this.ganttCapacity.AllowAdd = true;
			this.ganttCapacity.AllowEdit = true;
			this.ganttCapacity.AllowFixedColumnSize = true;
			this.ganttCapacity.AllowRowHeadingSize = true;
			this.ganttCapacity.AllowRowHeadingSwap = true;
			this.ganttCapacity.AllowRowSize = true;
			this.ganttCapacity.AllowRowSwap = true;
			this.ganttCapacity.AllowTimeLineScroll = true;
			this.ganttCapacity.AprilBackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
			this.ganttCapacity.AprilForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.AugustBackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
			this.ganttCapacity.AugustForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.AutomaticRedraw = true;
			this.ganttCapacity.BorderStyle = AGVBN20.Globals.E_BORDERSTYLE.TLB_3D;
			this.ganttCapacity.ButtonStyle = AGVBN20.Globals.GRE_BUTTONSTYLE.BT_NORMALWINDOWS;
			this.ganttCapacity.CurrentLayer = "0";
			this.ganttCapacity.CurrentView = "";
			this.ganttCapacity.DayFormat = "d ";
			this.ganttCapacity.DayFormatZoom0 = "dddd d";
			this.ganttCapacity.DayFormatZoom1 = "dddd d";
			this.ganttCapacity.DayFormatZoom2 = "dddd d";
			this.ganttCapacity.DayFormatZoom3 = "dddd d";
			this.ganttCapacity.DayFormatZoom4 = "dddd d";
			this.ganttCapacity.DayFormatZoom5 = "dddd d";
			this.ganttCapacity.DayFormatZoom6 = "dddd d";
			this.ganttCapacity.DayFormatZoom7 = "ddd d";
			this.ganttCapacity.DayFormatZoom8 = "ddd d";
			this.ganttCapacity.DayFormatZoom9 = "ddd d";
			this.ganttCapacity.DecemberBackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
			this.ganttCapacity.DecemberForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.DetectConflicts = true;
			this.ganttCapacity.DividerAppearance = AGVBN20.Globals.E_BORDERSTYLE.TLB_3D;
			this.ganttCapacity.EditMode = AGVBN20.Globals.E_EDITMODE.ET_GANTTMILESTONE;
			this.ganttCapacity.EnableObjects = AGVBN20.Globals.E_ENABLEOBJECTS.EO_CURRENTLAYERONLY;
			this.ganttCapacity.ErrorReports = AGVBN20.Globals.E_REPORTERRORS.RE_MSGBOX;
			this.ganttCapacity.FebruaryBackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.ganttCapacity.FebruaryForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.FirstVisibleRow = 1;
			this.ganttCapacity.FixedColumnWidth = 125;
			this.ganttCapacity.FridayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(95)), ((System.Byte)(109)), ((System.Byte)(231)));
			this.ganttCapacity.FridayForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.GridInterval = "15n";
			this.ganttCapacity.GridLinesColor = System.Drawing.SystemColors.Control;
			this.ganttCapacity.HorizontalGridLinesVisible = true;
			this.ganttCapacity.HorizontalScrollBarEnabled = false;
			this.ganttCapacity.HorizontalScrollBarFactor = 1;
			this.ganttCapacity.HorizontalScrollBarInterval = "n";
			this.ganttCapacity.HorizontalScrollBarLargeChange = 10;
			this.ganttCapacity.HorizontalScrollBarMax = 100;
			this.ganttCapacity.HorizontalScrollBarSmallChange = 1;
			this.ganttCapacity.HorizontalScrollBarStart = new System.DateTime(2005, 3, 17, 17, 36, 47, 125);
			this.ganttCapacity.HorizontalScrollBarValue = 0;
			this.ganttCapacity.JanuaryBackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.ganttCapacity.JanuaryForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.JulyBackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
			this.ganttCapacity.JulyForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.JuneBackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.ganttCapacity.JuneForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.Location = new System.Drawing.Point(8, 216);
			this.ganttCapacity.LowerStripeFactor = 0;
			this.ganttCapacity.LowerStripeFont = new System.Drawing.Font("Arial", 8F);
			this.ganttCapacity.LowerStripeHeight = 14;
			this.ganttCapacity.LowerStripeInterval = "";
			this.ganttCapacity.MarchBackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
			this.ganttCapacity.MarchForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.MayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.ganttCapacity.MayForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.MilestoneSelectionOffset = 5;
			this.ganttCapacity.MinRowHeadingWidth = 5;
			this.ganttCapacity.MinRowHeight = 5;
			this.ganttCapacity.MondayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(114)), ((System.Byte)(115)), ((System.Byte)(191)));
			this.ganttCapacity.MondayForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.MonthFormatZoom0 = "MMMM yyyy";
			this.ganttCapacity.MonthFormatZoom1 = "MMMM yyyy";
			this.ganttCapacity.MonthFormatZoom10 = "MMMM";
			this.ganttCapacity.MonthFormatZoom11 = "MMMM";
			this.ganttCapacity.MonthFormatZoom12 = "MMMM";
			this.ganttCapacity.MonthFormatZoom13 = "MMM";
			this.ganttCapacity.MonthFormatZoom14 = "MMM";
			this.ganttCapacity.MonthFormatZoom2 = "MMMM yyyy";
			this.ganttCapacity.MonthFormatZoom3 = "MMMM yyyy";
			this.ganttCapacity.MonthFormatZoom4 = "MMMM yyyy";
			this.ganttCapacity.MonthFormatZoom5 = "MMMM yyyy";
			this.ganttCapacity.MonthFormatZoom6 = "MMMM yyyy";
			this.ganttCapacity.MonthFormatZoom7 = "MMMM yyyy";
			this.ganttCapacity.MonthFormatZoom8 = "MMMM yyyy";
			this.ganttCapacity.MonthFormatZoom9 = "MMMM yyyy";
			this.ganttCapacity.Name = "ganttCapacity";
			this.ganttCapacity.NonContainerRowBackColor = System.Drawing.SystemColors.Control;
			this.ganttCapacity.NotchesAreaHeight = 33;
			this.ganttCapacity.NotchFont = new System.Drawing.Font("Arial", 8F);
			this.ganttCapacity.NotchTextOffset = 18;
			this.ganttCapacity.NovemberBackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
			this.ganttCapacity.NovemberForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.OctoberBackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.ganttCapacity.OctoberForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.Quarter1BackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.ganttCapacity.Quarter1ForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.Quarter2BackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.ganttCapacity.Quarter2ForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.Quarter3BackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
			this.ganttCapacity.Quarter3ForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.Quarter4BackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
			this.ganttCapacity.Quarter4ForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.QuarterFormatZoom10 = "\'Q\' yyyy";
			this.ganttCapacity.QuarterFormatZoom11 = "\'Q\' yyyy";
			this.ganttCapacity.QuarterFormatZoom12 = "\'Q\' yyyy";
			this.ganttCapacity.QuarterFormatZoom13 = "\'Q\' yyyy";
			this.ganttCapacity.QuarterFormatZoom14 = "\'Q\' yyyy";
			this.ganttCapacity.QuarterFormatZoom15 = "\'Q\'";
			this.ganttCapacity.RowHeadingWidth = 125;
			this.ganttCapacity.RowHeight = 40;
			this.ganttCapacity.SaturdayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(124)), ((System.Byte)(131)), ((System.Byte)(191)));
			this.ganttCapacity.SaturdayForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.ScrollBarBehaviour = AGVBN20.Globals.E_SCROLLBEHAVIOUR.SB_HIDE;
			this.ganttCapacity.ScrollBarsVisible = true;
			this.ganttCapacity.SelectedGanttItemIndex = 0;
			this.ganttCapacity.SelectedMilestoneIndex = 0;
			this.ganttCapacity.SelectedRowHeadingIndex = 0;
			this.ganttCapacity.SelectedRowIndex = 0;
			this.ganttCapacity.SelectedRowValueIndex = 0;
			this.ganttCapacity.SeptemberBackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.ganttCapacity.SeptemberForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.ShowLowerStripe = false;
			this.ganttCapacity.ShowTimeLineNotches = true;
			this.ganttCapacity.ShowUpperStripe = false;
			this.ganttCapacity.Size = new System.Drawing.Size(768, 204);
			this.ganttCapacity.SnapToGrid = false;
			this.ganttCapacity.SnapToGridWhenSelecting = false;
			this.ganttCapacity.SundayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(147)), ((System.Byte)(145)), ((System.Byte)(250)));
			this.ganttCapacity.SundayForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.TabIndex = 2;
			this.ganttCapacity.ThursdayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(64)), ((System.Byte)(164)));
			this.ganttCapacity.ThursdayForeColor = System.Drawing.Color.White;
			this.ganttCapacity.TimeBlockBehaviour = AGVBN20.Globals.E_TIMEBLOCKBEHAVIOUR.TBB_ROWEXTENTS;
			this.ganttCapacity.TimeFormat = "HH:mm";
			this.ganttCapacity.TimeLineAppearance = AGVBN20.Globals.E_BORDERSTYLE.TLB_3D;
			this.ganttCapacity.TimeLineBackColor = System.Drawing.SystemColors.Control;
			this.ganttCapacity.TimeLineForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.TimeLineMarkerColor = System.Drawing.Color.Red;
			this.ganttCapacity.TimeLineMarkerDate = new System.DateTime(2005, 3, 17, 17, 36, 47, 125);
			this.ganttCapacity.TimeLineMarkerLength = AGVBN20.Globals.E_TIMELINEMARKERLENGTH.TLMA_NOTCHAREA;
			this.ganttCapacity.TimeLineMarkerType = AGVBN20.Globals.E_TIMELINEMARKERTYPE.TLMT_SYSTEMTIME;
			this.ganttCapacity.TimeLineStyleIndex = "";
			this.ganttCapacity.ToolTipFormatZoom0To9 = "HH:mm";
			this.ganttCapacity.ToolTipFormatZoom10To15 = "M/d/yy h:mm tt";
			this.ganttCapacity.ToolTipsVisible = true;
			this.ganttCapacity.TrimTimeFormat = true;
			this.ganttCapacity.TuesdayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(80)), ((System.Byte)(140)));
			this.ganttCapacity.TuesdayForeColor = System.Drawing.Color.White;
			this.ganttCapacity.UpperStripeFactor = 0;
			this.ganttCapacity.UpperStripeFont = new System.Drawing.Font("Arial", 8F);
			this.ganttCapacity.UpperStripeHeight = 14;
			this.ganttCapacity.UpperStripeInterval = "";
			this.ganttCapacity.UseViews = false;
			this.ganttCapacity.VerticalGridLinesVisible = false;
			this.ganttCapacity.WednesdayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(104)), ((System.Byte)(109)), ((System.Byte)(152)));
			this.ganttCapacity.WednesdayForeColor = System.Drawing.Color.White;
			this.ganttCapacity.Year0BackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.ganttCapacity.Year0ForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.Year1BackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.ganttCapacity.Year1ForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.Year2BackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
			this.ganttCapacity.Year2ForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.Year3BackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
			this.ganttCapacity.Year3ForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.Year4BackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.ganttCapacity.Year4ForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.Year5BackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.ganttCapacity.Year5ForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.Year6BackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
			this.ganttCapacity.Year6ForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.Year7BackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
			this.ganttCapacity.Year7ForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.Year8BackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.ganttCapacity.Year8ForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.Year9BackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.ganttCapacity.Year9ForeColor = System.Drawing.Color.Black;
			this.ganttCapacity.YearFormatZoom15 = "yyyy";
			this.ganttCapacity.ZoomFactor = 5;
			this.ganttCapacity.GanttItemAdded += new AGVBN20.ActiveGanttVBNCtl.GanttItemAddedEventHandler(this.ganttCapacity_GanttItemAdded);
			this.ganttCapacity.GanttItemSelected += new AGVBN20.ActiveGanttVBNCtl.GanttItemSelectedEventHandler(this.ganttCapacity_GanttItemSelected);
			this.ganttCapacity.GanttItemChanged += new AGVBN20.ActiveGanttVBNCtl.GanttItemChangedEventHandler(this.ganttCapacity_GanttItemChanged);
			// 
			// btnPrevious
			// 
			this.btnPrevious.Enabled = false;
			this.btnPrevious.Location = new System.Drawing.Point(48, 424);
			this.btnPrevious.Name = "btnPrevious";
			this.btnPrevious.Size = new System.Drawing.Size(32, 23);
			this.btnPrevious.TabIndex = 56;
			this.btnPrevious.Text = "<";
			this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
			// 
			// btnFirst
			// 
			this.btnFirst.Enabled = false;
			this.btnFirst.Location = new System.Drawing.Point(16, 424);
			this.btnFirst.Name = "btnFirst";
			this.btnFirst.Size = new System.Drawing.Size(32, 23);
			this.btnFirst.TabIndex = 55;
			this.btnFirst.Text = "<<";
			this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
			// 
			// btnNext
			// 
			this.btnNext.Enabled = false;
			this.btnNext.Location = new System.Drawing.Point(80, 424);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(32, 23);
			this.btnNext.TabIndex = 57;
			this.btnNext.Text = ">";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnLast
			// 
			this.btnLast.Enabled = false;
			this.btnLast.Location = new System.Drawing.Point(112, 424);
			this.btnLast.Name = "btnLast";
			this.btnLast.Size = new System.Drawing.Size(32, 23);
			this.btnLast.TabIndex = 58;
			this.btnLast.Text = ">>";
			this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
			// 
			// lblYear
			// 
			this.lblYear.Location = new System.Drawing.Point(160, 426);
			this.lblYear.Name = "lblYear";
			this.lblYear.Size = new System.Drawing.Size(32, 20);
			this.lblYear.TabIndex = 59;
			this.lblYear.Text = "Year:";
			this.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nudYear
			// 
			this.nudYear.Location = new System.Drawing.Point(192, 426);
			this.nudYear.Maximum = new System.Decimal(new int[] {
																	2200,
																	0,
																	0,
																	0});
			this.nudYear.Minimum = new System.Decimal(new int[] {
																	1950,
																	0,
																	0,
																	0});
			this.nudYear.Name = "nudYear";
			this.nudYear.Size = new System.Drawing.Size(48, 20);
			this.nudYear.TabIndex = 60;
			this.nudYear.Value = new System.Decimal(new int[] {
																  2005,
																  0,
																  0,
																  0});
			this.nudYear.ValueChanged += new System.EventHandler(this.nudYear_ValueChanged);
			// 
			// btnCopy
			// 
			this.btnCopy.Location = new System.Drawing.Point(264, 424);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(48, 24);
			this.btnCopy.TabIndex = 61;
			this.btnCopy.Text = "Copy";
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			// 
			// btnPaste
			// 
			this.btnPaste.Enabled = false;
			this.btnPaste.Location = new System.Drawing.Point(312, 424);
			this.btnPaste.Name = "btnPaste";
			this.btnPaste.Size = new System.Drawing.Size(48, 24);
			this.btnPaste.TabIndex = 62;
			this.btnPaste.Text = "Paste";
			this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
			// 
			// btnImportShift
			// 
			this.btnImportShift.Location = new System.Drawing.Point(608, 424);
			this.btnImportShift.Name = "btnImportShift";
			this.btnImportShift.Size = new System.Drawing.Size(80, 24);
			this.btnImportShift.TabIndex = 63;
			this.btnImportShift.Text = "Import Shift";
			this.btnImportShift.Click += new System.EventHandler(this.btnImportShift_Click);
			// 
			// btnViewShift
			// 
			this.btnViewShift.Location = new System.Drawing.Point(696, 424);
			this.btnViewShift.Name = "btnViewShift";
			this.btnViewShift.Size = new System.Drawing.Size(80, 24);
			this.btnViewShift.TabIndex = 64;
			this.btnViewShift.Text = "View Shift";
			this.btnViewShift.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnViewShift_MouseUp);
			this.btnViewShift.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnViewShift_MouseDown);
			// 
			// ganttShift
			// 
			this.ganttShift.AddMode = AGVBN20.Globals.E_ADDMODE.AT_GANTTITEMADD;
			this.ganttShift.AllowAdd = true;
			this.ganttShift.AllowEdit = true;
			this.ganttShift.AllowFixedColumnSize = true;
			this.ganttShift.AllowRowHeadingSize = true;
			this.ganttShift.AllowRowHeadingSwap = true;
			this.ganttShift.AllowRowSize = true;
			this.ganttShift.AllowRowSwap = true;
			this.ganttShift.AllowTimeLineScroll = true;
			this.ganttShift.AprilBackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
			this.ganttShift.AprilForeColor = System.Drawing.Color.Black;
			this.ganttShift.AugustBackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
			this.ganttShift.AugustForeColor = System.Drawing.Color.Black;
			this.ganttShift.AutomaticRedraw = true;
			this.ganttShift.BorderStyle = AGVBN20.Globals.E_BORDERSTYLE.TLB_3D;
			this.ganttShift.ButtonStyle = AGVBN20.Globals.GRE_BUTTONSTYLE.BT_NORMALWINDOWS;
			this.ganttShift.CurrentLayer = "0";
			this.ganttShift.CurrentView = "";
			this.ganttShift.DayFormat = "d ";
			this.ganttShift.DayFormatZoom0 = "dddd d";
			this.ganttShift.DayFormatZoom1 = "dddd d";
			this.ganttShift.DayFormatZoom2 = "dddd d";
			this.ganttShift.DayFormatZoom3 = "dddd d";
			this.ganttShift.DayFormatZoom4 = "dddd d";
			this.ganttShift.DayFormatZoom5 = "dddd d";
			this.ganttShift.DayFormatZoom6 = "dddd d";
			this.ganttShift.DayFormatZoom7 = "ddd d";
			this.ganttShift.DayFormatZoom8 = "ddd d";
			this.ganttShift.DayFormatZoom9 = "ddd d";
			this.ganttShift.DecemberBackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
			this.ganttShift.DecemberForeColor = System.Drawing.Color.Black;
			this.ganttShift.DetectConflicts = true;
			this.ganttShift.DividerAppearance = AGVBN20.Globals.E_BORDERSTYLE.TLB_3D;
			this.ganttShift.EditMode = AGVBN20.Globals.E_EDITMODE.ET_GANTTMILESTONE;
			this.ganttShift.EnableObjects = AGVBN20.Globals.E_ENABLEOBJECTS.EO_CURRENTLAYERONLY;
			this.ganttShift.ErrorReports = AGVBN20.Globals.E_REPORTERRORS.RE_MSGBOX;
			this.ganttShift.FebruaryBackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.ganttShift.FebruaryForeColor = System.Drawing.Color.Black;
			this.ganttShift.FirstVisibleRow = 0;
			this.ganttShift.FixedColumnWidth = 0;
			this.ganttShift.FridayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(95)), ((System.Byte)(109)), ((System.Byte)(231)));
			this.ganttShift.FridayForeColor = System.Drawing.Color.Black;
			this.ganttShift.GridInterval = "15n";
			this.ganttShift.GridLinesColor = System.Drawing.SystemColors.Control;
			this.ganttShift.HorizontalGridLinesVisible = true;
			this.ganttShift.HorizontalScrollBarEnabled = false;
			this.ganttShift.HorizontalScrollBarFactor = 1;
			this.ganttShift.HorizontalScrollBarInterval = "n";
			this.ganttShift.HorizontalScrollBarLargeChange = 10;
			this.ganttShift.HorizontalScrollBarMax = 100;
			this.ganttShift.HorizontalScrollBarSmallChange = 1;
			this.ganttShift.HorizontalScrollBarStart = new System.DateTime(2005, 3, 17, 17, 36, 47, 125);
			this.ganttShift.HorizontalScrollBarValue = 0;
			this.ganttShift.JanuaryBackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.ganttShift.JanuaryForeColor = System.Drawing.Color.Black;
			this.ganttShift.JulyBackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
			this.ganttShift.JulyForeColor = System.Drawing.Color.Black;
			this.ganttShift.JuneBackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.ganttShift.JuneForeColor = System.Drawing.Color.Black;
			this.ganttShift.Location = new System.Drawing.Point(8, 216);
			this.ganttShift.LowerStripeFactor = 0;
			this.ganttShift.LowerStripeFont = new System.Drawing.Font("Arial", 8F);
			this.ganttShift.LowerStripeHeight = 14;
			this.ganttShift.LowerStripeInterval = "";
			this.ganttShift.MarchBackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
			this.ganttShift.MarchForeColor = System.Drawing.Color.Black;
			this.ganttShift.MayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.ganttShift.MayForeColor = System.Drawing.Color.Black;
			this.ganttShift.MilestoneSelectionOffset = 5;
			this.ganttShift.MinRowHeadingWidth = 5;
			this.ganttShift.MinRowHeight = 5;
			this.ganttShift.MondayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(114)), ((System.Byte)(115)), ((System.Byte)(191)));
			this.ganttShift.MondayForeColor = System.Drawing.Color.Black;
			this.ganttShift.MonthFormatZoom0 = "MMMM yyyy";
			this.ganttShift.MonthFormatZoom1 = "MMMM yyyy";
			this.ganttShift.MonthFormatZoom10 = "MMMM";
			this.ganttShift.MonthFormatZoom11 = "MMMM";
			this.ganttShift.MonthFormatZoom12 = "MMMM";
			this.ganttShift.MonthFormatZoom13 = "MMM";
			this.ganttShift.MonthFormatZoom14 = "MMM";
			this.ganttShift.MonthFormatZoom2 = "MMMM yyyy";
			this.ganttShift.MonthFormatZoom3 = "MMMM yyyy";
			this.ganttShift.MonthFormatZoom4 = "MMMM yyyy";
			this.ganttShift.MonthFormatZoom5 = "MMMM yyyy";
			this.ganttShift.MonthFormatZoom6 = "MMMM yyyy";
			this.ganttShift.MonthFormatZoom7 = "MMMM yyyy";
			this.ganttShift.MonthFormatZoom8 = "MMMM yyyy";
			this.ganttShift.MonthFormatZoom9 = "MMMM yyyy";
			this.ganttShift.Name = "ganttShift";
			this.ganttShift.NonContainerRowBackColor = System.Drawing.SystemColors.Control;
			this.ganttShift.NotchesAreaHeight = 33;
			this.ganttShift.NotchFont = new System.Drawing.Font("Arial", 8F);
			this.ganttShift.NotchTextOffset = 18;
			this.ganttShift.NovemberBackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
			this.ganttShift.NovemberForeColor = System.Drawing.Color.Black;
			this.ganttShift.OctoberBackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.ganttShift.OctoberForeColor = System.Drawing.Color.Black;
			this.ganttShift.Quarter1BackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.ganttShift.Quarter1ForeColor = System.Drawing.Color.Black;
			this.ganttShift.Quarter2BackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.ganttShift.Quarter2ForeColor = System.Drawing.Color.Black;
			this.ganttShift.Quarter3BackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
			this.ganttShift.Quarter3ForeColor = System.Drawing.Color.Black;
			this.ganttShift.Quarter4BackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
			this.ganttShift.Quarter4ForeColor = System.Drawing.Color.Black;
			this.ganttShift.QuarterFormatZoom10 = "\'Q\' yyyy";
			this.ganttShift.QuarterFormatZoom11 = "\'Q\' yyyy";
			this.ganttShift.QuarterFormatZoom12 = "\'Q\' yyyy";
			this.ganttShift.QuarterFormatZoom13 = "\'Q\' yyyy";
			this.ganttShift.QuarterFormatZoom14 = "\'Q\' yyyy";
			this.ganttShift.QuarterFormatZoom15 = "\'Q\'";
			this.ganttShift.RowHeadingWidth = 125;
			this.ganttShift.RowHeight = 40;
			this.ganttShift.SaturdayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(124)), ((System.Byte)(131)), ((System.Byte)(191)));
			this.ganttShift.SaturdayForeColor = System.Drawing.Color.Black;
			this.ganttShift.ScrollBarBehaviour = AGVBN20.Globals.E_SCROLLBEHAVIOUR.SB_HIDE;
			this.ganttShift.ScrollBarsVisible = true;
			this.ganttShift.SelectedGanttItemIndex = 0;
			this.ganttShift.SelectedMilestoneIndex = 0;
			this.ganttShift.SelectedRowHeadingIndex = 0;
			this.ganttShift.SelectedRowIndex = 0;
			this.ganttShift.SelectedRowValueIndex = 0;
			this.ganttShift.SeptemberBackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.ganttShift.SeptemberForeColor = System.Drawing.Color.Black;
			this.ganttShift.ShowLowerStripe = false;
			this.ganttShift.ShowTimeLineNotches = true;
			this.ganttShift.ShowUpperStripe = false;
			this.ganttShift.Size = new System.Drawing.Size(768, 204);
			this.ganttShift.SnapToGrid = false;
			this.ganttShift.SnapToGridWhenSelecting = true;
			this.ganttShift.SundayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(147)), ((System.Byte)(145)), ((System.Byte)(250)));
			this.ganttShift.SundayForeColor = System.Drawing.Color.Black;
			this.ganttShift.TabIndex = 65;
			this.ganttShift.ThursdayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(64)), ((System.Byte)(164)));
			this.ganttShift.ThursdayForeColor = System.Drawing.Color.White;
			this.ganttShift.TimeBlockBehaviour = AGVBN20.Globals.E_TIMEBLOCKBEHAVIOUR.TBB_ROWEXTENTS;
			this.ganttShift.TimeFormat = "HH:mm";
			this.ganttShift.TimeLineAppearance = AGVBN20.Globals.E_BORDERSTYLE.TLB_3D;
			this.ganttShift.TimeLineBackColor = System.Drawing.SystemColors.Control;
			this.ganttShift.TimeLineForeColor = System.Drawing.Color.Black;
			this.ganttShift.TimeLineMarkerColor = System.Drawing.Color.Red;
			this.ganttShift.TimeLineMarkerDate = new System.DateTime(2005, 3, 17, 17, 36, 47, 125);
			this.ganttShift.TimeLineMarkerLength = AGVBN20.Globals.E_TIMELINEMARKERLENGTH.TLMA_NOTCHAREA;
			this.ganttShift.TimeLineMarkerType = AGVBN20.Globals.E_TIMELINEMARKERTYPE.TLMT_SYSTEMTIME;
			this.ganttShift.TimeLineStyleIndex = "";
			this.ganttShift.ToolTipFormatZoom0To9 = "h:mm:ss tt";
			this.ganttShift.ToolTipFormatZoom10To15 = "M/d/yy h:mm tt";
			this.ganttShift.ToolTipsVisible = true;
			this.ganttShift.TrimTimeFormat = true;
			this.ganttShift.TuesdayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(80)), ((System.Byte)(140)));
			this.ganttShift.TuesdayForeColor = System.Drawing.Color.White;
			this.ganttShift.UpperStripeFactor = 0;
			this.ganttShift.UpperStripeFont = new System.Drawing.Font("Arial", 8F);
			this.ganttShift.UpperStripeHeight = 14;
			this.ganttShift.UpperStripeInterval = "";
			this.ganttShift.UseViews = false;
			this.ganttShift.VerticalGridLinesVisible = false;
			this.ganttShift.Visible = false;
			this.ganttShift.WednesdayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(104)), ((System.Byte)(109)), ((System.Byte)(152)));
			this.ganttShift.WednesdayForeColor = System.Drawing.Color.White;
			this.ganttShift.Year0BackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.ganttShift.Year0ForeColor = System.Drawing.Color.Black;
			this.ganttShift.Year1BackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.ganttShift.Year1ForeColor = System.Drawing.Color.Black;
			this.ganttShift.Year2BackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
			this.ganttShift.Year2ForeColor = System.Drawing.Color.Black;
			this.ganttShift.Year3BackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
			this.ganttShift.Year3ForeColor = System.Drawing.Color.Black;
			this.ganttShift.Year4BackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.ganttShift.Year4ForeColor = System.Drawing.Color.Black;
			this.ganttShift.Year5BackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.ganttShift.Year5ForeColor = System.Drawing.Color.Black;
			this.ganttShift.Year6BackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
			this.ganttShift.Year6ForeColor = System.Drawing.Color.Black;
			this.ganttShift.Year7BackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
			this.ganttShift.Year7ForeColor = System.Drawing.Color.Black;
			this.ganttShift.Year8BackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.ganttShift.Year8ForeColor = System.Drawing.Color.Black;
			this.ganttShift.Year9BackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.ganttShift.Year9ForeColor = System.Drawing.Color.Black;
			this.ganttShift.YearFormatZoom15 = "yyyy";
			this.ganttShift.ZoomFactor = 5;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(696, 504);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 24);
			this.btnCancel.TabIndex = 69;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(696, 472);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(80, 24);
			this.btnSave.TabIndex = 70;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// cover
			// 
			this.cover.Location = new System.Drawing.Point(10, 402);
			this.cover.Name = "cover";
			this.cover.Size = new System.Drawing.Size(100, 16);
			this.cover.TabIndex = 71;
			// 
			// btnClearWeek
			// 
			this.btnClearWeek.Location = new System.Drawing.Point(520, 424);
			this.btnClearWeek.Name = "btnClearWeek";
			this.btnClearWeek.Size = new System.Drawing.Size(80, 24);
			this.btnClearWeek.TabIndex = 72;
			this.btnClearWeek.Text = "Clear Week";
			this.btnClearWeek.Click += new System.EventHandler(this.btnClearWeek_Click);
			// 
			// FormABMCapacity
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CausesValidation = false;
			this.ClientSize = new System.Drawing.Size(786, 543);
			this.Controls.Add(this.btnClearWeek);
			this.Controls.Add(this.cover);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnViewShift);
			this.Controls.Add(this.btnImportShift);
			this.Controls.Add(this.btnPaste);
			this.Controls.Add(this.btnCopy);
			this.Controls.Add(this.nudYear);
			this.Controls.Add(this.lblYear);
			this.Controls.Add(this.btnPrevious);
			this.Controls.Add(this.btnFirst);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnLast);
			this.Controls.Add(this.ganttCapacity);
			this.Controls.Add(this.grpDetail);
			this.Controls.Add(this.grpDepartment);
			this.Controls.Add(this.grpShift);
			this.Controls.Add(this.grpVersion);
			this.Controls.Add(this.grpCapacity);
			this.Controls.Add(this.ganttShift);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormABMCapacity";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Machine Capacity";
			this.Load += new System.EventHandler(this.FormABMCapacity_Load);
			this.grpDepartment.ResumeLayout(false);
			this.grpDetail.ResumeLayout(false);
			this.grpCapacity.ResumeLayout(false);
			this.grpVersion.ResumeLayout(false);
			this.grpShift.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
			this.ResumeLayout(false);

		}		

		#endregion
	
		#region Constructors

		public FormABMCapacity(Machine machine)
		{
			this.machine = machine;
			this.coreFactory = UtilCoreFactory.createCoreFactory();
	
			InitializeComponent();
		}
	
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#endregion 

		#region Events

		private void FormABMCapacity_Load(object sender, System.EventArgs e)
		{
			this.LoadData();		
		}

		private void cboVersions_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			capacityVersion = (CapacityVersion)((ComboBoxItem)this.cboVersions.SelectedItem).Content;
			this.txtVersionStart.Text = DateUtil.getDateRepresentation(capacityVersion.getDtStart(),DateUtil.MMDDYYYY);
			this.txtVersionEnd.Text = DateUtil.getDateRepresentation(capacityVersion.getDtEnd(),DateUtil.MMDDYYYY);
			this.LoadCapacityGantt();
		}

		private void cboShifts_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ((shift == null) || (!shift.getShf().Equals(((Shift)((ComboBoxItem)this.cboShifts.SelectedItem).Content).getShf())))
			{
				shift = (Shift)((ComboBoxItem)this.cboShifts.SelectedItem).Content;
				this.txtShiftStart.Text = DateUtil.getDateRepresentation(shift.getStrPeriod(),DateUtil.MMDDYYYY);
				this.txtShiftEnd.Text = DateUtil.getDateRepresentation(shift.getEndPeriod(),DateUtil.MMDDYYYY);
				this.LoadShiftGantt();
				this.LoadCapacityGantt();
			}
		}

		private void btnViewShift_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.ganttShift.HorizontalScrollBarValue = this.ganttCapacity.HorizontalScrollBarValue;
			this.ganttShift.Visible = true;
			this.ganttCapacity.Visible = false;
		}

		private void btnViewShift_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.ganttCapacity.Visible = true;
			this.ganttShift.Visible = false;
		}

		private void btnFirst_Click(object sender, System.EventArgs e)
		{
			this.currentWeekPosition[0] = this.firstWeekPosition[0];
			this.currentWeekPosition[1] = this.firstWeekPosition[1];
			this.ShowCurrentWeek();
		}

		private void btnPrevious_Click(object sender, System.EventArgs e)
		{
			this.currentWeekPosition[0] -= 1;
			if (this.currentWeekPosition[0] == 0)
			{
				this.currentWeekPosition[1] -= 1;
				this.currentWeekPosition[0] = this.weekNumber (new DateTime(this.currentWeekPosition[1],12,31));
			}
			this.ShowCurrentWeek();
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			this.currentWeekPosition[0] += 1;
			if (this.currentWeekPosition[0] > this.weekNumber (new DateTime(this.currentWeekPosition[1],12,31)))
			{
				this.currentWeekPosition[1] += 1;
				this.currentWeekPosition[0] = 1;
			}
			this.ShowCurrentWeek();
		}

		private void btnLast_Click(object sender, System.EventArgs e)
		{
			this.currentWeekPosition[0] = this.lastWeekPosition[0];
			this.currentWeekPosition[1] = this.lastWeekPosition[1];
			this.ShowCurrentWeek();
		}

		private void nudYear_ValueChanged(object sender, System.EventArgs e)
		{
			this.currentWeekPosition[1] = (int)this.nudYear.Value;
			if ((this.currentWeekPosition[1] == this.firstWeekPosition[1]) && (this.currentWeekPosition[0] < this.firstWeekPosition[0]))
				this.currentWeekPosition[0] = this.firstWeekPosition[0];
			if ((this.currentWeekPosition[1] == this.lastWeekPosition[1]) && (this.currentWeekPosition[0] > this.lastWeekPosition[0]))
				this.currentWeekPosition[0] = this.lastWeekPosition[0];
			this.ShowCurrentWeek();
		}

		private void btnRecalculate_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show ("This feature is yet to be implemented.","Unavailable",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void btnDetailClear_Click(object sender, System.EventArgs e)
		{
			this.ClearDetailInfo();
		}

		private void tmeDetailTimeStart_ValueChanged(object sender, System.EventArgs e)
		{
			this.UpdateDetailsHours();
			if (this.detailChanging)
				impactCapacityHours();
		}

		private void tmeDetailTimeEnd_ValueChanged(object sender, System.EventArgs e)
		{
			this.UpdateDetailsHours();
			if (this.detailChanging)
				impactCapacityHours();
		}

		private void cboDetailDay_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.detailChanging)
				impactCapacityHours();
		}

		private void cboDetailType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.detailChanging)
				impactCapacityHours();
		}

		private void ganttCapacity_GanttItemSelected(int Index)
		{
			this.GanttItemSelected (Index);
		}

		private void btnDetailAddNew_Click(object sender, System.EventArgs e)
		{
			this.AddNewDetail();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			this.Save();		
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show ("Changes will be lost.\nContinue anyways?","Question",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				this.Close();
		}

		private void btnDetailDelete_Click(object sender, System.EventArgs e)
		{
			this.DeleteDetail();
		}

		private void ganttCapacity_GanttItemChanged(int Index, int ChangeType)
		{
			if (ChangeType == 2)
				this.tmeDetailTimeStart.Value = this.ganttCapacity.GanttItems.get_Item(Index.ToString()).StartDate;
			else if (ChangeType == 3)
				this.tmeDetailTimeEnd.Value = this.ganttCapacity.GanttItems.get_Item(Index.ToString()).EndDate;
			else if (ChangeType == 1)
			{
				DateTime startTime = this.ganttCapacity.GanttItems.get_Item(Index.ToString()).StartDate;
				DateTime endTime = this.ganttCapacity.GanttItems.get_Item(Index.ToString()).EndDate;
				this.detailChanging = false;
				this.tmeDetailTimeStart.Value = startTime;
				this.detailChanging = true;
				this.tmeDetailTimeEnd.Value = endTime;
			}
		}

		private void ganttCapacity_GanttItemAdded(int Index)
		{
			DateTime startTime = this.ganttCapacity.GanttItems.get_Item(Index.ToString()).StartDate;
			DateTime endTime = this.ganttCapacity.GanttItems.get_Item(Index.ToString()).EndDate;
			int day = int.Parse(this.ganttCapacity.GanttItems.get_Item(Index.ToString()).RowKey.Substring(3,1));
			this.ganttCapacity.GanttItems.Remove (Index.ToString());

			bool applyToAllWeek = this.chkApplyAllWeek.Checked;
			this.chkApplyAllWeek.Checked = false;
			int timeType = this.cboDetailType.SelectedIndex;
			this.ClearDetailInfo();

			this.cboDetailType.SelectedIndex = timeType;
			this.tmeDetailTimeStart.Value = startTime;
			this.tmeDetailTimeEnd.Value = endTime;
			this.cboDetailDay.SelectedIndex = day;
			this.AddNewDetail();

			this.chkApplyAllWeek.Checked = applyToAllWeek;
		}

		private void btnAddVersion_Click(object sender, System.EventArgs e)
		{
			NewVersion newVersion = new NewVersion(txtPlant.Text);
			newVersion.ShowDialog();
			LoadVersions();
		}

		private void btnCopy_Click(object sender, System.EventArgs e)
		{
			this.copiedWeek = capacity.getCapacityHoursOfWeekAsString (this.cboShifts.Text, this.currentWeekPosition[0], this.currentWeekPosition[1]);
			this.btnPaste.Enabled = true;
		}

		private void btnPaste_Click(object sender, System.EventArgs e)
		{
			this.InsertHours (this.copiedWeek, "The week couldn't be inserted as is.");
		}

		private void btnImportShift_Click(object sender, System.EventArgs e)
		{
			this.InsertHours(this.CreateHoursArrayFromShift(), "The shift couldn't be imported as is.");
		}

		private void btnClearWeek_Click(object sender, System.EventArgs e)
		{
			int leftItems = 1;
			while (this.ganttCapacity.GanttItems.Count > leftItems)
			{
				this.ganttCapacity.SelectedGanttItemIndex = leftItems + 1;
				int i = this.ganttCapacity.SelectedGanttItemIndex;
				this.GanttItemSelected (leftItems + 1);
				string styleKey = this.ganttCapacity.Styles.get_Item(this.ganttCapacity.GanttItems.get_Item(i.ToString()).StyleIndex).Key;
				if (!styleKey.Equals("_NotSched_") && !styleKey.Equals("_NA_"))
					this.DeleteDetail();
				else
					leftItems += 1;
			}
		}

		#endregion Events

		#region Methods

		private void LoadData()
		{
			if (this.machine == null ) 
				return;
	
			this.txtPlant.Text = this.machine.getPlt();
			this.txtDepartment.Text = this.machine.getDept();
			this.txtMachine.Text = this.machine.getMach();

			this.nudYear.Value = (Decimal)DateTime.Today.Year;

			this.InitializeGantts();

			this.LoadVersions();
			this.LoadShifts();

			this.LoadDays();
			this.LoadTimeCodes();

			//			SetStatus();
		}

		private void LoadVersions()
		{
			string[][] versions = coreFactory.getActiveCapacityVersions(machine.getPlt());

			for(int i = 0; i < versions.Length; i++)
			{
				CapacityVersion ver = coreFactory.createCapacityVersion();
				ver.setVersion (versions[i][0]);
				ver.setDtStart (DateUtil.parseDate(versions[i][2],DateUtil.MMDDYYYY));
				ver.setDtEnd (DateUtil.parseDate(versions[i][3],DateUtil.MMDDYYYY));

				ComboBoxItem cbItem = new ComboBoxItem (versions[i][0], ver);
				this.cboVersions.Items.Add (cbItem);
			}

			if (this.cboVersions.Items.Count > 0)
				this.cboVersions.SelectedIndex = 0;
		}
		
		private void LoadShifts()
		{
			if (this.machine == null) 
				return;

			ShiftContainer shifts = coreFactory.readShiftsByPltDept(machine.getPlt(), machine.getDept());

			for(int i = 0; i < shifts.Count; i++)
			{
				ComboBoxItem cbItem = new ComboBoxItem(((Shift)shifts[i]).getShf(),shifts[i]);
				this.cboShifts.Items.Add (cbItem);
			}

			if (this.cboVersions.Items.Count > 0)
				this.cboShifts.SelectedIndex = 0;
		}

		private void LoadDays()
		{
			for (int i=0; i<7; i++)
				this.cboDetailDay.Items.Add (Utils.NumberToDayOfWeek(i));
			this.cboDetailDay.SelectedIndex = 0;
		}

		private void LoadTimeCodes()
		{
			TimeCode[] timeCodes = TimeCodes.getInstance().getMachinesCodes();

			DataTable dt = new DataTable();
			dt.Columns.Add ("DisplayMember");
			dt.Columns.Add ("ValueMember");

			DataRow dr = null;

			for (int i=0; i<timeCodes.Length; i++)
			{
				dr = dt.NewRow();
				dr["DisplayMember"] = timeCodes[i].getDes();
				dr["ValueMember"]	= timeCodes[i].getTmType();
				dt.Rows.Add(dr);
			}

			this.cboDetailType.DataSource		= dt.DefaultView; 
			this.cboDetailType.DisplayMember	= "DisplayMember";
			this.cboDetailType.ValueMember	= "ValueMember";

			this.cboDetailType.SelectedIndex = 0;
		}

		private void InitializeGantts()
		{
			this.LoadGanttItemStyles();

			DateTime today   = DateTime.Today;
			DateTime dtStart = today;
			DateTime dtEnd   = today.AddDays(+1);

			this.ganttCapacity.NonContainerRowBackColor = System.Drawing.SystemColors.Window;
			this.ganttCapacity.BackColor = System.Drawing.SystemColors.Window;

			this.ganttCapacity.PositionTimeLine(dtStart);
			this.ganttCapacity.HorizontalScrollBarMax = 16;
			this.ganttCapacity.HorizontalScrollBarValue = 4;

			this.ganttCapacity.HorizontalScrollBarEnabled     = true;
			this.ganttCapacity.HorizontalScrollBarStart       = dtStart.AddMinutes (-25);
		
			this.ganttCapacity.HorizontalScrollBarFactor      = 2;
			this.ganttCapacity.HorizontalScrollBarInterval    = "h";
			this.ganttCapacity.HorizontalScrollBarLargeChange = 10;
        		

			this.ganttCapacity.AllowRowHeadingSwap  = false;
			this.ganttCapacity.AllowRowSwap         = false;
			this.ganttCapacity.AllowTimeLineScroll  = false;
			this.ganttCapacity.AllowDrop            = false;
			this.ganttCapacity.AllowAdd             = true;
			this.ganttCapacity.AllowEdit            = true;
			this.ganttCapacity.AllowFixedColumnSize = false;
			this.ganttCapacity.AllowRowSize         = false;

			this.tmeDetailTimeEnd.TimeStyle = NujitCustomWinControls.TimeCtrl.EnumTimeStyle.Hours24;

			this.ganttCapacity.RowHeadings.Add("Week # of #", 100, "0", "");

			this.ganttCapacity.Styles.Add("defaultStyleRowItem");

			this.ganttCapacity.Rows.Clear();
			this.ganttCapacity.GanttItems.Clear();

			this.ganttShift.NonContainerRowBackColor = System.Drawing.SystemColors.Window;
			this.ganttShift.BackColor = System.Drawing.SystemColors.Control;

			this.ganttShift.PositionTimeLine(dtStart);
			this.ganttShift.HorizontalScrollBarMax = 16;
			this.ganttShift.HorizontalScrollBarValue = 4;

			this.ganttShift.HorizontalScrollBarEnabled     = true;
			this.ganttShift.HorizontalScrollBarStart       = dtStart.AddMinutes (-25);
		
			this.ganttShift.HorizontalScrollBarFactor      = 2;
			this.ganttShift.HorizontalScrollBarInterval    = "h";
			this.ganttShift.HorizontalScrollBarLargeChange = 10;
        		

			this.ganttShift.AllowRowHeadingSwap  = false;
			this.ganttShift.AllowRowSwap         = false;
			this.ganttShift.AllowTimeLineScroll  = false;
			this.ganttShift.AllowDrop            = false;
			this.ganttShift.AllowAdd             = false;
			this.ganttShift.AllowEdit            = false;
			this.ganttShift.AllowFixedColumnSize = false;
			this.ganttShift.AllowRowSize         = false;

			this.ganttShift.RowHeadings.Add("SHIFTS", 100, "0", "");

			this.ganttShift.Styles.Add("defaultStyleRowItem");

			this.ganttShift.Rows.Clear();
			this.ganttShift.GanttItems.Clear();

			// Days headers

			clsStyle styleRow  = this.ganttCapacity.Styles.get_Item(this.ganttCapacity.Styles.Count.ToString());
			styleRow.ForeColor = System.Drawing.Color.Black;

			for (int i =0 ; i < 7 ; i++ )
			{	
				string rowKey =  "DAY" + i.ToString();
				string caption = "";
 
				caption = Nujit.NujitERP.ClassLib.Common.Utils.NumberToDayOfWeek(i);

				this.ganttCapacity.Rows.Add(rowKey , caption, true, true,  "defaultStyleRowItem", "");
				this.ganttShift.Rows.Add(rowKey , caption, true, true,  "defaultStyleRowItem", "");

				clsRow newRow = ganttCapacity.Rows.get_Item(rowKey);

				newRow.Height = 20;

				newRow = ganttShift.Rows.get_Item(rowKey);
				newRow.Height = 20;
			}	
		}		

		private void LoadGanttItemStyles()
		{
			// GANTT SHIFT STYLES

			TimeCode[] timeCodes = TimeCodes.getInstance().getLabourCodes();
			for (int i=0; i<timeCodes.Length; i++)
			{
				//Standard
				this.ganttShift.Styles.Add(Shift.SHIFT_TYPE_STANDARD + "-" + timeCodes[i].getTmType());
				clsStyle style  = this.ganttShift.Styles.get_Item(this.ganttShift.Styles.Count.ToString());

				Color col = TimeCodes.getInstance().getColor(timeCodes[i]);
				style.BackColor = col;
				style.CaptionAlignmentVertical = (AGVBN20.Globals.GRE_VERTICALALIGNMENT)1;
				style.CaptionYMargin = 4;
				style.Appearance = (AGVBN20.Globals.E_STYLEAPPEARANCE)2;
				style.BorderStyle = (AGVBN20.Globals.E_STYLEBORDER)1;
				style.BorderColor = System.Drawing.Color.Black;

				//Overtime
				this.ganttShift.Styles.Add(Shift.SHIFT_TYPE_OVER_TIME + "-" + timeCodes[i].getTmType());
				style  = this.ganttShift.Styles.get_Item(this.ganttShift.Styles.Count.ToString());

				style.Appearance = (AGVBN20.Globals.E_STYLEAPPEARANCE)2;
				style.BorderStyle = (AGVBN20.Globals.E_STYLEBORDER)1;
				style.BorderColor = System.Drawing.Color.Black;
				style.BackColor = col;

				style.UseMask = true;

				style.SelectionRectangleOffsetLeft = 20;
				style.CaptionPlacement = AGVBN20.Globals.E_CAPTIONPLACEMENT.SCP_OFFSETPLACEMENT;
				style.CaptionOffsetLeft = 20;
				style.CaptionOffsetTop = 4;

				style.PictureAlignmentHorizontal = AGVBN20.Globals.GRE_HORIZONTALALIGNMENT.HAL_LEFT;
				style.CaptionStringFormat.Alignment = System.Drawing.StringAlignment.Center;

				style.CaptionAlignmentVertical = (AGVBN20.Globals.GRE_VERTICALALIGNMENT)1;
				style.CaptionYMargin = 4;
			}

			// GANTT CAPACITY STYLES

			timeCodes = TimeCodes.getInstance().getMachinesCodes();
			for (int i=0; i<timeCodes.Length; i++)
			{
				//Standard
				this.ganttCapacity.Styles.Add(timeCodes[i].getTmType());
				clsStyle style  = this.ganttCapacity.Styles.get_Item(this.ganttCapacity.Styles.Count.ToString());

				Color col = TimeCodes.getInstance().getColor(timeCodes[i]);
				style.BackColor = col;
				style.CaptionAlignmentVertical = (AGVBN20.Globals.GRE_VERTICALALIGNMENT)1;
				style.CaptionYMargin = 4;
				style.Appearance = (AGVBN20.Globals.E_STYLEAPPEARANCE)2;
				style.BorderStyle = (AGVBN20.Globals.E_STYLEBORDER)1;
				style.BorderColor = System.Drawing.Color.Black;
			}

			//Not scheduled
			this.ganttCapacity.Styles.Add("_NotSched_");
			clsStyle emptyStyle  = this.ganttCapacity.Styles.get_Item(this.ganttCapacity.Styles.Count.ToString());

			emptyStyle.BackColor = Color.FromArgb(241,237,212);
			emptyStyle.Appearance = (AGVBN20.Globals.E_STYLEAPPEARANCE)1;
			emptyStyle.SelectionRectangleVisible = false;

			//Unavailable
			this.ganttCapacity.Styles.Add("_NA_");
			emptyStyle  = this.ganttCapacity.Styles.get_Item(this.ganttCapacity.Styles.Count.ToString());

			emptyStyle.BackColor = System.Drawing.SystemColors.Control;
			emptyStyle.Appearance = AGVBN20.Globals.E_STYLEAPPEARANCE.SA_FLAT;
			emptyStyle.SelectionRectangleVisible = false;

		}

		private void LoadShiftGantt()
		{
			this.ganttShift.GanttItems.Clear();
			for (int i=0; i<7; i++)
			{
				string[][] detail = shift.getDaysDetail (i);
				for (int j=0; j<detail.Length; j++)
				{
					int hours = int.Parse(detail[j][7].Substring(0,2));
					int minutes = int.Parse(detail[j][7].Substring(3,2));
					DateTime startTime = DateTime.Today.AddHours (hours).AddMinutes(minutes);

					hours = int.Parse(detail[j][8].Substring(0,2));
					minutes = int.Parse(detail[j][8].Substring(3,2));
					DateTime endTime = DateTime.Today.AddHours (hours).AddMinutes(minutes);

					string appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
					if (appPath.EndsWith("\\bin\\Debug"))
						appPath = appPath.Substring(0,appPath.Length-10) + "\\Images";
					else if (appPath.EndsWith("\\bin\\Release"))
						appPath = appPath.Substring(0,appPath.Length-12) + "\\Images";
					else
						appPath = appPath;

					if (detail[j][10].Equals (Shift.SHIFT_TYPE_OVER_TIME))
						this.ganttShift.GanttItems.Add (TimeCodes.getInstance().getTimeCode(detail[j][5]).getDes(), "DAY" + i.ToString(), startTime, endTime, i.ToString() + "-" + detail[j][7] + "-" + detail[j][8], detail[j][10] + "-" + detail[j][5], appPath + "\\Exclamation.bmp", "0");
					else
						this.ganttShift.GanttItems.Add (TimeCodes.getInstance().getTimeCode(detail[j][5]).getDes(), "DAY" + i.ToString(), startTime, endTime, i.ToString() + "-" + detail[j][7] + "-" + detail[j][8], detail[j][10] + "-" + detail[j][5], "", "0");
				}
			}
		}

		private void LoadCapacityGantt()
		{
			if ((this.cboVersions.SelectedIndex < 0) || (this.cboShifts.SelectedIndex < 0) || (this.txtPlant.Text.Length <= 0) || (this.txtDepartment.Text.Length <= 0) || (this.txtMachine.Text.Length <= 0))
				return;

			LoadCapacity();
		}

		private void LoadUnscheduledShiftOnCapacityGantt()
		{
			DateTime currentDay = this.getSundayOfCurrentWeek();
			this.shiftBounds = new string[7][][];
			for (int i=0; i<7; i++)
			{
				string[][] detail = shift.getDaysDetail (i);
				this.sortDetails(detail);
				ArrayList list = new ArrayList();
				if (currentDay.Year == (int)this.nudYear.Value)
				{
					for (int j=0; j<detail.Length-1; j++)
					{
						if (detail[j][8].CompareTo(detail[j+1][7]) < 0)
						{
							int hours = int.Parse(detail[j][8].Substring(0,2));
							int minutes = int.Parse(detail[j][8].Substring(3,2));
							DateTime startTime = DateTime.Today.AddHours (hours).AddMinutes(minutes);

							hours = int.Parse(detail[j+1][7].Substring(0,2));
							minutes = int.Parse(detail[j+1][7].Substring(3,2));
							DateTime endTime = DateTime.Today.AddHours (hours).AddMinutes(minutes);

							string[] item1 = {detail[j][8],detail[j+1][7]};
							list.Add (item1);

							this.ganttCapacity.GanttItems.Add ("","DAY" + i.ToString(),startTime,endTime,"EMPTY" + i.ToString() + j.ToString(),"_NotSched_","","0");
							clsGanttItem item = this.ganttCapacity.GanttItems.get_Item("EMPTY" + i.ToString() + j.ToString());
							item.AllowedMovement = (AGVBN20.Globals.E_MOVEMENTTYPE)1;
							item.AllowStretchLeft = false;
							item.AllowStretchRight = false;
							item.AllowedMovement = AGVBN20.Globals.E_MOVEMENTTYPE.MT_MOVEMENTDISABLED;
						}
					}
					if (detail.Length <= 0)
					{
						this.ganttCapacity.GanttItems.Add ("","DAY" + i.ToString(),DateTime.Today.AddHours(-1),DateTime.Today.AddHours(25),"EMPTY" + i.ToString(),"_NotSched_","","0");
						clsGanttItem item = this.ganttCapacity.GanttItems.get_Item("EMPTY" + i.ToString());
						item.AllowStretchLeft = false;
						item.AllowStretchRight = false;
						item.AllowedMovement = AGVBN20.Globals.E_MOVEMENTTYPE.MT_MOVEMENTDISABLED;
						string[] item1 = {"00:00","23:59"};
						list.Add (item1);
					}
					else
					{
						int hours = int.Parse(detail[detail.Length-1][8].Substring(0,2));
						int minutes = int.Parse(detail[detail.Length-1][8].Substring(3,2));
						DateTime startTime = DateTime.Today.AddHours (hours).AddMinutes(minutes);

						hours = int.Parse(detail[0][7].Substring(0,2));
						minutes = int.Parse(detail[0][7].Substring(3,2));
						DateTime endTime = DateTime.Today.AddHours (hours).AddMinutes(minutes);

						string[] item1 = {"00:00",detail[0][7]};
						string[] item2 = {detail[detail.Length-1][8],"23:59"};

						list.Add (item1);
						list.Add (item2);

						this.ganttCapacity.GanttItems.Add ("","DAY" + i.ToString(),DateTime.Today.AddHours(-1),endTime,"EMPTY" + i.ToString() + "1st","_NotSched_","","0");
						clsGanttItem item = this.ganttCapacity.GanttItems.get_Item("EMPTY" + i.ToString() + "1st");
						item.AllowStretchLeft = false;
						item.AllowStretchRight = false;
						item.AllowedMovement = AGVBN20.Globals.E_MOVEMENTTYPE.MT_MOVEMENTDISABLED;
						
						this.ganttCapacity.GanttItems.Add ("","DAY" + i.ToString(),startTime,DateTime.Today.AddHours(25),"EMPTY" + i.ToString() + "Last","_NotSched_","","0");
						item = this.ganttCapacity.GanttItems.get_Item("EMPTY" + i.ToString() + "Last");
						item.AllowStretchLeft = false;
						item.AllowStretchRight = false;
						item.AllowedMovement = AGVBN20.Globals.E_MOVEMENTTYPE.MT_MOVEMENTDISABLED;
					}
				}
				else
				{
					this.ganttCapacity.GanttItems.Add ("","DAY" + i.ToString(),DateTime.Today.AddHours(-1),DateTime.Today.AddHours(25),"EMPTY" + i.ToString(),"_NA_","","0");
					clsGanttItem item = this.ganttCapacity.GanttItems.get_Item("EMPTY" + i.ToString());
					item.AllowStretchLeft = false;
					item.AllowStretchRight = false;
					item.AllowedMovement = AGVBN20.Globals.E_MOVEMENTTYPE.MT_MOVEMENTDISABLED;
				}
				this.shiftBounds[i] = new string[list.Count][];
				for (int x=0; x<list.Count; x++)
					this.shiftBounds[i][x] = (string[])list[x];
				currentDay = currentDay.AddDays(1);
			}
		}

		private void sortDetails (string[][] detail)
		{
			for (int i = 0; i < detail.Length; i++)
			{
				for (int j=1; j < (detail.Length - i); j++)
				{
					if (detail[j-1][7].CompareTo(detail[j][7]) > 0)
					{
						string[] aux = detail[j-1];
						detail[j-1] = detail[j];
						detail[j] = aux;
					}
				}
			}
		}

		private void LoadCapacity ()
		{
			if ((this.capacity == null) || (!this.capacity.getVersion().Equals(this.cboVersions.Text)))
				this.capacity = this.coreFactory.readCapacity (this.cboVersions.Text, this.txtPlant.Text, this.txtDepartment.Text, this.txtMachine.Text);
			string[][] capacityHrs = capacity.getCapacityHoursAsString (cboShifts.Text);
			this.lastWeekPosition[1] = 0;
			this.firstWeekPosition[1] = int.MaxValue;
			for (int i=0; i < capacityHrs.Length; i++)
			{
				int year = int.Parse(capacityHrs[i][1].Substring(6,4));
				if ((year > this.lastWeekPosition[1]) || ((year == this.lastWeekPosition[1]) && (int.Parse(capacityHrs[i][0]) > this.lastWeekPosition[0])))
				{
					lastWeekPosition[0] = int.Parse(capacityHrs[i][0]);
					lastWeekPosition[1] = year;
				}
				if ((year < this.firstWeekPosition[1]) || ((year == this.firstWeekPosition[1]) && (int.Parse(capacityHrs[i][0]) < this.firstWeekPosition[0])))
				{
					firstWeekPosition[0] = int.Parse(capacityHrs[i][0]);
					firstWeekPosition[1] = year;
				}
			}
			if (this.lastWeekPosition[1] == 0)
			{
				this.lastWeekPosition[0] = this.weekNumber (DateTime.Today);
				this.lastWeekPosition[1] = DateTime.Today.Year;
			}
			if (this.firstWeekPosition[1] == int.MaxValue)
			{
				this.firstWeekPosition[0] = this.weekNumber (DateTime.Today);
				this.firstWeekPosition[1] = DateTime.Today.Year;
			}
			this.currentWeekPosition[0] = this.lastWeekPosition[0];
			this.currentWeekPosition[1] = this.lastWeekPosition[1];

			ShowCurrentWeek();
		}

		private int weekNumber (DateTime dateTime)
		{
			CultureInfo myCI = new CultureInfo("en-US");
			Calendar myCal = myCI.Calendar;
			CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
			return myCal.GetWeekOfYear(dateTime, myCWR, myCI.DateTimeFormat.FirstDayOfWeek);
		}

		private DateTime getSundayOfCurrentWeek ()
		{
			DateTime sunday = new DateTime ((int)this.nudYear.Value,1,2);
			while (!sunday.DayOfWeek.Equals(DayOfWeek.Sunday))
				sunday = sunday.AddDays(1);
			return sunday.AddDays((this.currentWeekPosition[0] - 2) * 7);
		}

		private void ShowCurrentWeek ()
		{
			this.updateWeekNavigationButtons();
			this.ganttCapacity.RowHeadings.get_Item(this.ganttCapacity.RowHeadings.Count).Caption = "Week " + this.currentWeekPosition[0].ToString();

			DateTime currentDay = this.getSundayOfCurrentWeek();

			for (int i=0; i<7; i++)
			{
				clsRow row = this.ganttCapacity.Rows.get_Item ("DAY" + i.ToString());
				row.Caption = Utils.NumberToDayOfWeek(i).Substring(0,3) + ". (" + currentDay.Month.ToString("00") + "." + currentDay.Day.ToString("00") + ")";
				currentDay = currentDay.AddDays(1);
			}
			this.ganttCapacity.GanttItems.Clear();
			this.ClearDetailInfo();

			this.ganttCapacity.GanttItems.Add ("","DAY0",DateTime.Today.AddMonths(-1),DateTime.Today.AddMonths(-1).AddMinutes(1),"NULL","0","","0");
			this.LoadUnscheduledShiftOnCapacityGantt();

			string[][] capacityHrs = capacity.getCapacityHoursOfWeekAsString (this.cboShifts.Text, this.currentWeekPosition[0], this.currentWeekPosition[1]);
			for (int i=0; i<capacityHrs.Length; i++)
			{
				string caption = TimeCodes.getInstance().getTimeCode(capacityHrs[i][3]).getDes();
				DateTime day = DateUtil.parseDate(capacityHrs[i][1],DateUtil.MMDDYYYY);
				string rowKey = "DAY" + Utils.DayOfWeekToNumber(day.DayOfWeek.ToString()).ToString();
				DateTime timeStart = DateTime.Today.AddHours(int.Parse(capacityHrs[i][5].Substring(0,2))).AddMinutes(int.Parse(capacityHrs[i][5].Substring(3,2)));
				DateTime timeEnd = DateTime.Today.AddHours(int.Parse(capacityHrs[i][6].Substring(0,2))).AddMinutes(int.Parse(capacityHrs[i][6].Substring(3,2)));
				string key = Utils.DayOfWeekToNumber(day.DayOfWeek.ToString()).ToString() + "-" + capacityHrs[i][5] + "-" + capacityHrs[i][6];

				this.ganttCapacity.GanttItems.Add(caption, rowKey, timeStart, timeEnd, key, capacityHrs[i][3], "", "0");

				clsGanttItem item = this.ganttCapacity.GanttItems.get_Item (key);
				item.AllowedMovement = (AGVBN20.Globals.E_MOVEMENTTYPE)1;
			}

			this.ganttCapacity.Refresh();
		}

		private void updateWeekNavigationButtons()
		{
			this.btnLast.Enabled = !(((this.currentWeekPosition[1] == this.lastWeekPosition[1]) && (this.currentWeekPosition[0] >= this.lastWeekPosition[0])) || (this.currentWeekPosition[1] > this.lastWeekPosition[1]));
			this.btnNext.Enabled = true;
			this.btnFirst.Enabled = !((this.currentWeekPosition[1] == this.firstWeekPosition[1]) && (this.currentWeekPosition[0] == this.firstWeekPosition[0]));
			this.btnPrevious.Enabled = this.btnFirst.Enabled;
			this.nudYear.Maximum = (decimal)this.lastWeekPosition[1];
			this.nudYear.Minimum = (decimal)this.firstWeekPosition[1];
			this.nudYear.Value = (decimal)this.currentWeekPosition[1];
		}

		private void ClearDetailInfo()
		{
			this.detailChanging = false;
			this.tmeDetailTimeStart.Value = DateTime.Today;
			this.tmeDetailTimeEnd.Value = DateTime.Today;
			this.ganttCapacity.SelectedGanttItemIndex = 1;
			this.btnDetailAddNew.Enabled = true;
			this.btnDetailDelete.Enabled = false;
			this.cboDetailDay.Enabled = true;

			this.ganttCapacity.Refresh();
		}

		private void UpdateDetailsHours ()
		{
			decimal totalHours = this.tmeDetailTimeEnd.Value.Hour - this.tmeDetailTimeStart.Value.Hour;
			totalHours += (this.tmeDetailTimeEnd.Value.Minute - this.tmeDetailTimeStart.Value.Minute) / 60M;
			this.numtxtDetailHours.Value = totalHours;
		}

		private void GanttItemSelected(int index)
		{
			clsGanttItem item = this.ganttCapacity.GanttItems.get_Item(index.ToString());
			clsStyle style = this.ganttCapacity.Styles.get_Item(item.StyleIndex);
			if (!style.Key.Equals("_NotSched_") && !style.Key.Equals("_NA_"))
			{
				string[] selectedDetail = this.capacity.getOneCapacityHourAsString(this.cboShifts.Text, this.getSundayOfCurrentWeek().AddDays(int.Parse(item.Key.Substring(0,1))), item.Key.Substring(2,5));
				this.currentDetail = new string[selectedDetail.Length];
				for (int i = 0; i < selectedDetail.Length; i++)
					this.currentDetail[i] = selectedDetail[i];
				this.CurrentDetailToScreen();
			}
		}

		private void CurrentDetailToScreen()
		{
			this.detailChanging = false;
			this.cboDetailDay.SelectedIndex = Utils.DayOfWeekToNumber(DateUtil.parseDate(this.currentDetail[1],DateUtil.MMDDYYYY).DayOfWeek.ToString());
			this.cboDetailType.SelectedValue = this.currentDetail[3];
			this.tmeDetailTimeStart.Value = DateTime.Today.AddHours(int.Parse(this.currentDetail[5].Substring(0,2))).AddMinutes(int.Parse(this.currentDetail[5].Substring(3,2)));
			this.tmeDetailTimeEnd.Value = DateTime.Today.AddHours(int.Parse(this.currentDetail[6].Substring(0,2))).AddMinutes(int.Parse(this.currentDetail[6].Substring(3,2)));

			this.detailChanging = true;
			this.btnDetailAddNew.Enabled = false;
			this.btnDetailDelete.Enabled = true;
			this.cboDetailDay.Enabled = false;
		}

		private bool ValidateDetail(bool alreadyExists, bool allWeek)
		{
			if (this.tmeDetailTimeStart.toString(TimeCtrl.HHMM24).CompareTo(this.tmeDetailTimeEnd.toString(TimeCtrl.HHMM24)) >= 0)
			{
				MessageBox.Show ("The ending time must be after the starting time.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			string[][] details = null;
			if (allWeek)
				details = capacity.getCapacityHoursOfWeekAsString (this.cboShifts.Text, this.currentWeekPosition[0], this.currentWeekPosition[1]);
			else
				details = capacity.getCapacityHoursOfDayAsString (this.cboShifts.Text, this.getSundayOfCurrentWeek().AddDays(this.cboDetailDay.SelectedIndex));
			string strStartTime = this.tmeDetailTimeStart.toString(TimeCtrl.HHMM24);
			string strEndTime = this.tmeDetailTimeEnd.toString(TimeCtrl.HHMM24);
			for (int i=0; i<details.Length; i++)
			{
				if (!alreadyExists || !details[i][5].Equals(currentDetail[5]))
				{
					bool good = false;
					if ((details[i][5].CompareTo (strStartTime) <= 0) && (details[i][6].CompareTo (strStartTime) <= 0))
						good = true;
					if ((details[i][5].CompareTo (strEndTime) >= 0) && (details[i][6].CompareTo (strEndTime) >= 0))
						good = true;
					if (!good)
					{
						MessageBox.Show ("This detail is in conflict with another detail of the same day","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
						return false;
					}
				}
			}
			bool hasConflicts = false;
			if (allWeek)
			{
				for (int i=1; i<6; i++)
					if (!hasConflicts)
						hasConflicts = this.HasConflictWithOtherShitfsCapacity(strStartTime, strEndTime, this.getSundayOfCurrentWeek().AddDays(i));
			}
			else
				hasConflicts = this.HasConflictWithOtherShitfsCapacity(strStartTime, strEndTime, this.getSundayOfCurrentWeek().AddDays(this.cboDetailDay.SelectedIndex));

			if (hasConflicts)
			{
				MessageBox.Show ("This detail is in conflict with a capacity detail of another shift.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}

			return this.CheckDetailInShiftsBounds(allWeek);
		}

		private bool CheckDetailInShiftsBounds(bool allWeek)
		{
			int times = allWeek ? 5 : 1;
			int index = allWeek ? 1 : this.cboDetailDay.SelectedIndex;
			bool noConflict = true;
			string strTimeStart = this.tmeDetailTimeStart.toString(TimeCtrl.HHMM24);
			string strTimeEnd = this.tmeDetailTimeEnd.toString(TimeCtrl.HHMM24);
			for (int i=0; (i<times) && noConflict; i++)
			{
				for (int j=0; (j<this.shiftBounds[i].Length) && noConflict; j++)
				{
					if ((strTimeStart.CompareTo(this.shiftBounds[index][j][0]) >= 0) && (strTimeStart.CompareTo(this.shiftBounds[index][j][1]) >= 0))
						noConflict = true;
					else if ((strTimeEnd.CompareTo(this.shiftBounds[index][j][0]) <= 0) && (strTimeEnd.CompareTo(this.shiftBounds[index][j][1]) <= 0))
						noConflict = true;
					else
						noConflict = false;
				}
				index++;
			}
			if (!noConflict)
				MessageBox.Show ("This detail is out of the shift's bounds","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			return noConflict;
		}

		private void AddNewDetail()
		{
			if (this.ValidateDetail(false, this.chkApplyAllWeek.Checked))
			{
				string strStartTime = this.tmeDetailTimeStart.toString(TimeCtrl.HHMM24);
				int hours = int.Parse(strStartTime.Substring(0,2));
				int minutes = int.Parse(strStartTime.Substring(3,2));
				DateTime startTime = DateTime.Today.AddHours (hours).AddMinutes(minutes);
		
				string strEndTime = this.tmeDetailTimeEnd.toString(TimeCtrl.HHMM24);
				hours = int.Parse(strEndTime.Substring(0,2));
				minutes = int.Parse(strEndTime.Substring(3,2));
				DateTime endTime = DateTime.Today.AddHours (hours).AddMinutes(minutes);
				TimeCode timeCode = TimeCodes.getInstance().getTimeCode(this.cboDetailType.SelectedValue.ToString());
				decimal utilPer = TimeCodes.getInstance().getMachineProductionHoursPorcentage(timeCode, this.txtPlant.Text, this.txtDepartment.Text, this.txtMachine.Text);
				decimal hrPr = this.numtxtDetailHours.Value * (utilPer / 100);

				if (this.chkApplyAllWeek.Checked)
				{
					for (int i=1; i<=5; i++)
					{
						this.ganttCapacity.GanttItems.Add (timeCode.getDes(), "DAY" + i.ToString(), startTime, endTime, i.ToString() + "-" + strStartTime + "-" + strEndTime, this.cboDetailType.SelectedValue.ToString(), "", "0");
						clsGanttItem item = this.ganttCapacity.GanttItems.get_Item (i.ToString() + "-" + strStartTime + "-" + strEndTime);
						item.AllowedMovement = (AGVBN20.Globals.E_MOVEMENTTYPE)1;

						capacity.addCapacityHour(this.currentWeekPosition[0], this.getSundayOfCurrentWeek().AddDays(i),
							this.cboShifts.Text, this.cboDetailType.SelectedValue.ToString(), 0, strStartTime, strEndTime,
							this.numtxtDetailHours.Value, hrPr, DateUtil.MinValue, "", "", utilPer, 0M, 0M, "");

						this.ClearDetailInfo();
					}
				}
				else
				{
					this.ganttCapacity.GanttItems.Add (timeCode.getDes(), "DAY" + this.cboDetailDay.SelectedIndex.ToString(), startTime, endTime, this.cboDetailDay.SelectedIndex.ToString() + "-" + strStartTime + "-" + strEndTime, this.cboDetailType.SelectedValue.ToString(), "", "0");
					clsGanttItem item = this.ganttCapacity.GanttItems.get_Item (this.cboDetailDay.SelectedIndex.ToString() + "-" + strStartTime + "-" + strEndTime);
					item.AllowedMovement = (AGVBN20.Globals.E_MOVEMENTTYPE)1;

					capacity.addCapacityHour(this.currentWeekPosition[0], this.getSundayOfCurrentWeek().AddDays(this.cboDetailDay.SelectedIndex),
						this.cboShifts.Text, this.cboDetailType.SelectedValue.ToString(), 0, strStartTime, strEndTime,
						this.numtxtDetailHours.Value, hrPr, DateUtil.MinValue, "", "", utilPer, 0M, 0M, "");

					this.ganttCapacity.SelectedGanttItemIndex = item.Index;
					this.GanttItemSelected(item.Index);
				}
			}
		}

		private void impactCapacityHours()
		{
			string strTimeStart = this.tmeDetailTimeStart.Value.Hour.ToString("00") + ":" + this.tmeDetailTimeStart.Value.Minute.ToString("00");
			string strTimeEnd = this.tmeDetailTimeEnd.Value.Hour.ToString("00") + ":" + this.tmeDetailTimeEnd.Value.Minute.ToString("00");
			if (!strTimeStart.Equals(this.currentDetail[5]) || !strTimeEnd.Equals(this.currentDetail[6]))
				if (!this.ValidateDetail(true, false))
				{
					this.CurrentDetailToScreen();
					return;
				}
			clsGanttItem item = this.ganttCapacity.GanttItems.get_Item(this.ganttCapacity.SelectedGanttItemIndex.ToString());
			item.StartDate = this.tmeDetailTimeStart.Value;
			item.EndDate = this.tmeDetailTimeEnd.Value;
			item.StyleIndex = this.cboDetailType.SelectedValue.ToString();
			item.Caption = this.cboDetailType.Text;
			item.Key = item.Key.Substring(0,1) + "-" + strTimeStart + "-" + strTimeEnd;

			this.ganttCapacity.Refresh();

			this.capacity.removeCapacityHour (this.cboShifts.Text, DateUtil.parseDate (currentDetail[1],DateUtil.MMDDYYYY), this.currentDetail[3], this.currentDetail[5], this.currentDetail[6]);
			
			TimeCode timeCode = TimeCodes.getInstance().getTimeCode (this.cboDetailType.SelectedValue.ToString());
			decimal utilPer = TimeCodes.getInstance().getMachineProductionHoursPorcentage(timeCode, this.txtPlant.Text, this.txtDepartment.Text, this.txtMachine.Text);
			decimal hrPr = this.numtxtDetailHours.Value * (utilPer / 100);
			this.currentDetail[3] = timeCode.getTmType();
			this.currentDetail[5] = strTimeStart;
			this.currentDetail[6] = strTimeEnd;
			this.currentDetail[7] = NumberUtil.toString(this.numtxtDetailHours.Value);
			this.currentDetail[8] = NumberUtil.toString(hrPr);

			this.capacity.addCapacityHour (int.Parse(this.currentDetail[0]), DateUtil.parseDate(this.currentDetail[1],DateUtil.MMDDYYYY), this.currentDetail[2], this.currentDetail[3], int.Parse(this.currentDetail[4]),
				this.currentDetail[5], this.currentDetail[6], this.numtxtDetailHours.Value, hrPr, DateUtil.parseDate(this.currentDetail[9],DateUtil.MMDDYYYY),
				this.currentDetail[10], this.currentDetail[11], utilPer, decimal.Parse(this.currentDetail[13]), decimal.Parse(this.currentDetail[14]), this.currentDetail[15]);
		}

		private void Save()
		{
			if (true)
			{
				if (this.coreFactory.existsCapacity(this.cboVersions.Text, this.txtPlant.Text, this.txtDepartment.Text, this.txtMachine.Text))
					this.coreFactory.updateCapacity(capacity);
				else
					this.coreFactory.writeCapacity(capacity);
			}
		}

		private void DeleteDetail()
		{
			this.ganttCapacity.GanttItems.Remove(this.ganttCapacity.SelectedGanttItemIndex.ToString());
			capacity.removeCapacityHour (this.currentDetail[2], DateUtil.parseDate(this.currentDetail[1],DateUtil.MMDDYYYY), this.currentDetail[3], this.currentDetail[5], this.currentDetail[6]);
			this.ClearDetailInfo();
		}

		private string[][] CreateHoursArrayFromShift()
		{
			ArrayList list = new ArrayList();
			for (int i=0; i<7; i++)
			{
				string[][] shiftArray = this.shift.getDaysDetail(i);
				for (int j=0; j<shiftArray.Length; j++)
				{
					string[] item = {"0","01/01/1901","","","0","00:00","00:00","0","0","01/01/1901","","","0","0","0",""};
					item[0] = this.currentWeekPosition[0].ToString();
					item[1] = DateUtil.getDateRepresentation(this.getSundayOfCurrentWeek().AddDays(i),DateUtil.MMDDYYYY);
					item[2] = this.cboShifts.Text;
					item[3] = TimeCodes.getInstance().getEquivalentCode(shiftArray[j][5]);
					item[5] = shiftArray[j][7];
					item[6] = shiftArray[j][8];
					item[7] = shiftArray[j][9];
					decimal utilPer = TimeCodes.getInstance().getMachineProductionHoursPorcentage(TimeCodes.getInstance().getTimeCode(item[3]), this.txtPlant.Text, this.txtDepartment.Text, this.txtMachine.Text);
					decimal hrPr = decimal.Parse(item[7]) * (utilPer / 100);
					item[8] = NumberUtil.toString (hrPr);
					item[12] = NumberUtil.toString (utilPer);
					list.Add (item);
				}
			}
			string[][] hours = new string[list.Count][];
			for (int i=0; i<list.Count; i++)
				hours[i] = (string[])list[i];
			return hours;
		}

		private void InsertHours(string[][] capacityHours, string warningMessage)
		{
			string[][][] allShiftsExistentHours = new string[this.cboShifts.Items.Count][][];
			for (int i=0; i<this.cboShifts.Items.Count; i++)
				allShiftsExistentHours[i] = capacity.getCapacityHoursOfWeekAsString(this.cboShifts.Items[i].ToString(), this.currentWeekPosition[0], this.currentWeekPosition[1]);

			ArrayList[] lists = new ArrayList[7];
			for (int j=0; j<allShiftsExistentHours.Length; j++)
			{
				for (int i=0; i<allShiftsExistentHours[j].Length; i++)
				{
					string[] item = {allShiftsExistentHours[j][i][5],allShiftsExistentHours[j][i][6]};
					int actDay = Utils.DayOfWeekToNumber(DateUtil.parseDate(allShiftsExistentHours[j][i][1],DateUtil.MMDDYYYY).DayOfWeek.ToString());
					if (lists[actDay] == null)
						lists[actDay] = new ArrayList();
					lists[actDay].Add (item);
				}
			}

			string[][][] weekExHours = new string[7][][];
			for (int i=0; i<7; i++)
			{
				if (lists[i] != null)
				{
					weekExHours[i] = new string[lists[i].Count][];
					for (int j=0; j<lists[i].Count; j++)
						weekExHours[i][j] = (string[])lists[i][j];
				}
				else
					weekExHours[i] = new string[0][];
			}

			ArrayList hoursToAdd = new ArrayList();
			for (int i=0; i<capacityHours.Length; i++)
			{
				ArrayList capacityHoursContainer = new ArrayList();
				capacityHoursContainer.Add (capacityHours[i]);
				int actDay = Utils.DayOfWeekToNumber(DateUtil.parseDate(capacityHours[i][1],DateUtil.MMDDYYYY).DayOfWeek.ToString());
				for (int j=0; j<weekExHours[actDay].Length; j++)
				{
					ArrayList newCapacityContainer = new ArrayList();
					IEnumerator enu = capacityHoursContainer.GetEnumerator();
					while (enu.MoveNext())
						newCapacityContainer.AddRange (this.splitHour((string[])enu.Current,weekExHours[actDay][j]));
					capacityHoursContainer = newCapacityContainer;
				}
				hoursToAdd.AddRange(capacityHoursContainer);
			}
			IEnumerator enuHour = hoursToAdd.GetEnumerator();
			bool hasConflicts = false;
			while (enuHour.MoveNext())
			{
				string[] hourToAdd = (string[])enuHour.Current;
				int actDay = Utils.DayOfWeekToNumber(DateUtil.parseDate(hourToAdd[1],DateUtil.MMDDYYYY).DayOfWeek.ToString());
				this.capacity.addCapacityHour (this.currentWeekPosition[0],this.getSundayOfCurrentWeek().AddDays(actDay),hourToAdd[2],hourToAdd[3],int.Parse(hourToAdd[4]),
					hourToAdd[5], hourToAdd[6], decimal.Parse(hourToAdd[7]), decimal.Parse(hourToAdd[8]),DateUtil.parseDate(hourToAdd[9],DateUtil.MMDDYYYY),hourToAdd[10],
					hourToAdd[11], decimal.Parse(hourToAdd[12]),decimal.Parse(hourToAdd[13]), decimal.Parse(hourToAdd[14]), hourToAdd[15]);
			}
			this.ShowCurrentWeek();
			if ((hoursToAdd.Count != capacityHours.Length) || hasConflicts)
				MessageBox.Show (warningMessage, "Waning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private ArrayList splitHour (string[] originalHours, string[] splitter)
		{
			ArrayList newHours = new ArrayList();
			string strStartTime = originalHours[5];
			string strEndTime = originalHours[6];

			if (((strStartTime.CompareTo(splitter[0]) >= 0) && (strStartTime.CompareTo(splitter[1]) >= 0)) ||
				((strEndTime.CompareTo(splitter[0]) <= 0) && (strEndTime.CompareTo(splitter[1]) <= 0)))
			{
				newHours.Add (originalHours);
				return newHours;
			}

			string[] item1 = new string[originalHours.Length];
			string[] item2 = new string[originalHours.Length];
			
			for (int i=0; i<originalHours.Length; i++)
			{
				item1[i] = originalHours[i];
				item2[i] = originalHours[i];
			}
			
			bool thereAre2Items = false;
			if ((strStartTime.CompareTo(splitter[0]) < 0) && (strEndTime.CompareTo(splitter[1]) > 0))
			{
				item1[6] = splitter[0];
				item2[5] = splitter[1];
				thereAre2Items = true;
			}
			else if ((strStartTime.CompareTo(splitter[0]) >= 0) && (strEndTime.CompareTo(splitter[1]) <= 0))
				return new ArrayList();
			else if (strStartTime.CompareTo(splitter[0]) < 0) 
				item1[6] = splitter[0];
			else
				item1[5] = splitter[1];

			TimeCode timeCode = TimeCodes.getInstance().getTimeCode(originalHours[3]);
			decimal hr = this.calculateHours(item1[5],item1[6]);
			decimal hrPr = hr * (TimeCodes.getInstance().getMachineProductionHoursPorcentage(timeCode, this.txtPlant.Text, this.txtDepartment.Text, this.txtMachine.Text) / 100);
			item1[7] = NumberUtil.toString (hr);
			item1[8] = NumberUtil.toString (hrPr);
			newHours.Add (item1);
			
			if (thereAre2Items)
			{
				hr = this.calculateHours(item1[5],item1[6]);
				hrPr = hr * (TimeCodes.getInstance().getMachineProductionHoursPorcentage(timeCode, this.txtPlant.Text, this.txtDepartment.Text, this.txtMachine.Text) / 100);
				item2[7] = NumberUtil.toString (hr);
				item2[8] = NumberUtil.toString (hrPr);
				newHours.Add (item2);
			}
			
			return newHours;
		}

		private decimal calculateHours (string timeStart, string timeEnd)
		{
			decimal totalHours = this.tmeDetailTimeEnd.Value.Hour - this.tmeDetailTimeStart.Value.Hour;
			return (totalHours + ((this.tmeDetailTimeEnd.Value.Minute - this.tmeDetailTimeStart.Value.Minute) / 60M));
		}

		private bool HasConflictWithOtherShitfsCapacity (string timeStart, string timeEnd, DateTime date)
		{
			if ((this.cboShifts.SelectedIndex < 0) || (this.cboShifts.Items.Count == 1))
				return false;
			string [][] capacityHours = this.capacity.getAllHoursAsString();
			for (int i=0; i < capacityHours.Length; i++)
			{
				if (this.cboShifts.Text.Equals (capacityHours[i][2]))
					continue;

				if (DateUtil.parseDate(capacityHours[i][1],DateUtil.MMDDYYYY).Equals (date))
				{

					if ((timeStart.CompareTo(capacityHours[i][5]) >= 0) && (timeStart.CompareTo(capacityHours[i][6]) < 0))
						return true;

					if ((timeEnd.CompareTo(capacityHours[i][5]) > 0) && (timeEnd.CompareTo(capacityHours[i][6]) <= 0))
						return true;

					if ((timeStart.CompareTo(capacityHours[i][5]) <= 0) && (timeEnd.CompareTo(capacityHours[i][6]) >= 0))
						return true;
				}
			}
			return false;
		}

		#endregion Methods

	}

}
