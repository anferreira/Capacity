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

namespace Nujit.NujitERP.WinForms.OrderEntry.PackSlip{
public class AllPackSlipHdrForm : System.Windows.Forms.Form	{
private System.Windows.Forms.GroupBox gBoxSch;
private System.Windows.Forms.Button btnSch;
private System.Windows.Forms.GroupBox gBoxBtns;
private System.Windows.Forms.Button btnCancel;
private System.Windows.Forms.Button btnEdit;
private System.Windows.Forms.Button btnAdd;
private System.Windows.Forms.Button btnDelete;
private System.Windows.Forms.DataGrid dGridAllPackSlip;
/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;
private CultureLocal culture = new CultureLocal(Culture.getCulture());
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.CheckBox checkBox2;
    private System.Windows.Forms.CheckBox checkBox3;
    private System.Windows.Forms.CheckBox checkBox4;
    private System.Windows.Forms.CheckBox checkBox5;
    private System.Windows.Forms.CheckBox checkBox6;
    private System.Windows.Forms.CheckBox checkBox7;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.TextBox textBox5;
    private System.Windows.Forms.TextBox textBox6;
    private System.Windows.Forms.TextBox textBox7;
    private System.Windows.Forms.TextBox textBox8;
private DataTable dataTable;		

public AllPackSlipHdrForm()		{
	
	InitializeComponent();

}
protected override void Dispose( bool disposing )		{	
		if( disposing )	{
		if(components != null){
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
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnSch = new System.Windows.Forms.Button();
            this.dGridAllPackSlip = new System.Windows.Forms.DataGrid();
            this.gBoxBtns = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.gBoxSch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridAllPackSlip)).BeginInit();
            this.gBoxBtns.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxSch
            // 
            this.gBoxSch.Controls.Add(this.textBox8);
            this.gBoxSch.Controls.Add(this.textBox7);
            this.gBoxSch.Controls.Add(this.textBox6);
            this.gBoxSch.Controls.Add(this.textBox5);
            this.gBoxSch.Controls.Add(this.textBox3);
            this.gBoxSch.Controls.Add(this.textBox2);
            this.gBoxSch.Controls.Add(this.textBox1);
            this.gBoxSch.Controls.Add(this.checkBox7);
            this.gBoxSch.Controls.Add(this.checkBox6);
            this.gBoxSch.Controls.Add(this.checkBox5);
            this.gBoxSch.Controls.Add(this.checkBox4);
            this.gBoxSch.Controls.Add(this.checkBox3);
            this.gBoxSch.Controls.Add(this.checkBox2);
            this.gBoxSch.Controls.Add(this.checkBox1);
            this.gBoxSch.Controls.Add(this.btnSch);
            this.gBoxSch.Location = new System.Drawing.Point(8, 8);
            this.gBoxSch.Name = "gBoxSch";
            this.gBoxSch.Size = new System.Drawing.Size(784, 80);
            this.gBoxSch.TabIndex = 2;
            this.gBoxSch.TabStop = false;
            this.gBoxSch.Text = "Search Pack Slip";
            // 
            // checkBox7
            // 
            this.checkBox7.Checked = true;
            this.checkBox7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox7.Location = new System.Drawing.Point(432, 20);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(88, 16);
            this.checkBox7.TabIndex = 8;
            this.checkBox7.Text = "Picked (Y/N)";
            // 
            // checkBox6
            // 
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Location = new System.Drawing.Point(432, 40);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(88, 16);
            this.checkBox6.TabIndex = 7;
            this.checkBox6.Text = "Pickup Time";
            // 
            // checkBox5
            // 
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(216, 40);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(88, 16);
            this.checkBox5.TabIndex = 6;
            this.checkBox5.Text = "Pack Slip #";
            // 
            // checkBox4
            // 
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(216, 20);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(64, 16);
            this.checkBox4.TabIndex = 5;
            this.checkBox4.Text = "Carrier";
            // 
            // checkBox3
            // 
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(24, 60);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(48, 16);
            this.checkBox3.TabIndex = 4;
            this.checkBox3.Text = "PO";
            // 
            // checkBox2
            // 
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(24, 40);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(64, 16);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Ship to";
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(24, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Bill to";
            // 
            // btnSch
            // 
            this.btnSch.Location = new System.Drawing.Point(704, 40);
            this.btnSch.Name = "btnSch";
            this.btnSch.Size = new System.Drawing.Size(30, 16);
            this.btnSch.TabIndex = 1;
            this.btnSch.Text = "...";
            // 
            // dGridAllPackSlip
            // 
            this.dGridAllPackSlip.DataMember = "";
            this.dGridAllPackSlip.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridAllPackSlip.Location = new System.Drawing.Point(8, 104);
            this.dGridAllPackSlip.Name = "dGridAllPackSlip";
            this.dGridAllPackSlip.Size = new System.Drawing.Size(792, 256);
            this.dGridAllPackSlip.TabIndex = 3;
            // 
            // gBoxBtns
            // 
            this.gBoxBtns.Controls.Add(this.btnCancel);
            this.gBoxBtns.Controls.Add(this.btnEdit);
            this.gBoxBtns.Controls.Add(this.btnAdd);
            this.gBoxBtns.Controls.Add(this.btnDelete);
            this.gBoxBtns.Location = new System.Drawing.Point(8, 368);
            this.gBoxBtns.Name = "gBoxBtns";
            this.gBoxBtns.Size = new System.Drawing.Size(792, 48);
            this.gBoxBtns.TabIndex = 4;
            this.gBoxBtns.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(704, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(448, 16);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnAdd.Location = new System.Drawing.Point(528, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(616, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(80, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 20);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(80, 56);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(120, 20);
            this.textBox3.TabIndex = 11;
            this.textBox3.Text = "";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(528, 36);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(120, 20);
            this.textBox5.TabIndex = 13;
            this.textBox5.Text = "";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(528, 16);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(120, 20);
            this.textBox6.TabIndex = 14;
            this.textBox6.Text = "";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(296, 36);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(120, 20);
            this.textBox7.TabIndex = 15;
            this.textBox7.Text = "";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(296, 16);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(120, 20);
            this.textBox8.TabIndex = 16;
            this.textBox8.Text = "";
            // 
            // AllPackSlipHdrForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(808, 422);
            this.Controls.Add(this.gBoxBtns);
            this.Controls.Add(this.dGridAllPackSlip);
            this.Controls.Add(this.gBoxSch);
            this.Name = "AllPackSlipHdrForm";
            this.Text = "Pack Slip ";
            this.Load += new System.EventHandler(this.AllPackSlipHdrForm_Load);
            this.gBoxSch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridAllPackSlip)).EndInit();
            this.gBoxBtns.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

private void btnEdit_Click(object sender, System.EventArgs e){
    PackSlipHdrForm packSlipHdrForm = new PackSlipHdrForm();
    packSlipHdrForm.ShowDialog();
}

private void AllPackSlipHdrForm_Load(object sender, System.EventArgs e){
 loadGrid();
}

private void loadGrid(){

    try{   
        dataTable = new DataTable();
        DataSet listDataSet = new DataSet();	
        string tableName = "packSlipAll";
        string[][] vecNames = loadColumnsNames();
        Grid.addColumns(vecNames,tableName,dataTable,this.dGridAllPackSlip);
          
    }catch(NujitException ne){
        
	    FormException formException = new FormException(ne);
	    formException.ShowDialog();
    }        

}

private string[][] loadColumnsNames(){
string[][] vec = new String[13][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
		     case "0":
				v[0]="Db";
				v[1] = "0";
				break;
		     case "1":
				v[0]="Company";
				v[1] = "0";
				break;
		     case "2":
				v[0]="Plant";
				v[1] = "0";
				break;
			case "3":
				v[0]="PS Type";
				v[1] = "60";
				break;		
			case "4":
				v[0]="Pack Slip #";
				v[1] = "80";
				break;
        	case "5":
				v[0]="Bill to";
				v[1] = "80";
				break;
			case "6":
				v[0]="Ship To";
				v[1] = "80";
				break;		
			case "7":
				v[0]="Picked(Y/N)";
				v[1] = "80";
				break;			
			case "8":
				v[0]="Avail";
				v[1] = "60";
				break;	
			case "9":
				v[0]="DateTime Req.";
				v[1] = "90";
				break;	
			case "10":
				v[0]="Carrier";
				v[1] = "60";
				break;		
			case "11":
				v[0]="Pickup Time";
				v[1] = "80";
				break;			
			case "12":
				v[0]="Bol #";
				v[1] = "60";
				break;																														
		}
		vec[i]=v;
		i++;	
	}
	return vec;
}

}//end class
}//end namespace
