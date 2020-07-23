using System;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class MachinesDataBase	: GenericDataBaseElement {

private int M_Id;
private string M_Db;
private string M_Plt;
private string M_Dept;
private string M_Machine;
private decimal M_RunHrs;
private decimal M_DowntimeHrs;
private decimal M_SetupHrs;
private int M_Month;
private int M_Year;
private int M_TotalParts;
private int M_TotalGood;
private decimal M_TotalScrap;
private decimal M_UnAccountedHrs;
private decimal M_UnScheduledHrs;
private decimal M_MaintenanceHrs;


public MachinesDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){

}

public
void load(NotNullDataReader reader){
    this.M_Id = reader.GetInt32("M_Id");
    this.M_Db = reader.GetString("M_Db");
    this.M_Plt = reader.GetString("M_Plt");
    this.M_Dept = reader.GetString("M_Dept");
    this.M_Machine = reader.GetString("M_Machine");
    this.M_RunHrs = reader.GetDecimal("M_RunHrs");
    this.M_DowntimeHrs = reader.GetDecimal("M_DowntimeHrs");
    this.M_SetupHrs = reader.GetDecimal("M_SetupHrs");
    this.M_Month = reader.GetInt32("M_Month");
    this.M_Year = reader.GetInt32("M_Year");
    this.M_TotalParts = reader.GetInt32("M_TotalParts");
    this.M_TotalGood = reader.GetInt32("M_TotalGood");
    this.M_TotalScrap = reader.GetDecimal("M_TotalScrap");
    this.M_UnAccountedHrs = reader.GetDecimal("M_UnAccountedHrs");
    this.M_UnScheduledHrs = reader.GetDecimal("M_UnScheduledHrs");
    this.M_MaintenanceHrs = reader.GetDecimal("M_MaintenanceHrs");

}


public override
void write(){
try{
		string sql = "insert into machines (M_Db,M_Plt,M_Dept,M_Machine,M_RunHrs,M_DowntimeHrs,M_SetupHrs," +
		                                   "M_Month,M_Year,M_TotalParts,M_TotalGood,M_TotalScrap,M_UnAccountedHrs,"+
		                                   "M_UnScheduledHrs,M_MaintenanceHrs) " +
		                "values('" + 
                                    Converter.fixString(M_Db) +"', '" +
                                    Converter.fixString(M_Plt) +"', '" +
                                    Converter.fixString(M_Dept) +"', '" +
                                    Converter.fixString(M_Machine) +"', " +
                                    NumberUtil.toString(M_RunHrs) +", " +
                                    NumberUtil.toString(M_DowntimeHrs) +", " +
                                    NumberUtil.toString(M_SetupHrs) +", " +
                                    NumberUtil.toString(M_Month) +", " +
                                    NumberUtil.toString(M_Year) +", " +
                                    NumberUtil.toString(M_TotalParts) +", " +
                                    NumberUtil.toString(M_TotalGood) +", " +
                                    NumberUtil.toString(M_TotalScrap) +", " +
                                    NumberUtil.toString(M_UnAccountedHrs) +", " +
                                    NumberUtil.toString(M_UnScheduledHrs) +", " +
                                    NumberUtil.toString(M_MaintenanceHrs) +")";
                        
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

public void setM_Id (int M_Id){
    this.M_Id = M_Id;
}

public void setM_Db (string M_Db){
    this.M_Db = M_Db;
}

public void setM_Plt (string M_Plt){
    this.M_Plt = M_Plt;
}

public void setM_Dept (string M_Dept){
    this.M_Dept = M_Dept;
}

public void setM_Machine (string M_Machine){
    this.M_Machine = M_Machine;
}

public void setM_RunHrs (decimal M_RunHrs){
    this.M_RunHrs = M_RunHrs;
}

public void setM_DowntimeHrs (decimal M_DowntimeHrs){
    this.M_DowntimeHrs = M_DowntimeHrs;
}

public void setM_SetupHrs (decimal M_SetupHrs){
    this.M_SetupHrs = M_SetupHrs;
}

public void setM_Month (int M_Month){
    this.M_Month = M_Month;
}

public void setM_Year (int M_Year){
    this.M_Year = M_Year;
}

public void setM_TotalParts (int M_TotalParts){
    this.M_TotalParts = M_TotalParts;
}

public void setM_TotalGood (int M_TotalGood){
    this.M_TotalGood = M_TotalGood;
}

public void setM_TotalScrap (decimal M_TotalScrap){
    this.M_TotalScrap = M_TotalScrap;
}

public void setM_UnAccountedHrs (decimal M_UnAccountedHrs){
    this.M_UnAccountedHrs = M_UnAccountedHrs;
}

public void setM_UnScheduledHrs (decimal M_UnScheduledHrs){
    this.M_UnScheduledHrs = M_UnScheduledHrs;
}

public void setM_MaintenanceHrs (decimal M_MaintenanceHrs){
    this.M_MaintenanceHrs = M_MaintenanceHrs;
}



//Getters
public int getM_Id(){
    return M_Id;
}

public string getM_Db(){
    return M_Db;
}

public string getM_Plt(){
    return M_Plt;
}

public string getM_Dept(){
    return M_Dept;
}

public string getM_Machine(){
    return M_Machine;
}

public decimal getM_RunHrs(){
    return M_RunHrs;
}

public decimal getM_DowntimeHrs(){
    return M_DowntimeHrs;
}

public decimal getM_SetupHrs(){
    return M_SetupHrs;
}

public int getM_Month(){
    return M_Month;
}

public int getM_Year(){
    return M_Year;
}

public int getM_TotalParts(){
    return M_TotalParts;
}

public int getM_TotalGood(){
    return M_TotalGood;
}

public decimal getM_TotalScrap(){
    return M_TotalScrap;
}

public decimal getM_UnAccountedHrs(){
    return M_UnAccountedHrs;
}

public decimal getM_UnScheduledHrs(){
    return M_UnScheduledHrs;
}

public decimal getM_MaintenanceHrs(){
    return M_MaintenanceHrs;
}


}//end class
}//end namespace
