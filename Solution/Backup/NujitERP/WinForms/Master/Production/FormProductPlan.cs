using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.WinForms.SearchForms;

namespace Nujit.NujitERP.WinForms.Master.Production{

/// <summary>
/// Summary description for FormProductPlan.
/// </summary>
public 
class FormProductPlan : System.Windows.Forms.Form{

private System.Windows.Forms.GroupBox groupBox6;
private System.Windows.Forms.Panel panel1;
private System.Windows.Forms.Button btnCancel;
private System.Windows.Forms.Button btnOk;
/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;
private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private System.Windows.Forms.Label labelSeq;
private System.Windows.Forms.TextBox txtProduct;
private System.Windows.Forms.Label labelstdPack;
private System.Windows.Forms.TextBox txtPackType;
private System.Windows.Forms.Label labelPackType;
private System.Windows.Forms.Label labelSkidQty;
private System.Windows.Forms.TextBox txtSkidQty;
private System.Windows.Forms.TextBox txtSkidType;
private System.Windows.Forms.Label labelSkidType;
private System.Windows.Forms.TextBox txtMinInv;
private System.Windows.Forms.Label labelMinInv;
private System.Windows.Forms.TextBox txtMaxInv;
private System.Windows.Forms.Label labelMaxInv;
private System.Windows.Forms.TextBox txtInvUom;
private System.Windows.Forms.Label labelInvUom;
private System.Windows.Forms.TextBox txtMinCon;
private System.Windows.Forms.Label labelMinCon;
private System.Windows.Forms.TextBox txtMaxCon;
private System.Windows.Forms.Label labelMaxCon;
private System.Windows.Forms.Label labelDohMin;
private System.Windows.Forms.TextBox txtDohMax;
private System.Windows.Forms.Label labelDohMax;
private System.Windows.Forms.TextBox txtPackWip;
private System.Windows.Forms.Label labelPackWip;
private System.Windows.Forms.TextBox txtContWip;
private System.Windows.Forms.Label labelContWip;
private System.Windows.Forms.TextBox txtTarRunQty;
private System.Windows.Forms.Label labelTarRunQty;
private System.Windows.Forms.TextBox txtColour;
private System.Windows.Forms.Label labelColour;
private System.Windows.Forms.TextBox txtDayLT;
private System.Windows.Forms.Label labelDayLT;
private System.Windows.Forms.TextBox txtHourLT;
private System.Windows.Forms.Label labelHourLT;
private System.Windows.Forms.TextBox txtDayLTCum;
private System.Windows.Forms.Label labelDayLTCum;
private System.Windows.Forms.TextBox txtHourLTCum;
private System.Windows.Forms.Label labelHourLTCum;

private System.Windows.Forms.TextBox txtStdPack;
private System.Windows.Forms.TextBox txtDohMin;
private System.Windows.Forms.Label labelProduct;
private System.Windows.Forms.TextBox txtBoxSeq;
private System.Windows.Forms.TabControl tabControl1;
private System.Windows.Forms.TabPage tabPage1;
private System.Windows.Forms.TabPage tabPage2;
private System.Windows.Forms.TabPage tabPage3;
private System.Windows.Forms.TabPage tabPage4;
private System.Windows.Forms.TabPage tabPage5;
private System.Windows.Forms.Label label1;
private System.Windows.Forms.Label label2;
private System.Windows.Forms.Label label3;
private System.Windows.Forms.ComboBox mainMaterialSeqTextBox;
private System.Windows.Forms.TextBox mainMaterialQtyTextBox;
private System.Windows.Forms.TextBox mainMaterialTextBox;
private System.Windows.Forms.Label label4;
private System.Windows.Forms.Label label6;
private System.Windows.Forms.Label label7;
private System.Windows.Forms.TextBox forecastTextBox;
private System.Windows.Forms.TextBox forecastTimeFenceTextBox;
private System.Windows.Forms.TextBox forecastExcludeAllocTextBox;
private System.Windows.Forms.Label label5;
private System.Windows.Forms.Label label8;
private System.Windows.Forms.Label label9;
private System.Windows.Forms.Label label10;
private System.Windows.Forms.Label label11;
private System.Windows.Forms.Label label12;
private System.Windows.Forms.Label label13;
private System.Windows.Forms.Label label14;
private System.Windows.Forms.TextBox mainToolTypeTextBox;
private System.Windows.Forms.TextBox mainToolQtyTextBox;
private System.Windows.Forms.TextBox schGroup1TextBox;
private System.Windows.Forms.TextBox schGroup2TxtBox;
private System.Windows.Forms.TextBox schGroup3TxtBox;
private System.Windows.Forms.TextBox schGroup6TxtBox;
private System.Windows.Forms.TextBox schGroup5TxtBox;
private System.Windows.Forms.TextBox schGroup4TxtBox;
private System.Windows.Forms.Label label15;
private System.Windows.Forms.Label label16;
private System.Windows.Forms.Label label17;
private System.Windows.Forms.Label label18;
private System.Windows.Forms.Label label19;
private System.Windows.Forms.Label label20;
private System.Windows.Forms.Label label23;
private System.Windows.Forms.Label label24;
private System.Windows.Forms.Label label25;
private System.Windows.Forms.Label label26;
private System.Windows.Forms.TextBox partToRunTextBox;
private System.Windows.Forms.TextBox batchOperationTextBox;
private System.Windows.Forms.TextBox reportingPointTextBox;
private System.Windows.Forms.TextBox scheduleWithNextOpTextBox;
private System.Windows.Forms.TextBox batchSizeTextBox;
private System.Windows.Forms.TextBox shortSetupTextBox;
private System.Windows.Forms.TextBox longSetupTextBox;
private System.Windows.Forms.TextBox transferToNextTextBox;
private System.Windows.Forms.TextBox daysInAdvanceTextBox;
private System.Windows.Forms.ComboBox qtySelectionComboBox;
private System.Windows.Forms.TabPage tabPage6;
private System.Windows.Forms.Label label28;
private System.Windows.Forms.Label label27;
private System.Windows.Forms.Label label22;
private System.Windows.Forms.Label label21;
private System.Windows.Forms.Label label29;
private System.Windows.Forms.Label label30;
private System.Windows.Forms.Label label31;
private System.Windows.Forms.GroupBox groupBox1;
private System.Windows.Forms.GroupBox groupBox2;
private System.Windows.Forms.Button seekMaterialButton;
private System.Windows.Forms.TextBox descMaterialTextBox;
private System.Windows.Forms.GroupBox groupBox3;
private System.Windows.Forms.GroupBox groupBox4;
private System.Windows.Forms.GroupBox groupBox5;
private System.Windows.Forms.ComboBox toolDependentComboBox;
private System.Windows.Forms.ComboBox machineDependentComboBox;
private System.Windows.Forms.ComboBox capacityRestrictComboBox;
private System.Windows.Forms.ComboBox laborDependentComboBox;
private System.Windows.Forms.ComboBox scheduleTypeComboBox;
private System.Windows.Forms.TextBox scheduleOrderTextBox;
private System.Windows.Forms.ComboBox processingLocationComboBox;
	private System.Windows.Forms.CheckBox checkBoxExcludeSaturday;
	private System.Windows.Forms.CheckBox checkBoxExcludeSunday;
private ProductPlan productPlan = null;

public 
FormProductPlan(string prod, string seq){
	InitializeComponent();

	productPlan = coreFactory.createProductPlan();
	this.txtProduct.Text = prod;
	this.txtBoxSeq.Text = seq;

	display();

}

protected override 
void Dispose(bool disposing){
	if (disposing){
		if (components != null){
			components.Dispose();
		}
	}
	base.Dispose(disposing);
}

#region Windows Form Designer generated code
private 
void InitializeComponent(){
	this.groupBox6 = new System.Windows.Forms.GroupBox();
	this.labelSeq = new System.Windows.Forms.Label();
	this.txtProduct = new System.Windows.Forms.TextBox();
	this.txtBoxSeq = new System.Windows.Forms.TextBox();
	this.labelProduct = new System.Windows.Forms.Label();
	this.panel1 = new System.Windows.Forms.Panel();
	this.btnCancel = new System.Windows.Forms.Button();
	this.btnOk = new System.Windows.Forms.Button();
	this.labelstdPack = new System.Windows.Forms.Label();
	this.txtStdPack = new System.Windows.Forms.TextBox();
	this.txtPackType = new System.Windows.Forms.TextBox();
	this.labelPackType = new System.Windows.Forms.Label();
	this.labelSkidQty = new System.Windows.Forms.Label();
	this.txtSkidQty = new System.Windows.Forms.TextBox();
	this.txtSkidType = new System.Windows.Forms.TextBox();
	this.labelSkidType = new System.Windows.Forms.Label();
	this.txtMinInv = new System.Windows.Forms.TextBox();
	this.labelMinInv = new System.Windows.Forms.Label();
	this.txtMaxInv = new System.Windows.Forms.TextBox();
	this.labelMaxInv = new System.Windows.Forms.Label();
	this.txtInvUom = new System.Windows.Forms.TextBox();
	this.labelInvUom = new System.Windows.Forms.Label();
	this.txtMinCon = new System.Windows.Forms.TextBox();
	this.labelMinCon = new System.Windows.Forms.Label();
	this.txtMaxCon = new System.Windows.Forms.TextBox();
	this.labelMaxCon = new System.Windows.Forms.Label();
	this.txtDohMin = new System.Windows.Forms.TextBox();
	this.labelDohMin = new System.Windows.Forms.Label();
	this.txtDohMax = new System.Windows.Forms.TextBox();
	this.labelDohMax = new System.Windows.Forms.Label();
	this.txtPackWip = new System.Windows.Forms.TextBox();
	this.labelPackWip = new System.Windows.Forms.Label();
	this.txtContWip = new System.Windows.Forms.TextBox();
	this.labelContWip = new System.Windows.Forms.Label();
	this.txtTarRunQty = new System.Windows.Forms.TextBox();
	this.labelTarRunQty = new System.Windows.Forms.Label();
	this.txtColour = new System.Windows.Forms.TextBox();
	this.labelColour = new System.Windows.Forms.Label();
	this.txtDayLT = new System.Windows.Forms.TextBox();
	this.labelDayLT = new System.Windows.Forms.Label();
	this.txtHourLT = new System.Windows.Forms.TextBox();
	this.labelHourLT = new System.Windows.Forms.Label();
	this.txtDayLTCum = new System.Windows.Forms.TextBox();
	this.labelDayLTCum = new System.Windows.Forms.Label();
	this.txtHourLTCum = new System.Windows.Forms.TextBox();
	this.labelHourLTCum = new System.Windows.Forms.Label();
	this.tabControl1 = new System.Windows.Forms.TabControl();
	this.tabPage1 = new System.Windows.Forms.TabPage();
	this.checkBoxExcludeSunday = new System.Windows.Forms.CheckBox();
	this.checkBoxExcludeSaturday = new System.Windows.Forms.CheckBox();
	this.tabPage6 = new System.Windows.Forms.TabPage();
	this.groupBox2 = new System.Windows.Forms.GroupBox();
	this.toolDependentComboBox = new System.Windows.Forms.ComboBox();
	this.label28 = new System.Windows.Forms.Label();
	this.machineDependentComboBox = new System.Windows.Forms.ComboBox();
	this.capacityRestrictComboBox = new System.Windows.Forms.ComboBox();
	this.label30 = new System.Windows.Forms.Label();
	this.label31 = new System.Windows.Forms.Label();
	this.label29 = new System.Windows.Forms.Label();
	this.laborDependentComboBox = new System.Windows.Forms.ComboBox();
	this.groupBox1 = new System.Windows.Forms.GroupBox();
	this.label27 = new System.Windows.Forms.Label();
	this.scheduleTypeComboBox = new System.Windows.Forms.ComboBox();
	this.scheduleOrderTextBox = new System.Windows.Forms.TextBox();
	this.label22 = new System.Windows.Forms.Label();
	this.label21 = new System.Windows.Forms.Label();
	this.processingLocationComboBox = new System.Windows.Forms.ComboBox();
	this.tabPage2 = new System.Windows.Forms.TabPage();
	this.qtySelectionComboBox = new System.Windows.Forms.ComboBox();
	this.daysInAdvanceTextBox = new System.Windows.Forms.TextBox();
	this.transferToNextTextBox = new System.Windows.Forms.TextBox();
	this.longSetupTextBox = new System.Windows.Forms.TextBox();
	this.shortSetupTextBox = new System.Windows.Forms.TextBox();
	this.batchSizeTextBox = new System.Windows.Forms.TextBox();
	this.scheduleWithNextOpTextBox = new System.Windows.Forms.TextBox();
	this.reportingPointTextBox = new System.Windows.Forms.TextBox();
	this.batchOperationTextBox = new System.Windows.Forms.TextBox();
	this.partToRunTextBox = new System.Windows.Forms.TextBox();
	this.label23 = new System.Windows.Forms.Label();
	this.label24 = new System.Windows.Forms.Label();
	this.label25 = new System.Windows.Forms.Label();
	this.label26 = new System.Windows.Forms.Label();
	this.label20 = new System.Windows.Forms.Label();
	this.label19 = new System.Windows.Forms.Label();
	this.label18 = new System.Windows.Forms.Label();
	this.label17 = new System.Windows.Forms.Label();
	this.label16 = new System.Windows.Forms.Label();
	this.label15 = new System.Windows.Forms.Label();
	this.tabPage3 = new System.Windows.Forms.TabPage();
	this.descMaterialTextBox = new System.Windows.Forms.TextBox();
	this.seekMaterialButton = new System.Windows.Forms.Button();
	this.mainMaterialTextBox = new System.Windows.Forms.TextBox();
	this.mainMaterialQtyTextBox = new System.Windows.Forms.TextBox();
	this.mainMaterialSeqTextBox = new System.Windows.Forms.ComboBox();
	this.label3 = new System.Windows.Forms.Label();
	this.label2 = new System.Windows.Forms.Label();
	this.label1 = new System.Windows.Forms.Label();
	this.tabPage4 = new System.Windows.Forms.TabPage();
	this.groupBox4 = new System.Windows.Forms.GroupBox();
	this.schGroup6TxtBox = new System.Windows.Forms.TextBox();
	this.schGroup5TxtBox = new System.Windows.Forms.TextBox();
	this.schGroup4TxtBox = new System.Windows.Forms.TextBox();
	this.schGroup3TxtBox = new System.Windows.Forms.TextBox();
	this.schGroup2TxtBox = new System.Windows.Forms.TextBox();
	this.schGroup1TextBox = new System.Windows.Forms.TextBox();
	this.label13 = new System.Windows.Forms.Label();
	this.label14 = new System.Windows.Forms.Label();
	this.label12 = new System.Windows.Forms.Label();
	this.label11 = new System.Windows.Forms.Label();
	this.label10 = new System.Windows.Forms.Label();
	this.label9 = new System.Windows.Forms.Label();
	this.groupBox3 = new System.Windows.Forms.GroupBox();
	this.mainToolQtyTextBox = new System.Windows.Forms.TextBox();
	this.mainToolTypeTextBox = new System.Windows.Forms.TextBox();
	this.label8 = new System.Windows.Forms.Label();
	this.label5 = new System.Windows.Forms.Label();
	this.tabPage5 = new System.Windows.Forms.TabPage();
	this.groupBox5 = new System.Windows.Forms.GroupBox();
	this.forecastExcludeAllocTextBox = new System.Windows.Forms.TextBox();
	this.forecastTimeFenceTextBox = new System.Windows.Forms.TextBox();
	this.forecastTextBox = new System.Windows.Forms.TextBox();
	this.label7 = new System.Windows.Forms.Label();
	this.label6 = new System.Windows.Forms.Label();
	this.label4 = new System.Windows.Forms.Label();
	this.groupBox6.SuspendLayout();
	this.panel1.SuspendLayout();
	this.tabControl1.SuspendLayout();
	this.tabPage1.SuspendLayout();
	this.tabPage6.SuspendLayout();
	this.groupBox2.SuspendLayout();
	this.groupBox1.SuspendLayout();
	this.tabPage2.SuspendLayout();
	this.tabPage3.SuspendLayout();
	this.tabPage4.SuspendLayout();
	this.groupBox4.SuspendLayout();
	this.groupBox3.SuspendLayout();
	this.tabPage5.SuspendLayout();
	this.groupBox5.SuspendLayout();
	this.SuspendLayout();
	// 
	// groupBox6
	// 
	this.groupBox6.Controls.Add(this.labelSeq);
	this.groupBox6.Controls.Add(this.txtProduct);
	this.groupBox6.Controls.Add(this.txtBoxSeq);
	this.groupBox6.Controls.Add(this.labelProduct);
	this.groupBox6.Location = new System.Drawing.Point(24, 16);
	this.groupBox6.Name = "groupBox6";
	this.groupBox6.Size = new System.Drawing.Size(440, 88);
	this.groupBox6.TabIndex = 1;
	this.groupBox6.TabStop = false;
	this.groupBox6.Text = "Identification";
	// 
	// labelSeq
	// 
	this.labelSeq.Location = new System.Drawing.Point(200, 40);
	this.labelSeq.Name = "labelSeq";
	this.labelSeq.Size = new System.Drawing.Size(64, 16);
	this.labelSeq.TabIndex = 4;
	this.labelSeq.Text = "Sequence";
	// 
	// txtProduct
	// 
	this.txtProduct.Location = new System.Drawing.Point(56, 40);
	this.txtProduct.MaxLength = 40;
	this.txtProduct.Name = "txtProduct";
	this.txtProduct.ReadOnly = true;
	this.txtProduct.Size = new System.Drawing.Size(128, 20);
	this.txtProduct.TabIndex = 2;
	this.txtProduct.Text = "";
	// 
	// txtBoxSeq
	// 
	this.txtBoxSeq.Location = new System.Drawing.Point(272, 40);
	this.txtBoxSeq.Name = "txtBoxSeq";
	this.txtBoxSeq.ReadOnly = true;
	this.txtBoxSeq.Size = new System.Drawing.Size(104, 20);
	this.txtBoxSeq.TabIndex = 5;
	this.txtBoxSeq.Text = "";
	// 
	// labelProduct
	// 
	this.labelProduct.Location = new System.Drawing.Point(8, 40);
	this.labelProduct.Name = "labelProduct";
	this.labelProduct.Size = new System.Drawing.Size(48, 16);
	this.labelProduct.TabIndex = 43;
	this.labelProduct.Text = "Product";
	// 
	// panel1
	// 
	this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
	this.panel1.Controls.Add(this.btnCancel);
	this.panel1.Controls.Add(this.btnOk);
	this.panel1.Location = new System.Drawing.Point(8, 512);
	this.panel1.Name = "panel1";
	this.panel1.Size = new System.Drawing.Size(512, 40);
	this.panel1.TabIndex = 2;
	// 
	// btnCancel
	// 
	this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
	this.btnCancel.Location = new System.Drawing.Point(368, 8);
	this.btnCancel.Name = "btnCancel";
	this.btnCancel.TabIndex = 21;
	this.btnCancel.Text = "Close";
	this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
	// 
	// btnOk
	// 
	this.btnOk.Location = new System.Drawing.Point(280, 8);
	this.btnOk.Name = "btnOk";
	this.btnOk.TabIndex = 19;
	this.btnOk.Text = "Save";
	this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
	// 
	// labelstdPack
	// 
	this.labelstdPack.Location = new System.Drawing.Point(40, 152);
	this.labelstdPack.Name = "labelstdPack";
	this.labelstdPack.Size = new System.Drawing.Size(64, 16);
	this.labelstdPack.TabIndex = 5;
	this.labelstdPack.Text = "Std.Pack";
	// 
	// txtStdPack
	// 
	this.txtStdPack.Location = new System.Drawing.Point(120, 152);
	this.txtStdPack.Name = "txtStdPack";
	this.txtStdPack.TabIndex = 6;
	this.txtStdPack.Text = "";
	// 
	// txtPackType
	// 
	this.txtPackType.Location = new System.Drawing.Point(360, 160);
	this.txtPackType.Name = "txtPackType";
	this.txtPackType.TabIndex = 8;
	this.txtPackType.Text = "";
	// 
	// labelPackType
	// 
	this.labelPackType.Location = new System.Drawing.Point(272, 160);
	this.labelPackType.Name = "labelPackType";
	this.labelPackType.Size = new System.Drawing.Size(64, 16);
	this.labelPackType.TabIndex = 7;
	this.labelPackType.Text = "Pack Type";
	// 
	// labelSkidQty
	// 
	this.labelSkidQty.Location = new System.Drawing.Point(40, 176);
	this.labelSkidQty.Name = "labelSkidQty";
	this.labelSkidQty.Size = new System.Drawing.Size(64, 16);
	this.labelSkidQty.TabIndex = 9;
	this.labelSkidQty.Text = "Skid Qty";
	// 
	// txtSkidQty
	// 
	this.txtSkidQty.Location = new System.Drawing.Point(120, 176);
	this.txtSkidQty.Name = "txtSkidQty";
	this.txtSkidQty.TabIndex = 10;
	this.txtSkidQty.Text = "";
	// 
	// txtSkidType
	// 
	this.txtSkidType.Location = new System.Drawing.Point(360, 184);
	this.txtSkidType.Name = "txtSkidType";
	this.txtSkidType.TabIndex = 12;
	this.txtSkidType.Text = "";
	// 
	// labelSkidType
	// 
	this.labelSkidType.Location = new System.Drawing.Point(272, 184);
	this.labelSkidType.Name = "labelSkidType";
	this.labelSkidType.Size = new System.Drawing.Size(64, 16);
	this.labelSkidType.TabIndex = 11;
	this.labelSkidType.Text = "Skid Type";
	// 
	// txtMinInv
	// 
	this.txtMinInv.Location = new System.Drawing.Point(120, 200);
	this.txtMinInv.Name = "txtMinInv";
	this.txtMinInv.TabIndex = 14;
	this.txtMinInv.Text = "";
	// 
	// labelMinInv
	// 
	this.labelMinInv.Location = new System.Drawing.Point(40, 200);
	this.labelMinInv.Name = "labelMinInv";
	this.labelMinInv.Size = new System.Drawing.Size(72, 16);
	this.labelMinInv.TabIndex = 13;
	this.labelMinInv.Text = "Min Inventory";
	// 
	// txtMaxInv
	// 
	this.txtMaxInv.Location = new System.Drawing.Point(360, 208);
	this.txtMaxInv.Name = "txtMaxInv";
	this.txtMaxInv.TabIndex = 16;
	this.txtMaxInv.Text = "";
	// 
	// labelMaxInv
	// 
	this.labelMaxInv.Location = new System.Drawing.Point(272, 208);
	this.labelMaxInv.Name = "labelMaxInv";
	this.labelMaxInv.Size = new System.Drawing.Size(80, 16);
	this.labelMaxInv.TabIndex = 15;
	this.labelMaxInv.Text = "Max. Inventory";
	// 
	// txtInvUom
	// 
	this.txtInvUom.Location = new System.Drawing.Point(120, 224);
	this.txtInvUom.Name = "txtInvUom";
	this.txtInvUom.TabIndex = 18;
	this.txtInvUom.Text = "";
	// 
	// labelInvUom
	// 
	this.labelInvUom.Location = new System.Drawing.Point(40, 224);
	this.labelInvUom.Name = "labelInvUom";
	this.labelInvUom.Size = new System.Drawing.Size(80, 16);
	this.labelInvUom.TabIndex = 17;
	this.labelInvUom.Text = "Inventory Uom";
	// 
	// txtMinCon
	// 
	this.txtMinCon.Location = new System.Drawing.Point(120, 248);
	this.txtMinCon.Name = "txtMinCon";
	this.txtMinCon.TabIndex = 20;
	this.txtMinCon.Text = "";
	// 
	// labelMinCon
	// 
	this.labelMinCon.Location = new System.Drawing.Point(40, 248);
	this.labelMinCon.Name = "labelMinCon";
	this.labelMinCon.Size = new System.Drawing.Size(72, 16);
	this.labelMinCon.TabIndex = 19;
	this.labelMinCon.Text = "Min. Con.";
	// 
	// txtMaxCon
	// 
	this.txtMaxCon.Location = new System.Drawing.Point(360, 232);
	this.txtMaxCon.Name = "txtMaxCon";
	this.txtMaxCon.TabIndex = 22;
	this.txtMaxCon.Text = "";
	// 
	// labelMaxCon
	// 
	this.labelMaxCon.Location = new System.Drawing.Point(272, 232);
	this.labelMaxCon.Name = "labelMaxCon";
	this.labelMaxCon.Size = new System.Drawing.Size(72, 16);
	this.labelMaxCon.TabIndex = 21;
	this.labelMaxCon.Text = "Max. Con.";
	// 
	// txtDohMin
	// 
	this.txtDohMin.Location = new System.Drawing.Point(120, 272);
	this.txtDohMin.Name = "txtDohMin";
	this.txtDohMin.TabIndex = 24;
	this.txtDohMin.Text = "";
	// 
	// labelDohMin
	// 
	this.labelDohMin.Location = new System.Drawing.Point(40, 272);
	this.labelDohMin.Name = "labelDohMin";
	this.labelDohMin.Size = new System.Drawing.Size(72, 16);
	this.labelDohMin.TabIndex = 23;
	this.labelDohMin.Text = "Doh. Min.";
	// 
	// txtDohMax
	// 
	this.txtDohMax.Location = new System.Drawing.Point(360, 256);
	this.txtDohMax.Name = "txtDohMax";
	this.txtDohMax.TabIndex = 26;
	this.txtDohMax.Text = "";
	// 
	// labelDohMax
	// 
	this.labelDohMax.Location = new System.Drawing.Point(272, 256);
	this.labelDohMax.Name = "labelDohMax";
	this.labelDohMax.Size = new System.Drawing.Size(72, 16);
	this.labelDohMax.TabIndex = 25;
	this.labelDohMax.Text = "Doh. Max.";
	// 
	// txtPackWip
	// 
	this.txtPackWip.Location = new System.Drawing.Point(120, 296);
	this.txtPackWip.Name = "txtPackWip";
	this.txtPackWip.TabIndex = 28;
	this.txtPackWip.Text = "";
	// 
	// labelPackWip
	// 
	this.labelPackWip.Location = new System.Drawing.Point(40, 296);
	this.labelPackWip.Name = "labelPackWip";
	this.labelPackWip.Size = new System.Drawing.Size(72, 16);
	this.labelPackWip.TabIndex = 27;
	this.labelPackWip.Text = "Pack.Wip.";
	// 
	// txtContWip
	// 
	this.txtContWip.Location = new System.Drawing.Point(360, 280);
	this.txtContWip.Name = "txtContWip";
	this.txtContWip.TabIndex = 30;
	this.txtContWip.Text = "";
	// 
	// labelContWip
	// 
	this.labelContWip.Location = new System.Drawing.Point(272, 280);
	this.labelContWip.Name = "labelContWip";
	this.labelContWip.Size = new System.Drawing.Size(72, 16);
	this.labelContWip.TabIndex = 29;
	this.labelContWip.Text = "Cont.Wip.";
	// 
	// txtTarRunQty
	// 
	this.txtTarRunQty.Location = new System.Drawing.Point(120, 320);
	this.txtTarRunQty.Name = "txtTarRunQty";
	this.txtTarRunQty.TabIndex = 32;
	this.txtTarRunQty.Text = "";
	// 
	// labelTarRunQty
	// 
	this.labelTarRunQty.Location = new System.Drawing.Point(40, 320);
	this.labelTarRunQty.Name = "labelTarRunQty";
	this.labelTarRunQty.Size = new System.Drawing.Size(72, 16);
	this.labelTarRunQty.TabIndex = 31;
	this.labelTarRunQty.Text = "Tar.Run.Qty.";
	// 
	// txtColour
	// 
	this.txtColour.Location = new System.Drawing.Point(360, 304);
	this.txtColour.Name = "txtColour";
	this.txtColour.TabIndex = 34;
	this.txtColour.Text = "";
	// 
	// labelColour
	// 
	this.labelColour.Location = new System.Drawing.Point(272, 304);
	this.labelColour.Name = "labelColour";
	this.labelColour.Size = new System.Drawing.Size(72, 16);
	this.labelColour.TabIndex = 33;
	this.labelColour.Text = "Colour";
	// 
	// txtDayLT
	// 
	this.txtDayLT.Location = new System.Drawing.Point(120, 344);
	this.txtDayLT.Name = "txtDayLT";
	this.txtDayLT.TabIndex = 36;
	this.txtDayLT.Text = "";
	// 
	// labelDayLT
	// 
	this.labelDayLT.Location = new System.Drawing.Point(40, 344);
	this.labelDayLT.Name = "labelDayLT";
	this.labelDayLT.Size = new System.Drawing.Size(72, 16);
	this.labelDayLT.TabIndex = 35;
	this.labelDayLT.Text = "Day LT.";
	// 
	// txtHourLT
	// 
	this.txtHourLT.Location = new System.Drawing.Point(360, 328);
	this.txtHourLT.Name = "txtHourLT";
	this.txtHourLT.TabIndex = 38;
	this.txtHourLT.Text = "";
	// 
	// labelHourLT
	// 
	this.labelHourLT.Location = new System.Drawing.Point(280, 328);
	this.labelHourLT.Name = "labelHourLT";
	this.labelHourLT.Size = new System.Drawing.Size(72, 16);
	this.labelHourLT.TabIndex = 37;
	this.labelHourLT.Text = "Hour LT.";
	// 
	// txtDayLTCum
	// 
	this.txtDayLTCum.Enabled = false;
	this.txtDayLTCum.Location = new System.Drawing.Point(120, 368);
	this.txtDayLTCum.Name = "txtDayLTCum";
	this.txtDayLTCum.Size = new System.Drawing.Size(104, 20);
	this.txtDayLTCum.TabIndex = 40;
	this.txtDayLTCum.Text = "";
	// 
	// labelDayLTCum
	// 
	this.labelDayLTCum.Location = new System.Drawing.Point(40, 368);
	this.labelDayLTCum.Name = "labelDayLTCum";
	this.labelDayLTCum.Size = new System.Drawing.Size(80, 16);
	this.labelDayLTCum.TabIndex = 39;
	this.labelDayLTCum.Text = "Day. LT. Cum.";
	// 
	// txtHourLTCum
	// 
	this.txtHourLTCum.Location = new System.Drawing.Point(360, 352);
	this.txtHourLTCum.Name = "txtHourLTCum";
	this.txtHourLTCum.Size = new System.Drawing.Size(104, 20);
	this.txtHourLTCum.TabIndex = 42;
	this.txtHourLTCum.Text = "";
	// 
	// labelHourLTCum
	// 
	this.labelHourLTCum.Location = new System.Drawing.Point(272, 352);
	this.labelHourLTCum.Name = "labelHourLTCum";
	this.labelHourLTCum.Size = new System.Drawing.Size(80, 16);
	this.labelHourLTCum.TabIndex = 41;
	this.labelHourLTCum.Text = "Hour LT Cum";
	// 
	// tabControl1
	// 
	this.tabControl1.Controls.Add(this.tabPage1);
	this.tabControl1.Controls.Add(this.tabPage6);
	this.tabControl1.Controls.Add(this.tabPage2);
	this.tabControl1.Controls.Add(this.tabPage3);
	this.tabControl1.Controls.Add(this.tabPage4);
	this.tabControl1.Controls.Add(this.tabPage5);
	this.tabControl1.Location = new System.Drawing.Point(8, 8);
	this.tabControl1.Name = "tabControl1";
	this.tabControl1.SelectedIndex = 0;
	this.tabControl1.Size = new System.Drawing.Size(512, 480);
	this.tabControl1.TabIndex = 43;
	// 
	// tabPage1
	// 
	this.tabPage1.Controls.Add(this.checkBoxExcludeSunday);
	this.tabPage1.Controls.Add(this.checkBoxExcludeSaturday);
	this.tabPage1.Controls.Add(this.txtDayLT);
	this.tabPage1.Controls.Add(this.labelDayLT);
	this.tabPage1.Controls.Add(this.txtHourLT);
	this.tabPage1.Controls.Add(this.labelstdPack);
	this.tabPage1.Controls.Add(this.labelHourLT);
	this.tabPage1.Controls.Add(this.labelDayLTCum);
	this.tabPage1.Controls.Add(this.txtHourLTCum);
	this.tabPage1.Controls.Add(this.txtPackType);
	this.tabPage1.Controls.Add(this.labelPackType);
	this.tabPage1.Controls.Add(this.txtSkidQty);
	this.tabPage1.Controls.Add(this.txtSkidType);
	this.tabPage1.Controls.Add(this.labelSkidType);
	this.tabPage1.Controls.Add(this.labelSkidQty);
	this.tabPage1.Controls.Add(this.txtStdPack);
	this.tabPage1.Controls.Add(this.txtMinInv);
	this.tabPage1.Controls.Add(this.labelMinInv);
	this.tabPage1.Controls.Add(this.txtMaxInv);
	this.tabPage1.Controls.Add(this.labelHourLTCum);
	this.tabPage1.Controls.Add(this.txtDayLTCum);
	this.tabPage1.Controls.Add(this.labelTarRunQty);
	this.tabPage1.Controls.Add(this.txtContWip);
	this.tabPage1.Controls.Add(this.labelMaxInv);
	this.tabPage1.Controls.Add(this.txtInvUom);
	this.tabPage1.Controls.Add(this.labelInvUom);
	this.tabPage1.Controls.Add(this.labelMinCon);
	this.tabPage1.Controls.Add(this.labelMaxCon);
	this.tabPage1.Controls.Add(this.txtMaxCon);
	this.tabPage1.Controls.Add(this.txtDohMin);
	this.tabPage1.Controls.Add(this.labelDohMin);
	this.tabPage1.Controls.Add(this.txtDohMax);
	this.tabPage1.Controls.Add(this.labelDohMax);
	this.tabPage1.Controls.Add(this.txtPackWip);
	this.tabPage1.Controls.Add(this.labelPackWip);
	this.tabPage1.Controls.Add(this.labelContWip);
	this.tabPage1.Controls.Add(this.txtTarRunQty);
	this.tabPage1.Controls.Add(this.txtColour);
	this.tabPage1.Controls.Add(this.txtMinCon);
	this.tabPage1.Controls.Add(this.labelColour);
	this.tabPage1.Controls.Add(this.groupBox6);
	this.tabPage1.Location = new System.Drawing.Point(4, 22);
	this.tabPage1.Name = "tabPage1";
	this.tabPage1.Size = new System.Drawing.Size(504, 454);
	this.tabPage1.TabIndex = 0;
	this.tabPage1.Text = "Overall";
	// 
	// checkBoxExcludeSunday
	// 
	this.checkBoxExcludeSunday.Location = new System.Drawing.Point(160, 400);
	this.checkBoxExcludeSunday.Name = "checkBoxExcludeSunday";
	this.checkBoxExcludeSunday.Size = new System.Drawing.Size(120, 16);
	this.checkBoxExcludeSunday.TabIndex = 44;
	this.checkBoxExcludeSunday.Text = "Exclude Sunday";
	// 
	// checkBoxExcludeSaturday
	// 
	this.checkBoxExcludeSaturday.Location = new System.Drawing.Point(40, 400);
	this.checkBoxExcludeSaturday.Name = "checkBoxExcludeSaturday";
	this.checkBoxExcludeSaturday.Size = new System.Drawing.Size(112, 16);
	this.checkBoxExcludeSaturday.TabIndex = 43;
	this.checkBoxExcludeSaturday.Text = "Exclude Saturday";
	// 
	// tabPage6
	// 
	this.tabPage6.Controls.Add(this.groupBox2);
	this.tabPage6.Controls.Add(this.groupBox1);
	this.tabPage6.Location = new System.Drawing.Point(4, 22);
	this.tabPage6.Name = "tabPage6";
	this.tabPage6.Size = new System.Drawing.Size(504, 454);
	this.tabPage6.TabIndex = 5;
	this.tabPage6.Text = "General";
	// 
	// groupBox2
	// 
	this.groupBox2.Controls.Add(this.toolDependentComboBox);
	this.groupBox2.Controls.Add(this.label28);
	this.groupBox2.Controls.Add(this.machineDependentComboBox);
	this.groupBox2.Controls.Add(this.capacityRestrictComboBox);
	this.groupBox2.Controls.Add(this.label30);
	this.groupBox2.Controls.Add(this.label31);
	this.groupBox2.Controls.Add(this.label29);
	this.groupBox2.Controls.Add(this.laborDependentComboBox);
	this.groupBox2.Location = new System.Drawing.Point(24, 192);
	this.groupBox2.Name = "groupBox2";
	this.groupBox2.Size = new System.Drawing.Size(456, 168);
	this.groupBox2.TabIndex = 63;
	this.groupBox2.TabStop = false;
	// 
	// toolDependentComboBox
	// 
	this.toolDependentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.toolDependentComboBox.Items.AddRange(new object[] {
															   "Y",
															   "N"});
	this.toolDependentComboBox.Location = new System.Drawing.Point(216, 80);
	this.toolDependentComboBox.Name = "toolDependentComboBox";
	this.toolDependentComboBox.Size = new System.Drawing.Size(56, 21);
	this.toolDependentComboBox.TabIndex = 60;
	// 
	// label28
	// 
	this.label28.Location = new System.Drawing.Point(32, 32);
	this.label28.Name = "label28";
	this.label28.Size = new System.Drawing.Size(120, 16);
	this.label28.TabIndex = 50;
	this.label28.Text = "Labor Dependent";
	// 
	// machineDependentComboBox
	// 
	this.machineDependentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.machineDependentComboBox.Items.AddRange(new object[] {
																  "Y",
																  "N"});
	this.machineDependentComboBox.Location = new System.Drawing.Point(216, 56);
	this.machineDependentComboBox.Name = "machineDependentComboBox";
	this.machineDependentComboBox.Size = new System.Drawing.Size(56, 21);
	this.machineDependentComboBox.TabIndex = 59;
	// 
	// capacityRestrictComboBox
	// 
	this.capacityRestrictComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.capacityRestrictComboBox.Items.AddRange(new object[] {
																  "Y",
																  "N"});
	this.capacityRestrictComboBox.Location = new System.Drawing.Point(216, 104);
	this.capacityRestrictComboBox.Name = "capacityRestrictComboBox";
	this.capacityRestrictComboBox.Size = new System.Drawing.Size(56, 21);
	this.capacityRestrictComboBox.TabIndex = 61;
	// 
	// label30
	// 
	this.label30.Location = new System.Drawing.Point(32, 80);
	this.label30.Name = "label30";
	this.label30.Size = new System.Drawing.Size(120, 16);
	this.label30.TabIndex = 53;
	this.label30.Text = "Tool Depedentent";
	// 
	// label31
	// 
	this.label31.Location = new System.Drawing.Point(32, 104);
	this.label31.Name = "label31";
	this.label31.Size = new System.Drawing.Size(120, 16);
	this.label31.TabIndex = 52;
	this.label31.Text = "Capacity Restrict";
	// 
	// label29
	// 
	this.label29.Location = new System.Drawing.Point(32, 56);
	this.label29.Name = "label29";
	this.label29.Size = new System.Drawing.Size(120, 16);
	this.label29.TabIndex = 54;
	this.label29.Text = "Machine Dependent";
	// 
	// laborDependentComboBox
	// 
	this.laborDependentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.laborDependentComboBox.Items.AddRange(new object[] {
																"Y",
																"N"});
	this.laborDependentComboBox.Location = new System.Drawing.Point(216, 32);
	this.laborDependentComboBox.Name = "laborDependentComboBox";
	this.laborDependentComboBox.Size = new System.Drawing.Size(56, 21);
	this.laborDependentComboBox.TabIndex = 58;
	// 
	// groupBox1
	// 
	this.groupBox1.Controls.Add(this.label27);
	this.groupBox1.Controls.Add(this.scheduleTypeComboBox);
	this.groupBox1.Controls.Add(this.scheduleOrderTextBox);
	this.groupBox1.Controls.Add(this.label22);
	this.groupBox1.Controls.Add(this.label21);
	this.groupBox1.Controls.Add(this.processingLocationComboBox);
	this.groupBox1.Location = new System.Drawing.Point(24, 64);
	this.groupBox1.Name = "groupBox1";
	this.groupBox1.Size = new System.Drawing.Size(456, 112);
	this.groupBox1.TabIndex = 62;
	this.groupBox1.TabStop = false;
	// 
	// label27
	// 
	this.label27.Location = new System.Drawing.Point(24, 72);
	this.label27.Name = "label27";
	this.label27.Size = new System.Drawing.Size(120, 16);
	this.label27.TabIndex = 49;
	this.label27.Text = "Schedule Order";
	// 
	// scheduleTypeComboBox
	// 
	this.scheduleTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.scheduleTypeComboBox.Items.AddRange(new object[] {
															  "Repetitive Automotive",
															  "Repetitive",
															  "Make to Order",
															  "Make to Stock"});
	this.scheduleTypeComboBox.Location = new System.Drawing.Point(208, 48);
	this.scheduleTypeComboBox.Name = "scheduleTypeComboBox";
	this.scheduleTypeComboBox.Size = new System.Drawing.Size(176, 21);
	this.scheduleTypeComboBox.TabIndex = 56;
	// 
	// scheduleOrderTextBox
	// 
	this.scheduleOrderTextBox.Location = new System.Drawing.Point(208, 72);
	this.scheduleOrderTextBox.Name = "scheduleOrderTextBox";
	this.scheduleOrderTextBox.TabIndex = 57;
	this.scheduleOrderTextBox.Text = "";
	// 
	// label22
	// 
	this.label22.Location = new System.Drawing.Point(24, 48);
	this.label22.Name = "label22";
	this.label22.Size = new System.Drawing.Size(120, 16);
	this.label22.TabIndex = 48;
	this.label22.Text = "Schedule Type";
	// 
	// label21
	// 
	this.label21.Location = new System.Drawing.Point(24, 24);
	this.label21.Name = "label21";
	this.label21.Size = new System.Drawing.Size(120, 16);
	this.label21.TabIndex = 47;
	this.label21.Text = "Processing Location";
	// 
	// processingLocationComboBox
	// 
	this.processingLocationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.processingLocationComboBox.Items.AddRange(new object[] {
																	"Inside Only",
																	"Outside Only",
																	"Both Equally",
																	"Internal Preference",
																	"External  Preference"});
	this.processingLocationComboBox.Location = new System.Drawing.Point(208, 24);
	this.processingLocationComboBox.Name = "processingLocationComboBox";
	this.processingLocationComboBox.Size = new System.Drawing.Size(176, 21);
	this.processingLocationComboBox.TabIndex = 55;
	// 
	// tabPage2
	// 
	this.tabPage2.Controls.Add(this.qtySelectionComboBox);
	this.tabPage2.Controls.Add(this.daysInAdvanceTextBox);
	this.tabPage2.Controls.Add(this.transferToNextTextBox);
	this.tabPage2.Controls.Add(this.longSetupTextBox);
	this.tabPage2.Controls.Add(this.shortSetupTextBox);
	this.tabPage2.Controls.Add(this.batchSizeTextBox);
	this.tabPage2.Controls.Add(this.scheduleWithNextOpTextBox);
	this.tabPage2.Controls.Add(this.reportingPointTextBox);
	this.tabPage2.Controls.Add(this.batchOperationTextBox);
	this.tabPage2.Controls.Add(this.partToRunTextBox);
	this.tabPage2.Controls.Add(this.label23);
	this.tabPage2.Controls.Add(this.label24);
	this.tabPage2.Controls.Add(this.label25);
	this.tabPage2.Controls.Add(this.label26);
	this.tabPage2.Controls.Add(this.label20);
	this.tabPage2.Controls.Add(this.label19);
	this.tabPage2.Controls.Add(this.label18);
	this.tabPage2.Controls.Add(this.label17);
	this.tabPage2.Controls.Add(this.label16);
	this.tabPage2.Controls.Add(this.label15);
	this.tabPage2.Location = new System.Drawing.Point(4, 22);
	this.tabPage2.Name = "tabPage2";
	this.tabPage2.Size = new System.Drawing.Size(504, 454);
	this.tabPage2.TabIndex = 1;
	this.tabPage2.Text = "Quantity Selection";
	// 
	// qtySelectionComboBox
	// 
	this.qtySelectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.qtySelectionComboBox.Items.AddRange(new object[] {
															  "Same as Daily Demand",
															  "Min Run Quantity",
															  "Number of Days",
															  "Higher Value of 2 or 3",
															  "Which sequence do you want"});
	this.qtySelectionComboBox.Location = new System.Drawing.Point(224, 72);
	this.qtySelectionComboBox.Name = "qtySelectionComboBox";
	this.qtySelectionComboBox.Size = new System.Drawing.Size(176, 21);
	this.qtySelectionComboBox.TabIndex = 19;
	// 
	// daysInAdvanceTextBox
	// 
	this.daysInAdvanceTextBox.Location = new System.Drawing.Point(224, 104);
	this.daysInAdvanceTextBox.Name = "daysInAdvanceTextBox";
	this.daysInAdvanceTextBox.TabIndex = 18;
	this.daysInAdvanceTextBox.Text = "";
	// 
	// transferToNextTextBox
	// 
	this.transferToNextTextBox.Location = new System.Drawing.Point(224, 328);
	this.transferToNextTextBox.Name = "transferToNextTextBox";
	this.transferToNextTextBox.TabIndex = 17;
	this.transferToNextTextBox.Text = "";
	// 
	// longSetupTextBox
	// 
	this.longSetupTextBox.Location = new System.Drawing.Point(224, 168);
	this.longSetupTextBox.Name = "longSetupTextBox";
	this.longSetupTextBox.TabIndex = 16;
	this.longSetupTextBox.Text = "";
	// 
	// shortSetupTextBox
	// 
	this.shortSetupTextBox.Location = new System.Drawing.Point(224, 200);
	this.shortSetupTextBox.Name = "shortSetupTextBox";
	this.shortSetupTextBox.TabIndex = 15;
	this.shortSetupTextBox.Text = "";
	// 
	// batchSizeTextBox
	// 
	this.batchSizeTextBox.Location = new System.Drawing.Point(224, 368);
	this.batchSizeTextBox.Name = "batchSizeTextBox";
	this.batchSizeTextBox.TabIndex = 14;
	this.batchSizeTextBox.Text = "";
	// 
	// scheduleWithNextOpTextBox
	// 
	this.scheduleWithNextOpTextBox.Location = new System.Drawing.Point(224, 296);
	this.scheduleWithNextOpTextBox.Name = "scheduleWithNextOpTextBox";
	this.scheduleWithNextOpTextBox.TabIndex = 13;
	this.scheduleWithNextOpTextBox.Text = "";
	// 
	// reportingPointTextBox
	// 
	this.reportingPointTextBox.Location = new System.Drawing.Point(224, 264);
	this.reportingPointTextBox.Name = "reportingPointTextBox";
	this.reportingPointTextBox.TabIndex = 12;
	this.reportingPointTextBox.Text = "";
	// 
	// batchOperationTextBox
	// 
	this.batchOperationTextBox.Location = new System.Drawing.Point(224, 232);
	this.batchOperationTextBox.Name = "batchOperationTextBox";
	this.batchOperationTextBox.TabIndex = 11;
	this.batchOperationTextBox.Text = "";
	// 
	// partToRunTextBox
	// 
	this.partToRunTextBox.Location = new System.Drawing.Point(224, 136);
	this.partToRunTextBox.Name = "partToRunTextBox";
	this.partToRunTextBox.TabIndex = 10;
	this.partToRunTextBox.Text = "";
	// 
	// label23
	// 
	this.label23.Location = new System.Drawing.Point(32, 376);
	this.label23.Name = "label23";
	this.label23.Size = new System.Drawing.Size(140, 16);
	this.label23.TabIndex = 9;
	this.label23.Text = "Batch Size";
	// 
	// label24
	// 
	this.label24.Location = new System.Drawing.Point(32, 336);
	this.label24.Name = "label24";
	this.label24.Size = new System.Drawing.Size(140, 16);
	this.label24.TabIndex = 8;
	this.label24.Text = "Transfer to Next Operation";
	// 
	// label25
	// 
	this.label25.Location = new System.Drawing.Point(32, 304);
	this.label25.Name = "label25";
	this.label25.Size = new System.Drawing.Size(140, 16);
	this.label25.TabIndex = 7;
	this.label25.Text = "Schedule with NextOp";
	// 
	// label26
	// 
	this.label26.Location = new System.Drawing.Point(32, 272);
	this.label26.Name = "label26";
	this.label26.Size = new System.Drawing.Size(140, 16);
	this.label26.TabIndex = 6;
	this.label26.Text = "Reporting Point";
	// 
	// label20
	// 
	this.label20.Location = new System.Drawing.Point(32, 240);
	this.label20.Name = "label20";
	this.label20.Size = new System.Drawing.Size(140, 16);
	this.label20.TabIndex = 5;
	this.label20.Text = "Batch Operation";
	// 
	// label19
	// 
	this.label19.Location = new System.Drawing.Point(32, 208);
	this.label19.Name = "label19";
	this.label19.Size = new System.Drawing.Size(140, 16);
	this.label19.TabIndex = 4;
	this.label19.Text = "Short Setup";
	// 
	// label18
	// 
	this.label18.Location = new System.Drawing.Point(32, 176);
	this.label18.Name = "label18";
	this.label18.Size = new System.Drawing.Size(140, 16);
	this.label18.TabIndex = 3;
	this.label18.Text = "Long Setup";
	// 
	// label17
	// 
	this.label17.Location = new System.Drawing.Point(32, 144);
	this.label17.Name = "label17";
	this.label17.Size = new System.Drawing.Size(160, 16);
	this.label17.TabIndex = 2;
	this.label17.Text = "Part to Run on Specific Shift";
	// 
	// label16
	// 
	this.label16.Location = new System.Drawing.Point(32, 112);
	this.label16.Name = "label16";
	this.label16.Size = new System.Drawing.Size(140, 16);
	this.label16.TabIndex = 1;
	this.label16.Text = "Days in Advance";
	// 
	// label15
	// 
	this.label15.Location = new System.Drawing.Point(32, 80);
	this.label15.Name = "label15";
	this.label15.Size = new System.Drawing.Size(140, 16);
	this.label15.TabIndex = 0;
	this.label15.Text = "Qty Selection";
	// 
	// tabPage3
	// 
	this.tabPage3.Controls.Add(this.descMaterialTextBox);
	this.tabPage3.Controls.Add(this.seekMaterialButton);
	this.tabPage3.Controls.Add(this.mainMaterialTextBox);
	this.tabPage3.Controls.Add(this.mainMaterialQtyTextBox);
	this.tabPage3.Controls.Add(this.mainMaterialSeqTextBox);
	this.tabPage3.Controls.Add(this.label3);
	this.tabPage3.Controls.Add(this.label2);
	this.tabPage3.Controls.Add(this.label1);
	this.tabPage3.Location = new System.Drawing.Point(4, 22);
	this.tabPage3.Name = "tabPage3";
	this.tabPage3.Size = new System.Drawing.Size(504, 454);
	this.tabPage3.TabIndex = 2;
	this.tabPage3.Text = "Material Selection";
	// 
	// descMaterialTextBox
	// 
	this.descMaterialTextBox.Location = new System.Drawing.Point(288, 88);
	this.descMaterialTextBox.Name = "descMaterialTextBox";
	this.descMaterialTextBox.Size = new System.Drawing.Size(192, 20);
	this.descMaterialTextBox.TabIndex = 7;
	this.descMaterialTextBox.Text = "";
	// 
	// seekMaterialButton
	// 
	this.seekMaterialButton.Location = new System.Drawing.Point(248, 92);
	this.seekMaterialButton.Name = "seekMaterialButton";
	this.seekMaterialButton.Size = new System.Drawing.Size(32, 16);
	this.seekMaterialButton.TabIndex = 6;
	this.seekMaterialButton.Text = "...";
	this.seekMaterialButton.Click += new System.EventHandler(this.seekMaterialButton_Click);
	// 
	// mainMaterialTextBox
	// 
	this.mainMaterialTextBox.Location = new System.Drawing.Point(136, 88);
	this.mainMaterialTextBox.Name = "mainMaterialTextBox";
	this.mainMaterialTextBox.TabIndex = 5;
	this.mainMaterialTextBox.Text = "";
	// 
	// mainMaterialQtyTextBox
	// 
	this.mainMaterialQtyTextBox.Location = new System.Drawing.Point(136, 168);
	this.mainMaterialQtyTextBox.Name = "mainMaterialQtyTextBox";
	this.mainMaterialQtyTextBox.TabIndex = 4;
	this.mainMaterialQtyTextBox.Text = "";
	// 
	// mainMaterialSeqTextBox
	// 
	this.mainMaterialSeqTextBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.mainMaterialSeqTextBox.Location = new System.Drawing.Point(136, 128);
	this.mainMaterialSeqTextBox.Name = "mainMaterialSeqTextBox";
	this.mainMaterialSeqTextBox.Size = new System.Drawing.Size(121, 21);
	this.mainMaterialSeqTextBox.TabIndex = 3;
	// 
	// label3
	// 
	this.label3.Location = new System.Drawing.Point(16, 168);
	this.label3.Name = "label3";
	this.label3.Size = new System.Drawing.Size(100, 16);
	this.label3.TabIndex = 2;
	this.label3.Text = "Main Material Qty";
	// 
	// label2
	// 
	this.label2.Location = new System.Drawing.Point(16, 128);
	this.label2.Name = "label2";
	this.label2.Size = new System.Drawing.Size(100, 16);
	this.label2.TabIndex = 1;
	this.label2.Text = "Main Material Seq";
	// 
	// label1
	// 
	this.label1.Location = new System.Drawing.Point(16, 96);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(100, 16);
	this.label1.TabIndex = 0;
	this.label1.Text = "Main material";
	// 
	// tabPage4
	// 
	this.tabPage4.Controls.Add(this.groupBox4);
	this.tabPage4.Controls.Add(this.groupBox3);
	this.tabPage4.Location = new System.Drawing.Point(4, 22);
	this.tabPage4.Name = "tabPage4";
	this.tabPage4.Size = new System.Drawing.Size(504, 454);
	this.tabPage4.TabIndex = 3;
	this.tabPage4.Text = "Tooling Selection";
	// 
	// groupBox4
	// 
	this.groupBox4.Controls.Add(this.schGroup6TxtBox);
	this.groupBox4.Controls.Add(this.schGroup5TxtBox);
	this.groupBox4.Controls.Add(this.schGroup4TxtBox);
	this.groupBox4.Controls.Add(this.schGroup3TxtBox);
	this.groupBox4.Controls.Add(this.schGroup2TxtBox);
	this.groupBox4.Controls.Add(this.schGroup1TextBox);
	this.groupBox4.Controls.Add(this.label13);
	this.groupBox4.Controls.Add(this.label14);
	this.groupBox4.Controls.Add(this.label12);
	this.groupBox4.Controls.Add(this.label11);
	this.groupBox4.Controls.Add(this.label10);
	this.groupBox4.Controls.Add(this.label9);
	this.groupBox4.Location = new System.Drawing.Point(16, 152);
	this.groupBox4.Name = "groupBox4";
	this.groupBox4.Size = new System.Drawing.Size(456, 248);
	this.groupBox4.TabIndex = 17;
	this.groupBox4.TabStop = false;
	// 
	// schGroup6TxtBox
	// 
	this.schGroup6TxtBox.Location = new System.Drawing.Point(176, 208);
	this.schGroup6TxtBox.Name = "schGroup6TxtBox";
	this.schGroup6TxtBox.TabIndex = 15;
	this.schGroup6TxtBox.Text = "";
	// 
	// schGroup5TxtBox
	// 
	this.schGroup5TxtBox.Location = new System.Drawing.Point(176, 176);
	this.schGroup5TxtBox.Name = "schGroup5TxtBox";
	this.schGroup5TxtBox.TabIndex = 14;
	this.schGroup5TxtBox.Text = "";
	// 
	// schGroup4TxtBox
	// 
	this.schGroup4TxtBox.Location = new System.Drawing.Point(176, 144);
	this.schGroup4TxtBox.Name = "schGroup4TxtBox";
	this.schGroup4TxtBox.TabIndex = 13;
	this.schGroup4TxtBox.Text = "";
	// 
	// schGroup3TxtBox
	// 
	this.schGroup3TxtBox.Location = new System.Drawing.Point(176, 112);
	this.schGroup3TxtBox.Name = "schGroup3TxtBox";
	this.schGroup3TxtBox.TabIndex = 12;
	this.schGroup3TxtBox.Text = "";
	// 
	// schGroup2TxtBox
	// 
	this.schGroup2TxtBox.Location = new System.Drawing.Point(176, 80);
	this.schGroup2TxtBox.Name = "schGroup2TxtBox";
	this.schGroup2TxtBox.TabIndex = 11;
	this.schGroup2TxtBox.Text = "";
	// 
	// schGroup1TextBox
	// 
	this.schGroup1TextBox.Location = new System.Drawing.Point(176, 48);
	this.schGroup1TextBox.Name = "schGroup1TextBox";
	this.schGroup1TextBox.TabIndex = 10;
	this.schGroup1TextBox.Text = "";
	// 
	// label13
	// 
	this.label13.Location = new System.Drawing.Point(64, 208);
	this.label13.Name = "label13";
	this.label13.Size = new System.Drawing.Size(100, 16);
	this.label13.TabIndex = 7;
	this.label13.Text = "Sch Group 6";
	// 
	// label14
	// 
	this.label14.Location = new System.Drawing.Point(64, 176);
	this.label14.Name = "label14";
	this.label14.Size = new System.Drawing.Size(100, 16);
	this.label14.TabIndex = 6;
	this.label14.Text = "Sch Group 5";
	// 
	// label12
	// 
	this.label12.Location = new System.Drawing.Point(64, 144);
	this.label12.Name = "label12";
	this.label12.Size = new System.Drawing.Size(100, 16);
	this.label12.TabIndex = 5;
	this.label12.Text = "Sch Group 4";
	// 
	// label11
	// 
	this.label11.Location = new System.Drawing.Point(64, 120);
	this.label11.Name = "label11";
	this.label11.Size = new System.Drawing.Size(100, 16);
	this.label11.TabIndex = 4;
	this.label11.Text = "Sch Group 3";
	// 
	// label10
	// 
	this.label10.Location = new System.Drawing.Point(64, 88);
	this.label10.Name = "label10";
	this.label10.Size = new System.Drawing.Size(100, 16);
	this.label10.TabIndex = 3;
	this.label10.Text = "Sch Group 2";
	// 
	// label9
	// 
	this.label9.Location = new System.Drawing.Point(64, 56);
	this.label9.Name = "label9";
	this.label9.Size = new System.Drawing.Size(100, 16);
	this.label9.TabIndex = 2;
	this.label9.Text = "Sch Group 1";
	// 
	// groupBox3
	// 
	this.groupBox3.Controls.Add(this.mainToolQtyTextBox);
	this.groupBox3.Controls.Add(this.mainToolTypeTextBox);
	this.groupBox3.Controls.Add(this.label8);
	this.groupBox3.Controls.Add(this.label5);
	this.groupBox3.Location = new System.Drawing.Point(16, 16);
	this.groupBox3.Name = "groupBox3";
	this.groupBox3.Size = new System.Drawing.Size(464, 120);
	this.groupBox3.TabIndex = 16;
	this.groupBox3.TabStop = false;
	// 
	// mainToolQtyTextBox
	// 
	this.mainToolQtyTextBox.Location = new System.Drawing.Point(176, 72);
	this.mainToolQtyTextBox.Name = "mainToolQtyTextBox";
	this.mainToolQtyTextBox.TabIndex = 9;
	this.mainToolQtyTextBox.Text = "";
	// 
	// mainToolTypeTextBox
	// 
	this.mainToolTypeTextBox.Location = new System.Drawing.Point(176, 32);
	this.mainToolTypeTextBox.Name = "mainToolTypeTextBox";
	this.mainToolTypeTextBox.TabIndex = 8;
	this.mainToolTypeTextBox.Text = "";
	// 
	// label8
	// 
	this.label8.Location = new System.Drawing.Point(64, 72);
	this.label8.Name = "label8";
	this.label8.Size = new System.Drawing.Size(100, 16);
	this.label8.TabIndex = 1;
	this.label8.Text = "Main Tool Qty";
	// 
	// label5
	// 
	this.label5.Location = new System.Drawing.Point(64, 32);
	this.label5.Name = "label5";
	this.label5.Size = new System.Drawing.Size(100, 16);
	this.label5.TabIndex = 0;
	this.label5.Text = "Main Tool Type";
	// 
	// tabPage5
	// 
	this.tabPage5.Controls.Add(this.groupBox5);
	this.tabPage5.Location = new System.Drawing.Point(4, 22);
	this.tabPage5.Name = "tabPage5";
	this.tabPage5.Size = new System.Drawing.Size(504, 454);
	this.tabPage5.TabIndex = 4;
	this.tabPage5.Text = "Forecast";
	// 
	// groupBox5
	// 
	this.groupBox5.Controls.Add(this.forecastExcludeAllocTextBox);
	this.groupBox5.Controls.Add(this.forecastTimeFenceTextBox);
	this.groupBox5.Controls.Add(this.forecastTextBox);
	this.groupBox5.Controls.Add(this.label7);
	this.groupBox5.Controls.Add(this.label6);
	this.groupBox5.Controls.Add(this.label4);
	this.groupBox5.Location = new System.Drawing.Point(24, 40);
	this.groupBox5.Name = "groupBox5";
	this.groupBox5.Size = new System.Drawing.Size(448, 280);
	this.groupBox5.TabIndex = 7;
	this.groupBox5.TabStop = false;
	// 
	// forecastExcludeAllocTextBox
	// 
	this.forecastExcludeAllocTextBox.Location = new System.Drawing.Point(232, 160);
	this.forecastExcludeAllocTextBox.Name = "forecastExcludeAllocTextBox";
	this.forecastExcludeAllocTextBox.Size = new System.Drawing.Size(160, 20);
	this.forecastExcludeAllocTextBox.TabIndex = 6;
	this.forecastExcludeAllocTextBox.Text = "";
	// 
	// forecastTimeFenceTextBox
	// 
	this.forecastTimeFenceTextBox.Location = new System.Drawing.Point(232, 120);
	this.forecastTimeFenceTextBox.Name = "forecastTimeFenceTextBox";
	this.forecastTimeFenceTextBox.Size = new System.Drawing.Size(160, 20);
	this.forecastTimeFenceTextBox.TabIndex = 5;
	this.forecastTimeFenceTextBox.Text = "";
	// 
	// forecastTextBox
	// 
	this.forecastTextBox.Location = new System.Drawing.Point(232, 80);
	this.forecastTextBox.Name = "forecastTextBox";
	this.forecastTextBox.Size = new System.Drawing.Size(160, 20);
	this.forecastTextBox.TabIndex = 4;
	this.forecastTextBox.Text = "";
	// 
	// label7
	// 
	this.label7.Location = new System.Drawing.Point(24, 160);
	this.label7.Name = "label7";
	this.label7.Size = new System.Drawing.Size(176, 16);
	this.label7.TabIndex = 3;
	this.label7.Text = "Exclude Allocations after# of Days";
	// 
	// label6
	// 
	this.label6.Location = new System.Drawing.Point(24, 120);
	this.label6.Name = "label6";
	this.label6.Size = new System.Drawing.Size(136, 16);
	this.label6.TabIndex = 2;
	this.label6.Text = "Forecast Time Fence";
	// 
	// label4
	// 
	this.label4.Location = new System.Drawing.Point(24, 80);
	this.label4.Name = "label4";
	this.label4.Size = new System.Drawing.Size(136, 16);
	this.label4.TabIndex = 0;
	this.label4.Text = "Forecast at this sequence";
	// 
	// FormProductPlan
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(536, 566);
	this.Controls.Add(this.tabControl1);
	this.Controls.Add(this.panel1);
	this.Name = "FormProductPlan";
	this.Text = "Product Plan Maintenance";
	this.Closing += new System.ComponentModel.CancelEventHandler(this.FormProductPlan_Closing);
	this.groupBox6.ResumeLayout(false);
	this.panel1.ResumeLayout(false);
	this.tabControl1.ResumeLayout(false);
	this.tabPage1.ResumeLayout(false);
	this.tabPage6.ResumeLayout(false);
	this.groupBox2.ResumeLayout(false);
	this.groupBox1.ResumeLayout(false);
	this.tabPage2.ResumeLayout(false);
	this.tabPage3.ResumeLayout(false);
	this.tabPage4.ResumeLayout(false);
	this.groupBox4.ResumeLayout(false);
	this.groupBox3.ResumeLayout(false);
	this.tabPage5.ResumeLayout(false);
	this.groupBox5.ResumeLayout(false);
	this.ResumeLayout(false);

}
#endregion

private 
void display(){
	string sprodId = txtProduct.Text;
	int seq = int.Parse(txtBoxSeq.Text);

	btnOk.Text = "Save";//save by default
	btnOk.Text = "Update";
	
	mainMaterialTextBox.ReadOnly = true;
	descMaterialTextBox.ReadOnly = true;

	productPlan = coreFactory.readProductPlan(sprodId, seq);
	objectToScreen(productPlan);
}

private
bool screenToObject(bool bvalidateOnlyProdAndSeq){
	if (bvalidateOnlyProdAndSeq)
		return true;

	string svalue = txtStdPack.Text;
	if (!checkDecimal(svalue,9999999999.99M,"Std Pack")){
		MessageBox.Show("The product does not exist.");
		return false;
	}
	productPlan.setStdPack(decimal.Parse(svalue));			

	svalue = txtPackType.Text;
	if (svalue.Length > 10){
		MessageBox.Show("Pack Type must not be greather than 10");	
		return false;
	}
	productPlan.setPackType(svalue);
	
	svalue = txtSkidQty.Text;
	if (!checkDecimal(svalue,9999999999.99M,"Skid Qty"))
		return false;
	productPlan.setSkidQty(decimal.Parse(svalue));			
			

	svalue = txtSkidType.Text;
	if (svalue.Length > 10){
		MessageBox.Show("Skid Type must not be greather than 10");	
		return false;
	}

	svalue = txtMinInv.Text;
	if (!checkDecimal(svalue,9999999999.99M,"Min Inv"))
		return false;
	productPlan.setMinInv(decimal.Parse(svalue));
	
	svalue = txtMaxInv.Text;
	if (!checkDecimal(svalue,9999999999.99M,"Max Inv"))
		return false;
	productPlan.setMaxInv(decimal.Parse(svalue));

	svalue = txtInvUom.Text;
	if (svalue.Length > 10){
		MessageBox.Show("Inventory Uom must not be greather than 10");	
		return false;
	}
	productPlan.setInvUom(svalue);
	
	svalue = txtMinCon.Text;
	if (!checkDecimal(svalue,9999999.99M,"Min Con"))
		return false;
	productPlan.setMinCon(decimal.Parse(svalue));

	svalue = txtMaxCon.Text;
	if (!checkDecimal(svalue,9999999.99M,"Max Con"))
		return false;
	productPlan.setMaxCon(decimal.Parse(svalue));

	svalue = txtDohMin.Text;
	if (!NumberUtil.isIntegerNumber(svalue)){
		MessageBox.Show("Please, choose a correct Doh Min value, must be a number.");
		return false;
	}
	productPlan.setDohMin(int.Parse(svalue));

	svalue = txtDohMax.Text;
	if (!NumberUtil.isIntegerNumber(svalue)){
		MessageBox.Show("Please, choose a correct Doh Max value, must be a number.");
		return false;
	}
	productPlan.setDohMax(int.Parse(svalue));

	svalue = txtPackWip.Text;
	if (!checkDecimal(svalue,999999999999999999M,"Pack Wip"))			
		return false;			
	productPlan.setPackWip(int.Parse(svalue));
	
	svalue = txtContWip.Text;
	if (svalue.Length > 5){
		MessageBox.Show("Cont Wip must not be greather than 5");	
		return false;
	}
	productPlan.setContWip(svalue);

	svalue = txtTarRunQty.Text;
	if (!checkDecimal(svalue,9999999999.99M,"Tar Run Qty"))
		return false;
	productPlan.setTarRunQty(decimal.Parse(svalue));			

	svalue = txtColour.Text;
	if (svalue.Length > 30){
		MessageBox.Show("Colour must not be greather than 30");	
		return false;
	}
	productPlan.setColour(svalue);
	
	
	svalue = txtDayLT.Text;
	if (!checkDecimal(svalue,9999.9M,"Day LT"))
		return false;
	productPlan.setDayLT(decimal.Parse(svalue));			

	svalue = txtHourLT.Text;
	if (!checkDecimal(svalue,999.99M,"Hour LT"))
		return false;
	productPlan.setHourLT(decimal.Parse(svalue));			

	svalue = txtDayLTCum.Text;
	if (!checkDecimal(svalue,999999999999999999M,"Day LT Cum"))			
		return false;			
	productPlan.setDayLTCum(long.Parse(svalue));

	svalue = txtHourLTCum.Text;
	if (!checkDecimal(svalue,9999999999999999.99M,"Hour LT Cum"))				
		return false;
	productPlan.setHourLTCum(decimal.Parse(svalue));						

	productPlan.setExcludeSats("N");
	productPlan.setExcludeSuns("N");
	if (checkBoxExcludeSaturday.Checked)
		productPlan.setExcludeSats("Y");
	if (checkBoxExcludeSunday.Checked)
		productPlan.setExcludeSuns("Y");

// -------------General Tab -----------------------------------------------------------------------
	productPlan.setScheduleType(scheduleTypeComboBox.SelectedIndex);
	productPlan.setScheduleOrder(scheduleOrderTextBox.Text);
	productPlan.setProcessLoc(processingLocationComboBox.SelectedIndex);
	productPlan.setToolDep(toolDependentComboBox.Text);
	productPlan.setMachineDep(machineDependentComboBox.Text);
	productPlan.setCapacityRestrict(capacityRestrictComboBox.Text);
	productPlan.setLaborDep(laborDependentComboBox.Text);

// -------------Quantity Selection Tab ------------------------------------------------------------------
	productPlan.setQtyOption(qtySelectionComboBox.SelectedIndex);
	productPlan.setDaysInAdvance(int.Parse(daysInAdvanceTextBox.Text));
	productPlan.setTransferToNext(transferToNextTextBox.Text);
	productPlan.setLongSetup(longSetupTextBox.Text);
	productPlan.setShortSetup(shortSetupTextBox.Text);
	productPlan.setBatchSize(batchSizeTextBox.Text);
	productPlan.setNextOpQtyTransfer(scheduleWithNextOpTextBox.Text);
	productPlan.setReportingPoint(reportingPointTextBox.Text);
	productPlan.setBatchOperation(batchOperationTextBox.Text);
	productPlan.setPartsonSpecShift(partToRunTextBox.Text);

// -------------Material Selection Tab ------------------------------------------------------------------
	if ((mainMaterialTextBox.Text == null) || (mainMaterialTextBox.Text.Trim().Equals(""))){
		MessageBox.Show("Warning : The Main Material is missing");
		productPlan.setMainMaterial("");
	}else{
		productPlan.setMainMaterial(mainMaterialTextBox.Text);
	}

	if (mainMaterialSeqTextBox.Items.Count > 0){
		if ((mainMaterialSeqTextBox.Text == null) || (mainMaterialSeqTextBox.Text.Trim().Equals(""))){
			MessageBox.Show("Enter Main Material Seq please !!");	
			return false;
		}
		productPlan.setMainMatSeq(int.Parse(mainMaterialSeqTextBox.Text));
	}else{
		productPlan.setMainMatSeq(0);
	}

	if ((mainMaterialTextBox.Text != null) && (!mainMaterialTextBox.Text.Trim().Equals(""))){
		if ((mainMaterialQtyTextBox.Text == null) || (mainMaterialQtyTextBox.Text.Trim().Equals(""))){
			MessageBox.Show("Enter Main Material Qty please !!");	
			return false;
		}
		productPlan.setMainMatQty(decimal.Parse(mainMaterialQtyTextBox.Text));
	}else{
		productPlan.setMainMatQty(0);
	}
	

// -------------Tooling Selection Tab ------------------------------------------------------------------

	productPlan.setNumofTools(int.Parse(mainToolQtyTextBox.Text));
	productPlan.setMainToolType(mainToolTypeTextBox.Text);
	productPlan.setSchGroup6(schGroup6TxtBox.Text);
	productPlan.setSchGroup5(schGroup5TxtBox.Text);
	productPlan.setSchGroup4(schGroup4TxtBox.Text);
	productPlan.setSchGroup3(schGroup3TxtBox.Text);
	productPlan.setSchGroup2(schGroup2TxtBox.Text);
	productPlan.setSchGroup1(schGroup1TextBox.Text);

// -------------Forecast Tab ------------------------------------------------------------------
	productPlan.setForecast(forecastTextBox.Text);
	productPlan.setForeTimeFence(forecastTimeFenceTextBox.Text);
	productPlan.setExcludeAlloc(forecastExcludeAllocTextBox.Text);

	return true;
}

private 
bool checkDecimal(string svalue,decimal dmaxValue,string snameValue){
	bool bresult = true;

	try{
		if (Convert.ToDecimal(svalue.Trim())<0 ){
			MessageBox.Show("The field " + snameValue + " must have a value > 0");
			return false;
		}
		if (!NumberUtil.withPoint(svalue.Trim().ToString())){
			MessageBox.Show("The field " + snameValue + " must be with '.' no with ','");
			return false;
		}
		
		decimal theValue = decimal.Parse(svalue.ToString());			

		if (decimal.Compare(theValue,dmaxValue) > 0){//theValue is greater than..
			MessageBox.Show("The field " + snameValue + " must be less than " + dmaxValue.ToString());
			return false;
		}
	}catch{
		return false;
	}
	return bresult;
}

private 
void btnOk_Click(object sender, System.EventArgs e){
	try{
		if (this.screenToObject(false)){ //validate all
			if (coreFactory.existsProductPlan(productPlan.getProdID(),productPlan.getSeq()))
				coreFactory.updateProductPlan(productPlan);
			else
				coreFactory.writeProductPlan(productPlan);

			productPlan = coreFactory.readProductPlan(productPlan.getProdID(), productPlan.getSeq());
			objectToScreen(productPlan);
			MessageBox.Show("Changed Saved Succesfully");
			
			this.coreFactory = null;

			this.Close();
		}
	}catch(NujitException Nex){
		MessageBox.Show(Nex.Message);
	}
}

private
void btnCancel_Click(object sender, System.EventArgs e){
	this.coreFactory = null;
	this.Close();
}

private
void FormProductPlan_Closing(object sender, System.ComponentModel.CancelEventArgs e){
	this.coreFactory = null;
	this.Close();
}

private	
void objectToScreen(ProductPlan productPlan){
	txtProduct.Text = productPlan.getProdID();
	txtStdPack.Text = NumberUtil.toString(productPlan.getStdPack());
	txtPackType.Text = productPlan.getPackType();
	txtSkidQty.Text = NumberUtil.toString(productPlan.getSkidQty());
	txtSkidType.Text = productPlan.getSkidType();

	txtMinInv.Text = NumberUtil.toString(productPlan.getMinInv());
	txtMaxInv.Text = NumberUtil.toString(productPlan.getMaxInv());
	txtInvUom.Text = productPlan.getInvUom();

	txtMinCon.Text = NumberUtil.toString(productPlan.getMinCon());
	txtMaxCon.Text = NumberUtil.toString(productPlan.getMaxCon());

	txtDohMin.Text = productPlan.getDohMin().ToString();
	txtDohMax.Text = productPlan.getDohMax().ToString();

	txtPackWip.Text = productPlan.getPackWip().ToString();
	txtContWip.Text = productPlan.getContWip().ToString();
	txtTarRunQty.Text = NumberUtil.toString(productPlan.getTarRunQty());

	txtColour.Text = productPlan.getColour();
	txtDayLT.Text = NumberUtil.toString(productPlan.getDayLT());
	txtHourLT.Text = NumberUtil.toString(productPlan.getHourLT());
	txtDayLTCum.Text = NumberUtil.toString(productPlan.getDayLTCum());
	txtHourLTCum.Text = NumberUtil.toString(productPlan.getHourLTCum());

	checkBoxExcludeSaturday.Checked = false;
	checkBoxExcludeSunday.Checked = false;
	
	if (productPlan.getExcludeSats().Equals("Y"))
		checkBoxExcludeSaturday.Checked = true;
	if (productPlan.getExcludeSuns().Equals("Y"))
		checkBoxExcludeSunday.Checked = true;

	qtySelectionComboBox.SelectedIndex = productPlan.getQtyOption();
	daysInAdvanceTextBox.Text = productPlan.getDaysInAdvance().ToString();
	longSetupTextBox.Text = productPlan.getLongSetup();
	shortSetupTextBox.Text = productPlan.getShortSetup();
	batchSizeTextBox.Text = productPlan.getBatchSize();
	batchOperationTextBox.Text = productPlan.getBatchOperation();
	partToRunTextBox.Text = productPlan.getPartsonSpecShift();
	scheduleWithNextOpTextBox.Text = productPlan.getNextOpQtyTransfer();

	scheduleTypeComboBox.SelectedIndex = productPlan.getScheduleType();
	scheduleOrderTextBox.Text = productPlan.getScheduleOrder();
	processingLocationComboBox.SelectedIndex = productPlan.getProcessLoc();
	toolDependentComboBox.Text = productPlan.getToolDep();
	machineDependentComboBox.Text = productPlan.getMachineDep();
	laborDependentComboBox.Text = productPlan.getLaborDep();
	capacityRestrictComboBox.Text = productPlan.getCapacityRestrict();

	mainMaterialTextBox.Text = productPlan.getMainMaterial();

	Product product = coreFactory.readProduct(productPlan.getMainMaterial());
	if (product != null)
		descMaterialTextBox.Text = product.getDes1();
	else
		descMaterialTextBox.Text = "";

	string[] v = coreFactory.getValidsSeqsForProduct(productPlan.getMainMaterial());
	for(int i = 0; i < v.Length; i++)
		mainMaterialSeqTextBox.Items.Add(v[i]);

	mainMaterialSeqTextBox.Text = productPlan.getMainMatSeq().ToString();
	mainMaterialQtyTextBox.Text = productPlan.getMainMatQty().ToString();

	mainToolTypeTextBox.Text = productPlan.getMainToolType();
	mainToolQtyTextBox.Text = productPlan.getNumofTools().ToString();
	schGroup1TextBox.Text = productPlan.getSchGroup1();
	schGroup2TxtBox.Text = productPlan.getSchGroup2();
	schGroup3TxtBox.Text = productPlan.getSchGroup3();
	schGroup4TxtBox.Text = productPlan.getSchGroup4();
	schGroup5TxtBox.Text = productPlan.getSchGroup5();
	schGroup6TxtBox.Text = productPlan.getSchGroup6();

	forecastTextBox.Text = productPlan.getForecast();
	forecastTimeFenceTextBox.Text = productPlan.getForeTimeFence();

	reportingPointTextBox.Text = productPlan.getReportingPoint();
	forecastExcludeAllocTextBox.Text = productPlan.getExcludeAlloc();

	transferToNextTextBox.Text = productPlan.getTransferToNext();
}

private 
void seekMaterialButton_Click(object sender, System.EventArgs e){
	ProductSearchForm productSearchForm = new ProductSearchForm("Product search",txtProduct.Text.Trim(),true);
	productSearchForm.ShowDialog();

	try{
		if (productSearchForm.DialogResult == DialogResult.OK){		
			string[] v = productSearchForm.getSelected();
			mainMaterialTextBox.Text = v[0];
			descMaterialTextBox.Text = v[1];

			string[] seqs = coreFactory.getValidsSeqsForProduct(v[0]);
			mainMaterialSeqTextBox.Items.Clear();
			for( int i = 0; i < seqs.Length; i++){
				mainMaterialSeqTextBox.Items.Add(seqs[i]);
			}

			if (seqs.Length > 0)
				mainMaterialSeqTextBox.SelectedIndex = 0;
		}
		productSearchForm.Dispose();
	}catch(NujitException Nex){
		MessageBox.Show(Nex.Message);
	}		
}


}

}
