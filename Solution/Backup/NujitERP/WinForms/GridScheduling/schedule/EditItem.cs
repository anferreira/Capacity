using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using NujitCustomWinControls;

using Nujit.NujitERP.ClassLib.Core;
using GridScheduling.gui;

using Nujit.NujitERP.ClassLib.Util;


namespace GridScheduling.gui.schedule{

public
class EditItem : System.Windows.Forms.Form{

private System.Windows.Forms.Label label17;
private System.Windows.Forms.Label label19;
private System.Windows.Forms.TextBox qtyText;
private System.Windows.Forms.Label label1;
private System.Windows.Forms.Button okButton;
private System.Windows.Forms.Label label2;
private System.Windows.Forms.Label label4;
private System.Windows.Forms.GroupBox groupBox2;
private System.Windows.Forms.TextBox positionText;
private System.Windows.Forms.ComboBox prodIdComboBox;
private System.Windows.Forms.RadioButton individualPartRB;
private System.Windows.Forms.RadioButton familyPartRB;
private System.Windows.Forms.ComboBox seqComboBox;

private int mode;
private string plant;
private bool isFamilyPart;
public const int ADD_MODE = 0;
public const int UPDATE_MODE = 1;
public const int DELETE_MODE = 2;
private CoreFactory core = UtilCoreFactory.createCoreFactory();

private System.Windows.Forms.Button cancelButton;
private System.Windows.Forms.ComboBox machineComboBox;
private System.Windows.Forms.Label label5;
private System.Windows.Forms.Label Time;
private System.Windows.Forms.Button calcButton;
private System.Windows.Forms.Label label7;
private System.Windows.Forms.TextBox hrPrTextBox;

private string endDate = "";
private string endTime = "";
private System.Windows.Forms.TabControl tabControl1;
private System.Windows.Forms.TabPage tabPage1;
private System.Windows.Forms.TabPage tabPage2;
private System.Windows.Forms.Label label3;
private System.Windows.Forms.Label label6;
private System.Windows.Forms.TextBox textBox1;
private System.Windows.Forms.TextBox textBox2;
private System.Windows.Forms.DataGrid packagingGrid;
private System.Windows.Forms.Button addPackButton;
private System.Windows.Forms.Button editPackButton;
private System.Windows.Forms.Button removePackButton;
private DataTable dataTable;
private Schedule schedule;
private CapacityVersion version;
	private System.Windows.Forms.Button allMachinesButton;
	private System.Windows.Forms.DateTimePicker endDateDateTimePicker;
	private NujitCustomWinControls.TimeCtrl timeEndTimeCtrl;
	private System.Windows.Forms.Label label8;
	private System.Windows.Forms.ComboBox deptComboBox;

/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;

public
EditItem(string plant, Schedule schedule){
	InitializeComponent();
	this.mode = ADD_MODE;
	this.plant = plant;
	this.schedule = schedule;
	this.version = core.readCapacityVersion(schedule.getVersion());
	isFamilyPart=false;

	initializePackagingGrid();

	modifyStatusControls();

	loadParts();
	prodIdComboBox.Focus();
}

public
EditItem(string plant, string mach, string prod, string seq, 
		string qty, string pos, string hrPr, string start, string end,Schedule schedule, bool isFam){
	
	InitializeComponent();
	this.mode = UPDATE_MODE;
	this.plant = plant;
	this.schedule = schedule;
	this.version = core.readCapacityVersion(schedule.getVersion());
	isFamilyPart=isFam;
	
	prodIdComboBox.Text = prod;
	qtyText.Text = qty;
	positionText.Text = pos;
	seqComboBox.DropDownStyle = ComboBoxStyle.DropDown;
	seqComboBox.Text = seq;
	machineComboBox.DropDownStyle = ComboBoxStyle.DropDown;
	machineComboBox.Text = mach;
	machineComboBox.Items.Add(mach);
	machineComboBox.SelectedIndex = 0;

	DateTime aux = DateUtil.parseCompleteDate(start, DateUtil.MMDDYYYY);
	endDateDateTimePicker.Value = new DateTime (aux.Year, aux.Month, aux.Day);
	timeEndTimeCtrl.Value = DateTime.Today.AddHours(aux.Hour).AddMinutes(aux.Minute).AddSeconds(aux.Second);
	
	aux = DateUtil.parseCompleteDate(end, DateUtil.MMDDYYYY);
	endDate = DateUtil.getDateRepresentation(aux, DateUtil.MMDDYYYY);
	endTime = DateUtil.getTimeRepresentation(aux);

	initializePackagingGrid();

	refreshProdHours();
	modifyStatusControls();
	loadGrid(prod);
}

private 
void modifyStatusControls(){
	switch(mode){
	case ADD_MODE:
		endDateDateTimePicker.Value = DateTime.Today;
		timeEndTimeCtrl.Text = DateUtil.getTimeRepresentation(DateTime.Now);
		break;
	case UPDATE_MODE:
		positionText.Enabled = false;
		prodIdComboBox.Enabled = false;
		seqComboBox.Enabled = false;
		endDateDateTimePicker.Enabled = false;
		timeEndTimeCtrl.Enabled = false;
		machineComboBox.Enabled = false;
		individualPartRB.Enabled = false;
		familyPartRB.Enabled = false;
		qtyText.Enabled = false;
		break;
	}
	this.textBox1.Enabled = false;
	this.textBox2.Enabled = false;

	this.textBox1.Text = prodIdComboBox.Text;
	this.textBox2.Text = qtyText.Text;
}

/// <summary>
/// Clean up any resources being used.
/// </summary>
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
/// <summary>
/// Required method for Designer support - do not modify
/// the contents of this method with the code editor.
/// </summary>
private 
void InitializeComponent(){
	this.positionText = new System.Windows.Forms.TextBox();
	this.label17 = new System.Windows.Forms.Label();
	this.label19 = new System.Windows.Forms.Label();
	this.qtyText = new System.Windows.Forms.TextBox();
	this.label1 = new System.Windows.Forms.Label();
	this.okButton = new System.Windows.Forms.Button();
	this.cancelButton = new System.Windows.Forms.Button();
	this.label2 = new System.Windows.Forms.Label();
	this.label4 = new System.Windows.Forms.Label();
	this.groupBox2 = new System.Windows.Forms.GroupBox();
	this.timeEndTimeCtrl = new NujitCustomWinControls.TimeCtrl();
	this.endDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
	this.allMachinesButton = new System.Windows.Forms.Button();
	this.hrPrTextBox = new System.Windows.Forms.TextBox();
	this.label7 = new System.Windows.Forms.Label();
	this.calcButton = new System.Windows.Forms.Button();
	this.Time = new System.Windows.Forms.Label();
	this.label5 = new System.Windows.Forms.Label();
	this.machineComboBox = new System.Windows.Forms.ComboBox();
	this.seqComboBox = new System.Windows.Forms.ComboBox();
	this.familyPartRB = new System.Windows.Forms.RadioButton();
	this.individualPartRB = new System.Windows.Forms.RadioButton();
	this.prodIdComboBox = new System.Windows.Forms.ComboBox();
	this.tabControl1 = new System.Windows.Forms.TabControl();
	this.tabPage1 = new System.Windows.Forms.TabPage();
	this.tabPage2 = new System.Windows.Forms.TabPage();
	this.removePackButton = new System.Windows.Forms.Button();
	this.editPackButton = new System.Windows.Forms.Button();
	this.addPackButton = new System.Windows.Forms.Button();
	this.textBox2 = new System.Windows.Forms.TextBox();
	this.textBox1 = new System.Windows.Forms.TextBox();
	this.label6 = new System.Windows.Forms.Label();
	this.label3 = new System.Windows.Forms.Label();
	this.packagingGrid = new System.Windows.Forms.DataGrid();
	this.label8 = new System.Windows.Forms.Label();
	this.deptComboBox = new System.Windows.Forms.ComboBox();
	this.groupBox2.SuspendLayout();
	this.tabControl1.SuspendLayout();
	this.tabPage1.SuspendLayout();
	this.tabPage2.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.packagingGrid)).BeginInit();
	this.SuspendLayout();
	// 
	// positionText
	// 
	this.positionText.Location = new System.Drawing.Point(128, 168);
	this.positionText.Name = "positionText";
	this.positionText.Size = new System.Drawing.Size(104, 20);
	this.positionText.TabIndex = 42;
	this.positionText.Text = "";
	// 
	// label17
	// 
	this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.label17.Location = new System.Drawing.Point(40, 168);
	this.label17.Name = "label17";
	this.label17.Size = new System.Drawing.Size(80, 20);
	this.label17.TabIndex = 0;
	this.label17.Text = "Position";
	this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label19
	// 
	this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.label19.Location = new System.Drawing.Point(40, 192);
	this.label19.Name = "label19";
	this.label19.Size = new System.Drawing.Size(64, 20);
	this.label19.TabIndex = 38;
	this.label19.Text = "End Date";
	this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// qtyText
	// 
	this.qtyText.Location = new System.Drawing.Point(128, 144);
	this.qtyText.Name = "qtyText";
	this.qtyText.Size = new System.Drawing.Size(104, 20);
	this.qtyText.TabIndex = 10;
	this.qtyText.Text = "";
	this.qtyText.TextChanged += new System.EventHandler(this.qtyText_TextChanged);
	// 
	// label1
	// 
	this.label1.Location = new System.Drawing.Point(40, 48);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(72, 20);
	this.label1.TabIndex = 1;
	this.label1.Text = "Prod Id/Fam";
	this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// okButton
	// 
	this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.okButton.Location = new System.Drawing.Point(632, 32);
	this.okButton.Name = "okButton";
	this.okButton.Size = new System.Drawing.Size(60, 24);
	this.okButton.TabIndex = 5;
	this.okButton.Text = "OK";
	this.okButton.Click += new System.EventHandler(this.okButton_Click);
	// 
	// cancelButton
	// 
	this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.cancelButton.Location = new System.Drawing.Point(632, 64);
	this.cancelButton.Name = "cancelButton";
	this.cancelButton.Size = new System.Drawing.Size(60, 24);
	this.cancelButton.TabIndex = 6;
	this.cancelButton.Text = "Cancel";
	this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
	// 
	// label2
	// 
	this.label2.Location = new System.Drawing.Point(40, 72);
	this.label2.Name = "label2";
	this.label2.Size = new System.Drawing.Size(72, 20);
	this.label2.TabIndex = 2;
	this.label2.Text = "Seq";
	this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label4
	// 
	this.label4.Location = new System.Drawing.Point(40, 144);
	this.label4.Name = "label4";
	this.label4.Size = new System.Drawing.Size(72, 20);
	this.label4.TabIndex = 4;
	this.label4.Text = "Quantity";
	this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// groupBox2
	// 
	this.groupBox2.Controls.Add(this.label8);
	this.groupBox2.Controls.Add(this.deptComboBox);
	this.groupBox2.Controls.Add(this.timeEndTimeCtrl);
	this.groupBox2.Controls.Add(this.endDateDateTimePicker);
	this.groupBox2.Controls.Add(this.allMachinesButton);
	this.groupBox2.Controls.Add(this.hrPrTextBox);
	this.groupBox2.Controls.Add(this.label7);
	this.groupBox2.Controls.Add(this.calcButton);
	this.groupBox2.Controls.Add(this.Time);
	this.groupBox2.Controls.Add(this.label5);
	this.groupBox2.Controls.Add(this.machineComboBox);
	this.groupBox2.Controls.Add(this.seqComboBox);
	this.groupBox2.Controls.Add(this.familyPartRB);
	this.groupBox2.Controls.Add(this.individualPartRB);
	this.groupBox2.Controls.Add(this.prodIdComboBox);
	this.groupBox2.Controls.Add(this.qtyText);
	this.groupBox2.Controls.Add(this.label1);
	this.groupBox2.Controls.Add(this.label2);
	this.groupBox2.Controls.Add(this.label4);
	this.groupBox2.Controls.Add(this.label17);
	this.groupBox2.Controls.Add(this.positionText);
	this.groupBox2.Controls.Add(this.label19);
	this.groupBox2.Location = new System.Drawing.Point(8, 8);
	this.groupBox2.Name = "groupBox2";
	this.groupBox2.Size = new System.Drawing.Size(592, 272);
	this.groupBox2.TabIndex = 38;
	this.groupBox2.TabStop = false;
	this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
	// 
	// timeEndTimeCtrl
	// 
	this.timeEndTimeCtrl.Location = new System.Drawing.Point(304, 192);
	this.timeEndTimeCtrl.Name = "timeEndTimeCtrl";
	this.timeEndTimeCtrl.ShowSeconds = true;
	this.timeEndTimeCtrl.Size = new System.Drawing.Size(112, 21);
	this.timeEndTimeCtrl.TabIndex = 57;
	this.timeEndTimeCtrl.Value = new System.DateTime(2005, 4, 12, 11, 6, 39, 0);
	// 
	// endDateDateTimePicker
	// 
	this.endDateDateTimePicker.Location = new System.Drawing.Point(128, 192);
	this.endDateDateTimePicker.Name = "endDateDateTimePicker";
	this.endDateDateTimePicker.Size = new System.Drawing.Size(120, 20);
	this.endDateDateTimePicker.TabIndex = 56;
	// 
	// allMachinesButton
	// 
	this.allMachinesButton.Location = new System.Drawing.Point(256, 120);
	this.allMachinesButton.Name = "allMachinesButton";
	this.allMachinesButton.Size = new System.Drawing.Size(40, 18);
	this.allMachinesButton.TabIndex = 55;
	this.allMachinesButton.Text = "All";
	this.allMachinesButton.Click += new System.EventHandler(this.allMachinesButton_Click);
	// 
	// hrPrTextBox
	// 
	this.hrPrTextBox.Enabled = false;
	this.hrPrTextBox.Location = new System.Drawing.Point(280, 144);
	this.hrPrTextBox.Name = "hrPrTextBox";
	this.hrPrTextBox.Size = new System.Drawing.Size(96, 20);
	this.hrPrTextBox.TabIndex = 54;
	this.hrPrTextBox.Text = "";
	// 
	// label7
	// 
	this.label7.Location = new System.Drawing.Point(384, 144);
	this.label7.Name = "label7";
	this.label7.Size = new System.Drawing.Size(56, 20);
	this.label7.TabIndex = 53;
	this.label7.Text = "P. Hours";
	this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// calcButton
	// 
	this.calcButton.Location = new System.Drawing.Point(240, 144);
	this.calcButton.Name = "calcButton";
	this.calcButton.Size = new System.Drawing.Size(24, 16);
	this.calcButton.TabIndex = 52;
	this.calcButton.Text = "...";
	this.calcButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
	// 
	// Time
	// 
	this.Time.Location = new System.Drawing.Point(264, 192);
	this.Time.Name = "Time";
	this.Time.Size = new System.Drawing.Size(32, 20);
	this.Time.TabIndex = 50;
	this.Time.Text = "Time";
	this.Time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label5
	// 
	this.label5.Location = new System.Drawing.Point(40, 120);
	this.label5.Name = "label5";
	this.label5.Size = new System.Drawing.Size(56, 20);
	this.label5.TabIndex = 47;
	this.label5.Text = "Machine";
	// 
	// machineComboBox
	// 
	this.machineComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.machineComboBox.Location = new System.Drawing.Point(128, 120);
	this.machineComboBox.Name = "machineComboBox";
	this.machineComboBox.Size = new System.Drawing.Size(121, 21);
	this.machineComboBox.TabIndex = 46;
	// 
	// seqComboBox
	// 
	this.seqComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.seqComboBox.Location = new System.Drawing.Point(128, 72);
	this.seqComboBox.Name = "seqComboBox";
	this.seqComboBox.Size = new System.Drawing.Size(121, 21);
	this.seqComboBox.TabIndex = 14;
	this.seqComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.seqComboBox_KeyDown);
	this.seqComboBox.Leave += new System.EventHandler(this.seqComboBox_Leave);
	// 
	// familyPartRB
	// 
	this.familyPartRB.Location = new System.Drawing.Point(408, 56);
	this.familyPartRB.Name = "familyPartRB";
	this.familyPartRB.Size = new System.Drawing.Size(104, 16);
	this.familyPartRB.TabIndex = 13;
	this.familyPartRB.Text = "Family Part";
	this.familyPartRB.CheckedChanged += new System.EventHandler(this.familyPartRB_CheckedChanged);
	// 
	// individualPartRB
	// 
	this.individualPartRB.Checked = true;
	this.individualPartRB.Location = new System.Drawing.Point(408, 32);
	this.individualPartRB.Name = "individualPartRB";
	this.individualPartRB.Size = new System.Drawing.Size(104, 16);
	this.individualPartRB.TabIndex = 12;
	this.individualPartRB.TabStop = true;
	this.individualPartRB.Text = "Individual Part";
	this.individualPartRB.CheckedChanged += new System.EventHandler(this.individualPartRB_CheckedChanged);
	// 
	// prodIdComboBox
	// 
	this.prodIdComboBox.Location = new System.Drawing.Point(128, 48);
	this.prodIdComboBox.Name = "prodIdComboBox";
	this.prodIdComboBox.Size = new System.Drawing.Size(121, 21);
	this.prodIdComboBox.TabIndex = 11;
	this.prodIdComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.prodIdComboBox_KeyDown);
	this.prodIdComboBox.SelectedValueChanged += new System.EventHandler(this.prodIdComboBox_SelectedValueChanged);
	this.prodIdComboBox.Click += new System.EventHandler(this.prodIdComboBox_Click);
	this.prodIdComboBox.SelectedIndexChanged += new System.EventHandler(this.prodIdComboBox_SelectedIndexChanged);
	this.prodIdComboBox.Leave += new System.EventHandler(this.prodIdComboBox_Leave);
	// 
	// tabControl1
	// 
	this.tabControl1.Controls.Add(this.tabPage1);
	this.tabControl1.Controls.Add(this.tabPage2);
	this.tabControl1.Location = new System.Drawing.Point(8, 8);
	this.tabControl1.Name = "tabControl1";
	this.tabControl1.SelectedIndex = 0;
	this.tabControl1.Size = new System.Drawing.Size(616, 312);
	this.tabControl1.TabIndex = 39;
	this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
	// 
	// tabPage1
	// 
	this.tabPage1.Controls.Add(this.groupBox2);
	this.tabPage1.Location = new System.Drawing.Point(4, 22);
	this.tabPage1.Name = "tabPage1";
	this.tabPage1.Size = new System.Drawing.Size(608, 286);
	this.tabPage1.TabIndex = 0;
	this.tabPage1.Text = "Item";
	// 
	// tabPage2
	// 
	this.tabPage2.Controls.Add(this.removePackButton);
	this.tabPage2.Controls.Add(this.editPackButton);
	this.tabPage2.Controls.Add(this.addPackButton);
	this.tabPage2.Controls.Add(this.textBox2);
	this.tabPage2.Controls.Add(this.textBox1);
	this.tabPage2.Controls.Add(this.label6);
	this.tabPage2.Controls.Add(this.label3);
	this.tabPage2.Controls.Add(this.packagingGrid);
	this.tabPage2.Location = new System.Drawing.Point(4, 22);
	this.tabPage2.Name = "tabPage2";
	this.tabPage2.Size = new System.Drawing.Size(608, 286);
	this.tabPage2.TabIndex = 1;
	this.tabPage2.Text = "Packaging Specs";
	this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
	// 
	// removePackButton
	// 
	this.removePackButton.Location = new System.Drawing.Point(432, 248);
	this.removePackButton.Name = "removePackButton";
	this.removePackButton.TabIndex = 7;
	this.removePackButton.Text = "Remove";
	this.removePackButton.Click += new System.EventHandler(this.removePackButton_Click);
	// 
	// editPackButton
	// 
	this.editPackButton.Location = new System.Drawing.Point(512, 248);
	this.editPackButton.Name = "editPackButton";
	this.editPackButton.TabIndex = 6;
	this.editPackButton.Text = "Edit";
	this.editPackButton.Click += new System.EventHandler(this.editPackButton_Click);
	// 
	// addPackButton
	// 
	this.addPackButton.Location = new System.Drawing.Point(352, 248);
	this.addPackButton.Name = "addPackButton";
	this.addPackButton.TabIndex = 5;
	this.addPackButton.Text = "Add";
	this.addPackButton.Click += new System.EventHandler(this.addPackButton_Click);
	// 
	// textBox2
	// 
	this.textBox2.Enabled = false;
	this.textBox2.ForeColor = System.Drawing.Color.Red;
	this.textBox2.Location = new System.Drawing.Point(144, 48);
	this.textBox2.Name = "textBox2";
	this.textBox2.TabIndex = 4;
	this.textBox2.Text = "";
	// 
	// textBox1
	// 
	this.textBox1.Enabled = false;
	this.textBox1.ForeColor = System.Drawing.Color.Red;
	this.textBox1.Location = new System.Drawing.Point(144, 24);
	this.textBox1.Name = "textBox1";
	this.textBox1.TabIndex = 3;
	this.textBox1.Text = "";
	// 
	// label6
	// 
	this.label6.Location = new System.Drawing.Point(24, 48);
	this.label6.Name = "label6";
	this.label6.TabIndex = 2;
	this.label6.Text = "Qty to Produce";
	// 
	// label3
	// 
	this.label3.Location = new System.Drawing.Point(24, 24);
	this.label3.Name = "label3";
	this.label3.TabIndex = 1;
	this.label3.Text = "Internal Part";
	// 
	// packagingGrid
	// 
	this.packagingGrid.CaptionVisible = false;
	this.packagingGrid.DataMember = "";
	this.packagingGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
	this.packagingGrid.Location = new System.Drawing.Point(16, 88);
	this.packagingGrid.Name = "packagingGrid";
	this.packagingGrid.Size = new System.Drawing.Size(576, 144);
	this.packagingGrid.TabIndex = 0;
	this.packagingGrid.Click += new System.EventHandler(this.packagingGrid_Click);
	this.packagingGrid.Navigate += new System.Windows.Forms.NavigateEventHandler(this.packagingGrid_Navigate);
	// 
	// label8
	// 
	this.label8.Location = new System.Drawing.Point(40, 96);
	this.label8.Name = "label8";
	this.label8.Size = new System.Drawing.Size(64, 20);
	this.label8.TabIndex = 59;
	this.label8.Text = "Department";
	// 
	// deptComboBox
	// 
	this.deptComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.deptComboBox.Location = new System.Drawing.Point(128, 96);
	this.deptComboBox.Name = "deptComboBox";
	this.deptComboBox.Size = new System.Drawing.Size(121, 21);
	this.deptComboBox.TabIndex = 58;
	// 
	// EditItem
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(704, 328);
	this.Controls.Add(this.tabControl1);
	this.Controls.Add(this.cancelButton);
	this.Controls.Add(this.okButton);
	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
	this.Name = "EditItem";
	this.Text = "Edit";
	this.Load += new System.EventHandler(this.AddForm_Load);
	this.groupBox2.ResumeLayout(false);
	this.tabControl1.ResumeLayout(false);
	this.tabPage1.ResumeLayout(false);
	this.tabPage2.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.packagingGrid)).EndInit();
	this.ResumeLayout(false);

}
#endregion

