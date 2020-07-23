using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

	
public 
class ArInvoiceDataBase	: GenericDataBaseElement{

private string ARI_Db;
private string ARI_Company;
private string ARI_Plant;
private string ARI_ARInvoiceN;
private int ARI_ARInvoiceNum;
private string ARI_InvoiceType;
private int ARI_BOLNum;
private string ARI_BOLN;
private string ARI_CustNum;
private string ARI_BillToName;
private string ARI_ShiptoNum;
private string ARI_ShiptoName;
private string ARI_CustPlant;
private DateTime ARI_InvDate;
private DateTime ARI_PostDate;
private DateTime ARI_DueDate;
private decimal ARI_InvoiceAmt;
private decimal ARI_Payment;
private decimal ARI_Balance;
private decimal ARI_CreditTot;
private DateTime ARI_LastPayDate;
private string ARI_LastCheck;
private decimal ARI_LastCheckAmt;
private int ARI_PostPeriod;
private int ARI_PostYear;
private string ARI_Program;
private string ARI_Status;
private string ARI_Currency;
private decimal ARI_PostExgRate;
private string ARI_TransDesc;

public 
ArInvoiceDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){

	this.ARI_Db = reader.GetString("ARI_Db");
	this.ARI_Company = reader.GetString("ARI_Company");
	this.ARI_Plant = reader.GetString("ARI_Plant");
	this.ARI_ARInvoiceN = reader.GetString("ARI_ARInvoiceN");
	this.ARI_ARInvoiceNum = reader.GetInt32("ARI_ARInvoiceNum");
	this.ARI_InvoiceType = reader.GetString("ARI_InvoiceType");
	this.ARI_BOLNum = reader.GetInt32("ARI_BOLNum");
	this.ARI_BOLN = reader.GetString("ARI_BOLN");
	this.ARI_CustNum = reader.GetString("ARI_CustNum");
	this.ARI_BillToName = reader.GetString("ARI_BillToName");
	this.ARI_ShiptoNum = reader.GetString("ARI_ShiptoNum");
	this.ARI_ShiptoName = reader.GetString("ARI_ShiptoName");
	this.ARI_CustPlant = reader.GetString("ARI_CustPlant");
	this.ARI_InvDate = reader.GetDateTime("ARI_InvDate");
	this.ARI_PostDate = reader.GetDateTime("ARI_PostDate");
	this.ARI_DueDate = reader.GetDateTime("ARI_DueDate");
	this.ARI_InvoiceAmt = reader.GetDecimal("ARI_InvoiceAmt");
	this.ARI_Payment = reader.GetDecimal("ARI_Payment");
	this.ARI_Balance = reader.GetDecimal("ARI_Balance");
	this.ARI_CreditTot = reader.GetDecimal("ARI_CreditTot");
	this.ARI_LastPayDate = reader.GetDateTime("ARI_LastPayDate");
	this.ARI_LastCheck = reader.GetString("ARI_LastCheck");
	this.ARI_LastCheckAmt = reader.GetDecimal("ARI_LastCheckAmt");
	this.ARI_PostPeriod = reader.GetInt16("ARI_PostPeriod");
	this.ARI_PostYear = reader.GetInt32("ARI_PostYear");
	this.ARI_Program = reader.GetString("ARI_Program");
	this.ARI_Status = reader.GetString("ARI_Status");
	this.ARI_Currency = reader.GetString("ARI_Currency");
	this.ARI_PostExgRate = reader.GetDecimal("ARI_PostExgRate");
	this.ARI_TransDesc = reader.GetString("ARI_TransDesc");
}

public override
void write(){

	try{
		string sql = "insert into arinvoice values('" +
				Converter.fixString(ARI_Db) +"', '" +
				Converter.fixString(ARI_Company) +"', '" +
				Converter.fixString(ARI_Plant) +"', '" +
				Converter.fixString(ARI_ARInvoiceN) +"', " +
				NumberUtil.toString(ARI_ARInvoiceNum) +", '" +
				Converter.fixString(ARI_InvoiceType) + "', " +
				NumberUtil.toString(ARI_BOLNum) + ", '" +
				Converter.fixString(ARI_BOLN) + "' , '" +
				Converter.fixString(ARI_CustNum) + "', '" +
				Converter.fixString(ARI_BillToName) + "', '" +
				Converter.fixString(ARI_ShiptoNum) + "', '" +
				Converter.fixString(ARI_ShiptoName) + "', '" +
				Converter.fixString(ARI_CustPlant) + "', '" +
				DateUtil.getCompleteDateRepresentation(ARI_InvDate) + "', '" +
				DateUtil.getCompleteDateRepresentation(ARI_PostDate) + "', '" +
				DateUtil.getCompleteDateRepresentation(ARI_DueDate) + "', " +
				NumberUtil.toString(ARI_InvoiceAmt) + ", " +
				NumberUtil.toString(ARI_Payment) + ", " +
				NumberUtil.toString(ARI_Balance) + ", " +
				NumberUtil.toString(ARI_CreditTot) + ", '" +
				DateUtil.getCompleteDateRepresentation(ARI_LastPayDate) + "', '" +
				Converter.fixString(ARI_LastCheck) + "', " +
				NumberUtil.toString(ARI_LastCheckAmt) + ", " +
				NumberUtil.toString(ARI_PostPeriod) + ", " +
				NumberUtil.toString(ARI_PostYear) + ", '" +
				Converter.fixString(ARI_Program) + "', '" +
				Converter.fixString(ARI_Status) + "', '" +
				Converter.fixString(ARI_Currency) + "', " +
				NumberUtil.toString(ARI_PostExgRate) + ", '" +
				Converter.fixString(ARI_TransDesc) +"')";
	
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
		string sql = "update arinvoice set " +
				"ARI_InvoiceAmt = " +NumberUtil.toString(ARI_InvoiceAmt) + ", " +
				"ARI_Payment = " + NumberUtil.toString(ARI_Payment) + ", " +
				"ARI_Balance = " + NumberUtil.toString(ARI_Balance) + " " +
			"where " + 
				"ARI_Db = '" + Converter.fixString(ARI_Db) +"' and " +
				"ARI_Company = '" + Converter.fixString(ARI_Company) +"' and " +
				"ARI_ARInvoiceN = '" +Converter.fixString(ARI_ARInvoiceN) +"'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <updateInvoice>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <updateInvoice>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <updateInvoice> : " + mySqlExc.Message,mySqlExc);
	}
}

