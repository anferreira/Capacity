using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

	
public 
class OePSDtlDataBase: GenericDataBaseElement{

private int	PD_ID;
private string PD_DB;
private int PD_Company;
private string PD_Plant;
private int PD_PackSlipNum;
private int PD_PackSlipItem;
private int PD_OrderNum;
private int PD_OrderItemNum;
private string PD_ReleaseNum;
private string PD_ProdID;
private int PD_Seq;
private string PD_ECNumber;
private string PD_CustPart;
private string PD_CustPartRev;
private decimal PD_PO; 
private decimal PD_ShipQty;
private string PD_ShipQtyUom;
private decimal PD_ShipQtyOE;
private string PD_ShipQtyOEUom;
private string PD_Status;
private int PD_InvoiceNum;
private int PD_InvLineNum;
private string PD_RanNumber;
private string PD_CustPO;
private decimal PD_CurrentCum;
private decimal PD_PreviousCum;
private string PD_ShipRef;
private string PD_LineStatus;
private string PD_StkLoc;
private string PD_Condition;
private string PD_Project;



public 
OePSDtlDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.PD_ID = reader.GetInt32("PD_ID");
	this.PD_DB = reader.GetString("PD_DB");
	this.PD_Company = reader.GetInt32("PD_Company");
	this.PD_Plant = reader.GetString("PD_Plant");
	this.PD_PackSlipNum = reader.GetInt32("PD_PackSlipNum");
	this.PD_PackSlipItem = reader.GetInt32("PD_PackSlipItem");
	this.PD_OrderNum = reader.GetInt32("PD_OrderNum");
	this.PD_OrderItemNum = reader.GetInt32("PD_OrderItemNum");
	this.PD_ReleaseNum = reader.GetString("PD_ReleaseNum");
	this.PD_ProdID = reader.GetString("PD_ProdID");
	this.PD_Seq = reader.GetInt32("PD_Seq");
	this.PD_ECNumber = reader.GetString("PD_ECNumber");
	this.PD_CustPart = reader.GetString("PD_CustPart");
	this.PD_CustPartRev = reader.GetString("PD_CustPartRev");
	this.PD_PO = reader.GetDecimal("PD_PO");
	this.PD_ShipQty = reader.GetDecimal("PD_ShipQty");
	this.PD_ShipQtyUom = reader.GetString("PD_ShipQtyUom");
	this.PD_ShipQtyOE = reader.GetDecimal("PD_ShipQtyOE");
	this.PD_ShipQtyOEUom = reader.GetString("PD_ShipQtyOEUom");
	this.PD_Status = reader.GetString("PD_Status");
	this.PD_InvoiceNum = reader.GetInt32("PD_InvoiceNum");
	this.PD_InvLineNum = reader.GetInt32("PD_InvLineNum");
	this.PD_RanNumber = reader.GetString("PD_RanNumber");
	this.PD_CustPO = reader.GetString("PD_CustPO");
	this.PD_CurrentCum = reader.GetDecimal("PD_CurrentCum");
	this.PD_PreviousCum = reader.GetDecimal("PD_PreviousCum");
	this.PD_ShipRef = reader.GetString("PD_ShipRef");
	this.PD_LineStatus = reader.GetString("PD_LineStatus");
	this.PD_StkLoc = reader.GetString("PD_StkLoc");
	this.PD_Condition = reader.GetString("PD_Condition");
	this.PD_Project = reader.GetString("PD_Project");
}

