using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Util;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.WinForms.InventoryLayout;
using Nujit.NujitERP.WinForms.SearchForms;

namespace Nujit.NujitERP.WinForms.Production{

public 
class SchdLogEditForm : System.Windows.Forms.Form{

#region WinControls

private System.Windows.Forms.TextBox companyNameTextBox;
private System.Windows.Forms.Label lblCompany;
private System.Windows.Forms.TextBox companyCodeTextBox;
private System.Windows.Forms.TextBox plantNameTextBox;
private System.Windows.Forms.Label lblPlt;
private System.Windows.Forms.TextBox plantCodeTextBox;
private System.Windows.Forms.GroupBox groupBox1;
private System.Windows.Forms.Button companySearchButton;
private System.Windows.Forms.Button plantSearchButton;
private System.Windows.Forms.TextBox deptNameTextBox;
private System.Windows.Forms.Button deptSearchButton;
private System.Windows.Forms.Label lblDept;
private System.Windows.Forms.TextBox deptCodeTextBox;
private System.Windows.Forms.ErrorProvider errorProvider;
private System.Windows.Forms.Label label1;
private System.Windows.Forms.TextBox jobCardIdTextBox;
private System.Windows.Forms.TabControl tabControl;
private System.Windows.Forms.Button familySearchButton;
private System.Windows.Forms.Label label7;
private System.Windows.Forms.TextBox familyDescTextBox;
private System.Windows.Forms.RadioButton activeRadioButton;
private System.Windows.Forms.RadioButton inactiveRadioButton;
private System.Windows.Forms.GroupBox statusGroupBox;
private System.Windows.Forms.CheckBox selFamilyPartCheckBox;
private System.Windows.Forms.TextBox familyTextBox;
private System.Windows.Forms.GroupBox groupBox2;
private System.Windows.Forms.Button cancelButton;
private System.Windows.Forms.Button okButton;
private System.Windows.Forms.DateTimePicker dateTimePicker;
private System.Windows.Forms.Label label13;
private System.Windows.Forms.TabPage otherTabPage;
private System.Windows.Forms.TabPage toolingTabPage;
private System.Windows.Forms.GroupBox groupBox3;
private NujitCustomWinControls.NumericTextBox qtyPerToolTextBox;
private System.Windows.Forms.Label label18;
private System.Windows.Forms.ComboBox mainToolComboBox;
private System.Windows.Forms.Label label17;
private System.Windows.Forms.Label label12;
private System.Windows.Forms.TextBox toolDescTextBox;
private System.Windows.Forms.TextBox nextOperationTextBox;
private System.Windows.Forms.TextBox operationTextBox;
private System.Windows.Forms.Label label20;
private System.Windows.Forms.Label label19;
private NujitCustomWinControls.NumericTextBox runStandardTextBox;
private System.Windows.Forms.Label label10;
private NujitCustomWinControls.NumericTextBox runQtyTextBox;
private System.Windows.Forms.Label label8;
private System.Windows.Forms.TextBox uomTextBox;
private System.Windows.Forms.Label label9;
private System.Windows.Forms.TabPage part1TabPage;
private System.Windows.Forms.TabPage part2TabPage;
private System.Windows.Forms.TabPage part3TabPage;
private System.Windows.Forms.TabPage part4TabPage;
private System.Windows.Forms.Label label27;
private System.Windows.Forms.Label label26;
private System.Windows.Forms.Label label25;
private System.Windows.Forms.ComboBox seqPart1ComboBox;
private System.Windows.Forms.Label label21;
private System.Windows.Forms.TextBox part1DescTextBox;
private System.Windows.Forms.TextBox part1TextBox;
private System.Windows.Forms.Button part1SearchButton;
private System.Windows.Forms.Label label3;
private System.Windows.Forms.ComboBox seqPart2ComboBox;
private System.Windows.Forms.Label label22;
private System.Windows.Forms.TextBox part2DescTextBox;
private System.Windows.Forms.Label label6;
private System.Windows.Forms.TextBox part2TextBox;
private System.Windows.Forms.Button part2SearchButton;
private System.Windows.Forms.ComboBox seqPart3ComboBox;
private System.Windows.Forms.Label label23;
private System.Windows.Forms.TextBox part3DescTextBox;
private System.Windows.Forms.Button part3SearchButton;
private System.Windows.Forms.TextBox part3TextBox;
private System.Windows.Forms.Label label4;
private System.Windows.Forms.ComboBox seqPart4ComboBox;
private System.Windows.Forms.Label label24;
private System.Windows.Forms.TextBox part4DescTextBox;
private System.Windows.Forms.Button part4SearchButton;
private System.Windows.Forms.TextBox part4TextBox;
private System.Windows.Forms.Label label5;
private System.Windows.Forms.GroupBox groupBox8;
private System.Windows.Forms.GroupBox groupBox9;
private System.Windows.Forms.Label label28;
private System.Windows.Forms.Label label29;
private System.Windows.Forms.Label label30;
private System.Windows.Forms.GroupBox groupBox10;
private System.Windows.Forms.Label label31;
private System.Windows.Forms.Label label32;
private System.Windows.Forms.Label label33;
private System.Windows.Forms.GroupBox mainMaterialGroupBox;
private System.Windows.Forms.TextBox machineDescTextBox;
private System.Windows.Forms.Button machineSearchButton;
private System.Windows.Forms.TextBox machineTextBox;
private System.Windows.Forms.Label label2;
private System.Windows.Forms.Label label11;
private NujitCustomWinControls.NumericTextBox machineHrsTextBox;
private System.Windows.Forms.GroupBox part1GroupBox;
private System.Windows.Forms.GroupBox part2GroupBox;
private System.Windows.Forms.GroupBox part3GroupBox;
private System.Windows.Forms.GroupBox part4GroupBox;
private System.Windows.Forms.GroupBox groupBox4;
private System.Windows.Forms.Label label34;
private System.Windows.Forms.Label label35;
private System.Windows.Forms.Label label36;
private NujitCustomWinControls.NumericTextBox currPart1SeqTextBox;
private NujitCustomWinControls.NumericTextBox prePart1SeqTextBox;
private NujitCustomWinControls.NumericTextBox nextPart1SeqTextBox;
private NujitCustomWinControls.NumericTextBox nextPart2SeqTextBox;
private NujitCustomWinControls.NumericTextBox prePart2SeqTextBox;
private NujitCustomWinControls.NumericTextBox currPart2SeqTextBox;
private NujitCustomWinControls.NumericTextBox currPart3SeqTextBox;
private NujitCustomWinControls.NumericTextBox nextPart3SeqTextBox;
private NujitCustomWinControls.NumericTextBox prePart3SeqTextBox;
private NujitCustomWinControls.NumericTextBox nextPart4SeqTextBox;
private NujitCustomWinControls.NumericTextBox prePart4SeqTextBox;
private NujitCustomWinControls.NumericTextBox currPart4SeqTextBox;
private System.Windows.Forms.Label label37;
private NujitCustomWinControls.NumericTextBox mainMat1QohTextBox;
private NujitCustomWinControls.NumericTextBox mainMat2QohTextBox;
private System.Windows.Forms.Label label38;
private NujitCustomWinControls.NumericTextBox mainMat3QohTextBox;
private System.Windows.Forms.Label label39;
private NujitCustomWinControls.NumericTextBox mainMat4QohTextBox;
private System.Windows.Forms.Label label40;
private System.Windows.Forms.Label label41;
private System.Windows.Forms.TextBox mainMaterialTextBox;
private System.Windows.Forms.TextBox mainMaterial2TextBox;
private System.Windows.Forms.Label label42;
private System.Windows.Forms.TextBox mainMaterial3TextBox;
private System.Windows.Forms.Label label43;
private System.Windows.Forms.TextBox mainMaterial4TextBox;
private System.Windows.Forms.Label label44;
private System.Windows.Forms.Label label45;
private System.Windows.Forms.Label label46;
private System.Windows.Forms.TextBox operation2TextBox;
private System.Windows.Forms.TextBox nextOperation2TextBox;
private System.Windows.Forms.Label label47;
private System.Windows.Forms.TextBox operation3TextBox;
private System.Windows.Forms.Label label48;
private System.Windows.Forms.TextBox nextOperation3TextBox;
private System.Windows.Forms.Label label49;
private System.Windows.Forms.TextBox operation4TextBox;
private System.Windows.Forms.Label label50;
private System.Windows.Forms.TextBox nextOperation4TextBox;
private NujitCustomWinControls.NumericTextBox runStandard2TextBox;
private System.Windows.Forms.Label label51;
private System.Windows.Forms.TextBox uom2TextBox;
private System.Windows.Forms.Label label52;
private NujitCustomWinControls.NumericTextBox runQty2TextBox;
private System.Windows.Forms.Label label53;
private NujitCustomWinControls.NumericTextBox runStandard3TextBox;
private System.Windows.Forms.Label label54;
private System.Windows.Forms.TextBox uom3TextBox;
private System.Windows.Forms.Label label55;
private NujitCustomWinControls.NumericTextBox runQty3TextBox;
private System.Windows.Forms.Label label56;
private NujitCustomWinControls.NumericTextBox runStandard4TextBox;
private System.Windows.Forms.Label label57;
private System.Windows.Forms.TextBox uom4TextBox;
private System.Windows.Forms.Label label58;
private NujitCustomWinControls.NumericTextBox runQty4TextBox;
private System.Windows.Forms.Label label59;
private NujitCustomWinControls.NumericTextBox qtyReqTextBox;
private NujitCustomWinControls.NumericTextBox qtyPerTextBox;
private System.Windows.Forms.Label label16;
private System.Windows.Forms.Label label14;
private System.Windows.Forms.Label label15;
private System.Windows.Forms.Label label60;
private System.Windows.Forms.Label label61;
private System.Windows.Forms.ComboBox seqsSelPartComboBox;
private System.Windows.Forms.Label label62;
private System.Windows.Forms.Label label63;
private System.Windows.Forms.ComboBox allPartsComboBox;
private NujitCustomWinControls.NumericTextBox runStdSelPartTextBox;
private System.Windows.Forms.TextBox uomSelPartTextBox;
private NujitCustomWinControls.NumericTextBox runQtySelPartTextBox;

#endregion

private System.ComponentModel.Container components = null;

private bool flagEdit = false;
private CoreFactory coreFactory;
private SchLog schLog;
string[][] tools;

public 
SchdLogEditForm(){
	InitializeComponent();
	
	this.flagEdit = false;
	initializeControls();
}

public 
SchdLogEditForm(SchLog schLog){
	InitializeComponent();
	
	this.flagEdit = true;
	this.schLog = schLog;
	initializeControls();
	disableControls();
	objectToScreen();
}


protected 
override void Dispose( bool disposing ){
	if( disposing ){
		if(components != null){
			components.Dispose();
		}
	}
	base.Dispose( disposing );
}

private
string getDftDataBase(){
	return Configuration.DftDataBase;
}

private
void initializeControls(){
	coreFactory = UtilCoreFactory.createCoreFactory();
	Company company = coreFactory.readCompany(getDftDataBase(), Configuration.DftCompany);
	companyCodeTextBox.Text = company.getCompany().ToString();
	companyNameTextBox.Text = company.getName();
	
	if (this.flagEdit)
		companySearchButton.Enabled = false;

	Plant plant = coreFactory.readPlant(Configuration.DftPlant);
	plantCodeTextBox.Text = plant.getPlt();
	plantNameTextBox.Text = plant.getName();
	
	if (this.flagEdit)
		plantSearchButton.Enabled = false;
		
	Departament department = coreFactory.readDepartament(plant.getPlt(), Configuration.DftDepartment);	
	deptCodeTextBox.Text = department.getDept();
	deptNameTextBox.Text = department.getDes1();
	
	if (this.flagEdit)
		deptSearchButton.Enabled = false;
	
	clearFamily();
	clearParts();
}

private
void disableControls(){
	jobCardIdTextBox.Enabled = false;
	deptCodeTextBox.Enabled = false;
	dateTimePicker.Enabled = false;
	operationTextBox.Enabled = false;
	nextOperationTextBox.Enabled = false;
}

private
void clearFamily(){
	familyTextBox.Text = "";
	familyDescTextBox.Text = "";
}

private
void clearParts(){
	part1TextBox.Text = "";
	part1DescTextBox.Text = "";
	seqPart1ComboBox.Items.Clear();
	seqPart1ComboBox.Text = string.Empty;

	part2TextBox.Text = "";
	part2DescTextBox.Text = "";
	seqPart2ComboBox.Items.Clear();
	seqPart2ComboBox.Text = string.Empty;

	part3TextBox.Text = "";
	part3DescTextBox.Text = "";
	seqPart3ComboBox.Items.Clear();
	seqPart3ComboBox.Text = string.Empty;

	part4TextBox.Text = "";
	part4DescTextBox.Text = "";
	seqPart4ComboBox.Items.Clear();
	seqPart4ComboBox.Text = string.Empty;
}

#region Windows Form Designer generated code
/// <summary>
/// Required method for Designer support - do not modify
/// the contents of this method with the code editor.
/// </summary>
private 
void InitializeComponent(){
	System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SchdLogEditForm));
	this.companyNameTextBox = new System.Windows.Forms.TextBox();
	this.companySearchButton = new System.Windows.Forms.Button();
	this.lblCompany = new System.Windows.Forms.Label();
	this.companyCodeTextBox = new System.Windows.Forms.TextBox();
	this.plantNameTextBox = new System.Windows.Forms.TextBox();
	this.lblPlt = new System.Windows.Forms.Label();
	this.plantCodeTextBox = new System.Windows.Forms.TextBox();
	this.plantSearchButton = new System.Windows.Forms.Button();
	this.groupBox1 = new System.Windows.Forms.GroupBox();
	this.qtyReqTextBox = new NujitCustomWinControls.NumericTextBox();
	this.qtyPerTextBox = new NujitCustomWinControls.NumericTextBox();
	this.label16 = new System.Windows.Forms.Label();
	this.label14 = new System.Windows.Forms.Label();
	this.label13 = new System.Windows.Forms.Label();
	this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
	this.tabControl = new System.Windows.Forms.TabControl();
	this.part1TabPage = new System.Windows.Forms.TabPage();
	this.part1GroupBox = new System.Windows.Forms.GroupBox();
	this.groupBox8 = new System.Windows.Forms.GroupBox();
	this.mainMat1QohTextBox = new NujitCustomWinControls.NumericTextBox();
	this.label37 = new System.Windows.Forms.Label();
	this.nextPart1SeqTextBox = new NujitCustomWinControls.NumericTextBox();
	this.prePart1SeqTextBox = new NujitCustomWinControls.NumericTextBox();
	this.currPart1SeqTextBox = new NujitCustomWinControls.NumericTextBox();
	this.label27 = new System.Windows.Forms.Label();
	this.label26 = new System.Windows.Forms.Label();
	this.label25 = new System.Windows.Forms.Label();
	this.mainMaterialTextBox = new System.Windows.Forms.TextBox();
	this.label41 = new System.Windows.Forms.Label();
	this.seqPart1ComboBox = new System.Windows.Forms.ComboBox();
	this.label21 = new System.Windows.Forms.Label();
	this.part1DescTextBox = new System.Windows.Forms.TextBox();
	this.part1TextBox = new System.Windows.Forms.TextBox();
	this.part1SearchButton = new System.Windows.Forms.Button();
	this.label3 = new System.Windows.Forms.Label();
	this.label20 = new System.Windows.Forms.Label();
	this.operationTextBox = new System.Windows.Forms.TextBox();
	this.label19 = new System.Windows.Forms.Label();
	this.nextOperationTextBox = new System.Windows.Forms.TextBox();
	this.runStandardTextBox = new NujitCustomWinControls.NumericTextBox();
	this.label10 = new System.Windows.Forms.Label();
	this.uomTextBox = new System.Windows.Forms.TextBox();
	this.label9 = new System.Windows.Forms.Label();
	this.runQtyTextBox = new NujitCustomWinControls.NumericTextBox();
	this.label8 = new System.Windows.Forms.Label();
	this.part2TabPage = new System.Windows.Forms.TabPage();
	this.part2GroupBox = new System.Windows.Forms.GroupBox();
	this.runStandard2TextBox = new NujitCustomWinControls.NumericTextBox();
	this.label51 = new System.Windows.Forms.Label();
	this.uom2TextBox = new System.Windows.Forms.TextBox();
	this.label52 = new System.Windows.Forms.Label();
	this.runQty2TextBox = new NujitCustomWinControls.NumericTextBox();
	this.label53 = new System.Windows.Forms.Label();
	this.label45 = new System.Windows.Forms.Label();
	this.operation2TextBox = new System.Windows.Forms.TextBox();
	this.label46 = new System.Windows.Forms.Label();
	this.nextOperation2TextBox = new System.Windows.Forms.TextBox();
	this.groupBox9 = new System.Windows.Forms.GroupBox();
	this.mainMat2QohTextBox = new NujitCustomWinControls.NumericTextBox();
	this.label38 = new System.Windows.Forms.Label();
	this.nextPart2SeqTextBox = new NujitCustomWinControls.NumericTextBox();
	this.prePart2SeqTextBox = new NujitCustomWinControls.NumericTextBox();
	this.currPart2SeqTextBox = new NujitCustomWinControls.NumericTextBox();
	this.label28 = new System.Windows.Forms.Label();
	this.label29 = new System.Windows.Forms.Label();
	this.label30 = new System.Windows.Forms.Label();
	this.mainMaterial2TextBox = new System.Windows.Forms.TextBox();
	this.label42 = new System.Windows.Forms.Label();
	this.seqPart2ComboBox = new System.Windows.Forms.ComboBox();
	this.label22 = new System.Windows.Forms.Label();
	this.part2DescTextBox = new System.Windows.Forms.TextBox();
	this.label6 = new System.Windows.Forms.Label();
	this.part2TextBox = new System.Windows.Forms.TextBox();
	this.part2SearchButton = new System.Windows.Forms.Button();
	this.part3TabPage = new System.Windows.Forms.TabPage();
	this.part3GroupBox = new System.Windows.Forms.GroupBox();
	this.runStandard3TextBox = new NujitCustomWinControls.NumericTextBox();
	this.label54 = new System.Windows.Forms.Label();
	this.uom3TextBox = new System.Windows.Forms.TextBox();
	this.label55 = new System.Windows.Forms.Label();
	this.runQty3TextBox = new NujitCustomWinControls.NumericTextBox();
	this.label56 = new System.Windows.Forms.Label();
	this.label47 = new System.Windows.Forms.Label();
	this.operation3TextBox = new System.Windows.Forms.TextBox();
	this.label48 = new System.Windows.Forms.Label();
	this.nextOperation3TextBox = new System.Windows.Forms.TextBox();
	this.groupBox10 = new System.Windows.Forms.GroupBox();
	this.mainMat3QohTextBox = new NujitCustomWinControls.NumericTextBox();
	this.label39 = new System.Windows.Forms.Label();
	this.nextPart3SeqTextBox = new NujitCustomWinControls.NumericTextBox();
	this.prePart3SeqTextBox = new NujitCustomWinControls.NumericTextBox();
	this.currPart3SeqTextBox = new NujitCustomWinControls.NumericTextBox();
	this.label31 = new System.Windows.Forms.Label();
	this.label32 = new System.Windows.Forms.Label();
	this.label33 = new System.Windows.Forms.Label();
	this.mainMaterial3TextBox = new System.Windows.Forms.TextBox();
	this.label43 = new System.Windows.Forms.Label();
	this.seqPart3ComboBox = new System.Windows.Forms.ComboBox();
	this.label23 = new System.Windows.Forms.Label();
	this.part3DescTextBox = new System.Windows.Forms.TextBox();
	this.part3SearchButton = new System.Windows.Forms.Button();
	this.part3TextBox = new System.Windows.Forms.TextBox();
	this.label4 = new System.Windows.Forms.Label();
	this.part4TabPage = new System.Windows.Forms.TabPage();
	this.part4GroupBox = new System.Windows.Forms.GroupBox();
	this.runStandard4TextBox = new NujitCustomWinControls.NumericTextBox();
	this.label57 = new System.Windows.Forms.Label();
	this.uom4TextBox = new System.Windows.Forms.TextBox();
	this.label58 = new System.Windows.Forms.Label();
	this.runQty4TextBox = new NujitCustomWinControls.NumericTextBox();
	this.label59 = new System.Windows.Forms.Label();
	this.label49 = new System.Windows.Forms.Label();
	this.operation4TextBox = new System.Windows.Forms.TextBox();
	this.label50 = new System.Windows.Forms.Label();
	this.nextOperation4TextBox = new System.Windows.Forms.TextBox();
	this.groupBox4 = new System.Windows.Forms.GroupBox();
	this.mainMat4QohTextBox = new NujitCustomWinControls.NumericTextBox();
	this.label40 = new System.Windows.Forms.Label();
	this.nextPart4SeqTextBox = new NujitCustomWinControls.NumericTextBox();
	this.prePart4SeqTextBox = new NujitCustomWinControls.NumericTextBox();
	this.currPart4SeqTextBox = new NujitCustomWinControls.NumericTextBox();
	this.label34 = new System.Windows.Forms.Label();
	this.label35 = new System.Windows.Forms.Label();
	this.label36 = new System.Windows.Forms.Label();
	this.mainMaterial4TextBox = new System.Windows.Forms.TextBox();
	this.label44 = new System.Windows.Forms.Label();
	this.seqPart4ComboBox = new System.Windows.Forms.ComboBox();
	this.label24 = new System.Windows.Forms.Label();
	this.part4DescTextBox = new System.Windows.Forms.TextBox();
	this.part4SearchButton = new System.Windows.Forms.Button();
	this.part4TextBox = new System.Windows.Forms.TextBox();
	this.label5 = new System.Windows.Forms.Label();
	this.otherTabPage = new System.Windows.Forms.TabPage();
	this.mainMaterialGroupBox = new System.Windows.Forms.GroupBox();
	this.allPartsComboBox = new System.Windows.Forms.ComboBox();
	this.seqsSelPartComboBox = new System.Windows.Forms.ComboBox();
	this.label62 = new System.Windows.Forms.Label();
	this.label63 = new System.Windows.Forms.Label();
	this.runStdSelPartTextBox = new NujitCustomWinControls.NumericTextBox();
	this.label15 = new System.Windows.Forms.Label();
	this.uomSelPartTextBox = new System.Windows.Forms.TextBox();
	this.label60 = new System.Windows.Forms.Label();
	this.runQtySelPartTextBox = new NujitCustomWinControls.NumericTextBox();
	this.label61 = new System.Windows.Forms.Label();
	this.machineDescTextBox = new System.Windows.Forms.TextBox();
	this.machineSearchButton = new System.Windows.Forms.Button();
	this.machineTextBox = new System.Windows.Forms.TextBox();
	this.label2 = new System.Windows.Forms.Label();
	this.label11 = new System.Windows.Forms.Label();
	this.machineHrsTextBox = new NujitCustomWinControls.NumericTextBox();
	this.toolingTabPage = new System.Windows.Forms.TabPage();
	this.groupBox3 = new System.Windows.Forms.GroupBox();
	this.toolDescTextBox = new System.Windows.Forms.TextBox();
	this.label12 = new System.Windows.Forms.Label();
	this.qtyPerToolTextBox = new NujitCustomWinControls.NumericTextBox();
	this.label18 = new System.Windows.Forms.Label();
	this.mainToolComboBox = new System.Windows.Forms.ComboBox();
	this.label17 = new System.Windows.Forms.Label();
	this.statusGroupBox = new System.Windows.Forms.GroupBox();
	this.inactiveRadioButton = new System.Windows.Forms.RadioButton();
	this.activeRadioButton = new System.Windows.Forms.RadioButton();
	this.jobCardIdTextBox = new System.Windows.Forms.TextBox();
	this.label1 = new System.Windows.Forms.Label();
	this.deptNameTextBox = new System.Windows.Forms.TextBox();
	this.deptSearchButton = new System.Windows.Forms.Button();
	this.lblDept = new System.Windows.Forms.Label();
	this.deptCodeTextBox = new System.Windows.Forms.TextBox();
	this.familyTextBox = new System.Windows.Forms.TextBox();
	this.familySearchButton = new System.Windows.Forms.Button();
	this.familyDescTextBox = new System.Windows.Forms.TextBox();
	this.label7 = new System.Windows.Forms.Label();
	this.selFamilyPartCheckBox = new System.Windows.Forms.CheckBox();
	this.errorProvider = new System.Windows.Forms.ErrorProvider();
	this.groupBox2 = new System.Windows.Forms.GroupBox();
	this.cancelButton = new System.Windows.Forms.Button();
	this.okButton = new System.Windows.Forms.Button();
	this.groupBox1.SuspendLayout();
	this.tabControl.SuspendLayout();
	this.part1TabPage.SuspendLayout();
	this.part1GroupBox.SuspendLayout();
	this.groupBox8.SuspendLayout();
	this.part2TabPage.SuspendLayout();
	this.part2GroupBox.SuspendLayout();
	this.groupBox9.SuspendLayout();
	this.part3TabPage.SuspendLayout();
	this.part3GroupBox.SuspendLayout();
	this.groupBox10.SuspendLayout();
	this.part4TabPage.SuspendLayout();
	this.part4GroupBox.SuspendLayout();
	this.groupBox4.SuspendLayout();
	this.otherTabPage.SuspendLayout();
	this.mainMaterialGroupBox.SuspendLayout();
	this.toolingTabPage.SuspendLayout();
	this.groupBox3.SuspendLayout();
	this.statusGroupBox.SuspendLayout();
	this.groupBox2.SuspendLayout();
	this.SuspendLayout();
	// 
	// companyNameTextBox
	// 
	this.companyNameTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.companyNameTextBox.Enabled = false;
	this.companyNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.companyNameTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
	this.companyNameTextBox.Location = new System.Drawing.Point(168, 16);
	this.companyNameTextBox.MaxLength = 10;
	this.companyNameTextBox.Name = "companyNameTextBox";
	this.companyNameTextBox.ReadOnly = true;
	this.companyNameTextBox.Size = new System.Drawing.Size(216, 20);
	this.companyNameTextBox.TabIndex = 1;
	this.companyNameTextBox.Text = "";
	// 
	// companySearchButton
	// 
	this.companySearchButton.Location = new System.Drawing.Point(392, 16);
	this.companySearchButton.Name = "companySearchButton";
	this.companySearchButton.Size = new System.Drawing.Size(32, 16);
	this.companySearchButton.TabIndex = 2;
	this.companySearchButton.Text = "...";
	this.companySearchButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
	this.companySearchButton.Click += new System.EventHandler(this.companySearchButton_Click);
	// 
	// lblCompany
	// 
	this.lblCompany.Location = new System.Drawing.Point(8, 16);
	this.lblCompany.Name = "lblCompany";
	this.lblCompany.Size = new System.Drawing.Size(56, 20);
	this.lblCompany.TabIndex = 24;
	this.lblCompany.Text = "Company";
	this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// companyCodeTextBox
	// 
	this.companyCodeTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.companyCodeTextBox.Enabled = false;
	this.companyCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.companyCodeTextBox.Location = new System.Drawing.Point(88, 16);
	this.companyCodeTextBox.MaxLength = 10;
	this.companyCodeTextBox.Name = "companyCodeTextBox";
	this.companyCodeTextBox.ReadOnly = true;
	this.companyCodeTextBox.Size = new System.Drawing.Size(76, 20);
	this.companyCodeTextBox.TabIndex = 0;
	this.companyCodeTextBox.Text = "";
	// 
	// plantNameTextBox
	// 
	this.plantNameTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.plantNameTextBox.Enabled = false;
	this.plantNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.plantNameTextBox.Location = new System.Drawing.Point(168, 40);
	this.plantNameTextBox.MaxLength = 10;
	this.plantNameTextBox.Name = "plantNameTextBox";
	this.plantNameTextBox.ReadOnly = true;
	this.plantNameTextBox.Size = new System.Drawing.Size(216, 20);
	this.plantNameTextBox.TabIndex = 4;
	this.plantNameTextBox.Text = "";
	// 
	// lblPlt
	// 
	this.lblPlt.Location = new System.Drawing.Point(8, 40);
	this.lblPlt.Name = "lblPlt";
	this.lblPlt.Size = new System.Drawing.Size(56, 20);
	this.lblPlt.TabIndex = 20;
	this.lblPlt.Text = "Plant";
	this.lblPlt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// plantCodeTextBox
	// 
	this.plantCodeTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.plantCodeTextBox.Enabled = false;
	this.plantCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.plantCodeTextBox.Location = new System.Drawing.Point(88, 40);
	this.plantCodeTextBox.MaxLength = 10;
	this.plantCodeTextBox.Name = "plantCodeTextBox";
	this.plantCodeTextBox.ReadOnly = true;
	this.plantCodeTextBox.Size = new System.Drawing.Size(76, 20);
	this.plantCodeTextBox.TabIndex = 3;
	this.plantCodeTextBox.Text = "";
	// 
	// plantSearchButton
	// 
	this.plantSearchButton.Location = new System.Drawing.Point(392, 40);
	this.plantSearchButton.Name = "plantSearchButton";
	this.plantSearchButton.Size = new System.Drawing.Size(32, 16);
	this.plantSearchButton.TabIndex = 5;
	this.plantSearchButton.Text = "...";
	this.plantSearchButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
	this.plantSearchButton.Click += new System.EventHandler(this.plantSearchButton_Click);
	// 
	// groupBox1
	// 
	this.groupBox1.Controls.Add(this.qtyReqTextBox);
	this.groupBox1.Controls.Add(this.qtyPerTextBox);
	this.groupBox1.Controls.Add(this.label16);
	this.groupBox1.Controls.Add(this.label14);
	this.groupBox1.Controls.Add(this.label13);
	this.groupBox1.Controls.Add(this.dateTimePicker);
	this.groupBox1.Controls.Add(this.tabControl);
	this.groupBox1.Controls.Add(this.statusGroupBox);
	this.groupBox1.Controls.Add(this.jobCardIdTextBox);
	this.groupBox1.Controls.Add(this.label1);
	this.groupBox1.Controls.Add(this.deptNameTextBox);
	this.groupBox1.Controls.Add(this.deptSearchButton);
	this.groupBox1.Controls.Add(this.lblDept);
	this.groupBox1.Controls.Add(this.deptCodeTextBox);
	this.groupBox1.Controls.Add(this.plantSearchButton);
	this.groupBox1.Controls.Add(this.plantCodeTextBox);
	this.groupBox1.Controls.Add(this.lblPlt);
	this.groupBox1.Controls.Add(this.plantNameTextBox);
	this.groupBox1.Controls.Add(this.companyCodeTextBox);
	this.groupBox1.Controls.Add(this.lblCompany);
	this.groupBox1.Controls.Add(this.companySearchButton);
	this.groupBox1.Controls.Add(this.companyNameTextBox);
	this.groupBox1.Controls.Add(this.familyTextBox);
	this.groupBox1.Controls.Add(this.familySearchButton);
	this.groupBox1.Controls.Add(this.familyDescTextBox);
	this.groupBox1.Controls.Add(this.label7);
	this.groupBox1.Controls.Add(this.selFamilyPartCheckBox);
	this.groupBox1.Location = new System.Drawing.Point(8, 8);
	this.groupBox1.Name = "groupBox1";
	this.groupBox1.Size = new System.Drawing.Size(800, 464);
	this.groupBox1.TabIndex = 0;
	this.groupBox1.TabStop = false;
	// 
	// qtyReqTextBox
	// 
	this.qtyReqTextBox.Location = new System.Drawing.Point(640, 144);
	this.qtyReqTextBox.Maximum = new System.Decimal(new int[] {
																  276447231,
																  23283,
																  0,
																  327680});
	this.qtyReqTextBox.MaxPrecision = 1;
	this.qtyReqTextBox.Minimum = new System.Decimal(new int[] {
																  0,
																  0,
																  0,
																  0});
	this.qtyReqTextBox.Name = "qtyReqTextBox";
	this.qtyReqTextBox.Size = new System.Drawing.Size(128, 20);
	this.qtyReqTextBox.TabIndex = 18;
	this.qtyReqTextBox.Value = new System.Decimal(new int[] {
																0,
																0,
																0,
																0});
	this.qtyReqTextBox.ValueChanged += new System.EventHandler(this.qtyReqTextBox_ValueChanged);
	// 
	// qtyPerTextBox
	// 
	this.qtyPerTextBox.Location = new System.Drawing.Point(640, 120);
	this.qtyPerTextBox.Maximum = new System.Decimal(new int[] {
																  276447231,
																  23283,
																  0,
																  327680});
	this.qtyPerTextBox.MaxPrecision = 1;
	this.qtyPerTextBox.Minimum = new System.Decimal(new int[] {
																  0,
																  0,
																  0,
																  0});
	this.qtyPerTextBox.Name = "qtyPerTextBox";
	this.qtyPerTextBox.Size = new System.Drawing.Size(128, 20);
	this.qtyPerTextBox.TabIndex = 17;
	this.qtyPerTextBox.Value = new System.Decimal(new int[] {
																0,
																0,
																0,
																0});
	// 
	// label16
	// 
	this.label16.Location = new System.Drawing.Point(544, 144);
	this.label16.Name = "label16";
	this.label16.Size = new System.Drawing.Size(96, 20);
	this.label16.TabIndex = 71;
	this.label16.Text = "Job Card Run Qty";
	this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label14
	// 
	this.label14.Location = new System.Drawing.Point(592, 120);
	this.label14.Name = "label14";
	this.label14.Size = new System.Drawing.Size(48, 20);
	this.label14.TabIndex = 70;
	this.label14.Text = "Lot Qty";
	this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label13
	// 
	this.label13.Location = new System.Drawing.Point(584, 40);
	this.label13.Name = "label13";
	this.label13.Size = new System.Drawing.Size(40, 20);
	this.label13.TabIndex = 69;
	this.label13.Text = "Date";
	this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// dateTimePicker
	// 
	this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
	this.dateTimePicker.Location = new System.Drawing.Point(640, 40);
	this.dateTimePicker.Name = "dateTimePicker";
	this.dateTimePicker.Size = new System.Drawing.Size(88, 20);
	this.dateTimePicker.TabIndex = 15;
	// 
	// tabControl
	// 
	this.tabControl.Controls.Add(this.part1TabPage);
	this.tabControl.Controls.Add(this.part2TabPage);
	this.tabControl.Controls.Add(this.part3TabPage);
	this.tabControl.Controls.Add(this.part4TabPage);
	this.tabControl.Controls.Add(this.otherTabPage);
	this.tabControl.Controls.Add(this.toolingTabPage);
	this.tabControl.Location = new System.Drawing.Point(8, 160);
	this.tabControl.Name = "tabControl";
	this.tabControl.SelectedIndex = 0;
	this.tabControl.Size = new System.Drawing.Size(704, 296);
	this.tabControl.TabIndex = 19;
	// 
	// part1TabPage
	// 
	this.part1TabPage.Controls.Add(this.part1GroupBox);
	this.part1TabPage.Location = new System.Drawing.Point(4, 22);
	this.part1TabPage.Name = "part1TabPage";
	this.part1TabPage.Size = new System.Drawing.Size(696, 270);
	this.part1TabPage.TabIndex = 4;
	this.part1TabPage.Text = "Part #1";
	// 
	// part1GroupBox
	// 
	this.part1GroupBox.Controls.Add(this.groupBox8);
	this.part1GroupBox.Controls.Add(this.seqPart1ComboBox);
	this.part1GroupBox.Controls.Add(this.label21);
	this.part1GroupBox.Controls.Add(this.part1DescTextBox);
	this.part1GroupBox.Controls.Add(this.part1TextBox);
	this.part1GroupBox.Controls.Add(this.part1SearchButton);
	this.part1GroupBox.Controls.Add(this.label3);
	this.part1GroupBox.Controls.Add(this.label20);
	this.part1GroupBox.Controls.Add(this.operationTextBox);
	this.part1GroupBox.Controls.Add(this.label19);
	this.part1GroupBox.Controls.Add(this.nextOperationTextBox);
	this.part1GroupBox.Controls.Add(this.runStandardTextBox);
	this.part1GroupBox.Controls.Add(this.label10);
	this.part1GroupBox.Controls.Add(this.uomTextBox);
	this.part1GroupBox.Controls.Add(this.label9);
	this.part1GroupBox.Controls.Add(this.runQtyTextBox);
	this.part1GroupBox.Controls.Add(this.label8);
	this.part1GroupBox.Location = new System.Drawing.Point(8, 8);
	this.part1GroupBox.Name = "part1GroupBox";
	this.part1GroupBox.Size = new System.Drawing.Size(680, 256);
	this.part1GroupBox.TabIndex = 0;
	this.part1GroupBox.TabStop = false;
	// 
	// groupBox8
	// 
	this.groupBox8.Controls.Add(this.mainMat1QohTextBox);
	this.groupBox8.Controls.Add(this.label37);
	this.groupBox8.Controls.Add(this.nextPart1SeqTextBox);
	this.groupBox8.Controls.Add(this.prePart1SeqTextBox);
	this.groupBox8.Controls.Add(this.currPart1SeqTextBox);
	this.groupBox8.Controls.Add(this.label27);
	this.groupBox8.Controls.Add(this.label26);
	this.groupBox8.Controls.Add(this.label25);
	this.groupBox8.Controls.Add(this.mainMaterialTextBox);
	this.groupBox8.Controls.Add(this.label41);
	this.groupBox8.Location = new System.Drawing.Point(8, 72);
	this.groupBox8.Name = "groupBox8";
	this.groupBox8.Size = new System.Drawing.Size(312, 168);
	this.groupBox8.TabIndex = 76;
	this.groupBox8.TabStop = false;
	this.groupBox8.Text = "QOH";
	// 
	// mainMat1QohTextBox
	// 
	this.mainMat1QohTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
	this.mainMat1QohTextBox.Enabled = false;
	this.mainMat1QohTextBox.Location = new System.Drawing.Point(128, 136);
	this.mainMat1QohTextBox.Maximum = new System.Decimal(new int[] {
																	   1215752191,
																	   23,
																	   0,
																	   131072});
	this.mainMat1QohTextBox.MaxPrecision = 1;
	this.mainMat1QohTextBox.Minimum = new System.Decimal(new int[] {
																	   0,
																	   0,
																	   0,
																	   0});
	this.mainMat1QohTextBox.Name = "mainMat1QohTextBox";
	this.mainMat1QohTextBox.ReadOnly = true;
	this.mainMat1QohTextBox.Size = new System.Drawing.Size(176, 20);
	this.mainMat1QohTextBox.TabIndex = 77;
	this.mainMat1QohTextBox.Value = new System.Decimal(new int[] {
																	 0,
																	 0,
																	 0,
																	 0});
	// 
	// label37
	// 
	this.label37.Location = new System.Drawing.Point(8, 136);
	this.label37.Name = "label37";
	this.label37.Size = new System.Drawing.Size(96, 16);
	this.label37.TabIndex = 76;
	this.label37.Text = "Main Material Qty";
	// 
	// nextPart1SeqTextBox
	// 
	this.nextPart1SeqTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
	this.nextPart1SeqTextBox.Enabled = false;
	this.nextPart1SeqTextBox.Location = new System.Drawing.Point(128, 72);
	this.nextPart1SeqTextBox.Maximum = new System.Decimal(new int[] {
																		-727379969,
																		232,
																		0,
																		131072});
	this.nextPart1SeqTextBox.MaxPrecision = 1;
	this.nextPart1SeqTextBox.Minimum = new System.Decimal(new int[] {
																		0,
																		0,
																		0,
																		0});
	this.nextPart1SeqTextBox.Name = "nextPart1SeqTextBox";
	this.nextPart1SeqTextBox.ReadOnly = true;
	this.nextPart1SeqTextBox.Size = new System.Drawing.Size(176, 20);
	this.nextPart1SeqTextBox.TabIndex = 75;
	this.nextPart1SeqTextBox.Value = new System.Decimal(new int[] {
																	  0,
																	  0,
																	  0,
																	  0});
	// 
	// prePart1SeqTextBox
	// 
	this.prePart1SeqTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
	this.prePart1SeqTextBox.Enabled = false;
	this.prePart1SeqTextBox.Location = new System.Drawing.Point(128, 48);
	this.prePart1SeqTextBox.Maximum = new System.Decimal(new int[] {
																	   -727379969,
																	   232,
																	   0,
																	   131072});
	this.prePart1SeqTextBox.MaxPrecision = 1;
	this.prePart1SeqTextBox.Minimum = new System.Decimal(new int[] {
																	   0,
																	   0,
																	   0,
																	   0});
	this.prePart1SeqTextBox.Name = "prePart1SeqTextBox";
	this.prePart1SeqTextBox.ReadOnly = true;
	this.prePart1SeqTextBox.Size = new System.Drawing.Size(176, 20);
	this.prePart1SeqTextBox.TabIndex = 74;
	this.prePart1SeqTextBox.Value = new System.Decimal(new int[] {
																	 0,
																	 0,
																	 0,
																	 0});
	// 
	// currPart1SeqTextBox
	// 
	this.currPart1SeqTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
	this.currPart1SeqTextBox.Enabled = false;
	this.currPart1SeqTextBox.Location = new System.Drawing.Point(128, 24);
	this.currPart1SeqTextBox.Maximum = new System.Decimal(new int[] {
																		-727379969,
																		232,
																		0,
																		131072});
	this.currPart1SeqTextBox.MaxPrecision = 1;
	this.currPart1SeqTextBox.Minimum = new System.Decimal(new int[] {
																		0,
																		0,
																		0,
																		0});
	this.currPart1SeqTextBox.Name = "currPart1SeqTextBox";
	this.currPart1SeqTextBox.ReadOnly = true;
	this.currPart1SeqTextBox.Size = new System.Drawing.Size(176, 20);
	this.currPart1SeqTextBox.TabIndex = 73;
	this.currPart1SeqTextBox.Value = new System.Decimal(new int[] {
																	  0,
																	  0,
																	  0,
																	  0});
	// 
	// label27
	// 
	this.label27.Location = new System.Drawing.Point(8, 72);
	this.label27.Name = "label27";
	this.label27.Size = new System.Drawing.Size(120, 16);
	this.label27.TabIndex = 72;
	this.label27.Text = "Next Part Seq.       30";
	// 
	// label26
	// 
	this.label26.Location = new System.Drawing.Point(8, 48);
	this.label26.Name = "label26";
	this.label26.Size = new System.Drawing.Size(120, 16);
	this.label26.TabIndex = 71;
	this.label26.Text = "Previous Part Seq. 10";
	// 
	// label25
	// 
	this.label25.Location = new System.Drawing.Point(8, 24);
	this.label25.Name = "label25";
	this.label25.Size = new System.Drawing.Size(120, 16);
	this.label25.TabIndex = 70;
	this.label25.Text = "Current Part Seq.   20";
	// 
	// mainMaterialTextBox
	// 
	this.mainMaterialTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.mainMaterialTextBox.Enabled = false;
	this.mainMaterialTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.mainMaterialTextBox.Location = new System.Drawing.Point(128, 112);
	this.mainMaterialTextBox.MaxLength = 30;
	this.mainMaterialTextBox.Name = "mainMaterialTextBox";
	this.mainMaterialTextBox.ReadOnly = true;
	this.mainMaterialTextBox.Size = new System.Drawing.Size(128, 20);
	this.mainMaterialTextBox.TabIndex = 78;
	this.mainMaterialTextBox.Text = "";
	// 
	// label41
	// 
	this.label41.Location = new System.Drawing.Point(8, 112);
	this.label41.Name = "label41";
	this.label41.Size = new System.Drawing.Size(72, 16);
	this.label41.TabIndex = 77;
	this.label41.Text = "Main Material";
	// 
	// seqPart1ComboBox
	// 
	this.seqPart1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.seqPart1ComboBox.Enabled = false;
	this.seqPart1ComboBox.Location = new System.Drawing.Point(48, 40);
	this.seqPart1ComboBox.Name = "seqPart1ComboBox";
	this.seqPart1ComboBox.Size = new System.Drawing.Size(64, 21);
	this.seqPart1ComboBox.TabIndex = 69;
	this.seqPart1ComboBox.SelectedIndexChanged += new System.EventHandler(this.seqPart1ComboBox_SelectedIndexChanged);
	// 
	// label21
	// 
	this.label21.Location = new System.Drawing.Point(8, 40);
	this.label21.Name = "label21";
	this.label21.Size = new System.Drawing.Size(32, 16);
	this.label21.TabIndex = 68;
	this.label21.Text = "Seq.";
	// 
	// part1DescTextBox
	// 
	this.part1DescTextBox.AutoSize = false;
	this.part1DescTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.part1DescTextBox.Enabled = false;
	this.part1DescTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.part1DescTextBox.Location = new System.Drawing.Point(176, 16);
	this.part1DescTextBox.MaxLength = 60;
	this.part1DescTextBox.Multiline = true;
	this.part1DescTextBox.Name = "part1DescTextBox";
	this.part1DescTextBox.ReadOnly = true;
	this.part1DescTextBox.Size = new System.Drawing.Size(224, 20);
	this.part1DescTextBox.TabIndex = 67;
	this.part1DescTextBox.Text = "";
	// 
	// part1TextBox
	// 
	this.part1TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.part1TextBox.Location = new System.Drawing.Point(48, 16);
	this.part1TextBox.MaxLength = 30;
	this.part1TextBox.Name = "part1TextBox";
	this.part1TextBox.Size = new System.Drawing.Size(128, 20);
	this.part1TextBox.TabIndex = 0;
	this.part1TextBox.Text = "";
	// 
	// part1SearchButton
	// 
	this.part1SearchButton.Location = new System.Drawing.Point(408, 16);
	this.part1SearchButton.Name = "part1SearchButton";
	this.part1SearchButton.Size = new System.Drawing.Size(32, 16);
	this.part1SearchButton.TabIndex = 1;
	this.part1SearchButton.Text = "...";
	this.part1SearchButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
	this.part1SearchButton.Click += new System.EventHandler(this.part1SearchButton_Click);
	// 
	// label3
	// 
	this.label3.Location = new System.Drawing.Point(8, 16);
	this.label3.Name = "label3";
	this.label3.Size = new System.Drawing.Size(48, 20);
	this.label3.TabIndex = 65;
	this.label3.Text = "Part #1";
	this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label20
	// 
	this.label20.Location = new System.Drawing.Point(464, 40);
	this.label20.Name = "label20";
	this.label20.Size = new System.Drawing.Size(80, 20);
	this.label20.TabIndex = 81;
	this.label20.Text = "Next Operation";
	this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// operationTextBox
	// 
	this.operationTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.operationTextBox.Enabled = false;
	this.operationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.operationTextBox.Location = new System.Drawing.Point(544, 16);
	this.operationTextBox.MaxLength = 30;
	this.operationTextBox.Name = "operationTextBox";
	this.operationTextBox.ReadOnly = true;
	this.operationTextBox.Size = new System.Drawing.Size(128, 20);
	this.operationTextBox.TabIndex = 9;
	this.operationTextBox.Text = "";
	// 
	// label19
	// 
	this.label19.Location = new System.Drawing.Point(464, 16);
	this.label19.Name = "label19";
	this.label19.Size = new System.Drawing.Size(56, 20);
	this.label19.TabIndex = 80;
	this.label19.Text = "Operation";
	this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// nextOperationTextBox
	// 
	this.nextOperationTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.nextOperationTextBox.Enabled = false;
	this.nextOperationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.nextOperationTextBox.Location = new System.Drawing.Point(544, 40);
	this.nextOperationTextBox.MaxLength = 30;
	this.nextOperationTextBox.Name = "nextOperationTextBox";
	this.nextOperationTextBox.ReadOnly = true;
	this.nextOperationTextBox.Size = new System.Drawing.Size(128, 20);
	this.nextOperationTextBox.TabIndex = 10;
	this.nextOperationTextBox.Text = "";
	// 
	// runStandardTextBox
	// 
	this.runStandardTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
	this.runStandardTextBox.Enabled = false;
	this.runStandardTextBox.Location = new System.Drawing.Point(544, 104);
	this.runStandardTextBox.Maximum = new System.Decimal(new int[] {
																	   999999999,
																	   0,
																	   0,
																	   131072});
	this.runStandardTextBox.MaxPrecision = 1;
	this.runStandardTextBox.Minimum = new System.Decimal(new int[] {
																	   0,
																	   0,
																	   0,
																	   0});
	this.runStandardTextBox.Name = "runStandardTextBox";
	this.runStandardTextBox.ReadOnly = true;
	this.runStandardTextBox.Size = new System.Drawing.Size(128, 20);
	this.runStandardTextBox.TabIndex = 13;
	this.runStandardTextBox.Value = new System.Decimal(new int[] {
																	 0,
																	 0,
																	 0,
																	 0});
	// 
	// label10
	// 
	this.label10.Location = new System.Drawing.Point(464, 104);
	this.label10.Name = "label10";
	this.label10.Size = new System.Drawing.Size(80, 20);
	this.label10.TabIndex = 79;
	this.label10.Text = "Run Standard";
	this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// uomTextBox
	// 
	this.uomTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.uomTextBox.Enabled = false;
	this.uomTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.uomTextBox.Location = new System.Drawing.Point(544, 128);
	this.uomTextBox.MaxLength = 10;
	this.uomTextBox.Name = "uomTextBox";
	this.uomTextBox.ReadOnly = true;
	this.uomTextBox.Size = new System.Drawing.Size(48, 20);
	this.uomTextBox.TabIndex = 11;
	this.uomTextBox.Text = "";
	// 
	// label9
	// 
	this.label9.Location = new System.Drawing.Point(464, 128);
	this.label9.Name = "label9";
	this.label9.Size = new System.Drawing.Size(32, 20);
	this.label9.TabIndex = 78;
	this.label9.Text = "UOM";
	this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// runQtyTextBox
	// 
	this.runQtyTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
	this.runQtyTextBox.Enabled = false;
	this.runQtyTextBox.Location = new System.Drawing.Point(544, 80);
	this.runQtyTextBox.Maximum = new System.Decimal(new int[] {
																  1215752191,
																  23,
																  0,
																  131072});
	this.runQtyTextBox.MaxPrecision = 1;
	this.runQtyTextBox.Minimum = new System.Decimal(new int[] {
																  0,
																  0,
																  0,
																  0});
	this.runQtyTextBox.Name = "runQtyTextBox";
	this.runQtyTextBox.ReadOnly = true;
	this.runQtyTextBox.Size = new System.Drawing.Size(128, 20);
	this.runQtyTextBox.TabIndex = 12;
	this.runQtyTextBox.Value = new System.Decimal(new int[] {
																0,
																0,
																0,
																0});
	// 
	// label8
	// 
	this.label8.Location = new System.Drawing.Point(464, 80);
	this.label8.Name = "label8";
	this.label8.Size = new System.Drawing.Size(56, 20);
	this.label8.TabIndex = 77;
	this.label8.Text = "Run Qty";
	this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// part2TabPage
	// 
	this.part2TabPage.Controls.Add(this.part2GroupBox);
	this.part2TabPage.Location = new System.Drawing.Point(4, 22);
	this.part2TabPage.Name = "part2TabPage";
	this.part2TabPage.Size = new System.Drawing.Size(696, 270);
	this.part2TabPage.TabIndex = 5;
	this.part2TabPage.Text = "Part #2";
	// 
	// part2GroupBox
	// 
	this.part2GroupBox.Controls.Add(this.runStandard2TextBox);
	this.part2GroupBox.Controls.Add(this.label51);
	this.part2GroupBox.Controls.Add(this.uom2TextBox);
	this.part2GroupBox.Controls.Add(this.label52);
	this.part2GroupBox.Controls.Add(this.runQty2TextBox);
	this.part2GroupBox.Controls.Add(this.label53);
	this.part2GroupBox.Controls.Add(this.label45);
	this.part2GroupBox.Controls.Add(this.operation2TextBox);
	this.part2GroupBox.Controls.Add(this.label46);
	this.part2GroupBox.Controls.Add(this.nextOperation2TextBox);
	this.part2GroupBox.Controls.Add(this.groupBox9);
	this.part2GroupBox.Controls.Add(this.seqPart2ComboBox);
	this.part2GroupBox.Controls.Add(this.label22);
	this.part2GroupBox.Controls.Add(this.part2DescTextBox);
	this.part2GroupBox.Controls.Add(this.label6);
	this.part2GroupBox.Controls.Add(this.part2TextBox);
	this.part2GroupBox.Controls.Add(this.part2SearchButton);
	this.part2GroupBox.Location = new System.Drawing.Point(8, 8);
	this.part2GroupBox.Name = "part2GroupBox";
	this.part2GroupBox.Size = new System.Drawing.Size(680, 256);
	this.part2GroupBox.TabIndex = 0;
	this.part2GroupBox.TabStop = false;
	// 
	// runStandard2TextBox
	// 
	this.runStandard2TextBox.Enabled = false;
	this.runStandard2TextBox.Location = new System.Drawing.Point(544, 104);
	this.runStandard2TextBox.Maximum = new System.Decimal(new int[] {
																		999999999,
																		0,
																		0,
																		131072});
	this.runStandard2TextBox.MaxPrecision = 1;
	this.runStandard2TextBox.Minimum = new System.Decimal(new int[] {
																		0,
																		0,
																		0,
																		0});
	this.runStandard2TextBox.Name = "runStandard2TextBox";
	this.runStandard2TextBox.Size = new System.Drawing.Size(128, 20);
	this.runStandard2TextBox.TabIndex = 88;
	this.runStandard2TextBox.Value = new System.Decimal(new int[] {
																	  0,
																	  0,
																	  0,
																	  0});
	// 
	// label51
	// 
	this.label51.Location = new System.Drawing.Point(464, 104);
	this.label51.Name = "label51";
	this.label51.Size = new System.Drawing.Size(80, 20);
	this.label51.TabIndex = 91;
	this.label51.Text = "Run Standard";
	this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// uom2TextBox
	// 
	this.uom2TextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.uom2TextBox.Enabled = false;
	this.uom2TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.uom2TextBox.Location = new System.Drawing.Point(544, 128);
	this.uom2TextBox.MaxLength = 10;
	this.uom2TextBox.Name = "uom2TextBox";
	this.uom2TextBox.Size = new System.Drawing.Size(48, 20);
	this.uom2TextBox.TabIndex = 86;
	this.uom2TextBox.Text = "";
	// 
	// label52
	// 
	this.label52.Location = new System.Drawing.Point(464, 128);
	this.label52.Name = "label52";
	this.label52.Size = new System.Drawing.Size(32, 20);
	this.label52.TabIndex = 90;
	this.label52.Text = "UOM";
	this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// runQty2TextBox
	// 
	this.runQty2TextBox.Enabled = false;
	this.runQty2TextBox.Location = new System.Drawing.Point(544, 80);
	this.runQty2TextBox.Maximum = new System.Decimal(new int[] {
																   1215752191,
																   23,
																   0,
																   131072});
	this.runQty2TextBox.MaxPrecision = 1;
	this.runQty2TextBox.Minimum = new System.Decimal(new int[] {
																   0,
																   0,
																   0,
																   0});
	this.runQty2TextBox.Name = "runQty2TextBox";
	this.runQty2TextBox.Size = new System.Drawing.Size(128, 20);
	this.runQty2TextBox.TabIndex = 87;
	this.runQty2TextBox.Value = new System.Decimal(new int[] {
																 0,
																 0,
																 0,
																 0});
	// 
	// label53
	// 
	this.label53.Location = new System.Drawing.Point(464, 80);
	this.label53.Name = "label53";
	this.label53.Size = new System.Drawing.Size(56, 20);
	this.label53.TabIndex = 89;
	this.label53.Text = "Run Qty";
	this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label45
	// 
	this.label45.Location = new System.Drawing.Point(464, 40);
	this.label45.Name = "label45";
	this.label45.Size = new System.Drawing.Size(80, 20);
	this.label45.TabIndex = 85;
	this.label45.Text = "Next Operation";
	this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// operation2TextBox
	// 
	this.operation2TextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.operation2TextBox.Enabled = false;
	this.operation2TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.operation2TextBox.Location = new System.Drawing.Point(544, 16);
	this.operation2TextBox.MaxLength = 30;
	this.operation2TextBox.Name = "operation2TextBox";
	this.operation2TextBox.Size = new System.Drawing.Size(128, 20);
	this.operation2TextBox.TabIndex = 82;
	this.operation2TextBox.Text = "";
	// 
	// label46
	// 
	this.label46.Location = new System.Drawing.Point(464, 16);
	this.label46.Name = "label46";
	this.label46.Size = new System.Drawing.Size(56, 20);
	this.label46.TabIndex = 84;
	this.label46.Text = "Operation";
	this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// nextOperation2TextBox
	// 
	this.nextOperation2TextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.nextOperation2TextBox.Enabled = false;
	this.nextOperation2TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.nextOperation2TextBox.Location = new System.Drawing.Point(544, 40);
	this.nextOperation2TextBox.MaxLength = 30;
	this.nextOperation2TextBox.Name = "nextOperation2TextBox";
	this.nextOperation2TextBox.Size = new System.Drawing.Size(128, 20);
	this.nextOperation2TextBox.TabIndex = 83;
	this.nextOperation2TextBox.Text = "";
	// 
	// groupBox9
	// 
	this.groupBox9.Controls.Add(this.mainMat2QohTextBox);
	this.groupBox9.Controls.Add(this.label38);
	this.groupBox9.Controls.Add(this.nextPart2SeqTextBox);
	this.groupBox9.Controls.Add(this.prePart2SeqTextBox);
	this.groupBox9.Controls.Add(this.currPart2SeqTextBox);
	this.groupBox9.Controls.Add(this.label28);
	this.groupBox9.Controls.Add(this.label29);
	this.groupBox9.Controls.Add(this.label30);
	this.groupBox9.Controls.Add(this.mainMaterial2TextBox);
	this.groupBox9.Controls.Add(this.label42);
	this.groupBox9.Location = new System.Drawing.Point(8, 72);
	this.groupBox9.Name = "groupBox9";
	this.groupBox9.Size = new System.Drawing.Size(312, 168);
	this.groupBox9.TabIndex = 77;
	this.groupBox9.TabStop = false;
	this.groupBox9.Text = "QOH";
	// 
	// mainMat2QohTextBox
	// 
	this.mainMat2QohTextBox.Enabled = false;
	this.mainMat2QohTextBox.Location = new System.Drawing.Point(128, 136);
	this.mainMat2QohTextBox.Maximum = new System.Decimal(new int[] {
																	   1215752191,
																	   23,
																	   0,
																	   131072});
	this.mainMat2QohTextBox.MaxPrecision = 1;
	this.mainMat2QohTextBox.Minimum = new System.Decimal(new int[] {
																	   0,
																	   0,
																	   0,
																	   0});
	this.mainMat2QohTextBox.Name = "mainMat2QohTextBox";
	this.mainMat2QohTextBox.Size = new System.Drawing.Size(176, 20);
	this.mainMat2QohTextBox.TabIndex = 80;
	this.mainMat2QohTextBox.Value = new System.Decimal(new int[] {
																	 0,
																	 0,
																	 0,
																	 0});
	// 
	// label38
	// 
	this.label38.Location = new System.Drawing.Point(8, 136);
	this.label38.Name = "label38";
	this.label38.Size = new System.Drawing.Size(96, 16);
	this.label38.TabIndex = 79;
	this.label38.Text = "Main Material Qty";
	// 
	// nextPart2SeqTextBox
	// 
	this.nextPart2SeqTextBox.Enabled = false;
	this.nextPart2SeqTextBox.Location = new System.Drawing.Point(128, 72);
	this.nextPart2SeqTextBox.Maximum = new System.Decimal(new int[] {
																		-727379969,
																		232,
																		0,
																		131072});
	this.nextPart2SeqTextBox.MaxPrecision = 1;
	this.nextPart2SeqTextBox.Minimum = new System.Decimal(new int[] {
																		0,
																		0,
																		0,
																		0});
	this.nextPart2SeqTextBox.Name = "nextPart2SeqTextBox";
	this.nextPart2SeqTextBox.Size = new System.Drawing.Size(176, 20);
	this.nextPart2SeqTextBox.TabIndex = 78;
	this.nextPart2SeqTextBox.Value = new System.Decimal(new int[] {
																	  0,
																	  0,
																	  0,
																	  0});
	// 
	// prePart2SeqTextBox
	// 
	this.prePart2SeqTextBox.Enabled = false;
	this.prePart2SeqTextBox.Location = new System.Drawing.Point(128, 48);
	this.prePart2SeqTextBox.Maximum = new System.Decimal(new int[] {
																	   -727379969,
																	   232,
																	   0,
																	   131072});
	this.prePart2SeqTextBox.MaxPrecision = 1;
	this.prePart2SeqTextBox.Minimum = new System.Decimal(new int[] {
																	   0,
																	   0,
																	   0,
																	   0});
	this.prePart2SeqTextBox.Name = "prePart2SeqTextBox";
	this.prePart2SeqTextBox.Size = new System.Drawing.Size(176, 20);
	this.prePart2SeqTextBox.TabIndex = 77;
	this.prePart2SeqTextBox.Value = new System.Decimal(new int[] {
																	 0,
																	 0,
																	 0,
																	 0});
	// 
	// currPart2SeqTextBox
	// 
	this.currPart2SeqTextBox.Enabled = false;
	this.currPart2SeqTextBox.Location = new System.Drawing.Point(128, 24);
	this.currPart2SeqTextBox.Maximum = new System.Decimal(new int[] {
																		-727379969,
																		232,
																		0,
																		131072});
	this.currPart2SeqTextBox.MaxPrecision = 1;
	this.currPart2SeqTextBox.Minimum = new System.Decimal(new int[] {
																		0,
																		0,
																		0,
																		0});
	this.currPart2SeqTextBox.Name = "currPart2SeqTextBox";
	this.currPart2SeqTextBox.Size = new System.Drawing.Size(176, 20);
	this.currPart2SeqTextBox.TabIndex = 76;
	this.currPart2SeqTextBox.Value = new System.Decimal(new int[] {
																	  0,
																	  0,
																	  0,
																	  0});
	// 
	// label28
	// 
	this.label28.Location = new System.Drawing.Point(8, 72);
	this.label28.Name = "label28";
	this.label28.Size = new System.Drawing.Size(120, 16);
	this.label28.TabIndex = 72;
	this.label28.Text = "Next Part Seq.       30";
	// 
	// label29
	// 
	this.label29.Location = new System.Drawing.Point(8, 48);
	this.label29.Name = "label29";
	this.label29.Size = new System.Drawing.Size(120, 16);
	this.label29.TabIndex = 71;
	this.label29.Text = "Previous Part Seq. 10";
	// 
	// label30
	// 
	this.label30.Location = new System.Drawing.Point(8, 24);
	this.label30.Name = "label30";
	this.label30.Size = new System.Drawing.Size(120, 16);
	this.label30.TabIndex = 70;
	this.label30.Text = "Current Part Seq.   20";
	// 
	// mainMaterial2TextBox
	// 
	this.mainMaterial2TextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.mainMaterial2TextBox.Enabled = false;
	this.mainMaterial2TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.mainMaterial2TextBox.Location = new System.Drawing.Point(128, 112);
	this.mainMaterial2TextBox.MaxLength = 30;
	this.mainMaterial2TextBox.Name = "mainMaterial2TextBox";
	this.mainMaterial2TextBox.Size = new System.Drawing.Size(128, 20);
	this.mainMaterial2TextBox.TabIndex = 81;
	this.mainMaterial2TextBox.Text = "";
	// 
	// label42
	// 
	this.label42.Location = new System.Drawing.Point(8, 112);
	this.label42.Name = "label42";
	this.label42.Size = new System.Drawing.Size(72, 16);
	this.label42.TabIndex = 80;
	this.label42.Text = "Main Material";
	// 
	// seqPart2ComboBox
	// 
	this.seqPart2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.seqPart2ComboBox.Enabled = false;
	this.seqPart2ComboBox.Location = new System.Drawing.Point(48, 40);
	this.seqPart2ComboBox.Name = "seqPart2ComboBox";
	this.seqPart2ComboBox.Size = new System.Drawing.Size(64, 21);
	this.seqPart2ComboBox.TabIndex = 61;
	this.seqPart2ComboBox.SelectedIndexChanged += new System.EventHandler(this.seqPart2ComboBox_SelectedIndexChanged);
	// 
	// label22
	// 
	this.label22.Location = new System.Drawing.Point(8, 40);
	this.label22.Name = "label22";
	this.label22.Size = new System.Drawing.Size(32, 16);
	this.label22.TabIndex = 60;
	this.label22.Text = "Seq.";
	// 
	// part2DescTextBox
	// 
	this.part2DescTextBox.AutoSize = false;
	this.part2DescTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.part2DescTextBox.Enabled = false;
	this.part2DescTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.part2DescTextBox.Location = new System.Drawing.Point(176, 16);
	this.part2DescTextBox.MaxLength = 60;
	this.part2DescTextBox.Multiline = true;
	this.part2DescTextBox.Name = "part2DescTextBox";
	this.part2DescTextBox.ReadOnly = true;
	this.part2DescTextBox.Size = new System.Drawing.Size(224, 20);
	this.part2DescTextBox.TabIndex = 59;
	this.part2DescTextBox.Text = "";
	// 
	// label6
	// 
	this.label6.BackColor = System.Drawing.SystemColors.Control;
	this.label6.Location = new System.Drawing.Point(8, 16);
	this.label6.Name = "label6";
	this.label6.Size = new System.Drawing.Size(41, 20);
	this.label6.TabIndex = 57;
	this.label6.Text = "Part #2";
	this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// part2TextBox
	// 
	this.part2TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.part2TextBox.Location = new System.Drawing.Point(48, 16);
	this.part2TextBox.MaxLength = 30;
	this.part2TextBox.Name = "part2TextBox";
	this.part2TextBox.Size = new System.Drawing.Size(128, 20);
	this.part2TextBox.TabIndex = 58;
	this.part2TextBox.Text = "";
	// 
	// part2SearchButton
	// 
	this.part2SearchButton.Location = new System.Drawing.Point(408, 16);
	this.part2SearchButton.Name = "part2SearchButton";
	this.part2SearchButton.Size = new System.Drawing.Size(32, 16);
	this.part2SearchButton.TabIndex = 56;
	this.part2SearchButton.Text = "...";
	this.part2SearchButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
	this.part2SearchButton.Click += new System.EventHandler(this.part2SearchButton_Click);
	// 
	// part3TabPage
	// 
	this.part3TabPage.Controls.Add(this.part3GroupBox);
	this.part3TabPage.Location = new System.Drawing.Point(4, 22);
	this.part3TabPage.Name = "part3TabPage";
	this.part3TabPage.Size = new System.Drawing.Size(696, 270);
	this.part3TabPage.TabIndex = 6;
	this.part3TabPage.Text = "Part #3";
	// 
	// part3GroupBox
	// 
	this.part3GroupBox.Controls.Add(this.runStandard3TextBox);
	this.part3GroupBox.Controls.Add(this.label54);
	this.part3GroupBox.Controls.Add(this.uom3TextBox);
	this.part3GroupBox.Controls.Add(this.label55);
	this.part3GroupBox.Controls.Add(this.runQty3TextBox);
	this.part3GroupBox.Controls.Add(this.label56);
	this.part3GroupBox.Controls.Add(this.label47);
	this.part3GroupBox.Controls.Add(this.operation3TextBox);
	this.part3GroupBox.Controls.Add(this.label48);
	this.part3GroupBox.Controls.Add(this.nextOperation3TextBox);
	this.part3GroupBox.Controls.Add(this.groupBox10);
	this.part3GroupBox.Controls.Add(this.seqPart3ComboBox);
	this.part3GroupBox.Controls.Add(this.label23);
	this.part3GroupBox.Controls.Add(this.part3DescTextBox);
	this.part3GroupBox.Controls.Add(this.part3SearchButton);
	this.part3GroupBox.Controls.Add(this.part3TextBox);
	this.part3GroupBox.Controls.Add(this.label4);
	this.part3GroupBox.Location = new System.Drawing.Point(8, 8);
	this.part3GroupBox.Name = "part3GroupBox";
	this.part3GroupBox.Size = new System.Drawing.Size(680, 256);
	this.part3GroupBox.TabIndex = 0;
	this.part3GroupBox.TabStop = false;
	// 
	// runStandard3TextBox
	// 
	this.runStandard3TextBox.Enabled = false;
	this.runStandard3TextBox.Location = new System.Drawing.Point(544, 104);
	this.runStandard3TextBox.Maximum = new System.Decimal(new int[] {
																		999999999,
																		0,
																		0,
																		131072});
	this.runStandard3TextBox.MaxPrecision = 1;
	this.runStandard3TextBox.Minimum = new System.Decimal(new int[] {
																		0,
																		0,
																		0,
																		0});
	this.runStandard3TextBox.Name = "runStandard3TextBox";
	this.runStandard3TextBox.Size = new System.Drawing.Size(128, 20);
	this.runStandard3TextBox.TabIndex = 92;
	this.runStandard3TextBox.Value = new System.Decimal(new int[] {
																	  0,
																	  0,
																	  0,
																	  0});
	// 
	// label54
	// 
	this.label54.Location = new System.Drawing.Point(464, 104);
	this.label54.Name = "label54";
	this.label54.Size = new System.Drawing.Size(80, 20);
	this.label54.TabIndex = 95;
	this.label54.Text = "Run Standard";
	this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// uom3TextBox
	// 
	this.uom3TextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.uom3TextBox.Enabled = false;
	this.uom3TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.uom3TextBox.Location = new System.Drawing.Point(544, 128);
	this.uom3TextBox.MaxLength = 10;
	this.uom3TextBox.Name = "uom3TextBox";
	this.uom3TextBox.Size = new System.Drawing.Size(48, 20);
	this.uom3TextBox.TabIndex = 90;
	this.uom3TextBox.Text = "";
	// 
	// label55
	// 
	this.label55.Location = new System.Drawing.Point(464, 128);
	this.label55.Name = "label55";
	this.label55.Size = new System.Drawing.Size(32, 20);
	this.label55.TabIndex = 94;
	this.label55.Text = "UOM";
	this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// runQty3TextBox
	// 
	this.runQty3TextBox.Enabled = false;
	this.runQty3TextBox.Location = new System.Drawing.Point(544, 80);
	this.runQty3TextBox.Maximum = new System.Decimal(new int[] {
																   1215752191,
																   23,
																   0,
																   131072});
	this.runQty3TextBox.MaxPrecision = 1;
	this.runQty3TextBox.Minimum = new System.Decimal(new int[] {
																   0,
																   0,
																   0,
																   0});
	this.runQty3TextBox.Name = "runQty3TextBox";
	this.runQty3TextBox.Size = new System.Drawing.Size(128, 20);
	this.runQty3TextBox.TabIndex = 91;
	this.runQty3TextBox.Value = new System.Decimal(new int[] {
																 0,
																 0,
																 0,
																 0});
	// 
	// label56
	// 
	this.label56.Location = new System.Drawing.Point(464, 80);
	this.label56.Name = "label56";
	this.label56.Size = new System.Drawing.Size(56, 20);
	this.label56.TabIndex = 93;
	this.label56.Text = "Run Qty";
	this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label47
	// 
	this.label47.Location = new System.Drawing.Point(464, 40);
	this.label47.Name = "label47";
	this.label47.Size = new System.Drawing.Size(80, 20);
	this.label47.TabIndex = 89;
	this.label47.Text = "Next Operation";
	this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// operation3TextBox
	// 
	this.operation3TextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.operation3TextBox.Enabled = false;
	this.operation3TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.operation3TextBox.Location = new System.Drawing.Point(544, 16);
	this.operation3TextBox.MaxLength = 30;
	this.operation3TextBox.Name = "operation3TextBox";
	this.operation3TextBox.Size = new System.Drawing.Size(128, 20);
	this.operation3TextBox.TabIndex = 86;
	this.operation3TextBox.Text = "";
	// 
	// label48
	// 
	this.label48.Location = new System.Drawing.Point(464, 16);
	this.label48.Name = "label48";
	this.label48.Size = new System.Drawing.Size(56, 20);
	this.label48.TabIndex = 88;
	this.label48.Text = "Operation";
	this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// nextOperation3TextBox
	// 
	this.nextOperation3TextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.nextOperation3TextBox.Enabled = false;
	this.nextOperation3TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.nextOperation3TextBox.Location = new System.Drawing.Point(544, 40);
	this.nextOperation3TextBox.MaxLength = 30;
	this.nextOperation3TextBox.Name = "nextOperation3TextBox";
	this.nextOperation3TextBox.Size = new System.Drawing.Size(128, 20);
	this.nextOperation3TextBox.TabIndex = 87;
	this.nextOperation3TextBox.Text = "";
	// 
	// groupBox10
	// 
	this.groupBox10.Controls.Add(this.mainMat3QohTextBox);
	this.groupBox10.Controls.Add(this.label39);
	this.groupBox10.Controls.Add(this.nextPart3SeqTextBox);
	this.groupBox10.Controls.Add(this.prePart3SeqTextBox);
	this.groupBox10.Controls.Add(this.currPart3SeqTextBox);
	this.groupBox10.Controls.Add(this.label31);
	this.groupBox10.Controls.Add(this.label32);
	this.groupBox10.Controls.Add(this.label33);
	this.groupBox10.Controls.Add(this.mainMaterial3TextBox);
	this.groupBox10.Controls.Add(this.label43);
	this.groupBox10.Location = new System.Drawing.Point(8, 72);
	this.groupBox10.Name = "groupBox10";
	this.groupBox10.Size = new System.Drawing.Size(312, 168);
	this.groupBox10.TabIndex = 78;
	this.groupBox10.TabStop = false;
	this.groupBox10.Text = "QOH";
	// 
	// mainMat3QohTextBox
	// 
	this.mainMat3QohTextBox.Enabled = false;
	this.mainMat3QohTextBox.Location = new System.Drawing.Point(128, 136);
	this.mainMat3QohTextBox.Maximum = new System.Decimal(new int[] {
																	   1215752191,
																	   23,
																	   0,
																	   131072});
	this.mainMat3QohTextBox.MaxPrecision = 1;
	this.mainMat3QohTextBox.Minimum = new System.Decimal(new int[] {
																	   0,
																	   0,
																	   0,
																	   0});
	this.mainMat3QohTextBox.Name = "mainMat3QohTextBox";
	this.mainMat3QohTextBox.Size = new System.Drawing.Size(176, 20);
	this.mainMat3QohTextBox.TabIndex = 83;
	this.mainMat3QohTextBox.Value = new System.Decimal(new int[] {
																	 0,
																	 0,
																	 0,
																	 0});
	// 
	// label39
	// 
	this.label39.Location = new System.Drawing.Point(8, 136);
	this.label39.Name = "label39";
	this.label39.Size = new System.Drawing.Size(96, 16);
	this.label39.TabIndex = 82;
	this.label39.Text = "Main Material Qty";
	// 
	// nextPart3SeqTextBox
	// 
	this.nextPart3SeqTextBox.Enabled = false;
	this.nextPart3SeqTextBox.Location = new System.Drawing.Point(128, 72);
	this.nextPart3SeqTextBox.Maximum = new System.Decimal(new int[] {
																		-727379969,
																		232,
																		0,
																		131072});
	this.nextPart3SeqTextBox.MaxPrecision = 1;
	this.nextPart3SeqTextBox.Minimum = new System.Decimal(new int[] {
																		0,
																		0,
																		0,
																		0});
	this.nextPart3SeqTextBox.Name = "nextPart3SeqTextBox";
	this.nextPart3SeqTextBox.Size = new System.Drawing.Size(176, 20);
	this.nextPart3SeqTextBox.TabIndex = 81;
	this.nextPart3SeqTextBox.Value = new System.Decimal(new int[] {
																	  0,
																	  0,
																	  0,
																	  0});
	// 
	// prePart3SeqTextBox
	// 
	this.prePart3SeqTextBox.Enabled = false;
	this.prePart3SeqTextBox.Location = new System.Drawing.Point(128, 48);
	this.prePart3SeqTextBox.Maximum = new System.Decimal(new int[] {
																	   -727379969,
																	   232,
																	   0,
																	   131072});
	this.prePart3SeqTextBox.MaxPrecision = 1;
	this.prePart3SeqTextBox.Minimum = new System.Decimal(new int[] {
																	   0,
																	   0,
																	   0,
																	   0});
	this.prePart3SeqTextBox.Name = "prePart3SeqTextBox";
	this.prePart3SeqTextBox.Size = new System.Drawing.Size(176, 20);
	this.prePart3SeqTextBox.TabIndex = 80;
	this.prePart3SeqTextBox.Value = new System.Decimal(new int[] {
																	 0,
																	 0,
																	 0,
																	 0});
	// 
	// currPart3SeqTextBox
	// 
	this.currPart3SeqTextBox.Enabled = false;
	this.currPart3SeqTextBox.Location = new System.Drawing.Point(128, 24);
	this.currPart3SeqTextBox.Maximum = new System.Decimal(new int[] {
																		-727379969,
																		232,
																		0,
																		131072});
	this.currPart3SeqTextBox.MaxPrecision = 1;
	this.currPart3SeqTextBox.Minimum = new System.Decimal(new int[] {
																		0,
																		0,
																		0,
																		0});
	this.currPart3SeqTextBox.Name = "currPart3SeqTextBox";
	this.currPart3SeqTextBox.Size = new System.Drawing.Size(176, 20);
	this.currPart3SeqTextBox.TabIndex = 79;
	this.currPart3SeqTextBox.Value = new System.Decimal(new int[] {
																	  0,
																	  0,
																	  0,
																	  0});
	// 
	// label31
	// 
	this.label31.Location = new System.Drawing.Point(8, 72);
	this.label31.Name = "label31";
	this.label31.Size = new System.Drawing.Size(120, 16);
	this.label31.TabIndex = 72;
	this.label31.Text = "Next Part Seq.       30";
	// 
	// label32
	// 
	this.label32.Location = new System.Drawing.Point(8, 48);
	this.label32.Name = "label32";
	this.label32.Size = new System.Drawing.Size(120, 16);
	this.label32.TabIndex = 71;
	this.label32.Text = "Previous Part Seq. 10";
	// 
	// label33
	// 
	this.label33.Location = new System.Drawing.Point(8, 24);
	this.label33.Name = "label33";
	this.label33.Size = new System.Drawing.Size(120, 16);
	this.label33.TabIndex = 70;
	this.label33.Text = "Current Part Seq.   20";
	// 
	// mainMaterial3TextBox
	// 
	this.mainMaterial3TextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.mainMaterial3TextBox.Enabled = false;
	this.mainMaterial3TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.mainMaterial3TextBox.Location = new System.Drawing.Point(128, 112);
	this.mainMaterial3TextBox.MaxLength = 30;
	this.mainMaterial3TextBox.Name = "mainMaterial3TextBox";
	this.mainMaterial3TextBox.Size = new System.Drawing.Size(128, 20);
	this.mainMaterial3TextBox.TabIndex = 81;
	this.mainMaterial3TextBox.Text = "";
	// 
	// label43
	// 
	this.label43.Location = new System.Drawing.Point(8, 112);
	this.label43.Name = "label43";
	this.label43.Size = new System.Drawing.Size(72, 16);
	this.label43.TabIndex = 80;
	this.label43.Text = "Main Material";
	// 
	// seqPart3ComboBox
	// 
	this.seqPart3ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.seqPart3ComboBox.Enabled = false;
	this.seqPart3ComboBox.Location = new System.Drawing.Point(48, 40);
	this.seqPart3ComboBox.Name = "seqPart3ComboBox";
	this.seqPart3ComboBox.Size = new System.Drawing.Size(64, 21);
	this.seqPart3ComboBox.TabIndex = 62;
	this.seqPart3ComboBox.SelectedIndexChanged += new System.EventHandler(this.seqPart3ComboBox_SelectedIndexChanged);
	// 
	// label23
	// 
	this.label23.Location = new System.Drawing.Point(8, 40);
	this.label23.Name = "label23";
	this.label23.Size = new System.Drawing.Size(32, 16);
	this.label23.TabIndex = 61;
	this.label23.Text = "Seq.";
	// 
	// part3DescTextBox
	// 
	this.part3DescTextBox.AutoSize = false;
	this.part3DescTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.part3DescTextBox.Enabled = false;
	this.part3DescTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.part3DescTextBox.Location = new System.Drawing.Point(176, 16);
	this.part3DescTextBox.MaxLength = 60;
	this.part3DescTextBox.Multiline = true;
	this.part3DescTextBox.Name = "part3DescTextBox";
	this.part3DescTextBox.Size = new System.Drawing.Size(224, 20);
	this.part3DescTextBox.TabIndex = 60;
	this.part3DescTextBox.Text = "";
	// 
	// part3SearchButton
	// 
	this.part3SearchButton.Location = new System.Drawing.Point(408, 16);
	this.part3SearchButton.Name = "part3SearchButton";
	this.part3SearchButton.Size = new System.Drawing.Size(32, 16);
	this.part3SearchButton.TabIndex = 57;
	this.part3SearchButton.Text = "...";
	this.part3SearchButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
	this.part3SearchButton.Click += new System.EventHandler(this.part3SearchButton_Click);
	// 
	// part3TextBox
	// 
	this.part3TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.part3TextBox.Location = new System.Drawing.Point(48, 16);
	this.part3TextBox.MaxLength = 30;
	this.part3TextBox.Name = "part3TextBox";
	this.part3TextBox.Size = new System.Drawing.Size(128, 20);
	this.part3TextBox.TabIndex = 59;
	this.part3TextBox.Text = "";
	// 
	// label4
	// 
	this.label4.Location = new System.Drawing.Point(8, 16);
	this.label4.Name = "label4";
	this.label4.Size = new System.Drawing.Size(48, 20);
	this.label4.TabIndex = 58;
	this.label4.Text = "Part #3";
	this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// part4TabPage
	// 
	this.part4TabPage.Controls.Add(this.part4GroupBox);
	this.part4TabPage.Location = new System.Drawing.Point(4, 22);
	this.part4TabPage.Name = "part4TabPage";
	this.part4TabPage.Size = new System.Drawing.Size(696, 270);
	this.part4TabPage.TabIndex = 7;
	this.part4TabPage.Text = "Part #4";
	// 
	// part4GroupBox
	// 
	this.part4GroupBox.Controls.Add(this.runStandard4TextBox);
	this.part4GroupBox.Controls.Add(this.label57);
	this.part4GroupBox.Controls.Add(this.uom4TextBox);
	this.part4GroupBox.Controls.Add(this.label58);
	this.part4GroupBox.Controls.Add(this.runQty4TextBox);
	this.part4GroupBox.Controls.Add(this.label59);
	this.part4GroupBox.Controls.Add(this.label49);
	this.part4GroupBox.Controls.Add(this.operation4TextBox);
	this.part4GroupBox.Controls.Add(this.label50);
	this.part4GroupBox.Controls.Add(this.nextOperation4TextBox);
	this.part4GroupBox.Controls.Add(this.groupBox4);
	this.part4GroupBox.Controls.Add(this.seqPart4ComboBox);
	this.part4GroupBox.Controls.Add(this.label24);
	this.part4GroupBox.Controls.Add(this.part4DescTextBox);
	this.part4GroupBox.Controls.Add(this.part4SearchButton);
	this.part4GroupBox.Controls.Add(this.part4TextBox);
	this.part4GroupBox.Controls.Add(this.label5);
	this.part4GroupBox.Location = new System.Drawing.Point(8, 8);
	this.part4GroupBox.Name = "part4GroupBox";
	this.part4GroupBox.Size = new System.Drawing.Size(680, 256);
	this.part4GroupBox.TabIndex = 0;
	this.part4GroupBox.TabStop = false;
	// 
	// runStandard4TextBox
	// 
	this.runStandard4TextBox.Enabled = false;
	this.runStandard4TextBox.Location = new System.Drawing.Point(544, 104);
	this.runStandard4TextBox.Maximum = new System.Decimal(new int[] {
																		999999999,
																		0,
																		0,
																		131072});
	this.runStandard4TextBox.MaxPrecision = 1;
	this.runStandard4TextBox.Minimum = new System.Decimal(new int[] {
																		0,
																		0,
																		0,
																		0});
	this.runStandard4TextBox.Name = "runStandard4TextBox";
	this.runStandard4TextBox.Size = new System.Drawing.Size(128, 20);
	this.runStandard4TextBox.TabIndex = 92;
	this.runStandard4TextBox.Value = new System.Decimal(new int[] {
																	  0,
																	  0,
																	  0,
																	  0});
	// 
	// label57
	// 
	this.label57.Location = new System.Drawing.Point(464, 104);
	this.label57.Name = "label57";
	this.label57.Size = new System.Drawing.Size(80, 20);
	this.label57.TabIndex = 95;
	this.label57.Text = "Run Standard";
	this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// uom4TextBox
	// 
	this.uom4TextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.uom4TextBox.Enabled = false;
	this.uom4TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.uom4TextBox.Location = new System.Drawing.Point(544, 128);
	this.uom4TextBox.MaxLength = 10;
	this.uom4TextBox.Name = "uom4TextBox";
	this.uom4TextBox.Size = new System.Drawing.Size(48, 20);
	this.uom4TextBox.TabIndex = 90;
	this.uom4TextBox.Text = "";
	// 
	// label58
	// 
	this.label58.Location = new System.Drawing.Point(464, 128);
	this.label58.Name = "label58";
	this.label58.Size = new System.Drawing.Size(32, 20);
	this.label58.TabIndex = 94;
	this.label58.Text = "UOM";
	this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// runQty4TextBox
	// 
	this.runQty4TextBox.Enabled = false;
	this.runQty4TextBox.Location = new System.Drawing.Point(544, 80);
	this.runQty4TextBox.Maximum = new System.Decimal(new int[] {
																   1215752191,
																   23,
																   0,
																   131072});
	this.runQty4TextBox.MaxPrecision = 1;
	this.runQty4TextBox.Minimum = new System.Decimal(new int[] {
																   0,
																   0,
																   0,
																   0});
	this.runQty4TextBox.Name = "runQty4TextBox";
	this.runQty4TextBox.Size = new System.Drawing.Size(128, 20);
	this.runQty4TextBox.TabIndex = 91;
	this.runQty4TextBox.Value = new System.Decimal(new int[] {
																 0,
																 0,
																 0,
																 0});
	// 
	// label59
	// 
	this.label59.Location = new System.Drawing.Point(464, 80);
	this.label59.Name = "label59";
	this.label59.Size = new System.Drawing.Size(56, 20);
	this.label59.TabIndex = 93;
	this.label59.Text = "Run Qty";
	this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label49
	// 
	this.label49.Location = new System.Drawing.Point(464, 40);
	this.label49.Name = "label49";
	this.label49.Size = new System.Drawing.Size(80, 20);
	this.label49.TabIndex = 89;
	this.label49.Text = "Next Operation";
	this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// operation4TextBox
	// 
	this.operation4TextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.operation4TextBox.Enabled = false;
	this.operation4TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.operation4TextBox.Location = new System.Drawing.Point(544, 16);
	this.operation4TextBox.MaxLength = 30;
	this.operation4TextBox.Name = "operation4TextBox";
	this.operation4TextBox.Size = new System.Drawing.Size(128, 20);
	this.operation4TextBox.TabIndex = 86;
	this.operation4TextBox.Text = "";
	// 
	// label50
	// 
	this.label50.Location = new System.Drawing.Point(464, 16);
	this.label50.Name = "label50";
	this.label50.Size = new System.Drawing.Size(56, 20);
	this.label50.TabIndex = 88;
	this.label50.Text = "Operation";
	this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// nextOperation4TextBox
	// 
	this.nextOperation4TextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.nextOperation4TextBox.Enabled = false;
	this.nextOperation4TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.nextOperation4TextBox.Location = new System.Drawing.Point(544, 40);
	this.nextOperation4TextBox.MaxLength = 30;
	this.nextOperation4TextBox.Name = "nextOperation4TextBox";
	this.nextOperation4TextBox.Size = new System.Drawing.Size(128, 20);
	this.nextOperation4TextBox.TabIndex = 87;
	this.nextOperation4TextBox.Text = "";
	// 
	// groupBox4
	// 
	this.groupBox4.Controls.Add(this.mainMat4QohTextBox);
	this.groupBox4.Controls.Add(this.label40);
	this.groupBox4.Controls.Add(this.nextPart4SeqTextBox);
	this.groupBox4.Controls.Add(this.prePart4SeqTextBox);
	this.groupBox4.Controls.Add(this.currPart4SeqTextBox);
	this.groupBox4.Controls.Add(this.label34);
	this.groupBox4.Controls.Add(this.label35);
	this.groupBox4.Controls.Add(this.label36);
	this.groupBox4.Controls.Add(this.mainMaterial4TextBox);
	this.groupBox4.Controls.Add(this.label44);
	this.groupBox4.Location = new System.Drawing.Point(8, 72);
	this.groupBox4.Name = "groupBox4";
	this.groupBox4.Size = new System.Drawing.Size(312, 168);
	this.groupBox4.TabIndex = 79;
	this.groupBox4.TabStop = false;
	this.groupBox4.Text = "QOH";
	// 
	// mainMat4QohTextBox
	// 
	this.mainMat4QohTextBox.Enabled = false;
	this.mainMat4QohTextBox.Location = new System.Drawing.Point(128, 136);
	this.mainMat4QohTextBox.Maximum = new System.Decimal(new int[] {
																	   1215752191,
																	   23,
																	   0,
																	   131072});
	this.mainMat4QohTextBox.MaxPrecision = 1;
	this.mainMat4QohTextBox.Minimum = new System.Decimal(new int[] {
																	   0,
																	   0,
																	   0,
																	   0});
	this.mainMat4QohTextBox.Name = "mainMat4QohTextBox";
	this.mainMat4QohTextBox.Size = new System.Drawing.Size(176, 20);
	this.mainMat4QohTextBox.TabIndex = 86;
	this.mainMat4QohTextBox.Value = new System.Decimal(new int[] {
																	 0,
																	 0,
																	 0,
																	 0});
	// 
	// label40
	// 
	this.label40.Location = new System.Drawing.Point(8, 136);
	this.label40.Name = "label40";
	this.label40.Size = new System.Drawing.Size(96, 16);
	this.label40.TabIndex = 85;
	this.label40.Text = "Main Material Qty";
	// 
	// nextPart4SeqTextBox
	// 
	this.nextPart4SeqTextBox.Enabled = false;
	this.nextPart4SeqTextBox.Location = new System.Drawing.Point(128, 72);
	this.nextPart4SeqTextBox.Maximum = new System.Decimal(new int[] {
																		-727379969,
																		232,
																		0,
																		131072});
	this.nextPart4SeqTextBox.MaxPrecision = 1;
	this.nextPart4SeqTextBox.Minimum = new System.Decimal(new int[] {
																		0,
																		0,
																		0,
																		0});
	this.nextPart4SeqTextBox.Name = "nextPart4SeqTextBox";
	this.nextPart4SeqTextBox.Size = new System.Drawing.Size(176, 20);
	this.nextPart4SeqTextBox.TabIndex = 84;
	this.nextPart4SeqTextBox.Value = new System.Decimal(new int[] {
																	  0,
																	  0,
																	  0,
																	  0});
	// 
	// prePart4SeqTextBox
	// 
	this.prePart4SeqTextBox.Enabled = false;
	this.prePart4SeqTextBox.Location = new System.Drawing.Point(128, 48);
	this.prePart4SeqTextBox.Maximum = new System.Decimal(new int[] {
																	   -727379969,
																	   232,
																	   0,
																	   131072});
	this.prePart4SeqTextBox.MaxPrecision = 1;
	this.prePart4SeqTextBox.Minimum = new System.Decimal(new int[] {
																	   0,
																	   0,
																	   0,
																	   0});
	this.prePart4SeqTextBox.Name = "prePart4SeqTextBox";
	this.prePart4SeqTextBox.Size = new System.Drawing.Size(176, 20);
	this.prePart4SeqTextBox.TabIndex = 83;
	this.prePart4SeqTextBox.Value = new System.Decimal(new int[] {
																	 0,
																	 0,
																	 0,
																	 0});
	// 
	// currPart4SeqTextBox
	// 
	this.currPart4SeqTextBox.Enabled = false;
	this.currPart4SeqTextBox.Location = new System.Drawing.Point(128, 24);
	this.currPart4SeqTextBox.Maximum = new System.Decimal(new int[] {
																		-727379969,
																		232,
																		0,
																		131072});
	this.currPart4SeqTextBox.MaxPrecision = 1;
	this.currPart4SeqTextBox.Minimum = new System.Decimal(new int[] {
																		0,
																		0,
																		0,
																		0});
	this.currPart4SeqTextBox.Name = "currPart4SeqTextBox";
	this.currPart4SeqTextBox.Size = new System.Drawing.Size(176, 20);
	this.currPart4SeqTextBox.TabIndex = 82;
	this.currPart4SeqTextBox.Value = new System.Decimal(new int[] {
																	  0,
																	  0,
																	  0,
																	  0});
	// 
	// label34
	// 
	this.label34.Location = new System.Drawing.Point(8, 72);
	this.label34.Name = "label34";
	this.label34.Size = new System.Drawing.Size(120, 16);
	this.label34.TabIndex = 72;
	this.label34.Text = "Next Part Seq.       30";
	// 
	// label35
	// 
	this.label35.Location = new System.Drawing.Point(8, 48);
	this.label35.Name = "label35";
	this.label35.Size = new System.Drawing.Size(120, 16);
	this.label35.TabIndex = 71;
	this.label35.Text = "Previous Part Seq. 10";
	// 
	// label36
	// 
	this.label36.Location = new System.Drawing.Point(8, 24);
	this.label36.Name = "label36";
	this.label36.Size = new System.Drawing.Size(120, 16);
	this.label36.TabIndex = 70;
	this.label36.Text = "Current Part Seq.   20";
	// 
	// mainMaterial4TextBox
	// 
	this.mainMaterial4TextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.mainMaterial4TextBox.Enabled = false;
	this.mainMaterial4TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.mainMaterial4TextBox.Location = new System.Drawing.Point(128, 112);
	this.mainMaterial4TextBox.MaxLength = 30;
	this.mainMaterial4TextBox.Name = "mainMaterial4TextBox";
	this.mainMaterial4TextBox.Size = new System.Drawing.Size(128, 20);
	this.mainMaterial4TextBox.TabIndex = 81;
	this.mainMaterial4TextBox.Text = "";
	// 
	// label44
	// 
	this.label44.Location = new System.Drawing.Point(8, 112);
	this.label44.Name = "label44";
	this.label44.Size = new System.Drawing.Size(72, 16);
	this.label44.TabIndex = 80;
	this.label44.Text = "Main Material";
	// 
	// seqPart4ComboBox
	// 
	this.seqPart4ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.seqPart4ComboBox.Enabled = false;
	this.seqPart4ComboBox.Location = new System.Drawing.Point(48, 40);
	this.seqPart4ComboBox.Name = "seqPart4ComboBox";
	this.seqPart4ComboBox.Size = new System.Drawing.Size(64, 21);
	this.seqPart4ComboBox.TabIndex = 63;
	this.seqPart4ComboBox.SelectedIndexChanged += new System.EventHandler(this.seqPart4ComboBox_SelectedIndexChanged);
	// 
	// label24
	// 
	this.label24.Location = new System.Drawing.Point(8, 40);
	this.label24.Name = "label24";
	this.label24.Size = new System.Drawing.Size(32, 16);
	this.label24.TabIndex = 62;
	this.label24.Text = "Seq.";
	// 
	// part4DescTextBox
	// 
	this.part4DescTextBox.AutoSize = false;
	this.part4DescTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.part4DescTextBox.Enabled = false;
	this.part4DescTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.part4DescTextBox.Location = new System.Drawing.Point(176, 16);
	this.part4DescTextBox.MaxLength = 60;
	this.part4DescTextBox.Multiline = true;
	this.part4DescTextBox.Name = "part4DescTextBox";
	this.part4DescTextBox.Size = new System.Drawing.Size(224, 20);
	this.part4DescTextBox.TabIndex = 61;
	this.part4DescTextBox.Text = "";
	// 
	// part4SearchButton
	// 
	this.part4SearchButton.Location = new System.Drawing.Point(408, 16);
	this.part4SearchButton.Name = "part4SearchButton";
	this.part4SearchButton.Size = new System.Drawing.Size(32, 16);
	this.part4SearchButton.TabIndex = 58;
	this.part4SearchButton.Text = "...";
	this.part4SearchButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
	this.part4SearchButton.Click += new System.EventHandler(this.part4SearchButton_Click);
	// 
	// part4TextBox
	// 
	this.part4TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.part4TextBox.Location = new System.Drawing.Point(48, 16);
	this.part4TextBox.MaxLength = 30;
	this.part4TextBox.Name = "part4TextBox";
	this.part4TextBox.Size = new System.Drawing.Size(128, 20);
	this.part4TextBox.TabIndex = 60;
	this.part4TextBox.Text = "";
	// 
	// label5
	// 
	this.label5.Location = new System.Drawing.Point(8, 16);
	this.label5.Name = "label5";
	this.label5.Size = new System.Drawing.Size(48, 20);
	this.label5.TabIndex = 59;
	this.label5.Text = "Part #4";
	this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// otherTabPage
	// 
	this.otherTabPage.Controls.Add(this.mainMaterialGroupBox);
	this.otherTabPage.Location = new System.Drawing.Point(4, 22);
	this.otherTabPage.Name = "otherTabPage";
	this.otherTabPage.Size = new System.Drawing.Size(696, 270);
	this.otherTabPage.TabIndex = 0;
	this.otherTabPage.Text = "Machine";
	// 
	// mainMaterialGroupBox
	// 
	this.mainMaterialGroupBox.Controls.Add(this.allPartsComboBox);
	this.mainMaterialGroupBox.Controls.Add(this.seqsSelPartComboBox);
	this.mainMaterialGroupBox.Controls.Add(this.label62);
	this.mainMaterialGroupBox.Controls.Add(this.label63);
	this.mainMaterialGroupBox.Controls.Add(this.runStdSelPartTextBox);
	this.mainMaterialGroupBox.Controls.Add(this.label15);
	this.mainMaterialGroupBox.Controls.Add(this.uomSelPartTextBox);
	this.mainMaterialGroupBox.Controls.Add(this.label60);
	this.mainMaterialGroupBox.Controls.Add(this.runQtySelPartTextBox);
	this.mainMaterialGroupBox.Controls.Add(this.label61);
	this.mainMaterialGroupBox.Controls.Add(this.machineDescTextBox);
	this.mainMaterialGroupBox.Controls.Add(this.machineSearchButton);
	this.mainMaterialGroupBox.Controls.Add(this.machineTextBox);
	this.mainMaterialGroupBox.Controls.Add(this.label2);
	this.mainMaterialGroupBox.Controls.Add(this.label11);
	this.mainMaterialGroupBox.Controls.Add(this.machineHrsTextBox);
	this.mainMaterialGroupBox.Location = new System.Drawing.Point(8, 8);
	this.mainMaterialGroupBox.Name = "mainMaterialGroupBox";
	this.mainMaterialGroupBox.Size = new System.Drawing.Size(680, 248);
	this.mainMaterialGroupBox.TabIndex = 64;
	this.mainMaterialGroupBox.TabStop = false;
	// 
	// allPartsComboBox
	// 
	this.allPartsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.allPartsComboBox.Location = new System.Drawing.Point(88, 16);
	this.allPartsComboBox.Name = "allPartsComboBox";
	this.allPartsComboBox.Size = new System.Drawing.Size(144, 21);
	this.allPartsComboBox.TabIndex = 0;
	this.allPartsComboBox.SelectedIndexChanged += new System.EventHandler(this.allPartsComboBox_SelectedIndexChanged);
	// 
	// seqsSelPartComboBox
	// 
	this.seqsSelPartComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.seqsSelPartComboBox.Enabled = false;
	this.seqsSelPartComboBox.Location = new System.Drawing.Point(88, 40);
	this.seqsSelPartComboBox.Name = "seqsSelPartComboBox";
	this.seqsSelPartComboBox.Size = new System.Drawing.Size(64, 21);
	this.seqsSelPartComboBox.TabIndex = 1;
	this.seqsSelPartComboBox.SelectedIndexChanged += new System.EventHandler(this.seqsSelPartComboBox_SelectedIndexChanged);
	// 
	// label62
	// 
	this.label62.Location = new System.Drawing.Point(8, 40);
	this.label62.Name = "label62";
	this.label62.Size = new System.Drawing.Size(32, 16);
	this.label62.TabIndex = 90;
	this.label62.Text = "Seq.";
	// 
	// label63
	// 
	this.label63.Location = new System.Drawing.Point(8, 16);
	this.label63.Name = "label63";
	this.label63.Size = new System.Drawing.Size(48, 20);
	this.label63.TabIndex = 88;
	this.label63.Text = "Part #";
	this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// runStdSelPartTextBox
	// 
	this.runStdSelPartTextBox.BackColor = System.Drawing.Color.Gainsboro;
	this.runStdSelPartTextBox.Enabled = false;
	this.runStdSelPartTextBox.Location = new System.Drawing.Point(88, 168);
	this.runStdSelPartTextBox.Maximum = new System.Decimal(new int[] {
																		 999999999,
																		 0,
																		 0,
																		 131072});
	this.runStdSelPartTextBox.MaxPrecision = 1;
	this.runStdSelPartTextBox.Minimum = new System.Decimal(new int[] {
																		 0,
																		 0,
																		 0,
																		 0});
	this.runStdSelPartTextBox.Name = "runStdSelPartTextBox";
	this.runStdSelPartTextBox.ReadOnly = true;
	this.runStdSelPartTextBox.Size = new System.Drawing.Size(128, 20);
	this.runStdSelPartTextBox.TabIndex = 7;
	this.runStdSelPartTextBox.Value = new System.Decimal(new int[] {
																	   0,
																	   0,
																	   0,
																	   0});
	// 
	// label15
	// 
	this.label15.Location = new System.Drawing.Point(8, 168);
	this.label15.Name = "label15";
	this.label15.Size = new System.Drawing.Size(80, 20);
	this.label15.TabIndex = 85;
	this.label15.Text = "Run Standard";
	this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// uomSelPartTextBox
	// 
	this.uomSelPartTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.uomSelPartTextBox.Location = new System.Drawing.Point(88, 192);
	this.uomSelPartTextBox.MaxLength = 10;
	this.uomSelPartTextBox.Name = "uomSelPartTextBox";
	this.uomSelPartTextBox.Size = new System.Drawing.Size(48, 20);
	this.uomSelPartTextBox.TabIndex = 8;
	this.uomSelPartTextBox.Text = "";
	// 
	// label60
	// 
	this.label60.Location = new System.Drawing.Point(8, 192);
	this.label60.Name = "label60";
	this.label60.Size = new System.Drawing.Size(32, 20);
	this.label60.TabIndex = 84;
	this.label60.Text = "UOM";
	this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// runQtySelPartTextBox
	// 
	this.runQtySelPartTextBox.Location = new System.Drawing.Point(88, 144);
	this.runQtySelPartTextBox.Maximum = new System.Decimal(new int[] {
																		 1215752191,
																		 23,
																		 0,
																		 131072});
	this.runQtySelPartTextBox.MaxPrecision = 1;
	this.runQtySelPartTextBox.Minimum = new System.Decimal(new int[] {
																		 0,
																		 0,
																		 0,
																		 0});
	this.runQtySelPartTextBox.Name = "runQtySelPartTextBox";
	this.runQtySelPartTextBox.Size = new System.Drawing.Size(128, 20);
	this.runQtySelPartTextBox.TabIndex = 6;
	this.runQtySelPartTextBox.Value = new System.Decimal(new int[] {
																	   0,
																	   0,
																	   0,
																	   0});
	this.runQtySelPartTextBox.ValueChanged += new System.EventHandler(this.runQtySelPartTextBox_ValueChanged);
	// 
	// label61
	// 
	this.label61.Location = new System.Drawing.Point(8, 144);
	this.label61.Name = "label61";
	this.label61.Size = new System.Drawing.Size(56, 20);
	this.label61.TabIndex = 83;
	this.label61.Text = "Run Qty";
	this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// machineDescTextBox
	// 
	this.machineDescTextBox.AutoSize = false;
	this.machineDescTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.machineDescTextBox.Enabled = false;
	this.machineDescTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.machineDescTextBox.Location = new System.Drawing.Point(216, 80);
	this.machineDescTextBox.MaxLength = 60;
	this.machineDescTextBox.Multiline = true;
	this.machineDescTextBox.Name = "machineDescTextBox";
	this.machineDescTextBox.ReadOnly = true;
	this.machineDescTextBox.Size = new System.Drawing.Size(192, 20);
	this.machineDescTextBox.TabIndex = 3;
	this.machineDescTextBox.Text = "";
	// 
	// machineSearchButton
	// 
	this.machineSearchButton.Location = new System.Drawing.Point(416, 80);
	this.machineSearchButton.Name = "machineSearchButton";
	this.machineSearchButton.Size = new System.Drawing.Size(32, 16);
	this.machineSearchButton.TabIndex = 4;
	this.machineSearchButton.Text = "...";
	this.machineSearchButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
	this.machineSearchButton.Click += new System.EventHandler(this.machineSearchButton_Click);
	// 
	// machineTextBox
	// 
	this.machineTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.machineTextBox.Location = new System.Drawing.Point(88, 80);
	this.machineTextBox.MaxLength = 30;
	this.machineTextBox.Name = "machineTextBox";
	this.machineTextBox.Size = new System.Drawing.Size(128, 20);
	this.machineTextBox.TabIndex = 2;
	this.machineTextBox.Text = "";
	// 
	// label2
	// 
	this.label2.Location = new System.Drawing.Point(8, 80);
	this.label2.Name = "label2";
	this.label2.Size = new System.Drawing.Size(56, 20);
	this.label2.TabIndex = 70;
	this.label2.Text = "Machine";
	this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label11
	// 
	this.label11.Location = new System.Drawing.Point(8, 104);
	this.label11.Name = "label11";
	this.label11.Size = new System.Drawing.Size(68, 20);
	this.label11.TabIndex = 72;
	this.label11.Text = "Machine Hrs";
	this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// machineHrsTextBox
	// 
	this.machineHrsTextBox.Enabled = false;
	this.machineHrsTextBox.Location = new System.Drawing.Point(88, 104);
	this.machineHrsTextBox.Maximum = new System.Decimal(new int[] {
																	  999999999,
																	  0,
																	  0,
																	  131072});
	this.machineHrsTextBox.MaxPrecision = 1;
	this.machineHrsTextBox.Minimum = new System.Decimal(new int[] {
																	  0,
																	  0,
																	  0,
																	  0});
	this.machineHrsTextBox.Name = "machineHrsTextBox";
	this.machineHrsTextBox.Size = new System.Drawing.Size(128, 20);
	this.machineHrsTextBox.TabIndex = 5;
	this.machineHrsTextBox.Value = new System.Decimal(new int[] {
																	0,
																	0,
																	0,
																	0});
	// 
	// toolingTabPage
	// 
	this.toolingTabPage.Controls.Add(this.groupBox3);
	this.toolingTabPage.Location = new System.Drawing.Point(4, 22);
	this.toolingTabPage.Name = "toolingTabPage";
	this.toolingTabPage.Size = new System.Drawing.Size(696, 270);
	this.toolingTabPage.TabIndex = 3;
	this.toolingTabPage.Text = "Tooling";
	// 
	// groupBox3
	// 
	this.groupBox3.Controls.Add(this.toolDescTextBox);
	this.groupBox3.Controls.Add(this.label12);
	this.groupBox3.Controls.Add(this.qtyPerToolTextBox);
	this.groupBox3.Controls.Add(this.label18);
	this.groupBox3.Controls.Add(this.mainToolComboBox);
	this.groupBox3.Controls.Add(this.label17);
	this.groupBox3.Location = new System.Drawing.Point(8, 8);
	this.groupBox3.Name = "groupBox3";
	this.groupBox3.Size = new System.Drawing.Size(680, 256);
	this.groupBox3.TabIndex = 0;
	this.groupBox3.TabStop = false;
	// 
	// toolDescTextBox
	// 
	this.toolDescTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.toolDescTextBox.Enabled = false;
	this.toolDescTextBox.Location = new System.Drawing.Point(112, 48);
	this.toolDescTextBox.MaxLength = 40;
	this.toolDescTextBox.Name = "toolDescTextBox";
	this.toolDescTextBox.Size = new System.Drawing.Size(248, 20);
	this.toolDescTextBox.TabIndex = 63;
	this.toolDescTextBox.Text = "";
	// 
	// label12
	// 
	this.label12.Location = new System.Drawing.Point(16, 48);
	this.label12.Name = "label12";
	this.label12.Size = new System.Drawing.Size(88, 20);
	this.label12.TabIndex = 62;
	this.label12.Text = "Tool Description";
	this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// qtyPerToolTextBox
	// 
	this.qtyPerToolTextBox.Location = new System.Drawing.Point(112, 72);
	this.qtyPerToolTextBox.Maximum = new System.Decimal(new int[] {
																	  99999,
																	  0,
																	  0,
																	  0});
	this.qtyPerToolTextBox.Minimum = new System.Decimal(new int[] {
																	  0,
																	  0,
																	  0,
																	  0});
	this.qtyPerToolTextBox.Name = "qtyPerToolTextBox";
	this.qtyPerToolTextBox.Size = new System.Drawing.Size(56, 20);
	this.qtyPerToolTextBox.TabIndex = 59;
	this.qtyPerToolTextBox.Value = new System.Decimal(new int[] {
																	0,
																	0,
																	0,
																	0});
	// 
	// label18
	// 
	this.label18.Location = new System.Drawing.Point(16, 72);
	this.label18.Name = "label18";
	this.label18.Size = new System.Drawing.Size(72, 20);
	this.label18.TabIndex = 61;
	this.label18.Text = "Qty Per Tool";
	this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// mainToolComboBox
	// 
	this.mainToolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.mainToolComboBox.Location = new System.Drawing.Point(112, 24);
	this.mainToolComboBox.Name = "mainToolComboBox";
	this.mainToolComboBox.Size = new System.Drawing.Size(184, 21);
	this.mainToolComboBox.TabIndex = 58;
	this.mainToolComboBox.SelectedIndexChanged += new System.EventHandler(this.mainToolComboBox_SelectedIndexChanged);
	// 
	// label17
	// 
	this.label17.Location = new System.Drawing.Point(16, 24);
	this.label17.Name = "label17";
	this.label17.Size = new System.Drawing.Size(56, 20);
	this.label17.TabIndex = 60;
	this.label17.Text = "Main Tool";
	this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// statusGroupBox
	// 
	this.statusGroupBox.Controls.Add(this.inactiveRadioButton);
	this.statusGroupBox.Controls.Add(this.activeRadioButton);
	this.statusGroupBox.Location = new System.Drawing.Point(640, 66);
	this.statusGroupBox.Name = "statusGroupBox";
	this.statusGroupBox.Size = new System.Drawing.Size(152, 48);
	this.statusGroupBox.TabIndex = 16;
	this.statusGroupBox.TabStop = false;
	this.statusGroupBox.Text = "Status";
	// 
	// inactiveRadioButton
	// 
	this.inactiveRadioButton.Location = new System.Drawing.Point(80, 24);
	this.inactiveRadioButton.Name = "inactiveRadioButton";
	this.inactiveRadioButton.Size = new System.Drawing.Size(64, 16);
	this.inactiveRadioButton.TabIndex = 1;
	this.inactiveRadioButton.Text = "Inactive";
	// 
	// activeRadioButton
	// 
	this.activeRadioButton.Checked = true;
	this.activeRadioButton.Location = new System.Drawing.Point(8, 24);
	this.activeRadioButton.Name = "activeRadioButton";
	this.activeRadioButton.Size = new System.Drawing.Size(56, 16);
	this.activeRadioButton.TabIndex = 0;
	this.activeRadioButton.TabStop = true;
	this.activeRadioButton.Text = "Active";
	// 
	// jobCardIdTextBox
	// 
	this.jobCardIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.jobCardIdTextBox.Location = new System.Drawing.Point(640, 16);
	this.jobCardIdTextBox.MaxLength = 30;
	this.jobCardIdTextBox.Name = "jobCardIdTextBox";
	this.jobCardIdTextBox.Size = new System.Drawing.Size(128, 20);
	this.jobCardIdTextBox.TabIndex = 14;
	this.jobCardIdTextBox.Text = "";
	this.jobCardIdTextBox.TextChanged += new System.EventHandler(this.jobCardIdTextBox_TextChanged);
	// 
	// label1
	// 
	this.label1.Location = new System.Drawing.Point(584, 16);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(56, 20);
	this.label1.TabIndex = 32;
	this.label1.Text = "Job Card";
	this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// deptNameTextBox
	// 
	this.deptNameTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.deptNameTextBox.Enabled = false;
	this.deptNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.deptNameTextBox.Location = new System.Drawing.Point(168, 64);
	this.deptNameTextBox.MaxLength = 10;
	this.deptNameTextBox.Name = "deptNameTextBox";
	this.deptNameTextBox.ReadOnly = true;
	this.deptNameTextBox.Size = new System.Drawing.Size(216, 20);
	this.deptNameTextBox.TabIndex = 7;
	this.deptNameTextBox.Text = "";
	// 
	// deptSearchButton
	// 
	this.deptSearchButton.Location = new System.Drawing.Point(392, 65);
	this.deptSearchButton.Name = "deptSearchButton";
	this.deptSearchButton.Size = new System.Drawing.Size(32, 16);
	this.deptSearchButton.TabIndex = 8;
	this.deptSearchButton.Text = "...";
	this.deptSearchButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
	this.deptSearchButton.Click += new System.EventHandler(this.deptSearchButton_Click);
	// 
	// lblDept
	// 
	this.lblDept.Location = new System.Drawing.Point(8, 64);
	this.lblDept.Name = "lblDept";
	this.lblDept.Size = new System.Drawing.Size(64, 20);
	this.lblDept.TabIndex = 28;
	this.lblDept.Text = "Department";
	this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// deptCodeTextBox
	// 
	this.deptCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.deptCodeTextBox.Location = new System.Drawing.Point(88, 64);
	this.deptCodeTextBox.MaxLength = 10;
	this.deptCodeTextBox.Name = "deptCodeTextBox";
	this.deptCodeTextBox.Size = new System.Drawing.Size(76, 20);
	this.deptCodeTextBox.TabIndex = 6;
	this.deptCodeTextBox.Text = "";
	// 
	// familyTextBox
	// 
	this.familyTextBox.Enabled = false;
	this.familyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.familyTextBox.Location = new System.Drawing.Point(88, 96);
	this.familyTextBox.MaxLength = 30;
	this.familyTextBox.Name = "familyTextBox";
	this.familyTextBox.Size = new System.Drawing.Size(128, 20);
	this.familyTextBox.TabIndex = 11;
	this.familyTextBox.Text = "";
	// 
	// familySearchButton
	// 
	this.familySearchButton.Enabled = false;
	this.familySearchButton.Location = new System.Drawing.Point(448, 96);
	this.familySearchButton.Name = "familySearchButton";
	this.familySearchButton.Size = new System.Drawing.Size(32, 16);
	this.familySearchButton.TabIndex = 13;
	this.familySearchButton.Text = "...";
	this.familySearchButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
	this.familySearchButton.Click += new System.EventHandler(this.familySearchButton_Click);
	// 
	// familyDescTextBox
	// 
	this.familyDescTextBox.AutoSize = false;
	this.familyDescTextBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(232)), ((System.Byte)(232)), ((System.Byte)(232)));
	this.familyDescTextBox.Enabled = false;
	this.familyDescTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.familyDescTextBox.Location = new System.Drawing.Point(216, 96);
	this.familyDescTextBox.MaxLength = 60;
	this.familyDescTextBox.Multiline = true;
	this.familyDescTextBox.Name = "familyDescTextBox";
	this.familyDescTextBox.ReadOnly = true;
	this.familyDescTextBox.Size = new System.Drawing.Size(224, 20);
	this.familyDescTextBox.TabIndex = 12;
	this.familyDescTextBox.Text = "";
	// 
	// label7
	// 
	this.label7.Location = new System.Drawing.Point(24, 96);
	this.label7.Name = "label7";
	this.label7.Size = new System.Drawing.Size(64, 20);
	this.label7.TabIndex = 10;
	this.label7.Text = "Family Part";
	this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// selFamilyPartCheckBox
	// 
	this.selFamilyPartCheckBox.Location = new System.Drawing.Point(8, 98);
	this.selFamilyPartCheckBox.Name = "selFamilyPartCheckBox";
	this.selFamilyPartCheckBox.Size = new System.Drawing.Size(16, 16);
	this.selFamilyPartCheckBox.TabIndex = 9;
	this.selFamilyPartCheckBox.CheckedChanged += new System.EventHandler(this.selFamilyPartCheckBox_CheckedChanged);
	// 
	// errorProvider
	// 
	this.errorProvider.ContainerControl = this;
	// 
	// groupBox2
	// 
	this.groupBox2.Controls.Add(this.cancelButton);
	this.groupBox2.Controls.Add(this.okButton);
	this.groupBox2.Location = new System.Drawing.Point(8, 472);
	this.groupBox2.Name = "groupBox2";
	this.groupBox2.Size = new System.Drawing.Size(800, 48);
	this.groupBox2.TabIndex = 1;
	this.groupBox2.TabStop = false;
	// 
	// cancelButton
	// 
	this.cancelButton.Location = new System.Drawing.Point(96, 16);
	this.cancelButton.Name = "cancelButton";
	this.cancelButton.Size = new System.Drawing.Size(75, 24);
	this.cancelButton.TabIndex = 1;
	this.cancelButton.Text = "Cancel";
	this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
	// 
	// okButton
	// 
	this.okButton.Location = new System.Drawing.Point(8, 16);
	this.okButton.Name = "okButton";
	this.okButton.Size = new System.Drawing.Size(75, 24);
	this.okButton.TabIndex = 0;
	this.okButton.Text = "Ok";
	this.okButton.Click += new System.EventHandler(this.okButton_Click);
	// 
	// SchdLogEditForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(816, 526);
	this.Controls.Add(this.groupBox2);
	this.Controls.Add(this.groupBox1);
	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	this.Name = "SchdLogEditForm";
	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	this.Text = "Job Card";
	this.Load += new System.EventHandler(this.SchdLogEditForm_Load);
	this.groupBox1.ResumeLayout(false);
	this.tabControl.ResumeLayout(false);
	this.part1TabPage.ResumeLayout(false);
	this.part1GroupBox.ResumeLayout(false);
	this.groupBox8.ResumeLayout(false);
	this.part2TabPage.ResumeLayout(false);
	this.part2GroupBox.ResumeLayout(false);
	this.groupBox9.ResumeLayout(false);
	this.part3TabPage.ResumeLayout(false);
	this.part3GroupBox.ResumeLayout(false);
	this.groupBox10.ResumeLayout(false);
	this.part4TabPage.ResumeLayout(false);
	this.part4GroupBox.ResumeLayout(false);
	this.groupBox4.ResumeLayout(false);
	this.otherTabPage.ResumeLayout(false);
	this.mainMaterialGroupBox.ResumeLayout(false);
	this.toolingTabPage.ResumeLayout(false);
	this.groupBox3.ResumeLayout(false);
	this.statusGroupBox.ResumeLayout(false);
	this.groupBox2.ResumeLayout(false);
	this.ResumeLayout(false);

}
#endregion

