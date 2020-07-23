using System;
using System.IO;
using System.Collections;
using System.Data; 
using System.Drawing; 
using System.Windows.Forms;  
using Nujit.NujitERP.ClassLib;

namespace Nujit.NujitERP.ClassLib.CustomDataGrid 
{
	/// <summary>
	/// Summary description for DataGridUtils.
	/// </summary>
	public class DataGridUtils
	{
		#region Methods

		public static void FormatDG(DataGrid dg)
		{
			// Assume DataGrid DataSource is a DataSet that contains at least one table.
			if (dg.DataSource.GetType() == typeof(DataSet))
			{
				DataSet ds = (DataSet)dg.DataSource;
				if (ds != null)
				{
					if(dg.TableStyles.Count > 0)
						dg.TableStyles.Clear();

					float prevSumWidths = 0.0f;
					int   maxHeight     = 0;
					int   calcH          = 0;

					foreach (DataTable dt in ds.Tables)
					{
						// DataTable dt = ds.Tables[tableName];
						DataGridTableStyle DGStyle = new DataGridTableStyle();
						DGStyle.MappingName = dt.TableName;
						DGStyle.AllowSorting = false;
						DGStyle.AlternatingBackColor = Color.Gainsboro;
						DataGridTextBoxColumn textColumn;
						int nbrColumns = dt.Columns.Count;
						DataRow dr;
						ArrayList cWidths = new ArrayList();
						Graphics g = dg.CreateGraphics();
						Font f = dg.Font;
						SizeF sf;
						// get widths for each column header
						foreach (DataColumn c in dt.Columns)
						{
							// "W"is used as padding
							sf = g.MeasureString("W"+ c.Caption, f);
							cWidths.Add(sf.Width);
						}
						// loop through each row comparing against initial column
						// width and then against each new maximum width based upon
						// data contained in each row for that column.
						string strTemp;
						for(int i=0; i < dt.Rows.Count; i++)
						{
							dr = dt.Rows[i];
							for (int j=0; j < nbrColumns; j++)
							{
								if(!Convert.IsDBNull( dr[j]))
								{
									strTemp = dr[j].ToString();
									// careful strings can get
									// very long, limit it to 100 characters
									if(dr[j].GetType() == typeof(System.String) && strTemp.Length > 100)
										sf = g.MeasureString("W" + strTemp.Substring(0,100), f);
									else
										sf = g.MeasureString("W"+ strTemp, f);

									if(sf.Width > (float)cWidths[j])
										cWidths[j] = sf.Width;
								}
							}
						}

						// set each column with its determined width
						// set alignment for each column
						// set format for decimal numbers
						float sumWidths = 0.0f;
						foreach (DataColumn c in dt.Columns)
						{
							if(c.DataType == typeof(bool))
							{
								DataGridBoolColumn boolColumn = new DataGridBoolColumn();
								boolColumn.MappingName = c.ColumnName;
								boolColumn.HeaderText = ""+ c.Caption;
								boolColumn.Width = 50;
								boolColumn.ReadOnly = false;
								boolColumn.Alignment = HorizontalAlignment.Center ;
								DGStyle.GridColumnStyles.Add(boolColumn);
								sumWidths += boolColumn.Width;
							}
							else
							{
								textColumn= new DataGridTextBoxColumn();
								textColumn.MappingName = c.ColumnName;
								textColumn.HeaderText = ""+ c.Caption;
								textColumn.ReadOnly = false;
								textColumn.NullText = string.Empty;

								if(c.DataType == typeof(System.Guid) || c.DataType == typeof(System.String))
								{
									textColumn.Alignment = HorizontalAlignment.Left ;
								}
								else if(c.DataType == typeof(System.DateTime))
								{
									textColumn.Alignment =HorizontalAlignment.Center ;
								}
								else if(c.DataType == typeof(int))
								{
									textColumn.Alignment =HorizontalAlignment.Center ;
								}
								else
								{
									textColumn.Alignment = HorizontalAlignment.Right ;

									if(    c.DataType == typeof(System.Double)
										|| c.DataType ==typeof(System.Decimal)
										|| c.DataType == typeof(float))
									{
										textColumn.Format = "0.00";
									}
								}

								textColumn.Width = (int)(float)cWidths[c.Ordinal];
								DGStyle.GridColumnStyles.Add(textColumn);
								sumWidths += textColumn.Width;
								
								if (maxHeight < textColumn.TextBox.Height)
								{
									maxHeight = textColumn.TextBox.Height;
								}
							}
						}
						dg.TableStyles.Add(DGStyle);

						// Adjust width of DataGrid to match calculated widths
						// select maximum width of all tables in the dataset
						// Adjust width to fit inside the parent container’s width
						if (prevSumWidths < sumWidths)
						{
							prevSumWidths = sumWidths;
							prevSumWidths += dg.RowHeaderWidth;
							if (dg.VisibleRowCount < dt.Rows.Count)
								prevSumWidths += 16; // add width of scrollbar
							// check to see if it is greater than the width of its parent
							// e.g. a panel or tabpage control.
							if (prevSumWidths > (float)dg.Parent.Width)
								// allow room for the scroll bar and provide a little padding.
								prevSumWidths = (float)dg.Parent.Width - 16 - 5;
						}
						
						// Adjust height of DataGrid based upon row visiblity
						if (dg.VisibleRowCount >= dt.Rows.Count)
						{
							calcH = (dg.VisibleRowCount)*maxHeight+2*dg.PreferredRowHeight+16;
						}
						else
						{
							calcH = (dt.Rows.Count)*maxHeight+2*dg.PreferredRowHeight+16;
							// make a correction since all rows will now be visible
							if (calcH < dg.Parent.Height)
								prevSumWidths -= 16;
						}
//
//						if (calcH >=dg.Parent.Height)
//						{
//							calcH = dg.Parent.Height – dg.Top - 25; // some arbitrary value
//						}
					}
					dg.Size = new Size((int)prevSumWidths,calcH);
				}
			}   
		}

