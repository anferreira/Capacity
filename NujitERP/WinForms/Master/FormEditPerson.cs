using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.WinForms.SearchForms;

using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.Master{
	
public 
class FormEditPerson : System.Windows.Forms.Form{
private System.Windows.Forms.Label label1;
private System.Windows.Forms.Label label2;
private System.Windows.Forms.Label label3;
private System.Windows.Forms.Label label6;
private System.Windows.Forms.Label label7;
private System.Windows.Forms.Label label8;
private System.Windows.Forms.Label label9;
private System.Windows.Forms.Label label10;
private System.Windows.Forms.Label label11;
private System.Windows.Forms.Label label12;
private System.Windows.Forms.Label label13;
private System.Windows.Forms.Label label14;
private System.Windows.Forms.Label label15;
private System.Windows.Forms.Label label16;
private System.Windows.Forms.Label label17;
private System.Windows.Forms.GroupBox groupBox2;
private System.Windows.Forms.GroupBox groupBox3;
private System.Windows.Forms.Label label18;
private System.Windows.Forms.GroupBox groupBox4;
private System.Windows.Forms.TextBox address1TextBox;
private System.Windows.Forms.TextBox address2TextBox;
private System.Windows.Forms.TextBox address3TextBox;
private System.Windows.Forms.TextBox phoneTextBox;
private System.Windows.Forms.TextBox faxTextBox;
private System.Windows.Forms.TextBox webPageTextBox;
private System.Windows.Forms.TextBox countryTextBox;
private System.Windows.Forms.TextBox stateTextBox;
private System.Windows.Forms.TextBox territoryTextBox;
private System.Windows.Forms.GroupBox groupBox1;
private System.Windows.Forms.TextBox nameTextBox;
private System.Windows.Forms.TextBox classTextBox;
private System.Windows.Forms.TextBox currencyTextBox;
private System.Windows.Forms.TextBox cusTypeTextBox;
private System.Windows.Forms.GroupBox groupBox5;
private System.Windows.Forms.TextBox plantTextBox;
private System.Windows.Forms.TextBox idTextBox;
private System.Windows.Forms.Button searchPlantButton;
private System.Windows.Forms.TextBox plantDescTextBox;

private System.ComponentModel.Container components = null;
private System.Windows.Forms.Button saveButton;
private System.Windows.Forms.Button cancelButton;
private System.Windows.Forms.Button deleteButton;

private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private System.Windows.Forms.Button searchPersonButton;
private System.Windows.Forms.CheckBox customerCheckBox;
private System.Windows.Forms.CheckBox vendorCheckBox;
private System.Windows.Forms.CheckBox activeCheckBox;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.Label label5;
	private System.Windows.Forms.TextBox zipCodeTextBox;
	private System.Windows.Forms.TextBox billToCustTextBox;
	private System.Windows.Forms.Button searchBillToButton;
	private System.Windows.Forms.Label label19;
	private System.Windows.Forms.TextBox billToNameTextBox;
private Person person = null;


public 
FormEditPerson(){
	//
	// Required for Windows Form Designer support
	//
	InitializeComponent();

	//
	// TODO: Add any constructor code after InitializeComponent call
	//
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
	this.saveButton = new System.Windows.Forms.Button();
	this.cancelButton = new System.Windows.Forms.Button();
	this.deleteButton = new System.Windows.Forms.Button();
	this.label1 = new System.Windows.Forms.Label();
	this.label2 = new System.Windows.Forms.Label();
	this.label3 = new System.Windows.Forms.Label();
	this.label6 = new System.Windows.Forms.Label();
	this.label7 = new System.Windows.Forms.Label();
	this.label8 = new System.Windows.Forms.Label();
	this.label9 = new System.Windows.Forms.Label();
	this.label10 = new System.Windows.Forms.Label();
	this.label11 = new System.Windows.Forms.Label();
	this.label12 = new System.Windows.Forms.Label();
	this.label13 = new System.Windows.Forms.Label();
	this.label14 = new System.Windows.Forms.Label();
	this.label15 = new System.Windows.Forms.Label();
	this.label16 = new System.Windows.Forms.Label();
	this.label17 = new System.Windows.Forms.Label();
	this.groupBox2 = new System.Windows.Forms.GroupBox();
	this.searchPersonButton = new System.Windows.Forms.Button();
	this.plantDescTextBox = new System.Windows.Forms.TextBox();
	this.searchPlantButton = new System.Windows.Forms.Button();
	this.idTextBox = new System.Windows.Forms.TextBox();
	this.plantTextBox = new System.Windows.Forms.TextBox();
	this.groupBox3 = new System.Windows.Forms.GroupBox();
	this.billToNameTextBox = new System.Windows.Forms.TextBox();
	this.label19 = new System.Windows.Forms.Label();
	this.billToCustTextBox = new System.Windows.Forms.TextBox();
	this.zipCodeTextBox = new System.Windows.Forms.TextBox();
	this.label5 = new System.Windows.Forms.Label();
	this.label4 = new System.Windows.Forms.Label();
	this.territoryTextBox = new System.Windows.Forms.TextBox();
	this.stateTextBox = new System.Windows.Forms.TextBox();
	this.countryTextBox = new System.Windows.Forms.TextBox();
	this.webPageTextBox = new System.Windows.Forms.TextBox();
	this.faxTextBox = new System.Windows.Forms.TextBox();
	this.phoneTextBox = new System.Windows.Forms.TextBox();
	this.address3TextBox = new System.Windows.Forms.TextBox();
	this.address2TextBox = new System.Windows.Forms.TextBox();
	this.address1TextBox = new System.Windows.Forms.TextBox();
	this.label18 = new System.Windows.Forms.Label();
	this.searchBillToButton = new System.Windows.Forms.Button();
	this.groupBox4 = new System.Windows.Forms.GroupBox();
	this.groupBox1 = new System.Windows.Forms.GroupBox();
	this.groupBox5 = new System.Windows.Forms.GroupBox();
	this.customerCheckBox = new System.Windows.Forms.CheckBox();
	this.vendorCheckBox = new System.Windows.Forms.CheckBox();
	this.cusTypeTextBox = new System.Windows.Forms.TextBox();
	this.currencyTextBox = new System.Windows.Forms.TextBox();
	this.classTextBox = new System.Windows.Forms.TextBox();
	this.nameTextBox = new System.Windows.Forms.TextBox();
	this.activeCheckBox = new System.Windows.Forms.CheckBox();
	this.groupBox2.SuspendLayout();
	this.groupBox3.SuspendLayout();
	this.groupBox4.SuspendLayout();
	this.groupBox1.SuspendLayout();
	this.groupBox5.SuspendLayout();
	this.SuspendLayout();
	// 
	// saveButton
	// 
	this.saveButton.Location = new System.Drawing.Point(240, 16);
	this.saveButton.Name = "saveButton";
	this.saveButton.TabIndex = 24;
	this.saveButton.Text = "Save";
	this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
	// 
	// cancelButton
	// 
	this.cancelButton.Location = new System.Drawing.Point(320, 16);
	this.cancelButton.Name = "cancelButton";
	this.cancelButton.TabIndex = 25;
	this.cancelButton.Text = "Cancel";
	this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
	// 
	// deleteButton
	// 
	this.deleteButton.Location = new System.Drawing.Point(400, 16);
	this.deleteButton.Name = "deleteButton";
	this.deleteButton.TabIndex = 26;
	this.deleteButton.Text = "Delete";
	this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
	// 
	// label1
	// 
	this.label1.Location = new System.Drawing.Point(24, 48);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(40, 16);
	this.label1.TabIndex = 1;
	this.label1.Text = "Plant";
	// 
	// label2
	// 
	this.label2.Location = new System.Drawing.Point(24, 24);
	this.label2.Name = "label2";
	this.label2.Size = new System.Drawing.Size(40, 16);
	this.label2.TabIndex = 2;
	this.label2.Text = "Code";
	// 
	// label3
	// 
	this.label3.Location = new System.Drawing.Point(24, 88);
	this.label3.Name = "label3";
	this.label3.Size = new System.Drawing.Size(60, 16);
	this.label3.TabIndex = 3;
	this.label3.Text = "Cus Type";
	// 
	// label6
	// 
	this.label6.Location = new System.Drawing.Point(24, 32);
	this.label6.Name = "label6";
	this.label6.Size = new System.Drawing.Size(60, 16);
	this.label6.TabIndex = 6;
	this.label6.Text = "Name";
	// 
	// label7
	// 
	this.label7.Location = new System.Drawing.Point(96, 48);
	this.label7.Name = "label7";
	this.label7.Size = new System.Drawing.Size(24, 20);
	this.label7.TabIndex = 7;
	this.label7.Text = "2 : ";
	// 
	// label8
	// 
	this.label8.Location = new System.Drawing.Point(96, 24);
	this.label8.Name = "label8";
	this.label8.Size = new System.Drawing.Size(24, 20);
	this.label8.TabIndex = 8;
	this.label8.Text = "1 :";
	// 
	// label9
	// 
	this.label9.Location = new System.Drawing.Point(96, 72);
	this.label9.Name = "label9";
	this.label9.Size = new System.Drawing.Size(24, 20);
	this.label9.TabIndex = 9;
	this.label9.Text = "3 : ";
	// 
	// label10
	// 
	this.label10.Location = new System.Drawing.Point(16, 100);
	this.label10.Name = "label10";
	this.label10.Size = new System.Drawing.Size(56, 16);
	this.label10.TabIndex = 10;
	this.label10.Text = "Phone";
	this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label11
	// 
	this.label11.Location = new System.Drawing.Point(16, 120);
	this.label11.Name = "label11";
	this.label11.Size = new System.Drawing.Size(56, 16);
	this.label11.TabIndex = 11;
	this.label11.Text = "Fax";
	this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label12
	// 
	this.label12.Location = new System.Drawing.Point(256, 120);
	this.label12.Name = "label12";
	this.label12.Size = new System.Drawing.Size(64, 16);
	this.label12.TabIndex = 12;
	this.label12.Text = "Web Page";
	// 
	// label13
	// 
	this.label13.Location = new System.Drawing.Point(16, 140);
	this.label13.Name = "label13";
	this.label13.Size = new System.Drawing.Size(48, 16);
	this.label13.TabIndex = 13;
	this.label13.Text = "Country";
	this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label14
	// 
	this.label14.Location = new System.Drawing.Point(16, 160);
	this.label14.Name = "label14";
	this.label14.Size = new System.Drawing.Size(64, 16);
	this.label14.TabIndex = 14;
	this.label14.Text = "State Prov";
	this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label15
	// 
	this.label15.Location = new System.Drawing.Point(24, 67);
	this.label15.Name = "label15";
	this.label15.Size = new System.Drawing.Size(60, 16);
	this.label15.TabIndex = 15;
	this.label15.Text = "Currency";
	// 
	// label16
	// 
	this.label16.Location = new System.Drawing.Point(16, 180);
	this.label16.Name = "label16";
	this.label16.Size = new System.Drawing.Size(56, 16);
	this.label16.TabIndex = 16;
	this.label16.Text = "Territory";
	this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label17
	// 
	this.label17.Location = new System.Drawing.Point(24, 48);
	this.label17.Name = "label17";
	this.label17.Size = new System.Drawing.Size(60, 16);
	this.label17.TabIndex = 17;
	this.label17.Text = "Class";
	// 
	// groupBox2
	// 
	this.groupBox2.Controls.Add(this.searchPersonButton);
	this.groupBox2.Controls.Add(this.plantDescTextBox);
	this.groupBox2.Controls.Add(this.searchPlantButton);
	this.groupBox2.Controls.Add(this.idTextBox);
	this.groupBox2.Controls.Add(this.plantTextBox);
	this.groupBox2.Controls.Add(this.label1);
	this.groupBox2.Controls.Add(this.label2);
	this.groupBox2.Location = new System.Drawing.Point(8, 8);
	this.groupBox2.Name = "groupBox2";
	this.groupBox2.Size = new System.Drawing.Size(504, 80);
	this.groupBox2.TabIndex = 3;
	this.groupBox2.TabStop = false;
	// 
	// searchPersonButton
	// 
	this.searchPersonButton.Location = new System.Drawing.Point(200, 28);
	this.searchPersonButton.Name = "searchPersonButton";
	this.searchPersonButton.Size = new System.Drawing.Size(25, 15);
	this.searchPersonButton.TabIndex = 4;
	this.searchPersonButton.Text = "...";
	this.searchPersonButton.Click += new System.EventHandler(this.searchPersonButton_Click);
	// 
	// plantDescTextBox
	// 
	this.plantDescTextBox.Location = new System.Drawing.Point(232, 48);
	this.plantDescTextBox.Name = "plantDescTextBox";
	this.plantDescTextBox.ReadOnly = true;
	this.plantDescTextBox.Size = new System.Drawing.Size(224, 20);
	this.plantDescTextBox.TabIndex = 100;
	this.plantDescTextBox.TabStop = false;
	this.plantDescTextBox.Text = "";
	// 
	// searchPlantButton
	// 
	this.searchPlantButton.Location = new System.Drawing.Point(200, 52);
	this.searchPlantButton.Name = "searchPlantButton";
	this.searchPlantButton.Size = new System.Drawing.Size(25, 15);
	this.searchPlantButton.TabIndex = 6;
	this.searchPlantButton.Text = "...";
	this.searchPlantButton.Click += new System.EventHandler(this.searchPlantButton_Click);
	// 
	// idTextBox
	// 
	this.idTextBox.Location = new System.Drawing.Point(96, 24);
	this.idTextBox.Name = "idTextBox";
	this.idTextBox.TabIndex = 3;
	this.idTextBox.Text = "";
	this.idTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.idTextBox_KeyDown);
	this.idTextBox.Leave += new System.EventHandler(this.idTextBox_Leave);
	// 
	// plantTextBox
	// 
	this.plantTextBox.Location = new System.Drawing.Point(96, 48);
	this.plantTextBox.Name = "plantTextBox";
	this.plantTextBox.TabIndex = 5;
	this.plantTextBox.Text = "";
	this.plantTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.plantTextBox_KeyDown);
	this.plantTextBox.Leave += new System.EventHandler(this.plantTextBox_Leave);
	// 
	// groupBox3
	// 
	this.groupBox3.Controls.Add(this.billToNameTextBox);
	this.groupBox3.Controls.Add(this.label19);
	this.groupBox3.Controls.Add(this.billToCustTextBox);
	this.groupBox3.Controls.Add(this.zipCodeTextBox);
	this.groupBox3.Controls.Add(this.label5);
	this.groupBox3.Controls.Add(this.label4);
	this.groupBox3.Controls.Add(this.territoryTextBox);
	this.groupBox3.Controls.Add(this.stateTextBox);
	this.groupBox3.Controls.Add(this.countryTextBox);
	this.groupBox3.Controls.Add(this.webPageTextBox);
	this.groupBox3.Controls.Add(this.faxTextBox);
	this.groupBox3.Controls.Add(this.phoneTextBox);
	this.groupBox3.Controls.Add(this.address3TextBox);
	this.groupBox3.Controls.Add(this.address2TextBox);
	this.groupBox3.Controls.Add(this.address1TextBox);
	this.groupBox3.Controls.Add(this.label18);
	this.groupBox3.Controls.Add(this.label10);
	this.groupBox3.Controls.Add(this.label11);
	this.groupBox3.Controls.Add(this.label8);
	this.groupBox3.Controls.Add(this.label7);
	this.groupBox3.Controls.Add(this.label9);
	this.groupBox3.Controls.Add(this.label13);
	this.groupBox3.Controls.Add(this.label14);
	this.groupBox3.Controls.Add(this.label16);
	this.groupBox3.Controls.Add(this.label12);
	this.groupBox3.Controls.Add(this.searchBillToButton);
	this.groupBox3.Location = new System.Drawing.Point(8, 224);
	this.groupBox3.Name = "groupBox3";
	this.groupBox3.Size = new System.Drawing.Size(504, 232);
	this.groupBox3.TabIndex = 14;
	this.groupBox3.TabStop = false;
	// 
	// billToNameTextBox
	// 
	this.billToNameTextBox.Location = new System.Drawing.Point(336, 192);
	this.billToNameTextBox.Name = "billToNameTextBox";
	this.billToNameTextBox.ReadOnly = true;
	this.billToNameTextBox.Size = new System.Drawing.Size(152, 20);
	this.billToNameTextBox.TabIndex = 103;
	this.billToNameTextBox.Text = "";
	// 
	// label19
	// 
	this.label19.Location = new System.Drawing.Point(256, 194);
	this.label19.Name = "label19";
	this.label19.Size = new System.Drawing.Size(72, 16);
	this.label19.TabIndex = 102;
	this.label19.Text = "Bill To Name";
	this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// billToCustTextBox
	// 
	this.billToCustTextBox.Location = new System.Drawing.Point(336, 168);
	this.billToCustTextBox.Name = "billToCustTextBox";
	this.billToCustTextBox.Size = new System.Drawing.Size(112, 20);
	this.billToCustTextBox.TabIndex = 27;
	this.billToCustTextBox.Text = "";
	// 
	// zipCodeTextBox
	// 
	this.zipCodeTextBox.Location = new System.Drawing.Point(88, 196);
	this.zipCodeTextBox.MaxLength = 20;
	this.zipCodeTextBox.Name = "zipCodeTextBox";
	this.zipCodeTextBox.Size = new System.Drawing.Size(56, 20);
	this.zipCodeTextBox.TabIndex = 26;
	this.zipCodeTextBox.Text = "";
	// 
	// label5
	// 
	this.label5.Location = new System.Drawing.Point(16, 200);
	this.label5.Name = "label5";
	this.label5.Size = new System.Drawing.Size(56, 16);
	this.label5.TabIndex = 25;
	this.label5.Text = "ZipCode";
	this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label4
	// 
	this.label4.Location = new System.Drawing.Point(256, 170);
	this.label4.Name = "label4";
	this.label4.Size = new System.Drawing.Size(72, 16);
	this.label4.TabIndex = 24;
	this.label4.Text = "Bill To Cust.";
	this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// territoryTextBox
	// 
	this.territoryTextBox.Location = new System.Drawing.Point(88, 176);
	this.territoryTextBox.Name = "territoryTextBox";
	this.territoryTextBox.Size = new System.Drawing.Size(56, 20);
	this.territoryTextBox.TabIndex = 22;
	this.territoryTextBox.Text = "";
	// 
	// stateTextBox
	// 
	this.stateTextBox.Location = new System.Drawing.Point(88, 156);
	this.stateTextBox.Name = "stateTextBox";
	this.stateTextBox.Size = new System.Drawing.Size(56, 20);
	this.stateTextBox.TabIndex = 21;
	this.stateTextBox.Text = "";
	// 
	// countryTextBox
	// 
	this.countryTextBox.Location = new System.Drawing.Point(88, 136);
	this.countryTextBox.Name = "countryTextBox";
	this.countryTextBox.Size = new System.Drawing.Size(56, 20);
	this.countryTextBox.TabIndex = 20;
	this.countryTextBox.Text = "";
	// 
	// webPageTextBox
	// 
	this.webPageTextBox.Location = new System.Drawing.Point(336, 116);
	this.webPageTextBox.Name = "webPageTextBox";
	this.webPageTextBox.Size = new System.Drawing.Size(152, 20);
	this.webPageTextBox.TabIndex = 23;
	this.webPageTextBox.Text = "";
	// 
	// faxTextBox
	// 
	this.faxTextBox.Location = new System.Drawing.Point(88, 116);
	this.faxTextBox.Name = "faxTextBox";
	this.faxTextBox.Size = new System.Drawing.Size(152, 20);
	this.faxTextBox.TabIndex = 19;
	this.faxTextBox.Text = "";
	// 
	// phoneTextBox
	// 
	this.phoneTextBox.Location = new System.Drawing.Point(88, 96);
	this.phoneTextBox.Name = "phoneTextBox";
	this.phoneTextBox.Size = new System.Drawing.Size(152, 20);
	this.phoneTextBox.TabIndex = 18;
	this.phoneTextBox.Text = "";
	// 
	// address3TextBox
	// 
	this.address3TextBox.Location = new System.Drawing.Point(128, 64);
	this.address3TextBox.Name = "address3TextBox";
	this.address3TextBox.Size = new System.Drawing.Size(312, 20);
	this.address3TextBox.TabIndex = 17;
	this.address3TextBox.Text = "";
	// 
	// address2TextBox
	// 
	this.address2TextBox.Location = new System.Drawing.Point(128, 44);
	this.address2TextBox.Name = "address2TextBox";
	this.address2TextBox.Size = new System.Drawing.Size(312, 20);
	this.address2TextBox.TabIndex = 15;
	this.address2TextBox.Text = "";
	// 
	// address1TextBox
	// 
	this.address1TextBox.Location = new System.Drawing.Point(128, 24);
	this.address1TextBox.Name = "address1TextBox";
	this.address1TextBox.Size = new System.Drawing.Size(312, 20);
	this.address1TextBox.TabIndex = 14;
	this.address1TextBox.Text = "";
	// 
	// label18
	// 
	this.label18.Location = new System.Drawing.Point(16, 24);
	this.label18.Name = "label18";
	this.label18.Size = new System.Drawing.Size(48, 16);
	this.label18.TabIndex = 15;
	this.label18.Text = "Address";
	// 
	// searchBillToButton
	// 
	this.searchBillToButton.Location = new System.Drawing.Point(456, 168);
	this.searchBillToButton.Name = "searchBillToButton";
	this.searchBillToButton.Size = new System.Drawing.Size(25, 15);
	this.searchBillToButton.TabIndex = 101;
	this.searchBillToButton.Text = "...";
	this.searchBillToButton.Click += new System.EventHandler(this.searchBillToButton_Click);
	// 
	// groupBox4
	// 
	this.groupBox4.Controls.Add(this.saveButton);
	this.groupBox4.Controls.Add(this.cancelButton);
	this.groupBox4.Controls.Add(this.deleteButton);
	this.groupBox4.Location = new System.Drawing.Point(8, 464);
	this.groupBox4.Name = "groupBox4";
	this.groupBox4.Size = new System.Drawing.Size(504, 48);
	this.groupBox4.TabIndex = 24;
	this.groupBox4.TabStop = false;
	// 
	// groupBox1
	// 
	this.groupBox1.Controls.Add(this.groupBox5);
	this.groupBox1.Controls.Add(this.cusTypeTextBox);
	this.groupBox1.Controls.Add(this.currencyTextBox);
	this.groupBox1.Controls.Add(this.classTextBox);
	this.groupBox1.Controls.Add(this.nameTextBox);
	this.groupBox1.Controls.Add(this.activeCheckBox);
	this.groupBox1.Controls.Add(this.label6);
	this.groupBox1.Controls.Add(this.label17);
	this.groupBox1.Controls.Add(this.label15);
	this.groupBox1.Controls.Add(this.label3);
	this.groupBox1.Location = new System.Drawing.Point(8, 88);
	this.groupBox1.Name = "groupBox1";
	this.groupBox1.Size = new System.Drawing.Size(504, 136);
	this.groupBox1.TabIndex = 7;
	this.groupBox1.TabStop = false;
	// 
	// groupBox5
	// 
	this.groupBox5.Controls.Add(this.customerCheckBox);
	this.groupBox5.Controls.Add(this.vendorCheckBox);
	this.groupBox5.Location = new System.Drawing.Point(336, 48);
	this.groupBox5.Name = "groupBox5";
	this.groupBox5.Size = new System.Drawing.Size(112, 72);
	this.groupBox5.TabIndex = 25;
	this.groupBox5.TabStop = false;
	this.groupBox5.Text = "Type";
	// 
	// customerCheckBox
	// 
	this.customerCheckBox.Location = new System.Drawing.Point(16, 24);
	this.customerCheckBox.Name = "customerCheckBox";
	this.customerCheckBox.Size = new System.Drawing.Size(72, 16);
	this.customerCheckBox.TabIndex = 12;
	this.customerCheckBox.Text = "Customer";
	// 
	// vendorCheckBox
	// 
	this.vendorCheckBox.Location = new System.Drawing.Point(16, 40);
	this.vendorCheckBox.Name = "vendorCheckBox";
	this.vendorCheckBox.Size = new System.Drawing.Size(64, 16);
	this.vendorCheckBox.TabIndex = 13;
	this.vendorCheckBox.Text = "Vendor";
	// 
	// cusTypeTextBox
	// 
	this.cusTypeTextBox.Location = new System.Drawing.Point(90, 87);
	this.cusTypeTextBox.MaxLength = 1;
	this.cusTypeTextBox.Name = "cusTypeTextBox";
	this.cusTypeTextBox.TabIndex = 10;
	this.cusTypeTextBox.Text = "";
	// 
	// currencyTextBox
	// 
	this.currencyTextBox.Location = new System.Drawing.Point(90, 66);
	this.currencyTextBox.Name = "currencyTextBox";
	this.currencyTextBox.TabIndex = 9;
	this.currencyTextBox.Text = "";
	// 
	// classTextBox
	// 
	this.classTextBox.Location = new System.Drawing.Point(90, 45);
	this.classTextBox.Name = "classTextBox";
	this.classTextBox.TabIndex = 8;
	this.classTextBox.Text = "";
	// 
	// nameTextBox
	// 
	this.nameTextBox.Location = new System.Drawing.Point(90, 24);
	this.nameTextBox.Name = "nameTextBox";
	this.nameTextBox.Size = new System.Drawing.Size(230, 20);
	this.nameTextBox.TabIndex = 7;
	this.nameTextBox.Text = "";
	// 
	// activeCheckBox
	// 
	this.activeCheckBox.Location = new System.Drawing.Point(352, 24);
	this.activeCheckBox.Name = "activeCheckBox";
	this.activeCheckBox.Size = new System.Drawing.Size(72, 16);
	this.activeCheckBox.TabIndex = 11;
	this.activeCheckBox.Text = "Active";
	// 
	// FormEditPerson
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(520, 525);
	this.Controls.Add(this.groupBox1);
	this.Controls.Add(this.groupBox4);
	this.Controls.Add(this.groupBox3);
	this.Controls.Add(this.groupBox2);
	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
	this.MaximizeBox = false;
	this.Name = "FormEditPerson";
	this.Text = " Edit Person";
	this.groupBox2.ResumeLayout(false);
	this.groupBox3.ResumeLayout(false);
	this.groupBox4.ResumeLayout(false);
	this.groupBox1.ResumeLayout(false);
	this.groupBox5.ResumeLayout(false);
	this.ResumeLayout(false);

}
#endregion

