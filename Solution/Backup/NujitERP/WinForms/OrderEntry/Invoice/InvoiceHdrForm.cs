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
using Nujit.NujitERP.WinForms.Orders;

namespace Nujit.NujitERP.WinForms.OrderEntry.Invoice{
	/// <summary>
	/// Summary description for InvoiceHdrForm.
	/// </summary>
	public class InvoiceHdrForm : System.Windows.Forms.Form	{
        private System.Windows.Forms.GroupBox gBoxKeyData;
        private System.Windows.Forms.Label lIHDb;
        private System.Windows.Forms.Label lIHCompany;
        private System.Windows.Forms.Label lIHPlant;
        private System.Windows.Forms.Label lIHInvoiceNum;
        private System.Windows.Forms.TextBox tBoxIHDataBase;
        private System.Windows.Forms.TextBox tBoxIHPlant;
        private NujitCustomWinControls.NumericTextBox ntboxIHCompany;
        private NujitCustomWinControls.NumericTextBox ntboxIHInvoiceNum;
        private System.Windows.Forms.GroupBox gBoxBtns;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TabPage tabPageHeader;
        private System.Windows.Forms.Label lIHInvType;
        private System.Windows.Forms.TextBox tBoxIH_InvType;
        private System.Windows.Forms.Label lIHPODate;
        private System.Windows.Forms.DateTimePicker dtpIH_PODate;
        private System.Windows.Forms.DateTimePicker dtpIH_OrderDate;
        private System.Windows.Forms.Label lIHOrderDate;
        private System.Windows.Forms.Label lIHPoNum;
        private System.Windows.Forms.TextBox tBoxIH_PONum;
        private NujitCustomWinControls.NumericTextBox ntbIH_BatchNum;
        private System.Windows.Forms.Label lIHBatchNum;
        private System.Windows.Forms.TabPage tabPagePart;
        private System.Windows.Forms.Button btnAddPart;
        private System.Windows.Forms.Button btnEditPart;
        private System.Windows.Forms.Button btnDeletePart;
        private System.Windows.Forms.TabControl tabControlInvoice;
        private System.Windows.Forms.DataGrid dGridInfoPart;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        private DataTable dataTable;
        private System.Windows.Forms.TabPage tabPageLocation;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGrid dGridShipTo;
        private System.Windows.Forms.GroupBox gBoxShipLoc;
        private NujitCustomWinControls.NumericTextBox ntbIH_Refunded;
        private System.Windows.Forms.Label lIH_Refunded;
        private NujitCustomWinControls.NumericTextBox ntbIH_Returned;
        private System.Windows.Forms.Label lIH_Returned;
        private NujitCustomWinControls.NumericTextBox ntbIH_Paid;
        private System.Windows.Forms.Label lIH_Paid;
        private NujitCustomWinControls.NumericTextBox ntbIH_ExchangeRate;
        private System.Windows.Forms.Label lIH_ExchangeRate;
        private System.Windows.Forms.GroupBox gBoxTaxes;
        private NujitCustomWinControls.NumericTextBox ntbIH_Tax3Total;
        private System.Windows.Forms.Label lIHTax3Total;
        private NujitCustomWinControls.NumericTextBox ntbIH_Tax2Total;
        private System.Windows.Forms.Label lIHTaxt2Total;
        private NujitCustomWinControls.NumericTextBox ntbIH_Tax1Total;
        private System.Windows.Forms.Label lIHTax1Total;
        private System.Windows.Forms.DataGrid dGridTaxes;
        private NujitCustomWinControls.NumericTextBox ntbIH_TaxTotal;
        private System.Windows.Forms.Label lIH_TaxTotal;
        private NujitCustomWinControls.NumericTextBox ntbIH_ARYear;
        private NujitCustomWinControls.NumericTextBox ntbIH_ARPeriod;
        private System.Windows.Forms.Label lIHARYear;
        private System.Windows.Forms.Label lIH_ARPeriod;
        private System.Windows.Forms.Label lIhInvDate;
        private System.Windows.Forms.DateTimePicker dtpIH_InvDate;
        private System.Windows.Forms.Label lIHInvoiceTotal;
        private System.Windows.Forms.Label lIvCredit;
        private System.Windows.Forms.ComboBox cBoxIHInvCredit;
        private NujitCustomWinControls.NumericTextBox numericTextBox1;
        private System.Windows.Forms.Label lIHCurrency;
        private System.Windows.Forms.TextBox tBoxIH_Currency;
        private System.Windows.Forms.Label lIHBillToName;
        private System.Windows.Forms.Button btnSchBillTo;
        private System.Windows.Forms.Label lIHBillToCust;
        private System.Windows.Forms.TextBox tBoxIH_BillToName;
        private System.Windows.Forms.TextBox tBoxIH_BillToCust;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGrid dGridSalesCode;
        private System.Windows.Forms.TabPage tabPagePayment;
        private System.Windows.Forms.TabPage tabPageSalesCode;
        private System.Windows.Forms.Label lIHDealerSalesRep;
        private System.Windows.Forms.TextBox tBoxIH_DealerSalesRep;
        private System.Windows.Forms.Label lIHDealer;
        private System.Windows.Forms.TextBox tBoxIH_Dealer;
        private System.Windows.Forms.GroupBox gBoxComm;
        private System.Windows.Forms.TextBox tBoxIH_SalesPer;
        private System.Windows.Forms.TextBox tBoxSalesPesonName;
        private System.Windows.Forms.Button btnSchSalesPerson;
        private System.Windows.Forms.Label lIHSalesPer;
        private System.Windows.Forms.DataGrid dGridComm;
        private System.Windows.Forms.Label lIHBaseCurrency;
        private System.Windows.Forms.TextBox tBoxIH_BaseCurrency;
        private System.Windows.Forms.TabPage tabPageTaxes;
        private System.Windows.Forms.TabPage tabPageDiscounts;
        private System.Windows.Forms.Label lIHDiscountTot;
        private NujitCustomWinControls.NumericTextBox ntbIH_DiscountTot;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGrid dGridDiscounts;
        private System.Windows.Forms.TabPage tabPageFreigth;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox12;
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
        private System.Windows.Forms.TabPage tabPageAccounting;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGrid dGridPRC;
        private System.Windows.Forms.TabPage tabPageChaRetCom;
        private System.Windows.Forms.TabPage tabPageContact;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gBoxXhargesCalculated;
        private System.Windows.Forms.RadioButton rbtnIH_ChargesCalculatedNo;
        private System.Windows.Forms.RadioButton rbtnIH_ChargesCalculatedYes;
        private System.Windows.Forms.GroupBox gBoxPosted;
        private System.Windows.Forms.RadioButton rbtnIH_PostedNo;
        private System.Windows.Forms.RadioButton rbtnIH_PostedYes;
        private System.Windows.Forms.GroupBox gboxInfo;
        private System.Windows.Forms.DateTimePicker dtpIHDateUpdated;
        private System.Windows.Forms.Label lIHDateUpdated;
        private System.Windows.Forms.DateTimePicker dtpIHDateCreated;
        private System.Windows.Forms.Label lIHDateCreated;
        private System.Windows.Forms.TextBox tBoxIH_UserId;
        private System.Windows.Forms.Label lIHUserId;
        private NujitCustomWinControls.NumericTextBox ntbIH_OrderNumber;
        private System.Windows.Forms.Label lIHOrderNum;
        private System.Windows.Forms.Label lIHQuoteNum;
        private System.Windows.Forms.TextBox tBoxIH_QuoteNum;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tBocIHShipToAdr1;
        private System.Windows.Forms.TextBox tBoxIH_ShipToAdr2;
        private System.Windows.Forms.Label lIHShipToAdr1;
        private System.Windows.Forms.TextBox tBoxIH_ShipToCust;
        private System.Windows.Forms.Button btnSchCust;
        private System.Windows.Forms.Label lIHShipToName;
        private System.Windows.Forms.TextBox tBoxIHShipToName;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label lCustCity;
        private System.Windows.Forms.TextBox tBoxIH_ShipToAdr3;
        private System.Windows.Forms.Label lIHShipToAdr3;
        private System.Windows.Forms.Label lIHShipToAdr2;
        private System.Windows.Forms.Label lCustCountry;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label lCustRegion;
        private System.Windows.Forms.Label lIHShipToCust;
        private System.Windows.Forms.CheckBox cBoxIH_Emailed;
        private System.Windows.Forms.CheckBox cBoxIH_Printed;
        private System.Windows.Forms.CheckBox cBoxIH_Faxed;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Label label29;
        private NujitCustomWinControls.NumericTextBox numericTextBox8;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.Label label35;
        private NujitCustomWinControls.NumericTextBox numericTextBox9;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label36;
        private NujitCustomWinControls.NumericTextBox numericTextBox10;
        private NujitCustomWinControls.NumericTextBox numericTextBox11;
        private System.Windows.Forms.Label label37;
        private NujitCustomWinControls.NumericTextBox numericTextBox12;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private NujitCustomWinControls.NumericTextBox numericTextBox13;
        private NujitCustomWinControls.NumericTextBox numericTextBox14;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.DataGrid dGridPayments;
        private System.Windows.Forms.GroupBox gBoxPayment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBoxIH_PaymentsMethod;
        private System.Windows.Forms.TextBox tBoxPayTypeDesc;
        private System.Windows.Forms.Label lIHPayTerms;
        private System.Windows.Forms.TextBox tBoxIH_PayTerms;
        private System.Windows.Forms.Label lIHPayType;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnSchPayType;
        private NujitCustomWinControls.NumericTextBox ntbIH_BalanceReturn;
        private System.Windows.Forms.Label lIH_BalanceReturn;
        private NujitCustomWinControls.NumericTextBox ntbIH_Balance;
        private System.Windows.Forms.Label lIH_Balance;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DateTimePicker dtpIH_ShipDate;
        private System.Windows.Forms.Label lIHFobPoint;
        private System.Windows.Forms.TextBox tBoxIh_FobPoint;
        private System.Windows.Forms.Label lShipToVia;
        private System.Windows.Forms.TextBox tBoxIH_ShipToVia;
        private System.Windows.Forms.Label lIHShipDate;
        private System.Windows.Forms.TextBox tBoxIH_PackSlipNum;
        private System.Windows.Forms.Label lIHBolNumber;
        private NujitCustomWinControls.NumericTextBox ntbIH_BolNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.Label label42;
        private NujitCustomWinControls.NumericTextBox numericTextBox15;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label41;
        private NujitCustomWinControls.NumericTextBox numericTextBox16;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.TextBox textBox25;
        private System.Windows.Forms.Label label44;
        private NujitCustomWinControls.NumericTextBox numericTextBox17;
        private System.Windows.Forms.Label label49;
        private NujitCustomWinControls.NumericTextBox numericTextBox19;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox textBox27;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox textBox28;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox textBox29;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox30;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.TextBox textBox31;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label lIH_Warehouse;
        private System.Windows.Forms.TextBox tBoxIH_WareHouse;
        private System.Windows.Forms.DataGrid dgridContact;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Button btnSchSFContact;
        private System.Windows.Forms.Label lPSFContact;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnShipFrom;
        private System.Windows.Forms.Button buttonAddDiscGroup;
        private System.Windows.Forms.Button buttonAddDiscount;
        private System.Windows.Forms.Button buttonRemoveItem;
        private System.Windows.Forms.Button buttonEditItem;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.TextBox textBox53;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.TextBox textBox54;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.TextBox textBox55;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.TextBox textBox48;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.TextBox textBox49;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.TextBox textBox50;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.TextBox textBox51;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.TextBox textBox47;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.TextBox textBox46;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.TextBox textBox45;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.TextBox textBox44;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox textBox43;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.TextBox textBox52;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.TextBox textBox56;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox15;
        private NujitCustomWinControls.NumericTextBox ntbID_ComPercent;
        private NujitCustomWinControls.NumericTextBox ntbID_CommRate;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label lIdCommPercent;
        private System.Windows.Forms.TextBox tBoxId_CommPlan;
        private System.Windows.Forms.Label lIdCommPlan;
        private System.Windows.Forms.Button btnSchSalesPer;
        private System.Windows.Forms.TextBox tBoxID_SalesPerson;
        private System.Windows.Forms.Label lIDSalesPerson;
        private System.Windows.Forms.GroupBox gBoxCost;
        private NujitCustomWinControls.NumericTextBox numericTextBox18;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label81;
        private NujitCustomWinControls.NumericTextBox numericTextBox20;
        private System.Windows.Forms.Label label82;
        private NujitCustomWinControls.NumericTextBox numericTextBox21;
        private System.Windows.Forms.Label label83;
        private NujitCustomWinControls.NumericTextBox numericTextBox22;
        private System.Windows.Forms.Label label84;
        private NujitCustomWinControls.NumericTextBox numericTextBox23;
        private System.Windows.Forms.Label label85;
        private NujitCustomWinControls.NumericTextBox numericTextBox24;
        private System.Windows.Forms.Label label86;
        private NujitCustomWinControls.NumericTextBox numericTextBox25;
        private System.Windows.Forms.Label label87;
        private NujitCustomWinControls.NumericTextBox numericTextBox26;
        private System.Windows.Forms.Label label88;
        private NujitCustomWinControls.NumericTextBox numericTextBox27;
        private System.Windows.Forms.Label label89;
        private NujitCustomWinControls.NumericTextBox numericTextBox28;
        private System.Windows.Forms.Label label90;
        private NujitCustomWinControls.NumericTextBox numericTextBox29;
        private System.Windows.Forms.Label label91;
        private NujitCustomWinControls.NumericTextBox numericTextBox30;
        private System.Windows.Forms.Label label92;
        private NujitCustomWinControls.NumericTextBox numericTextBox31;
        private System.Windows.Forms.Label label93;
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
        private System.Windows.Forms.GroupBox groupBox16;
        private NujitCustomWinControls.NumericTextBox numericTextBox32;
        private System.Windows.Forms.Label label94;
        private NujitCustomWinControls.NumericTextBox ntbID_RoyCharges;
        private NujitCustomWinControls.NumericTextBox ntbId_FreigthAmt;
        private System.Windows.Forms.Label lIDRoyCharges;
        private System.Windows.Forms.Label lIdFreightAmt;
        private NujitCustomWinControls.NumericTextBox numericTextBox33;
        private NujitCustomWinControls.NumericTextBox numericTextBox34;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.GroupBox groupBox17;
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
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.Windows.Forms.CheckBox checkBox16;
        private System.Windows.Forms.CheckBox checkBox17;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.CheckBox checkBox18;
        private System.Windows.Forms.CheckBox checkBox19;
        private System.Windows.Forms.CheckBox checkBox20;
        private System.Windows.Forms.CheckBox checkBox21;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.CheckBox checkBox22;
        private System.Windows.Forms.CheckBox checkBox23;
        private System.Windows.Forms.CheckBox checkBox24;
        private System.Windows.Forms.CheckBox checkBox25;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TextBox textBox32;
        private CultureLocal culture = new CultureLocal(Culture.getCulture());
        private System.Windows.Forms.TextBox tBoxContactPhoneST;
        private System.Windows.Forms.Button btnSchBTContact;
        private System.Windows.Forms.TextBox tBoxContactNameST;
        private System.Windows.Forms.TextBox tBoxContactPhoneBT;
        private System.Windows.Forms.TextBox tBoxContactNameBT;
        private System.Windows.Forms.DataGrid dGridAccFrDis;
        private System.Windows.Forms.GroupBox gBoxAccounting;
        private System.Windows.Forms.TreeView treeViewInfo;
        private System.Windows.Forms.DataGrid dGridShowDetail;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private NujitCustomWinControls.NumericTextBox numericTextBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private NujitCustomWinControls.NumericTextBox numericTextBox4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;
        private NujitCustomWinControls.NumericTextBox numericTextBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private NujitCustomWinControls.NumericTextBox numericTextBox2;
        private System.Windows.Forms.Label label8;
        private NujitCustomWinControls.NumericTextBox numericTextBox35;
        private System.Windows.Forms.Label label59;
        private NujitCustomWinControls.NumericTextBox numericTextBox36;
        private System.Windows.Forms.Label label60;
        private NujitCustomWinControls.NumericTextBox numericTextBox37;
        private System.Windows.Forms.Label label61;
        private NujitCustomWinControls.NumericTextBox numericTextBox38;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label63;
        private NujitCustomWinControls.NumericTextBox numericTextBox39;
        private System.Windows.Forms.TextBox textBox33;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label lIHFreigthTerms;
        private System.Windows.Forms.TextBox tBoxIH_FreigthTerms;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.TextBox textBox34;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.TextBox textBox35;
        private System.Windows.Forms.DateTimePicker dateTimePicker5;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.DateTimePicker dateTimePicker6;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.DateTimePicker dateTimePicker7;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.Button button6;
        private CoreFactory coreFactory;
        private string rootLevel = "ROOT";
        private string layer1 = "LAYER1";
        private string layer2 = "LAYER2";
        private string layer3 = "LAYER3";
        private string layer4 = "LAYER4";
		public InvoiceHdrForm()	{
		
			InitializeComponent();
			setFormatDates();
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.gBoxKeyData = new System.Windows.Forms.GroupBox();
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
            this.numericTextBox8 = new NujitCustomWinControls.NumericTextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lIhInvDate = new System.Windows.Forms.Label();
            this.lIHCurrency = new System.Windows.Forms.Label();
            this.tBoxIH_Currency = new System.Windows.Forms.TextBox();
            this.dtpIH_InvDate = new System.Windows.Forms.DateTimePicker();
            this.lIHInvoiceTotal = new System.Windows.Forms.Label();
            this.lIvCredit = new System.Windows.Forms.Label();
            this.cBoxIHInvCredit = new System.Windows.Forms.ComboBox();
            this.numericTextBox1 = new NujitCustomWinControls.NumericTextBox();
            this.ntboxIHInvoiceNum = new NujitCustomWinControls.NumericTextBox();
            this.ntboxIHCompany = new NujitCustomWinControls.NumericTextBox();
            this.tBoxIHPlant = new System.Windows.Forms.TextBox();
            this.tBoxIHDataBase = new System.Windows.Forms.TextBox();
            this.lIHInvoiceNum = new System.Windows.Forms.Label();
            this.lIHPlant = new System.Windows.Forms.Label();
            this.lIHCompany = new System.Windows.Forms.Label();
            this.lIHDb = new System.Windows.Forms.Label();
            this.lIHInvType = new System.Windows.Forms.Label();
            this.tBoxIH_InvType = new System.Windows.Forms.TextBox();
            this.ntbIH_ARYear = new NujitCustomWinControls.NumericTextBox();
            this.ntbIH_ARPeriod = new NujitCustomWinControls.NumericTextBox();
            this.lIHARYear = new System.Windows.Forms.Label();
            this.lIH_ARPeriod = new System.Windows.Forms.Label();
            this.ntbIH_BatchNum = new NujitCustomWinControls.NumericTextBox();
            this.lIHBatchNum = new System.Windows.Forms.Label();
            this.gBoxBtns = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tabControlInvoice = new System.Windows.Forms.TabControl();
            this.tabPageHeader = new System.Windows.Forms.TabPage();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.btnShipFrom = new System.Windows.Forms.Button();
            this.lIHOrderDate = new System.Windows.Forms.Label();
            this.dtpIH_OrderDate = new System.Windows.Forms.DateTimePicker();
            this.lIHPoNum = new System.Windows.Forms.Label();
            this.tBoxIH_PONum = new System.Windows.Forms.TextBox();
            this.lIHPODate = new System.Windows.Forms.Label();
            this.dtpIH_PODate = new System.Windows.Forms.DateTimePicker();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label56 = new System.Windows.Forms.Label();
            this.tBoxContactPhoneST = new System.Windows.Forms.TextBox();
            this.tBoxContactNameST = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tBocIHShipToAdr1 = new System.Windows.Forms.TextBox();
            this.tBoxIH_ShipToAdr2 = new System.Windows.Forms.TextBox();
            this.lIHShipToAdr1 = new System.Windows.Forms.Label();
            this.tBoxIH_ShipToCust = new System.Windows.Forms.TextBox();
            this.btnSchCust = new System.Windows.Forms.Button();
            this.lIHShipToName = new System.Windows.Forms.Label();
            this.tBoxIHShipToName = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.lCustCity = new System.Windows.Forms.Label();
            this.tBoxIH_ShipToAdr3 = new System.Windows.Forms.TextBox();
            this.lIHShipToAdr3 = new System.Windows.Forms.Label();
            this.lIHShipToAdr2 = new System.Windows.Forms.Label();
            this.lCustCountry = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.lCustRegion = new System.Windows.Forms.Label();
            this.lIHShipToCust = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.btnSchSFContact = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label55 = new System.Windows.Forms.Label();
            this.tBoxContactPhoneBT = new System.Windows.Forms.TextBox();
            this.tBoxContactNameBT = new System.Windows.Forms.TextBox();
            this.lPSFContact = new System.Windows.Forms.Label();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
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
            this.lIHBillToName = new System.Windows.Forms.Label();
            this.btnSchBillTo = new System.Windows.Forms.Button();
            this.lIHBillToCust = new System.Windows.Forms.Label();
            this.tBoxIH_BillToName = new System.Windows.Forms.TextBox();
            this.tBoxIH_BillToCust = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnSchBTContact = new System.Windows.Forms.Button();
            this.tabPageFreigth = new System.Windows.Forms.TabPage();
            this.gBoxAccounting = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker6 = new System.Windows.Forms.DateTimePicker();
            this.label100 = new System.Windows.Forms.Label();
            this.dateTimePicker7 = new System.Windows.Forms.DateTimePicker();
            this.label101 = new System.Windows.Forms.Label();
            this.dateTimePicker5 = new System.Windows.Forms.DateTimePicker();
            this.label99 = new System.Windows.Forms.Label();
            this.textBox35 = new System.Windows.Forms.TextBox();
            this.label98 = new System.Windows.Forms.Label();
            this.tBoxIH_FreigthTerms = new System.Windows.Forms.TextBox();
            this.label97 = new System.Windows.Forms.Label();
            this.textBox34 = new System.Windows.Forms.TextBox();
            this.lIHFreigthTerms = new System.Windows.Forms.Label();
            this.textBox33 = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.numericTextBox39 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox38 = new NujitCustomWinControls.NumericTextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.numericTextBox37 = new NujitCustomWinControls.NumericTextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.numericTextBox36 = new NujitCustomWinControls.NumericTextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.numericTextBox35 = new NujitCustomWinControls.NumericTextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.numericTextBox6 = new NujitCustomWinControls.NumericTextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.numericTextBox4 = new NujitCustomWinControls.NumericTextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numericTextBox3 = new NujitCustomWinControls.NumericTextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericTextBox2 = new NujitCustomWinControls.NumericTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dGridShowDetail = new System.Windows.Forms.DataGrid();
            this.treeViewInfo = new System.Windows.Forms.TreeView();
            this.button6 = new System.Windows.Forms.Button();
            this.tabPageAccounting = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.ntbID_ComPercent = new NujitCustomWinControls.NumericTextBox();
            this.ntbID_CommRate = new NujitCustomWinControls.NumericTextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.lIdCommPercent = new System.Windows.Forms.Label();
            this.tBoxId_CommPlan = new System.Windows.Forms.TextBox();
            this.lIdCommPlan = new System.Windows.Forms.Label();
            this.btnSchSalesPer = new System.Windows.Forms.Button();
            this.tBoxID_SalesPerson = new System.Windows.Forms.TextBox();
            this.lIDSalesPerson = new System.Windows.Forms.Label();
            this.gBoxCost = new System.Windows.Forms.GroupBox();
            this.numericTextBox18 = new NujitCustomWinControls.NumericTextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.numericTextBox20 = new NujitCustomWinControls.NumericTextBox();
            this.label82 = new System.Windows.Forms.Label();
            this.numericTextBox21 = new NujitCustomWinControls.NumericTextBox();
            this.label83 = new System.Windows.Forms.Label();
            this.numericTextBox22 = new NujitCustomWinControls.NumericTextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.numericTextBox23 = new NujitCustomWinControls.NumericTextBox();
            this.label85 = new System.Windows.Forms.Label();
            this.numericTextBox24 = new NujitCustomWinControls.NumericTextBox();
            this.label86 = new System.Windows.Forms.Label();
            this.numericTextBox25 = new NujitCustomWinControls.NumericTextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.numericTextBox26 = new NujitCustomWinControls.NumericTextBox();
            this.label88 = new System.Windows.Forms.Label();
            this.numericTextBox27 = new NujitCustomWinControls.NumericTextBox();
            this.label89 = new System.Windows.Forms.Label();
            this.numericTextBox28 = new NujitCustomWinControls.NumericTextBox();
            this.label90 = new System.Windows.Forms.Label();
            this.numericTextBox29 = new NujitCustomWinControls.NumericTextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.numericTextBox30 = new NujitCustomWinControls.NumericTextBox();
            this.label92 = new System.Windows.Forms.Label();
            this.numericTextBox31 = new NujitCustomWinControls.NumericTextBox();
            this.label93 = new System.Windows.Forms.Label();
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
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.numericTextBox32 = new NujitCustomWinControls.NumericTextBox();
            this.label94 = new System.Windows.Forms.Label();
            this.ntbID_RoyCharges = new NujitCustomWinControls.NumericTextBox();
            this.ntbId_FreigthAmt = new NujitCustomWinControls.NumericTextBox();
            this.lIDRoyCharges = new System.Windows.Forms.Label();
            this.lIdFreightAmt = new System.Windows.Forms.Label();
            this.numericTextBox33 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox34 = new NujitCustomWinControls.NumericTextBox();
            this.label95 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
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
            this.tabPagePart = new System.Windows.Forms.TabPage();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.textBox56 = new System.Windows.Forms.TextBox();
            this.label75 = new System.Windows.Forms.Label();
            this.textBox52 = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.textBox43 = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddPart = new System.Windows.Forms.Button();
            this.btnDeletePart = new System.Windows.Forms.Button();
            this.btnEditPart = new System.Windows.Forms.Button();
            this.dGridInfoPart = new System.Windows.Forms.DataGrid();
            this.tabPageContact = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
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
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.cBoxIH_Emailed = new System.Windows.Forms.CheckBox();
            this.cBoxIH_Faxed = new System.Windows.Forms.CheckBox();
            this.cBoxIH_Printed = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dgridContact = new System.Windows.Forms.DataGrid();
            this.tabPageLocation = new System.Windows.Forms.TabPage();
            this.gBoxShipLoc = new System.Windows.Forms.GroupBox();
            this.btnDetails = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label41 = new System.Windows.Forms.Label();
            this.numericTextBox16 = new NujitCustomWinControls.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.numericTextBox15 = new NujitCustomWinControls.NumericTextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.dGridShipTo = new System.Windows.Forms.DataGrid();
            this.tabPageSalesCode = new System.Windows.Forms.TabPage();
            this.gBoxComm = new System.Windows.Forms.GroupBox();
            this.tBoxIH_SalesPer = new System.Windows.Forms.TextBox();
            this.tBoxSalesPesonName = new System.Windows.Forms.TextBox();
            this.btnSchSalesPerson = new System.Windows.Forms.Button();
            this.lIHSalesPer = new System.Windows.Forms.Label();
            this.dGridComm = new System.Windows.Forms.DataGrid();
            this.lIHDealerSalesRep = new System.Windows.Forms.Label();
            this.tBoxIH_DealerSalesRep = new System.Windows.Forms.TextBox();
            this.lIHDealer = new System.Windows.Forms.Label();
            this.tBoxIH_Dealer = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dGridSalesCode = new System.Windows.Forms.DataGrid();
            this.tabPageDiscounts = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonAddDiscGroup = new System.Windows.Forms.Button();
            this.buttonAddDiscount = new System.Windows.Forms.Button();
            this.buttonRemoveItem = new System.Windows.Forms.Button();
            this.buttonEditItem = new System.Windows.Forms.Button();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.numericTextBox17 = new NujitCustomWinControls.NumericTextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.numericTextBox19 = new NujitCustomWinControls.NumericTextBox();
            this.lIHDiscountTot = new System.Windows.Forms.Label();
            this.ntbIH_DiscountTot = new NujitCustomWinControls.NumericTextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.dGridDiscounts = new System.Windows.Forms.DataGrid();
            this.tabPageChaRetCom = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dGridPRC = new System.Windows.Forms.DataGrid();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dGridAccFrDis = new System.Windows.Forms.DataGrid();
            this.lIH_Warehouse = new System.Windows.Forms.Label();
            this.tBoxIH_WareHouse = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dtpIH_ShipDate = new System.Windows.Forms.DateTimePicker();
            this.lIHFobPoint = new System.Windows.Forms.Label();
            this.tBoxIh_FobPoint = new System.Windows.Forms.TextBox();
            this.lShipToVia = new System.Windows.Forms.Label();
            this.tBoxIH_ShipToVia = new System.Windows.Forms.TextBox();
            this.lIHShipDate = new System.Windows.Forms.Label();
            this.tBoxIH_PackSlipNum = new System.Windows.Forms.TextBox();
            this.lIHBolNumber = new System.Windows.Forms.Label();
            this.ntbIH_BolNumber = new NujitCustomWinControls.NumericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gBoxPayment = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBoxIH_PaymentsMethod = new System.Windows.Forms.TextBox();
            this.tBoxPayTypeDesc = new System.Windows.Forms.TextBox();
            this.lIHPayTerms = new System.Windows.Forms.Label();
            this.tBoxIH_PayTerms = new System.Windows.Forms.TextBox();
            this.lIHPayType = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnSchPayType = new System.Windows.Forms.Button();
            this.ntbIH_BalanceReturn = new NujitCustomWinControls.NumericTextBox();
            this.lIH_BalanceReturn = new System.Windows.Forms.Label();
            this.ntbIH_Balance = new NujitCustomWinControls.NumericTextBox();
            this.lIH_Balance = new System.Windows.Forms.Label();
            this.ntbIH_OrderNumber = new NujitCustomWinControls.NumericTextBox();
            this.lIHOrderNum = new System.Windows.Forms.Label();
            this.lIHQuoteNum = new System.Windows.Forms.Label();
            this.tBoxIH_QuoteNum = new System.Windows.Forms.TextBox();
            this.gboxInfo = new System.Windows.Forms.GroupBox();
            this.dtpIHDateUpdated = new System.Windows.Forms.DateTimePicker();
            this.lIHDateUpdated = new System.Windows.Forms.Label();
            this.dtpIHDateCreated = new System.Windows.Forms.DateTimePicker();
            this.lIHDateCreated = new System.Windows.Forms.Label();
            this.tBoxIH_UserId = new System.Windows.Forms.TextBox();
            this.lIHUserId = new System.Windows.Forms.Label();
            this.gBoxXhargesCalculated = new System.Windows.Forms.GroupBox();
            this.rbtnIH_ChargesCalculatedNo = new System.Windows.Forms.RadioButton();
            this.rbtnIH_ChargesCalculatedYes = new System.Windows.Forms.RadioButton();
            this.gBoxPosted = new System.Windows.Forms.GroupBox();
            this.rbtnIH_PostedNo = new System.Windows.Forms.RadioButton();
            this.rbtnIH_PostedYes = new System.Windows.Forms.RadioButton();
            this.tabPagePayment = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label58 = new System.Windows.Forms.Label();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.dGridPayments = new System.Windows.Forms.DataGrid();
            this.numericTextBox14 = new NujitCustomWinControls.NumericTextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.numericTextBox12 = new NujitCustomWinControls.NumericTextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.numericTextBox13 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox9 = new NujitCustomWinControls.NumericTextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.ntbIH_ExchangeRate = new NujitCustomWinControls.NumericTextBox();
            this.lIH_ExchangeRate = new System.Windows.Forms.Label();
            this.lIHBaseCurrency = new System.Windows.Forms.Label();
            this.tBoxIH_BaseCurrency = new System.Windows.Forms.TextBox();
            this.lIH_Paid = new System.Windows.Forms.Label();
            this.ntbIH_Refunded = new NujitCustomWinControls.NumericTextBox();
            this.lIH_Refunded = new System.Windows.Forms.Label();
            this.ntbIH_Returned = new NujitCustomWinControls.NumericTextBox();
            this.lIH_Returned = new System.Windows.Forms.Label();
            this.ntbIH_Paid = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox10 = new NujitCustomWinControls.NumericTextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.numericTextBox11 = new NujitCustomWinControls.NumericTextBox();
            this.tabPageTaxes = new System.Windows.Forms.TabPage();
            this.gBoxTaxes = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.lIH_TaxTotal = new System.Windows.Forms.Label();
            this.ntbIH_Tax1Total = new NujitCustomWinControls.NumericTextBox();
            this.lIHTax1Total = new System.Windows.Forms.Label();
            this.ntbIH_Tax2Total = new NujitCustomWinControls.NumericTextBox();
            this.lIHTaxt2Total = new System.Windows.Forms.Label();
            this.ntbIH_Tax3Total = new NujitCustomWinControls.NumericTextBox();
            this.lIHTax3Total = new System.Windows.Forms.Label();
            this.ntbIH_TaxTotal = new NujitCustomWinControls.NumericTextBox();
            this.dGridTaxes = new System.Windows.Forms.DataGrid();
            this.gBoxKeyData.SuspendLayout();
            this.gBoxBtns.SuspendLayout();
            this.tabControlInvoice.SuspendLayout();
            this.tabPageHeader.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPageFreigth.SuspendLayout();
            this.gBoxAccounting.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGridShowDetail)).BeginInit();
            this.tabPageAccounting.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.gBoxCost.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.gBoxTax.SuspendLayout();
            this.tabPagePart.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridInfoPart)).BeginInit();
            this.tabPageContact.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridContact)).BeginInit();
            this.tabPageLocation.SuspendLayout();
            this.gBoxShipLoc.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridShipTo)).BeginInit();
            this.tabPageSalesCode.SuspendLayout();
            this.gBoxComm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridComm)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridSalesCode)).BeginInit();
            this.tabPageDiscounts.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridDiscounts)).BeginInit();
            this.tabPageChaRetCom.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridPRC)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridAccFrDis)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.gBoxPayment.SuspendLayout();
            this.gboxInfo.SuspendLayout();
            this.gBoxXhargesCalculated.SuspendLayout();
            this.gBoxPosted.SuspendLayout();
            this.tabPagePayment.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridPayments)).BeginInit();
            this.tabPageTaxes.SuspendLayout();
            this.gBoxTaxes.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridTaxes)).BeginInit();
            this.SuspendLayout();
            // 
            // gBoxKeyData
            // 
            this.gBoxKeyData.Controls.Add(this.label34);
            this.gBoxKeyData.Controls.Add(this.textBox20);
            this.gBoxKeyData.Controls.Add(this.label33);
            this.gBoxKeyData.Controls.Add(this.dateTimePicker4);
            this.gBoxKeyData.Controls.Add(this.label32);
            this.gBoxKeyData.Controls.Add(this.dateTimePicker3);
            this.gBoxKeyData.Controls.Add(this.label31);
            this.gBoxKeyData.Controls.Add(this.textBox19);
            this.gBoxKeyData.Controls.Add(this.label30);
            this.gBoxKeyData.Controls.Add(this.dateTimePicker2);
            this.gBoxKeyData.Controls.Add(this.label29);
            this.gBoxKeyData.Controls.Add(this.numericTextBox8);
            this.gBoxKeyData.Controls.Add(this.label28);
            this.gBoxKeyData.Controls.Add(this.textBox18);
            this.gBoxKeyData.Controls.Add(this.label27);
            this.gBoxKeyData.Controls.Add(this.textBox2);
            this.gBoxKeyData.Controls.Add(this.lIhInvDate);
            this.gBoxKeyData.Controls.Add(this.lIHCurrency);
            this.gBoxKeyData.Controls.Add(this.tBoxIH_Currency);
            this.gBoxKeyData.Controls.Add(this.dtpIH_InvDate);
            this.gBoxKeyData.Controls.Add(this.lIHInvoiceTotal);
            this.gBoxKeyData.Controls.Add(this.lIvCredit);
            this.gBoxKeyData.Controls.Add(this.cBoxIHInvCredit);
            this.gBoxKeyData.Controls.Add(this.numericTextBox1);
            this.gBoxKeyData.Controls.Add(this.ntboxIHInvoiceNum);
            this.gBoxKeyData.Controls.Add(this.ntboxIHCompany);
            this.gBoxKeyData.Controls.Add(this.tBoxIHPlant);
            this.gBoxKeyData.Controls.Add(this.tBoxIHDataBase);
            this.gBoxKeyData.Controls.Add(this.lIHInvoiceNum);
            this.gBoxKeyData.Controls.Add(this.lIHPlant);
            this.gBoxKeyData.Controls.Add(this.lIHCompany);
            this.gBoxKeyData.Controls.Add(this.lIHDb);
            this.gBoxKeyData.Controls.Add(this.lIHInvType);
            this.gBoxKeyData.Controls.Add(this.tBoxIH_InvType);
            this.gBoxKeyData.Controls.Add(this.ntbIH_ARYear);
            this.gBoxKeyData.Controls.Add(this.ntbIH_ARPeriod);
            this.gBoxKeyData.Controls.Add(this.lIHARYear);
            this.gBoxKeyData.Controls.Add(this.lIH_ARPeriod);
            this.gBoxKeyData.Controls.Add(this.ntbIH_BatchNum);
            this.gBoxKeyData.Controls.Add(this.lIHBatchNum);
            this.gBoxKeyData.Location = new System.Drawing.Point(8, 0);
            this.gBoxKeyData.Name = "gBoxKeyData";
            this.gBoxKeyData.Size = new System.Drawing.Size(808, 128);
            this.gBoxKeyData.TabIndex = 1;
            this.gBoxKeyData.TabStop = false;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(344, 96);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(80, 20);
            this.label34.TabIndex = 73;
            this.label34.Text = "Invoice Status";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(424, 96);
            this.textBox20.MaxLength = 10;
            this.textBox20.Name = "textBox20";
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
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(600, 56);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(88, 20);
            this.dateTimePicker3.TabIndex = 69;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(160, 56);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(88, 20);
            this.label31.TabIndex = 64;
            this.label31.Text = "Invoice Balance";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(248, 56);
            this.textBox19.MaxLength = 10;
            this.textBox19.Name = "textBox19";
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
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(600, 36);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(88, 20);
            this.dateTimePicker2.TabIndex = 62;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(344, 36);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(64, 20);
            this.label29.TabIndex = 60;
            this.label29.Text = "Total Lines";
            // 
            // numericTextBox8
            // 
            this.numericTextBox8.Location = new System.Drawing.Point(424, 36);
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
            this.numericTextBox8.Size = new System.Drawing.Size(72, 20);
            this.numericTextBox8.TabIndex = 61;
            this.numericTextBox8.Value = new System.Decimal(new int[] {
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
            this.label27.Location = new System.Drawing.Point(344, 16);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(64, 20);
            this.label27.TabIndex = 56;
            this.label27.Text = "Customer #";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(424, 16);
            this.textBox2.MaxLength = 20;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(72, 20);
            this.textBox2.TabIndex = 55;
            this.textBox2.Text = "";
            // 
            // lIhInvDate
            // 
            this.lIhInvDate.Location = new System.Drawing.Point(160, 16);
            this.lIhInvDate.Name = "lIhInvDate";
            this.lIhInvDate.Size = new System.Drawing.Size(72, 20);
            this.lIhInvDate.TabIndex = 41;
            this.lIhInvDate.Text = "Invoice Date";
            // 
            // lIHCurrency
            // 
            this.lIHCurrency.Location = new System.Drawing.Point(8, 36);
            this.lIHCurrency.Name = "lIHCurrency";
            this.lIHCurrency.Size = new System.Drawing.Size(56, 20);
            this.lIHCurrency.TabIndex = 47;
            this.lIHCurrency.Text = "Currency";
            // 
            // tBoxIH_Currency
            // 
            this.tBoxIH_Currency.Location = new System.Drawing.Point(80, 36);
            this.tBoxIH_Currency.MaxLength = 5;
            this.tBoxIH_Currency.Name = "tBoxIH_Currency";
            this.tBoxIH_Currency.Size = new System.Drawing.Size(72, 20);
            this.tBoxIH_Currency.TabIndex = 46;
            this.tBoxIH_Currency.Text = "";
            // 
            // dtpIH_InvDate
            // 
            this.dtpIH_InvDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIH_InvDate.Location = new System.Drawing.Point(248, 16);
            this.dtpIH_InvDate.Name = "dtpIH_InvDate";
            this.dtpIH_InvDate.Size = new System.Drawing.Size(88, 20);
            this.dtpIH_InvDate.TabIndex = 40;
            // 
            // lIHInvoiceTotal
            // 
            this.lIHInvoiceTotal.Location = new System.Drawing.Point(160, 36);
            this.lIHInvoiceTotal.Name = "lIHInvoiceTotal";
            this.lIHInvoiceTotal.Size = new System.Drawing.Size(80, 20);
            this.lIHInvoiceTotal.TabIndex = 44;
            this.lIHInvoiceTotal.Text = "Invocie Total";
            // 
            // lIvCredit
            // 
            this.lIvCredit.Location = new System.Drawing.Point(160, 76);
            this.lIvCredit.Name = "lIvCredit";
            this.lIvCredit.Size = new System.Drawing.Size(80, 20);
            this.lIvCredit.TabIndex = 43;
            this.lIvCredit.Text = "Invoice Credit";
            // 
            // cBoxIHInvCredit
            // 
            this.cBoxIHInvCredit.Items.AddRange(new object[] {
                                                                 "1 - Invoice ",
                                                                 "2 - Credit ",
                                                                 "3 - Finance "});
            this.cBoxIHInvCredit.Location = new System.Drawing.Point(248, 76);
            this.cBoxIHInvCredit.Name = "cBoxIHInvCredit";
            this.cBoxIHInvCredit.Size = new System.Drawing.Size(88, 21);
            this.cBoxIHInvCredit.TabIndex = 42;
            this.cBoxIHInvCredit.Text = "1 - Invoice ";
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Location = new System.Drawing.Point(248, 36);
            this.numericTextBox1.Maximum = new System.Decimal(new int[] {
                                                                            -727379969,
                                                                            232,
                                                                            0,
                                                                            0});
            this.numericTextBox1.MaxPrecision = 2;
            this.numericTextBox1.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox1.TabIndex = 45;
            this.numericTextBox1.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // ntboxIHInvoiceNum
            // 
            this.ntboxIHInvoiceNum.Location = new System.Drawing.Point(80, 16);
            this.ntboxIHInvoiceNum.Maximum = new System.Decimal(new int[] {
                                                                              -1486618625,
                                                                              232830643,
                                                                              0,
                                                                              0});
            this.ntboxIHInvoiceNum.Minimum = new System.Decimal(new int[] {
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0});
            this.ntboxIHInvoiceNum.Name = "ntboxIHInvoiceNum";
            this.ntboxIHInvoiceNum.Size = new System.Drawing.Size(72, 20);
            this.ntboxIHInvoiceNum.TabIndex = 8;
            this.ntboxIHInvoiceNum.Value = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            // 
            // ntboxIHCompany
            // 
            this.ntboxIHCompany.Location = new System.Drawing.Point(80, 76);
            this.ntboxIHCompany.Maximum = new System.Decimal(new int[] {
                                                                           999,
                                                                           0,
                                                                           0,
                                                                           0});
            this.ntboxIHCompany.Minimum = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            this.ntboxIHCompany.Name = "ntboxIHCompany";
            this.ntboxIHCompany.Size = new System.Drawing.Size(72, 20);
            this.ntboxIHCompany.TabIndex = 7;
            this.ntboxIHCompany.Value = new System.Decimal(new int[] {
                                                                         0,
                                                                         0,
                                                                         0,
                                                                         0});
            // 
            // tBoxIHPlant
            // 
            this.tBoxIHPlant.Location = new System.Drawing.Point(80, 96);
            this.tBoxIHPlant.MaxLength = 10;
            this.tBoxIHPlant.Name = "tBoxIHPlant";
            this.tBoxIHPlant.Size = new System.Drawing.Size(72, 20);
            this.tBoxIHPlant.TabIndex = 6;
            this.tBoxIHPlant.Text = "";
            // 
            // tBoxIHDataBase
            // 
            this.tBoxIHDataBase.Location = new System.Drawing.Point(80, 56);
            this.tBoxIHDataBase.MaxLength = 10;
            this.tBoxIHDataBase.Name = "tBoxIHDataBase";
            this.tBoxIHDataBase.ReadOnly = true;
            this.tBoxIHDataBase.Size = new System.Drawing.Size(72, 20);
            this.tBoxIHDataBase.TabIndex = 4;
            this.tBoxIHDataBase.Text = "";
            // 
            // lIHInvoiceNum
            // 
            this.lIHInvoiceNum.Location = new System.Drawing.Point(8, 16);
            this.lIHInvoiceNum.Name = "lIHInvoiceNum";
            this.lIHInvoiceNum.Size = new System.Drawing.Size(64, 20);
            this.lIHInvoiceNum.TabIndex = 3;
            this.lIHInvoiceNum.Text = "Invoice #";
            // 
            // lIHPlant
            // 
            this.lIHPlant.Location = new System.Drawing.Point(8, 96);
            this.lIHPlant.Name = "lIHPlant";
            this.lIHPlant.Size = new System.Drawing.Size(48, 20);
            this.lIHPlant.TabIndex = 2;
            this.lIHPlant.Text = "Plant";
            // 
            // lIHCompany
            // 
            this.lIHCompany.Location = new System.Drawing.Point(8, 76);
            this.lIHCompany.Name = "lIHCompany";
            this.lIHCompany.Size = new System.Drawing.Size(64, 20);
            this.lIHCompany.TabIndex = 1;
            this.lIHCompany.Text = "Company";
            // 
            // lIHDb
            // 
            this.lIHDb.Location = new System.Drawing.Point(8, 56);
            this.lIHDb.Name = "lIHDb";
            this.lIHDb.Size = new System.Drawing.Size(64, 20);
            this.lIHDb.TabIndex = 0;
            this.lIHDb.Text = "Data Base";
            // 
            // lIHInvType
            // 
            this.lIHInvType.Location = new System.Drawing.Point(160, 96);
            this.lIHInvType.Name = "lIHInvType";
            this.lIHInvType.Size = new System.Drawing.Size(72, 20);
            this.lIHInvType.TabIndex = 18;
            this.lIHInvType.Text = "Invoice Type";
            // 
            // tBoxIH_InvType
            // 
            this.tBoxIH_InvType.Location = new System.Drawing.Point(248, 97);
            this.tBoxIH_InvType.MaxLength = 10;
            this.tBoxIH_InvType.Name = "tBoxIH_InvType";
            this.tBoxIH_InvType.Size = new System.Drawing.Size(88, 20);
            this.tBoxIH_InvType.TabIndex = 19;
            this.tBoxIH_InvType.Text = "";
            // 
            // ntbIH_ARYear
            // 
            this.ntbIH_ARYear.Location = new System.Drawing.Point(424, 56);
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
            this.ntbIH_ARPeriod.Location = new System.Drawing.Point(424, 76);
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
            this.lIHARYear.Location = new System.Drawing.Point(344, 56);
            this.lIHARYear.Name = "lIHARYear";
            this.lIHARYear.Size = new System.Drawing.Size(56, 20);
            this.lIHARYear.TabIndex = 66;
            this.lIHARYear.Text = "Fiscal YY";
            // 
            // lIH_ARPeriod
            // 
            this.lIH_ARPeriod.Location = new System.Drawing.Point(344, 76);
            this.lIH_ARPeriod.Name = "lIH_ARPeriod";
            this.lIH_ARPeriod.Size = new System.Drawing.Size(56, 20);
            this.lIH_ARPeriod.TabIndex = 65;
            this.lIH_ARPeriod.Text = "Fiscal PP";
            // 
            // ntbIH_BatchNum
            // 
            this.ntbIH_BatchNum.Location = new System.Drawing.Point(600, 96);
            this.ntbIH_BatchNum.Maximum = new System.Decimal(new int[] {
                                                                           -727379969,
                                                                           232,
                                                                           0,
                                                                           0});
            this.ntbIH_BatchNum.Minimum = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            this.ntbIH_BatchNum.Name = "ntbIH_BatchNum";
            this.ntbIH_BatchNum.Size = new System.Drawing.Size(88, 20);
            this.ntbIH_BatchNum.TabIndex = 34;
            this.ntbIH_BatchNum.Value = new System.Decimal(new int[] {
                                                                         0,
                                                                         0,
                                                                         0,
                                                                         0});
            // 
            // lIHBatchNum
            // 
            this.lIHBatchNum.Location = new System.Drawing.Point(512, 96);
            this.lIHBatchNum.Name = "lIHBatchNum";
            this.lIHBatchNum.Size = new System.Drawing.Size(56, 16);
            this.lIHBatchNum.TabIndex = 33;
            this.lIHBatchNum.Text = "Batch #";
            // 
            // gBoxBtns
            // 
            this.gBoxBtns.Controls.Add(this.btnClear);
            this.gBoxBtns.Controls.Add(this.btnAdd);
            this.gBoxBtns.Controls.Add(this.btnSave);
            this.gBoxBtns.Controls.Add(this.btnDelete);
            this.gBoxBtns.Location = new System.Drawing.Point(16, 576);
            this.gBoxBtns.Name = "gBoxBtns";
            this.gBoxBtns.Size = new System.Drawing.Size(800, 48);
            this.gBoxBtns.TabIndex = 2;
            this.gBoxBtns.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(448, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            // 
            // btnAdd
            // 
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnAdd.Location = new System.Drawing.Point(624, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(536, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(712, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete";
            // 
            // tabControlInvoice
            // 
            this.tabControlInvoice.Controls.Add(this.tabPageHeader);
            this.tabControlInvoice.Controls.Add(this.tabPageFreigth);
            this.tabControlInvoice.Controls.Add(this.tabPageAccounting);
            this.tabControlInvoice.Controls.Add(this.tabPagePart);
            this.tabControlInvoice.Controls.Add(this.tabPageContact);
            this.tabControlInvoice.Controls.Add(this.tabPageLocation);
            this.tabControlInvoice.Controls.Add(this.tabPageSalesCode);
            this.tabControlInvoice.Controls.Add(this.tabPageDiscounts);
            this.tabControlInvoice.Controls.Add(this.tabPageChaRetCom);
            this.tabControlInvoice.Controls.Add(this.tabPage1);
            this.tabControlInvoice.Controls.Add(this.tabPagePayment);
            this.tabControlInvoice.Controls.Add(this.tabPageTaxes);
            this.tabControlInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.tabControlInvoice.Location = new System.Drawing.Point(8, 136);
            this.tabControlInvoice.Name = "tabControlInvoice";
            this.tabControlInvoice.SelectedIndex = 0;
            this.tabControlInvoice.Size = new System.Drawing.Size(808, 432);
            this.tabControlInvoice.TabIndex = 3;
            this.tabControlInvoice.SelectedIndexChanged += new System.EventHandler(this.tabControlInvoice_SelectedIndexChanged);
            // 
            // tabPageHeader
            // 
            this.tabPageHeader.Controls.Add(this.groupBox14);
            this.tabPageHeader.Controls.Add(this.groupBox6);
            this.tabPageHeader.Controls.Add(this.groupBox3);
            this.tabPageHeader.Location = new System.Drawing.Point(4, 22);
            this.tabPageHeader.Name = "tabPageHeader";
            this.tabPageHeader.Size = new System.Drawing.Size(800, 406);
            this.tabPageHeader.TabIndex = 0;
            this.tabPageHeader.Text = "Shipping";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.btnShipFrom);
            this.groupBox14.Controls.Add(this.lIHOrderDate);
            this.groupBox14.Controls.Add(this.dtpIH_OrderDate);
            this.groupBox14.Controls.Add(this.lIHPoNum);
            this.groupBox14.Controls.Add(this.tBoxIH_PONum);
            this.groupBox14.Controls.Add(this.lIHPODate);
            this.groupBox14.Controls.Add(this.dtpIH_PODate);
            this.groupBox14.Location = new System.Drawing.Point(8, 16);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(784, 48);
            this.groupBox14.TabIndex = 75;
            this.groupBox14.TabStop = false;
            // 
            // btnShipFrom
            // 
            this.btnShipFrom.Location = new System.Drawing.Point(688, 16);
            this.btnShipFrom.Name = "btnShipFrom";
            this.btnShipFrom.TabIndex = 33;
            this.btnShipFrom.Text = "Ship From";
            this.btnShipFrom.Click += new System.EventHandler(this.btnShipFrom_Click);
            // 
            // lIHOrderDate
            // 
            this.lIHOrderDate.Location = new System.Drawing.Point(16, 16);
            this.lIHOrderDate.Name = "lIHOrderDate";
            this.lIHOrderDate.Size = new System.Drawing.Size(64, 16);
            this.lIHOrderDate.TabIndex = 25;
            this.lIHOrderDate.Text = "Order Date";
            // 
            // dtpIH_OrderDate
            // 
            this.dtpIH_OrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIH_OrderDate.Location = new System.Drawing.Point(88, 16);
            this.dtpIH_OrderDate.Name = "dtpIH_OrderDate";
            this.dtpIH_OrderDate.Size = new System.Drawing.Size(88, 20);
            this.dtpIH_OrderDate.TabIndex = 24;
            // 
            // lIHPoNum
            // 
            this.lIHPoNum.Location = new System.Drawing.Point(408, 16);
            this.lIHPoNum.Name = "lIHPoNum";
            this.lIHPoNum.Size = new System.Drawing.Size(40, 20);
            this.lIHPoNum.TabIndex = 32;
            this.lIHPoNum.Text = "PO #";
            // 
            // tBoxIH_PONum
            // 
            this.tBoxIH_PONum.Location = new System.Drawing.Point(456, 16);
            this.tBoxIH_PONum.MaxLength = 40;
            this.tBoxIH_PONum.Name = "tBoxIH_PONum";
            this.tBoxIH_PONum.Size = new System.Drawing.Size(192, 20);
            this.tBoxIH_PONum.TabIndex = 31;
            this.tBoxIH_PONum.Text = "";
            // 
            // lIHPODate
            // 
            this.lIHPODate.Location = new System.Drawing.Point(208, 16);
            this.lIHPODate.Name = "lIHPODate";
            this.lIHPODate.Size = new System.Drawing.Size(56, 16);
            this.lIHPODate.TabIndex = 23;
            this.lIHPODate.Text = "PO Date";
            // 
            // dtpIH_PODate
            // 
            this.dtpIH_PODate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIH_PODate.Location = new System.Drawing.Point(264, 16);
            this.dtpIH_PODate.Name = "dtpIH_PODate";
            this.dtpIH_PODate.Size = new System.Drawing.Size(88, 20);
            this.dtpIH_PODate.TabIndex = 22;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label56);
            this.groupBox6.Controls.Add(this.tBoxContactPhoneST);
            this.groupBox6.Controls.Add(this.tBoxContactNameST);
            this.groupBox6.Controls.Add(this.label57);
            this.groupBox6.Controls.Add(this.label52);
            this.groupBox6.Controls.Add(this.textBox29);
            this.groupBox6.Controls.Add(this.textBox27);
            this.groupBox6.Controls.Add(this.label50);
            this.groupBox6.Controls.Add(this.comboBox1);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.tBocIHShipToAdr1);
            this.groupBox6.Controls.Add(this.tBoxIH_ShipToAdr2);
            this.groupBox6.Controls.Add(this.lIHShipToAdr1);
            this.groupBox6.Controls.Add(this.tBoxIH_ShipToCust);
            this.groupBox6.Controls.Add(this.btnSchCust);
            this.groupBox6.Controls.Add(this.lIHShipToName);
            this.groupBox6.Controls.Add(this.tBoxIHShipToName);
            this.groupBox6.Controls.Add(this.textBox9);
            this.groupBox6.Controls.Add(this.lCustCity);
            this.groupBox6.Controls.Add(this.tBoxIH_ShipToAdr3);
            this.groupBox6.Controls.Add(this.lIHShipToAdr3);
            this.groupBox6.Controls.Add(this.lIHShipToAdr2);
            this.groupBox6.Controls.Add(this.lCustCountry);
            this.groupBox6.Controls.Add(this.textBox10);
            this.groupBox6.Controls.Add(this.textBox11);
            this.groupBox6.Controls.Add(this.lCustRegion);
            this.groupBox6.Controls.Add(this.lIHShipToCust);
            this.groupBox6.Controls.Add(this.label54);
            this.groupBox6.Controls.Add(this.textBox31);
            this.groupBox6.Controls.Add(this.btnSchSFContact);
            this.groupBox6.Location = new System.Drawing.Point(408, 80);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(384, 312);
            this.groupBox6.TabIndex = 74;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Ship To";
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(8, 284);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(48, 20);
            this.label56.TabIndex = 113;
            this.label56.Text = "Phone #";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tBoxContactPhoneST
            // 
            this.tBoxContactPhoneST.Location = new System.Drawing.Point(80, 284);
            this.tBoxContactPhoneST.MaxLength = 20;
            this.tBoxContactPhoneST.Name = "tBoxContactPhoneST";
            this.tBoxContactPhoneST.ReadOnly = true;
            this.tBoxContactPhoneST.Size = new System.Drawing.Size(120, 20);
            this.tBoxContactPhoneST.TabIndex = 112;
            this.tBoxContactPhoneST.Text = "";
            // 
            // tBoxContactNameST
            // 
            this.tBoxContactNameST.Location = new System.Drawing.Point(80, 264);
            this.tBoxContactNameST.MaxLength = 20;
            this.tBoxContactNameST.Name = "tBoxContactNameST";
            this.tBoxContactNameST.Size = new System.Drawing.Size(120, 20);
            this.tBoxContactNameST.TabIndex = 110;
            this.tBoxContactNameST.Text = "";
            // 
            // label57
            // 
            this.label57.Location = new System.Drawing.Point(8, 264);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(60, 20);
            this.label57.TabIndex = 109;
            this.label57.Text = "Contact";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(8, 204);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(56, 20);
            this.label52.TabIndex = 79;
            this.label52.Text = "Region";
            // 
            // textBox29
            // 
            this.textBox29.Location = new System.Drawing.Point(80, 204);
            this.textBox29.MaxLength = 20;
            this.textBox29.Name = "textBox29";
            this.textBox29.ReadOnly = true;
            this.textBox29.Size = new System.Drawing.Size(120, 20);
            this.textBox29.TabIndex = 78;
            this.textBox29.Text = "";
            // 
            // textBox27
            // 
            this.textBox27.Location = new System.Drawing.Point(80, 144);
            this.textBox27.MaxLength = 20;
            this.textBox27.Name = "textBox27";
            this.textBox27.ReadOnly = true;
            this.textBox27.Size = new System.Drawing.Size(120, 20);
            this.textBox27.TabIndex = 76;
            this.textBox27.Text = "";
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(8, 144);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(64, 20);
            this.label50.TabIndex = 77;
            this.label50.Text = "City";
            // 
            // comboBox1
            // 
            this.comboBox1.Items.AddRange(new object[] {
                                                           "Bussiness",
                                                           "Consumer"});
            this.comboBox1.Location = new System.Drawing.Point(80, 244);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(80, 21);
            this.comboBox1.TabIndex = 59;
            this.comboBox1.Text = "Bussiness";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(8, 244);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 20);
            this.label19.TabIndex = 58;
            this.label19.Text = "Ship To Type";
            // 
            // tBocIHShipToAdr1
            // 
            this.tBocIHShipToAdr1.Location = new System.Drawing.Point(80, 64);
            this.tBocIHShipToAdr1.MaxLength = 40;
            this.tBocIHShipToAdr1.Name = "tBocIHShipToAdr1";
            this.tBocIHShipToAdr1.ReadOnly = true;
            this.tBocIHShipToAdr1.Size = new System.Drawing.Size(248, 20);
            this.tBocIHShipToAdr1.TabIndex = 42;
            this.tBocIHShipToAdr1.Text = "";
            // 
            // tBoxIH_ShipToAdr2
            // 
            this.tBoxIH_ShipToAdr2.Location = new System.Drawing.Point(80, 84);
            this.tBoxIH_ShipToAdr2.MaxLength = 40;
            this.tBoxIH_ShipToAdr2.Name = "tBoxIH_ShipToAdr2";
            this.tBoxIH_ShipToAdr2.ReadOnly = true;
            this.tBoxIH_ShipToAdr2.Size = new System.Drawing.Size(248, 20);
            this.tBoxIH_ShipToAdr2.TabIndex = 50;
            this.tBoxIH_ShipToAdr2.Text = "";
            // 
            // lIHShipToAdr1
            // 
            this.lIHShipToAdr1.Location = new System.Drawing.Point(8, 64);
            this.lIHShipToAdr1.Name = "lIHShipToAdr1";
            this.lIHShipToAdr1.Size = new System.Drawing.Size(56, 20);
            this.lIHShipToAdr1.TabIndex = 43;
            this.lIHShipToAdr1.Text = "Address 1";
            // 
            // tBoxIH_ShipToCust
            // 
            this.tBoxIH_ShipToCust.Location = new System.Drawing.Point(80, 24);
            this.tBoxIH_ShipToCust.MaxLength = 20;
            this.tBoxIH_ShipToCust.Name = "tBoxIH_ShipToCust";
            this.tBoxIH_ShipToCust.Size = new System.Drawing.Size(128, 20);
            this.tBoxIH_ShipToCust.TabIndex = 33;
            this.tBoxIH_ShipToCust.Text = "";
            // 
            // btnSchCust
            // 
            this.btnSchCust.Location = new System.Drawing.Point(216, 24);
            this.btnSchCust.Name = "btnSchCust";
            this.btnSchCust.Size = new System.Drawing.Size(24, 16);
            this.btnSchCust.TabIndex = 37;
            this.btnSchCust.Text = "...";
            // 
            // lIHShipToName
            // 
            this.lIHShipToName.Location = new System.Drawing.Point(8, 44);
            this.lIHShipToName.Name = "lIHShipToName";
            this.lIHShipToName.Size = new System.Drawing.Size(40, 20);
            this.lIHShipToName.TabIndex = 36;
            this.lIHShipToName.Text = "Name";
            // 
            // tBoxIHShipToName
            // 
            this.tBoxIHShipToName.Location = new System.Drawing.Point(80, 44);
            this.tBoxIHShipToName.MaxLength = 40;
            this.tBoxIHShipToName.Name = "tBoxIHShipToName";
            this.tBoxIHShipToName.ReadOnly = true;
            this.tBoxIHShipToName.Size = new System.Drawing.Size(248, 20);
            this.tBoxIHShipToName.TabIndex = 35;
            this.tBoxIHShipToName.Text = "";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(80, 124);
            this.textBox9.MaxLength = 20;
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(120, 20);
            this.textBox9.TabIndex = 52;
            this.textBox9.Text = "";
            // 
            // lCustCity
            // 
            this.lCustCity.Location = new System.Drawing.Point(8, 124);
            this.lCustCity.Name = "lCustCity";
            this.lCustCity.Size = new System.Drawing.Size(64, 20);
            this.lCustCity.TabIndex = 53;
            this.lCustCity.Text = "Prov/State";
            // 
            // tBoxIH_ShipToAdr3
            // 
            this.tBoxIH_ShipToAdr3.Location = new System.Drawing.Point(80, 104);
            this.tBoxIH_ShipToAdr3.MaxLength = 40;
            this.tBoxIH_ShipToAdr3.Name = "tBoxIH_ShipToAdr3";
            this.tBoxIH_ShipToAdr3.ReadOnly = true;
            this.tBoxIH_ShipToAdr3.Size = new System.Drawing.Size(248, 20);
            this.tBoxIH_ShipToAdr3.TabIndex = 48;
            this.tBoxIH_ShipToAdr3.Text = "";
            // 
            // lIHShipToAdr3
            // 
            this.lIHShipToAdr3.Location = new System.Drawing.Point(8, 104);
            this.lIHShipToAdr3.Name = "lIHShipToAdr3";
            this.lIHShipToAdr3.Size = new System.Drawing.Size(56, 20);
            this.lIHShipToAdr3.TabIndex = 49;
            this.lIHShipToAdr3.Text = "Address 3";
            // 
            // lIHShipToAdr2
            // 
            this.lIHShipToAdr2.Location = new System.Drawing.Point(8, 84);
            this.lIHShipToAdr2.Name = "lIHShipToAdr2";
            this.lIHShipToAdr2.Size = new System.Drawing.Size(56, 20);
            this.lIHShipToAdr2.TabIndex = 51;
            this.lIHShipToAdr2.Text = "Address 2";
            // 
            // lCustCountry
            // 
            this.lCustCountry.Location = new System.Drawing.Point(8, 164);
            this.lCustCountry.Name = "lCustCountry";
            this.lCustCountry.Size = new System.Drawing.Size(56, 20);
            this.lCustCountry.TabIndex = 55;
            this.lCustCountry.Text = "Country";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(80, 164);
            this.textBox10.MaxLength = 20;
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(120, 20);
            this.textBox10.TabIndex = 54;
            this.textBox10.Text = "";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(80, 224);
            this.textBox11.MaxLength = 20;
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(120, 20);
            this.textBox11.TabIndex = 56;
            this.textBox11.Text = "";
            // 
            // lCustRegion
            // 
            this.lCustRegion.Location = new System.Drawing.Point(8, 224);
            this.lCustRegion.Name = "lCustRegion";
            this.lCustRegion.Size = new System.Drawing.Size(56, 20);
            this.lCustRegion.TabIndex = 57;
            this.lCustRegion.Text = "Territory";
            // 
            // lIHShipToCust
            // 
            this.lIHShipToCust.Location = new System.Drawing.Point(8, 24);
            this.lIHShipToCust.Name = "lIHShipToCust";
            this.lIHShipToCust.Size = new System.Drawing.Size(72, 20);
            this.lIHShipToCust.TabIndex = 34;
            this.lIHShipToCust.Text = "Ship to";
            // 
            // label54
            // 
            this.label54.Location = new System.Drawing.Point(8, 184);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(60, 20);
            this.label54.TabIndex = 94;
            this.label54.Text = "Post Zip";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox31
            // 
            this.textBox31.Location = new System.Drawing.Point(80, 184);
            this.textBox31.MaxLength = 20;
            this.textBox31.Name = "textBox31";
            this.textBox31.ReadOnly = true;
            this.textBox31.Size = new System.Drawing.Size(120, 20);
            this.textBox31.TabIndex = 95;
            this.textBox31.Text = "";
            // 
            // btnSchSFContact
            // 
            this.btnSchSFContact.Location = new System.Drawing.Point(208, 264);
            this.btnSchSFContact.Name = "btnSchSFContact";
            this.btnSchSFContact.Size = new System.Drawing.Size(30, 16);
            this.btnSchSFContact.TabIndex = 111;
            this.btnSchSFContact.Text = "...";
            this.btnSchSFContact.Click += new System.EventHandler(this.btnSchSFContact_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label55);
            this.groupBox3.Controls.Add(this.tBoxContactPhoneBT);
            this.groupBox3.Controls.Add(this.tBoxContactNameBT);
            this.groupBox3.Controls.Add(this.lPSFContact);
            this.groupBox3.Controls.Add(this.textBox30);
            this.groupBox3.Controls.Add(this.label53);
            this.groupBox3.Controls.Add(this.label51);
            this.groupBox3.Controls.Add(this.textBox28);
            this.groupBox3.Controls.Add(this.textBox26);
            this.groupBox3.Controls.Add(this.label48);
            this.groupBox3.Controls.Add(this.textBox12);
            this.groupBox3.Controls.Add(this.textBox13);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.textBox14);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.textBox15);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.textBox16);
            this.groupBox3.Controls.Add(this.textBox17);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.lIHBillToName);
            this.groupBox3.Controls.Add(this.btnSchBillTo);
            this.groupBox3.Controls.Add(this.lIHBillToCust);
            this.groupBox3.Controls.Add(this.tBoxIH_BillToName);
            this.groupBox3.Controls.Add(this.tBoxIH_BillToCust);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.btnSchBTContact);
            this.groupBox3.Location = new System.Drawing.Point(8, 80);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(384, 312);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bill To";
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(8, 288);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(48, 20);
            this.label55.TabIndex = 113;
            this.label55.Text = "Phone #";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tBoxContactPhoneBT
            // 
            this.tBoxContactPhoneBT.Location = new System.Drawing.Point(80, 285);
            this.tBoxContactPhoneBT.MaxLength = 20;
            this.tBoxContactPhoneBT.Name = "tBoxContactPhoneBT";
            this.tBoxContactPhoneBT.ReadOnly = true;
            this.tBoxContactPhoneBT.Size = new System.Drawing.Size(120, 20);
            this.tBoxContactPhoneBT.TabIndex = 112;
            this.tBoxContactPhoneBT.Text = "";
            // 
            // tBoxContactNameBT
            // 
            this.tBoxContactNameBT.Location = new System.Drawing.Point(80, 265);
            this.tBoxContactNameBT.MaxLength = 30;
            this.tBoxContactNameBT.Name = "tBoxContactNameBT";
            this.tBoxContactNameBT.Size = new System.Drawing.Size(120, 20);
            this.tBoxContactNameBT.TabIndex = 110;
            this.tBoxContactNameBT.Text = "";
            // 
            // lPSFContact
            // 
            this.lPSFContact.Location = new System.Drawing.Point(8, 268);
            this.lPSFContact.Name = "lPSFContact";
            this.lPSFContact.Size = new System.Drawing.Size(60, 20);
            this.lPSFContact.TabIndex = 109;
            this.lPSFContact.Text = "Contact";
            this.lPSFContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox30
            // 
            this.textBox30.Location = new System.Drawing.Point(80, 184);
            this.textBox30.MaxLength = 20;
            this.textBox30.Name = "textBox30";
            this.textBox30.ReadOnly = true;
            this.textBox30.Size = new System.Drawing.Size(120, 20);
            this.textBox30.TabIndex = 93;
            this.textBox30.Text = "";
            // 
            // label53
            // 
            this.label53.Location = new System.Drawing.Point(8, 184);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(60, 20);
            this.label53.TabIndex = 92;
            this.label53.Text = "Post Zip";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(8, 204);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(56, 20);
            this.label51.TabIndex = 77;
            this.label51.Text = "Region";
            // 
            // textBox28
            // 
            this.textBox28.Location = new System.Drawing.Point(80, 204);
            this.textBox28.MaxLength = 20;
            this.textBox28.Name = "textBox28";
            this.textBox28.ReadOnly = true;
            this.textBox28.Size = new System.Drawing.Size(120, 20);
            this.textBox28.TabIndex = 76;
            this.textBox28.Text = "";
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(80, 144);
            this.textBox26.MaxLength = 20;
            this.textBox26.Name = "textBox26";
            this.textBox26.ReadOnly = true;
            this.textBox26.Size = new System.Drawing.Size(120, 20);
            this.textBox26.TabIndex = 74;
            this.textBox26.Text = "";
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(8, 144);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(64, 20);
            this.label48.TabIndex = 75;
            this.label48.Text = "City";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(80, 64);
            this.textBox12.MaxLength = 40;
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(248, 20);
            this.textBox12.TabIndex = 60;
            this.textBox12.Text = "";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(80, 84);
            this.textBox13.MaxLength = 40;
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(248, 20);
            this.textBox13.TabIndex = 64;
            this.textBox13.Text = "";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(8, 64);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 20);
            this.label21.TabIndex = 61;
            this.label21.Text = "Address 1";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(80, 124);
            this.textBox14.MaxLength = 20;
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(120, 20);
            this.textBox14.TabIndex = 66;
            this.textBox14.Text = "";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(8, 124);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 20);
            this.label22.TabIndex = 67;
            this.label22.Text = "Prov/State";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(80, 104);
            this.textBox15.MaxLength = 40;
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(248, 20);
            this.textBox15.TabIndex = 62;
            this.textBox15.Text = "";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(8, 104);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 20);
            this.label23.TabIndex = 63;
            this.label23.Text = "Address 3";
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(8, 84);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 20);
            this.label24.TabIndex = 65;
            this.label24.Text = "Address 2";
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(8, 164);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 20);
            this.label25.TabIndex = 69;
            this.label25.Text = "Country";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(80, 164);
            this.textBox16.MaxLength = 20;
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(120, 20);
            this.textBox16.TabIndex = 68;
            this.textBox16.Text = "";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(80, 224);
            this.textBox17.MaxLength = 20;
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new System.Drawing.Size(120, 20);
            this.textBox17.TabIndex = 70;
            this.textBox17.Text = "";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(8, 224);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 20);
            this.label26.TabIndex = 71;
            this.label26.Text = "Territory";
            // 
            // lIHBillToName
            // 
            this.lIHBillToName.Location = new System.Drawing.Point(8, 44);
            this.lIHBillToName.Name = "lIHBillToName";
            this.lIHBillToName.Size = new System.Drawing.Size(48, 20);
            this.lIHBillToName.TabIndex = 56;
            this.lIHBillToName.Text = "Name";
            // 
            // btnSchBillTo
            // 
            this.btnSchBillTo.Location = new System.Drawing.Point(216, 24);
            this.btnSchBillTo.Name = "btnSchBillTo";
            this.btnSchBillTo.Size = new System.Drawing.Size(24, 16);
            this.btnSchBillTo.TabIndex = 57;
            this.btnSchBillTo.Text = "...";
            // 
            // lIHBillToCust
            // 
            this.lIHBillToCust.Location = new System.Drawing.Point(8, 24);
            this.lIHBillToCust.Name = "lIHBillToCust";
            this.lIHBillToCust.Size = new System.Drawing.Size(56, 20);
            this.lIHBillToCust.TabIndex = 54;
            this.lIHBillToCust.Text = "Bill to";
            // 
            // tBoxIH_BillToName
            // 
            this.tBoxIH_BillToName.Location = new System.Drawing.Point(80, 44);
            this.tBoxIH_BillToName.MaxLength = 40;
            this.tBoxIH_BillToName.Name = "tBoxIH_BillToName";
            this.tBoxIH_BillToName.ReadOnly = true;
            this.tBoxIH_BillToName.Size = new System.Drawing.Size(248, 20);
            this.tBoxIH_BillToName.TabIndex = 55;
            this.tBoxIH_BillToName.Text = "";
            // 
            // tBoxIH_BillToCust
            // 
            this.tBoxIH_BillToCust.Location = new System.Drawing.Point(80, 24);
            this.tBoxIH_BillToCust.MaxLength = 20;
            this.tBoxIH_BillToCust.Name = "tBoxIH_BillToCust";
            this.tBoxIH_BillToCust.Size = new System.Drawing.Size(128, 20);
            this.tBoxIH_BillToCust.TabIndex = 53;
            this.tBoxIH_BillToCust.Text = "";
            // 
            // comboBox2
            // 
            this.comboBox2.Items.AddRange(new object[] {
                                                           "Bussiness",
                                                           "Consumer"});
            this.comboBox2.Location = new System.Drawing.Point(80, 244);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(80, 21);
            this.comboBox2.TabIndex = 73;
            this.comboBox2.Text = "Bussiness";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(8, 248);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 20);
            this.label20.TabIndex = 72;
            this.label20.Text = "Bill To Type";
            // 
            // btnSchBTContact
            // 
            this.btnSchBTContact.Location = new System.Drawing.Point(208, 264);
            this.btnSchBTContact.Name = "btnSchBTContact";
            this.btnSchBTContact.Size = new System.Drawing.Size(30, 16);
            this.btnSchBTContact.TabIndex = 111;
            this.btnSchBTContact.Text = "...";
            this.btnSchBTContact.Click += new System.EventHandler(this.btnSchBTContact_Click);
            // 
            // tabPageFreigth
            // 
            this.tabPageFreigth.Controls.Add(this.gBoxAccounting);
            this.tabPageFreigth.Location = new System.Drawing.Point(4, 22);
            this.tabPageFreigth.Name = "tabPageFreigth";
            this.tabPageFreigth.Size = new System.Drawing.Size(800, 406);
            this.tabPageFreigth.TabIndex = 6;
            this.tabPageFreigth.Text = "Freigth";
            // 
            // gBoxAccounting
            // 
            this.gBoxAccounting.Controls.Add(this.groupBox5);
            this.gBoxAccounting.Controls.Add(this.dGridShowDetail);
            this.gBoxAccounting.Controls.Add(this.treeViewInfo);
            this.gBoxAccounting.Controls.Add(this.button6);
            this.gBoxAccounting.Location = new System.Drawing.Point(0, 0);
            this.gBoxAccounting.Name = "gBoxAccounting";
            this.gBoxAccounting.Size = new System.Drawing.Size(800, 392);
            this.gBoxAccounting.TabIndex = 0;
            this.gBoxAccounting.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dateTimePicker6);
            this.groupBox5.Controls.Add(this.label100);
            this.groupBox5.Controls.Add(this.dateTimePicker7);
            this.groupBox5.Controls.Add(this.label101);
            this.groupBox5.Controls.Add(this.dateTimePicker5);
            this.groupBox5.Controls.Add(this.label99);
            this.groupBox5.Controls.Add(this.textBox35);
            this.groupBox5.Controls.Add(this.label98);
            this.groupBox5.Controls.Add(this.tBoxIH_FreigthTerms);
            this.groupBox5.Controls.Add(this.label97);
            this.groupBox5.Controls.Add(this.textBox34);
            this.groupBox5.Controls.Add(this.lIHFreigthTerms);
            this.groupBox5.Controls.Add(this.textBox33);
            this.groupBox5.Controls.Add(this.label64);
            this.groupBox5.Controls.Add(this.label63);
            this.groupBox5.Controls.Add(this.numericTextBox39);
            this.groupBox5.Controls.Add(this.numericTextBox38);
            this.groupBox5.Controls.Add(this.label62);
            this.groupBox5.Controls.Add(this.numericTextBox37);
            this.groupBox5.Controls.Add(this.label61);
            this.groupBox5.Controls.Add(this.numericTextBox36);
            this.groupBox5.Controls.Add(this.label60);
            this.groupBox5.Controls.Add(this.numericTextBox35);
            this.groupBox5.Controls.Add(this.label59);
            this.groupBox5.Controls.Add(this.textBox8);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.numericTextBox6);
            this.groupBox5.Controls.Add(this.textBox7);
            this.groupBox5.Controls.Add(this.textBox6);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.numericTextBox4);
            this.groupBox5.Controls.Add(this.numericUpDown1);
            this.groupBox5.Controls.Add(this.dateTimePicker1);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.numericTextBox3);
            this.groupBox5.Controls.Add(this.textBox4);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.numericTextBox2);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Location = new System.Drawing.Point(8, 208);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(784, 144);
            this.groupBox5.TabIndex = 81;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Container";
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
            this.label100.Location = new System.Drawing.Point(448, 112);
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
            this.label101.Location = new System.Drawing.Point(448, 88);
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
            this.label99.Location = new System.Drawing.Point(280, 112);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(80, 16);
            this.label99.TabIndex = 86;
            this.label99.Text = "Pickup Time";
            // 
            // textBox35
            // 
            this.textBox35.Location = new System.Drawing.Point(672, 64);
            this.textBox35.MaxLength = 5;
            this.textBox35.Name = "textBox35";
            this.textBox35.Size = new System.Drawing.Size(72, 20);
            this.textBox35.TabIndex = 84;
            this.textBox35.Text = "";
            // 
            // label98
            // 
            this.label98.Location = new System.Drawing.Point(600, 64);
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
            this.label97.Location = new System.Drawing.Point(440, 64);
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
            this.lIHFreigthTerms.Location = new System.Drawing.Point(280, 64);
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
            // label64
            // 
            this.label64.Location = new System.Drawing.Point(176, 112);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(56, 16);
            this.label64.TabIndex = 71;
            this.label64.Text = "FOB Point";
            // 
            // label63
            // 
            this.label63.Location = new System.Drawing.Point(176, 88);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(48, 16);
            this.label63.TabIndex = 69;
            this.label63.Text = "Pro#";
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
            // label62
            // 
            this.label62.Location = new System.Drawing.Point(416, 36);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(80, 20);
            this.label62.TabIndex = 66;
            this.label62.Text = "Manual Weigth";
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
            // label61
            // 
            this.label61.Location = new System.Drawing.Point(568, 36);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(72, 20);
            this.label61.TabIndex = 64;
            this.label61.Text = "Manual Vol";
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
            // label60
            // 
            this.label60.Location = new System.Drawing.Point(424, 16);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(64, 20);
            this.label60.TabIndex = 62;
            this.label60.Text = "Net Weigth";
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
            // label59
            // 
            this.label59.Location = new System.Drawing.Point(272, 16);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(72, 20);
            this.label59.TabIndex = 60;
            this.label59.Text = "Tare Weigth";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(80, 112);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(88, 20);
            this.textBox8.TabIndex = 56;
            this.textBox8.Text = "";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(8, 112);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 16);
            this.label18.TabIndex = 57;
            this.label18.Text = "Carrier Loc.";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(176, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 16);
            this.label16.TabIndex = 55;
            this.label16.Text = "Trailer #";
            // 
            // numericTextBox6
            // 
            this.numericTextBox6.Location = new System.Drawing.Point(232, 64);
            this.numericTextBox6.Maximum = new System.Decimal(new int[] {
                                                                            1000000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox6.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox6.Name = "numericTextBox6";
            this.numericTextBox6.Size = new System.Drawing.Size(40, 20);
            this.numericTextBox6.TabIndex = 54;
            this.numericTextBox6.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(80, 64);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(88, 20);
            this.textBox7.TabIndex = 52;
            this.textBox7.Text = "";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(80, 88);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(88, 20);
            this.textBox6.TabIndex = 50;
            this.textBox6.Text = "";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 16);
            this.label13.TabIndex = 51;
            this.label13.Text = "Carrier Name";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 16);
            this.label14.TabIndex = 48;
            this.label14.Text = "SCAC";
            // 
            // numericTextBox4
            // 
            this.numericTextBox4.Location = new System.Drawing.Point(688, 112);
            this.numericTextBox4.Maximum = new System.Decimal(new int[] {
                                                                            1000000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox4.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox4.Name = "numericTextBox4";
            this.numericTextBox4.Size = new System.Drawing.Size(64, 20);
            this.numericTextBox4.TabIndex = 47;
            this.numericTextBox4.Value = new System.Decimal(new int[] {
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
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(352, 88);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(88, 20);
            this.dateTimePicker1.TabIndex = 34;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(640, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(56, 20);
            this.textBox1.TabIndex = 40;
            this.textBox1.Text = "";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(128, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 20);
            this.label11.TabIndex = 42;
            this.label11.Text = "Total Volume";
            // 
            // numericTextBox3
            // 
            this.numericTextBox3.Location = new System.Drawing.Point(208, 36);
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
            this.numericTextBox3.TabIndex = 43;
            this.numericTextBox3.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(352, 36);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(56, 20);
            this.textBox4.TabIndex = 44;
            this.textBox4.Text = "";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(272, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 20);
            this.label10.TabIndex = 45;
            this.label10.Text = "Volume Uom";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(568, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 20);
            this.label9.TabIndex = 41;
            this.label9.Text = "Weigth Uom";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Total Skids";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(280, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "Pickup Date";
            // 
            // numericTextBox2
            // 
            this.numericTextBox2.Location = new System.Drawing.Point(208, 16);
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
            this.numericTextBox2.TabIndex = 39;
            this.numericTextBox2.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(128, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 20);
            this.label8.TabIndex = 38;
            this.label8.Text = "Total Weigth";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(616, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 16);
            this.label12.TabIndex = 46;
            this.label12.Text = "Freight Total";
            // 
            // dGridShowDetail
            // 
            this.dGridShowDetail.DataMember = "";
            this.dGridShowDetail.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridShowDetail.Location = new System.Drawing.Point(176, 16);
            this.dGridShowDetail.Name = "dGridShowDetail";
            this.dGridShowDetail.Size = new System.Drawing.Size(616, 184);
            this.dGridShowDetail.TabIndex = 1;
            // 
            // treeViewInfo
            // 
            this.treeViewInfo.ImageIndex = -1;
            this.treeViewInfo.Location = new System.Drawing.Point(8, 16);
            this.treeViewInfo.Name = "treeViewInfo";
            this.treeViewInfo.SelectedImageIndex = -1;
            this.treeViewInfo.Size = new System.Drawing.Size(160, 184);
            this.treeViewInfo.TabIndex = 0;
            this.treeViewInfo.Click += new System.EventHandler(this.treeViewInfo_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(712, 360);
            this.button6.Name = "button6";
            this.button6.TabIndex = 82;
            this.button6.Text = "3rd Party";
            // 
            // tabPageAccounting
            // 
            this.tabPageAccounting.Controls.Add(this.button2);
            this.tabPageAccounting.Controls.Add(this.groupBox15);
            this.tabPageAccounting.Controls.Add(this.gBoxCost);
            this.tabPageAccounting.Controls.Add(this.groupBox16);
            this.tabPageAccounting.Controls.Add(this.groupBox17);
            this.tabPageAccounting.Controls.Add(this.gBoxTax);
            this.tabPageAccounting.Location = new System.Drawing.Point(4, 22);
            this.tabPageAccounting.Name = "tabPageAccounting";
            this.tabPageAccounting.Size = new System.Drawing.Size(800, 406);
            this.tabPageAccounting.TabIndex = 9;
            this.tabPageAccounting.Text = "Accounting/Cost";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(632, 320);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 52;
            this.button2.Text = "GL Distribution";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.ntbID_ComPercent);
            this.groupBox15.Controls.Add(this.ntbID_CommRate);
            this.groupBox15.Controls.Add(this.label79);
            this.groupBox15.Controls.Add(this.lIdCommPercent);
            this.groupBox15.Controls.Add(this.tBoxId_CommPlan);
            this.groupBox15.Controls.Add(this.lIdCommPlan);
            this.groupBox15.Controls.Add(this.btnSchSalesPer);
            this.groupBox15.Controls.Add(this.tBoxID_SalesPerson);
            this.groupBox15.Controls.Add(this.lIDSalesPerson);
            this.groupBox15.Location = new System.Drawing.Point(64, 272);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(512, 72);
            this.groupBox15.TabIndex = 47;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Commision";
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
            // label79
            // 
            this.label79.Location = new System.Drawing.Point(216, 48);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(96, 16);
            this.label79.TabIndex = 57;
            this.label79.Text = "Commission Rate";
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
            this.gBoxCost.Controls.Add(this.label80);
            this.gBoxCost.Controls.Add(this.label81);
            this.gBoxCost.Controls.Add(this.numericTextBox20);
            this.gBoxCost.Controls.Add(this.label82);
            this.gBoxCost.Controls.Add(this.numericTextBox21);
            this.gBoxCost.Controls.Add(this.label83);
            this.gBoxCost.Controls.Add(this.numericTextBox22);
            this.gBoxCost.Controls.Add(this.label84);
            this.gBoxCost.Controls.Add(this.numericTextBox23);
            this.gBoxCost.Controls.Add(this.label85);
            this.gBoxCost.Controls.Add(this.numericTextBox24);
            this.gBoxCost.Controls.Add(this.label86);
            this.gBoxCost.Controls.Add(this.numericTextBox25);
            this.gBoxCost.Controls.Add(this.label87);
            this.gBoxCost.Controls.Add(this.numericTextBox26);
            this.gBoxCost.Controls.Add(this.label88);
            this.gBoxCost.Controls.Add(this.numericTextBox27);
            this.gBoxCost.Controls.Add(this.label89);
            this.gBoxCost.Controls.Add(this.numericTextBox28);
            this.gBoxCost.Controls.Add(this.label90);
            this.gBoxCost.Controls.Add(this.numericTextBox29);
            this.gBoxCost.Controls.Add(this.label91);
            this.gBoxCost.Controls.Add(this.numericTextBox30);
            this.gBoxCost.Controls.Add(this.label92);
            this.gBoxCost.Controls.Add(this.numericTextBox31);
            this.gBoxCost.Controls.Add(this.label93);
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
            this.gBoxCost.Location = new System.Drawing.Point(64, 40);
            this.gBoxCost.Name = "gBoxCost";
            this.gBoxCost.Size = new System.Drawing.Size(360, 224);
            this.gBoxCost.TabIndex = 50;
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
            // label80
            // 
            this.label80.Location = new System.Drawing.Point(128, 200);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(88, 16);
            this.label80.TabIndex = 38;
            this.label80.Text = "Total ";
            // 
            // label81
            // 
            this.label81.Location = new System.Drawing.Point(8, 88);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(48, 16);
            this.label81.TabIndex = 37;
            this.label81.Text = "Lab ";
            // 
            // numericTextBox20
            // 
            this.numericTextBox20.Location = new System.Drawing.Point(264, 108);
            this.numericTextBox20.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox20.MaxPrecision = 5;
            this.numericTextBox20.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox20.Name = "numericTextBox20";
            this.numericTextBox20.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox20.TabIndex = 36;
            this.numericTextBox20.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label82
            // 
            this.label82.Location = new System.Drawing.Point(184, 112);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(80, 16);
            this.label82.TabIndex = 35;
            this.label82.Text = "User Cost 2";
            // 
            // numericTextBox21
            // 
            this.numericTextBox21.Location = new System.Drawing.Point(264, 148);
            this.numericTextBox21.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox21.MaxPrecision = 5;
            this.numericTextBox21.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox21.Name = "numericTextBox21";
            this.numericTextBox21.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox21.TabIndex = 34;
            this.numericTextBox21.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label83
            // 
            this.label83.Location = new System.Drawing.Point(184, 152);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(72, 16);
            this.label83.TabIndex = 33;
            this.label83.Text = "User Cost 4";
            // 
            // numericTextBox22
            // 
            this.numericTextBox22.Location = new System.Drawing.Point(264, 128);
            this.numericTextBox22.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox22.MaxPrecision = 5;
            this.numericTextBox22.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox22.Name = "numericTextBox22";
            this.numericTextBox22.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox22.TabIndex = 32;
            this.numericTextBox22.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label84
            // 
            this.label84.Location = new System.Drawing.Point(184, 132);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(72, 16);
            this.label84.TabIndex = 31;
            this.label84.Text = "User Cost 3";
            // 
            // numericTextBox23
            // 
            this.numericTextBox23.Location = new System.Drawing.Point(264, 168);
            this.numericTextBox23.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox23.MaxPrecision = 5;
            this.numericTextBox23.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox23.Name = "numericTextBox23";
            this.numericTextBox23.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox23.TabIndex = 30;
            this.numericTextBox23.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label85
            // 
            this.label85.Location = new System.Drawing.Point(184, 176);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(72, 16);
            this.label85.TabIndex = 29;
            this.label85.Text = "User Cost 5";
            // 
            // numericTextBox24
            // 
            this.numericTextBox24.Location = new System.Drawing.Point(264, 88);
            this.numericTextBox24.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox24.MaxPrecision = 5;
            this.numericTextBox24.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox24.Name = "numericTextBox24";
            this.numericTextBox24.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox24.TabIndex = 28;
            this.numericTextBox24.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label86
            // 
            this.label86.Location = new System.Drawing.Point(184, 92);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(88, 16);
            this.label86.TabIndex = 27;
            this.label86.Text = "User Cost 1";
            // 
            // numericTextBox25
            // 
            this.numericTextBox25.Location = new System.Drawing.Point(264, 68);
            this.numericTextBox25.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox25.MaxPrecision = 5;
            this.numericTextBox25.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox25.Name = "numericTextBox25";
            this.numericTextBox25.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox25.TabIndex = 26;
            this.numericTextBox25.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label87
            // 
            this.label87.Location = new System.Drawing.Point(184, 72);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(88, 16);
            this.label87.TabIndex = 25;
            this.label87.Text = "Curr. Exchange";
            // 
            // numericTextBox26
            // 
            this.numericTextBox26.Location = new System.Drawing.Point(264, 48);
            this.numericTextBox26.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox26.MaxPrecision = 5;
            this.numericTextBox26.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox26.Name = "numericTextBox26";
            this.numericTextBox26.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox26.TabIndex = 24;
            this.numericTextBox26.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label88
            // 
            this.label88.Location = new System.Drawing.Point(184, 48);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(88, 16);
            this.label88.TabIndex = 23;
            this.label88.Text = "Outside Proc";
            // 
            // numericTextBox27
            // 
            this.numericTextBox27.Location = new System.Drawing.Point(264, 28);
            this.numericTextBox27.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox27.MaxPrecision = 5;
            this.numericTextBox27.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox27.Name = "numericTextBox27";
            this.numericTextBox27.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox27.TabIndex = 22;
            this.numericTextBox27.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label89
            // 
            this.label89.Location = new System.Drawing.Point(184, 32);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(88, 16);
            this.label89.TabIndex = 21;
            this.label89.Text = "Warehouseing";
            // 
            // numericTextBox28
            // 
            this.numericTextBox28.Location = new System.Drawing.Point(264, 8);
            this.numericTextBox28.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox28.MaxPrecision = 5;
            this.numericTextBox28.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox28.Name = "numericTextBox28";
            this.numericTextBox28.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox28.TabIndex = 20;
            this.numericTextBox28.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label90
            // 
            this.label90.Location = new System.Drawing.Point(184, 12);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(88, 16);
            this.label90.TabIndex = 19;
            this.label90.Text = "InDirect Labour";
            // 
            // numericTextBox29
            // 
            this.numericTextBox29.Location = new System.Drawing.Point(88, 168);
            this.numericTextBox29.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox29.MaxPrecision = 5;
            this.numericTextBox29.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox29.Name = "numericTextBox29";
            this.numericTextBox29.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox29.TabIndex = 18;
            this.numericTextBox29.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label91
            // 
            this.label91.Location = new System.Drawing.Point(8, 176);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(88, 16);
            this.label91.TabIndex = 17;
            this.label91.Text = "InDirect Burden";
            // 
            // numericTextBox30
            // 
            this.numericTextBox30.Location = new System.Drawing.Point(88, 148);
            this.numericTextBox30.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox30.MaxPrecision = 5;
            this.numericTextBox30.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox30.Name = "numericTextBox30";
            this.numericTextBox30.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox30.TabIndex = 16;
            this.numericTextBox30.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label92
            // 
            this.label92.Location = new System.Drawing.Point(8, 152);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(80, 16);
            this.label92.TabIndex = 15;
            this.label92.Text = "Direct Labour";
            // 
            // numericTextBox31
            // 
            this.numericTextBox31.Location = new System.Drawing.Point(88, 128);
            this.numericTextBox31.Maximum = new System.Decimal(new int[] {
                                                                             -1530494977,
                                                                             232830,
                                                                             0,
                                                                             0});
            this.numericTextBox31.MaxPrecision = 5;
            this.numericTextBox31.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox31.Name = "numericTextBox31";
            this.numericTextBox31.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox31.TabIndex = 14;
            this.numericTextBox31.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label93
            // 
            this.label93.Location = new System.Drawing.Point(8, 132);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(80, 16);
            this.label93.TabIndex = 13;
            this.label93.Text = "Direct Burden";
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
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.numericTextBox32);
            this.groupBox16.Controls.Add(this.label94);
            this.groupBox16.Controls.Add(this.ntbID_RoyCharges);
            this.groupBox16.Controls.Add(this.ntbId_FreigthAmt);
            this.groupBox16.Controls.Add(this.lIDRoyCharges);
            this.groupBox16.Controls.Add(this.lIdFreightAmt);
            this.groupBox16.Controls.Add(this.numericTextBox33);
            this.groupBox16.Controls.Add(this.numericTextBox34);
            this.groupBox16.Controls.Add(this.label95);
            this.groupBox16.Controls.Add(this.label96);
            this.groupBox16.Location = new System.Drawing.Point(424, 40);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(144, 128);
            this.groupBox16.TabIndex = 51;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Sales";
            // 
            // numericTextBox32
            // 
            this.numericTextBox32.Location = new System.Drawing.Point(72, 104);
            this.numericTextBox32.Maximum = new System.Decimal(new int[] {
                                                                             1316134911,
                                                                             2328,
                                                                             0,
                                                                             0});
            this.numericTextBox32.MaxPrecision = 2;
            this.numericTextBox32.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox32.Name = "numericTextBox32";
            this.numericTextBox32.Size = new System.Drawing.Size(64, 20);
            this.numericTextBox32.TabIndex = 11;
            this.numericTextBox32.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label94
            // 
            this.label94.Location = new System.Drawing.Point(8, 104);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(52, 16);
            this.label94.TabIndex = 10;
            this.label94.Text = "Total";
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
            // numericTextBox33
            // 
            this.numericTextBox33.Location = new System.Drawing.Point(72, 36);
            this.numericTextBox33.Maximum = new System.Decimal(new int[] {
                                                                             -727379969,
                                                                             232,
                                                                             0,
                                                                             0});
            this.numericTextBox33.MaxPrecision = 2;
            this.numericTextBox33.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox33.Name = "numericTextBox33";
            this.numericTextBox33.Size = new System.Drawing.Size(64, 20);
            this.numericTextBox33.TabIndex = 5;
            this.numericTextBox33.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // numericTextBox34
            // 
            this.numericTextBox34.Location = new System.Drawing.Point(72, 16);
            this.numericTextBox34.Maximum = new System.Decimal(new int[] {
                                                                             -727379969,
                                                                             232,
                                                                             0,
                                                                             0});
            this.numericTextBox34.MaxPrecision = 2;
            this.numericTextBox34.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox34.Name = "numericTextBox34";
            this.numericTextBox34.Size = new System.Drawing.Size(64, 20);
            this.numericTextBox34.TabIndex = 3;
            this.numericTextBox34.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label95
            // 
            this.label95.Location = new System.Drawing.Point(8, 40);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(72, 16);
            this.label95.TabIndex = 2;
            this.label95.Text = "Discounts";
            // 
            // label96
            // 
            this.label96.Location = new System.Drawing.Point(8, 20);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(72, 16);
            this.label96.TabIndex = 0;
            this.label96.Text = "Commisions";
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.tBoxID_GLSalesAcc);
            this.groupBox17.Controls.Add(this.lIDGLSalesAcc);
            this.groupBox17.Controls.Add(this.lIDGLCosAcc);
            this.groupBox17.Controls.Add(this.tBoxID_GLCosAcc);
            this.groupBox17.Controls.Add(this.tBoxID_GLCosType);
            this.groupBox17.Controls.Add(this.lIDGLCosType);
            this.groupBox17.Location = new System.Drawing.Point(568, 168);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(152, 96);
            this.groupBox17.TabIndex = 49;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "General Leadger";
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
            this.gBoxTax.Location = new System.Drawing.Point(568, 40);
            this.gBoxTax.Name = "gBoxTax";
            this.gBoxTax.Size = new System.Drawing.Size(152, 128);
            this.gBoxTax.TabIndex = 48;
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
            // tabPagePart
            // 
            this.tabPagePart.Controls.Add(this.groupBox18);
            this.tabPagePart.Controls.Add(this.groupBox1);
            this.tabPagePart.Location = new System.Drawing.Point(4, 22);
            this.tabPagePart.Name = "tabPagePart";
            this.tabPagePart.Size = new System.Drawing.Size(800, 406);
            this.tabPagePart.TabIndex = 2;
            this.tabPagePart.Text = "Part information";
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.textBox56);
            this.groupBox18.Controls.Add(this.label75);
            this.groupBox18.Controls.Add(this.textBox52);
            this.groupBox18.Controls.Add(this.label66);
            this.groupBox18.Controls.Add(this.textBox43);
            this.groupBox18.Controls.Add(this.label65);
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
            this.groupBox18.Location = new System.Drawing.Point(8, 256);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(784, 128);
            this.groupBox18.TabIndex = 47;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Summarize";
            // 
            // textBox56
            // 
            this.textBox56.Location = new System.Drawing.Point(408, 34);
            this.textBox56.Name = "textBox56";
            this.textBox56.Size = new System.Drawing.Size(80, 20);
            this.textBox56.TabIndex = 105;
            this.textBox56.Text = "0";
            // 
            // label75
            // 
            this.label75.Location = new System.Drawing.Point(288, 34);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(64, 20);
            this.label75.TabIndex = 104;
            this.label75.Text = "Discounts";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox52
            // 
            this.textBox52.Location = new System.Drawing.Point(408, 54);
            this.textBox52.Name = "textBox52";
            this.textBox52.Size = new System.Drawing.Size(80, 20);
            this.textBox52.TabIndex = 103;
            this.textBox52.Text = "0";
            // 
            // label66
            // 
            this.label66.Location = new System.Drawing.Point(288, 54);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(112, 20);
            this.label66.TabIndex = 102;
            this.label66.Text = "Invoice Before Taxes";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox43
            // 
            this.textBox43.Location = new System.Drawing.Point(640, 74);
            this.textBox43.Name = "textBox43";
            this.textBox43.Size = new System.Drawing.Size(80, 20);
            this.textBox43.TabIndex = 101;
            this.textBox43.Text = "0";
            // 
            // label65
            // 
            this.label65.Location = new System.Drawing.Point(560, 74);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(64, 20);
            this.label65.TabIndex = 100;
            this.label65.Text = "Royalties";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox53
            // 
            this.textBox53.Location = new System.Drawing.Point(640, 54);
            this.textBox53.Name = "textBox53";
            this.textBox53.Size = new System.Drawing.Size(80, 20);
            this.textBox53.TabIndex = 99;
            this.textBox53.Text = "0";
            // 
            // label76
            // 
            this.label76.Location = new System.Drawing.Point(560, 54);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(64, 20);
            this.label76.TabIndex = 98;
            this.label76.Text = "Taxes";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox54
            // 
            this.textBox54.Location = new System.Drawing.Point(640, 34);
            this.textBox54.Name = "textBox54";
            this.textBox54.Size = new System.Drawing.Size(80, 20);
            this.textBox54.TabIndex = 97;
            this.textBox54.Text = "0";
            // 
            // label77
            // 
            this.label77.Location = new System.Drawing.Point(560, 34);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(80, 20);
            this.label77.TabIndex = 96;
            this.label77.Text = "Freight";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox55
            // 
            this.textBox55.Location = new System.Drawing.Point(640, 14);
            this.textBox55.Name = "textBox55";
            this.textBox55.Size = new System.Drawing.Size(80, 20);
            this.textBox55.TabIndex = 95;
            this.textBox55.Text = "0";
            // 
            // label78
            // 
            this.label78.Location = new System.Drawing.Point(560, 14);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(80, 20);
            this.label78.TabIndex = 94;
            this.label78.Text = "Gross Margin";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox48
            // 
            this.textBox48.Location = new System.Drawing.Point(640, 94);
            this.textBox48.Name = "textBox48";
            this.textBox48.Size = new System.Drawing.Size(80, 20);
            this.textBox48.TabIndex = 93;
            this.textBox48.Text = "0";
            // 
            // label71
            // 
            this.label71.Location = new System.Drawing.Point(560, 94);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(56, 20);
            this.label71.TabIndex = 92;
            this.label71.Text = "Total ";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox49
            // 
            this.textBox49.Location = new System.Drawing.Point(408, 94);
            this.textBox49.Name = "textBox49";
            this.textBox49.Size = new System.Drawing.Size(80, 20);
            this.textBox49.TabIndex = 91;
            this.textBox49.Text = "0";
            // 
            // label72
            // 
            this.label72.Location = new System.Drawing.Point(288, 94);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(112, 20);
            this.label72.TabIndex = 90;
            this.label72.Text = "Total Order Charges";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox50
            // 
            this.textBox50.Location = new System.Drawing.Point(408, 74);
            this.textBox50.Name = "textBox50";
            this.textBox50.Size = new System.Drawing.Size(80, 20);
            this.textBox50.TabIndex = 89;
            this.textBox50.Text = "0";
            // 
            // label73
            // 
            this.label73.Location = new System.Drawing.Point(288, 74);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(80, 20);
            this.label73.TabIndex = 88;
            this.label73.Text = "Total Order";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox51
            // 
            this.textBox51.Location = new System.Drawing.Point(408, 14);
            this.textBox51.Name = "textBox51";
            this.textBox51.Size = new System.Drawing.Size(80, 20);
            this.textBox51.TabIndex = 87;
            this.textBox51.Text = "0";
            // 
            // label74
            // 
            this.label74.Location = new System.Drawing.Point(288, 14);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(80, 20);
            this.label74.TabIndex = 86;
            this.label74.Text = "Costs";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox47
            // 
            this.textBox47.Location = new System.Drawing.Point(136, 84);
            this.textBox47.Name = "textBox47";
            this.textBox47.Size = new System.Drawing.Size(80, 20);
            this.textBox47.TabIndex = 85;
            this.textBox47.Text = "0";
            // 
            // label70
            // 
            this.label70.Location = new System.Drawing.Point(32, 84);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(104, 20);
            this.label70.TabIndex = 84;
            this.label70.Text = "Total Lines Avaible";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox46
            // 
            this.textBox46.Location = new System.Drawing.Point(136, 64);
            this.textBox46.Name = "textBox46";
            this.textBox46.Size = new System.Drawing.Size(80, 20);
            this.textBox46.TabIndex = 83;
            this.textBox46.Text = "0";
            // 
            // label69
            // 
            this.label69.Location = new System.Drawing.Point(32, 64);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(96, 20);
            this.label69.TabIndex = 82;
            this.label69.Text = "Total Lines Req.";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox45
            // 
            this.textBox45.Location = new System.Drawing.Point(136, 44);
            this.textBox45.Name = "textBox45";
            this.textBox45.Size = new System.Drawing.Size(40, 20);
            this.textBox45.TabIndex = 81;
            this.textBox45.Text = "0";
            // 
            // label68
            // 
            this.label68.Location = new System.Drawing.Point(32, 44);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(80, 20);
            this.label68.TabIndex = 80;
            this.label68.Text = "% Commission";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox44
            // 
            this.textBox44.Location = new System.Drawing.Point(136, 24);
            this.textBox44.Name = "textBox44";
            this.textBox44.Size = new System.Drawing.Size(80, 20);
            this.textBox44.TabIndex = 79;
            this.textBox44.Text = "0";
            // 
            // label67
            // 
            this.label67.Location = new System.Drawing.Point(32, 24);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(40, 20);
            this.label67.TabIndex = 78;
            this.label67.Text = "Total";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddPart);
            this.groupBox1.Controls.Add(this.btnDeletePart);
            this.groupBox1.Controls.Add(this.btnEditPart);
            this.groupBox1.Controls.Add(this.dGridInfoPart);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 248);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btnAddPart
            // 
            this.btnAddPart.Location = new System.Drawing.Point(520, 216);
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.TabIndex = 1;
            this.btnAddPart.Text = "Add";
            this.btnAddPart.Click += new System.EventHandler(this.btnAddPart_Click);
            // 
            // btnDeletePart
            // 
            this.btnDeletePart.Location = new System.Drawing.Point(688, 216);
            this.btnDeletePart.Name = "btnDeletePart";
            this.btnDeletePart.TabIndex = 3;
            this.btnDeletePart.Text = "Delete";
            // 
            // btnEditPart
            // 
            this.btnEditPart.Location = new System.Drawing.Point(608, 216);
            this.btnEditPart.Name = "btnEditPart";
            this.btnEditPart.TabIndex = 2;
            this.btnEditPart.Text = "Edit";
            // 
            // dGridInfoPart
            // 
            this.dGridInfoPart.DataMember = "";
            this.dGridInfoPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dGridInfoPart.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridInfoPart.Location = new System.Drawing.Point(8, 16);
            this.dGridInfoPart.Name = "dGridInfoPart";
            this.dGridInfoPart.Size = new System.Drawing.Size(768, 184);
            this.dGridInfoPart.TabIndex = 0;
            // 
            // tabPageContact
            // 
            this.tabPageContact.Controls.Add(this.groupBox9);
            this.tabPageContact.Location = new System.Drawing.Point(4, 22);
            this.tabPageContact.Name = "tabPageContact";
            this.tabPageContact.Size = new System.Drawing.Size(800, 406);
            this.tabPageContact.TabIndex = 11;
            this.tabPageContact.Text = "Contact";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.groupBox23);
            this.groupBox9.Controls.Add(this.groupBox25);
            this.groupBox9.Controls.Add(this.groupBox24);
            this.groupBox9.Controls.Add(this.groupBox22);
            this.groupBox9.Controls.Add(this.groupBox21);
            this.groupBox9.Controls.Add(this.groupBox20);
            this.groupBox9.Controls.Add(this.groupBox19);
            this.groupBox9.Controls.Add(this.button1);
            this.groupBox9.Controls.Add(this.button4);
            this.groupBox9.Controls.Add(this.button5);
            this.groupBox9.Controls.Add(this.dgridContact);
            this.groupBox9.Location = new System.Drawing.Point(8, 8);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(776, 392);
            this.groupBox9.TabIndex = 95;
            this.groupBox9.TabStop = false;
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.checkBox14);
            this.groupBox23.Controls.Add(this.checkBox15);
            this.groupBox23.Controls.Add(this.checkBox17);
            this.groupBox23.Controls.Add(this.checkBox16);
            this.groupBox23.Location = new System.Drawing.Point(328, 8);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(152, 56);
            this.groupBox23.TabIndex = 112;
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
            this.groupBox25.Location = new System.Drawing.Point(328, 64);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(152, 56);
            this.groupBox25.TabIndex = 114;
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
            this.groupBox24.Location = new System.Drawing.Point(480, 8);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(152, 56);
            this.groupBox24.TabIndex = 113;
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
            this.groupBox22.Location = new System.Drawing.Point(176, 64);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(152, 56);
            this.groupBox22.TabIndex = 111;
            this.groupBox22.TabStop = false;
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
            this.groupBox21.Location = new System.Drawing.Point(16, 64);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(152, 56);
            this.groupBox21.TabIndex = 110;
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
            this.groupBox20.Location = new System.Drawing.Point(176, 8);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(152, 56);
            this.groupBox20.TabIndex = 109;
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
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.cBoxIH_Emailed);
            this.groupBox19.Controls.Add(this.cBoxIH_Faxed);
            this.groupBox19.Controls.Add(this.cBoxIH_Printed);
            this.groupBox19.Controls.Add(this.checkBox1);
            this.groupBox19.Location = new System.Drawing.Point(16, 8);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(152, 56);
            this.groupBox19.TabIndex = 108;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Quote";
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
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(88, 32);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 16);
            this.checkBox1.TabIndex = 109;
            this.checkBox1.Text = "Send";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(696, 360);
            this.button1.Name = "button1";
            this.button1.TabIndex = 94;
            this.button1.Text = "Delete";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(616, 360);
            this.button4.Name = "button4";
            this.button4.TabIndex = 93;
            this.button4.Text = "Edit";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(528, 360);
            this.button5.Name = "button5";
            this.button5.TabIndex = 92;
            this.button5.Text = "Add";
            // 
            // dgridContact
            // 
            this.dgridContact.DataMember = "";
            this.dgridContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dgridContact.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgridContact.Location = new System.Drawing.Point(8, 136);
            this.dgridContact.Name = "dgridContact";
            this.dgridContact.Size = new System.Drawing.Size(760, 216);
            this.dgridContact.TabIndex = 91;
            // 
            // tabPageLocation
            // 
            this.tabPageLocation.Controls.Add(this.gBoxShipLoc);
            this.tabPageLocation.Location = new System.Drawing.Point(4, 22);
            this.tabPageLocation.Name = "tabPageLocation";
            this.tabPageLocation.Size = new System.Drawing.Size(800, 406);
            this.tabPageLocation.TabIndex = 3;
            this.tabPageLocation.Text = "Location";
            // 
            // gBoxShipLoc
            // 
            this.gBoxShipLoc.Controls.Add(this.btnDetails);
            this.gBoxShipLoc.Controls.Add(this.groupBox11);
            this.gBoxShipLoc.Controls.Add(this.dGridShipTo);
            this.gBoxShipLoc.Location = new System.Drawing.Point(16, 8);
            this.gBoxShipLoc.Name = "gBoxShipLoc";
            this.gBoxShipLoc.Size = new System.Drawing.Size(776, 384);
            this.gBoxShipLoc.TabIndex = 53;
            this.gBoxShipLoc.TabStop = false;
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(688, 352);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.TabIndex = 75;
            this.btnDetails.Text = "Details";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label41);
            this.groupBox11.Controls.Add(this.numericTextBox16);
            this.groupBox11.Controls.Add(this.label1);
            this.groupBox11.Controls.Add(this.textBox5);
            this.groupBox11.Controls.Add(this.label4);
            this.groupBox11.Controls.Add(this.textBox21);
            this.groupBox11.Controls.Add(this.textBox22);
            this.groupBox11.Controls.Add(this.label42);
            this.groupBox11.Controls.Add(this.numericTextBox15);
            this.groupBox11.Controls.Add(this.label43);
            this.groupBox11.Location = new System.Drawing.Point(12, 8);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(756, 72);
            this.groupBox11.TabIndex = 74;
            this.groupBox11.TabStop = false;
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(224, 40);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(64, 16);
            this.label41.TabIndex = 48;
            this.label41.Text = "Total Boxes";
            // 
            // numericTextBox16
            // 
            this.numericTextBox16.Location = new System.Drawing.Point(312, 36);
            this.numericTextBox16.Maximum = new System.Decimal(new int[] {
                                                                             1000000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox16.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox16.Name = "numericTextBox16";
            this.numericTextBox16.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox16.TabIndex = 49;
            this.numericTextBox16.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 47;
            this.label1.Text = "Total Skids";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(104, 36);
            this.textBox5.MaxLength = 10;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(88, 20);
            this.textBox5.TabIndex = 46;
            this.textBox5.Text = "0";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 45;
            this.label4.Text = "Total Shipment";
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(104, 16);
            this.textBox21.MaxLength = 40;
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(88, 20);
            this.textBox21.TabIndex = 44;
            this.textBox21.Text = "0";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(312, 16);
            this.textBox22.MaxLength = 20;
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(88, 20);
            this.textBox22.TabIndex = 46;
            this.textBox22.Text = "0";
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(432, 40);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(64, 16);
            this.label42.TabIndex = 24;
            this.label42.Text = "Total Bols";
            // 
            // numericTextBox15
            // 
            this.numericTextBox15.Location = new System.Drawing.Point(496, 36);
            this.numericTextBox15.Maximum = new System.Decimal(new int[] {
                                                                             1000000000,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox15.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox15.Name = "numericTextBox15";
            this.numericTextBox15.Size = new System.Drawing.Size(88, 20);
            this.numericTextBox15.TabIndex = 25;
            this.numericTextBox15.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(224, 20);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(80, 16);
            this.label43.TabIndex = 47;
            this.label43.Text = "Total Pack Slip ";
            // 
            // dGridShipTo
            // 
            this.dGridShipTo.DataMember = "";
            this.dGridShipTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dGridShipTo.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridShipTo.Location = new System.Drawing.Point(8, 96);
            this.dGridShipTo.Name = "dGridShipTo";
            this.dGridShipTo.Size = new System.Drawing.Size(760, 240);
            this.dGridShipTo.TabIndex = 0;
            // 
            // tabPageSalesCode
            // 
            this.tabPageSalesCode.Controls.Add(this.gBoxComm);
            this.tabPageSalesCode.Controls.Add(this.lIHDealerSalesRep);
            this.tabPageSalesCode.Controls.Add(this.tBoxIH_DealerSalesRep);
            this.tabPageSalesCode.Controls.Add(this.lIHDealer);
            this.tabPageSalesCode.Controls.Add(this.tBoxIH_Dealer);
            this.tabPageSalesCode.Controls.Add(this.groupBox4);
            this.tabPageSalesCode.Location = new System.Drawing.Point(4, 22);
            this.tabPageSalesCode.Name = "tabPageSalesCode";
            this.tabPageSalesCode.Size = new System.Drawing.Size(800, 406);
            this.tabPageSalesCode.TabIndex = 7;
            this.tabPageSalesCode.Text = "Sales Code";
            // 
            // gBoxComm
            // 
            this.gBoxComm.Controls.Add(this.tBoxIH_SalesPer);
            this.gBoxComm.Controls.Add(this.tBoxSalesPesonName);
            this.gBoxComm.Controls.Add(this.btnSchSalesPerson);
            this.gBoxComm.Controls.Add(this.lIHSalesPer);
            this.gBoxComm.Controls.Add(this.dGridComm);
            this.gBoxComm.Location = new System.Drawing.Point(8, 200);
            this.gBoxComm.Name = "gBoxComm";
            this.gBoxComm.Size = new System.Drawing.Size(784, 200);
            this.gBoxComm.TabIndex = 75;
            this.gBoxComm.TabStop = false;
            this.gBoxComm.Text = "Commission";
            // 
            // tBoxIH_SalesPer
            // 
            this.tBoxIH_SalesPer.Location = new System.Drawing.Point(112, 16);
            this.tBoxIH_SalesPer.MaxLength = 10;
            this.tBoxIH_SalesPer.Name = "tBoxIH_SalesPer";
            this.tBoxIH_SalesPer.Size = new System.Drawing.Size(72, 20);
            this.tBoxIH_SalesPer.TabIndex = 72;
            this.tBoxIH_SalesPer.Text = "";
            // 
            // tBoxSalesPesonName
            // 
            this.tBoxSalesPesonName.Location = new System.Drawing.Point(192, 16);
            this.tBoxSalesPesonName.MaxLength = 50;
            this.tBoxSalesPesonName.Name = "tBoxSalesPesonName";
            this.tBoxSalesPesonName.ReadOnly = true;
            this.tBoxSalesPesonName.Size = new System.Drawing.Size(200, 20);
            this.tBoxSalesPesonName.TabIndex = 73;
            this.tBoxSalesPesonName.Text = "";
            // 
            // btnSchSalesPerson
            // 
            this.btnSchSalesPerson.Location = new System.Drawing.Point(400, 16);
            this.btnSchSalesPerson.Name = "btnSchSalesPerson";
            this.btnSchSalesPerson.Size = new System.Drawing.Size(30, 16);
            this.btnSchSalesPerson.TabIndex = 74;
            this.btnSchSalesPerson.Text = "...";
            // 
            // lIHSalesPer
            // 
            this.lIHSalesPer.Location = new System.Drawing.Point(24, 16);
            this.lIHSalesPer.Name = "lIHSalesPer";
            this.lIHSalesPer.Size = new System.Drawing.Size(80, 16);
            this.lIHSalesPer.TabIndex = 71;
            this.lIHSalesPer.Text = "Sales Person";
            // 
            // dGridComm
            // 
            this.dGridComm.DataMember = "";
            this.dGridComm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dGridComm.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridComm.Location = new System.Drawing.Point(12, 40);
            this.dGridComm.Name = "dGridComm";
            this.dGridComm.Size = new System.Drawing.Size(764, 152);
            this.dGridComm.TabIndex = 1;
            // 
            // lIHDealerSalesRep
            // 
            this.lIHDealerSalesRep.Location = new System.Drawing.Point(232, 12);
            this.lIHDealerSalesRep.Name = "lIHDealerSalesRep";
            this.lIHDealerSalesRep.Size = new System.Drawing.Size(72, 16);
            this.lIHDealerSalesRep.TabIndex = 72;
            this.lIHDealerSalesRep.Text = "Sales Rep";
            // 
            // tBoxIH_DealerSalesRep
            // 
            this.tBoxIH_DealerSalesRep.Location = new System.Drawing.Point(304, 8);
            this.tBoxIH_DealerSalesRep.MaxLength = 10;
            this.tBoxIH_DealerSalesRep.Name = "tBoxIH_DealerSalesRep";
            this.tBoxIH_DealerSalesRep.Size = new System.Drawing.Size(80, 20);
            this.tBoxIH_DealerSalesRep.TabIndex = 71;
            this.tBoxIH_DealerSalesRep.Text = "";
            // 
            // lIHDealer
            // 
            this.lIHDealer.Location = new System.Drawing.Point(96, 12);
            this.lIHDealer.Name = "lIHDealer";
            this.lIHDealer.Size = new System.Drawing.Size(40, 16);
            this.lIHDealer.TabIndex = 70;
            this.lIHDealer.Text = "Dealer";
            // 
            // tBoxIH_Dealer
            // 
            this.tBoxIH_Dealer.Location = new System.Drawing.Point(144, 8);
            this.tBoxIH_Dealer.MaxLength = 10;
            this.tBoxIH_Dealer.Name = "tBoxIH_Dealer";
            this.tBoxIH_Dealer.Size = new System.Drawing.Size(80, 20);
            this.tBoxIH_Dealer.TabIndex = 69;
            this.tBoxIH_Dealer.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dGridSalesCode);
            this.groupBox4.Location = new System.Drawing.Point(8, 32);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(784, 168);
            this.groupBox4.TabIndex = 68;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sales Code";
            // 
            // dGridSalesCode
            // 
            this.dGridSalesCode.DataMember = "";
            this.dGridSalesCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dGridSalesCode.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridSalesCode.Location = new System.Drawing.Point(16, 16);
            this.dGridSalesCode.Name = "dGridSalesCode";
            this.dGridSalesCode.Size = new System.Drawing.Size(760, 144);
            this.dGridSalesCode.TabIndex = 0;
            // 
            // tabPageDiscounts
            // 
            this.tabPageDiscounts.Controls.Add(this.groupBox2);
            this.tabPageDiscounts.Location = new System.Drawing.Point(4, 22);
            this.tabPageDiscounts.Name = "tabPageDiscounts";
            this.tabPageDiscounts.Size = new System.Drawing.Size(800, 406);
            this.tabPageDiscounts.TabIndex = 8;
            this.tabPageDiscounts.Text = "Discounts";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonAddDiscGroup);
            this.groupBox2.Controls.Add(this.buttonAddDiscount);
            this.groupBox2.Controls.Add(this.buttonRemoveItem);
            this.groupBox2.Controls.Add(this.buttonEditItem);
            this.groupBox2.Controls.Add(this.buttonAddItem);
            this.groupBox2.Controls.Add(this.groupBox13);
            this.groupBox2.Controls.Add(this.dGridDiscounts);
            this.groupBox2.Location = new System.Drawing.Point(16, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 384);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            // 
            // buttonAddDiscGroup
            // 
            this.buttonAddDiscGroup.Location = new System.Drawing.Point(120, 336);
            this.buttonAddDiscGroup.Name = "buttonAddDiscGroup";
            this.buttonAddDiscGroup.Size = new System.Drawing.Size(96, 23);
            this.buttonAddDiscGroup.TabIndex = 142;
            this.buttonAddDiscGroup.Text = "Add Disc. Group";
            this.buttonAddDiscGroup.Click += new System.EventHandler(this.buttonAddDiscGroup_Click);
            // 
            // buttonAddDiscount
            // 
            this.buttonAddDiscount.Location = new System.Drawing.Point(32, 336);
            this.buttonAddDiscount.Name = "buttonAddDiscount";
            this.buttonAddDiscount.Size = new System.Drawing.Size(80, 23);
            this.buttonAddDiscount.TabIndex = 141;
            this.buttonAddDiscount.Text = "Add Discount";
            this.buttonAddDiscount.Click += new System.EventHandler(this.buttonAddDiscount_Click);
            // 
            // buttonRemoveItem
            // 
            this.buttonRemoveItem.Location = new System.Drawing.Point(672, 336);
            this.buttonRemoveItem.Name = "buttonRemoveItem";
            this.buttonRemoveItem.TabIndex = 140;
            this.buttonRemoveItem.Text = "Remove";
            // 
            // buttonEditItem
            // 
            this.buttonEditItem.Location = new System.Drawing.Point(584, 336);
            this.buttonEditItem.Name = "buttonEditItem";
            this.buttonEditItem.TabIndex = 139;
            this.buttonEditItem.Text = "Edit";
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Location = new System.Drawing.Point(496, 336);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.TabIndex = 138;
            this.buttonAddItem.Text = "Add ";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.numericTextBox17);
            this.groupBox13.Controls.Add(this.label44);
            this.groupBox13.Controls.Add(this.numericTextBox19);
            this.groupBox13.Controls.Add(this.lIHDiscountTot);
            this.groupBox13.Controls.Add(this.ntbIH_DiscountTot);
            this.groupBox13.Controls.Add(this.label49);
            this.groupBox13.Location = new System.Drawing.Point(32, 16);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(720, 100);
            this.groupBox13.TabIndex = 42;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Discounts Header";
            // 
            // numericTextBox17
            // 
            this.numericTextBox17.Location = new System.Drawing.Point(168, 44);
            this.numericTextBox17.Maximum = new System.Decimal(new int[] {
                                                                             -727379969,
                                                                             232,
                                                                             0,
                                                                             0});
            this.numericTextBox17.MaxPrecision = 2;
            this.numericTextBox17.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox17.Name = "numericTextBox17";
            this.numericTextBox17.Size = new System.Drawing.Size(92, 20);
            this.numericTextBox17.TabIndex = 37;
            this.numericTextBox17.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(40, 48);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(120, 16);
            this.label44.TabIndex = 36;
            this.label44.Text = "Invoice Amt w/o Taxes";
            // 
            // numericTextBox19
            // 
            this.numericTextBox19.Location = new System.Drawing.Point(168, 64);
            this.numericTextBox19.Maximum = new System.Decimal(new int[] {
                                                                             -727379969,
                                                                             232,
                                                                             0,
                                                                             0});
            this.numericTextBox19.MaxPrecision = 2;
            this.numericTextBox19.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox19.Name = "numericTextBox19";
            this.numericTextBox19.Size = new System.Drawing.Size(92, 20);
            this.numericTextBox19.TabIndex = 41;
            this.numericTextBox19.Value = new System.Decimal(new int[] {
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
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(40, 68);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(136, 16);
            this.label49.TabIndex = 40;
            this.label49.Text = "Overall Discount Savings";
            // 
            // dGridDiscounts
            // 
            this.dGridDiscounts.DataMember = "";
            this.dGridDiscounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dGridDiscounts.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridDiscounts.Location = new System.Drawing.Point(32, 120);
            this.dGridDiscounts.Name = "dGridDiscounts";
            this.dGridDiscounts.Size = new System.Drawing.Size(720, 208);
            this.dGridDiscounts.TabIndex = 35;
            // 
            // tabPageChaRetCom
            // 
            this.tabPageChaRetCom.Controls.Add(this.groupBox8);
            this.tabPageChaRetCom.Location = new System.Drawing.Point(4, 22);
            this.tabPageChaRetCom.Name = "tabPageChaRetCom";
            this.tabPageChaRetCom.Size = new System.Drawing.Size(800, 406);
            this.tabPageChaRetCom.TabIndex = 10;
            this.tabPageChaRetCom.Text = "Charges/Ret/Comp.";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.dGridPRC);
            this.groupBox8.Location = new System.Drawing.Point(16, 8);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(776, 384);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            // 
            // dGridPRC
            // 
            this.dGridPRC.DataMember = "";
            this.dGridPRC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dGridPRC.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridPRC.Location = new System.Drawing.Point(24, 24);
            this.dGridPRC.Name = "dGridPRC";
            this.dGridPRC.Size = new System.Drawing.Size(728, 344);
            this.dGridPRC.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dGridAccFrDis);
            this.tabPage1.Controls.Add(this.lIH_Warehouse);
            this.tabPage1.Controls.Add(this.tBoxIH_WareHouse);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.gBoxPayment);
            this.tabPage1.Controls.Add(this.ntbIH_OrderNumber);
            this.tabPage1.Controls.Add(this.lIHOrderNum);
            this.tabPage1.Controls.Add(this.lIHQuoteNum);
            this.tabPage1.Controls.Add(this.tBoxIH_QuoteNum);
            this.tabPage1.Controls.Add(this.gboxInfo);
            this.tabPage1.Controls.Add(this.gBoxXhargesCalculated);
            this.tabPage1.Controls.Add(this.gBoxPosted);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(800, 406);
            this.tabPage1.TabIndex = 12;
            this.tabPage1.Text = "Trash";
            // 
            // dGridAccFrDis
            // 
            this.dGridAccFrDis.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dGridAccFrDis.DataMember = "";
            this.dGridAccFrDis.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dGridAccFrDis.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridAccFrDis.Location = new System.Drawing.Point(40, 296);
            this.dGridAccFrDis.Name = "dGridAccFrDis";
            this.dGridAccFrDis.Size = new System.Drawing.Size(208, 72);
            this.dGridAccFrDis.TabIndex = 77;
            // 
            // lIH_Warehouse
            // 
            this.lIH_Warehouse.Location = new System.Drawing.Point(648, 80);
            this.lIH_Warehouse.Name = "lIH_Warehouse";
            this.lIH_Warehouse.Size = new System.Drawing.Size(72, 16);
            this.lIH_Warehouse.TabIndex = 76;
            this.lIH_Warehouse.Text = "WareHouse";
            // 
            // tBoxIH_WareHouse
            // 
            this.tBoxIH_WareHouse.Location = new System.Drawing.Point(672, 96);
            this.tBoxIH_WareHouse.MaxLength = 10;
            this.tBoxIH_WareHouse.Name = "tBoxIH_WareHouse";
            this.tBoxIH_WareHouse.Size = new System.Drawing.Size(80, 20);
            this.tBoxIH_WareHouse.TabIndex = 75;
            this.tBoxIH_WareHouse.Text = "";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dtpIH_ShipDate);
            this.groupBox7.Controls.Add(this.lIHFobPoint);
            this.groupBox7.Controls.Add(this.tBoxIh_FobPoint);
            this.groupBox7.Controls.Add(this.lShipToVia);
            this.groupBox7.Controls.Add(this.tBoxIH_ShipToVia);
            this.groupBox7.Controls.Add(this.lIHShipDate);
            this.groupBox7.Controls.Add(this.tBoxIH_PackSlipNum);
            this.groupBox7.Controls.Add(this.lIHBolNumber);
            this.groupBox7.Controls.Add(this.ntbIH_BolNumber);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Location = new System.Drawing.Point(8, 144);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(648, 72);
            this.groupBox7.TabIndex = 73;
            this.groupBox7.TabStop = false;
            // 
            // dtpIH_ShipDate
            // 
            this.dtpIH_ShipDate.Location = new System.Drawing.Point(72, 40);
            this.dtpIH_ShipDate.Name = "dtpIH_ShipDate";
            this.dtpIH_ShipDate.Size = new System.Drawing.Size(104, 20);
            this.dtpIH_ShipDate.TabIndex = 24;
            // 
            // lIHFobPoint
            // 
            this.lIHFobPoint.Location = new System.Drawing.Point(408, 16);
            this.lIHFobPoint.Name = "lIHFobPoint";
            this.lIHFobPoint.Size = new System.Drawing.Size(64, 16);
            this.lIHFobPoint.TabIndex = 47;
            this.lIHFobPoint.Text = "Fob Point";
            // 
            // tBoxIh_FobPoint
            // 
            this.tBoxIh_FobPoint.Location = new System.Drawing.Point(480, 16);
            this.tBoxIh_FobPoint.MaxLength = 10;
            this.tBoxIh_FobPoint.Name = "tBoxIh_FobPoint";
            this.tBoxIh_FobPoint.Size = new System.Drawing.Size(88, 20);
            this.tBoxIh_FobPoint.TabIndex = 46;
            this.tBoxIh_FobPoint.Text = "";
            // 
            // lShipToVia
            // 
            this.lShipToVia.Location = new System.Drawing.Point(8, 16);
            this.lShipToVia.Name = "lShipToVia";
            this.lShipToVia.Size = new System.Drawing.Size(64, 16);
            this.lShipToVia.TabIndex = 45;
            this.lShipToVia.Text = "Ship To Via";
            // 
            // tBoxIH_ShipToVia
            // 
            this.tBoxIH_ShipToVia.Location = new System.Drawing.Point(72, 16);
            this.tBoxIH_ShipToVia.MaxLength = 40;
            this.tBoxIH_ShipToVia.Name = "tBoxIH_ShipToVia";
            this.tBoxIH_ShipToVia.Size = new System.Drawing.Size(248, 20);
            this.tBoxIH_ShipToVia.TabIndex = 44;
            this.tBoxIH_ShipToVia.Text = "";
            // 
            // lIHShipDate
            // 
            this.lIHShipDate.Location = new System.Drawing.Point(8, 40);
            this.lIHShipDate.Name = "lIHShipDate";
            this.lIHShipDate.Size = new System.Drawing.Size(56, 16);
            this.lIHShipDate.TabIndex = 25;
            this.lIHShipDate.Text = "Ship Date";
            // 
            // tBoxIH_PackSlipNum
            // 
            this.tBoxIH_PackSlipNum.Location = new System.Drawing.Point(264, 40);
            this.tBoxIH_PackSlipNum.MaxLength = 20;
            this.tBoxIH_PackSlipNum.Name = "tBoxIH_PackSlipNum";
            this.tBoxIH_PackSlipNum.Size = new System.Drawing.Size(152, 20);
            this.tBoxIH_PackSlipNum.TabIndex = 46;
            this.tBoxIH_PackSlipNum.Text = "";
            // 
            // lIHBolNumber
            // 
            this.lIHBolNumber.Location = new System.Drawing.Point(432, 40);
            this.lIHBolNumber.Name = "lIHBolNumber";
            this.lIHBolNumber.Size = new System.Drawing.Size(40, 16);
            this.lIHBolNumber.TabIndex = 24;
            this.lIHBolNumber.Text = "Bol #";
            // 
            // ntbIH_BolNumber
            // 
            this.ntbIH_BolNumber.Location = new System.Drawing.Point(480, 40);
            this.ntbIH_BolNumber.Maximum = new System.Decimal(new int[] {
                                                                            1000000000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.ntbIH_BolNumber.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.ntbIH_BolNumber.Name = "ntbIH_BolNumber";
            this.ntbIH_BolNumber.Size = new System.Drawing.Size(88, 20);
            this.ntbIH_BolNumber.TabIndex = 25;
            this.ntbIH_BolNumber.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(192, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 47;
            this.label3.Text = "Pack Slip #";
            // 
            // gBoxPayment
            // 
            this.gBoxPayment.Controls.Add(this.label2);
            this.gBoxPayment.Controls.Add(this.tBoxIH_PaymentsMethod);
            this.gBoxPayment.Controls.Add(this.tBoxPayTypeDesc);
            this.gBoxPayment.Controls.Add(this.lIHPayTerms);
            this.gBoxPayment.Controls.Add(this.tBoxIH_PayTerms);
            this.gBoxPayment.Controls.Add(this.lIHPayType);
            this.gBoxPayment.Controls.Add(this.textBox3);
            this.gBoxPayment.Controls.Add(this.btnSchPayType);
            this.gBoxPayment.Controls.Add(this.ntbIH_BalanceReturn);
            this.gBoxPayment.Controls.Add(this.lIH_BalanceReturn);
            this.gBoxPayment.Controls.Add(this.ntbIH_Balance);
            this.gBoxPayment.Controls.Add(this.lIH_Balance);
            this.gBoxPayment.Location = new System.Drawing.Point(8, 72);
            this.gBoxPayment.Name = "gBoxPayment";
            this.gBoxPayment.Size = new System.Drawing.Size(640, 64);
            this.gBoxPayment.TabIndex = 71;
            this.gBoxPayment.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(168, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 51;
            this.label2.Text = "Method";
            // 
            // tBoxIH_PaymentsMethod
            // 
            this.tBoxIH_PaymentsMethod.Location = new System.Drawing.Point(216, 16);
            this.tBoxIH_PaymentsMethod.MaxLength = 10;
            this.tBoxIH_PaymentsMethod.Name = "tBoxIH_PaymentsMethod";
            this.tBoxIH_PaymentsMethod.Size = new System.Drawing.Size(80, 20);
            this.tBoxIH_PaymentsMethod.TabIndex = 50;
            this.tBoxIH_PaymentsMethod.Text = "";
            // 
            // tBoxPayTypeDesc
            // 
            this.tBoxPayTypeDesc.Location = new System.Drawing.Point(464, 16);
            this.tBoxPayTypeDesc.MaxLength = 10;
            this.tBoxPayTypeDesc.Name = "tBoxPayTypeDesc";
            this.tBoxPayTypeDesc.ReadOnly = true;
            this.tBoxPayTypeDesc.Size = new System.Drawing.Size(96, 20);
            this.tBoxPayTypeDesc.TabIndex = 49;
            this.tBoxPayTypeDesc.Text = "";
            // 
            // lIHPayTerms
            // 
            this.lIHPayTerms.Location = new System.Drawing.Point(16, 16);
            this.lIHPayTerms.Name = "lIHPayTerms";
            this.lIHPayTerms.Size = new System.Drawing.Size(64, 16);
            this.lIHPayTerms.TabIndex = 47;
            this.lIHPayTerms.Text = "Terms";
            // 
            // tBoxIH_PayTerms
            // 
            this.tBoxIH_PayTerms.Location = new System.Drawing.Point(80, 16);
            this.tBoxIH_PayTerms.MaxLength = 10;
            this.tBoxIH_PayTerms.Name = "tBoxIH_PayTerms";
            this.tBoxIH_PayTerms.Size = new System.Drawing.Size(80, 20);
            this.tBoxIH_PayTerms.TabIndex = 46;
            this.tBoxIH_PayTerms.Text = "";
            // 
            // lIHPayType
            // 
            this.lIHPayType.Location = new System.Drawing.Point(320, 16);
            this.lIHPayType.Name = "lIHPayType";
            this.lIHPayType.Size = new System.Drawing.Size(64, 16);
            this.lIHPayType.TabIndex = 44;
            this.lIHPayType.Text = "Type";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(384, 16);
            this.textBox3.MaxLength = 10;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(72, 20);
            this.textBox3.TabIndex = 43;
            this.textBox3.Text = "";
            // 
            // btnSchPayType
            // 
            this.btnSchPayType.Location = new System.Drawing.Point(576, 16);
            this.btnSchPayType.Name = "btnSchPayType";
            this.btnSchPayType.Size = new System.Drawing.Size(30, 16);
            this.btnSchPayType.TabIndex = 45;
            this.btnSchPayType.Text = "...";
            // 
            // ntbIH_BalanceReturn
            // 
            this.ntbIH_BalanceReturn.Location = new System.Drawing.Point(104, 40);
            this.ntbIH_BalanceReturn.Maximum = new System.Decimal(new int[] {
                                                                                1316134912,
                                                                                2328,
                                                                                0,
                                                                                0});
            this.ntbIH_BalanceReturn.MaxPrecision = 2;
            this.ntbIH_BalanceReturn.Minimum = new System.Decimal(new int[] {
                                                                                0,
                                                                                0,
                                                                                0,
                                                                                0});
            this.ntbIH_BalanceReturn.Name = "ntbIH_BalanceReturn";
            this.ntbIH_BalanceReturn.Size = new System.Drawing.Size(120, 20);
            this.ntbIH_BalanceReturn.TabIndex = 28;
            this.ntbIH_BalanceReturn.Value = new System.Decimal(new int[] {
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0});
            // 
            // lIH_BalanceReturn
            // 
            this.lIH_BalanceReturn.Location = new System.Drawing.Point(8, 40);
            this.lIH_BalanceReturn.Name = "lIH_BalanceReturn";
            this.lIH_BalanceReturn.Size = new System.Drawing.Size(88, 16);
            this.lIH_BalanceReturn.TabIndex = 27;
            this.lIH_BalanceReturn.Text = "Balance Return";
            // 
            // ntbIH_Balance
            // 
            this.ntbIH_Balance.Location = new System.Drawing.Point(352, 40);
            this.ntbIH_Balance.Maximum = new System.Decimal(new int[] {
                                                                          -727379968,
                                                                          232,
                                                                          0,
                                                                          0});
            this.ntbIH_Balance.MaxPrecision = 2;
            this.ntbIH_Balance.Minimum = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            this.ntbIH_Balance.Name = "ntbIH_Balance";
            this.ntbIH_Balance.Size = new System.Drawing.Size(120, 20);
            this.ntbIH_Balance.TabIndex = 30;
            this.ntbIH_Balance.Value = new System.Decimal(new int[] {
                                                                        0,
                                                                        0,
                                                                        0,
                                                                        0});
            // 
            // lIH_Balance
            // 
            this.lIH_Balance.Location = new System.Drawing.Point(264, 40);
            this.lIH_Balance.Name = "lIH_Balance";
            this.lIH_Balance.Size = new System.Drawing.Size(80, 16);
            this.lIH_Balance.TabIndex = 29;
            this.lIH_Balance.Text = "Balance ";
            // 
            // ntbIH_OrderNumber
            // 
            this.ntbIH_OrderNumber.Location = new System.Drawing.Point(328, 16);
            this.ntbIH_OrderNumber.Maximum = new System.Decimal(new int[] {
                                                                              1410065408,
                                                                              2,
                                                                              0,
                                                                              0});
            this.ntbIH_OrderNumber.Minimum = new System.Decimal(new int[] {
                                                                              0,
                                                                              0,
                                                                              0,
                                                                              0});
            this.ntbIH_OrderNumber.Name = "ntbIH_OrderNumber";
            this.ntbIH_OrderNumber.Size = new System.Drawing.Size(40, 20);
            this.ntbIH_OrderNumber.TabIndex = 68;
            this.ntbIH_OrderNumber.Value = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            // 
            // lIHOrderNum
            // 
            this.lIHOrderNum.Location = new System.Drawing.Point(264, 16);
            this.lIHOrderNum.Name = "lIHOrderNum";
            this.lIHOrderNum.Size = new System.Drawing.Size(56, 16);
            this.lIHOrderNum.TabIndex = 67;
            this.lIHOrderNum.Text = "Order #";
            // 
            // lIHQuoteNum
            // 
            this.lIHQuoteNum.Location = new System.Drawing.Point(264, 40);
            this.lIHQuoteNum.Name = "lIHQuoteNum";
            this.lIHQuoteNum.Size = new System.Drawing.Size(56, 16);
            this.lIHQuoteNum.TabIndex = 70;
            this.lIHQuoteNum.Text = "Quote #";
            // 
            // tBoxIH_QuoteNum
            // 
            this.tBoxIH_QuoteNum.Location = new System.Drawing.Point(328, 40);
            this.tBoxIH_QuoteNum.MaxLength = 20;
            this.tBoxIH_QuoteNum.Name = "tBoxIH_QuoteNum";
            this.tBoxIH_QuoteNum.Size = new System.Drawing.Size(40, 20);
            this.tBoxIH_QuoteNum.TabIndex = 69;
            this.tBoxIH_QuoteNum.Text = "";
            // 
            // gboxInfo
            // 
            this.gboxInfo.Controls.Add(this.dtpIHDateUpdated);
            this.gboxInfo.Controls.Add(this.lIHDateUpdated);
            this.gboxInfo.Controls.Add(this.dtpIHDateCreated);
            this.gboxInfo.Controls.Add(this.lIHDateCreated);
            this.gboxInfo.Controls.Add(this.tBoxIH_UserId);
            this.gboxInfo.Controls.Add(this.lIHUserId);
            this.gboxInfo.Location = new System.Drawing.Point(384, 16);
            this.gboxInfo.Name = "gboxInfo";
            this.gboxInfo.Size = new System.Drawing.Size(424, 48);
            this.gboxInfo.TabIndex = 66;
            this.gboxInfo.TabStop = false;
            // 
            // dtpIHDateUpdated
            // 
            this.dtpIHDateUpdated.Location = new System.Drawing.Point(328, 16);
            this.dtpIHDateUpdated.Name = "dtpIHDateUpdated";
            this.dtpIHDateUpdated.Size = new System.Drawing.Size(88, 20);
            this.dtpIHDateUpdated.TabIndex = 20;
            // 
            // lIHDateUpdated
            // 
            this.lIHDateUpdated.Location = new System.Drawing.Point(280, 16);
            this.lIHDateUpdated.Name = "lIHDateUpdated";
            this.lIHDateUpdated.Size = new System.Drawing.Size(48, 16);
            this.lIHDateUpdated.TabIndex = 21;
            this.lIHDateUpdated.Text = "Updated";
            // 
            // dtpIHDateCreated
            // 
            this.dtpIHDateCreated.Location = new System.Drawing.Point(184, 16);
            this.dtpIHDateCreated.Name = "dtpIHDateCreated";
            this.dtpIHDateCreated.Size = new System.Drawing.Size(88, 20);
            this.dtpIHDateCreated.TabIndex = 18;
            // 
            // lIHDateCreated
            // 
            this.lIHDateCreated.Location = new System.Drawing.Point(136, 16);
            this.lIHDateCreated.Name = "lIHDateCreated";
            this.lIHDateCreated.Size = new System.Drawing.Size(72, 16);
            this.lIHDateCreated.TabIndex = 19;
            this.lIHDateCreated.Text = "Created";
            // 
            // tBoxIH_UserId
            // 
            this.tBoxIH_UserId.Location = new System.Drawing.Point(56, 16);
            this.tBoxIH_UserId.Name = "tBoxIH_UserId";
            this.tBoxIH_UserId.ReadOnly = true;
            this.tBoxIH_UserId.Size = new System.Drawing.Size(72, 20);
            this.tBoxIH_UserId.TabIndex = 25;
            this.tBoxIH_UserId.Text = "";
            // 
            // lIHUserId
            // 
            this.lIHUserId.Location = new System.Drawing.Point(8, 16);
            this.lIHUserId.Name = "lIHUserId";
            this.lIHUserId.Size = new System.Drawing.Size(56, 16);
            this.lIHUserId.TabIndex = 26;
            this.lIHUserId.Text = "User Id";
            // 
            // gBoxXhargesCalculated
            // 
            this.gBoxXhargesCalculated.Controls.Add(this.rbtnIH_ChargesCalculatedNo);
            this.gBoxXhargesCalculated.Controls.Add(this.rbtnIH_ChargesCalculatedYes);
            this.gBoxXhargesCalculated.Location = new System.Drawing.Point(8, 16);
            this.gBoxXhargesCalculated.Name = "gBoxXhargesCalculated";
            this.gBoxXhargesCalculated.Size = new System.Drawing.Size(112, 40);
            this.gBoxXhargesCalculated.TabIndex = 65;
            this.gBoxXhargesCalculated.TabStop = false;
            this.gBoxXhargesCalculated.Text = "Charges Calculated";
            // 
            // rbtnIH_ChargesCalculatedNo
            // 
            this.rbtnIH_ChargesCalculatedNo.Location = new System.Drawing.Point(56, 16);
            this.rbtnIH_ChargesCalculatedNo.Name = "rbtnIH_ChargesCalculatedNo";
            this.rbtnIH_ChargesCalculatedNo.Size = new System.Drawing.Size(48, 16);
            this.rbtnIH_ChargesCalculatedNo.TabIndex = 1;
            this.rbtnIH_ChargesCalculatedNo.Text = "No";
            // 
            // rbtnIH_ChargesCalculatedYes
            // 
            this.rbtnIH_ChargesCalculatedYes.Checked = true;
            this.rbtnIH_ChargesCalculatedYes.Location = new System.Drawing.Point(16, 16);
            this.rbtnIH_ChargesCalculatedYes.Name = "rbtnIH_ChargesCalculatedYes";
            this.rbtnIH_ChargesCalculatedYes.Size = new System.Drawing.Size(48, 16);
            this.rbtnIH_ChargesCalculatedYes.TabIndex = 0;
            this.rbtnIH_ChargesCalculatedYes.TabStop = true;
            this.rbtnIH_ChargesCalculatedYes.Text = "Yes";
            // 
            // gBoxPosted
            // 
            this.gBoxPosted.Controls.Add(this.rbtnIH_PostedNo);
            this.gBoxPosted.Controls.Add(this.rbtnIH_PostedYes);
            this.gBoxPosted.Location = new System.Drawing.Point(128, 16);
            this.gBoxPosted.Name = "gBoxPosted";
            this.gBoxPosted.Size = new System.Drawing.Size(120, 48);
            this.gBoxPosted.TabIndex = 64;
            this.gBoxPosted.TabStop = false;
            this.gBoxPosted.Text = "Posted";
            // 
            // rbtnIH_PostedNo
            // 
            this.rbtnIH_PostedNo.Location = new System.Drawing.Point(64, 16);
            this.rbtnIH_PostedNo.Name = "rbtnIH_PostedNo";
            this.rbtnIH_PostedNo.Size = new System.Drawing.Size(48, 16);
            this.rbtnIH_PostedNo.TabIndex = 1;
            this.rbtnIH_PostedNo.Text = "No";
            // 
            // rbtnIH_PostedYes
            // 
            this.rbtnIH_PostedYes.Checked = true;
            this.rbtnIH_PostedYes.Location = new System.Drawing.Point(16, 16);
            this.rbtnIH_PostedYes.Name = "rbtnIH_PostedYes";
            this.rbtnIH_PostedYes.Size = new System.Drawing.Size(48, 16);
            this.rbtnIH_PostedYes.TabIndex = 0;
            this.rbtnIH_PostedYes.TabStop = true;
            this.rbtnIH_PostedYes.Text = "Yes";
            // 
            // tabPagePayment
            // 
            this.tabPagePayment.Controls.Add(this.groupBox10);
            this.tabPagePayment.Location = new System.Drawing.Point(4, 22);
            this.tabPagePayment.Name = "tabPagePayment";
            this.tabPagePayment.Size = new System.Drawing.Size(800, 406);
            this.tabPagePayment.TabIndex = 4;
            this.tabPagePayment.Text = "Payment";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label58);
            this.groupBox10.Controls.Add(this.textBox32);
            this.groupBox10.Controls.Add(this.button3);
            this.groupBox10.Controls.Add(this.btnAddPayment);
            this.groupBox10.Controls.Add(this.dGridPayments);
            this.groupBox10.Controls.Add(this.numericTextBox14);
            this.groupBox10.Controls.Add(this.label40);
            this.groupBox10.Controls.Add(this.numericTextBox12);
            this.groupBox10.Controls.Add(this.label38);
            this.groupBox10.Controls.Add(this.label39);
            this.groupBox10.Controls.Add(this.numericTextBox13);
            this.groupBox10.Controls.Add(this.numericTextBox9);
            this.groupBox10.Controls.Add(this.label35);
            this.groupBox10.Controls.Add(this.ntbIH_ExchangeRate);
            this.groupBox10.Controls.Add(this.lIH_ExchangeRate);
            this.groupBox10.Controls.Add(this.lIHBaseCurrency);
            this.groupBox10.Controls.Add(this.tBoxIH_BaseCurrency);
            this.groupBox10.Controls.Add(this.lIH_Paid);
            this.groupBox10.Controls.Add(this.ntbIH_Refunded);
            this.groupBox10.Controls.Add(this.lIH_Refunded);
            this.groupBox10.Controls.Add(this.ntbIH_Returned);
            this.groupBox10.Controls.Add(this.lIH_Returned);
            this.groupBox10.Controls.Add(this.ntbIH_Paid);
            this.groupBox10.Controls.Add(this.numericTextBox10);
            this.groupBox10.Controls.Add(this.label36);
            this.groupBox10.Controls.Add(this.label37);
            this.groupBox10.Controls.Add(this.numericTextBox11);
            this.groupBox10.Location = new System.Drawing.Point(8, 8);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(784, 384);
            this.groupBox10.TabIndex = 73;
            this.groupBox10.TabStop = false;
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(232, 44);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(56, 16);
            this.label58.TabIndex = 83;
            this.label58.Text = "Cash";
            // 
            // textBox32
            // 
            this.textBox32.Location = new System.Drawing.Point(296, 40);
            this.textBox32.MaxLength = 5;
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new System.Drawing.Size(80, 20);
            this.textBox32.TabIndex = 82;
            this.textBox32.Text = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(696, 352);
            this.button3.Name = "button3";
            this.button3.TabIndex = 81;
            this.button3.Text = "Remove";
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.Location = new System.Drawing.Point(608, 352);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.TabIndex = 80;
            this.btnAddPayment.Text = "Add ";
            this.btnAddPayment.Click += new System.EventHandler(this.button2_Click);
            // 
            // dGridPayments
            // 
            this.dGridPayments.DataMember = "";
            this.dGridPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dGridPayments.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridPayments.Location = new System.Drawing.Point(8, 152);
            this.dGridPayments.Name = "dGridPayments";
            this.dGridPayments.Size = new System.Drawing.Size(760, 184);
            this.dGridPayments.TabIndex = 79;
            // 
            // numericTextBox14
            // 
            this.numericTextBox14.Location = new System.Drawing.Point(104, 100);
            this.numericTextBox14.Maximum = new System.Decimal(new int[] {
                                                                             1874919424,
                                                                             2328306,
                                                                             0,
                                                                             0});
            this.numericTextBox14.MaxPrecision = 2;
            this.numericTextBox14.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox14.Name = "numericTextBox14";
            this.numericTextBox14.Size = new System.Drawing.Size(120, 20);
            this.numericTextBox14.TabIndex = 78;
            this.numericTextBox14.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(16, 100);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(80, 20);
            this.label40.TabIndex = 77;
            this.label40.Text = "Amount Paid";
            // 
            // numericTextBox12
            // 
            this.numericTextBox12.Location = new System.Drawing.Point(104, 120);
            this.numericTextBox12.Maximum = new System.Decimal(new int[] {
                                                                             1874919424,
                                                                             2328306,
                                                                             0,
                                                                             0});
            this.numericTextBox12.MaxPrecision = 2;
            this.numericTextBox12.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox12.Name = "numericTextBox12";
            this.numericTextBox12.Size = new System.Drawing.Size(120, 20);
            this.numericTextBox12.TabIndex = 74;
            this.numericTextBox12.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(16, 120);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(96, 20);
            this.label38.TabIndex = 73;
            this.label38.Text = "Amount Owed";
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(232, 120);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(64, 20);
            this.label39.TabIndex = 75;
            this.label39.Text = "On Account";
            // 
            // numericTextBox13
            // 
            this.numericTextBox13.Location = new System.Drawing.Point(328, 120);
            this.numericTextBox13.Maximum = new System.Decimal(new int[] {
                                                                             1874919424,
                                                                             2328306,
                                                                             0,
                                                                             0});
            this.numericTextBox13.MaxPrecision = 2;
            this.numericTextBox13.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox13.Name = "numericTextBox13";
            this.numericTextBox13.Size = new System.Drawing.Size(120, 20);
            this.numericTextBox13.TabIndex = 76;
            this.numericTextBox13.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // numericTextBox9
            // 
            this.numericTextBox9.Location = new System.Drawing.Point(104, 24);
            this.numericTextBox9.Maximum = new System.Decimal(new int[] {
                                                                            1874919424,
                                                                            2328306,
                                                                            0,
                                                                            0});
            this.numericTextBox9.MaxPrecision = 2;
            this.numericTextBox9.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox9.Name = "numericTextBox9";
            this.numericTextBox9.Size = new System.Drawing.Size(120, 20);
            this.numericTextBox9.TabIndex = 72;
            this.numericTextBox9.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(16, 24);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(88, 20);
            this.label35.TabIndex = 71;
            this.label35.Text = "Payment Totals";
            // 
            // ntbIH_ExchangeRate
            // 
            this.ntbIH_ExchangeRate.Location = new System.Drawing.Point(104, 44);
            this.ntbIH_ExchangeRate.Maximum = new System.Decimal(new int[] {
                                                                               1874919424,
                                                                               2328306,
                                                                               0,
                                                                               0});
            this.ntbIH_ExchangeRate.MaxPrecision = 7;
            this.ntbIH_ExchangeRate.Minimum = new System.Decimal(new int[] {
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               0});
            this.ntbIH_ExchangeRate.Name = "ntbIH_ExchangeRate";
            this.ntbIH_ExchangeRate.Size = new System.Drawing.Size(120, 20);
            this.ntbIH_ExchangeRate.TabIndex = 16;
            this.ntbIH_ExchangeRate.Value = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            // 
            // lIH_ExchangeRate
            // 
            this.lIH_ExchangeRate.Location = new System.Drawing.Point(16, 44);
            this.lIH_ExchangeRate.Name = "lIH_ExchangeRate";
            this.lIH_ExchangeRate.Size = new System.Drawing.Size(88, 20);
            this.lIH_ExchangeRate.TabIndex = 15;
            this.lIH_ExchangeRate.Text = "Exchange Rate";
            // 
            // lIHBaseCurrency
            // 
            this.lIHBaseCurrency.Location = new System.Drawing.Point(232, 24);
            this.lIHBaseCurrency.Name = "lIHBaseCurrency";
            this.lIHBaseCurrency.Size = new System.Drawing.Size(56, 16);
            this.lIHBaseCurrency.TabIndex = 41;
            this.lIHBaseCurrency.Text = "Currency";
            // 
            // tBoxIH_BaseCurrency
            // 
            this.tBoxIH_BaseCurrency.Location = new System.Drawing.Point(296, 24);
            this.tBoxIH_BaseCurrency.MaxLength = 5;
            this.tBoxIH_BaseCurrency.Name = "tBoxIH_BaseCurrency";
            this.tBoxIH_BaseCurrency.Size = new System.Drawing.Size(80, 20);
            this.tBoxIH_BaseCurrency.TabIndex = 40;
            this.tBoxIH_BaseCurrency.Text = "";
            // 
            // lIH_Paid
            // 
            this.lIH_Paid.Location = new System.Drawing.Point(232, 80);
            this.lIH_Paid.Name = "lIH_Paid";
            this.lIH_Paid.Size = new System.Drawing.Size(80, 20);
            this.lIH_Paid.TabIndex = 21;
            this.lIH_Paid.Text = "Amount Paid";
            // 
            // ntbIH_Refunded
            // 
            this.ntbIH_Refunded.Location = new System.Drawing.Point(544, 80);
            this.ntbIH_Refunded.Maximum = new System.Decimal(new int[] {
                                                                           1874919424,
                                                                           2328306,
                                                                           0,
                                                                           0});
            this.ntbIH_Refunded.MaxPrecision = 2;
            this.ntbIH_Refunded.Minimum = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            this.ntbIH_Refunded.Name = "ntbIH_Refunded";
            this.ntbIH_Refunded.Size = new System.Drawing.Size(120, 20);
            this.ntbIH_Refunded.TabIndex = 26;
            this.ntbIH_Refunded.Value = new System.Decimal(new int[] {
                                                                         0,
                                                                         0,
                                                                         0,
                                                                         0});
            // 
            // lIH_Refunded
            // 
            this.lIH_Refunded.Location = new System.Drawing.Point(464, 80);
            this.lIH_Refunded.Name = "lIH_Refunded";
            this.lIH_Refunded.Size = new System.Drawing.Size(88, 20);
            this.lIH_Refunded.TabIndex = 25;
            this.lIH_Refunded.Text = "Refund Owed";
            // 
            // ntbIH_Returned
            // 
            this.ntbIH_Returned.Location = new System.Drawing.Point(328, 100);
            this.ntbIH_Returned.Maximum = new System.Decimal(new int[] {
                                                                           1874919424,
                                                                           2328306,
                                                                           0,
                                                                           0});
            this.ntbIH_Returned.MaxPrecision = 2;
            this.ntbIH_Returned.Minimum = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            this.ntbIH_Returned.Name = "ntbIH_Returned";
            this.ntbIH_Returned.Size = new System.Drawing.Size(120, 20);
            this.ntbIH_Returned.TabIndex = 24;
            this.ntbIH_Returned.Value = new System.Decimal(new int[] {
                                                                         0,
                                                                         0,
                                                                         0,
                                                                         0});
            // 
            // lIH_Returned
            // 
            this.lIH_Returned.Location = new System.Drawing.Point(232, 100);
            this.lIH_Returned.Name = "lIH_Returned";
            this.lIH_Returned.Size = new System.Drawing.Size(96, 20);
            this.lIH_Returned.TabIndex = 23;
            this.lIH_Returned.Text = "Change Returned";
            // 
            // ntbIH_Paid
            // 
            this.ntbIH_Paid.Location = new System.Drawing.Point(328, 80);
            this.ntbIH_Paid.Maximum = new System.Decimal(new int[] {
                                                                       1874919424,
                                                                       2328306,
                                                                       0,
                                                                       0});
            this.ntbIH_Paid.MaxPrecision = 2;
            this.ntbIH_Paid.Minimum = new System.Decimal(new int[] {
                                                                       0,
                                                                       0,
                                                                       0,
                                                                       0});
            this.ntbIH_Paid.Name = "ntbIH_Paid";
            this.ntbIH_Paid.Size = new System.Drawing.Size(120, 20);
            this.ntbIH_Paid.TabIndex = 22;
            this.ntbIH_Paid.Value = new System.Decimal(new int[] {
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     0});
            // 
            // numericTextBox10
            // 
            this.numericTextBox10.Location = new System.Drawing.Point(104, 80);
            this.numericTextBox10.Maximum = new System.Decimal(new int[] {
                                                                             -727379969,
                                                                             232,
                                                                             0,
                                                                             0});
            this.numericTextBox10.MaxPrecision = 2;
            this.numericTextBox10.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox10.Name = "numericTextBox10";
            this.numericTextBox10.ReadOnly = true;
            this.numericTextBox10.Size = new System.Drawing.Size(120, 20);
            this.numericTextBox10.TabIndex = 47;
            this.numericTextBox10.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(16, 80);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(80, 20);
            this.label36.TabIndex = 46;
            this.label36.Text = "Total Invoiced";
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(464, 100);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(64, 20);
            this.label37.TabIndex = 48;
            this.label37.Text = "Refunded";
            // 
            // numericTextBox11
            // 
            this.numericTextBox11.Location = new System.Drawing.Point(544, 100);
            this.numericTextBox11.Maximum = new System.Decimal(new int[] {
                                                                             1874919424,
                                                                             2328306,
                                                                             0,
                                                                             0});
            this.numericTextBox11.MaxPrecision = 2;
            this.numericTextBox11.Minimum = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            this.numericTextBox11.Name = "numericTextBox11";
            this.numericTextBox11.Size = new System.Drawing.Size(120, 20);
            this.numericTextBox11.TabIndex = 49;
            this.numericTextBox11.Value = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            // 
            // tabPageTaxes
            // 
            this.tabPageTaxes.Controls.Add(this.gBoxTaxes);
            this.tabPageTaxes.Location = new System.Drawing.Point(4, 22);
            this.tabPageTaxes.Name = "tabPageTaxes";
            this.tabPageTaxes.Size = new System.Drawing.Size(800, 406);
            this.tabPageTaxes.TabIndex = 5;
            this.tabPageTaxes.Text = "Taxes";
            // 
            // gBoxTaxes
            // 
            this.gBoxTaxes.Controls.Add(this.groupBox12);
            this.gBoxTaxes.Controls.Add(this.dGridTaxes);
            this.gBoxTaxes.Location = new System.Drawing.Point(8, 8);
            this.gBoxTaxes.Name = "gBoxTaxes";
            this.gBoxTaxes.Size = new System.Drawing.Size(784, 384);
            this.gBoxTaxes.TabIndex = 50;
            this.gBoxTaxes.TabStop = false;
            this.gBoxTaxes.Text = "Taxes";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.textBox25);
            this.groupBox12.Controls.Add(this.textBox24);
            this.groupBox12.Controls.Add(this.textBox23);
            this.groupBox12.Controls.Add(this.label47);
            this.groupBox12.Controls.Add(this.label46);
            this.groupBox12.Controls.Add(this.label45);
            this.groupBox12.Controls.Add(this.lIH_TaxTotal);
            this.groupBox12.Controls.Add(this.ntbIH_Tax1Total);
            this.groupBox12.Controls.Add(this.lIHTax1Total);
            this.groupBox12.Controls.Add(this.ntbIH_Tax2Total);
            this.groupBox12.Controls.Add(this.lIHTaxt2Total);
            this.groupBox12.Controls.Add(this.ntbIH_Tax3Total);
            this.groupBox12.Controls.Add(this.lIHTax3Total);
            this.groupBox12.Controls.Add(this.ntbIH_TaxTotal);
            this.groupBox12.Location = new System.Drawing.Point(16, 16);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(752, 104);
            this.groupBox12.TabIndex = 40;
            this.groupBox12.TabStop = false;
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(256, 56);
            this.textBox25.MaxLength = 40;
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(200, 20);
            this.textBox25.TabIndex = 45;
            this.textBox25.Text = "";
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(256, 36);
            this.textBox24.MaxLength = 40;
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(200, 20);
            this.textBox24.TabIndex = 44;
            this.textBox24.Text = "";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(256, 16);
            this.textBox23.MaxLength = 40;
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(200, 20);
            this.textBox23.TabIndex = 43;
            this.textBox23.Text = "";
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(200, 16);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(48, 20);
            this.label47.TabIndex = 42;
            this.label47.Text = "Desc";
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(200, 36);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(48, 20);
            this.label46.TabIndex = 41;
            this.label46.Text = "Desc";
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(200, 56);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(48, 20);
            this.label45.TabIndex = 40;
            this.label45.Text = "Desc";
            // 
            // lIH_TaxTotal
            // 
            this.lIH_TaxTotal.Location = new System.Drawing.Point(8, 76);
            this.lIH_TaxTotal.Name = "lIH_TaxTotal";
            this.lIH_TaxTotal.Size = new System.Drawing.Size(48, 20);
            this.lIH_TaxTotal.TabIndex = 31;
            this.lIH_TaxTotal.Text = "Total";
            // 
            // ntbIH_Tax1Total
            // 
            this.ntbIH_Tax1Total.Location = new System.Drawing.Point(56, 16);
            this.ntbIH_Tax1Total.Maximum = new System.Decimal(new int[] {
                                                                            -727379968,
                                                                            232,
                                                                            0,
                                                                            0});
            this.ntbIH_Tax1Total.MaxPrecision = 2;
            this.ntbIH_Tax1Total.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.ntbIH_Tax1Total.Name = "ntbIH_Tax1Total";
            this.ntbIH_Tax1Total.Size = new System.Drawing.Size(120, 20);
            this.ntbIH_Tax1Total.TabIndex = 38;
            this.ntbIH_Tax1Total.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // lIHTax1Total
            // 
            this.lIHTax1Total.Location = new System.Drawing.Point(8, 16);
            this.lIHTax1Total.Name = "lIHTax1Total";
            this.lIHTax1Total.Size = new System.Drawing.Size(48, 20);
            this.lIHTax1Total.TabIndex = 37;
            this.lIHTax1Total.Text = "Tax 1 ";
            // 
            // ntbIH_Tax2Total
            // 
            this.ntbIH_Tax2Total.Location = new System.Drawing.Point(56, 36);
            this.ntbIH_Tax2Total.Maximum = new System.Decimal(new int[] {
                                                                            -727379968,
                                                                            232,
                                                                            0,
                                                                            0});
            this.ntbIH_Tax2Total.MaxPrecision = 2;
            this.ntbIH_Tax2Total.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.ntbIH_Tax2Total.Name = "ntbIH_Tax2Total";
            this.ntbIH_Tax2Total.Size = new System.Drawing.Size(120, 20);
            this.ntbIH_Tax2Total.TabIndex = 36;
            this.ntbIH_Tax2Total.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // lIHTaxt2Total
            // 
            this.lIHTaxt2Total.Location = new System.Drawing.Point(8, 36);
            this.lIHTaxt2Total.Name = "lIHTaxt2Total";
            this.lIHTaxt2Total.Size = new System.Drawing.Size(48, 20);
            this.lIHTaxt2Total.TabIndex = 35;
            this.lIHTaxt2Total.Text = "Tax 2 ";
            // 
            // ntbIH_Tax3Total
            // 
            this.ntbIH_Tax3Total.Location = new System.Drawing.Point(56, 56);
            this.ntbIH_Tax3Total.Maximum = new System.Decimal(new int[] {
                                                                            -727379968,
                                                                            232,
                                                                            0,
                                                                            0});
            this.ntbIH_Tax3Total.MaxPrecision = 2;
            this.ntbIH_Tax3Total.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.ntbIH_Tax3Total.Name = "ntbIH_Tax3Total";
            this.ntbIH_Tax3Total.Size = new System.Drawing.Size(120, 20);
            this.ntbIH_Tax3Total.TabIndex = 34;
            this.ntbIH_Tax3Total.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // lIHTax3Total
            // 
            this.lIHTax3Total.Location = new System.Drawing.Point(8, 56);
            this.lIHTax3Total.Name = "lIHTax3Total";
            this.lIHTax3Total.Size = new System.Drawing.Size(48, 20);
            this.lIHTax3Total.TabIndex = 33;
            this.lIHTax3Total.Text = "Tax 3 ";
            // 
            // ntbIH_TaxTotal
            // 
            this.ntbIH_TaxTotal.Location = new System.Drawing.Point(56, 76);
            this.ntbIH_TaxTotal.Maximum = new System.Decimal(new int[] {
                                                                           -727379968,
                                                                           232,
                                                                           0,
                                                                           0});
            this.ntbIH_TaxTotal.MaxPrecision = 2;
            this.ntbIH_TaxTotal.Minimum = new System.Decimal(new int[] {
                                                                           0,
                                                                           0,
                                                                           0,
                                                                           0});
            this.ntbIH_TaxTotal.Name = "ntbIH_TaxTotal";
            this.ntbIH_TaxTotal.Size = new System.Drawing.Size(120, 20);
            this.ntbIH_TaxTotal.TabIndex = 32;
            this.ntbIH_TaxTotal.Value = new System.Decimal(new int[] {
                                                                         0,
                                                                         0,
                                                                         0,
                                                                         0});
            // 
            // dGridTaxes
            // 
            this.dGridTaxes.DataMember = "";
            this.dGridTaxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dGridTaxes.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridTaxes.Location = new System.Drawing.Point(8, 136);
            this.dGridTaxes.Name = "dGridTaxes";
            this.dGridTaxes.Size = new System.Drawing.Size(760, 232);
            this.dGridTaxes.TabIndex = 39;
            // 
            // InvoiceHdrForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(824, 630);
            this.Controls.Add(this.tabControlInvoice);
            this.Controls.Add(this.gBoxBtns);
            this.Controls.Add(this.gBoxKeyData);
            this.Name = "InvoiceHdrForm";
            this.Text = "Invoice Header";
            this.Load += new System.EventHandler(this.InvoiceHdrForm_Load);
            this.gBoxKeyData.ResumeLayout(false);
            this.gBoxBtns.ResumeLayout(false);
            this.tabControlInvoice.ResumeLayout(false);
            this.tabPageHeader.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabPageFreigth.ResumeLayout(false);
            this.gBoxAccounting.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGridShowDetail)).EndInit();
            this.tabPageAccounting.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.gBoxCost.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.gBoxTax.ResumeLayout(false);
            this.tabPagePart.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridInfoPart)).EndInit();
            this.tabPageContact.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox25.ResumeLayout(false);
            this.groupBox24.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox20.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgridContact)).EndInit();
            this.tabPageLocation.ResumeLayout(false);
            this.gBoxShipLoc.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridShipTo)).EndInit();
            this.tabPageSalesCode.ResumeLayout(false);
            this.gBoxComm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridComm)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridSalesCode)).EndInit();
            this.tabPageDiscounts.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridDiscounts)).EndInit();
            this.tabPageChaRetCom.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridPRC)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridAccFrDis)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.gBoxPayment.ResumeLayout(false);
            this.gboxInfo.ResumeLayout(false);
            this.gBoxXhargesCalculated.ResumeLayout(false);
            this.gBoxPosted.ResumeLayout(false);
            this.tabPagePayment.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridPayments)).EndInit();
            this.tabPageTaxes.ResumeLayout(false);
            this.gBoxTaxes.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridTaxes)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

    
