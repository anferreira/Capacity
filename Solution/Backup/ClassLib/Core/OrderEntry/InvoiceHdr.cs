using System;
using System.Collections;
using System.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{

[Serializable]	
public class InvoiceHdr : MarshalByRefObject{

private string db;
private int company;
private string plant;
private int invoiceNum;
private decimal orderNum;
private string posted;
private DateTime invDate;
private DateTime shipDate;
private string invType;
private string invCredit;
private string billToCust;
private string shiptoCust;
private string billToName;
private string shipToName;
private decimal invoiceTotal;
private decimal tax1Total;
private decimal tax2Total;
private decimal tax3Total;
private decimal discountTot;
private decimal taxTotal;
private decimal costTotal;
private string terms;
private string payType;
private string poNum;
private string quoteNum;
private string currency;
private string salesPer;
private int bolNumber;
private string packSlipNum;
private string stockLoc;
private string warehouse;
private string shipToAdr1;
private string shipToAdr2;
private string shipToAdr3;
private string shipVia;
private string freightTerms;
private string fobPoint;
private string printed;
private string emailed;
private string faxed;
private decimal emailList;
private int arYear;
private int arPeriod;
private string postedToERP;
private int batchNumber;
private string chargesCalculated;
private DateTime poDate;
private DateTime orderDate;
private string recordCheck;
private DateTime dateCreated;
private DateTime dateUpdated;
private int userID;
private string baseCurrency;
private decimal exchangeRate;
private decimal depositAmt;
private decimal amtOwed;
private string authorization;
private string creditCardType;
private string creditCardNumber;
private int expiryDate;
private string dealer;
private string dealerSalesRep;
private decimal paid;
private decimal balance;
private string paymentsMethod;
private decimal returned;
private decimal refunded;
private decimal balanceReturn;


internal InvoiceHdr(){

    db = "";
    company = 0;
    plant = "";
    invoiceNum = 0;
    orderNum = 0;
    posted = "";
    invDate = System.DateTime.MinValue;
    shipDate = System.DateTime.MinValue;
    invType = "";
    invCredit = "";
    billToCust = "";
    shiptoCust = "";
    billToName = "";
    shipToName = "";
    invoiceTotal = 0;
    tax1Total = 0;
    tax2Total = 0;
    tax3Total = 0;
    discountTot = 0;
    taxTotal = 0;
    costTotal = 0;
    terms = "";
    payType = "";
    poNum = "";
    quoteNum = "";
    currency = "";
    salesPer = "";
    bolNumber = 0;
    packSlipNum = "";
    stockLoc = "";
    warehouse = "";
    shipToAdr1 = "";
    shipToAdr2 = "";
    shipToAdr3 = "";
    shipVia = "";
    freightTerms = "";
    fobPoint = "";
    printed = "";
    emailed = "";
    faxed = "";
    emailList = 0;
    arYear = 0;
    arPeriod = 0;
    postedToERP = "";
    batchNumber = 0;
    chargesCalculated = "";
    poDate = System.DateTime.MinValue;
    orderDate = System.DateTime.MinValue;
    recordCheck = "";
    dateCreated = System.DateTime.MinValue;
    dateUpdated = System.DateTime.MinValue;
    userID = 0;
    baseCurrency = "";
    exchangeRate = 0;
    depositAmt = 0;
    amtOwed = 0;
    authorization = "";
    creditCardType = "";
    creditCardNumber = "";
    expiryDate = 0;
    dealer = "";
    dealerSalesRep = "";
    paid = 0;
    balance = 0;
    paymentsMethod = "";
    returned = 0;
    refunded = 0;
    balanceReturn = 0;
    	
}


//Setters
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
void setInvoiceNum(int invoiceNum){
   this.invoiceNum = invoiceNum;
}

public 
void setOrderNum(decimal orderNum){
   this.orderNum = orderNum;
}

public 
void setPosted(string posted){
   this.posted = posted;
}

public 
void setInvDate(DateTime invDate){
   this.invDate = invDate;
}

public 
void setShipDate(DateTime shipDate){
   this.shipDate = shipDate;
}

public 
void setInvType(string invType){
   this.invType = invType;
}

public 
void setInvCredit(string invCredit){
   this.invCredit = invCredit;
}

public 
void setBillToCust(string billToCust){
   this.billToCust = billToCust;
}

public 
void setShiptoCust(string shiptoCust){
   this.shiptoCust = shiptoCust;
}

public 
void setBillToName(string billToName){
   this.billToName = billToName;
}

public 
void setShipToName(string shipToName){
   this.shipToName = shipToName;
}

public 
void setInvoiceTotal(decimal invoiceTotal){
   this.invoiceTotal = invoiceTotal;
}

public 
void setTax1Total(decimal tax1Total){
   this.tax1Total = tax1Total;
}

public 
void setTax2Total(decimal tax2Total){
   this.tax2Total = tax2Total;
}

public 
void setTax3Total(decimal tax3Total){
   this.tax3Total = tax3Total;
}

public 
void setDiscountTot(decimal discountTot){
   this.discountTot = discountTot;
}

public 
void setTaxTotal(decimal taxTotal){
   this.taxTotal = taxTotal;
}

public 
void setCostTotal(decimal costTotal){
   this.costTotal = costTotal;
}

public 
void setTerms(string terms){
   this.terms = terms;
}

public 
void setPayType(string payType){
   this.payType = payType;
}

public 
void setPONum(string pNum){
   this.poNum = poNum;
}

public 
void setQuoteNum(string quoteNum){
   this.quoteNum = quoteNum;
}

public 
void setCurrency(string currency){
   this.currency = currency;
}

public 
void setSalesPer(string salesPer){
   this.salesPer = salesPer;
}

public 
void setBolNumber(int bolNumber){
   this.bolNumber = bolNumber;
}

public 
void setPackSlipNum(string packSlipNum){
   this.packSlipNum = packSlipNum;
}

public 
void setStockLoc(string stockLoc){
   this.stockLoc = stockLoc;
}

public 
void setWarehouse(string warehouse){
   this.warehouse = warehouse;
}

public 
void setShipToAdr1(string shipToAdr1){
   this.shipToAdr1 = shipToAdr1;
}

public 
void setShipToAdr2(string shipToAdr2){
   this.shipToAdr2 = shipToAdr2;
}

public 
void setShipToAdr3(string shipToAdr3){
   this.shipToAdr3 = shipToAdr3;
}

public 
void setShipVia(string shipVia){
   this.shipVia = shipVia;
}

public 
void setFreightTerms(string freightTerms){
   this.freightTerms = freightTerms;
}

public 
void setFobPoint(string fobPoint){
   this.fobPoint = fobPoint;
}

public 
void setPrinted(string printed){
   this.printed = printed;
}

public 
void setEmailed(string emailed){
   this.emailed = emailed;
}

public 
void setFaxed(string faxed){
   this.faxed = faxed;
}

public 
void setEmailList(decimal EmailList){
   this.emailList = EmailList;
}

public 
void setArYear(int arYear){
   this.arYear = arYear;
}

public 
void setARPeriod(int arPeriod){
   this.arPeriod = arPeriod;
}

public 
void setPostedToERP (string postedToERP){
    this.postedToERP = postedToERP;
}

public 
void setBatchNumber(int batchNumber){
   this.batchNumber= batchNumber;
}

public 
void setChargesCalculated(string chargesCalculated){
    this.chargesCalculated = chargesCalculated;
}

public 
void setPoDate (DateTime PoDate){
    this.poDate = poDate;
}

public 
void setOrderDate (DateTime orderDate){
    this.orderDate = orderDate;
}

public 
void setRecordCheck (string recordCheck){
    this.recordCheck = recordCheck;
}


public void setDateCreated (DateTime dateCreated){
    this.dateCreated = dateCreated;
}

public void setDateUpdated (DateTime dateUpdated){
    this.dateUpdated = dateUpdated;
}

public void setUserID (int userID){
    this.userID = userID;
}

public void setBaseCurrency (string baseCurrency){
    this.baseCurrency = baseCurrency;
}

public void setExchangeRate (decimal exchangeRate){
    this.exchangeRate = exchangeRate;
}

public void setDepositAmt (decimal depositAmt){
    this.depositAmt = depositAmt;
}

public void setAmtOwed (decimal amtOwed){
    this.amtOwed = amtOwed;
}

public void setAuthorization (string authorization){
    this.authorization = authorization;
}

public void setCreditCardType (string creditCardType){
    this.creditCardType = creditCardType;
}

public void setCreditCardNumber (string creditCardNumber){
    this.creditCardNumber = creditCardNumber;
}

public void setExpiryDate (int expiryDate){
    this.expiryDate = expiryDate;
}

public void setDealer (string dealer){
    this.dealer = dealer;
}

public void setDealerSalesRep (string dealerSalesRep){
    this.dealerSalesRep = dealerSalesRep;
}

public void setPaid (decimal paid){
    this.paid = paid;
}

public void setBalance (decimal balance){
    this.balance = balance;
}

public void setPaymentsMethod (string paymentsMethod){
    this.paymentsMethod = paymentsMethod;
}

public void setReturned (decimal returned){
    this.returned = returned;
}

public void setRefunded (decimal refunded){
    this.refunded = refunded;
}

public void setBalanceReturn (decimal balanceReturn){
    this.balanceReturn = balanceReturn;
}


//Getters
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
int getInvoiceNum(){
   return invoiceNum;
}

public
decimal getOrderNum(){
   return orderNum;
}

public
string getPosted(){
   return posted;
}

public
DateTime getInvDate(){
   return invDate;
}

public
DateTime getShipDate(){
   return shipDate;
}

public
string getInvType(){
   return invType;
}

public
string getInvCredit(){
   return invCredit;
}

public
string getBillToCust(){
   return billToCust;
}

public
string getShiptoCust(){
   return shiptoCust;
}

public
string getBillToName(){
   return billToName;
}

public
string getShipToName(){
   return shipToName;
}

public
decimal getInvoiceTotal(){
   return invoiceTotal;
}

public
decimal getTax1Total(){
   return tax1Total;
}

public
decimal getTax2Total(){
   return tax2Total;
}

public
decimal getTax3Total(){
   return tax3Total;
}

public
decimal getDiscountTot(){
   return discountTot;
}

public
decimal getTaxTotal(){
   return taxTotal;
}

public
decimal getCostTotal(){
   return costTotal;
}

public
string getTerms(){
   return terms;
}

public
string getPayType(){
   return payType;
}

public
string getPoNum(){
   return poNum;
}

public
string getQuoteNum(){
   return quoteNum;
}

public
string getCurrency(){
   return currency;
}

public
string getSalesPer(){
   return salesPer;
}

public
int getBolNumber(){
   return bolNumber;
}

public
string getPackSlipNum(){
   return packSlipNum;
}

public
string getStockLoc(){
   return stockLoc;
}

public
string getWarehouse(){
   return warehouse;
}

public
string getShipToAdr1(){
   return shipToAdr1;
}

public
string getShipToAdr2(){
   return shipToAdr2;
}

public
string getShipToAdr3(){
   return shipToAdr3;
}

public
string getShipVia(){
   return shipVia;
}

public
string getFreightTerms(){
   return freightTerms;
}

public
string getFobPoint(){
   return fobPoint;
}

public
string getPrinted(){
   return printed;
}

public
string getEmailed(){
   return emailed;
}

public
string getFaxed(){
   return faxed;
}

public
decimal getEmailList(){
   return emailList;
}

public
int getArYear(){
   return arYear;
}

public
int getArPeriod(){
   return arPeriod;
}

public 
string getPostedToERP(){
    return postedToERP;
}

public 
int getBatchNumber(){
    return batchNumber;
}


public string getChargesCalculated(){
    return chargesCalculated;
}

public string getRecordCheck(){
    return recordCheck;
}


public DateTime getPoDate(){
    return poDate;
}

public DateTime getOrderDate(){
    return orderDate;
}

public DateTime getDateCreated(){
    return dateCreated;
}

public DateTime getDateUpdated(){
    return dateUpdated;
}

public int getUserID(){
    return userID;
}

public string getBaseCurrency(){
    return baseCurrency;
}

public decimal getExchangeRate(){
    return exchangeRate;
}

public decimal getDepositAmt(){
    return depositAmt;
}

public decimal getAmtOwed(){
    return amtOwed;
}

public string getAuthorization(){
    return authorization;
}

public string getCreditCardType(){
    return creditCardType;
}

public string getCreditCardNumber(){
    return creditCardNumber;
}

public int getExpiryDate(){
    return expiryDate;
}

public string getDealer(){
    return dealer;
}

public string getDealerSalesRep(){
    return dealerSalesRep;
}

public decimal getPaid(){
    return paid;
}

public decimal getBalance(){
    return balance;
}

public string getPaymentsMethod(){
    return paymentsMethod;
}

public decimal getReturned(){
    return returned;
}

public decimal getRefunded(){
    return refunded;
}

public decimal getBalanceReturn(){
    return balanceReturn;
}



}//end class
}//end namespace
