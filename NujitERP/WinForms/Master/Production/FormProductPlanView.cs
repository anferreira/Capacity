using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.WinForms.SearchForms;

namespace Nujit.NujitERP.WinForms.Master.Production{
	
public 
class FormProductPlanView : System.Windows.Forms.Form{
	
private System.Windows.Forms.GroupBox groupBox6;
private System.Windows.Forms.Panel panel1;
private System.Windows.Forms.Button btnCancel;
private System.Windows.Forms.Button btnSeek;
/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;
private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private System.Windows.Forms.TextBox txtProduct;

private System.Windows.Forms.Label labelProduct;
private System.Windows.Forms.DataGrid grid;
private System.Windows.Forms.TextBox textName;
private System.Windows.Forms.Button btnEdit;
ProductPlan productPlan = null;
private DataTable dataTable = new DataTable();
private Button clearAllLeadTimesButton;
private DataView dataView;

public 
FormProductPlanView(){
	productPlan = coreFactory.createProductPlan();
	InitializeComponent();
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

private 
void InitializeComponent(){
    this.groupBox6 = new System.Windows.Forms.GroupBox();
    this.textName = new System.Windows.Forms.TextBox();
    this.txtProduct = new System.Windows.Forms.TextBox();
    this.btnSeek = new System.Windows.Forms.Button();
    this.labelProduct = new System.Windows.Forms.Label();
    this.panel1 = new System.Windows.Forms.Panel();
    this.btnEdit = new System.Windows.Forms.Button();
    this.btnCancel = new System.Windows.Forms.Button();
    this.grid = new System.Windows.Forms.DataGrid();
    this.clearAllLeadTimesButton = new System.Windows.Forms.Button();
    this.groupBox6.SuspendLayout();
    this.panel1.SuspendLayout();
    ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
    this.SuspendLayout();
    // 
    // groupBox6
    // 
    this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
    this.groupBox6.Controls.Add(this.textName);
    this.groupBox6.Controls.Add(this.txtProduct);
    this.groupBox6.Controls.Add(this.btnSeek);
    this.groupBox6.Controls.Add(this.labelProduct);
    this.groupBox6.Location = new System.Drawing.Point(8, 8);
    this.groupBox6.Name = "groupBox6";
    this.groupBox6.Size = new System.Drawing.Size(576, 64);
    this.groupBox6.TabIndex = 1;
    this.groupBox6.TabStop = false;
    this.groupBox6.Text = "Identification";
    // 
    // textName
    // 
    this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
    this.textName.Location = new System.Drawing.Point(264, 24);
    this.textName.MaxLength = 40;
    this.textName.Name = "textName";
    this.textName.ReadOnly = true;
    this.textName.Size = new System.Drawing.Size(304, 20);
    this.textName.TabIndex = 45;
    // 
    // txtProduct
    // 
    this.txtProduct.Location = new System.Drawing.Point(56, 22);
    this.txtProduct.MaxLength = 40;
    this.txtProduct.Name = "txtProduct";
    this.txtProduct.Size = new System.Drawing.Size(144, 20);
    this.txtProduct.TabIndex = 2;
    this.txtProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProduct_KeyDown);
    // 
    // btnSeek
    // 
    this.btnSeek.Location = new System.Drawing.Point(208, 24);
    this.btnSeek.Name = "btnSeek";
    this.btnSeek.Size = new System.Drawing.Size(48, 16);
    this.btnSeek.TabIndex = 3;
    this.btnSeek.Text = "...";
    this.btnSeek.Click += new System.EventHandler(this.btnSeek_Click);
    // 
    // labelProduct
    // 
    this.labelProduct.Location = new System.Drawing.Point(8, 24);
    this.labelProduct.Name = "labelProduct";
    this.labelProduct.Size = new System.Drawing.Size(48, 16);
    this.labelProduct.TabIndex = 43;
    this.labelProduct.Text = "Product";
    // 
    // panel1
    // 
    this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
    this.panel1.Controls.Add(this.clearAllLeadTimesButton);
    this.panel1.Controls.Add(this.btnEdit);
    this.panel1.Controls.Add(this.btnCancel);
    this.panel1.Location = new System.Drawing.Point(8, 256);
    this.panel1.Name = "panel1";
    this.panel1.Size = new System.Drawing.Size(576, 40);
    this.panel1.TabIndex = 2;
    // 
    // btnEdit
    // 
    this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Right)));
    this.btnEdit.Location = new System.Drawing.Point(368, 8);
    this.btnEdit.Name = "btnEdit";
    this.btnEdit.Size = new System.Drawing.Size(75, 23);
    this.btnEdit.TabIndex = 20;
    this.btnEdit.Text = "Edit";
    this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
    // 
    // btnCancel
    // 
    this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Right)));
    this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
    this.btnCancel.Location = new System.Drawing.Point(456, 8);
    this.btnCancel.Name = "btnCancel";
    this.btnCancel.Size = new System.Drawing.Size(75, 23);
    this.btnCancel.TabIndex = 21;
    this.btnCancel.Text = "Close";
    this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
    // 
    // grid
    // 
    this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
    this.grid.DataMember = "";
    this.grid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
    this.grid.Location = new System.Drawing.Point(8, 80);
    this.grid.Name = "grid";
    this.grid.Size = new System.Drawing.Size(576, 168);
    this.grid.TabIndex = 3;
    // 
    // clearAllLeadTimesButton
    // 
    this.clearAllLeadTimesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)));
    this.clearAllLeadTimesButton.Location = new System.Drawing.Point(45, 8);
    this.clearAllLeadTimesButton.Name = "clearAllLeadTimesButton";
    this.clearAllLeadTimesButton.Size = new System.Drawing.Size(126, 23);
    this.clearAllLeadTimesButton.TabIndex = 22;
    this.clearAllLeadTimesButton.Text = "Clear All Lead Times";
    this.clearAllLeadTimesButton.Click += new System.EventHandler(this.clearAllLeadTimesButton_Click);
    // 
    // FormProductPlanView
    // 
    this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
    this.ClientSize = new System.Drawing.Size(592, 310);
    this.Controls.Add(this.grid);
    this.Controls.Add(this.panel1);
    this.Controls.Add(this.groupBox6);
    this.Name = "FormProductPlanView";
    this.Text = "Product Plan Maintenance";
    this.Closing += new System.ComponentModel.CancelEventHandler(this.FormProductPlanView_Closing);
    this.groupBox6.ResumeLayout(false);
    this.groupBox6.PerformLayout();
    this.panel1.ResumeLayout(false);
    ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
    this.ResumeLayout(false);

}
#endregion