private void setFormatDates(){
        this.dtpIH_InvDate.Format =  DateTimePickerFormat.Short;
        this.dtpIH_OrderDate.Format = DateTimePickerFormat.Short;
        this.dtpIH_PODate.Format = DateTimePickerFormat.Short;
        this.dtpIHDateCreated.Format = DateTimePickerFormat.Short;
        this.dtpIHDateUpdated.Format = DateTimePickerFormat.Short;
        this.dtpIH_ShipDate.Format = DateTimePickerFormat.Short;
        this.dateTimePicker1.Format = DateTimePickerFormat.Short;
        
}


private void tabControlInvoice_SelectedIndexChanged(object sender, System.EventArgs e){

    loadTabPage(tabControlInvoice.SelectedTab);

}

private void loadTabPage(TabPage tabPage){
  
  	switch (tabPage.Name){
				case "tabPageHeader":
				    break;
				case "tabPagePart":
				    loadGridPart();
				    break;
				case "tabPageLocation":
				    loadGridShipTo();
				    break;    
                case "tabPageTaxes":
				    loadGridTaxes();
				    break;    
                case "tabPageSalesCode":
				    loadGridSalesCode();
				    loadGridCommission();
				    break;    
				case "tabPageFreigth":
				    //loadGridFreigth();
				    loadTreeView();
				    break;
                case "tabPageDiscounts":
				    loadGridDiscounts();
				    break;				    
                case "tabPageChaRetCom":
                    loadGridCRC();
                    break;
                case "tabPagePayment":
                    loadGridPayments();
                    break;
                case "tabPageContact":
                    loadGridContact();
                    break;    
   }
    			
}


