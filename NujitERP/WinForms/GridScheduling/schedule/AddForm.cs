using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using System.Threading;

using Nujit.NujitERP.ClassLib.Core;
using GridScheduling.gui;
using GridScheduling.gui.Model;

using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.WinForms;


namespace GridScheduling.gui.schedule{

/// <summary>
/// Summary description for AddForm.
/// </summary>
public
class AddForm : System.Windows.Forms.Form{

private ScheduleModel model = null;

private System.Windows.Forms.TabControl tabControl1;
private System.Windows.Forms.TabPage gridView1;
private System.Windows.Forms.TabPage gridView2;

private System.Windows.Forms.GroupBox groupBox1;
private System.Windows.Forms.Label label20;
private System.Windows.Forms.GroupBox groupBox3;
private System.Windows.Forms.Panel panel1;

private System.Windows.Forms.Button addButton;
private System.Windows.Forms.Button removeButton;
private System.Windows.Forms.Button editButton;
private System.Windows.Forms.Label label1;
private System.Windows.Forms.Label label2;
private System.Windows.Forms.TextBox startTextBox;
private System.Windows.Forms.TextBox endTextBox;
private System.Windows.Forms.TextBox pltTextBox;
private System.Windows.Forms.Button OkButton;
private System.Windows.Forms.Button cancelButton;
private System.Windows.Forms.DataGrid grid;
private System.Windows.Forms.Label label3;
private System.Windows.Forms.TextBox versionTextBox;
private System.Windows.Forms.DataGrid materialsDataGrid;
private DataTable materialsDataTable;
private System.Windows.Forms.Button hotListButton;


/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;

private string plant;
private string machine;
private string version;
private CoreFactory core = UtilCoreFactory.createCoreFactory();
private Schedule schedule = null;
private DataTable dataTable;
private System.Windows.Forms.Button removeAllButton;
private DataView dataView;

public
AddForm(string plant, string version, ScheduleModel model){
	InitializeComponent();
	
	this.model = model;
	this.plant = plant;
	this.machine = machine;
	this.version = version;

	modifyDataControls();
}

private 
void modifyDataControls(){
	this.pltTextBox.Text = plant;
	this.pltTextBox.Enabled = false;
	this.versionTextBox.Text = version;
	
	schedule = core.readSchedule(plant, version);

	this.startTextBox.Text = DateUtil.getDateRepresentation(schedule.getDtStartVersion(), DateUtil.MMDDYYYY);
	this.startTextBox.Enabled = false;
	this.endTextBox.Text = DateUtil.getDateRepresentation(schedule.getDtEndVersion(), DateUtil.MMDDYYYY);
	this.endTextBox.Enabled = false;
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
	this.groupBox1 = new System.Windows.Forms.GroupBox();
	this.versionTextBox = new System.Windows.Forms.TextBox();
	this.label3 = new System.Windows.Forms.Label();
	this.cancelButton = new System.Windows.Forms.Button();
	this.OkButton = new System.Windows.Forms.Button();
	this.pltTextBox = new System.Windows.Forms.TextBox();
	this.endTextBox = new System.Windows.Forms.TextBox();
	this.startTextBox = new System.Windows.Forms.TextBox();
	this.label2 = new System.Windows.Forms.Label();
	this.label1 = new System.Windows.Forms.Label();
	this.label20 = new System.Windows.Forms.Label();
	this.groupBox3 = new System.Windows.Forms.GroupBox();
	this.panel1 = new System.Windows.Forms.Panel();
	this.removeAllButton = new System.Windows.Forms.Button();
	this.hotListButton = new System.Windows.Forms.Button();
	this.editButton = new System.Windows.Forms.Button();
	this.removeButton = new System.Windows.Forms.Button();
	this.addButton = new System.Windows.Forms.Button();
	this.tabControl1 = new System.Windows.Forms.TabControl();
	this.gridView1 = new System.Windows.Forms.TabPage();
	this.grid = new System.Windows.Forms.DataGrid();
	this.gridView2 = new System.Windows.Forms.TabPage();
	this.materialsDataGrid = new System.Windows.Forms.DataGrid();
	this.groupBox1.SuspendLayout();
	this.groupBox3.SuspendLayout();
	this.panel1.SuspendLayout();
	this.tabControl1.SuspendLayout();
	this.gridView1.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
	this.gridView2.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.materialsDataGrid)).BeginInit();
	this.SuspendLayout();
	// 
	// groupBox1
	// 
	this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
		| System.Windows.Forms.AnchorStyles.Right)));
	this.groupBox1.Controls.Add(this.versionTextBox);
	this.groupBox1.Controls.Add(this.label3);
	this.groupBox1.Controls.Add(this.cancelButton);
	this.groupBox1.Controls.Add(this.OkButton);
	this.groupBox1.Controls.Add(this.pltTextBox);
	this.groupBox1.Controls.Add(this.endTextBox);
	this.groupBox1.Controls.Add(this.startTextBox);
	this.groupBox1.Controls.Add(this.label2);
	this.groupBox1.Controls.Add(this.label1);
	this.groupBox1.Controls.Add(this.label20);
	this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.groupBox1.Location = new System.Drawing.Point(16, 16);
	this.groupBox1.Name = "groupBox1";
	this.groupBox1.Size = new System.Drawing.Size(752, 88);
	this.groupBox1.TabIndex = 37;
	this.groupBox1.TabStop = false;
	this.groupBox1.Text = "Version";
	// 
	// versionTextBox
	// 
	this.versionTextBox.Enabled = false;
	this.versionTextBox.Location = new System.Drawing.Point(72, 48);
	this.versionTextBox.Name = "versionTextBox";
	this.versionTextBox.Size = new System.Drawing.Size(176, 20);
	this.versionTextBox.TabIndex = 55;
	this.versionTextBox.Text = "";
	// 
	// label3
	// 
	this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.label3.Location = new System.Drawing.Point(24, 48);
	this.label3.Name = "label3";
	this.label3.Size = new System.Drawing.Size(64, 20);
	this.label3.TabIndex = 54;
	this.label3.Text = "Version:";
	this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// cancelButton
	// 
	this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.cancelButton.Location = new System.Drawing.Point(664, 48);
	this.cancelButton.Name = "cancelButton";
	this.cancelButton.TabIndex = 53;
	this.cancelButton.Text = "Cancel";
	this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
	// 
	// OkButton
	// 
	this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
	this.OkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.OkButton.Location = new System.Drawing.Point(664, 16);
	this.OkButton.Name = "OkButton";
	this.OkButton.TabIndex = 52;
	this.OkButton.Text = "Ok";
	this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
	// 
	// pltTextBox
	// 
	this.pltTextBox.Location = new System.Drawing.Point(72, 24);
	this.pltTextBox.Name = "pltTextBox";
	this.pltTextBox.Size = new System.Drawing.Size(176, 20);
	this.pltTextBox.TabIndex = 50;
	this.pltTextBox.Text = "";
	// 
	// endTextBox
	// 
	this.endTextBox.Enabled = false;
	this.endTextBox.Location = new System.Drawing.Point(328, 48);
	this.endTextBox.Name = "endTextBox";
	this.endTextBox.Size = new System.Drawing.Size(176, 20);
	this.endTextBox.TabIndex = 49;
	this.endTextBox.Text = "";
	// 
	// startTextBox
	// 
	this.startTextBox.Enabled = false;
	this.startTextBox.Location = new System.Drawing.Point(328, 24);
	this.startTextBox.Name = "startTextBox";
	this.startTextBox.Size = new System.Drawing.Size(176, 20);
	this.startTextBox.TabIndex = 48;
	this.startTextBox.Text = "";
	// 
	// label2
	// 
	this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.label2.Location = new System.Drawing.Point(288, 24);
	this.label2.Name = "label2";
	this.label2.Size = new System.Drawing.Size(64, 20);
	this.label2.TabIndex = 47;
	this.label2.Text = "Start:";
	this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label1
	// 
	this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.label1.Location = new System.Drawing.Point(288, 48);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(64, 20);
	this.label1.TabIndex = 46;
	this.label1.Text = "End:";
	this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// label20
	// 
	this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.label20.Location = new System.Drawing.Point(24, 24);
	this.label20.Name = "label20";
	this.label20.Size = new System.Drawing.Size(64, 20);
	this.label20.TabIndex = 39;
	this.label20.Text = "Plant:";
	this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	// 
	// groupBox3
	// 
	this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
		| System.Windows.Forms.AnchorStyles.Left) 
		| System.Windows.Forms.AnchorStyles.Right)));
	this.groupBox3.Controls.Add(this.panel1);
	this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.groupBox3.Location = new System.Drawing.Point(16, 112);
	this.groupBox3.Name = "groupBox3";
	this.groupBox3.Size = new System.Drawing.Size(752, 328);
	this.groupBox3.TabIndex = 39;
	this.groupBox3.TabStop = false;
	this.groupBox3.Text = "Part Info";
	// 
	// panel1
	// 
	this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
		| System.Windows.Forms.AnchorStyles.Left) 
		| System.Windows.Forms.AnchorStyles.Right)));
	this.panel1.Controls.Add(this.removeAllButton);
	this.panel1.Controls.Add(this.hotListButton);
	this.panel1.Controls.Add(this.editButton);
	this.panel1.Controls.Add(this.removeButton);
	this.panel1.Controls.Add(this.addButton);
	this.panel1.Controls.Add(this.tabControl1);
	this.panel1.Location = new System.Drawing.Point(8, 24);
	this.panel1.Name = "panel1";
	this.panel1.Size = new System.Drawing.Size(736, 296);
	this.panel1.TabIndex = 60;
	// 
	// removeAllButton
	// 
	this.removeAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	this.removeAllButton.Location = new System.Drawing.Point(464, 272);
	this.removeAllButton.Name = "removeAllButton";
	this.removeAllButton.TabIndex = 5;
	this.removeAllButton.Text = "Remove All";
	this.removeAllButton.Click += new System.EventHandler(this.removeAllButton_Click);
	// 
	// hotListButton
	// 
	this.hotListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	this.hotListButton.Location = new System.Drawing.Point(304, 272);
	this.hotListButton.Name = "hotListButton";
	this.hotListButton.TabIndex = 4;
	this.hotListButton.Text = "Hot List";
	this.hotListButton.Click += new System.EventHandler(this.hotListButton_Click);
	// 
	// editButton
	// 
	this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	this.editButton.Location = new System.Drawing.Point(624, 272);
	this.editButton.Name = "editButton";
	this.editButton.TabIndex = 3;
	this.editButton.Text = "Edit";
	this.editButton.Click += new System.EventHandler(this.editButton_Click);
	// 
	// removeButton
	// 
	this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	this.removeButton.Location = new System.Drawing.Point(544, 272);
	this.removeButton.Name = "removeButton";
	this.removeButton.TabIndex = 2;
	this.removeButton.Text = "Remove";
	this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
	// 
	// addButton
	// 
	this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	this.addButton.Location = new System.Drawing.Point(384, 272);
	this.addButton.Name = "addButton";
	this.addButton.TabIndex = 1;
	this.addButton.Text = "Add";
	this.addButton.Click += new System.EventHandler(this.addButton_Click);
	// 
	// tabControl1
	// 
	this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
		| System.Windows.Forms.AnchorStyles.Left) 
		| System.Windows.Forms.AnchorStyles.Right)));
	this.tabControl1.Controls.Add(this.gridView1);
	this.tabControl1.Controls.Add(this.gridView2);
	this.tabControl1.Location = new System.Drawing.Point(0, 0);
	this.tabControl1.Name = "tabControl1";
	this.tabControl1.SelectedIndex = 0;
	this.tabControl1.Size = new System.Drawing.Size(736, 264);
	this.tabControl1.TabIndex = 0;
	// 
	// gridView1
	// 
	this.gridView1.Controls.Add(this.grid);
	this.gridView1.Location = new System.Drawing.Point(4, 22);
	this.gridView1.Name = "gridView1";
	this.gridView1.Size = new System.Drawing.Size(728, 246);
	this.gridView1.TabIndex = 0;
	this.gridView1.Text = "Items";
	// 
	// grid
	// 
	this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
		| System.Windows.Forms.AnchorStyles.Left) 
		| System.Windows.Forms.AnchorStyles.Right)));
	this.grid.CaptionVisible = false;
	this.grid.DataMember = "";
	this.grid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
	this.grid.Location = new System.Drawing.Point(8, 8);
	this.grid.Name = "grid";
	this.grid.ReadOnly = true;
	this.grid.Size = new System.Drawing.Size(712, 232);
	this.grid.TabIndex = 0;
	this.grid.Click += new System.EventHandler(this.grid_Click);
	// 
	// gridView2
	// 
	this.gridView2.Controls.Add(this.materialsDataGrid);
	this.gridView2.Location = new System.Drawing.Point(4, 22);
	this.gridView2.Name = "gridView2";
	this.gridView2.Size = new System.Drawing.Size(728, 238);
	this.gridView2.TabIndex = 1;
	this.gridView2.Text = "Materials";
	// 
	// materialsDataGrid
	// 
	this.materialsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
		| System.Windows.Forms.AnchorStyles.Left) 
		| System.Windows.Forms.AnchorStyles.Right)));
	this.materialsDataGrid.CaptionVisible = false;
	this.materialsDataGrid.DataMember = "";
	this.materialsDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
	this.materialsDataGrid.Location = new System.Drawing.Point(8, 8);
	this.materialsDataGrid.Name = "materialsDataGrid";
	this.materialsDataGrid.Size = new System.Drawing.Size(712, 224);
	this.materialsDataGrid.TabIndex = 0;
	this.materialsDataGrid.Click += new System.EventHandler(this.materialsDataGrid_Click);
	// 
	// AddForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(784, 445);
	this.Controls.Add(this.groupBox3);
	this.Controls.Add(this.groupBox1);
	this.MaximizeBox = false;
	this.MinimumSize = new System.Drawing.Size(648, 400);
	this.Name = "AddForm";
	this.Text = "Add Mode";
	this.Load += new System.EventHandler(this.AddForm_Load);
	this.groupBox1.ResumeLayout(false);
	this.groupBox3.ResumeLayout(false);
	this.panel1.ResumeLayout(false);
	this.tabControl1.ResumeLayout(false);
	this.gridView1.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
	this.gridView2.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.materialsDataGrid)).EndInit();
	this.ResumeLayout(false);

}
#endregion

