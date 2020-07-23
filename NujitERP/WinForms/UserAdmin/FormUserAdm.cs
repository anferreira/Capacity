/*********************************************************************** 
File Name:               FormUserAdmin.cs
Created By:              Eric zhong
Created Date:            30/04/2004
***********************************************************************/
using System;
using System.Data;

using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Nujit.NujitERP.ClassLib;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.CustomDataGrid;
using Nujit.NujitERP.ClassLib.ErpException;
using System.Collections;
using System.Collections.ObjectModel;


namespace Nujit.NujitERP.WinForms{
	
public 
class FormUserAdm : System.Windows.Forms.Form{		
		
//private DataSet mobjDataSet = new DataSet("User");

private User mobjUser;
private User mainUser=null;

private bool blnEdit = false , blnInsert = false;
private bool mblnContentChanged = false;

private int mintPageCurrent;
private int mintPageTotal;
private int mintPageSize;

private int mintTotalCount;
private string mstrSort;
private string mstrSortBy;
	private Nujit.NujitERP.ClassLib.CustomDataGrid.SingleSelectDataGrid dgCollection;

private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private DataTable dataTable = new DataTable();
private EmployeeContainer employeeContainer;

private System.Windows.Forms.Button btnAdd;
private System.Windows.Forms.Button btnSave;
private System.Windows.Forms.Button btnCancel;
private System.Windows.Forms.Button btnDelete;
private System.Windows.Forms.Button btnClose;
private System.Windows.Forms.GroupBox groupBox2;
private System.Windows.Forms.Label lblEmail;
private System.Windows.Forms.TextBox txtEmail;
private System.Windows.Forms.Button btnEdit;
private System.Windows.Forms.Label lblFirstName;
private System.Windows.Forms.TextBox txtFirstName;
private System.Windows.Forms.Label lblLastName;
private System.Windows.Forms.TextBox txtLastName;
private System.Windows.Forms.TextBox txtUserName;
private System.Windows.Forms.Label lblUserName;
private System.Windows.Forms.TextBox txtPassword;
private System.Windows.Forms.TextBox txtRetypePassword;
private System.Windows.Forms.Label lblRetypePassword;
private System.Windows.Forms.Label lblPassword;
private System.Windows.Forms.ErrorProvider errorProviderUser;
private System.Windows.Forms.GroupBox grpBoxtype;
private System.Windows.Forms.Label lblType;
private System.Windows.Forms.RadioButton rdoAdmin;
	private System.Windows.Forms.Button btnDefaults;
        private IContainer components;
        private ComboBox employeeComboBox;
        private Label employeeLabel;
        private System.Windows.Forms.RadioButton rdoUser;
		

public 
User Operator{
	get{
		if (this.mobjUser == null)  
			mobjUser = coreFactory.createUser();
		return mobjUser;
	}
	set{
		this.mobjUser = value;
	}
}

public 
int PageSize{
	get{
		return mintPageSize;
	}
	set{
		mintPageSize = value;
	}
}

public 
string SortExpression{
	get{
		if(this.mstrSort != null && this.mstrSort != string.Empty){
			if(this.mstrSortBy != null && this.mstrSortBy != string.Empty){
				return this.mstrSort + " " + this.mstrSortBy;
			}
			return this.mstrSort;
		}
		return "";
	}
}

public 
bool ContentChanged{
	get{
		return mblnContentChanged;
	}
	set{
		mblnContentChanged = value;
	}
}

private 
void ClearFields(){
	// Clear text fields box
	txtUserName.Text         = string.Empty;
	txtFirstName.Text         = string.Empty;
	txtLastName.Text          = string.Empty;
	txtEmail.Text			  = string.Empty;
	this.txtPassword.Text          ="";
	this.txtRetypePassword.Text   ="";
    if (employeeComboBox.Items.Count > 0)
        employeeComboBox.SelectedIndex=0;
}

private void FillInTextBoxes(){   
	//dgCollection.CurrentRowIndex
	int intUserID = int.Parse((string)dataTable.Rows[dgCollection.CurrentRowIndex][0]);
		
	this.mainUser = this.coreFactory.readUser(intUserID);

	txtUserName.Text = mainUser.getLoginName();
	txtFirstName.Text = mainUser.getFirstName();
	txtLastName.Text = mainUser.getLastName();
	txtPassword.Text = mainUser.getPassword();
	txtRetypePassword.Text = mainUser.getPassword();
	txtEmail.Text = mainUser.getEmail();

    setEmpId(mainUser);
    
	if (mainUser.getType().ToUpper().Equals("ADMIN")){
		this.rdoAdmin.Checked = true;
	}else if (mainUser.getType().ToUpper().Equals("USER")){
		this.rdoUser.Checked = true;
	}
}

private void GetFieldsData(User objUser){
	objUser.setLoginName(txtUserName.Text.Trim()); 
	objUser.setFirstName(txtFirstName.Text.Trim());
	objUser.setLastName(txtLastName.Text.Trim());
	objUser.setEmail(txtEmail.Text.Trim());
	objUser.setPassword(txtPassword.Text.Trim());
	objUser.setType((rdoAdmin.Checked)?"ADMIN":"USER");

    objUser.EmpId = getEmpId();

}

private void 
FormUserAdm_Load(object sender, System.EventArgs e){	
	//this.BackColor =  (System.Drawing.Color.FromArgb(216,216,197));
	//InitialControls();
	LoadData();
	//FormatDataGrid();
}

private 
void FormUserAdm_Closing(object sender, System.ComponentModel.CancelEventArgs e){
	if (this.blnInsert == true || this.blnEdit == true){
		MessageBox.Show("   Please save your modification before exit!   ","Save work",MessageBoxButtons.OK,MessageBoxIcon.Stop);
		e.Cancel = true;
		return;
	}
}
/*
private 
void btnLast_Click(object sender, System.EventArgs e){
	this.mintPageCurrent = this.mintPageTotal;
	BindGridPager();
}
*/
/*
private void btnNext_Click(object sender, System.EventArgs e){
	this.mintPageCurrent += 1;
	if(this.mintPageCurrent > this.mintPageTotal){
		this.mintPageCurrent = this.mintPageTotal;
	}

	BindGridPager();
}
*/
/*
private void btnPrevious_Click(object sender, System.EventArgs e){
	this.mintPageCurrent -= 1;
	if(this.mintPageCurrent < 1){
		this.mintPageCurrent = 1;
	}
	BindGridPager();
}
*/
/*
private void btnFirst_Click(object sender, System.EventArgs e){
	this.mintPageCurrent = 1;
	BindGridPager();
}
*/
private void InitialControls(){
	//initial data grid
	DataGridTableStyle ts = new DataGridTableStyle();
	ts.MappingName = "User";

	DataGridColumnStyle col = new DataGridNoActiveCellColumn();

	col.MappingName = "UserID";
	col.HeaderText  = "User ID";
	col.Width = 0;				     //Hide Id from users

	ts.GridColumnStyles.Add(col);

	col = new DataGridNoActiveCellColumn();
	col.MappingName = "LoginName";
	col.HeaderText  = "User Name";
	col.Width = 120;

	ts.GridColumnStyles.Add(col);

	col = new DataGridNoActiveCellColumn();
	col.MappingName = "FirstName";
	col.HeaderText  = "First Name";
	col.Width = 120;

	ts.GridColumnStyles.Add(col);

	col = new DataGridNoActiveCellColumn();
	col.MappingName = "LastName";
	col.HeaderText  = "Last Name";
	col.Width = 120;

	ts.GridColumnStyles.Add(col);


	col = new DataGridNoActiveCellColumn();

	col.MappingName = "Email";
	col.HeaderText = "Email";
	col.Width = 300;

	ts.GridColumnStyles.Add(col);

	dgCollection.TableStyles.Add(ts);
	dgCollection.AllowSorting = true;

	//initial page
	this.mintPageCurrent = 1;
	this.mintPageSize = 10;
	this.mstrSort = "";
	this.mstrSortBy = "";
}

private 
void FormatDataGrid(){
	Nujit.NujitERP.ClassLib.CustomDataGrid.DataGridUtils.FormatDG(this.dgCollection);
}

private
void LoadData(){
    loadEmployees();
	dataTable = new DataTable();
	dataTable.Columns.Add(new DataColumn("UserID", typeof(string)));
	dataTable.Columns.Add(new DataColumn("LoginName", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Password", typeof(string)));
	dataTable.Columns.Add(new DataColumn("FirstName", typeof(string)));
	dataTable.Columns.Add(new DataColumn("LastName", typeof(string)));
	dataTable.Columns.Add(new DataColumn("Email", typeof(string)));
    dataTable.Columns.Add(new DataColumn("EmpId", typeof(string)));

	UserContainer userContainer = coreFactory.readUsers();
	for(int i = 0; i < userContainer.Count; i++){
		DataRow dataRow = dataTable.NewRow();
 		dataRow[0] = ((User)userContainer[i]).getUserID();
 		dataRow[1] = ((User)userContainer[i]).getLoginName();
 		dataRow[2] = ((User)userContainer[i]).getPassword();
 		dataRow[3] = ((User)userContainer[i]).getFirstName();
 		dataRow[4] = ((User)userContainer[i]).getLastName();
 		dataRow[5] = ((User)userContainer[i]).getEmail();
        dataRow[6] = ((User)userContainer[i]).EmpId;
		dataTable.Rows.Add(dataRow);
	}

	DataView dataView = new DataView(dataTable);
	dataView.AllowEdit = false;
	dataView.AllowDelete = false;
	dataView.AllowNew = false;

	//gmgm
	dgCollection.DataSource = dataView;
	dgCollection.DataSource = dataView;
	dgCollection.PreferredColumnWidth = 150;
	dgCollection.RowHeadersVisible = false;

	//Create a DataGridTableStyle object	
	DataGridTableStyle dgdtblStyle	= new DataGridTableStyle();
	//Set its properties
	dgdtblStyle.MappingName			= dataTable.TableName;//its table name of dataset
	dgCollection.TableStyles.Clear(); 
	dgCollection.TableStyles.Add(dgdtblStyle);
	dgdtblStyle.RowHeadersVisible	= true;
	dgdtblStyle.AllowSorting		= true;
	dgdtblStyle.PreferredRowHeight	= 22;
	GridColumnStylesCollection	colStyle;
	colStyle				= dgCollection.TableStyles[0].GridColumnStyles;		
	colStyle[0].Width      	= 50;
	colStyle[1].Width		= 80;
	colStyle[2].Width		= 80;
	colStyle[3].Width		= 100;
	colStyle[4].Width      	= 100;
	colStyle[5].Width		= 143;
    colStyle[6].Width		= 80;
	dgCollection.Refresh();
	this.SetButtons();    
}
	
	
	
//	mobjDataSet.Tables.Clear();
//	mobjDataSet.Tables.Add(dt);
//	
//	//bind data grid
////			this.dgCollection.SetDataBinding(this.mobjDataSet,"User"); 
//	this.dgCollection.DataMember = "User";
//	this.dgCollection.DataSource = mobjDataSet;
//
//	//no adding of new rows thru dataview...
//	CurrencyManager cm = (CurrencyManager)this.BindingContext[dgCollection.DataSource, dgCollection.DataMember];
//
////			((DataView)cm.List).AllowNew = false;
//	
//	this.mintTotalCount = dt.Rows.Count;
//
//	//bind grid
////			BindGridPager();
//
//	//this.SynFields();
//	this.SetButtons();
//}

/*
private void BindGridPager(){
	this.mintPageTotal = Convert.ToInt32(Math.Ceiling((double)this.mintTotalCount/(double)this.mintPageSize)); 
	if(this.mintPageTotal == 0) this.mintPageTotal = 1;
	if(this.mintPageCurrent < 1) this.mintPageCurrent = 1;
	if(this.mintPageTotal < 1) this.mintPageTotal = 1;
	if(this.mintPageCurrent > this.mintPageTotal) this.mintPageCurrent = this.mintPageTotal;
	int intFrom = (this.mintPageCurrent-1)*this.mintPageSize;
	int intTo = intFrom + this.mintPageSize;
	if(intTo >= mintTotalCount) intTo = this.mintTotalCount;
	string strFilter = "";
	DataView view = this.dataTable.DefaultView;
	view.Sort = this.SortExpression;

	for(int i=intFrom;i<intTo;i++){
		DataRow dr = view[i].Row;
		strFilter += "'"+ dr["LoginName"] + "',";
	}

	while(strFilter.EndsWith(",")){
		strFilter = strFilter.Substring(0,strFilter.Length-1);  
	}

	if(strFilter != ""){
		strFilter = "LoginName IN (" + strFilter + ")";
	}

	CurrencyManager cm = (CurrencyManager)this.BindingContext[dgCollection.DataSource, dgCollection.DataMember];       
	((DataView)cm.List).Sort = this.SortExpression;
	((DataView)cm.List).RowFilter = strFilter; 

	SetGridPagerButtons();

	//set button
	if(dgCollection.CurrentRowIndex >= 0){
		dgCollection.Select(dgCollection.CurrentRowIndex);
		btnEdit.Enabled = true;
		btnDelete.Enabled = true;
	}else{
		btnEdit.Enabled = false;
		btnDelete.Enabled = false;
	}
}
*/
/*
private void SetGridPagerButtons(){
	this.btnFirst.Enabled		= false; 
	this.btnPrevious.Enabled	= false;
	this.btnNext.Enabled		= false;
	this.btnLast.Enabled		= false;

	if(this.mintPageCurrent > 1)
	{
		btnFirst.Enabled		= true;
		btnPrevious.Enabled		= true;
	}

	if (this.mintPageCurrent < this.mintPageTotal){
		this.btnNext.Enabled = true;
		this.btnLast.Enabled = true;
	}

	lblPageCurrent.Text = this.mintPageCurrent.ToString();
	lblPageTotal.Text   = this.mintPageTotal.ToString();  
}
*/

private void dgCollection_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e){
	System.Drawing.Point pt = new Point(e.X, e.Y); 

	DataGrid.HitTestInfo hti = dgCollection.HitTest(pt); 

	if(hti.Type == DataGrid.HitTestType.ColumnHeader){ 
		string s = this.dataTable.Columns[hti.Column].ToString();

		if(s != this.mstrSort){
			this.mstrSortBy = "";
		}else{
			if(this.mstrSortBy == null){
				this.mstrSortBy = "";
			}else if(this.mstrSortBy == ""){	
				this.mstrSortBy = "DESC";
			}else{
				this.mstrSortBy = "";
			}
		}

		this.mstrSort = s;
		this.mintPageCurrent = 1;
//		BindGridPager();
	}
	this.SynFields();
}

private void btnClose_Click(object sender, System.EventArgs e){ this.Close(); }

public FormUserAdm(){
	InitializeComponent();

    this.employeeContainer = coreFactory.createEmployeeContainer();
	InitialControls();
}

protected override void Dispose( bool disposing ){
	base.Dispose( disposing );
}

#region Windows Form Designer generated code

private void InitializeComponent(){
            this.components = new System.ComponentModel.Container();
            this.dgCollection = new Nujit.NujitERP.ClassLib.CustomDataGrid.SingleSelectDataGrid();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblType = new System.Windows.Forms.Label();
            this.grpBoxtype = new System.Windows.Forms.GroupBox();
            this.rdoUser = new System.Windows.Forms.RadioButton();
            this.rdoAdmin = new System.Windows.Forms.RadioButton();
            this.txtRetypePassword = new System.Windows.Forms.TextBox();
            this.lblRetypePassword = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.errorProviderUser = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDefaults = new System.Windows.Forms.Button();
            this.employeeComboBox = new System.Windows.Forms.ComboBox();
            this.employeeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgCollection)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpBoxtype.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUser)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCollection
            // 
            this.dgCollection.AlternatingBackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.dgCollection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgCollection.DataMember = "";
            this.dgCollection.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgCollection.Location = new System.Drawing.Point(12, 16);
            this.dgCollection.Name = "dgCollection";
            this.dgCollection.Size = new System.Drawing.Size(650, 336);
            this.dgCollection.TabIndex = 0;
            this.dgCollection.CurrentCellChanged += new System.EventHandler(this.dgCollection_Click);
            this.dgCollection.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dgCollection_Navigate);
            this.dgCollection.Click += new System.EventHandler(this.dgCollection_Click);
            this.dgCollection.DoubleClick += new System.EventHandler(this.dgCollection_Click);
            this.dgCollection.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgCollection_MouseUp);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Location = new System.Drawing.Point(338, 358);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 24);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(418, 358);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 24);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(490, 358);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 24);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Location = new System.Drawing.Point(490, 358);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 24);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(570, 358);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 24);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.Location = new System.Drawing.Point(418, 358);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(72, 24);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.employeeComboBox);
            this.groupBox2.Controls.Add(this.employeeLabel);
            this.groupBox2.Controls.Add(this.lblType);
            this.groupBox2.Controls.Add(this.grpBoxtype);
            this.groupBox2.Controls.Add(this.txtRetypePassword);
            this.groupBox2.Controls.Add(this.lblRetypePassword);
            this.groupBox2.Controls.Add(this.lblPassword);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.lblUserName);
            this.groupBox2.Controls.Add(this.txtUserName);
            this.groupBox2.Controls.Add(this.txtLastName);
            this.groupBox2.Controls.Add(this.lblLastName);
            this.groupBox2.Controls.Add(this.txtFirstName);
            this.groupBox2.Controls.Add(this.lblFirstName);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.lblEmail);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(32, 400);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 176);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(283, 18);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(100, 23);
            this.lblType.TabIndex = 40;
            this.lblType.Text = "User type";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblType.Visible = false;
            // 
            // grpBoxtype
            // 
            this.grpBoxtype.Controls.Add(this.rdoUser);
            this.grpBoxtype.Controls.Add(this.rdoAdmin);
            this.grpBoxtype.Location = new System.Drawing.Point(395, 11);
            this.grpBoxtype.Name = "grpBoxtype";
            this.grpBoxtype.Size = new System.Drawing.Size(144, 28);
            this.grpBoxtype.TabIndex = 1;
            this.grpBoxtype.TabStop = false;
            this.grpBoxtype.Visible = false;
            // 
            // rdoUser
            // 
            this.rdoUser.Checked = true;
            this.rdoUser.Location = new System.Drawing.Point(80, 8);
            this.rdoUser.Name = "rdoUser";
            this.rdoUser.Size = new System.Drawing.Size(48, 18);
            this.rdoUser.TabIndex = 1;
            this.rdoUser.TabStop = true;
            this.rdoUser.Text = "User";
            // 
            // rdoAdmin
            // 
            this.rdoAdmin.Location = new System.Drawing.Point(8, 8);
            this.rdoAdmin.Name = "rdoAdmin";
            this.rdoAdmin.Size = new System.Drawing.Size(56, 18);
            this.rdoAdmin.TabIndex = 0;
            this.rdoAdmin.Text = "Admin";
            // 
            // txtRetypePassword
            // 
            this.txtRetypePassword.Location = new System.Drawing.Point(395, 43);
            this.txtRetypePassword.MaxLength = 10;
            this.txtRetypePassword.Name = "txtRetypePassword";
            this.txtRetypePassword.PasswordChar = '*';
            this.txtRetypePassword.Size = new System.Drawing.Size(144, 20);
            this.txtRetypePassword.TabIndex = 3;
            // 
            // lblRetypePassword
            // 
            this.lblRetypePassword.Location = new System.Drawing.Point(291, 43);
            this.lblRetypePassword.Name = "lblRetypePassword";
            this.lblRetypePassword.Size = new System.Drawing.Size(96, 20);
            this.lblRetypePassword.TabIndex = 36;
            this.lblRetypePassword.Text = "Retype Password";
            this.lblRetypePassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(19, 44);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(91, 20);
            this.lblPassword.TabIndex = 35;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(115, 44);
            this.txtPassword.MaxLength = 10;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(144, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(3, 18);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(100, 23);
            this.lblUserName.TabIndex = 33;
            this.lblUserName.Text = "User Name";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(115, 19);
            this.txtUserName.MaxLength = 10;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(144, 20);
            this.txtUserName.TabIndex = 0;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(115, 99);
            this.txtLastName.MaxLength = 30;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(208, 20);
            this.txtLastName.TabIndex = 5;
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(43, 99);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(64, 20);
            this.lblLastName.TabIndex = 30;
            this.lblLastName.Text = "Last Name";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(115, 75);
            this.txtFirstName.MaxLength = 30;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(208, 20);
            this.txtFirstName.TabIndex = 4;
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(27, 75);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(80, 20);
            this.lblFirstName.TabIndex = 28;
            this.lblFirstName.Text = "First Name";
            this.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(115, 123);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(208, 20);
            this.txtEmail.TabIndex = 6;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(27, 123);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(80, 20);
            this.lblEmail.TabIndex = 25;
            this.lblEmail.Text = "Email Address";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // errorProviderUser
            // 
            this.errorProviderUser.ContainerControl = this;
            // 
            // btnDefaults
            // 
            this.btnDefaults.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDefaults.Location = new System.Drawing.Point(250, 358);
            this.btnDefaults.Name = "btnDefaults";
            this.btnDefaults.Size = new System.Drawing.Size(72, 24);
            this.btnDefaults.TabIndex = 10;
            this.btnDefaults.Text = "Defaults";
            this.btnDefaults.Click += new System.EventHandler(this.btnDefaults_Click);
            // 
            // employeeComboBox
            // 
            this.employeeComboBox.Location = new System.Drawing.Point(395, 76);
            this.employeeComboBox.Name = "employeeComboBox";
            this.employeeComboBox.Size = new System.Drawing.Size(215, 21);
            this.employeeComboBox.TabIndex = 42;
            // 
            // employeeLabel
            // 
            this.employeeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeLabel.Location = new System.Drawing.Point(323, 76);
            this.employeeLabel.Name = "employeeLabel";
            this.employeeLabel.Size = new System.Drawing.Size(68, 20);
            this.employeeLabel.TabIndex = 41;
            this.employeeLabel.Text = "Employee";
            this.employeeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormUserAdm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(696, 584);
            this.Controls.Add(this.btnDefaults);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgCollection);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormUserAdm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Management";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormUserAdm_Closing);
            this.Load += new System.EventHandler(this.FormUserAdm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCollection)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpBoxtype.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUser)).EndInit();
            this.ResumeLayout(false);

}