private void loadGridPart(){
 
    try{   
        dataTable = new DataTable();
        DataSet listDataSet = new DataSet();	
        string tableName = "invocieDtlInfo";
        string[][] vecNames = loadColumnsNamesPart();
        Grid.addColumns(vecNames,tableName,dataTable,this.dGridInfoPart);
        
        
    }catch(NujitException ne){
        
	    FormException formException = new FormException(ne);
	    formException.ShowDialog();
    }        

}

private string[][] loadColumnsNamesPart(){
string[][] vec = new String[8][];
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
				v[1] = "60";
				break;
		    case "2":
				v[0]="Cust Part";
				v[1] = "110";
				break;	
		    case "3":
				v[0]="Description";
				v[1] = "150";
				break;
		    case "4":
				v[0]="Qty. Ordered";
				v[1] = "90";
				break;							
			case "5":
				v[0]="Qty. Shiped";
				v[1] = "90";
				break;
            case "6":
				v[0]="Price";
				v[1] = "90";
				break;
  	       case "7":
				v[0]="Total";
				v[1] = "90";
				break;
		}
		vec[i]=v;
		i++;	
	}
	return vec;
}


private void loadGridShipTo(){
 
    try{   
        dataTable = new DataTable();
        DataSet listDataSet = new DataSet();	
        string tableName = "invocieDtlShipTo";
        string[][] vecNames = loadColumnsNamesShip();
        Grid.addColumns(vecNames,tableName,dataTable,this.dGridShipTo);
        
        //se deberia cargar la info del invoice si es un invoice que existe.
          
    }catch(NujitException ne){
        
	    FormException formException = new FormException(ne);
	    formException.ShowDialog();
    }        

}

