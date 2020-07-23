using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class ArInvoiceClassDataBase : GenericDataBaseElement{

private string ARC_InvClass;
private string ARC_Desc;

public 
ArInvoiceClassDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){

	this.ARC_InvClass = reader.GetString("ARC_InvClass");
	this.ARC_Desc = reader.GetString("ARC_Desc");
}

public override
void write(){
	try{
		string sql = "insert into arinvoiceclass (ARC_InvClass, ARC_Desc) " +
                      "values('" +
				                Converter.fixString(ARC_InvClass) + "', " + 
				                Converter.fixString(ARC_Desc) + "')";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message,mySqlExc);
	}
}

public override
void update(){
	try{
		string sql ="update arinvoiceclass set " +
					"ARC_Desc = '" + Converter.fixString(ARC_Desc) + "' " +
					"where ARC_InvClass ='" + Converter.fixString(ARC_InvClass) + "'";
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
		string sql = "delete from arinvoiceclass " +
			"where ARC_InvClass ='" + Converter.fixString(ARC_InvClass) + "'";
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
    NotNullDataReader reader = null;
	try{
		string sql = "select * from arinvoiceclass " + 
			"where ARC_InvClass ='" + Converter.fixString(ARC_InvClass) + "'";

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
public 
void setARC_InvClass(string ARC_InvClass){
   this.ARC_InvClass = ARC_InvClass;
}

public 
void setARC_Desc(string ARC_Desc){
   this.ARC_Desc = ARC_Desc;
}


//Getters
public
string getARC_InvClass(){
   return ARC_InvClass;
}

public
string getARC_Desc(){
   return ARC_Desc;
}

}//end class

}//end namespace
