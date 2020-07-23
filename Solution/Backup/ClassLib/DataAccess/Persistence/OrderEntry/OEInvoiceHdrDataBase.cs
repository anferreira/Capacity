using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public 
class OEInvoiceHdrDataBase : GenericDataBaseElement{

private string IH_Db;
private int IH_Company;
private string IH_Plant;
private int IH_InvoiceNum;
private decimal IH_OrderNum;
private string IH_Posted;
private DateTime IH_InvDate;
private DateTime IH_ShipDate;
private string IH_InvType;
private string IH_InvCredit;
private string IH_BillToCust;
private string IH_ShiptoCust;
private string IH_BillToName;
private string IH_ShipToName;
private decimal IH_InvoiceTotal;
private decimal IH_Tax1Total;
private decimal IH_Tax2Total;
private decimal IH_Tax3Total;
private decimal IH_DiscountTot;
private decimal IH_TaxTotal;
private decimal IH_CostTotal;
private string IH_Terms;
private string IH_PayType;
private string IH_PONum;
private string IH_QuoteNum;
private string IH_Currency;
private string IH_SalesPer;
private int IH_BOLNumber;
private string IH_PackSlipNum;
private string IH_StockLoc;
private string IH_Warehouse;
private string IH_ShipToAdr1;
private string IH_ShipToAdr2;
private string IH_ShipToAdr3;
private string IH_ShipVia;
private string IH_FreightTerms;
private string IH_FOBPoint;
private string IH_Printed;
private string IH_Emailed;
private string IH_Faxed;
private decimal IH_EmailList;
private int IH_ARYear;
private int IH_ARPeriod;
private string IH_PostedToERP;
private int IH_BatchNumber;
private string IH_ChargesCalculated;
private DateTime IH_PODate;
private DateTime IH_OrderDate;
private string IH_RecordCheck;
private DateTime IH_DateCreated;
private DateTime IH_DateUpdated;
private int IH_UserID;
private string IH_BaseCurrency;
private decimal IH_ExchangeRate;
private decimal IH_DepositAmt;
private decimal IH_AmtOwed;
private string IH_Authorization;
private string IH_CreditCardType;
private string IH_CreditCardNumber;
private int IH_ExpiryDate;
private string IH_Dealer;
private string IH_DealerSalesRep;
private decimal IH_Paid;
private decimal IH_Balance;
private string IH_PaymentsMethod;
private decimal IH_Returned;
private decimal IH_Refunded;
private decimal IH_BalanceReturn;
//Auxiliry variables using in loadMaxMin
private int Max;
private int Min;
private DateTime MaxDate;
private DateTime MinDate;
private int countRecords;

//Using to recover the invoices transfer

public 
OEInvoiceHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.IH_Db = reader.GetString("IH_Db");
	this.IH_Company = reader.GetInt32("IH_Company");
	this.IH_Plant = reader.GetString("IH_Plant");
	this.IH_InvoiceNum = reader.GetInt32("IH_InvoiceNum");
	this.IH_OrderNum = reader.GetDecimal("IH_OrderNum");
	this.IH_Posted = reader.GetString("IH_Posted");
	this.IH_InvDate = reader.GetDateTime("IH_InvDate");
	this.IH_ShipDate = reader.GetDateTime("IH_ShipDate");
	this.IH_InvType = reader.GetString("IH_InvType");
	this.IH_InvCredit = reader.GetString("IH_InvCredit");
	this.IH_BillToCust = reader.GetString("IH_BillToCust");
	this.IH_ShiptoCust = reader.GetString("IH_ShiptoCust");
	this.IH_BillToName = reader.GetString("IH_BillToName");
	this.IH_ShipToName = reader.GetString("IH_ShipToName");
	this.IH_InvoiceTotal = reader.GetDecimal("IH_InvoiceTotal");
	this.IH_Tax1Total = reader.GetDecimal("IH_Tax1Total");
	this.IH_Tax2Total = reader.GetDecimal("IH_Tax2Total");
	this.IH_Tax3Total = reader.GetDecimal("IH_Tax3Total");
	this.IH_DiscountTot = reader.GetDecimal("IH_DiscountTot");
	this.IH_TaxTotal = reader.GetDecimal("IH_TaxTotal");
	this.IH_CostTotal = reader.GetDecimal("IH_CostTotal");
	this.IH_Terms = reader.GetString("IH_Terms");
	this.IH_PayType = reader.GetString("IH_PayType");
	this.IH_PONum = reader.GetString("IH_PONum");
	this.IH_QuoteNum = reader.GetString("IH_QuoteNum");
	this.IH_Currency = reader.GetString("IH_Currency");
	this.IH_SalesPer = reader.GetString("IH_SalesPer");
	this.IH_BOLNumber = reader.GetInt32("IH_BOLNumber");
	this.IH_PackSlipNum = reader.GetString("IH_PackSlipNum");
	this.IH_StockLoc = reader.GetString("IH_StockLoc");
	this.IH_Warehouse = reader.GetString("IH_Warehouse");
	this.IH_ShipToAdr1 = reader.GetString("IH_ShipToAdr1");
	this.IH_ShipToAdr2 = reader.GetString("IH_ShipToAdr2");
	this.IH_ShipToAdr3 = reader.GetString("IH_ShipToAdr3");
	this.IH_ShipVia = reader.GetString("IH_ShipVia");
	this.IH_FreightTerms = reader.GetString("IH_FreightTerms");
	this.IH_FOBPoint = reader.GetString("IH_FOBPoint");
	this.IH_Printed = reader.GetString("IH_Printed");
	this.IH_Emailed = reader.GetString("IH_Emailed");
	this.IH_Faxed = reader.GetString("IH_Faxed");
	this.IH_EmailList = reader.GetDecimal("IH_EmailList");
	this.IH_ARYear = reader.GetInt32("IH_ARYear");
	this.IH_ARPeriod = reader.GetInt32("IH_ARPeriod");
	this.IH_PostedToERP = reader.GetString("IH_PostedToERP");
	this.IH_BatchNumber = reader.GetInt32("IH_BatchNumber");
	this.IH_ChargesCalculated = reader.GetString("IH_ChargesCalculated");
    this.IH_PODate = reader.GetDateTime("IH_PODate");
    this.IH_OrderDate = reader.GetDateTime("IH_OrderDate");
    this.IH_RecordCheck = reader.GetString("IH_RecordCheck");
    this.IH_DateCreated = reader.GetDateTime("IH_DateCreated");
    this.IH_DateUpdated = reader.GetDateTime("IH_DateUpdated");
    this.IH_UserID = reader.GetInt32("IH_UserID");
    this.IH_BaseCurrency = reader.GetString("IH_BaseCurrency");
    this.IH_ExchangeRate = reader.GetDecimal("IH_ExchangeRate");
    this.IH_DepositAmt = reader.GetDecimal("IH_DepositAmt");
    this.IH_AmtOwed = reader.GetDecimal("IH_AmtOwed");
    this.IH_Authorization = reader.GetString("IH_Authorization");
    this.IH_CreditCardType = reader.GetString("IH_CreditCardType");
    this.IH_CreditCardNumber = reader.GetString("IH_CreditCardNumber");
    this.IH_ExpiryDate = reader.GetInt32("IH_ExpiryDate");
    this.IH_Dealer = reader.GetString("IH_Dealer");
    this.IH_DealerSalesRep    = reader.GetString("IH_DealerSalesRep");
    this.IH_Paid = reader.GetDecimal("IH_Paid");
    this.IH_Balance = reader.GetDecimal("IH_Balance");
    this.IH_PaymentsMethod = reader.GetString("IH_PaymentsMethod");
    this.IH_Returned = reader.GetDecimal("IH_Returned");
    this.IH_Refunded = reader.GetDecimal("IH_Refunded");
    this.IH_BalanceReturn = reader.GetDecimal("IH_BalanceReturn");
 
}