private 
void companySearchButton_Click(object sender, System.EventArgs e){
	CompanySearchForm companySearchForm = new CompanySearchForm("Company Search");
	companySearchForm.setBaseFilter (getDftDataBase());
	companySearchForm.ShowDialog();

	if (companySearchForm.DialogResult == DialogResult.OK){
		string oldCode = companyCodeTextBox.Text;
		string[] v = companySearchForm.getSelected();
		if (v != null){			
			this.companyCodeTextBox.Text = v[1];
			this.companyNameTextBox.Text = v[2];
		}
		if (!oldCode.Equals(this.companyCodeTextBox.Text)){
			Plant plant = coreFactory.readPlant(Configuration.DftPlant);
			plantCodeTextBox.Text = plant.getPlt();
			plantNameTextBox.Text = plant.getName();
			
			Departament department = coreFactory.readDepartament(plant.getPlt(), Configuration.DftDepartment);	
			deptCodeTextBox.Text = department.getDept();
			deptNameTextBox.Text = department.getDes1();
		}
		if (!this.plantSearchButton.Enabled)
			plantSearchButton.Enabled = true;
	}
	errorProvider.SetError(companySearchButton, "");
}

private 
void plantSearchButton_Click(object sender, System.EventArgs e){
	PlantSearchForm plantSearchForm = new PlantSearchForm("Plant Search");
	plantSearchForm.ShowDialog();

	if (plantSearchForm.DialogResult == DialogResult.OK){
		string oldCode = plantCodeTextBox.Text;
		string[] v = plantSearchForm.getSelected();
		if (v != null){			
			this.plantCodeTextBox.Text = v[0];
			this.plantNameTextBox.Text = v[1];
		}
		if (!oldCode.Equals(this.plantCodeTextBox.Text)){
			Departament department = coreFactory.readDepartament(this.plantCodeTextBox.Text, Configuration.DftDepartment);	
			deptCodeTextBox.Text = department.getDept();
			deptNameTextBox.Text = department.getDes1();
		}
		if (!this.deptSearchButton.Enabled){
			deptSearchButton.Enabled = true;
			deptCodeTextBox.Enabled = true;
		}
	}
	errorProvider.SetError(plantSearchButton, "");
}

