using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.WinForms.Master
{
	
	public class AddInvPltLocForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtProdId;
		private System.Windows.Forms.Label label1;
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
		private System.Windows.Forms.TextBox txtLotId;
		private System.Windows.Forms.TextBox txtMasPrOrd;
		private System.Windows.Forms.TextBox txtPrOrd;
		private System.Windows.Forms.TextBox txtQoh;
		private System.Windows.Forms.TextBox txtQohAvail;
		private System.Windows.Forms.TextBox txtQoh2;
		private System.Windows.Forms.TextBox txtQohAvail2;
		private System.Windows.Forms.TextBox txtUom2;
		private System.Windows.Forms.TextBox txtProd2;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.TextBox txtUom;
		
		public const int ADD_MODE = 0;
		public const int UPDATE_MODE = 1;
		public const int DELETE_MODE = 2;
		private string[] vecInvPltLoc; 
		private string[] vecSeq;
		private System.Windows.Forms.ErrorProvider error;
		private System.Windows.Forms.ComboBox cBoxSeq;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox cmbStk;

		private System.ComponentModel.Container components = null;

		public AddInvPltLocForm()
		{
			
			InitializeComponent();

		}

public AddInvPltLocForm(string addEdit,string[] vec,string[] vecSeq,string[][] vecStk){
	
	InitializeComponent();		
	if (addEdit.Equals("Add")){
		this.Text = "Add Inventory";
		this.vecSeq = vecSeq;
		this.cBoxSeq.Text=vecSeq[0];
		for(int i = 0; i < vecSeq.Length; i++)
				this.cBoxSeq.Items.Add(vecSeq[i]);
		
		for(int i = 0;i <vecStk.Length;i++)
			this.cmbStk.Items.Add(vecStk[i][0]);
		this.cmbStk.Text = vecStk[1][0];
	} else{
		this.Text = "Edit Inventory";
		vecInvPltLoc = vec;
		loadValues();		
	}
	this.txtProdId.Text =vec[0];
}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
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
			this.txtProdId = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
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
			this.txtLotId = new System.Windows.Forms.TextBox();
			this.txtMasPrOrd = new System.Windows.Forms.TextBox();
			this.txtPrOrd = new System.Windows.Forms.TextBox();
			this.txtQoh = new System.Windows.Forms.TextBox();
			this.txtQohAvail = new System.Windows.Forms.TextBox();
			this.txtUom = new System.Windows.Forms.TextBox();
			this.txtQoh2 = new System.Windows.Forms.TextBox();
			this.txtQohAvail2 = new System.Windows.Forms.TextBox();
			this.txtUom2 = new System.Windows.Forms.TextBox();
			this.txtProd2 = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.error = new System.Windows.Forms.ErrorProvider();
			this.cBoxSeq = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cmbStk = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtProdId
			// 
			this.txtProdId.Enabled = false;
			this.txtProdId.Location = new System.Drawing.Point(104, 16);
			this.txtProdId.MaxLength = 40;
			this.txtProdId.Name = "txtProdId";
			this.txtProdId.Size = new System.Drawing.Size(320, 20);
			this.txtProdId.TabIndex = 0;
			this.txtProdId.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Prod Id";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(224, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Seq";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "Lot Id";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Mas Pr Ord";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(24, 80);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 16);
			this.label6.TabIndex = 6;
			this.label6.Text = "Pr Ord";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(32, 56);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(48, 16);
			this.label7.TabIndex = 7;
			this.label7.Text = "Stk Loc";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(24, 112);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 23);
			this.label8.TabIndex = 8;
			this.label8.Text = "Qoh";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(264, 104);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 23);
			this.label9.TabIndex = 9;
			this.label9.Text = "Qoh Avail";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(24, 136);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(40, 16);
			this.label10.TabIndex = 10;
			this.label10.Text = "Uom";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(24, 160);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 16);
			this.label11.TabIndex = 11;
			this.label11.Text = "Qoh 2";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(264, 168);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(64, 16);
			this.label12.TabIndex = 12;
			this.label12.Text = "Qoh Avail 2";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(24, 184);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(56, 16);
			this.label13.TabIndex = 13;
			this.label13.Text = "Uom 2";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(264, 184);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(56, 16);
			this.label14.TabIndex = 14;
			this.label14.Text = "Prod 2";
			// 
			// txtLotId
			// 
			this.txtLotId.Location = new System.Drawing.Point(96, 16);
			this.txtLotId.MaxLength = 30;
			this.txtLotId.Name = "txtLotId";
			this.txtLotId.Size = new System.Drawing.Size(200, 20);
			this.txtLotId.TabIndex = 4;
			this.txtLotId.Text = "";
			// 
			// txtMasPrOrd
			// 
			this.txtMasPrOrd.Location = new System.Drawing.Point(96, 40);
			this.txtMasPrOrd.MaxLength = 30;
			this.txtMasPrOrd.Name = "txtMasPrOrd";
			this.txtMasPrOrd.Size = new System.Drawing.Size(200, 20);
			this.txtMasPrOrd.TabIndex = 5;
			this.txtMasPrOrd.Text = "";
			// 
			// txtPrOrd
			// 
			this.txtPrOrd.Location = new System.Drawing.Point(96, 80);
			this.txtPrOrd.MaxLength = 30;
			this.txtPrOrd.Name = "txtPrOrd";
			this.txtPrOrd.Size = new System.Drawing.Size(152, 20);
			this.txtPrOrd.TabIndex = 6;
			this.txtPrOrd.Text = "";
			// 
			// txtQoh
			// 
			this.txtQoh.Location = new System.Drawing.Point(96, 104);
			this.txtQoh.MaxLength = 16;
			this.txtQoh.Name = "txtQoh";
			this.txtQoh.Size = new System.Drawing.Size(152, 20);
			this.txtQoh.TabIndex = 7;
			this.txtQoh.Text = "";
			// 
			// txtQohAvail
			// 
			this.txtQohAvail.Location = new System.Drawing.Point(328, 104);
			this.txtQohAvail.MaxLength = 16;
			this.txtQohAvail.Name = "txtQohAvail";
			this.txtQohAvail.Size = new System.Drawing.Size(152, 20);
			this.txtQohAvail.TabIndex = 8;
			this.txtQohAvail.Text = "";
			// 
			// txtUom
			// 
			this.txtUom.Location = new System.Drawing.Point(96, 128);
			this.txtUom.MaxLength = 5;
			this.txtUom.Name = "txtUom";
			this.txtUom.TabIndex = 9;
			this.txtUom.Text = "";
			// 
			// txtQoh2
			// 
			this.txtQoh2.Location = new System.Drawing.Point(96, 160);
			this.txtQoh2.MaxLength = 16;
			this.txtQoh2.Name = "txtQoh2";
			this.txtQoh2.Size = new System.Drawing.Size(152, 20);
			this.txtQoh2.TabIndex = 10;
			this.txtQoh2.Text = "";
			// 
			// txtQohAvail2
			// 
			this.txtQohAvail2.Location = new System.Drawing.Point(328, 160);
			this.txtQohAvail2.MaxLength = 16;
			this.txtQohAvail2.Name = "txtQohAvail2";
			this.txtQohAvail2.Size = new System.Drawing.Size(152, 20);
			this.txtQohAvail2.TabIndex = 11;
			this.txtQohAvail2.Text = "";
			// 
			// txtUom2
			// 
			this.txtUom2.Location = new System.Drawing.Point(96, 184);
			this.txtUom2.MaxLength = 5;
			this.txtUom2.Name = "txtUom2";
			this.txtUom2.TabIndex = 12;
			this.txtUom2.Text = "";
			// 
			// txtProd2
			// 
			this.txtProd2.Location = new System.Drawing.Point(328, 184);
			this.txtProd2.MaxLength = 5;
			this.txtProd2.Name = "txtProd2";
			this.txtProd2.Size = new System.Drawing.Size(128, 20);
			this.txtProd2.TabIndex = 13;
			this.txtProd2.Text = "";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(512, 56);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(88, 23);
			this.btnCancel.TabIndex = 28;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(512, 24);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(88, 23);
			this.btnOk.TabIndex = 29;
			this.btnOk.Text = "OK";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// error
			// 
			this.error.ContainerControl = this;
			// 
			// cBoxSeq
			// 
			this.cBoxSeq.Location = new System.Drawing.Point(264, 48);
			this.cBoxSeq.Name = "cBoxSeq";
			this.cBoxSeq.Size = new System.Drawing.Size(160, 21);
			this.cBoxSeq.TabIndex = 30;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtProd2);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.txtQohAvail2);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.txtUom2);
			this.groupBox1.Controls.Add(this.txtQoh2);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.txtUom);
			this.groupBox1.Controls.Add(this.txtQohAvail);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.txtQoh);
			this.groupBox1.Controls.Add(this.txtPrOrd);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtLotId);
			this.groupBox1.Controls.Add(this.txtMasPrOrd);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new System.Drawing.Point(8, 96);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(496, 224);
			this.groupBox1.TabIndex = 31;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cmbStk);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.txtProdId);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.cBoxSeq);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(8, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(496, 80);
			this.groupBox2.TabIndex = 32;
			this.groupBox2.TabStop = false;
			// 
			// cmbStk
			// 
			this.cmbStk.Location = new System.Drawing.Point(104, 48);
			this.cmbStk.Name = "cmbStk";
			this.cmbStk.Size = new System.Drawing.Size(104, 21);
			this.cmbStk.TabIndex = 31;
			// 
			// AddInvPltLocForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(608, 334);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "AddInvPltLocForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		
private void loadValues(){

	this.cBoxSeq.Text =vecInvPltLoc[1];
	this.cBoxSeq.Enabled = false;
	this.txtLotId.Text = vecInvPltLoc[2];
	this.txtMasPrOrd.Text = vecInvPltLoc[3];
	this.txtPrOrd.Text = vecInvPltLoc[4];	
	this.cmbStk.Text = vecInvPltLoc[5];
	this.cmbStk.Enabled = false;
	this.txtQoh.Text = vecInvPltLoc[6];
	this.txtQohAvail.Text =vecInvPltLoc[7];
	this.txtUom.Text = vecInvPltLoc[8];	
	this.txtQoh2.Text = vecInvPltLoc[9];	
	this.txtQohAvail2.Text =vecInvPltLoc[10];	
	this.txtUom2.Text =vecInvPltLoc[11];	
	this.txtProd2.Text = vecInvPltLoc[12];	

	
	
	
}

private void btnCancel_Click(object sender, System.EventArgs e){
	DialogResult = DialogResult.Cancel;
	this.Hide();

}//endbtnCancel_Click

private void btnOk_Click(object sender, System.EventArgs e){
	clearError();
	if (!isDataOK()){
		DialogResult = DialogResult.OK;
		this.Hide();
	}
}

private void clearError()	{
	foreach(Control objControl in this.groupBox1.Controls)	{
		if (objControl is TextBox)
			error.SetError(objControl,"");
		
	}
}

private bool isDataOK(){
	bool errors = false;

	if (this.txtQoh.Text != null){
		try {
			if (Convert.ToDecimal(this.txtQoh.Text.Trim())<0 ){
				error.SetError(this.txtQoh,"This field must have a value > 0");	
				return true;
			}
			if(! NumberUtil.withPoint(this.txtQoh.Text.Trim().ToString())){
				error.SetError(this.txtQoh,"The value must be with '.' no with ','");	
				return true;
			}
			//Verify that the number is less than 9999999999.99999
			Decimal theValue = decimal.Parse(this.txtQoh.Text.Trim().ToString());
			Decimal comp = 9999999999.99999M;
			if (decimal.Compare(theValue,comp) > 0){//theValue is greater than..
			    error.SetError(this.txtQoh,"The value must be less than 9999999999.99999.");	
				return true;
			}
			    
		}catch {
				error.SetError(this.txtQoh,"A value number is expected");	
				return true;
		}
	}

	if (this.txtQohAvail.Text != null){
					
		try {
			if (Convert.ToDecimal(this.txtQohAvail.Text.Trim())<0 ){
				error.SetError(this.txtQohAvail,"This field must have a value > 0");	
				return true;
			}
			if(! NumberUtil.withPoint(this.txtQohAvail.Text.Trim().ToString())){
				error.SetError(this.txtQohAvail,"The value must be with '.' no with ','");	
				return true;
			}
			Decimal theValue = decimal.Parse(this.txtQohAvail.Text.Trim().ToString());
			Decimal comp = 9999999999.99999M;
			if (decimal.Compare(theValue,comp) > 0){//theValue is greater than..
			    error.SetError(this.txtQohAvail,"The value must be less than 9999999999.99999.");	
				return true;
			}
		}catch {
				error.SetError(this.txtQohAvail,"A value number is expected");	
				return true;
		}
	}

	if(this.txtQoh2.Text != null){
		try {
			if (Convert.ToDecimal(this.txtQoh2.Text.Trim())<0 ){
				error.SetError(this.txtQoh2,"This field must have a decimal value");	
				return true;
			}
			if(! NumberUtil.withPoint(this.txtQoh2.Text.Trim().ToString())){
				error.SetError(this.txtQoh2,"The value must be with '.' no with ','");	
				return true;
			}
			Decimal theValue = decimal.Parse(this.txtQoh2.Text.Trim().ToString());
			Decimal comp = 9999999999.99999M;
			if (decimal.Compare(theValue,comp) > 0){//theValue is greater than..
			    error.SetError(this.txtQoh2,"The value must be less than 9999999999.99999.");	
				return true;
			}
		}catch {
				error.SetError(this.txtQoh2,"A value number is expected");	
				return true;
		}
	}	

	if(this.txtQohAvail2.Text != null){
		try {
			if (Convert.ToDecimal(this.txtQohAvail2.Text.Trim())<0 ){
				error.SetError(this.txtQohAvail2,"This field must have a decimal value");	
				return true;
			}
			if(! NumberUtil.withPoint(this.txtQohAvail2.Text.Trim().ToString())){
				error.SetError(this.txtQohAvail2,"The value must be with '.' no with ','");	
				return true;
			}
			Decimal theValue = decimal.Parse(this.txtQohAvail2.Text.Trim().ToString());
			Decimal comp = 9999999999.99999M;
			if (decimal.Compare(theValue,comp) > 0){//theValue is greater than..
			    error.SetError(this.txtQohAvail2,"The value must be less than 9999999999.99999.");	
				return true;
			}
			
		}catch {
				error.SetError(this.txtQohAvail2,"A value number is expected");	
				return true;	
		}
	}	
	return errors;
}
	
public string getProdID(){
	return this.txtProdId.Text;
}

public string getSeq(){
	
	if ((string)this.cBoxSeq.SelectedItem == null)
		return this.cBoxSeq.Text;
	return this.cBoxSeq.SelectedItem.ToString();
}

public string getLotID(){
	return this.txtLotId.Text;
}

public string getMasPrOrd(){
	return this.txtMasPrOrd.Text;
}

public string getPrOrd(){
	return this.txtPrOrd.Text;
}

public string getStkLoc(){
	if ((string)this.cmbStk.SelectedItem == null)
		return this.cmbStk.Text;
	return this.cmbStk.SelectedItem.ToString();
}

public string getQoh(){
	return this.txtQoh.Text;
}

public string getQohAvail(){
	return this.txtQohAvail.Text;
}

public string getUom(){
	return this.txtUom.Text;
}

public string getQoh2(){
	return this.txtQoh2.Text;
}

public string getQohAvail2(){
	return this.txtQohAvail2.Text;
}

public string getUom2(){
	return this.txtUom2.Text;
}

public string getProd2(){
	return this.txtProd2.Text;
}


}//end Class
}//end namespace