private string[][] loadColumnsNamesShip(){
string[][] vec = new String[8][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
		     case "0":
				v[0]="Bol #";
				v[1] = "80";
				break;
		     case "1":
				v[0]="Pack Slip";
				v[1] = "100";
				break;
		     case "2":
				v[0]="Date Shipped";
				v[1] = "100";
				break;
			case "3":
				v[0]="Line #";
				v[1] = "50";
				break;
            case "4":
				v[0]="Part";
				v[1] = "100";
				break;
            case "5":
				v[0]="Qty";
				v[1] = "90";
				break;
            case "6":
				v[0]="Uom";
				v[1] = "50";
				break;	
            case "7":
				v[0]="Carrier";
				v[1] = "130";
				break;		
		}
		vec[i]=v;
		i++;	
	}
	return vec;
}


private void InvoiceHdrForm_Load(object sender, System.EventArgs e){
    this.tabControlInvoice.TabPages.RemoveAt(11);//remove the trash page
}
     
     
     
private void loadGridTaxes(){
 
    try{   
        dataTable = new DataTable();
        DataSet listDataSet = new DataSet();	
        string tableName = "invocieDtlTaxes";
        string[][] vecNames = loadColumnsNamesTaxes();
        Grid.addColumns(vecNames,tableName,dataTable,this.dGridTaxes);
        
        //se deberia cargar la info del invoice si es un invoice que existe.
          
    }catch(NujitException ne){
        
	    FormException formException = new FormException(ne);
	    formException.ShowDialog();
    }        

}

