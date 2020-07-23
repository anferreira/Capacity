using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.WinForms.SearchForms;


namespace Nujit.NujitERP.WinForms.InventoryLayout{
	/// <summary>
	/// Summary description for CompanyEditForm.
	/// </summary>
public class CompanyEditForm : System.Windows.Forms.Form{
private System.Windows.Forms.Button btnCancel;
private System.Windows.Forms.Button btnOk;
private System.Windows.Forms.GroupBox gBoxCompData;
private System.Windows.Forms.TextBox tBoxDb;
private System.Windows.Forms.TextBox tBoxCurrCrdNoteNum;
private System.Windows.Forms.TextBox tBoxCurrQuoteNum;
private System.Windows.Forms.TextBox tBoxCurrBillLadNum;
private System.Windows.Forms.TextBox tBoxCurrInvoiceNum;
private System.Windows.Forms.TextBox tBoxCurrOrderNum;
private System.Windows.Forms.TextBox tBoxDescription;
private System.Windows.Forms.TextBox tBoxName;
private System.Windows.Forms.TextBox tBoxCompany;
private System.Windows.Forms.GroupBox gBoxCompValues;
/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;
private System.Windows.Forms.GroupBox gBoxData;
private System.Windows.Forms.Label lCompany;
private System.Windows.Forms.Label lDb;
private System.Windows.Forms.Label lDescription;
private System.Windows.Forms.Label lCurrQuoteNum;
private System.Windows.Forms.Label lName;
private System.Windows.Forms.Label lCurrOrderNum;
private System.Windows.Forms.Label lCurrInvoiceNum;
private System.Windows.Forms.Label lCurrBillLadNum;
private System.Windows.Forms.Label lCurrCreditNoteNum;

private int action;
private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private CultureLocal culture = new CultureLocal(Culture.getCulture());

private System.Windows.Forms.ErrorProvider error;




public CompanyEditForm(string title, int action,Company company){
//update = false  indicates that we are deleting the company
	
	InitializeComponent();
	this.showCulture();
	
	this.Text = title;
	if ((action.Equals(Constants.UPDATE)) ||(action.Equals(Constants.ADD)))
		setByUpdate(action);
	else
		setByDelete();
	this.action = action;   
	setCompanyInfo(company); 
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
	System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CompanyEditForm));
	this.lCompany = new System.Windows.Forms.Label();
    this.lDb = new System.Windows.Forms.Label();
    this.lDescription = new System.Windows.Forms.Label();
    this.lCurrQuoteNum = new System.Windows.Forms.Label();
    this.lName = new System.Windows.Forms.Label();
    this.lCurrOrderNum = new System.Windows.Forms.Label();
    this.lCurrInvoiceNum = new System.Windows.Forms.Label();
    this.lCurrBillLadNum = new System.Windows.Forms.Label();
    this.gBoxCompData = new System.Windows.Forms.GroupBox();
    this.tBoxCompany = new System.Windows.Forms.TextBox();
    this.tBoxDb = new System.Windows.Forms.TextBox();
    this.tBoxName = new System.Windows.Forms.TextBox();
    this.tBoxDescription = new System.Windows.Forms.TextBox();
    this.lCurrCreditNoteNum = new System.Windows.Forms.Label();
    this.btnCancel = new System.Windows.Forms.Button();
    this.btnOk = new System.Windows.Forms.Button();
    this.tBoxCurrCrdNoteNum = new System.Windows.Forms.TextBox();
    this.tBoxCurrQuoteNum = new System.Windows.Forms.TextBox();
    this.tBoxCurrBillLadNum = new System.Windows.Forms.TextBox();
    this.tBoxCurrInvoiceNum = new System.Windows.Forms.TextBox();
    this.tBoxCurrOrderNum = new System.Windows.Forms.TextBox();
    this.gBoxCompValues = new System.Windows.Forms.GroupBox();
    this.error = new System.Windows.Forms.ErrorProvider();
    this.gBoxData = new System.Windows.Forms.GroupBox();
    this.gBoxCompData.SuspendLayout();
    this.gBoxCompValues.SuspendLayout();
    this.gBoxData.SuspendLayout();
    this.SuspendLayout();
    // 
    // lCompany
    // 
    this.lCompany.Location = new System.Drawing.Point(208, 16);
    this.lCompany.Name = "lCompany";
    this.lCompany.Size = new System.Drawing.Size(56, 16);
    this.lCompany.TabIndex = 0;
    this.lCompany.Text = "Company";
    // 
    // lDb
    // 
    this.lDb.Location = new System.Drawing.Point(8, 16);
    this.lDb.Name = "lDb";
    this.lDb.Size = new System.Drawing.Size(72, 16);
    this.lDb.TabIndex = 1;
    this.lDb.Text = "Data Base";
    // 
    // lDescription
    // 
    this.lDescription.Location = new System.Drawing.Point(8, 48);
    this.lDescription.Name = "lDescription";
    this.lDescription.Size = new System.Drawing.Size(72, 16);
    this.lDescription.TabIndex = 2;
    this.lDescription.Text = "Description";
    // 
    // lCurrQuoteNum
    // 
    this.lCurrQuoteNum.Location = new System.Drawing.Point(8, 72);
    this.lCurrQuoteNum.Name = "lCurrQuoteNum";
    this.lCurrQuoteNum.Size = new System.Drawing.Size(96, 16);
    this.lCurrQuoteNum.TabIndex = 3;
    this.lCurrQuoteNum.Text = "Current Quote #";
    // 
    // lName
    // 
    this.lName.Location = new System.Drawing.Point(8, 16);
    this.lName.Name = "lName";
    this.lName.Size = new System.Drawing.Size(72, 16);
    this.lName.TabIndex = 4;
    this.lName.Text = "Name";
    // 
    // lCurrOrderNum
    // 
    this.lCurrOrderNum.Location = new System.Drawing.Point(8, 24);
    this.lCurrOrderNum.Name = "lCurrOrderNum";
    this.lCurrOrderNum.Size = new System.Drawing.Size(96, 16);
    this.lCurrOrderNum.TabIndex = 5;
    this.lCurrOrderNum.Text = "Current Order#";
    // 
    // lCurrInvoiceNum
    // 
    this.lCurrInvoiceNum.Location = new System.Drawing.Point(240, 24);
    this.lCurrInvoiceNum.Name = "lCurrInvoiceNum";
    this.lCurrInvoiceNum.Size = new System.Drawing.Size(112, 16);
    this.lCurrInvoiceNum.TabIndex = 6;
    this.lCurrInvoiceNum.Text = "Current Invoice#";
    // 
    // lCurrBillLadNum
    // 
    this.lCurrBillLadNum.Location = new System.Drawing.Point(8, 48);
    this.lCurrBillLadNum.Name = "lCurrBillLadNum";
    this.lCurrBillLadNum.Size = new System.Drawing.Size(112, 16);
    this.lCurrBillLadNum.TabIndex = 7;
    this.lCurrBillLadNum.Text = "Current Bill Lading #";
    // 
    // gBoxCompData
    // 
    this.gBoxCompData.Controls.Add(this.tBoxCompany);
    this.gBoxCompData.Controls.Add(this.tBoxDb);
    this.gBoxCompData.Controls.Add(this.lDb);
    this.gBoxCompData.Controls.Add(this.lCompany);
    this.gBoxCompData.Location = new System.Drawing.Point(8, 8);
    this.gBoxCompData.Name = "gBoxCompData";
    this.gBoxCompData.Size = new System.Drawing.Size(464, 48);
    this.gBoxCompData.TabIndex = 1;
    this.gBoxCompData.TabStop = false;
    // 
    // tBoxCompany
    // 
    this.tBoxCompany.Location = new System.Drawing.Point(280, 16);
    this.tBoxCompany.MaxLength = 15;
    this.tBoxCompany.Name = "tBoxCompany";
    this.tBoxCompany.Size = new System.Drawing.Size(128, 20);
    this.tBoxCompany.TabIndex = 10;
    this.tBoxCompany.Text = "";
    // 
    // tBoxDb
    // 
    this.tBoxDb.Location = new System.Drawing.Point(80, 16);
    this.tBoxDb.MaxLength = 10;
    this.tBoxDb.Name = "tBoxDb";
    this.tBoxDb.TabIndex = 9;
    this.tBoxDb.Text = "";
    // 
    // tBoxName
    // 
    this.tBoxName.Location = new System.Drawing.Point(96, 16);
    this.tBoxName.MaxLength = 30;
    this.tBoxName.Name = "tBoxName";
    this.tBoxName.Size = new System.Drawing.Size(312, 20);
    this.tBoxName.TabIndex = 20;
    this.tBoxName.Text = "";
    // 
    // tBoxDescription
    // 
    this.tBoxDescription.Location = new System.Drawing.Point(96, 40);
    this.tBoxDescription.MaxLength = 60;
    this.tBoxDescription.Multiline = true;
    this.tBoxDescription.Name = "tBoxDescription";
    this.tBoxDescription.Size = new System.Drawing.Size(312, 40);
    this.tBoxDescription.TabIndex = 30;
    this.tBoxDescription.Text = "";
    // 
    // lCurrCreditNoteNum
    // 
    this.lCurrCreditNoteNum.Location = new System.Drawing.Point(240, 48);
    this.lCurrCreditNoteNum.Name = "lCurrCreditNoteNum";
    this.lCurrCreditNoteNum.Size = new System.Drawing.Size(112, 16);
    this.lCurrCreditNoteNum.TabIndex = 8;
    this.lCurrCreditNoteNum.Text = "Current Credit Note #";
    // 
    // btnCancel
    // 
    this.btnCancel.Location = new System.Drawing.Point(304, 256);
    this.btnCancel.Name = "btnCancel";
    this.btnCancel.TabIndex = 90;
    this.btnCancel.Text = "Cancel";
    this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
    // 
    // btnOk
    // 
    this.btnOk.Location = new System.Drawing.Point(400, 256);
    this.btnOk.Name = "btnOk";
    this.btnOk.TabIndex = 100;
    this.btnOk.Text = "Ok";
    this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
    // 
    // tBoxCurrCrdNoteNum
    // 
    this.tBoxCurrCrdNoteNum.Location = new System.Drawing.Point(352, 40);
    this.tBoxCurrCrdNoteNum.MaxLength = 10;
    this.tBoxCurrCrdNoteNum.Name = "tBoxCurrCrdNoteNum";
    this.tBoxCurrCrdNoteNum.TabIndex = 70;
    this.tBoxCurrCrdNoteNum.Text = "0";
    // 
    // tBoxCurrQuoteNum
    // 
    this.tBoxCurrQuoteNum.Location = new System.Drawing.Point(120, 64);
    this.tBoxCurrQuoteNum.MaxLength = 10;
    this.tBoxCurrQuoteNum.Name = "tBoxCurrQuoteNum";
    this.tBoxCurrQuoteNum.TabIndex = 80;
    this.tBoxCurrQuoteNum.Text = "0";
    // 
    // tBoxCurrBillLadNum
    // 
    this.tBoxCurrBillLadNum.Location = new System.Drawing.Point(120, 40);
    this.tBoxCurrBillLadNum.MaxLength = 10;
    this.tBoxCurrBillLadNum.Name = "tBoxCurrBillLadNum";
    this.tBoxCurrBillLadNum.TabIndex = 60;
    this.tBoxCurrBillLadNum.Text = "0";
    // 
    // tBoxCurrInvoiceNum
    // 
    this.tBoxCurrInvoiceNum.Location = new System.Drawing.Point(352, 16);
    this.tBoxCurrInvoiceNum.MaxLength = 10;
    this.tBoxCurrInvoiceNum.Name = "tBoxCurrInvoiceNum";
    this.tBoxCurrInvoiceNum.TabIndex = 50;
    this.tBoxCurrInvoiceNum.Text = "0";
    // 
    // tBoxCurrOrderNum
    // 
    this.tBoxCurrOrderNum.Location = new System.Drawing.Point(120, 16);
    this.tBoxCurrOrderNum.MaxLength = 10;
    this.tBoxCurrOrderNum.Name = "tBoxCurrOrderNum";
    this.tBoxCurrOrderNum.TabIndex = 40;
    this.tBoxCurrOrderNum.Text = "0";
    // 
    // gBoxCompValues
    // 
    this.gBoxCompValues.Controls.Add(this.tBoxCurrBillLadNum);
    this.gBoxCompValues.Controls.Add(this.lCurrBillLadNum);
    this.gBoxCompValues.Controls.Add(this.tBoxCurrCrdNoteNum);
    this.gBoxCompValues.Controls.Add(this.tBoxCurrQuoteNum);
    this.gBoxCompValues.Controls.Add(this.tBoxCurrOrderNum);
    this.gBoxCompValues.Controls.Add(this.lCurrOrderNum);
    this.gBoxCompValues.Controls.Add(this.lCurrQuoteNum);
    this.gBoxCompValues.Controls.Add(this.lCurrInvoiceNum);
    this.gBoxCompValues.Controls.Add(this.lCurrCreditNoteNum);
    this.gBoxCompValues.Controls.Add(this.tBoxCurrInvoiceNum);
    this.gBoxCompValues.Location = new System.Drawing.Point(8, 152);
    this.gBoxCompValues.Name = "gBoxCompValues";
    this.gBoxCompValues.Size = new System.Drawing.Size(464, 96);
    this.gBoxCompValues.TabIndex = 31;
    this.gBoxCompValues.TabStop = false;
    // 
    // error
    // 
    this.error.ContainerControl = this;
    // 
    // gBoxData
    // 
    this.gBoxData.Controls.Add(this.lDescription);
    this.gBoxData.Controls.Add(this.tBoxName);
    this.gBoxData.Controls.Add(this.lName);
    this.gBoxData.Controls.Add(this.tBoxDescription);
    this.gBoxData.Location = new System.Drawing.Point(8, 56);
    this.gBoxData.Name = "gBoxData";
    this.gBoxData.Size = new System.Drawing.Size(464, 96);
    this.gBoxData.TabIndex = 11;
    this.gBoxData.TabStop = false;
    // 
    // CompanyEditForm
    // 
    this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
    this.ClientSize = new System.Drawing.Size(488, 294);
    this.Controls.Add(this.gBoxData);
    this.Controls.Add(this.gBoxCompValues);
    this.Controls.Add(this.btnOk);
    this.Controls.Add(this.btnCancel);
    this.Controls.Add(this.gBoxCompData);
	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	this.MaximumSize = new System.Drawing.Size(496, 328);
    this.MinimumSize = new System.Drawing.Size(496, 328);
    this.Name = "CompanyEditForm";
    this.Load += new System.EventHandler(this.CompanyEditForm_Load);
    this.gBoxCompData.ResumeLayout(false);
    this.gBoxCompValues.ResumeLayout(false);
    this.gBoxData.ResumeLayout(false);
    this.ResumeLayout(false);

}
#endregion

