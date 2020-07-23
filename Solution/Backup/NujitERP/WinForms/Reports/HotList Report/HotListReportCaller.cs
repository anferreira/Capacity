using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.WinForms.Util;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using System.Data;
using System.Data.SqlClient;
using Nujit.NujitERP.ClassLib.Reports.HotList;


namespace Nujit.NujitERP.WinForms.Reports.HotList_Report{


	/// <summary>
	/// Sample form to show how to call the HotListReport
	/// </summary>
	public class HotListReportCaller : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblPartNumber;
		private System.Windows.Forms.TextBox txtPartNumber;
		private System.Windows.Forms.Button btnReport;
		private string typeOfReport;
		private bool isHoursReport = false;
		private bool labourReport = false;
		private bool noZeros = false;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public HotListReportCaller(string typeOfReport, bool isHoursReport, bool noZeros)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.typeOfReport=typeOfReport;
			this.isHoursReport = isHoursReport;
			this.noZeros = noZeros;
		}

		public HotListReportCaller(string part, string typeOfReport, bool isHoursReport, bool noZeros)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			txtPartNumber.Text = part;
			this.typeOfReport = typeOfReport;
			this.isHoursReport = isHoursReport;
			this.noZeros = noZeros;
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
			this.lblPartNumber = new System.Windows.Forms.Label();
			this.txtPartNumber = new System.Windows.Forms.TextBox();
			this.btnReport = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblPartNumber
			// 
			this.lblPartNumber.Location = new System.Drawing.Point(20, 36);
			this.lblPartNumber.Name = "lblPartNumber";
			this.lblPartNumber.Size = new System.Drawing.Size(80, 16);
			this.lblPartNumber.TabIndex = 0;
			this.lblPartNumber.Text = "Part Number";
			// 
			// txtPartNumber
			// 
			this.txtPartNumber.Location = new System.Drawing.Point(100, 35);
			this.txtPartNumber.Name = "txtPartNumber";
			this.txtPartNumber.Size = new System.Drawing.Size(120, 20);
			this.txtPartNumber.TabIndex = 1;
			this.txtPartNumber.Text = "";
			// 
			// btnReport
			// 
			this.btnReport.Location = new System.Drawing.Point(250, 34);
			this.btnReport.Name = "btnReport";
			this.btnReport.TabIndex = 2;
			this.btnReport.Text = "Report";
			this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
			// 
			// HotListReportCaller
			// 
			this.AcceptButton = this.btnReport;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 96);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnReport,
																		  this.txtPartNumber,
																		  this.lblPartNumber});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HotListReportCaller";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Please enter data for the HotList Report";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
//		[STAThread]
//		static void Main() 
//		{
//			Application.Run(new HotListReportCaller());
//		}
//

