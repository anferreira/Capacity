using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Util;
using System.Data;

namespace Nujit.NujitERP.WinForms.Schedule.LoadUpLoad.GeneratedRecords
{
	/// <summary>
	/// Summary description for DiscardInsertedForm.
	/// </summary>
	public class DiscardInsertedForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblDate;
		private System.ComponentModel.Container components = null;
		private string[] records;
		private System.Windows.Forms.DataGrid dGridDepts;
		private DataTable table;

		public DiscardInsertedForm(string[] recordsDiscard)
		{
			
			InitializeComponent();
			this.lblDate.Text += DateUtil.getCompleteDateRepresentation(DateTime.Now, DateUtil.MMDDYYYY);
			loadGridInformation(recordsDiscard);
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dGridDepts = new System.Windows.Forms.DataGrid();
			this.lblDate = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dGridDepts)).BeginInit();
			this.SuspendLayout();
			// 
			// dGridDepts
			// 
			this.dGridDepts.CaptionVisible = false;
			this.dGridDepts.DataMember = "";
			this.dGridDepts.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridDepts.Location = new System.Drawing.Point(24, 80);
			this.dGridDepts.Name = "dGridDepts";
			this.dGridDepts.ReadOnly = true;
			this.dGridDepts.Size = new System.Drawing.Size(240, 216);
			this.dGridDepts.TabIndex = 0;
			// 
			// lblDate
			// 
			this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDate.Location = new System.Drawing.Point(32, 24);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(224, 24);
			this.lblDate.TabIndex = 1;
			this.lblDate.Text = "Discard Rcords of: ";
			// 
			// DiscardInsertedForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(288, 326);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblDate,
																		  this.dGridDepts});
			this.Name = "DiscardInsertedForm";
			this.Text = "Detail of Discard Records";
			((System.ComponentModel.ISupportInitialize)(this.dGridDepts)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


private void loadGridInformation(string[] records){
	
	this.records=records;
	
	//add columnas to datatable
	table = new DataTable();
	table.Columns.Add(new DataColumn("Dept",typeof(string)));
	
	dGridDepts.PreferredColumnWidth = 200;
	//Fill the grid with the discard records
	DataRow dataRow;
	string dept;
	
	for(int i = 2; i < records.Length;i++){
		if (records[i] == null)
			break;
		dataRow = table.NewRow();
		dept = records[i];
		dataRow[0]=dept;
		table.Rows.Add(dataRow);
	}
	
	DataView dataView = new DataView(table);
	dataView.AllowEdit = false;
	dataView.AllowDelete = false;
	dataView.AllowNew = false;
	
	dGridDepts.DataSource = dataView;

	this.dGridDepts.Refresh();

}//end loadGridInformation


}//end class
}//en namespace
