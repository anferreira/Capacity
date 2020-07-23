using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
	
public class PlantDataBase	: GenericDataBaseElement{

private string PL_Db;
private int PL_Company;
private string PL_Plant;
private string PL_PltName;
private string PL_PltShort;
private DateTime PL_DateUpdated;
private string PL_Address;
private string PL_DftForSalesForecast;
private string PL_Timezone;
private string PL_DftReceivetoStkRoom;
private string PL_Intransit;
private string PL_OutsideServiceStkRoom;
private string PL_ShipFromStkLoc;
private string PL_ProdFulFillmentGrp;
private string PL_DistFulFillmentGrp;
private string PL_WhsStorageGrp;
private string PL_OutsideStorageGrp;

public PlantDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from plant " + 
		             "where " + this.getWhereCondition();
                      		             
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
	
	string sql = "select * from plant " + 
		         "where " + this.getWhereCondition();
    return exists(sql);	
}

public 
void load(NotNullDataReader reader){

    this.PL_Db = reader.GetString("PL_Db");
    this.PL_Company = reader.GetInt32("PL_Company");
    this.PL_Plant = reader.GetString("PL_Plant");
    this.PL_PltName = reader.GetString("PL_PltName");
    this.PL_PltShort = reader.GetString("PL_PltShort");
    this.PL_DateUpdated = reader.GetDateTime("PL_DateUpdated");
    this.PL_Address = reader.GetString("PL_Address");
    this.PL_DftForSalesForecast = reader.GetString("PL_DftForSalesForecast");
    this.PL_Timezone = reader.GetString("PL_Timezone");
    this.PL_DftReceivetoStkRoom = reader.GetString("PL_DftReceivetoStkRoom");
    this.PL_Intransit = reader.GetString("PL_Intransit");
    this.PL_OutsideServiceStkRoom = reader.GetString("PL_OutsideServiceStkRoom");
    this.PL_ShipFromStkLoc = reader.GetString("PL_ShipFromStkLoc");
    this.PL_ProdFulFillmentGrp = reader.GetString("PL_ProdFulFillmentGrp");
    this.PL_DistFulFillmentGrp = reader.GetString("PL_DistFulFillmentGrp");
    this.PL_WhsStorageGrp = reader.GetString("PL_WhsStorageGrp");
    this.PL_OutsideStorageGrp = reader.GetString("PL_OutsideStorageGrp");

}

public override 
void write(){
	
	string sql = "insert into plant values('" + 
                        Converter.fixString(PL_Db) +"', " +
                        NumberUtil.toString(PL_Company) +", '" +
                        Converter.fixString(PL_Plant) +"', '" +
                        Converter.fixString(PL_PltName) +"', '" +
                        Converter.fixString(PL_PltShort) +"', '" +
                        DateUtil.getCompleteDateRepresentation(PL_DateUpdated) +"', '" +
                        Converter.fixString(PL_Address) +"', '" +
                        Converter.fixString(PL_DftForSalesForecast) +"', '" +
                        Converter.fixString(PL_Timezone) +"', '" +
                        Converter.fixString(PL_DftReceivetoStkRoom) +"', '" +
                        Converter.fixString(PL_Intransit) +"', '" +
                        Converter.fixString(PL_OutsideServiceStkRoom) +"', '" +
                        Converter.fixString(PL_ShipFromStkLoc) +"', '" +
                        Converter.fixString(PL_ProdFulFillmentGrp) +"', '" +
                        Converter.fixString(PL_DistFulFillmentGrp) +"', '" +
                        Converter.fixString(PL_WhsStorageGrp) +"', '" +
                        Converter.fixString(PL_OutsideStorageGrp) +"')";

    write(sql);	
}

public override 
void update(){
	
    string sql = "update plant set " +
                    "PL_PltName = '" + Converter.fixString(PL_PltName) +"', " +
                    "PL_PltShort = '" + Converter.fixString(PL_PltShort) +"', " +
                    "PL_DateUpdated = '" + DateUtil.getCompleteDateRepresentation(PL_DateUpdated) +"', " +
                    "PL_Address = '" + Converter.fixString(PL_Address) +"', " +
                    "PL_DftForSalesForecast = '" + Converter.fixString(PL_DftForSalesForecast) +"', " +
                    "PL_Timezone = '" + Converter.fixString(PL_Timezone) +"', " +
                    "PL_DftReceivetoStkRoom = '" + Converter.fixString(PL_DftReceivetoStkRoom) +"', " +
                    "PL_Intransit = '" + Converter.fixString(PL_Intransit) +"', " +
                    "PL_OutsideServiceStkRoom = '" + Converter.fixString(PL_OutsideServiceStkRoom) +"', " +
                    "PL_ShipFromStkLoc = '" + Converter.fixString(PL_ShipFromStkLoc) +"', " +
                    "PL_ProdFulFillmentGrp = '" + Converter.fixString(PL_ProdFulFillmentGrp) +"', " +
                    "PL_DistFulFillmentGrp = '" + Converter.fixString(PL_DistFulFillmentGrp) +"', " +
                    "PL_WhsStorageGrp = '" + Converter.fixString(PL_WhsStorageGrp) +"', " +
                    "PL_OutsideStorageGrp = '" + Converter.fixString(PL_OutsideStorageGrp) +"' " +		
		            "where " + this.getWhereCondition();
    update(sql);    

}

