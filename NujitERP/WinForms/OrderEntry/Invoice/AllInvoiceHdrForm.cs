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
	/// <summary>
	/// Summary description for AllInvoiceHdrForm.
	/// </summary>
public class AllInvoiceHdrForm : System.Windows.Forms.Form	{
private System.Windows.Forms.GroupBox gBoxSch;
private System.Windows.Forms.Button button1;
private System.Windows.Forms.GroupBox gBoxBtns;
private System.Windows.Forms.Button btnEdit;
private System.Windows.Forms.Button btnAdd;
private System.Windows.Forms.Button btnDelete;
private System.Windows.Forms.Button btnCancel;
/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;

private CultureLocal culture = new CultureLocal(Culture.getCulture());
    private System.Windows.Forms.DataGrid dGridDataTable;
    private System.Windows.Forms.Button btnTransfer;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.TextBox textBox4;
    private System.Windows.Forms.TextBox textBox5;
    private System.Windows.Forms.TextBox textBox6;
    private System.Windows.Forms.DateTimePicker dateTimePicker1;
    private System.Windows.Forms.DateTimePicker dateTimePicker2;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.CheckBox checkBox1;
private DataTable dataTable;

public AllInvoiceHdrForm()		{

	InitializeComponent();
	
}

/// <summary>
/// Clean up any resources being used.
/// </summary>
protected override void Dispose( bool disposing ){
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
    this.gBoxSch = new System.Windows.Forms.GroupBox();
    this.button4 = new System.Windows.Forms.Button();
    this.button3 = new System.Windows.Forms.Button();
    this.button2 = new System.Windows.Forms.Button();
    this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
    this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
    this.textBox6 = new System.Windows.Forms.TextBox();
    this.textBox5 = new System.Windows.Forms.TextBox();
    this.textBox4 = new System.Windows.Forms.TextBox();
    this.textBox3 = new System.Windows.Forms.TextBox();
    this.textBox2 = new System.Windows.Forms.TextBox();
    this.label8 = new System.Windows.Forms.Label();
    this.label7 = new System.Windows.Forms.Label();
    this.label6 = new System.Windows.Forms.Label();
    this.label5 = new System.Windows.Forms.Label();
    this.label4 = new System.Windows.Forms.Label();
    this.label3 = new System.Windows.Forms.Label();
    this.label2 = new System.Windows.Forms.Label();
    this.textBox1 = new System.Windows.Forms.TextBox();
    this.label1 = new System.Windows.Forms.Label();
    this.button1 = new System.Windows.Forms.Button();
    this.dGridDataTable = new System.Windows.Forms.DataGrid();
    this.gBoxBtns = new System.Windows.Forms.GroupBox();
    this.btnTransfer = new System.Windows.Forms.Button();
    this.btnCancel = new System.Windows.Forms.Button();
    this.btnEdit = new System.Windows.Forms.Button();
    this.btnAdd = new System.Windows.Forms.Button();
    this.btnDelete = new System.Windows.Forms.Button();
    this.checkBox1 = new System.Windows.Forms.CheckBox();
    this.gBoxSch.SuspendLayout();
    ((System.ComponentModel.ISupportInitialize)(this.dGridDataTable)).BeginInit();
    this.gBoxBtns.SuspendLayout();
    this.SuspendLayout();
    // 
    // gBoxSch
    // 
    this.gBoxSch.Controls.Add(this.checkBox1);
    this.gBoxSch.Controls.Add(this.button4);
    this.gBoxSch.Controls.Add(this.button3);
    this.gBoxSch.Controls.Add(this.button2);
    this.gBoxSch.Controls.Add(this.dateTimePicker2);
    this.gBoxSch.Controls.Add(this.dateTimePicker1);
    this.gBoxSch.Controls.Add(this.textBox6);
    this.gBoxSch.Controls.Add(this.textBox5);
    this.gBoxSch.Controls.Add(this.textBox4);
    this.gBoxSch.Controls.Add(this.textBox3);
    this.gBoxSch.Controls.Add(this.textBox2);
    this.gBoxSch.Controls.Add(this.label8);
    this.gBoxSch.Controls.Add(this.label7);
    this.gBoxSch.Controls.Add(this.label6);
    this.gBoxSch.Controls.Add(this.label5);
    this.gBoxSch.Controls.Add(this.label4);
    this.gBoxSch.Controls.Add(this.label3);
    this.gBoxSch.Controls.Add(this.label2);
    this.gBoxSch.Controls.Add(this.textBox1);
    this.gBoxSch.Controls.Add(this.label1);
    this.gBoxSch.Controls.Add(this.button1);
    this.gBoxSch.Location = new System.Drawing.Point(16, 8);
    this.gBoxSch.Name = "gBoxSch";
    this.gBoxSch.Size = new System.Drawing.Size(816, 128);
    this.gBoxSch.TabIndex = 1;
    this.gBoxSch.TabStop = false;
    this.gBoxSch.Text = "Search Invoice";
    // 
    // button4
    // 
    this.button4.Location = new System.Drawing.Point(184, 80);
    this.button4.Name = "button4";
    this.button4.Size = new System.Drawing.Size(24, 16);
    this.button4.TabIndex = 22;
    this.button4.Text = "...";
    // 
    // button3
    // 
    this.button3.Location = new System.Drawing.Point(184, 100);
    this.button3.Name = "button3";
    this.button3.Size = new System.Drawing.Size(24, 16);
    this.button3.TabIndex = 21;
    this.button3.Text = "...";
    // 
    // button2
    // 
    this.button2.Location = new System.Drawing.Point(184, 60);
    this.button2.Name = "button2";
    this.button2.Size = new System.Drawing.Size(24, 16);
    this.button2.TabIndex = 20;
    this.button2.Text = "...";
    // 
    // dateTimePicker2
    // 
    this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
    this.dateTimePicker2.Location = new System.Drawing.Point(584, 16);
    this.dateTimePicker2.Name = "dateTimePicker2";
    this.dateTimePicker2.Size = new System.Drawing.Size(96, 20);
    this.dateTimePicker2.TabIndex = 19;
    // 
    // dateTimePicker1
    // 
    this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
    this.dateTimePicker1.Location = new System.Drawing.Point(360, 16);
    this.dateTimePicker1.Name = "dateTimePicker1";
    this.dateTimePicker1.Size = new System.Drawing.Size(96, 20);
    this.dateTimePicker1.TabIndex = 18;
    // 
    // textBox6
    // 
    this.textBox6.Location = new System.Drawing.Point(320, 48);
    this.textBox6.Name = "textBox6";
    this.textBox6.TabIndex = 17;
    this.textBox6.Text = "";
    // 
    // textBox5
    // 
    this.textBox5.Location = new System.Drawing.Point(80, 96);
    this.textBox5.Name = "textBox5";
    this.textBox5.TabIndex = 16;
    this.textBox5.Text = "";
    // 
    // textBox4
    // 
    this.textBox4.Location = new System.Drawing.Point(80, 76);
    this.textBox4.Name = "textBox4";
    this.textBox4.TabIndex = 15;
    this.textBox4.Text = "";
    // 
    // textBox3
    // 
    this.textBox3.Location = new System.Drawing.Point(80, 56);
    this.textBox3.Name = "textBox3";
    this.textBox3.TabIndex = 14;
    this.textBox3.Text = "";
    // 
    // textBox2
    // 
    this.textBox2.Location = new System.Drawing.Point(80, 36);
    this.textBox2.Name = "textBox2";
    this.textBox2.TabIndex = 13;
    this.textBox2.Text = "";
    // 
    // label8
    // 
    this.label8.Location = new System.Drawing.Point(248, 48);
    this.label8.Name = "label8";
    this.label8.Size = new System.Drawing.Size(80, 23);
    this.label8.TabIndex = 12;
    this.label8.Text = "Fiscal Period";
    // 
    // label7
    // 
    this.label7.Location = new System.Drawing.Point(16, 96);
    this.label7.Name = "label7";
    this.label7.Size = new System.Drawing.Size(64, 20);
    this.label7.TabIndex = 11;
    this.label7.Text = "Currency";
    // 
    // label6
    // 
    this.label6.Location = new System.Drawing.Point(16, 76);
    this.label6.Name = "label6";
    this.label6.Size = new System.Drawing.Size(64, 20);
    this.label6.TabIndex = 10;
    this.label6.Text = "Plant";
    // 
    // label5
    // 
    this.label5.Location = new System.Drawing.Point(16, 56);
    this.label5.Name = "label5";
    this.label5.Size = new System.Drawing.Size(64, 20);
    this.label5.TabIndex = 7;
    this.label5.Text = "Company";
    // 
    // label4
    // 
    this.label4.Location = new System.Drawing.Point(480, 16);
    this.label4.Name = "label4";
    this.label4.Size = new System.Drawing.Size(112, 23);
    this.label4.TabIndex = 6;
    this.label4.Text = "Ending Invoice Date";
    // 
    // label3
    // 
    this.label3.Location = new System.Drawing.Point(248, 16);
    this.label3.Name = "label3";
    this.label3.Size = new System.Drawing.Size(112, 23);
    this.label3.TabIndex = 5;
    this.label3.Text = "Starting Invoice Date";
    // 
    // label2
    // 
    this.label2.Location = new System.Drawing.Point(16, 36);
    this.label2.Name = "label2";
    this.label2.Size = new System.Drawing.Size(64, 20);
    this.label2.TabIndex = 4;
    this.label2.Text = "Data Base";
    // 
    // textBox1
    // 
    this.textBox1.Location = new System.Drawing.Point(80, 16);
    this.textBox1.Name = "textBox1";
    this.textBox1.TabIndex = 3;
    this.textBox1.Text = "";
    // 
    // label1
    // 
    this.label1.Location = new System.Drawing.Point(16, 16);
    this.label1.Name = "label1";
    this.label1.Size = new System.Drawing.Size(64, 20);
    this.label1.TabIndex = 2;
    this.label1.Text = "Invoice #";
    // 
    // button1
    // 
    this.button1.Location = new System.Drawing.Point(720, 88);
    this.button1.Name = "button1";
    this.button1.Size = new System.Drawing.Size(80, 24);
    this.button1.TabIndex = 1;
    this.button1.Text = "Search";
    // 
    // dGridDataTable
    // 
    this.dGridDataTable.DataMember = "";
    this.dGridDataTable.HeaderForeColor = System.Drawing.SystemColors.ControlText;
    this.dGridDataTable.Location = new System.Drawing.Point(8, 144);
    this.dGridDataTable.Name = "dGridDataTable";
    this.dGridDataTable.Size = new System.Drawing.Size(832, 312);
    this.dGridDataTable.TabIndex = 2;
    // 
    // gBoxBtns
    // 
    this.gBoxBtns.Controls.Add(this.btnTransfer);
    this.gBoxBtns.Controls.Add(this.btnCancel);
    this.gBoxBtns.Controls.Add(this.btnEdit);
    this.gBoxBtns.Controls.Add(this.btnAdd);
    this.gBoxBtns.Controls.Add(this.btnDelete);
    this.gBoxBtns.Location = new System.Drawing.Point(16, 472);
    this.gBoxBtns.Name = "gBoxBtns";
    this.gBoxBtns.Size = new System.Drawing.Size(816, 48);
    this.gBoxBtns.TabIndex = 3;
    this.gBoxBtns.TabStop = false;
    // 
    // btnTransfer
    // 
    this.btnTransfer.Location = new System.Drawing.Point(32, 16);
    this.btnTransfer.Name = "btnTransfer";
    this.btnTransfer.TabIndex = 5;
    this.btnTransfer.Text = "Transfer";
    this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
    // 
    // btnCancel
    // 
    this.btnCancel.Location = new System.Drawing.Point(720, 16);
    this.btnCancel.Name = "btnCancel";
    this.btnCancel.TabIndex = 4;
    this.btnCancel.Text = "Cancel";
    this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
    // 
    // btnEdit
    // 
    this.btnEdit.Location = new System.Drawing.Point(456, 16);
    this.btnEdit.Name = "btnEdit";
    this.btnEdit.TabIndex = 3;
    this.btnEdit.Text = "Edit";
    this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
    // 
    // btnAdd
    // 
    this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.No;
    this.btnAdd.Location = new System.Drawing.Point(544, 16);
    this.btnAdd.Name = "btnAdd";
    this.btnAdd.TabIndex = 2;
    this.btnAdd.Text = "Add";
    this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
    // 
    // btnDelete
    // 
    this.btnDelete.Location = new System.Drawing.Point(632, 16);
    this.btnDelete.Name = "btnDelete";
    this.btnDelete.TabIndex = 0;
    this.btnDelete.Text = "Delete";
    // 
    // checkBox1
    // 
    this.checkBox1.Checked = true;
    this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
    this.checkBox1.Location = new System.Drawing.Point(248, 72);
    this.checkBox1.Name = "checkBox1";
    this.checkBox1.Size = new System.Drawing.Size(96, 24);
    this.checkBox1.TabIndex = 23;
    this.checkBox1.Text = "Invoice/Credit";
    // 
    // AllInvoiceHdrForm
    // 
    this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
    this.ClientSize = new System.Drawing.Size(848, 542);
    this.Controls.Add(this.gBoxBtns);
    this.Controls.Add(this.dGridDataTable);
    this.Controls.Add(this.gBoxSch);
    this.Name = "AllInvoiceHdrForm";
    this.Text = "Invoices ";
    this.Load += new System.EventHandler(this.AllInvoiceHdrForm_Load);
    this.gBoxSch.ResumeLayout(false);
    ((System.ComponentModel.ISupportInitialize)(this.dGridDataTable)).EndInit();
    this.gBoxBtns.ResumeLayout(false);
    this.ResumeLayout(false);

}
#endregion

private void AllInvoiceHdrForm_Load(object sender, System.EventArgs e){
    loadGrid();

}


private void loadGrid(){

    try{   
        dataTable = new DataTable();
        DataSet listDataSet = new DataSet();	
        string tableName = "invocieDtlInfo";
        string[][] vecNames = loadColumnsNames();
        Grid.addColumns(vecNames,tableName,dataTable,this.dGridDataTable);
        
          
    }catch(NujitException ne){
        
	    FormException formException = new FormException(ne);
	    formException.ShowDialog();
    }        

}

private string[][] loadColumnsNames(){
string[][] vec = new String[11][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
		     case "0":
				v[0]="Db";
				v[1] = "50";
				break;
		     case "1":
				v[0]="Company";
				v[1] = "60";
				break;
		     case "2":
				v[0]="Plant";
				v[1] = "60";
				break;
		     case "3":
				v[0]="Invoice #";
				v[1] = "60";
				break;
		     case "4":
				v[0]="Order #";
				v[1] = "60";
				break;
			case "5":
				v[0]="Invoice Date";
				v[1] = "80";
				break;
            case "6":
				v[0]="Date Posted";
				v[1] = "80";
				break;
            case "7":
				v[0]="Inv. Type";
				v[1] = "80";
				break;
		    case "8":
				v[0]="Inv. Credit";
				v[1] = "80";
				break;
			case "9":
				v[0]="Invoice Amt";
				v[1] = "100";
				break;	
			case "10":
				v[0]="Posting Batch";
				v[1] = "100";
				break;
		}
		vec[i]=v;
		i++;	
	}
	return vec;
}

private void btnEdit_Click(object sender, System.EventArgs e){
    InvoiceHdrForm invoiceHdrForm= new InvoiceHdrForm();
    invoiceHdrForm.ShowDialog();
}

private void btnAdd_Click(object sender, System.EventArgs e){
    InvoiceHdrForm invoiceHdrForm= new InvoiceHdrForm();
    invoiceHdrForm.ShowDialog();
}

private void btnTransfer_Click(object sender, System.EventArgs e){

    TransferScreenForm transferScreenForm = new TransferScreenForm();
    transferScreenForm.ShowDialog();
}

private void btnCancel_Click(object sender, System.EventArgs e){

    this.Close();
}

}//end class
}//end namespace
