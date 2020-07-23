using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;

using Nujit.NujitERP.ClassLib.Common;

using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.WinForms.Master;
using Nujit.NujitERP.WinForms.SearchForms;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.WinForms.OrderEntry;
using Nujit.NujitERP.WinForms.Orders;



namespace Nujit.NujitERP.WinForms.Orders
{
	/// <summary>
	/// Summary description for FormAddNewOrder.
	/// </summary>
	public class FormAddNewOrder : System.Windows.Forms.Form
	{

		#region Control Vars

		private System.Windows.Forms.Label labelOH_OrderNum;
		private System.Windows.Forms.Label labelOH_Company;
		private System.Windows.Forms.Label labelOH_Plant;
		private System.Windows.Forms.TextBox textBoxOH_OrderNum;
		private System.Windows.Forms.TextBox textBoxOH_PO;
		private System.Windows.Forms.Label labelOH_PO;
		private System.Windows.Forms.TextBox textBoxOH_Currency;
		private System.Windows.Forms.Label labelOH_Currency;
		private System.Windows.Forms.Label labelOH_OrderDate;
		private System.Windows.Forms.Button buttonSaveOrder;
		private System.Windows.Forms.TextBox textBoxOH_Company;
		private System.Windows.Forms.TextBox textBoxOH_Plant;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TextBox textBoxOH_OrderDate;
		private System.Windows.Forms.ContextMenu contextMenuOrdersDtls;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItemAddItem;
		private System.Windows.Forms.MenuItem menuItemRemoveItem;
		private System.Windows.Forms.MenuItem menuItemEditItem;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion Control Vars

		private Person billToObj = null;
		private CoreFactory coreFactory;
        private System.Windows.Forms.TabControl tabControlOrder;
        private System.Windows.Forms.TabPage tabPageShip;
        private System.Windows.Forms.TabPage tabPageMaterials;
        private System.Windows.Forms.TabPage tabPageCom;
        private System.Windows.Forms.TabPage tabPageDistribution;
        private System.Windows.Forms.TabPage tabPageDoc;
        private System.Windows.Forms.TabPage tabPageContact;
        private System.Windows.Forms.TabPage tabPageFreigth;
        private System.Windows.Forms.TabPage tabPageCharges;
        private System.Windows.Forms.TabPage tabPageAcc;
        private System.Windows.Forms.TabPage tabPageSales;
        private System.Windows.Forms.TabPage tabPageConfig;
        private System.Windows.Forms.TabPage tabPageItems;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox textBoxOH_BillToName;
        private System.Windows.Forms.Label labelOH_BillToName;
        private System.Windows.Forms.Button buttonSearchBillTo;
        private System.Windows.Forms.TextBox textBoxOH_BillToNum;
        private System.Windows.Forms.Label labelOH_BillToNum;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelOH_Tax1Total;
        private System.Windows.Forms.TextBox textBoxOH_CommissTot;
        private System.Windows.Forms.Label labeOH_Tax2Total;
        private System.Windows.Forms.TextBox textBoxOH_Tax2Total;
        private System.Windows.Forms.Label labelOH_Tax3Total;
        private System.Windows.Forms.TextBox textBoxOH_Tax3Total;
        private System.Windows.Forms.Label labelOH_DiscountTot;
        private System.Windows.Forms.TextBox textBoxOH_DiscountTot;
        private System.Windows.Forms.Label labelOH_OrderNet;
        private System.Windows.Forms.TextBox textBoxOH_OrderNet;
        private System.Windows.Forms.Label labelOH_RoyaltyTot;
        private System.Windows.Forms.TextBox textBoxOH_Tax1Total;
        private System.Windows.Forms.Label labelOH_OrderTotal;
        private System.Windows.Forms.TextBox textBoxOH_RoyaltyTot;
        private System.Windows.Forms.TextBox textBoxOH_OrderTotal;
        private System.Windows.Forms.Label labelOH_CommissTot;
        private System.Windows.Forms.GroupBox gBoxSalesCode;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox tBoxID_SC1;
        private System.Windows.Forms.Label lIDSc5;
        private System.Windows.Forms.TextBox tBoxID_SC4;
        private System.Windows.Forms.Label lIDSc1;
        private System.Windows.Forms.Label lIDSc3;
        private System.Windows.Forms.Label lIDSc6;
        private System.Windows.Forms.TextBox tBoxID_SC3;
        private System.Windows.Forms.Label lIDSc4;
        private System.Windows.Forms.TextBox tBoxID_SC6;
        private System.Windows.Forms.TextBox tBoxID_SC5;
        private System.Windows.Forms.Label lIDSc2;
        private System.Windows.Forms.TextBox tBoxID_SC2;
        private System.Windows.Forms.Button btnSchSc;
        private System.Windows.Forms.TabPage tabPageDiscounts;
        private System.Windows.Forms.Button buttonAddDiscGroup;
        private System.Windows.Forms.Button buttonAddDiscount;
        private System.Windows.Forms.Button buttonRemoveItem;
        private System.Windows.Forms.Button buttonEditItem;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.DataGrid dgridContact;
		private Order order;
        private System.Windows.Forms.Button btnDeletePart;
        private System.Windows.Forms.Button btnEditPart;
        private System.Windows.Forms.Button btnAddPart;
        private System.Windows.Forms.DataGrid dGridComponents;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGrid dGridItems;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.DataGrid dGtidMaterials;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox textBoxOH_ComRate;
        private System.Windows.Forms.Label labelOH_ComRate;
        private System.Windows.Forms.TextBox textBoxOH_ComPercent;
        private System.Windows.Forms.Label labelOH_ComPercent;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.TextBox textBox30;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox28;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox27;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tBocIHShipToAdr1;
        private System.Windows.Forms.TextBox tBoxIH_ShipToAdr2;
        private System.Windows.Forms.Label lIHShipToAdr1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label lCustCity;
        private System.Windows.Forms.TextBox tBoxIH_ShipToAdr3;
        private System.Windows.Forms.Label lIHShipToAdr3;
        private System.Windows.Forms.Label lIHShipToAdr2;
        private System.Windows.Forms.Label lCustCountry;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.Label lCustRegion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox31;
        private System.Windows.Forms.TextBox textBoxOH_ShipVia;
        private System.Windows.Forms.Label labelOH_ShipVia;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox35;
        private System.Windows.Forms.TextBox textBox25;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox textBox36;
        private System.Windows.Forms.TextBox textBox37;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox textBox38;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox textBox39;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox textBox40;
        private System.Windows.Forms.Button btnSchSFContact;
        private System.Windows.Forms.TextBox tBoxPSFPContact;
        private System.Windows.Forms.Label lPSFContact;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox textBox41;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.TextBox textBox42;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnShipFrom;
        private System.Windows.Forms.Button btnSchShipTo;
        private System.Windows.Forms.GroupBox gBoxCost;
        private NujitCustomWinControls.NumericTextBox numericTextBox1;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private NujitCustomWinControls.NumericTextBox numericTextBox2;
        private System.Windows.Forms.Label label39;
        private NujitCustomWinControls.NumericTextBox numericTextBox3;
        private System.Windows.Forms.Label label41;
        private NujitCustomWinControls.NumericTextBox numericTextBox4;
        private System.Windows.Forms.Label label42;
        private NujitCustomWinControls.NumericTextBox numericTextBox5;
        private System.Windows.Forms.Label label43;
        private NujitCustomWinControls.NumericTextBox numericTextBox13;
        private System.Windows.Forms.Label label55;
        private NujitCustomWinControls.NumericTextBox numericTextBox12;
        private System.Windows.Forms.Label label56;
        private NujitCustomWinControls.NumericTextBox numericTextBox11;
        private System.Windows.Forms.Label label57;
        private NujitCustomWinControls.NumericTextBox numericTextBox10;
        private System.Windows.Forms.Label label58;
        private NujitCustomWinControls.NumericTextBox numericTextBox7;
        private System.Windows.Forms.Label label59;
        private NujitCustomWinControls.NumericTextBox numericTextBox6;
        private System.Windows.Forms.Label label60;
        private NujitCustomWinControls.NumericTextBox numericTextBox8;
        private System.Windows.Forms.Label label61;
        private NujitCustomWinControls.NumericTextBox numericTextBox19;
        private System.Windows.Forms.Label label62;
        private NujitCustomWinControls.NumericTextBox ntbOutsideCost;
        private System.Windows.Forms.Label lIdOutsideCost;
        private NujitCustomWinControls.NumericTextBox ntbID_MatCost;
        private NujitCustomWinControls.NumericTextBox ntbID_OHCost;
        private System.Windows.Forms.Label lIdOHCost;
        private System.Windows.Forms.Label lIdMatCost;
        private NujitCustomWinControls.NumericTextBox ntbId_UnitCost;
        private NujitCustomWinControls.NumericTextBox ntbId_LabCost;
        private NujitCustomWinControls.NumericTextBox ntbID_CostExt;
        private System.Windows.Forms.Label lIdUnitCost;
        private System.Windows.Forms.Label lIdLabCost;
        private System.Windows.Forms.Label lIdCostExt;
        private System.Windows.Forms.GroupBox groupBox15;
        private NujitCustomWinControls.NumericTextBox numericTextBox20;
        private System.Windows.Forms.Label label63;
        private NujitCustomWinControls.NumericTextBox ntbID_RoyCharges;
        private NujitCustomWinControls.NumericTextBox ntbId_FreigthAmt;
        private System.Windows.Forms.Label lIDRoyCharges;
        private System.Windows.Forms.Label lIdFreightAmt;
        private NujitCustomWinControls.NumericTextBox numericTextBox21;
        private NujitCustomWinControls.NumericTextBox numericTextBox22;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.TextBox tBoxID_GLSalesAcc;
        private System.Windows.Forms.Label lIDGLSalesAcc;
        private System.Windows.Forms.Label lIDGLCosAcc;
        private System.Windows.Forms.TextBox tBoxID_GLCosAcc;
        private System.Windows.Forms.TextBox tBoxID_GLCosType;
        private System.Windows.Forms.Label lIDGLCosType;
        private System.Windows.Forms.GroupBox gBoxTax;
        private NujitCustomWinControls.NumericTextBox ntbID_TaxAmtTot;
        private System.Windows.Forms.Label lIDTaxAmtTot;
        private NujitCustomWinControls.NumericTextBox ntbID_LineExtwTax;
        private System.Windows.Forms.Label lIDLineExtwTax;
        private NujitCustomWinControls.NumericTextBox ntbID_Tax2Amt;
        private NujitCustomWinControls.NumericTextBox ntbID_Tax3Amt;
        private NujitCustomWinControls.NumericTextBox ntbID_Tax1Amt;
        private System.Windows.Forms.Label lIDTax2Amt;
        private System.Windows.Forms.Label lIdTax3Amt;
        private System.Windows.Forms.Label lIDTax1Amt;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBoxEmployeeName;
        private System.Windows.Forms.Label labelEmployeeName;
        private System.Windows.Forms.TextBox textBoxOH_SalesPerson;
        private System.Windows.Forms.Label labelOH_SalesPerson;
        private System.Windows.Forms.Button buttonSearchEmployee;
        private System.Windows.Forms.TextBox textBox43;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rdoQuote;
        private System.Windows.Forms.RadioButton rdoPO;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rdoRhubarb;
        private System.Windows.Forms.RadioButton rdoRetail;
        private System.Windows.Forms.TextBox textBoxOH_HoldStatus;
        private System.Windows.Forms.Button buttonOH_Note;
        private System.Windows.Forms.Label labelOH_HoldStatus;
        private System.Windows.Forms.CheckBox checkBoxOH_Note;
        private System.Windows.Forms.Label labelOH_Terms;
        private System.Windows.Forms.TextBox textBoxOH_Territory;
        private System.Windows.Forms.TextBox textBoxOH_DistributionLoc;
        private System.Windows.Forms.Label labelOH_Territory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxOH_Terms;
        private System.Windows.Forms.GroupBox groupBoxDate;
        private System.Windows.Forms.CheckBox checkBoxOH_DatePromise;
        private System.Windows.Forms.CheckBox checkBoxOH_DateRequest;
        private System.Windows.Forms.DateTimePicker dateTimePickerOH_DatePromise;
        private System.Windows.Forms.DateTimePicker dateTimePickerOH_DateRequest;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.TextBox textBox44;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox textBox45;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.TextBox textBox46;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.TextBox textBox47;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.TextBox textBox48;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.TextBox textBox49;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.TextBox textBox50;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.TextBox textBox51;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.TextBox textBox53;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.TextBox textBox54;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.TextBox textBox55;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.DataGrid dataGridOrderItems;
        private System.Windows.Forms.GroupBox groupBox19;
        private NujitCustomWinControls.NumericTextBox numericTextBox23;
        private System.Windows.Forms.Label label75;
        private NujitCustomWinControls.NumericTextBox numericTextBox24;
        private System.Windows.Forms.Label lIHDiscountTot;
        private NujitCustomWinControls.NumericTextBox ntbIH_DiscountTot;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.DataGrid dGridDiscounts;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.Windows.Forms.CheckBox checkBox17;
        private System.Windows.Forms.CheckBox checkBox16;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.CheckBox checkBox22;
        private System.Windows.Forms.CheckBox checkBox23;
        private System.Windows.Forms.CheckBox checkBox24;
        private System.Windows.Forms.CheckBox checkBox25;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.CheckBox checkBox18;
        private System.Windows.Forms.CheckBox checkBox19;
        private System.Windows.Forms.CheckBox checkBox20;
        private System.Windows.Forms.CheckBox checkBox21;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.GroupBox groupBox26;
        private System.Windows.Forms.CheckBox cBoxIH_Emailed;
        private System.Windows.Forms.CheckBox cBoxIH_Faxed;
        private System.Windows.Forms.CheckBox cBoxIH_Printed;
        private System.Windows.Forms.CheckBox checkBox26;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.GroupBox gBoxAccounting;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.DateTimePicker dateTimePicker6;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.DateTimePicker dateTimePicker7;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.DateTimePicker dateTimePicker5;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.TextBox tBoxIH_FreigthTerms;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.TextBox textBox34;
        private System.Windows.Forms.Label lIHFreigthTerms;
        private System.Windows.Forms.TextBox textBox33;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private NujitCustomWinControls.NumericTextBox numericTextBox39;
        private NujitCustomWinControls.NumericTextBox numericTextBox38;
        private System.Windows.Forms.Label label40;
        private NujitCustomWinControls.NumericTextBox numericTextBox37;
        private System.Windows.Forms.Label label44;
        private NujitCustomWinControls.NumericTextBox numericTextBox36;
        private System.Windows.Forms.Label label45;
        private NujitCustomWinControls.NumericTextBox numericTextBox35;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox textBox29;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private NujitCustomWinControls.NumericTextBox numericTextBox9;
        private System.Windows.Forms.TextBox textBox32;
        private System.Windows.Forms.TextBox textBox52;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private NujitCustomWinControls.NumericTextBox numericTextBox14;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.TextBox textBox56;
        private System.Windows.Forms.Label label51;
        private NujitCustomWinControls.NumericTextBox numericTextBox15;
        private System.Windows.Forms.TextBox textBox57;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label80;
        private NujitCustomWinControls.NumericTextBox numericTextBox16;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.DataGrid dGridShowDetail;
        private System.Windows.Forms.TreeView treeViewInfo;
        private System.Windows.Forms.Button button6;
		private DataTable dataTable;
		private string rootLevel = "ROOT";
        private string layer1 = "LAYER1";
        private string layer2 = "LAYER2";
        private string layer3 = "LAYER3";
        private string layer4 = "LAYER4";

		#region Contructors
		public FormAddNewOrder()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();


			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			coreFactory = UtilCoreFactory.createCoreFactory();
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