private
void AddForm_Load(object sender, System.EventArgs e){
//	loadParts();
//	prodIdComboBox.Focus();
}

private 
void loadParts(){
	prodIdComboBox.Text = "";
	if (isFamilyPart)
		loadFamilyParts();
	else
		loadIndividualParts();
}

private
void loadIndividualParts(){
	string[] products = core.getManufacturedProductCodes(plant);

	this.prodIdComboBox.Items.Clear();
	for(int i = 0; i < products.Length; i++){
		this.prodIdComboBox.Items.Add(products[i].Trim());
	}
	if (prodIdComboBox.Items.Count>0)
		prodIdComboBox.SelectedIndex=0;
}

private
void loadFamilyParts(){
	string[] fam = core.getProductFamilyCodes();
	this.prodIdComboBox.Items.Clear();
	for(int i = 0; i < fam.Length; i++){
		this.prodIdComboBox.Items.Add(fam[i]);
	}
	if (prodIdComboBox.Items.Count>0)
		prodIdComboBox.SelectedIndex=0;
}

private
void readFamilyData(){
	string item1 = (string)prodIdComboBox.SelectedItem;
	string item2 = prodIdComboBox.Text;
	string familyCode = "";
	
	string[] products = new string[0];
	if ((item1 != null) && (!item1.Equals(""))){
		familyCode = item1;
	}else{
		if ((item2 != null) && (!item2.Equals(""))){
			familyCode = item2;
		}
	}

	seqComboBox.Items.Clear();
	string[] validSeqs = core.getValidsSeqsForProduct(familyCode);
	for(int i = 0; i < validSeqs.Length; i++){
		seqComboBox.Items.Add(validSeqs[i]);
	}

	machineComboBox.Items.Clear();
	string[] deptCfg = getCfg();
	string[] machines = core.getMachineCodesFromConfiguration(plant, deptCfg[0], deptCfg[1]);
	for(int i = 0; i < machines.Length; i++){
		machineComboBox.Items.Add(machines[i]);
	}
}

