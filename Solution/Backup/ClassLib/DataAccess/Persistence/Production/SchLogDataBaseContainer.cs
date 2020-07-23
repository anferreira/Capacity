using System;
using System.Collections;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class SchLogDataBaseContainer : GenericDataBaseContainer{

public
SchLogDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schlog";
		reader = dataBaseAccess.executeQuery(sql);
		load(reader);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByDesc(string searchText, int rows){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schlog";
		if (searchText.Length > 0){
			sql += " where SL_Db like '" + Converter.fixString(searchText) + "%'";
			sql += " or SL_JobcardID like '" + Converter.fixString(searchText) + "%'";
			sql += " or SL_Company like '" + Converter.fixString(searchText) + "%'";
			sql += " or SL_Plant like '" + Converter.fixString(searchText) + "%'";
			sql += " or SL_Department like '" + Converter.fixString(searchText) + "%'";
			sql += " or SL_Machine like '" + Converter.fixString(searchText) + "%'";
			sql += " or SL_Part like '" + Converter.fixString(searchText) + "%'";
			sql += " or SL_Description like '" + Converter.fixString(searchText) + "%'";
			sql += " or SL_Part2 like '" + Converter.fixString(searchText) + "%'";
			sql += " or SL_Description2 like '" + Converter.fixString(searchText) + "%'";
			sql += " or SL_Part3 like '" + Converter.fixString(searchText) + "%'";
			sql += " or SL_Description3 like '" + Converter.fixString(searchText) + "%'";
			sql += " or SL_Part4 like '" + Converter.fixString(searchText) + "%'";
			sql += " or SL_Description4 like '" + Converter.fixString(searchText) + "%'";
			sql += " or SL_Family like '" + Converter.fixString(searchText) + "%'";
			sql += " or SL_FamilyDescription like '" + Converter.fixString(searchText) + "%'";
			sql += " or SL_UOM like '" + Converter.fixString(searchText) + "%'";
			sql += " or SL_MainTool like '" + Converter.fixString(searchText) + "%'";
			sql += " or SL_MainMaterial like '" + Converter.fixString(searchText) + "%'";
			sql += " or SL_Status like '" + Converter.fixString(searchText) + "%'";
		}
		if (rows > 0)
			sql = DBFormatter.selectTopRows(sql, Configuration.SqlRepositoryType, rows);
		reader = dataBaseAccess.executeQuery(sql);
		load(reader);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDesc> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}	
}

public
void load(NotNullDataReader reader){
	while(reader.Read()){
		SchLogDataBase schLogDataBase = new SchLogDataBase(dataBaseAccess);
		schLogDataBase.load(reader);
		this.Add(schLogDataBase);
	}
}

public
void truncate(){
	try{	
		string sql = "delete from schlog";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + mySqlExc.Message, mySqlExc);
	}	
}

} // class
} // package