#endregion


private void btnAdd_Click(object sender, System.EventArgs e){
	ChangeFieldsEnableReadonlyStatus(true);
	
	this.ClearFields();
	SetDefaultValues();

	this.mainUser = coreFactory.createUser();
	
	this.blnEdit		= false;
	this.blnInsert		= true;
/*
	btnFirst.Enabled	= false;
	btnPrevious.Enabled = false;
	btnNext.Enabled		= false;
	btnLast.Enabled		= false;
*/
	btnAdd.Enabled		= false;
	btnDefaults.Enabled = true;

	btnEdit.Enabled     = false;
	btnEdit.Visible     = false;

	btnDelete.Visible   = false;
	btnDelete.Enabled   = false;

	btnSave.Visible     = true;
	btnSave.Enabled     = true;

	btnCancel.Visible	= true;
	btnCancel.Enabled	= true;

	btnClose.Enabled    = false;

	//Disable CpnsignerNumber field
	txtUserName.ReadOnly = false;
}


private void btnEdit_Click(object sender, System.EventArgs e){
	ChangeFieldsEnableReadonlyStatus(true);
			
	blnInsert			= false;
	blnEdit				= true;
/*
	btnFirst.Enabled    = false;
	btnPrevious.Enabled = false;
	btnNext.Enabled     = false;
	btnLast.Enabled     = false;
*/
	btnAdd.Enabled      = false;
	btnDefaults.Enabled = true;
	

	btnEdit.Enabled     = false;
	btnEdit.Visible     = false;

	btnDelete.Visible   = false;
	btnDelete.Enabled   = false;

	btnSave.Visible     = true;
	btnSave.Enabled     = true;

	btnCancel.Visible   = true;
	btnCancel.Enabled   = true;

	btnClose.Enabled	= false;

	txtUserName.ReadOnly =true;
}


