using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.DataAccess
{
	public class SqlHelper
	{
		private SqlHelper(){}

		#region get function for SqlDataReader parameter type

		public static string getString(SqlDataReader reader, int col)
		{
			return reader.IsDBNull(col) ? string.Empty : reader.GetString(col).Trim();
		}

		public static short getInt16(SqlDataReader reader, int col)
		{
			return reader.IsDBNull(col) ? (short)0 : reader.GetInt16(col);
		}
	
		public static int getInt32(SqlDataReader reader, int col)
		{
			return reader.IsDBNull(col) ? 0 : reader.GetInt32(col);
		}

		public static byte getTinyInt(SqlDataReader reader, int col)
		{
			return reader.IsDBNull(col) ? (byte)0 : Convert.ToByte(reader.GetValue(col));
		}

		public static decimal getDecimal(SqlDataReader reader, int col)
		{
			return reader.IsDBNull(col) ? (decimal)0 : Convert.ToDecimal(reader.GetValue(col));
		}

		public static double getDouble(SqlDataReader reader, int col)
		{
			return reader.IsDBNull(col) ? (double)0 : Convert.ToDouble(reader.GetValue(col));
		}

		public static DateTime getDateTime(SqlDataReader reader, int col)
		{
			return reader.IsDBNull(col) ? Convert.ToDateTime("1900/01/01") : Convert.ToDateTime(reader.GetValue(col));
		}

		public static Boolean getBoolean(SqlDataReader reader, int col) 
		{
			return reader.IsDBNull(col) ? false : reader.GetBoolean(col);
		}

		public static Guid getGuid(SqlDataReader reader, int col) 
		{
			return reader.IsDBNull(col) ? Guid.Empty : reader.GetGuid(col);
		}

		#endregion

		#region get function for OleDbDataReader parameter type

		public static string getString(OleDbDataReader reader, int col)
		{
			return reader.IsDBNull(col) ? string.Empty : reader.GetString(col).Trim();
		}

		public static short getInt16(OleDbDataReader reader, int col)
		{
			return reader.IsDBNull(col) ? (short)0 : reader.GetInt16(col);
		}
	
		public static int getInt32(OleDbDataReader reader, int col)
		{
			return reader.IsDBNull(col) ? 0 : reader.GetInt32(col);
		}

		public static byte getTinyInt(OleDbDataReader reader, int col)
		{
			return reader.IsDBNull(col) ? (byte)0 : Convert.ToByte(reader.GetValue(col));
		}

		public static decimal getDecimal(OleDbDataReader reader, int col)
		{
			return reader.IsDBNull(col) ? (decimal)0 : Convert.ToDecimal(reader.GetValue(col));
		}

		public static double getDouble(OleDbDataReader reader, int col)
		{
			return reader.IsDBNull(col) ? (double)0 : Convert.ToDouble(reader.GetValue(col));
		}

		public static DateTime getDateTime(OleDbDataReader reader, int col)
		{
			return reader.IsDBNull(col) ? Convert.ToDateTime("1900/01/01") : Convert.ToDateTime(reader.GetValue(col));
		}

		public static Boolean getBoolean(OleDbDataReader reader, int col) 
		{
			return reader.IsDBNull(col) ? false : reader.GetBoolean(col);
		}

		public static Guid getGuid(OleDbDataReader reader, int col) 
		{
			return reader.IsDBNull(col) ? Guid.Empty : reader.GetGuid(col);
		}

		#endregion

		#region get function for DataRow parameter type

		public static string getString(DataRow dataRow, int col)
		{
			return dataRow.ItemArray[col].Equals(System.DBNull.Value) ? string.Empty : dataRow.ItemArray[col].ToString().Trim();
		}

		public static short getInt16(DataRow dataRow, int col)
		{
			return dataRow.ItemArray[col].Equals(System.DBNull.Value) ? (short)0 : Convert.ToInt16(dataRow.ItemArray[col]);
		}
	
		public static int getInt32(DataRow dataRow, int col)
		{
			return dataRow.ItemArray[col].Equals(System.DBNull.Value) ? 0 : Convert.ToInt32(dataRow.ItemArray[col]);
		}

		public static byte getTinyInt(DataRow dataRow, int col)
		{
			return dataRow.ItemArray[col].Equals(System.DBNull.Value) ? (byte)0 : Convert.ToByte(dataRow.ItemArray[col]);
		}

		public static decimal getDecimal(DataRow dataRow, int col)
		{
			return dataRow.ItemArray[col].Equals(System.DBNull.Value) ? (decimal)0 : Convert.ToDecimal(dataRow.ItemArray[col]);
		}

		public static double getDouble(DataRow dataRow, int col)
		{
			return dataRow.ItemArray[col].Equals(System.DBNull.Value) ? (double)0 : Convert.ToDouble(dataRow.ItemArray[col]);
		}

		public static DateTime getDateTime(DataRow dataRow, int col)
		{
			return dataRow.ItemArray[col].Equals(System.DBNull.Value) ? Convert.ToDateTime("1900/01/01") : Convert.ToDateTime(dataRow.ItemArray[col]);
		}

		public static Boolean getBoolean(DataRow dataRow, int col) 
		{
			return dataRow.ItemArray[col].Equals(System.DBNull.Value) ? false : Convert.ToBoolean(Convert.ToInt32(dataRow.ItemArray[col]));
		}

		#endregion

		#region other function

		public static object makeNull(string strVal)
		{
			return (strVal.Trim() == string.Empty) ? System.DBNull.Value : (object)strVal;
		}

		public static object makeNull(int intVal)
		{
			return (intVal == 0) ? System.DBNull.Value : (object)intVal;
		}

		public static object makeNull(DateTime datVal)
		{
			return (datVal.ToString("MM/dd/yyyy") == "01/01/1900") ? System.DBNull.Value : (object)datVal;
		}

		public static string replaceChars(string strGenericXML)
		{
			//Method to replace invalid XML characters with their appropriate values
			strGenericXML = strGenericXML.Replace("&", "&amp;");
			strGenericXML = strGenericXML.Replace("'","&apos;");
			strGenericXML = strGenericXML.Replace("\"","&quot;");
			strGenericXML = strGenericXML.Replace("<","&lt;");
			strGenericXML = strGenericXML.Replace(">","&gt;");

			return strGenericXML;

		}

		public static string getSQLDateString(DateTime date)
		{
			return (date.ToString("MM/dd/yyyy") == "01/01/1900") ? string.Empty : date.ToString("MM/dd/yyyy");
		}

		#endregion

		
	}
}
