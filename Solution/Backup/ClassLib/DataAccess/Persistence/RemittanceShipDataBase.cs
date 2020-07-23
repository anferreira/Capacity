using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
	
public 
class RemittanceShipDataBase: GenericDataBaseElement{

private int ID;
private string RS_Db;
private int	RS_LogNum;
private int	RS_EntryNum;
private int	RS_LineNum;
private string RS_BOLReceived;
private decimal	RS_BOLActual;
private decimal RS_InvActual;
private string RS_InvSent;
private string RS_POSent;
private string RS_CustAcc;
private string RS_CheckRef;
private decimal	RS_GrossAmt;
private decimal	RS_DiscAmt;
private decimal	RS_DiscPer;
private decimal	RS_GSTAmt;
private decimal	RS_NetAmtPaid;
private decimal	RS_RemitAmt;
private decimal	RS_PayAmt;
private string RS_OtherAmtQu1;
private decimal	RS_OtherAmt1;
private string RS_OtherAmtQu2;
private decimal	RS_OtherAmt2;
private string RS_Ref1;
private string RS_Ref2;
private string RS_Ref3;
private string RS_Ref4;
private DateTime RS_LiabilityDate;
private DateTime RS_IssueDate;
private DateTime RS_InvDate;
private string RS_CheckNum;
private string RS_BillToCust;
private string RS_ShipToCust;
private string RS_ShipType;
private string RS_ProcessYN;
private decimal	RS_PstAmt;
private decimal	RS_AdjAmt;
private string RS_Process;
private string RS_Linked;
private string RS_SentToERP;
private DateTime RS_DateSentToERP;
private string RS_ERPDebitNote;
private string RS_DebitNote;

//RemittanceHdr fileds
private string RH_PayID;
private string RH_TPartner;
private string RH_PayingPH;


public 
RemittanceShipDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.ID = reader.GetInt32("ID");
	this.RS_Db = reader.GetString("RS_Db");
	this.RS_LogNum = reader.GetInt32("RS_LogNum");
	this.RS_EntryNum = reader.GetInt32("RS_EntryNum");
	this.RS_LineNum = reader.GetInt32("RS_LineNum");
	this.RS_BOLReceived = reader.GetString("RS_BOLReceived");
	this.RS_BOLActual = reader.GetDecimal("RS_BOLActual");
	this.RS_InvActual = reader.GetDecimal("RS_InvActual");
	this.RS_InvSent = reader.GetString("RS_InvSent");
	this.RS_POSent = reader.GetString("RS_POSent");
	this.RS_CustAcc = reader.GetString("RS_CustAcc");
	this.RS_CheckRef = reader.GetString("RS_CheckRef");
	this.RS_GrossAmt = reader.GetDecimal("RS_GrossAmt");
	this.RS_DiscAmt = reader.GetDecimal("RS_DiscAmt");
	this.RS_DiscPer = reader.GetDecimal("RS_DiscPer");
	this.RS_GSTAmt = reader.GetDecimal("RS_GSTAmt");
	this.RS_NetAmtPaid = reader.GetDecimal("RS_NetAmtPaid");
	this.RS_RemitAmt = reader.GetDecimal("RS_RemitAmt");
	this.RS_PayAmt = reader.GetDecimal("RS_PayAmt");
	this.RS_OtherAmtQu1 = reader.GetString("RS_OtherAmtQu1");
	this.RS_OtherAmt1 = reader.GetDecimal("RS_OtherAmt1");
	this.RS_OtherAmtQu2 = reader.GetString("RS_OtherAmtQu2");
	this.RS_OtherAmt2 = reader.GetDecimal("RS_OtherAmt2");
	this.RS_Ref1 = reader.GetString("RS_Ref1");
	this.RS_Ref2 = reader.GetString("RS_Ref2");
	this.RS_Ref3 = reader.GetString("RS_Ref3");
	this.RS_Ref4 = reader.GetString("RS_Ref4");
	this.RS_LiabilityDate = reader.GetDateTime("RS_LiabilityDate");
	this.RS_IssueDate = reader.GetDateTime("RS_IssueDate");
	this.RS_InvDate = reader.GetDateTime("RS_InvDate");
	this.RS_CheckNum = reader.GetString("RS_CheckNum");
	this.RS_BillToCust = reader.GetString("RS_BillToCust");
	this.RS_ShipToCust = reader.GetString("RS_ShipToCust");
	this.RS_ShipType = reader.GetString("RS_ShipType");
	this.RS_ProcessYN = reader.GetString("RS_ProcessYN");
	this.RS_PstAmt = reader.GetDecimal("RS_PstAmt");
	this.RS_AdjAmt = reader.GetDecimal("RS_AdjAmt");
	this.RS_Process = reader.GetString("RS_Process");
	this.RS_Linked = reader.GetString("RS_Linked");
	this.RS_SentToERP = reader.GetString("RS_SentToERP");
	this.RS_DateSentToERP = reader.GetDateTime("RS_DateSentToERP");
	this.RS_ERPDebitNote = reader.GetString("RS_ERPDebitNote");
	this.RS_DebitNote = reader.GetString("RS_DebitNote");
}

