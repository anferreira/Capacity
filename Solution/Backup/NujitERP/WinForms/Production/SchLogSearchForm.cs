using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.WinForms.SearchForms;
using Nujit.NujitERP.WinForms.Reports.JobCard;

namespace Nujit.NujitERP.WinForms.Production{

public 
class SchLogSearchForm : System.Windows.Forms.Form{

private System.Windows.Forms.Panel panel1;
private System.Windows.Forms.Panel panel2;
private System.Windows.Forms.DataGrid dGridSearch;
protected System.Windows.Forms.TextBox tBoxSearch;
private System.Windows.Forms.Button btnSearch;
private System.ComponentModel.Container components = null;
private DataTable searchDataTable = new DataTable();

private CultureLocal culture = new CultureLocal(Culture.getCulture());
private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private System.Windows.Forms.Label label1;
private System.Windows.Forms.TextBox recordsTextBox;
private System.Windows.Forms.Label label2;
private System.Windows.Forms.GroupBox groupBox2;
private System.Windows.Forms.Button closeButton;
private System.Windows.Forms.Button printButton;
private System.Windows.Forms.Button deleteButton;
private System.Windows.Forms.Button updateButton;
private System.Windows.Forms.Button addButton;

public 
SchLogSearchForm(){
	InitializeComponent();

	intializeFields();
	intializeDataGrid();
	showCulture();
}

public 
SchLogSearchForm(string title){
	InitializeComponent();

	this.Text = title;
	intializeFields();
	intializeDataGrid();
	showCulture();
}

public 
SchLogSearchForm(string title,string searchPattern){
	InitializeComponent();

	this.Text = title;
	this.tBoxSearch.Text=searchPattern;
	intializeFields();
	intializeDataGrid();
	showCulture();
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
/// <summary>
/// Required method for Designer support - do not modify
/// the contents of this method with the code editor.
/// </summary>
private
void InitializeComponent(){
	System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SchLogSearchForm));
	this.panel1 = new System.Windows.Forms.Panel();
	this.label2 = new System.Windows.Forms.Label();
	this.recordsTextBox = new System.Windows.Forms.TextBox();
	this.label1 = new System.Windows.Forms.Label();
	this.btnSearch = new System.Windows.Forms.Button();
	this.tBoxSearch = new System.Windows.Forms.TextBox();
	this.panel2 = new System.Windows.Forms.Panel();
	this.dGridSearch = new System.Windows.Forms.DataGrid();
	this.groupBox2 = new System.Windows.Forms.GroupBox();
	this.closeButton = new System.Windows.Forms.Button();
	this.printButton = new System.Windows.Forms.Button();
	this.deleteButton = new System.Windows.Forms.Button();
	this.updateButton = new System.Windows.Forms.Button();
	this.addButton = new System.Windows.Forms.Button();
	this.panel1.SuspendLayout();
	this.panel2.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.dGridSearch)).BeginInit();
	this.groupBox2.SuspendLayout();
	this.SuspendLayout();
	// 
	// panel1
	// 
	this.panel1.Controls.Add(this.label2);
	this.panel1.Controls.Add(this.recordsTextBox);
	this.panel1.Controls.Add(this.label1);
	this.panel1.Controls.Add(this.btnSearch);
	this.panel1.Controls.Add(this.tBoxSearch);
	this.panel1.Location = new System.Drawing.Point(16, 16);
	this.panel1.Name = "panel1";
	this.panel1.Size = new System.Drawing.Size(704, 88);
	this.panel1.TabIndex = 0;
	// 
	// label2
	// 
	this.label2.Location = new System.Drawing.Point(160, 56);
	this.label2.Name = "label2";
	this.label2.Size = new System.Drawing.Size(56, 16);
	this.label2.TabIndex = 4;
	this.label2.Text = "records ...";
	// 
	// recordsTextBox
	// 
	this.recordsTextBox.Location = new System.Drawing.Point(96, 50);
	this.recordsTextBox.Name = "recordsTextBox";
	this.recordsTextBox.Size = new System.Drawing.Size(56, 20);
	this.recordsTextBox.TabIndex = 3;
	this.recordsTextBox.Text = "";
	// 
	// label1
	// 
	this.label1.Location = new System.Drawing.Point(16, 56);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(72, 16);
	this.label1.TabIndex = 2;
	this.label1.Text = "Get the First :";
	// 
	// btnSearch
	// 
	this.btnSearch.Location = new System.Drawing.Point(512, 14);
	this.btnSearch.Name = "btnSearch";
	this.btnSearch.Size = new System.Drawing.Size(68, 23);
	this.btnSearch.TabIndex = 1;
	this.btnSearch.Text = "Search";
	this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
	// 
	// tBoxSearch
	// 
	this.tBoxSearch.Location = new System.Drawing.Point(16, 16);
	this.tBoxSearch.Name = "tBoxSearch";
	this.tBoxSearch.Size = new System.Drawing.Size(464, 20);
	this.tBoxSearch.TabIndex = 0;
	this.tBoxSearch.Text = "";
	// 
	// panel2
	// 
	this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
	this.panel2.Controls.Add(this.dGridSearch);
	this.panel2.Location = new System.Drawing.Point(16, 120);
	this.panel2.Name = "panel2";
	this.panel2.Size = new System.Drawing.Size(704, 248);
	this.panel2.TabIndex = 1;
	// 
	// dGridSearch
	// 
	this.dGridSearch.DataMember = "";
	this.dGridSearch.HeaderForeColor = System.Drawing.SystemColors.ControlText;
	this.dGridSearch.Location = new System.Drawing.Point(8, 0);
	this.dGridSearch.Name = "dGridSearch";
	this.dGridSearch.ReadOnly = true;
	this.dGridSearch.Size = new System.Drawing.Size(688, 240);
	this.dGridSearch.TabIndex = 0;
	this.dGridSearch.DoubleClick += new System.EventHandler(this.dGridSearch_DoubleClick);
	// 
	// groupBox2
	// 
	this.groupBox2.Controls.Add(this.closeButton);
	this.groupBox2.Controls.Add(this.printButton);
	this.groupBox2.Controls.Add(this.deleteButton);
	this.groupBox2.Controls.Add(this.updateButton);
	this.groupBox2.Controls.Add(this.addButton);
	this.groupBox2.Location = new System.Drawing.Point(16, 376);
	this.groupBox2.Name = "groupBox2";
	this.groupBox2.Size = new System.Drawing.Size(704, 48);
	this.groupBox2.TabIndex = 6;
	this.groupBox2.TabStop = false;
	// 
	// closeButton
	// 
	this.closeButton.Location = new System.Drawing.Point(616, 16);
	this.closeButton.Name = "closeButton";
	this.closeButton.Size = new System.Drawing.Size(75, 24);
	this.closeButton.TabIndex = 4;
	this.closeButton.Text = "Close";
	this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
	// 
	// printButton
	// 
	this.printButton.Location = new System.Drawing.Point(272, 16);
	this.printButton.Name = "printButton";
	this.printButton.Size = new System.Drawing.Size(75, 24);
	this.printButton.TabIndex = 3;
	this.printButton.Text = "Print";
	this.printButton.Click += new System.EventHandler(this.printButton_Click);
	// 
	// deleteButton
	// 
	this.deleteButton.Location = new System.Drawing.Point(184, 16);
	this.deleteButton.Name = "deleteButton";
	this.deleteButton.Size = new System.Drawing.Size(75, 24);
	this.deleteButton.TabIndex = 2;
	this.deleteButton.Text = "Delete";
	this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
	// 
	// updateButton
	// 
	this.updateButton.Location = new System.Drawing.Point(96, 16);
	this.updateButton.Name = "updateButton";
	this.updateButton.Size = new System.Drawing.Size(75, 24);
	this.updateButton.TabIndex = 1;
	this.updateButton.Text = "Update";
	this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
	// 
	// addButton
	// 
	this.addButton.Location = new System.Drawing.Point(8, 16);
	this.addButton.Name = "addButton";
	this.addButton.Size = new System.Drawing.Size(75, 24);
	this.addButton.TabIndex = 0;
	this.addButton.Text = "Add";
	this.addButton.Click += new System.EventHandler(this.addButton_Click);
	// 
	// SchLogSearchForm
	// 
	this.AcceptButton = this.btnSearch;
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(738, 430);
	this.Controls.Add(this.groupBox2);
	this.Controls.Add(this.panel2);
	this.Controls.Add(this.panel1);
	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	this.MinimumSize = new System.Drawing.Size(746, 464);
	this.Name = "SchLogSearchForm";
	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	this.Text = "Job Cards";
	this.Load += new System.EventHandler(this.SchLogSearchForm_Load);
	this.panel1.ResumeLayout(false);
	this.panel2.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.dGridSearch)).EndInit();
	this.groupBox2.ResumeLayout(false);
	this.ResumeLayout(false);

}
#endregion

