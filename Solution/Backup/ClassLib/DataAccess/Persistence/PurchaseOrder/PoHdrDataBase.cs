/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:25 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/PurchaseOrder/PoHdrDataBase.cs,v $ 
*   $State: Exp $ 
*   $Log: PoHdrDataBase.cs,v $
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
class PoHdrDataBase : GenericDataBaseElement {

private int POH_Id;
private string POH_Db;
private int POH_Company;
private string POH_Plant;
private int POH_PO;
private string POH_POStatus;
private DateTime POH_PODate;
private DateTime POH_DtTmCreated;
private string POH_POSource;
private string POH_POType;
private string POH_BPNumber;
private string POH_BPName;
private string POH_BPRemitTo;
private string POH_CustOrdShipAdr;
private string POH_ShiptoBPNum;
private string POH_ShiptoBPName;
private string POH_ShiptoAddress1;
private string POH_ShiptoAddress2;
private string POH_ShiptoAddress3;
private string POH_ShiptoPostZip;
private string POH_City;
private string POH_StateProv;
private string POH_Region;
private string POH_Country;
private string POH_ContactName;
private int POH_Contact;
private string POH_ContactPhone;
private int POH_FreightTerms;
private string POH_Carrier;
private string POH_ShipVia;
private string POH_FOB;
private string POH_Printed;
private decimal POH_POValue;
private decimal POH_Freight;
private decimal POH_Duty;
private decimal POH_Brokerage;
private decimal POH_CurrExchange;
private decimal POH_CurrExchangeRate;
private string POH_Currency;
private decimal POH_POValueGoods;
private string POH_CurrencyBase;
private decimal POH_POValueBase;
private string POH_Tax1;
private string POH_Tax2;
private string POH_Tax3;
private decimal POH_Tax1Amt;
private decimal POH_Tax2Amt;
private decimal POH_Tax3Amt;
private string POH_Buyer;
private string POH_UserID;

public
PoHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from pohdr where " + getWhereCondition();

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
	string sql = "select * from pohdr where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.POH_Id = reader.GetInt32("POH_Id");
	this.POH_Db = reader.GetString("POH_Db");
	this.POH_Company = reader.GetInt32("POH_Company");
	this.POH_Plant = reader.GetString("POH_Plant");
	this.POH_PO = reader.GetInt32("POH_PO");
	this.POH_POStatus = reader.GetString("POH_POStatus");
	this.POH_PODate = reader.GetDateTime("POH_PODate");
	this.POH_DtTmCreated = reader.GetDateTime("POH_DtTmCreated");
	this.POH_POSource = reader.GetString("POH_POSource");
	this.POH_POType = reader.GetString("POH_POType");
	this.POH_BPNumber = reader.GetString("POH_BPNumber");
	this.POH_BPName = reader.GetString("POH_BPName");
	this.POH_BPRemitTo = reader.GetString("POH_BPRemitTo");
	this.POH_CustOrdShipAdr = reader.GetString("POH_CustOrdShipAdr");
	this.POH_ShiptoBPNum = reader.GetString("POH_ShiptoBPNum");
	this.POH_ShiptoBPName = reader.GetString("POH_ShiptoBPName");
	this.POH_ShiptoAddress1 = reader.GetString("POH_ShiptoAddress1");
	this.POH_ShiptoAddress2 = reader.GetString("POH_ShiptoAddress2");
	this.POH_ShiptoAddress3 = reader.GetString("POH_ShiptoAddress3");
	this.POH_ShiptoPostZip = reader.GetString("POH_ShiptoPostZip");
	this.POH_City = reader.GetString("POH_City");
	this.POH_StateProv = reader.GetString("POH_StateProv");
	this.POH_Region = reader.GetString("POH_Region");
	this.POH_Country = reader.GetString("POH_Country");
	this.POH_ContactName = reader.GetString("POH_ContactName");
	this.POH_Contact = reader.GetInt32("POH_Contact");
	this.POH_ContactPhone = reader.GetString("POH_ContactPhone");
	this.POH_FreightTerms = reader.GetInt32("POH_FreightTerms");
	this.POH_Carrier = reader.GetString("POH_Carrier");
	this.POH_ShipVia = reader.GetString("POH_ShipVia");
	this.POH_FOB = reader.GetString("POH_FOB");
	this.POH_Printed = reader.GetString("POH_Printed");
	this.POH_POValue = reader.GetDecimal("POH_POValue");
	this.POH_Freight = reader.GetDecimal("POH_Freight");
	this.POH_Duty = reader.GetDecimal("POH_Duty");
	this.POH_Brokerage = reader.GetDecimal("POH_Brokerage");
	this.POH_CurrExchange = reader.GetDecimal("POH_CurrExchange");
	this.POH_CurrExchangeRate = reader.GetDecimal("POH_CurrExchangeRate");
	this.POH_Currency = reader.GetString("POH_Currency");
	this.POH_POValueGoods = reader.GetDecimal("POH_POValueGoods");
	this.POH_CurrencyBase = reader.GetString("POH_CurrencyBase");
	this.POH_POValueBase = reader.GetDecimal("POH_POValueBase");
	this.POH_Tax1 = reader.GetString("POH_Tax1");
	this.POH_Tax2 = reader.GetString("POH_Tax2");
	this.POH_Tax3 = reader.GetString("POH_Tax3");
	this.POH_Tax1Amt = reader.GetDecimal("POH_Tax1Amt");
	this.POH_Tax2Amt = reader.GetDecimal("POH_Tax2Amt");
	this.POH_Tax3Amt = reader.GetDecimal("POH_Tax3Amt");
	this.POH_Buyer = reader.GetString("POH_Buyer");
	this.POH_UserID = reader.GetString("POH_UserID");
}