public
void loadMaxMin(NotNullDataReader reader){
	this.Max= reader.GetInt32("Max");
	this.Min= reader.GetInt32("Min");
}

public
void loadMaxMinDate(NotNullDataReader reader){
	this.MaxDate= reader.GetDateTime("MaxDate");
	this.MinDate= reader.GetDateTime("MinDate");
}
public
void loadByDbInvoiceNum(NotNullDataReader reader){
	this.IH_Db = reader.GetString("IH_Db");
	this.IH_Company = reader.GetInt32("IH_Company");
	this.IH_Plant = reader.GetString("IH_Plant");
	this.IH_InvoiceNum = reader.GetInt32("IH_InvoiceNum");
}

public
void loadCountRecords(NotNullDataReader reader){
    this.countRecords = reader.GetInt32("countRecords");
}

public override
void write(){
	string sql = "insert into oeinvoicehdr values('" +
			    Converter.fixString(IH_Db) + "', " +
			    NumberUtil.toString(IH_Company) + ", '" +
			    Converter.fixString(IH_Plant) + "', " +
			    NumberUtil.toString(IH_InvoiceNum) + ", " +
			    NumberUtil.toString(IH_OrderNum) + ", '" +
			    Converter.fixString(IH_Posted) + "', '" +
			    DateUtil.getDateRepresentation(IH_InvDate) + "', '" +
			    DateUtil.getDateRepresentation(IH_ShipDate) + "', '" +
			    Converter.fixString(IH_InvType) + "', '" +
			    Converter.fixString(IH_InvCredit) + "', '" +
			    Converter.fixString(IH_BillToCust) + "', '" +
			    Converter.fixString(IH_ShiptoCust) + "', '" +
			    Converter.fixString(IH_BillToName) + "', '" +
			    Converter.fixString(IH_ShipToName) + "', " +
			    NumberUtil.toString(IH_InvoiceTotal) + ", " +
			    NumberUtil.toString(IH_Tax1Total) + ", " +
			    NumberUtil.toString(IH_Tax2Total) + ", " +
			    NumberUtil.toString(IH_Tax3Total) + ", " +
			    NumberUtil.toString(IH_DiscountTot) + ", " +
			    NumberUtil.toString(IH_TaxTotal) + ", " +
			    NumberUtil.toString(IH_CostTotal) + ", '" +
			    Converter.fixString(IH_Terms) + "', '" +
			    Converter.fixString(IH_PayType) + "', '" +
			    Converter.fixString(IH_PONum) + "', '" +
			    Converter.fixString(IH_QuoteNum) + "', '" +
			    Converter.fixString(IH_Currency) + "', '" +
			    Converter.fixString(IH_SalesPer) + "', " +
			    NumberUtil.toString(IH_BOLNumber) + ", '" +
			    Converter.fixString(IH_PackSlipNum) + "', '" +
			    Converter.fixString(IH_StockLoc) + "', '" +
			    Converter.fixString(IH_Warehouse) + "', '" +
			    Converter.fixString(IH_ShipToAdr1) + "', '" +
			    Converter.fixString(IH_ShipToAdr2) + "', '" +
			    Converter.fixString(IH_ShipToAdr3) + "', '" +
			    Converter.fixString(IH_ShipVia) + "', '" +
			    Converter.fixString(IH_FreightTerms) + "', '" +
			    Converter.fixString(IH_FOBPoint) + "', '" +
			    Converter.fixString(IH_Printed) + "', '" +
			    Converter.fixString(IH_Emailed) + "', '" +
			    Converter.fixString(IH_Faxed) + "', " +
			    NumberUtil.toString(IH_EmailList) + ", " +
			    NumberUtil.toString(IH_ARYear) + ", " +
			    NumberUtil.toString(IH_ARPeriod) + ", '" +
			    Converter.fixString(IH_PostedToERP)+"', " +
			    NumberUtil.toString(IH_BatchNumber)+", '" +
			    Converter.fixString(IH_ChargesCalculated) + "', '" +
                DateUtil.getCompleteDateRepresentation(IH_PODate) +"', '" +
                DateUtil.getCompleteDateRepresentation(IH_OrderDate) +"', '" +
                Converter.fixString(IH_RecordCheck)+ "', '"  +
                DateUtil.getCompleteDateRepresentation(IH_DateCreated) +"', '" +
                DateUtil.getCompleteDateRepresentation(IH_DateUpdated) +"', " +
                NumberUtil.toString(IH_UserID) +", '" +
                Converter.fixString(IH_BaseCurrency) +"', " +
                NumberUtil.toString(IH_ExchangeRate) +", " +
                NumberUtil.toString(IH_DepositAmt) +", " +
                NumberUtil.toString(IH_AmtOwed) +", '" +
                Converter.fixString(IH_Authorization) +"', '" +
                Converter.fixString(IH_CreditCardType) +"', '" +
                Converter.fixString(IH_CreditCardNumber) +"', " +
                NumberUtil.toString(IH_ExpiryDate) +", '" +
                Converter.fixString(IH_Dealer) +"', '" +
                Converter.fixString(IH_DealerSalesRep) +"'," +
                NumberUtil.toString(IH_Paid) +", " +
                NumberUtil.toString(IH_Balance) +", '" +
                Converter.fixString(IH_PaymentsMethod) +"', " +
                NumberUtil.toString(IH_Returned) +", " +
                NumberUtil.toString(IH_Refunded) +", " +
                NumberUtil.toString(IH_BalanceReturn) +")";
    write(sql);
}