private string[][] loadColumnsNamesTaxes(){
string[][] vec = new String[8][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
		    case "0":
				v[0]="Line #";
				v[1] = "80";
				break;	
		    case "1":
				v[0]="Part #";
				v[1] = "80";
				break;	
			case "2":
				v[0]="Extension";
				v[1] = "120";
				break;	
		    case "3":
				v[0]="Tax Group";
				v[1] = "90";
				break;	
		     case "4":
				v[0]="Tax Amt1";
				v[1] = "85";
				break;
		     case "5":
				v[0]="Tax Amt2";
				v[1] = "85";
				break;
		     case "6":
				v[0]="Tax Amt3";
				v[1] = "85";
				break;
            case "7":
				v[0]="Tax Total";
				v[1] = "85";
				break;
		}
		vec[i]=v;
		i++;	
	}
	return vec;
}

private void loadGridSalesCode(){
 
    try{   
        dataTable = new DataTable();
        DataSet listDataSet = new DataSet();	
        string tableName = "invocieDtlSC";
        string[][] vecNames = loadColumnsNamesSC();
        Grid.addColumns(vecNames,tableName,dataTable,this.dGridSalesCode);
        
        //se deberia cargar la info del invoice si es un invoice que existe.
          
    }catch(NujitException ne){
        
	    FormException formException = new FormException(ne);
	    formException.ShowDialog();
    }        

}

