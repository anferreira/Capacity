using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;

//using Nujit.NujitERP.ClassLib.Master;
using Nujit.NujitERP.ClassLib.Core;

namespace Nujit.NujitERP.WinForms
{
	/// <summary>
	/// Summary description for FormEditCapMacCfg.
	/// </summary>
	public class FormEditCapMacCfg : System.Windows.Forms.Form
	{
		
		#region Controls

		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.Label lblDept;
		private System.Windows.Forms.TextBox txtBoxDept;
		private System.Windows.Forms.GroupBox grpBoxDept;
		private System.Windows.Forms.Button btnDelete;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblCapMacCfg;
		private System.Windows.Forms.Label lblDes1;
		private System.Windows.Forms.Label lblSet;
		private System.Windows.Forms.Label lblCfgExact;
		private System.Windows.Forms.Panel panelCfg;
		private System.Windows.Forms.TextBox txtBoxPlt;
		private System.Windows.Forms.Label lblPlt;
		private System.Windows.Forms.GroupBox grpBoxCfg;
		private System.Windows.Forms.TextBox txtBoxExact;
		private System.Windows.Forms.TextBox txtBoxDes1;
		private System.Windows.Forms.TextBox txtBoxSet;
		private System.Windows.Forms.TextBox txtBoxCfg;

		#endregion Controls

		#region Vars

		private bool blnInsert = false;
		private bool blnDelete = false;
		private bool blnUpdate = false;

		private MacConfiguration _configuration;
		private MacConfiguration savedConfiguration;
		private CoreFactory coreFactory;

		#endregion Vars
		
		#region Properties

		public bool IsInsert
		{
			get{return this.blnInsert;}
			set{this.blnInsert = value;}
		}

		public bool IsUpdate
		{
			get{return this.blnUpdate;}
			set{this.blnUpdate = value;}
		}


		public bool IsDelete
		{
			get{return this.blnDelete;}
			set{this.blnDelete = value;}
		}

		public MacConfiguration Configuration
		{
			get 
			{
				if (this._configuration == null)
					return coreFactory.createConfiguration();
				return this._configuration;
			}
			set
			{
				this._configuration = value;
			}
		}

		public MacConfiguration SavedConfiguration
		{
			get {return this.savedConfiguration;}
		}

		#endregion Properties

		#region Constructors


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormEditCapMacCfg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			coreFactory = UtilCoreFactory.createCoreFactory();
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



        #endregion Constructors

		#region Validation 

		private bool DataValidation()
		{
			bool blnResult = true;

			ClearErrorMark();
			blnResult = this.ValidateCfg()	&& blnResult ;
		//	blnResult = ValidateUtilPer()	&& blnResult ;
				
			return blnResult;
		}

		private void ClearErrorMark()
		{
			foreach(Control objControl in this.grpBoxCfg.Controls)
			{
				errorProvider1.SetError(objControl,"");
				
			}
		}

		private bool ValidateCfg()
		{
			bool IsValid = true;

			if ( this.txtBoxCfg.Text == "")
			{
				errorProvider1.SetError(txtBoxCfg,"Configuration field can not be empty!");
				IsValid = false;
			}

			return IsValid;
		
		}

