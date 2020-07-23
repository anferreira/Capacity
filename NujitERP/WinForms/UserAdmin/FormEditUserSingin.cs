using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Common;

using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.WinForms.Reports.ProductsReport;
using Nujit.NujitERP.WinForms.Reports.InventoryReport;
using Nujit.NujitERP.WinForms.SearchForms;
using System.Globalization;

using System.Resources;
using System.Security.Permissions;


namespace Nujit.NujitERP.WinForms
{
	/// <summary>
	/// Summary description for FormEditUserSignin.
	/// </summary>
	public class FormEditUserSingin : System.Windows.Forms.Form
	{		
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBoxUSApply;
		private System.Windows.Forms.Button buttonUSClear;
		private System.Windows.Forms.Button buttonUSSave;
		private System.Windows.Forms.Button buttonUSCancel;
		private System.Windows.Forms.Button buttonUSDelete;
		private System.Windows.Forms.Label labelUSBase;
		private System.Windows.Forms.Button buttonUSCompanySearch;
		private System.Windows.Forms.TextBox textBoxUSBase;
		private System.Windows.Forms.TextBox textBoxUSCompany;
		private System.Windows.Forms.Label labelUSCompany;
		private System.Windows.Forms.Label labelUSPlant;
		private System.Windows.Forms.TextBox textBoxUSPlant;
		private System.Windows.Forms.Button buttonUSPlantSearch;
		private System.Windows.Forms.Label labelUSDefaultLabel;
		private System.Windows.Forms.TextBox textBoxUSDefaultLabel;
		private System.Windows.Forms.Button buttonUSDefaultLabelSearch;
		private System.Windows.Forms.Label labelUSDefaultPrinter;
		private System.Windows.Forms.TextBox textBoxUSDefaultPrinter;
		private System.Windows.Forms.Label labelUSSecurityProfile;
		private System.Windows.Forms.TextBox textBoxUSSecurityProfile;

		private CoreFactory		coreFactory = UtilCoreFactory.createCoreFactory();
		private UserSignin		userSignin=null;		
		private User			user=null;		
		private CultureLocal	culture = new CultureLocal(Culture.getCulture());

		public FormEditUserSingin(User user)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();							

			this.user = user;

			this.userSignin=user.getUserSignin();		
            if (userSignin!= null)
				this.objectToScreen();
			else
				initialize();

