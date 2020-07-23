using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.WinForms.SearchForms;
using Nujit.NujitERP.ClassLib.Common;
using System.Globalization;


namespace Nujit.NujitERP.WinForms.GeneralLedger{
	/// <summary>
	/// Summary description for CurrencyEditForm.
	/// </summary>
public class CurrencyDlyExcEditForm : System.Windows.Forms.Form	{

private System.Windows.Forms.GroupBox groupBox1;
private System.Windows.Forms.TextBox tBoxIdentification;
private System.Windows.Forms.GroupBox groupBox2;
private System.Windows.Forms.Button btnSave;
private System.Windows.Forms.Button btnClear;
private System.Windows.Forms.Button btnCancel;
private System.Windows.Forms.Button btnDelete;
/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;

private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private GLCurrencyDlyExc glCurrencyDlyExc = new GLCurrencyDlyExc();
private bool flgEdit = false;
private string user="";

private System.Windows.Forms.Button btnSchCurrencyDly;
private System.Windows.Forms.Label lCDEDb;
private System.Windows.Forms.Label lCDECompany;
private System.Windows.Forms.Label lCDECurrencyBase;
private System.Windows.Forms.Label lCDECurrencyCode;
private System.Windows.Forms.TextBox tBoxCurrBaseName;
private System.Windows.Forms.TextBox tBoxCompanyName;
private System.Windows.Forms.TextBox tBoxCurrCodeName;
private System.Windows.Forms.Button btnSchCurrCode;
private System.Windows.Forms.Button btnSchCurrBase;
private System.Windows.Forms.Button btnSchCompany;
private System.Windows.Forms.DateTimePicker dtpCDEStartingDate;
private System.Windows.Forms.DateTimePicker dtpCDEEndingDate;
private System.Windows.Forms.Label lEndDate;
private System.Windows.Forms.Label lCDEStartingDate;
private System.Windows.Forms.GroupBox groupBox3;
private System.Windows.Forms.Label lCDEDateCreated;
private System.Windows.Forms.DateTimePicker dtpCDEDateCreated;
private System.Windows.Forms.Label lCDEDateUpdated;
private System.Windows.Forms.Label lCDEUserCreated;
private System.Windows.Forms.TextBox tBoxCDEUserCreated;
private System.Windows.Forms.TextBox tBoxCDEUserUpdated;
    private System.Windows.Forms.TextBox tBoxCDECurencyBase;
    private System.Windows.Forms.TextBox tBoxCDECurencyCode;
    private System.Windows.Forms.Label lCDEUserUpdated;
    private System.Windows.Forms.Label lCDEExchangeRate;
    private NujitCustomWinControls.NumericTextBox ntbCDEExchangeRate;
    private System.Windows.Forms.ErrorProvider error;
    private System.Windows.Forms.DateTimePicker dtpCDEDateUpdated;
    private System.Windows.Forms.TextBox tBoxCDECompany;
    private System.Windows.Forms.TextBox tBoxCDEDb;
private CultureLocal culture = new CultureLocal(Culture.getCulture());


public CurrencyDlyExcEditForm(string user)		{
	
	InitializeComponent();
    showCulture();
    this.user = user;
   
}

/// <summary>
/// Clean up any resources being used.
/// </summary>
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
		private void InitializeComponent()
		{
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CurrencyDlyExcEditForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSchCurrencyDly = new System.Windows.Forms.Button();
            this.tBoxIdentification = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lCDEDb = new System.Windows.Forms.Label();
            this.tBoxCDEDb = new System.Windows.Forms.TextBox();
            this.lCDECompany = new System.Windows.Forms.Label();
            this.tBoxCDECurencyBase = new System.Windows.Forms.TextBox();
            this.lCDECurrencyBase = new System.Windows.Forms.Label();
            this.tBoxCDECurencyCode = new System.Windows.Forms.TextBox();
            this.lCDECurrencyCode = new System.Windows.Forms.Label();
            this.tBoxCurrBaseName = new System.Windows.Forms.TextBox();
            this.tBoxCompanyName = new System.Windows.Forms.TextBox();
            this.tBoxCurrCodeName = new System.Windows.Forms.TextBox();
            this.btnSchCurrCode = new System.Windows.Forms.Button();
            this.btnSchCurrBase = new System.Windows.Forms.Button();
            this.btnSchCompany = new System.Windows.Forms.Button();
            this.dtpCDEStartingDate = new System.Windows.Forms.DateTimePicker();
            this.dtpCDEEndingDate = new System.Windows.Forms.DateTimePicker();
            this.lEndDate = new System.Windows.Forms.Label();
            this.lCDEStartingDate = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tBoxCDEUserUpdated = new System.Windows.Forms.TextBox();
            this.lCDEUserUpdated = new System.Windows.Forms.Label();
            this.tBoxCDEUserCreated = new System.Windows.Forms.TextBox();
            this.lCDEUserCreated = new System.Windows.Forms.Label();
            this.lCDEDateUpdated = new System.Windows.Forms.Label();
            this.dtpCDEDateUpdated = new System.Windows.Forms.DateTimePicker();
            this.lCDEDateCreated = new System.Windows.Forms.Label();
            this.dtpCDEDateCreated = new System.Windows.Forms.DateTimePicker();
            this.lCDEExchangeRate = new System.Windows.Forms.Label();
            this.ntbCDEExchangeRate = new NujitCustomWinControls.NumericTextBox();
            this.error = new System.Windows.Forms.ErrorProvider();
            this.tBoxCDECompany = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSchCurrencyDly);
            this.groupBox1.Controls.Add(this.tBoxIdentification);
            this.groupBox1.Location = new System.Drawing.Point(8, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 48);
            this.groupBox1.TabIndex = 500;
            this.groupBox1.TabStop = false;
            // 
            // btnSchCurrencyDly
            // 
            this.btnSchCurrencyDly.Location = new System.Drawing.Point(392, 16);
            this.btnSchCurrencyDly.Name = "btnSchCurrencyDly";
            this.btnSchCurrencyDly.Size = new System.Drawing.Size(30, 16);
            this.btnSchCurrencyDly.TabIndex = 1;
            this.btnSchCurrencyDly.Text = "...";
            this.btnSchCurrencyDly.Click += new System.EventHandler(this.btnSchCurrencyDly_Click);
            // 
            // tBoxIdentification
            // 
            this.tBoxIdentification.Location = new System.Drawing.Point(16, 16);
            this.tBoxIdentification.Name = "tBoxIdentification";
            this.tBoxIdentification.ReadOnly = true;
            this.tBoxIdentification.Size = new System.Drawing.Size(352, 20);
            this.tBoxIdentification.TabIndex = 0;
            this.tBoxIdentification.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Location = new System.Drawing.Point(8, 416);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(432, 48);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(344, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabIndex = 64;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(264, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 63;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(104, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.TabIndex = 61;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(184, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.TabIndex = 62;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lCDEDb
            // 
            this.lCDEDb.Location = new System.Drawing.Point(8, 80);
            this.lCDEDb.Name = "lCDEDb";
            this.lCDEDb.Size = new System.Drawing.Size(72, 16);
            this.lCDEDb.TabIndex = 2;
            this.lCDEDb.Text = "Data Base";
            // 
            // tBoxCDEDb
            // 
            this.tBoxCDEDb.Location = new System.Drawing.Point(96, 76);
            this.tBoxCDEDb.MaxLength = 10;
            this.tBoxCDEDb.Name = "tBoxCDEDb";
            this.tBoxCDEDb.ReadOnly = true;
            this.tBoxCDEDb.Size = new System.Drawing.Size(304, 20);
            this.tBoxCDEDb.TabIndex = 5;
            this.tBoxCDEDb.Text = "";
            // 
            // lCDECompany
            // 
            this.lCDECompany.Location = new System.Drawing.Point(8, 108);
            this.lCDECompany.Name = "lCDECompany";
            this.lCDECompany.Size = new System.Drawing.Size(72, 16);
            this.lCDECompany.TabIndex = 6;
            this.lCDECompany.Text = "Company";
            // 
            // tBoxCDECurencyBase
            // 
            this.tBoxCDECurencyBase.Location = new System.Drawing.Point(96, 136);
            this.tBoxCDECurencyBase.MaxLength = 5;
            this.tBoxCDECurencyBase.Name = "tBoxCDECurencyBase";
            this.tBoxCDECurencyBase.ReadOnly = true;
            this.tBoxCDECurencyBase.Size = new System.Drawing.Size(64, 20);
            this.tBoxCDECurencyBase.TabIndex = 11;
            this.tBoxCDECurencyBase.Text = "";
            // 
            // lCDECurrencyBase
            // 
            this.lCDECurrencyBase.Location = new System.Drawing.Point(8, 140);
            this.lCDECurrencyBase.Name = "lCDECurrencyBase";
            this.lCDECurrencyBase.Size = new System.Drawing.Size(88, 16);
            this.lCDECurrencyBase.TabIndex = 8;
            this.lCDECurrencyBase.Text = "Currency Base";
            // 
            // tBoxCDECurencyCode
            // 
            this.tBoxCDECurencyCode.Location = new System.Drawing.Point(96, 256);
            this.tBoxCDECurencyCode.MaxLength = 5;
            this.tBoxCDECurencyCode.Name = "tBoxCDECurencyCode";
            this.tBoxCDECurencyCode.ReadOnly = true;
            this.tBoxCDECurencyCode.Size = new System.Drawing.Size(72, 20);
            this.tBoxCDECurencyCode.TabIndex = 31;
            this.tBoxCDECurencyCode.Text = "";
            // 
            // lCDECurrencyCode
            // 
            this.lCDECurrencyCode.Location = new System.Drawing.Point(8, 256);
            this.lCDECurrencyCode.Name = "lCDECurrencyCode";
            this.lCDECurrencyCode.Size = new System.Drawing.Size(88, 16);
            this.lCDECurrencyCode.TabIndex = 10;
            this.lCDECurrencyCode.Text = "Currency Code";
            // 
            // tBoxCurrBaseName
            // 
            this.tBoxCurrBaseName.Location = new System.Drawing.Point(168, 136);
            this.tBoxCurrBaseName.MaxLength = 15;
            this.tBoxCurrBaseName.Name = "tBoxCurrBaseName";
            this.tBoxCurrBaseName.ReadOnly = true;
            this.tBoxCurrBaseName.Size = new System.Drawing.Size(232, 20);
            this.tBoxCurrBaseName.TabIndex = 12;
            this.tBoxCurrBaseName.Text = "";
            // 
            // tBoxCompanyName
            // 
            this.tBoxCompanyName.Location = new System.Drawing.Point(168, 104);
            this.tBoxCompanyName.MaxLength = 15;
            this.tBoxCompanyName.Name = "tBoxCompanyName";
            this.tBoxCompanyName.ReadOnly = true;
            this.tBoxCompanyName.Size = new System.Drawing.Size(232, 20);
            this.tBoxCompanyName.TabIndex = 7;
            this.tBoxCompanyName.Text = "";
            // 
            // tBoxCurrCodeName
            // 
            this.tBoxCurrCodeName.Location = new System.Drawing.Point(176, 256);
            this.tBoxCurrCodeName.MaxLength = 15;
            this.tBoxCurrCodeName.Name = "tBoxCurrCodeName";
            this.tBoxCurrCodeName.ReadOnly = true;
            this.tBoxCurrCodeName.Size = new System.Drawing.Size(224, 20);
            this.tBoxCurrCodeName.TabIndex = 32;
            this.tBoxCurrCodeName.Text = "";
            // 
            // btnSchCurrCode
            // 
            this.btnSchCurrCode.Location = new System.Drawing.Point(408, 256);
            this.btnSchCurrCode.Name = "btnSchCurrCode";
            this.btnSchCurrCode.Size = new System.Drawing.Size(30, 16);
            this.btnSchCurrCode.TabIndex = 35;
            this.btnSchCurrCode.Text = "...";
            this.btnSchCurrCode.Click += new System.EventHandler(this.btnSchCurrCode_Click);
            // 
            // btnSchCurrBase
            // 
            this.btnSchCurrBase.Location = new System.Drawing.Point(408, 140);
            this.btnSchCurrBase.Name = "btnSchCurrBase";
            this.btnSchCurrBase.Size = new System.Drawing.Size(30, 16);
            this.btnSchCurrBase.TabIndex = 15;
            this.btnSchCurrBase.Text = "...";
            this.btnSchCurrBase.Click += new System.EventHandler(this.btnSchCurrBase_Click);
            // 
            // btnSchCompany
            // 
            this.btnSchCompany.Location = new System.Drawing.Point(408, 108);
            this.btnSchCompany.Name = "btnSchCompany";
            this.btnSchCompany.Size = new System.Drawing.Size(30, 16);
            this.btnSchCompany.TabIndex = 10;
            this.btnSchCompany.Text = "...";
            this.btnSchCompany.Click += new System.EventHandler(this.btnSchCompany_Click);
            // 
            // dtpCDEStartingDate
            // 
            this.dtpCDEStartingDate.Location = new System.Drawing.Point(96, 168);
            this.dtpCDEStartingDate.Name = "dtpCDEStartingDate";
            this.dtpCDEStartingDate.TabIndex = 20;
            // 
            // dtpCDEEndingDate
            // 
            this.dtpCDEEndingDate.Location = new System.Drawing.Point(96, 192);
            this.dtpCDEEndingDate.Name = "dtpCDEEndingDate";
            this.dtpCDEEndingDate.TabIndex = 25;
            // 
            // lEndDate
            // 
            this.lEndDate.Location = new System.Drawing.Point(8, 192);
            this.lEndDate.Name = "lEndDate";
            this.lEndDate.Size = new System.Drawing.Size(64, 16);
            this.lEndDate.TabIndex = 20;
            this.lEndDate.Text = "End Date";
            // 
            // lCDEStartingDate
            // 
            this.lCDEStartingDate.Location = new System.Drawing.Point(8, 168);
            this.lCDEStartingDate.Name = "lCDEStartingDate";
            this.lCDEStartingDate.Size = new System.Drawing.Size(64, 16);
            this.lCDEStartingDate.TabIndex = 21;
            this.lCDEStartingDate.Text = "Start Date";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tBoxCDEUserUpdated);
            this.groupBox3.Controls.Add(this.lCDEUserUpdated);
            this.groupBox3.Controls.Add(this.tBoxCDEUserCreated);
            this.groupBox3.Controls.Add(this.lCDEUserCreated);
            this.groupBox3.Controls.Add(this.lCDEDateUpdated);
            this.groupBox3.Controls.Add(this.dtpCDEDateUpdated);
            this.groupBox3.Controls.Add(this.lCDEDateCreated);
            this.groupBox3.Controls.Add(this.dtpCDEDateCreated);
            this.groupBox3.Location = new System.Drawing.Point(56, 280);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(344, 128);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            // 
            // tBoxCDEUserUpdated
            // 
            this.tBoxCDEUserUpdated.Location = new System.Drawing.Point(112, 96);
            this.tBoxCDEUserUpdated.Name = "tBoxCDEUserUpdated";
            this.tBoxCDEUserUpdated.ReadOnly = true;
            this.tBoxCDEUserUpdated.Size = new System.Drawing.Size(200, 20);
            this.tBoxCDEUserUpdated.TabIndex = 54;
            this.tBoxCDEUserUpdated.Text = "";
            // 
            // lCDEUserUpdated
            // 
            this.lCDEUserUpdated.Location = new System.Drawing.Point(32, 96);
            this.lCDEUserUpdated.Name = "lCDEUserUpdated";
            this.lCDEUserUpdated.Size = new System.Drawing.Size(80, 16);
            this.lCDEUserUpdated.TabIndex = 28;
            this.lCDEUserUpdated.Text = "User Updated";
            // 
            // tBoxCDEUserCreated
            // 
            this.tBoxCDEUserCreated.Location = new System.Drawing.Point(112, 72);
            this.tBoxCDEUserCreated.Name = "tBoxCDEUserCreated";
            this.tBoxCDEUserCreated.ReadOnly = true;
            this.tBoxCDEUserCreated.Size = new System.Drawing.Size(200, 20);
            this.tBoxCDEUserCreated.TabIndex = 53;
            this.tBoxCDEUserCreated.Text = "";
            // 
            // lCDEUserCreated
            // 
            this.lCDEUserCreated.Location = new System.Drawing.Point(32, 72);
            this.lCDEUserCreated.Name = "lCDEUserCreated";
            this.lCDEUserCreated.Size = new System.Drawing.Size(72, 16);
            this.lCDEUserCreated.TabIndex = 26;
            this.lCDEUserCreated.Text = "User Created";
            // 
            // lCDEDateUpdated
            // 
            this.lCDEDateUpdated.Location = new System.Drawing.Point(32, 48);
            this.lCDEDateUpdated.Name = "lCDEDateUpdated";
            this.lCDEDateUpdated.Size = new System.Drawing.Size(80, 16);
            this.lCDEDateUpdated.TabIndex = 25;
            this.lCDEDateUpdated.Text = "Date Updated";
            // 
            // dtpCDEDateUpdated
            // 
            this.dtpCDEDateUpdated.Enabled = false;
            this.dtpCDEDateUpdated.Location = new System.Drawing.Point(112, 48);
            this.dtpCDEDateUpdated.Name = "dtpCDEDateUpdated";
            this.dtpCDEDateUpdated.TabIndex = 52;
            // 
            // lCDEDateCreated
            // 
            this.lCDEDateCreated.Location = new System.Drawing.Point(32, 24);
            this.lCDEDateCreated.Name = "lCDEDateCreated";
            this.lCDEDateCreated.Size = new System.Drawing.Size(72, 16);
            this.lCDEDateCreated.TabIndex = 23;
            this.lCDEDateCreated.Text = "Date Created";
            // 
            // dtpCDEDateCreated
            // 
            this.dtpCDEDateCreated.Enabled = false;
            this.dtpCDEDateCreated.Location = new System.Drawing.Point(112, 24);
            this.dtpCDEDateCreated.Name = "dtpCDEDateCreated";
            this.dtpCDEDateCreated.TabIndex = 51;
            // 
            // lCDEExchangeRate
            // 
            this.lCDEExchangeRate.Location = new System.Drawing.Point(8, 224);
            this.lCDEExchangeRate.Name = "lCDEExchangeRate";
            this.lCDEExchangeRate.Size = new System.Drawing.Size(88, 16);
            this.lCDEExchangeRate.TabIndex = 23;
            this.lCDEExchangeRate.Text = "Excahnge Rate";
            // 
            // ntbCDEExchangeRate
            // 
            this.ntbCDEExchangeRate.Location = new System.Drawing.Point(96, 224);
            this.ntbCDEExchangeRate.Maximum = new System.Decimal(new int[] {
                                                                               1661992960,
                                                                               1808227885,
                                                                               5,
                                                                               0});
            this.ntbCDEExchangeRate.MaxPrecision = 8;
            this.ntbCDEExchangeRate.Minimum = new System.Decimal(new int[] {
                                                                               0,
                                                                               0,
                                                                               0,
                                                                               0});
            this.ntbCDEExchangeRate.Name = "ntbCDEExchangeRate";
            this.ntbCDEExchangeRate.Size = new System.Drawing.Size(200, 20);
            this.ntbCDEExchangeRate.TabIndex = 30;
            this.ntbCDEExchangeRate.Value = new System.Decimal(new int[] {
                                                                             0,
                                                                             0,
                                                                             0,
                                                                             0});
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // tBoxCDECompany
            // 
            this.tBoxCDECompany.Location = new System.Drawing.Point(96, 104);
            this.tBoxCDECompany.MaxLength = 10;
            this.tBoxCDECompany.Name = "tBoxCDECompany";
            this.tBoxCDECompany.ReadOnly = true;
            this.tBoxCDECompany.Size = new System.Drawing.Size(64, 20);
            this.tBoxCDECompany.TabIndex = 6;
            this.tBoxCDECompany.Text = "";
            // 
            // CurrencyDlyExcEditForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(464, 478);
            this.Controls.Add(this.ntbCDEExchangeRate);
            this.Controls.Add(this.lCDEExchangeRate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lCDEStartingDate);
            this.Controls.Add(this.lEndDate);
            this.Controls.Add(this.dtpCDEEndingDate);
            this.Controls.Add(this.dtpCDEStartingDate);
            this.Controls.Add(this.btnSchCompany);
            this.Controls.Add(this.btnSchCurrBase);
            this.Controls.Add(this.btnSchCurrCode);
            this.Controls.Add(this.tBoxCurrCodeName);
            this.Controls.Add(this.tBoxCompanyName);
            this.Controls.Add(this.tBoxCurrBaseName);
            this.Controls.Add(this.tBoxCDECurencyCode);
            this.Controls.Add(this.lCDECurrencyCode);
            this.Controls.Add(this.tBoxCDECurencyBase);
            this.Controls.Add(this.lCDECurrencyBase);
            this.Controls.Add(this.tBoxCDECompany);
            this.Controls.Add(this.lCDECompany);
            this.Controls.Add(this.tBoxCDEDb);
            this.Controls.Add(this.lCDEDb);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(472, 512);
            this.MinimumSize = new System.Drawing.Size(472, 512);
            this.Name = "CurrencyDlyExcEditForm";
            this.Text = "Currency Dayly Exchange";
            this.Load += new System.EventHandler(this.CurrencyDlyExcEditForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion


private void showCulture(){

    culture.setResource("Nujit.NujitERP.WinForms.GeneralLedger.Culture.CurrencyDlyExcEditForm",
						typeof(CurrencyDlyExcEditForm).Assembly);
	culture.setControlsCulture(this);

}

private void btnCancel_Click(object sender, System.EventArgs e){
    Close();
}

private void btnClear_Click(object sender, System.EventArgs e){

    initializeScreen();
}

private void initializeScreen(){
    clearErrors();
    this.tBoxCDECompany.Text = "";
    this.tBoxCDECurencyBase.Text ="";
    this.tBoxCDECurencyCode.Text ="";
    this.tBoxCDEUserCreated.Text = this.user;
    this.tBoxCDEUserUpdated.Text ="";
    this.tBoxCompanyName.Text ="";
    this.tBoxCurrBaseName.Text ="";
    this.tBoxCurrCodeName.Text ="";
    this.tBoxCDEDb.Text = Configuration.DftDataBase;
    this.tBoxIdentification.Text ="";
    this.btnDelete.Enabled = false;
    this.ntbCDEExchangeRate.Value =0;
    this.dtpCDEDateCreated.Value = System.DateTime.Today;
    this.dtpCDEDateUpdated.Value = System.DateTime.Today;
    this.dtpCDEStartingDate.Value = System.DateTime.Today;
    this.dtpCDEStartingDate.Enabled = true;
    this.dtpCDEEndingDate.Value = System.DateTime.Today;
    this.dtpCDEEndingDate.Enabled = true;
    this.flgEdit = false;
    
 }


private void btnDelete_Click(object sender, System.EventArgs e){
    
    DialogResult deleteConfirm = MessageBox.Show(culture.getText("message1"), culture.getText("message2"), 
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    if (deleteConfirm == DialogResult.No)
	    return;
    if (delete())
        initializeScreen();
}

private bool delete(){
    try{
            setObject();
            coreFactory.deleteGLCurrencyDlyExc(glCurrencyDlyExc.getDb(),glCurrencyDlyExc.getCompany(),
                                              glCurrencyDlyExc.getStartingDate(),glCurrencyDlyExc.getEndingDate(),
                                              glCurrencyDlyExc.getCurrencyBase());
            return true;
    }catch(NujitException nu){				
		    FormException formException = new FormException(nu);
		    formException.ShowDialog();
            return false;
    }

}


private void btnSave_Click(object sender, System.EventArgs e){

     if (save())
        initializeScreen(); 
}
   
private bool save(){
    if (dataOk()){
        setObject();
        try{
            if (flgEdit){ //is an update
                glCurrencyDlyExc.setUserUpdated(user); 
                glCurrencyDlyExc.setDateUpdated(System.DateTime.Today);
                coreFactory.updateGLCurrencyDlyExc(glCurrencyDlyExc);
                return true;
            }else{ // is a new record
                if (coreFactory.existsGLCurrencyDlyExc(glCurrencyDlyExc.getDb(),glCurrencyDlyExc.getCompany(),
                                                       glCurrencyDlyExc.getStartingDate(),glCurrencyDlyExc.getEndingDate(),
                                                       glCurrencyDlyExc.getCurrencyBase())){
                    MessageBox.Show(culture.getText("message3"));
                    return false;
                }else{
                        coreFactory.writeGLCurrencyDlyExc(glCurrencyDlyExc);
                        return true;
                    }
            }
        }catch(NujitException nu){				
		    FormException formException = new FormException(nu);
		    formException.ShowDialog();
		    initializeScreen();
		    return false;
	    }
    } else
        return false;
}

private bool dataOk(){

    clearErrors();
    if (this.tBoxCDECompany.Text.Equals("")) {
        error.SetError(tBoxCDECompany,culture.getText("emptyValue"));
        return false;
    }
    if (this.tBoxCDECurencyBase.Text.Equals("")){
        error.SetError(tBoxCDECurencyBase,culture.getText("emptyValue"));
        return false;
    }
    return true;
}
   
private void clearErrors(){
   
   error.SetError(tBoxCDECurencyBase,"");
   error.SetError(tBoxCDECompany,"");
}

   
private void setObject(){
    this.glCurrencyDlyExc.setCompany(int.Parse(tBoxCDECompany.Text));
    this.glCurrencyDlyExc.setCurrencyBase(this.tBoxCDECurencyBase.Text);
    this.glCurrencyDlyExc.setCurrencyCode(this.tBoxCDECurencyCode.Text);
    this.glCurrencyDlyExc.setDateCreated(this.dtpCDEDateCreated.Value);
    this.glCurrencyDlyExc.setDateUpdated(this.dtpCDEDateUpdated.Value);
    this.glCurrencyDlyExc.setDb(this.tBoxCDEDb.Text);
    this.glCurrencyDlyExc.setEndingDate(this.dtpCDEEndingDate.Value);
    this.glCurrencyDlyExc.setExchangeRate(this.ntbCDEExchangeRate.Value);
    this.glCurrencyDlyExc.setStartingDate(this.dtpCDEStartingDate.Value);
    this.glCurrencyDlyExc.setUserCreated(this.tBoxCDEUserCreated.Text);
    this.glCurrencyDlyExc.setUserUpdated(this.tBoxCDEUserUpdated.Text);
}

private void btnSchCurrencyDly_Click(object sender, System.EventArgs e){
    searchCurrDly();
}

private void searchCurrDly(){

    CurrencyDlyExcSearchForm currencyDlyExcSearchForm = new CurrencyDlyExcSearchForm(culture.getText("schCurrDly"));
    currencyDlyExcSearchForm.setBaseFilter(Configuration.DftDataBase);
    currencyDlyExcSearchForm.ShowDialog();
    if (currencyDlyExcSearchForm.DialogResult == DialogResult.OK){
		    string[] v = currencyDlyExcSearchForm.getSelected();
		    if (v != null){			
                this.tBoxCDEDb.Text = v[0];   
                this.tBoxCDECompany.Text = v[1];
                this.dtpCDEStartingDate.Value = DateUtil.parseDate(v[2],DateUtil.MMDDYYYY);
                this.dtpCDEEndingDate.Value = DateUtil.parseDate(v[3],DateUtil.MMDDYYYY); 
                this.tBoxCDECurencyBase.Text = v[4];
                this.ntbCDEExchangeRate.Value =decimal.Parse(v[5]);
                this.tBoxCDECurencyCode.Text = v[6];
                this.dtpCDEDateCreated.Value = DateUtil.parseDate(v[7],DateUtil.MMDDYYYY); 
                this.tBoxCDEUserCreated.Text = v[8];
                this.dtpCDEDateUpdated.Value = DateUtil.parseDate(v[9],DateUtil.MMDDYYYY); 
                this.tBoxCDEUserUpdated.Text = v[10];
    
    			this.flgEdit= true;
			    this.btnDelete.Enabled =true;
			    this.dtpCDEStartingDate.Enabled = false;
			    this.dtpCDEEndingDate.Enabled = false;
		    }
        }else{
	        initializeScreen();
   }

}

private void btnSchCompany_Click(object sender, System.EventArgs e){
    CompanySearchForm companySearchForm= new CompanySearchForm(culture.getText("schCompany"));
    companySearchForm.setBaseFilter(Configuration.DftDataBase);
    companySearchForm.ShowDialog();
    if (companySearchForm.DialogResult == DialogResult.OK){
		    string[] v = companySearchForm.getSelected();
		    if (v != null){			
               this.tBoxCDECompany.Text = v[1];
               this.tBoxCompanyName.Text = v[2];
		    }
    }
}

private void btnSchCurrBase_Click(object sender, System.EventArgs e){

 CurrencySearchForm currencySearchForm= new CurrencySearchForm(culture.getText("schCurr"));
 currencySearchForm.setBaseFilter(Configuration.DftDataBase);
 currencySearchForm.ShowDialog();
  if (currencySearchForm.DialogResult == DialogResult.OK){
		string[] v = currencySearchForm.getSelected();
		if (v != null){			
            this.tBoxCDECurencyBase.Text = v[1];
            this.tBoxCurrBaseName.Text = v[2];
		}
    }
}

private void btnSchCurrCode_Click(object sender, System.EventArgs e){

 CurrencySearchForm currencySearchForm= new CurrencySearchForm(culture.getText("schCurr"));
 currencySearchForm.setBaseFilter(Configuration.DftDataBase);
 currencySearchForm.ShowDialog();
  if (currencySearchForm.DialogResult == DialogResult.OK){
		string[] v = currencySearchForm.getSelected();
		if (v != null){			
            this.tBoxCDECurencyCode.Text = v[1];
            this.tBoxCurrCodeName.Text = v[2];
		}
    }
}

private void CurrencyDlyExcEditForm_Load(object sender, System.EventArgs e){

    initializeScreen();
}
    

}//end class
}//end namespace