private
void readProductData(){
	string item1 = (string)prodIdComboBox.SelectedItem;
	string item2 = prodIdComboBox.Text;
	string productCode = "";
	
	if ((item1 != null) && (!item1.Equals(""))){
		productCode = item1;
	}else{
		if ((item2 != null) && (!item2.Equals(""))){
			productCode = item2;
		}else{
			return ;
		}
	}
	
	seqComboBox.Items.Clear();
	string[] validSeqs = core.getValidsSeqsForProduct(productCode);
	for(int i = 0; i < validSeqs.Length; i++){
		seqComboBox.Items.Add(validSeqs[i]);
	}

	string[] deptCfg = getCfg();

	deptComboBox.Items.Clear();
	deptComboBox.Items.Add (deptCfg[0]);
	deptComboBox.SelectedIndex = 0;

	machineComboBox.Items.Clear();
	string[] machines = core.getMachineCodesFromConfiguration(plant, deptCfg[0], deptCfg[1]);
	for(int i = 0; i < machines.Length; i++){
		machineComboBox.Items.Add(machines[i]);
	}
	loadGrid(productCode);

}

private
void prodIdComboBox_SelectedValueChanged(object sender, System.EventArgs e){
	if (isFamilyPart){
		readFamilyData();
	}else{
		readProductData();
	}
}

