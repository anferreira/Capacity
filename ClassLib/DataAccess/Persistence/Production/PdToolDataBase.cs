using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class PdToolDataBase : GenericDataBaseElement{

private int TOO_ID;
private string TOO_Db;
private string TOO_Company;
private string TOO_Plant;
private string TOO_ToolNumber;
private string TOO_Desc1;
private string TOO_Desc2;
private string TOO_Desc3;
private string TOO_MaintenanceClass;
private string TOO_AssetID;
private string TOO_ToolStatus;
private string TOO_ScheduleStatus;
private string TOO_ProductionUom;
private string TOO_CurrentWorkOrder;

public
PdToolDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}


public
bool read(){
	string sql = "select * from pdtool where " + getWhereCondition();
	return read(sql);
}

public
bool readById(){
	string sql = "select * from pdtool where TOO_ID = " + NumberUtil.toString(TOO_ID);
	return read(sql);
}

public
bool exists(){
	string sql = "select * from pdtool where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.TOO_ID = reader.GetInt32("TOO_ID");
	this.TOO_Db = reader.GetString("TOO_Db");
	this.TOO_Company = reader.GetString("TOO_Company");
	this.TOO_Plant = reader.GetString("TOO_Plant");
	this.TOO_ToolNumber = reader.GetString("TOO_ToolNumber");
	this.TOO_Desc1 = reader.GetString("TOO_Desc1");
	this.TOO_Desc2 = reader.GetString("TOO_Desc2");
	this.TOO_Desc3 = reader.GetString("TOO_Desc3");
	this.TOO_MaintenanceClass = reader.GetString("TOO_MaintenanceClass");
	this.TOO_AssetID = reader.GetString("TOO_AssetID");
	this.TOO_ToolStatus = reader.GetString("TOO_ToolStatus");
	this.TOO_ScheduleStatus = reader.GetString("TOO_ScheduleStatus");
	this.TOO_ProductionUom = reader.GetString("TOO_ProductionUom");
	this.TOO_CurrentWorkOrder = reader.GetString("TOO_CurrentWorkOrder");
}

