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
	
public class TransferScreenForm : System.Windows.Forms.Form	{

private System.Windows.Forms.Button btnExit;
private System.Windows.Forms.GroupBox groupBox1;
private DataTable dataTable;
private System.Windows.Forms.DataGrid dGridInvoices;
private System.ComponentModel.Container components = null;
private System.Windows.Forms.Button btnTransfer;
private System.Windows.Forms.TextBox tBoxFiscalPeriod;
private System.Windows.Forms.TextBox tBoxFiscalYear;
private System.Windows.Forms.Label label1;
private System.Windows.Forms.Label label2;

private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
public TransferScreenForm(){
	
	InitializeComponent();
	loadGrid();

}


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
            this.dGridInvoices = new System.Windows.Forms.DataGrid();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tBoxFiscalYear = new System.Windows.Forms.TextBox();
            this.tBoxFiscalPeriod = new System.Windows.Forms.TextBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGridInvoices)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dGridInvoices
            // 
            this.dGridInvoices.DataMember = "";
            this.dGridInvoices.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridInvoices.Location = new System.Drawing.Point(8, 16);
            this.dGridInvoices.Name = "dGridInvoices";
            this.dGridInvoices.Size = new System.Drawing.Size(792, 176);
            this.dGridInvoices.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(720, 224);
            this.btnExit.Name = "btnExit";
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tBoxFiscalYear);
            this.groupBox1.Controls.Add(this.tBoxFiscalPeriod);
            this.groupBox1.Controls.Add(this.dGridInvoices);
            this.groupBox1.Controls.Add(this.btnTransfer);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 256);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Summarize Transfer";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Fiscal Year";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Fiscal Period";
            // 
            // tBoxFiscalYear
            // 
            this.tBoxFiscalYear.Location = new System.Drawing.Point(88, 224);
            this.tBoxFiscalYear.Name = "tBoxFiscalYear";
            this.tBoxFiscalYear.TabIndex = 13;
            this.tBoxFiscalYear.Text = "";
            // 
            // tBoxFiscalPeriod
            // 
            this.tBoxFiscalPeriod.Location = new System.Drawing.Point(88, 200);
            this.tBoxFiscalPeriod.Name = "tBoxFiscalPeriod";
            this.tBoxFiscalPeriod.TabIndex = 12;
            this.tBoxFiscalPeriod.Text = "";
            // 
            // btnTransfer
            // 
            this.btnTransfer.Enabled = false;
            this.btnTransfer.Location = new System.Drawing.Point(616, 224);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(96, 23);
            this.btnTransfer.TabIndex = 8;
            this.btnTransfer.Text = "Transfer";
            // 
            // TransferScreenForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(824, 286);
            this.Controls.Add(this.groupBox1);
            this.Name = "TransferScreenForm";
            this.Text = "Transfer Screen";
            this.Load += new System.EventHandler(this.TransferPostScreenForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGridInvoices)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

private void btnExit_Click(object sender, System.EventArgs e){
    this.Dispose();
}

private void TransferPostScreenForm_Load(object sender, System.EventArgs e){
  try{  

            loadGrid();

  }catch(NujitException ne){
        FormException formException = new FormException(ne);
		formException.ShowDialog();
  }
        
}

private void loadGrid(){
    
    dataTable = new DataTable();
    DataSet listDataSet = new DataSet();	
    string tableName = "invoicesTransfer";
    string[][] vecNames=loadColumnsNames();
    Grid.addColumns(vecNames,tableName,dataTable,this.dGridInvoices);

}
private string[][] loadColumnsNames(){
string[][] vec = new String[8][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
			case "0":
				v[0]="DataBase";
				v[1] = "80";
				break;
			case "1":
				v[0]="Company";
				v[1] = "80";
				break;
            case "2":
				v[0]="Plant";
				v[1] = "80";
				break;	
            case "3":
				v[0]="Batch Number";
				v[1] = "80";
				break;							
			case "4":
				v[0]="#Invoices";
				v[1] = "120";
				break;				
			case "5":
				v[0]="Invoice Total";
				v[1] = "120";
				break;
			case "6":
				v[0]="Invoice Items";
				v[1] = "120";
				break;
			case "7":
				v[0]="Item Qty's";
				v[1] = "120";
				break;
		}
		vec[i]=v;
		i++;	
	}
	return vec;
}


   
}
}
