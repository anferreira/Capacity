using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using System.Data;
using Nujit.NujitERP.WinForms.Reports.InventoryReport;
using Nujit.NujitERP.WinForms.SearchForms;
//using System.Windows.Forms.KeyEventArgs
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.WinForms.Master
{
	/// <summary>
	/// Summary description for InvPltLocForm.
	/// </summary>
	public class InvPltLocForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnSearchProd;
		private System.Windows.Forms.TextBox tBoxProdId;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dtGridInvPltLoc;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnEdit;
		private bool existRows = false;
		private bool flgChange = false;
		private string prodID;
		private DataTable invPltLocDataTable;
		private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
		private Inventory inventory;
		private System.Windows.Forms.Button btnReport;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnExit;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public InvPltLocForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			loadGrid();
			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
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
		private void InitializeComponent()
		{
			this.btnSearchProd = new System.Windows.Forms.Button();
			this.tBoxProdId = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dtGridInvPltLoc = new System.Windows.Forms.DataGrid();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnReport = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dtGridInvPltLoc)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSearchProd
			// 
			this.btnSearchProd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSearchProd.Location = new System.Drawing.Point(352, 24);
			this.btnSearchProd.Name = "btnSearchProd";
			this.btnSearchProd.Size = new System.Drawing.Size(32, 24);
			this.btnSearchProd.TabIndex = 1;
			this.btnSearchProd.Text = "...";
			this.btnSearchProd.Click += new System.EventHandler(this.btnSearchProd_Click);
			// 
			// tBoxProdId
			// 
			this.tBoxProdId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tBoxProdId.Location = new System.Drawing.Point(80, 24);
			this.tBoxProdId.Name = "tBoxProdId";
			this.tBoxProdId.Size = new System.Drawing.Size(256, 20);
			this.tBoxProdId.TabIndex = 2;
			this.tBoxProdId.Text = "";
			this.tBoxProdId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPressEvent);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Prod Id";
			// 
			// dtGridInvPltLoc
			// 
			this.dtGridInvPltLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dtGridInvPltLoc.CaptionVisible = false;
			this.dtGridInvPltLoc.DataMember = "";
			this.dtGridInvPltLoc.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dtGridInvPltLoc.Location = new System.Drawing.Point(8, 56);
			this.dtGridInvPltLoc.Name = "dtGridInvPltLoc";
			this.dtGridInvPltLoc.ReadOnly = true;
			this.dtGridInvPltLoc.Size = new System.Drawing.Size(664, 304);
			this.dtGridInvPltLoc.TabIndex = 4;
			this.dtGridInvPltLoc.DoubleClick += new System.EventHandler(this.dtGridInvPltLoc_DoubleClick);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Enabled = false;
			this.btnAdd.Location = new System.Drawing.Point(352, 368);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.TabIndex = 5;
			this.btnAdd.Text = "Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemove.Enabled = false;
			this.btnRemove.Location = new System.Drawing.Point(432, 368);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.TabIndex = 6;
			this.btnRemove.Text = "Remove";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Enabled = false;
			this.btnEdit.Location = new System.Drawing.Point(512, 368);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.TabIndex = 7;
			this.btnEdit.Text = "Edit";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnExit
			// 
			this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExit.Location = new System.Drawing.Point(592, 368);
			this.btnExit.Name = "btnExit";
			this.btnExit.TabIndex = 8;
			this.btnExit.Text = "Close";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnReport
			// 
			this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnReport.Enabled = false;
			this.btnReport.Location = new System.Drawing.Point(32, 368);
			this.btnReport.Name = "btnReport";
			this.btnReport.Size = new System.Drawing.Size(104, 23);
			this.btnReport.TabIndex = 10;
			this.btnReport.Text = "Report";
			this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Enabled = false;
			this.btnSave.Location = new System.Drawing.Point(432, 24);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(104, 23);
			this.btnSave.TabIndex = 11;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// InvPltLocForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(680, 406);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnReport);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.dtGridInvPltLoc);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tBoxProdId);
			this.Controls.Add(this.btnSearchProd);
			this.Name = "InvPltLocForm";
			this.Text = "Inventory ";
			this.Load += new System.EventHandler(this.InvPltLocForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtGridInvPltLoc)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion



