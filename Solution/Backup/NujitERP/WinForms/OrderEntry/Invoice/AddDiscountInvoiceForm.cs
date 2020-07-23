using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Nujit.NujitERP.WinForms.OrderEntry.Invoice
{
	/// <summary>
	/// Summary description for AddDiscountInvoiceForm.
	/// </summary>
	public class AddDiscountInvoiceForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private NujitCustomWinControls.NumericTextBox numericTextBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox textBox4;
        private NujitCustomWinControls.NumericTextBox numericTextBox2;
        private NujitCustomWinControls.NumericTextBox numericTextBox3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddDiscountInvoiceForm()
		{
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.numericTextBox1 = new NujitCustomWinControls.NumericTextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.numericTextBox2 = new NujitCustomWinControls.NumericTextBox();
            this.numericTextBox3 = new NujitCustomWinControls.NumericTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Discount Code";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Invoice Line#";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(208, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Invoice#";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(256, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = " Overall Disc. %";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(256, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "Discount Line";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 23);
            this.label7.TabIndex = 7;
            this.label7.Text = "Part #";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 23);
            this.label8.TabIndex = 8;
            this.label8.Text = "Discount %";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 23);
            this.label9.TabIndex = 9;
            this.label9.Text = "Discount Amt.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(216, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 16);
            this.button1.TabIndex = 10;
            this.button1.Text = "...";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(328, 168);
            this.btnOk.Name = "btnOk";
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(408, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericTextBox3);
            this.groupBox1.Controls.Add(this.numericTextBox2);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.numericTextBox1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 160);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(104, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(72, 20);
            this.textBox2.TabIndex = 11;
            this.textBox2.Text = "";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(264, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(72, 20);
            this.textBox3.TabIndex = 12;
            this.textBox3.Text = "";
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Location = new System.Drawing.Point(352, 96);
            this.numericTextBox1.Maximum = new System.Decimal(new int[] {
                                                                            1000000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox1.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.Size = new System.Drawing.Size(48, 20);
            this.numericTextBox1.TabIndex = 13;
            this.numericTextBox1.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(352, 120);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown1.TabIndex = 14;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(104, 40);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.TabIndex = 15;
            this.textBox4.Text = "";
            // 
            // numericTextBox2
            // 
            this.numericTextBox2.Location = new System.Drawing.Point(104, 96);
            this.numericTextBox2.Maximum = new System.Decimal(new int[] {
                                                                            1000000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox2.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox2.Name = "numericTextBox2";
            this.numericTextBox2.Size = new System.Drawing.Size(48, 20);
            this.numericTextBox2.TabIndex = 16;
            this.numericTextBox2.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // numericTextBox3
            // 
            this.numericTextBox3.Location = new System.Drawing.Point(104, 120);
            this.numericTextBox3.Maximum = new System.Decimal(new int[] {
                                                                            1000000,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox3.Minimum = new System.Decimal(new int[] {
                                                                            0,
                                                                            0,
                                                                            0,
                                                                            0});
            this.numericTextBox3.Name = "numericTextBox3";
            this.numericTextBox3.Size = new System.Drawing.Size(120, 20);
            this.numericTextBox3.TabIndex = 17;
            this.numericTextBox3.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // AddDiscountInvoiceForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(496, 206);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Name = "AddDiscountInvoiceForm";
            this.Text = "Add Discount Invoice";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

private void btnCancel_Click(object sender, System.EventArgs e){

    Close();
}

private void btnOk_Click(object sender, System.EventArgs e){
    
    //Save the information before
    Close();
}

}//end class
}//end namespace