public override
void update(){
		string sql = "update oeinvoicehdr set " +
				"IH_OrderNum = " + NumberUtil.toString(IH_OrderNum) + ", " +
				"IH_Posted = '" +Converter.fixString(IH_Posted) + "', " +
				"IH_InvDate = '" +DateUtil.getCompleteDateRepresentation(IH_InvDate) + "', " +
				"IH_ShipDate = '" + DateUtil.getCompleteDateRepresentation(IH_ShipDate) + "', " +
				"IH_InvType = '" +Converter.fixString(IH_InvType) + "', " +
				"IH_InvCredit ='" +Converter.fixString(IH_InvCredit) + "', " +
				"IH_BillToCust ='" +Converter.fixString(IH_BillToCust) + "', " +
				"IH_ShiptoCust ='" +Converter.fixString(IH_ShiptoCust) + "', " +
				"IH_BillToName ='" +Converter.fixString(IH_BillToName) + "', " +
				"IH_ShipToName ='" +Converter.fixString(IH_ShipToName) + "', " +
				"IH_InvoiceTotal = " + NumberUtil.toString(IH_InvoiceTotal) + ", " +
				"IH_Tax1Total = " + NumberUtil.toString(IH_Tax1Total) + ", " +
				"IH_Tax2Total = " + NumberUtil.toString(IH_Tax2Total) + ", " +
				"IH_Tax3Total = " + NumberUtil.toString(IH_Tax3Total) + ", " +
				"IH_DiscountTot = " + NumberUtil.toString(IH_DiscountTot) + ", " +
				"IH_TaxTotal = " +NumberUtil.toString(IH_TaxTotal) + ", " +
				"IH_CostTotal = " +NumberUtil.toString(IH_CostTotal) + ", " +
				"IH_Terms = '" +Converter.fixString(IH_Terms) + "', " +
				"IH_PayType = '" +Converter.fixString(IH_PayType) + "', " +
				"IH_PONum = '" +Converter.fixString(IH_PONum) + "', " +
				"IH_QuoteNum = '" + Converter.fixString(IH_QuoteNum) + "', " +
				"IH_Currency = '" + Converter.fixString(IH_Currency) + "', " +
				"IH_SalesPer = '" + Converter.fixString(IH_SalesPer) + "', " +
				"IH_BOLNumber = " + NumberUtil.toString(IH_BOLNumber) + ", '" +
				"IH_PackSlipNum = '" +Converter.fixString(IH_PackSlipNum) + "', " +
				"IH_StockLoc = '" + Converter.fixString(IH_StockLoc) + "', " +
				"IH_Warehouse = '" + Converter.fixString(IH_Warehouse) + "', " +
				"IH_ShipToAdr1 = '" + Converter.fixString(IH_ShipToAdr1) + "', " +
				"IH_ShipToAdr2 = '" + Converter.fixString(IH_ShipToAdr2) + "', " +
				"IH_ShipToAdr3 = '" + Converter.fixString(IH_ShipToAdr3) + "', " +
				"IH_ShipVia = '" + Converter.fixString(IH_ShipVia) + "', " +
				"IH_FreightTerms ='" + Converter.fixString(IH_FreightTerms) + "', " +
				"IH_FOBPoint = '" + Converter.fixString(IH_FOBPoint) + "', " +
				"IH_Printed = '" + Converter.fixString(IH_Printed) + "', " +
				"IH_Emailed = '" +Converter.fixString(IH_Emailed) + "', " +
				"IH_Faxed = '" + Converter.fixString(IH_Faxed) + "', " +
				"IH_EmailList = " +NumberUtil.toString(IH_EmailList) + ", " +
				"IH_ARYear  = " + IH_ARYear + ", " +
				"IH_ARPeriod = " + IH_ARPeriod + ", " +
				"IH_PostedToERP = '" +IH_PostedToERP +"', " +  
				"IH_BatchNumber =" + NumberUtil.toString(IH_BatchNumber)+", " + 
				"IH_ChargesCalculated = '"+ Converter.fixString(IH_ChargesCalculated)+"', " +
                "IH_PODate = '" + DateUtil.getCompleteDateRepresentation(IH_PODate) +"', " +
                "IH_OrderDate = '" + DateUtil.getCompleteDateRepresentation(IH_OrderDate) +"', " +
                "IH_RecordCheck = '" + Converter.fixString(IH_RecordCheck) +"', " +
                "IH_DateCreated = '" + DateUtil.getCompleteDateRepresentation(IH_DateCreated) +"', " +
                "IH_DateUpdated = '" + DateUtil.getCompleteDateRepresentation(IH_DateUpdated) +"', " +
                "IH_UserID = " + NumberUtil.toString(IH_UserID) +", " +
                "IH_BaseCurrency = '" + Converter.fixString(IH_BaseCurrency) +"', " +
                "IH_ExchangeRate = '" + NumberUtil.toString(IH_ExchangeRate) +", " +
                "IH_DepositAmt = " + NumberUtil.toString(IH_DepositAmt) +", " +
                "IH_AmtOwed = " + NumberUtil.toString(IH_AmtOwed) +", " +
                "IH_Authorization = '" + Converter.fixString(IH_Authorization) +"', " +
                "IH_CreditCardType = '" + Converter.fixString(IH_CreditCardType) +"', " +
                "IH_CreditCardNumber = '" + Converter.fixString(IH_CreditCardNumber) +"', " +
                "IH_ExpiryDate = " + NumberUtil.toString(IH_ExpiryDate) +", " +
                "IH_Dealer = '" + Converter.fixString(IH_Dealer) +"', " +
                "IH_DealerSalesRep = '" + Converter.fixString(IH_DealerSalesRep) +"' " +
                "IH_Paid = " + NumberUtil.toString(IH_Paid) +", " +
                "IH_Balance = " + NumberUtil.toString(IH_Balance) +", '" +
                "IH_PaymentsMethod = '" +Converter.fixString(IH_PaymentsMethod) +"', " +
                "IH_Returned =" + NumberUtil.toString(IH_Returned) +", " +
                "IH_Refunded =" + NumberUtil.toString(IH_Refunded) +", " +
                "IH_BalanceReturn =" +NumberUtil.toString(IH_BalanceReturn) +   
			" where " + 
			        getWhereCondition();
	update(sql);

}