private 
void deptSearchButton_Click(object sender, System.EventArgs e){
	DepartmentSearchForm departmentSearchForm = new DepartmentSearchForm("Department Search", deptCodeTextBox.Text);
	departmentSearchForm.setPlantFilter (this.plantCodeTextBox.Text);
	departmentSearchForm.ShowDialog();
	
	if (departmentSearchForm.DialogResult == DialogResult.OK){
		string[] v = departmentSearchForm.getSelected();
		if (v != null){			
			this.deptCodeTextBox.Text = v[3];
			this.deptNameTextBox.Text = v[4];
		}
	}
}

private 
void familySearchButton_Click(object sender, System.EventArgs e){
	FamilyPartSearchForm familyPartSearchForm = new FamilyPartSearchForm("Family Part Search", familyTextBox.Text);
	familyPartSearchForm.ShowDialog();
	
	if (familyPartSearchForm.DialogResult == DialogResult.OK){		
		string[] v = familyPartSearchForm.getSelected();
		familyTextBox.Text = v[0];
		
		// Get Parts
		allPartsComboBox.Items.Clear();
		seqsSelPartComboBox.Items.Clear();
		string[][] parts = coreFactory.getProductsByFamilyId(v[0]);
		for(int i = 0; i < parts.Length; i ++){
			switch(i){
				case 0:
					part1TextBox.Text = parts[i][0];
					part1DescTextBox.Text = parts[i][1];
					familyDescTextBox.Text = parts[i][1];
					getValidSeqsForPart(part1TextBox.Text, 1);
					seqPart1ComboBox.Enabled = true;
					
					if (!part1TextBox.Text.Equals(string.Empty)){
						allPartsComboBox.Items.Add("Part#1 - " + part1TextBox.Text);
						allPartsComboBox.SelectedIndex = 0;
					}
					seqsSelPartComboBox.Enabled = true;
					
					if(!parts[i][0].Equals(string.Empty))
						getPart1Data(parts[i][0], parts[i][2]);
					break;
				case 1:
					part2TextBox.Text = parts[i][0];
					part2DescTextBox.Text = parts[i][1];
					getValidSeqsForPart(part2TextBox.Text, 2);
					seqPart2ComboBox.Enabled = true;
					
					if (!part2TextBox.Text.Equals(string.Empty))
						allPartsComboBox.Items.Add("Part#2 - " + part2TextBox.Text);
					
					if(!parts[i][0].Equals(string.Empty))
						getPart2Data(parts[i][0], parts[i][2]);
					break;
				case 2:
					part3TextBox.Text = parts[i][0];
					part3DescTextBox.Text = parts[i][1];
					getValidSeqsForPart(part3TextBox.Text, 3);
					seqPart3ComboBox.Enabled = true;
					
					if (!part3TextBox.Text.Equals(string.Empty))
						allPartsComboBox.Items.Add("Part#3 - " + part3TextBox.Text);
					
					if(!parts[i][0].Equals(string.Empty))
						getPart3Data(parts[i][0], parts[i][2]);
					break;
				case 3:
					part4TextBox.Text = parts[i][0];
					part4DescTextBox.Text = parts[i][1];
					//seqPart4ComboBox.Text = parts[i][2];
					getValidSeqsForPart(part4TextBox.Text, 4);
					seqPart4ComboBox.Enabled = true;
					
					if (!part4TextBox.Text.Equals(string.Empty))
						allPartsComboBox.Items.Add("Part#4 - " + part4TextBox.Text);
					
					if(!parts[i][0].Equals(string.Empty))
						getPart4Data(parts[i][0], parts[i][2]);
					break;
			}
		}
		for(int j = 3; (j > -1) && parts[j][0].Equals(string.Empty); j --){
			switch(j){
				case 3:
					tabControl.TabPages.Remove(part4TabPage);
					break;
				case 2:
					tabControl.TabPages.Remove(part3TabPage);
					break;
				case 1:
					tabControl.TabPages.Remove(part2TabPage);
					break;
				case 0:
					tabControl.TabPages.Remove(part1TabPage);
					break;
			}
		}
		tabControl.SelectedIndex = 0;
		getTools();
	}
	familyPartSearchForm.Dispose();
}

