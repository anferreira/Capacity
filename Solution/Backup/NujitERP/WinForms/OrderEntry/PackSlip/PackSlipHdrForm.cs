using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Nujit.NujitERP.WinForms.OrderEntry.PackSlip
{
	/// <summary>
	/// Summary description for PackSlipHdrForm.
	/// </summary>
	public class PackSlipHdrForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.GroupBox gBoxKeyData;
        private NujitCustomWinControls.NumericTextBox ntboxP_Company;
        private System.Windows.Forms.TextBox tBoxP_Plant;
        private System.Windows.Forms.TextBox tBoxP_Db;
        private System.Windows.Forms.Label lPPlant;
        private System.Windows.Forms.Label lPCompany;
        private System.Windows.Forms.Label lPDb;
        private NujitCustomWinControls.NumericTextBox ntbP_PackSlipNum;
        private System.Windows.Forms.Label lPPackSlipNum;
        private System.Windows.Forms.Label lPPackSlipType;
        private System.Windows.Forms.ComboBox cBoxP_PackSlipType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDetail;
        private System.Windows.Forms.DataGrid dGridPackSlipDtl;
        private System.Windows.Forms.Button btnDeleteDtl;
        private System.Windows.Forms.Button btnEditDtl;
        private System.Windows.Forms.Button btnAddDtl;
        private System.Windows.Forms.TabPage tabPageShipping;
        private System.Windows.Forms.TabPage tabPageContainers;
        private System.Windows.Forms.TabPage tabPageParts;
        private System.Windows.Forms.TabPage tabPageAsn;
        private System.Windows.Forms.TabPage tabPageForms;
        private System.Windows.Forms.Label lPBillToCust;
        private System.Windows.Forms.Label lPShipToCust;
        private System.Windows.Forms.Label lPShipToName;
        private System.Windows.Forms.Label lPBillToName;
        private System.Windows.Forms.TextBox tBoxP_ShipToName;
        private System.Windows.Forms.TextBox tBoxP_BilltoName;
        private System.Windows.Forms.TextBox tBoxP_ShipToCust;
        private System.Windows.Forms.TextBox tBoxP_BillToCust;
        private System.Windows.Forms.Button btnSchShipTo;
        private System.Windows.Forms.Button btnSchBillTo;
        private System.Windows.Forms.TextBox tBoxP_BillToPost;
        private System.Windows.Forms.Label lPBillToPost;
        private System.Windows.Forms.DateTimePicker dtpP_ShipDate;
        private System.Windows.Forms.Label lPShipDate;
        private System.Windows.Forms.TextBox tBoxP_ShipVia;
        private System.Windows.Forms.Label lPShipVia;
        private System.Windows.Forms.TextBox tBoxP_BTAdd1;
        private System.Windows.Forms.Label lPBTAdd1;
        private System.Windows.Forms.TextBox tBoxP_BTAdd3;
        private System.Windows.Forms.Label lPBTAdd3;
        private System.Windows.Forms.TextBox tBoxP_BlTAdd2;
        private System.Windows.Forms.Label lPBTAdd2;
        private System.Windows.Forms.TextBox tBoxP_STAdd2;
        private System.Windows.Forms.Label lPSTAdd2;
        private System.Windows.Forms.TextBox tBoxP_STAdd3;
        private System.Windows.Forms.Label lPSTAdd3;
        private System.Windows.Forms.TextBox tBoxP_STAdd1;
        private System.Windows.Forms.Label lPSTAdd1;
        private System.Windows.Forms.GroupBox gBoxBillTo;
        private System.Windows.Forms.GroupBox gBoxShipTo;
        private System.Windows.Forms.TextBox tBoxP_BTProvState;
        private System.Windows.Forms.Label lPBTProvState;
        private System.Windows.Forms.TextBox tboxP_BTCountry;
        private System.Windows.Forms.Label lPBTCountry;
        private System.Windows.Forms.TextBox tBoxP_BTPostZip;
        private System.Windows.Forms.Label lPBTPostZip;
        private System.Windows.Forms.Label lPBTContact;
        private System.Windows.Forms.TextBox tBoxP_BTContact;
        private System.Windows.Forms.Button btnSchBTContact;
        private System.Windows.Forms.Button btnSchStContact;
        private System.Windows.Forms.TextBox tBoxP_STContact;
        private System.Windows.Forms.Label lPSTContact;
        private System.Windows.Forms.TextBox tBoxlP_DTPostZip;
        private System.Windows.Forms.Label lPDTPostZip;
        private System.Windows.Forms.TextBox tBoxP_STCountry;
        private System.Windows.Forms.Label lPSTCountry;
        private System.Windows.Forms.TextBox tBoxP_STProvState;
        private System.Windows.Forms.Label lPSTProvState;
        private System.Windows.Forms.Label lPShipTime;
        private System.Windows.Forms.DateTimePicker dtpP_ShipTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lPShipmentId;
        private System.Windows.Forms.TextBox tBoxP_ShipmentId;
        private System.Windows.Forms.Label lPOrderNum;
        private NujitCustomWinControls.NumericTextBox ntbP_OrderNumber;
        private System.Windows.Forms.Label lPStkLoc;
        private System.Windows.Forms.TextBox tBoxP_StkLoc;
        private System.Windows.Forms.Button schStkLoc;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Label lPMBOL;
        private NujitCustomWinControls.NumericTextBox ntbP_MBol;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lPStatus;
        private System.Windows.Forms.CheckBox cBoxP_PrintInd;
        private System.Windows.Forms.CheckBox cBoxP_ShipInd;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label11;
        private NujitCustomWinControls.NumericTextBox numericTextBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private NujitCustomWinControls.NumericTextBox numericTextBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lPSFAdd4;
        private System.Windows.Forms.TextBox tBoxP_SFAdd4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private NujitCustomWinControls.NumericTextBox numericTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox7;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PackSlipHdrForm()	{
			
			InitializeComponent();
           
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
            this.cBoxP_ShipInd = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lPStatus = new System.Windows.Forms.Label();
            this.cBoxP_PackSlipType = new System.Windows.Forms.ComboBox();
            this.lPPackSlipType = new System.Windows.Forms.Label();
            this.ntbP_PackSlipNum = new NujitCustomWinControls.NumericTextBox();
            this.lPPackSlipNum = new System.Windows.Forms.Label();
            this.ntboxP_Company = new NujitCustomWinControls.NumericTextBox();
            this.tBoxP_Plant = new System.Windows.Forms.TextBox();
            this.tBoxP_Db = new System.Windows.Forms.TextBox();
            this.lPPlant = new System.Windows.Forms.Label();
            this.lPCompany = new System.Windows.Forms.Label();
            this.lPDb = new System.Windows.Forms.Label();
            this.cBoxP_PrintInd = new System.Windows.Forms.CheckBox();
            this.ntbP_MBol = new NujitCustomWinControls.NumericTextBox();
            this.lPMBOL = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageShipping = new System.Windows.Forms.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numericTextBox3 = new NujitCustomWinControls.NumericTextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericTextBox2 = new NujitCustomWinControls.NumericTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.schStkLoc = new System.Windows.Forms.Button();
            this.lPStkLoc = new System.Windows.Forms.Label();
            this.tBoxP_StkLoc = new System.Windows.Forms.TextBox();
            this.ntbP_OrderNumber = new NujitCustomWinControls.NumericTextBox();
            this.lPOrderNum = new System.Windows.Forms.Label();
            this.lPShipmentId = new System.Windows.Forms.Label();
            this.tBoxP_ShipmentId = new System.Windows.Forms.TextBox();
            this.dtpP_ShipDate = new System.Windows.Forms.DateTimePicker();
            this.lPShipTime = new System.Windows.Forms.Label();
            this.dtpP_ShipTime = new System.Windows.Forms.DateTimePicker();
            this.lPShipDate = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gBoxShipTo = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lPShipToCust = new System.Windows.Forms.Label();
            this.btnSchShipTo = new System.Windows.Forms.Button();
            this.tBoxP_ShipToCust = new System.Windows.Forms.TextBox();
            this.tBoxP_ShipToName = new System.Windows.Forms.TextBox();
            this.lPShipToName = new System.Windows.Forms.Label();
            this.tBoxP_STAdd1 = new System.Windows.Forms.TextBox();
            this.tBoxP_STAdd2 = new System.Windows.Forms.TextBox();
            this.lPSTAdd3 = new System.Windows.Forms.Label();
            this.lPSTAdd2 = new System.Windows.Forms.Label();
            this.lPSTAdd1 = new System.Windows.Forms.Label();
            this.tBoxP_STAdd3 = new System.Windows.Forms.TextBox();
            this.tBoxP_ShipVia = new System.Windows.Forms.TextBox();
            this.lPShipVia = new System.Windows.Forms.Label();
            this.btnSchStContact = new System.Windows.Forms.Button();
            this.tBoxP_STContact = new System.Windows.Forms.TextBox();
            this.lPSTContact = new System.Windows.Forms.Label();
            this.tBoxlP_DTPostZip = new System.Windows.Forms.TextBox();
            this.lPDTPostZip = new System.Windows.Forms.Label();
            this.tBoxP_STCountry = new System.Windows.Forms.TextBox();
            this.lPSTCountry = new System.Windows.Forms.Label();
            this.tBoxP_STProvState = new System.Windows.Forms.TextBox();
            this.lPSTProvState = new System.Windows.Forms.Label();
            this.gBoxBillTo = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.lPSFAdd4 = new System.Windows.Forms.Label();
            this.tBoxP_SFAdd4 = new System.Windows.Forms.TextBox();
            this.lPBillToName = new System.Windows.Forms.Label();
            this.tBoxP_BillToCust = new System.Windows.Forms.TextBox();
            this.btnSchBillTo = new System.Windows.Forms.Button();
            this.tBoxP_BilltoName = new System.Windows.Forms.TextBox();
            this.lPBillToCust = new System.Windows.Forms.Label();
            this.lPBTAdd1 = new System.Windows.Forms.Label();
            this.tBoxP_BTAdd1 = new System.Windows.Forms.TextBox();
            this.lPBTAdd3 = new System.Windows.Forms.Label();
            this.tBoxP_BTAdd3 = new System.Windows.Forms.TextBox();
            this.lPBTAdd2 = new System.Windows.Forms.Label();
            this.tBoxP_BlTAdd2 = new System.Windows.Forms.TextBox();
            this.lPBillToPost = new System.Windows.Forms.Label();
            this.tBoxP_BillToPost = new System.Windows.Forms.TextBox();
            this.tboxP_BTCountry = new System.Windows.Forms.TextBox();
            this.tBoxP_BTProvState = new System.Windows.Forms.TextBox();
            this.tBoxP_BTContact = new System.Windows.Forms.TextBox();
            this.tBoxP_BTPostZip = new System.Windows.Forms.TextBox();
            this.btnSchBTContact = new System.Windows.Forms.Button();
            this.lPBTProvState = new System.Windows.Forms.Label();
            this.lPBTCountry = new System.Windows.Forms.Label();
            this.lPBTContact = new System.Windows.Forms.Label();
            this.lPBTPostZip = new System.Windows.Forms.Label();
            this.tabPageContainers = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tabPageDetail = new System.Windows.Forms.TabPage();
            this.btnDeleteDtl = new System.Windows.Forms.Button();
            this.btnEditDtl = new System.Windows.Forms.Button();
            this.btnAddDtl = new System.Windows.Forms.Button();
            this.dGridPackSlipDtl = new System.Windows.Forms.DataGrid();
            this.tabPageAsn = new System.Windows.Forms.TabPage();
            this.tabPageForms = new System.Windows.Forms.TabPage();
            this.tabPageParts = new System.Windows.Forms.TabPage();
            this.gBoxKeyData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageShipping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gBoxShipTo.SuspendLayout();
            this.gBoxBillTo.SuspendLayout();
            this.tabPageContainers.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.tabPageDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridPackSlipDtl)).BeginInit();
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
            this.gBoxKeyData.Controls.Add(this.cBoxP_ShipInd);
            this.gBoxKeyData.Controls.Add(this.comboBox1);
            this.gBoxKeyData.Controls.Add(this.lPStatus);
            this.gBoxKeyData.Controls.Add(this.cBoxP_PackSlipType);
            this.gBoxKeyData.Controls.Add(this.lPPackSlipType);
            this.gBoxKeyData.Controls.Add(this.ntbP_PackSlipNum);
            this.gBoxKeyData.Controls.Add(this.lPPackSlipNum);
            this.gBoxKeyData.Controls.Add(this.ntboxP_Company);
            this.gBoxKeyData.Controls.Add(this.tBoxP_Plant);
            this.gBoxKeyData.Controls.Add(this.tBoxP_Db);
            this.gBoxKeyData.Controls.Add(this.lPPlant);
            this.gBoxKeyData.Controls.Add(this.lPCompany);
            this.gBoxKeyData.Controls.Add(this.lPDb);
            this.gBoxKeyData.Controls.Add(this.cBoxP_PrintInd);
            this.gBoxKeyData.Controls.Add(this.ntbP_MBol);
            this.gBoxKeyData.Controls.Add(this.lPMBOL);
            this.gBoxKeyData.Location = new System.Drawing.Point(8, 8);
            this.gBoxKeyData.Name = "gBoxKeyData";
            this.gBoxKeyData.Size = new System.Drawing.Size(688, 104);
            this.gBoxKeyData.TabIndex = 2;
            this.gBoxKeyData.TabStop = false;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(440, 56);
            this.textBox5.MaxLength = 10;
            this.textBox5.Name = "textBox5";
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
            this.checkBox2.Location = new System.Drawing.Point(544, 16);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(112, 16);
            this.checkBox2.TabIndex = 82;
            this.checkBox2.Text = "Pack Skip Printed";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(440, 36);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(88, 20);
            this.dateTimePicker2.TabIndex = 81;
            // 
            // dateTimePicker1
            // 
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
            // cBoxP_ShipInd
            // 
            this.cBoxP_ShipInd.Checked = true;
            this.cBoxP_ShipInd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxP_ShipInd.Location = new System.Drawing.Point(528, 128);
            this.cBoxP_ShipInd.Name = "cBoxP_ShipInd";
            this.cBoxP_ShipInd.Size = new System.Drawing.Size(72, 16);
            this.cBoxP_ShipInd.TabIndex = 75;
            this.cBoxP_ShipInd.Text = "Ship Ind";
            // 
            // comboBox1
            // 
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
            // cBoxP_PackSlipType
            // 
            this.cBoxP_PackSlipType.Location = new System.Drawing.Point(424, 120);
            this.cBoxP_PackSlipType.Name = "cBoxP_PackSlipType";
            this.cBoxP_PackSlipType.Size = new System.Drawing.Size(88, 21);
            this.cBoxP_PackSlipType.TabIndex = 56;
            this.cBoxP_PackSlipType.Text = "Type1";
            // 
            // lPPackSlipType
            // 
            this.lPPackSlipType.Location = new System.Drawing.Point(336, 128);
            this.lPPackSlipType.Name = "lPPackSlipType";
            this.lPPackSlipType.Size = new System.Drawing.Size(80, 16);
            this.lPPackSlipType.TabIndex = 55;
            this.lPPackSlipType.Text = "Pack Slip Type";
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
            // cBoxP_PrintInd
            // 
            this.cBoxP_PrintInd.Checked = true;
            this.cBoxP_PrintInd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxP_PrintInd.Location = new System.Drawing.Point(528, 112);
            this.cBoxP_PrintInd.Name = "cBoxP_PrintInd";
            this.cBoxP_PrintInd.Size = new System.Drawing.Size(72, 16);
            this.cBoxP_PrintInd.TabIndex = 74;
            this.cBoxP_PrintInd.Text = "Print Ind";
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
            this.groupBox1.Location = new System.Drawing.Point(8, 544);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 48);
            this.groupBox1.TabIndex = 3;
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageShipping);
            this.tabControl1.Controls.Add(this.tabPageContainers);
            this.tabControl1.Controls.Add(this.tabPageDetail);
            this.tabControl1.Controls.Add(this.tabPageAsn);
            this.tabControl1.Controls.Add(this.tabPageForms);
            this.tabControl1.Controls.Add(this.tabPageParts);
            this.tabControl1.Location = new System.Drawing.Point(8, 120);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(688, 408);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPageShipping
            // 
            this.tabPageShipping.Controls.Add(this.textBox3);
            this.tabPageShipping.Controls.Add(this.label2);
            this.tabPageShipping.Controls.Add(this.numericUpDown1);
            this.tabPageShipping.Controls.Add(this.textBox2);
            this.tabPageShipping.Controls.Add(this.label11);
            this.tabPageShipping.Controls.Add(this.numericTextBox3);
            this.tabPageShipping.Controls.Add(this.textBox4);
            this.tabPageShipping.Controls.Add(this.label10);
            this.tabPageShipping.Controls.Add(this.label9);
            this.tabPageShipping.Controls.Add(this.label5);
            this.tabPageShipping.Controls.Add(this.label7);
            this.tabPageShipping.Controls.Add(this.numericTextBox2);
            this.tabPageShipping.Controls.Add(this.label8);
            this.tabPageShipping.Controls.Add(this.numericUpDown2);
            this.tabPageShipping.Controls.Add(this.groupBox2);
            this.tabPageShipping.Controls.Add(this.gBoxShipTo);
            this.tabPageShipping.Controls.Add(this.gBoxBillTo);
            this.tabPageShipping.Location = new System.Drawing.Point(4, 22);
            this.tabPageShipping.Name = "tabPageShipping";
            this.tabPageShipping.Size = new System.Drawing.Size(680, 382);
            this.tabPageShipping.TabIndex = 0;
            this.tabPageShipping.Text = "Shipping";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(504, 336);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(136, 20);
            this.textBox3.TabIndex = 88;
            this.textBox3.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(432, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 89;
            this.label2.Text = "Carrier Name";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(80, 336);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown1.TabIndex = 77;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(344, 352);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(56, 20);
            this.textBox2.TabIndex = 82;
            this.textBox2.Text = "";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(136, 336);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 20);
            this.label11.TabIndex = 84;
            this.label11.Text = "Total Volume";
            // 
            // numericTextBox3
            // 
            this.numericTextBox3.Location = new System.Drawing.Point(208, 336);
            this.numericTextBox3.Maximum = new System.Decimal(new int[] {
                                                                            1000000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox3.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox3.Name = "numericTextBox3";
            this.numericTextBox3.Size = new System.Drawing.Size(56, 20);
            this.numericTextBox3.TabIndex = 85;
            this.numericTextBox3.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(208, 356);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(56, 20);
            this.textBox4.TabIndex = 86;
            this.textBox4.Text = "";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(136, 356);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 20);
            this.label10.TabIndex = 87;
            this.label10.Text = "Volume Uom";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(272, 352);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 20);
            this.label9.TabIndex = 83;
            this.label9.Text = "Weigth Uom";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 76;
            this.label5.Text = "Total Skids";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 356);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 78;
            this.label7.Text = "Total Boxes";
            // 
            // numericTextBox2
            // 
            this.numericTextBox2.Location = new System.Drawing.Point(344, 336);
            this.numericTextBox2.Maximum = new System.Decimal(new int[] {
                                                                            1000000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox2.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox2.Name = "numericTextBox2";
            this.numericTextBox2.Size = new System.Drawing.Size(56, 20);
            this.numericTextBox2.TabIndex = 81;
            this.numericTextBox2.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(272, 336);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 20);
            this.label8.TabIndex = 80;
            this.label8.Text = "Total Weigth";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(80, 356);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown2.TabIndex = 79;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.schStkLoc);
            this.groupBox2.Controls.Add(this.lPStkLoc);
            this.groupBox2.Controls.Add(this.tBoxP_StkLoc);
            this.groupBox2.Controls.Add(this.ntbP_OrderNumber);
            this.groupBox2.Controls.Add(this.lPOrderNum);
            this.groupBox2.Controls.Add(this.lPShipmentId);
            this.groupBox2.Controls.Add(this.tBoxP_ShipmentId);
            this.groupBox2.Controls.Add(this.dtpP_ShipDate);
            this.groupBox2.Controls.Add(this.lPShipTime);
            this.groupBox2.Controls.Add(this.dtpP_ShipTime);
            this.groupBox2.Controls.Add(this.lPShipDate);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(8, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(664, 64);
            this.groupBox2.TabIndex = 75;
            this.groupBox2.TabStop = false;
            // 
            // schStkLoc
            // 
            this.schStkLoc.Location = new System.Drawing.Point(344, 40);
            this.schStkLoc.Name = "schStkLoc";
            this.schStkLoc.Size = new System.Drawing.Size(30, 16);
            this.schStkLoc.TabIndex = 91;
            this.schStkLoc.Text = "...";
            // 
            // lPStkLoc
            // 
            this.lPStkLoc.Location = new System.Drawing.Point(200, 40);
            this.lPStkLoc.Name = "lPStkLoc";
            this.lPStkLoc.Size = new System.Drawing.Size(48, 16);
            this.lPStkLoc.TabIndex = 79;
            this.lPStkLoc.Text = "Stk. Loc";
            // 
            // tBoxP_StkLoc
            // 
            this.tBoxP_StkLoc.Location = new System.Drawing.Point(256, 36);
            this.tBoxP_StkLoc.MaxLength = 10;
            this.tBoxP_StkLoc.Multiline = true;
            this.tBoxP_StkLoc.Name = "tBoxP_StkLoc";
            this.tBoxP_StkLoc.Size = new System.Drawing.Size(80, 20);
            this.tBoxP_StkLoc.TabIndex = 80;
            this.tBoxP_StkLoc.Text = "";
            // 
            // ntbP_OrderNumber
            // 
            this.ntbP_OrderNumber.Location = new System.Drawing.Point(488, 16);
            this.ntbP_OrderNumber.Maximum = new System.Decimal(new int[] {
                                                                             1215752191,
                                                                             23,
                                                                             0,
                                                                             0});
            this.ntbP_OrderNumber.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.ntbP_OrderNumber.Name = "ntbP_OrderNumber";
            this.ntbP_OrderNumber.Size = new System.Drawing.Size(80, 20);
            this.ntbP_OrderNumber.TabIndex = 78;
            this.ntbP_OrderNumber.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // lPOrderNum
            // 
            this.lPOrderNum.Location = new System.Drawing.Point(432, 16);
            this.lPOrderNum.Name = "lPOrderNum";
            this.lPOrderNum.Size = new System.Drawing.Size(48, 16);
            this.lPOrderNum.TabIndex = 77;
            this.lPOrderNum.Text = "Order #";
            // 
            // lPShipmentId
            // 
            this.lPShipmentId.Location = new System.Drawing.Point(200, 20);
            this.lPShipmentId.Name = "lPShipmentId";
            this.lPShipmentId.Size = new System.Drawing.Size(40, 16);
            this.lPShipmentId.TabIndex = 75;
            this.lPShipmentId.Text = "Ship Id";
            // 
            // tBoxP_ShipmentId
            // 
            this.tBoxP_ShipmentId.Location = new System.Drawing.Point(256, 16);
            this.tBoxP_ShipmentId.MaxLength = 20;
            this.tBoxP_ShipmentId.Multiline = true;
            this.tBoxP_ShipmentId.Name = "tBoxP_ShipmentId";
            this.tBoxP_ShipmentId.Size = new System.Drawing.Size(160, 20);
            this.tBoxP_ShipmentId.TabIndex = 76;
            this.tBoxP_ShipmentId.Text = "";
            // 
            // dtpP_ShipDate
            // 
            this.dtpP_ShipDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpP_ShipDate.Location = new System.Drawing.Point(88, 12);
            this.dtpP_ShipDate.Name = "dtpP_ShipDate";
            this.dtpP_ShipDate.Size = new System.Drawing.Size(88, 20);
            this.dtpP_ShipDate.TabIndex = 55;
            // 
            // lPShipTime
            // 
            this.lPShipTime.Location = new System.Drawing.Point(16, 36);
            this.lPShipTime.Name = "lPShipTime";
            this.lPShipTime.Size = new System.Drawing.Size(56, 16);
            this.lPShipTime.TabIndex = 74;
            this.lPShipTime.Text = "Ship time";
            // 
            // dtpP_ShipTime
            // 
            this.dtpP_ShipTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpP_ShipTime.Location = new System.Drawing.Point(88, 32);
            this.dtpP_ShipTime.Name = "dtpP_ShipTime";
            this.dtpP_ShipTime.Size = new System.Drawing.Size(88, 20);
            this.dtpP_ShipTime.TabIndex = 73;
            // 
            // lPShipDate
            // 
            this.lPShipDate.Location = new System.Drawing.Point(16, 16);
            this.lPShipDate.Name = "lPShipDate";
            this.lPShipDate.Size = new System.Drawing.Size(56, 16);
            this.lPShipDate.TabIndex = 56;
            this.lPShipDate.Text = "Date Sip";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(576, 32);
            this.button1.Name = "button1";
            this.button1.TabIndex = 90;
            this.button1.Text = "Ship From";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gBoxShipTo
            // 
            this.gBoxShipTo.Controls.Add(this.label13);
            this.gBoxShipTo.Controls.Add(this.textBox6);
            this.gBoxShipTo.Controls.Add(this.label3);
            this.gBoxShipTo.Controls.Add(this.textBox1);
            this.gBoxShipTo.Controls.Add(this.lPShipToCust);
            this.gBoxShipTo.Controls.Add(this.btnSchShipTo);
            this.gBoxShipTo.Controls.Add(this.tBoxP_ShipToCust);
            this.gBoxShipTo.Controls.Add(this.tBoxP_ShipToName);
            this.gBoxShipTo.Controls.Add(this.lPShipToName);
            this.gBoxShipTo.Controls.Add(this.tBoxP_STAdd1);
            this.gBoxShipTo.Controls.Add(this.tBoxP_STAdd2);
            this.gBoxShipTo.Controls.Add(this.lPSTAdd3);
            this.gBoxShipTo.Controls.Add(this.lPSTAdd2);
            this.gBoxShipTo.Controls.Add(this.lPSTAdd1);
            this.gBoxShipTo.Controls.Add(this.tBoxP_STAdd3);
            this.gBoxShipTo.Controls.Add(this.tBoxP_ShipVia);
            this.gBoxShipTo.Controls.Add(this.lPShipVia);
            this.gBoxShipTo.Controls.Add(this.btnSchStContact);
            this.gBoxShipTo.Controls.Add(this.tBoxP_STContact);
            this.gBoxShipTo.Controls.Add(this.lPSTContact);
            this.gBoxShipTo.Controls.Add(this.tBoxlP_DTPostZip);
            this.gBoxShipTo.Controls.Add(this.lPDTPostZip);
            this.gBoxShipTo.Controls.Add(this.tBoxP_STCountry);
            this.gBoxShipTo.Controls.Add(this.lPSTCountry);
            this.gBoxShipTo.Controls.Add(this.tBoxP_STProvState);
            this.gBoxShipTo.Controls.Add(this.lPSTProvState);
            this.gBoxShipTo.Location = new System.Drawing.Point(8, 64);
            this.gBoxShipTo.Name = "gBoxShipTo";
            this.gBoxShipTo.Size = new System.Drawing.Size(328, 264);
            this.gBoxShipTo.TabIndex = 72;
            this.gBoxShipTo.TabStop = false;
            this.gBoxShipTo.Text = "Ship To";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 236);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 20);
            this.label13.TabIndex = 105;
            this.label13.Text = "Phone #";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(64, 236);
            this.textBox6.MaxLength = 20;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(128, 20);
            this.textBox6.TabIndex = 104;
            this.textBox6.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 91;
            this.label3.Text = "City";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 156);
            this.textBox1.MaxLength = 30;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(128, 20);
            this.textBox1.TabIndex = 92;
            this.textBox1.Text = "";
            // 
            // lPShipToCust
            // 
            this.lPShipToCust.Location = new System.Drawing.Point(8, 16);
            this.lPShipToCust.Name = "lPShipToCust";
            this.lPShipToCust.Size = new System.Drawing.Size(56, 20);
            this.lPShipToCust.TabIndex = 1;
            this.lPShipToCust.Text = "Customer";
            // 
            // btnSchShipTo
            // 
            this.btnSchShipTo.Location = new System.Drawing.Point(144, 16);
            this.btnSchShipTo.Name = "btnSchShipTo";
            this.btnSchShipTo.Size = new System.Drawing.Size(30, 16);
            this.btnSchShipTo.TabIndex = 13;
            this.btnSchShipTo.Text = "...";
            // 
            // tBoxP_ShipToCust
            // 
            this.tBoxP_ShipToCust.Location = new System.Drawing.Point(64, 16);
            this.tBoxP_ShipToCust.MaxLength = 10;
            this.tBoxP_ShipToCust.Name = "tBoxP_ShipToCust";
            this.tBoxP_ShipToCust.Size = new System.Drawing.Size(72, 20);
            this.tBoxP_ShipToCust.TabIndex = 9;
            this.tBoxP_ShipToCust.Text = "";
            // 
            // tBoxP_ShipToName
            // 
            this.tBoxP_ShipToName.Location = new System.Drawing.Point(64, 36);
            this.tBoxP_ShipToName.MaxLength = 40;
            this.tBoxP_ShipToName.Multiline = true;
            this.tBoxP_ShipToName.Name = "tBoxP_ShipToName";
            this.tBoxP_ShipToName.ReadOnly = true;
            this.tBoxP_ShipToName.Size = new System.Drawing.Size(256, 20);
            this.tBoxP_ShipToName.TabIndex = 7;
            this.tBoxP_ShipToName.Text = "";
            // 
            // lPShipToName
            // 
            this.lPShipToName.Location = new System.Drawing.Point(8, 36);
            this.lPShipToName.Name = "lPShipToName";
            this.lPShipToName.Size = new System.Drawing.Size(48, 20);
            this.lPShipToName.TabIndex = 3;
            this.lPShipToName.Text = "Name";
            // 
            // tBoxP_STAdd1
            // 
            this.tBoxP_STAdd1.Location = new System.Drawing.Point(64, 56);
            this.tBoxP_STAdd1.MaxLength = 40;
            this.tBoxP_STAdd1.Multiline = true;
            this.tBoxP_STAdd1.Name = "tBoxP_STAdd1";
            this.tBoxP_STAdd1.ReadOnly = true;
            this.tBoxP_STAdd1.Size = new System.Drawing.Size(256, 20);
            this.tBoxP_STAdd1.TabIndex = 66;
            this.tBoxP_STAdd1.Text = "";
            // 
            // tBoxP_STAdd2
            // 
            this.tBoxP_STAdd2.Location = new System.Drawing.Point(64, 76);
            this.tBoxP_STAdd2.MaxLength = 40;
            this.tBoxP_STAdd2.Multiline = true;
            this.tBoxP_STAdd2.Name = "tBoxP_STAdd2";
            this.tBoxP_STAdd2.ReadOnly = true;
            this.tBoxP_STAdd2.Size = new System.Drawing.Size(256, 20);
            this.tBoxP_STAdd2.TabIndex = 70;
            this.tBoxP_STAdd2.Text = "";
            // 
            // lPSTAdd3
            // 
            this.lPSTAdd3.Location = new System.Drawing.Point(8, 96);
            this.lPSTAdd3.Name = "lPSTAdd3";
            this.lPSTAdd3.Size = new System.Drawing.Size(40, 20);
            this.lPSTAdd3.TabIndex = 67;
            this.lPSTAdd3.Text = "Addr3";
            // 
            // lPSTAdd2
            // 
            this.lPSTAdd2.Location = new System.Drawing.Point(8, 76);
            this.lPSTAdd2.Name = "lPSTAdd2";
            this.lPSTAdd2.Size = new System.Drawing.Size(40, 20);
            this.lPSTAdd2.TabIndex = 69;
            this.lPSTAdd2.Text = "Addr2";
            // 
            // lPSTAdd1
            // 
            this.lPSTAdd1.Location = new System.Drawing.Point(8, 56);
            this.lPSTAdd1.Name = "lPSTAdd1";
            this.lPSTAdd1.Size = new System.Drawing.Size(40, 20);
            this.lPSTAdd1.TabIndex = 65;
            this.lPSTAdd1.Text = "Addr1";
            // 
            // tBoxP_STAdd3
            // 
            this.tBoxP_STAdd3.Location = new System.Drawing.Point(64, 96);
            this.tBoxP_STAdd3.MaxLength = 40;
            this.tBoxP_STAdd3.Multiline = true;
            this.tBoxP_STAdd3.Name = "tBoxP_STAdd3";
            this.tBoxP_STAdd3.ReadOnly = true;
            this.tBoxP_STAdd3.Size = new System.Drawing.Size(256, 20);
            this.tBoxP_STAdd3.TabIndex = 68;
            this.tBoxP_STAdd3.Text = "";
            // 
            // tBoxP_ShipVia
            // 
            this.tBoxP_ShipVia.Location = new System.Drawing.Point(64, 116);
            this.tBoxP_ShipVia.MaxLength = 30;
            this.tBoxP_ShipVia.Name = "tBoxP_ShipVia";
            this.tBoxP_ShipVia.ReadOnly = true;
            this.tBoxP_ShipVia.Size = new System.Drawing.Size(256, 20);
            this.tBoxP_ShipVia.TabIndex = 58;
            this.tBoxP_ShipVia.Text = "";
            // 
            // lPShipVia
            // 
            this.lPShipVia.Location = new System.Drawing.Point(8, 116);
            this.lPShipVia.Name = "lPShipVia";
            this.lPShipVia.Size = new System.Drawing.Size(48, 20);
            this.lPShipVia.TabIndex = 57;
            this.lPShipVia.Text = "Via";
            // 
            // btnSchStContact
            // 
            this.btnSchStContact.Location = new System.Drawing.Point(200, 220);
            this.btnSchStContact.Name = "btnSchStContact";
            this.btnSchStContact.Size = new System.Drawing.Size(30, 16);
            this.btnSchStContact.TabIndex = 90;
            this.btnSchStContact.Text = "...";
            // 
            // tBoxP_STContact
            // 
            this.tBoxP_STContact.Location = new System.Drawing.Point(64, 196);
            this.tBoxP_STContact.MaxLength = 20;
            this.tBoxP_STContact.Name = "tBoxP_STContact";
            this.tBoxP_STContact.ReadOnly = true;
            this.tBoxP_STContact.Size = new System.Drawing.Size(128, 20);
            this.tBoxP_STContact.TabIndex = 89;
            this.tBoxP_STContact.Text = "";
            // 
            // lPSTContact
            // 
            this.lPSTContact.Location = new System.Drawing.Point(8, 216);
            this.lPSTContact.Name = "lPSTContact";
            this.lPSTContact.Size = new System.Drawing.Size(48, 20);
            this.lPSTContact.TabIndex = 88;
            this.lPSTContact.Text = "Contact";
            this.lPSTContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tBoxlP_DTPostZip
            // 
            this.tBoxlP_DTPostZip.Location = new System.Drawing.Point(64, 216);
            this.tBoxlP_DTPostZip.MaxLength = 20;
            this.tBoxlP_DTPostZip.Name = "tBoxlP_DTPostZip";
            this.tBoxlP_DTPostZip.Size = new System.Drawing.Size(128, 20);
            this.tBoxlP_DTPostZip.TabIndex = 87;
            this.tBoxlP_DTPostZip.Text = "";
            // 
            // lPDTPostZip
            // 
            this.lPDTPostZip.Location = new System.Drawing.Point(8, 196);
            this.lPDTPostZip.Name = "lPDTPostZip";
            this.lPDTPostZip.Size = new System.Drawing.Size(60, 20);
            this.lPDTPostZip.TabIndex = 86;
            this.lPDTPostZip.Text = "Post Zip";
            this.lPDTPostZip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tBoxP_STCountry
            // 
            this.tBoxP_STCountry.Location = new System.Drawing.Point(64, 176);
            this.tBoxP_STCountry.MaxLength = 20;
            this.tBoxP_STCountry.Name = "tBoxP_STCountry";
            this.tBoxP_STCountry.ReadOnly = true;
            this.tBoxP_STCountry.Size = new System.Drawing.Size(128, 20);
            this.tBoxP_STCountry.TabIndex = 85;
            this.tBoxP_STCountry.Text = "";
            // 
            // lPSTCountry
            // 
            this.lPSTCountry.Location = new System.Drawing.Point(8, 176);
            this.lPSTCountry.Name = "lPSTCountry";
            this.lPSTCountry.Size = new System.Drawing.Size(60, 20);
            this.lPSTCountry.TabIndex = 84;
            this.lPSTCountry.Text = "Country";
            // 
            // tBoxP_STProvState
            // 
            this.tBoxP_STProvState.Location = new System.Drawing.Point(64, 136);
            this.tBoxP_STProvState.MaxLength = 20;
            this.tBoxP_STProvState.Name = "tBoxP_STProvState";
            this.tBoxP_STProvState.ReadOnly = true;
            this.tBoxP_STProvState.Size = new System.Drawing.Size(128, 20);
            this.tBoxP_STProvState.TabIndex = 83;
            this.tBoxP_STProvState.Text = "";
            // 
            // lPSTProvState
            // 
            this.lPSTProvState.Location = new System.Drawing.Point(8, 136);
            this.lPSTProvState.Name = "lPSTProvState";
            this.lPSTProvState.Size = new System.Drawing.Size(60, 20);
            this.lPSTProvState.TabIndex = 82;
            this.lPSTProvState.Text = "Prov/State";
            // 
            // gBoxBillTo
            // 
            this.gBoxBillTo.Controls.Add(this.label14);
            this.gBoxBillTo.Controls.Add(this.textBox7);
            this.gBoxBillTo.Controls.Add(this.lPSFAdd4);
            this.gBoxBillTo.Controls.Add(this.tBoxP_SFAdd4);
            this.gBoxBillTo.Controls.Add(this.lPBillToName);
            this.gBoxBillTo.Controls.Add(this.tBoxP_BillToCust);
            this.gBoxBillTo.Controls.Add(this.btnSchBillTo);
            this.gBoxBillTo.Controls.Add(this.tBoxP_BilltoName);
            this.gBoxBillTo.Controls.Add(this.lPBillToCust);
            this.gBoxBillTo.Controls.Add(this.lPBTAdd1);
            this.gBoxBillTo.Controls.Add(this.tBoxP_BTAdd1);
            this.gBoxBillTo.Controls.Add(this.lPBTAdd3);
            this.gBoxBillTo.Controls.Add(this.tBoxP_BTAdd3);
            this.gBoxBillTo.Controls.Add(this.lPBTAdd2);
            this.gBoxBillTo.Controls.Add(this.tBoxP_BlTAdd2);
            this.gBoxBillTo.Controls.Add(this.lPBillToPost);
            this.gBoxBillTo.Controls.Add(this.tBoxP_BillToPost);
            this.gBoxBillTo.Controls.Add(this.tboxP_BTCountry);
            this.gBoxBillTo.Controls.Add(this.tBoxP_BTProvState);
            this.gBoxBillTo.Controls.Add(this.tBoxP_BTContact);
            this.gBoxBillTo.Controls.Add(this.tBoxP_BTPostZip);
            this.gBoxBillTo.Controls.Add(this.btnSchBTContact);
            this.gBoxBillTo.Controls.Add(this.lPBTProvState);
            this.gBoxBillTo.Controls.Add(this.lPBTCountry);
            this.gBoxBillTo.Controls.Add(this.lPBTContact);
            this.gBoxBillTo.Controls.Add(this.lPBTPostZip);
            this.gBoxBillTo.Location = new System.Drawing.Point(344, 64);
            this.gBoxBillTo.Name = "gBoxBillTo";
            this.gBoxBillTo.Size = new System.Drawing.Size(328, 264);
            this.gBoxBillTo.TabIndex = 71;
            this.gBoxBillTo.TabStop = false;
            this.gBoxBillTo.Text = "Bill To";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 236);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 20);
            this.label14.TabIndex = 105;
            this.label14.Text = "Phone #";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(64, 236);
            this.textBox7.MaxLength = 20;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(128, 20);
            this.textBox7.TabIndex = 104;
            this.textBox7.Text = "";
            // 
            // lPSFAdd4
            // 
            this.lPSFAdd4.Location = new System.Drawing.Point(8, 156);
            this.lPSFAdd4.Name = "lPSFAdd4";
            this.lPSFAdd4.Size = new System.Drawing.Size(40, 20);
            this.lPSFAdd4.TabIndex = 82;
            this.lPSFAdd4.Text = "City";
            // 
            // tBoxP_SFAdd4
            // 
            this.tBoxP_SFAdd4.Location = new System.Drawing.Point(64, 156);
            this.tBoxP_SFAdd4.MaxLength = 30;
            this.tBoxP_SFAdd4.Multiline = true;
            this.tBoxP_SFAdd4.Name = "tBoxP_SFAdd4";
            this.tBoxP_SFAdd4.ReadOnly = true;
            this.tBoxP_SFAdd4.Size = new System.Drawing.Size(128, 20);
            this.tBoxP_SFAdd4.TabIndex = 83;
            this.tBoxP_SFAdd4.Text = "";
            // 
            // lPBillToName
            // 
            this.lPBillToName.Location = new System.Drawing.Point(8, 36);
            this.lPBillToName.Name = "lPBillToName";
            this.lPBillToName.Size = new System.Drawing.Size(40, 20);
            this.lPBillToName.TabIndex = 2;
            this.lPBillToName.Text = "Name";
            // 
            // tBoxP_BillToCust
            // 
            this.tBoxP_BillToCust.Location = new System.Drawing.Point(64, 16);
            this.tBoxP_BillToCust.MaxLength = 10;
            this.tBoxP_BillToCust.Name = "tBoxP_BillToCust";
            this.tBoxP_BillToCust.Size = new System.Drawing.Size(72, 20);
            this.tBoxP_BillToCust.TabIndex = 10;
            this.tBoxP_BillToCust.Text = "";
            // 
            // btnSchBillTo
            // 
            this.btnSchBillTo.Location = new System.Drawing.Point(144, 16);
            this.btnSchBillTo.Name = "btnSchBillTo";
            this.btnSchBillTo.Size = new System.Drawing.Size(30, 16);
            this.btnSchBillTo.TabIndex = 14;
            this.btnSchBillTo.Text = "...";
            // 
            // tBoxP_BilltoName
            // 
            this.tBoxP_BilltoName.Location = new System.Drawing.Point(64, 36);
            this.tBoxP_BilltoName.MaxLength = 40;
            this.tBoxP_BilltoName.Multiline = true;
            this.tBoxP_BilltoName.Name = "tBoxP_BilltoName";
            this.tBoxP_BilltoName.ReadOnly = true;
            this.tBoxP_BilltoName.Size = new System.Drawing.Size(256, 20);
            this.tBoxP_BilltoName.TabIndex = 8;
            this.tBoxP_BilltoName.Text = "";
            // 
            // lPBillToCust
            // 
            this.lPBillToCust.Location = new System.Drawing.Point(8, 16);
            this.lPBillToCust.Name = "lPBillToCust";
            this.lPBillToCust.Size = new System.Drawing.Size(64, 20);
            this.lPBillToCust.TabIndex = 0;
            this.lPBillToCust.Text = "Customer";
            // 
            // lPBTAdd1
            // 
            this.lPBTAdd1.Location = new System.Drawing.Point(8, 56);
            this.lPBTAdd1.Name = "lPBTAdd1";
            this.lPBTAdd1.Size = new System.Drawing.Size(40, 20);
            this.lPBTAdd1.TabIndex = 59;
            this.lPBTAdd1.Text = "Addr1";
            // 
            // tBoxP_BTAdd1
            // 
            this.tBoxP_BTAdd1.Location = new System.Drawing.Point(64, 56);
            this.tBoxP_BTAdd1.MaxLength = 40;
            this.tBoxP_BTAdd1.Multiline = true;
            this.tBoxP_BTAdd1.Name = "tBoxP_BTAdd1";
            this.tBoxP_BTAdd1.ReadOnly = true;
            this.tBoxP_BTAdd1.Size = new System.Drawing.Size(256, 20);
            this.tBoxP_BTAdd1.TabIndex = 60;
            this.tBoxP_BTAdd1.Text = "";
            // 
            // lPBTAdd3
            // 
            this.lPBTAdd3.Location = new System.Drawing.Point(8, 96);
            this.lPBTAdd3.Name = "lPBTAdd3";
            this.lPBTAdd3.Size = new System.Drawing.Size(40, 20);
            this.lPBTAdd3.TabIndex = 61;
            this.lPBTAdd3.Text = "Addr3";
            // 
            // tBoxP_BTAdd3
            // 
            this.tBoxP_BTAdd3.Location = new System.Drawing.Point(64, 96);
            this.tBoxP_BTAdd3.MaxLength = 40;
            this.tBoxP_BTAdd3.Multiline = true;
            this.tBoxP_BTAdd3.Name = "tBoxP_BTAdd3";
            this.tBoxP_BTAdd3.ReadOnly = true;
            this.tBoxP_BTAdd3.Size = new System.Drawing.Size(256, 20);
            this.tBoxP_BTAdd3.TabIndex = 62;
            this.tBoxP_BTAdd3.Text = "";
            // 
            // lPBTAdd2
            // 
            this.lPBTAdd2.Location = new System.Drawing.Point(8, 76);
            this.lPBTAdd2.Name = "lPBTAdd2";
            this.lPBTAdd2.Size = new System.Drawing.Size(40, 20);
            this.lPBTAdd2.TabIndex = 63;
            this.lPBTAdd2.Text = "Addr2";
            // 
            // tBoxP_BlTAdd2
            // 
            this.tBoxP_BlTAdd2.Location = new System.Drawing.Point(64, 76);
            this.tBoxP_BlTAdd2.MaxLength = 40;
            this.tBoxP_BlTAdd2.Multiline = true;
            this.tBoxP_BlTAdd2.Name = "tBoxP_BlTAdd2";
            this.tBoxP_BlTAdd2.ReadOnly = true;
            this.tBoxP_BlTAdd2.Size = new System.Drawing.Size(256, 20);
            this.tBoxP_BlTAdd2.TabIndex = 64;
            this.tBoxP_BlTAdd2.Text = "";
            // 
            // lPBillToPost
            // 
            this.lPBillToPost.Location = new System.Drawing.Point(8, 116);
            this.lPBillToPost.Name = "lPBillToPost";
            this.lPBillToPost.Size = new System.Drawing.Size(40, 20);
            this.lPBillToPost.TabIndex = 15;
            this.lPBillToPost.Text = "Post";
            // 
            // tBoxP_BillToPost
            // 
            this.tBoxP_BillToPost.Location = new System.Drawing.Point(64, 116);
            this.tBoxP_BillToPost.MaxLength = 40;
            this.tBoxP_BillToPost.Name = "tBoxP_BillToPost";
            this.tBoxP_BillToPost.ReadOnly = true;
            this.tBoxP_BillToPost.Size = new System.Drawing.Size(256, 20);
            this.tBoxP_BillToPost.TabIndex = 16;
            this.tBoxP_BillToPost.Text = "";
            // 
            // tboxP_BTCountry
            // 
            this.tboxP_BTCountry.Location = new System.Drawing.Point(64, 176);
            this.tboxP_BTCountry.MaxLength = 20;
            this.tboxP_BTCountry.Name = "tboxP_BTCountry";
            this.tboxP_BTCountry.ReadOnly = true;
            this.tboxP_BTCountry.Size = new System.Drawing.Size(128, 20);
            this.tboxP_BTCountry.TabIndex = 76;
            this.tboxP_BTCountry.Text = "";
            // 
            // tBoxP_BTProvState
            // 
            this.tBoxP_BTProvState.Location = new System.Drawing.Point(64, 136);
            this.tBoxP_BTProvState.MaxLength = 20;
            this.tBoxP_BTProvState.Name = "tBoxP_BTProvState";
            this.tBoxP_BTProvState.ReadOnly = true;
            this.tBoxP_BTProvState.Size = new System.Drawing.Size(128, 20);
            this.tBoxP_BTProvState.TabIndex = 74;
            this.tBoxP_BTProvState.Text = "";
            // 
            // tBoxP_BTContact
            // 
            this.tBoxP_BTContact.Location = new System.Drawing.Point(64, 216);
            this.tBoxP_BTContact.MaxLength = 20;
            this.tBoxP_BTContact.Name = "tBoxP_BTContact";
            this.tBoxP_BTContact.Size = new System.Drawing.Size(128, 20);
            this.tBoxP_BTContact.TabIndex = 80;
            this.tBoxP_BTContact.Text = "";
            // 
            // tBoxP_BTPostZip
            // 
            this.tBoxP_BTPostZip.Location = new System.Drawing.Point(64, 196);
            this.tBoxP_BTPostZip.MaxLength = 20;
            this.tBoxP_BTPostZip.Name = "tBoxP_BTPostZip";
            this.tBoxP_BTPostZip.ReadOnly = true;
            this.tBoxP_BTPostZip.Size = new System.Drawing.Size(128, 20);
            this.tBoxP_BTPostZip.TabIndex = 78;
            this.tBoxP_BTPostZip.Text = "";
            // 
            // btnSchBTContact
            // 
            this.btnSchBTContact.Location = new System.Drawing.Point(200, 220);
            this.btnSchBTContact.Name = "btnSchBTContact";
            this.btnSchBTContact.Size = new System.Drawing.Size(30, 16);
            this.btnSchBTContact.TabIndex = 81;
            this.btnSchBTContact.Text = "...";
            // 
            // lPBTProvState
            // 
            this.lPBTProvState.Location = new System.Drawing.Point(8, 136);
            this.lPBTProvState.Name = "lPBTProvState";
            this.lPBTProvState.Size = new System.Drawing.Size(60, 20);
            this.lPBTProvState.TabIndex = 73;
            this.lPBTProvState.Text = "Prov/State";
            // 
            // lPBTCountry
            // 
            this.lPBTCountry.Location = new System.Drawing.Point(8, 176);
            this.lPBTCountry.Name = "lPBTCountry";
            this.lPBTCountry.Size = new System.Drawing.Size(60, 20);
            this.lPBTCountry.TabIndex = 75;
            this.lPBTCountry.Text = "Country";
            // 
            // lPBTContact
            // 
            this.lPBTContact.Location = new System.Drawing.Point(8, 216);
            this.lPBTContact.Name = "lPBTContact";
            this.lPBTContact.Size = new System.Drawing.Size(60, 20);
            this.lPBTContact.TabIndex = 79;
            this.lPBTContact.Text = "Contact";
            this.lPBTContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lPBTPostZip
            // 
            this.lPBTPostZip.Location = new System.Drawing.Point(8, 196);
            this.lPBTPostZip.Name = "lPBTPostZip";
            this.lPBTPostZip.Size = new System.Drawing.Size(60, 20);
            this.lPBTPostZip.TabIndex = 77;
            this.lPBTPostZip.Text = "Post Zip";
            this.lPBTPostZip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPageContainers
            // 
            this.tabPageContainers.Controls.Add(this.groupBox3);
            this.tabPageContainers.Location = new System.Drawing.Point(4, 22);
            this.tabPageContainers.Name = "tabPageContainers";
            this.tabPageContainers.Size = new System.Drawing.Size(680, 382);
            this.tabPageContainers.TabIndex = 1;
            this.tabPageContainers.Text = "Containers";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGrid1);
            this.groupBox3.Location = new System.Drawing.Point(8, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(664, 288);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(648, 232);
            this.dataGrid1.TabIndex = 0;
            // 
            // tabPageDetail
            // 
            this.tabPageDetail.Controls.Add(this.btnDeleteDtl);
            this.tabPageDetail.Controls.Add(this.btnEditDtl);
            this.tabPageDetail.Controls.Add(this.btnAddDtl);
            this.tabPageDetail.Controls.Add(this.dGridPackSlipDtl);
            this.tabPageDetail.Location = new System.Drawing.Point(4, 22);
            this.tabPageDetail.Name = "tabPageDetail";
            this.tabPageDetail.Size = new System.Drawing.Size(680, 382);
            this.tabPageDetail.TabIndex = 2;
            this.tabPageDetail.Text = "Detail";
            // 
            // btnDeleteDtl
            // 
            this.btnDeleteDtl.Location = new System.Drawing.Point(576, 328);
            this.btnDeleteDtl.Name = "btnDeleteDtl";
            this.btnDeleteDtl.TabIndex = 6;
            this.btnDeleteDtl.Text = "Delete";
            // 
            // btnEditDtl
            // 
            this.btnEditDtl.Location = new System.Drawing.Point(496, 328);
            this.btnEditDtl.Name = "btnEditDtl";
            this.btnEditDtl.TabIndex = 5;
            this.btnEditDtl.Text = "Edit";
            // 
            // btnAddDtl
            // 
            this.btnAddDtl.Location = new System.Drawing.Point(408, 328);
            this.btnAddDtl.Name = "btnAddDtl";
            this.btnAddDtl.TabIndex = 4;
            this.btnAddDtl.Text = "Add";
            this.btnAddDtl.Click += new System.EventHandler(this.btnAddDtl_Click);
            // 
            // dGridPackSlipDtl
            // 
            this.dGridPackSlipDtl.DataMember = "";
            this.dGridPackSlipDtl.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridPackSlipDtl.Location = new System.Drawing.Point(16, 16);
            this.dGridPackSlipDtl.Name = "dGridPackSlipDtl";
            this.dGridPackSlipDtl.Size = new System.Drawing.Size(648, 304);
            this.dGridPackSlipDtl.TabIndex = 0;
            // 
            // tabPageAsn
            // 
            this.tabPageAsn.Location = new System.Drawing.Point(4, 22);
            this.tabPageAsn.Name = "tabPageAsn";
            this.tabPageAsn.Size = new System.Drawing.Size(680, 382);
            this.tabPageAsn.TabIndex = 5;
            this.tabPageAsn.Text = "Asn Info";
            // 
            // tabPageForms
            // 
            this.tabPageForms.Location = new System.Drawing.Point(4, 22);
            this.tabPageForms.Name = "tabPageForms";
            this.tabPageForms.Size = new System.Drawing.Size(680, 382);
            this.tabPageForms.TabIndex = 6;
            this.tabPageForms.Text = "Forms";
            // 
            // tabPageParts
            // 
            this.tabPageParts.Location = new System.Drawing.Point(4, 22);
            this.tabPageParts.Name = "tabPageParts";
            this.tabPageParts.Size = new System.Drawing.Size(680, 382);
            this.tabPageParts.TabIndex = 4;
            this.tabPageParts.Text = "Parts";
            // 
            // PackSlipHdrForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(712, 598);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gBoxKeyData);
            this.Name = "PackSlipHdrForm";
            this.Text = "Pack Slip Header";
            this.gBoxKeyData.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageShipping.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.gBoxShipTo.ResumeLayout(false);
            this.gBoxBillTo.ResumeLayout(false);
            this.tabPageContainers.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.tabPageDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridPackSlipDtl)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

private void button1_Click(object sender, System.EventArgs e)
{
    ShipFromForm shipFromForm= new ShipFromForm();
    shipFromForm.ShowDialog();
}


private void btnAddDtl_Click(object sender, System.EventArgs e){
    PackSlipDtlForm packSlipDtlForm= new PackSlipDtlForm();
    packSlipDtlForm.ShowDialog();

}


}
}