public override
void delete(){

	string sql = "delete from oeinvoicehdr where " + getWhereCondition();
    delete(sql);
}

public
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from oeinvoicehdr where " +  getWhereCondition();
		
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

	string sql = "select * from oeinvoicehdr " + 
		"where " + getWhereCondition();
    return exists(sql);
	
}

public 
void updateCharge(){
	string sql = "update oeinvoicehdr set " +
			"IH_ChargesCalculated = '"+ Converter.fixString(IH_ChargesCalculated)+"' " +
    		"where " + getWhereCondition();
			
	update(sql);

}

private string getWhereCondition(){
    string sql ="IH_Db = '" + Converter.fixString(IH_Db) + "' and " +
			    "IH_Company =" + NumberUtil.toString(IH_Company) + " and " +
			    "IH_Plant = '" + Converter.fixString(IH_Plant) + "' and " +
			    "IH_InvoiceNum = " + NumberUtil.toString(IH_InvoiceNum);
	return sql;
}

//Setters
public 
void setIH_Db(string IH_Db){
   this.IH_Db = IH_Db;
}

public 
void setIH_Company(int IH_Company){
   this.IH_Company = IH_Company;
}

public 
void setIH_Plant(string IH_Plant){
   this.IH_Plant = IH_Plant;
}

