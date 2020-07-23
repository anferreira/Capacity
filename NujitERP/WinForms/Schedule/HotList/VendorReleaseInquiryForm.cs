using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Nujit.NujitERP.ClassLib.Core;
using GridScheduling.gui;

using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.ErpException;

using Nujit.NujitERP.WinForms.Reports.VendorReleaseInquiry;


namespace Nujit.NujitERP.WinForms.Schedule.HotList{

/// <summary>
/// Summary description for VendorReleaseInquiryForm.
/// </summary>
public 
class VendorReleaseInquiryForm : System.Windows.Forms.Form{

private System.Windows.Forms.TabControl tabControl1;
private System.Windows.Forms.TabPage daysTabPage;
private System.Windows.Forms.TabPage weeksTabPage;
private System.Windows.Forms.DataGrid daysDataGrid;
private System.Windows.Forms.DataGrid weeksDataGrid;
private System.Windows.Forms.Button closeButton;
/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;

private DataTable daysDataTable;
private DataTable weeksDataTable;
private DataView daysDataView;
private DataView weeksDataView;
	private System.Windows.Forms.Button dayReportButton;
	private System.Windows.Forms.Button weekReportButton;

private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();


public 
VendorReleaseInquiryForm(){
	InitializeComponent();

	//
	// TODO: Add any constructor code after InitializeComponent call
	//
	initializeWeeksDataGrid();
	initializeDaysDataGrid();
}

/// <summary>
/// Clean up any resources being used.
/// </summary>
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
/// <summary>
/// Required method for Designer support - do not modify
/// the contents of this method with the code editor.
/// </summary>
private 
void InitializeComponent(){
	this.tabControl1 = new System.Windows.Forms.TabControl();
	this.daysTabPage = new System.Windows.Forms.TabPage();
	this.daysDataGrid = new System.Windows.Forms.DataGrid();
	this.weeksTabPage = new System.Windows.Forms.TabPage();
	this.weeksDataGrid = new System.Windows.Forms.DataGrid();
	this.closeButton = new System.Windows.Forms.Button();
	this.dayReportButton = new System.Windows.Forms.Button();
	this.weekReportButton = new System.Windows.Forms.Button();
	this.tabControl1.SuspendLayout();
	this.daysTabPage.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.daysDataGrid)).BeginInit();
	this.weeksTabPage.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.weeksDataGrid)).BeginInit();
	this.SuspendLayout();
	// 
	// tabControl1
	// 
	this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
																			  this.daysTabPage,
																			  this.weeksTabPage});
	this.tabControl1.Location = new System.Drawing.Point(8, 40);
	this.tabControl1.Name = "tabControl1";
	this.tabControl1.SelectedIndex = 0;
	this.tabControl1.Size = new System.Drawing.Size(848, 376);
	this.tabControl1.TabIndex = 0;
	// 
	// daysTabPage
	// 
	this.daysTabPage.Controls.AddRange(new System.Windows.Forms.Control[] {
																			  this.dayReportButton,
																			  this.daysDataGrid});
	this.daysTabPage.Location = new System.Drawing.Point(4, 22);
	this.daysTabPage.Name = "daysTabPage";
	this.daysTabPage.Size = new System.Drawing.Size(840, 350);
	this.daysTabPage.TabIndex = 0;
	this.daysTabPage.Text = "Days";
	// 
	// daysDataGrid
	// 
	this.daysDataGrid.DataMember = "";
	this.daysDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
	this.daysDataGrid.Location = new System.Drawing.Point(8, 8);
	this.daysDataGrid.Name = "daysDataGrid";
	this.daysDataGrid.Size = new System.Drawing.Size(824, 296);
	this.daysDataGrid.TabIndex = 0;
	// 
	// weeksTabPage
	// 
	this.weeksTabPage.Controls.AddRange(new System.Windows.Forms.Control[] {
																			   this.weekReportButton,
																			   this.weeksDataGrid});
	this.weeksTabPage.Location = new System.Drawing.Point(4, 22);
	this.weeksTabPage.Name = "weeksTabPage";
	this.weeksTabPage.Size = new System.Drawing.Size(840, 350);
	this.weeksTabPage.TabIndex = 1;
	this.weeksTabPage.Text = "Weeks";
	// 
	// weeksDataGrid
	// 
	this.weeksDataGrid.DataMember = "";
	this.weeksDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
	this.weeksDataGrid.Location = new System.Drawing.Point(8, 8);
	this.weeksDataGrid.Name = "weeksDataGrid";
	this.weeksDataGrid.Size = new System.Drawing.Size(824, 296);
	this.weeksDataGrid.TabIndex = 0;
	// 
	// closeButton
	// 
	this.closeButton.Location = new System.Drawing.Point(752, 440);
	this.closeButton.Name = "closeButton";
	this.closeButton.TabIndex = 1;
	this.closeButton.Text = "Close";
	this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
	// 
	// dayReportButton
	// 
	this.dayReportButton.Location = new System.Drawing.Point(736, 320);
	this.dayReportButton.Name = "dayReportButton";
	this.dayReportButton.TabIndex = 1;
	this.dayReportButton.Text = "Report";
	this.dayReportButton.Click += new System.EventHandler(this.dayReportButton_Click);
	// 
	// weekReportButton
	// 
	this.weekReportButton.Location = new System.Drawing.Point(736, 320);
	this.weekReportButton.Name = "weekReportButton";
	this.weekReportButton.TabIndex = 1;
	this.weekReportButton.Text = "Report";
	this.weekReportButton.Click += new System.EventHandler(this.weekReportButton_Click);
	// 
	// VendorReleaseInquiryForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(864, 470);
	this.Controls.AddRange(new System.Windows.Forms.Control[] {
																  this.closeButton,
																  this.tabControl1});
	this.Name = "VendorReleaseInquiryForm";
	this.Text = "Vendor Release Inquiry";
	this.tabControl1.ResumeLayout(false);
	this.daysTabPage.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.daysDataGrid)).EndInit();
	this.weeksTabPage.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.weeksDataGrid)).EndInit();
	this.ResumeLayout(false);

}
#endregion

