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

namespace Nujit.NujitERP.WinForms.SearchForms.OrderEntry{
	/// <summary>
	/// Summary description for RequestSearchForm.
	/// </summary>
	public class RequestSearchForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGrid dGridRequest;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnAddQuote;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private NujitCustomWinControls.NumericTextBox numericTextBox1;
        private NujitCustomWinControls.NumericTextBox numericTextBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Button btnSch;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolTip toolTip1;
		private DataTable dataTable;

		public RequestSearchForm()
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSch = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericTextBox2 = new NujitCustomWinControls.NumericTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericTextBox1 = new NujitCustomWinControls.NumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dGridRequest = new System.Windows.Forms.DataGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddQuote = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridRequest)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSch);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.textBox16);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.textBox15);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.textBox14);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.textBox13);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.textBox12);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox11);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.numericTextBox2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numericTextBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(664, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSch
            // 
            this.btnSch.Location = new System.Drawing.Point(576, 208);
            this.btnSch.Name = "btnSch";
            this.btnSch.TabIndex = 42;
            this.btnSch.Text = "Search";
            this.btnSch.Click += new System.EventHandler(this.btnSch_Click);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(344, 92);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 20);
            this.label19.TabIndex = 41;
            this.label19.Text = "Cat 2";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(384, 92);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(240, 20);
            this.textBox16.TabIndex = 40;
            this.textBox16.Text = "";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(344, 112);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 20);
            this.label18.TabIndex = 39;
            this.label18.Text = "Cat 3";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(384, 112);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(240, 20);
            this.textBox15.TabIndex = 38;
            this.textBox15.Text = "";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(344, 132);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 20);
            this.label17.TabIndex = 37;
            this.label17.Text = "Cat 4";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(384, 132);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(240, 20);
            this.textBox14.TabIndex = 36;
            this.textBox14.Text = "";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(344, 152);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 20);
            this.label16.TabIndex = 35;
            this.label16.Text = "Cat 5";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(384, 152);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(240, 20);
            this.textBox13.TabIndex = 34;
            this.textBox13.Text = "";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(344, 172);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 20);
            this.label15.TabIndex = 33;
            this.label15.Text = "Cat 6";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(384, 172);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(240, 20);
            this.textBox12.TabIndex = 32;
            this.textBox12.Text = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(344, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Cat 1";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(384, 72);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(240, 20);
            this.textBox11.TabIndex = 30;
            this.textBox11.Text = "";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(16, 112);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 20);
            this.label14.TabIndex = 29;
            this.label14.Text = "Feature 3";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(80, 112);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(240, 20);
            this.textBox10.TabIndex = 28;
            this.textBox10.Text = "";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(16, 132);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 20);
            this.label13.TabIndex = 27;
            this.label13.Text = "Feature 4";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(80, 132);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(240, 20);
            this.textBox9.TabIndex = 26;
            this.textBox9.Text = "";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(16, 152);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 20);
            this.label12.TabIndex = 25;
            this.label12.Text = "Feature 5";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(80, 152);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(240, 20);
            this.textBox8.TabIndex = 24;
            this.textBox8.Text = "";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(16, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "Feature 6";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(80, 172);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(240, 20);
            this.textBox7.TabIndex = 22;
            this.textBox7.Text = "";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(16, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Feature 7";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(80, 192);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(240, 20);
            this.textBox6.TabIndex = 20;
            this.textBox6.Text = "";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(16, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Feature 8";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(80, 212);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(240, 20);
            this.textBox5.TabIndex = 18;
            this.textBox5.Text = "";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Feature 2";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(80, 92);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(240, 20);
            this.textBox4.TabIndex = 16;
            this.textBox4.Text = "";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Feature 1";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(80, 72);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(240, 20);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(384, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 24);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Available";
            // 
            // numericTextBox2
            // 
            this.numericTextBox2.Location = new System.Drawing.Point(296, 36);
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
            this.numericTextBox2.TabIndex = 12;
            this.numericTextBox2.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(200, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "High Price Range";
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Location = new System.Drawing.Point(296, 16);
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
            this.numericTextBox1.TabIndex = 10;
            this.numericTextBox1.Value = new System.Decimal(new int[] {
                                                                          0,
                                                                          0,
                                                                          0,
                                                                          0});
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(200, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Low Price Range";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Model";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(88, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(64, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Manufacturer";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dGridRequest);
            this.groupBox2.Location = new System.Drawing.Point(8, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(664, 232);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dGridRequest
            // 
            this.dGridRequest.DataMember = "";
            this.dGridRequest.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridRequest.Location = new System.Drawing.Point(8, 16);
            this.dGridRequest.Name = "dGridRequest";
            this.dGridRequest.Size = new System.Drawing.Size(648, 208);
            this.dGridRequest.TabIndex = 0;
            this.toolTip1.SetToolTip(this.dGridRequest, "Here");
            this.dGridRequest.Click += new System.EventHandler(this.dGridRequest_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.btnAddQuote);
            this.groupBox3.Controls.Add(this.btnAddOrder);
            this.groupBox3.Location = new System.Drawing.Point(8, 480);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(664, 48);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(584, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddQuote
            // 
            this.btnAddQuote.Location = new System.Drawing.Point(496, 16);
            this.btnAddQuote.Name = "btnAddQuote";
            this.btnAddQuote.TabIndex = 1;
            this.btnAddQuote.Text = "Add Quote";
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(408, 16);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.TabIndex = 0;
            this.btnAddOrder.Text = "Add Order";
            // 
            // RequestSearchForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(688, 534);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RequestSearchForm";
            this.Text = "Request Search";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridRequest)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

private void btnCancel_Click(object sender, System.EventArgs e){
    Close();
}

private void btnSch_Click(object sender, System.EventArgs e){
    loadGrid();
    loadData();
}

private void loadGrid(){
 
    try{   
        dataTable = new DataTable();
        DataSet listDataSet = new DataSet();	
        string tableName = "request";
        string[][] vecNames = loadColumnsNames();
        Grid.addColumns(vecNames,tableName,dataTable,this.dGridRequest);
        
        //se deberia cargar la info del invoice si es un invoice que existe.
          
    }catch(NujitException ne){
        
	    FormException formException = new FormException(ne);
	    formException.ShowDialog();
    }        

}

private string[][] loadColumnsNames(){
string[][] vec = new String[7][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
		     case "0":
				v[0]="Manufacturer";
				v[1] = "100";
				break;
		     case "1":
				v[0]="Model";
				v[1] = "90";
				break;
		     case "2":
				v[0]="Availability";
				v[1] = "100";
				break;
			case "3":
				v[0]="Part #";
				v[1] = "90";
				break;
			case "4":
				v[0]="Price";
				v[1] = "90";
				break;
			case "5":
				v[0]="Cost";
				v[1] = "90";
				break;
	        case "6":
				v[0]="Gross Margin";
				v[1] = "90";
				break;				
  		}
		vec[i]=v;
		i++;	
	}
	return vec;
}

private void loadData(){

for (int i=0; i<3 ; i++){
    DataRow dr = this.dataTable.NewRow();
	dr[0] = "Manufacturer:" +i.ToString();
	dr[1] = "Model:"  +i.ToString();
	dr[2] = "Aval:"  +i.ToString();
	dr[3] = "Part:"  +i.ToString();
	dr[4] = "Price:" +i.ToString();
	dr[5] = "Costs:" +i.ToString();
	dr[6] = "Gross:" +i.ToString();
	
	dataTable.Rows.Add(dr);
}				

}

private void dGridRequest_Click(object sender, System.EventArgs e){
   int rowNumber = this.dGridRequest.CurrentCell.RowNumber;
    string[] selected = Grid.getSelected(rowNumber,dGridRequest,dataTable);
    this.toolTip1.SetToolTip(this.dGridRequest,"Part information: Feature1, More Information"+ selected[0]+"-"+selected[1]+"\n"+
	                                           "Part information: Feature2, More Information \n");


}


}//end class
}//end namespace
