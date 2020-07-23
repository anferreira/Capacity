using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
#if !POCKET_PC
using MySql.Data;
#endif
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.NujitExcel{

public 
class ExcelAdapter{

protected System.Data.OleDb.OleDbConnection conn;
protected DataBaseAccess dataBaseAccess;
protected Type excel; 
protected object[] parameter; 
protected object excelObject; 
protected object excelWorkbooks; 
protected object excelWorkbook;
protected object excelWorksheet;
protected object excelNames;
protected object excelName;

public
ExcelAdapter(DataBaseAccess dataBaseAccess){
	this.dataBaseAccess = dataBaseAccess;
}

protected
void openConnection(string filename){
	try{
		string strConnect = 
			"Provider=Microsoft.Jet.OLEDB.4.0;" + 
			"Data Source=" + filename + ";" + 
			"Extended Properties=\"Excel 8.0;HDR=yes;IMEX=2\"";

		conn = new OleDbConnection(strConnect);
		conn.Open();
	}catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<openConnection> : " + ex.Message, ex);
	}
}

protected
void closeConnection(){
	try{
		conn.Close();
	}catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<closeConnection> : " + ex.Message, ex);
	}
}

protected
ExcelUserQuery executeDBQuery(string sql, string excelTable){
	NotNullDataReader reader = null;

	try{
		reader = dataBaseAccess.executeQuery(sql);
	}catch(System.Exception ex){
		if (reader != null)
			reader.Close();
		throw new ExcelPersistenceException(ex.Message);
	}

	try{
		ExcelUserQuery excelUserQuery = new ExcelUserQuery(excelTable);
		bool readOk=false;
		if(reader.Read()){
			readOk=true;
			for(int i=0; i<reader.ColumnCount();i++)
				excelUserQuery.addColumn(reader.GetFieldName(i),reader.GetFieldDataType(i));
		}
		if(readOk){
			do{
				string[] row = new string[reader.ColumnCount()];
				for(int i=0; i<reader.ColumnCount();i++)
					row[i]=reader.GetValue(i).ToString();
				excelUserQuery.addRow(row);
			}while(reader.Read());
		}
		return excelUserQuery;
	}catch(System.Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<executeDBQuery> : " + ex.Message, ex);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

protected
void executeExcelQuery(){
	throw new NotImplementedException("This method should allow running a SQL query against an Excel Database. Check JV and WMS projects.");
}

protected
void executeExcelNonQuery(string sql){
	try{
		OleDbCommand cmdCreate = new OleDbCommand(sql, conn);
		cmdCreate.ExecuteNonQuery();
	}catch(Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<executeExcelNonQuery> : " + ex.Message, ex);
	}
}

protected
void createFile(string filename){
	try{
		parameter= new object[1]; 
		excel = Type.GetTypeFromProgID("Excel.Application"); 
		excelObject = Activator.CreateInstance(excel); 
		parameter[0] = false; 
		excelObject.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, excelObject, parameter); 
		excelObject.GetType().InvokeMember("UserControl", BindingFlags.SetProperty, null, excelObject, parameter); 

		excelWorkbooks = excelObject.GetType().InvokeMember("Workbooks", System.Reflection.BindingFlags.GetProperty,null, excelObject, null,null);
		excelWorkbook = excelWorkbooks.GetType().InvokeMember("Add",System.Reflection.BindingFlags.InvokeMethod,null, excelWorkbooks, null,null);
		parameter[0] = filename;
	
		excelWorkbook.GetType().InvokeMember("SaveAs",System.Reflection.BindingFlags.InvokeMethod,null,excelWorkbook,parameter);
	}catch(Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<createFile> : " + ex.Message, ex);
	}finally{
		if(excelWorkbook!=null)
			excelWorkbook.GetType().InvokeMember("Close",BindingFlags.InvokeMethod,null,excelWorkbook,null);
		if(excelWorkbooks!=null)
			excelWorkbooks.GetType().InvokeMember("Close",BindingFlags.InvokeMethod,null,excelWorkbooks,null);
		if(excelObject!=null)
			excelObject.GetType().InvokeMember("Quit",BindingFlags.InvokeMethod,null,excelObject,null);

		Marshal.ReleaseComObject(excelObject);
		Marshal.ReleaseComObject(excelWorkbooks);
		Marshal.ReleaseComObject(excelWorkbook);

		excelObject=null;
		excelWorkbooks=null;
		excelWorkbook=null;
		GC.Collect();
	}
}

protected
void removeExtraSheets(string filename){
	try{
		parameter= new object[1]; 
		excel = Type.GetTypeFromProgID("Excel.Application"); 
		excelObject = Activator.CreateInstance(excel); 
		parameter[0] = false; 
		excelObject.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, excelObject, parameter); 
		excelObject.GetType().InvokeMember("UserControl", BindingFlags.SetProperty, null, excelObject, parameter); 

		excelWorkbooks = excelObject.GetType().InvokeMember("Workbooks", System.Reflection.BindingFlags.GetProperty,null, excelObject, null,null);
		parameter[0] = filename;
		excelWorkbook = excelWorkbooks.GetType().InvokeMember("Open", System.Reflection.BindingFlags.InvokeMethod,null, excelWorkbooks, parameter,null);
	
		parameter[0] = false; 
		excelObject.GetType().InvokeMember("DisplayAlerts", BindingFlags.SetProperty, null, excelObject, parameter); 
		parameter[0]=1;
		excelWorksheet = excelWorkbook.GetType().InvokeMember("Sheets",System.Reflection.BindingFlags.GetProperty,null, excelWorkbook, parameter,null);
		excelWorksheet.GetType().InvokeMember("Delete",System.Reflection.BindingFlags.InvokeMethod,null, excelWorksheet, null,null);
		excelWorksheet = excelWorkbook.GetType().InvokeMember("Sheets",System.Reflection.BindingFlags.GetProperty,null, excelWorkbook, parameter,null);
		excelWorksheet.GetType().InvokeMember("Delete",System.Reflection.BindingFlags.InvokeMethod,null, excelWorksheet, null,null);
		excelWorksheet = excelWorkbook.GetType().InvokeMember("Sheets",System.Reflection.BindingFlags.GetProperty,null, excelWorkbook, parameter,null);
		excelWorksheet.GetType().InvokeMember("Delete",System.Reflection.BindingFlags.InvokeMethod,null, excelWorksheet, null,null);
		parameter[0] = true; 
		excelObject.GetType().InvokeMember("DisplayAlerts", BindingFlags.SetProperty, null, excelObject, parameter); 
		excelWorkbook.GetType().InvokeMember("Save", System.Reflection.BindingFlags.GetProperty,null, excelWorkbook, null,null);
	}catch(Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<removeExtraSheets> : " + ex.Message, ex);
	}finally{
		if(excelWorkbook!=null)
			excelWorkbook.GetType().InvokeMember("Close",BindingFlags.InvokeMethod,null,excelWorkbook,null);
		if(excelWorkbooks!=null)
			excelWorkbooks.GetType().InvokeMember("Close",BindingFlags.InvokeMethod,null,excelWorkbooks,null);
		if(excelObject!=null)
			excelObject.GetType().InvokeMember("Quit",BindingFlags.InvokeMethod,null,excelObject,null);

		Marshal.ReleaseComObject(excelObject);
		Marshal.ReleaseComObject(excelWorkbooks);
		Marshal.ReleaseComObject(excelWorkbook);
		Marshal.ReleaseComObject(excelWorksheet);

		excelObject=null;
		excelWorkbooks=null;
		excelWorkbook=null;
		excelWorksheet=null;
		GC.Collect();
	}
}