private
void screenToObject(){
	person.setPlt(plantTextBox.Text);
	person.setId(idTextBox.Text);
	person.setCustomerType(cusTypeTextBox.Text);

	if ((customerCheckBox.Checked) && (vendorCheckBox.Checked)){
		person.setRecType("A");
	}else{
		if (customerCheckBox.Checked){
			person.setRecType(Constants.PERSON_TYPE_CUSTOMER);
		}else{
			if (vendorCheckBox.Checked){
				person.setRecType(Constants.PERSON_TYPE_VENDOR);
			}
		}
	}
	
	if (activeCheckBox.Checked)
		person.setStatus("A");
	else
		person.setStatus("I");
	
	person.setName(nameTextBox.Text);
	person.setAddress1(address1TextBox.Text);
	person.setAddress2(address2TextBox.Text);
	person.setAddress3(address3TextBox.Text);
	person.setPhone(phoneTextBox.Text);
	person.setFax(faxTextBox.Text);
	person.setWebPage(webPageTextBox.Text);
	person.setCountry(countryTextBox.Text);
	person.setState_Prov(stateTextBox.Text);
	person.setCurrency(currencyTextBox.Text);
	person.setTerritory(territoryTextBox.Text);
	person.setPersonClass(classTextBox.Text);
	person.setBillToCust(billToCustTextBox.Text);
	person.setZipCode(zipCodeTextBox.Text);
}

