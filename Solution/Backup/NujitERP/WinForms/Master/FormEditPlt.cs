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
	/// Summary description for FormEditPlt.
	/// </summary>
	public class FormEditPlt : System.Windows.Forms.Form
	{
		#region Vars

		private Plant plant;
		private Plant savedPlant = null;
		
		private bool blnInsert = false;
		private bool blnDelete = false;
		private bool blnUpdate = false;
		private CoreFactory core = UtilCoreFactory.createCoreFactory();
		  

		#endregion Vars

		#region Controls


		private System.Windows.Forms.Label lblPlt;
		private System.Windows.Forms.Label lblPlantName;
		private System.Windows.Forms.Label lblAds1;
		private System.Windows.Forms.Label lblAds2;
		private System.Windows.Forms.Label lblAds3;
		private System.Windows.Forms.Label lblAds4;
		private System.Windows.Forms.TextBox txtBoxPlt;
		private System.Windows.Forms.TextBox txtBoxAds1;
		private System.Windows.Forms.TextBox txtBoxAds2;
		private System.Windows.Forms.TextBox txtBoxAds3;
		private System.Windows.Forms.TextBox txtBoxAds4;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtBoxPltName;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxPltShort;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion Controls

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

		public Plant SavedPlant
		{
			get{return savedPlant;}
		}

		#endregion Properties

		#region Constructors
		public FormEditPlt(Plant plt)		{
			
			InitializeComponent();
			plant = core.createPlant();
			this.plant=plt;

			
		}
        public FormEditPlt()		{
			
			InitializeComponent();
			
		}
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

			blnResult = this.ValidatePlt()	&& blnResult ;
				
			return blnResult;
		}

		private bool ValidatePlt()
		{
			bool IsValid = true;

			if ( this.txtBoxPlt.Text == "")
			{
				errorProvider1.SetError(txtBoxPlt,"Plt field can not be empty!");
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
			this.lblAds1 = new System.Windows.Forms.Label();
			this.lblAds2 = new System.Windows.Forms.Label();
			this.lblAds3 = new System.Windows.Forms.Label();
			this.lblAds4 = new System.Windows.Forms.Label();
			this.txtBoxPlt = new System.Windows.Forms.TextBox();
			this.txtBoxPltName = new System.Windows.Forms.TextBox();
			this.txtBoxAds1 = new System.Windows.Forms.TextBox();
			this.txtBoxAds2 = new System.Windows.Forms.TextBox();
			this.txtBoxAds3 = new System.Windows.Forms.TextBox();
			this.txtBoxAds4 = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.btnDelete = new System.Windows.Forms.Button();
			this.txtBoxPltShort = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblPlt
			// 
			this.lblPlt.Location = new System.Drawing.Point(12, 24);
			this.lblPlt.Name = "lblPlt";
			this.lblPlt.Size = new System.Drawing.Size(90, 23);
			this.lblPlt.TabIndex = 0;
			this.lblPlt.Text = "Plant Code";
			this.lblPlt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPlantName
			// 
			this.lblPlantName.Location = new System.Drawing.Point(12, 47);
			this.lblPlantName.Name = "lblPlantName";
			this.lblPlantName.Size = new System.Drawing.Size(90, 23);
			this.lblPlantName.TabIndex = 1;
			this.lblPlantName.Text = "Plant name";
			this.lblPlantName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblAds1
			// 
			this.lblAds1.Location = new System.Drawing.Point(12, 96);
			this.lblAds1.Name = "lblAds1";
			this.lblAds1.Size = new System.Drawing.Size(90, 23);
			this.lblAds1.TabIndex = 2;
			this.lblAds1.Text = "Address 1";
			this.lblAds1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblAds2
			// 
			this.lblAds2.Location = new System.Drawing.Point(12, 120);
			this.lblAds2.Name = "lblAds2";
			this.lblAds2.Size = new System.Drawing.Size(90, 23);
			this.lblAds2.TabIndex = 3;
			this.lblAds2.Text = "Address 2 ";
			this.lblAds2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblAds3
			// 
			this.lblAds3.Location = new System.Drawing.Point(12, 144);
			this.lblAds3.Name = "lblAds3";
			this.lblAds3.Size = new System.Drawing.Size(90, 23);
			this.lblAds3.TabIndex = 4;
			this.lblAds3.Text = "Address 3";
			this.lblAds3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblAds4
			// 
			this.lblAds4.Location = new System.Drawing.Point(12, 168);
			this.lblAds4.Name = "lblAds4";
			this.lblAds4.Size = new System.Drawing.Size(90, 23);
			this.lblAds4.TabIndex = 5;
			this.lblAds4.Text = "Address 4";
			this.lblAds4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBoxPlt
			// 
			this.txtBoxPlt.Location = new System.Drawing.Point(110, 24);
			this.txtBoxPlt.MaxLength = 10;
			this.txtBoxPlt.Name = "txtBoxPlt";
			this.txtBoxPlt.TabIndex = 1;
			this.txtBoxPlt.Text = "";
			// 
			// txtBoxPltName
			// 
			this.txtBoxPltName.Location = new System.Drawing.Point(110, 48);
			this.txtBoxPltName.MaxLength = 40;
			this.txtBoxPltName.Name = "txtBoxPltName";
			this.txtBoxPltName.Size = new System.Drawing.Size(456, 20);
			this.txtBoxPltName.TabIndex = 2;
			this.txtBoxPltName.Text = "";
			// 
			// txtBoxAds1
			// 
			this.txtBoxAds1.Location = new System.Drawing.Point(110, 96);
			this.txtBoxAds1.MaxLength = 40;
			this.txtBoxAds1.Name = "txtBoxAds1";
			this.txtBoxAds1.Size = new System.Drawing.Size(456, 20);
			this.txtBoxAds1.TabIndex = 4;
			this.txtBoxAds1.Text = "";
			// 
			// txtBoxAds2
			// 
			this.txtBoxAds2.Location = new System.Drawing.Point(110, 120);
			this.txtBoxAds2.MaxLength = 40;
			this.txtBoxAds2.Name = "txtBoxAds2";
			this.txtBoxAds2.Size = new System.Drawing.Size(456, 20);
			this.txtBoxAds2.TabIndex = 5;
			this.txtBoxAds2.Text = "";
			// 
			// txtBoxAds3
			// 
			this.txtBoxAds3.Location = new System.Drawing.Point(110, 144);
			this.txtBoxAds3.MaxLength = 40;
			this.txtBoxAds3.Name = "txtBoxAds3";
			this.txtBoxAds3.Size = new System.Drawing.Size(456, 20);
			this.txtBoxAds3.TabIndex = 6;
			this.txtBoxAds3.Text = "";
			// 
			// txtBoxAds4
			// 
			this.txtBoxAds4.Location = new System.Drawing.Point(110, 168);
			this.txtBoxAds4.MaxLength = 40;
			this.txtBoxAds4.Name = "txtBoxAds4";
			this.txtBoxAds4.Size = new System.Drawing.Size(456, 20);
			this.txtBoxAds4.TabIndex = 7;
			this.txtBoxAds4.Text = "";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(376, 200);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(85, 23);
			this.btnSave.TabIndex = 12;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(480, 200);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(85, 23);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			this.errorProvider1.DataMember = "";
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(376, 200);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(85, 23);
			this.btnDelete.TabIndex = 8;
			this.btnDelete.Text = "Delete";
			this.btnDelete.Visible = false;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// txtBoxPltShort
			// 
			this.txtBoxPltShort.Location = new System.Drawing.Point(110, 72);
			this.txtBoxPltShort.MaxLength = 3;
			this.txtBoxPltShort.Name = "txtBoxPltShort";
			this.txtBoxPltShort.TabIndex = 3;
			this.txtBoxPltShort.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 23);
			this.label2.TabIndex = 17;
			this.label2.Text = "Plant Short";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FormEditPlt
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(602, 232);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtBoxPltShort);
			this.Controls.Add(this.txtBoxAds4);
			this.Controls.Add(this.txtBoxAds3);
			this.Controls.Add(this.txtBoxAds2);
			this.Controls.Add(this.txtBoxAds1);
			this.Controls.Add(this.txtBoxPltName);
			this.Controls.Add(this.txtBoxPlt);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lblAds4);
			this.Controls.Add(this.lblAds3);
			this.Controls.Add(this.lblAds2);
			this.Controls.Add(this.lblAds1);
			this.Controls.Add(this.lblPlantName);
			this.Controls.Add(this.lblPlt);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnSave);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormEditPlt";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormEditPlt";
			this.Load += new System.EventHandler(this.FormEditPlt_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region Methods
		private Plant AssemblePlt()	{
		    Plant plt = core.createPlant();
			plt.setAds1(txtBoxAds1.Text.Trim());
			plt.setAds2(txtBoxAds2.Text.Trim());
			plt.setAds3(txtBoxAds3.Text.Trim());
			plt.setAds4(txtBoxAds4.Text.Trim());
			plt.setName(txtBoxPltName.Text.Trim());
			plt.setPlt(txtBoxPlt.Text.Trim());
			plt.setPltShort(this.txtBoxPltShort.Text.Trim());
			return plt;
		}
       
		private bool  InserPlt(Plant pltToSave)
		{
		    if (core.existsPlant(pltToSave.getPlt())){
		        MessageBox.Show("The plant " + pltToSave.getPlt() + " already exists");
				return false;
		    }
		    core.insertPlant(pltToSave);
            return true;
		}

		private bool  UpdatePlt(Plant pltToSave)
		{	
		    core.updatePlant(pltToSave);
		    return true;
		}
      

		private void BindData()
		{
			this.txtBoxPlt.Text     = plant.getPlt();
			this.txtBoxPltName.Text = plant.getName();
			this.txtBoxAds1.Text    = plant.getAds1();
			this.txtBoxAds2.Text    = plant.getAds1();
			this.txtBoxAds3.Text    = plant.getAds1();
			this.txtBoxAds4.Text    = plant.getAds1();			
			this.txtBoxPltShort.Text= plant.getPltShort();
		}

		private void SetDeleteStatus()
		{
			foreach (Control objControl  in this.Controls)
			{
				if (objControl is TextBox)
				{
					((TextBox)objControl).ReadOnly = true;
				}
			}

    		this.btnDelete.Visible = true;
			this.btnSave.Visible   = false;
					
		}

		#endregion Methods

		#region Events

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (!this.DataValidation()) return ;

			Plant pltToSave = AssemblePlt();
			bool IsSuccessful = false;

			if (this.IsInsert) IsSuccessful = InserPlt(pltToSave);
			else IsSuccessful = UpdatePlt(pltToSave);

			if (IsSuccessful) {
				this.DialogResult = DialogResult.OK;
				savedPlant = pltToSave;
				this.Close();
			}
		}

		private void FormEditPlt_Load(object sender, System.EventArgs e)
		{
			this.Text = "Add new plant";
			if (this.IsUpdate == true  && this.plant != null)
			{	
				
				this.BindData();
				this.txtBoxPlt.ReadOnly = true;

				this.Text = "Update plant information";
				return;
			}

			if (this.IsDelete)
			{
				this.BindData();
				SetDeleteStatus();
				this.Text = "Delete plant record ";
				return;
			}

		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{   
			DialogResult deleteConfirm = MessageBox.Show("Delete this plant?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (deleteConfirm == DialogResult.No)
					return;
					
            if (plant!= null && !core.hasDeptForPlant(plant.getPlt()))			{
				try 
				{
					core.deletePlant(plant);
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				catch 
				{
					MessageBox.Show("  Unable to delete this plant.   ","Delete plant failed!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}
			else 
			{
				MessageBox.Show("  This plant has department records.   \n  Please delete the deptparment records first and try again!\n\n ","Delete records failed!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}

		}


		#endregion Events
	}
}
