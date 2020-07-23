using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.WinForms.SearchForms;

using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Common;



namespace Nujit.NujitERP.WinForms.Contacts{

/// <summary>
/// Summary description for ContactsForm.
/// </summary>
public 
class ContactsForm : System.Windows.Forms.Form{

private System.Windows.Forms.TabControl tabControl1;
private System.Windows.Forms.TabPage tabPage1;
private System.Windows.Forms.Label label1;
private System.Windows.Forms.Label label2;
private System.Windows.Forms.Label label3;
private System.Windows.Forms.Label label4;
private System.Windows.Forms.Label label5;
private System.Windows.Forms.Label label6;
private System.Windows.Forms.Label label7;
private System.Windows.Forms.GroupBox groupBox1;
private System.Windows.Forms.Label label8;
private System.Windows.Forms.TextBox firstNameTextBox;
private System.Windows.Forms.TextBox secondtNameTextBox;
private System.Windows.Forms.TextBox lastNameTextBox;
private System.Windows.Forms.TextBox nickNameTextBox;
private System.Windows.Forms.TextBox titleTextBox;
private System.Windows.Forms.ComboBox displayNameComboBox;
private System.Windows.Forms.ListBox emailListBox;
private System.Windows.Forms.TextBox emailTextBox;
private System.Windows.Forms.TabPage tabPage2;
private System.Windows.Forms.TabPage tabPage3;
private System.Windows.Forms.TabPage tabPage4;
private System.Windows.Forms.TabPage tabPage5;
private System.Windows.Forms.Button addMailButton;
private System.Windows.Forms.Button updateMailButton;
private System.Windows.Forms.Button deleteMailButton;
private System.Windows.Forms.Button saveButton;
private System.Windows.Forms.Button cancelButton;
private System.Windows.Forms.Label label9;
private System.Windows.Forms.TextBox phoneTextBox;
private System.Windows.Forms.Label label10;
private System.Windows.Forms.TextBox faxTextBox;
private System.Windows.Forms.Label label11;
private System.Windows.Forms.TextBox mobileTextBox;
private System.Windows.Forms.Label label12;
private System.Windows.Forms.TextBox cityTextBox;
private System.Windows.Forms.Label label13;
private System.Windows.Forms.TextBox stateTextBox;
private System.Windows.Forms.Label label14;
private System.Windows.Forms.TextBox countryTextBox;
private System.Windows.Forms.Label label15;
private System.Windows.Forms.TextBox zipCodeTextBox;
private System.Windows.Forms.Label label16;
private System.Windows.Forms.Label label17;
private System.Windows.Forms.Label label18;
private System.Windows.Forms.Label label19;
private System.Windows.Forms.Label label20;
private System.Windows.Forms.Label label21;
private System.Windows.Forms.Label label22;
private System.Windows.Forms.Label label23;
private System.Windows.Forms.Label label24;
private System.Windows.Forms.Label label25;
private System.Windows.Forms.Label label26;
private System.Windows.Forms.Label label27;
private System.Windows.Forms.Label label28;
private System.Windows.Forms.Label label29;
private System.Windows.Forms.Label label30;
private System.Windows.Forms.Label label31;
private System.Windows.Forms.Button button1;
private System.Windows.Forms.Button button2;
private System.Windows.Forms.Button button3;
private System.Windows.Forms.TextBox organizationTextBox;
private System.Windows.Forms.TextBox cityOrgTextBox;
private System.Windows.Forms.TextBox stateOrgTextBox;
private System.Windows.Forms.TextBox departamentTextBox;
private System.Windows.Forms.TextBox positionTextBox;
private System.Windows.Forms.TextBox addressOrgTextBox;
private System.Windows.Forms.TextBox officeTextBox;
private System.Windows.Forms.TextBox zipCodeOrgTextBox;
private System.Windows.Forms.TextBox countryOrgTextBox;
private System.Windows.Forms.TextBox ipPhoneOrgTextBox;
private System.Windows.Forms.TextBox locOrgTextBox;
private System.Windows.Forms.TextBox phoneOrgTextBox;
private System.Windows.Forms.RichTextBox notesRichTextBox;
private System.Windows.Forms.TextBox conyugeTextBox;
private System.Windows.Forms.ListBox sonsListBox;
private System.Windows.Forms.Label label32;
private System.Windows.Forms.Label label33;
private System.Windows.Forms.DateTimePicker anniversaryTimePicker;
private System.Windows.Forms.DateTimePicker birthdayTimePicker;
private System.Windows.Forms.TextBox addressTextBox;
/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;
	private System.Windows.Forms.TextBox faxOrgTextBox;
	private System.Windows.Forms.Label label34;
private Contact contact;
	private System.Windows.Forms.Button seekButton;
	private System.Windows.Forms.PictureBox pictureBox;
	private System.Windows.Forms.RadioButton femaleRadioButton;
	private System.Windows.Forms.RadioButton maleRadioButton;
	private System.Windows.Forms.TextBox sonTextBox;
	private System.Windows.Forms.Button deleteButton;
private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();


public 
ContactsForm(){
	InitializeComponent();

	// TODO: Add any constructor code after InitializeComponent call
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
    System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ContactsForm));
    this.tabControl1 = new System.Windows.Forms.TabControl();
    this.tabPage1 = new System.Windows.Forms.TabPage();
    this.seekButton = new System.Windows.Forms.Button();
    this.label8 = new System.Windows.Forms.Label();
    this.pictureBox = new System.Windows.Forms.PictureBox();
    this.groupBox1 = new System.Windows.Forms.GroupBox();
    this.deleteMailButton = new System.Windows.Forms.Button();
    this.updateMailButton = new System.Windows.Forms.Button();
    this.addMailButton = new System.Windows.Forms.Button();
    this.emailTextBox = new System.Windows.Forms.TextBox();
    this.emailListBox = new System.Windows.Forms.ListBox();
    this.label7 = new System.Windows.Forms.Label();
    this.displayNameComboBox = new System.Windows.Forms.ComboBox();
    this.titleTextBox = new System.Windows.Forms.TextBox();
    this.nickNameTextBox = new System.Windows.Forms.TextBox();
    this.lastNameTextBox = new System.Windows.Forms.TextBox();
    this.secondtNameTextBox = new System.Windows.Forms.TextBox();
    this.firstNameTextBox = new System.Windows.Forms.TextBox();
    this.label6 = new System.Windows.Forms.Label();
    this.label5 = new System.Windows.Forms.Label();
    this.label4 = new System.Windows.Forms.Label();
    this.label3 = new System.Windows.Forms.Label();
    this.label2 = new System.Windows.Forms.Label();
    this.label1 = new System.Windows.Forms.Label();
    this.tabPage2 = new System.Windows.Forms.TabPage();
    this.addressTextBox = new System.Windows.Forms.TextBox();
    this.zipCodeTextBox = new System.Windows.Forms.TextBox();
    this.label16 = new System.Windows.Forms.Label();
    this.countryTextBox = new System.Windows.Forms.TextBox();
    this.label15 = new System.Windows.Forms.Label();
    this.stateTextBox = new System.Windows.Forms.TextBox();
    this.label14 = new System.Windows.Forms.Label();
    this.cityTextBox = new System.Windows.Forms.TextBox();
    this.label13 = new System.Windows.Forms.Label();
    this.mobileTextBox = new System.Windows.Forms.TextBox();
    this.label12 = new System.Windows.Forms.Label();
    this.faxTextBox = new System.Windows.Forms.TextBox();
    this.label11 = new System.Windows.Forms.Label();
    this.phoneTextBox = new System.Windows.Forms.TextBox();
    this.label10 = new System.Windows.Forms.Label();
    this.label9 = new System.Windows.Forms.Label();
    this.tabPage3 = new System.Windows.Forms.TabPage();
    this.label34 = new System.Windows.Forms.Label();
    this.faxOrgTextBox = new System.Windows.Forms.TextBox();
    this.ipPhoneOrgTextBox = new System.Windows.Forms.TextBox();
    this.label26 = new System.Windows.Forms.Label();
    this.locOrgTextBox = new System.Windows.Forms.TextBox();
    this.label27 = new System.Windows.Forms.Label();
    this.phoneOrgTextBox = new System.Windows.Forms.TextBox();
    this.label28 = new System.Windows.Forms.Label();
    this.countryOrgTextBox = new System.Windows.Forms.TextBox();
    this.label25 = new System.Windows.Forms.Label();
    this.zipCodeOrgTextBox = new System.Windows.Forms.TextBox();
    this.label24 = new System.Windows.Forms.Label();
    this.addressOrgTextBox = new System.Windows.Forms.TextBox();
    this.label22 = new System.Windows.Forms.Label();
    this.officeTextBox = new System.Windows.Forms.TextBox();
    this.label23 = new System.Windows.Forms.Label();
    this.departamentTextBox = new System.Windows.Forms.TextBox();
    this.label20 = new System.Windows.Forms.Label();
    this.positionTextBox = new System.Windows.Forms.TextBox();
    this.label21 = new System.Windows.Forms.Label();
    this.stateOrgTextBox = new System.Windows.Forms.TextBox();
    this.label19 = new System.Windows.Forms.Label();
    this.cityOrgTextBox = new System.Windows.Forms.TextBox();
    this.label18 = new System.Windows.Forms.Label();
    this.organizationTextBox = new System.Windows.Forms.TextBox();
    this.label17 = new System.Windows.Forms.Label();
    this.tabPage4 = new System.Windows.Forms.TabPage();
    this.sonTextBox = new System.Windows.Forms.TextBox();
    this.label33 = new System.Windows.Forms.Label();
    this.label32 = new System.Windows.Forms.Label();
    this.anniversaryTimePicker = new System.Windows.Forms.DateTimePicker();
    this.birthdayTimePicker = new System.Windows.Forms.DateTimePicker();
    this.button3 = new System.Windows.Forms.Button();
    this.button2 = new System.Windows.Forms.Button();
    this.femaleRadioButton = new System.Windows.Forms.RadioButton();
    this.maleRadioButton = new System.Windows.Forms.RadioButton();
    this.button1 = new System.Windows.Forms.Button();
    this.label31 = new System.Windows.Forms.Label();
    this.sonsListBox = new System.Windows.Forms.ListBox();
    this.conyugeTextBox = new System.Windows.Forms.TextBox();
    this.label30 = new System.Windows.Forms.Label();
    this.tabPage5 = new System.Windows.Forms.TabPage();
    this.label29 = new System.Windows.Forms.Label();
    this.notesRichTextBox = new System.Windows.Forms.RichTextBox();
    this.saveButton = new System.Windows.Forms.Button();
    this.cancelButton = new System.Windows.Forms.Button();
    this.deleteButton = new System.Windows.Forms.Button();
    this.tabControl1.SuspendLayout();
    this.tabPage1.SuspendLayout();
    this.groupBox1.SuspendLayout();
    this.tabPage2.SuspendLayout();
    this.tabPage3.SuspendLayout();
    this.tabPage4.SuspendLayout();
    this.tabPage5.SuspendLayout();
    this.SuspendLayout();
    // 
    // tabControl1
    // 
    this.tabControl1.Controls.Add(this.tabPage1);
    this.tabControl1.Controls.Add(this.tabPage2);
    this.tabControl1.Controls.Add(this.tabPage3);
    this.tabControl1.Controls.Add(this.tabPage4);
    this.tabControl1.Controls.Add(this.tabPage5);
    this.tabControl1.Location = new System.Drawing.Point(16, 24);
    this.tabControl1.Name = "tabControl1";
    this.tabControl1.SelectedIndex = 0;
    this.tabControl1.Size = new System.Drawing.Size(536, 408);
    this.tabControl1.TabIndex = 0;
    // 
    // tabPage1
    // 
    this.tabPage1.Controls.Add(this.seekButton);
    this.tabPage1.Controls.Add(this.label8);
    this.tabPage1.Controls.Add(this.pictureBox);
    this.tabPage1.Controls.Add(this.groupBox1);
    this.tabPage1.Controls.Add(this.displayNameComboBox);
    this.tabPage1.Controls.Add(this.titleTextBox);
    this.tabPage1.Controls.Add(this.nickNameTextBox);
    this.tabPage1.Controls.Add(this.lastNameTextBox);
    this.tabPage1.Controls.Add(this.secondtNameTextBox);
    this.tabPage1.Controls.Add(this.firstNameTextBox);
    this.tabPage1.Controls.Add(this.label6);
    this.tabPage1.Controls.Add(this.label5);
    this.tabPage1.Controls.Add(this.label4);
    this.tabPage1.Controls.Add(this.label3);
    this.tabPage1.Controls.Add(this.label2);
    this.tabPage1.Controls.Add(this.label1);
    this.tabPage1.Location = new System.Drawing.Point(4, 22);
    this.tabPage1.Name = "tabPage1";
    this.tabPage1.Size = new System.Drawing.Size(528, 382);
    this.tabPage1.TabIndex = 0;
    this.tabPage1.Text = "Name";
    // 
    // seekButton
    // 
    this.seekButton.Location = new System.Drawing.Point(296, 24);
    this.seekButton.Name = "seekButton";
    this.seekButton.Size = new System.Drawing.Size(24, 16);
    this.seekButton.TabIndex = 16;
    this.seekButton.Text = "...";
    this.seekButton.Click += new System.EventHandler(this.seekButton_Click);
    // 
    // label8
    // 
    this.label8.Location = new System.Drawing.Point(360, 48);
    this.label8.Name = "label8";
    this.label8.Size = new System.Drawing.Size(100, 16);
    this.label8.TabIndex = 15;
    this.label8.Text = "Picture";
    this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
    // 
    // pictureBox
    // 
    this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    this.pictureBox.Location = new System.Drawing.Point(344, 72);
    this.pictureBox.Name = "pictureBox";
    this.pictureBox.Size = new System.Drawing.Size(144, 104);
    this.pictureBox.TabIndex = 14;
    this.pictureBox.TabStop = false;
    this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
    // 
    // groupBox1
    // 
    this.groupBox1.Controls.Add(this.deleteMailButton);
    this.groupBox1.Controls.Add(this.updateMailButton);
    this.groupBox1.Controls.Add(this.addMailButton);
    this.groupBox1.Controls.Add(this.emailTextBox);
    this.groupBox1.Controls.Add(this.emailListBox);
    this.groupBox1.Controls.Add(this.label7);
    this.groupBox1.Location = new System.Drawing.Point(8, 184);
    this.groupBox1.Name = "groupBox1";
    this.groupBox1.Size = new System.Drawing.Size(512, 184);
    this.groupBox1.TabIndex = 13;
    this.groupBox1.TabStop = false;
    // 
    // deleteMailButton
    // 
    this.deleteMailButton.Location = new System.Drawing.Point(400, 120);
    this.deleteMailButton.Name = "deleteMailButton";
    this.deleteMailButton.Size = new System.Drawing.Size(96, 23);
    this.deleteMailButton.TabIndex = 14;
    this.deleteMailButton.Text = "Delete";
    this.deleteMailButton.Click += new System.EventHandler(this.deleteMailButton_Click);
    // 
    // updateMailButton
    // 
    this.updateMailButton.Location = new System.Drawing.Point(400, 96);
    this.updateMailButton.Name = "updateMailButton";
    this.updateMailButton.Size = new System.Drawing.Size(96, 23);
    this.updateMailButton.TabIndex = 13;
    this.updateMailButton.Text = "Modify";
    this.updateMailButton.Click += new System.EventHandler(this.updateMailButton_Click);
    // 
    // addMailButton
    // 
    this.addMailButton.Location = new System.Drawing.Point(400, 72);
    this.addMailButton.Name = "addMailButton";
    this.addMailButton.Size = new System.Drawing.Size(96, 23);
    this.addMailButton.TabIndex = 12;
    this.addMailButton.Text = "Add";
    this.addMailButton.Click += new System.EventHandler(this.addMailButton_Click);
    // 
    // emailTextBox
    // 
    this.emailTextBox.Location = new System.Drawing.Point(104, 24);
    this.emailTextBox.Name = "emailTextBox";
    this.emailTextBox.Size = new System.Drawing.Size(160, 20);
    this.emailTextBox.TabIndex = 11;
    this.emailTextBox.Text = "";
    // 
    // emailListBox
    // 
    this.emailListBox.Location = new System.Drawing.Point(8, 56);
    this.emailListBox.Name = "emailListBox";
    this.emailListBox.Size = new System.Drawing.Size(376, 121);
    this.emailListBox.TabIndex = 7;
    this.emailListBox.SelectedValueChanged += new System.EventHandler(this.emailListBox_SelectedValueChanged);
    // 
    // label7
    // 
    this.label7.Location = new System.Drawing.Point(40, 24);
    this.label7.Name = "label7";
    this.label7.Size = new System.Drawing.Size(56, 16);
    this.label7.TabIndex = 6;
    this.label7.Text = "Emails";
    // 
    // displayNameComboBox
    // 
    this.displayNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    this.displayNameComboBox.Location = new System.Drawing.Point(128, 120);
    this.displayNameComboBox.Name = "displayNameComboBox";
    this.displayNameComboBox.Size = new System.Drawing.Size(160, 21);
    this.displayNameComboBox.TabIndex = 12;
    // 
    // titleTextBox
    // 
    this.titleTextBox.Location = new System.Drawing.Point(128, 144);
    this.titleTextBox.Name = "titleTextBox";
    this.titleTextBox.Size = new System.Drawing.Size(96, 20);
    this.titleTextBox.TabIndex = 11;
    this.titleTextBox.Text = "";
    // 
    // nickNameTextBox
    // 
    this.nickNameTextBox.Location = new System.Drawing.Point(128, 96);
    this.nickNameTextBox.Name = "nickNameTextBox";
    this.nickNameTextBox.Size = new System.Drawing.Size(160, 20);
    this.nickNameTextBox.TabIndex = 10;
    this.nickNameTextBox.Text = "";
    // 
    // lastNameTextBox
    // 
    this.lastNameTextBox.Location = new System.Drawing.Point(128, 72);
    this.lastNameTextBox.Name = "lastNameTextBox";
    this.lastNameTextBox.Size = new System.Drawing.Size(160, 20);
    this.lastNameTextBox.TabIndex = 9;
    this.lastNameTextBox.Text = "";
    // 
    // secondtNameTextBox
    // 
    this.secondtNameTextBox.Location = new System.Drawing.Point(128, 48);
    this.secondtNameTextBox.Name = "secondtNameTextBox";
    this.secondtNameTextBox.Size = new System.Drawing.Size(160, 20);
    this.secondtNameTextBox.TabIndex = 8;
    this.secondtNameTextBox.Text = "";
    // 
    // firstNameTextBox
    // 
    this.firstNameTextBox.Location = new System.Drawing.Point(128, 24);
    this.firstNameTextBox.Name = "firstNameTextBox";
    this.firstNameTextBox.Size = new System.Drawing.Size(160, 20);
    this.firstNameTextBox.TabIndex = 7;
    this.firstNameTextBox.Text = "";
    // 
    // label6
    // 
    this.label6.Location = new System.Drawing.Point(24, 152);
    this.label6.Name = "label6";
    this.label6.Size = new System.Drawing.Size(100, 16);
    this.label6.TabIndex = 5;
    this.label6.Text = "Title";
    // 
    // label5
    // 
    this.label5.Location = new System.Drawing.Point(24, 128);
    this.label5.Name = "label5";
    this.label5.Size = new System.Drawing.Size(48, 16);
    this.label5.TabIndex = 4;
    this.label5.Text = "Display";
    // 
    // label4
    // 
    this.label4.Location = new System.Drawing.Point(24, 104);
    this.label4.Name = "label4";
    this.label4.Size = new System.Drawing.Size(100, 16);
    this.label4.TabIndex = 3;
    this.label4.Text = "NickName";
    // 
    // label3
    // 
    this.label3.Location = new System.Drawing.Point(24, 80);
    this.label3.Name = "label3";
    this.label3.Size = new System.Drawing.Size(100, 16);
    this.label3.TabIndex = 2;
    this.label3.Text = "Last Name";
    // 
    // label2
    // 
    this.label2.Location = new System.Drawing.Point(24, 56);
    this.label2.Name = "label2";
    this.label2.Size = new System.Drawing.Size(100, 16);
    this.label2.TabIndex = 1;
    this.label2.Text = "Second Name";
    // 
    // label1
    // 
    this.label1.Location = new System.Drawing.Point(24, 32);
    this.label1.Name = "label1";
    this.label1.Size = new System.Drawing.Size(100, 16);
    this.label1.TabIndex = 0;
    this.label1.Text = "First Name";
    // 
    // tabPage2
    // 
    this.tabPage2.Controls.Add(this.addressTextBox);
    this.tabPage2.Controls.Add(this.zipCodeTextBox);
    this.tabPage2.Controls.Add(this.label16);
    this.tabPage2.Controls.Add(this.countryTextBox);
    this.tabPage2.Controls.Add(this.label15);
    this.tabPage2.Controls.Add(this.stateTextBox);
    this.tabPage2.Controls.Add(this.label14);
    this.tabPage2.Controls.Add(this.cityTextBox);
    this.tabPage2.Controls.Add(this.label13);
    this.tabPage2.Controls.Add(this.mobileTextBox);
    this.tabPage2.Controls.Add(this.label12);
    this.tabPage2.Controls.Add(this.faxTextBox);
    this.tabPage2.Controls.Add(this.label11);
    this.tabPage2.Controls.Add(this.phoneTextBox);
    this.tabPage2.Controls.Add(this.label10);
    this.tabPage2.Controls.Add(this.label9);
    this.tabPage2.Location = new System.Drawing.Point(4, 22);
    this.tabPage2.Name = "tabPage2";
    this.tabPage2.Size = new System.Drawing.Size(528, 382);
    this.tabPage2.TabIndex = 1;
    this.tabPage2.Text = "Address";
    // 
    // addressTextBox
    // 
    this.addressTextBox.Location = new System.Drawing.Point(136, 72);
    this.addressTextBox.Multiline = true;
    this.addressTextBox.Name = "addressTextBox";
    this.addressTextBox.Size = new System.Drawing.Size(336, 80);
    this.addressTextBox.TabIndex = 24;
    this.addressTextBox.Text = "";
    // 
    // zipCodeTextBox
    // 
    this.zipCodeTextBox.Location = new System.Drawing.Point(136, 280);
    this.zipCodeTextBox.Name = "zipCodeTextBox";
    this.zipCodeTextBox.Size = new System.Drawing.Size(160, 20);
    this.zipCodeTextBox.TabIndex = 23;
    this.zipCodeTextBox.Text = "";
    // 
    // label16
    // 
    this.label16.Location = new System.Drawing.Point(32, 288);
    this.label16.Name = "label16";
    this.label16.Size = new System.Drawing.Size(100, 16);
    this.label16.TabIndex = 22;
    this.label16.Text = "Zip Code";
    // 
    // countryTextBox
    // 
    this.countryTextBox.Location = new System.Drawing.Point(136, 304);
    this.countryTextBox.Name = "countryTextBox";
    this.countryTextBox.Size = new System.Drawing.Size(160, 20);
    this.countryTextBox.TabIndex = 21;
    this.countryTextBox.Text = "";
    // 
    // label15
    // 
    this.label15.Location = new System.Drawing.Point(32, 312);
    this.label15.Name = "label15";
    this.label15.Size = new System.Drawing.Size(100, 16);
    this.label15.TabIndex = 20;
    this.label15.Text = "Country";
    // 
    // stateTextBox
    // 
    this.stateTextBox.Location = new System.Drawing.Point(136, 256);
    this.stateTextBox.Name = "stateTextBox";
    this.stateTextBox.Size = new System.Drawing.Size(160, 20);
    this.stateTextBox.TabIndex = 19;
    this.stateTextBox.Text = "";
    // 
    // label14
    // 
    this.label14.Location = new System.Drawing.Point(32, 264);
    this.label14.Name = "label14";
    this.label14.Size = new System.Drawing.Size(100, 16);
    this.label14.TabIndex = 18;
    this.label14.Text = "State";
    // 
    // cityTextBox
    // 
    this.cityTextBox.Location = new System.Drawing.Point(136, 232);
    this.cityTextBox.Name = "cityTextBox";
    this.cityTextBox.Size = new System.Drawing.Size(160, 20);
    this.cityTextBox.TabIndex = 17;
    this.cityTextBox.Text = "";
    // 
    // label13
    // 
    this.label13.Location = new System.Drawing.Point(32, 240);
    this.label13.Name = "label13";
    this.label13.Size = new System.Drawing.Size(100, 16);
    this.label13.TabIndex = 16;
    this.label13.Text = "City";
    // 
    // mobileTextBox
    // 
    this.mobileTextBox.Location = new System.Drawing.Point(136, 208);
    this.mobileTextBox.Name = "mobileTextBox";
    this.mobileTextBox.Size = new System.Drawing.Size(272, 20);
    this.mobileTextBox.TabIndex = 15;
    this.mobileTextBox.Text = "";
    // 
    // label12
    // 
    this.label12.Location = new System.Drawing.Point(32, 216);
    this.label12.Name = "label12";
    this.label12.Size = new System.Drawing.Size(100, 16);
    this.label12.TabIndex = 14;
    this.label12.Text = "Mobile";
    // 
    // faxTextBox
    // 
    this.faxTextBox.Location = new System.Drawing.Point(136, 184);
    this.faxTextBox.Name = "faxTextBox";
    this.faxTextBox.Size = new System.Drawing.Size(272, 20);
    this.faxTextBox.TabIndex = 13;
    this.faxTextBox.Text = "";
    // 
    // label11
    // 
    this.label11.Location = new System.Drawing.Point(32, 192);
    this.label11.Name = "label11";
    this.label11.Size = new System.Drawing.Size(100, 16);
    this.label11.TabIndex = 12;
    this.label11.Text = "Fax";
    // 
    // phoneTextBox
    // 
    this.phoneTextBox.Location = new System.Drawing.Point(136, 160);
    this.phoneTextBox.Name = "phoneTextBox";
    this.phoneTextBox.Size = new System.Drawing.Size(272, 20);
    this.phoneTextBox.TabIndex = 11;
    this.phoneTextBox.Text = "";
    // 
    // label10
    // 
    this.label10.Location = new System.Drawing.Point(32, 168);
    this.label10.Name = "label10";
    this.label10.Size = new System.Drawing.Size(100, 16);
    this.label10.TabIndex = 10;
    this.label10.Text = "Phone";
    // 
    // label9
    // 
    this.label9.Location = new System.Drawing.Point(32, 80);
    this.label9.Name = "label9";
    this.label9.Size = new System.Drawing.Size(100, 16);
    this.label9.TabIndex = 8;
    this.label9.Text = "Address";
    // 
    // tabPage3
    // 
    this.tabPage3.Controls.Add(this.label34);
    this.tabPage3.Controls.Add(this.faxOrgTextBox);
    this.tabPage3.Controls.Add(this.ipPhoneOrgTextBox);
    this.tabPage3.Controls.Add(this.label26);
    this.tabPage3.Controls.Add(this.locOrgTextBox);
    this.tabPage3.Controls.Add(this.label27);
    this.tabPage3.Controls.Add(this.phoneOrgTextBox);
    this.tabPage3.Controls.Add(this.label28);
    this.tabPage3.Controls.Add(this.countryOrgTextBox);
    this.tabPage3.Controls.Add(this.label25);
    this.tabPage3.Controls.Add(this.zipCodeOrgTextBox);
    this.tabPage3.Controls.Add(this.label24);
    this.tabPage3.Controls.Add(this.addressOrgTextBox);
    this.tabPage3.Controls.Add(this.label22);
    this.tabPage3.Controls.Add(this.officeTextBox);
    this.tabPage3.Controls.Add(this.label23);
    this.tabPage3.Controls.Add(this.departamentTextBox);
    this.tabPage3.Controls.Add(this.label20);
    this.tabPage3.Controls.Add(this.positionTextBox);
    this.tabPage3.Controls.Add(this.label21);
    this.tabPage3.Controls.Add(this.stateOrgTextBox);
    this.tabPage3.Controls.Add(this.label19);
    this.tabPage3.Controls.Add(this.cityOrgTextBox);
    this.tabPage3.Controls.Add(this.label18);
    this.tabPage3.Controls.Add(this.organizationTextBox);
    this.tabPage3.Controls.Add(this.label17);
    this.tabPage3.Location = new System.Drawing.Point(4, 22);
    this.tabPage3.Name = "tabPage3";
    this.tabPage3.Size = new System.Drawing.Size(528, 382);
    this.tabPage3.TabIndex = 2;
    this.tabPage3.Text = "Business";
    // 
    // label34
    // 
    this.label34.Location = new System.Drawing.Point(40, 280);
    this.label34.Name = "label34";
    this.label34.Size = new System.Drawing.Size(100, 16);
    this.label34.TabIndex = 33;
    this.label34.Text = "Fax";
    // 
    // faxOrgTextBox
    // 
    this.faxOrgTextBox.Location = new System.Drawing.Point(144, 272);
    this.faxOrgTextBox.Name = "faxOrgTextBox";
    this.faxOrgTextBox.Size = new System.Drawing.Size(160, 20);
    this.faxOrgTextBox.TabIndex = 32;
    this.faxOrgTextBox.Text = "";
    // 
    // ipPhoneOrgTextBox
    // 
    this.ipPhoneOrgTextBox.Location = new System.Drawing.Point(144, 320);
    this.ipPhoneOrgTextBox.Name = "ipPhoneOrgTextBox";
    this.ipPhoneOrgTextBox.Size = new System.Drawing.Size(160, 20);
    this.ipPhoneOrgTextBox.TabIndex = 31;
    this.ipPhoneOrgTextBox.Text = "";
    // 
    // label26
    // 
    this.label26.Location = new System.Drawing.Point(40, 328);
    this.label26.Name = "label26";
    this.label26.Size = new System.Drawing.Size(100, 16);
    this.label26.TabIndex = 30;
    this.label26.Text = "Ip Phone";
    // 
    // locOrgTextBox
    // 
    this.locOrgTextBox.Location = new System.Drawing.Point(144, 296);
    this.locOrgTextBox.Name = "locOrgTextBox";
    this.locOrgTextBox.Size = new System.Drawing.Size(160, 20);
    this.locOrgTextBox.TabIndex = 29;
    this.locOrgTextBox.Text = "";
    // 
    // label27
    // 
    this.label27.Location = new System.Drawing.Point(40, 304);
    this.label27.Name = "label27";
    this.label27.Size = new System.Drawing.Size(100, 16);
    this.label27.TabIndex = 28;
    this.label27.Text = "Localizator";
    // 
    // phoneOrgTextBox
    // 
    this.phoneOrgTextBox.Location = new System.Drawing.Point(144, 248);
    this.phoneOrgTextBox.Name = "phoneOrgTextBox";
    this.phoneOrgTextBox.Size = new System.Drawing.Size(160, 20);
    this.phoneOrgTextBox.TabIndex = 27;
    this.phoneOrgTextBox.Text = "";
    // 
    // label28
    // 
    this.label28.Location = new System.Drawing.Point(40, 256);
    this.label28.Name = "label28";
    this.label28.Size = new System.Drawing.Size(100, 16);
    this.label28.TabIndex = 26;
    this.label28.Text = "Phone";
    // 
    // countryOrgTextBox
    // 
    this.countryOrgTextBox.Location = new System.Drawing.Point(144, 224);
    this.countryOrgTextBox.Name = "countryOrgTextBox";
    this.countryOrgTextBox.Size = new System.Drawing.Size(160, 20);
    this.countryOrgTextBox.TabIndex = 25;
    this.countryOrgTextBox.Text = "";
    // 
    // label25
    // 
    this.label25.Location = new System.Drawing.Point(40, 232);
    this.label25.Name = "label25";
    this.label25.Size = new System.Drawing.Size(100, 16);
    this.label25.TabIndex = 24;
    this.label25.Text = "Country";
    // 
    // zipCodeOrgTextBox
    // 
    this.zipCodeOrgTextBox.Location = new System.Drawing.Point(144, 200);
    this.zipCodeOrgTextBox.Name = "zipCodeOrgTextBox";
    this.zipCodeOrgTextBox.Size = new System.Drawing.Size(160, 20);
    this.zipCodeOrgTextBox.TabIndex = 23;
    this.zipCodeOrgTextBox.Text = "";
    // 
    // label24
    // 
    this.label24.Location = new System.Drawing.Point(40, 208);
    this.label24.Name = "label24";
    this.label24.Size = new System.Drawing.Size(100, 16);
    this.label24.TabIndex = 22;
    this.label24.Text = "Zip Code";
    // 
    // addressOrgTextBox
    // 
    this.addressOrgTextBox.Location = new System.Drawing.Point(144, 128);
    this.addressOrgTextBox.Name = "addressOrgTextBox";
    this.addressOrgTextBox.Size = new System.Drawing.Size(160, 20);
    this.addressOrgTextBox.TabIndex = 21;
    this.addressOrgTextBox.Text = "";
    // 
    // label22
    // 
    this.label22.Location = new System.Drawing.Point(40, 136);
    this.label22.Name = "label22";
    this.label22.Size = new System.Drawing.Size(100, 16);
    this.label22.TabIndex = 20;
    this.label22.Text = "Address";
    // 
    // officeTextBox
    // 
    this.officeTextBox.Location = new System.Drawing.Point(144, 104);
    this.officeTextBox.Name = "officeTextBox";
    this.officeTextBox.Size = new System.Drawing.Size(160, 20);
    this.officeTextBox.TabIndex = 19;
    this.officeTextBox.Text = "";
    // 
    // label23
    // 
    this.label23.Location = new System.Drawing.Point(40, 112);
    this.label23.Name = "label23";
    this.label23.Size = new System.Drawing.Size(100, 16);
    this.label23.TabIndex = 18;
    this.label23.Text = "Office";
    // 
    // departamentTextBox
    // 
    this.departamentTextBox.Location = new System.Drawing.Point(144, 80);
    this.departamentTextBox.Name = "departamentTextBox";
    this.departamentTextBox.Size = new System.Drawing.Size(160, 20);
    this.departamentTextBox.TabIndex = 17;
    this.departamentTextBox.Text = "";
    // 
    // label20
    // 
    this.label20.Location = new System.Drawing.Point(40, 88);
    this.label20.Name = "label20";
    this.label20.Size = new System.Drawing.Size(100, 16);
    this.label20.TabIndex = 16;
    this.label20.Text = "Departament";
    // 
    // positionTextBox
    // 
    this.positionTextBox.Location = new System.Drawing.Point(144, 56);
    this.positionTextBox.Name = "positionTextBox";
    this.positionTextBox.Size = new System.Drawing.Size(160, 20);
    this.positionTextBox.TabIndex = 15;
    this.positionTextBox.Text = "";
    // 
    // label21
    // 
    this.label21.Location = new System.Drawing.Point(40, 64);
    this.label21.Name = "label21";
    this.label21.Size = new System.Drawing.Size(100, 16);
    this.label21.TabIndex = 14;
    this.label21.Text = "Position";
    // 
    // stateOrgTextBox
    // 
    this.stateOrgTextBox.Location = new System.Drawing.Point(144, 176);
    this.stateOrgTextBox.Name = "stateOrgTextBox";
    this.stateOrgTextBox.Size = new System.Drawing.Size(160, 20);
    this.stateOrgTextBox.TabIndex = 13;
    this.stateOrgTextBox.Text = "";
    // 
    // label19
    // 
    this.label19.Location = new System.Drawing.Point(40, 184);
    this.label19.Name = "label19";
    this.label19.Size = new System.Drawing.Size(100, 16);
    this.label19.TabIndex = 12;
    this.label19.Text = "State";
    // 
    // cityOrgTextBox
    // 
    this.cityOrgTextBox.Location = new System.Drawing.Point(144, 152);
    this.cityOrgTextBox.Name = "cityOrgTextBox";
    this.cityOrgTextBox.Size = new System.Drawing.Size(160, 20);
    this.cityOrgTextBox.TabIndex = 11;
    this.cityOrgTextBox.Text = "";
    // 
    // label18
    // 
    this.label18.Location = new System.Drawing.Point(40, 160);
    this.label18.Name = "label18";
    this.label18.Size = new System.Drawing.Size(100, 16);
    this.label18.TabIndex = 10;
    this.label18.Text = "City";
    // 
    // organizationTextBox
    // 
    this.organizationTextBox.Location = new System.Drawing.Point(144, 32);
    this.organizationTextBox.Name = "organizationTextBox";
    this.organizationTextBox.Size = new System.Drawing.Size(160, 20);
    this.organizationTextBox.TabIndex = 9;
    this.organizationTextBox.Text = "";
    // 
    // label17
    // 
    this.label17.Location = new System.Drawing.Point(40, 40);
    this.label17.Name = "label17";
    this.label17.Size = new System.Drawing.Size(100, 16);
    this.label17.TabIndex = 8;
    this.label17.Text = "Organization";
    // 
    // tabPage4
    // 
    this.tabPage4.Controls.Add(this.sonTextBox);
    this.tabPage4.Controls.Add(this.label33);
    this.tabPage4.Controls.Add(this.label32);
    this.tabPage4.Controls.Add(this.anniversaryTimePicker);
    this.tabPage4.Controls.Add(this.birthdayTimePicker);
    this.tabPage4.Controls.Add(this.button3);
    this.tabPage4.Controls.Add(this.button2);
    this.tabPage4.Controls.Add(this.femaleRadioButton);
    this.tabPage4.Controls.Add(this.maleRadioButton);
    this.tabPage4.Controls.Add(this.button1);
    this.tabPage4.Controls.Add(this.label31);
    this.tabPage4.Controls.Add(this.sonsListBox);
    this.tabPage4.Controls.Add(this.conyugeTextBox);
    this.tabPage4.Controls.Add(this.label30);
    this.tabPage4.Location = new System.Drawing.Point(4, 22);
    this.tabPage4.Name = "tabPage4";
    this.tabPage4.Size = new System.Drawing.Size(528, 382);
    this.tabPage4.TabIndex = 3;
    this.tabPage4.Text = "Personal";
    // 
    // sonTextBox
    // 
    this.sonTextBox.Location = new System.Drawing.Point(144, 120);
    this.sonTextBox.Name = "sonTextBox";
    this.sonTextBox.Size = new System.Drawing.Size(200, 20);
    this.sonTextBox.TabIndex = 23;
    this.sonTextBox.Text = "";
    // 
    // label33
    // 
    this.label33.Location = new System.Drawing.Point(32, 344);
    this.label33.Name = "label33";
    this.label33.Size = new System.Drawing.Size(72, 16);
    this.label33.TabIndex = 22;
    this.label33.Text = "Anniversary";
    // 
    // label32
    // 
    this.label32.Location = new System.Drawing.Point(32, 314);
    this.label32.Name = "label32";
    this.label32.Size = new System.Drawing.Size(64, 16);
    this.label32.TabIndex = 21;
    this.label32.Text = "Birthday";
    // 
    // anniversaryTimePicker
    // 
    this.anniversaryTimePicker.Location = new System.Drawing.Point(120, 344);
    this.anniversaryTimePicker.Name = "anniversaryTimePicker";
    this.anniversaryTimePicker.TabIndex = 20;
    // 
    // birthdayTimePicker
    // 
    this.birthdayTimePicker.Location = new System.Drawing.Point(120, 312);
    this.birthdayTimePicker.Name = "birthdayTimePicker";
    this.birthdayTimePicker.TabIndex = 19;
    // 
    // button3
    // 
    this.button3.Location = new System.Drawing.Point(368, 216);
    this.button3.Name = "button3";
    this.button3.TabIndex = 18;
    this.button3.Text = "Modify";
    this.button3.Click += new System.EventHandler(this.button3_Click);
    // 
    // button2
    // 
    this.button2.Location = new System.Drawing.Point(368, 192);
    this.button2.Name = "button2";
    this.button2.TabIndex = 17;
    this.button2.Text = "Delete";
    this.button2.Click += new System.EventHandler(this.button2_Click);
    // 
    // femaleRadioButton
    // 
    this.femaleRadioButton.Location = new System.Drawing.Point(184, 80);
    this.femaleRadioButton.Name = "femaleRadioButton";
    this.femaleRadioButton.Size = new System.Drawing.Size(64, 16);
    this.femaleRadioButton.TabIndex = 16;
    this.femaleRadioButton.Text = "Female";
    // 
    // maleRadioButton
    // 
    this.maleRadioButton.Location = new System.Drawing.Point(112, 80);
    this.maleRadioButton.Name = "maleRadioButton";
    this.maleRadioButton.Size = new System.Drawing.Size(64, 16);
    this.maleRadioButton.TabIndex = 15;
    this.maleRadioButton.Text = "Male";
    // 
    // button1
    // 
    this.button1.Location = new System.Drawing.Point(368, 168);
    this.button1.Name = "button1";
    this.button1.TabIndex = 14;
    this.button1.Text = "Add";
    this.button1.Click += new System.EventHandler(this.button1_Click);
    // 
    // label31
    // 
    this.label31.Location = new System.Drawing.Point(56, 120);
    this.label31.Name = "label31";
    this.label31.Size = new System.Drawing.Size(48, 16);
    this.label31.TabIndex = 13;
    this.label31.Text = "Sons";
    // 
    // sonsListBox
    // 
    this.sonsListBox.Location = new System.Drawing.Point(48, 144);
    this.sonsListBox.Name = "sonsListBox";
    this.sonsListBox.Size = new System.Drawing.Size(312, 147);
    this.sonsListBox.TabIndex = 12;
    this.sonsListBox.SelectedValueChanged += new System.EventHandler(this.sonsListBox_SelectedValueChanged);
    // 
    // conyugeTextBox
    // 
    this.conyugeTextBox.Location = new System.Drawing.Point(160, 32);
    this.conyugeTextBox.Name = "conyugeTextBox";
    this.conyugeTextBox.Size = new System.Drawing.Size(248, 20);
    this.conyugeTextBox.TabIndex = 11;
    this.conyugeTextBox.Text = "";
    // 
    // label30
    // 
    this.label30.Location = new System.Drawing.Point(56, 40);
    this.label30.Name = "label30";
    this.label30.Size = new System.Drawing.Size(100, 16);
    this.label30.TabIndex = 10;
    this.label30.Text = "Conyuge";
    // 
    // tabPage5
    // 
    this.tabPage5.Controls.Add(this.label29);
    this.tabPage5.Controls.Add(this.notesRichTextBox);
    this.tabPage5.Location = new System.Drawing.Point(4, 22);
    this.tabPage5.Name = "tabPage5";
    this.tabPage5.Size = new System.Drawing.Size(528, 382);
    this.tabPage5.TabIndex = 4;
    this.tabPage5.Text = "Others/Notes";
    // 
    // label29
    // 
    this.label29.Location = new System.Drawing.Point(80, 48);
    this.label29.Name = "label29";
    this.label29.Size = new System.Drawing.Size(100, 16);
    this.label29.TabIndex = 1;
    this.label29.Text = "Notes ...";
    // 
    // notesRichTextBox
    // 
    this.notesRichTextBox.Location = new System.Drawing.Point(24, 72);
    this.notesRichTextBox.Name = "notesRichTextBox";
    this.notesRichTextBox.Size = new System.Drawing.Size(472, 264);
    this.notesRichTextBox.TabIndex = 0;
    this.notesRichTextBox.Text = "";
    // 
    // saveButton
    // 
    this.saveButton.Location = new System.Drawing.Point(368, 440);
    this.saveButton.Name = "saveButton";
    this.saveButton.TabIndex = 1;
    this.saveButton.Text = "Save";
    this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
    // 
    // cancelButton
    // 
    this.cancelButton.Location = new System.Drawing.Point(448, 440);
    this.cancelButton.Name = "cancelButton";
    this.cancelButton.TabIndex = 2;
    this.cancelButton.Text = "Cancel";
    this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
    // 
    // deleteButton
    // 
    this.deleteButton.Location = new System.Drawing.Point(288, 440);
    this.deleteButton.Name = "deleteButton";
    this.deleteButton.TabIndex = 3;
    this.deleteButton.Text = "Delete";
    this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
    // 
    // ContactsForm
    // 
    this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
    this.ClientSize = new System.Drawing.Size(568, 470);
    this.Controls.Add(this.deleteButton);
    this.Controls.Add(this.cancelButton);
    this.Controls.Add(this.saveButton);
    this.Controls.Add(this.tabControl1);
    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
    this.Name = "ContactsForm";
    this.Text = "ContactsForm";
    this.tabControl1.ResumeLayout(false);
    this.tabPage1.ResumeLayout(false);
    this.groupBox1.ResumeLayout(false);
    this.tabPage2.ResumeLayout(false);
    this.tabPage3.ResumeLayout(false);
    this.tabPage4.ResumeLayout(false);
    this.tabPage5.ResumeLayout(false);
    this.ResumeLayout(false);

}