public 
void setIH_InvoiceNum(int IH_InvoiceNum){
   this.IH_InvoiceNum = IH_InvoiceNum;
}

public 
void setIH_OrderNum(decimal IH_OrderNum){
   this.IH_OrderNum = IH_OrderNum;
}

public 
void setIH_Posted(string IH_Posted){
   this.IH_Posted = IH_Posted;
}

public 
void setIH_InvDate(DateTime IH_InvDate){
   this.IH_InvDate = IH_InvDate;
}

public 
void setIH_ShipDate(DateTime IH_ShipDate){
   this.IH_ShipDate = IH_ShipDate;
}

public 
void setIH_InvType(string IH_InvType){
   this.IH_InvType = IH_InvType;
}

public 
void setIH_InvCredit(string IH_InvCredit){
   this.IH_InvCredit = IH_InvCredit;
}

public 
void setIH_BillToCust(string IH_BillToCust){
   this.IH_BillToCust = IH_BillToCust;
}

public 
void setIH_ShiptoCust(string IH_ShiptoCust){
   this.IH_ShiptoCust = IH_ShiptoCust;
}

public 
void setIH_BillToName(string IH_BillToName){
   this.IH_BillToName = IH_BillToName;
}

public 
void setIH_ShipToName(string IH_ShipToName){
   this.IH_ShipToName = IH_ShipToName;
}

