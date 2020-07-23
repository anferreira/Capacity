using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.Orders
{
	/// <summary>
	/// Summary description for FormNote.
	/// </summary>
	public abstract class FormNote : System.Windows.Forms.Form
	{
		protected System.Windows.Forms.TextBox textBoxNote;
		protected System.Windows.Forms.Button buttonAccept;
		protected System.Windows.Forms.Button buttonCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		protected System.ComponentModel.Container components = null;
		
		protected Note		note=null;	

		public FormNote()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
								
		}

		protected void setNote()
		{
			note = createNote();
		}
		protected abstract Note createNote();	

		protected abstract void objectToScreen();		

		protected abstract void screenToObject();
		
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
			this.textBoxNote = new System.Windows.Forms.TextBox();
			this.buttonAccept = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBoxNote
			// 
			this.textBoxNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNote.Location = new System.Drawing.Point(24, 24);
			this.textBoxNote.MaxLength = 250;
			this.textBoxNote.Multiline = true;
			this.textBoxNote.Name = "textBoxNote";
			this.textBoxNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxNote.Size = new System.Drawing.Size(344, 176);
			this.textBoxNote.TabIndex = 3;
			this.textBoxNote.Text = "";
			// 
			// buttonAccept
			// 
			this.buttonAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAccept.Location = new System.Drawing.Point(136, 224);
			this.buttonAccept.Name = "buttonAccept";
			this.buttonAccept.Size = new System.Drawing.Size(112, 24);
			this.buttonAccept.TabIndex = 1;
			this.buttonAccept.Text = "Accept";
			this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(256, 224);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(112, 24);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// FormNote
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 266);
			this.Controls.Add(this.buttonAccept);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.textBoxNote);
			this.Name = "FormNote";
			this.Text = "Note";
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonAccept_Click(object sender, System.EventArgs e)
		{			
			if (StringUtil.checkLength(this.textBoxNote.Text,250,"Note",false,true))
			{				
				this.screenToObject();

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("The note will be lost." + "\n" + "Are you sure?","Warning!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
				this.Close();
		}
	}
}
