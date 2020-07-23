using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class APInvoiceHdrDataBase : GenericDataBaseElement{

private int APH_ID;
private string APH_Company;
private string APH_Plant;
private int APH_GroupID;
private int APH_VoucherID;
private string APH_SupplierID;
private DateTime APH_DateEntered;
private DateTime APH_InvoiceDate;
private DateTime APH_DateDue;
private DateTime APH_DateDiscount;
private decimal APH_InvoiceAmt;
private string APH_Currency;
private decimal APH_InvoiceAmtGL;
private string APH_CurrencyGL;
private int APH_FiscalPeriod;
private int APH_FiscalYear;
private string APH_ProjectCode;
private string APH_BudgetCode;
private string APH_VoucherDesc;
private int APH_CheckNumber;
private string APH_WireNumber;
private int APH_PO;
private int APH_POItem;
private int APH_POItemRel;


public APInvoiceHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}
public
void load(NotNullDataReader reader){

    this.APH_ID = reader.GetInt32("APH_ID");
    this.APH_Company = reader.GetString("APH_Company");
    this.APH_Plant = reader.GetString("APH_Plant");
    this.APH_GroupID = reader.GetInt32("APH_GroupID");
    this.APH_VoucherID = reader.GetInt32("APH_VoucherID");
    this.APH_SupplierID = reader.GetString("APH_SupplierID");
    this.APH_DateEntered = reader.GetDateTime("APH_DateEntered");
    this.APH_InvoiceDate = reader.GetDateTime("APH_InvoiceDate");
    this.APH_DateDue = reader.GetDateTime("APH_DateDue");
    this.APH_DateDiscount = reader.GetDateTime("APH_DateDiscount");
    this.APH_InvoiceAmt = reader.GetDecimal("APH_InvoiceAmt");
    this.APH_Currency = reader.GetString("APH_Currency");
    this.APH_InvoiceAmtGL = reader.GetDecimal("APH_InvoiceAmtGL");
    this.APH_CurrencyGL = reader.GetString("APH_CurrencyGL");
    this.APH_FiscalPeriod = reader.GetInt32("APH_FiscalPeriod");
    this.APH_FiscalYear = reader.GetInt32("APH_FiscalYear");
    this.APH_ProjectCode = reader.GetString("APH_ProjectCode");
    this.APH_BudgetCode = reader.GetString("APH_BudgetCode");
    this.APH_VoucherDesc = reader.GetString("APH_VoucherDesc");
    this.APH_CheckNumber = reader.GetInt32("APH_CheckNumber");
    this.APH_WireNumber = reader.GetString("APH_WireNumber");
    this.APH_PO = reader.GetInt32("APH_PO");
    this.APH_POItem = reader.GetInt32("APH_POItem");
    this.APH_POItemRel = reader.GetInt32("APH_POItemRel");

}

