using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Nujit.NujitERP.WinForms.Schedule.LoadUpLoad.GeneratedRecords
{
	/// <summary>
	/// Summary description for DeptsInsertedDiscardForm.
	/// </summary>
	public class DeptsInsertedDiscardForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnVDiscardRecords;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label labelInformation;
		private System.ComponentModel.Container components = null;
		private int inserted; 
		private int discard;
		private string[] allRecords;


		public DeptsInsertedDiscardForm(int inserted, int discard,string[] allRecords){
			InitializeComponent();
			loadRecords(allRecords);
			loadForm(inserted,discard);
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
			this.btnVDiscardRecords = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.labelInformation = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnVDiscardRecords
			// 
			this.btnVDiscardRecords.Enabled = false;
			this.btnVDiscardRecords.Location = new System.Drawing.Point(32, 64);
			this.btnVDiscardRecords.Name = "btnVDiscardRecords";
			this.btnVDiscardRecords.Size = new System.Drawing.Size(128, 24);
			this.btnVDiscardRecords.TabIndex = 0;
			this.btnVDiscardRecords.Text = "View discard records";
			this.btnVDiscardRecords.Click += new System.EventHandler(this.btnVDiscardRecords_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(176, 64);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(104, 24);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// labelInformation
			// 
			this.labelInformation.BackColor = System.Drawing.SystemColors.Control;
			this.labelInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelInformation.Location = new System.Drawing.Point(32, 24);
			this.labelInformation.Name = "labelInformation";
			this.labelInformation.Size = new System.Drawing.Size(240, 24);
			this.labelInformation.TabIndex = 2;
			this.labelInformation.Text = "Total Discard/Inserted records:";
			// 
			// DeptsInsertedDiscardForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(312, 118);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.labelInformation,
																		  this.btnClose,
																		  this.btnVDiscardRecords});
			this.Name = "DeptsInsertedDiscardForm";
			this.Text = "Discard Inserted Records";
			this.ResumeLayout(false);

		}
		#endregion



private void btnClose_Click(object sender, System.EventArgs e){
	this.Dispose();
}

private void loadForm(int ins,int dis){

	this.inserted=ins;
	this.discard=dis;
	this.labelInformation.Text +=" "+ this.discard +" / "+ this.inserted;
	if (this.discard > 0){
			this.btnVDiscardRecords.Enabled=true;
	}
}//end loadForm

private void loadRecords(string[] records){

	this.allRecords = new string[records.Length];
	for (int i=0;i<records.Length;i++){
		this.allRecords[i]=records[i];
	}	

}

private void btnVDiscardRecords_Click(object sender, System.EventArgs e){

	DiscardInsertedForm discardInserted = new DiscardInsertedForm(this.allRecords);
	discardInserted.ShowDialog();


}//btnVDiscardRecords_Click


	}//end class
}//end namespace