public 
void setIH_InvoiceTotal(decimal IH_InvoiceTotal){
   this.IH_InvoiceTotal = IH_InvoiceTotal;
}

public 
void setIH_Tax1Total(decimal IH_Tax1Total){
   this.IH_Tax1Total = IH_Tax1Total;
}

public 
void setIH_Tax2Total(decimal IH_Tax2Total){
   this.IH_Tax2Total = IH_Tax2Total;
}

public 
void setIH_Tax3Total(decimal IH_Tax3Total){
   this.IH_Tax3Total = IH_Tax3Total;
}

public 
void setIH_DiscountTot(decimal IH_DiscountTot){
   this.IH_DiscountTot = IH_DiscountTot;
}

public 
void setIH_TaxTotal(decimal IH_TaxTotal){
   this.IH_TaxTotal = IH_TaxTotal;
}

public 
void setIH_CostTotal(decimal IH_CostTotal){
   this.IH_CostTotal = IH_CostTotal;
}

public 
void setIH_Terms(string IH_Terms){
   this.IH_Terms = IH_Terms;
}

public 
void setIH_PayType(string IH_PayType){
   this.IH_PayType = IH_PayType;
}

public 
void setIH_PONum(string IH_PONum){
   this.IH_PONum = IH_PONum;
}

public 
void setIH_QuoteNum(string IH_QuoteNum){
   this.IH_QuoteNum = IH_QuoteNum;
}

public 
void setIH_Currency(string IH_Currency){
   this.IH_Currency = IH_Currency;
}

public 
void setIH_SalesPer(string IH_SalesPer){
   this.IH_SalesPer = IH_SalesPer;
}

public 
void setIH_BOLNumber(int IH_BOLNumber){
   this.IH_BOLNumber = IH_BOLNumber;
}

public 
void setIH_PackSlipNum(string IH_PackSlipNum){
   this.IH_PackSlipNum = IH_PackSlipNum;
}

public 
void setIH_StockLoc(string IH_StockLoc){
   this.IH_StockLoc = IH_StockLoc;
}

public 
void setIH_Warehouse(string IH_Warehouse){
   this.IH_Warehouse = IH_Warehouse;
}

public 
void setIH_ShipToAdr1(string IH_ShipToAdr1){
   this.IH_ShipToAdr1 = IH_ShipToAdr1;
}

public 
void setIH_ShipToAdr2(string IH_ShipToAdr2){
   this.IH_ShipToAdr2 = IH_ShipToAdr2;
}

public 
void setIH_ShipToAdr3(string IH_ShipToAdr3){
   this.IH_ShipToAdr3 = IH_ShipToAdr3;
}

public 
void setIH_ShipVia(string IH_ShipVia){
   this.IH_ShipVia = IH_ShipVia;
}

public 
void setIH_FreightTerms(string IH_FreightTerms){
   this.IH_FreightTerms = IH_FreightTerms;
}

public 
void setIH_FOBPoint(string IH_FOBPoint){
   this.IH_FOBPoint = IH_FOBPoint;
}

public 
void setIH_Printed(string IH_Printed){
   this.IH_Printed = IH_Printed;
}

public 
void setIH_Emailed(string IH_Emailed){
   this.IH_Emailed = IH_Emailed;
}

public 
void setIH_Faxed(string IH_Faxed){
   this.IH_Faxed = IH_Faxed;
}

public 
void setIH_EmailList(decimal IH_EmailList){
   this.IH_EmailList = IH_EmailList;
}

public 
void setIH_ARYear(int IH_ARYear){
   this.IH_ARYear = IH_ARYear;
}

public 
void setIH_ARPeriod(int IH_ARPeriod){
   this.IH_ARPeriod = IH_ARPeriod;
}

public 
void setIH_PostedToERP (string IH_PostedToERP){
    this.IH_PostedToERP = IH_PostedToERP;
}

public 
void setIH_BatchNumber(int IH_BatchNumber){
   this.IH_BatchNumber= IH_BatchNumber;
}

