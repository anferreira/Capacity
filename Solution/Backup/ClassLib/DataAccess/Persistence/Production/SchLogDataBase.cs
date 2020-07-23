using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class SchLogDataBase : GenericDataBaseElement{

private int SL_ID;
private string SL_Db;
private string SL_JobcardID;
private string SL_Company;
private string SL_Plant;
private string SL_Department;
private string SL_Machine;
private string SL_Part;
private string SL_Description;
private string SL_Part2;
private string SL_Description2;
private string SL_Part3;
private string SL_Description3;
private string SL_Part4;
private string SL_Description4;
private string SL_Family;
private string SL_FamilyDescription;
private decimal SL_RunQty;
private string SL_UOM;
private decimal SL_RunStandard;
private decimal SL_MachineHrs;
private string SL_MainTool;
private decimal SL_QtyPerTool;
private string SL_MainMaterial;
private decimal SL_QtyPer;
private decimal SL_MaterialReq;
private string SL_Status;
private DateTime SL_DateReq;
private string SL_Operation;
private string SL_NextOperation;

public
SchLogDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schlog where " + getWhereCondition();
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
bool exists(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from schlog where " + getWhereCondition();
		
		bool founded = false;
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			founded = true;
		return founded;
	}catch(System.Data.SqlClient.SqlException){
		return false;
	}catch(System.Data.DataException){
		return false;
	}catch(MySql.Data.MySqlClient.MySqlException){
		return false;
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void load(NotNullDataReader reader){
	this.SL_ID = reader.GetInt32("SL_ID");
	this.SL_Db = reader.GetString("SL_Db");
	this.SL_JobcardID = reader.GetString("SL_JobcardID");
	this.SL_Company = reader.GetString("SL_Company");
	this.SL_Plant = reader.GetString("SL_Plant");
	this.SL_Department = reader.GetString("SL_Department");
	this.SL_Machine = reader.GetString("SL_Machine");
	this.SL_Part = reader.GetString("SL_Part");
	this.SL_Description = reader.GetString("SL_Description");
	this.SL_Part2 = reader.GetString("SL_Part2");
	this.SL_Description2 = reader.GetString("SL_Description2");
	this.SL_Part3 = reader.GetString("SL_Part3");
	this.SL_Description3 = reader.GetString("SL_Description3");
	this.SL_Part4 = reader.GetString("SL_Part4");
	this.SL_Description4 = reader.GetString("SL_Description4");
	this.SL_Family = reader.GetString("SL_Family");
	this.SL_FamilyDescription = reader.GetString("SL_FamilyDescription");
	this.SL_RunQty = reader.GetDecimal("SL_RunQty");
	this.SL_UOM = reader.GetString("SL_UOM");
	this.SL_RunStandard = reader.GetDecimal("SL_RunStandard");
	this.SL_MachineHrs = reader.GetDecimal("SL_MachineHrs");
	this.SL_MainTool = reader.GetString("SL_MainTool");
	this.SL_QtyPerTool = reader.GetDecimal("SL_QtyPerTool");
	this.SL_MainMaterial = reader.GetString("SL_MainMaterial");
	this.SL_QtyPer = reader.GetDecimal("SL_QtyPer");
	this.SL_MaterialReq = reader.GetDecimal("SL_MaterialReq");
	this.SL_Status = reader.GetString("SL_Status");
	this.SL_DateReq = reader.GetDateTime("SL_DateReq");
	this.SL_Operation = reader.GetString("SL_Operation");
	this.SL_NextOperation = reader.GetString("SL_NextOperation");
}

public override
void write(){
	try{
		string sql = "insert into schlog(" + 
			"SL_Db," +
			"SL_JobcardID," +
			"SL_Company," +
			"SL_Plant," +
			"SL_Department," +
			"SL_Machine," +
			"SL_Part," +
			"SL_Description," +
			"SL_Part2," +
			"SL_Description2," +
			"SL_Part3," +
			"SL_Description3," +
			"SL_Part4," +
			"SL_Description4," +
			"SL_Family," +
			"SL_FamilyDescription," +
			"SL_RunQty," +
			"SL_UOM," +
			"SL_RunStandard," +
			"SL_MachineHrs," +
			"SL_MainTool," +
			"SL_QtyPerTool," +
			"SL_MainMaterial," +
			"SL_QtyPer," +
			"SL_MaterialReq," +
			"SL_Status," +
			"SL_DateReq," +
			"SL_Operation," +
			"SL_NextOperation" +

			") values (" + 

			"'" + Converter.fixString(SL_Db) + "'," +
			"'" + Converter.fixString(SL_JobcardID) + "'," +
			"'" + Converter.fixString(SL_Company) + "'," +
			"'" + Converter.fixString(SL_Plant) + "'," +
			"'" + Converter.fixString(SL_Department) + "'," +
			"'" + Converter.fixString(SL_Machine) + "'," +
			"'" + Converter.fixString(SL_Part) + "'," +
			"'" + Converter.fixString(SL_Description) + "'," +
			"'" + Converter.fixString(SL_Part2) + "'," +
			"'" + Converter.fixString(SL_Description2) + "'," +
			"'" + Converter.fixString(SL_Part3) + "'," +
			"'" + Converter.fixString(SL_Description3) + "'," +
			"'" + Converter.fixString(SL_Part4) + "'," +
			"'" + Converter.fixString(SL_Description4) + "'," +
			"'" + Converter.fixString(SL_Family) + "'," +
			"'" + Converter.fixString(SL_FamilyDescription) + "'," +
			"" + NumberUtil.toString(SL_RunQty) + "," +
			"'" + Converter.fixString(SL_UOM) + "'," +
			"" + NumberUtil.toString(SL_RunStandard) + "," +
			"" + NumberUtil.toString(SL_MachineHrs) + "," +
			"'" + Converter.fixString(SL_MainTool) + "'," +
			"" + NumberUtil.toString(SL_QtyPerTool) + "," +
			"'" + Converter.fixString(SL_MainMaterial) + "'," +
			"" + NumberUtil.toString(SL_QtyPer) + "," +
			"" + NumberUtil.toString(SL_MaterialReq) + "," +
			"'" + Converter.fixString(SL_Status) + "'," +
			"'" + DateUtil.getCompleteDateRepresentation(SL_DateReq) + "'," +
			"'" + Converter.fixString(SL_Operation) + "'," +
			"'" + Converter.fixString(SL_NextOperation) + "')";
		
		dataBaseAccess.executeUpdate(sql);
		this.setSL_ID(dataBaseAccess.getLastId());
		
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
		string sql = "update schlog set " +
			"SL_Db = '" + Converter.fixString(SL_Db) + "', " +
			"SL_JobcardID = '" + Converter.fixString(SL_JobcardID) + "', " +
			"SL_Company = '" + Converter.fixString(SL_Company) + "', " +
			"SL_Plant = '" + Converter.fixString(SL_Plant) + "', " +
			"SL_Department = '" + Converter.fixString(SL_Department) + "', " +
			"SL_Machine = '" + Converter.fixString(SL_Machine) + "', " +
			"SL_Part = '" + Converter.fixString(SL_Part) + "', " +
			"SL_Description = '" + Converter.fixString(SL_Description) + "', " +
			"SL_Part2 = '" + Converter.fixString(SL_Part2) + "', " +
			"SL_Description2 = '" + Converter.fixString(SL_Description2) + "', " +
			"SL_Part3 = '" + Converter.fixString(SL_Part3) + "', " +
			"SL_Description3 = '" + Converter.fixString(SL_Description3) + "', " +
			"SL_Part4 = '" + Converter.fixString(SL_Part4) + "', " +
			"SL_Description4 = '" + Converter.fixString(SL_Description4) + "', " +
			"SL_Family = '" + Converter.fixString(SL_Family) + "', " +
			"SL_FamilyDescription = '" + Converter.fixString(SL_FamilyDescription) + "', " +
			"SL_RunQty = " + NumberUtil.toString(SL_RunQty) + ", " +
			"SL_UOM = '" + Converter.fixString(SL_UOM) + "', " +
			"SL_RunStandard = " + NumberUtil.toString(SL_RunStandard) + ", " +
			"SL_MachineHrs = " + NumberUtil.toString(SL_MachineHrs) + ", " +
			"SL_MainTool = '" + Converter.fixString(SL_MainTool) + "', " +
			"SL_QtyPerTool = " + NumberUtil.toString(SL_QtyPerTool) + ", " +
			"SL_MainMaterial = '" + Converter.fixString(SL_MainMaterial) + "', " +
			"SL_QtyPer = " + NumberUtil.toString(SL_QtyPer) + ", " +
			"SL_MaterialReq = " + NumberUtil.toString(SL_MaterialReq) + ", " +
			"SL_Status = '" + Converter.fixString(SL_Status) + "', " +
			"SL_DateReq = '" + DateUtil.getCompleteDateRepresentation(SL_DateReq) + "', " +
			"SL_Operation = '" + Converter.fixString(SL_Operation) + "', " +
			"SL_NextOperation = '" + Converter.fixString(SL_NextOperation) + "' " +

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
		string sql = "delete from schlog where " + getWhereCondition();
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
		"SL_Db = '" + Converter.fixString(SL_Db) + "' and " +
		"SL_JobcardID = '" + Converter.fixString(SL_JobcardID) + "' and " +
		"SL_Company = '" + Converter.fixString(SL_Company) + "' and " +
		"SL_Plant = '" + Converter.fixString(SL_Plant) + "'";
	return sqlWhere;
}

public
void setSL_ID(int SL_ID){
	this.SL_ID = SL_ID;
}

public
void setSL_Db(string SL_Db){
	this.SL_Db = SL_Db;
}

public
void setSL_JobcardID(string SL_JobcardID){
	this.SL_JobcardID = SL_JobcardID;
}

public
void setSL_Company(string SL_Company){
	this.SL_Company = SL_Company;
}

public
void setSL_Plant(string SL_Plant){
	this.SL_Plant = SL_Plant;
}

public
void setSL_Department(string SL_Department){
	this.SL_Department = SL_Department;
}

public
void setSL_Machine(string SL_Machine){
	this.SL_Machine = SL_Machine;
}

public
void setSL_Part(string SL_Part){
	this.SL_Part = SL_Part;
}

public
void setSL_Description(string SL_Description){
	this.SL_Description = SL_Description;
}

public
void setSL_Part2(string SL_Part2){
	this.SL_Part2 = SL_Part2;
}

public
void setSL_Description2(string SL_Description2){
	this.SL_Description2 = SL_Description2;
}

public
void setSL_Part3(string SL_Part3){
	this.SL_Part3 = SL_Part3;
}

public
void setSL_Description3(string SL_Description3){
	this.SL_Description3 = SL_Description3;
}

public
void setSL_Part4(string SL_Part4){
	this.SL_Part4 = SL_Part4;
}

public
void setSL_Description4(string SL_Description4){
	this.SL_Description4 = SL_Description4;
}

public
void setSL_Family(string SL_Family){
	this.SL_Family = SL_Family;
}

public
void setSL_FamilyDescription(string SL_FamilyDescription){
	this.SL_FamilyDescription = SL_FamilyDescription;
}

public
void setSL_RunQty(decimal SL_RunQty){
	this.SL_RunQty = SL_RunQty;
}

public
void setSL_UOM(string SL_UOM){
	this.SL_UOM = SL_UOM;
}

public
void setSL_RunStandard(decimal SL_RunStandard){
	this.SL_RunStandard = SL_RunStandard;
}

public
void setSL_MachineHrs(decimal SL_MachineHrs){
	this.SL_MachineHrs = SL_MachineHrs;
}

public
void setSL_MainTool(string SL_MainTool){
	this.SL_MainTool = SL_MainTool;
}

public
void setSL_QtyPerTool(decimal SL_QtyPerTool){
	this.SL_QtyPerTool = SL_QtyPerTool;
}

public
void setSL_MainMaterial(string SL_MainMaterial){
	this.SL_MainMaterial = SL_MainMaterial;
}

public
void setSL_QtyPer(decimal SL_QtyPer){
	this.SL_QtyPer = SL_QtyPer;
}

public
void setSL_MaterialReq(decimal SL_MaterialReq){
	this.SL_MaterialReq = SL_MaterialReq;
}

public
void setSL_Status(string SL_Status){
	this.SL_Status = SL_Status;
}

public
void setSL_DateReq(DateTime SL_DateReq){
	this.SL_DateReq = SL_DateReq;
}

public
void setSL_Operation(string SL_Operation){
	this.SL_Operation = SL_Operation;
}

public
void setSL_NextOperation(string SL_NextOperation){
	this.SL_NextOperation = SL_NextOperation;
}

public
int getSL_ID(){
	return SL_ID;
}

public
string getSL_Db(){
	return SL_Db;
}

public
string getSL_JobcardID(){
	return SL_JobcardID;
}

public
string getSL_Company(){
	return SL_Company;
}

public
string getSL_Plant(){
	return SL_Plant;
}

public
string getSL_Department(){
	return SL_Department;
}

public
string getSL_Machine(){
	return SL_Machine;
}

public
string getSL_Part(){
	return SL_Part;
}

public
string getSL_Description(){
	return SL_Description;
}

public
string getSL_Part2(){
	return SL_Part2;
}

public
string getSL_Description2(){
	return SL_Description2;
}

public
string getSL_Part3(){
	return SL_Part3;
}

public
string getSL_Description3(){
	return SL_Description3;
}

public
string getSL_Part4(){
	return SL_Part4;
}

public
string getSL_Description4(){
	return SL_Description4;
}

public
string getSL_Family(){
	return SL_Family;
}

public
string getSL_FamilyDescription(){
	return SL_FamilyDescription;
}

public
decimal getSL_RunQty(){
	return SL_RunQty;
}

public
string getSL_UOM(){
	return SL_UOM;
}

public
decimal getSL_RunStandard(){
	return SL_RunStandard;
}

public
decimal getSL_MachineHrs(){
	return SL_MachineHrs;
}

public
string getSL_MainTool(){
	return SL_MainTool;
}

public
decimal getSL_QtyPerTool(){
	return SL_QtyPerTool;
}

public
string getSL_MainMaterial(){
	return SL_MainMaterial;
}

public
decimal getSL_QtyPer(){
	return SL_QtyPer;
}

public
decimal getSL_MaterialReq(){
	return SL_MaterialReq;
}

public
string getSL_Status(){
	return SL_Status;
}

public
DateTime getSL_DateReq(){
	return SL_DateReq;
}

public
string getSL_Operation(){
	return SL_Operation;
}

public
string getSL_NextOperation(){
	return SL_NextOperation;
}

} // class
} // package