private string[][] loadColumnsNamesSC(){
string[][] vec = new String[9][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
		     case "0":
				v[0]="Line#";
				v[1] = "70";
				break;
		     case "1":
				v[0]="Part#";
				v[1] = "70";
				break;
		     case "2":
				v[0]="SC 1";
				v[1] = "80";
				break;
		     case "3":
				v[0]="SC 2";
				v[1] = "80";
				break;
		     case "4":
				v[0]="SC 3";
				v[1] = "80";
				break;
			case "5":
				v[0]="SC 4";
				v[1] = "80";
				break;
            case "6":
				v[0]="SC 5";
				v[1] = "80";
				break;
            case "7":
				v[0]="SC 6";
				v[1] = "80";
				break; 
		     case "8":
				v[0]="Dealer";
				v[1] = "100";
				break;
		}
		vec[i]=v;
		i++;	
	}
	return vec;
}

private void loadGridFreigth(){
 
    try{   
        dataTable = new DataTable();
        DataSet listDataSet = new DataSet();	
        string tableName = "invocieDtlFreigth";
        string[][] vecNames = loadColumnsNamesFreigth();
        Grid.addColumns(vecNames,tableName,dataTable,this.dGridAccFrDis);
        
        //se deberia cargar la info del invoice si es un invoice que existe.
          
    }catch(NujitException ne){
        
	    FormException formException = new FormException(ne);
	    formException.ShowDialog();
    }        

}

