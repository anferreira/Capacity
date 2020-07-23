using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;

using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.WinForms;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.ExcelReports;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.NujitExcel;


namespace Nujit.NujitERP.WinForms.ExcelReports{

public 
class ExcelReportsMaintenanceForm : System.Windows.Forms.Form{

private System.Windows.Forms.Button searchButton;
private System.Windows.Forms.TextBox searchTextBox;
private System.Windows.Forms.Button okButton;
private NujitCustomWinControls.NujitEditableListView nujitEditableListView1;
private System.Windows.Forms.ColumnHeader columnHeader1;
private System.Windows.Forms.ColumnHeader columnHeader2;
private System.Windows.Forms.ColumnHeader columnHeader3;
private System.Windows.Forms.ColumnHeader columnHeader4;
private System.Windows.Forms.ColumnHeader columnHeader5;
private System.Windows.Forms.Button addbutton;
private System.Windows.Forms.Button editbutton;
private System.Windows.Forms.Button deletebutton;
private System.ComponentModel.Container components = null;
private CoreFactory coreFactory;


public 
ExcelReportsMaintenanceForm(){
	InitializeComponent();
	coreFactory = UtilCoreFactory.createCoreFactory();
	load_grid();

}

protected override 
void Dispose( bool disposing ){
	if( disposing ){
		if(components != null){
			components.Dispose();
		}
	}
	base.Dispose( disposing );
}

#region Windows Form Designer generated code

private void InitializeComponent(){
	System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ExcelReportsMaintenanceForm));
	this.searchTextBox = new System.Windows.Forms.TextBox();
	this.searchButton = new System.Windows.Forms.Button();
	this.okButton = new System.Windows.Forms.Button();
	this.nujitEditableListView1 = new NujitCustomWinControls.NujitEditableListView();
	this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
	this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
	this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
	this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
	this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
	this.addbutton = new System.Windows.Forms.Button();
	this.editbutton = new System.Windows.Forms.Button();
	this.deletebutton = new System.Windows.Forms.Button();
	this.SuspendLayout();
	// 
	// searchTextBox
	// 
	this.searchTextBox.Location = new System.Drawing.Point(14, 16);
	this.searchTextBox.Name = "searchTextBox";
	this.searchTextBox.Size = new System.Drawing.Size(396, 20);
	this.searchTextBox.TabIndex = 0;
	this.searchTextBox.Text = "";
	// 
	// searchButton
	// 
	this.searchButton.Location = new System.Drawing.Point(436, 16);
	this.searchButton.Name = "searchButton";
	this.searchButton.TabIndex = 1;
	this.searchButton.Text = "Search";
	this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
	// 
	// okButton
	// 
	this.okButton.Location = new System.Drawing.Point(302, 384);
	this.okButton.Name = "okButton";
	this.okButton.TabIndex = 2;
	this.okButton.Text = "Close";
	this.okButton.Click += new System.EventHandler(this.okButton_Click);
	// 
	// nujitEditableListView1
	// 
	this.nujitEditableListView1.AllowColumnReorder = true;
	this.nujitEditableListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.columnHeader1,
																							 this.columnHeader2,
																							 this.columnHeader3,
																							 this.columnHeader4,
																							 this.columnHeader5});
	this.nujitEditableListView1.DoubleClickActivation = false;
	this.nujitEditableListView1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.nujitEditableListView1.FullRowSelect = true;
	this.nujitEditableListView1.HideSelection = false;
	this.nujitEditableListView1.Location = new System.Drawing.Point(12, 86);
	this.nujitEditableListView1.MultiSelect = false;
	this.nujitEditableListView1.Name = "nujitEditableListView1";
	this.nujitEditableListView1.Size = new System.Drawing.Size(752, 278);
	this.nujitEditableListView1.TabIndex = 5;
	this.nujitEditableListView1.View = System.Windows.Forms.View.Details;
	// 
	// columnHeader1
	// 
	this.columnHeader1.Text = "Report Name";
	this.columnHeader1.Width = 120;
	// 
	// columnHeader2
	// 
	this.columnHeader2.Text = "Path";
	this.columnHeader2.Width = 211;
	// 
	// columnHeader3
	// 
	this.columnHeader3.Text = "File Name";
	this.columnHeader3.Width = 100;
	// 
	// columnHeader4
	// 
	this.columnHeader4.Text = "Sql Sentence";
	this.columnHeader4.Width = 313;
	// 
	// columnHeader5
	// 
	this.columnHeader5.Text = "pivottable";
	this.columnHeader5.Width = 0;
	// 
	// addbutton
	// 
	this.addbutton.Location = new System.Drawing.Point(14, 384);
	this.addbutton.Name = "addbutton";
	this.addbutton.TabIndex = 6;
	this.addbutton.Text = "Add";
	this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
	// 
	// editbutton
	// 
	this.editbutton.Location = new System.Drawing.Point(108, 384);
	this.editbutton.Name = "editbutton";
	this.editbutton.TabIndex = 7;
	this.editbutton.Text = "Edit";
	this.editbutton.Click += new System.EventHandler(this.editbutton_Click);
	// 
	// deletebutton
	// 
	this.deletebutton.Location = new System.Drawing.Point(204, 384);
	this.deletebutton.Name = "deletebutton";
	this.deletebutton.TabIndex = 8;
	this.deletebutton.Text = "Delete";
	this.deletebutton.Click += new System.EventHandler(this.deletebutton_Click);
	// 
	// ExcelReportsMaintenanceForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(778, 431);
	this.Controls.Add(this.deletebutton);
	this.Controls.Add(this.editbutton);
	this.Controls.Add(this.addbutton);
	this.Controls.Add(this.nujitEditableListView1);
	this.Controls.Add(this.okButton);
	this.Controls.Add(this.searchButton);
	this.Controls.Add(this.searchTextBox);
	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	this.Name = "ExcelReportsMaintenanceForm";
	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	this.Text = "Reports Setup Form";
	this.ResumeLayout(false);

}
#endregion