private void btnCancel_Click(object sender, System.EventArgs e){
	this.blnEdit	= false;
	this.blnInsert  = false;

	this.btnDelete.Enabled  = false;

	btnDelete.Visible   = true;
	btnDelete.Enabled   = true;

	SynFields();
	SetButtons();

	//Disable user name  field
	txtUserName.ReadOnly =true;
}


private void dgCollection_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne){
	SynFields();
}


private void dgCollection_Click(object sender, System.EventArgs e){
	SynFields();
}


void SetButtons(){  
	ClearErrorStatus();
	ChangeFieldsEnableReadonlyStatus(false);

	btnClose.Enabled = true;
	btnDefaults.Enabled = false;

	if (dataTable.Rows.Count==0 ){  
/*		btnFirst.Enabled	= false;
		btnPrevious.Enabled = false;
		btnNext.Enabled		= false;
		btnLast.Enabled		= false;
*/
		btnAdd.Enabled		= true;
		btnAdd.Visible      = true;		

		btnEdit.Enabled     = false;
		btnEdit.Visible     = true;   //btnEdit.Visible     = true;
		
		btnDelete.Enabled   = false;
		btnDelete.Visible   = true;//false;
		

		btnSave.Visible     = false;
		btnSave.Enabled     = false;

		btnCancel.Visible   = false;
		btnCancel.Enabled   = false;

		btnClose.Enabled    = true;

		this.ClearFields();

		return;
	}

	if (dataTable.Rows.Count > 0){
		btnAdd.Enabled		= true;
		btnAdd.Visible		= true;

		btnEdit.Enabled     = true;
		btnEdit.Visible     = true;
//
//				btnDelete.Visible   = false;
//				btnDelete.Enabled   = false;
//
		btnDelete.Visible   = true;
		btnDelete.Enabled   = true;

		btnSave.Visible     = false;
		btnSave.Enabled     = false;

		btnCancel.Visible   = false;
		btnCancel.Enabled   = false;

		btnClose.Enabled    = true;	
		//				this.grpBoxDetail.Enabled = true;
	}

	SynFields();
	txtUserName.ReadOnly = true;
	return;

}
	