		#endregion Validation 

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblDept = new System.Windows.Forms.Label();
			this.txtBoxDept = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.grpBoxDept = new System.Windows.Forms.GroupBox();
			this.txtBoxPlt = new System.Windows.Forms.TextBox();
			this.lblPlt = new System.Windows.Forms.Label();
			this.btnDelete = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panelCfg = new System.Windows.Forms.Panel();
			this.grpBoxCfg = new System.Windows.Forms.GroupBox();
			this.txtBoxDes1 = new System.Windows.Forms.TextBox();
			this.txtBoxExact = new System.Windows.Forms.TextBox();
			this.txtBoxSet = new System.Windows.Forms.TextBox();
			this.txtBoxCfg = new System.Windows.Forms.TextBox();
			this.lblCapMacCfg = new System.Windows.Forms.Label();
			this.lblDes1 = new System.Windows.Forms.Label();
			this.lblCfgExact = new System.Windows.Forms.Label();
			this.lblSet = new System.Windows.Forms.Label();
			this.grpBoxDept.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panelCfg.SuspendLayout();
			this.grpBoxCfg.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblDept
			// 
			this.lblDept.Location = new System.Drawing.Point(272, 16);
			this.lblDept.Name = "lblDept";
			this.lblDept.Size = new System.Drawing.Size(64, 23);
			this.lblDept.TabIndex = 2;
			this.lblDept.Text = "Department";
			this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBoxDept
			// 
			this.txtBoxDept.Location = new System.Drawing.Point(352, 19);
			this.txtBoxDept.MaxLength = 10;
			this.txtBoxDept.Name = "txtBoxDept";
			this.txtBoxDept.ReadOnly = true;
			this.txtBoxDept.Size = new System.Drawing.Size(96, 20);
			this.txtBoxDept.TabIndex = 8;
			this.txtBoxDept.Text = "";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(288, 200);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(80, 23);
			this.btnSave.TabIndex = 12;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(408, 200);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 23);
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			this.errorProvider1.DataMember = "";
			// 
			// grpBoxDept
			// 
			this.grpBoxDept.Controls.Add(this.txtBoxPlt);
			this.grpBoxDept.Controls.Add(this.lblPlt);
			this.grpBoxDept.Controls.Add(this.txtBoxDept);
			this.grpBoxDept.Controls.Add(this.lblDept);
			this.grpBoxDept.Location = new System.Drawing.Point(8, 8);
			this.grpBoxDept.Name = "grpBoxDept";
			this.grpBoxDept.Size = new System.Drawing.Size(472, 56);
			this.grpBoxDept.TabIndex = 15;
			this.grpBoxDept.TabStop = false;
			this.grpBoxDept.Text = "Department";
			// 
			// txtBoxPlt
			// 
			this.txtBoxPlt.Location = new System.Drawing.Point(104, 19);
			this.txtBoxPlt.MaxLength = 10;
			this.txtBoxPlt.Name = "txtBoxPlt";
			this.txtBoxPlt.ReadOnly = true;
			this.txtBoxPlt.Size = new System.Drawing.Size(96, 20);
			this.txtBoxPlt.TabIndex = 10;
			this.txtBoxPlt.Text = "";
			// 
			// lblPlt
			// 
			this.lblPlt.Location = new System.Drawing.Point(24, 16);
			this.lblPlt.Name = "lblPlt";
			this.lblPlt.Size = new System.Drawing.Size(64, 23);
			this.lblPlt.TabIndex = 9;
			this.lblPlt.Text = "Plant";
			this.lblPlt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(224, 200);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(80, 23);
			this.btnDelete.TabIndex = 16;
			this.btnDelete.Text = "Delete";
			this.btnDelete.Visible = false;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.grpBoxDept);
			this.panel1.Location = new System.Drawing.Point(8, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(496, 72);
			this.panel1.TabIndex = 17;
			// 
			// panelCfg
			// 
			this.panelCfg.Controls.Add(this.grpBoxCfg);
			this.panelCfg.Location = new System.Drawing.Point(8, 80);
			this.panelCfg.Name = "panelCfg";
			this.panelCfg.Size = new System.Drawing.Size(496, 120);
			this.panelCfg.TabIndex = 18;
			// 
			// grpBoxCfg
			// 
			this.grpBoxCfg.Controls.Add(this.txtBoxDes1);
			this.grpBoxCfg.Controls.Add(this.txtBoxExact);
			this.grpBoxCfg.Controls.Add(this.txtBoxSet);
			this.grpBoxCfg.Controls.Add(this.txtBoxCfg);
			this.grpBoxCfg.Controls.Add(this.lblCapMacCfg);
			this.grpBoxCfg.Controls.Add(this.lblDes1);
			this.grpBoxCfg.Controls.Add(this.lblCfgExact);
			this.grpBoxCfg.Controls.Add(this.lblSet);
			this.grpBoxCfg.Location = new System.Drawing.Point(8, 8);
			this.grpBoxCfg.Name = "grpBoxCfg";
			this.grpBoxCfg.Size = new System.Drawing.Size(472, 104);
			this.grpBoxCfg.TabIndex = 4;
			this.grpBoxCfg.TabStop = false;
			this.grpBoxCfg.Text = "Configuration";
			// 
			// txtBoxDes1
			// 
			this.txtBoxDes1.Location = new System.Drawing.Point(104, 64);
			this.txtBoxDes1.MaxLength = 40;
			this.txtBoxDes1.Name = "txtBoxDes1";
			this.txtBoxDes1.Size = new System.Drawing.Size(344, 20);
			this.txtBoxDes1.TabIndex = 14;
			this.txtBoxDes1.Text = "";
			// 
			// txtBoxExact
			// 
			this.txtBoxExact.Location = new System.Drawing.Point(408, 24);
			this.txtBoxExact.MaxLength = 1;
			this.txtBoxExact.Name = "txtBoxExact";
			this.txtBoxExact.Size = new System.Drawing.Size(40, 20);
			this.txtBoxExact.TabIndex = 13;
			this.txtBoxExact.Text = "";
			// 
			// txtBoxSet
			// 
			this.txtBoxSet.Location = new System.Drawing.Point(272, 24);
			this.txtBoxSet.MaxLength = 1;
			this.txtBoxSet.Name = "txtBoxSet";
			this.txtBoxSet.Size = new System.Drawing.Size(40, 20);
			this.txtBoxSet.TabIndex = 12;
			this.txtBoxSet.Text = "";
			// 
			// txtBoxCfg
			// 
			this.txtBoxCfg.Location = new System.Drawing.Point(104, 24);
			this.txtBoxCfg.MaxLength = 10;
			this.txtBoxCfg.Name = "txtBoxCfg";
			this.txtBoxCfg.Size = new System.Drawing.Size(96, 20);
			this.txtBoxCfg.TabIndex = 11;
			this.txtBoxCfg.Text = "";
			// 
			// lblCapMacCfg
			// 
			this.lblCapMacCfg.Location = new System.Drawing.Point(8, 24);
			this.lblCapMacCfg.Name = "lblCapMacCfg";
			this.lblCapMacCfg.Size = new System.Drawing.Size(80, 23);
			this.lblCapMacCfg.TabIndex = 0;
			this.lblCapMacCfg.Text = "Configuration ";
			this.lblCapMacCfg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblDes1
			// 
			this.lblDes1.Location = new System.Drawing.Point(16, 56);
			this.lblDes1.Name = "lblDes1";
			this.lblDes1.Size = new System.Drawing.Size(64, 23);
			this.lblDes1.TabIndex = 1;
			this.lblDes1.Text = "Description";
			this.lblDes1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblCfgExact
			// 
			this.lblCfgExact.Location = new System.Drawing.Point(344, 24);
			this.lblCfgExact.Name = "lblCfgExact";
			this.lblCfgExact.Size = new System.Drawing.Size(40, 23);
			this.lblCfgExact.TabIndex = 3;
			this.lblCfgExact.Text = "Exact";
			this.lblCfgExact.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSet
			// 
			this.lblSet.Location = new System.Drawing.Point(224, 24);
			this.lblSet.Name = "lblSet";
			this.lblSet.Size = new System.Drawing.Size(32, 23);
			this.lblSet.TabIndex = 2;
			this.lblSet.Text = "Set";
			this.lblSet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FormEditCapMacCfg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 238);
			this.Controls.Add(this.panelCfg);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnSave);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormEditCapMacCfg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Configuration ";
			this.Load += new System.EventHandler(this.FormEditCapMacCfg_Load);
			this.grpBoxDept.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panelCfg.ResumeLayout(false);
			this.grpBoxCfg.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Methods
		
		private MacConfiguration AssembleData()
		{
			MacConfiguration conf = coreFactory.createConfiguration();

			conf.setPlt(this.txtBoxPlt.Text.Trim());
			conf.setDept(this.txtBoxDept.Text.Trim());
			conf.setCfg(this.txtBoxCfg.Text.Trim());
			conf.setDes1(this.txtBoxDes1.Text.Trim());
			conf.setExact(this.txtBoxExact.Text.Trim());
			conf.setSet(this.txtBoxSet.Text.Trim());

			return conf;
		
		}
       
		private bool Insert(MacConfiguration conf)
		{
			try
			{
				if (coreFactory.existsConfiguration(conf.getPlt(), conf.getDept(), conf.getCfg()))
				{
					MessageBox.Show("The configuration " + conf.getCfg() + " already exists");
					return false;
				}

				coreFactory.writeConfiguration (conf);
				return true;
			}
			catch (Exception ex)
			{
				FormException formEx = new FormException (ex);
				formEx.ShowDialog();
			}
			return false;
		}

		private bool Update(MacConfiguration conf)
		{			
			try
			{
				coreFactory.updateConfiguration (conf);
				return true;
			}
			catch (Exception ex)
			{
				FormException formEx = new FormException (ex);
				formEx.ShowDialog();
			}
			return false;
		}
		private bool Delete(MacConfiguration conf)
		{  
			// added by Gustavo Muller
			// changes by Fernando Nicolet
			DialogResult deleteConfirm = MessageBox.Show("Remove this item ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (deleteConfirm == DialogResult.No)
				return false; // false = wasn't deleted
			
			//Check whether there are machines are associated with the dept.
			try
			{
				coreFactory.deleteConfiguration (conf);
				return true;
			}
			catch (Exception ex)
			{
				FormException formEx = new FormException (ex);
				formEx.ShowDialog();
			}
			return false;
		
		}
      
		private void BindData(MacConfiguration conf)
		{
			this.txtBoxPlt.Text          =  conf.getPlt();   
			this.txtBoxDept.Text 		 = 	conf.getDept();
			this.txtBoxCfg.Text  		 = 	conf.getCfg(); 
			this.txtBoxDes1.Text 		 = 	conf.getDes1();
			this.txtBoxExact.Text		 = 	conf.getExact();
			this.txtBoxSet.Text  		 = 	conf.getSet();
		}

		
		private void SetStatus()
		{
			
			if (this.IsUpdate)
				this.txtBoxCfg.ReadOnly = true;

			if (this.IsDelete)
			{
				foreach (Control objControl in this.grpBoxCfg.Controls)
				{   if (objControl is TextBox)
						((TextBox)objControl).ReadOnly = true;
				}
				this.btnDelete.Visible = true;
				this.btnSave.Visible   = false;
			
			}
		}

		
		#endregion Methods
	
		#region Events

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (!this.DataValidation()) return ;

			MacConfiguration conf = AssembleData();


			bool IsSuccessful = false;

			if (this.IsInsert) IsSuccessful = Insert(conf);
			if (this.IsUpdate) IsSuccessful = Update(conf);
            
			if (IsSuccessful) {
				this.DialogResult = DialogResult.OK;
				this.savedConfiguration = conf;
				this.Close();
			}
		}

		private void FormEditCapMacCfg_Load(object sender, System.EventArgs e)
		{
			if (this._configuration == null) return; 

			BindData(this._configuration);

			SetStatus();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void btnDelete_Click(object sender, System.EventArgs e)
		{

			if (coreFactory.configurationHasMachines (this._configuration))
			{
				string strMessage = "\n    There are machines associated with this configuration.   " ;
				strMessage += "\n    Please delete those nodes first and try again!   \n\n";

				MessageBox.Show(strMessage, "Can't delete configuration record!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			bool IsSuccessful = false;


			if (this.IsDelete)
				IsSuccessful = Delete(this._configuration);
            
			if (IsSuccessful){
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
			


		#endregion Events
		
	}
}