		//Copy selected table in DataGrid to clipboard
		public static void CopyDGtoClipboard(DataGrid dg, string tableName)
		{
			if (dg.DataSource != null)
			{
				DataTable dt = null;
				if (dg.DataSource.GetType() == typeof(DataSet))
				{
					DataSet ds = (DataSet)dg.DataSource;
					// need to use tableName when DataSet contains more than
					// one table
					if (ds.Tables.Contains(tableName))
						dt = ds.Tables[tableName];
				}
				else if (dg.DataSource.GetType() == typeof(DataTable))
				{
					dt = (DataTable)dg.DataSource;
					if (dt.TableName != tableName)
					{
						dt.Clear();
						dt = null;
					}
				}

				if (dt != null)
					Clipboard.SetDataObject(TableToString (dt), true );
			}
		}

		private static string TableToString(DataTable dt)
		{
			string strData = dt.TableName + "\r\n";
			string sep = string.Empty;
			if (dt.Rows.Count > 0)
			{
				foreach (DataColumn c in dt.Columns)
				{
					if(c.DataType != typeof(System.Guid) && c.DataType != typeof(System.Byte[]))
					{
						strData += sep + c.ColumnName;
						sep = "\t";
					}
				}
				strData += "\r\n";
				foreach(DataRow r in dt.Rows)
				{
					sep = string.Empty;
					foreach(DataColumn c in dt.Columns)
					{
						if(c.DataType != typeof(System.Guid) &&	c.DataType != typeof(System.Byte[]))
						{
							if(!Convert.IsDBNull(r[c.ColumnName]))
								strData += sep + r[c.ColumnName].ToString();
							else
								strData += sep + "";

							sep = "\t";
						}
					}
					strData += "\r\n";
				}
			}
			else
				strData += "\r\n---> Table was empty!";
			return strData;
		}



		public static void TabTextFile(DataGrid dg)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.InitialDirectory = "c:\\";
			openFileDialog1.Filter = "Text Files (*.txt)|*.txt| All files (*.*)|*.*";
			openFileDialog1.RestoreDirectory = true ;
			openFileDialog1.Title="Export DataGrid to Text File";
			System.Windows.Forms.DialogResult res = openFileDialog1.ShowDialog();

			if(res == DialogResult.OK)
			{
				DataSet ds = new DataSet();
				DataTable dtSource = null;
				DataTable dt = new DataTable();
				//DataRow dr;
				if(dg.DataSource != null)
				{
					if (dg.DataSource.GetType() == typeof(DataSet))
					{
						DataSet dsSource = (DataSet)dg.DataSource;
						// assume DataSet contains desired table at index 0
						if (dsSource.Tables.Count > 0)
						{
							string strTables = string.Empty;
							foreach (DataTable dTable in dsSource.Tables)
							{
								strTables += TableToString (dTable);
								strTables += "\r\n\r\n";
							}
							if (strTables != string.Empty)
								SaveDataGridData (strTables,openFileDialog1.FileName);
						}
					}
					else
					{
						if (dg.DataSource.GetType() == typeof(DataTable))
							dtSource = (DataTable)dg.DataSource;
						if (dtSource != null )
							SaveDataGridData (TableToString(dtSource),
								openFileDialog1.FileName);
					}
				}
			}
		}
		public static void SaveDataGridData(string strData, string strFileName)
		{
			FileStream fs;
			TextWriter tw = null;
			try
			{
				if (File.Exists(strFileName))
				{
					fs = new FileStream(strFileName, FileMode.Open);
				}
				else
				{
					fs= new FileStream(strFileName, FileMode.Create);
				}
				tw = new StreamWriter(fs);
				tw.Write(strData);
			}
			finally
			{
				if (tw != null)
				{
					tw.Flush();
					tw.Close();
					MessageBox.Show("DataGrid Data has been saved to: "+ strFileName
						,"Save DataGrid Data As", System.Windows.Forms.MessageBoxButtons.OK
						, System.Windows.Forms.MessageBoxIcon.Information);
				}
			}
		}


		public static DataSet CloneDataTable(DataGrid dgTable)
		{
			DataSet ds = new DataSet();
			DataTable dtSource = null;
			DataTable dt = new DataTable();
			DataRow dr;
			if(dgTable.DataSource != null)
			{
				if (dgTable.DataSource.GetType() == typeof(DataSet))
				{
					DataSet dsSource = (DataSet)dgTable.DataSource;
					// assume DataSet contains desired table at index 0
					dtSource = dsSource.Tables[0];
				}
				else
					if (dgTable.DataSource.GetType() == typeof(DataTable))
					dtSource = (DataTable)dgTable.DataSource;
				if (dtSource != null)
				{
					dt = dtSource.Clone();
					// dgConversionTable.CaptionText;
					dt.TableName = dtSource.TableName;
					dt.BeginLoadData();
					foreach (DataRow drSource in dtSource.Rows)
					{
						dr = dt.NewRow();
						foreach (DataColumn dc in dtSource.Columns)
						{
							dr[dc.ColumnName] = drSource[dc.ColumnName];
						}
						dt.Rows.Add(dr);
					}
					dt.AcceptChanges();
					dt.EndLoadData();
					ds.Tables.Add(dt);
				}
			}
			return ds;
		}

		#endregion

		#region Constructors
    
		public DataGridUtils()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#endregion Constructors
	}
}
