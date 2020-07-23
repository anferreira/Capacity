using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.WinForms.Master;
using Nujit.NujitERP.WinForms.SearchForms;


namespace Nujit.NujitERP.WinForms.Reports.ProductsReport{
	/// <summary>
	/// Summary description for selectProductForm.
	/// </summary>
public class SelectProductForm : System.Windows.Forms.Form{
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.TextBox txtProdId;
	private System.Windows.Forms.Button btnSearch;
	private System.Windows.Forms.Button btnAdd;
	private System.Windows.Forms.Button btnClear;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.CheckedListBox clbSelectedProd;
	private System.ComponentModel.Container components = null;

	private bool flgSearch = false;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.Label label6;
	private System.Windows.Forms.Button btnClose;
	private System.Windows.Forms.Button btnReport;
	private System.Windows.Forms.TextBox txtMinGMayorThan;
	private System.Windows.Forms.TextBox txtMinGLessThan;
	private System.Windows.Forms.TextBox txtMayGLessThan;
	private System.Windows.Forms.TextBox txtMayGMayorThan;
	private System.Windows.Forms.ErrorProvider errorProvider1;
	private System.Windows.Forms.GroupBox groupBox2;
	private System.Windows.Forms.GroupBox gboxMinMay;
	private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();

public SelectProductForm(){
	
	InitializeComponent();

}

protected override void Dispose( bool disposing ){
	if( disposing )
	{
		if(components != null)
		{
			components.Dispose();
		}
	}
	base.Dispose( disposing );
}

#region Windows Form Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
private void InitializeComponent()	{
	this.label1 = new System.Windows.Forms.Label();
	this.txtProdId = new System.Windows.Forms.TextBox();
	this.btnSearch = new System.Windows.Forms.Button();
	this.btnAdd = new System.Windows.Forms.Button();
	this.btnClear = new System.Windows.Forms.Button();
	this.clbSelectedProd = new System.Windows.Forms.CheckedListBox();
	this.label2 = new System.Windows.Forms.Label();
	this.txtMinGMayorThan = new System.Windows.Forms.TextBox();
	this.txtMinGLessThan = new System.Windows.Forms.TextBox();
	this.btnReport = new System.Windows.Forms.Button();
	this.label4 = new System.Windows.Forms.Label();
	this.txtMayGLessThan = new System.Windows.Forms.TextBox();
	this.txtMayGMayorThan = new System.Windows.Forms.TextBox();
	this.label6 = new System.Windows.Forms.Label();
	this.btnClose = new System.Windows.Forms.Button();
	this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
	this.gboxMinMay = new System.Windows.Forms.GroupBox();
	this.groupBox2 = new System.Windows.Forms.GroupBox();
	this.gboxMinMay.SuspendLayout();
	this.groupBox2.SuspendLayout();
	this.SuspendLayout();
	// 
	// label1
	// 
	this.label1.Location = new System.Drawing.Point(8, 32);
	this.label1.Name = "label1";
	this.label1.Size = new System.Drawing.Size(56, 16);
	this.label1.TabIndex = 0;
	this.label1.Text = "Prod ID";
	// 
	// txtProdId
	// 
	this.txtProdId.Location = new System.Drawing.Point(64, 32);
	this.txtProdId.Name = "txtProdId";
	this.txtProdId.Size = new System.Drawing.Size(184, 20);
	this.txtProdId.TabIndex = 1;
	this.txtProdId.Text = "";
	this.txtProdId.TextChanged += new System.EventHandler(this.textChange);
	// 
	// btnSearch
	// 
	this.btnSearch.Location = new System.Drawing.Point(256, 32);
	this.btnSearch.Name = "btnSearch";
	this.btnSearch.Size = new System.Drawing.Size(32, 23);
	this.btnSearch.TabIndex = 2;
	this.btnSearch.Text = "...";
	this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
	// 
	// btnAdd
	// 
	this.btnAdd.Enabled = false;
	this.btnAdd.Location = new System.Drawing.Point(216, 72);
	this.btnAdd.Name = "btnAdd";
	this.btnAdd.Size = new System.Drawing.Size(56, 23);
	this.btnAdd.TabIndex = 3;
	this.btnAdd.Text = "Add";
	this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
	// 
	// btnClear
	// 
	this.btnClear.Enabled = false;
	this.btnClear.Location = new System.Drawing.Point(216, 104);
	this.btnClear.Name = "btnClear";
	this.btnClear.Size = new System.Drawing.Size(56, 23);
	this.btnClear.TabIndex = 5;
	this.btnClear.Text = "Clear";
	this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
	// 
	// clbSelectedProd
	// 
	this.clbSelectedProd.Location = new System.Drawing.Point(24, 64);
	this.clbSelectedProd.Name = "clbSelectedProd";
	this.clbSelectedProd.Size = new System.Drawing.Size(184, 154);
	this.clbSelectedProd.TabIndex = 6;
	// 
	// label2
	// 
	this.label2.Location = new System.Drawing.Point(72, 48);
	this.label2.Name = "label2";
	this.label2.Size = new System.Drawing.Size(120, 16);
	this.label2.TabIndex = 7;
	this.label2.Text = "Minor Group  between";
	// 
	// txtMinGMayorThan
	// 
	this.txtMinGMayorThan.Location = new System.Drawing.Point(72, 72);
	this.txtMinGMayorThan.Name = "txtMinGMayorThan";
	this.txtMinGMayorThan.Size = new System.Drawing.Size(40, 20);
	this.txtMinGMayorThan.TabIndex = 8;
	this.txtMinGMayorThan.Text = "";
	// 
	// txtMinGLessThan
	// 
	this.txtMinGLessThan.Location = new System.Drawing.Point(144, 72);
	this.txtMinGLessThan.Name = "txtMinGLessThan";
	this.txtMinGLessThan.Size = new System.Drawing.Size(40, 20);
	this.txtMinGLessThan.TabIndex = 9;
	this.txtMinGLessThan.Text = "";
	// 
	// btnReport
	// 
	this.btnReport.Location = new System.Drawing.Point(352, 256);
	this.btnReport.Name = "btnReport";
	this.btnReport.Size = new System.Drawing.Size(144, 23);
	this.btnReport.TabIndex = 11;
	this.btnReport.Text = "Report";
	this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
	// 
	// label4
	// 
	this.label4.Location = new System.Drawing.Point(112, 104);
	this.label4.Name = "label4";
	this.label4.Size = new System.Drawing.Size(32, 16);
	this.label4.TabIndex = 15;
	this.label4.Text = "and";
	// 
	// txtMayGLessThan
	// 
	this.txtMayGLessThan.Location = new System.Drawing.Point(144, 152);
	this.txtMayGLessThan.Name = "txtMayGLessThan";
	this.txtMayGLessThan.Size = new System.Drawing.Size(40, 20);
	this.txtMayGLessThan.TabIndex = 18;
	this.txtMayGLessThan.Text = "";
	// 
	// txtMayGMayorThan
	// 
	this.txtMayGMayorThan.Location = new System.Drawing.Point(72, 152);
	this.txtMayGMayorThan.Name = "txtMayGMayorThan";
	this.txtMayGMayorThan.Size = new System.Drawing.Size(40, 20);
	this.txtMayGMayorThan.TabIndex = 17;
	this.txtMayGMayorThan.Text = "";
	// 
	// label6
	// 
	this.label6.Location = new System.Drawing.Point(72, 128);
	this.label6.Name = "label6";
	this.label6.Size = new System.Drawing.Size(120, 16);
	this.label6.TabIndex = 16;
	this.label6.Text = "Mayor Group  between";
	// 
	// btnClose
	// 
	this.btnClose.Location = new System.Drawing.Point(512, 256);
	this.btnClose.Name = "btnClose";
	this.btnClose.TabIndex = 20;
	this.btnClose.Text = "Close";
	this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
	// 
	// errorProvider1
	// 
	this.errorProvider1.DataMember = null;
	// 
	// gboxMinMay
	// 
	this.gboxMinMay.Controls.AddRange(new System.Windows.Forms.Control[] {
																			 this.label4,
																			 this.txtMayGLessThan,
																			 this.label2,
																			 this.txtMinGMayorThan,
																			 this.txtMayGMayorThan,
																			 this.txtMinGLessThan,
																			 this.label6});
	this.gboxMinMay.Location = new System.Drawing.Point(344, 16);
	this.gboxMinMay.Name = "gboxMinMay";
	this.gboxMinMay.Size = new System.Drawing.Size(248, 232);
	this.gboxMinMay.TabIndex = 21;
	this.gboxMinMay.TabStop = false;
	this.gboxMinMay.Text = "Minor and Mayor Group";
	// 
	// groupBox2
	// 
	this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																			this.btnSearch,
																			this.txtProdId,
																			this.label1,
																			this.clbSelectedProd,
																			this.btnClear,
																			this.btnAdd});
	this.groupBox2.Location = new System.Drawing.Point(16, 16);
	this.groupBox2.Name = "groupBox2";
	this.groupBox2.Size = new System.Drawing.Size(312, 232);
	this.groupBox2.TabIndex = 22;
	this.groupBox2.TabStop = false;
	this.groupBox2.Text = "Products";
	// 
	// SelectProductForm
	// 
	this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
	this.ClientSize = new System.Drawing.Size(624, 294);
	this.Controls.AddRange(new System.Windows.Forms.Control[] {
																  this.groupBox2,
																  this.gboxMinMay,
																  this.btnClose,
																  this.btnReport});
	this.Name = "SelectProductForm";
	this.Text = "Select Product";
	this.gboxMinMay.ResumeLayout(false);
	this.groupBox2.ResumeLayout(false);
	this.ResumeLayout(false);

}
#endregion