private 
void btnSearch_Click(object sender, System.EventArgs e){
	dGridSearch.DataSource=null;
	string[][] founded = search(tBoxSearch.Text);

	searchDataTable.Rows.Clear();
	for(int i = 0; i < founded.Length; i++){
		DataRow dataRow = searchDataTable.NewRow();
		dataRow.ItemArray = founded[i];
		searchDataTable.Rows.Add(dataRow);
	}		
	dGridSearch.CaptionText = founded.Length.ToString() + " row(s) found .. ";
	dGridSearch.DataSource = searchDataTable;
}

private	
void intializeDataGrid(){
	string[][] columns = getColumns();

	for(int i = 0; i < columns.Length; i++)
		searchDataTable.Columns.Add(new DataColumn(columns[i][0], typeof(string)));

	DataView dataView = new DataView(searchDataTable);
	dataView.AllowEdit = false;
	dataView.AllowDelete = false;

	dGridSearch.DataSource = dataView;
	dGridSearch.PreferredColumnWidth = 150;
	dGridSearch.RowHeadersVisible = false;

	DataGridTableStyle dgdtblStyle = new DataGridTableStyle();
	dgdtblStyle.MappingName	= searchDataTable.TableName;//its table name of dataset

	dGridSearch.TableStyles.Clear(); 
	dGridSearch.TableStyles.Add(dgdtblStyle);
	dgdtblStyle.RowHeadersVisible = true;
	dgdtblStyle.AllowSorting = true;
	dgdtblStyle.PreferredRowHeight = 22;
	GridColumnStylesCollection colStyle;
	colStyle = dGridSearch.TableStyles[0].GridColumnStyles;		

	for(int i = 0; i < columns.Length; i++){
		int w = int.Parse(columns[i][1]);
		if (w != 0)
			colStyle[i].Width = w;
		else
			colStyle[i].Width = 0;
	}
	dGridSearch.Refresh();
}

