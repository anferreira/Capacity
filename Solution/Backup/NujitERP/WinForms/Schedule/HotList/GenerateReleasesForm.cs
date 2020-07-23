using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms.Schedule.HotList{

/// <summary>
/// Summary description for GenerateReleasesForm.
/// </summary>
public 
class GenerateReleasesForm : System.Windows.Forms.Form{

private System.Windows.Forms.Label label1;
private System.Windows.Forms.Label label2;
private System.Windows.Forms.Label label3;
private System.Windows.Forms.Label label4;
private System.Windows.Forms.GroupBox groupBox1;
private System.Windows.Forms.TextBox startSupplierTextBox;
private System.Windows.Forms.TextBox startPartTextBox;
private System.Windows.Forms.TextBox endSupplierTextBox;
private System.Windows.Forms.TextBox endPartTextBox;
private System.Windows.Forms.Button generateButton;
private System.Windows.Forms.GroupBox groupBox2;
private System.Windows.Forms.Button closeButton;
/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;

private System.Windows.Forms.DataGrid dataGrid;
private System.Windows.Forms.Button historyButton;
private System.Windows.Forms.Button sendButton;
private System.Windows.Forms.Button activeButton;

private DataTable dataTable;
private DataView dataView;
private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
	
public 
GenerateReleasesForm(){
	InitializeComponent();

	initializeWeeksDataGrid();
}

/// <summary>
/// Clean up any resources being used.
/// </summary>
protected override 
void Dispose(bool disposing){
	if(disposing){
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
	this.label1 = new System.Windows.Forms.Label();
	this.label2 = new System.Windows.Forms.Label();
	this.label3 = new System.Windows.Forms.Label();
	this.label4 = new System.Windows.Forms.Label();
	this.groupBox1 = new System.Windows.Forms.GroupBox();
	this.startSupplierTextBox = new System.Windows.Forms.TextBox();
	this.endSupplierTextBox = new System.Windows.Forms.TextBox();
	this.startPartTextBox = new System.Windows.Forms.TextBox();
	this.endPartTextBox = new System.Windows.Forms.TextBox();
	this.generateButton = new System.Windows.Forms.Button();
	this.groupBox2 = new System.Windows.Forms.GroupBox();
	this.dataGrid = new System.Windows.Forms.DataGrid();
	this.closeButton = new System.Windows.Forms.Button();
	this.historyButton = new System.Windows.Forms.Button();
	this.sendButton = new System.Windows.Forms.Button();
	this.activeButton = new System.Windows.Forms.Button();
	this.groupBox1.SuspendLayout();
	this.groupBox2.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
	this.SuspendLayout();
	// 
	// label1
	// 
	this.label1.Location = new System.Drawing.Point(104, 24);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(100, 16);
	this.label1.TabIndex = 0;
	this.label1.Text = "Starting Supplier";
	// 
	// label2
	// 
	this.label2.Location = new System.Drawing.Point(448, 24);
	this.label2.Name = "label2";
	this.label2.Size = new System.Drawing.Size(112, 16);
	this.label2.TabIndex = 1;
	this.label2.Text = "Ending Supplier";
	// 
	// label3
	// 
	this.label3.Location = new System.Drawing.Point(448, 64);
	this.label3.Name = "label3";
	this.label3.Size = new System.Drawing.Size(112, 16);
	this.label3.TabIndex = 2;
	this.label3.Text = "Ending Part Number";
	// 
	// label4
	// 
	this.label4.Location = new System.Drawing.Point(104, 64);
	this.label4.Name = "label4";
	this.label4.Size = new System.Drawing.Size(112, 16);
	this.label4.TabIndex = 3;
	this.label4.Text = "Starting Part Number";
	// 
	// groupBox1
	// 
	this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																			this.label1,
																			this.label4,
																			this.label2,
																			this.label3,
																			this.startSupplierTextBox,
																			this.endSupplierTextBox,
																			this.startPartTextBox,
																			this.endPartTextBox});
	this.groupBox1.Location = new System.Drawing.Point(16, 16);
	this.groupBox1.Name = "groupBox1";
	this.groupBox1.Size = new System.Drawing.Size(808, 104);
	this.groupBox1.TabIndex = 4;
	this.groupBox1.TabStop = false;
	// 
	// startSupplierTextBox
	// 
	this.startSupplierTextBox.Location = new System.Drawing.Point(232, 24);
	this.startSupplierTextBox.Name = "startSupplierTextBox";
	this.startSupplierTextBox.Size = new System.Drawing.Size(136, 20);
	this.startSupplierTextBox.TabIndex = 5;
	this.startSupplierTextBox.Text = "";
	// 
	// endSupplierTextBox
	// 
	this.endSupplierTextBox.Location = new System.Drawing.Point(584, 24);
	this.endSupplierTextBox.Name = "endSupplierTextBox";
	this.endSupplierTextBox.Size = new System.Drawing.Size(136, 20);
	this.endSupplierTextBox.TabIndex = 7;
	this.endSupplierTextBox.Text = "";
	// 
	// startPartTextBox
	// 
	this.startPartTextBox.Location = new System.Drawing.Point(232, 64);
	this.startPartTextBox.Name = "startPartTextBox";
	this.startPartTextBox.Size = new System.Drawing.Size(136, 20);
	this.startPartTextBox.TabIndex = 6;
	this.startPartTextBox.Text = "";
	// 
	// endPartTextBox
	// 
	this.endPartTextBox.Location = new System.Drawing.Point(584, 64);
	this.endPartTextBox.Name = "endPartTextBox";
	this.endPartTextBox.Size = new System.Drawing.Size(136, 20);
	this.endPartTextBox.TabIndex = 8;
	this.endPartTextBox.Text = "";
	// 
	// generateButton
	// 
	this.generateButton.Location = new System.Drawing.Point(24, 122);
	this.generateButton.Name = "generateButton";
	this.generateButton.TabIndex = 5;
	this.generateButton.Text = "Generate";
	this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
	// 
	// groupBox2
	// 
	this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																			this.dataGrid});
	this.groupBox2.Location = new System.Drawing.Point(16, 144);
	this.groupBox2.Name = "groupBox2";
	this.groupBox2.Size = new System.Drawing.Size(808, 192);
	this.groupBox2.TabIndex = 6;
	this.groupBox2.TabStop = false;
	// 
	// dataGrid
	// 
	this.dataGrid.DataMember = "";
	this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
	this.dataGrid.Location = new System.Drawing.Point(8, 16);
	this.dataGrid.Name = "dataGrid";
	this.dataGrid.Size = new System.Drawing.Size(792, 168);
	this.dataGrid.TabIndex = 0;
	// 
	// closeButton
	// 
	this.closeButton.Location = new System.Drawing.Point(560, 344);
	this.closeButton.Name = "closeButton";
	this.closeButton.TabIndex = 7;
	this.closeButton.Text = "Close";
	this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
	// 
	// historyButton
	// 
	this.historyButton.Location = new System.Drawing.Point(336, 344);
	this.historyButton.Name = "historyButton";
	this.historyButton.TabIndex = 8;
	this.historyButton.Text = "History";
	// 
	// sendButton
	// 
	this.sendButton.Location = new System.Drawing.Point(416, 344);
	this.sendButton.Name = "sendButton";
	this.sendButton.Size = new System.Drawing.Size(136, 23);
	this.sendButton.TabIndex = 9;
	this.sendButton.Text = "Send Releases To ERP";
	// 
	// activeButton
	// 
	this.activeButton.Location = new System.Drawing.Point(256, 344);
	this.activeButton.Name = "activeButton";
	this.activeButton.TabIndex = 10;
	this.activeButton.Text = "Active";
	// 
	// GenerateReleasesForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(832, 382);
	this.Controls.AddRange(new System.Windows.Forms.Control[] {
																  this.activeButton,
																  this.sendButton,
																  this.historyButton,
																  this.closeButton,
																  this.groupBox2,
																  this.generateButton,
																  this.groupBox1});
	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
	this.Name = "GenerateReleasesForm";
	this.Text = "Generate Purchasing Requirements";
	this.groupBox1.ResumeLayout(false);
	this.groupBox2.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
	this.ResumeLayout(false);

}
#endregion
	