private
void objectToScreen(){
	plantTextBox.Text = person.getPlt();
	idTextBox.Text = person.getId();
	cusTypeTextBox.Text = person.getCustomerType();

	if (person.getRecType().Equals(Constants.PERSON_TYPE_CUSTOMER)){
		customerCheckBox.Checked = true;
	}else{
		if (person.getRecType().Equals(Constants.PERSON_TYPE_VENDOR)){
			vendorCheckBox.Checked = true;
		}else{
			customerCheckBox.Checked = true;
			vendorCheckBox.Checked = true;
		}
	}

	activeCheckBox.Checked = false;
	if (person.getStatus().Equals("A"))
		activeCheckBox.Checked = true;
	
	nameTextBox.Text = person.getName();
	address1TextBox.Text = person.getAddress1();
	address2TextBox.Text = person.getAddress2();
	address3TextBox.Text = person.getAddress3();
	phoneTextBox.Text = person.getPhone();
	faxTextBox.Text = person.getFax();
	webPageTextBox.Text = person.getWebPage();
	countryTextBox.Text = person.getCountry();
	stateTextBox.Text = person.getState_Prov();
	currencyTextBox.Text = person.getCurrency();
	territoryTextBox.Text = person.getTerritory();
	classTextBox.Text = person.getPersonClass();
	billToCustTextBox.Text = person.getBillToCust();
	zipCodeTextBox.Text = person.getZipCode();
}