public override
void write(){
	string sql = "insert into oepsdtl " +
		            "(PD_DB,PD_Company,PD_Plant,PD_PackSlipNum,PD_PackSlipItem,PD_OrderNum,"+
		            " PD_OrderItemNum,PD_ReleaseNum,PD_ProdID,PD_Seq,PD_ECNumber,PD_CustPart,"+
		            " PD_CustPartRev,PD_PO,PD_ShipQty,PD_ShipQtyUom,PD_ShipQtyOE,PD_ShipQtyOEUom,"+
		            " PD_Status,PD_InvoiceNum,PD_InvLineNum,PD_RanNumber,PD_CustPO,PD_CurrentCum,"+
		            " PD_PreviousCum,PD_ShipRef,PD_LineStatus,PD_StkLoc,PD_Condition,PD_Project)" +
		    " values('" +
			    Converter.fixString(PD_DB) +"', " +
			    NumberUtil.toString(PD_Company) +", '" +
			    Converter.fixString(PD_Plant) +"', " +
			    NumberUtil.toString(PD_PackSlipNum) +", " +
			    NumberUtil.toString(PD_PackSlipItem) +", " +
			    NumberUtil.toString(PD_OrderNum) +", " +
			    NumberUtil.toString(PD_OrderItemNum) +", '" +
			    Converter.fixString(PD_ReleaseNum) +"', '" +
			    Converter.fixString(PD_ProdID) +"', " +
			    NumberUtil.toString(PD_Seq) +", '" +
			    Converter.fixString(PD_ECNumber) +"', '" +
			    Converter.fixString(PD_CustPart) +"', '" +
			    Converter.fixString(PD_CustPartRev) +"', " +
			    NumberUtil.toString(PD_PO) + ", " +
			    NumberUtil.toString(PD_ShipQty) +", '" +
			    Converter.fixString(PD_ShipQtyUom) +"', " +
			    NumberUtil.toString(PD_ShipQtyOE) +", '" +
			    Converter.fixString(PD_ShipQtyOEUom) +"', '" +
			    Converter.fixString(PD_Status) +"', " +
			    NumberUtil.toString(PD_InvoiceNum) +", " +
			    NumberUtil.toString(PD_InvLineNum) +", '" +
			    Converter.fixString(PD_RanNumber) +"', '" +
			    Converter.fixString(PD_CustPO) +"', " +
			    NumberUtil.toString(PD_CurrentCum) +", " +
			    NumberUtil.toString(PD_PreviousCum) +", '" +
			    Converter.fixString(PD_ShipRef) +"', '" +
			    Converter.fixString(PD_LineStatus) +"', '" +
			    Converter.fixString(PD_StkLoc) +"', '" +
			    Converter.fixString(PD_Condition) +"', '" +
			    Converter.fixString(PD_Project) +"')";
	write(sql);
}
public override
void update(){
		string sql = "update oepsdtl set " +
			"PD_DB = '" + Converter.fixString(PD_DB) + "', " +
			"PD_Company = " + NumberUtil.toString(PD_Company) +", " +
			"PD_Plant = '" + Converter.fixString(PD_Plant) +"', " +
			"PD_PackSlipNum = " + NumberUtil.toString(PD_PackSlipNum) +", " +
			"PD_PackSlipItem =" + NumberUtil.toString(PD_PackSlipItem) +", " +
			"PD_OrderNum = " + NumberUtil.toString(PD_OrderNum) +", " +
			"PD_OrderItemNum = " + NumberUtil.toString(PD_OrderItemNum) +", " +
			"PD_ReleaseNum = '" + Converter.fixString(PD_ReleaseNum) +"', " +
			"PD_ProdID = '" + Converter.fixString(PD_ProdID) +"', " +
			"PD_Seq = " + NumberUtil.toString(PD_Seq) +", " +
			"PD_ECNumber ='" + Converter.fixString(PD_ECNumber) +"', " +
			"PD_CustPart = '" + Converter.fixString(PD_CustPart) +"', " +
			"PD_CustPartRev = '" + Converter.fixString(PD_CustPartRev) +"', " +
			"PD_PO = " + NumberUtil.toString(PD_PO) + ", " + 
			"PD_ShipQty = " + NumberUtil.toString(PD_ShipQty) +", " +
			"PD_ShipQtyUom = '" + Converter.fixString(PD_ShipQtyUom) +"', " +
			"PD_ShipQtyOE = " + NumberUtil.toString(PD_ShipQtyOE) +", " +
			"PD_ShipQtyOEUom = '" + Converter.fixString(PD_ShipQtyOEUom) +"', " +
			"PD_Status = '" + Converter.fixString(PD_Status) +"', " +
			"PD_InvoiceNum = " + NumberUtil.toString(PD_InvoiceNum) +", " +
			"PD_InvLineNum = " + NumberUtil.toString(PD_InvLineNum) +", " +
			"PD_RanNumber = '" + Converter.fixString(PD_RanNumber) +"', " +
			"PD_CustPO = '" + Converter.fixString(PD_CustPO) +"', " +
			"PD_CurrentCum = " + NumberUtil.toString(PD_CurrentCum) +", " +
			"PD_PreviousCum = " + NumberUtil.toString(PD_PreviousCum) +", " +
			"PD_ShipRef = '" + Converter.fixString(PD_ShipRef) +"', " +
			"PD_LineStatus = '" + Converter.fixString(PD_LineStatus) +"', " +
			"PD_StkLoc = ' " + Converter.fixString(PD_StkLoc) +", " +
			"PD_Condition = '" + Converter.fixString(PD_Condition) + "', " +
			"PD_Project = '" + Converter.fixString(PD_Project) +" " +
		"where " +
			"PD_ID = " + NumberUtil.toString(PD_ID);	
	update(sql);

}