public override
void write(){
	try{
		string sql = "insert into pdtool(" + 
			"TOO_Db," +
			"TOO_Company," +
			"TOO_Plant," +
			"TOO_ToolNumber," +
			"TOO_Desc1," +
			"TOO_Desc2," +
			"TOO_Desc3," +
			"TOO_MaintenanceClass," +
			"TOO_AssetID," +
			"TOO_ToolStatus," +
			"TOO_ScheduleStatus," +
			"TOO_ProductionUom," +
			"TOO_CurrentWorkOrder" +

			") values (" + 

			"'" + Converter.fixString(TOO_Db) + "'," +
			"'" + Converter.fixString(TOO_Company) + "'," +
			"'" + Converter.fixString(TOO_Plant) + "'," +
			"'" + Converter.fixString(TOO_ToolNumber) + "'," +
			"'" + Converter.fixString(TOO_Desc1) + "'," +
			"'" + Converter.fixString(TOO_Desc2) + "'," +
			"'" + Converter.fixString(TOO_Desc3) + "'," +
			"'" + Converter.fixString(TOO_MaintenanceClass) + "'," +
			"'" + Converter.fixString(TOO_AssetID) + "'," +
			"'" + Converter.fixString(TOO_ToolStatus) + "'," +
			"'" + Converter.fixString(TOO_ScheduleStatus) + "'," +
			"'" + Converter.fixString(TOO_ProductionUom) + "'," +
			"'" + Converter.fixString(TOO_CurrentWorkOrder) + "')";
		
		dataBaseAccess.executeUpdate(sql);

		this.setTOO_ID(dataBaseAccess.getLastId());
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void update(){
	try{
		string sql = "update pdtool set " +
		"TOO_Db = '" + Converter.fixString(TOO_Db) + "', " +
		"TOO_Company = '" + Converter.fixString(TOO_Company) + "', " +
		"TOO_Plant = '" + Converter.fixString(TOO_Plant) + "', " +
		"TOO_ToolNumber = '" + Converter.fixString(TOO_ToolNumber) + "', " +
		"TOO_Desc1 = '" + Converter.fixString(TOO_Desc1) + "', " +
		"TOO_Desc2 = '" + Converter.fixString(TOO_Desc2) + "', " +
		"TOO_Desc3 = '" + Converter.fixString(TOO_Desc3) + "', " +
		"TOO_MaintenanceClass = '" + Converter.fixString(TOO_MaintenanceClass) + "', " +
		"TOO_AssetID = '" + Converter.fixString(TOO_AssetID) + "', " +
		"TOO_ToolStatus = '" + Converter.fixString(TOO_ToolStatus) + "', " +
		"TOO_ScheduleStatus = '" + Converter.fixString(TOO_ScheduleStatus) + "', " +
		"TOO_ProductionUom = '" + Converter.fixString(TOO_ProductionUom) + "', " +
		"TOO_CurrentWorkOrder = '" + Converter.fixString(TOO_CurrentWorkOrder) + "' " +

		"where " + getWhereCondition();

		dataBaseAccess.executeUpdate(sql);
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void delete(){
	try{
		string sql = "delete from pdtool where " + getWhereCondition();
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}	
}

public
string getWhereCondition(){
	string sqlWhere =
		"TOO_Db = '" + Converter.fixString(TOO_Db) + "' and " +
		"TOO_Company = '" + Converter.fixString(TOO_Company) + "' and " +
		"TOO_Plant = '" + Converter.fixString(TOO_Plant) + "' and " +
		"TOO_ToolNumber = '" + Converter.fixString(TOO_ToolNumber) + "'";
	return sqlWhere;
}

public
void setTOO_ID(int TOO_ID){
	this.TOO_ID = TOO_ID;
}

public
void setTOO_Db(string TOO_Db){
	this.TOO_Db = TOO_Db;
}

public
void setTOO_Company(string TOO_Company){
	this.TOO_Company = TOO_Company;
}

public
void setTOO_Plant(string TOO_Plant){
	this.TOO_Plant = TOO_Plant;
}

public
void setTOO_ToolNumber(string TOO_ToolNumber){
	this.TOO_ToolNumber = TOO_ToolNumber;
}

public
void setTOO_Desc1(string TOO_Desc1){
	this.TOO_Desc1 = TOO_Desc1;
}

public
void setTOO_Desc2(string TOO_Desc2){
	this.TOO_Desc2 = TOO_Desc2;
}

public
void setTOO_Desc3(string TOO_Desc3){
	this.TOO_Desc3 = TOO_Desc3;
}

public
void setTOO_MaintenanceClass(string TOO_MaintenanceClass){
	this.TOO_MaintenanceClass = TOO_MaintenanceClass;
}

public
void setTOO_AssetID(string TOO_AssetID){
	this.TOO_AssetID = TOO_AssetID;
}

public
void setTOO_ToolStatus(string TOO_ToolStatus){
	this.TOO_ToolStatus = TOO_ToolStatus;
}

public
void setTOO_ScheduleStatus(string TOO_ScheduleStatus){
	this.TOO_ScheduleStatus = TOO_ScheduleStatus;
}

public
void setTOO_ProductionUom(string TOO_ProductionUom){
	this.TOO_ProductionUom = TOO_ProductionUom;
}

public
void setTOO_CurrentWorkOrder(string TOO_CurrentWorkOrder){
	this.TOO_CurrentWorkOrder = TOO_CurrentWorkOrder;
}

public
int getTOO_ID(){
	return TOO_ID;
}

public
string getTOO_Db(){
	return TOO_Db;
}

public
string getTOO_Company(){
	return TOO_Company;
}

public
string getTOO_Plant(){
	return TOO_Plant;
}

public
string getTOO_ToolNumber(){
	return TOO_ToolNumber;
}

public
string getTOO_Desc1(){
	return TOO_Desc1;
}

public
string getTOO_Desc2(){
	return TOO_Desc2;
}

public
string getTOO_Desc3(){
	return TOO_Desc3;
}

public
string getTOO_MaintenanceClass(){
	return TOO_MaintenanceClass;
}

public
string getTOO_AssetID(){
	return TOO_AssetID;
}

public
string getTOO_ToolStatus(){
	return TOO_ToolStatus;
}

public
string getTOO_ScheduleStatus(){
	return TOO_ScheduleStatus;
}

public
string getTOO_ProductionUom(){
	return TOO_ProductionUom;
}

public
string getTOO_CurrentWorkOrder(){
	return TOO_CurrentWorkOrder;
}

} // class

} // package