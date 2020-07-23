/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author Claudia Melo$ 
*   $Date 13-04-2005$ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/PurchaseOrder/PoItemDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: PoItemDataBase.cs,v $
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
class PoItemDataBase : GenericDataBaseElement {

private int POI_ID;
private string POI_Database;
private int POI_Company;
private string POI_Plant;
private int POI_Po;
private int POI_PoItem;
private string POI_POType;
private string POI_POSource;
private string POI_Part;
private int POI_Sequence;
private string POI_WO;
private string POI_Revision;
private string POI_BusPartner;
private string POI_BusPartnerPart;
private string POI_Manufacturer;
private string POI_Model;
private decimal POI_Attribute1;
private decimal POI_Attribute2;
private decimal POI_Attribute3;
private string POI_Attribute4;
private string POI_Attribute5;
private string POI_Condition;
private decimal POI_QtyOrdered;
private decimal POI_QtyReceived;
private decimal POI_QtyReturned;
private string POI_Uom;
private decimal POI_Price;
private string POI_PriceUom;
private decimal POI_ValueOrdered;
private decimal POI_ValueReceived;
private decimal POI_ValueRemain;
private decimal POI_PercentComp;
private string POI_ItemSts;
private string POI_AutoCumApply;
private string POI_Project;
private string POI_SourceOrig;
private string POI_DropShip;
private decimal POI_Allocated;
private string POI_OrdersWaiting;
private string POI_Approved;
private string POI_POAccountDis;
private DateTime POI_DateReq;
private DateTime POI_DateConfirmed;
private string POI_ReqCode;
private int POI_DefReceiveCo;
private string POI_DefRecievePlt;
private string POI_DefReceiveLoc;
private string POI_Tax1;
private string POI_Tax2;
private string POI_Tax3;
private decimal POI_TaxAmt1;
private decimal POI_TaxAmt2;
private decimal POI_TaxAmt3;

public
PoItemDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from poitem where " + getWhereCondition();

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
	string sql = "select * from poitem where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.POI_ID = reader.GetInt32("POI_ID");
	this.POI_Database = reader.GetString("POI_Database");
	this.POI_Company = reader.GetInt32("POI_Company");
	this.POI_Plant = reader.GetString("POI_Plant");
	this.POI_Po = reader.GetInt32("POI_Po");
	this.POI_PoItem = reader.GetInt32("POI_PoItem");
	this.POI_POType = reader.GetString("POI_POType");
	this.POI_POSource = reader.GetString("POI_POSource");
	this.POI_Part = reader.GetString("POI_Part");
	this.POI_Sequence = reader.GetInt32("POI_Sequence");
	this.POI_WO = reader.GetString("POI_WO");
	this.POI_Revision = reader.GetString("POI_Revision");
	this.POI_BusPartner = reader.GetString("POI_BusPartner");
	this.POI_BusPartnerPart = reader.GetString("POI_BusPartnerPart");
	this.POI_Manufacturer = reader.GetString("POI_Manufacturer");
	this.POI_Model = reader.GetString("POI_Model");
	this.POI_Attribute1 = reader.GetDecimal("POI_Attribute1");
	this.POI_Attribute2 = reader.GetDecimal("POI_Attribute2");
	this.POI_Attribute3 = reader.GetDecimal("POI_Attribute3");
	this.POI_Attribute4 = reader.GetString("POI_Attribute4");
	this.POI_Attribute5 = reader.GetString("POI_Attribute5");
	this.POI_Condition = reader.GetString("POI_Condition");
	this.POI_QtyOrdered = reader.GetDecimal("POI_QtyOrdered");
	this.POI_QtyReceived = reader.GetDecimal("POI_QtyReceived");
	this.POI_QtyReturned = reader.GetDecimal("POI_QtyReturned");
	this.POI_Uom = reader.GetString("POI_Uom");
	this.POI_Price = reader.GetDecimal("POI_Price");
	this.POI_PriceUom = reader.GetString("POI_PriceUom");
	this.POI_ValueOrdered = reader.GetDecimal("POI_ValueOrdered");
	this.POI_ValueReceived = reader.GetDecimal("POI_ValueReceived");
	this.POI_ValueRemain = reader.GetDecimal("POI_ValueRemain");
	this.POI_PercentComp = reader.GetDecimal("POI_PercentComp");
	this.POI_ItemSts = reader.GetString("POI_ItemSts");
	this.POI_AutoCumApply = reader.GetString("POI_AutoCumApply");
	this.POI_Project = reader.GetString("POI_Project");
	this.POI_SourceOrig = reader.GetString("POI_SourceOrig");
	this.POI_DropShip = reader.GetString("POI_DropShip");
	this.POI_Allocated = reader.GetDecimal("POI_Allocated");
	this.POI_OrdersWaiting = reader.GetString("POI_OrdersWaiting");
	this.POI_Approved = reader.GetString("POI_Approved");
	this.POI_POAccountDis = reader.GetString("POI_POAccountDis");
	this.POI_DateReq = reader.GetDateTime("POI_DateReq");
	this.POI_DateConfirmed = reader.GetDateTime("POI_DateConfirmed");
	this.POI_ReqCode = reader.GetString("POI_ReqCode");
	this.POI_DefReceiveCo = reader.GetInt32("POI_DefReceiveCo");
	this.POI_DefRecievePlt = reader.GetString("POI_DefRecievePlt");
	this.POI_DefReceiveLoc = reader.GetString("POI_DefReceiveLoc");
	this.POI_Tax1 = reader.GetString("POI_Tax1");
	this.POI_Tax2 = reader.GetString("POI_Tax2");
	this.POI_Tax3 = reader.GetString("POI_Tax3");
	this.POI_TaxAmt1 = reader.GetDecimal("POI_TaxAmt1");
	this.POI_TaxAmt2 = reader.GetDecimal("POI_TaxAmt2");
	this.POI_TaxAmt3 = reader.GetDecimal("POI_TaxAmt3");
}

