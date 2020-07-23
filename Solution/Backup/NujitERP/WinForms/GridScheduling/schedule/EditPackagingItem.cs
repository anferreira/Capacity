using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Util;

namespace GridScheduling.gui.schedule{
	
/// <summary>
/// Summary description for EditPackagingItem.
/// </summary>
public 
class EditPackagingItem : System.Windows.Forms.Form{

private System.Windows.Forms.Label label1;
private System.Windows.Forms.Label label2;
private System.Windows.Forms.Label label3;
private System.Windows.Forms.Label label4;
private System.Windows.Forms.Label label5;
private System.Windows.Forms.Label label6;
private System.Windows.Forms.Label label7;
private System.Windows.Forms.TextBox shipToLocTextBox;
private System.Windows.Forms.TextBox cusProdIdTextBox;
private System.Windows.Forms.TextBox orderNumberTextBox;
private System.Windows.Forms.TextBox orderItemNumberTextBox;
private System.Windows.Forms.TextBox qtyTextBox;
private System.Windows.Forms.TextBox numberOfBoxesTextBox;
private System.Windows.Forms.TextBox qtyOnHandTextBox;
private System.Windows.Forms.Panel panel1;
private System.Windows.Forms.Button okEditButton;
private System.Windows.Forms.Button cancelEditButton;
/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;

	
public
EditPackagingItem(string shipToLocation, string customerProdId, 
		string orderNumber, string orderItemNumber, string qty, 
		string numberOfBoxes){
	InitializeComponent();

	shipToLocTextBox.Text = shipToLocation;
	cusProdIdTextBox.Text = customerProdId;
	orderNumberTextBox.Text = orderNumber;
	orderItemNumberTextBox.Text = orderItemNumber;
	qtyTextBox.Text = qty;
	numberOfBoxesTextBox.Text = numberOfBoxes;
	qtyOnHandTextBox.Text = "0";
}

public 
EditPackagingItem(){
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
	this.label1 = new System.Windows.Forms.Label();
	this.label2 = new System.Windows.Forms.Label();
	this.label3 = new System.Windows.Forms.Label();
	this.label4 = new System.Windows.Forms.Label();
	this.label5 = new System.Windows.Forms.Label();
	this.label6 = new System.Windows.Forms.Label();
	this.label7 = new System.Windows.Forms.Label();
	this.shipToLocTextBox = new System.Windows.Forms.TextBox();
	this.cusProdIdTextBox = new System.Windows.Forms.TextBox();
	this.orderNumberTextBox = new System.Windows.Forms.TextBox();
	this.orderItemNumberTextBox = new System.Windows.Forms.TextBox();
	this.qtyTextBox = new System.Windows.Forms.TextBox();
	this.numberOfBoxesTextBox = new System.Windows.Forms.TextBox();
	this.qtyOnHandTextBox = new System.Windows.Forms.TextBox();
	this.panel1 = new System.Windows.Forms.Panel();
	this.cancelEditButton = new System.Windows.Forms.Button();
	this.okEditButton = new System.Windows.Forms.Button();
	this.panel1.SuspendLayout();
	this.SuspendLayout();
	// 
	// label1
	// 
	this.label1.Location = new System.Drawing.Point(16, 16);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(100, 20);
	this.label1.TabIndex = 0;
	this.label1.Text = "Ship To Location";
	// 
	// label2
	// 
	this.label2.Location = new System.Drawing.Point(16, 40);
	this.label2.Name = "label2";
	this.label2.Size = new System.Drawing.Size(112, 20);
	this.label2.TabIndex = 1;
	this.label2.Text = "Customer Product Id";
	// 
	// label3
	// 
	this.label3.Location = new System.Drawing.Point(16, 64);
	this.label3.Name = "label3";
	this.label3.Size = new System.Drawing.Size(100, 20);
	this.label3.TabIndex = 2;
	this.label3.Text = "Order Number";
	// 
	// label4
	// 
	this.label4.Location = new System.Drawing.Point(16, 88);
	this.label4.Name = "label4";
	this.label4.Size = new System.Drawing.Size(112, 20);
	this.label4.TabIndex = 3;
	this.label4.Text = "Order/Item Number";
	// 
	// label5
	// 
	this.label5.Location = new System.Drawing.Point(16, 112);
	this.label5.Name = "label5";
	this.label5.Size = new System.Drawing.Size(100, 20);
	this.label5.TabIndex = 4;
	this.label5.Text = "Qty";
	// 
	// label6
	// 
	this.label6.Location = new System.Drawing.Point(16, 136);
	this.label6.Name = "label6";
	this.label6.Size = new System.Drawing.Size(100, 20);
	this.label6.TabIndex = 5;
	this.label6.Text = "Number of boxes";
	// 
	// label7
	// 
	this.label7.Location = new System.Drawing.Point(16, 160);
	this.label7.Name = "label7";
	this.label7.Size = new System.Drawing.Size(100, 20);
	this.label7.TabIndex = 6;
	this.label7.Text = "Qty On Hand";
	// 
	// shipToLocTextBox
	// 
	this.shipToLocTextBox.Location = new System.Drawing.Point(136, 16);
	this.shipToLocTextBox.Name = "shipToLocTextBox";
	this.shipToLocTextBox.Size = new System.Drawing.Size(120, 20);
	this.shipToLocTextBox.TabIndex = 7;
	this.shipToLocTextBox.Text = "";
	// 
	// cusProdIdTextBox
	// 
	this.cusProdIdTextBox.Location = new System.Drawing.Point(136, 40);
	this.cusProdIdTextBox.Name = "cusProdIdTextBox";
	this.cusProdIdTextBox.Size = new System.Drawing.Size(120, 20);
	this.cusProdIdTextBox.TabIndex = 8;
	this.cusProdIdTextBox.Text = "";
	// 
	// orderNumberTextBox
	// 
	this.orderNumberTextBox.Location = new System.Drawing.Point(136, 64);
	this.orderNumberTextBox.Name = "orderNumberTextBox";
	this.orderNumberTextBox.Size = new System.Drawing.Size(120, 20);
	this.orderNumberTextBox.TabIndex = 9;
	this.orderNumberTextBox.Text = "";
	// 
	// orderItemNumberTextBox
	// 
	this.orderItemNumberTextBox.Location = new System.Drawing.Point(136, 88);
	this.orderItemNumberTextBox.Name = "orderItemNumberTextBox";
	this.orderItemNumberTextBox.Size = new System.Drawing.Size(120, 20);
	this.orderItemNumberTextBox.TabIndex = 10;
	this.orderItemNumberTextBox.Text = "";
	// 
	// qtyTextBox
	// 
	this.qtyTextBox.Location = new System.Drawing.Point(136, 112);
	this.qtyTextBox.Name = "qtyTextBox";
	this.qtyTextBox.Size = new System.Drawing.Size(120, 20);
	this.qtyTextBox.TabIndex = 11;
	this.qtyTextBox.Text = "";
	// 
	// numberOfBoxesTextBox
	// 
	this.numberOfBoxesTextBox.Location = new System.Drawing.Point(136, 136);
	this.numberOfBoxesTextBox.Name = "numberOfBoxesTextBox";
	this.numberOfBoxesTextBox.Size = new System.Drawing.Size(120, 20);
	this.numberOfBoxesTextBox.TabIndex = 12;
	this.numberOfBoxesTextBox.Text = "";
	// 
	// qtyOnHandTextBox
	// 
	this.qtyOnHandTextBox.Enabled = false;
	this.qtyOnHandTextBox.Location = new System.Drawing.Point(136, 160);
	this.qtyOnHandTextBox.Name = "qtyOnHandTextBox";
	this.qtyOnHandTextBox.Size = new System.Drawing.Size(120, 20);
	this.qtyOnHandTextBox.TabIndex = 13;
	this.qtyOnHandTextBox.Text = "0";
	// 
	// panel1
	// 
	this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																			this.cancelEditButton,
																			this.okEditButton,
																			this.orderNumberTextBox,
																			this.label4,
																			this.label2,
																			this.cusProdIdTextBox,
																			this.label7,
																			this.label5,
																			this.orderItemNumberTextBox,
																			this.numberOfBoxesTextBox,
																			this.shipToLocTextBox,
																			this.label1,
																			this.label6,
																			this.qtyTextBox,
																			this.label3,
																			this.qtyOnHandTextBox});
	this.panel1.Location = new System.Drawing.Point(8, 8);
	this.panel1.Name = "panel1";
	this.panel1.Size = new System.Drawing.Size(376, 200);
	this.panel1.TabIndex = 14;
	// 
	// cancelEditButton
	// 
	this.cancelEditButton.Location = new System.Drawing.Point(288, 48);
	this.cancelEditButton.Name = "cancelEditButton";
	this.cancelEditButton.TabIndex = 15;
	this.cancelEditButton.Text = "Cancel";
	this.cancelEditButton.Click += new System.EventHandler(this.cancelEditButton_Click);
	// 
	// okEditButton
	// 
	this.okEditButton.Location = new System.Drawing.Point(288, 16);
	this.okEditButton.Name = "okEditButton";
	this.okEditButton.TabIndex = 14;
	this.okEditButton.Text = "Ok";
	this.okEditButton.Click += new System.EventHandler(this.okEditButton_Click);
	// 
	// EditPackagingItem
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(394, 216);
	this.Controls.AddRange(new System.Windows.Forms.Control[] {
																	this.panel1});
	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
	this.MaximizeBox = false;
	this.Name = "EditPackagingItem";
	this.Text = "Packaging Item";
	this.panel1.ResumeLayout(false);
	this.ResumeLayout(false);

}
#endregion

