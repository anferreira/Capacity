using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.WinForms.Master;
using Nujit.NujitERP.WinForms.SearchForms;

namespace Nujit.NujitERP.WinForms.Orders
{
	/// <summary>
	/// Summary description for FormNewOrderDtl.
	/// </summary>
	public class FormOrderDtl : System.Windows.Forms.Form
	{

		#region Controls
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBoxOD_QtyOrdSum;
		private System.Windows.Forms.Label labelOD_QtyOrdSum;
		private System.Windows.Forms.TextBox textBoxOD_UnitPriceUom;
		private System.Windows.Forms.Label labelOD_UnitPriceUom;
		private System.Windows.Forms.TextBox textBoxOD_UnitPrice;
		private System.Windows.Forms.Label labelOD_UnitPrice;
		private System.Windows.Forms.TextBox textBoxOD_CustPO;
		private System.Windows.Forms.Label labelOD_CustPO;
		private System.Windows.Forms.TextBox textBoxOD_CustPart;
		private System.Windows.Forms.Label labelOD_CustPart;
		private System.Windows.Forms.Button buttonSearchProd;
		private System.Windows.Forms.Label labelOD_ProdID;
		private System.Windows.Forms.TextBox textBoxOD_InternalRef;
		private System.Windows.Forms.Label labelOD_InternalRef;
		private System.Windows.Forms.TextBox textBoxOD_Seq;
		private System.Windows.Forms.Label labelOD_Seq;
		private System.Windows.Forms.Label labelOD_DateAdded;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label labelOD_TotalFedTax;
		private System.Windows.Forms.TextBox textBoxOD_TotalFedTax;
		private System.Windows.Forms.TextBox textBoxOD_TotalRoyalty;
		private System.Windows.Forms.Label labelOD_TotalDiscounts;
		private System.Windows.Forms.Label labelOD_TotalRoyalty;
		private System.Windows.Forms.TextBox textBoxOD_ItemNetTotal;
		private System.Windows.Forms.Label labelOD_ItemNetTotal;
		private System.Windows.Forms.Label labelOD_TotalPromo;
		private System.Windows.Forms.TextBox textBoxOD_TotalPromo;
		private System.Windows.Forms.TextBox textBoxOD_TotalDiscounts;
		private System.Windows.Forms.Label label1OD_TotalStTax;
		private System.Windows.Forms.Label labelOD_TotalFreight;
		private System.Windows.Forms.Label labelOD_TotalTax;
		private System.Windows.Forms.TextBox textBoxOD_TotalFreight;
		private System.Windows.Forms.TextBox textBoxOD_TotalTax;
		private System.Windows.Forms.TextBox textBoxOD_TotalStTax;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Button buttonAccept;
		private System.Windows.Forms.Button buttonNewShipment;
		private System.Windows.Forms.Button buttonEditShipment;
		private System.Windows.Forms.Button buttonRemoveShipment;
		private System.Windows.Forms.TabPage tabShipments;
		private System.Windows.Forms.TextBox textBoxOD_ProdID;
		private System.Windows.Forms.TextBox textBoxOD_ProdDescription;
		private System.Windows.Forms.Label labelOD_ProdDescription;
		private System.Windows.Forms.DataGrid dataGridDtlRels;
		private System.Windows.Forms.Label labelQtyShipped;
		private System.Windows.Forms.TextBox textBoxOD_DateAdded;
		private System.Windows.Forms.TextBox textBoxOD_QtyShipped;
		private System.Windows.Forms.GroupBox groupBoxProgress;
		private System.Windows.Forms.Label label_ODQtyPackSize;
		private System.Windows.Forms.TextBox textBoxOD_QtyPackSize;
		private System.Windows.Forms.ContextMenu contextMenuDiscounts;
		private System.Windows.Forms.ContextMenu contextMenuShipments;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItemAddDiscount;
		private System.Windows.Forms.MenuItem menuItemAddDiscGroup;
		private System.Windows.Forms.MenuItem menuItemClearDiscounts;
		private System.Windows.Forms.MenuItem menuItemNewShipment;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItemEditShipment;
		private System.Windows.Forms.MenuItem menuItemRemoveShipment;
		private System.Windows.Forms.Label labelTotal;
		private System.Windows.Forms.TextBox textBoxTotal;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		private Person billToObj;
		private string lastUnitPriceValueStr = "";
		private string lastQtyValueStr = "";
		private OrderDtl _orderDtl, _auxOrderDtl;
		private Order _order;
		private string _mode;
		private OrderDtlRel activeRel = null;
		private CoreFactory coreFactory;
		private bool mustClose = false;
		private bool cantSelectProduct = false;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TabPage tabDiscounts;
		private System.Windows.Forms.Button buttonAddDiscount;
		private System.Windows.Forms.Button buttonAddDiscountGroup;
		private System.Windows.Forms.Button buttonRemoveDiscount;
		private System.Windows.Forms.DataGrid dataGridDtlCharges;
		private bool UnitPriceOrQtyIsBeingEditted = false;
		private System.Windows.Forms.TextBox textBoxOD_Cost;
		private System.Windows.Forms.Label labelOD_Cost;
		private System.Windows.Forms.CheckBox checkBoxOD_Note;
		private System.Windows.Forms.Button buttonOD_Note;
        private System.Windows.Forms.TabPage tabPageAcc;
        private System.Windows.Forms.TabPage tabPageItem;
		private bool loadingPrice = false;

		#region Constructors
		public FormOrderDtl(Order order, Person billTo,string mode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			_order = order;
			_mode = mode.ToUpper();
			billToObj = billTo;
			coreFactory = UtilCoreFactory.createCoreFactory();
			MyInitialize();
			//
		}