public
void loadWithHdr(NotNullDataReader reader){
	this.RS_Db = reader.GetString("RS_Db");
	this.RS_LogNum = reader.GetInt32("RS_LogNum");
	this.RS_EntryNum = reader.GetInt32("RS_EntryNum");
	this.RS_LineNum = reader.GetInt32("RS_LineNum");
	this.RS_BOLReceived = reader.GetString("RS_BOLReceived");
	this.RS_BOLActual = reader.GetDecimal("RS_BOLActual");
	this.RS_InvActual = reader.GetDecimal("RS_InvActual");
	this.RS_InvSent = reader.GetString("RS_InvSent");
	this.RS_POSent = reader.GetString("RS_POSent");
	this.RS_CustAcc = reader.GetString("RS_CustAcc");
	this.RS_CheckRef = reader.GetString("RS_CheckRef");
	this.RS_GrossAmt = reader.GetDecimal("RS_GrossAmt");
	this.RS_DiscAmt = reader.GetDecimal("RS_DiscAmt");
	this.RS_DiscPer = reader.GetDecimal("RS_DiscPer");
	this.RS_GSTAmt = reader.GetDecimal("RS_GSTAmt");
	this.RS_NetAmtPaid = reader.GetDecimal("RS_NetAmtPaid");
	this.RS_RemitAmt = reader.GetDecimal("RS_RemitAmt");
	this.RS_PayAmt = reader.GetDecimal("RS_PayAmt");
	this.RS_OtherAmtQu1 = reader.GetString("RS_OtherAmtQu1");
	this.RS_OtherAmt1 = reader.GetDecimal("RS_OtherAmt1");
	this.RS_OtherAmtQu2 = reader.GetString("RS_OtherAmtQu2");
	this.RS_OtherAmt2 = reader.GetDecimal("RS_OtherAmt2");
	this.RS_Ref1 = reader.GetString("RS_Ref1");
	this.RS_Ref2 = reader.GetString("RS_Ref2");
	this.RS_Ref3 = reader.GetString("RS_Ref3");
	this.RS_Ref4 = reader.GetString("RS_Ref4");
	this.RS_LiabilityDate = reader.GetDateTime("RS_LiabilityDate");
	this.RS_IssueDate = reader.GetDateTime("RS_IssueDate");
	this.RS_InvDate = reader.GetDateTime("RS_InvDate");
	this.RS_CheckNum = reader.GetString("RS_CheckNum");
	this.RS_BillToCust = reader.GetString("RS_BillToCust");
	this.RS_ShipToCust = reader.GetString("RS_ShipToCust");
	this.RS_ShipType = reader.GetString("RS_ShipType");
	this.RS_ProcessYN = reader.GetString("RS_ProcessYN");
	this.RS_PstAmt = reader.GetDecimal("RS_PstAmt");
	this.RS_AdjAmt = reader.GetDecimal("RS_AdjAmt");
	this.RS_Process = reader.GetString("RS_Process");
	this.RS_Linked = reader.GetString("RS_Linked");
	this.RS_SentToERP = reader.GetString("RS_SentToERP");
	this.RS_DateSentToERP = reader.GetDateTime("RS_DateSentToERP");
	this.RS_ERPDebitNote = reader.GetString("RS_ERPDebitNote");
	this.RS_DebitNote = reader.GetString("RS_DebitNote");
//RemittanceHdr fileds
    this.RH_PayID = reader.GetString("RH_PayID");
    this.RH_TPartner = reader.GetString("RH_TPartner");
    this.RH_PayingPH = reader.GetString("RH_PayingPH");
}

