using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
	
public 
class RemittanceHdrDataBase	: GenericDataBaseElement{

private int ID;
private string RH_Db;
private int RH_LogNum;
private int RH_EntNum;
private string RH_DocCtlNum	;
private DateTime RH_PayTime;
private string RH_TransType;
private decimal RH_RemitAmt;
private string RH_DebCredit;
private string RH_PayMethType;
private string RH_PayFormat;
private string RH_RDFIType;
private string RH_RDFINum;
private string RH_AccNum;
private string RH_ReceiveAcc;
private DateTime RH_SettleDate;
private string RH_LockNum;
private string RH_Ref1;
private string RH_Ref2;
private string RH_Ref3;
private string RH_Ref4;
private string RH_Ref5;
private string RH_RefDesc;
private string RH_PayID;
private string RH_PayName;
private string RH_FinType;
private string RH_FinanceID;
private string RH_FinName;
private string RH_PayType;
private string RH_PayingID;
private string RH_PayingName;
private string RH_PayingCon;
private string RH_PayingPH;
private string RH_TraceType;
private string RH_TraceNum;
private string RH_Currency;
private DateTime RH_LiabilityDate;
private DateTime RH_TransDate;
private DateTime RH_CheckDate;
private string RH_CheckRef;
private decimal RH_CheckRefNum;
private string RH_BillToCust;
private string RH_ProcessYN;
private decimal RH_BatchNum;
private string RH_TPartner;
private string RH_Process;
private DateTime RH_DateProcess;
private string RH_UserProcess;
private string RH_SendToCMS;

public 
RemittanceHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.ID = reader.GetInt32("ID");
	this.RH_Db = reader.GetString("RH_Db");
	this.RH_LogNum = reader.GetInt32("RH_LogNum");
	this.RH_EntNum = reader.GetInt32("RH_EntNum");
	this.RH_DocCtlNum	 = reader.GetString("RH_DocCtlNum");
	this.RH_PayTime = reader.GetDateTime("RH_PayTime");
	this.RH_TransType = reader.GetString("RH_TransType");
	this.RH_RemitAmt = reader.GetDecimal("RH_RemitAmt");
	this.RH_DebCredit = reader.GetString("RH_DebCredit");
	this.RH_PayMethType = reader.GetString("RH_PayMethType");
	this.RH_PayFormat = reader.GetString("RH_PayFormat");
	this.RH_RDFIType = reader.GetString("RH_RDFIType");
	this.RH_RDFINum = reader.GetString("RH_RDFINum");
	this.RH_AccNum = reader.GetString("RH_AccNum");
	this.RH_ReceiveAcc = reader.GetString("RH_ReceiveAcc");
	this.RH_SettleDate = reader.GetDateTime("RH_SettleDate");
	this.RH_LockNum = reader.GetString("RH_LockNum");
	this.RH_Ref1 = reader.GetString("RH_Ref1");
	this.RH_Ref2 = reader.GetString("RH_Ref2");
	this.RH_Ref3 = reader.GetString("RH_Ref3");
	this.RH_Ref4 = reader.GetString("RH_Ref4");
	this.RH_Ref5 = reader.GetString("RH_Ref5");
	this.RH_RefDesc = reader.GetString("RH_RefDesc");
	this.RH_PayID = reader.GetString("RH_PayID");
	this.RH_PayName = reader.GetString("RH_PayName");
	this.RH_FinType = reader.GetString("RH_FinType");
	this.RH_FinanceID = reader.GetString("RH_FinanceID");
	this.RH_FinName = reader.GetString("RH_FinName");
	this.RH_PayType = reader.GetString("RH_PayType");
	this.RH_PayingID = reader.GetString("RH_PayingID");
	this.RH_PayingName = reader.GetString("RH_PayingName");
	this.RH_PayingCon = reader.GetString("RH_PayingCon");
	this.RH_PayingPH = reader.GetString("RH_PayingPH");
	this.RH_TraceType = reader.GetString("RH_TraceType");
	this.RH_TraceNum = reader.GetString("RH_TraceNum");
	this.RH_Currency = reader.GetString("RH_Currency");
	this.RH_LiabilityDate = reader.GetDateTime("RH_LiabilityDate");
	this.RH_TransDate = reader.GetDateTime("RH_TransDate");
	this.RH_CheckDate = reader.GetDateTime("RH_CheckDate");
	this.RH_CheckRef = reader.GetString("RH_CheckRef");
	this.RH_CheckRefNum = reader.GetDecimal("RH_CheckRefNum");
	this.RH_BillToCust = reader.GetString("RH_BillToCust");
	this.RH_ProcessYN = reader.GetString("RH_ProcessYN");
	this.RH_BatchNum = reader.GetDecimal("RH_BatchNum");
	this.RH_TPartner = reader.GetString("RH_TPartner");	
	this.RH_Process = reader.GetString("RH_Process");
	this.RH_DateProcess = reader.GetDateTime("RH_DateProcess");
	this.RH_UserProcess = reader.GetString("RH_UserProcess");
	this.RH_SendToCMS = reader.GetString("RH_SendToCMS");
}

