/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:25 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/GeneralLedger/GLCurrencyDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: GLCurrencyDataBase.cs,v $
*   Revision 1.4  2006-12-21 19:56:25  bgularte
*   *** empty log message ***
*
*   Revision 1.3  2005/05/17 04:34:52  gmuller
*   ponga aqui un comentario
*
*   Revision 1.2  2005/03/11 20:28:14  cmelo
*   *** empty log message ***
*
*   Revision 1.1  2005/03/11 03:28:33  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class GLCurrencyDataBase : GenericDataBaseElement {

private string GLC_Db;
private string GLC_currency;
private string GLC_Description;

public
GLCurrencyDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from glcurrency where " + getWhereCondition();

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
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
bool exists(){
	string sql = "select * from glcurrency where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.GLC_Db = reader.GetString("GLC_Db");
	this.GLC_currency = reader.GetString("GLC_currency");
	this.GLC_Description = reader.GetString("GLC_Description");
}

public override
void write(){
	string sql = "insert into glcurrency (" + 
		"GLC_Db," +
		"GLC_currency," +
		"GLC_Description" +

		") values (" + 

		"'" + Converter.fixString(GLC_Db) + "'," +
		"'" + Converter.fixString(GLC_currency) + "'," +
		"'" + Converter.fixString(GLC_Description) + "')";
	write(sql);
}

public override
void update(){
	string sql = "update glcurrency set " +
		"GLC_Db = '" + Converter.fixString(GLC_Db) + "', " +
		"GLC_currency = '" + Converter.fixString(GLC_currency) + "', " +
		"GLC_Description = '" + Converter.fixString(GLC_Description) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from glcurrency where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"GLC_Db = '" + Converter.fixString(GLC_Db) + "' and " +
		"GLC_currency = '" + Converter.fixString(GLC_currency) + "'";
	return sqlWhere;
}

public
void setGLC_Db(string GLC_Db){
	this.GLC_Db = GLC_Db;
}

public
void setGLC_Currency(string GLC_currency){
	this.GLC_currency = GLC_currency;
}

public
void setGLC_Description(string GLC_Description){
	this.GLC_Description = GLC_Description;
}

public
string getGLC_Db(){
	return GLC_Db;
}

public
string getGLC_Currency(){
	return GLC_currency;
}

public
string getGLC_Description(){
	return GLC_Description;
}

} // class

} // package