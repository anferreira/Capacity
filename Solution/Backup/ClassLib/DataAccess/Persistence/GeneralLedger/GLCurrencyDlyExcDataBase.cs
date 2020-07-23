/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author Claudia Melo$ 
*   $Date 03/10/2005$ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/GeneralLedger/GLCurrencyDlyExcDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: GLCurrencyDlyExcDataBase.cs,v $
*   Revision 1.3  2006-12-21 19:56:25  bgularte
*   *** empty log message ***
*
*   Revision 1.2  2005/05/17 04:34:52  gmuller
*   ponga aqui un comentario
*
*   Revision 1.1  2005/03/11 03:15:52  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class GLCurrencyDlyExcDataBase : GenericDataBaseElement {

private string CDE_Db;
private int CDE_Company;
private DateTime CDE_StartingDate;
private DateTime CDE_EndingDate;
private string CDE_CurrencyBase;
private decimal CDE_ExchangeRate;
private string CDE_CurrencyCode;
private DateTime CDE_DateCreated;
private string CDE_UserCreated;
private DateTime CDE_DateUpdated;
private string CDE_UserUpdated;

public
GLCurrencyDlyExcDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from glcurrencydlyexc where " + getWhereCondition();

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
	string sql = "select * from glcurrencydlyexc where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.CDE_Db = reader.GetString("CDE_Db");
	this.CDE_Company = reader.GetInt32("CDE_Company");
	this.CDE_StartingDate = reader.GetDateTime("CDE_StartingDate");
	this.CDE_EndingDate = reader.GetDateTime("CDE_EndingDate");
	this.CDE_CurrencyBase = reader.GetString("CDE_CurrencyBase");
	this.CDE_ExchangeRate = reader.GetDecimal("CDE_ExchangeRate");
	this.CDE_CurrencyCode = reader.GetString("CDE_CurrencyCode");
	this.CDE_DateCreated = reader.GetDateTime("CDE_DateCreated");
	this.CDE_UserCreated = reader.GetString("CDE_UserCreated");
	this.CDE_DateUpdated = reader.GetDateTime("CDE_DateUpdated");
	this.CDE_UserUpdated = reader.GetString("CDE_UserUpdated");
}

public override
void write(){
	string sql = "insert into glcurrencydlyexc (" + 
		"CDE_Db," +
		"CDE_Company," +
		"CDE_StartingDate," +
		"CDE_EndingDate," +
		"CDE_CurrencyBase," +
		"CDE_ExchangeRate," +
		"CDE_CurrencyCode," +
		"CDE_DateCreated," +
		"CDE_UserCreated," +
		"CDE_DateUpdated," +
		"CDE_UserUpdated" +

		") values (" + 

		"'" + Converter.fixString(CDE_Db) + "'," +
		"" + NumberUtil.toString(CDE_Company) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(CDE_StartingDate) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(CDE_EndingDate) + "'," +
		"'" + Converter.fixString(CDE_CurrencyBase) + "'," +
		"" + NumberUtil.toString(CDE_ExchangeRate) + "," +
		"'" + Converter.fixString(CDE_CurrencyCode) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(CDE_DateCreated) + "'," +
		"'" + Converter.fixString(CDE_UserCreated) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(CDE_DateUpdated) + "'," +
		"'" + Converter.fixString(CDE_UserUpdated) + "')";
	write(sql);
}

public override
void update(){
	string sql = "update glcurrencydlyexc set " +
		"CDE_Db = '" + Converter.fixString(CDE_Db) + "', " +
		"CDE_Company = " + NumberUtil.toString(CDE_Company) + ", " +
		"CDE_StartingDate = '" + DateUtil.getCompleteDateRepresentation(CDE_StartingDate) + "', " +
		"CDE_EndingDate = '" + DateUtil.getCompleteDateRepresentation(CDE_EndingDate) + "', " +
		"CDE_CurrencyBase = '" + Converter.fixString(CDE_CurrencyBase) + "', " +
		"CDE_ExchangeRate = " + NumberUtil.toString(CDE_ExchangeRate) + ", " +
		"CDE_CurrencyCode = '" + Converter.fixString(CDE_CurrencyCode) + "', " +
		"CDE_DateCreated = '" + DateUtil.getCompleteDateRepresentation(CDE_DateCreated) + "', " +
		"CDE_UserCreated = '" + Converter.fixString(CDE_UserCreated) + "', " +
		"CDE_DateUpdated = '" + DateUtil.getCompleteDateRepresentation(CDE_DateUpdated) + "', " +
		"CDE_UserUpdated = '" + Converter.fixString(CDE_UserUpdated) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from glcurrencydlyexc where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"CDE_Db = '" + Converter.fixString(CDE_Db) + "' and " +
		"CDE_Company = " + NumberUtil.toString(CDE_Company) + " and " +
		"CDE_StartingDate = '" + DateUtil.getCompleteDateRepresentation(CDE_StartingDate) + "' and " +
		"CDE_EndingDate = '" + DateUtil.getCompleteDateRepresentation(CDE_EndingDate) + "' and " +
		"CDE_CurrencyBase = '" + Converter.fixString(CDE_CurrencyBase) + "'";
	return sqlWhere;
}

public
void setCDE_Db(string CDE_Db){
	this.CDE_Db = CDE_Db;
}

public
void setCDE_Company(int CDE_Company){
	this.CDE_Company = CDE_Company;
}

public
void setCDE_StartingDate(DateTime CDE_StartingDate){
	this.CDE_StartingDate = CDE_StartingDate;
}

public
void setCDE_EndingDate(DateTime CDE_EndingDate){
	this.CDE_EndingDate = CDE_EndingDate;
}

public
void setCDE_CurrencyBase(string CDE_CurrencyBase){
	this.CDE_CurrencyBase = CDE_CurrencyBase;
}

public
void setCDE_ExchangeRate(decimal CDE_ExchangeRate){
	this.CDE_ExchangeRate = CDE_ExchangeRate;
}

public
void setCDE_CurrencyCode(string CDE_CurrencyCode){
	this.CDE_CurrencyCode = CDE_CurrencyCode;
}

public
void setCDE_DateCreated(DateTime CDE_DateCreated){
	this.CDE_DateCreated = CDE_DateCreated;
}

public
void setCDE_UserCreated(string CDE_UserCreated){
	this.CDE_UserCreated = CDE_UserCreated;
}

public
void setCDE_DateUpdated(DateTime CDE_DateUpdated){
	this.CDE_DateUpdated = CDE_DateUpdated;
}

public
void setCDE_UserUpdated(string CDE_UserUpdated){
	this.CDE_UserUpdated = CDE_UserUpdated;
}

public
string getCDE_Db(){
	return CDE_Db;
}

public
int getCDE_Company(){
	return CDE_Company;
}

public
DateTime getCDE_StartingDate(){
	return CDE_StartingDate;
}

public
DateTime getCDE_EndingDate(){
	return CDE_EndingDate;
}

public
string getCDE_CurrencyBase(){
	return CDE_CurrencyBase;
}

public
decimal getCDE_ExchangeRate(){
	return CDE_ExchangeRate;
}

public
string getCDE_CurrencyCode(){
	return CDE_CurrencyCode;
}

public
DateTime getCDE_DateCreated(){
	return CDE_DateCreated;
}

public
string getCDE_UserCreated(){
	return CDE_UserCreated;
}

public
DateTime getCDE_DateUpdated(){
	return CDE_DateUpdated;
}

public
string getCDE_UserUpdated(){
	return CDE_UserUpdated;
}

} // class

} // package