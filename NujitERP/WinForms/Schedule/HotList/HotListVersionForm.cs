using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Core;


namespace Nujit.NujitERP.WinForms.Schedule.HotList{


public 
class HotListVersionForm : System.Windows.Forms.Form{

private System.Windows.Forms.ListView versionListView;
private System.Windows.Forms.ColumnHeader columnHeader1;
private System.Windows.Forms.ColumnHeader columnHeader2;

private System.ComponentModel.Container components = null;
private System.Windows.Forms.Button cancelButton;
private System.Windows.Forms.Button okButton;
private System.Windows.Forms.ColumnHeader columnHeader3;
private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private bool multiSelect = false;


public 
HotListVersionForm(bool multiSelect){
	InitializeComponent();

	this.multiSelect = multiSelect;
	this.versionListView.MultiSelect = multiSelect;

	loadView();
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
	this.versionListView = new System.Windows.Forms.ListView();
	this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
	this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
	this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
	this.cancelButton = new System.Windows.Forms.Button();
	this.okButton = new System.Windows.Forms.Button();
	this.SuspendLayout();
	// 
	// versionListView
	// 
	this.versionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					  this.columnHeader1,
																					  this.columnHeader2,
																					  this.columnHeader3});
	this.versionListView.FullRowSelect = true;
	this.versionListView.Location = new System.Drawing.Point(8, 16);
	this.versionListView.Name = "versionListView";
	this.versionListView.Size = new System.Drawing.Size(368, 184);
	this.versionListView.TabIndex = 0;
	this.versionListView.View = System.Windows.Forms.View.Details;
	// 
	// columnHeader1
	// 
	this.columnHeader1.Text = "ID";
	// 
	// columnHeader2
	// 
	this.columnHeader2.Text = "Generation";
	this.columnHeader2.Width = 120;
	// 
	// columnHeader3
	// 
	this.columnHeader3.Text = "Explosion";
	this.columnHeader3.Width = 120;
	// 
	// cancelButton
	// 
	this.cancelButton.Location = new System.Drawing.Point(296, 208);
	this.cancelButton.Name = "cancelButton";
	this.cancelButton.TabIndex = 1;
	this.cancelButton.Text = "Cancel";
	this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
	// 
	// okButton
	// 
	this.okButton.Location = new System.Drawing.Point(216, 208);
	this.okButton.Name = "okButton";
	this.okButton.Size = new System.Drawing.Size(75, 24);
	this.okButton.TabIndex = 2;
	this.okButton.Text = "OK";
	this.okButton.Click += new System.EventHandler(this.okButton_Click);
	// 
	// HotListVersionForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(392, 246);
	this.Controls.Add(this.okButton);
	this.Controls.Add(this.cancelButton);
	this.Controls.Add(this.versionListView);
	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
	this.Name = "HotListVersionForm";
	this.Text = "HotList Version";
	this.ResumeLayout(false);

}
#endregion

private 
void loadView(){
	string[][] vec = coreFactory.getHotListLogHist();
	for(int i = 0; i < vec.Length; i++){
		ListViewItem item = this.versionListView.Items.Add(vec[i][0]);
		item.SubItems.Add(vec[i][1]);
		item.SubItems.Add(vec[i][2]);
	}
}

private 
void okButton_Click(object sender, System.EventArgs e){
	if (multiSelect){
		if (versionListView.SelectedItems.Count != 2){
			MessageBox.Show("You have to select 2 items");
			return;
		}
	}else{
		if (this.versionListView.SelectedIndices.Count == 0){
			MessageBox.Show("You have to select an item");
			return;
		}
	}

	this.DialogResult = DialogResult.OK;
	Close();
}

private 
void cancelButton_Click(object sender, System.EventArgs e){
	this.DialogResult = DialogResult.Cancel;
	Close();
}

public 
string[][] getSelected(){
	string[][] vec = new string[versionListView.SelectedItems.Count][];

	for(int i = 0; i < versionListView.SelectedItems.Count; i++){
		string[] line = new string[3];
		line[0] = versionListView.SelectedItems[i].SubItems[0].Text;
		line[1] = versionListView.SelectedItems[i].SubItems[1].Text;
		line[2] = versionListView.SelectedItems[i].SubItems[2].Text;

		vec[i] = line;
	}

	return vec;
}

}

}