private 
void part1SearchButton_Click(object sender, System.EventArgs e){
	ProductSearchForm productSearchForm = new ProductSearchForm("Part search", part1TextBox.Text, true, false);
	productSearchForm.ShowDialog();
	if (productSearchForm.DialogResult == DialogResult.OK){		
		string[] v = productSearchForm.getSelected();
		part1TextBox.Text = v[0];
		part1DescTextBox.Text = v[1];
				
		addToAllParts(part1TextBox.Text, 1);
				
		getValidSeqsForPart(v[0], 1);
		if (seqPart1ComboBox.SelectedIndex == 0)
			getPart1Data(v[0], seqPart1ComboBox.SelectedItem.ToString());
		getTools();
		
		seqPart1ComboBox.Enabled = true;
	}
	productSearchForm.Dispose();
}

private 
void part2SearchButton_Click(object sender, System.EventArgs e){
	ProductSearchForm productSearchForm = new ProductSearchForm("Part search", part2TextBox.Text, true, false);
	productSearchForm.ShowDialog();
	if (productSearchForm.DialogResult == DialogResult.OK){		
		string[] v = productSearchForm.getSelected();
		part2TextBox.Text = v[0];
		part2DescTextBox.Text = v[1];
				
		//addToAllParts(part2TextBox.Text, 2);
				
		getValidSeqsForPart(v[0], 2);
		if (seqPart2ComboBox.SelectedIndex == 0)
			getPart2Data(v[0], seqPart2ComboBox.SelectedItem.ToString());
		getTools();
		
		seqPart2ComboBox.Enabled = true;
	}
	productSearchForm.Dispose();
}

