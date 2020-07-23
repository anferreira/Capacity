using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Util;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.WinForms.Util{

public class Grid	
{

	public const string ALIGN_RIGHT		= "R";
	public const string ALIGN_LEFT		= "L";
	public const string ALIGN_CENTER	= "C";

public static string[] getSelected(int current,DataGrid dGrid,DataTable dataTable){

	if (current > -1) {
		int cols = dataTable.Columns.Count;
		string[] aux = new String[cols];
		for(int i = 0; i < cols; i++){
			if (!dGrid[current, i].Equals(System.DBNull.Value))
				aux[i] = (string)dGrid[current, i];
			else
				aux[i] = "";
		}
		return aux;
	}
	return null;
}


public static string[] getSelected2(int current,int idecimalDigits,DataGrid dGrid,DataTable dataTable){
    int cols = dataTable.Columns.Count;
    int rows = dataTable.Rows.Count;

    if (current >= 0 && current < rows){		
		string[] aux = new String[cols];
		for(int i = 0; i < cols; i++){
            string dataType = dGrid[current, i].GetType().ToString();
            switch (dataType){
                case "System.String":
                    aux[i] = (string)dGrid[current, i];
                    break;
                case "System.Int32":
                    int intValue = (int)dGrid[current, i];
                    aux[i] = intValue.ToString();
                    break;
                case "System.Decimal":
                    decimal dvalue = (decimal)dGrid[current, i];
                    string  saux ="0";
                    if (idecimalDigits > 0){
                        saux+= ".";
                        for (int j=0;j < idecimalDigits;j++)
                            saux += "0";
                        aux[i] = dvalue.ToString(saux);
                    }else
                        aux[i] = Convert.ToInt64(dvalue).ToString();                    
                    break;
                case "System.DateTime":
                    DateTime dTvalue = (DateTime)dGrid[current, i];
                    aux[i] = DateUtil.getCompleteDateRepresentation(dTvalue,DateUtil.MMDDYYYY);
                    break;
                default:
                    aux[i] = "";
                    break;
            }							
		}
		return aux;
	}
	return null;
}

public static void setGridValue(string theValue,int rowNumber, int column,DataTable dataTable){
	int index = 0;
	IEnumerator en = dataTable.Rows.GetEnumerator();
	while(en.MoveNext()){
		DataRow dataRow = (DataRow)en.Current;
		if (index == rowNumber){
			string dataType = dataRow[column].GetType().ToString();
			switch(dataType){
			case "System.String":
				dataRow[column] = theValue;
				break;
			case "System.Int32":
				int intValue = int.Parse(theValue);
				dataRow[column] = intValue;
				break;
			case "System.Decimal":
				dataRow[column] = decimal.Parse(theValue);
				break;
			case "System.DateTime":
				dataRow[column] = DateUtil.parseDate(theValue, DateUtil.DDMMYYYY);
				break;
			}
		}
		index++;
	}
}

public static void addColumns(string[][] gridColumns,string tableName,DataTable listDataTable,DataGrid dataGrid){
	listDataTable.TableName = tableName;
	for (int i=0;i < gridColumns.Length;i++){
		listDataTable.Columns.Add(new DataColumn(gridColumns[i][0], typeof(string)));
	}

	DataView dataView = new DataView(listDataTable);
	dataView.AllowEdit = false;
	dataView.AllowDelete = false;

	dataGrid.DataSource = dataView;

	DataGridTableStyle dgdtblStyle = new DataGridTableStyle();
	dgdtblStyle.MappingName	= listDataTable.TableName;//its table name of dataset

	dataGrid.TableStyles.Clear(); 
	dataGrid.TableStyles.Add(dgdtblStyle);
	dataGrid.RowHeadersVisible = true;
	dataGrid.PreferredRowHeight = 18;
	GridColumnStylesCollection colStyle;
	colStyle = dataGrid.TableStyles[0].GridColumnStyles;		
	
	for (int i=0;i < gridColumns.Length;i++){
		colStyle[i].Width = int.Parse(gridColumns[i][1]);
		if (gridColumns[i].Length > 2)
			setAlignment (colStyle[i],gridColumns[i][2]);
	}
}

public static 
void makeGrid(string[][] gridColumns,string tableName,DataTable listDataTable,DataGrid dataGrid, string[][] data){
	listDataTable.TableName = tableName;
	for (int i=0;i < gridColumns.Length;i++){
		listDataTable.Columns.Add(new DataColumn(gridColumns[i][0], typeof(string)));
	}

	for(int x = 0; x < data.Length; x++){
		DataRow dataRow = listDataTable.NewRow();
	    for(int z = 0; z < data[x].Length; z++)
		    dataRow[z] = data[x][z];
		listDataTable.Rows.Add(dataRow);
	}

	DataView dataView = new DataView(listDataTable);
	dataView.AllowEdit = false;
	dataView.AllowDelete = false;

	dataGrid.DataSource = dataView;

	DataGridTableStyle dgdtblStyle = new DataGridTableStyle();
	dgdtblStyle.MappingName	= listDataTable.TableName;//its table name of dataset

	dataGrid.TableStyles.Clear(); 
	dataGrid.TableStyles.Add(dgdtblStyle);
	dataGrid.RowHeadersVisible = true;
	dataGrid.PreferredRowHeight = 18;
	GridColumnStylesCollection colStyle;
	colStyle = dataGrid.TableStyles[0].GridColumnStyles;		
	
	for (int i=0;i < gridColumns.Length;i++){
		colStyle[i].Width = int.Parse(gridColumns[i][1]);		
	}
}


private static void setAlignment (DataGridColumnStyle column, string alignment)
{
	switch (alignment)
	{
		case (ALIGN_LEFT):
			column.Alignment = HorizontalAlignment.Left;
			break;
		case (ALIGN_CENTER):
			column.Alignment = HorizontalAlignment.Center;
			break;
		case (ALIGN_RIGHT):
			column.Alignment = HorizontalAlignment.Right;
			column.HeaderText += " .";
			break;
	}
}

//Use this for reports
public static void addColumns(string[][] gridColumns,string tableName,DataTable listDataTable){
	listDataTable.TableName = tableName;
	for (int i=0;i < gridColumns.Length;i++){
		listDataTable.Columns.Add(new DataColumn(gridColumns[i][0], typeof(string)));
	}

	DataView dataView = new DataView(listDataTable);
}

}//end class
}//end namespace