private void CompanyEditForm_Load(object sender, System.EventArgs e){

}

private void setByUpdate(int action){
    this.tBoxDb.Enabled =false;
    
    if (action.Equals(Constants.UPDATE))
        this.tBoxCompany.Enabled = false;
    
}

private void setByDelete(){

    foreach(Control objControl in this.gBoxCompData.Controls){
		if (objControl is TextBox)
			objControl.Enabled = false;
	}
    foreach(Control objControl in this.gBoxCompValues.Controls){
		if (objControl is TextBox)
			objControl.Enabled = false;
	}
	 foreach(Control objControl in this.gBoxData.Controls){
		if (objControl is TextBox)
			objControl.Enabled = false;
	}
	this.btnOk.Text =culture.getText("delete");
}

private void clearErrors(){

  foreach(Control objControl in this.gBoxCompData.Controls){
		    if (objControl is TextBox)
			    error.SetError(objControl,"");
  }
  foreach(Control objControl in this.gBoxCompValues.Controls){
		    if (objControl is TextBox)
			    error.SetError(objControl,"");
  }
  foreach(Control objControl in this.gBoxData.Controls){
		    if (objControl is TextBox)
			    error.SetError(objControl,"");
  }
}
private void btnOk_Click(object sender, System.EventArgs e){
       
    //Save the new/update company
    Company company = setDataFromScreen();
    if (company == null)
        return;
        
    try{    
        if (action.Equals(Constants.ADD)){    
            if (coreFactory.existsCompany(company.getDb(),company.getCompany())){
                MessageBox.Show(culture.getText("message1"));
                return;
            }
            coreFactory.writeCompany(company);
            this.Tag = company.getCompany();
        }
        if (action.Equals(Constants.UPDATE))
            coreFactory.updateCompany(company);    
        if (action.Equals(Constants.DELETE)) { 
             DialogResult deleteConfirm = MessageBox.Show(culture.getText("message4"), culture.getText("message5"), 
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deleteConfirm == DialogResult.No)
	                return;  
            coreFactory.deleteCompany(company);
        }    
        DialogResult = DialogResult.OK;    
        Close();
    }catch(NujitException ne){
		Nujit.NujitERP.WinForms.FormException formException = new Nujit.NujitERP.WinForms.FormException(ne);
		formException.ShowDialog();
		this.DialogResult = DialogResult.Cancel;
	}    
}


