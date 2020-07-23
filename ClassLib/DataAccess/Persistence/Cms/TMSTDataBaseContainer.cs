/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:24 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/Cms/TMSTDataBaseContainer.cs,v $ 
*   $State: Exp $ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using MySql.Data;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public
class TMSTDataBaseContainer : GenericDataBaseContainer{

public
TMSTDataBaseContainer(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from ";
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary + ".";
		sql += "tmst";
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
		string sql = "select * from tmst";
		
		if (searchText.Length > 0){
			sql += " where LXTOOL like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXDES1 like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXDES2 like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXDES3 like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXCLSS like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXAST like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXSTKL like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXBIN like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXSTAT like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXUNIT like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXFPRT like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXFORD like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXLPRT like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXLORD like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXCPRT like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXCORD like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXMTPT like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXOWNT like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXOWNR like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXCTBY like '" + Converter.fixString(searchText) + "%'";
			sql += " or LXUPBY like '" + Converter.fixString(searchText) + "%'";
		}
		if (rows > 0)
			sql = DBFormatter.selectTopRows(sql, Configuration.SqlRepositoryType, rows);
			
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
void load(NotNullDataReader reader){
	while(reader.Read()){
		TMSTDataBase tMSTDataBase = new TMSTDataBase(dataBaseAccess);
		tMSTDataBase.load(reader);
		this.Add(tMSTDataBase);
	}
}

public 
void truncate(){
	try{
		string sql = "delete from tmst";
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