private void btnExit_Click(object sender, System.EventArgs e){
	if (this.flgChange){
		DialogResult exitConfirm = MessageBox.Show("Data have change, do you want to save first?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (exitConfirm == DialogResult.Yes)
			saveData();
	}
	Close();
}//btnExit_Click

private bool isDataOk(){
	return true;
}

private void btnSearchProd_Click(object sender, System.EventArgs e){
	
	if (flgChange){
	     DialogResult errorsMessage = MessageBox.Show("Do you want to save the changes first?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		 if (errorsMessage == DialogResult.Yes){
		    saveData();
		    loadGrid();
		    this.btnAdd.Enabled = true;
		    this.btnEdit.Enabled = true;
		    this.btnRemove.Enabled =true;
		 }
	}else{
	    ProductSearchForm productSearchForm = new ProductSearchForm("Search", true);
	    productSearchForm.ShowDialog();
    	
	    if (productSearchForm.DialogResult == DialogResult.OK){
	    //public static string[] getSelected(int current,DataGrid dGrid,DataTable dataTable){

		    string[] v = productSearchForm.getSelected();
		    if (v != null){
			    prodID=tBoxProdId.Text=v[0];
			    if (coreFactory.existsInventory(prodID,Configuration.DftPlant)){
				    this.inventory = coreFactory.readInventory(prodID, Configuration.DftPlant);
				    string[][] invent = inventory.getInvPltLocAsString();
				    if (invent != null){
					    loadGrid(invent);
					    this.existRows =true;
					    this.btnRemove.Enabled=true;
					    this.btnEdit.Enabled=true;
					    this.btnAdd.Enabled=true;
					    this.btnReport.Enabled=true;
				    }
    				
			    }else
				    this.btnAdd.Enabled=true;
    			
		    }else
			    MessageBox.Show("Select a product!");
	    }
	}
}//end_btnSearchProd_Click


private void loadGrid(){

    invPltLocDataTable = new DataTable();
	string[][] gridColumns =columnsNames();
	DataSet listDataSet = new DataSet();	
	Grid.addColumns(gridColumns," ",invPltLocDataTable,dtGridInvPltLoc);
		
	DataView dataView = new DataView(invPltLocDataTable);

	dataView.AllowEdit = false;
	dataView.AllowDelete = false;
	dataView.AllowNew = false;
	dtGridInvPltLoc.DataSource = dataView;
	
	//FN
/*	GridColumnStylesCollection colStyle = dtGridInvPltLoc.TableStyles[0].GridColumnStyles;
	colStyle[6].Alignment = HorizontalAlignment.Right;
	colStyle[7].Alignment = HorizontalAlignment.Right;
	colStyle[9].Alignment = HorizontalAlignment.Right;
	colStyle[10].Alignment = HorizontalAlignment.Right;
*/
}//endLoadGrid

private void loadGrid(string[][] inventory){

	invPltLocDataTable = new DataTable();
	string[][] gridColumns =columnsNames();
	DataRow dataRow;
	DataSet listDataSet = new DataSet();	
	Grid.addColumns(gridColumns," ",invPltLocDataTable);
	for (int i = 0; i < inventory.Length; i++){
		dataRow = invPltLocDataTable.NewRow();
		dataRow[0] = inventory[i][0];
		dataRow[1] = inventory[i][1];
		dataRow[2] = inventory[i][2];
		dataRow[3] = inventory[i][3];
		dataRow[4] = inventory[i][4];
		dataRow[5] = inventory[i][5];
		dataRow[6] = inventory[i][6];
		dataRow[7] = inventory[i][7];
		dataRow[8] = inventory[i][8];
		dataRow[9] = inventory[i][9];
		dataRow[10] = inventory[i][10];
		dataRow[11] = inventory[i][11];
		dataRow[12] = inventory[i][12];
		invPltLocDataTable.Rows.Add(dataRow);
	}
	DataView dataView = new DataView(invPltLocDataTable);
	dtGridInvPltLoc.DataSource = dataView;
	
}//endLoadGrid


public 
string[][] columnsNames() {
	string[][] vec = new String[13][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
			case "0":
				v[0]="Prod Id";
				v[1] = "120";
				break;
			case "1":
				v[0]="Seq";
				v[1] = "70";
				break;
			case "2":
				v[0]="Lot Id";
				v[1] = "70";
				break;
			 case "3":
				v[0]="Mas Prod Id";
				v[1] = "70";
				break;
			 case "4":
				v[0]="Pr Ord";
				v[1] = "70";
				break;
			 case "5":
				v[0]="Stk Loc";
				v[1] = "70";
				break;
			case "6":
				v = new string[3];
				v[0]="Qoh";
				v[1] = "70";
				v[2] = Grid.ALIGN_RIGHT;
				break;
		    case "7":
				v = new string[3];
				v[0]="Qoh Avail";
				v[1] = "70";
				v[2] = Grid.ALIGN_RIGHT;
				break;
			case "8":
				v[0]="Uom";
				v[1] = "70";
				break;     
			case "9":
				v = new string[3];
				v[0]="Qoh 2";
				v[1] = "70";
				v[2] = Grid.ALIGN_RIGHT;
				break;           
			case "10":
				v = new string[3];
				v[0]="Qoh Avail2";
				v[1] = "70";
				v[2] = Grid.ALIGN_RIGHT;
				break;           
            case "11":
				v[0]="Uom 2";
				v[1] = "70";
				break;
			case "12":
				v[0]="Prod 2";
				v[1] = "70";
				break;
		}
	    vec[i]=v;
		i++;	
	}
	return vec;
}