private 
void part3SearchButton_Click(object sender, System.EventArgs e){
	ProductSearchForm productSearchForm = new ProductSearchForm("Part search", part3TextBox.Text, true, false);
	productSearchForm.ShowDialog();
	if (productSearchForm.DialogResult == DialogResult.OK){		
		string[] v = productSearchForm.getSelected();
		part3TextBox.Text = v[0];
		part3DescTextBox.Text = v[1];
		
		//addToAllParts(part3TextBox.Text, 3);
						
		getValidSeqsForPart(v[0], 3);
		if (seqPart3ComboBox.SelectedIndex == 0)
			getPart3Data(v[0], seqPart3ComboBox.SelectedItem.ToString());
		getTools();
		
		seqPart3ComboBox.Enabled = true;
	}
	productSearchForm.Dispose();
}

private 
void part4SearchButton_Click(object sender, System.EventArgs e){
	ProductSearchForm productSearchForm = new ProductSearchForm("Part search", part4TextBox.Text, true, false);
	productSearchForm.ShowDialog();
	if (productSearchForm.DialogResult == DialogResult.OK){		
		string[] v = productSearchForm.getSelected();
		part4TextBox.Text = v[0];
		part4DescTextBox.Text = v[1];
		
		//addToAllParts(part4TextBox.Text, 4);
						
		getValidSeqsForPart(v[0], 4);
		if (seqPart4ComboBox.SelectedIndex == 0)
			getPart4Data(v[0], seqPart4ComboBox.SelectedItem.ToString());
		getTools();
		
		seqPart4ComboBox.Enabled = true;
	}
	productSearchForm.Dispose();
}

