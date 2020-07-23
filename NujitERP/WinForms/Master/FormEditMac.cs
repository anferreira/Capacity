using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;

using Nujit.NujitERP.ClassLib.Core;
using GridScheduling.gui;
using Nujit.NujitERP.ClassLib.Core.Machines;


namespace Nujit.NujitERP.WinForms{
	/// <summary>
	/// Summary description for FormEditMac.
	/// </summary>
	public class FormEditMac : System.Windows.Forms.Form
	{
		
		#region Controls

		private System.Windows.Forms.Label lblPlt;
		private System.Windows.Forms.TextBox txtBoxPlt;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.Label lblDept;
		private System.Windows.Forms.TextBox txtBoxDept;
		private System.Windows.Forms.GroupBox grpBoxDept;
		private System.Windows.Forms.Button btnDelete;


		private System.Windows.Forms.GroupBox grpBoxMac;
		private System.Windows.Forms.Label lblMac;
		private System.Windows.Forms.Label lblDes1;
		private System.Windows.Forms.Label lblDes2;
		private System.Windows.Forms.Label lblDes3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblPltInvLoc;
		private System.Windows.Forms.Label lblInOut;
		private System.Windows.Forms.Label lblMacType;
		private System.Windows.Forms.Label lblSchType;
		private System.Windows.Forms.Label lblUtilPer;
		private System.Windows.Forms.Label lblInvDrFr;
		private System.Windows.Forms.Label lblInvRecTo;
		private System.Windows.Forms.Label lblCableLn;
		private System.Windows.Forms.Label lblLnUom;
		private System.Windows.Forms.Label lblSpeed;
		private System.Windows.Forms.Label lblMaxRacks;
		private System.Windows.Forms.Label lblDefSpaceRack;
		private System.Windows.Forms.Label lblDefSpaceUom;
		private System.Windows.Forms.Label lblMaxWgtUom;
		private System.Windows.Forms.Label lblMaxWgt;
		private System.Windows.Forms.TextBox txtBoxMac;
		private System.Windows.Forms.TextBox txtBoxUtilPer;
		private System.Windows.Forms.TextBox txtBoxInOut;
		private System.Windows.Forms.TextBox txtBoxMachTyp;
		private System.Windows.Forms.TextBox txtBoxPltInvLoc;
		private System.Windows.Forms.TextBox txtBoxInvDrFr;
		private System.Windows.Forms.TextBox txtBoxInvRecTo;
		private System.Windows.Forms.TextBox txtBoxSchTyp;
		private System.Windows.Forms.TextBox txtBoxDes1;
		private System.Windows.Forms.TextBox txtBoxDes2;
		private System.Windows.Forms.TextBox txtBoxDes4;
		private System.Windows.Forms.TextBox txtBoxCableLn;
		private System.Windows.Forms.TextBox txtBoxLnUom;
		private System.Windows.Forms.TextBox txtBoxSpeed;
		private System.Windows.Forms.TextBox txtBoxMaxRacks;
		private System.Windows.Forms.TextBox txtBoxDefSpaceRack;
		private System.Windows.Forms.TextBox txtBoxDefSpaceUom;
		private System.Windows.Forms.TextBox txtBoxMaxWgt;
		private System.Windows.Forms.TextBox txtBoxMaxWgtUom;
		private System.Windows.Forms.GroupBox grpBoxPlt;

		private System.Windows.Forms.TextBox txtBoxDes3;
	
		#endregion Controls

		#region Vars

		private bool blnInsert = false;
		private bool blnDelete = false;
		private bool blnUpdate = false;
		private CoreFactory coreFactory;

		private Machine _machine;
		private Machine savedMachine = null;

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

		public Machine machine
		{
			get 
			{
				if (this._machine == null)  {return new Machine();}
				return this._machine;
			}
			set 
			{
				this._machine= value;
			}
		}

		public Machine SavedMachine
		{
			get {return savedMachine;}
		}

		#endregion Properties

		#region Constructors

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormEditMac()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			coreFactory = UtilCoreFactory.createCoreFactory();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

    		blnResult = this.ValidateMach()	&& blnResult ;
         	blnResult = ValidateUtilPer()	&& blnResult ;//
            blnResult = ValidatePDM_CableLn()	&& blnResult ;	//ValidatePDM_Speed()
		    blnResult = ValidatePDM_Speed()	&& blnResult ;       //ValidatePDM_MaxRacks()

			blnResult = ValidatePDM_MaxRacks()	&& blnResult ; 
            blnResult = ValidatePDM_DefSpaceRack()	&& blnResult ;    
	        blnResult = ValidatePDM_MaxWgt()	&& blnResult ; 

			return blnResult;
		}

		private void ClearErrorMark()
		{
			foreach(Control objControl in this.grpBoxMac.Controls)
			{
				errorProvider1.SetError(objControl,"");
			}
		}


		private bool ValidateMach()
		{
			bool IsValid = true;

			if ( this.txtBoxMac.Text == "")
			{
				errorProvider1.SetError(txtBoxMac,"Machine field can not be empty!");
				IsValid = false;
			}

			return IsValid;
		}