private 
void prodIdComboBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e){
	if ((e != null) && (e.KeyData.ToString().Equals("Enter"))){
		if (isFamilyPart){
			readFamilyData();
		}else{
			readProductData();
		}
	}
}

private
void prodIdComboBox_Leave(object sender, System.EventArgs e){
	if (familyPartRB.Checked){
		readFamilyData();
	}else{
		readProductData();
	}
}

private
void seqComboBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e){
	if ((e != null) && (e.KeyData.ToString().Equals("Enter"))){
		string digitedItem = seqComboBox.Text;
		bool founded = false;

		IEnumerator enumerator = seqComboBox.Items.GetEnumerator();
		while(enumerator.MoveNext()){
			string item = (string) enumerator.Current;
			if (item.Equals(digitedItem)){
				founded = true;
			}
		}

		if (!founded){
			MessageBox.Show("This Sequence is not valid");
			seqComboBox.Text = "";
		}
	}
}

private
void seqComboBox_Leave(object sender, System.EventArgs e){
	string digitedItem = seqComboBox.Text;
	string selectedItem = (string)seqComboBox.SelectedItem;
	string theItem = "";

	if ((digitedItem != null) && (!digitedItem.Equals(""))){
		theItem = digitedItem;
	}else{
		theItem = selectedItem;
	}
	
	bool founded = false;

	IEnumerator enumerator = seqComboBox.Items.GetEnumerator();
	while(enumerator.MoveNext()){
		string item = (string) enumerator.Current;
		if (item.Equals(theItem)){
			founded = true;
		}
	}


	if (!founded){
		MessageBox.Show("This Sequence is not valid");
		seqComboBox.Text = "";
	}
}