#endregion

private 
void cancelButton_Click(object sender, System.EventArgs e){
	this.Close();
}

private 
void saveButton_Click(object sender, System.EventArgs e){
	try{
		if (contact == null){
			this.contact = coreFactory.createContact();

			screenToObject();
			coreFactory.writeContact(contact);
		}else{
			screenToObject();
			coreFactory.updateContact(contact);
		}

		MessageBox.Show("Contact added with the number : " + contact.getContactId().ToString());
		this.Close();
	}catch(NujitException ne){
		FormException formException = new FormException(ne);
		formException.Show();
	}
}

private 
bool validData(){
	if (firstNameTextBox.Text.Equals("")){
		return false;
	}
	if (lastNameTextBox.Text.Equals("")){
		return false;
	}
	return true;
}

private 
void screenToObject(){
	contact.setFirstName(firstNameTextBox.Text);
	contact.setSecondName(secondtNameTextBox.Text);
	contact.setLastName(lastNameTextBox.Text);
	contact.setNickName(nickNameTextBox.Text);
	contact.setDisplayName(displayNameComboBox.Text);
	contact.setTitle(titleTextBox.Text);
	contact.setAddress(addressTextBox.Text);
	contact.setCity(cityTextBox.Text);
	contact.setState(stateTextBox.Text);
	contact.setZipCode(zipCodeTextBox.Text);
	contact.setCountry(countryTextBox.Text);
	contact.setPhone(phoneTextBox.Text);
	contact.setFax(faxTextBox.Text);
	contact.setMobile(mobileTextBox.Text);
	contact.setOrganization(organizationTextBox.Text);
	contact.setOffice(officeTextBox.Text);
	contact.setJobAddress(addressOrgTextBox.Text);
	contact.setJobCity(cityOrgTextBox.Text);
	contact.setJobState(stateOrgTextBox.Text);
	contact.setJobZipCode(zipCodeOrgTextBox.Text);
	contact.setJobCountry(countryOrgTextBox.Text);
	contact.setJobPhone(phoneOrgTextBox.Text);
	contact.setJobFax(faxOrgTextBox.Text);
	contact.setJobPosition(positionTextBox.Text);
	contact.setJobDepartament(departamentTextBox.Text);
	contact.setJobLocalizator(locOrgTextBox.Text);
	contact.setJobIpPhone(ipPhoneOrgTextBox.Text);
	contact.setConyugue(conyugeTextBox.Text);
	contact.setBirthday(birthdayTimePicker.Value);
	contact.setAnniversary(anniversaryTimePicker.Value);
	contact.setNotes(notesRichTextBox.Text);

	if (femaleRadioButton.Checked)
		contact.setSex("F");
	else
		contact.setSex("M");

	contact.clearEmails();
	for(int i = 0; i < emailListBox.Items.Count; i++){
		Mail mail = (Mail)emailListBox.Items[i];
		contact.addEmail(mail.email, mail.defaultMail);
	}

	contact.clearSons();
	for(int i = 0; i < sonsListBox.Items.Count; i++)
		contact.addSon((string)sonsListBox.Items[i]);

}

