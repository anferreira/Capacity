using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.WinForms.Master.ChartsReports;


namespace Nujit.NujitERP.WinForms.Master
{
	/// <summary>
	/// Summary description for FormChartsAndReports.
	/// </summary>
	public class FormChartsAndReports : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.PictureBox pictureBoxChartReports;
		private System.Windows.Forms.PictureBox pBoxCharts;
		private System.Windows.Forms.PictureBox pictureBoxReports;
		private System.Windows.Forms.ToolTip toolTip;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.Label labelCharts;
		private System.Windows.Forms.Label labelReports;

		private FormMain formMainParent;

		public FormChartsAndReports()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public FormChartsAndReports(FormMain formParent)
		{
			InitializeComponent();

			this.MdiParent = formParent;
			this.formMainParent = formParent;
			//this.toolTip1.
			
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormChartsAndReports));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.pictureBoxChartReports = new System.Windows.Forms.PictureBox();
			this.pBoxCharts = new System.Windows.Forms.PictureBox();
			this.pictureBoxReports = new System.Windows.Forms.PictureBox();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.labelCharts = new System.Windows.Forms.Label();
			this.labelReports = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(160, 168);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(872, 4);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
			this.label7.Location = new System.Drawing.Point(160, 144);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(160, 16);
			this.label7.TabIndex = 19;
			// 
			// pictureBoxChartReports
			// 
			this.pictureBoxChartReports.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxChartReports.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBoxChartReports.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxChartReports.Image")));
			this.pictureBoxChartReports.Location = new System.Drawing.Point(16, 104);
			this.pictureBoxChartReports.Name = "pictureBoxChartReports";
			this.pictureBoxChartReports.Size = new System.Drawing.Size(130, 92);
			this.pictureBoxChartReports.TabIndex = 18;
			this.pictureBoxChartReports.TabStop = false;
			this.toolTip.SetToolTip(this.pictureBoxChartReports, "Chart and Reports");
			// 
			// pBoxCharts
			// 
			this.pBoxCharts.Image = ((System.Drawing.Image)(resources.GetObject("pBoxCharts.Image")));
			this.pBoxCharts.Location = new System.Drawing.Point(160, 208);
			this.pBoxCharts.Name = "pBoxCharts";
			this.pBoxCharts.Size = new System.Drawing.Size(72, 72);
			this.pBoxCharts.TabIndex = 21;
			this.pBoxCharts.TabStop = false;
			this.toolTip.SetToolTip(this.pBoxCharts, "Charts");
			this.pBoxCharts.Click += new System.EventHandler(this.pBoxCharts_Click);
			// 
			// pictureBoxReports
			// 
			this.pictureBoxReports.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxReports.Image")));
			this.pictureBoxReports.Location = new System.Drawing.Point(160, 296);
			this.pictureBoxReports.Name = "pictureBoxReports";
			this.pictureBoxReports.Size = new System.Drawing.Size(72, 72);
			this.pictureBoxReports.TabIndex = 22;
			this.pictureBoxReports.TabStop = false;
			this.toolTip.SetToolTip(this.pictureBoxReports, "Reports");
			this.pictureBoxReports.Click += new System.EventHandler(this.pictureBoxReports_Click);
			// 
			// pictureBox4
			// 
			this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
			this.pictureBox4.Location = new System.Drawing.Point(0, 0);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(1080, 88);
			this.pictureBox4.TabIndex = 27;
			this.pictureBox4.TabStop = false;
			// 
			// labelCharts
			// 
			this.labelCharts.BackColor = System.Drawing.Color.Transparent;
			this.labelCharts.Image = ((System.Drawing.Image)(resources.GetObject("labelCharts.Image")));
			this.labelCharts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelCharts.Location = new System.Drawing.Point(240, 248);
			this.labelCharts.Name = "labelCharts";
			this.labelCharts.Size = new System.Drawing.Size(56, 16);
			this.labelCharts.TabIndex = 29;
			this.labelCharts.Click += new System.EventHandler(this.labelCharts_Click);
			// 
			// labelReports
			// 
			this.labelReports.BackColor = System.Drawing.Color.Transparent;
			this.labelReports.Image = ((System.Drawing.Image)(resources.GetObject("labelReports.Image")));
			this.labelReports.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.labelReports.Location = new System.Drawing.Point(240, 336);
			this.labelReports.Name = "labelReports";
			this.labelReports.Size = new System.Drawing.Size(64, 16);
			this.labelReports.TabIndex = 30;
			// 
			// FormChartsAndReports
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(217)), ((System.Byte)(196)), ((System.Byte)(175)));
			this.ClientSize = new System.Drawing.Size(680, 486);
			this.Controls.Add(this.labelReports);
			this.Controls.Add(this.labelCharts);
			this.Controls.Add(this.pictureBox4);
			this.Controls.Add(this.pictureBoxReports);
			this.Controls.Add(this.pBoxCharts);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.pictureBoxChartReports);
			this.Name = "FormChartsAndReports";
			this.Text = "Charts and Reports";
			this.Closed += new System.EventHandler(this.FormChartsAndReports_Closed);
			this.ResumeLayout(false);

		}
		#endregion

		private void pBoxCharts_Click(object sender, System.EventArgs e)
		{
			FormCharts formCharts = new FormCharts();

			formCharts.ShowDialog();
		}

		private void pictureBoxReports_Click(object sender, System.EventArgs e)
		{
		
		}

		
		private void FormChartsAndReports_Closed(object sender, System.EventArgs e)
		{
			if (this.formMainParent != null)
			{
				this.formMainParent.RemoveTab(this.Tag);

				this.formMainParent.SetButtons();
			}	
		}

		private void labelCharts_Click(object sender, System.EventArgs e)
		{
			FormCharts formCharts = new FormCharts();

			formCharts.ShowDialog();
		}
	}
}