private
void okButton_Click(object sender, System.EventArgs e){
	if (validData()){
		this.DialogResult = DialogResult.OK;
		Close();
	}
}

private 
void cancelButton_Click(object sender, System.EventArgs e){
	this.DialogResult = DialogResult.Cancel;
	Close();
}

public
string getPart(){
	if ((prodIdComboBox.Text != null) && (!prodIdComboBox.Text.Equals("")))
		return prodIdComboBox.Text;
	return (string)prodIdComboBox.SelectedItem;
}

public
string getSeq(){
	if ((seqComboBox.Text != null) && (!seqComboBox.Text.Equals("")))
		return seqComboBox.Text;
	return (string)seqComboBox.SelectedItem;
}

public
string getQty(){
	return qtyText.Text;
}

public
string getPos(){
	if (positionText.Text.Equals(""))
		return "0";
	return this.positionText.Text;
}

public
string getStartDate(){
	return DateUtil.getDateRepresentation(endDateDateTimePicker.Value, DateUtil.MMDDYYYY) + " " + timeEndTimeCtrl.toString(TimeCtrl.HHMMSS24);
}

public
string getEndDate(){
/*	DateTime start = DateUtil.parseCompleteDate(startDateTimeText.Text + " " + timeStartTextBox.Text, DateUtil.MMDDYYYY);
	start = start.AddHours(double.Parse(getProdHours()));
	return DateUtil.getCompleteDateRepresentation(start, DateUtil.MMDDYYYY);
*/	return DateUtil.getDateRepresentation(endDateDateTimePicker.Value, DateUtil.MMDDYYYY) + " " + timeEndTimeCtrl.toString(TimeCtrl.HHMMSS24);
}