private void btnSave_Click(object sender, System.EventArgs e){
	//Validation
	if (!DataValidation()){
		MessageBox.Show("	Please input valid data!	","Invalid data", MessageBoxButtons.OK, MessageBoxIcon.Warning);	
		return;
	}
	
	User  objUserToUpdate = this.mainUser;

	GetFieldsData( objUserToUpdate);

	if (blnInsert == true &&  blnEdit == false){	
		coreFactory.writeUser(objUserToUpdate);
		this.ContentChanged = true;
		Utils.PopupMessage("	Add record successfully!	");
	}else if(blnEdit == true && blnInsert == false){	
		
		objUserToUpdate.setUserID(int.Parse((string)dataTable.Rows[dgCollection.CurrentRowIndex][0]));
		coreFactory.updateUser(objUserToUpdate);
		this.ContentChanged = true;
		Utils.PopupMessage("	Update record successfully!	");
	}

	blnInsert = false;
	blnEdit   = false;
		
	if (this.ContentChanged){
		LoadData();
	}
	this.SetButtons();

}


private void btnDelete_Click(object sender, System.EventArgs e){
	int intSelectedUserID  =  int.Parse((string)dataTable.Rows[dgCollection.CurrentRowIndex][0]);

	User objUserToDelete = coreFactory.createUser();

	objUserToDelete.setUserID(intSelectedUserID);

	if (DialogResult.No == MessageBox.Show(" Sure you want to delete this user?   \n","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)){
		return;
	}
	
	//delete record of consigner		
	this.coreFactory.deleteUser(objUserToDelete);
	Utils.PopupMessage("Delete record successfully!");
	LoadData();

}

private void SynFields(){
	
	if (this.dataTable.Rows.Count > 0){
		this.FillInTextBoxes();
		
		int intSelectedUserID = int.Parse((string)dataTable.Rows[dgCollection.CurrentRowIndex][0]);
		if (this.Operator   != null && intSelectedUserID == this.Operator.getUserID() ){
			this.btnDelete.Enabled = false;
		}else{
			this.btnDelete.Enabled = true;
		}
	}else{
		this.ClearFields();
		this.btnDelete.Enabled = false;
	}
}

private void SetDefaultValues(){
	this.rdoUser.Checked = true;
}

private void ChangeFieldsEnableReadonlyStatus(bool blnEnableStatus){
	System.Drawing.Color objBackColor =(!blnEnableStatus)?System.Drawing.Color.MintCream:System.Drawing.Color.White;
	foreach (Control objControl in this.groupBox2.Controls){
		if (objControl is TextBox){
			((TextBox)(objControl)).ReadOnly = !blnEnableStatus;
			objControl.BackColor =  objBackColor;									
		}else if (objControl is ComboBox){
			objControl.Enabled = blnEnableStatus;
			objControl.BackColor =  objBackColor;
		}
	}
}

private void txtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e){
	ValidateFirstName();
}


