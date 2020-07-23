using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
	
public 
class ArInvoiceAsgDataBase: GenericDataBaseElement{

private int	ARIA_ID;
private string ARIA_DB;
private string ARIA_Company;
private string ARIA_InvoiceN;
private int ARIA_InvoiceNum;
private int ARIA_InvItemNum;
private string ARIA_Plant;
private string ARIA_Program;
private string ARIA_InvClass;
private string ARIA_InvType;
private string ARIA_SalesPerson;
private string ARIA_Territory;
private int ARIA_GLAccountNum;
private string ARIA_CustRefInv;
private DateTime ARIA_RefInvDate;
private string ARIA_OtherDes;
private string ARIA_DebitRC;
private string ARIA_UserID;
private DateTime ARIA_Date;
private string ARIA_Status;
private string ARIA_Notes;


public 
ArInvoiceAsgDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.ARIA_ID = reader.GetInt32("ARIA_ID");
	this.ARIA_DB = reader.GetString("ARIA_DB");
	this.ARIA_Company = reader.GetString("ARIA_Company");
	this.ARIA_InvoiceN = reader.GetString("ARIA_InvoiceN");
	this.ARIA_InvoiceNum = reader.GetInt32("ARIA_InvoiceNum");
	this.ARIA_InvItemNum = reader.GetInt32("ARIA_InvItemNum");
	this.ARIA_Plant = reader.GetString("ARIA_Plant");
	this.ARIA_Program = reader.GetString("ARIA_Program");
	this.ARIA_InvClass = reader.GetString("ARIA_InvClass");
	this.ARIA_InvType = reader.GetString("ARIA_InvType");
	this.ARIA_SalesPerson = reader.GetString("ARIA_SalesPerson");
	this.ARIA_Territory = reader.GetString("ARIA_Territory");
	this.ARIA_GLAccountNum = reader.GetInt32("ARIA_GLAccountNum");
	this.ARIA_CustRefInv = reader.GetString("ARIA_CustRefInv");
	this.ARIA_RefInvDate = reader.GetDateTime("ARIA_RefInvDate");
	this.ARIA_OtherDes = reader.GetString("ARIA_OtherDes");
	this.ARIA_DebitRC = reader.GetString("ARIA_DebitRC");
	this.ARIA_UserID = reader.GetString("ARIA_UserID");
	this.ARIA_Date = reader.GetDateTime("ARIA_Date");
	this.ARIA_Status = reader.GetString("ARIA_Status");
	this.ARIA_Notes = reader.GetString("ARIA_Notes");
}