public override
void write(){
   try{
	    string sql = "insert into apinvoicehdr " + 
	                    "(APH_Company,APH_Plant,APH_GroupID,APH_VoucherID,APH_SupplierID,APH_DateEntered,"+
	                     "APH_InvoiceDate,APH_DateDue,APH_DateDiscount,APH_InvoiceAmt,APH_Currency,APH_InvoiceAmtGL,"+
	                     "APH_CurrencyGL,APH_FiscalPeriod,APH_FiscalYear,APH_ProjectCode,APH_BudgetCode,APH_VoucherDesc,"+
	                     "APH_CheckNumber,APH_WireNumber,APH_PO,APH_POItem,APH_POItemRel)" +
	                " values('" +
                                Converter.fixString(APH_Company) +"', '" +
                                Converter.fixString(APH_Plant) +"', " +
                                NumberUtil.toString(APH_GroupID) +", " +
                                NumberUtil.toString(APH_VoucherID) +", '" +
                                Converter.fixString(APH_SupplierID) +"', '" +
                                DateUtil.getDateRepresentation(APH_DateEntered) +"', '" +
                                DateUtil.getDateRepresentation(APH_InvoiceDate) +"', '" +
                                DateUtil.getDateRepresentation(APH_DateDue) +"', '" +
                                DateUtil.getDateRepresentation(APH_DateDiscount) +"', " +
                                NumberUtil.toString(APH_InvoiceAmt) +", '" +
                                Converter.fixString(APH_Currency) +"', " +
                                NumberUtil.toString(APH_InvoiceAmtGL) +", '" +
                                Converter.fixString(APH_CurrencyGL) +"', " +
                                NumberUtil.toString(APH_FiscalPeriod) +", " +
                                NumberUtil.toString(APH_FiscalYear) +", '" +
                                Converter.fixString(APH_ProjectCode) +"', '" +
                                Converter.fixString(APH_BudgetCode) +"', '" +
                                Converter.fixString(APH_VoucherDesc) +"', " +
                                NumberUtil.toString(APH_CheckNumber) +", '" +
                                Converter.fixString(APH_WireNumber) +"', " +
                                NumberUtil.toString(APH_PO) +", " +
                                NumberUtil.toString(APH_POItem) +", " +
                                NumberUtil.toString(APH_POItemRel) +")";
        dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
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
    throw new PersistenceException("Method not implemented");
}

//Setters

public void setAPH_ID (int APH_ID){
    this.APH_ID = APH_ID;
}

public void setAPH_Company (string APH_Company){
    this.APH_Company = APH_Company;
}

public void setAPH_Plant (string APH_Plant){
    this.APH_Plant = APH_Plant;
}

public void setAPH_GroupID (int APH_GroupID){
    this.APH_GroupID = APH_GroupID;
}

public void setAPH_VoucherID (int APH_VoucherID){
    this.APH_VoucherID = APH_VoucherID;
}

public void setAPH_SupplierID (string APH_SupplierID){
    this.APH_SupplierID = APH_SupplierID;
}

public void setAPH_DateEntered (DateTime APH_DateEntered){
    this.APH_DateEntered = APH_DateEntered;
}

public void setAPH_InvoiceDate (DateTime APH_InvoiceDate){
    this.APH_InvoiceDate = APH_InvoiceDate;
}

public void setAPH_DateDue (DateTime APH_DateDue){
    this.APH_DateDue = APH_DateDue;
}

public void setAPH_DateDiscount (DateTime APH_DateDiscount){
    this.APH_DateDiscount = APH_DateDiscount;
}

public void setAPH_InvoiceAmt (decimal APH_InvoiceAmt){
    this.APH_InvoiceAmt = APH_InvoiceAmt;
}

public void setAPH_Currency (string APH_Currency){
    this.APH_Currency = APH_Currency;
}

public void setAPH_InvoiceAmtGL (decimal APH_InvoiceAmtGL){
    this.APH_InvoiceAmtGL = APH_InvoiceAmtGL;
}

public void setAPH_CurrencyGL (string APH_CurrencyGL){
    this.APH_CurrencyGL = APH_CurrencyGL;
}

public void setAPH_FiscalPeriod (int APH_FiscalPeriod){
    this.APH_FiscalPeriod = APH_FiscalPeriod;
}

public void setAPH_FiscalYear (int APH_FiscalYear){
    this.APH_FiscalYear = APH_FiscalYear;
}

public void setAPH_ProjectCode (string APH_ProjectCode){
    this.APH_ProjectCode = APH_ProjectCode;
}

public void setAPH_BudgetCode (string APH_BudgetCode){
    this.APH_BudgetCode = APH_BudgetCode;
}

public void setAPH_VoucherDesc (string APH_VoucherDesc){
    this.APH_VoucherDesc = APH_VoucherDesc;
}

public void setAPH_CheckNumber (int APH_CheckNumber){
    this.APH_CheckNumber = APH_CheckNumber;
}

public void setAPH_WireNumber (string APH_WireNumber){
    this.APH_WireNumber = APH_WireNumber;
}

public void setAPH_PO (int APH_PO){
    this.APH_PO = APH_PO;
}

public void setAPH_POItem (int APH_POItem){
    this.APH_POItem = APH_POItem;
}

public void setAPH_POItemRel (int APH_POItemRel){
    this.APH_POItemRel = APH_POItemRel;
}



//Getters

public int getAPH_ID(){
    return APH_ID;
}

public string getAPH_Company(){
    return APH_Company;
}

public string getAPH_Plant(){
    return APH_Plant;
}

public int getAPH_GroupID(){
    return APH_GroupID;
}

public int getAPH_VoucherID(){
    return APH_VoucherID;
}

public string getAPH_SupplierID(){
    return APH_SupplierID;
}

public DateTime getAPH_DateEntered(){
    return APH_DateEntered;
}

public DateTime getAPH_InvoiceDate(){
    return APH_InvoiceDate;
}

public DateTime getAPH_DateDue(){
    return APH_DateDue;
}

public DateTime getAPH_DateDiscount(){
    return APH_DateDiscount;
}

public decimal getAPH_InvoiceAmt(){
    return APH_InvoiceAmt;
}

public string getAPH_Currency(){
    return APH_Currency;
}

public decimal getAPH_InvoiceAmtGL(){
    return APH_InvoiceAmtGL;
}

public string getAPH_CurrencyGL(){
    return APH_CurrencyGL;
}

public int getAPH_FiscalPeriod(){
    return APH_FiscalPeriod;
}

public int getAPH_FiscalYear(){
    return APH_FiscalYear;
}

public string getAPH_ProjectCode(){
    return APH_ProjectCode;
}

public string getAPH_BudgetCode(){
    return APH_BudgetCode;
}

public string getAPH_VoucherDesc(){
    return APH_VoucherDesc;
}

public int getAPH_CheckNumber(){
    return APH_CheckNumber;
}

public string getAPH_WireNumber(){
    return APH_WireNumber;
}

public int getAPH_PO(){
    return APH_PO;
}

public int getAPH_POItem(){
    return APH_POItem;
}

public int getAPH_POItemRel(){
    return APH_POItemRel;
}


}//end class
}//end namespace