		#endregion Contructors

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.labelOH_OrderNum = new System.Windows.Forms.Label();
            this.labelOH_Company = new System.Windows.Forms.Label();
            this.labelOH_Plant = new System.Windows.Forms.Label();
            this.textBoxOH_OrderNum = new System.Windows.Forms.TextBox();
            this.textBoxOH_Company = new System.Windows.Forms.TextBox();
            this.textBoxOH_Plant = new System.Windows.Forms.TextBox();
            this.textBoxOH_PO = new System.Windows.Forms.TextBox();
            this.labelOH_PO = new System.Windows.Forms.Label();
            this.textBoxOH_Currency = new System.Windows.Forms.TextBox();
            this.labelOH_Currency = new System.Windows.Forms.Label();
            this.labelOH_OrderDate = new System.Windows.Forms.Label();
            this.textBoxOH_OrderDate = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSaveOrder = new System.Windows.Forms.Button();
            this.contextMenuOrdersDtls = new System.Windows.Forms.ContextMenu();
            this.menuItemAddItem = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItemEditItem = new System.Windows.Forms.MenuItem();
            this.menuItemRemoveItem = new System.Windows.Forms.MenuItem();
            this.tabControlOrder = new System.Windows.Forms.TabControl();
            this.tabPageShip = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.textBox41 = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.textBox42 = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tBocIHShipToAdr1 = new System.Windows.Forms.TextBox();
            this.tBoxIH_ShipToAdr2 = new System.Windows.Forms.TextBox();
            this.lIHShipToAdr1 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.lCustCity = new System.Windows.Forms.Label();
            this.tBoxIH_ShipToAdr3 = new System.Windows.Forms.TextBox();
            this.lIHShipToAdr3 = new System.Windows.Forms.Label();
            this.lIHShipToAdr2 = new System.Windows.Forms.Label();
            this.lCustCountry = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.lCustRegion = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSchShipTo = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.textBox40 = new System.Windows.Forms.TextBox();
            this.btnSchSFContact = new System.Windows.Forms.Button();
            this.tBoxPSFPContact = new System.Windows.Forms.TextBox();
            this.lPSFContact = new System.Windows.Forms.Label();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxOH_BillToName = new System.Windows.Forms.TextBox();
            this.labelOH_BillToName = new System.Windows.Forms.Label();
            this.buttonSearchBillTo = new System.Windows.Forms.Button();
            this.textBoxOH_BillToNum = new System.Windows.Forms.TextBox();
            this.labelOH_BillToNum = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnShipFrom = new System.Windows.Forms.Button();
            this.labelOH_ShipVia = new System.Windows.Forms.Label();
            this.textBoxOH_ShipVia = new System.Windows.Forms.TextBox();
            this.tabPageDiscounts = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.numericTextBox23 = new NujitCustomWinControls.NumericTextBox();
            this.label75 = new System.Windows.Forms.Label();
            this.numericTextBox24 = new NujitCustomWinControls.NumericTextBox();
            this.lIHDiscountTot = new System.Windows.Forms.Label();
            this.ntbIH_DiscountTot = new NujitCustomWinControls.NumericTextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.dGridDiscounts = new System.Windows.Forms.DataGrid();
            this.buttonAddDiscGroup = new System.Windows.Forms.Button();
            this.buttonAddDiscount = new System.Windows.Forms.Button();
            this.buttonRemoveItem = new System.Windows.Forms.Button();
            this.buttonEditItem = new System.Windows.Forms.Button();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.tabPageContact = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.checkBox22 = new System.Windows.Forms.CheckBox();
            this.checkBox23 = new System.Windows.Forms.CheckBox();
            this.checkBox24 = new System.Windows.Forms.CheckBox();
            this.checkBox25 = new System.Windows.Forms.CheckBox();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.checkBox19 = new System.Windows.Forms.CheckBox();
            this.checkBox20 = new System.Windows.Forms.CheckBox();
            this.checkBox21 = new System.Windows.Forms.CheckBox();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.cBoxIH_Emailed = new System.Windows.Forms.CheckBox();
            this.cBoxIH_Faxed = new System.Windows.Forms.CheckBox();
            this.cBoxIH_Printed = new System.Windows.Forms.CheckBox();
            this.checkBox26 = new System.Windows.Forms.CheckBox();
            this.dgridContact = new System.Windows.Forms.DataGrid();
            this.btnEditPart = new System.Windows.Forms.Button();
            this.btnAddPart = new System.Windows.Forms.Button();
            this.btnDeletePart = new System.Windows.Forms.Button();
            this.tabPageDoc = new System.Windows.Forms.TabPage();
            this.tabPageItems = new System.Windows.Forms.TabPage();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.textBox53 = new System.Windows.Forms.TextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.textBox54 = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.textBox55 = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.textBox48 = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.textBox49 = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.textBox50 = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.textBox51 = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.textBox47 = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.textBox46 = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.textBox45 = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.textBox44 = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.dGridItems = new System.Windows.Forms.DataGrid();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.tabPageCom = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.dGridComponents = new System.Windows.Forms.DataGrid();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPageCharges = new System.Windows.Forms.TabPage();
            this.tabPageAcc = new System.Windows.Forms.TabPage();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.numericTextBox20 = new NujitCustomWinControls.NumericTextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.ntbID_RoyCharges = new NujitCustomWinControls.NumericTextBox();
            this.ntbId_FreigthAmt = new NujitCustomWinControls.NumericTextBox();
            this.lIDRoyCharges = new System.Windows.Forms.Label();
            this.lIdFreightAmt = new System.Windows.Forms.Label();
            this.numericTextBox21 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox22 = new NujitCustomWinControls.NumericTextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.tBoxID_GLSalesAcc = new System.Windows.Forms.TextBox();
            this.lIDGLSalesAcc = new System.Windows.Forms.Label();
            this.lIDGLCosAcc = new System.Windows.Forms.Label();
            this.tBoxID_GLCosAcc = new System.Windows.Forms.TextBox();
            this.tBoxID_GLCosType = new System.Windows.Forms.TextBox();
            this.lIDGLCosType = new System.Windows.Forms.Label();
            this.gBoxTax = new System.Windows.Forms.GroupBox();
            this.ntbID_TaxAmtTot = new NujitCustomWinControls.NumericTextBox();
            this.lIDTaxAmtTot = new System.Windows.Forms.Label();
            this.ntbID_LineExtwTax = new NujitCustomWinControls.NumericTextBox();
            this.lIDLineExtwTax = new System.Windows.Forms.Label();
            this.ntbID_Tax2Amt = new NujitCustomWinControls.NumericTextBox();
            this.ntbID_Tax3Amt = new NujitCustomWinControls.NumericTextBox();
            this.ntbID_Tax1Amt = new NujitCustomWinControls.NumericTextBox();
            this.lIDTax2Amt = new System.Windows.Forms.Label();
            this.lIdTax3Amt = new System.Windows.Forms.Label();
            this.lIDTax1Amt = new System.Windows.Forms.Label();
            this.gBoxCost = new System.Windows.Forms.GroupBox();
            this.numericTextBox1 = new NujitCustomWinControls.NumericTextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.numericTextBox2 = new NujitCustomWinControls.NumericTextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.numericTextBox3 = new NujitCustomWinControls.NumericTextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.numericTextBox4 = new NujitCustomWinControls.NumericTextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.numericTextBox5 = new NujitCustomWinControls.NumericTextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.numericTextBox13 = new NujitCustomWinControls.NumericTextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.numericTextBox12 = new NujitCustomWinControls.NumericTextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.numericTextBox11 = new NujitCustomWinControls.NumericTextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.numericTextBox10 = new NujitCustomWinControls.NumericTextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.numericTextBox7 = new NujitCustomWinControls.NumericTextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.numericTextBox6 = new NujitCustomWinControls.NumericTextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.numericTextBox8 = new NujitCustomWinControls.NumericTextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.numericTextBox19 = new NujitCustomWinControls.NumericTextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.ntbOutsideCost = new NujitCustomWinControls.NumericTextBox();
            this.lIdOutsideCost = new System.Windows.Forms.Label();
            this.ntbID_MatCost = new NujitCustomWinControls.NumericTextBox();
            this.ntbID_OHCost = new NujitCustomWinControls.NumericTextBox();
            this.lIdOHCost = new System.Windows.Forms.Label();
            this.lIdMatCost = new System.Windows.Forms.Label();
            this.ntbId_UnitCost = new NujitCustomWinControls.NumericTextBox();
            this.ntbId_LabCost = new NujitCustomWinControls.NumericTextBox();
            this.ntbID_CostExt = new NujitCustomWinControls.NumericTextBox();
            this.lIdUnitCost = new System.Windows.Forms.Label();
            this.lIdLabCost = new System.Windows.Forms.Label();
            this.lIdCostExt = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelOH_Tax1Total = new System.Windows.Forms.Label();
            this.textBoxOH_CommissTot = new System.Windows.Forms.TextBox();
            this.labeOH_Tax2Total = new System.Windows.Forms.Label();
            this.textBoxOH_Tax2Total = new System.Windows.Forms.TextBox();
            this.labelOH_Tax3Total = new System.Windows.Forms.Label();
            this.textBoxOH_Tax3Total = new System.Windows.Forms.TextBox();
            this.labelOH_DiscountTot = new System.Windows.Forms.Label();
            this.textBoxOH_DiscountTot = new System.Windows.Forms.TextBox();
            this.labelOH_OrderNet = new System.Windows.Forms.Label();
            this.textBoxOH_OrderNet = new System.Windows.Forms.TextBox();
            this.labelOH_RoyaltyTot = new System.Windows.Forms.Label();
            this.textBoxOH_Tax1Total = new System.Windows.Forms.TextBox();
            this.labelOH_OrderTotal = new System.Windows.Forms.Label();
            this.textBoxOH_RoyaltyTot = new System.Windows.Forms.TextBox();
            this.textBoxOH_OrderTotal = new System.Windows.Forms.TextBox();
            this.labelOH_CommissTot = new System.Windows.Forms.Label();
            this.tabPageSales = new System.Windows.Forms.TabPage();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.labelOH_Terms = new System.Windows.Forms.Label();
            this.textBoxOH_Territory = new System.Windows.Forms.TextBox();
            this.textBoxOH_DistributionLoc = new System.Windows.Forms.TextBox();
            this.labelOH_Territory = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxOH_Terms = new System.Windows.Forms.TextBox();
            this.buttonOH_Note = new System.Windows.Forms.Button();
            this.labelOH_HoldStatus = new System.Windows.Forms.Label();
            this.checkBoxOH_Note = new System.Windows.Forms.CheckBox();
            this.textBoxOH_HoldStatus = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdoQuote = new System.Windows.Forms.RadioButton();
            this.rdoPO = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rdoRhubarb = new System.Windows.Forms.RadioButton();
            this.rdoRetail = new System.Windows.Forms.RadioButton();
            this.groupBoxDate = new System.Windows.Forms.GroupBox();
            this.checkBoxOH_DatePromise = new System.Windows.Forms.CheckBox();
            this.checkBoxOH_DateRequest = new System.Windows.Forms.CheckBox();
            this.dateTimePickerOH_DatePromise = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerOH_DateRequest = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox43 = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.textBoxOH_ComRate = new System.Windows.Forms.TextBox();
            this.labelOH_ComRate = new System.Windows.Forms.Label();
            this.textBoxOH_ComPercent = new System.Windows.Forms.TextBox();
            this.labelOH_ComPercent = new System.Windows.Forms.Label();
            this.gBoxSalesCode = new System.Windows.Forms.GroupBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.tBoxID_SC1 = new System.Windows.Forms.TextBox();
            this.lIDSc5 = new System.Windows.Forms.Label();
            this.tBoxID_SC4 = new System.Windows.Forms.TextBox();
            this.lIDSc1 = new System.Windows.Forms.Label();
            this.lIDSc3 = new System.Windows.Forms.Label();
            this.lIDSc6 = new System.Windows.Forms.Label();
            this.tBoxID_SC3 = new System.Windows.Forms.TextBox();
            this.lIDSc4 = new System.Windows.Forms.Label();
            this.tBoxID_SC6 = new System.Windows.Forms.TextBox();
            this.tBoxID_SC5 = new System.Windows.Forms.TextBox();
            this.lIDSc2 = new System.Windows.Forms.Label();
            this.tBoxID_SC2 = new System.Windows.Forms.TextBox();
            this.btnSchSc = new System.Windows.Forms.Button();
            this.tabPageDistribution = new System.Windows.Forms.TabPage();
            this.tabPageFreigth = new System.Windows.Forms.TabPage();
            this.gBoxAccounting = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker6 = new System.Windows.Forms.DateTimePicker();
            this.label100 = new System.Windows.Forms.Label();
            this.dateTimePicker7 = new System.Windows.Forms.DateTimePicker();
            this.label101 = new System.Windows.Forms.Label();
            this.dateTimePicker5 = new System.Windows.Forms.DateTimePicker();
            this.label99 = new System.Windows.Forms.Label();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.label98 = new System.Windows.Forms.Label();
            this.tBoxIH_FreigthTerms = new System.Windows.Forms.TextBox();
            this.label97 = new System.Windows.Forms.Label();
            this.textBox34 = new System.Windows.Forms.TextBox();
            this.lIHFreigthTerms = new System.Windows.Forms.Label();
            this.textBox33 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.numericTextBox39 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox38 = new NujitCustomWinControls.NumericTextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.numericTextBox37 = new NujitCustomWinControls.NumericTextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.numericTextBox36 = new NujitCustomWinControls.NumericTextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.numericTextBox35 = new NujitCustomWinControls.NumericTextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.numericTextBox9 = new NujitCustomWinControls.NumericTextBox();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.textBox52 = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.numericTextBox14 = new NujitCustomWinControls.NumericTextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.textBox56 = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.numericTextBox15 = new NujitCustomWinControls.NumericTextBox();
            this.textBox57 = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.numericTextBox16 = new NujitCustomWinControls.NumericTextBox();
            this.label81 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.dGridShowDetail = new System.Windows.Forms.DataGrid();
            this.treeViewInfo = new System.Windows.Forms.TreeView();
            this.button6 = new System.Windows.Forms.Button();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.tabPageMaterials = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.dGtidMaterials = new System.Windows.Forms.DataGrid();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridOrderItems = new System.Windows.Forms.DataGrid();
            this.textBoxEmployeeName = new System.Windows.Forms.TextBox();
            this.labelEmployeeName = new System.Windows.Forms.Label();
            this.textBoxOH_SalesPerson = new System.Windows.Forms.TextBox();
            this.labelOH_SalesPerson = new System.Windows.Forms.Label();
            this.buttonSearchEmployee = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.textBox39 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.textBox38 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox37 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox35 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label28 = new System.Windows.Forms.Label();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox36 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tabControlOrder.SuspendLayout();
            this.tabPageShip.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPageDiscounts.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridDiscounts)).BeginInit();
            this.tabPageContact.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridContact)).BeginInit();
            this.tabPageItems.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridItems)).BeginInit();
            this.tabPageCom.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridComponents)).BeginInit();
            this.tabPageAcc.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.gBoxTax.SuspendLayout();
            this.gBoxCost.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageSales.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBoxDate.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gBoxSalesCode.SuspendLayout();
            this.tabPageFreigth.SuspendLayout();
            this.gBoxAccounting.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGridShowDetail)).BeginInit();
            this.tabPageMaterials.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGtidMaterials)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderItems)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelOH_OrderNum
            // 
            this.labelOH_OrderNum.Location = new System.Drawing.Point(8, 24);
            this.labelOH_OrderNum.Name = "labelOH_OrderNum";
            this.labelOH_OrderNum.Size = new System.Drawing.Size(48, 20);
            this.labelOH_OrderNum.TabIndex = 2;
            this.labelOH_OrderNum.Text = "Order #";
            this.labelOH_OrderNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOH_Company
            // 
            this.labelOH_Company.Location = new System.Drawing.Point(8, 84);
            this.labelOH_Company.Name = "labelOH_Company";
            this.labelOH_Company.Size = new System.Drawing.Size(56, 20);
            this.labelOH_Company.TabIndex = 8;
            this.labelOH_Company.Text = "Company";
            this.labelOH_Company.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOH_Plant
            // 
            this.labelOH_Plant.Location = new System.Drawing.Point(8, 108);
            this.labelOH_Plant.Name = "labelOH_Plant";
            this.labelOH_Plant.Size = new System.Drawing.Size(56, 16);
            this.labelOH_Plant.TabIndex = 12;
            this.labelOH_Plant.Text = "Plant";
            this.labelOH_Plant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_OrderNum
            // 
            this.textBoxOH_OrderNum.Location = new System.Drawing.Point(72, 24);
            this.textBoxOH_OrderNum.Name = "textBoxOH_OrderNum";
            this.textBoxOH_OrderNum.ReadOnly = true;
            this.textBoxOH_OrderNum.Size = new System.Drawing.Size(72, 20);
            this.textBoxOH_OrderNum.TabIndex = 10;
            this.textBoxOH_OrderNum.Text = "0";
            // 
            // textBoxOH_Company
            // 
            this.textBoxOH_Company.Location = new System.Drawing.Point(72, 84);
            this.textBoxOH_Company.MaxLength = 10;
            this.textBoxOH_Company.Name = "textBoxOH_Company";
            this.textBoxOH_Company.Size = new System.Drawing.Size(72, 20);
            this.textBoxOH_Company.TabIndex = 5;
            this.textBoxOH_Company.Text = "";
            // 
            // textBoxOH_Plant
            // 
            this.textBoxOH_Plant.Location = new System.Drawing.Point(72, 104);
            this.textBoxOH_Plant.MaxLength = 10;
            this.textBoxOH_Plant.Name = "textBoxOH_Plant";
            this.textBoxOH_Plant.ReadOnly = true;
            this.textBoxOH_Plant.Size = new System.Drawing.Size(72, 20);
            this.textBoxOH_Plant.TabIndex = 10;
            this.textBoxOH_Plant.Text = "Dft";
            // 
            // textBoxOH_PO
            // 
            this.textBoxOH_PO.Location = new System.Drawing.Point(88, 36);
            this.textBoxOH_PO.MaxLength = 40;
            this.textBoxOH_PO.Name = "textBoxOH_PO";
            this.textBoxOH_PO.Size = new System.Drawing.Size(192, 20);
            this.textBoxOH_PO.TabIndex = 15;
            this.textBoxOH_PO.Text = "";
            // 
            // labelOH_PO
            // 
            this.labelOH_PO.Location = new System.Drawing.Point(16, 36);
            this.labelOH_PO.Name = "labelOH_PO";
            this.labelOH_PO.Size = new System.Drawing.Size(72, 20);
            this.labelOH_PO.TabIndex = 27;
            this.labelOH_PO.Text = "Order #";
            this.labelOH_PO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_Currency
            // 
            this.textBoxOH_Currency.Location = new System.Drawing.Point(72, 44);
            this.textBoxOH_Currency.MaxLength = 5;
            this.textBoxOH_Currency.Name = "textBoxOH_Currency";
            this.textBoxOH_Currency.Size = new System.Drawing.Size(72, 20);
            this.textBoxOH_Currency.TabIndex = 20;
            this.textBoxOH_Currency.Text = "";
            // 
            // labelOH_Currency
            // 
            this.labelOH_Currency.Location = new System.Drawing.Point(8, 44);
            this.labelOH_Currency.Name = "labelOH_Currency";
            this.labelOH_Currency.Size = new System.Drawing.Size(56, 20);
            this.labelOH_Currency.TabIndex = 37;
            this.labelOH_Currency.Text = "Currency";
            this.labelOH_Currency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOH_OrderDate
            // 
            this.labelOH_OrderDate.Location = new System.Drawing.Point(16, 16);
            this.labelOH_OrderDate.Name = "labelOH_OrderDate";
            this.labelOH_OrderDate.Size = new System.Drawing.Size(64, 20);
            this.labelOH_OrderDate.TabIndex = 67;
            this.labelOH_OrderDate.Text = "Order Date";
            this.labelOH_OrderDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_OrderDate
            // 
            this.textBoxOH_OrderDate.Location = new System.Drawing.Point(88, 16);
            this.textBoxOH_OrderDate.MaxLength = 10;
            this.textBoxOH_OrderDate.Name = "textBoxOH_OrderDate";
            this.textBoxOH_OrderDate.ReadOnly = true;
            this.textBoxOH_OrderDate.Size = new System.Drawing.Size(96, 20);
            this.textBoxOH_OrderDate.TabIndex = 95;
            this.textBoxOH_OrderDate.TabStop = false;
            this.textBoxOH_OrderDate.Text = "";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(784, 560);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.TabIndex = 135;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSaveOrder
            // 
            this.buttonSaveOrder.Location = new System.Drawing.Point(704, 560);
            this.buttonSaveOrder.Name = "buttonSaveOrder";
            this.buttonSaveOrder.TabIndex = 115;
            this.buttonSaveOrder.Text = "Save ";
            this.buttonSaveOrder.Click += new System.EventHandler(this.buttonSaveOrder_Click);
            // 
            // contextMenuOrdersDtls
            // 
            this.contextMenuOrdersDtls.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                                  this.menuItemAddItem,
                                                                                                  this.menuItem2,
                                                                                                  this.menuItemEditItem,
                                                                                                  this.menuItemRemoveItem});
            // 
            // menuItemAddItem
            // 
            this.menuItemAddItem.Index = 0;
            this.menuItemAddItem.Text = "Add Item";
            this.menuItemAddItem.Click += new System.EventHandler(this.menuItemAddItem_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "-";
            // 
            // menuItemEditItem
            // 
            this.menuItemEditItem.Index = 2;
            this.menuItemEditItem.Text = "Edit Item";
            this.menuItemEditItem.Click += new System.EventHandler(this.menuItemEditItem_Click);
            // 
            // menuItemRemoveItem
            // 
            this.menuItemRemoveItem.Index = 3;
            this.menuItemRemoveItem.Text = "Remove Item";
            this.menuItemRemoveItem.Click += new System.EventHandler(this.menuItemRemoveItem_Click);
            // 
            // tabControlOrder
            // 
            this.tabControlOrder.Controls.Add(this.tabPageShip);
            this.tabControlOrder.Controls.Add(this.tabPageDiscounts);
            this.tabControlOrder.Controls.Add(this.tabPageContact);
            this.tabControlOrder.Controls.Add(this.tabPageDoc);
            this.tabControlOrder.Controls.Add(this.tabPageItems);
            this.tabControlOrder.Controls.Add(this.tabPageCom);
            this.tabControlOrder.Controls.Add(this.tabPageCharges);
            this.tabControlOrder.Controls.Add(this.tabPageAcc);
            this.tabControlOrder.Controls.Add(this.tabPageSales);
            this.tabControlOrder.Controls.Add(this.tabPageDistribution);
            this.tabControlOrder.Controls.Add(this.tabPageFreigth);
            this.tabControlOrder.Controls.Add(this.tabPageConfig);
            this.tabControlOrder.Controls.Add(this.tabPageMaterials);
            this.tabControlOrder.Controls.Add(this.tabPage1);
            this.tabControlOrder.Location = new System.Drawing.Point(8, 144);
            this.tabControlOrder.Name = "tabControlOrder";
            this.tabControlOrder.SelectedIndex = 0;
            this.tabControlOrder.Size = new System.Drawing.Size(848, 408);
            this.tabControlOrder.TabIndex = 136;
            this.tabControlOrder.SelectedIndexChanged += new System.EventHandler(this.tabControlOrder_SelectedIndexChanged);
            // 
            // tabPageShip
            // 
            this.tabPageShip.Controls.Add(this.groupBox3);
            this.tabPageShip.Controls.Add(this.groupBox14);
            this.tabPageShip.Controls.Add(this.groupBox7);
            this.tabPageShip.Location = new System.Drawing.Point(4, 22);
            this.tabPageShip.Name = "tabPageShip";
            this.tabPageShip.Size = new System.Drawing.Size(840, 382);
            this.tabPageShip.TabIndex = 0;
            this.tabPageShip.Text = "Shipping";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label35);
            this.groupBox3.Controls.Add(this.textBox41);
            this.groupBox3.Controls.Add(this.button12);
            this.groupBox3.Controls.Add(this.textBox42);
            this.groupBox3.Controls.Add(this.label36);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Controls.Add(this.textBox27);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.tBocIHShipToAdr1);
            this.groupBox3.Controls.Add(this.tBoxIH_ShipToAdr2);
            this.groupBox3.Controls.Add(this.lIHShipToAdr1);
            this.groupBox3.Controls.Add(this.textBox6);
            this.groupBox3.Controls.Add(this.lCustCity);
            this.groupBox3.Controls.Add(this.tBoxIH_ShipToAdr3);
            this.groupBox3.Controls.Add(this.lIHShipToAdr3);
            this.groupBox3.Controls.Add(this.lIHShipToAdr2);
            this.groupBox3.Controls.Add(this.lCustCountry);
            this.groupBox3.Controls.Add(this.textBox18);
            this.groupBox3.Controls.Add(this.textBox19);
            this.groupBox3.Controls.Add(this.lCustRegion);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textBox31);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnSchShipTo);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(448, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(336, 304);
            this.groupBox3.TabIndex = 91;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ship To";
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(8, 276);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(48, 20);
            this.label35.TabIndex = 113;
            this.label35.Text = "Phone #";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox41
            // 
            this.textBox41.Location = new System.Drawing.Point(80, 276);
            this.textBox41.MaxLength = 20;
            this.textBox41.Name = "textBox41";
            this.textBox41.Size = new System.Drawing.Size(120, 20);
            this.textBox41.TabIndex = 112;
            this.textBox41.Text = "";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(208, 256);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(30, 16);
            this.button12.TabIndex = 111;
            this.button12.Text = "...";
            // 
            // textBox42
            // 
            this.textBox42.Location = new System.Drawing.Point(80, 256);
            this.textBox42.MaxLength = 20;
            this.textBox42.Name = "textBox42";
            this.textBox42.Size = new System.Drawing.Size(120, 20);
            this.textBox42.TabIndex = 110;
            this.textBox42.Text = "";
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(8, 256);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(60, 20);
            this.label36.TabIndex = 109;
            this.label36.Text = "Contact";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 20);
            this.label7.TabIndex = 79;
            this.label7.Text = "Region";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(80, 196);
            this.textBox5.MaxLength = 20;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(120, 20);
            this.textBox5.TabIndex = 78;
            this.textBox5.Text = "";
            // 
            // textBox27
            // 
            this.textBox27.Location = new System.Drawing.Point(80, 136);
            this.textBox27.MaxLength = 20;
            this.textBox27.Name = "textBox27";
            this.textBox27.ReadOnly = true;
            this.textBox27.Size = new System.Drawing.Size(120, 20);
            this.textBox27.TabIndex = 76;
            this.textBox27.Text = "";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 77;
            this.label8.Text = "City";
            // 
            // comboBox1
            // 
            this.comboBox1.Items.AddRange(new object[] {
                                                           "Bussiness",
                                                           "Consumer"});
            this.comboBox1.Location = new System.Drawing.Point(80, 236);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(80, 21);
            this.comboBox1.TabIndex = 59;
            this.comboBox1.Text = "Bussiness";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(8, 237);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 20);
            this.label19.TabIndex = 58;
            this.label19.Text = "Ship To Type";
            // 
            // tBocIHShipToAdr1
            // 
            this.tBocIHShipToAdr1.Location = new System.Drawing.Point(80, 56);
            this.tBocIHShipToAdr1.MaxLength = 40;
            this.tBocIHShipToAdr1.Name = "tBocIHShipToAdr1";
            this.tBocIHShipToAdr1.ReadOnly = true;
            this.tBocIHShipToAdr1.Size = new System.Drawing.Size(248, 20);
            this.tBocIHShipToAdr1.TabIndex = 42;
            this.tBocIHShipToAdr1.Text = "";
            // 
            // tBoxIH_ShipToAdr2
            // 
            this.tBoxIH_ShipToAdr2.Location = new System.Drawing.Point(80, 76);
            this.tBoxIH_ShipToAdr2.MaxLength = 40;
            this.tBoxIH_ShipToAdr2.Name = "tBoxIH_ShipToAdr2";
            this.tBoxIH_ShipToAdr2.ReadOnly = true;
            this.tBoxIH_ShipToAdr2.Size = new System.Drawing.Size(248, 20);
            this.tBoxIH_ShipToAdr2.TabIndex = 50;
            this.tBoxIH_ShipToAdr2.Text = "";
            // 
            // lIHShipToAdr1
            // 
            this.lIHShipToAdr1.Location = new System.Drawing.Point(8, 56);
            this.lIHShipToAdr1.Name = "lIHShipToAdr1";
            this.lIHShipToAdr1.Size = new System.Drawing.Size(56, 20);
            this.lIHShipToAdr1.TabIndex = 43;
            this.lIHShipToAdr1.Text = "Address 1";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(80, 116);
            this.textBox6.MaxLength = 20;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(120, 20);
            this.textBox6.TabIndex = 52;
            this.textBox6.Text = "";
            // 
            // lCustCity
            // 
            this.lCustCity.Location = new System.Drawing.Point(8, 116);
            this.lCustCity.Name = "lCustCity";
            this.lCustCity.Size = new System.Drawing.Size(64, 20);
            this.lCustCity.TabIndex = 53;
            this.lCustCity.Text = "Prov/State";
            // 
            // tBoxIH_ShipToAdr3
            // 
            this.tBoxIH_ShipToAdr3.Location = new System.Drawing.Point(80, 96);
            this.tBoxIH_ShipToAdr3.MaxLength = 40;
            this.tBoxIH_ShipToAdr3.Name = "tBoxIH_ShipToAdr3";
            this.tBoxIH_ShipToAdr3.ReadOnly = true;
            this.tBoxIH_ShipToAdr3.Size = new System.Drawing.Size(248, 20);
            this.tBoxIH_ShipToAdr3.TabIndex = 48;
            this.tBoxIH_ShipToAdr3.Text = "";
            // 
            // lIHShipToAdr3
            // 
            this.lIHShipToAdr3.Location = new System.Drawing.Point(8, 96);
            this.lIHShipToAdr3.Name = "lIHShipToAdr3";
            this.lIHShipToAdr3.Size = new System.Drawing.Size(56, 20);
            this.lIHShipToAdr3.TabIndex = 49;
            this.lIHShipToAdr3.Text = "Address 3";
            // 
            // lIHShipToAdr2
            // 
            this.lIHShipToAdr2.Location = new System.Drawing.Point(8, 76);
            this.lIHShipToAdr2.Name = "lIHShipToAdr2";
            this.lIHShipToAdr2.Size = new System.Drawing.Size(56, 20);
            this.lIHShipToAdr2.TabIndex = 51;
            this.lIHShipToAdr2.Text = "Address 2";
            // 
            // lCustCountry
            // 
            this.lCustCountry.Location = new System.Drawing.Point(8, 156);
            this.lCustCountry.Name = "lCustCountry";
            this.lCustCountry.Size = new System.Drawing.Size(56, 20);
            this.lCustCountry.TabIndex = 55;
            this.lCustCountry.Text = "Country";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(80, 156);
            this.textBox18.MaxLength = 20;
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(120, 20);
            this.textBox18.TabIndex = 54;
            this.textBox18.Text = "";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(80, 216);
            this.textBox19.MaxLength = 20;
            this.textBox19.Name = "textBox19";
            this.textBox19.ReadOnly = true;
            this.textBox19.Size = new System.Drawing.Size(120, 20);
            this.textBox19.TabIndex = 56;
            this.textBox19.Text = "";
            // 
            // lCustRegion
            // 
            this.lCustRegion.Location = new System.Drawing.Point(8, 216);
            this.lCustRegion.Name = "lCustRegion";
            this.lCustRegion.Size = new System.Drawing.Size(56, 20);
            this.lCustRegion.TabIndex = 57;
            this.lCustRegion.Text = "Territory";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 20);
            this.label9.TabIndex = 94;
            this.label9.Text = "Post Zip";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox31
            // 
            this.textBox31.Location = new System.Drawing.Point(80, 176);
            this.textBox31.MaxLength = 20;
            this.textBox31.Name = "textBox31";
            this.textBox31.ReadOnly = true;
            this.textBox31.Size = new System.Drawing.Size(120, 20);
            this.textBox31.TabIndex = 95;
            this.textBox31.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 36);
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(248, 20);
            this.textBox1.TabIndex = 20;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 24);
            this.label1.TabIndex = 72;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSchShipTo
            // 
            this.btnSchShipTo.Location = new System.Drawing.Point(160, 16);
            this.btnSchShipTo.Name = "btnSchShipTo";
            this.btnSchShipTo.Size = new System.Drawing.Size(30, 16);
            this.btnSchShipTo.TabIndex = 15;
            this.btnSchShipTo.Text = "...";
            this.btnSchShipTo.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(80, 16);
            this.textBox2.MaxLength = 10;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(72, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 24);
            this.label2.TabIndex = 23;
            this.label2.Text = "Ship To";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.label32);
            this.groupBox14.Controls.Add(this.textBox40);
            this.groupBox14.Controls.Add(this.btnSchSFContact);
            this.groupBox14.Controls.Add(this.tBoxPSFPContact);
            this.groupBox14.Controls.Add(this.lPSFContact);
            this.groupBox14.Controls.Add(this.textBox30);
            this.groupBox14.Controls.Add(this.label3);
            this.groupBox14.Controls.Add(this.label4);
            this.groupBox14.Controls.Add(this.textBox28);
            this.groupBox14.Controls.Add(this.textBox3);
            this.groupBox14.Controls.Add(this.label6);
            this.groupBox14.Controls.Add(this.textBox4);
            this.groupBox14.Controls.Add(this.textBox13);
            this.groupBox14.Controls.Add(this.label21);
            this.groupBox14.Controls.Add(this.textBox14);
            this.groupBox14.Controls.Add(this.label22);
            this.groupBox14.Controls.Add(this.textBox15);
            this.groupBox14.Controls.Add(this.label23);
            this.groupBox14.Controls.Add(this.label24);
            this.groupBox14.Controls.Add(this.label25);
            this.groupBox14.Controls.Add(this.textBox16);
            this.groupBox14.Controls.Add(this.textBox17);
            this.groupBox14.Controls.Add(this.label26);
            this.groupBox14.Controls.Add(this.comboBox2);
            this.groupBox14.Controls.Add(this.label20);
            this.groupBox14.Controls.Add(this.textBoxOH_BillToName);
            this.groupBox14.Controls.Add(this.labelOH_BillToName);
            this.groupBox14.Controls.Add(this.buttonSearchBillTo);
            this.groupBox14.Controls.Add(this.textBoxOH_BillToNum);
            this.groupBox14.Controls.Add(this.labelOH_BillToNum);
            this.groupBox14.Location = new System.Drawing.Point(64, 72);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(336, 304);
            this.groupBox14.TabIndex = 90;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Bill To";
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(8, 276);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(48, 20);
            this.label32.TabIndex = 108;
            this.label32.Text = "Phone #";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox40
            // 
            this.textBox40.Location = new System.Drawing.Point(80, 276);
            this.textBox40.MaxLength = 20;
            this.textBox40.Name = "textBox40";
            this.textBox40.Size = new System.Drawing.Size(120, 20);
            this.textBox40.TabIndex = 107;
            this.textBox40.Text = "";
            // 
            // btnSchSFContact
            // 
            this.btnSchSFContact.Location = new System.Drawing.Point(208, 256);
            this.btnSchSFContact.Name = "btnSchSFContact";
            this.btnSchSFContact.Size = new System.Drawing.Size(30, 16);
            this.btnSchSFContact.TabIndex = 106;
            this.btnSchSFContact.Text = "...";
            // 
            // tBoxPSFPContact
            // 
            this.tBoxPSFPContact.Location = new System.Drawing.Point(80, 256);
            this.tBoxPSFPContact.MaxLength = 20;
            this.tBoxPSFPContact.Name = "tBoxPSFPContact";
            this.tBoxPSFPContact.Size = new System.Drawing.Size(120, 20);
            this.tBoxPSFPContact.TabIndex = 105;
            this.tBoxPSFPContact.Text = "";
            // 
            // lPSFContact
            // 
            this.lPSFContact.Location = new System.Drawing.Point(8, 256);
            this.lPSFContact.Name = "lPSFContact";
            this.lPSFContact.Size = new System.Drawing.Size(60, 20);
            this.lPSFContact.TabIndex = 104;
            this.lPSFContact.Text = "Contact";
            this.lPSFContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox30
            // 
            this.textBox30.Location = new System.Drawing.Point(80, 176);
            this.textBox30.MaxLength = 20;
            this.textBox30.Name = "textBox30";
            this.textBox30.ReadOnly = true;
            this.textBox30.Size = new System.Drawing.Size(120, 20);
            this.textBox30.TabIndex = 93;
            this.textBox30.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 92;
            this.label3.Text = "Post Zip";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 77;
            this.label4.Text = "Region";
            // 
            // textBox28
            // 
            this.textBox28.Location = new System.Drawing.Point(80, 196);
            this.textBox28.MaxLength = 20;
            this.textBox28.Name = "textBox28";
            this.textBox28.ReadOnly = true;
            this.textBox28.Size = new System.Drawing.Size(120, 20);
            this.textBox28.TabIndex = 76;
            this.textBox28.Text = "";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(80, 136);
            this.textBox3.MaxLength = 20;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(120, 20);
            this.textBox3.TabIndex = 74;
            this.textBox3.Text = "";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 75;
            this.label6.Text = "City";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(80, 56);
            this.textBox4.MaxLength = 40;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(248, 20);
            this.textBox4.TabIndex = 60;
            this.textBox4.Text = "";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(80, 76);
            this.textBox13.MaxLength = 40;
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(248, 20);
            this.textBox13.TabIndex = 64;
            this.textBox13.Text = "";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(8, 56);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 20);
            this.label21.TabIndex = 61;
            this.label21.Text = "Address 1";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(80, 116);
            this.textBox14.MaxLength = 20;
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(120, 20);
            this.textBox14.TabIndex = 66;
            this.textBox14.Text = "";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(8, 116);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 20);
            this.label22.TabIndex = 67;
            this.label22.Text = "Prov/State";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(80, 96);
            this.textBox15.MaxLength = 40;
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(248, 20);
            this.textBox15.TabIndex = 62;
            this.textBox15.Text = "";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(8, 96);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 20);
            this.label23.TabIndex = 63;
            this.label23.Text = "Address 3";
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(8, 76);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 20);
            this.label24.TabIndex = 65;
            this.label24.Text = "Address 2";
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(8, 156);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 20);
            this.label25.TabIndex = 69;
            this.label25.Text = "Country";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(80, 156);
            this.textBox16.MaxLength = 20;
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(120, 20);
            this.textBox16.TabIndex = 68;
            this.textBox16.Text = "";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(80, 216);
            this.textBox17.MaxLength = 20;
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new System.Drawing.Size(120, 20);
            this.textBox17.TabIndex = 70;
            this.textBox17.Text = "";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(8, 216);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 20);
            this.label26.TabIndex = 71;
            this.label26.Text = "Territory";
            // 
            // comboBox2
            // 
            this.comboBox2.Items.AddRange(new object[] {
                                                           "Bussiness",
                                                           "Consumer"});
            this.comboBox2.Location = new System.Drawing.Point(80, 236);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(80, 21);
            this.comboBox2.TabIndex = 73;
            this.comboBox2.Text = "Bussiness";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(8, 237);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 20);
            this.label20.TabIndex = 72;
            this.label20.Text = "Bill To Type";
            // 
            // textBoxOH_BillToName
            // 
            this.textBoxOH_BillToName.Location = new System.Drawing.Point(80, 36);
            this.textBoxOH_BillToName.MaxLength = 50;
            this.textBoxOH_BillToName.Name = "textBoxOH_BillToName";
            this.textBoxOH_BillToName.ReadOnly = true;
            this.textBoxOH_BillToName.Size = new System.Drawing.Size(248, 20);
            this.textBoxOH_BillToName.TabIndex = 20;
            this.textBoxOH_BillToName.TabStop = false;
            this.textBoxOH_BillToName.Text = "";
            // 
            // labelOH_BillToName
            // 
            this.labelOH_BillToName.Location = new System.Drawing.Point(8, 32);
            this.labelOH_BillToName.Name = "labelOH_BillToName";
            this.labelOH_BillToName.Size = new System.Drawing.Size(72, 24);
            this.labelOH_BillToName.TabIndex = 72;
            this.labelOH_BillToName.Text = "Name";
            this.labelOH_BillToName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonSearchBillTo
            // 
            this.buttonSearchBillTo.Location = new System.Drawing.Point(160, 16);
            this.buttonSearchBillTo.Name = "buttonSearchBillTo";
            this.buttonSearchBillTo.Size = new System.Drawing.Size(30, 16);
            this.buttonSearchBillTo.TabIndex = 15;
            this.buttonSearchBillTo.Text = "...";
            this.buttonSearchBillTo.Click += new System.EventHandler(this.buttonSearchBillTo_Click);
            // 
            // textBoxOH_BillToNum
            // 
            this.textBoxOH_BillToNum.Location = new System.Drawing.Point(80, 16);
            this.textBoxOH_BillToNum.MaxLength = 10;
            this.textBoxOH_BillToNum.Name = "textBoxOH_BillToNum";
            this.textBoxOH_BillToNum.ReadOnly = true;
            this.textBoxOH_BillToNum.Size = new System.Drawing.Size(72, 20);
            this.textBoxOH_BillToNum.TabIndex = 5;
            this.textBoxOH_BillToNum.Text = "";
            // 
            // labelOH_BillToNum
            // 
            this.labelOH_BillToNum.Location = new System.Drawing.Point(8, 12);
            this.labelOH_BillToNum.Name = "labelOH_BillToNum";
            this.labelOH_BillToNum.Size = new System.Drawing.Size(72, 24);
            this.labelOH_BillToNum.TabIndex = 23;
            this.labelOH_BillToNum.Text = "Bill To";
            this.labelOH_BillToNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.labelOH_OrderDate);
            this.groupBox7.Controls.Add(this.textBoxOH_OrderDate);
            this.groupBox7.Controls.Add(this.labelOH_PO);
            this.groupBox7.Controls.Add(this.textBoxOH_PO);
            this.groupBox7.Controls.Add(this.btnShipFrom);
            this.groupBox7.Controls.Add(this.labelOH_ShipVia);
            this.groupBox7.Controls.Add(this.textBoxOH_ShipVia);
            this.groupBox7.Location = new System.Drawing.Point(64, 8);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(720, 64);
            this.groupBox7.TabIndex = 77;
            this.groupBox7.TabStop = false;
            // 
            // btnShipFrom
            // 
            this.btnShipFrom.Location = new System.Drawing.Point(584, 24);
            this.btnShipFrom.Name = "btnShipFrom";
            this.btnShipFrom.TabIndex = 96;
            this.btnShipFrom.Text = "Ship From";
            this.btnShipFrom.Click += new System.EventHandler(this.btnShipFrom_Click);
            // 
            // labelOH_ShipVia
            // 
            this.labelOH_ShipVia.Location = new System.Drawing.Point(360, 16);
            this.labelOH_ShipVia.Name = "labelOH_ShipVia";
            this.labelOH_ShipVia.Size = new System.Drawing.Size(56, 20);
            this.labelOH_ShipVia.TabIndex = 105;
            this.labelOH_ShipVia.Text = "Ship Via";
            this.labelOH_ShipVia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_ShipVia
            // 
            this.textBoxOH_ShipVia.Location = new System.Drawing.Point(416, 16);
            this.textBoxOH_ShipVia.MaxLength = 40;
            this.textBoxOH_ShipVia.Name = "textBoxOH_ShipVia";
            this.textBoxOH_ShipVia.Size = new System.Drawing.Size(112, 20);
            this.textBoxOH_ShipVia.TabIndex = 106;
            this.textBoxOH_ShipVia.Text = "";
            // 
            // tabPageDiscounts
            // 
            this.tabPageDiscounts.Controls.Add(this.groupBox2);
            this.tabPageDiscounts.Location = new System.Drawing.Point(4, 22);
            this.tabPageDiscounts.Name = "tabPageDiscounts";
            this.tabPageDiscounts.Size = new System.Drawing.Size(840, 382);
            this.tabPageDiscounts.TabIndex = 12;
            this.tabPageDiscounts.Text = "Discounts";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.groupBox19);
            this.groupBox2.Controls.Add(this.dGridDiscounts);
            this.groupBox2.Controls.Add(this.buttonAddDiscGroup);
            this.groupBox2.Controls.Add(this.buttonAddDiscount);
            this.groupBox2.Controls.Add(this.buttonRemoveItem);
            this.groupBox2.Controls.Add(this.buttonEditItem);
            this.groupBox2.Controls.Add(this.buttonAddItem);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(832, 360);
            this.groupBox2.TabIndex = 138;
            this.groupBox2.TabStop = false;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.numericTextBox23);
            this.groupBox19.Controls.Add(this.label75);
            this.groupBox19.Controls.Add(this.numericTextBox24);
            this.groupBox19.Controls.Add(this.lIHDiscountTot);
            this.groupBox19.Controls.Add(this.ntbIH_DiscountTot);
            this.groupBox19.Controls.Add(this.label79);
            this.groupBox19.Location = new System.Drawing.Point(56, 8);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(720, 100);
            this.groupBox19.TabIndex = 139;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Discounts Header";
            // 
            // numericTextBox23
            // 
            this.numericTextBox23.Location = new System.Drawing.Point(168, 44);
            this.numericTextBox23.Maximum = new System.Decimal(new int[] {
                                                                             -727379969,
                                                                             232,
                                                                             0,
                                                                             0});
            this.numericTextBox23.MaxPrecision = 2;
            this.numericTextBox23.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox23.Name = "numericTextBox23";
            this.numericTextBox23.Size = new System.Drawing.Size(92, 20);
            this.numericTextBox23.TabIndex = 37;
            this.numericTextBox23.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label75
            // 
            this.label75.Location = new System.Drawing.Point(40, 48);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(120, 16);
            this.label75.TabIndex = 36;
            this.label75.Text = "Invoice Amt w/o Taxes";
            // 
            // numericTextBox24
            // 
            this.numericTextBox24.Location = new System.Drawing.Point(168, 64);
            this.numericTextBox24.Maximum = new System.Decimal(new int[] {
                                                                             -727379969,
                                                                             232,
                                                                             0,
                                                                             0});
            this.numericTextBox24.MaxPrecision = 2;
            this.numericTextBox24.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox24.Name = "numericTextBox24";
            this.numericTextBox24.Size = new System.Drawing.Size(92, 20);
            this.numericTextBox24.TabIndex = 41;
            this.numericTextBox24.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // lIHDiscountTot
            // 
            this.lIHDiscountTot.Location = new System.Drawing.Point(40, 28);
            this.lIHDiscountTot.Name = "lIHDiscountTot";
            this.lIHDiscountTot.Size = new System.Drawing.Size(96, 16);
            this.lIHDiscountTot.TabIndex = 33;
            this.lIHDiscountTot.Text = "Invoice Discounts";
            // 
            // ntbIH_DiscountTot
            // 
            this.ntbIH_DiscountTot.Location = new System.Drawing.Point(168, 24);
            this.ntbIH_DiscountTot.Maximum = new System.Decimal(new int[] {
                                                                              -727379969,
                                                                              232,
                                                                              0,
                                                                              0});
            this.ntbIH_DiscountTot.MaxPrecision = 2;
            this.ntbIH_DiscountTot.Minimum = new System.Decimal(new int[] {
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0});
            this.ntbIH_DiscountTot.Name = "ntbIH_DiscountTot";
            this.ntbIH_DiscountTot.Size = new System.Drawing.Size(92, 20);
            this.ntbIH_DiscountTot.TabIndex = 34;
            this.ntbIH_DiscountTot.Value = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            // 
            // label79
            // 
            this.label79.Location = new System.Drawing.Point(40, 68);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(136, 16);
            this.label79.TabIndex = 40;
            this.label79.Text = "Overall Discount Savings";
            // 
            // dGridDiscounts
            // 
            this.dGridDiscounts.DataMember = "";
            this.dGridDiscounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dGridDiscounts.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridDiscounts.Location = new System.Drawing.Point(56, 112);
            this.dGridDiscounts.Name = "dGridDiscounts";
            this.dGridDiscounts.Size = new System.Drawing.Size(720, 200);
            this.dGridDiscounts.TabIndex = 138;
            // 
            // buttonAddDiscGroup
            // 
            this.buttonAddDiscGroup.Location = new System.Drawing.Point(136, 320);
            this.buttonAddDiscGroup.Name = "buttonAddDiscGroup";
            this.buttonAddDiscGroup.Size = new System.Drawing.Size(96, 23);
            this.buttonAddDiscGroup.TabIndex = 137;
            this.buttonAddDiscGroup.Text = "Add Disc. Group";
            this.buttonAddDiscGroup.Click += new System.EventHandler(this.buttonAddDiscGroup_Click_2);
            // 
            // buttonAddDiscount
            // 
            this.buttonAddDiscount.Location = new System.Drawing.Point(48, 320);
            this.buttonAddDiscount.Name = "buttonAddDiscount";
            this.buttonAddDiscount.Size = new System.Drawing.Size(80, 23);
            this.buttonAddDiscount.TabIndex = 136;
            this.buttonAddDiscount.Text = "Add Discount";
            this.buttonAddDiscount.Click += new System.EventHandler(this.buttonAddDiscount_Click_1);
            // 
            // buttonRemoveItem
            // 
            this.buttonRemoveItem.Location = new System.Drawing.Point(680, 320);
            this.buttonRemoveItem.Name = "buttonRemoveItem";
            this.buttonRemoveItem.TabIndex = 130;
            this.buttonRemoveItem.Text = "Remove";
            // 
            // buttonEditItem
            // 
            this.buttonEditItem.Location = new System.Drawing.Point(592, 320);
            this.buttonEditItem.Name = "buttonEditItem";
            this.buttonEditItem.TabIndex = 125;
            this.buttonEditItem.Text = "Edit";
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Location = new System.Drawing.Point(504, 320);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.TabIndex = 120;
            this.buttonAddItem.Text = "Add ";
            // 
            // tabPageContact
            // 
            this.tabPageContact.Controls.Add(this.groupBox13);
            this.tabPageContact.Location = new System.Drawing.Point(4, 22);
            this.tabPageContact.Name = "tabPageContact";
            this.tabPageContact.Size = new System.Drawing.Size(840, 382);
            this.tabPageContact.TabIndex = 5;
            this.tabPageContact.Text = "Contact";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.groupBox23);
            this.groupBox13.Controls.Add(this.groupBox25);
            this.groupBox13.Controls.Add(this.groupBox24);
            this.groupBox13.Controls.Add(this.groupBox22);
            this.groupBox13.Controls.Add(this.groupBox21);
            this.groupBox13.Controls.Add(this.groupBox20);
            this.groupBox13.Controls.Add(this.groupBox26);
            this.groupBox13.Controls.Add(this.dgridContact);
            this.groupBox13.Controls.Add(this.btnEditPart);
            this.groupBox13.Controls.Add(this.btnAddPart);
            this.groupBox13.Controls.Add(this.btnDeletePart);
            this.groupBox13.Location = new System.Drawing.Point(8, 8);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(824, 368);
            this.groupBox13.TabIndex = 100;
            this.groupBox13.TabStop = false;
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.checkBox14);
            this.groupBox23.Controls.Add(this.checkBox15);
            this.groupBox23.Controls.Add(this.checkBox17);
            this.groupBox23.Controls.Add(this.checkBox16);
            this.groupBox23.Location = new System.Drawing.Point(352, 8);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(152, 56);
            this.groupBox23.TabIndex = 119;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Invoice";
            // 
            // checkBox14
            // 
            this.checkBox14.Checked = true;
            this.checkBox14.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox14.Location = new System.Drawing.Point(8, 16);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(64, 16);
            this.checkBox14.TabIndex = 69;
            this.checkBox14.Text = "Emailed";
            // 
            // checkBox15
            // 
            this.checkBox15.Checked = true;
            this.checkBox15.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox15.Location = new System.Drawing.Point(8, 32);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(64, 16);
            this.checkBox15.TabIndex = 71;
            this.checkBox15.Text = "Faxed";
            // 
            // checkBox17
            // 
            this.checkBox17.Checked = true;
            this.checkBox17.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox17.Location = new System.Drawing.Point(80, 32);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(56, 16);
            this.checkBox17.TabIndex = 109;
            this.checkBox17.Text = "Send";
            // 
            // checkBox16
            // 
            this.checkBox16.Checked = true;
            this.checkBox16.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox16.Location = new System.Drawing.Point(80, 16);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(64, 16);
            this.checkBox16.TabIndex = 70;
            this.checkBox16.Text = "Printed";
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.checkBox22);
            this.groupBox25.Controls.Add(this.checkBox23);
            this.groupBox25.Controls.Add(this.checkBox24);
            this.groupBox25.Controls.Add(this.checkBox25);
            this.groupBox25.Location = new System.Drawing.Point(352, 64);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(152, 56);
            this.groupBox25.TabIndex = 121;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Other Documents";
            // 
            // checkBox22
            // 
            this.checkBox22.Checked = true;
            this.checkBox22.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox22.Location = new System.Drawing.Point(8, 16);
            this.checkBox22.Name = "checkBox22";
            this.checkBox22.Size = new System.Drawing.Size(64, 16);
            this.checkBox22.TabIndex = 69;
            this.checkBox22.Text = "Emailed";
            // 
            // checkBox23
            // 
            this.checkBox23.Checked = true;
            this.checkBox23.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox23.Location = new System.Drawing.Point(8, 32);
            this.checkBox23.Name = "checkBox23";
            this.checkBox23.Size = new System.Drawing.Size(64, 16);
            this.checkBox23.TabIndex = 71;
            this.checkBox23.Text = "Faxed";
            // 
            // checkBox24
            // 
            this.checkBox24.Checked = true;
            this.checkBox24.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox24.Location = new System.Drawing.Point(80, 16);
            this.checkBox24.Name = "checkBox24";
            this.checkBox24.Size = new System.Drawing.Size(64, 16);
            this.checkBox24.TabIndex = 70;
            this.checkBox24.Text = "Printed";
            // 
            // checkBox25
            // 
            this.checkBox25.Checked = true;
            this.checkBox25.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox25.Location = new System.Drawing.Point(80, 32);
            this.checkBox25.Name = "checkBox25";
            this.checkBox25.Size = new System.Drawing.Size(64, 16);
            this.checkBox25.TabIndex = 109;
            this.checkBox25.Text = "Send";
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.checkBox18);
            this.groupBox24.Controls.Add(this.checkBox19);
            this.groupBox24.Controls.Add(this.checkBox20);
            this.groupBox24.Controls.Add(this.checkBox21);
            this.groupBox24.Location = new System.Drawing.Point(504, 8);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(152, 56);
            this.groupBox24.TabIndex = 120;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Custom\'s Invoice";
            // 
            // checkBox18
            // 
            this.checkBox18.Checked = true;
            this.checkBox18.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox18.Location = new System.Drawing.Point(8, 16);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(56, 16);
            this.checkBox18.TabIndex = 69;
            this.checkBox18.Text = "Emailed";
            // 
            // checkBox19
            // 
            this.checkBox19.Checked = true;
            this.checkBox19.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox19.Location = new System.Drawing.Point(8, 32);
            this.checkBox19.Name = "checkBox19";
            this.checkBox19.Size = new System.Drawing.Size(56, 16);
            this.checkBox19.TabIndex = 71;
            this.checkBox19.Text = "Faxed";
            // 
            // checkBox20
            // 
            this.checkBox20.Checked = true;
            this.checkBox20.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox20.Location = new System.Drawing.Point(80, 16);
            this.checkBox20.Name = "checkBox20";
            this.checkBox20.Size = new System.Drawing.Size(64, 16);
            this.checkBox20.TabIndex = 70;
            this.checkBox20.Text = "Printed";
            // 
            // checkBox21
            // 
            this.checkBox21.Checked = true;
            this.checkBox21.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox21.Location = new System.Drawing.Point(80, 32);
            this.checkBox21.Name = "checkBox21";
            this.checkBox21.Size = new System.Drawing.Size(56, 16);
            this.checkBox21.TabIndex = 109;
            this.checkBox21.Text = "Send";
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.checkBox10);
            this.groupBox22.Controls.Add(this.checkBox11);
            this.groupBox22.Controls.Add(this.checkBox12);
            this.groupBox22.Controls.Add(this.checkBox13);
            this.groupBox22.Location = new System.Drawing.Point(200, 64);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(152, 56);
            this.groupBox22.TabIndex = 118;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Bol";
            // 
            // checkBox10
            // 
            this.checkBox10.Checked = true;
            this.checkBox10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox10.Location = new System.Drawing.Point(8, 16);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(56, 16);
            this.checkBox10.TabIndex = 69;
            this.checkBox10.Text = "Emailed";
            // 
            // checkBox11
            // 
            this.checkBox11.Checked = true;
            this.checkBox11.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox11.Location = new System.Drawing.Point(8, 32);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(56, 16);
            this.checkBox11.TabIndex = 71;
            this.checkBox11.Text = "Faxed";
            // 
            // checkBox12
            // 
            this.checkBox12.Checked = true;
            this.checkBox12.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox12.Location = new System.Drawing.Point(72, 16);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(64, 16);
            this.checkBox12.TabIndex = 70;
            this.checkBox12.Text = "Printed";
            // 
            // checkBox13
            // 
            this.checkBox13.Checked = true;
            this.checkBox13.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox13.Location = new System.Drawing.Point(72, 32);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(64, 16);
            this.checkBox13.TabIndex = 109;
            this.checkBox13.Text = "Send";
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.checkBox6);
            this.groupBox21.Controls.Add(this.checkBox7);
            this.groupBox21.Controls.Add(this.checkBox8);
            this.groupBox21.Controls.Add(this.checkBox9);
            this.groupBox21.Location = new System.Drawing.Point(40, 64);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(152, 56);
            this.groupBox21.TabIndex = 117;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Pack Slip";
            // 
            // checkBox6
            // 
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Location = new System.Drawing.Point(16, 16);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(64, 16);
            this.checkBox6.TabIndex = 69;
            this.checkBox6.Text = "Emailed";
            // 
            // checkBox7
            // 
            this.checkBox7.Checked = true;
            this.checkBox7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox7.Location = new System.Drawing.Point(16, 32);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(64, 16);
            this.checkBox7.TabIndex = 71;
            this.checkBox7.Text = "Faxed";
            // 
            // checkBox8
            // 
            this.checkBox8.Checked = true;
            this.checkBox8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox8.Location = new System.Drawing.Point(88, 16);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(56, 16);
            this.checkBox8.TabIndex = 70;
            this.checkBox8.Text = "Printed";
            // 
            // checkBox9
            // 
            this.checkBox9.Checked = true;
            this.checkBox9.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox9.Location = new System.Drawing.Point(88, 32);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(56, 16);
            this.checkBox9.TabIndex = 109;
            this.checkBox9.Text = "Send";
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.checkBox2);
            this.groupBox20.Controls.Add(this.checkBox3);
            this.groupBox20.Controls.Add(this.checkBox4);
            this.groupBox20.Controls.Add(this.checkBox5);
            this.groupBox20.Location = new System.Drawing.Point(200, 8);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(152, 56);
            this.groupBox20.TabIndex = 116;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Order Acknowledgement";
            // 
            // checkBox2
            // 
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(8, 16);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(64, 16);
            this.checkBox2.TabIndex = 69;
            this.checkBox2.Text = "Emailed";
            // 
            // checkBox3
            // 
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(8, 32);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(64, 16);
            this.checkBox3.TabIndex = 71;
            this.checkBox3.Text = "Faxed";
            // 
            // checkBox4
            // 
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(80, 16);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(64, 16);
            this.checkBox4.TabIndex = 70;
            this.checkBox4.Text = "Printed";
            // 
            // checkBox5
            // 
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(80, 32);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(64, 16);
            this.checkBox5.TabIndex = 109;
            this.checkBox5.Text = "Send";
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.cBoxIH_Emailed);
            this.groupBox26.Controls.Add(this.cBoxIH_Faxed);
            this.groupBox26.Controls.Add(this.cBoxIH_Printed);
            this.groupBox26.Controls.Add(this.checkBox26);
            this.groupBox26.Location = new System.Drawing.Point(40, 8);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(152, 56);
            this.groupBox26.TabIndex = 115;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "Quote";
            // 
            // cBoxIH_Emailed
            // 
            this.cBoxIH_Emailed.Checked = true;
            this.cBoxIH_Emailed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxIH_Emailed.Location = new System.Drawing.Point(16, 16);
            this.cBoxIH_Emailed.Name = "cBoxIH_Emailed";
            this.cBoxIH_Emailed.Size = new System.Drawing.Size(64, 16);
            this.cBoxIH_Emailed.TabIndex = 69;
            this.cBoxIH_Emailed.Text = "Emailed";
            // 
            // cBoxIH_Faxed
            // 
            this.cBoxIH_Faxed.Checked = true;
            this.cBoxIH_Faxed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxIH_Faxed.Location = new System.Drawing.Point(88, 16);
            this.cBoxIH_Faxed.Name = "cBoxIH_Faxed";
            this.cBoxIH_Faxed.Size = new System.Drawing.Size(56, 16);
            this.cBoxIH_Faxed.TabIndex = 71;
            this.cBoxIH_Faxed.Text = "Faxed";
            // 
            // cBoxIH_Printed
            // 
            this.cBoxIH_Printed.Checked = true;
            this.cBoxIH_Printed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxIH_Printed.Location = new System.Drawing.Point(16, 32);
            this.cBoxIH_Printed.Name = "cBoxIH_Printed";
            this.cBoxIH_Printed.Size = new System.Drawing.Size(64, 16);
            this.cBoxIH_Printed.TabIndex = 70;
            this.cBoxIH_Printed.Text = "Printed";
            // 
            // checkBox26
            // 
            this.checkBox26.Checked = true;
            this.checkBox26.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox26.Location = new System.Drawing.Point(88, 32);
            this.checkBox26.Name = "checkBox26";
            this.checkBox26.Size = new System.Drawing.Size(56, 16);
            this.checkBox26.TabIndex = 109;
            this.checkBox26.Text = "Send";
            // 
            // dgridContact
            // 
            this.dgridContact.DataMember = "";
            this.dgridContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dgridContact.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgridContact.Location = new System.Drawing.Point(32, 128);
            this.dgridContact.Name = "dgridContact";
            this.dgridContact.Size = new System.Drawing.Size(768, 192);
            this.dgridContact.TabIndex = 92;
            // 
            // btnEditPart
            // 
            this.btnEditPart.Location = new System.Drawing.Point(624, 336);
            this.btnEditPart.Name = "btnEditPart";
            this.btnEditPart.TabIndex = 98;
            this.btnEditPart.Text = "Edit";
            // 
            // btnAddPart
            // 
            this.btnAddPart.Location = new System.Drawing.Point(536, 336);
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.TabIndex = 97;
            this.btnAddPart.Text = "Add";
            // 
            // btnDeletePart
            // 
            this.btnDeletePart.Location = new System.Drawing.Point(704, 336);
            this.btnDeletePart.Name = "btnDeletePart";
            this.btnDeletePart.TabIndex = 99;
            this.btnDeletePart.Text = "Delete";
            // 
            // tabPageDoc
            // 
            this.tabPageDoc.Location = new System.Drawing.Point(4, 22);
            this.tabPageDoc.Name = "tabPageDoc";
            this.tabPageDoc.Size = new System.Drawing.Size(840, 382);
            this.tabPageDoc.TabIndex = 4;
            this.tabPageDoc.Text = "Documents";
            // 
            // tabPageItems
            // 
            this.tabPageItems.Controls.Add(this.groupBox18);
            this.tabPageItems.Controls.Add(this.groupBox11);
            this.tabPageItems.Location = new System.Drawing.Point(4, 22);
            this.tabPageItems.Name = "tabPageItems";
            this.tabPageItems.Size = new System.Drawing.Size(840, 382);
            this.tabPageItems.TabIndex = 11;
            this.tabPageItems.Text = "Items";
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.textBox53);
            this.groupBox18.Controls.Add(this.label76);
            this.groupBox18.Controls.Add(this.textBox54);
            this.groupBox18.Controls.Add(this.label77);
            this.groupBox18.Controls.Add(this.textBox55);
            this.groupBox18.Controls.Add(this.label78);
            this.groupBox18.Controls.Add(this.textBox48);
            this.groupBox18.Controls.Add(this.label71);
            this.groupBox18.Controls.Add(this.textBox49);
            this.groupBox18.Controls.Add(this.label72);
            this.groupBox18.Controls.Add(this.textBox50);
            this.groupBox18.Controls.Add(this.label73);
            this.groupBox18.Controls.Add(this.textBox51);
            this.groupBox18.Controls.Add(this.label74);
            this.groupBox18.Controls.Add(this.textBox47);
            this.groupBox18.Controls.Add(this.label70);
            this.groupBox18.Controls.Add(this.textBox46);
            this.groupBox18.Controls.Add(this.label69);
            this.groupBox18.Controls.Add(this.textBox45);
            this.groupBox18.Controls.Add(this.label68);
            this.groupBox18.Controls.Add(this.textBox44);
            this.groupBox18.Controls.Add(this.label67);
            this.groupBox18.Location = new System.Drawing.Point(8, 240);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(824, 120);
            this.groupBox18.TabIndex = 46;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Summarize";
            // 
            // textBox53
            // 
            this.textBox53.Location = new System.Drawing.Point(608, 62);
            this.textBox53.Name = "textBox53";
            this.textBox53.Size = new System.Drawing.Size(80, 20);
            this.textBox53.TabIndex = 99;
            this.textBox53.Text = "0";
            // 
            // label76
            // 
            this.label76.Location = new System.Drawing.Point(528, 62);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(64, 20);
            this.label76.TabIndex = 98;
            this.label76.Text = "Taxes";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox54
            // 
            this.textBox54.Location = new System.Drawing.Point(608, 38);
            this.textBox54.Name = "textBox54";
            this.textBox54.Size = new System.Drawing.Size(80, 20);
            this.textBox54.TabIndex = 97;
            this.textBox54.Text = "0";
            // 
            // label77
            // 
            this.label77.Location = new System.Drawing.Point(528, 38);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(80, 20);
            this.label77.TabIndex = 96;
            this.label77.Text = "Freight";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox55
            // 
            this.textBox55.Location = new System.Drawing.Point(608, 14);
            this.textBox55.Name = "textBox55";
            this.textBox55.Size = new System.Drawing.Size(80, 20);
            this.textBox55.TabIndex = 95;
            this.textBox55.Text = "0";
            // 
            // label78
            // 
            this.label78.Location = new System.Drawing.Point(528, 14);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(80, 20);
            this.label78.TabIndex = 94;
            this.label78.Text = "Gross Margin";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox48
            // 
            this.textBox48.Location = new System.Drawing.Point(392, 86);
            this.textBox48.Name = "textBox48";
            this.textBox48.Size = new System.Drawing.Size(80, 20);
            this.textBox48.TabIndex = 93;
            this.textBox48.Text = "0";
            // 
            // label71
            // 
            this.label71.Location = new System.Drawing.Point(280, 86);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(104, 20);
            this.label71.TabIndex = 92;
            this.label71.Text = "Total ";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox49
            // 
            this.textBox49.Location = new System.Drawing.Point(392, 62);
            this.textBox49.Name = "textBox49";
            this.textBox49.Size = new System.Drawing.Size(80, 20);
            this.textBox49.TabIndex = 91;
            this.textBox49.Text = "0";
            // 
            // label72
            // 
            this.label72.Location = new System.Drawing.Point(280, 62);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(112, 20);
            this.label72.TabIndex = 90;
            this.label72.Text = "Total Order Charges";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox50
            // 
            this.textBox50.Location = new System.Drawing.Point(392, 38);
            this.textBox50.Name = "textBox50";
            this.textBox50.Size = new System.Drawing.Size(80, 20);
            this.textBox50.TabIndex = 89;
            this.textBox50.Text = "0";
            // 
            // label73
            // 
            this.label73.Location = new System.Drawing.Point(280, 38);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(80, 20);
            this.label73.TabIndex = 88;
            this.label73.Text = "Total Order";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox51
            // 
            this.textBox51.Location = new System.Drawing.Point(392, 14);
            this.textBox51.Name = "textBox51";
            this.textBox51.Size = new System.Drawing.Size(80, 20);
            this.textBox51.TabIndex = 87;
            this.textBox51.Text = "0";
            // 
            // label74
            // 
            this.label74.Location = new System.Drawing.Point(280, 14);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(80, 20);
            this.label74.TabIndex = 86;
            this.label74.Text = "Gross Margin";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox47
            // 
            this.textBox47.Location = new System.Drawing.Point(144, 88);
            this.textBox47.Name = "textBox47";
            this.textBox47.Size = new System.Drawing.Size(80, 20);
            this.textBox47.TabIndex = 85;
            this.textBox47.Text = "0";
            // 
            // label70
            // 
            this.label70.Location = new System.Drawing.Point(40, 88);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(104, 20);
            this.label70.TabIndex = 84;
            this.label70.Text = "Total Lines Avaible";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox46
            // 
            this.textBox46.Location = new System.Drawing.Point(144, 64);
            this.textBox46.Name = "textBox46";
            this.textBox46.Size = new System.Drawing.Size(80, 20);
            this.textBox46.TabIndex = 83;
            this.textBox46.Text = "0";
            // 
            // label69
            // 
            this.label69.Location = new System.Drawing.Point(40, 64);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(96, 20);
            this.label69.TabIndex = 82;
            this.label69.Text = "Total Lines Req.";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox45
            // 
            this.textBox45.Location = new System.Drawing.Point(144, 40);
            this.textBox45.Name = "textBox45";
            this.textBox45.Size = new System.Drawing.Size(40, 20);
            this.textBox45.TabIndex = 81;
            this.textBox45.Text = "0";
            // 
            // label68
            // 
            this.label68.Location = new System.Drawing.Point(40, 40);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(80, 20);
            this.label68.TabIndex = 80;
            this.label68.Text = "% Commission";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox44
            // 
            this.textBox44.Location = new System.Drawing.Point(144, 16);
            this.textBox44.Name = "textBox44";
            this.textBox44.Size = new System.Drawing.Size(80, 20);
            this.textBox44.TabIndex = 79;
            this.textBox44.Text = "0";
            // 
            // label67
            // 
            this.label67.Location = new System.Drawing.Point(40, 16);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(40, 20);
            this.label67.TabIndex = 78;
            this.label67.Text = "Total";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.dGridItems);
            this.groupBox11.Controls.Add(this.btnDeleteItem);
            this.groupBox11.Controls.Add(this.btnAddItem);
            this.groupBox11.Controls.Add(this.btnEditItem);
            this.groupBox11.Location = new System.Drawing.Point(8, 8);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(824, 232);
            this.groupBox11.TabIndex = 45;
            this.groupBox11.TabStop = false;
            // 
            // dGridItems
            // 
            this.dGridItems.DataMember = "";
            this.dGridItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dGridItems.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridItems.Location = new System.Drawing.Point(16, 16);
            this.dGridItems.Name = "dGridItems";
            this.dGridItems.Size = new System.Drawing.Size(800, 176);
            this.dGridItems.TabIndex = 44;
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Location = new System.Drawing.Point(728, 200);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.TabIndex = 105;
            this.btnDeleteItem.Text = "Delete";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(648, 200);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.TabIndex = 103;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(568, 200);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.TabIndex = 104;
            this.btnEditItem.Text = "Edit";
            this.btnEditItem.Click += new System.EventHandler(this.button7_Click);
            // 
            // tabPageCom
            // 
            this.tabPageCom.Controls.Add(this.groupBox10);
            this.tabPageCom.Location = new System.Drawing.Point(4, 22);
            this.tabPageCom.Name = "tabPageCom";
            this.tabPageCom.Size = new System.Drawing.Size(840, 382);
            this.tabPageCom.TabIndex = 2;
            this.tabPageCom.Text = "Components";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.dGridComponents);
            this.groupBox10.Controls.Add(this.button5);
            this.groupBox10.Controls.Add(this.button4);
            this.groupBox10.Controls.Add(this.button1);
            this.groupBox10.Location = new System.Drawing.Point(8, 8);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(830, 352);
            this.groupBox10.TabIndex = 31;
            this.groupBox10.TabStop = false;
            // 
            // dGridComponents
            // 
            this.dGridComponents.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dGridComponents.DataMember = "";
            this.dGridComponents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dGridComponents.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridComponents.Location = new System.Drawing.Point(8, 16);
            this.dGridComponents.Name = "dGridComponents";
            this.dGridComponents.Size = new System.Drawing.Size(800, 288);
            this.dGridComponents.TabIndex = 30;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(552, 320);
            this.button5.Name = "button5";
            this.button5.TabIndex = 100;
            this.button5.Text = "Add";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(640, 320);
            this.button4.Name = "button4";
            this.button4.TabIndex = 101;
            this.button4.Text = "Edit";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(728, 320);
            this.button1.Name = "button1";
            this.button1.TabIndex = 102;
            this.button1.Text = "Delete";
            // 
            // tabPageCharges
            // 
            this.tabPageCharges.Location = new System.Drawing.Point(4, 22);
            this.tabPageCharges.Name = "tabPageCharges";
            this.tabPageCharges.Size = new System.Drawing.Size(840, 382);
            this.tabPageCharges.TabIndex = 7;
            this.tabPageCharges.Text = "Charges";
            // 
            // tabPageAcc
            // 
            this.tabPageAcc.Controls.Add(this.groupBox15);
            this.tabPageAcc.Controls.Add(this.groupBox16);
            this.tabPageAcc.Controls.Add(this.gBoxTax);
            this.tabPageAcc.Controls.Add(this.gBoxCost);
            this.tabPageAcc.Controls.Add(this.groupBox1);
            this.tabPageAcc.Location = new System.Drawing.Point(4, 22);
            this.tabPageAcc.Name = "tabPageAcc";
            this.tabPageAcc.Size = new System.Drawing.Size(840, 382);
            this.tabPageAcc.TabIndex = 8;
            this.tabPageAcc.Text = "Accounting";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.numericTextBox20);
            this.groupBox15.Controls.Add(this.label63);
            this.groupBox15.Controls.Add(this.ntbID_RoyCharges);
            this.groupBox15.Controls.Add(this.ntbId_FreigthAmt);
            this.groupBox15.Controls.Add(this.lIDRoyCharges);
            this.groupBox15.Controls.Add(this.lIdFreightAmt);
            this.groupBox15.Controls.Add(this.numericTextBox21);
            this.groupBox15.Controls.Add(this.numericTextBox22);
            this.groupBox15.Controls.Add(this.label64);
            this.groupBox15.Controls.Add(this.label65);
            this.groupBox15.Location = new System.Drawing.Point(424, 232);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(176, 128);
            this.groupBox15.TabIndex = 90;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Sales";
            // 
            // numericTextBox20
            // 
            this.numericTextBox20.Location = new System.Drawing.Point(72, 104);
            this.numericTextBox20.Maximum = new System.Decimal(new int[] {
                                                                             1316134911,
                                                                             2328,
                                                                             0,
                                                                             0});
            this.numericTextBox20.MaxPrecision = 2;
            this.numericTextBox20.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox20.Name = "numericTextBox20";
            this.numericTextBox20.Size = new System.Drawing.Size(64, 20);
            this.numericTextBox20.TabIndex = 11;
            this.numericTextBox20.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label63
            // 
            this.label63.Location = new System.Drawing.Point(8, 104);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(52, 16);
            this.label63.TabIndex = 10;
            this.label63.Text = "Total";
            // 
            // ntbID_RoyCharges
            // 
            this.ntbID_RoyCharges.Location = new System.Drawing.Point(72, 76);
            this.ntbID_RoyCharges.Maximum = new System.Decimal(new int[] {
                                                                             1316134911,
                                                                             2328,
                                                                             0,
                                                                             0});
            this.ntbID_RoyCharges.MaxPrecision = 2;
            this.ntbID_RoyCharges.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.ntbID_RoyCharges.Name = "ntbID_RoyCharges";
            this.ntbID_RoyCharges.Size = new System.Drawing.Size(64, 20);
            this.ntbID_RoyCharges.TabIndex = 9;
            this.ntbID_RoyCharges.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // ntbId_FreigthAmt
            // 
            this.ntbId_FreigthAmt.Location = new System.Drawing.Point(72, 56);
            this.ntbId_FreigthAmt.Maximum = new System.Decimal(new int[] {
                                                                             -727379969,
                                                                             232,
                                                                             0,
                                                                             0});
            this.ntbId_FreigthAmt.MaxPrecision = 2;
            this.ntbId_FreigthAmt.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.ntbId_FreigthAmt.Name = "ntbId_FreigthAmt";
            this.ntbId_FreigthAmt.Size = new System.Drawing.Size(64, 20);
            this.ntbId_FreigthAmt.TabIndex = 8;
            this.ntbId_FreigthAmt.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // lIDRoyCharges
            // 
            this.lIDRoyCharges.Location = new System.Drawing.Point(8, 80);
            this.lIDRoyCharges.Name = "lIDRoyCharges";
            this.lIDRoyCharges.Size = new System.Drawing.Size(52, 16);
            this.lIDRoyCharges.TabIndex = 7;
            this.lIDRoyCharges.Text = "Royalties";
            // 
            // lIdFreightAmt
            // 
            this.lIdFreightAmt.Location = new System.Drawing.Point(8, 60);
            this.lIdFreightAmt.Name = "lIdFreightAmt";
            this.lIdFreightAmt.Size = new System.Drawing.Size(44, 16);
            this.lIdFreightAmt.TabIndex = 6;
            this.lIdFreightAmt.Text = "Freigth";
            // 
            // numericTextBox21
            // 
            this.numericTextBox21.Location = new System.Drawing.Point(72, 36);
            this.numericTextBox21.Maximum = new System.Decimal(new int[] {
                                                                             -727379969,
                                                                             232,
                                                                             0,
                                                                             0});
            this.numericTextBox21.MaxPrecision = 2;
            this.numericTextBox21.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox21.Name = "numericTextBox21";
            this.numericTextBox21.Size = new System.Drawing.Size(64, 20);
            this.numericTextBox21.TabIndex = 5;
            this.numericTextBox21.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // numericTextBox22
            // 
            this.numericTextBox22.Location = new System.Drawing.Point(72, 16);
            this.numericTextBox22.Maximum = new System.Decimal(new int[] {
                                                                             -727379969,
                                                                             232,
                                                                             0,
                                                                             0});
            this.numericTextBox22.MaxPrecision = 2;
            this.numericTextBox22.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox22.Name = "numericTextBox22";
            this.numericTextBox22.Size = new System.Drawing.Size(64, 20);
            this.numericTextBox22.TabIndex = 3;
            this.numericTextBox22.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label64
            // 
            this.label64.Location = new System.Drawing.Point(8, 40);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(72, 16);
            this.label64.TabIndex = 2;
            this.label64.Text = "Discounts";
            // 
            // label65
            // 
            this.label65.Location = new System.Drawing.Point(8, 20);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(72, 16);
            this.label65.TabIndex = 0;
            this.label65.Text = "Commisions";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.tBoxID_GLSalesAcc);
            this.groupBox16.Controls.Add(this.lIDGLSalesAcc);
            this.groupBox16.Controls.Add(this.lIDGLCosAcc);
            this.groupBox16.Controls.Add(this.tBoxID_GLCosAcc);
            this.groupBox16.Controls.Add(this.tBoxID_GLCosType);
            this.groupBox16.Controls.Add(this.lIDGLCosType);
            this.groupBox16.Location = new System.Drawing.Point(608, 136);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(152, 88);
            this.groupBox16.TabIndex = 89;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "General Leadger";
            // 
            // tBoxID_GLSalesAcc
            // 
            this.tBoxID_GLSalesAcc.Location = new System.Drawing.Point(64, 24);
            this.tBoxID_GLSalesAcc.MaxLength = 5;
            this.tBoxID_GLSalesAcc.Name = "tBoxID_GLSalesAcc";
            this.tBoxID_GLSalesAcc.Size = new System.Drawing.Size(64, 20);
            this.tBoxID_GLSalesAcc.TabIndex = 6;
            this.tBoxID_GLSalesAcc.Text = "";
            // 
            // lIDGLSalesAcc
            // 
            this.lIDGLSalesAcc.Location = new System.Drawing.Point(8, 24);
            this.lIDGLSalesAcc.Name = "lIDGLSalesAcc";
            this.lIDGLSalesAcc.Size = new System.Drawing.Size(72, 20);
            this.lIDGLSalesAcc.TabIndex = 1;
            this.lIDGLSalesAcc.Text = "Sales Acc.";
            // 
            // lIDGLCosAcc
            // 
            this.lIDGLCosAcc.Location = new System.Drawing.Point(8, 44);
            this.lIDGLCosAcc.Name = "lIDGLCosAcc";
            this.lIDGLCosAcc.Size = new System.Drawing.Size(56, 20);
            this.lIDGLCosAcc.TabIndex = 5;
            this.lIDGLCosAcc.Text = "Cos. Acc.";
            // 
            // tBoxID_GLCosAcc
            // 
            this.tBoxID_GLCosAcc.Location = new System.Drawing.Point(64, 44);
            this.tBoxID_GLCosAcc.MaxLength = 5;
            this.tBoxID_GLCosAcc.Name = "tBoxID_GLCosAcc";
            this.tBoxID_GLCosAcc.Size = new System.Drawing.Size(64, 20);
            this.tBoxID_GLCosAcc.TabIndex = 8;
            this.tBoxID_GLCosAcc.Text = "";
            // 
            // tBoxID_GLCosType
            // 
            this.tBoxID_GLCosType.Location = new System.Drawing.Point(64, 64);
            this.tBoxID_GLCosType.MaxLength = 5;
            this.tBoxID_GLCosType.Name = "tBoxID_GLCosType";
            this.tBoxID_GLCosType.Size = new System.Drawing.Size(64, 20);
            this.tBoxID_GLCosType.TabIndex = 7;
            this.tBoxID_GLCosType.Text = "";
            // 
            // lIDGLCosType
            // 
            this.lIDGLCosType.Location = new System.Drawing.Point(8, 64);
            this.lIDGLCosType.Name = "lIDGLCosType";
            this.lIDGLCosType.Size = new System.Drawing.Size(64, 20);
            this.lIDGLCosType.TabIndex = 4;
            this.lIDGLCosType.Text = "Cos Type";
            // 
            // gBoxTax
            // 
            this.gBoxTax.Controls.Add(this.ntbID_TaxAmtTot);
            this.gBoxTax.Controls.Add(this.lIDTaxAmtTot);
            this.gBoxTax.Controls.Add(this.ntbID_LineExtwTax);
            this.gBoxTax.Controls.Add(this.lIDLineExtwTax);
            this.gBoxTax.Controls.Add(this.ntbID_Tax2Amt);
            this.gBoxTax.Controls.Add(this.ntbID_Tax3Amt);
            this.gBoxTax.Controls.Add(this.ntbID_Tax1Amt);
            this.gBoxTax.Controls.Add(this.lIDTax2Amt);
            this.gBoxTax.Controls.Add(this.lIdTax3Amt);
            this.gBoxTax.Controls.Add(this.lIDTax1Amt);
            this.gBoxTax.Location = new System.Drawing.Point(608, 8);
            this.gBoxTax.Name = "gBoxTax";
            this.gBoxTax.Size = new System.Drawing.Size(152, 128);
            this.gBoxTax.TabIndex = 88;
            this.gBoxTax.TabStop = false;
            this.gBoxTax.Text = "Tax";
            // 
            // ntbID_TaxAmtTot
            // 
            this.ntbID_TaxAmtTot.Location = new System.Drawing.Point(56, 104);
            this.ntbID_TaxAmtTot.Maximum = new System.Decimal(new int[] {
                                                                            -727379969,
                                                                            232,
                                                                            0,
                                                                            0});
            this.ntbID_TaxAmtTot.MaxPrecision = 2;
            this.ntbID_TaxAmtTot.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.ntbID_TaxAmtTot.Name = "ntbID_TaxAmtTot";
            this.ntbID_TaxAmtTot.Size = new System.Drawing.Size(88, 20);
            this.ntbID_TaxAmtTot.TabIndex = 9;
            this.ntbID_TaxAmtTot.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // lIDTaxAmtTot
            // 
            this.lIDTaxAmtTot.Location = new System.Drawing.Point(8, 104);
            this.lIDTaxAmtTot.Name = "lIDTaxAmtTot";
            this.lIDTaxAmtTot.Size = new System.Drawing.Size(56, 16);
            this.lIDTaxAmtTot.TabIndex = 8;
            this.lIDTaxAmtTot.Text = "Total";
            // 
            // ntbID_LineExtwTax
            // 
            this.ntbID_LineExtwTax.Location = new System.Drawing.Point(56, 76);
            this.ntbID_LineExtwTax.Maximum = new System.Decimal(new int[] {
                                                                              -727379969,
                                                                              232,
                                                                              0,
                                                                              0});
            this.ntbID_LineExtwTax.MaxPrecision = 2;
            this.ntbID_LineExtwTax.Minimum = new System.Decimal(new int[] {
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0});
            this.ntbID_LineExtwTax.Name = "ntbID_LineExtwTax";
            this.ntbID_LineExtwTax.Size = new System.Drawing.Size(88, 20);
            this.ntbID_LineExtwTax.TabIndex = 7;
            this.ntbID_LineExtwTax.Value = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            // 
            // lIDLineExtwTax
            // 
            this.lIDLineExtwTax.Location = new System.Drawing.Point(8, 80);
            this.lIDLineExtwTax.Name = "lIDLineExtwTax";
            this.lIDLineExtwTax.Size = new System.Drawing.Size(56, 16);
            this.lIDLineExtwTax.TabIndex = 6;
            this.lIDLineExtwTax.Text = "Line Ext. ";
            // 
            // ntbID_Tax2Amt
            // 
            this.ntbID_Tax2Amt.Location = new System.Drawing.Point(56, 36);
            this.ntbID_Tax2Amt.Maximum = new System.Decimal(new int[] {
                                                                          -727379969,
                                                                          232,
                                                                          0,
                                                                          0});
            this.ntbID_Tax2Amt.MaxPrecision = 2;
            this.ntbID_Tax2Amt.Minimum = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            this.ntbID_Tax2Amt.Name = "ntbID_Tax2Amt";
            this.ntbID_Tax2Amt.Size = new System.Drawing.Size(88, 20);
            this.ntbID_Tax2Amt.TabIndex = 5;
            this.ntbID_Tax2Amt.Value = new System.Decimal(new int[] {
                                                                        0,
                                                                        0,
                                                                        0,
                                                                        0});
            // 
            // ntbID_Tax3Amt
            // 
            this.ntbID_Tax3Amt.Location = new System.Drawing.Point(56, 56);
            this.ntbID_Tax3Amt.Maximum = new System.Decimal(new int[] {
                                                                          -727379969,
                                                                          232,
                                                                          0,
                                                                          0});
            this.ntbID_Tax3Amt.MaxPrecision = 2;
            this.ntbID_Tax3Amt.Minimum = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            this.ntbID_Tax3Amt.Name = "ntbID_Tax3Amt";
            this.ntbID_Tax3Amt.Size = new System.Drawing.Size(88, 20);
            this.ntbID_Tax3Amt.TabIndex = 4;
            this.ntbID_Tax3Amt.Value = new System.Decimal(new int[] {
                                                                        0,
                                                                        0,
                                                                        0,
                                                                        0});
            // 
            // ntbID_Tax1Amt
            // 
            this.ntbID_Tax1Amt.Location = new System.Drawing.Point(56, 16);
            this.ntbID_Tax1Amt.Maximum = new System.Decimal(new int[] {
                                                                          -727379969,
                                                                          232,
                                                                          0,
                                                                          0});
            this.ntbID_Tax1Amt.MaxPrecision = 2;
            this.ntbID_Tax1Amt.Minimum = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            this.ntbID_Tax1Amt.Name = "ntbID_Tax1Amt";
            this.ntbID_Tax1Amt.Size = new System.Drawing.Size(88, 20);
            this.ntbID_Tax1Amt.TabIndex = 3;
            this.ntbID_Tax1Amt.Value = new System.Decimal(new int[] {
                                                                        0,
                                                                        0,
                                                                        0,
                                                                        0});
            // 
            // lIDTax2Amt
            // 
            this.lIDTax2Amt.Location = new System.Drawing.Point(8, 40);
            this.lIDTax2Amt.Name = "lIDTax2Amt";
            this.lIDTax2Amt.Size = new System.Drawing.Size(40, 16);
            this.lIDTax2Amt.TabIndex = 2;
            this.lIDTax2Amt.Text = "2 Amt.";
            // 
            // lIdTax3Amt
            // 
            this.lIdTax3Amt.Location = new System.Drawing.Point(8, 60);
            this.lIdTax3Amt.Name = "lIdTax3Amt";
            this.lIdTax3Amt.Size = new System.Drawing.Size(40, 16);
            this.lIdTax3Amt.TabIndex = 1;
            this.lIdTax3Amt.Text = "3 Amt.";
            // 
            // lIDTax1Amt
            // 
            this.lIDTax1Amt.Location = new System.Drawing.Point(8, 16);
            this.lIDTax1Amt.Name = "lIDTax1Amt";
            this.lIDTax1Amt.Size = new System.Drawing.Size(40, 16);
            this.lIDTax1Amt.TabIndex = 0;
            this.lIDTax1Amt.Text = "1 Amt.";
            // 
            // gBoxCost
            // 
            this.gBoxCost.Controls.Add(this.numericTextBox1);
            this.gBoxCost.Controls.Add(this.label37);
            this.gBoxCost.Controls.Add(this.label38);
            this.gBoxCost.Controls.Add(this.numericTextBox2);
            this.gBoxCost.Controls.Add(this.label39);
            this.gBoxCost.Controls.Add(this.numericTextBox3);
            this.gBoxCost.Controls.Add(this.label41);
            this.gBoxCost.Controls.Add(this.numericTextBox4);
            this.gBoxCost.Controls.Add(this.label42);
            this.gBoxCost.Controls.Add(this.numericTextBox5);
            this.gBoxCost.Controls.Add(this.label43);
            this.gBoxCost.Controls.Add(this.numericTextBox13);
            this.gBoxCost.Controls.Add(this.label55);
            this.gBoxCost.Controls.Add(this.numericTextBox12);
            this.gBoxCost.Controls.Add(this.label56);
            this.gBoxCost.Controls.Add(this.numericTextBox11);
            this.gBoxCost.Controls.Add(this.label57);
            this.gBoxCost.Controls.Add(this.numericTextBox10);
            this.gBoxCost.Controls.Add(this.label58);
            this.gBoxCost.Controls.Add(this.numericTextBox7);
            this.gBoxCost.Controls.Add(this.label59);
            this.gBoxCost.Controls.Add(this.numericTextBox6);
            this.gBoxCost.Controls.Add(this.label60);
            this.gBoxCost.Controls.Add(this.numericTextBox8);
            this.gBoxCost.Controls.Add(this.label61);
            this.gBoxCost.Controls.Add(this.numericTextBox19);
            this.gBoxCost.Controls.Add(this.label62);
            this.gBoxCost.Controls.Add(this.ntbOutsideCost);
            this.gBoxCost.Controls.Add(this.lIdOutsideCost);
            this.gBoxCost.Controls.Add(this.ntbID_MatCost);
            this.gBoxCost.Controls.Add(this.ntbID_OHCost);
            this.gBoxCost.Controls.Add(this.lIdOHCost);
            this.gBoxCost.Controls.Add(this.lIdMatCost);
            this.gBoxCost.Controls.Add(this.ntbId_UnitCost);
            this.gBoxCost.Controls.Add(this.ntbId_LabCost);
            this.gBoxCost.Controls.Add(this.ntbID_CostExt);
            this.gBoxCost.Controls.Add(this.lIdUnitCost);
            this.gBoxCost.Controls.Add(this.lIdLabCost);
            this.gBoxCost.Controls.Add(this.lIdCostExt);
            this.gBoxCost.Location = new System.Drawing.Point(56, 8);
            this.gBoxCost.Name = "gBoxCost";
            this.gBoxCost.Size = new System.Drawing.Size(360, 224);
            this.gBoxCost.TabIndex = 87;
            this.gBoxCost.TabStop = false;
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Location = new System.Drawing.Point(224, 196);
            this.numericTextBox1.Maximum = new System.Decimal(new int[] {
                                                                            -1530494977,
                                                                            232830,
                                                                            0,
                                                                            0});
            this.numericTextBox1.MaxPrecision = 5;
            this.numericTextBox1.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.Size = new System.Drawing.Size(128, 20);
            this.numericTextBox1.TabIndex = 39;
            this.numericTextBox1.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(184, 200);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(40, 16);
            this.label37.TabIndex = 38;
            this.label37.Text = "Total ";
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(8, 92);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(48, 16);
            this.label38.TabIndex = 37;
            this.label38.Text = "Lab ";
            // 
            // numericTextBox2
            // 
            this.numericTextBox2.Location = new System.Drawing.Point(264, 108);
            this.numericTextBox2.Maximum = new System.Decimal(new int[] {
                                                                            -1530494977,
                                                                            232830,
                                                                            0,
                                                                            0});
            this.numericTextBox2.MaxPrecision = 5;
            this.numericTextBox2.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox2.Name = "numericTextBox2";
            this.numericTextBox2.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox2.TabIndex = 36;
            this.numericTextBox2.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(184, 112);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(80, 16);
            this.label39.TabIndex = 35;
            this.label39.Text = "User Cost 2";
            // 
            // numericTextBox3
            // 
            this.numericTextBox3.Location = new System.Drawing.Point(264, 148);
            this.numericTextBox3.Maximum = new System.Decimal(new int[] {
                                                                            -1530494977,
                                                                            232830,
                                                                            0,
                                                                            0});
            this.numericTextBox3.MaxPrecision = 5;
            this.numericTextBox3.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox3.Name = "numericTextBox3";
            this.numericTextBox3.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox3.TabIndex = 34;
            this.numericTextBox3.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(184, 152);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(72, 16);
            this.label41.TabIndex = 33;
            this.label41.Text = "User Cost 4";
            // 
            // numericTextBox4
            // 
            this.numericTextBox4.Location = new System.Drawing.Point(264, 128);
            this.numericTextBox4.Maximum = new System.Decimal(new int[] {
                                                                            -1530494977,
                                                                            232830,
                                                                            0,
                                                                            0});
            this.numericTextBox4.MaxPrecision = 5;
            this.numericTextBox4.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox4.Name = "numericTextBox4";
            this.numericTextBox4.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox4.TabIndex = 32;
            this.numericTextBox4.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(184, 132);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(72, 16);
            this.label42.TabIndex = 31;
            this.label42.Text = "User Cost 3";
            // 
            // numericTextBox5
            // 
            this.numericTextBox5.Location = new System.Drawing.Point(264, 168);
            this.numericTextBox5.Maximum = new System.Decimal(new int[] {
                                                                            -1530494977,
                                                                            232830,
                                                                            0,
                                                                            0});
            this.numericTextBox5.MaxPrecision = 5;
            this.numericTextBox5.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox5.Name = "numericTextBox5";
            this.numericTextBox5.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox5.TabIndex = 30;
            this.numericTextBox5.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(184, 172);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(72, 16);
            this.label43.TabIndex = 29;
            this.label43.Text = "User Cost 5";
            // 
            // numericTextBox13
            // 
            this.numericTextBox13.Location = new System.Drawing.Point(264, 88);
            this.numericTextBox13.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox13.MaxPrecision = 5;
            this.numericTextBox13.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox13.Name = "numericTextBox13";
            this.numericTextBox13.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox13.TabIndex = 28;
            this.numericTextBox13.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(184, 92);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(88, 16);
            this.label55.TabIndex = 27;
            this.label55.Text = "User Cost 1";
            // 
            // numericTextBox12
            // 
            this.numericTextBox12.Location = new System.Drawing.Point(264, 68);
            this.numericTextBox12.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox12.MaxPrecision = 5;
            this.numericTextBox12.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox12.Name = "numericTextBox12";
            this.numericTextBox12.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox12.TabIndex = 26;
            this.numericTextBox12.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(184, 72);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(88, 16);
            this.label56.TabIndex = 25;
            this.label56.Text = "Curr. Exchange";
            // 
            // numericTextBox11
            // 
            this.numericTextBox11.Location = new System.Drawing.Point(264, 48);
            this.numericTextBox11.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox11.MaxPrecision = 5;
            this.numericTextBox11.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox11.Name = "numericTextBox11";
            this.numericTextBox11.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox11.TabIndex = 24;
            this.numericTextBox11.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label57
            // 
            this.label57.Location = new System.Drawing.Point(184, 52);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(88, 16);
            this.label57.TabIndex = 23;
            this.label57.Text = "Outside Proc";
            // 
            // numericTextBox10
            // 
            this.numericTextBox10.Location = new System.Drawing.Point(264, 28);
            this.numericTextBox10.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox10.MaxPrecision = 5;
            this.numericTextBox10.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox10.Name = "numericTextBox10";
            this.numericTextBox10.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox10.TabIndex = 22;
            this.numericTextBox10.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(184, 32);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(88, 16);
            this.label58.TabIndex = 21;
            this.label58.Text = "Warehouseing";
            // 
            // numericTextBox7
            // 
            this.numericTextBox7.Location = new System.Drawing.Point(264, 8);
            this.numericTextBox7.Maximum = new System.Decimal(new int[] {
                                                                            -1530494977,
                                                                            232830,
                                                                            0,
                                                                            0});
            this.numericTextBox7.MaxPrecision = 5;
            this.numericTextBox7.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox7.Name = "numericTextBox7";
            this.numericTextBox7.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox7.TabIndex = 20;
            this.numericTextBox7.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label59
            // 
            this.label59.Location = new System.Drawing.Point(184, 12);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(88, 16);
            this.label59.TabIndex = 19;
            this.label59.Text = "InDirect Labour";
            // 
            // numericTextBox6
            // 
            this.numericTextBox6.Location = new System.Drawing.Point(88, 168);
            this.numericTextBox6.Maximum = new System.Decimal(new int[] {
                                                                            -1530494977,
                                                                            232830,
                                                                            0,
                                                                            0});
            this.numericTextBox6.MaxPrecision = 5;
            this.numericTextBox6.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox6.Name = "numericTextBox6";
            this.numericTextBox6.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox6.TabIndex = 18;
            this.numericTextBox6.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label60
            // 
            this.label60.Location = new System.Drawing.Point(8, 172);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(88, 16);
            this.label60.TabIndex = 17;
            this.label60.Text = "InDirect Burden";
            // 
            // numericTextBox8
            // 
            this.numericTextBox8.Location = new System.Drawing.Point(88, 148);
            this.numericTextBox8.Maximum = new System.Decimal(new int[] {
                                                                            -1530494977,
                                                                            232830,
                                                                            0,
                                                                            0});
            this.numericTextBox8.MaxPrecision = 5;
            this.numericTextBox8.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox8.Name = "numericTextBox8";
            this.numericTextBox8.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox8.TabIndex = 16;
            this.numericTextBox8.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label61
            // 
            this.label61.Location = new System.Drawing.Point(8, 152);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(80, 16);
            this.label61.TabIndex = 15;
            this.label61.Text = "Direct Labour";
            // 
            // numericTextBox19
            // 
            this.numericTextBox19.Location = new System.Drawing.Point(88, 128);
            this.numericTextBox19.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox19.MaxPrecision = 5;
            this.numericTextBox19.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox19.Name = "numericTextBox19";
            this.numericTextBox19.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox19.TabIndex = 14;
            this.numericTextBox19.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label62
            // 
            this.label62.Location = new System.Drawing.Point(8, 132);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(80, 16);
            this.label62.TabIndex = 13;
            this.label62.Text = "Direct Burden";
            // 
            // ntbOutsideCost
            // 
            this.ntbOutsideCost.Location = new System.Drawing.Point(88, 108);
            this.ntbOutsideCost.Maximum = new System.Decimal(new int[] {
                                                                           -1530494977,
                                                                           232830,
                                                                           0,
                                                                           0});
            this.ntbOutsideCost.MaxPrecision = 5;
            this.ntbOutsideCost.Minimum = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            this.ntbOutsideCost.Name = "ntbOutsideCost";
            this.ntbOutsideCost.Size = new System.Drawing.Size(88, 20);
            this.ntbOutsideCost.TabIndex = 12;
            this.ntbOutsideCost.Value = new System.Decimal(new int[] {
                                                                         0,
                                                                         0,
                                                                         0,
                                                                         0});
            // 
            // lIdOutsideCost
            // 
            this.lIdOutsideCost.Location = new System.Drawing.Point(8, 112);
            this.lIdOutsideCost.Name = "lIdOutsideCost";
            this.lIdOutsideCost.Size = new System.Drawing.Size(48, 16);
            this.lIdOutsideCost.TabIndex = 11;
            this.lIdOutsideCost.Text = "Outside ";
            // 
            // ntbID_MatCost
            // 
            this.ntbID_MatCost.Location = new System.Drawing.Point(88, 8);
            this.ntbID_MatCost.Maximum = new System.Decimal(new int[] {
                                                                          1316134911,
                                                                          2328,
                                                                          0,
                                                                          0});
            this.ntbID_MatCost.MaxPrecision = 5;
            this.ntbID_MatCost.Minimum = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            this.ntbID_MatCost.Name = "ntbID_MatCost";
            this.ntbID_MatCost.Size = new System.Drawing.Size(88, 20);
            this.ntbID_MatCost.TabIndex = 10;
            this.ntbID_MatCost.Value = new System.Decimal(new int[] {
                                                                        0,
                                                                        0,
                                                                        0,
                                                                        0});
            // 
            // ntbID_OHCost
            // 
            this.ntbID_OHCost.Location = new System.Drawing.Point(88, 68);
            this.ntbID_OHCost.Maximum = new System.Decimal(new int[] {
                                                                         -1530494977,
                                                                         232830,
                                                                         0,
                                                                         0});
            this.ntbID_OHCost.MaxPrecision = 5;
            this.ntbID_OHCost.Minimum = new System.Decimal(new int[] {
                                                                         0,
                                                                         0,
                                                                         0,
                                                                         0});
            this.ntbID_OHCost.Name = "ntbID_OHCost";
            this.ntbID_OHCost.Size = new System.Drawing.Size(88, 20);
            this.ntbID_OHCost.TabIndex = 9;
            this.ntbID_OHCost.Value = new System.Decimal(new int[] {
                                                                       0,
                                                                       0,
                                                                       0,
                                                                       0});
            // 
            // lIdOHCost
            // 
            this.lIdOHCost.Location = new System.Drawing.Point(8, 72);
            this.lIdOHCost.Name = "lIdOHCost";
            this.lIdOHCost.Size = new System.Drawing.Size(48, 16);
            this.lIdOHCost.TabIndex = 8;
            this.lIdOHCost.Text = "Oh";
            // 
            // lIdMatCost
            // 
            this.lIdMatCost.Location = new System.Drawing.Point(8, 12);
            this.lIdMatCost.Name = "lIdMatCost";
            this.lIdMatCost.Size = new System.Drawing.Size(56, 16);
            this.lIdMatCost.TabIndex = 6;
            this.lIdMatCost.Text = "Mataterial";
            // 
            // ntbId_UnitCost
            // 
            this.ntbId_UnitCost.Location = new System.Drawing.Point(88, 28);
            this.ntbId_UnitCost.Maximum = new System.Decimal(new int[] {
                                                                           -1530494977,
                                                                           232830,
                                                                           0,
                                                                           0});
            this.ntbId_UnitCost.MaxPrecision = 5;
            this.ntbId_UnitCost.Minimum = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            this.ntbId_UnitCost.Name = "ntbId_UnitCost";
            this.ntbId_UnitCost.Size = new System.Drawing.Size(88, 20);
            this.ntbId_UnitCost.TabIndex = 5;
            this.ntbId_UnitCost.Value = new System.Decimal(new int[] {
                                                                         0,
                                                                         0,
                                                                         0,
                                                                         0});
            // 
            // ntbId_LabCost
            // 
            this.ntbId_LabCost.Location = new System.Drawing.Point(88, 88);
            this.ntbId_LabCost.Maximum = new System.Decimal(new int[] {
                                                                          1316134911,
                                                                          2328,
                                                                          0,
                                                                          0});
            this.ntbId_LabCost.MaxPrecision = 5;
            this.ntbId_LabCost.Minimum = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            this.ntbId_LabCost.Name = "ntbId_LabCost";
            this.ntbId_LabCost.Size = new System.Drawing.Size(88, 20);
            this.ntbId_LabCost.TabIndex = 4;
            this.ntbId_LabCost.Value = new System.Decimal(new int[] {
                                                                        0,
                                                                        0,
                                                                        0,
                                                                        0});
            // 
            // ntbID_CostExt
            // 
            this.ntbID_CostExt.Location = new System.Drawing.Point(88, 48);
            this.ntbID_CostExt.Maximum = new System.Decimal(new int[] {
                                                                          -727379969,
                                                                          232,
                                                                          0,
                                                                          0});
            this.ntbID_CostExt.MaxPrecision = 2;
            this.ntbID_CostExt.Minimum = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            this.ntbID_CostExt.Name = "ntbID_CostExt";
            this.ntbID_CostExt.Size = new System.Drawing.Size(88, 20);
            this.ntbID_CostExt.TabIndex = 3;
            this.ntbID_CostExt.Value = new System.Decimal(new int[] {
                                                                        0,
                                                                        0,
                                                                        0,
                                                                        0});
            // 
            // lIdUnitCost
            // 
            this.lIdUnitCost.Location = new System.Drawing.Point(8, 32);
            this.lIdUnitCost.Name = "lIdUnitCost";
            this.lIdUnitCost.Size = new System.Drawing.Size(48, 16);
            this.lIdUnitCost.TabIndex = 2;
            this.lIdUnitCost.Text = "Unit";
            // 
            // lIdLabCost
            // 
            this.lIdLabCost.Location = new System.Drawing.Point(8, 112);
            this.lIdLabCost.Name = "lIdLabCost";
            this.lIdLabCost.Size = new System.Drawing.Size(48, 16);
            this.lIdLabCost.TabIndex = 1;
            this.lIdLabCost.Text = "Lab ";
            // 
            // lIdCostExt
            // 
            this.lIdCostExt.Location = new System.Drawing.Point(8, 52);
            this.lIdCostExt.Name = "lIdCostExt";
            this.lIdCostExt.Size = new System.Drawing.Size(48, 16);
            this.lIdCostExt.TabIndex = 0;
            this.lIdCostExt.Text = "Ext.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelOH_Tax1Total);
            this.groupBox1.Controls.Add(this.textBoxOH_CommissTot);
            this.groupBox1.Controls.Add(this.labeOH_Tax2Total);
            this.groupBox1.Controls.Add(this.textBoxOH_Tax2Total);
            this.groupBox1.Controls.Add(this.labelOH_Tax3Total);
            this.groupBox1.Controls.Add(this.textBoxOH_Tax3Total);
            this.groupBox1.Controls.Add(this.labelOH_DiscountTot);
            this.groupBox1.Controls.Add(this.textBoxOH_DiscountTot);
            this.groupBox1.Controls.Add(this.labelOH_OrderNet);
            this.groupBox1.Controls.Add(this.textBoxOH_OrderNet);
            this.groupBox1.Controls.Add(this.labelOH_RoyaltyTot);
            this.groupBox1.Controls.Add(this.textBoxOH_Tax1Total);
            this.groupBox1.Controls.Add(this.labelOH_OrderTotal);
            this.groupBox1.Controls.Add(this.textBoxOH_RoyaltyTot);
            this.groupBox1.Controls.Add(this.textBoxOH_OrderTotal);
            this.groupBox1.Controls.Add(this.labelOH_CommissTot);
            this.groupBox1.Location = new System.Drawing.Point(424, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 224);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Totals";
            // 
            // labelOH_Tax1Total
            // 
            this.labelOH_Tax1Total.Location = new System.Drawing.Point(8, 80);
            this.labelOH_Tax1Total.Name = "labelOH_Tax1Total";
            this.labelOH_Tax1Total.Size = new System.Drawing.Size(72, 20);
            this.labelOH_Tax1Total.TabIndex = 43;
            this.labelOH_Tax1Total.Text = "Tax1 Total";
            this.labelOH_Tax1Total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_CommissTot
            // 
            this.textBoxOH_CommissTot.Location = new System.Drawing.Point(80, 172);
            this.textBoxOH_CommissTot.MaxLength = 10;
            this.textBoxOH_CommissTot.Name = "textBoxOH_CommissTot";
            this.textBoxOH_CommissTot.ReadOnly = true;
            this.textBoxOH_CommissTot.Size = new System.Drawing.Size(88, 20);
            this.textBoxOH_CommissTot.TabIndex = 31;
            this.textBoxOH_CommissTot.TabStop = false;
            this.textBoxOH_CommissTot.Text = "0.00";
            this.textBoxOH_CommissTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labeOH_Tax2Total
            // 
            this.labeOH_Tax2Total.Location = new System.Drawing.Point(8, 100);
            this.labeOH_Tax2Total.Name = "labeOH_Tax2Total";
            this.labeOH_Tax2Total.Size = new System.Drawing.Size(72, 20);
            this.labeOH_Tax2Total.TabIndex = 53;
            this.labeOH_Tax2Total.Text = "Tax2 Total";
            this.labeOH_Tax2Total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_Tax2Total
            // 
            this.textBoxOH_Tax2Total.Location = new System.Drawing.Point(80, 100);
            this.textBoxOH_Tax2Total.MaxLength = 10;
            this.textBoxOH_Tax2Total.Name = "textBoxOH_Tax2Total";
            this.textBoxOH_Tax2Total.ReadOnly = true;
            this.textBoxOH_Tax2Total.Size = new System.Drawing.Size(88, 20);
            this.textBoxOH_Tax2Total.TabIndex = 28;
            this.textBoxOH_Tax2Total.TabStop = false;
            this.textBoxOH_Tax2Total.Text = "0.00";
            this.textBoxOH_Tax2Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelOH_Tax3Total
            // 
            this.labelOH_Tax3Total.Location = new System.Drawing.Point(8, 120);
            this.labelOH_Tax3Total.Name = "labelOH_Tax3Total";
            this.labelOH_Tax3Total.Size = new System.Drawing.Size(72, 20);
            this.labelOH_Tax3Total.TabIndex = 55;
            this.labelOH_Tax3Total.Text = "Tax3 Total";
            this.labelOH_Tax3Total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_Tax3Total
            // 
            this.textBoxOH_Tax3Total.Location = new System.Drawing.Point(80, 120);
            this.textBoxOH_Tax3Total.MaxLength = 10;
            this.textBoxOH_Tax3Total.Name = "textBoxOH_Tax3Total";
            this.textBoxOH_Tax3Total.ReadOnly = true;
            this.textBoxOH_Tax3Total.Size = new System.Drawing.Size(88, 20);
            this.textBoxOH_Tax3Total.TabIndex = 29;
            this.textBoxOH_Tax3Total.TabStop = false;
            this.textBoxOH_Tax3Total.Text = "0.00";
            this.textBoxOH_Tax3Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelOH_DiscountTot
            // 
            this.labelOH_DiscountTot.Location = new System.Drawing.Point(8, 152);
            this.labelOH_DiscountTot.Name = "labelOH_DiscountTot";
            this.labelOH_DiscountTot.Size = new System.Drawing.Size(72, 20);
            this.labelOH_DiscountTot.TabIndex = 57;
            this.labelOH_DiscountTot.Text = "Discount Tot.";
            this.labelOH_DiscountTot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_DiscountTot
            // 
            this.textBoxOH_DiscountTot.Location = new System.Drawing.Point(80, 152);
            this.textBoxOH_DiscountTot.MaxLength = 10;
            this.textBoxOH_DiscountTot.Name = "textBoxOH_DiscountTot";
            this.textBoxOH_DiscountTot.ReadOnly = true;
            this.textBoxOH_DiscountTot.Size = new System.Drawing.Size(88, 20);
            this.textBoxOH_DiscountTot.TabIndex = 30;
            this.textBoxOH_DiscountTot.TabStop = false;
            this.textBoxOH_DiscountTot.Text = "0.00";
            this.textBoxOH_DiscountTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelOH_OrderNet
            // 
            this.labelOH_OrderNet.Location = new System.Drawing.Point(8, 44);
            this.labelOH_OrderNet.Name = "labelOH_OrderNet";
            this.labelOH_OrderNet.Size = new System.Drawing.Size(72, 20);
            this.labelOH_OrderNet.TabIndex = 41;
            this.labelOH_OrderNet.Text = "Order Net";
            this.labelOH_OrderNet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_OrderNet
            // 
            this.textBoxOH_OrderNet.Location = new System.Drawing.Point(80, 44);
            this.textBoxOH_OrderNet.MaxLength = 10;
            this.textBoxOH_OrderNet.Name = "textBoxOH_OrderNet";
            this.textBoxOH_OrderNet.ReadOnly = true;
            this.textBoxOH_OrderNet.Size = new System.Drawing.Size(88, 20);
            this.textBoxOH_OrderNet.TabIndex = 26;
            this.textBoxOH_OrderNet.TabStop = false;
            this.textBoxOH_OrderNet.Text = "0.00";
            this.textBoxOH_OrderNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelOH_RoyaltyTot
            // 
            this.labelOH_RoyaltyTot.Location = new System.Drawing.Point(8, 192);
            this.labelOH_RoyaltyTot.Name = "labelOH_RoyaltyTot";
            this.labelOH_RoyaltyTot.Size = new System.Drawing.Size(72, 20);
            this.labelOH_RoyaltyTot.TabIndex = 63;
            this.labelOH_RoyaltyTot.Text = "Royalty Tot.";
            this.labelOH_RoyaltyTot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_Tax1Total
            // 
            this.textBoxOH_Tax1Total.Location = new System.Drawing.Point(80, 80);
            this.textBoxOH_Tax1Total.MaxLength = 10;
            this.textBoxOH_Tax1Total.Name = "textBoxOH_Tax1Total";
            this.textBoxOH_Tax1Total.ReadOnly = true;
            this.textBoxOH_Tax1Total.Size = new System.Drawing.Size(88, 20);
            this.textBoxOH_Tax1Total.TabIndex = 27;
            this.textBoxOH_Tax1Total.TabStop = false;
            this.textBoxOH_Tax1Total.Text = "0.00";
            this.textBoxOH_Tax1Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelOH_OrderTotal
            // 
            this.labelOH_OrderTotal.Location = new System.Drawing.Point(8, 24);
            this.labelOH_OrderTotal.Name = "labelOH_OrderTotal";
            this.labelOH_OrderTotal.Size = new System.Drawing.Size(72, 20);
            this.labelOH_OrderTotal.TabIndex = 31;
            this.labelOH_OrderTotal.Text = "Order Total";
            this.labelOH_OrderTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_RoyaltyTot
            // 
            this.textBoxOH_RoyaltyTot.Location = new System.Drawing.Point(80, 192);
            this.textBoxOH_RoyaltyTot.MaxLength = 10;
            this.textBoxOH_RoyaltyTot.Name = "textBoxOH_RoyaltyTot";
            this.textBoxOH_RoyaltyTot.ReadOnly = true;
            this.textBoxOH_RoyaltyTot.Size = new System.Drawing.Size(88, 20);
            this.textBoxOH_RoyaltyTot.TabIndex = 32;
            this.textBoxOH_RoyaltyTot.TabStop = false;
            this.textBoxOH_RoyaltyTot.Text = "0.00";
            this.textBoxOH_RoyaltyTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxOH_OrderTotal
            // 
            this.textBoxOH_OrderTotal.Location = new System.Drawing.Point(80, 24);
            this.textBoxOH_OrderTotal.MaxLength = 10;
            this.textBoxOH_OrderTotal.Name = "textBoxOH_OrderTotal";
            this.textBoxOH_OrderTotal.ReadOnly = true;
            this.textBoxOH_OrderTotal.Size = new System.Drawing.Size(88, 20);
            this.textBoxOH_OrderTotal.TabIndex = 25;
            this.textBoxOH_OrderTotal.TabStop = false;
            this.textBoxOH_OrderTotal.Text = "0.00";
            this.textBoxOH_OrderTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelOH_CommissTot
            // 
            this.labelOH_CommissTot.Location = new System.Drawing.Point(8, 172);
            this.labelOH_CommissTot.Name = "labelOH_CommissTot";
            this.labelOH_CommissTot.Size = new System.Drawing.Size(80, 20);
            this.labelOH_CommissTot.TabIndex = 59;
            this.labelOH_CommissTot.Text = "Commiss Tot.";
            this.labelOH_CommissTot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPageSales
            // 
            this.tabPageSales.Controls.Add(this.groupBox17);
            this.tabPageSales.Controls.Add(this.groupBox5);
            this.tabPageSales.Controls.Add(this.groupBox6);
            this.tabPageSales.Controls.Add(this.groupBoxDate);
            this.tabPageSales.Controls.Add(this.groupBox4);
            this.tabPageSales.Controls.Add(this.gBoxSalesCode);
            this.tabPageSales.Location = new System.Drawing.Point(4, 22);
            this.tabPageSales.Name = "tabPageSales";
            this.tabPageSales.Size = new System.Drawing.Size(840, 382);
            this.tabPageSales.TabIndex = 9;
            this.tabPageSales.Text = "Sales";
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.labelOH_Terms);
            this.groupBox17.Controls.Add(this.textBoxOH_Territory);
            this.groupBox17.Controls.Add(this.textBoxOH_DistributionLoc);
            this.groupBox17.Controls.Add(this.labelOH_Territory);
            this.groupBox17.Controls.Add(this.label5);
            this.groupBox17.Controls.Add(this.textBoxOH_Terms);
            this.groupBox17.Controls.Add(this.buttonOH_Note);
            this.groupBox17.Controls.Add(this.labelOH_HoldStatus);
            this.groupBox17.Controls.Add(this.checkBoxOH_Note);
            this.groupBox17.Controls.Add(this.textBoxOH_HoldStatus);
            this.groupBox17.Location = new System.Drawing.Point(48, 200);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(512, 100);
            this.groupBox17.TabIndex = 111;
            this.groupBox17.TabStop = false;
            // 
            // labelOH_Terms
            // 
            this.labelOH_Terms.Location = new System.Drawing.Point(24, 16);
            this.labelOH_Terms.Name = "labelOH_Terms";
            this.labelOH_Terms.Size = new System.Drawing.Size(72, 20);
            this.labelOH_Terms.TabIndex = 101;
            this.labelOH_Terms.Text = "Terms";
            this.labelOH_Terms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_Territory
            // 
            this.textBoxOH_Territory.Location = new System.Drawing.Point(96, 40);
            this.textBoxOH_Territory.MaxLength = 20;
            this.textBoxOH_Territory.Name = "textBoxOH_Territory";
            this.textBoxOH_Territory.TabIndex = 102;
            this.textBoxOH_Territory.Text = "";
            // 
            // textBoxOH_DistributionLoc
            // 
            this.textBoxOH_DistributionLoc.Location = new System.Drawing.Point(96, 64);
            this.textBoxOH_DistributionLoc.MaxLength = 20;
            this.textBoxOH_DistributionLoc.Name = "textBoxOH_DistributionLoc";
            this.textBoxOH_DistributionLoc.TabIndex = 103;
            this.textBoxOH_DistributionLoc.Text = "";
            // 
            // labelOH_Territory
            // 
            this.labelOH_Territory.Location = new System.Drawing.Point(24, 40);
            this.labelOH_Territory.Name = "labelOH_Territory";
            this.labelOH_Territory.Size = new System.Drawing.Size(72, 20);
            this.labelOH_Territory.TabIndex = 104;
            this.labelOH_Territory.Text = "Territory";
            this.labelOH_Territory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 99;
            this.label5.Text = "Distri. Loc.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_Terms
            // 
            this.textBoxOH_Terms.Location = new System.Drawing.Point(96, 16);
            this.textBoxOH_Terms.MaxLength = 10;
            this.textBoxOH_Terms.Name = "textBoxOH_Terms";
            this.textBoxOH_Terms.TabIndex = 100;
            this.textBoxOH_Terms.Text = "";
            // 
            // buttonOH_Note
            // 
            this.buttonOH_Note.Location = new System.Drawing.Point(472, 16);
            this.buttonOH_Note.Name = "buttonOH_Note";
            this.buttonOH_Note.Size = new System.Drawing.Size(24, 16);
            this.buttonOH_Note.TabIndex = 109;
            this.buttonOH_Note.Text = "...";
            // 
            // labelOH_HoldStatus
            // 
            this.labelOH_HoldStatus.Location = new System.Drawing.Point(216, 16);
            this.labelOH_HoldStatus.Name = "labelOH_HoldStatus";
            this.labelOH_HoldStatus.Size = new System.Drawing.Size(64, 20);
            this.labelOH_HoldStatus.TabIndex = 108;
            this.labelOH_HoldStatus.Text = "Hold Status";
            this.labelOH_HoldStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxOH_Note
            // 
            this.checkBoxOH_Note.Enabled = false;
            this.checkBoxOH_Note.Location = new System.Drawing.Point(408, 16);
            this.checkBoxOH_Note.Name = "checkBoxOH_Note";
            this.checkBoxOH_Note.Size = new System.Drawing.Size(56, 20);
            this.checkBoxOH_Note.TabIndex = 107;
            this.checkBoxOH_Note.Text = "Note";
            // 
            // textBoxOH_HoldStatus
            // 
            this.textBoxOH_HoldStatus.Location = new System.Drawing.Point(280, 16);
            this.textBoxOH_HoldStatus.MaxLength = 5;
            this.textBoxOH_HoldStatus.Name = "textBoxOH_HoldStatus";
            this.textBoxOH_HoldStatus.Size = new System.Drawing.Size(96, 20);
            this.textBoxOH_HoldStatus.TabIndex = 110;
            this.textBoxOH_HoldStatus.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdoQuote);
            this.groupBox5.Controls.Add(this.rdoPO);
            this.groupBox5.Location = new System.Drawing.Point(592, 208);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(168, 40);
            this.groupBox5.TabIndex = 105;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Type";
            // 
            // rdoQuote
            // 
            this.rdoQuote.Location = new System.Drawing.Point(96, 16);
            this.rdoQuote.Name = "rdoQuote";
            this.rdoQuote.Size = new System.Drawing.Size(54, 16);
            this.rdoQuote.TabIndex = 7;
            this.rdoQuote.Text = "Quote";
            // 
            // rdoPO
            // 
            this.rdoPO.Checked = true;
            this.rdoPO.Location = new System.Drawing.Point(8, 16);
            this.rdoPO.Name = "rdoPO";
            this.rdoPO.Size = new System.Drawing.Size(102, 16);
            this.rdoPO.TabIndex = 7;
            this.rdoPO.TabStop = true;
            this.rdoPO.Text = "Order";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rdoRhubarb);
            this.groupBox6.Controls.Add(this.rdoRetail);
            this.groupBox6.Location = new System.Drawing.Point(592, 256);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(168, 40);
            this.groupBox6.TabIndex = 106;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Retail Type";
            // 
            // rdoRhubarb
            // 
            this.rdoRhubarb.Location = new System.Drawing.Point(96, 16);
            this.rdoRhubarb.Name = "rdoRhubarb";
            this.rdoRhubarb.Size = new System.Drawing.Size(66, 16);
            this.rdoRhubarb.TabIndex = 7;
            this.rdoRhubarb.Text = "Rhubarb";
            // 
            // rdoRetail
            // 
            this.rdoRetail.Checked = true;
            this.rdoRetail.Location = new System.Drawing.Point(8, 16);
            this.rdoRetail.Name = "rdoRetail";
            this.rdoRetail.Size = new System.Drawing.Size(102, 16);
            this.rdoRetail.TabIndex = 7;
            this.rdoRetail.TabStop = true;
            this.rdoRetail.Text = "Retail";
            // 
            // groupBoxDate
            // 
            this.groupBoxDate.Controls.Add(this.checkBoxOH_DatePromise);
            this.groupBoxDate.Controls.Add(this.checkBoxOH_DateRequest);
            this.groupBoxDate.Controls.Add(this.dateTimePickerOH_DatePromise);
            this.groupBoxDate.Controls.Add(this.dateTimePickerOH_DateRequest);
            this.groupBoxDate.Location = new System.Drawing.Point(592, 120);
            this.groupBoxDate.Name = "groupBoxDate";
            this.groupBoxDate.Size = new System.Drawing.Size(208, 80);
            this.groupBoxDate.TabIndex = 98;
            this.groupBoxDate.TabStop = false;
            this.groupBoxDate.Text = "Date";
            // 
            // checkBoxOH_DatePromise
            // 
            this.checkBoxOH_DatePromise.Location = new System.Drawing.Point(8, 48);
            this.checkBoxOH_DatePromise.Name = "checkBoxOH_DatePromise";
            this.checkBoxOH_DatePromise.Size = new System.Drawing.Size(72, 20);
            this.checkBoxOH_DatePromise.TabIndex = 15;
            this.checkBoxOH_DatePromise.Text = "Promise";
            // 
            // checkBoxOH_DateRequest
            // 
            this.checkBoxOH_DateRequest.Location = new System.Drawing.Point(8, 24);
            this.checkBoxOH_DateRequest.Name = "checkBoxOH_DateRequest";
            this.checkBoxOH_DateRequest.Size = new System.Drawing.Size(72, 20);
            this.checkBoxOH_DateRequest.TabIndex = 5;
            this.checkBoxOH_DateRequest.Text = "Request";
            // 
            // dateTimePickerOH_DatePromise
            // 
            this.dateTimePickerOH_DatePromise.Enabled = false;
            this.dateTimePickerOH_DatePromise.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerOH_DatePromise.Location = new System.Drawing.Point(80, 48);
            this.dateTimePickerOH_DatePromise.Name = "dateTimePickerOH_DatePromise";
            this.dateTimePickerOH_DatePromise.Size = new System.Drawing.Size(96, 20);
            this.dateTimePickerOH_DatePromise.TabIndex = 20;
            // 
            // dateTimePickerOH_DateRequest
            // 
            this.dateTimePickerOH_DateRequest.Enabled = false;
            this.dateTimePickerOH_DateRequest.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerOH_DateRequest.Location = new System.Drawing.Point(80, 24);
            this.dateTimePickerOH_DateRequest.Name = "dateTimePickerOH_DateRequest";
            this.dateTimePickerOH_DateRequest.Size = new System.Drawing.Size(96, 20);
            this.dateTimePickerOH_DateRequest.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.textBox43);
            this.groupBox4.Controls.Add(this.label66);
            this.groupBox4.Controls.Add(this.textBoxOH_ComRate);
            this.groupBox4.Controls.Add(this.labelOH_ComRate);
            this.groupBox4.Controls.Add(this.textBoxOH_ComPercent);
            this.groupBox4.Controls.Add(this.labelOH_ComPercent);
            this.groupBox4.Location = new System.Drawing.Point(592, 24);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(208, 96);
            this.groupBox4.TabIndex = 97;
            this.groupBox4.TabStop = false;
            // 
            // textBox43
            // 
            this.textBox43.Location = new System.Drawing.Point(88, 64);
            this.textBox43.MaxLength = 11;
            this.textBox43.Name = "textBox43";
            this.textBox43.Size = new System.Drawing.Size(104, 20);
            this.textBox43.TabIndex = 103;
            this.textBox43.Text = "";
            // 
            // label66
            // 
            this.label66.Location = new System.Drawing.Point(16, 64);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(72, 20);
            this.label66.TabIndex = 102;
            this.label66.Text = "Com. Plan";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_ComRate
            // 
            this.textBoxOH_ComRate.Location = new System.Drawing.Point(88, 40);
            this.textBoxOH_ComRate.MaxLength = 11;
            this.textBoxOH_ComRate.Name = "textBoxOH_ComRate";
            this.textBoxOH_ComRate.Size = new System.Drawing.Size(104, 20);
            this.textBoxOH_ComRate.TabIndex = 101;
            this.textBoxOH_ComRate.Text = "";
            // 
            // labelOH_ComRate
            // 
            this.labelOH_ComRate.Location = new System.Drawing.Point(16, 40);
            this.labelOH_ComRate.Name = "labelOH_ComRate";
            this.labelOH_ComRate.Size = new System.Drawing.Size(72, 20);
            this.labelOH_ComRate.TabIndex = 98;
            this.labelOH_ComRate.Text = "Com. Rate";
            this.labelOH_ComRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_ComPercent
            // 
            this.textBoxOH_ComPercent.Location = new System.Drawing.Point(88, 16);
            this.textBoxOH_ComPercent.MaxLength = 7;
            this.textBoxOH_ComPercent.Name = "textBoxOH_ComPercent";
            this.textBoxOH_ComPercent.Size = new System.Drawing.Size(104, 20);
            this.textBoxOH_ComPercent.TabIndex = 99;
            this.textBoxOH_ComPercent.Text = "";
            // 
            // labelOH_ComPercent
            // 
            this.labelOH_ComPercent.Location = new System.Drawing.Point(16, 16);
            this.labelOH_ComPercent.Name = "labelOH_ComPercent";
            this.labelOH_ComPercent.Size = new System.Drawing.Size(72, 20);
            this.labelOH_ComPercent.TabIndex = 100;
            this.labelOH_ComPercent.Text = "Com.Percent";
            this.labelOH_ComPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gBoxSalesCode
            // 
            this.gBoxSalesCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxSalesCode.Controls.Add(this.textBox11);
            this.gBoxSalesCode.Controls.Add(this.textBox10);
            this.gBoxSalesCode.Controls.Add(this.textBox9);
            this.gBoxSalesCode.Controls.Add(this.textBox8);
            this.gBoxSalesCode.Controls.Add(this.textBox7);
            this.gBoxSalesCode.Controls.Add(this.textBox12);
            this.gBoxSalesCode.Controls.Add(this.tBoxID_SC1);
            this.gBoxSalesCode.Controls.Add(this.lIDSc5);
            this.gBoxSalesCode.Controls.Add(this.tBoxID_SC4);
            this.gBoxSalesCode.Controls.Add(this.lIDSc1);
            this.gBoxSalesCode.Controls.Add(this.lIDSc3);
            this.gBoxSalesCode.Controls.Add(this.lIDSc6);
            this.gBoxSalesCode.Controls.Add(this.tBoxID_SC3);
            this.gBoxSalesCode.Controls.Add(this.lIDSc4);
            this.gBoxSalesCode.Controls.Add(this.tBoxID_SC6);
            this.gBoxSalesCode.Controls.Add(this.tBoxID_SC5);
            this.gBoxSalesCode.Controls.Add(this.lIDSc2);
            this.gBoxSalesCode.Controls.Add(this.tBoxID_SC2);
            this.gBoxSalesCode.Controls.Add(this.btnSchSc);
            this.gBoxSalesCode.Location = new System.Drawing.Point(48, 24);
            this.gBoxSalesCode.Name = "gBoxSalesCode";
            this.gBoxSalesCode.Size = new System.Drawing.Size(512, 176);
            this.gBoxSalesCode.TabIndex = 4;
            this.gBoxSalesCode.TabStop = false;
            this.gBoxSalesCode.Text = "Sales Code";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(144, 48);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(320, 20);
            this.textBox11.TabIndex = 96;
            this.textBox11.Text = "";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(144, 72);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(320, 20);
            this.textBox10.TabIndex = 95;
            this.textBox10.Text = "";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(144, 144);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(320, 20);
            this.textBox9.TabIndex = 94;
            this.textBox9.Text = "";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(144, 118);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(320, 20);
            this.textBox8.TabIndex = 93;
            this.textBox8.Text = "";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(144, 96);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(320, 20);
            this.textBox7.TabIndex = 92;
            this.textBox7.Text = "";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(144, 24);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(320, 20);
            this.textBox12.TabIndex = 91;
            this.textBox12.Text = "";
            // 
            // tBoxID_SC1
            // 
            this.tBoxID_SC1.Location = new System.Drawing.Point(56, 24);
            this.tBoxID_SC1.MaxLength = 5;
            this.tBoxID_SC1.Name = "tBoxID_SC1";
            this.tBoxID_SC1.ReadOnly = true;
            this.tBoxID_SC1.Size = new System.Drawing.Size(80, 20);
            this.tBoxID_SC1.TabIndex = 6;
            this.tBoxID_SC1.Text = "";
            // 
            // lIDSc5
            // 
            this.lIDSc5.Location = new System.Drawing.Point(24, 120);
            this.lIDSc5.Name = "lIDSc5";
            this.lIDSc5.Size = new System.Drawing.Size(24, 16);
            this.lIDSc5.TabIndex = 3;
            this.lIDSc5.Text = "5";
            // 
            // tBoxID_SC4
            // 
            this.tBoxID_SC4.Location = new System.Drawing.Point(56, 96);
            this.tBoxID_SC4.MaxLength = 5;
            this.tBoxID_SC4.Name = "tBoxID_SC4";
            this.tBoxID_SC4.ReadOnly = true;
            this.tBoxID_SC4.Size = new System.Drawing.Size(80, 20);
            this.tBoxID_SC4.TabIndex = 20;
            this.tBoxID_SC4.Text = "";
            // 
            // lIDSc1
            // 
            this.lIDSc1.Location = new System.Drawing.Point(24, 24);
            this.lIDSc1.Name = "lIDSc1";
            this.lIDSc1.Size = new System.Drawing.Size(24, 16);
            this.lIDSc1.TabIndex = 0;
            this.lIDSc1.Text = "1";
            // 
            // lIDSc3
            // 
            this.lIDSc3.Location = new System.Drawing.Point(24, 72);
            this.lIDSc3.Name = "lIDSc3";
            this.lIDSc3.Size = new System.Drawing.Size(24, 16);
            this.lIDSc3.TabIndex = 5;
            this.lIDSc3.Text = "3";
            // 
            // lIDSc6
            // 
            this.lIDSc6.Location = new System.Drawing.Point(24, 144);
            this.lIDSc6.Name = "lIDSc6";
            this.lIDSc6.Size = new System.Drawing.Size(24, 16);
            this.lIDSc6.TabIndex = 2;
            this.lIDSc6.Text = "6";
            // 
            // tBoxID_SC3
            // 
            this.tBoxID_SC3.Location = new System.Drawing.Point(56, 72);
            this.tBoxID_SC3.MaxLength = 5;
            this.tBoxID_SC3.Name = "tBoxID_SC3";
            this.tBoxID_SC3.ReadOnly = true;
            this.tBoxID_SC3.Size = new System.Drawing.Size(80, 20);
            this.tBoxID_SC3.TabIndex = 17;
            this.tBoxID_SC3.Text = "";
            // 
            // lIDSc4
            // 
            this.lIDSc4.Location = new System.Drawing.Point(24, 96);
            this.lIDSc4.Name = "lIDSc4";
            this.lIDSc4.Size = new System.Drawing.Size(24, 16);
            this.lIDSc4.TabIndex = 4;
            this.lIDSc4.Text = "4";
            // 
            // tBoxID_SC6
            // 
            this.tBoxID_SC6.Location = new System.Drawing.Point(56, 144);
            this.tBoxID_SC6.MaxLength = 5;
            this.tBoxID_SC6.Name = "tBoxID_SC6";
            this.tBoxID_SC6.ReadOnly = true;
            this.tBoxID_SC6.Size = new System.Drawing.Size(80, 20);
            this.tBoxID_SC6.TabIndex = 26;
            this.tBoxID_SC6.Text = "";
            // 
            // tBoxID_SC5
            // 
            this.tBoxID_SC5.Location = new System.Drawing.Point(56, 120);
            this.tBoxID_SC5.MaxLength = 5;
            this.tBoxID_SC5.Name = "tBoxID_SC5";
            this.tBoxID_SC5.ReadOnly = true;
            this.tBoxID_SC5.Size = new System.Drawing.Size(80, 20);
            this.tBoxID_SC5.TabIndex = 23;
            this.tBoxID_SC5.Text = "";
            // 
            // lIDSc2
            // 
            this.lIDSc2.Location = new System.Drawing.Point(24, 48);
            this.lIDSc2.Name = "lIDSc2";
            this.lIDSc2.Size = new System.Drawing.Size(24, 16);
            this.lIDSc2.TabIndex = 1;
            this.lIDSc2.Text = "2";
            // 
            // tBoxID_SC2
            // 
            this.tBoxID_SC2.Location = new System.Drawing.Point(56, 48);
            this.tBoxID_SC2.MaxLength = 5;
            this.tBoxID_SC2.Name = "tBoxID_SC2";
            this.tBoxID_SC2.ReadOnly = true;
            this.tBoxID_SC2.Size = new System.Drawing.Size(80, 20);
            this.tBoxID_SC2.TabIndex = 14;
            this.tBoxID_SC2.Text = "";
            // 
            // btnSchSc
            // 
            this.btnSchSc.Location = new System.Drawing.Point(472, 24);
            this.btnSchSc.Name = "btnSchSc";
            this.btnSchSc.Size = new System.Drawing.Size(32, 16);
            this.btnSchSc.TabIndex = 90;
            this.btnSchSc.Text = "...";
            // 
            // tabPageDistribution
            // 
            this.tabPageDistribution.Location = new System.Drawing.Point(4, 22);
            this.tabPageDistribution.Name = "tabPageDistribution";
            this.tabPageDistribution.Size = new System.Drawing.Size(840, 382);
            this.tabPageDistribution.TabIndex = 3;
            this.tabPageDistribution.Text = "Distribution";
            // 
            // tabPageFreigth
            // 
            this.tabPageFreigth.Controls.Add(this.gBoxAccounting);
            this.tabPageFreigth.Location = new System.Drawing.Point(4, 22);
            this.tabPageFreigth.Name = "tabPageFreigth";
            this.tabPageFreigth.Size = new System.Drawing.Size(840, 382);
            this.tabPageFreigth.TabIndex = 6;
            this.tabPageFreigth.Text = "Freigth";
            // 
            // gBoxAccounting
            // 
            this.gBoxAccounting.Controls.Add(this.groupBox9);
            this.gBoxAccounting.Controls.Add(this.dGridShowDetail);
            this.gBoxAccounting.Controls.Add(this.treeViewInfo);
            this.gBoxAccounting.Controls.Add(this.button6);
            this.gBoxAccounting.Location = new System.Drawing.Point(20, 8);
            this.gBoxAccounting.Name = "gBoxAccounting";
            this.gBoxAccounting.Size = new System.Drawing.Size(800, 368);
            this.gBoxAccounting.TabIndex = 1;
            this.gBoxAccounting.TabStop = false;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.dateTimePicker6);
            this.groupBox9.Controls.Add(this.label100);
            this.groupBox9.Controls.Add(this.dateTimePicker7);
            this.groupBox9.Controls.Add(this.label101);
            this.groupBox9.Controls.Add(this.dateTimePicker5);
            this.groupBox9.Controls.Add(this.label99);
            this.groupBox9.Controls.Add(this.textBox26);
            this.groupBox9.Controls.Add(this.label98);
            this.groupBox9.Controls.Add(this.tBoxIH_FreigthTerms);
            this.groupBox9.Controls.Add(this.label97);
            this.groupBox9.Controls.Add(this.textBox34);
            this.groupBox9.Controls.Add(this.lIHFreigthTerms);
            this.groupBox9.Controls.Add(this.textBox33);
            this.groupBox9.Controls.Add(this.label33);
            this.groupBox9.Controls.Add(this.label34);
            this.groupBox9.Controls.Add(this.numericTextBox39);
            this.groupBox9.Controls.Add(this.numericTextBox38);
            this.groupBox9.Controls.Add(this.label40);
            this.groupBox9.Controls.Add(this.numericTextBox37);
            this.groupBox9.Controls.Add(this.label44);
            this.groupBox9.Controls.Add(this.numericTextBox36);
            this.groupBox9.Controls.Add(this.label45);
            this.groupBox9.Controls.Add(this.numericTextBox35);
            this.groupBox9.Controls.Add(this.label46);
            this.groupBox9.Controls.Add(this.textBox29);
            this.groupBox9.Controls.Add(this.label47);
            this.groupBox9.Controls.Add(this.label48);
            this.groupBox9.Controls.Add(this.numericTextBox9);
            this.groupBox9.Controls.Add(this.textBox32);
            this.groupBox9.Controls.Add(this.textBox52);
            this.groupBox9.Controls.Add(this.label49);
            this.groupBox9.Controls.Add(this.label50);
            this.groupBox9.Controls.Add(this.numericTextBox14);
            this.groupBox9.Controls.Add(this.numericUpDown1);
            this.groupBox9.Controls.Add(this.dateTimePicker4);
            this.groupBox9.Controls.Add(this.textBox56);
            this.groupBox9.Controls.Add(this.label51);
            this.groupBox9.Controls.Add(this.numericTextBox15);
            this.groupBox9.Controls.Add(this.textBox57);
            this.groupBox9.Controls.Add(this.label52);
            this.groupBox9.Controls.Add(this.label53);
            this.groupBox9.Controls.Add(this.label54);
            this.groupBox9.Controls.Add(this.label80);
            this.groupBox9.Controls.Add(this.numericTextBox16);
            this.groupBox9.Controls.Add(this.label81);
            this.groupBox9.Controls.Add(this.label82);
            this.groupBox9.Location = new System.Drawing.Point(8, 184);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(784, 144);
            this.groupBox9.TabIndex = 81;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Container";
            // 
            // dateTimePicker6
            // 
            this.dateTimePicker6.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker6.Location = new System.Drawing.Point(520, 112);
            this.dateTimePicker6.Name = "dateTimePicker6";
            this.dateTimePicker6.Size = new System.Drawing.Size(88, 20);
            this.dateTimePicker6.TabIndex = 91;
            // 
            // label100
            // 
            this.label100.Location = new System.Drawing.Point(448, 116);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(80, 16);
            this.label100.TabIndex = 90;
            this.label100.Text = "Delivery Time";
            // 
            // dateTimePicker7
            // 
            this.dateTimePicker7.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker7.Location = new System.Drawing.Point(520, 88);
            this.dateTimePicker7.Name = "dateTimePicker7";
            this.dateTimePicker7.Size = new System.Drawing.Size(88, 20);
            this.dateTimePicker7.TabIndex = 89;
            // 
            // label101
            // 
            this.label101.Location = new System.Drawing.Point(448, 92);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(80, 16);
            this.label101.TabIndex = 88;
            this.label101.Text = "Delivery Date";
            // 
            // dateTimePicker5
            // 
            this.dateTimePicker5.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker5.Location = new System.Drawing.Point(352, 112);
            this.dateTimePicker5.Name = "dateTimePicker5";
            this.dateTimePicker5.Size = new System.Drawing.Size(88, 20);
            this.dateTimePicker5.TabIndex = 87;
            // 
            // label99
            // 
            this.label99.Location = new System.Drawing.Point(280, 116);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(80, 16);
            this.label99.TabIndex = 86;
            this.label99.Text = "Pickup Time";
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(672, 64);
            this.textBox26.MaxLength = 5;
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(72, 20);
            this.textBox26.TabIndex = 84;
            this.textBox26.Text = "";
            // 
            // label98
            // 
            this.label98.Location = new System.Drawing.Point(600, 68);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(80, 16);
            this.label98.TabIndex = 85;
            this.label98.Text = "Freigth Charge";
            // 
            // tBoxIH_FreigthTerms
            // 
            this.tBoxIH_FreigthTerms.Location = new System.Drawing.Point(352, 64);
            this.tBoxIH_FreigthTerms.MaxLength = 5;
            this.tBoxIH_FreigthTerms.Name = "tBoxIH_FreigthTerms";
            this.tBoxIH_FreigthTerms.Size = new System.Drawing.Size(72, 20);
            this.tBoxIH_FreigthTerms.TabIndex = 80;
            this.tBoxIH_FreigthTerms.Text = "";
            // 
            // label97
            // 
            this.label97.Location = new System.Drawing.Point(440, 68);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(80, 16);
            this.label97.TabIndex = 83;
            this.label97.Text = "Freigth Service";
            // 
            // textBox34
            // 
            this.textBox34.Location = new System.Drawing.Point(520, 64);
            this.textBox34.MaxLength = 5;
            this.textBox34.Name = "textBox34";
            this.textBox34.Size = new System.Drawing.Size(72, 20);
            this.textBox34.TabIndex = 82;
            this.textBox34.Text = "";
            // 
            // lIHFreigthTerms
            // 
            this.lIHFreigthTerms.Location = new System.Drawing.Point(280, 68);
            this.lIHFreigthTerms.Name = "lIHFreigthTerms";
            this.lIHFreigthTerms.Size = new System.Drawing.Size(80, 16);
            this.lIHFreigthTerms.TabIndex = 81;
            this.lIHFreigthTerms.Text = "Freigth Terms";
            // 
            // textBox33
            // 
            this.textBox33.Location = new System.Drawing.Point(232, 112);
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new System.Drawing.Size(40, 20);
            this.textBox33.TabIndex = 70;
            this.textBox33.Text = "";
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(176, 116);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(56, 16);
            this.label33.TabIndex = 71;
            this.label33.Text = "FOB Point";
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(176, 92);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(48, 16);
            this.label34.TabIndex = 69;
            this.label34.Text = "Pro#";
            // 
            // numericTextBox39
            // 
            this.numericTextBox39.Location = new System.Drawing.Point(232, 88);
            this.numericTextBox39.Maximum = new System.Decimal(new int[] {
                                                                             1000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox39.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox39.Name = "numericTextBox39";
            this.numericTextBox39.Size = new System.Drawing.Size(40, 20);
            this.numericTextBox39.TabIndex = 68;
            this.numericTextBox39.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // numericTextBox38
            // 
            this.numericTextBox38.Location = new System.Drawing.Point(496, 36);
            this.numericTextBox38.Maximum = new System.Decimal(new int[] {
                                                                             1000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox38.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox38.Name = "numericTextBox38";
            this.numericTextBox38.Size = new System.Drawing.Size(56, 20);
            this.numericTextBox38.TabIndex = 67;
            this.numericTextBox38.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(416, 36);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(80, 20);
            this.label40.TabIndex = 66;
            this.label40.Text = "Manual Weigth";
            // 
            // numericTextBox37
            // 
            this.numericTextBox37.Location = new System.Drawing.Point(640, 36);
            this.numericTextBox37.Maximum = new System.Decimal(new int[] {
                                                                             1000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox37.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox37.Name = "numericTextBox37";
            this.numericTextBox37.Size = new System.Drawing.Size(56, 20);
            this.numericTextBox37.TabIndex = 65;
            this.numericTextBox37.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(568, 36);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(72, 20);
            this.label44.TabIndex = 64;
            this.label44.Text = "Manual Vol";
            // 
            // numericTextBox36
            // 
            this.numericTextBox36.Location = new System.Drawing.Point(496, 16);
            this.numericTextBox36.Maximum = new System.Decimal(new int[] {
                                                                             1000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox36.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox36.Name = "numericTextBox36";
            this.numericTextBox36.Size = new System.Drawing.Size(56, 20);
            this.numericTextBox36.TabIndex = 63;
            this.numericTextBox36.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(416, 16);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(64, 20);
            this.label45.TabIndex = 62;
            this.label45.Text = "Net Weigth";
            // 
            // numericTextBox35
            // 
            this.numericTextBox35.Location = new System.Drawing.Point(352, 16);
            this.numericTextBox35.Maximum = new System.Decimal(new int[] {
                                                                             1000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox35.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox35.Name = "numericTextBox35";
            this.numericTextBox35.Size = new System.Drawing.Size(56, 20);
            this.numericTextBox35.TabIndex = 61;
            this.numericTextBox35.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(272, 16);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(72, 20);
            this.label46.TabIndex = 60;
            this.label46.Text = "Tare Weigth";
            // 
            // textBox29
            // 
            this.textBox29.Location = new System.Drawing.Point(80, 112);
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(88, 20);
            this.textBox29.TabIndex = 56;
            this.textBox29.Text = "";
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(8, 116);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(72, 16);
            this.label47.TabIndex = 57;
            this.label47.Text = "Carrier Loc.";
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(176, 68);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(48, 16);
            this.label48.TabIndex = 55;
            this.label48.Text = "Trailer #";
            // 
            // numericTextBox9
            // 
            this.numericTextBox9.Location = new System.Drawing.Point(232, 64);
            this.numericTextBox9.Maximum = new System.Decimal(new int[] {
                                                                            1000000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox9.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox9.Name = "numericTextBox9";
            this.numericTextBox9.Size = new System.Drawing.Size(40, 20);
            this.numericTextBox9.TabIndex = 54;
            this.numericTextBox9.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // textBox32
            // 
            this.textBox32.Location = new System.Drawing.Point(80, 64);
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new System.Drawing.Size(88, 20);
            this.textBox32.TabIndex = 52;
            this.textBox32.Text = "";
            // 
            // textBox52
            // 
            this.textBox52.Location = new System.Drawing.Point(80, 88);
            this.textBox52.Name = "textBox52";
            this.textBox52.Size = new System.Drawing.Size(88, 20);
            this.textBox52.TabIndex = 50;
            this.textBox52.Text = "";
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(8, 92);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(72, 16);
            this.label49.TabIndex = 51;
            this.label49.Text = "Carrier Name";
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(8, 68);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(48, 16);
            this.label50.TabIndex = 48;
            this.label50.Text = "SCAC";
            // 
            // numericTextBox14
            // 
            this.numericTextBox14.Location = new System.Drawing.Point(688, 112);
            this.numericTextBox14.Maximum = new System.Decimal(new int[] {
                                                                             1000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox14.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox14.Name = "numericTextBox14";
            this.numericTextBox14.Size = new System.Drawing.Size(64, 20);
            this.numericTextBox14.TabIndex = 47;
            this.numericTextBox14.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(72, 16);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown1.TabIndex = 35;
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker4.Location = new System.Drawing.Point(352, 88);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(88, 20);
            this.dateTimePicker4.TabIndex = 34;
            // 
            // textBox56
            // 
            this.textBox56.Location = new System.Drawing.Point(640, 16);
            this.textBox56.Name = "textBox56";
            this.textBox56.Size = new System.Drawing.Size(56, 20);
            this.textBox56.TabIndex = 40;
            this.textBox56.Text = "";
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(128, 36);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(72, 20);
            this.label51.TabIndex = 42;
            this.label51.Text = "Total Volume";
            // 
            // numericTextBox15
            // 
            this.numericTextBox15.Location = new System.Drawing.Point(208, 36);
            this.numericTextBox15.Maximum = new System.Decimal(new int[] {
                                                                             1000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox15.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox15.Name = "numericTextBox15";
            this.numericTextBox15.Size = new System.Drawing.Size(56, 20);
            this.numericTextBox15.TabIndex = 43;
            this.numericTextBox15.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // textBox57
            // 
            this.textBox57.Location = new System.Drawing.Point(352, 36);
            this.textBox57.Name = "textBox57";
            this.textBox57.Size = new System.Drawing.Size(56, 20);
            this.textBox57.TabIndex = 44;
            this.textBox57.Text = "";
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(272, 36);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(72, 20);
            this.label52.TabIndex = 45;
            this.label52.Text = "Volume Uom";
            // 
            // label53
            // 
            this.label53.Location = new System.Drawing.Point(568, 16);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(72, 20);
            this.label53.TabIndex = 41;
            this.label53.Text = "Weigth Uom";
            // 
            // label54
            // 
            this.label54.Location = new System.Drawing.Point(8, 20);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(64, 16);
            this.label54.TabIndex = 31;
            this.label54.Text = "Total Skids";
            // 
            // label80
            // 
            this.label80.Location = new System.Drawing.Point(280, 92);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(80, 16);
            this.label80.TabIndex = 33;
            this.label80.Text = "Pickup Date";
            // 
            // numericTextBox16
            // 
            this.numericTextBox16.Location = new System.Drawing.Point(208, 16);
            this.numericTextBox16.Maximum = new System.Decimal(new int[] {
                                                                             1000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox16.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox16.Name = "numericTextBox16";
            this.numericTextBox16.Size = new System.Drawing.Size(56, 20);
            this.numericTextBox16.TabIndex = 39;
            this.numericTextBox16.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label81
            // 
            this.label81.Location = new System.Drawing.Point(128, 16);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(72, 20);
            this.label81.TabIndex = 38;
            this.label81.Text = "Total Weigth";
            // 
            // label82
            // 
            this.label82.Location = new System.Drawing.Point(616, 116);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(80, 16);
            this.label82.TabIndex = 46;
            this.label82.Text = "Freight Total";
            // 
            // dGridShowDetail
            // 
            this.dGridShowDetail.DataMember = "";
            this.dGridShowDetail.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridShowDetail.Location = new System.Drawing.Point(176, 16);
            this.dGridShowDetail.Name = "dGridShowDetail";
            this.dGridShowDetail.Size = new System.Drawing.Size(616, 168);
            this.dGridShowDetail.TabIndex = 1;
            // 
            // treeViewInfo
            // 
            this.treeViewInfo.ImageIndex = -1;
            this.treeViewInfo.Location = new System.Drawing.Point(8, 16);
            this.treeViewInfo.Name = "treeViewInfo";
            this.treeViewInfo.SelectedImageIndex = -1;
            this.treeViewInfo.Size = new System.Drawing.Size(160, 168);
            this.treeViewInfo.TabIndex = 0;
            this.treeViewInfo.Click += new System.EventHandler(this.treeViewInfo_Click_1);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(712, 336);
            this.button6.Name = "button6";
            this.button6.TabIndex = 82;
            this.button6.Text = "3rd Party";
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Size = new System.Drawing.Size(840, 382);
            this.tabPageConfig.TabIndex = 10;
            this.tabPageConfig.Text = "Configuration";
            // 
            // tabPageMaterials
            // 
            this.tabPageMaterials.Controls.Add(this.groupBox12);
            this.tabPageMaterials.Location = new System.Drawing.Point(4, 22);
            this.tabPageMaterials.Name = "tabPageMaterials";
            this.tabPageMaterials.Size = new System.Drawing.Size(840, 382);
            this.tabPageMaterials.TabIndex = 1;
            this.tabPageMaterials.Text = "Materials";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.dGtidMaterials);
            this.groupBox12.Controls.Add(this.button11);
            this.groupBox12.Controls.Add(this.button10);
            this.groupBox12.Controls.Add(this.button9);
            this.groupBox12.Location = new System.Drawing.Point(8, 8);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(832, 360);
            this.groupBox12.TabIndex = 73;
            this.groupBox12.TabStop = false;
            // 
            // dGtidMaterials
            // 
            this.dGtidMaterials.DataMember = "";
            this.dGtidMaterials.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dGtidMaterials.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGtidMaterials.Location = new System.Drawing.Point(8, 16);
            this.dGtidMaterials.Name = "dGtidMaterials";
            this.dGtidMaterials.Size = new System.Drawing.Size(816, 304);
            this.dGtidMaterials.TabIndex = 72;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(584, 328);
            this.button11.Name = "button11";
            this.button11.TabIndex = 106;
            this.button11.Text = "Add";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(664, 328);
            this.button10.Name = "button10";
            this.button10.TabIndex = 107;
            this.button10.Text = "Edit";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(744, 328);
            this.button9.Name = "button9";
            this.button9.TabIndex = 108;
            this.button9.Text = "Delete";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridOrderItems);
            this.tabPage1.Controls.Add(this.textBoxEmployeeName);
            this.tabPage1.Controls.Add(this.labelEmployeeName);
            this.tabPage1.Controls.Add(this.textBoxOH_SalesPerson);
            this.tabPage1.Controls.Add(this.labelOH_SalesPerson);
            this.tabPage1.Controls.Add(this.buttonSearchEmployee);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(840, 382);
            this.tabPage1.TabIndex = 13;
            this.tabPage1.Text = "Trash";
            // 
            // dataGridOrderItems
            // 
            this.dataGridOrderItems.CaptionVisible = false;
            this.dataGridOrderItems.DataMember = "";
            this.dataGridOrderItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dataGridOrderItems.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridOrderItems.Location = new System.Drawing.Point(24, 72);
            this.dataGridOrderItems.Name = "dataGridOrderItems";
            this.dataGridOrderItems.ReadOnly = true;
            this.dataGridOrderItems.Size = new System.Drawing.Size(672, 248);
            this.dataGridOrderItems.TabIndex = 41;
            // 
            // textBoxEmployeeName
            // 
            this.textBoxEmployeeName.Location = new System.Drawing.Point(136, 48);
            this.textBoxEmployeeName.MaxLength = 10;
            this.textBoxEmployeeName.Name = "textBoxEmployeeName";
            this.textBoxEmployeeName.ReadOnly = true;
            this.textBoxEmployeeName.Size = new System.Drawing.Size(208, 20);
            this.textBoxEmployeeName.TabIndex = 38;
            this.textBoxEmployeeName.TabStop = false;
            this.textBoxEmployeeName.Text = "";
            // 
            // labelEmployeeName
            // 
            this.labelEmployeeName.Location = new System.Drawing.Point(64, 40);
            this.labelEmployeeName.Name = "labelEmployeeName";
            this.labelEmployeeName.Size = new System.Drawing.Size(72, 24);
            this.labelEmployeeName.TabIndex = 39;
            this.labelEmployeeName.Text = "Name";
            this.labelEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_SalesPerson
            // 
            this.textBoxOH_SalesPerson.Location = new System.Drawing.Point(136, 24);
            this.textBoxOH_SalesPerson.MaxLength = 20;
            this.textBoxOH_SalesPerson.Name = "textBoxOH_SalesPerson";
            this.textBoxOH_SalesPerson.ReadOnly = true;
            this.textBoxOH_SalesPerson.Size = new System.Drawing.Size(88, 20);
            this.textBoxOH_SalesPerson.TabIndex = 36;
            this.textBoxOH_SalesPerson.Text = "";
            // 
            // labelOH_SalesPerson
            // 
            this.labelOH_SalesPerson.Location = new System.Drawing.Point(64, 24);
            this.labelOH_SalesPerson.Name = "labelOH_SalesPerson";
            this.labelOH_SalesPerson.Size = new System.Drawing.Size(72, 20);
            this.labelOH_SalesPerson.TabIndex = 40;
            this.labelOH_SalesPerson.Text = "Employee ID";
            this.labelOH_SalesPerson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonSearchEmployee
            // 
            this.buttonSearchEmployee.Location = new System.Drawing.Point(232, 24);
            this.buttonSearchEmployee.Name = "buttonSearchEmployee";
            this.buttonSearchEmployee.Size = new System.Drawing.Size(32, 16);
            this.buttonSearchEmployee.TabIndex = 37;
            this.buttonSearchEmployee.Text = "...";
            this.buttonSearchEmployee.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.textBox39);
            this.groupBox8.Controls.Add(this.label31);
            this.groupBox8.Controls.Add(this.textBox38);
            this.groupBox8.Controls.Add(this.label30);
            this.groupBox8.Controls.Add(this.textBox37);
            this.groupBox8.Controls.Add(this.label29);
            this.groupBox8.Controls.Add(this.textBox25);
            this.groupBox8.Controls.Add(this.label18);
            this.groupBox8.Controls.Add(this.textBox35);
            this.groupBox8.Controls.Add(this.label17);
            this.groupBox8.Controls.Add(this.dateTimePicker3);
            this.groupBox8.Controls.Add(this.label16);
            this.groupBox8.Controls.Add(this.dateTimePicker2);
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Controls.Add(this.label13);
            this.groupBox8.Controls.Add(this.textBox23);
            this.groupBox8.Controls.Add(this.label14);
            this.groupBox8.Controls.Add(this.textBox24);
            this.groupBox8.Controls.Add(this.dateTimePicker1);
            this.groupBox8.Controls.Add(this.label28);
            this.groupBox8.Controls.Add(this.textBox22);
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.textBox21);
            this.groupBox8.Controls.Add(this.checkBox1);
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Controls.Add(this.textBox20);
            this.groupBox8.Controls.Add(this.labelOH_OrderNum);
            this.groupBox8.Controls.Add(this.textBoxOH_OrderNum);
            this.groupBox8.Controls.Add(this.labelOH_Currency);
            this.groupBox8.Controls.Add(this.textBoxOH_Currency);
            this.groupBox8.Controls.Add(this.labelOH_Company);
            this.groupBox8.Controls.Add(this.textBoxOH_Company);
            this.groupBox8.Controls.Add(this.textBoxOH_Plant);
            this.groupBox8.Controls.Add(this.labelOH_Plant);
            this.groupBox8.Controls.Add(this.label12);
            this.groupBox8.Controls.Add(this.textBox36);
            this.groupBox8.Controls.Add(this.label27);
            this.groupBox8.Location = new System.Drawing.Point(8, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(856, 136);
            this.groupBox8.TabIndex = 137;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Order Header";
            // 
            // textBox39
            // 
            this.textBox39.Location = new System.Drawing.Point(232, 104);
            this.textBox39.MaxLength = 40;
            this.textBox39.Name = "textBox39";
            this.textBox39.Size = new System.Drawing.Size(80, 20);
            this.textBox39.TabIndex = 83;
            this.textBox39.Text = "";
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(160, 108);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(72, 16);
            this.label31.TabIndex = 82;
            this.label31.Text = "Order Status";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox38
            // 
            this.textBox38.Location = new System.Drawing.Point(408, 104);
            this.textBox38.MaxLength = 40;
            this.textBox38.Name = "textBox38";
            this.textBox38.Size = new System.Drawing.Size(148, 20);
            this.textBox38.TabIndex = 81;
            this.textBox38.Text = "";
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(320, 104);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(56, 20);
            this.label30.TabIndex = 80;
            this.label30.Text = "CSR";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox37
            // 
            this.textBox37.Location = new System.Drawing.Point(408, 84);
            this.textBox37.MaxLength = 40;
            this.textBox37.Name = "textBox37";
            this.textBox37.Size = new System.Drawing.Size(148, 20);
            this.textBox37.TabIndex = 79;
            this.textBox37.Text = "";
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(320, 84);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(88, 20);
            this.label29.TabIndex = 78;
            this.label29.Text = "Sales Person";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(408, 64);
            this.textBox25.MaxLength = 40;
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(148, 20);
            this.textBox25.TabIndex = 75;
            this.textBox25.Text = "";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(160, 64);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 20);
            this.label18.TabIndex = 73;
            this.label18.Text = "# of Lines";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox35
            // 
            this.textBox35.Location = new System.Drawing.Point(232, 64);
            this.textBox35.Name = "textBox35";
            this.textBox35.ReadOnly = true;
            this.textBox35.Size = new System.Drawing.Size(80, 20);
            this.textBox35.TabIndex = 74;
            this.textBox35.Text = "0";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(320, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 20);
            this.label17.TabIndex = 71;
            this.label17.Text = "Purchase Order";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(680, 44);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(96, 20);
            this.dateTimePicker3.TabIndex = 69;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(568, 44);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 20);
            this.label16.TabIndex = 70;
            this.label16.Text = "Dock Requiered Date";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(680, 64);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(96, 20);
            this.dateTimePicker2.TabIndex = 67;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(568, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 20);
            this.label15.TabIndex = 68;
            this.label15.Text = "Request Ship Date";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(320, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 20);
            this.label13.TabIndex = 66;
            this.label13.Text = "Ship To Name";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(408, 44);
            this.textBox23.MaxLength = 40;
            this.textBox23.Name = "textBox23";
            this.textBox23.ReadOnly = true;
            this.textBox23.Size = new System.Drawing.Size(148, 20);
            this.textBox23.TabIndex = 65;
            this.textBox23.Text = "";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(160, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 20);
            this.label14.TabIndex = 64;
            this.label14.Text = "Ship To #";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(232, 44);
            this.textBox24.MaxLength = 5;
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(80, 20);
            this.textBox24.TabIndex = 63;
            this.textBox24.Text = "";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(680, 24);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(96, 20);
            this.dateTimePicker1.TabIndex = 61;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(320, 24);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(88, 20);
            this.label28.TabIndex = 60;
            this.label28.Text = "Supplier Name";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(408, 24);
            this.textBox22.MaxLength = 40;
            this.textBox22.Name = "textBox22";
            this.textBox22.ReadOnly = true;
            this.textBox22.Size = new System.Drawing.Size(148, 20);
            this.textBox22.TabIndex = 59;
            this.textBox22.Text = "";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(160, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 20);
            this.label11.TabIndex = 42;
            this.label11.Text = "Supplier#";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(232, 24);
            this.textBox21.MaxLength = 5;
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(80, 20);
            this.textBox21.TabIndex = 41;
            this.textBox21.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(576, 104);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 40;
            this.checkBox1.Text = "Shipped";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 20);
            this.label10.TabIndex = 39;
            this.label10.Text = "Data Base";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(72, 64);
            this.textBox20.MaxLength = 10;
            this.textBox20.Name = "textBox20";
            this.textBox20.ReadOnly = true;
            this.textBox20.Size = new System.Drawing.Size(72, 20);
            this.textBox20.TabIndex = 38;
            this.textBox20.Text = "Dft";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(568, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 20);
            this.label12.TabIndex = 62;
            this.label12.Text = "Date Ordered";
            // 
            // textBox36
            // 
            this.textBox36.Location = new System.Drawing.Point(232, 84);
            this.textBox36.Name = "textBox36";
            this.textBox36.Size = new System.Drawing.Size(80, 20);
            this.textBox36.TabIndex = 77;
            this.textBox36.Text = "0";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(160, 84);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(72, 20);
            this.label27.TabIndex = 76;
            this.label27.Text = "Order Value";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormAddNewOrder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(874, 592);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.tabControlOrder);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSaveOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddNewOrder";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Order";
            this.Load += new System.EventHandler(this.FormAddNewOrder_Load);
            this.tabControlOrder.ResumeLayout(false);
            this.tabPageShip.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.tabPageDiscounts.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridDiscounts)).EndInit();
            this.tabPageContact.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox25.ResumeLayout(false);
            this.groupBox24.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox20.ResumeLayout(false);
            this.groupBox26.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgridContact)).EndInit();
            this.tabPageItems.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridItems)).EndInit();
            this.tabPageCom.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridComponents)).EndInit();
            this.tabPageAcc.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.gBoxTax.ResumeLayout(false);
            this.gBoxCost.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPageSales.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBoxDate.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.gBoxSalesCode.ResumeLayout(false);
            this.tabPageFreigth.ResumeLayout(false);
            this.gBoxAccounting.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGridShowDetail)).EndInit();
            this.tabPageMaterials.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGtidMaterials)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderItems)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

		#region Methods

		private void InitiaControls()
		{
			this.textBoxOH_OrderDate.Text = DateUtil.getDateRepresentation(DateTime.Now,DateUtil.DDMMYYYY);
		}

		private void InitialDataGrid()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Part", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Desc.", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Unit Price", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Quantity", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Disc. Amt", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Net Total", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Total", typeof(string)));
			
	
			DataView dataView = new DataView(dataTable);
			dataView.AllowEdit = false;
			dataView.AllowDelete = false;
			dataView.AllowNew = false;

			dataGridOrderItems.DataSource = dataView;
			dataGridOrderItems.PreferredColumnWidth = 150;
			dataGridOrderItems.TableStyles.Clear();
			dataGridOrderItems.TableStyles.Add(new DataGridTableStyle());

			//setColumnWidths();

			dataGridOrderItems.Refresh();
		}

		private void screenToObject()
		{
			order.setCompany (textBoxOH_Company.Text);
			order.setPlant (textBoxOH_Plant.Text);
			order.setOrderStatus (Constants.ORDER_STATUS_CREATED);
			order.setOrderNum (int.Parse(textBoxOH_OrderNum.Text));
			if (rdoPO.Checked)
				order.setOrderType (Constants.ORDER_TYPE_ORDER);
			else
				order.setOrderType (Constants.ORDER_TYPE_QUOTE);
			if (rdoRetail.Checked)
				order.setRetailProductType (Constants.RETAIL_PRODUCT_TYPE_RETAIL);
			else
				order.setRetailProductType (Constants.RETAIL_PRODUCT_TYPE_RHUBARB);
			order.setPO (textBoxOH_PO.Text);
			order.setCurrency (textBoxOH_Currency.Text);
			order.setSalesPerson (textBoxOH_SalesPerson.Text);
			order.setTerms (textBoxOH_Terms.Text);
			order.setTerritory (textBoxOH_Territory.Text);
			if ((textBoxOH_ComPercent.Text.Equals(string.Empty)) || (textBoxOH_ComPercent.Text.Equals(",")) || (textBoxOH_ComPercent.Text.Equals(".")))
				order.setComPercent (0);
			else
				order.setComPercent (Double.Parse(textBoxOH_ComPercent.Text) / 100);
			if ((textBoxOH_ComRate.Text.Equals(string.Empty)) || (textBoxOH_ComRate.Text.Equals(",")) || (textBoxOH_ComRate.Text.Equals(".")))
				order.setComRate (0);
			else
				order.setComRate (Double.Parse(textBoxOH_ComRate.Text));
			order.setDistributionLoc (textBoxOH_DistributionLoc.Text);
			order.setBillToNum (textBoxOH_BillToNum.Text);
			
			if (billToObj != null) 
			{
				order.setBillToName(billToObj.getName());
				order.setBillToAdd1 (billToObj.getAddress1());
				order.setBillToAdd2 (billToObj.getAddress2());
				order.setBillToAdd3 (billToObj.getAddress3());
				order.setBillToAdd4 (billToObj.getAddress4());
				order.setBillToAdd5 (billToObj.getAddress5());
				order.setBillToAdd6 (billToObj.getAddress6());
				order.setBillToZipCode (billToObj.getZipCode());
			}

			order.setShipVia (textBoxOH_ShipVia.Text);
			order.setHoldStatus (textBoxOH_HoldStatus.Text);
			if (checkBoxOH_DateRequest.Checked)
				order.setDateRequest (dateTimePickerOH_DateRequest.Value);
			if (checkBoxOH_DatePromise.Checked)
				order.setDatePromise (dateTimePickerOH_DatePromise.Value);

			order.setOrderDate (DateTime.Now);
			if (rdoPO.Checked)
				order.setDateConfirm (order.getOrderDate());

			IEnumerator enuDtls = order.getLineEnumerator();
			while (enuDtls.MoveNext())
			{
				OrderDtl orderDtl = (OrderDtl)enuDtls.Current;
				orderDtl.setDateAdded (DateTime.Now);
				IEnumerator enuRel = orderDtl.getDtlRelsEnumerator();
				while (enuRel.MoveNext())
				{
					((OrderDtlRel)enuRel.Current).setDateAdded(DateTime.Now);
				}
			}
		}

		public void objectToScreen ()
		{
			textBoxOH_OrderNet.Text = NumberUtil.toString(order.getOrderNet(),2);
			textBoxOH_OrderTotal.Text = NumberUtil.toString(order.getOrderTotal(),2);
			textBoxOH_Tax1Total.Text = NumberUtil.toString(order.getTax1Total(),2);
			textBoxOH_Tax2Total.Text = NumberUtil.toString(order.getTax2Total(),2);
			textBoxOH_Tax3Total.Text = NumberUtil.toString(order.getTax3Total(),2);
			textBoxOH_DiscountTot.Text = NumberUtil.toString(order.getDiscountTot(),2);
			textBoxOH_CommissTot.Text = NumberUtil.toString(order.getCommissTot(),2);
			textBoxOH_RoyaltyTot.Text = NumberUtil.toString(order.getRoyaltyTot(),2);
		}

		private void loadBillTo ()
		{
			try
			{
				billToObj = coreFactory.readPerson(textBoxOH_Plant.Text,textBoxOH_BillToNum.Text);	
				if (billToObj != null)
					textBoxOH_BillToName.Text = billToObj.getName();
			}
			catch (Exception ex)
			{
				FormException frmEx = new FormException(ex);
				frmEx.ShowDialog(this);
			}
		}

		private void hasToBeDouble (TextBox textBox)
		{
			if (!textBox.Text.Equals(string.Empty) && !NumberUtil.isDoubleNumber(textBox.Text) && (!textBox.Text.Equals(".")) && (!textBox.Text.Equals(",")))
			{
				int pos = textBox.SelectionStart;
				if (pos == 0)
					textBox.Text = textBox.Text.Substring(1,textBox.Text.Length-1);
				else
				{
					string auxStr = textBox.Text;
					textBox.Text = auxStr.Substring (0,pos-1) + auxStr.Substring(pos,auxStr.Length-pos);
					textBox.SelectionStart = pos - 1;
					textBox.SelectionLength = 0;
				}
			}
			else
			{
				int pos = textBox.SelectionStart;
				int len = textBox.SelectionLength;
				for (int i=0; i<textBox.Text.Length; i++)
					if (textBox.Text[i].Equals(','))
						textBox.Text = textBox.Text.Substring(0,i) + "." + textBox.Text.Substring (i+1);
				if (pos >= 0)
					textBox.SelectionStart = pos;
				if (len >= 0)
					textBox.SelectionLength = len;
			}
		}
		
		private void loadGrid()
		{
			IEnumerator enu = order.getLineEnumerator();
			(((DataView)dataGridOrderItems.DataSource).Table).Clear();
			while (enu.MoveNext())
			{
				loadGrid((OrderDtl)enu.Current);
			}
		}

		private void loadGrid(OrderDtl orderDtl)
		{
			DataTable dt = ((DataView)dataGridOrderItems.DataSource).Table;
			DataRow dr = dt.NewRow();
			dr[0] = "";
			dr[1] = orderDtl.getItemNum().ToString();
			dr[2] = orderDtl.getProdDescription();
			dr[3] = NumberUtil.toString(orderDtl.getUnitPrice(),2);
			dr[4] = NumberUtil.toString(orderDtl.getQtyOrdSum(),2);
			dr[5] = "";
			dr[6] = NumberUtil.toString(orderDtl.getItemNetTotal(),2);
			dr[7] = NumberUtil.toString(orderDtl.getItemNetTotal() - orderDtl.getTotalDiscounts(),2);
			dt.Rows.Add(dr);
		}

		private void addItem ()
		{
			try
			{
				if (billToObj != null)
				{
					this.screenToObject();
					FormOrderDtl frm = new FormOrderDtl(order, billToObj);
					frm.Text = "Add New Order Detail";
					frm.ShowDialog(this);
		
					if ((frm.DialogResult == DialogResult.OK) && (frm.orderDtl != null))
					{
						buttonSearchBillTo.Enabled = false;
						rdoRetail.Enabled = false;
						rdoRhubarb.Enabled = false;
						order.addNewLine (frm.orderDtl);
						order.recalculate();
						this.loadGrid(frm.orderDtl);
						objectToScreen();
					}
				}
				else
					MessageBox.Show ("A bill to customer must be settled first", "No Bill to Customer", MessageBoxButtons.OK,MessageBoxIcon.Stop);
			}
			catch (Exception ex)
			{
				FormException frmEx = new FormException (ex);
				frmEx.ShowDialog(this);
			}
		}

		private void editItem()
		{
			try
			{
				if (dataGridOrderItems.CurrentRowIndex > -1)
				{
					this.screenToObject();
					FormOrderDtl frm = new FormOrderDtl(order,billToObj);
					string orderDtlItemNumStr = (string)dataGridOrderItems[dataGridOrderItems.CurrentRowIndex,0];
					frm.orderDtl = order.getLineByID(int.Parse(orderDtlItemNumStr));
					frm.Text = "Edit Order Detail";

					frm.ShowDialog(this);
					order.recalculate();
					this.loadGrid();
					objectToScreen();
				}
			}
			catch (Exception ex)
			{
				FormException frmEx = new FormException (ex);
				frmEx.ShowDialog(this);
			}
		}

		private void removeItem()
		{
			if (dataGridOrderItems.CurrentRowIndex >= 0)
			{
				if (MessageBox.Show("This will remove the detail line." + "\n" + "Do you wish to proceed?","Warning!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					this.screenToObject();
					string orderDtlItemNumStr = (string)dataGridOrderItems[dataGridOrderItems.CurrentRowIndex,0];
					order.removeLineByID(int.Parse(orderDtlItemNumStr));
					order.recalculate();
					this.loadGrid();
					if (order.getCountLines() == 0)
					{
						buttonSearchBillTo.Enabled = true;
						rdoRetail.Enabled = true;
						rdoRhubarb.Enabled = true;
					}
					objectToScreen();
				}
			}
		}

		private void setColumnWidths ()
		{
			dataGridOrderItems.TableStyles[0].GridColumnStyles[0].Width = (int)Math.Floor((dataGridOrderItems.Size.Width - dataGridOrderItems.RowHeaderWidth) * 0.14);
			dataGridOrderItems.TableStyles[0].GridColumnStyles[1].Width = (int)Math.Floor((dataGridOrderItems.Size.Width - dataGridOrderItems.RowHeaderWidth) * 0.28);
			dataGridOrderItems.TableStyles[0].GridColumnStyles[2].Width = (int)Math.Floor((dataGridOrderItems.Size.Width - dataGridOrderItems.RowHeaderWidth) * 0.14);
			dataGridOrderItems.TableStyles[0].GridColumnStyles[3].Width = (int)Math.Floor((dataGridOrderItems.Size.Width - dataGridOrderItems.RowHeaderWidth) * 0.14);
			dataGridOrderItems.TableStyles[0].GridColumnStyles[4].Width = (int)Math.Floor((dataGridOrderItems.Size.Width - dataGridOrderItems.RowHeaderWidth) * 0.14);

			int widthLast = dataGridOrderItems.Size.Width - dataGridOrderItems.RowHeaderWidth;
			for (int i=0; i < 5; i++)
				widthLast -= dataGridOrderItems.TableStyles[0].GridColumnStyles[i].Width;
			dataGridOrderItems.TableStyles[0].GridColumnStyles[5].Width = widthLast - 4;
		}

		private void addDiscount()
		{
			try
			{
				FormDiscounts frm = new FormDiscounts();
				frm.ShowDialog (this);

				if ((frm.DialogResult == DialogResult.OK) && (frm.orderDtlCharge != null))
				{
					IEnumerator enu = order.getLineEnumerator();
					while (enu.MoveNext())
					{
						if (!((OrderDtl)enu.Current).hasDtlCharge(frm.orderDtlCharge.getChargeCode()))
							((OrderDtl)enu.Current).addNewDtlCharge(frm.orderDtlCharge.clone());
					}
					order.recalculate();
					objectToScreen();
					this.loadGrid();
				}
			}
			catch (Exception ex)
			{
				FormException frmEx = new FormException (ex);
				frmEx.ShowDialog(this);
			}
		}

		private void addDiscountGroup()
		{
			try
			{
				FormGroupDiscounts frm = new FormGroupDiscounts();
				frm.ShowDialog (this);

				if (frm.DialogResult == DialogResult.OK)
				{
					IEnumerator enuRel = order.getLineEnumerator();
					while (enuRel.MoveNext())
					{
						IEnumerator enuCharges = frm.getChargesEnumerator();
						while (enuCharges.MoveNext())
						{
							OrderDtl orderDtl = (OrderDtl)enuRel.Current;
							if (!orderDtl.hasDtlCharge(((OrderDtlCharge)enuCharges.Current).getChargeCode()))
								orderDtl.addNewDtlCharge (((OrderDtlCharge)enuCharges.Current).clone());
						}
					}
					order.recalculate();
					objectToScreen();
					this.loadGrid();
				}
			}
			catch (Exception ex)
			{
				FormException frmEx = new FormException (ex);
				frmEx.ShowDialog(this);
			}
		}
		#endregion Methods

		#region Events
		private void FormAddNewOrder_Load(object sender, System.EventArgs e)
		{
			InitiaControls();
			InitialDataGrid();
			order = new Order();
			this.tabControlOrder.TabPages.RemoveAt(13);//remove the trash page
		}


		private void buttonSaveOrder_Click(object sender, System.EventArgs e)
		{
			if (billToObj != null)
			{
				try 
				{
					this.screenToObject();
					if (order.getCountLines() == 0)
						MessageBox.Show("The order has no details.","Can't save...",MessageBoxButtons.OK,MessageBoxIcon.Stop);
					else
					{
						if (MessageBox.Show("The order entry will be saved." + "\n" + "Are you sure?","Save order...",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
						{
							coreFactory.writeCompleteOrder(order);
							this.Close();
						}
					}
				}
				catch (Exception ex)
				{
					FormException frmEx = new FormException(ex);
					frmEx.ShowDialog(this);
				}
			}
			else
				MessageBox.Show ("A bill to customer must be settled first", "No Bill to Customer", MessageBoxButtons.OK,MessageBoxIcon.Stop);
		}

		private void buttonAddItem_Click(object sender, System.EventArgs e)
		{
			this.addItem();
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("All changes will be lost." + "\n" + "Are you sure?","Warning!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
				this.Close();
		}

		private void buttonEditItem_Click(object sender, System.EventArgs e)
		{
			this.editItem();
		}

		private void buttonSearchBillTo_Click(object sender, System.EventArgs e)
		{
			PersonSearchForm personSearchForm = new PersonSearchForm("Persons ...");
			personSearchForm.setFilter(Constants.PERSON_TYPE_CUSTOMER);
			personSearchForm.ShowDialog();
	
			if ((personSearchForm.DialogResult == DialogResult.OK) &&
				(personSearchForm.getSelected() != null))
			{
				textBoxOH_BillToNum.Text = personSearchForm.getSelected()[1];
				this.loadBillTo();
			}
		}

		private void textBoxOH_ComPercent_TextChanged(object sender, System.EventArgs e)
		{
			this.hasToBeDouble(textBoxOH_ComPercent);
		}

		private void textBoxOH_ComRate_TextChanged(object sender, System.EventArgs e)
		{
			this.hasToBeDouble(textBoxOH_ComRate);
		}

		private void buttonRemoveItem_Click(object sender, System.EventArgs e)
		{
			this.removeItem();
		}

		private void checkBoxOH_DateRequest_CheckedChanged(object sender, System.EventArgs e)
		{
			dateTimePickerOH_DateRequest.Enabled = checkBoxOH_DateRequest.Checked;
		}

		private void checkBoxOH_DatePromise_CheckedChanged(object sender, System.EventArgs e)
		{
			dateTimePickerOH_DatePromise.Enabled = checkBoxOH_DatePromise.Checked;
		}

		private void dataGridOrderItems_DoubleClick(object sender, EventArgs e)
		{
			System.Windows.Forms.DataGrid.HitTestInfo hti = dataGridOrderItems.HitTest(dataGridOrderItems.PointToClient(MousePosition)); 
			if (hti.Type == DataGrid.HitTestType.RowHeader)
				this.editItem();
		}

		private void dataGridOrderItems_MouseUp(object sender, MouseEventArgs e)
		{
			System.Windows.Forms.DataGrid.HitTestInfo hti = dataGridOrderItems.HitTest(new Point(e.X, e.Y)); 
			if ((e.Button == MouseButtons.Right) && ((hti.Type == DataGrid.HitTestType.RowHeader) || (hti.Type == DataGrid.HitTestType.Cell)))
			{
				dataGridOrderItems.UnSelect(dataGridOrderItems.CurrentRowIndex);
				menuItemEditItem.Enabled = true;
				menuItemRemoveItem.Enabled = true;
				dataGridOrderItems.CurrentRowIndex = hti.Row;
				dataGridOrderItems.Select(hti.Row);
				contextMenuOrdersDtls.Show(dataGridOrderItems,new Point(e.X,e.Y));
			}
			else if (e.Button == MouseButtons.Right)
			{
				menuItemEditItem.Enabled = false;
				menuItemRemoveItem.Enabled = false;
				contextMenuOrdersDtls.Show(dataGridOrderItems,new Point(e.X,e.Y));
			}
		}

		private void menuItemAddItem_Click(object sender, System.EventArgs e)
		{
			this.addItem();
		}

		private void menuItemEditItem_Click(object sender, System.EventArgs e)
		{
			this.editItem();
		}

		private void menuItemRemoveItem_Click(object sender, System.EventArgs e)
		{
			this.removeItem();
		}

		private void buttonSearchEmployee_Click(object sender, System.EventArgs e)
		{
			EmployeeSearchForm employeeSearchForm = new EmployeeSearchForm("Employees ...",coreFactory);
			employeeSearchForm.ShowDialog();
	
			if ((employeeSearchForm.DialogResult == DialogResult.OK) &&
				(employeeSearchForm.getSelected() != null))
			{
				try 
				{
					Employee emp = coreFactory.readEmployee(employeeSearchForm.getSelected()[0]);
					FormConfirmEmployee frm = new FormConfirmEmployee(emp);
					frm.ShowDialog(this);
					if (frm.DialogResult == DialogResult.OK)
					{
						textBoxOH_SalesPerson.Text = emp.getId();
						textBoxEmployeeName.Text = emp.getLastName() + ", " + emp.getFirstName();
					}
				}
				catch (Exception ex)
				{
					FormException frmEx = new FormException(ex);
					frmEx.ShowDialog(this);
				}
			}
		}

		private void dataGridOrderItems_Paint(object sender, PaintEventArgs e)
		{
			setColumnWidths();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.addDiscount();
		}

		private void buttonAddDiscGroup_Click(object sender, System.EventArgs e)
		{
			this.addDiscountGroup();
		}
		#endregion

		private void buttonOH_Note_Click(object sender, System.EventArgs e)
		{
			addNote();
		}

		private void addNote()
		{
			FormOrderNote formNote = new FormOrderNote(order);

			formNote.ShowDialog();
			if (formNote.DialogResult == DialogResult.OK)
				order = formNote.getOrder();				
								
			if (order.getCountNotes() > 0)
				this.checkBoxOH_Note.Checked = true;
			else
				this.checkBoxOH_Note.Checked = false;
		}


     
     
private void loadGridContact(){
 
    try{   
        dataTable = new DataTable();
        DataSet listDataSet = new DataSet();	
        string tableName = "invocieContact";
        string[][] vecNames = loadColumnsNamesContact();
        Grid.addColumns(vecNames,tableName,dataTable,this.dgridContact);
        
        //se deberia cargar la info del invoice si es un invoice que existe.
          
    }catch(NujitException ne){
        
	    FormException formException = new FormException(ne);
	    formException.ShowDialog();
    }        

}

private string[][] loadColumnsNamesContact(){
string[][] vec = new String[6][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
		     case "0":
				v[0]="Item #";
				v[1] = "70";
				break;
		    case "1":
				v[0]="Date Time";
				v[1] = "90";
				break;
			case "2":
				v[0]="Contact Name";
				v[1] = "180";
				break;
            case "3":
				v[0]="Phone";
				v[1] = "90";
				break;
            case "4":
				v[0]="Type";
				v[1] = "90";
				break;
            case "5":
				v[0]="Conversation Des.";
				v[1] = "205";
				break;	
		}
		
		vec[i]=v;
		i++;	
	}
	return vec;
}

private void tabControlOrder_SelectedIndexChanged(object sender, System.EventArgs e){

   loadTabPage(tabControlOrder.SelectedTab);

}     

private void loadTabPage(TabPage tabPage){
  
  	switch (tabPage.Name){
				case "tabPageContact":
				    this.loadGridContact();
				    break;
				 case "tabPageCom":
				    loadGridComponents();
				    break;  
				 case "tabPageItems":
				    loadGridItems();
				    break; 
				 case "tabPageMaterials":
		            loadGridMaterials();
		            break;
		         case "tabPageDiscounts":
		            loadGridDiscounts();
		            break;
		         case "tabPageFreigth":
		            loadTreeView();
		            break;
    }   
}		

     
private void loadGridComponents(){
 
    try{   
        dataTable = new DataTable();
        DataSet listDataSet = new DataSet();	
        string tableName = "invocieComp";
        string[][] vecNames = loadColumnsNamesComp();
        Grid.addColumns(vecNames,tableName,dataTable,this.dGridComponents);
        
        //se deberia cargar la info del invoice si es un invoice que existe.
          
    }catch(NujitException ne){
        
	    FormException formException = new FormException(ne);
	    formException.ShowDialog();
    }        

}

private string[][] loadColumnsNamesComp(){
string[][] vec = new String[9][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
		     case "0":
				v[0]="Item #";
				v[1] = "50";
				break;
		    case "1":
				v[0]="Parent";
				v[1] = "90";
				break;
			case "2":
				v[0]="Part";
				v[1] = "90";
				break;
            case "3":
				v[0]="Description";
				v[1] = "150";
				break;
            case "4":
				v[0]="Qty";
				v[1] = "70";
				break;	
            case "5":
				v[0]="Qty Uom";
				v[1] = "70";
				break;		
            case "6":
				v[0]="Price";
				v[1] = "80";
				break;
            case "7":
				v[0]="Net Total";
				v[1] = "80";
				break;		
            case "8":
				v[0]="Ship Date";
				v[1] = "80";
				break;	
		}
		
		vec[i]=v;
		i++;	
	}
	return vec;
}

private void loadGridItems(){
 
    try{   
        dataTable = new DataTable();
        DataSet listDataSet = new DataSet();	
        string tableName = "psItems";
        string[][] vecNames = loadColumnsNamesItems();
        Grid.addColumns(vecNames,tableName,dataTable,dGridItems);
        
        //se deberia cargar la info del invoice si es un invoice que existe.
          
    }catch(NujitException ne){
        
	    FormException formException = new FormException(ne);
	    formException.ShowDialog();
    }        

}

private string[][] loadColumnsNamesItems(){
string[][] vec = new String[10][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
		    case "0":
				v[0]="Part";
				v[1] = "80";
				break;
			case "1":
				v[0]="Supp. Part";
				v[1] = "90";
				break;
            case "2":
				v[0]="Description";
				v[1] = "80";
				break;
            case "3":
				v[0]="Qty";
				v[1] = "70";
				break;	
            case "4":
				v[0]="Qty Uom";
				v[1] = "80";
				break;		
            case "5":
				v[0]="InvSts";
				v[1] = "80";
				break;		
            case "6":
				v[0]="Ship Date";
				v[1] = "80";
				break;	
            case "7":
				v[0]="Order";
				v[1] = "60";
				break;	
            case "8":
				v[0]="GM%";
				v[1] = "65";
				break;	
            case "9":
				v[0]="Total";
				v[1] = "80";
				break;											
		}
		
		vec[i]=v;
		i++;	
	}
	return vec;
}



private void loadGridMaterials(){
 
    try{   
        dataTable = new DataTable();
        DataSet listDataSet = new DataSet();	
        string tableName = "psMaterials";
        string[][] vecNames = loadColumnsNamesMaterials();
        Grid.addColumns(vecNames,tableName,dataTable,this.dGtidMaterials);
        
        //se deberia cargar la info del invoice si es un invoice que existe.
          
    }catch(NujitException ne){
        
	    FormException formException = new FormException(ne);
	    formException.ShowDialog();
    }        

}

private string[][] loadColumnsNamesMaterials(){
string[][] vec = new String[10][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
		     case "0":
				v[0]="Item #";
				v[1] = "50";
				break;
		    case "1":
				v[0]="Part";
				v[1] = "80";
				break;
			case "2":
				v[0]="Parent";
				v[1] = "90";
				break;
            case "3":
				v[0]="Description";
				v[1] = "80";
				break;
            case "4":
				v[0]="Date Recived";
				v[1] = "80";
				break;	
            case "5":
				v[0]="Qty";
				v[1] = "70";
				break;	
            case "6":
				v[0]="Qty Uom";
				v[1] = "80";
				break;
            case "7":
				v[0]="Cost";
				v[1] = "80";
				break;						
            case "8":
				v[0]="Net Total";
				v[1] = "80";
				break;		
            case "9":
				v[0]="Total";
				v[1] = "85";
				break;											
		}
		
		vec[i]=v;
		i++;	
	}
	return vec;
}