private 
void saveButton_Click(object sender, System.EventArgs e){
	try{
		if (!dataOk())
			return;

		if (person == null){
			person = new Person();
			screenToObject();

			person.setDateCreated(DateTime.Now);
			person.setDateUpdated(DateTime.Now);
			
			coreFactory.writePerson(person);
		}else{
			screenToObject();

			person.setDateUpdated(DateTime.Now);
			
			coreFactory.updatePerson(person);
		}

		Close();
	}catch(Exception exc){
		MessageBox.Show("Error : " + exc.Message);
	}
}

private 
void searchPlantButton_Click(object sender, System.EventArgs e){
	PlantSearchForm plantSearchForm = new PlantSearchForm("Plants ...");
	plantSearchForm.ShowDialog();
	
	if ((plantSearchForm.DialogResult == DialogResult.OK) &&
			(plantSearchForm.getSelected() != null)){
		string[] v = plantSearchForm.getSelected();

		plantTextBox.Text = v[0];
		plantDescTextBox.Text = v[1];

		nameTextBox.Focus();
	}
}

private 
void searchPersonButton_Click(object sender, System.EventArgs e){
	PersonSearchForm personSearchForm = new PersonSearchForm("Persons ...");
	personSearchForm.ShowDialog();
	
	if ((personSearchForm.DialogResult == DialogResult.OK) &&
			(personSearchForm.getSelected() != null)){
		string[] v = personSearchForm.getSelected();

		string plant = v[0];
		string id = v[1];

		person = coreFactory.readPerson(plant, id);
		objectToScreen();
	}
}