private
void initializeWeeksDataGrid(){
    dataTable = new DataTable();

	dataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Release Day", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Product", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Seq", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Release#", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Created", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Sent", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Upload ERP", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Emailed", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Confirmed", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Schedule", typeof(string)));

	dataView = new DataView(dataTable);
	dataView.AllowEdit = false;
	dataView.AllowDelete = false;
	dataView.AllowNew = false;
	
	dataGrid.DataSource = dataView;
	dataGrid.PreferredColumnWidth = 150;
	dataGrid.PreferredRowHeight = 22;
	dataGrid.RowHeadersVisible = false;

	//Create a DataGridTableStyle object	
	DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();
	//Set its properties
	dgdtblStyle.MappingName	= dataTable.TableName;//its table name of dataset
	dataGrid.TableStyles.Clear(); 
	dataGrid.TableStyles.Add(dgdtblStyle);
	dgdtblStyle.RowHeadersVisible	= true;
	dgdtblStyle.AllowSorting		= true;
	dgdtblStyle.PreferredRowHeight	= 22;
	GridColumnStylesCollection	colStyle;
	colStyle				= dataGrid.TableStyles[0].GridColumnStyles;		
	colStyle[0].Width      	= 60;
	colStyle[1].Width		= 80;
	colStyle[2].Width		= 90;
	colStyle[3].Width		= 40;
	colStyle[4].Width		= 90;
	colStyle[5].Width      	= 60;
	colStyle[6].Width		= 60;
	colStyle[7].Width		= 80;
	colStyle[8].Width		= 60;
	colStyle[9].Width		= 60;
	colStyle[10].Width		= 60;
	dataGrid.Refresh();
}

private 
void closeButton_Click(object sender, System.EventArgs e){
	Close();
}

private 
void generateButton_Click(object sender, System.EventArgs e){
	coreFactory.generateReleases(startSupplierTextBox.Text, endSupplierTextBox.Text,
		startPartTextBox.Text, endPartTextBox.Text);
	
	string[][] v = coreFactory.getReleasesAsString(startSupplierTextBox.Text, 
		endSupplierTextBox.Text, startPartTextBox.Text, endPartTextBox.Text);
	for(int i = 0; i < v.Length; i++){
		DataRow dataRow = dataTable.NewRow();
 		dataRow[0] = v[i][0];
 		dataRow[1] = v[i][1];
 		dataRow[2] = v[i][2];
 		dataRow[3] = v[i][3];
 		dataRow[4] = v[i][4];
 		dataRow[5] = v[i][5];
 		dataRow[6] = v[i][6];
 		dataRow[7] = v[i][7];
 		dataRow[8] = v[i][8];
 		dataRow[9] = v[i][9];
 		dataRow[10] = v[i][10];

		dataTable.Rows.Add(dataRow);
	}
}	
	
	
} // class

} // namespace
