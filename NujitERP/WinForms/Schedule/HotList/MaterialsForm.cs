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
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.WinForms.Reports;
using Nujit.NujitERP.WinForms.Reports.MaterialsReport;
using Nujit.NujitERP.ClassLib.Reports.UtilReports;


namespace Nujit.NujitERP.WinForms.Schedule.HotList{

/// <summary>
/// Summary description for AddForm.
/// </summary>
public
class MaterialsForm : System.Windows.Forms.Form{


private System.Windows.Forms.GroupBox groupBox3;

private CoreFactory core = UtilCoreFactory.createCoreFactory();
private System.Windows.Forms.DataGrid grid;
private DataTable dataTable;
private DataView dataView;
private string[][] vecMat = null; 
private string[] partFilter;
private string[] deptFilter;
private string[] matbFilter;
private System.Windows.Forms.Button closeButton;
private System.Windows.Forms.CheckBox allocatedCheckBox;
private SortedList arrayOfMaterials = null;
private SortedList arrayOfMaterialsByMaterial = null;
private System.Windows.Forms.GroupBox groupBox1;
private System.Windows.Forms.RadioButton rbtnByMaterialsDays;
private System.Windows.Forms.RadioButton rBtnGByMaterialPart;
private System.Windows.Forms.RadioButton rBtnGbyParentPart;
private System.Windows.Forms.RadioButton rBtnBySupplierDays;
private System.Windows.Forms.RadioButton rBtnBySupplierWeeks;
private System.Windows.Forms.RadioButton rBtnByMaterialWeeks;
private System.Windows.Forms.Button btnShow;
private System.Windows.Forms.RadioButton orderByDemandRadioButton;
private System.Windows.Forms.RadioButton rBtnBySupplierDaysExcell;
private bool lessDays;

/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;


public
MaterialsForm(string[] partFilter, string[] deptFilter, string[] matbFilter, bool lessDays){
	this.partFilter = partFilter;
	this.deptFilter = deptFilter;
	this.matbFilter = matbFilter;
	this.lessDays = lessDays;

	InitializeComponent();
	modifyDataControls();
}

private 
void modifyDataControls(){
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
	this.groupBox3 = new System.Windows.Forms.GroupBox();
	this.allocatedCheckBox = new System.Windows.Forms.CheckBox();
	this.grid = new System.Windows.Forms.DataGrid();
	this.closeButton = new System.Windows.Forms.Button();
	this.groupBox1 = new System.Windows.Forms.GroupBox();
	this.rBtnBySupplierDaysExcell = new System.Windows.Forms.RadioButton();
	this.orderByDemandRadioButton = new System.Windows.Forms.RadioButton();
	this.btnShow = new System.Windows.Forms.Button();
	this.rBtnByMaterialWeeks = new System.Windows.Forms.RadioButton();
	this.rBtnBySupplierWeeks = new System.Windows.Forms.RadioButton();
	this.rBtnBySupplierDays = new System.Windows.Forms.RadioButton();
	this.rbtnByMaterialsDays = new System.Windows.Forms.RadioButton();
	this.rBtnGByMaterialPart = new System.Windows.Forms.RadioButton();
	this.rBtnGbyParentPart = new System.Windows.Forms.RadioButton();
	this.groupBox3.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
	this.groupBox1.SuspendLayout();
	this.SuspendLayout();
	// 
	// groupBox3
	// 
	this.groupBox3.Controls.Add(this.allocatedCheckBox);
	this.groupBox3.Controls.Add(this.grid);
	this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.groupBox3.Location = new System.Drawing.Point(16, 16);
	this.groupBox3.Name = "groupBox3";
	this.groupBox3.Size = new System.Drawing.Size(840, 320);
	this.groupBox3.TabIndex = 39;
	this.groupBox3.TabStop = false;
	this.groupBox3.Text = "Part Info";
	// 
	// allocatedCheckBox
	// 
	this.allocatedCheckBox.Checked = true;
	this.allocatedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
	this.allocatedCheckBox.Location = new System.Drawing.Point(672, 24);
	this.allocatedCheckBox.Name = "allocatedCheckBox";
	this.allocatedCheckBox.Size = new System.Drawing.Size(136, 24);
	this.allocatedCheckBox.TabIndex = 1;
	this.allocatedCheckBox.Text = "Show all Allocated Qty";
	this.allocatedCheckBox.Click += new System.EventHandler(this.allocatedCheckBox_Click);
	// 
	// grid
	// 
	this.grid.AllowSorting = false;
	this.grid.DataMember = "";
	this.grid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
	this.grid.Location = new System.Drawing.Point(8, 64);
	this.grid.Name = "grid";
	this.grid.ReadOnly = true;
	this.grid.Size = new System.Drawing.Size(824, 240);
	this.grid.TabIndex = 0;
	this.grid.Click += new System.EventHandler(this.grid_Click);
	// 
	// closeButton
	// 
	this.closeButton.Location = new System.Drawing.Point(752, 48);
	this.closeButton.Name = "closeButton";
	this.closeButton.TabIndex = 40;
	this.closeButton.Text = "Close";
	this.closeButton.Click += new System.EventHandler(this.closeButton_Click_1);
	// 
	// groupBox1
	// 
	this.groupBox1.Controls.Add(this.rBtnBySupplierDaysExcell);
	this.groupBox1.Controls.Add(this.orderByDemandRadioButton);
	this.groupBox1.Controls.Add(this.btnShow);
	this.groupBox1.Controls.Add(this.rBtnByMaterialWeeks);
	this.groupBox1.Controls.Add(this.rBtnBySupplierWeeks);
	this.groupBox1.Controls.Add(this.rBtnBySupplierDays);
	this.groupBox1.Controls.Add(this.rbtnByMaterialsDays);
	this.groupBox1.Controls.Add(this.rBtnGByMaterialPart);
	this.groupBox1.Controls.Add(this.rBtnGbyParentPart);
	this.groupBox1.Controls.Add(this.closeButton);
	this.groupBox1.Location = new System.Drawing.Point(16, 344);
	this.groupBox1.Name = "groupBox1";
	this.groupBox1.Size = new System.Drawing.Size(840, 80);
	this.groupBox1.TabIndex = 42;
	this.groupBox1.TabStop = false;
	this.groupBox1.Text = "Reports";
	// 
	// rBtnBySupplierDaysExcell
	// 
	this.rBtnBySupplierDaysExcell.Location = new System.Drawing.Point(424, 24);
	this.rBtnBySupplierDaysExcell.Name = "rBtnBySupplierDaysExcell";
	this.rBtnBySupplierDaysExcell.Size = new System.Drawing.Size(152, 16);
	this.rBtnBySupplierDaysExcell.TabIndex = 51;
	this.rBtnBySupplierDaysExcell.Text = "By Supplier (Days) Excell";
	// 
	// orderByDemandRadioButton
	// 
	this.orderByDemandRadioButton.Location = new System.Drawing.Point(592, 24);
	this.orderByDemandRadioButton.Name = "orderByDemandRadioButton";
	this.orderByDemandRadioButton.Size = new System.Drawing.Size(120, 16);
	this.orderByDemandRadioButton.TabIndex = 50;
	this.orderByDemandRadioButton.Text = "By Demand (Days)";
	// 
	// btnShow
	// 
	this.btnShow.Location = new System.Drawing.Point(752, 16);
	this.btnShow.Name = "btnShow";
	this.btnShow.TabIndex = 49;
	this.btnShow.Text = "Show";
	this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
	// 
	// rBtnByMaterialWeeks
	// 
	this.rBtnByMaterialWeeks.Location = new System.Drawing.Point(168, 48);
	this.rBtnByMaterialWeeks.Name = "rBtnByMaterialWeeks";
	this.rBtnByMaterialWeeks.Size = new System.Drawing.Size(136, 16);
	this.rBtnByMaterialWeeks.TabIndex = 48;
	this.rBtnByMaterialWeeks.Text = "By Materials (Weeks)";
	// 
	// rBtnBySupplierWeeks
	// 
	this.rBtnBySupplierWeeks.Location = new System.Drawing.Point(304, 48);
	this.rBtnBySupplierWeeks.Name = "rBtnBySupplierWeeks";
	this.rBtnBySupplierWeeks.Size = new System.Drawing.Size(128, 16);
	this.rBtnBySupplierWeeks.TabIndex = 47;
	this.rBtnBySupplierWeeks.Text = "By Supplier (Weeks)";
	// 
	// rBtnBySupplierDays
	// 
	this.rBtnBySupplierDays.Location = new System.Drawing.Point(304, 24);
	this.rBtnBySupplierDays.Name = "rBtnBySupplierDays";
	this.rBtnBySupplierDays.Size = new System.Drawing.Size(120, 16);
	this.rBtnBySupplierDays.TabIndex = 46;
	this.rBtnBySupplierDays.Text = "By Supplier (Days)";
	// 
	// rbtnByMaterialsDays
	// 
	this.rbtnByMaterialsDays.Location = new System.Drawing.Point(168, 24);
	this.rbtnByMaterialsDays.Name = "rbtnByMaterialsDays";
	this.rbtnByMaterialsDays.Size = new System.Drawing.Size(120, 16);
	this.rbtnByMaterialsDays.TabIndex = 44;
	this.rbtnByMaterialsDays.Text = "By Materials (days)";
	// 
	// rBtnGByMaterialPart
	// 
	this.rBtnGByMaterialPart.Location = new System.Drawing.Point(16, 40);
	this.rBtnGByMaterialPart.Name = "rBtnGByMaterialPart";
	this.rBtnGByMaterialPart.Size = new System.Drawing.Size(144, 24);
	this.rBtnGByMaterialPart.TabIndex = 43;
	this.rBtnGByMaterialPart.Text = "Group By Material Part";
	// 
	// rBtnGbyParentPart
	// 
	this.rBtnGbyParentPart.Location = new System.Drawing.Point(16, 24);
	this.rBtnGbyParentPart.Name = "rBtnGbyParentPart";
	this.rBtnGbyParentPart.Size = new System.Drawing.Size(136, 16);
	this.rBtnGbyParentPart.TabIndex = 42;
	this.rBtnGbyParentPart.Text = "Group By Parent Part";
	// 
	// MaterialsForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(874, 440);
	this.Controls.Add(this.groupBox3);
	this.Controls.Add(this.groupBox1);
	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
	this.MaximizeBox = false;
	this.Name = "MaterialsForm";
	this.Text = "Materials";
	this.Closing += new System.ComponentModel.CancelEventHandler(this.MaterialsForm_Closing);
	this.Load += new System.EventHandler(this.AddForm_Load);
	this.groupBox3.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
	this.groupBox1.ResumeLayout(false);
	this.ResumeLayout(false);

}
#endregion

private
void AddForm_Load(object sender, System.EventArgs e){
	initializeItemsGrid();
}

private
void initializeItemsGrid(){
	if (vecMat == null){
		vecMat = core.getAllMatReqAsString(deptFilter, partFilter, Configuration.DftPlant);
	}

	dataTable = new DataTable();
    DataRow dataRow;

	dataTable.Columns.Add(new DataColumn("Version", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Plant", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Dept", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Prod", typeof(string)));
	dataTable.Columns.Add(new DataColumn("P. Seq", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Mat", typeof(string)));
	dataTable.Columns.Add(new DataColumn("M. Seq", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Usage", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Qoh", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Dem Mat Req", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Sch Mat Req", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Cume Requirement", typeof(string)));

	arrayOfMaterials = new SortedList(new MyComparator(), vecMat.Length);
	arrayOfMaterialsByMaterial = new SortedList(new MyComparator(), vecMat.Length);

	for(int x = 0; x < vecMat.Length; x++){
		if (!vecMat[x][15].Equals("")){
			dataRow = dataTable.NewRow();
 			dataRow[0] = ""; // version
			dataRow[1] = ""; // plant
			dataRow[2] = ""; // dept
 			dataRow[3] = ""; // prod
			dataRow[4] = ""; // prod seq
 			dataRow[5] = vecMat[x][5]; // mat
 			dataRow[6] = vecMat[x][6]; // mat seq
 			dataRow[7] = ""; // date
 			dataRow[8] = ""; // usage
 			dataRow[9] = vecMat[x][15]; // Qoh
 			dataRow[10] = ""; // Dem Mat Req
 			dataRow[11] = ""; // Sch Mat Req
 			dataRow[12] = ""; // Cume Requirement
			dataTable.Rows.Add(dataRow);
		}

		if (!allocatedCheckBox.Checked){ // apply filter
			decimal currentQty = decimal.Parse(vecMat[x][14]);
			if (currentQty >= 0)
				continue;
		}

		dataRow = dataTable.NewRow();
 		dataRow[0] = vecMat[x][0]; // version
		dataRow[1] = vecMat[x][1]; // plant
		dataRow[2] = vecMat[x][2]; // dept
 		dataRow[3] = vecMat[x][3]; // prod
		dataRow[4] = vecMat[x][4]; // prod seq
 		dataRow[5] = vecMat[x][5]; // mat
 		dataRow[6] = vecMat[x][6]; // mat seq
 		dataRow[7] = vecMat[x][7]; // date

		if (vecMat[x][9].Equals("S"))
 			dataRow[8] = "Scheduler"; // usage
		if (vecMat[x][9].Equals("D"))
 			dataRow[8] = "Demand"; // usage
		if (vecMat[x][9].Equals("B"))
 			dataRow[8] = "Both"; // usage

 		dataRow[9] = vecMat[x][10]; // Remaining Qoh
 		dataRow[10] = vecMat[x][12]; // Dem Mat Req
 		dataRow[11] = vecMat[x][13]; // Sch Mat Req
 		dataRow[12] = vecMat[x][14]; // Cume Requirement

		dataTable.Rows.Add(dataRow);

//string prod, string prodSeq, string mat, string matSeq, string date
		MyKey myKey = new MyKey(vecMat[x][3], vecMat[x][4], vecMat[x][5], vecMat[x][6], vecMat[x][7]);
		arrayOfMaterials.Add(myKey, vecMat[x]);

		// material - material sequence - date - product - product sequence
		MyKey myKey2 = new MyKey(vecMat[x][5], vecMat[x][6], vecMat[x][7], vecMat[x][3], vecMat[x][4]);
		arrayOfMaterialsByMaterial.Add(myKey2, vecMat[x]);
	}

	dataView = new DataView(dataTable);
	dataView.AllowEdit = false;
	dataView.AllowDelete = false;
	dataView.AllowNew = false;
	
	grid.DataSource = dataView;
	grid.PreferredColumnWidth = 150;
	grid.PreferredRowHeight = 22;
	grid.RowHeadersVisible = false;
	grid.AllowSorting = false;

	//Create a DataGridTableStyle object	
	DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();
	//Set its properties
	dgdtblStyle.MappingName			= dataTable.TableName;//its table name of dataset
	grid.TableStyles.Clear(); 
	grid.TableStyles.Add(dgdtblStyle);
	dgdtblStyle.RowHeadersVisible	= true;
	dgdtblStyle.AllowSorting		= false;
	dgdtblStyle.PreferredRowHeight	= 22;
	GridColumnStylesCollection	colStyle;
	colStyle				= grid.TableStyles[0].GridColumnStyles;		
	colStyle[0].Width      	= 0; // version
	colStyle[1].Width		= 35; // plant
	colStyle[2].Width		= 35; // dept
	colStyle[3].Width		= 90; // prod
	colStyle[4].Width		= 40; // prod seq
	colStyle[5].Width      	= 90; // mat
	colStyle[6].Width		= 40; // mat seq
	colStyle[7].Width		= 70; // date
	colStyle[8].Width		= 60; // usage
	colStyle[9].Width		= 60; // qoh
	colStyle[10].Width      = 80; // Dem Mat Req",
	colStyle[11].Width		= 80; // Sch Mat Req",
	colStyle[12].Width		= 80; // Allocated Qty

	grid.CaptionText = dataTable.Rows.Count.ToString() + " rows";
	grid.Refresh();
}

private
string getCurrentValue(int column){
	int row = grid.CurrentRowIndex;

	DataView myView;
    myView = (DataView) grid.DataSource;

	if (row > -1) {
		int cols = myView.Table.Columns.Count;
		if (column<cols) {
			for(int i = 0; i < cols; i++){
				return grid[row, column].ToString();
			}
		} else
			return "";
	} else
		return "";
	return "";
}
		
// sets a value in the shift data grid
private
void setCurrentValue(string myValue, int column){
	int row = grid.CurrentCell.RowNumber;
	int index = 0;

	IEnumerator en = dataTable.Rows.GetEnumerator();
	while(en.MoveNext()){
		DataRow dataRow = (DataRow)en.Current;

		if (index == row){
			string dataType = dataRow[column].GetType().ToString();
			switch(dataType){
			case "System.String":
				dataRow[column] = myValue;
				break;
			case "System.Int32":
				int intValue = int.Parse(myValue);
				dataRow[column] = intValue;
				break;
			case "System.Decimal":
				dataRow[column] = decimal.Parse(myValue);
				break;
			case "System.DateTime":
				dataRow[column] = DateUtil.parseDate(myValue, DateUtil.DDMMYYYY);
				break;
			}
		}
		index++;
	}
}

private 
void grid_Click(object sender, System.EventArgs e){
	grid.PreferredRowHeight = 10;

	DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();
    
	dgdtblStyle = grid.TableStyles[0];
	dgdtblStyle.PreferredRowHeight = 10;
}

private 
void closeButton_Click_1(object sender, System.EventArgs e){
	this.core = null;
	Close();
}


private 
DataSet generateDataSetMaterialsByMaterial(){
	this.Cursor = Cursors.WaitCursor;

	DataTable dataTable = new DataTable();

	dataTable.TableName = "materials";
	dataTable.Columns.Add(new DataColumn("ParentPart", typeof(string)));
	dataTable.Columns.Add(new DataColumn("DateRequired", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Material", typeof(string)));
	dataTable.Columns.Add(new DataColumn("QtyReq", typeof(string)));
	dataTable.Columns.Add(new DataColumn("InvQty", typeof(string)));
	dataTable.Columns.Add(new DataColumn("SchMatReq", typeof(string)));
	dataTable.Columns.Add(new DataColumn("AllocatedQty", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Qoh", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Factor", typeof(string)));
	dataTable.Columns.Add(new DataColumn("ParentDemand", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
	dataTable.Columns.Add(new DataColumn("LeadTime", typeof(string)));

	string lastMaterial = "";
	string lastQoh = "";
	string lastFactor = "";

	for(int z = 0; z < vecMat.Length; z++){
		string[] line = vecMat[z];

		if (!allocatedCheckBox.Checked){ // apply filter
			decimal currentQty = decimal.Parse(line[14]);
			if (currentQty >= 0)
				continue;
		}

		DataRow dataRow;
		dataRow = dataTable.NewRow();

		dataRow[0] = line[3] + " " + line[4];
		dataRow[1] = line[7];
		dataRow[3] = line[12];
		dataRow[4] = line[10];

		string schMatReq = line[13];
		if (Convert.ToDecimal(line[10]) < 0)
			schMatReq = line[10];

		dataRow[5] = schMatReq;
		dataRow[6] = line[14];

		if (!lastMaterial.Equals(line[5])){
			dataRow[2] = line[5] + " " + line[6];

			Inventory inventory = core.readInventory(line[5], Configuration.DftPlant);
			lastQoh = NumberUtilReports.toString(inventory.getTotalInventory());
			dataRow[7] = lastQoh;
		}else{
			dataRow[2] = line[5] + " " + line[6];
			dataRow[7] = lastQoh;
		}
		dataRow[8] = line[16]; // multiply factor

		if (!line[16].Equals(""))
			lastFactor = line[16];
        
        if (!NumberUtil.isDecimalNumber(lastFactor) || decimal.Parse(lastFactor) == 0) //AF 2019-05-14 added if because of error attemp divide zero
            lastFactor="1";                            

        decimal parentDemand = decimal.Parse(line[12]) / decimal.Parse(lastFactor);        

		dataRow[9] = parentDemand.ToString("##############0"); // parent demand

		dataRow[10] = line[17];
		dataRow[11] = line[18];

		dataTable.Rows.Add(dataRow);
		lastMaterial = line[5];
	}

	DataSet materialsDataSet = new DataSet();
	materialsDataSet.Tables.Add(dataTable);

	this.Cursor = Cursors.Default;
	return materialsDataSet;
}

private 
DataSet generateDataSetMaterialsByProduct(){
	this.Cursor = Cursors.WaitCursor;
	
	DataTable dataTable = new DataTable();

	dataTable.TableName = "materials";
	dataTable.Columns.Add(new DataColumn("ParentPart", typeof(string)));
	dataTable.Columns.Add(new DataColumn("DateRequired", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Material", typeof(string)));
	dataTable.Columns.Add(new DataColumn("QtyReq", typeof(string)));
	dataTable.Columns.Add(new DataColumn("InvQty", typeof(string)));
	dataTable.Columns.Add(new DataColumn("SchMatReq", typeof(string)));
	dataTable.Columns.Add(new DataColumn("AllocatedQty", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Qoh", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Factor", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
	dataTable.Columns.Add(new DataColumn("LeadTime", typeof(string)));

	string lastMaterial = "";
	string lastQoh = "";

	IEnumerator en = arrayOfMaterials.GetEnumerator();

	for(; en.MoveNext(); ){
		DictionaryEntry entry = (DictionaryEntry)en.Current;
		string[] line = (string[])entry.Value;

		if (!allocatedCheckBox.Checked){ // apply filter
			decimal currentQty = decimal.Parse(line[14]);
			if (currentQty >= 0)
				continue;
		}

		DataRow dataRow;
		dataRow = dataTable.NewRow();

		dataRow[0] = line[3] + " " + line[4];
		dataRow[1] = line[7];
		dataRow[3] = line[12];
		dataRow[4] = line[10];

		string schMatReq = line[13];
		if (Convert.ToDecimal(line[10]) < 0)
			schMatReq = line[10];

		dataRow[5] = schMatReq;
		dataRow[6] = line[14];

		if (!lastMaterial.Equals(line[5])){
			dataRow[2] = line[5] + " " + line[6];

			Inventory inventory = core.readInventory(line[5], Configuration.DftPlant);
			lastQoh = NumberUtilReports.toString(inventory.getTotalInventory());
			dataRow[7] = lastQoh;
		}else{
			dataRow[2] = "";
			dataRow[7] = "";
		}
		dataRow[8] = line[16];

		dataRow[9] = line[17];
		dataRow[10] = line[18];

		dataTable.Rows.Add(dataRow);

		lastMaterial = line[5];
	}

	DataSet materialsDataSet = new DataSet();
	materialsDataSet.Tables.Add(dataTable);

	this.Cursor = Cursors.Default;

	return materialsDataSet;
}

private 
void allocatedCheckBox_Click(object sender, System.EventArgs e){
	initializeItemsGrid();
}

private 
DataSet generateDataSetMaterialDueDate(string[][] materials){
	this.Cursor = Cursors.WaitCursor;
	
	DataTable dataTable = new DataTable();

	dataTable.TableName = "materials";
	dataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Material", typeof(string)));
	dataTable.Columns.Add(new DataColumn("MaterialSeq", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Qoh", typeof(string)));
	dataTable.Columns.Add(new DataColumn("PastDue", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Ent1", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Ent2", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Ent3", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Ent4", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Ent5", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Ent6", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Ent7", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Ent8", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Ent9", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Ent10", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Ent11", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Ent12", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Ent13", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Ent14", typeof(string)));
	dataTable.Columns.Add(new DataColumn("MaterialDescription", typeof(string)));

	for(int i = 0; i < materials.Length; i++){
		DataRow dataRow;
		dataRow = dataTable.NewRow();

		dataRow[0] = materials[i][0]; // supp
		dataRow[1] = materials[i][2]; // mat
		dataRow[2] = materials[i][3]; // seq
		dataRow[3] = materials[i][1]; // qoh
		dataRow[4] = materials[i][5]; // past due
		dataRow[5] = materials[i][6]; // ent1
		dataRow[6] = materials[i][7]; // ent2
		dataRow[7] = materials[i][8]; // ent3
		dataRow[8] = materials[i][9]; // ent4
		dataRow[9] = materials[i][10]; // ent5
		dataRow[10] = materials[i][11]; // ent6
		dataRow[11] = materials[i][12]; // ent7
		dataRow[12] = materials[i][13]; // ent8
		dataRow[13] = materials[i][14]; // ent9
		dataRow[14] = materials[i][15]; // ent10
		dataRow[15] = materials[i][16]; // ent11
		dataRow[16] = materials[i][17]; // ent12
		dataRow[17] = materials[i][18]; // ent13
		dataRow[18] = materials[i][19]; // ent14
		dataRow[19] = materials[i][4]; // mat desc

		dataTable.Rows.Add(dataRow);
	}

	DataSet materialsDataSet = new DataSet();
	materialsDataSet.Tables.Add(dataTable);

	this.Cursor = Cursors.Default;

	return materialsDataSet;
}
private 
DataSet generateDataSetMaterialDueDateByDemand(string[][] materials){
	for(int i = 0; i < materials.Length; i++){
		for(int x = i + 1; x < materials.Length; x++){
			decimal pastDue_1 = decimal.Parse(materials[i][5]);
			decimal ent1_1 = decimal.Parse(materials[i][6]);
			decimal ent2_1 = decimal.Parse(materials[i][7]);
			decimal ent3_1 = decimal.Parse(materials[i][8]);
			decimal ent4_1 = decimal.Parse(materials[i][9]);
			decimal ent5_1 = decimal.Parse(materials[i][10]);
			decimal ent6_1 = decimal.Parse(materials[i][11]);
			decimal ent7_1 = decimal.Parse(materials[i][12]);
			decimal ent8_1 = decimal.Parse(materials[i][13]);
			decimal ent9_1 = decimal.Parse(materials[i][14]);
			decimal ent10_1 = decimal.Parse(materials[i][15]);
			decimal ent11_1 = decimal.Parse(materials[i][16]);
			decimal ent12_1 = decimal.Parse(materials[i][17]);
			decimal ent13_1 = decimal.Parse(materials[i][18]);
			decimal ent14_1 = decimal.Parse(materials[i][19]);

			decimal pastDue_2 = decimal.Parse(materials[x][5]);
			decimal ent1_2 = decimal.Parse(materials[x][6]);
			decimal ent2_2 = decimal.Parse(materials[x][7]);
			decimal ent3_2 = decimal.Parse(materials[x][8]);
			decimal ent4_2 = decimal.Parse(materials[x][9]);
			decimal ent5_2 = decimal.Parse(materials[x][10]);
			decimal ent6_2 = decimal.Parse(materials[x][11]);
			decimal ent7_2 = decimal.Parse(materials[x][12]);
			decimal ent8_2 = decimal.Parse(materials[x][13]);
			decimal ent9_2 = decimal.Parse(materials[x][14]);
			decimal ent10_2 = decimal.Parse(materials[x][15]);
			decimal ent11_2 = decimal.Parse(materials[x][16]);
			decimal ent12_2 = decimal.Parse(materials[x][17]);
			decimal ent13_2 = decimal.Parse(materials[x][18]);
			decimal ent14_2 = decimal.Parse(materials[x][19]);

			if (greaterDemand(pastDue_1, ent1_1, ent2_1, ent3_1, ent4_1, ent5_1, ent6_1, ent7_1, 
					ent8_1, ent9_1, ent10_1, ent11_1, ent12_1, ent13_1, ent14_1, pastDue_2, ent1_2,
					ent2_2, ent3_2, ent4_2, ent5_2, ent6_2, ent7_2, ent8_2, ent9_2, ent10_2, ent11_2, 
					ent12_2, ent13_2, ent14_2)){

				// swap
				for(int z = 0; z < materials[x].Length; z++){
					string backup = materials[x][z];
					materials[x][z] = materials[i][z];
					materials[i][z] = backup;
				}
			}
		}
	}

	return generateDataSetMaterialDueDate(materials);
}

private 
bool greaterDemand(decimal pastDue_1, decimal ent1_1, decimal ent2_1, decimal ent3_1, decimal ent4_1,
		decimal ent5_1, decimal ent6_1, decimal ent7_1, decimal ent8_1, decimal ent9_1, decimal ent10_1,
		decimal ent11_1, decimal ent12_1, decimal ent13_1, decimal ent14_1, decimal pastDue_2, decimal ent1_2,
		decimal ent2_2, decimal ent3_2, decimal ent4_2, decimal ent5_2, decimal ent6_2, decimal ent7_2,
		decimal ent8_2, decimal ent9_2, decimal ent10_2, decimal ent11_2, decimal ent12_2, decimal ent13_2,
		decimal ent14_2){

	bool isGreaterDemand = false;

	if ((pastDue_1 > pastDue_2) || (pastDue_1 == pastDue_2)){
		isGreaterDemand = (pastDue_1 > pastDue_2);
		if (isGreaterDemand)
			return true;

		if ((ent1_1 > ent1_2) || (ent1_1 == ent1_2)){
			isGreaterDemand = (ent1_1 > ent1_2);
			if (isGreaterDemand)
				return true;

			if ((ent2_1 > ent2_2) || (ent2_1 == ent2_2)){
				isGreaterDemand = (ent2_1 > ent2_2);
				if (isGreaterDemand)
					return true;

				if ((ent3_1 > ent3_2) || (ent3_1 == ent3_2)){
					isGreaterDemand = (ent3_1 > ent3_2);
					if (isGreaterDemand)
						return true;

					if ((ent4_1 > ent4_2) || (ent4_1 == ent4_2)){
						isGreaterDemand = (ent4_1 > ent4_2);
						if (isGreaterDemand)
							return true;

						if ((ent5_1 > ent5_2) || (ent5_1 == ent5_2)){
							isGreaterDemand = (ent5_1 > ent5_2);
							if (isGreaterDemand)
								return true;

							if ((ent6_1 > ent6_2) || (ent6_1 == ent6_2)){
								isGreaterDemand = (ent6_1 > ent6_2);
								if (isGreaterDemand)
									return true;

								if ((ent7_1 > ent7_2) || (ent7_1 == ent7_2)){
									isGreaterDemand = (ent7_1 > ent7_2);
									if (isGreaterDemand)
										return true;

									if ((ent8_1 > ent8_2) || (ent8_1 == ent8_2)){
										isGreaterDemand = (ent8_1 > ent8_2);
										if (isGreaterDemand)
											return true;

										if ((ent9_1 > ent9_2) || (ent9_1 == ent9_2)){
											isGreaterDemand = (ent9_1 > ent9_2);
											if (isGreaterDemand)
												return true;

											if ((ent10_1 > ent10_2) || (ent10_1 == ent10_2)){
												isGreaterDemand = (ent10_1 > ent10_2);
												if (isGreaterDemand)
													return true;

												if ((ent11_1 > ent11_2) || (ent11_1 == ent11_2)){
													isGreaterDemand = (ent11_1 > ent11_2);
													if (isGreaterDemand)
														return true;

													if ((ent12_1 > ent12_2) || (ent12_1 == ent12_2)){
														isGreaterDemand = (ent12_1 > ent12_2);
														if (isGreaterDemand)
															return true;
													
														if ((ent13_1 > ent13_2) || (ent13_1 == ent13_2)){
															isGreaterDemand = (ent13_1 > ent13_2);
															if (isGreaterDemand)
																return true;

															if ((ent14_1 > ent14_2) || (ent14_1 == ent14_2)){
																isGreaterDemand = (ent14_1 > ent14_2);
																if (isGreaterDemand)
																	return true;
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
	return isGreaterDemand;
}

private 
void dayDueDatebutton_Click(object sender, System.EventArgs e){
	string[][] materialDueDate = core.getMaterialDueDate(false, deptFilter, partFilter, false, matbFilter, Configuration.DftPlant);
	DataSet dataSet = generateDataSetMaterialDueDate(materialDueDate);

	MaterialsReportDueDate materialsReportDueDate = new MaterialsReportDueDate(dataSet, true, this.lessDays);
	materialsReportDueDate.Show();
	
}

private 
void weeksButton_Click(object sender, System.EventArgs e){
	string[][] materialDueDate = core.getMaterialDueDate(true, deptFilter, partFilter, false, matbFilter, Configuration.DftPlant);
	DataSet dataSet = generateDataSetMaterialDueDate(materialDueDate);

	MaterialsReportDueDate materialsReportDueDate = new MaterialsReportDueDate(dataSet, false, this.lessDays);
	materialsReportDueDate.Show();
	
}

private 
void supplierDayButton_Click(object sender, System.EventArgs e){
	string[][] materialDueDate = core.getMaterialDueDate(false, deptFilter, partFilter, true, matbFilter, Configuration.DftPlant);
	DataSet dataSet = generateDataSetMaterialDueDate(materialDueDate);

	MaterialsReportDueDateVendor materialsReportDueDateVendor = new MaterialsReportDueDateVendor(dataSet, true, this.lessDays);
	materialsReportDueDateVendor.Show();

}

private 
void supplierWeekButton_Click(object sender, System.EventArgs e){
	string[][] materialDueDate = core.getMaterialDueDate(true, deptFilter, partFilter, true, matbFilter, Configuration.DftPlant);
	DataSet dataSet = generateDataSetMaterialDueDate(materialDueDate);
	
	MaterialsReportDueDateVendor materialsReportDueDateVendor = new MaterialsReportDueDateVendor(dataSet, false, this.lessDays);
	materialsReportDueDateVendor.Show();
}


private 
void btnShow_Click(object sender, System.EventArgs e){
	this.Cursor = Cursors.WaitCursor;

	if (rBtnGbyParentPart.Checked){
		DataSet dsMaterials = this.generateDataSetMaterialsByProduct();
		MaterialsReport materialsReport = new MaterialsReport(dsMaterials);
		materialsReport.Show();
	}

	if (this.rBtnGByMaterialPart.Checked){
		DataSet dsMaterials = generateDataSetMaterialsByMaterial();
		MaterialsReportByMaterial materialsReportByMaterial = new MaterialsReportByMaterial(dsMaterials);
		materialsReportByMaterial.Show();	
	}

	if (this.rbtnByMaterialsDays.Checked){
		string[][] materialDueDate = core.getMaterialDueDate(false, deptFilter, partFilter, false, matbFilter, Configuration.DftPlant);
		DataSet dataSet = generateDataSetMaterialDueDate(materialDueDate);
		MaterialsReportDueDate materialsReportDueDate = new MaterialsReportDueDate(dataSet, true, this.lessDays);
		materialsReportDueDate.Show();
	}

	if (this.rBtnByMaterialWeeks.Checked){
		string[][] materialDueDate = core.getMaterialDueDate(true, deptFilter, partFilter, false, matbFilter, Configuration.DftPlant);
		DataSet dataSet = generateDataSetMaterialDueDate(materialDueDate);
		MaterialsReportDueDate materialsReportDueDate = new MaterialsReportDueDate(dataSet, false, this.lessDays);
		materialsReportDueDate.Show();
	}

	if (this.rBtnBySupplierDays.Checked){
		string[][] materialDueDate = core.getMaterialDueDate(false, deptFilter, partFilter, true, matbFilter, Configuration.DftPlant);
		DataSet dataSet = generateDataSetMaterialDueDate(materialDueDate);
		MaterialsReportDueDateVendor materialsReportDueDateVendor = new MaterialsReportDueDateVendor(dataSet, true, this.lessDays);
		materialsReportDueDateVendor.Show();
	}

	if (this.rBtnBySupplierWeeks.Checked){
		string[][] materialDueDate = core.getMaterialDueDate(true, deptFilter, partFilter, true, matbFilter, Configuration.DftPlant);
		DataSet dataSet = generateDataSetMaterialDueDate(materialDueDate);
		MaterialsReportDueDateVendor materialsReportDueDateVendor = new MaterialsReportDueDateVendor(dataSet, false, this.lessDays);
		materialsReportDueDateVendor.Show();
	}

	if (this.rBtnBySupplierDaysExcell.Checked){
		string[][] materialDueDate = core.getMaterialDueDate(false, deptFilter, partFilter, true, matbFilter, Configuration.DftPlant);
		DataSet dataSetExc = generateDataSetMaterialDueDate(materialDueDate);

		rptMaterialsReportGroupByDateVendorExcMartinRea rpt = null;
		rptMaterialsReportGroupByDateVendorExc rpt2 = null;

		if (this.lessDays)
		{
			rpt = new rptMaterialsReportGroupByDateVendorExcMartinRea();
			rpt.setLabel("Day");
			GenerateReportFormat.generateReport(rpt, dataSetExc, "materials", Constants.XLS_FORMAT);
		}
		else
		{
			rpt2 = new rptMaterialsReportGroupByDateVendorExc();
			rpt2.setLabel("Day");
			GenerateReportFormat.generateReport(rpt2, dataSetExc, "materials", Constants.XLS_FORMAT);
		}
	}

	if (this.orderByDemandRadioButton.Checked){
		string[][] materialDueDate = core.getMaterialDueDate(false, deptFilter, partFilter, false, matbFilter, Configuration.DftPlant);
		DataSet dataSet = generateDataSetMaterialDueDateByDemand(materialDueDate);
		MaterialsReportDueDateDemand materialsReportDueDateDemand = new MaterialsReportDueDateDemand(dataSet, true, this.lessDays);
		materialsReportDueDateDemand.Show();
	}

	this.Cursor = Cursors.Default;
}

private 
void MaterialsForm_Closing(object sender, System.ComponentModel.CancelEventArgs e){
	this.core = null;
}



//-----------------------------------------------------

private
class MyComparator : System.Collections.IComparer{

public
int Compare(Object o1, Object o2){
	MyKey myKey1 = (MyKey)o1;
	MyKey myKey2 = (MyKey)o2;
	return myKey1.CompareTo(myKey2);
}

}

private
class MyKey{

private string prod;
private string prodSeq;
private string mat;
private string matSeq;
private string date;

public
MyKey(string prod, string prodSeq, string mat, string matSeq, string date){
	this.prod = prod;
	this.prodSeq = prodSeq;
	this.mat = mat;
	this.matSeq = matSeq;

	if (DateUtil.isValidDate(date, DateUtil.MMDDYYYY)){
		DateTime aux = DateUtil.parseDate(date, DateUtil.MMDDYYYY);
		this.date = DateUtil.getDateRepresentation(aux, DateUtil.YYYYMMDD);
	}else{
		this.date = date;
	}
}

public override
bool Equals(Object obj){
	return (this.CompareTo(obj) == 0);
}

public
int CompareTo(Object obj){
	MyKey miKey = (MyKey)obj;

	if (prod.CompareTo(miKey.prod) != 0)
		return prod.CompareTo(miKey.prod);
	if (prodSeq.CompareTo(miKey.prodSeq) != 0)
		return prodSeq.CompareTo(miKey.prodSeq);
	if (mat.CompareTo(miKey.mat) != 0)
		return mat.CompareTo(miKey.mat);
	if (matSeq.CompareTo(miKey.matSeq) != 0)
		return matSeq.CompareTo(miKey.matSeq);
	if (date.CompareTo(miKey.date) != 0)
		return date.CompareTo(miKey.date);
	return 0;
}

public override
string ToString(){
	return prod + "-" + prodSeq + "-" + mat + "-" + matSeq + "-" + date;
}

}


} // class

} // namespace