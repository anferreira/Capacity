using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Nujit.NujitERP.ClassLib.Core;
//using Nujit.NujitERP.ClassLib.Master;

namespace Nujit.NujitERP.WinForms
{
	/// <summary>
	/// Summary description for FormEditPltDept.
	/// </summary>
	public class FormEditPltDept : System.Windows.Forms.Form
	{
		
		#region Controls

		private System.Windows.Forms.Label lblPlt;
		private System.Windows.Forms.Label lblPlantName;
		private System.Windows.Forms.TextBox txtBoxPlt;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtBoxPltName;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.Label lblDept;
		private System.Windows.Forms.Label lblDes;
		private System.Windows.Forms.Label lblUtilPer;
		private System.Windows.Forms.TextBox txtBoxDept;
		private System.Windows.Forms.TextBox txtBoxDes;
		private System.Windows.Forms.TextBox txtBoxUtilPer;
		private System.Windows.Forms.GroupBox grpBoxPlt;
		private System.Windows.Forms.GroupBox grpBoxDept;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.TextBox tBoxPlant;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tBoxDeptShort;

		#endregion Controls

		#region Vars

		private bool blnInsert = false;
		private bool blnDelete = false;
		private bool blnUpdate = false;

        private Departament departament;
		private Departament savedDept;
        private CoreFactory core = UtilCoreFactory.createCoreFactory();
       		
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

		public Departament SavedDept
		{
			get{return savedDept;}
		}

		#endregion Properties

		#region Constructors


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormEditPltDept()		{
			
			InitializeComponent();

		}
        public FormEditPltDept(Departament dept)		{
			
			InitializeComponent();
			this.departament = core.createDepartament();
            this.departament = dept;
			
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
			blnResult = this.ValidatePltDept()	&& blnResult ;
			blnResult = ValidateUtilPer()	&& blnResult ;
				
			return blnResult;
		}

		private void ClearErrorMark()
		{
			foreach(Control objControl in this.grpBoxDept.Controls)
			{
				if (objControl is TextBox)
					errorProvider1.SetError(objControl,"");
				
			}
		}

		private bool ValidateUtilPer()
		{
			bool IsValid = true;
			
			if (this.txtBoxUtilPer.Text.Trim().Equals(string.Empty)) return true;

			try
			{
            	if ( Convert.ToDecimal(this.txtBoxUtilPer.Text.Trim())>100 ||Convert.ToDecimal(this.txtBoxUtilPer.Text.Trim())<0 )
				{
					errorProvider1.SetError(this.txtBoxUtilPer,"Department util. percentage should be between 0 and 100!");
					IsValid = false;
				}
			}
			catch
			{
				errorProvider1.SetError(txtBoxUtilPer,"A number between 0 and 100 is expected!");
				IsValid = false;
			
			}

			return IsValid;
		
		}

		private bool ValidatePltDept()
		{
			bool IsValid = true;

			if ( this.txtBoxDept.Text == "")
			{
				errorProvider1.SetError(txtBoxDept,"Department field can not be empty!");
				IsValid = false;
			}

			return IsValid;
		
		}

