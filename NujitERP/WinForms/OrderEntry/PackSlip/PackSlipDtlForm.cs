using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Nujit.NujitERP.WinForms.OrderEntry.PackSlip
{
	/// <summary>
	/// Summary description for PackSlipDtlForm.
	/// </summary>
	public class PackSlipDtlForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.GroupBox gBoxKeyData;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private NujitCustomWinControls.NumericTextBox numericTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lPStatus;
        private NujitCustomWinControls.NumericTextBox ntbP_PackSlipNum;
        private System.Windows.Forms.Label lPPackSlipNum;
        private NujitCustomWinControls.NumericTextBox ntboxP_Company;
        private System.Windows.Forms.TextBox tBoxP_Plant;
        private System.Windows.Forms.TextBox tBoxP_Db;
        private System.Windows.Forms.Label lPPlant;
        private System.Windows.Forms.Label lPCompany;
        private System.Windows.Forms.Label lPDb;
        private NujitCustomWinControls.NumericTextBox ntbP_MBol;
        private System.Windows.Forms.Label lPMBOL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private NujitCustomWinControls.NumericTextBox numericTextBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label9;
        private NujitCustomWinControls.NumericTextBox numericTextBox3;
        private System.Windows.Forms.Label label11;
        private NujitCustomWinControls.NumericTextBox numericTextBox4;
        private System.Windows.Forms.Label label13;
        private NujitCustomWinControls.NumericTextBox numericTextBox5;
        private System.Windows.Forms.Label label14;
        private NujitCustomWinControls.NumericTextBox numericTextBox6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label17;
        private NujitCustomWinControls.NumericTextBox numericTextBox7;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label10;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PackSlipDtlForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.gBoxKeyData = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericTextBox1 = new NujitCustomWinControls.NumericTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lPStatus = new System.Windows.Forms.Label();
            this.ntbP_PackSlipNum = new NujitCustomWinControls.NumericTextBox();
            this.lPPackSlipNum = new System.Windows.Forms.Label();
            this.ntboxP_Company = new NujitCustomWinControls.NumericTextBox();
            this.tBoxP_Plant = new System.Windows.Forms.TextBox();
            this.tBoxP_Db = new System.Windows.Forms.TextBox();
            this.lPPlant = new System.Windows.Forms.Label();
            this.lPCompany = new System.Windows.Forms.Label();
            this.lPDb = new System.Windows.Forms.Label();
            this.ntbP_MBol = new NujitCustomWinControls.NumericTextBox();
            this.lPMBOL = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericTextBox2 = new NujitCustomWinControls.NumericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericTextBox3 = new NujitCustomWinControls.NumericTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numericTextBox4 = new NujitCustomWinControls.NumericTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numericTextBox5 = new NujitCustomWinControls.NumericTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.numericTextBox6 = new NujitCustomWinControls.NumericTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.numericTextBox7 = new NujitCustomWinControls.NumericTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gBoxKeyData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // gBoxKeyData
            // 
            this.gBoxKeyData.Controls.Add(this.textBox5);
            this.gBoxKeyData.Controls.Add(this.label1);
            this.gBoxKeyData.Controls.Add(this.checkBox1);
            this.gBoxKeyData.Controls.Add(this.checkBox2);
            this.gBoxKeyData.Controls.Add(this.dateTimePicker2);
            this.gBoxKeyData.Controls.Add(this.dateTimePicker1);
            this.gBoxKeyData.Controls.Add(this.label12);
            this.gBoxKeyData.Controls.Add(this.label6);
            this.gBoxKeyData.Controls.Add(this.numericTextBox1);
            this.gBoxKeyData.Controls.Add(this.label4);
            this.gBoxKeyData.Controls.Add(this.comboBox1);
            this.gBoxKeyData.Controls.Add(this.lPStatus);
            this.gBoxKeyData.Controls.Add(this.ntbP_PackSlipNum);
            this.gBoxKeyData.Controls.Add(this.lPPackSlipNum);
            this.gBoxKeyData.Controls.Add(this.ntboxP_Company);
            this.gBoxKeyData.Controls.Add(this.tBoxP_Plant);
            this.gBoxKeyData.Controls.Add(this.tBoxP_Db);
            this.gBoxKeyData.Controls.Add(this.lPPlant);
            this.gBoxKeyData.Controls.Add(this.lPCompany);
            this.gBoxKeyData.Controls.Add(this.lPDb);
            this.gBoxKeyData.Controls.Add(this.ntbP_MBol);
            this.gBoxKeyData.Controls.Add(this.lPMBOL);
            this.gBoxKeyData.Controls.Add(this.textBox7);
            this.gBoxKeyData.Controls.Add(this.label10);
            this.gBoxKeyData.Location = new System.Drawing.Point(8, 0);
            this.gBoxKeyData.Name = "gBoxKeyData";
            this.gBoxKeyData.Size = new System.Drawing.Size(688, 104);
            this.gBoxKeyData.TabIndex = 3;
            this.gBoxKeyData.TabStop = false;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(440, 56);
            this.textBox5.MaxLength = 10;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(88, 20);
            this.textBox5.TabIndex = 85;
            this.textBox5.Text = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(336, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 84;
            this.label1.Text = "Carrier";
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(544, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 83;
            this.checkBox1.Text = "Picked";
            // 
            // checkBox2
            // 
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(544, 16);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(112, 16);
            this.checkBox2.TabIndex = 82;
            this.checkBox2.Text = "Pack Skip Printed";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(440, 36);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(88, 20);
            this.dateTimePicker2.TabIndex = 81;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(440, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(88, 20);
            this.dateTimePicker1.TabIndex = 80;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(336, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 20);
            this.label12.TabIndex = 79;
            this.label12.Text = "Required Ship Time";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(336, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 20);
            this.label6.TabIndex = 78;
            this.label6.Text = "Required Ship Date";
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Location = new System.Drawing.Point(232, 16);
            this.numericTextBox1.Maximum = new System.Decimal(new int[] {
                                                                            1215752191,
                                                                            23,
                                                                            0,
                                                                            0});
            this.numericTextBox1.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.ReadOnly = true;
            this.numericTextBox1.Size = new System.Drawing.Size(96, 20);
            this.numericTextBox1.TabIndex = 77;
            this.numericTextBox1.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(168, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 76;
            this.label4.Text = "Bol#";
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.Items.AddRange(new object[] {
                                                           "1 - Yes, Posted",
                                                           "2 - Not, Posted",
                                                           "3 - In use"});
            this.comboBox1.Location = new System.Drawing.Point(232, 56);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(96, 21);
            this.comboBox1.TabIndex = 58;
            this.comboBox1.Text = "1 - Yes, Posted";
            // 
            // lPStatus
            // 
            this.lPStatus.Location = new System.Drawing.Point(168, 56);
            this.lPStatus.Name = "lPStatus";
            this.lPStatus.Size = new System.Drawing.Size(48, 20);
            this.lPStatus.TabIndex = 57;
            this.lPStatus.Text = "Status";
            // 
            // ntbP_PackSlipNum
            // 
            this.ntbP_PackSlipNum.Location = new System.Drawing.Point(80, 16);
            this.ntbP_PackSlipNum.Maximum = new System.Decimal(new int[] {
                                                                             1215752191,
                                                                             23,
                                                                             0,
                                                                             0});
            this.ntbP_PackSlipNum.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.ntbP_PackSlipNum.Name = "ntbP_PackSlipNum";
            this.ntbP_PackSlipNum.ReadOnly = true;
            this.ntbP_PackSlipNum.Size = new System.Drawing.Size(72, 20);
            this.ntbP_PackSlipNum.TabIndex = 54;
            this.ntbP_PackSlipNum.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // lPPackSlipNum
            // 
            this.lPPackSlipNum.Location = new System.Drawing.Point(8, 16);
            this.lPPackSlipNum.Name = "lPPackSlipNum";
            this.lPPackSlipNum.Size = new System.Drawing.Size(64, 20);
            this.lPPackSlipNum.TabIndex = 53;
            this.lPPackSlipNum.Text = "Pack Slip #";
            // 
            // ntboxP_Company
            // 
            this.ntboxP_Company.Location = new System.Drawing.Point(80, 56);
            this.ntboxP_Company.Maximum = new System.Decimal(new int[] {
                                                                           999,
                                                                           0,
                                                                           0,
                                                                           0});
            this.ntboxP_Company.Minimum = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            this.ntboxP_Company.Name = "ntboxP_Company";
            this.ntboxP_Company.ReadOnly = true;
            this.ntboxP_Company.Size = new System.Drawing.Size(72, 20);
            this.ntboxP_Company.TabIndex = 7;
            this.ntboxP_Company.Value = new System.Decimal(new int[] {
                                                                         0,
                                                                         0,
                                                                         0,
                                                                         0});
            // 
            // tBoxP_Plant
            // 
            this.tBoxP_Plant.Location = new System.Drawing.Point(80, 76);
            this.tBoxP_Plant.MaxLength = 10;
            this.tBoxP_Plant.Name = "tBoxP_Plant";
            this.tBoxP_Plant.ReadOnly = true;
            this.tBoxP_Plant.Size = new System.Drawing.Size(72, 20);
            this.tBoxP_Plant.TabIndex = 6;
            this.tBoxP_Plant.Text = "";
            // 
            // tBoxP_Db
            // 
            this.tBoxP_Db.Location = new System.Drawing.Point(80, 36);
            this.tBoxP_Db.MaxLength = 10;
            this.tBoxP_Db.Name = "tBoxP_Db";
            this.tBoxP_Db.ReadOnly = true;
            this.tBoxP_Db.Size = new System.Drawing.Size(72, 20);
            this.tBoxP_Db.TabIndex = 4;
            this.tBoxP_Db.Text = "";
            // 
            // lPPlant
            // 
            this.lPPlant.Location = new System.Drawing.Point(8, 76);
            this.lPPlant.Name = "lPPlant";
            this.lPPlant.Size = new System.Drawing.Size(40, 20);
            this.lPPlant.TabIndex = 2;
            this.lPPlant.Text = "Plant";
            // 
            // lPCompany
            // 
            this.lPCompany.Location = new System.Drawing.Point(8, 56);
            this.lPCompany.Name = "lPCompany";
            this.lPCompany.Size = new System.Drawing.Size(64, 20);
            this.lPCompany.TabIndex = 1;
            this.lPCompany.Text = "Company";
            // 
            // lPDb
            // 
            this.lPDb.Location = new System.Drawing.Point(8, 36);
            this.lPDb.Name = "lPDb";
            this.lPDb.Size = new System.Drawing.Size(64, 20);
            this.lPDb.TabIndex = 0;
            this.lPDb.Text = "Data Base";
            // 
            // ntbP_MBol
            // 
            this.ntbP_MBol.Location = new System.Drawing.Point(232, 36);
            this.ntbP_MBol.Maximum = new System.Decimal(new int[] {
                                                                      1215752191,
                                                                      23,
                                                                      0,
                                                                      0});
            this.ntbP_MBol.Minimum = new System.Decimal(new int[] {
                                                                      0,
                                                                      0,
                                                                      0,
                                                                      0});
            this.ntbP_MBol.Name = "ntbP_MBol";
            this.ntbP_MBol.ReadOnly = true;
            this.ntbP_MBol.Size = new System.Drawing.Size(96, 20);
            this.ntbP_MBol.TabIndex = 55;
            this.ntbP_MBol.Value = new System.Decimal(new int[] {
                                                                    0,
                                                                    0,
                                                                    0,
                                                                    0});
            // 
            // lPMBOL
            // 
            this.lPMBOL.Location = new System.Drawing.Point(168, 36);
            this.lPMBOL.Name = "lPMBOL";
            this.lPMBOL.Size = new System.Drawing.Size(64, 20);
            this.lPMBOL.TabIndex = 14;
            this.lPMBOL.Text = "Master Bol";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Location = new System.Drawing.Point(12, 376);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 48);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(336, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            // 
            // btnAdd
            // 
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnAdd.Location = new System.Drawing.Point(512, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(424, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(600, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(120, 16);
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(72, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Part";
            // 
            // numericTextBox2
            // 
            this.numericTextBox2.Location = new System.Drawing.Point(120, 40);
            this.numericTextBox2.Maximum = new System.Decimal(new int[] {
                                                                            999,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox2.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox2.Name = "numericTextBox2";
            this.numericTextBox2.ReadOnly = true;
            this.numericTextBox2.Size = new System.Drawing.Size(72, 20);
            this.numericTextBox2.TabIndex = 10;
            this.numericTextBox2.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Seq";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(120, 64);
            this.textBox2.MaxLength = 10;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 20);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Revision";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(560, 16);
            this.textBox3.MaxLength = 10;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(72, 20);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(480, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Customer Part";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(120, 88);
            this.textBox4.MaxLength = 10;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(88, 20);
            this.textBox4.TabIndex = 16;
            this.textBox4.Text = "";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Manufacturer";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(120, 112);
            this.textBox6.MaxLength = 10;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(88, 20);
            this.textBox6.TabIndex = 18;
            this.textBox6.Text = "";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(16, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "Manufacturer Part";
            // 
            // numericTextBox3
            // 
            this.numericTextBox3.Location = new System.Drawing.Point(576, 16);
            this.numericTextBox3.Maximum = new System.Decimal(new int[] {
                                                                            999,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox3.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox3.Name = "numericTextBox3";
            this.numericTextBox3.Size = new System.Drawing.Size(72, 20);
            this.numericTextBox3.TabIndex = 22;
            this.numericTextBox3.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(432, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 16);
            this.label11.TabIndex = 21;
            this.label11.Text = "Total Order Qty Remaining";
            // 
            // numericTextBox4
            // 
            this.numericTextBox4.Location = new System.Drawing.Point(112, 16);
            this.numericTextBox4.Maximum = new System.Decimal(new int[] {
                                                                            999,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox4.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox4.Name = "numericTextBox4";
            this.numericTextBox4.Size = new System.Drawing.Size(72, 20);
            this.numericTextBox4.TabIndex = 24;
            this.numericTextBox4.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 16);
            this.label13.TabIndex = 23;
            this.label13.Text = "Qty Shipped";
            // 
            // numericTextBox5
            // 
            this.numericTextBox5.Location = new System.Drawing.Point(112, 40);
            this.numericTextBox5.Maximum = new System.Decimal(new int[] {
                                                                            999,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox5.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox5.Name = "numericTextBox5";
            this.numericTextBox5.Size = new System.Drawing.Size(72, 20);
            this.numericTextBox5.TabIndex = 26;
            this.numericTextBox5.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 16);
            this.label14.TabIndex = 25;
            this.label14.Text = "Qty  to Ship";
            // 
            // numericTextBox6
            // 
            this.numericTextBox6.Location = new System.Drawing.Point(344, 16);
            this.numericTextBox6.Maximum = new System.Decimal(new int[] {
                                                                            999,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox6.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox6.Name = "numericTextBox6";
            this.numericTextBox6.Size = new System.Drawing.Size(72, 20);
            this.numericTextBox6.TabIndex = 28;
            this.numericTextBox6.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(208, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 16);
            this.label15.TabIndex = 27;
            this.label15.Text = "Cumulative Qty";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(120, 136);
            this.textBox8.MaxLength = 10;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(184, 20);
            this.textBox8.TabIndex = 30;
            this.textBox8.Text = "";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(16, 136);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 20);
            this.label16.TabIndex = 29;
            this.label16.Text = "Shipping Location";
            // 
            // checkBox3
            // 
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(160, 168);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(56, 24);
            this.checkBox3.TabIndex = 31;
            this.checkBox3.Text = "Bin";
            // 
            // checkBox4
            // 
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(224, 168);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(72, 24);
            this.checkBox4.TabIndex = 32;
            this.checkBox4.Text = "Picked";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(184, 336);
            this.textBox9.MaxLength = 10;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(72, 20);
            this.textBox9.TabIndex = 34;
            this.textBox9.Text = "";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(64, 336);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(120, 20);
            this.label17.TabIndex = 33;
            this.label17.Text = "Individually Packeged";
            // 
            // numericTextBox7
            // 
            this.numericTextBox7.Location = new System.Drawing.Point(392, 136);
            this.numericTextBox7.Maximum = new System.Decimal(new int[] {
                                                                            999,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox7.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox7.Name = "numericTextBox7";
            this.numericTextBox7.Size = new System.Drawing.Size(72, 20);
            this.numericTextBox7.TabIndex = 36;
            this.numericTextBox7.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(352, 136);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 16);
            this.label18.TabIndex = 35;
            this.label18.Text = "Pick #";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(336, 80);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 20);
            this.label19.TabIndex = 37;
            this.label19.Text = "Cartons";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(448, 80);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 20);
            this.label20.TabIndex = 39;
            this.label20.Text = "Cases";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(560, 80);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 20);
            this.label21.TabIndex = 41;
            this.label21.Text = "Pallets";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(320, 16);
            this.textBox13.MaxLength = 10;
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(136, 20);
            this.textBox13.TabIndex = 44;
            this.textBox13.Text = "";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(264, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 20);
            this.label22.TabIndex = 43;
            this.label22.Text = "Serial #";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(512, 160);
            this.button1.Name = "button1";
            this.button1.TabIndex = 45;
            this.button1.Text = "Serial/Lot";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(600, 160);
            this.button2.Name = "button2";
            this.button2.TabIndex = 46;
            this.button2.Text = "Packaging";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.checkBox5);
            this.groupBox2.Controls.Add(this.numericUpDown3);
            this.groupBox2.Controls.Add(this.numericUpDown2);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.numericTextBox2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBox13);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.textBox9);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.numericTextBox7);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(8, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(688, 200);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericTextBox4);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.numericTextBox5);
            this.groupBox3.Controls.Add(this.numericTextBox6);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.numericTextBox3);
            this.groupBox3.Location = new System.Drawing.Point(8, 304);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(688, 72);
            this.groupBox3.TabIndex = 48;
            this.groupBox3.TabStop = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(504, 80);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown1.TabIndex = 45;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(616, 80);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown2.TabIndex = 46;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(392, 80);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown3.TabIndex = 47;
            // 
            // checkBox5
            // 
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(16, 168);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(144, 24);
            this.checkBox5.TabIndex = 48;
            this.checkBox5.Text = "Individually Packaged";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(216, 88);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 16);
            this.button3.TabIndex = 49;
            this.button3.Text = "...";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(208, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 16);
            this.button4.TabIndex = 50;
            this.button4.Text = "...";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(312, 136);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 16);
            this.button5.TabIndex = 51;
            this.button5.Text = "...";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(640, 16);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(25, 16);
            this.button6.TabIndex = 52;
            this.button6.Text = "...";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(232, 80);
            this.textBox7.MaxLength = 10;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(96, 20);
            this.textBox7.TabIndex = 54;
            this.textBox7.Text = "0";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(168, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 20);
            this.label10.TabIndex = 53;
            this.label10.Text = "Item #";
            // 
            // PackSlipDtlForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(704, 438);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gBoxKeyData);
            this.Name = "PackSlipDtlForm";
            this.Text = "Pack Slip Detail";
            this.gBoxKeyData.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion
	}
}
