using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Nujit.NujitERP.WinForms;

namespace GridScheduling.gui
{
	/// <summary>
	/// Summary description for MatReleaseHistoricalForm.
	/// </summary>
	public class MatReleaseHistoricalForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.DataGrid dataGrid1;
		private DataTable dataTable;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private FormMain formMainParent;

		public MatReleaseHistoricalForm(FormMain formParent)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		public MatReleaseHistoricalForm()
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
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.okButton = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.cancelButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(48, 24);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "Trading partner";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(48, 48);
			this.label2.Name = "label2";
			this.label2.TabIndex = 1;
			this.label2.Text = "Trading Location";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(48, 72);
			this.label3.Name = "label3";
			this.label3.TabIndex = 2;
			this.label3.Text = "PordId";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(48, 96);
			this.label4.Name = "label4";
			this.label4.TabIndex = 3;
			this.label4.Text = "Weekly Low";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(48, 120);
			this.label5.Name = "label5";
			this.label5.TabIndex = 4;
			this.label5.Text = "Weekly High";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(48, 144);
			this.label6.Name = "label6";
			this.label6.TabIndex = 5;
			this.label6.Text = "Max Weekly";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(48, 168);
			this.label7.Name = "label7";
			this.label7.TabIndex = 6;
			this.label7.Text = "Request";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(48, 192);
			this.label8.Name = "label8";
			this.label8.TabIndex = 7;
			this.label8.Text = "Min Weekly";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(48, 216);
			this.label9.Name = "label9";
			this.label9.TabIndex = 8;
			this.label9.Text = "Request";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(152, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 9;
			this.textBox1.Text = "GM";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(152, 48);
			this.textBox2.Name = "textBox2";
			this.textBox2.TabIndex = 10;
			this.textBox2.Text = "GM Location";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(152, 72);
			this.textBox3.Name = "textBox3";
			this.textBox3.TabIndex = 11;
			this.textBox3.Text = "ABC";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(152, 96);
			this.textBox4.Name = "textBox4";
			this.textBox4.TabIndex = 12;
			this.textBox4.Text = "1000";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(152, 120);
			this.textBox5.Name = "textBox5";
			this.textBox5.TabIndex = 13;
			this.textBox5.Text = "3000";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(152, 144);
			this.textBox6.Name = "textBox6";
			this.textBox6.TabIndex = 14;
			this.textBox6.Text = "";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(152, 168);
			this.textBox7.Name = "textBox7";
			this.textBox7.TabIndex = 15;
			this.textBox7.Text = "";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(152, 192);
			this.textBox8.Name = "textBox8";
			this.textBox8.TabIndex = 16;
			this.textBox8.Text = "300";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(152, 216);
			this.textBox9.Name = "textBox9";
			this.textBox9.TabIndex = 17;
			this.textBox9.Text = "";
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(632, 24);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 18;
			this.okButton.Text = "OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(16, 256);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(696, 160);
			this.dataGrid1.TabIndex = 19;
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(632, 56);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 29;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// MatReleaseHistoricalForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(728, 430);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cancelButton,
																		  this.dataGrid1,
																		  this.okButton,
																		  this.textBox9,
																		  this.textBox8,
																		  this.textBox7,
																		  this.textBox6,
																		  this.textBox5,
																		  this.textBox4,
																		  this.textBox3,
																		  this.textBox2,
																		  this.textBox1,
																		  this.label9,
																		  this.label8,
																		  this.label7,
																		  this.label6,
																		  this.label5,
																		  this.label4,
																		  this.label3,
																		  this.label2,
																		  this.label1});
			this.Name = "MatReleaseHistoricalForm";
			this.Text = "Material Release Historical Analysis";
			this.Closed += new System.EventHandler(this.OnClosed);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		//Initilize data grid
		private
			void initializeDataGrid()
		{   
			dataTable = new DataTable();

			DataColumn d0 = new DataColumn("Date", typeof(DateTime));
			d0.DefaultValue = DateTime.Today;
			dataTable.Columns.Add(d0);

			DataColumn d1 = new DataColumn("Qty Delfor", typeof(decimal));
			d1.DefaultValue = 0;
			dataTable.Columns.Add(d1);

			DataColumn d2 = new DataColumn("Qty  Jit", typeof(decimal));
			d1.DefaultValue = 0;
			dataTable.Columns.Add(d2);
			
			DataColumn d3 = new DataColumn("Qty Shipped", typeof(decimal));
			d2.DefaultValue = 0;
			dataTable.Columns.Add(d3);
			
			DataColumn d4 = new DataColumn("Diff Ship Sch/Delfor", typeof(decimal));
			d3.DefaultValue = 0;
			dataTable.Columns.Add(d4);
			
			DataColumn d5 = new DataColumn("Previous Wk Delfor", typeof(decimal));
			d4.DefaultValue = 0;
			dataTable.Columns.Add(d5);
			
			DataColumn d6 = new DataColumn("Change/Prior Wk", typeof(decimal));
			d5.DefaultValue = 0;
			dataTable.Columns.Add(d6);

			DataColumn d7 = new DataColumn("2 Week Prior", typeof(decimal));
			d5.DefaultValue = 0;
			dataTable.Columns.Add(d7);

			DataColumn d8 = new DataColumn("Change/Prior 2 Wk", typeof(decimal));
			d5.DefaultValue = 0;
			dataTable.Columns.Add(d8);
			
			DataView dataView = new DataView(dataTable);

			dataView.AllowEdit = false;
			dataView.AllowDelete = false;
			dataView.AllowNew = false;

//Generacion de los datos a mano.
			for(int i = 0; i < 21; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = DateTime.Today;
				dataRow[1] = 2000;
				dataRow[2] = 1800;
				dataRow[3] = 1800;
				dataRow[4] = -200;
				dataRow[5] = 2500;
				dataRow[6] = -500;
				dataRow[7] = 3000;
				dataRow[8] = -1000;
				dataTable.Rows.Add(dataRow);
			}
			dataGrid1.DataSource = dataView;
		}

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void okButton_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
		
	}
}
