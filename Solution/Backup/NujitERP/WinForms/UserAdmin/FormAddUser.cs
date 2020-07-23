/*********************************************************************** 
File Name:               FormAddUser.cs
Created By:              Eric zhong
Created Date:            22/04/2003
***********************************************************************/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.ErpException;

namespace Nujit.NujitERP.WinForms
{
	/// <summary>
	/// Summary description for FormAddUser.
	/// </summary>
	public class FormAddUser : System.Windows.Forms.Form
	{
		#region Controls

		private System.Windows.Forms.Label lblLoginName;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.Label lblReTypePassword;
		private System.Windows.Forms.TextBox txtLoginName;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtRetypePassword;
		private System.Windows.Forms.Label lblEmail;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ErrorProvider errorProviderUser;
		private ReflectionIT.Common.Windows.Forms.WizardHeader wizardHeaderAddUser;
		private System.ComponentModel.Container components = null;
		
		#endregion
		
		#region Variables

		public static User Operator;

		#endregion


		#region Constructors

		public FormAddUser()
		{
			InitializeComponent();
			Operator  = new User();
		}

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

		#endregion Constructors

		#region Windows Form Designer generated code
	
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormAddUser));
			this.lblLoginName = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.lblReTypePassword = new System.Windows.Forms.Label();
			this.txtLoginName = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtRetypePassword = new System.Windows.Forms.TextBox();
			this.lblEmail = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.errorProviderUser = new System.Windows.Forms.ErrorProvider();
			this.wizardHeaderAddUser = new ReflectionIT.Common.Windows.Forms.WizardHeader();
			this.SuspendLayout();
			// 
			// lblLoginName
			// 
			this.lblLoginName.Location = new System.Drawing.Point(48, 80);
			this.lblLoginName.Name = "lblLoginName";
			this.lblLoginName.Size = new System.Drawing.Size(80, 20);
			this.lblLoginName.TabIndex = 0;
			this.lblLoginName.Text = "Login Name";
			this.lblLoginName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPassword
			// 
			this.lblPassword.Location = new System.Drawing.Point(48, 104);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(80, 20);
			this.lblPassword.TabIndex = 1;
			this.lblPassword.Text = "Password";
			this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblReTypePassword
			// 
			this.lblReTypePassword.Location = new System.Drawing.Point(32, 128);
			this.lblReTypePassword.Name = "lblReTypePassword";
			this.lblReTypePassword.Size = new System.Drawing.Size(96, 20);
			this.lblReTypePassword.TabIndex = 2;
			this.lblReTypePassword.Text = "Retype Password";
			this.lblReTypePassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtLoginName
			// 
			this.txtLoginName.Location = new System.Drawing.Point(144, 80);
			this.txtLoginName.MaxLength = 10;
			this.txtLoginName.Name = "txtLoginName";
			this.txtLoginName.Size = new System.Drawing.Size(270, 20);
			this.txtLoginName.TabIndex = 3;
			this.txtLoginName.Text = "";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(144, 104);
			this.txtPassword.MaxLength = 10;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(270, 20);
			this.txtPassword.TabIndex = 4;
			this.txtPassword.Text = "";
			// 
			// txtRetypePassword
			// 
			this.txtRetypePassword.Location = new System.Drawing.Point(144, 128);
			this.txtRetypePassword.MaxLength = 10;
			this.txtRetypePassword.Name = "txtRetypePassword";
			this.txtRetypePassword.PasswordChar = '*';
			this.txtRetypePassword.Size = new System.Drawing.Size(270, 20);
			this.txtRetypePassword.TabIndex = 5;
			this.txtRetypePassword.Text = "";
			// 
			// lblEmail
			// 
			this.lblEmail.Location = new System.Drawing.Point(48, 152);
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Size = new System.Drawing.Size(80, 20);
			this.lblEmail.TabIndex = 6;
			this.lblEmail.Text = "Email";
			this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(144, 152);
			this.txtEmail.MaxLength = 50;
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(270, 20);
			this.txtEmail.TabIndex = 7;
			this.txtEmail.Text = "";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(248, 192);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(72, 24);
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "Create";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(344, 192);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 24);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Exit";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// wizardHeaderAddUser
			// 
			this.wizardHeaderAddUser.BackColor = System.Drawing.Color.White;
			this.wizardHeaderAddUser.Description = "Enter your lgin name, password and email address";
			this.wizardHeaderAddUser.Dock = System.Windows.Forms.DockStyle.Top;
			this.wizardHeaderAddUser.Image = ((System.Drawing.Bitmap)(resources.GetObject("wizardHeaderAddUser.Image")));
			this.wizardHeaderAddUser.Name = "wizardHeaderAddUser";
			this.wizardHeaderAddUser.Size = new System.Drawing.Size(490, 56);
			this.wizardHeaderAddUser.TabIndex = 11;
			this.wizardHeaderAddUser.Text = "Create admin account";
			// 
			// FormAddUser
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(490, 240);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.wizardHeaderAddUser,
																		  this.btnCancel,
																		  this.btnOK,
																		  this.txtEmail,
																		  this.lblEmail,
																		  this.txtRetypePassword,
																		  this.txtPassword,
																		  this.txtLoginName,
																		  this.lblReTypePassword,
																		  this.lblPassword,
																		  this.lblLoginName});
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormAddUser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add admin user";
			this.Load += new System.EventHandler(this.FormAddUser_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region validation functions
		
		private void txtLoginName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			ValidateLoginName();
		}

		private bool ValidateLoginName()
		{
			bool blnResult = true;
			if ( txtLoginName.Text == "")
			{
				errorProviderUser.SetError(txtLoginName,"Please enter a login name you prefer");
				blnResult = false;
			}
			else
			{
				errorProviderUser.SetError(txtLoginName,"");
			}
			return blnResult;
		}

		private void txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			ValidatePassword();
		}

		private bool ValidatePassword()
		{
			bool blnResult = true;
			if ( txtPassword.Text == "")
			{
				errorProviderUser.SetError(txtPassword,"Please enter the password");
				blnResult = false;
			}
			else
			{
				errorProviderUser.SetError(txtPassword,"");
			}
			return blnResult;
		}

		private void txtRetypePassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			ValidateRetypePassword();
		}

		private bool ValidateRetypePassword()
		{
			bool blnResult = true;
			if ( txtRetypePassword.Text == "")
			{
				errorProviderUser.SetError(txtRetypePassword,"Please re enter the password");
				blnResult = false;
			}
			else if ( !txtRetypePassword.Text.Trim().Equals(txtPassword.Text.Trim()))
			{
				errorProviderUser.SetError(txtRetypePassword,"Passwords don't match, please enter it again ");

				txtRetypePassword.Text = txtPassword.Text = "";
				blnResult = false;
			}
			else
			{
				errorProviderUser.SetError(txtRetypePassword,"");
				
			}
			return blnResult;
		}

		private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			ValidateEmail();
		}

		private bool ValidateEmail()
		{
			bool blnResult = true;
			if ( txtEmail.Text == "")
			{
				errorProviderUser.SetError(txtEmail,"Please enter email address");
				blnResult = false;
			}
			else if (!( Utils.RegexCheck(txtEmail.Text,RegexType.Email)))
			{
				errorProviderUser.SetError(txtEmail,"Email address should be in ###@###.### format. \nPlease enter your emial address again");
				blnResult = false;
			}
			else
			{
				errorProviderUser.SetError(txtEmail,"");
				
			}
			return blnResult;
		}

		private bool ValidateData()
		{
			bool blnResult = true;
			blnResult =  ValidateLoginName()		 && blnResult;
			blnResult =  ValidatePassword()			 && blnResult;
			blnResult =  ValidateRetypePassword()	 && blnResult;
			blnResult =  ValidateEmail()			 && blnResult;
			return  blnResult;
		}


		#endregion validation functions

		#region Events		

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			AddUser();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{	
			this.DialogResult = DialogResult.No ;
			this.Dispose();
		}

		private void FormAddUser_Load(object sender, System.EventArgs e)
		{
			  this.BackColor =  (System.Drawing.Color.FromArgb(216,216,197));
			  this.DialogResult = DialogResult.No;
		}

		#endregion Events	
	
		#region Methods
		private void AddUser(){
			if ( !ValidateData()){
				return;
			}

			string strLoginName = txtLoginName.Text.Trim();
			string strPassword  = txtPassword.Text.Trim();
			string strEmail     = txtEmail.Text.Trim();

			//Inser a record in databse
			Operator.setLoginName(strLoginName);
			Operator.setPassword(strPassword);
			Operator.setEmail(strEmail);
			Operator.setType("ADMIN");

			try{
				CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
				coreFactory.writeUser(Operator);

				MessageBox.Show(" The User with the Username: "+strLoginName+" has been added to the Database! \n Click OK to Continue ...","Creating new User succesfull!",MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.DialogResult=DialogResult.Yes;
				this.Close();
			}catch(NujitException ne){
				MessageBox.Show("ERROR : " + ne.Message);
			}
		}



		#endregion Methods
	
		#region Backup 


		#endregion Backup 
	}
}