private void buttonAddDiscGroup_Click_2(object sender, System.EventArgs e){
    this.addDiscountGroup();
}

private void buttonAddDiscount_Click_1(object sender, System.EventArgs e){

    this.addDiscount();
}

private void btnShipFrom_Click(object sender, System.EventArgs e){

    ShipFromForm shipFromForm= new ShipFromForm();
    shipFromForm.ShowDialog();
}

private void button3_Click(object sender, System.EventArgs e){

		PersonSearchForm personSearchForm = new PersonSearchForm("Persons ...");
		personSearchForm.setFilter(Constants.PERSON_TYPE_CUSTOMER);
		personSearchForm.ShowDialog();

		if ((personSearchForm.DialogResult == DialogResult.OK) &&
			(personSearchForm.getSelected() != null))	{
			textBox2.Text = personSearchForm.getSelected()[1];
			
		}
}

private void loadGridDiscounts(){
 
    try{   
        dataTable = new DataTable();
        DataSet listDataSet = new DataSet();	
        string tableName = "invocieDtlDiscounts";
        string[][] vecNames = loadColumnsNamesDiscounts();
        Grid.addColumns(vecNames,tableName,dataTable,this.dGridDiscounts);
        
        //se deberia cargar la info del invoice si es un invoice que existe.
          
    }catch(NujitException ne){
        
	    FormException formException = new FormException(ne);
	    formException.ShowDialog();
    }        

}

