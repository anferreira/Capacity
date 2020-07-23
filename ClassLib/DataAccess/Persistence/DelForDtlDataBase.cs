using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public class DelForDtlDataBase : GenericDataBaseElement	{

private int DD_ID;
private int DD_Key;
private string DD_Db;
private string DD_DelforReleaseNum;
private DateTime DD_DelforDate;
private DateTime DD_DelforTime;
private DateTime DD_DelforToDate;
private decimal DD_DelforQtyCum;
private int DD_Qty;
private int DD_QtyAdj;
private string DD_AuthLev;
private string DD_Timing;
private string DD_AuthType;
private string DD_RanNumber;

			
public DelForDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public 
void load(NotNullDataReader reader){
	this.DD_ID = reader.GetInt32("DD_ID");
	this.DD_Key = reader.GetInt32("DD_Key");
	this.DD_Db = reader.GetString("DD_Db");
	this.DD_DelforReleaseNum = reader.GetString("DD_DelforReleaseNum");
	this.DD_DelforDate = reader.GetDateTime("DD_DelforDate");
	this.DD_DelforTime = reader.GetDateTime("DD_DelforTime");
	this.DD_DelforToDate = reader.GetDateTime("DD_DelforToDate");
	this.DD_DelforQtyCum = reader.GetDecimal("DD_DelforQtyCum");
	this.DD_Qty = reader.GetInt32("DD_Qty");
	this.DD_QtyAdj = reader.GetInt32("DD_QtyAdj");
	this.DD_AuthLev = reader.GetString("DD_AuthLev");
	this.DD_Timing = reader.GetString("DD_Timing");
	this.DD_AuthType = reader.GetString("DD_AuthType");
	this.DD_RanNumber = reader.GetString("DD_RanNumber");
}

public override 
void write(){
	try{
		string sql = "insert into delfordtl (DD_Key,DD_Db,DD_DelforReleaseNum,DD_DelforDate,DD_DelforTime," +
		                                    "DD_DelforToDate,DD_DelforQtyCum,DD_Qty,DD_QtyAdj,DD_AuthLev," +
		                                    "DD_Timing,DD_AuthType,DD_RanNumber) " +
		            "values(" + 
                        NumberUtil.toString(DD_Key) +", '" +
                        Converter.fixString(DD_Db) +"', '" +
                        Converter.fixString(DD_DelforReleaseNum) +"', '" +
                        DateUtil.getCompleteDateRepresentation(DD_DelforDate) +"', '" +
                        DateUtil.getCompleteDateRepresentation(DD_DelforTime) + "', '" +//AF 2018/10/15 DateUtil.getTimeRepresentation(DD_DelforTime) +"', '" +
                        DateUtil.getCompleteDateRepresentation(DD_DelforToDate) +"', " +
                        NumberUtil.toString(DD_DelforQtyCum) +", " +
                        NumberUtil.toString(DD_Qty) +", " +
                        NumberUtil.toString(DD_QtyAdj) +", '" +
                        Converter.fixString(DD_AuthLev) +"', '" +
                        Converter.fixString(DD_Timing) +"', '" +
                        Converter.fixString(DD_AuthType) +"', '" +
                        Converter.fixString(DD_RanNumber) +"')";
		 		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public override 
void update(){
    throw new PersistenceException("Method not implemented");
}

public override 
void delete(){
    throw new PersistenceException("Method not implemented");

}

public 
void read(){
    throw new PersistenceException("Method not implemented");
}

//Setters

public void setDD_ID (int DD_ID){
    this.DD_ID = DD_ID;
}

public void setDD_Key (int DD_Key){
    this.DD_Key = DD_Key;
}

public void setDD_Db (string DD_Db){
    this.DD_Db = DD_Db;
}

public void setDD_DelforReleaseNum (string DD_DelforReleaseNum){
    this.DD_DelforReleaseNum = DD_DelforReleaseNum;
}

public void setDD_DelforDate (DateTime DD_DelforDate){
    this.DD_DelforDate = DD_DelforDate;
}

public void setDD_DelforTime (DateTime DD_DelforTime){
    this.DD_DelforTime = DD_DelforTime;
}

public void setDD_DelforToDate (DateTime DD_DelforToDate){
    this.DD_DelforToDate = DD_DelforToDate;
}

public void setDD_DelforQtyCum (decimal DD_DelforQtyCum){
    this.DD_DelforQtyCum = DD_DelforQtyCum;
}

public void setDD_Qty (int DD_Qty){
    this.DD_Qty = DD_Qty;
}

public void setDD_QtyAdj (int DD_QtyAdj){
    this.DD_QtyAdj = DD_QtyAdj;
}

public void setDD_AuthLev (string DD_AuthLev){
    this.DD_AuthLev = DD_AuthLev;
}

public void setDD_Timing (string DD_Timing){
    this.DD_Timing = DD_Timing;
}

public void setDD_AuthType (string DD_AuthType){
    this.DD_AuthType = DD_AuthType;
}

public void setDD_RanNumber (string DD_RanNumber){
    this.DD_RanNumber = DD_RanNumber;
}



//Getters
public int getDD_ID(){
    return DD_ID;
}

public int getDD_Key(){
    return DD_Key;
}

public string getDD_Db(){
    return DD_Db;
}

public string getDD_DelforReleaseNum(){
    return DD_DelforReleaseNum;
}

public DateTime getDD_DelforDate(){
    return DD_DelforDate;
}

public DateTime getDD_DelforTime(){
    return DD_DelforTime;
}

public DateTime getDD_DelforToDate(){
    return DD_DelforToDate;
}

public decimal getDD_DelforQtyCum(){
    return DD_DelforQtyCum;
}

public int getDD_Qty(){
    return DD_Qty;
}

public int getDD_QtyAdj(){
    return DD_QtyAdj;
}

public string getDD_AuthLev(){
    return DD_AuthLev;
}

public string getDD_Timing(){
    return DD_Timing;
}

public string getDD_AuthType(){
    return DD_AuthType;
}

public string getDD_RanNumber(){
    return DD_RanNumber;
}


}//end class
}//end namespace