public
string getProdHours(){
	string prod = "";
	if ((prodIdComboBox.Text != null) && (!prodIdComboBox.Text.Equals("")))
		prod = prodIdComboBox.Text;
	else
		prod = (string)prodIdComboBox.SelectedItem;
	decimal qty = decimal.Parse(qtyText.Text);

	decimal hrPr = core.getProductionHours(plant, prod, qty);
	return Decimal.Round(hrPr, 2).ToString();
}

public
string getDepartment(){
	if ((deptComboBox.Text != null) && (!deptComboBox.Text.Equals("")))
		return deptComboBox.Text;
	return (string)deptComboBox.SelectedItem;
}

public
string getMachine(){
	if ((machineComboBox.Text != null) && (!machineComboBox.Text.Equals("")))
		return machineComboBox.Text;
	return (string)machineComboBox.SelectedItem;
}

public bool getIsFamilyPart(){
	return isFamilyPart;
}

private
string[] getCfg(){
	string prod = "";
	if ((prodIdComboBox.Text != null) && (!prodIdComboBox.Text.Equals("")))
		prod = prodIdComboBox.Text;
	else
		prod = (string)prodIdComboBox.SelectedItem;
	string[] cfg = core.getCfgFromProd(plant, prod);
	return cfg;
}

private 
void calcButton_Click(object sender, System.EventArgs e){
	refreshProdHours();
}

