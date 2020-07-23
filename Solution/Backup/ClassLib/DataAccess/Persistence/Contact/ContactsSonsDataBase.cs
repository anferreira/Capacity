/*/////////////////////////////////////////////////////////////////////////////////

 This class was copy from the Tooling Project. 
Claudia Melo
05-04-2005

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{



public
class ContactsSonsDataBase : GenericDataBaseElement {

private int CE_ContactId;
private string CE_Son;

public
ContactsSonsDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from contactssons where " + getWhereCondition();

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
	string sql = "select * from contactssons where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.CE_ContactId = reader.GetInt32("CE_ContactId");
	this.CE_Son = reader.GetString("CE_Son");
}

public override
void write(){
	string sql = "insert into contactssons (" + 
		"CE_ContactId," +
		"CE_Son" +

		") values (" + 

		"" + NumberUtil.toString(CE_ContactId) + "," +
		"'" + Converter.fixString(CE_Son) + "')";
	write(sql);
}

public override
void update(){
	string sql = "update contactssons set " +
		"CE_ContactId = " + NumberUtil.toString(CE_ContactId) + ", " +
		"CE_Son = '" + Converter.fixString(CE_Son) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from contactssons where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"CE_ContactId = " + NumberUtil.toString(CE_ContactId) + " and " +
		"CE_Son = '" + Converter.fixString(CE_Son) + "'";
	return sqlWhere;
}

public
void setCE_ContactId(int CE_ContactId){
	this.CE_ContactId = CE_ContactId;
}

public
void setCE_Son(string CE_Son){
	this.CE_Son = CE_Son;
}

public
int getCE_ContactId(){
	return CE_ContactId;
}

public
string getCE_Son(){
	return CE_Son;
}

} // class

} // package