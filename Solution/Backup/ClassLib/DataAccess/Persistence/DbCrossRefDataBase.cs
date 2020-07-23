using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class DbCrossRefDataBase : GenericDataBaseElement{

private string ST_Customer;
private string ST_IPAddress;
private string ST_ServerName;
private string ST_ServerType;
private string ST_Db;

public 
DbCrossRefDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.ST_Customer = reader.GetString("ST_Customer");
	this.ST_IPAddress = reader.GetString("ST_IPAddress");
	this.ST_ServerName = reader.GetString("ST_ServerName");
	this.ST_ServerType = reader.GetString("ST_ServerType");
	this.ST_Db = reader.GetString("ST_Db");
}

public
void loadDB(NotNullDataReader reader){
	this.ST_Db = reader.GetString("ST_Db");
}

public
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from dbcrossref " +
					 "where " +
						"ST_IPAddress = '" +Converter.fixString(ST_IPAddress) +"' and " +
						"ST_Db = '" + Converter.fixString(ST_Db) +"' and " +
						"ST_Customer = '" + Converter.fixString(ST_Customer) + "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public override
void delete(){
	try{
		string sql = "delete from dbcrossref " +
					 "where " +
						"ST_IPAddress = '" +Converter.fixString(ST_IPAddress) +"' and " +
						"ST_Db = '" + Converter.fixString(ST_Db) +"' and " +
						"ST_Customer = '" + Converter.fixString(ST_Customer) + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete>: " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete>: " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void update(){
	try{
		string sql = "update dbcrossref  set " +
					"ST_ServerName = '" + Converter.fixString(ST_ServerName) + "', " +
					"ST_ServerType = '" + Converter.fixString(ST_ServerType) + "', " +
					 "where " +
						"ST_IPAddress = '" +Converter.fixString(ST_IPAddress) +"' and " +
						"ST_Db = '" + Converter.fixString(ST_Db) +"' and " +
						"ST_Customer = '" + Converter.fixString(ST_Customer) + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update>: " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update>: " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void write(){
	try{
		string sql = "insert into dbcrossref values('" + 
			Converter.fixString(ST_Customer) + "', '" +
			Converter.fixString(ST_IPAddress) + "', '" +
			Converter.fixString(ST_ServerName) + "', '" +
			Converter.fixString(ST_ServerType) + "', '" +
			Converter.fixString(ST_Db) + "')";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
	
}


//Setters
public 
void setST_Customer(string ST_Customer){
   this.ST_Customer = ST_Customer;
}

public 
void setST_IPAddress(string ST_IPAddress){
   this.ST_IPAddress = ST_IPAddress;
}

public 
void setST_ServerName(string ST_ServerName){
   this.ST_ServerName = ST_ServerName;
}

public 
void setST_ServerType(string ST_ServerType){
   this.ST_ServerType = ST_ServerType;
}

public 
void setST_Db(string ST_Db){
   this.ST_Db = ST_Db;
}


//Getters
public
string getST_Customer(){
   return ST_Customer;
}


public
string getST_IPAddress(){
   return ST_IPAddress;
}

public
string getST_ServerName(){
   return ST_ServerName;
}

public
string getST_ServerType(){
   return ST_ServerType;
}

public
string getST_Db(){
   return ST_Db;
}

}//end class

}//end namespace
