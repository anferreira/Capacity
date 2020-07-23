using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Util;
using System.Data;
using Nujit.NujitERP.WinForms.Reports.ProductsReport;
using Nujit.NujitERP.WinForms.Reports.BomErrorsReport;


namespace Nujit.NujitERP.WinForms.Schedule.LoadUpLoad.GeneratedRecords{

/// <summary>
/// Summary description for DiscardWipbForm.
/// </summary>
public 
class DiscardBomForm : System.Windows.Forms.Form{

private System.Windows.Forms.Label lblDate;
private System.ComponentModel.Container components = null;
private System.Windows.Forms.DataGrid dGridDepts;
private DataTable table;
private System.Windows.Forms.Button reportButton;
private System.Windows.Forms.Button closeButton;
string[][] badRecords;

public 
DiscardBomForm(string[][] recordsDiscard){
	InitializeComponent();
	loadGridInformation(recordsDiscard);
	badRecords = recordsDiscard;
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
	this.dGridDepts = new System.Windows.Forms.DataGrid();
	this.lblDate = new System.Windows.Forms.Label();
	this.reportButton = new System.Windows.Forms.Button();
	this.closeButton = new System.Windows.Forms.Button();
	((System.ComponentModel.ISupportInitialize)(this.dGridDepts)).BeginInit();
	this.SuspendLayout();
	// 
	// dGridDepts
	// 
	this.dGridDepts.CaptionVisible = false;
	this.dGridDepts.DataMember = "";
	this.dGridDepts.HeaderForeColor = System.Drawing.SystemColors.ControlText;
	this.dGridDepts.Location = new System.Drawing.Point(8, 80);
	this.dGridDepts.Name = "dGridDepts";
	this.dGridDepts.ReadOnly = true;
	this.dGridDepts.Size = new System.Drawing.Size(712, 288);
	this.dGridDepts.TabIndex = 0;
	// 
	// lblDate
	// 
	this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.lblDate.Location = new System.Drawing.Point(32, 24);
	this.lblDate.Name = "lblDate";
	this.lblDate.Size = new System.Drawing.Size(224, 24);
	this.lblDate.TabIndex = 1;
	this.lblDate.Text = "Discard Records of BOM";
	// 
	// reportButton
	// 
	this.reportButton.Location = new System.Drawing.Point(528, 384);
	this.reportButton.Name = "reportButton";
	this.reportButton.TabIndex = 2;
	this.reportButton.Text = "Report";
	this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
	// 
	// closeButton
	// 
	this.closeButton.Location = new System.Drawing.Point(608, 384);
	this.closeButton.Name = "closeButton";
	this.closeButton.TabIndex = 3;
	this.closeButton.Text = "Close";
	this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
	// 
	// DiscardBomForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(728, 422);
	this.Controls.AddRange(new System.Windows.Forms.Control[] {
																  this.closeButton,
																  this.reportButton,
																  this.lblDate,
																  this.dGridDepts});
	this.MaximizeBox = false;
	this.MinimizeBox = false;
	this.Name = "DiscardBomForm";
	this.Text = "Detail of Discard Records (BOM table)";
	((System.ComponentModel.ISupportInitialize)(this.dGridDepts)).EndInit();
	this.ResumeLayout(false);

}
#endregion


private 
void loadGridInformation(string[][] records){
	table = new DataTable();
	table.Columns.Add(new DataColumn("Product",typeof(string)));
	table.Columns.Add(new DataColumn("Material",typeof(string)));
	table.Columns.Add(new DataColumn("Status",typeof(string)));
	table.Columns.Add(new DataColumn("Description",typeof(string)));
	
	dGridDepts.PreferredColumnWidth = 90;
	//Fill the grid with the discard records
	DataRow dataRow;

	for(int i = 0; i < records.Length; i++){
		dataRow = table.NewRow();

		dataRow[0] = records[i][0];
		dataRow[1] = records[i][1];
		dataRow[2] = records[i][2];
		dataRow[3] = records[i][3];
		
		table.Rows.Add(dataRow);
	}

	DataView dataView = new DataView(table);
	dataView.AllowEdit = false;
	dataView.AllowDelete = false;
	dataView.AllowNew = false;
	
	dGridDepts.DataSource = dataView;

	DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();
	dgdtblStyle.MappingName			= table.TableName;//its table name of dataset
	dGridDepts.TableStyles.Clear(); 
	dGridDepts.TableStyles.Add(dgdtblStyle);
	dgdtblStyle.RowHeadersVisible	= true;
	dgdtblStyle.AllowSorting		= true;
	dgdtblStyle.PreferredRowHeight	= 22;
	GridColumnStylesCollection	colStyle;
	colStyle				= dGridDepts.TableStyles[0].GridColumnStyles;		
	colStyle[0].Width      	= 120;
	colStyle[1].Width		= 120;
	colStyle[2].Width		= 90;
	colStyle[3].Width		= 400;
	dGridDepts.Refresh();
}

private 
void callReport(){
	DataSet dataSet = new DataSet();
	DataTable dataTable = new DataTable();

	dataTable.TableName = "bom";
	dataTable.Columns.Add(new DataColumn("Product", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Material", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Status", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Description", typeof(string)));

	for(int i = 0; i < badRecords.Length; i++){
		DataRow dataRow;
		dataRow = dataTable.NewRow();

		dataRow[0] = badRecords[i][0];
		dataRow[1] = badRecords[i][1];
		dataRow[2] = badRecords[i][2];
		dataRow[3] = badRecords[i][3];
		dataTable.Rows.Add(dataRow);
	}

	dataSet.Tables.Add(dataTable);
	
	BomReport bomReport = new BomReport(dataSet);
	bomReport.ShowDialog();
}

private 
void reportButton_Click(object sender, System.EventArgs e){
	this.callReport();
}

private 
void closeButton_Click(object sender, System.EventArgs e){
	this.Dispose();
}


}//end class

}//en namespace
