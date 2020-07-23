using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Nujit.NujitERP.WinForms;


namespace GridScheduling.gui{
	/// <summary>
	/// Summary description for DetailCustomerDemandForm.
	/// </summary>
	public class DetailCustomerDemandForm : System.Windows.Forms.Form{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.DataGrid dataGrid1;
		private DataTable dataTable;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private FormMain formMainParent;

		public DetailCustomerDemandForm(FormMain formParent)
		{
			InitializeComponent();
			initializeDataGrid();
		
			this.MdiParent = formParent;
			this.formMainParent = formParent;
		}

		#region Must Have
		private void OnClosed(object sender, System.EventArgs e)
		{
			if (this.formMainParent != null)
			{
				this.formMainParent.RemoveTab(this.Tag);

				this.formMainParent.SetButtons();
			}	
		}
		#endregion Must Have


		public DetailCustomerDemandForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			initializeDataGrid();

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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.OkButton = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Customer";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(264, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Ending Date";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(264, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Starting Date";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(264, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Past Due Qty";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(264, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 16);
			this.label5.TabIndex = 4;
			this.label5.Text = "Cumulative Value";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 64);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 16);
			this.label6.TabIndex = 5;
			this.label6.Text = "Past Due";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 40);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 16);
			this.label7.TabIndex = 6;
			this.label7.Text = "Destination All";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(376, 64);
			this.textBox2.Name = "textBox2";
			this.textBox2.TabIndex = 8;
			this.textBox2.Text = "";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(376, 40);
			this.textBox3.Name = "textBox3";
			this.textBox3.TabIndex = 9;
			this.textBox3.Text = "";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(376, 16);
			this.textBox4.Name = "textBox4";
			this.textBox4.TabIndex = 10;
			this.textBox4.Text = "";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(104, 64);
			this.textBox5.Name = "textBox5";
			this.textBox5.TabIndex = 11;
			this.textBox5.Text = "";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(104, 40);
			this.textBox6.Name = "textBox6";
			this.textBox6.TabIndex = 12;
			this.textBox6.Text = "";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(376, 88);
			this.textBox7.Name = "textBox7";
			this.textBox7.TabIndex = 13;
			this.textBox7.Text = "";
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(496, 16);
			this.OkButton.Name = "OkButton";
			this.OkButton.TabIndex = 14;
			this.OkButton.Text = "Ok";
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(16, 128);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(560, 136);
			this.dataGrid1.TabIndex = 16;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(496, 48);
			this.button1.Name = "button1";
			this.button1.TabIndex = 23;
			this.button1.Text = "Cancel";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(104, 16);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 24;
			this.comboBox1.Text = "* All";
			// 
			// DetailCustomerDemandForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 278);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.comboBox1,
																		  this.button1,
																		  this.dataGrid1,
																		  this.OkButton,
																		  this.textBox7,
																		  this.textBox6,
																		  this.textBox5,
																		  this.textBox4,
																		  this.textBox3,
																		  this.textBox2,
																		  this.label7,
																		  this.label6,
																		  this.label5,
																		  this.label4,
																		  this.label3,
																		  this.label2,
																		  this.label1});
			this.Name = "DetailCustomerDemandForm";
			this.Text = "Detail Customer Demand";
			this.Closed += new System.EventHandler(this.OnClosed);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void CancelButton_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		// initialize data grid
		private
			void initializeDataGrid()
		{   
			dataTable = new DataTable();

			DataColumn d0 = new DataColumn("Start Date", typeof(DateTime));
			d0.DefaultValue = DateTime.Today;
			dataTable.Columns.Add(d0);

			DataColumn d1 = new DataColumn("Period Type", typeof(string));
			d1.DefaultValue = "";
			dataTable.Columns.Add(d1);

			DataColumn d2 = new DataColumn("Dem Type", typeof(string));
			d2.DefaultValue = "";
			dataTable.Columns.Add(d2);
			
			DataColumn d3 = new DataColumn("Auth.", typeof(string));
			d3.DefaultValue = "";
			dataTable.Columns.Add(d3);
			
			DataColumn d4 = new DataColumn("Del Jit", typeof(string));
			d4.DefaultValue = "";
			dataTable.Columns.Add(d4);
			
			
			DataView dataView = new DataView(dataTable);

		

			for(int i = 0; i < 18; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				//La fecha tengo que cambiarla
				dataRow[0] = DateTime.Today;
				if (i==0||i==7|| i==14){
					dataRow[1]='W';
				}
				if (i<5){
					dataRow[4]=200;
				}
				else if (i>6 && i<12){
					 	dataRow[4]=100;
				}
				dataTable.Rows.Add(dataRow);
			}
			dataView.AllowEdit = false;
			dataView.AllowDelete = false;
			dataView.AllowNew = false;
			dataGrid1.DataSource = dataView;
						
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void OkButton_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
		
	}
}