private string[][] loadColumnsNamesFreigth(){
string[][] vec = new String[4][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
		     case "0":
				v[0]="Sales  Acc";
				v[1] = "150";
				break;
		     case "1":
				v[0]="Cos. Acc";
				v[1] = "150";
				break;
		     case "2":
				v[0]="Cos. Type";
				v[1] = "150";
				break;
			case "3":
				v[0]="Freigth Amt.";
				v[1] = "150";
				break;
    				
		}
		vec[i]=v;
		i++;	
	}
	return vec;
}


private void loadGridCommission(){
 
    try{   
        dataTable = new DataTable();
        DataSet listDataSet = new DataSet();	
        string tableName = "invocieDtlCommsion";
        string[][] vecNames = loadColumnsNamesCommsion();
        Grid.addColumns(vecNames,tableName,dataTable,this.dGridComm);
        
        //se deberia cargar la info del invoice si es un invoice que existe.
          
    }catch(NujitException ne){
        
	    FormException formException = new FormException(ne);
	    formException.ShowDialog();
    }        

}

private string[][] loadColumnsNamesCommsion(){
string[][] vec = new String[9][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
		     case "0":
				v[0]="Line#";
				v[1] = "60";
				break;
		     case "1":
				v[0]="Part #";
				v[1] = "60";
				break;
		     case "2":
				v[0]="Sales Person";
				v[1] = "120";
				break;
		     case "3":
				v[0]="Qty";
				v[1] = "70";
				break;
		     case "4":
				v[0]="Comm Plan";
				v[1] = "80";
				break;
		     case "5":
				v[0]="Com %";
				v[1] = "80";
				break;
		     case "6":
				v[0]="Comm Rate";
				v[1] = "70";
				break;
		     case "7":
				v[0]="Comm Amt";
				v[1] = "70";
				break;
		     case "8":
				v[0]="Pd Flag";
				v[1] = "70";
				break;
		}
		vec[i]=v;
		i++;	
	}
	return vec;
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
				v[1] = "100";
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

 