public override
void write(){
	string sql = "insert into poitem (" + 
		"POI_ID," +
		"POI_Database," +
		"POI_Company," +
		"POI_Plant," +
		"POI_Po," +
		"POI_PoItem," +
		"POI_POType," +
		"POI_POSource," +
		"POI_Part," +
		"POI_Sequence," +
		"POI_WO," +
		"POI_Revision," +
		"POI_BusPartner," +
		"POI_BusPartnerPart," +
		"POI_Manufacturer," +
		"POI_Model," +
		"POI_Attribute1," +
		"POI_Attribute2," +
		"POI_Attribute3," +
		"POI_Attribute4," +
		"POI_Attribute5," +
		"POI_Condition," +
		"POI_QtyOrdered," +
		"POI_QtyReceived," +
		"POI_QtyReturned," +
		"POI_Uom," +
		"POI_Price," +
		"POI_PriceUom," +
		"POI_ValueOrdered," +
		"POI_ValueReceived," +
		"POI_ValueRemain," +
		"POI_PercentComp," +
		"POI_ItemSts," +
		"POI_AutoCumApply," +
		"POI_Project," +
		"POI_SourceOrig," +
		"POI_DropShip," +
		"POI_Allocated," +
		"POI_OrdersWaiting," +
		"POI_Approved," +
		"POI_POAccountDis," +
		"POI_DateReq," +
		"POI_DateConfirmed," +
		"POI_ReqCode," +
		"POI_DefReceiveCo," +
		"POI_DefRecievePlt," +
		"POI_DefReceiveLoc," +
		"POI_Tax1," +
		"POI_Tax2," +
		"POI_Tax3," +
		"POI_TaxAmt1," +
		"POI_TaxAmt2," +
		"POI_TaxAmt3" +

		") values (" + 

		"" + NumberUtil.toString(POI_ID) + "," +
		"'" + Converter.fixString(POI_Database) + "'," +
		"" + NumberUtil.toString(POI_Company) + "," +
		"'" + Converter.fixString(POI_Plant) + "'," +
		"" + NumberUtil.toString(POI_Po) + "," +
		"" + NumberUtil.toString(POI_PoItem) + "," +
		"'" + Converter.fixString(POI_POType) + "'," +
		"'" + Converter.fixString(POI_POSource) + "'," +
		"'" + Converter.fixString(POI_Part) + "'," +
		"" + NumberUtil.toString(POI_Sequence) + "," +
		"'" + Converter.fixString(POI_WO) + "'," +
		"'" + Converter.fixString(POI_Revision) + "'," +
		"'" + Converter.fixString(POI_BusPartner) + "'," +
		"'" + Converter.fixString(POI_BusPartnerPart) + "'," +
		"'" + Converter.fixString(POI_Manufacturer) + "'," +
		"'" + Converter.fixString(POI_Model) + "'," +
		"" + NumberUtil.toString(POI_Attribute1) + "," +
		"" + NumberUtil.toString(POI_Attribute2) + "," +
		"" + NumberUtil.toString(POI_Attribute3) + "," +
		"'" + Converter.fixString(POI_Attribute4) + "'," +
		"'" + Converter.fixString(POI_Attribute5) + "'," +
		"'" + Converter.fixString(POI_Condition) + "'," +
		"" + NumberUtil.toString(POI_QtyOrdered) + "," +
		"" + NumberUtil.toString(POI_QtyReceived) + "," +
		"" + NumberUtil.toString(POI_QtyReturned) + "," +
		"'" + Converter.fixString(POI_Uom) + "'," +
		"" + NumberUtil.toString(POI_Price) + "," +
		"'" + Converter.fixString(POI_PriceUom) + "'," +
		"" + NumberUtil.toString(POI_ValueOrdered) + "," +
		"" + NumberUtil.toString(POI_ValueReceived) + "," +
		"" + NumberUtil.toString(POI_ValueRemain) + "," +
		"" + NumberUtil.toString(POI_PercentComp) + "," +
		"'" + Converter.fixString(POI_ItemSts) + "'," +
		"'" + Converter.fixString(POI_AutoCumApply) + "'," +
		"'" + Converter.fixString(POI_Project) + "'," +
		"'" + Converter.fixString(POI_SourceOrig) + "'," +
		"'" + Converter.fixString(POI_DropShip) + "'," +
		"" + NumberUtil.toString(POI_Allocated) + "," +
		"'" + Converter.fixString(POI_OrdersWaiting) + "'," +
		"'" + Converter.fixString(POI_Approved) + "'," +
		"'" + Converter.fixString(POI_POAccountDis) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(POI_DateReq) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(POI_DateConfirmed) + "'," +
		"'" + Converter.fixString(POI_ReqCode) + "'," +
		"" + NumberUtil.toString(POI_DefReceiveCo) + "," +
		"'" + Converter.fixString(POI_DefRecievePlt) + "'," +
		"'" + Converter.fixString(POI_DefReceiveLoc) + "'," +
		"'" + Converter.fixString(POI_Tax1) + "'," +
		"'" + Converter.fixString(POI_Tax2) + "'," +
		"'" + Converter.fixString(POI_Tax3) + "'," +
		"" + NumberUtil.toString(POI_TaxAmt1) + "," +
		"" + NumberUtil.toString(POI_TaxAmt2) + "," +
		"" + NumberUtil.toString(POI_TaxAmt3) + ")";
	write(sql);
}