public override
void write(){
	try{
		string sql = "insert into arinvoiceasg "+
		                    "(ARIA_DB,ARIA_Company,ARIA_InvoiceN,ARIA_InvoiceNum,ARIA_InvItemNum,"+
		                    " ARIA_Plant,ARIA_Program,ARIA_InvClass,ARIA_InvType,ARIA_SalesPerson,"+
		                    " ARIA_Territory,ARIA_GLAccountNum,ARIA_CustRefInv,ARIA_RefInvDate,"+
		                    " ARIA_OtherDes,ARIA_DebitRC,ARIA_UserID,ARIA_Date,ARIA_Status,ARIA_Notes)" +
		    "values('" +
				Converter.fixString(ARIA_DB) + "', '" +
				Converter.fixString(ARIA_Company) + "', '" +
				Converter.fixString(ARIA_InvoiceN) + "', " +
				ARIA_InvoiceNum + ", " +
				ARIA_InvItemNum + ", '" +
				Converter.fixString(ARIA_Plant) + "', '" +
				Converter.fixString(ARIA_Program) + "', '" +
				Converter.fixString(ARIA_InvClass) + "', '" +
				Converter.fixString(ARIA_InvType) + "', '" +
				Converter.fixString(ARIA_SalesPerson) + "', '" +
				Converter.fixString(ARIA_Territory) + "', " +
				NumberUtil.toString(ARIA_GLAccountNum)+ ", '" +
				Converter.fixString(ARIA_CustRefInv)+ "', '" +
				DateUtil.getCompleteDateRepresentation(ARIA_RefInvDate)+ "', '" +
				Converter.fixString(ARIA_OtherDes)+ "', '" +
				Converter.fixString(ARIA_DebitRC)+ "', '" +
				Converter.fixString(ARIA_UserID)+ "', '" +
				DateUtil.getCompleteDateRepresentation(ARIA_Date)+ "', '" +
				Converter.fixString(ARIA_Status)+ "', '" +
				Converter.fixString(ARIA_Notes)+ "')";
				
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
		string sql = "update arinvoiceasg set " +
			 "ARIA_DB = '" + ARIA_DB + "', " +
			 "ARIA_Company = '" + Converter.fixString(ARIA_Company) + "', " +
			 "ARIA_InvoiceN = '" +Converter.fixString(ARIA_InvoiceN) + "', " +
			 "ARIA_InvoiceNum = " + ARIA_InvoiceNum + ", " +
			 "ARIA_InvItemNum = " + ARIA_InvItemNum + ", " +
			 "ARIA_Plant = '" + Converter.fixString(ARIA_Plant) + "', " +
			 "ARIA_Program = '" + Converter.fixString(ARIA_Program) + "', " +
			 "ARIA_InvClass = '" + Converter.fixString(ARIA_InvClass) + "', " +
			 "ARIA_InvType = '" + Converter.fixString(ARIA_InvType) + "', " +
			 "ARIA_SalesPerson ='" + Converter.fixString(ARIA_SalesPerson) + "', " +
			 "ARIA_Territory = '" + Converter.fixString(ARIA_Territory)+  "', " +
			 "ARIA_GLAccountNum = " + NumberUtil.toString(ARIA_GLAccountNum)+ ", " +
			 "ARIA_CustRefInv = '" + Converter.fixString(ARIA_CustRefInv)+ "', " +
			 "ARIA_RefInvDate = '" + DateUtil.getCompleteDateRepresentation(ARIA_RefInvDate)+ "', " +
			 "ARIA_OtherDes = '" + Converter.fixString(ARIA_OtherDes)+ "', " +
			 "ARIA_DebitRC = '" + Converter.fixString(ARIA_DebitRC)+ "', " +
			 "ARIA_UserID = '" + Converter.fixString(ARIA_UserID)+ "', " +
			 "ARIA_Date = '" + DateUtil.getCompleteDateRepresentation(ARIA_Date)+ "', " +
			 "ARIA_Status = '" + Converter.fixString(ARIA_Status)+ "', " +
			 "ARIA_Notes = '" + Converter.fixString(ARIA_Notes)+ "' " +
			"where " + 
				"ARIA_ID = " + ARIA_ID;
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message,mySqlExc);
	}
}