			//showCulture();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormEditUserSingin));
			this.groupBoxUSApply = new System.Windows.Forms.GroupBox();
			this.buttonUSClear = new System.Windows.Forms.Button();
			this.buttonUSSave = new System.Windows.Forms.Button();
			this.buttonUSCancel = new System.Windows.Forms.Button();
			this.buttonUSDelete = new System.Windows.Forms.Button();
			this.labelUSBase = new System.Windows.Forms.Label();
			this.buttonUSCompanySearch = new System.Windows.Forms.Button();
			this.textBoxUSBase = new System.Windows.Forms.TextBox();
			this.textBoxUSCompany = new System.Windows.Forms.TextBox();
			this.labelUSCompany = new System.Windows.Forms.Label();
			this.labelUSPlant = new System.Windows.Forms.Label();
			this.textBoxUSPlant = new System.Windows.Forms.TextBox();
			this.buttonUSPlantSearch = new System.Windows.Forms.Button();
			this.labelUSDefaultLabel = new System.Windows.Forms.Label();
			this.textBoxUSDefaultLabel = new System.Windows.Forms.TextBox();
			this.buttonUSDefaultLabelSearch = new System.Windows.Forms.Button();
			this.labelUSDefaultPrinter = new System.Windows.Forms.Label();
			this.textBoxUSDefaultPrinter = new System.Windows.Forms.TextBox();
			this.labelUSSecurityProfile = new System.Windows.Forms.Label();
			this.textBoxUSSecurityProfile = new System.Windows.Forms.TextBox();
			this.groupBoxUSApply.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxUSApply
			// 
			this.groupBoxUSApply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxUSApply.Controls.Add(this.buttonUSClear);
			this.groupBoxUSApply.Controls.Add(this.buttonUSSave);
			this.groupBoxUSApply.Controls.Add(this.buttonUSCancel);
			this.groupBoxUSApply.Controls.Add(this.buttonUSDelete);
			this.groupBoxUSApply.Location = new System.Drawing.Point(16, 176);
			this.groupBoxUSApply.Name = "groupBoxUSApply";
			this.groupBoxUSApply.Size = new System.Drawing.Size(472, 48);
			this.groupBoxUSApply.TabIndex = 10;
			this.groupBoxUSApply.TabStop = false;
			this.groupBoxUSApply.Enter += new System.EventHandler(this.groupBoxLVApply_Enter);
			// 
			// buttonUSClear
			// 
			this.buttonUSClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUSClear.Location = new System.Drawing.Point(144, 16);
			this.buttonUSClear.Name = "buttonUSClear";
			this.buttonUSClear.TabIndex = 1;
			this.buttonUSClear.Text = "Clear";
			this.buttonUSClear.Click += new System.EventHandler(this.buttonUSClear_Click);
			// 
			// buttonUSSave
			// 
			this.buttonUSSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUSSave.Location = new System.Drawing.Point(224, 16);
			this.buttonUSSave.Name = "buttonUSSave";
			this.buttonUSSave.TabIndex = 2;
			this.buttonUSSave.Text = "Save";
			this.buttonUSSave.Click += new System.EventHandler(this.buttonUSSave_Click);
			// 
			// buttonUSCancel
			// 
			this.buttonUSCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUSCancel.Location = new System.Drawing.Point(304, 16);
			this.buttonUSCancel.Name = "buttonUSCancel";
			this.buttonUSCancel.TabIndex = 3;
			this.buttonUSCancel.Text = "Cancel";
			this.buttonUSCancel.Click += new System.EventHandler(this.buttonUSCancel_Click);
			// 
			// buttonUSDelete
			// 
			this.buttonUSDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUSDelete.Location = new System.Drawing.Point(384, 16);
			this.buttonUSDelete.Name = "buttonUSDelete";
			this.buttonUSDelete.TabIndex = 4;
			this.buttonUSDelete.Text = "Delete";
			this.buttonUSDelete.Click += new System.EventHandler(this.buttonUSDelete_Click);
			// 
			// labelUSBase
			// 
			this.labelUSBase.Location = new System.Drawing.Point(32, 8);
			this.labelUSBase.Name = "labelUSBase";
			this.labelUSBase.Size = new System.Drawing.Size(88, 16);
			this.labelUSBase.TabIndex = 26;
			this.labelUSBase.Text = "Base:";
			// 
			// buttonUSCompanySearch
			// 
			this.buttonUSCompanySearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUSCompanySearch.Location = new System.Drawing.Point(424, 32);
			this.buttonUSCompanySearch.Name = "buttonUSCompanySearch";
			this.buttonUSCompanySearch.Size = new System.Drawing.Size(32, 16);
			this.buttonUSCompanySearch.TabIndex = 610;
			this.buttonUSCompanySearch.Text = "...";
			this.buttonUSCompanySearch.Click += new System.EventHandler(this.buttonUSHardCodedVariablesSearch_Click);
			// 
			// textBoxUSBase
			// 
			this.textBoxUSBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUSBase.Location = new System.Drawing.Point(128, 8);
			this.textBoxUSBase.MaxLength = 20;
			this.textBoxUSBase.Name = "textBoxUSBase";
			this.textBoxUSBase.ReadOnly = true;
			this.textBoxUSBase.Size = new System.Drawing.Size(288, 20);
			this.textBoxUSBase.TabIndex = 611;
			this.textBoxUSBase.Text = "";
			// 
			// textBoxUSCompany
			// 
			this.textBoxUSCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUSCompany.Location = new System.Drawing.Point(128, 32);
			this.textBoxUSCompany.MaxLength = 20;
			this.textBoxUSCompany.Name = "textBoxUSCompany";
			this.textBoxUSCompany.ReadOnly = true;
			this.textBoxUSCompany.Size = new System.Drawing.Size(288, 20);
			this.textBoxUSCompany.TabIndex = 612;
			this.textBoxUSCompany.Text = "";
			// 
			// labelUSCompany
			// 
			this.labelUSCompany.Location = new System.Drawing.Point(32, 32);
			this.labelUSCompany.Name = "labelUSCompany";
			this.labelUSCompany.Size = new System.Drawing.Size(88, 16);
			this.labelUSCompany.TabIndex = 613;
			this.labelUSCompany.Text = "Company:";
			// 
			// labelUSPlant
			// 
			this.labelUSPlant.Location = new System.Drawing.Point(32, 56);
			this.labelUSPlant.Name = "labelUSPlant";
			this.labelUSPlant.Size = new System.Drawing.Size(88, 16);
			this.labelUSPlant.TabIndex = 616;
			this.labelUSPlant.Text = "Plant:";
			// 
			// textBoxUSPlant
			// 
			this.textBoxUSPlant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUSPlant.Location = new System.Drawing.Point(128, 56);
			this.textBoxUSPlant.MaxLength = 20;
			this.textBoxUSPlant.Name = "textBoxUSPlant";
			this.textBoxUSPlant.ReadOnly = true;
			this.textBoxUSPlant.Size = new System.Drawing.Size(288, 20);
			this.textBoxUSPlant.TabIndex = 615;
			this.textBoxUSPlant.Text = "";
			// 
			// buttonUSPlantSearch
			// 
			this.buttonUSPlantSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUSPlantSearch.Location = new System.Drawing.Point(424, 56);
			this.buttonUSPlantSearch.Name = "buttonUSPlantSearch";
			this.buttonUSPlantSearch.Size = new System.Drawing.Size(32, 16);
			this.buttonUSPlantSearch.TabIndex = 614;
			this.buttonUSPlantSearch.Text = "...";
			// 
			// labelUSDefaultLabel
			// 
			this.labelUSDefaultLabel.Location = new System.Drawing.Point(32, 80);
			this.labelUSDefaultLabel.Name = "labelUSDefaultLabel";
			this.labelUSDefaultLabel.Size = new System.Drawing.Size(88, 16);
			this.labelUSDefaultLabel.TabIndex = 618;
			this.labelUSDefaultLabel.Text = "Default Label:";
			// 
			// textBoxUSDefaultLabel
			// 
			this.textBoxUSDefaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUSDefaultLabel.Location = new System.Drawing.Point(128, 80);
			this.textBoxUSDefaultLabel.MaxLength = 20;
			this.textBoxUSDefaultLabel.Name = "textBoxUSDefaultLabel";
			this.textBoxUSDefaultLabel.ReadOnly = true;
			this.textBoxUSDefaultLabel.Size = new System.Drawing.Size(288, 20);
			this.textBoxUSDefaultLabel.TabIndex = 617;
			this.textBoxUSDefaultLabel.Text = "";
			// 
			// buttonUSDefaultLabelSearch
			// 
			this.buttonUSDefaultLabelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUSDefaultLabelSearch.Location = new System.Drawing.Point(424, 80);
			this.buttonUSDefaultLabelSearch.Name = "buttonUSDefaultLabelSearch";
			this.buttonUSDefaultLabelSearch.Size = new System.Drawing.Size(32, 16);
			this.buttonUSDefaultLabelSearch.TabIndex = 619;
			this.buttonUSDefaultLabelSearch.Text = "...";
			this.buttonUSDefaultLabelSearch.Click += new System.EventHandler(this.buttonUSDefaultLabelSearch_Click);
			// 
			// labelUSDefaultPrinter
			// 
			this.labelUSDefaultPrinter.Location = new System.Drawing.Point(32, 104);
			this.labelUSDefaultPrinter.Name = "labelUSDefaultPrinter";
			this.labelUSDefaultPrinter.Size = new System.Drawing.Size(88, 16);
			this.labelUSDefaultPrinter.TabIndex = 620;
			this.labelUSDefaultPrinter.Text = "Default Printer:";
			// 
			// textBoxUSDefaultPrinter
			// 
			this.textBoxUSDefaultPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUSDefaultPrinter.Location = new System.Drawing.Point(128, 104);
			this.textBoxUSDefaultPrinter.MaxLength = 10;
			this.textBoxUSDefaultPrinter.Name = "textBoxUSDefaultPrinter";
			this.textBoxUSDefaultPrinter.Size = new System.Drawing.Size(288, 20);
			this.textBoxUSDefaultPrinter.TabIndex = 621;
			this.textBoxUSDefaultPrinter.Text = "";
			// 
			// labelUSSecurityProfile
			// 
			this.labelUSSecurityProfile.Location = new System.Drawing.Point(32, 128);
			this.labelUSSecurityProfile.Name = "labelUSSecurityProfile";
			this.labelUSSecurityProfile.Size = new System.Drawing.Size(88, 16);
			this.labelUSSecurityProfile.TabIndex = 622;
			this.labelUSSecurityProfile.Text = "Security Profile:";
			// 
			// textBoxUSSecurityProfile
			// 
			this.textBoxUSSecurityProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUSSecurityProfile.Location = new System.Drawing.Point(128, 128);
			this.textBoxUSSecurityProfile.MaxLength = 10;
			this.textBoxUSSecurityProfile.Name = "textBoxUSSecurityProfile";
			this.textBoxUSSecurityProfile.Size = new System.Drawing.Size(288, 20);
			this.textBoxUSSecurityProfile.TabIndex = 623;
			this.textBoxUSSecurityProfile.Text = "";
			// 
			// FormEditUserSingin
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 238);
			this.Controls.Add(this.textBoxUSSecurityProfile);
			this.Controls.Add(this.labelUSSecurityProfile);
			this.Controls.Add(this.textBoxUSDefaultPrinter);
			this.Controls.Add(this.labelUSDefaultPrinter);
			this.Controls.Add(this.buttonUSDefaultLabelSearch);
			this.Controls.Add(this.labelUSDefaultLabel);
			this.Controls.Add(this.textBoxUSDefaultLabel);
			this.Controls.Add(this.labelUSPlant);
			this.Controls.Add(this.textBoxUSPlant);
			this.Controls.Add(this.buttonUSPlantSearch);
			this.Controls.Add(this.labelUSCompany);
			this.Controls.Add(this.textBoxUSCompany);
			this.Controls.Add(this.textBoxUSBase);
			this.Controls.Add(this.buttonUSCompanySearch);
			this.Controls.Add(this.labelUSBase);
			this.Controls.Add(this.groupBoxUSApply);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormEditUserSingin";
			this.Text = "User Singin";
			this.groupBoxUSApply.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


private	
void objectToScreen(){
			
	if (userSignin!= null)
	{			
		this.textBoxUSBase.Text = userSignin.getDefDatabase();
		this.textBoxUSCompany.Text = userSignin.getDefCompany().ToString();
		this.textBoxUSPlant.Text = userSignin.getDefPlant();
		this.textBoxUSDefaultLabel.Text = userSignin.getDefLabelPrinter();
		this.textBoxUSDefaultPrinter.Text = userSignin.getDefPrinter();
		this.textBoxUSSecurityProfile.Text = userSignin.getSecurityProfile();			
				
		buttonUSDelete.Enabled = true;
	}	
}

private
bool screenToObject(){
	
	bool	bresult=true;
	
	if (bresult)
	{		
		userSignin.setDefDatabase(this.textBoxUSBase.Text);
		userSignin.setDefCompany(int.Parse(this.textBoxUSCompany.Text));
		userSignin.setDefPlant(this.textBoxUSPlant.Text);
		userSignin.setDefLabelPrinter(this.textBoxUSDefaultLabel.Text);
		userSignin.setDefPrinter(this.textBoxUSDefaultPrinter.Text);
		userSignin.setSecurityProfile(this.textBoxUSSecurityProfile.Text);							
	}

	return bresult;
}

protected virtual 
void initialize(){	

	userSignin = coreFactory.createUserSignin();
	userSignin.setUserId(user.getUserID());
	
	buttonUSDelete.Enabled = false;//can not delete
		
	this.textBoxUSBase.Text				= Configuration.DftDataBase;
	this.textBoxUSCompany.Text			= Configuration.DftCompany.ToString();
	this.textBoxUSPlant.Text			= "1";//Configuration.getDefPlant();
	this.textBoxUSDefaultLabel.Text		= "";
	this.textBoxUSDefaultPrinter.Text	= "";
	this.textBoxUSSecurityProfile.Text	= "";

}

private void buttonUSSave_Click(object sender, System.EventArgs e)
{
	save();
}

private void save()
{
	bool bprocessOk=false;
	try
	{
		if (this.screenToObject())
		{
			this.user.setUserSignin(this.userSignin);
			this.DialogResult = DialogResult.OK;
			Dispose();
		}
	}
	catch(NujitException nu)
	{				
		FormException formException = new FormException(nu);
		formException.ShowDialog();
	}
}

private void buttonUSDelete_Click(object sender, System.EventArgs e)
{
	DialogResult deleteConfirm = MessageBox.Show(culture.getText("message2"), culture.getText("message3"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
	if (deleteConfirm == DialogResult.No)
		return;
	delete();
}

private void delete()
{							
	try
	{
		if (this.screenToObject())
		{
			this.user.setUserSignin(null);//delete the object
			this.DialogResult = DialogResult.OK;
			Dispose();
		}
	}
	catch(NujitException nu)
	{
		FormException formException = new FormException(nu);
		formException.ShowDialog();
	}			
}

private void buttonUSCancel_Click(object sender, System.EventArgs e)
{
	this.DialogResult = DialogResult.Cancel;
	Dispose();
}

private void textBoxLVCode_TextChanged(object sender, System.EventArgs e)
{	
	
}

private void showCulture()
{
	culture.setResource("Nujit.NujitERP.WinForms.UserAdmin.Culture.FormEditUserSingin",
						typeof(FormEditUserSingin).Assembly);

	culture.setControlsCulture(this);				
}

private void groupBoxLVApply_Enter(object sender, System.EventArgs e)
{

}

private void buttonUSClear_Click(object sender, System.EventArgs e)
{
	initialize();
}

private void buttonUSHardCodedVariablesSearch_Click(object sender, System.EventArgs e)
{
	/*
	UserSigninHardCodedSearchForm userSigninHardCodedSearchForm = new UserSigninHardCodedSearchForm("");
	userSigninHardCodedSearchForm.ShowDialog();
	
	if (userSigninHardCodedSearchForm.DialogResult == DialogResult.OK){
		string[] v = userSigninHardCodedSearchForm.getSelected();
		if (v != null){			
								
			this.textBoxLVFieldVar.Text = v[0];
		}
	}*/
}

public User getUser()
{
	return user;
}

private void buttonUSDefaultLabelSearch_Click(object sender, System.EventArgs e)
{	
	string slabFormat="";

	if (searchLabFormat(out slabFormat))
		this.textBoxUSDefaultLabel.Text = slabFormat;
}

private bool searchLabFormat(out string sout)
{	
	sout="";
	/*

	bool				bresult=false;
	LabFormatSearchForm labFormatSearchForm = new LabFormatSearchForm("Label Format");			
	labFormatSearchForm.ShowDialog();
	
	if (labFormatSearchForm.DialogResult == DialogResult.OK){
		string[] v = labFormatSearchForm.getSelected();
		if (v != null){			
			
			bresult=true;
			sout = v[1];					
		}
	}
	return bresult;
	*/
	return false;
}


}
}
