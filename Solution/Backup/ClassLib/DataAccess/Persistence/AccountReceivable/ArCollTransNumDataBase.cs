using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
	
public class ArCollTransNumDataBase :GenericDataBaseElement	{
	
private int ID;
private int ART_TransNum;
private string ART_ARCollectionGrp;
private string ART_CollType;
private string ART_DB;
private string ART_Company;
private string ART_Plant;
private string ART_InvoiceN;
private int ART_InvoiceNum;
private int ART_InvItemNum;
private int ART_BOLNum;
private string ART_ProdID;
private int ART_Seq;
private string ART_CustPart;
private string ART_CustPO;
private string ART_CustVouchNum;
private string ART_CollectNotes;
private string ART_CustContact;
private string ART_CustPhoneNum;
private string ART_CustFaxNum;
private string ART_Status;
private DateTime ART_Date;
private DateTime ART_ResponseDate;
private string ART_RecCode;
private string ART_AdjReasonCode;
private decimal ART_AdjAmt;
private DateTime ART_CloseDate;
private string ART_UserId;
private decimal ART_DiscepancyAmt;
private string ART_CustRequired;


public ArCollTransNumDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess)	{
	
}
public
void load(NotNullDataReader reader){

    this.ID = reader.GetInt32("ID");
    this.ART_TransNum = reader.GetInt32("ART_TransNum");
    this.ART_ARCollectionGrp = reader.GetString("ART_ARCollectionGrp");
    this.ART_CollType = reader.GetString("ART_CollType");
    this.ART_DB = reader.GetString("ART_DB");
    this.ART_Company = reader.GetString("ART_Company");
    this.ART_Plant = reader.GetString("ART_Plant");
    this.ART_InvoiceN = reader.GetString("ART_InvoiceN");
    this.ART_InvoiceNum = reader.GetInt32("ART_InvoiceNum");
    this.ART_InvItemNum = reader.GetInt32("ART_InvItemNum");
    this.ART_BOLNum = reader.GetInt32("ART_BOLNum");
    this.ART_ProdID = reader.GetString("ART_ProdID");
    this.ART_Seq = reader.GetInt32("ART_Seq");
    this.ART_CustPart = reader.GetString("ART_CustPart");
    this.ART_CustPO = reader.GetString("ART_CustPO");
    this.ART_CustVouchNum = reader.GetString("ART_CustVouchNum");
    this.ART_CollectNotes = reader.GetString("ART_CollectNotes");
    this.ART_CustContact = reader.GetString("ART_CustContact");
    this.ART_CustPhoneNum = reader.GetString("ART_CustPhoneNum");
    this.ART_CustFaxNum = reader.GetString("ART_CustFaxNum");
    this.ART_Status = reader.GetString("ART_Status");
    this.ART_Date = reader.GetDateTime("ART_Date");
    this.ART_ResponseDate = reader.GetDateTime("ART_ResponseDate");
    this.ART_RecCode = reader.GetString("ART_RecCode");
    this.ART_AdjReasonCode = reader.GetString("ART_AdjReasonCode");
    this.ART_AdjAmt = reader.GetDecimal("ART_AdjAmt");
    this.ART_CloseDate = reader.GetDateTime("ART_CloseDate");
    this.ART_UserId = reader.GetString("ART_UserId");
    this.ART_DiscepancyAmt = reader.GetDecimal("ART_DiscepancyAmt");
    this.ART_CustRequired = reader.GetString("ART_CustRequired");
}

