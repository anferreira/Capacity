using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.WinForms.SearchForms;


namespace Nujit.NujitERP.WinForms.OrderEntry.Invoice{
	
	public class InvoiceDtlEditForm : System.Windows.Forms.Form	{
        private System.Windows.Forms.Label lIHInvoiceTotal;
        private System.Windows.Forms.Label lIvCredit;
        private NujitCustomWinControls.NumericTextBox ntbIHInvTotal;
        private NujitCustomWinControls.NumericTextBox ntboxID_Company;
        private System.Windows.Forms.TextBox tBoxID_Plant;
        private System.Windows.Forms.TextBox tBoxID_DataBase;
        private System.Windows.Forms.Label lIDInvoiceNum;
        private System.Windows.Forms.Label lIDPlant;
        private System.Windows.Forms.Label lIDCompany;
        private System.Windows.Forms.Label lIDDb;
        private System.Windows.Forms.Label lIHInvType;
        private System.Windows.Forms.TextBox tBoxIH_InvType;
        private System.Windows.Forms.DateTimePicker dtpIH_InvDate;
        private System.Windows.Forms.Label lIhInvDate;
        private System.Windows.Forms.TextBox textBox1;
        private NujitCustomWinControls.NumericTextBox ntboxID_InvoiceNum;
        private NujitCustomWinControls.NumericTextBox ntbID_OrderNum;
        private System.Windows.Forms.Label lIDOrderNum;
        private System.Windows.Forms.Label lIDInvLineNum;
        private NujitCustomWinControls.NumericTextBox ntbID_InvLineNum;
        private NujitCustomWinControls.NumericTextBox ntbID_OrderItemNum;
        private System.Windows.Forms.Label lIDOrderItemNum;
        private NujitCustomWinControls.NumericTextBox numericTextBox1;
        private System.Windows.Forms.Label lIDReleaseNum;
        private System.Windows.Forms.GroupBox gBoxBtns;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabControl tabControlInvDtl;
        private System.Windows.Forms.TabPage tabPagePart;
        private System.Windows.Forms.TextBox tBoxID_UPUom;
        private System.Windows.Forms.Label lIDUpUom;
        private NujitCustomWinControls.NumericTextBox ntbID_UnitPrice;
        private System.Windows.Forms.Label lIDUnitPrice;
        private NujitCustomWinControls.NumericTextBox ntbID_LineExt;
        private System.Windows.Forms.Label lIDLineExt;
        private System.Windows.Forms.TextBox tBoxID_Description;
        private System.Windows.Forms.Label lIDDescription;
        private System.Windows.Forms.TabPage tabPageAccounting;
        private System.Windows.Forms.TabPage tabPageComponentList;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lIDComponentList;
        private System.Windows.Forms.GroupBox gBoxPart;
        private System.Windows.Forms.Button btnSchCustPart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lIDPart;
        private System.Windows.Forms.TextBox tBoxID_Revision;
        private System.Windows.Forms.Label lIDRevision;
        private System.Windows.Forms.TextBox tBoxID_Part;
        private System.Windows.Forms.Label lIDSequence;
        private System.Windows.Forms.TextBox tBoxID_CustPart;
        private System.Windows.Forms.Label lIDCustPart;
        private System.Windows.Forms.TextBox tBoxID_Sequence;
        private System.Windows.Forms.TabPage tabPageShippmet;
        private System.Windows.Forms.GroupBox gBoxQty;
        private NujitCustomWinControls.NumericTextBox ntbID_QtyShipped;
        private System.Windows.Forms.Label lIDQtyOutstand;
        private NujitCustomWinControls.NumericTextBox ntbID_Qty_Outstand;
        private System.Windows.Forms.Label lIDQtyBackOrder;
        private System.Windows.Forms.Label label2;
        private NujitCustomWinControls.NumericTextBox ntbID_QtyShipInv;
        private System.Windows.Forms.Label lIDQtyShipInv;
        private System.Windows.Forms.Label lIDQSIUom;
        private System.Windows.Forms.Label lIDQtyShipped;
        private NujitCustomWinControls.NumericTextBox ntbID_QtyBackOrder;
        private System.Windows.Forms.Button btnSchUomQsi;
        private System.Windows.Forms.TextBox tBoxID_QSUom;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnSchUom;
        private NujitCustomWinControls.NumericTextBox ntbID_DiscountAmt;
        private System.Windows.Forms.Label lIDDiscountAmt;
        private System.Windows.Forms.GroupBox gBoxShip;
        private System.Windows.Forms.Label label4;
        private NujitCustomWinControls.NumericTextBox ntbID_PackingSlip;
        private System.Windows.Forms.Label lIDPackingSlip;
        private NujitCustomWinControls.NumericTextBox ntbID_PackingSlipLin;
        private System.Windows.Forms.Label lIdPackingSlipLin;
        private System.Windows.Forms.DateTimePicker dtpID_DateShipped;
        private System.Windows.Forms.Label lIDDateShipped;
        private System.Windows.Forms.Button schStkLoc;
        private System.Windows.Forms.Label lIDShipStkLoc;
        private System.Windows.Forms.TextBox tBoxID_ShipStkLoc;
        private System.Windows.Forms.Button btnSchPlant;
        private System.Windows.Forms.TextBox tBoxID_ShipPlant;
        private System.Windows.Forms.Label lIDShipPlant;
        private System.Windows.Forms.Button btnSchCompany;
        private NujitCustomWinControls.NumericTextBox ntbID_ShipCompany;
        private System.Windows.Forms.Label lIDShipCompany;
        private System.Windows.Forms.TextBox tBoxID_GLSalesAcc;
        private System.Windows.Forms.Label lIDGLCosAcc;
        private System.Windows.Forms.TextBox tBoxID_GLCosAcc;
        private System.Windows.Forms.TextBox tBoxID_GLCosType;
        private System.Windows.Forms.Label lIDGLSalesAcc;
        private System.Windows.Forms.Label lIDGLCosType;
        private System.Windows.Forms.GroupBox gBoxOthersSC;
        private System.Windows.Forms.Label lIdCustRan;
        private System.Windows.Forms.TextBox tBoxID_CustRan;
        private System.Windows.Forms.Label lIDManuPart;
        private System.Windows.Forms.TextBox tBoxID_ManuPart;
        private System.Windows.Forms.Button btnSchManuPart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBoxID_Manufacturer;
        private System.Windows.Forms.Button btnSchMgf;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox gBoxCost;
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
        private System.Windows.Forms.TabPage tabPageSales;
        private System.Windows.Forms.GroupBox gBoxSalesCode;
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
        private System.Windows.Forms.Label label1;
        private NujitCustomWinControls.NumericTextBox numericTextBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private NujitCustomWinControls.NumericTextBox ntbID_PriceBefDis;
        private System.Windows.Forms.Label lIdPriceBefDis;
        private NujitCustomWinControls.NumericTextBox numericTextBox4;
        private System.Windows.Forms.Label label8;
        private NujitCustomWinControls.NumericTextBox ntbID_QtyReturned;
        private System.Windows.Forms.Label lIDQtyReturned;
        private System.Windows.Forms.TextBox tBoxID_DistributionCenter;
        private System.Windows.Forms.GroupBox groupBox2;
        private NujitCustomWinControls.NumericTextBox ntbID_ComPercent;
        private NujitCustomWinControls.NumericTextBox ntbID_CommRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lIdCommPercent;
        private System.Windows.Forms.TextBox tBoxId_CommPlan;
        private System.Windows.Forms.Label lIdCommPlan;
        private System.Windows.Forms.Button btnSchSalesPer;
        private System.Windows.Forms.TextBox tBoxID_SalesPerson;
        private System.Windows.Forms.Label lIDSalesPerson;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.GroupBox groupBox1;
        private NujitCustomWinControls.NumericTextBox numericTextBox6;
        private NujitCustomWinControls.NumericTextBox numericTextBox8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGrid dGridComponents;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

       private CultureLocal culture = new CultureLocal(Culture.getCulture());
        private System.Windows.Forms.Button btnDeletePart;
        private System.Windows.Forms.Button btnEditPart;
        private System.Windows.Forms.Button btnAddPart;
        private System.Windows.Forms.GroupBox groupBox3;
        private NujitCustomWinControls.NumericTextBox ntbID_RoyCharges;
        private NujitCustomWinControls.NumericTextBox ntbId_FreigthAmt;
        private System.Windows.Forms.Label lIDRoyCharges;
        private System.Windows.Forms.Label lIdFreightAmt;
        private NujitCustomWinControls.NumericTextBox numericTextBox2;
        private System.Windows.Forms.Label label9;
        private NujitCustomWinControls.NumericTextBox numericTextBox5;
        private System.Windows.Forms.Label label10;
        private NujitCustomWinControls.NumericTextBox numericTextBox7;
        private System.Windows.Forms.Label label12;
        private NujitCustomWinControls.NumericTextBox numericTextBox9;
        private System.Windows.Forms.Label label14;
        private NujitCustomWinControls.NumericTextBox numericTextBox10;
        private System.Windows.Forms.Label label15;
        private NujitCustomWinControls.NumericTextBox numericTextBox11;
        private System.Windows.Forms.Label label16;
        private NujitCustomWinControls.NumericTextBox numericTextBox12;
        private System.Windows.Forms.Label label17;
        private NujitCustomWinControls.NumericTextBox numericTextBox13;
        private System.Windows.Forms.Label label18;
        private NujitCustomWinControls.NumericTextBox numericTextBox14;
        private System.Windows.Forms.Label label19;
        private NujitCustomWinControls.NumericTextBox numericTextBox15;
        private System.Windows.Forms.Label label20;
        private NujitCustomWinControls.NumericTextBox numericTextBox16;
        private System.Windows.Forms.Label label21;
        private NujitCustomWinControls.NumericTextBox numericTextBox17;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private NujitCustomWinControls.NumericTextBox numericTextBox18;
        private System.Windows.Forms.Label label24;
        private NujitCustomWinControls.NumericTextBox numericTextBox19;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label29;
        private NujitCustomWinControls.NumericTextBox numericTextBox20;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox textBox12;
        private NujitCustomWinControls.NumericTextBox ntbIH_ARYear;
        private NujitCustomWinControls.NumericTextBox ntbIH_ARPeriod;
        private System.Windows.Forms.Label lIHARYear;
        private System.Windows.Forms.Label lIH_ARPeriod;
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label26;
        private NujitCustomWinControls.NumericTextBox numericTextBox21;
        private System.Windows.Forms.Button btnDisccounts;
       private DataTable dataTable;