public override
void delete(){
	string sql = "delete from oepsdtl where " +
	             "PD_ID = " + NumberUtil.toString(PD_ID);	
    delete(sql);
}

public
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from oepsdtl where " + 
			"ID = " + NumberUtil.toString(PD_ID);
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

 	string sql = "select * from oepsdtl " + 
		"where " +
		"PD_Db = '" + Converter.fixString(PD_DB) + "' and " +
		"PD_Company =" + NumberUtil.toString(PD_Company) + " and " +
		"PD_Plant = '" + Converter.fixString(PD_Plant) + "' and " +
		"PD_PackSlipNum = " + NumberUtil.toString(PD_PackSlipNum) + " and " +
		"PD_PackSlipItem = " + NumberUtil.toString(PD_PackSlipItem);
   return exists(sql);
	
}


//Setters
public 
void setPD_ID(int	PD_ID){
   this.PD_ID = PD_ID;
}

public 
void setPD_DB(string PD_DB){
   this.PD_DB = PD_DB;
}

public 
void setPD_Company(int PD_Company){
   this.PD_Company = PD_Company;
}

public 
void setPD_Plant(string PD_Plant){
   this.PD_Plant = PD_Plant;
}

public 
void setPD_PackSlipNum(int PD_PackSlipNum){
   this.PD_PackSlipNum = PD_PackSlipNum;
}

public 
void setPD_PackSlipItem(int PD_PackSlipItem){
   this.PD_PackSlipItem = PD_PackSlipItem;
}

public 
void setPD_OrderNum(int PD_OrderNum){
   this.PD_OrderNum = PD_OrderNum;
}

public 
void setPD_OrderItemNum(int PD_OrderItemNum){
   this.PD_OrderItemNum = PD_OrderItemNum;
}

public 
void setPD_ReleaseNum(string PD_ReleaseNum){
   this.PD_ReleaseNum = PD_ReleaseNum;
}

public 
void setPD_ProdID(string PD_ProdID){
   this.PD_ProdID = PD_ProdID;
}

public 
void setPD_Seq(int PD_Seq){
   this.PD_Seq = PD_Seq;
}

public 
void setPD_ECNumber(string PD_ECNumber){
   this.PD_ECNumber = PD_ECNumber;
}

public 
void setPD_CustPart(string PD_CustPart){
   this.PD_CustPart = PD_CustPart;
}

public 
void setPD_CustPartRev(string PD_CustPartRev){
   this.PD_CustPartRev = PD_CustPartRev;
}

public 
void setPD_PO (decimal PD_PO){
    this.PD_PO = PD_PO;
}

public 
void setPD_ShipQty(decimal PD_ShipQty){
   this.PD_ShipQty = PD_ShipQty;
}

public 
void setPD_ShipQtyUom(string PD_ShipQtyUom){
   this.PD_ShipQtyUom = PD_ShipQtyUom;
}