public override 
void delete(){
	
	string sql = "delete from plant " +
		            "where " + this.getWhereCondition();
                        
    delete(sql);                 

}


//Setters

public void setPL_Db (string PL_Db){
    this.PL_Db = PL_Db;
}

public void setPL_Company (int PL_Company){
    this.PL_Company = PL_Company;
}

public void setPL_Plant (string PL_Plant){
    this.PL_Plant = PL_Plant;
}

public void setPL_PltName (string PL_PltName){
    this.PL_PltName = PL_PltName;
}

public void setPL_PltShort (string PL_PltShort){
    this.PL_PltShort = PL_PltShort;
}

public void setPL_DateUpdated (DateTime PL_DateUpdated){
    this.PL_DateUpdated = PL_DateUpdated;
}

public void setPL_Address (string PL_Address){
    this.PL_Address = PL_Address;
}

public void setPL_DftForSalesForecast (string PL_DftForSalesForecast){
    this.PL_DftForSalesForecast = PL_DftForSalesForecast;
}

public void setPL_Timezone (string PL_Timezone){
    this.PL_Timezone = PL_Timezone;
}

public void setPL_DftReceivetoStkRoom (string PL_DftReceivetoStkRoom){
    this.PL_DftReceivetoStkRoom = PL_DftReceivetoStkRoom;
}

public void setPL_Intransit (string PL_Intransit){
    this.PL_Intransit = PL_Intransit;
}

public void setPL_OutsideServiceStkRoom (string PL_OutsideServiceStkRoom){
    this.PL_OutsideServiceStkRoom = PL_OutsideServiceStkRoom;
}

public void setPL_ShipFromStkLoc (string PL_ShipFromStkLoc){
    this.PL_ShipFromStkLoc = PL_ShipFromStkLoc;
}

public void setPL_ProdFulFillmentGrp (string PL_ProdFulFillmentGrp){
    this.PL_ProdFulFillmentGrp = PL_ProdFulFillmentGrp;
}

public void setPL_DistFulFillmentGrp (string PL_DistFulFillmentGrp){
    this.PL_DistFulFillmentGrp = PL_DistFulFillmentGrp;
}

public void setPL_WhsStorageGrp (string PL_WhsStorageGrp){
    this.PL_WhsStorageGrp = PL_WhsStorageGrp;
}

public void setPL_OutsideStorageGrp (string PL_OutsideStorageGrp){
    this.PL_OutsideStorageGrp = PL_OutsideStorageGrp;
}


//Getters

public string getPL_Db(){
    return PL_Db;
}

public int getPL_Company(){
    return PL_Company;
}

public string getPL_Plant(){
    return PL_Plant;
}

public string getPL_PltName(){
    return PL_PltName;
}

public string getPL_PltShort(){
    return PL_PltShort;
}

public DateTime getPL_DateUpdated(){
    return PL_DateUpdated;
}

public string getPL_Address(){
    return PL_Address;
}

public string getPL_DftForSalesForecast(){
    return PL_DftForSalesForecast;
}

public string getPL_Timezone(){
    return PL_Timezone;
}

public string getPL_DftReceivetoStkRoom(){
    return PL_DftReceivetoStkRoom;
}

public string getPL_Intransit(){
    return PL_Intransit;
}

public string getPL_OutsideServiceStkRoom(){
    return PL_OutsideServiceStkRoom;
}

public string getPL_ShipFromStkLoc(){
    return PL_ShipFromStkLoc;
}

public string getPL_ProdFulFillmentGrp(){
    return PL_ProdFulFillmentGrp;
}

public string getPL_DistFulFillmentGrp(){
    return PL_DistFulFillmentGrp;
}

public string getPL_WhsStorageGrp(){
    return PL_WhsStorageGrp;
}

public string getPL_OutsideStorageGrp(){
    return PL_OutsideStorageGrp;
}


private string getWhereCondition(){
    string sql =    "PL_Db = '" + Converter.fixString(PL_Db) +"' and " +
                    "PL_Company = " + NumberUtil.toString(PL_Company) +" and " +
                    "PL_Plant = '" + Converter.fixString(PL_Plant) +"'";
    return sql;
}

}//end class
}//end namespace
