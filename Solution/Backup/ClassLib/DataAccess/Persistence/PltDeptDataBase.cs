using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class PltDeptDataBase : GenericDataBaseElement{

private string DE_Db;
private int DE_Company;
private string DE_Plt;
private string DE_Dept;
private string DE_Des1;
private decimal DE_UtilPer;
private string DE_DeptShort;

public
PltDeptDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.DE_Db = reader.GetString("DE_Db");
	this.DE_Company = reader.GetInt32("DE_Company");
	this.DE_Plt = reader.GetString("DE_Plt");
	this.DE_Dept = reader.GetString("DE_Dept");
	this.DE_Des1 = reader.GetString("DE_Des1");
	this.DE_UtilPer = reader.GetDecimal("DE_UtilPer");
	this.DE_DeptShort = reader.GetString("DE_DeptShort");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pltdept where " + 
			"DE_Plt = '" + DE_Plt + "' and " +
			"DE_Dept = '" + DE_Dept + "'";

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
void readByDept(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pltdept where " + 
			"DE_Dept = '" + DE_Dept + "'";

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDept> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDept> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByDept> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
bool existsByDept(){
	NotNullDataReader reader = null;
	try{
		bool returnValue = false;
		
		string sql = "select * from pltdept where " + 
			"DE_Dept = '" + DE_Dept + "'";

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnValue = true;
		
		return returnValue;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsByDept> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsByDept> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsByDept> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public override
void delete(){
	try{
		string sql = "delete from pltdept where " +
			"DE_Plt = '" + DE_Plt + "' and " +
			"DE_Dept = '" + DE_Dept + "'";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void update(){
	try{
		string sql = "update pltdept set " +
			"DE_Des1 = '" + Converter.fixString(DE_Des1) + "', " +			
			"DE_UtilPer = " + NumberUtil.toString(DE_UtilPer) + ", " +
			"DE_DeptShort = '" + Converter.fixString(DE_DeptShort) + "' " +
		"where " + 
			"DE_Plt = '" + DE_Plt + "' and " +
			"DE_Dept = '" + DE_Dept + "'";
		
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
void write(){
	try{
		string sql = "insert into pltdept values('" + 
			Converter.fixString(DE_Db) + "', " +
			NumberUtil.toString(DE_Company) + ", '" +
			Converter.fixString(DE_Plt) + "', '" +
			Converter.fixString(DE_Dept) + "', '" +
			Converter.fixString(DE_Des1) + "', " +
			NumberUtil.toString(DE_UtilPer) + ", '" +
			Converter.fixString(DE_DeptShort) + "')";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public
bool exists(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from pltdept where " + 
			"DE_Plt = '" + DE_Plt + "' and " +
			"DE_Dept = '" + DE_Dept + "'";

		bool returnType = false;
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			returnType = true;

		return returnType;
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
bool hasDeptsForPlant(){
	NotNullDataReader reader = null;
	try{
		bool returnValue = false;

		string sql = "select count(*) as cantDepts " +
		             "from pltdept where DE_Plt = '" + DE_Plt + "'";
		
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read()){
		    string cantDepts = reader.GetInt32("cantDepts").ToString();
		    if (!cantDepts.Equals("0"))
		        returnValue = true;
        }
		return returnValue;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <hasDeptsForPlant> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <hasDeptsForPlant> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <hasDeptsForPlant> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void setDE_Db(string DE_Db){
	this.DE_Db = DE_Db;
}

public
void setDE_Company(int DE_Company){
	this.DE_Company = DE_Company;
}

public
void setDE_Plt(string DE_Plt){
	this.DE_Plt = DE_Plt;
}

public
void setDE_Dept(string DE_Dept){
	this.DE_Dept = DE_Dept;
}

public
void setDE_Des1(string DE_Des1){
	this.DE_Des1 = DE_Des1;
}

public
void setDE_UtilPer(decimal DE_UtilPer){
	this.DE_UtilPer = DE_UtilPer;
}


public
void setDE_DeptShort(string DE_DeptShort){
	this.DE_DeptShort = DE_DeptShort;
}

public
string getDE_Db(){
	return DE_Db;
}

public
int getDE_Company(){
	return DE_Company;
}

public
string getDE_Plt(){
	return DE_Plt;
}

public
string getDE_Dept(){
	return DE_Dept;
}

public
string getDE_Des1(){
	return DE_Des1;
}

public
decimal getDE_UtilPer(){
	return DE_UtilPer;
}

public
string getDE_DeptShort(){
	return DE_DeptShort;
}

} // class

}
