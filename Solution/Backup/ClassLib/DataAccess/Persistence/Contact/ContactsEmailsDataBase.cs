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
class ContactsEmailsDataBase : GenericDataBaseElement {

private int CE_ContactId;
private string CE_Email;
private string CE_Predetermined;

public
ContactsEmailsDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from contactsemails where " + getWhereCondition();

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
	string sql = "select * from contactsemails where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.CE_ContactId = reader.GetInt32("CE_ContactId");
	this.CE_Email = reader.GetString("CE_Email");
	this.CE_Predetermined = reader.GetString("CE_Predetermined");
}

public override
void write(){
	string sql = "insert into contactsemails (" + 
		"CE_ContactId," +
		"CE_Email," +
		"CE_Predetermined" +

		") values (" + 

		"" + NumberUtil.toString(CE_ContactId) + "," +
		"'" + Converter.fixString(CE_Email) + "'," +
		"'" + Converter.fixString(CE_Predetermined) + "')";
	write(sql);
}

public override
void update(){
	string sql = "update contactsemails set " +
		"CE_ContactId = " + NumberUtil.toString(CE_ContactId) + ", " +
		"CE_Email = '" + Converter.fixString(CE_Email) + "', " +
		"CE_Predetermined = '" + Converter.fixString(CE_Predetermined) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from contactsemails where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"CE_ContactId = " + NumberUtil.toString(CE_ContactId) + " and " +
		"CE_Email = '" + Converter.fixString(CE_Email) + "'";
	return sqlWhere;
}

public
void setCE_ContactId(int CE_ContactId){
	this.CE_ContactId = CE_ContactId;
}

public
void setCE_Email(string CE_Email){
	this.CE_Email = CE_Email;
}

public
void setCE_Predetermined(string CE_Predetermined){
	this.CE_Predetermined = CE_Predetermined;
}

public
int getCE_ContactId(){
	return CE_ContactId;
}

public
string getCE_Email(){
	return CE_Email;
}

public
string getCE_Predetermined(){
	return CE_Predetermined;
}

} // class

} // package