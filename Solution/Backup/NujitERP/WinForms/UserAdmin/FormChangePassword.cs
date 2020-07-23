/*********************************************************************** 
File Name:               FormChangePassword.cs
Created By:              Eric zhong
Created Date:            29/04/2003
***********************************************************************/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;

using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.WinForms
{
	public class FormChangePassword : System.Windows.Forms.Form
	{
		#region Controls
		
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.ErrorProvider errorProviderUser;
		private ReflectionIT.Common.Windows.Forms.WizardHeader wizardHeaderEditUserinfo; 
		private System.Windows.Forms.Label lblUserName;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.Label lblRetypePassword;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TextBox txtRetypePassword;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnExit;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtOldPassword;

		#endregion	Controls
	
	
		public static User Operator;


		#region Properties

		#endregion

		#region Constructors

		public FormChangePassword()
		{
			InitializeComponent();
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormChangePassword));
			this.lblUserName = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.lblRetypePassword = new System.Windows.Forms.Label();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtRetypePassword = new System.Windows.Forms.TextBox();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.errorProviderUser = new System.Windows.Forms.ErrorProvider();
			this.wizardHeaderEditUserinfo = new ReflectionIT.Common.Windows.Forms.WizardHeader();
			this.label1 = new System.Windows.Forms.Label();
			this.txtOldPassword = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblUserName
			// 
			this.lblUserName.Location = new System.Drawing.Point(48, 72);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new System.Drawing.Size(91, 20);
			this.lblUserName.TabIndex = 0;
			this.lblUserName.Text = "User Name";
			this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPassword
			// 
			this.lblPassword.Location = new System.Drawing.Point(48, 120);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(91, 20);
			this.lblPassword.TabIndex = 1;
			this.lblPassword.Text = "Password";
			this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblRetypePassword
			// 
			this.lblRetypePassword.Location = new System.Drawing.Point(40, 144);
			this.lblRetypePassword.Name = "lblRetypePassword";
			this.lblRetypePassword.Size = new System.Drawing.Size(96, 20);
			this.lblRetypePassword.TabIndex = 2;
			this.lblRetypePassword.Text = "Retype Password";
			this.lblRetypePassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtUserName
			// 
			this.txtUserName.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.txtUserName.Location = new System.Drawing.Point(144, 72);
			this.txtUserName.MaxLength = 10;
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.ReadOnly = true;
			this.txtUserName.Size = new System.Drawing.Size(234, 20);
			this.txtUserName.TabIndex = 0;
			this.txtUserName.Text = "";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(144, 120);
			this.txtPassword.MaxLength = 10;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(234, 20);
			this.txtPassword.TabIndex = 2;
			this.txtPassword.Text = "";
			// 
			// txtRetypePassword
			// 
			this.txtRetypePassword.Location = new System.Drawing.Point(144, 144);
			this.txtRetypePassword.Name = "txtRetypePassword";
			this.txtRetypePassword.PasswordChar = '*';
			this.txtRetypePassword.Size = new System.Drawing.Size(234, 20);
			this.txtRetypePassword.TabIndex = 3;
			this.txtRetypePassword.Text = "";
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(144, 184);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(69, 24);
			this.btnUpdate.TabIndex = 4;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(228, 184);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(68, 24);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Reset";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(310, 184);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(68, 24);
			this.btnExit.TabIndex = 6;
			this.btnExit.Text = "Exit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// errorProviderUser
			// 
			this.errorProviderUser.DataMember = null;
			// 
			// wizardHeaderEditUserinfo
			// 
			this.wizardHeaderEditUserinfo.BackColor = System.Drawing.Color.White;
			this.wizardHeaderEditUserinfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.wizardHeaderEditUserinfo.Image = ((System.Drawing.Bitmap)(resources.GetObject("wizardHeaderEditUserinfo.Image")));
			this.wizardHeaderEditUserinfo.Name = "wizardHeaderEditUserinfo";
			this.wizardHeaderEditUserinfo.Size = new System.Drawing.Size(466, 48);
			this.wizardHeaderEditUserinfo.TabIndex = 12;
			this.wizardHeaderEditUserinfo.Text = "Change password";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(48, 96);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 20);
			this.label1.TabIndex = 13;
			this.label1.Text = "Old Password";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtOldPassword
			// 
			this.txtOldPassword.Location = new System.Drawing.Point(144, 96);
			this.txtOldPassword.Name = "txtOldPassword";
			this.txtOldPassword.PasswordChar = '*';
			this.txtOldPassword.Size = new System.Drawing.Size(234, 20);
			this.txtOldPassword.TabIndex = 1;
			this.txtOldPassword.Text = "";
			// 
			// FormChangePassword
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(466, 240);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtOldPassword,
																		  this.label1,
																		  this.wizardHeaderEditUserinfo,
																		  this.btnExit,
																		  this.btnCancel,
																		  this.btnUpdate,
																		  this.txtRetypePassword,
																		  this.txtPassword,
																		  this.txtUserName,
																		  this.lblRetypePassword,
																		  this.lblPassword,
																		  this.lblUserName});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormChangePassword";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Password management";
			this.Load += new System.EventHandler(this.FormChangePassword_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region Validation functions

		private void txtOldPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			ValidateOldPassword();
		}

	
		private bool ValidateOldPassword()
		{
			bool blnResult = true;
			if ( txtOldPassword.Text == "")
			{
				errorProviderUser.SetError(txtOldPassword,"Please enter the old password");
				blnResult = false;
			}
			else if (!(txtOldPassword.Text.Trim().Equals( Operator.getPassword())))
			{
				errorProviderUser.SetError(txtOldPassword,"Please enter the correct old password");
				blnResult = false;
			}
			else
			{
				errorProviderUser.SetError(txtOldPassword,"");
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
				errorProviderUser.SetError(txtRetypePassword,"Please re-enter the password");
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

	
		private bool ValidateFieldsData()
		{
			bool blnResult = true;
			blnResult =  ValidateOldPassword()		 && blnResult;
			blnResult =  ValidatePassword()			 && blnResult;
			blnResult =  ValidateRetypePassword()	 && blnResult;
			return  blnResult;
		}


		#endregion Validation functions

		#region Functions

		private void FillTextFields()
		{
			if (Operator != null &&  Operator.getLoginName() != string.Empty )
			{   
				txtUserName.Text		= Operator.getLoginName();
		
			}
		}


		private void ClearErrorStatus()
		{	
			errorProviderUser.SetError(txtOldPassword,"");
			errorProviderUser.SetError(txtPassword,"");
			errorProviderUser.SetError(txtRetypePassword,"");
		}


		private void ClearFields()
		{
			foreach (Control objControl in this.Controls)
			{
				if (objControl is TextBox)
					((TextBox)objControl).Text = "";
			
			}

			this.txtOldPassword.Focus();
		}


		#endregion Functions

		#region Events
	
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			UpdatePassword();
		}

	

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			ClearFields();			
			ClearErrorStatus();
			FillTextFields();
		}
			

		private void FormChangePassword_Load(object sender, System.EventArgs e)
		{
			//this.BackColor =  (System.Drawing.Color.FromArgb(216,216,197));
			this.ClearFields();

			FillTextFields();

			this.txtOldPassword.Focus();
		}

		#endregion Events

		#region Methods
		private void UpdatePassword()
		{
		
			if ( !ValidateFieldsData())
			{
				//MessageBox.Show("Please input valid data.","Invalid data ",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			string strPassword  = txtPassword.Text.Trim();
	
			Operator.setPassword(strPassword);

			try{
				CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
				coreFactory.updateUser(Operator);

				MessageBox.Show("Password has been updated! \nClick OK to Continue ...","Updating succesfull!",MessageBoxButtons.OK,MessageBoxIcon.Information);
				Operator.setPassword(strPassword);
				this.ClearFields();

				FillTextFields();
			}catch(NujitException ne){
				MessageBox.Show("ERROR : " + ne.Message);
			}
		
		}
	
		#endregion 
	}
}