private	
void intializeFields(){
	recordsTextBox.Text = Configuration.SearchDefaultMaxRecords;

	if (Configuration.SearchUserChangeDefaultMaxRecords.Equals("true"))
		recordsTextBox.ReadOnly = false;
	else
		recordsTextBox.ReadOnly = true;
}

public 
string[] getSelected(){
	int current = dGridSearch.CurrentRowIndex;

	if (current > -1){
		int cols = searchDataTable.Columns.Count;
		string[] aux = new String[cols];
		for(int i = 0; i < cols; i++){
			if (!dGridSearch[current, i].Equals(System.DBNull.Value))
				aux[i] = (string)dGridSearch[current, i];
			else
				aux[i] = "";
		}
		return aux;
	}
	return null;
}

private 
void dGridSearch_DoubleClick(object sender, System.EventArgs e){
	updateButton_Click(this, null);
}

private 
void showCulture(){
	culture.setResource("Nujit.NujitERP.WinForms.Util.Culture.SearchForm",
						typeof(SearchForm).Assembly);

	culture.setControlsCulture(this);
}

public 
void setSchText(string schText){
    this.tBoxSearch.Text = schText;
}

private
string[][] search(string searchText){
	string[][] founded = null;

	founded = coreFactory.getSchLogByDesc(searchText, 0);
	return founded;
}

private
string[][] getColumns(){
	string[][] columns = new string[30][];

	string[] column = new string[2];
	column[0] = "Entry#";
	column[1] = "70";
	columns[0] = column;

	column = new string[2];
	column[0] = "Db";
	column[1] = "0";
	columns[1] = column;

	column = new string[2];
	column[0] = "Job Card";
	column[1] = "100";
	columns[2] = column;
	
	column = new string[2];
	column[0] = "Company";
	column[1] = "0";
	columns[3] = column;
	
	column = new string[2];
	column[0] = "Plant";
	column[1] = "0";
	columns[4] = column;
	
	column = new string[2];
	column[0] = "Department";
	column[1] = "120";
	columns[5] = column;
	
	column = new string[2];
	column[0] = "Machine";
	column[1] = "120";
	columns[6] = column;
	
	column = new string[2];
	column[0] = "Part #1";
	column[1] = "120";
	columns[7] = column;
	
	column = new string[2];
	column[0] = "Description";
	column[1] = "0";
	columns[8] = column;
	
	column = new string[2];
	column[0] = "Part2";
	column[1] = "0";
	columns[9] = column;
	
	column = new string[2];
	column[0] = "Description2";
	column[1] = "0";
	columns[10] = column;
	
	column = new string[2];
	column[0] = "Part3";
	column[1] = "0";
	columns[11] = column;
	
	column = new string[2];
	column[0] = "Description3";
	column[1] = "0";
	columns[12] = column;
	
	column = new string[2];
	column[0] = "Part4";
	column[1] = "0";
	columns[13] = column;
	
	column = new string[2];
	column[0] = "Description4";
	column[1] = "0";
	columns[14] = column;
	
	column = new string[2];
	column[0] = "Family";
	column[1] = "0";
	columns[15] = column;
	
	column = new string[2];
	column[0] = "Family Description";
	column[1] = "0";
	columns[16] = column;
	
	column = new string[2];
	column[0] = "Run Qty";
	column[1] = "120";
	columns[17] = column;
	
	column = new string[2];
	column[0] = "UOM";
	column[1] = "0";
	columns[18] = column;
	
	column = new string[2];
	column[0] = "Run Standard";
	column[1] = "0";
	columns[19] = column;	
	
	column = new string[2];
	column[0] = "Machine Hrs";
	column[1] = "0";
	columns[20] = column;
	
	column = new string[2];
	column[0] = "Main Tool";
	column[1] = "0";
	columns[21] = column;
	
	column = new string[2];
	column[0] = "Qty Per Tool";
	column[1] = "0";
	columns[22] = column;
	
	column = new string[2];
	column[0] = "Main Material";
	column[1] = "0";
	columns[23] = column;	
	
	column = new string[2];
	column[0] = "Qty Per";
	column[1] = "0";
	columns[24] = column;
	
	column = new string[2];
	column[0] = "Material Req";
	column[1] = "0";
	columns[25] = column;
	
	column = new string[2];
	column[0] = "Status";
	column[1] = "0";
	columns[26] = column;
	
	column = new string[2];
	column[0] = "Date";
	column[1] = "100";
	columns[27] = column;

	column = new string[2];
	column[0] = "Operation";
	column[1] = "0";
	columns[28] = column;
	
	column = new string[2];
	column[0] = "Next Operation";
	column[1] = "0";
	columns[29] = column;

	return columns;
}