private bool ValidateFirstName(){
	bool blnResult = true;
	if (txtFirstName.Text == ""){
		errorProviderUser.SetError (txtFirstName,"Please enter first name");
		blnResult = false;
	}else{
		errorProviderUser.SetError (txtFirstName,"");
	}
		
	return blnResult;
}

private void txtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e){
	ValidateLastName();
}

private bool ValidateLastName(){
	bool blnResult = true;
	if (txtLastName.Text == ""){
		errorProviderUser.SetError (txtLastName,"Please enter last name");
		blnResult = false;
	}else{
		errorProviderUser.SetError (txtLastName,"");
	}
		
	return blnResult;
}


private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e){
	ValidateEmail();
}

private bool ValidateEmail(){
	bool blnResult = true;
	if (txtEmail.Text == ""){
		errorProviderUser.SetError (txtEmail,"Please enter email account");
		blnResult = false;
	}else if (!( Utils.RegexCheck(txtEmail.Text,RegexType.Email))){
		errorProviderUser.SetError (txtEmail,"Email account isn't in correct format");
		blnResult = false;
	}else{
		errorProviderUser.SetError (txtEmail,"");
	}
		
	return blnResult;
}

private void txtUserName_Validating(object sender, System.ComponentModel.CancelEventArgs e){
	ValidateUserName();
}