public 
void setPD_ShipQtyOE(decimal PD_ShipQtyOE){
   this.PD_ShipQtyOE = PD_ShipQtyOE;
}

public 
void setPD_ShipQtyOEUom(string PD_ShipQtyOEUom){
   this.PD_ShipQtyOEUom = PD_ShipQtyOEUom;
}

public 
void setPD_Status(string PD_Status){
   this.PD_Status = PD_Status;
}

public 
void setPD_InvoiceNum(int PD_InvoiceNum){
   this.PD_InvoiceNum = PD_InvoiceNum;
}

public 
void setPD_InvLineNum(int PD_InvLineNum){
   this.PD_InvLineNum = PD_InvLineNum;
}

public 
void setPD_RanNumber(string PD_RanNumber){
   this.PD_RanNumber = PD_RanNumber;
}

public 
void setPD_CustPO(string PD_CustPO){
   this.PD_CustPO = PD_CustPO;
}

public 
void setPD_CurrentCum(decimal PD_CurrentCum){
   this.PD_CurrentCum = PD_CurrentCum;
}

public 
void setPD_PreviousCum(decimal PD_PreviousCum){
   this.PD_PreviousCum = PD_PreviousCum;
}

public 
void setPD_ShipRef(string PD_ShipRef){
   this.PD_ShipRef = PD_ShipRef;
}

public 
void setPD_LineStatus(string PD_LineStatus){
   this.PD_LineStatus = PD_LineStatus;
}

public 
void setPD_StkLoc(string PD_StkLoc){
   this.PD_StkLoc = PD_StkLoc;
}

public 
void setPD_Condition(string PD_Condition){
    this.PD_Condition =  PD_Condition;
}

public 
void setPD_Project(string PD_Project){
    this.PD_Project = PD_Project;
}
//Getters
public
int	getPD_ID(){
   return PD_ID;
}

public
string getPD_DB(){
   return PD_DB;
}

public
int getPD_Company(){
   return PD_Company;
}

public
string getPD_Plant(){
   return PD_Plant;
}

public
int getPD_PackSlipNum(){
   return PD_PackSlipNum;
}

public
int getPD_PackSlipItem(){
   return PD_PackSlipItem;
}

public
int getPD_OrderNum(){
   return PD_OrderNum;
}

public
int getPD_OrderItemNum(){
   return PD_OrderItemNum;
}

public
string getPD_ReleaseNum(){
   return PD_ReleaseNum;
}

public
string getPD_ProdID(){
   return PD_ProdID;
}

public
int getPD_Seq(){
   return PD_Seq;
}

public
string getPD_ECNumber(){
   return PD_ECNumber;
}

public
string getPD_CustPart(){
   return PD_CustPart;
}

public
string getPD_CustPartRev(){
   return PD_CustPartRev;
}

public
decimal getPD_PO(){
    return PD_PO;
}

public
decimal getPD_ShipQty(){
   return PD_ShipQty;
}

public
string getPD_ShipQtyUom(){
   return PD_ShipQtyUom;
}

public
decimal getPD_ShipQtyOE(){
   return PD_ShipQtyOE;
}

public
string getPD_ShipQtyOEUom(){
   return PD_ShipQtyOEUom;
}

public
string getPD_Status(){
   return PD_Status;
}

public
int getPD_InvoiceNum(){
   return PD_InvoiceNum;
}

public
int getPD_InvLineNum(){
   return PD_InvLineNum;
}

public
string getPD_RanNumber(){
   return PD_RanNumber;
}

public
string getPD_CustPO(){
   return PD_CustPO;
}

public
decimal getPD_CurrentCum(){
   return PD_CurrentCum;
}

public
decimal getPD_PreviousCum(){
   return PD_PreviousCum;
}

public
string getPD_ShipRef(){
   return PD_ShipRef;
}

public
string getPD_LineStatus(){
   return PD_LineStatus;
}

public
string getPD_StkLoc(){
   return PD_StkLoc;
}

}//end class
}//end namespace
