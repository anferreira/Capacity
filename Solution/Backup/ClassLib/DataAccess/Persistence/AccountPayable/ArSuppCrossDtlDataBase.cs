using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class ArSuppCrossDtlDataBase : GenericDataBaseElement{

private int	ID;
private string SCD_Db;
private string SCD_TradingPartner;
private string SCD_Company;
private string SCD_Plant;
private string SCD_CustBillTo;
private string SCD_CustPlant;
private string SCD_CustPart;
private string SCD_SupplierNum;

public 
ArSuppCrossDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void load(NotNullDataReader reader){
	this.ID = reader.GetInt32("ID");
	this.SCD_Db = reader.GetString("SCD_Db");
	this.SCD_TradingPartner = reader.GetString("SCD_TradingPartner");
	this.SCD_Company = reader.GetString("SCD_Company");
	this.SCD_Plant = reader.GetString("SCD_Plant");
	this.SCD_CustBillTo = reader.GetString("SCD_CustBillTo");
	this.SCD_CustPlant = reader.GetString("SCD_CustPlant");
	this.SCD_CustPart = reader.GetString("SCD_CustPart");
	this.SCD_SupplierNum = reader.GetString("SCD_SupplierNum");
}

public 
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from arsuppcrossdtl where " +
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

public override 
void write(){
	try{
		string sql = "insert into arsuppcrossdtl " +
		                    "(SCD_Db,SCD_TradingPartner,SCD_Company,SCD_Plant,SCD_CustBillTo," +
		                    " SCD_CustPlant,SCD_CustPart,SCD_SupplierNum)" +
    	            "values('" + 
					    Converter.fixString(SCD_Db) +"', '" + 
					    Converter.fixString(SCD_TradingPartner) +"', '" + 
					    Converter.fixString(SCD_Company) +"', '" + 
					    Converter.fixString(SCD_Plant) +"', '" + 
					    Converter.fixString(SCD_CustBillTo) +"', '" + 
					    Converter.fixString(SCD_CustPlant) +"', '" + 
					    Converter.fixString(SCD_CustPart) +"','" + 
					    Converter.fixString(SCD_SupplierNum)+"')"; 							
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
		string sql = "update arsuppcrossdtl set " +		 
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
		string sql = "delete from arsuppcrossdtl where " +
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

//Getters
public
int	getID(){
   return ID;
}

public
string getSCD_Db(){
   return SCD_Db;
}

public
string getSCD_TradingPartner(){
   return SCD_TradingPartner;
}

public
string getSCD_Company(){
   return SCD_Company;
}

public
string getSCD_Plant(){
   return SCD_Plant;
}

public
string getSCD_CustBillTo(){
   return SCD_CustBillTo;
}

public
string getSCD_CustPlant(){
   return SCD_CustPlant;
}

public
string getSCD_CustPart(){
   return SCD_CustPart;
}

public
string getSCD_SupplierNum(){
   return SCD_SupplierNum;
}

//Setters
public 
void setID(int	ID){
   this.ID = ID;
}

public 
void setSCD_Db(string SCD_Db){
   this.SCD_Db = SCD_Db;
}

public 
void setSCD_TradingPartner(string SCD_TradingPartner){
   this.SCD_TradingPartner = SCD_TradingPartner;
}

public 
void setSCD_Company(string SCD_Company){
   this.SCD_Company = SCD_Company;
}

public 
void setSCD_Plant(string SCD_Plant){
   this.SCD_Plant = SCD_Plant;
}

public 
void setSCD_CustBillTo(string SCD_CustBillTo){
   this.SCD_CustBillTo = SCD_CustBillTo;
}

public 
void setSCD_CustPlant(string SCD_CustPlant){
   this.SCD_CustPlant = SCD_CustPlant;
}

public 
void setSCD_CustPart(string SCD_CustPart){
   this.SCD_CustPart = SCD_CustPart;
}

public 
void setSCD_SupplierNum(string SCD_SupplierNum){
   this.SCD_SupplierNum = SCD_SupplierNum;
}

}//end class

}//end namespace