private 
void addButton_Click(object sender, System.EventArgs e){
	SchdLogEditForm schdLogEditForm = new SchdLogEditForm();
	schdLogEditForm.ShowDialog();
	
	btnSearch_Click(this, null);
}

private 
void updateButton_Click(object sender, System.EventArgs e){
	if (dGridSearch.CurrentRowIndex == -1){
		MessageBox.Show("There is not selected record");
		return;
	}
	
	string[] selected = getSelected();
	SchLog schLog = coreFactory.readSchLog(selected[1], selected[2], selected[3], selected[4]); 
	
	SchdLogEditForm schdLogEditForm = new SchdLogEditForm(schLog);
	schdLogEditForm.ShowDialog();
}

private 
void deleteButton_Click(object sender, System.EventArgs e){
	if (dGridSearch.CurrentRowIndex == -1){
		MessageBox.Show("There is not selected record");
		return;
	}
	
	DialogResult deleteConfirm = MessageBox.Show("Remove this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
	if (deleteConfirm == DialogResult.No)
		return;

	string[] selected = getSelected();
	coreFactory.deleteSchLog(selected[1], selected[2], selected[3], selected[4]); 
	
	btnSearch_Click(this, null);	
}

private 
void printButton_Click(object sender, System.EventArgs e){
	if (dGridSearch.CurrentRowIndex == -1){
		MessageBox.Show("There is not selected record");
		return;
	}
	
	string[] selected = getSelected();
	DataSet ds = generateJobCardDataSet(selected);
	JobCardReport rpt = new JobCardReport(ds);
	rpt.ShowDialog();
	rpt.Dispose();
}

private 
void closeButton_Click(object sender, System.EventArgs e){
	this.Close();
}

private 
void SchLogSearchForm_Load(object sender, System.EventArgs e){
	btnSearch_Click(this, null);
}

private
DataSet generateJobCardDataSet(string[] selected){
	DataTable dataTable = new DataTable();
	DataRow dataRow;
	
	dataTable.TableName = "jobCard";	
	
	dataTable.Columns.Add(new DataColumn("partNumber",typeof(string)));
	dataTable.Columns.Add(new DataColumn("partName",typeof(string)));
	dataTable.Columns.Add(new DataColumn("operation",typeof(string)));
	dataTable.Columns.Add(new DataColumn("nextOperation",typeof(string)));
	dataTable.Columns.Add(new DataColumn("runQty",typeof(string)));
	dataTable.Columns.Add(new DataColumn("material",typeof(string)));
	dataTable.Columns.Add(new DataColumn("matReq",typeof(string)));
	dataTable.Columns.Add(new DataColumn("date",typeof(string)));
	dataTable.Columns.Add(new DataColumn("machine",typeof(string)));
	dataTable.Columns.Add(new DataColumn("matDescription",typeof(string)));
	
	string[] vec = coreFactory.readSchLogForReport(selected[1], selected[2], selected[3], selected[4]);
	dataRow = dataTable.NewRow();
	dataRow.ItemArray = vec;
	dataTable.Rows.Add(dataRow);	
	
	DataSet jobCardDataSet = new DataSet();
	jobCardDataSet.Tables.Add(dataTable);
	
	return jobCardDataSet;
}

} // class
} // namespace
