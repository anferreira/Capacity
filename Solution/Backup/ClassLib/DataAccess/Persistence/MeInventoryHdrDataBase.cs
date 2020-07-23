using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class MeInventoryHdrDataBase : GenericDataBaseElement{

private int MIH_Id;
private DateTime MIH_MonthEndDate;
private DateTime MIH_MonthEndPeriod;
private int MIH_FiscalYY;
private int MIH_FiscalPP;
private string MIH_UserCreated;
private DateTime MIH_DateTime;



public MeInventoryHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){

    this.MIH_Id = reader.GetInt32("MIH_Id");
    this.MIH_MonthEndDate = reader.GetDateTime("MIH_MonthEndDate");
    this.MIH_MonthEndPeriod = reader.GetDateTime("MIH_MonthEndPeriod");
    this.MIH_FiscalYY = reader.GetInt32("MIH_FiscalYY");
    this.MIH_FiscalPP = reader.GetInt32("MIH_FiscalPP");
    this.MIH_UserCreated = reader.GetString("MIH_UserCreated");
    this.MIH_DateTime = reader.GetDateTime("MIH_DateTime");

}

public override
void write(){
	try{
		string sql = "insert into dlyinventoryhdr (MIH_MonthEndDate,MIH_MonthEndPeriod,MIH_FiscalYY, " +
		                                          "MIH_FiscalPP,MIH_UserCreated,MIH_DateTime) " +
		                "values('" + 
                                DateUtil.getCompleteDateRepresentation(MIH_MonthEndDate) +"', '" +
                                DateUtil.getCompleteDateRepresentation(MIH_MonthEndPeriod) +"', " +
                                NumberUtil.toString(MIH_FiscalYY) +", " +
                                NumberUtil.toString(MIH_FiscalPP) +", '" +
                                Converter.fixString(MIH_UserCreated) +"', '" +
                                DateUtil.getCompleteDateRepresentation(MIH_DateTime) +"')";
                        
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

public void setMIH_Id (int MIH_Id){
    this.MIH_Id = MIH_Id;
}

public void setMIH_MonthEndDate (DateTime MIH_MonthEndDate){
    this.MIH_MonthEndDate = MIH_MonthEndDate;
}

public void setMIH_MonthEndPeriod (DateTime MIH_MonthEndPeriod){
    this.MIH_MonthEndPeriod = MIH_MonthEndPeriod;
}

public void setMIH_FiscalYY (int MIH_FiscalYY){
    this.MIH_FiscalYY = MIH_FiscalYY;
}

public void setMIH_FiscalPP (int MIH_FiscalPP){
    this.MIH_FiscalPP = MIH_FiscalPP;
}

public void setMIH_UserCreated (string MIH_UserCreated){
    this.MIH_UserCreated = MIH_UserCreated;
}

public void setMIH_DateTime (DateTime MIH_DateTime){
    this.MIH_DateTime = MIH_DateTime;
}


//Getters

public int getMIH_Id(){
    return MIH_Id;
}

public DateTime getMIH_MonthEndDate(){
    return MIH_MonthEndDate;
}

public DateTime getMIH_MonthEndPeriod(){
    return MIH_MonthEndPeriod;
}

public int getMIH_FiscalYY(){
    return MIH_FiscalYY;
}

public int getMIH_FiscalPP(){
    return MIH_FiscalPP;
}

public string getMIH_UserCreated(){
    return MIH_UserCreated;
}

public DateTime getMIH_DateTime(){
    return MIH_DateTime;
}


}//end class
}//end namespace
