using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;

using System.Collections;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core{


public class Order :
#if OE_SYNC
	Serializable{
#else
	MarshalByRefObject{
#endif

private	int   id;
private	string sdb;
private string scompany;
private string splant;
private int	   iorderNum;
private string sorgId;
private DateTime	orderDate;
private string sorderSatus;
private string sdistributionLoc;
private string sorderType;
private string sbillToNum;
private string sbillToName;
private string sBillToAdd1;
private string sBillToAdd2;
private string sBillToAdd3;
private string sBillToAdd4;
private string sBillToAdd5;
private string sBillToAdd6;
private string sBillToZipCode;
private string sattention;
private string sterms;
private string shipVia;
private string spO;
private int	   iquote;
private string scurrency;
private string salesPerson;
private double dcomPercent;
private double dcomRate;
private DateTime	dateRequest;
private DateTime	datePromise;
private DateTime	dateShip;
private DateTime	dateConfirm;
private DateTime	dateCancel;
private DateTime	prodDate;
private string sterritory;
private string sholdStatus;
private string shipComplete;
private double dorderTotal;
private double dorderNet;
private double dtax1Total;
private double dtax2Total;
private double dtax3Total;
private double discountTot;
private double dcommissTot;
private double droyaltyTot;
private string synchronized;
private string sorgOrderType;
private string sretailProductType;
private string sentToCMS;
private string sentUser;
private DateTime sentDateTime;
private string serpOrdNum;

//now we hava only 1 ship client, in the future could be more than 1
private string shipToNum;

#if OE_SYNC
public const string FieldH_ID				= "f1";
public const string FieldH_Db				= "f2";		
public const string FieldH_Company			= "f3";
public const string FieldH_Plant			= "f4";
public const string	FieldH_OrderNum			= "f5";
public const string FieldH_OrderOrg			= "f6";
public const string	FieldH_OrderDate		= "f7";
public const string FieldH_OrderStatus		= "f8";
public const string FieldH_DistributionLoc	= "f9";
public const string FieldH_OrderType		= "f10";
public const string FieldH_BillToNum		= "f11";
public const string FieldH_BillToName		= "f12";
public const string FieldH_BillToAdd1		= "f13";
public const string FieldH_BillToAdd2		= "f14";
public const string FieldH_BillToAdd3		= "f15";
public const string FieldH_BillToAdd4		= "f16";
public const string FieldH_BillToAdd5		= "f17";
public const string FieldH_BillToAdd6		= "f18";
public const string FieldH_BillToPostZip	= "f19";
public const string FieldH_Attention		= "f20";
public const string FieldH_Terms			= "f21";	
public const string FieldH_ShipVia			= "f22";
public const string FieldH_PO				= "f23";
public const string FieldH_Quote			= "f24";
public const string FieldH_Currency			= "f25";	
public const string FieldH_SalesPerson		= "f26";
public const string FieldH_ComPercent		= "f27";
public const string FieldH_ComRate			= "f28";
public const string	FieldH_DateRequest		= "f29";	
public const string	FieldH_DatePromise		= "f30";
public const string	FieldH_DateShip			= "f31";
public const string	FieldH_DateConfirm		= "f32";
public const string	FieldH_DateCancel		= "f33";
public const string	FieldH_ProdDate			= "f34";
public const string FieldH_Territory		= "f35";
public const string FieldH_HoldStatus		= "f36";
public const string FieldH_ShipComplete		= "f37";
public const string FieldH_OrderTotal		= "f38";
public const string FieldH_OrderNet			= "f39";
public const string FieldH_Tax1Total		= "f40";	
public const string FieldH_Tax2Total		= "f41";
public const string FieldH_Tax3Total		= "f42";
public const string FieldH_DiscountTot		= "f43";
public const string FieldH_CommissTot		= "f44";
public const string FieldH_RoyaltyTot		= "f45";
public const string FieldH_Synchronized		= "f46";
public const string FieldH_RetailProductType= "f47";
public const string FieldH_SentToCMS		= "f48";
public const string FieldH_SentUser			= "f49";
public const string FieldH_SentDateTime		= "f50";
public const string FieldH_ErpOrdNum		= "f51";

public const string FieldD_HID				="f1";
public const string FieldD_ID				="f2";
public const string FieldD_Db				="f3";
public const string FieldD_Company			="f4";
public const string FieldD_Plant			="f5";
public const string FieldD_OrderNum			="f6";
public const string FieldD_ItemNum			="f7";	
public const string FieldD_OrgOrderNum		="f8";	
public const string FieldD_OrgItemNum		="f9";	
public const string FieldD_ProdID			="f10";
public const string FieldD_ProdDescription	="f11";
public const string FieldD_Seq				="f12";
public const string FieldD_InternalRef		="f13";
public const string FieldD_CustPart			="f14";
public const string FieldD_CustPO			="f15";
public const string FieldD_QtyOrdSum		="f16";
public const string FieldD_QtyShippedSum	="f17";
public const string FieldD_QtyOrdUom		="f18";
public const string FieldD_UnitPrice		="f19";
public const string FieldD_UnitPriceUom		="f20";
public const string FieldD_ItemNetTotal		="f21";
public const string FieldD_DateAdded		="f22";
public const string FieldD_TotalDiscounts	="f23";
public const string FieldD_TotalPromo		="f24";
public const string FieldD_TotalRoyalty		="f25";
public const string FieldD_TotalFreight		="f26";
public const string FieldD_TotalTax			="f27";
public const string FieldD_TotalStTax		="f28";
public const string FieldD_TotalFedTax		="f29";
#endif

	ArrayList		arrayOrderLines	= null;
	NoteList		noteList= null;

public 
Order(){
	arrayOrderLines = new ArrayList();
	noteList		= new NoteList();

	id=0;
	sdb="Db";
	scompany="Company";
	splant=Constants.CUST_DEFAULT_PLANT;
	iorderNum=0;
	sorgId="";	
	orderDate=DateUtil.MinValue;
	sorderSatus="";
	sdistributionLoc="";
	sorderType="";
	sbillToNum="";
	sbillToName="";
	sBillToAdd1="";
	sBillToAdd2="";
	sBillToAdd3="";
	sBillToAdd4="";
	sBillToAdd5="";
	sBillToAdd6="";
	sBillToZipCode="";	
	sattention="";
	sterms="";
	shipVia="";
	spO="";
	iquote=0;
	scurrency="";
	salesPerson="";
	dcomPercent=0;
	dcomRate=0;
	dateRequest = DateUtil.MinValue;
	datePromise= DateUtil.MinValue;
	dateShip= DateTime.Now;
	dateConfirm= DateUtil.MinValue;
	dateCancel= DateUtil.MinValue;
	prodDate= DateUtil.MinValue;
	sterritory="";
	sholdStatus="";
	shipComplete="";
	dorderTotal=0;
	dorderNet=0;
	dtax1Total=0;
	dtax2Total=0;
	dtax3Total=0;
	discountTot=0;
	dcommissTot=0;
	droyaltyTot=0;
	synchronized= Constants.STRING_NO;
	sorgOrderType="E";
	sretailProductType="";	
	sentToCMS=Constants.STRING_NO;
	sentUser="";
	sentDateTime=DateUtil.MinValue;
	serpOrdNum="";
	
	//now we hava only 1 ship client, in the future could be more than 1
	shipToNum="";
}

public int	getId()
{
	return id;
}
public string getDb()
{
	return sdb;
}
public string getCompany()
{
	return scompany;
}

public string getPlant()
{
	return splant;
}

public int getOrderNum()
{
	return iorderNum;
}

public string	getOrgId()
{
	return sorgId;
}

public DateTime getOrderDate(){
	return orderDate;
}

public string	getOrderStatus(){
	return sorderSatus;
}

public string getOrderStatusCompleteString()
{
	switch (sorderSatus)
	{
		case Constants.ORDER_STATUS_CREATED:
			return "Created";
		case Constants.ORDER_STATUS_FINISHED:
			return "Finished";
		case Constants.ORDER_STATUS_REMOVED:
			return "Removed";
	}
	return string.Empty;
}

public string	getDistributionLoc()
{
	return sdistributionLoc;
}
public string	getOrderType(){
	return sorderType;
}

public string	getBillToNum(){
	return sbillToNum;
}

public string	getBillToName(){
	return sbillToName;
}

public string	getBillToAdd1(){
	return sBillToAdd1;
}

public string	getBillToAdd2(){
	return sBillToAdd2;
}

public string	getBillToAdd3(){
	return sBillToAdd3;
}
public string	getBillToAdd4()
{
	return sBillToAdd3;
}
public string	getBillToAdd5()
{
	return sBillToAdd3;
}
public string	getBillToAdd6()
{
	return sBillToAdd3;
}

public string	getBillToZipCode(){
	return sBillToZipCode;
}

public string	getAttention(){
	return sattention;
}
public string	getTerms(){
	return sterms;
}
public string	getShipVia(){
	return shipVia;
}
public string	getPO(){
	return spO;
}
public int	getQuote(){
	return iquote;
}
public string getCurrency(){
	return scurrency;
}
public string	getSalesPerson(){
	return salesPerson;
}
public double	getComPercent(){
	return dcomPercent;
}
public double	getComRate(){
	return dcomRate;
}
public DateTime getDateRequest(){
	return dateRequest;
}
public DateTime getDatePromise(){
	return datePromise;
}
public DateTime getDateShip(){
	return dateShip;
}
public DateTime getDateConfirm(){
	return dateConfirm;
}
public DateTime getDateCancel(){
	return dateCancel;
}
public DateTime getProdDate(){
	return prodDate;
}
public string	getTerritory(){
	return sterritory;
}
public string getHoldStatus(){
	return sholdStatus;
}
public string getShipComplete(){
	return shipComplete;
}
public double getOrderTotal(){
	return dorderTotal;
}
public double getOrderNet(){
	return dorderNet;
}
public double getTax1Total(){
	return dtax1Total;
}
public double getTax2Total(){
	return dtax2Total;
}
public double getTax3Total(){
	return dtax3Total;
}
public double getDiscountTot(){
	return discountTot;
}
public double getCommissTot(){
	return dcommissTot;
}
public double getRoyaltyTot(){
	return droyaltyTot;
}
public string getSynchronized(){
	return synchronized;
}

public string getOrgOrderType(){
	return this.sorgOrderType;
}

public string getRetailProductType(){
	return this.sretailProductType;
}



public bool getIsQuote()
{
	string	sorderType = this.getOrderType();
	bool	bvalue=false;

	//type of order, Quote or not
	sorderType.Trim();
	if (sorderType.Equals(Constants.ORDER_TYPE_QUOTE))
		bvalue = true;
		
	return bvalue;
}
public bool getFinished()
{
	bool bvalue=true;
	//type of order, Quote or not
	if (this.getOrderStatus().Equals(Constants.ORDER_STATUS_CREATED))
		bvalue = false;
		
	return bvalue;
}

public string getErpOrdNum()
{
	return serpOrdNum;
}

public
void setSentToCMS(string sentToCMS){
	this.sentToCMS = sentToCMS;
}
public
void setSentUser(string sentUser){
	this.sentUser = sentUser;
}
public
void setSentDateTime(DateTime sentDateTime){
	this.sentDateTime = sentDateTime;
}

public
void setId(int id){
	this.id = id;
}

public
void setDb(string sdb){
	this.sdb = sdb;
}

public void setCompany(string scompany){	
	this.scompany = scompany;
}


public
void setPlant(string	splant){
	this.splant = splant;
}

public void setOrderNum(int iorderNum)
{
	this.iorderNum = iorderNum;
}


public
void setOrgId(string	sorgId){
	this.sorgId = sorgId;
}


public
void setOrderDate(DateTime	orderDate){
	this.orderDate = orderDate;
}

public
void setOrderStatus(string sorderSatus){
this.sorderSatus  = sorderSatus;
}

public
void setDistributionLoc(string sdistributionLoc){
this.sdistributionLoc = sdistributionLoc;
}

public
void setOrderType(string sorderType){
this.sorderType = sorderType;
}

public
void setBillToNum(string sbillToNum){
this.sbillToNum = sbillToNum;
}

public
void setBillToName(string sbillToName){
this.sbillToName = sbillToName;
}

public
void setBillToAdd1(string sBillToAdd1){
this.sBillToAdd1 = sBillToAdd1;
}

public
void setBillToAdd2(string sBillToAdd2){
this.sBillToAdd2 = sBillToAdd2;
}

public
void setBillToAdd3(string sBillToAdd3){
this.sBillToAdd3 = sBillToAdd3;
}

public
void setBillToAdd4(string sBillToAdd4){
this.sBillToAdd4 = sBillToAdd4;
}

public
void setBillToAdd5(string sBillToAdd5){
this.sBillToAdd5 = sBillToAdd5;
}

public
void setBillToAdd6(string sBillToAdd6){
this.sBillToAdd6 = sBillToAdd6;
}

public
void setBillToZipCode( string sBillToZipCode){
this.sBillToZipCode = sBillToZipCode;
}

public
void setAttention(string sattention){
this.sattention = sattention;
}

public
void setTerms(string sterms){
this.sterms = sterms;
}

public
void setShipVia(string shipVia){
this.shipVia = shipVia;
}

public
void setPO(string spO){
this.spO = spO;
}

public
void setQuote(int iquote){
this.iquote = iquote;
}

public
void setCurrency(string scurrency){
this.scurrency = scurrency;
}

public
void setSalesPerson(string salesPerson){
this.salesPerson = salesPerson;
}

public
void setComPercent(double dcomPercent){
this.dcomPercent = dcomPercent;
}

public
void setComRate(double dcomRate){
this.dcomRate = dcomRate;
}

public
void setDateRequest(DateTime dateRequest){
this.dateRequest = dateRequest;
}

public
void setDatePromise(DateTime datePromise){
this.datePromise = datePromise;
}

public
void setDateShip(DateTime dateShip){
this.dateShip = dateShip;
}	

public
void setDateConfirm(DateTime dateConfirm){
this.dateConfirm = dateConfirm;
}	

public
void setDateCancel(DateTime dateCancel){
this.dateCancel = dateCancel;
}	

public
void setProdDate(DateTime prodDate){
this.prodDate = prodDate;
}	


public
void setTerritory(string sterritory){
this.sterritory = sterritory;
}

public
void setHoldStatus(string sholdStatus){
this.sholdStatus = sholdStatus;
}

public
void setShipComplete(string shipComplete){
this.shipComplete = shipComplete;
}

public
void setOrderTotal(double dorderTotal){
this.dorderTotal = dorderTotal;
}

public
void setOrderNet(double dorderNet){
this.dorderNet = dorderNet;
}

public
void setTax1Total(double dtax1Total){
this.dtax1Total = dtax1Total;
}

public
void setTax2Total(double dtax2Total){
this.dtax2Total = dtax2Total;
}

public
void setTax3Total(double dtax3Total){
this.dtax3Total = dtax3Total;
}

public
void setDiscountTot(double discountTot){
this.discountTot = discountTot;
}

public
void setCommissTot(double dcommissTot){
this.dcommissTot = dcommissTot;
}

public
void setRoyaltyTot(double droyaltyTot){
this.droyaltyTot = droyaltyTot;
}

public
void setSynchronized(string synchronized){
this.synchronized = synchronized;
}

public void setOrgOrderType(string sorgOrderType){
	this.sorgOrderType = sorgOrderType;
}

public void setRetailProductType(string sretailProductType){
	this.sretailProductType = sretailProductType;
}

	

public void setShipToNum(string shipToNum)
{
	this.shipToNum = shipToNum;
}

public string getShipToNum()
{
	return shipToNum;
}

public string getSentToCMS()
{
	return sentToCMS;
}
public string getSentUser()
{
	return sentUser;
}
public DateTime getSentDateTime()
{
	return sentDateTime;
}
	
public void setErpOrdNum(string serpOrdNum)
{
	this.serpOrdNum = serpOrdNum;
}
	
#if OE_SYNC
public 
XmlDocument toXml()
{	
	string			sxml;
	XmlDocument		xmlDoc = new XmlDocument();
	XmlElement		xmlElement = xmlDoc.DocumentElement;
	XmlAttribute	xmlAttribute=null;
	OrderDtl		orderDtl=null;
						
	try
	{				
		sxml = "<" + getXmlHeader() + "></" + getXmlHeader() + ">";
		xmlDoc.LoadXml(sxml); 	

		
		xmlAttribute = xmlDoc.CreateAttribute(FieldH_ID);
		xmlAttribute.Value = this.id.ToString();
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_Db);
		xmlAttribute.Value =  Converter.fixString(this.sdb);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_Company);
		xmlAttribute.Value =  Converter.fixString(this.scompany);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_Plant);
		xmlAttribute.Value =  Converter.fixString(this.splant);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);


		xmlAttribute = xmlDoc.CreateAttribute(FieldH_OrderNum);
		xmlAttribute.Value = this.iorderNum.ToString();
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_OrderOrg);		
		xmlAttribute.Value = Converter.fixString(this.sorgId);		
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_OrderDate);
		xmlAttribute.Value =DateUtil.getCompleteDateRepresentation(this.orderDate, DateUtil.MMDDYYYY);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_OrderStatus);
		xmlAttribute.Value = Converter.fixString(this.sorderSatus);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_DistributionLoc);
		xmlAttribute.Value = Converter.fixString(this.sdistributionLoc);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_OrderType);
		xmlAttribute.Value = Converter.fixString(this.sorderType);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_BillToNum);
		xmlAttribute.Value = Converter.fixString(this.sbillToNum);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_BillToName);
		xmlAttribute.Value = Converter.fixString(this.sbillToName);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_BillToAdd1);
		xmlAttribute.Value = Converter.fixString(this.sBillToAdd1);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_BillToAdd2);
		xmlAttribute.Value = Converter.fixString(this.sBillToAdd2);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_BillToAdd3);
		xmlAttribute.Value = Converter.fixString(this.sBillToAdd3);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_BillToAdd4);
		xmlAttribute.Value = Converter.fixString(this.sBillToAdd4);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_BillToAdd5);
		xmlAttribute.Value = Converter.fixString(this.sBillToAdd5);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_BillToAdd6);
		xmlAttribute.Value = Converter.fixString(this.sBillToAdd6);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);
		
		xmlAttribute = xmlDoc.CreateAttribute(FieldH_BillToPostZip);
		xmlAttribute.Value = Converter.fixString(this.sBillToZipCode);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);
		
		xmlAttribute = xmlDoc.CreateAttribute(FieldH_Attention);
		xmlAttribute.Value = Converter.fixString(this.sattention);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_Terms);
		xmlAttribute.Value = Converter.fixString(this.sterms);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_ShipVia);
		xmlAttribute.Value = Converter.fixString(this.shipVia);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_PO);
		xmlAttribute.Value = Converter.fixString(this.spO);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_Quote);
		xmlAttribute.Value = this.iquote.ToString();
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_Currency);
		xmlAttribute.Value = Converter.fixString(this.scurrency);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_SalesPerson);
		xmlAttribute.Value = Converter.fixString(this.salesPerson);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_ComPercent);
		xmlAttribute.Value = NumberUtil.toString(this.dcomPercent);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_ComRate);
		xmlAttribute.Value = NumberUtil.toString(this.dcomRate);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);
			
		xmlAttribute = xmlDoc.CreateAttribute(FieldH_DateRequest);
		xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(this.dateRequest, DateUtil.MMDDYYYY);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_DatePromise);
		xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(this.datePromise, DateUtil.MMDDYYYY);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_DateShip);
		xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(this.dateShip, DateUtil.MMDDYYYY);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_DateConfirm);
		xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(this.dateConfirm, DateUtil.MMDDYYYY);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_DateCancel);
		xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(this.dateCancel, DateUtil.MMDDYYYY);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_ProdDate);
		xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(this.prodDate, DateUtil.MMDDYYYY);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_Territory);
		xmlAttribute.Value = Converter.fixString(this.sterritory);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_HoldStatus);
		xmlAttribute.Value = Converter.fixString(this.sholdStatus);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_ShipComplete);
		xmlAttribute.Value = Converter.fixString(this.shipComplete);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_OrderTotal);
		xmlAttribute.Value = NumberUtil.toString(this.dorderTotal);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_OrderNet);
		xmlAttribute.Value = NumberUtil.toString(this.dorderNet);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_Tax1Total);
		xmlAttribute.Value = NumberUtil.toString(this.dtax1Total);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_Tax2Total);
		xmlAttribute.Value = NumberUtil.toString(this.dtax2Total);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_Tax3Total);
		xmlAttribute.Value = NumberUtil.toString(this.dtax3Total);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_DiscountTot);
		xmlAttribute.Value = NumberUtil.toString(this.discountTot);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_CommissTot);
		xmlAttribute.Value = NumberUtil.toString(this.dcommissTot);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_RoyaltyTot);
		xmlAttribute.Value = NumberUtil.toString(this.droyaltyTot);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_Synchronized);
		xmlAttribute.Value = Converter.fixString(this.synchronized);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);
		
		xmlAttribute = xmlDoc.CreateAttribute(FieldH_RetailProductType);
		xmlAttribute.Value = Converter.fixString(this.sretailProductType);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);		

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_SentToCMS);
		xmlAttribute.Value = Converter.fixString(this.sentToCMS);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_SentUser);
		xmlAttribute.Value = Converter.fixString(this.sentUser);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_SentDateTime);
		xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(this.sentDateTime, DateUtil.MMDDYYYY);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FieldH_ErpOrdNum);
		xmlAttribute.Value = Converter.fixString(this.serpOrdNum);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);										
							
		for (int i=0; i < this.arrayOrderLines.Count;i++)
		{
			orderDtl = getLineByIndex(i);

			XmlNode root = xmlDoc.DocumentElement;			

			xmlDoc = orderDtl.toXml(xmlDoc);	
		}			

		xmlDoc = noteList.toXml(xmlDoc);
	}
	catch (XmlException ex)
	{
		xmlDoc=null;//error
		throw new NujitException("Error in class Order  <toXml> : " + ex.Message);		
	}
		
	return xmlDoc;
}

