using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Nujit.NujitERP.WinForms.Screens
{
	/// <summary>
	/// Summary description for RealTimePress.
	/// </summary>
	public class RealTimePress : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid infoGrid;
		private DataTable dataTable;
		private System.Windows.Forms.Label label1;


		private FormMain formMainParent;

		public RealTimePress(FormMain formParent)
		{
			InitializeComponent();
		
			this.MdiParent = formParent;
			this.formMainParent = formParent;
			loadData();
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


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RealTimePress()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			loadData();

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
			this.infoGrid = new System.Windows.Forms.DataGrid();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.infoGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// infoGrid
			// 
			this.infoGrid.DataMember = "";
			this.infoGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.infoGrid.Location = new System.Drawing.Point(8, 64);
			this.infoGrid.Name = "infoGrid";
			this.infoGrid.Size = new System.Drawing.Size(848, 336);
			this.infoGrid.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(312, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(200, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Real Time Shop Floor";
			// 
			// RealTimePress
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(864, 438);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1,
																		  this.infoGrid});
			this.Name = "RealTimePress";
			this.Text = "RealTimePress";
			this.Closed += new System.EventHandler(this.OnClosed);
			((System.ComponentModel.ISupportInitialize)(this.infoGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		
		// Load data into the graphic components
		private void loadData() 
		{
			// Fill the infoGrid (table)
			dataTable = new DataTable();

			DataColumn d0 = new DataColumn("Dept", typeof(string));
			d0.DefaultValue = "";
			dataTable.Columns.Add(d0);

			DataColumn d1 = new DataColumn("Mach #", typeof(string));
			d1.DefaultValue = 0;
			dataTable.Columns.Add(d1);

			DataColumn d2 = new DataColumn("Part", typeof(string));
			d2.DefaultValue = 0;
			dataTable.Columns.Add(d2);
			
			DataColumn d3 = new DataColumn("Seq", typeof(decimal));
			d3.DefaultValue = 0;
			dataTable.Columns.Add(d3);

			DataColumn d4 = new DataColumn("Job#/Order#", typeof(string));
			d4.DefaultValue = 0;
			dataTable.Columns.Add(d4);

			DataColumn d5 = new DataColumn("Good Parts", typeof(decimal));
			d5.DefaultValue = 0;
			dataTable.Columns.Add(d5);

			DataColumn d6 = new DataColumn("Parts Remaining", typeof(decimal));
			d6.DefaultValue = 0;
			dataTable.Columns.Add(d6);

			DataColumn d7 = new DataColumn("Hours Left", typeof(string));
			d7.DefaultValue = 0;
			dataTable.Columns.Add(d7);

			DataColumn d8 = new DataColumn("Shifts to go", typeof(string));
			d8.DefaultValue = 0;
			dataTable.Columns.Add(d8);

			DataColumn d9 = new DataColumn("Machine Speed", typeof(string));
			d9.DefaultValue = 0;
			dataTable.Columns.Add(d9);

			DataColumn d10 = new DataColumn("Std Speed", typeof(string));
			d10.DefaultValue = 0;
			dataTable.Columns.Add(d10);

			DataColumn d11 = new DataColumn("EFF%", typeof(string));
			d11.DefaultValue = 0;
			dataTable.Columns.Add(d11);

			DataColumn d12 = new DataColumn("Yield", typeof(string));
			d12.DefaultValue = "";
			dataTable.Columns.Add(d12);

			DataColumn d13 = new DataColumn("Std Cav", typeof(string));
			d13.DefaultValue = "";
			dataTable.Columns.Add(d13);

			DataColumn d14 = new DataColumn("Act Cav", typeof(string));
			d14.DefaultValue = "";
			dataTable.Columns.Add(d14);

			DateTime start = DateTime.Today;

			for(int i = 0; i < 9; i++) 
			{
				string dateLabel = start.ToShortDateString();
				DataRow dataRow = dataTable.NewRow();

				dataRow[0] = "10";
				dataRow[1] = "00" + i.ToString();
				dataRow[2] = "GM-35622" + i.ToString();
				dataRow[3] = "10";
				dataRow[4] = "";
				dataRow[5] = (i+3) * (i * i * i + 3);
				dataRow[6] = ((i+3) * (i * i * i + 3)) / 2;
				dataRow[7] = (i+1)*3 + ".5";
				dataRow[8] = (12 - i) * 2;
				dataRow[9] = 100 + (i * 3 + 1);
				dataRow[10] = 102 + (i * 3 + 1);
				dataRow[11] = "10" + i + "%";


				
				dataTable.Rows.Add(dataRow);
			}
			DataView dataView = new DataView(dataTable);
			dataView.AllowEdit = false;
			dataView.AllowDelete = false;
			dataView.AllowNew = false;
			
			infoGrid.DataSource = dataView;
			infoGrid.CaptionText = "Information"; 

		}

	}


}
