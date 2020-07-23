using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Nujit.NujitERP.WinForms;

namespace Nujit.NujitERP.WinForms.Demo
{
	/// <summary>
	/// Summary description for Formdemo.
	/// </summary>
	public class FormDemo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox cmBoxProduct;
		private System.Windows.Forms.Label lblProd;
		private System.Windows.Forms.Label lblHot;
		private System.Windows.Forms.ComboBox cmBoxHot;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button btnGo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.DomainUpDown domainUpDown1;
		private System.Windows.Forms.NumericUpDown numUpDownStartHour;
		private System.Windows.Forms.NumericUpDown numUpDownEndHour;
		private System.Windows.Forms.TextBox textBoxHours;
		private System.Windows.Forms.TabPage tabPage2;

		#region Vars
		private FormMain formMainParent;
		#endregion Vars

		public FormDemo(FormMain formParent)
		{
			InitializeComponent();
		
			this.MdiParent = formParent;
			this.formMainParent = formParent;
		}
		public FormDemo()
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
			this.cmBoxProduct = new System.Windows.Forms.ComboBox();
			this.lblProd = new System.Windows.Forms.Label();
			this.lblHot = new System.Windows.Forms.Label();
			this.cmBoxHot = new System.Windows.Forms.ComboBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.btnGo = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.textBoxHours = new System.Windows.Forms.TextBox();
			this.numUpDownEndHour = new System.Windows.Forms.NumericUpDown();
			this.numUpDownStartHour = new System.Windows.Forms.NumericUpDown();
			this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numUpDownEndHour)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numUpDownStartHour)).BeginInit();
			this.SuspendLayout();
			// 
			// cmBoxProduct
			// 
			this.cmBoxProduct.Location = new System.Drawing.Point(160, 24);
			this.cmBoxProduct.Name = "cmBoxProduct";
			this.cmBoxProduct.Size = new System.Drawing.Size(121, 21);
			this.cmBoxProduct.TabIndex = 0;
			this.cmBoxProduct.Text = "Choose Product";
			// 
			// lblProd
			// 
			this.lblProd.Location = new System.Drawing.Point(56, 24);
			this.lblProd.Name = "lblProd";
			this.lblProd.TabIndex = 1;
			this.lblProd.Text = "Product";
			// 
			// lblHot
			// 
			this.lblHot.Location = new System.Drawing.Point(336, 24);
			this.lblHot.Name = "lblHot";
			this.lblHot.TabIndex = 2;
			this.lblHot.Text = "Hot (a,b,c)";
			// 
			// cmBoxHot
			// 
			this.cmBoxHot.Location = new System.Drawing.Point(464, 24);
			this.cmBoxHot.Name = "cmBoxHot";
			this.cmBoxHot.Size = new System.Drawing.Size(121, 21);
			this.cmBoxHot.TabIndex = 3;
			this.cmBoxHot.Text = "Choose A, B, C";
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(16, 424);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(752, 128);
			this.dataGrid1.TabIndex = 4;
			// 
			// btnGo
			// 
			this.btnGo.Location = new System.Drawing.Point(648, 24);
			this.btnGo.Name = "btnGo";
			this.btnGo.TabIndex = 5;
			this.btnGo.Text = "Go";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.tabPage1,
																					  this.tabPage2});
			this.tabControl1.Location = new System.Drawing.Point(24, 48);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(760, 368);
			this.tabControl1.TabIndex = 6;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.textBoxHours,
																				   this.numUpDownEndHour,
																				   this.numUpDownStartHour,
																				   this.domainUpDown1});
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(752, 342);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			// 
			// textBoxHours
			// 
			this.textBoxHours.Location = new System.Drawing.Point(552, 48);
			this.textBoxHours.Name = "textBoxHours";
			this.textBoxHours.TabIndex = 3;
			this.textBoxHours.Text = "";
			// 
			// numUpDownEndHour
			// 
			this.numUpDownEndHour.Location = new System.Drawing.Point(440, 48);
			this.numUpDownEndHour.Maximum = new System.Decimal(new int[] {
																			 24,
																			 0,
																			 0,
																			 0});
			this.numUpDownEndHour.Name = "numUpDownEndHour";
			this.numUpDownEndHour.Size = new System.Drawing.Size(56, 20);
			this.numUpDownEndHour.TabIndex = 2;
			this.numUpDownEndHour.ValueChanged += new System.EventHandler(this.numUpDownEndHour_ValueChanged);
			// 
			// numUpDownStartHour
			// 
			this.numUpDownStartHour.Location = new System.Drawing.Point(344, 48);
			this.numUpDownStartHour.Maximum = new System.Decimal(new int[] {
																			   24,
																			   0,
																			   0,
																			   0});
			this.numUpDownStartHour.Name = "numUpDownStartHour";
			this.numUpDownStartHour.Size = new System.Drawing.Size(56, 20);
			this.numUpDownStartHour.TabIndex = 1;
			this.numUpDownStartHour.ValueChanged += new System.EventHandler(this.numUpDownStartHour_ValueChanged);
			// 
			// domainUpDown1
			// 
			this.domainUpDown1.Items.Add("Monday");
			this.domainUpDown1.Items.Add("Tuesday");
			this.domainUpDown1.Items.Add("Wednesday");
			this.domainUpDown1.Items.Add("Thursday");
			this.domainUpDown1.Items.Add("Friday");
			this.domainUpDown1.Items.Add("Saturday");
			this.domainUpDown1.Items.Add("Sunday");
			this.domainUpDown1.Location = new System.Drawing.Point(152, 48);
			this.domainUpDown1.Name = "domainUpDown1";
			this.domainUpDown1.TabIndex = 0;
			this.domainUpDown1.Wrap = true;
			this.domainUpDown1.SelectedItemChanged += new System.EventHandler(this.domainUpDown1_SelectedItemChanged);
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(752, 342);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			// 
			// FormDemo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 590);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tabControl1,
																		  this.btnGo,
																		  this.dataGrid1,
																		  this.cmBoxHot,
																		  this.lblHot,
																		  this.lblProd,
																		  this.cmBoxProduct});
			this.Name = "FormDemo";
			this.Text = "Demo";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numUpDownEndHour)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numUpDownStartHour)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void numUpDownStartHour_ValueChanged(object sender, System.EventArgs e)
		{
			numUpDownStartHour.Value = numUpDownStartHour.Value % 24;
			this.textBoxHours.Text = (this.TimeSpan((int)numUpDownStartHour.Value, (int)numUpDownEndHour.Value, 24)).ToString();
		}

		public int TimeSpan(int intStart, int intEnd, int intBase)
	    { 
			if (intStart <= intEnd)
				return   (intEnd - intStart);
			
			int intTimeSpan = 0;

			while (intStart != intEnd)
			{	   
				 intTimeSpan ++;
				 if ( ++intStart == intBase)
					 intStart = 0;
			}
			return	intTimeSpan;
	    }
		public decimal MinuteToHour(int intMinutes)
		{
		    return (decimal) intMinutes / 60;	
		}


		private void domainUpDown1_SelectedItemChanged(object sender, System.EventArgs e)
		{
		
		}

		private void numUpDownEndHour_ValueChanged(object sender, System.EventArgs e)
		{
			numUpDownEndHour.Value=(numUpDownEndHour.Value >24)? (numUpDownEndHour.Value % 24):numUpDownEndHour.Value;
			this.textBoxHours.Text = (this.TimeSpan((int)numUpDownStartHour.Value, (int)numUpDownEndHour.Value, 24)).ToString();
		}

	}
}