public 
bool Parse(XmlDocument xmlDocument)
{
	bool	bresult=false;

	try
	{		
		XmlAttributeCollection xmlAttribCollection = xmlDocument.DocumentElement.Attributes;
		//read all of the attribute
		for (int i=0; i < xmlAttribCollection.Count; i++)
		{
			bresult=true;

			if (xmlAttribCollection[i].Name.Equals(FieldH_ID))
				this.id = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_Db))
				this.sdb = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_Company))
				this.scompany = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_Plant))
				this.splant = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_OrderNum))
				this.iorderNum = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_OrderOrg))
				this.sorgId = xmlAttribCollection[i].Value;	
			else if (xmlAttribCollection[i].Name.Equals(FieldH_OrderDate))
				this.orderDate = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_OrderStatus))
				this.sorderSatus = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_DistributionLoc))
				this.sdistributionLoc = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_OrderType))
				this.sorderType = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_BillToNum))
				this.sbillToNum = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_BillToName))
				this.sbillToName = xmlAttribCollection[i].Value;				
			else if (xmlAttribCollection[i].Name.Equals(FieldH_BillToAdd1))
				this.sBillToAdd1 = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_BillToAdd2))
				this.sBillToAdd2 = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_BillToAdd3))
				this.sBillToAdd3 = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_BillToAdd4))
				this.sBillToAdd4 = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_BillToAdd5))
				this.sBillToAdd5 = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_BillToAdd6))
				this.sBillToAdd6 = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_BillToPostZip))
				this.sBillToZipCode = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_Attention))
				this.sattention = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_Terms))
				this.sterms = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_ShipVia))
				this.shipVia = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_PO))
				this.spO = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_Quote))
				this.iquote = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_Currency))
				this.scurrency = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_SalesPerson))
				this.salesPerson = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_ComPercent))
				this.dcomPercent = double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_ComRate))
				this.dcomRate = double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_DateRequest))
				this.dateRequest = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_DatePromise))
				this.datePromise = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_DateShip))
				this.dateShip = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_DateConfirm))
				this.dateConfirm = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_DateCancel))
				this.dateCancel = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_ProdDate))
				this.prodDate = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_Territory))
				this.sterritory = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_HoldStatus))
				this.sholdStatus = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_ShipComplete))
				this.shipComplete = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_OrderTotal))
				this.dorderTotal = double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_OrderNet))
				this.dorderNet = double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_Tax1Total))
				this.dtax1Total = double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_Tax2Total))
				this.dtax2Total = double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_Tax3Total))
				this.dtax3Total = double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_DiscountTot))
				this.discountTot = double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_CommissTot))
				this.dcommissTot = double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_RoyaltyTot))
				this.droyaltyTot = double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldH_Synchronized))
				this.synchronized = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_RetailProductType))
				this.sretailProductType = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldH_SentToCMS))
				this.sentToCMS = xmlAttribCollection[i].Value;			
			else if (xmlAttribCollection[i].Name.Equals(FieldH_SentUser))
				this.sentUser = xmlAttribCollection[i].Value;			
			else if (xmlAttribCollection[i].Name.Equals(FieldH_SentDateTime))
				this.sentDateTime = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);		
			else if (xmlAttribCollection[i].Name.Equals(FieldH_ErpOrdNum))
				this.serpOrdNum = xmlAttribCollection[i].Value;				
		}
	}
	catch (XmlException ex)
	{
		bresult=false;
		throw new NujitException("Error in class Order  <toXml> : " + ex.Message);		
	}   

	return bresult;
}