private void btnSearch_Click(object sender, System.EventArgs e){
	
	ProductSearchForm productSearchForm = new ProductSearchForm("Product Search", true);
	productSearchForm.ShowDialog();
	
	if (productSearchForm.DialogResult == DialogResult.OK){
		string[] v = productSearchForm.getSelected();
		if (v != null){
			this.txtProdId.Text=v[0];
			this.flgSearch = true;
		}
	}

}

private void btnAdd_Click(object sender, System.EventArgs e){
	if (!flgSearch){
		if (!existProd(this.txtProdId.Text)){
			MessageBox.Show("The product does't exist!");
			return;		
		}
	}
	if (!inList(this.txtProdId.Text)){
		clbSelectedProd.Items.Add(this.txtProdId.Text,true);
		this.btnClear.Enabled=true;
		this.btnAdd.Enabled=false;
		
	}
	else
		MessageBox.Show("The "+this.txtProdId.Text+" product is already selected." );
	this.txtProdId.Text = "";	
	flgSearch = false;
}

private bool existProd(string prodID){
	return coreFactory.existsProduct(prodID);
}


private bool inList(string prodID){
	bool inCblList = false;
	if (clbSelectedProd.Items.Count>0){
		this.clbSelectedProd.SelectedIndex = this.clbSelectedProd.FindStringExact(prodID);
		if (clbSelectedProd.SelectedIndex == -1)
			clbSelectedProd.SelectedIndex = 0;
		else
			inCblList = true;
	}
	return inCblList;
}



