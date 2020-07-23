/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:25 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/ExcelReports/ExcelReportsSetupDataBaseContainer.cs,v $ 
*   $State: Exp $ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.Common;


namespace  Nujit.NujitERP.ClassLib.DataAccess.Persistence.ExcelReports{


public
class ExcelReportsSetupDataBaseContainer : GenericDataBaseContainer{

public
ExcelReportsSetupDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from excelreportssetup";
		reader = dataBaseAccess.executeQuery(sql);
		load(reader);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByDesc(string searchText, int rows){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from excelreportssetup";
		if (searchText.Length > 0){
			sql += " where EXC_ReportName like '" + Converter.fixString(searchText) + "%'";
			sql += " or EXC_Path like '" + Converter.fixString(searchText) + "%'";
			sql += " or EXC_SqlSentence like '" + Converter.fixString(searchText) + "%'";
		}
		if (rows > 0)
			sql = DBFormatter.selectTopRows(sql, Configuration.SqlRepositoryType, rows);

		reader = dataBaseAccess.executeQuery(sql);
		load(reader);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByDescType(string searchText,string type, int rows){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from excelreportssetup where EXC_Type = '";
		sql += Converter.fixString(type) + "' ";
		if (searchText.Length > 0){
			sql += " and ( EXC_ReportName like '" + Converter.fixString(searchText) + "%'";
			sql += " or EXC_Path like '" + Converter.fixString(searchText) + "%'";
			sql += " or EXC_SqlSentence like '" + Converter.fixString(searchText) + "%' )";
		}
		if (rows > 0)
			sql = DBFormatter.selectTopRows(sql, Configuration.SqlRepositoryType, rows);

		reader = dataBaseAccess.executeQuery(sql);
		load(reader);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

internal
void load(NotNullDataReader reader){
	while(reader.Read()){
		ExcelReportsSetupDataBase excelReportsSetupDataBase = new ExcelReportsSetupDataBase(dataBaseAccess);
		excelReportsSetupDataBase.load(reader);
		this.Add(excelReportsSetupDataBase);
	}
}

public
void truncate(){
	try{
		string sql = "delete from excelreportssetup";

		dataBaseAccess.executeUpdate(sql);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message,mySqlExc);
	}
}

} // class

} // package