		private void ClearErrorStatus()
		{
			foreach (Control objControl in this.Controls)
			{
				errorProvider1.SetError(objControl,"");
			
			}
			
		}
		#endregion Validation 

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblPlt = new System.Windows.Forms.Label();
			this.lblPlantName = new System.Windows.Forms.Label();
			this.lblDept = new System.Windows.Forms.Label();
			this.lblDes = new System.Windows.Forms.Label();
			this.lblUtilPer = new System.Windows.Forms.Label();
			this.txtBoxPlt = new System.Windows.Forms.TextBox();
			this.txtBoxPltName = new System.Windows.Forms.TextBox();
			this.txtBoxDept = new System.Windows.Forms.TextBox();
			this.txtBoxDes = new System.Windows.Forms.TextBox();
			this.txtBoxUtilPer = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.grpBoxPlt = new System.Windows.Forms.GroupBox();
			this.tBoxPlant = new System.Windows.Forms.TextBox();
			this.grpBoxDept = new System.Windows.Forms.GroupBox();
			this.tBoxDeptShort = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnDelete = new System.Windows.Forms.Button();
			this.grpBoxPlt.SuspendLayout();
			this.grpBoxDept.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblPlt
			// 
			this.lblPlt.Location = new System.Drawing.Point(32, 16);
			this.lblPlt.Name = "lblPlt";
			this.lblPlt.Size = new System.Drawing.Size(64, 23);
			this.lblPlt.TabIndex = 0;
			this.lblPlt.Text = "Plant";
			this.lblPlt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPlantName
			// 
			this.lblPlantName.Location = new System.Drawing.Point(24, 48);
			this.lblPlantName.Name = "lblPlantName";
			this.lblPlantName.Size = new System.Drawing.Size(72, 23);
			this.lblPlantName.TabIndex = 1;
			this.lblPlantName.Text = "Plant name";
			this.lblPlantName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblDept
			// 
			this.lblDept.Location = new System.Drawing.Point(40, 16);
			this.lblDept.Name = "lblDept";
			this.lblDept.Size = new System.Drawing.Size(64, 23);
			this.lblDept.TabIndex = 2;
			this.lblDept.Text = "Department";
			this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblDes
			// 
			this.lblDes.Location = new System.Drawing.Point(40, 80);
			this.lblDes.Name = "lblDes";
			this.lblDes.Size = new System.Drawing.Size(64, 23);
			this.lblDes.TabIndex = 3;
			this.lblDes.Text = "Description";
			this.lblDes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblUtilPer
			// 
			this.lblUtilPer.Location = new System.Drawing.Point(240, 16);
			this.lblUtilPer.Name = "lblUtilPer";
			this.lblUtilPer.TabIndex = 4;
			this.lblUtilPer.Text = "Util. Percent";
			this.lblUtilPer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBoxPlt
			// 
			this.txtBoxPlt.Location = new System.Drawing.Point(496, 19);
			this.txtBoxPlt.MaxLength = 10;
			this.txtBoxPlt.Name = "txtBoxPlt";
			this.txtBoxPlt.Size = new System.Drawing.Size(96, 20);
			this.txtBoxPlt.TabIndex = 20;
			this.txtBoxPlt.Text = "";
			this.txtBoxPlt.Visible = false;
			// 
			// txtBoxPltName
			// 
			this.txtBoxPltName.Location = new System.Drawing.Point(104, 48);
			this.txtBoxPltName.MaxLength = 40;
			this.txtBoxPltName.Name = "txtBoxPltName";
			this.txtBoxPltName.ReadOnly = true;
			this.txtBoxPltName.Size = new System.Drawing.Size(488, 20);
			this.txtBoxPltName.TabIndex = 30;
			this.txtBoxPltName.Text = "";
			// 
			// txtBoxDept
			// 
			this.txtBoxDept.Location = new System.Drawing.Point(112, 16);
			this.txtBoxDept.MaxLength = 10;
			this.txtBoxDept.Name = "txtBoxDept";
			this.txtBoxDept.Size = new System.Drawing.Size(96, 20);
			this.txtBoxDept.TabIndex = 10;
			this.txtBoxDept.Text = "";
			// 
			// txtBoxDes
			// 
			this.txtBoxDes.Location = new System.Drawing.Point(112, 80);
			this.txtBoxDes.MaxLength = 40;
			this.txtBoxDes.Name = "txtBoxDes";
			this.txtBoxDes.Size = new System.Drawing.Size(488, 20);
			this.txtBoxDes.TabIndex = 30;
			this.txtBoxDes.Text = "";
			// 
			// txtBoxUtilPer
			// 
			this.txtBoxUtilPer.Location = new System.Drawing.Point(352, 16);
			this.txtBoxUtilPer.MaxLength = 10;
			this.txtBoxUtilPer.Name = "txtBoxUtilPer";
			this.txtBoxUtilPer.Size = new System.Drawing.Size(104, 20);
			this.txtBoxUtilPer.TabIndex = 40;
			this.txtBoxUtilPer.Text = "";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(448, 248);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(85, 23);
			this.btnSave.TabIndex = 12;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(552, 248);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(85, 23);
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			this.errorProvider1.DataMember = "";
			// 
			// grpBoxPlt
			// 
			this.grpBoxPlt.Controls.Add(this.tBoxPlant);
			this.grpBoxPlt.Controls.Add(this.txtBoxPlt);
			this.grpBoxPlt.Controls.Add(this.lblPlt);
			this.grpBoxPlt.Controls.Add(this.txtBoxPltName);
			this.grpBoxPlt.Controls.Add(this.lblPlantName);
			this.grpBoxPlt.Location = new System.Drawing.Point(16, 16);
			this.grpBoxPlt.Name = "grpBoxPlt";
			this.grpBoxPlt.Size = new System.Drawing.Size(624, 88);
			this.grpBoxPlt.TabIndex = 10;
			this.grpBoxPlt.TabStop = false;
			this.grpBoxPlt.Text = "Plant Info.";
			// 
			// tBoxPlant
			// 
			this.tBoxPlant.Enabled = false;
			this.tBoxPlant.Location = new System.Drawing.Point(104, 16);
			this.tBoxPlant.Name = "tBoxPlant";
			this.tBoxPlant.ReadOnly = true;
			this.tBoxPlant.TabIndex = 10;
			this.tBoxPlant.Text = "";
			// 
			// grpBoxDept
			// 
			this.grpBoxDept.Controls.Add(this.tBoxDeptShort);
			this.grpBoxDept.Controls.Add(this.label1);
			this.grpBoxDept.Controls.Add(this.lblDes);
			this.grpBoxDept.Controls.Add(this.txtBoxDes);
			this.grpBoxDept.Controls.Add(this.lblUtilPer);
			this.grpBoxDept.Controls.Add(this.txtBoxUtilPer);
			this.grpBoxDept.Controls.Add(this.txtBoxDept);
			this.grpBoxDept.Controls.Add(this.lblDept);
			this.grpBoxDept.Location = new System.Drawing.Point(16, 120);
			this.grpBoxDept.Name = "grpBoxDept";
			this.grpBoxDept.Size = new System.Drawing.Size(624, 112);
			this.grpBoxDept.TabIndex = 20;
			this.grpBoxDept.TabStop = false;
			this.grpBoxDept.Text = "Department";
			// 
			// tBoxDeptShort
			// 
			this.tBoxDeptShort.Location = new System.Drawing.Point(112, 48);
			this.tBoxDeptShort.MaxLength = 2;
			this.tBoxDeptShort.Name = "tBoxDeptShort";
			this.tBoxDeptShort.Size = new System.Drawing.Size(96, 20);
			this.tBoxDeptShort.TabIndex = 20;
			this.tBoxDeptShort.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 11;
			this.label1.Text = "Department Short";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(448, 248);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(85, 23);
			this.btnDelete.TabIndex = 16;
			this.btnDelete.Text = "Delete";
			this.btnDelete.Visible = false;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// FormEditPltDept
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(656, 286);
			this.Controls.Add(this.grpBoxDept);
			this.Controls.Add(this.grpBoxPlt);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnDelete);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormEditPltDept";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Department ";
			this.Load += new System.EventHandler(this.FormEditPltDept_Load);
			this.grpBoxPlt.ResumeLayout(false);
			this.grpBoxDept.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
      	