public override
void delete(){
	try{
		string sql = "delete from arinvoice where " +
			"ARI_Db = '" + Converter.fixString(ARI_Db) +"' and " +
			"ARI_Company = '" + Converter.fixString(ARI_Company) +"' and " +
			"ARI_Plant = '" + Converter.fixString(ARI_Plant) +"' and " +
			"ARI_ARInvoiceN = '" +Converter.fixString(ARI_ARInvoiceN) +"'";

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message,mySqlExc);
	}
}

public
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from arinvoice where " + 
			"ARI_Db = '" + Converter.fixString(ARI_Db) +"' and " +
			"ARI_Company = '" + Converter.fixString(ARI_Company) +"' and " +
			"ARI_Plant = '" + Converter.fixString(ARI_Plant) +"' and " +
			"ARI_ARInvoiceN = '" +Converter.fixString(ARI_ARInvoiceN) +"'";
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

public 
void deleteOldRecords(){
	try{
		string sql = "delete from arinvoice where " +
					    "ARI_Db = '"+ Converter.fixString(ARI_Db) +"' and " +
						"ARI_Company = '" + Converter.fixString(ARI_Company) +"' and " +
						"ARI_ARInvoiceN = '" + Converter.fixString(ARI_ARInvoiceN)+"'" ;

		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <deleteOldRecords>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <deleteOldRecords>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <deleteOldRecords> : " + mySqlExc.Message,mySqlExc);
	}
}

