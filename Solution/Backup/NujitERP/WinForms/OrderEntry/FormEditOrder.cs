
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;

using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;

using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.WinForms.Master;
using Nujit.NujitERP.WinForms.SearchForms;


namespace Nujit.NujitERP.WinForms.Orders
{
	/// <summary>
	/// Summary description for FormAddNewOrder.
	/// </summary>
	public class FormEditOrder : System.Windows.Forms.Form
	{

		#region Controls

		private System.Windows.Forms.GroupBox groupBoxDate;
		private System.Windows.Forms.TextBox textBoxOH_Tax3Total;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label labelOH_OrderNum;
		private System.Windows.Forms.Label labelOH_Company;
		private System.Windows.Forms.Label labelOH_Plant;
		private System.Windows.Forms.TextBox textBoxOH_DistributionLoc;
		private System.Windows.Forms.Label labelOH_BillToNum;
		private System.Windows.Forms.TextBox textBoxOH_OrderNum;
		private System.Windows.Forms.TextBox textBoxOH_BillToNum;
		private System.Windows.Forms.TextBox textBoxOH_PO;
		private System.Windows.Forms.TextBox textBoxOH_ShipVia;
		private System.Windows.Forms.TextBox textBoxOH_Terms;
		private System.Windows.Forms.Label labelOH_PO;
		private System.Windows.Forms.Label labelOH_ShipVia;
		private System.Windows.Forms.Label labelOH_Terms;
		private System.Windows.Forms.TextBox textBoxOH_Currency;
		private System.Windows.Forms.TextBox textBoxOH_ComPercent;
		private System.Windows.Forms.TextBox textBoxOH_SalesPerson;
		private System.Windows.Forms.Label labelOH_Currency;
		private System.Windows.Forms.Label labelOH_ComPercent;
		private System.Windows.Forms.TextBox textBoxOH_ComRate;
		private System.Windows.Forms.Label labelOH_ComRate;
		private System.Windows.Forms.TextBox textBoxOH_OrderTotal;
		private System.Windows.Forms.Label labelOH_OrderTotal;
		private System.Windows.Forms.TextBox textBoxOH_Territory;
		private System.Windows.Forms.TextBox textBoxOH_HoldStatus;
		private System.Windows.Forms.Label labelOH_Territory;
		private System.Windows.Forms.Label labelOH_HoldStatus;
		private System.Windows.Forms.TextBox textBoxOH_Tax1Total;
		private System.Windows.Forms.Label labelOH_Tax1Total;
		private System.Windows.Forms.TextBox textBoxOH_OrderNet;
		private System.Windows.Forms.Label labelOH_OrderNet;
		private System.Windows.Forms.Label labelOH_Tax3Total;
		private System.Windows.Forms.TextBox textBoxOH_Tax2Total;
		private System.Windows.Forms.Label labeOH_Tax2Total;
		private System.Windows.Forms.TextBox textBoxOH_DiscountTot;
		private System.Windows.Forms.Label labelOH_DiscountTot;
		private System.Windows.Forms.TextBox textBoxOH_CommissTot;
		private System.Windows.Forms.Label labelOH_CommissTot;
		private System.Windows.Forms.TextBox textBoxOH_RoyaltyTot;
		private System.Windows.Forms.Label labelOH_RoyaltyTot;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label labelOH_OrderDate;
		private System.Windows.Forms.Panel panelOrdrHdrInfo;
		private System.Windows.Forms.Button buttonSaveOrder;
		private System.Windows.Forms.Button buttonAddItem;
		private System.Windows.Forms.Button buttonEditItem;
		private System.Windows.Forms.TextBox textBoxOH_Company;
		private System.Windows.Forms.TextBox textBoxOH_Plant;
		private System.Windows.Forms.DateTimePicker dateTimePickerOH_DatePromise;
		private System.Windows.Forms.DateTimePicker dateTimePickerOH_DateRequest;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TextBox textBoxOH_OrderDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxOH_BillToName;
		private System.Windows.Forms.DataGrid dataGridOrderItems;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button buttonRemoveItem;
		private System.Windows.Forms.CheckBox checkBoxOH_DateRequest;
		private System.Windows.Forms.CheckBox checkBoxOH_DatePromise;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dateTimePickerOH_DateShip;
		private System.Windows.Forms.DateTimePicker dateTimePickerOH_DateCancel;
		private System.Windows.Forms.DateTimePicker dateTimePickerOH_ProdDate;
		private System.Windows.Forms.CheckBox checkBoxOH_ProdDate;
		private System.Windows.Forms.CheckBox checkBoxOH_DateCancel;
		private System.Windows.Forms.CheckBox checkBoxOH_DateShip;
		private System.Windows.Forms.TextBox textBoxOH_OrderType;
		private System.Windows.Forms.Label labelConfirmed;
		private System.Windows.Forms.Button buttonAction;
		private System.Windows.Forms.TextBox textBoxOH_DateConfirmed;
		private System.Windows.Forms.ContextMenu contextMenuOrderDtls;
		private System.Windows.Forms.MenuItem menuItemAddItem;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItemEditItem;
		private System.Windows.Forms.MenuItem menuItemRemoveItem;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button buttonSearchEmployee;
		private System.Windows.Forms.TextBox textBoxEmployeeName;
		private System.Windows.Forms.Label labelEmployeeName;
		private System.Windows.Forms.Label labelOH_SalesPerson;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion Control Vars

		private Order order;
		private Person billToObj;
		private System.Windows.Forms.Label labelOH_RetailProductType;
		private System.Windows.Forms.TextBox textBoxOH_RetailProductType;
		private System.Windows.Forms.Button buttonAddDiscGroup;
		private System.Windows.Forms.Button buttonAddDiscount;
		private System.Windows.Forms.CheckBox checkBoxOH_Note;
		private System.Windows.Forms.Button buttonOH_Note;
		private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControlOrder;
        private System.Windows.Forms.TabPage tabPageShip;
        private System.Windows.Forms.TabPage tabPageMaterials;
        private System.Windows.Forms.TabPage tabPageCom;
        private System.Windows.Forms.TabPage tabPageDistribution;
        private System.Windows.Forms.TabPage tabPageDoc;
        private System.Windows.Forms.TabPage tabPageContact;
		private CoreFactory coreFactory;
	