private string[][] loadColumnsNamesDiscounts(){
string[][] vec = new String[7][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
            case "0":
				v[0]="Inv. Line #";
				v[1] = "90";
				break;
            case "1":
				v[0]="Overall Disc. %";
				v[1] = "90";
				break;
            case "2":
				v[0]="Discount Line";
				v[1] = "90";
				break;
            case "3":
				v[0]="Part#";
				v[1] = "100";
				break;
            case "4":
				v[0]="Discount Code";
				v[1] = "95";
				break;
            case "5":
				v[0]="Discount %";
				v[1] = "100";
				break;
            case "6":
				v[0]="Discount Amt";
				v[1] = "100";
				break;
    
		}
		vec[i]=v;
		i++;	
	}
	return vec;
}

private void btnAddItem_Click(object sender, System.EventArgs e){

    FormOrderDtl formOrderDtl= new FormOrderDtl(this.order,null,""); //See to pass the correct arguments 
    formOrderDtl.ShowDialog();
}

private void button7_Click(object sender, System.EventArgs e){
    FormOrderDtl formOrderDtl= new FormOrderDtl(this.order,null,"");//See to pass the correct arguments 
    formOrderDtl.ShowDialog();
}



private void loadTreeView(){
 
    TreeNode root = new TreeNode("Freigth");
    root.Tag = rootLevel +";"+rootLevel;
    this.treeViewInfo.Nodes.Add(root);
    //------------------------------
    //All that is charge is example we have to chenge for the correct infomrmation
    //that camces from PackSlip tables    
    for(int i=0; i< 3;i++){
        TreeNode currentLayer1 = new TreeNode("Layer1 <Skids>: "+i.ToString());
        currentLayer1.Tag = this.layer1 ;
        root.Nodes.Add(currentLayer1);
        for (int j=1; j<2; j++) {
            TreeNode currentLayer2 = new TreeNode("Layer2 <Boxes>:" + j.ToString());
            currentLayer2.Tag = this.layer2 ;
            currentLayer1.Nodes.Add(currentLayer2);
            
            for(int k=0; k<1;k++){
                TreeNode currentLayer3 = new TreeNode("Layer3 <Cartons> :" + k.ToString());
                currentLayer3.Tag = this.layer3;
                currentLayer2.Nodes.Add(currentLayer3);
                
                for(int m=0; m<1;m++){
                    TreeNode currentLayer4 = new TreeNode("Layer4 <Part>:" + m.ToString());
                    currentLayer4.Tag = this.layer4;
                    currentLayer3.Nodes.Add(currentLayer4);
                    
                }
                
            }
        }
    }    
    
    //-----------------------------------
}

