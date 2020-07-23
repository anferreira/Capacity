using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class OePSKanBansDataBase: GenericDataBaseElement	{

private int PSK_ID;
private string PSK_Database;
private int PSK_Company;
private string PSK_Plant;
private int PSK_PackSlipNum;
private int PSK_PSLineNum;
private int PSK_PSDetailNum;
private string PSK_KanbanNum;
private decimal PSK_KanbanQty;
private string PSK_ShipRef;
private string PSK_KanbanPrefix;
private string PSK_KanbanSuffix;
private decimal PSK_KanbanBase;


public 
OePSKanBansDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.PSK_ID = reader.GetInt32("PSK_ID");
	this.PSK_Database = reader.GetString("PSK_Database");
	this.PSK_Company = reader.GetInt32("PSK_Company");
	this.PSK_Plant = reader.GetString("PSK_Plant");
	this.PSK_PackSlipNum = reader.GetInt32("PSK_PackSlipNum");
	this.PSK_PSLineNum = reader.GetInt32("PSK_PSLineNum");
	this.PSK_PSDetailNum = reader.GetInt32("PSK_PSDetailNum");
	this.PSK_KanbanNum = reader.GetString("PSK_KanbanNum");
	this.PSK_KanbanQty = reader.GetDecimal("PSK_KanbanQty");
	this.PSK_ShipRef = reader.GetString("PSK_ShipRef");
	this.PSK_KanbanPrefix = reader.GetString("PSK_KanbanPrefix");
	this.PSK_KanbanSuffix = reader.GetString("PSK_KanbanSuffix");
	this.PSK_KanbanBase = reader.GetDecimal("PSK_KanbanBase");
}

public override
void write(){

	string sql = "insert into oepskanbans " +
		            "(PSK_Database,PSK_Company,PSK_Plant,PSK_PackSlipNum,"+
		            " PSK_PSLineNum,PSK_PSDetailNum,PSK_KanbanNum, "+
		            " PSK_KanbanQty,PSK_ShipRef,PSK_KanbanPrefix,PSK_KanbanSuffix,PSK_KanbanBase)" +
		    "values('" +
				    Converter.fixString(PSK_Database) + "', " +
				    NumberUtil.toString(PSK_Company) + ", '" +
				    Converter.fixString(PSK_Plant) + "', " +
				    NumberUtil.toString(PSK_PackSlipNum) + ", " +
				    NumberUtil.toString(PSK_PSLineNum) + ", " +
				    NumberUtil.toString(PSK_PSDetailNum) + ", '" +
				    Converter.fixString(PSK_KanbanNum) + "', " +
				    NumberUtil.toString(PSK_KanbanQty) + ", '" +
				    Converter.fixString(PSK_ShipRef) + "', '" +
				    Converter.fixString(PSK_KanbanPrefix) + "', '" +
				    Converter.fixString(PSK_KanbanSuffix) + "', " +
				    NumberUtil.toString(PSK_KanbanBase)+")";
		
	write(sql);

}

public override
void update(){
	string sql = "update oepskanbans " +
		  		    "PSK_Database = '" + Converter.fixString(PSK_Database) + "', " +
				    "PSK_Company = " + NumberUtil.toString(PSK_Company) + ", " +
				    "PSK_Plant = ' " + Converter.fixString(PSK_Plant) + "', " +
				    "PSK_PackSlipNum = '" + NumberUtil.toString(PSK_PackSlipNum) + ", " +
				    "PSK_PSLineNum = '" + NumberUtil.toString(PSK_PSLineNum) + ", " +
				    "PSK_PSDetailNum = '" + NumberUtil.toString(PSK_PSDetailNum) + ", " +
				    "PSK_KanbanNum = '" + Converter.fixString(PSK_KanbanNum) + "', " +
				    "PSK_KanbanQty = '" + NumberUtil.toString(PSK_KanbanQty) + ", " +
				    "PSK_ShipRef = '" + Converter.fixString(PSK_ShipRef) + "', " +
				    "PSK_KanbanPrefix = '" + Converter.fixString(PSK_KanbanPrefix) + "', " +
				    "PSK_KanbanSuffix = '" + Converter.fixString(PSK_KanbanSuffix) + "', " +
				    "PSK_KanbanBase = " + NumberUtil.toString(PSK_KanbanBase)+")";
    update(sql);
}

public override
void delete(){

	string sql = "delete from oepskanbans where " +
		"PSK_ID = " + NumberUtil.toString(PSK_ID);	
	delete(sql);
	
}

public
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from oepskanbans where " + 
			"PSK_ID = " + NumberUtil.toString(PSK_ID);
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
void setPSK_ID(int PSK_ID){
   this.PSK_ID = PSK_ID;
}

public 
void setPSK_Database(string PSK_Database){
   this.PSK_Database = PSK_Database;
}

public 
void setPSK_Company(int PSK_Company){
   this.PSK_Company = PSK_Company;
}

public 
void setPSK_Plant(string PSK_Plant){
   this.PSK_Plant = PSK_Plant;
}

public 
void setPSK_PackSlipNum(int PSK_PackSlipNum){
   this.PSK_PackSlipNum = PSK_PackSlipNum;
}

public 
void setPSK_PSLineNum(int PSK_PSLineNum){
   this.PSK_PSLineNum = PSK_PSLineNum;
}

public 
void setPSK_PSDetailNum(int PSK_PSDetailNum){
   this.PSK_PSDetailNum = PSK_PSDetailNum;
}

public 
void setPSK_KanbanNum(string PSK_KanbanNum){
   this.PSK_KanbanNum = PSK_KanbanNum;
}

public 
void setPSK_KanbanQty(decimal PSK_KanbanQty){
   this.PSK_KanbanQty = PSK_KanbanQty;
}

public 
void setPSK_ShipRef(string PSK_ShipRef){
   this.PSK_ShipRef = PSK_ShipRef;
}

public 
void setPSK_KanbanPrefix(string PSK_KanbanPrefix){
   this.PSK_KanbanPrefix = PSK_KanbanPrefix;
}

public 
void setPSK_KanbanSuffix(string PSK_KanbanSuffix){
   this.PSK_KanbanSuffix = PSK_KanbanSuffix;
}

public 
void setPSK_KanbanBase(decimal PSK_KanbanBase){
   this.PSK_KanbanBase = PSK_KanbanBase;
}


//Getters
public
int getPSK_ID(){
   return PSK_ID;
}

public
string getPSK_Database(){
   return PSK_Database;
}

public
int getPSK_Company(){
   return PSK_Company;
}

public
string getPSK_Plant(){
   return PSK_Plant;
}

public
int getPSK_PackSlipNum(){
   return PSK_PackSlipNum;
}

public
int getPSK_PSLineNum(){
   return PSK_PSLineNum;
}

public
int getPSK_PSDetailNum(){
   return PSK_PSDetailNum;
}

public
string getPSK_KanbanNum(){
   return PSK_KanbanNum;
}

public
decimal getPSK_KanbanQty(){
   return PSK_KanbanQty;
}

public
string getPSK_ShipRef(){
   return PSK_ShipRef;
}

public
string getPSK_KanbanPrefix(){
   return PSK_KanbanPrefix;
}

public
string getPSK_KanbanSuffix(){
   return PSK_KanbanSuffix;
}

public
decimal getPSK_KanbanBase(){
   return PSK_KanbanBase;
}

}//end class

}//end namespace
