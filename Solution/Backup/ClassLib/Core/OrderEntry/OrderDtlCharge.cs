using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Nujit.NujitERP.ClassLib.Util;

using System.Collections;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core{


public 
class OrderDtlCharge :
#if OE_SYNC
	Serializable{
#else
	MarshalByRefObject{
#endif

		
	int ihId;
	int id;
	string sDb;
	int iorderNum;
	int itemNum;
	int itemChgNum;
	string schargeCode;
	string schargeDesc;	
	string schargeType;
	string schargeTypeSub;
	string sbaseNet;
	string sfixedUnit;
	string saleCOS;
	double damount;
	double dmaxAmount;
	string sbeforeTax;
	string sbeforeFreight;
	string sbeforeDiscount;
	double dpercent;
	double dextension;
	string sapplytoCust;
	string sapplytoSupplier;
	long   lGLAccountNum;
	string sonSalePaidInv;
	string spaid;
	string sreceived;

#if OE_SYNC
	public const string  FieldODC_HID				="f1";
	public const string  FieldODC_ID				="f2";
	public const string  FieldODC_Db				="f3";
	public const string  FieldODC_OrderNum			="f4";
	public const string  FieldODC_ItemNum			="f5";
	public const string  FieldODC_ItemChgNum		="f6";
	public const string  FieldODC_ChargeCode		="f7";
	public const string  FieldODC_ChargeDesc		="f8";	
	public const string  FieldODC_ChargeType		="f9";
	public const string  FieldODC_ChargeTypeSub		="f10";
	public const string  FieldODC_BaseNet			="f11";
	public const string  FieldODC_FixedUnit			="f12";
	public const string  FieldODC_SaleCOS			="f13";
	public const string  FieldODC_Amount			="f14";
	public const string  FieldODC_MaxAmount			="f15";
	public const string  FieldODC_BeforeTax			="f16";
	public const string  FieldODC_BeforeFreight		="f17";
	public const string  FieldODC_BeforeDiscount	="f18";
	public const string  FieldODC_Percent			="f19";
	public const string  FieldODC_Extension			="f20";
	public const string  FieldODC_ApplytoCust		="f21";
	public const string  FieldODC_ApplytoSupplier	="f22";
	public const string  FieldODC_GLAccountNum		="f23";
	public const string  FieldODC_OnSalePaidInv		="f24";
	public const string  FieldODC_Paid				="f25";
	public const string  FieldODC_Received			="f26";
#endif

	public OrderDtlCharge ()
	{
		id = 0;
		sDb = "db";
		ihId = 0;
		itemNum = 0;
		itemChgNum = 0;
		iorderNum = 0;
		schargeCode = "";
		schargeDesc = "";	
		schargeType = "";
		schargeTypeSub = "";
		sbaseNet = "";
		sfixedUnit = "";
		saleCOS = "";
		damount = 0;
		dmaxAmount = 0;
		sbeforeTax = "";
		sbeforeFreight = "";
		sbeforeDiscount = "";
		dpercent = 0;
		dextension = 0;
		sapplytoCust = "";
		sapplytoSupplier = "";
		lGLAccountNum = 0;
		sonSalePaidInv = "";
		spaid = "";
		sreceived = "";
	}
	
public void setHId (int ihId)
{
	this.ihId =ihId;
}

public void setId (int id){
	this.id =id;
}

public void setDb (string sDb){
	this.sDb = sDb;
}

public void setOrderNum (	int iorderNum){
	this.iorderNum = iorderNum;
}

public void setItemNum (int itemNum){
	this.itemNum = itemNum;
}

public void setItemChgNum (int itemChgNum){
	this.itemChgNum = itemChgNum;
}

public void setChargeCode (string schargeCode){
	this.schargeCode = schargeCode;
}

public void setChargeDesc (string schargeDesc){
	this.schargeDesc = schargeDesc;
}

public void setChargeType(string schargeType){
	this.schargeType = schargeType;
}

public void setChargeTypeSub(string schargeTypeSub){
	this.schargeTypeSub = schargeTypeSub;
}	

public void setBaseNet (string sbaseNet){
	this.sbaseNet = sbaseNet;
}

public void setFixedUnit (string sfixedUnit){
	this.sfixedUnit = sfixedUnit;
}

public void setSaleCOS (string	saleCOS){
	this.saleCOS = saleCOS;
}

public void setAmount (double damount){
	this.damount = damount;
}

public void setMaxAmount (double dmaxAmount){
	this.dmaxAmount = dmaxAmount;
}

public void setBeforeTax (string sbeforeTax){
	this.sbeforeTax = sbeforeTax;
}

public void setBeforeFreight (string sbeforeFreight){
	this.sbeforeFreight = sbeforeFreight;
}

public void setBeforeDiscount (string sbeforeDiscount){
	this.sbeforeDiscount = sbeforeDiscount;
}

public void setPercent (double dpercent){
	this.dpercent = dpercent;
}

public void setExtension (double dextension){
	this.dextension = dextension;
}

public void setApplytoCust (string sapplytoCust){
	this.sapplytoCust = sapplytoCust;
}

public void setApplytoSupplier (string sapplytoSupplier){
	this.sapplytoSupplier = sapplytoSupplier;
}

public void setGLAccountNum (long lGLAccountNum){
	this.lGLAccountNum = lGLAccountNum;
}

public void setOnSalePaidInv (string sonSalePaidInv){
	this.sonSalePaidInv = sonSalePaidInv;
}

public void setPaid (string spaid){
	this.spaid = spaid;
}

public void setReceived (string sreceived){
	this.sreceived = sreceived;
}

public int getHId (){
	return ihId;
}
	
public int getId(){
	return id;
}
public string getDb(){
	return sDb;
}
public int getOrderNum(){
	return iorderNum;
}
public int getItemNum(){
	return itemNum;
}
public int getItemChgNum(){
	return itemChgNum;
}
public string getChargeCode(){
	return schargeCode;
}
public string getChargeDesc(){
	return schargeDesc;
}

public string getChargeType(){
	return schargeType;
}

public string getChargeTypeSub(){
	return schargeTypeSub;
}	

public string getBaseNet(){
	return sbaseNet;
}
public string getFixedUnit (){
	return this.sfixedUnit;
}

public
string	getSaleCOS(){
	return saleCOS;
}
public double getAmount(){
	return damount;
}
public double getMaxAmount(){
	return dmaxAmount;
}
public string getBeforeTax(){
	return sbeforeTax;
}
public string getBeforeFreight(){
	return sbeforeFreight;
}
public string getBeforeDiscount(){
	return sbeforeDiscount;
}
public double getPercent(){
	return dpercent;
}
public double getExtension(){
	return dextension;
}

public string getApplytoCust(){
	return sapplytoCust;
}
public string getApplytoSupplier(){
	return sapplytoSupplier;
}
public long getGLAccountNum(){
	return lGLAccountNum;
}
public string getOnSalePaidInv(){
	return sonSalePaidInv;
}
public string getPaid(){
	return spaid;
}
public string getReceived(){
	return sreceived;
}

#if OE_SYNC
public 
XmlDocument toXml()
{	
	string			sxml;
	XmlDocument		xmlDoc = new XmlDocument();
	XmlElement		xmlElement = xmlDoc.DocumentElement;
	//XmlAttribute	xmlAttribute=null;
	
	try
	{				
		sxml = "<" + getXmlHeader() + "></" + getXmlHeader() + ">";
		xmlDoc.LoadXml(sxml); 	

	}
	catch (XmlException ex)
	{
		xmlDoc=null;//error
		throw new NujitException("Error in class OrderDtlCharge <toXml> : " + ex.Message);		
	}
	
	return xmlDoc;
}

public 
XmlDocument toXml(XmlDocument xmlDoc)
{	
	try
	{							
			XmlElement		xmlElement = xmlDoc.DocumentElement;
			XmlAttribute	xmlAttribute=null;
			XmlNode root = xmlDoc.DocumentElement;			
	
			//Create a new node.
			xmlElement = xmlDoc.CreateElement(this.getXmlHeader());
							
			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_HID);
			xmlAttribute.Value = this.getHId().ToString();
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_ID);
			xmlAttribute.Value = this.getId().ToString();
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_Db);
			xmlAttribute.Value = Converter.fixString(this.getDb());
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_OrderNum);
			xmlAttribute.Value = this.getOrderNum().ToString();
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_ItemNum);
			xmlAttribute.Value = this.getItemNum().ToString();
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_ItemChgNum);
			xmlAttribute.Value = this.getItemChgNum().ToString();
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_ChargeCode);
			xmlAttribute.Value = Converter.fixString(this.getChargeCode());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_ChargeDesc);
			xmlAttribute.Value =  Converter.fixString(this.getChargeDesc());
			xmlElement.SetAttributeNode(xmlAttribute);		
		
			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_ChargeType);
			xmlAttribute.Value = Converter.fixString(this.getChargeType());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_ChargeTypeSub);
			xmlAttribute.Value = Converter.fixString(this.getChargeTypeSub());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_BaseNet);
			xmlAttribute.Value = Converter.fixString(this.getBaseNet());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_FixedUnit);
			xmlAttribute.Value = Converter.fixString(this.getFixedUnit());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_SaleCOS);
			xmlAttribute.Value = Converter.fixString(this.getSaleCOS());
			xmlElement.SetAttributeNode(xmlAttribute);				

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_Amount);
			xmlAttribute.Value = NumberUtil.toString(this.getAmount());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_MaxAmount);
			xmlAttribute.Value = NumberUtil.toString(this.getMaxAmount());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_BeforeTax);
			xmlAttribute.Value = Converter.fixString(this.getBeforeTax());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_BeforeFreight);
			xmlAttribute.Value = Converter.fixString(this.getBeforeFreight());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_BeforeDiscount);
			xmlAttribute.Value = Converter.fixString(this.getBeforeDiscount());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_Percent);
			xmlAttribute.Value = NumberUtil.toString(this.getPercent());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_Extension);
			xmlAttribute.Value = NumberUtil.toString(this.getExtension());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_ApplytoCust);
			xmlAttribute.Value = Converter.fixString(this.getApplytoCust());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_ApplytoSupplier);
			xmlAttribute.Value = Converter.fixString(this.getApplytoSupplier());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_GLAccountNum);
			xmlAttribute.Value = this.getGLAccountNum().ToString();
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_OnSalePaidInv);
			xmlAttribute.Value = Converter.fixString(this.getOnSalePaidInv());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_Paid);
			xmlAttribute.Value = Converter.fixString(this.getPaid());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldODC_Received);
			xmlAttribute.Value = Converter.fixString(this.getReceived());
			xmlElement.SetAttributeNode(xmlAttribute);		
									
			//Add the node to the document.
			root.AppendChild(xmlElement);			
	}
	catch (XmlException ex)
	{		
		throw new NujitException("Error in class OrderDtl  <toXml> : " + ex.Message);		
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
						
			if (xmlAttribCollection[i].Name.Equals(FieldODC_HID))
				this.ihId = int.Parse(xmlAttribCollection[i].Value);
			if (xmlAttribCollection[i].Name.Equals(FieldODC_ID))
				this.id = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_Db))
				this.sDb = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_OrderNum))
				this.iorderNum = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_ItemNum))
				this.itemNum = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_ItemChgNum))
				this.itemChgNum = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_ChargeCode))
				this.schargeCode = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_ChargeDesc))
				this.schargeDesc = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_ChargeType))
				this.schargeType = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_ChargeTypeSub))
				this.schargeTypeSub = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_BaseNet))
				this.sbaseNet = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_FixedUnit))
				this.sfixedUnit = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_SaleCOS))
				this.saleCOS = xmlAttribCollection[i].Value;				
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_Amount))
				this.damount = double.Parse(xmlAttribCollection[i].Value);			
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_MaxAmount))
				this.dmaxAmount = double.Parse(xmlAttribCollection[i].Value);			
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_BeforeTax))
				this.sbeforeTax = xmlAttribCollection[i].Value;				
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_BeforeFreight))
				this.sbeforeFreight = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_BeforeDiscount))
				this.sbeforeDiscount = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_Percent))
				this.dpercent = double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_Extension))
				this.dextension = double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_ApplytoCust))
				this.sapplytoCust = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_ApplytoSupplier))
				this.sapplytoSupplier = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_GLAccountNum))
				this.lGLAccountNum = long.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_OnSalePaidInv))
				this.sonSalePaidInv = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_Paid))
				this.spaid = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldODC_Received))
				this.sreceived = xmlAttribCollection[i].Value;			
					
		}
	}
	catch (XmlException ex)
	{
		bresult=false;
		throw new NujitException("Error in class OrderDtlCharge  <toXml> : " + ex.Message);		
	}   

	return bresult;
}