private 
void selFamilyPartCheckBox_CheckedChanged(object sender, System.EventArgs e){
	if (selFamilyPartCheckBox.Checked){
		part1SearchButton.Enabled = false;
		part2SearchButton.Enabled = false;
		part3SearchButton.Enabled = false;
		part4SearchButton.Enabled = false;
		familySearchButton.Enabled = true;
		familyTextBox.Enabled = true;
	}
	else{	
		part1SearchButton.Enabled = true;
		part2SearchButton.Enabled = true;
		part3SearchButton.Enabled = true;
		part4SearchButton.Enabled = true;
		familySearchButton.Enabled = false;
		familyTextBox.Enabled = false;
		
		if (tabControl.TabPages.Count < 6){
			tabControl.TabPages.Clear();
			tabControl.TabPages.Add(part1TabPage);
			tabControl.TabPages.Add(part2TabPage);
			tabControl.TabPages.Add(part3TabPage);
			tabControl.TabPages.Add(part4TabPage);
			tabControl.TabPages.Add(otherTabPage);
			tabControl.TabPages.Add(toolingTabPage);
		}
	}
	clearParts();
	clearFamily();
	allPartsComboBox.Items.Clear();
	seqsSelPartComboBox.Items.Clear();
}

private
void screenToObject(){
	schLog = coreFactory.createSchLog();
	schLog.setDb(this.getDftDataBase());
	schLog.setCompany(companyCodeTextBox.Text);
	schLog.setPlant(plantCodeTextBox.Text);
	schLog.setDepartment(deptCodeTextBox.Text);
	schLog.setMachine(machineTextBox.Text);
	schLog.setJobcardID(jobCardIdTextBox.Text);
	
	schLog.setFamily(familyTextBox.Text);
	schLog.setFamilyDescription(familyDescTextBox.Text);

	schLog.setPart(part1TextBox.Text);
	schLog.setDescription(part1DescTextBox.Text);
	
	schLog.setPart2(part2TextBox.Text);
	schLog.setDescription2(part2DescTextBox.Text);
	
	schLog.setPart3(part3TextBox.Text);
	schLog.setDescription3(part3DescTextBox.Text);
	
	schLog.setPart4(part4TextBox.Text);
	schLog.setDescription4(part4DescTextBox.Text);
	
	schLog.setRunQty(runQtyTextBox.Value);
	schLog.setRunStandard(runStandardTextBox.Value);
	schLog.setUOM(uomTextBox.Text);
	schLog.setMachineHrs(machineHrsTextBox.Value);
	
	//schLog.setMainTool(mainToolTextBox.Text);
	string toolSelected = (string)mainToolComboBox.SelectedItem;
	if(toolSelected != null)
		toolSelected = toolSelected.Split(' ')[0];
	else
		toolSelected = "";
	schLog.setMainTool(toolSelected);
	
	schLog.setQtyPerTool(qtyPerToolTextBox.Value);
	schLog.setMainMaterial(mainMaterialTextBox.Text);
	schLog.setQtyPer(qtyPerTextBox.Value);
	schLog.setMaterialReq(qtyReqTextBox.Value);
	if (activeRadioButton.Checked)
		schLog.setStatus(Constants.STATUS_ACTIVE);
	else
		schLog.setStatus(Constants.STATUS_INACTIVE);
	schLog.setDateReq(dateTimePicker.Value);
	schLog.setOperation(operationTextBox.Text);
	schLog.setNextOperation(nextOperationTextBox.Text);
}