private
void AddForm_Load(object sender, System.EventArgs e){
	initializeItemsGrid();
	initializeMaterialsDataGrid();
}

private
void initializeItemsGrid(){
    dataTable = new DataTable();
    DataRow dataRow;

	dataTable.Columns.Add(new DataColumn("Mach", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Part", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Seq", typeof(decimal)));
	dataTable.Columns.Add(new DataColumn("Qty", typeof(decimal)));
	dataTable.Columns.Add(new DataColumn("Pos", typeof(decimal)));
	dataTable.Columns.Add(new DataColumn("Prod. Hours", typeof(decimal)));
	dataTable.Columns.Add(new DataColumn("Start", typeof(string)));
	dataTable.Columns.Add(new DataColumn("End", typeof(string)));		
	dataTable.Columns.Add(new DataColumn("Shift", typeof(string)));		
	dataTable.Columns.Add(new DataColumn("Prod. %", typeof(decimal)));
	dataTable.Columns.Add(new DataColumn("TimeType", typeof(string)));
	dataTable.Columns.Add(new DataColumn("OrdID", typeof(decimal)));
	dataTable.Columns.Add(new DataColumn("ItemID", typeof(decimal)));
	dataTable.Columns.Add(new DataColumn("RLID", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Dept", typeof(string)));

	string[][] vec = schedule.getSchPrMasStr();
	for(int x = 0; x < vec.Length; x++){
		dataRow = dataTable.NewRow();
 		dataRow[0] = vec[x][23]; // machine
		if (core.isFamilyPart(vec[x][2])) // family / part
			dataRow[1] = "Family";
		else
			dataRow[1] = "Part";

		dataRow[2] = vec[x][2]; // prod id
 		dataRow[3] = vec[x][4]; // seq
		dataRow[4] = decimal.Parse(vec[x][6]); // qty
 		dataRow[5] = decimal.Parse(vec[x][24]); // pos
 		dataRow[6] = decimal.Parse(vec[x][15]); // prod hours
 		dataRow[7] = vec[x][13]; // start date
 		dataRow[8] = vec[x][14]; // end date
		dataRow[9] = vec[x][25]; // shift
		dataRow[10] = decimal.Parse(vec[x][26]); // util percentage
		dataRow[11] = vec[x][27]; // time Type
		dataRow[12] = decimal.Parse(vec[x][28]);
		dataRow[13] = decimal.Parse(vec[x][29]);
		dataRow[14] = vec[x][30];
		dataRow[15] = vec[x][31];
		dataTable.Rows.Add(dataRow);
	}

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
	colStyle[0].Width      	= 60;
	colStyle[1].Width		= 60;
	colStyle[2].Width		= 80;
	colStyle[3].Width		= 60;
	colStyle[4].Width		= 60;
	colStyle[5].Width      	= 60;
	colStyle[6].Width		= 70;
	colStyle[7].Width		= 111;
	colStyle[8].Width		= 111;
	colStyle[9].Width		= 60;
	colStyle[10].Width		= 60;
	colStyle[11].Width		= 0;
	colStyle[12].Width		= 0;
	colStyle[13].Width		= 0;
	colStyle[14].Width		= 0;
	colStyle[15].Width		= 60;
	grid.Refresh();
}

private
string[][] getVec(){
	int i = 0;
	string[][] vec = new string[dataTable.Rows.Count][];
	for(IEnumerator e = dataTable.Rows.GetEnumerator(); e.MoveNext();){
		DataRow row = (DataRow)e.Current;

		string[] vec2 = new string[15];
		vec2[0] = row[0].ToString(); // machine
		vec2[1] = row[2].ToString(); // prod id
		vec2[2] = row[3].ToString(); // seq
		vec2[3] = row[4].ToString(); // qty
		vec2[4] = row[5].ToString(); // pos
		vec2[5] = row[6].ToString(); // prod hours
		vec2[6] = row[7].ToString(); // start date
		vec2[7] = row[8].ToString(); // end date
		vec2[8] = row[9].ToString(); // shift
		vec2[9] = row[10].ToString(); // util percentage
		vec2[10] = row[11].ToString(); // time type
		vec2[11] = row[12].ToString();
		vec2[12] = row[13].ToString();
		vec2[13] = row[14].ToString();
		vec2[14] = row[15].ToString(); // Dept
		vec[i] = vec2;
		i++;
	}
	return vec;
}

private
void reviewButton_Click(object sender, System.EventArgs e){
	// add code for reload objects here
	MessageBox.Show("reviewButton pressed");
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
void OkButton_Click(object sender, System.EventArgs e){
	if (!isDataOk())
		return;

	try{
		schedule.setSchVersion(version);

		string[][] vec = getVec();
		schedule.addAllItems(plant, vec);

		core.updateSchedule(schedule);
		
		this.DialogResult = DialogResult.OK;
	}catch(NujitException ne){
		FormException formException = new FormException(ne);
		formException.ShowDialog();
	}
	Close();
}

private 
void cancelButton_Click(object sender, System.EventArgs e){
	this.DialogResult = DialogResult.Cancel;

	Close();
}

private 
void addButton_Click(object sender, System.EventArgs e){
	try{
		EditItem edit = new EditItem(plant, schedule);
		edit.ShowDialog();
		if (edit.DialogResult == DialogResult.OK){
			string dept = edit.getDepartment();
			string mach = edit.getMachine();
			string part = edit.getPart();
			string seq = edit.getSeq();
			string qty = edit.getQty();
			string pos = edit.getPos();
			string sDateTime = edit.getStartDate();
			string eDateTime = edit.getEndDate();
			string prHr = edit.getProdHours();
			bool isFamilyPart = edit.getIsFamilyPart();
			
			string[][] vec = edit.getVecPackagingItems();
		
			addItemToGrid(dept, mach, part, seq, qty, pos, sDateTime, eDateTime, prHr, isFamilyPart, vec, false);
		}
	}catch(FormatException){
		MessageBox.Show("Please, fill all the fields in the form ","Error");
		addButton_Click(sender, e);
	}
}

/* OLD
private 
bool addItemToGrid(string mach, string part, string seq, string qty, string pos, string sDateTime,
			string eDateTime, string prHr, bool isFamilyPart, string[][] vecPackagingItems, bool quietly){
	bool returnValue = false;
	
	if (addOk(mach, sDateTime, eDateTime, pos, quietly)){
		if (pos.Equals("0"))
			pos = getMaxPos().ToString();
		
		DataRow dataRow = dataTable.NewRow();
 		dataRow[0] = mach;
		if (isFamilyPart)
			dataRow[1] = "Family";
		else
			dataRow[1] = "Part";
 		dataRow[2] = part;
 		dataRow[3] = decimal.Parse(seq);
 		dataRow[4] = decimal.Parse(qty);
 		dataRow[5] = decimal.Parse(pos);
 		dataRow[6] = decimal.Parse(prHr);
 		dataRow[7] = sDateTime;
 		dataRow[8] = eDateTime;

		dataTable.Rows.Add(dataRow);

		if (vecPackagingItems.Length != 0)
			schedule.addProdPackDtlItems(part, vecPackagingItems);
	}else{
		if (!quietly){
			DialogResult deleteConfirm = MessageBox.Show("Jobs will be readjusted to insert current Job", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (deleteConfirm == DialogResult.Yes){
				readjust(mach, part, seq, qty, pos, sDateTime,
					eDateTime, prHr);

				DialogResult optConfirm = MessageBox.Show("Jobs will be optimized", "Continue", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (optConfirm == DialogResult.Yes){
					optimizeTimes(mach);
				}
			}
		}else{
			returnValue = true;
		}
	}

	return returnValue;
}
*/

private 
bool addItemToGrid(string dept, string mach, string part, string seq, string qty, string pos, string sDateTime,
				string eDateTime, string prHr, bool isFamilyPart, string[][] vecPackagingItems, bool quietly){

	string[][] vec = getVec();
	ArrayList al = new ArrayList();
	DateTime endDate = DateUtil.parseCompleteDate(eDateTime,DateUtil.MMDDYYYY);
	DateTime datePos = DateUtil.parseCompleteDate(eDateTime,DateUtil.MMDDYYYY);
	DateTime versionStart = DateUtil.parseDate (this.startTextBox.Text, DateUtil.MMDDYYYY);

	decimal rate = decimal.Parse(qty) / decimal.Parse (prHr);
	decimal hoursToGo = decimal.Parse (prHr);

	for(int i = 0; i < vec.Length; i++)
	{
		if (vec[i][0].Equals(mach))
		{
			DateTime endCurrentDate = DateUtil.parseCompleteDate(vec[i][7],DateUtil.MMDDYYYY);
			DateTime startCurrentDate = DateUtil.parseCompleteDate(vec[i][6],DateUtil.MMDDYYYY);
			int ArrayPos = 1;
			while ((ArrayPos < al.Count) && (((DateTime)al[ArrayPos]).CompareTo(endCurrentDate) < 0))
				ArrayPos += 2;
			al.Insert (ArrayPos - 1, endCurrentDate);
			al.Insert (ArrayPos - 1, startCurrentDate);
		}
	}

	Capacity capacity = core.readCapacity (version, plant, dept, mach);
	capacity.sort();
	string[][] capacityHours = capacity.getAllHoursAsString();

	int arrayPos = al.Count - 2;
	int capPos = capacityHours.Length - 1;

	while ((datePos.CompareTo(versionStart) > 0) && (hoursToGo > 0) && (capPos >= 0))
	{
		bool canInsert = false;
		while (!canInsert && (capPos >= 0))
		{
			while ((arrayPos >= 0) && (((DateTime)al[arrayPos]).CompareTo(datePos) >= 0))
				arrayPos -= 2;
			if ((arrayPos >= 0) && (((DateTime)al[arrayPos + 1]).CompareTo(datePos) >= 0))
				datePos = (DateTime)al[arrayPos];
			else{
				DateTime currCapacityStart = DateTime.MinValue;
				if (capPos >= 0) {
					int hours = int.Parse(capacityHours[capPos][5].Substring(0,2));
					int minutes = int.Parse(capacityHours[capPos][5].Substring(3,2));
					currCapacityStart = DateUtil.parseDate(capacityHours[capPos][1],DateUtil.MMDDYYYY).AddHours(hours).AddMinutes(minutes);
				}
				while ((capPos >= 0) && (currCapacityStart.CompareTo (datePos) >= 0))
				{
					capPos --;
					int hours = int.Parse(capacityHours[capPos][5].Substring(0,2));
					int minutes = int.Parse(capacityHours[capPos][5].Substring(3,2));
					currCapacityStart = DateUtil.parseDate(capacityHours[capPos][1],DateUtil.MMDDYYYY).AddHours(hours).AddMinutes(minutes);
				}
				int auxHours = int.Parse(capacityHours[capPos][6].Substring(0,2));
				int auxMinutes = int.Parse(capacityHours[capPos][6].Substring(3,2));
				DateTime currCapacityEnd = DateUtil.parseDate(capacityHours[capPos][1],DateUtil.MMDDYYYY).AddHours(auxHours).AddMinutes(auxMinutes);
				if (datePos.CompareTo(currCapacityEnd) > 0)
					datePos = currCapacityEnd;
				else
					canInsert = true;
			}
		}
		if (capPos >= 0)
		{
			int auxHours2 = int.Parse(capacityHours[capPos][5].Substring(0,2));
			int auxMinutes2 = int.Parse(capacityHours[capPos][5].Substring(3,2));
			DateTime capacityStart = DateUtil.parseDate(capacityHours[capPos][1],DateUtil.MMDDYYYY).AddHours(auxHours2).AddMinutes(auxMinutes2);
			DateTime taskEnd = DateTime.MinValue;
			if (arrayPos >= 0)
				taskEnd = (DateTime)al[arrayPos + 1];
			DateTime newTaskStart = DateTime.MinValue;
			if (capacityStart.CompareTo(taskEnd) > 0)
				newTaskStart = capacityStart;
			else
				newTaskStart = taskEnd;

			TimeSpan ts = datePos.Subtract(newTaskStart);
			decimal totalRealHours = (decimal)ts.Hours;
			totalRealHours += (decimal)ts.Minutes / 60M;
			totalRealHours += (decimal)ts.Seconds / 3600M;
			decimal perc = decimal.Parse(capacityHours[capPos][12]);

			if (perc > 0) 
			{

				decimal totalProdHours = (totalRealHours * perc) / 100M;

				if (totalProdHours > hoursToGo)
				{
					totalProdHours = hoursToGo;
					totalRealHours = (totalProdHours * 100M) / perc;
					hoursToGo = totalRealHours;
					double hoursToGoHours = Math.Floor((double)hoursToGo);
					hoursToGo -= (decimal)hoursToGoHours;
					double hoursToGoMinutes = Math.Floor((double)hoursToGo * 60);
					hoursToGo -= (decimal)hoursToGoMinutes / 60M;
					double hoursToGoSeconds = Math.Floor((double)hoursToGo * 3600);
					hoursToGo = 0;
					newTaskStart = datePos.Subtract (new TimeSpan ((int)hoursToGoHours, (int)hoursToGoMinutes, (int)hoursToGoSeconds));
				}
				else
					hoursToGo = hoursToGo - totalProdHours;

				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = mach;
				if (isFamilyPart)
					dataRow[1] = "Family";
				else
					dataRow[1] = "Part";

				dataRow[2] = part;
				dataRow[3] = decimal.Parse(seq);
				dataRow[4] = rate * totalProdHours;
				dataRow[5] = decimal.Parse(pos);
				dataRow[6] = totalRealHours;
				dataRow[7] = DateUtil.getCompleteDateRepresentation (newTaskStart, DateUtil.MMDDYYYY);
				dataRow[8] = DateUtil.getCompleteDateRepresentation (datePos, DateUtil.MMDDYYYY);
				dataRow[9] = capacityHours[capPos][2];
				dataRow[10] = decimal.Parse(capacityHours[capPos][12]);
				dataRow[11] = capacityHours[capPos][3];
				dataRow[12] = 0;
				dataRow[13] = 0;
				dataRow[14] = "";
	
				dataTable.Rows.Add(dataRow);

			}		
			datePos = newTaskStart;
		}
	}

	return true;

}

private
bool addOk(string mach, string sDateTime, string eDateTime, string pos, bool quietly){
	string[][] vec = getVec();
	for(int i = 0; i < vec.Length; i++){
 		if (vec[i][0].Equals(mach)){
			decimal actualPosition = decimal.Parse(vec[i][4]);
			decimal tentativePosition = decimal.Parse(pos);

			if (actualPosition == tentativePosition){
				if (!quietly)
					MessageBox.Show("The machine : " + mach + " is busy for this position");
				return false;
			}
			
			DateTime startJob = DateUtil.parseCompleteDate(vec[i][6], DateUtil.MMDDYYYY);
			DateTime endJob = DateUtil.parseCompleteDate(vec[i][7], DateUtil.MMDDYYYY);

			DateTime tentativeStartJob = DateUtil.parseCompleteDate(sDateTime, DateUtil.MMDDYYYY);
			DateTime tentativeEndJob = DateUtil.parseCompleteDate(eDateTime, DateUtil.MMDDYYYY);

			// the tentative or new start date of a job is
			// between two dates of an old job
			if ((startJob.CompareTo(tentativeStartJob) <= 0) &&
				(endJob.CompareTo(tentativeStartJob) >= 0)){

				if (!quietly)
					MessageBox.Show("The machine : " + mach + " is busy for that dates");
				return false;
			}

			// the tentative or new end date of job is
			// between two dates of an old job
			if ((startJob.CompareTo(tentativeEndJob) <= 0) &&
				(endJob.CompareTo(tentativeEndJob) >= 0)){
				
				if (!quietly)
					MessageBox.Show("The machine : " + mach + " is busy for that dates");
				return false;
			}
		}
	}
	return true;
}

private 
void editButton_Click(object sender, System.EventArgs e){
	if (dataTable.Rows.Count > 0){
		string mach = getCurrentValue(0);
		bool isFam = (getCurrentValue(1) == "Family");
		string part = getCurrentValue(2);
		string seq = getCurrentValue(3);
		string qty = getCurrentValue(4);
		string pos = getCurrentValue(5);
		string hrPr = getCurrentValue(6);
		string start = getCurrentValue(7);
		string end = getCurrentValue(8);

		EditItem edit = new EditItem(plant, mach, part, seq, qty, pos, hrPr, start, end, this.schedule, isFam);
		edit.ShowDialog();
		if (edit.DialogResult == DialogResult.OK){
			mach = edit.getMachine();
			part = edit.getPart();
			seq = edit.getSeq();
			qty = edit.getQty();
			pos = edit.getPos();
			hrPr = edit.getProdHours();
			start = edit.getStartDate();
			end = edit.getEndDate();

			setCurrentValue(mach, 0);
			setCurrentValue(part, 2);
			setCurrentValue(seq, 3);
			setCurrentValue(qty, 4);
			setCurrentValue(pos, 5);
			setCurrentValue(hrPr, 6);
			setCurrentValue(start, 7);
			setCurrentValue(end, 8);

			string[][] vec = edit.getVecPackagingItems();
			schedule.addProdPackDtlItems(part, vec);
		}
	}else{
		MessageBox.Show("There is no record to edit");
	}
}

private 
void removeButton_Click(object sender, System.EventArgs e){
	if (dataTable.Rows.Count > 0){
		DialogResult deleteConfirm = MessageBox.Show("Remove this item ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (deleteConfirm == DialogResult.No)
			return;

		int rowNumber = grid.CurrentCell.RowNumber;
		dataTable.Rows.RemoveAt(rowNumber);
	}else{
		MessageBox.Show("There are no records to delete");
	}
}

private
void initializeMaterialsDataGrid(){
    materialsDataTable = new DataTable();

	materialsDataTable.Columns.Add(new DataColumn("QOH", typeof(string)));
	materialsDataTable.Columns.Add(new DataColumn("Past Due", typeof(string)));
	materialsDataTable.Columns.Add(new DataColumn("Day 1", typeof(string)));
	materialsDataTable.Columns.Add(new DataColumn("Day 2", typeof(string)));
	materialsDataTable.Columns.Add(new DataColumn("Day 3", typeof(string)));
	materialsDataTable.Columns.Add(new DataColumn("Day 4", typeof(string)));
	materialsDataTable.Columns.Add(new DataColumn("Day 5", typeof(string)));
	materialsDataTable.Columns.Add(new DataColumn("Day 6", typeof(string)));
	materialsDataTable.Columns.Add(new DataColumn("Day 7", typeof(string)));

	DataView dataView = new DataView(materialsDataTable);
	dataView.AllowEdit = false;
	dataView.AllowDelete = false;
	dataView.AllowNew = false;
	
	materialsDataGrid.DataSource = dataView;
	materialsDataGrid.DataSource = dataView;
	materialsDataGrid.PreferredColumnWidth = 150;
	materialsDataGrid.RowHeadersVisible = false;

	//Create a DataGridTableStyle object	
	DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();
	//Set its properties
	dgdtblStyle.MappingName			= materialsDataTable.TableName;//its table name of dataset
	materialsDataGrid.TableStyles.Clear(); 
	materialsDataGrid.TableStyles.Add(dgdtblStyle);
	dgdtblStyle.RowHeadersVisible	= true;
	dgdtblStyle.AllowSorting		= true;
	dgdtblStyle.PreferredRowHeight	= 22;
	GridColumnStylesCollection	colStyle;
	colStyle				= materialsDataGrid.TableStyles[0].GridColumnStyles;		
	colStyle[0].Width      	= 73;
	colStyle[1].Width		= 75;
	colStyle[2].Width		= 75;
	colStyle[3].Width		= 75;
	colStyle[4].Width      	= 75;
	colStyle[5].Width		= 75;
	colStyle[6].Width		= 75;
	colStyle[7].Width		= 75;
	colStyle[8].Width		= 75;
	materialsDataGrid.Refresh();
}

private
void reNumerate(string machine, decimal from){
	for(IEnumerator e = dataTable.Rows.GetEnumerator(); e.MoveNext();){
		DataRow row = (DataRow)e.Current;

		string mach = row[0].ToString();
		decimal currentPos = decimal.Parse(row[4].ToString());

		if ((mach.Equals(machine)) && (currentPos > from)){
			currentPos++;
			row[4] = currentPos;
		}
	}
}

private 
void readjust(string mach, string part, string seq, string qty, 
		string pos, string sDateTime, string eDateTime, string prHr){

	int index = 0;
	string[][] vec = getVec();
	string[][] newVec = new string[vec.Length + 1][];

	for(int i = 0; i < vec.Length; i++){
 		if (vec[i][0].Equals(mach)){
			DateTime startJob = DateUtil.parseCompleteDate(vec[i][6], DateUtil.MMDDYYYY);
			DateTime endJob = DateUtil.parseCompleteDate(vec[i][7], DateUtil.MMDDYYYY);
			decimal actualPos = decimal.Parse(vec[i][4]);

			DateTime tentativeStartJob = DateTime.Today;
			DateTime tentativeEndJob = DateTime.Today;
			decimal tentativePos = decimal.Parse(pos);

			if (tentativePos == actualPos){
				string[] vec4 = new string[8];
				vec4[0] = mach;
				vec4[1] = part;
				vec4[2] = seq;
				vec4[3] = qty;
				vec4[4] = pos;
				vec4[5] = prHr;
				vec4[6] = sDateTime;
				vec4[7] = eDateTime;
				newVec[index] = vec4;
				index++;

				// shift jobs
				DateTime wDate = DateUtil.parseCompleteDate(eDateTime, DateUtil.MMDDYYYY);
				for(int x = i; x < vec.Length; x++){
					DateTime wStartJob = DateUtil.parseCompleteDate(vec[x][6], DateUtil.MMDDYYYY);
					DateTime wEndJob = DateUtil.parseCompleteDate(vec[x][7], DateUtil.MMDDYYYY);
					double wHrPr = double.Parse(vec[x][5]);
				
					if (wDate.CompareTo(wStartJob) > 0){ // have to recalculate
						wStartJob = wDate.AddSeconds(1);
						wEndJob = wStartJob.AddHours(wHrPr);

						decimal posToChange = decimal.Parse(vec[x][4]);
						posToChange++;
						vec[x][4] = posToChange.ToString();
						vec[x][6] = DateUtil.getCompleteDateRepresentation(wStartJob, DateUtil.MMDDYYYY);
						vec[x][7] = DateUtil.getCompleteDateRepresentation(wEndJob, DateUtil.MMDDYYYY);
						
						wDate = wEndJob;
					}
				}
//						continue;
			}else{
				tentativeStartJob = DateUtil.parseCompleteDate(sDateTime, DateUtil.MMDDYYYY);
				tentativeEndJob = DateUtil.parseCompleteDate(eDateTime, DateUtil.MMDDYYYY);

				// the tentative or new start date of a job is
				// between two dates of an old job
				// have to move this old job
				if ((startJob.CompareTo(tentativeStartJob) <= 0) &&
					(endJob.CompareTo(tentativeStartJob) >= 0)){

					string[] vec1 = new string[8];
					vec1[0] = mach;
					vec1[1] = part;
					vec1[2] = seq;
					vec1[3] = qty;
					vec1[4] = pos;
					vec1[5] = prHr;
					vec1[6] = sDateTime;
					vec1[7] = eDateTime;
					newVec[index] = vec1;
					index++;

					// shift jobs
					DateTime wDate = DateUtil.parseCompleteDate(eDateTime, DateUtil.MMDDYYYY);
					for(int x = i; x < vec.Length; x++){
						DateTime wStartJob = DateUtil.parseCompleteDate(vec[x][6], DateUtil.MMDDYYYY);
						DateTime wEndJob = DateUtil.parseCompleteDate(vec[x][7], DateUtil.MMDDYYYY);
						double wHrPr = double.Parse(vec[x][5]);
					
						if (wDate.CompareTo(wStartJob) > 0){ // have to recalculate
							wStartJob = wDate.AddSeconds(1);
							wEndJob = wStartJob.AddHours(wHrPr);

							vec[x][6] = DateUtil.getCompleteDateRepresentation(wStartJob, DateUtil.MMDDYYYY);
							vec[x][7] = DateUtil.getCompleteDateRepresentation(wEndJob, DateUtil.MMDDYYYY);
							
							wDate = wEndJob;
						}
					}
				}else{
					// the tentative or new end date of job is
					// between two dates of an old job
					// have to move this old job
					if ((startJob.CompareTo(tentativeEndJob) <= 0) &&
						(endJob.CompareTo(tentativeEndJob) >= 0)){
// aca es donde hay que meter el mio y correr todo hacia adelante

						string[] vec2 = new string[8];
						vec2[0] = mach;
						vec2[1] = part;
						vec2[2] = seq;
						vec2[3] = qty;
						vec2[4] = pos;
						vec2[5] = prHr;
						vec2[6] = sDateTime;
						vec2[7] = eDateTime;
						newVec[index] = vec2;
						index++;

					
						// shift jobs
						DateTime wDate = DateUtil.parseCompleteDate(eDateTime, DateUtil.MMDDYYYY);
						for(int x = i; x < vec.Length; x++){
							DateTime wStartJob = DateUtil.parseCompleteDate(vec[x][6], DateUtil.MMDDYYYY);
							DateTime wEndJob = DateUtil.parseCompleteDate(vec[x][7], DateUtil.MMDDYYYY);
							double wHrPr = double.Parse(vec[x][5]);
						
							if (wDate.CompareTo(wStartJob) > 0){ // have to recalculate
								wStartJob = wDate.AddSeconds(1);
								wEndJob = wStartJob.AddHours(wHrPr);

								vec[x][6] = DateUtil.getCompleteDateRepresentation(wStartJob, DateUtil.MMDDYYYY);
								vec[x][7] = DateUtil.getCompleteDateRepresentation(wEndJob, DateUtil.MMDDYYYY);
								
								wDate = wEndJob;
							}
						}
					}
				}
			}
		}
		
		string[] vec3 = new string[8];
		vec3[0] = vec[i][0];
		vec3[1] = vec[i][1];
		vec3[2] = vec[i][2];
		vec3[3] = vec[i][3];
		vec3[4] = vec[i][4];
		vec3[5] = vec[i][5];
		vec3[6] = vec[i][6];
		vec3[7] = vec[i][7];
		newVec[index] = vec3;
		index++;
	}

	dataTable.Rows.Clear();
	for(int i = 0; i < newVec.Length; i++){
		DataRow dataRow = dataTable.NewRow();
 		dataRow[0] = newVec[i][0];

		if (core.isFamilyPart(newVec[i][1]))
			dataRow[1] = "Family";
		else
			dataRow[1] = "Part";

 		dataRow[2] = newVec[i][1];
 		dataRow[3] = decimal.Parse(newVec[i][2]);
 		dataRow[4] = decimal.Parse(newVec[i][3]);
 		dataRow[5] = decimal.Parse(newVec[i][4]);
 		dataRow[6] = decimal.Parse(newVec[i][5]);
 		dataRow[7] = newVec[i][6];
 		dataRow[8] = newVec[i][7];
		dataTable.Rows.Add(dataRow);
	}		
} // method

private
void optimizeTimes(string mach){
	int index = 0;
	int num = 0;
	string[][] vec = getVec();
	string[][] newVec = new string[vec.Length][];
	bool renum = false;

	for(int i = 0; i < vec.Length; i++){
 		if (vec[i][0].Equals(mach)){
			DateTime startJob = DateUtil.parseCompleteDate(vec[i][6], DateUtil.MMDDYYYY);
			DateTime endJob = DateUtil.parseCompleteDate(vec[i][7], DateUtil.MMDDYYYY);

			// shift jobs
			DateTime wDate = endJob;
			for(int x = i; x < vec.Length; x++){
 				if (vec[x][0].Equals(mach)){
					DateTime wStartJob = DateUtil.parseCompleteDate(vec[x][6], DateUtil.MMDDYYYY);
					DateTime wEndJob = DateUtil.parseCompleteDate(vec[x][7], DateUtil.MMDDYYYY);
					double wHrPr = double.Parse(vec[x][5]);
				
					if (i != x){
						wStartJob = wDate.AddSeconds(1);
						wEndJob = wStartJob.AddHours(wHrPr);

						vec[x][6] = DateUtil.getCompleteDateRepresentation(wStartJob, DateUtil.MMDDYYYY);
						vec[x][7] = DateUtil.getCompleteDateRepresentation(wEndJob, DateUtil.MMDDYYYY);
					}

					if (!renum){
						num++;
						vec[x][4] = num.ToString();
					}
					
					wDate = wEndJob;
				}
			}
			renum = true;
		}

		string[] vec3 = new string[8];
		vec3[0] = vec[i][0];
		vec3[1] = vec[i][1];
		vec3[2] = vec[i][2];
		vec3[3] = vec[i][3];
		vec3[4] = vec[i][4];
		vec3[5] = vec[i][5];
		vec3[6] = vec[i][6];
		vec3[7] = vec[i][7];
		newVec[index] = vec3;
		index++;
	}

	dataTable.Rows.Clear();
	for(int i = 0; i < newVec.Length; i++){
		DataRow dataRow = dataTable.NewRow();
 		dataRow[0] = newVec[i][0];

		if (core.isFamilyPart(newVec[i][1]))
			dataRow[1] = "Family";
		else
			dataRow[1] = "Part";

 		dataRow[2] = newVec[i][1];
 		dataRow[3] = decimal.Parse(newVec[i][2]);
 		dataRow[4] = decimal.Parse(newVec[i][3]);
 		dataRow[5] = decimal.Parse(newVec[i][4]);
 		dataRow[6] = decimal.Parse(newVec[i][5]);
 		dataRow[7] = newVec[i][6];
 		dataRow[8] = newVec[i][7];
		dataTable.Rows.Add(dataRow);
	}		
}

private
bool isDataOk(){
	if ((pltTextBox.Text == null) || (pltTextBox.Text.Equals(""))){
		MessageBox.Show("The Plant field is empty");
		return false;
	}
	if ((startTextBox.Text == null) || (startTextBox.Text.Equals(""))){
		MessageBox.Show("The Start field is empty");
		return false;
	}
	if ((endTextBox.Text == null) || (endTextBox.Text.Equals(""))){
		MessageBox.Show("The End field is empty");
		return false;
	}
	return true;
}

private
string getMaxPos(){
	int i = 0;
	decimal maxPos = 0;
	string[][] vec = new string[dataTable.Rows.Count][];
	for(IEnumerator e = dataTable.Rows.GetEnumerator(); e.MoveNext();){
		DataRow row = (DataRow)e.Current;

		decimal currentPos = decimal.Parse(row[4].ToString());
		if (currentPos > maxPos)
			maxPos = currentPos;
		i++;
	}
	return maxPos.ToString();
}

private 
void grid_Click(object sender, System.EventArgs e){
	grid.PreferredRowHeight = 10;

	DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();
    
	dgdtblStyle = grid.TableStyles[0];
	dgdtblStyle.PreferredRowHeight = 10;
}

private 
void materialsDataGrid_Click(object sender, System.EventArgs e){
	materialsDataGrid.PreferredRowHeight = 10;

	DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();
    
	dgdtblStyle = materialsDataGrid.TableStyles[0];
	dgdtblStyle.PreferredRowHeight = 10;
}

private 
void hotListButton_Click(object sender, System.EventArgs e){

	model.setTimeScope (new DateTime(2005,4,10), new DateTime(2005,4,20));

//	Thread thread = new Thread(new ThreadStart(model.insertTasksFromDemand));
//	thread.Start();

	model.insertTasksFromDemand();
	fillGridFromModel();
}

private void fillGridFromModel()
{
	dataTable.Rows.Clear();
	ArrayList al = model.getTasksAddedFromDemandAsString();
	IEnumerator enu = al.GetEnumerator();
	while (enu.MoveNext())
	{
		object[] item = (object[])enu.Current;

		DataRow dataRow = dataTable.NewRow();
		dataRow[0] = (string)item[0];
		dataRow[1] = (string)item[1];
		dataRow[2] = (string)item[2];
		dataRow[3] = decimal.Parse((string)item[3]);
		dataRow[4] = (decimal)item[4];
		dataRow[5] = (decimal)item[5];
		dataRow[6] = (decimal)item[6];
		dataRow[7] = (string)item[7];
		dataRow[8] = (string)item[8];
		dataRow[9] = (string)item[9];
		dataRow[10] = (decimal)item[10];
		dataRow[11] = (string)item[11];
		dataRow[12] = (decimal)item[12];
		dataRow[13] = (decimal)item[13];
		dataRow[14] = (string)item[14];
		dataRow[15] = (string)item[15];

		dataTable.Rows.Add(dataRow);
	}

	SchQohAssignation schQohAssignation = model.getSchQohAssigations();
	core.updateSchQohAssignation (schQohAssignation);
}

private void removeAllButton_Click(object sender, System.EventArgs e)
{
	dataTable.Rows.Clear();
}

public ScheduleModel getModel()
{
	return model;
}


} // class

} // namespace