private 
void btnSeek_Click(object sender, System.EventArgs e){
	ProductSearchForm productSearchForm = new ProductSearchForm("Product search",txtProduct.Text.Trim(),true);
	productSearchForm.ShowDialog();

	try{
		if (productSearchForm.DialogResult == DialogResult.OK){		
			string[] v = productSearchForm.getSelected();
			txtProduct.Text = v[0];
			textName.Text = v[1];
			initializeGrid();
		}
		productSearchForm.Dispose();
	}catch(NujitException Nex){
		MessageBox.Show(Nex.Message);
	}		
}

private 
void initializeGrid(){
    dataTable = new DataTable();
    DataRow dataRow;

	dataTable.Columns.Add(new DataColumn("Seq", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Days Lt", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Days Lt Cum", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Inv Min", typeof(decimal)));
	dataTable.Columns.Add(new DataColumn("Inv Max", typeof(decimal)));

	string[][] vec = coreFactory.getProductPlanAsString(txtProduct.Text.Trim());
	for(int x = 0; x < vec.Length; x++){
		dataRow = dataTable.NewRow();

		dataRow[0] = vec[x][0]; 
 		dataRow[1] = vec[x][1]; 
		dataRow[2] = vec[x][2]; 
 		dataRow[3] = vec[x][3]; 
		dataRow[4] = vec[x][4]; 
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
	colStyle = grid.TableStyles[0].GridColumnStyles;		
	colStyle[0].Width = 100;
	colStyle[1].Width = 100;
	colStyle[2].Width = 100;
	colStyle[3].Width = 100;
	colStyle[4].Width = 100;
	grid.Refresh();
}


private 
void btnCancel_Click(object sender, System.EventArgs e){
	this.coreFactory = null;
	this.Close();
}

private 
void btnEdit_Click(object sender, System.EventArgs e){
	if (grid.CurrentRowIndex == -1){
		MessageBox.Show("You have to select a record first");
		return;
	}

	string prod = txtProduct.Text.Trim();
	string seq = getCurrentValue(0);

	FormProductPlan formProductPlan = new FormProductPlan(prod, seq);
	formProductPlan.ShowDialog();
	formProductPlan.Dispose();

	initializeGrid();
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

private 
void FormProductPlanView_Closing(object sender, System.ComponentModel.CancelEventArgs e){
	this.coreFactory = null;
    //this.Close(); AF 2018/09/28
}

private void txtProduct_KeyDown(object sender, KeyEventArgs e)
{
	if (e.KeyData == Keys.Enter)
	{
		Product p = coreFactory.readProduct (txtProduct.Text);
		if (p != null)
			this.textName.Text = p.getDes1();
		initializeGrid();
	}
}

private void clearAllLeadTimesButton_Click(object sender, EventArgs e)
{
    if (MessageBox.Show("Are you sure you want to clear all Lead Times and Cumulative values?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    {
        try
        {
            coreFactory.clearLeadTimes();
            MessageBox.Show("All values were cleaned.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }catch(Exception ex){
            MessageBox.Show("Error cleaning Lead Times and Cumulative values: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}


}

}
