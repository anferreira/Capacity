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
public class CurrencyEditForm : System.Windows.Forms.Form	{
private System.Windows.Forms.GroupBox groupBox1;
private System.Windows.Forms.TextBox tBoxIdentification;
private System.Windows.Forms.Button btnSchCurrency;
private System.Windows.Forms.GroupBox groupBox2;
private System.Windows.Forms.Button btnSave;
private System.Windows.Forms.Button btnClear;
private System.Windows.Forms.Button btnCancel;
private System.Windows.Forms.Button btnDelete;
private System.Windows.Forms.Label lGLCDescription;
private System.Windows.Forms.Label lGLCCurrency;
private System.Windows.Forms.TextBox tBoxGLCDb;
private System.Windows.Forms.TextBox tBoxGLCCurrency;
private System.Windows.Forms.TextBox tBoxGLCDescription;
/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.Container components = null;

private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
private GLCurrency glCurrency = new GLCurrency();
private bool flgEdit = false;
    private System.Windows.Forms.Label lGLCDb;
    private System.Windows.Forms.ErrorProvider error;
private CultureLocal culture = new CultureLocal(Culture.getCulture());


public CurrencyEditForm()		{
	
	InitializeComponent();
    showCulture();

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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CurrencyEditForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSchCurrency = new System.Windows.Forms.Button();
            this.tBoxIdentification = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lGLCDb = new System.Windows.Forms.Label();
            this.lGLCDescription = new System.Windows.Forms.Label();
            this.lGLCCurrency = new System.Windows.Forms.Label();
            this.tBoxGLCDb = new System.Windows.Forms.TextBox();
            this.tBoxGLCCurrency = new System.Windows.Forms.TextBox();
            this.tBoxGLCDescription = new System.Windows.Forms.TextBox();
            this.error = new System.Windows.Forms.ErrorProvider();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSchCurrency);
            this.groupBox1.Controls.Add(this.tBoxIdentification);
            this.groupBox1.Location = new System.Drawing.Point(8, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 48);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            // 
            // btnSchCurrency
            // 
            this.btnSchCurrency.Location = new System.Drawing.Point(376, 16);
            this.btnSchCurrency.Name = "btnSchCurrency";
            this.btnSchCurrency.Size = new System.Drawing.Size(30, 16);
            this.btnSchCurrency.TabIndex = 1;
            this.btnSchCurrency.Text = "...";
            this.btnSchCurrency.Click += new System.EventHandler(this.btnSchCurrency_Click);
            // 
            // tBoxIdentification
            // 
            this.tBoxIdentification.Location = new System.Drawing.Point(16, 16);
            this.tBoxIdentification.Name = "tBoxIdentification";
            this.tBoxIdentification.ReadOnly = true;
            this.tBoxIdentification.Size = new System.Drawing.Size(296, 20);
            this.tBoxIdentification.TabIndex = 0;
            this.tBoxIdentification.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Location = new System.Drawing.Point(8, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 48);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(336, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(256, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(96, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(176, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lGLCDb
            // 
            this.lGLCDb.Location = new System.Drawing.Point(48, 80);
            this.lGLCDb.Name = "lGLCDb";
            this.lGLCDb.Size = new System.Drawing.Size(72, 16);
            this.lGLCDb.TabIndex = 2;
            this.lGLCDb.Text = "Data Base";
            // 
            // lGLCDescription
            // 
            this.lGLCDescription.Location = new System.Drawing.Point(48, 144);
            this.lGLCDescription.Name = "lGLCDescription";
            this.lGLCDescription.Size = new System.Drawing.Size(72, 16);
            this.lGLCDescription.TabIndex = 3;
            this.lGLCDescription.Text = "Description";
            // 
            // lGLCCurrency
            // 
            this.lGLCCurrency.Location = new System.Drawing.Point(48, 108);
            this.lGLCCurrency.Name = "lGLCCurrency";
            this.lGLCCurrency.Size = new System.Drawing.Size(72, 16);
            this.lGLCCurrency.TabIndex = 4;
            this.lGLCCurrency.Text = "Currency";
            // 
            // tBoxGLCDb
            // 
            this.tBoxGLCDb.Location = new System.Drawing.Point(128, 76);
            this.tBoxGLCDb.MaxLength = 10;
            this.tBoxGLCDb.Name = "tBoxGLCDb";
            this.tBoxGLCDb.ReadOnly = true;
            this.tBoxGLCDb.TabIndex = 5;
            this.tBoxGLCDb.Text = "";
            // 
            // tBoxGLCCurrency
            // 
            this.tBoxGLCCurrency.Location = new System.Drawing.Point(128, 104);
            this.tBoxGLCCurrency.MaxLength = 5;
            this.tBoxGLCCurrency.Name = "tBoxGLCCurrency";
            this.tBoxGLCCurrency.TabIndex = 6;
            this.tBoxGLCCurrency.Text = "";
            // 
            // tBoxGLCDescription
            // 
            this.tBoxGLCDescription.Location = new System.Drawing.Point(128, 136);
            this.tBoxGLCDescription.MaxLength = 15;
            this.tBoxGLCDescription.Name = "tBoxGLCDescription";
            this.tBoxGLCDescription.Size = new System.Drawing.Size(192, 20);
            this.tBoxGLCDescription.TabIndex = 7;
            this.tBoxGLCDescription.Text = "";
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // CurrencyEditForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(472, 246);
            this.Controls.Add(this.tBoxGLCDescription);
            this.Controls.Add(this.tBoxGLCCurrency);
            this.Controls.Add(this.tBoxGLCDb);
            this.Controls.Add(this.lGLCCurrency);
            this.Controls.Add(this.lGLCDescription);
            this.Controls.Add(this.lGLCDb);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(480, 280);
            this.MinimumSize = new System.Drawing.Size(480, 280);
            this.Name = "CurrencyEditForm";
            this.Text = "Currency ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion


private void showCulture(){

    culture.setResource("Nujit.NujitERP.WinForms.GeneralLedger.Culture.CurrencyEditForm",
						typeof(CurrencyEditForm).Assembly);
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
    this.tBoxGLCDb.Text = Configuration.DftDataBase;
    this.tBoxGLCCurrency.Text ="";
    this.tBoxGLCDescription.Text="";
    this.tBoxIdentification.Text ="";
    this.btnDelete.Enabled = false;
    this.flgEdit = false;

}

private void btnSchCurrency_Click(object sender, System.EventArgs e){
    search();
}

private void search(){

 CurrencySearchForm currencySearchForm= new CurrencySearchForm(culture.getText("search"));
 currencySearchForm.setBaseFilter(Configuration.DftDataBase);
 currencySearchForm.ShowDialog();
  if (currencySearchForm.DialogResult == DialogResult.OK){
		string[] v = currencySearchForm.getSelected();
		if (v != null){			
		    this.tBoxGLCDb.Text = v[0];
            this.tBoxGLCCurrency.Text = v[1];
            this.tBoxGLCDescription.Text = v[2];
            this.tBoxIdentification.Text = v[2];
			this.flgEdit= true;
			this.btnDelete.Enabled =true;
		}
    }else{
	    initializeScreen();
    }

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
            coreFactory.deleteGLCurrency(glCurrency.getDb(),glCurrency.getCurrency());
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
                coreFactory.updateGLCurrency(glCurrency);
                return true;
            }else{ // is a new record
                if (coreFactory.existsGLCurrency(this.glCurrency.getDb(),this.glCurrency.getCurrency())){
                    MessageBox.Show(culture.getText("message3"));
                    return false;
                }else{
                        coreFactory.writeGLCurrency(glCurrency);
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
    if (this.tBoxGLCCurrency.Text.Equals("")){
        error.SetError(tBoxGLCCurrency,culture.getText("emptyValue"));
        return false;
    }
    return true;

}
   
private void clearErrors(){
    error.SetError(tBoxGLCCurrency,"");
}
   
private void setObject(){
    
    this.glCurrency.setDb(this.tBoxGLCDb.Text);
    this.glCurrency.setCurrency(this.tBoxGLCCurrency.Text);
    this.glCurrency.setDescription(this.tBoxGLCDescription.Text);
}

}//end class
}//end namespace
