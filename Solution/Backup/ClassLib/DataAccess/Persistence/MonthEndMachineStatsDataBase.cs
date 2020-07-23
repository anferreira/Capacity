using System;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class MonthEndMachineStatsDataBase	: GenericDataBaseElement {

private int MEMS_Id;
private string MEMS_Db;
private string MEMS_Plt;
private string MEMS_Dept;
private string MEMS_Machine;
private decimal MEMS_RunHrs;
private decimal MEMS_DowntimeHrs;
private decimal MEMS_SetupHrs;
private int MEMS_Month;
private int MEMS_Year;
private int MEMS_TotalParts;
private int MEMS_TotalGood;
private decimal MEMS_TotalScrap;
private decimal MEMS_UnAccountedHrs;
private decimal MEMS_UnScheduledHrs;
private decimal MEMS_MaintenanceHrs;


public MonthEndMachineStatsDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){

}

public
void load(NotNullDataReader reader){
    this.MEMS_Id = reader.GetInt32("MEMS_Id");
    this.MEMS_Db = reader.GetString("MEMS_Db");
    this.MEMS_Plt = reader.GetString("MEMS_Plt");
    this.MEMS_Dept = reader.GetString("MEMS_Dept");
    this.MEMS_Machine = reader.GetString("MEMS_Machine");
    this.MEMS_RunHrs = reader.GetDecimal("MEMS_RunHrs");
    this.MEMS_DowntimeHrs = reader.GetDecimal("MEMS_DowntimeHrs");
    this.MEMS_SetupHrs = reader.GetDecimal("MEMS_SetupHrs");
    this.MEMS_Month = reader.GetInt32("MEMS_Month");
    this.MEMS_Year = reader.GetInt32("MEMS_Year");
    this.MEMS_TotalParts = reader.GetInt32("MEMS_TotalParts");
    this.MEMS_TotalGood = reader.GetInt32("MEMS_TotalGood");
    this.MEMS_TotalScrap = reader.GetDecimal("MEMS_TotalScrap");
    this.MEMS_UnAccountedHrs = reader.GetDecimal("MEMS_UnAccountedHrs");
    this.MEMS_UnScheduledHrs = reader.GetDecimal("MEMS_UnScheduledHrs");
    this.MEMS_MaintenanceHrs = reader.GetDecimal("MEMS_MaintenanceHrs");

}


public override
void write(){
try{
		string sql = "insert into monthendmachinestats " +
		                            "(MEMS_Db,MEMS_Plt,MEMS_Dept,MEMS_Machine,MEMS_RunHrs,MEMS_DowntimeHrs,MEMS_SetupHrs," +
		                            " MEMS_Month,MEMS_Year,MEMS_TotalParts,MEMS_TotalGood,MEMS_TotalScrap,MEMS_UnAccountedHrs,"+
		                            " MEMS_UnScheduledHrs,MEMS_MaintenanceHrs) " +
		                "values('" + 
                                    Converter.fixString(MEMS_Db) +"', '" +
                                    Converter.fixString(MEMS_Plt) +"', '" +
                                    Converter.fixString(MEMS_Dept) +"', '" +
                                    Converter.fixString(MEMS_Machine) +"', " +
                                    NumberUtil.toString(MEMS_RunHrs) +", " +
                                    NumberUtil.toString(MEMS_DowntimeHrs) +", " +
                                    NumberUtil.toString(MEMS_SetupHrs) +", " +
                                    NumberUtil.toString(MEMS_Month) +", " +
                                    NumberUtil.toString(MEMS_Year) +", " +
                                    NumberUtil.toString(MEMS_TotalParts) +", " +
                                    NumberUtil.toString(MEMS_TotalGood) +", " +
                                    NumberUtil.toString(MEMS_TotalScrap) +", " +
                                    NumberUtil.toString(MEMS_UnAccountedHrs) +", " +
                                    NumberUtil.toString(MEMS_UnScheduledHrs) +", " +
                                    NumberUtil.toString(MEMS_MaintenanceHrs) +")";
                        
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


//Setters

public void setMEMS_Id (int MEMS_Id){
    this.MEMS_Id = MEMS_Id;
}

public void setMEMS_Db (string MEMS_Db){
    this.MEMS_Db = MEMS_Db;
}

public void setMEMS_Plt (string MEMS_Plt){
    this.MEMS_Plt = MEMS_Plt;
}

public void setMEMS_Dept (string MEMS_Dept){
    this.MEMS_Dept = MEMS_Dept;
}

public void setMEMS_Machine (string MEMS_Machine){
    this.MEMS_Machine = MEMS_Machine;
}

public void setMEMS_RunHrs (decimal MEMS_RunHrs){
    this.MEMS_RunHrs = MEMS_RunHrs;
}

public void setMEMS_DowntimeHrs (decimal MEMS_DowntimeHrs){
    this.MEMS_DowntimeHrs = MEMS_DowntimeHrs;
}

public void setMEMS_SetupHrs (decimal MEMS_SetupHrs){
    this.MEMS_SetupHrs = MEMS_SetupHrs;
}

public void setMEMS_Month (int MEMS_Month){
    this.MEMS_Month = MEMS_Month;
}

public void setMEMS_Year (int MEMS_Year){
    this.MEMS_Year = MEMS_Year;
}

public void setMEMS_TotalParts (int MEMS_TotalParts){
    this.MEMS_TotalParts = MEMS_TotalParts;
}

public void setMEMS_TotalGood (int MEMS_TotalGood){
    this.MEMS_TotalGood = MEMS_TotalGood;
}

public void setMEMS_TotalScrap (decimal MEMS_TotalScrap){
    this.MEMS_TotalScrap = MEMS_TotalScrap;
}

public void setMEMS_UnAccountedHrs (decimal MEMS_UnAccountedHrs){
    this.MEMS_UnAccountedHrs = MEMS_UnAccountedHrs;
}

public void setMEMS_UnScheduledHrs (decimal MEMS_UnScheduledHrs){
    this.MEMS_UnScheduledHrs = MEMS_UnScheduledHrs;
}

public void setMEMS_MaintenanceHrs (decimal MEMS_MaintenanceHrs){
    this.MEMS_MaintenanceHrs = MEMS_MaintenanceHrs;
}



//Getters
public int getMEMS_Id(){
    return MEMS_Id;
}

public string getMEMS_Db(){
    return MEMS_Db;
}

public string getMEMS_Plt(){
    return MEMS_Plt;
}

public string getMEMS_Dept(){
    return MEMS_Dept;
}

public string getMEMS_Machine(){
    return MEMS_Machine;
}

public decimal getMEMS_RunHrs(){
    return MEMS_RunHrs;
}

public decimal getMEMS_DowntimeHrs(){
    return MEMS_DowntimeHrs;
}

public decimal getMEMS_SetupHrs(){
    return MEMS_SetupHrs;
}

public int getMEMS_Month(){
    return MEMS_Month;
}

public int getMEMS_Year(){
    return MEMS_Year;
}

public int getMEMS_TotalParts(){
    return MEMS_TotalParts;
}

public int getMEMS_TotalGood(){
    return MEMS_TotalGood;
}

public decimal getMEMS_TotalScrap(){
    return MEMS_TotalScrap;
}

public decimal getMEMS_UnAccountedHrs(){
    return MEMS_UnAccountedHrs;
}

public decimal getMEMS_UnScheduledHrs(){
    return MEMS_UnScheduledHrs;
}

public decimal getMEMS_MaintenanceHrs(){
    return MEMS_MaintenanceHrs;
}


}//end class
}//end namespace