private 
void objectToScreen(){
	firstNameTextBox.Text = contact.getFirstName();
	secondtNameTextBox.Text = contact.getSecondName();
	lastNameTextBox.Text = contact.getLastName();
	nickNameTextBox.Text = contact.getNickName();
	displayNameComboBox.Text = contact.getDisplayName();
	titleTextBox.Text = contact.getTitle();
	addressTextBox.Text = contact.getAddress();
	cityTextBox.Text = contact.getCity();
	stateTextBox.Text = contact.getState();
	zipCodeTextBox.Text = contact.getZipCode();
	countryTextBox.Text = contact.getCountry();
	phoneTextBox.Text = contact.getPhone();
	faxTextBox.Text = contact.getFax();
	mobileTextBox.Text = contact.getMobile();
	organizationTextBox.Text = contact.getOrganization();
	officeTextBox.Text = contact.getOffice();
	addressOrgTextBox.Text = contact.getJobAddress();
	cityOrgTextBox.Text = contact.getJobCity();
	stateOrgTextBox.Text = contact.getJobState();
	zipCodeOrgTextBox.Text = contact.getJobZipCode();
	countryOrgTextBox.Text = contact.getJobCountry();
	phoneOrgTextBox.Text = contact.getJobPhone();
	faxOrgTextBox.Text = contact.getJobFax();
	positionTextBox.Text = contact.getJobPosition();
	departamentTextBox.Text = contact.getJobDepartament();
	locOrgTextBox.Text = contact.getJobLocalizator();
	ipPhoneOrgTextBox.Text = contact.getJobIpPhone();
	conyugeTextBox.Text = contact.getConyugue();
	birthdayTimePicker.Value = contact.getBirthday();
	anniversaryTimePicker.Value = contact.getAnniversary();
	notesRichTextBox.Text = contact.getNotes();
	
	this.emailListBox.Items.Clear();
	string[][] mails = contact.getEmails();
	for(int i = 0; i < mails.Length; i++)
		this.emailListBox.Items.Add(new Mail(mails[i][0], mails[i][1]));

	femaleRadioButton.Checked = false;
	maleRadioButton.Checked = false;
	if (contact.getSex().Equals("M"))
		maleRadioButton.Checked = true;
	else
		femaleRadioButton.Checked = true;

	sonsListBox.Items.Clear();
	string[] sons = contact.getSons();
	for(int i = 0; i < sons.Length; i++)
		this.sonsListBox.Items.Add(sons[i]);
}