private 
void closeButton_Click(object sender, System.EventArgs e){
	Close();
}

private
void initializeDaysDataGrid(){
    daysDataTable = new DataTable();
    DataRow dataRow;

	daysDataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
	daysDataTable.Columns.Add(new DataColumn("Cat", typeof(string)));
	daysDataTable.Columns.Add(new DataColumn("Product", typeof(string)));
	daysDataTable.Columns.Add(new DataColumn("Seq", typeof(string)));
	daysDataTable.Columns.Add(new DataColumn("Description", typeof(string)));
	daysDataTable.Columns.Add(new DataColumn("Release#", typeof(string)));
	daysDataTable.Columns.Add(new DataColumn("Past Due", typeof(string)));
	daysDataTable.Columns.Add(new DataColumn("Day 1", typeof(string)));
	daysDataTable.Columns.Add(new DataColumn("Day 2", typeof(string)));
	daysDataTable.Columns.Add(new DataColumn("Day 3", typeof(string)));
	daysDataTable.Columns.Add(new DataColumn("Day 4", typeof(string)));
	daysDataTable.Columns.Add(new DataColumn("Day 5", typeof(string)));
	daysDataTable.Columns.Add(new DataColumn("Day 6", typeof(string)));
	daysDataTable.Columns.Add(new DataColumn("Day 7", typeof(string)));

	string[][] vec = coreFactory.getVendorReleaseInquiry(false);
 	for(int x = 0; x < vec.Length; x++){
		dataRow = daysDataTable.NewRow();
 		dataRow[0] = vec[x][0];
 		dataRow[1] = vec[x][1];
 		dataRow[2] = vec[x][2];
 		dataRow[3] = vec[x][3];
 		dataRow[4] = vec[x][4];
 		dataRow[5] = vec[x][5];
 		dataRow[6] = vec[x][6];
 		dataRow[7] = vec[x][7];
 		dataRow[8] = vec[x][8];
 		dataRow[9] = vec[x][9];
 		dataRow[10] = vec[x][10];
 		dataRow[11] = vec[x][11];
 		dataRow[12] = vec[x][12];
 		dataRow[13] = vec[x][13];
		daysDataTable.Rows.Add(dataRow);
	}

	daysDataView = new DataView(daysDataTable);
	daysDataView.AllowEdit = false;
	daysDataView.AllowDelete = false;
	daysDataView.AllowNew = false;
	
	daysDataGrid.DataSource = daysDataView;
	daysDataGrid.PreferredColumnWidth = 150;
	daysDataGrid.PreferredRowHeight = 22;
	daysDataGrid.RowHeadersVisible = false;

	//Create a DataGridTableStyle object	
	DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();
	//Set its properties
	dgdtblStyle.MappingName	= daysDataTable.TableName;//its table name of dataset
	daysDataGrid.TableStyles.Clear(); 
	daysDataGrid.TableStyles.Add(dgdtblStyle);
	dgdtblStyle.RowHeadersVisible	= true;
	dgdtblStyle.AllowSorting		= true;
	dgdtblStyle.PreferredRowHeight	= 22;
	GridColumnStylesCollection	colStyle;
	colStyle				= daysDataGrid.TableStyles[0].GridColumnStyles;		
	colStyle[0].Width      	= 70; // supp
	colStyle[1].Width		= 40; // cat
	colStyle[2].Width		= 90; // prod
	colStyle[3].Width		= 30; // seq
	colStyle[4].Width		= 80; // desc
	colStyle[5].Width      	= 60; // release #
	colStyle[6].Width		= 60; // past due
	colStyle[7].Width		= 50; // weeks
	colStyle[8].Width		= 50;
	colStyle[9].Width		= 50;
	colStyle[10].Width      = 50;
	colStyle[11].Width		= 50;
	colStyle[12].Width		= 50;
	colStyle[13].Width		= 50;
	daysDataGrid.Refresh();
}

