using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class MeHistMachDtlDataBase : GenericDataBaseElement{

private int MHMD_ID;
private string MHMD_Db;
private string MHMD_Plt;
private string MHMD_Dept;
private string MHMD_Machine;
private string MHMD_Part;
private int MHMD_Seq;
private decimal MHMD_QtyRun;
private decimal MHMD_GoodQty;
private decimal MHMD_SetupHrs;
private decimal MHMD_DowntimeHrs;
private decimal MHMD_RuntimeHrs;


public 
MeHistMachDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
    this.MHMD_ID = reader.GetInt32("MHMD_ID");
    this.MHMD_Db = reader.GetString("MHMD_Db");
    this.MHMD_Plt = reader.GetString("MHMD_Plt");
    this.MHMD_Dept = reader.GetString("MHMD_Dept");
    this.MHMD_Machine = reader.GetString("MHMD_Machine");
    this.MHMD_Part = reader.GetString("MHMD_Part");
    this.MHMD_Seq = reader.GetInt32("MHMD_Seq");
    this.MHMD_QtyRun = reader.GetDecimal("MHMD_QtyRun");
    this.MHMD_GoodQty = reader.GetDecimal("MHMD_GoodQty");
    this.MHMD_SetupHrs = reader.GetDecimal("MHMD_SetupHrs");
    this.MHMD_DowntimeHrs = reader.GetDecimal("MHMD_DowntimeHrs");
    this.MHMD_RuntimeHrs = reader.GetDecimal("MHMD_RuntimeHrs");
}

public override
void write(){
	try{
		string sql = "insert into mehistmachdtl(MHMD_Db,MHMD_Plt,MHMD_Dept,MHMD_Machine,MHMD_Part,MHMD_Seq," +
		                            "MHMD_QtyRun,MHMD_GoodQty,MHMD_SetupHrs,MHMD_DowntimeHrs," +
		                            "MHMD_RuntimeHrs) "  +
		"values('" + 
			Converter.fixString(MHMD_Db) +"', '" +
			Converter.fixString(MHMD_Plt) +"', '" +
			Converter.fixString(MHMD_Dept) +"', '" +
			Converter.fixString(MHMD_Machine) +"', '" +
			Converter.fixString(MHMD_Part) +"', " +
			NumberUtil.toString(MHMD_Seq) +", " +
			NumberUtil.toString(MHMD_QtyRun) +", " +
			NumberUtil.toString(MHMD_GoodQty) +", " +
			NumberUtil.toString(MHMD_SetupHrs) +", " +
			NumberUtil.toString(MHMD_DowntimeHrs) +", " +
			NumberUtil.toString(MHMD_RuntimeHrs) +")";
	 	dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + se.Message, se);
	}catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + mySqlExc.Message, mySqlExc);
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

//Setters
public 
void setMHMD_ID (int MHMD_ID){
    this.MHMD_ID = MHMD_ID;
}

public 
void setMHMD_Db (string MHMD_Db){
    this.MHMD_Db = MHMD_Db;
}

public 
void setMHMD_Plt (string MHMD_Plt){
    this.MHMD_Plt = MHMD_Plt;
}

public 
void setMHMD_Dept (string MHMD_Dept){
    this.MHMD_Dept = MHMD_Dept;
}

public 
void setMHMD_Machine (string MHMD_Machine){
    this.MHMD_Machine = MHMD_Machine;
}

public 
void setMHMD_Part (string MHMD_Part){
    this.MHMD_Part = MHMD_Part;
}

public 
void setMHMD_Seq (int MHMD_Seq){
    this.MHMD_Seq = MHMD_Seq;
}

public 
void setMHMD_QtyRun (decimal MHMD_QtyRun){
    this.MHMD_QtyRun = MHMD_QtyRun;
}

public 
void setMHMD_GoodQty(decimal MHMD_GoodQty){
    this.MHMD_GoodQty = MHMD_GoodQty;
}

public 
void setMHMD_SetupHrs (decimal MHMD_SetupHrs){
    this.MHMD_SetupHrs = MHMD_SetupHrs;
}

public 
void setMHMD_DowntimeHrs (decimal MHMD_DowntimeHrs){
    this.MHMD_DowntimeHrs = MHMD_DowntimeHrs;
}

public 
void setMHMD_RuntimeHrs (decimal MHMD_RuntimeHrs){
    this.MHMD_RuntimeHrs = MHMD_RuntimeHrs;
}

//Getters
public 
int getMHMD_ID(){
    return MHMD_ID;
}

public 
string getMHMD_Db(){
    return MHMD_Db;
}

public 
string getMHMD_Plt(){
    return MHMD_Plt;
}

public 
string getMHMD_Dept(){
    return MHMD_Dept;
}

public 
string getMHMD_Machine(){
    return MHMD_Machine;
}

public 
string getMHMD_Part(){
    return MHMD_Part;
}

public 
int getMHMD_Seq(){
    return MHMD_Seq;
}

public 
decimal getMHMD_QtyRun(){
    return MHMD_QtyRun;
}

public 
decimal getMHMD_GoodQty(){
    return MHMD_GoodQty;
}

public 
decimal getMHMD_SetupHrs(){
    return MHMD_SetupHrs;
}

public 
decimal getMHMD_DowntimeHrs(){
    return MHMD_DowntimeHrs;
}

public 
decimal getMHMD_RuntimeHrs(){
    return MHMD_RuntimeHrs;
}

}//end class

}//end namespace
