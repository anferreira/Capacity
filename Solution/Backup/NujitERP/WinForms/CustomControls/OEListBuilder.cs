using System;
using Nujit.NujitERP.ClassLib;

using System.Windows.Forms;

using System.Data;
using Nujit.NujitERP.ClassLib.Common;



namespace Nujit.NujitERP.WinForms.CustomControls
{
	/// <summary>
	/// Summary description for OEListBuilder.
	/// </summary>
	public class OEListBuilder
	{

		public static void FillOEListOH_Orderstatus(ComboBox lst,string strAllNoneNormal)
		{
			
			DataTable dt = new DataTable();

			dt.Columns.Add("DisplayMember");
			dt.Columns.Add("ValueMember");

			DataRow dr = dt.NewRow();

			if(strAllNoneNormal == "ALL")
			{
				dr = dt.NewRow();
				dr["DisplayMember"] = "All";
				dr["ValueMember"]   = "";
				dt.Rows.Add(dr);  	
			}

			dr = dt.NewRow();
			dr["DisplayMember"] = "Created"; 
			dr["ValueMember"]   = "C";
			dt.Rows.Add(dr);  

			dr = dt.NewRow();
			dr["DisplayMember"] = "Completed";
			dr["ValueMember"]   = "F";
			dt.Rows.Add(dr); 
 
			dr = dt.NewRow();
			dr["DisplayMember"] = "Removed";
			dr["ValueMember"]   = "R";
			dt.Rows.Add(dr);  
	
			lst.DataSource    = dt.DefaultView; 
			lst.DisplayMember = "DisplayMember";
			lst.ValueMember   = "ValueMember";

			lst.SelectedValue = "ALL";
		}


	}
}
