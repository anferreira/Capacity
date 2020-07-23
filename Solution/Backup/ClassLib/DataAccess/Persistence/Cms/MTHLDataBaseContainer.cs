using System;
using System.Collections;
using MySql.Data;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public
class MTHLDataBaseContainer : GenericDataBaseContainer{

public
MTHLDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from ";
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary + ".";
		sql += "mthl";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
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
		string sql = "select * from mthl";
		if (searchText.Length > 0){
			sql += " where MHPART like '" + Converter.fixString(searchText) + "%'";
			sql += " or MHTOOL like '" + Converter.fixString(searchText) + "%'";
			sql += " or MHRSET like '" + Converter.fixString(searchText) + "%'";
			sql += " or MHRRUN like '" + Converter.fixString(searchText) + "%'";
			sql += " or MHUNIT like '" + Converter.fixString(searchText) + "%'";
			sql += " or MHCTBY like '" + Converter.fixString(searchText) + "%'";
			sql += " or MHUPBY like '" + Converter.fixString(searchText) + "%'";
		}
		if (rows > 0)
			sql = DBFormatter.selectTopRows(sql, Configuration.SqlRepositoryType, rows);
		
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
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
		MTHLDataBase mTHLDataBase = new MTHLDataBase(dataBaseAccess);
		mTHLDataBase.load(reader);
		this.Add(mTHLDataBase);
	}
}

public 
void truncate(){
	try{
		string sql = "delete from mthl";
		dataBaseAccess.executeUpdate(sql);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <truncate> : " + de.Message, de);
	}
}

} // class

} // package