public override
void write(){
	try{
		string sql = "insert into remittanceship " +
		                "(RS_Db,RS_LogNum,RS_EntryNum,RS_LineNum,RS_BOLReceived,RS_BOLActual," +
		                " RS_InvActual,RS_InvSent,RS_POSent,RS_CustAcc,RS_CheckRef,RS_GrossAmt," +
		                " RS_DiscAmt,RS_DiscPer,RS_GSTAmt,RS_NetAmtPaid,RS_RemitAmt,RS_PayAmt," +
		                " RS_OtherAmtQu1,RS_OtherAmt1,RS_OtherAmtQu2,RS_OtherAmt2,RS_Ref1,RS_Ref2," +
		                " RS_Ref3,RS_Ref4,RS_LiabilityDate,RS_IssueDate,RS_InvDate,RS_CheckNum," +
		                " RS_BillToCust,RS_ShipToCust,RS_ShipType,RS_ProcessYN,RS_PstAmt,RS_AdjAmt," +
		                " RS_Process,RS_Linked,RS_SentToERP,RS_DateSentToERP,RS_ERPDebitNote,RS_DebitNote)"+
		            "values('" +
				            Converter.fixString(RS_Db) +"', " +
				            NumberUtil.toString(RS_LogNum) +", " +
				            NumberUtil.toString(RS_EntryNum) +", " +
				            NumberUtil.toString(RS_LineNum) +", '" +
				            Converter.fixString(RS_BOLReceived) +"', " +
				            NumberUtil.toString(RS_BOLActual) +", " +
				            NumberUtil.toString(RS_InvActual) +", '" +
				            Converter.fixString(RS_InvSent) +"', '" +
				            Converter.fixString(RS_POSent) +"', '" +
				            Converter.fixString(RS_CustAcc) +"', '" +
				            Converter.fixString(RS_CheckRef) +"', " +
				            NumberUtil.toString(RS_GrossAmt) +", " +
				            NumberUtil.toString(RS_DiscAmt) +", " +
				            NumberUtil.toString(RS_DiscPer) +", " +
				            NumberUtil.toString(RS_GSTAmt) +", " +
				            NumberUtil.toString(RS_NetAmtPaid) +", " +
				            NumberUtil.toString(RS_RemitAmt) +", " +
				            NumberUtil.toString(RS_PayAmt) +", '" +
				            Converter.fixString(RS_OtherAmtQu1) +"', " +
				            NumberUtil.toString(RS_OtherAmt1) +", '" +
				            Converter.fixString(RS_OtherAmtQu2) +"', " +
				            NumberUtil.toString(RS_OtherAmt2) +", '" +
				            Converter.fixString(RS_Ref1) +"', '" +
				            Converter.fixString(RS_Ref2) +"', '" +
				            Converter.fixString(RS_Ref3) +"', '" +
				            Converter.fixString(RS_Ref4) +"', '" +
				            DateUtil.getCompleteDateRepresentation(RS_LiabilityDate) +"', '" +
				            DateUtil.getCompleteDateRepresentation(RS_IssueDate) +"', '" +
				            DateUtil.getCompleteDateRepresentation(RS_InvDate) +"', '" +
				            Converter.fixString(RS_CheckNum) +"', '" +
				            Converter.fixString(RS_BillToCust) +"', '" +
				            Converter.fixString(RS_ShipToCust) +"', '" +
				            Converter.fixString(RS_ShipType) +"', '" +
				            Converter.fixString(RS_ProcessYN) +"', " +
				            NumberUtil.toString(RS_PstAmt) +", " +
				            NumberUtil.toString(RS_AdjAmt)+", '" +
				            Converter.fixString(RS_Process) +"', '" +
				            Converter.fixString(RS_Linked) +"', '" +
				            Converter.fixString(RS_SentToERP) +"', '" +
				            DateUtil.getCompleteDateRepresentation(RS_DateSentToERP) +"', '" +
				            Converter.fixString(RS_ERPDebitNote) +"', '" +
				            Converter.fixString(RS_DebitNote) +"')";
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
		string sql = "update remittanceship set " +
				"RS_Process = '" +Converter.fixString(RS_Process) + "', " +
				"RS_Linked = '" + Converter.fixString(RS_Linked) + "' " +
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
    NotNullDataReader reader=null;
	try{
		bool ret = false;

		string sql = "select * from remittanceship " + 
			"where " +
			"RS_Db = '" + Converter.fixString(RS_Db) +"' and " +
			"RS_LogNum = " + NumberUtil.toString(RS_LogNum) +" and " +
			"RS_EntryNum = " + NumberUtil.toString(RS_EntryNum)+ " and " +
			"RS_LineNum = " + NumberUtil.toString(RS_LineNum);
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

public void setRS_Db(string RS_Db){
   this.RS_Db = RS_Db;
}

public void setRS_LogNum(int RS_LogNum){
   this.RS_LogNum = RS_LogNum;
}

public void setRS_EntryNum(int RS_EntryNum){
   this.RS_EntryNum = RS_EntryNum;
}

public void setRS_LineNum(int RS_LineNum){
   this.RS_LineNum = RS_LineNum;
}

public void setRS_BOLReceived(string RS_BOLReceived){
   this.RS_BOLReceived = RS_BOLReceived;
}

public void setRS_BOLActual(decimal	RS_BOLActual){
   this.RS_BOLActual = RS_BOLActual;
}

public void setRS_InvSent(string RS_InvSent){
   this.RS_InvSent = RS_InvSent;
}

public void setRS_POSent(string RS_POSent){
   this.RS_POSent = RS_POSent;
}

public void setRS_CustAcc(string RS_CustAcc){
   this.RS_CustAcc = RS_CustAcc;
}

public void setRS_CheckRef(string RS_CheckRef){
   this.RS_CheckRef = RS_CheckRef;
}

public void setRS_GrossAmt(decimal	RS_GrossAmt){
   this.RS_GrossAmt = RS_GrossAmt;
}

public void setRS_DiscAmt(decimal	RS_DiscAmt){
   this.RS_DiscAmt = RS_DiscAmt;
}

public void setRS_DiscPer(decimal	RS_DiscPer){
   this.RS_DiscPer = RS_DiscPer;
}

public void setRS_GSTAmt(decimal	RS_GSTAmt){
   this.RS_GSTAmt = RS_GSTAmt;
}

public void setRS_NetAmtPaid(decimal	RS_NetAmtPaid){
   this.RS_NetAmtPaid = RS_NetAmtPaid;
}

public void setRS_RemitAmt(decimal	RS_RemitAmt){
   this.RS_RemitAmt = RS_RemitAmt;
}

public void setRS_PayAmt(decimal	RS_PayAmt){
   this.RS_PayAmt = RS_PayAmt;
}

public void setRS_OtherAmtQu1(string RS_OtherAmtQu1){
   this.RS_OtherAmtQu1 = RS_OtherAmtQu1;
}

public void setRS_OtherAmt1(decimal	RS_OtherAmt1){
   this.RS_OtherAmt1 = RS_OtherAmt1;
}

public void setRS_OtherAmtQu2(string RS_OtherAmtQu2){
   this.RS_OtherAmtQu2 = RS_OtherAmtQu2;
}

public void setRS_OtherAmt2(decimal	RS_OtherAmt2){
   this.RS_OtherAmt2 = RS_OtherAmt2;
}

public void setRS_Ref1(string RS_Ref1){
   this.RS_Ref1 = RS_Ref1;
}

public void setRS_Ref2(string RS_Ref2){
   this.RS_Ref2 = RS_Ref2;
}

public void setRS_Ref3(string RS_Ref3){
   this.RS_Ref3 = RS_Ref3;
}

public void setRS_Ref4(string RS_Ref4){
   this.RS_Ref4 = RS_Ref4;
}

public void setRS_LiabilityDate(DateTime RS_LiabilityDate){
   this.RS_LiabilityDate = RS_LiabilityDate;
}

public void setRS_IssueDate(DateTime RS_IssueDate){
   this.RS_IssueDate = RS_IssueDate;
}

public void setRS_InvDate(DateTime RS_InvDate){
   this.RS_InvDate = RS_InvDate;
}

public void setRS_CheckNum(string RS_CheckNum){
   this.RS_CheckNum = RS_CheckNum;
}

public void setRS_BillToCust(string RS_BillToCust){
   this.RS_BillToCust = RS_BillToCust;
}

public void setRS_ShipToCust(string RS_ShipToCust){
   this.RS_ShipToCust = RS_ShipToCust;
}

public void setRS_ShipType(string RS_ShipType){
   this.RS_ShipType = RS_ShipType;
}

public void setRS_ProcessYN(string RS_ProcessYN){
   this.RS_ProcessYN = RS_ProcessYN;
}

public void setRS_PstAmt(decimal	RS_PstAmt){
   this.RS_PstAmt = RS_PstAmt;
}

public void setRS_AdjAmt(decimal	RS_AdjAmt){
   this.RS_AdjAmt = RS_AdjAmt;
}

public void setRS_InvActual(decimal	RS_InvActual){
   this.RS_InvActual = RS_InvActual;
}


public void setRS_Process(string RS_Process){
   this.RS_Process = RS_Process;
}

public void setRS_Linked(string RS_Linked){
   this.RS_Linked = RS_Linked;
}

public void setRS_SentToERP(string RS_SentToERP){
   this.RS_SentToERP = RS_SentToERP;
}

public void setRS_DateSentToERP(DateTime RS_DateSentToERP){
   this.RS_DateSentToERP = RS_DateSentToERP;
}

public void setRS_ERPDebitNote(string RS_ERPDebitNote){
   this.RS_ERPDebitNote = RS_ERPDebitNote;
}

public void setRS_DebitNote(string RS_DebitNote){
   this.RS_DebitNote = RS_DebitNote;
}

//RemittanceHdr fileds
public void setRH_PayID (string RH_PayID){
    this.RH_PayID = RH_PayID;
}

public void setRH_TPartner (string RH_TPartner){
    this.RH_TPartner = RH_TPartner;
}
//Getters


public
string getRS_Db(){
   return RS_Db;
}

public
int	getRS_LogNum(){
   return RS_LogNum;
}

public
int	getRS_EntryNum(){
   return RS_EntryNum;
}

public
int	getRS_LineNum(){
   return RS_LineNum;
}

public
string getRS_BOLReceived(){
   return RS_BOLReceived;
}

public
decimal	getRS_BOLActual(){
   return RS_BOLActual;
}

public
string getRS_InvSent(){
   return RS_InvSent;
}

public
string getRS_POSent(){
   return RS_POSent;
}

public
string getRS_CustAcc(){
   return RS_CustAcc;
}

public
string getRS_CheckRef(){
   return RS_CheckRef;
}

public
decimal	getRS_GrossAmt(){
   return RS_GrossAmt;
}

public
decimal	getRS_DiscAmt(){
   return RS_DiscAmt;
}

public
decimal	getRS_DiscPer(){
   return RS_DiscPer;
}

public
decimal	getRS_GSTAmt(){
   return RS_GSTAmt;
}

public
decimal	getRS_NetAmtPaid(){
   return RS_NetAmtPaid;
}

public
decimal	getRS_RemitAmt(){
   return RS_RemitAmt;
}

public
decimal	getRS_PayAmt(){
   return RS_PayAmt;
}

public
string getRS_OtherAmtQu1(){
   return RS_OtherAmtQu1;
}

public
decimal	getRS_OtherAmt1(){
   return RS_OtherAmt1;
}

public
string getRS_OtherAmtQu2(){
   return RS_OtherAmtQu2;
}

public
decimal	getRS_OtherAmt2(){
   return RS_OtherAmt2;
}

public
string getRS_Ref1(){
   return RS_Ref1;
}

public
string getRS_Ref2(){
   return RS_Ref2;
}

public
string getRS_Ref3(){
   return RS_Ref3;
}

public
string getRS_Ref4(){
   return RS_Ref4;
}

public
DateTime getRS_LiabilityDate(){
   return RS_LiabilityDate;
}

public
DateTime getRS_IssueDate(){
   return RS_IssueDate;
}

public
DateTime getRS_InvDate(){
   return RS_InvDate;
}

public
string getRS_CheckNum(){
   return RS_CheckNum;
}

public
string getRS_BillToCust(){
   return RS_BillToCust;
}

public
string getRS_ShipToCust(){
   return RS_ShipToCust;
}

public
string getRS_ShipType(){
   return RS_ShipType;
}

public
string getRS_ProcessYN(){
   return RS_ProcessYN;
}

public
decimal	getRS_PstAmt(){
   return RS_PstAmt;
}

public
decimal	getRS_AdjAmt(){
   return RS_AdjAmt;
}

public
decimal	getRS_InvActual(){
   return RS_InvActual;
}

public
string getRS_Process(){
   return RS_Process;
}

public
string getRS_Linked(){
   return RS_Linked;
}

public
string getRS_SentToERP(){
   return RS_SentToERP;
}

public
DateTime getRS_DateSentToERP(){
   return RS_DateSentToERP;
}

public
string getRS_ERPDebitNote(){
   return RS_ERPDebitNote;
}

public
string getRS_DebitNote(){
   return RS_DebitNote;
}

//RemittanceHdr fileds
public 
string getRH_PayID(){
    return RH_PayID;
}

public 
string getRH_TPartner(){
    return RH_TPartner;
}

public 
string getRH_PayingPH(){
    return this.RH_PayingPH;
}

}//end class
	
}//end namespace
