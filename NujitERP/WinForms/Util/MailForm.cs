using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Web;
using System.Web.Mail;
using System.Data; 
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core;


namespace Nujit.NujitERP.WinForms.Util{


public 
class MailForm : System.Windows.Forms.Form{

private System.Windows.Forms.Button sendButton;
private System.Windows.Forms.Button cancelButton;
private System.Windows.Forms.TextBox toTextBox;
private System.Windows.Forms.Label label2;
private System.Windows.Forms.Label label1;
private System.ComponentModel.Container components = null;
private System.Windows.Forms.Label Subject;
private System.Windows.Forms.TextBox subjectTextBox;
	private System.Windows.Forms.RichTextBox messTextBox;
	private System.Windows.Forms.Label labelFrom;
	private System.Windows.Forms.TextBox fromtextBox; 
	private string  attachPath = null;
	private System.Windows.Forms.TextBox smtpServerTextBox;
	private System.Windows.Forms.Label labelSmtpServer;
	private User	user=null;

public 
MailForm(string attachPath){
	InitializeComponent();

	this.attachPath = attachPath;

	user = FormMain.Operator;

	this.fromtextBox.Text = user.getEmail();
	this.smtpServerTextBox.Text	= Configuration.SmtpServer;
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

#region Windows Form Designer generated code

private 
void InitializeComponent(){
	this.sendButton = new System.Windows.Forms.Button();
	this.cancelButton = new System.Windows.Forms.Button();
	this.toTextBox = new System.Windows.Forms.TextBox();
	this.label2 = new System.Windows.Forms.Label();
	this.label1 = new System.Windows.Forms.Label();
	this.Subject = new System.Windows.Forms.Label();
	this.subjectTextBox = new System.Windows.Forms.TextBox();
	this.messTextBox = new System.Windows.Forms.RichTextBox();
	this.labelFrom = new System.Windows.Forms.Label();
	this.fromtextBox = new System.Windows.Forms.TextBox();
	this.smtpServerTextBox = new System.Windows.Forms.TextBox();
	this.labelSmtpServer = new System.Windows.Forms.Label();
	this.SuspendLayout();
	// 
	// sendButton
	// 
	this.sendButton.Location = new System.Drawing.Point(408, 264);
	this.sendButton.Name = "sendButton";
	this.sendButton.TabIndex = 5;
	this.sendButton.Text = "Send";
	this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
	// 
	// cancelButton
	// 
	this.cancelButton.Location = new System.Drawing.Point(488, 264);
	this.cancelButton.Name = "cancelButton";
	this.cancelButton.TabIndex = 6;
	this.cancelButton.Text = "Cancel";
	this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
	// 
	// toTextBox
	// 
	this.toTextBox.Location = new System.Drawing.Point(120, 64);
	this.toTextBox.Name = "toTextBox";
	this.toTextBox.Size = new System.Drawing.Size(448, 20);
	this.toTextBox.TabIndex = 2;
	this.toTextBox.Text = "";
	// 
	// label2
	// 
	this.label2.Location = new System.Drawing.Point(32, 120);
	this.label2.Name = "label2";
	this.label2.Size = new System.Drawing.Size(72, 16);
	this.label2.TabIndex = 5;
	this.label2.Text = "Message";
	// 
	// label1
	// 
	this.label1.Location = new System.Drawing.Point(32, 64);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(72, 16);
	this.label1.TabIndex = 6;
	this.label1.Text = "To";
	// 
	// Subject
	// 
	this.Subject.Location = new System.Drawing.Point(32, 88);
	this.Subject.Name = "Subject";
	this.Subject.Size = new System.Drawing.Size(72, 16);
	this.Subject.TabIndex = 7;
	this.Subject.Text = "Subject";
	// 
	// subjectTextBox
	// 
	this.subjectTextBox.Location = new System.Drawing.Point(120, 88);
	this.subjectTextBox.Name = "subjectTextBox";
	this.subjectTextBox.Size = new System.Drawing.Size(448, 20);
	this.subjectTextBox.TabIndex = 3;
	this.subjectTextBox.Text = "";
	// 
	// messTextBox
	// 
	this.messTextBox.Location = new System.Drawing.Point(120, 112);
	this.messTextBox.Name = "messTextBox";
	this.messTextBox.Size = new System.Drawing.Size(448, 136);
	this.messTextBox.TabIndex = 4;
	this.messTextBox.Text = "";
	// 
	// labelFrom
	// 
	this.labelFrom.Location = new System.Drawing.Point(32, 40);
	this.labelFrom.Name = "labelFrom";
	this.labelFrom.Size = new System.Drawing.Size(72, 16);
	this.labelFrom.TabIndex = 10;
	this.labelFrom.Text = "From";
	// 
	// fromtextBox
	// 
	this.fromtextBox.Location = new System.Drawing.Point(120, 40);
	this.fromtextBox.Name = "fromtextBox";
	this.fromtextBox.Size = new System.Drawing.Size(448, 20);
	this.fromtextBox.TabIndex = 1;
	this.fromtextBox.Text = "";
	// 
	// smtpServerTextBox
	// 
	this.smtpServerTextBox.Location = new System.Drawing.Point(120, 16);
	this.smtpServerTextBox.Name = "smtpServerTextBox";
	this.smtpServerTextBox.Size = new System.Drawing.Size(448, 20);
	this.smtpServerTextBox.TabIndex = 0;
	this.smtpServerTextBox.Text = "";
	// 
	// labelSmtpServer
	// 
	this.labelSmtpServer.Location = new System.Drawing.Point(32, 16);
	this.labelSmtpServer.Name = "labelSmtpServer";
	this.labelSmtpServer.Size = new System.Drawing.Size(72, 16);
	this.labelSmtpServer.TabIndex = 12;
	this.labelSmtpServer.Text = "Smtp Server";
	// 
	// MailForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(592, 296);
	this.Controls.Add(this.labelSmtpServer);
	this.Controls.Add(this.smtpServerTextBox);
	this.Controls.Add(this.fromtextBox);
	this.Controls.Add(this.labelFrom);
	this.Controls.Add(this.messTextBox);
	this.Controls.Add(this.subjectTextBox);
	this.Controls.Add(this.toTextBox);
	this.Controls.Add(this.Subject);
	this.Controls.Add(this.label1);
	this.Controls.Add(this.label2);
	this.Controls.Add(this.cancelButton);
	this.Controls.Add(this.sendButton);
	this.MaximumSize = new System.Drawing.Size(600, 330);
	this.MinimumSize = new System.Drawing.Size(600, 330);
	this.Name = "MailForm";
	this.Text = "Send Mail ";
	this.ResumeLayout(false);

}
#endregion



private 
void sendButton_Click(object sender, System.EventArgs e){
	try{
		this.Cursor = Cursors.WaitCursor;

		string spassword = "";
		string smtpServer = "";
		
		//verify smtp server
		smtpServer = this.smtpServerTextBox.Text;
		if (smtpServer.Length < 0 || smtpServer.IndexOf(".") <= 0){
			MessageBox.Show("Invalid Smtp Server value, please re enter !");	
			return;
		}

		//check valid mail address
		if (!validMail(this.fromtextBox.Text,"From"))
			return;
		if (!validMail(this.toTextBox.Text,"To"))
			return;

		this.sendButton.Enabled = false;
		this.cancelButton.Enabled = false;

		//choose the password
		PasswordForm  passwordForm = new PasswordForm();
		passwordForm.ShowDialog();
		spassword = passwordForm.getPassword();//result, password
		if (spassword==null)
			return;

		MailMessage mail = new MailMessage();
		mail.From = fromtextBox.Text;
		mail.To = toTextBox.Text;
		mail.Subject = subjectTextBox.Text;
		//mail.Priority = MailPriority.Low;
		mail.BodyFormat = MailFormat.Text;
		mail.Body = messTextBox.Text;

		if (attachPath != null){
			MailAttachment myAttachment = new MailAttachment(attachPath, MailEncoding.Base64);
			mail.Attachments.Add(myAttachment);
		}

		mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");	//basic authentication
		mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", fromtextBox.Text); //set your username here
		mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", spassword);	//set your password here
		mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpconnectiontimeout", 120); 

//		SmtpMail.SmtpServer = smtpServer;
		SmtpMail.SmtpServer.Insert(0, smtpServer);

		SmtpMail.Send(mail);

		this.Cursor = Cursors.Default;
		this.sendButton.Enabled = true;
		this.cancelButton.Enabled = true;

		MessageBox.Show("Message sent succesfully !!");
		
		this.Close();
	}catch(Exception k){
		this.Cursor = Cursors.Default;
		this.sendButton.Enabled = true;
		this.cancelButton.Enabled = true;

		FormException exc = new FormException(k);
		exc.ShowInTaskbar = true;
		exc.Show();
	}
}

private 
void cancelButton_Click(object sender, System.EventArgs e){
	Dispose();
}

private
bool validMail(string svalue, string stitle){

	if (svalue == null){
		MessageBox.Show(stitle + ": must be filled, please re enter !");
		return false;
	}

	if (svalue.Equals("")){
		MessageBox.Show(stitle + ": must be filled, please re enter !");
		return false;
	}

	if (svalue.IndexOf("@") <= 0){
		MessageBox.Show(stitle + "@: must be in a valid position, please re enter !");
		return false;
	}
	return true;
}


} // class

} // namespace
