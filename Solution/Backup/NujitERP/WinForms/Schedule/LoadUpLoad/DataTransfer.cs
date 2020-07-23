using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.WinForms.Reports.HotList_Report;
using System.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.WinForms.Schedule.LoadUpLoad;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.WinForms.Schedule.LoadUpLoad.GeneratedRecords;



namespace Nujit.NujitERP.WinForms.Schedule.LoadUpLoad{

/// <summary>
/// Summary description for DataTransfer.
/// </summary>
public 
class DataTransfer : System.Windows.Forms.Form{

private System.ComponentModel.IContainer components;
public System.Windows.Forms.StatusBarPanel statusBarPanelMessage;
private System.Windows.Forms.Button btnItems;
private System.Windows.Forms.Button btnFamilParts;
private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private System.Windows.Forms.Button btnDeptsRecords;
private System.Windows.Forms.Button machButton;
private System.Windows.Forms.Button btnStkr;
private System.Windows.Forms.Button personsButton;
private System.Windows.Forms.CheckBox cBoxStkrCmsToNujit;
private System.Windows.Forms.GroupBox gBoxStockRooms;
private System.Windows.Forms.GroupBox groupBox1;
private System.Windows.Forms.CheckBox cBoxItemsAs400ToCMS;
private System.Windows.Forms.CheckBox cBoxItemsCmsToNujit;
private System.Windows.Forms.GroupBox groupBox3;
private System.Windows.Forms.CheckBox ckBoxFamilyCmsToNujit;
private System.Windows.Forms.CheckBox cBoxFamilyAS400ToCms;
private System.Windows.Forms.GroupBox gBoxDepts;
private System.Windows.Forms.CheckBox cBoxDeptsAS400ToCms;
private System.Windows.Forms.CheckBox cBoxDeptsCmsToNujit;
private System.Windows.Forms.GroupBox gBoxMachines;
private System.Windows.Forms.CheckBox cBoxMachAS400ToCms;
private System.Windows.Forms.GroupBox gBoxSuppliers;
private System.Windows.Forms.CheckBox ckBoxSuppAS400ToCms;
private System.Windows.Forms.CheckBox ckBoxSuppCmsToNujit;
private System.Windows.Forms.CheckBox cBoxmachCmsToNujit;
private System.Windows.Forms.CheckBox cboxStkrAsToCms;
private System.Windows.Forms.GroupBox groupBox4;
private System.Windows.Forms.CheckBox cBoxShippingCmsToNujit;
private System.Windows.Forms.CheckBox cBoxShippingAs400ToCMS;
private System.Windows.Forms.Button btnShipping;
private System.Windows.Forms.GroupBox groupBox5;
private System.Windows.Forms.CheckBox cBoxMaterialAs400ToNujit;
private System.Windows.Forms.CheckBox cBoxMaterialAs400ToCMS;
private System.Windows.Forms.Button btnMaterial;
private System.Windows.Forms.GroupBox groupBox6;
private System.Windows.Forms.CheckBox cBoxCRefAs400ToNujit;
private System.Windows.Forms.CheckBox cBoxCRefAs400ToCMS;
private System.Windows.Forms.Button btnCRef;
private System.Windows.Forms.ToolTip toolTip1;
private System.Windows.Forms.GroupBox groupBox7;
private System.Windows.Forms.CheckBox cBoxHistAs400ToNujit;
private System.Windows.Forms.CheckBox cBoxHistAs400ToCMS;
private System.Windows.Forms.Button btnHist;
private System.Windows.Forms.GroupBox groupBox8;
private System.Windows.Forms.CheckBox cBoxLbHistAs400ToNujit;
private System.Windows.Forms.CheckBox cBoxLbHistAs400ToCMS;
private System.Windows.Forms.Button btnLbHist;
private System.Windows.Forms.GroupBox groupBox9;
private System.Windows.Forms.Button btnLbPssc;
private System.Windows.Forms.CheckBox cBoxPsscAs400ToNujit;
private System.Windows.Forms.CheckBox cBoxPsscAs400ToCMS;
private System.Windows.Forms.GroupBox groupBox10;
private System.Windows.Forms.Button btnScrap;
private System.Windows.Forms.CheckBox cBoxScrapCmsTempToNujit;
private System.Windows.Forms.CheckBox cBoxScrapCMStoCmsTemp;
private System.Windows.Forms.GroupBox groupBox11;
private System.Windows.Forms.CheckBox cBoxSprsnCmsTempToNujit;
private System.Windows.Forms.CheckBox cBoxSprsnCMStoCmsTemp;
private System.Windows.Forms.Button button1;
private System.Windows.Forms.TabControl tabControl1;
private System.Windows.Forms.TabPage tabPage2;
private System.Windows.Forms.TabPage tabPage3;
private System.Windows.Forms.TabPage tabPage4;
private System.Windows.Forms.TabPage tabPage1;
private System.Windows.Forms.GroupBox groupBox2;
private System.Windows.Forms.GroupBox groupBox12;
private System.Windows.Forms.Button btnClose;
private System.Windows.Forms.GroupBox groupBox13;
private System.Windows.Forms.CheckBox cBoxIcstpCMSToNujit;
private System.Windows.Forms.CheckBox cBoxIcstpAs400ToCMS;
private System.Windows.Forms.Button btnIcstp;
private System.Windows.Forms.GroupBox groupBox14;
private System.Windows.Forms.CheckBox cBoxIcstmCMSToNujit;
private System.Windows.Forms.CheckBox cBoxIcstmAs400ToCMS;
private System.Windows.Forms.Button btnIcstm;
private System.Windows.Forms.Button btnAutomatePrHist;
private System.Windows.Forms.Button btnAutomateScrap;
private System.Windows.Forms.Button btnAutomateSprsn;
private System.Windows.Forms.Button btnAutomateLbhist;
private System.Windows.Forms.Button btnAutomatePssc;
private System.Windows.Forms.Button btnAutomateFamilyParts;
private System.Windows.Forms.Button btnAutomateItems;
private System.Windows.Forms.Button btnAutomateDepts;
private System.Windows.Forms.Button btnAutomateMachines;
private System.Windows.Forms.Button btnAutomateStkr;
private System.Windows.Forms.Button btnAutomateSuppliers;
private System.Windows.Forms.Button btnAutomateShippingSch;
private System.Windows.Forms.Button btnAutomateIcstp;
private System.Windows.Forms.Button btnAutomateMatRelease;
private System.Windows.Forms.Button btnAutomateEdiCrossRef;
private System.Windows.Forms.Button btnAutomateIcstm;
private System.Windows.Forms.GroupBox groupBox15;
private System.Windows.Forms.Button btnAutomateMmgp;
private System.Windows.Forms.CheckBox cBoxMmgpAs400ToNujit;
private System.Windows.Forms.CheckBox cBoxMmgpAs400ToCMS;
private System.Windows.Forms.Button btnMmgp;
private System.Windows.Forms.GroupBox groupBox16;
private System.Windows.Forms.Button btnAutomateStkt;
private System.Windows.Forms.CheckBox cBoxStktCMSToNujit;
private System.Windows.Forms.CheckBox cBoxStktpAs400ToCMS;
private System.Windows.Forms.Button btnStkt;
private System.Windows.Forms.GroupBox groupBox17;
private System.Windows.Forms.CheckBox checkBox1;
private System.Windows.Forms.CheckBox checkBox2;
private System.Windows.Forms.Button button2;
private System.Windows.Forms.Button button3;
private System.Windows.Forms.GroupBox groupBox18;
private System.Windows.Forms.CheckBox checkBox3;
private System.Windows.Forms.CheckBox checkBox4;
private System.Windows.Forms.Button button4;
private System.Windows.Forms.Button button5;
private System.Windows.Forms.GroupBox groupBox19;
private System.Windows.Forms.CheckBox checkBox5;
private System.Windows.Forms.CheckBox checkBox6;
private System.Windows.Forms.Button button6;
private System.Windows.Forms.Button button7;
private System.Windows.Forms.GroupBox groupBox20;
private System.Windows.Forms.CheckBox cBoxRprdCmsTempToNujit;
private System.Windows.Forms.CheckBox cBoxRprdCMStoCmsTemp;
private System.Windows.Forms.Button btnRprd;
private System.Windows.Forms.Button btnAutomateRprd;
private System.Windows.Forms.GroupBox groupBox21;
private System.Windows.Forms.GroupBox groupBox22;
private System.Windows.Forms.GroupBox groupBox23;
private System.Windows.Forms.CheckBox checkBox11;
private System.Windows.Forms.CheckBox checkBox12;
private System.Windows.Forms.Button button12;
private System.Windows.Forms.Button button13;
private System.Windows.Forms.GroupBox groupBox24;
private System.Windows.Forms.GroupBox groupBox25;
private System.Windows.Forms.CheckBox checkBox15;
private System.Windows.Forms.CheckBox checkBox16;
private System.Windows.Forms.Button button16;
private System.Windows.Forms.Button button17;
private System.Windows.Forms.CheckBox checkBox17;
private System.Windows.Forms.CheckBox checkBox18;
private System.Windows.Forms.Button button18;
private System.Windows.Forms.Button button19;
private System.Windows.Forms.CheckBox cBoxRprrCmsTempToNujit;
private System.Windows.Forms.CheckBox cBoxRprrCMStoCmsTemp;
private System.Windows.Forms.Button btnRprr;
private System.Windows.Forms.Button btnAutomateRprr;
private System.Windows.Forms.CheckBox cBoxRprsCmsTempToNujit;
private System.Windows.Forms.CheckBox cBoxRprsCMStoCmsTemp;
private System.Windows.Forms.Button btnRprs;
private System.Windows.Forms.Button btnAutomateRprs;
private System.Windows.Forms.GroupBox groupBox26;
private System.Windows.Forms.GroupBox groupBox27;
private System.Windows.Forms.CheckBox checkBox7;
private System.Windows.Forms.CheckBox checkBox8;
private System.Windows.Forms.Button button8;
private System.Windows.Forms.Button button9;
private System.Windows.Forms.GroupBox groupBox28;
private System.Windows.Forms.GroupBox groupBox29;
private System.Windows.Forms.CheckBox checkBox13;
private System.Windows.Forms.CheckBox checkBox14;
private System.Windows.Forms.Button button14;
private System.Windows.Forms.Button button15;
private System.Windows.Forms.CheckBox checkBox19;
private System.Windows.Forms.CheckBox checkBox20;
private System.Windows.Forms.Button button20;
private System.Windows.Forms.Button button21;
private System.Windows.Forms.CheckBox cBoxRprhCmsTempToNujit;
private System.Windows.Forms.CheckBox cBoxRprhCMStoCmsTemp;
private System.Windows.Forms.Button btnRprh;
private System.Windows.Forms.Button btnAutomateRprh;
private System.Windows.Forms.GroupBox groupBox30;
private System.Windows.Forms.GroupBox groupBox31;
private System.Windows.Forms.CheckBox checkBox9;
private System.Windows.Forms.CheckBox checkBox10;
private System.Windows.Forms.Button button10;
private System.Windows.Forms.Button button11;
private System.Windows.Forms.GroupBox groupBox32;
private System.Windows.Forms.CheckBox cBoxRprpCmsTempToNujit;
private System.Windows.Forms.CheckBox cBoxRprpCMStoCmsTemp;
private System.Windows.Forms.Button btnRprp;
private System.Windows.Forms.Button btnAutomateRprp;
private System.Windows.Forms.GroupBox groupBox33;
private System.Windows.Forms.CheckBox checkBox23;
private System.Windows.Forms.CheckBox checkBox24;
private System.Windows.Forms.Button button24;
private System.Windows.Forms.Button button25;
private System.Windows.Forms.CheckBox checkBox25;
private System.Windows.Forms.CheckBox checkBox26;
private System.Windows.Forms.Button button26;
private System.Windows.Forms.Button button27;
private System.Windows.Forms.GroupBox groupBox34;
private System.Windows.Forms.Button mthlAutomateButton;
private System.Windows.Forms.Button mthlTransferButton;
private System.Windows.Forms.CheckBox cBoxMthlCmsToNujit;
private System.Windows.Forms.CheckBox cBoxMthlAS400ToCms;
private System.Windows.Forms.GroupBox groupBox35;
private System.Windows.Forms.CheckBox cBoxTmstCmsToNujit;
private System.Windows.Forms.CheckBox cBoxTmstAS400ToCms;
private System.Windows.Forms.Button tmstTransferButton;
private System.Windows.Forms.Button tmstAutomateButton;
private System.Windows.Forms.StatusBar statusBar; 

public 
DataTransfer(){
	InitializeComponent();
}

/// <summary>
/// Clean up any resources being used.
/// </summary>
protected override 
void Dispose(bool disposing){
	if (disposing){
		if(components != null){
			components.Dispose();
		}
	}
	base.Dispose(disposing);
}

#region Windows Form Designer generated code
/// <summary>
/// Required method for Designer support - do not modify
/// the contents of this method with the code editor.
/// </summary>
private 
void InitializeComponent(){
	this.components = new System.ComponentModel.Container();
	System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DataTransfer));
	this.statusBar = new System.Windows.Forms.StatusBar();
	this.statusBarPanelMessage = new System.Windows.Forms.StatusBarPanel();
	this.groupBox11 = new System.Windows.Forms.GroupBox();
	this.cBoxSprsnCmsTempToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxSprsnCMStoCmsTemp = new System.Windows.Forms.CheckBox();
	this.button1 = new System.Windows.Forms.Button();
	this.btnAutomateSprsn = new System.Windows.Forms.Button();
	this.groupBox10 = new System.Windows.Forms.GroupBox();
	this.cBoxScrapCmsTempToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxScrapCMStoCmsTemp = new System.Windows.Forms.CheckBox();
	this.btnScrap = new System.Windows.Forms.Button();
	this.btnAutomateScrap = new System.Windows.Forms.Button();
	this.groupBox9 = new System.Windows.Forms.GroupBox();
	this.btnAutomatePssc = new System.Windows.Forms.Button();
	this.cBoxPsscAs400ToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxPsscAs400ToCMS = new System.Windows.Forms.CheckBox();
	this.btnLbPssc = new System.Windows.Forms.Button();
	this.groupBox8 = new System.Windows.Forms.GroupBox();
	this.groupBox17 = new System.Windows.Forms.GroupBox();
	this.checkBox1 = new System.Windows.Forms.CheckBox();
	this.checkBox2 = new System.Windows.Forms.CheckBox();
	this.button2 = new System.Windows.Forms.Button();
	this.button3 = new System.Windows.Forms.Button();
	this.groupBox18 = new System.Windows.Forms.GroupBox();
	this.checkBox3 = new System.Windows.Forms.CheckBox();
	this.checkBox4 = new System.Windows.Forms.CheckBox();
	this.button4 = new System.Windows.Forms.Button();
	this.button5 = new System.Windows.Forms.Button();
	this.groupBox19 = new System.Windows.Forms.GroupBox();
	this.checkBox5 = new System.Windows.Forms.CheckBox();
	this.checkBox6 = new System.Windows.Forms.CheckBox();
	this.button6 = new System.Windows.Forms.Button();
	this.button7 = new System.Windows.Forms.Button();
	this.cBoxLbHistAs400ToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxLbHistAs400ToCMS = new System.Windows.Forms.CheckBox();
	this.btnLbHist = new System.Windows.Forms.Button();
	this.btnAutomateLbhist = new System.Windows.Forms.Button();
	this.groupBox7 = new System.Windows.Forms.GroupBox();
	this.cBoxHistAs400ToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxHistAs400ToCMS = new System.Windows.Forms.CheckBox();
	this.btnHist = new System.Windows.Forms.Button();
	this.btnAutomatePrHist = new System.Windows.Forms.Button();
	this.groupBox6 = new System.Windows.Forms.GroupBox();
	this.btnAutomateEdiCrossRef = new System.Windows.Forms.Button();
	this.cBoxCRefAs400ToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxCRefAs400ToCMS = new System.Windows.Forms.CheckBox();
	this.btnCRef = new System.Windows.Forms.Button();
	this.groupBox5 = new System.Windows.Forms.GroupBox();
	this.btnAutomateMatRelease = new System.Windows.Forms.Button();
	this.cBoxMaterialAs400ToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxMaterialAs400ToCMS = new System.Windows.Forms.CheckBox();
	this.btnMaterial = new System.Windows.Forms.Button();
	this.groupBox4 = new System.Windows.Forms.GroupBox();
	this.btnAutomateShippingSch = new System.Windows.Forms.Button();
	this.cBoxShippingCmsToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxShippingAs400ToCMS = new System.Windows.Forms.CheckBox();
	this.btnShipping = new System.Windows.Forms.Button();
	this.gBoxSuppliers = new System.Windows.Forms.GroupBox();
	this.btnAutomateSuppliers = new System.Windows.Forms.Button();
	this.ckBoxSuppCmsToNujit = new System.Windows.Forms.CheckBox();
	this.ckBoxSuppAS400ToCms = new System.Windows.Forms.CheckBox();
	this.personsButton = new System.Windows.Forms.Button();
	this.gBoxMachines = new System.Windows.Forms.GroupBox();
	this.btnAutomateMachines = new System.Windows.Forms.Button();
	this.cBoxmachCmsToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxMachAS400ToCms = new System.Windows.Forms.CheckBox();
	this.machButton = new System.Windows.Forms.Button();
	this.gBoxDepts = new System.Windows.Forms.GroupBox();
	this.btnAutomateDepts = new System.Windows.Forms.Button();
	this.cBoxDeptsCmsToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxDeptsAS400ToCms = new System.Windows.Forms.CheckBox();
	this.btnDeptsRecords = new System.Windows.Forms.Button();
	this.groupBox3 = new System.Windows.Forms.GroupBox();
	this.btnAutomateFamilyParts = new System.Windows.Forms.Button();
	this.cBoxFamilyAS400ToCms = new System.Windows.Forms.CheckBox();
	this.ckBoxFamilyCmsToNujit = new System.Windows.Forms.CheckBox();
	this.btnFamilParts = new System.Windows.Forms.Button();
	this.groupBox1 = new System.Windows.Forms.GroupBox();
	this.btnAutomateItems = new System.Windows.Forms.Button();
	this.cBoxItemsCmsToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxItemsAs400ToCMS = new System.Windows.Forms.CheckBox();
	this.btnItems = new System.Windows.Forms.Button();
	this.gBoxStockRooms = new System.Windows.Forms.GroupBox();
	this.btnAutomateStkr = new System.Windows.Forms.Button();
	this.cboxStkrAsToCms = new System.Windows.Forms.CheckBox();
	this.cBoxStkrCmsToNujit = new System.Windows.Forms.CheckBox();
	this.btnStkr = new System.Windows.Forms.Button();
	this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
	this.groupBox13 = new System.Windows.Forms.GroupBox();
	this.btnAutomateIcstp = new System.Windows.Forms.Button();
	this.cBoxIcstpCMSToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxIcstpAs400ToCMS = new System.Windows.Forms.CheckBox();
	this.btnIcstp = new System.Windows.Forms.Button();
	this.groupBox14 = new System.Windows.Forms.GroupBox();
	this.btnAutomateIcstm = new System.Windows.Forms.Button();
	this.cBoxIcstmCMSToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxIcstmAs400ToCMS = new System.Windows.Forms.CheckBox();
	this.btnIcstm = new System.Windows.Forms.Button();
	this.groupBox15 = new System.Windows.Forms.GroupBox();
	this.btnAutomateMmgp = new System.Windows.Forms.Button();
	this.cBoxMmgpAs400ToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxMmgpAs400ToCMS = new System.Windows.Forms.CheckBox();
	this.btnMmgp = new System.Windows.Forms.Button();
	this.groupBox16 = new System.Windows.Forms.GroupBox();
	this.btnAutomateStkt = new System.Windows.Forms.Button();
	this.cBoxStktCMSToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxStktpAs400ToCMS = new System.Windows.Forms.CheckBox();
	this.btnStkt = new System.Windows.Forms.Button();
	this.groupBox20 = new System.Windows.Forms.GroupBox();
	this.cBoxRprdCmsTempToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxRprdCMStoCmsTemp = new System.Windows.Forms.CheckBox();
	this.btnRprd = new System.Windows.Forms.Button();
	this.btnAutomateRprd = new System.Windows.Forms.Button();
	this.groupBox21 = new System.Windows.Forms.GroupBox();
	this.cBoxRprrCmsTempToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxRprrCMStoCmsTemp = new System.Windows.Forms.CheckBox();
	this.btnRprr = new System.Windows.Forms.Button();
	this.btnAutomateRprr = new System.Windows.Forms.Button();
	this.groupBox22 = new System.Windows.Forms.GroupBox();
	this.groupBox23 = new System.Windows.Forms.GroupBox();
	this.checkBox11 = new System.Windows.Forms.CheckBox();
	this.checkBox12 = new System.Windows.Forms.CheckBox();
	this.button12 = new System.Windows.Forms.Button();
	this.button13 = new System.Windows.Forms.Button();
	this.groupBox24 = new System.Windows.Forms.GroupBox();
	this.cBoxRprsCmsTempToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxRprsCMStoCmsTemp = new System.Windows.Forms.CheckBox();
	this.btnRprs = new System.Windows.Forms.Button();
	this.btnAutomateRprs = new System.Windows.Forms.Button();
	this.groupBox25 = new System.Windows.Forms.GroupBox();
	this.checkBox15 = new System.Windows.Forms.CheckBox();
	this.checkBox16 = new System.Windows.Forms.CheckBox();
	this.button16 = new System.Windows.Forms.Button();
	this.button17 = new System.Windows.Forms.Button();
	this.checkBox17 = new System.Windows.Forms.CheckBox();
	this.checkBox18 = new System.Windows.Forms.CheckBox();
	this.button18 = new System.Windows.Forms.Button();
	this.button19 = new System.Windows.Forms.Button();
	this.groupBox26 = new System.Windows.Forms.GroupBox();
	this.groupBox27 = new System.Windows.Forms.GroupBox();
	this.checkBox7 = new System.Windows.Forms.CheckBox();
	this.checkBox8 = new System.Windows.Forms.CheckBox();
	this.button8 = new System.Windows.Forms.Button();
	this.button9 = new System.Windows.Forms.Button();
	this.groupBox28 = new System.Windows.Forms.GroupBox();
	this.cBoxRprhCmsTempToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxRprhCMStoCmsTemp = new System.Windows.Forms.CheckBox();
	this.btnRprh = new System.Windows.Forms.Button();
	this.btnAutomateRprh = new System.Windows.Forms.Button();
	this.groupBox29 = new System.Windows.Forms.GroupBox();
	this.checkBox13 = new System.Windows.Forms.CheckBox();
	this.checkBox14 = new System.Windows.Forms.CheckBox();
	this.button14 = new System.Windows.Forms.Button();
	this.button15 = new System.Windows.Forms.Button();
	this.checkBox19 = new System.Windows.Forms.CheckBox();
	this.checkBox20 = new System.Windows.Forms.CheckBox();
	this.button20 = new System.Windows.Forms.Button();
	this.button21 = new System.Windows.Forms.Button();
	this.groupBox30 = new System.Windows.Forms.GroupBox();
	this.groupBox31 = new System.Windows.Forms.GroupBox();
	this.checkBox9 = new System.Windows.Forms.CheckBox();
	this.checkBox10 = new System.Windows.Forms.CheckBox();
	this.button10 = new System.Windows.Forms.Button();
	this.button11 = new System.Windows.Forms.Button();
	this.groupBox32 = new System.Windows.Forms.GroupBox();
	this.cBoxRprpCmsTempToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxRprpCMStoCmsTemp = new System.Windows.Forms.CheckBox();
	this.btnRprp = new System.Windows.Forms.Button();
	this.btnAutomateRprp = new System.Windows.Forms.Button();
	this.groupBox33 = new System.Windows.Forms.GroupBox();
	this.checkBox23 = new System.Windows.Forms.CheckBox();
	this.checkBox24 = new System.Windows.Forms.CheckBox();
	this.button24 = new System.Windows.Forms.Button();
	this.button25 = new System.Windows.Forms.Button();
	this.checkBox25 = new System.Windows.Forms.CheckBox();
	this.checkBox26 = new System.Windows.Forms.CheckBox();
	this.button26 = new System.Windows.Forms.Button();
	this.button27 = new System.Windows.Forms.Button();
	this.groupBox34 = new System.Windows.Forms.GroupBox();
	this.mthlAutomateButton = new System.Windows.Forms.Button();
	this.cBoxMthlCmsToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxMthlAS400ToCms = new System.Windows.Forms.CheckBox();
	this.mthlTransferButton = new System.Windows.Forms.Button();
	this.groupBox35 = new System.Windows.Forms.GroupBox();
	this.tmstAutomateButton = new System.Windows.Forms.Button();
	this.cBoxTmstCmsToNujit = new System.Windows.Forms.CheckBox();
	this.cBoxTmstAS400ToCms = new System.Windows.Forms.CheckBox();
	this.tmstTransferButton = new System.Windows.Forms.Button();
	this.tabControl1 = new System.Windows.Forms.TabControl();
	this.tabPage2 = new System.Windows.Forms.TabPage();
	this.tabPage4 = new System.Windows.Forms.TabPage();
	this.tabPage3 = new System.Windows.Forms.TabPage();
	this.tabPage1 = new System.Windows.Forms.TabPage();
	this.groupBox2 = new System.Windows.Forms.GroupBox();
	this.groupBox12 = new System.Windows.Forms.GroupBox();
	this.btnClose = new System.Windows.Forms.Button();
	((System.ComponentModel.ISupportInitialize)(this.statusBarPanelMessage)).BeginInit();
	this.groupBox11.SuspendLayout();
	this.groupBox10.SuspendLayout();
	this.groupBox9.SuspendLayout();
	this.groupBox8.SuspendLayout();
	this.groupBox17.SuspendLayout();
	this.groupBox18.SuspendLayout();
	this.groupBox19.SuspendLayout();
	this.groupBox7.SuspendLayout();
	this.groupBox6.SuspendLayout();
	this.groupBox5.SuspendLayout();
	this.groupBox4.SuspendLayout();
	this.gBoxSuppliers.SuspendLayout();
	this.gBoxMachines.SuspendLayout();
	this.gBoxDepts.SuspendLayout();
	this.groupBox3.SuspendLayout();
	this.groupBox1.SuspendLayout();
	this.gBoxStockRooms.SuspendLayout();
	this.groupBox13.SuspendLayout();
	this.groupBox14.SuspendLayout();
	this.groupBox15.SuspendLayout();
	this.groupBox16.SuspendLayout();
	this.groupBox20.SuspendLayout();
	this.groupBox21.SuspendLayout();
	this.groupBox22.SuspendLayout();
	this.groupBox23.SuspendLayout();
	this.groupBox24.SuspendLayout();
	this.groupBox25.SuspendLayout();
	this.groupBox26.SuspendLayout();
	this.groupBox27.SuspendLayout();
	this.groupBox28.SuspendLayout();
	this.groupBox29.SuspendLayout();
	this.groupBox30.SuspendLayout();
	this.groupBox31.SuspendLayout();
	this.groupBox32.SuspendLayout();
	this.groupBox33.SuspendLayout();
	this.groupBox34.SuspendLayout();
	this.groupBox35.SuspendLayout();
	this.tabControl1.SuspendLayout();
	this.tabPage2.SuspendLayout();
	this.tabPage4.SuspendLayout();
	this.tabPage3.SuspendLayout();
	this.tabPage1.SuspendLayout();
	this.groupBox2.SuspendLayout();
	this.groupBox12.SuspendLayout();
	this.SuspendLayout();
	// 
	// statusBar
	// 
	this.statusBar.Location = new System.Drawing.Point(0, 490);
	this.statusBar.Name = "statusBar";
	this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																				 this.statusBarPanelMessage});
	this.statusBar.Size = new System.Drawing.Size(776, 16);
	this.statusBar.TabIndex = 16;
	// 
	// statusBarPanelMessage
	// 
	this.statusBarPanelMessage.Text = "Message";
	// 
	// groupBox11
	// 
	this.groupBox11.Controls.Add(this.cBoxSprsnCmsTempToNujit);
	this.groupBox11.Controls.Add(this.cBoxSprsnCMStoCmsTemp);
	this.groupBox11.Controls.Add(this.button1);
	this.groupBox11.Controls.Add(this.btnAutomateSprsn);
	this.groupBox11.Location = new System.Drawing.Point(16, 104);
	this.groupBox11.Name = "groupBox11";
	this.groupBox11.Size = new System.Drawing.Size(224, 80);
	this.groupBox11.TabIndex = 32;
	this.groupBox11.TabStop = false;
	this.groupBox11.Text = "Sprsn";
	this.toolTip1.SetToolTip(this.groupBox11, "Data will transfer from Sprsn table");
	// 
	// cBoxSprsnCmsTempToNujit
	// 
	this.cBoxSprsnCmsTempToNujit.Enabled = false;
	this.cBoxSprsnCmsTempToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxSprsnCmsTempToNujit.Name = "cBoxSprsnCmsTempToNujit";
	this.cBoxSprsnCmsTempToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxSprsnCmsTempToNujit.TabIndex = 1;
	this.cBoxSprsnCmsTempToNujit.Text = "CmsTemp to Nujit";
	// 
	// cBoxSprsnCMStoCmsTemp
	// 
	this.cBoxSprsnCMStoCmsTemp.Checked = true;
	this.cBoxSprsnCMStoCmsTemp.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxSprsnCMStoCmsTemp.Location = new System.Drawing.Point(8, 24);
	this.cBoxSprsnCMStoCmsTemp.Name = "cBoxSprsnCMStoCmsTemp";
	this.cBoxSprsnCMStoCmsTemp.Size = new System.Drawing.Size(128, 16);
	this.cBoxSprsnCMStoCmsTemp.TabIndex = 0;
	this.cBoxSprsnCMStoCmsTemp.Text = "As400 to CmsTemp";
	// 
	// button1
	// 
	this.button1.Location = new System.Drawing.Point(144, 16);
	this.button1.Name = "button1";
	this.button1.Size = new System.Drawing.Size(72, 23);
	this.button1.TabIndex = 0;
	this.button1.Text = "Transfer";
	this.button1.Click += new System.EventHandler(this.button1_Click);
	// 
	// btnAutomateSprsn
	// 
	this.btnAutomateSprsn.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateSprsn.Name = "btnAutomateSprsn";
	this.btnAutomateSprsn.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateSprsn.TabIndex = 34;
	this.btnAutomateSprsn.Text = "Automate";
	this.btnAutomateSprsn.Click += new System.EventHandler(this.btnAutomateSprsn_Click);
	// 
	// groupBox10
	// 
	this.groupBox10.Controls.Add(this.cBoxScrapCmsTempToNujit);
	this.groupBox10.Controls.Add(this.cBoxScrapCMStoCmsTemp);
	this.groupBox10.Controls.Add(this.btnScrap);
	this.groupBox10.Controls.Add(this.btnAutomateScrap);
	this.groupBox10.Location = new System.Drawing.Point(16, 16);
	this.groupBox10.Name = "groupBox10";
	this.groupBox10.Size = new System.Drawing.Size(224, 80);
	this.groupBox10.TabIndex = 31;
	this.groupBox10.TabStop = false;
	this.groupBox10.Text = "Scrap";
	this.toolTip1.SetToolTip(this.groupBox10, "Data will transfer from Scrap table");
	// 
	// cBoxScrapCmsTempToNujit
	// 
	this.cBoxScrapCmsTempToNujit.Enabled = false;
	this.cBoxScrapCmsTempToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxScrapCmsTempToNujit.Name = "cBoxScrapCmsTempToNujit";
	this.cBoxScrapCmsTempToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxScrapCmsTempToNujit.TabIndex = 1;
	this.cBoxScrapCmsTempToNujit.Text = "CmsTemp to Nujit";
	// 
	// cBoxScrapCMStoCmsTemp
	// 
	this.cBoxScrapCMStoCmsTemp.Checked = true;
	this.cBoxScrapCMStoCmsTemp.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxScrapCMStoCmsTemp.Location = new System.Drawing.Point(8, 24);
	this.cBoxScrapCMStoCmsTemp.Name = "cBoxScrapCMStoCmsTemp";
	this.cBoxScrapCMStoCmsTemp.Size = new System.Drawing.Size(128, 16);
	this.cBoxScrapCMStoCmsTemp.TabIndex = 0;
	this.cBoxScrapCMStoCmsTemp.Text = "As400 to CmsTemp";
	// 
	// btnScrap
	// 
	this.btnScrap.Location = new System.Drawing.Point(144, 16);
	this.btnScrap.Name = "btnScrap";
	this.btnScrap.Size = new System.Drawing.Size(72, 23);
	this.btnScrap.TabIndex = 0;
	this.btnScrap.Text = "Transfer";
	this.btnScrap.Click += new System.EventHandler(this.btnScrap_Click);
	// 
	// btnAutomateScrap
	// 
	this.btnAutomateScrap.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateScrap.Name = "btnAutomateScrap";
	this.btnAutomateScrap.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateScrap.TabIndex = 33;
	this.btnAutomateScrap.Text = "Automate";
	this.btnAutomateScrap.Click += new System.EventHandler(this.btnAutomateScrap_Click);
	// 
	// groupBox9
	// 
	this.groupBox9.Controls.Add(this.btnAutomatePssc);
	this.groupBox9.Controls.Add(this.cBoxPsscAs400ToNujit);
	this.groupBox9.Controls.Add(this.cBoxPsscAs400ToCMS);
	this.groupBox9.Controls.Add(this.btnLbPssc);
	this.groupBox9.Location = new System.Drawing.Point(16, 192);
	this.groupBox9.Name = "groupBox9";
	this.groupBox9.Size = new System.Drawing.Size(224, 80);
	this.groupBox9.TabIndex = 30;
	this.groupBox9.TabStop = false;
	this.groupBox9.Text = "Pssc";
	this.toolTip1.SetToolTip(this.groupBox9, "Data will be transferred from Pssc Table");
	// 
	// btnAutomatePssc
	// 
	this.btnAutomatePssc.Location = new System.Drawing.Point(144, 48);
	this.btnAutomatePssc.Name = "btnAutomatePssc";
	this.btnAutomatePssc.Size = new System.Drawing.Size(72, 23);
	this.btnAutomatePssc.TabIndex = 5;
	this.btnAutomatePssc.Text = "Automate";
	this.btnAutomatePssc.Click += new System.EventHandler(this.btnAutomatePssc_Click);
	// 
	// cBoxPsscAs400ToNujit
	// 
	this.cBoxPsscAs400ToNujit.Enabled = false;
	this.cBoxPsscAs400ToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxPsscAs400ToNujit.Name = "cBoxPsscAs400ToNujit";
	this.cBoxPsscAs400ToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxPsscAs400ToNujit.TabIndex = 4;
	this.cBoxPsscAs400ToNujit.Text = "CmsTemp to Nujit";
	// 
	// cBoxPsscAs400ToCMS
	// 
	this.cBoxPsscAs400ToCMS.Checked = true;
	this.cBoxPsscAs400ToCMS.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxPsscAs400ToCMS.Location = new System.Drawing.Point(8, 24);
	this.cBoxPsscAs400ToCMS.Name = "cBoxPsscAs400ToCMS";
	this.cBoxPsscAs400ToCMS.Size = new System.Drawing.Size(136, 16);
	this.cBoxPsscAs400ToCMS.TabIndex = 3;
	this.cBoxPsscAs400ToCMS.Text = "As400 to CmsTemp";
	// 
	// btnLbPssc
	// 
	this.btnLbPssc.Location = new System.Drawing.Point(144, 16);
	this.btnLbPssc.Name = "btnLbPssc";
	this.btnLbPssc.Size = new System.Drawing.Size(72, 23);
	this.btnLbPssc.TabIndex = 2;
	this.btnLbPssc.Text = "Transfer";
	this.btnLbPssc.Click += new System.EventHandler(this.btnLbPssc_Click);
	// 
	// groupBox8
	// 
	this.groupBox8.Controls.Add(this.groupBox17);
	this.groupBox8.Controls.Add(this.groupBox18);
	this.groupBox8.Controls.Add(this.groupBox19);
	this.groupBox8.Controls.Add(this.cBoxLbHistAs400ToNujit);
	this.groupBox8.Controls.Add(this.cBoxLbHistAs400ToCMS);
	this.groupBox8.Controls.Add(this.btnLbHist);
	this.groupBox8.Controls.Add(this.btnAutomateLbhist);
	this.groupBox8.Location = new System.Drawing.Point(16, 192);
	this.groupBox8.Name = "groupBox8";
	this.groupBox8.Size = new System.Drawing.Size(224, 80);
	this.groupBox8.TabIndex = 29;
	this.groupBox8.TabStop = false;
	this.groupBox8.Text = " LbHist";
	this.toolTip1.SetToolTip(this.groupBox8, "Data will transfer from LbHist tables");
	// 
	// groupBox17
	// 
	this.groupBox17.Controls.Add(this.checkBox1);
	this.groupBox17.Controls.Add(this.checkBox2);
	this.groupBox17.Controls.Add(this.button2);
	this.groupBox17.Controls.Add(this.button3);
	this.groupBox17.Location = new System.Drawing.Point(0, -88);
	this.groupBox17.Name = "groupBox17";
	this.groupBox17.Size = new System.Drawing.Size(224, 87);
	this.groupBox17.TabIndex = 36;
	this.groupBox17.TabStop = false;
	this.groupBox17.Text = "Scrap";
	this.toolTip1.SetToolTip(this.groupBox17, "Data will transfer from Scrap table");
	// 
	// checkBox1
	// 
	this.checkBox1.Enabled = false;
	this.checkBox1.Location = new System.Drawing.Point(8, 48);
	this.checkBox1.Name = "checkBox1";
	this.checkBox1.Size = new System.Drawing.Size(120, 16);
	this.checkBox1.TabIndex = 1;
	this.checkBox1.Text = "CmsTemp to Nujit";
	// 
	// checkBox2
	// 
	this.checkBox2.Checked = true;
	this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
	this.checkBox2.Location = new System.Drawing.Point(8, 24);
	this.checkBox2.Name = "checkBox2";
	this.checkBox2.Size = new System.Drawing.Size(128, 16);
	this.checkBox2.TabIndex = 0;
	this.checkBox2.Text = "As400 to CmsTemp";
	// 
	// button2
	// 
	this.button2.Location = new System.Drawing.Point(144, 16);
	this.button2.Name = "button2";
	this.button2.Size = new System.Drawing.Size(72, 23);
	this.button2.TabIndex = 0;
	this.button2.Text = "Transfer";
	// 
	// button3
	// 
	this.button3.Location = new System.Drawing.Point(144, 48);
	this.button3.Name = "button3";
	this.button3.Size = new System.Drawing.Size(72, 23);
	this.button3.TabIndex = 33;
	this.button3.Text = "Automate";
	// 
	// groupBox18
	// 
	this.groupBox18.Controls.Add(this.checkBox3);
	this.groupBox18.Controls.Add(this.checkBox4);
	this.groupBox18.Controls.Add(this.button4);
	this.groupBox18.Controls.Add(this.button5);
	this.groupBox18.Location = new System.Drawing.Point(0, 0);
	this.groupBox18.Name = "groupBox18";
	this.groupBox18.Size = new System.Drawing.Size(224, 80);
	this.groupBox18.TabIndex = 37;
	this.groupBox18.TabStop = false;
	this.groupBox18.Text = "Sprsn";
	this.toolTip1.SetToolTip(this.groupBox18, "Data will transfer from Sprsn table");
	// 
	// checkBox3
	// 
	this.checkBox3.Enabled = false;
	this.checkBox3.Location = new System.Drawing.Point(8, 48);
	this.checkBox3.Name = "checkBox3";
	this.checkBox3.Size = new System.Drawing.Size(120, 16);
	this.checkBox3.TabIndex = 1;
	this.checkBox3.Text = "CmsTemp to Nujit";
	// 
	// checkBox4
	// 
	this.checkBox4.Checked = true;
	this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
	this.checkBox4.Location = new System.Drawing.Point(8, 24);
	this.checkBox4.Name = "checkBox4";
	this.checkBox4.Size = new System.Drawing.Size(128, 16);
	this.checkBox4.TabIndex = 0;
	this.checkBox4.Text = "As400 to CmsTemp";
	// 
	// button4
	// 
	this.button4.Location = new System.Drawing.Point(144, 16);
	this.button4.Name = "button4";
	this.button4.Size = new System.Drawing.Size(72, 23);
	this.button4.TabIndex = 0;
	this.button4.Text = "Transfer";
	// 
	// button5
	// 
	this.button5.Location = new System.Drawing.Point(144, 48);
	this.button5.Name = "button5";
	this.button5.Size = new System.Drawing.Size(72, 23);
	this.button5.TabIndex = 34;
	this.button5.Text = "Automate";
	// 
	// groupBox19
	// 
	this.groupBox19.Controls.Add(this.checkBox5);
	this.groupBox19.Controls.Add(this.checkBox6);
	this.groupBox19.Controls.Add(this.button6);
	this.groupBox19.Controls.Add(this.button7);
	this.groupBox19.Location = new System.Drawing.Point(0, 88);
	this.groupBox19.Name = "groupBox19";
	this.groupBox19.Size = new System.Drawing.Size(224, 80);
	this.groupBox19.TabIndex = 35;
	this.groupBox19.TabStop = false;
	this.groupBox19.Text = " LbHist";
	this.toolTip1.SetToolTip(this.groupBox19, "Data will transfer from LbHist tables");
	// 
	// checkBox5
	// 
	this.checkBox5.Checked = true;
	this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
	this.checkBox5.Location = new System.Drawing.Point(8, 48);
	this.checkBox5.Name = "checkBox5";
	this.checkBox5.Size = new System.Drawing.Size(120, 16);
	this.checkBox5.TabIndex = 1;
	this.checkBox5.Text = "CmsTemp to Nujit";
	// 
	// checkBox6
	// 
	this.checkBox6.Checked = true;
	this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
	this.checkBox6.Location = new System.Drawing.Point(8, 24);
	this.checkBox6.Name = "checkBox6";
	this.checkBox6.Size = new System.Drawing.Size(136, 16);
	this.checkBox6.TabIndex = 0;
	this.checkBox6.Text = "As400 to CmsTemp";
	// 
	// button6
	// 
	this.button6.Location = new System.Drawing.Point(144, 16);
	this.button6.Name = "button6";
	this.button6.Size = new System.Drawing.Size(72, 23);
	this.button6.TabIndex = 0;
	this.button6.Text = "Transfer";
	// 
	// button7
	// 
	this.button7.Location = new System.Drawing.Point(144, 48);
	this.button7.Name = "button7";
	this.button7.Size = new System.Drawing.Size(72, 23);
	this.button7.TabIndex = 34;
	this.button7.Text = "Automate";
	// 
	// cBoxLbHistAs400ToNujit
	// 
	this.cBoxLbHistAs400ToNujit.Checked = true;
	this.cBoxLbHistAs400ToNujit.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxLbHistAs400ToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxLbHistAs400ToNujit.Name = "cBoxLbHistAs400ToNujit";
	this.cBoxLbHistAs400ToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxLbHistAs400ToNujit.TabIndex = 1;
	this.cBoxLbHistAs400ToNujit.Text = "CmsTemp to Nujit";
	this.cBoxLbHistAs400ToNujit.CheckedChanged += new System.EventHandler(this.cBoxLbHistAs400ToNujit_CheckedChanged);
	// 
	// cBoxLbHistAs400ToCMS
	// 
	this.cBoxLbHistAs400ToCMS.Checked = true;
	this.cBoxLbHistAs400ToCMS.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxLbHistAs400ToCMS.Location = new System.Drawing.Point(8, 24);
	this.cBoxLbHistAs400ToCMS.Name = "cBoxLbHistAs400ToCMS";
	this.cBoxLbHistAs400ToCMS.Size = new System.Drawing.Size(136, 16);
	this.cBoxLbHistAs400ToCMS.TabIndex = 0;
	this.cBoxLbHistAs400ToCMS.Text = "As400 to CmsTemp";
	this.cBoxLbHistAs400ToCMS.CheckedChanged += new System.EventHandler(this.cBoxLbHistAs400ToCMS_CheckedChanged);
	// 
	// btnLbHist
	// 
	this.btnLbHist.Location = new System.Drawing.Point(144, 16);
	this.btnLbHist.Name = "btnLbHist";
	this.btnLbHist.Size = new System.Drawing.Size(72, 23);
	this.btnLbHist.TabIndex = 0;
	this.btnLbHist.Text = "Transfer";
	this.btnLbHist.Click += new System.EventHandler(this.btnLbHist_Click);
	// 
	// btnAutomateLbhist
	// 
	this.btnAutomateLbhist.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateLbhist.Name = "btnAutomateLbhist";
	this.btnAutomateLbhist.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateLbhist.TabIndex = 34;
	this.btnAutomateLbhist.Text = "Automate";
	this.btnAutomateLbhist.Click += new System.EventHandler(this.btnAutomateLbhist_Click);
	// 
	// groupBox7
	// 
	this.groupBox7.Controls.Add(this.cBoxHistAs400ToNujit);
	this.groupBox7.Controls.Add(this.cBoxHistAs400ToCMS);
	this.groupBox7.Controls.Add(this.btnHist);
	this.groupBox7.Controls.Add(this.btnAutomatePrHist);
	this.groupBox7.Location = new System.Drawing.Point(16, 280);
	this.groupBox7.Name = "groupBox7";
	this.groupBox7.Size = new System.Drawing.Size(224, 80);
	this.groupBox7.TabIndex = 28;
	this.groupBox7.TabStop = false;
	this.groupBox7.Text = "PrHist";
	this.toolTip1.SetToolTip(this.groupBox7, "Data will transfer from PrHist table");
	// 
	// cBoxHistAs400ToNujit
	// 
	this.cBoxHistAs400ToNujit.Checked = true;
	this.cBoxHistAs400ToNujit.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxHistAs400ToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxHistAs400ToNujit.Name = "cBoxHistAs400ToNujit";
	this.cBoxHistAs400ToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxHistAs400ToNujit.TabIndex = 1;
	this.cBoxHistAs400ToNujit.Text = "CmsTemp to Nujit";
	this.cBoxHistAs400ToNujit.CheckedChanged += new System.EventHandler(this.cBoxHistAs400ToNujit_CheckedChanged);
	// 
	// cBoxHistAs400ToCMS
	// 
	this.cBoxHistAs400ToCMS.Checked = true;
	this.cBoxHistAs400ToCMS.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxHistAs400ToCMS.Location = new System.Drawing.Point(8, 24);
	this.cBoxHistAs400ToCMS.Name = "cBoxHistAs400ToCMS";
	this.cBoxHistAs400ToCMS.Size = new System.Drawing.Size(136, 16);
	this.cBoxHistAs400ToCMS.TabIndex = 0;
	this.cBoxHistAs400ToCMS.Text = "As400 to CmsTemp";
	this.cBoxHistAs400ToCMS.CheckedChanged += new System.EventHandler(this.cBoxHistAs400ToCMS_CheckedChanged);
	// 
	// btnHist
	// 
	this.btnHist.Location = new System.Drawing.Point(144, 16);
	this.btnHist.Name = "btnHist";
	this.btnHist.Size = new System.Drawing.Size(72, 23);
	this.btnHist.TabIndex = 0;
	this.btnHist.Text = "Transfer";
	this.btnHist.Click += new System.EventHandler(this.btnHist_Click);
	// 
	// btnAutomatePrHist
	// 
	this.btnAutomatePrHist.Location = new System.Drawing.Point(144, 48);
	this.btnAutomatePrHist.Name = "btnAutomatePrHist";
	this.btnAutomatePrHist.Size = new System.Drawing.Size(72, 23);
	this.btnAutomatePrHist.TabIndex = 3;
	this.btnAutomatePrHist.Text = "Automate";
	this.btnAutomatePrHist.Click += new System.EventHandler(this.btnAutomatePrhist_Click);
	// 
	// groupBox6
	// 
	this.groupBox6.Controls.Add(this.btnAutomateEdiCrossRef);
	this.groupBox6.Controls.Add(this.cBoxCRefAs400ToNujit);
	this.groupBox6.Controls.Add(this.cBoxCRefAs400ToCMS);
	this.groupBox6.Controls.Add(this.btnCRef);
	this.groupBox6.Location = new System.Drawing.Point(16, 192);
	this.groupBox6.Name = "groupBox6";
	this.groupBox6.Size = new System.Drawing.Size(224, 80);
	this.groupBox6.TabIndex = 27;
	this.groupBox6.TabStop = false;
	this.groupBox6.Text = "EDI Cross Ref";
	this.toolTip1.SetToolTip(this.groupBox6, "Data will transfer fromTRLP table");
	// 
	// btnAutomateEdiCrossRef
	// 
	this.btnAutomateEdiCrossRef.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateEdiCrossRef.Name = "btnAutomateEdiCrossRef";
	this.btnAutomateEdiCrossRef.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateEdiCrossRef.TabIndex = 35;
	this.btnAutomateEdiCrossRef.Text = "Automate";
	this.btnAutomateEdiCrossRef.Click += new System.EventHandler(this.btnAutomateEdiCrossRef_Click);
	// 
	// cBoxCRefAs400ToNujit
	// 
	this.cBoxCRefAs400ToNujit.Checked = true;
	this.cBoxCRefAs400ToNujit.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxCRefAs400ToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxCRefAs400ToNujit.Name = "cBoxCRefAs400ToNujit";
	this.cBoxCRefAs400ToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxCRefAs400ToNujit.TabIndex = 1;
	this.cBoxCRefAs400ToNujit.Text = "CmsTemp to Nujit";
	this.cBoxCRefAs400ToNujit.CheckedChanged += new System.EventHandler(this.cBoxCRefAs400ToNujit_CheckedChanged_1);
	// 
	// cBoxCRefAs400ToCMS
	// 
	this.cBoxCRefAs400ToCMS.Checked = true;
	this.cBoxCRefAs400ToCMS.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxCRefAs400ToCMS.Location = new System.Drawing.Point(8, 24);
	this.cBoxCRefAs400ToCMS.Name = "cBoxCRefAs400ToCMS";
	this.cBoxCRefAs400ToCMS.Size = new System.Drawing.Size(136, 16);
	this.cBoxCRefAs400ToCMS.TabIndex = 0;
	this.cBoxCRefAs400ToCMS.Text = "As400 to CmsTemp";
	this.cBoxCRefAs400ToCMS.CheckedChanged += new System.EventHandler(this.cBoxCRefAs400ToCMS_CheckedChanged_1);
	// 
	// btnCRef
	// 
	this.btnCRef.Location = new System.Drawing.Point(144, 16);
	this.btnCRef.Name = "btnCRef";
	this.btnCRef.Size = new System.Drawing.Size(72, 23);
	this.btnCRef.TabIndex = 0;
	this.btnCRef.Text = "Transfer";
	this.btnCRef.Click += new System.EventHandler(this.btnCRef_Click_1);
	// 
	// groupBox5
	// 
	this.groupBox5.Controls.Add(this.btnAutomateMatRelease);
	this.groupBox5.Controls.Add(this.cBoxMaterialAs400ToNujit);
	this.groupBox5.Controls.Add(this.cBoxMaterialAs400ToCMS);
	this.groupBox5.Controls.Add(this.btnMaterial);
	this.groupBox5.Location = new System.Drawing.Point(16, 104);
	this.groupBox5.Name = "groupBox5";
	this.groupBox5.Size = new System.Drawing.Size(224, 80);
	this.groupBox5.TabIndex = 26;
	this.groupBox5.TabStop = false;
	this.groupBox5.Text = "Material Release";
	this.toolTip1.SetToolTip(this.groupBox5, "Data will transfer from RRLH and RRLD tables");
	// 
	// btnAutomateMatRelease
	// 
	this.btnAutomateMatRelease.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateMatRelease.Name = "btnAutomateMatRelease";
	this.btnAutomateMatRelease.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateMatRelease.TabIndex = 35;
	this.btnAutomateMatRelease.Text = "Automate";
	this.btnAutomateMatRelease.Click += new System.EventHandler(this.btnAutomateMatRelease_Click);
	// 
	// cBoxMaterialAs400ToNujit
	// 
	this.cBoxMaterialAs400ToNujit.Checked = true;
	this.cBoxMaterialAs400ToNujit.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxMaterialAs400ToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxMaterialAs400ToNujit.Name = "cBoxMaterialAs400ToNujit";
	this.cBoxMaterialAs400ToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxMaterialAs400ToNujit.TabIndex = 1;
	this.cBoxMaterialAs400ToNujit.Text = "CmsTemp to Nujit";
	this.cBoxMaterialAs400ToNujit.CheckedChanged += new System.EventHandler(this.cBoxMaterialAs400ToNujit_CheckedChanged_1);
	// 
	// cBoxMaterialAs400ToCMS
	// 
	this.cBoxMaterialAs400ToCMS.Checked = true;
	this.cBoxMaterialAs400ToCMS.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxMaterialAs400ToCMS.Location = new System.Drawing.Point(8, 24);
	this.cBoxMaterialAs400ToCMS.Name = "cBoxMaterialAs400ToCMS";
	this.cBoxMaterialAs400ToCMS.Size = new System.Drawing.Size(136, 16);
	this.cBoxMaterialAs400ToCMS.TabIndex = 0;
	this.cBoxMaterialAs400ToCMS.Text = "As400 to CmsTemp";
	this.cBoxMaterialAs400ToCMS.CheckedChanged += new System.EventHandler(this.cBoxMaterialAs400ToCMS_CheckedChanged_1);
	// 
	// btnMaterial
	// 
	this.btnMaterial.Location = new System.Drawing.Point(144, 16);
	this.btnMaterial.Name = "btnMaterial";
	this.btnMaterial.Size = new System.Drawing.Size(72, 23);
	this.btnMaterial.TabIndex = 0;
	this.btnMaterial.Text = "Transfer";
	this.btnMaterial.Click += new System.EventHandler(this.btnMaterial_Click_1);
	// 
	// groupBox4
	// 
	this.groupBox4.Controls.Add(this.btnAutomateShippingSch);
	this.groupBox4.Controls.Add(this.cBoxShippingCmsToNujit);
	this.groupBox4.Controls.Add(this.cBoxShippingAs400ToCMS);
	this.groupBox4.Controls.Add(this.btnShipping);
	this.groupBox4.Location = new System.Drawing.Point(16, 16);
	this.groupBox4.Name = "groupBox4";
	this.groupBox4.Size = new System.Drawing.Size(224, 80);
	this.groupBox4.TabIndex = 25;
	this.groupBox4.TabStop = false;
	this.groupBox4.Text = "Shipping Schedule";
	this.toolTip1.SetToolTip(this.groupBox4, "Data will transfer from JITH and JITD tables");
	// 
	// btnAutomateShippingSch
	// 
	this.btnAutomateShippingSch.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateShippingSch.Name = "btnAutomateShippingSch";
	this.btnAutomateShippingSch.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateShippingSch.TabIndex = 35;
	this.btnAutomateShippingSch.Text = "Automate";
	this.btnAutomateShippingSch.Click += new System.EventHandler(this.btnAutomateShippingSch_Click);
	// 
	// cBoxShippingCmsToNujit
	// 
	this.cBoxShippingCmsToNujit.Checked = true;
	this.cBoxShippingCmsToNujit.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxShippingCmsToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxShippingCmsToNujit.Name = "cBoxShippingCmsToNujit";
	this.cBoxShippingCmsToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxShippingCmsToNujit.TabIndex = 1;
	this.cBoxShippingCmsToNujit.Text = "CmsTemp to Nujit";
	this.cBoxShippingCmsToNujit.CheckedChanged += new System.EventHandler(this.cBoxShippingCmsToNujit_CheckedChanged_1);
	// 
	// cBoxShippingAs400ToCMS
	// 
	this.cBoxShippingAs400ToCMS.Checked = true;
	this.cBoxShippingAs400ToCMS.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxShippingAs400ToCMS.Location = new System.Drawing.Point(8, 24);
	this.cBoxShippingAs400ToCMS.Name = "cBoxShippingAs400ToCMS";
	this.cBoxShippingAs400ToCMS.Size = new System.Drawing.Size(128, 16);
	this.cBoxShippingAs400ToCMS.TabIndex = 0;
	this.cBoxShippingAs400ToCMS.Text = "As400 to CmsTemp";
	this.cBoxShippingAs400ToCMS.CheckedChanged += new System.EventHandler(this.cBoxShippingAs400ToCMS_CheckedChanged);
	// 
	// btnShipping
	// 
	this.btnShipping.Location = new System.Drawing.Point(144, 16);
	this.btnShipping.Name = "btnShipping";
	this.btnShipping.Size = new System.Drawing.Size(72, 23);
	this.btnShipping.TabIndex = 0;
	this.btnShipping.Text = "Transfer";
	this.btnShipping.Click += new System.EventHandler(this.btnShipping_Click);
	// 
	// gBoxSuppliers
	// 
	this.gBoxSuppliers.Controls.Add(this.btnAutomateSuppliers);
	this.gBoxSuppliers.Controls.Add(this.ckBoxSuppCmsToNujit);
	this.gBoxSuppliers.Controls.Add(this.ckBoxSuppAS400ToCms);
	this.gBoxSuppliers.Controls.Add(this.personsButton);
	this.gBoxSuppliers.Location = new System.Drawing.Point(16, 280);
	this.gBoxSuppliers.Name = "gBoxSuppliers";
	this.gBoxSuppliers.Size = new System.Drawing.Size(224, 80);
	this.gBoxSuppliers.TabIndex = 18;
	this.gBoxSuppliers.TabStop = false;
	this.gBoxSuppliers.Text = "Suppliers";
	this.toolTip1.SetToolTip(this.gBoxSuppliers, "Data will be transferred from Customer and Vendor Files  (Cust and Vend)");
	// 
	// btnAutomateSuppliers
	// 
	this.btnAutomateSuppliers.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateSuppliers.Name = "btnAutomateSuppliers";
	this.btnAutomateSuppliers.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateSuppliers.TabIndex = 34;
	this.btnAutomateSuppliers.Text = "Automate";
	this.btnAutomateSuppliers.Click += new System.EventHandler(this.btnAutomateSuppliers_Click);
	// 
	// ckBoxSuppCmsToNujit
	// 
	this.ckBoxSuppCmsToNujit.Checked = true;
	this.ckBoxSuppCmsToNujit.CheckState = System.Windows.Forms.CheckState.Checked;
	this.ckBoxSuppCmsToNujit.Location = new System.Drawing.Point(16, 48);
	this.ckBoxSuppCmsToNujit.Name = "ckBoxSuppCmsToNujit";
	this.ckBoxSuppCmsToNujit.Size = new System.Drawing.Size(120, 16);
	this.ckBoxSuppCmsToNujit.TabIndex = 1;
	this.ckBoxSuppCmsToNujit.Text = "CmsTemp to Nujit";
	this.ckBoxSuppCmsToNujit.CheckedChanged += new System.EventHandler(this.ckBoxSuppCmsToNujit_CheckedChanged);
	// 
	// ckBoxSuppAS400ToCms
	// 
	this.ckBoxSuppAS400ToCms.Checked = true;
	this.ckBoxSuppAS400ToCms.CheckState = System.Windows.Forms.CheckState.Checked;
	this.ckBoxSuppAS400ToCms.Location = new System.Drawing.Point(16, 24);
	this.ckBoxSuppAS400ToCms.Name = "ckBoxSuppAS400ToCms";
	this.ckBoxSuppAS400ToCms.Size = new System.Drawing.Size(128, 16);
	this.ckBoxSuppAS400ToCms.TabIndex = 0;
	this.ckBoxSuppAS400ToCms.Text = "As400 to CmsTemp";
	this.ckBoxSuppAS400ToCms.CheckedChanged += new System.EventHandler(this.ckBoxSuppAS400ToCms_CheckedChanged);
	// 
	// personsButton
	// 
	this.personsButton.Location = new System.Drawing.Point(144, 16);
	this.personsButton.Name = "personsButton";
	this.personsButton.Size = new System.Drawing.Size(72, 23);
	this.personsButton.TabIndex = 4;
	this.personsButton.Text = "Transfer";
	this.personsButton.Click += new System.EventHandler(this.personsButton_Click);
	// 
	// gBoxMachines
	// 
	this.gBoxMachines.Controls.Add(this.btnAutomateMachines);
	this.gBoxMachines.Controls.Add(this.cBoxmachCmsToNujit);
	this.gBoxMachines.Controls.Add(this.cBoxMachAS400ToCms);
	this.gBoxMachines.Controls.Add(this.machButton);
	this.gBoxMachines.Location = new System.Drawing.Point(16, 104);
	this.gBoxMachines.Name = "gBoxMachines";
	this.gBoxMachines.Size = new System.Drawing.Size(224, 80);
	this.gBoxMachines.TabIndex = 17;
	this.gBoxMachines.TabStop = false;
	this.gBoxMachines.Text = "Machines";
	this.toolTip1.SetToolTip(this.gBoxMachines, "Data will be transferred from Equipment Resource File  (RESRE)");
	// 
	// btnAutomateMachines
	// 
	this.btnAutomateMachines.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateMachines.Name = "btnAutomateMachines";
	this.btnAutomateMachines.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateMachines.TabIndex = 34;
	this.btnAutomateMachines.Text = "Automate";
	this.btnAutomateMachines.Click += new System.EventHandler(this.btnAutomateMachines_Click);
	// 
	// cBoxmachCmsToNujit
	// 
	this.cBoxmachCmsToNujit.Checked = true;
	this.cBoxmachCmsToNujit.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxmachCmsToNujit.Location = new System.Drawing.Point(16, 48);
	this.cBoxmachCmsToNujit.Name = "cBoxmachCmsToNujit";
	this.cBoxmachCmsToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxmachCmsToNujit.TabIndex = 1;
	this.cBoxmachCmsToNujit.Text = "CmsTemp to Nujit";
	this.cBoxmachCmsToNujit.CheckedChanged += new System.EventHandler(this.cBoxmachCmsToNujit_CheckedChanged);
	// 
	// cBoxMachAS400ToCms
	// 
	this.cBoxMachAS400ToCms.Checked = true;
	this.cBoxMachAS400ToCms.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxMachAS400ToCms.Location = new System.Drawing.Point(16, 24);
	this.cBoxMachAS400ToCms.Name = "cBoxMachAS400ToCms";
	this.cBoxMachAS400ToCms.Size = new System.Drawing.Size(128, 16);
	this.cBoxMachAS400ToCms.TabIndex = 0;
	this.cBoxMachAS400ToCms.Text = "As400 to CmsTemp";
	this.cBoxMachAS400ToCms.CheckedChanged += new System.EventHandler(this.cBoxMachAS400ToCms_CheckedChanged);
	// 
	// machButton
	// 
	this.machButton.Location = new System.Drawing.Point(144, 16);
	this.machButton.Name = "machButton";
	this.machButton.Size = new System.Drawing.Size(72, 23);
	this.machButton.TabIndex = 3;
	this.machButton.Text = "Transfer";
	this.machButton.Click += new System.EventHandler(this.machButton_Click);
	// 
	// gBoxDepts
	// 
	this.gBoxDepts.Controls.Add(this.btnAutomateDepts);
	this.gBoxDepts.Controls.Add(this.cBoxDeptsCmsToNujit);
	this.gBoxDepts.Controls.Add(this.cBoxDeptsAS400ToCms);
	this.gBoxDepts.Controls.Add(this.btnDeptsRecords);
	this.gBoxDepts.Location = new System.Drawing.Point(16, 16);
	this.gBoxDepts.Name = "gBoxDepts";
	this.gBoxDepts.Size = new System.Drawing.Size(224, 80);
	this.gBoxDepts.TabIndex = 16;
	this.gBoxDepts.TabStop = false;
	this.gBoxDepts.Text = "Plants and Departaments";
	this.toolTip1.SetToolTip(this.gBoxDepts, "Data will be transferred from Departments (DEPTS File)");
	// 
	// btnAutomateDepts
	// 
	this.btnAutomateDepts.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateDepts.Name = "btnAutomateDepts";
	this.btnAutomateDepts.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateDepts.TabIndex = 34;
	this.btnAutomateDepts.Text = "Automate";
	this.btnAutomateDepts.Click += new System.EventHandler(this.btnAutomateDepts_Click);
	// 
	// cBoxDeptsCmsToNujit
	// 
	this.cBoxDeptsCmsToNujit.Checked = true;
	this.cBoxDeptsCmsToNujit.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxDeptsCmsToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxDeptsCmsToNujit.Name = "cBoxDeptsCmsToNujit";
	this.cBoxDeptsCmsToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxDeptsCmsToNujit.TabIndex = 1;
	this.cBoxDeptsCmsToNujit.Text = "CmsTemp to Nujit";
	this.cBoxDeptsCmsToNujit.CheckedChanged += new System.EventHandler(this.cBoxDeptsCmsToNujit_CheckedChanged);
	// 
	// cBoxDeptsAS400ToCms
	// 
	this.cBoxDeptsAS400ToCms.Checked = true;
	this.cBoxDeptsAS400ToCms.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxDeptsAS400ToCms.Location = new System.Drawing.Point(8, 24);
	this.cBoxDeptsAS400ToCms.Name = "cBoxDeptsAS400ToCms";
	this.cBoxDeptsAS400ToCms.Size = new System.Drawing.Size(136, 16);
	this.cBoxDeptsAS400ToCms.TabIndex = 0;
	this.cBoxDeptsAS400ToCms.Text = "As400 to CmsTemp";
	this.cBoxDeptsAS400ToCms.CheckedChanged += new System.EventHandler(this.cBoxDeptsAS400ToCms_CheckedChanged);
	// 
	// btnDeptsRecords
	// 
	this.btnDeptsRecords.Location = new System.Drawing.Point(144, 16);
	this.btnDeptsRecords.Name = "btnDeptsRecords";
	this.btnDeptsRecords.Size = new System.Drawing.Size(72, 23);
	this.btnDeptsRecords.TabIndex = 2;
	this.btnDeptsRecords.Text = "Transfer";
	this.btnDeptsRecords.Click += new System.EventHandler(this.btnDeptsRecords_Click);
	// 
	// groupBox3
	// 
	this.groupBox3.Controls.Add(this.btnAutomateFamilyParts);
	this.groupBox3.Controls.Add(this.cBoxFamilyAS400ToCms);
	this.groupBox3.Controls.Add(this.ckBoxFamilyCmsToNujit);
	this.groupBox3.Controls.Add(this.btnFamilParts);
	this.groupBox3.Location = new System.Drawing.Point(16, 104);
	this.groupBox3.Name = "groupBox3";
	this.groupBox3.Size = new System.Drawing.Size(224, 80);
	this.groupBox3.TabIndex = 15;
	this.groupBox3.TabStop = false;
	this.groupBox3.Text = "Family Parts";
	this.toolTip1.SetToolTip(this.groupBox3, "Data will be transferred from Family Parts  (PDFC and PDFM)");
	// 
	// btnAutomateFamilyParts
	// 
	this.btnAutomateFamilyParts.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateFamilyParts.Name = "btnAutomateFamilyParts";
	this.btnAutomateFamilyParts.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateFamilyParts.TabIndex = 2;
	this.btnAutomateFamilyParts.Text = "Automate";
	this.btnAutomateFamilyParts.Click += new System.EventHandler(this.btnAutomateFamilyParts_Click);
	// 
	// cBoxFamilyAS400ToCms
	// 
	this.cBoxFamilyAS400ToCms.Checked = true;
	this.cBoxFamilyAS400ToCms.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxFamilyAS400ToCms.Location = new System.Drawing.Point(8, 24);
	this.cBoxFamilyAS400ToCms.Name = "cBoxFamilyAS400ToCms";
	this.cBoxFamilyAS400ToCms.Size = new System.Drawing.Size(128, 16);
	this.cBoxFamilyAS400ToCms.TabIndex = 1;
	this.cBoxFamilyAS400ToCms.Text = "As400 to CmsTemp";
	this.cBoxFamilyAS400ToCms.CheckedChanged += new System.EventHandler(this.cBoxFamilyAS400ToCms_CheckedChanged);
	// 
	// ckBoxFamilyCmsToNujit
	// 
	this.ckBoxFamilyCmsToNujit.Checked = true;
	this.ckBoxFamilyCmsToNujit.CheckState = System.Windows.Forms.CheckState.Checked;
	this.ckBoxFamilyCmsToNujit.Location = new System.Drawing.Point(8, 48);
	this.ckBoxFamilyCmsToNujit.Name = "ckBoxFamilyCmsToNujit";
	this.ckBoxFamilyCmsToNujit.Size = new System.Drawing.Size(120, 16);
	this.ckBoxFamilyCmsToNujit.TabIndex = 0;
	this.ckBoxFamilyCmsToNujit.Text = "CmsTemp to Nujit";
	this.ckBoxFamilyCmsToNujit.CheckedChanged += new System.EventHandler(this.ckBoxFamilyCmsToNujit_CheckedChanged);
	// 
	// btnFamilParts
	// 
	this.btnFamilParts.Location = new System.Drawing.Point(144, 16);
	this.btnFamilParts.Name = "btnFamilParts";
	this.btnFamilParts.Size = new System.Drawing.Size(72, 23);
	this.btnFamilParts.TabIndex = 1;
	this.btnFamilParts.Text = "Transfer";
	this.btnFamilParts.Click += new System.EventHandler(this.btnFamilParts_Click);
	// 
	// groupBox1
	// 
	this.groupBox1.Controls.Add(this.btnAutomateItems);
	this.groupBox1.Controls.Add(this.cBoxItemsCmsToNujit);
	this.groupBox1.Controls.Add(this.cBoxItemsAs400ToCMS);
	this.groupBox1.Controls.Add(this.btnItems);
	this.groupBox1.Location = new System.Drawing.Point(16, 16);
	this.groupBox1.Name = "groupBox1";
	this.groupBox1.Size = new System.Drawing.Size(224, 80);
	this.groupBox1.TabIndex = 14;
	this.groupBox1.TabStop = false;
	this.groupBox1.Text = "Item Master";
	this.toolTip1.SetToolTip(this.groupBox1, "Data will be transferred from Parts (STKMM and STKMP)");
	// 
	// btnAutomateItems
	// 
	this.btnAutomateItems.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateItems.Name = "btnAutomateItems";
	this.btnAutomateItems.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateItems.TabIndex = 2;
	this.btnAutomateItems.Text = "Automate";
	this.btnAutomateItems.Click += new System.EventHandler(this.btnAutomateItems_Click);
	// 
	// cBoxItemsCmsToNujit
	// 
	this.cBoxItemsCmsToNujit.Checked = true;
	this.cBoxItemsCmsToNujit.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxItemsCmsToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxItemsCmsToNujit.Name = "cBoxItemsCmsToNujit";
	this.cBoxItemsCmsToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxItemsCmsToNujit.TabIndex = 1;
	this.cBoxItemsCmsToNujit.Text = "CmsTemp to Nujit";
	this.cBoxItemsCmsToNujit.CheckedChanged += new System.EventHandler(this.cBoxItemsCmsToNujit_CheckedChanged);
	// 
	// cBoxItemsAs400ToCMS
	// 
	this.cBoxItemsAs400ToCMS.Checked = true;
	this.cBoxItemsAs400ToCMS.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxItemsAs400ToCMS.Location = new System.Drawing.Point(8, 24);
	this.cBoxItemsAs400ToCMS.Name = "cBoxItemsAs400ToCMS";
	this.cBoxItemsAs400ToCMS.Size = new System.Drawing.Size(128, 16);
	this.cBoxItemsAs400ToCMS.TabIndex = 0;
	this.cBoxItemsAs400ToCMS.Text = "As400 to CmsTemp";
	this.cBoxItemsAs400ToCMS.CheckedChanged += new System.EventHandler(this.cBoxItemsAs400ToCMS_CheckedChanged);
	// 
	// btnItems
	// 
	this.btnItems.Location = new System.Drawing.Point(144, 16);
	this.btnItems.Name = "btnItems";
	this.btnItems.Size = new System.Drawing.Size(72, 23);
	this.btnItems.TabIndex = 0;
	this.btnItems.Text = "Transfer";
	this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
	// 
	// gBoxStockRooms
	// 
	this.gBoxStockRooms.Controls.Add(this.btnAutomateStkr);
	this.gBoxStockRooms.Controls.Add(this.cboxStkrAsToCms);
	this.gBoxStockRooms.Controls.Add(this.cBoxStkrCmsToNujit);
	this.gBoxStockRooms.Controls.Add(this.btnStkr);
	this.gBoxStockRooms.Location = new System.Drawing.Point(16, 192);
	this.gBoxStockRooms.Name = "gBoxStockRooms";
	this.gBoxStockRooms.Size = new System.Drawing.Size(224, 80);
	this.gBoxStockRooms.TabIndex = 13;
	this.gBoxStockRooms.TabStop = false;
	this.gBoxStockRooms.Text = "Stock Rooms";
	this.toolTip1.SetToolTip(this.gBoxStockRooms, "Data will be transferred from Stock Rooms  (STKR)");
	// 
	// btnAutomateStkr
	// 
	this.btnAutomateStkr.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateStkr.Name = "btnAutomateStkr";
	this.btnAutomateStkr.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateStkr.TabIndex = 34;
	this.btnAutomateStkr.Text = "Automate";
	this.btnAutomateStkr.Click += new System.EventHandler(this.btnAutomateStkr_Click);
	// 
	// cboxStkrAsToCms
	// 
	this.cboxStkrAsToCms.Checked = true;
	this.cboxStkrAsToCms.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cboxStkrAsToCms.Location = new System.Drawing.Point(8, 24);
	this.cboxStkrAsToCms.Name = "cboxStkrAsToCms";
	this.cboxStkrAsToCms.Size = new System.Drawing.Size(136, 16);
	this.cboxStkrAsToCms.TabIndex = 11;
	this.cboxStkrAsToCms.Text = "As400 to CmsTemp";
	this.cboxStkrAsToCms.CheckedChanged += new System.EventHandler(this.cboxStkrAsToCms_CheckedChanged);
	// 
	// cBoxStkrCmsToNujit
	// 
	this.cBoxStkrCmsToNujit.Checked = true;
	this.cBoxStkrCmsToNujit.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxStkrCmsToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxStkrCmsToNujit.Name = "cBoxStkrCmsToNujit";
	this.cBoxStkrCmsToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxStkrCmsToNujit.TabIndex = 12;
	this.cBoxStkrCmsToNujit.Text = "CmsTemp to Nujit";
	this.cBoxStkrCmsToNujit.CheckedChanged += new System.EventHandler(this.cBoxStkrCmsToNujit_CheckedChanged);
	// 
	// btnStkr
	// 
	this.btnStkr.Location = new System.Drawing.Point(144, 16);
	this.btnStkr.Name = "btnStkr";
	this.btnStkr.Size = new System.Drawing.Size(72, 23);
	this.btnStkr.TabIndex = 2;
	this.btnStkr.Text = "Transfer";
	this.btnStkr.Click += new System.EventHandler(this.btnStkr_Click);
	// 
	// groupBox13
	// 
	this.groupBox13.Controls.Add(this.btnAutomateIcstp);
	this.groupBox13.Controls.Add(this.cBoxIcstpCMSToNujit);
	this.groupBox13.Controls.Add(this.cBoxIcstpAs400ToCMS);
	this.groupBox13.Controls.Add(this.btnIcstp);
	this.groupBox13.Location = new System.Drawing.Point(256, 16);
	this.groupBox13.Name = "groupBox13";
	this.groupBox13.Size = new System.Drawing.Size(224, 80);
	this.groupBox13.TabIndex = 28;
	this.groupBox13.TabStop = false;
	this.groupBox13.Text = "Icstp";
	this.toolTip1.SetToolTip(this.groupBox13, "Data will transfer from ICSTP table");
	// 
	// btnAutomateIcstp
	// 
	this.btnAutomateIcstp.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateIcstp.Name = "btnAutomateIcstp";
	this.btnAutomateIcstp.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateIcstp.TabIndex = 35;
	this.btnAutomateIcstp.Text = "Automate";
	this.btnAutomateIcstp.Click += new System.EventHandler(this.btnAutomateIcstp_Click);
	// 
	// cBoxIcstpCMSToNujit
	// 
	this.cBoxIcstpCMSToNujit.Checked = true;
	this.cBoxIcstpCMSToNujit.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxIcstpCMSToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxIcstpCMSToNujit.Name = "cBoxIcstpCMSToNujit";
	this.cBoxIcstpCMSToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxIcstpCMSToNujit.TabIndex = 1;
	this.cBoxIcstpCMSToNujit.Text = "CmsTemp to Nujit";
	this.cBoxIcstpCMSToNujit.CheckedChanged += new System.EventHandler(this.cBoxIcstpCMSToNujit_CheckedChanged);
	// 
	// cBoxIcstpAs400ToCMS
	// 
	this.cBoxIcstpAs400ToCMS.Checked = true;
	this.cBoxIcstpAs400ToCMS.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxIcstpAs400ToCMS.Location = new System.Drawing.Point(8, 24);
	this.cBoxIcstpAs400ToCMS.Name = "cBoxIcstpAs400ToCMS";
	this.cBoxIcstpAs400ToCMS.Size = new System.Drawing.Size(128, 16);
	this.cBoxIcstpAs400ToCMS.TabIndex = 0;
	this.cBoxIcstpAs400ToCMS.Text = "As400 to CmsTemp";
	this.cBoxIcstpAs400ToCMS.CheckedChanged += new System.EventHandler(this.cBoxIcstpAs400ToCMS_CheckedChanged);
	// 
	// btnIcstp
	// 
	this.btnIcstp.Location = new System.Drawing.Point(144, 16);
	this.btnIcstp.Name = "btnIcstp";
	this.btnIcstp.Size = new System.Drawing.Size(72, 23);
	this.btnIcstp.TabIndex = 0;
	this.btnIcstp.Text = "Transfer";
	this.btnIcstp.Click += new System.EventHandler(this.btnIcstp_Click);
	// 
	// groupBox14
	// 
	this.groupBox14.Controls.Add(this.btnAutomateIcstm);
	this.groupBox14.Controls.Add(this.cBoxIcstmCMSToNujit);
	this.groupBox14.Controls.Add(this.cBoxIcstmAs400ToCMS);
	this.groupBox14.Controls.Add(this.btnIcstm);
	this.groupBox14.Location = new System.Drawing.Point(16, 280);
	this.groupBox14.Name = "groupBox14";
	this.groupBox14.Size = new System.Drawing.Size(224, 80);
	this.groupBox14.TabIndex = 29;
	this.groupBox14.TabStop = false;
	this.groupBox14.Text = "Icstm";
	this.toolTip1.SetToolTip(this.groupBox14, "Data will transfer from ICSTM table");
	// 
	// btnAutomateIcstm
	// 
	this.btnAutomateIcstm.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateIcstm.Name = "btnAutomateIcstm";
	this.btnAutomateIcstm.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateIcstm.TabIndex = 35;
	this.btnAutomateIcstm.Text = "Automate";
	this.btnAutomateIcstm.Click += new System.EventHandler(this.btnAutomateIcstm_Click);
	// 
	// cBoxIcstmCMSToNujit
	// 
	this.cBoxIcstmCMSToNujit.Checked = true;
	this.cBoxIcstmCMSToNujit.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxIcstmCMSToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxIcstmCMSToNujit.Name = "cBoxIcstmCMSToNujit";
	this.cBoxIcstmCMSToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxIcstmCMSToNujit.TabIndex = 1;
	this.cBoxIcstmCMSToNujit.Text = "CmsTemp to Nujit";
	this.cBoxIcstmCMSToNujit.CheckedChanged += new System.EventHandler(this.cBoxIcstmCMSToNujit_CheckedChanged);
	// 
	// cBoxIcstmAs400ToCMS
	// 
	this.cBoxIcstmAs400ToCMS.Checked = true;
	this.cBoxIcstmAs400ToCMS.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxIcstmAs400ToCMS.Location = new System.Drawing.Point(8, 24);
	this.cBoxIcstmAs400ToCMS.Name = "cBoxIcstmAs400ToCMS";
	this.cBoxIcstmAs400ToCMS.Size = new System.Drawing.Size(128, 16);
	this.cBoxIcstmAs400ToCMS.TabIndex = 0;
	this.cBoxIcstmAs400ToCMS.Text = "As400 to CmsTemp";
	this.cBoxIcstmAs400ToCMS.CheckedChanged += new System.EventHandler(this.cBoxIcstmAs400ToCMS_CheckedChanged);
	// 
	// btnIcstm
	// 
	this.btnIcstm.Location = new System.Drawing.Point(144, 16);
	this.btnIcstm.Name = "btnIcstm";
	this.btnIcstm.Size = new System.Drawing.Size(72, 23);
	this.btnIcstm.TabIndex = 0;
	this.btnIcstm.Text = "Transfer";
	this.btnIcstm.Click += new System.EventHandler(this.btnIcstm_Click);
	// 
	// groupBox15
	// 
	this.groupBox15.Controls.Add(this.btnAutomateMmgp);
	this.groupBox15.Controls.Add(this.cBoxMmgpAs400ToNujit);
	this.groupBox15.Controls.Add(this.cBoxMmgpAs400ToCMS);
	this.groupBox15.Controls.Add(this.btnMmgp);
	this.groupBox15.Location = new System.Drawing.Point(16, 280);
	this.groupBox15.Name = "groupBox15";
	this.groupBox15.Size = new System.Drawing.Size(224, 80);
	this.groupBox15.TabIndex = 31;
	this.groupBox15.TabStop = false;
	this.groupBox15.Text = "Mmgp";
	this.toolTip1.SetToolTip(this.groupBox15, "Data will be transferred from Pssc Table");
	// 
	// btnAutomateMmgp
	// 
	this.btnAutomateMmgp.Enabled = false;
	this.btnAutomateMmgp.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateMmgp.Name = "btnAutomateMmgp";
	this.btnAutomateMmgp.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateMmgp.TabIndex = 5;
	this.btnAutomateMmgp.Text = "Automate";
	this.btnAutomateMmgp.Click += new System.EventHandler(this.btnAutomateMmgp_Click);
	// 
	// cBoxMmgpAs400ToNujit
	// 
	this.cBoxMmgpAs400ToNujit.Enabled = false;
	this.cBoxMmgpAs400ToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxMmgpAs400ToNujit.Name = "cBoxMmgpAs400ToNujit";
	this.cBoxMmgpAs400ToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxMmgpAs400ToNujit.TabIndex = 4;
	this.cBoxMmgpAs400ToNujit.Text = "CmsTemp to Nujit";
	// 
	// cBoxMmgpAs400ToCMS
	// 
	this.cBoxMmgpAs400ToCMS.Checked = true;
	this.cBoxMmgpAs400ToCMS.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxMmgpAs400ToCMS.Location = new System.Drawing.Point(8, 24);
	this.cBoxMmgpAs400ToCMS.Name = "cBoxMmgpAs400ToCMS";
	this.cBoxMmgpAs400ToCMS.Size = new System.Drawing.Size(136, 16);
	this.cBoxMmgpAs400ToCMS.TabIndex = 3;
	this.cBoxMmgpAs400ToCMS.Text = "As400 to CmsTemp";
	// 
	// btnMmgp
	// 
	this.btnMmgp.Location = new System.Drawing.Point(144, 16);
	this.btnMmgp.Name = "btnMmgp";
	this.btnMmgp.Size = new System.Drawing.Size(72, 23);
	this.btnMmgp.TabIndex = 2;
	this.btnMmgp.Text = "Transfer";
	this.btnMmgp.Click += new System.EventHandler(this.btnMmgp_Click);
	// 
	// groupBox16
	// 
	this.groupBox16.Controls.Add(this.btnAutomateStkt);
	this.groupBox16.Controls.Add(this.cBoxStktCMSToNujit);
	this.groupBox16.Controls.Add(this.cBoxStktpAs400ToCMS);
	this.groupBox16.Controls.Add(this.btnStkt);
	this.groupBox16.Location = new System.Drawing.Point(256, 104);
	this.groupBox16.Name = "groupBox16";
	this.groupBox16.Size = new System.Drawing.Size(224, 80);
	this.groupBox16.TabIndex = 30;
	this.groupBox16.TabStop = false;
	this.groupBox16.Text = "Stkt";
	this.toolTip1.SetToolTip(this.groupBox16, "Data will transfer from Stkt table");
	// 
	// btnAutomateStkt
	// 
	this.btnAutomateStkt.Enabled = false;
	this.btnAutomateStkt.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateStkt.Name = "btnAutomateStkt";
	this.btnAutomateStkt.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateStkt.TabIndex = 35;
	this.btnAutomateStkt.Text = "Automate";
	// 
	// cBoxStktCMSToNujit
	// 
	this.cBoxStktCMSToNujit.Checked = true;
	this.cBoxStktCMSToNujit.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxStktCMSToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxStktCMSToNujit.Name = "cBoxStktCMSToNujit";
	this.cBoxStktCMSToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxStktCMSToNujit.TabIndex = 1;
	this.cBoxStktCMSToNujit.Text = "CmsTemp to Nujit";
	// 
	// cBoxStktpAs400ToCMS
	// 
	this.cBoxStktpAs400ToCMS.Checked = true;
	this.cBoxStktpAs400ToCMS.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxStktpAs400ToCMS.Location = new System.Drawing.Point(8, 24);
	this.cBoxStktpAs400ToCMS.Name = "cBoxStktpAs400ToCMS";
	this.cBoxStktpAs400ToCMS.Size = new System.Drawing.Size(128, 16);
	this.cBoxStktpAs400ToCMS.TabIndex = 0;
	this.cBoxStktpAs400ToCMS.Text = "As400 to CmsTemp";
	// 
	// btnStkt
	// 
	this.btnStkt.Location = new System.Drawing.Point(144, 16);
	this.btnStkt.Name = "btnStkt";
	this.btnStkt.Size = new System.Drawing.Size(72, 23);
	this.btnStkt.TabIndex = 0;
	this.btnStkt.Text = "Transfer";
	this.btnStkt.Click += new System.EventHandler(this.btnStkt_Click);
	// 
	// groupBox20
	// 
	this.groupBox20.Controls.Add(this.cBoxRprdCmsTempToNujit);
	this.groupBox20.Controls.Add(this.cBoxRprdCMStoCmsTemp);
	this.groupBox20.Controls.Add(this.btnRprd);
	this.groupBox20.Controls.Add(this.btnAutomateRprd);
	this.groupBox20.Location = new System.Drawing.Point(256, 16);
	this.groupBox20.Name = "groupBox20";
	this.groupBox20.Size = new System.Drawing.Size(224, 80);
	this.groupBox20.TabIndex = 34;
	this.groupBox20.TabStop = false;
	this.groupBox20.Text = "Rprd";
	this.toolTip1.SetToolTip(this.groupBox20, "Data will transfer from Rprd table");
	// 
	// cBoxRprdCmsTempToNujit
	// 
	this.cBoxRprdCmsTempToNujit.Enabled = false;
	this.cBoxRprdCmsTempToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxRprdCmsTempToNujit.Name = "cBoxRprdCmsTempToNujit";
	this.cBoxRprdCmsTempToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxRprdCmsTempToNujit.TabIndex = 1;
	this.cBoxRprdCmsTempToNujit.Text = "CmsTemp to Nujit";
	// 
	// cBoxRprdCMStoCmsTemp
	// 
	this.cBoxRprdCMStoCmsTemp.Checked = true;
	this.cBoxRprdCMStoCmsTemp.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxRprdCMStoCmsTemp.Location = new System.Drawing.Point(8, 24);
	this.cBoxRprdCMStoCmsTemp.Name = "cBoxRprdCMStoCmsTemp";
	this.cBoxRprdCMStoCmsTemp.Size = new System.Drawing.Size(128, 16);
	this.cBoxRprdCMStoCmsTemp.TabIndex = 0;
	this.cBoxRprdCMStoCmsTemp.Text = "As400 to CmsTemp";
	// 
	// btnRprd
	// 
	this.btnRprd.Location = new System.Drawing.Point(144, 16);
	this.btnRprd.Name = "btnRprd";
	this.btnRprd.Size = new System.Drawing.Size(72, 23);
	this.btnRprd.TabIndex = 0;
	this.btnRprd.Text = "Transfer";
	this.btnRprd.Click += new System.EventHandler(this.btnRprd_Click);
	// 
	// btnAutomateRprd
	// 
	this.btnAutomateRprd.Enabled = false;
	this.btnAutomateRprd.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateRprd.Name = "btnAutomateRprd";
	this.btnAutomateRprd.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateRprd.TabIndex = 33;
	this.btnAutomateRprd.Text = "Automate";
	// 
	// groupBox21
	// 
	this.groupBox21.Controls.Add(this.cBoxRprrCmsTempToNujit);
	this.groupBox21.Controls.Add(this.cBoxRprrCMStoCmsTemp);
	this.groupBox21.Controls.Add(this.btnRprr);
	this.groupBox21.Controls.Add(this.btnAutomateRprr);
	this.groupBox21.Location = new System.Drawing.Point(256, 104);
	this.groupBox21.Name = "groupBox21";
	this.groupBox21.Size = new System.Drawing.Size(224, 80);
	this.groupBox21.TabIndex = 35;
	this.groupBox21.TabStop = false;
	this.groupBox21.Text = "Rprr";
	this.toolTip1.SetToolTip(this.groupBox21, "Data will transfer from Rprr table");
	// 
	// cBoxRprrCmsTempToNujit
	// 
	this.cBoxRprrCmsTempToNujit.Enabled = false;
	this.cBoxRprrCmsTempToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxRprrCmsTempToNujit.Name = "cBoxRprrCmsTempToNujit";
	this.cBoxRprrCmsTempToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxRprrCmsTempToNujit.TabIndex = 1;
	this.cBoxRprrCmsTempToNujit.Text = "CmsTemp to Nujit";
	// 
	// cBoxRprrCMStoCmsTemp
	// 
	this.cBoxRprrCMStoCmsTemp.Checked = true;
	this.cBoxRprrCMStoCmsTemp.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxRprrCMStoCmsTemp.Location = new System.Drawing.Point(8, 24);
	this.cBoxRprrCMStoCmsTemp.Name = "cBoxRprrCMStoCmsTemp";
	this.cBoxRprrCMStoCmsTemp.Size = new System.Drawing.Size(128, 16);
	this.cBoxRprrCMStoCmsTemp.TabIndex = 0;
	this.cBoxRprrCMStoCmsTemp.Text = "As400 to CmsTemp";
	// 
	// btnRprr
	// 
	this.btnRprr.Location = new System.Drawing.Point(144, 16);
	this.btnRprr.Name = "btnRprr";
	this.btnRprr.Size = new System.Drawing.Size(72, 23);
	this.btnRprr.TabIndex = 0;
	this.btnRprr.Text = "Transfer";
	this.btnRprr.Click += new System.EventHandler(this.btnRprr_Click);
	// 
	// btnAutomateRprr
	// 
	this.btnAutomateRprr.Enabled = false;
	this.btnAutomateRprr.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateRprr.Name = "btnAutomateRprr";
	this.btnAutomateRprr.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateRprr.TabIndex = 34;
	this.btnAutomateRprr.Text = "Automate";
	// 
	// groupBox22
	// 
	this.groupBox22.Controls.Add(this.groupBox23);
	this.groupBox22.Controls.Add(this.groupBox24);
	this.groupBox22.Controls.Add(this.groupBox25);
	this.groupBox22.Controls.Add(this.checkBox17);
	this.groupBox22.Controls.Add(this.checkBox18);
	this.groupBox22.Controls.Add(this.button18);
	this.groupBox22.Controls.Add(this.button19);
	this.groupBox22.Location = new System.Drawing.Point(256, 192);
	this.groupBox22.Name = "groupBox22";
	this.groupBox22.Size = new System.Drawing.Size(224, 80);
	this.groupBox22.TabIndex = 33;
	this.groupBox22.TabStop = false;
	this.groupBox22.Text = " LbHist";
	this.toolTip1.SetToolTip(this.groupBox22, "Data will transfer from Rprs tables");
	// 
	// groupBox23
	// 
	this.groupBox23.Controls.Add(this.checkBox11);
	this.groupBox23.Controls.Add(this.checkBox12);
	this.groupBox23.Controls.Add(this.button12);
	this.groupBox23.Controls.Add(this.button13);
	this.groupBox23.Location = new System.Drawing.Point(0, -88);
	this.groupBox23.Name = "groupBox23";
	this.groupBox23.Size = new System.Drawing.Size(224, 87);
	this.groupBox23.TabIndex = 36;
	this.groupBox23.TabStop = false;
	this.groupBox23.Text = "Scrap";
	this.toolTip1.SetToolTip(this.groupBox23, "Data will transfer from Scrap table");
	// 
	// checkBox11
	// 
	this.checkBox11.Enabled = false;
	this.checkBox11.Location = new System.Drawing.Point(8, 48);
	this.checkBox11.Name = "checkBox11";
	this.checkBox11.Size = new System.Drawing.Size(120, 16);
	this.checkBox11.TabIndex = 1;
	this.checkBox11.Text = "CmsTemp to Nujit";
	// 
	// checkBox12
	// 
	this.checkBox12.Checked = true;
	this.checkBox12.CheckState = System.Windows.Forms.CheckState.Checked;
	this.checkBox12.Location = new System.Drawing.Point(8, 24);
	this.checkBox12.Name = "checkBox12";
	this.checkBox12.Size = new System.Drawing.Size(128, 16);
	this.checkBox12.TabIndex = 0;
	this.checkBox12.Text = "As400 to CmsTemp";
	// 
	// button12
	// 
	this.button12.Location = new System.Drawing.Point(144, 16);
	this.button12.Name = "button12";
	this.button12.Size = new System.Drawing.Size(72, 23);
	this.button12.TabIndex = 0;
	this.button12.Text = "Transfer";
	// 
	// button13
	// 
	this.button13.Location = new System.Drawing.Point(144, 48);
	this.button13.Name = "button13";
	this.button13.Size = new System.Drawing.Size(72, 23);
	this.button13.TabIndex = 33;
	this.button13.Text = "Automate";
	// 
	// groupBox24
	// 
	this.groupBox24.Controls.Add(this.cBoxRprsCmsTempToNujit);
	this.groupBox24.Controls.Add(this.cBoxRprsCMStoCmsTemp);
	this.groupBox24.Controls.Add(this.btnRprs);
	this.groupBox24.Controls.Add(this.btnAutomateRprs);
	this.groupBox24.Location = new System.Drawing.Point(0, 0);
	this.groupBox24.Name = "groupBox24";
	this.groupBox24.Size = new System.Drawing.Size(224, 80);
	this.groupBox24.TabIndex = 37;
	this.groupBox24.TabStop = false;
	this.groupBox24.Text = "Rprs";
	this.toolTip1.SetToolTip(this.groupBox24, "Data will transfer from Rprs table");
	// 
	// cBoxRprsCmsTempToNujit
	// 
	this.cBoxRprsCmsTempToNujit.Enabled = false;
	this.cBoxRprsCmsTempToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxRprsCmsTempToNujit.Name = "cBoxRprsCmsTempToNujit";
	this.cBoxRprsCmsTempToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxRprsCmsTempToNujit.TabIndex = 1;
	this.cBoxRprsCmsTempToNujit.Text = "CmsTemp to Nujit";
	// 
	// cBoxRprsCMStoCmsTemp
	// 
	this.cBoxRprsCMStoCmsTemp.Checked = true;
	this.cBoxRprsCMStoCmsTemp.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxRprsCMStoCmsTemp.Location = new System.Drawing.Point(8, 24);
	this.cBoxRprsCMStoCmsTemp.Name = "cBoxRprsCMStoCmsTemp";
	this.cBoxRprsCMStoCmsTemp.Size = new System.Drawing.Size(128, 16);
	this.cBoxRprsCMStoCmsTemp.TabIndex = 0;
	this.cBoxRprsCMStoCmsTemp.Text = "As400 to CmsTemp";
	// 
	// btnRprs
	// 
	this.btnRprs.Location = new System.Drawing.Point(144, 16);
	this.btnRprs.Name = "btnRprs";
	this.btnRprs.Size = new System.Drawing.Size(72, 23);
	this.btnRprs.TabIndex = 0;
	this.btnRprs.Text = "Transfer";
	this.btnRprs.Click += new System.EventHandler(this.btnRprs_Click);
	// 
	// btnAutomateRprs
	// 
	this.btnAutomateRprs.Enabled = false;
	this.btnAutomateRprs.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateRprs.Name = "btnAutomateRprs";
	this.btnAutomateRprs.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateRprs.TabIndex = 34;
	this.btnAutomateRprs.Text = "Automate";
	// 
	// groupBox25
	// 
	this.groupBox25.Controls.Add(this.checkBox15);
	this.groupBox25.Controls.Add(this.checkBox16);
	this.groupBox25.Controls.Add(this.button16);
	this.groupBox25.Controls.Add(this.button17);
	this.groupBox25.Location = new System.Drawing.Point(0, 88);
	this.groupBox25.Name = "groupBox25";
	this.groupBox25.Size = new System.Drawing.Size(224, 80);
	this.groupBox25.TabIndex = 35;
	this.groupBox25.TabStop = false;
	this.groupBox25.Text = " LbHist";
	this.toolTip1.SetToolTip(this.groupBox25, "Data will transfer from LbHist tables");
	// 
	// checkBox15
	// 
	this.checkBox15.Checked = true;
	this.checkBox15.CheckState = System.Windows.Forms.CheckState.Checked;
	this.checkBox15.Location = new System.Drawing.Point(8, 48);
	this.checkBox15.Name = "checkBox15";
	this.checkBox15.Size = new System.Drawing.Size(120, 16);
	this.checkBox15.TabIndex = 1;
	this.checkBox15.Text = "CmsTemp to Nujit";
	// 
	// checkBox16
	// 
	this.checkBox16.Checked = true;
	this.checkBox16.CheckState = System.Windows.Forms.CheckState.Checked;
	this.checkBox16.Location = new System.Drawing.Point(8, 24);
	this.checkBox16.Name = "checkBox16";
	this.checkBox16.Size = new System.Drawing.Size(136, 16);
	this.checkBox16.TabIndex = 0;
	this.checkBox16.Text = "As400 to CmsTemp";
	// 
	// button16
	// 
	this.button16.Location = new System.Drawing.Point(144, 16);
	this.button16.Name = "button16";
	this.button16.Size = new System.Drawing.Size(72, 23);
	this.button16.TabIndex = 0;
	this.button16.Text = "Transfer";
	// 
	// button17
	// 
	this.button17.Location = new System.Drawing.Point(144, 48);
	this.button17.Name = "button17";
	this.button17.Size = new System.Drawing.Size(72, 23);
	this.button17.TabIndex = 34;
	this.button17.Text = "Automate";
	// 
	// checkBox17
	// 
	this.checkBox17.Checked = true;
	this.checkBox17.CheckState = System.Windows.Forms.CheckState.Checked;
	this.checkBox17.Location = new System.Drawing.Point(8, 48);
	this.checkBox17.Name = "checkBox17";
	this.checkBox17.Size = new System.Drawing.Size(120, 16);
	this.checkBox17.TabIndex = 1;
	this.checkBox17.Text = "CmsTemp to Nujit";
	// 
	// checkBox18
	// 
	this.checkBox18.Checked = true;
	this.checkBox18.CheckState = System.Windows.Forms.CheckState.Checked;
	this.checkBox18.Location = new System.Drawing.Point(8, 24);
	this.checkBox18.Name = "checkBox18";
	this.checkBox18.Size = new System.Drawing.Size(136, 16);
	this.checkBox18.TabIndex = 0;
	this.checkBox18.Text = "As400 to CmsTemp";
	// 
	// button18
	// 
	this.button18.Location = new System.Drawing.Point(144, 16);
	this.button18.Name = "button18";
	this.button18.Size = new System.Drawing.Size(72, 23);
	this.button18.TabIndex = 0;
	this.button18.Text = "Transfer";
	// 
	// button19
	// 
	this.button19.Location = new System.Drawing.Point(144, 48);
	this.button19.Name = "button19";
	this.button19.Size = new System.Drawing.Size(72, 23);
	this.button19.TabIndex = 34;
	this.button19.Text = "Automate";
	// 
	// groupBox26
	// 
	this.groupBox26.Controls.Add(this.groupBox27);
	this.groupBox26.Controls.Add(this.groupBox28);
	this.groupBox26.Controls.Add(this.groupBox29);
	this.groupBox26.Controls.Add(this.checkBox19);
	this.groupBox26.Controls.Add(this.checkBox20);
	this.groupBox26.Controls.Add(this.button20);
	this.groupBox26.Controls.Add(this.button21);
	this.groupBox26.Location = new System.Drawing.Point(256, 280);
	this.groupBox26.Name = "groupBox26";
	this.groupBox26.Size = new System.Drawing.Size(224, 80);
	this.groupBox26.TabIndex = 36;
	this.groupBox26.TabStop = false;
	this.groupBox26.Text = " LbHist";
	this.toolTip1.SetToolTip(this.groupBox26, "Data will transfer from Rprh tables");
	// 
	// groupBox27
	// 
	this.groupBox27.Controls.Add(this.checkBox7);
	this.groupBox27.Controls.Add(this.checkBox8);
	this.groupBox27.Controls.Add(this.button8);
	this.groupBox27.Controls.Add(this.button9);
	this.groupBox27.Location = new System.Drawing.Point(0, -88);
	this.groupBox27.Name = "groupBox27";
	this.groupBox27.Size = new System.Drawing.Size(224, 87);
	this.groupBox27.TabIndex = 36;
	this.groupBox27.TabStop = false;
	this.groupBox27.Text = "Scrap";
	this.toolTip1.SetToolTip(this.groupBox27, "Data will transfer from Scrap table");
	// 
	// checkBox7
	// 
	this.checkBox7.Enabled = false;
	this.checkBox7.Location = new System.Drawing.Point(8, 48);
	this.checkBox7.Name = "checkBox7";
	this.checkBox7.Size = new System.Drawing.Size(120, 16);
	this.checkBox7.TabIndex = 1;
	this.checkBox7.Text = "CmsTemp to Nujit";
	// 
	// checkBox8
	// 
	this.checkBox8.Checked = true;
	this.checkBox8.CheckState = System.Windows.Forms.CheckState.Checked;
	this.checkBox8.Location = new System.Drawing.Point(8, 24);
	this.checkBox8.Name = "checkBox8";
	this.checkBox8.Size = new System.Drawing.Size(128, 16);
	this.checkBox8.TabIndex = 0;
	this.checkBox8.Text = "As400 to CmsTemp";
	// 
	// button8
	// 
	this.button8.Location = new System.Drawing.Point(144, 16);
	this.button8.Name = "button8";
	this.button8.Size = new System.Drawing.Size(72, 23);
	this.button8.TabIndex = 0;
	this.button8.Text = "Transfer";
	// 
	// button9
	// 
	this.button9.Location = new System.Drawing.Point(144, 48);
	this.button9.Name = "button9";
	this.button9.Size = new System.Drawing.Size(72, 23);
	this.button9.TabIndex = 33;
	this.button9.Text = "Automate";
	// 
	// groupBox28
	// 
	this.groupBox28.Controls.Add(this.cBoxRprhCmsTempToNujit);
	this.groupBox28.Controls.Add(this.cBoxRprhCMStoCmsTemp);
	this.groupBox28.Controls.Add(this.btnRprh);
	this.groupBox28.Controls.Add(this.btnAutomateRprh);
	this.groupBox28.Location = new System.Drawing.Point(0, 0);
	this.groupBox28.Name = "groupBox28";
	this.groupBox28.Size = new System.Drawing.Size(224, 80);
	this.groupBox28.TabIndex = 37;
	this.groupBox28.TabStop = false;
	this.groupBox28.Text = "Rprh";
	this.toolTip1.SetToolTip(this.groupBox28, "Data will transfer from Rprh table");
	// 
	// cBoxRprhCmsTempToNujit
	// 
	this.cBoxRprhCmsTempToNujit.Enabled = false;
	this.cBoxRprhCmsTempToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxRprhCmsTempToNujit.Name = "cBoxRprhCmsTempToNujit";
	this.cBoxRprhCmsTempToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxRprhCmsTempToNujit.TabIndex = 1;
	this.cBoxRprhCmsTempToNujit.Text = "CmsTemp to Nujit";
	// 
	// cBoxRprhCMStoCmsTemp
	// 
	this.cBoxRprhCMStoCmsTemp.Checked = true;
	this.cBoxRprhCMStoCmsTemp.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxRprhCMStoCmsTemp.Location = new System.Drawing.Point(8, 24);
	this.cBoxRprhCMStoCmsTemp.Name = "cBoxRprhCMStoCmsTemp";
	this.cBoxRprhCMStoCmsTemp.Size = new System.Drawing.Size(128, 16);
	this.cBoxRprhCMStoCmsTemp.TabIndex = 0;
	this.cBoxRprhCMStoCmsTemp.Text = "As400 to CmsTemp";
	// 
	// btnRprh
	// 
	this.btnRprh.Location = new System.Drawing.Point(144, 16);
	this.btnRprh.Name = "btnRprh";
	this.btnRprh.Size = new System.Drawing.Size(72, 23);
	this.btnRprh.TabIndex = 0;
	this.btnRprh.Text = "Transfer";
	this.btnRprh.Click += new System.EventHandler(this.btnRprh_Click);
	// 
	// btnAutomateRprh
	// 
	this.btnAutomateRprh.Enabled = false;
	this.btnAutomateRprh.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateRprh.Name = "btnAutomateRprh";
	this.btnAutomateRprh.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateRprh.TabIndex = 34;
	this.btnAutomateRprh.Text = "Automate";
	// 
	// groupBox29
	// 
	this.groupBox29.Controls.Add(this.checkBox13);
	this.groupBox29.Controls.Add(this.checkBox14);
	this.groupBox29.Controls.Add(this.button14);
	this.groupBox29.Controls.Add(this.button15);
	this.groupBox29.Location = new System.Drawing.Point(0, 88);
	this.groupBox29.Name = "groupBox29";
	this.groupBox29.Size = new System.Drawing.Size(224, 80);
	this.groupBox29.TabIndex = 35;
	this.groupBox29.TabStop = false;
	this.groupBox29.Text = " LbHist";
	this.toolTip1.SetToolTip(this.groupBox29, "Data will transfer from LbHist tables");
	// 
	// checkBox13
	// 
	this.checkBox13.Checked = true;
	this.checkBox13.CheckState = System.Windows.Forms.CheckState.Checked;
	this.checkBox13.Location = new System.Drawing.Point(8, 48);
	this.checkBox13.Name = "checkBox13";
	this.checkBox13.Size = new System.Drawing.Size(120, 16);
	this.checkBox13.TabIndex = 1;
	this.checkBox13.Text = "CmsTemp to Nujit";
	// 
	// checkBox14
	// 
	this.checkBox14.Checked = true;
	this.checkBox14.CheckState = System.Windows.Forms.CheckState.Checked;
	this.checkBox14.Location = new System.Drawing.Point(8, 24);
	this.checkBox14.Name = "checkBox14";
	this.checkBox14.Size = new System.Drawing.Size(136, 16);
	this.checkBox14.TabIndex = 0;
	this.checkBox14.Text = "As400 to CmsTemp";
	// 
	// button14
	// 
	this.button14.Location = new System.Drawing.Point(144, 16);
	this.button14.Name = "button14";
	this.button14.Size = new System.Drawing.Size(72, 23);
	this.button14.TabIndex = 0;
	this.button14.Text = "Transfer";
	// 
	// button15
	// 
	this.button15.Location = new System.Drawing.Point(144, 48);
	this.button15.Name = "button15";
	this.button15.Size = new System.Drawing.Size(72, 23);
	this.button15.TabIndex = 34;
	this.button15.Text = "Automate";
	// 
	// checkBox19
	// 
	this.checkBox19.Checked = true;
	this.checkBox19.CheckState = System.Windows.Forms.CheckState.Checked;
	this.checkBox19.Location = new System.Drawing.Point(8, 48);
	this.checkBox19.Name = "checkBox19";
	this.checkBox19.Size = new System.Drawing.Size(120, 16);
	this.checkBox19.TabIndex = 1;
	this.checkBox19.Text = "CmsTemp to Nujit";
	// 
	// checkBox20
	// 
	this.checkBox20.Checked = true;
	this.checkBox20.CheckState = System.Windows.Forms.CheckState.Checked;
	this.checkBox20.Location = new System.Drawing.Point(8, 24);
	this.checkBox20.Name = "checkBox20";
	this.checkBox20.Size = new System.Drawing.Size(136, 16);
	this.checkBox20.TabIndex = 0;
	this.checkBox20.Text = "As400 to CmsTemp";
	// 
	// button20
	// 
	this.button20.Location = new System.Drawing.Point(144, 16);
	this.button20.Name = "button20";
	this.button20.Size = new System.Drawing.Size(72, 23);
	this.button20.TabIndex = 0;
	this.button20.Text = "Transfer";
	// 
	// button21
	// 
	this.button21.Location = new System.Drawing.Point(144, 48);
	this.button21.Name = "button21";
	this.button21.Size = new System.Drawing.Size(72, 23);
	this.button21.TabIndex = 34;
	this.button21.Text = "Automate";
	// 
	// groupBox30
	// 
	this.groupBox30.Controls.Add(this.groupBox31);
	this.groupBox30.Controls.Add(this.groupBox32);
	this.groupBox30.Controls.Add(this.groupBox33);
	this.groupBox30.Controls.Add(this.checkBox25);
	this.groupBox30.Controls.Add(this.checkBox26);
	this.groupBox30.Controls.Add(this.button26);
	this.groupBox30.Controls.Add(this.button27);
	this.groupBox30.Location = new System.Drawing.Point(493, 16);
	this.groupBox30.Name = "groupBox30";
	this.groupBox30.Size = new System.Drawing.Size(224, 80);
	this.groupBox30.TabIndex = 37;
	this.groupBox30.TabStop = false;
	this.groupBox30.Text = " LbHist";
	this.toolTip1.SetToolTip(this.groupBox30, "Data will transfer from Rprh tables");
	// 
	// groupBox31
	// 
	this.groupBox31.Controls.Add(this.checkBox9);
	this.groupBox31.Controls.Add(this.checkBox10);
	this.groupBox31.Controls.Add(this.button10);
	this.groupBox31.Controls.Add(this.button11);
	this.groupBox31.Location = new System.Drawing.Point(0, -88);
	this.groupBox31.Name = "groupBox31";
	this.groupBox31.Size = new System.Drawing.Size(224, 87);
	this.groupBox31.TabIndex = 36;
	this.groupBox31.TabStop = false;
	this.groupBox31.Text = "Scrap";
	this.toolTip1.SetToolTip(this.groupBox31, "Data will transfer from Scrap table");
	// 
	// checkBox9
	// 
	this.checkBox9.Enabled = false;
	this.checkBox9.Location = new System.Drawing.Point(8, 48);
	this.checkBox9.Name = "checkBox9";
	this.checkBox9.Size = new System.Drawing.Size(120, 16);
	this.checkBox9.TabIndex = 1;
	this.checkBox9.Text = "CmsTemp to Nujit";
	// 
	// checkBox10
	// 
	this.checkBox10.Checked = true;
	this.checkBox10.CheckState = System.Windows.Forms.CheckState.Checked;
	this.checkBox10.Location = new System.Drawing.Point(8, 24);
	this.checkBox10.Name = "checkBox10";
	this.checkBox10.Size = new System.Drawing.Size(128, 16);
	this.checkBox10.TabIndex = 0;
	this.checkBox10.Text = "As400 to CmsTemp";
	// 
	// button10
	// 
	this.button10.Location = new System.Drawing.Point(144, 16);
	this.button10.Name = "button10";
	this.button10.Size = new System.Drawing.Size(72, 23);
	this.button10.TabIndex = 0;
	this.button10.Text = "Transfer";
	// 
	// button11
	// 
	this.button11.Location = new System.Drawing.Point(144, 48);
	this.button11.Name = "button11";
	this.button11.Size = new System.Drawing.Size(72, 23);
	this.button11.TabIndex = 33;
	this.button11.Text = "Automate";
	// 
	// groupBox32
	// 
	this.groupBox32.Controls.Add(this.cBoxRprpCmsTempToNujit);
	this.groupBox32.Controls.Add(this.cBoxRprpCMStoCmsTemp);
	this.groupBox32.Controls.Add(this.btnRprp);
	this.groupBox32.Controls.Add(this.btnAutomateRprp);
	this.groupBox32.Location = new System.Drawing.Point(0, 0);
	this.groupBox32.Name = "groupBox32";
	this.groupBox32.Size = new System.Drawing.Size(224, 80);
	this.groupBox32.TabIndex = 37;
	this.groupBox32.TabStop = false;
	this.groupBox32.Text = "Rprp";
	this.toolTip1.SetToolTip(this.groupBox32, "Data will transfer from Rprp table");
	// 
	// cBoxRprpCmsTempToNujit
	// 
	this.cBoxRprpCmsTempToNujit.Enabled = false;
	this.cBoxRprpCmsTempToNujit.Location = new System.Drawing.Point(8, 48);
	this.cBoxRprpCmsTempToNujit.Name = "cBoxRprpCmsTempToNujit";
	this.cBoxRprpCmsTempToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxRprpCmsTempToNujit.TabIndex = 1;
	this.cBoxRprpCmsTempToNujit.Text = "CmsTemp to Nujit";
	// 
	// cBoxRprpCMStoCmsTemp
	// 
	this.cBoxRprpCMStoCmsTemp.Checked = true;
	this.cBoxRprpCMStoCmsTemp.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxRprpCMStoCmsTemp.Location = new System.Drawing.Point(8, 24);
	this.cBoxRprpCMStoCmsTemp.Name = "cBoxRprpCMStoCmsTemp";
	this.cBoxRprpCMStoCmsTemp.Size = new System.Drawing.Size(128, 16);
	this.cBoxRprpCMStoCmsTemp.TabIndex = 0;
	this.cBoxRprpCMStoCmsTemp.Text = "As400 to CmsTemp";
	// 
	// btnRprp
	// 
	this.btnRprp.Location = new System.Drawing.Point(144, 16);
	this.btnRprp.Name = "btnRprp";
	this.btnRprp.Size = new System.Drawing.Size(72, 23);
	this.btnRprp.TabIndex = 0;
	this.btnRprp.Text = "Transfer";
	this.btnRprp.Click += new System.EventHandler(this.btnRprp_Click);
	// 
	// btnAutomateRprp
	// 
	this.btnAutomateRprp.Enabled = false;
	this.btnAutomateRprp.Location = new System.Drawing.Point(144, 48);
	this.btnAutomateRprp.Name = "btnAutomateRprp";
	this.btnAutomateRprp.Size = new System.Drawing.Size(72, 23);
	this.btnAutomateRprp.TabIndex = 34;
	this.btnAutomateRprp.Text = "Automate";
	// 
	// groupBox33
	// 
	this.groupBox33.Controls.Add(this.checkBox23);
	this.groupBox33.Controls.Add(this.checkBox24);
	this.groupBox33.Controls.Add(this.button24);
	this.groupBox33.Controls.Add(this.button25);
	this.groupBox33.Location = new System.Drawing.Point(0, 88);
	this.groupBox33.Name = "groupBox33";
	this.groupBox33.Size = new System.Drawing.Size(224, 80);
	this.groupBox33.TabIndex = 35;
	this.groupBox33.TabStop = false;
	this.groupBox33.Text = " LbHist";
	this.toolTip1.SetToolTip(this.groupBox33, "Data will transfer from LbHist tables");
	// 
	// checkBox23
	// 
	this.checkBox23.Checked = true;
	this.checkBox23.CheckState = System.Windows.Forms.CheckState.Checked;
	this.checkBox23.Location = new System.Drawing.Point(8, 48);
	this.checkBox23.Name = "checkBox23";
	this.checkBox23.Size = new System.Drawing.Size(120, 16);
	this.checkBox23.TabIndex = 1;
	this.checkBox23.Text = "CmsTemp to Nujit";
	// 
	// checkBox24
	// 
	this.checkBox24.Checked = true;
	this.checkBox24.CheckState = System.Windows.Forms.CheckState.Checked;
	this.checkBox24.Location = new System.Drawing.Point(8, 24);
	this.checkBox24.Name = "checkBox24";
	this.checkBox24.Size = new System.Drawing.Size(136, 16);
	this.checkBox24.TabIndex = 0;
	this.checkBox24.Text = "As400 to CmsTemp";
	// 
	// button24
	// 
	this.button24.Location = new System.Drawing.Point(144, 16);
	this.button24.Name = "button24";
	this.button24.Size = new System.Drawing.Size(72, 23);
	this.button24.TabIndex = 0;
	this.button24.Text = "Transfer";
	// 
	// button25
	// 
	this.button25.Location = new System.Drawing.Point(144, 48);
	this.button25.Name = "button25";
	this.button25.Size = new System.Drawing.Size(72, 23);
	this.button25.TabIndex = 34;
	this.button25.Text = "Automate";
	// 
	// checkBox25
	// 
	this.checkBox25.Checked = true;
	this.checkBox25.CheckState = System.Windows.Forms.CheckState.Checked;
	this.checkBox25.Location = new System.Drawing.Point(8, 48);
	this.checkBox25.Name = "checkBox25";
	this.checkBox25.Size = new System.Drawing.Size(120, 16);
	this.checkBox25.TabIndex = 1;
	this.checkBox25.Text = "CmsTemp to Nujit";
	// 
	// checkBox26
	// 
	this.checkBox26.Checked = true;
	this.checkBox26.CheckState = System.Windows.Forms.CheckState.Checked;
	this.checkBox26.Location = new System.Drawing.Point(8, 24);
	this.checkBox26.Name = "checkBox26";
	this.checkBox26.Size = new System.Drawing.Size(136, 16);
	this.checkBox26.TabIndex = 0;
	this.checkBox26.Text = "As400 to CmsTemp";
	// 
	// button26
	// 
	this.button26.Location = new System.Drawing.Point(144, 16);
	this.button26.Name = "button26";
	this.button26.Size = new System.Drawing.Size(72, 23);
	this.button26.TabIndex = 0;
	this.button26.Text = "Transfer";
	// 
	// button27
	// 
	this.button27.Location = new System.Drawing.Point(144, 48);
	this.button27.Name = "button27";
	this.button27.Size = new System.Drawing.Size(72, 23);
	this.button27.TabIndex = 34;
	this.button27.Text = "Automate";
	// 
	// groupBox34
	// 
	this.groupBox34.Controls.Add(this.mthlAutomateButton);
	this.groupBox34.Controls.Add(this.cBoxMthlCmsToNujit);
	this.groupBox34.Controls.Add(this.cBoxMthlAS400ToCms);
	this.groupBox34.Controls.Add(this.mthlTransferButton);
	this.groupBox34.Location = new System.Drawing.Point(264, 16);
	this.groupBox34.Name = "groupBox34";
	this.groupBox34.Size = new System.Drawing.Size(224, 80);
	this.groupBox34.TabIndex = 35;
	this.groupBox34.TabStop = false;
	this.groupBox34.Text = "Method File - Tooling";
	this.toolTip1.SetToolTip(this.groupBox34, "Data will be transferred from Customer and Vendor Files  (Cust and Vend)");
	// 
	// mthlAutomateButton
	// 
	this.mthlAutomateButton.Location = new System.Drawing.Point(144, 48);
	this.mthlAutomateButton.Name = "mthlAutomateButton";
	this.mthlAutomateButton.Size = new System.Drawing.Size(72, 23);
	this.mthlAutomateButton.TabIndex = 34;
	this.mthlAutomateButton.Text = "Automate";
	this.mthlAutomateButton.Click += new System.EventHandler(this.mthlAutomateButton_Click);
	// 
	// cBoxMthlCmsToNujit
	// 
	this.cBoxMthlCmsToNujit.Checked = true;
	this.cBoxMthlCmsToNujit.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxMthlCmsToNujit.Location = new System.Drawing.Point(16, 48);
	this.cBoxMthlCmsToNujit.Name = "cBoxMthlCmsToNujit";
	this.cBoxMthlCmsToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxMthlCmsToNujit.TabIndex = 1;
	this.cBoxMthlCmsToNujit.Text = "CmsTemp to Nujit";
	// 
	// cBoxMthlAS400ToCms
	// 
	this.cBoxMthlAS400ToCms.Checked = true;
	this.cBoxMthlAS400ToCms.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxMthlAS400ToCms.Location = new System.Drawing.Point(16, 24);
	this.cBoxMthlAS400ToCms.Name = "cBoxMthlAS400ToCms";
	this.cBoxMthlAS400ToCms.Size = new System.Drawing.Size(128, 16);
	this.cBoxMthlAS400ToCms.TabIndex = 0;
	this.cBoxMthlAS400ToCms.Text = "As400 to CmsTemp";
	// 
	// mthlTransferButton
	// 
	this.mthlTransferButton.Location = new System.Drawing.Point(144, 16);
	this.mthlTransferButton.Name = "mthlTransferButton";
	this.mthlTransferButton.Size = new System.Drawing.Size(72, 23);
	this.mthlTransferButton.TabIndex = 4;
	this.mthlTransferButton.Text = "Transfer";
	this.mthlTransferButton.Click += new System.EventHandler(this.mthlTransferButton_Click);
	// 
	// groupBox35
	// 
	this.groupBox35.Controls.Add(this.tmstAutomateButton);
	this.groupBox35.Controls.Add(this.cBoxTmstCmsToNujit);
	this.groupBox35.Controls.Add(this.cBoxTmstAS400ToCms);
	this.groupBox35.Controls.Add(this.tmstTransferButton);
	this.groupBox35.Location = new System.Drawing.Point(264, 104);
	this.groupBox35.Name = "groupBox35";
	this.groupBox35.Size = new System.Drawing.Size(224, 80);
	this.groupBox35.TabIndex = 36;
	this.groupBox35.TabStop = false;
	this.groupBox35.Text = "Tool Master File";
	this.toolTip1.SetToolTip(this.groupBox35, "Data will be transferred from Customer and Vendor Files  (Cust and Vend)");
	// 
	// tmstAutomateButton
	// 
	this.tmstAutomateButton.Location = new System.Drawing.Point(144, 48);
	this.tmstAutomateButton.Name = "tmstAutomateButton";
	this.tmstAutomateButton.Size = new System.Drawing.Size(72, 23);
	this.tmstAutomateButton.TabIndex = 34;
	this.tmstAutomateButton.Text = "Automate";
	this.tmstAutomateButton.Click += new System.EventHandler(this.tmstAutomateButton_Click);
	// 
	// cBoxTmstCmsToNujit
	// 
	this.cBoxTmstCmsToNujit.Checked = true;
	this.cBoxTmstCmsToNujit.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxTmstCmsToNujit.Location = new System.Drawing.Point(16, 48);
	this.cBoxTmstCmsToNujit.Name = "cBoxTmstCmsToNujit";
	this.cBoxTmstCmsToNujit.Size = new System.Drawing.Size(120, 16);
	this.cBoxTmstCmsToNujit.TabIndex = 1;
	this.cBoxTmstCmsToNujit.Text = "CmsTemp to Nujit";
	// 
	// cBoxTmstAS400ToCms
	// 
	this.cBoxTmstAS400ToCms.Checked = true;
	this.cBoxTmstAS400ToCms.CheckState = System.Windows.Forms.CheckState.Checked;
	this.cBoxTmstAS400ToCms.Location = new System.Drawing.Point(16, 24);
	this.cBoxTmstAS400ToCms.Name = "cBoxTmstAS400ToCms";
	this.cBoxTmstAS400ToCms.Size = new System.Drawing.Size(128, 16);
	this.cBoxTmstAS400ToCms.TabIndex = 0;
	this.cBoxTmstAS400ToCms.Text = "As400 to CmsTemp";
	// 
	// tmstTransferButton
	// 
	this.tmstTransferButton.Location = new System.Drawing.Point(144, 16);
	this.tmstTransferButton.Name = "tmstTransferButton";
	this.tmstTransferButton.Size = new System.Drawing.Size(72, 23);
	this.tmstTransferButton.TabIndex = 4;
	this.tmstTransferButton.Text = "Transfer";
	this.tmstTransferButton.Click += new System.EventHandler(this.tmstTransferButton_Click);
	// 
	// tabControl1
	// 
	this.tabControl1.Controls.Add(this.tabPage2);
	this.tabControl1.Controls.Add(this.tabPage4);
	this.tabControl1.Controls.Add(this.tabPage3);
	this.tabControl1.Controls.Add(this.tabPage1);
	this.tabControl1.Location = new System.Drawing.Point(8, 16);
	this.tabControl1.Name = "tabControl1";
	this.tabControl1.SelectedIndex = 0;
	this.tabControl1.Size = new System.Drawing.Size(740, 408);
	this.tabControl1.TabIndex = 18;
	// 
	// tabPage2
	// 
	this.tabPage2.Controls.Add(this.groupBox15);
	this.tabPage2.Controls.Add(this.groupBox1);
	this.tabPage2.Controls.Add(this.groupBox3);
	this.tabPage2.Controls.Add(this.groupBox9);
	this.tabPage2.Location = new System.Drawing.Point(4, 22);
	this.tabPage2.Name = "tabPage2";
	this.tabPage2.Size = new System.Drawing.Size(732, 382);
	this.tabPage2.TabIndex = 1;
	this.tabPage2.Text = "Items";
	// 
	// tabPage4
	// 
	this.tabPage4.Controls.Add(this.groupBox30);
	this.tabPage4.Controls.Add(this.groupBox26);
	this.tabPage4.Controls.Add(this.groupBox20);
	this.tabPage4.Controls.Add(this.groupBox21);
	this.tabPage4.Controls.Add(this.groupBox22);
	this.tabPage4.Controls.Add(this.groupBox10);
	this.tabPage4.Controls.Add(this.groupBox11);
	this.tabPage4.Controls.Add(this.groupBox7);
	this.tabPage4.Controls.Add(this.groupBox8);
	this.tabPage4.Location = new System.Drawing.Point(4, 22);
	this.tabPage4.Name = "tabPage4";
	this.tabPage4.Size = new System.Drawing.Size(732, 382);
	this.tabPage4.TabIndex = 3;
	this.tabPage4.Text = "History";
	// 
	// tabPage3
	// 
	this.tabPage3.Controls.Add(this.groupBox16);
	this.tabPage3.Controls.Add(this.groupBox14);
	this.tabPage3.Controls.Add(this.groupBox13);
	this.tabPage3.Controls.Add(this.groupBox5);
	this.tabPage3.Controls.Add(this.groupBox4);
	this.tabPage3.Controls.Add(this.groupBox6);
	this.tabPage3.Location = new System.Drawing.Point(4, 22);
	this.tabPage3.Name = "tabPage3";
	this.tabPage3.Size = new System.Drawing.Size(732, 382);
	this.tabPage3.TabIndex = 2;
	this.tabPage3.Text = "Inventory";
	// 
	// tabPage1
	// 
	this.tabPage1.Controls.Add(this.gBoxStockRooms);
	this.tabPage1.Controls.Add(this.gBoxMachines);
	this.tabPage1.Controls.Add(this.gBoxDepts);
	this.tabPage1.Controls.Add(this.gBoxSuppliers);
	this.tabPage1.Controls.Add(this.groupBox34);
	this.tabPage1.Controls.Add(this.groupBox35);
	this.tabPage1.Location = new System.Drawing.Point(4, 22);
	this.tabPage1.Name = "tabPage1";
	this.tabPage1.Size = new System.Drawing.Size(732, 382);
	this.tabPage1.TabIndex = 4;
	this.tabPage1.Text = "Infraestructure";
	// 
	// groupBox2
	// 
	this.groupBox2.Controls.Add(this.tabControl1);
	this.groupBox2.Location = new System.Drawing.Point(8, 8);
	this.groupBox2.Name = "groupBox2";
	this.groupBox2.Size = new System.Drawing.Size(757, 432);
	this.groupBox2.TabIndex = 19;
	this.groupBox2.TabStop = false;
	// 
	// groupBox12
	// 
	this.groupBox12.Controls.Add(this.btnClose);
	this.groupBox12.Location = new System.Drawing.Point(8, 440);
	this.groupBox12.Name = "groupBox12";
	this.groupBox12.Size = new System.Drawing.Size(758, 48);
	this.groupBox12.TabIndex = 20;
	this.groupBox12.TabStop = false;
	// 
	// btnClose
	// 
	this.btnClose.Location = new System.Drawing.Point(674, 16);
	this.btnClose.Name = "btnClose";
	this.btnClose.TabIndex = 21;
	this.btnClose.Text = "Close";
	this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
	// 
	// DataTransfer
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(776, 506);
	this.Controls.Add(this.groupBox12);
	this.Controls.Add(this.groupBox2);
	this.Controls.Add(this.statusBar);
	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	this.MaximumSize = new System.Drawing.Size(784, 540);
	this.MinimumSize = new System.Drawing.Size(784, 540);
	this.Name = "DataTransfer";
	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	this.Text = "Data Transfer";
	this.Closing += new System.ComponentModel.CancelEventHandler(this.DataTransfer_Closing);
	this.Closed += new System.EventHandler(this.OnClosed);
	((System.ComponentModel.ISupportInitialize)(this.statusBarPanelMessage)).EndInit();
	this.groupBox11.ResumeLayout(false);
	this.groupBox10.ResumeLayout(false);
	this.groupBox9.ResumeLayout(false);
	this.groupBox8.ResumeLayout(false);
	this.groupBox17.ResumeLayout(false);
	this.groupBox18.ResumeLayout(false);
	this.groupBox19.ResumeLayout(false);
	this.groupBox7.ResumeLayout(false);
	this.groupBox6.ResumeLayout(false);
	this.groupBox5.ResumeLayout(false);
	this.groupBox4.ResumeLayout(false);
	this.gBoxSuppliers.ResumeLayout(false);
	this.gBoxMachines.ResumeLayout(false);
	this.gBoxDepts.ResumeLayout(false);
	this.groupBox3.ResumeLayout(false);
	this.groupBox1.ResumeLayout(false);
	this.gBoxStockRooms.ResumeLayout(false);
	this.groupBox13.ResumeLayout(false);
	this.groupBox14.ResumeLayout(false);
	this.groupBox15.ResumeLayout(false);
	this.groupBox16.ResumeLayout(false);
	this.groupBox20.ResumeLayout(false);
	this.groupBox21.ResumeLayout(false);
	this.groupBox22.ResumeLayout(false);
	this.groupBox23.ResumeLayout(false);
	this.groupBox24.ResumeLayout(false);
	this.groupBox25.ResumeLayout(false);
	this.groupBox26.ResumeLayout(false);
	this.groupBox27.ResumeLayout(false);
	this.groupBox28.ResumeLayout(false);
	this.groupBox29.ResumeLayout(false);
	this.groupBox30.ResumeLayout(false);
	this.groupBox31.ResumeLayout(false);
	this.groupBox32.ResumeLayout(false);
	this.groupBox33.ResumeLayout(false);
	this.groupBox34.ResumeLayout(false);
	this.groupBox35.ResumeLayout(false);
	this.tabControl1.ResumeLayout(false);
	this.tabPage2.ResumeLayout(false);
	this.tabPage4.ResumeLayout(false);
	this.tabPage3.ResumeLayout(false);
	this.tabPage1.ResumeLayout(false);
	this.groupBox2.ResumeLayout(false);
	this.groupBox12.ResumeLayout(false);
	this.ResumeLayout(false);

}
#endregion
     
