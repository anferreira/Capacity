using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Nujit.NujitERP.WinForms.Master{

public 
class FormServer : System.Windows.Forms.Form{
	private System.Windows.Forms.Button closeButton;

private System.ComponentModel.Container components = null;

public 
FormServer(){
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

#region Windows Form Designer generated code

private 
void InitializeComponent(){
	this.closeButton = new System.Windows.Forms.Button();
	this.SuspendLayout();
	// 
	// closeButton
	// 
	this.closeButton.Location = new System.Drawing.Point(280, 224);
	this.closeButton.Name = "closeButton";
	this.closeButton.TabIndex = 0;
	this.closeButton.Text = "Close";
	this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
	// 
	// ServerForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(400, 266);
	this.Controls.Add(this.closeButton);
	this.Name = "ServerForm";
	this.Text = "Nujit Server";
	this.ResumeLayout(false);

}
#endregion

private 
void closeButton_Click(object sender, System.EventArgs e){
	this.Close();
}

} // class

} // namespace
