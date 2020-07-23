using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class ArRemLinkDetailDataBase : GenericDataBaseElement{

private int ID;
private string RL_RemDb;
private int RL_LogNum;
private int RL_EntryNum;
private int RL_LineNum;
private int RL_DetailNum;
private string RL_InvDb;
private string RL_InvCompany;
private string RL_InvPlant;
private string RL_InvoiceN;
private int RL_InvoiceNum;
private int RL_InvoiceItem;
private string RL_BOLN;
private int RL_BOLNum;
private int RL_BOLItem;
private string RL_PayType;
private decimal RL_PayDiff;
private string RL_PayD;
private decimal RL_PriceDiff;
private string RL_PriceD;
private string RL_CollectionGrp;
private decimal RL_QtyDiff;

public
ArRemLinkDetailDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.ID = reader.GetInt32("ID");
	this.RL_RemDb = reader.GetString("RL_RemDb");
	this.RL_LogNum = reader.GetInt32("RL_LogNum");
	this.RL_LogNum = reader.GetInt32("RL_LogNum");
	this.RL_EntryNum = reader.GetInt32("RL_EntryNum");
	this.RL_LineNum = reader.GetInt32("RL_LineNum");
	this.RL_DetailNum = reader.GetInt32("RL_DetailNum");
	this.RL_InvDb = reader.GetString("RL_InvDb");
	this.RL_InvCompany = reader.GetString("RL_InvCompany");
	this.RL_InvPlant = reader.GetString("RL_InvPlant");
	this.RL_InvoiceN = reader.GetString("RL_InvoiceN");
	this.RL_InvoiceNum = reader.GetInt32("RL_InvoiceNum");
	this.RL_InvoiceItem = reader.GetInt32("RL_InvoiceItem");
	this.RL_BOLN = reader.GetString("RL_BOLN");
	this.RL_BOLNum = reader.GetInt32("RL_BOLNum");
	this.RL_BOLItem = reader.GetInt32("RL_BOLItem");
	this.RL_PayType = reader.GetString("RL_PayType");
	this.RL_PayDiff = reader.GetDecimal("RL_PayDiff");
	this.RL_PayD = reader.GetString("RL_PayD");
	this.RL_PriceDiff = reader.GetDecimal("RL_PriceDiff");
	this.RL_PriceD = reader.GetString("RL_PriceD");
	this.RL_CollectionGrp = reader.GetString("RL_CollectionGrp");
	this.RL_QtyDiff = reader.GetDecimal("RL_QtyDiff");
}

