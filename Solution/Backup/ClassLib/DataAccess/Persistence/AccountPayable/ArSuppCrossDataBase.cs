using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public
class ArSuppCrossDataBase : GenericDataBaseElement{

private int ID;
private string SC_Db;
private string SC_TradingPartner;
private string SC_Company;
private string SC_Plant;
private string SC_CustBillTo;
private string SC_CustPlant;
private string SC_SupplierNum;


public 
ArSuppCrossDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void load(NotNullDataReader reader){
	this.ID = reader.GetInt32("ID");
	this.SC_Db = reader.GetString("SC_Db");
	this.SC_TradingPartner = reader.GetString("SC_TradingPartner");
	this.SC_Company = reader.GetString("SC_Company");
	this.SC_Plant = reader.GetString("SC_Plant");
	this.SC_CustBillTo = reader.GetString("SC_CustBillTo");
	this.SC_CustPlant = reader.GetString("SC_CustPlant");
	this.SC_SupplierNum = reader.GetString("SC_SupplierNum");
}

public 
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from arsuppcross where " +
			"ID = " + NumberUtil.toString(ID);

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

public
void readByTPartnerSuppNum(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from arsuppcross " +
		             "where SC_TradingPartner = '" + Converter.fixString(SC_TradingPartner)+"' and " +
		                   "SC_SupplierNum = '" + Converter.fixString(SC_SupplierNum) +"'";

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
		    load(reader);
		
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByTPartnerSuppNum> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByTPartnerSuppNum> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByTPartnerSuppNum> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public override 
void write(){
	try{
		string sql = "insert into arsuppcross " +
    		                    "(SC_Db,SC_TradingPartner,SC_Company,SC_Plant," +
    		                    " SC_CustBillTo,SC_CustPlant,SC_SupplierNum)"+
		            "values('" + 
						Converter.fixString(SC_Db) +"', '" + 
						Converter.fixString(SC_TradingPartner) +"', '" + 
						Converter.fixString(SC_Company) +"', '" + 
						Converter.fixString(SC_Plant) +"', '" + 
						Converter.fixString(SC_CustBillTo) +"', '" + 
						Converter.fixString(SC_CustPlant) +"', '" + 
						Converter.fixString(SC_SupplierNum) +"'"; 
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
		string sql = "update arsuppcross set " +
						"SC_Db = '" + Converter.fixString(SC_Db) + "', '" +
						"SC_TradingPartner = '" + Converter.fixString(SC_TradingPartner) + "', '" +
						"SC_Company = '" + Converter.fixString(SC_Company) + "', '" +
						"SC_Plant = '" + Converter.fixString(SC_Plant) + "', '" +
						"SC_CustBillTo = '" + Converter.fixString(SC_CustBillTo) + "', '" +
						"SC_CustPlant = '" + Converter.fixString(SC_CustPlant) + "', '" +
						"SC_SupplierNum = '" + Converter.fixString(SC_SupplierNum) + "' " + 
					"where " +  
						"ID = " + NumberUtil.toString(ID);
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
		string sql = "delete from arsuppcross where " +
						"ID = " + NumberUtil.toString(ID);
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message,mySqlExc);
	}
}


//Setters
public 
void setID(int ID){
   this.ID = ID;
}

public 
void setSC_Db(string SC_Db){
   this.SC_Db = SC_Db;
}

public 
void setSC_TradingPartner(string SC_TradingPartner){
   this.SC_TradingPartner = SC_TradingPartner;
}

public 
void setSC_Company(string SC_Company){
   this.SC_Company = SC_Company;
}

public 
void setSC_Plant(string SC_Plant){
   this.SC_Plant = SC_Plant;
}

public 
void setSC_CustBillTo(string SC_CustBillTo){
   this.SC_CustBillTo = SC_CustBillTo;
}

public 
void setSC_CustPlant(string SC_CustPlant){
   this.SC_CustPlant = SC_CustPlant;
}

public 
void setSC_SupplierNum(string SC_SupplierNum){
   this.SC_SupplierNum = SC_SupplierNum;
}


//Getters
public
int getID(){
   return ID;
}

public
string getSC_Db(){
   return SC_Db;
}

public
string getSC_TradingPartner(){
   return SC_TradingPartner;
}

public
string getSC_Company(){
   return SC_Company;
}

public
string getSC_Plant(){
   return SC_Plant;
}

public
string getSC_CustBillTo(){
   return SC_CustBillTo;
}

public
string getSC_CustPlant(){
   return SC_CustPlant;
}

public
string getSC_SupplierNum(){
   return SC_SupplierNum;
}

}//end Class

}//endnamespace