private 
void cancelButton_Click(object sender, System.EventArgs e){
	Close();
}

private
bool dataOk(){
	if ((plantTextBox.Text == null) || (plantTextBox.Text.Equals("")))
		return false;
	if ((idTextBox.Text == null) || (idTextBox.Text.Equals("")))
		return false;

	return true;
}

private 
void deleteButton_Click(object sender, System.EventArgs e){
	try{
		if (!dataOk())
			return;

		DialogResult deleteConfirm = MessageBox.Show("Delete this person ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (deleteConfirm == DialogResult.No)
			return;
		
		person = new Person();
		screenToObject();

		coreFactory.deletePerson(person.getPlt(), person.getId());

		Close();
	}catch(Exception exc){
		MessageBox.Show("Error : " + exc.Message);
	}
}

private
void focusLost(){
	if ((idTextBox.Text == null) || (idTextBox.Text.Equals("")))
		return;
	
	if ((plantTextBox.Text == null) || (plantTextBox.Text.Equals("")))
		return;

	try{
		if (coreFactory.existsPlant(plantTextBox.Text)){
			Plant plant = coreFactory.readPlant(plantTextBox.Text);
			plantDescTextBox.Text = plant.getName();
		}else{
			MessageBox.Show("Error, Plant : " + plantDescTextBox.Text + " does not exist");
			plantTextBox.Focus();
			return;
		}
		
		if (coreFactory.existsPerson(plantTextBox.Text, idTextBox.Text)){
			person = coreFactory.readPerson(plantTextBox.Text, idTextBox.Text);
			objectToScreen();

			nameTextBox.Focus();
		}
	}catch(Exception exc){
		MessageBox.Show(exc.Message);
	}
}

private 
void idTextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e){
	if (e.KeyCode.ToString().Equals("Enter"))
		focusLost();
}

private 
void plantTextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e){
	if (e.KeyCode.ToString().Equals("Enter"))
		focusLost();
}

private 
void idTextBox_Leave(object sender, System.EventArgs e){
	focusLost();
}

private 
void plantTextBox_Leave(object sender, System.EventArgs e){
	focusLost();
}

private void searchBillToButton_Click(object sender, System.EventArgs e)
{
	PersonSearchForm personSearchForm = new PersonSearchForm("Persons ...");
	personSearchForm.setFilters(Constants.PERSON_TYPE_CUSTOMER,person.getPlt());
	personSearchForm.ShowDialog();
	
	if ((personSearchForm.DialogResult == DialogResult.OK) &&
		(personSearchForm.getSelected() != null))
	{
		string[] v = personSearchForm.getSelected();

		billToCustTextBox.Text = v[1];
		billToNameTextBox.Text = v[2];
	}
}

} // class

} // namespace
