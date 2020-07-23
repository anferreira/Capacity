using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class ArRemLinkShipDataBase: GenericDataBaseElement{

private int	ID;
private string ARLS_RemDB;
private int ARLS_LogNum;
private int ARLS_EntryNum;
private int ARLS_LineNum;
private string ARLS_BOLDb;
private string ARLS_Company;
private string ARLS_Plant;
private string ARLS_BolRef;
private int ARLS_BOLNum;
private string ARLS_InvRef;
private int ARLS_InvNum;
private string ARLS_PORef;
private string ARLS_CustAcct;
private string ARLS_Status;
private string ARLS_PayType;
private string ARLS_SentToERP;
private string ARLS_SupplierN;


public 
ArRemLinkShipDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.ID = reader.GetInt32("ID");
	this.ARLS_RemDB = reader.GetString("ARLS_RemDB");
	this.ARLS_LogNum = reader.GetInt32("ARLS_LogNum");
	this.ARLS_EntryNum = reader.GetInt32("ARLS_EntryNum");
	this.ARLS_LineNum = reader.GetInt32("ARLS_LineNum");
	this.ARLS_BOLDb = reader.GetString("ARLS_BOLDb");
	this.ARLS_Company = reader.GetString("ARLS_Company");
	this.ARLS_Plant = reader.GetString("ARLS_Plant");
	this.ARLS_BolRef = reader.GetString("ARLS_BolRef");
	this.ARLS_BOLNum = reader.GetInt32("ARLS_BOLNum");
	this.ARLS_InvRef = reader.GetString("ARLS_InvRef");
	this.ARLS_InvNum = reader.GetInt32("ARLS_InvNum");
	this.ARLS_PORef = reader.GetString("ARLS_PORef");
	this.ARLS_CustAcct = reader.GetString("ARLS_CustAcct");
	this.ARLS_Status = reader.GetString("ARLS_Status");
	this.ARLS_PayType = reader.GetString("ARLS_PayType");
	this.ARLS_SentToERP = reader.GetString("ARLS_SentToERP");
	this.ARLS_SupplierN = reader.GetString("ARLS_SupplierN");
}