private
void initializeWeeksDataGrid(){
    weeksDataTable = new DataTable();
    DataRow dataRow;

	weeksDataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
	weeksDataTable.Columns.Add(new DataColumn("Cat", typeof(string)));
	weeksDataTable.Columns.Add(new DataColumn("Product", typeof(string)));
	weeksDataTable.Columns.Add(new DataColumn("Seq", typeof(string)));
	weeksDataTable.Columns.Add(new DataColumn("Description", typeof(string)));
	weeksDataTable.Columns.Add(new DataColumn("Release#", typeof(string)));
	weeksDataTable.Columns.Add(new DataColumn("Past Due", typeof(string)));
	weeksDataTable.Columns.Add(new DataColumn("Week 1", typeof(string)));
	weeksDataTable.Columns.Add(new DataColumn("Week 2", typeof(string)));
	weeksDataTable.Columns.Add(new DataColumn("Week 3", typeof(string)));
	weeksDataTable.Columns.Add(new DataColumn("Week 4", typeof(string)));
	weeksDataTable.Columns.Add(new DataColumn("Week 5", typeof(string)));
	weeksDataTable.Columns.Add(new DataColumn("Week 6", typeof(string)));
	weeksDataTable.Columns.Add(new DataColumn("Week 7", typeof(string)));

	string[][] vec = coreFactory.getVendorReleaseInquiry(true);
 	for(int x = 0; x < vec.Length; x++){
		dataRow = weeksDataTable.NewRow();
 		dataRow[0] = vec[x][0];
 		dataRow[1] = vec[x][1];
 		dataRow[2] = vec[x][2];
 		dataRow[3] = vec[x][3];
 		dataRow[4] = vec[x][4];
 		dataRow[5] = vec[x][5];
 		dataRow[6] = vec[x][6];
 		dataRow[7] = vec[x][7];
 		dataRow[8] = vec[x][8];
 		dataRow[9] = vec[x][9];
 		dataRow[10] = vec[x][10];
 		dataRow[11] = vec[x][11];
 		dataRow[12] = vec[x][12];
 		dataRow[13] = vec[x][13];
		weeksDataTable.Rows.Add(dataRow);
	}
	weeksDataView = new DataView(weeksDataTable);
	weeksDataView.AllowEdit = false;
	weeksDataView.AllowDelete = false;
	weeksDataView.AllowNew = false;
	
	weeksDataGrid.DataSource = weeksDataView;
	weeksDataGrid.PreferredColumnWidth = 150;
	weeksDataGrid.PreferredRowHeight = 22;
	weeksDataGrid.RowHeadersVisible = false;

	//Create a DataGridTableStyle object	
	DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();
	//Set its properties
	dgdtblStyle.MappingName	= weeksDataTable.TableName;//its table name of dataset
	weeksDataGrid.TableStyles.Clear(); 
	weeksDataGrid.TableStyles.Add(dgdtblStyle);
	dgdtblStyle.RowHeadersVisible	= true;
	dgdtblStyle.AllowSorting		= true;
	dgdtblStyle.PreferredRowHeight	= 22;
	GridColumnStylesCollection	colStyle;
	colStyle				= weeksDataGrid.TableStyles[0].GridColumnStyles;		
	colStyle[0].Width      	= 70; // supp
	colStyle[1].Width		= 40; // cat
	colStyle[2].Width		= 90; // prod
	colStyle[3].Width		= 30; // seq
	colStyle[4].Width		= 80; // desc
	colStyle[5].Width      	= 60; // release #
	colStyle[6].Width		= 60; // past due
	colStyle[7].Width		= 50; // weeks
	colStyle[8].Width		= 50;
	colStyle[9].Width		= 50;
	colStyle[10].Width      = 50;
	colStyle[11].Width		= 50;
	colStyle[12].Width		= 50;
	colStyle[13].Width		= 50;
	weeksDataGrid.Refresh();
}