public override
void write(){
	string sql = "insert into pohdr (" + 
		"POH_Id," +
		"POH_Db," +
		"POH_Company," +
		"POH_Plant," +
		"POH_PO," +
		"POH_POStatus," +
		"POH_PODate," +
		"POH_DtTmCreated," +
		"POH_POSource," +
		"POH_POType," +
		"POH_BPNumber," +
		"POH_BPName," +
		"POH_BPRemitTo," +
		"POH_CustOrdShipAdr," +
		"POH_ShiptoBPNum," +
		"POH_ShiptoBPName," +
		"POH_ShiptoAddress1," +
		"POH_ShiptoAddress2," +
		"POH_ShiptoAddress3," +
		"POH_ShiptoPostZip," +
		"POH_City," +
		"POH_StateProv," +
		"POH_Region," +
		"POH_Country," +
		"POH_ContactName," +
		"POH_Contact," +
		"POH_ContactPhone," +
		"POH_FreightTerms," +
		"POH_Carrier," +
		"POH_ShipVia," +
		"POH_FOB," +
		"POH_Printed," +
		"POH_POValue," +
		"POH_Freight," +
		"POH_Duty," +
		"POH_Brokerage," +
		"POH_CurrExchange," +
		"POH_CurrExchangeRate," +
		"POH_Currency," +
		"POH_POValueGoods," +
		"POH_CurrencyBase," +
		"POH_POValueBase," +
		"POH_Tax1," +
		"POH_Tax2," +
		"POH_Tax3," +
		"POH_Tax1Amt," +
		"POH_Tax2Amt," +
		"POH_Tax3Amt," +
		"POH_Buyer," +
		"POH_UserID" +

		") values (" + 

		"" + NumberUtil.toString(POH_Id) + "," +
		"'" + Converter.fixString(POH_Db) + "'," +
		"" + NumberUtil.toString(POH_Company) + "," +
		"'" + Converter.fixString(POH_Plant) + "'," +
		"" + NumberUtil.toString(POH_PO) + "," +
		"'" + Converter.fixString(POH_POStatus) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(POH_PODate) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(POH_DtTmCreated) + "'," +
		"'" + Converter.fixString(POH_POSource) + "'," +
		"'" + Converter.fixString(POH_POType) + "'," +
		"'" + Converter.fixString(POH_BPNumber) + "'," +
		"'" + Converter.fixString(POH_BPName) + "'," +
		"'" + Converter.fixString(POH_BPRemitTo) + "'," +
		"'" + Converter.fixString(POH_CustOrdShipAdr) + "'," +
		"'" + Converter.fixString(POH_ShiptoBPNum) + "'," +
		"'" + Converter.fixString(POH_ShiptoBPName) + "'," +
		"'" + Converter.fixString(POH_ShiptoAddress1) + "'," +
		"'" + Converter.fixString(POH_ShiptoAddress2) + "'," +
		"'" + Converter.fixString(POH_ShiptoAddress3) + "'," +
		"'" + Converter.fixString(POH_ShiptoPostZip) + "'," +
		"'" + Converter.fixString(POH_City) + "'," +
		"'" + Converter.fixString(POH_StateProv) + "'," +
		"'" + Converter.fixString(POH_Region) + "'," +
		"'" + Converter.fixString(POH_Country) + "'," +
		"'" + Converter.fixString(POH_ContactName) + "'," +
		"" + NumberUtil.toString(POH_Contact) + "," +
		"'" + Converter.fixString(POH_ContactPhone) + "'," +
		"" + NumberUtil.toString(POH_FreightTerms) + "," +
		"'" + Converter.fixString(POH_Carrier) + "'," +
		"'" + Converter.fixString(POH_ShipVia) + "'," +
		"'" + Converter.fixString(POH_FOB) + "'," +
		"'" + Converter.fixString(POH_Printed) + "'," +
		"" + NumberUtil.toString(POH_POValue) + "," +
		"" + NumberUtil.toString(POH_Freight) + "," +
		"" + NumberUtil.toString(POH_Duty) + "," +
		"" + NumberUtil.toString(POH_Brokerage) + "," +
		"" + NumberUtil.toString(POH_CurrExchange) + "," +
		"" + NumberUtil.toString(POH_CurrExchangeRate) + "," +
		"'" + Converter.fixString(POH_Currency) + "'," +
		"" + NumberUtil.toString(POH_POValueGoods) + "," +
		"'" + Converter.fixString(POH_CurrencyBase) + "'," +
		"" + NumberUtil.toString(POH_POValueBase) + "," +
		"'" + Converter.fixString(POH_Tax1) + "'," +
		"'" + Converter.fixString(POH_Tax2) + "'," +
		"'" + Converter.fixString(POH_Tax3) + "'," +
		"" + NumberUtil.toString(POH_Tax1Amt) + "," +
		"" + NumberUtil.toString(POH_Tax2Amt) + "," +
		"" + NumberUtil.toString(POH_Tax3Amt) + "," +
		"'" + Converter.fixString(POH_Buyer) + "'," +
		"'" + Converter.fixString(POH_UserID) + "')";
	write(sql);
}

