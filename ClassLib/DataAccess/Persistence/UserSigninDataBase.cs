/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:24 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/UserSigninDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: UserSigninDataBase.cs,v $
*   Revision 1.3  2006-12-21 19:56:24  bgularte
*   *** empty log message ***
*
*   Revision 1.2  2005/05/17 04:35:17  gmuller
*   ponga aqui un comentario
*
*   Revision 1.1  2005/04/12 19:35:25  aferreira
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class UserSigninDataBase : GenericDataBaseElement {

private int UC_UserId;
private string UC_DefDatabase;
private int UC_DefCompany;
private string UC_DefPlant;
private string UC_DefLabelPrinter;
private string UC_DefPrinter;
private int UC_TimeSignedIn;
private string UC_SecurityProfile;

public
UserSigninDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from usersignin where " + getWhereCondition();

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
	string sql = "select * from usersignin where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.UC_UserId = reader.GetInt32("UC_UserId");
	this.UC_DefDatabase = reader.GetString("UC_DefDatabase");

    try {
	    this.UC_DefCompany = reader.GetInt32("UC_DefCompany");
    }catch{
        this.UC_DefCompany = 0;
        string saux = reader.GetString("UC_DefCompany");
        if (!string.IsNullOrEmpty(saux))
            this.UC_DefCompany = Convert.ToInt32(saux);
    }

	this.UC_DefPlant = reader.GetString("UC_DefPlant");
	this.UC_DefLabelPrinter = reader.GetString("UC_DefLabelPrinter");
	this.UC_DefPrinter = reader.GetString("UC_DefPrinter");
	this.UC_TimeSignedIn = reader.GetInt32("UC_TimeSignedIn");
	this.UC_SecurityProfile = reader.GetString("UC_SecurityProfile");
}

public override
void write(){
	string sql = "insert into usersignin (" + 
		"UC_UserId," +
		"UC_DefDatabase," +
		"UC_DefCompany," +
		"UC_DefPlant," +
		"UC_DefLabelPrinter," +
		"UC_DefPrinter," +
		"UC_TimeSignedIn," +
		"UC_SecurityProfile" +

		") values (" + 

		"" + NumberUtil.toString(UC_UserId) + "," +
		"'" + Converter.fixString(UC_DefDatabase) + "'," +
		"" + NumberUtil.toString(UC_DefCompany) + "," +
		"'" + Converter.fixString(UC_DefPlant) + "'," +
		"'" + Converter.fixString(UC_DefLabelPrinter) + "'," +
		"'" + Converter.fixString(UC_DefPrinter) + "'," +
		"" + NumberUtil.toString(UC_TimeSignedIn) + "," +
		"'" + Converter.fixString(UC_SecurityProfile) + "')";
	write(sql);
}

public override
void update(){
	string sql = "update usersignin set " +
		"UC_UserId = " + NumberUtil.toString(UC_UserId) + ", " +
		"UC_DefDatabase = '" + Converter.fixString(UC_DefDatabase) + "', " +
		"UC_DefCompany = " + NumberUtil.toString(UC_DefCompany) + ", " +
		"UC_DefPlant = '" + Converter.fixString(UC_DefPlant) + "', " +
		"UC_DefLabelPrinter = '" + Converter.fixString(UC_DefLabelPrinter) + "', " +
		"UC_DefPrinter = '" + Converter.fixString(UC_DefPrinter) + "', " +
		"UC_TimeSignedIn = " + NumberUtil.toString(UC_TimeSignedIn) + ", " +
		"UC_SecurityProfile = '" + Converter.fixString(UC_SecurityProfile) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from usersignin where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"UC_UserId = " + NumberUtil.toString(UC_UserId) + "";
	return sqlWhere;
}

public
void setUC_UserId(int UC_UserId){
	this.UC_UserId = UC_UserId;
}

public
void setUC_DefDatabase(string UC_DefDatabase){
	this.UC_DefDatabase = UC_DefDatabase;
}

public
void setUC_DefCompany(int UC_DefCompany){
	this.UC_DefCompany = UC_DefCompany;
}

public
void setUC_DefPlant(string UC_DefPlant){
	this.UC_DefPlant = UC_DefPlant;
}

public
void setUC_DefLabelPrinter(string UC_DefLabelPrinter){
	this.UC_DefLabelPrinter = UC_DefLabelPrinter;
}

public
void setUC_DefPrinter(string UC_DefPrinter){
	this.UC_DefPrinter = UC_DefPrinter;
}

public
void setUC_TimeSignedIn(int UC_TimeSignedIn){
	this.UC_TimeSignedIn = UC_TimeSignedIn;
}

public
void setUC_SecurityProfile(string UC_SecurityProfile){
	this.UC_SecurityProfile = UC_SecurityProfile;
}

public
int getUC_UserId(){
	return UC_UserId;
}

public
string getUC_DefDatabase(){
	return UC_DefDatabase;
}

public
int getUC_DefCompany(){
	return UC_DefCompany;
}

public
string getUC_DefPlant(){
	return UC_DefPlant;
}

public
string getUC_DefLabelPrinter(){
	return UC_DefLabelPrinter;
}

public
string getUC_DefPrinter(){
	return UC_DefPrinter;
}

public
int getUC_TimeSignedIn(){
	return UC_TimeSignedIn;
}

public
string getUC_SecurityProfile(){
	return UC_SecurityProfile;
}

} // class

} // package