		#region Methods
		
		private Departament AssembleData()	{
			
			Departament dept = core.createDepartament();
			dept.setPlt(this.tBoxPlant.Text);
			dept.setDept(this.txtBoxDept.Text.Trim());
			dept.setDes1(this.txtBoxDes.Text.Trim());
			dept.setUtilPer( this.txtBoxUtilPer.Text.Trim().Equals(string.Empty)?0:Convert.ToDecimal(this.txtBoxUtilPer.Text.Trim()));
			dept.setDeptShort(this.tBoxDeptShort.Text.Trim());
			return dept;		
		}
       
		private bool  Insert(Departament dept)	{
		    
		    //Check if there is a dept for this plant.
		    if (core.existsDepartament(dept.getPlt(),dept.getDept())){
		        MessageBox.Show("Tha Departament "+dept.getDept()+ " already exist in " + dept.getPlt() +" plant.");
		        return false;
		    }
		    core.writeDepartament(dept);
		    return true;
		}

		private bool  Update(Departament dept)		{	
		    core.updateDepartament(dept);		
		    return true;
		}
		
		private bool  Delete(Departament dept)		{  
			//Check whether there are machines are associated with the dept.
			core.deleteDepartament(dept);
			return true;
		}
      

		private void FormEditPltDept_Load(object sender, System.EventArgs e)	{
            BindPlt();
            
			if (!this.IsInsert)
				BindDept();
				
			SetStatus();
		}

		private void SetStatus(){
			
			if (this.IsUpdate)
		        this.txtBoxDept.ReadOnly = true;
			
			if (this.IsDelete)	{
				foreach (Control objControl in this.grpBoxDept.Controls){ 
				  if (objControl is TextBox)
						((TextBox)objControl).ReadOnly = true;
				}
			    this.btnDelete.Visible = true;
				this.btnSave.Visible   = false;
			}
		}

		private void BindDept()		{
			if (this.departament == null) return;

			this.txtBoxDept.Text    = this.departament.getDept();
			this.txtBoxDes.Text     = this.departament.getDes1();
			this.txtBoxUtilPer.Text = this.departament.getUtilPer().ToString();
			this.tBoxDeptShort.Text = this.departament.getDeptShort().ToString();
		
		}
		private void BindPlt()	{
		    Plant plant = core.readPlant(departament.getPlt());
		    this.tBoxPlant.Text = plant.getPlt();
		    this.txtBoxPltName.Text = plant.getName();
		}

	

		#endregion Methods

		#region Events
		private void btnSave_Click(object sender, System.EventArgs e){
			if (!this.DataValidation()) return ;

	        Departament dept = AssembleData();
			bool IsSuccessful = false;

			if (this.IsInsert) IsSuccessful = Insert(dept);
			if (this.IsUpdate) IsSuccessful = Update(dept);
		   
			if (IsSuccessful)
			{
				this.DialogResult = DialogResult.OK;	
				this.savedDept = dept;
				this.Close();
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)	{
			this.Close();
		}


		private void btnDelete_Click(object sender, System.EventArgs e)	{
			
			DialogResult deleteConfirm = MessageBox.Show("Delete this departament?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (deleteConfirm == DialogResult.No)
					return;

			string strMessage = string.Empty;

            if (core.hasConfigurationForDept(departament))
                    	strMessage += "\n    There are configurations associated with this Dept." ;
                    	
            if (core.hasMachineForDept(departament))
            				strMessage += "\n    There are machines associated with this Dept.    " ;
            				
			if (strMessage != string.Empty)	{
				strMessage += "\n\n    Please delete those nodes first and try again!     \n";
				MessageBox.Show(strMessage, "Can't delete this dept. record!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}
			
			bool IsSuccessful = false;

			if (this.IsDelete) IsSuccessful = Delete(this.departament);
            
			if (IsSuccessful)
			{
				this.Close();
				this.DialogResult = DialogResult.OK;
			}
		}
			
		#endregion Events


	}
}