public override
void update(){
	string sql = "update pohdr set " +
		"POH_Id = " + NumberUtil.toString(POH_Id) + ", " +
		"POH_Db = '" + Converter.fixString(POH_Db) + "', " +
		"POH_Company = " + NumberUtil.toString(POH_Company) + ", " +
		"POH_Plant = '" + Converter.fixString(POH_Plant) + "', " +
		"POH_PO = " + NumberUtil.toString(POH_PO) + ", " +
		"POH_POStatus = '" + Converter.fixString(POH_POStatus) + "', " +
		"POH_PODate = '" + DateUtil.getCompleteDateRepresentation(POH_PODate) + "', " +
		"POH_DtTmCreated = '" + DateUtil.getCompleteDateRepresentation(POH_DtTmCreated) + "', " +
		"POH_POSource = '" + Converter.fixString(POH_POSource) + "', " +
		"POH_POType = '" + Converter.fixString(POH_POType) + "', " +
		"POH_BPNumber = '" + Converter.fixString(POH_BPNumber) + "', " +
		"POH_BPName = '" + Converter.fixString(POH_BPName) + "', " +
		"POH_BPRemitTo = '" + Converter.fixString(POH_BPRemitTo) + "', " +
		"POH_CustOrdShipAdr = '" + Converter.fixString(POH_CustOrdShipAdr) + "', " +
		"POH_ShiptoBPNum = '" + Converter.fixString(POH_ShiptoBPNum) + "', " +
		"POH_ShiptoBPName = '" + Converter.fixString(POH_ShiptoBPName) + "', " +
		"POH_ShiptoAddress1 = '" + Converter.fixString(POH_ShiptoAddress1) + "', " +
		"POH_ShiptoAddress2 = '" + Converter.fixString(POH_ShiptoAddress2) + "', " +
		"POH_ShiptoAddress3 = '" + Converter.fixString(POH_ShiptoAddress3) + "', " +
		"POH_ShiptoPostZip = '" + Converter.fixString(POH_ShiptoPostZip) + "', " +
		"POH_City = '" + Converter.fixString(POH_City) + "', " +
		"POH_StateProv = '" + Converter.fixString(POH_StateProv) + "', " +
		"POH_Region = '" + Converter.fixString(POH_Region) + "', " +
		"POH_Country = '" + Converter.fixString(POH_Country) + "', " +
		"POH_ContactName = '" + Converter.fixString(POH_ContactName) + "', " +
		"POH_Contact = " + NumberUtil.toString(POH_Contact) + ", " +
		"POH_ContactPhone = '" + Converter.fixString(POH_ContactPhone) + "', " +
		"POH_FreightTerms = " + NumberUtil.toString(POH_FreightTerms) + ", " +
		"POH_Carrier = '" + Converter.fixString(POH_Carrier) + "', " +
		"POH_ShipVia = '" + Converter.fixString(POH_ShipVia) + "', " +
		"POH_FOB = '" + Converter.fixString(POH_FOB) + "', " +
		"POH_Printed = '" + Converter.fixString(POH_Printed) + "', " +
		"POH_POValue = " + NumberUtil.toString(POH_POValue) + ", " +
		"POH_Freight = " + NumberUtil.toString(POH_Freight) + ", " +
		"POH_Duty = " + NumberUtil.toString(POH_Duty) + ", " +
		"POH_Brokerage = " + NumberUtil.toString(POH_Brokerage) + ", " +
		"POH_CurrExchange = " + NumberUtil.toString(POH_CurrExchange) + ", " +
		"POH_CurrExchangeRate = " + NumberUtil.toString(POH_CurrExchangeRate) + ", " +
		"POH_Currency = '" + Converter.fixString(POH_Currency) + "', " +
		"POH_POValueGoods = " + NumberUtil.toString(POH_POValueGoods) + ", " +
		"POH_CurrencyBase = '" + Converter.fixString(POH_CurrencyBase) + "', " +
		"POH_POValueBase = " + NumberUtil.toString(POH_POValueBase) + ", " +
		"POH_Tax1 = '" + Converter.fixString(POH_Tax1) + "', " +
		"POH_Tax2 = '" + Converter.fixString(POH_Tax2) + "', " +
		"POH_Tax3 = '" + Converter.fixString(POH_Tax3) + "', " +
		"POH_Tax1Amt = " + NumberUtil.toString(POH_Tax1Amt) + ", " +
		"POH_Tax2Amt = " + NumberUtil.toString(POH_Tax2Amt) + ", " +
		"POH_Tax3Amt = " + NumberUtil.toString(POH_Tax3Amt) + ", " +
		"POH_Buyer = '" + Converter.fixString(POH_Buyer) + "', " +
		"POH_UserID = '" + Converter.fixString(POH_UserID) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from pohdr where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"POH_Id = " + NumberUtil.toString(POH_Id) + "";
	return sqlWhere;
}