		public InvoiceDtlEditForm()		{
			
			InitializeComponent();
			setDatesFormat();
			
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
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.numericTextBox1 = new NujitCustomWinControls.NumericTextBox();
            this.lIDReleaseNum = new System.Windows.Forms.Label();
            this.ntbID_OrderItemNum = new NujitCustomWinControls.NumericTextBox();
            this.lIDOrderItemNum = new System.Windows.Forms.Label();
            this.ntbID_InvLineNum = new NujitCustomWinControls.NumericTextBox();
            this.lIDInvLineNum = new System.Windows.Forms.Label();
            this.ntbID_OrderNum = new NujitCustomWinControls.NumericTextBox();
            this.lIDOrderNum = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lIhInvDate = new System.Windows.Forms.Label();
            this.dtpIH_InvDate = new System.Windows.Forms.DateTimePicker();
            this.lIvCredit = new System.Windows.Forms.Label();
            this.ntbIHInvTotal = new NujitCustomWinControls.NumericTextBox();
            this.ntboxID_InvoiceNum = new NujitCustomWinControls.NumericTextBox();
            this.ntboxID_Company = new NujitCustomWinControls.NumericTextBox();
            this.tBoxID_Plant = new System.Windows.Forms.TextBox();
            this.tBoxID_DataBase = new System.Windows.Forms.TextBox();
            this.lIDInvoiceNum = new System.Windows.Forms.Label();
            this.lIDPlant = new System.Windows.Forms.Label();
            this.lIDCompany = new System.Windows.Forms.Label();
            this.lIDDb = new System.Windows.Forms.Label();
            this.lIHInvType = new System.Windows.Forms.Label();
            this.tBoxIH_InvType = new System.Windows.Forms.TextBox();
            this.lIHInvoiceTotal = new System.Windows.Forms.Label();
            this.gBoxBtns = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tabControlInvDtl = new System.Windows.Forms.TabControl();
            this.tabPagePart = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.numericTextBox21 = new NujitCustomWinControls.NumericTextBox();
            this.lIdPriceBefDis = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.ntbID_LineExt = new NujitCustomWinControls.NumericTextBox();
            this.lIDLineExt = new System.Windows.Forms.Label();
            this.btnDisccounts = new System.Windows.Forms.Button();
            this.ntbID_DiscountAmt = new NujitCustomWinControls.NumericTextBox();
            this.lIDDiscountAmt = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericTextBox3 = new NujitCustomWinControls.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ntbID_UnitPrice = new NujitCustomWinControls.NumericTextBox();
            this.lIDUnitPrice = new System.Windows.Forms.Label();
            this.lIDUpUom = new System.Windows.Forms.Label();
            this.tBoxID_UPUom = new System.Windows.Forms.TextBox();
            this.numericTextBox4 = new NujitCustomWinControls.NumericTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ntbID_PriceBefDis = new NujitCustomWinControls.NumericTextBox();
            this.gBoxOthersSC = new System.Windows.Forms.GroupBox();
            this.lIdCustRan = new System.Windows.Forms.Label();
            this.tBoxID_CustRan = new System.Windows.Forms.TextBox();
            this.lIDManuPart = new System.Windows.Forms.Label();
            this.tBoxID_ManuPart = new System.Windows.Forms.TextBox();
            this.btnSchManuPart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tBoxID_Manufacturer = new System.Windows.Forms.TextBox();
            this.btnSchMgf = new System.Windows.Forms.Button();
            this.ntbID_QtyReturned = new NujitCustomWinControls.NumericTextBox();
            this.lIDQtyReturned = new System.Windows.Forms.Label();
            this.tabPageShippmet = new System.Windows.Forms.TabPage();
            this.gBoxShip = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBoxID_DistributionCenter = new System.Windows.Forms.TextBox();
            this.ntbID_PackingSlip = new NujitCustomWinControls.NumericTextBox();
            this.lIDPackingSlip = new System.Windows.Forms.Label();
            this.ntbID_PackingSlipLin = new NujitCustomWinControls.NumericTextBox();
            this.lIdPackingSlipLin = new System.Windows.Forms.Label();
            this.dtpID_DateShipped = new System.Windows.Forms.DateTimePicker();
            this.lIDDateShipped = new System.Windows.Forms.Label();
            this.schStkLoc = new System.Windows.Forms.Button();
            this.lIDShipStkLoc = new System.Windows.Forms.Label();
            this.tBoxID_ShipStkLoc = new System.Windows.Forms.TextBox();
            this.btnSchPlant = new System.Windows.Forms.Button();
            this.tBoxID_ShipPlant = new System.Windows.Forms.TextBox();
            this.lIDShipPlant = new System.Windows.Forms.Label();
            this.btnSchCompany = new System.Windows.Forms.Button();
            this.ntbID_ShipCompany = new NujitCustomWinControls.NumericTextBox();
            this.lIDShipCompany = new System.Windows.Forms.Label();
            this.gBoxQty = new System.Windows.Forms.GroupBox();
            this.ntbID_QtyShipped = new NujitCustomWinControls.NumericTextBox();
            this.lIDQtyOutstand = new System.Windows.Forms.Label();
            this.ntbID_Qty_Outstand = new NujitCustomWinControls.NumericTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ntbID_QtyShipInv = new NujitCustomWinControls.NumericTextBox();
            this.lIDQtyShipInv = new System.Windows.Forms.Label();
            this.lIDQSIUom = new System.Windows.Forms.Label();
            this.lIDQtyShipped = new System.Windows.Forms.Label();
            this.ntbID_QtyBackOrder = new NujitCustomWinControls.NumericTextBox();
            this.btnSchUomQsi = new System.Windows.Forms.Button();
            this.tBoxID_QSUom = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnSchUom = new System.Windows.Forms.Button();
            this.lIDQtyBackOrder = new System.Windows.Forms.Label();
            this.tabPageAccounting = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ntbID_ComPercent = new NujitCustomWinControls.NumericTextBox();
            this.ntbID_CommRate = new NujitCustomWinControls.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lIdCommPercent = new System.Windows.Forms.Label();
            this.tBoxId_CommPlan = new System.Windows.Forms.TextBox();
            this.lIdCommPlan = new System.Windows.Forms.Label();
            this.btnSchSalesPer = new System.Windows.Forms.Button();
            this.tBoxID_SalesPerson = new System.Windows.Forms.TextBox();
            this.lIDSalesPerson = new System.Windows.Forms.Label();
            this.gBoxCost = new System.Windows.Forms.GroupBox();
            this.numericTextBox18 = new NujitCustomWinControls.NumericTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.numericTextBox17 = new NujitCustomWinControls.NumericTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.numericTextBox16 = new NujitCustomWinControls.NumericTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.numericTextBox15 = new NujitCustomWinControls.NumericTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.numericTextBox14 = new NujitCustomWinControls.NumericTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.numericTextBox13 = new NujitCustomWinControls.NumericTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.numericTextBox12 = new NujitCustomWinControls.NumericTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.numericTextBox11 = new NujitCustomWinControls.NumericTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.numericTextBox10 = new NujitCustomWinControls.NumericTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.numericTextBox7 = new NujitCustomWinControls.NumericTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numericTextBox9 = new NujitCustomWinControls.NumericTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.numericTextBox5 = new NujitCustomWinControls.NumericTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numericTextBox2 = new NujitCustomWinControls.NumericTextBox();
            this.label9 = new System.Windows.Forms.Label();
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
            this.numericTextBox19 = new NujitCustomWinControls.NumericTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.ntbID_RoyCharges = new NujitCustomWinControls.NumericTextBox();
            this.ntbId_FreigthAmt = new NujitCustomWinControls.NumericTextBox();
            this.lIDRoyCharges = new System.Windows.Forms.Label();
            this.lIdFreightAmt = new System.Windows.Forms.Label();
            this.numericTextBox6 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox8 = new NujitCustomWinControls.NumericTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
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
            this.tabPageComponentList = new System.Windows.Forms.TabPage();
            this.btnDeletePart = new System.Windows.Forms.Button();
            this.btnEditPart = new System.Windows.Forms.Button();
            this.btnAddPart = new System.Windows.Forms.Button();
            this.dGridComponents = new System.Windows.Forms.DataGrid();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lIDComponentList = new System.Windows.Forms.Label();
            this.tabPageSales = new System.Windows.Forms.TabPage();
            this.gBoxSalesCode = new System.Windows.Forms.GroupBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
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
            this.tBoxID_Description = new System.Windows.Forms.TextBox();
            this.lIDDescription = new System.Windows.Forms.Label();
            this.gBoxPart = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btnSchCustPart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lIDPart = new System.Windows.Forms.Label();
            this.tBoxID_Revision = new System.Windows.Forms.TextBox();
            this.lIDRevision = new System.Windows.Forms.Label();
            this.tBoxID_Part = new System.Windows.Forms.TextBox();
            this.lIDSequence = new System.Windows.Forms.Label();
            this.tBoxID_CustPart = new System.Windows.Forms.TextBox();
            this.lIDCustPart = new System.Windows.Forms.Label();
            this.tBoxID_Sequence = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.label32 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label31 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.numericTextBox20 = new NujitCustomWinControls.NumericTextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.ntbIH_ARYear = new NujitCustomWinControls.NumericTextBox();
            this.ntbIH_ARPeriod = new NujitCustomWinControls.NumericTextBox();
            this.lIHARYear = new System.Windows.Forms.Label();
            this.lIH_ARPeriod = new System.Windows.Forms.Label();
            this.gBoxBtns.SuspendLayout();
            this.tabControlInvDtl.SuspendLayout();
            this.tabPagePart.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gBoxOthersSC.SuspendLayout();
            this.tabPageShippmet.SuspendLayout();
            this.gBoxShip.SuspendLayout();
            this.gBoxQty.SuspendLayout();
            this.tabPageAccounting.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gBoxCost.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gBoxTax.SuspendLayout();
            this.tabPageComponentList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridComponents)).BeginInit();
            this.tabPageSales.SuspendLayout();
            this.gBoxSalesCode.SuspendLayout();
            this.gBoxPart.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 55;
            this.label7.Text = "Currency";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(80, 36);
            this.textBox5.MaxLength = 10;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(80, 20);
            this.textBox5.TabIndex = 56;
            this.textBox5.Text = "";
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Location = new System.Drawing.Point(432, 116);
            this.numericTextBox1.Maximum = new System.Decimal(new int[] {
                                                                            900000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox1.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.Size = new System.Drawing.Size(72, 20);
            this.numericTextBox1.TabIndex = 54;
            this.numericTextBox1.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // lIDReleaseNum
            // 
            this.lIDReleaseNum.Location = new System.Drawing.Point(352, 120);
            this.lIDReleaseNum.Name = "lIDReleaseNum";
            this.lIDReleaseNum.Size = new System.Drawing.Size(64, 20);
            this.lIDReleaseNum.TabIndex = 53;
            this.lIDReleaseNum.Text = "Release #";
            // 
            // ntbID_OrderItemNum
            // 
            this.ntbID_OrderItemNum.Location = new System.Drawing.Point(256, 116);
            this.ntbID_OrderItemNum.Maximum = new System.Decimal(new int[] {
                                                                               900000,
                                                                               0,
                                                                               0,
                                                                               0});
            this.ntbID_OrderItemNum.Minimum = new System.Decimal(new int[] {
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               0});
            this.ntbID_OrderItemNum.Name = "ntbID_OrderItemNum";
            this.ntbID_OrderItemNum.Size = new System.Drawing.Size(88, 20);
            this.ntbID_OrderItemNum.TabIndex = 52;
            this.ntbID_OrderItemNum.Value = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            // 
            // lIDOrderItemNum
            // 
            this.lIDOrderItemNum.Location = new System.Drawing.Point(168, 120);
            this.lIDOrderItemNum.Name = "lIDOrderItemNum";
            this.lIDOrderItemNum.Size = new System.Drawing.Size(64, 20);
            this.lIDOrderItemNum.TabIndex = 51;
            this.lIDOrderItemNum.Text = "Order item#";
            // 
            // ntbID_InvLineNum
            // 
            this.ntbID_InvLineNum.Location = new System.Drawing.Point(80, 116);
            this.ntbID_InvLineNum.Maximum = new System.Decimal(new int[] {
                                                                             900,
                                                                             0,
                                                                             0,
                                                                             0});
            this.ntbID_InvLineNum.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.ntbID_InvLineNum.Name = "ntbID_InvLineNum";
            this.ntbID_InvLineNum.Size = new System.Drawing.Size(80, 20);
            this.ntbID_InvLineNum.TabIndex = 50;
            this.ntbID_InvLineNum.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // lIDInvLineNum
            // 
            this.lIDInvLineNum.Location = new System.Drawing.Point(8, 120);
            this.lIDInvLineNum.Name = "lIDInvLineNum";
            this.lIDInvLineNum.Size = new System.Drawing.Size(80, 20);
            this.lIDInvLineNum.TabIndex = 49;
            this.lIDInvLineNum.Text = "Invoice Line #";
            // 
            // ntbID_OrderNum
            // 
            this.ntbID_OrderNum.Location = new System.Drawing.Point(608, 120);
            this.ntbID_OrderNum.Maximum = new System.Decimal(new int[] {
                                                                           -1486618625,
                                                                           232830643,
                                                                           0,
                                                                           0});
            this.ntbID_OrderNum.Minimum = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            this.ntbID_OrderNum.Name = "ntbID_OrderNum";
            this.ntbID_OrderNum.ReadOnly = true;
            this.ntbID_OrderNum.Size = new System.Drawing.Size(80, 20);
            this.ntbID_OrderNum.TabIndex = 48;
            this.ntbID_OrderNum.Value = new System.Decimal(new int[] {
                                                                         0,
                                                                         0,
                                                                         0,
                                                                         0});
            // 
            // lIDOrderNum
            // 
            this.lIDOrderNum.Location = new System.Drawing.Point(520, 120);
            this.lIDOrderNum.Name = "lIDOrderNum";
            this.lIDOrderNum.Size = new System.Drawing.Size(56, 20);
            this.lIDOrderNum.TabIndex = 47;
            this.lIDOrderNum.Text = "Order #";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(256, 76);
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(88, 20);
            this.textBox1.TabIndex = 46;
            this.textBox1.Text = "";
            // 
            // lIhInvDate
            // 
            this.lIhInvDate.Location = new System.Drawing.Point(168, 16);
            this.lIhInvDate.Name = "lIhInvDate";
            this.lIhInvDate.Size = new System.Drawing.Size(72, 16);
            this.lIhInvDate.TabIndex = 41;
            this.lIhInvDate.Text = "Invoice Date";
            // 
            // dtpIH_InvDate
            // 
            this.dtpIH_InvDate.Enabled = false;
            this.dtpIH_InvDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIH_InvDate.Location = new System.Drawing.Point(256, 16);
            this.dtpIH_InvDate.Name = "dtpIH_InvDate";
            this.dtpIH_InvDate.Size = new System.Drawing.Size(88, 20);
            this.dtpIH_InvDate.TabIndex = 40;
            this.dtpIH_InvDate.Value = new System.DateTime(2005, 3, 22, 15, 55, 58, 688);
            // 
            // lIvCredit
            // 
            this.lIvCredit.Location = new System.Drawing.Point(168, 80);
            this.lIvCredit.Name = "lIvCredit";
            this.lIvCredit.Size = new System.Drawing.Size(80, 16);
            this.lIvCredit.TabIndex = 43;
            this.lIvCredit.Text = "Invoice Credit";
            // 
            // ntbIHInvTotal
            // 
            this.ntbIHInvTotal.Location = new System.Drawing.Point(256, 36);
            this.ntbIHInvTotal.Maximum = new System.Decimal(new int[] {
                                                                          -727379969,
                                                                          232,
                                                                          0,
                                                                          0});
            this.ntbIHInvTotal.MaxPrecision = 2;
            this.ntbIHInvTotal.Minimum = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            this.ntbIHInvTotal.Name = "ntbIHInvTotal";
            this.ntbIHInvTotal.ReadOnly = true;
            this.ntbIHInvTotal.Size = new System.Drawing.Size(88, 20);
            this.ntbIHInvTotal.TabIndex = 45;
            this.ntbIHInvTotal.Value = new System.Decimal(new int[] {
                                                                        0,
                                                                        0,
                                                                        0,
                                                                        0});
            // 
            // ntboxID_InvoiceNum
            // 
            this.ntboxID_InvoiceNum.Location = new System.Drawing.Point(80, 16);
            this.ntboxID_InvoiceNum.Maximum = new System.Decimal(new int[] {
                                                                               -1486618625,
                                                                               232830643,
                                                                               0,
                                                                               0});
            this.ntboxID_InvoiceNum.Minimum = new System.Decimal(new int[] {
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               0});
            this.ntboxID_InvoiceNum.Name = "ntboxID_InvoiceNum";
            this.ntboxID_InvoiceNum.ReadOnly = true;
            this.ntboxID_InvoiceNum.Size = new System.Drawing.Size(80, 20);
            this.ntboxID_InvoiceNum.TabIndex = 8;
            this.ntboxID_InvoiceNum.Value = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            // 
            // ntboxID_Company
            // 
            this.ntboxID_Company.Location = new System.Drawing.Point(80, 76);
            this.ntboxID_Company.Maximum = new System.Decimal(new int[] {
                                                                            999,
                                                                            0,
                                                                            0,
                                                                            0});
            this.ntboxID_Company.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.ntboxID_Company.Name = "ntboxID_Company";
            this.ntboxID_Company.ReadOnly = true;
            this.ntboxID_Company.Size = new System.Drawing.Size(80, 20);
            this.ntboxID_Company.TabIndex = 7;
            this.ntboxID_Company.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // tBoxID_Plant
            // 
            this.tBoxID_Plant.Location = new System.Drawing.Point(80, 96);
            this.tBoxID_Plant.MaxLength = 10;
            this.tBoxID_Plant.Name = "tBoxID_Plant";
            this.tBoxID_Plant.ReadOnly = true;
            this.tBoxID_Plant.Size = new System.Drawing.Size(80, 20);
            this.tBoxID_Plant.TabIndex = 6;
            this.tBoxID_Plant.Text = "";
            // 
            // tBoxID_DataBase
            // 
            this.tBoxID_DataBase.Location = new System.Drawing.Point(80, 56);
            this.tBoxID_DataBase.MaxLength = 10;
            this.tBoxID_DataBase.Name = "tBoxID_DataBase";
            this.tBoxID_DataBase.ReadOnly = true;
            this.tBoxID_DataBase.Size = new System.Drawing.Size(80, 20);
            this.tBoxID_DataBase.TabIndex = 4;
            this.tBoxID_DataBase.Text = "";
            // 
            // lIDInvoiceNum
            // 
            this.lIDInvoiceNum.Location = new System.Drawing.Point(8, 16);
            this.lIDInvoiceNum.Name = "lIDInvoiceNum";
            this.lIDInvoiceNum.Size = new System.Drawing.Size(64, 16);
            this.lIDInvoiceNum.TabIndex = 3;
            this.lIDInvoiceNum.Text = "Invoice #";
            // 
            // lIDPlant
            // 
            this.lIDPlant.Location = new System.Drawing.Point(8, 100);
            this.lIDPlant.Name = "lIDPlant";
            this.lIDPlant.Size = new System.Drawing.Size(48, 16);
            this.lIDPlant.TabIndex = 2;
            this.lIDPlant.Text = "Plant";
            // 
            // lIDCompany
            // 
            this.lIDCompany.Location = new System.Drawing.Point(8, 80);
            this.lIDCompany.Name = "lIDCompany";
            this.lIDCompany.Size = new System.Drawing.Size(64, 16);
            this.lIDCompany.TabIndex = 1;
            this.lIDCompany.Text = "Company";
            // 
            // lIDDb
            // 
            this.lIDDb.Location = new System.Drawing.Point(8, 60);
            this.lIDDb.Name = "lIDDb";
            this.lIDDb.Size = new System.Drawing.Size(64, 16);
            this.lIDDb.TabIndex = 0;
            this.lIDDb.Text = "Data Base";
            // 
            // lIHInvType
            // 
            this.lIHInvType.Location = new System.Drawing.Point(168, 100);
            this.lIHInvType.Name = "lIHInvType";
            this.lIHInvType.Size = new System.Drawing.Size(72, 16);
            this.lIHInvType.TabIndex = 18;
            this.lIHInvType.Text = "Invoice Type";
            // 
            // tBoxIH_InvType
            // 
            this.tBoxIH_InvType.Location = new System.Drawing.Point(256, 96);
            this.tBoxIH_InvType.MaxLength = 10;
            this.tBoxIH_InvType.Name = "tBoxIH_InvType";
            this.tBoxIH_InvType.ReadOnly = true;
            this.tBoxIH_InvType.Size = new System.Drawing.Size(88, 20);
            this.tBoxIH_InvType.TabIndex = 19;
            this.tBoxIH_InvType.Text = "";
            // 
            // lIHInvoiceTotal
            // 
            this.lIHInvoiceTotal.Location = new System.Drawing.Point(168, 40);
            this.lIHInvoiceTotal.Name = "lIHInvoiceTotal";
            this.lIHInvoiceTotal.Size = new System.Drawing.Size(80, 16);
            this.lIHInvoiceTotal.TabIndex = 44;
            this.lIHInvoiceTotal.Text = "Invocie Total";
            // 
            // gBoxBtns
            // 
            this.gBoxBtns.Controls.Add(this.btnClear);
            this.gBoxBtns.Controls.Add(this.btnSave);
            this.gBoxBtns.Controls.Add(this.btnDelete);
            this.gBoxBtns.Location = new System.Drawing.Point(8, 576);
            this.gBoxBtns.Name = "gBoxBtns";
            this.gBoxBtns.Size = new System.Drawing.Size(784, 48);
            this.gBoxBtns.TabIndex = 3;
            this.gBoxBtns.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(528, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(616, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(696, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete";
            // 
            // tabControlInvDtl
            // 
            this.tabControlInvDtl.Controls.Add(this.tabPagePart);
            this.tabControlInvDtl.Controls.Add(this.tabPageShippmet);
            this.tabControlInvDtl.Controls.Add(this.tabPageAccounting);
            this.tabControlInvDtl.Controls.Add(this.tabPageComponentList);
            this.tabControlInvDtl.Controls.Add(this.tabPageSales);
            this.tabControlInvDtl.Location = new System.Drawing.Point(48, 232);
            this.tabControlInvDtl.Name = "tabControlInvDtl";
            this.tabControlInvDtl.SelectedIndex = 0;
            this.tabControlInvDtl.Size = new System.Drawing.Size(704, 344);
            this.tabControlInvDtl.TabIndex = 4;
            this.tabControlInvDtl.SelectedIndexChanged += new System.EventHandler(this.tabControlInvDtl_SelectedIndexChanged);
            // 
            // tabPagePart
            // 
            this.tabPagePart.Controls.Add(this.groupBox3);
            this.tabPagePart.Controls.Add(this.gBoxOthersSC);
            this.tabPagePart.Location = new System.Drawing.Point(4, 22);
            this.tabPagePart.Name = "tabPagePart";
            this.tabPagePart.Size = new System.Drawing.Size(696, 318);
            this.tabPagePart.TabIndex = 0;
            this.tabPagePart.Text = "Items";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.numericTextBox21);
            this.groupBox3.Controls.Add(this.lIdPriceBefDis);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.ntbID_LineExt);
            this.groupBox3.Controls.Add(this.lIDLineExt);
            this.groupBox3.Controls.Add(this.btnDisccounts);
            this.groupBox3.Controls.Add(this.ntbID_DiscountAmt);
            this.groupBox3.Controls.Add(this.lIDDiscountAmt);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.numericTextBox3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.ntbID_UnitPrice);
            this.groupBox3.Controls.Add(this.lIDUnitPrice);
            this.groupBox3.Controls.Add(this.lIDUpUom);
            this.groupBox3.Controls.Add(this.tBoxID_UPUom);
            this.groupBox3.Controls.Add(this.numericTextBox4);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.ntbID_PriceBefDis);
            this.groupBox3.Location = new System.Drawing.Point(72, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(536, 100);
            this.groupBox3.TabIndex = 54;
            this.groupBox3.TabStop = false;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(32, 56);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 16);
            this.label26.TabIndex = 53;
            this.label26.Text = "Tax Grp.";
            // 
            // numericTextBox21
            // 
            this.numericTextBox21.Location = new System.Drawing.Point(32, 72);
            this.numericTextBox21.Maximum = new System.Decimal(new int[] {
                                                                             1316134911,
                                                                             2328,
                                                                             0,
                                                                             0});
            this.numericTextBox21.MaxPrecision = 6;
            this.numericTextBox21.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox21.Name = "numericTextBox21";
            this.numericTextBox21.Size = new System.Drawing.Size(72, 20);
            this.numericTextBox21.TabIndex = 54;
            this.numericTextBox21.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // lIdPriceBefDis
            // 
            this.lIdPriceBefDis.Location = new System.Drawing.Point(104, 56);
            this.lIdPriceBefDis.Name = "lIdPriceBefDis";
            this.lIdPriceBefDis.Size = new System.Drawing.Size(80, 16);
            this.lIdPriceBefDis.TabIndex = 49;
            this.lIdPriceBefDis.Text = "Price Bef. Dis.";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(208, 32);
            this.textBox4.MaxLength = 5;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(56, 20);
            this.textBox4.TabIndex = 48;
            this.textBox4.Text = "";
            // 
            // ntbID_LineExt
            // 
            this.ntbID_LineExt.Location = new System.Drawing.Point(320, 32);
            this.ntbID_LineExt.Maximum = new System.Decimal(new int[] {
                                                                          -1981284353,
                                                                          -1966660860,
                                                                          0,
                                                                          0});
            this.ntbID_LineExt.MaxPrecision = 2;
            this.ntbID_LineExt.Minimum = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            this.ntbID_LineExt.Name = "ntbID_LineExt";
            this.ntbID_LineExt.Size = new System.Drawing.Size(96, 20);
            this.ntbID_LineExt.TabIndex = 32;
            this.ntbID_LineExt.Value = new System.Decimal(new int[] {
                                                                        0,
                                                                        0,
                                                                        0,
                                                                        0});
            // 
            // lIDLineExt
            // 
            this.lIDLineExt.Location = new System.Drawing.Point(320, 16);
            this.lIDLineExt.Name = "lIDLineExt";
            this.lIDLineExt.Size = new System.Drawing.Size(56, 16);
            this.lIDLineExt.TabIndex = 31;
            this.lIDLineExt.Text = "Line Ext.";
            // 
            // btnDisccounts
            // 
            this.btnDisccounts.Location = new System.Drawing.Point(448, 24);
            this.btnDisccounts.Name = "btnDisccounts";
            this.btnDisccounts.Size = new System.Drawing.Size(64, 24);
            this.btnDisccounts.TabIndex = 33;
            this.btnDisccounts.Text = "Discounts";
            this.btnDisccounts.Click += new System.EventHandler(this.button2_Click);
            // 
            // ntbID_DiscountAmt
            // 
            this.ntbID_DiscountAmt.Location = new System.Drawing.Point(208, 72);
            this.ntbID_DiscountAmt.Maximum = new System.Decimal(new int[] {
                                                                              1316134911,
                                                                              2328,
                                                                              0,
                                                                              0});
            this.ntbID_DiscountAmt.MaxPrecision = 2;
            this.ntbID_DiscountAmt.Minimum = new System.Decimal(new int[] {
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0});
            this.ntbID_DiscountAmt.Name = "ntbID_DiscountAmt";
            this.ntbID_DiscountAmt.Size = new System.Drawing.Size(104, 20);
            this.ntbID_DiscountAmt.TabIndex = 32;
            this.ntbID_DiscountAmt.Value = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            // 
            // lIDDiscountAmt
            // 
            this.lIDDiscountAmt.Location = new System.Drawing.Point(208, 56);
            this.lIDDiscountAmt.Name = "lIDDiscountAmt";
            this.lIDDiscountAmt.Size = new System.Drawing.Size(80, 16);
            this.lIDDiscountAmt.TabIndex = 31;
            this.lIDDiscountAmt.Text = "Discount Amt";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(208, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 47;
            this.label6.Text = "Qty Uom";
            // 
            // numericTextBox3
            // 
            this.numericTextBox3.Location = new System.Drawing.Point(32, 32);
            this.numericTextBox3.Maximum = new System.Decimal(new int[] {
                                                                            1874919423,
                                                                            2328306,
                                                                            0,
                                                                            0});
            this.numericTextBox3.MaxPrecision = 5;
            this.numericTextBox3.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox3.Name = "numericTextBox3";
            this.numericTextBox3.Size = new System.Drawing.Size(72, 20);
            this.numericTextBox3.TabIndex = 46;
            this.numericTextBox3.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 45;
            this.label1.Text = "Qty";
            // 
            // ntbID_UnitPrice
            // 
            this.ntbID_UnitPrice.Location = new System.Drawing.Point(104, 32);
            this.ntbID_UnitPrice.Maximum = new System.Decimal(new int[] {
                                                                            1874919423,
                                                                            2328306,
                                                                            0,
                                                                            0});
            this.ntbID_UnitPrice.MaxPrecision = 5;
            this.ntbID_UnitPrice.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.ntbID_UnitPrice.Name = "ntbID_UnitPrice";
            this.ntbID_UnitPrice.Size = new System.Drawing.Size(104, 20);
            this.ntbID_UnitPrice.TabIndex = 30;
            this.ntbID_UnitPrice.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // lIDUnitPrice
            // 
            this.lIDUnitPrice.Location = new System.Drawing.Point(104, 16);
            this.lIDUnitPrice.Name = "lIDUnitPrice";
            this.lIDUnitPrice.Size = new System.Drawing.Size(64, 16);
            this.lIDUnitPrice.TabIndex = 29;
            this.lIDUnitPrice.Text = "Unit Price";
            // 
            // lIDUpUom
            // 
            this.lIDUpUom.Location = new System.Drawing.Point(264, 16);
            this.lIDUpUom.Name = "lIDUpUom";
            this.lIDUpUom.Size = new System.Drawing.Size(56, 16);
            this.lIDUpUom.TabIndex = 26;
            this.lIDUpUom.Text = "UP Uom";
            // 
            // tBoxID_UPUom
            // 
            this.tBoxID_UPUom.Location = new System.Drawing.Point(264, 32);
            this.tBoxID_UPUom.MaxLength = 5;
            this.tBoxID_UPUom.Name = "tBoxID_UPUom";
            this.tBoxID_UPUom.Size = new System.Drawing.Size(56, 20);
            this.tBoxID_UPUom.TabIndex = 27;
            this.tBoxID_UPUom.Text = "";
            // 
            // numericTextBox4
            // 
            this.numericTextBox4.Location = new System.Drawing.Point(320, 72);
            this.numericTextBox4.Maximum = new System.Decimal(new int[] {
                                                                            -1981284353,
                                                                            -1966660860,
                                                                            0,
                                                                            0});
            this.numericTextBox4.MaxPrecision = 2;
            this.numericTextBox4.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox4.Name = "numericTextBox4";
            this.numericTextBox4.Size = new System.Drawing.Size(96, 20);
            this.numericTextBox4.TabIndex = 52;
            this.numericTextBox4.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(320, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.label8.TabIndex = 51;
            this.label8.Text = "Extension";
            // 
            // ntbID_PriceBefDis
            // 
            this.ntbID_PriceBefDis.Location = new System.Drawing.Point(104, 72);
            this.ntbID_PriceBefDis.Maximum = new System.Decimal(new int[] {
                                                                              1316134911,
                                                                              2328,
                                                                              0,
                                                                              0});
            this.ntbID_PriceBefDis.MaxPrecision = 6;
            this.ntbID_PriceBefDis.Minimum = new System.Decimal(new int[] {
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0});
            this.ntbID_PriceBefDis.Name = "ntbID_PriceBefDis";
            this.ntbID_PriceBefDis.Size = new System.Drawing.Size(104, 20);
            this.ntbID_PriceBefDis.TabIndex = 50;
            this.ntbID_PriceBefDis.Value = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            // 
            // gBoxOthersSC
            // 
            this.gBoxOthersSC.Controls.Add(this.lIdCustRan);
            this.gBoxOthersSC.Controls.Add(this.tBoxID_CustRan);
            this.gBoxOthersSC.Controls.Add(this.lIDManuPart);
            this.gBoxOthersSC.Controls.Add(this.tBoxID_ManuPart);
            this.gBoxOthersSC.Controls.Add(this.btnSchManuPart);
            this.gBoxOthersSC.Controls.Add(this.label3);
            this.gBoxOthersSC.Controls.Add(this.tBoxID_Manufacturer);
            this.gBoxOthersSC.Controls.Add(this.btnSchMgf);
            this.gBoxOthersSC.Controls.Add(this.ntbID_QtyReturned);
            this.gBoxOthersSC.Controls.Add(this.lIDQtyReturned);
            this.gBoxOthersSC.Location = new System.Drawing.Point(72, 112);
            this.gBoxOthersSC.Name = "gBoxOthersSC";
            this.gBoxOthersSC.Size = new System.Drawing.Size(536, 112);
            this.gBoxOthersSC.TabIndex = 44;
            this.gBoxOthersSC.TabStop = false;
            this.gBoxOthersSC.Text = "Others";
            // 
            // lIdCustRan
            // 
            this.lIdCustRan.Location = new System.Drawing.Point(8, 60);
            this.lIdCustRan.Name = "lIdCustRan";
            this.lIdCustRan.Size = new System.Drawing.Size(64, 16);
            this.lIdCustRan.TabIndex = 97;
            this.lIdCustRan.Text = "Cust Ran";
            // 
            // tBoxID_CustRan
            // 
            this.tBoxID_CustRan.Location = new System.Drawing.Point(112, 56);
            this.tBoxID_CustRan.MaxLength = 20;
            this.tBoxID_CustRan.Name = "tBoxID_CustRan";
            this.tBoxID_CustRan.Size = new System.Drawing.Size(136, 20);
            this.tBoxID_CustRan.TabIndex = 98;
            this.tBoxID_CustRan.Text = "";
            // 
            // lIDManuPart
            // 
            this.lIDManuPart.Location = new System.Drawing.Point(8, 40);
            this.lIDManuPart.Name = "lIDManuPart";
            this.lIDManuPart.Size = new System.Drawing.Size(80, 16);
            this.lIDManuPart.TabIndex = 94;
            this.lIDManuPart.Text = "Manufact. Part";
            // 
            // tBoxID_ManuPart
            // 
            this.tBoxID_ManuPart.Location = new System.Drawing.Point(112, 36);
            this.tBoxID_ManuPart.MaxLength = 40;
            this.tBoxID_ManuPart.Name = "tBoxID_ManuPart";
            this.tBoxID_ManuPart.Size = new System.Drawing.Size(248, 20);
            this.tBoxID_ManuPart.TabIndex = 95;
            this.tBoxID_ManuPart.Text = "";
            // 
            // btnSchManuPart
            // 
            this.btnSchManuPart.Location = new System.Drawing.Point(368, 40);
            this.btnSchManuPart.Name = "btnSchManuPart";
            this.btnSchManuPart.Size = new System.Drawing.Size(30, 16);
            this.btnSchManuPart.TabIndex = 96;
            this.btnSchManuPart.Text = "...";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 91;
            this.label3.Text = "Manufacturer";
            // 
            // tBoxID_Manufacturer
            // 
            this.tBoxID_Manufacturer.Location = new System.Drawing.Point(112, 16);
            this.tBoxID_Manufacturer.MaxLength = 40;
            this.tBoxID_Manufacturer.Name = "tBoxID_Manufacturer";
            this.tBoxID_Manufacturer.Size = new System.Drawing.Size(248, 20);
            this.tBoxID_Manufacturer.TabIndex = 92;
            this.tBoxID_Manufacturer.Text = "";
            // 
            // btnSchMgf
            // 
            this.btnSchMgf.Location = new System.Drawing.Point(368, 16);
            this.btnSchMgf.Name = "btnSchMgf";
            this.btnSchMgf.Size = new System.Drawing.Size(30, 16);
            this.btnSchMgf.TabIndex = 93;
            this.btnSchMgf.Text = "...";
            // 
            // ntbID_QtyReturned
            // 
            this.ntbID_QtyReturned.Location = new System.Drawing.Point(112, 76);
            this.ntbID_QtyReturned.Maximum = new System.Decimal(new int[] {
                                                                              1215752191,
                                                                              23,
                                                                              0,
                                                                              0});
            this.ntbID_QtyReturned.MaxPrecision = 2;
            this.ntbID_QtyReturned.Minimum = new System.Decimal(new int[] {
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0});
            this.ntbID_QtyReturned.Name = "ntbID_QtyReturned";
            this.ntbID_QtyReturned.Size = new System.Drawing.Size(136, 20);
            this.ntbID_QtyReturned.TabIndex = 38;
            this.ntbID_QtyReturned.Value = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            // 
            // lIDQtyReturned
            // 
            this.lIDQtyReturned.Location = new System.Drawing.Point(8, 80);
            this.lIDQtyReturned.Name = "lIDQtyReturned";
            this.lIDQtyReturned.Size = new System.Drawing.Size(72, 16);
            this.lIDQtyReturned.TabIndex = 37;
            this.lIDQtyReturned.Text = "Qty Returned";
            // 
            // tabPageShippmet
            // 
            this.tabPageShippmet.Controls.Add(this.gBoxShip);
            this.tabPageShippmet.Controls.Add(this.gBoxQty);
            this.tabPageShippmet.Location = new System.Drawing.Point(4, 22);
            this.tabPageShippmet.Name = "tabPageShippmet";
            this.tabPageShippmet.Size = new System.Drawing.Size(696, 318);
            this.tabPageShippmet.TabIndex = 6;
            this.tabPageShippmet.Text = "Shippment";
            // 
            // gBoxShip
            // 
            this.gBoxShip.Controls.Add(this.label4);
            this.gBoxShip.Controls.Add(this.tBoxID_DistributionCenter);
            this.gBoxShip.Controls.Add(this.ntbID_PackingSlip);
            this.gBoxShip.Controls.Add(this.lIDPackingSlip);
            this.gBoxShip.Controls.Add(this.ntbID_PackingSlipLin);
            this.gBoxShip.Controls.Add(this.lIdPackingSlipLin);
            this.gBoxShip.Controls.Add(this.dtpID_DateShipped);
            this.gBoxShip.Controls.Add(this.lIDDateShipped);
            this.gBoxShip.Controls.Add(this.schStkLoc);
            this.gBoxShip.Controls.Add(this.lIDShipStkLoc);
            this.gBoxShip.Controls.Add(this.tBoxID_ShipStkLoc);
            this.gBoxShip.Controls.Add(this.btnSchPlant);
            this.gBoxShip.Controls.Add(this.tBoxID_ShipPlant);
            this.gBoxShip.Controls.Add(this.lIDShipPlant);
            this.gBoxShip.Controls.Add(this.btnSchCompany);
            this.gBoxShip.Controls.Add(this.ntbID_ShipCompany);
            this.gBoxShip.Controls.Add(this.lIDShipCompany);
            this.gBoxShip.Location = new System.Drawing.Point(16, 16);
            this.gBoxShip.Name = "gBoxShip";
            this.gBoxShip.Size = new System.Drawing.Size(624, 104);
            this.gBoxShip.TabIndex = 41;
            this.gBoxShip.TabStop = false;
            this.gBoxShip.Text = "Ship";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(40, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 63;
            this.label4.Text = "Distribution Center";
            // 
            // tBoxID_DistributionCenter
            // 
            this.tBoxID_DistributionCenter.Location = new System.Drawing.Point(144, 76);
            this.tBoxID_DistributionCenter.MaxLength = 5;
            this.tBoxID_DistributionCenter.Name = "tBoxID_DistributionCenter";
            this.tBoxID_DistributionCenter.Size = new System.Drawing.Size(72, 20);
            this.tBoxID_DistributionCenter.TabIndex = 62;
            this.tBoxID_DistributionCenter.Text = "";
            // 
            // ntbID_PackingSlip
            // 
            this.ntbID_PackingSlip.Location = new System.Drawing.Point(408, 36);
            this.ntbID_PackingSlip.Maximum = new System.Decimal(new int[] {
                                                                              8000,
                                                                              0,
                                                                              0,
                                                                              0});
            this.ntbID_PackingSlip.Minimum = new System.Decimal(new int[] {
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0});
            this.ntbID_PackingSlip.Name = "ntbID_PackingSlip";
            this.ntbID_PackingSlip.Size = new System.Drawing.Size(104, 20);
            this.ntbID_PackingSlip.TabIndex = 61;
            this.ntbID_PackingSlip.Value = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            // 
            // lIDPackingSlip
            // 
            this.lIDPackingSlip.Location = new System.Drawing.Point(304, 36);
            this.lIDPackingSlip.Name = "lIDPackingSlip";
            this.lIDPackingSlip.Size = new System.Drawing.Size(72, 20);
            this.lIDPackingSlip.TabIndex = 60;
            this.lIDPackingSlip.Text = "Packing Slip";
            // 
            // ntbID_PackingSlipLin
            // 
            this.ntbID_PackingSlipLin.Location = new System.Drawing.Point(408, 56);
            this.ntbID_PackingSlipLin.Maximum = new System.Decimal(new int[] {
                                                                                 999,
                                                                                 0,
                                                                                 0,
                                                                                 0});
            this.ntbID_PackingSlipLin.Minimum = new System.Decimal(new int[] {
                                                                                 0,
                                                                                 0,
                                                                                 0,
                                                                                 0});
            this.ntbID_PackingSlipLin.Name = "ntbID_PackingSlipLin";
            this.ntbID_PackingSlipLin.Size = new System.Drawing.Size(104, 20);
            this.ntbID_PackingSlipLin.TabIndex = 59;
            this.ntbID_PackingSlipLin.Value = new System.Decimal(new int[] {
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               0});
            // 
            // lIdPackingSlipLin
            // 
            this.lIdPackingSlipLin.Location = new System.Drawing.Point(304, 56);
            this.lIdPackingSlipLin.Name = "lIdPackingSlipLin";
            this.lIdPackingSlipLin.Size = new System.Drawing.Size(96, 20);
            this.lIdPackingSlipLin.TabIndex = 58;
            this.lIdPackingSlipLin.Text = "Packing Slip Line";
            // 
            // dtpID_DateShipped
            // 
            this.dtpID_DateShipped.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpID_DateShipped.Location = new System.Drawing.Point(408, 16);
            this.dtpID_DateShipped.Name = "dtpID_DateShipped";
            this.dtpID_DateShipped.Size = new System.Drawing.Size(88, 20);
            this.dtpID_DateShipped.TabIndex = 56;
            // 
            // lIDDateShipped
            // 
            this.lIDDateShipped.Location = new System.Drawing.Point(304, 16);
            this.lIDDateShipped.Name = "lIDDateShipped";
            this.lIDDateShipped.Size = new System.Drawing.Size(56, 20);
            this.lIDDateShipped.TabIndex = 57;
            this.lIDDateShipped.Text = "Ship Date";
            // 
            // schStkLoc
            // 
            this.schStkLoc.Location = new System.Drawing.Point(224, 60);
            this.schStkLoc.Name = "schStkLoc";
            this.schStkLoc.Size = new System.Drawing.Size(30, 16);
            this.schStkLoc.TabIndex = 54;
            this.schStkLoc.Text = "...";
            // 
            // lIDShipStkLoc
            // 
            this.lIDShipStkLoc.Location = new System.Drawing.Point(40, 56);
            this.lIDShipStkLoc.Name = "lIDShipStkLoc";
            this.lIDShipStkLoc.Size = new System.Drawing.Size(80, 20);
            this.lIDShipStkLoc.TabIndex = 53;
            this.lIDShipStkLoc.Text = "Stk. Location";
            // 
            // tBoxID_ShipStkLoc
            // 
            this.tBoxID_ShipStkLoc.Location = new System.Drawing.Point(144, 56);
            this.tBoxID_ShipStkLoc.MaxLength = 10;
            this.tBoxID_ShipStkLoc.Name = "tBoxID_ShipStkLoc";
            this.tBoxID_ShipStkLoc.Size = new System.Drawing.Size(72, 20);
            this.tBoxID_ShipStkLoc.TabIndex = 52;
            this.tBoxID_ShipStkLoc.Text = "";
            // 
            // btnSchPlant
            // 
            this.btnSchPlant.Location = new System.Drawing.Point(224, 40);
            this.btnSchPlant.Name = "btnSchPlant";
            this.btnSchPlant.Size = new System.Drawing.Size(30, 16);
            this.btnSchPlant.TabIndex = 15;
            this.btnSchPlant.Text = "...";
            // 
            // tBoxID_ShipPlant
            // 
            this.tBoxID_ShipPlant.Location = new System.Drawing.Point(144, 36);
            this.tBoxID_ShipPlant.MaxLength = 10;
            this.tBoxID_ShipPlant.Name = "tBoxID_ShipPlant";
            this.tBoxID_ShipPlant.Size = new System.Drawing.Size(72, 20);
            this.tBoxID_ShipPlant.TabIndex = 14;
            this.tBoxID_ShipPlant.Text = "";
            // 
            // lIDShipPlant
            // 
            this.lIDShipPlant.Location = new System.Drawing.Point(40, 36);
            this.lIDShipPlant.Name = "lIDShipPlant";
            this.lIDShipPlant.Size = new System.Drawing.Size(64, 20);
            this.lIDShipPlant.TabIndex = 13;
            this.lIDShipPlant.Text = "Plant";
            // 
            // btnSchCompany
            // 
            this.btnSchCompany.Location = new System.Drawing.Point(224, 20);
            this.btnSchCompany.Name = "btnSchCompany";
            this.btnSchCompany.Size = new System.Drawing.Size(30, 16);
            this.btnSchCompany.TabIndex = 11;
            this.btnSchCompany.Text = "...";
            // 
            // ntbID_ShipCompany
            // 
            this.ntbID_ShipCompany.Location = new System.Drawing.Point(144, 16);
            this.ntbID_ShipCompany.Maximum = new System.Decimal(new int[] {
                                                                              999,
                                                                              0,
                                                                              0,
                                                                              0});
            this.ntbID_ShipCompany.Minimum = new System.Decimal(new int[] {
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0});
            this.ntbID_ShipCompany.Name = "ntbID_ShipCompany";
            this.ntbID_ShipCompany.Size = new System.Drawing.Size(72, 20);
            this.ntbID_ShipCompany.TabIndex = 9;
            this.ntbID_ShipCompany.Value = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            // 
            // lIDShipCompany
            // 
            this.lIDShipCompany.Location = new System.Drawing.Point(40, 16);
            this.lIDShipCompany.Name = "lIDShipCompany";
            this.lIDShipCompany.Size = new System.Drawing.Size(64, 20);
            this.lIDShipCompany.TabIndex = 8;
            this.lIDShipCompany.Text = "Company";
            // 
            // gBoxQty
            // 
            this.gBoxQty.Controls.Add(this.ntbID_QtyShipped);
            this.gBoxQty.Controls.Add(this.lIDQtyOutstand);
            this.gBoxQty.Controls.Add(this.ntbID_Qty_Outstand);
            this.gBoxQty.Controls.Add(this.label2);
            this.gBoxQty.Controls.Add(this.ntbID_QtyShipInv);
            this.gBoxQty.Controls.Add(this.lIDQtyShipInv);
            this.gBoxQty.Controls.Add(this.lIDQSIUom);
            this.gBoxQty.Controls.Add(this.lIDQtyShipped);
            this.gBoxQty.Controls.Add(this.ntbID_QtyBackOrder);
            this.gBoxQty.Controls.Add(this.btnSchUomQsi);
            this.gBoxQty.Controls.Add(this.tBoxID_QSUom);
            this.gBoxQty.Controls.Add(this.textBox2);
            this.gBoxQty.Controls.Add(this.btnSchUom);
            this.gBoxQty.Controls.Add(this.lIDQtyBackOrder);
            this.gBoxQty.Location = new System.Drawing.Point(16, 120);
            this.gBoxQty.Name = "gBoxQty";
            this.gBoxQty.Size = new System.Drawing.Size(624, 96);
            this.gBoxQty.TabIndex = 39;
            this.gBoxQty.TabStop = false;
            this.gBoxQty.Text = "Qty";
            // 
            // ntbID_QtyShipped
            // 
            this.ntbID_QtyShipped.Location = new System.Drawing.Point(120, 16);
            this.ntbID_QtyShipped.Maximum = new System.Decimal(new int[] {
                                                                             1874919423,
                                                                             2328306,
                                                                             0,
                                                                             0});
            this.ntbID_QtyShipped.MaxPrecision = 5;
            this.ntbID_QtyShipped.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.ntbID_QtyShipped.Name = "ntbID_QtyShipped";
            this.ntbID_QtyShipped.Size = new System.Drawing.Size(136, 20);
            this.ntbID_QtyShipped.TabIndex = 13;
            this.ntbID_QtyShipped.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // lIDQtyOutstand
            // 
            this.lIDQtyOutstand.Location = new System.Drawing.Point(304, 56);
            this.lIDQtyOutstand.Name = "lIDQtyOutstand";
            this.lIDQtyOutstand.Size = new System.Drawing.Size(56, 20);
            this.lIDQtyOutstand.TabIndex = 22;
            this.lIDQtyOutstand.Text = "Outstand";
            // 
            // ntbID_Qty_Outstand
            // 
            this.ntbID_Qty_Outstand.Location = new System.Drawing.Point(368, 56);
            this.ntbID_Qty_Outstand.Maximum = new System.Decimal(new int[] {
                                                                               1874919423,
                                                                               2328306,
                                                                               0,
                                                                               0});
            this.ntbID_Qty_Outstand.MaxPrecision = 5;
            this.ntbID_Qty_Outstand.Minimum = new System.Decimal(new int[] {
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               0});
            this.ntbID_Qty_Outstand.Name = "ntbID_Qty_Outstand";
            this.ntbID_Qty_Outstand.Size = new System.Drawing.Size(136, 20);
            this.ntbID_Qty_Outstand.TabIndex = 23;
            this.ntbID_Qty_Outstand.Value = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(304, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "QS. Uom";
            // 
            // ntbID_QtyShipInv
            // 
            this.ntbID_QtyShipInv.Location = new System.Drawing.Point(120, 36);
            this.ntbID_QtyShipInv.Maximum = new System.Decimal(new int[] {
                                                                             1874919423,
                                                                             2328306,
                                                                             0,
                                                                             0});
            this.ntbID_QtyShipInv.MaxPrecision = 5;
            this.ntbID_QtyShipInv.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.ntbID_QtyShipInv.Name = "ntbID_QtyShipInv";
            this.ntbID_QtyShipInv.Size = new System.Drawing.Size(136, 20);
            this.ntbID_QtyShipInv.TabIndex = 18;
            this.ntbID_QtyShipInv.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // lIDQtyShipInv
            // 
            this.lIDQtyShipInv.Location = new System.Drawing.Point(40, 36);
            this.lIDQtyShipInv.Name = "lIDQtyShipInv";
            this.lIDQtyShipInv.Size = new System.Drawing.Size(56, 20);
            this.lIDQtyShipInv.TabIndex = 17;
            this.lIDQtyShipInv.Text = "Ship. Inv";
            // 
            // lIDQSIUom
            // 
            this.lIDQSIUom.Location = new System.Drawing.Point(304, 36);
            this.lIDQSIUom.Name = "lIDQSIUom";
            this.lIDQSIUom.Size = new System.Drawing.Size(56, 20);
            this.lIDQSIUom.TabIndex = 19;
            this.lIDQSIUom.Text = "QSI. Uom";
            // 
            // lIDQtyShipped
            // 
            this.lIDQtyShipped.Location = new System.Drawing.Point(40, 16);
            this.lIDQtyShipped.Name = "lIDQtyShipped";
            this.lIDQtyShipped.Size = new System.Drawing.Size(56, 20);
            this.lIDQtyShipped.TabIndex = 12;
            this.lIDQtyShipped.Text = "Shipped";
            // 
            // ntbID_QtyBackOrder
            // 
            this.ntbID_QtyBackOrder.Location = new System.Drawing.Point(120, 56);
            this.ntbID_QtyBackOrder.Maximum = new System.Decimal(new int[] {
                                                                               1874919423,
                                                                               2328306,
                                                                               0,
                                                                               0});
            this.ntbID_QtyBackOrder.MaxPrecision = 5;
            this.ntbID_QtyBackOrder.Minimum = new System.Decimal(new int[] {
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               0});
            this.ntbID_QtyBackOrder.Name = "ntbID_QtyBackOrder";
            this.ntbID_QtyBackOrder.Size = new System.Drawing.Size(136, 20);
            this.ntbID_QtyBackOrder.TabIndex = 25;
            this.ntbID_QtyBackOrder.Value = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            // 
            // btnSchUomQsi
            // 
            this.btnSchUomQsi.Location = new System.Drawing.Point(424, 40);
            this.btnSchUomQsi.Name = "btnSchUomQsi";
            this.btnSchUomQsi.Size = new System.Drawing.Size(32, 16);
            this.btnSchUomQsi.TabIndex = 21;
            this.btnSchUomQsi.Text = "...";
            // 
            // tBoxID_QSUom
            // 
            this.tBoxID_QSUom.Location = new System.Drawing.Point(368, 36);
            this.tBoxID_QSUom.MaxLength = 5;
            this.tBoxID_QSUom.Name = "tBoxID_QSUom";
            this.tBoxID_QSUom.Size = new System.Drawing.Size(48, 20);
            this.tBoxID_QSUom.TabIndex = 20;
            this.tBoxID_QSUom.Text = "";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(368, 16);
            this.textBox2.MaxLength = 5;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(48, 20);
            this.textBox2.TabIndex = 15;
            this.textBox2.Text = "";
            // 
            // btnSchUom
            // 
            this.btnSchUom.Location = new System.Drawing.Point(424, 20);
            this.btnSchUom.Name = "btnSchUom";
            this.btnSchUom.Size = new System.Drawing.Size(32, 16);
            this.btnSchUom.TabIndex = 16;
            this.btnSchUom.Text = "...";
            // 
            // lIDQtyBackOrder
            // 
            this.lIDQtyBackOrder.Location = new System.Drawing.Point(40, 56);
            this.lIDQtyBackOrder.Name = "lIDQtyBackOrder";
            this.lIDQtyBackOrder.Size = new System.Drawing.Size(80, 20);
            this.lIDQtyBackOrder.TabIndex = 24;
            this.lIDQtyBackOrder.Text = " Back Order";
            // 
            // tabPageAccounting
            // 
            this.tabPageAccounting.Controls.Add(this.button3);
            this.tabPageAccounting.Controls.Add(this.groupBox2);
            this.tabPageAccounting.Controls.Add(this.gBoxCost);
            this.tabPageAccounting.Controls.Add(this.groupBox1);
            this.tabPageAccounting.Controls.Add(this.groupBox4);
            this.tabPageAccounting.Controls.Add(this.gBoxTax);
            this.tabPageAccounting.Location = new System.Drawing.Point(4, 22);
            this.tabPageAccounting.Name = "tabPageAccounting";
            this.tabPageAccounting.Size = new System.Drawing.Size(696, 318);
            this.tabPageAccounting.TabIndex = 4;
            this.tabPageAccounting.Text = "Accounting";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(576, 280);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 23);
            this.button3.TabIndex = 46;
            this.button3.Text = "GL Distribution";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ntbID_ComPercent);
            this.groupBox2.Controls.Add(this.ntbID_CommRate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lIdCommPercent);
            this.groupBox2.Controls.Add(this.tBoxId_CommPlan);
            this.groupBox2.Controls.Add(this.lIdCommPlan);
            this.groupBox2.Controls.Add(this.btnSchSalesPer);
            this.groupBox2.Controls.Add(this.tBoxID_SalesPerson);
            this.groupBox2.Controls.Add(this.lIDSalesPerson);
            this.groupBox2.Location = new System.Drawing.Point(8, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 72);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Commision";
            // 
            // ntbID_ComPercent
            // 
            this.ntbID_ComPercent.Location = new System.Drawing.Point(104, 40);
            this.ntbID_ComPercent.Maximum = new System.Decimal(new int[] {
                                                                             9999999,
                                                                             0,
                                                                             0,
                                                                             0});
            this.ntbID_ComPercent.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.ntbID_ComPercent.Name = "ntbID_ComPercent";
            this.ntbID_ComPercent.Size = new System.Drawing.Size(104, 20);
            this.ntbID_ComPercent.TabIndex = 62;
            this.ntbID_ComPercent.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // ntbID_CommRate
            // 
            this.ntbID_CommRate.Location = new System.Drawing.Point(312, 40);
            this.ntbID_CommRate.Maximum = new System.Decimal(new int[] {
                                                                           -727379969,
                                                                           232,
                                                                           0,
                                                                           0});
            this.ntbID_CommRate.MaxPrecision = 6;
            this.ntbID_CommRate.Minimum = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            this.ntbID_CommRate.Name = "ntbID_CommRate";
            this.ntbID_CommRate.Size = new System.Drawing.Size(104, 20);
            this.ntbID_CommRate.TabIndex = 61;
            this.ntbID_CommRate.Value = new System.Decimal(new int[] {
                                                                         0,
                                                                         0,
                                                                         0,
                                                                         0});
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(216, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 57;
            this.label5.Text = "Commission Rate";
            // 
            // lIdCommPercent
            // 
            this.lIdCommPercent.Location = new System.Drawing.Point(8, 40);
            this.lIdCommPercent.Name = "lIdCommPercent";
            this.lIdCommPercent.Size = new System.Drawing.Size(80, 16);
            this.lIdCommPercent.TabIndex = 53;
            this.lIdCommPercent.Text = "Commission %";
            // 
            // tBoxId_CommPlan
            // 
            this.tBoxId_CommPlan.Location = new System.Drawing.Point(424, 16);
            this.tBoxId_CommPlan.MaxLength = 10;
            this.tBoxId_CommPlan.Name = "tBoxId_CommPlan";
            this.tBoxId_CommPlan.Size = new System.Drawing.Size(72, 20);
            this.tBoxId_CommPlan.TabIndex = 14;
            this.tBoxId_CommPlan.Text = "";
            // 
            // lIdCommPlan
            // 
            this.lIdCommPlan.Location = new System.Drawing.Point(392, 16);
            this.lIdCommPlan.Name = "lIdCommPlan";
            this.lIdCommPlan.Size = new System.Drawing.Size(32, 16);
            this.lIdCommPlan.TabIndex = 13;
            this.lIdCommPlan.Text = "Plan";
            // 
            // btnSchSalesPer
            // 
            this.btnSchSalesPer.Location = new System.Drawing.Point(344, 16);
            this.btnSchSalesPer.Name = "btnSchSalesPer";
            this.btnSchSalesPer.Size = new System.Drawing.Size(30, 16);
            this.btnSchSalesPer.TabIndex = 11;
            this.btnSchSalesPer.Text = "...";
            // 
            // tBoxID_SalesPerson
            // 
            this.tBoxID_SalesPerson.Location = new System.Drawing.Point(104, 16);
            this.tBoxID_SalesPerson.MaxLength = 40;
            this.tBoxID_SalesPerson.Name = "tBoxID_SalesPerson";
            this.tBoxID_SalesPerson.ReadOnly = true;
            this.tBoxID_SalesPerson.Size = new System.Drawing.Size(232, 20);
            this.tBoxID_SalesPerson.TabIndex = 10;
            this.tBoxID_SalesPerson.Text = "";
            // 
            // lIDSalesPerson
            // 
            this.lIDSalesPerson.Location = new System.Drawing.Point(8, 16);
            this.lIDSalesPerson.Name = "lIDSalesPerson";
            this.lIDSalesPerson.Size = new System.Drawing.Size(72, 16);
            this.lIDSalesPerson.TabIndex = 8;
            this.lIDSalesPerson.Text = "Sales Person";
            // 
            // gBoxCost
            // 
            this.gBoxCost.Controls.Add(this.numericTextBox18);
            this.gBoxCost.Controls.Add(this.label24);
            this.gBoxCost.Controls.Add(this.label23);
            this.gBoxCost.Controls.Add(this.numericTextBox17);
            this.gBoxCost.Controls.Add(this.label22);
            this.gBoxCost.Controls.Add(this.numericTextBox16);
            this.gBoxCost.Controls.Add(this.label21);
            this.gBoxCost.Controls.Add(this.numericTextBox15);
            this.gBoxCost.Controls.Add(this.label20);
            this.gBoxCost.Controls.Add(this.numericTextBox14);
            this.gBoxCost.Controls.Add(this.label19);
            this.gBoxCost.Controls.Add(this.numericTextBox13);
            this.gBoxCost.Controls.Add(this.label18);
            this.gBoxCost.Controls.Add(this.numericTextBox12);
            this.gBoxCost.Controls.Add(this.label17);
            this.gBoxCost.Controls.Add(this.numericTextBox11);
            this.gBoxCost.Controls.Add(this.label16);
            this.gBoxCost.Controls.Add(this.numericTextBox10);
            this.gBoxCost.Controls.Add(this.label15);
            this.gBoxCost.Controls.Add(this.numericTextBox7);
            this.gBoxCost.Controls.Add(this.label12);
            this.gBoxCost.Controls.Add(this.numericTextBox9);
            this.gBoxCost.Controls.Add(this.label14);
            this.gBoxCost.Controls.Add(this.numericTextBox5);
            this.gBoxCost.Controls.Add(this.label10);
            this.gBoxCost.Controls.Add(this.numericTextBox2);
            this.gBoxCost.Controls.Add(this.label9);
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
            this.gBoxCost.Location = new System.Drawing.Point(8, 0);
            this.gBoxCost.Name = "gBoxCost";
            this.gBoxCost.Size = new System.Drawing.Size(360, 224);
            this.gBoxCost.TabIndex = 43;
            this.gBoxCost.TabStop = false;
            // 
            // numericTextBox18
            // 
            this.numericTextBox18.Location = new System.Drawing.Point(224, 196);
            this.numericTextBox18.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox18.MaxPrecision = 5;
            this.numericTextBox18.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox18.Name = "numericTextBox18";
            this.numericTextBox18.Size = new System.Drawing.Size(128, 20);
            this.numericTextBox18.TabIndex = 39;
            this.numericTextBox18.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(128, 200);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(88, 16);
            this.label24.TabIndex = 38;
            this.label24.Text = "Total ";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(8, 88);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 16);
            this.label23.TabIndex = 37;
            this.label23.Text = "Lab ";
            // 
            // numericTextBox17
            // 
            this.numericTextBox17.Location = new System.Drawing.Point(264, 108);
            this.numericTextBox17.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox17.MaxPrecision = 5;
            this.numericTextBox17.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox17.Name = "numericTextBox17";
            this.numericTextBox17.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox17.TabIndex = 36;
            this.numericTextBox17.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(184, 112);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 16);
            this.label22.TabIndex = 35;
            this.label22.Text = "User Cost 2";
            // 
            // numericTextBox16
            // 
            this.numericTextBox16.Location = new System.Drawing.Point(264, 148);
            this.numericTextBox16.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox16.MaxPrecision = 5;
            this.numericTextBox16.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox16.Name = "numericTextBox16";
            this.numericTextBox16.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox16.TabIndex = 34;
            this.numericTextBox16.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(184, 152);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 16);
            this.label21.TabIndex = 33;
            this.label21.Text = "User Cost 4";
            // 
            // numericTextBox15
            // 
            this.numericTextBox15.Location = new System.Drawing.Point(264, 128);
            this.numericTextBox15.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox15.MaxPrecision = 5;
            this.numericTextBox15.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox15.Name = "numericTextBox15";
            this.numericTextBox15.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox15.TabIndex = 32;
            this.numericTextBox15.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(184, 132);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 16);
            this.label20.TabIndex = 31;
            this.label20.Text = "User Cost 3";
            // 
            // numericTextBox14
            // 
            this.numericTextBox14.Location = new System.Drawing.Point(264, 168);
            this.numericTextBox14.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox14.MaxPrecision = 5;
            this.numericTextBox14.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox14.Name = "numericTextBox14";
            this.numericTextBox14.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox14.TabIndex = 30;
            this.numericTextBox14.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(184, 176);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 16);
            this.label19.TabIndex = 29;
            this.label19.Text = "User Cost 5";
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
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(184, 92);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 16);
            this.label18.TabIndex = 27;
            this.label18.Text = "User Cost 1";
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
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(184, 72);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 16);
            this.label17.TabIndex = 25;
            this.label17.Text = "Curr. Exchange";
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
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(184, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 16);
            this.label16.TabIndex = 23;
            this.label16.Text = "Outside Proc";
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
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(184, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 16);
            this.label15.TabIndex = 21;
            this.label15.Text = "Warehouseing";
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
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(184, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 16);
            this.label12.TabIndex = 19;
            this.label12.Text = "InDirect Labour";
            // 
            // numericTextBox9
            // 
            this.numericTextBox9.Location = new System.Drawing.Point(88, 168);
            this.numericTextBox9.Maximum = new System.Decimal(new int[] {
                                                                            -1530494977,
                                                                            232830,
                                                                            0,
                                                                            0});
            this.numericTextBox9.MaxPrecision = 5;
            this.numericTextBox9.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox9.Name = "numericTextBox9";
            this.numericTextBox9.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox9.TabIndex = 18;
            this.numericTextBox9.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 176);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 16);
            this.label14.TabIndex = 17;
            this.label14.Text = "InDirect Burden";
            // 
            // numericTextBox5
            // 
            this.numericTextBox5.Location = new System.Drawing.Point(88, 148);
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
            this.numericTextBox5.TabIndex = 16;
            this.numericTextBox5.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 16);
            this.label10.TabIndex = 15;
            this.label10.Text = "Direct Labour";
            // 
            // numericTextBox2
            // 
            this.numericTextBox2.Location = new System.Drawing.Point(88, 128);
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
            this.numericTextBox2.TabIndex = 14;
            this.numericTextBox2.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "Direct Burden";
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
            this.lIdCostExt.Location = new System.Drawing.Point(8, 48);
            this.lIdCostExt.Name = "lIdCostExt";
            this.lIdCostExt.Size = new System.Drawing.Size(48, 16);
            this.lIdCostExt.TabIndex = 0;
            this.lIdCostExt.Text = "Ext.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericTextBox19);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.ntbID_RoyCharges);
            this.groupBox1.Controls.Add(this.ntbId_FreigthAmt);
            this.groupBox1.Controls.Add(this.lIDRoyCharges);
            this.groupBox1.Controls.Add(this.lIdFreightAmt);
            this.groupBox1.Controls.Add(this.numericTextBox6);
            this.groupBox1.Controls.Add(this.numericTextBox8);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(368, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 128);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sales";
            // 
            // numericTextBox19
            // 
            this.numericTextBox19.Location = new System.Drawing.Point(72, 104);
            this.numericTextBox19.Maximum = new System.Decimal(new int[] {
                                                                             1316134911,
                                                                             2328,
                                                                             0,
                                                                             0});
            this.numericTextBox19.MaxPrecision = 2;
            this.numericTextBox19.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox19.Name = "numericTextBox19";
            this.numericTextBox19.Size = new System.Drawing.Size(64, 20);
            this.numericTextBox19.TabIndex = 11;
            this.numericTextBox19.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(8, 104);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(52, 16);
            this.label25.TabIndex = 10;
            this.label25.Text = "Total";
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
            // numericTextBox6
            // 
            this.numericTextBox6.Location = new System.Drawing.Point(72, 36);
            this.numericTextBox6.Maximum = new System.Decimal(new int[] {
                                                                            -727379969,
                                                                            232,
                                                                            0,
                                                                            0});
            this.numericTextBox6.MaxPrecision = 2;
            this.numericTextBox6.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox6.Name = "numericTextBox6";
            this.numericTextBox6.Size = new System.Drawing.Size(64, 20);
            this.numericTextBox6.TabIndex = 5;
            this.numericTextBox6.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // numericTextBox8
            // 
            this.numericTextBox8.Location = new System.Drawing.Point(72, 16);
            this.numericTextBox8.Maximum = new System.Decimal(new int[] {
                                                                            -727379969,
                                                                            232,
                                                                            0,
                                                                            0});
            this.numericTextBox8.MaxPrecision = 2;
            this.numericTextBox8.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox8.Name = "numericTextBox8";
            this.numericTextBox8.Size = new System.Drawing.Size(64, 20);
            this.numericTextBox8.TabIndex = 3;
            this.numericTextBox8.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Discounts";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "Commisions";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tBoxID_GLSalesAcc);
            this.groupBox4.Controls.Add(this.lIDGLSalesAcc);
            this.groupBox4.Controls.Add(this.lIDGLCosAcc);
            this.groupBox4.Controls.Add(this.tBoxID_GLCosAcc);
            this.groupBox4.Controls.Add(this.tBoxID_GLCosType);
            this.groupBox4.Controls.Add(this.lIDGLCosType);
            this.groupBox4.Location = new System.Drawing.Point(512, 128);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(152, 96);
            this.groupBox4.TabIndex = 43;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "General Leadger";
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
            this.gBoxTax.Location = new System.Drawing.Point(512, 0);
            this.gBoxTax.Name = "gBoxTax";
            this.gBoxTax.Size = new System.Drawing.Size(152, 128);
            this.gBoxTax.TabIndex = 42;
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
            // tabPageComponentList
            // 
            this.tabPageComponentList.Controls.Add(this.btnDeletePart);
            this.tabPageComponentList.Controls.Add(this.btnEditPart);
            this.tabPageComponentList.Controls.Add(this.btnAddPart);
            this.tabPageComponentList.Controls.Add(this.dGridComponents);
            this.tabPageComponentList.Controls.Add(this.textBox3);
            this.tabPageComponentList.Controls.Add(this.lIDComponentList);
            this.tabPageComponentList.Location = new System.Drawing.Point(4, 22);
            this.tabPageComponentList.Name = "tabPageComponentList";
            this.tabPageComponentList.Size = new System.Drawing.Size(696, 318);
            this.tabPageComponentList.TabIndex = 5;
            this.tabPageComponentList.Text = "Component List";
            // 
            // btnDeletePart
            // 
            this.btnDeletePart.Location = new System.Drawing.Point(600, 328);
            this.btnDeletePart.Name = "btnDeletePart";
            this.btnDeletePart.TabIndex = 14;
            this.btnDeletePart.Text = "Delete";
            // 
            // btnEditPart
            // 
            this.btnEditPart.Location = new System.Drawing.Point(520, 328);
            this.btnEditPart.Name = "btnEditPart";
            this.btnEditPart.TabIndex = 13;
            this.btnEditPart.Text = "Edit";
            // 
            // btnAddPart
            // 
            this.btnAddPart.Location = new System.Drawing.Point(432, 328);
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.TabIndex = 12;
            this.btnAddPart.Text = "Add";
            // 
            // dGridComponents
            // 
            this.dGridComponents.DataMember = "";
            this.dGridComponents.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridComponents.Location = new System.Drawing.Point(8, 48);
            this.dGridComponents.Name = "dGridComponents";
            this.dGridComponents.Size = new System.Drawing.Size(680, 264);
            this.dGridComponents.TabIndex = 11;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(104, 16);
            this.textBox3.MaxLength = 10;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(72, 20);
            this.textBox3.TabIndex = 10;
            this.textBox3.Text = "";
            // 
            // lIDComponentList
            // 
            this.lIDComponentList.Location = new System.Drawing.Point(16, 16);
            this.lIDComponentList.Name = "lIDComponentList";
            this.lIDComponentList.Size = new System.Drawing.Size(88, 16);
            this.lIDComponentList.TabIndex = 9;
            this.lIDComponentList.Text = "Component List";
            // 
            // tabPageSales
            // 
            this.tabPageSales.Controls.Add(this.gBoxSalesCode);
            this.tabPageSales.Location = new System.Drawing.Point(4, 22);
            this.tabPageSales.Name = "tabPageSales";
            this.tabPageSales.Size = new System.Drawing.Size(696, 318);
            this.tabPageSales.TabIndex = 7;
            this.tabPageSales.Text = "Sales";
            // 
            // gBoxSalesCode
            // 
            this.gBoxSalesCode.Controls.Add(this.textBox11);
            this.gBoxSalesCode.Controls.Add(this.textBox10);
            this.gBoxSalesCode.Controls.Add(this.textBox9);
            this.gBoxSalesCode.Controls.Add(this.textBox8);
            this.gBoxSalesCode.Controls.Add(this.textBox7);
            this.gBoxSalesCode.Controls.Add(this.textBox6);
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
            this.gBoxSalesCode.Location = new System.Drawing.Point(24, 16);
            this.gBoxSalesCode.Name = "gBoxSalesCode";
            this.gBoxSalesCode.Size = new System.Drawing.Size(400, 176);
            this.gBoxSalesCode.TabIndex = 3;
            this.gBoxSalesCode.TabStop = false;
            this.gBoxSalesCode.Text = "Sales Code";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(144, 48);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(192, 20);
            this.textBox11.TabIndex = 96;
            this.textBox11.Text = "";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(144, 72);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(192, 20);
            this.textBox10.TabIndex = 95;
            this.textBox10.Text = "";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(144, 144);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(192, 20);
            this.textBox9.TabIndex = 94;
            this.textBox9.Text = "";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(144, 118);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(192, 20);
            this.textBox8.TabIndex = 93;
            this.textBox8.Text = "";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(144, 96);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(192, 20);
            this.textBox7.TabIndex = 92;
            this.textBox7.Text = "";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(144, 24);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(192, 20);
            this.textBox6.TabIndex = 91;
            this.textBox6.Text = "";
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
            this.btnSchSc.Location = new System.Drawing.Point(352, 24);
            this.btnSchSc.Name = "btnSchSc";
            this.btnSchSc.Size = new System.Drawing.Size(30, 16);
            this.btnSchSc.TabIndex = 90;
            this.btnSchSc.Text = "...";
            // 
            // tBoxID_Description
            // 
            this.tBoxID_Description.Location = new System.Drawing.Point(496, 16);
            this.tBoxID_Description.MaxLength = 120;
            this.tBoxID_Description.Multiline = true;
            this.tBoxID_Description.Name = "tBoxID_Description";
            this.tBoxID_Description.Size = new System.Drawing.Size(192, 56);
            this.tBoxID_Description.TabIndex = 34;
            this.tBoxID_Description.Text = "";
            // 
            // lIDDescription
            // 
            this.lIDDescription.Location = new System.Drawing.Point(424, 16);
            this.lIDDescription.Name = "lIDDescription";
            this.lIDDescription.Size = new System.Drawing.Size(64, 16);
            this.lIDDescription.TabIndex = 33;
            this.lIDDescription.Text = "Description";
            // 
            // gBoxPart
            // 
            this.gBoxPart.Controls.Add(this.button4);
            this.gBoxPart.Controls.Add(this.btnSchCustPart);
            this.gBoxPart.Controls.Add(this.button1);
            this.gBoxPart.Controls.Add(this.lIDPart);
            this.gBoxPart.Controls.Add(this.tBoxID_Revision);
            this.gBoxPart.Controls.Add(this.lIDRevision);
            this.gBoxPart.Controls.Add(this.tBoxID_Part);
            this.gBoxPart.Controls.Add(this.lIDSequence);
            this.gBoxPart.Controls.Add(this.tBoxID_CustPart);
            this.gBoxPart.Controls.Add(this.lIDCustPart);
            this.gBoxPart.Controls.Add(this.tBoxID_Sequence);
            this.gBoxPart.Controls.Add(this.lIDDescription);
            this.gBoxPart.Controls.Add(this.tBoxID_Description);
            this.gBoxPart.Location = new System.Drawing.Point(8, 144);
            this.gBoxPart.Name = "gBoxPart";
            this.gBoxPart.Size = new System.Drawing.Size(808, 88);
            this.gBoxPart.TabIndex = 38;
            this.gBoxPart.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(704, 48);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(72, 24);
            this.button4.TabIndex = 35;
            this.button4.Text = "Description";
            // 
            // btnSchCustPart
            // 
            this.btnSchCustPart.Location = new System.Drawing.Point(312, 40);
            this.btnSchCustPart.Name = "btnSchCustPart";
            this.btnSchCustPart.Size = new System.Drawing.Size(32, 16);
            this.btnSchCustPart.TabIndex = 11;
            this.btnSchCustPart.Text = "...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 16);
            this.button1.TabIndex = 2;
            this.button1.Text = "...";
            // 
            // lIDPart
            // 
            this.lIDPart.Location = new System.Drawing.Point(8, 20);
            this.lIDPart.Name = "lIDPart";
            this.lIDPart.Size = new System.Drawing.Size(40, 16);
            this.lIDPart.TabIndex = 0;
            this.lIDPart.Text = "Part";
            // 
            // tBoxID_Revision
            // 
            this.tBoxID_Revision.Location = new System.Drawing.Point(64, 56);
            this.tBoxID_Revision.MaxLength = 40;
            this.tBoxID_Revision.Name = "tBoxID_Revision";
            this.tBoxID_Revision.Size = new System.Drawing.Size(240, 20);
            this.tBoxID_Revision.TabIndex = 6;
            this.tBoxID_Revision.Text = "";
            // 
            // lIDRevision
            // 
            this.lIDRevision.Location = new System.Drawing.Point(8, 60);
            this.lIDRevision.Name = "lIDRevision";
            this.lIDRevision.Size = new System.Drawing.Size(48, 16);
            this.lIDRevision.TabIndex = 5;
            this.lIDRevision.Text = "Revision";
            // 
            // tBoxID_Part
            // 
            this.tBoxID_Part.Location = new System.Drawing.Point(64, 16);
            this.tBoxID_Part.MaxLength = 40;
            this.tBoxID_Part.Name = "tBoxID_Part";
            this.tBoxID_Part.Size = new System.Drawing.Size(240, 20);
            this.tBoxID_Part.TabIndex = 1;
            this.tBoxID_Part.Text = "";
            // 
            // lIDSequence
            // 
            this.lIDSequence.Location = new System.Drawing.Point(312, 60);
            this.lIDSequence.Name = "lIDSequence";
            this.lIDSequence.Size = new System.Drawing.Size(56, 16);
            this.lIDSequence.TabIndex = 3;
            this.lIDSequence.Text = "Sequence";
            // 
            // tBoxID_CustPart
            // 
            this.tBoxID_CustPart.Location = new System.Drawing.Point(64, 36);
            this.tBoxID_CustPart.MaxLength = 40;
            this.tBoxID_CustPart.Name = "tBoxID_CustPart";
            this.tBoxID_CustPart.Size = new System.Drawing.Size(240, 20);
            this.tBoxID_CustPart.TabIndex = 8;
            this.tBoxID_CustPart.Text = "";
            // 
            // lIDCustPart
            // 
            this.lIDCustPart.Location = new System.Drawing.Point(8, 40);
            this.lIDCustPart.Name = "lIDCustPart";
            this.lIDCustPart.Size = new System.Drawing.Size(56, 16);
            this.lIDCustPart.TabIndex = 7;
            this.lIDCustPart.Text = "Cust. Part";
            // 
            // tBoxID_Sequence
            // 
            this.tBoxID_Sequence.Location = new System.Drawing.Point(368, 56);
            this.tBoxID_Sequence.MaxLength = 10;
            this.tBoxID_Sequence.Name = "tBoxID_Sequence";
            this.tBoxID_Sequence.ReadOnly = true;
            this.tBoxID_Sequence.Size = new System.Drawing.Size(56, 20);
            this.tBoxID_Sequence.TabIndex = 4;
            this.tBoxID_Sequence.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label34);
            this.groupBox5.Controls.Add(this.textBox20);
            this.groupBox5.Controls.Add(this.label33);
            this.groupBox5.Controls.Add(this.dateTimePicker4);
            this.groupBox5.Controls.Add(this.label32);
            this.groupBox5.Controls.Add(this.dateTimePicker3);
            this.groupBox5.Controls.Add(this.label31);
            this.groupBox5.Controls.Add(this.textBox19);
            this.groupBox5.Controls.Add(this.label30);
            this.groupBox5.Controls.Add(this.dateTimePicker2);
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Controls.Add(this.numericTextBox20);
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Controls.Add(this.textBox18);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.textBox12);
            this.groupBox5.Controls.Add(this.ntbIH_ARYear);
            this.groupBox5.Controls.Add(this.ntbIH_ARPeriod);
            this.groupBox5.Controls.Add(this.lIHARYear);
            this.groupBox5.Controls.Add(this.lIH_ARPeriod);
            this.groupBox5.Controls.Add(this.ntboxID_InvoiceNum);
            this.groupBox5.Controls.Add(this.lIDInvoiceNum);
            this.groupBox5.Controls.Add(this.lIhInvDate);
            this.groupBox5.Controls.Add(this.dtpIH_InvDate);
            this.groupBox5.Controls.Add(this.tBoxID_DataBase);
            this.groupBox5.Controls.Add(this.lIDDb);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.textBox5);
            this.groupBox5.Controls.Add(this.ntboxID_Company);
            this.groupBox5.Controls.Add(this.tBoxID_Plant);
            this.groupBox5.Controls.Add(this.lIDPlant);
            this.groupBox5.Controls.Add(this.lIDCompany);
            this.groupBox5.Controls.Add(this.lIHInvoiceTotal);
            this.groupBox5.Controls.Add(this.ntbIHInvTotal);
            this.groupBox5.Controls.Add(this.lIHInvType);
            this.groupBox5.Controls.Add(this.tBoxIH_InvType);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.lIvCredit);
            this.groupBox5.Controls.Add(this.numericTextBox1);
            this.groupBox5.Controls.Add(this.lIDReleaseNum);
            this.groupBox5.Controls.Add(this.ntbID_OrderItemNum);
            this.groupBox5.Controls.Add(this.lIDOrderItemNum);
            this.groupBox5.Controls.Add(this.ntbID_InvLineNum);
            this.groupBox5.Controls.Add(this.lIDInvLineNum);
            this.groupBox5.Controls.Add(this.ntbID_OrderNum);
            this.groupBox5.Controls.Add(this.lIDOrderNum);
            this.groupBox5.Location = new System.Drawing.Point(8, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(808, 144);
            this.groupBox5.TabIndex = 39;
            this.groupBox5.TabStop = false;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(352, 96);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(80, 20);
            this.label34.TabIndex = 73;
            this.label34.Text = "Invoice Status";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(432, 96);
            this.textBox20.MaxLength = 10;
            this.textBox20.Name = "textBox20";
            this.textBox20.ReadOnly = true;
            this.textBox20.Size = new System.Drawing.Size(72, 20);
            this.textBox20.TabIndex = 74;
            this.textBox20.Text = "";
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(512, 76);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(64, 20);
            this.label33.TabIndex = 72;
            this.label33.Text = "Date Paid";
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Enabled = false;
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker4.Location = new System.Drawing.Point(600, 76);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(88, 20);
            this.dateTimePicker4.TabIndex = 71;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(512, 56);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(64, 20);
            this.label32.TabIndex = 70;
            this.label32.Text = "Date Sent";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Enabled = false;
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(600, 56);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(88, 20);
            this.dateTimePicker3.TabIndex = 69;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(168, 60);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(88, 16);
            this.label31.TabIndex = 64;
            this.label31.Text = "Invoice Balance";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(256, 56);
            this.textBox19.MaxLength = 10;
            this.textBox19.Name = "textBox19";
            this.textBox19.ReadOnly = true;
            this.textBox19.Size = new System.Drawing.Size(88, 20);
            this.textBox19.TabIndex = 65;
            this.textBox19.Text = "";
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(512, 36);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(72, 20);
            this.label30.TabIndex = 63;
            this.label30.Text = "Date Created";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(600, 36);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(88, 20);
            this.dateTimePicker2.TabIndex = 62;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(352, 36);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(64, 20);
            this.label29.TabIndex = 60;
            this.label29.Text = "Total Lines";
            // 
            // numericTextBox20
            // 
            this.numericTextBox20.Location = new System.Drawing.Point(432, 36);
            this.numericTextBox20.Maximum = new System.Decimal(new int[] {
                                                                             -727379969,
                                                                             232,
                                                                             0,
                                                                             0});
            this.numericTextBox20.MaxPrecision = 2;
            this.numericTextBox20.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox20.Name = "numericTextBox20";
            this.numericTextBox20.ReadOnly = true;
            this.numericTextBox20.Size = new System.Drawing.Size(72, 20);
            this.numericTextBox20.TabIndex = 61;
            this.numericTextBox20.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(512, 16);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(88, 20);
            this.label28.TabIndex = 58;
            this.label28.Text = "Customer Name";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(600, 16);
            this.textBox18.MaxLength = 40;
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(148, 20);
            this.textBox18.TabIndex = 57;
            this.textBox18.Text = "";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(352, 16);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(64, 20);
            this.label27.TabIndex = 56;
            this.label27.Text = "Customer #";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(432, 16);
            this.textBox12.MaxLength = 20;
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(72, 20);
            this.textBox12.TabIndex = 55;
            this.textBox12.Text = "";
            // 
            // ntbIH_ARYear
            // 
            this.ntbIH_ARYear.Location = new System.Drawing.Point(432, 56);
            this.ntbIH_ARYear.Maximum = new System.Decimal(new int[] {
                                                                         99999999,
                                                                         0,
                                                                         0,
                                                                         0});
            this.ntbIH_ARYear.Minimum = new System.Decimal(new int[] {
                                                                         0,
                                                                         0,
                                                                         0,
                                                                         0});
            this.ntbIH_ARYear.Name = "ntbIH_ARYear";
            this.ntbIH_ARYear.ReadOnly = true;
            this.ntbIH_ARYear.Size = new System.Drawing.Size(72, 20);
            this.ntbIH_ARYear.TabIndex = 68;
            this.ntbIH_ARYear.Value = new System.Decimal(new int[] {
                                                                       0,
                                                                       0,
                                                                       0,
                                                                       0});
            // 
            // ntbIH_ARPeriod
            // 
            this.ntbIH_ARPeriod.Location = new System.Drawing.Point(432, 76);
            this.ntbIH_ARPeriod.Maximum = new System.Decimal(new int[] {
                                                                           99999999,
                                                                           0,
                                                                           0,
                                                                           0});
            this.ntbIH_ARPeriod.Minimum = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            this.ntbIH_ARPeriod.Name = "ntbIH_ARPeriod";
            this.ntbIH_ARPeriod.ReadOnly = true;
            this.ntbIH_ARPeriod.Size = new System.Drawing.Size(72, 20);
            this.ntbIH_ARPeriod.TabIndex = 67;
            this.ntbIH_ARPeriod.Value = new System.Decimal(new int[] {
                                                                         0,
                                                                         0,
                                                                         0,
                                                                         0});
            // 
            // lIHARYear
            // 
            this.lIHARYear.Location = new System.Drawing.Point(352, 56);
            this.lIHARYear.Name = "lIHARYear";
            this.lIHARYear.Size = new System.Drawing.Size(56, 20);
            this.lIHARYear.TabIndex = 66;
            this.lIHARYear.Text = "Fiscal YY";
            // 
            // lIH_ARPeriod
            // 
            this.lIH_ARPeriod.Location = new System.Drawing.Point(352, 76);
            this.lIH_ARPeriod.Name = "lIH_ARPeriod";
            this.lIH_ARPeriod.Size = new System.Drawing.Size(56, 20);
            this.lIH_ARPeriod.TabIndex = 65;
            this.lIH_ARPeriod.Text = "Fiscal PP";
            // 
            // InvoiceDtlEditForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(824, 630);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.gBoxPart);
            this.Controls.Add(this.tabControlInvDtl);
            this.Controls.Add(this.gBoxBtns);
            this.Name = "InvoiceDtlEditForm";
            this.Text = "Invoice Detail";
            this.gBoxBtns.ResumeLayout(false);
            this.tabControlInvDtl.ResumeLayout(false);
            this.tabPagePart.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.gBoxOthersSC.ResumeLayout(false);
            this.tabPageShippmet.ResumeLayout(false);
            this.gBoxShip.ResumeLayout(false);
            this.gBoxQty.ResumeLayout(false);
            this.tabPageAccounting.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gBoxCost.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.gBoxTax.ResumeLayout(false);
            this.tabPageComponentList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridComponents)).EndInit();
            this.tabPageSales.ResumeLayout(false);
            this.gBoxSalesCode.ResumeLayout(false);
            this.gBoxPart.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

     
