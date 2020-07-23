using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.ErpException;

namespace GridScheduling.gui.schedule{

public 
class NewVersion : System.Windows.Forms.Form{

private System.Windows.Forms.TextBox versionTextBox;
private System.Windows.Forms.TextBox setTextBox;
private System.Windows.Forms.TextBox startTextBox;
private System.Windows.Forms.TextBox endTextBox;
private System.Windows.Forms.Button cancelButton;
private System.Windows.Forms.Button okButton;
private System.Windows.Forms.Label label1;
private System.Windows.Forms.Label label2;
private System.Windows.Forms.Label label3;
private System.Windows.Forms.Label label4;

private System.ComponentModel.Container components = null;

private string plt;

public 
NewVersion(string plt){
	this.plt = plt;

	InitializeComponent();
	initializeValues();
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
	this.versionTextBox = new System.Windows.Forms.TextBox();
	this.setTextBox = new System.Windows.Forms.TextBox();
	this.startTextBox = new System.Windows.Forms.TextBox();
	this.endTextBox = new System.Windows.Forms.TextBox();
	this.cancelButton = new System.Windows.Forms.Button();
	this.okButton = new System.Windows.Forms.Button();
	this.label1 = new System.Windows.Forms.Label();
	this.label2 = new System.Windows.Forms.Label();
	this.label3 = new System.Windows.Forms.Label();
	this.label4 = new System.Windows.Forms.Label();
	this.SuspendLayout();
	// 
	// versionTextBox
	// 
	this.versionTextBox.Location = new System.Drawing.Point(184, 40);
	this.versionTextBox.Name = "versionTextBox";
	this.versionTextBox.Size = new System.Drawing.Size(144, 20);
	this.versionTextBox.TabIndex = 0;
	this.versionTextBox.Text = "";
	// 
	// setTextBox
	// 
	this.setTextBox.Location = new System.Drawing.Point(184, 64);
	this.setTextBox.Name = "setTextBox";
	this.setTextBox.Size = new System.Drawing.Size(144, 20);
	this.setTextBox.TabIndex = 1;
	this.setTextBox.Text = "";
	// 
	// startTextBox
	// 
	this.startTextBox.Location = new System.Drawing.Point(184, 88);
	this.startTextBox.Name = "startTextBox";
	this.startTextBox.Size = new System.Drawing.Size(144, 20);
	this.startTextBox.TabIndex = 2;
	this.startTextBox.Text = "";
	// 
	// endTextBox
	// 
	this.endTextBox.Location = new System.Drawing.Point(184, 112);
	this.endTextBox.Name = "endTextBox";
	this.endTextBox.Size = new System.Drawing.Size(144, 20);
	this.endTextBox.TabIndex = 3;
	this.endTextBox.Text = "";
	// 
	// cancelButton
	// 
	this.cancelButton.Location = new System.Drawing.Point(400, 56);
	this.cancelButton.Name = "cancelButton";
	this.cancelButton.TabIndex = 4;
	this.cancelButton.Text = "Cancel";
	this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
	// 
	// okButton
	// 
	this.okButton.Location = new System.Drawing.Point(400, 24);
	this.okButton.Name = "okButton";
	this.okButton.TabIndex = 5;
	this.okButton.Text = "OK";
	this.okButton.Click += new System.EventHandler(this.okButton_Click);
	// 
	// label1
	// 
	this.label1.Location = new System.Drawing.Point(56, 48);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(100, 16);
	this.label1.TabIndex = 6;
	this.label1.Text = "Version";
	// 
	// label2
	// 
	this.label2.Location = new System.Drawing.Point(56, 72);
	this.label2.Name = "label2";
	this.label2.Size = new System.Drawing.Size(100, 16);
	this.label2.TabIndex = 7;
	this.label2.Text = "Set";
	// 
	// label3
	// 
	this.label3.Location = new System.Drawing.Point(56, 96);
	this.label3.Name = "label3";
	this.label3.Size = new System.Drawing.Size(100, 16);
	this.label3.TabIndex = 8;
	this.label3.Text = "Start";
	// 
	// label4
	// 
	this.label4.Location = new System.Drawing.Point(56, 120);
	this.label4.Name = "label4";
	this.label4.Size = new System.Drawing.Size(100, 16);
	this.label4.TabIndex = 9;
	this.label4.Text = "End";
	// 
	// NewVersion
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(504, 158);
	this.Controls.Add(this.label4);
	this.Controls.Add(this.label3);
	this.Controls.Add(this.label2);
	this.Controls.Add(this.label1);
	this.Controls.Add(this.okButton);
	this.Controls.Add(this.cancelButton);
	this.Controls.Add(this.endTextBox);
	this.Controls.Add(this.startTextBox);
	this.Controls.Add(this.setTextBox);
	this.Controls.Add(this.versionTextBox);
	this.Name = "NewVersion";
	this.Text = "NewVersion";
	this.ResumeLayout(false);

}
#endregion

private 
void initializeValues(){
	versionTextBox.Text = DateTime.Now.Ticks.ToString();
	setTextBox.Text = "";;
	startTextBox.Text = DateUtil.getDateRepresentation(DateUtil.MMDDYYYY);
	endTextBox.Text = DateUtil.getDateRepresentation(DateTime.Today.AddDays(180), DateUtil.MMDDYYYY);
}

private
bool validData(){
	if ((versionTextBox.Text == null) || (versionTextBox.Text.Equals(""))){
		MessageBox.Show("The Version must be a valid value");
		return false;
	}
				
	if ((startTextBox.Text == null) || (startTextBox.Text.Equals(""))){
		MessageBox.Show("The Start Date must be a valid value");
		return false;
	}

	if ((endTextBox.Text == null) || (endTextBox.Text.Equals(""))){
		MessageBox.Show("The End Date must be a valid value");
		return false;
	}

	if (!DateUtil.isValidDate(startTextBox.Text, DateUtil.MMDDYYYY)){
		MessageBox.Show("The Start Date must be a valid value");
		return false;
	}
	
	if (!DateUtil.isValidDate(endTextBox.Text, DateUtil.MMDDYYYY)){
		MessageBox.Show("The End Date must be a valid value");
		return false;
	}
	return true;
}

private 
void okButton_Click(object sender, System.EventArgs e){
	if (!validData())
		return;

	try{
		CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
		
		if (!coreFactory.existsCapacityVersion(versionTextBox.Text)){
			CapacityVersion version = coreFactory.createCapacityVersion();
				
				
			version.setPlt(plt);
			version.setVersion(versionTextBox.Text);
			version.setStatus("A");
			version.setSett("");
			version.setDtStart(DateUtil.parseDate(startTextBox.Text, DateUtil.MMDDYYYY));
			version.setDtEnd(DateUtil.parseDate(endTextBox.Text, DateUtil.MMDDYYYY));
			version.setDtCreat(DateUtil.parseDate(startTextBox.Text, DateUtil.MMDDYYYY));
			version.setUserCr("");
			version.setDtUpdate(DateUtil.parseDate(startTextBox.Text, DateUtil.MMDDYYYY));
			version.setUserUp("");
				
			coreFactory.writeCapacityVersion(version);

			this.DialogResult = DialogResult.OK;

			Close();
		}else{
			MessageBox.Show("The version " + versionTextBox.Text + " already exists, prease re enter");
			return;
		}
	}catch(NujitException ne){
		MessageBox.Show("Error : " + ne.Message);
	}
}

private 
void cancelButton_Click(object sender, System.EventArgs e){
	this.DialogResult = DialogResult.Cancel;
	Close();
}


} // class

} // namespace