public
bool exists(){
    NotNullDataReader reader = null;
	try{
		bool ret = false;

		string sql = "select * from arinvoice " + 
			"where " +
			"ARI_Db = '" + Converter.fixString(ARI_Db) +"' and " +
			"ARI_Company = '" + Converter.fixString(ARI_Company) +"' and " +
			"ARI_Plant = '" + Converter.fixString(ARI_Plant) +"' and " +
			"ARI_ARInvoiceN = '" +Converter.fixString(ARI_ARInvoiceN) +"'";

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			ret = true;

		return ret;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
bool existsInvoice(){
	NotNullDataReader reader = null;
	try{
		bool ret = false;

		string sql = "select * from arinvoice " + 
			"where " +
			"ARI_Db = '" + Converter.fixString(ARI_Db) +"' and " +
			"ARI_Company = '" + Converter.fixString(ARI_Company) +"' and " +
			"ARI_ARInvoiceN = '" +Converter.fixString(ARI_ARInvoiceN) +"'";

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			ret = true;
		return ret;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsInvoice>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsInvoice>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsInvoice> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

//Setters
public 
void setARI_Db(string ARI_Db){
   this.ARI_Db = ARI_Db;
}

public 
void setARI_Company(string ARI_Company){
   this.ARI_Company = ARI_Company;
}

public 
void setARI_Plant(string ARI_Plant){
   this.ARI_Plant = ARI_Plant;
}

public 
void setARI_ARInvoiceN(string ARI_ARInvoiceN){
   this.ARI_ARInvoiceN = ARI_ARInvoiceN;
}

public 
void setARI_ARInvoiceNum(int ARI_ARInvoiceNum){
   this.ARI_ARInvoiceNum = ARI_ARInvoiceNum;
}

public 
void setARI_InvoiceType(string ARI_InvoiceType){
   this.ARI_InvoiceType = ARI_InvoiceType;
}

public 
void setARI_BOLNum(int ARI_BOLNum){
   this.ARI_BOLNum = ARI_BOLNum;
}

public 
void setARI_BOLN(string ARI_BOLN){
   this.ARI_BOLN = ARI_BOLN;
}

public 
void setARI_CustNum(string ARI_CustNum){
   this.ARI_CustNum = ARI_CustNum;
}

public 
void setARI_InvDate(DateTime ARI_InvDate){
   this.ARI_InvDate = ARI_InvDate;
}

public 
void setARI_PostDate(DateTime ARI_PostDate){
   this.ARI_PostDate = ARI_PostDate;
}

public 
void setARI_DueDate(DateTime ARI_DueDate){
   this.ARI_DueDate = ARI_DueDate;
}

public 
void setARI_InvoiceAmt(decimal ARI_InvoiceAmt){
   this.ARI_InvoiceAmt = ARI_InvoiceAmt;
}

public 
void setARI_Payment(decimal ARI_Payment){
   this.ARI_Payment = ARI_Payment;
}

public 
void setARI_Balance(decimal ARI_Balance){
   this.ARI_Balance = ARI_Balance;
}

public 
void setARI_CreditTot(decimal ARI_CreditTot){
   this.ARI_CreditTot = ARI_CreditTot;
}

public 
void setARI_LastPayDate(DateTime ARI_LastPayDate){
   this.ARI_LastPayDate = ARI_LastPayDate;
}

public 
void setARI_LastCheck(string ARI_LastCheck){
   this.ARI_LastCheck = ARI_LastCheck;
}

public 
void setARI_LastCheckAmt(decimal ARI_LastCheckAmt){
   this.ARI_LastCheckAmt = ARI_LastCheckAmt;
}

public 
void setARI_PostPeriod(int ARI_PostPeriod){
   this.ARI_PostPeriod = ARI_PostPeriod;
}

public 
void setARI_PostYear(int ARI_PostYear){
   this.ARI_PostYear = ARI_PostYear;
}

public 
void setARI_Program(string ARI_Program){
   this.ARI_Program = ARI_Program;
}

public 
void setARI_Status(string ARI_Status){
   this.ARI_Status = ARI_Status;
}

public 
void setARI_Currency(string ARI_Currency){
   this.ARI_Currency = ARI_Currency;
}

public 
void setARI_PostExgRate(decimal ARI_PostExgRate){
   this.ARI_PostExgRate = ARI_PostExgRate;
}

public 
void setARI_BillToName(string ARI_BillToName){
	this.ARI_BillToName = ARI_BillToName;
}

public 
void setARI_ShiptoNum(string ARI_ShiptoNum){
	this.ARI_ShiptoNum = ARI_ShiptoNum;
}

public 
void setARI_ShiptoName(string ARI_ShiptoName){
	this.ARI_ShiptoName = ARI_ShiptoName;
}

public 
void setARI_CustPlant(string ARI_CustPlant){
	this.ARI_CustPlant = ARI_CustPlant;
}

public 
void setARI_TransDesc(string ARI_TransDesc){
	this.ARI_TransDesc = ARI_TransDesc;
}


//Getters
public
string getARI_Db(){
   return ARI_Db;
}

public
string getARI_Company(){
   return ARI_Company;
}

public
string getARI_Plant(){
   return ARI_Plant;
}

public
string getARI_ARInvoiceN(){
   return ARI_ARInvoiceN;
}

public
int getARI_ARInvoiceNum(){
   return ARI_ARInvoiceNum;
}

public
string getARI_InvoiceType(){
   return ARI_InvoiceType;
}

public
int getARI_BOLNum(){
   return ARI_BOLNum;
}

public
string getARI_BOLN(){
   return ARI_BOLN;
}

public
string getARI_CustNum(){
   return ARI_CustNum;
}

public
DateTime getARI_InvDate(){
   return ARI_InvDate;
}

public
DateTime getARI_PostDate(){
   return ARI_PostDate;
}

public
DateTime getARI_DueDate(){
   return ARI_DueDate;
}

public
decimal getARI_InvoiceAmt(){
   return ARI_InvoiceAmt;
}

public
decimal getARI_Payment(){
   return ARI_Payment;
}

public
decimal getARI_Balance(){
   return ARI_Balance;
}

public
decimal getARI_CreditTot(){
   return ARI_CreditTot;
}

public
DateTime getARI_LastPayDate(){
   return ARI_LastPayDate;
}

public
string getARI_LastCheck(){
   return ARI_LastCheck;
}

public
decimal getARI_LastCheckAmt(){
   return ARI_LastCheckAmt;
}

public
int getARI_PostPeriod(){
   return ARI_PostPeriod;
}

public
int getARI_PostYear(){
   return ARI_PostYear;
}

public
string getARI_Program(){
   return ARI_Program;
}

public
string getARI_Status(){
   return ARI_Status;
}

public
string getARI_Currency(){
   return ARI_Currency;
}

public
decimal getARI_PostExgRate(){
   return ARI_PostExgRate;
}

public 
string getARI_BillToName(){
	return ARI_BillToName;
}

public 
string getARI_ShiptoNum(){
	return ARI_ShiptoNum;
}

public 
string getARI_ShiptoName(){
	return ARI_ShiptoName;
}

public 
string getARI_CustPlant(){
	return ARI_CustPlant;
}

public 
string getARI_TransDesc(){
	return ARI_TransDesc;
}

}//end class

}//end namespace