private 
void load_grid(){
	string[][] items = null;
	
	items = coreFactory.getExcelReportSetupsByDescType(this.searchTextBox.Text,"G",0);
	
	ListViewItem item=null;
	for(int i=0; i<items.Length;i++ ){
		item = this.nujitEditableListView1.Items.Add(items[i][0]); 
		item.SubItems.Add(items[i][1]); 
		item.SubItems.Add(items[i][2]); 
		item.SubItems.Add(items[i][3]); 
		item.SubItems.Add(items[i][4]);
	}
}


private 
void searchButton_Click(object sender, System.EventArgs e){
	this.nujitEditableListView1.Items.Clear();
	this.load_grid();
}

private 
void okButton_Click(object sender, System.EventArgs e){
	this.Close();
}

private 
void cancelButton_Click(object sender, System.EventArgs e){
	this.Close();
}

private 
void addbutton_Click(object sender, System.EventArgs e){
	newRecord();
}

private 
void editbutton_Click(object sender, System.EventArgs e){
	updateRecord();
}

private 
void deletebutton_Click(object sender, System.EventArgs e){
	deleteRecord();
}

private
DialogResult deleteRecord(){
	if (this.nujitEditableListView1.SelectedItems.Count > 0){
		DialogResult deleteConfirm = MessageBox.Show("Delete Record", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (deleteConfirm == DialogResult.Yes){
			try {
				CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
				coreFactory.deleteExcelReportSetup(nujitEditableListView1.SelectedItems[0].SubItems[0].Text);
				MessageBox.Show("Deleted");
				this.nujitEditableListView1.Items.Clear();
				this.load_grid();
				return DialogResult.OK;
			}catch (Exception ex){
				FormException frmEx = new FormException (ex);
				frmEx.ShowDialog(this);
			}
		}
		return DialogResult.Cancel;
	}
	else{
		MessageBox.Show("There is no selected record");
		return DialogResult.Cancel;
	}
}

private
DialogResult updateRecord(){
	DialogResult result = DialogResult.OK;
	if (this.nujitEditableListView1.SelectedItems.Count > 0){
		try {
			CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
			ExcelReportSetup excelReportSetup = coreFactory.readExcelReportSetup(nujitEditableListView1.SelectedItems[0].SubItems[0].Text);
			if(excelReportSetup == null)
				MessageBox.Show("There is no selected record","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			else{
				using (ExcelReportSetupEditForm frm = new ExcelReportSetupEditForm(excelReportSetup))
				result = frm.ShowDialog(this);
				this.nujitEditableListView1.Items.Clear();
				this.load_grid();
				return result;
			}
		}catch (Exception ex) {
			FormException frmEx = new FormException (ex);
			frmEx.ShowDialog(this);
		}
		return DialogResult.Cancel;
	
	}else{
		MessageBox.Show("There is no selected record");
		return DialogResult.Cancel;
	}
}

private
DialogResult newRecord(){
	DialogResult result = DialogResult.OK;
	using (ExcelReportSetupEditForm frm = new ExcelReportSetupEditForm("G")){
		result = frm.ShowDialog(this);
	}
	this.nujitEditableListView1.Items.Clear();
	this.load_grid();
	return result;
}


}
}