private void loadGridCRC(){
 
    try{   
        dataTable = new DataTable();
        DataSet listDataSet = new DataSet();	
        string tableName = "invocieDtlCRC";
        string[][] vecNames = loadColumnsNamesCRC();
        Grid.addColumns(vecNames,tableName,dataTable,this.dGridPRC);
        
        //se deberia cargar la info del invoice si es un invoice que existe.
          
    }catch(NujitException ne){
        
	    FormException formException = new FormException(ne);
	    formException.ShowDialog();
    }        

}

private string[][] loadColumnsNamesCRC(){
string[][] vec = new String[3][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
		     case "0":
				v[0]="Roy Charges";
				v[1] = "230";
				break;
		    case "1":
				v[0]="Qty Returned";
				v[1] = "230";
				break;
			case "2":
				v[0]="Components List";
				v[1] = "230";
				break;
        }
		vec[i]=v;
		i++;	
	}
	return vec;
}


private void loadGridPayments(){
 
    try{   
        dataTable = new DataTable();
        DataSet listDataSet = new DataSet();	
        string tableName = "invocieDtlPayments";
        string[][] vecNames = loadColumnsNamesPayments();
        Grid.addColumns(vecNames,tableName,dataTable,this.dGridPayments);
        
        //se deberia cargar la info del invoice si es un invoice que existe.
          
    }catch(NujitException ne){
        
	    FormException formException = new FormException(ne);
	    formException.ShowDialog();
    }        

}

private string[][] loadColumnsNamesPayments(){
string[][] vec = new String[5][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
		     case "0":
				v[0]="Payment #";
				v[1] = "120";
				break;
		    case "1":
				v[0]="Amount";
				v[1] = "130";
				break;
			case "2":
				v[0]="Payment Type";
				v[1] = "150";
				break;
            case "3":
				v[0]="Reference";
				v[1] = "200";
				break;
            case "4":
				v[0]="Payment Date";
				v[1] = "150";
				break;
		}
		vec[i]=v;
		i++;	
	}
	return vec;
}

private void button2_Click(object sender, System.EventArgs e){

    PaymentTypesForm paymentTypesForm= new PaymentTypesForm();
    paymentTypesForm.ShowDialog();
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
				v[1] = "50";
				break;
		    case "1":
				v[0]="Date Time";
				v[1] = "80";
				break;
			case "2":
				v[0]="Contact Name";
				v[1] = "200";
				break;
            case "3":
				v[0]="Phone";
				v[1] = "90";
				break;
            case "4":
				v[0]="Type";
				v[1] = "80";
				break;
            case "5":
				v[0]="Conversation Des.";
				v[1] = "220";
				break;	
		
		}
		
		vec[i]=v;
		i++;	
	}
	return vec;
}

private void btnAddPart_Click(object sender, System.EventArgs e){
    InvoiceDtlEditForm invoiceDtlEditForm = new InvoiceDtlEditForm();
    invoiceDtlEditForm.ShowDialog();
}

private void btnShipFrom_Click(object sender, System.EventArgs e){
    ShipFromForm shipFromForm= new ShipFromForm();
    shipFromForm.ShowDialog();
}

private void buttonAddDiscount_Click(object sender, System.EventArgs e){

    FormDiscounts formDiscounts= new FormDiscounts();
    formDiscounts.ShowDialog();
}

private void buttonAddDiscGroup_Click(object sender, System.EventArgs e){
     FormGroupDiscounts formGroupDiscounts= new FormGroupDiscounts();
     formGroupDiscounts.ShowDialog();

}

private void btnSchSFContact_Click(object sender, System.EventArgs e){
    string[] vecSelected = showContactSchForm();
    if (vecSelected!=null){
        int idContact = int.Parse(vecSelected[0]);
        Contact contact = coreFactory.readContact(idContact);
        this.tBoxContactNameST.Text = contact.getDisplayName();
        this.tBoxContactPhoneST.Text = contact.getPhone();
    }
}     

private string[] showContactSchForm(){
    ContactSearchForm contactSearchForm= new ContactSearchForm("Search Contacts");
    contactSearchForm.ShowDialog();
    
    if (contactSearchForm.DialogResult.Equals(DialogResult.OK)){
        return contactSearchForm.getSelected();
    }else
        return null;
    

}

private void btnSchBTContact_Click(object sender, System.EventArgs e){
   string[] vecSelected = showContactSchForm();
   if (vecSelected!=null){
        int idContact = int.Parse(vecSelected[0]);
        Contact contact = coreFactory.readContact(idContact);
        this.tBoxContactNameBT.Text = contact.getDisplayName();
        this.tBoxContactPhoneBT.Text = contact.getPhone();
    }
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


private void treeViewInfo_Click(object sender, System.EventArgs e){
 try{
 
    string selectedNode = treeViewInfo.SelectedNode.Tag.ToString();
    setInformation(selectedNode);
 
  }catch{
    return;
  }
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
				v[0]="Cust. Part";
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
				v[0]="Cust. Part";
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
				v[0]="Cust. Part";
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
    
}//end class
}// end namespace

