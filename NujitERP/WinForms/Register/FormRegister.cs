using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Microsoft.Win32;

using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Encryption;
using Nujit.NujitERP.ClassLib.Register;

namespace Nujit.NujitERP.WinForms.Register
{
	/// <summary>
	/// Summary description for FormRegister.
	/// </summary>
	public class FormRegister : System.Windows.Forms.Form
	{	 
		#region Controls

		private System.Windows.Forms.Label lblProdCode;
		private System.Windows.Forms.Panel panelTitle;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxProdCode;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ErrorProvider errorProviderChecker;
		private System.Windows.Forms.TextBox textBoxSN;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion Controls
    
		#region contructors
		public FormRegister()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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


		#endregion contructors

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblProdCode = new System.Windows.Forms.Label();
			this.panelTitle = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxProdCode = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.errorProviderChecker = new System.Windows.Forms.ErrorProvider();
			this.textBoxSN = new System.Windows.Forms.TextBox();
			this.panelTitle.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblProdCode
			// 
			this.lblProdCode.Location = new System.Drawing.Point(24, 88);
			this.lblProdCode.Name = "lblProdCode";
			this.lblProdCode.TabIndex = 0;
			this.lblProdCode.Text = "Prod Code";
			this.lblProdCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panelTitle
			// 
			this.panelTitle.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.panelTitle.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.label3,
																					 this.label2});
			this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTitle.Name = "panelTitle";
			this.panelTitle.Size = new System.Drawing.Size(480, 64);
			this.panelTitle.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(40, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(440, 16);
			this.label3.TabIndex = 1;
			this.label3.Text = "Please enter the registration infomation you received when purchasing NujitERP ";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(24, 8);
			this.label2.Name = "label2";
			this.label2.TabIndex = 0;
			this.label2.Text = "Register ";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 120);
			this.label1.Name = "label1";
			this.label1.TabIndex = 2;
			this.label1.Text = "Serial Number";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxProdCode
			// 
			this.textBoxProdCode.Location = new System.Drawing.Point(128, 91);
			this.textBoxProdCode.Name = "textBoxProdCode";
			this.textBoxProdCode.Size = new System.Drawing.Size(280, 20);
			this.textBoxProdCode.TabIndex = 3;
			this.textBoxProdCode.Text = "";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(216, 160);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(88, 23);
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "Register";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(320, 160);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(88, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// errorProviderChecker
			// 
			this.errorProviderChecker.DataMember = null;
			// 
			// textBoxSN
			// 
			this.textBoxSN.Location = new System.Drawing.Point(128, 120);
			this.textBoxSN.Name = "textBoxSN";
			this.textBoxSN.Size = new System.Drawing.Size(280, 20);
			this.textBoxSN.TabIndex = 7;
			this.textBoxSN.Text = "";
			// 
			// FormRegister
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(480, 214);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.textBoxSN,
																		  this.btnCancel,
																		  this.btnOK,
																		  this.textBoxProdCode,
																		  this.label1,
																		  this.panelTitle,
																		  this.lblProdCode});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(488, 280);
			this.MinimizeBox = false;
			this.Name = "FormRegister";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Application Registration";
			this.panelTitle.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Events
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (!ValidateData()) return;

			if (!CheckDataCorrectness()) return;
			//StoreProdCodeSNInRegistry();
			StoreProdCodeSNInSerializableSN();

			this.Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		#endregion Events

		#region Methods

		private void StoreProdCodeSNInSerializableSN()
		{
			SerializableSN objSerializableSN = new SerializableSN();
			BlowfishSimple objBlowfishSimple = new BlowfishSimple(Configuration.EncryKey);
			objSerializableSN.Prodcode       = objBlowfishSimple.Encrypt(this.textBoxProdCode.Text);
			objSerializableSN.SN             = objBlowfishSimple.Encrypt((this.textBoxSN.Text));
			objSerializableSN.Store();
		}

		private void StoreProdCodeSNInRegistry()
		{
			Microsoft.Win32.RegistryKey	           objRedistryKey = Registry.LocalMachine;

			RegistryKey	 objRedistryKeyNujit  =  objRedistryKey.CreateSubKey(@"SOFTWARE\Nujit");
			objRedistryKeyNujit.SetValue("ProdCode",this.textBoxProdCode.Text);

		//	RegistryKey	 objRedistryKeyProdCode  =  objRedistryKey.CreateSubKey(@"SOFTWARE\Nujit");
			objRedistryKeyNujit.SetValue("SN",this.textBoxSN.Text);
			objRedistryKeyNujit.Close();
			this.Close();
		}
		
		
		#endregion Methods 

        #region Validation
		private bool ValidateProdCode()
		{
			bool blnResult = true;
			if (this.textBoxProdCode.Text == ""	)
			{
				errorProviderChecker.SetError(textBoxProdCode,"Please enter your ProdCode");
				blnResult= false;
			}
			else
			{
				errorProviderChecker.SetError(textBoxProdCode,"");
				blnResult= true;
			}
			return 	blnResult;
	
		}
 	
		private bool ValidateSN()
		{
			bool blnResult = true;
			if (this.textBoxSN.Text == ""	)
			{
				errorProviderChecker.SetError(textBoxSN,"Please enter your serial number");
				blnResult= false;
			}
			else
			{
				errorProviderChecker.SetError(textBoxSN,"");
				blnResult= true;
			}
			return 	blnResult;

		}


		private bool CheckDataCorrectness()
		{
			bool blnResult = true;

			Nujit.NujitERP.ClassLib.Encryption.BlowfishSimple objBlowfishSimple = new BlowfishSimple(Configuration.EncryKey);

			// added by Gustavo Muller
			string aux = objBlowfishSimple.Decrypt(this.textBoxSN.Text);
			if (aux != null)
				blnResult = (objBlowfishSimple.Decrypt(this.textBoxSN.Text)).ToUpper() == textBoxProdCode.Text.ToUpper();
			else	
				blnResult = false;
			// end of added by Gustavo Muller

       		if (!blnResult	)
			{
				errorProviderChecker.SetError(textBoxSN,"Incorrect Prod Code or Serial Number");
				errorProviderChecker.SetError(this.textBoxProdCode,"Incorrect Prod Code or Serial Number");
				
			}
			else
			{
				errorProviderChecker.SetError(textBoxSN,"");
				errorProviderChecker.SetError(this.textBoxProdCode,"");
				
			}

			return 	blnResult;
		
		}

		private bool ValidateData()
		{
			bool blnResult = true;

			blnResult = ValidateSN() && blnResult ;
			blnResult = ValidateProdCode() && blnResult ;
			return	blnResult;
		}
		
		#endregion Validation

		
	}
}
