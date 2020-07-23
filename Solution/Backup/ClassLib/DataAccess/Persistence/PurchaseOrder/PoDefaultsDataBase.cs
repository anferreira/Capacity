/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:25 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/PurchaseOrder/PoDefaultsDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: PoDefaultsDataBase.cs,v $
*   Revision 1.3  2006-12-21 19:56:25  bgularte
*   *** empty log message ***
*
*   Revision 1.2  2005/05/17 04:34:53  gmuller
*   ponga aqui un comentario
*
*   Revision 1.1  2005/04/14 03:03:08  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class PoDefaultsDataBase : GenericDataBaseElement {

private int POD_ID;
private int POD_Company;
private string POD_Plant;
private int POD_LastRecLogNum;
private int POD_LastPO;
private string POD_POAutoNum;
private string POD_DefRecCustVend;
private string POD_DefFreighTerms;
private string POD_DefRecLoc;
private string POD_DefShiptoLoc;

public
PoDefaultsDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from podefaults where " + getWhereCondition();

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
	string sql = "select * from podefaults where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.POD_ID = reader.GetInt32("POD_ID");
	this.POD_Company = reader.GetInt32("POD_Company");
	this.POD_Plant = reader.GetString("POD_Plant");
	this.POD_LastRecLogNum = reader.GetInt32("POD_LastRecLogNum");
	this.POD_LastPO = reader.GetInt32("POD_LastPO");
	this.POD_POAutoNum = reader.GetString("POD_POAutoNum");
	this.POD_DefRecCustVend = reader.GetString("POD_DefRecCustVend");
	this.POD_DefFreighTerms = reader.GetString("POD_DefFreighTerms");
	this.POD_DefRecLoc = reader.GetString("POD_DefRecLoc");
	this.POD_DefShiptoLoc = reader.GetString("POD_DefShiptoLoc");
}

public override
void write(){
	string sql = "insert into podefaults (" + 
		"POD_ID," +
		"POD_Company," +
		"POD_Plant," +
		"POD_LastRecLogNum," +
		"POD_LastPO," +
		"POD_POAutoNum," +
		"POD_DefRecCustVend," +
		"POD_DefFreighTerms," +
		"POD_DefRecLoc," +
		"POD_DefShiptoLoc" +

		") values (" + 

		"" + NumberUtil.toString(POD_ID) + "," +
		"" + NumberUtil.toString(POD_Company) + "," +
		"'" + Converter.fixString(POD_Plant) + "'," +
		"" + NumberUtil.toString(POD_LastRecLogNum) + "," +
		"" + NumberUtil.toString(POD_LastPO) + "," +
		"'" + Converter.fixString(POD_POAutoNum) + "'," +
		"'" + Converter.fixString(POD_DefRecCustVend) + "'," +
		"'" + Converter.fixString(POD_DefFreighTerms) + "'," +
		"'" + Converter.fixString(POD_DefRecLoc) + "'," +
		"'" + Converter.fixString(POD_DefShiptoLoc) + "')";
	write(sql);
}

public override
void update(){
	string sql = "update podefaults set " +
		"POD_ID = " + NumberUtil.toString(POD_ID) + ", " +
		"POD_Company = " + NumberUtil.toString(POD_Company) + ", " +
		"POD_Plant = '" + Converter.fixString(POD_Plant) + "', " +
		"POD_LastRecLogNum = " + NumberUtil.toString(POD_LastRecLogNum) + ", " +
		"POD_LastPO = " + NumberUtil.toString(POD_LastPO) + ", " +
		"POD_POAutoNum = '" + Converter.fixString(POD_POAutoNum) + "', " +
		"POD_DefRecCustVend = '" + Converter.fixString(POD_DefRecCustVend) + "', " +
		"POD_DefFreighTerms = '" + Converter.fixString(POD_DefFreighTerms) + "', " +
		"POD_DefRecLoc = '" + Converter.fixString(POD_DefRecLoc) + "', " +
		"POD_DefShiptoLoc = '" + Converter.fixString(POD_DefShiptoLoc) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from podefaults where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"POD_ID = " + NumberUtil.toString(POD_ID) + "";
	return sqlWhere;
}

public
void setPOD_ID(int POD_ID){
	this.POD_ID = POD_ID;
}

public
void setPOD_Company(int POD_Company){
	this.POD_Company = POD_Company;
}

public
void setPOD_Plant(string POD_Plant){
	this.POD_Plant = POD_Plant;
}

public
void setPOD_LastRecLogNum(int POD_LastRecLogNum){
	this.POD_LastRecLogNum = POD_LastRecLogNum;
}

public
void setPOD_LastPO(int POD_LastPO){
	this.POD_LastPO = POD_LastPO;
}

public
void setPOD_POAutoNum(string POD_POAutoNum){
	this.POD_POAutoNum = POD_POAutoNum;
}

public
void setPOD_DefRecCustVend(string POD_DefRecCustVend){
	this.POD_DefRecCustVend = POD_DefRecCustVend;
}

public
void setPOD_DefFreighTerms(string POD_DefFreighTerms){
	this.POD_DefFreighTerms = POD_DefFreighTerms;
}

public
void setPOD_DefRecLoc(string POD_DefRecLoc){
	this.POD_DefRecLoc = POD_DefRecLoc;
}

public
void setPOD_DefShiptoLoc(string POD_DefShiptoLoc){
	this.POD_DefShiptoLoc = POD_DefShiptoLoc;
}

public
int getPOD_ID(){
	return POD_ID;
}

public
int getPOD_Company(){
	return POD_Company;
}

public
string getPOD_Plant(){
	return POD_Plant;
}

public
int getPOD_LastRecLogNum(){
	return POD_LastRecLogNum;
}

public
int getPOD_LastPO(){
	return POD_LastPO;
}

public
string getPOD_POAutoNum(){
	return POD_POAutoNum;
}

public
string getPOD_DefRecCustVend(){
	return POD_DefRecCustVend;
}

public
string getPOD_DefFreighTerms(){
	return POD_DefFreighTerms;
}

public
string getPOD_DefRecLoc(){
	return POD_DefRecLoc;
}

public
string getPOD_DefShiptoLoc(){
	return POD_DefShiptoLoc;
}

} // class

} // package