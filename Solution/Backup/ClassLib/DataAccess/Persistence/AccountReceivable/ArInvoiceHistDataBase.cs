using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
	
public class ArInvoiceHistDataBase	: GenericDataBaseElement{

private string ARIH_Db;
private string ARIH_InvoiceNum;
private string ARIH_InvoiceType;

public ArInvoiceHistDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}

public
void load(NotNullDataReader reader){
	this.ARIH_Db = reader.GetString("ARIH_Db");
	this.ARIH_InvoiceNum = reader.GetString("ARIH_InvoiceNum");
	this.ARIH_InvoiceType = reader.GetString("ARIH_InvoiceType");
}

public override
void write(){

	try{
		string sql = "insert into arinvoicehist values('" +
			Converter.fixString(ARIH_Db) + "', '" +
			Converter.fixString(ARIH_InvoiceNum) + "', '" +
			Converter.fixString(ARIH_InvoiceType) + "')";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + se.Message);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + de.Message);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message);
	}
}

public override
void update(){
	try{
		string sql = "update arinvoicehist set " +
			"ARIH_InvoiceType = '" + Converter.fixString(ARIH_InvoiceType) + "'" +
			"where " + 
				"ARIH_Db = '" + Converter.fixString(ARIH_Db) + "' and " +
				"ARIH_InvoiceNum = '" + Converter.fixString(ARIH_InvoiceNum) + "'";
				
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message,mySqlExc);
	}
}


public override
void delete(){

	try{
		string sql = "delete from arinvoicehist where " +
			"ARIH_Db = '" + Converter.fixString(ARIH_Db) + "' and " +
			"ARIH_InvoiceNum = '" + Converter.fixString(ARIH_InvoiceNum) + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message,mySqlExc);
	}
}

public
void read(){
    NotNullDataReader reader =null;
	try{
		string sql = "select * from arinvoicehist where " + 
			"ARIH_Db = '" + Converter.fixString(ARIH_Db) + "' and " +
			"ARIH_InvoiceNum = '" + Converter.fixString(ARIH_InvoiceNum) + "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

//Setters
public void setARIH_Db(string ARIH_Db){
   this.ARIH_Db = ARIH_Db;
}

public void setARIH_InvoiceNum(string ARIH_InvoiceNum){
   this.ARIH_InvoiceNum = ARIH_InvoiceNum;
}

public void setARIH_InvoiceType(string ARIH_InvoiceType){
   this.ARIH_InvoiceType = ARIH_InvoiceType;
}


//Getters
public
string getARIH_Db(){
   return ARIH_Db;
}

public
string getARIH_InvoiceNum(){
   return ARIH_InvoiceNum;
}

public
string getARIH_InvoiceType(){
   return ARIH_InvoiceType;
}


}//end class
}//end namespace