public
void setPOH_Id(int POH_Id){
	this.POH_Id = POH_Id;
}

public
void setPOH_Db(string POH_Db){
	this.POH_Db = POH_Db;
}

public
void setPOH_Company(int POH_Company){
	this.POH_Company = POH_Company;
}

public
void setPOH_Plant(string POH_Plant){
	this.POH_Plant = POH_Plant;
}

public
void setPOH_PO(int POH_PO){
	this.POH_PO = POH_PO;
}

public
void setPOH_POStatus(string POH_POStatus){
	this.POH_POStatus = POH_POStatus;
}

public
void setPOH_PODate(DateTime POH_PODate){
	this.POH_PODate = POH_PODate;
}

public
void setPOH_DtTmCreated(DateTime POH_DtTmCreated){
	this.POH_DtTmCreated = POH_DtTmCreated;
}

public
void setPOH_POSource(string POH_POSource){
	this.POH_POSource = POH_POSource;
}

public
void setPOH_POType(string POH_POType){
	this.POH_POType = POH_POType;
}

public
void setPOH_BPNumber(string POH_BPNumber){
	this.POH_BPNumber = POH_BPNumber;
}

public
void setPOH_BPName(string POH_BPName){
	this.POH_BPName = POH_BPName;
}

public
void setPOH_BPRemitTo(string POH_BPRemitTo){
	this.POH_BPRemitTo = POH_BPRemitTo;
}