public 
void setIH_ChargesCalculated(string IH_ChargesCalculated){
    this.IH_ChargesCalculated = IH_ChargesCalculated;
}

public 
void setIH_PODate (DateTime IH_PODate){
    this.IH_PODate = IH_PODate;
}

public 
void setIH_OrderDate (DateTime IH_OrderDate){
    this.IH_OrderDate = IH_OrderDate;
}

public 
void setIH_RecordCheck (string IH_RecordCheck){
    this.IH_RecordCheck = IH_RecordCheck;
}


public void setIH_DateCreated (DateTime IH_DateCreated){
    this.IH_DateCreated = IH_DateCreated;
}

public void setIH_DateUpdated (DateTime IH_DateUpdated){
    this.IH_DateUpdated = IH_DateUpdated;
}

public void setIH_UserID (int IH_UserID){
    this.IH_UserID = IH_UserID;
}


public void setIH_BaseCurrency (string IH_BaseCurrency){
    this.IH_BaseCurrency = IH_BaseCurrency;
}

public void setIH_ExchangeRate (decimal IH_ExchangeRate){
    this.IH_ExchangeRate = IH_ExchangeRate;
}

public void setIH_DepositAmt (decimal IH_DepositAmt){
    this.IH_DepositAmt = IH_DepositAmt;
}

public void setIH_AmtOwed (decimal IH_AmtOwed){
    this.IH_AmtOwed = IH_AmtOwed;
}

public void setIH_Authorization (string IH_Authorization){
    this.IH_Authorization = IH_Authorization;
}

public void setIH_CreditCardType (string IH_CreditCardType){
    this.IH_CreditCardType = IH_CreditCardType;
}

public void setIH_CreditCardNumber (string IH_CreditCardNumber){
    this.IH_CreditCardNumber = IH_CreditCardNumber;
}

public void setIH_ExpiryDate (int IH_ExpiryDate){
    this.IH_ExpiryDate = IH_ExpiryDate;
}

public void setIH_Dealer (string IH_Dealer){
    this.IH_Dealer = IH_Dealer;
}

public void setIH_DealerSalesRep (string IH_DealerSalesRep){
    this.IH_DealerSalesRep = IH_DealerSalesRep;
}

public void setIH_Paid (decimal IH_Paid){
    this.IH_Paid = IH_Paid;
}

public void setIH_Balance (decimal IH_Balance){
    this.IH_Balance = IH_Balance;
}

public void setIH_PaymentsMethod (string IH_PaymentsMethod){
    this.IH_PaymentsMethod = IH_PaymentsMethod;
}

public void setIH_Returned (decimal IH_Returned){
    this.IH_Returned = IH_Returned;
}

public void setIH_Refunded (decimal IH_Refunded){
    this.IH_Refunded = IH_Refunded;
}

public void setIH_BalanceReturn (decimal IH_BalanceReturn){
    this.IH_BalanceReturn = IH_BalanceReturn;
}



// aux vars
public 
void setcountRecords (int countRecords){
    this.countRecords = countRecords;
}

public 
void setMax(int Max){
   this.Max = Max;
}

public 
void setMin(int Min){
   this.Min = Min;
}

public 
void setMaxDate(DateTime MaxDate){
   this.MaxDate = MaxDate;
}

public 
void setMinDate(DateTime MinDate){
   this.MinDate = MinDate;
}


//Getters
public
string getIH_Db(){
   return IH_Db;
}

public
int getIH_Company(){
   return IH_Company;
}

public
string getIH_Plant(){
   return IH_Plant;
}

public
int getIH_InvoiceNum(){
   return IH_InvoiceNum;
}

public
decimal getIH_OrderNum(){
   return IH_OrderNum;
}

public
string getIH_Posted(){
   return IH_Posted;
}

public
DateTime getIH_InvDate(){
   return IH_InvDate;
}

public
DateTime getIH_ShipDate(){
   return IH_ShipDate;
}

public
string getIH_InvType(){
   return IH_InvType;
}

public
string getIH_InvCredit(){
   return IH_InvCredit;
}

public
string getIH_BillToCust(){
   return IH_BillToCust;
}

public
string getIH_ShiptoCust(){
   return IH_ShiptoCust;
}

public
string getIH_BillToName(){
   return IH_BillToName;
}

public
string getIH_ShipToName(){
   return IH_ShipToName;
}