public override
void delete(){
	try{
		string sql = "delete arinvoiceasg  " +
			 "where " + 
				"ARIA_ID = " + ARIA_ID;
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
		string sql = "select * from arinvoiceasg  " +
			 "where " + 
				"ARIA_ID = " + ARIA_ID;
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
bool exists(){
    NotNullDataReader reader=null;
	try{
		bool ret = false;

		string sql = "select * from arinvoiceasg " + 
			"where " +
			"ARIA_DB = '" +Converter.fixString(ARIA_DB) + "' and " +
			"ARIA_Company = '" +Converter.fixString(ARIA_Company) + "' and " +
			"ARIA_InvoiceNum = " +ARIA_InvoiceNum + " and " +
			"ARIA_Plant = '" +Converter.fixString(ARIA_Plant)+ "'";

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
bool existsDebitNote(){
    NotNullDataReader reader =null;
	try{
		bool ret = false;

		string sql = "select ARIA_InvoiceN from arinvoiceasg " + 
			"where " +
			"ARIA_DB = '" +Converter.fixString(ARIA_DB) + "' and " +
			"ARIA_Company = '" + Converter.fixString(ARIA_Company) + "' and " +
			"ARIA_InvoiceN = '" + Converter.fixString(ARIA_InvoiceN) + "' and " +
			"(ARIA_InvType = 'DEB' or ARIA_InvType = 'POA')";

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			ret = true;
		return ret;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsDebitNote>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsDebitNote>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsDebitNote> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


public
bool existsInvoiceN(string invoiceN){
    NotNullDataReader reader = null;
	try{
		bool ret = false;

		string sql = "select * from arinvoiceasg " + 
			"where " +
			"ARIA_InvoiceN = '" +Converter.fixString(invoiceN) +"'";

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			ret = true;
		return ret;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsInvoiceN>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsInvoiceN>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsInvoiceN> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public bool existsByPlant(string plant)	{
    NotNullDataReader reader = null;
	try	{
		bool ret = false;
		string sql = "select * from arinvoiceasg " + 
			"where " +
			"ARIA_Plant = '" +Converter.fixString(plant) +"'";

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			ret = true;
		return ret;
	}catch(System.Data.SqlClient.SqlException se)	{
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsByPlant>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsByPlant>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <existsByPlant> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

//Setters
public 
void setARIA_ID(int ARIA_ID){
	this.ARIA_ID = ARIA_ID;
}

public 
void setARIA_DB(string ARIA_DB){
	this.ARIA_DB = ARIA_DB;
}

public 
void setARIA_Company(string ARIA_Company){
	this.ARIA_Company = ARIA_Company;
}

public 
void setARIA_InvoiceN(string ARIA_InvoiceN){
	this.ARIA_InvoiceN = ARIA_InvoiceN;
}

public 
void setARIA_InvoiceNum(int ARIA_InvoiceNum){
	this.ARIA_InvoiceNum = ARIA_InvoiceNum;
}

public 
void setARIA_InvItemNum(int ARIA_InvItemNum){
	this.ARIA_InvItemNum = ARIA_InvItemNum;
}

public 
void setARIA_Plant(string ARIA_Plant){
	this.ARIA_Plant = ARIA_Plant;
}

public 
void setARIA_Program(string ARIA_Program){
	this.ARIA_Program = ARIA_Program;
}

public 
void setARIA_InvClass(string ARIA_InvClass){
	this.ARIA_InvClass = ARIA_InvClass;
}

public 
void setARIA_InvType(string ARIA_InvType){
	this.ARIA_InvType = ARIA_InvType;
}

public 
void setARIA_SalesPerson(string ARIA_SalesPerson){
	this.ARIA_SalesPerson = ARIA_SalesPerson;
}

public 
void setARIA_Territory(string ARIA_Territory){
	this.ARIA_Territory = ARIA_Territory;
}

public 
void setARIA_GLAccountNum(int ARIA_GLAccountNum){
   this.ARIA_GLAccountNum = ARIA_GLAccountNum;
}

public 
void setARIA_CustRefInv(string ARIA_CustRefInv){
   this.ARIA_CustRefInv = ARIA_CustRefInv;
}

public 
void setARIA_RefInvDate(DateTime ARIA_RefInvDate){
   this.ARIA_RefInvDate = ARIA_RefInvDate;
}

public 
void setARIA_OtherDes(string ARIA_OtherDes){
   this.ARIA_OtherDes = ARIA_OtherDes;
}

public 
void setARIA_DebitRC(string ARIA_DebitRC){
   this.ARIA_DebitRC = ARIA_DebitRC;
}

public 
void setARIA_UserID(string ARIA_UserID){
   this.ARIA_UserID = ARIA_UserID;
}

public 
void setARIA_Date(DateTime ARIA_Date){
   this.ARIA_Date = ARIA_Date;
}

public 
void setARIA_Status(string ARIA_Status){
   this.ARIA_Status = ARIA_Status;
}

public 
void setARIA_Notes(string ARIA_Notes){
   this.ARIA_Notes = ARIA_Notes;
}


//Getters
public 
int getARIA_ID(){
	return ARIA_ID;
}

public 
string getARIA_DB(){
	return ARIA_DB;
}

public 
string getARIA_Company(){
	return ARIA_Company;
}

public 
string getARIA_InvoiceN(){
	return ARIA_InvoiceN;
}

public 
int getARIA_InvoiceNum(){
	return ARIA_InvoiceNum;
}

public 
int getARIA_InvItemNum(){
	return ARIA_InvItemNum;
}

public 
string getARIA_Plant(){
	return ARIA_Plant;
}

public 
string getARIA_Program(){
	return ARIA_Program;
}

public 
string getARIA_InvClass(){
	return ARIA_InvClass;
}

public 
string getARIA_InvType(){
	return ARIA_InvType;
}

public 
string getARIA_SalesPerson(){
	return ARIA_SalesPerson;
}

public 
string getARIA_Territory(){
	return ARIA_Territory;
}

public
int getARIA_GLAccountNum(){
   return ARIA_GLAccountNum;
}

public
string getARIA_CustRefInv(){
   return ARIA_CustRefInv;
}

public
DateTime getARIA_RefInvDate(){
   return ARIA_RefInvDate;
}

public
string getARIA_OtherDes(){
   return ARIA_OtherDes;
}

public
string getARIA_DebitRC(){
   return ARIA_DebitRC;
}

public
string getARIA_UserID(){
   return ARIA_UserID;
}

public
DateTime getARIA_Date(){
   return ARIA_Date;
}

public
string getARIA_Status(){
   return ARIA_Status;
}

public
string getARIA_Notes(){
   return ARIA_Notes;
}

}//end class

}//end namespace