public
string getXmlHeader()
{
	return "ORDERDTLCHARGE";
}	
#endif

public static OrderDtlCharge FromDiscount (Discount discount)
{
	OrderDtlCharge orderDtlCharge = new OrderDtlCharge();
	orderDtlCharge.setBaseNet (discount.getBaseNet());
	orderDtlCharge.setAmount (discount.getDiscAmount());
	orderDtlCharge.setChargeCode (discount.getDiscCode());
	orderDtlCharge.setChargeDesc (discount.getDiscDes());
	orderDtlCharge.setPercent (discount.getDiscRate());
	orderDtlCharge.setFixedUnit (discount.getFixedUnit());

	return orderDtlCharge;
}

public OrderDtlCharge clone()
{
	OrderDtlCharge newOrderDtlCharge = new OrderDtlCharge();
	newOrderDtlCharge.ihId = this.ihId;
	newOrderDtlCharge.id = this.id;
	newOrderDtlCharge.sDb = this.sDb;
	newOrderDtlCharge.iorderNum = this.iorderNum;
	newOrderDtlCharge.itemNum = this.itemNum;
	newOrderDtlCharge.itemChgNum = this.itemChgNum;
	newOrderDtlCharge.schargeCode = this.schargeCode;
	newOrderDtlCharge.schargeDesc = this.schargeDesc;	
	newOrderDtlCharge.schargeType = this.schargeType;
	newOrderDtlCharge.schargeTypeSub = this.schargeTypeSub;
	newOrderDtlCharge.sbaseNet = this.sbaseNet;
	newOrderDtlCharge.sfixedUnit = this.sfixedUnit;
	newOrderDtlCharge.saleCOS = this.saleCOS;
	newOrderDtlCharge.damount = this.damount;
	newOrderDtlCharge.dmaxAmount = this.dmaxAmount;
	newOrderDtlCharge.sbeforeTax = this.sbeforeTax;
	newOrderDtlCharge.sbeforeFreight = this.sbeforeFreight;
	newOrderDtlCharge.sbeforeDiscount = this.sbeforeDiscount;
	newOrderDtlCharge.dpercent = this.dpercent;
	newOrderDtlCharge.dextension = this.dextension;
	newOrderDtlCharge.sapplytoCust = this.sapplytoCust;
	newOrderDtlCharge.sapplytoSupplier = this.sapplytoSupplier;
	newOrderDtlCharge.lGLAccountNum = this.lGLAccountNum;
	newOrderDtlCharge.sonSalePaidInv = this.sonSalePaidInv;
	newOrderDtlCharge.spaid = this.spaid;
	newOrderDtlCharge.sreceived = this.sreceived;

	return newOrderDtlCharge;
}

} // class
//
} // namespace