protected
void removeName(string filename, string name){
	try{
		parameter= new object[1]; 
		excel = Type.GetTypeFromProgID("Excel.Application"); 
		excelObject = Activator.CreateInstance(excel); 
		parameter[0] = false; 
		excelObject.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, excelObject, parameter); 
		excelObject.GetType().InvokeMember("UserControl", BindingFlags.SetProperty, null, excelObject, parameter); 

		excelWorkbooks = excelObject.GetType().InvokeMember("Workbooks", System.Reflection.BindingFlags.GetProperty,null, excelObject, null,null);
		parameter[0] = filename;
		excelWorkbook = excelWorkbooks.GetType().InvokeMember("Open", System.Reflection.BindingFlags.InvokeMethod,null, excelWorkbooks, parameter,null);
	}catch(Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<removeName> : " + ex.Message, ex);
	}
	bool existsSheet = true;
	try{
		parameter[0]=name;
		excelWorksheet = excelWorkbook.GetType().InvokeMember("Sheets",System.Reflection.BindingFlags.GetProperty,null, excelWorkbook, parameter,null);
	}catch(Exception){
		existsSheet=false;
	}
	bool existsName = true;
	try{
		excelNames = excelWorkbook.GetType().InvokeMember("Names",System.Reflection.BindingFlags.GetProperty,null, excelWorkbook, null,null);
		parameter[0]=name;
		excelName = excelNames.GetType().InvokeMember("Item",System.Reflection.BindingFlags.InvokeMethod,null, excelNames, parameter,null);
	}catch{
		existsName=false;
	}
	try{
		if(!existsSheet && existsName){
			excelName.GetType().InvokeMember("Delete", System.Reflection.BindingFlags.InvokeMethod,null, excelName, null,null);
			excelWorkbook.GetType().InvokeMember("Save", System.Reflection.BindingFlags.InvokeMethod,null, excelWorkbook, null,null);
		}
	}catch(Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<removeName> : " + ex.Message, ex);
	}finally{
		if(excelWorkbook!=null)
			excelWorkbook.GetType().InvokeMember("Close",BindingFlags.InvokeMethod,null,excelWorkbook,null);
		if(excelWorkbooks!=null)
			excelWorkbooks.GetType().InvokeMember("Close",BindingFlags.InvokeMethod,null,excelWorkbooks,null);
		if(excelObject!=null)
			excelObject.GetType().InvokeMember("Quit",BindingFlags.InvokeMethod,null,excelObject,null);

		if(existsName){
			Marshal.ReleaseComObject(excelName);
			Marshal.ReleaseComObject(excelNames);
		}
		if(existsSheet)
			Marshal.ReleaseComObject(excelWorksheet);
		Marshal.ReleaseComObject(excelObject);
		Marshal.ReleaseComObject(excelWorkbooks);
		Marshal.ReleaseComObject(excelWorkbook);
		
		excelObject=null;
		excelWorkbooks=null;
		excelWorkbook=null;
		excelWorksheet=null;
		excelNames=null;
		excelName=null;
		GC.Collect();
	}
}
/*
protected
void updatePivotTable(string filename){
	Excel.Application excelApp = new Excel.Application();
	excelApp.Visible = false;
	excelApp.UserControl = false;

	Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(filename,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value,Missing.Value);



	Excel.Worksheet excelSheet = (Excel.Worksheet)((Excel.Sheets)excelWorkbook.Sheets)["PivotTable"];

	Excel.PivotTable pivotTable = ((Excel.PivotTable)excelSheet.PivotTables("PivotTable"));

	try{
		pivotTable.RefreshTable();
		excelWorkbook.Save();
	}catch(Exception ex){
		throw new PersistenceException("Error in class " + this.GetType().Name + "<removeName> : " + ex.Message, ex);
	}finally{
		
		excelWorkbook.Close(null,null,null);
		excelApp.Workbooks.Close();
		excelApp.Quit();

		Marshal.ReleaseComObject(pivotTable);
		Marshal.ReleaseComObject(excelSheet);
		Marshal.ReleaseComObject(excelWorkbook);
		Marshal.ReleaseComObject(excelApp);

		pivotTable=null;
		excelSheet=null;
		excelWorkbook=null;
		excelApp=null;
		GC.Collect();
	}
}*/
} // class

} // namespace