private
void objectToScreen(){
	Company company = coreFactory.readCompany(schLog.getDb(), int.Parse(schLog.getCompany()));
	companyCodeTextBox.Text = company.getCompany().ToString();
	companyNameTextBox.Text = company.getName();
	
	Plant plant = coreFactory.readPlant(schLog.getPlant());
	plantCodeTextBox.Text = plant.getPlt();
	plantNameTextBox.Text = plant.getName();
	
	Departament dept = coreFactory.readDepartament(schLog.getPlant(), schLog.getDepartment());
	deptCodeTextBox.Text = dept.getDept();
	deptNameTextBox.Text = dept.getDes1();
	
	machineTextBox.Text = schLog.getMachine();
	jobCardIdTextBox.Text = schLog.getJobcardID();

	if (!schLog.getFamily().Equals("")){
		selFamilyPartCheckBox.Checked = true;
	}
	else{
		selFamilyPartCheckBox.Checked = false;
	}
	
	familyTextBox.Text = schLog.getFamily();
	familyDescTextBox.Text = schLog.getFamilyDescription();
	
	if(schLog.getPart().Equals(string.Empty))
		tabControl.TabPages.Remove(part1TabPage);
	else{
		part1TextBox.Text = schLog.getPart();
		part1DescTextBox.Text = schLog.getDescription();
		//seqPart1ComboBox.Text = coreFactory.readProduct(schLog.getPart()).getSeqLast().ToString();
		getValidSeqsForPart(part1TextBox.Text, 1);
		if (seqPart1ComboBox.SelectedIndex == 0)
			getPart1Data(part1TextBox.Text, seqPart1ComboBox.SelectedItem.ToString());
		
		seqPart1ComboBox.Enabled = true;
		addToAllParts(part1TextBox.Text, 1);
	}
		
	if(schLog.getPart2().Equals(string.Empty))
		tabControl.TabPages.Remove(part2TabPage);
	else{
		part2TextBox.Text = schLog.getPart2();
		part2DescTextBox.Text = schLog.getDescription2();
		//seqPart2ComboBox.Text = coreFactory.readProduct(schLog.getPart()).getSeqLast().ToString();
		getValidSeqsForPart(part2TextBox.Text, 2);
		if (seqPart2ComboBox.SelectedIndex == 0)
			getPart2Data(part2TextBox.Text, seqPart2ComboBox.SelectedItem.ToString());
		
		seqPart2ComboBox.Enabled = true;
		if (!schLog.getFamily().Equals(""))
			addToAllParts(part2TextBox.Text, 2);
	}
	
	if(schLog.getPart3().Equals(string.Empty))
		tabControl.TabPages.Remove(part3TabPage);
	else{
		part3TextBox.Text = schLog.getPart3();
		part3DescTextBox.Text = schLog.getDescription3();
		//seqPart3ComboBox.Text = coreFactory.readProduct(schLog.getPart()).getSeqLast().ToString();
		getValidSeqsForPart(part3TextBox.Text, 3);
		if (seqPart3ComboBox.SelectedIndex == 0)
			getPart3Data(part3TextBox.Text, seqPart3ComboBox.SelectedItem.ToString());
		
		seqPart3ComboBox.Enabled = true;
		if (!schLog.getFamily().Equals(""))
			addToAllParts(part3TextBox.Text, 3);
	}
	
	if(schLog.getPart4().Equals(string.Empty))
		tabControl.TabPages.Remove(part4TabPage);
	else{
		part4TextBox.Text = schLog.getPart4();
		part4DescTextBox.Text = schLog.getDescription4();
		//seqPart4ComboBox.Text = coreFactory.readProduct(schLog.getPart()).getSeqLast().ToString();
		getValidSeqsForPart(part4TextBox.Text, 4);
		if (seqPart4ComboBox.SelectedIndex == 0)
			getPart4Data(part4TextBox.Text, seqPart4ComboBox.SelectedItem.ToString());
		
		seqPart4ComboBox.Enabled = true;
		if (!schLog.getFamily().Equals(""))
			addToAllParts(part4TextBox.Text, 4);
	}
	tabControl.SelectedIndex = 0;
	
	uomTextBox.Text = schLog.getUOM();
	machineHrsTextBox.Value = schLog.getMachineHrs();
		
	mainToolComboBox.Items.Add(schLog.getMainTool());
	mainToolComboBox.SelectedIndex = 0;
		
	qtyPerToolTextBox.Value = schLog.getQtyPerTool();
	
	mainMaterialTextBox.Text = schLog.getMainMaterial();
		
	qtyPerTextBox.Value = schLog.getQtyPer();
	qtyReqTextBox.Value = schLog.getMaterialReq();
	if (schLog.getStatus().Equals(Constants.STATUS_ACTIVE)){
		activeRadioButton.Checked = true;
		inactiveRadioButton.Checked = false;
	}
	else{
		activeRadioButton.Checked = false;
		inactiveRadioButton.Checked = true;
	}
	dateTimePicker.Value = schLog.getDateReq();
}