private
void refreshProdHours(){
	string prod = "";
	if ((prodIdComboBox.Text != null) && (!prodIdComboBox.Text.Equals("")))
		prod = prodIdComboBox.Text;
	else{
		if (prodIdComboBox.SelectedItem == null)
			return;
		prod = (string)prodIdComboBox.SelectedItem;
	}
	
	if (qtyText.Text == null)
		return;
	decimal qty = decimal.Parse(qtyText.Text);

	decimal hrPr = core.getProductionHours(plant, prod, qty);
	hrPrTextBox.Text = Decimal.Round(hrPr, 2).ToString();
}

private
void setCurrentValue(string myValue, int column){
	int row = packagingGrid.CurrentCell.RowNumber;
	int index = 0;

	IEnumerator en = dataTable.Rows.GetEnumerator();
	while(en.MoveNext()){
		DataRow dataRow = (DataRow)en.Current;

		if (index == row){
			string dataType = dataRow[column].GetType().ToString();
			switch(dataType){
			case "System.String":
				dataRow[column] = myValue;
				break;
			case "System.Int32":
				int intValue = int.Parse(myValue);
				dataRow[column] = intValue;
				break;
			case "System.Decimal":
				dataRow[column] = decimal.Parse(myValue);
				break;
			case "System.DateTime":
				dataRow[column] = DateUtil.parseDate(myValue, DateUtil.DDMMYYYY);
				break;
			}
		}
		index++;
	}
}

private
string getCurrentValue(int column){
	int row = packagingGrid.CurrentCell.RowNumber;
	int index = 0;
	
	IEnumerator en = dataTable.Rows.GetEnumerator();
	while(en.MoveNext()){
		DataRow dataRow = (DataRow)en.Current;

		if (index == row)
			return dataRow[column].ToString();
		index++;
	}
	return "";
}

private
void initializePackagingGrid(){
    dataTable = new DataTable();

	dataTable.Columns.Add(new DataColumn("Ship-To Location", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Customer Prod Id", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Order Number", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Order/Item Number", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Qty", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Number of Boxes", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Qty On Hand", typeof(string)));

	DataView dataView = new DataView(dataTable);
	dataView.AllowEdit = false;
	dataView.AllowDelete = false;
	dataView.AllowNew = false;
	
	packagingGrid.DataSource = dataView;
}

private 
void addPackButton_Click(object sender, System.EventArgs e){
	EditPackagingItem editPackagingItem = new EditPackagingItem();
	editPackagingItem.ShowDialog();

	if (editPackagingItem.DialogResult == DialogResult.OK){
		DataRow dataRow = dataTable.NewRow();

		dataRow[0] = editPackagingItem.getShipToLocation();
		dataRow[1] = editPackagingItem.getCustomerProdId();
		dataRow[2] = editPackagingItem.getOrderNumber();
		dataRow[3] = editPackagingItem.getOrderItemNumber();
		dataRow[4] = editPackagingItem.getQty();
		dataRow[5] = editPackagingItem.getNumberOfBoxes();
		dataRow[6] = "0";
		
		dataTable.Rows.Add(dataRow);
	}
}

private 
void editPackButton_Click(object sender, System.EventArgs e){
	if (dataTable.Rows.Count > 0){
		string shipToLocation = getCurrentValue(0);
		string customerProdId = getCurrentValue(1);
		string orderNumber = getCurrentValue(2);
		string orderItemNumber = getCurrentValue(3);
		string qty = getCurrentValue(4);
		string numberOfBoxes = getCurrentValue(5);

		EditPackagingItem editPackagingItem = new EditPackagingItem(shipToLocation,
			customerProdId, orderNumber, orderItemNumber, qty, numberOfBoxes);
		editPackagingItem.ShowDialog();
		
		if (editPackagingItem.DialogResult == DialogResult.OK){
			setCurrentValue(editPackagingItem.getShipToLocation(), 0);
			setCurrentValue(editPackagingItem.getCustomerProdId(), 1);
			setCurrentValue(editPackagingItem.getOrderNumber(), 2);
			setCurrentValue(editPackagingItem.getOrderItemNumber(), 3);
			setCurrentValue(editPackagingItem.getQty(), 4);
			setCurrentValue(editPackagingItem.getNumberOfBoxes(), 5);
			setCurrentValue("0", 6);
		}
	}else{
		MessageBox.Show("There are no record to edit");
	}
}

