using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Nujit.NujitERP.ClassLib.Util;
using System.Data;

using Nujit.NujitERP.ClassLib.Common;

using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Core.Print;
using Nujit.NujitERP.WinForms.OrderEntry.Invoice;
using Nujit.NujitERP.WinForms.OrderEntry.PackSlip;
using Nujit.NujitERP.WinForms.SearchForms.OrderEntry;

using Nujit.NujitERP.WinForms.Orders;

namespace Nujit.NujitERP.WinForms.Orders
{
	/// <summary>
	/// Summary description for FormOrderSearch.
	/// </summary>
	public class FormOrderSearch : System.Windows.Forms.Form
	{
		private CoreFactory coreFactory;
		private Order[] ordersInGrid;
		private FormMain formParent = null;
		private string user = "";

		#region	Controls
		private System.Windows.Forms.Label labelOH_ID;
		private System.Windows.Forms.TextBox textBoxBillTo;
		private System.Windows.Forms.Label labelBillTo;
		private System.Windows.Forms.Label labelOrderDateFrom;
		private System.Windows.Forms.DateTimePicker dateTimePickerDateFrom;
		private System.Windows.Forms.DateTimePicker dateTimePickerDateTo;
		private System.Windows.Forms.Label labelOrderDateTo;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Panel panelOrder;
		private System.Windows.Forms.ComboBox comboBoxOH_OrderStatus;
		private System.Windows.Forms.Button buttonEdit;
		private System.Windows.Forms.Button buttonRemove;
		private System.Windows.Forms.Button buttonSearch;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonAddNewOrder;
		private System.Windows.Forms.TextBox textBoxOH_OrderNum;
		private System.Windows.Forms.CheckBox chBxPO;
		private System.Windows.Forms.CheckBox chBxQuote;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ContextMenu contextMenuOrders;
		private System.Windows.Forms.MenuItem menuItemAddNew;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItemEditOrder;
		private System.Windows.Forms.MenuItem menuItemRemoveOrder;
		private System.Windows.Forms.CheckBox checkBoxPending;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox checkBoxTimeFrame;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.Button buttonPrint;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion	   Control Vars

		#region Contructors
		public FormOrderSearch()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			coreFactory = UtilCoreFactory.createCoreFactory();
			ordersInGrid = new Order[0];
		}