private void setDatesFormat(){

    this.dtpID_DateShipped.Format = DateTimePickerFormat.Short;
    this.dtpIH_InvDate.Format = DateTimePickerFormat.Short;
}

private void tabControlInvDtl_SelectedIndexChanged(object sender, System.EventArgs e){
 
 loadTabPage(this.tabControlInvDtl.SelectedTab);

}

private void loadTabPage(TabPage tabPage){
  
  	switch (tabPage.Name){
			case "tabPageComponentList":
                loadGridComponents();
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
string[][] vec = new String[8][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
		     case "0":
				v[0]="Lin #";
				v[1] = "90";
				break;
		    case "1":
				v[0]="Component";
				v[1] = "60";
				break;
			case "2":
				v[0]="Description";
				v[1] = "90";
				break;
            case "3":
				v[0]="Qty";
				v[1] = "60";
				break;
            case "4":
				v[0]="Price";
				v[1] = "60";
				break;
            case "5":
				v[0]="Extension";
				v[1] = "80";
				break;	
            case "6":
				v[0]="Uom Qty";
				v[1] = "80";
				break;	
            case "7":
				v[0]="Uom Pricing";
				v[1] = "80";
				break;	
		}
		
		vec[i]=v;
		i++;	
	}
	return vec;
}

private void button2_Click(object sender, System.EventArgs e){
    AddDiscountInvoiceForm addDiscountInvoiceForm= new AddDiscountInvoiceForm();
    addDiscountInvoiceForm.ShowDialog();

}


      

        
}
}
