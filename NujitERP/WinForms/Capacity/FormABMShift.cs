using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using NujitCustomWinControls;

using System.Data;

//using Nujit.NujitERP.ClassLib.Master;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.WinForms.SearchForms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.Core;

//using GridScheduling.com.nujit.core;
//using GridScheduling.com.nujit.gui;

using AGVBN20;

namespace Nujit.NujitERP.WinForms.CapacityModule
{
	/// <summary>
	/// Summary description for FormEditShift.
	/// </summary>
	public class FormABMShift : System.Windows.Forms.Form
	{
		private bool changing = false;
		private bool isUpdate = false;
		private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
		private Shift shift, _savedShift;
		private TimeCode[] timeCodes;
		private string[] currentDetail;
		private bool oneOperation = false;
		private int nullSelection = 1;

		#region Controls

		private System.Windows.Forms.Button btnClearShift;
		private System.Windows.Forms.Button btnNewDetail;
		private System.Windows.Forms.TextBox txtBoxShiftCode;
		private System.Windows.Forms.TextBox txtBoxShiftName;
		private System.Windows.Forms.TextBox txtBoxShf;
		private System.Windows.Forms.TextBox txtBoxDb;
		private NujitCustomWinControls.NumericTextBox txtBoxMachNum;
		private NujitCustomWinControls.NumericTextBox txtBoxLabTempCost;
		private NujitCustomWinControls.NumericTextBox txtBoxLabDirCost;
		private NujitCustomWinControls.NumericTextBox txtBoxLabIndCost;
		private NujitCustomWinControls.NumericTextBox txtBoxMachDirCost;
		private NujitCustomWinControls.NumericTextBox txtBoxEmpNumTI;
		private NujitCustomWinControls.NumericTextBox txtBoxEmpNumI;
		private NujitCustomWinControls.NumericTextBox txtBoxEmpNumD;
		private NujitCustomWinControls.NumericTextBox txtBoxEmpNumT;
		private System.Windows.Forms.TextBox txtBoxDes;
		private System.Windows.Forms.TextBox txtBoxRegTime;
		private System.Windows.Forms.Button btnDeleteDetail;
		private System.Windows.Forms.CheckBox chkBoxApplyAllWeek;
		private System.Windows.Forms.Button btnClearDetail;
		private System.Windows.Forms.Label label6;
		private NujitCustomWinControls.NumericTextBox txtBoxTotalDetailHours;
		private System.Windows.Forms.CheckBox chkOverTime;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private AGVBN20.ActiveGanttVBNCtl activeGanttVBNCtl1;
		private System.Windows.Forms.TextBox txtBoxPltCode;
		private System.Windows.Forms.TextBox txtBoxDeptCode;
		private System.Windows.Forms.Button btnShiftSearch;
		private System.Windows.Forms.Label lblSH_Db;
		private System.Windows.Forms.Button btnPlantSearch;
		private System.Windows.Forms.Button btnDeptSearch;
		private System.Windows.Forms.TextBox txtBoxPltName;
		private System.Windows.Forms.TextBox txtBoxDeptName;
		private System.Windows.Forms.TextBox txtBoxCompanyName;
		private System.Windows.Forms.Button btnCompanySearch;
		private System.Windows.Forms.Label lblCompany;
		private System.Windows.Forms.TextBox txtBoxCompanyCode;
		private System.Windows.Forms.GroupBox groupBoxType;
		private System.Windows.Forms.GroupBox groupBoxStatus;
		private System.Windows.Forms.DateTimePicker dTimePickerEndPeriod;
		private System.Windows.Forms.DateTimePicker dTimePickerStrPeriod;
		private System.Windows.Forms.RadioButton rdoButtonActive;
		private System.Windows.Forms.RadioButton rdoButtonInactive;
		private System.Windows.Forms.RadioButton rdoButtonStandard;
		private System.Windows.Forms.RadioButton rdoButtonOverTime;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private NujitCustomWinControls.TimeCtrl timeCtrlTimeStart;
		private NujitCustomWinControls.TimeCtrl timeCtrlTimeEnd;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox comboBoxTmTypes;
		private System.Windows.Forms.Label lblPlt;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.Label lblDept;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.GroupBox grpBoxPlt;
		private System.Windows.Forms.Label lblSH_LabTempCost;
		private System.Windows.Forms.Label lblSH_LabIndCost;
		private System.Windows.Forms.Label lblSH_LabDirCost;
		private System.Windows.Forms.Label lblSH_MachDirCost;
		private System.Windows.Forms.Label lblSH_MachNum;
		private System.Windows.Forms.Label lblSH_EmpNumI;
		private System.Windows.Forms.Label lblSH_EmpNumD;
		private System.Windows.Forms.Label lblSH_RegTime;
		private System.Windows.Forms.Label lblSH_EmpNumTl;
		private System.Windows.Forms.Label g;
		private System.Windows.Forms.Label lblSH_EmpNumT;
		private System.Windows.Forms.Label lblDes;
		private System.Windows.Forms.Label lblShift;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox grpShiftHdr;
		private System.Windows.Forms.GroupBox grpBoxShiftDetail;
		private System.Windows.Forms.Label lblDay;
		private System.Windows.Forms.ComboBox comboBoxStartlDay;

		#endregion Controls
		private System.Windows.Forms.RadioButton rdoButtonMixed;
		private System.Windows.Forms.ImageList imageListOverTime;
		private System.ComponentModel.IContainer components;


		#region Constructors


		public FormABMShift()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.initialize();
		}

	
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