private 
void seekButton_Click(object sender, System.EventArgs e){
	ContactSearchForm contactSearchForm = new ContactSearchForm("Contacts");
	contactSearchForm.ShowDialog();

	if (contactSearchForm.DialogResult == DialogResult.OK){
		string[] v = contactSearchForm.getSelected();
		string id = v[0];
		this.contact = coreFactory.readContact(int.Parse(id));
		objectToScreen();
	}
}

private 
void pictureBox_Click(object sender, System.EventArgs e){
}

private 
class Mail{

public 
Mail(string email, string defaultMail){
	this.email = email;
	this.defaultMail = defaultMail;
}

public string email;
public string defaultMail;

public override
string ToString(){
	return email;
}

}

private 
bool validMail(){
	if (emailTextBox.Text.Equals(""))
		return false;
	if (emailTextBox.Text.IndexOf("@") == -1)
		return false;
	if (emailTextBox.Text.IndexOf(".") == -1)
		return false;
	if (emailTextBox.Text.IndexOf("@.") > -1)
		return false;
	if (emailTextBox.Text[emailTextBox.Text.Length - 1] == '.')
		return false;

	for(int i = 0; i < emailListBox.Items.Count; i++){
		Mail mail = (Mail)emailListBox.Items[i];
		if (mail.email.Equals(emailTextBox.Text))
			return false;
	}

	return true;
}