public override
void write(){
	try{
		string sql = "insert into arremlinkship " +
		                "(ARLS_RemDB,ARLS_LogNum,ARLS_EntryNum,ARLS_LineNum,ARLS_BOLDb," +
		                " ARLS_Company,ARLS_Plant,ARLS_BolRef,ARLS_BOLNum,ARLS_InvRef," +
		                " ARLS_InvNum,ARLS_PORef,ARLS_CustAcct,ARLS_Status,ARLS_PayType," +
		                " ARLS_SentToERP,ARLS_SupplierN )" +
		        " values('" +
					Converter.fixString(ARLS_RemDB) +"', " + 
					NumberUtil.toString(ARLS_LogNum) +", " + 
					NumberUtil.toString(ARLS_EntryNum) +", " + 
					NumberUtil.toString(ARLS_LineNum) +", '" + 
					Converter.fixString(ARLS_BOLDb) +"', '" + 
					Converter.fixString(ARLS_Company) +"', '" + 
					Converter.fixString(ARLS_Plant) +"', '" + 
					Converter.fixString(ARLS_BolRef) +"', " + 
					NumberUtil.toString(ARLS_BOLNum) +", '" + 
					Converter.fixString(ARLS_InvRef) +"', " + 
					NumberUtil.toString(ARLS_InvNum) +", '" + 
					Converter.fixString(ARLS_PORef) +"', '" + 
					Converter.fixString(ARLS_CustAcct) +"', '" +
					Converter.fixString(ARLS_Status) +"', '" + 
					Converter.fixString(ARLS_PayType) +"', '" + 
					Converter.fixString(ARLS_SentToERP) +"', '" + 
					Converter.fixString(ARLS_SupplierN) +"')"; 	
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
		string sql = "update arremlinkship set " +
					"ARLS_RemDB = '" + Converter.fixString(ARLS_RemDB) + "', " +
					"ARLS_LogNum = " + NumberUtil.toString(ARLS_LogNum) + ", " +
					"ARLS_EntryNum = " + NumberUtil.toString(ARLS_EntryNum) + ", " +
					"ARLS_LineNum = " + NumberUtil.toString(ARLS_LineNum) + ", " +
					"ARLS_BOLDb = '" + Converter.fixString(ARLS_BOLDb) + "', " +
					"ARLS_Company = '" + Converter.fixString(ARLS_Company) + "', " +
					"ARLS_Plant = '" + Converter.fixString(ARLS_Plant) + "', " +
					"ARLS_BolRef = '" + Converter.fixString(ARLS_BolRef) + "', " +
					"ARLS_BOLNum = " + NumberUtil.toString(ARLS_BOLNum) + ", " +
					"ARLS_InvRef = '" + Converter.fixString(ARLS_InvRef) + "', " +
					"ARLS_InvNum = " + NumberUtil.toString(ARLS_InvNum) + ", " +
					"ARLS_PORef = '" + Converter.fixString(ARLS_PORef) + "', " +
					"ARLS_CustAcct = '" + Converter.fixString(ARLS_CustAcct) + "', " +
					"ARLS_Status = '" + Converter.fixString(ARLS_Status) + "', " +
					"ARLS_PayType = '" + Converter.fixString(ARLS_PayType) + "', " +
					"ARLS_SentToERP = '" + Converter.fixString(ARLS_SentToERP) + "', " +
					"ARLS_SupplierN = '" + Converter.fixString(ARLS_SupplierN) + "' " +
			" where " +
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
		string sql = "delete from arremlinkship " +
				" where " +
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
		string sql = "select * from arremlinkship " + 
				"where " +
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
    NotNullDataReader  reader = null;
	try{
		bool ret = false;

		string sql = "select * from arremlinkship " + 
			"where " +
			"ARLS_RemDb = '" + Converter.fixString(ARLS_RemDB) +"' and " +
			"ARLS_LogNum= " + NumberUtil.toString(ARLS_LogNum) +" and " +
			"ARLS_EntryNum= " + NumberUtil.toString(ARLS_EntryNum) + " and " + 
			"ARLS_LineNum= " + NumberUtil.toString(ARLS_LineNum);

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
void setID(int	ID){
   this.ID = ID;
}

public 
void setARLS_RemDB(string ARLS_RemDB){
   this.ARLS_RemDB = ARLS_RemDB;
}

public 
void setARLS_LogNum(int ARLS_LogNum){
   this.ARLS_LogNum = ARLS_LogNum;
}

public 
void setARLS_EntryNum(int ARLS_EntryNum){
   this.ARLS_EntryNum = ARLS_EntryNum;
}

public 
void setARLS_LineNum(int ARLS_LineNum){
   this.ARLS_LineNum = ARLS_LineNum;
}

public 
void setARLS_BolRef(string ARLS_BolRef){
   this.ARLS_BolRef = ARLS_BolRef;
}

public 
void setARLS_BOLNum(int ARLS_BOLNum){
   this.ARLS_BOLNum = ARLS_BOLNum;
}

public 
void setARLS_InvRef(string ARLS_InvRef){
   this.ARLS_InvRef = ARLS_InvRef;
}

public 
void setARLS_InvNum(int ARLS_InvNum){
   this.ARLS_InvNum = ARLS_InvNum;
}

public 
void setARLS_PORef(string ARLS_PORef){
   this.ARLS_PORef = ARLS_PORef;
}

public 
void setARLS_CustAcct(string ARLS_CustAcct){
   this.ARLS_CustAcct = ARLS_CustAcct;
}



public void setARLS_BOLDb(string ARLS_BOLDb){
   this.ARLS_BOLDb = ARLS_BOLDb;
}

public 
void setARLS_Company(string ARLS_Company){
   this.ARLS_Company = ARLS_Company;
}

public 
void setARLS_Plant(string ARLS_Plant){
   this.ARLS_Plant = ARLS_Plant;
}

public 
void setARLS_Status(string ARLS_Status){
   this.ARLS_Status = ARLS_Status;
}

public 
void setARLS_PayType(string ARLS_PayType){
   this.ARLS_PayType = ARLS_PayType;
}

public 
void setARLS_SentToERP(string ARLS_SentToERP){
   this.ARLS_SentToERP = ARLS_SentToERP;
}

public 
void setARLS_SupplierN(string ARLS_SupplierN){
   this.ARLS_SupplierN = ARLS_SupplierN;
}


//Getters
public
int	getID(){
   return ID;
}

public
string getARLS_RemDB(){
   return ARLS_RemDB;
}

public
int getARLS_LogNum(){
   return ARLS_LogNum;
}

public
int getARLS_EntryNum(){
   return ARLS_EntryNum;
}

public
int getARLS_LineNum(){
   return ARLS_LineNum;
}

public
string getARLS_BolRef(){
   return ARLS_BolRef;
}

public
int getARLS_BOLNum(){
   return ARLS_BOLNum;
}

public
string getARLS_InvRef(){
   return ARLS_InvRef;
}

public
int getARLS_InvNum(){
   return ARLS_InvNum;
}

public
string getARLS_PORef(){
   return ARLS_PORef;
}

public
string getARLS_CustAcct(){
   return ARLS_CustAcct;
}


public
string getARLS_BOLDb(){
   return ARLS_BOLDb;
}

public
string getARLS_Company(){
   return ARLS_Company;
}

public
string getARLS_Plant(){
   return ARLS_Plant;
}

public
string getARLS_Status(){
   return ARLS_Status;
}

public
string getARLS_PayType(){
   return ARLS_PayType;
}

public
string getARLS_SentToERP(){
   return ARLS_SentToERP;
}

public
string getARLS_SupplierN(){
   return ARLS_SupplierN;
}

}//end class

}//end namespace
