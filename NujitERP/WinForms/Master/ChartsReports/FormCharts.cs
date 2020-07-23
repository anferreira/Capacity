using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace	Nujit.NujitERP.WinForms.Master.ChartsReports
{
	/// <summary>
	/// Summary description for FormCharts.
	/// </summary>
	public class FormCharts : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pBoxCharts;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.PictureBox pictureBoxProduction;
		private System.Windows.Forms.ToolTip toolTip;
		private System.ComponentModel.IContainer components;

		public FormCharts()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormCharts));
			this.pBoxCharts = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.pictureBoxProduction = new System.Windows.Forms.PictureBox();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// pBoxCharts
			// 
			this.pBoxCharts.Image = ((System.Drawing.Image)(resources.GetObject("pBoxCharts.Image")));
			this.pBoxCharts.Location = new System.Drawing.Point(16, 24);
			this.pBoxCharts.Name = "pBoxCharts";
			this.pBoxCharts.Size = new System.Drawing.Size(72, 72);
			this.pBoxCharts.TabIndex = 25;
			this.pBoxCharts.TabStop = false;
			this.toolTip.SetToolTip(this.pBoxCharts, "Charts");
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(160, 48);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(520, 4);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
			this.label7.Location = new System.Drawing.Point(152, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 16);
			this.label7.TabIndex = 23;
			// 
			// pictureBoxProduction
			// 
			this.pictureBoxProduction.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxProduction.Image")));
			this.pictureBoxProduction.Location = new System.Drawing.Point(160, 96);
			this.pictureBoxProduction.Name = "pictureBoxProduction";
			this.pictureBoxProduction.Size = new System.Drawing.Size(72, 72);
			this.pictureBoxProduction.TabIndex = 26;
			this.pictureBoxProduction.TabStop = false;
			this.toolTip.SetToolTip(this.pictureBoxProduction, "Production History");
			this.pictureBoxProduction.Click += new System.EventHandler(this.pictureBoxProduction_Click);
			// 
			// FormCharts
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(217)), ((System.Byte)(196)), ((System.Byte)(175)));
			this.ClientSize = new System.Drawing.Size(736, 486);
			this.Controls.Add(this.pictureBoxProduction);
			this.Controls.Add(this.pBoxCharts);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label7);
			this.Name = "FormCharts";
			this.Text = "Charts";
			this.ResumeLayout(false);

		}
		#endregion

		private void pictureBoxProduction_Click(object sender, System.EventArgs e)
		{
			FormChartProductionHistory formChartProductionHistory= new FormChartProductionHistory();
			formChartProductionHistory.ShowDialog();
		}
	}
}
