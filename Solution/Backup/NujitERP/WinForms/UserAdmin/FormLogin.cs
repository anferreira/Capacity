/*********************************************************************** 
File Name:               FormLogin.cs
Created By:              Eric zhong
Created Date:            30/04/2004
***********************************************************************/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms{
	
public 
class FormLogin : System.Windows.Forms.Form{

private System.Windows.Forms.Label lblUserName;
private System.Windows.Forms.Label lblPassword;
private System.Windows.Forms.TextBox txtUserName;
private System.Windows.Forms.TextBox txtPassword;
private System.Windows.Forms.Button btnOK;
private System.Windows.Forms.Button btnExit; 
private System.ComponentModel.Container components = null;

private bool blnLegalUser = false ;
//private DataSet objUserDataSet = null;
//private Nujit.NujitERP.ClassLib.User.User objUserOperator  ;
//private Nujit.NujitERP.ClassLib.User.User objNuAdmin;
//private Nujit.NujitERP.ClassLib.User.User objThisUser;

//private ClassLib.ClassLib.Core.User userLogged = null;
private User user = null;

private System.Windows.Forms.ErrorProvider errorProviderLogin;
private ReflectionIT.Common.Windows.Forms.WizardHeader wizardHeaderLogin;
private System.Windows.Forms.PictureBox pictureBox1;
private System.Windows.Forms.PictureBox pictureBox2;

int intLoginCounter = 0;


public 
bool LegalUser{
	get{ return blnLegalUser;}
	set{  this.blnLegalUser = value;}
}

public 
FormLogin(){
	InitializeComponent();
}

protected override 
void Dispose(bool disposing){
	if (disposing){
		if (components != null){
			components.Dispose();
		}
	}
	base.Dispose(disposing);
}
	
private 
void InitializeComponent(){
	System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormLogin));
	this.lblUserName = new System.Windows.Forms.Label();
	this.lblPassword = new System.Windows.Forms.Label();
	this.txtUserName = new System.Windows.Forms.TextBox();
	this.txtPassword = new System.Windows.Forms.TextBox();
	this.btnOK = new System.Windows.Forms.Button();
	this.btnExit = new System.Windows.Forms.Button();
	this.errorProviderLogin = new System.Windows.Forms.ErrorProvider();
	this.wizardHeaderLogin = new ReflectionIT.Common.Windows.Forms.WizardHeader();
	this.pictureBox1 = new System.Windows.Forms.PictureBox();
	this.pictureBox2 = new System.Windows.Forms.PictureBox();
	this.SuspendLayout();
	// 
	// lblUserName
	// 
	this.lblUserName.Location = new System.Drawing.Point(80, 80);
	this.lblUserName.Name = "lblUserName";
	this.lblUserName.Size = new System.Drawing.Size(64, 20);
	this.lblUserName.TabIndex = 0;
	this.lblUserName.Text = "User Name";
	this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
	// 
	// lblPassword
	// 
	this.lblPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
	this.lblPassword.Location = new System.Drawing.Point(80, 112);
	this.lblPassword.Name = "lblPassword";
	this.lblPassword.Size = new System.Drawing.Size(64, 20);
	this.lblPassword.TabIndex = 0;
	this.lblPassword.Text = "Password";
	this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
	// 
	// txtUserName
	// 
	this.txtUserName.Location = new System.Drawing.Point(152, 80);
	this.txtUserName.MaxLength = 10;
	this.txtUserName.Name = "txtUserName";
	this.txtUserName.Size = new System.Drawing.Size(168, 20);
	this.txtUserName.TabIndex = 1;
	this.txtUserName.Text = "";
	this.txtUserName.GotFocus += new EventHandler(txtUserName_GotFocus);
	// 
	// txtPassword
	// 
	this.txtPassword.AutoSize = false;
	this.txtPassword.Font = new System.Drawing.Font("Webdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(2)));
	this.txtPassword.Location = new System.Drawing.Point(152, 112);
	this.txtPassword.MaxLength = 10;
	this.txtPassword.Name = "txtPassword";
	this.txtPassword.PasswordChar = '=';
	this.txtPassword.Size = new System.Drawing.Size(168, 20);
	this.txtPassword.TabIndex = 2;
	this.txtPassword.Text = "";
	this.txtPassword.GotFocus += new EventHandler(txtPassword_GotFocus);
	// 
	// btnOK
	// 
	this.btnOK.Location = new System.Drawing.Point(160, 152);
	this.btnOK.Name = "btnOK";
	this.btnOK.Size = new System.Drawing.Size(72, 24);
	this.btnOK.TabIndex = 3;
	this.btnOK.Text = "Login";
	this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
	// 
	// btnExit
	// 
	this.btnExit.Location = new System.Drawing.Point(248, 152);
	this.btnExit.Name = "btnExit";
	this.btnExit.Size = new System.Drawing.Size(72, 24);
	this.btnExit.TabIndex = 4;
	this.btnExit.Text = "Exit";
	this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
	// 
	// errorProviderLogin
	// 
	this.errorProviderLogin.DataMember = null;
	// 
	// wizardHeaderLogin
	// 
	this.wizardHeaderLogin.BackColor = System.Drawing.Color.White;
	this.wizardHeaderLogin.Description = "Enter user name and password";
	this.wizardHeaderLogin.Dock = System.Windows.Forms.DockStyle.Top;
	this.wizardHeaderLogin.Image = null;
	this.wizardHeaderLogin.Name = "wizardHeaderLogin";
	this.wizardHeaderLogin.Size = new System.Drawing.Size(442, 58);
	this.wizardHeaderLogin.TabIndex = 5;
	this.wizardHeaderLogin.Text = "Login";
	this.wizardHeaderLogin.Click += new System.EventHandler(this.wizardHeaderLogin_Click);
	// 
	// pictureBox1
	// 
	this.pictureBox1.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox1.Image")));
	this.pictureBox1.Name = "pictureBox1";
	this.pictureBox1.Size = new System.Drawing.Size(442, 56);
	this.pictureBox1.TabIndex = 6;
	this.pictureBox1.TabStop = false;
	// 
	// pictureBox2
	// 
	this.pictureBox2.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox2.Image")));
	this.pictureBox2.Location = new System.Drawing.Point(0, 58);
	this.pictureBox2.Name = "pictureBox2";
	this.pictureBox2.Size = new System.Drawing.Size(33, 132);
	this.pictureBox2.TabIndex = 7;
	this.pictureBox2.TabStop = false;
	// 
	// FormLogin
	// 
	this.AcceptButton = this.btnOK;
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(223)), ((System.Byte)(227)));
	this.ClientSize = new System.Drawing.Size(442, 192);
	this.ControlBox = false;
	this.Controls.AddRange(new System.Windows.Forms.Control[] {
																	this.pictureBox2,
																	this.pictureBox1,
																	this.wizardHeaderLogin,
																	this.btnExit,
																	this.btnOK,
																	this.txtPassword,
																	this.txtUserName,
																	this.lblPassword,
																	this.lblUserName});
	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	this.MaximizeBox = false;
	this.Name = "FormLogin";
	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	this.Text = "Welcome";
	this.Load += new System.EventHandler(this.FormLogin_Load);
	this.ResumeLayout(false);
}

