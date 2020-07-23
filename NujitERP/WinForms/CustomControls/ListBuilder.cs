//Created by Eric Zhong 
//March 16 ,2004

using System;
using System.Windows.Forms;

using System.Data;

using Nujit.NujitERP.ClassLib.Common;
//using Nujit.NujitERP.ClassLib.Master;

namespace Nujit.NujitERP.WinForms.CustomControls
{
	/// <summary>
	/// Summary description for CustomControl.
	/// </summary>
	/// 
	public class ListBuilder
	{
		public static void FillListDayOfWeek(ComboBox lst)
		{
			DataTable dt		= new DataTable();
			dt.Columns.Add("DisplayMember");
			dt.Columns.Add("ValueMember");

			DataRow dr = null;

			dr = dt.NewRow();
			dr["DisplayMember"] = "Sunday";
			dr["ValueMember"]	= "0";
			dt.Rows.Add(dr);

			dr = dt.NewRow();
			dr["DisplayMember"] = "Monday";
			dr["ValueMember"]	= "1";
			dt.Rows.Add(dr);

			dr = dt.NewRow();
			dr["DisplayMember"] = "Tuesday";
			dr["ValueMember"]	= "2";
			dt.Rows.Add(dr);

			dr = dt.NewRow();
			dr["DisplayMember"] = "Wednesday";
			dr["ValueMember"]	= "3";
			dt.Rows.Add(dr);

			dr = dt.NewRow();
			dr["DisplayMember"] = "Thursday";
			dr["ValueMember"]	= "4";
			dt.Rows.Add(dr);

			dr = dt.NewRow();
			dr["DisplayMember"] = "Friday";
			dr["ValueMember"]	= "5";
			dt.Rows.Add(dr);
		

			dr = dt.NewRow();
			dr["DisplayMember"] = "Saturday";
			dr["ValueMember"]	= "6";
			dt.Rows.Add(dr);
			
			lst.DataSource		= dt.DefaultView; 
			lst.DisplayMember	= "DisplayMember";
			lst.ValueMember		= "ValueMember";
		}
	}

}
