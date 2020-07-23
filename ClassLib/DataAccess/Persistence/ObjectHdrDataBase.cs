using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ObjectHdrDataBase : GenericDataBaseElement{

private int OBH_ID;
private string OBH_ObjName;
private string OBH_Department;
private string OBH_ObjDesc;

public 
ObjectHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from objecthdr where OBD_ID = " + NumberUtil.toString(OBH_ID);
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
		string sql = "select * from objecthdr where OBD_ID = " + NumberUtil.toString(OBH_ID);
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
	this.OBH_ID = reader.GetInt32("OBH_ID");
	this.OBH_ObjName = reader.GetString("OBH_ObjName");
	this.OBH_Department = reader.GetString("OBH_Department");
	this.OBH_ObjDesc = reader.GetString("OBH_ObjDesc");
}

public override 
void write(){
	try{
		string sql = "insert into objecthdr(OBH_ObjName, OBH_Department, OBH_ObjDesc" +
			")values('" + 
			Converter.fixString(OBH_ObjName) + "', '" +
			Converter.fixString(OBH_Department) + "', '" +
			Converter.fixString(OBH_ObjDesc) + "')";
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
		string sql = "update objecthdr set " +
			"OBH_ObjName = '" + Converter.fixString(OBH_ObjName) + "', '" +
			"OBH_Department = '" + Converter.fixString(OBH_Department) + "', '" +
			"OBH_ObjDesc = '" + Converter.fixString(OBH_ObjDesc) + "' " +
		"where " +
			"OBH_ID = '" + NumberUtil.toString(OBH_ID) + "'";

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
		string sql = "delete from objecthdr where OBD_ID = " + NumberUtil.toString(OBH_ID);
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
void setOBH_ID(int OBH_ID){
	this.OBH_ID = OBH_ID;
}

public
void setOBH_ObjName(string OBH_ObjName){
	this.OBH_ObjName = OBH_ObjName;
}

public
void setOBH_Department(string OBH_Department){
	this.OBH_Department = OBH_Department;
}

public
void setOBH_ObjDesc(string OBH_ObjDesc){
	this.OBH_ObjDesc = OBH_ObjDesc;
}


public
int getOBH_ID(){
	return OBH_ID;
}

public
string getOBH_ObjName(){
	return OBH_ObjName;
}

public
string getOBH_Department(){
	return OBH_Department;
}

public
string getOBH_ObjDesc(){
	return OBH_ObjDesc;
}

} // class

} // namespace