private 
void removePackButton_Click(object sender, System.EventArgs e){
	if (dataTable.Rows.Count > 0){
		DialogResult deleteConfirm = MessageBox.Show("Remove item ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (deleteConfirm == DialogResult.No)
			return;
		
		int rowNumber = packagingGrid.CurrentCell.RowNumber;
		dataTable.Rows.RemoveAt(rowNumber);
	}else{
		MessageBox.Show("There are no record to delete");
	}
}

public
string[][] getVecPackagingItems(){
	string[][] vec = new String[dataTable.Rows.Count][];
	
	for(int i = 0; i < dataTable.Rows.Count; i++){
		string[] lin = new String[6];
		
		DataRow row = dataTable.Rows[i];
		lin[0] = row[0].ToString();
		lin[1] = row[1].ToString();
		lin[2] = row[2].ToString();
		lin[3] = row[3].ToString();
		lin[4] = row[4].ToString();
		lin[5] = row[5].ToString();
		
		vec[i] = lin;
	}
	return vec;
}

public 
void loadGrid (String prodId){
	dataTable.Rows.Clear();
	String[][] vec =  schedule.getProdPackDtlInfo(prodId);

	for (int i = 0; i<vec.Length; i++){
		DataRow dataRow = dataTable.NewRow();
		dataRow[0] = vec[i][0];
		dataRow[1] = vec[i][1];
		dataRow[2] = vec[i][2];
		dataRow[3] = vec[i][3];
		dataRow[4] = vec[i][4];
		dataRow[5] = vec[i][5];
		dataRow[6] = 0 ; // Es el valor de Qty On Hand, se carga en 0 
							// desde la pantalla editPacking, pero no se carga en la base.
		dataTable.Rows.Add(dataRow);
	
	}
}

private 
void tabPage2_Click(object sender, System.EventArgs e){
	this.textBox1.Text = prodIdComboBox.Text;
	this.textBox2.Text = qtyText.Text;
}

private 
void packagingGrid_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne){

}

private 
void packagingGrid_Click(object sender, System.EventArgs e){
	if (packagingGrid.TableStyles.Count > 0){
		packagingGrid.PreferredRowHeight = 10;

		DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();
    
		dgdtblStyle = packagingGrid.TableStyles[0];
		dgdtblStyle.PreferredRowHeight = 10;
	}
}

private 
void prodIdComboBox_SelectedIndexChanged(object sender, System.EventArgs e){
	if (prodIdComboBox.SelectedIndex > -1){
		textBox1.Text = prodIdComboBox.Text;
	}
}

private 
void qtyText_TextChanged(object sender, System.EventArgs e){
	try{
		int qty = Int32.Parse(qtyText.Text);
		textBox2.Text = qty.ToString();
	}catch(System.FormatException){
		textBox2.Text = "0";
	}
}

private 
void familyPartRB_CheckedChanged(object sender, System.EventArgs e){
    isFamilyPart=true;		
	loadParts();
}

private 
void individualPartRB_CheckedChanged(object sender, System.EventArgs e){
	isFamilyPart=false;
	loadParts();
}

private 
void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e){
}

private 
void prodIdComboBox_Click(object sender, System.EventArgs e){
	if (isFamilyPart){
		readFamilyData();
	}else{
		readProductData();
	}
}

private 
void groupBox2_Enter(object sender, System.EventArgs e){
}

private
bool validData(){
	if ((qtyText.Text == null) || (qtyText.Text.Equals(""))){
		MessageBox.Show("Please, fill all the fields in the form ","Error");
		return false;
	}

/*	if ((startDateTimeText.Text  == null) || (startDateTimeText.Text.Equals(""))){
		MessageBox.Show("Please, fill all the fields in the form ","Error");
		return false;
	}
	
	if (!DateUtil.isValidDate(startDateTimeText.Text, DateUtil.MMDDYYYY)) {
		MessageBox.Show("Please, check the start date format","Error");
		return false;
	}
*/
	if ((endDateDateTimePicker.Value.CompareTo(version.getDtStart()) < 0) ||
		(endDateDateTimePicker.Value.CompareTo(version.getDtEnd()) > 0)){
		MessageBox.Show("The end date has to be in the version's range","Error");
		return false;
	}

/*	if (!DateUtil.isValidTimeHMS(timeStartTextBox.Text)) {
		MessageBox.Show("Please, check the start time format","Error");
		return false;
	}
*/
	if ((positionText.Text == null) || (positionText.Text.Equals("")))
	{
		MessageBox.Show("Please, fill all the fields in the form ","Error");
		return false;
	}

	if ((getMachine() == null) || (getMachine().Equals(""))){
		MessageBox.Show("Please, fill all the fields in the form ","Error");
		return false;
	}

	if ((getSeq() == null) || (getSeq().Equals(""))){
		MessageBox.Show("Please, fill all the fields in the form ","Error");
		return false;
	}

	if ((getPart() == null) || (getPart().Equals(""))){
		MessageBox.Show("Please, fill all the fields in the form ","Error");
		return false;
	}

	return true;
}

private 
void allMachinesButton_Click(object sender, System.EventArgs e){
	machineComboBox.Items.Clear();

	string[] machines = core.getMachineCodesByPlt(plant);
	for(int i = 0; i < machines.Length; i++){
		machineComboBox.Items.Add(machines[i]);
	}
}

} // class

} // namespace