private 
void OnClosed(object sender, System.EventArgs e){
	this.coreFactory = null;
	this.Dispose();
}

private 
void btnItems_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;

		if ((cBoxItemsAs400ToCMS.Checked) && (cBoxItemsCmsToNujit.Checked)){
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			statusBar.Text	= "Copying products, please wait...";
			
			copied = coreFactory.generateCMSItems();

			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Items !!";
			
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
		
		if (cBoxItemsAs400ToCMS.Checked){
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			statusBar.Text	= "Copying items, please wait...";
			
			copied = coreFactory.cms400ToCmsTempItems();

			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Items !!";
		}

		if (cBoxItemsCmsToNujit.Checked){
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			statusBar.Text	= "Copying items, please wait...";
			
			copied = coreFactory.cmsTempToNujitItems();

			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Items !!";
		}

		MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
	}catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void btnFamilParts_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;
		if ((cBoxFamilyAS400ToCms.Checked) && (ckBoxFamilyCmsToNujit.Checked)){
			statusBar.Text	= "Copying family parts, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			
			copied = coreFactory.CMSFamilyCopy();
			
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done family parts !!";

			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
		
		if (cBoxFamilyAS400ToCms.Checked){
			statusBar.Text	= "Copying family parts, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			
			copied = coreFactory.cms400ToCmsTempFamily();
			
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done family parts !!";
		}
		
		if (ckBoxFamilyCmsToNujit.Checked){
			statusBar.Text	= "Copying family parts, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.cmsTempToNujitFamily();
			
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done family parts !!";
		}
		
		MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
	}catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void btnDeptsRecords_Click(object sender, System.EventArgs e){
	try{
		if ((cBoxDeptsAS400ToCms.Checked) && (cBoxDeptsCmsToNujit.Checked)){
			statusBar.Text	= "Copying Depts and Plants, please wait...";

			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			
			string[] recInsertDiscard = coreFactory.generateCMSDeptsRecords(); //depts to pltDepts
			int  counter = coreFactory.generateCMSPlt();//plnt to plt
			this.Cursor = System.Windows.Forms.Cursors.Default;
			
			statusBar.Text	= "Done! Depts and Plants !!";

			int inserted = 0;
			int discard = 0;
			if (recInsertDiscard.Length != 1){
				statusBar.Text	= "Done! Depts and Plants !!";
				
				this.Cursor = System.Windows.Forms.Cursors.Default;

				inserted = int.Parse(recInsertDiscard[0]);
				discard = int.Parse(recInsertDiscard[1]);
			
				DeptsInsertedDiscardForm deptsInsertedDiscard = new DeptsInsertedDiscardForm(inserted,discard,recInsertDiscard);
				deptsInsertedDiscard.ShowDialog();
			}else
				inserted = int.Parse(recInsertDiscard[0]);

			MessageBox.Show("Process completed !! " + inserted.ToString() + " items copied ...", "Information");
			return;
		}

		if (cBoxDeptsAS400ToCms.Checked){ //copy Depts from AS400 to Cmstemp
			statusBar.Text	= "Copying Depts and Plants, please wait...";

			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			
			int cc = coreFactory.cms400ToCmsTempDepts(); //Depts
			coreFactory.cms400ToCmsTempPlnt();  //Plnt
			
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done! Depts and Plants !!";
			
			MessageBox.Show("Process completed !! " + cc.ToString() + " items copied ...", "Information");
		}

		if (cBoxDeptsCmsToNujit.Checked){//Copy Depts from CmsTemp to Nujit
			statusBar.Text	= "Copying Depts and Plnt to Nujit, please wait...";

			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			
			string[] recInsertDiscard = coreFactory.cmsTempToNujitDepts();//Depts to Nujit
			
			coreFactory.cmsTempToNujitPlt(); //Plnt to Nujit
			
			int inserted = 0;
			int discard = 0;
			if (!recInsertDiscard.Equals(null)){
				if (recInsertDiscard.Length != 1){
					statusBar.Text	= "Done! Depts and Plants !!";

					this.Cursor = System.Windows.Forms.Cursors.Default;

					inserted = int.Parse(recInsertDiscard[0]);
					discard = int.Parse(recInsertDiscard[1]);
				
					DeptsInsertedDiscardForm deptsInsertedDiscard = new DeptsInsertedDiscardForm(inserted,discard,recInsertDiscard);
					deptsInsertedDiscard.ShowDialog();
				}else
					inserted = int.Parse(recInsertDiscard[0]);

				MessageBox.Show("Process completed !! " + inserted.ToString() + " items copied ...", "Information");
			}else{
				MessageBox.Show("Depts records could not be generated.");	
				this.Cursor = System.Windows.Forms.Cursors.Default;
				statusBar.Text	= "Depts and Plants could not be generated !!";
			}
		}
	}catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void machButton_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;
		if ((cBoxmachCmsToNujit.Checked) && (cBoxMachAS400ToCms.Checked)){
			statusBar.Text	= "Copying Machines, please wait...";
			
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.generateCMSMachineRecords();
				
			this.Cursor = System.Windows.Forms.Cursors.Default;

			statusBar.Text	= "Done, Machines !!";

			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
		
		if (cBoxMachAS400ToCms.Checked){
			statusBar.Text	= "Copying Machines, please wait...";
			
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.cms400ToCmsTempMachines();
				
			this.Cursor = System.Windows.Forms.Cursors.Default;

			statusBar.Text	= "Done, Machines !!";
		}
		
		if (cBoxmachCmsToNujit.Checked){
			statusBar.Text	= "Copying Machines, please wait...";
			
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.cmsTempToNujitMachines();
				
			this.Cursor = System.Windows.Forms.Cursors.Default;

			statusBar.Text	= "Done, Machines !!";
		}
	
		MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
	}catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void btnStkr_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;

		if ((this.cboxStkrAsToCms.Checked) && (this.cBoxStkrCmsToNujit.Checked)){//transfer from as400 to Nujit
			statusBar.Text	= "Copying Stkr to CMSTemp, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.generateCMSStkr();

			statusBar.Text	= "Done Stkr !!";
			this.Cursor = System.Windows.Forms.Cursors.Default;

			MessageBox.Show("Process completed !! " + copied.ToString() + " items copied ...", "Information");
			return;
		}

		if (this.cboxStkrAsToCms.Checked){//transfer from as400 to Cmstemp
			statusBar.Text	= "Copying Stkr, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.cms400ToCmsTempStkr();

			statusBar.Text	= "Done Stkr !!";
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		if (this.cBoxStkrCmsToNujit.Checked){//transfer from Cmstemp to Nujit
			statusBar.Text	= "Copying Stkr, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.cmsTempToNujitStkr();

			statusBar.Text	= "Done Stkr !!";
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		
		MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
	}catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void personsButton_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;

		if ((this.ckBoxSuppCmsToNujit.Checked) && (this.ckBoxSuppAS400ToCms.Checked)){
			statusBar.Text	= "Copying Suppliers, please wait...";
		
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			
			copied = coreFactory.generateCustVend();

			statusBar.Text	= "Done Suppliers !!";
		
			this.Cursor = System.Windows.Forms.Cursors.Default;
		
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}

		if (this.ckBoxSuppAS400ToCms.Checked){
			statusBar.Text	= "Copying Suppliers, please wait...";
		
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			
			//Copy from AS400 to Cmstemp
			copied = coreFactory.cms400ToCmsTempCust();
			copied += coreFactory.cms400ToCmsTempVend();

			statusBar.Text	= "Done Suppliers !!";
		
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		
		if (this.ckBoxSuppCmsToNujit.Checked){
			statusBar.Text	= "Copying Suppliers, please wait...";
		
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			//Copy from CmsTemp to Nujit
			copied = coreFactory.cmsTempToNujitCustVend();

			statusBar.Text	= "Done Suppliers !!";
		
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		
		MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
	}catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void cboxStkrAsToCms_CheckedChanged(object sender, System.EventArgs e){
	if ((!this.cboxStkrAsToCms.Checked)&&(!this.cBoxStkrCmsToNujit.Checked))
		this.btnStkr.Enabled = false;
	else
		this.btnStkr.Enabled = true;
}

private 
void cBoxStkrCmsToNujit_CheckedChanged(object sender, System.EventArgs e){
	if ((!this.cboxStkrAsToCms.Checked)&&(!this.cBoxStkrCmsToNujit.Checked))
		this.btnStkr.Enabled = false;
	else
		this.btnStkr.Enabled = true;
}

private
void cBoxItemsAs400ToCMS_CheckedChanged(object sender, System.EventArgs e){
	if ((!this.cBoxItemsAs400ToCMS.Checked)&&(!this.cBoxItemsCmsToNujit.Checked))
		this.btnItems.Enabled = false;
	else
		this.btnItems.Enabled = true;
}

private 
void cBoxItemsCmsToNujit_CheckedChanged(object sender, System.EventArgs e){
	if ((!this.cBoxItemsAs400ToCMS.Checked)&&(!this.cBoxItemsCmsToNujit.Checked))
		this.btnItems.Enabled = false;
	else
		this.btnItems.Enabled = true;
}

private 
void cBoxFamilyAS400ToCms_CheckedChanged(object sender, System.EventArgs e){
	if ((!this.cBoxFamilyAS400ToCms.Checked)&&(!this.ckBoxFamilyCmsToNujit.Checked))
		this.btnFamilParts.Enabled=false;
	else
		this.btnFamilParts.Enabled=true;
}

private 
void cBoxDeptsAS400ToCms_CheckedChanged(object sender, System.EventArgs e){
	if ((!this.cBoxDeptsAS400ToCms.Checked)&&(!this.cBoxDeptsCmsToNujit.Checked))
		this.btnDeptsRecords.Enabled=false;
	else
		this.btnDeptsRecords.Enabled=true;
}

private 
void cBoxDeptsCmsToNujit_CheckedChanged(object sender, System.EventArgs e){
	if ((!this.cBoxDeptsAS400ToCms.Checked)&&(!this.cBoxDeptsCmsToNujit.Checked))
		this.btnDeptsRecords.Enabled=false;
	else
		this.btnDeptsRecords.Enabled=true;
}

private 
void cBoxMachAS400ToCms_CheckedChanged(object sender, System.EventArgs e){
	if ((!this.cBoxMachAS400ToCms.Checked)&&(!this.cBoxmachCmsToNujit.Checked))
		this.machButton.Enabled=false;
	else
		this.machButton.Enabled=true;
}

private 
void cBoxmachCmsToNujit_CheckedChanged(object sender, System.EventArgs e){
	if ((!this.cBoxMachAS400ToCms.Checked)&&(!this.cBoxmachCmsToNujit.Checked))
		this.machButton.Enabled = false;
	else
		this.machButton.Enabled=true;
}

private 
void ckBoxSuppAS400ToCms_CheckedChanged(object sender, System.EventArgs e){
	if ((!this.ckBoxSuppAS400ToCms.Checked)&&(!this.ckBoxSuppCmsToNujit.Checked))
		this.personsButton.Enabled=false;
	else
		this.personsButton.Enabled=true;
}

private 
void ckBoxSuppCmsToNujit_CheckedChanged(object sender, System.EventArgs e){
	if ((!this.ckBoxSuppAS400ToCms.Checked)&&(!this.ckBoxSuppCmsToNujit.Checked))
		this.personsButton.Enabled=false;
	else
		this.personsButton.Enabled=true;
}

private 
void ckBoxFamilyCmsToNujit_CheckedChanged(object sender, System.EventArgs e){
	if ((!this.cBoxFamilyAS400ToCms.Checked) && (!this.ckBoxFamilyCmsToNujit.Checked))
		this.btnFamilParts.Enabled = false;
	else
		this.btnFamilParts.Enabled = true;
}


private 
void cBoxShippingAs400ToCMS_CheckedChanged(object sender, System.EventArgs e){
if ((!this.cBoxShippingAs400ToCMS.Checked)&&(!this.cBoxShippingCmsToNujit.Checked))
		this.btnShipping.Enabled = false;
	else
		this.btnShipping.Enabled = true;
}

private 
void cBoxMaterialAs400ToCMS_CheckedChanged(object sender, System.EventArgs e){
if ((!this.cBoxMaterialAs400ToCMS.Checked)&&(!this.cBoxMaterialAs400ToNujit.Checked))
		this.btnMaterial.Enabled = false;
	else
		this.btnMaterial.Enabled = true;
}

private 
void cBoxMaterialAs400ToNujit_CheckedChanged(object sender, System.EventArgs e){
    if ((!this.cBoxMaterialAs400ToCMS.Checked)&&(!this.cBoxMaterialAs400ToNujit.Checked))
		this.btnMaterial.Enabled = false;
	else
		this.btnMaterial.Enabled = true;
}

private 
void cBoxCRefAs400ToCMS_CheckedChanged(object sender, System.EventArgs e) {
    if ((!this.cBoxCRefAs400ToCMS.Checked)&&(!this.cBoxCRefAs400ToNujit.Checked))
		this.btnCRef.Enabled = false;
	else
		this.btnCRef.Enabled = true;
}


private 
void btnCRef_Click_1(object sender, System.EventArgs e){
 try{
    int copied = 0;
    if ((this.cBoxCRefAs400ToCMS.Checked)&&(cBoxCRefAs400ToNujit.Checked)){
        statusBar.Text	= "Transfer Cross Reference , please wait...";
		this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
     
       copied = coreFactory.generateCMSTrlp();
        
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "Done Cross Reference!!";
		MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
		return;
    }
    
    if (cBoxCRefAs400ToCMS.Checked){
        statusBar.Text	= "Transfer Cross Reference , please wait...";
		this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
		
		copied = coreFactory.cms400ToCmsTempTrlp();
        	
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "Done Cross Reference!!";
		MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
		return;
     }
     if (cBoxCRefAs400ToNujit.Checked){
     statusBar.Text	= "Transfer Cross Reference, please wait...";
		this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
		
		copied = coreFactory.cmsTempToNujitTPPartCrossRef();
		
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "Done Cross Reference !!";
		MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
		return;
     }
    }catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void btnMaterial_Click_1(object sender, System.EventArgs e){
try{
	int copied = 0;

    if ((cBoxMaterialAs400ToNujit.Checked)&&(cBoxMaterialAs400ToCMS.Checked)){
        statusBar.Text	= "Transfer material releases , please wait...";
	    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
    		
	    copied = coreFactory.generateRRLToDelFor();
	    	
	    this.Cursor = System.Windows.Forms.Cursors.Default;
	    statusBar.Text	= "Done Material Releses Schedule !!";
	    MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
	    return;
    }

    if (this.cBoxMaterialAs400ToCMS.Checked){
        statusBar.Text	= "Transfer material releases, please wait...";
	    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
    		
	    copied = coreFactory.cms400ToCmsTempRrlh();
	    copied += coreFactory.cms400ToCmsTempRrld();
    		
	    this.Cursor = System.Windows.Forms.Cursors.Default;
	    statusBar.Text	= "Done metarial releases Schedule !!";
	    MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
	    return;
    }
    if (cBoxMaterialAs400ToNujit.Checked){
        statusBar.Text	= "Transfer material releases, please wait...";
	    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
	    copied = coreFactory.cmsTempToNujitDelFor();
	    this.Cursor = System.Windows.Forms.Cursors.Default;
	    statusBar.Text	= "Done material releases !!";
	    MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
	    return;
    }
    
}catch(NujitException ne){
	this.Cursor = System.Windows.Forms.Cursors.Default;
	statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
}
}

private 
void cBoxShippingCmsToNujit_CheckedChanged_1(object sender, System.EventArgs e){
    if ((!this.cBoxShippingAs400ToCMS.Checked)&&(!this.cBoxShippingCmsToNujit.Checked))
		this.btnShipping.Enabled = false;
	else
		this.btnShipping.Enabled = true;
}

private 
void cBoxMaterialAs400ToCMS_CheckedChanged_1(object sender, System.EventArgs e){
    if ((!this.cBoxMaterialAs400ToCMS.Checked)&&(!this.cBoxMaterialAs400ToNujit.Checked))
		this.btnMaterial.Enabled = false;
	else
		this.btnMaterial.Enabled = true;
}

private 
void cBoxMaterialAs400ToNujit_CheckedChanged_1(object sender, System.EventArgs e){
    if ((!this.cBoxMaterialAs400ToCMS.Checked)&&(!this.cBoxMaterialAs400ToNujit.Checked))
		this.btnMaterial.Enabled = false;
	else
		this.btnMaterial.Enabled = true;
}

private 
void cBoxCRefAs400ToCMS_CheckedChanged_1(object sender, System.EventArgs e){
    if ((!this.cBoxCRefAs400ToCMS.Checked)&&(!this.cBoxCRefAs400ToNujit.Checked))
		this.btnCRef.Enabled = false;
	else
		this.btnCRef.Enabled = true;
}

private 
void cBoxCRefAs400ToNujit_CheckedChanged_1(object sender, System.EventArgs e){
    if ((!this.cBoxCRefAs400ToCMS.Checked)&&(!this.cBoxCRefAs400ToNujit.Checked))
		this.btnCRef.Enabled = false;
	else
		this.btnCRef.Enabled = true;
}

private 
void btnShipping_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;
	    
		if ((cBoxShippingCmsToNujit.Checked)&&(cBoxShippingAs400ToCMS.Checked)){
			statusBar.Text	= "Transfer shipping Schedule, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				
			copied = coreFactory.generateCMSJitToDelJit();
			
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Shipping Schedule !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
	    
		if (cBoxShippingAs400ToCMS.Checked){
			statusBar.Text	= "Transfer shipping Schedule, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				
			copied = coreFactory.cms400ToCmsTempJith();
			copied += coreFactory.cms400ToCmsTempJitd();
				
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Shipping Schedule !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
		if (cBoxShippingCmsToNujit.Checked){
			statusBar.Text	= "Transfer shipping Schedule, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			copied = coreFactory.cmsTempToNujitDelJit();
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Shipping Schedule !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
    }catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void cBoxHistAs400ToCMS_CheckedChanged(object sender, System.EventArgs e){
    if ((!this.cBoxHistAs400ToCMS.Checked)&&(!this.cBoxHistAs400ToNujit.Checked))
        this.btnHist.Enabled = false;
    else
        this.btnHist.Enabled = true;
}

private 
void cBoxHistAs400ToNujit_CheckedChanged(object sender, System.EventArgs e) {
    if ((!this.cBoxHistAs400ToCMS.Checked)&&(!this.cBoxHistAs400ToNujit.Checked))
        this.btnHist.Enabled = false;
    else
        this.btnHist.Enabled = true;
}

private 
void btnHist_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;
		if ((cBoxHistAs400ToCMS.Checked)&&(cBoxHistAs400ToNujit.Checked)){
			statusBar.Text	= "Transfer PrHist to MeHistMachDtl, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
	     
			copied = coreFactory.generateCMSPrhist();
	      	
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done PrHist!!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
	    
		if (cBoxHistAs400ToCMS.Checked){
			statusBar.Text	= "Transfer PrHist, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			copied = coreFactory.cms400ToCmsTempPrhist();
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done  PrHist !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
		if (cBoxHistAs400ToNujit.Checked){
		statusBar.Text	= "Transfer PrHist to MeHistMachDtl , please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			
			copied = coreFactory.cmsTempToNujitMeHistMach();
			
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done PrHist  !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
    }catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}

}

private 
void cBoxLbHistAs400ToCMS_CheckedChanged(object sender, System.EventArgs e){
	if ((!this.cBoxLbHistAs400ToCMS.Checked)&&(!this.cBoxLbHistAs400ToNujit.Checked))
        this.btnLbHist.Enabled = false;
    else
        this.btnLbHist.Enabled = true;
}

private 
void cBoxLbHistAs400ToNujit_CheckedChanged(object sender, System.EventArgs e){
	if ((!this.cBoxLbHistAs400ToCMS.Checked)&&(!this.cBoxLbHistAs400ToNujit.Checked))
        this.btnLbHist.Enabled = false;
    else
        this.btnLbHist.Enabled = true;

}

private 
void btnLbHist_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;
		if ((cBoxLbHistAs400ToCMS.Checked)&&(cBoxLbHistAs400ToNujit.Checked)){
			statusBar.Text	= "Transfer LbHist to MeHistLabDtl, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			
			copied = coreFactory.generateCmsLbHist();

			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done LbHist!!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}

		if (cBoxLbHistAs400ToCMS.Checked){
			statusBar.Text	= "Transfer LbHist, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			copied = coreFactory.cms400ToCmsTempLbHist();	
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done  LbHist !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
		if (cBoxLbHistAs400ToNujit.Checked){
		statusBar.Text	= "Transfer LbHist to MeHistLabDtl , please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			
			copied = coreFactory.cmsTempToNujitMeHistLab();
			
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done LbHist  !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
    }catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";
		
		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void btnLbPssc_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;
		if ((cBoxPsscAs400ToCMS.Checked) && (cBoxPsscAs400ToNujit.Checked)){
			statusBar.Text	= "Transfering Pssc, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			
			copied = coreFactory.cms400ToNujitPssc();

			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Pssc !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}

		if (cBoxPsscAs400ToCMS.Checked){
			statusBar.Text	= "Transfer Pssc, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			copied = coreFactory.cms400ToCmsTempPssc();	
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done  Pssc !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}

		if (cBoxPsscAs400ToNujit.Checked){
			statusBar.Text	= "Transfering Pssc, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			
			copied = coreFactory.cmsTempToNujitPssc();
			
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Pssc !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
    }catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";
		
		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void btnScrap_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;
		if ((cBoxScrapCMStoCmsTemp.Checked) && (cBoxScrapCmsTempToNujit.Checked)){
			statusBar.Text	= "Transfering Scrap, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			
			copied = coreFactory.cms400ToNujitScrap();

			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Scrap !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}

		if (cBoxScrapCMStoCmsTemp.Checked){
			statusBar.Text	= "Transfer Scrap, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.cms400ToCmsTempScrap();	
			
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done  Scrap !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}

		if (cBoxScrapCmsTempToNujit.Checked){
			statusBar.Text	= "Transfering Scrap, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			
			copied = coreFactory.cmsTempToNujitScrap();
			
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Scrap !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
    }catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void button1_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;
		if ((cBoxSprsnCMStoCmsTemp.Checked) && (cBoxSprsnCmsTempToNujit.Checked)){
			statusBar.Text	= "Transfering Sprsn, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			
			copied = coreFactory.cms400ToNujitSprsn();

			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Sprsn !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}

		if (cBoxSprsnCMStoCmsTemp.Checked){
			statusBar.Text	= "Transfer Sprsn, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.cms400ToCmsTempSprsn();	
			
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Sprsn !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}

		if (cBoxSprsnCmsTempToNujit.Checked){
			statusBar.Text	= "Transfering Sprsn, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			
			copied = coreFactory.cmsTempToNujitSprsn();
			
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Sprsn !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
    }catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void btnClose_Click(object sender, System.EventArgs e){
	Dispose();
}

private 
void cBoxIcstmAs400ToCMS_CheckedChanged(object sender, System.EventArgs e){
    if ((!this.cBoxIcstmAs400ToCMS.Checked)&&(!this.cBoxIcstmCMSToNujit.Checked))
		this.btnIcstm.Enabled = false;
	else
		this.btnIcstm.Enabled = true;
}

private 
void cBoxIcstmCMSToNujit_CheckedChanged(object sender, System.EventArgs e){
    if ((!this.cBoxIcstmAs400ToCMS.Checked)&&(!this.cBoxIcstmCMSToNujit.Checked))
		this.btnIcstm.Enabled = false;
	else
		this.btnIcstm.Enabled = true;
}

private 
void cBoxIcstpAs400ToCMS_CheckedChanged(object sender, System.EventArgs e){
    if ((!this.cBoxIcstpAs400ToCMS.Checked)&&(!this.cBoxIcstpCMSToNujit.Checked))
		this.btnIcstp.Enabled = false;
	else
		this.btnIcstp.Enabled = true;
}

private 
void cBoxIcstpCMSToNujit_CheckedChanged(object sender, System.EventArgs e){
    if ((!this.cBoxIcstpAs400ToCMS.Checked)&&(!this.cBoxIcstpCMSToNujit.Checked))
		this.btnIcstp.Enabled = false;
	else
		this.btnIcstp.Enabled = true;
}

private 
void btnIcstm_Click(object sender, System.EventArgs e){
 try{
    int copied = 0;
    if ((this.cBoxIcstmAs400ToCMS.Checked)&&(this.cBoxIcstmCMSToNujit.Checked)){
        statusBar.Text	= "Transfer Icstm, please wait...";
		this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
     
       copied = coreFactory.generateCMSIcstm();
        
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "Done Icstm!!";
		MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
		return;
    }
    
    if (cBoxIcstmAs400ToCMS.Checked){
        statusBar.Text	= "Transfer Icstm , please wait...";
		this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
		
		copied = coreFactory.cms400ToCmsTempIcstm();
        	
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "Done Icstm!!";
		MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
		return;
     }
     if (cBoxIcstmCMSToNujit.Checked){
        statusBar.Text	= "Transfer Icstm, please wait...";
		this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
		
		copied = coreFactory.cmsTempToNujitIcstm();
		
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "Done Icstm !!";
		MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
		return;
     }
    }catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void btnIcstp_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;
		if ((this.cBoxIcstpAs400ToCMS.Checked)&&(this.cBoxIcstpCMSToNujit.Checked)){
			statusBar.Text	= "Transfer Icstp, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.generateCMSIcstp();

			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Icstp!!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
    
		if (cBoxIcstpAs400ToCMS.Checked){
			statusBar.Text	= "Transfer Icstp , please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.cms400ToCmsTempIcstp();
			    
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Icstp!!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}

		if (cBoxIcstpCMSToNujit.Checked){
			statusBar.Text	= "Transfer Icstp, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.cmsTempToNujitIcstp();

			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Icstp !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
	}catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void btnAutomatePrhist_Click(object sender, System.EventArgs e){
	string title = "Automate transfer - PRHIST";
	
	AutomateDateForm automateDateForm = new AutomateDateForm(title, Task.TASK_GENERATE_PRHIST);
	automateDateForm.ShowDialog();
}

private 
void btnAutomateScrap_Click(object sender, System.EventArgs e){
	string title = "Automate transfer - SCRAP";
	
	AutomateDateForm automateDateForm = new AutomateDateForm(title, Task.TASK_GENERATE_SCRAP);
	automateDateForm.ShowDialog();
}

private 
void btnAutomateSprsn_Click(object sender, System.EventArgs e){
	string title = "Automate transfer - SPRSN";
	
	AutomateDateForm automateDateForm = new AutomateDateForm(title, Task.TASK_GENERATE_SPRSN);
	automateDateForm.ShowDialog();
}

private 
void btnAutomateLbhist_Click(object sender, System.EventArgs e){
	string title = "Automate transfer - LBHIST";
	
	AutomateDateForm automateDateForm = new AutomateDateForm(title, Task.TASK_GENERATE_LBHIST);
	automateDateForm.ShowDialog();
}

private 
void btnAutomateItems_Click(object sender, System.EventArgs e){
	string title = "Automate transfer - Items";
	
	AutomateDateForm na = new AutomateDateForm(title, Task.TASK_GENERATE_ITEMS);
	na.ShowDialog();
}

private 
void btnAutomateFamilyParts_Click(object sender, System.EventArgs e){
	string title = "Automate transfer - Family Parts";
	
	AutomateDateForm automateDateForm = new AutomateDateForm(title, Task.TASK_GENERATE_FAMILYPARTS);
	automateDateForm.ShowDialog();
}

private 
void btnAutomatePssc_Click(object sender, System.EventArgs e){
	string title = "Automate transfer - Pssc";
	
	AutomateDateForm automateDateForm = new AutomateDateForm(title, Task.TASK_GENERATE_PSSC);
	automateDateForm.ShowDialog();
}

private 
void btnAutomateDepts_Click(object sender, System.EventArgs e){
	string title = "Automate transfer - Departaments";
	
	AutomateDateForm automateDateForm = new AutomateDateForm(title, Task.TASK_GENERATE_DEPTS);
	automateDateForm.ShowDialog();
}

private 
void btnAutomateMachines_Click(object sender, System.EventArgs e){
	string title = "Automate transfer - Machines";
	
	AutomateDateForm automateDateForm = new AutomateDateForm(title, Task.TASK_GENERATE_MACHINES);
	automateDateForm.ShowDialog();
}

private 
void btnAutomateStkr_Click(object sender, System.EventArgs e){
	string title = "Automate transfer - Stkr";
	
	AutomateDateForm automateDateForm = new AutomateDateForm(title, Task.TASK_GENERATE_STKR);
	automateDateForm.ShowDialog();

}

private 
void btnAutomateSuppliers_Click(object sender, System.EventArgs e){
	string title = "Automate transfer - Suppliers";
	
	AutomateDateForm automateDateForm = new AutomateDateForm(title, Task.TASK_GENERATE_SUPPLIERS);
	automateDateForm.ShowDialog();

}

private 
void btnAutomateShippingSch_Click(object sender, System.EventArgs e){
	string title = "Automate transfer - Schipping Schedule";
	
	AutomateDateForm automateDateForm = new AutomateDateForm(title, Task.TASK_GENERATE_SCHIPPING_SCHEDULE);
	automateDateForm.ShowDialog();
}

private 
void btnAutomateMatRelease_Click(object sender, System.EventArgs e){
	string title = "Automate transfer - Material Release";
	
	AutomateDateForm automateDateForm = new AutomateDateForm(title, Task.TASK_GENERATE_MAT_RELEASE);
	automateDateForm.ShowDialog();
}

private 
void btnAutomateEdiCrossRef_Click(object sender, System.EventArgs e){
	string title = "Automate transfer - Edi Cross Ref";
	
	AutomateDateForm automateDateForm = new AutomateDateForm(title, Task.TASK_GENERATE_EDI_CROSS_REF);
	automateDateForm.ShowDialog();
}

private 
void btnAutomateIcstm_Click(object sender, System.EventArgs e){
	string title = "Automate transfer - Icstm";
	
	AutomateDateForm automateDateForm = new AutomateDateForm(title, Task.TASK_GENERATE_ICSTM);
	automateDateForm.ShowDialog();
}

private 
void btnAutomateIcstp_Click(object sender, System.EventArgs e){
	string title = "Automate transfer - Icstp";
	
	AutomateDateForm automateDateForm = new AutomateDateForm(title, Task.TASK_GENERATE_ICSTP);
	automateDateForm.ShowDialog();
}

private
void DataTransfer_Closing(object sender, System.ComponentModel.CancelEventArgs e){
	this.coreFactory = null;
}

private 
void btnMmgp_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;
		if ((this.cBoxMmgpAs400ToCMS.Checked) && (cBoxMmgpAs400ToNujit.Checked)){
			statusBar.Text	= "Transfer Mmgp, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.generateCMSMmgp();

			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Mmgp!!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
    
		if (cBoxMmgpAs400ToCMS.Checked){
			statusBar.Text	= "Transfer Mmgp, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.cms400ToCmsTempMmgp();
			    
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Mmgp!!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}

		if (cBoxMmgpAs400ToNujit.Checked){
			statusBar.Text	= "Transfer Mmgp, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.cmsTempToNujitMmgp();

			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Mmgp !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
	}catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}
	
private 
void btnAutomateMmgp_Click(object sender, System.EventArgs e){
	string title = "Automate transfer - Mmgp";
	
	AutomateDateForm automateDateForm = new AutomateDateForm(title, Task.TASK_GENERATE_MMGP);
	automateDateForm.ShowDialog();
}

private 
void btnStkt_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;
		statusBar.Text	= "Transfer Stkt, please wait...";
		this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

		copied = coreFactory.generateCMSStkt();

		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "Done Stkt!!";
		MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
		return;
		
	}catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void btnRprd_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;
		if (cBoxRprdCMStoCmsTemp.Checked){
			statusBar.Text	= "Transfer Rprd, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.cms400ToCmsTempRprd();	
			
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Rprd !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
    }catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void btnRprr_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;
		if (cBoxRprrCMStoCmsTemp.Checked){
			statusBar.Text	= "Transfer Rprr, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.cms400ToCmsTempRprr();	
			
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Rprr !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
    }catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void btnRprs_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;
		if (cBoxRprsCMStoCmsTemp.Checked){
			statusBar.Text	= "Transfer Rprs, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.cms400ToCmsTempRprs();	
			
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Rprs !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
    }catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void btnRprh_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;
		if (cBoxRprhCMStoCmsTemp.Checked){
			statusBar.Text	= "Transfer Rprh, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.cms400ToCmsTempRprh();	
			
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Rprh !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
    }catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void btnRprp_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;
		if (cBoxRprpCMStoCmsTemp.Checked){
			statusBar.Text	= "Transfer Rprp, please wait...";
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

			copied = coreFactory.cms400ToCmsTempRprp();	
			
			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Rprp !!";
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
    }catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void mthlTransferButton_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;
		
		if ((cBoxMthlAS400ToCms.Checked) && (cBoxMthlCmsToNujit.Checked)){
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			statusBar.Text	= "Transfer Mthl, please wait...";
			
			copied = coreFactory.generateCMSMthl();

			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Items !!";
			
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
		
		if (cBoxMthlAS400ToCms.Checked){
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			statusBar.Text	= "Copying items, please wait...";
			
			copied = coreFactory.cms400ToCmsTempMthl();

			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Items !!";
		}

		if (cBoxMthlCmsToNujit.Checked){
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			statusBar.Text	= "Copying items, please wait...";
			
			copied = coreFactory.cmsTempToNujitMthl();

			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Items !!";
		}

		MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
	}catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void tmstTransferButton_Click(object sender, System.EventArgs e){
	try{
		int copied = 0;

		if ((cBoxTmstAS400ToCms.Checked) && (cBoxTmstCmsToNujit.Checked)){
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			statusBar.Text	= "Transfer Tmst, please wait...";
			
			copied = coreFactory.generateCMSTmst();

			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Items !!";
			
			MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
			return;
		}
		
		if (cBoxTmstAS400ToCms.Checked){
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			statusBar.Text	= "Copying items, please wait...";
			
			copied = coreFactory.cms400ToCmsTempTmst();

			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Items !!";
		}

		if (cBoxTmstCmsToNujit.Checked){
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			statusBar.Text	= "Copying items, please wait...";
			
			copied = coreFactory.cmsTempToNujitTmst();

			this.Cursor = System.Windows.Forms.Cursors.Default;
			statusBar.Text	= "Done Items !!";
		}

		MessageBox.Show("Process completed !!  " + copied.ToString() + " items copied ...", "Information");
	}catch(NujitException ne){
		this.Cursor = System.Windows.Forms.Cursors.Default;
		statusBar.Text	= "ERROR!";

		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
}

private 
void mthlAutomateButton_Click(object sender, System.EventArgs e){
	string title = "Automate transfer - MTHL";
	
	AutomateDateForm automateDateForm = new AutomateDateForm(title, Task.TASK_GENERATE_MTHL);
	automateDateForm.ShowDialog();
}

private 
void tmstAutomateButton_Click(object sender, System.EventArgs e){
	string title = "Automate transfer - TMST";
	
	AutomateDateForm automateDateForm = new AutomateDateForm(title, Task.TASK_GENERATE_TMST);
	automateDateForm.ShowDialog();
}


} // class
} // namespace
