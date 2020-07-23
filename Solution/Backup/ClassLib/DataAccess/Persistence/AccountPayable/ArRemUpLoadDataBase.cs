using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class ArRemUpLoadDataBase : GenericDataBaseElement{

private int ID;
private string ARUL_DB;
private DateTime ARUL_DateTime;
private int ARUL_LogNum;
private int ARUL_EntNum;
private string ARUL_Cheque;
private int ARUL_InvoiceNum;
private string ARUL_InvoiceN;

public 
ArRemUpLoadDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
    this.ID = reader.GetInt32("ID");
    this.ARUL_DB = reader.GetString("ARUL_DB");
    this.ARUL_DateTime = reader.GetDateTime("ARUL_DateTime");
    this.ARUL_LogNum = reader.GetInt32("ARUL_LogNum");
    this.ARUL_EntNum = reader.GetInt32("ARUL_EntNum");
    this.ARUL_Cheque = reader.GetString("ARUL_Cheque");
    this.ARUL_InvoiceNum = reader.GetInt32("ARUL_InvoiceNum");
    this.ARUL_InvoiceN = reader.GetString("ARUL_InvoiceN");
}

public override
void write(){
	try{
		string sql = "insert into arremupload " +
		                        "(ARUL_DB,ARUL_DateTime,ARUL_LogNum,ARUL_EntNum,ARUL_Cheque,"+ 
		                        " ARUL_InvoiceNum,ARUL_InvoiceN)" +
		            " values('" +
                        Converter.fixString(ARUL_DB) +"', '" +
                        DateUtil.getCompleteDateRepresentation(ARUL_DateTime) +"', " +
                        NumberUtil.toString(ARUL_LogNum) +", " +
                        NumberUtil.toString(ARUL_EntNum) +", '" +
                        Converter.fixString(ARUL_Cheque) +"', " +
                        NumberUtil.toString(ARUL_InvoiceNum) +", '" +
                        Converter.fixString(ARUL_InvoiceN) +"')";
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
		string sql = "update arremupload set " +
                        "ARUL_DB = '" + Converter.fixString(ARUL_DB) +"', " +
                        "ARUL_DateTime = '" + DateUtil.getCompleteDateRepresentation(ARUL_DateTime) +"', " +
                        "ARUL_LogNum = " + NumberUtil.toString(ARUL_LogNum) +", " +
                        "ARUL_EntNum = " + NumberUtil.toString(ARUL_EntNum) +", " +
                        "ARUL_Cheque = '" + Converter.fixString(ARUL_Cheque) +"', " +
                        "ARUL_InvoiceNum = " + NumberUtil.toString(ARUL_InvoiceNum) +", " +
                        "ARUL_InvoiceN = '" + Converter.fixString(ARUL_InvoiceN) +"' " +
			        "where " + 
				            "ID = " + ID;
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
		string sql = "delete arremupload  " +
			 "where " + 
				"ID = " + ID;
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message,mySqlExc);
	}
}

//Setters
public 
void setID (int ID){
    this.ID = ID;
}

public 
void setARUL_DB (string ARUL_DB){
    this.ARUL_DB = ARUL_DB;
}

public 
void setARUL_DateTime (DateTime ARUL_DateTime){
    this.ARUL_DateTime = ARUL_DateTime;
}

public 
void setARUL_LogNum (int ARUL_LogNum){
    this.ARUL_LogNum = ARUL_LogNum;
}

public 
void setARUL_EntNum (int ARUL_EntNum){
    this.ARUL_EntNum = ARUL_EntNum;
}

public 
void setARUL_Cheque (string ARUL_Cheque){
    this.ARUL_Cheque = ARUL_Cheque;
}

public 
void setARUL_InvoiceNum (int ARUL_InvoiceNum){
    this.ARUL_InvoiceNum = ARUL_InvoiceNum;
}

public 
void setARUL_InvoiceN (string ARUL_InvoiceN){
    this.ARUL_InvoiceN = ARUL_InvoiceN;
}


//Getters
public 
int getID(){
    return ID;
}

public 
string getARUL_DB(){
    return ARUL_DB;
}

public 
DateTime getARUL_DateTime(){
    return ARUL_DateTime;
}

public 
int getARUL_LogNum(){
    return ARUL_LogNum;
}

public 
int getARUL_EntNum(){
    return ARUL_EntNum;
}

public 
string getARUL_Cheque(){
    return ARUL_Cheque;
}

public 
int getARUL_InvoiceNum(){
    return ARUL_InvoiceNum;
}

public 
string getARUL_InvoiceN(){
    return ARUL_InvoiceN;
}

}//end class

}//end namespace