private
bool isDataOk(){
	if ((shipToLocTextBox.Text == null) || (shipToLocTextBox.Text.Equals(""))){
		MessageBox.Show("The Ship To Location field is empty.");
		return false;
	}
	
	if ((cusProdIdTextBox.Text == null) || (cusProdIdTextBox.Text.Equals(""))){
		MessageBox.Show("The Customer Product Id field is empty.");
		return false;
	}
    
	if ((orderNumberTextBox.Text == null) || (orderNumberTextBox.Text.Equals(""))){
		MessageBox.Show("The Order Num field is empty.");
		return false;
	}
	
	if ((orderItemNumberTextBox.Text == null) || (orderItemNumberTextBox.Text.Equals(""))){
		MessageBox.Show("The Order Item field is empty.");
		return false;
	}

	if (!NumberUtil.isIntegerNumber(orderNumberTextBox.Text)){
		MessageBox.Show("The Order Number field must be a number.");
		return false;
	}else{
		int ordNum	=int.Parse(orderNumberTextBox.Text);
		if (ordNum < 0){
			MessageBox.Show("The Order Number field could not be < 0.");
			return false;
		}
	}

	if (!NumberUtil.isIntegerNumber(orderItemNumberTextBox.Text)){
		MessageBox.Show("The Order/Item Number field must be a number.");
		return false;
	}else {
		int ordINum	=int.Parse(orderItemNumberTextBox.Text);
		if (ordINum < 0){
			MessageBox.Show("The Order/Item Number field could not be less than 1");
			return false;
		}
	}

	if (! NumberUtil.isIntegerNumber(qtyTextBox.Text)){
		MessageBox.Show("The Qty field must be a number.");
		return false;
	}else {
		decimal qtyText	=decimal.Parse(qtyTextBox.Text);
		if (qtyText < 0)	{
			MessageBox.Show("The Qty field could not be < 0.");
			return false;
		}
	}

	if (!NumberUtil.isIntegerNumber(numberOfBoxesTextBox.Text)){
		MessageBox.Show("The Number Of Boxes field must be a number.");
		return false;
	}else {
		int nOfBox = int.Parse(numberOfBoxesTextBox.Text);
		if (nOfBox < 0)	{
			MessageBox.Show("The Number of Boxes filel must be > 0.");
			return false;
		}
	}
	
	if (!NumberUtil.isIntegerNumber(numberOfBoxesTextBox.Text)){
		MessageBox.Show("The Number Of Boxes field must be a number.");
		return false;
	}else {
		int qOHand = int.Parse(qtyOnHandTextBox.Text);
/*				if (qOHand <= 0){
			MessageBox.Show("The Qty On Hand fiel must be > 0.");
			return false;
		}*/
	}
	return true;
}


private 
void okEditButton_Click(object sender, System.EventArgs e){
	if (!isDataOk())
		return;
	this.DialogResult = DialogResult.OK;
	Close();
}

private 
void cancelEditButton_Click(object sender, System.EventArgs e){
	this.DialogResult = DialogResult.Cancel;
	Close();
}

public 
string getShipToLocation(){
	return shipToLocTextBox.Text;
}

public 
string getCustomerProdId(){
	return cusProdIdTextBox.Text;
}

public 
string getOrderNumber(){
	return orderNumberTextBox.Text;
}

public 
string getOrderItemNumber(){
	return orderItemNumberTextBox.Text;
}

public 
string getQty(){
	return qtyTextBox.Text;
}

public 
string getNumberOfBoxes(){
	return numberOfBoxesTextBox.Text;
}

public 
string getQtyOnHand(){
	return qtyOnHandTextBox.Text;
}


} // class

} // namespace