private void btnClose_Click(object sender, System.EventArgs e){
	this.Dispose();

}

private void btnClear_Click(object sender, System.EventArgs e){
	for(int i=0 ;i<clbSelectedProd.Items.Count; i++){
		clbSelectedProd.SetItemChecked(i, false);
	}
	this.btnClear.Enabled=false;
}

private void textChange(object sender, System.EventArgs e){
	this.btnAdd.Enabled=true;
}


private void btnReport_Click(object sender, System.EventArgs e){
	
	string	infMinGroup = this.txtMinGMayorThan.Text;
	string	supMinGroup = this.txtMinGLessThan.Text;
	string	infMayGroup = this.txtMayGMayorThan.Text;
	string	supMayGroup = this.txtMayGLessThan.Text;
					
		
	string[] vecProd= getProdFromList();
	DataSet dataSet = this.generateReportDataSet(vecProd,infMinGroup,supMinGroup,infMayGroup,supMayGroup);
	ProductReport productReport = new ProductReport(dataSet,infMayGroup,supMayGroup);
	productReport.ShowDialog();
	

}

private void clearError()	{
	foreach(Control objControl in this.gboxMinMay.Controls)	{
		if (objControl is TextBox)
			errorProvider1.SetError(objControl,"");	
	}
}

private bool validNumericFields(){
	if (!NumberUtil.isIntegerNumber(txtMinGMayorThan.Text.ToString())){ 		
			this.errorProvider1.SetError(txtMinGMayorThan,"This value must be integer");
			return false;
	}

	if (!NumberUtil.isIntegerNumber(txtMinGLessThan.Text.ToString())){
		this.errorProvider1.SetError(txtMinGLessThan,"This value must be integer");
		return false;
	}
	
	if (!NumberUtil.isIntegerNumber(txtMayGMayorThan.Text.ToString())){
		this.errorProvider1.SetError(txtMayGMayorThan,"This value must be integer");
		return false;
	}
	
	if (!NumberUtil.isIntegerNumber(txtMayGLessThan.Text.ToString())){
		this.errorProvider1.SetError(txtMayGLessThan,"This value must be integer");
		return false;
	}
	return true;
	
}
private string[] getProdFromList(){
	ArrayList array = new ArrayList();
	for (int i = 0; i < this.clbSelectedProd.Items.Count; i++){
		if (clbSelectedProd.GetItemChecked(i))
			array.Add(clbSelectedProd.Items[i]);
	}
	string[] vec = new String[array.Count];
	int index = 0;
	IEnumerator iEnum2 = array.GetEnumerator();
	while(iEnum2.MoveNext()){
		vec[index] = iEnum2.Current.ToString();
		index++;
	}
		
	return  vec;
}