		public FormOrderDtl (Order order, Person billTo) : this(order, billTo, "NEW"){}

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
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelOD_ProdDescription = new System.Windows.Forms.Label();
            this.textBoxOD_ProdDescription = new System.Windows.Forms.TextBox();
            this.textBoxOD_DateAdded = new System.Windows.Forms.TextBox();
            this.textBoxOD_CustPO = new System.Windows.Forms.TextBox();
            this.contextMenuDiscounts = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemAddDiscount = new System.Windows.Forms.MenuItem();
            this.menuItemAddDiscGroup = new System.Windows.Forms.MenuItem();
            this.menuItemClearDiscounts = new System.Windows.Forms.MenuItem();
            this.labelOD_CustPO = new System.Windows.Forms.Label();
            this.textBoxOD_CustPart = new System.Windows.Forms.TextBox();
            this.labelOD_CustPart = new System.Windows.Forms.Label();
            this.buttonSearchProd = new System.Windows.Forms.Button();
            this.labelOD_ProdID = new System.Windows.Forms.Label();
            this.textBoxOD_ProdID = new System.Windows.Forms.TextBox();
            this.textBoxOD_InternalRef = new System.Windows.Forms.TextBox();
            this.labelOD_InternalRef = new System.Windows.Forms.Label();
            this.textBoxOD_Seq = new System.Windows.Forms.TextBox();
            this.labelOD_Seq = new System.Windows.Forms.Label();
            this.labelOD_DateAdded = new System.Windows.Forms.Label();
            this.buttonOD_Note = new System.Windows.Forms.Button();
            this.checkBoxOD_Note = new System.Windows.Forms.CheckBox();
            this.labelOD_Cost = new System.Windows.Forms.Label();
            this.textBoxOD_Cost = new System.Windows.Forms.TextBox();
            this.textBoxOD_QtyPackSize = new System.Windows.Forms.TextBox();
            this.label_ODQtyPackSize = new System.Windows.Forms.Label();
            this.groupBoxProgress = new System.Windows.Forms.GroupBox();
            this.textBoxOD_QtyShipped = new System.Windows.Forms.TextBox();
            this.labelQtyShipped = new System.Windows.Forms.Label();
            this.textBoxOD_QtyOrdSum = new System.Windows.Forms.TextBox();
            this.labelOD_QtyOrdSum = new System.Windows.Forms.Label();
            this.textBoxOD_UnitPriceUom = new System.Windows.Forms.TextBox();
            this.labelOD_UnitPriceUom = new System.Windows.Forms.Label();
            this.textBoxOD_UnitPrice = new System.Windows.Forms.TextBox();
            this.labelOD_UnitPrice = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelOD_TotalFedTax = new System.Windows.Forms.Label();
            this.textBoxOD_TotalFedTax = new System.Windows.Forms.TextBox();
            this.textBoxOD_TotalRoyalty = new System.Windows.Forms.TextBox();
            this.labelOD_TotalDiscounts = new System.Windows.Forms.Label();
            this.labelOD_TotalRoyalty = new System.Windows.Forms.Label();
            this.textBoxOD_ItemNetTotal = new System.Windows.Forms.TextBox();
            this.labelOD_ItemNetTotal = new System.Windows.Forms.Label();
            this.labelOD_TotalPromo = new System.Windows.Forms.Label();
            this.textBoxOD_TotalPromo = new System.Windows.Forms.TextBox();
            this.textBoxOD_TotalDiscounts = new System.Windows.Forms.TextBox();
            this.label1OD_TotalStTax = new System.Windows.Forms.Label();
            this.labelOD_TotalFreight = new System.Windows.Forms.Label();
            this.labelOD_TotalTax = new System.Windows.Forms.Label();
            this.textBoxOD_TotalFreight = new System.Windows.Forms.TextBox();
            this.textBoxOD_TotalTax = new System.Windows.Forms.TextBox();
            this.textBoxOD_TotalStTax = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageItem = new System.Windows.Forms.TabPage();
            this.tabDiscounts = new System.Windows.Forms.TabPage();
            this.buttonAddDiscount = new System.Windows.Forms.Button();
            this.buttonAddDiscountGroup = new System.Windows.Forms.Button();
            this.buttonRemoveDiscount = new System.Windows.Forms.Button();
            this.dataGridDtlCharges = new System.Windows.Forms.DataGrid();
            this.tabShipments = new System.Windows.Forms.TabPage();
            this.buttonRemoveShipment = new System.Windows.Forms.Button();
            this.dataGridDtlRels = new System.Windows.Forms.DataGrid();
            this.buttonEditShipment = new System.Windows.Forms.Button();
            this.buttonNewShipment = new System.Windows.Forms.Button();
            this.tabPageAcc = new System.Windows.Forms.TabPage();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.contextMenuShipments = new System.Windows.Forms.ContextMenu();
            this.menuItemNewShipment = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItemEditShipment = new System.Windows.Forms.MenuItem();
            this.menuItemRemoveShipment = new System.Windows.Forms.MenuItem();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBoxProgress.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageItem.SuspendLayout();
            this.tabDiscounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDtlCharges)).BeginInit();
            this.tabShipments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDtlRels)).BeginInit();
            this.tabPageAcc.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelOD_ProdDescription);
            this.groupBox3.Controls.Add(this.textBoxOD_ProdDescription);
            this.groupBox3.Controls.Add(this.textBoxOD_DateAdded);
            this.groupBox3.Controls.Add(this.textBoxOD_CustPO);
            this.groupBox3.Controls.Add(this.labelOD_CustPO);
            this.groupBox3.Controls.Add(this.textBoxOD_CustPart);
            this.groupBox3.Controls.Add(this.labelOD_CustPart);
            this.groupBox3.Controls.Add(this.buttonSearchProd);
            this.groupBox3.Controls.Add(this.labelOD_ProdID);
            this.groupBox3.Controls.Add(this.textBoxOD_ProdID);
            this.groupBox3.Controls.Add(this.textBoxOD_InternalRef);
            this.groupBox3.Controls.Add(this.labelOD_InternalRef);
            this.groupBox3.Controls.Add(this.textBoxOD_Seq);
            this.groupBox3.Controls.Add(this.labelOD_Seq);
            this.groupBox3.Controls.Add(this.labelOD_DateAdded);
            this.groupBox3.Controls.Add(this.buttonOD_Note);
            this.groupBox3.Controls.Add(this.checkBoxOD_Note);
            this.groupBox3.Location = new System.Drawing.Point(8, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(648, 104);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Item General";
            // 
            // labelOD_ProdDescription
            // 
            this.labelOD_ProdDescription.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOD_ProdDescription.Location = new System.Drawing.Point(16, 44);
            this.labelOD_ProdDescription.Name = "labelOD_ProdDescription";
            this.labelOD_ProdDescription.Size = new System.Drawing.Size(64, 20);
            this.labelOD_ProdDescription.TabIndex = 24;
            this.labelOD_ProdDescription.Text = "Part Desc.";
            this.labelOD_ProdDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOD_ProdDescription
            // 
            this.textBoxOD_ProdDescription.Location = new System.Drawing.Point(80, 44);
            this.textBoxOD_ProdDescription.MaxLength = 200;
            this.textBoxOD_ProdDescription.Name = "textBoxOD_ProdDescription";
            this.textBoxOD_ProdDescription.ReadOnly = true;
            this.textBoxOD_ProdDescription.Size = new System.Drawing.Size(128, 20);
            this.textBoxOD_ProdDescription.TabIndex = 30;
            this.textBoxOD_ProdDescription.TabStop = false;
            this.textBoxOD_ProdDescription.Text = "";
            // 
            // textBoxOD_DateAdded
            // 
            this.textBoxOD_DateAdded.Location = new System.Drawing.Point(496, 24);
            this.textBoxOD_DateAdded.Name = "textBoxOD_DateAdded";
            this.textBoxOD_DateAdded.ReadOnly = true;
            this.textBoxOD_DateAdded.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxOD_DateAdded.TabIndex = 80;
            this.textBoxOD_DateAdded.TabStop = false;
            this.textBoxOD_DateAdded.Text = "";
            // 
            // textBoxOD_CustPO
            // 
            this.textBoxOD_CustPO.ContextMenu = this.contextMenuDiscounts;
            this.textBoxOD_CustPO.Location = new System.Drawing.Point(304, 64);
            this.textBoxOD_CustPO.MaxLength = 40;
            this.textBoxOD_CustPO.Name = "textBoxOD_CustPO";
            this.textBoxOD_CustPO.TabIndex = 70;
            this.textBoxOD_CustPO.Text = "";
            // 
            // contextMenuDiscounts
            // 
            this.contextMenuDiscounts.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                                 this.menuItem1,
                                                                                                 this.menuItemClearDiscounts});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.menuItemAddDiscount,
                                                                                      this.menuItemAddDiscGroup});
            this.menuItem1.Text = "Add";
            // 
            // menuItemAddDiscount
            // 
            this.menuItemAddDiscount.Index = 0;
            this.menuItemAddDiscount.Text = "Discount";
            this.menuItemAddDiscount.Click += new System.EventHandler(this.menuItemAddDiscount_Click);
            // 
            // menuItemAddDiscGroup
            // 
            this.menuItemAddDiscGroup.Index = 1;
            this.menuItemAddDiscGroup.Text = "Discount Group";
            this.menuItemAddDiscGroup.Click += new System.EventHandler(this.menuItemAddDiscGroup_Click);
            // 
            // menuItemClearDiscounts
            // 
            this.menuItemClearDiscounts.Index = 1;
            this.menuItemClearDiscounts.Text = "Clear Discounts";
            this.menuItemClearDiscounts.Click += new System.EventHandler(this.menuItemClearDiscounts_Click);
            // 
            // labelOD_CustPO
            // 
            this.labelOD_CustPO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOD_CustPO.Location = new System.Drawing.Point(240, 64);
            this.labelOD_CustPO.Name = "labelOD_CustPO";
            this.labelOD_CustPO.Size = new System.Drawing.Size(64, 20);
            this.labelOD_CustPO.TabIndex = 11;
            this.labelOD_CustPO.Text = "Cust P.O.";
            this.labelOD_CustPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOD_CustPart
            // 
            this.textBoxOD_CustPart.Location = new System.Drawing.Point(304, 44);
            this.textBoxOD_CustPart.MaxLength = 40;
            this.textBoxOD_CustPart.Name = "textBoxOD_CustPart";
            this.textBoxOD_CustPart.TabIndex = 60;
            this.textBoxOD_CustPart.Text = "";
            // 
            // labelOD_CustPart
            // 
            this.labelOD_CustPart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOD_CustPart.Location = new System.Drawing.Point(240, 44);
            this.labelOD_CustPart.Name = "labelOD_CustPart";
            this.labelOD_CustPart.Size = new System.Drawing.Size(64, 20);
            this.labelOD_CustPart.TabIndex = 9;
            this.labelOD_CustPart.Text = "Cust Part";
            this.labelOD_CustPart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonSearchProd
            // 
            this.buttonSearchProd.Location = new System.Drawing.Point(184, 24);
            this.buttonSearchProd.Name = "buttonSearchProd";
            this.buttonSearchProd.Size = new System.Drawing.Size(24, 16);
            this.buttonSearchProd.TabIndex = 20;
            this.buttonSearchProd.Text = "...";
            this.buttonSearchProd.Click += new System.EventHandler(this.buttonSearchProd_Click);
            // 
            // labelOD_ProdID
            // 
            this.labelOD_ProdID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOD_ProdID.Location = new System.Drawing.Point(16, 24);
            this.labelOD_ProdID.Name = "labelOD_ProdID";
            this.labelOD_ProdID.Size = new System.Drawing.Size(64, 20);
            this.labelOD_ProdID.TabIndex = 2;
            this.labelOD_ProdID.Text = "Part #";
            this.labelOD_ProdID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOD_ProdID
            // 
            this.textBoxOD_ProdID.Location = new System.Drawing.Point(80, 24);
            this.textBoxOD_ProdID.MaxLength = 40;
            this.textBoxOD_ProdID.Name = "textBoxOD_ProdID";
            this.textBoxOD_ProdID.ReadOnly = true;
            this.textBoxOD_ProdID.Size = new System.Drawing.Size(96, 20);
            this.textBoxOD_ProdID.TabIndex = 10;
            this.textBoxOD_ProdID.TabStop = false;
            this.textBoxOD_ProdID.Text = "";
            // 
            // textBoxOD_InternalRef
            // 
            this.textBoxOD_InternalRef.Location = new System.Drawing.Point(304, 24);
            this.textBoxOD_InternalRef.MaxLength = 40;
            this.textBoxOD_InternalRef.Name = "textBoxOD_InternalRef";
            this.textBoxOD_InternalRef.TabIndex = 50;
            this.textBoxOD_InternalRef.Text = "";
            // 
            // labelOD_InternalRef
            // 
            this.labelOD_InternalRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOD_InternalRef.Location = new System.Drawing.Point(240, 24);
            this.labelOD_InternalRef.Name = "labelOD_InternalRef";
            this.labelOD_InternalRef.Size = new System.Drawing.Size(64, 20);
            this.labelOD_InternalRef.TabIndex = 6;
            this.labelOD_InternalRef.Text = "Inter. Ref.";
            this.labelOD_InternalRef.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOD_Seq
            // 
            this.textBoxOD_Seq.Location = new System.Drawing.Point(80, 64);
            this.textBoxOD_Seq.MaxLength = 200;
            this.textBoxOD_Seq.Name = "textBoxOD_Seq";
            this.textBoxOD_Seq.ReadOnly = true;
            this.textBoxOD_Seq.Size = new System.Drawing.Size(128, 20);
            this.textBoxOD_Seq.TabIndex = 40;
            this.textBoxOD_Seq.TabStop = false;
            this.textBoxOD_Seq.Text = "";
            // 
            // labelOD_Seq
            // 
            this.labelOD_Seq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOD_Seq.Location = new System.Drawing.Point(16, 64);
            this.labelOD_Seq.Name = "labelOD_Seq";
            this.labelOD_Seq.Size = new System.Drawing.Size(64, 20);
            this.labelOD_Seq.TabIndex = 4;
            this.labelOD_Seq.Text = "Seq.";
            this.labelOD_Seq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOD_DateAdded
            // 
            this.labelOD_DateAdded.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOD_DateAdded.Location = new System.Drawing.Point(432, 24);
            this.labelOD_DateAdded.Name = "labelOD_DateAdded";
            this.labelOD_DateAdded.Size = new System.Drawing.Size(64, 20);
            this.labelOD_DateAdded.TabIndex = 18;
            this.labelOD_DateAdded.Text = "Date Added";
            this.labelOD_DateAdded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonOD_Note
            // 
            this.buttonOD_Note.Location = new System.Drawing.Point(504, 64);
            this.buttonOD_Note.Name = "buttonOD_Note";
            this.buttonOD_Note.Size = new System.Drawing.Size(24, 16);
            this.buttonOD_Note.TabIndex = 75;
            this.buttonOD_Note.Text = "...";
            this.buttonOD_Note.Click += new System.EventHandler(this.buttonOD_Note_Click);
            // 
            // checkBoxOD_Note
            // 
            this.checkBoxOD_Note.Enabled = false;
            this.checkBoxOD_Note.Location = new System.Drawing.Point(440, 64);
            this.checkBoxOD_Note.Name = "checkBoxOD_Note";
            this.checkBoxOD_Note.Size = new System.Drawing.Size(56, 20);
            this.checkBoxOD_Note.TabIndex = 74;
            this.checkBoxOD_Note.Text = "Note";
            // 
            // labelOD_Cost
            // 
            this.labelOD_Cost.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOD_Cost.Location = new System.Drawing.Point(24, 56);
            this.labelOD_Cost.Name = "labelOD_Cost";
            this.labelOD_Cost.Size = new System.Drawing.Size(64, 20);
            this.labelOD_Cost.TabIndex = 132;
            this.labelOD_Cost.Text = "Cost";
            this.labelOD_Cost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOD_Cost
            // 
            this.textBoxOD_Cost.Location = new System.Drawing.Point(104, 56);
            this.textBoxOD_Cost.MaxLength = 5;
            this.textBoxOD_Cost.Name = "textBoxOD_Cost";
            this.textBoxOD_Cost.ReadOnly = true;
            this.textBoxOD_Cost.Size = new System.Drawing.Size(104, 20);
            this.textBoxOD_Cost.TabIndex = 131;
            this.textBoxOD_Cost.TabStop = false;
            this.textBoxOD_Cost.Text = "0.00";
            // 
            // textBoxOD_QtyPackSize
            // 
            this.textBoxOD_QtyPackSize.Location = new System.Drawing.Point(104, 76);
            this.textBoxOD_QtyPackSize.MaxLength = 15;
            this.textBoxOD_QtyPackSize.Name = "textBoxOD_QtyPackSize";
            this.textBoxOD_QtyPackSize.ReadOnly = true;
            this.textBoxOD_QtyPackSize.Size = new System.Drawing.Size(104, 20);
            this.textBoxOD_QtyPackSize.TabIndex = 110;
            this.textBoxOD_QtyPackSize.TabStop = false;
            this.textBoxOD_QtyPackSize.Text = "0.00";
            // 
            // label_ODQtyPackSize
            // 
            this.label_ODQtyPackSize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_ODQtyPackSize.Location = new System.Drawing.Point(24, 80);
            this.label_ODQtyPackSize.Name = "label_ODQtyPackSize";
            this.label_ODQtyPackSize.Size = new System.Drawing.Size(64, 20);
            this.label_ODQtyPackSize.TabIndex = 28;
            this.label_ODQtyPackSize.Text = "Pack Size";
            this.label_ODQtyPackSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxProgress
            // 
            this.groupBoxProgress.Controls.Add(this.textBoxOD_QtyShipped);
            this.groupBoxProgress.Controls.Add(this.labelQtyShipped);
            this.groupBoxProgress.Location = new System.Drawing.Point(280, 16);
            this.groupBoxProgress.Name = "groupBoxProgress";
            this.groupBoxProgress.Size = new System.Drawing.Size(184, 56);
            this.groupBoxProgress.TabIndex = 130;
            this.groupBoxProgress.TabStop = false;
            this.groupBoxProgress.Text = "Progress";
            this.groupBoxProgress.Visible = false;
            this.groupBoxProgress.VisibleChanged += new System.EventHandler(this.groupBoxProgress_VisibleChanged);
            // 
            // textBoxOD_QtyShipped
            // 
            this.textBoxOD_QtyShipped.Location = new System.Drawing.Point(88, 24);
            this.textBoxOD_QtyShipped.MaxLength = 15;
            this.textBoxOD_QtyShipped.Name = "textBoxOD_QtyShipped";
            this.textBoxOD_QtyShipped.ReadOnly = true;
            this.textBoxOD_QtyShipped.Size = new System.Drawing.Size(88, 20);
            this.textBoxOD_QtyShipped.TabIndex = 10;
            this.textBoxOD_QtyShipped.Text = "0.00";
            this.textBoxOD_QtyShipped.LostFocus += new System.EventHandler(this.textBoxOD_QtyShipped_LostFocus);
            this.textBoxOD_QtyShipped.TextChanged += new System.EventHandler(this.textBoxOD_QtyShipped_TextChanged);
            // 
            // labelQtyShipped
            // 
            this.labelQtyShipped.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelQtyShipped.Location = new System.Drawing.Point(8, 24);
            this.labelQtyShipped.Name = "labelQtyShipped";
            this.labelQtyShipped.Size = new System.Drawing.Size(80, 20);
            this.labelQtyShipped.TabIndex = 25;
            this.labelQtyShipped.Text = "Qty. Shipped";
            this.labelQtyShipped.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOD_QtyOrdSum
            // 
            this.textBoxOD_QtyOrdSum.Location = new System.Drawing.Point(104, 120);
            this.textBoxOD_QtyOrdSum.MaxLength = 15;
            this.textBoxOD_QtyOrdSum.Name = "textBoxOD_QtyOrdSum";
            this.textBoxOD_QtyOrdSum.ReadOnly = true;
            this.textBoxOD_QtyOrdSum.Size = new System.Drawing.Size(104, 20);
            this.textBoxOD_QtyOrdSum.TabIndex = 120;
            this.textBoxOD_QtyOrdSum.Text = "0.00";
            this.textBoxOD_QtyOrdSum.LostFocus += new System.EventHandler(this.textBoxOD_QtyOrdSum_LostFocus);
            this.textBoxOD_QtyOrdSum.GotFocus += new System.EventHandler(this.textBoxOD_QtyOrdSum_GotFocus);
            this.textBoxOD_QtyOrdSum.TextChanged += new System.EventHandler(this.textBoxOD_QtyOrdSum_TextChanged);
            // 
            // labelOD_QtyOrdSum
            // 
            this.labelOD_QtyOrdSum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOD_QtyOrdSum.Location = new System.Drawing.Point(24, 120);
            this.labelOD_QtyOrdSum.Name = "labelOD_QtyOrdSum";
            this.labelOD_QtyOrdSum.Size = new System.Drawing.Size(80, 20);
            this.labelOD_QtyOrdSum.TabIndex = 17;
            this.labelOD_QtyOrdSum.Text = "Qty. Ordered";
            this.labelOD_QtyOrdSum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOD_UnitPriceUom
            // 
            this.textBoxOD_UnitPriceUom.Location = new System.Drawing.Point(104, 36);
            this.textBoxOD_UnitPriceUom.MaxLength = 5;
            this.textBoxOD_UnitPriceUom.Name = "textBoxOD_UnitPriceUom";
            this.textBoxOD_UnitPriceUom.ReadOnly = true;
            this.textBoxOD_UnitPriceUom.Size = new System.Drawing.Size(104, 20);
            this.textBoxOD_UnitPriceUom.TabIndex = 100;
            this.textBoxOD_UnitPriceUom.TabStop = false;
            this.textBoxOD_UnitPriceUom.Text = "";
            // 
            // labelOD_UnitPriceUom
            // 
            this.labelOD_UnitPriceUom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOD_UnitPriceUom.Location = new System.Drawing.Point(24, 40);
            this.labelOD_UnitPriceUom.Name = "labelOD_UnitPriceUom";
            this.labelOD_UnitPriceUom.Size = new System.Drawing.Size(64, 20);
            this.labelOD_UnitPriceUom.TabIndex = 15;
            this.labelOD_UnitPriceUom.Text = "U.O.M.";
            this.labelOD_UnitPriceUom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOD_UnitPrice
            // 
            this.textBoxOD_UnitPrice.Location = new System.Drawing.Point(104, 16);
            this.textBoxOD_UnitPrice.MaxLength = 15;
            this.textBoxOD_UnitPrice.Name = "textBoxOD_UnitPrice";
            this.textBoxOD_UnitPrice.ReadOnly = true;
            this.textBoxOD_UnitPrice.Size = new System.Drawing.Size(104, 20);
            this.textBoxOD_UnitPrice.TabIndex = 90;
            this.textBoxOD_UnitPrice.TabStop = false;
            this.textBoxOD_UnitPrice.Text = "0.00";
            this.textBoxOD_UnitPrice.LostFocus += new System.EventHandler(this.textBoxOD_UnitPrice_LostFocus);
            this.textBoxOD_UnitPrice.GotFocus += new System.EventHandler(this.textBoxOD_UnitPrice_GotFocus);
            this.textBoxOD_UnitPrice.TextChanged += new System.EventHandler(this.textBoxOD_UnitPrice_TextChanged);
            // 
            // labelOD_UnitPrice
            // 
            this.labelOD_UnitPrice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOD_UnitPrice.Location = new System.Drawing.Point(24, 16);
            this.labelOD_UnitPrice.Name = "labelOD_UnitPrice";
            this.labelOD_UnitPrice.Size = new System.Drawing.Size(64, 20);
            this.labelOD_UnitPrice.TabIndex = 13;
            this.labelOD_UnitPrice.Text = "Unit Price";
            this.labelOD_UnitPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxTotal);
            this.groupBox2.Controls.Add(this.labelTotal);
            this.groupBox2.Controls.Add(this.labelOD_TotalFedTax);
            this.groupBox2.Controls.Add(this.textBoxOD_TotalFedTax);
            this.groupBox2.Controls.Add(this.textBoxOD_TotalRoyalty);
            this.groupBox2.Controls.Add(this.labelOD_TotalDiscounts);
            this.groupBox2.Controls.Add(this.labelOD_TotalRoyalty);
            this.groupBox2.Controls.Add(this.textBoxOD_ItemNetTotal);
            this.groupBox2.Controls.Add(this.labelOD_ItemNetTotal);
            this.groupBox2.Controls.Add(this.labelOD_TotalPromo);
            this.groupBox2.Controls.Add(this.textBoxOD_TotalPromo);
            this.groupBox2.Controls.Add(this.textBoxOD_TotalDiscounts);
            this.groupBox2.Controls.Add(this.label1OD_TotalStTax);
            this.groupBox2.Controls.Add(this.labelOD_TotalFreight);
            this.groupBox2.Controls.Add(this.labelOD_TotalTax);
            this.groupBox2.Controls.Add(this.textBoxOD_TotalFreight);
            this.groupBox2.Controls.Add(this.textBoxOD_TotalTax);
            this.groupBox2.Controls.Add(this.textBoxOD_TotalStTax);
            this.groupBox2.Location = new System.Drawing.Point(16, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 216);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total";
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.textBoxTotal.Location = new System.Drawing.Point(112, 192);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(120, 20);
            this.textBoxTotal.TabIndex = 90;
            this.textBoxTotal.TabStop = false;
            this.textBoxTotal.Text = "0.00";
            this.textBoxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelTotal
            // 
            this.labelTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTotal.Location = new System.Drawing.Point(24, 192);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(80, 20);
            this.labelTotal.TabIndex = 25;
            this.labelTotal.Text = "TOTAL";
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOD_TotalFedTax
            // 
            this.labelOD_TotalFedTax.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOD_TotalFedTax.Location = new System.Drawing.Point(24, 124);
            this.labelOD_TotalFedTax.Name = "labelOD_TotalFedTax";
            this.labelOD_TotalFedTax.Size = new System.Drawing.Size(80, 20);
            this.labelOD_TotalFedTax.TabIndex = 24;
            this.labelOD_TotalFedTax.Text = "Tot. FedTax";
            this.labelOD_TotalFedTax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOD_TotalFedTax
            // 
            this.textBoxOD_TotalFedTax.Location = new System.Drawing.Point(112, 124);
            this.textBoxOD_TotalFedTax.Name = "textBoxOD_TotalFedTax";
            this.textBoxOD_TotalFedTax.ReadOnly = true;
            this.textBoxOD_TotalFedTax.Size = new System.Drawing.Size(120, 20);
            this.textBoxOD_TotalFedTax.TabIndex = 60;
            this.textBoxOD_TotalFedTax.Text = "0.00";
            this.textBoxOD_TotalFedTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxOD_TotalFedTax.TextChanged += new System.EventHandler(this.textBoxOD_TotalFedTax_TextChanged);
            // 
            // textBoxOD_TotalRoyalty
            // 
            this.textBoxOD_TotalRoyalty.Location = new System.Drawing.Point(112, 44);
            this.textBoxOD_TotalRoyalty.Name = "textBoxOD_TotalRoyalty";
            this.textBoxOD_TotalRoyalty.ReadOnly = true;
            this.textBoxOD_TotalRoyalty.Size = new System.Drawing.Size(120, 20);
            this.textBoxOD_TotalRoyalty.TabIndex = 20;
            this.textBoxOD_TotalRoyalty.Text = "0.00";
            this.textBoxOD_TotalRoyalty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxOD_TotalRoyalty.TextChanged += new System.EventHandler(this.textBoxOD_TotalRoyalty_TextChanged);
            // 
            // labelOD_TotalDiscounts
            // 
            this.labelOD_TotalDiscounts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOD_TotalDiscounts.Location = new System.Drawing.Point(24, 164);
            this.labelOD_TotalDiscounts.Name = "labelOD_TotalDiscounts";
            this.labelOD_TotalDiscounts.Size = new System.Drawing.Size(80, 20);
            this.labelOD_TotalDiscounts.TabIndex = 10;
            this.labelOD_TotalDiscounts.Text = "Discount Tot.";
            this.labelOD_TotalDiscounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOD_TotalRoyalty
            // 
            this.labelOD_TotalRoyalty.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOD_TotalRoyalty.Location = new System.Drawing.Point(24, 44);
            this.labelOD_TotalRoyalty.Name = "labelOD_TotalRoyalty";
            this.labelOD_TotalRoyalty.Size = new System.Drawing.Size(72, 20);
            this.labelOD_TotalRoyalty.TabIndex = 14;
            this.labelOD_TotalRoyalty.Text = "Tot. Royalty";
            this.labelOD_TotalRoyalty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOD_ItemNetTotal
            // 
            this.textBoxOD_ItemNetTotal.Location = new System.Drawing.Point(112, 144);
            this.textBoxOD_ItemNetTotal.Name = "textBoxOD_ItemNetTotal";
            this.textBoxOD_ItemNetTotal.ReadOnly = true;
            this.textBoxOD_ItemNetTotal.Size = new System.Drawing.Size(120, 20);
            this.textBoxOD_ItemNetTotal.TabIndex = 70;
            this.textBoxOD_ItemNetTotal.TabStop = false;
            this.textBoxOD_ItemNetTotal.Text = "0.00";
            this.textBoxOD_ItemNetTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelOD_ItemNetTotal
            // 
            this.labelOD_ItemNetTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOD_ItemNetTotal.Location = new System.Drawing.Point(24, 144);
            this.labelOD_ItemNetTotal.Name = "labelOD_ItemNetTotal";
            this.labelOD_ItemNetTotal.Size = new System.Drawing.Size(72, 20);
            this.labelOD_ItemNetTotal.TabIndex = 8;
            this.labelOD_ItemNetTotal.Text = "Net Total";
            this.labelOD_ItemNetTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOD_TotalPromo
            // 
            this.labelOD_TotalPromo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOD_TotalPromo.Location = new System.Drawing.Point(24, 24);
            this.labelOD_TotalPromo.Name = "labelOD_TotalPromo";
            this.labelOD_TotalPromo.Size = new System.Drawing.Size(72, 20);
            this.labelOD_TotalPromo.TabIndex = 12;
            this.labelOD_TotalPromo.Text = "Tot. Promo";
            this.labelOD_TotalPromo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOD_TotalPromo
            // 
            this.textBoxOD_TotalPromo.Location = new System.Drawing.Point(112, 24);
            this.textBoxOD_TotalPromo.Name = "textBoxOD_TotalPromo";
            this.textBoxOD_TotalPromo.ReadOnly = true;
            this.textBoxOD_TotalPromo.Size = new System.Drawing.Size(120, 20);
            this.textBoxOD_TotalPromo.TabIndex = 10;
            this.textBoxOD_TotalPromo.Text = "0.00";
            this.textBoxOD_TotalPromo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxOD_TotalPromo.TextChanged += new System.EventHandler(this.textBoxOD_TotalPromo_TextChanged);
            // 
            // textBoxOD_TotalDiscounts
            // 
            this.textBoxOD_TotalDiscounts.Location = new System.Drawing.Point(112, 164);
            this.textBoxOD_TotalDiscounts.Name = "textBoxOD_TotalDiscounts";
            this.textBoxOD_TotalDiscounts.ReadOnly = true;
            this.textBoxOD_TotalDiscounts.Size = new System.Drawing.Size(120, 20);
            this.textBoxOD_TotalDiscounts.TabIndex = 80;
            this.textBoxOD_TotalDiscounts.TabStop = false;
            this.textBoxOD_TotalDiscounts.Text = "0.00";
            this.textBoxOD_TotalDiscounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1OD_TotalStTax
            // 
            this.label1OD_TotalStTax.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1OD_TotalStTax.Location = new System.Drawing.Point(24, 104);
            this.label1OD_TotalStTax.Name = "label1OD_TotalStTax";
            this.label1OD_TotalStTax.Size = new System.Drawing.Size(80, 20);
            this.label1OD_TotalStTax.TabIndex = 22;
            this.label1OD_TotalStTax.Text = "Tot. StTax";
            this.label1OD_TotalStTax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOD_TotalFreight
            // 
            this.labelOD_TotalFreight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOD_TotalFreight.Location = new System.Drawing.Point(24, 64);
            this.labelOD_TotalFreight.Name = "labelOD_TotalFreight";
            this.labelOD_TotalFreight.Size = new System.Drawing.Size(72, 20);
            this.labelOD_TotalFreight.TabIndex = 20;
            this.labelOD_TotalFreight.Text = "Tot. Freight";
            this.labelOD_TotalFreight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOD_TotalTax
            // 
            this.labelOD_TotalTax.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOD_TotalTax.Location = new System.Drawing.Point(24, 84);
            this.labelOD_TotalTax.Name = "labelOD_TotalTax";
            this.labelOD_TotalTax.Size = new System.Drawing.Size(80, 20);
            this.labelOD_TotalTax.TabIndex = 16;
            this.labelOD_TotalTax.Text = "Tot. Tax";
            this.labelOD_TotalTax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOD_TotalFreight
            // 
            this.textBoxOD_TotalFreight.Location = new System.Drawing.Point(112, 64);
            this.textBoxOD_TotalFreight.Name = "textBoxOD_TotalFreight";
            this.textBoxOD_TotalFreight.ReadOnly = true;
            this.textBoxOD_TotalFreight.Size = new System.Drawing.Size(120, 20);
            this.textBoxOD_TotalFreight.TabIndex = 30;
            this.textBoxOD_TotalFreight.Text = "0.00";
            this.textBoxOD_TotalFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxOD_TotalFreight.TextChanged += new System.EventHandler(this.textBoxOD_TotalFreight_TextChanged);
            // 
            // textBoxOD_TotalTax
            // 
            this.textBoxOD_TotalTax.Location = new System.Drawing.Point(112, 84);
            this.textBoxOD_TotalTax.Name = "textBoxOD_TotalTax";
            this.textBoxOD_TotalTax.ReadOnly = true;
            this.textBoxOD_TotalTax.Size = new System.Drawing.Size(120, 20);
            this.textBoxOD_TotalTax.TabIndex = 40;
            this.textBoxOD_TotalTax.Text = "0.00";
            this.textBoxOD_TotalTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxOD_TotalTax.TextChanged += new System.EventHandler(this.textBoxOD_TotalTax_TextChanged);
            // 
            // textBoxOD_TotalStTax
            // 
            this.textBoxOD_TotalStTax.Location = new System.Drawing.Point(112, 104);
            this.textBoxOD_TotalStTax.Name = "textBoxOD_TotalStTax";
            this.textBoxOD_TotalStTax.ReadOnly = true;
            this.textBoxOD_TotalStTax.Size = new System.Drawing.Size(120, 20);
            this.textBoxOD_TotalStTax.TabIndex = 50;
            this.textBoxOD_TotalStTax.Text = "0.00";
            this.textBoxOD_TotalStTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxOD_TotalStTax.TextChanged += new System.EventHandler(this.textBoxOD_TotalStTax_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageItem);
            this.tabControl1.Controls.Add(this.tabDiscounts);
            this.tabControl1.Controls.Add(this.tabShipments);
            this.tabControl1.Controls.Add(this.tabPageAcc);
            this.tabControl1.Location = new System.Drawing.Point(8, 120);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(640, 256);
            this.tabControl1.TabIndex = 30;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageItem
            // 
            this.tabPageItem.Controls.Add(this.textBoxOD_QtyOrdSum);
            this.tabPageItem.Controls.Add(this.labelOD_QtyOrdSum);
            this.tabPageItem.Controls.Add(this.textBoxOD_UnitPriceUom);
            this.tabPageItem.Controls.Add(this.labelOD_Cost);
            this.tabPageItem.Controls.Add(this.textBoxOD_Cost);
            this.tabPageItem.Controls.Add(this.textBoxOD_UnitPrice);
            this.tabPageItem.Controls.Add(this.textBoxOD_QtyPackSize);
            this.tabPageItem.Controls.Add(this.labelOD_UnitPrice);
            this.tabPageItem.Controls.Add(this.label_ODQtyPackSize);
            this.tabPageItem.Controls.Add(this.groupBoxProgress);
            this.tabPageItem.Controls.Add(this.labelOD_UnitPriceUom);
            this.tabPageItem.Location = new System.Drawing.Point(4, 22);
            this.tabPageItem.Name = "tabPageItem";
            this.tabPageItem.Size = new System.Drawing.Size(632, 230);
            this.tabPageItem.TabIndex = 3;
            this.tabPageItem.Text = "Item";
            // 
            // tabDiscounts
            // 
            this.tabDiscounts.Controls.Add(this.buttonAddDiscount);
            this.tabDiscounts.Controls.Add(this.buttonAddDiscountGroup);
            this.tabDiscounts.Controls.Add(this.buttonRemoveDiscount);
            this.tabDiscounts.Controls.Add(this.dataGridDtlCharges);
            this.tabDiscounts.Location = new System.Drawing.Point(4, 22);
            this.tabDiscounts.Name = "tabDiscounts";
            this.tabDiscounts.Size = new System.Drawing.Size(632, 230);
            this.tabDiscounts.TabIndex = 0;
            this.tabDiscounts.Text = "Discounts";
            // 
            // buttonAddDiscount
            // 
            this.buttonAddDiscount.Location = new System.Drawing.Point(272, 200);
            this.buttonAddDiscount.Name = "buttonAddDiscount";
            this.buttonAddDiscount.Size = new System.Drawing.Size(112, 24);
            this.buttonAddDiscount.TabIndex = 5;
            this.buttonAddDiscount.Text = "A&dd Discount";
            this.buttonAddDiscount.Click += new System.EventHandler(this.buttonAddDiscount_Click);
            // 
            // buttonAddDiscountGroup
            // 
            this.buttonAddDiscountGroup.Location = new System.Drawing.Point(392, 200);
            this.buttonAddDiscountGroup.Name = "buttonAddDiscountGroup";
            this.buttonAddDiscountGroup.Size = new System.Drawing.Size(112, 24);
            this.buttonAddDiscountGroup.TabIndex = 4;
            this.buttonAddDiscountGroup.Text = "Add Disc. G&roup";
            this.buttonAddDiscountGroup.Click += new System.EventHandler(this.buttonAddDiscountGroup_Click);
            // 
            // buttonRemoveDiscount
            // 
            this.buttonRemoveDiscount.Location = new System.Drawing.Point(512, 200);
            this.buttonRemoveDiscount.Name = "buttonRemoveDiscount";
            this.buttonRemoveDiscount.Size = new System.Drawing.Size(112, 24);
            this.buttonRemoveDiscount.TabIndex = 3;
            this.buttonRemoveDiscount.Text = "&Clear Discounts";
            this.buttonRemoveDiscount.Click += new System.EventHandler(this.buttonRemoveDiscount_Click);
            // 
            // dataGridDtlCharges
            // 
            this.dataGridDtlCharges.CaptionVisible = false;
            this.dataGridDtlCharges.ContextMenu = this.contextMenuDiscounts;
            this.dataGridDtlCharges.DataMember = "";
            this.dataGridDtlCharges.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridDtlCharges.Location = new System.Drawing.Point(0, 0);
            this.dataGridDtlCharges.Name = "dataGridDtlCharges";
            this.dataGridDtlCharges.Size = new System.Drawing.Size(632, 192);
            this.dataGridDtlCharges.TabIndex = 2;
            // 
            // tabShipments
            // 
            this.tabShipments.Controls.Add(this.buttonRemoveShipment);
            this.tabShipments.Controls.Add(this.dataGridDtlRels);
            this.tabShipments.Controls.Add(this.buttonEditShipment);
            this.tabShipments.Controls.Add(this.buttonNewShipment);
            this.tabShipments.Location = new System.Drawing.Point(4, 22);
            this.tabShipments.Name = "tabShipments";
            this.tabShipments.Size = new System.Drawing.Size(632, 230);
            this.tabShipments.TabIndex = 1;
            this.tabShipments.Text = "Shipment";
            // 
            // buttonRemoveShipment
            // 
            this.buttonRemoveShipment.Location = new System.Drawing.Point(544, 200);
            this.buttonRemoveShipment.Name = "buttonRemoveShipment";
            this.buttonRemoveShipment.Size = new System.Drawing.Size(80, 24);
            this.buttonRemoveShipment.TabIndex = 3;
            this.buttonRemoveShipment.Text = "Remove";
            this.buttonRemoveShipment.Click += new System.EventHandler(this.buttonRemoveShipment_Click);
            // 
            // dataGridDtlRels
            // 
            this.dataGridDtlRels.CaptionVisible = false;
            this.dataGridDtlRels.DataMember = "";
            this.dataGridDtlRels.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridDtlRels.Location = new System.Drawing.Point(0, 0);
            this.dataGridDtlRels.Name = "dataGridDtlRels";
            this.dataGridDtlRels.Size = new System.Drawing.Size(632, 192);
            this.dataGridDtlRels.TabIndex = 4;
            this.dataGridDtlRels.DoubleClick += new System.EventHandler(this.dataGridDtlRels_DoubleClick);
            this.dataGridDtlRels.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridDtlRels_MouseUp);
            this.dataGridDtlRels.CurrentCellChanged += new System.EventHandler(this.dataGridDtlRels_CurrentCellChanged);
            // 
            // buttonEditShipment
            // 
            this.buttonEditShipment.Location = new System.Drawing.Point(456, 200);
            this.buttonEditShipment.Name = "buttonEditShipment";
            this.buttonEditShipment.Size = new System.Drawing.Size(80, 24);
            this.buttonEditShipment.TabIndex = 2;
            this.buttonEditShipment.Text = "Edit";
            this.buttonEditShipment.Click += new System.EventHandler(this.buttonEditShipment_Click);
            // 
            // buttonNewShipment
            // 
            this.buttonNewShipment.Location = new System.Drawing.Point(368, 200);
            this.buttonNewShipment.Name = "buttonNewShipment";
            this.buttonNewShipment.Size = new System.Drawing.Size(80, 24);
            this.buttonNewShipment.TabIndex = 1;
            this.buttonNewShipment.Text = "Add";
            this.buttonNewShipment.Click += new System.EventHandler(this.buttonNewShipment_Click);
            // 
            // tabPageAcc
            // 
            this.tabPageAcc.Controls.Add(this.groupBox2);
            this.tabPageAcc.Location = new System.Drawing.Point(4, 22);
            this.tabPageAcc.Name = "tabPageAcc";
            this.tabPageAcc.Size = new System.Drawing.Size(632, 230);
            this.tabPageAcc.TabIndex = 2;
            this.tabPageAcc.Text = "Accounting";
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(408, 384);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(112, 24);
            this.buttonAccept.TabIndex = 40;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // contextMenuShipments
            // 
            this.contextMenuShipments.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                                 this.menuItemNewShipment,
                                                                                                 this.menuItem3,
                                                                                                 this.menuItemEditShipment,
                                                                                                 this.menuItemRemoveShipment});
            // 
            // menuItemNewShipment
            // 
            this.menuItemNewShipment.Index = 0;
            this.menuItemNewShipment.Text = "New Shipment";
            this.menuItemNewShipment.Click += new System.EventHandler(this.menuItemNewShipment_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "-";
            // 
            // menuItemEditShipment
            // 
            this.menuItemEditShipment.Index = 2;
            this.menuItemEditShipment.Text = "Edit Shipment";
            this.menuItemEditShipment.Click += new System.EventHandler(this.menuItemEditShipment_Click);
            // 
            // menuItemRemoveShipment
            // 
            this.menuItemRemoveShipment.Index = 3;
            this.menuItemRemoveShipment.Text = "Remove Shipment";
            this.menuItemRemoveShipment.Click += new System.EventHandler(this.menuItemRemoveShipment_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(536, 384);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 24);
            this.buttonCancel.TabIndex = 51;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormOrderDtl
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(666, 416);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOrderDtl";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Detail";
            this.Load += new System.EventHandler(this.FormOrderDtl_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBoxProgress.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageItem.ResumeLayout(false);
            this.tabDiscounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDtlCharges)).EndInit();
            this.tabShipments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDtlRels)).EndInit();
            this.tabPageAcc.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

		#region Properties
		public OrderDtl orderDtl 
		{
			get
			{
				return _orderDtl;
			}
			set
			{
				_orderDtl = value;
				if (_auxOrderDtl == null)
					_auxOrderDtl = new OrderDtl();
				if (_auxOrderDtl.getCountCharges() > 0)
					_auxOrderDtl.removeAllDltCharge();
				IEnumerator enu = value.getDtlChargesEnumerator();
				while (enu.MoveNext())
				{
					_auxOrderDtl.addDtlCharge(((OrderDtlCharge)enu.Current).clone());
				}
				if (_auxOrderDtl.getCountLines() > 0)
					_auxOrderDtl.removeAllDltRel();
				enu = value.getDtlRelsEnumerator();
				while (enu.MoveNext())
				{
					_auxOrderDtl.addDtlRel (((OrderDtlRel)enu.Current).clone());
				}
				//note
				enu = value.getNoteEnumerator();
				while (enu.MoveNext())
					_auxOrderDtl.addNote((Note)enu.Current);

				_orderDtl.recalculate();
				objectToScreen(_orderDtl);
			}
		}

		private OrderDtlRel createDefaultShipment (Person customer)
		{
			OrderDtlRel auxRel = new OrderDtlRel();
			auxRel.setCompany (_order.getCompany());
			auxRel.setDateAdded (_order.getOrderDate());
			auxRel.setPlant (customer.getPlt());
			auxRel.setShipToAdd1 (customer.getAddress1());
			auxRel.setShipToAdd2 (customer.getAddress1());
			auxRel.setShipToAdd3 (customer.getAddress1());
			auxRel.setShipToAdd4 (customer.getAddress1());
			auxRel.setShipToAdd5 (customer.getAddress1());
			auxRel.setShipToAdd6 (customer.getAddress1());
			auxRel.setShipToName (customer.getName());
			auxRel.setShipToNum (customer.getId());
			auxRel.setShipPostZip (customer.getZipCode());
			auxRel.setPhoneNum (customer.getPhone());
			return auxRel;
		}
		#endregion

		#region Events
		private void textBoxOD_TotalPromo_TextChanged(object sender, System.EventArgs e)
		{
			this.hasToBeDouble (textBoxOD_TotalPromo);
		}

		private void textBoxOD_TotalRoyalty_TextChanged(object sender, System.EventArgs e)
		{
			this.hasToBeDouble (textBoxOD_TotalRoyalty);
		}

		private void textBoxOD_TotalFreight_TextChanged(object sender, System.EventArgs e)
		{
			this.hasToBeDouble (textBoxOD_TotalFreight);
		}

		private void textBoxOD_TotalTax_TextChanged(object sender, System.EventArgs e)
		{
			this.hasToBeDouble (textBoxOD_TotalTax);
		}

		private void textBoxOD_TotalStTax_TextChanged(object sender, System.EventArgs e)
		{
			this.hasToBeDouble (textBoxOD_TotalStTax);
		}

		private void textBoxOD_TotalFedTax_TextChanged(object sender, System.EventArgs e)
		{
			this.hasToBeDouble (textBoxOD_TotalFedTax);
		}

		private void buttonNewShipment_Click(object sender, System.EventArgs e)
		{
			this.newShipment();
		}

		private void buttonEditShipment_Click(object sender, System.EventArgs e)
		{
			editShipment();
		}

		private void buttonRemoveShipment_Click(object sender, System.EventArgs e)
		{
			this.removeShipment();
		}

		private void buttonAddDiscount_Click(object sender, System.EventArgs e)
		{
			this.addDiscount();
		}

		private void buttonRemoveDiscount_Click(object sender, System.EventArgs e)
		{
			this.clearDiscounts();
		}

		private void buttonAccept_Click(object sender, System.EventArgs e)
		{
			if (textBoxOD_ProdID.Text.Equals(string.Empty))
				MessageBox.Show ("There must be a product asociated with this detail.","No product asigned.",MessageBoxButtons.OK,MessageBoxIcon.Stop);
			else
			{
				if (_auxOrderDtl.getCountLines() == 0)
					MessageBox.Show ("There must be shipments included in the detail.","No shipments.",MessageBoxButtons.OK,MessageBoxIcon.Stop);
				else
				{
					DialogResult messageBoxResult = MessageBox.Show("Apply changes?","Question",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
					if (messageBoxResult == DialogResult.Yes)
					{			
						screenToObject(ref _orderDtl);
						_orderDtl.removeAllDltCharge();
						IEnumerator enu = _auxOrderDtl.getDtlChargesEnumerator();
						while (enu.MoveNext())
							_orderDtl.addDtlCharge((OrderDtlCharge)enu.Current);
						_orderDtl.removeAllDltRel();
						enu = _auxOrderDtl.getDtlRelsEnumerator();
						while (enu.MoveNext())
							_orderDtl.addDtlRel((OrderDtlRel)enu.Current);
						//notes
						_orderDtl.removeAllNotes();
						enu = _auxOrderDtl.getNoteEnumerator();
						while (enu.MoveNext())
							_orderDtl.addNote((Note)enu.Current);

						this.DialogResult = DialogResult.OK;
						this.Close();
					}
					if (messageBoxResult == DialogResult.No)
					{
						this.Close();
					}
				}
			}
		}

		private void buttonSearchProd_Click(object sender, System.EventArgs e)
		{
			if (cantSelectProduct)
			{
				MessageBox.Show ("The Bill to customer no longer exists on the database." + "\n" + "The product can't be modified.","No customer on database.",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
			else
			{
				ProductSearchForm productSearchForm = new ProductSearchForm("Products ...", false);
				productSearchForm.retailProductTypeFilter = _order.getRetailProductType();
				productSearchForm.ShowDialog();
	
				if ((productSearchForm.DialogResult == DialogResult.OK) &&
					(productSearchForm.getSelected() != null))
				{
					if (_order.checkIfProductInTheOrder(productSearchForm.getSelected()[0]) != null)
					{
						MessageBox.Show ("There's already one detail with this product.\nPlease edit that one instead of creating a new one.","Producti in order.",MessageBoxButtons.OK,MessageBoxIcon.Stop);
					}
					else
					{
						textBoxOD_ProdID.Text = productSearchForm.getSelected()[0];
						textBoxOD_ProdDescription.Text = productSearchForm.getSelected()[1];
						textBoxOD_Seq.Text = productSearchForm.getSelected()[4];
						ProductActCost prodActCost = coreFactory.readProductActCost (textBoxOD_ProdID.Text, int.Parse(textBoxOD_Seq.Text));
						if (prodActCost != null)
							textBoxOD_Cost.Text = NumberUtil.toString(prodActCost.getCost(),2);
						else
							textBoxOD_Cost.Text = "0.00";
						if (!this.loadPrice()) 
						{
							OrderDtl lastPriceDtl = coreFactory.readIfProductSold(textBoxOD_ProdID.Text);
							if (lastPriceDtl == null)
							{
								MessageBox.Show ("There is no price set for this product.\nThere's no history record of this product's used price.","Warning!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
								textBoxOD_UnitPrice.Text="0.00";
							}
							else
							{
								MessageBox.Show ("There is no price set for this product.\nThe last price used was " 
									+ NumberUtil.toString(lastPriceDtl.getUnitPrice(),2) + " on " + DateUtil.getDateRepresentation(lastPriceDtl.getDateAdded(),DateUtil.MMDDYYYY) + 
									".","Warning!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
								textBoxOD_UnitPrice.Text=NumberUtil.toString(lastPriceDtl.getUnitPrice(),2);
							}
							textBoxOD_UnitPrice.Select(0,textBoxOD_UnitPrice.Text.Length);
							textBoxOD_UnitPrice.Focus();
						}
					}
				}
			}
		}

		private void textBoxOD_QtyOrdSum_TextChanged(object sender, System.EventArgs e)
		{
			if (!lastQtyValueStr.Equals(textBoxOD_QtyOrdSum.Text))
			{
				lastQtyValueStr = textBoxOD_QtyOrdSum.Text;
				this.hasToBeDouble(textBoxOD_QtyOrdSum);
				this.loadNetTotal();			
			}
		}

		private void textBoxOD_UnitPrice_TextChanged(object sender, System.EventArgs e)
		{
			if (!lastUnitPriceValueStr.Equals(textBoxOD_UnitPrice.Text))
			{
				lastUnitPriceValueStr = textBoxOD_UnitPrice.Text;
				this.hasToBeDouble(textBoxOD_UnitPrice);
				this.loadNetTotal();			
			}
		}

		private void textBoxOD_Cost_TextChanged (object sender, System.EventArgs e)
		{
			this.hasToBeDouble(textBoxOD_Cost);
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			activateRel();
			if (tabControl1.SelectedIndex != 1)
			{
				textBoxOD_QtyShipped.Text="";
				textBoxOD_QtyShipped.ReadOnly = true;
			}
		}

		private void textBoxOD_QtyShipped_TextChanged(object sender, System.EventArgs e)
		{
			this.hasToBeDouble(textBoxOD_QtyShipped);
		}

		private void menuItemAddDiscount_Click(object sender, System.EventArgs e)
		{
			this.addDiscount();
		}

		private void menuItemAddDiscGroup_Click(object sender, System.EventArgs e)
		{
			this.addDiscGroup();
		}

		private void menuItemClearDiscounts_Click(object sender, System.EventArgs e)
		{
			this.clearDiscounts();
		}

		private void menuItemNewShipment_Click(object sender, System.EventArgs e)
		{
			this.newShipment();
		}

		private void menuItemEditShipment_Click(object sender, System.EventArgs e)
		{
			this.editShipment();
		}

		private void menuItemRemoveShipment_Click(object sender, System.EventArgs e)
		{
			this.removeShipment();
		}

		private void dataGridDtlRels_DoubleClick(object sender, EventArgs e)
		{
			System.Windows.Forms.DataGrid.HitTestInfo hti = dataGridDtlRels.HitTest(dataGridDtlRels.PointToClient(MousePosition)); 
			if (hti.Type == DataGrid.HitTestType.RowHeader)
				this.editShipment();
		}

		private void textBoxOD_QtyShipped_LostFocus(object sender, System.EventArgs e)
		{
			if ((activeRel != null) && (NumberUtil.isDoubleNumber(textBoxOD_QtyShipped.Text)))
			{
				activeRel.setQtyShipped(double.Parse(textBoxOD_QtyShipped.Text));
			}

		}

		private void dataGridDtlRels_CurrentCellChanged(object sender, System.EventArgs e)
		{
			activateRel();
		}

		private void dataGridDtlRels_MouseUp(object sender, MouseEventArgs e)
		{
			System.Windows.Forms.DataGrid.HitTestInfo hti = dataGridDtlRels.HitTest(new Point(e.X, e.Y)); 
			if ((e.Button == MouseButtons.Right) && ((hti.Type == DataGrid.HitTestType.RowHeader) || (hti.Type == DataGrid.HitTestType.Cell)))
			{
				dataGridDtlRels.UnSelect(dataGridDtlRels.CurrentRowIndex);
				menuItemEditShipment.Enabled = true;
				menuItemRemoveShipment.Enabled = true;
				dataGridDtlRels.CurrentRowIndex = hti.Row;
				dataGridDtlRels.Select(hti.Row);
				contextMenuShipments.Show(dataGridDtlRels,new Point(e.X,e.Y));
			}
			else if (e.Button == MouseButtons.Right)
			{
				menuItemEditShipment.Enabled = false;
				menuItemRemoveShipment.Enabled = false;
				contextMenuShipments.Show(dataGridDtlRels,new Point(e.X,e.Y));
			}
		}

		private void FormOrderDtl_Load(object sender, System.EventArgs e)
		{
			if (mustClose)
				this.Close();
		}

		private void textBoxOD_UnitPrice_LostFocus(object sender, EventArgs e)
		{
			UnitPriceOrQtyIsBeingEditted = false;
		}

		private void textBoxOD_UnitPrice_GotFocus(object sender, EventArgs e)
		{
			UnitPriceOrQtyIsBeingEditted = true;
		}

		private void textBoxOD_QtyOrdSum_GotFocus(object sender, EventArgs e)
		{
			UnitPriceOrQtyIsBeingEditted = true;
		}

		private void textBoxOD_QtyOrdSum_LostFocus(object sender, EventArgs e)
		{
			UnitPriceOrQtyIsBeingEditted = false;
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("All changes will be lost." + "\n" + "Are you sure?","Warning!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
				this.Close();
		}

		private void groupBoxProgress_VisibleChanged(object sender, EventArgs e)
		{
			if (groupBoxProgress.Visible && _order.getOrderType().Equals(Constants.ORDER_TYPE_QUOTE))
				groupBoxProgress.Visible = false;
		}
		#endregion
		
		#region Methods
		private void MyInitialize()
		{
			try
			{
				Person customer = coreFactory.readPerson (_order.getPlant(),_order.getBillToNum());
				if (_mode.Equals("NEW"))
				{
					_auxOrderDtl = new OrderDtl();
					if (customer == null)
					{
						MessageBox.Show ("The Bill to customer no longer exists on the database." + "\n" + "No aditional detail lines can be added.","No customer on database.",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
						mustClose = true;
						return;
					}
					_auxOrderDtl.addNewDtlRel(createDefaultShipment(customer));
					_orderDtl = new OrderDtl();
				}
				else
				{
					if (customer == null)
						cantSelectProduct = true;
				}
				textBoxOD_DateAdded.Text = DateUtil.getDateRepresentation(_order.getOrderDate(),DateUtil.MMDDYYYY);
				this.InitialDataGridCharges();
				this.InitialDataGridRels();
				this.loadGridRels();
			}
			catch (Exception ex)
			{
				FormException frmEx = new FormException(ex);
				frmEx.ShowDialog(this);
			}
		}

		private void screenToObject (ref OrderDtl anOrderDtl)
		{
			if (anOrderDtl == null)
				anOrderDtl = new OrderDtl();
			anOrderDtl.setProdID(textBoxOD_ProdID.Text);
			anOrderDtl.setProdDescription(textBoxOD_ProdDescription.Text);
			if ((textBoxOD_UnitPrice.Text.Equals(string.Empty)) || (textBoxOD_UnitPrice.Text.Equals(",")) || (textBoxOD_UnitPrice.Text.Equals(".")))
				anOrderDtl.setUnitPrice (0);
			else
				anOrderDtl.setUnitPrice (double.Parse(textBoxOD_UnitPrice.Text));
			anOrderDtl.setUnitPriceUom (textBoxOD_UnitPriceUom.Text);
			anOrderDtl.setQtyPackSize(double.Parse(textBoxOD_QtyPackSize.Text));
			if (textBoxOD_Seq.Text.Equals(string.Empty))
				anOrderDtl.setSeq (0);
			else
				anOrderDtl.setSeq (int.Parse(textBoxOD_Seq.Text));
			if (textBoxOD_Cost.Text.Equals(string.Empty))
				anOrderDtl.setCost (0.0);
			else
				anOrderDtl.setCost (double.Parse(textBoxOD_Cost.Text));
			anOrderDtl.setInternalRef (textBoxOD_InternalRef.Text);
			anOrderDtl.setCustPart (textBoxOD_CustPart.Text);
			anOrderDtl.setCustPO (textBoxOD_CustPO.Text);
			if ((textBoxOD_QtyOrdSum.Text.Equals(string.Empty)) || (textBoxOD_QtyOrdSum.Text.Equals(",")) || (textBoxOD_QtyOrdSum.Text.Equals(".")))
				anOrderDtl.setQtyOrdSum (0);
			else
				anOrderDtl.setQtyOrdSum (double.Parse(textBoxOD_QtyOrdSum.Text));
			if ((textBoxOD_TotalPromo.Text.Equals(string.Empty)) || (textBoxOD_TotalPromo.Text.Equals(",")) || (textBoxOD_TotalPromo.Text.Equals(".")))
				anOrderDtl.setTotalPromo (0);
			else
				anOrderDtl.setTotalPromo (double.Parse(textBoxOD_TotalPromo.Text));
			if ((textBoxOD_TotalRoyalty.Text.Equals(string.Empty)) || (textBoxOD_TotalRoyalty.Text.Equals(",")) || (textBoxOD_TotalRoyalty.Text.Equals(".")))
				anOrderDtl.setTotalRoyalty (0);
			else
				anOrderDtl.setTotalRoyalty (double.Parse(textBoxOD_TotalRoyalty.Text));
			if ((textBoxOD_TotalFreight.Text.Equals(string.Empty)) || (textBoxOD_TotalFreight.Text.Equals(",")) || (textBoxOD_TotalFreight.Text.Equals(".")))
				anOrderDtl.setTotalFreight (0);
			else
				anOrderDtl.setTotalFreight (double.Parse(textBoxOD_TotalFreight.Text));
			if ((textBoxOD_TotalTax.Text.Equals(string.Empty)) || (textBoxOD_TotalTax.Text.Equals(",")) || (textBoxOD_TotalTax.Text.Equals(".")))
				anOrderDtl.setTotalTax (0);
			else
				anOrderDtl.setTotalTax (double.Parse(textBoxOD_TotalTax.Text));
			if ((textBoxOD_TotalStTax.Text.Equals(string.Empty)) || (textBoxOD_TotalStTax.Text.Equals(",")) || (textBoxOD_TotalStTax.Text.Equals(".")))
				anOrderDtl.setTotalStTax (0);
			else
				anOrderDtl.setTotalStTax (double.Parse(textBoxOD_TotalStTax.Text));
			if ((textBoxOD_TotalFedTax.Text.Equals(string.Empty)) || (textBoxOD_TotalFedTax.Text.Equals(",")) || (textBoxOD_TotalFedTax.Text.Equals(".")))
				anOrderDtl.setTotalFedTax (0);
			else
				anOrderDtl.setTotalFedTax (double.Parse(textBoxOD_TotalFedTax.Text));

		}

		public void objectToScreen (OrderDtl anOrderDtl)
		{
			textBoxOD_ProdID.Text = anOrderDtl.getProdID();
			textBoxOD_ProdDescription.Text = anOrderDtl.getProdDescription();
			if (!UnitPriceOrQtyIsBeingEditted)
				textBoxOD_UnitPrice.Text = NumberUtil.toString(anOrderDtl.getUnitPrice(),2);
			textBoxOD_UnitPriceUom.Text = anOrderDtl.getUnitPriceUom();
			textBoxOD_QtyPackSize.Text = NumberUtil.toString(anOrderDtl.getQtyPackSize(),2);
			textBoxOD_Seq.Text = NumberUtil.toString(anOrderDtl.getSeq());
			textBoxOD_Cost.Text = NumberUtil.toString(anOrderDtl.getCost(),2);
			textBoxOD_InternalRef.Text = anOrderDtl.getInternalRef();
			textBoxOD_CustPart.Text = anOrderDtl.getCustPart();
			textBoxOD_CustPO.Text = anOrderDtl.getCustPO();
		
			if (anOrderDtl.getCountNotes() > 0)
				this.checkBoxOD_Note.Checked=true;

			if (!UnitPriceOrQtyIsBeingEditted)
				textBoxOD_QtyOrdSum.Text = NumberUtil.toString(anOrderDtl.getQtyOrdSum(),2);
			textBoxOD_TotalPromo.Text = NumberUtil.toString(anOrderDtl.getTotalPromo(),2);
			textBoxOD_TotalRoyalty.Text = NumberUtil.toString(anOrderDtl.getTotalRoyalty(),2);
			textBoxOD_TotalFreight.Text = NumberUtil.toString(anOrderDtl.getTotalFreight(),2);
			textBoxOD_TotalTax.Text = NumberUtil.toString(anOrderDtl.getTotalTax(),2);
			textBoxOD_TotalStTax.Text = NumberUtil.toString(anOrderDtl.getTotalStTax(),2);
			textBoxOD_TotalFedTax.Text = NumberUtil.toString(anOrderDtl.getTotalFedTax(),2);

			textBoxOD_ItemNetTotal.Text = NumberUtil.toString(anOrderDtl.getItemNetTotal(),2);
			textBoxOD_TotalDiscounts.Text = NumberUtil.toString(anOrderDtl.getTotalDiscounts(),2);
			textBoxTotal.Text = NumberUtil.toString(anOrderDtl.getItemNetTotal() - anOrderDtl.getTotalDiscounts(),2);
			
			if (_mode.Equals("EDIT"))
				groupBoxProgress.Visible = true;
			this.loadGridCharges();
			this.loadGridRels();
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

		private void loadNetTotal()
		{
			try 
			{
				if ((textBoxOD_UnitPrice.Text.Length > 0) && (textBoxOD_QtyOrdSum.Text.Length > 0))
				{
					if ((double.Parse(textBoxOD_UnitPrice.Text) * double.Parse(textBoxOD_QtyOrdSum.Text)) != 0)
					{
						if (_auxOrderDtl == null)
							_auxOrderDtl = new OrderDtl();
						this.screenToObject(ref _auxOrderDtl);

						bool wasBeingEditted = UnitPriceOrQtyIsBeingEditted;
						UnitPriceOrQtyIsBeingEditted = true;
						loadPrice();
						_auxOrderDtl.recalculate();

						objectToScreen(_auxOrderDtl);
						if (!wasBeingEditted)
							UnitPriceOrQtyIsBeingEditted = false;

						return;
					}
				}
			}
			catch {} // User enters "." in qty, it can't parse, therefore it should be considered as 0.
			textBoxOD_ItemNetTotal.Text = "0.00";
		}

		private bool loadPrice()
		{
			if (!loadingPrice)
			{
				loadingPrice = true;
				if (textBoxOD_ProdID.Text.Length > 0)
				{
					try
					{
						Product prod = coreFactory.readProduct(textBoxOD_ProdID.Text);
						textBoxOD_QtyPackSize.Text = "1.00";
						if (prod != null)
						{
							textBoxOD_QtyPackSize.Text = NumberUtil.toString(prod.getStdPackSize(),2);
							if (prod.getStdPackSize().Equals(0.0))
								textBoxOD_QtyPackSize.Text = "1.00";
							if ((_auxOrderDtl.getDltRelByIndex(0).getQtyOrd().Equals(0.0)) && (_auxOrderDtl.getDltRelByIndex(0).getShipToNum().Equals(_order.getBillToNum())))
							{
								_auxOrderDtl.getDtlRelByID(1).setQtyOrd(double.Parse(textBoxOD_QtyPackSize.Text));
								this.loadGridRels();
								calculateQty();
							}
						}
						string[][] pPrice = coreFactory.readProductPriceByCustomer (textBoxOD_ProdID.Text, _order.getBillToNum(),billToObj.getPersonClass(),DateUtil.getDateRepresentation(DateTime.Now,DateUtil.MMDDYYYY),Constants.STRING_YES,decimal.Parse(textBoxOD_QtyOrdSum.Text));
						if (pPrice.Length < 1)
						{
							textBoxOD_UnitPrice.ReadOnly = false;
							textBoxOD_UnitPrice.TabStop = true;
							textBoxOD_UnitPriceUom.ReadOnly = false;
							textBoxOD_UnitPriceUom.TabStop = true;
							loadingPrice = false;
							return false;
						}
						else
						{
							textBoxOD_UnitPrice.Text = NumberUtil.toString(decimal.Parse(pPrice[0][0]),2);
							textBoxOD_UnitPrice.ReadOnly = true;
							textBoxOD_UnitPrice.TabStop = false;
							textBoxOD_UnitPriceUom.ReadOnly = true;
							textBoxOD_UnitPriceUom.TabStop = false;
							loadingPrice = false;
							return true;
						}
					}
					catch (Exception ex)
					{
						FormException frmEx = new FormException(ex);
						frmEx.ShowDialog(this);
						loadingPrice = false;
					}
				}
				loadingPrice = false;
			}
			return false;
		}

		private void InitialDataGridCharges()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Discount Num", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Discount Desc.", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Perc./Amount", typeof(string)));
	
			DataView dataView = new DataView(dataTable);
			dataView.AllowEdit = false;
			dataView.AllowDelete = false;
			dataView.AllowNew = false;

			dataGridDtlCharges.DataSource = dataView;
			dataGridDtlCharges.PreferredColumnWidth = 150;
			dataGridDtlCharges.TableStyles.Clear();
			dataGridDtlCharges.TableStyles.Add(new DataGridTableStyle());
			
			GridColumnStylesCollection	colStyle;
			colStyle				= dataGridDtlCharges.TableStyles[0].GridColumnStyles;		
			colStyle[0].Width      	= 80;
			colStyle[1].Width		= 433;
			colStyle[2].Width		= 80;
			dataGridDtlCharges.Refresh();
		}

		private void InitialDataGridRels()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("RelNum", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Num", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Address", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Phone Number", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty Ordered", typeof(string)));
	
			DataView dataView = new DataView(dataTable);
			dataView.AllowEdit = false;
			dataView.AllowDelete = false;
			dataView.AllowNew = false;

			dataGridDtlRels.DataSource = dataView;
			dataGridDtlRels.PreferredColumnWidth = 150;
			dataGridDtlRels.TableStyles.Clear();
			dataGridDtlRels.TableStyles.Add(new DataGridTableStyle());
			
			GridColumnStylesCollection	colStyle;
			colStyle				= dataGridDtlRels.TableStyles[0].GridColumnStyles;
			colStyle[0].Width      	= 0;
			colStyle[1].Width      	= 80;
			colStyle[2].Width		= 173;
			colStyle[3].Width		= 170;
			colStyle[4].Width		= 100;
			colStyle[5].Width		= 70;
			dataGridDtlRels.Refresh();
		}

		private void loadGridCharges()
		{
			IEnumerator enu = _auxOrderDtl.getDtlChargesEnumerator();
			(((DataView)dataGridDtlCharges.DataSource).Table).Clear();
			while (enu.MoveNext())
			{
				loadGridCharges((OrderDtlCharge)enu.Current);
			}
		}

		private void loadGridRels()
		{
			if (_auxOrderDtl != null)
			{
				IEnumerator enu = _auxOrderDtl.getDtlRelsEnumerator();
				(((DataView)dataGridDtlRels.DataSource).Table).Clear();
				while (enu.MoveNext())
				{
					loadGridRels((OrderDtlRel)enu.Current);
				}
			}
		}

		private void activateRel ()
		{
			if (dataGridDtlRels.CurrentRowIndex >= 0)
			{
				textBoxOD_QtyShipped.ReadOnly = false;
				OrderDtlRel auxRel = _auxOrderDtl.getDtlRelByID (int.Parse((string)dataGridDtlRels[dataGridDtlRels.CurrentRowIndex,0]));
				textBoxOD_QtyShipped.Text = auxRel.getQtyShipped().ToString();
				activeRel = auxRel;
			}
			else
			{
				textBoxOD_QtyShipped.ReadOnly = true;
				textBoxOD_QtyShipped.Text = "";
				activeRel = null;
			}
		}

		private void buttonAddDiscountGroup_Click(object sender, System.EventArgs e)
		{
			this.addDiscGroup();
		}

		private void loadGridCharges(OrderDtlCharge orderDtlCharge)
		{
			DataTable dt = ((DataView)dataGridDtlCharges.DataSource).Table;
			DataRow dr = dt.NewRow();
			dr[0] = orderDtlCharge.getItemChgNum().ToString();
			dr[1] = orderDtlCharge.getChargeDesc();
			if (orderDtlCharge.getPercent()>0)
				dr[2] = "% " + NumberUtil.toString(orderDtlCharge.getPercent());
			else
				dr[2] = "$ " + NumberUtil.toString(orderDtlCharge.getAmount());
			dt.Rows.Add(dr);
		}

		private void loadGridRels(OrderDtlRel orderDtlRel)
		{
			DataTable dt = ((DataView)dataGridDtlRels.DataSource).Table;
			DataRow dr = dt.NewRow();
			dr[0] = orderDtlRel.getItemNumRel();
			dr[1] = orderDtlRel.getShipToNum();
			dr[2] = orderDtlRel.getShipToName();
			dr[3] = orderDtlRel.getShipToAdd1();
			dr[4] = orderDtlRel.getPhoneNum();
			dr[5] = orderDtlRel.getQtyOrd().ToString();
			dt.Rows.Add(dr);
		}

		private void calculateQty ()
		{
			double aux = 0;
			IEnumerator enu = _auxOrderDtl.getDtlRelsEnumerator();
			while (enu.MoveNext())
			{
				aux += ((OrderDtlRel)enu.Current).getQtyOrd();
			}
			textBoxOD_QtyOrdSum.Text = NumberUtil.toString(aux,2);
			_auxOrderDtl.setQtyOrdSum(aux);
		}

		private void addDiscount()
		{
			try
			{
				FormDiscounts frm = new FormDiscounts();
				frm.ShowDialog (this);

				if (frm.DialogResult == DialogResult.OK)
				{
					if (_auxOrderDtl == null)
						_auxOrderDtl = new OrderDtl();
					_auxOrderDtl.addNewDtlCharge (frm.orderDtlCharge);
					loadGridCharges (frm.orderDtlCharge);
					loadNetTotal();
				}
			}
			catch (Exception ex)
			{
				FormException frmEx = new FormException (ex);
				frmEx.ShowDialog(this);
			}
		}

		private void addDiscGroup()
		{
			try
			{
				FormGroupDiscounts frm = new FormGroupDiscounts();
				frm.ShowDialog (this);

				if (frm.DialogResult == DialogResult.OK)
				{
					IEnumerator enu = frm.getChargesEnumerator();
					if (_auxOrderDtl == null)
						_auxOrderDtl = new OrderDtl();
					while (enu.MoveNext())
						_auxOrderDtl.addNewDtlCharge ((OrderDtlCharge)enu.Current);
					loadGridCharges ();
					loadNetTotal();
				}
			}
			catch (Exception ex)
			{
				FormException frmEx = new FormException (ex);
				frmEx.ShowDialog(this);
			}
		}

		private void clearDiscounts()
		{
			if (((DataView)dataGridDtlCharges.DataSource).Table.Rows.Count > 0)
			{
				if (MessageBox.Show("This will delete all discount." + "\n" + "Do you wish to proceed?","Warning!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					_auxOrderDtl.removeAllDltCharge();
					loadGridCharges();
					loadNetTotal();
				}
			}
		}

		private void newShipment()
		{
			try
			{
				screenToObject (ref _auxOrderDtl);
				FormNewOrderDtlRel frm = new FormNewOrderDtlRel(_order, _auxOrderDtl);
				frm.ShowDialog(this);


				if (frm.DialogResult == DialogResult.OK)
				{
					_auxOrderDtl.addNewDtlRel (frm.orderDtlRel);
					loadGridRels (frm.orderDtlRel);
					if (_mode.Equals("EDIT"))
						frm.orderDtlRel.setDateAdded (DateTime.Now);
					calculateQty();
				}
			}
			catch (Exception ex)
			{
				FormException frmEx = new FormException (ex);
				frmEx.ShowDialog(this);
			}
		}

		private void editShipment()
		{
			try
			{
				if (dataGridDtlRels.CurrentRowIndex > -1)
				{
					screenToObject (ref _auxOrderDtl);
					FormNewOrderDtlRel frm = new FormNewOrderDtlRel(_order, _auxOrderDtl);
				
					string itemNumRel = (string)dataGridDtlRels[dataGridDtlRels.CurrentRowIndex,0];
					frm.orderDtlRel = _auxOrderDtl.getDtlRelByID (int.Parse(itemNumRel));
					frm.ShowDialog(this);
					calculateQty();
					this.loadGridRels();
				}
			}
			catch (Exception ex)
			{
				FormException frmEx = new FormException (ex);
				frmEx.ShowDialog(this);
			}
		}

		private void removeShipment()
		{
			if (dataGridDtlRels.CurrentRowIndex >= 0)
			{
				if (MessageBox.Show ("The shipment will be deleted." + "\n" + "Do you wish to proceed?","Warning!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					string itemNumRel = (string)dataGridDtlRels[dataGridDtlRels.CurrentRowIndex,0];
					_auxOrderDtl.removeDtlRelByID (int.Parse(itemNumRel));
					calculateQty();
					_auxOrderDtl.recalculate();
					objectToScreen(_auxOrderDtl);
					dataGridDtlRels.CurrentRowIndex = -1;
					dataGridDtlRels.CurrentRowIndex = 0;
				}
			}
		}
		#endregion

		private void buttonOD_Note_Click(object sender, System.EventArgs e)
		{
			addNote();
		}

		private void addNote()
		{
			FormOrderDtlNote formNote = new FormOrderDtlNote(_auxOrderDtl);

			formNote.ShowDialog();
			if (formNote.DialogResult == DialogResult.OK)
				_auxOrderDtl = formNote.getOrderDtl();				
								
			if (_auxOrderDtl.getCountNotes() > 0)
				this.checkBoxOD_Note.Checked = true;
			else
				this.checkBoxOD_Note.Checked = false;
		}


	}
}