public
string getXmlHeader()
{
	return "ORDER";
}	
#endif

public 
void addLine(OrderDtl orderDtl)
{
	this.arrayOrderLines.Add(orderDtl);	
}	

public 
void addNote(Note note)
{
	noteList.addNote(note);	
}


public 
OrderDtl getLineByIndex(int index)
{
	OrderDtl orderDtl=null;

	if (index < arrayOrderLines.Count)
		orderDtl= (OrderDtl)arrayOrderLines[index];

	return orderDtl;	
}

public 
Note getNoteByIndex(int index)
{
	return noteList.getNoteByIndex(index);
}

public void addNewLine (OrderDtl orderDtl)
{
	if (arrayOrderLines.Count == 0)
		orderDtl.setItemNum (1);
	else
		orderDtl.setItemNum(((OrderDtl)arrayOrderLines[arrayOrderLines.Count-1]).getItemNum()+1);
	arrayOrderLines.Add (orderDtl);
}

public void addNewNote (Note note)
{	
	noteList.addNewNote(note);	
}
public 
Note createNote(string snote)
{
	Note note= new Note();

	note.setType(Constants.NOTE_TYPE_ORDER);
	note.setKey1(this.getId());
	note.setKey2(int.MinValue);
	note.setKey3(int.MinValue);

	return note;
}