		#region Contructors
		public FormEditOrder(Order anOrder)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();


			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			coreFactory = UtilCoreFactory.createCoreFactory();
			MyInitialize(anOrder);
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
            this.label5 = new System.Windows.Forms.Label();
            this.labelOH_Company = new System.Windows.Forms.Label();
            this.labelOH_Plant = new System.Windows.Forms.Label();
            this.textBoxOH_OrderNum = new System.Windows.Forms.TextBox();
            this.textBoxOH_DistributionLoc = new System.Windows.Forms.TextBox();
            this.textBoxOH_Company = new System.Windows.Forms.TextBox();
            this.textBoxOH_Plant = new System.Windows.Forms.TextBox();
            this.textBoxOH_BillToNum = new System.Windows.Forms.TextBox();
            this.labelOH_BillToNum = new System.Windows.Forms.Label();
            this.textBoxOH_PO = new System.Windows.Forms.TextBox();
            this.textBoxOH_ShipVia = new System.Windows.Forms.TextBox();
            this.textBoxOH_Terms = new System.Windows.Forms.TextBox();
            this.labelOH_PO = new System.Windows.Forms.Label();
            this.labelOH_ShipVia = new System.Windows.Forms.Label();
            this.labelOH_Terms = new System.Windows.Forms.Label();
            this.textBoxOH_Currency = new System.Windows.Forms.TextBox();
            this.textBoxOH_ComPercent = new System.Windows.Forms.TextBox();
            this.textBoxOH_SalesPerson = new System.Windows.Forms.TextBox();
            this.labelOH_Currency = new System.Windows.Forms.Label();
            this.labelOH_ComPercent = new System.Windows.Forms.Label();
            this.textBoxOH_ComRate = new System.Windows.Forms.TextBox();
            this.labelOH_ComRate = new System.Windows.Forms.Label();
            this.textBoxOH_OrderTotal = new System.Windows.Forms.TextBox();
            this.labelOH_OrderTotal = new System.Windows.Forms.Label();
            this.textBoxOH_Territory = new System.Windows.Forms.TextBox();
            this.textBoxOH_HoldStatus = new System.Windows.Forms.TextBox();
            this.labelOH_Territory = new System.Windows.Forms.Label();
            this.labelOH_HoldStatus = new System.Windows.Forms.Label();
            this.textBoxOH_Tax1Total = new System.Windows.Forms.TextBox();
            this.labelOH_Tax1Total = new System.Windows.Forms.Label();
            this.textBoxOH_OrderNet = new System.Windows.Forms.TextBox();
            this.labelOH_OrderNet = new System.Windows.Forms.Label();
            this.textBoxOH_DiscountTot = new System.Windows.Forms.TextBox();
            this.labelOH_DiscountTot = new System.Windows.Forms.Label();
            this.textBoxOH_Tax3Total = new System.Windows.Forms.TextBox();
            this.labelOH_Tax3Total = new System.Windows.Forms.Label();
            this.textBoxOH_Tax2Total = new System.Windows.Forms.TextBox();
            this.labeOH_Tax2Total = new System.Windows.Forms.Label();
            this.textBoxOH_CommissTot = new System.Windows.Forms.TextBox();
            this.labelOH_CommissTot = new System.Windows.Forms.Label();
            this.textBoxOH_RoyaltyTot = new System.Windows.Forms.TextBox();
            this.labelOH_RoyaltyTot = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelOH_RetailProductType = new System.Windows.Forms.Label();
            this.textBoxOH_RetailProductType = new System.Windows.Forms.TextBox();
            this.textBoxOH_OrderType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxOH_Note = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonOH_Note = new System.Windows.Forms.Button();
            this.textBoxOH_OrderDate = new System.Windows.Forms.TextBox();
            this.labelOH_OrderDate = new System.Windows.Forms.Label();
            this.panelOrdrHdrInfo = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonSearchEmployee = new System.Windows.Forms.Button();
            this.textBoxEmployeeName = new System.Windows.Forms.TextBox();
            this.labelEmployeeName = new System.Windows.Forms.Label();
            this.labelOH_SalesPerson = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxOH_BillToName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxDate = new System.Windows.Forms.GroupBox();
            this.checkBoxOH_ProdDate = new System.Windows.Forms.CheckBox();
            this.dateTimePickerOH_ProdDate = new System.Windows.Forms.DateTimePicker();
            this.checkBoxOH_DateCancel = new System.Windows.Forms.CheckBox();
            this.dateTimePickerOH_DateCancel = new System.Windows.Forms.DateTimePicker();
            this.checkBoxOH_DateShip = new System.Windows.Forms.CheckBox();
            this.dateTimePickerOH_DateShip = new System.Windows.Forms.DateTimePicker();
            this.checkBoxOH_DatePromise = new System.Windows.Forms.CheckBox();
            this.checkBoxOH_DateRequest = new System.Windows.Forms.CheckBox();
            this.dateTimePickerOH_DatePromise = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerOH_DateRequest = new System.Windows.Forms.DateTimePicker();
            this.labelConfirmed = new System.Windows.Forms.Label();
            this.textBoxOH_DateConfirmed = new System.Windows.Forms.TextBox();
            this.buttonAction = new System.Windows.Forms.Button();
            this.buttonRemoveItem = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonEditItem = new System.Windows.Forms.Button();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.buttonSaveOrder = new System.Windows.Forms.Button();
            this.buttonAddDiscount = new System.Windows.Forms.Button();
            this.buttonAddDiscGroup = new System.Windows.Forms.Button();
            this.dataGridOrderItems = new System.Windows.Forms.DataGrid();
            this.contextMenuOrderDtls = new System.Windows.Forms.ContextMenu();
            this.menuItemAddItem = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItemEditItem = new System.Windows.Forms.MenuItem();
            this.menuItemRemoveItem = new System.Windows.Forms.MenuItem();
            this.tabControlOrder = new System.Windows.Forms.TabControl();
            this.tabPageShip = new System.Windows.Forms.TabPage();
            this.tabPageMaterials = new System.Windows.Forms.TabPage();
            this.tabPageCom = new System.Windows.Forms.TabPage();
            this.tabPageDistribution = new System.Windows.Forms.TabPage();
            this.tabPageDoc = new System.Windows.Forms.TabPage();
            this.tabPageContact = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelOrdrHdrInfo.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBoxDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderItems)).BeginInit();
            this.tabControlOrder.SuspendLayout();
            this.tabPageShip.SuspendLayout();
            this.tabPageMaterials.SuspendLayout();
            this.tabPageCom.SuspendLayout();
            this.tabPageContact.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelOH_OrderNum
            // 
            this.labelOH_OrderNum.Location = new System.Drawing.Point(8, 24);
            this.labelOH_OrderNum.Name = "labelOH_OrderNum";
            this.labelOH_OrderNum.Size = new System.Drawing.Size(72, 20);
            this.labelOH_OrderNum.TabIndex = 2;
            this.labelOH_OrderNum.Text = "Order No.";
            this.labelOH_OrderNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Distri. Loc.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOH_Company
            // 
            this.labelOH_Company.Location = new System.Drawing.Point(8, 48);
            this.labelOH_Company.Name = "labelOH_Company";
            this.labelOH_Company.Size = new System.Drawing.Size(56, 20);
            this.labelOH_Company.TabIndex = 8;
            this.labelOH_Company.Text = "Company";
            this.labelOH_Company.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOH_Plant
            // 
            this.labelOH_Plant.Location = new System.Drawing.Point(8, 72);
            this.labelOH_Plant.Name = "labelOH_Plant";
            this.labelOH_Plant.Size = new System.Drawing.Size(56, 20);
            this.labelOH_Plant.TabIndex = 12;
            this.labelOH_Plant.Text = "Plant";
            this.labelOH_Plant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_OrderNum
            // 
            this.textBoxOH_OrderNum.Location = new System.Drawing.Point(80, 24);
            this.textBoxOH_OrderNum.Name = "textBoxOH_OrderNum";
            this.textBoxOH_OrderNum.ReadOnly = true;
            this.textBoxOH_OrderNum.Size = new System.Drawing.Size(96, 20);
            this.textBoxOH_OrderNum.TabIndex = 5;
            this.textBoxOH_OrderNum.Text = "0";
            // 
            // textBoxOH_DistributionLoc
            // 
            this.textBoxOH_DistributionLoc.Location = new System.Drawing.Point(96, 176);
            this.textBoxOH_DistributionLoc.MaxLength = 20;
            this.textBoxOH_DistributionLoc.Name = "textBoxOH_DistributionLoc";
            this.textBoxOH_DistributionLoc.Size = new System.Drawing.Size(96, 20);
            this.textBoxOH_DistributionLoc.TabIndex = 70;
            this.textBoxOH_DistributionLoc.Text = "";
            // 
            // textBoxOH_Company
            // 
            this.textBoxOH_Company.Location = new System.Drawing.Point(80, 48);
            this.textBoxOH_Company.MaxLength = 10;
            this.textBoxOH_Company.Name = "textBoxOH_Company";
            this.textBoxOH_Company.Size = new System.Drawing.Size(96, 20);
            this.textBoxOH_Company.TabIndex = 15;
            this.textBoxOH_Company.Text = "";
            // 
            // textBoxOH_Plant
            // 
            this.textBoxOH_Plant.Location = new System.Drawing.Point(72, 72);
            this.textBoxOH_Plant.MaxLength = 10;
            this.textBoxOH_Plant.Name = "textBoxOH_Plant";
            this.textBoxOH_Plant.ReadOnly = true;
            this.textBoxOH_Plant.Size = new System.Drawing.Size(96, 20);
            this.textBoxOH_Plant.TabIndex = 20;
            this.textBoxOH_Plant.Text = "";
            // 
            // textBoxOH_BillToNum
            // 
            this.textBoxOH_BillToNum.Location = new System.Drawing.Point(72, 24);
            this.textBoxOH_BillToNum.MaxLength = 10;
            this.textBoxOH_BillToNum.Name = "textBoxOH_BillToNum";
            this.textBoxOH_BillToNum.ReadOnly = true;
            this.textBoxOH_BillToNum.Size = new System.Drawing.Size(96, 20);
            this.textBoxOH_BillToNum.TabIndex = 10;
            this.textBoxOH_BillToNum.Text = "";
            // 
            // labelOH_BillToNum
            // 
            this.labelOH_BillToNum.Location = new System.Drawing.Point(8, 24);
            this.labelOH_BillToNum.Name = "labelOH_BillToNum";
            this.labelOH_BillToNum.Size = new System.Drawing.Size(56, 20);
            this.labelOH_BillToNum.TabIndex = 23;
            this.labelOH_BillToNum.Text = "Bill To No.";
            this.labelOH_BillToNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_PO
            // 
            this.textBoxOH_PO.Location = new System.Drawing.Point(256, 24);
            this.textBoxOH_PO.MaxLength = 40;
            this.textBoxOH_PO.Name = "textBoxOH_PO";
            this.textBoxOH_PO.Size = new System.Drawing.Size(96, 20);
            this.textBoxOH_PO.TabIndex = 20;
            this.textBoxOH_PO.Text = "";
            // 
            // textBoxOH_ShipVia
            // 
            this.textBoxOH_ShipVia.Location = new System.Drawing.Point(416, 184);
            this.textBoxOH_ShipVia.MaxLength = 40;
            this.textBoxOH_ShipVia.Name = "textBoxOH_ShipVia";
            this.textBoxOH_ShipVia.Size = new System.Drawing.Size(96, 20);
            this.textBoxOH_ShipVia.TabIndex = 30;
            this.textBoxOH_ShipVia.Text = "";
            // 
            // textBoxOH_Terms
            // 
            this.textBoxOH_Terms.Location = new System.Drawing.Point(96, 128);
            this.textBoxOH_Terms.MaxLength = 10;
            this.textBoxOH_Terms.Name = "textBoxOH_Terms";
            this.textBoxOH_Terms.Size = new System.Drawing.Size(96, 20);
            this.textBoxOH_Terms.TabIndex = 50;
            this.textBoxOH_Terms.Text = "";
            // 
            // labelOH_PO
            // 
            this.labelOH_PO.Location = new System.Drawing.Point(192, 24);
            this.labelOH_PO.Name = "labelOH_PO";
            this.labelOH_PO.Size = new System.Drawing.Size(72, 20);
            this.labelOH_PO.TabIndex = 27;
            this.labelOH_PO.Text = "P.O.";
            this.labelOH_PO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOH_ShipVia
            // 
            this.labelOH_ShipVia.Location = new System.Drawing.Point(360, 184);
            this.labelOH_ShipVia.Name = "labelOH_ShipVia";
            this.labelOH_ShipVia.Size = new System.Drawing.Size(56, 20);
            this.labelOH_ShipVia.TabIndex = 26;
            this.labelOH_ShipVia.Text = "Ship Via";
            this.labelOH_ShipVia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOH_Terms
            // 
            this.labelOH_Terms.Location = new System.Drawing.Point(24, 128);
            this.labelOH_Terms.Name = "labelOH_Terms";
            this.labelOH_Terms.Size = new System.Drawing.Size(72, 20);
            this.labelOH_Terms.TabIndex = 25;
            this.labelOH_Terms.Text = "Terms";
            this.labelOH_Terms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_Currency
            // 
            this.textBoxOH_Currency.Location = new System.Drawing.Point(256, 48);
            this.textBoxOH_Currency.MaxLength = 5;
            this.textBoxOH_Currency.Name = "textBoxOH_Currency";
            this.textBoxOH_Currency.Size = new System.Drawing.Size(96, 20);
            this.textBoxOH_Currency.TabIndex = 25;
            this.textBoxOH_Currency.Text = "";
            // 
            // textBoxOH_ComPercent
            // 
            this.textBoxOH_ComPercent.Location = new System.Drawing.Point(352, 40);
            this.textBoxOH_ComPercent.MaxLength = 7;
            this.textBoxOH_ComPercent.Name = "textBoxOH_ComPercent";
            this.textBoxOH_ComPercent.TabIndex = 10;
            this.textBoxOH_ComPercent.Text = "";
            this.textBoxOH_ComPercent.TextChanged += new System.EventHandler(this.textBoxOH_ComPercent_TextChanged);
            // 
            // textBoxOH_SalesPerson
            // 
            this.textBoxOH_SalesPerson.Location = new System.Drawing.Point(80, 24);
            this.textBoxOH_SalesPerson.MaxLength = 20;
            this.textBoxOH_SalesPerson.Name = "textBoxOH_SalesPerson";
            this.textBoxOH_SalesPerson.ReadOnly = true;
            this.textBoxOH_SalesPerson.Size = new System.Drawing.Size(88, 20);
            this.textBoxOH_SalesPerson.TabIndex = 10;
            this.textBoxOH_SalesPerson.Text = "";
            // 
            // labelOH_Currency
            // 
            this.labelOH_Currency.Location = new System.Drawing.Point(192, 48);
            this.labelOH_Currency.Name = "labelOH_Currency";
            this.labelOH_Currency.Size = new System.Drawing.Size(56, 20);
            this.labelOH_Currency.TabIndex = 37;
            this.labelOH_Currency.Text = "Currency";
            this.labelOH_Currency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOH_ComPercent
            // 
            this.labelOH_ComPercent.Location = new System.Drawing.Point(272, 40);
            this.labelOH_ComPercent.Name = "labelOH_ComPercent";
            this.labelOH_ComPercent.Size = new System.Drawing.Size(72, 20);
            this.labelOH_ComPercent.TabIndex = 36;
            this.labelOH_ComPercent.Text = "Com.Percent";
            this.labelOH_ComPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_ComRate
            // 
            this.textBoxOH_ComRate.Location = new System.Drawing.Point(352, 64);
            this.textBoxOH_ComRate.MaxLength = 11;
            this.textBoxOH_ComRate.Name = "textBoxOH_ComRate";
            this.textBoxOH_ComRate.TabIndex = 15;
            this.textBoxOH_ComRate.Text = "";
            this.textBoxOH_ComRate.TextChanged += new System.EventHandler(this.textBoxOH_ComRate_TextChanged);
            // 
            // labelOH_ComRate
            // 
            this.labelOH_ComRate.Location = new System.Drawing.Point(272, 64);
            this.labelOH_ComRate.Name = "labelOH_ComRate";
            this.labelOH_ComRate.Size = new System.Drawing.Size(72, 20);
            this.labelOH_ComRate.TabIndex = 33;
            this.labelOH_ComRate.Text = "Com. Rate";
            this.labelOH_ComRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_OrderTotal
            // 
            this.textBoxOH_OrderTotal.Location = new System.Drawing.Point(80, 24);
            this.textBoxOH_OrderTotal.MaxLength = 10;
            this.textBoxOH_OrderTotal.Name = "textBoxOH_OrderTotal";
            this.textBoxOH_OrderTotal.ReadOnly = true;
            this.textBoxOH_OrderTotal.Size = new System.Drawing.Size(88, 20);
            this.textBoxOH_OrderTotal.TabIndex = 10;
            this.textBoxOH_OrderTotal.TabStop = false;
            this.textBoxOH_OrderTotal.Text = "0.00";
            this.textBoxOH_OrderTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // textBoxOH_Territory
            // 
            this.textBoxOH_Territory.Location = new System.Drawing.Point(96, 152);
            this.textBoxOH_Territory.MaxLength = 20;
            this.textBoxOH_Territory.Name = "textBoxOH_Territory";
            this.textBoxOH_Territory.Size = new System.Drawing.Size(96, 20);
            this.textBoxOH_Territory.TabIndex = 60;
            this.textBoxOH_Territory.Text = "";
            // 
            // textBoxOH_HoldStatus
            // 
            this.textBoxOH_HoldStatus.Location = new System.Drawing.Point(448, 48);
            this.textBoxOH_HoldStatus.MaxLength = 5;
            this.textBoxOH_HoldStatus.Name = "textBoxOH_HoldStatus";
            this.textBoxOH_HoldStatus.Size = new System.Drawing.Size(96, 20);
            this.textBoxOH_HoldStatus.TabIndex = 40;
            this.textBoxOH_HoldStatus.Text = "";
            // 
            // labelOH_Territory
            // 
            this.labelOH_Territory.Location = new System.Drawing.Point(24, 152);
            this.labelOH_Territory.Name = "labelOH_Territory";
            this.labelOH_Territory.Size = new System.Drawing.Size(72, 20);
            this.labelOH_Territory.TabIndex = 47;
            this.labelOH_Territory.Text = "Territory";
            this.labelOH_Territory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOH_HoldStatus
            // 
            this.labelOH_HoldStatus.Location = new System.Drawing.Point(368, 48);
            this.labelOH_HoldStatus.Name = "labelOH_HoldStatus";
            this.labelOH_HoldStatus.Size = new System.Drawing.Size(72, 20);
            this.labelOH_HoldStatus.TabIndex = 45;
            this.labelOH_HoldStatus.Text = "Hold Status";
            this.labelOH_HoldStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_Tax1Total
            // 
            this.textBoxOH_Tax1Total.Location = new System.Drawing.Point(80, 64);
            this.textBoxOH_Tax1Total.MaxLength = 10;
            this.textBoxOH_Tax1Total.Name = "textBoxOH_Tax1Total";
            this.textBoxOH_Tax1Total.ReadOnly = true;
            this.textBoxOH_Tax1Total.Size = new System.Drawing.Size(88, 20);
            this.textBoxOH_Tax1Total.TabIndex = 30;
            this.textBoxOH_Tax1Total.TabStop = false;
            this.textBoxOH_Tax1Total.Text = "0.00";
            this.textBoxOH_Tax1Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelOH_Tax1Total
            // 
            this.labelOH_Tax1Total.Location = new System.Drawing.Point(8, 64);
            this.labelOH_Tax1Total.Name = "labelOH_Tax1Total";
            this.labelOH_Tax1Total.Size = new System.Drawing.Size(72, 20);
            this.labelOH_Tax1Total.TabIndex = 43;
            this.labelOH_Tax1Total.Text = "Tax1 Total";
            this.labelOH_Tax1Total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_OrderNet
            // 
            this.textBoxOH_OrderNet.Location = new System.Drawing.Point(80, 44);
            this.textBoxOH_OrderNet.MaxLength = 10;
            this.textBoxOH_OrderNet.Name = "textBoxOH_OrderNet";
            this.textBoxOH_OrderNet.ReadOnly = true;
            this.textBoxOH_OrderNet.Size = new System.Drawing.Size(88, 20);
            this.textBoxOH_OrderNet.TabIndex = 20;
            this.textBoxOH_OrderNet.TabStop = false;
            this.textBoxOH_OrderNet.Text = "0.00";
            this.textBoxOH_OrderNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // textBoxOH_DiscountTot
            // 
            this.textBoxOH_DiscountTot.Location = new System.Drawing.Point(80, 124);
            this.textBoxOH_DiscountTot.MaxLength = 10;
            this.textBoxOH_DiscountTot.Name = "textBoxOH_DiscountTot";
            this.textBoxOH_DiscountTot.ReadOnly = true;
            this.textBoxOH_DiscountTot.Size = new System.Drawing.Size(88, 20);
            this.textBoxOH_DiscountTot.TabIndex = 60;
            this.textBoxOH_DiscountTot.TabStop = false;
            this.textBoxOH_DiscountTot.Text = "0.00";
            this.textBoxOH_DiscountTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelOH_DiscountTot
            // 
            this.labelOH_DiscountTot.Location = new System.Drawing.Point(8, 124);
            this.labelOH_DiscountTot.Name = "labelOH_DiscountTot";
            this.labelOH_DiscountTot.Size = new System.Drawing.Size(72, 20);
            this.labelOH_DiscountTot.TabIndex = 57;
            this.labelOH_DiscountTot.Text = "Discount Tot.";
            this.labelOH_DiscountTot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_Tax3Total
            // 
            this.textBoxOH_Tax3Total.Location = new System.Drawing.Point(80, 104);
            this.textBoxOH_Tax3Total.MaxLength = 10;
            this.textBoxOH_Tax3Total.Name = "textBoxOH_Tax3Total";
            this.textBoxOH_Tax3Total.ReadOnly = true;
            this.textBoxOH_Tax3Total.Size = new System.Drawing.Size(88, 20);
            this.textBoxOH_Tax3Total.TabIndex = 50;
            this.textBoxOH_Tax3Total.TabStop = false;
            this.textBoxOH_Tax3Total.Text = "0.00";
            this.textBoxOH_Tax3Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelOH_Tax3Total
            // 
            this.labelOH_Tax3Total.Location = new System.Drawing.Point(8, 104);
            this.labelOH_Tax3Total.Name = "labelOH_Tax3Total";
            this.labelOH_Tax3Total.Size = new System.Drawing.Size(72, 20);
            this.labelOH_Tax3Total.TabIndex = 55;
            this.labelOH_Tax3Total.Text = "Tax3 Total";
            this.labelOH_Tax3Total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_Tax2Total
            // 
            this.textBoxOH_Tax2Total.Location = new System.Drawing.Point(80, 84);
            this.textBoxOH_Tax2Total.MaxLength = 10;
            this.textBoxOH_Tax2Total.Name = "textBoxOH_Tax2Total";
            this.textBoxOH_Tax2Total.ReadOnly = true;
            this.textBoxOH_Tax2Total.Size = new System.Drawing.Size(88, 20);
            this.textBoxOH_Tax2Total.TabIndex = 40;
            this.textBoxOH_Tax2Total.TabStop = false;
            this.textBoxOH_Tax2Total.Text = "0.00";
            this.textBoxOH_Tax2Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labeOH_Tax2Total
            // 
            this.labeOH_Tax2Total.Location = new System.Drawing.Point(8, 84);
            this.labeOH_Tax2Total.Name = "labeOH_Tax2Total";
            this.labeOH_Tax2Total.Size = new System.Drawing.Size(72, 20);
            this.labeOH_Tax2Total.TabIndex = 53;
            this.labeOH_Tax2Total.Text = "Tax2 Total";
            this.labeOH_Tax2Total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_CommissTot
            // 
            this.textBoxOH_CommissTot.Location = new System.Drawing.Point(80, 144);
            this.textBoxOH_CommissTot.MaxLength = 10;
            this.textBoxOH_CommissTot.Name = "textBoxOH_CommissTot";
            this.textBoxOH_CommissTot.ReadOnly = true;
            this.textBoxOH_CommissTot.Size = new System.Drawing.Size(88, 20);
            this.textBoxOH_CommissTot.TabIndex = 70;
            this.textBoxOH_CommissTot.TabStop = false;
            this.textBoxOH_CommissTot.Text = "0.00";
            this.textBoxOH_CommissTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelOH_CommissTot
            // 
            this.labelOH_CommissTot.Location = new System.Drawing.Point(8, 144);
            this.labelOH_CommissTot.Name = "labelOH_CommissTot";
            this.labelOH_CommissTot.Size = new System.Drawing.Size(80, 20);
            this.labelOH_CommissTot.TabIndex = 59;
            this.labelOH_CommissTot.Text = "Commiss Tot.";
            this.labelOH_CommissTot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_RoyaltyTot
            // 
            this.textBoxOH_RoyaltyTot.Location = new System.Drawing.Point(80, 164);
            this.textBoxOH_RoyaltyTot.MaxLength = 10;
            this.textBoxOH_RoyaltyTot.Name = "textBoxOH_RoyaltyTot";
            this.textBoxOH_RoyaltyTot.ReadOnly = true;
            this.textBoxOH_RoyaltyTot.Size = new System.Drawing.Size(88, 20);
            this.textBoxOH_RoyaltyTot.TabIndex = 80;
            this.textBoxOH_RoyaltyTot.TabStop = false;
            this.textBoxOH_RoyaltyTot.Text = "0.00";
            this.textBoxOH_RoyaltyTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelOH_RoyaltyTot
            // 
            this.labelOH_RoyaltyTot.Location = new System.Drawing.Point(8, 164);
            this.labelOH_RoyaltyTot.Name = "labelOH_RoyaltyTot";
            this.labelOH_RoyaltyTot.Size = new System.Drawing.Size(72, 20);
            this.labelOH_RoyaltyTot.TabIndex = 63;
            this.labelOH_RoyaltyTot.Text = "Royalty Tot.";
            this.labelOH_RoyaltyTot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.groupBox1.Location = new System.Drawing.Point(24, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 194);
            this.groupBox1.TabIndex = 110;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Totals";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelOH_RetailProductType);
            this.groupBox2.Controls.Add(this.textBoxOH_RetailProductType);
            this.groupBox2.Controls.Add(this.textBoxOH_OrderType);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.labelOH_Currency);
            this.groupBox2.Controls.Add(this.labelOH_Company);
            this.groupBox2.Controls.Add(this.textBoxOH_Currency);
            this.groupBox2.Controls.Add(this.textBoxOH_PO);
            this.groupBox2.Controls.Add(this.labelOH_PO);
            this.groupBox2.Controls.Add(this.labelOH_OrderNum);
            this.groupBox2.Controls.Add(this.textBoxOH_OrderNum);
            this.groupBox2.Controls.Add(this.textBoxOH_Company);
            this.groupBox2.Controls.Add(this.checkBoxOH_Note);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.buttonOH_Note);
            this.groupBox2.Controls.Add(this.textBoxOH_OrderDate);
            this.groupBox2.Controls.Add(this.labelOH_OrderDate);
            this.groupBox2.Controls.Add(this.labelOH_HoldStatus);
            this.groupBox2.Controls.Add(this.textBoxOH_HoldStatus);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 120);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Order Info.";
            // 
            // labelOH_RetailProductType
            // 
            this.labelOH_RetailProductType.Location = new System.Drawing.Point(368, 72);
            this.labelOH_RetailProductType.Name = "labelOH_RetailProductType";
            this.labelOH_RetailProductType.Size = new System.Drawing.Size(72, 20);
            this.labelOH_RetailProductType.TabIndex = 41;
            this.labelOH_RetailProductType.Text = "Retail Type";
            this.labelOH_RetailProductType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_RetailProductType
            // 
            this.textBoxOH_RetailProductType.Location = new System.Drawing.Point(448, 72);
            this.textBoxOH_RetailProductType.MaxLength = 5;
            this.textBoxOH_RetailProductType.Name = "textBoxOH_RetailProductType";
            this.textBoxOH_RetailProductType.ReadOnly = true;
            this.textBoxOH_RetailProductType.Size = new System.Drawing.Size(96, 20);
            this.textBoxOH_RetailProductType.TabIndex = 30;
            this.textBoxOH_RetailProductType.Text = "";
            // 
            // textBoxOH_OrderType
            // 
            this.textBoxOH_OrderType.Location = new System.Drawing.Point(256, 72);
            this.textBoxOH_OrderType.Name = "textBoxOH_OrderType";
            this.textBoxOH_OrderType.ReadOnly = true;
            this.textBoxOH_OrderType.Size = new System.Drawing.Size(96, 20);
            this.textBoxOH_OrderType.TabIndex = 10;
            this.textBoxOH_OrderType.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(192, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "Type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxOH_Note
            // 
            this.checkBoxOH_Note.Enabled = false;
            this.checkBoxOH_Note.Location = new System.Drawing.Point(16, 96);
            this.checkBoxOH_Note.Name = "checkBoxOH_Note";
            this.checkBoxOH_Note.Size = new System.Drawing.Size(72, 20);
            this.checkBoxOH_Note.TabIndex = 121;
            this.checkBoxOH_Note.Text = "Note";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(344, 296);
            this.button1.Name = "button1";
            this.button1.TabIndex = 123;
            this.button1.Text = "Save Order";
            // 
            // buttonOH_Note
            // 
            this.buttonOH_Note.Location = new System.Drawing.Point(88, 96);
            this.buttonOH_Note.Name = "buttonOH_Note";
            this.buttonOH_Note.Size = new System.Drawing.Size(24, 16);
            this.buttonOH_Note.TabIndex = 122;
            this.buttonOH_Note.Text = "...";
            this.buttonOH_Note.Click += new System.EventHandler(this.buttonOH_Note_Click);
            // 
            // textBoxOH_OrderDate
            // 
            this.textBoxOH_OrderDate.Location = new System.Drawing.Point(448, 24);
            this.textBoxOH_OrderDate.MaxLength = 10;
            this.textBoxOH_OrderDate.Name = "textBoxOH_OrderDate";
            this.textBoxOH_OrderDate.ReadOnly = true;
            this.textBoxOH_OrderDate.Size = new System.Drawing.Size(96, 20);
            this.textBoxOH_OrderDate.TabIndex = 120;
            this.textBoxOH_OrderDate.TabStop = false;
            this.textBoxOH_OrderDate.Text = "";
            // 
            // labelOH_OrderDate
            // 
            this.labelOH_OrderDate.Location = new System.Drawing.Point(368, 24);
            this.labelOH_OrderDate.Name = "labelOH_OrderDate";
            this.labelOH_OrderDate.Size = new System.Drawing.Size(64, 20);
            this.labelOH_OrderDate.TabIndex = 67;
            this.labelOH_OrderDate.Text = "Order Date";
            this.labelOH_OrderDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelOrdrHdrInfo
            // 
            this.panelOrdrHdrInfo.Controls.Add(this.groupBox2);
            this.panelOrdrHdrInfo.Location = new System.Drawing.Point(0, 0);
            this.panelOrdrHdrInfo.Name = "panelOrdrHdrInfo";
            this.panelOrdrHdrInfo.Size = new System.Drawing.Size(592, 136);
            this.panelOrdrHdrInfo.TabIndex = 71;
            this.panelOrdrHdrInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelOrdrHdrInfo_Paint);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonSearchEmployee);
            this.groupBox4.Controls.Add(this.textBoxEmployeeName);
            this.groupBox4.Controls.Add(this.labelEmployeeName);
            this.groupBox4.Controls.Add(this.labelOH_SalesPerson);
            this.groupBox4.Controls.Add(this.textBoxOH_SalesPerson);
            this.groupBox4.Location = new System.Drawing.Point(32, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 76);
            this.groupBox4.TabIndex = 90;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Employee";
            // 
            // buttonSearchEmployee
            // 
            this.buttonSearchEmployee.Location = new System.Drawing.Point(170, 26);
            this.buttonSearchEmployee.Name = "buttonSearchEmployee";
            this.buttonSearchEmployee.Size = new System.Drawing.Size(20, 14);
            this.buttonSearchEmployee.TabIndex = 20;
            this.buttonSearchEmployee.Text = "...";
            this.buttonSearchEmployee.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSearchEmployee.Click += new System.EventHandler(this.buttonSearchEmployee_Click);
            // 
            // textBoxEmployeeName
            // 
            this.textBoxEmployeeName.Location = new System.Drawing.Point(80, 44);
            this.textBoxEmployeeName.MaxLength = 10;
            this.textBoxEmployeeName.Name = "textBoxEmployeeName";
            this.textBoxEmployeeName.ReadOnly = true;
            this.textBoxEmployeeName.Size = new System.Drawing.Size(112, 20);
            this.textBoxEmployeeName.TabIndex = 30;
            this.textBoxEmployeeName.TabStop = false;
            this.textBoxEmployeeName.Text = "";
            // 
            // labelEmployeeName
            // 
            this.labelEmployeeName.Location = new System.Drawing.Point(8, 44);
            this.labelEmployeeName.Name = "labelEmployeeName";
            this.labelEmployeeName.Size = new System.Drawing.Size(72, 24);
            this.labelEmployeeName.TabIndex = 25;
            this.labelEmployeeName.Text = "Name";
            this.labelEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOH_SalesPerson
            // 
            this.labelOH_SalesPerson.Location = new System.Drawing.Point(8, 24);
            this.labelOH_SalesPerson.Name = "labelOH_SalesPerson";
            this.labelOH_SalesPerson.Size = new System.Drawing.Size(72, 20);
            this.labelOH_SalesPerson.TabIndex = 35;
            this.labelOH_SalesPerson.Text = "Employee ID";
            this.labelOH_SalesPerson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxOH_BillToName);
            this.groupBox3.Controls.Add(this.labelOH_Plant);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBoxOH_Plant);
            this.groupBox3.Controls.Add(this.textBoxOH_BillToNum);
            this.groupBox3.Controls.Add(this.labelOH_BillToNum);
            this.groupBox3.Location = new System.Drawing.Point(16, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 104);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bill To";
            // 
            // textBoxOH_BillToName
            // 
            this.textBoxOH_BillToName.Location = new System.Drawing.Point(72, 48);
            this.textBoxOH_BillToName.MaxLength = 50;
            this.textBoxOH_BillToName.Name = "textBoxOH_BillToName";
            this.textBoxOH_BillToName.ReadOnly = true;
            this.textBoxOH_BillToName.Size = new System.Drawing.Size(200, 20);
            this.textBoxOH_BillToName.TabIndex = 30;
            this.textBoxOH_BillToName.TabStop = false;
            this.textBoxOH_BillToName.Text = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 72;
            this.label1.Text = " Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxDate
            // 
            this.groupBoxDate.Controls.Add(this.checkBoxOH_ProdDate);
            this.groupBoxDate.Controls.Add(this.dateTimePickerOH_ProdDate);
            this.groupBoxDate.Controls.Add(this.checkBoxOH_DateCancel);
            this.groupBoxDate.Controls.Add(this.dateTimePickerOH_DateCancel);
            this.groupBoxDate.Controls.Add(this.checkBoxOH_DateShip);
            this.groupBoxDate.Controls.Add(this.dateTimePickerOH_DateShip);
            this.groupBoxDate.Controls.Add(this.checkBoxOH_DatePromise);
            this.groupBoxDate.Controls.Add(this.checkBoxOH_DateRequest);
            this.groupBoxDate.Controls.Add(this.dateTimePickerOH_DatePromise);
            this.groupBoxDate.Controls.Add(this.dateTimePickerOH_DateRequest);
            this.groupBoxDate.Controls.Add(this.labelConfirmed);
            this.groupBoxDate.Controls.Add(this.textBoxOH_DateConfirmed);
            this.groupBoxDate.Location = new System.Drawing.Point(336, 16);
            this.groupBoxDate.Name = "groupBoxDate";
            this.groupBoxDate.Size = new System.Drawing.Size(200, 156);
            this.groupBoxDate.TabIndex = 100;
            this.groupBoxDate.TabStop = false;
            this.groupBoxDate.Text = "Date";
            // 
            // checkBoxOH_ProdDate
            // 
            this.checkBoxOH_ProdDate.Location = new System.Drawing.Point(8, 104);
            this.checkBoxOH_ProdDate.Name = "checkBoxOH_ProdDate";
            this.checkBoxOH_ProdDate.Size = new System.Drawing.Size(72, 20);
            this.checkBoxOH_ProdDate.TabIndex = 90;
            this.checkBoxOH_ProdDate.Text = "Prod.";
            this.checkBoxOH_ProdDate.CheckedChanged += new System.EventHandler(this.checkBoxOH_ProdDate_CheckedChanged);
            // 
            // dateTimePickerOH_ProdDate
            // 
            this.dateTimePickerOH_ProdDate.Enabled = false;
            this.dateTimePickerOH_ProdDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerOH_ProdDate.Location = new System.Drawing.Point(80, 104);
            this.dateTimePickerOH_ProdDate.Name = "dateTimePickerOH_ProdDate";
            this.dateTimePickerOH_ProdDate.Size = new System.Drawing.Size(112, 20);
            this.dateTimePickerOH_ProdDate.TabIndex = 100;
            // 
            // checkBoxOH_DateCancel
            // 
            this.checkBoxOH_DateCancel.Enabled = false;
            this.checkBoxOH_DateCancel.Location = new System.Drawing.Point(8, 84);
            this.checkBoxOH_DateCancel.Name = "checkBoxOH_DateCancel";
            this.checkBoxOH_DateCancel.Size = new System.Drawing.Size(72, 20);
            this.checkBoxOH_DateCancel.TabIndex = 70;
            this.checkBoxOH_DateCancel.Text = "Cancel";
            this.checkBoxOH_DateCancel.CheckedChanged += new System.EventHandler(this.checkBoxOH_DateCancel_CheckedChanged);
            // 
            // dateTimePickerOH_DateCancel
            // 
            this.dateTimePickerOH_DateCancel.Enabled = false;
            this.dateTimePickerOH_DateCancel.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerOH_DateCancel.Location = new System.Drawing.Point(80, 84);
            this.dateTimePickerOH_DateCancel.Name = "dateTimePickerOH_DateCancel";
            this.dateTimePickerOH_DateCancel.Size = new System.Drawing.Size(112, 20);
            this.dateTimePickerOH_DateCancel.TabIndex = 80;
            // 
            // checkBoxOH_DateShip
            // 
            this.checkBoxOH_DateShip.Location = new System.Drawing.Point(8, 64);
            this.checkBoxOH_DateShip.Name = "checkBoxOH_DateShip";
            this.checkBoxOH_DateShip.Size = new System.Drawing.Size(72, 20);
            this.checkBoxOH_DateShip.TabIndex = 50;
            this.checkBoxOH_DateShip.Text = "Ship";
            this.checkBoxOH_DateShip.CheckedChanged += new System.EventHandler(this.checkBoxOH_DateShip_CheckedChanged);
            // 
            // dateTimePickerOH_DateShip
            // 
            this.dateTimePickerOH_DateShip.Enabled = false;
            this.dateTimePickerOH_DateShip.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerOH_DateShip.Location = new System.Drawing.Point(80, 64);
            this.dateTimePickerOH_DateShip.Name = "dateTimePickerOH_DateShip";
            this.dateTimePickerOH_DateShip.Size = new System.Drawing.Size(112, 20);
            this.dateTimePickerOH_DateShip.TabIndex = 60;
            // 
            // checkBoxOH_DatePromise
            // 
            this.checkBoxOH_DatePromise.Location = new System.Drawing.Point(8, 44);
            this.checkBoxOH_DatePromise.Name = "checkBoxOH_DatePromise";
            this.checkBoxOH_DatePromise.Size = new System.Drawing.Size(72, 20);
            this.checkBoxOH_DatePromise.TabIndex = 30;
            this.checkBoxOH_DatePromise.Text = "Promise";
            this.checkBoxOH_DatePromise.CheckedChanged += new System.EventHandler(this.checkBoxOH_DatePromise_CheckedChanged);
            // 
            // checkBoxOH_DateRequest
            // 
            this.checkBoxOH_DateRequest.Location = new System.Drawing.Point(8, 24);
            this.checkBoxOH_DateRequest.Name = "checkBoxOH_DateRequest";
            this.checkBoxOH_DateRequest.Size = new System.Drawing.Size(72, 20);
            this.checkBoxOH_DateRequest.TabIndex = 10;
            this.checkBoxOH_DateRequest.Text = "Request";
            this.checkBoxOH_DateRequest.CheckedChanged += new System.EventHandler(this.checkBoxOH_DateRequest_CheckedChanged);
            // 
            // dateTimePickerOH_DatePromise
            // 
            this.dateTimePickerOH_DatePromise.Enabled = false;
            this.dateTimePickerOH_DatePromise.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerOH_DatePromise.Location = new System.Drawing.Point(80, 44);
            this.dateTimePickerOH_DatePromise.Name = "dateTimePickerOH_DatePromise";
            this.dateTimePickerOH_DatePromise.Size = new System.Drawing.Size(112, 20);
            this.dateTimePickerOH_DatePromise.TabIndex = 40;
            // 
            // dateTimePickerOH_DateRequest
            // 
            this.dateTimePickerOH_DateRequest.Enabled = false;
            this.dateTimePickerOH_DateRequest.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerOH_DateRequest.Location = new System.Drawing.Point(80, 24);
            this.dateTimePickerOH_DateRequest.Name = "dateTimePickerOH_DateRequest";
            this.dateTimePickerOH_DateRequest.Size = new System.Drawing.Size(112, 20);
            this.dateTimePickerOH_DateRequest.TabIndex = 20;
            // 
            // labelConfirmed
            // 
            this.labelConfirmed.Location = new System.Drawing.Point(8, 124);
            this.labelConfirmed.Name = "labelConfirmed";
            this.labelConfirmed.Size = new System.Drawing.Size(72, 20);
            this.labelConfirmed.TabIndex = 68;
            this.labelConfirmed.Text = "Confirmed:";
            this.labelConfirmed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_DateConfirmed
            // 
            this.textBoxOH_DateConfirmed.Location = new System.Drawing.Point(80, 124);
            this.textBoxOH_DateConfirmed.MaxLength = 10;
            this.textBoxOH_DateConfirmed.Name = "textBoxOH_DateConfirmed";
            this.textBoxOH_DateConfirmed.ReadOnly = true;
            this.textBoxOH_DateConfirmed.Size = new System.Drawing.Size(112, 20);
            this.textBoxOH_DateConfirmed.TabIndex = 110;
            this.textBoxOH_DateConfirmed.TabStop = false;
            this.textBoxOH_DateConfirmed.Text = "";
            // 
            // buttonAction
            // 
            this.buttonAction.Location = new System.Drawing.Point(24, 208);
            this.buttonAction.Name = "buttonAction";
            this.buttonAction.Size = new System.Drawing.Size(168, 24);
            this.buttonAction.TabIndex = 80;
            this.buttonAction.Text = "Confirm Quote!";
            this.buttonAction.Click += new System.EventHandler(this.buttonAction_Click);
            // 
            // buttonRemoveItem
            // 
            this.buttonRemoveItem.Location = new System.Drawing.Point(464, 256);
            this.buttonRemoveItem.Name = "buttonRemoveItem";
            this.buttonRemoveItem.TabIndex = 170;
            this.buttonRemoveItem.Text = "Remove";
            this.buttonRemoveItem.Click += new System.EventHandler(this.buttonRemoveItem_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(504, 464);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.TabIndex = 180;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonEditItem
            // 
            this.buttonEditItem.Location = new System.Drawing.Point(376, 256);
            this.buttonEditItem.Name = "buttonEditItem";
            this.buttonEditItem.TabIndex = 160;
            this.buttonEditItem.Text = "Edit";
            this.buttonEditItem.Click += new System.EventHandler(this.buttonEditItem_Click);
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Location = new System.Drawing.Point(288, 256);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.TabIndex = 150;
            this.buttonAddItem.Text = "Add";
            this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
            // 
            // buttonSaveOrder
            // 
            this.buttonSaveOrder.Location = new System.Drawing.Point(416, 464);
            this.buttonSaveOrder.Name = "buttonSaveOrder";
            this.buttonSaveOrder.TabIndex = 140;
            this.buttonSaveOrder.Text = "Save";
            this.buttonSaveOrder.Click += new System.EventHandler(this.buttonSaveOrder_Click);
            // 
            // buttonAddDiscount
            // 
            this.buttonAddDiscount.Location = new System.Drawing.Point(80, 256);
            this.buttonAddDiscount.Name = "buttonAddDiscount";
            this.buttonAddDiscount.Size = new System.Drawing.Size(80, 23);
            this.buttonAddDiscount.TabIndex = 138;
            this.buttonAddDiscount.Text = "Add Discount";
            this.buttonAddDiscount.Click += new System.EventHandler(this.buttonAddDiscount_Click);
            // 
            // buttonAddDiscGroup
            // 
            this.buttonAddDiscGroup.Location = new System.Drawing.Point(168, 256);
            this.buttonAddDiscGroup.Name = "buttonAddDiscGroup";
            this.buttonAddDiscGroup.Size = new System.Drawing.Size(96, 23);
            this.buttonAddDiscGroup.TabIndex = 139;
            this.buttonAddDiscGroup.Text = "Add Disc. Group";
            this.buttonAddDiscGroup.Click += new System.EventHandler(this.buttonAddDiscGroup_Click);
            // 
            // dataGridOrderItems
            // 
            this.dataGridOrderItems.CaptionVisible = false;
            this.dataGridOrderItems.DataMember = "";
            this.dataGridOrderItems.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridOrderItems.Location = new System.Drawing.Point(8, 8);
            this.dataGridOrderItems.Name = "dataGridOrderItems";
            this.dataGridOrderItems.ReadOnly = true;
            this.dataGridOrderItems.Size = new System.Drawing.Size(544, 224);
            this.dataGridOrderItems.TabIndex = 34;
            this.dataGridOrderItems.DoubleClick += new System.EventHandler(this.dataGridOrderItems_DoubleClick);
            this.dataGridOrderItems.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridOrderItems_MouseUp);
            // 
            // contextMenuOrderDtls
            // 
            this.contextMenuOrderDtls.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
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
            this.tabControlOrder.Controls.Add(this.tabPageMaterials);
            this.tabControlOrder.Controls.Add(this.tabPageCom);
            this.tabControlOrder.Controls.Add(this.tabPageDistribution);
            this.tabControlOrder.Controls.Add(this.tabPageDoc);
            this.tabControlOrder.Controls.Add(this.tabPageContact);
            this.tabControlOrder.Location = new System.Drawing.Point(8, 136);
            this.tabControlOrder.Name = "tabControlOrder";
            this.tabControlOrder.SelectedIndex = 0;
            this.tabControlOrder.Size = new System.Drawing.Size(576, 320);
            this.tabControlOrder.TabIndex = 137;
            // 
            // tabPageShip
            // 
            this.tabPageShip.Controls.Add(this.groupBox3);
            this.tabPageShip.Controls.Add(this.labelOH_ShipVia);
            this.tabPageShip.Controls.Add(this.textBoxOH_ShipVia);
            this.tabPageShip.Controls.Add(this.groupBoxDate);
            this.tabPageShip.Controls.Add(this.labelOH_Terms);
            this.tabPageShip.Controls.Add(this.labelOH_Territory);
            this.tabPageShip.Controls.Add(this.textBoxOH_Terms);
            this.tabPageShip.Controls.Add(this.textBoxOH_DistributionLoc);
            this.tabPageShip.Controls.Add(this.textBoxOH_Territory);
            this.tabPageShip.Controls.Add(this.label5);
            this.tabPageShip.Controls.Add(this.buttonAction);
            this.tabPageShip.Location = new System.Drawing.Point(4, 22);
            this.tabPageShip.Name = "tabPageShip";
            this.tabPageShip.Size = new System.Drawing.Size(568, 294);
            this.tabPageShip.TabIndex = 0;
            this.tabPageShip.Text = "Shipping";
            // 
            // tabPageMaterials
            // 
            this.tabPageMaterials.Controls.Add(this.dataGridOrderItems);
            this.tabPageMaterials.Controls.Add(this.buttonEditItem);
            this.tabPageMaterials.Controls.Add(this.buttonAddItem);
            this.tabPageMaterials.Controls.Add(this.buttonAddDiscount);
            this.tabPageMaterials.Controls.Add(this.buttonAddDiscGroup);
            this.tabPageMaterials.Controls.Add(this.buttonRemoveItem);
            this.tabPageMaterials.Location = new System.Drawing.Point(4, 22);
            this.tabPageMaterials.Name = "tabPageMaterials";
            this.tabPageMaterials.Size = new System.Drawing.Size(568, 294);
            this.tabPageMaterials.TabIndex = 1;
            this.tabPageMaterials.Text = "Materials";
            this.tabPageMaterials.Visible = false;
            // 
            // tabPageCom
            // 
            this.tabPageCom.Controls.Add(this.groupBox1);
            this.tabPageCom.Location = new System.Drawing.Point(4, 22);
            this.tabPageCom.Name = "tabPageCom";
            this.tabPageCom.Size = new System.Drawing.Size(568, 294);
            this.tabPageCom.TabIndex = 2;
            this.tabPageCom.Text = "Componets";
            this.tabPageCom.Visible = false;
            // 
            // tabPageDistribution
            // 
            this.tabPageDistribution.Location = new System.Drawing.Point(4, 22);
            this.tabPageDistribution.Name = "tabPageDistribution";
            this.tabPageDistribution.Size = new System.Drawing.Size(568, 294);
            this.tabPageDistribution.TabIndex = 3;
            this.tabPageDistribution.Text = "Distribution";
            this.tabPageDistribution.Visible = false;
            // 
            // tabPageDoc
            // 
            this.tabPageDoc.Location = new System.Drawing.Point(4, 22);
            this.tabPageDoc.Name = "tabPageDoc";
            this.tabPageDoc.Size = new System.Drawing.Size(568, 294);
            this.tabPageDoc.TabIndex = 4;
            this.tabPageDoc.Text = "Documents";
            this.tabPageDoc.Visible = false;
            // 
            // tabPageContact
            // 
            this.tabPageContact.Controls.Add(this.groupBox4);
            this.tabPageContact.Controls.Add(this.textBoxOH_ComRate);
            this.tabPageContact.Controls.Add(this.labelOH_ComRate);
            this.tabPageContact.Controls.Add(this.textBoxOH_ComPercent);
            this.tabPageContact.Controls.Add(this.labelOH_ComPercent);
            this.tabPageContact.Location = new System.Drawing.Point(4, 22);
            this.tabPageContact.Name = "tabPageContact";
            this.tabPageContact.Size = new System.Drawing.Size(568, 294);
            this.tabPageContact.TabIndex = 5;
            this.tabPageContact.Text = "Contact";
            this.tabPageContact.Visible = false;
            // 
            // FormEditOrder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(594, 496);
            this.Controls.Add(this.tabControlOrder);
            this.Controls.Add(this.panelOrdrHdrInfo);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSaveOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditOrder";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Order";
            this.Load += new System.EventHandler(this.FormAddNewOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panelOrdrHdrInfo.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBoxDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderItems)).EndInit();
            this.tabControlOrder.ResumeLayout(false);
            this.tabPageShip.ResumeLayout(false);
            this.tabPageMaterials.ResumeLayout(false);
            this.tabPageCom.ResumeLayout(false);
            this.tabPageContact.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion
  
		#region Methods
		private void MyInitialize(Order anOrder)
		{
			order = anOrder;

			initiateControls();
			InitialDataGrid();
			objectToScreen();
		}

		private void initiateControls()
		{
			if (order.getOrderType().Equals(Constants.ORDER_TYPE_QUOTE))
				buttonAction.Text = "Confirm Quote!";
			else
				buttonAction.Text = "Cancel Order!";
			checkBoxOH_DateRequest.Enabled = order.getOrderType().Equals(Constants.ORDER_TYPE_ORDER);
			checkBoxOH_DatePromise.Enabled = order.getOrderType().Equals(Constants.ORDER_TYPE_ORDER);
			checkBoxOH_DateCancel.Enabled = order.getOrderType().Equals(Constants.ORDER_TYPE_ORDER) && !order.getDateCancel().Equals(DateUtil.MinValue);
			checkBoxOH_ProdDate.Enabled = order.getOrderType().Equals(Constants.ORDER_TYPE_ORDER);
			if (order.getOrderType().Equals(Constants.ORDER_TYPE_ORDER) && !order.getDateCancel().Equals(DateUtil.MinValue))
			{
				this.Text += "  / This order was canceled!";
				buttonAction.Visible = false;
			}
			else
				buttonAction.Visible = true;
		}

		private void InitialDataGrid()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Item Num", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Product Desc.", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Unit Price", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Quantity", typeof(string)));
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
			
			setColumnWidths();

			dataGridOrderItems.Refresh();
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

		private void screenToObject()
		{
			order.setCompany (textBoxOH_Company.Text);
			order.setOrderStatus (Constants.ORDER_STATUS_CREATED);
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
			order.setShipVia (textBoxOH_ShipVia.Text);
			order.setHoldStatus (textBoxOH_HoldStatus.Text);

			if (checkBoxOH_DateRequest.Checked)
				order.setDateRequest (dateTimePickerOH_DateRequest.Value);
			else
				order.setDateRequest (DateUtil.MinValue);
			if (checkBoxOH_DatePromise.Checked)
				order.setDatePromise (dateTimePickerOH_DatePromise.Value);
			else
				order.setDatePromise (DateUtil.MinValue);
			if (checkBoxOH_DateShip.Checked)
				order.setDateShip (dateTimePickerOH_DateShip.Value);
			else
				order.setDateShip (DateUtil.MinValue);
			if (checkBoxOH_DateCancel.Checked)
				order.setDateCancel (dateTimePickerOH_DateCancel.Value);
			else
				order.setDateCancel (DateUtil.MinValue);
			if (checkBoxOH_ProdDate.Checked)
				order.setProdDate (dateTimePickerOH_ProdDate.Value);
			else
				order.setProdDate (DateUtil.MinValue);
		}

		public void objectToScreen ()
		{
			if (order.getCountNotes() > 0)
				this.checkBoxOH_Note.Checked=true;
			
			// Dates
			checkBoxOH_DateShip.Checked = !order.getDateShip().Equals (DateUtil.MinValue);
			if (checkBoxOH_DateShip.Checked)
				dateTimePickerOH_DateShip.Value = order.getDateShip();

			if (order.getOrderType().Equals(Constants.ORDER_TYPE_ORDER))
			{
				checkBoxOH_DateRequest.Checked = !order.getDateRequest().Equals (DateUtil.MinValue);
				if (checkBoxOH_DateRequest.Checked)
					dateTimePickerOH_DateRequest.Value = order.getDateRequest();
				checkBoxOH_DatePromise.Checked = !order.getDatePromise().Equals (DateUtil.MinValue);
				if (checkBoxOH_DatePromise.Checked)
					dateTimePickerOH_DatePromise.Value = order.getDatePromise();
				
				checkBoxOH_DateCancel.Checked = !order.getDateCancel().Equals (DateUtil.MinValue);
				if (checkBoxOH_DateCancel.Checked)
					dateTimePickerOH_DateCancel.Value = order.getDateCancel();
				checkBoxOH_ProdDate.Checked = !order.getProdDate().Equals (DateUtil.MinValue);
				if (checkBoxOH_ProdDate.Checked)
					dateTimePickerOH_ProdDate.Value = order.getProdDate();
				textBoxOH_OrderNum.Text = order.getOrderNum().ToString();
			}
			else
				textBoxOH_OrderNum.Text = order.getQuote().ToString();				
			// Totals
			textBoxOH_OrderNet.Text = NumberUtil.toString(order.getOrderNet(),2);
			textBoxOH_OrderTotal.Text = NumberUtil.toString(order.getOrderTotal(),2);
			textBoxOH_Tax1Total.Text = NumberUtil.toString(order.getTax1Total(),2);
			textBoxOH_Tax2Total.Text = NumberUtil.toString(order.getTax2Total(),2);
			textBoxOH_Tax3Total.Text = NumberUtil.toString(order.getTax3Total(),2);
			textBoxOH_DiscountTot.Text = NumberUtil.toString(order.getDiscountTot(),2);
			textBoxOH_CommissTot.Text = NumberUtil.toString(order.getCommissTot(),2);
			textBoxOH_RoyaltyTot.Text = NumberUtil.toString(order.getRoyaltyTot(),2);
			// Info
			textBoxOH_OrderType.Text = order.getOrderType();
			textBoxOH_Company.Text = order.getCompany();
			textBoxOH_PO.Text = order.getPO();
			textBoxOH_Currency.Text = order.getCurrency();
			if (order.getRetailProductType().Equals(Constants.RETAIL_PRODUCT_TYPE_RETAIL))
				textBoxOH_RetailProductType.Text = "Retail";
			if (order.getRetailProductType().Equals(Constants.RETAIL_PRODUCT_TYPE_RHUBARB))
				textBoxOH_RetailProductType.Text = "Rhubarb";
			textBoxOH_SalesPerson.Text = order.getSalesPerson();

			try 
			{
				Employee emp = coreFactory.readEmployee(order.getSalesPerson());
				if (emp != null)
					textBoxEmployeeName.Text = emp.getLastName() + ", " + emp.getFirstName();
			}
			catch (Exception ex)
			{
				FormException frmEx = new FormException(ex);
				frmEx.ShowDialog(this);
			}

			textBoxOH_ComPercent.Text = NumberUtil.toString(order.getComPercent()*100,2);
			textBoxOH_ComRate.Text = NumberUtil.toString(order.getComRate(),2);
			textBoxOH_ShipVia.Text = order.getShipVia();
			textBoxOH_HoldStatus.Text = order.getHoldStatus();
			textBoxOH_Terms.Text = order.getTerms();
			textBoxOH_Territory.Text = order.getTerritory();
			textBoxOH_DistributionLoc.Text = order.getDistributionLoc();
			textBoxOH_OrderDate.Text = DateUtil.getDateRepresentation (order.getOrderDate(),DateUtil.MMDDYYYY);
			textBoxOH_BillToNum.Text = order.getBillToNum();
			textBoxOH_BillToName.Text = order.getBillToName();
			textBoxOH_Plant.Text = order.getPlant();
			if (order.getOrderType().Equals(Constants.ORDER_TYPE_QUOTE))
				textBoxOH_DateConfirmed.Text = "-";
			else
				textBoxOH_DateConfirmed.Text = DateUtil.getDateRepresentation (order.getDateConfirm(),DateUtil.MMDDYYYY);
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
			dr[0] = orderDtl.getItemNum().ToString();
			dr[1] = orderDtl.getProdDescription();
			dr[2] = NumberUtil.toString(orderDtl.getUnitPrice(),2);
			dr[3] = NumberUtil.toString(orderDtl.getQtyOrdSum(),2);
			dr[4] = NumberUtil.toString(orderDtl.getItemNetTotal(),2);
			dr[5] = NumberUtil.toString(orderDtl.getItemNetTotal() - orderDtl.getTotalDiscounts(),2);
			dt.Rows.Add(dr);
		}

		private void cancelOrder()
		{
			if (MessageBox.Show("The order will be canceled." + "\n" + "Are you sure?","Warning!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				this.screenToObject();
				order.setDateCancel (DateTime.Now);
				order.setOrderStatus (Constants.ORDER_STATUS_REMOVED);
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void confirmQuote()
		{
			if (MessageBox.Show("This quote will be confirmed into an order." + "\n" + "Are you sure?","Warning!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				this.screenToObject();
				order.setDateConfirm (DateTime.Now);
				order.setOrderType (Constants.ORDER_TYPE_ORDER);
				order.setOrderNum (order.getQuote());
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void addItem()
		{
			try
			{
				this.screenToObject();
				if (billToObj == null)
					billToObj = coreFactory.readPerson (order.getPlant(),order.getBillToNum());
				FormOrderDtl frm = new FormOrderDtl(order,billToObj);
				frm.Text = "Add New Order Detail";
				frm.ShowDialog(this);

				if ((frm.DialogResult == DialogResult.OK) && (frm.orderDtl != null))
				{
					frm.orderDtl.setDateAdded (DateTime.Now);
					order.addNewLine (frm.orderDtl);
					order.recalculate();
					this.loadGrid(frm.orderDtl);
					objectToScreen();
				}
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
					if (billToObj == null)
						billToObj = coreFactory.readPerson(order.getPlant(),order.getBillToNum());
					FormOrderDtl frm = new FormOrderDtl(order,billToObj,"EDIT");
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
					objectToScreen();
				}
			}
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
			InitialDataGrid();
		}

		private void buttonSaveOrder_Click(object sender, System.EventArgs e)
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
						coreFactory.updateCompleteOrder(order);
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

		private void checkBoxOH_DateShip_CheckedChanged(object sender, System.EventArgs e)
		{
			dateTimePickerOH_DateShip.Enabled = checkBoxOH_DateShip.Checked;
		}

		private void checkBoxOH_DateCancel_CheckedChanged(object sender, System.EventArgs e)
		{
			dateTimePickerOH_DateCancel.Enabled = checkBoxOH_DateCancel.Checked;
		}

		private void checkBoxOH_ProdDate_CheckedChanged(object sender, System.EventArgs e)
		{
			dateTimePickerOH_ProdDate.Enabled = checkBoxOH_ProdDate.Checked;
		}

		private void buttonAction_Click(object sender, System.EventArgs e)
		{
			if (order.getOrderType().Equals(Constants.ORDER_TYPE_ORDER))
				this.cancelOrder();
			else
				this.confirmQuote();
		}

		private void panelOrdrHdrInfo_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			this.loadGrid();
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
				contextMenuOrderDtls.Show(dataGridOrderItems,new Point(e.X,e.Y));
			}
			else if (e.Button == MouseButtons.Right)
			{
				menuItemEditItem.Enabled = false;
				menuItemRemoveItem.Enabled = false;
				contextMenuOrderDtls.Show(dataGridOrderItems,new Point(e.X,e.Y));
			}
		}

		private void buttonSearchEmployee_Click(object sender, System.EventArgs e)
		{
			EmployeeSearchForm employeeSearchForm = new EmployeeSearchForm("Employees ...", coreFactory);
			employeeSearchForm.ShowDialog();
	
			if ((employeeSearchForm.DialogResult == DialogResult.OK) &&
				(employeeSearchForm.getSelected() != null) && 
				!employeeSearchForm.getSelected()[0].Equals(textBoxOH_SalesPerson.Text))
			{
				try
				{
					Employee newEmp = coreFactory.readEmployee(employeeSearchForm.getSelected()[0]);
					Employee oldEmp = null;
					if (!textBoxOH_SalesPerson.Text.Equals(string.Empty))
						oldEmp = coreFactory.readEmployee(textBoxOH_SalesPerson.Text);
					Form frm;
					if (oldEmp == null)
						frm = new FormConfirmEmployee(newEmp);
					else
						frm = new FormConfirmEmployeeChange (oldEmp,newEmp);
					frm.ShowDialog(this);
					if (frm.DialogResult == DialogResult.OK)
					{
						textBoxOH_SalesPerson.Text = newEmp.getId();
						textBoxEmployeeName.Text = newEmp.getLastName() + ", " + newEmp.getFirstName();
					}
				}
				catch (Exception ex)
				{
					FormException frmEx = new FormException(ex);
					frmEx.ShowDialog(this);
				}
			}
		}

		private void buttonAddDiscount_Click(object sender, System.EventArgs e)
		{
			addDiscount();
		}

		private void buttonAddDiscGroup_Click(object sender, System.EventArgs e)
		{
			addDiscountGroup();
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

	} // Class
} // NameSpace