private bool ValidateUserName(){
	string strToCheck     = txtUserName.Text.Trim();
	bool blnResult = true;
	
	if (strToCheck == ""){
		errorProviderUser.SetError (txtUserName,"Please enter a unique user name");
		blnResult = false;
	}else{
		if (coreFactory.existsUserByName(strToCheck)){
			errorProviderUser.SetError (txtUserName,"This user name is used, choose another name please");
			blnResult = false;
		}
	}
	return	blnResult;
}

private bool ValidatePassword(){
	bool blnResult = true;
	if (txtPassword.Text == ""){
		errorProviderUser.SetError(txtPassword,"Please enter the password");
		blnResult = false;
	}else{
		errorProviderUser.SetError(txtPassword,"");
	}
	return blnResult;
}

private void txtRetypePassword_Validating(object sender, System.ComponentModel.CancelEventArgs e){
	ValidateRetypePassword();
}

private bool ValidateRetypePassword(){
	bool blnResult = true;
	if ( txtRetypePassword.Text == ""){
		errorProviderUser.SetError(txtRetypePassword,"Please re-enter the password");
		blnResult = false;
	}else if ( !txtRetypePassword.Text.Trim().Equals(txtPassword.Text.Trim())){
		errorProviderUser.SetError(txtRetypePassword,"Passwords don't match, please enter it again ");
		txtRetypePassword.Text = "";
		blnResult = false;
	}else{
		errorProviderUser.SetError(txtRetypePassword,"");
	}
	return blnResult;
}

