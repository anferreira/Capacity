using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;

using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.ExcelReports;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.NujitExcel;
using System.Runtime.InteropServices;


namespace Nujit.NujitERP.WinForms.ExcelReports{

public 
class ExcelReportsQueryForm : System.Windows.Forms.Form{

private System.Windows.Forms.Button searchButton;
private System.Windows.Forms.TextBox searchTextBox;
private System.Windows.Forms.Button okButton;
private System.Windows.Forms.Button runReportButton;
private NujitCustomWinControls.NujitEditableListView nujitEditableListView1;
private System.Windows.Forms.ColumnHeader columnHeader1;
private System.Windows.Forms.ColumnHeader columnHeader2;
private System.Windows.Forms.ColumnHeader columnHeader3;
private System.Windows.Forms.ColumnHeader columnHeader4;
private System.Windows.Forms.ColumnHeader columnHeader5;
private System.ComponentModel.Container components = null;
private CoreFactory coreFactory;

public 
ExcelReportsQueryForm(){
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
	System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ExcelReportsQueryForm));
	this.searchTextBox = new System.Windows.Forms.TextBox();
	this.searchButton = new System.Windows.Forms.Button();
	this.okButton = new System.Windows.Forms.Button();
	this.runReportButton = new System.Windows.Forms.Button();
	this.nujitEditableListView1 = new NujitCustomWinControls.NujitEditableListView();
	this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
	this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
	this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
	this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
	this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
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
	this.okButton.Location = new System.Drawing.Point(110, 376);
	this.okButton.Name = "okButton";
	this.okButton.TabIndex = 2;
	this.okButton.Text = "Close";
	this.okButton.Click += new System.EventHandler(this.okButton_Click);
	// 
	// runReportButton
	// 
	this.runReportButton.Location = new System.Drawing.Point(14, 376);
	this.runReportButton.Name = "runReportButton";
	this.runReportButton.TabIndex = 4;
	this.runReportButton.Text = "Run Report";
	this.runReportButton.Click += new System.EventHandler(this.runReportButton_Click);
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
	// ExcelReportsQueryForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(778, 407);
	this.Controls.Add(this.nujitEditableListView1);
	this.Controls.Add(this.runReportButton);
	this.Controls.Add(this.okButton);
	this.Controls.Add(this.searchButton);
	this.Controls.Add(this.searchTextBox);
	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	this.Name = "ExcelReportsQueryForm";
	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	this.Text = "Reports Query Form";
	this.ResumeLayout(false);

}
#endregion

private
void runReport(){
	if (this.nujitEditableListView1.SelectedItems.Count < 1){
		MessageBox.Show("There is no selected record");
		return;
	}
	try{
		ExcelReportSetup excelReportSetup = coreFactory.readExcelReportSetup(nujitEditableListView1.SelectedItems[0].SubItems[0].Text);
		if(excelReportSetup == null)
			MessageBox.Show("There is no selected record","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
		else{
			if(!Directory.Exists(excelReportSetup.getPath()))
				MessageBox.Show("Invalid Path","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			else{
				Type excel;
				object excelObject=null; 
				object excelWorkbooks=null; 
				object excelWorkbook=null;
				object[] parameter= new object[1]; 

				try{	
					excel = Type.GetTypeFromProgID("Excel.Application"); 
					excelObject = Activator.CreateInstance(excel); 	
				}
				catch{
					MessageBox.Show("It's necessary to have installed Excel to view the Report.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}

				this.Cursor = Cursors.WaitCursor;
				coreFactory.generateExcelReport(excelReportSetup);
				
				string fileName = excelReportSetup.getPath();
				if(!fileName.Substring(fileName.Length-1,1).Equals("\\"))
					fileName+="\\";
				FileInfo fi = new FileInfo(fileName);
				fileName=fi.FullName+excelReportSetup.getFileName();
				if(!fileName.Substring(fileName.Length-4,4).Equals(".xls"))
					fileName+=".xls";
				
				try{
					parameter[0] = true; 
					excelObject.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, excelObject, parameter); 
					excelObject.GetType().InvokeMember("UserControl", BindingFlags.SetProperty, null, excelObject, parameter);
					excelWorkbooks = excelObject.GetType().InvokeMember("Workbooks", System.Reflection.BindingFlags.GetProperty,null, excelObject, null,null);
					parameter[0] = fileName;
					excelWorkbook = excelWorkbooks.GetType().InvokeMember("Open", System.Reflection.BindingFlags.InvokeMethod,null, excelWorkbooks, parameter,null);	
				}
				catch{
					MessageBox.Show("The report could not be generated","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;	
				}finally{
					Marshal.ReleaseComObject(excelObject);
					Marshal.ReleaseComObject(excelWorkbooks);
					Marshal.ReleaseComObject(excelWorkbook);
					excelObject=null;
					excelWorkbooks=null;
					excelWorkbook=null;
					GC.Collect();
				}
			}
		}
	}catch(ExcelFileException){				
		MessageBox.Show("File cannot be opened for writing. Try closing it.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
	}catch(ExcelException ee){				
		MessageBox.Show("Possible error in sql sentence"+":\n"+ee.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
	}catch(ExcelPersistenceException ee){				
		MessageBox.Show("Possible error in sql sentence"+":\n"+ee.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
	}catch(Exception ex){				
		FormException frmEx = new FormException (ex);
		frmEx.ShowDialog(this);
	}finally{
		this.Cursor = Cursors.Default;
	}
}

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
void runReportButton_Click(object sender, System.EventArgs e){
	this.runReport();
}

private 
void okButton_Click(object sender, System.EventArgs e){
	this.Close();
}

private 
void cancelButton_Click(object sender, System.EventArgs e){
	this.Close();
}


}
}