        #endregion Constructors

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormABMShift));
			this.lblPlt = new System.Windows.Forms.Label();
			this.lblDept = new System.Windows.Forms.Label();
			this.txtBoxPltCode = new System.Windows.Forms.TextBox();
			this.txtBoxDeptCode = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.btnDelete = new System.Windows.Forms.Button();
			this.grpShiftHdr = new System.Windows.Forms.GroupBox();
			this.txtBoxMachNum = new NujitCustomWinControls.NumericTextBox();
			this.txtBoxLabTempCost = new NujitCustomWinControls.NumericTextBox();
			this.txtBoxLabDirCost = new NujitCustomWinControls.NumericTextBox();
			this.txtBoxLabIndCost = new NujitCustomWinControls.NumericTextBox();
			this.txtBoxMachDirCost = new NujitCustomWinControls.NumericTextBox();
			this.groupBoxType = new System.Windows.Forms.GroupBox();
			this.rdoButtonMixed = new System.Windows.Forms.RadioButton();
			this.rdoButtonOverTime = new System.Windows.Forms.RadioButton();
			this.rdoButtonStandard = new System.Windows.Forms.RadioButton();
			this.groupBoxStatus = new System.Windows.Forms.GroupBox();
			this.rdoButtonActive = new System.Windows.Forms.RadioButton();
			this.rdoButtonInactive = new System.Windows.Forms.RadioButton();
			this.txtBoxDb = new System.Windows.Forms.TextBox();
			this.lblSH_Db = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtBoxEmpNumTI = new NujitCustomWinControls.NumericTextBox();
			this.txtBoxEmpNumI = new NujitCustomWinControls.NumericTextBox();
			this.txtBoxEmpNumD = new NujitCustomWinControls.NumericTextBox();
			this.txtBoxEmpNumT = new NujitCustomWinControls.NumericTextBox();
			this.lblSH_EmpNumT = new System.Windows.Forms.Label();
			this.lblSH_EmpNumI = new System.Windows.Forms.Label();
			this.lblSH_EmpNumTl = new System.Windows.Forms.Label();
			this.lblSH_EmpNumD = new System.Windows.Forms.Label();
			this.dTimePickerEndPeriod = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.dTimePickerStrPeriod = new System.Windows.Forms.DateTimePicker();
			this.txtBoxDes = new System.Windows.Forms.TextBox();
			this.txtBoxRegTime = new System.Windows.Forms.TextBox();
			this.txtBoxShf = new System.Windows.Forms.TextBox();
			this.lblSH_LabTempCost = new System.Windows.Forms.Label();
			this.lblSH_LabIndCost = new System.Windows.Forms.Label();
			this.lblSH_LabDirCost = new System.Windows.Forms.Label();
			this.lblSH_MachDirCost = new System.Windows.Forms.Label();
			this.lblSH_MachNum = new System.Windows.Forms.Label();
			this.lblSH_RegTime = new System.Windows.Forms.Label();
			this.g = new System.Windows.Forms.Label();
			this.lblDes = new System.Windows.Forms.Label();
			this.lblShift = new System.Windows.Forms.Label();
			this.grpBoxPlt = new System.Windows.Forms.GroupBox();
			this.txtBoxShiftCode = new System.Windows.Forms.TextBox();
			this.txtBoxCompanyName = new System.Windows.Forms.TextBox();
			this.btnCompanySearch = new System.Windows.Forms.Button();
			this.lblCompany = new System.Windows.Forms.Label();
			this.txtBoxCompanyCode = new System.Windows.Forms.TextBox();
			this.txtBoxDeptName = new System.Windows.Forms.TextBox();
			this.btnDeptSearch = new System.Windows.Forms.Button();
			this.txtBoxPltName = new System.Windows.Forms.TextBox();
			this.btnPlantSearch = new System.Windows.Forms.Button();
			this.btnShiftSearch = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtBoxShiftName = new System.Windows.Forms.TextBox();
			this.grpBoxShiftDetail = new System.Windows.Forms.GroupBox();
			this.txtBoxTotalDetailHours = new NujitCustomWinControls.NumericTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.chkOverTime = new System.Windows.Forms.CheckBox();
			this.chkBoxApplyAllWeek = new System.Windows.Forms.CheckBox();
			this.btnDeleteDetail = new System.Windows.Forms.Button();
			this.btnClearDetail = new System.Windows.Forms.Button();
			this.btnNewDetail = new System.Windows.Forms.Button();
			this.comboBoxTmTypes = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.timeCtrlTimeEnd = new NujitCustomWinControls.TimeCtrl();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.timeCtrlTimeStart = new NujitCustomWinControls.TimeCtrl();
			this.comboBoxStartlDay = new System.Windows.Forms.ComboBox();
			this.lblDay = new System.Windows.Forms.Label();
			this.activeGanttVBNCtl1 = new AGVBN20.ActiveGanttVBNCtl();
			this.btnClearShift = new System.Windows.Forms.Button();
			this.imageListOverTime = new System.Windows.Forms.ImageList(this.components);
			this.grpShiftHdr.SuspendLayout();
			this.groupBoxType.SuspendLayout();
			this.groupBoxStatus.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.grpBoxPlt.SuspendLayout();
			this.grpBoxShiftDetail.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblPlt
			// 
			this.lblPlt.Location = new System.Drawing.Point(8, 48);
			this.lblPlt.Name = "lblPlt";
			this.lblPlt.Size = new System.Drawing.Size(56, 20);
			this.lblPlt.TabIndex = 0;
			this.lblPlt.Text = "Plant:";
			this.lblPlt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblDept
			// 
			this.lblDept.Location = new System.Drawing.Point(384, 24);
			this.lblDept.Name = "lblDept";
			this.lblDept.Size = new System.Drawing.Size(56, 20);
			this.lblDept.TabIndex = 2;
			this.lblDept.Text = "Dep.t:";
			this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBoxPltCode
			// 
			this.txtBoxPltCode.Location = new System.Drawing.Point(64, 48);
			this.txtBoxPltCode.MaxLength = 10;
			this.txtBoxPltCode.Name = "txtBoxPltCode";
			this.txtBoxPltCode.ReadOnly = true;
			this.txtBoxPltCode.Size = new System.Drawing.Size(68, 20);
			this.txtBoxPltCode.TabIndex = 6;
			this.txtBoxPltCode.Text = "";
			// 
			// txtBoxDeptCode
			// 
			this.txtBoxDeptCode.Location = new System.Drawing.Point(440, 24);
			this.txtBoxDeptCode.MaxLength = 10;
			this.txtBoxDeptCode.Name = "txtBoxDeptCode";
			this.txtBoxDeptCode.ReadOnly = true;
			this.txtBoxDeptCode.Size = new System.Drawing.Size(68, 20);
			this.txtBoxDeptCode.TabIndex = 8;
			this.txtBoxDeptCode.Text = "";
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(704, 568);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(85, 23);
			this.btnSave.TabIndex = 35;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(704, 600);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(85, 23);
			this.btnCancel.TabIndex = 36;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			this.errorProvider1.DataMember = "";
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Enabled = false;
			this.btnDelete.Location = new System.Drawing.Point(704, 504);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(85, 23);
			this.btnDelete.TabIndex = 16;
			this.btnDelete.Text = "Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// grpShiftHdr
			// 
			this.grpShiftHdr.Controls.Add(this.txtBoxMachNum);
			this.grpShiftHdr.Controls.Add(this.txtBoxLabTempCost);
			this.grpShiftHdr.Controls.Add(this.txtBoxLabDirCost);
			this.grpShiftHdr.Controls.Add(this.txtBoxLabIndCost);
			this.grpShiftHdr.Controls.Add(this.txtBoxMachDirCost);
			this.grpShiftHdr.Controls.Add(this.groupBoxType);
			this.grpShiftHdr.Controls.Add(this.groupBoxStatus);
			this.grpShiftHdr.Controls.Add(this.txtBoxDb);
			this.grpShiftHdr.Controls.Add(this.lblSH_Db);
			this.grpShiftHdr.Controls.Add(this.groupBox1);
			this.grpShiftHdr.Controls.Add(this.dTimePickerEndPeriod);
			this.grpShiftHdr.Controls.Add(this.label1);
			this.grpShiftHdr.Controls.Add(this.dTimePickerStrPeriod);
			this.grpShiftHdr.Controls.Add(this.txtBoxDes);
			this.grpShiftHdr.Controls.Add(this.txtBoxRegTime);
			this.grpShiftHdr.Controls.Add(this.txtBoxShf);
			this.grpShiftHdr.Controls.Add(this.lblSH_LabTempCost);
			this.grpShiftHdr.Controls.Add(this.lblSH_LabIndCost);
			this.grpShiftHdr.Controls.Add(this.lblSH_LabDirCost);
			this.grpShiftHdr.Controls.Add(this.lblSH_MachDirCost);
			this.grpShiftHdr.Controls.Add(this.lblSH_MachNum);
			this.grpShiftHdr.Controls.Add(this.lblSH_RegTime);
			this.grpShiftHdr.Controls.Add(this.g);
			this.grpShiftHdr.Controls.Add(this.lblDes);
			this.grpShiftHdr.Controls.Add(this.lblShift);
			this.grpShiftHdr.Location = new System.Drawing.Point(16, 96);
			this.grpShiftHdr.Name = "grpShiftHdr";
			this.grpShiftHdr.Size = new System.Drawing.Size(768, 185);
			this.grpShiftHdr.TabIndex = 17;
			this.grpShiftHdr.TabStop = false;
			this.grpShiftHdr.Text = "Shift";
			// 
			// txtBoxMachNum
			// 
			this.txtBoxMachNum.Location = new System.Drawing.Point(592, 104);
			this.txtBoxMachNum.Maximum = new System.Decimal(new int[] {
																		  1215752191,
																		  23,
																		  0,
																		  0});
			this.txtBoxMachNum.Minimum = new System.Decimal(new int[] {
																		  0,
																		  0,
																		  0,
																		  0});
			this.txtBoxMachNum.Name = "txtBoxMachNum";
			this.txtBoxMachNum.Size = new System.Drawing.Size(160, 20);
			this.txtBoxMachNum.TabIndex = 50;
			this.txtBoxMachNum.Value = new System.Decimal(new int[] {
																		0,
																		0,
																		0,
																		0});
			// 
			// txtBoxLabTempCost
			// 
			this.txtBoxLabTempCost.DecimalPlaces = 4;
			this.txtBoxLabTempCost.Location = new System.Drawing.Point(328, 152);
			this.txtBoxLabTempCost.Maximum = new System.Decimal(new int[] {
																			  1410065407,
																			  2,
																			  0,
																			  262144});
			this.txtBoxLabTempCost.MaxPrecision = 4;
			this.txtBoxLabTempCost.Minimum = new System.Decimal(new int[] {
																			  0,
																			  0,
																			  0,
																			  0});
			this.txtBoxLabTempCost.Name = "txtBoxLabTempCost";
			this.txtBoxLabTempCost.Size = new System.Drawing.Size(168, 20);
			this.txtBoxLabTempCost.TabIndex = 49;
			this.txtBoxLabTempCost.Value = new System.Decimal(new int[] {
																			0,
																			0,
																			0,
																			0});
			// 
			// txtBoxLabDirCost
			// 
			this.txtBoxLabDirCost.Location = new System.Drawing.Point(328, 128);
			this.txtBoxLabDirCost.Maximum = new System.Decimal(new int[] {
																			 1410065407,
																			 2,
																			 0,
																			 262144});
			this.txtBoxLabDirCost.MaxPrecision = 4;
			this.txtBoxLabDirCost.Minimum = new System.Decimal(new int[] {
																			 0,
																			 0,
																			 0,
																			 0});
			this.txtBoxLabDirCost.Name = "txtBoxLabDirCost";
			this.txtBoxLabDirCost.Size = new System.Drawing.Size(168, 20);
			this.txtBoxLabDirCost.TabIndex = 48;
			this.txtBoxLabDirCost.Value = new System.Decimal(new int[] {
																		   0,
																		   0,
																		   0,
																		   0});
			// 
			// txtBoxLabIndCost
			// 
			this.txtBoxLabIndCost.Location = new System.Drawing.Point(328, 104);
			this.txtBoxLabIndCost.Maximum = new System.Decimal(new int[] {
																			 1410065407,
																			 2,
																			 0,
																			 262144});
			this.txtBoxLabIndCost.MaxPrecision = 4;
			this.txtBoxLabIndCost.Minimum = new System.Decimal(new int[] {
																			 0,
																			 0,
																			 0,
																			 0});
			this.txtBoxLabIndCost.Name = "txtBoxLabIndCost";
			this.txtBoxLabIndCost.Size = new System.Drawing.Size(168, 20);
			this.txtBoxLabIndCost.TabIndex = 47;
			this.txtBoxLabIndCost.Value = new System.Decimal(new int[] {
																		   0,
																		   0,
																		   0,
																		   0});
			// 
			// txtBoxMachDirCost
			// 
			this.txtBoxMachDirCost.Location = new System.Drawing.Point(328, 80);
			this.txtBoxMachDirCost.Maximum = new System.Decimal(new int[] {
																			  1410065407,
																			  2,
																			  0,
																			  262144});
			this.txtBoxMachDirCost.MaxPrecision = 4;
			this.txtBoxMachDirCost.Minimum = new System.Decimal(new int[] {
																			  0,
																			  0,
																			  0,
																			  0});
			this.txtBoxMachDirCost.Name = "txtBoxMachDirCost";
			this.txtBoxMachDirCost.Size = new System.Drawing.Size(168, 20);
			this.txtBoxMachDirCost.TabIndex = 46;
			this.txtBoxMachDirCost.Value = new System.Decimal(new int[] {
																			0,
																			0,
																			0,
																			0});
			// 
			// groupBoxType
			// 
			this.groupBoxType.Controls.Add(this.rdoButtonMixed);
			this.groupBoxType.Controls.Add(this.rdoButtonOverTime);
			this.groupBoxType.Controls.Add(this.rdoButtonStandard);
			this.groupBoxType.Location = new System.Drawing.Point(16, 120);
			this.groupBoxType.Name = "groupBoxType";
			this.groupBoxType.Size = new System.Drawing.Size(224, 48);
			this.groupBoxType.TabIndex = 45;
			this.groupBoxType.TabStop = false;
			this.groupBoxType.Text = "Type";
			// 
			// rdoButtonMixed
			// 
			this.rdoButtonMixed.Location = new System.Drawing.Point(164, 24);
			this.rdoButtonMixed.Name = "rdoButtonMixed";
			this.rdoButtonMixed.Size = new System.Drawing.Size(56, 16);
			this.rdoButtonMixed.TabIndex = 4;
			this.rdoButtonMixed.Text = "Mixed";
			this.rdoButtonMixed.CheckedChanged += new System.EventHandler(this.rdoButtonMixed_CheckedChanged);
			// 
			// rdoButtonOverTime
			// 
			this.rdoButtonOverTime.Location = new System.Drawing.Point(84, 24);
			this.rdoButtonOverTime.Name = "rdoButtonOverTime";
			this.rdoButtonOverTime.Size = new System.Drawing.Size(72, 16);
			this.rdoButtonOverTime.TabIndex = 3;
			this.rdoButtonOverTime.Text = "Over time";
			this.rdoButtonOverTime.CheckedChanged += new System.EventHandler(this.rdoButtonOverTime_CheckedChanged);
			// 
			// rdoButtonStandard
			// 
			this.rdoButtonStandard.Checked = true;
			this.rdoButtonStandard.Location = new System.Drawing.Point(12, 24);
			this.rdoButtonStandard.Name = "rdoButtonStandard";
			this.rdoButtonStandard.Size = new System.Drawing.Size(96, 16);
			this.rdoButtonStandard.TabIndex = 2;
			this.rdoButtonStandard.TabStop = true;
			this.rdoButtonStandard.Text = "Standard";
			this.rdoButtonStandard.CheckedChanged += new System.EventHandler(this.rdoButtonStandard_CheckedChanged);
			// 
			// groupBoxStatus
			// 
			this.groupBoxStatus.Controls.Add(this.rdoButtonActive);
			this.groupBoxStatus.Controls.Add(this.rdoButtonInactive);
			this.groupBoxStatus.Location = new System.Drawing.Point(16, 64);
			this.groupBoxStatus.Name = "groupBoxStatus";
			this.groupBoxStatus.Size = new System.Drawing.Size(224, 48);
			this.groupBoxStatus.TabIndex = 44;
			this.groupBoxStatus.TabStop = false;
			this.groupBoxStatus.Text = "Status";
			// 
			// rdoButtonActive
			// 
			this.rdoButtonActive.Checked = true;
			this.rdoButtonActive.Location = new System.Drawing.Point(16, 24);
			this.rdoButtonActive.Name = "rdoButtonActive";
			this.rdoButtonActive.Size = new System.Drawing.Size(96, 16);
			this.rdoButtonActive.TabIndex = 0;
			this.rdoButtonActive.TabStop = true;
			this.rdoButtonActive.Text = "Active";
			// 
			// rdoButtonInactive
			// 
			this.rdoButtonInactive.Location = new System.Drawing.Point(120, 24);
			this.rdoButtonInactive.Name = "rdoButtonInactive";
			this.rdoButtonInactive.Size = new System.Drawing.Size(96, 16);
			this.rdoButtonInactive.TabIndex = 1;
			this.rdoButtonInactive.Text = "Inactive";
			// 
			// txtBoxDb
			// 
			this.txtBoxDb.Location = new System.Drawing.Point(80, 40);
			this.txtBoxDb.MaxLength = 10;
			this.txtBoxDb.Name = "txtBoxDb";
			this.txtBoxDb.Size = new System.Drawing.Size(160, 20);
			this.txtBoxDb.TabIndex = 43;
			this.txtBoxDb.Text = "";
			this.txtBoxDb.TextChanged += new System.EventHandler(this.textBoxSH_Db_TextChanged);
			// 
			// lblSH_Db
			// 
			this.lblSH_Db.Location = new System.Drawing.Point(8, 40);
			this.lblSH_Db.Name = "lblSH_Db";
			this.lblSH_Db.Size = new System.Drawing.Size(72, 20);
			this.lblSH_Db.TabIndex = 42;
			this.lblSH_Db.Text = "Base:";
			this.lblSH_Db.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtBoxEmpNumTI);
			this.groupBox1.Controls.Add(this.txtBoxEmpNumI);
			this.groupBox1.Controls.Add(this.txtBoxEmpNumD);
			this.groupBox1.Controls.Add(this.txtBoxEmpNumT);
			this.groupBox1.Controls.Add(this.lblSH_EmpNumT);
			this.groupBox1.Controls.Add(this.lblSH_EmpNumI);
			this.groupBox1.Controls.Add(this.lblSH_EmpNumTl);
			this.groupBox1.Controls.Add(this.lblSH_EmpNumD);
			this.groupBox1.Location = new System.Drawing.Point(512, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(240, 80);
			this.groupBox1.TabIndex = 41;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Emp. Num.";
			// 
			// txtBoxEmpNumTI
			// 
			this.txtBoxEmpNumTI.Location = new System.Drawing.Point(136, 48);
			this.txtBoxEmpNumTI.Maximum = new System.Decimal(new int[] {
																		   1215752191,
																		   23,
																		   0,
																		   0});
			this.txtBoxEmpNumTI.Minimum = new System.Decimal(new int[] {
																		   0,
																		   0,
																		   0,
																		   0});
			this.txtBoxEmpNumTI.Name = "txtBoxEmpNumTI";
			this.txtBoxEmpNumTI.Size = new System.Drawing.Size(88, 20);
			this.txtBoxEmpNumTI.TabIndex = 54;
			this.txtBoxEmpNumTI.Value = new System.Decimal(new int[] {
																		 0,
																		 0,
																		 0,
																		 0});
			// 
			// txtBoxEmpNumI
			// 
			this.txtBoxEmpNumI.Location = new System.Drawing.Point(136, 24);
			this.txtBoxEmpNumI.Maximum = new System.Decimal(new int[] {
																		  1215752191,
																		  23,
																		  0,
																		  0});
			this.txtBoxEmpNumI.Minimum = new System.Decimal(new int[] {
																		  0,
																		  0,
																		  0,
																		  0});
			this.txtBoxEmpNumI.Name = "txtBoxEmpNumI";
			this.txtBoxEmpNumI.Size = new System.Drawing.Size(88, 20);
			this.txtBoxEmpNumI.TabIndex = 53;
			this.txtBoxEmpNumI.Value = new System.Decimal(new int[] {
																		0,
																		0,
																		0,
																		0});
			// 
			// txtBoxEmpNumD
			// 
			this.txtBoxEmpNumD.Location = new System.Drawing.Point(24, 48);
			this.txtBoxEmpNumD.Maximum = new System.Decimal(new int[] {
																		  1215752191,
																		  23,
																		  0,
																		  0});
			this.txtBoxEmpNumD.Minimum = new System.Decimal(new int[] {
																		  0,
																		  0,
																		  0,
																		  0});
			this.txtBoxEmpNumD.Name = "txtBoxEmpNumD";
			this.txtBoxEmpNumD.Size = new System.Drawing.Size(88, 20);
			this.txtBoxEmpNumD.TabIndex = 52;
			this.txtBoxEmpNumD.Value = new System.Decimal(new int[] {
																		0,
																		0,
																		0,
																		0});
			// 
			// txtBoxEmpNumT
			// 
			this.txtBoxEmpNumT.Location = new System.Drawing.Point(24, 24);
			this.txtBoxEmpNumT.Maximum = new System.Decimal(new int[] {
																		  1215752191,
																		  23,
																		  0,
																		  0});
			this.txtBoxEmpNumT.Minimum = new System.Decimal(new int[] {
																		  0,
																		  0,
																		  0,
																		  0});
			this.txtBoxEmpNumT.Name = "txtBoxEmpNumT";
			this.txtBoxEmpNumT.Size = new System.Drawing.Size(88, 20);
			this.txtBoxEmpNumT.TabIndex = 51;
			this.txtBoxEmpNumT.Value = new System.Decimal(new int[] {
																		0,
																		0,
																		0,
																		0});
			// 
			// lblSH_EmpNumT
			// 
			this.lblSH_EmpNumT.Location = new System.Drawing.Point(8, 24);
			this.lblSH_EmpNumT.Name = "lblSH_EmpNumT";
			this.lblSH_EmpNumT.Size = new System.Drawing.Size(16, 20);
			this.lblSH_EmpNumT.TabIndex = 2;
			this.lblSH_EmpNumT.Text = "T:";
			this.lblSH_EmpNumT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSH_EmpNumI
			// 
			this.lblSH_EmpNumI.Location = new System.Drawing.Point(120, 24);
			this.lblSH_EmpNumI.Name = "lblSH_EmpNumI";
			this.lblSH_EmpNumI.Size = new System.Drawing.Size(16, 20);
			this.lblSH_EmpNumI.TabIndex = 11;
			this.lblSH_EmpNumI.Text = "I:";
			this.lblSH_EmpNumI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSH_EmpNumTl
			// 
			this.lblSH_EmpNumTl.Location = new System.Drawing.Point(112, 48);
			this.lblSH_EmpNumTl.Name = "lblSH_EmpNumTl";
			this.lblSH_EmpNumTl.Size = new System.Drawing.Size(24, 20);
			this.lblSH_EmpNumTl.TabIndex = 6;
			this.lblSH_EmpNumTl.Text = "TI:";
			this.lblSH_EmpNumTl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSH_EmpNumD
			// 
			this.lblSH_EmpNumD.Location = new System.Drawing.Point(8, 48);
			this.lblSH_EmpNumD.Name = "lblSH_EmpNumD";
			this.lblSH_EmpNumD.Size = new System.Drawing.Size(16, 20);
			this.lblSH_EmpNumD.TabIndex = 10;
			this.lblSH_EmpNumD.Text = "D:";
			this.lblSH_EmpNumD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dTimePickerEndPeriod
			// 
			this.dTimePickerEndPeriod.Location = new System.Drawing.Point(328, 40);
			this.dTimePickerEndPeriod.Name = "dTimePickerEndPeriod";
			this.dTimePickerEndPeriod.Size = new System.Drawing.Size(168, 20);
			this.dTimePickerEndPeriod.TabIndex = 24;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(248, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 20);
			this.label1.TabIndex = 40;
			this.label1.Text = "End Period:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dTimePickerStrPeriod
			// 
			this.dTimePickerStrPeriod.Location = new System.Drawing.Point(328, 16);
			this.dTimePickerStrPeriod.Name = "dTimePickerStrPeriod";
			this.dTimePickerStrPeriod.Size = new System.Drawing.Size(168, 20);
			this.dTimePickerStrPeriod.TabIndex = 23;
			// 
			// txtBoxDes
			// 
			this.txtBoxDes.Location = new System.Drawing.Point(592, 152);
			this.txtBoxDes.MaxLength = 40;
			this.txtBoxDes.Multiline = true;
			this.txtBoxDes.Name = "txtBoxDes";
			this.txtBoxDes.Size = new System.Drawing.Size(160, 20);
			this.txtBoxDes.TabIndex = 25;
			this.txtBoxDes.Text = "";
			// 
			// txtBoxRegTime
			// 
			this.txtBoxRegTime.Location = new System.Drawing.Point(592, 128);
			this.txtBoxRegTime.MaxLength = 1;
			this.txtBoxRegTime.Name = "txtBoxRegTime";
			this.txtBoxRegTime.Size = new System.Drawing.Size(160, 20);
			this.txtBoxRegTime.TabIndex = 22;
			this.txtBoxRegTime.Text = "";
			// 
			// txtBoxShf
			// 
			this.txtBoxShf.Location = new System.Drawing.Point(80, 16);
			this.txtBoxShf.MaxLength = 10;
			this.txtBoxShf.Name = "txtBoxShf";
			this.txtBoxShf.Size = new System.Drawing.Size(160, 20);
			this.txtBoxShf.TabIndex = 19;
			this.txtBoxShf.Text = "";
			// 
			// lblSH_LabTempCost
			// 
			this.lblSH_LabTempCost.Location = new System.Drawing.Point(240, 152);
			this.lblSH_LabTempCost.Name = "lblSH_LabTempCost";
			this.lblSH_LabTempCost.Size = new System.Drawing.Size(88, 20);
			this.lblSH_LabTempCost.TabIndex = 16;
			this.lblSH_LabTempCost.Text = "Lab Temp. Cost:";
			this.lblSH_LabTempCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSH_LabIndCost
			// 
			this.lblSH_LabIndCost.Location = new System.Drawing.Point(240, 104);
			this.lblSH_LabIndCost.Name = "lblSH_LabIndCost";
			this.lblSH_LabIndCost.Size = new System.Drawing.Size(88, 20);
			this.lblSH_LabIndCost.TabIndex = 15;
			this.lblSH_LabIndCost.Text = "Lab Ind. Cost:";
			this.lblSH_LabIndCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSH_LabDirCost
			// 
			this.lblSH_LabDirCost.Location = new System.Drawing.Point(240, 128);
			this.lblSH_LabDirCost.Name = "lblSH_LabDirCost";
			this.lblSH_LabDirCost.Size = new System.Drawing.Size(88, 20);
			this.lblSH_LabDirCost.TabIndex = 14;
			this.lblSH_LabDirCost.Text = "Lab Dir. Cost:";
			this.lblSH_LabDirCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSH_MachDirCost
			// 
			this.lblSH_MachDirCost.Location = new System.Drawing.Point(240, 80);
			this.lblSH_MachDirCost.Name = "lblSH_MachDirCost";
			this.lblSH_MachDirCost.Size = new System.Drawing.Size(88, 20);
			this.lblSH_MachDirCost.TabIndex = 13;
			this.lblSH_MachDirCost.Text = "Mach. Dir. Cost:";
			this.lblSH_MachDirCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSH_MachNum
			// 
			this.lblSH_MachNum.Location = new System.Drawing.Point(504, 104);
			this.lblSH_MachNum.Name = "lblSH_MachNum";
			this.lblSH_MachNum.Size = new System.Drawing.Size(88, 20);
			this.lblSH_MachNum.TabIndex = 12;
			this.lblSH_MachNum.Text = "Machine Num.:";
			this.lblSH_MachNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSH_RegTime
			// 
			this.lblSH_RegTime.Location = new System.Drawing.Point(504, 128);
			this.lblSH_RegTime.Name = "lblSH_RegTime";
			this.lblSH_RegTime.Size = new System.Drawing.Size(88, 20);
			this.lblSH_RegTime.TabIndex = 9;
			this.lblSH_RegTime.Text = "Reg. Time:";
			this.lblSH_RegTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// g
			// 
			this.g.Location = new System.Drawing.Point(248, 16);
			this.g.Name = "g";
			this.g.Size = new System.Drawing.Size(80, 20);
			this.g.TabIndex = 5;
			this.g.Text = "Start Period:";
			this.g.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblDes
			// 
			this.lblDes.Location = new System.Drawing.Point(520, 152);
			this.lblDes.Name = "lblDes";
			this.lblDes.Size = new System.Drawing.Size(72, 20);
			this.lblDes.TabIndex = 1;
			this.lblDes.Text = "Description:";
			this.lblDes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblShift
			// 
			this.lblShift.Location = new System.Drawing.Point(16, 16);
			this.lblShift.Name = "lblShift";
			this.lblShift.Size = new System.Drawing.Size(64, 20);
			this.lblShift.TabIndex = 0;
			this.lblShift.Text = "Shift:";
			this.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpBoxPlt
			// 
			this.grpBoxPlt.Controls.Add(this.txtBoxShiftCode);
			this.grpBoxPlt.Controls.Add(this.txtBoxCompanyName);
			this.grpBoxPlt.Controls.Add(this.btnCompanySearch);
			this.grpBoxPlt.Controls.Add(this.lblCompany);
			this.grpBoxPlt.Controls.Add(this.txtBoxCompanyCode);
			this.grpBoxPlt.Controls.Add(this.txtBoxDeptName);
			this.grpBoxPlt.Controls.Add(this.btnDeptSearch);
			this.grpBoxPlt.Controls.Add(this.txtBoxPltName);
			this.grpBoxPlt.Controls.Add(this.lblPlt);
			this.grpBoxPlt.Controls.Add(this.txtBoxPltCode);
			this.grpBoxPlt.Controls.Add(this.lblDept);
			this.grpBoxPlt.Controls.Add(this.txtBoxDeptCode);
			this.grpBoxPlt.Controls.Add(this.btnPlantSearch);
			this.grpBoxPlt.Controls.Add(this.btnShiftSearch);
			this.grpBoxPlt.Controls.Add(this.label2);
			this.grpBoxPlt.Controls.Add(this.txtBoxShiftName);
			this.grpBoxPlt.Location = new System.Drawing.Point(16, 8);
			this.grpBoxPlt.Name = "grpBoxPlt";
			this.grpBoxPlt.Size = new System.Drawing.Size(768, 80);
			this.grpBoxPlt.TabIndex = 18;
			this.grpBoxPlt.TabStop = false;
			this.grpBoxPlt.Text = "Location";
			// 
			// txtBoxShiftCode
			// 
			this.txtBoxShiftCode.Location = new System.Drawing.Point(440, 48);
			this.txtBoxShiftCode.MaxLength = 10;
			this.txtBoxShiftCode.Name = "txtBoxShiftCode";
			this.txtBoxShiftCode.ReadOnly = true;
			this.txtBoxShiftCode.Size = new System.Drawing.Size(68, 20);
			this.txtBoxShiftCode.TabIndex = 20;
			this.txtBoxShiftCode.Text = "";
			// 
			// txtBoxCompanyName
			// 
			this.txtBoxCompanyName.Location = new System.Drawing.Point(136, 24);
			this.txtBoxCompanyName.MaxLength = 10;
			this.txtBoxCompanyName.Name = "txtBoxCompanyName";
			this.txtBoxCompanyName.ReadOnly = true;
			this.txtBoxCompanyName.Size = new System.Drawing.Size(200, 20);
			this.txtBoxCompanyName.TabIndex = 19;
			this.txtBoxCompanyName.Text = "";
			// 
			// btnCompanySearch
			// 
			this.btnCompanySearch.Enabled = false;
			this.btnCompanySearch.Location = new System.Drawing.Point(344, 26);
			this.btnCompanySearch.Name = "btnCompanySearch";
			this.btnCompanySearch.Size = new System.Drawing.Size(32, 16);
			this.btnCompanySearch.TabIndex = 18;
			this.btnCompanySearch.Text = "...";
			this.btnCompanySearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCompanySearch.Click += new System.EventHandler(this.btnCompanySearch_Click);
			// 
			// lblCompany
			// 
			this.lblCompany.Location = new System.Drawing.Point(8, 24);
			this.lblCompany.Name = "lblCompany";
			this.lblCompany.Size = new System.Drawing.Size(56, 20);
			this.lblCompany.TabIndex = 16;
			this.lblCompany.Text = "Company:";
			this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBoxCompanyCode
			// 
			this.txtBoxCompanyCode.Location = new System.Drawing.Point(64, 24);
			this.txtBoxCompanyCode.MaxLength = 10;
			this.txtBoxCompanyCode.Name = "txtBoxCompanyCode";
			this.txtBoxCompanyCode.ReadOnly = true;
			this.txtBoxCompanyCode.Size = new System.Drawing.Size(68, 20);
			this.txtBoxCompanyCode.TabIndex = 17;
			this.txtBoxCompanyCode.Text = "";
			// 
			// txtBoxDeptName
			// 
			this.txtBoxDeptName.Location = new System.Drawing.Point(512, 24);
			this.txtBoxDeptName.MaxLength = 10;
			this.txtBoxDeptName.Name = "txtBoxDeptName";
			this.txtBoxDeptName.ReadOnly = true;
			this.txtBoxDeptName.Size = new System.Drawing.Size(200, 20);
			this.txtBoxDeptName.TabIndex = 11;
			this.txtBoxDeptName.Text = "";
			// 
			// btnDeptSearch
			// 
			this.btnDeptSearch.Enabled = false;
			this.btnDeptSearch.Location = new System.Drawing.Point(720, 24);
			this.btnDeptSearch.Name = "btnDeptSearch";
			this.btnDeptSearch.Size = new System.Drawing.Size(32, 16);
			this.btnDeptSearch.TabIndex = 10;
			this.btnDeptSearch.Text = "...";
			this.btnDeptSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnDeptSearch.Click += new System.EventHandler(this.btnDeptSearch_Click);
			// 
			// txtBoxPltName
			// 
			this.txtBoxPltName.Location = new System.Drawing.Point(136, 48);
			this.txtBoxPltName.MaxLength = 10;
			this.txtBoxPltName.Name = "txtBoxPltName";
			this.txtBoxPltName.ReadOnly = true;
			this.txtBoxPltName.Size = new System.Drawing.Size(200, 20);
			this.txtBoxPltName.TabIndex = 9;
			this.txtBoxPltName.Text = "";
			// 
			// btnPlantSearch
			// 
			this.btnPlantSearch.Enabled = false;
			this.btnPlantSearch.Location = new System.Drawing.Point(344, 50);
			this.btnPlantSearch.Name = "btnPlantSearch";
			this.btnPlantSearch.Size = new System.Drawing.Size(32, 16);
			this.btnPlantSearch.TabIndex = 8;
			this.btnPlantSearch.Text = "...";
			this.btnPlantSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnPlantSearch.Click += new System.EventHandler(this.btnPlantSearch_Click);
			// 
			// btnShiftSearch
			// 
			this.btnShiftSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnShiftSearch.Enabled = false;
			this.btnShiftSearch.Location = new System.Drawing.Point(720, 48);
			this.btnShiftSearch.Name = "btnShiftSearch";
			this.btnShiftSearch.Size = new System.Drawing.Size(32, 16);
			this.btnShiftSearch.TabIndex = 7;
			this.btnShiftSearch.Text = "...";
			this.btnShiftSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnShiftSearch.Click += new System.EventHandler(this.btnShiftSearch_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(408, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "Shift:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBoxShiftName
			// 
			this.txtBoxShiftName.Location = new System.Drawing.Point(512, 48);
			this.txtBoxShiftName.MaxLength = 10;
			this.txtBoxShiftName.Name = "txtBoxShiftName";
			this.txtBoxShiftName.ReadOnly = true;
			this.txtBoxShiftName.Size = new System.Drawing.Size(200, 20);
			this.txtBoxShiftName.TabIndex = 6;
			this.txtBoxShiftName.Text = "";
			// 
			// grpBoxShiftDetail
			// 
			this.grpBoxShiftDetail.Controls.Add(this.txtBoxTotalDetailHours);
			this.grpBoxShiftDetail.Controls.Add(this.label6);
			this.grpBoxShiftDetail.Controls.Add(this.chkOverTime);
			this.grpBoxShiftDetail.Controls.Add(this.chkBoxApplyAllWeek);
			this.grpBoxShiftDetail.Controls.Add(this.btnDeleteDetail);
			this.grpBoxShiftDetail.Controls.Add(this.btnClearDetail);
			this.grpBoxShiftDetail.Controls.Add(this.btnNewDetail);
			this.grpBoxShiftDetail.Controls.Add(this.comboBoxTmTypes);
			this.grpBoxShiftDetail.Controls.Add(this.label5);
			this.grpBoxShiftDetail.Controls.Add(this.timeCtrlTimeEnd);
			this.grpBoxShiftDetail.Controls.Add(this.label4);
			this.grpBoxShiftDetail.Controls.Add(this.label3);
			this.grpBoxShiftDetail.Controls.Add(this.timeCtrlTimeStart);
			this.grpBoxShiftDetail.Controls.Add(this.comboBoxStartlDay);
			this.grpBoxShiftDetail.Controls.Add(this.lblDay);
			this.grpBoxShiftDetail.Location = new System.Drawing.Point(16, 504);
			this.grpBoxShiftDetail.Name = "grpBoxShiftDetail";
			this.grpBoxShiftDetail.Size = new System.Drawing.Size(664, 112);
			this.grpBoxShiftDetail.TabIndex = 21;
			this.grpBoxShiftDetail.TabStop = false;
			this.grpBoxShiftDetail.Text = "Shift Detail";
			// 
			// txtBoxTotalDetailHours
			// 
			this.txtBoxTotalDetailHours.DecimalPlaces = 2;
			this.txtBoxTotalDetailHours.Location = new System.Drawing.Point(288, 80);
			this.txtBoxTotalDetailHours.Maximum = new System.Decimal(new int[] {
																				   24,
																				   0,
																				   0,
																				   0});
			this.txtBoxTotalDetailHours.MaxPrecision = 2;
			this.txtBoxTotalDetailHours.Minimum = new System.Decimal(new int[] {
																				   0,
																				   0,
																				   0,
																				   0});
			this.txtBoxTotalDetailHours.Name = "txtBoxTotalDetailHours";
			this.txtBoxTotalDetailHours.ReadOnly = true;
			this.txtBoxTotalDetailHours.Rounded = true;
			this.txtBoxTotalDetailHours.Size = new System.Drawing.Size(80, 20);
			this.txtBoxTotalDetailHours.TabIndex = 44;
			this.txtBoxTotalDetailHours.Value = new System.Decimal(new int[] {
																				 0,
																				 0,
																				 0,
																				 0});
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(216, 80);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 20);
			this.label6.TabIndex = 43;
			this.label6.Text = "Detail Hours:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkOverTime
			// 
			this.chkOverTime.Location = new System.Drawing.Point(408, 64);
			this.chkOverTime.Name = "chkOverTime";
			this.chkOverTime.Size = new System.Drawing.Size(128, 20);
			this.chkOverTime.TabIndex = 41;
			this.chkOverTime.Text = "Over-time";
			this.chkOverTime.CheckedChanged += new System.EventHandler(this.chkOverTime_CheckedChanged);
			// 
			// chkBoxApplyAllWeek
			// 
			this.chkBoxApplyAllWeek.Location = new System.Drawing.Point(408, 40);
			this.chkBoxApplyAllWeek.Name = "chkBoxApplyAllWeek";
			this.chkBoxApplyAllWeek.Size = new System.Drawing.Size(128, 20);
			this.chkBoxApplyAllWeek.TabIndex = 40;
			this.chkBoxApplyAllWeek.Text = "Apply to all Week";
			// 
			// btnDeleteDetail
			// 
			this.btnDeleteDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDeleteDetail.Enabled = false;
			this.btnDeleteDetail.Location = new System.Drawing.Point(568, 16);
			this.btnDeleteDetail.Name = "btnDeleteDetail";
			this.btnDeleteDetail.Size = new System.Drawing.Size(85, 23);
			this.btnDeleteDetail.TabIndex = 39;
			this.btnDeleteDetail.Text = "Delete";
			this.btnDeleteDetail.Click += new System.EventHandler(this.btnDeleteDetail_Click);
			// 
			// btnClearDetail
			// 
			this.btnClearDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClearDetail.Location = new System.Drawing.Point(568, 80);
			this.btnClearDetail.Name = "btnClearDetail";
			this.btnClearDetail.Size = new System.Drawing.Size(85, 23);
			this.btnClearDetail.TabIndex = 38;
			this.btnClearDetail.Text = "Clear";
			this.btnClearDetail.Click += new System.EventHandler(this.buttonClear_Click);
			// 
			// btnNewDetail
			// 
			this.btnNewDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNewDetail.Location = new System.Drawing.Point(568, 48);
			this.btnNewDetail.Name = "btnNewDetail";
			this.btnNewDetail.Size = new System.Drawing.Size(85, 23);
			this.btnNewDetail.TabIndex = 37;
			this.btnNewDetail.Text = "Add New";
			this.btnNewDetail.Click += new System.EventHandler(this.buttonNew_Click);
			// 
			// comboBoxTmTypes
			// 
			this.comboBoxTmTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTmTypes.Location = new System.Drawing.Point(72, 64);
			this.comboBoxTmTypes.Name = "comboBoxTmTypes";
			this.comboBoxTmTypes.Size = new System.Drawing.Size(120, 21);
			this.comboBoxTmTypes.TabIndex = 27;
			this.comboBoxTmTypes.SelectedIndexChanged += new System.EventHandler(this.comboBoxTmTypes_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(32, 64);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 20);
			this.label5.TabIndex = 26;
			this.label5.Text = "Type:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// timeCtrlTimeEnd
			// 
			this.timeCtrlTimeEnd.Location = new System.Drawing.Point(288, 48);
			this.timeCtrlTimeEnd.Name = "timeCtrlTimeEnd";
			this.timeCtrlTimeEnd.ShowSeconds = false;
			this.timeCtrlTimeEnd.Size = new System.Drawing.Size(80, 21);
			this.timeCtrlTimeEnd.TabIndex = 25;
			this.timeCtrlTimeEnd.TimeStyle = NujitCustomWinControls.TimeCtrl.EnumTimeStyle.Hours24;
			this.timeCtrlTimeEnd.Value = new System.DateTime(2005, 3, 21, 11, 8, 0, 0);
			this.timeCtrlTimeEnd.ValueChanged += new System.EventHandler(this.timeCtrlTimeEnd_ValueChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(216, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 20);
			this.label4.TabIndex = 24;
			this.label4.Text = "Time End:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(216, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 20);
			this.label3.TabIndex = 23;
			this.label3.Text = "Time Start:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// timeCtrlTimeStart
			// 
			this.timeCtrlTimeStart.Location = new System.Drawing.Point(288, 24);
			this.timeCtrlTimeStart.Name = "timeCtrlTimeStart";
			this.timeCtrlTimeStart.ShowSeconds = false;
			this.timeCtrlTimeStart.Size = new System.Drawing.Size(80, 21);
			this.timeCtrlTimeStart.TabIndex = 22;
			this.timeCtrlTimeStart.TimeStyle = NujitCustomWinControls.TimeCtrl.EnumTimeStyle.Hours24;
			this.timeCtrlTimeStart.Value = new System.DateTime(2005, 3, 21, 11, 8, 0, 0);
			this.timeCtrlTimeStart.ValueChanged += new System.EventHandler(this.timeCtrlTimeStart_ValueChanged);
			// 
			// comboBoxStartlDay
			// 
			this.comboBoxStartlDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxStartlDay.Location = new System.Drawing.Point(72, 40);
			this.comboBoxStartlDay.Name = "comboBoxStartlDay";
			this.comboBoxStartlDay.Size = new System.Drawing.Size(120, 21);
			this.comboBoxStartlDay.TabIndex = 21;
			// 
			// lblDay
			// 
			this.lblDay.Location = new System.Drawing.Point(32, 40);
			this.lblDay.Name = "lblDay";
			this.lblDay.Size = new System.Drawing.Size(40, 20);
			this.lblDay.TabIndex = 20;
			this.lblDay.Text = "Day:";
			this.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// activeGanttVBNCtl1
			// 
			this.activeGanttVBNCtl1.AddMode = AGVBN20.Globals.E_ADDMODE.AT_GANTTITEMADD;
			this.activeGanttVBNCtl1.AllowAdd = true;
			this.activeGanttVBNCtl1.AllowEdit = true;
			this.activeGanttVBNCtl1.AllowFixedColumnSize = true;
			this.activeGanttVBNCtl1.AllowRowHeadingSize = true;
			this.activeGanttVBNCtl1.AllowRowHeadingSwap = true;
			this.activeGanttVBNCtl1.AllowRowSize = true;
			this.activeGanttVBNCtl1.AllowRowSwap = true;
			this.activeGanttVBNCtl1.AllowTimeLineScroll = true;
			this.activeGanttVBNCtl1.AprilBackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
			this.activeGanttVBNCtl1.AprilForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.AugustBackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
			this.activeGanttVBNCtl1.AugustForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.AutomaticRedraw = true;
			this.activeGanttVBNCtl1.BorderStyle = AGVBN20.Globals.E_BORDERSTYLE.TLB_3D;
			this.activeGanttVBNCtl1.ButtonStyle = AGVBN20.Globals.GRE_BUTTONSTYLE.BT_NORMALWINDOWS;
			this.activeGanttVBNCtl1.CurrentLayer = "0";
			this.activeGanttVBNCtl1.CurrentView = "";
			this.activeGanttVBNCtl1.DayFormat = "d ";
			this.activeGanttVBNCtl1.DayFormatZoom0 = "dddd d";
			this.activeGanttVBNCtl1.DayFormatZoom1 = "dddd d";
			this.activeGanttVBNCtl1.DayFormatZoom2 = "dddd d";
			this.activeGanttVBNCtl1.DayFormatZoom3 = "dddd d";
			this.activeGanttVBNCtl1.DayFormatZoom4 = "dddd d";
			this.activeGanttVBNCtl1.DayFormatZoom5 = "dddd d";
			this.activeGanttVBNCtl1.DayFormatZoom6 = "dddd d";
			this.activeGanttVBNCtl1.DayFormatZoom7 = "ddd d";
			this.activeGanttVBNCtl1.DayFormatZoom8 = "ddd d";
			this.activeGanttVBNCtl1.DayFormatZoom9 = "ddd d";
			this.activeGanttVBNCtl1.DecemberBackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
			this.activeGanttVBNCtl1.DecemberForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.DetectConflicts = true;
			this.activeGanttVBNCtl1.DividerAppearance = AGVBN20.Globals.E_BORDERSTYLE.TLB_3D;
			this.activeGanttVBNCtl1.EditMode = AGVBN20.Globals.E_EDITMODE.ET_GANTTMILESTONE;
			this.activeGanttVBNCtl1.EnableObjects = AGVBN20.Globals.E_ENABLEOBJECTS.EO_CURRENTLAYERONLY;
			this.activeGanttVBNCtl1.ErrorReports = AGVBN20.Globals.E_REPORTERRORS.RE_MSGBOX;
			this.activeGanttVBNCtl1.FebruaryBackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.activeGanttVBNCtl1.FebruaryForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.FirstVisibleRow = 1;
			this.activeGanttVBNCtl1.FixedColumnWidth = 125;
			this.activeGanttVBNCtl1.FridayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(95)), ((System.Byte)(109)), ((System.Byte)(231)));
			this.activeGanttVBNCtl1.FridayForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.GridInterval = "15n";
			this.activeGanttVBNCtl1.GridLinesColor = System.Drawing.SystemColors.Control;
			this.activeGanttVBNCtl1.HorizontalGridLinesVisible = true;
			this.activeGanttVBNCtl1.HorizontalScrollBarEnabled = false;
			this.activeGanttVBNCtl1.HorizontalScrollBarFactor = 1;
			this.activeGanttVBNCtl1.HorizontalScrollBarInterval = "n";
			this.activeGanttVBNCtl1.HorizontalScrollBarLargeChange = 10;
			this.activeGanttVBNCtl1.HorizontalScrollBarMax = 100;
			this.activeGanttVBNCtl1.HorizontalScrollBarSmallChange = 1;
			this.activeGanttVBNCtl1.HorizontalScrollBarStart = new System.DateTime(2004, 4, 15, 11, 57, 24, 281);
			this.activeGanttVBNCtl1.HorizontalScrollBarValue = 0;
			this.activeGanttVBNCtl1.JanuaryBackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.activeGanttVBNCtl1.JanuaryForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.JulyBackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
			this.activeGanttVBNCtl1.JulyForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.JuneBackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.activeGanttVBNCtl1.JuneForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.Location = new System.Drawing.Point(16, 288);
			this.activeGanttVBNCtl1.LowerStripeFactor = 0;
			this.activeGanttVBNCtl1.LowerStripeFont = new System.Drawing.Font("Arial", 8F);
			this.activeGanttVBNCtl1.LowerStripeHeight = 0;
			this.activeGanttVBNCtl1.LowerStripeInterval = "";
			this.activeGanttVBNCtl1.MarchBackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
			this.activeGanttVBNCtl1.MarchForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.MayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.activeGanttVBNCtl1.MayForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.MilestoneSelectionOffset = 5;
			this.activeGanttVBNCtl1.MinRowHeadingWidth = 5;
			this.activeGanttVBNCtl1.MinRowHeight = 5;
			this.activeGanttVBNCtl1.MondayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(114)), ((System.Byte)(115)), ((System.Byte)(191)));
			this.activeGanttVBNCtl1.MondayForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.MonthFormatZoom0 = "MMMM yyyy";
			this.activeGanttVBNCtl1.MonthFormatZoom1 = "MMMM yyyy";
			this.activeGanttVBNCtl1.MonthFormatZoom10 = "MMMM";
			this.activeGanttVBNCtl1.MonthFormatZoom11 = "MMMM";
			this.activeGanttVBNCtl1.MonthFormatZoom12 = "MMMM";
			this.activeGanttVBNCtl1.MonthFormatZoom13 = "MMM";
			this.activeGanttVBNCtl1.MonthFormatZoom14 = "MMM";
			this.activeGanttVBNCtl1.MonthFormatZoom2 = "MMMM yyyy";
			this.activeGanttVBNCtl1.MonthFormatZoom3 = "MMMM yyyy";
			this.activeGanttVBNCtl1.MonthFormatZoom4 = "MMMM yyyy";
			this.activeGanttVBNCtl1.MonthFormatZoom5 = "MMMM yyyy";
			this.activeGanttVBNCtl1.MonthFormatZoom6 = "MMMM yyyy";
			this.activeGanttVBNCtl1.MonthFormatZoom7 = "MMMM yyyy";
			this.activeGanttVBNCtl1.MonthFormatZoom8 = "MMMM yyyy";
			this.activeGanttVBNCtl1.MonthFormatZoom9 = "MMMM yyyy";
			this.activeGanttVBNCtl1.Name = "activeGanttVBNCtl1";
			this.activeGanttVBNCtl1.NonContainerRowBackColor = System.Drawing.SystemColors.Control;
			this.activeGanttVBNCtl1.NotchesAreaHeight = 33;
			this.activeGanttVBNCtl1.NotchFont = new System.Drawing.Font("Arial", 8F);
			this.activeGanttVBNCtl1.NotchTextOffset = 18;
			this.activeGanttVBNCtl1.NovemberBackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
			this.activeGanttVBNCtl1.NovemberForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.OctoberBackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.activeGanttVBNCtl1.OctoberForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.Quarter1BackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.activeGanttVBNCtl1.Quarter1ForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.Quarter2BackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.activeGanttVBNCtl1.Quarter2ForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.Quarter3BackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
			this.activeGanttVBNCtl1.Quarter3ForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.Quarter4BackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
			this.activeGanttVBNCtl1.Quarter4ForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.QuarterFormatZoom10 = "\'Q\' yyyy";
			this.activeGanttVBNCtl1.QuarterFormatZoom11 = "\'Q\' yyyy";
			this.activeGanttVBNCtl1.QuarterFormatZoom12 = "\'Q\' yyyy";
			this.activeGanttVBNCtl1.QuarterFormatZoom13 = "\'Q\' yyyy";
			this.activeGanttVBNCtl1.QuarterFormatZoom14 = "\'Q\' yyyy";
			this.activeGanttVBNCtl1.QuarterFormatZoom15 = "\'Q\'";
			this.activeGanttVBNCtl1.RowHeadingWidth = 125;
			this.activeGanttVBNCtl1.RowHeight = 40;
			this.activeGanttVBNCtl1.SaturdayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(124)), ((System.Byte)(131)), ((System.Byte)(191)));
			this.activeGanttVBNCtl1.SaturdayForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.ScrollBarBehaviour = AGVBN20.Globals.E_SCROLLBEHAVIOUR.SB_HIDE;
			this.activeGanttVBNCtl1.ScrollBarsVisible = true;
			this.activeGanttVBNCtl1.SelectedGanttItemIndex = 0;
			this.activeGanttVBNCtl1.SelectedMilestoneIndex = 0;
			this.activeGanttVBNCtl1.SelectedRowHeadingIndex = 0;
			this.activeGanttVBNCtl1.SelectedRowIndex = 0;
			this.activeGanttVBNCtl1.SelectedRowValueIndex = 0;
			this.activeGanttVBNCtl1.SeptemberBackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.activeGanttVBNCtl1.SeptemberForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.ShowLowerStripe = true;
			this.activeGanttVBNCtl1.ShowTimeLineNotches = true;
			this.activeGanttVBNCtl1.ShowUpperStripe = false;
			this.activeGanttVBNCtl1.Size = new System.Drawing.Size(768, 204);
			this.activeGanttVBNCtl1.SnapToGrid = false;
			this.activeGanttVBNCtl1.SnapToGridWhenSelecting = true;
			this.activeGanttVBNCtl1.SundayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(147)), ((System.Byte)(145)), ((System.Byte)(250)));
			this.activeGanttVBNCtl1.SundayForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.TabIndex = 39;
			this.activeGanttVBNCtl1.ThursdayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(53)), ((System.Byte)(64)), ((System.Byte)(164)));
			this.activeGanttVBNCtl1.ThursdayForeColor = System.Drawing.Color.White;
			this.activeGanttVBNCtl1.TimeBlockBehaviour = AGVBN20.Globals.E_TIMEBLOCKBEHAVIOUR.TBB_ROWEXTENTS;
			this.activeGanttVBNCtl1.TimeFormat = "HH:mm";
			this.activeGanttVBNCtl1.TimeLineAppearance = AGVBN20.Globals.E_BORDERSTYLE.TLB_3D;
			this.activeGanttVBNCtl1.TimeLineBackColor = System.Drawing.SystemColors.Control;
			this.activeGanttVBNCtl1.TimeLineForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.TimeLineMarkerColor = System.Drawing.Color.Red;
			this.activeGanttVBNCtl1.TimeLineMarkerDate = new System.DateTime(2004, 4, 15, 11, 57, 24, 281);
			this.activeGanttVBNCtl1.TimeLineMarkerLength = AGVBN20.Globals.E_TIMELINEMARKERLENGTH.TLMA_NOTCHAREA;
			this.activeGanttVBNCtl1.TimeLineMarkerType = AGVBN20.Globals.E_TIMELINEMARKERTYPE.TLMT_SYSTEMTIME;
			this.activeGanttVBNCtl1.TimeLineStyleIndex = "";
			this.activeGanttVBNCtl1.ToolTipFormatZoom0To9 = "HH:mm";
			this.activeGanttVBNCtl1.ToolTipFormatZoom10To15 = "M/d/yy h:mm tt";
			this.activeGanttVBNCtl1.ToolTipsVisible = true;
			this.activeGanttVBNCtl1.TrimTimeFormat = true;
			this.activeGanttVBNCtl1.TuesdayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(80)), ((System.Byte)(80)), ((System.Byte)(140)));
			this.activeGanttVBNCtl1.TuesdayForeColor = System.Drawing.Color.White;
			this.activeGanttVBNCtl1.UpperStripeFactor = 0;
			this.activeGanttVBNCtl1.UpperStripeFont = new System.Drawing.Font("Arial", 8F);
			this.activeGanttVBNCtl1.UpperStripeHeight = 0;
			this.activeGanttVBNCtl1.UpperStripeInterval = "";
			this.activeGanttVBNCtl1.UseViews = false;
			this.activeGanttVBNCtl1.VerticalGridLinesVisible = false;
			this.activeGanttVBNCtl1.WednesdayBackColor = System.Drawing.Color.FromArgb(((System.Byte)(104)), ((System.Byte)(109)), ((System.Byte)(152)));
			this.activeGanttVBNCtl1.WednesdayForeColor = System.Drawing.Color.White;
			this.activeGanttVBNCtl1.Year0BackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.activeGanttVBNCtl1.Year0ForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.Year1BackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.activeGanttVBNCtl1.Year1ForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.Year2BackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
			this.activeGanttVBNCtl1.Year2ForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.Year3BackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
			this.activeGanttVBNCtl1.Year3ForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.Year4BackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.activeGanttVBNCtl1.Year4ForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.Year5BackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.activeGanttVBNCtl1.Year5ForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.Year6BackColor = System.Drawing.Color.FromArgb(((System.Byte)(170)), ((System.Byte)(170)), ((System.Byte)(173)));
			this.activeGanttVBNCtl1.Year6ForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.Year7BackColor = System.Drawing.Color.FromArgb(((System.Byte)(126)), ((System.Byte)(127)), ((System.Byte)(141)));
			this.activeGanttVBNCtl1.Year7ForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.Year8BackColor = System.Drawing.Color.FromArgb(((System.Byte)(205)), ((System.Byte)(205)), ((System.Byte)(220)));
			this.activeGanttVBNCtl1.Year8ForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.Year9BackColor = System.Drawing.Color.FromArgb(((System.Byte)(187)), ((System.Byte)(188)), ((System.Byte)(206)));
			this.activeGanttVBNCtl1.Year9ForeColor = System.Drawing.Color.Black;
			this.activeGanttVBNCtl1.YearFormatZoom15 = "yyyy";
			this.activeGanttVBNCtl1.ZoomFactor = 5;
			this.activeGanttVBNCtl1.GanttItemAdded += new AGVBN20.ActiveGanttVBNCtl.GanttItemAddedEventHandler(this.activeGanttVBNCtl1_GanttItemAdded);
			this.activeGanttVBNCtl1.GanttItemSelected += new AGVBN20.ActiveGanttVBNCtl.GanttItemSelectedEventHandler(this.activeGanttVBNCtl1_GanttItemSelected);
			this.activeGanttVBNCtl1.GanttItemChanged += new AGVBN20.ActiveGanttVBNCtl.GanttItemChangedEventHandler(this.activeGanttVBNCtl1_GanttItemChanged);
			// 
			// btnClearShift
			// 
			this.btnClearShift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClearShift.Enabled = false;
			this.btnClearShift.Location = new System.Drawing.Point(704, 536);
			this.btnClearShift.Name = "btnClearShift";
			this.btnClearShift.Size = new System.Drawing.Size(85, 23);
			this.btnClearShift.TabIndex = 40;
			this.btnClearShift.Text = "Clear";
			this.btnClearShift.Click += new System.EventHandler(this.btnClearShift_Click);
			// 
			// imageListOverTime
			// 
			this.imageListOverTime.ImageSize = new System.Drawing.Size(16, 16);
			this.imageListOverTime.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListOverTime.ImageStream")));
			this.imageListOverTime.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// FormABMShift
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(798, 631);
			this.Controls.Add(this.btnClearShift);
			this.Controls.Add(this.activeGanttVBNCtl1);
			this.Controls.Add(this.grpBoxPlt);
			this.Controls.Add(this.grpShiftHdr);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.grpBoxShiftDetail);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormABMShift";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Shift";
			this.grpShiftHdr.ResumeLayout(false);
			this.groupBoxType.ResumeLayout(false);
			this.groupBoxStatus.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.grpBoxPlt.ResumeLayout(false);
			this.grpBoxShiftDetail.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private string getImagePath()
		{
			string appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
			if (appPath.EndsWith("\\bin\\Debug"))
				return appPath.Substring(0,appPath.Length-10) + "\\Images";
			else if (appPath.EndsWith("\\bin\\Release"))
				return appPath.Substring(0,appPath.Length-12) + "\\Images";
			else
				return appPath;
		}

		private int getCompanyCode()
		{
			try{return int.Parse(this.txtBoxCompanyCode.Text);}
			catch{return -1;}
		}

		public Shift getSavedShift()
		{
			return _savedShift;
		}

		public void initialize()
		{
			shift = coreFactory.createShift();

			this.timeCtrlTimeEnd.setTime (DateTime.Today);
			this.timeCtrlTimeStart.setTime (DateTime.Today);

//			this.timeCtrlTimeEnd.TimeStyle = NujitCustomWinControls.TimeCtrl.EnumTimeStyle.Hours24;
//			this.timeCtrlTimeStart.TimeStyle = NujitCustomWinControls.TimeCtrl.EnumTimeStyle.Hours24;

			this.txtBoxDb.Text = Configuration.DftDataBase;
			timeCodes = TimeCodes.getInstance().getLabourCodes();

			DateTime today   = DateTime.Today;
			DateTime dtStart = today;                     //today.AddDays(-1);
			DateTime dtEnd   = today.AddDays(+1);
			
			this.activeGanttVBNCtl1.SaturdayBackColor = Color.Beige;
			this.activeGanttVBNCtl1.SundayBackColor   = Color.Beige;
			this.activeGanttVBNCtl1.BackColor = System.Drawing.SystemColors.Window;

			this.activeGanttVBNCtl1.TimeLineAppearance = AGVBN20.Globals.E_BORDERSTYLE.TLB_NONE;

			this.activeGanttVBNCtl1.PositionTimeLine(dtStart);
			this.activeGanttVBNCtl1.HorizontalScrollBarMax = 16;
			this.activeGanttVBNCtl1.HorizontalScrollBarValue = 4;

			this.activeGanttVBNCtl1.HorizontalScrollBarEnabled     = true;
			this.activeGanttVBNCtl1.HorizontalScrollBarStart       = dtStart.AddMinutes (-25);
		
			this.activeGanttVBNCtl1.HorizontalScrollBarFactor      = 2;
			this.activeGanttVBNCtl1.HorizontalScrollBarInterval    = "h";
			this.activeGanttVBNCtl1.HorizontalScrollBarLargeChange = 10;
        		

			this.activeGanttVBNCtl1.AllowRowHeadingSwap  = false;
			this.activeGanttVBNCtl1.AllowRowSwap         = false;
			this.activeGanttVBNCtl1.AllowTimeLineScroll  = false;
			this.activeGanttVBNCtl1.AllowDrop            = false;
			this.activeGanttVBNCtl1.AllowAdd             = true;
			this.activeGanttVBNCtl1.AllowEdit            = true;
			this.activeGanttVBNCtl1.AllowFixedColumnSize = false;
			this.activeGanttVBNCtl1.AllowRowSize         = false;

			this.activeGanttVBNCtl1.HorizontalGridLinesVisible = false;

			this.activeGanttVBNCtl1.RowHeadings.Add("", 100, "0", "");

			this.setTimeCodesStyles();

			this.activeGanttVBNCtl1.Styles.Add("defaultStyleRowItem");

			clsStyle styleRow  = this.activeGanttVBNCtl1.Styles.get_Item(this.activeGanttVBNCtl1.Styles.Count.ToString());
			styleRow.ForeColor = System.Drawing.Color.Black;

			Nujit.NujitERP.WinForms.CustomControls.ListBuilder.FillListDayOfWeek(this.comboBoxStartlDay);
			this.loadTimeTypesToComboBox();

			this.activeGanttVBNCtl1.Rows.Clear();
			this.activeGanttVBNCtl1.GanttItems.Clear();

			for (int i =0 ; i < 7 ; i++ )
			{	
				string rowKey =  "DAY" + i.ToString();
				string caption = "";
 
				caption = Nujit.NujitERP.ClassLib.Common.Utils.NumberToDayOfWeek(i);

				this.activeGanttVBNCtl1.Rows.Add(rowKey , caption, true, true,  "defaultStyleRowItem", "");
				clsRow newRow = activeGanttVBNCtl1.Rows.get_Item(rowKey);
				
				newRow.Height = 20;
			}	

			this.activeGanttVBNCtl1.GanttItems.Add ("","DAY0",DateTime.Today.AddDays(-1),DateTime.Today.AddDays(-1).AddHours(1),"NULL","0","","0");

		}

		private void loadTimeTypesToComboBox()
		{
			DataTable dt		= new DataTable();
			dt.Columns.Add("DisplayMember");
			dt.Columns.Add("ValueMember");

			DataRow dr = null;

			for (int i=0; i<timeCodes.Length; i++)
			{
				dr = dt.NewRow();
				dr["DisplayMember"] = timeCodes[i].getDes();
				dr["ValueMember"]	= timeCodes[i].getTmType();
				dt.Rows.Add(dr);
			}

			this.comboBoxTmTypes.DataSource		= dt.DefaultView; 
			this.comboBoxTmTypes.DisplayMember	= "DisplayMember";
			this.comboBoxTmTypes.ValueMember	= "ValueMember";
		}

		private void setTimeCodesStyles()
		{
			for (int i=0; i<timeCodes.Length; i++)
			{
				//Standard
				this.activeGanttVBNCtl1.Styles.Add(Shift.SHIFT_TYPE_STANDARD + "-" + timeCodes[i].getTmType());
				clsStyle style  = this.activeGanttVBNCtl1.Styles.get_Item(this.activeGanttVBNCtl1.Styles.Count.ToString());

				style.BackColor = TimeCodes.getInstance().getColor(timeCodes[i]);
				style.CaptionAlignmentVertical = (AGVBN20.Globals.GRE_VERTICALALIGNMENT)1;
				style.CaptionYMargin = 4;
				style.Appearance = (AGVBN20.Globals.E_STYLEAPPEARANCE)2;
				style.BorderStyle = (AGVBN20.Globals.E_STYLEBORDER)1;
				style.BorderColor = System.Drawing.Color.Black;

				//Overtime
				this.activeGanttVBNCtl1.Styles.Add(Shift.SHIFT_TYPE_OVER_TIME + "-" + timeCodes[i].getTmType());
				style  = this.activeGanttVBNCtl1.Styles.get_Item(this.activeGanttVBNCtl1.Styles.Count.ToString());

				style.Appearance = (AGVBN20.Globals.E_STYLEAPPEARANCE)2;
				style.BorderStyle = (AGVBN20.Globals.E_STYLEBORDER)1;
				style.BorderColor = System.Drawing.Color.Black;
				style.BackColor = TimeCodes.getInstance().getColor(timeCodes[i]);

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
		}

		private void btnShiftSearch_Click(object sender, System.EventArgs e)
		{
			ShiftHdrSearchForm shiftHdrSearchForm = new ShiftHdrSearchForm("Shift Search");
			shiftHdrSearchForm.setBaseFilter (this.txtBoxDb.Text);
			shiftHdrSearchForm.setCompanyFilter (getCompanyCode());
			shiftHdrSearchForm.setPlantFilter (this.txtBoxPltCode.Text);
			shiftHdrSearchForm.setDeptFilter (this.txtBoxDeptCode.Text);
			shiftHdrSearchForm.ShowDialog();
	
			if (shiftHdrSearchForm.DialogResult == DialogResult.OK)
			{
				string[] v = shiftHdrSearchForm.getSelected();
				if (v != null)
				{			
					this.txtBoxShiftCode.Text = v[4];
					this.txtBoxShiftName.Text = v[5];
				}
				if (this.txtBoxDeptCode.Text.Length == 0)
				{
					if (this.txtBoxPltCode.Text.Length == 0)
					{
						if (getCompanyCode() == -1)
						{
							this.txtBoxCompanyCode.Text = v[1];
							this.txtBoxCompanyName.Text = coreFactory.readCompany (this.txtBoxDb.Text, getCompanyCode()).getName();
						}
						this.txtBoxPltCode.Text = v[2];
						this.txtBoxPltName.Text = coreFactory.readPlt (this.txtBoxDb.Text, getCompanyCode(), this.txtBoxPltCode.Text).getPltName();
					}
					this.txtBoxDeptCode.Text = v[3];
					this.txtBoxDeptName.Text = coreFactory.readDepartament (this.txtBoxPltCode.Text, this.txtBoxDeptCode.Text).getDes1();
				}
				this.btnCompanySearch.Enabled = false;
				this.btnPlantSearch.Enabled = false;
				this.btnDeptSearch.Enabled = false;
				this.objectToScreen (v[0], int.Parse(v[1]), v[2], v[3], v[4]);
			}
		}

		private void btnCompanySearch_Click(object sender, System.EventArgs e)
		{
			CompanySearchForm companySearchForm = new CompanySearchForm("Company Search");
			companySearchForm.setBaseFilter (this.txtBoxDb.Text);
			companySearchForm.ShowDialog();
	
			if (companySearchForm.DialogResult == DialogResult.OK)
			{
				string oldCode = txtBoxCompanyCode.Text;
				string[] v = companySearchForm.getSelected();
				if (v != null)
				{			
					this.txtBoxCompanyCode.Text = v[1];
					this.txtBoxCompanyName.Text = v[2];
				}
				if (!oldCode.Equals(this.txtBoxCompanyCode.Text))
				{
					this.txtBoxPltCode.Text = string.Empty;
					this.txtBoxPltName.Text = string.Empty;
					this.txtBoxDeptCode.Text = string.Empty;
					this.txtBoxDeptName.Text = string.Empty;
				}
			}
		}

		private void objectToScreen (string db, int company, string plant, string dept, string shf)
		{
			if (coreFactory.existsShift (db, company, plant, dept, shf))
			{
				shift = coreFactory.readShift (db, company, plant, dept, shf);
				isUpdate = true;
				this.btnDelete.Enabled = true;
				this.btnClearShift.Enabled = true;

				this.txtBoxDb.ReadOnly = true;
				this.txtBoxShf.ReadOnly = true;

				this.txtBoxShf.Text = shift.getShf();
				if (shift.getShfStatus().Equals(Shift.SHIFT_STATUS_ACTIVE))
					this.rdoButtonActive.Checked = true;
				else
					this.rdoButtonInactive.Checked = true;
				if (shift.getShfType().Equals(Shift.SHIFT_TYPE_STANDARD))
				{
					this.rdoButtonStandard.Checked = true;
					this.chkOverTime.Checked = false;
					this.chkOverTime.Enabled = false;
				}
				else if (shift.getShfType().Equals(Shift.SHIFT_TYPE_OVER_TIME))
				{
					this.rdoButtonOverTime.Checked = true;
					this.chkOverTime.Checked = true;
					this.chkOverTime.Enabled = false;
				}
				else
				{
					this.rdoButtonMixed.Checked = true;
					this.chkOverTime.Checked = false;
					this.chkOverTime.Enabled = true;
				}
				this.dTimePickerStrPeriod.Value = shift.getStrPeriod();
				this.dTimePickerEndPeriod.Value = shift.getEndPeriod();
				this.txtBoxMachDirCost.Value = shift.getMachDirCost();
				this.txtBoxLabDirCost.Value = shift.getLabDirCost();
				this.txtBoxLabIndCost.Value = shift.getLabIndCost();
				this.txtBoxLabTempCost.Value = shift.getLabTempCost();
				this.txtBoxEmpNumD.Value = shift.getEmpNumD();
				this.txtBoxEmpNumT.Value = shift.getEmpNumT();
				this.txtBoxEmpNumI.Value = shift.getEmpNumI();
				this.txtBoxEmpNumTI.Value = shift.getEmpNumTl();
				this.txtBoxMachNum.Value = shift.getMachNum();
				this.txtBoxRegTime.Text = shift.getRegTime();
				this.txtBoxDes.Text = shift.getDes();
				
				this.loadGridData();
				this.btnDelete.Enabled = true;
			}
		}

		private void loadGridData()
		{
			this.activeGanttVBNCtl1.GanttItems.Clear();
		
			this.activeGanttVBNCtl1.GanttItems.Add ("","DAY0",DateTime.Today.AddDays(-1),DateTime.Today.AddDays(-1).AddHours(1),"NULL","0","","0");

			DateTime minTime = DateTime.Today.AddDays(1).AddMilliseconds(-1);
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

					this.activeGanttVBNCtl1.GanttItems.Add (TimeCodes.getInstance().getTimeCode(detail[j][5]).getDes(), "DAY" + i.ToString(), startTime, endTime, i.ToString() + "-" + detail[j][7] + "-" + detail[j][8], detail[j][10] + "-" + detail[j][5], "", "0");
					clsGanttItem item = this.activeGanttVBNCtl1.GanttItems.get_Item (i.ToString() + "-" + detail[j][7] + "-" + detail[j][8]);
					item.AllowedMovement = (AGVBN20.Globals.E_MOVEMENTTYPE)1;
					if (detail[j][10].Equals(Shift.SHIFT_TYPE_OVER_TIME))
						item.Picture = getImagePath() + "\\Exclamation.bmp";
					
					if (startTime.CompareTo(minTime) < 0)
						minTime = startTime;
				}
			}
			activeGanttVBNCtl1.HorizontalScrollBarValue = Math.Min(minTime.Hour / 2,7);
		}

		private void screenToObject()
		{
			if (shift == null) 
				shift = coreFactory.createShift();

			shift.setDb(this.txtBoxDb.Text);
			shift.setCompany(int.Parse(this.txtBoxCompanyCode.Text));
			shift.setPlt(this.txtBoxPltCode.Text.Trim());
			shift.setDept(this.txtBoxDeptCode.Text.Trim()); 
			shift.setShf(this.txtBoxShf.Text.Trim()); 
			shift.setEndPeriod(this.dTimePickerEndPeriod.Value);
			shift.setStrPeriod(this.dTimePickerStrPeriod.Value);
			shift.setDes(Converter.fixString(this.txtBoxDes.Text.Trim()));
			shift.setRegTime(this.txtBoxRegTime.Text.Trim());
			if (this.rdoButtonActive.Checked)
				shift.setShfStatus(Shift.SHIFT_STATUS_ACTIVE);
			else
				shift.setShfStatus(Shift.SHIFT_STATUS_INACTIVE);
			if (this.rdoButtonStandard.Checked)
				shift.setShfType(Shift.SHIFT_TYPE_STANDARD);
			else if (this.rdoButtonOverTime.Checked)
				shift.setShfType(Shift.SHIFT_TYPE_OVER_TIME);
			else
				shift.setShfType(Shift.SHIFT_TYPE_MIXED);
			shift.setEmpNumD(Convert.ToInt32(this.txtBoxEmpNumD.Value));
			shift.setEmpNumI(Convert.ToInt32(this.txtBoxEmpNumI.Value));
			shift.setEmpNumT(Convert.ToInt32(this.txtBoxEmpNumT.Value));
			shift.setEmpNumTl(Convert.ToInt32(this.txtBoxEmpNumTI.Value));  
			shift.setMachNum(Convert.ToInt32(this.txtBoxMachNum.Value));
			shift.setLabDirCost(this.txtBoxLabDirCost.Value);
			shift.setLabIndCost(this.txtBoxLabIndCost.Value);
			shift.setLabTempCost(this.txtBoxLabTempCost.Value);
			shift.setMachDirCost(this.txtBoxMachDirCost.Value);
		}

		private void btnPlantSearch_Click(object sender, System.EventArgs e)
		{
			PlantSearchForm plantSearchForm = new PlantSearchForm("Plant Search");
			plantSearchForm.ShowDialog();
	
			if (plantSearchForm.DialogResult == DialogResult.OK)
			{
				string oldCode = txtBoxPltCode.Text;
				string[] v = plantSearchForm.getSelected();
				if (v != null)
				{			
					this.txtBoxPltCode.Text = v[0];
					this.txtBoxPltName.Text = v[1];
				}
				if (getCompanyCode() == -1)
				{
					this.txtBoxCompanyCode.Text = v[1];
					this.txtBoxCompanyName.Text = coreFactory.readCompany (this.txtBoxDb.Text, getCompanyCode()).getName();
				}
				if (!oldCode.Equals(this.txtBoxPltCode.Text))
				{
					this.txtBoxDeptCode.Text = string.Empty;
					this.txtBoxDeptName.Text = string.Empty;
				}
			}
		}

		private void btnDeptSearch_Click(object sender, System.EventArgs e)
		{
			DepartmentSearchForm departmentSearchForm = new DepartmentSearchForm("Department Search");
			departmentSearchForm.setBaseFilter (this.txtBoxDb.Text);
			departmentSearchForm.setPlantFilter (this.txtBoxPltCode.Text);
			departmentSearchForm.setCompanyFilter (getCompanyCode());
			departmentSearchForm.ShowDialog();
	
			if (departmentSearchForm.DialogResult == DialogResult.OK)
			{
				string[] v = departmentSearchForm.getSelected();
				if (v != null)
				{			
					this.txtBoxDeptCode.Text = v[3];
					this.txtBoxDeptName.Text = v[4];
				}
				if (this.txtBoxPltCode.Text.Length == 0)
				{
					if (getCompanyCode() == -1)
					{
						this.txtBoxCompanyCode.Text = v[1];
						this.txtBoxCompanyName.Text = coreFactory.readCompany (this.txtBoxDb.Text, getCompanyCode()).getName();
					}
					this.txtBoxPltCode.Text = v[2];
					this.txtBoxPltName.Text = coreFactory.readPlt (this.txtBoxDb.Text, getCompanyCode(), this.txtBoxPltCode.Text).getPltName();
				}
			}
		}

		private void textBoxSH_Db_TextChanged(object sender, System.EventArgs e)
		{
			if (this.txtBoxDb.Text.Length > 0)
			{
				this.btnShiftSearch.Enabled = true;
				this.btnCompanySearch.Enabled = true;
				this.btnPlantSearch.Enabled = true;
				this.btnDeptSearch.Enabled = true;
			}
			else
			{
				this.btnShiftSearch.Enabled = false;
				this.btnCompanySearch.Enabled = false;
				this.btnPlantSearch.Enabled = false;
				this.btnDeptSearch.Enabled = false;
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			string message;
			if (isUpdate)
				message = "Update de current shift?";
			else
				message = "Add current shift to the system?";
			if (MessageBox.Show (message, "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				this.save();
		}

		private void save()
		{
			try 
			{
				if (isUpdate)
				{
					this.screenToObject();
					coreFactory.updateShift (shift);
				}
				else
				{
					if (txtBoxDb.Text.Length == 0)
					{
						MessageBox.Show("A base must be entered.","Field missing",MessageBoxButtons.OK,MessageBoxIcon.Error);
						return;
					}
					if (txtBoxCompanyCode.Text.Length == 0)
					{
						MessageBox.Show("A company must be selected.","Field missing",MessageBoxButtons.OK,MessageBoxIcon.Error);
						return;
					}
					if (txtBoxPltCode.Text.Length == 0)
					{
						MessageBox.Show("A plant must be selected.","Field missing",MessageBoxButtons.OK,MessageBoxIcon.Error);
						return;
					}
					if (txtBoxDeptCode.Text.Length == 0)
					{
						MessageBox.Show("A department must be selected.","Field missing",MessageBoxButtons.OK,MessageBoxIcon.Error);
						return;
					}
					if (txtBoxShf.Text.Length == 0)
					{
						MessageBox.Show("A code must be entered.","Field missing",MessageBoxButtons.OK,MessageBoxIcon.Error);
						return;
					}
					if (coreFactory.existsShift (txtBoxDb.Text,int.Parse(txtBoxCompanyCode.Text),txtBoxPltCode.Text,txtBoxDeptCode.Text,txtBoxShf.Text))
					{
						MessageBox.Show("The shift already exists.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
						return;
					}
					this.screenToObject();
					coreFactory.writeShift (shift);
				}
				MessageBox.Show ("Shift saved.","Complete");
				if (oneOperation)
				{
					this.DialogResult = DialogResult.OK;
					_savedShift = shift;
					this.Close();
				}
			}						
			catch
			{
				MessageBox.Show ("Shift couldn't be saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show ("The shift will be deleted.\nAre you sure?","Confirmation",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.coreFactory.deleteShift (shift.getDb(), shift.getCompany(), shift.getPlt(), shift.getDept(), shift.getShf()); 
				this.clearForm();
				if (oneOperation)
				{
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show ("Changes will be lost.\nContinue anyways?","Question",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				this.Close();
		}

		private void activeGanttVBNCtl1_GanttItemSelected(int Index)
		{
			int index = this.activeGanttVBNCtl1.SelectedGanttItemIndex;
			clsGanttItem item = this.activeGanttVBNCtl1.GanttItems.get_Item(index.ToString());
			this.currentDetail = shift.getDayDetailByTimeSpan (int.Parse(item.Key.Substring(0,1)),DateUtil.getTimeRepresentation(item.StartDate).Substring(0,5),DateUtil.getTimeRepresentation(item.EndDate).Substring(0,5));
			this.detailToScreen();
		}

		private void detailToScreen()
		{
			changing = false;

			chkBoxApplyAllWeek.Enabled = false;
			this.comboBoxStartlDay.SelectedIndex = int.Parse(currentDetail[6]);
			this.comboBoxStartlDay.Enabled = false;
			this.btnNewDetail.Enabled = false;

			int hours = int.Parse(currentDetail[7].Substring(0,2));
			int minutes = int.Parse(currentDetail[7].Substring(3,2));
			DateTime startTime = DateTime.Today.AddHours (hours).AddMinutes(minutes);

			hours = int.Parse(currentDetail[8].Substring(0,2));
			minutes = int.Parse(currentDetail[8].Substring(3,2));
			DateTime endTime = DateTime.Today.AddHours (hours).AddMinutes(minutes);

			this.timeCtrlTimeStart.setTime (startTime);
			this.timeCtrlTimeEnd.setTime (endTime);

			this.comboBoxTmTypes.SelectedValue = currentDetail[5];

			if (currentDetail[10].Equals(Shift.SHIFT_TYPE_OVER_TIME))
				this.chkOverTime.Checked = true;
			else
				this.chkOverTime.Checked = false;

			changing = true;
			btnDeleteDetail.Enabled = true;
		}

		private void impactChangesInObject()
		{
			clsGanttItem item = this.activeGanttVBNCtl1.GanttItems.get_Item(currentDetail[6] + "-" + currentDetail[7] + "-" + currentDetail[8]);
			
			string strStartTime = this.timeCtrlTimeStart.toString(TimeCtrl.HHMM24);
			int hours = int.Parse(strStartTime.Substring(0,2));
			int minutes = int.Parse(strStartTime.Substring(3,2));
			DateTime startTime = DateTime.Today.AddHours (hours).AddMinutes(minutes);
	
			string strEndTime = this.timeCtrlTimeEnd.toString(TimeCtrl.HHMM24);
			hours = int.Parse(strEndTime.Substring(0,2));
			minutes = int.Parse(strEndTime.Substring(3,2));
			DateTime endTime = DateTime.Today.AddHours (hours).AddMinutes(minutes);
		
			if ((strStartTime.Equals(currentDetail[7]) && strEndTime.Equals(currentDetail[8])) || validateDetail(true, false))
			{
				item.StartDate = startTime;
				item.EndDate = endTime;
				item.Key = this.comboBoxStartlDay.SelectedIndex.ToString() + "-" + this.timeCtrlTimeStart.toString (TimeCtrl.HHMM24) + "-" + this.timeCtrlTimeEnd.toString(TimeCtrl.HHMM24);
				item.Caption = TimeCodes.getInstance().getTimeCode(this.comboBoxTmTypes.SelectedValue.ToString()).getDes();
				if (chkOverTime.Checked)
				{
					item.StyleIndex = Shift.SHIFT_TYPE_OVER_TIME + "-" + this.comboBoxTmTypes.SelectedValue.ToString();
					item.Picture = getImagePath() + "\\Exclamation.bmp";
				}
				else
				{
					item.StyleIndex = Shift.SHIFT_TYPE_STANDARD + "-" + this.comboBoxTmTypes.SelectedValue.ToString();
					item.Picture = "";
				}
				this.activeGanttVBNCtl1.Refresh();

				shift.removeDayDetailByTimeSpan (int.Parse(currentDetail[6]), currentDetail[7], currentDetail[8]);
				shift.addDayDetail (this.comboBoxStartlDay.SelectedIndex,this.comboBoxTmTypes.SelectedValue.ToString(),strStartTime, strEndTime, txtBoxTotalDetailHours.Value, chkOverTime.Checked ? Shift.SHIFT_TYPE_OVER_TIME : Shift.SHIFT_TYPE_STANDARD);

				currentDetail[5]  = this.comboBoxTmTypes.SelectedValue.ToString();
				currentDetail[6]  = this.comboBoxStartlDay.SelectedIndex.ToString();
				currentDetail[7]  = this.timeCtrlTimeStart.toString(TimeCtrl.HHMM24);
				currentDetail[8]  = this.timeCtrlTimeEnd.toString(TimeCtrl.HHMM24);
				currentDetail[9]  = this.txtBoxTotalDetailHours.ToString();
				currentDetail[10] = this.chkOverTime.Checked ? Shift.SHIFT_TYPE_OVER_TIME : Shift.SHIFT_TYPE_STANDARD;
			}
			else
			{
				detailToScreen ();
			}
		}

		private bool validateDetail(bool alreadyExists, bool allWeek)
		{
			if (this.timeCtrlTimeStart.toString(TimeCtrl.HHMM24).CompareTo(this.timeCtrlTimeEnd.toString(TimeCtrl.HHMM24)) >= 0)
			{
				MessageBox.Show ("The ending time must be after the starting time.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			string[][] details = null;
			if (allWeek)
				details = shift.getDetails ();
			else
				details = shift.getDaysDetail (comboBoxStartlDay.SelectedIndex);
			string strStartTime = this.timeCtrlTimeStart.toString(TimeCtrl.HHMM24);
			string strEndTime = this.timeCtrlTimeEnd.toString(TimeCtrl.HHMM24);
			for (int i=0; i<details.Length; i++)
			{
				if (!alreadyExists || !details[i][7].Equals(currentDetail[7]))
				{
					bool good = false;
					if ((details[i][7].CompareTo (strStartTime) <= 0) && (details[i][8].CompareTo (strStartTime) <= 0))
						good = true;
					if ((details[i][7].CompareTo (strEndTime) >= 0) && (details[i][8].CompareTo (strEndTime) >= 0))
						good = true;
					if (!good)
					{
						MessageBox.Show ("This detail is in conflict with another detail of the same day","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
						return false;
					}
				}
			}
			return true;
		}

		private void comboBoxTmTypes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (changing)
				impactChangesInObject();
		}

		private void chkOverTime_CheckedChanged(object sender, System.EventArgs e)
		{
			if (changing)
				impactChangesInObject();
		}

		private void timeCtrlTimeStart_ValueChanged(object sender, System.EventArgs e)
		{
			if (changing)
				impactChangesInObject();
			calculateTotalHours();
		}

		private void timeCtrlTimeEnd_ValueChanged(object sender, System.EventArgs e)
		{
			if (changing)
				impactChangesInObject();
			calculateTotalHours();
		}

		private void calculateTotalHours()
		{
			decimal totalHours = timeCtrlTimeEnd.Value.Hour - timeCtrlTimeStart.Value.Hour;
			totalHours += (timeCtrlTimeEnd.Value.Minute - timeCtrlTimeStart.Value.Minute) / 60M;
			txtBoxTotalDetailHours.Value = totalHours;
		}

		private void buttonClear_Click(object sender, System.EventArgs e)
		{
			this.clearDetail();
		}

		private void clearDetail()
		{
			changing = false;
			btnDeleteDetail.Enabled = false;
			activeGanttVBNCtl1.SelectedGanttItemIndex = nullSelection;
			comboBoxStartlDay.SelectedIndex = 0;
			comboBoxStartlDay.Enabled = true;
			comboBoxTmTypes.SelectedIndex = 0;
			timeCtrlTimeStart.setTime (DateTime.Today);
			timeCtrlTimeEnd.setTime (DateTime.Today);
			btnNewDetail.Enabled = true;
			activeGanttVBNCtl1.Refresh();
			chkBoxApplyAllWeek.Enabled = true;
			this.chkOverTime.Checked = rdoButtonOverTime.Checked;
		}

		private void buttonNew_Click(object sender, System.EventArgs e)
		{
			this.addNewDetail();
		}

		private void addNewDetail()
		{
			string strStartTime = this.timeCtrlTimeStart.toString(TimeCtrl.HHMM24);
			int hours = int.Parse(strStartTime.Substring(0,2));
			int minutes = int.Parse(strStartTime.Substring(3,2));
			DateTime startTime = DateTime.Today.AddHours (hours).AddMinutes(minutes);
		
			string strEndTime = this.timeCtrlTimeEnd.toString(TimeCtrl.HHMM24);
			hours = int.Parse(strEndTime.Substring(0,2));
			minutes = int.Parse(strEndTime.Substring(3,2));
			DateTime endTime = DateTime.Today.AddHours (hours).AddMinutes(minutes);
			if (chkBoxApplyAllWeek.Checked)
			{
				if (validateDetail(false, true))
				{
					for (int i=1; i<=5; i++)
					{
						this.activeGanttVBNCtl1.GanttItems.Add (TimeCodes.getInstance().getTimeCode(this.comboBoxTmTypes.SelectedValue.ToString()).getDes(), "DAY" + i.ToString(), startTime, endTime, i.ToString() + "-" + strStartTime + "-" + strEndTime, (chkOverTime.Checked ? Shift.SHIFT_TYPE_OVER_TIME : Shift.SHIFT_TYPE_STANDARD) + "-" + this.comboBoxTmTypes.SelectedValue.ToString(), "", "0");
						clsGanttItem item = this.activeGanttVBNCtl1.GanttItems.get_Item (i.ToString() + "-" + strStartTime + "-" + strEndTime);
						item.AllowedMovement = (AGVBN20.Globals.E_MOVEMENTTYPE)1;
						if (this.chkOverTime.Checked)
							item.Picture = getImagePath() + "\\Exclamation.bmp";

						shift.addDayDetail (i,this.comboBoxTmTypes.SelectedValue.ToString(),strStartTime, strEndTime, txtBoxTotalDetailHours.Value, chkOverTime.Checked ? Shift.SHIFT_TYPE_OVER_TIME : Shift.SHIFT_TYPE_STANDARD);
					}
					this.clearDetail();
				}
			}
			else
			{
			
				if (validateDetail(false, false))
				{
					this.activeGanttVBNCtl1.GanttItems.Add (TimeCodes.getInstance().getTimeCode(this.comboBoxTmTypes.SelectedValue.ToString()).getDes(), "DAY" + this.comboBoxStartlDay.SelectedIndex.ToString(), startTime, endTime, this.comboBoxStartlDay.SelectedIndex.ToString() + "-" + strStartTime + "-" + strEndTime, (chkOverTime.Checked ? Shift.SHIFT_TYPE_OVER_TIME : Shift.SHIFT_TYPE_STANDARD) + "-" + this.comboBoxTmTypes.SelectedValue.ToString(), "", "0");
					clsGanttItem item = this.activeGanttVBNCtl1.GanttItems.get_Item (this.comboBoxStartlDay.SelectedIndex.ToString() + "-" + strStartTime + "-" + strEndTime);
					item.AllowedMovement = (AGVBN20.Globals.E_MOVEMENTTYPE)1;
					if (this.chkOverTime.Checked)
						item.Picture = getImagePath() + "\\Exclamation.bmp";

					shift.addDayDetail (this.comboBoxStartlDay.SelectedIndex,this.comboBoxTmTypes.SelectedValue.ToString(),strStartTime, strEndTime, txtBoxTotalDetailHours.Value, chkOverTime.Checked ? Shift.SHIFT_TYPE_OVER_TIME : Shift.SHIFT_TYPE_STANDARD);

					currentDetail = shift.getDayDetailByTimeSpan (this.comboBoxStartlDay.SelectedIndex,strStartTime, strEndTime);
					this.activeGanttVBNCtl1.SelectedGanttItemIndex = item.Index;

					changing = true;
					btnNewDetail.Enabled = false;
				}
			}
		}

		private void btnClearShift_Click(object sender, System.EventArgs e)
		{
			this.clearForm();
		}

		private void clearForm()
		{
			changing = false;
			isUpdate = false;
			shift = coreFactory.createShift();

			activeGanttVBNCtl1.GanttItems.Clear();
			
			this.activeGanttVBNCtl1.GanttItems.Add ("","DAY0",DateTime.Today.AddDays(-1),DateTime.Today.AddDays(-1).AddHours(1),"NULL","0","","0");

			timeCtrlTimeStart.setTime (DateTime.Today);
			timeCtrlTimeStart.setTime (DateTime.Today);

			btnDelete.Enabled = false;
			btnDeleteDetail.Enabled = false;
			btnNewDetail.Enabled = true;

			comboBoxStartlDay.SelectedIndex = -1;
			comboBoxTmTypes.SelectedIndex = -1;

			txtBoxCompanyCode.Text = "";
			txtBoxCompanyName.Text = "";
			txtBoxPltCode.Text = "";
			txtBoxPltName.Text = "";
			txtBoxDeptCode.Text = "";
			txtBoxDeptName.Text = "";
			txtBoxShiftCode.Text = "";
			txtBoxShiftName.Text = "";

			rdoButtonActive.Checked = true;
			rdoButtonStandard.Checked = true;

			dTimePickerStrPeriod.Value = DateTime.Today;
			dTimePickerEndPeriod.Value = DateTime.Today;

			txtBoxShf.Text = "";
			txtBoxDb.Text = Configuration.DftDataBase;
			txtBoxShf.ReadOnly = false;
			txtBoxDb.ReadOnly = false;

			txtBoxEmpNumD.Value = 0;
			txtBoxEmpNumT.Value = 0;
			txtBoxEmpNumI.Value = 0;
			txtBoxEmpNumTI.Value = 0;

			txtBoxMachDirCost.Value = 0;
			txtBoxLabIndCost.Value = 0;
			txtBoxLabDirCost.Value = 0;
			txtBoxLabTempCost.Value = 0;

			txtBoxMachNum.Value = 0;
			txtBoxRegTime.Text = "";
			txtBoxDes.Text = "";

			btnCompanySearch.Enabled = true;
			btnPlantSearch.Enabled = true;
			btnDeptSearch.Enabled = true;
			btnShiftSearch.Enabled = true;

			btnClearShift.Enabled = false;
		}

		private void btnDeleteDetail_Click(object sender, System.EventArgs e)
		{
			if (changing && MessageBox.Show ("The detail will be deleted.\nAre you sure?","Confirmation",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				activeGanttVBNCtl1.GanttItems.Remove(activeGanttVBNCtl1.SelectedGanttItemIndex.ToString());
				shift.removeDayDetailByTimeSpan (int.Parse(currentDetail[6]), currentDetail[7], currentDetail[8]);
				clearDetail();
			}
		}

		public void setNewParameters (string db, int company, string plant, string dept)
		{
			this.txtBoxDb.Text = db;
			this.txtBoxCompanyCode.Text = company.ToString();
			this.txtBoxPltCode.Text = plant;
			this.txtBoxDeptCode.Text = dept;
			this.txtBoxShiftCode.Text = "";
			this.loadSearchs();
			oneOperation = true;
			this.btnCompanySearch.Enabled = false;
			this.btnPlantSearch.Enabled = false;
			this.btnDeptSearch.Enabled = false;
			this.btnShiftSearch.Enabled = false;
		}

		public void setUpdateParameters (string db, int company, string plant, string dept, string shf)
		{
			this.txtBoxDb.Text = db;
			this.txtBoxCompanyCode.Text = company.ToString();
			this.txtBoxPltCode.Text = plant;
			this.txtBoxDeptCode.Text = dept;
			this.txtBoxShiftCode.Text = shf;
			this.loadSearchs();
			objectToScreen(db, company, plant, dept, shf);
			this.btnClearShift.Enabled = false;
			oneOperation = true;
		}

		private void loadSearchs()
		{
			Company company = coreFactory.readCompany(txtBoxDb.Text,int.Parse(txtBoxCompanyCode.Text));
			txtBoxCompanyName.Text = (company == null) ? "" : company.getName();

			Plt plant = coreFactory.readPlt(txtBoxDb.Text,int.Parse(txtBoxCompanyCode.Text),txtBoxPltCode.Text);
			txtBoxPltName.Text = (plant == null) ? "" : plant.getPltName();
			
			Departament department = coreFactory.readDepartament(txtBoxPltCode.Text,txtBoxDeptCode.Text);
			txtBoxDeptName.Text = (department == null) ? "" : department.getDes1();

			Shift auxShift = coreFactory.readShift(txtBoxDb.Text,int.Parse(txtBoxCompanyCode.Text),txtBoxPltCode.Text,txtBoxDeptCode.Text,txtBoxShiftCode.Text);
			txtBoxShiftName.Text = (auxShift == null) ? "" : auxShift.getDes();
		}

		private void rdoButtonStandard_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdoButtonStandard.Checked)
			{
				chkOverTime.Checked = false;
				chkOverTime.Enabled = false;
				bool changes = false;
				string[][] detail = shift.getDetails ();
				for (int i=0; i<detail.Length; i++)
				{
					if (!detail[i][10].Equals(Shift.SHIFT_TYPE_STANDARD))
					{
						shift.removeDayDetailByTimeSpan(int.Parse(detail[i][6]),detail[i][7],detail[i][8]);
						shift.addDayDetail (int.Parse(detail[i][6]),detail[i][5],detail[i][7],detail[i][8],decimal.Parse(detail[i][9]),Shift.SHIFT_TYPE_STANDARD);
						changes = true;
					}
				}
				if (changes)
					loadGridData();
			}
		}

		private void rdoButtonOverTime_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdoButtonOverTime.Checked)
			{
				chkOverTime.Checked = true;
				chkOverTime.Enabled = false;
				bool changes = false;
				string[][] detail = shift.getDetails ();
				for (int i=0; i<detail.Length; i++)
				{
					if (!detail[i][10].Equals(Shift.SHIFT_TYPE_OVER_TIME))
					{
						shift.removeDayDetailByTimeSpan(int.Parse(detail[i][6]),detail[i][7],detail[i][8]);
						shift.addDayDetail (int.Parse(detail[i][6]),detail[i][5],detail[i][7],detail[i][8],decimal.Parse(detail[i][9]),Shift.SHIFT_TYPE_OVER_TIME);
						changes = true;
					}
				}
				if (changes)
					loadGridData();
			}
		}

		private void rdoButtonMixed_CheckedChanged(object sender, System.EventArgs e)
		{
			chkOverTime.Enabled = true;
		}

		private void activeGanttVBNCtl1_GanttItemChanged(int Index, int ChangeType)
		{
			if (ChangeType == 2)
				this.timeCtrlTimeStart.Value = this.activeGanttVBNCtl1.GanttItems.get_Item(Index.ToString()).StartDate;
			else if (ChangeType == 3)
				this.timeCtrlTimeEnd.Value = this.activeGanttVBNCtl1.GanttItems.get_Item(Index.ToString()).EndDate;
			else if (ChangeType == 1)
			{
				DateTime startTime = this.activeGanttVBNCtl1.GanttItems.get_Item(Index.ToString()).StartDate;
				DateTime endTime = this.activeGanttVBNCtl1.GanttItems.get_Item(Index.ToString()).EndDate;
				this.changing = false;
				this.timeCtrlTimeStart.Value = startTime;
				this.changing = true;
				this.timeCtrlTimeEnd.Value = endTime;
			}
		}

		private void activeGanttVBNCtl1_GanttItemAdded(int Index)
		{
			DateTime startTime = this.activeGanttVBNCtl1.GanttItems.get_Item(Index.ToString()).StartDate;
			DateTime endTime = this.activeGanttVBNCtl1.GanttItems.get_Item(Index.ToString()).EndDate;
			int day = int.Parse(this.activeGanttVBNCtl1.GanttItems.get_Item(Index.ToString()).RowKey.Substring(3,1));
			this.activeGanttVBNCtl1.GanttItems.Remove (Index.ToString());

			bool applyToAllWeek = this.chkBoxApplyAllWeek.Checked;
			this.chkBoxApplyAllWeek.Checked = false;
			int timeType = this.comboBoxTmTypes.SelectedIndex;
			int oldDay = this.comboBoxStartlDay.SelectedIndex;
			bool overTime = this.chkOverTime.Checked;
			this.clearDetail();

			this.chkOverTime.Checked = overTime;
			this.comboBoxTmTypes.SelectedIndex = timeType;
			this.timeCtrlTimeStart.Value = startTime;
			this.timeCtrlTimeEnd.Value = endTime;
			this.comboBoxStartlDay.SelectedIndex = day;
			this.addNewDetail();

			this.chkBoxApplyAllWeek.Checked = applyToAllWeek;
		}

	}
}