private void setInformation(string selectedNode){

    string[]  vecTag = selectedNode.Split(';'); //pos 0 : Level
    string tag = vecTag[0];
    
    switch (tag)	{
        case ("ROOT"):
                break;
	    case ("LAYER1"):
		        showView1();
		        break;
	    case ("LAYER2"):
		        showView2();
		        break;
	     case ("LAYER3"):
		        showView3();
		        break;
	
       }
}

private void showView1(){

    dataTable = new DataTable();
    DataSet listDataSet = new DataSet();	
    string tableName = "View1";
    string[][] vecNames = loadColumnView1();
    Grid.addColumns(vecNames,tableName,dataTable,this.dGridShowDetail);
    dGridShowDetail.CaptionText = "Layer 1";    
}

private string[][] loadColumnView1(){
string[][] vec = new String[11][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
		     case "0":
				v[0]="Pack Line";
				v[1] = "60";
				break;
		    case "1":
				v[0]="Skid Serial#";
				v[1] = "60";
				break;
			case "2":
				v[0]="PackType";
				v[1] = "60";
				break;
            case "3":
				v[0]="Skid Type";
				v[1] = "60";
				break;
            case "4":
				v[0]="Part";
				v[1] = "60";
				break;
            case "5":
				v[0]="Supp. Part";
				v[1] = "60";
				break;	
		    case "6":
				v[0]="Qty";
				v[1] = "60";
				break;	
            case "7":
				v[0]="Weight";
				v[1] = "60";
				break;	
		    case "8":
		    	v[0]="Uom";
				v[1] = "60";
				break;	
		    case "9":
				v[0]="Volume";
				v[1] = "60";
				break;	
		    case "10":
				v[0]="Vol Uom";
				v[1] = "60";
				break;	
		}
		
		vec[i]=v;
		i++;	
	}
	return vec;
}