public OrderDtl getLineByID (int itemNum)
{
	IEnumerator enu = arrayOrderLines.GetEnumerator();
	while (enu.MoveNext())
	{
		if (itemNum.Equals(((OrderDtl)enu.Current).getItemNum()))
			return (OrderDtl)enu.Current;
	}
	return null;
}

public Note getNoteByID (int ilineNum)
{
	return noteList.getNoteByID(ilineNum);	
}

public bool removeLineByID (int itemNum)
{
	int i=0;
	bool found = false;
	while ((i<arrayOrderLines.Count) && (!found))
	{
		if (itemNum.Equals(((OrderDtl)arrayOrderLines[i]).getItemNum()))
		{
			found = true;
			arrayOrderLines.RemoveAt(i);
		}
		i++;
	}
	return found;
}

public bool removeNoteByID (int itemNum)
{
	return noteList.removeNoteByID(itemNum);	
}

public 
void removeAllNotes()
{
	noteList.removeAllNotes();		
}	
	
public
IEnumerator getLineEnumerator()
{
	return arrayOrderLines.GetEnumerator();
}

public
IEnumerator getNoteEnumerator()
{
	return noteList.getNoteEnumerator();
}
	
public 
OrderDtlRel getLineRelByIndex(int idetailIndex, int idetailRelIndex)
{
	OrderDtl orderDtl=null;
	OrderDtlRel orderDtlRel = null;

	//check detail index
	if (idetailIndex < arrayOrderLines.Count)
	{
		orderDtl = (OrderDtl)arrayOrderLines[idetailIndex];

		//check detail rel index
		if (orderDtl != null && idetailRelIndex < orderDtl.getCountLines())
		{
			orderDtlRel = orderDtl.getDltRelByIndex(idetailRelIndex);
		}
	}
	return (orderDtlRel);	
}
public 
bool removeLineByIndex(int index)
{
	bool	bresult=false;
	
	if (index < arrayOrderLines.Count)
	{
		arrayOrderLines.RemoveAt(index);
		bresult=true;
	}	

	return bresult;	
}	
public 
int getCountLines()
{
	return arrayOrderLines.Count;
}
public 
int getCountNotes()
{
	return noteList.getCountNotes();
}	