private void btnRemove_Click(object sender, System.EventArgs e)	{
	DialogResult deleteConfirm = MessageBox.Show("Remove this item ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
	if (deleteConfirm == DialogResult.No)
		return;
	
	int rowNumber = this.dtGridInvPltLoc.CurrentCell.RowNumber;
	invPltLocDataTable.Rows.RemoveAt(rowNumber);
	if (!flgChange){
		flgChange = true;
		this.btnSave.Enabled = true;
	}
	if (invPltLocDataTable.Rows.Count == 0)
		this.btnRemove.Enabled=false;	
	
}

private void btnAdd_Click(object sender, System.EventArgs e){
	try{
		string[]  vecProdID = {tBoxProdId.Text};
		string[] vecSeq = coreFactory.getValidsSeqsForProduct(this.tBoxProdId.Text);
		if (vecSeq.Length < 1){
			MessageBox.Show("There are not a valid sequence for the product: "+this.tBoxProdId.Text);
			return;
		}else{
			string[][] vecStk = coreFactory.getAllPltInvLocAsString();
			if ((vecStk != null) &&(vecStk.Length > 0)){
				AddInvPltLocForm addInvPltLoc = new AddInvPltLocForm("Add",vecProdID,vecSeq,vecStk);
				addInvPltLoc.ShowDialog();
				loadGridNewData(addInvPltLoc);		
				this.btnRemove.Enabled = true;
				if (!flgChange){
					flgChange = true;
					this.btnSave.Enabled = true;
				}
			}else
				MessageBox.Show("There is not Stkr for load.");
		}
	}catch (FormatException) {
		MessageBox.Show("Please, fill all the fields in the form","Error");
		btnAdd_Click(sender, e);
	}
}

private bool addGridOK(int seq,string stkLoc){
	bool  notExist = false;
	for(IEnumerator en = invPltLocDataTable.Rows.GetEnumerator(); en.MoveNext();){
		DataRow row = (DataRow)en.Current;
		if (row[1].ToString().Equals(seq.ToString())&(row[5].ToString().Equals(stkLoc)))
			return true;
	}
	return  notExist;
}

private void btnEdit_Click(object sender, System.EventArgs e){
	if (!this.editItem())
		btnAdd_Click(sender, e);
}

private bool editItem ()
{
	try 
	{
		int rowNumber = this.dtGridInvPltLoc.CurrentCell.RowNumber;
		string[] infomrationInlPltLoc = Grid.getSelected(rowNumber,dtGridInvPltLoc,invPltLocDataTable);
		string[] vecSeq = {};
		string[][] vecStk = null;
		AddInvPltLocForm addInvPltLoc = new AddInvPltLocForm("Edit",infomrationInlPltLoc,vecSeq,vecStk);
		addInvPltLoc.ShowDialog();
		loadGridModifData(addInvPltLoc,rowNumber);
		if (!flgChange)
		{
			flgChange = true;
			this.btnSave.Enabled = true;
		}
		return true;
	} 
	catch (FormatException)
	{
		MessageBox.Show("Please, fill all the fields in the form","Error");
		return false;
	}
}

private void loadGridNewData(AddInvPltLocForm invPltLoc)
{
	if (invPltLoc.DialogResult== DialogResult.OK){
		if (!addGridOK(int.Parse(invPltLoc.getSeq()),invPltLoc.getStkLoc())){
			DataRow dataRow = invPltLocDataTable.NewRow();
			dataRow[0]= invPltLoc.getProdID();;
			dataRow[1]= int.Parse(invPltLoc.getSeq());
			dataRow[2]= invPltLoc.getLotID();
			dataRow[3]= invPltLoc.getMasPrOrd();
			dataRow[4]= invPltLoc.getPrOrd();
			dataRow[5]= invPltLoc.getStkLoc();
			string aux =invPltLoc.getQoh();
			if ((aux != null)&(!aux.Equals("")))
				dataRow[6]= Convert.ToDecimal(aux);
			else
				dataRow[6]= 0;
			aux = invPltLoc.getQohAvail();
			
			if ((aux != null)&(!aux.Equals("")))
				dataRow[7]= Convert.ToDecimal(aux);
			else
				dataRow[7]= 0;
			dataRow[8]= invPltLoc.getUom();
			aux = invPltLoc.getQoh2();
			if ((aux != null)&(!aux.Equals("")))
				dataRow[9]= Convert.ToDecimal(aux);
			else
				dataRow[9]= 0;
			aux = invPltLoc.getQohAvail2();
			if ((aux != null)&(!aux.Equals("")))
				dataRow[10]= Convert.ToDecimal(aux);
			else
				dataRow[10]= 0;
			dataRow[11]= invPltLoc.getUom2();
			dataRow[12]= invPltLoc.getProd2();	
			invPltLocDataTable.Rows.Add(dataRow);
		}else {
			MessageBox.Show("There is a Seq, StkLoc for this product, try with another Seq, StkLoc.");
		}
	}

}

private void loadGridModifData(AddInvPltLocForm invPltLoc,int rowNumber){
	
	if (invPltLoc.DialogResult == DialogResult.OK){
	    Grid.setGridValue(invPltLoc.getMasPrOrd(),rowNumber,3,invPltLocDataTable);
	    Grid.setGridValue(invPltLoc.getPrOrd(),rowNumber,4,invPltLocDataTable);
		Grid.setGridValue(invPltLoc.getLotID(),rowNumber,2,invPltLocDataTable);
		Grid.setGridValue(invPltLoc.getQoh(),rowNumber,6,invPltLocDataTable);
		Grid.setGridValue(invPltLoc.getQohAvail(),rowNumber,7,invPltLocDataTable);
		Grid.setGridValue(invPltLoc.getUom(),rowNumber,8,invPltLocDataTable);
		Grid.setGridValue(invPltLoc.getQoh2(),rowNumber,9,invPltLocDataTable);
		Grid.setGridValue(invPltLoc.getQohAvail2(),rowNumber,10,invPltLocDataTable);
		Grid.setGridValue(invPltLoc.getUom2(),rowNumber,11,invPltLocDataTable);
		Grid.setGridValue(invPltLoc.getProd2(),rowNumber,12,invPltLocDataTable);		
	}
}//end loadGridModifData

private void btnReport_Click(object sender, System.EventArgs e){
	if (this.flgChange){
		DialogResult reportConfirm = MessageBox.Show("Data have change, do you want to save first? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (reportConfirm == DialogResult.Yes)
			saveData();
	}
	this.Cursor = Cursors.WaitCursor;
	DataSet dsInventory = generateDataSetInventory();
	InventoryReport inventoryReport = new InventoryReport(this.tBoxProdId.Text,dsInventory);
	this.Cursor = Cursors.Default;

	inventoryReport.ShowDialog();
	
}

private void btnSave_Click(object sender, System.EventArgs e){
	saveData();		
}//end btnSave_Click

	
private void saveData(){
	if (invPltLocDataTable.Columns.Count>0){
		if (existRows)
			inventory.removeAllInventary();
		else
			this.inventory = coreFactory.readInventory(prodID,Configuration.DftPlant);
		for(IEnumerator en = invPltLocDataTable.Rows.GetEnumerator(); en.MoveNext();){
				DataRow row = (DataRow)en.Current;		
				int cols = invPltLocDataTable.Columns.Count;
				string[] aux = new String[cols];
				for(int i = 0; i < cols; i++){
					aux[i] = row[i].ToString();
				}
				inventory.addValueInventory(aux[0],aux[1],aux[2],aux[3],aux[4],aux[5],aux[6],aux[7],aux[8],
											aux[9],aux[10],aux[11],aux[12]);
		}
		try {
			coreFactory.updateInventory(inventory);
			this.flgChange = false;
			btnSave.Enabled = false;	
	
		}catch (NujitException ne){
			MessageBox.Show(ne.Message);
		}
	}
}

private string[][] columnsNameReport(){
	string[][] vec = new String[15][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
            case "0":
                v[0] = "IPL_ProdID";
                v[1] = "0";
                break;
            case "1":
                v[0] = "IPL_Seq";
                v[1] = "0";
                break;
            case "2":
                v[0] = "IPL_StkLoc";
                v[1] = "0";
                break;
            case "3":
                v[0] = "IPL_ActID";
                v[1] = "0";
                break;
            case "4":
                v[0] = "IPL_LotID";
                v[1] = "0";
                break;
            case "5":
                v[0] = "IPL_MasPrOrd";
                v[1] = "0";
                break;
            case "6":
                v[0] = "IPL_PrOrd";
                v[1] = "0";
                break;
            case "7":
                v[0] = "IPL_Qoh";
                v[1] = "0";
                break;
            case "8":
                v[0] = "IPL_QohAvail";
                v[1] = "0";
                break;
            case "9":
                v[0] = "IPL_Uom";
                v[1] = "0";
                break;
            case "10":
                v[0] = "IPL_Qoh2";
                v[1] = "0";
                break;
            case "11":
                v[0] = "IPL_QohAvail2";
                v[1] = "0";
                break;
            case "12":
                v[0] = "IPL_Uom2";
                v[1] = "0";
                break;
            case "13":
                v[0] = "IPL_Prod2";
                v[1] = "0";
                break;
            case "14":
                v[0] = "PFS_Des1";     
                v[1] = "0";
                break;
    }
	vec[i]=v;
	i++;	
    }
	return vec;
}
private 
DataSet generateDataSetInventory(){
	
	DataTable dataTable = new DataTable();
	DataRow dataRow;
	string tableName ="inventory";
	string[][] columns= columnsNameReport();
						
    Grid.addColumns(columns,tableName,dataTable);
	string[][] vec = coreFactory.getInventoryReport(this.tBoxProdId.Text);
	for(int x = 0; x < vec.Length; x++){
		dataRow = dataTable.NewRow();
		dataRow.ItemArray = vec[x];
		dataTable.Rows.Add(dataRow);
	}
	DataSet inventoryReportDataSet = new DataSet();
	inventoryReportDataSet.Tables.Add(dataTable);
	return inventoryReportDataSet;
}

private void keyPressEvent(object sender, System.Windows.Forms.KeyPressEventArgs e){
	if(e.KeyChar == (char)13){ //The key press is ENTER
		string prodText = tBoxProdId.Text;
		if (coreFactory.existsProduct(prodText)){
		    if (coreFactory.existsInventory(prodText,Configuration.DftPlant)){
				    this.inventory = coreFactory.readInventory(prodText, Configuration.DftPlant);
				    string[][] invent = inventory.getInvPltLocAsString();
				    if (invent != null){
					    loadGrid(invent);
					    this.existRows =true;
					    this.btnRemove.Enabled=true;
					    this.btnEdit.Enabled=true;
					    this.btnAdd.Enabled=true;
					    this.btnReport.Enabled=true;
				    }
    	    }else
			    this.btnAdd.Enabled=true;	
		}else MessageBox.Show("The product " + prodText + " does not exist.");
	}
			
}

		private void dtGridInvPltLoc_DoubleClick(object sender, EventArgs e)
		{
			System.Windows.Forms.DataGrid.HitTestInfo hti = dtGridInvPltLoc.HitTest(dtGridInvPltLoc.PointToClient(MousePosition)); 
			if (hti.Type == DataGrid.HitTestType.RowHeader)
				this.editItem();
		}

		private void InvPltLocForm_Load(object sender, System.EventArgs e)
		{
		
		}
	}//end class
}//end namespace