private void showView2(){

    dataTable = new DataTable();
    DataSet listDataSet = new DataSet();	
    string tableName = "View2";
    string[][] vecNames = loadColumnView2();
    Grid.addColumns(vecNames,tableName,dataTable,this.dGridShowDetail);
    dGridShowDetail.CaptionText = "Layer 2";
}



private string[][] loadColumnView2(){
string[][] vec = new String[11][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
		     case "0":
				v[0]="Pack Line";
				v[1] = "60";
				break;
		    case "1":
				v[0]="Skid Serial#";
				v[1] = "60";
				break;
			case "2":
				v[0]="Box Serial#";
				v[1] = "60";
				break;
            case "3":
				v[0]="Pack Type";
				v[1] = "60";
				break;
            case "4":
				v[0]="Part";
				v[1] = "60";
				break;
            case "5":
				v[0]="Supp. Part";
				v[1] = "60";
				break;	
		    case "6":
				v[0]="Qty";
				v[1] = "60";
				break;	
            case "7":
				v[0]="Weight";
				v[1] = "60";
				break;	
		    case "8":
		    	v[0]="Uom";
				v[1] = "60";
				break;	
		    case "9":
				v[0]="Volume";
				v[1] = "60";
				break;	
		    case "10":
				v[0]="Vol Uom";
				v[1] = "60";
				break;	
		}
		
		vec[i]=v;
		i++;	
	}
	return vec;
}

