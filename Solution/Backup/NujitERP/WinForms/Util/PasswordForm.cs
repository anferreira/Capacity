using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Nujit.NujitERP.WinForms.Util
{
	/// <summary>
	/// Summary description for PasswordForm.
	/// </summary>
	public class PasswordForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Label labelPassword;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		string spassword="";

		public PasswordForm()
		{
			// Required for Windows Form Designer support
			InitializeComponent();

			textBoxPassword.Focus();
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
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.labelPassword = new System.Windows.Forms.Label();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(112, 40);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(120, 20);
			this.textBoxPassword.TabIndex = 0;
			this.textBoxPassword.Text = "";
			this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPassword_KeyDown);
			// 
			// labelPassword
			// 
			this.labelPassword.Location = new System.Drawing.Point(24, 40);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(88, 23);
			this.labelPassword.TabIndex = 1;
			this.labelPassword.Text = "Mail Password";
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(48, 96);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.TabIndex = 1;
			this.buttonOk.Text = "Ok";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(144, 96);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// PasswordForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(272, 126);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.labelPassword);
			this.Controls.Add(this.textBoxPassword);
			this.Name = "PasswordForm";
			this.Text = "Password";
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonOk_Click(object sender, System.EventArgs e){
			ok_pressed();
		}

		private void ok_pressed(){
			spassword  = this.textBoxPassword.Text;

			if (spassword.Length < 1){
				MessageBox.Show("Mail password, must be filled, please re enter !");
				spassword=null;
				return;
			}
			Dispose();
		}

		private void buttonCancel_Click(object sender, System.EventArgs e){
			spassword=null;
			Dispose();
		}

		public string getPassword(){
			return this.spassword;
		}

		private void textBoxPassword_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e){
			if (e.KeyValue == 13){
				ok_pressed();
			}
		}
	}
}