private 
DataSet generateReportsDataSet(string[][] vec){
	this.Cursor = Cursors.WaitCursor;

	DataTable dataTable = new DataTable();
    DataRow dataRow;

	dataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Cat", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Product", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Seq", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Release", typeof(string)));
	dataTable.Columns.Add(new DataColumn("PastDue", typeof(string)));
	dataTable.Columns.Add(new DataColumn("E1", typeof(string)));
	dataTable.Columns.Add(new DataColumn("E2", typeof(string)));
	dataTable.Columns.Add(new DataColumn("E3", typeof(string)));
	dataTable.Columns.Add(new DataColumn("E4", typeof(string)));
	dataTable.Columns.Add(new DataColumn("E5", typeof(string)));
	dataTable.Columns.Add(new DataColumn("E6", typeof(string)));
	dataTable.Columns.Add(new DataColumn("E7", typeof(string)));

 	for(int x = 0; x < vec.Length; x++){
		dataRow = dataTable.NewRow();
 		dataRow[0] = vec[x][0];
 		dataRow[1] = vec[x][1];
 		dataRow[2] = vec[x][2];
 		dataRow[3] = vec[x][3];
 		dataRow[4] = vec[x][4];
 		dataRow[5] = vec[x][5];
 		dataRow[6] = vec[x][6];
 		dataRow[7] = vec[x][7];
 		dataRow[8] = vec[x][8];
 		dataRow[9] = vec[x][9];
 		dataRow[10] = vec[x][10];
 		dataRow[11] = vec[x][11];
 		dataRow[12] = vec[x][12];
 		dataRow[13] = vec[x][13];
		dataTable.Rows.Add(dataRow);
	}

	dataTable.TableName = "vri";
	DataSet reportsDataSet = new DataSet();
	reportsDataSet.Tables.Add(dataTable);
//	reportsDataSet.DataSetName = "vri";

	this.Cursor = Cursors.Default;

	return reportsDataSet;
}

private 
void dayReportButton_Click(object sender, System.EventArgs e){
	string[][] vec = coreFactory.getVendorReleaseInquiry(false);

	DataSet dataSet = generateReportsDataSet(vec);
	VRIReport report = new VRIReport(dataSet, "Day");
	report.ShowDialog();
}

private 
void weekReportButton_Click(object sender, System.EventArgs e){
	string[][] vec = coreFactory.getVendorReleaseInquiry(true);

	DataSet dataSet = generateReportsDataSet(vec);
	VRIReport report = new VRIReport(dataSet, "Week");
	report.ShowDialog();
}


} // class

} // namespace
