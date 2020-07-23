using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Nujit.NujitERP.WinForms.GridScheduling.Tooling{

public 
class JobInquiry : System.Windows.Forms.Form{

private System.Windows.Forms.GroupBox groupBox3;
/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;

private DataTable dataTable = new DataTable();
	private System.Windows.Forms.DataGrid grid;
	private System.Windows.Forms.Button closeButton;
private DataView dataView;

public 
JobInquiry(){
	InitializeComponent();

	// TODO: Add any constructor code after InitializeComponent call
	initializeItemsGrid();

}

protected override void Dispose(bool disposing){
	if (disposing){
		if(components != null){
			components.Dispose();
		}
	}
	base.Dispose(disposing);
}

#region Windows Form Designer generated code

private void InitializeComponent(){
	this.groupBox3 = new System.Windows.Forms.GroupBox();
	this.grid = new System.Windows.Forms.DataGrid();
	this.closeButton = new System.Windows.Forms.Button();
	this.groupBox3.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
	this.SuspendLayout();
	// 
	// groupBox3
	// 
	this.groupBox3.Controls.Add(this.closeButton);
	this.groupBox3.Controls.Add(this.grid);
	this.groupBox3.Location = new System.Drawing.Point(8, 16);
	this.groupBox3.Name = "groupBox3";
	this.groupBox3.Size = new System.Drawing.Size(912, 432);
	this.groupBox3.TabIndex = 22;
	this.groupBox3.TabStop = false;
	// 
	// grid
	// 
	this.grid.DataMember = "";
	this.grid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
	this.grid.Location = new System.Drawing.Point(8, 16);
	this.grid.Name = "grid";
	this.grid.Size = new System.Drawing.Size(896, 376);
	this.grid.TabIndex = 0;
	// 
	// closeButton
	// 
	this.closeButton.Location = new System.Drawing.Point(816, 400);
	this.closeButton.Name = "closeButton";
	this.closeButton.TabIndex = 2;
	this.closeButton.Text = "Close";
	this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
	// 
	// ToolSchedule
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(928, 462);
	this.Controls.Add(this.groupBox3);
	this.Name = "ToolSchedule";
	this.Text = "ToolScheduleSeq";
	this.groupBox3.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
	this.ResumeLayout(false);

}
#endregion

private
void initializeItemsGrid(){
    dataTable = new DataTable();
//    DataRow dataRow;

	grid.CaptionText = "Tool Components";

	dataTable.Columns.Add(new DataColumn("Customer Order", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Item", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Order Date", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Production Order Date", typeof(decimal)));
	dataTable.Columns.Add(new DataColumn("Production Start Date", typeof(decimal)));
	dataTable.Columns.Add(new DataColumn("Final Assembly Date", typeof(decimal)));
	dataTable.Columns.Add(new DataColumn("Testing Date", typeof(decimal)));
	dataTable.Columns.Add(new DataColumn("First Completion Date", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Days Ahead/Behind Schedule", typeof(string)));		

//	string[][] vec = schedule.getSchPrMasStr();
//	for(int x = 0; x < vec.Length; x++){
//		dataRow = dataTable.NewRow();
// 		dataRow[0] = vec[x][23]; // machine
//		if (core.isFamilyPart(vec[x][2])) // family / part
//			dataRow[1] = "Family";
//		else
//			dataRow[1] = "Part";
//
//		dataRow[2] = vec[x][2]; // prod id
// 		dataRow[3] = vec[x][4]; // seq
//		dataRow[4] = decimal.Parse(vec[x][6]); // qty
// 		dataRow[5] = decimal.Parse(vec[x][24]); // pos
// 		dataRow[6] = decimal.Parse(vec[x][15]); // prod hours
// 		dataRow[7] = vec[x][13]; // start date
// 		dataRow[8] = vec[x][14]; // end date
//		dataTable.Rows.Add(dataRow);
//	}

	dataView = new DataView(dataTable);
	dataView.AllowEdit = false;
	dataView.AllowDelete = false;
	dataView.AllowNew = false;
	
	grid.DataSource = dataView;
	grid.PreferredColumnWidth = 150;
	grid.PreferredRowHeight = 22;
	grid.RowHeadersVisible = false;

	//Create a DataGridTableStyle object	
	DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();
	//Set its properties
	dgdtblStyle.MappingName			= dataTable.TableName;//its table name of dataset
	grid.TableStyles.Clear(); 
	grid.TableStyles.Add(dgdtblStyle);
	dgdtblStyle.RowHeadersVisible	= true;
	dgdtblStyle.AllowSorting		= true;
	dgdtblStyle.PreferredRowHeight	= 22;
	GridColumnStylesCollection	colStyle;
	colStyle				= grid.TableStyles[0].GridColumnStyles;		
	colStyle[0].Width      	= 90;
	colStyle[1].Width		= 90;
	colStyle[2].Width		= 90;
	colStyle[3].Width		= 90;
	colStyle[4].Width		= 90;
	colStyle[5].Width      	= 90;
	colStyle[6].Width		= 90;
	colStyle[7].Width		= 90;
	colStyle[8].Width		= 90;
	grid.Refresh();
}

private 
void okButton_Click(object sender, System.EventArgs e){
	Close();
}

private 
void closeButton_Click(object sender, System.EventArgs e){
	Close();
}



}

}
