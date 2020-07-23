using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ObjectDtlDataBase : GenericDataBaseElement{

private int OBD_ID;
private string OBD_ObjName;
private string OBD_Department;
private int OBD_ObjLineNum;
private string OBD_Objective;
private string OBD_Desciption;
private decimal OBD_DefDaysReq;
private decimal OBD_DefHoursReq;
private string OBD_DefEventToTrigger;

public 
ObjectDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from objectdtl where OBD_ID = " + NumberUtil.toString(OBD_ID);
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
		bool returnValue = false;
		string sql = "select * from objectdtl where OBD_ID = " + NumberUtil.toString(OBD_ID);
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;

		return returnValue;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public 
void load(NotNullDataReader reader){
	this.OBD_ID = reader.GetInt32("OBD_ID");
	this.OBD_ObjName = reader.GetString("OBD_ObjName");
	this.OBD_Department = reader.GetString("OBD_Department");
	this.OBD_ObjLineNum = reader.GetInt32("OBD_ObjLineNum");
	this.OBD_Objective = reader.GetString("OBD_Objective");
	this.OBD_Desciption = reader.GetString("OBD_Desciption");
	this.OBD_DefDaysReq = reader.GetDecimal("OBD_DefDaysReq");
	this.OBD_DefHoursReq = reader.GetDecimal("OBD_DefHoursReq");
	this.OBD_DefEventToTrigger = reader.GetString("OBD_DefEventToTrigger");
}

public override 
void write(){
	try{
		string sql = "insert into objecthdr(" + 
			"OBD_ObjName, " +
			"OBD_Department, " +
			"OBD_ObjLineNum, " +
			"OBD_Objective, " +
			"OBD_Desciption, " +
			"OBD_DefDaysReq, " +
			"OBD_DefHoursReq, " +
			"OBD_DefEventToTrigger " +
		")values('" + 
			Converter.fixString(OBD_ObjName) + "', '" +
			Converter.fixString(OBD_Department) + "', " +
			NumberUtil.toString(OBD_ObjLineNum) + ", '" +
			Converter.fixString(OBD_Objective) + "', '" +
			Converter.fixString(OBD_Desciption) + "', " +
			NumberUtil.toString(OBD_DefDaysReq) + ", " +
			NumberUtil.toString(OBD_DefHoursReq) + ", '" +
			Converter.fixString(OBD_DefEventToTrigger) + "')";
		dataBaseAccess.executeUpdate(sql);
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
		string sql = "update objectdtl set " +
			"OBD_ObjName = '" + Converter.fixString(OBD_ObjName) + "', " +
			"OBD_Department = '" + Converter.fixString(OBD_Department) + "', " +
			"OBD_ObjLineNum = " + NumberUtil.toString(OBD_ObjLineNum) + ", " +
			"OBD_Objective = '" + Converter.fixString(OBD_Objective) + "', " +
			"OBD_Desciption = '" + Converter.fixString(OBD_Desciption) + "', " +
			"OBD_DefDaysReq = " + NumberUtil.toString(OBD_DefDaysReq) + ", " +
			"OBD_DefHoursReq = " + NumberUtil.toString(OBD_DefHoursReq) + ", " +
			"OBD_DefEventToTrigger = '" + Converter.fixString(OBD_DefEventToTrigger) + "' " +
		"where " +
			"OBD_ID = '" + NumberUtil.toString(OBD_ID) + "'";

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
		string sql = "delete from objectdtl where OBD_ID = " + NumberUtil.toString(OBD_ID);
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
void setOBD_ID(int OBD_ID){
	this.OBD_ID = OBD_ID;
}

public
void setOBD_ObjName(string OBD_ObjName){
	this.OBD_ObjName = OBD_ObjName;
}

public
void setOBD_Department(string OBD_Department){
	this.OBD_Department = OBD_Department;
}

public
void setOBD_ObjLineNum(int OBD_ObjLineNum){
	this.OBD_ObjLineNum = OBD_ObjLineNum;
}

public
void setOBD_Objective(string OBD_Objective){
	this.OBD_Objective = OBD_Objective;
}

public
void setOBD_Desciption(string OBD_Desciption){
	this.OBD_Desciption = OBD_Desciption;
}

public
void setOBD_DefDaysReq(decimal OBD_DefDaysReq){
	this.OBD_DefDaysReq = OBD_DefDaysReq;
}

public
void setOBD_DefHoursReq(decimal OBD_DefHoursReq){
	this.OBD_DefHoursReq = OBD_DefHoursReq;
}

public
void setOBD_DefEventToTrigger(string OBD_DefEventToTrigger){
	this.OBD_DefEventToTrigger = OBD_DefEventToTrigger;
}


public
int getOBD_ID(){
	return OBD_ID;
}

public
string getOBD_ObjName(){
	return OBD_ObjName;
}

public
string getOBD_Department(){
	return OBD_Department;
}

public
int getOBD_ObjLineNum(){
	return OBD_ObjLineNum;
}

public
string getOBD_Objective(){
	return OBD_Objective;
}

public
string getOBD_Desciption(){
	return OBD_Desciption;
}

public
decimal getOBD_DefDaysReq(){
	return OBD_DefDaysReq;
}

public
decimal getOBD_DefHoursReq(){
	return OBD_DefHoursReq;
}

public
string getOBD_DefEventToTrigger(){
	return OBD_DefEventToTrigger;
}

} // class

} // namespace