public override
void update(){
	string sql = "update poitem set " +
		"POI_ID = " + NumberUtil.toString(POI_ID) + ", " +
		"POI_Database = '" + Converter.fixString(POI_Database) + "', " +
		"POI_Company = " + NumberUtil.toString(POI_Company) + ", " +
		"POI_Plant = '" + Converter.fixString(POI_Plant) + "', " +
		"POI_Po = " + NumberUtil.toString(POI_Po) + ", " +
		"POI_PoItem = " + NumberUtil.toString(POI_PoItem) + ", " +
		"POI_POType = '" + Converter.fixString(POI_POType) + "', " +
		"POI_POSource = '" + Converter.fixString(POI_POSource) + "', " +
		"POI_Part = '" + Converter.fixString(POI_Part) + "', " +
		"POI_Sequence = " + NumberUtil.toString(POI_Sequence) + ", " +
		"POI_WO = '" + Converter.fixString(POI_WO) + "', " +
		"POI_Revision = '" + Converter.fixString(POI_Revision) + "', " +
		"POI_BusPartner = '" + Converter.fixString(POI_BusPartner) + "', " +
		"POI_BusPartnerPart = '" + Converter.fixString(POI_BusPartnerPart) + "', " +
		"POI_Manufacturer = '" + Converter.fixString(POI_Manufacturer) + "', " +
		"POI_Model = '" + Converter.fixString(POI_Model) + "', " +
		"POI_Attribute1 = " + NumberUtil.toString(POI_Attribute1) + ", " +
		"POI_Attribute2 = " + NumberUtil.toString(POI_Attribute2) + ", " +
		"POI_Attribute3 = " + NumberUtil.toString(POI_Attribute3) + ", " +
		"POI_Attribute4 = '" + Converter.fixString(POI_Attribute4) + "', " +
		"POI_Attribute5 = '" + Converter.fixString(POI_Attribute5) + "', " +
		"POI_Condition = '" + Converter.fixString(POI_Condition) + "', " +
		"POI_QtyOrdered = " + NumberUtil.toString(POI_QtyOrdered) + ", " +
		"POI_QtyReceived = " + NumberUtil.toString(POI_QtyReceived) + ", " +
		"POI_QtyReturned = " + NumberUtil.toString(POI_QtyReturned) + ", " +
		"POI_Uom = '" + Converter.fixString(POI_Uom) + "', " +
		"POI_Price = " + NumberUtil.toString(POI_Price) + ", " +
		"POI_PriceUom = '" + Converter.fixString(POI_PriceUom) + "', " +
		"POI_ValueOrdered = " + NumberUtil.toString(POI_ValueOrdered) + ", " +
		"POI_ValueReceived = " + NumberUtil.toString(POI_ValueReceived) + ", " +
		"POI_ValueRemain = " + NumberUtil.toString(POI_ValueRemain) + ", " +
		"POI_PercentComp = " + NumberUtil.toString(POI_PercentComp) + ", " +
		"POI_ItemSts = '" + Converter.fixString(POI_ItemSts) + "', " +
		"POI_AutoCumApply = '" + Converter.fixString(POI_AutoCumApply) + "', " +
		"POI_Project = '" + Converter.fixString(POI_Project) + "', " +
		"POI_SourceOrig = '" + Converter.fixString(POI_SourceOrig) + "', " +
		"POI_DropShip = '" + Converter.fixString(POI_DropShip) + "', " +
		"POI_Allocated = " + NumberUtil.toString(POI_Allocated) + ", " +
		"POI_OrdersWaiting = '" + Converter.fixString(POI_OrdersWaiting) + "', " +
		"POI_Approved = '" + Converter.fixString(POI_Approved) + "', " +
		"POI_POAccountDis = '" + Converter.fixString(POI_POAccountDis) + "', " +
		"POI_DateReq = '" + DateUtil.getCompleteDateRepresentation(POI_DateReq) + "', " +
		"POI_DateConfirmed = '" + DateUtil.getCompleteDateRepresentation(POI_DateConfirmed) + "', " +
		"POI_ReqCode = '" + Converter.fixString(POI_ReqCode) + "', " +
		"POI_DefReceiveCo = " + NumberUtil.toString(POI_DefReceiveCo) + ", " +
		"POI_DefRecievePlt = '" + Converter.fixString(POI_DefRecievePlt) + "', " +
		"POI_DefReceiveLoc = '" + Converter.fixString(POI_DefReceiveLoc) + "', " +
		"POI_Tax1 = '" + Converter.fixString(POI_Tax1) + "', " +
		"POI_Tax2 = '" + Converter.fixString(POI_Tax2) + "', " +
		"POI_Tax3 = '" + Converter.fixString(POI_Tax3) + "', " +
		"POI_TaxAmt1 = " + NumberUtil.toString(POI_TaxAmt1) + ", " +
		"POI_TaxAmt2 = " + NumberUtil.toString(POI_TaxAmt2) + ", " +
		"POI_TaxAmt3 = " + NumberUtil.toString(POI_TaxAmt3) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from poitem where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"POI_ID = " + NumberUtil.toString(POI_ID) + "";
	return sqlWhere;
}

