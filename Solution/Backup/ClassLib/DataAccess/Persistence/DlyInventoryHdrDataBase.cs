using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class DlyInventoryHdrDataBase : GenericDataBaseElement{

private int DIH_Id;
private DateTime DIH_MonthEndDate;
private DateTime DIH_MonthEndPeriod;
private int DIH_FiscalYY;
private int DIH_FiscalPP;
private string DIH_UserCreated;
private DateTime DIH_DateTime;



public DlyInventoryHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){

    this.DIH_Id = reader.GetInt32("DIH_Id");
    this.DIH_MonthEndDate = reader.GetDateTime("DIH_MonthEndDate");
    this.DIH_MonthEndPeriod = reader.GetDateTime("DIH_MonthEndPeriod");
    this.DIH_FiscalYY = reader.GetInt32("DIH_FiscalYY");
    this.DIH_FiscalPP = reader.GetInt32("DIH_FiscalPP");
    this.DIH_UserCreated = reader.GetString("DIH_UserCreated");
    this.DIH_DateTime = reader.GetDateTime("DIH_DateTime");

}

public override
void write(){
	try{
		string sql = "insert into dlyinventoryhdr (DIH_MonthEndDate,DIH_MonthEndPeriod,DIH_FiscalYY, " +
		                                          "DIH_FiscalPP,DIH_UserCreated,DIH_DateTime) " +
		                "values('" + 
                                DateUtil.getCompleteDateRepresentation(DIH_MonthEndDate) +"', '" +
                                DateUtil.getCompleteDateRepresentation(DIH_MonthEndPeriod) +"', " +
                                NumberUtil.toString(DIH_FiscalYY) +", " +
                                NumberUtil.toString(DIH_FiscalPP) +", '" +
                                Converter.fixString(DIH_UserCreated) +"', '" +
                                DateUtil.getCompleteDateRepresentation(DIH_DateTime) +"')";
                        
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

public void setDIH_Id (int DIH_Id){
    this.DIH_Id = DIH_Id;
}

public void setDIH_MonthEndDate (DateTime DIH_MonthEndDate){
    this.DIH_MonthEndDate = DIH_MonthEndDate;
}

public void setDIH_MonthEndPeriod (DateTime DIH_MonthEndPeriod){
    this.DIH_MonthEndPeriod = DIH_MonthEndPeriod;
}

public void setDIH_FiscalYY (int DIH_FiscalYY){
    this.DIH_FiscalYY = DIH_FiscalYY;
}

public void setDIH_FiscalPP (int DIH_FiscalPP){
    this.DIH_FiscalPP = DIH_FiscalPP;
}

public void setDIH_UserCreated (string DIH_UserCreated){
    this.DIH_UserCreated = DIH_UserCreated;
}

public void setDIH_DateTime (DateTime DIH_DateTime){
    this.DIH_DateTime = DIH_DateTime;
}


//Getters

public int getDIH_Id(){
    return DIH_Id;
}

public DateTime getDIH_MonthEndDate(){
    return DIH_MonthEndDate;
}

public DateTime getDIH_MonthEndPeriod(){
    return DIH_MonthEndPeriod;
}

public int getDIH_FiscalYY(){
    return DIH_FiscalYY;
}

public int getDIH_FiscalPP(){
    return DIH_FiscalPP;
}

public string getDIH_UserCreated(){
    return DIH_UserCreated;
}

public DateTime getDIH_DateTime(){
    return DIH_DateTime;
}


}//end class
}//end namespace
