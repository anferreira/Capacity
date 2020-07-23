using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class MeHistLabDtlDataBase : GenericDataBaseElement{
	
private int MHLD_ID;
private string MHLD_Db;
private string MHLD_Employee;
private string MHLD_Part;
private int MHLD_Seq;
private decimal MHLD_QtyRun;
private decimal MHLD_GoodQty;
private decimal MHLD_ScrapLastMonth;
private decimal MHLD_LabHrs;
private decimal MHLD_DowntimeHrs;
private decimal MHLD_EffPercent;
private decimal MHLD_ScraptPercent;
private decimal MHLD_IndirectLabHrs;


public 
MeHistLabDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
    this.MHLD_ID = reader.GetInt32("MHLD_ID");
    this.MHLD_Db = reader.GetString("MHLD_Db");
    this.MHLD_Employee = reader.GetString("MHLD_Employee");
    this.MHLD_Part = reader.GetString("MHLD_Part");
    this.MHLD_Seq = reader.GetInt32("MHLD_Seq");
    this.MHLD_QtyRun = reader.GetDecimal("MHLD_QtyRun");
    this.MHLD_GoodQty = reader.GetDecimal("MHLD_GoodQty");
    this.MHLD_ScrapLastMonth = reader.GetDecimal("MHLD_ScrapLastMonth");
    this.MHLD_LabHrs = reader.GetDecimal("MHLD_LabHrs");
    this.MHLD_DowntimeHrs = reader.GetDecimal("MHLD_DowntimeHrs");
    this.MHLD_EffPercent = reader.GetDecimal("MHLD_EffPercent");
    this.MHLD_ScraptPercent = reader.GetDecimal("MHLD_ScraptPercent");
    this.MHLD_IndirectLabHrs = reader.GetDecimal("MHLD_IndirectLabHrs");
}

public override
void write(){
	try{
		string sql = "insert into mehistlabdtl  (MHLD_Db,MHLD_Employee,MHLD_Part,MHLD_Seq,MHLD_QtyRun," +
		                        "MHLD_GoodQty,MHLD_ScrapLastMonth,MHLD_LabHrs,MHLD_DowntimeHrs," +
		                        "MHLD_EffPercent,MHLD_ScraptPercent,MHLD_IndirectLabHrs) " +
		"values('" + 
            Converter.fixString(MHLD_Db) +"', '" +
            Converter.fixString(MHLD_Employee) +"', '" +
            Converter.fixString(MHLD_Part) +"', " +
            NumberUtil.toString(MHLD_Seq) +", " +
            NumberUtil.toString(MHLD_QtyRun) +", " +
            NumberUtil.toString(MHLD_GoodQty) +", " +
            NumberUtil.toString(MHLD_ScrapLastMonth) +", " +
            NumberUtil.toString(MHLD_LabHrs) +", " +
            NumberUtil.toString(MHLD_DowntimeHrs) +", " +
            NumberUtil.toString(MHLD_EffPercent) +", " +
            NumberUtil.toString(MHLD_ScraptPercent) +", " +
            NumberUtil.toString(MHLD_IndirectLabHrs) +")";
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
void setMHLD_ID (int MHLD_ID){
    this.MHLD_ID = MHLD_ID;
}

public 
void setMHLD_Db (string MHLD_Db){
    this.MHLD_Db = MHLD_Db;
}

public 
void setMHLD_Employee (string MHLD_Employee){
    this.MHLD_Employee = MHLD_Employee;
}

public 
void setMHLD_Part (string MHLD_Part){
    this.MHLD_Part = MHLD_Part;
}

public 
void setMHLD_Seq (int MHLD_Seq){
    this.MHLD_Seq = MHLD_Seq;
}

public 
void setMHLD_QtyRun (decimal MHLD_QtyRun){
    this.MHLD_QtyRun = MHLD_QtyRun;
}

public 
void setMHLD_GoodQty (decimal MHLD_GoodQty){
    this.MHLD_GoodQty = MHLD_GoodQty;
}

public 
void setMHLD_ScrapLastMonth (decimal MHLD_ScrapLastMonth){
    this.MHLD_ScrapLastMonth = MHLD_ScrapLastMonth;
}

public 
void setMHLD_LabHrs (decimal MHLD_LabHrs){
    this.MHLD_LabHrs = MHLD_LabHrs;
}

public 
void setMHLD_DowntimeHrs (decimal MHLD_DowntimeHrs){
    this.MHLD_DowntimeHrs = MHLD_DowntimeHrs;
}

public 
void setMHLD_EffPercent (decimal MHLD_EffPercent){
    this.MHLD_EffPercent = MHLD_EffPercent;
}

public
void setMHLD_ScraptPercent (decimal MHLD_ScraptPercent){
    this.MHLD_ScraptPercent = MHLD_ScraptPercent;
}

public 
void setMHLD_IndirectLabHrs (decimal MHLD_IndirectLabHrs){
    this.MHLD_IndirectLabHrs = MHLD_IndirectLabHrs;
}


//Getters
public 
int getMHLD_ID(){
    return MHLD_ID;
}

public 
string getMHLD_Db(){
    return MHLD_Db;
}

public 
string getMHLD_Employee(){
    return MHLD_Employee;
}

public 
string getMHLD_Part(){
    return MHLD_Part;
}

public 
int getMHLD_Seq(){
    return MHLD_Seq;
}

public 
decimal getMHLD_QtyRun(){
    return MHLD_QtyRun;
}

public 
decimal getMHLD_GoodQty(){
    return MHLD_GoodQty;
}

public 
decimal getMHLD_ScrapLastMonth(){
    return MHLD_ScrapLastMonth;
}

public 
decimal getMHLD_LabHrs(){
    return MHLD_LabHrs;
}

public 
decimal getMHLD_DowntimeHrs(){
    return MHLD_DowntimeHrs;
}

public 
decimal getMHLD_EffPercent(){
    return MHLD_EffPercent;
}

public 
decimal getMHLD_ScraptPercent(){
    return MHLD_ScraptPercent;
}

public 
decimal getMHLD_IndirectLabHrs(){
    return MHLD_IndirectLabHrs;
}


}//end class

}//end namespace