public
void setPOI_ID(int POI_ID){
	this.POI_ID = POI_ID;
}

public
void setPOI_Database(string POI_Database){
	this.POI_Database = POI_Database;
}

public
void setPOI_Company(int POI_Company){
	this.POI_Company = POI_Company;
}

public
void setPOI_Plant(string POI_Plant){
	this.POI_Plant = POI_Plant;
}

public
void setPOI_Po(int POI_Po){
	this.POI_Po = POI_Po;
}

public
void setPOI_PoItem(int POI_PoItem){
	this.POI_PoItem = POI_PoItem;
}

public
void setPOI_POType(string POI_POType){
	this.POI_POType = POI_POType;
}

public
void setPOI_POSource(string POI_POSource){
	this.POI_POSource = POI_POSource;
}

public
void setPOI_Part(string POI_Part){
	this.POI_Part = POI_Part;
}

public
void setPOI_Sequence(int POI_Sequence){
	this.POI_Sequence = POI_Sequence;
}

public
void setPOI_WO(string POI_WO){
	this.POI_WO = POI_WO;
}

public
void setPOI_Revision(string POI_Revision){
	this.POI_Revision = POI_Revision;
}

public
void setPOI_BusPartner(string POI_BusPartner){
	this.POI_BusPartner = POI_BusPartner;
}