private Company setDataFromScreen(){

    if (action.Equals(Constants.ADD)||(action.Equals(Constants.UPDATE))){ 
        if (!dataOk()) //Data in the screen has erros
                return null;
    }

	Company comp = this.coreFactory.createCompany();
	comp.setDb(tBoxDb.Text);
	comp.setCompany(int.Parse(tBoxCompany.Text));
	comp.setName(tBoxName.Text);
	comp.setDescription(tBoxDescription.Text);
	comp.setCurrOrderNum(int.Parse(tBoxCurrOrderNum.Text));
	comp.setCurrInvoiceNum(int.Parse(tBoxCurrInvoiceNum.Text));
	comp.setCurrBillLadNum(int.Parse(tBoxCurrBillLadNum.Text));
	comp.setCurrQuoteNum(int.Parse(tBoxCurrQuoteNum.Text));
	comp.setCurrCreditNoteNum(int.Parse(tBoxCurrCrdNoteNum.Text));

    return comp;
} 

private void btnCancel_Click(object sender, System.EventArgs e){
    
    DialogResult = DialogResult.Cancel;
    this.Close();
}

private bool dataOk(){ //Checks the data that is in the screen
    clearErrors();
    //Validate the company value
    if (tBoxCompany.Text.Equals("")){
        error.SetError(tBoxCompany,culture.getText("message2"));
        tBoxCompany.Focus();
        return false;
    }else{ //the value must be integer
		    if (!NumberUtil.isIntegerNumber(tBoxCompany.Text)){
			    error.SetError(tBoxCompany,culture.getText("message3"));
			    tBoxCompany.Focus();
			    return false;
			}
    }
    
    //Validate that the values are all integers
    foreach(Control objControl in this.gBoxCompValues.Controls){
		    if (objControl is TextBox){
		        string theValue = objControl.Text;
		        if (!NumberUtil.isIntegerNumber(theValue)){
			        error.SetError(objControl,culture.getText("message3"));
			        objControl.Focus();
			        return false;
			    }
            }
    }
    return true;
}

private void setCompanyInfo(Company company){

    tBoxDb.Text = company.getDb();
    tBoxCurrCrdNoteNum.Text = company.getCurrCreditNoteNum().ToString();
    tBoxCurrQuoteNum.Text = company.getCurrQuoteNum().ToString();
    tBoxCurrBillLadNum.Text = company.getCurrBillLadNum().ToString();
    tBoxCurrInvoiceNum.Text = company.getCurrInvoiceNum().ToString();
    tBoxCurrOrderNum.Text = company.getCurrOrderNum().ToString(); 
    tBoxDescription.Text = company.getDescription();
    tBoxName.Text = company.getName();
    if (!action.Equals(Constants.ADD))
        tBoxCompany.Text = company.getCompany().ToString();

}


private void showCulture()	{

	culture.setResource("Nujit.NujitWms.WinForms.Inventory.Culture.CompanyEdit",
						typeof(CompanyEditForm).Assembly);

	culture.setControlsCulture(this);

}
    
}//end class
}//end namespace
