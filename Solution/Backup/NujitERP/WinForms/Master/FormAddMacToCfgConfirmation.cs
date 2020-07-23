using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Nujit.NujitERP.WinForms.Master
{
	/// <summary>
	/// Summary description for FormAddMacToCfgConfirmation.
	/// </summary>
	public class FormAddMacToCfgConfirmation : System.Windows.Forms.Form
	{

		public const string YES			= "YES";
		public const string NO			= "NO";
		public const string YES_TO_ALL	= "YESALL";
		public const string NO_TO_ALL	= "NOALL";
		public const string CANCEL		= "CANCEL";
		private string _result = "";

		private System.Windows.Forms.Label mainLabel;
		private System.Windows.Forms.Button buttonNoToAll;
		private System.Windows.Forms.Button buttonNo;
		private System.Windows.Forms.Button buttonYesToAll;
		private System.Windows.Forms.Button buttonYes;
		private System.Windows.Forms.Button buttonCancel;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormAddMacToCfgConfirmation()
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainLabel = new System.Windows.Forms.Label();
			this.buttonNoToAll = new System.Windows.Forms.Button();
			this.buttonNo = new System.Windows.Forms.Button();
			this.buttonYesToAll = new System.Windows.Forms.Button();
			this.buttonYes = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// mainLabel
			// 
			this.mainLabel.Location = new System.Drawing.Point(24, 16);
			this.mainLabel.Name = "mainLabel";
			this.mainLabel.Size = new System.Drawing.Size(384, 72);
			this.mainLabel.TabIndex = 0;
			this.mainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonNoToAll
			// 
			this.buttonNoToAll.Location = new System.Drawing.Point(256, 96);
			this.buttonNoToAll.Name = "buttonNoToAll";
			this.buttonNoToAll.Size = new System.Drawing.Size(72, 24);
			this.buttonNoToAll.TabIndex = 5;
			this.buttonNoToAll.Text = "No to All";
			this.buttonNoToAll.Click += new System.EventHandler(this.buttonNoToAll_Click);
			// 
			// buttonNo
			// 
			this.buttonNo.Location = new System.Drawing.Point(176, 96);
			this.buttonNo.Name = "buttonNo";
			this.buttonNo.Size = new System.Drawing.Size(72, 24);
			this.buttonNo.TabIndex = 4;
			this.buttonNo.Text = "No";
			this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
			// 
			// buttonYesToAll
			// 
			this.buttonYesToAll.Location = new System.Drawing.Point(96, 96);
			this.buttonYesToAll.Name = "buttonYesToAll";
			this.buttonYesToAll.Size = new System.Drawing.Size(72, 24);
			this.buttonYesToAll.TabIndex = 3;
			this.buttonYesToAll.Text = "Yes to All";
			this.buttonYesToAll.Click += new System.EventHandler(this.buttonYesToAll_Click);
			// 
			// buttonYes
			// 
			this.buttonYes.Location = new System.Drawing.Point(16, 96);
			this.buttonYes.Name = "buttonYes";
			this.buttonYes.Size = new System.Drawing.Size(72, 24);
			this.buttonYes.TabIndex = 2;
			this.buttonYes.Text = "Yes";
			this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(336, 96);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(72, 24);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// FormAddMacToCfgConfirmation
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(424, 131);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonYes);
			this.Controls.Add(this.buttonYesToAll);
			this.Controls.Add(this.buttonNo);
			this.Controls.Add(this.buttonNoToAll);
			this.Controls.Add(this.mainLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormAddMacToCfgConfirmation";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormAddMacToCfgConfirmation";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormAddMacToCfgConfirmation_Closing);
			this.ResumeLayout(false);

		}
		#endregion

		public string Result
		{
			get {return _result;}
		}

		public void Show (string text, string caption)
		{
			this.mainLabel.Text = text;
			this.Text = " " + caption;
			base.ShowDialog();
		}

		private void buttonYes_Click(object sender, System.EventArgs e)
		{
			_result = YES;
			this.Close();
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			_result = CANCEL;
			this.Close();
		}

		private void buttonNoToAll_Click(object sender, System.EventArgs e)
		{
			_result = NO_TO_ALL;
			this.Close();
		}

		private void buttonNo_Click(object sender, System.EventArgs e)
		{
			_result = NO;
			this.Close();
		}

		private void buttonYesToAll_Click(object sender, System.EventArgs e)
		{
			_result = YES_TO_ALL;
			this.Close();
		}

		private void FormAddMacToCfgConfirmation_Closing(object sender, CancelEventArgs e)
		{
			if (_result.Equals(string.Empty))
				_result = CANCEL;
		}
	}
}