private 
bool ValidateName(){
	bool blnResult = true;
	if (txtUserName.Text == ""){
		this.errorProviderLogin.SetError(txtUserName,"Please enter your login name");
		blnResult= false;
	}else{
		this.errorProviderLogin.SetError(txtUserName,"");
		blnResult= true;
	}
	return 	blnResult;
}

private 
bool ValidatePassword(){
	bool blnResult = true;
	if (txtPassword.Text == ""){
		this.errorProviderLogin.SetError(txtPassword,"Please enter your password");
		blnResult= false;
	}else{
		this.errorProviderLogin.SetError(txtPassword,"");
		blnResult= true;
	}
	return 	blnResult;
}

private 
bool ValidateData(){
	bool blnValidateResult = true;

	blnValidateResult = ValidateName() && blnValidateResult ;
	blnValidateResult = ValidatePassword() && blnValidateResult ;
	return	blnValidateResult;
}

private 
void ClearTextFields(){
	txtUserName.Text = "";
	txtPassword.Text = "";
	txtUserName.Focus();
}

private 
void FormLogin_Load(object sender, System.EventArgs e){
	txtUserName.Focus();
}

private
void txtUserName_GotFocus (object sender, System.EventArgs e){
	txtUserName.SelectAll();
}

private 
void txtPassword_GotFocus(object sender, EventArgs e){
	txtPassword.SelectAll();
}

private 
void btnOK_Click(object sender, System.EventArgs e){
	if (!ValidateData()){return;}

	string strLoginName = txtUserName.Text.Trim().ToUpper();
	string strPassword  = txtPassword.Text.Trim();

	CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
    this.user = coreFactory.readUserByName(strLoginName);
	if (strPassword.Equals(user.getPassword()))
	    this.LegalUser = true;

	if (this.LegalUser == true){
		this.DialogResult= DialogResult.Yes;
		this.Close();
	}else{
		if (intLoginCounter<3){
			ClearTextFields();
			intLoginCounter++;
			return;
		}else{
			this.DialogResult = DialogResult.No;	
			MessageBox.Show(" Sorry! The user name or password isn't correct.\n You can not use this system. Click OK to exit!\n \n");
		}
	}
}

private 
void btnExit_Click(object sender, System.EventArgs e){
	this.DialogResult =DialogResult.No;	
	this.Dispose();
}

private 
void wizardHeaderLogin_Click(object sender, System.EventArgs e){
}

public
User getLoggedUser(){
	return this.user;
}

} // class

} // namespace
