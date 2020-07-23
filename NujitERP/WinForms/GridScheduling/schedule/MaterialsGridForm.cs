using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Common;

namespace GridScheduling.gui.schedule{

/// <summary>
/// Summary description for MaterialsGridForm.
/// </summary>
public 
class MaterialsGridForm : System.Windows.Forms.Form{

private System.Windows.Forms.Label label1;
private System.Windows.Forms.Label label2;
private System.Windows.Forms.Label label3;
private System.Windows.Forms.Label label5;
private System.Windows.Forms.Panel panel1;
private System.Windows.Forms.Panel panel2;
private System.Windows.Forms.DataGrid grid;
private System.Windows.Forms.Button okButton;
/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;
private DataTable dataTable;
private CoreFactory core = UtilCoreFactory.createCoreFactory();
private string partNumber;
private System.Windows.Forms.TextBox partTextBox;
private System.Windows.Forms.TextBox lowLevelTextBox;
private System.Windows.Forms.TextBox qtyReqTextBox;
private System.Windows.Forms.TextBox qtyOnHandTextBox;
private System.Windows.Forms.TextBox descProdTextBox;
private string seqNumber;

public 
MaterialsGridForm(string partNumber, string seqNumber, string qty){
	InitializeComponent();

	this.partNumber = partNumber;
	this.seqNumber = seqNumber;

	partTextBox.Text = partNumber;
	qtyReqTextBox.Text = qty;

	try{
		if (core.existsProduct(partNumber)){
			Product prod = core.readProduct(partNumber);
			descProdTextBox.Text = prod.getDes1();

			decimal qtyOnHand = core.getQtyOnHandForProduct(partNumber);
			qtyOnHandTextBox.Text = qtyOnHand.ToString();
		}else{
			MessageBox.Show("The product : " + partNumber + " was not found");
		}
	}catch(NujitException ne){
		MessageBox.Show("Error : " + ne.Message);
	}

	initializeGrid();
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
	this.label1 = new System.Windows.Forms.Label();
	this.label2 = new System.Windows.Forms.Label();
	this.label3 = new System.Windows.Forms.Label();
	this.label5 = new System.Windows.Forms.Label();
	this.panel1 = new System.Windows.Forms.Panel();
	this.descProdTextBox = new System.Windows.Forms.TextBox();
	this.lowLevelTextBox = new System.Windows.Forms.TextBox();
	this.qtyReqTextBox = new System.Windows.Forms.TextBox();
	this.qtyOnHandTextBox = new System.Windows.Forms.TextBox();
	this.partTextBox = new System.Windows.Forms.TextBox();
	this.okButton = new System.Windows.Forms.Button();
	this.panel2 = new System.Windows.Forms.Panel();
	this.grid = new System.Windows.Forms.DataGrid();
	this.panel1.SuspendLayout();
	this.panel2.SuspendLayout();
	((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
	this.SuspendLayout();
	// 
	// label1
	// 
	this.label1.Location = new System.Drawing.Point(24, 16);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(100, 18);
	this.label1.TabIndex = 0;
	this.label1.Text = "Part";
	// 
	// label2
	// 
	this.label2.Location = new System.Drawing.Point(24, 40);
	this.label2.Name = "label2";
	this.label2.Size = new System.Drawing.Size(100, 18);
	this.label2.TabIndex = 1;
	this.label2.Text = "Quantity on Hand";
	// 
	// label3
	// 
	this.label3.Location = new System.Drawing.Point(24, 64);
	this.label3.Name = "label3";
	this.label3.Size = new System.Drawing.Size(100, 18);
	this.label3.TabIndex = 2;
	this.label3.Text = "Quantity Required";
	// 
	// label5
	// 
	this.label5.Location = new System.Drawing.Point(24, 88);
	this.label5.Name = "label5";
	this.label5.Size = new System.Drawing.Size(100, 18);
	this.label5.TabIndex = 4;
	this.label5.Text = "Lowest Level";
	// 
	// panel1
	// 
	this.panel1.Controls.Add(this.descProdTextBox);
	this.panel1.Controls.Add(this.lowLevelTextBox);
	this.panel1.Controls.Add(this.qtyReqTextBox);
	this.panel1.Controls.Add(this.qtyOnHandTextBox);
	this.panel1.Controls.Add(this.partTextBox);
	this.panel1.Controls.Add(this.label3);
	this.panel1.Controls.Add(this.label5);
	this.panel1.Controls.Add(this.label1);
	this.panel1.Controls.Add(this.label2);
	this.panel1.Location = new System.Drawing.Point(16, 8);
	this.panel1.Name = "panel1";
	this.panel1.Size = new System.Drawing.Size(560, 120);
	this.panel1.TabIndex = 9;
	// 
	// descProdTextBox
	// 
	this.descProdTextBox.Enabled = false;
	this.descProdTextBox.Location = new System.Drawing.Point(240, 16);
	this.descProdTextBox.Name = "descProdTextBox";
	this.descProdTextBox.Size = new System.Drawing.Size(232, 20);
	this.descProdTextBox.TabIndex = 14;
	this.descProdTextBox.Text = "";
	// 
	// lowLevelTextBox
	// 
	this.lowLevelTextBox.Enabled = false;
	this.lowLevelTextBox.Location = new System.Drawing.Point(136, 88);
	this.lowLevelTextBox.Name = "lowLevelTextBox";
	this.lowLevelTextBox.TabIndex = 13;
	this.lowLevelTextBox.Text = "";
	// 
	// qtyReqTextBox
	// 
	this.qtyReqTextBox.Enabled = false;
	this.qtyReqTextBox.Location = new System.Drawing.Point(136, 64);
	this.qtyReqTextBox.Name = "qtyReqTextBox";
	this.qtyReqTextBox.TabIndex = 11;
	this.qtyReqTextBox.Text = "";
	// 
	// qtyOnHandTextBox
	// 
	this.qtyOnHandTextBox.Enabled = false;
	this.qtyOnHandTextBox.Location = new System.Drawing.Point(136, 40);
	this.qtyOnHandTextBox.Name = "qtyOnHandTextBox";
	this.qtyOnHandTextBox.TabIndex = 10;
	this.qtyOnHandTextBox.Text = "";
	// 
	// partTextBox
	// 
	this.partTextBox.Enabled = false;
	this.partTextBox.Location = new System.Drawing.Point(136, 16);
	this.partTextBox.Name = "partTextBox";
	this.partTextBox.TabIndex = 9;
	this.partTextBox.Text = "";
	// 
	// okButton
	// 
	this.okButton.Location = new System.Drawing.Point(632, 320);
	this.okButton.Name = "okButton";
	this.okButton.Size = new System.Drawing.Size(72, 24);
	this.okButton.TabIndex = 18;
	this.okButton.Text = "Ok";
	this.okButton.Click += new System.EventHandler(this.okButton_Click);
	// 
	// panel2
	// 
	this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
	this.panel2.Controls.Add(this.grid);
	this.panel2.Location = new System.Drawing.Point(16, 136);
	this.panel2.Name = "panel2";
	this.panel2.Size = new System.Drawing.Size(688, 176);
	this.panel2.TabIndex = 10;
	// 
	// grid
	// 
	this.grid.CaptionVisible = false;
	this.grid.DataMember = "";
	this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
	this.grid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
	this.grid.Location = new System.Drawing.Point(0, 0);
	this.grid.Name = "grid";
	this.grid.Size = new System.Drawing.Size(684, 172);
	this.grid.TabIndex = 0;
	// 
	// MaterialsGridForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(722, 351);
	this.Controls.Add(this.panel2);
	this.Controls.Add(this.panel1);
	this.Controls.Add(this.okButton);
	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
	this.Name = "MaterialsGridForm";
	this.Text = "Materials";
	this.panel1.ResumeLayout(false);
	this.panel2.ResumeLayout(false);
	((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
	this.ResumeLayout(false);

}
#endregion

private
void initializeGrid(){
    dataTable = new DataTable();
    DataRow dataRow;

	dataTable.Columns.Add(new DataColumn("Lvl", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Part #", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Desc", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Req Qty", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Sequence", typeof(string)));
	dataTable.Columns.Add(new DataColumn("WIP Available", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Part Type", typeof(string)));

	string[][] forSeek;

	bool isFamily = core.isFamilyPart(partNumber);
	if (isFamily){
		forSeek = core.getComponentsFromFamily(partNumber);
	}else{
		forSeek = new string[1][];
		
		string[] line = new string[3];
		line[0] = partNumber;
		line[1] = seqNumber;
		forSeek[0] = line;
	}


	int lowLevel = 0;

	for(int x = 0; x < forSeek.Length; x++){
		string[][] vec = core.getAllMaterialsForProduct(forSeek[x][0], int.Parse(forSeek[x][1]),Configuration.DftPlant);
		
		for(int z = 0; z < vec.Length; z++){
			dataRow = dataTable.NewRow();
 			dataRow[0] = vec[z][1]; // level
			dataRow[1] = vec[z][0]; // part number
			dataRow[2] = vec[z][2]; // desc
 			dataRow[3] = vec[z][3]; // req qty
 			dataRow[4] = vec[z][5]; // sequence
 			dataRow[5] = vec[z][4]; // available or inventory
			dataRow[6] = vec[z][6]; // manufactured / purchased
			dataTable.Rows.Add(dataRow);

			int lowLevelAux = int.Parse(vec[z][1]);
			if (lowLevelAux > lowLevel)
				lowLevel = lowLevelAux;
		}
	}

	lowLevelTextBox.Text = lowLevel.ToString();
	DataView dataView = new DataView(dataTable);
	dataView.AllowEdit = false;
	dataView.AllowDelete = false;
	dataView.AllowNew = false;
	
	grid.DataSource = dataView;
	grid.PreferredColumnWidth = 150;
	grid.RowHeadersVisible = false;

	//Create a DataGridTableStyle object	
	DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();
	//Set its properties
	dgdtblStyle.MappingName = dataTable.TableName;//its table name of dataset
	grid.TableStyles.Clear(); 
	grid.TableStyles.Add(dgdtblStyle);
	dgdtblStyle.RowHeadersVisible = true;
	dgdtblStyle.AllowSorting = true;
	dgdtblStyle.PreferredRowHeight	= 22;

	GridColumnStylesCollection colStyle = grid.TableStyles[0].GridColumnStyles;		
	colStyle[0].Width = 30;
	colStyle[1].Width = 90;
	colStyle[2].Width = 200;
	colStyle[3].Width = 55;
	colStyle[4].Width = 65;
	colStyle[5].Width = 75;
	colStyle[6].Width = 90;
	grid.Refresh();
}

private 
void okButton_Click(object sender, System.EventArgs e){
	this.Dispose();
}


} // class

} // namespace
