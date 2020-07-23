using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Nujit.NujitERP.WinForms;

using Nujit.NujitERP.ClassLib.Util;

namespace GridScheduling.gui{
	/// <summary>
	/// Summary description for CustomerDemandForm.
	/// </summary>
	public class CustomerDemandForm : System.Windows.Forms.Form{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.ComboBox comboBox4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DataGrid demandDataGrid;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private FormMain formMainParent;

		public CustomerDemandForm(FormMain formParent){
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.initializeDemandGrid();
		
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

		private DataTable dataTable;


		public CustomerDemandForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.initializeDemandGrid();
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
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.comboBox4 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.demandDataGrid = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.demandDataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "ProdID";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(40, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 15);
			this.label2.TabIndex = 1;
			this.label2.Text = "Customer";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(40, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 15);
			this.label4.TabIndex = 3;
			this.label4.Text = "Destination";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(40, 104);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 15);
			this.label5.TabIndex = 4;
			this.label5.Text = "# of Locations";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(152, 32);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 5;
			this.comboBox1.Text = "PROD";
			// 
			// comboBox2
			// 
			this.comboBox2.Location = new System.Drawing.Point(152, 56);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(121, 21);
			this.comboBox2.TabIndex = 6;
			this.comboBox2.Text = "* All";
			// 
			// comboBox3
			// 
			this.comboBox3.Location = new System.Drawing.Point(152, 80);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(121, 21);
			this.comboBox3.TabIndex = 7;
			this.comboBox3.Text = "* All";
			// 
			// comboBox4
			// 
			this.comboBox4.Location = new System.Drawing.Point(152, 104);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(121, 21);
			this.comboBox4.TabIndex = 8;
			this.comboBox4.Text = "* All";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(432, 16);
			this.button1.Name = "button1";
			this.button1.TabIndex = 9;
			this.button1.Text = "OK";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(432, 48);
			this.button2.Name = "button2";
			this.button2.TabIndex = 10;
			this.button2.Text = "Details";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// demandDataGrid
			// 
			this.demandDataGrid.DataMember = "";
			this.demandDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.demandDataGrid.Location = new System.Drawing.Point(16, 136);
			this.demandDataGrid.Name = "demandDataGrid";
			this.demandDataGrid.Size = new System.Drawing.Size(496, 144);
			this.demandDataGrid.TabIndex = 11;
			// 
			// CustomerDemandForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(528, 293);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.demandDataGrid,
																		  this.button2,
																		  this.button1,
																		  this.comboBox4,
																		  this.comboBox3,
																		  this.comboBox2,
																		  this.comboBox1,
																		  this.label5,
																		  this.label4,
																		  this.label2,
																		  this.label1});
			this.Name = "CustomerDemandForm";
			this.Text = "Customer Demand";
			this.Closed += new System.EventHandler(this.OnClosed);
			((System.ComponentModel.ISupportInitialize)(this.demandDataGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private 
		void button1_Click(object sender, System.EventArgs e){
			this.Dispose();
		}

		private 
		void button2_Click(object sender, System.EventArgs e){
			DetailCustomerDemandForm form = new DetailCustomerDemandForm();
			form.ShowDialog();
		}

		private
		void initializeDemandGrid(){
            dataTable = new DataTable();

			DataColumn d0 = new DataColumn("Start Date", typeof(string));
			d0.DefaultValue = DateTime.Today;
			dataTable.Columns.Add(d0);

			DataColumn d1 = new DataColumn("Delfor", typeof(string));
			d1.DefaultValue = "";
			dataTable.Columns.Add(d1);
			
			DataColumn d2 = new DataColumn("Cumulative Shipped", typeof(string));
			d2.DefaultValue = "";
			dataTable.Columns.Add(d2);
			
			DataColumn d3 = new DataColumn("Qty", typeof(string));
			d3.DefaultValue = "";
			dataTable.Columns.Add(d3);
			
			DataColumn d4 = new DataColumn("Send to Schedule", typeof(string));
			d4.DefaultValue = "";
			dataTable.Columns.Add(d4);
			
			DataColumn d5 = new DataColumn("Scheduled", typeof(string));
			d5.DefaultValue = "";
			dataTable.Columns.Add(d5);

			DateTime date = new DateTime(2004, 04, 26, 0, 0, 0, 0);
			for(int i = 0; i < 20; i++){
				DataRow dataRow = dataTable.NewRow();
				
				dataRow[0] = DateUtil.getDateRepresentation(date, DateUtil.MMDDYYYY);
				dataRow[1] = "1000";
				dataRow[2] = "";
				dataRow[3] = "";
				dataRow[4] = "";
				dataRow[5] = "";
				dataTable.Rows.Add(dataRow);

				date = date.AddDays(1);
			}

			DataView dataView = new DataView(dataTable);

			dataView.AllowEdit = false;
			dataView.AllowDelete = false;
			dataView.AllowNew = false;
			
			demandDataGrid.DataSource = dataView;
		}
	
	
	
	}
}