private 
void okButton_Click(object sender, System.EventArgs e){
	if (dataOk()){
		screenToObject();
		if (flagEdit){
			coreFactory.updateSchLog(schLog);
			this.Close();
		}
		else{
			if (coreFactory.existsSchLog(schLog.getDb(), schLog.getJobcardID(), schLog.getCompany(), schLog.getPlant()))
				MessageBox.Show("Job Card Exists!");
			else{
				coreFactory.writeSchLog(schLog);
				this.Close();
			}
		}
	}
}

private 
void cancelButton_Click(object sender, System.EventArgs e){
	this.Close();
}

private
bool dataOk(){
	if (companyCodeTextBox.Text.Equals("")){
		errorProvider.SetError(companySearchButton, "Select Company");
		return false;
	}
	if (plantCodeTextBox.Text.Equals("")){
		errorProvider.SetError(plantSearchButton, "Select Plant");
		return false;
	}
	if (jobCardIdTextBox.Text.Equals("")){
		errorProvider.SetError(jobCardIdTextBox, "Field Needed");
		return false;
	}
	return true;
}

private 
void machineSearchButton_Click(object sender, System.EventArgs e){
	MachineSearchForm machineSearchForm = new MachineSearchForm("Machine Search", plantCodeTextBox.Text,
	                                                            deptCodeTextBox.Text, machineTextBox.Text);
	machineSearchForm.ShowDialog();
	if (machineSearchForm.DialogResult == DialogResult.OK){		
		string[] v = machineSearchForm.getSelected();
		machineTextBox.Text = v[2];
		machineDescTextBox.Text = v[3];
	}
	machineSearchForm.Dispose();
}

private 
void jobCardIdTextBox_TextChanged(object sender, System.EventArgs e){
	errorProvider.SetError(jobCardIdTextBox, "");
}

private 
void getTools(){
	mainToolComboBox.Items.Clear();
	toolDescTextBox.Text = "";
		
	tools = coreFactory.getPdToolByPart(part1TextBox.Text, part2TextBox.Text, part3TextBox.Text, part4TextBox.Text);
	for(int i = 0; i < tools.Length; i ++){
		string item = tools[i][0];
		mainToolComboBox.Items.Add(item);		
	}
	if(mainToolComboBox.Items.Count != 0)
		mainToolComboBox.SelectedIndex = 0;
}

private 
void mainToolComboBox_SelectedIndexChanged(object sender, System.EventArgs e){
	if (tools != null)
		toolDescTextBox.Text = tools[0][1];
}

private
void getPart1Data(string part, string seq){
	// get qoh's
	decimal[] qohs = coreFactory.getSeqQOHs(part);
	currPart1SeqTextBox.Value = qohs[0];
	prePart1SeqTextBox.Value = qohs[1];
	nextPart1SeqTextBox.Value = qohs[2];
	
	//Product Plan
	ProductPlan productPlan = coreFactory.readProductPlan(part, int.Parse(seq));
	if (productPlan != null){
		mainMaterialTextBox.Text = productPlan.getMainMaterial();
		mainMat1QohTextBox.Value = productPlan.getMainMatQty();
		operationTextBox.Text = productPlan.getBatchOperation();
		nextOperationTextBox.Text = productPlan.getNextOpQtyTransfer();
		runQtyTextBox.Value = productPlan.getTarRunQty();
		runStandardTextBox.Value = coreFactory.getRunStdByPart(part, seq);
		uomTextBox.Text = productPlan.getInvUom();
	}
}

private
void getPart2Data(string part, string seq){
	// get qoh's
	decimal[] qohs = coreFactory.getSeqQOHs(part);
	currPart2SeqTextBox.Value = qohs[0];
	prePart2SeqTextBox.Value = qohs[1];
	nextPart2SeqTextBox.Value = qohs[2];
	
	//Product Plan
	ProductPlan productPlan = coreFactory.readProductPlan(part, int.Parse(seq));
	if (productPlan != null){
		mainMaterial2TextBox.Text = productPlan.getMainMaterial();
		mainMat2QohTextBox.Value = productPlan.getMainMatQty();
		operation2TextBox.Text = productPlan.getBatchOperation();
		nextOperation2TextBox.Text = productPlan.getNextOpQtyTransfer();
		runQty2TextBox.Value = productPlan.getTarRunQty();
		runStandard2TextBox.Value = coreFactory.getRunStdByPart(part, seq);
		uom2TextBox.Text = productPlan.getInvUom();
	}
}

private
void getPart3Data(string part, string seq){
	// get qoh's
	decimal[] qohs = coreFactory.getSeqQOHs(part);
	currPart3SeqTextBox.Value = qohs[0];
	prePart3SeqTextBox.Value = qohs[1];
	nextPart3SeqTextBox.Value = qohs[2];
	
	//Product Plan
	ProductPlan productPlan = coreFactory.readProductPlan(part, int.Parse(seq));
	if (productPlan != null){
		mainMaterial3TextBox.Text = productPlan.getMainMaterial();
		mainMat3QohTextBox.Value = productPlan.getMainMatQty();
		operation3TextBox.Text = productPlan.getBatchOperation();
		nextOperation3TextBox.Text = productPlan.getNextOpQtyTransfer();
		runQty3TextBox.Value = productPlan.getTarRunQty();
		runStandard3TextBox.Value = coreFactory.getRunStdByPart(part, seq);
		uom3TextBox.Text = productPlan.getInvUom();
	}
}

private
void getPart4Data(string part, string seq){
	// get qoh's
	decimal[] qohs = coreFactory.getSeqQOHs(part);
	currPart4SeqTextBox.Value = qohs[0];
	prePart4SeqTextBox.Value = qohs[1];
	nextPart4SeqTextBox.Value = qohs[2];
	
	//Product Plan
	ProductPlan productPlan = coreFactory.readProductPlan(part, int.Parse(seq));
	if (productPlan != null){
		mainMaterial4TextBox.Text = productPlan.getMainMaterial();
		mainMat4QohTextBox.Value = productPlan.getMainMatQty();
		operation4TextBox.Text = productPlan.getBatchOperation();
		nextOperation4TextBox.Text = productPlan.getNextOpQtyTransfer();
		runQty4TextBox.Value = productPlan.getTarRunQty();
		runStandard4TextBox.Value = coreFactory.getRunStdByPart(part, seq);
		uom4TextBox.Text = productPlan.getInvUom();
	}
}

private
void getValidSeqsForPart(string part, int partNum){
	string[] seqs = coreFactory.getValidsSeqsByProdAndDept(part, deptCodeTextBox.Text);
	switch(partNum){
			case 1:
				seqPart1ComboBox.Items.Clear();
				break;
			case 2:
				seqPart2ComboBox.Items.Clear();
				break;
			case 3:
				seqPart3ComboBox.Items.Clear();
				break;
			case 4:
				seqPart4ComboBox.Items.Clear();
				break;
	}
	for(int i = 0; i < seqs.Length; i ++){
		switch(partNum){
			case 1:
				seqPart1ComboBox.Items.Add(seqs[i]);
				break;
			case 2:
				seqPart2ComboBox.Items.Add(seqs[i]);
				break;
			case 3:
				seqPart3ComboBox.Items.Add(seqs[i]);
				break;
			case 4:
				seqPart4ComboBox.Items.Add(seqs[i]);
				break;
		}
	}
	if (seqs.Length > 0){
		switch(partNum){
				case 1:
					seqPart1ComboBox.SelectedIndex = 0;
					break;
				case 2:
					seqPart2ComboBox.SelectedIndex = 0;
					break;
				case 3:
					seqPart3ComboBox.SelectedIndex = 0;
					break;
				case 4:
					seqPart4ComboBox.SelectedIndex = 0;
					break;
		}
	}
}

private 
void seqPart1ComboBox_SelectedIndexChanged(object sender, System.EventArgs e){
	getPart1Data(part1TextBox.Text, seqPart1ComboBox.Text);
}

private 
void seqPart2ComboBox_SelectedIndexChanged(object sender, System.EventArgs e){
	getPart2Data(part2TextBox.Text, seqPart2ComboBox.Text);
}

private 
void seqPart3ComboBox_SelectedIndexChanged(object sender, System.EventArgs e){
	getPart3Data(part3TextBox.Text, seqPart3ComboBox.Text);
}

private 
void seqPart4ComboBox_SelectedIndexChanged(object sender, System.EventArgs e){
	getPart4Data(part4TextBox.Text, seqPart4ComboBox.Text);
}

private
void addToAllParts(string part, int partNum){
	string key;
	bool find;
	switch(partNum){
		case 1:
			key = "Part#1";
			for(int i = 0; i < allPartsComboBox.Items.Count; i ++){
				if (allPartsComboBox.Items[i].ToString().Split(' ')[0].Equals(key))
					allPartsComboBox.Items.RemoveAt(i);
			}
			allPartsComboBox.Items.Add("Part#1 - " + part1TextBox.Text);
			break;
		case 2:
			key = "Part#2";
			find = false;
			for(int i = 0; (i < allPartsComboBox.Items.Count) && !find; i ++){
				if (allPartsComboBox.Items[i].ToString().Split(' ')[0].Equals(key))
					allPartsComboBox.Items.RemoveAt(i);
			}
			allPartsComboBox.Items.Add("Part#2 - " + part2TextBox.Text);
			break;
		case 3:
			key = "Part#3";
			find = false;
			for(int i = 0; (i < allPartsComboBox.Items.Count) && !find; i ++){
				if (allPartsComboBox.Items[i].ToString().Split(' ')[0].Equals(key))
					allPartsComboBox.Items.RemoveAt(i);
			}
			allPartsComboBox.Items.Add("Part#3 - " + part3TextBox.Text);
			break;
		case 4:
			key = "Part#4";
			find = false;
			for(int i = 0; (i < allPartsComboBox.Items.Count) && !find; i ++){
				if (allPartsComboBox.Items[i].ToString().Split(' ')[0].Equals(key))
					allPartsComboBox.Items.RemoveAt(i);
			}
			allPartsComboBox.Items.Add("Part#4 - " + part4TextBox.Text);
			break;
	}
	seqsSelPartComboBox.Enabled = true;
	allPartsComboBox.SelectedIndex = 0;
}

private 
void allPartsComboBox_SelectedIndexChanged(object sender, System.EventArgs e){
	string part = allPartsComboBox.SelectedItem.ToString().Split(' ')[0];
	switch(part){
		case "Part#1":
			getValidSeqsForPartSelected(part1TextBox.Text, 1);
			break;
		case "Part#2":
			getValidSeqsForPartSelected(part2TextBox.Text, 2);
			break;
		case "Part#3":
			getValidSeqsForPartSelected(part3TextBox.Text, 3);
			break;
		case "Part#4":
			getValidSeqsForPartSelected(part4TextBox.Text, 4);
			break;
	}
}

private
void getValidSeqsForPartSelected(string part, int partNum){
	seqsSelPartComboBox.Items.Clear();
	string[] seqs = coreFactory.getValidsSeqsByProdAndDept(part, deptCodeTextBox.Text);
	for(int i = 0; i < seqs.Length; i ++){
		switch(partNum){
			case 1:
				seqsSelPartComboBox.Items.Add(seqs[i]);
				break;
			case 2:
				seqsSelPartComboBox.Items.Add(seqs[i]);
				break;
			case 3:
				seqsSelPartComboBox.Items.Add(seqs[i]);
				break;
			case 4:
				seqsSelPartComboBox.Items.Add(seqs[i]);
				break;
		}
	}
	if (seqs.Length > 0){
		switch(partNum){
				case 1:
					seqsSelPartComboBox.SelectedIndex = 0;
					break;
				case 2:
					seqsSelPartComboBox.SelectedIndex = 0;
					break;
				case 3:
					seqsSelPartComboBox.SelectedIndex = 0;
					break;
				case 4:
					seqsSelPartComboBox.SelectedIndex = 0;
					break;
		}
	}
}

private 
void seqsSelPartComboBox_SelectedIndexChanged(object sender, System.EventArgs e){
	string[] aux = allPartsComboBox.SelectedItem.ToString().Split(' ');
	string num = aux[0];
	string part = aux[2]; 
	
	//Product Plan
	ProductPlan productPlan = coreFactory.readProductPlan(part, int.Parse(seqsSelPartComboBox.SelectedItem.ToString()));
	if (productPlan != null){
		//runQtySelPartTextBox.Value = productPlan.getTarRunQty();
		runStdSelPartTextBox.Value = coreFactory.getRunStdByPart(part, seqsSelPartComboBox.SelectedItem.ToString());
		runQtySelPartTextBox.Value = runStdSelPartTextBox.Value;
		uomSelPartTextBox.Text = productPlan.getInvUom();		
	}
	
	string[] machine = coreFactory.getMachineByPartAndSeq(plantCodeTextBox.Text, deptCodeTextBox.Text, part, 
												          int.Parse(seqsSelPartComboBox.SelectedItem.ToString()));	
	machineTextBox.Text = machine[0];
	machineDescTextBox.Text = machine[1];
}

private 
void qtyReqTextBox_ValueChanged(object sender, System.EventArgs e){
	if (runQtySelPartTextBox.Value != 0)
		machineHrsTextBox.Value = qtyReqTextBox.Value / runQtySelPartTextBox.Value;
	else
		machineHrsTextBox.Value = 0;
}

private 
void runQtySelPartTextBox_ValueChanged(object sender, System.EventArgs e){
	qtyReqTextBox_ValueChanged(null, null);
}

private 
void SchdLogEditForm_Load(object sender, System.EventArgs e){
	Color lightGrey = Color.FromArgb(232, 232, 232);
	
	currPart1SeqTextBox.BackColor = lightGrey;
	prePart1SeqTextBox.BackColor = lightGrey;
	nextPart1SeqTextBox.BackColor = lightGrey;
	mainMat1QohTextBox.BackColor = lightGrey;
	runQtyTextBox.BackColor = lightGrey;
	runStandardTextBox.BackColor = lightGrey;
	
	currPart2SeqTextBox.BackColor = lightGrey;
	prePart2SeqTextBox.BackColor = lightGrey;
	nextPart2SeqTextBox.BackColor = lightGrey;
	mainMat2QohTextBox.BackColor = lightGrey;
	runQty2TextBox.BackColor = lightGrey;
	runStandard2TextBox.BackColor = lightGrey;
	
	currPart3SeqTextBox.BackColor = lightGrey;
	prePart3SeqTextBox.BackColor = lightGrey;
	nextPart3SeqTextBox.BackColor = lightGrey;
	mainMat3QohTextBox.BackColor = lightGrey;
	runQty3TextBox.BackColor = lightGrey;
	runStandard3TextBox.BackColor = lightGrey;
	
	currPart4SeqTextBox.BackColor = lightGrey;
	prePart4SeqTextBox.BackColor = lightGrey;
	nextPart4SeqTextBox.BackColor = lightGrey;
	mainMat4QohTextBox.BackColor = lightGrey;
	runQty4TextBox.BackColor = lightGrey;
	runStandard4TextBox.BackColor = lightGrey;
	
	runStdSelPartTextBox.BackColor = lightGrey;
	
}

}
}


