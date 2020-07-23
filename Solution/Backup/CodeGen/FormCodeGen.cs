using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

//using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.CodeGen
{
	/// <summary>
	/// Summary description for FormCodeGen.
	/// </summary>
	public class FormCodeGen : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblID;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxID;
		private System.Windows.Forms.Panel panelTitle;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBoxSN;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormCodeGen()
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
				if (components != null) 
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
			this.lblID = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxID = new System.Windows.Forms.TextBox();
			this.panelTitle = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.textBoxSN = new System.Windows.Forms.TextBox();
			this.panelTitle.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblID
			// 
			this.lblID.Location = new System.Drawing.Point(64, 88);
			this.lblID.Name = "lblID";
			this.lblID.Size = new System.Drawing.Size(72, 23);
			this.lblID.TabIndex = 0;
			this.lblID.Text = "Prod Code";
			this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(56, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Serial Number";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxID
			// 
			this.textBoxID.Location = new System.Drawing.Point(144, 88);
			this.textBoxID.MaxLength = 10;
			this.textBoxID.Name = "textBoxID";
			this.textBoxID.Size = new System.Drawing.Size(288, 20);
			this.textBoxID.TabIndex = 2;
			this.textBoxID.Text = "";
			// 
			// panelTitle
			// 
			this.panelTitle.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.panelTitle.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.label3,
																					 this.label1});
			this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTitle.Name = "panelTitle";
			this.panelTitle.Size = new System.Drawing.Size(506, 64);
			this.panelTitle.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(72, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(304, 16);
			this.label3.TabIndex = 1;
			this.label3.Text = "Input Prod Code , then click generate button";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(224, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Serial Number Generator";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(352, 160);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 24);
			this.button1.TabIndex = 6;
			this.button1.Text = "Generate";
//			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBoxSN
			// 
			this.textBoxSN.Location = new System.Drawing.Point(144, 120);
			this.textBoxSN.Name = "textBoxSN";
			this.textBoxSN.Size = new System.Drawing.Size(288, 20);
			this.textBoxSN.TabIndex = 7;
			this.textBoxSN.Text = "";
			// 
			// FormCodeGen
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(506, 208);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.textBoxSN,
																		  this.button1,
																		  this.panelTitle,
																		  this.textBoxID,
																		  this.label2,
																		  this.lblID});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(544, 288);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(544, 288);
			this.Name = "FormCodeGen";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Serial Number generator";
//			this.Load += new System.EventHandler(this.FormCodeGen_Load);
			this.panelTitle.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormCodeGen());
		}

/*		private void FormCodeGen_Load(object sender, System.EventArgs e)
		{
		
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (this.textBoxID.Text == string.Empty) return;

			Nujit.NujitERP.ClassLib.Encryption.BlowfishSimple objBlowFish = new Nujit.NujitERP.ClassLib.Encryption.BlowfishSimple(Configuration.EncryKey);
			this.textBoxSN.Text =   (objBlowFish.Encrypt(this.textBoxID.Text));
		}*/
	}
}