		private bool ValidateUtilPer()
		{
			bool IsValid = true;
			
			if (this.txtBoxUtilPer.Text.Trim().Equals(string.Empty)) return true;

			try
			{
            	if ( Convert.ToDecimal(this.txtBoxUtilPer.Text.Trim())>100 ||Convert.ToDecimal(this.txtBoxUtilPer.Text.Trim())<0 )
				{
					errorProvider1.SetError(this.txtBoxUtilPer,"Machine util. percentage should be between 0 and 100!");
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

		private bool ValidatePDM_CableLn()
		{
			bool isValid = true;

			if (this.txtBoxCableLn.Text.Trim().Equals(string.Empty))
				return true;

			try{
				if ((Convert.ToDecimal(this.txtBoxCableLn.Text.Trim()) > 1000000) ||
					 (Convert.ToDecimal(this.txtBoxCableLn.Text.Trim()) < 0)){
					isValid = false;
					errorProvider1.SetError(this.txtBoxCableLn,"A number between 0 and 999999.99 is expected!");
				}else{
				}
			}catch{
				errorProvider1.SetError(txtBoxCableLn,"A number between 0 and 999999.99 is expected!");
				isValid = false;
			}
			return isValid;
		}

		//PDM_Speed

		private bool ValidatePDM_Speed()
		{
			bool IsValid = true;

			if (this.txtBoxSpeed.Text.Trim().Equals(string.Empty)) return true;

			try
			{
				if ( Convert.ToDecimal(txtBoxSpeed.Text.Trim())>1000000 ||Convert.ToDecimal(this.txtBoxSpeed.Text.Trim())<0 )
				{
					errorProvider1.SetError(this.txtBoxSpeed,"A number between 0 and 999999.99 is expected!");
					IsValid = false;
				}
			}
			catch
			{
				errorProvider1.SetError(txtBoxSpeed,"A number between 0 and 999999.99 is expected!");
				IsValid = false;
			
			}
			return IsValid;
		
		}

        //PDM_MaxRacks

		private bool ValidatePDM_MaxRacks()
		{
			bool IsValid = true;

			if (this.txtBoxMaxRacks.Text.Trim().Equals(string.Empty)) return true;

			try
			{
				if ( Convert.ToDecimal(txtBoxMaxRacks.Text.Trim())>1000000 ||Convert.ToDecimal(this.txtBoxMaxRacks.Text.Trim())<0 )
				{
					errorProvider1.SetError(this.txtBoxMaxRacks,"A number between 0 and 99999 is expected!");
					IsValid = false;
				}
			}
			catch
			{
				errorProvider1.SetError(txtBoxMaxRacks,"A number between 0 and 99999 is expected!");
				IsValid = false;
			
			}
			return IsValid;
		
		}


		//PDM_DefSpaceRack [PDM_DefSpaceRack]	[numeric](6, 2) NULL , 

		private bool ValidatePDM_DefSpaceRack()
		{
			bool IsValid = true;

			if (this.txtBoxDefSpaceRack.Text.Trim().Equals(string.Empty)) return true;

			try
			{
				if ( Convert.ToDecimal(txtBoxDefSpaceRack.Text.Trim())>10000 ||Convert.ToDecimal(this.txtBoxDefSpaceRack.Text.Trim())<0 )
				{
					errorProvider1.SetError(this.txtBoxDefSpaceRack,"A number between 0 and 9999.99 is expected!");
					IsValid = false;
				}
			}
			catch
			{
				errorProvider1.SetError(txtBoxDefSpaceRack,"A number between 0 and 9999.99 is expected!");
				IsValid = false;
			
			}
			return IsValid;
		
		}


        //[PDM_MaxWgt]		[numeric](5, 0) NULL
		private bool ValidatePDM_MaxWgt()
		{
			bool IsValid = true;

			if (this.txtBoxMaxWgt.Text.Trim().Equals(string.Empty)) return true;

			try
			{
				if ( Convert.ToDecimal(txtBoxMaxWgt.Text.Trim())>10000 ||Convert.ToDecimal(this.txtBoxMaxWgt.Text.Trim())<0 )
				{
					errorProvider1.SetError(this.txtBoxMaxWgt,"A number between 0 and 99999 is expected!");
					IsValid = false;
				}
			}
			catch
			{
				errorProvider1.SetError(txtBoxMaxWgt,"A number between 0 and 99999 is expected!");
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormEditMac));
			this.lblPlt = new System.Windows.Forms.Label();
			this.lblDept = new System.Windows.Forms.Label();
			this.txtBoxPlt = new System.Windows.Forms.TextBox();
			this.txtBoxDept = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.grpBoxDept = new System.Windows.Forms.GroupBox();
			this.btnDelete = new System.Windows.Forms.Button();
			this.grpBoxMac = new System.Windows.Forms.GroupBox();
			this.txtBoxMaxWgtUom = new System.Windows.Forms.TextBox();
			this.txtBoxMaxWgt = new System.Windows.Forms.TextBox();
			this.txtBoxDefSpaceUom = new System.Windows.Forms.TextBox();
			this.txtBoxDefSpaceRack = new System.Windows.Forms.TextBox();
			this.txtBoxMaxRacks = new System.Windows.Forms.TextBox();
			this.txtBoxSpeed = new System.Windows.Forms.TextBox();
			this.txtBoxLnUom = new System.Windows.Forms.TextBox();
			this.txtBoxCableLn = new System.Windows.Forms.TextBox();
			this.txtBoxDes4 = new System.Windows.Forms.TextBox();
			this.txtBoxDes3 = new System.Windows.Forms.TextBox();
			this.txtBoxDes2 = new System.Windows.Forms.TextBox();
			this.txtBoxDes1 = new System.Windows.Forms.TextBox();
			this.txtBoxSchTyp = new System.Windows.Forms.TextBox();
			this.txtBoxInvRecTo = new System.Windows.Forms.TextBox();
			this.txtBoxInvDrFr = new System.Windows.Forms.TextBox();
			this.txtBoxPltInvLoc = new System.Windows.Forms.TextBox();
			this.txtBoxMachTyp = new System.Windows.Forms.TextBox();
			this.txtBoxInOut = new System.Windows.Forms.TextBox();
			this.txtBoxUtilPer = new System.Windows.Forms.TextBox();
			this.txtBoxMac = new System.Windows.Forms.TextBox();
			this.lblMaxWgtUom = new System.Windows.Forms.Label();
			this.lblDefSpaceUom = new System.Windows.Forms.Label();
			this.lblDefSpaceRack = new System.Windows.Forms.Label();
			this.lblMaxRacks = new System.Windows.Forms.Label();
			this.lblSpeed = new System.Windows.Forms.Label();
			this.lblLnUom = new System.Windows.Forms.Label();
			this.lblCableLn = new System.Windows.Forms.Label();
			this.lblInvRecTo = new System.Windows.Forms.Label();
			this.lblInvDrFr = new System.Windows.Forms.Label();
			this.lblUtilPer = new System.Windows.Forms.Label();
			this.lblSchType = new System.Windows.Forms.Label();
			this.lblMacType = new System.Windows.Forms.Label();
			this.lblInOut = new System.Windows.Forms.Label();
			this.lblPltInvLoc = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lblDes3 = new System.Windows.Forms.Label();
			this.lblDes2 = new System.Windows.Forms.Label();
			this.lblDes1 = new System.Windows.Forms.Label();
			this.lblMac = new System.Windows.Forms.Label();
			this.lblMaxWgt = new System.Windows.Forms.Label();
			this.grpBoxPlt = new System.Windows.Forms.GroupBox();
			this.grpBoxDept.SuspendLayout();
			this.grpBoxMac.SuspendLayout();
			this.grpBoxPlt.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblPlt
			// 
			this.lblPlt.Location = new System.Drawing.Point(40, 21);
			this.lblPlt.Name = "lblPlt";
			this.lblPlt.Size = new System.Drawing.Size(40, 23);
			this.lblPlt.TabIndex = 0;
			this.lblPlt.Text = "Plant";
			this.lblPlt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblDept
			// 
			this.lblDept.Location = new System.Drawing.Point(24, 24);
			this.lblDept.Name = "lblDept";
			this.lblDept.Size = new System.Drawing.Size(64, 16);
			this.lblDept.TabIndex = 2;
			this.lblDept.Text = "Department";
			this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBoxPlt
			// 
			this.txtBoxPlt.Location = new System.Drawing.Point(96, 24);
			this.txtBoxPlt.MaxLength = 10;
			this.txtBoxPlt.Name = "txtBoxPlt";
			this.txtBoxPlt.ReadOnly = true;
			this.txtBoxPlt.Size = new System.Drawing.Size(96, 20);
			this.txtBoxPlt.TabIndex = 6;
			this.txtBoxPlt.Text = "";
			// 
			// txtBoxDept
			// 
			this.txtBoxDept.Location = new System.Drawing.Point(96, 24);
			this.txtBoxDept.MaxLength = 10;
			this.txtBoxDept.Name = "txtBoxDept";
			this.txtBoxDept.ReadOnly = true;
			this.txtBoxDept.Size = new System.Drawing.Size(96, 20);
			this.txtBoxDept.TabIndex = 8;
			this.txtBoxDept.Text = "";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(488, 400);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(85, 23);
			this.btnSave.TabIndex = 12;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(592, 400);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(85, 23);
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// grpBoxDept
			// 
			this.grpBoxDept.Controls.Add(this.txtBoxDept);
			this.grpBoxDept.Controls.Add(this.lblDept);
			this.grpBoxDept.Location = new System.Drawing.Point(248, 8);
			this.grpBoxDept.Name = "grpBoxDept";
			this.grpBoxDept.Size = new System.Drawing.Size(216, 56);
			this.grpBoxDept.TabIndex = 15;
			this.grpBoxDept.TabStop = false;
			this.grpBoxDept.Text = "Department";
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(488, 400);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(85, 23);
			this.btnDelete.TabIndex = 16;
			this.btnDelete.Text = "Delete";
			this.btnDelete.Visible = false;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// grpBoxMac
			// 
			this.grpBoxMac.Controls.Add(this.txtBoxMaxWgtUom);
			this.grpBoxMac.Controls.Add(this.txtBoxMaxWgt);
			this.grpBoxMac.Controls.Add(this.txtBoxDefSpaceUom);
			this.grpBoxMac.Controls.Add(this.txtBoxDefSpaceRack);
			this.grpBoxMac.Controls.Add(this.txtBoxMaxRacks);
			this.grpBoxMac.Controls.Add(this.txtBoxSpeed);
			this.grpBoxMac.Controls.Add(this.txtBoxLnUom);
			this.grpBoxMac.Controls.Add(this.txtBoxCableLn);
			this.grpBoxMac.Controls.Add(this.txtBoxDes4);
			this.grpBoxMac.Controls.Add(this.txtBoxDes3);
			this.grpBoxMac.Controls.Add(this.txtBoxDes2);
			this.grpBoxMac.Controls.Add(this.txtBoxDes1);
			this.grpBoxMac.Controls.Add(this.txtBoxSchTyp);
			this.grpBoxMac.Controls.Add(this.txtBoxInvRecTo);
			this.grpBoxMac.Controls.Add(this.txtBoxInvDrFr);
			this.grpBoxMac.Controls.Add(this.txtBoxPltInvLoc);
			this.grpBoxMac.Controls.Add(this.txtBoxMachTyp);
			this.grpBoxMac.Controls.Add(this.txtBoxInOut);
			this.grpBoxMac.Controls.Add(this.txtBoxUtilPer);
			this.grpBoxMac.Controls.Add(this.txtBoxMac);
			this.grpBoxMac.Controls.Add(this.lblMaxWgtUom);
			this.grpBoxMac.Controls.Add(this.lblDefSpaceUom);
			this.grpBoxMac.Controls.Add(this.lblDefSpaceRack);
			this.grpBoxMac.Controls.Add(this.lblMaxRacks);
			this.grpBoxMac.Controls.Add(this.lblSpeed);
			this.grpBoxMac.Controls.Add(this.lblLnUom);
			this.grpBoxMac.Controls.Add(this.lblCableLn);
			this.grpBoxMac.Controls.Add(this.lblInvRecTo);
			this.grpBoxMac.Controls.Add(this.lblInvDrFr);
			this.grpBoxMac.Controls.Add(this.lblUtilPer);
			this.grpBoxMac.Controls.Add(this.lblSchType);
			this.grpBoxMac.Controls.Add(this.lblMacType);
			this.grpBoxMac.Controls.Add(this.lblInOut);
			this.grpBoxMac.Controls.Add(this.lblPltInvLoc);
			this.grpBoxMac.Controls.Add(this.label5);
			this.grpBoxMac.Controls.Add(this.lblDes3);
			this.grpBoxMac.Controls.Add(this.lblDes2);
			this.grpBoxMac.Controls.Add(this.lblDes1);
			this.grpBoxMac.Controls.Add(this.lblMac);
			this.grpBoxMac.Controls.Add(this.lblMaxWgt);
			this.grpBoxMac.Location = new System.Drawing.Point(16, 72);
			this.grpBoxMac.Name = "grpBoxMac";
			this.grpBoxMac.Size = new System.Drawing.Size(664, 312);
			this.grpBoxMac.TabIndex = 17;
			this.grpBoxMac.TabStop = false;
			this.grpBoxMac.Text = "Machine";
			// 
			// txtBoxMaxWgtUom
			// 
			this.txtBoxMaxWgtUom.Location = new System.Drawing.Point(328, 272);
			this.txtBoxMaxWgtUom.MaxLength = 5;
			this.txtBoxMaxWgtUom.Name = "txtBoxMaxWgtUom";
			this.txtBoxMaxWgtUom.Size = new System.Drawing.Size(96, 20);
			this.txtBoxMaxWgtUom.TabIndex = 38;
			this.txtBoxMaxWgtUom.Text = "";
			// 
			// txtBoxMaxWgt
			// 
			this.txtBoxMaxWgt.Location = new System.Drawing.Point(96, 272);
			this.txtBoxMaxWgt.MaxLength = 5;
			this.txtBoxMaxWgt.Name = "txtBoxMaxWgt";
			this.txtBoxMaxWgt.Size = new System.Drawing.Size(96, 20);
			this.txtBoxMaxWgt.TabIndex = 37;
			this.txtBoxMaxWgt.Text = "";
			// 
			// txtBoxDefSpaceUom
			// 
			this.txtBoxDefSpaceUom.Location = new System.Drawing.Point(544, 248);
			this.txtBoxDefSpaceUom.MaxLength = 5;
			this.txtBoxDefSpaceUom.Name = "txtBoxDefSpaceUom";
			this.txtBoxDefSpaceUom.Size = new System.Drawing.Size(96, 20);
			this.txtBoxDefSpaceUom.TabIndex = 36;
			this.txtBoxDefSpaceUom.Text = "";
			// 
			// txtBoxDefSpaceRack
			// 
			this.txtBoxDefSpaceRack.Location = new System.Drawing.Point(328, 248);
			this.txtBoxDefSpaceRack.MaxLength = 5;
			this.txtBoxDefSpaceRack.Name = "txtBoxDefSpaceRack";
			this.txtBoxDefSpaceRack.Size = new System.Drawing.Size(96, 20);
			this.txtBoxDefSpaceRack.TabIndex = 35;
			this.txtBoxDefSpaceRack.Text = "";
			// 
			// txtBoxMaxRacks
			// 
			this.txtBoxMaxRacks.Location = new System.Drawing.Point(96, 248);
			this.txtBoxMaxRacks.Name = "txtBoxMaxRacks";
			this.txtBoxMaxRacks.Size = new System.Drawing.Size(96, 20);
			this.txtBoxMaxRacks.TabIndex = 34;
			this.txtBoxMaxRacks.Text = "";
			// 
			// txtBoxSpeed
			// 
			this.txtBoxSpeed.Location = new System.Drawing.Point(544, 224);
			this.txtBoxSpeed.MaxLength = 5;
			this.txtBoxSpeed.Name = "txtBoxSpeed";
			this.txtBoxSpeed.Size = new System.Drawing.Size(96, 20);
			this.txtBoxSpeed.TabIndex = 33;
			this.txtBoxSpeed.Text = "";
			// 
			// txtBoxLnUom
			// 
			this.txtBoxLnUom.Location = new System.Drawing.Point(328, 224);
			this.txtBoxLnUom.MaxLength = 5;
			this.txtBoxLnUom.Name = "txtBoxLnUom";
			this.txtBoxLnUom.Size = new System.Drawing.Size(96, 20);
			this.txtBoxLnUom.TabIndex = 32;
			this.txtBoxLnUom.Text = "";
			// 
			// txtBoxCableLn
			// 
			this.txtBoxCableLn.Location = new System.Drawing.Point(96, 224);
			this.txtBoxCableLn.Name = "txtBoxCableLn";
			this.txtBoxCableLn.Size = new System.Drawing.Size(96, 20);
			this.txtBoxCableLn.TabIndex = 31;
			this.txtBoxCableLn.Text = "";
			// 
			// txtBoxDes4
			// 
			this.txtBoxDes4.Location = new System.Drawing.Point(96, 176);
			this.txtBoxDes4.MaxLength = 40;
			this.txtBoxDes4.Name = "txtBoxDes4";
			this.txtBoxDes4.Size = new System.Drawing.Size(544, 20);
			this.txtBoxDes4.TabIndex = 30;
			this.txtBoxDes4.Text = "";
			// 
			// txtBoxDes3
			// 
			this.txtBoxDes3.Location = new System.Drawing.Point(96, 153);
			this.txtBoxDes3.MaxLength = 40;
			this.txtBoxDes3.Name = "txtBoxDes3";
			this.txtBoxDes3.Size = new System.Drawing.Size(544, 20);
			this.txtBoxDes3.TabIndex = 29;
			this.txtBoxDes3.Text = "";
			// 
			// txtBoxDes2
			// 
			this.txtBoxDes2.Location = new System.Drawing.Point(96, 130);
			this.txtBoxDes2.MaxLength = 40;
			this.txtBoxDes2.Name = "txtBoxDes2";
			this.txtBoxDes2.Size = new System.Drawing.Size(544, 20);
			this.txtBoxDes2.TabIndex = 28;
			this.txtBoxDes2.Text = "";
			// 
			// txtBoxDes1
			// 
			this.txtBoxDes1.Location = new System.Drawing.Point(96, 107);
			this.txtBoxDes1.MaxLength = 40;
			this.txtBoxDes1.Name = "txtBoxDes1";
			this.txtBoxDes1.Size = new System.Drawing.Size(544, 20);
			this.txtBoxDes1.TabIndex = 27;
			this.txtBoxDes1.Text = "";
			// 
			// txtBoxSchTyp
			// 
			this.txtBoxSchTyp.Location = new System.Drawing.Point(544, 19);
			this.txtBoxSchTyp.MaxLength = 10;
			this.txtBoxSchTyp.Name = "txtBoxSchTyp";
			this.txtBoxSchTyp.Size = new System.Drawing.Size(96, 20);
			this.txtBoxSchTyp.TabIndex = 26;
			this.txtBoxSchTyp.Text = "";
			// 
			// txtBoxInvRecTo
			// 
			this.txtBoxInvRecTo.Location = new System.Drawing.Point(544, 65);
			this.txtBoxInvRecTo.MaxLength = 10;
			this.txtBoxInvRecTo.Name = "txtBoxInvRecTo";
			this.txtBoxInvRecTo.Size = new System.Drawing.Size(96, 20);
			this.txtBoxInvRecTo.TabIndex = 25;
			this.txtBoxInvRecTo.Text = "";
			// 
			// txtBoxInvDrFr
			// 
			this.txtBoxInvDrFr.Location = new System.Drawing.Point(328, 65);
			this.txtBoxInvDrFr.MaxLength = 10;
			this.txtBoxInvDrFr.Name = "txtBoxInvDrFr";
			this.txtBoxInvDrFr.Size = new System.Drawing.Size(96, 20);
			this.txtBoxInvDrFr.TabIndex = 24;
			this.txtBoxInvDrFr.Text = "";
			// 
			// txtBoxPltInvLoc
			// 
			this.txtBoxPltInvLoc.Location = new System.Drawing.Point(328, 43);
			this.txtBoxPltInvLoc.MaxLength = 40;
			this.txtBoxPltInvLoc.Name = "txtBoxPltInvLoc";
			this.txtBoxPltInvLoc.Size = new System.Drawing.Size(312, 20);
			this.txtBoxPltInvLoc.TabIndex = 23;
			this.txtBoxPltInvLoc.Text = "";
			// 
			// txtBoxMachTyp
			// 
			this.txtBoxMachTyp.Location = new System.Drawing.Point(328, 19);
			this.txtBoxMachTyp.MaxLength = 10;
			this.txtBoxMachTyp.Name = "txtBoxMachTyp";
			this.txtBoxMachTyp.Size = new System.Drawing.Size(96, 20);
			this.txtBoxMachTyp.TabIndex = 22;
			this.txtBoxMachTyp.Text = "";
			// 
			// txtBoxInOut
			// 
			this.txtBoxInOut.Location = new System.Drawing.Point(96, 65);
			this.txtBoxInOut.MaxLength = 1;
			this.txtBoxInOut.Name = "txtBoxInOut";
			this.txtBoxInOut.Size = new System.Drawing.Size(96, 20);
			this.txtBoxInOut.TabIndex = 21;
			this.txtBoxInOut.Text = "";
			// 
			// txtBoxUtilPer
			// 
			this.txtBoxUtilPer.Location = new System.Drawing.Point(96, 43);
			this.txtBoxUtilPer.Name = "txtBoxUtilPer";
			this.txtBoxUtilPer.Size = new System.Drawing.Size(96, 20);
			this.txtBoxUtilPer.TabIndex = 20;
			this.txtBoxUtilPer.Text = "";
			// 
			// txtBoxMac
			// 
			this.txtBoxMac.Location = new System.Drawing.Point(96, 19);
			this.txtBoxMac.MaxLength = 10;
			this.txtBoxMac.Name = "txtBoxMac";
			this.txtBoxMac.Size = new System.Drawing.Size(96, 20);
			this.txtBoxMac.TabIndex = 19;
			this.txtBoxMac.Text = "";
			// 
			// lblMaxWgtUom
			// 
			this.lblMaxWgtUom.Location = new System.Drawing.Point(240, 269);
			this.lblMaxWgtUom.Name = "lblMaxWgtUom";
			this.lblMaxWgtUom.Size = new System.Drawing.Size(80, 23);
			this.lblMaxWgtUom.TabIndex = 18;
			this.lblMaxWgtUom.Tag = "";
			this.lblMaxWgtUom.Text = "Max Wgt. Uom";
			this.lblMaxWgtUom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblDefSpaceUom
			// 
			this.lblDefSpaceUom.Location = new System.Drawing.Point(456, 245);
			this.lblDefSpaceUom.Name = "lblDefSpaceUom";
			this.lblDefSpaceUom.Size = new System.Drawing.Size(80, 23);
			this.lblDefSpaceUom.TabIndex = 17;
			this.lblDefSpaceUom.Text = "DefSpaceUom";
			this.lblDefSpaceUom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblDefSpaceRack
			// 
			this.lblDefSpaceRack.Location = new System.Drawing.Point(240, 245);
			this.lblDefSpaceRack.Name = "lblDefSpaceRack";
			this.lblDefSpaceRack.Size = new System.Drawing.Size(80, 23);
			this.lblDefSpaceRack.TabIndex = 16;
			this.lblDefSpaceRack.Text = "DefSpaceRack";
			this.lblDefSpaceRack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblMaxRacks
			// 
			this.lblMaxRacks.Location = new System.Drawing.Point(8, 245);
			this.lblMaxRacks.Name = "lblMaxRacks";
			this.lblMaxRacks.Size = new System.Drawing.Size(80, 23);
			this.lblMaxRacks.TabIndex = 15;
			this.lblMaxRacks.Text = "MaxRacks";
			this.lblMaxRacks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSpeed
			// 
			this.lblSpeed.Location = new System.Drawing.Point(464, 221);
			this.lblSpeed.Name = "lblSpeed";
			this.lblSpeed.Size = new System.Drawing.Size(72, 23);
			this.lblSpeed.TabIndex = 14;
			this.lblSpeed.Text = "Speed";
			this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblLnUom
			// 
			this.lblLnUom.Location = new System.Drawing.Point(240, 221);
			this.lblLnUom.Name = "lblLnUom";
			this.lblLnUom.Size = new System.Drawing.Size(80, 23);
			this.lblLnUom.TabIndex = 13;
			this.lblLnUom.Text = "LnUom";
			this.lblLnUom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblCableLn
			// 
			this.lblCableLn.Location = new System.Drawing.Point(8, 221);
			this.lblCableLn.Name = "lblCableLn";
			this.lblCableLn.Size = new System.Drawing.Size(80, 23);
			this.lblCableLn.TabIndex = 12;
			this.lblCableLn.Text = "CableLn";
			this.lblCableLn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblInvRecTo
			// 
			this.lblInvRecTo.Location = new System.Drawing.Point(464, 65);
			this.lblInvRecTo.Name = "lblInvRecTo";
			this.lblInvRecTo.Size = new System.Drawing.Size(72, 23);
			this.lblInvRecTo.TabIndex = 11;
			this.lblInvRecTo.Text = "InvRecTo";
			this.lblInvRecTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblInvDrFr
			// 
			this.lblInvDrFr.Location = new System.Drawing.Point(240, 65);
			this.lblInvDrFr.Name = "lblInvDrFr";
			this.lblInvDrFr.Size = new System.Drawing.Size(80, 23);
			this.lblInvDrFr.TabIndex = 10;
			this.lblInvDrFr.Text = "InvDrFr";
			this.lblInvDrFr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblUtilPer
			// 
			this.lblUtilPer.Location = new System.Drawing.Point(16, 40);
			this.lblUtilPer.Name = "lblUtilPer";
			this.lblUtilPer.Size = new System.Drawing.Size(72, 23);
			this.lblUtilPer.TabIndex = 9;
			this.lblUtilPer.Text = "Util. Percent";
			this.lblUtilPer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSchType
			// 
			this.lblSchType.Location = new System.Drawing.Point(472, 16);
			this.lblSchType.Name = "lblSchType";
			this.lblSchType.Size = new System.Drawing.Size(64, 23);
			this.lblSchType.TabIndex = 8;
			this.lblSchType.Text = "Sch. Type";
			this.lblSchType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblMacType
			// 
			this.lblMacType.Location = new System.Drawing.Point(256, 16);
			this.lblMacType.Name = "lblMacType";
			this.lblMacType.Size = new System.Drawing.Size(64, 23);
			this.lblMacType.TabIndex = 7;
			this.lblMacType.Text = "Mac. type";
			this.lblMacType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblInOut
			// 
			this.lblInOut.Location = new System.Drawing.Point(16, 62);
			this.lblInOut.Name = "lblInOut";
			this.lblInOut.Size = new System.Drawing.Size(72, 23);
			this.lblInOut.TabIndex = 6;
			this.lblInOut.Text = "InOut";
			this.lblInOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPltInvLoc
			// 
			this.lblPltInvLoc.Location = new System.Drawing.Point(240, 43);
			this.lblPltInvLoc.Name = "lblPltInvLoc";
			this.lblPltInvLoc.Size = new System.Drawing.Size(80, 23);
			this.lblPltInvLoc.TabIndex = 5;
			this.lblPltInvLoc.Text = "PltInvLoc";
			this.lblPltInvLoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 176);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "Description 4";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblDes3
			// 
			this.lblDes3.Location = new System.Drawing.Point(8, 153);
			this.lblDes3.Name = "lblDes3";
			this.lblDes3.Size = new System.Drawing.Size(80, 23);
			this.lblDes3.TabIndex = 3;
			this.lblDes3.Text = "Description 3";
			this.lblDes3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblDes2
			// 
			this.lblDes2.Location = new System.Drawing.Point(8, 130);
			this.lblDes2.Name = "lblDes2";
			this.lblDes2.Size = new System.Drawing.Size(80, 23);
			this.lblDes2.TabIndex = 2;
			this.lblDes2.Text = "Description 2";
			this.lblDes2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblDes1
			// 
			this.lblDes1.Location = new System.Drawing.Point(8, 107);
			this.lblDes1.Name = "lblDes1";
			this.lblDes1.Size = new System.Drawing.Size(80, 23);
			this.lblDes1.TabIndex = 1;
			this.lblDes1.Text = "Description 1";
			this.lblDes1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblMac
			// 
			this.lblMac.Location = new System.Drawing.Point(16, 16);
			this.lblMac.Name = "lblMac";
			this.lblMac.Size = new System.Drawing.Size(72, 23);
			this.lblMac.TabIndex = 0;
			this.lblMac.Text = "Machine";
			this.lblMac.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblMaxWgt
			// 
			this.lblMaxWgt.Location = new System.Drawing.Point(8, 269);
			this.lblMaxWgt.Name = "lblMaxWgt";
			this.lblMaxWgt.Size = new System.Drawing.Size(80, 23);
			this.lblMaxWgt.TabIndex = 18;
			this.lblMaxWgt.Tag = "Max Wgt. Uom";
			this.lblMaxWgt.Text = "Max Wgt.";
			this.lblMaxWgt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpBoxPlt
			// 
			this.grpBoxPlt.Controls.Add(this.lblPlt);
			this.grpBoxPlt.Controls.Add(this.txtBoxPlt);
			this.grpBoxPlt.Location = new System.Drawing.Point(16, 8);
			this.grpBoxPlt.Name = "grpBoxPlt";
			this.grpBoxPlt.Size = new System.Drawing.Size(216, 56);
			this.grpBoxPlt.TabIndex = 18;
			this.grpBoxPlt.TabStop = false;
			this.grpBoxPlt.Text = "Plant";
			// 
			// FormEditMac
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(696, 438);
			this.Controls.Add(this.grpBoxPlt);
			this.Controls.Add(this.grpBoxMac);
			this.Controls.Add(this.grpBoxDept);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnSave);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormEditMac";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Machine";
			this.Load += new System.EventHandler(this.FormEditMac_Load);
			this.grpBoxDept.ResumeLayout(false);
			this.grpBoxMac.ResumeLayout(false);
			this.grpBoxPlt.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Methods

		private void btnSave_Click(object sender, System.EventArgs e)
		{
        	if (!this.DataValidation()) return ;

    		Machine newMachine = AssembleData();

			bool IsSuccessful = false;

			if (this.IsInsert) IsSuccessful = Insert(newMachine);
			if (this.IsUpdate) IsSuccessful = Update(newMachine);
			if (this.IsDelete) IsSuccessful = Delete(newMachine);
            
			if (IsSuccessful) {
				this.DialogResult = DialogResult.OK;
				this.savedMachine = newMachine;
				this.Close();
			}
		}

		private Machine AssembleData()
		{
			Machine newMachine = new Machine();

			newMachine.setPlt (this.txtBoxPlt.Text.Trim());
			newMachine.setDept (this.txtBoxDept.Text.Trim());

			newMachine.setMach (this.txtBoxMac.Text.Trim());
			newMachine.setDes1 (this.txtBoxDes1.Text.Trim());
			newMachine.setDes2 (this.txtBoxDes2.Text.Trim());
			newMachine.setDes3 (this.txtBoxDes3.Text.Trim());
			newMachine.setDes4 (this.txtBoxDes4.Text.Trim());

			newMachine.setPltLoc (this.txtBoxPltInvLoc.Text.Trim());
			newMachine.setInOut (this.txtBoxInOut.Text.Trim());
			newMachine.setMachTyp (this.txtBoxMachTyp.Text.Trim());
			newMachine.setSchType (this.txtBoxSchTyp.Text.Trim());
			newMachine.setUtilPer (Convert.ToDecimal(this.txtBoxUtilPer.Text.Trim()));
			newMachine.setInvDrFr (this.txtBoxInvDrFr.Text.Trim());
			newMachine.setInvRecTo (this.txtBoxInvRecTo.Text.Trim());
                                         
			newMachine.setCableLn (Convert.ToDecimal(this.txtBoxCableLn.Text.Trim()));
			newMachine.setLnUom (this.txtBoxLnUom.Text.Trim());
			newMachine.setSpeed (Convert.ToDecimal(this.txtBoxSpeed.Text.Trim()));
			newMachine.setMaxRacks (Convert.ToDecimal(this.txtBoxMaxRacks.Text.Trim()));
			newMachine.setDefSpaceRack (Convert.ToDecimal(this.txtBoxDefSpaceRack.Text.Trim()));
			newMachine.setDefSpaceUom (this.txtBoxDefSpaceUom.Text.Trim());
			newMachine.setMaxWgt (Convert.ToDecimal(this.txtBoxMaxWgt.Text.Trim()));
			newMachine.setMaxWgtUom (this.txtBoxMaxWgtUom.Text.Trim());
   
			return newMachine;
		
		}
       
		private bool  Insert(Machine newMachine)
		{
			if (coreFactory.existsMachine(newMachine.getPlt(), newMachine.getDept(), newMachine.getMach())){
				MessageBox.Show("The machine  " + newMachine.getMach() + " already exists");
				return false;
			}

			try 
			{
				coreFactory.writeMachine (newMachine);
			}
			catch (Exception ex)
			{
				FormException formEx = new FormException (ex);
				formEx.Show();
			}
			return true;
		}

		private bool  Update(Machine newMachine)
		{			
			try 
			{
				coreFactory.updateMachine (newMachine);
			}
			catch (Exception ex)
			{
				FormException formEx = new FormException (ex);
				formEx.Show();
			}
			return true;
		}

		private bool Delete(Machine newMachine)
		{  
			try 
			{
				coreFactory.deleteMachine(this._machine);
			}
			catch (Exception ex)
			{
				FormException formEx = new FormException (ex);
				formEx.Show();
			}
			return true;
		}
      
		private void BindData(Machine newMachine)
		{
			if (newMachine == null ) return;

			this.txtBoxPlt.Text			     =    newMachine.getPlt();
			this.txtBoxDept.Text             =    newMachine.getDept();       
			this.txtBoxMac.Text              =    newMachine.getMach();

            this.txtBoxDes1.Text             =    newMachine.getDes1();
			this.txtBoxDes2.Text             =    newMachine.getDes2();
			this.txtBoxDes3.Text             =    newMachine.getDes3();
			this.txtBoxDes4.Text             =    newMachine.getDes4();
            
			this.txtBoxPltInvLoc.Text        =    newMachine.getPltLoc();
			this.txtBoxInOut.Text            =    newMachine.getInOut();
			this.txtBoxMachTyp.Text          =    newMachine.getMachTyp();
			this.txtBoxSchTyp.Text           =    newMachine.getSchType();
            this.txtBoxUtilPer.Text  		 =    newMachine.getUtilPer().ToString();
			this.txtBoxInvDrFr.Text          =    newMachine.getInvDrFr();
            this.txtBoxInvRecTo.Text         =    newMachine.getInvRecTo();

			this.txtBoxCableLn.Text          =    newMachine.getCableLn().ToString();
			this.txtBoxLnUom.Text            =    newMachine.getLnUom();
			this.txtBoxSpeed.Text			 =    newMachine.getSpeed().ToString();
			this.txtBoxMaxRacks.Text         =    newMachine.getMaxRacks().ToString();
			this.txtBoxDefSpaceRack.Text     =    newMachine.getDefSpaceRack().ToString();
			this.txtBoxDefSpaceUom.Text      =    newMachine.getDefSpaceUom();
			this.txtBoxMaxWgt.Text           =    newMachine.getMaxWgt().ToString();
            this.txtBoxMaxWgtUom.Text        =    newMachine.getMaxWgtUom();

		}
	
		private void SetStatus()
		{
			if (this.IsUpdate)
			{
				  txtBoxMac.ReadOnly = true;

            
			}

			if (this.IsInsert)  txtBoxMac.Enabled = true;

			if (this.IsDelete)
			{
				foreach (Control objControl in this.grpBoxMac.Controls)
				{   if (objControl is TextBox)
						((TextBox)objControl).ReadOnly = true;
				}
			
				this.btnDelete.Visible = true;
				this.btnSave.Visible   = false;
			
			}
		}

		#endregion Methods

		#region Events

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void FormEditMac_Load(object sender, System.EventArgs e)
		{
			BindData(this._machine);

			SetStatus();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			bool IsSuccessful = false;

			if (this.IsDelete) IsSuccessful = Delete(this._machine);
            
			if (IsSuccessful) 
			{
				this.Close();
				this.DialogResult = DialogResult.OK;
			}
		}
			
	
		#endregion Events

	
	}
}