private 
void addMailButton_Click(object sender, System.EventArgs e){
	if (validMail()){
		emailListBox.Items.Add(new Mail(emailTextBox.Text, "N"));
		emailTextBox.Text = "";
		emailTextBox.Focus();
	}else{
		MessageBox.Show("Invalid email address !");
		return;
	}
}

private 
void updateMailButton_Click(object sender, System.EventArgs e){
	object selected = emailListBox.SelectedItem;
	if (selected != null){
		Mail mail = (Mail)selected;
		mail.email = emailTextBox.Text;

		int where = emailListBox.SelectedIndex;
		emailListBox.Items.Remove(selected);
		emailListBox.Items.Insert(where, selected);
		
		emailTextBox.Focus();
	}
}

private 
void deleteMailButton_Click(object sender, System.EventArgs e){
	object selected = emailListBox.SelectedItem;
	if (selected != null){
		emailListBox.Items.Remove(selected);
		emailListBox.Refresh();
	}
}

private 
void emailListBox_SelectedValueChanged(object sender, System.EventArgs e){
	object selected = emailListBox.SelectedItem;
	if (selected != null){
		Mail mail = (Mail)selected;
		emailTextBox.Text = mail.email;
	}
}

private 
void button1_Click(object sender, System.EventArgs e){
	addSon();
}

