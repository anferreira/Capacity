using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.WinForms;


namespace GridScheduling.gui
{
	/// <summary>
	/// Summary description for DaysOnHandsForm.
	/// </summary>
	public class DaysOnHandForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.DataGrid dataGrid1;
		private DataTable dataTable;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox5;

		private FormMain formMainParent;

		public DaysOnHandForm(FormMain formParent)
		{
			//
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


		public DaysOnHandForm()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DaysOnHandForm));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Wip - 10";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(40, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "Wip - 20";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(40, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 24);
			this.label3.TabIndex = 2;
			this.label3.Text = "Wip - 30";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(40, 136);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 24);
			this.label4.TabIndex = 3;
			this.label4.Text = "FG";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(128, 40);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "0";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(128, 72);
			this.textBox2.Name = "textBox2";
			this.textBox2.TabIndex = 5;
			this.textBox2.Text = "0";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(128, 104);
			this.textBox3.Name = "textBox3";
			this.textBox3.TabIndex = 6;
			this.textBox3.Text = "";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(128, 128);
			this.textBox4.Name = "textBox4";
			this.textBox4.TabIndex = 7;
			this.textBox4.Text = "500";
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(16, 168);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(624, 296);
			this.dataGrid1.TabIndex = 35;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.Location = new System.Drawing.Point(560, 16);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 36;
			this.okButton.Text = "OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.Location = new System.Drawing.Point(560, 48);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 50;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(40, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 23);
			this.label5.TabIndex = 51;
			this.label5.Text = " Product ID ";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(128, 16);
			this.textBox5.Name = "textBox5";
			this.textBox5.TabIndex = 52;
			this.textBox5.Text = "GM-10241935";
			// 
			// DaysOnHandForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(656, 477);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(344, 312);
			this.Name = "DaysOnHandForm";
			this.Text = "Days On Hands";
			this.Closed += new System.EventHandler(this.OnClosed);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		// initialize data grid
		private
			void initializeDataGrid()
		{   
			dataTable = new DataTable();

			DataColumn d0 = new DataColumn("Date", typeof(DateTime));
			d0.DefaultValue = DateTime.Today;
			dataTable.Columns.Add(d0);

			DataColumn d1 = new DataColumn("Net", typeof(decimal));
			d1.DefaultValue = 0;
			dataTable.Columns.Add(d1);

			DataColumn d2 = new DataColumn("Cum.", typeof(decimal));
			d1.DefaultValue = 0;
			dataTable.Columns.Add(d2);
			
			DataColumn d3 = new DataColumn("Cumulative w/Inv", typeof(decimal));
			d2.DefaultValue = 0;
			dataTable.Columns.Add(d3);
			
			DataColumn d4 = new DataColumn("Prod. Sch.", typeof(decimal));
			d3.DefaultValue = 0;
			dataTable.Columns.Add(d4);
			
			DataColumn d5 = new DataColumn("Cum.Prod Sch.", typeof(decimal));
			d4.DefaultValue = 0;
			dataTable.Columns.Add(d5);
			
			DataColumn d6 = new DataColumn("Net Cum.", typeof(decimal));
			d5.DefaultValue = 0;
			dataTable.Columns.Add(d6);

			DataColumn d7 = new DataColumn("Days on Hand", typeof(decimal));
			d5.DefaultValue = 0;
			dataTable.Columns.Add(d7);

			DataColumn d8 = new DataColumn("WIP LEV1", typeof(decimal));
			d5.DefaultValue = 0;
			dataTable.Columns.Add(d8);
//
//			DataColumn d8 = new DataColumn("2nd Last Seq", typeof(decimal));
//			d5.DefaultValue = 0;
//			dataTable.Columns.Add(d8);
//
//			
//			DataColumn d9 = new DataColumn("3rd Last Seq.", typeof(decimal));
//			d5.DefaultValue = 0;
//			dataTable.Columns.Add(d9);
			DataColumn d9 = new DataColumn("WIP LEV2", typeof(decimal));
			d5.DefaultValue = 0;
			dataTable.Columns.Add(d9);
			//WIP LEV1

			DataColumn d10 = new DataColumn("Raw Mat.", typeof(decimal));
			d5.DefaultValue = 0;
			dataTable.Columns.Add(d10);

			DataColumn d11 = new DataColumn("Total Days", typeof(decimal));
			d5.DefaultValue = 0;
			dataTable.Columns.Add(d11);
		
			DataView dataView = new DataView(dataTable);

			dataView.AllowEdit = false;
			dataView.AllowDelete = false;
			dataView.AllowNew = false;

			//Arreglos definidos para la carga de datos para la demo.
			
			decimal [] Datos3 = {400,300,200,100,0,-100,-200,-300,-400,-500,-600,-700,-800,-900,-1000,-1100,-1200,-1300};
			decimal [] Datos5 = {0,0,0,500,500,500,500,500,1000,1000,1000,1000,1000,1500,1500,1500,1500,1500};
			decimal [] Datos6 = {400,300,200,600,500,400,300,200,600,500,400,300,200,600,500,400,300,200};
			decimal [] Datos8 = {0,0,7,6,5,4,3,7,6,5,4,3,7,0,0,7,7,7};
			decimal [] Datos9 = {7,7,0,7,7,7,7,0,7,7,7,7,0,7,7,2,2,2};
			decimal [] Datos10 = {2,2,7,2,2,2,2,7,2,2,2,2,7,2,2,2,7,7};
			decimal [] Datos11 = {13,12,16,21,19,17,15,16,21,19,17,15,16,15,14,15,19,18};

			for(int i = 0; i < 18; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				//La fecha tengo que cambiarla
				dataRow[0] = DateTime.Today.AddDays(i) ;
				dataRow[1] = 100;
				dataRow[2] = i*100;
				dataRow[3] = Datos3[i];
				if (i==3 || i==8 || i==13 ){
					dataRow[4] = 500;}
				dataRow[5] = Datos5[i];
				dataRow[6] = Datos6[i];
				dataRow[7] = Datos3[i]/100;
				dataRow[8] = Datos8[i];
				dataRow[9] = Datos9[i];
				dataRow[10] = Datos10[i];
				dataRow[11] = Datos11[i];
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
