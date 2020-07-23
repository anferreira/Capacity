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
class PdToolPartDataBaseContainer : GenericDataBaseContainer{

public
PdToolPartDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pdtoolpart";
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
		string sql = "select * from pdtoolpart";
		if (searchText.Length > 0){
			sql += " where PTP_Db like '" + Converter.fixString(searchText) + "%'";
			sql += " or PTP_Company like '" + Converter.fixString(searchText) + "%'";
			sql += " or PTP_Plant like '" + Converter.fixString(searchText) + "%'";
			sql += " or PTP_Family like '" + Converter.fixString(searchText) + "%'";
			sql += " or PTP_Part like '" + Converter.fixString(searchText) + "%'";
			sql += " or PTP_ToolNum like '" + Converter.fixString(searchText) + "%'";
			sql += " or PTP_ReqSetup like '" + Converter.fixString(searchText) + "%'";
			sql += " or PTP_ReqRun like '" + Converter.fixString(searchText) + "%'";
			sql += " or PTP_Uom like '" + Converter.fixString(searchText) + "%'";
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
		PdToolPartDataBase pdToolPartDataBase = new PdToolPartDataBase(dataBaseAccess);
		pdToolPartDataBase.load(reader);
		this.Add(pdToolPartDataBase);
	}
}

public
void truncate(){
	try{	
		string sql = "delete from pdtoolpart";
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