private 
void addSon(){
	if (this.sonTextBox.Text.Trim().Equals(""))
		return;

	for(int i = 0; i < sonsListBox.Items.Count; i++){
		string son = (string)sonsListBox.Items[i];
		if (this.sonTextBox.Text.Trim().Equals(son)){
			MessageBox.Show("Son already added !!!");
			return;
		}
	}
	sonsListBox.Items.Add(this.sonTextBox.Text.Trim());
	sonTextBox.Text = "";
}

private 
void button2_Click(object sender, System.EventArgs e){
	removeSon();
}

private 
bool removeSon(){
	if (sonsListBox.SelectedIndex != -1){
		string son = (string)sonsListBox.SelectedItem;
		sonsListBox.Items.Remove(son);
		return true;
	}else
		return false;
}

private 
void button3_Click(object sender, System.EventArgs e){
	if (removeSon())
		addSon();
}

private 
void sonsListBox_SelectedValueChanged(object sender, System.EventArgs e){
	object obj = sonsListBox.SelectedItem;
	if (obj != null)
		sonTextBox.Text = (string)obj;
}

private 
void deleteButton_Click(object sender, System.EventArgs e){
	try{
		screenToObject();
		
		if (coreFactory.canDeleteContact(contact))
			coreFactory.deleteContact(contact);
		else
			MessageBox.Show("Sorry this contact cannot be deleted !!");

		MessageBox.Show("Contact deleted succesfully !!!");
		this.Close();
	}catch(NujitException ne){
		FormException formException = new FormException(ne);
		formException.Show();
	}
}


}

}