public void updateOrderDetailRel(OrderDtlRel orderDtlRelNew)
{
	OrderDtl		orderDtl=null;
	OrderDtlRel		orderDtlRel=null;

	//change the orderDtlRel to the new values
	for (int i=0; i < this.arrayOrderLines.Count;i++)
	{
		orderDtl = getLineByIndex(i);
		
		for (int j=0; j < orderDtl.getCountLines();j++)
		{
			orderDtlRel = orderDtl.getDltRelByIndex(j);
			
			orderDtlRel.setShipToNum(orderDtlRelNew.getShipToNum());	//id
			orderDtlRel.setShipToName(orderDtlRelNew.getShipToName());//name

			orderDtlRel.setPlant(orderDtlRelNew.getPlant());		//plt
			orderDtlRel.setPhoneNum(orderDtlRelNew.getPhoneNum());//phone		

			//address	
			orderDtlRel.setShipToAdd1(orderDtlRelNew.getShipToAdd1());
			orderDtlRel.setShipToAdd2(orderDtlRelNew.getShipToAdd2());
			orderDtlRel.setShipToAdd3(orderDtlRelNew.getShipToAdd3());	
		}
	}
}	

public 
bool addNewLine(out OrderDtl		orderDtl,
				out OrderDtlRel		orderDtlRel,
				Product				product,
#if !PROV
				ProductActCost		productActCost,
#endif
				Person				billPerson,
				Person				shipPerson,
				double				dprice,
				double				dquantity)
{
	bool bresult=true;

	orderDtl = new OrderDtl();

	orderDtl.setHId(this.getId());											//id header
	orderDtl.setProdID(product.getProdID());								//id product
	orderDtl.setProdDescription(product.getDes1());							//product description
	orderDtl.setSeq(product.getSeqLast());									//seq
	orderDtl.setQtyOrdUom(product.getStdPackUnit());						//unit UOM
	orderDtl.setQtyPackSize(decimal.ToDouble(product.getStdPackSize()));	//pack size
	//costo
#if !PROV
	if (productActCost!= null)		orderDtl.setCost(decimal.ToDouble(productActCost.getCost()));
	else							orderDtl.setCost(0);
#endif

	orderDtl.setUnitPrice(dprice);							//prize
	orderDtl.setQtyOrdSum(dquantity);						//quantity
	orderDtl.setDateAdded(DateTime.Now);					//date							
	orderDtl.setOrderNum(this.getOrderNum());
	orderDtl.setOrgId(this.getOrgId());						//original order num
	orderDtl.setOrgItemNum(orderDtl.getItemNum().ToString());//original item menu

	orderDtl.setItemNetTotal(dprice * dquantity);			//total net

	orderDtl.setCustPO(this.getPO());						//cust purchase order
	
	addNewLine(orderDtl);//add detail and setItemNum

	orderDtlRel = orderDtl.createDtlRel(billPerson,shipPerson);//set detail rel	
	orderDtl.addNewDtlRel(orderDtlRel);//add detail rel and setItemNumRel

	return bresult;
}	