private DataSet generateReportDataSet(string[] prodsID,string infMinGroup,string supMinGroup,
													   string infMayGroup,string supMayGroup){
	DataTable dataTable = new DataTable();
	DataRow dataRow;
	
	dataTable.TableName = "products";	

	dataTable.Columns.Add(new DataColumn("PFS_ProdID",typeof(string)));
	dataTable.Columns.Add(new DataColumn("PFS_Des1",typeof(string)));
	dataTable.Columns.Add(new DataColumn("PFS_Des2",typeof(string)));
	dataTable.Columns.Add(new DataColumn("PFS_Des3",typeof(string)));
	dataTable.Columns.Add(new DataColumn("PFS_VarFam",typeof(string)));
	dataTable.Columns.Add(new DataColumn("PFS_SeqLast",typeof(string)));
	dataTable.Columns.Add(new DataColumn("PFS_ActIDLast",typeof(string)));
	dataTable.Columns.Add(new DataColumn("PFS_FamProd",typeof(string)));
	dataTable.Columns.Add(new DataColumn("PFS_PartType",typeof(string)));
	dataTable.Columns.Add(new DataColumn("PFS_InvStatus",typeof(string)));
	dataTable.Columns.Add(new DataColumn("PFS_ABCCode",typeof(string)));
	dataTable.Columns.Add(new DataColumn("PFS_MajorGroup",typeof(string)));
	dataTable.Columns.Add(new DataColumn("PFS_MinorGroup",typeof(string)));
	dataTable.Columns.Add(new DataColumn("PFS_GLExp",typeof(string)));
	dataTable.Columns.Add(new DataColumn("PFS_GLDistr",typeof(string)));
	dataTable.Columns.Add(new DataColumn("PFS_MajorSales",typeof(string)));
	dataTable.Columns.Add(new DataColumn("PFS_MinorSales",typeof(string)));
	dataTable.Columns.Add(new DataColumn("PFS_LastRevision",typeof(string)));
	
	CoreFactory coreFactory =UtilCoreFactory.createCoreFactory();
	string[][] vec = coreFactory.getProductsForReportAsString(infMayGroup,infMinGroup,supMayGroup,supMinGroup,prodsID);
	
	for(int x = 0; x < vec.Length; x++){
		dataRow = dataTable.NewRow();
		dataRow.ItemArray = vec[x];
		dataTable.Rows.Add(dataRow);	
	}
	DataSet productReportDataSet = new DataSet();
	productReportDataSet.Tables.Add(dataTable);
	
	return productReportDataSet;
}

	

}//end class
}//end namespace
