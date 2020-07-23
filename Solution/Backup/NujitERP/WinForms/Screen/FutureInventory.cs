using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Nujit.NujitERP.WinForms;

namespace Nujit.NujitERP.WinForms.Screens
{
	/// <summary>
	/// Summary description for PastInventory.
	/// </summary>
	public class FutureInventory : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox cmbPlant;
		private System.Windows.Forms.ComboBox cmbLoc;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.ComboBox comboBox4;
		private System.Windows.Forms.ComboBox comboBox5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox comboBox6;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox comboBox7;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox comboBox8;
		private System.Windows.Forms.DataGrid infoGrid;
		private DataTable dataTable;
		private System.Windows.Forms.Label label12; // (!!!)
		private FormMain formMainParent;

		public FutureInventory(FormMain formParent)
		{
			InitializeComponent();
		
			this.MdiParent = formParent;
			this.formMainParent = formParent;
			loadData() ;
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FutureInventory()
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
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		// Load data into the graphic components
		private void loadData() 
		{
			// Fill the Plants Combo
			cmbPlant.Items.Add("My Plant");
			cmbPlant.Items.Add("Other Plant");
			cmbPlant.Items.Add("Toronto Plant");
			// Fill the infoGrid (table)
			dataTable = new DataTable();

			DataColumn d0 = new DataColumn("Date", typeof(string));
			d0.DefaultValue = "";
			dataTable.Columns.Add(d0);

			DataColumn d1 = new DataColumn("Product ID", typeof(string));
			d1.DefaultValue = 0;
			dataTable.Columns.Add(d1);

			DataColumn d2 = new DataColumn("Major Group", typeof(string));
			d2.DefaultValue = 0;
			dataTable.Columns.Add(d2);
			
			DataColumn d3 = new DataColumn("Minor Group", typeof(string));
			d3.DefaultValue = 0;
			dataTable.Columns.Add(d3);

			DataColumn d4 = new DataColumn("Qty", typeof(decimal));
			d4.DefaultValue = 0;
			dataTable.Columns.Add(d4);

			DateTime start = DateTime.Today;

			for(int i = 0; i < 9; i++) 
			{
				string dateLabel = start.AddDays(i).ToShortDateString();
				DataRow dataRow = dataTable.NewRow();

				dataRow[0] = dateLabel;
				dataRow[1] = "XM-GL-5002";
				//dataRow[1] = (i < 3)? "XM-GL-5002" : "XM-GL-5017";
				dataRow[2] = "FG";
				dataRow[3] = "ELEC";
				dataRow[4] = (i * i * 2) * 5 - i + 1 ;
				
				dataTable.Rows.Add(dataRow);
			}
			DataView dataView = new DataView(dataTable);
			dataView.AllowEdit = false;
			dataView.AllowDelete = false;
			dataView.AllowNew = false;
			
			infoGrid.DataSource = dataView;
			infoGrid.CaptionText = "Information"; 
			

		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FutureInventory));
			this.cmbPlant = new System.Windows.Forms.ComboBox();
			this.cmbLoc = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.comboBox4 = new System.Windows.Forms.ComboBox();
			this.comboBox5 = new System.Windows.Forms.ComboBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.comboBox6 = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.comboBox7 = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.comboBox8 = new System.Windows.Forms.ComboBox();
			this.infoGrid = new System.Windows.Forms.DataGrid();
			this.label12 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.infoGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// cmbPlant
			// 
			this.cmbPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPlant.Location = new System.Drawing.Point(160, 40);
			this.cmbPlant.Name = "cmbPlant";
			this.cmbPlant.Size = new System.Drawing.Size(128, 21);
			this.cmbPlant.TabIndex = 1;
			// 
			// cmbLoc
			// 
			this.cmbLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLoc.Location = new System.Drawing.Point(160, 64);
			this.cmbLoc.Name = "cmbLoc";
			this.cmbLoc.Size = new System.Drawing.Size(128, 21);
			this.cmbLoc.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 20);
			this.label1.TabIndex = 4;
			this.label1.Text = "Plant";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "LOC";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(16, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 20);
			this.label3.TabIndex = 6;
			this.label3.Text = "P/M";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(16, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(136, 20);
			this.label4.TabIndex = 7;
			this.label4.Text = "Start Part";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(16, 136);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(136, 20);
			this.label5.TabIndex = 8;
			this.label5.Text = "Major Group";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(16, 160);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(136, 20);
			this.label6.TabIndex = 9;
			this.label6.Text = "Minor Group";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(16, 184);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(136, 20);
			this.label7.TabIndex = 10;
			this.label7.Text = "Show Units";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(16, 208);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(136, 20);
			this.label8.TabIndex = 11;
			this.label8.Text = "Enter Starting Date";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Location = new System.Drawing.Point(160, 88);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(128, 21);
			this.comboBox1.TabIndex = 12;
			// 
			// comboBox2
			// 
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.Location = new System.Drawing.Point(160, 112);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(128, 21);
			this.comboBox2.TabIndex = 13;
			// 
			// comboBox3
			// 
			this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox3.Location = new System.Drawing.Point(160, 136);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(128, 21);
			this.comboBox3.TabIndex = 14;
			// 
			// comboBox4
			// 
			this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox4.Location = new System.Drawing.Point(160, 160);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(128, 21);
			this.comboBox4.TabIndex = 15;
			// 
			// comboBox5
			// 
			this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox5.Location = new System.Drawing.Point(160, 184);
			this.comboBox5.Name = "comboBox5";
			this.comboBox5.Size = new System.Drawing.Size(128, 21);
			this.comboBox5.TabIndex = 16;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(160, 208);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(128, 20);
			this.textBox1.TabIndex = 17;
			this.textBox1.Text = "";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.Location = new System.Drawing.Point(312, 112);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(136, 20);
			this.label9.TabIndex = 18;
			this.label9.Text = "Ending Part";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBox6
			// 
			this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox6.Location = new System.Drawing.Point(456, 112);
			this.comboBox6.Name = "comboBox6";
			this.comboBox6.Size = new System.Drawing.Size(128, 21);
			this.comboBox6.TabIndex = 19;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label10.Location = new System.Drawing.Point(312, 136);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(136, 20);
			this.label10.TabIndex = 20;
			this.label10.Text = "Ending MajGrp";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBox7
			// 
			this.comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox7.Location = new System.Drawing.Point(456, 136);
			this.comboBox7.Name = "comboBox7";
			this.comboBox7.Size = new System.Drawing.Size(128, 21);
			this.comboBox7.TabIndex = 21;
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label11.Location = new System.Drawing.Point(312, 160);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(136, 20);
			this.label11.TabIndex = 22;
			this.label11.Text = "Ending MinGrp";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBox8
			// 
			this.comboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox8.Location = new System.Drawing.Point(456, 160);
			this.comboBox8.Name = "comboBox8";
			this.comboBox8.Size = new System.Drawing.Size(128, 21);
			this.comboBox8.TabIndex = 23;
			// 
			// infoGrid
			// 
			this.infoGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.infoGrid.DataMember = "";
			this.infoGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.infoGrid.Location = new System.Drawing.Point(16, 240);
			this.infoGrid.Name = "infoGrid";
			this.infoGrid.Size = new System.Drawing.Size(710, 304);
			this.infoGrid.TabIndex = 24;
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label12.Location = new System.Drawing.Point(0, 8);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(744, 24);
			this.label12.TabIndex = 25;
			this.label12.Text = "Future Inventory";
			this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// FutureInventory
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(742, 553);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.infoGrid);
			this.Controls.Add(this.comboBox8);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.comboBox7);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.comboBox6);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.comboBox5);
			this.Controls.Add(this.comboBox4);
			this.Controls.Add(this.comboBox3);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbLoc);
			this.Controls.Add(this.cmbPlant);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(608, 432);
			this.Name = "FutureInventory";
			this.Text = "Show Units";
			this.Load += new System.EventHandler(this.FutureInventory_Load);
			this.Closed += new System.EventHandler(this.OnClosed);
			((System.ComponentModel.ISupportInitialize)(this.infoGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

//		/// <summary>
//		/// The main entry point for the application.
//		/// </summary>
//		[STAThread]
//		static void Main() 
//		{
//			Application.Run(new FutureInventory());
//		}
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

		private void FutureInventory_Load(object sender, System.EventArgs e)
		{
		
		}


	}
}