public override
void write(){
	try{
		string sql = "insert into arremlinkdetail " +
		                    "(RL_RemDb,RL_LogNum,RL_EntryNum,RL_LineNum,RL_DetailNum,RL_InvDb,"+
		                    " RL_InvCompany,RL_InvPlant,RL_InvoiceN,RL_InvoiceNum,RL_InvoiceItem,"+
		                    " RL_BOLN,RL_BOLNum,RL_BOLItem,RL_PayType,RL_PayDiff,RL_PayD,RL_PriceDiff,"+
		                    " RL_PriceD,RL_CollectionGrp,RL_QtyDiff)" +
		        " values('" +
					Converter.fixString(RL_RemDb)+ "', " + 
					NumberUtil.toString(RL_LogNum)+ ", " +
					NumberUtil.toString(RL_EntryNum)+ ", " +
					NumberUtil.toString(RL_LineNum)+ ", " +
					NumberUtil.toString(RL_DetailNum)+ ", '" +
					Converter.fixString(RL_InvDb)+ "', '" +
					Converter.fixString(RL_InvCompany)+ "', '" +
					Converter.fixString(RL_InvPlant)+ "', '" +
					Converter.fixString(RL_InvoiceN)+ "', " +
					NumberUtil.toString(RL_InvoiceNum)+ ", " +
					NumberUtil.toString(RL_InvoiceItem)+ ", '" +
					Converter.fixString(RL_BOLN)+ "', " +
					NumberUtil.toString(RL_BOLNum)+ ", " +
					NumberUtil.toString(RL_BOLItem)+ ", '" +
					Converter.fixString(RL_PayType) + "', " +
					NumberUtil.toString(RL_PayDiff) + ", '" +
					Converter.fixString(RL_PayD) + "', " +
					NumberUtil.toString(RL_PriceDiff) + ", '" +
					Converter.fixString(RL_PriceD) + "', '" +
					Converter.fixString(RL_CollectionGrp) + "', " +
					NumberUtil.toString(RL_QtyDiff)+")";
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
		string sql = "update arremlinkdetail set " +
					"RL_RemDb = '" + Converter.fixString(RL_RemDb) +"', " +
					"RL_LogNum = " + NumberUtil.toString(RL_LogNum) +", " +
					"RL_EntryNum = " + NumberUtil.toString(RL_EntryNum) +", " +
					"RL_LineNum = " + NumberUtil.toString(RL_LineNum) +", " +
					"RL_DetailNum = " + NumberUtil.toString(RL_DetailNum) +", " +
					"RL_InvDb =  '" + Converter.fixString(RL_InvDb) +"', " +
					"RL_InvCompany = '" + Converter.fixString(RL_InvCompany) +"', " +
					"RL_InvPlant = '" + Converter.fixString(RL_InvPlant) +"', " +
					"RL_InvoiceN = '" + Converter.fixString(RL_InvoiceN) +"', " +
					"RL_InvoiceNum = " + NumberUtil.toString(RL_InvoiceNum) +", " +
					"RL_InvoiceItem = " + NumberUtil.toString(RL_InvoiceItem) +", " +
					"RL_BOLN = '" + Converter.fixString(RL_BOLN) +"', " +
					"RL_BOLNum = " + NumberUtil.toString(RL_BOLNum) +", " +
					"RL_BOLItem =" + NumberUtil.toString(RL_BOLItem)+ ", " +
					"RL_PayType = '" + Converter.fixString(RL_PayType) + "', " +
					"RL_PayDiff = " + NumberUtil.toString(RL_PayDiff) + ", " +
					"RL_PayD = '" + Converter.fixString(RL_PayD) + "', " +
					"RL_PriceDiff = " + NumberUtil.toString(RL_PriceDiff) + ", " +
					"RL_PriceD = '" + Converter.fixString(RL_PriceD) + "', " +
					"RL_CollectionGrp = '" + Converter.fixString(RL_CollectionGrp) + "', " +
					"RL_QtyDiff = " + NumberUtil.toString(RL_QtyDiff) +" " +
			"where " + 
				"ID = " + NumberUtil.toString(ID);
				
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
		string sql = "delete from arremlinkdetail where " +
				"ID = " + NumberUtil.toString(ID);
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
		string sql = "select * from arremlinkdetail where " + 
				"ID = " + NumberUtil.toString(ID);
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
    NotNullDataReader reader = null;
	try{
		bool ret = false;

		string sql = "select * from arremlinkdetail " + 
			"where " +
			"RL_RemDb = '" + Converter.fixString(RL_RemDb) +"' and " +
			"RL_LogNum= " + NumberUtil.toString(RL_LogNum) +" and " +
			"RL_EntryNum= " + NumberUtil.toString(RL_EntryNum) + " and " + 
			"RL_LineNum= " + NumberUtil.toString(RL_LineNum);

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

//Setters
public 
void setID(int ID){
   this.ID = ID;
}

public 
void setRL_RemDb(string RL_RemDb){
   this.RL_RemDb = RL_RemDb;
}

public 
void setRL_LogNum(int RL_LogNum){
   this.RL_LogNum = RL_LogNum;
}

public 
void setRL_EntryNum(int RL_EntryNum){
   this.RL_EntryNum = RL_EntryNum;
}

public 
void setRL_LineNum(int RL_LineNum){
   this.RL_LineNum = RL_LineNum;
}

public 
void setRL_DetailNum(int RL_DetailNum){
   this.RL_DetailNum = RL_DetailNum;
}

public 
void setRL_InvDb(string RL_InvDb){
   this.RL_InvDb = RL_InvDb;
}

public 
void setRL_InvCompany(string RL_InvCompany){
   this.RL_InvCompany = RL_InvCompany;
}

public 
void setRL_InvPlant(string RL_InvPlant){
   this.RL_InvPlant = RL_InvPlant;
}

public 
void setRL_InvoiceN(string RL_InvoiceN){
   this.RL_InvoiceN = RL_InvoiceN;
}

public 
void setRL_InvoiceNum(int RL_InvoiceNum){
   this.RL_InvoiceNum = RL_InvoiceNum;
}

public 
void setRL_InvoiceItem(int RL_InvoiceItem){
	this.RL_InvoiceItem = RL_InvoiceItem;
}

public 
void setRL_BOLN(string RL_BOLN){
   this.RL_BOLN = RL_BOLN;
}

public 
void setRL_BOLNum(int RL_BOLNum){
   this.RL_BOLNum = RL_BOLNum;
}

public 
void setRL_PayType(string RL_PayType){
   this.RL_PayType = RL_PayType;
}

public 
void setRL_PayDiff(decimal RL_PayDiff){
   this.RL_PayDiff = RL_PayDiff;
}

public 
void setRL_PayD(string RL_PayD){
   this.RL_PayD = RL_PayD;
}

public 
void setRL_PriceDiff(decimal RL_PriceDiff){
   this.RL_PriceDiff = RL_PriceDiff;
}

public 
void setRL_PriceD(string RL_PriceD){
   this.RL_PriceD = RL_PriceD;
}

public 
void setRL_CollectionGrp(string RL_CollectionGrp){
   this.RL_CollectionGrp = RL_CollectionGrp;
}

public 
void setRL_BOLItem(int RL_BOLItem){
	this.RL_BOLItem = RL_BOLItem;
}

public 
void setRL_QtyDiff(decimal RL_QtyDiff){
   this.RL_QtyDiff = RL_QtyDiff;
}


//Getters
public
int getID(){
   return ID;
}

public
string getRL_RemDb(){
   return RL_RemDb;
}

public
int getRL_LogNum(){
   return RL_LogNum;
}

public
int getRL_EntryNum(){
   return RL_EntryNum;
}

public
int getRL_LineNum(){
   return RL_LineNum;
}

public
int getRL_DetailNum(){
   return RL_DetailNum;
}

public int getRL_BOLItem(){
	return RL_BOLItem;
}

public
string getRL_InvDb(){
   return RL_InvDb;
}

public
string getRL_InvCompany(){
   return RL_InvCompany;
}

public
string getRL_InvPlant(){
   return RL_InvPlant;
}

public
string getRL_InvoiceN(){
   return RL_InvoiceN;
}

public
int getRL_InvoiceNum(){
   return RL_InvoiceNum;
}

public int getRL_InvoiceItem(){
	return RL_InvoiceItem;
}
public
string getRL_BOLN(){
   return RL_BOLN;
}

public
int getRL_BOLNum(){
   return RL_BOLNum;
}

public
string getRL_PayType(){
   return RL_PayType;
}

public
decimal getRL_PayDiff(){
   return RL_PayDiff;
}

public
string getRL_PayD(){
   return RL_PayD;
}

public
decimal getRL_PriceDiff(){
   return RL_PriceDiff;
}

public
string getRL_PriceD(){
   return RL_PriceD;
}

public
string getRL_CollectionGrp(){
   return RL_CollectionGrp;
}

public
decimal getRL_QtyDiff(){
   return RL_QtyDiff;
}

}//end class

}//end namespace