public
void setPOH_CustOrdShipAdr(string POH_CustOrdShipAdr){
	this.POH_CustOrdShipAdr = POH_CustOrdShipAdr;
}

public
void setPOH_ShiptoBPNum(string POH_ShiptoBPNum){
	this.POH_ShiptoBPNum = POH_ShiptoBPNum;
}

public
void setPOH_ShiptoBPName(string POH_ShiptoBPName){
	this.POH_ShiptoBPName = POH_ShiptoBPName;
}

public
void setPOH_ShiptoAddress1(string POH_ShiptoAddress1){
	this.POH_ShiptoAddress1 = POH_ShiptoAddress1;
}

public
void setPOH_ShiptoAddress2(string POH_ShiptoAddress2){
	this.POH_ShiptoAddress2 = POH_ShiptoAddress2;
}

public
void setPOH_ShiptoAddress3(string POH_ShiptoAddress3){
	this.POH_ShiptoAddress3 = POH_ShiptoAddress3;
}

public
void setPOH_ShiptoPostZip(string POH_ShiptoPostZip){
	this.POH_ShiptoPostZip = POH_ShiptoPostZip;
}

public
void setPOH_City(string POH_City){
	this.POH_City = POH_City;
}

public
void setPOH_StateProv(string POH_StateProv){
	this.POH_StateProv = POH_StateProv;
}

public
void setPOH_Region(string POH_Region){
	this.POH_Region = POH_Region;
}

public
void setPOH_Country(string POH_Country){
	this.POH_Country = POH_Country;
}

public
void setPOH_ContactName(string POH_ContactName){
	this.POH_ContactName = POH_ContactName;
}

public
void setPOH_Contact(int POH_Contact){
	this.POH_Contact = POH_Contact;
}

public
void setPOH_ContactPhone(string POH_ContactPhone){
	this.POH_ContactPhone = POH_ContactPhone;
}

public
void setPOH_FreightTerms(int POH_FreightTerms){
	this.POH_FreightTerms = POH_FreightTerms;
}

public
void setPOH_Carrier(string POH_Carrier){
	this.POH_Carrier = POH_Carrier;
}

public
void setPOH_ShipVia(string POH_ShipVia){
	this.POH_ShipVia = POH_ShipVia;
}

public
void setPOH_FOB(string POH_FOB){
	this.POH_FOB = POH_FOB;
}

public
void setPOH_Printed(string POH_Printed){
	this.POH_Printed = POH_Printed;
}

public
void setPOH_POValue(decimal POH_POValue){
	this.POH_POValue = POH_POValue;
}

public
void setPOH_Freight(decimal POH_Freight){
	this.POH_Freight = POH_Freight;
}

public
void setPOH_Duty(decimal POH_Duty){
	this.POH_Duty = POH_Duty;
}

public
void setPOH_Brokerage(decimal POH_Brokerage){
	this.POH_Brokerage = POH_Brokerage;
}

public
void setPOH_CurrExchange(decimal POH_CurrExchange){
	this.POH_CurrExchange = POH_CurrExchange;
}

public
void setPOH_CurrExchangeRate(decimal POH_CurrExchangeRate){
	this.POH_CurrExchangeRate = POH_CurrExchangeRate;
}

public
void setPOH_Currency(string POH_Currency){
	this.POH_Currency = POH_Currency;
}

public
void setPOH_POValueGoods(decimal POH_POValueGoods){
	this.POH_POValueGoods = POH_POValueGoods;
}

public
void setPOH_CurrencyBase(string POH_CurrencyBase){
	this.POH_CurrencyBase = POH_CurrencyBase;
}

public
void setPOH_POValueBase(decimal POH_POValueBase){
	this.POH_POValueBase = POH_POValueBase;
}

public
void setPOH_Tax1(string POH_Tax1){
	this.POH_Tax1 = POH_Tax1;
}

public
void setPOH_Tax2(string POH_Tax2){
	this.POH_Tax2 = POH_Tax2;
}

public
void setPOH_Tax3(string POH_Tax3){
	this.POH_Tax3 = POH_Tax3;
}

public
void setPOH_Tax1Amt(decimal POH_Tax1Amt){
	this.POH_Tax1Amt = POH_Tax1Amt;
}

