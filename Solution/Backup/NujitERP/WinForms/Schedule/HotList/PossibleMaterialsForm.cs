using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Utility;

using GridScheduling.gui;

using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.WinForms.Reports.MaterialsReport;
using Nujit.NujitERP.WinForms.SearchForms;
using Nujit.NujitERP.ClassLib.Reports.UtilReports;

namespace Nujit.NujitERP.WinForms.Schedule.HotList{

/// <summary>
/// Summary description for AddForm.
/// </summary>
public
class PossibleMaterialsForm : System.Windows.Forms.Form{


private System.Windows.Forms.GroupBox groupBox3;

private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private System.Windows.Forms.DataGrid grid;
private DataTable dataTable;
private DataView dataView;
private System.Windows.Forms.Button closeButton;
private System.Windows.Forms.Button btnShow;
private System.Windows.Forms.TextBox prodTextBox;
private System.Windows.Forms.TextBox prodDescTextBox;
private System.Windows.Forms.Button prodSeekButton;
private System.Windows.Forms.Button refreshButton;
private System.Windows.Forms.ComboBox seqComboBox;
private System.Windows.Forms.Label label1;
private System.Windows.Forms.Label label2;
private MaterialBomContainer materialBomContainer = null;
private System.Windows.Forms.Label label3;
private System.Windows.Forms.TextBox possibleTextBox;

/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;


public
PossibleMaterialsForm(){
	InitializeComponent();

	prodTextBox.Focus();
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
	this.possibleTextBox = new System.Windows.Forms.TextBox();
	this.label3 = new System.Windows.Forms.Label();
	this.label2 = new System.Windows.Forms.Label();
	this.label1 = new System.Windows.Forms.Label();
	this.seqComboBox = new System.Windows.Forms.ComboBox();
	this.refreshButton = new System.Windows.Forms.Button();
	this.prodSeekButton = new System.Windows.Forms.Button();
	this.prodDescTextBox = new System.Windows.Forms.TextBox();
	this.prodTextBox = new System.Windows.Forms.TextBox();
	this.grid = new System.Windows.Forms.DataGrid();
	this.closeButton = new System.Windows.Forms.Button();
	this.btnShow = new System.Windows.Forms.Button();
	this.groupBox3.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
	this.SuspendLayout();
	// 
	// groupBox3
	// 
	this.groupBox3.Controls.Add(this.possibleTextBox);
	this.groupBox3.Controls.Add(this.label3);
	this.groupBox3.Controls.Add(this.label2);
	this.groupBox3.Controls.Add(this.label1);
	this.groupBox3.Controls.Add(this.seqComboBox);
	this.groupBox3.Controls.Add(this.refreshButton);
	this.groupBox3.Controls.Add(this.prodSeekButton);
	this.groupBox3.Controls.Add(this.prodDescTextBox);
	this.groupBox3.Controls.Add(this.prodTextBox);
	this.groupBox3.Controls.Add(this.grid);
	this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
	this.groupBox3.Location = new System.Drawing.Point(16, 16);
	this.groupBox3.Name = "groupBox3";
	this.groupBox3.Size = new System.Drawing.Size(840, 352);
	this.groupBox3.TabIndex = 39;
	this.groupBox3.TabStop = false;
	// 
	// possibleTextBox
	// 
	this.possibleTextBox.Location = new System.Drawing.Point(128, 84);
	this.possibleTextBox.Name = "possibleTextBox";
	this.possibleTextBox.ReadOnly = true;
	this.possibleTextBox.TabIndex = 10;
	this.possibleTextBox.Text = "";
	// 
	// label3
	// 
	this.label3.Location = new System.Drawing.Point(24, 88);
	this.label3.Name = "label3";
	this.label3.Size = new System.Drawing.Size(100, 16);
	this.label3.TabIndex = 8;
	this.label3.Text = "# of Possible Parts";
	// 
	// label2
	// 
	this.label2.Location = new System.Drawing.Point(24, 60);
	this.label2.Name = "label2";
	this.label2.Size = new System.Drawing.Size(100, 16);
	this.label2.TabIndex = 7;
	this.label2.Text = "Sequence";
	// 
	// label1
	// 
	this.label1.Location = new System.Drawing.Point(24, 28);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(100, 16);
	this.label1.TabIndex = 6;
	this.label1.Text = "Product";
	// 
	// seqComboBox
	// 
	this.seqComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	this.seqComboBox.Location = new System.Drawing.Point(128, 56);
	this.seqComboBox.Name = "seqComboBox";
	this.seqComboBox.Size = new System.Drawing.Size(121, 21);
	this.seqComboBox.TabIndex = 2;
	// 
	// refreshButton
	// 
	this.refreshButton.Location = new System.Drawing.Point(752, 88);
	this.refreshButton.Name = "refreshButton";
	this.refreshButton.TabIndex = 3;
	this.refreshButton.Text = "Refresh";
	this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
	// 
	// prodSeekButton
	// 
	this.prodSeekButton.Location = new System.Drawing.Point(280, 28);
	this.prodSeekButton.Name = "prodSeekButton";
	this.prodSeekButton.Size = new System.Drawing.Size(32, 16);
	this.prodSeekButton.TabIndex = 1;
	this.prodSeekButton.Text = "...";
	this.prodSeekButton.Click += new System.EventHandler(this.prodSeekButton_Click);
	// 
	// prodDescTextBox
	// 
	this.prodDescTextBox.Location = new System.Drawing.Point(320, 24);
	this.prodDescTextBox.Name = "prodDescTextBox";
	this.prodDescTextBox.ReadOnly = true;
	this.prodDescTextBox.Size = new System.Drawing.Size(392, 20);
	this.prodDescTextBox.TabIndex = 10;
	this.prodDescTextBox.Text = "";
	// 
	// prodTextBox
	// 
	this.prodTextBox.Location = new System.Drawing.Point(128, 24);
	this.prodTextBox.Name = "prodTextBox";
	this.prodTextBox.Size = new System.Drawing.Size(144, 20);
	this.prodTextBox.TabIndex = 0;
	this.prodTextBox.Text = "";
	this.prodTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.prodTextBox_KeyDown);
	// 
	// grid
	// 
	this.grid.AllowSorting = false;
	this.grid.DataMember = "";
	this.grid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
	this.grid.Location = new System.Drawing.Point(8, 120);
	this.grid.Name = "grid";
	this.grid.ReadOnly = true;
	this.grid.Size = new System.Drawing.Size(824, 224);
	this.grid.TabIndex = 4;
	this.grid.Click += new System.EventHandler(this.grid_Click);
	// 
	// closeButton
	// 
	this.closeButton.Location = new System.Drawing.Point(768, 392);
	this.closeButton.Name = "closeButton";
	this.closeButton.TabIndex = 6;
	this.closeButton.Text = "Close";
	this.closeButton.Click += new System.EventHandler(this.closeButton_Click_1);
	// 
	// btnShow
	// 
	this.btnShow.Location = new System.Drawing.Point(688, 392);
	this.btnShow.Name = "btnShow";
	this.btnShow.TabIndex = 5;
	this.btnShow.Text = "Report";
	this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
	// 
	// PossibleMaterialsForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(874, 424);
	this.Controls.Add(this.groupBox3);
	this.Controls.Add(this.closeButton);
	this.Controls.Add(this.btnShow);
	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
	this.MaximizeBox = false;
	this.Name = "PossibleMaterialsForm";
	this.Text = "Materials";
	this.Closing += new System.ComponentModel.CancelEventHandler(this.MaterialsForm_Closing);
	this.Load += new System.EventHandler(this.AddForm_Load);
	this.groupBox3.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
	this.ResumeLayout(false);

}
#endregion

private
void AddForm_Load(object sender, System.EventArgs e){
	initializeItemsGrid();
}

private
void initializeItemsGrid(){
	dataTable = new DataTable();

	dataTable.Columns.Add(new DataColumn("Departament", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Part", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Sequence", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Qty Rel", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Qoh", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
}

private 
void refreshItems(){
	initializeItemsGrid();
    DataRow dataRow;

	for(int x = 0; x < materialBomContainer.Count; x++){
		MaterialBom materialBom = (MaterialBom)materialBomContainer[x];

		dataRow = dataTable.NewRow();
 		dataRow[0] = materialBom.getDept();
		dataRow[1] = materialBom.getProdId();
		dataRow[2] = materialBom.getSeq().ToString();
 		dataRow[3] = decimal.Round(materialBom.getQty(), 4).ToString();
		dataRow[4] = decimal.Round(materialBom.getQoh(), 4).ToString();
 		
		if (materialBom.getProdType().Equals("P"))
 			dataRow[5] = "Purchased";
		else
 			dataRow[5] = "Manufactured";

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
	colStyle[0].Width      	= 80; 
	colStyle[1].Width		= 160;
	colStyle[2].Width		= 80;
	colStyle[3].Width		= 190;
	colStyle[4].Width		= 190;
	colStyle[5].Width      	= 100;

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
	this.coreFactory = null;
	Close();
}


private 
void allocatedCheckBox_Click(object sender, System.EventArgs e){
	initializeItemsGrid();
}

private 
DataSet generateDataSetReport(){
	this.Cursor = Cursors.WaitCursor;
	
	DataTable dataTable = new DataTable();

	dataTable.TableName = "materials";
	dataTable.Columns.Add(new DataColumn("Dept", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Part", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Sequence", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Qty", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Qoh", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Type", typeof(string)));

	for(int i = 0; i < materialBomContainer.Count; i++){
		MaterialBom materialBom = (MaterialBom)materialBomContainer[i];

		DataRow dataRow;
		dataRow = dataTable.NewRow();

		dataRow = dataTable.NewRow();
 		dataRow[0] = materialBom.getDept();
		dataRow[1] = materialBom.getProdId();
		dataRow[2] = materialBom.getSeq().ToString();
 		dataRow[3] = materialBom.getQty().ToString();
		dataRow[4] = materialBom.getQoh().ToString();
 		
		if (materialBom.getProdType().Equals("P"))
 			dataRow[5] = "Purchased";
		else
 			dataRow[5] = "Manufactured";

		dataTable.Rows.Add(dataRow);
	}

	DataSet materialsDataSet = new DataSet();
	materialsDataSet.Tables.Add(dataTable);

	this.Cursor = Cursors.Default;

	return materialsDataSet;
}

private 
void btnShow_Click(object sender, System.EventArgs e){
	if (materialBomContainer == null || materialBomContainer.Count == 0){
		MessageBox.Show("Nothing to report !!");
		return;
	}

	DataSet ds = generateDataSetReport();

	Nujit.NujitERP.WinForms.Reports.PossibleMaterials.PosMaterialsReport posMaterialsReport = 
		new Nujit.NujitERP.WinForms.Reports.PossibleMaterials.PosMaterialsReport(this.prodTextBox.Text,int.Parse((string)seqComboBox.SelectedItem),materialBomContainer.getPossible(), ds);
	posMaterialsReport.ShowDialog();
}

private 
void MaterialsForm_Closing(object sender, System.ComponentModel.CancelEventArgs e){
	this.coreFactory = null;
}

private 
void prodSeekButton_Click(object sender, System.EventArgs e){
	ProductSearchForm productSearchForm = new ProductSearchForm("Product search",this.prodTextBox.Text.Trim(),true);
	productSearchForm.ShowDialog();

	if (productSearchForm.DialogResult == DialogResult.OK){
		string[] v = productSearchForm.getSelected();
		prodTextBox.Text = v[0];
		prodDescTextBox.Text = v[1];

		this.seqComboBox.Items.Clear();
		string[] seqs = coreFactory.getValidsSeqsForProduct(v[0]);
		for(int i = 0; i < seqs.Length; i++)
			this.seqComboBox.Items.Add(seqs[i]);
	}
}

private 
void refreshButton_Click(object sender, System.EventArgs e){
	refreshGrid();
}
	
private 
void refreshGrid(){
	if (!prodTextBox.Text.Equals("")){
		if (seqComboBox.Items.Count != 0){
			if (seqComboBox.SelectedIndex != -1){
				this.materialBomContainer = 
					coreFactory.generateMaterialListRecursive(prodTextBox.Text, int.Parse((string)seqComboBox.SelectedItem));
				possibleTextBox.Text = decimal.Round(materialBomContainer.getPossible(), 3).ToString();
				refreshItems();
			}else{
				MessageBox.Show("You have to select a sequence first !!");
				return;
			}
		}
	}else{
		MessageBox.Show("You have to select a product first !!");
		return;
	}
}

private 
void prodTextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e){
	if (e.KeyCode.ToString().Equals("Enter")){
		if (!coreFactory.existsProduct(prodTextBox.Text)){
			MessageBox.Show("The product doesn't exists !!");
			return;
		}

		Product product = coreFactory.readProduct(prodTextBox.Text);
		prodDescTextBox.Text = product.getDes1();

		this.seqComboBox.Items.Clear();
		string[] seqs = coreFactory.getValidsSeqsForProduct(prodTextBox.Text);
		for(int i = 0; i < seqs.Length; i++)
			this.seqComboBox.Items.Add(seqs[i]);
		if (this.seqComboBox.Items.Count > 0){
			this.seqComboBox.SelectedIndex = 0;
			refreshGrid();
		}

	}
}








} // class

} // namespace