		public FormOrderSearch(FormMain formParent, string user)
		{
			InitializeComponent();
		
			coreFactory = UtilCoreFactory.createCoreFactory();
			this.MdiParent = formParent;
			this.formParent = formParent;
			this.user = user;
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			coreFactory = null;
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
            this.labelOH_ID = new System.Windows.Forms.Label();
            this.textBoxOH_OrderNum = new System.Windows.Forms.TextBox();
            this.textBoxBillTo = new System.Windows.Forms.TextBox();
            this.comboBoxOH_OrderStatus = new System.Windows.Forms.ComboBox();
            this.labelBillTo = new System.Windows.Forms.Label();
            this.labelOrderDateFrom = new System.Windows.Forms.Label();
            this.dateTimePickerDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDateTo = new System.Windows.Forms.DateTimePicker();
            this.labelOrderDateTo = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.contextMenuOrders = new System.Windows.Forms.ContextMenu();
            this.menuItemAddNew = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItemEditOrder = new System.Windows.Forms.MenuItem();
            this.menuItemRemoveOrder = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.panelOrder = new System.Windows.Forms.Panel();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAddNewOrder = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxPending = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chBxQuote = new System.Windows.Forms.CheckBox();
            this.chBxPO = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxTimeFrame = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.panelOrder.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelOH_ID
            // 
            this.labelOH_ID.Location = new System.Drawing.Point(96, 16);
            this.labelOH_ID.Name = "labelOH_ID";
            this.labelOH_ID.Size = new System.Drawing.Size(66, 20);
            this.labelOH_ID.TabIndex = 0;
            this.labelOH_ID.Text = "Order #:";
            this.labelOH_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOH_OrderNum
            // 
            this.textBoxOH_OrderNum.Location = new System.Drawing.Point(176, 16);
            this.textBoxOH_OrderNum.Name = "textBoxOH_OrderNum";
            this.textBoxOH_OrderNum.Size = new System.Drawing.Size(128, 20);
            this.textBoxOH_OrderNum.TabIndex = 20;
            this.textBoxOH_OrderNum.Text = "";
            this.textBoxOH_OrderNum.TextChanged += new System.EventHandler(this.textBoxOH_OrderNum_TextChanged);
            // 
            // textBoxBillTo
            // 
            this.textBoxBillTo.Location = new System.Drawing.Point(392, 16);
            this.textBoxBillTo.Name = "textBoxBillTo";
            this.textBoxBillTo.Size = new System.Drawing.Size(120, 20);
            this.textBoxBillTo.TabIndex = 30;
            this.textBoxBillTo.Text = "";
            // 
            // comboBoxOH_OrderStatus
            // 
            this.comboBoxOH_OrderStatus.Location = new System.Drawing.Point(176, 36);
            this.comboBoxOH_OrderStatus.Name = "comboBoxOH_OrderStatus";
            this.comboBoxOH_OrderStatus.Size = new System.Drawing.Size(128, 21);
            this.comboBoxOH_OrderStatus.TabIndex = 40;
            // 
            // labelBillTo
            // 
            this.labelBillTo.Location = new System.Drawing.Point(328, 16);
            this.labelBillTo.Name = "labelBillTo";
            this.labelBillTo.Size = new System.Drawing.Size(40, 20);
            this.labelBillTo.TabIndex = 5;
            this.labelBillTo.Text = "Bill To:";
            this.labelBillTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOrderDateFrom
            // 
            this.labelOrderDateFrom.Location = new System.Drawing.Point(32, 16);
            this.labelOrderDateFrom.Name = "labelOrderDateFrom";
            this.labelOrderDateFrom.Size = new System.Drawing.Size(64, 20);
            this.labelOrderDateFrom.TabIndex = 10;
            this.labelOrderDateFrom.Text = "Date From: ";
            this.labelOrderDateFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerDateFrom
            // 
            this.dateTimePickerDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDateFrom.Location = new System.Drawing.Point(96, 16);
            this.dateTimePickerDateFrom.Name = "dateTimePickerDateFrom";
            this.dateTimePickerDateFrom.Size = new System.Drawing.Size(96, 20);
            this.dateTimePickerDateFrom.TabIndex = 20;
            // 
            // dateTimePickerDateTo
            // 
            this.dateTimePickerDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDateTo.Location = new System.Drawing.Point(248, 16);
            this.dateTimePickerDateTo.Name = "dateTimePickerDateTo";
            this.dateTimePickerDateTo.Size = new System.Drawing.Size(96, 20);
            this.dateTimePickerDateTo.TabIndex = 30;
            // 
            // labelOrderDateTo
            // 
            this.labelOrderDateTo.Location = new System.Drawing.Point(200, 16);
            this.labelOrderDateTo.Name = "labelOrderDateTo";
            this.labelOrderDateTo.Size = new System.Drawing.Size(48, 20);
            this.labelOrderDateTo.TabIndex = 8;
            this.labelOrderDateTo.Text = "Date To: ";
            this.labelOrderDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, 0);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(936, 344);
            this.dataGrid1.TabIndex = 90;
            this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
            this.dataGrid1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGrid1_MouseUp);
            // 
            // contextMenuOrders
            // 
            this.contextMenuOrders.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                              this.menuItemAddNew,
                                                                                              this.menuItem2,
                                                                                              this.menuItemEditOrder,
                                                                                              this.menuItemRemoveOrder,
                                                                                              this.menuItem1,
                                                                                              this.menuItem4,
                                                                                              this.menuItem5,
                                                                                              this.menuItem3});
            // 
            // menuItemAddNew
            // 
            this.menuItemAddNew.Index = 0;
            this.menuItemAddNew.Text = "Add New";
            this.menuItemAddNew.Click += new System.EventHandler(this.menuItemAddNew_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "-";
            // 
            // menuItemEditOrder
            // 
            this.menuItemEditOrder.Index = 2;
            this.menuItemEditOrder.Text = "Edit Order";
            this.menuItemEditOrder.Click += new System.EventHandler(this.menuItemEditOrder_Click);
            // 
            // menuItemRemoveOrder
            // 
            this.menuItemRemoveOrder.Index = 3;
            this.menuItemRemoveOrder.Text = "Remove Order";
            this.menuItemRemoveOrder.Click += new System.EventHandler(this.menuItemRemoveOrder_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 4;
            this.menuItem1.Text = "-";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 5;
            this.menuItem4.Text = "Print";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 6;
            this.menuItem5.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 7;
            this.menuItem3.Text = "Send To CMS";
            // 
            // panelOrder
            // 
            this.panelOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOrder.Controls.Add(this.dataGrid1);
            this.panelOrder.Location = new System.Drawing.Point(8, 168);
            this.panelOrder.Name = "panelOrder";
            this.panelOrder.Size = new System.Drawing.Size(936, 344);
            this.panelOrder.TabIndex = 11;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(752, 112);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.TabIndex = 70;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.buttonPrint);
            this.panel1.Controls.Add(this.buttonRemove);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonEdit);
            this.panel1.Controls.Add(this.buttonAddNewOrder);
            this.panel1.Location = new System.Drawing.Point(8, 520);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(936, 24);
            this.panel1.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(328, 0);
            this.button3.Name = "button3";
            this.button3.TabIndex = 126;
            this.button3.Text = "PackSlip";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(416, 1);
            this.button4.Name = "button4";
            this.button4.TabIndex = 125;
            this.button4.Text = "WO";
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(504, 0);
            this.button5.Name = "button5";
            this.button5.TabIndex = 124;
            this.button5.Text = "Invoice";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(24, 0);
            this.button2.Name = "button2";
            this.button2.TabIndex = 123;
            this.button2.Text = "Copy";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(120, 1);
            this.button1.Name = "button1";
            this.button1.TabIndex = 122;
            this.button1.Text = "Request";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrint.Location = new System.Drawing.Point(208, 0);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.TabIndex = 121;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.Location = new System.Drawing.Point(768, 0);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.TabIndex = 110;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(856, 0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.TabIndex = 120;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.Location = new System.Drawing.Point(680, 0);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.TabIndex = 100;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonAddNewOrder
            // 
            this.buttonAddNewOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddNewOrder.Location = new System.Drawing.Point(592, 0);
            this.buttonAddNewOrder.Name = "buttonAddNewOrder";
            this.buttonAddNewOrder.Size = new System.Drawing.Size(72, 23);
            this.buttonAddNewOrder.TabIndex = 80;
            this.buttonAddNewOrder.Text = "Add ";
            this.buttonAddNewOrder.Click += new System.EventHandler(this.buttonAddNewOrder_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBox8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.textBox6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textBox7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBox5);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.checkBoxPending);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.labelBillTo);
            this.panel2.Controls.Add(this.comboBoxOH_OrderStatus);
            this.panel2.Controls.Add(this.textBoxBillTo);
            this.panel2.Controls.Add(this.textBoxOH_OrderNum);
            this.panel2.Controls.Add(this.labelOH_ID);
            this.panel2.Controls.Add(this.buttonSearch);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Location = new System.Drawing.Point(8, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(840, 144);
            this.panel2.TabIndex = 0;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(560, 36);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(80, 20);
            this.textBox8.TabIndex = 98;
            this.textBox8.Text = "";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(520, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 16);
            this.label9.TabIndex = 97;
            this.label9.Text = "CSR:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(560, 16);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(80, 20);
            this.textBox6.TabIndex = 96;
            this.textBox6.Text = "";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(520, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 95;
            this.label7.Text = "Order:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(656, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 24);
            this.label8.TabIndex = 93;
            this.label8.Text = "Data Base:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(720, 56);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(80, 20);
            this.textBox7.TabIndex = 94;
            this.textBox7.Text = "";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(96, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 24);
            this.label6.TabIndex = 89;
            this.label6.Text = "Sales Person:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(176, 57);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(128, 20);
            this.textBox5.TabIndex = 90;
            this.textBox5.Text = "";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(328, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 87;
            this.label5.Text = "Ship From:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(392, 56);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(120, 20);
            this.textBox4.TabIndex = 88;
            this.textBox4.Text = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(328, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 85;
            this.label4.Text = "Ship To:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(392, 36);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(120, 20);
            this.textBox3.TabIndex = 86;
            this.textBox3.Text = "";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(720, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(80, 20);
            this.textBox2.TabIndex = 84;
            this.textBox2.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(720, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(80, 20);
            this.textBox1.TabIndex = 83;
            this.textBox1.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(656, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 82;
            this.label3.Text = "Plant:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(656, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 81;
            this.label2.Text = "Company:";
            // 
            // checkBoxPending
            // 
            this.checkBoxPending.Location = new System.Drawing.Point(480, 112);
            this.checkBoxPending.Name = "checkBoxPending";
            this.checkBoxPending.Size = new System.Drawing.Size(144, 20);
            this.checkBoxPending.TabIndex = 45;
            this.checkBoxPending.Text = "Pending orders to CMS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chBxQuote);
            this.groupBox1.Controls.Add(this.chBxPO);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(72, 72);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type";
            // 
            // chBxQuote
            // 
            this.chBxQuote.Checked = true;
            this.chBxQuote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBxQuote.Location = new System.Drawing.Point(8, 40);
            this.chBxQuote.Name = "chBxQuote";
            this.chBxQuote.Size = new System.Drawing.Size(56, 24);
            this.chBxQuote.TabIndex = 20;
            this.chBxQuote.Text = "Quote";
            // 
            // chBxPO
            // 
            this.chBxPO.Checked = true;
            this.chBxPO.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBxPO.Location = new System.Drawing.Point(8, 16);
            this.chBxPO.Name = "chBxPO";
            this.chBxPO.Size = new System.Drawing.Size(52, 24);
            this.chBxPO.TabIndex = 10;
            this.chBxPO.Text = "Order";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(96, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Order Status:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePickerDateFrom);
            this.groupBox2.Controls.Add(this.labelOrderDateFrom);
            this.groupBox2.Controls.Add(this.dateTimePickerDateTo);
            this.groupBox2.Controls.Add(this.labelOrderDateTo);
            this.groupBox2.Controls.Add(this.checkBoxTimeFrame);
            this.groupBox2.Location = new System.Drawing.Point(96, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 48);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Time Frame";
            // 
            // checkBoxTimeFrame
            // 
            this.checkBoxTimeFrame.Checked = true;
            this.checkBoxTimeFrame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTimeFrame.Location = new System.Drawing.Point(8, 16);
            this.checkBoxTimeFrame.Name = "checkBoxTimeFrame";
            this.checkBoxTimeFrame.Size = new System.Drawing.Size(16, 20);
            this.checkBoxTimeFrame.TabIndex = 82;
            // 
            // FormOrderSearch
            // 
            this.AcceptButton = this.buttonSearch;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(952, 550);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelOrder);
            this.Name = "FormOrderSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Order\'s Maintenance";
            this.SizeChanged += new System.EventHandler(this.FormOrderSearch_SizeChanged);
            this.Load += new System.EventHandler(this.FormOrderSearch_Load);
            this.Closed += new System.EventHandler(this.OnClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.panelOrder.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

		#region Events
		private void FormOrderSearch_Load(object sender, System.EventArgs e)
		{
			SetValues();
			LoadOHOrderStatus();
			InitialDataGrid();
		}

		private void buttonSearch_Click(object sender, System.EventArgs e)
		{
			this.doSearch();
		}      
	
		private void buttonAddNewOrder_Click(object sender, System.EventArgs e)
		{
			this.addNew();
		}

		private void OnClosed(object sender, System.EventArgs e)
		{
/*			if (this.formMainParent != null)
			{
				this.formMainParent.RemoveTab(this.Tag);
				this.formMainParent.SetButtons();
			}	
*/		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void textBoxOH_OrderNum_TextChanged(object sender, System.EventArgs e)
		{
			this.hasToBeInteger (textBoxOH_OrderNum);
		}

		private void buttonSelect_Click(object sender, System.EventArgs e)
		{
			editOrder();
		}

		private void buttonRemove_Click(object sender, System.EventArgs e)
		{
			removeOrder();
		}

		private void menuItemAddNew_Click(object sender, System.EventArgs e)
		{
			this.addNew();
		}

		private void menuItemEditOrder_Click(object sender, System.EventArgs e)
		{
			this.editOrder();
		}

		private void menuItemRemoveOrder_Click(object sender, System.EventArgs e)
		{
			this.removeOrder();
		}

		private void dataGrid1_DoubleClick(object sender, EventArgs e)
		{
			System.Windows.Forms.DataGrid.HitTestInfo hti = dataGrid1.HitTest(dataGrid1.PointToClient(MousePosition)); 
			if (hti.Type == DataGrid.HitTestType.RowHeader)
				this.editOrder();
		}

		private void dataGrid1_MouseUp(object sender, MouseEventArgs e)
		{
			System.Windows.Forms.DataGrid.HitTestInfo hti = dataGrid1.HitTest(new Point(e.X, e.Y)); 
			if ((e.Button == MouseButtons.Right) && ((hti.Type == DataGrid.HitTestType.RowHeader) || (hti.Type == DataGrid.HitTestType.Cell)))
			{
				dataGrid1.UnSelect(dataGrid1.CurrentRowIndex);
				menuItemEditOrder.Enabled = true;
				menuItemRemoveOrder.Enabled = true;
				dataGrid1.CurrentRowIndex = hti.Row;
				dataGrid1.Select(hti.Row);
				contextMenuOrders.Show(dataGrid1,new Point(e.X,e.Y));
			}
			else if (e.Button == MouseButtons.Right)
			{
				menuItemEditOrder.Enabled = false;
				menuItemRemoveOrder.Enabled = false;
				contextMenuOrders.Show(dataGrid1,new Point(e.X,e.Y));
			}
			if ((e.Button == MouseButtons.Left) && (hti.Type == DataGrid.HitTestType.Cell))
			{
				dataGrid1.CurrentRowIndex = hti.Row;
				dataGrid1.Select(hti.Row);
			}
		}
/******************** IF WE WANT GRID COLUMNS TO ADJUST TO GRID'S WIDTH ****************

 		private void dataGrid1_Paint(object sender, PaintEventArgs e)
		{
			dataGrid1.TableStyles[0].GridColumnStyles[0].Width = (int)Math.Floor((dataGrid1.Size.Width - dataGrid1.RowHeaderWidth) * 0.00);
			dataGrid1.TableStyles[0].GridColumnStyles[1].Width = (int)Math.Floor((dataGrid1.Size.Width - dataGrid1.RowHeaderWidth) * 0.09);
			dataGrid1.TableStyles[0].GridColumnStyles[2].Width = (int)Math.Floor((dataGrid1.Size.Width - dataGrid1.RowHeaderWidth) * 0.09);
			dataGrid1.TableStyles[0].GridColumnStyles[3].Width = (int)Math.Floor((dataGrid1.Size.Width - dataGrid1.RowHeaderWidth) * 0.08);
			dataGrid1.TableStyles[0].GridColumnStyles[4].Width = (int)Math.Floor((dataGrid1.Size.Width - dataGrid1.RowHeaderWidth) * 0.09);
			dataGrid1.TableStyles[0].GridColumnStyles[5].Width = (int)Math.Floor((dataGrid1.Size.Width - dataGrid1.RowHeaderWidth) * 0.09);
			dataGrid1.TableStyles[0].GridColumnStyles[6].Width = (int)Math.Floor((dataGrid1.Size.Width - dataGrid1.RowHeaderWidth) * 0.10);
			dataGrid1.TableStyles[0].GridColumnStyles[7].Width = (int)Math.Floor((dataGrid1.Size.Width - dataGrid1.RowHeaderWidth) * 0.10);
			dataGrid1.TableStyles[0].GridColumnStyles[8].Width = (int)Math.Floor((dataGrid1.Size.Width - dataGrid1.RowHeaderWidth) * 0.08);
			dataGrid1.TableStyles[0].GridColumnStyles[9].Width = (int)Math.Floor((dataGrid1.Size.Width - dataGrid1.RowHeaderWidth) * 0.08);
			dataGrid1.TableStyles[0].GridColumnStyles[10].Width = (int)Math.Floor((dataGrid1.Size.Width - dataGrid1.RowHeaderWidth) * 0.10);

			int widthLast = dataGrid1.Size.Width - dataGrid1.RowHeaderWidth;
			for (int i=0; i < 11; i++)
				widthLast -= dataGrid1.TableStyles[0].GridColumnStyles[i].Width;
			dataGrid1.TableStyles[0].GridColumnStyles[11].Width = widthLast - 4;
		}
*/

//		private void menuItem3_Click(object sender, System.EventArgs e)
//		{
//			sendSelectedToCMS();
//		}

//		private void buttonSendToCMS_Click(object sender, System.EventArgs e)
//		{
//			sendSelectedToCMS(); Lo sacamos a pedido de chuck
//		}

//		private void buttonSendAll_Click(object sender, System.EventArgs e)
//		{
//			sendAllToCMS();
//		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			printOrders();
		}

		private void buttonPrint_Click(object sender, System.EventArgs e)
		{
			printOrders();
		}

		private void FormOrderSearch_SizeChanged(object sender, EventArgs e)
		{
			panel2.Location = new Point((this.ClientSize.Width - panel2.Size.Width) / 2,panel2.Location.Y);
		}
		#endregion

		#region Methods
		
		private void   LoadOHOrderStatus()
		{
			fillCombo(this.comboBoxOH_OrderStatus,"ALL");
			comboBoxOH_OrderStatus.SelectedIndex = 0;
		}

		private void fillCombo (ComboBox lst, string strAllNoneNormal)
		{
			DataTable dt = new DataTable();

			dt.Columns.Add("DisplayMember");
			dt.Columns.Add("ValueMember");

			DataRow dr = dt.NewRow();

			if(strAllNoneNormal == "ALL")
			{
				dr = dt.NewRow();
				dr["DisplayMember"] = "All";
				dr["ValueMember"]   = "";
				dt.Rows.Add(dr);  	
			}

			dr = dt.NewRow();
			dr["DisplayMember"] = "N - New";//"Created"; 
			dr["ValueMember"]   = Constants.ORDER_STATUS_CREATED;//See the correct value
			dt.Rows.Add(dr);  

			dr = dt.NewRow();
			dr["DisplayMember"] = "A - Active";//"Finished";
			dr["ValueMember"]   = Constants.ORDER_STATUS_FINISHED; //See the correct value
			dt.Rows.Add(dr); 
 
			dr = dt.NewRow();
			dr["DisplayMember"] = "C - Complete";//"Removed";
			dr["ValueMember"]   = Constants.ORDER_STATUS_REMOVED; //See the correct value
			dt.Rows.Add(dr);  
	
	        //----------------------
	        dr = dt.NewRow();
			dr["DisplayMember"] = "B - Backordered";//"Removed";
			dr["ValueMember"]   = Constants.ORDER_STATUS_REMOVED; //See the correct value
			dt.Rows.Add(dr);  
	
	        dr = dt.NewRow();
			dr["DisplayMember"] = "H - Held";//"Removed";
			dr["ValueMember"]   = Constants.ORDER_STATUS_REMOVED; //See the correct value
			dt.Rows.Add(dr);  
	        //-----------------------------------
			lst.DataSource    = dt.DefaultView; 
			lst.DisplayMember = "DisplayMember";
			lst.ValueMember   = "ValueMember";

			lst.SelectedValue = "ALL";
		}

		private void SetValues()
		{
			this.dateTimePickerDateFrom.Value = DateTime.Now.AddDays(-30);
		
		}

		private void InitialDataGrid()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Order ID", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Order Num", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Quote Num", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
			dataTable.Columns.Add(new DataColumn("STS", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Order Date", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date Required", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Status", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Pocket ID", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Company", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Bill To", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Ship To", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Order", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Currency", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Net Total.", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Total.", typeof(string)));
	
			DataView dataView = new DataView(dataTable);
			dataView.AllowEdit = false;
			dataView.AllowDelete = false;
			dataView.AllowNew = false;

			dataGrid1.DataSource = dataView;
			dataGrid1.PreferredColumnWidth = 150;
			dataGrid1.ReadOnly = true;
			dataGrid1.TableStyles.Clear();
			dataGrid1.TableStyles.Add(new DataGridTableStyle());
			
			GridColumnStylesCollection	colStyle;
			colStyle				= dataGrid1.TableStyles[0].GridColumnStyles;		
			colStyle[0].Width      	= 0; //Hidden
			colStyle[1].Width      	= 70;
			colStyle[2].Width		= 70;
			colStyle[3].Width		= 0; //Hidden delete after
			colStyle[4].Width		= 40; //STS new column
			colStyle[5].Width		= 90;
			colStyle[6].Width		= 90; //Date Requiered
			colStyle[7].Width		= 0;//Status is hide
			colStyle[8].Width		= 80;
			colStyle[9].Width		= 0;//Company 
			colStyle[10].Width		= 185;
			colStyle[11].Width		= 185;
			colStyle[12].Width     	= 80;
			colStyle[13].Width		= 65;
			colStyle[14].Width		= 0;//Hidden delete after	
			//colStyle[14].Alignment = HorizontalAlignment.Right; //Hidden delete after
			colStyle[15].Width		= 0;//Hidden delete after	
			//colStyle[15].Alignment = HorizontalAlignment.Right;
			dataGrid1.Refresh();
		}

		private void doSearch()
		{
			// Makes DateTo, so that it is included in the search.
			DateTime dtTo, dtFrom;
			if (checkBoxTimeFrame.Checked)
			{
				dtTo = new DateTime(dateTimePickerDateTo.Value.Year,dateTimePickerDateTo.Value.Month,dateTimePickerDateTo.Value.Day,23,59,59);
				dtFrom = dateTimePickerDateFrom.Value;
			}
			else
			{
				dtTo = DateUtil.MinValue;
				dtFrom = DateUtil.MinValue;
			}
			// Create the search string according to the type
			string orderType = "NOTHING";
			if (chBxPO.Checked && chBxQuote.Checked)
				orderType = "";
			else
			{
				if (chBxPO.Checked)
					orderType = Constants.ORDER_TYPE_ORDER;
				if (chBxQuote.Checked)
					orderType = Constants.ORDER_TYPE_QUOTE;
			}

			ordersInGrid = new Order[0];

			if ((!textBoxOH_OrderNum.Text.Equals(string.Empty)) && (!NumberUtil.isIntegerNumber(textBoxOH_OrderNum.Text)))
				MessageBox.Show ("Order number invalid.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			else
			{
				int auxOrderNum;
				if (textBoxOH_OrderNum.Text.Equals(string.Empty))
					auxOrderNum = 0;
				else
					auxOrderNum = int.Parse(textBoxOH_OrderNum.Text);
				try
				{
				ordersInGrid = coreFactory.readOrdersHeaders(textBoxBillTo.Text,"",
					dtFrom, dtTo,"",comboBoxOH_OrderStatus.SelectedValue.ToString(),
					orderType,auxOrderNum, checkBoxPending.Checked);
				}
				catch (Exception ex)
				{
					FormException frmEx = new FormException(ex);
					frmEx.ShowDialog(this);
				}
			}
			DataTable dt = ((DataView)dataGrid1.DataSource).Table;
			dt.Rows.Clear();
			int pendingOrders = 0;
			for (int i=0; i<ordersInGrid.Length; i++)
			{
				DataRow dr = dt.NewRow();
				dr[0] = ordersInGrid[i].getId();
				dr[1] = ordersInGrid[i].getOrderNum();
				dr[2] = ordersInGrid[i].getQuote();;
				dr[3] = ordersInGrid[i].getOrderType();
				dr[4] = "";
				dr[5] = DateUtil.getDateRepresentation(ordersInGrid[i].getOrderDate(),DateUtil.MMDDYYYY);
				dr[6] = "";//DateRequiered New
				dr[7] = ordersInGrid[i].getOrderStatusCompleteString();
				dr[8] = ordersInGrid[i].getOrgId();
				dr[9] = ordersInGrid[i].getCompany();
				dr[10] = ordersInGrid[i].getBillToNum() + " - " + ordersInGrid[i].getBillToName();
				dr[11] = "";//ordersInGrid[i].getShipVia(); ShipTo
				dr[12] = ordersInGrid[i].getPO();
				dr[13] = ordersInGrid[i].getCurrency();
				dr[14] = NumberUtil.toString(ordersInGrid[i].getOrderNet(),2);
				dr[15] = NumberUtil.toString(ordersInGrid[i].getOrderTotal(),2);
				dt.Rows.Add(dr);
				if (ordersInGrid[i].getSentToCMS().Equals(Constants.STRING_NO))
					pendingOrders++;
			}
			dataGrid1.CaptionText = ordersInGrid.Length.ToString() + " orders found.";
			if (pendingOrders > 0)
				dataGrid1.CaptionText += " There are " + pendingOrders.ToString() + " still pending to be sent to CMS.";
		}

		private void hasToBeInteger (TextBox textBox)
		{
			if (!textBox.Text.Equals(string.Empty) && !NumberUtil.isIntegerNumber(textBox.Text))
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
				textBox.SelectionStart = pos;
				textBox.SelectionLength = len;
			}
		}

		private void addNew ()
		{
			try
			{
				FormAddNewOrder form = new FormAddNewOrder();
				form.ShowDialog();
				form.Dispose();
			}
			catch (Exception ex)
			{
				FormException frm = new FormException (ex);
				frm.ShowDialog(this);
			}
		}

		private void editOrder()
		{
			if (dataGrid1.CurrentRowIndex >= 0)
			{
				try
				{
					string orderIDStr = (string)dataGrid1[dataGrid1.CurrentRowIndex,0];
					Order order = coreFactory.readOrderHeaderAllData(int.Parse(orderIDStr));

					if (order.getOrderStatus().Equals(Constants.ORDER_STATUS_REMOVED))
					{
						MessageBox.Show ("This order can't be editted. It has been removed.","Attention",MessageBoxButtons.OK,MessageBoxIcon.Stop);
					}
					else
					{
						if (order.getSentToCMS().Equals(Constants.STRING_YES))
						{
							MessageBox.Show ("This order can't be editted. It has been sent to CMS.","Attention",MessageBoxButtons.OK,MessageBoxIcon.Stop);
						}
						else
						{
							FormEditOrder frm = new FormEditOrder(order);
							frm.ShowDialog();

							if (frm.DialogResult == DialogResult.OK)
							{
								coreFactory.updateOrderHeader (order);
							}
						}
					}

					this.doSearch();
				}
				catch (Exception ex)
				{
					FormException frmEx = new FormException(ex);
					frmEx.ShowDialog(this);
				}
			}
		}

		private void removeOrder()
		{
			if (dataGrid1.CurrentRowIndex >= 0)
			{
				if (MessageBox.Show("The order entry will be deleted." + "\n" + "Do you wish to proceed?","Warning!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					try
					{
						string orderIDStr = (string)dataGrid1[dataGrid1.CurrentRowIndex,0];
						Order order = new Order();
						order.setId (int.Parse(orderIDStr));
						coreFactory.deleteOrderHeader(order);
						doSearch();
					}
					catch (Exception ex)
					{
						FormException frmEx = new FormException(ex);
						frmEx.ShowDialog(this);
					}
				}
			}
		}

		private Order getOrderFromArray (int iOrderID)
		{
			//***** Array is sorted: This method should be transformed into a binary search
			int i=0;
			bool found = false;
			Order seeked = null;
			while ((i<ordersInGrid.Length) && !found)
			{
				if (ordersInGrid[i].getId() == iOrderID)
				{
					found=true;
					seeked = ordersInGrid[i];
				}
				i++;
			}
			return seeked;
		}

//		private void sendToCMS (ArrayList ordersList)
//		{
//			try
//			{
//				this.Cursor = Cursors.WaitCursor;
//
//				string ordersSent = "";
//				string ordersNotSent = "";
//				string ordersAlreadySent = "";
//				int countOrdersSent = 0;
//				int countOrdersNotSent = 0;
//				int countOrdersAlreadySent = 0;
//
//				if (ordersList.Count > 0)
//				{
//					for (int i=0; i<ordersList.Count; i++)
//					{
//						Order order = coreFactory.readOrderHeaderAllData(((Order)ordersList[i]).getId());
//						if (order.getSentToCMS().Equals(Constants.STRING_YES))
//						{
//							countOrdersAlreadySent++;
//							ordersAlreadySent += "   Id: " + order.getId().ToString() + "\n";
//						}
//						else
//						{
//							if (coreFactory.sendOrderToCMS(order, user))
//							{
//								countOrdersSent++;
//								ordersSent += "   Id: " + order.getId().ToString() + "\n";
//							}
//							else
//							{
//								countOrdersNotSent++;
//								ordersNotSent += "   Id: " + order.getId().ToString() + "\n";
//							}
//						}
//					}
//					string log = "";
//					if (countOrdersSent > 0)
//					{
//						log += countOrdersSent.ToString() + " order(s) succesfully sent:" + "\n";
//						log += ordersSent + "\n";
//					}
//					else
//						log += "No orders could be sent." + "\n\n";
//
//					if (countOrdersNotSent > 0)
//					{
//						log += countOrdersNotSent.ToString() + " order(s) couldn't be sent:" + "\n";
//						log += ordersNotSent + "\n";
//					}
//
//					if (countOrdersAlreadySent > 0)
//					{
//						log += countOrdersAlreadySent.ToString() + " order(s) were already in CMS:" + "\n";
//						log += ordersAlreadySent + "\n";
//					}
//
//					MessageBox.Show (log,"Transfer log");
//				}
//				else
//					MessageBox.Show("No orders selected.");
//				this.Cursor = Cursors.Default;
//			}
//			catch(Exception exc)
//			{
//				this.Cursor = Cursors.Default;
//				
//				FormException fe = new FormException(exc);
//				fe.ShowDialog();
//			}
//		}

		private ArrayList getSelectedOrders()
		{
			ArrayList selectedOrders = new ArrayList();
			for (int i=0; i<((DataView)dataGrid1.DataSource).Table.Rows.Count; i++)
				if (dataGrid1.IsSelected(i))
					selectedOrders.Add(this.getOrderFromArray(int.Parse((string)dataGrid1[i,0])));

			if ((selectedOrders.Count == 0) && (dataGrid1.CurrentRowIndex > -1))
				selectedOrders.Add(this.getOrderFromArray(int.Parse((string)dataGrid1[dataGrid1.CurrentRowIndex,0])));

			return selectedOrders;
		}
		
//		private void sendSelectedToCMS()
//		{
//			sendToCMS (getSelectedOrders());
//		}

//		private void sendAllToCMS()
//		{
//			ArrayList allOrders = new ArrayList(ordersInGrid);
//			sendToCMS(allOrders);
//		}

		private bool printOrders ()
		{
			ArrayList selectedOrders = getSelectedOrders();			

			PrintServerOrder		printSOrderReport= new PrintServerOrder();
			Cash					cash = new Cash(coreFactory);
			Order					order = null;
			Person					billPerson = null;
			Person					shipPerson = null;
			Employee				employee = null;
			int						iorderNum=0;			
			string					sprintFile= Configuration.ReportPath + "Print.prn";
			string					sErrorToSend="";
			bool					bresult=true;
			int						i=0;
			string					message = "";
			
			if (selectedOrders.Count == 0)
				MessageBox.Show ("No orders selected.");
			else
			{
				while ((i < selectedOrders.Count) && (bresult))
				{
					iorderNum = ((Order)selectedOrders[i]).getId();
					if (!cash.loadOrder(iorderNum, out order, out billPerson, out shipPerson, out employee))
					{
						message = "Cannot load order.";
						bresult = false;
					}
					else
					{				
						printSOrderReport.processReport(cash.getBillPerson(),
														cash.getShipPerson(),
														cash.getEmployee(),
														cash.getOrder(),		
														1);
						bresult=false;

						if (printSOrderReport.createPrintFile(sprintFile))										
							bresult = printSOrderReport.print(sprintFile,out sErrorToSend);

						if (bresult && cash.getOrder().getOrderStatus().Equals(Constants.ORDER_STATUS_CREATED)
							&& cash.getOrder().getOrderType().Equals(Constants.ORDER_TYPE_ORDER))
						{
							cash.getOrder().setOrderStatus (Constants.ORDER_STATUS_FINISHED);
							coreFactory.writeCompleteOrder (cash.getOrder());
						}
					}
					if (!bresult)
						message = "Printer error.";
					i++;
				}
			}
			if (bresult)
				MessageBox.Show ("Printing complete.");
			else
				MessageBox.Show ("There was a problem on order " + iorderNum.ToString() + ".\n" + message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			return bresult;
		}
		#endregion Methods

private void button5_Click(object sender, System.EventArgs e){
    AllInvoiceHdrForm allInvoiceHdrForm= new AllInvoiceHdrForm();
    allInvoiceHdrForm.ShowDialog();
    
}

private void button3_Click(object sender, System.EventArgs e){
    AllPackSlipHdrForm allPackSlipHdrForm= new AllPackSlipHdrForm();
    allPackSlipHdrForm.ShowDialog();

}

private void button1_Click(object sender, System.EventArgs e)        {
    RequestSearchForm requestSearchForm= new RequestSearchForm();
    requestSearchForm.ShowDialog();
}

     
	}
}
