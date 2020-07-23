using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Nujit.NujitERP.WinForms.GridScheduling.Tooling{

public 
class ToolScheduleSeq : System.Windows.Forms.Form{

private System.Windows.Forms.Label label1;
private System.Windows.Forms.Label label2;
private System.Windows.Forms.Label label3;
private System.Windows.Forms.Label label4;
private System.Windows.Forms.Label label5;
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
private System.Windows.Forms.GroupBox groupBox1;
private System.Windows.Forms.GroupBox groupBox2;
private System.Windows.Forms.TextBox textBox1;
private System.Windows.Forms.TextBox textBox2;
private System.Windows.Forms.TextBox textBox3;
private System.Windows.Forms.TextBox textBox4;
private System.Windows.Forms.TextBox textBox5;
private System.Windows.Forms.TextBox textBox6;
private System.Windows.Forms.TextBox textBox7;
private System.Windows.Forms.TextBox textBox8;
private System.Windows.Forms.TextBox textBox9;
private System.Windows.Forms.TextBox textBox10;
private System.Windows.Forms.TextBox textBox11;
private System.Windows.Forms.TextBox textBox12;
private System.Windows.Forms.TextBox textBox13;
private System.Windows.Forms.TextBox textBox14;
private System.Windows.Forms.TextBox textBox15;
private System.Windows.Forms.TextBox textBox16;
private System.Windows.Forms.TextBox textBox18;
private System.Windows.Forms.TextBox textBox19;
private System.Windows.Forms.TextBox textBox20;
private System.Windows.Forms.TextBox textBox17;
private System.Windows.Forms.TextBox textBox21;
private System.Windows.Forms.TextBox textBox22;
private System.Windows.Forms.TextBox textBox23;
private System.Windows.Forms.TextBox textBox24;
private System.Windows.Forms.TextBox textBox25;
private System.Windows.Forms.Label label18;
private System.Windows.Forms.Label label19;
private System.Windows.Forms.Label label20;
private System.Windows.Forms.Label label21;
private System.Windows.Forms.Label label22;
private System.Windows.Forms.Label label23;
private System.Windows.Forms.Label label24;
private System.Windows.Forms.Label label25;
private System.Windows.Forms.GroupBox groupBox3;
/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;

private DataTable dataTable = new DataTable();
	private System.Windows.Forms.DataGrid grid;
	private System.Windows.Forms.Button reviewButton;
	private System.Windows.Forms.Button okButton;
	private System.Windows.Forms.Button commitButton;
private DataView dataView;

public 
ToolScheduleSeq(){
	InitializeComponent();

	// TODO: Add any constructor code after InitializeComponent call
	initializeItemsGrid();

}

protected override void Dispose(bool disposing){
	if (disposing){
		if(components != null){
			components.Dispose();
		}
	}
	base.Dispose(disposing);
}

#region Windows Form Designer generated code

private void InitializeComponent(){
	this.label1 = new System.Windows.Forms.Label();
	this.label2 = new System.Windows.Forms.Label();
	this.label3 = new System.Windows.Forms.Label();
	this.reviewButton = new System.Windows.Forms.Button();
	this.okButton = new System.Windows.Forms.Button();
	this.commitButton = new System.Windows.Forms.Button();
	this.label4 = new System.Windows.Forms.Label();
	this.label5 = new System.Windows.Forms.Label();
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
	this.groupBox1 = new System.Windows.Forms.GroupBox();
	this.textBox3 = new System.Windows.Forms.TextBox();
	this.textBox2 = new System.Windows.Forms.TextBox();
	this.textBox1 = new System.Windows.Forms.TextBox();
	this.groupBox2 = new System.Windows.Forms.GroupBox();
	this.label20 = new System.Windows.Forms.Label();
	this.label21 = new System.Windows.Forms.Label();
	this.label22 = new System.Windows.Forms.Label();
	this.label23 = new System.Windows.Forms.Label();
	this.label24 = new System.Windows.Forms.Label();
	this.label25 = new System.Windows.Forms.Label();
	this.label18 = new System.Windows.Forms.Label();
	this.label19 = new System.Windows.Forms.Label();
	this.textBox17 = new System.Windows.Forms.TextBox();
	this.textBox21 = new System.Windows.Forms.TextBox();
	this.textBox22 = new System.Windows.Forms.TextBox();
	this.textBox23 = new System.Windows.Forms.TextBox();
	this.textBox24 = new System.Windows.Forms.TextBox();
	this.textBox25 = new System.Windows.Forms.TextBox();
	this.textBox18 = new System.Windows.Forms.TextBox();
	this.textBox19 = new System.Windows.Forms.TextBox();
	this.textBox20 = new System.Windows.Forms.TextBox();
	this.textBox15 = new System.Windows.Forms.TextBox();
	this.textBox16 = new System.Windows.Forms.TextBox();
	this.textBox14 = new System.Windows.Forms.TextBox();
	this.textBox13 = new System.Windows.Forms.TextBox();
	this.textBox12 = new System.Windows.Forms.TextBox();
	this.textBox11 = new System.Windows.Forms.TextBox();
	this.textBox10 = new System.Windows.Forms.TextBox();
	this.textBox9 = new System.Windows.Forms.TextBox();
	this.textBox8 = new System.Windows.Forms.TextBox();
	this.textBox7 = new System.Windows.Forms.TextBox();
	this.textBox6 = new System.Windows.Forms.TextBox();
	this.textBox5 = new System.Windows.Forms.TextBox();
	this.textBox4 = new System.Windows.Forms.TextBox();
	this.groupBox3 = new System.Windows.Forms.GroupBox();
	this.grid = new System.Windows.Forms.DataGrid();
	this.groupBox1.SuspendLayout();
	this.groupBox2.SuspendLayout();
	this.groupBox3.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
	this.SuspendLayout();
	// 
	// label1
	// 
	this.label1.Location = new System.Drawing.Point(24, 24);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(100, 14);
	this.label1.TabIndex = 0;
	this.label1.Text = "Order";
	// 
	// label2
	// 
	this.label2.Location = new System.Drawing.Point(24, 48);
	this.label2.Name = "label2";
	this.label2.Size = new System.Drawing.Size(100, 14);
	this.label2.TabIndex = 1;
	this.label2.Text = "Item";
	// 
	// label3
	// 
	this.label3.Location = new System.Drawing.Point(24, 72);
	this.label3.Name = "label3";
	this.label3.Size = new System.Drawing.Size(100, 14);
	this.label3.TabIndex = 2;
	this.label3.Text = "Release";
	// 
	// reviewButton
	// 
	this.reviewButton.Location = new System.Drawing.Point(776, 16);
	this.reviewButton.Name = "reviewButton";
	this.reviewButton.TabIndex = 3;
	this.reviewButton.Text = "Review";
	// 
	// okButton
	// 
	this.okButton.Location = new System.Drawing.Point(776, 40);
	this.okButton.Name = "okButton";
	this.okButton.TabIndex = 4;
	this.okButton.Text = "Ok";
	this.okButton.Click += new System.EventHandler(this.okButton_Click);
	// 
	// commitButton
	// 
	this.commitButton.Location = new System.Drawing.Point(776, 64);
	this.commitButton.Name = "commitButton";
	this.commitButton.TabIndex = 5;
	this.commitButton.Text = "Commit";
	// 
	// label4
	// 
	this.label4.Location = new System.Drawing.Point(24, 32);
	this.label4.Name = "label4";
	this.label4.Size = new System.Drawing.Size(100, 14);
	this.label4.TabIndex = 6;
	this.label4.Text = "Customer #";
	// 
	// label5
	// 
	this.label5.Location = new System.Drawing.Point(24, 54);
	this.label5.Name = "label5";
	this.label5.Size = new System.Drawing.Size(100, 14);
	this.label5.TabIndex = 7;
	this.label5.Text = "Customer Name";
	// 
	// label6
	// 
	this.label6.Location = new System.Drawing.Point(24, 76);
	this.label6.Name = "label6";
	this.label6.Size = new System.Drawing.Size(104, 14);
	this.label6.TabIndex = 8;
	this.label6.Text = "Promise Date/Time";
	// 
	// label7
	// 
	this.label7.Location = new System.Drawing.Point(24, 98);
	this.label7.Name = "label7";
	this.label7.Size = new System.Drawing.Size(100, 14);
	this.label7.TabIndex = 9;
	this.label7.Text = "Date Requested";
	// 
	// label8
	// 
	this.label8.Location = new System.Drawing.Point(24, 120);
	this.label8.Name = "label8";
	this.label8.Size = new System.Drawing.Size(100, 14);
	this.label8.TabIndex = 10;
	this.label8.Text = "Quantity Req";
	// 
	// label9
	// 
	this.label9.Location = new System.Drawing.Point(24, 142);
	this.label9.Name = "label9";
	this.label9.Size = new System.Drawing.Size(100, 14);
	this.label9.TabIndex = 11;
	this.label9.Text = "Purchase Order";
	// 
	// label10
	// 
	this.label10.Location = new System.Drawing.Point(24, 164);
	this.label10.Name = "label10";
	this.label10.Size = new System.Drawing.Size(120, 14);
	this.label10.TabIndex = 12;
	this.label10.Text = "Customer Part Number";
	// 
	// label11
	// 
	this.label11.Location = new System.Drawing.Point(24, 186);
	this.label11.Name = "label11";
	this.label11.Size = new System.Drawing.Size(100, 14);
	this.label11.TabIndex = 13;
	this.label11.Text = "Product ID";
	// 
	// label12
	// 
	this.label12.Location = new System.Drawing.Point(24, 208);
	this.label12.Name = "label12";
	this.label12.Size = new System.Drawing.Size(100, 14);
	this.label12.TabIndex = 14;
	this.label12.Text = "Description";
	// 
	// label13
	// 
	this.label13.Location = new System.Drawing.Point(352, 24);
	this.label13.Name = "label13";
	this.label13.Size = new System.Drawing.Size(104, 14);
	this.label13.TabIndex = 15;
	this.label13.Text = "Shipping Date/Time";
	// 
	// label14
	// 
	this.label14.Location = new System.Drawing.Point(352, 48);
	this.label14.Name = "label14";
	this.label14.Size = new System.Drawing.Size(100, 14);
	this.label14.TabIndex = 16;
	this.label14.Text = "Date Received";
	// 
	// label15
	// 
	this.label15.Location = new System.Drawing.Point(352, 72);
	this.label15.Name = "label15";
	this.label15.Size = new System.Drawing.Size(100, 14);
	this.label15.TabIndex = 17;
	this.label15.Text = "Order Type";
	// 
	// label16
	// 
	this.label16.Location = new System.Drawing.Point(352, 96);
	this.label16.Name = "label16";
	this.label16.Size = new System.Drawing.Size(104, 14);
	this.label16.TabIndex = 18;
	this.label16.Text = "Order Ranking of";
	// 
	// label17
	// 
	this.label17.Location = new System.Drawing.Point(352, 120);
	this.label17.Name = "label17";
	this.label17.Size = new System.Drawing.Size(100, 14);
	this.label17.TabIndex = 19;
	this.label17.Text = "Remaining";
	// 
	// groupBox1
	// 
	this.groupBox1.Controls.Add(this.textBox3);
	this.groupBox1.Controls.Add(this.textBox2);
	this.groupBox1.Controls.Add(this.textBox1);
	this.groupBox1.Controls.Add(this.okButton);
	this.groupBox1.Controls.Add(this.label3);
	this.groupBox1.Controls.Add(this.label1);
	this.groupBox1.Controls.Add(this.reviewButton);
	this.groupBox1.Controls.Add(this.label2);
	this.groupBox1.Controls.Add(this.commitButton);
	this.groupBox1.Location = new System.Drawing.Point(8, 0);
	this.groupBox1.Name = "groupBox1";
	this.groupBox1.Size = new System.Drawing.Size(912, 96);
	this.groupBox1.TabIndex = 20;
	this.groupBox1.TabStop = false;
	// 
	// textBox3
	// 
	this.textBox3.Location = new System.Drawing.Point(136, 64);
	this.textBox3.Name = "textBox3";
	this.textBox3.TabIndex = 8;
	this.textBox3.Text = "";
	// 
	// textBox2
	// 
	this.textBox2.Location = new System.Drawing.Point(136, 40);
	this.textBox2.Name = "textBox2";
	this.textBox2.TabIndex = 7;
	this.textBox2.Text = "";
	// 
	// textBox1
	// 
	this.textBox1.Location = new System.Drawing.Point(136, 16);
	this.textBox1.Name = "textBox1";
	this.textBox1.TabIndex = 6;
	this.textBox1.Text = "";
	// 
	// groupBox2
	// 
	this.groupBox2.Controls.Add(this.label20);
	this.groupBox2.Controls.Add(this.label21);
	this.groupBox2.Controls.Add(this.label22);
	this.groupBox2.Controls.Add(this.label23);
	this.groupBox2.Controls.Add(this.label24);
	this.groupBox2.Controls.Add(this.label25);
	this.groupBox2.Controls.Add(this.label18);
	this.groupBox2.Controls.Add(this.label19);
	this.groupBox2.Controls.Add(this.textBox17);
	this.groupBox2.Controls.Add(this.textBox21);
	this.groupBox2.Controls.Add(this.textBox22);
	this.groupBox2.Controls.Add(this.textBox23);
	this.groupBox2.Controls.Add(this.textBox24);
	this.groupBox2.Controls.Add(this.textBox25);
	this.groupBox2.Controls.Add(this.textBox18);
	this.groupBox2.Controls.Add(this.textBox19);
	this.groupBox2.Controls.Add(this.textBox20);
	this.groupBox2.Controls.Add(this.textBox15);
	this.groupBox2.Controls.Add(this.textBox16);
	this.groupBox2.Controls.Add(this.textBox14);
	this.groupBox2.Controls.Add(this.textBox13);
	this.groupBox2.Controls.Add(this.textBox12);
	this.groupBox2.Controls.Add(this.textBox11);
	this.groupBox2.Controls.Add(this.textBox10);
	this.groupBox2.Controls.Add(this.textBox9);
	this.groupBox2.Controls.Add(this.textBox8);
	this.groupBox2.Controls.Add(this.textBox7);
	this.groupBox2.Controls.Add(this.textBox6);
	this.groupBox2.Controls.Add(this.textBox5);
	this.groupBox2.Controls.Add(this.textBox4);
	this.groupBox2.Controls.Add(this.label12);
	this.groupBox2.Controls.Add(this.label6);
	this.groupBox2.Controls.Add(this.label4);
	this.groupBox2.Controls.Add(this.label7);
	this.groupBox2.Controls.Add(this.label5);
	this.groupBox2.Controls.Add(this.label8);
	this.groupBox2.Controls.Add(this.label9);
	this.groupBox2.Controls.Add(this.label10);
	this.groupBox2.Controls.Add(this.label11);
	this.groupBox2.Controls.Add(this.label17);
	this.groupBox2.Controls.Add(this.label14);
	this.groupBox2.Controls.Add(this.label15);
	this.groupBox2.Controls.Add(this.label13);
	this.groupBox2.Controls.Add(this.label16);
	this.groupBox2.Location = new System.Drawing.Point(8, 96);
	this.groupBox2.Name = "groupBox2";
	this.groupBox2.Size = new System.Drawing.Size(912, 248);
	this.groupBox2.TabIndex = 21;
	this.groupBox2.TabStop = false;
	// 
	// label20
	// 
	this.label20.Location = new System.Drawing.Point(664, 144);
	this.label20.Name = "label20";
	this.label20.Size = new System.Drawing.Size(100, 14);
	this.label20.TabIndex = 49;
	this.label20.Text = "Project Code";
	// 
	// label21
	// 
	this.label21.Location = new System.Drawing.Point(664, 120);
	this.label21.Name = "label21";
	this.label21.Size = new System.Drawing.Size(100, 14);
	this.label21.TabIndex = 48;
	this.label21.Text = "Change Request#";
	// 
	// label22
	// 
	this.label22.Location = new System.Drawing.Point(664, 48);
	this.label22.Name = "label22";
	this.label22.Size = new System.Drawing.Size(100, 14);
	this.label22.TabIndex = 45;
	this.label22.Text = "Print Status";
	// 
	// label23
	// 
	this.label23.Location = new System.Drawing.Point(664, 72);
	this.label23.Name = "label23";
	this.label23.Size = new System.Drawing.Size(100, 14);
	this.label23.TabIndex = 46;
	this.label23.Text = "Sched Type";
	// 
	// label24
	// 
	this.label24.Location = new System.Drawing.Point(664, 24);
	this.label24.Name = "label24";
	this.label24.Size = new System.Drawing.Size(100, 14);
	this.label24.TabIndex = 44;
	this.label24.Text = "Status ";
	// 
	// label25
	// 
	this.label25.Location = new System.Drawing.Point(664, 96);
	this.label25.Name = "label25";
	this.label25.Size = new System.Drawing.Size(100, 14);
	this.label25.TabIndex = 47;
	this.label25.Text = "Program";
	// 
	// label18
	// 
	this.label18.Location = new System.Drawing.Point(352, 168);
	this.label18.Name = "label18";
	this.label18.Size = new System.Drawing.Size(100, 14);
	this.label18.TabIndex = 43;
	this.label18.Text = "DateTime Changed";
	// 
	// label19
	// 
	this.label19.Location = new System.Drawing.Point(352, 144);
	this.label19.Name = "label19";
	this.label19.Size = new System.Drawing.Size(100, 14);
	this.label19.TabIndex = 42;
	this.label19.Text = "Order Changed";
	// 
	// textBox17
	// 
	this.textBox17.Location = new System.Drawing.Point(792, 144);
	this.textBox17.Name = "textBox17";
	this.textBox17.TabIndex = 41;
	this.textBox17.Text = "";
	// 
	// textBox21
	// 
	this.textBox21.Location = new System.Drawing.Point(792, 120);
	this.textBox21.Name = "textBox21";
	this.textBox21.TabIndex = 40;
	this.textBox21.Text = "";
	// 
	// textBox22
	// 
	this.textBox22.Location = new System.Drawing.Point(792, 96);
	this.textBox22.Name = "textBox22";
	this.textBox22.TabIndex = 39;
	this.textBox22.Text = "";
	// 
	// textBox23
	// 
	this.textBox23.Location = new System.Drawing.Point(792, 72);
	this.textBox23.Name = "textBox23";
	this.textBox23.TabIndex = 38;
	this.textBox23.Text = "";
	// 
	// textBox24
	// 
	this.textBox24.Location = new System.Drawing.Point(792, 48);
	this.textBox24.Name = "textBox24";
	this.textBox24.TabIndex = 37;
	this.textBox24.Text = "";
	// 
	// textBox25
	// 
	this.textBox25.Location = new System.Drawing.Point(792, 24);
	this.textBox25.Name = "textBox25";
	this.textBox25.TabIndex = 36;
	this.textBox25.Text = "";
	// 
	// textBox18
	// 
	this.textBox18.Location = new System.Drawing.Point(480, 168);
	this.textBox18.Name = "textBox18";
	this.textBox18.TabIndex = 35;
	this.textBox18.Text = "";
	// 
	// textBox19
	// 
	this.textBox19.Location = new System.Drawing.Point(480, 144);
	this.textBox19.Name = "textBox19";
	this.textBox19.TabIndex = 34;
	this.textBox19.Text = "";
	// 
	// textBox20
	// 
	this.textBox20.Location = new System.Drawing.Point(480, 120);
	this.textBox20.Name = "textBox20";
	this.textBox20.TabIndex = 33;
	this.textBox20.Text = "";
	// 
	// textBox15
	// 
	this.textBox15.Location = new System.Drawing.Point(480, 96);
	this.textBox15.Name = "textBox15";
	this.textBox15.TabIndex = 32;
	this.textBox15.Text = "";
	// 
	// textBox16
	// 
	this.textBox16.Location = new System.Drawing.Point(480, 72);
	this.textBox16.Name = "textBox16";
	this.textBox16.TabIndex = 31;
	this.textBox16.Text = "";
	// 
	// textBox14
	// 
	this.textBox14.Location = new System.Drawing.Point(480, 48);
	this.textBox14.Name = "textBox14";
	this.textBox14.TabIndex = 30;
	this.textBox14.Text = "";
	// 
	// textBox13
	// 
	this.textBox13.Location = new System.Drawing.Point(480, 24);
	this.textBox13.Name = "textBox13";
	this.textBox13.TabIndex = 29;
	this.textBox13.Text = "";
	// 
	// textBox12
	// 
	this.textBox12.Location = new System.Drawing.Point(152, 216);
	this.textBox12.Name = "textBox12";
	this.textBox12.TabIndex = 28;
	this.textBox12.Text = "";
	// 
	// textBox11
	// 
	this.textBox11.Location = new System.Drawing.Point(152, 192);
	this.textBox11.Name = "textBox11";
	this.textBox11.TabIndex = 27;
	this.textBox11.Text = "";
	// 
	// textBox10
	// 
	this.textBox10.Location = new System.Drawing.Point(152, 168);
	this.textBox10.Name = "textBox10";
	this.textBox10.TabIndex = 26;
	this.textBox10.Text = "";
	// 
	// textBox9
	// 
	this.textBox9.Location = new System.Drawing.Point(152, 144);
	this.textBox9.Name = "textBox9";
	this.textBox9.TabIndex = 25;
	this.textBox9.Text = "";
	// 
	// textBox8
	// 
	this.textBox8.Location = new System.Drawing.Point(152, 120);
	this.textBox8.Name = "textBox8";
	this.textBox8.TabIndex = 24;
	this.textBox8.Text = "";
	// 
	// textBox7
	// 
	this.textBox7.Location = new System.Drawing.Point(152, 96);
	this.textBox7.Name = "textBox7";
	this.textBox7.TabIndex = 23;
	this.textBox7.Text = "";
	// 
	// textBox6
	// 
	this.textBox6.Location = new System.Drawing.Point(152, 72);
	this.textBox6.Name = "textBox6";
	this.textBox6.TabIndex = 22;
	this.textBox6.Text = "";
	// 
	// textBox5
	// 
	this.textBox5.Location = new System.Drawing.Point(152, 48);
	this.textBox5.Name = "textBox5";
	this.textBox5.TabIndex = 21;
	this.textBox5.Text = "";
	// 
	// textBox4
	// 
	this.textBox4.Location = new System.Drawing.Point(152, 24);
	this.textBox4.Name = "textBox4";
	this.textBox4.TabIndex = 20;
	this.textBox4.Text = "";
	// 
	// groupBox3
	// 
	this.groupBox3.Controls.Add(this.grid);
	this.groupBox3.Location = new System.Drawing.Point(8, 344);
	this.groupBox3.Name = "groupBox3";
	this.groupBox3.Size = new System.Drawing.Size(912, 280);
	this.groupBox3.TabIndex = 22;
	this.groupBox3.TabStop = false;
	// 
	// grid
	// 
	this.grid.DataMember = "";
	this.grid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
	this.grid.Location = new System.Drawing.Point(8, 16);
	this.grid.Name = "grid";
	this.grid.Size = new System.Drawing.Size(896, 256);
	this.grid.TabIndex = 0;
	// 
	// ToolScheduleSeq
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(928, 630);
	this.Controls.Add(this.groupBox3);
	this.Controls.Add(this.groupBox2);
	this.Controls.Add(this.groupBox1);
	this.Name = "ToolScheduleSeq";
	this.Text = "ToolScheduleSeq";
	this.groupBox1.ResumeLayout(false);
	this.groupBox2.ResumeLayout(false);
	this.groupBox3.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
	this.ResumeLayout(false);

}
#endregion

private
void initializeItemsGrid(){
    dataTable = new DataTable();
//    DataRow dataRow;

	dataTable.Columns.Add(new DataColumn("Component", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Sequence", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Qty Sch", typeof(decimal)));
	dataTable.Columns.Add(new DataColumn("Qty Comp", typeof(decimal)));
	dataTable.Columns.Add(new DataColumn("StrDtTime", typeof(decimal)));
	dataTable.Columns.Add(new DataColumn("EndDtTime", typeof(decimal)));
	dataTable.Columns.Add(new DataColumn("Dept", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Mach", typeof(string)));		
	dataTable.Columns.Add(new DataColumn("Hrs Req", typeof(decimal)));
	dataTable.Columns.Add(new DataColumn("Shift Req", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Piece/Hr", typeof(string)));		

//	string[][] vec = schedule.getSchPrMasStr();
//	for(int x = 0; x < vec.Length; x++){
//		dataRow = dataTable.NewRow();
// 		dataRow[0] = vec[x][23]; // machine
//		if (core.isFamilyPart(vec[x][2])) // family / part
//			dataRow[1] = "Family";
//		else
//			dataRow[1] = "Part";
//
//		dataRow[2] = vec[x][2]; // prod id
// 		dataRow[3] = vec[x][4]; // seq
//		dataRow[4] = decimal.Parse(vec[x][6]); // qty
// 		dataRow[5] = decimal.Parse(vec[x][24]); // pos
// 		dataRow[6] = decimal.Parse(vec[x][15]); // prod hours
// 		dataRow[7] = vec[x][13]; // start date
// 		dataRow[8] = vec[x][14]; // end date
//		dataTable.Rows.Add(dataRow);
//	}

	dataView = new DataView(dataTable);
	dataView.AllowEdit = false;
	dataView.AllowDelete = false;
	dataView.AllowNew = false;
	
	grid.DataSource = dataView;
	grid.PreferredColumnWidth = 150;
	grid.PreferredRowHeight = 22;
	grid.RowHeadersVisible = false;

	//Create a DataGridTableStyle object	
	DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();
	//Set its properties
	dgdtblStyle.MappingName			= dataTable.TableName;//its table name of dataset
	grid.TableStyles.Clear(); 
	grid.TableStyles.Add(dgdtblStyle);
	dgdtblStyle.RowHeadersVisible	= true;
	dgdtblStyle.AllowSorting		= true;
	dgdtblStyle.PreferredRowHeight	= 22;
	GridColumnStylesCollection	colStyle;
	colStyle				= grid.TableStyles[0].GridColumnStyles;		
	colStyle[0].Width      	= 90;
	colStyle[1].Width		= 90;
	colStyle[2].Width		= 90;
	colStyle[3].Width		= 90;
	colStyle[4].Width		= 90;
	colStyle[5].Width      	= 90;
	colStyle[6].Width		= 90;
	colStyle[7].Width		= 90;
	colStyle[8].Width		= 90;
	colStyle[9].Width		= 90;
	colStyle[10].Width		= 90;
	colStyle[11].Width		= 90;
	grid.Refresh();
}

private 
void okButton_Click(object sender, System.EventArgs e){
	Close();
}



}

}