private void showView3(){

    dataTable = new DataTable();
    DataSet listDataSet = new DataSet();	
    string tableName = "View3";
    string[][] vecNames = loadColumnView3();
    Grid.addColumns(vecNames,tableName,dataTable,this.dGridShowDetail);
    dGridShowDetail.CaptionText = "Layer 3";

}


private string[][] loadColumnView3(){
string[][] vec = new String[11][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
		     case "0":
				v[0]="Pack Line";
				v[1] = "60";
				break;
		    case "1":
				v[0]="Skid Serial #";
				v[1] = "60";
				break;
			case "2":
				v[0]="Box Serial#";
				v[1] = "60";
				break;
            case "3":
				v[0]="Case Serial";
				v[1] = "60";
				break;
            case "4":
				v[0]="Part";
				v[1] = "60";
				break;
            case "5":
				v[0]="Supp. Part";
				v[1] = "60";
				break;	
		    case "6":
				v[0]="Qty";
				v[1] = "60";
				break;	
            case "7":
				v[0]="Weight";
				v[1] = "60";
				break;	
		    case "8":
		    	v[0]="Uom";
				v[1] = "60";
				break;	
		    case "9":
				v[0]="Volume";
				v[1] = "60";
				break;	
		    case "10":
				v[0]="Vol Uom";
				v[1] = "60";
				break;	
		}
		
		vec[i]=v;
		i++;	
	}
	return vec;
}

private void treeViewInfo_Click_1(object sender, System.EventArgs e){
try{
 
    string selectedNode = treeViewInfo.SelectedNode.Tag.ToString();
    setInformation(selectedNode);
 
  }catch{
    return;
  }
}
              

       

} // Class
} // NameSpace