private void ClearErrorStatus(){
	errorProviderUser.SetError(txtUserName,"");
	errorProviderUser.SetError(txtFirstName,"");
	errorProviderUser.SetError(txtLastName,"");
	errorProviderUser.SetError(txtPassword,"");
	errorProviderUser.SetError(txtEmail,"");
	errorProviderUser.SetError(txtRetypePassword,"");
}

private bool DataValidation(){
	bool blnResult = true;
	if (blnInsert)
		blnResult = this.ValidateUserName()			&& blnResult ;
	blnResult = this.ValidatePassword()			&& blnResult ;
	blnResult = this.ValidateRetypePassword()	&& blnResult ;
	blnResult = this.ValidateEmail()            && blnResult ;
	return blnResult;
}

private void btnDefaults_Click(object sender, System.EventArgs e)
{
	FormEditUserSingin formEditUserSingin = new FormEditUserSingin(mainUser);
	formEditUserSingin.ShowDialog();

	if (formEditUserSingin.DialogResult == DialogResult.OK)
		mainUser= formEditUserSingin.getUser();		
}

private 
void loadEmployees(){
    try{        
        EmployeeContainer   employeeContainerAux = coreFactory.readEmployeeByFilters("","","",Constants.STATUS_ACTIVE,0,"",-1,false,true,0);
        Employee            employee=coreFactory.createEmployee();
        int                 imaxLen=10;

        employeeContainer = coreFactory.createEmployeeContainer();

        employee.FirstName = "None";
        employeeContainer.Add(employee);
        foreach(Employee employeeAux in employeeContainerAux)
            employeeContainer.Add(employeeAux);
        
        employeeComboBox.Items.Clear();    
	    for(int i = 0; i < employeeContainer.Count; i++){
            employee = employeeContainer[i];
            employeeComboBox.Items.Add(StringUtil.AddSpaces(employee.Id, imaxLen, false) + "-" + employee.FullName);            
        }        
    }catch(NujitException ne){	
		FormException formException = new FormException(ne);
        formException.ShowDialog();
	}
}

