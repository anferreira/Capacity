using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.WinForms.Util{


public abstract	
class SearchForm : System.Windows.Forms.Form{

private System.Windows.Forms.Panel panel1;
private System.Windows.Forms.Panel panel2;
private System.Windows.Forms.DataGrid dGridSearch;
protected System.Windows.Forms.TextBox tBoxSearch;
private System.Windows.Forms.Button btnSearch;
private System.ComponentModel.Container components = null;
private DataTable searchDataTable = new DataTable();

private CultureLocal culture = new CultureLocal(Culture.getCulture());
private System.Windows.Forms.Button btnCancel;
private System.Windows.Forms.Label label1;
private System.Windows.Forms.TextBox recordsTextBox;
private System.Windows.Forms.Label label2;
private System.Windows.Forms.Button btnOk;


public 
SearchForm(){
	InitializeComponent();

	intializeFields();
	intializeDataGrid();
	showCulture();
}

public 
SearchForm(string title){
	InitializeComponent();

	this.Text = title;
	intializeFields();
	intializeDataGrid();
	showCulture();
}

public 
SearchForm(string title,string searchPattern){
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
	System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SearchForm));
	this.panel1 = new System.Windows.Forms.Panel();
	this.label2 = new System.Windows.Forms.Label();
	this.recordsTextBox = new System.Windows.Forms.TextBox();
	this.label1 = new System.Windows.Forms.Label();
	this.btnSearch = new System.Windows.Forms.Button();
	this.tBoxSearch = new System.Windows.Forms.TextBox();
	this.panel2 = new System.Windows.Forms.Panel();
	this.dGridSearch = new System.Windows.Forms.DataGrid();
	this.btnCancel = new System.Windows.Forms.Button();
	this.btnOk = new System.Windows.Forms.Button();
	this.panel1.SuspendLayout();
	this.panel2.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.dGridSearch)).BeginInit();
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
	this.panel1.Size = new System.Drawing.Size(608, 88);
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
	this.recordsTextBox.Location = new System.Drawing.Point(96, 48);
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
	this.btnSearch.Location = new System.Drawing.Point(512, 16);
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
	this.panel2.Size = new System.Drawing.Size(720, 224);
	this.panel2.TabIndex = 1;
	// 
	// dGridSearch
	// 
	this.dGridSearch.DataMember = "";
	this.dGridSearch.HeaderForeColor = System.Drawing.SystemColors.ControlText;
	this.dGridSearch.Location = new System.Drawing.Point(8, 0);
	this.dGridSearch.Name = "dGridSearch";
	this.dGridSearch.ReadOnly = true;
	this.dGridSearch.Size = new System.Drawing.Size(704, 216);
	this.dGridSearch.TabIndex = 0;
	this.dGridSearch.DoubleClick += new System.EventHandler(this.dGridSearch_DoubleClick);
	// 
	// btnCancel
	// 
	this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
	this.btnCancel.Location = new System.Drawing.Point(648, 48);
	this.btnCancel.Name = "btnCancel";
	this.btnCancel.Size = new System.Drawing.Size(72, 23);
	this.btnCancel.TabIndex = 5;
	this.btnCancel.Text = "Cancel";
	this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
	// 
	// btnOk
	// 
	this.btnOk.Location = new System.Drawing.Point(648, 16);
	this.btnOk.Name = "btnOk";
	this.btnOk.Size = new System.Drawing.Size(72, 23);
	this.btnOk.TabIndex = 4;
	this.btnOk.Text = "OK";
	this.btnOk.Click += new System.EventHandler(this.btnOk_Click_1);
	// 
	// SearchForm
	// 
	this.AcceptButton = this.btnSearch;
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(752, 366);
	this.Controls.Add(this.btnCancel);
	this.Controls.Add(this.btnOk);
	this.Controls.Add(this.panel2);
	this.Controls.Add(this.panel1);
	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	this.MinimumSize = new System.Drawing.Size(624, 344);
	this.Name = "SearchForm";
	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	this.Text = "Search";
	this.Resize += new System.EventHandler(this.SearchForm_Resize);
	this.Load += new System.EventHandler(this.SearchForm_Load);
	this.panel1.ResumeLayout(false);
	this.panel2.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.dGridSearch)).EndInit();
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
void btnCancel_Click_1(object sender, System.EventArgs e){
	this.DialogResult = DialogResult.Cancel;
	Close();
}

private 
void btnOk_Click_1(object sender, System.EventArgs e){
	if (dGridSearch.CurrentRowIndex == -1){
		MessageBox.Show("There is not selected records");
		return;
	}

	this.DialogResult = DialogResult.OK;
	Close();
}

private 
void SearchForm_Resize(object sender, System.EventArgs e){
	panel2.Height = this.Height - 138;
	panel2.Width = this.Width - 43;
	dGridSearch.Height = panel2.Height -4;
	dGridSearch.Width = panel2.Width -3;
}

private 
void dGridSearch_DoubleClick(object sender, System.EventArgs e){
	btnOk_Click_1(this,null);
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
void SearchForm_Load(object sender, System.EventArgs e){
	btnSearch_Click(this, null);
}

// abstract methods
protected abstract string[][] search(string searchText);
protected abstract string[][] getColumns();


} // class

} // namespace
