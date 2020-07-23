using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.WinForms.Reports.ShortageReport;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.WinForms.Reports.ShortageReport
{
	/// <summary>
	/// Summary description for GenReportForm.
	/// </summary>
	public class GenReportForm : System.Windows.Forms.Form
	{
       	private CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dTPDataFrom;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private string[][] vecMajorGrp;
        private string[][] filterMajorGrp;
        private string[][] vecMinorGrp;
        private string[][] filterMinorGrp;
 
        private System.Windows.Forms.Button btnMajorGrp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMinorGrp;
        private System.Windows.Forms.GroupBox gBoxDates;
        private bool selected = false; 
        
		public GenReportForm()		{
			
			InitializeComponent();

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
            this.btnReport = new System.Windows.Forms.Button();
            this.dTPDataFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMajorGrp = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMinorGrp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gBoxDates = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.gBoxDates.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(248, 88);
            this.btnReport.Name = "btnReport";
            this.btnReport.TabIndex = 0;
            this.btnReport.Text = "Report";
            this.btnReport.Click += new System.EventHandler(this.button1_Click);
            // 
            // dTPDataFrom
            // 
            this.dTPDataFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPDataFrom.Location = new System.Drawing.Point(96, 24);
            this.dTPDataFrom.Name = "dTPDataFrom";
            this.dTPDataFrom.Size = new System.Drawing.Size(88, 20);
            this.dTPDataFrom.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date From";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(328, 88);
            this.btnClose.Name = "btnClose";
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMajorGrp
            // 
            this.btnMajorGrp.Location = new System.Drawing.Point(128, 16);
            this.btnMajorGrp.Name = "btnMajorGrp";
            this.btnMajorGrp.Size = new System.Drawing.Size(32, 16);
            this.btnMajorGrp.TabIndex = 14;
            this.btnMajorGrp.Text = "...";
            this.btnMajorGrp.Click += new System.EventHandler(this.btnMajorGrp_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 16);
            this.label5.Name = "label5";
            this.label5.TabIndex = 15;
            this.label5.Text = "Filter Major Group ";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 40);
            this.label6.Name = "label6";
            this.label6.TabIndex = 17;
            this.label6.Text = "Filter Minor Group ";
            // 
            // btnMinorGrp
            // 
            this.btnMinorGrp.Location = new System.Drawing.Point(128, 40);
            this.btnMinorGrp.Name = "btnMinorGrp";
            this.btnMinorGrp.Size = new System.Drawing.Size(32, 16);
            this.btnMinorGrp.TabIndex = 16;
            this.btnMinorGrp.Text = "...";
            this.btnMinorGrp.Click += new System.EventHandler(this.btnMinorGrp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMinorGrp);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnMajorGrp);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 72);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // gBoxDates
            // 
            this.gBoxDates.Controls.Add(this.dTPDataFrom);
            this.gBoxDates.Controls.Add(this.label2);
            this.gBoxDates.Location = new System.Drawing.Point(216, 8);
            this.gBoxDates.Name = "gBoxDates";
            this.gBoxDates.Size = new System.Drawing.Size(200, 72);
            this.gBoxDates.TabIndex = 1;
            this.gBoxDates.TabStop = false;
            // 
            // GenReportForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(432, 126);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gBoxDates);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReport);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(440, 160);
            this.MinimumSize = new System.Drawing.Size(440, 160);
            this.Name = "GenReportForm";
            this.Text = "Shortage Report";
            this.Load += new System.EventHandler(this.GenReportForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.gBoxDates.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

private void button1_Click(object sender, System.EventArgs e){

    string[] vecMajorSel = getMajorGrpFilter();
    string[] vecMinorSel = getMinorGrpFilter();
    DateTime dateFrom = this.dTPDataFrom.Value;
 //   DateTime dateTo = this.dTPDateTo.Value;
    
    DataSet dataSet =generateReportDataSet(vecMajorSel,vecMinorSel,dateFrom);
    
    ShortageReport shortageReport= new ShortageReport(dataSet,dateFrom);
    shortageReport.ShowDialog();    

}

private string[] getMajorGrpFilter(){

    //Selected by filter form
   
    int countMajorGrp = 0;
	for(int i = 0; i < this.vecMajorGrp.Length; i++)
	if (vecMajorGrp[i][1].Equals("true"))
		countMajorGrp++;
		
	int indexMajorGrp = 0;
	string[] majorFilterAux = new String[countMajorGrp];

	for(int i = 0; i <vecMajorGrp.Length; i++){
	if (vecMajorGrp[i][1].Equals("true")){
		majorFilterAux[indexMajorGrp] = vecMajorGrp[i][0];
		indexMajorGrp++;
		}
	}
	return majorFilterAux; 
}

private string[] getMinorGrpFilter(){
    //Selected by filter form
   
    int countMinorGrp = 0;
	for(int i = 0; i < this.vecMinorGrp.Length; i++)
	if (vecMinorGrp[i][1].Equals("true"))
		countMinorGrp++;
		
	int indexMinorGrp = 0;
	string[] minorFilterAux = new String[countMinorGrp];

	for(int i = 0; i <vecMinorGrp.Length; i++){
	if (vecMinorGrp[i][1].Equals("true")){
		minorFilterAux[indexMinorGrp] = vecMinorGrp[i][0];
		indexMinorGrp++;
		}
	}
	return minorFilterAux;
  
}

private DataSet generateReportDataSet(string[] vecMajorFilter,string[] vecMinorFilter,DateTime dateFrom){

	DataTable dataTable = new DataTable();
	DataRow dataRow;
	
	dataTable.TableName = "shortageReport";	

	dataTable.Columns.Add(new DataColumn("majorGrp",typeof(string)));
	dataTable.Columns.Add(new DataColumn("part",typeof(string)));
	dataTable.Columns.Add(new DataColumn("qoh",typeof(string)));
	dataTable.Columns.Add(new DataColumn("minQty",typeof(string)));
//	dataTable.Columns.Add(new DataColumn("below",typeof(string)));
	dataTable.Columns.Add(new DataColumn("week1",typeof(string)));
	dataTable.Columns.Add(new DataColumn("week2",typeof(string)));
	dataTable.Columns.Add(new DataColumn("week3",typeof(string)));
	dataTable.Columns.Add(new DataColumn("week4",typeof(string)));
//	dataTable.Columns.Add(new DataColumn("week5",typeof(string)));
//	dataTable.Columns.Add(new DataColumn("month2",typeof(string)));
//	dataTable.Columns.Add(new DataColumn("month3",typeof(string)));
//	dataTable.Columns.Add(new DataColumn("month4",typeof(string)));
//	
    try{
	    CoreFactory coreFactory =UtilCoreFactory.createCoreFactory();
	    string[][] vec = coreFactory.getShortageReportAsString(vecMajorFilter,vecMinorFilter,dateFrom);
    	
	    for(int x = 0; x < vec.Length; x++){
		    dataRow = dataTable.NewRow();
		    dataRow.ItemArray= vec[x];
		    dataTable.Rows.Add(dataRow);	
	    }
	    DataSet dataSet = new DataSet();
	    dataSet.Tables.Add(dataTable);
    	
	    return dataSet;
	}catch(NujitException ne){
		FormException formException = new FormException(ne);
	    formException.ShowDialog();
	    return null;
	}
}

private void GenReportForm_Load(object sender, System.EventArgs e){
    getMajorMinorGrp();
   
}

private void  getMajorMinorGrp(){
    try{
    
     string[] vecAuxMajor = coreFactory.getMajorGroupASString("");
     string[] vecAuxMinor = coreFactory.getMinorGroupASString(); //Minor
     if ((vecAuxMajor.Length==0)||(vecAuxMinor.Length == 0)){
            MessageBox.Show("There isn't Major or Minor Groups in ProdFmInfo table.");
            this.btnReport.Enabled = false;
    }else {
	        this.vecMajorGrp = new string[vecAuxMajor.Length][] ;
	        for(int i = 0; i < vecAuxMajor.Length; i++){
		        string[] v = new string[2];
		        v[0] = vecAuxMajor[i];
		        v[1] = "true";		
		        vecMajorGrp[i] = v;
            }
            
            this.vecMinorGrp= new string[vecAuxMinor.Length][] ;
	        for(int i = 0; i < vecAuxMinor.Length; i++){
		        string[] v = new string[2];
		        v[0] = vecAuxMinor[i];
		        v[1] = "true";		
		        vecMinorGrp[i] = v;
            }
            
        }     
    }catch (NujitException ne){
		FormException formException = new FormException(ne);
	    formException.ShowDialog();
	   
	}	
 

}


private void btnClose_Click(object sender, System.EventArgs e){

    this.Close();
}



private void cBoxMajorGrpFrom_SelectedIndexChanged(object sender, System.EventArgs e){
    selected = true;
}

private void btnMajorGrp_Click(object sender, System.EventArgs e){
    FilterForm filterForm= new FilterForm(vecMajorGrp);
    filterForm.ShowDialog();
    if (filterForm.DialogResult.Equals(DialogResult.OK)){
        filterMajorGrp = filterForm.getItems();
    }


}

private void btnMinorGrp_Click(object sender, System.EventArgs e){
   FilterForm filterForm= new FilterForm(vecMinorGrp);
    filterForm.ShowDialog();
    if (filterForm.DialogResult.Equals(DialogResult.OK)){
        filterMajorGrp = filterForm.getItems();
    }
}


}
}