public override
void write(){
try{
		string sql = "insert into arcolltransnum "+
		                "(ART_TransNum,ART_ARCollectionGrp,ART_CollType,ART_DB,ART_Company," +
		                " ART_Plant,ART_InvoiceN,ART_InvoiceNum,ART_InvItemNum,ART_BOLNum," +
		                " ART_ProdID,ART_Seq,ART_CustPart,ART_CustPO,ART_CustVouchNum," +
		                " ART_CollectNotes,ART_CustContact,ART_CustPhoneNum,ART_CustFaxNum," +
		                " ART_Status,ART_Date,ART_ResponseDate,ART_RecCode,ART_AdjReasonCode," +
		                " ART_AdjAmt,ART_CloseDate,ART_UserId,ART_DiscepancyAmt,ART_CustRequired) " +
        		" values(" +
                        NumberUtil.toString(ART_TransNum) +", '" +
                        Converter.fixString(ART_ARCollectionGrp) +"', '" +
                        Converter.fixString(ART_CollType) +"', '" +
                        Converter.fixString(ART_DB) +"', '" +
                        Converter.fixString(ART_Company) +"', '" +
                        Converter.fixString(ART_Plant) +"', '" +
                        Converter.fixString(ART_InvoiceN) +"', " +
                        NumberUtil.toString(ART_InvoiceNum) +", " +
                        NumberUtil.toString(ART_InvItemNum) +", " +
                        NumberUtil.toString(ART_BOLNum) +", '" +
                        Converter.fixString(ART_ProdID) +"', " +
                        NumberUtil.toString(ART_Seq) +", '" +
                        Converter.fixString(ART_CustPart) +"', '" +
                        Converter.fixString(ART_CustPO) +"', '" +
                        Converter.fixString(ART_CustVouchNum) +"', '" +
                        Converter.fixString(ART_CollectNotes) +"', '" +
                        Converter.fixString(ART_CustContact) +"', '" +
                        Converter.fixString(ART_CustPhoneNum) +"', '" +
                        Converter.fixString(ART_CustFaxNum) +"', '" +
                        Converter.fixString(ART_Status) +"', '" +
                        DateUtil.getCompleteDateRepresentation(ART_Date) +"', '" +
                        DateUtil.getCompleteDateRepresentation(ART_ResponseDate) +"', '" +
                        Converter.fixString(ART_RecCode) +"', '" +
                        Converter.fixString(ART_AdjReasonCode) +"', " +
                        NumberUtil.toString(ART_AdjAmt) +", '" +
                        DateUtil.getCompleteDateRepresentation(ART_CloseDate) +"', '" +
                        Converter.fixString(ART_UserId) +"', " +
                        NumberUtil.toString(ART_DiscepancyAmt) +", '" +
                        Converter.fixString(ART_CustRequired) +"')";
	
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
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

public
void read(){
    NotNullDataReader  reader = null;
    try{
		string sql = "select * from arcolltransnum where " + 
		    	"ID = " + NumberUtil.toString(ID);
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
		reader.Close();
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


//Setters

public void setID(int ID){
    this.ID = ID;
}

public void setART_TransNum(int ART_TransNum){
    this.ART_TransNum = ART_TransNum;
}

public void setART_ARCollectionGrp(string ART_ARCollectionGrp){
    this.ART_ARCollectionGrp = ART_ARCollectionGrp;
}

public void setART_CollType(string ART_CollType){
    this.ART_CollType = ART_CollType;
}

public void setART_DB (string ART_DB){
    this.ART_DB = ART_DB;
}

public void setART_Company (string ART_Company){
    this.ART_Company = ART_Company;
}

public void setART_Plant (string ART_Plant){
    this.ART_Plant = ART_Plant;
}

public void setART_InvoiceN (string ART_InvoiceN){
    this.ART_InvoiceN = ART_InvoiceN;
}

public void setART_InvoiceNum (int ART_InvoiceNum){
    this.ART_InvoiceNum = ART_InvoiceNum;
}

public void setART_InvItemNum (int ART_InvItemNum){
    this.ART_InvItemNum = ART_InvItemNum;
}

public void setART_BOLNum (int ART_BOLNum){
    this.ART_BOLNum = ART_BOLNum;
}

public void setART_ProdID (string ART_ProdID){
    this.ART_ProdID = ART_ProdID;
}

public void setART_Seq (int ART_Seq){
    this.ART_Seq = ART_Seq;
}

public void setART_CustPart (string ART_CustPart){
    this.ART_CustPart = ART_CustPart;
}

public void setART_CustPO (string ART_CustPO){
    this.ART_CustPO = ART_CustPO;
}

public void setART_CustVouchNum (string ART_CustVouchNum){
    this.ART_CustVouchNum = ART_CustVouchNum;
}

public void setART_CollectNotes (string ART_CollectNotes){
    this.ART_CollectNotes = ART_CollectNotes;
}

public void setART_CustContact (string ART_CustContact){
    this.ART_CustContact = ART_CustContact;
}

public void setART_CustPhoneNum (string ART_CustPhoneNum){
    this.ART_CustPhoneNum = ART_CustPhoneNum;
}

public void setpriART_CustFaxNum (string ART_CustFaxNum){
    this.ART_CustFaxNum = ART_CustFaxNum;
}

public void setART_Status (string ART_Status){
    this.ART_Status = ART_Status;
}

public void setprivaART_Date (DateTime ART_Date){
    this.ART_Date = ART_Date;
}

public void setART_ResponseDate (DateTime ART_ResponseDate){
    this.ART_ResponseDate = ART_ResponseDate;
}

public void setART_RecCode (string ART_RecCode){
    this.ART_RecCode = ART_RecCode;
}

public void setpriART_AdjReasonCode (string ART_AdjReasonCode){
    this.ART_AdjReasonCode = ART_AdjReasonCode;
}

public void setART_AdjAmt (decimal ART_AdjAmt){
    this.ART_AdjAmt = ART_AdjAmt;
}

public void setART_CloseDate (DateTime ART_CloseDate){
    this.ART_CloseDate = ART_CloseDate;
}

public void setART_UserId (string ART_UserId){
    this.ART_UserId = ART_UserId;
}

public void setART_DiscepancyAmt (decimal ART_DiscepancyAmt){
    this.ART_DiscepancyAmt = ART_DiscepancyAmt;
}

public void setART_CustRequired (string ART_CustRequired){
    this.ART_CustRequired = ART_CustRequired;
}


//Getters

public int getID(){
    return ID;
}

public int getART_TransNum(){
    return ART_TransNum;
}

public string getART_ARCollectionGrp(){
    return ART_ARCollectionGrp = ART_ARCollectionGrp;
}

public string getART_CollType(){
    return ART_CollType = ART_CollType;
}

public string getART_DB(){
    return ART_DB = ART_DB;
}

public string getART_Company(){
    return ART_Company = ART_Company;
}

public string getART_Plant(){
    return ART_Plant = ART_Plant;
}

public string getART_InvoiceN(){
    return ART_InvoiceN = ART_InvoiceN;
}

public int getART_InvoiceNum(){
    return ART_InvoiceNum = ART_InvoiceNum;
}

public int getART_InvItemNum(){
    return ART_InvItemNum = ART_InvItemNum;
}

public int getART_BOLNum(){
    return ART_BOLNum = ART_BOLNum;
}

public string getART_ProdID(){
    return ART_ProdID = ART_ProdID;
}

public int getART_Seq(){
    return ART_Seq = ART_Seq;
}

public string getART_CustPart(){
    return ART_CustPart = ART_CustPart;
}

public string getART_CustPO(){
    return ART_CustPO = ART_CustPO;
}

public string getART_CustVouchNum(){
    return ART_CustVouchNum = ART_CustVouchNum;
}

public string getART_CollectNotes(){
    return ART_CollectNotes = ART_CollectNotes;
}

public string getART_CustContact(){
    return ART_CustContact = ART_CustContact;
}

public string getART_CustPhoneNum(){
    return ART_CustPhoneNum = ART_CustPhoneNum;
}

public string getART_CustFaxNum(){
    return ART_CustFaxNum = ART_CustFaxNum;
}

public string getART_Status(){
    return ART_Status = ART_Status;
}

public DateTime getART_Date(){
    return ART_Date = ART_Date;
}

public DateTime getART_ResponseDate(){
    return ART_ResponseDate = ART_ResponseDate;
}

public string getART_RecCode(){
    return ART_RecCode = ART_RecCode;
}

public string getART_AdjReasonCode(){
    return ART_AdjReasonCode = ART_AdjReasonCode;
}

public decimal getART_AdjAmt(){
    return ART_AdjAmt = ART_AdjAmt;
}

public DateTime getART_CloseDate(){
    return ART_CloseDate = ART_CloseDate;
}

public string getART_UserId(){
    return ART_UserId = ART_UserId;
}

public decimal getART_DiscepancyAmt(){
    return ART_DiscepancyAmt = ART_DiscepancyAmt;
}

public string getART_CustRequired(){
    return ART_CustRequired = ART_CustRequired;
}


}
}