public 
OrderDtl checkIfProductInTheOrder(string sprodId)
{	
	OrderDtl		orderDtl=null;
	bool			bexists=false;
		
	//search if the product exists
	for (int i=0; i < this.arrayOrderLines.Count && !bexists;i++)
	{
		orderDtl = getLineByIndex(i);
		if (orderDtl.getProdID().Equals(sprodId))
			bexists=true;
	}		

	if (bexists)
		return orderDtl;

	return null;
}	

public void recalculate()
{
	IEnumerator enu = arrayOrderLines.GetEnumerator();
	dorderTotal = 0;
	dorderNet = 0;
	discountTot = 0;
	while (enu.MoveNext())
	{
		OrderDtl orderDtl = (OrderDtl)enu.Current;
		orderDtl.recalculate();
		dorderTotal += orderDtl.getUnitPrice() * orderDtl.getQtyOrdSum() - orderDtl.getTotalDiscounts();
		discountTot += orderDtl.getTotalDiscounts();
		dorderNet += orderDtl.getItemNetTotal();
	}
}

public void setPerson(Person person)
{
	//bill person
	this.setBillToNum(person.getId());	
	this.setBillToName(person.getName());
	this.setBillToAdd1(person.getAddress1());
	this.setBillToAdd2(person.getAddress2());
	this.setBillToAdd3(person.getAddress3());
	this.setBillToAdd4(person.getAddress4());
	this.setBillToAdd5(person.getAddress5());
	this.setBillToAdd6(person.getAddress6());	
	this.setBillToZipCode(person.getZipCode());	
}

public void getPerson(ref Person person)
{
	//bill person	
	person.setName(this.getBillToName());
	person.setAddress1(this.getBillToAdd1());
	person.setAddress2(this.getBillToAdd2());
	person.setAddress3(this.getBillToAdd3());
	person.setAddress4(this.getBillToAdd4());
	person.setAddress5(this.getBillToAdd5());
	person.setAddress6(this.getBillToAdd6());	
	person.setZipCode(this.getBillToZipCode());	
}


} // class

} // namespace