public
void loadTraceNum(NotNullDataReader reader){
	this.RH_TraceNum = reader.GetString("RH_TraceNum");
}

public
void loadTPartner(NotNullDataReader reader){
	this.RH_TPartner = reader.GetString("RH_TPartner");
}

public
void loadEntryNumber(NotNullDataReader reader){
	this.RH_EntNum = reader.GetInt32("RH_EntNum");
}

public
void loadLogNumber(NotNullDataReader reader){
	this.RH_LogNum = reader.GetInt32("RH_LogNum");
}

public override
void write(){
    try{
		string sql = "insert into remittancehdr " +
		            "(RH_Db,RH_LogNum,RH_EntNum,RH_DocCtlNum,RH_PayTime,RH_TransType,"+
		            " RH_RemitAmt,RH_DebCredit,RH_PayMethType,RH_PayFormat,RH_RDFIType,"+
		            " RH_RDFINum,RH_AccNum,RH_ReceiveAcc,RH_SettleDate,RH_LockNum,RH_Ref1,"+
		            " RH_Ref2,RH_Ref3,RH_Ref4,RH_Ref5,RH_RefDesc,RH_PayID,RH_PayName,RH_FinType,"+
		            " RH_FinanceID,RH_FinName,RH_PayType,RH_PayingID,RH_PayingName,RH_PayingCon,"+          
		            " RH_PayingPH,RH_TraceType,RH_TraceNum,RH_Currency,RH_LiabilityDate,"+
		            " RH_TransDate,RH_CheckDate,RH_CheckRef,RH_CheckRefNum,RH_BillToCust,"+
		            " RH_ProcessYN,RH_BatchNum,RH_TPartner,RH_Process,RH_DateProcess,"+
		            " RH_UserProcess,RH_SendToCMS)" +
		        " values('" +
				    Converter.fixString(RH_Db) +"' , " +
				    NumberUtil.toString(RH_LogNum) +" , " +
				    NumberUtil.toString(RH_EntNum) +" , '" +
				    Converter.fixString(RH_DocCtlNum) +"' , '" +
				    DateUtil.getCompleteDateRepresentation(RH_PayTime) +"' , '" +
				    Converter.fixString(RH_TransType) +"' , " +
				    NumberUtil.toString(RH_RemitAmt) +" , '" +
				    Converter.fixString(RH_DebCredit) +"' , '" +
				    Converter.fixString(RH_PayMethType) +"' , '" +
				    Converter.fixString(RH_PayFormat) +"' , '" +
				    Converter.fixString(RH_RDFIType) +"' , '" +
				    Converter.fixString(RH_RDFINum) +"' , '" +
				    Converter.fixString(RH_AccNum) +"' , '" +
				    Converter.fixString(RH_ReceiveAcc) +"' , '" +
				    DateUtil.getCompleteDateRepresentation(RH_SettleDate) +"' , '" +
				    Converter.fixString(RH_LockNum) +"' , '" +
				    Converter.fixString(RH_Ref1) +"' , '" +
				    Converter.fixString(RH_Ref2) +"' , '" +
				    Converter.fixString(RH_Ref3) +"' , '" +
				    Converter.fixString(RH_Ref4) +"' , '" +
				    Converter.fixString(RH_Ref5) +"' , '" +
				    Converter.fixString(RH_RefDesc) +"' , '" +
				    Converter.fixString(RH_PayID) +"' , '" +
				    Converter.fixString(RH_PayName) +"' , '" +
				    Converter.fixString(RH_FinType) +"' , '" +
				    Converter.fixString(RH_FinanceID) +"' , '" +
				    Converter.fixString(RH_FinName) +"' , '" +
				    Converter.fixString(RH_PayType) +"' , '" +
				    Converter.fixString(RH_PayingID) +"' , '" +
				    Converter.fixString(RH_PayingName) +"' , '" +
				    Converter.fixString(RH_PayingCon) +"' , '" +
				    Converter.fixString(RH_PayingPH) +"' , '" +
				    Converter.fixString(RH_TraceType) +"' , '" +
				    Converter.fixString(RH_TraceNum) +"' , '" +
				    Converter.fixString(RH_Currency) +"' , '" +
				    DateUtil.getCompleteDateRepresentation(RH_LiabilityDate) +"' , '" +
				    DateUtil.getCompleteDateRepresentation(RH_TransDate) +"' , '" +
				    DateUtil.getCompleteDateRepresentation(RH_CheckDate) +"' , '" +
				    Converter.fixString(RH_CheckRef) +"' , " +
				    NumberUtil.toString(RH_CheckRefNum) +" , '" +
				    Converter.fixString(RH_BillToCust) +"' , '" +
				    Converter.fixString(RH_ProcessYN) +"' , " +
				    NumberUtil.toString(RH_BatchNum) +" , '" +
				    Converter.fixString(RH_TPartner)+ "', '" +
				    Converter.fixString(RH_Process)+ "', '" +
				    DateUtil.getCompleteDateRepresentation(RH_DateProcess)+ "', '" +
				    Converter.fixString(RH_UserProcess)+ "', '" +
				    Converter.fixString(RH_SendToCMS)+"')";
    							
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
		string sql = "update remittancehdr set " +
				"RH_Process = '" +Converter.fixString(RH_Process) + "', " +
				"RH_DateProcess = '" + DateUtil.getCompleteDateRepresentation(RH_DateProcess) + "' " +
			"where " + 
				"ID = '" + NumberUtil.toString(ID) +"'";
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
	throw new PersistenceException("Method not implemented");
}

public
void read(){
	throw new PersistenceException("Method not implemented");
}


public
bool exists(){
    NotNullDataReader reader = null;
	try{
		bool ret = false;

		string sql = "select * from remittancehdr " + 
			"where " +
			"RH_Db = '" + Converter.fixString(RH_Db) +"' and " +
			"RH_LogNum = " + NumberUtil.toString(RH_LogNum) +" and " +
			"RH_EntNum = " + NumberUtil.toString(RH_EntNum);

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
void setRH_Db(string RH_Db){
   this.RH_Db = RH_Db;
}

public 
void setRH_LogNum(int RH_LogNum){
   this.RH_LogNum = RH_LogNum;
}

public 
void setRH_EntNum(int RH_EntNum){
   this.RH_EntNum = RH_EntNum;
}

public 
void setRH_DocCtlNum	(string RH_DocCtlNum	){
   this.RH_DocCtlNum	 = RH_DocCtlNum	;
}

public 
void setRH_PayTime(DateTime RH_PayTime){
   this.RH_PayTime = RH_PayTime;
}

public 
void setRH_TransType(string RH_TransType){
   this.RH_TransType = RH_TransType;
}

public 
void setRH_RemitAmt(decimal RH_RemitAmt){
   this.RH_RemitAmt = RH_RemitAmt;
}

public 
void setRH_DebCredit(string RH_DebCredit){
   this.RH_DebCredit = RH_DebCredit;
}

public 
void setRH_PayMethType(string RH_PayMethType){
   this.RH_PayMethType = RH_PayMethType;
}

public 
void setRH_PayFormat(string RH_PayFormat){
   this.RH_PayFormat = RH_PayFormat;
}

public 
void setRH_RDFIType(string RH_RDFIType){
   this.RH_RDFIType = RH_RDFIType;
}

public 
void setRH_RDFINum(string RH_RDFINum){
   this.RH_RDFINum = RH_RDFINum;
}

public 
void setRH_AccNum(string RH_AccNum){
   this.RH_AccNum = RH_AccNum;
}

public 
void setRH_ReceiveAcc(string RH_ReceiveAcc){
   this.RH_ReceiveAcc = RH_ReceiveAcc;
}

public 
void setRH_SettleDate(DateTime RH_SettleDate){
   this.RH_SettleDate = RH_SettleDate;
}

public 
void setRH_LockNum(string RH_LockNum){
   this.RH_LockNum = RH_LockNum;
}

public 
void setRH_Ref1(string RH_Ref1){
   this.RH_Ref1 = RH_Ref1;
}

public 
void setRH_Ref2(string RH_Ref2){
   this.RH_Ref2 = RH_Ref2;
}

public 
void setRH_Ref3(string RH_Ref3){
   this.RH_Ref3 = RH_Ref3;
}

public 
void setRH_Ref4(string RH_Ref4){
   this.RH_Ref4 = RH_Ref4;
}

public 
void setRH_Ref5(string RH_Ref5){
   this.RH_Ref5 = RH_Ref5;
}

public 
void setRH_RefDesc(string RH_RefDesc){
   this.RH_RefDesc = RH_RefDesc;
}

public 
void setRH_PayID(string RH_PayID){
   this.RH_PayID = RH_PayID;
}

public 
void setRH_PayName(string RH_PayName){
   this.RH_PayName = RH_PayName;
}

public 
void setRH_FinType(string RH_FinType){
   this.RH_FinType = RH_FinType;
}

public 
void setRH_FinanceID(string RH_FinanceID){
   this.RH_FinanceID = RH_FinanceID;
}

public 
void setRH_FinName(string RH_FinName){
   this.RH_FinName = RH_FinName;
}

public 
void setRH_PayType(string RH_PayType){
   this.RH_PayType = RH_PayType;
}

public 
void setRH_PayingID(string RH_PayingID){
   this.RH_PayingID = RH_PayingID;
}

public 
void setRH_PayingName(string RH_PayingName){
   this.RH_PayingName = RH_PayingName;
}

public 
void setRH_PayingCon(string RH_PayingCon){
   this.RH_PayingCon = RH_PayingCon;
}

public 
void setRH_PayingPH(string RH_PayingPH){
   this.RH_PayingPH = RH_PayingPH;
}

public 
void setRH_TraceType(string RH_TraceType){
   this.RH_TraceType = RH_TraceType;
}

public 
void setRH_TraceNum(string RH_TraceNum){
   this.RH_TraceNum = RH_TraceNum;
}

public 
void setRH_Currency(string RH_Currency){
   this.RH_Currency = RH_Currency;
}

public 
void setRH_LiabilityDate(DateTime RH_LiabilityDate){
   this.RH_LiabilityDate = RH_LiabilityDate;
}

public 
void setRH_TransDate(DateTime RH_TransDate){
   this.RH_TransDate = RH_TransDate;
}

public 
void setRH_CheckDate(DateTime RH_CheckDate){
   this.RH_CheckDate = RH_CheckDate;
}

public 
void setRH_CheckRef(string RH_CheckRef){
   this.RH_CheckRef = RH_CheckRef;
}

public 
void setRH_CheckRefNum(decimal RH_CheckRefNum){
   this.RH_CheckRefNum = RH_CheckRefNum;
}

public 
void setRH_BillToCust(string RH_BillToCust){
   this.RH_BillToCust = RH_BillToCust;
}

public 
void setRH_ProcessYN(string RH_ProcessYN){
   this.RH_ProcessYN = RH_ProcessYN;
}

public 
void setRH_BatchNum(decimal RH_BatchNum){
   this.RH_BatchNum = RH_BatchNum;
}

public 
void setRH_TPartner(string RH_TPartner){
   this.RH_TPartner = RH_TPartner;
}

public 
void setRH_Process(string RH_Process){
   this.RH_Process = RH_Process;
}

public 
void setRH_DateProcess(DateTime RH_DateProcess){
   this.RH_DateProcess = RH_DateProcess;
}

public 
void setRH_UserProcess(string RH_UserProcess){
   this.RH_UserProcess = RH_UserProcess;
}

public 
void setRH_SendToCMS(string RH_SendToCMS){
   this.RH_SendToCMS = RH_SendToCMS;
}


//Getters
public
string getRH_Db(){
   return RH_Db;
}

public
int getRH_LogNum(){
   return RH_LogNum;
}

public
int getRH_EntNum(){
   return RH_EntNum;
}

public
string getRH_DocCtlNum	(){
   return RH_DocCtlNum	;
}

public
DateTime getRH_PayTime(){
   return RH_PayTime;
}

public
string getRH_TransType(){
   return RH_TransType;
}

public
decimal getRH_RemitAmt(){
   return RH_RemitAmt;
}

public
string getRH_DebCredit(){
   return RH_DebCredit;
}

public
string getRH_PayMethType(){
   return RH_PayMethType;
}

public
string getRH_PayFormat(){
   return RH_PayFormat;
}

public
string getRH_RDFIType(){
   return RH_RDFIType;
}

public
string getRH_RDFINum(){
   return RH_RDFINum;
}

public
string getRH_AccNum(){
   return RH_AccNum;
}

public
string getRH_ReceiveAcc(){
   return RH_ReceiveAcc;
}

public
DateTime getRH_SettleDate(){
   return RH_SettleDate;
}

public
string getRH_LockNum(){
   return RH_LockNum;
}

public
string getRH_Ref1(){
   return RH_Ref1;
}

public
string getRH_Ref2(){
   return RH_Ref2;
}

public
string getRH_Ref3(){
   return RH_Ref3;
}

public
string getRH_Ref4(){
   return RH_Ref4;
}

public
string getRH_Ref5(){
   return RH_Ref5;
}

public
string getRH_RefDesc(){
   return RH_RefDesc;
}

public
string getRH_PayID(){
   return RH_PayID;
}

public
string getRH_PayName(){
   return RH_PayName;
}

public
string getRH_FinType(){
   return RH_FinType;
}

public
string getRH_FinanceID(){
   return RH_FinanceID;
}

public
string getRH_FinName(){
   return RH_FinName;
}

public
string getRH_PayType(){
   return RH_PayType;
}

public
string getRH_PayingID(){
   return RH_PayingID;
}

public
string getRH_PayingName(){
   return RH_PayingName;
}

public
string getRH_PayingCon(){
   return RH_PayingCon;
}

public
string getRH_PayingPH(){
   return RH_PayingPH;
}

public
string getRH_TraceType(){
   return RH_TraceType;
}

public
string getRH_TraceNum(){
   return RH_TraceNum;
}

public
string getRH_Currency(){
   return RH_Currency;
}

public
DateTime getRH_LiabilityDate(){
   return RH_LiabilityDate;
}

public
DateTime getRH_TransDate(){
   return RH_TransDate;
}

public
DateTime getRH_CheckDate(){
   return RH_CheckDate;
}

public
string getRH_CheckRef(){
   return RH_CheckRef;
}

public
decimal getRH_CheckRefNum(){
   return RH_CheckRefNum;
}

public
string getRH_BillToCust(){
   return RH_BillToCust;
}

public
string getRH_ProcessYN(){
   return RH_ProcessYN;
}

public
decimal getRH_BatchNum(){
   return RH_BatchNum;
}

public
string getRH_TPartner(){
   return RH_TPartner;
}

public
string getRH_Process(){
   return RH_Process;
}

public
DateTime getRH_DateProcess(){
   return RH_DateProcess;
}

public
string getRH_UserProcess(){
   return RH_UserProcess;
}

public
string getRH_SendToCMS(){
   return RH_SendToCMS;
}

}//end class

}//end namespace