public
void setPOH_Tax2Amt(decimal POH_Tax2Amt){
	this.POH_Tax2Amt = POH_Tax2Amt;
}

public
void setPOH_Tax3Amt(decimal POH_Tax3Amt){
	this.POH_Tax3Amt = POH_Tax3Amt;
}

public
void setPOH_Buyer(string POH_Buyer){
	this.POH_Buyer = POH_Buyer;
}

public
void setPOH_UserID(string POH_UserID){
	this.POH_UserID = POH_UserID;
}

public
int getPOH_Id(){
	return POH_Id;
}

public
string getPOH_Db(){
	return POH_Db;
}

public
int getPOH_Company(){
	return POH_Company;
}

public
string getPOH_Plant(){
	return POH_Plant;
}

public
int getPOH_PO(){
	return POH_PO;
}

public
string getPOH_POStatus(){
	return POH_POStatus;
}

public
DateTime getPOH_PODate(){
	return POH_PODate;
}

public
DateTime getPOH_DtTmCreated(){
	return POH_DtTmCreated;
}

public
string getPOH_POSource(){
	return POH_POSource;
}

public
string getPOH_POType(){
	return POH_POType;
}

public
string getPOH_BPNumber(){
	return POH_BPNumber;
}

public
string getPOH_BPName(){
	return POH_BPName;
}

public
string getPOH_BPRemitTo(){
	return POH_BPRemitTo;
}

public
string getPOH_CustOrdShipAdr(){
	return POH_CustOrdShipAdr;
}

public
string getPOH_ShiptoBPNum(){
	return POH_ShiptoBPNum;
}

public
string getPOH_ShiptoBPName(){
	return POH_ShiptoBPName;
}

public
string getPOH_ShiptoAddress1(){
	return POH_ShiptoAddress1;
}

public
string getPOH_ShiptoAddress2(){
	return POH_ShiptoAddress2;
}

public
string getPOH_ShiptoAddress3(){
	return POH_ShiptoAddress3;
}

public
string getPOH_ShiptoPostZip(){
	return POH_ShiptoPostZip;
}

public
string getPOH_City(){
	return POH_City;
}

public
string getPOH_StateProv(){
	return POH_StateProv;
}

public
string getPOH_Region(){
	return POH_Region;
}

public
string getPOH_Country(){
	return POH_Country;
}

public
string getPOH_ContactName(){
	return POH_ContactName;
}

public
int getPOH_Contact(){
	return POH_Contact;
}

public
string getPOH_ContactPhone(){
	return POH_ContactPhone;
}

public
int getPOH_FreightTerms(){
	return POH_FreightTerms;
}

public
string getPOH_Carrier(){
	return POH_Carrier;
}

public
string getPOH_ShipVia(){
	return POH_ShipVia;
}

public
string getPOH_FOB(){
	return POH_FOB;
}

public
string getPOH_Printed(){
	return POH_Printed;
}

public
decimal getPOH_POValue(){
	return POH_POValue;
}

public
decimal getPOH_Freight(){
	return POH_Freight;
}

public
decimal getPOH_Duty(){
	return POH_Duty;
}

public
decimal getPOH_Brokerage(){
	return POH_Brokerage;
}

public
decimal getPOH_CurrExchange(){
	return POH_CurrExchange;
}

public
decimal getPOH_CurrExchangeRate(){
	return POH_CurrExchangeRate;
}

public
string getPOH_Currency(){
	return POH_Currency;
}

public
decimal getPOH_POValueGoods(){
	return POH_POValueGoods;
}

public
string getPOH_CurrencyBase(){
	return POH_CurrencyBase;
}

public
decimal getPOH_POValueBase(){
	return POH_POValueBase;
}

public
string getPOH_Tax1(){
	return POH_Tax1;
}

public
string getPOH_Tax2(){
	return POH_Tax2;
}

public
string getPOH_Tax3(){
	return POH_Tax3;
}

public
decimal getPOH_Tax1Amt(){
	return POH_Tax1Amt;
}

public
decimal getPOH_Tax2Amt(){
	return POH_Tax2Amt;
}

public
decimal getPOH_Tax3Amt(){
	return POH_Tax3Amt;
}

public
string getPOH_Buyer(){
	return POH_Buyer;
}

public
string getPOH_UserID(){
	return POH_UserID;
}

} // class

} // package