public
void setPOI_BusPartnerPart(string POI_BusPartnerPart){
	this.POI_BusPartnerPart = POI_BusPartnerPart;
}

public
void setPOI_Manufacturer(string POI_Manufacturer){
	this.POI_Manufacturer = POI_Manufacturer;
}

public
void setPOI_Model(string POI_Model){
	this.POI_Model = POI_Model;
}

public
void setPOI_Attribute1(decimal POI_Attribute1){
	this.POI_Attribute1 = POI_Attribute1;
}

public
void setPOI_Attribute2(decimal POI_Attribute2){
	this.POI_Attribute2 = POI_Attribute2;
}

public
void setPOI_Attribute3(decimal POI_Attribute3){
	this.POI_Attribute3 = POI_Attribute3;
}

public
void setPOI_Attribute4(string POI_Attribute4){
	this.POI_Attribute4 = POI_Attribute4;
}

public
void setPOI_Attribute5(string POI_Attribute5){
	this.POI_Attribute5 = POI_Attribute5;
}

public
void setPOI_Condition(string POI_Condition){
	this.POI_Condition = POI_Condition;
}

public
void setPOI_QtyOrdered(decimal POI_QtyOrdered){
	this.POI_QtyOrdered = POI_QtyOrdered;
}

public
void setPOI_QtyReceived(decimal POI_QtyReceived){
	this.POI_QtyReceived = POI_QtyReceived;
}

public
void setPOI_QtyReturned(decimal POI_QtyReturned){
	this.POI_QtyReturned = POI_QtyReturned;
}