public 
string[][] columnsNames() {
	string[][] vec = new String[73][];
	int i =0;
	while (i < vec.Length){
		string[] v = new String[2];
		switch (i.ToString()){
			
            case "0":
                v[0] = "HOT_ProdID";
                v[1] = "0";
                break;
            case "1":
                v[0] = "HOT_ActID";
                v[1] = "0";
                break;
            case "2":
                v[0] = "HOT_Seq";
                v[1] = "0";
                break;
            case "3":
                v[0] = "HOT_Uom";
                v[1] = "0";
                break;
            case "4":
                v[0] = "HOT_Dept";			
                v[1] = "0";
                break;
            case "5":
                v[0] = "HOT_Mach";
                v[1] = "0";
                break;
            case "6":
                v[0] = "HOT_MachCyc";
                v[1] = "0";
                break;
            case "7":
                v[0] = "HOT_Qoh";
                v[1] = "0";
                break;
            case "8":
                v[0] = "HOT_QohCml";
                v[1] = "0";
                break;
            case "9":
                v[0] = "HOT_PastDue";
                v[1] = "0";
                break;
            case "10":
                v[0] = "HOT_Day001";
                v[1] = "0";
                break;
            case "11":
                v[0] = "HOT_Day002";
                v[1] = "0";
                break;
            case "12":
                v[0] = "HOT_Day003";
                v[1] = "0";
                break;
            case "13":
                v[0] = "HOT_Day004";
                v[1] = "0";
                break;
            case "14":
                v[0] = "HOT_Day005";
                v[1] = "0";
                break;
            case "15":
                v[0] = "HOT_Day006";
                v[1] = "0";
                break;
            case "16":
                v[0] = "HOT_Day007";
                v[1] = "0";
                break;
            case "17":
                v[0] = "HOT_Day008";
                v[1] = "0";
                break;
            case "18":
                v[0] = "HOT_Day009";
                v[1] = "0";
                break;
            case "19":
                v[0] = "HOT_Day010";
                v[1] = "0";
                break;
            case "20":
                v[0] = "HOT_Day011";
                v[1] = "0";
                break;
            case "21":
                v[0] = "HOT_Day012";
                v[1] = "0";
                break;
            case "22":
                v[0] = "HOT_Day013";
                v[1] = "0";
                break;
            case "23":
                v[0] = "HOT_Day014";
                v[1] = "0";
                break;
            case "24":
                v[0] = "HOT_Day015";
                v[1] = "0";
                break;
            case "25":
                v[0] = "HOT_Day016";
                v[1] = "0";
                break;
            case "26":
                v[0] = "HOT_Day017";
                v[1] = "0";
                break;
            case "27":
                v[0] = "HOT_Day018";
                v[1] = "0";
                break;
            case "28":
                v[0] = "HOT_Day019";
                v[1] = "0";
                break;
            case "29":
                v[0] = "HOT_Day020";
                v[1] = "0";
                break;
            case "30":
                v[0] = "HOT_Day021";
                v[1] = "0";
                break;
            case "31":
                v[0] = "HOT_Day022";
                v[1] = "0";
                break;
            case "32":
                v[0] = "HOT_Day023";
                v[1] = "0";
                break;
            case "33":
                v[0] = "HOT_Day024";
                v[1] = "0";
                break;
            case "34":
                v[0] = "HOT_Day025";
                v[1] = "0";
                break;
            case "35":
                v[0] = "HOT_Day026";
                v[1] = "0";
                break;
            case "36":
                v[0] = "HOT_Day027";
                v[1] = "0";
                break;
            case "37":
                v[0] = "HOT_Day028";
                v[1] = "0";
                break;
            case "38":
                v[0] = "HOT_Day029";
                v[1] = "0";
                break;
            case "39":
                v[0] = "HOT_Day030";
                v[1] = "0";
                break;
            case "40":
                v[0] = "HOT_Day031";
                v[1] = "0";
                break;
            case "41":
                v[0] = "HOT_Day032";
                v[1] = "0";
                break;
            case "42":
                v[0] = "HOT_Day033";
                v[1] = "0";
                break;
            case "43":
                v[0] = "HOT_Day034";
                v[1] = "0";
                break;
            case "44":
                v[0] = "HOT_Day035";
                v[1] = "0";
                break;
            case "45":
                v[0] = "HOT_Day036";
                v[1] = "0";
                break;
            case "46":
                v[0] = "HOT_Day037";
                v[1] = "0";
                break;
            case "47":
                v[0] = "HOT_Day038";
                v[1] = "0";
                break;
            case "48":
                v[0] = "HOT_Day039";
                v[1] = "0";
                break;
            case "49":
                v[0] = "HOT_Day040";
                v[1] = "0";
                break;
            case "50":
                v[0] = "HOT_Day041";
                v[1] = "0";
                break;
            case "51":
                v[0] = "HOT_Day042";
                v[1] = "0";
                break;
            case "52":
                v[0] = "HOT_Day043";
                v[1] = "0";
                break;
            case "53":
                v[0] = "HOT_Day044";
                v[1] = "0";
                break;
            case "54":
                v[0] = "HOT_Day045";
                v[1] = "0";
                break;
            case "55":
                v[0] = "HOT_Day046";
                v[1] = "0";
                break;
            case "56":
                v[0] = "HOT_Day047";
                v[1] = "0";
                break;
            case "57":
                v[0] = "HOT_Day048";
                v[1] = "0";
                break;
            case "58":
                v[0] = "HOT_Day049";
                v[1] = "0";
                break;
            case "59":
                v[0] = "HOT_Day050";
                v[1] = "0";
                break;
            case "60":
                v[0] = "HOT_Day051";
                v[1] = "0";
                break;
            case "61":
                v[0] = "HOT_Day052";
                v[1] = "0";
                break;
            case "62":
                v[0] = "HOT_Day053";
                v[1] = "0";
                break;
            case "63":
                v[0] = "HOT_Day054";
                v[1] = "0";
                break;
            case "64":
                v[0] = "HOT_Day055";
                v[1] = "0";
                break;
            case "65":
                v[0] = "HOT_Day056";
                v[1] = "0";
                break;
            case "66":
                v[0] = "HOT_Day057";
                v[1] = "0";
                break;
            case "67":
                v[0] = "HOT_Day058";
                v[1] = "0";
                break;
            case "68":
                v[0] = "HOT_Day059";
                v[1] = "0";
                break;
            case "69":
                v[0] = "HOT_Day060";
                v[1] = "0";
                break;
            case "70":
                v[0] = "HOT_MajorGroup";
                v[1] = "0";
                break;
            case "71":
                v[0] = "HOT_MinorGroup";
                v[1] = "0";
                break;
            case "72":
                v[0] = "HOT_Finalized";	
                v[1] = "0";
                break;
		}
	    vec[i]=v;
		i++;	
	}
	return vec;
}

public 
DataSet generateRportDataSet(string byPart){
	DataTable hotListReportDataTable = new DataTable();
	DataRow dataRow;
	string[][] gridColumns = columnsNames();
	Grid.addColumns(gridColumns,"hotListReport",hotListReportDataTable);
   	
	CoreFactory coreFactory = UtilCoreFactory.createCoreFactory();	
	string[][] vec = coreFactory.getHotListReportByPart(0,byPart);//CM 11/10/2005
	for(int x = 0; x < vec.Length; x++){
		dataRow = hotListReportDataTable.NewRow();
		dataRow.ItemArray = vec[x];
		hotListReportDataTable.Rows.Add(dataRow);
	}
	coreFactory = null;

	DataSet hotListReportDataSet = new DataSet();
	hotListReportDataSet.Tables.Add(hotListReportDataTable);
	
	return hotListReportDataSet;
}


private 
void btnReport_Click(object sender, System.EventArgs e){
	this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
	DataSet dataSet = generateRportDataSet(txtPartNumber.Text.Trim());
	if (dataSet.Tables["hotListReport"].Rows.Count == 0){
			this.Cursor = System.Windows.Forms.Cursors.Default;
			MessageBox.Show("There is no information to display");
	}else{	     
		// Create the HotList report
		HotListReport hlr = new HotListReport(dataSet, "All Products Hotlist", 
			isHoursReport, labourReport, true, "", "", false, false);
    
		hlr.Show();
		this.Cursor = System.Windows.Forms.Cursors.Default;
		this.Dispose();
	}
	
}//end btnReport_Click



}
}