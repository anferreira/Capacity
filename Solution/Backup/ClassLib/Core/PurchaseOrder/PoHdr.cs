/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: gmuller $ 
*   $Date: 2005-05-17 04:34:50 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/Core/PurchaseOrder/PoHdr.cs,v $ 
*   $State: Exp $ 
*   $Log: PoHdr.cs,v $
*   Revision 1.2  2005-05-17 04:34:50  gmuller
*   ponga aqui un comentario
*
*   Revision 1.1  2005/04/14 03:02:20  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////


using System;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]
public class PoHdr : MarshalByRefObject
{

private int id;
private string db;
private int company;
private string plant;
private int pO;
private string pOStatus;
private DateTime pODate;
private DateTime dtTmCreated;
private string pOSource;
private string pOType;
private string bPNumber;
private string bPName;
private string bPRemitTo;
private string custOrdShipAdr;
private string shiptoBPNum;
private string shiptoBPName;
private string shiptoAddress1;
private string shiptoAddress2;
private string shiptoAddress3;
private string shiptoPostZip;
private string city;
private string stateProv;
private string region;
private string country;
private string contactName;
private int contact;
private string contactPhone;
private int freightTerms;
private string carrier;
private string shipVia;
private string fOB;
private string printed;
private decimal pOValue;
private decimal freight;
private decimal duty;
private decimal brokerage;
private decimal currExchange;
private decimal currExchangeRate;
private string currency;
private decimal pOValueGoods;
private string currencyBase;
private decimal pOValueBase;
private string tax1;
private string tax2;
private string tax3;
private decimal tax1Amt;
private decimal tax2Amt;
private decimal tax3Amt;
private string buyer;
private string userID;

public
PoHdr(){
	this.id = 0;
	this.db = "";
	this.company = 0;
	this.plant = "";
	this.pO = 0;
	this.pOStatus = "";
	this.pODate = DateUtil.MinValue;
	this.dtTmCreated = DateUtil.MinValue;
	this.pOSource = "";
	this.pOType = "";
	this.bPNumber = "";
	this.bPName = "";
	this.bPRemitTo = "";
	this.custOrdShipAdr = "";
	this.shiptoBPNum = "";
	this.shiptoBPName = "";
	this.shiptoAddress1 = "";
	this.shiptoAddress2 = "";
	this.shiptoAddress3 = "";
	this.shiptoPostZip = "";
	this.city = "";
	this.stateProv = "";
	this.region = "";
	this.country = "";
	this.contactName = "";
	this.contact = 0;
	this.contactPhone = "";
	this.freightTerms = 0;
	this.carrier = "";
	this.shipVia = "";
	this.fOB = "";
	this.printed = "";
	this.pOValue = 0;
	this.freight = 0;
	this.duty = 0;
	this.brokerage = 0;
	this.currExchange = 0;
	this.currExchangeRate = 0;
	this.currency = "";
	this.pOValueGoods = 0;
	this.currencyBase = "";
	this.pOValueBase = 0;
	this.tax1 = "";
	this.tax2 = "";
	this.tax3 = "";
	this.tax1Amt = 0;
	this.tax2Amt = 0;
	this.tax3Amt = 0;
	this.buyer = "";
	this.userID = "";
}

public
PoHdr(
				int id,
				string db,
				int company,
				string plant,
				int pO,
				string pOStatus,
				DateTime pODate,
				DateTime dtTmCreated,
				string pOSource,
				string pOType,
				string bPNumber,
				string bPName,
				string bPRemitTo,
				string custOrdShipAdr,
				string shiptoBPNum,
				string shiptoBPName,
				string shiptoAddress1,
				string shiptoAddress2,
				string shiptoAddress3,
				string shiptoPostZip,
				string city,
				string stateProv,
				string region,
				string country,
				string contactName,
				int contact,
				string contactPhone,
				int freightTerms,
				string carrier,
				string shipVia,
				string fOB,
				string printed,
				decimal pOValue,
				decimal freight,
				decimal duty,
				decimal brokerage,
				decimal currExchange,
				decimal currExchangeRate,
				string currency,
				decimal pOValueGoods,
				string currencyBase,
				decimal pOValueBase,
				string tax1,
				string tax2,
				string tax3,
				decimal tax1Amt,
				decimal tax2Amt,
				decimal tax3Amt,
				string buyer,
				string userID)
{
	this.id = id;
	this.db = db;
	this.company = company;
	this.plant = plant;
	this.pO = pO;
	this.pOStatus = pOStatus;
	this.pODate = pODate;
	this.dtTmCreated = dtTmCreated;
	this.pOSource = pOSource;
	this.pOType = pOType;
	this.bPNumber = bPNumber;
	this.bPName = bPName;
	this.bPRemitTo = bPRemitTo;
	this.custOrdShipAdr = custOrdShipAdr;
	this.shiptoBPNum = shiptoBPNum;
	this.shiptoBPName = shiptoBPName;
	this.shiptoAddress1 = shiptoAddress1;
	this.shiptoAddress2 = shiptoAddress2;
	this.shiptoAddress3 = shiptoAddress3;
	this.shiptoPostZip = shiptoPostZip;
	this.city = city;
	this.stateProv = stateProv;
	this.region = region;
	this.country = country;
	this.contactName = contactName;
	this.contact = contact;
	this.contactPhone = contactPhone;
	this.freightTerms = freightTerms;
	this.carrier = carrier;
	this.shipVia = shipVia;
	this.fOB = fOB;
	this.printed = printed;
	this.pOValue = pOValue;
	this.freight = freight;
	this.duty = duty;
	this.brokerage = brokerage;
	this.currExchange = currExchange;
	this.currExchangeRate = currExchangeRate;
	this.currency = currency;
	this.pOValueGoods = pOValueGoods;
	this.currencyBase = currencyBase;
	this.pOValueBase = pOValueBase;
	this.tax1 = tax1;
	this.tax2 = tax2;
	this.tax3 = tax3;
	this.tax1Amt = tax1Amt;
	this.tax2Amt = tax2Amt;
	this.tax3Amt = tax3Amt;
	this.buyer = buyer;
	this.userID = userID;
}

public
void setId(int id){
	this.id = id;
}

public
void setDb(string db){
	this.db = db;
}

public
void setCompany(int company){
	this.company = company;
}

public
void setPlant(string plant){
	this.plant = plant;
}

public
void setPO(int pO){
	this.pO = pO;
}

public
void setPOStatus(string pOStatus){
	this.pOStatus = pOStatus;
}

public
void setPODate(DateTime pODate){
	this.pODate = pODate;
}

public
void setDtTmCreated(DateTime dtTmCreated){
	this.dtTmCreated = dtTmCreated;
}

public
void setPOSource(string pOSource){
	this.pOSource = pOSource;
}

public
void setPOType(string pOType){
	this.pOType = pOType;
}

public
void setBPNumber(string bPNumber){
	this.bPNumber = bPNumber;
}

public
void setBPName(string bPName){
	this.bPName = bPName;
}

public
void setBPRemitTo(string bPRemitTo){
	this.bPRemitTo = bPRemitTo;
}

public
void setCustOrdShipAdr(string custOrdShipAdr){
	this.custOrdShipAdr = custOrdShipAdr;
}

public
void setShiptoBPNum(string shiptoBPNum){
	this.shiptoBPNum = shiptoBPNum;
}

public
void setShiptoBPName(string shiptoBPName){
	this.shiptoBPName = shiptoBPName;
}

public
void setShiptoAddress1(string shiptoAddress1){
	this.shiptoAddress1 = shiptoAddress1;
}

public
void setShiptoAddress2(string shiptoAddress2){
	this.shiptoAddress2 = shiptoAddress2;
}

public
void setShiptoAddress3(string shiptoAddress3){
	this.shiptoAddress3 = shiptoAddress3;
}

public
void setShiptoPostZip(string shiptoPostZip){
	this.shiptoPostZip = shiptoPostZip;
}

public
void setCity(string city){
	this.city = city;
}

public
void setStateProv(string stateProv){
	this.stateProv = stateProv;
}

public
void setRegion(string region){
	this.region = region;
}

public
void setCountry(string country){
	this.country = country;
}

public
void setContactName(string contactName){
	this.contactName = contactName;
}

public
void setContact(int contact){
	this.contact = contact;
}

public
void setContactPhone(string contactPhone){
	this.contactPhone = contactPhone;
}

public
void setFreightTerms(int freightTerms){
	this.freightTerms = freightTerms;
}

public
void setCarrier(string carrier){
	this.carrier = carrier;
}

public
void setShipVia(string shipVia){
	this.shipVia = shipVia;
}

public
void setFOB(string fOB){
	this.fOB = fOB;
}

public
void setPrinted(string printed){
	this.printed = printed;
}

public
void setPOValue(decimal pOValue){
	this.pOValue = pOValue;
}

public
void setFreight(decimal freight){
	this.freight = freight;
}

public
void setDuty(decimal duty){
	this.duty = duty;
}

public
void setBrokerage(decimal brokerage){
	this.brokerage = brokerage;
}

public
void setCurrExchange(decimal currExchange){
	this.currExchange = currExchange;
}

public
void setCurrExchangeRate(decimal currExchangeRate){
	this.currExchangeRate = currExchangeRate;
}

public
void setCurrency(string currency){
	this.currency = currency;
}

public
void setPOValueGoods(decimal pOValueGoods){
	this.pOValueGoods = pOValueGoods;
}

public
void setCurrencyBase(string currencyBase){
	this.currencyBase = currencyBase;
}

public
void setPOValueBase(decimal pOValueBase){
	this.pOValueBase = pOValueBase;
}

public
void setTax1(string tax1){
	this.tax1 = tax1;
}

public
void setTax2(string tax2){
	this.tax2 = tax2;
}

public
void setTax3(string tax3){
	this.tax3 = tax3;
}

public
void setTax1Amt(decimal tax1Amt){
	this.tax1Amt = tax1Amt;
}

public
void setTax2Amt(decimal tax2Amt){
	this.tax2Amt = tax2Amt;
}

public
void setTax3Amt(decimal tax3Amt){
	this.tax3Amt = tax3Amt;
}

public
void setBuyer(string buyer){
	this.buyer = buyer;
}

public
void setUserID(string userID){
	this.userID = userID;
}

public
int getId(){
	 return id;
}

public
string getDb(){
	 return db;
}

public
int getCompany(){
	 return company;
}

public
string getPlant(){
	 return plant;
}

public
int getPO(){
	 return pO;
}

public
string getPOStatus(){
	 return pOStatus;
}

public
DateTime getPODate(){
	 return pODate;
}

public
DateTime getDtTmCreated(){
	 return dtTmCreated;
}

public
string getPOSource(){
	 return pOSource;
}

public
string getPOType(){
	 return pOType;
}

public
string getBPNumber(){
	 return bPNumber;
}

public
string getBPName(){
	 return bPName;
}

public
string getBPRemitTo(){
	 return bPRemitTo;
}

public
string getCustOrdShipAdr(){
	 return custOrdShipAdr;
}

public
string getShiptoBPNum(){
	 return shiptoBPNum;
}

public
string getShiptoBPName(){
	 return shiptoBPName;
}

public
string getShiptoAddress1(){
	 return shiptoAddress1;
}

public
string getShiptoAddress2(){
	 return shiptoAddress2;
}

public
string getShiptoAddress3(){
	 return shiptoAddress3;
}

public
string getShiptoPostZip(){
	 return shiptoPostZip;
}

public
string getCity(){
	 return city;
}

public
string getStateProv(){
	 return stateProv;
}

public
string getRegion(){
	 return region;
}

public
string getCountry(){
	 return country;
}

public
string getContactName(){
	 return contactName;
}

public
int getContact(){
	 return contact;
}

public
string getContactPhone(){
	 return contactPhone;
}

public
int getFreightTerms(){
	 return freightTerms;
}

public
string getCarrier(){
	 return carrier;
}

public
string getShipVia(){
	 return shipVia;
}

public
string getFOB(){
	 return fOB;
}

public
string getPrinted(){
	 return printed;
}

public
decimal getPOValue(){
	 return pOValue;
}

public
decimal getFreight(){
	 return freight;
}

public
decimal getDuty(){
	 return duty;
}

public
decimal getBrokerage(){
	 return brokerage;
}

public
decimal getCurrExchange(){
	 return currExchange;
}

public
decimal getCurrExchangeRate(){
	 return currExchangeRate;
}

public
string getCurrency(){
	 return currency;
}

public
decimal getPOValueGoods(){
	 return pOValueGoods;
}

public
string getCurrencyBase(){
	 return currencyBase;
}

public
decimal getPOValueBase(){
	 return pOValueBase;
}

public
string getTax1(){
	 return tax1;
}

public
string getTax2(){
	 return tax2;
}

public
string getTax3(){
	 return tax3;
}

public
decimal getTax1Amt(){
	 return tax1Amt;
}

public
decimal getTax2Amt(){
	 return tax2Amt;
}

public
decimal getTax3Amt(){
	 return tax3Amt;
}

public
string getBuyer(){
	 return buyer;
}

public
string getUserID(){
	 return userID;
}

} // class

} // package