public
decimal getIH_InvoiceTotal(){
   return IH_InvoiceTotal;
}

public
decimal getIH_Tax1Total(){
   return IH_Tax1Total;
}

public
decimal getIH_Tax2Total(){
   return IH_Tax2Total;
}

public
decimal getIH_Tax3Total(){
   return IH_Tax3Total;
}

public
decimal getIH_DiscountTot(){
   return IH_DiscountTot;
}

public
decimal getIH_TaxTotal(){
   return IH_TaxTotal;
}

public
decimal getIH_CostTotal(){
   return IH_CostTotal;
}

public
string getIH_Terms(){
   return IH_Terms;
}

public
string getIH_PayType(){
   return IH_PayType;
}

public
string getIH_PONum(){
   return IH_PONum;
}

public
string getIH_QuoteNum(){
   return IH_QuoteNum;
}

public
string getIH_Currency(){
   return IH_Currency;
}

public
string getIH_SalesPer(){
   return IH_SalesPer;
}

public
int getIH_BOLNumber(){
   return IH_BOLNumber;
}

public
string getIH_PackSlipNum(){
   return IH_PackSlipNum;
}

public
string getIH_StockLoc(){
   return IH_StockLoc;
}

public
string getIH_Warehouse(){
   return IH_Warehouse;
}

public
string getIH_ShipToAdr1(){
   return IH_ShipToAdr1;
}

public
string getIH_ShipToAdr2(){
   return IH_ShipToAdr2;
}

public
string getIH_ShipToAdr3(){
   return IH_ShipToAdr3;
}

public
string getIH_ShipVia(){
   return IH_ShipVia;
}

public
string getIH_FreightTerms(){
   return IH_FreightTerms;
}

public
string getIH_FOBPoint(){
   return IH_FOBPoint;
}

public
string getIH_Printed(){
   return IH_Printed;
}

public
string getIH_Emailed(){
   return IH_Emailed;
}

public
string getIH_Faxed(){
   return IH_Faxed;
}

public
decimal getIH_EmailList(){
   return IH_EmailList;
}

public
int getIH_ARYear(){
   return IH_ARYear;
}

public
int getIH_ARPeriod(){
   return IH_ARPeriod;
}

public 
string getIH_PostedToERP(){
    return IH_PostedToERP;
}

public 
int getIH_BatchNumber(){
    return IH_BatchNumber;
}


public string getIH_ChargesCalculated(){
    return IH_ChargesCalculated;
}

public string getIH_RecordCheck(){
    return IH_RecordCheck;
}


//Auxiliares
public
int getMax(){
   return Max;
}

public
int getMin(){
   return Min;
}

public
DateTime getMaxDate(){
   return MaxDate;
}

public
DateTime getMinDate(){
   return MinDate;
}

public int getcountRecords(){
    return countRecords;
}

public DateTime getIH_PODate(){
    return IH_PODate;
}

public DateTime getIH_OrderDate(){
    return IH_OrderDate;
}

public DateTime getIH_DateCreated(){
    return IH_DateCreated;
}

public DateTime getIH_DateUpdated(){
    return IH_DateUpdated;
}

public int getIH_UserID(){
    return IH_UserID;
}

public string getIH_BaseCurrency(){
    return IH_BaseCurrency;
}

public decimal getIH_ExchangeRate(){
    return IH_ExchangeRate;
}

public decimal getIH_DepositAmt(){
    return IH_DepositAmt;
}

public decimal getIH_AmtOwed(){
    return IH_AmtOwed;
}

public string getIH_Authorization(){
    return IH_Authorization;
}

public string getIH_CreditCardType(){
    return IH_CreditCardType;
}

public string getIH_CreditCardNumber(){
    return IH_CreditCardNumber;
}

public int getIH_ExpiryDate(){
    return IH_ExpiryDate;
}

public string getIH_Dealer(){
    return IH_Dealer;
}

public string getIH_DealerSalesRep(){
    return IH_DealerSalesRep;
}

public decimal getIH_Paid(){
    return IH_Paid;
}

public decimal getIH_Balance(){
    return IH_Balance;
}

public string getIH_PaymentsMethod(){
    return IH_PaymentsMethod;
}

public decimal getIH_Returned(){
    return IH_Returned;
}

public decimal getIH_Refunded(){
    return IH_Refunded;
}

public decimal getIH_BalanceReturn(){
    return IH_BalanceReturn;
}



}//end class
}//end namespace
