/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $  Claudia Melo
*   $Date: 2006-12-21 19:56:24 $  6/4/2005
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/TellerDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: TellerDataBase.cs,v $
*   Revision 1.3  2006-12-21 19:56:24  bgularte
*   *** empty log message ***
*
*   Revision 1.2  2005/05/17 04:35:17  gmuller
*   ponga aqui un comentario
*
*   Revision 1.1  2005/04/07 20:37:29  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class TellerDataBase : GenericDataBaseElement {

private int T_Id;
private string T_DB;
private string T_Store;
private string T_Teller;

public
TellerDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from teller where " + getWhereCondition();

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
	string sql = "select * from teller where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.T_Id = reader.GetInt32("T_Id");
	this.T_DB = reader.GetString("T_DB");
	this.T_Store = reader.GetString("T_Store");
	this.T_Teller = reader.GetString("T_Teller");
}

public override
void write(){
	string sql = "insert into teller (" + 
		"T_DB," +
		"T_Store," +
		"T_Teller" +

		") values (" + 

		"'" + Converter.fixString(T_DB) + "'," +
		"'" + Converter.fixString(T_Store) + "'," +
		"'" + Converter.fixString(T_Teller) + "')";
	write(sql);
}

public override
void update(){
	string sql = "update teller set " +
		"T_DB = '" + Converter.fixString(T_DB) + "', " +
		"T_Store = '" + Converter.fixString(T_Store) + "', " +
		"T_Teller = '" + Converter.fixString(T_Teller) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from teller where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"T_Id = " + NumberUtil.toString(T_Id) + "";
	return sqlWhere;
}

public
void setT_Id(int T_Id){
	this.T_Id = T_Id;
}

public
void setT_DB(string T_DB){
	this.T_DB = T_DB;
}

public
void setT_Store(string T_Store){
	this.T_Store = T_Store;
}

public
void setT_Teller(string T_Teller){
	this.T_Teller = T_Teller;
}

public
int getT_Id(){
	return T_Id;
}

public
string getT_DB(){
	return T_DB;
}

public
string getT_Store(){
	return T_Store;
}

public
string getT_Teller(){
	return T_Teller;
}

} // class

} // package