private
bool setEmpId(User mainUser){
    bool    bresult=false;
    try{
        int     indexEmpId = -1;

        for(int i = 0; !bresult && i < employeeContainer.Count; i++){
            Employee employee = employeeContainer[i];
            if (employee.Id.ToUpper().Equals(mainUser.EmpId.ToUpper())){
                indexEmpId=i;
                bresult=true;
            } 
        }     

        if (indexEmpId < 0)
            indexEmpId=0;
        if (employeeComboBox.Items.Count > indexEmpId)
            employeeComboBox.SelectedIndex= indexEmpId;

    }catch(NujitException ne){	
		FormException formException = new FormException(ne);
        formException.ShowDialog();
	}

    return bresult;
}

private
string getEmpId(){
    string sempId="";
    try{
        int     indexEmpId = employeeComboBox.SelectedIndex;

        if (employeeContainer.Count > indexEmpId){
            Employee employee =  employeeContainer[indexEmpId];
            sempId= employee.Id;
        }      

    }catch(NujitException ne){	
		FormException formException = new FormException(ne);
        formException.ShowDialog();
	}

    return sempId;
}

        /*
public
EmployeeContainer loadEmployeeCombo(ComboBox comboBox,string sid="",string firstName="",string lastName="",string status=Constants.STATUS_ACTIVE,int iassignShift=0,string sdept="",int rows=0){
    EmployeeContainer employeeContainer = coreFactory.createEmployeeContainer();
    try { 
        employeeContainer = coreFactory.readEmployeeByFilters(sid, firstName, lastName, status, iassignShift, sdept, false,rows);
        ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem> list = new ObservableCollection<Nujit.NujitWms.WinForms.Util.ComboBoxItem>();
        list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(StringUtil.AddSpaces("", 10, false) + "-"  + "All",""));

        foreach(Employee employee in employeeContainer)
            list.Add(new Nujit.NujitWms.WinForms.Util.ComboBoxItem(StringUtil.AddSpaces(employee.Id,10,false) + "-" + employee.FullName,employee.Id));

        setDataContextCombo(comboBox, list);        

    }catch (Exception ex){
        MessageBox.Show("loadEmployeeCombo Exception: " + ex.Message);
    }
    return employeeContainer;
}*/

}

}