public
void setPOI_Uom(string POI_Uom){
	this.POI_Uom = POI_Uom;
}

public
void setPOI_Price(decimal POI_Price){
	this.POI_Price = POI_Price;
}

public
void setPOI_PriceUom(string POI_PriceUom){
	this.POI_PriceUom = POI_PriceUom;
}

public
void setPOI_ValueOrdered(decimal POI_ValueOrdered){
	this.POI_ValueOrdered = POI_ValueOrdered;
}

public
void setPOI_ValueReceived(decimal POI_ValueReceived){
	this.POI_ValueReceived = POI_ValueReceived;
}

public
void setPOI_ValueRemain(decimal POI_ValueRemain){
	this.POI_ValueRemain = POI_ValueRemain;
}

public
void setPOI_PercentComp(decimal POI_PercentComp){
	this.POI_PercentComp = POI_PercentComp;
}

public
void setPOI_ItemSts(string POI_ItemSts){
	this.POI_ItemSts = POI_ItemSts;
}

public
void setPOI_AutoCumApply(string POI_AutoCumApply){
	this.POI_AutoCumApply = POI_AutoCumApply;
}

public
void setPOI_Project(string POI_Project){
	this.POI_Project = POI_Project;
}

public
void setPOI_SourceOrig(string POI_SourceOrig){
	this.POI_SourceOrig = POI_SourceOrig;
}

public
void setPOI_DropShip(string POI_DropShip){
	this.POI_DropShip = POI_DropShip;
}

public
void setPOI_Allocated(decimal POI_Allocated){
	this.POI_Allocated = POI_Allocated;
}

public
void setPOI_OrdersWaiting(string POI_OrdersWaiting){
	this.POI_OrdersWaiting = POI_OrdersWaiting;
}

public
void setPOI_Approved(string POI_Approved){
	this.POI_Approved = POI_Approved;
}

public
void setPOI_POAccountDis(string POI_POAccountDis){
	this.POI_POAccountDis = POI_POAccountDis;
}

public
void setPOI_DateReq(DateTime POI_DateReq){
	this.POI_DateReq = POI_DateReq;
}

public
void setPOI_DateConfirmed(DateTime POI_DateConfirmed){
	this.POI_DateConfirmed = POI_DateConfirmed;
}

public
void setPOI_ReqCode(string POI_ReqCode){
	this.POI_ReqCode = POI_ReqCode;
}

public
void setPOI_DefReceiveCo(int POI_DefReceiveCo){
	this.POI_DefReceiveCo = POI_DefReceiveCo;
}

public
void setPOI_DefRecievePlt(string POI_DefRecievePlt){
	this.POI_DefRecievePlt = POI_DefRecievePlt;
}

public
void setPOI_DefReceiveLoc(string POI_DefReceiveLoc){
	this.POI_DefReceiveLoc = POI_DefReceiveLoc;
}

public
void setPOI_Tax1(string POI_Tax1){
	this.POI_Tax1 = POI_Tax1;
}

public
void setPOI_Tax2(string POI_Tax2){
	this.POI_Tax2 = POI_Tax2;
}

public
void setPOI_Tax3(string POI_Tax3){
	this.POI_Tax3 = POI_Tax3;
}

public
void setPOI_TaxAmt1(decimal POI_TaxAmt1){
	this.POI_TaxAmt1 = POI_TaxAmt1;
}

public
void setPOI_TaxAmt2(decimal POI_TaxAmt2){
	this.POI_TaxAmt2 = POI_TaxAmt2;
}

public
void setPOI_TaxAmt3(decimal POI_TaxAmt3){
	this.POI_TaxAmt3 = POI_TaxAmt3;
}

public
int getPOI_ID(){
	return POI_ID;
}

public
string getPOI_Database(){
	return POI_Database;
}

public
int getPOI_Company(){
	return POI_Company;
}

