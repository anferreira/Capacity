using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{


public 
class ProdPrice : 
#if OE_SYNC
	Serializable{
#else
	MarshalByRefObject{
#endif
	
private int id;
private string custClassID;
private string product;
private string pricingUnit;
private string currency;
private decimal price;
private string active;
private DateTime effecFrmDate;
private DateTime effecToDate;
private DateTime lastChgDate;
private string lastChgUser;
private	decimal	volume;
private string	discode; 
private string type;

#if OE_SYNC
public const string ID				= "f1";
public const string CUST_ID			= "f2";
public const string PRODUCT			= "f3";
public const string PRICING_UNIT	= "f4";
public const string CURRENCY		= "f5";
public const string PRICE			= "f6";
public const string ACTIVE			= "f7";
public const string EFFECT_FRM_DATE = "f8";
public const string EFFECT_TO_DATE	= "f9";
public const string LAST_CHG_DATE	= "f10";
public const string LAST_CHG_USER	= "f11";
public const string VOLUME			= "f12";
public const string DISC_CODE		= "f13";
public const string TYPE			= "f14";
#endif

public 
ProdPrice(){
	this.id = 0;
	this.custClassID = "";
	this.product = "";
	this.pricingUnit = "";
	this.currency = "";
	this.price = 0;
	this.active = "";
	this.effecFrmDate = DateTime.Today;
	this.effecToDate = DateTime.Today;
	this.lastChgDate = DateTime.Today;
	this.lastChgUser = "";
	this.volume=0;
	this.discode="";
	this.type="";
}

public
void setId(int id){
	this.id = id;
}

public
void setCustClassID(string custClassID){
	this.custClassID = custClassID;
}

public
void setProduct(string product){
	this.product = product;
}

public
void setPricingUnit(string pricingUnit){
	this.pricingUnit = pricingUnit;
}

public
void setCurrency(string currency){
	this.currency = currency;
}

public
void setPrice(decimal price){
	this.price = price;
}

public
void setActive(string active){
	this.active = active;
}

public
void setEffecFrmDate(DateTime effecFrmDate){
	this.effecFrmDate = effecFrmDate;
}

public
void setEffecToDate(DateTime effecToDate){
	this.effecToDate = effecToDate;
}

public
void setLastChgDate(DateTime lastChgDate){
	this.lastChgDate = lastChgDate;
}

public
void setLastChgUser(string lastChgUser){
	this.lastChgUser = lastChgUser;
}

public
void setVolume(decimal volume){
	this.volume = volume;
}
public
void setDiscode(string discode){
	this.discode = discode;
}

public 
void setType(string type){
	this.type = type;
}

public
int getId(){
	return id;
}

public
string getCustClassID(){
	return custClassID;
}

public
string getProduct(){
	return product;
}

public
string getPricingUnit(){
	return pricingUnit;
}

public
string getCurrency(){
	return currency;
}

public
decimal getPrice(){
	return price;
}

public
string getActive(){
	return active;
}

public
DateTime getEffecFrmDate(){
	return effecFrmDate;
}

public
DateTime getEffecToDate(){
	return effecToDate;
}

public
DateTime getLastChgDate(){
	return lastChgDate;
}

public
decimal getVolume(){
	return volume;
}
public
string getDiscode(){
	return discode;
}

public
string getLastChgUser(){
	return lastChgUser;
}

public 
string getType(){
	return type;
}

#if OE_SYNC
public 
XmlDocument toXml(){	
	string			sxml;
	XmlDocument		xmlDoc = new XmlDocument();
	XmlElement		xmlElement = xmlDoc.DocumentElement;
	XmlAttribute	xmlAttribute=null;
					
	try{				
		sxml = "<" + getXmlHeader() + "></" + getXmlHeader() + ">";
		xmlDoc.LoadXml(sxml); 	

		xmlAttribute = xmlDoc.CreateAttribute(ID);
		xmlAttribute.Value = id.ToString();
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(CUST_ID);
		xmlAttribute.Value = custClassID;
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(PRODUCT);
		xmlAttribute.Value = product;
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(PRICING_UNIT);
		xmlAttribute.Value = pricingUnit;
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(CURRENCY);
		xmlAttribute.Value = currency;
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(PRICE);
		xmlAttribute.Value = price.ToString();
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(ACTIVE);
		xmlAttribute.Value = active;
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);
	
		xmlAttribute = xmlDoc.CreateAttribute(EFFECT_FRM_DATE);
		xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(effecFrmDate, DateUtil.MMDDYYYY);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);
	
		xmlAttribute = xmlDoc.CreateAttribute(EFFECT_TO_DATE);
		xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(effecToDate, DateUtil.MMDDYYYY);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);
	
		xmlAttribute = xmlDoc.CreateAttribute(LAST_CHG_DATE);
		xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(lastChgDate, DateUtil.MMDDYYYY);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);
	
		xmlAttribute = xmlDoc.CreateAttribute(LAST_CHG_USER);
		xmlAttribute.Value = lastChgUser;
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(VOLUME);
		xmlAttribute.Value = NumberUtil.toString(volume);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(DISC_CODE);
		xmlAttribute.Value = Converter.fixString(discode);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);		

		xmlAttribute = xmlDoc.CreateAttribute(TYPE);
		xmlAttribute.Value = Converter.fixString(type);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);				
	
	}catch (XmlException ex){
		xmlDoc=null;//error
		throw new NujitException("Error in class ProdPrice  <toXml> : " + ex.Message);		
	}
			
	return xmlDoc;
}


public 
bool Parse(XmlDocument xmlDocument){
	bool	bresult=false;

	try{		
		XmlAttributeCollection xmlAttribCollection = xmlDocument.DocumentElement.Attributes;
		//read all of the attribute
		for (int i=0; i < xmlAttribCollection.Count; i++){
			bresult=true;

			if (xmlAttribCollection[i].Name.Equals(ID))
				this.id = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(CUST_ID))
				this.custClassID = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(PRODUCT))
				this.product = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(PRICING_UNIT))
				this.pricingUnit = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(CURRENCY))
				this.currency = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(PRICE))
				this.price = decimal.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(ACTIVE))
				this.active = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(EFFECT_FRM_DATE))
				this.effecFrmDate = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);	           
			else if (xmlAttribCollection[i].Name.Equals(EFFECT_TO_DATE))
				this.effecToDate = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);	           
			else if (xmlAttribCollection[i].Name.Equals(LAST_CHG_DATE))
				this.lastChgDate = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);	           
			else if (xmlAttribCollection[i].Name.Equals(LAST_CHG_USER))
				this.lastChgUser = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(VOLUME))
				this.volume = decimal.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(DISC_CODE))
				this.discode = xmlAttribCollection[i].Value;			
			else if (xmlAttribCollection[i].Name.Equals(TYPE))
				this.type = xmlAttribCollection[i].Value;						
		}
	}catch (XmlException ex){
		bresult=false;
		throw new NujitException("Error in class ProdPrice  <toXml> : " + ex.Message);		
	}   

	return bresult;
}

public
string getXmlHeader(){
	return "PRICE";
}
#endif

} // class

} // namespace
