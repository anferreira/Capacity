using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Windows.Forms;

namespace Nujit.NujitERP.WinForms.M1
{
	public class FormChildForm : System.Windows.Forms.Form
	{
		#region Variables

		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button btnRun;
		private FormMain formMainParent;

		#endregion Variables

		#region Constructors
		
		public FormChildForm(FormMain formParent)
		{
			InitializeComponent();
		
			this.MdiParent = formParent;
			this.formMainParent = formParent;
		}

		public FormChildForm()
		{
			InitializeComponent();
		}

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


		#endregion Constructors

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnRun = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnRun
			// 
			this.btnRun.Location = new System.Drawing.Point(624, 40);
			this.btnRun.Name = "btnRun";
			this.btnRun.TabIndex = 0;
			this.btnRun.Text = "Run";
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// FormChildForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(816, 364);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnRun});
			this.Name = "FormChildForm";
			this.Text = "Child Form ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Closed += new System.EventHandler(this.OnClosed);
			this.ResumeLayout(false);

		}
		#endregion

		#region Framework functions

		private void btnRun_Click(object sender, System.EventArgs e)
		{
			if (this.Parent != null)
			{
				this.formMainParent.statusBarPanelMessage.Text = "Loading report, please wait...";
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			}
			DoSomething();
			if (this.Parent != null)
			{	
				this.formMainParent.statusBarPanelMessage.Text = this.Text + " loaded";
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			
			
		}

		private void DoSomething(){	}

		private void OnClosed(object sender, System.EventArgs e)
		{
			if (this.formMainParent != null)
			{
				this.formMainParent.RemoveTab(this.Tag);

				this.formMainParent.SetButtons();
			}	
		}


		#endregion Framework functions
	}
}

