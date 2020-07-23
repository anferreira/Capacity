using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


using Nujit.NujitERP.ClassLib.Register;

namespace Nujit.NujitERP.WinForms.Register
{
	/// <summary>
	/// Summary description for FormRegisterReminder.
	/// </summary>
	public class FormRegisterReminder : System.Windows.Forms.Form
	{
		#region Controls
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnRegister;
		private System.Windows.Forms.Label lblEvalTimesInfo;
		private System.Windows.Forms.Label lblExpireInfo;
		private System.Windows.Forms.Button btnEvaluate;
		private System.Windows.Forms.Button btnQuit;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion Controls

		#region Constructors

		public FormRegisterReminder()
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

      
		#endregion Constructors

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnRegister = new System.Windows.Forms.Button();
			this.lblEvalTimesInfo = new System.Windows.Forms.Label();
			this.lblExpireInfo = new System.Windows.Forms.Label();
			this.btnEvaluate = new System.Windows.Forms.Button();
			this.btnQuit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(48, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(224, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Thank you for trying NujitERP. ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(48, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(224, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "Unregistered Copy of Evaluation";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnRegister
			// 
			this.btnRegister.Location = new System.Drawing.Point(96, 184);
			this.btnRegister.Name = "btnRegister";
			this.btnRegister.Size = new System.Drawing.Size(128, 23);
			this.btnRegister.TabIndex = 2;
			this.btnRegister.Text = "Enter serial number";
			this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
			// 
			// lblEvalTimesInfo
			// 
			this.lblEvalTimesInfo.Location = new System.Drawing.Point(48, 106);
			this.lblEvalTimesInfo.Name = "lblEvalTimesInfo";
			this.lblEvalTimesInfo.Size = new System.Drawing.Size(224, 24);
			this.lblEvalTimesInfo.TabIndex = 3;
			this.lblEvalTimesInfo.Text = "label3";
			this.lblEvalTimesInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblEvalTimesInfo.Click += new System.EventHandler(this.lblEvalTimesInfo_Click);
			// 
			// lblExpireInfo
			// 
			this.lblExpireInfo.Location = new System.Drawing.Point(48, 143);
			this.lblExpireInfo.Name = "lblExpireInfo";
			this.lblExpireInfo.Size = new System.Drawing.Size(224, 24);
			this.lblExpireInfo.TabIndex = 4;
			this.lblExpireInfo.Text = "This ";
			this.lblExpireInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblExpireInfo.Visible = false;
			this.lblExpireInfo.Click += new System.EventHandler(this.lblExpireInfo_Click);
			// 
			// btnEvaluate
			// 
			this.btnEvaluate.Location = new System.Drawing.Point(96, 212);
			this.btnEvaluate.Name = "btnEvaluate";
			this.btnEvaluate.Size = new System.Drawing.Size(128, 23);
			this.btnEvaluate.TabIndex = 5;
			this.btnEvaluate.Text = "Evaluate";
			this.btnEvaluate.Click += new System.EventHandler(this.btnEvaluate_Click);
			// 
			// btnQuit
			// 
			this.btnQuit.Location = new System.Drawing.Point(96, 240);
			this.btnQuit.Name = "btnQuit";
			this.btnQuit.Size = new System.Drawing.Size(128, 23);
			this.btnQuit.TabIndex = 6;
			this.btnQuit.Text = "Quit";
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			// 
			// FormRegisterReminder
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 318);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnQuit,
																		  this.btnEvaluate,
																		  this.lblExpireInfo,
																		  this.lblEvalTimesInfo,
																		  this.btnRegister,
																		  this.label2,
																		  this.label1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormRegisterReminder";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Evaluation ";
			this.Load += new System.EventHandler(this.FormRegisterReminder_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region Vars
		Nujit.NujitERP.ClassLib.Register.SerializableSN objSerializableSN; 
		#endregion Vars

		#region Events
		private void lblExpireInfo_Click(object sender, System.EventArgs e)
		{
		
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lblEvalTimesInfo_Click(object sender, System.EventArgs e)
		{
//		   FormRegister formRegister = new FormRegister();
//		   formRegister.ShowDialog();
//		   formRegister.Dispose(); 
		}

		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void btnEvaluate_Click(object sender, System.EventArgs e)
		{
//			Nujit.NujitERP.ClassLib.Register.SerializableSN	objSerializableSN = SerializableSN.RetrieveSerializedSN();
//			objSerializableSN.times++;
			objSerializableSN.Store();
			this.Close();
		}

		private void btnRegister_Click(object sender, System.EventArgs e)
		{
			FormRegister formRegister = new FormRegister();
			formRegister.ShowDialog();
			formRegister.Dispose(); 
			this.Close();
		}

		private void FormRegisterReminder_Load(object sender, System.EventArgs e)
		{
			 objSerializableSN= SerializableSN.RetrieveSerializedSN();
			 objSerializableSN.Times ++;
			 objSerializableSN.Store();

			if	 ( objSerializableSN.Times <= 3)
			{
				this.lblEvalTimesInfo.Text =  "This is " + (objSerializableSN.Times ).ToString() + (((objSerializableSN.Times)==1)?" time":" times")+ " of 30-time evaluation!" ;
			   
			}
			else
			{
				 this.lblEvalTimesInfo.Text =  "Application expires. " ;
				 this.btnEvaluate.Enabled = false;
			}


		}
		#endregion Events
	}
}
