/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:25 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/PurchaseOrder/PoItemRelDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: PoItemRelDataBase.cs,v $
*   Revision 1.3  2006-12-21 19:56:25  bgularte
*   *** empty log message ***
*
*   Revision 1.2  2005/05/17 04:34:53  gmuller
*   ponga aqui un comentario
*
*   Revision 1.1  2005/04/14 03:03:08  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class PoItemRelDataBase : GenericDataBaseElement {

private int PIR_ID;
private string PIR_Database;
private int PIR_Company;
private string PIR_Plant;
private int PIR_Po;
private int PIR_PoItem;
private string PIR_PoITemRel;
private string PIR_WO;
private string PIR_Condition;
private string PIR_Revision;
private decimal PIR_Attribute1;
private decimal PIR_Attribute2;
private decimal PIR_Attribute3;
private string PIR_Attribute4;
private string PIR_Attribute5;
private decimal PIR_QtyOrdered;
private decimal PIR_QtyReceived;
private decimal PIR_QtyReturned;
private string PIR_Uom;
private decimal PIR_Price;
private string PIR_PriceUom;
private decimal PIR_ValueOrdered;
private decimal PIR_ValueReceived;
private decimal PIR_PercentComp;
private string PIR_ItemSts;
private string PIR_AutoCumApply;
private string PIR_Project;
private string PIR_SourceOrig;
private string PIR_DropShip;
private decimal PIR_HardAllocated;
private decimal PIR_InvAllocated;
private int PIR_InvidiualPick;
private string PIR_PickDtl;
private int PIR_OrdersWaiting;
private string PIR_Approved;
private int PIR_POAccountDis;
private DateTime PIR_DateReq;
private DateTime PIR_DateConfirmed;
private string PIR_Status;
private decimal PIR_ItemValue;
private decimal PIR_ItemValueLeft;
private int PIR_DefReceiveCo;
private string PIR_DefRecievePlt;
private string PIR_DefReceiveLoc;
private string PIR_Tax1;
private string PIR_Tax2;
private string PIR_Tax3;
private decimal PIR_TaxAmt1;
private decimal PIR_TaxAmt2;
private decimal PIR_TaxAmt3;

public
PoItemRelDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from poitemrel where " + getWhereCondition();

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
bool exists(){
	string sql = "select * from poitemrel where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.PIR_ID = reader.GetInt32("PIR_ID");
	this.PIR_Database = reader.GetString("PIR_Database");
	this.PIR_Company = reader.GetInt32("PIR_Company");
	this.PIR_Plant = reader.GetString("PIR_Plant");
	this.PIR_Po = reader.GetInt32("PIR_Po");
	this.PIR_PoItem = reader.GetInt32("PIR_PoItem");
	this.PIR_PoITemRel = reader.GetString("PIR_PoITemRel");
	this.PIR_WO = reader.GetString("PIR_WO");
	this.PIR_Condition = reader.GetString("PIR_Condition");
	this.PIR_Revision = reader.GetString("PIR_Revision");
	this.PIR_Attribute1 = reader.GetDecimal("PIR_Attribute1");
	this.PIR_Attribute2 = reader.GetDecimal("PIR_Attribute2");
	this.PIR_Attribute3 = reader.GetDecimal("PIR_Attribute3");
	this.PIR_Attribute4 = reader.GetString("PIR_Attribute4");
	this.PIR_Attribute5 = reader.GetString("PIR_Attribute5");
	this.PIR_QtyOrdered = reader.GetDecimal("PIR_QtyOrdered");
	this.PIR_QtyReceived = reader.GetDecimal("PIR_QtyReceived");
	this.PIR_QtyReturned = reader.GetDecimal("PIR_QtyReturned");
	this.PIR_Uom = reader.GetString("PIR_Uom");
	this.PIR_Price = reader.GetDecimal("PIR_Price");
	this.PIR_PriceUom = reader.GetString("PIR_PriceUom");
	this.PIR_ValueOrdered = reader.GetDecimal("PIR_ValueOrdered");
	this.PIR_ValueReceived = reader.GetDecimal("PIR_ValueReceived");
	this.PIR_PercentComp = reader.GetDecimal("PIR_PercentComp");
	this.PIR_ItemSts = reader.GetString("PIR_ItemSts");
	this.PIR_AutoCumApply = reader.GetString("PIR_AutoCumApply");
	this.PIR_Project = reader.GetString("PIR_Project");
	this.PIR_SourceOrig = reader.GetString("PIR_SourceOrig");
	this.PIR_DropShip = reader.GetString("PIR_DropShip");
	this.PIR_HardAllocated = reader.GetDecimal("PIR_HardAllocated");
	this.PIR_InvAllocated = reader.GetDecimal("PIR_InvAllocated");
	this.PIR_InvidiualPick = reader.GetInt32("PIR_InvidiualPick");
	this.PIR_PickDtl = reader.GetString("PIR_PickDtl");
	this.PIR_OrdersWaiting = reader.GetInt32("PIR_OrdersWaiting");
	this.PIR_Approved = reader.GetString("PIR_Approved");
	this.PIR_POAccountDis = reader.GetInt32("PIR_POAccountDis");
	this.PIR_DateReq = reader.GetDateTime("PIR_DateReq");
	this.PIR_DateConfirmed = reader.GetDateTime("PIR_DateConfirmed");
	this.PIR_Status = reader.GetString("PIR_Status");
	this.PIR_ItemValue = reader.GetDecimal("PIR_ItemValue");
	this.PIR_ItemValueLeft = reader.GetDecimal("PIR_ItemValueLeft");
	this.PIR_DefReceiveCo = reader.GetInt32("PIR_DefReceiveCo");
	this.PIR_DefRecievePlt = reader.GetString("PIR_DefRecievePlt");
	this.PIR_DefReceiveLoc = reader.GetString("PIR_DefReceiveLoc");
	this.PIR_Tax1 = reader.GetString("PIR_Tax1");
	this.PIR_Tax2 = reader.GetString("PIR_Tax2");
	this.PIR_Tax3 = reader.GetString("PIR_Tax3");
	this.PIR_TaxAmt1 = reader.GetDecimal("PIR_TaxAmt1");
	this.PIR_TaxAmt2 = reader.GetDecimal("PIR_TaxAmt2");
	this.PIR_TaxAmt3 = reader.GetDecimal("PIR_TaxAmt3");
}

public override
void write(){
	string sql = "insert into poitemrel (" + 
		"PIR_ID," +
		"PIR_Database," +
		"PIR_Company," +
		"PIR_Plant," +
		"PIR_Po," +
		"PIR_PoItem," +
		"PIR_PoITemRel," +
		"PIR_WO," +
		"PIR_Condition," +
		"PIR_Revision," +
		"PIR_Attribute1," +
		"PIR_Attribute2," +
		"PIR_Attribute3," +
		"PIR_Attribute4," +
		"PIR_Attribute5," +
		"PIR_QtyOrdered," +
		"PIR_QtyReceived," +
		"PIR_QtyReturned," +
		"PIR_Uom," +
		"PIR_Price," +
		"PIR_PriceUom," +
		"PIR_ValueOrdered," +
		"PIR_ValueReceived," +
		"PIR_PercentComp," +
		"PIR_ItemSts," +
		"PIR_AutoCumApply," +
		"PIR_Project," +
		"PIR_SourceOrig," +
		"PIR_DropShip," +
		"PIR_HardAllocated," +
		"PIR_InvAllocated," +
		"PIR_InvidiualPick," +
		"PIR_PickDtl," +
		"PIR_OrdersWaiting," +
		"PIR_Approved," +
		"PIR_POAccountDis," +
		"PIR_DateReq," +
		"PIR_DateConfirmed," +
		"PIR_Status," +
		"PIR_ItemValue," +
		"PIR_ItemValueLeft," +
		"PIR_DefReceiveCo," +
		"PIR_DefRecievePlt," +
		"PIR_DefReceiveLoc," +
		"PIR_Tax1," +
		"PIR_Tax2," +
		"PIR_Tax3," +
		"PIR_TaxAmt1," +
		"PIR_TaxAmt2," +
		"PIR_TaxAmt3" +

		") values (" + 

		"" + NumberUtil.toString(PIR_ID) + "," +
		"'" + Converter.fixString(PIR_Database) + "'," +
		"" + NumberUtil.toString(PIR_Company) + "," +
		"'" + Converter.fixString(PIR_Plant) + "'," +
		"" + NumberUtil.toString(PIR_Po) + "," +
		"" + NumberUtil.toString(PIR_PoItem) + "," +
		"'" + Converter.fixString(PIR_PoITemRel) + "'," +
		"'" + Converter.fixString(PIR_WO) + "'," +
		"'" + Converter.fixString(PIR_Condition) + "'," +
		"'" + Converter.fixString(PIR_Revision) + "'," +
		"" + NumberUtil.toString(PIR_Attribute1) + "," +
		"" + NumberUtil.toString(PIR_Attribute2) + "," +
		"" + NumberUtil.toString(PIR_Attribute3) + "," +
		"'" + Converter.fixString(PIR_Attribute4) + "'," +
		"'" + Converter.fixString(PIR_Attribute5) + "'," +
		"" + NumberUtil.toString(PIR_QtyOrdered) + "," +
		"" + NumberUtil.toString(PIR_QtyReceived) + "," +
		"" + NumberUtil.toString(PIR_QtyReturned) + "," +
		"'" + Converter.fixString(PIR_Uom) + "'," +
		"" + NumberUtil.toString(PIR_Price) + "," +
		"'" + Converter.fixString(PIR_PriceUom) + "'," +
		"" + NumberUtil.toString(PIR_ValueOrdered) + "," +
		"" + NumberUtil.toString(PIR_ValueReceived) + "," +
		"" + NumberUtil.toString(PIR_PercentComp) + "," +
		"'" + Converter.fixString(PIR_ItemSts) + "'," +
		"'" + Converter.fixString(PIR_AutoCumApply) + "'," +
		"'" + Converter.fixString(PIR_Project) + "'," +
		"'" + Converter.fixString(PIR_SourceOrig) + "'," +
		"'" + Converter.fixString(PIR_DropShip) + "'," +
		"" + NumberUtil.toString(PIR_HardAllocated) + "," +
		"" + NumberUtil.toString(PIR_InvAllocated) + "," +
		"" + NumberUtil.toString(PIR_InvidiualPick) + "," +
		"'" + Converter.fixString(PIR_PickDtl) + "'," +
		"" + NumberUtil.toString(PIR_OrdersWaiting) + "," +
		"'" + Converter.fixString(PIR_Approved) + "'," +
		"" + NumberUtil.toString(PIR_POAccountDis) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(PIR_DateReq) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(PIR_DateConfirmed) + "'," +
		"'" + Converter.fixString(PIR_Status) + "'," +
		"" + NumberUtil.toString(PIR_ItemValue) + "," +
		"" + NumberUtil.toString(PIR_ItemValueLeft) + "," +
		"" + NumberUtil.toString(PIR_DefReceiveCo) + "," +
		"'" + Converter.fixString(PIR_DefRecievePlt) + "'," +
		"'" + Converter.fixString(PIR_DefReceiveLoc) + "'," +
		"'" + Converter.fixString(PIR_Tax1) + "'," +
		"'" + Converter.fixString(PIR_Tax2) + "'," +
		"'" + Converter.fixString(PIR_Tax3) + "'," +
		"" + NumberUtil.toString(PIR_TaxAmt1) + "," +
		"" + NumberUtil.toString(PIR_TaxAmt2) + "," +
		"" + NumberUtil.toString(PIR_TaxAmt3) + ")";
	write(sql);
}

public override
void update(){
	string sql = "update poitemrel set " +
		"PIR_ID = " + NumberUtil.toString(PIR_ID) + ", " +
		"PIR_Database = '" + Converter.fixString(PIR_Database) + "', " +
		"PIR_Company = " + NumberUtil.toString(PIR_Company) + ", " +
		"PIR_Plant = '" + Converter.fixString(PIR_Plant) + "', " +
		"PIR_Po = " + NumberUtil.toString(PIR_Po) + ", " +
		"PIR_PoItem = " + NumberUtil.toString(PIR_PoItem) + ", " +
		"PIR_PoITemRel = '" + Converter.fixString(PIR_PoITemRel) + "', " +
		"PIR_WO = '" + Converter.fixString(PIR_WO) + "', " +
		"PIR_Condition = '" + Converter.fixString(PIR_Condition) + "', " +
		"PIR_Revision = '" + Converter.fixString(PIR_Revision) + "', " +
		"PIR_Attribute1 = " + NumberUtil.toString(PIR_Attribute1) + ", " +
		"PIR_Attribute2 = " + NumberUtil.toString(PIR_Attribute2) + ", " +
		"PIR_Attribute3 = " + NumberUtil.toString(PIR_Attribute3) + ", " +
		"PIR_Attribute4 = '" + Converter.fixString(PIR_Attribute4) + "', " +
		"PIR_Attribute5 = '" + Converter.fixString(PIR_Attribute5) + "', " +
		"PIR_QtyOrdered = " + NumberUtil.toString(PIR_QtyOrdered) + ", " +
		"PIR_QtyReceived = " + NumberUtil.toString(PIR_QtyReceived) + ", " +
		"PIR_QtyReturned = " + NumberUtil.toString(PIR_QtyReturned) + ", " +
		"PIR_Uom = '" + Converter.fixString(PIR_Uom) + "', " +
		"PIR_Price = " + NumberUtil.toString(PIR_Price) + ", " +
		"PIR_PriceUom = '" + Converter.fixString(PIR_PriceUom) + "', " +
		"PIR_ValueOrdered = " + NumberUtil.toString(PIR_ValueOrdered) + ", " +
		"PIR_ValueReceived = " + NumberUtil.toString(PIR_ValueReceived) + ", " +
		"PIR_PercentComp = " + NumberUtil.toString(PIR_PercentComp) + ", " +
		"PIR_ItemSts = '" + Converter.fixString(PIR_ItemSts) + "', " +
		"PIR_AutoCumApply = '" + Converter.fixString(PIR_AutoCumApply) + "', " +
		"PIR_Project = '" + Converter.fixString(PIR_Project) + "', " +
		"PIR_SourceOrig = '" + Converter.fixString(PIR_SourceOrig) + "', " +
		"PIR_DropShip = '" + Converter.fixString(PIR_DropShip) + "', " +
		"PIR_HardAllocated = " + NumberUtil.toString(PIR_HardAllocated) + ", " +
		"PIR_InvAllocated = " + NumberUtil.toString(PIR_InvAllocated) + ", " +
		"PIR_InvidiualPick = " + NumberUtil.toString(PIR_InvidiualPick) + ", " +
		"PIR_PickDtl = '" + Converter.fixString(PIR_PickDtl) + "', " +
		"PIR_OrdersWaiting = " + NumberUtil.toString(PIR_OrdersWaiting) + ", " +
		"PIR_Approved = '" + Converter.fixString(PIR_Approved) + "', " +
		"PIR_POAccountDis = " + NumberUtil.toString(PIR_POAccountDis) + ", " +
		"PIR_DateReq = '" + DateUtil.getCompleteDateRepresentation(PIR_DateReq) + "', " +
		"PIR_DateConfirmed = '" + DateUtil.getCompleteDateRepresentation(PIR_DateConfirmed) + "', " +
		"PIR_Status = '" + Converter.fixString(PIR_Status) + "', " +
		"PIR_ItemValue = " + NumberUtil.toString(PIR_ItemValue) + ", " +
		"PIR_ItemValueLeft = " + NumberUtil.toString(PIR_ItemValueLeft) + ", " +
		"PIR_DefReceiveCo = " + NumberUtil.toString(PIR_DefReceiveCo) + ", " +
		"PIR_DefRecievePlt = '" + Converter.fixString(PIR_DefRecievePlt) + "', " +
		"PIR_DefReceiveLoc = '" + Converter.fixString(PIR_DefReceiveLoc) + "', " +
		"PIR_Tax1 = '" + Converter.fixString(PIR_Tax1) + "', " +
		"PIR_Tax2 = '" + Converter.fixString(PIR_Tax2) + "', " +
		"PIR_Tax3 = '" + Converter.fixString(PIR_Tax3) + "', " +
		"PIR_TaxAmt1 = " + NumberUtil.toString(PIR_TaxAmt1) + ", " +
		"PIR_TaxAmt2 = " + NumberUtil.toString(PIR_TaxAmt2) + ", " +
		"PIR_TaxAmt3 = " + NumberUtil.toString(PIR_TaxAmt3) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from poitemrel where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"PIR_ID = " + NumberUtil.toString(PIR_ID) + "";
	return sqlWhere;
}

public
void setPIR_ID(int PIR_ID){
	this.PIR_ID = PIR_ID;
}

public
void setPIR_Database(string PIR_Database){
	this.PIR_Database = PIR_Database;
}

public
void setPIR_Company(int PIR_Company){
	this.PIR_Company = PIR_Company;
}

public
void setPIR_Plant(string PIR_Plant){
	this.PIR_Plant = PIR_Plant;
}

public
void setPIR_Po(int PIR_Po){
	this.PIR_Po = PIR_Po;
}

public
void setPIR_PoItem(int PIR_PoItem){
	this.PIR_PoItem = PIR_PoItem;
}

public
void setPIR_PoITemRel(string PIR_PoITemRel){
	this.PIR_PoITemRel = PIR_PoITemRel;
}

public
void setPIR_WO(string PIR_WO){
	this.PIR_WO = PIR_WO;
}

public
void setPIR_Condition(string PIR_Condition){
	this.PIR_Condition = PIR_Condition;
}

public
void setPIR_Revision(string PIR_Revision){
	this.PIR_Revision = PIR_Revision;
}

public
void setPIR_Attribute1(decimal PIR_Attribute1){
	this.PIR_Attribute1 = PIR_Attribute1;
}

public
void setPIR_Attribute2(decimal PIR_Attribute2){
	this.PIR_Attribute2 = PIR_Attribute2;
}

public
void setPIR_Attribute3(decimal PIR_Attribute3){
	this.PIR_Attribute3 = PIR_Attribute3;
}

public
void setPIR_Attribute4(string PIR_Attribute4){
	this.PIR_Attribute4 = PIR_Attribute4;
}

public
void setPIR_Attribute5(string PIR_Attribute5){
	this.PIR_Attribute5 = PIR_Attribute5;
}

public
void setPIR_QtyOrdered(decimal PIR_QtyOrdered){
	this.PIR_QtyOrdered = PIR_QtyOrdered;
}

public
void setPIR_QtyReceived(decimal PIR_QtyReceived){
	this.PIR_QtyReceived = PIR_QtyReceived;
}

public
void setPIR_QtyReturned(decimal PIR_QtyReturned){
	this.PIR_QtyReturned = PIR_QtyReturned;
}

public
void setPIR_Uom(string PIR_Uom){
	this.PIR_Uom = PIR_Uom;
}

public
void setPIR_Price(decimal PIR_Price){
	this.PIR_Price = PIR_Price;
}

public
void setPIR_PriceUom(string PIR_PriceUom){
	this.PIR_PriceUom = PIR_PriceUom;
}

public
void setPIR_ValueOrdered(decimal PIR_ValueOrdered){
	this.PIR_ValueOrdered = PIR_ValueOrdered;
}

public
void setPIR_ValueReceived(decimal PIR_ValueReceived){
	this.PIR_ValueReceived = PIR_ValueReceived;
}

public
void setPIR_PercentComp(decimal PIR_PercentComp){
	this.PIR_PercentComp = PIR_PercentComp;
}

public
void setPIR_ItemSts(string PIR_ItemSts){
	this.PIR_ItemSts = PIR_ItemSts;
}

public
void setPIR_AutoCumApply(string PIR_AutoCumApply){
	this.PIR_AutoCumApply = PIR_AutoCumApply;
}

public
void setPIR_Project(string PIR_Project){
	this.PIR_Project = PIR_Project;
}

public
void setPIR_SourceOrig(string PIR_SourceOrig){
	this.PIR_SourceOrig = PIR_SourceOrig;
}

public
void setPIR_DropShip(string PIR_DropShip){
	this.PIR_DropShip = PIR_DropShip;
}

public
void setPIR_HardAllocated(decimal PIR_HardAllocated){
	this.PIR_HardAllocated = PIR_HardAllocated;
}

public
void setPIR_InvAllocated(decimal PIR_InvAllocated){
	this.PIR_InvAllocated = PIR_InvAllocated;
}

public
void setPIR_InvidiualPick(int PIR_InvidiualPick){
	this.PIR_InvidiualPick = PIR_InvidiualPick;
}

public
void setPIR_PickDtl(string PIR_PickDtl){
	this.PIR_PickDtl = PIR_PickDtl;
}

public
void setPIR_OrdersWaiting(int PIR_OrdersWaiting){
	this.PIR_OrdersWaiting = PIR_OrdersWaiting;
}

public
void setPIR_Approved(string PIR_Approved){
	this.PIR_Approved = PIR_Approved;
}

public
void setPIR_POAccountDis(int PIR_POAccountDis){
	this.PIR_POAccountDis = PIR_POAccountDis;
}

public
void setPIR_DateReq(DateTime PIR_DateReq){
	this.PIR_DateReq = PIR_DateReq;
}

public
void setPIR_DateConfirmed(DateTime PIR_DateConfirmed){
	this.PIR_DateConfirmed = PIR_DateConfirmed;
}

public
void setPIR_Status(string PIR_Status){
	this.PIR_Status = PIR_Status;
}

public
void setPIR_ItemValue(decimal PIR_ItemValue){
	this.PIR_ItemValue = PIR_ItemValue;
}

public
void setPIR_ItemValueLeft(decimal PIR_ItemValueLeft){
	this.PIR_ItemValueLeft = PIR_ItemValueLeft;
}

public
void setPIR_DefReceiveCo(int PIR_DefReceiveCo){
	this.PIR_DefReceiveCo = PIR_DefReceiveCo;
}

public
void setPIR_DefRecievePlt(string PIR_DefRecievePlt){
	this.PIR_DefRecievePlt = PIR_DefRecievePlt;
}

public
void setPIR_DefReceiveLoc(string PIR_DefReceiveLoc){
	this.PIR_DefReceiveLoc = PIR_DefReceiveLoc;
}

public
void setPIR_Tax1(string PIR_Tax1){
	this.PIR_Tax1 = PIR_Tax1;
}

public
void setPIR_Tax2(string PIR_Tax2){
	this.PIR_Tax2 = PIR_Tax2;
}

public
void setPIR_Tax3(string PIR_Tax3){
	this.PIR_Tax3 = PIR_Tax3;
}

public
void setPIR_TaxAmt1(decimal PIR_TaxAmt1){
	this.PIR_TaxAmt1 = PIR_TaxAmt1;
}

public
void setPIR_TaxAmt2(decimal PIR_TaxAmt2){
	this.PIR_TaxAmt2 = PIR_TaxAmt2;
}

public
void setPIR_TaxAmt3(decimal PIR_TaxAmt3){
	this.PIR_TaxAmt3 = PIR_TaxAmt3;
}

public
int getPIR_ID(){
	return PIR_ID;
}

public
string getPIR_Database(){
	return PIR_Database;
}

public
int getPIR_Company(){
	return PIR_Company;
}

public
string getPIR_Plant(){
	return PIR_Plant;
}

public
int getPIR_Po(){
	return PIR_Po;
}

public
int getPIR_PoItem(){
	return PIR_PoItem;
}

public
string getPIR_PoITemRel(){
	return PIR_PoITemRel;
}

public
string getPIR_WO(){
	return PIR_WO;
}

public
string getPIR_Condition(){
	return PIR_Condition;
}

public
string getPIR_Revision(){
	return PIR_Revision;
}

public
decimal getPIR_Attribute1(){
	return PIR_Attribute1;
}

public
decimal getPIR_Attribute2(){
	return PIR_Attribute2;
}

public
decimal getPIR_Attribute3(){
	return PIR_Attribute3;
}

public
string getPIR_Attribute4(){
	return PIR_Attribute4;
}

public
string getPIR_Attribute5(){
	return PIR_Attribute5;
}

public
decimal getPIR_QtyOrdered(){
	return PIR_QtyOrdered;
}

public
decimal getPIR_QtyReceived(){
	return PIR_QtyReceived;
}

public
decimal getPIR_QtyReturned(){
	return PIR_QtyReturned;
}

public
string getPIR_Uom(){
	return PIR_Uom;
}

public
decimal getPIR_Price(){
	return PIR_Price;
}

public
string getPIR_PriceUom(){
	return PIR_PriceUom;
}

public
decimal getPIR_ValueOrdered(){
	return PIR_ValueOrdered;
}

public
decimal getPIR_ValueReceived(){
	return PIR_ValueReceived;
}

public
decimal getPIR_PercentComp(){
	return PIR_PercentComp;
}

public
string getPIR_ItemSts(){
	return PIR_ItemSts;
}

public
string getPIR_AutoCumApply(){
	return PIR_AutoCumApply;
}

public
string getPIR_Project(){
	return PIR_Project;
}

public
string getPIR_SourceOrig(){
	return PIR_SourceOrig;
}

public
string getPIR_DropShip(){
	return PIR_DropShip;
}

public
decimal getPIR_HardAllocated(){
	return PIR_HardAllocated;
}

public
decimal getPIR_InvAllocated(){
	return PIR_InvAllocated;
}

public
int getPIR_InvidiualPick(){
	return PIR_InvidiualPick;
}

public
string getPIR_PickDtl(){
	return PIR_PickDtl;
}

public
int getPIR_OrdersWaiting(){
	return PIR_OrdersWaiting;
}

public
string getPIR_Approved(){
	return PIR_Approved;
}

public
int getPIR_POAccountDis(){
	return PIR_POAccountDis;
}

public
DateTime getPIR_DateReq(){
	return PIR_DateReq;
}

public
DateTime getPIR_DateConfirmed(){
	return PIR_DateConfirmed;
}

public
string getPIR_Status(){
	return PIR_Status;
}

public
decimal getPIR_ItemValue(){
	return PIR_ItemValue;
}

public
decimal getPIR_ItemValueLeft(){
	return PIR_ItemValueLeft;
}

public
int getPIR_DefReceiveCo(){
	return PIR_DefReceiveCo;
}

public
string getPIR_DefRecievePlt(){
	return PIR_DefRecievePlt;
}

public
string getPIR_DefReceiveLoc(){
	return PIR_DefReceiveLoc;
}

public
string getPIR_Tax1(){
	return PIR_Tax1;
}

public
string getPIR_Tax2(){
	return PIR_Tax2;
}

public
string getPIR_Tax3(){
	return PIR_Tax3;
}

public
decimal getPIR_TaxAmt1(){
	return PIR_TaxAmt1;
}

public
decimal getPIR_TaxAmt2(){
	return PIR_TaxAmt2;
}

public
decimal getPIR_TaxAmt3(){
	return PIR_TaxAmt3;
}

} // class

} // package