public
string getPOI_Plant(){
	return POI_Plant;
}

public
int getPOI_Po(){
	return POI_Po;
}

public
int getPOI_PoItem(){
	return POI_PoItem;
}

public
string getPOI_POType(){
	return POI_POType;
}

public
string getPOI_POSource(){
	return POI_POSource;
}

public
string getPOI_Part(){
	return POI_Part;
}

public
int getPOI_Sequence(){
	return POI_Sequence;
}

public
string getPOI_WO(){
	return POI_WO;
}

public
string getPOI_Revision(){
	return POI_Revision;
}

public
string getPOI_BusPartner(){
	return POI_BusPartner;
}

public
string getPOI_BusPartnerPart(){
	return POI_BusPartnerPart;
}

public
string getPOI_Manufacturer(){
	return POI_Manufacturer;
}

public
string getPOI_Model(){
	return POI_Model;
}

public
decimal getPOI_Attribute1(){
	return POI_Attribute1;
}

public
decimal getPOI_Attribute2(){
	return POI_Attribute2;
}

public
decimal getPOI_Attribute3(){
	return POI_Attribute3;
}

public
string getPOI_Attribute4(){
	return POI_Attribute4;
}

public
string getPOI_Attribute5(){
	return POI_Attribute5;
}

public
string getPOI_Condition(){
	return POI_Condition;
}

public
decimal getPOI_QtyOrdered(){
	return POI_QtyOrdered;
}

public
decimal getPOI_QtyReceived(){
	return POI_QtyReceived;
}

public
decimal getPOI_QtyReturned(){
	return POI_QtyReturned;
}

public
string getPOI_Uom(){
	return POI_Uom;
}

public
decimal getPOI_Price(){
	return POI_Price;
}

public
string getPOI_PriceUom(){
	return POI_PriceUom;
}

public
decimal getPOI_ValueOrdered(){
	return POI_ValueOrdered;
}

public
decimal getPOI_ValueReceived(){
	return POI_ValueReceived;
}

public
decimal getPOI_ValueRemain(){
	return POI_ValueRemain;
}

public
decimal getPOI_PercentComp(){
	return POI_PercentComp;
}

public
string getPOI_ItemSts(){
	return POI_ItemSts;
}

public
string getPOI_AutoCumApply(){
	return POI_AutoCumApply;
}

public
string getPOI_Project(){
	return POI_Project;
}

public
string getPOI_SourceOrig(){
	return POI_SourceOrig;
}

public
string getPOI_DropShip(){
	return POI_DropShip;
}

public
decimal getPOI_Allocated(){
	return POI_Allocated;
}

public
string getPOI_OrdersWaiting(){
	return POI_OrdersWaiting;
}

public
string getPOI_Approved(){
	return POI_Approved;
}

public
string getPOI_POAccountDis(){
	return POI_POAccountDis;
}

public
DateTime getPOI_DateReq(){
	return POI_DateReq;
}

public
DateTime getPOI_DateConfirmed(){
	return POI_DateConfirmed;
}

public
string getPOI_ReqCode(){
	return POI_ReqCode;
}

public
int getPOI_DefReceiveCo(){
	return POI_DefReceiveCo;
}

public
string getPOI_DefRecievePlt(){
	return POI_DefRecievePlt;
}

public
string getPOI_DefReceiveLoc(){
	return POI_DefReceiveLoc;
}

public
string getPOI_Tax1(){
	return POI_Tax1;
}

public
string getPOI_Tax2(){
	return POI_Tax2;
}

public
string getPOI_Tax3(){
	return POI_Tax3;
}

public
decimal getPOI_TaxAmt1(){
	return POI_TaxAmt1;
}

public
decimal getPOI_TaxAmt2(){
	return POI_TaxAmt2;
}

public
decimal getPOI_TaxAmt3(){
	return POI_TaxAmt3;
}

} // class

} // package