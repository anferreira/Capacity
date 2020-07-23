using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.WinForms.Reports.ProductsReport;
using Nujit.NujitERP.WinForms.Reports.InventoryReport;
using Nujit.NujitERP.WinForms.SearchForms;


namespace Nujit.NujitERP.WinForms.Master{


public 
class ProductForm : System.Windows.Forms.Form{

private System.Windows.Forms.Button btnSeek;
private System.Windows.Forms.Label label1;
private System.Windows.Forms.Label label2;
private System.Windows.Forms.Label label3;
private System.Windows.Forms.Label label4;
private System.Windows.Forms.Label label5;
private System.Windows.Forms.Label label6;
private System.Windows.Forms.Label label7;
private System.Windows.Forms.Panel panel2;
private System.Windows.Forms.Label label11;
private System.Windows.Forms.Label label12;
private System.Windows.Forms.Label label13;
private System.Windows.Forms.Label label14;
private System.Windows.Forms.Label label15;
private System.Windows.Forms.Label label16;
private System.Windows.Forms.Label label17;
private System.Windows.Forms.Label label18;
private System.Windows.Forms.Label label19;
private System.Windows.Forms.Label label20;
private System.Windows.Forms.Label label21;
private System.Windows.Forms.GroupBox groupBox1;
private System.Windows.Forms.GroupBox groupBox2;
private System.Windows.Forms.GroupBox groupBox3;
private System.Windows.Forms.GroupBox groupBox4;
private System.Windows.Forms.GroupBox groupBox5;
private System.Windows.Forms.GroupBox groupBox6;
private System.Windows.Forms.CheckBox chBoxFam;
private System.Windows.Forms.Panel panel1;
private System.Windows.Forms.Button btnOk;
private System.Windows.Forms.Button btnCancel;
private System.Windows.Forms.Button btnInv;
private System.ComponentModel.Container components = null;

private System.Windows.Forms.TextBox tBoxVarFam;
private System.Windows.Forms.TextBox tBoxSeqLast;
private System.Windows.Forms.TextBox tBoxActIdLast;
private System.Windows.Forms.TextBox tBoxId;
private System.Windows.Forms.TextBox tBoxDes1;
private System.Windows.Forms.TextBox tBoxDes2;
private System.Windows.Forms.TextBox tBoxDes3;
private System.Windows.Forms.TextBox tBoxMinorGroup;
private System.Windows.Forms.TextBox tBoxMajorGroup;
private System.Windows.Forms.TextBox tBoxGlExp;
private System.Windows.Forms.TextBox tBoxGlDistr;
private System.Windows.Forms.TextBox tBoxMinorSales;
private System.Windows.Forms.TextBox tBoxMajorSales;
private System.Windows.Forms.TextBox tBoxAbcCode;

private Product product;
private System.Windows.Forms.Button btnDelete;
private System.Windows.Forms.CheckBox chBoxInvStatus;
private System.Windows.Forms.CheckBox chBoxPartType;
private System.Windows.Forms.Button btnReport;
private System.Windows.Forms.DateTimePicker dtpLastRevision;
private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
	private System.Windows.Forms.GroupBox groupBox7;
	private System.Windows.Forms.Label label8;
	private System.Windows.Forms.Label label9;
	private System.Windows.Forms.TextBox sizeTextBox;
	private System.Windows.Forms.TextBox unitTextBox;
    private System.Windows.Forms.TextBox tBoxProductCode;
    private System.Windows.Forms.Label label10;
private bool loading=false;


public 
ProductForm(){
	InitializeComponent();
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
/// <summary>
/// Required method for Designer support - do not modify
/// the contents of this method with the code editor.
/// </summary>
private 
	void InitializeComponent()
{
    this.btnSeek = new System.Windows.Forms.Button();
    this.tBoxVarFam = new System.Windows.Forms.TextBox();
    this.tBoxSeqLast = new System.Windows.Forms.TextBox();
    this.tBoxActIdLast = new System.Windows.Forms.TextBox();
    this.label1 = new System.Windows.Forms.Label();
    this.label2 = new System.Windows.Forms.Label();
    this.label3 = new System.Windows.Forms.Label();
    this.label4 = new System.Windows.Forms.Label();
    this.label5 = new System.Windows.Forms.Label();
    this.label6 = new System.Windows.Forms.Label();
    this.label7 = new System.Windows.Forms.Label();
    this.panel2 = new System.Windows.Forms.Panel();
    this.groupBox7 = new System.Windows.Forms.GroupBox();
    this.unitTextBox = new System.Windows.Forms.TextBox();
    this.sizeTextBox = new System.Windows.Forms.TextBox();
    this.label9 = new System.Windows.Forms.Label();
    this.label8 = new System.Windows.Forms.Label();
    this.dtpLastRevision = new System.Windows.Forms.DateTimePicker();
    this.chBoxPartType = new System.Windows.Forms.CheckBox();
    this.chBoxInvStatus = new System.Windows.Forms.CheckBox();
    this.groupBox6 = new System.Windows.Forms.GroupBox();
    this.chBoxFam = new System.Windows.Forms.CheckBox();
    this.tBoxId = new System.Windows.Forms.TextBox();
    this.groupBox5 = new System.Windows.Forms.GroupBox();
    this.groupBox4 = new System.Windows.Forms.GroupBox();
    this.tBoxDes1 = new System.Windows.Forms.TextBox();
    this.label19 = new System.Windows.Forms.Label();
    this.tBoxDes2 = new System.Windows.Forms.TextBox();
    this.label20 = new System.Windows.Forms.Label();
    this.label21 = new System.Windows.Forms.Label();
    this.tBoxDes3 = new System.Windows.Forms.TextBox();
    this.groupBox3 = new System.Windows.Forms.GroupBox();
    this.tBoxMinorGroup = new System.Windows.Forms.TextBox();
    this.tBoxMajorGroup = new System.Windows.Forms.TextBox();
    this.label13 = new System.Windows.Forms.Label();
    this.label12 = new System.Windows.Forms.Label();
    this.groupBox2 = new System.Windows.Forms.GroupBox();
    this.tBoxGlExp = new System.Windows.Forms.TextBox();
    this.tBoxGlDistr = new System.Windows.Forms.TextBox();
    this.label15 = new System.Windows.Forms.Label();
    this.label14 = new System.Windows.Forms.Label();
    this.groupBox1 = new System.Windows.Forms.GroupBox();
    this.label16 = new System.Windows.Forms.Label();
    this.label17 = new System.Windows.Forms.Label();
    this.tBoxMinorSales = new System.Windows.Forms.TextBox();
    this.tBoxMajorSales = new System.Windows.Forms.TextBox();
    this.tBoxAbcCode = new System.Windows.Forms.TextBox();
    this.label18 = new System.Windows.Forms.Label();
    this.label11 = new System.Windows.Forms.Label();
    this.panel1 = new System.Windows.Forms.Panel();
    this.btnReport = new System.Windows.Forms.Button();
    this.btnDelete = new System.Windows.Forms.Button();
    this.btnInv = new System.Windows.Forms.Button();
    this.btnCancel = new System.Windows.Forms.Button();
    this.btnOk = new System.Windows.Forms.Button();
    this.tBoxProductCode = new System.Windows.Forms.TextBox();
    this.label10 = new System.Windows.Forms.Label();
    this.panel2.SuspendLayout();
    this.groupBox7.SuspendLayout();
    this.groupBox6.SuspendLayout();
    this.groupBox5.SuspendLayout();
    this.groupBox4.SuspendLayout();
    this.groupBox3.SuspendLayout();
    this.groupBox2.SuspendLayout();
    this.groupBox1.SuspendLayout();
    this.panel1.SuspendLayout();
    this.SuspendLayout();
    // 
    // btnSeek
    // 
    this.btnSeek.Location = new System.Drawing.Point(208, 24);
    this.btnSeek.Name = "btnSeek";
    this.btnSeek.Size = new System.Drawing.Size(32, 16);
    this.btnSeek.TabIndex = 1;
    this.btnSeek.Text = "...";
    this.btnSeek.Click += new System.EventHandler(this.btnSeek_Click);
    // 
    // tBoxVarFam
    // 
    this.tBoxVarFam.Location = new System.Drawing.Point(400, 424);
    this.tBoxVarFam.MaxLength = 1;
    this.tBoxVarFam.Name = "tBoxVarFam";
    this.tBoxVarFam.TabIndex = 16;
    this.tBoxVarFam.Text = "";
    // 
    // tBoxSeqLast
    // 
    this.tBoxSeqLast.Location = new System.Drawing.Point(328, 16);
    this.tBoxSeqLast.Name = "tBoxSeqLast";
    this.tBoxSeqLast.TabIndex = 4;
    this.tBoxSeqLast.Text = "";
    // 
    // tBoxActIdLast
    // 
    this.tBoxActIdLast.Location = new System.Drawing.Point(88, 16);
    this.tBoxActIdLast.MaxLength = 10;
    this.tBoxActIdLast.Name = "tBoxActIdLast";
    this.tBoxActIdLast.TabIndex = 3;
    this.tBoxActIdLast.Text = "";
    // 
    // label1
    // 
    this.label1.Location = new System.Drawing.Point(16, -128);
    this.label1.Name = "label1";
    this.label1.Size = new System.Drawing.Size(100, 36);
    this.label1.TabIndex = 7;
    this.label1.Text = "Id";
    // 
    // label2
    // 
    this.label2.Location = new System.Drawing.Point(24, -96);
    this.label2.Name = "label2";
    this.label2.Size = new System.Drawing.Size(100, 36);
    this.label2.TabIndex = 8;
    this.label2.Text = "Des 1";
    // 
    // label3
    // 
    this.label3.Location = new System.Drawing.Point(16, -64);
    this.label3.Name = "label3";
    this.label3.Size = new System.Drawing.Size(100, 36);
    this.label3.TabIndex = 9;
    this.label3.Text = "Des 2";
    // 
    // label4
    // 
    this.label4.Location = new System.Drawing.Point(8, -32);
    this.label4.Name = "label4";
    this.label4.Size = new System.Drawing.Size(100, 32);
    this.label4.TabIndex = 10;
    this.label4.Text = "Des 3";
    // 
    // label5
    // 
    this.label5.Location = new System.Drawing.Point(320, 424);
    this.label5.Name = "label5";
    this.label5.Size = new System.Drawing.Size(64, 15);
    this.label5.TabIndex = 11;
    this.label5.Text = "Var Fam";
    // 
    // label6
    // 
    this.label6.Location = new System.Drawing.Point(240, 16);
    this.label6.Name = "label6";
    this.label6.Size = new System.Drawing.Size(56, 15);
    this.label6.TabIndex = 12;
    this.label6.Text = "Seq Last";
    // 
    // label7
    // 
    this.label7.Location = new System.Drawing.Point(16, 16);
    this.label7.Name = "label7";
    this.label7.Size = new System.Drawing.Size(64, 15);
    this.label7.TabIndex = 13;
    this.label7.Text = "Act ID Last";
    // 
    // panel2
    // 
    this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    this.panel2.Controls.Add(this.tBoxProductCode);
    this.panel2.Controls.Add(this.label10);
    this.panel2.Controls.Add(this.groupBox7);
    this.panel2.Controls.Add(this.dtpLastRevision);
    this.panel2.Controls.Add(this.chBoxPartType);
    this.panel2.Controls.Add(this.chBoxInvStatus);
    this.panel2.Controls.Add(this.groupBox6);
    this.panel2.Controls.Add(this.groupBox5);
    this.panel2.Controls.Add(this.groupBox4);
    this.panel2.Controls.Add(this.groupBox3);
    this.panel2.Controls.Add(this.groupBox2);
    this.panel2.Controls.Add(this.groupBox1);
    this.panel2.Controls.Add(this.tBoxAbcCode);
    this.panel2.Controls.Add(this.label18);
    this.panel2.Controls.Add(this.label11);
    this.panel2.Controls.Add(this.label2);
    this.panel2.Controls.Add(this.label5);
    this.panel2.Controls.Add(this.label4);
    this.panel2.Controls.Add(this.label1);
    this.panel2.Controls.Add(this.label3);
    this.panel2.Controls.Add(this.tBoxVarFam);
    this.panel2.Location = new System.Drawing.Point(16, 8);
    this.panel2.Name = "panel2";
    this.panel2.Size = new System.Drawing.Size(528, 512);
    this.panel2.TabIndex = 0;
    // 
    // groupBox7
    // 
    this.groupBox7.Controls.Add(this.unitTextBox);
    this.groupBox7.Controls.Add(this.sizeTextBox);
    this.groupBox7.Controls.Add(this.label9);
    this.groupBox7.Controls.Add(this.label8);
    this.groupBox7.Location = new System.Drawing.Point(312, 136);
    this.groupBox7.Name = "groupBox7";
    this.groupBox7.Size = new System.Drawing.Size(192, 96);
    this.groupBox7.TabIndex = 25;
    this.groupBox7.TabStop = false;
    this.groupBox7.Text = "Packages";
    // 
    // unitTextBox
    // 
    this.unitTextBox.Location = new System.Drawing.Point(72, 56);
    this.unitTextBox.MaxLength = 5;
    this.unitTextBox.Name = "unitTextBox";
    this.unitTextBox.TabIndex = 3;
    this.unitTextBox.Text = "";
    // 
    // sizeTextBox
    // 
    this.sizeTextBox.Location = new System.Drawing.Point(72, 32);
    this.sizeTextBox.Name = "sizeTextBox";
    this.sizeTextBox.TabIndex = 2;
    this.sizeTextBox.Text = "";
    // 
    // label9
    // 
    this.label9.Location = new System.Drawing.Point(16, 64);
    this.label9.Name = "label9";
    this.label9.Size = new System.Drawing.Size(32, 15);
    this.label9.TabIndex = 1;
    this.label9.Text = "Unit";
    // 
    // label8
    // 
    this.label8.Location = new System.Drawing.Point(16, 40);
    this.label8.Name = "label8";
    this.label8.Size = new System.Drawing.Size(32, 15);
    this.label8.TabIndex = 0;
    this.label8.Text = "Size";
    // 
    // dtpLastRevision
    // 
    this.dtpLastRevision.Location = new System.Drawing.Point(304, 464);
    this.dtpLastRevision.Name = "dtpLastRevision";
    this.dtpLastRevision.TabIndex = 19;
    // 
    // chBoxPartType
    // 
    this.chBoxPartType.Location = new System.Drawing.Point(40, 480);
    this.chBoxPartType.Name = "chBoxPartType";
    this.chBoxPartType.TabIndex = 18;
    this.chBoxPartType.Text = "Manufactured";
    // 
    // chBoxInvStatus
    // 
    this.chBoxInvStatus.Location = new System.Drawing.Point(40, 456);
    this.chBoxInvStatus.Name = "chBoxInvStatus";
    this.chBoxInvStatus.TabIndex = 17;
    this.chBoxInvStatus.Text = "Active";
    // 
    // groupBox6
    // 
    this.groupBox6.Controls.Add(this.chBoxFam);
    this.groupBox6.Controls.Add(this.tBoxId);
    this.groupBox6.Controls.Add(this.btnSeek);
    this.groupBox6.Location = new System.Drawing.Point(24, 8);
    this.groupBox6.Name = "groupBox6";
    this.groupBox6.Size = new System.Drawing.Size(480, 64);
    this.groupBox6.TabIndex = 0;
    this.groupBox6.TabStop = false;
    this.groupBox6.Text = "Identificacion";
    // 
    // chBoxFam
    // 
    this.chBoxFam.Location = new System.Drawing.Point(344, 32);
    this.chBoxFam.Name = "chBoxFam";
    this.chBoxFam.Size = new System.Drawing.Size(104, 16);
    this.chBoxFam.TabIndex = 2;
    this.chBoxFam.Text = "Family";
    // 
    // tBoxId
    // 
    this.tBoxId.Location = new System.Drawing.Point(16, 24);
    this.tBoxId.MaxLength = 40;
    this.tBoxId.Name = "tBoxId";
    this.tBoxId.Size = new System.Drawing.Size(184, 20);
    this.tBoxId.TabIndex = 0;
    this.tBoxId.Text = "";
    this.tBoxId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBoxId_KeyDown);
    this.tBoxId.TextChanged += new System.EventHandler(this.tBoxId_TextChanged);
    // 
    // groupBox5
    // 
    this.groupBox5.Controls.Add(this.tBoxSeqLast);
    this.groupBox5.Controls.Add(this.label6);
    this.groupBox5.Controls.Add(this.label7);
    this.groupBox5.Controls.Add(this.tBoxActIdLast);
    this.groupBox5.Location = new System.Drawing.Point(24, 72);
    this.groupBox5.Name = "groupBox5";
    this.groupBox5.Size = new System.Drawing.Size(480, 56);
    this.groupBox5.TabIndex = 1;
    this.groupBox5.TabStop = false;
    // 
    // groupBox4
    // 
    this.groupBox4.Controls.Add(this.tBoxDes1);
    this.groupBox4.Controls.Add(this.label19);
    this.groupBox4.Controls.Add(this.tBoxDes2);
    this.groupBox4.Controls.Add(this.label20);
    this.groupBox4.Controls.Add(this.label21);
    this.groupBox4.Controls.Add(this.tBoxDes3);
    this.groupBox4.Location = new System.Drawing.Point(24, 136);
    this.groupBox4.Name = "groupBox4";
    this.groupBox4.Size = new System.Drawing.Size(280, 96);
    this.groupBox4.TabIndex = 2;
    this.groupBox4.TabStop = false;
    this.groupBox4.Text = "Descriptions";
    // 
    // tBoxDes1
    // 
    this.tBoxDes1.Location = new System.Drawing.Point(32, 16);
    this.tBoxDes1.MaxLength = 40;
    this.tBoxDes1.Name = "tBoxDes1";
    this.tBoxDes1.Size = new System.Drawing.Size(232, 20);
    this.tBoxDes1.TabIndex = 5;
    this.tBoxDes1.Text = "";
    // 
    // label19
    // 
    this.label19.Location = new System.Drawing.Point(16, 16);
    this.label19.Name = "label19";
    this.label19.Size = new System.Drawing.Size(8, 15);
    this.label19.TabIndex = 37;
    this.label19.Text = "1";
    // 
    // tBoxDes2
    // 
    this.tBoxDes2.Location = new System.Drawing.Point(32, 40);
    this.tBoxDes2.MaxLength = 40;
    this.tBoxDes2.Name = "tBoxDes2";
    this.tBoxDes2.Size = new System.Drawing.Size(232, 20);
    this.tBoxDes2.TabIndex = 6;
    this.tBoxDes2.Text = "";
    // 
    // label20
    // 
    this.label20.Location = new System.Drawing.Point(16, 40);
    this.label20.Name = "label20";
    this.label20.Size = new System.Drawing.Size(8, 15);
    this.label20.TabIndex = 38;
    this.label20.Text = "2";
    // 
    // label21
    // 
    this.label21.Location = new System.Drawing.Point(16, 64);
    this.label21.Name = "label21";
    this.label21.Size = new System.Drawing.Size(8, 15);
    this.label21.TabIndex = 39;
    this.label21.Text = "3";
    // 
    // tBoxDes3
    // 
    this.tBoxDes3.Location = new System.Drawing.Point(32, 64);
    this.tBoxDes3.MaxLength = 40;
    this.tBoxDes3.Name = "tBoxDes3";
    this.tBoxDes3.Size = new System.Drawing.Size(232, 20);
    this.tBoxDes3.TabIndex = 7;
    this.tBoxDes3.Text = "";
    // 
    // groupBox3
    // 
    this.groupBox3.Controls.Add(this.tBoxMinorGroup);
    this.groupBox3.Controls.Add(this.tBoxMajorGroup);
    this.groupBox3.Controls.Add(this.label13);
    this.groupBox3.Controls.Add(this.label12);
    this.groupBox3.Location = new System.Drawing.Point(24, 328);
    this.groupBox3.Name = "groupBox3";
    this.groupBox3.Size = new System.Drawing.Size(480, 56);
    this.groupBox3.TabIndex = 5;
    this.groupBox3.TabStop = false;
    this.groupBox3.Text = "Groups";
    // 
    // tBoxMinorGroup
    // 
    this.tBoxMinorGroup.Location = new System.Drawing.Point(312, 24);
    this.tBoxMinorGroup.MaxLength = 20;
    this.tBoxMinorGroup.Name = "tBoxMinorGroup";
    this.tBoxMinorGroup.Size = new System.Drawing.Size(152, 20);
    this.tBoxMinorGroup.TabIndex = 13;
    this.tBoxMinorGroup.Text = "";
    // 
    // tBoxMajorGroup
    // 
    this.tBoxMajorGroup.Location = new System.Drawing.Point(64, 24);
    this.tBoxMajorGroup.MaxLength = 20;
    this.tBoxMajorGroup.Name = "tBoxMajorGroup";
    this.tBoxMajorGroup.Size = new System.Drawing.Size(152, 20);
    this.tBoxMajorGroup.TabIndex = 12;
    this.tBoxMajorGroup.Text = "";
    // 
    // label13
    // 
    this.label13.Location = new System.Drawing.Point(256, 24);
    this.label13.Name = "label13";
    this.label13.Size = new System.Drawing.Size(40, 15);
    this.label13.TabIndex = 19;
    this.label13.Text = "Minor";
    // 
    // label12
    // 
    this.label12.Location = new System.Drawing.Point(16, 24);
    this.label12.Name = "label12";
    this.label12.Size = new System.Drawing.Size(40, 15);
    this.label12.TabIndex = 18;
    this.label12.Text = "Major";
    // 
    // groupBox2
    // 
    this.groupBox2.Controls.Add(this.tBoxGlExp);
    this.groupBox2.Controls.Add(this.tBoxGlDistr);
    this.groupBox2.Controls.Add(this.label15);
    this.groupBox2.Controls.Add(this.label14);
    this.groupBox2.Location = new System.Drawing.Point(272, 240);
    this.groupBox2.Name = "groupBox2";
    this.groupBox2.Size = new System.Drawing.Size(232, 80);
    this.groupBox2.TabIndex = 4;
    this.groupBox2.TabStop = false;
    this.groupBox2.Text = "GL";
    // 
    // tBoxGlExp
    // 
    this.tBoxGlExp.Location = new System.Drawing.Point(64, 24);
    this.tBoxGlExp.MaxLength = 20;
    this.tBoxGlExp.Name = "tBoxGlExp";
    this.tBoxGlExp.Size = new System.Drawing.Size(152, 20);
    this.tBoxGlExp.TabIndex = 10;
    this.tBoxGlExp.Text = "";
    // 
    // tBoxGlDistr
    // 
    this.tBoxGlDistr.Location = new System.Drawing.Point(64, 48);
    this.tBoxGlDistr.MaxLength = 20;
    this.tBoxGlDistr.Name = "tBoxGlDistr";
    this.tBoxGlDistr.Size = new System.Drawing.Size(152, 20);
    this.tBoxGlDistr.TabIndex = 11;
    this.tBoxGlDistr.Text = "";
    // 
    // label15
    // 
    this.label15.Location = new System.Drawing.Point(8, 48);
    this.label15.Name = "label15";
    this.label15.Size = new System.Drawing.Size(32, 15);
    this.label15.TabIndex = 21;
    this.label15.Text = "Distr";
    // 
    // label14
    // 
    this.label14.Location = new System.Drawing.Point(8, 24);
    this.label14.Name = "label14";
    this.label14.Size = new System.Drawing.Size(40, 15);
    this.label14.TabIndex = 20;
    this.label14.Text = "Exp";
    // 
    // groupBox1
    // 
    this.groupBox1.Controls.Add(this.label16);
    this.groupBox1.Controls.Add(this.label17);
    this.groupBox1.Controls.Add(this.tBoxMinorSales);
    this.groupBox1.Controls.Add(this.tBoxMajorSales);
    this.groupBox1.Location = new System.Drawing.Point(24, 240);
    this.groupBox1.Name = "groupBox1";
    this.groupBox1.Size = new System.Drawing.Size(232, 80);
    this.groupBox1.TabIndex = 3;
    this.groupBox1.TabStop = false;
    this.groupBox1.Text = "Sales";
    // 
    // label16
    // 
    this.label16.Location = new System.Drawing.Point(8, 24);
    this.label16.Name = "label16";
    this.label16.Size = new System.Drawing.Size(40, 15);
    this.label16.TabIndex = 22;
    this.label16.Text = "Major";
    // 
    // label17
    // 
    this.label17.Location = new System.Drawing.Point(8, 48);
    this.label17.Name = "label17";
    this.label17.Size = new System.Drawing.Size(40, 15);
    this.label17.TabIndex = 23;
    this.label17.Text = "Minor";
    // 
    // tBoxMinorSales
    // 
    this.tBoxMinorSales.Location = new System.Drawing.Point(64, 48);
    this.tBoxMinorSales.MaxLength = 20;
    this.tBoxMinorSales.Name = "tBoxMinorSales";
    this.tBoxMinorSales.Size = new System.Drawing.Size(152, 20);
    this.tBoxMinorSales.TabIndex = 9;
    this.tBoxMinorSales.Text = "";
    // 
    // tBoxMajorSales
    // 
    this.tBoxMajorSales.Location = new System.Drawing.Point(64, 24);
    this.tBoxMajorSales.MaxLength = 20;
    this.tBoxMajorSales.Name = "tBoxMajorSales";
    this.tBoxMajorSales.Size = new System.Drawing.Size(152, 20);
    this.tBoxMajorSales.TabIndex = 8;
    this.tBoxMajorSales.Text = "";
    // 
    // tBoxAbcCode
    // 
    this.tBoxAbcCode.Location = new System.Drawing.Point(152, 424);
    this.tBoxAbcCode.MaxLength = 1;
    this.tBoxAbcCode.Name = "tBoxAbcCode";
    this.tBoxAbcCode.TabIndex = 15;
    this.tBoxAbcCode.Text = "";
    // 
    // label18
    // 
    this.label18.Location = new System.Drawing.Point(224, 464);
    this.label18.Name = "label18";
    this.label18.Size = new System.Drawing.Size(72, 15);
    this.label18.TabIndex = 24;
    this.label18.Text = "Last Revision";
    // 
    // label11
    // 
    this.label11.Location = new System.Drawing.Point(40, 424);
    this.label11.Name = "label11";
    this.label11.Size = new System.Drawing.Size(100, 24);
    this.label11.TabIndex = 17;
    this.label11.Text = "ABC Code";
    this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
    // 
    // panel1
    // 
    this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
    this.panel1.Controls.Add(this.btnReport);
    this.panel1.Controls.Add(this.btnDelete);
    this.panel1.Controls.Add(this.btnInv);
    this.panel1.Controls.Add(this.btnCancel);
    this.panel1.Controls.Add(this.btnOk);
    this.panel1.Location = new System.Drawing.Point(16, 528);
    this.panel1.Name = "panel1";
    this.panel1.Size = new System.Drawing.Size(528, 40);
    this.panel1.TabIndex = 1;
    // 
    // btnReport
    // 
    this.btnReport.Location = new System.Drawing.Point(96, 8);
    this.btnReport.Name = "btnReport";
    this.btnReport.TabIndex = 24;
    this.btnReport.Text = "Report";
    this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
    // 
    // btnDelete
    // 
    this.btnDelete.Enabled = false;
    this.btnDelete.Location = new System.Drawing.Point(352, 8);
    this.btnDelete.Name = "btnDelete";
    this.btnDelete.TabIndex = 20;
    this.btnDelete.Text = "Delete";
    this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
    // 
    // btnInv
    // 
    this.btnInv.Enabled = false;
    this.btnInv.Location = new System.Drawing.Point(16, 8);
    this.btnInv.Name = "btnInv";
    this.btnInv.TabIndex = 22;
    this.btnInv.Text = "Inventory";
    this.btnInv.Click += new System.EventHandler(this.btnInv_Click);
    // 
    // btnCancel
    // 
    this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
    this.btnCancel.Location = new System.Drawing.Point(432, 8);
    this.btnCancel.Name = "btnCancel";
    this.btnCancel.TabIndex = 21;
    this.btnCancel.Text = "Close";
    this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
    // 
    // btnOk
    // 
    this.btnOk.Location = new System.Drawing.Point(272, 8);
    this.btnOk.Name = "btnOk";
    this.btnOk.TabIndex = 19;
    this.btnOk.Text = "Save";
    this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
    // 
    // tBoxProductCode
    // 
    this.tBoxProductCode.Location = new System.Drawing.Point(152, 392);
    this.tBoxProductCode.MaxLength = 40;
    this.tBoxProductCode.Name = "tBoxProductCode";
    this.tBoxProductCode.Size = new System.Drawing.Size(352, 20);
    this.tBoxProductCode.TabIndex = 14;
    this.tBoxProductCode.Text = "";
    // 
    // label10
    // 
    this.label10.Location = new System.Drawing.Point(40, 392);
    this.label10.Name = "label10";
    this.label10.Size = new System.Drawing.Size(100, 24);
    this.label10.TabIndex = 27;
    this.label10.Text = "Product Code";
    this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
    // 
    // ProductForm
    // 
    this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
    this.CancelButton = this.btnCancel;
    this.ClientSize = new System.Drawing.Size(560, 574);
    this.Controls.Add(this.panel1);
    this.Controls.Add(this.panel2);
    this.Name = "ProductForm";
    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
    this.Text = "Product";
    this.Load += new System.EventHandler(this.ProductForm_Load);
    this.panel2.ResumeLayout(false);
    this.groupBox7.ResumeLayout(false);
    this.groupBox6.ResumeLayout(false);
    this.groupBox5.ResumeLayout(false);
    this.groupBox4.ResumeLayout(false);
    this.groupBox3.ResumeLayout(false);
    this.groupBox2.ResumeLayout(false);
    this.groupBox1.ResumeLayout(false);
    this.panel1.ResumeLayout(false);
    this.ResumeLayout(false);

}
#endregion

private	
void objectToScreen(string id){
	if (coreFactory.existsProduct(id)){
		product = coreFactory.readProduct(id);
		tBoxVarFam.Text = product.getVarFam().Trim();
		tBoxSeqLast.Text = product.getSeqLast().ToString().Trim();
		tBoxActIdLast.Text = product.getActIDLast().Trim();
		tBoxId.Text = product.getProdID().Trim();
		tBoxDes1.Text = product.getDes1().Trim();
		tBoxDes2.Text = product.getDes2().Trim();
		tBoxDes3.Text = product.getDes3().Trim();
		tBoxMinorGroup.Text = product.getMinorGroup().Trim();
		tBoxMajorGroup.Text = product.getMajorGroup().Trim();
		tBoxGlExp.Text = product.getGLExp().Trim();
		tBoxGlDistr.Text = product.getGLDistr().Trim();
		tBoxMinorSales.Text = product.getMinorSales().Trim();
		tBoxMajorSales.Text = product.getMajorSales().Trim();
        try{
		    dtpLastRevision.Value = product.getLastRevision();
        } catch {
            dtpLastRevision.Value = DateUtil.MinValue; //AF 2018/09/28 ,issue difference between DatTime.MinValue=0001 vs Picker.MinValue=1753
        }

		tBoxAbcCode.Text = product.getABCCode();
		sizeTextBox.Text = product.getStdPackSize().ToString();
		unitTextBox.Text = product.getStdPackUnit();

		chBoxFam.Checked = false;
		if (product.getFamProd().Equals("F"))
			chBoxFam.Checked = true;

		chBoxInvStatus.Checked = false;
		if (product.getInvStatus().Equals("A"))
			chBoxInvStatus.Checked = true;

		chBoxPartType.Checked = false;
		if (product.getPartType().Equals("M"))
			chBoxPartType.Checked = true;
			
		tBoxProductCode.Text = product.getProdCode();
	}else{
		if(MessageBox.Show("The product : " + id + " was not found\nDo you want to search it?","Nujit",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes){
			btnSeek_Click(this,null);
		}
	}
}

private
void screenToObject(){
	product.setProdID(tBoxId.Text);
	product.setVarFam(tBoxVarFam.Text);
	product.setSeqLast(int.Parse(tBoxSeqLast.Text));
	product.setActIDLast(tBoxActIdLast.Text);
	product.setDes1(tBoxDes1.Text);
	product.setDes2(tBoxDes2.Text);
	product.setDes3(tBoxDes3.Text);
	product.setMinorGroup(tBoxMinorGroup.Text);
	product.setMajorGroup(tBoxMajorGroup.Text);
	product.setGLExp(tBoxGlExp.Text);
	product.setGLDistr(tBoxGlDistr.Text);
	product.setMinorSales(tBoxMinorSales.Text);
	product.setMajorSales(tBoxMajorSales.Text);
	product.setLastRevision(dtpLastRevision.Value);
	product.setABCCode(tBoxAbcCode.Text);
	product.setStdPackSize(decimal.Parse(sizeTextBox.Text));
	product.setStdPackUnit(unitTextBox.Text);

	product.setFamProd("P");
	if (chBoxFam.Checked)
		product.setFamProd("F");

	product.setInvStatus("I");
	if (chBoxInvStatus.Checked)
		product.setInvStatus("A");

	product.setPartType("P");
	if (chBoxPartType.Checked)
		product.setPartType("M");
    
    product.setProdCode(tBoxProductCode.Text);

}

private 
void btnOk_Click(object sender, System.EventArgs e){
	if (validData()){
		bool ok;
		if (product == null)
			ok = addProduct();
		else
			ok = updateProduct();

		if (ok)
			Close();
	}
}

private 
void btnCancel_Click(object sender, System.EventArgs e){
	Close();
}

private 
bool addProduct(){
	if (! existProduct(tBoxId.Text.Trim())){

		product = coreFactory.createProduct();
		screenToObject();

		try{
			coreFactory.writeProduct(product);
			return true;
		}catch(NujitException ne){
			FormException formException = new FormException(ne);
			formException.ShowDialog();
			return false;
		}
	}else{
		MessageBox.Show("Already exist a product named "+tBoxId.Text.Trim(),"Nujit",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
		return false;
	}
}

private 
bool existProduct(string id){
	return coreFactory.existsProduct(id);
}

private 
bool updateProduct(){
	screenToObject();
	try{
		coreFactory.updateProduct(product);
		return true;
	}catch(NujitException ne){
		FormException formException = new FormException(ne);
		formException.ShowDialog();
		return false;
	}
}

private 
bool deleteProduct(){
	if (coreFactory.existsProduct(tBoxId.Text)){
		try{
			product = coreFactory.readProduct(tBoxId.Text);
			coreFactory.deleteProduct(product);
			return true;
		}catch(NujitException ne){
			FormException formException = new FormException(ne);
			formException.ShowDialog();
			return false;
		}
	}else{
		MessageBox.Show("The product not exists","Nujit",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
		return false;
	}
}

private	
bool validData(){
	if ((tBoxId.Text == null) || (tBoxId.Text.Equals(""))){
		MessageBox.Show("The Prod Id field cannot be null");
		return false;
	}

	if ((tBoxSeqLast.Text == null) || (tBoxSeqLast.Text.Equals(""))){
		MessageBox.Show("The Seq Last field cannot be null");
		return false;
	}else{
		try{
			int.Parse(tBoxSeqLast.Text);
		}catch{
			MessageBox.Show("The Seq Last field should be integer");
			return false;
		}
	}

	if ((tBoxMinorGroup.Text == null) || (tBoxMinorGroup.Text.Equals(""))){
		MessageBox.Show("The Minor Group field cannot be null");
		return false;
	}

	if ((tBoxMajorGroup.Text == null) || (tBoxMajorGroup.Text.Equals(""))){
		MessageBox.Show("The Major Group field cannot be null");
		return false;
	}

	if ((tBoxMinorSales.Text == null) || (tBoxMinorSales.Text.Equals(""))){
		MessageBox.Show("The Minor Sales field cannot be null");
		return false;
	}

	if ((tBoxMajorSales.Text == null) || (tBoxMajorSales.Text.Equals(""))){
		MessageBox.Show("The Major Sales field cannot be null");
		return false;
	}

	if (dtpLastRevision.Value > System.DateTime.Today){
		MessageBox.Show("The Last Revision date can be less or equals that today");
		return false;
	}

	if ((tBoxGlExp.Text == null) || (tBoxGlExp.Text.Equals(""))){
		MessageBox.Show("The Gl Exp field cannot be null");
		return false;
	}

	if ((tBoxGlDistr.Text == null) || (tBoxGlDistr.Text.Equals(""))){
		MessageBox.Show("The Gl Distr field cannot be null");
		return false;
	}

	return true;
}

private 
void tBoxId_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e){
	if (e.KeyCode.ToString().Equals("Enter")){
		if (product == null){
			objectToScreen(tBoxId.Text);
		}
	}
}

private 
void btnDelete_Click(object sender, System.EventArgs e){
	DialogResult deleteConfirm = MessageBox.Show("Remove this item ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
	if (deleteConfirm == DialogResult.No)
		return;

	if (deleteProduct())
		Close();
}

private 
void btnReport_Click(object sender, System.EventArgs e){
	SelectProductForm selectProduct = new SelectProductForm();
	selectProduct.ShowDialog();
}

private 
void ProductForm_Load(object sender, System.EventArgs e){
	dtpLastRevision.Value = DateTime.Today;
}

private 
void btnSeek_Click(object sender, System.EventArgs e){
	ProductSearchForm productSearchForm = new ProductSearchForm("Product search",tBoxId.Text.Trim(),true);
	productSearchForm.ShowDialog();

	if (productSearchForm.DialogResult == DialogResult.OK){
		string[] v = productSearchForm.getSelected();
		string id = v[0];
		loading=true;
		objectToScreen(id);
		loading=false;
		btnDelete.Enabled=true;
		btnInv.Enabled=true;
		btnOk.Text="Update";
	}
}

private 
void tBoxId_TextChanged(object sender, System.EventArgs e){
	if (product != null && !loading){
		btnOk.Text = "Save";
		btnDelete.Enabled = false;
		btnInv.Enabled = false;
		product = null;
		MessageBox.Show("If you change de Product Id, you are creating a new product","Nujit",MessageBoxButtons.OK,MessageBoxIcon.Information);
	}
}

private 
void btnInv_Click(object sender, System.EventArgs e){
	this.Cursor = Cursors.WaitCursor;
	DataSet dsInventory = generateDataSetInventory();
	InventoryReport inventoryReport = new InventoryReport(this.tBoxId.Text,dsInventory);
	this.Cursor = Cursors.Default;
	inventoryReport.ShowDialog();
}


private 
DataSet generateDataSetInventory(){
	DataTable dataTable = new DataTable();
	DataRow dataRow;

	dataTable.TableName = "inventory";
	dataTable.Columns.Add(new DataColumn("IPL_ProdID", typeof(string)));
	dataTable.Columns.Add(new DataColumn("IPL_Seq", typeof(string)));
	dataTable.Columns.Add(new DataColumn("IPL_StkLoc", typeof(string)));
	dataTable.Columns.Add(new DataColumn("IPL_ActID", typeof(string)));
	dataTable.Columns.Add(new DataColumn("IPL_LotID", typeof(string)));
	dataTable.Columns.Add(new DataColumn("IPL_MasPrOrd", typeof(string)));
	dataTable.Columns.Add(new DataColumn("IPL_PrOrd", typeof(string)));
	dataTable.Columns.Add(new DataColumn("IPL_Qoh", typeof(string)));
	dataTable.Columns.Add(new DataColumn("IPL_QohAvail", typeof(string)));
	dataTable.Columns.Add(new DataColumn("IPL_Uom", typeof(string)));
	dataTable.Columns.Add(new DataColumn("IPL_Qoh2", typeof(string)));
	dataTable.Columns.Add(new DataColumn("IPL_QohAvail2", typeof(string)));
	dataTable.Columns.Add(new DataColumn("IPL_Uom2", typeof(string)));
	dataTable.Columns.Add(new DataColumn("IPL_Prod2", typeof(string)));
	dataTable.Columns.Add(new DataColumn("PFS_Des1", typeof(string)));							

	string[][] vec = coreFactory.getInventoryReport(this.tBoxId.Text);
	for(int x = 0; x < vec.Length; x++){
		dataRow = dataTable.NewRow();
		dataRow.ItemArray = vec[x];
		dataTable.Rows.Add(dataRow);
	}

	DataSet inventoryReportDataSet = new DataSet();
	inventoryReportDataSet.Tables.Add(dataTable);
	return inventoryReportDataSet;
}

   
	


} // class

} // namespace
