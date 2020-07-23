using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Nujit.NujitERP.ClassLib.Util;


namespace Nujit.NujitERP.ClassLib.Core{


public 
class Discount : 
#if OE_SYNC
	Serializable{
#else
	MarshalByRefObject{
#endif
	
private int id;
private string sdisCode;
private string sdiscDes;
private double discRate;
private string sdrCr;
private string sbaseNet;
private double discAmount;
private string sfixedUnit;
private string salesCode;
private DateTime DateUpdated;

#if OE_SYNC
public const string DF_ID			= "f1";
public const string DF_DiscCode		= "f2";
public const string DF_DiscDesc		= "f3";
public const string DF_DiscRate		= "f4";
public const string DF_DrCr			= "f5";
public const string DF_BaseNet		= "f6";
public const string DF_DiscAmount	= "f7";
public const string DF_FixedUnit	= "f8";
public const string DF_SalesCode	= "f9";
public const string DF_DateUpdated	= "f10";
#endif

public 
Discount(){
	this.id = 0;
	this.sdisCode = "";
	this.sdiscDes = "";
	this.discRate = 0;
	this.sdrCr = "";
	this.sbaseNet = "";
	this.discAmount = 0;
	this.sfixedUnit = "";
	this.salesCode = "";
	this.DateUpdated = DateTime.Now;
}

public
void setId(int id){
	this.id = id;
}

public
void setDiscCode(string sdisCode){
	this.sdisCode = sdisCode;
}

public
void setDiscDes(string sdiscDes){
	this.sdiscDes = sdiscDes;
}

public
void setDiscRate(double discRate){
	this.discRate = discRate;
}

public
void setDrCr(string sdrCr){
	this.sdrCr = sdrCr;
}

public
void setBaseNet(string sbaseNet){
	this.sbaseNet = sbaseNet;
}


public
void setDiscAmount(double discAmount){
	this.discAmount = discAmount;
}

public
void setFixedUnit(string sfixedUnit){
	this.sfixedUnit = sfixedUnit;
}

public
void setSalesCode(string salesCode){
	this.salesCode = salesCode;
}

public
void setDateUpdated(DateTime DateUpdated){
	this.DateUpdated = DateUpdated;
}


public
int getId(){
	return id;
}

public
string getDiscCode(){
	return sdisCode;
}

public
string getDiscDes(){
	return sdiscDes;
}

public
double getDiscRate(){
	return discRate;
}

public
string getDrCr(){
	return sdrCr;
}

public
string getBaseNet(){
	return sbaseNet;
}

public
double getDiscAmount(){
	return discAmount;
}

public
string getFixedUnit(){
	return sfixedUnit;
}

public
string getSalesCode(){
	return salesCode;
}

public
DateTime getDateUpdated(){
	return DateUpdated;
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

		xmlAttribute = xmlDoc.CreateAttribute(DF_ID);
		xmlAttribute.Value = id.ToString();
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(DF_DiscCode);
		xmlAttribute.Value = Converter.fixString(this.sdisCode);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(DF_DiscDesc);
		xmlAttribute.Value = Converter.fixString(this.sdiscDes);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(DF_DiscRate);
		xmlAttribute.Value = NumberUtil.toString(this.discRate);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(DF_DrCr);
		xmlAttribute.Value = Converter.fixString(this.sdrCr);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(DF_BaseNet);
		xmlAttribute.Value = Converter.fixString(this.sbaseNet);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);
			
		xmlAttribute = xmlDoc.CreateAttribute(DF_DiscAmount);
		xmlAttribute.Value = NumberUtil.toString(this.discAmount);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);
	
		xmlAttribute = xmlDoc.CreateAttribute(DF_FixedUnit);
		xmlAttribute.Value = Converter.fixString(this.sfixedUnit);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);
	
		xmlAttribute = xmlDoc.CreateAttribute(DF_SalesCode);
		xmlAttribute.Value = Converter.fixString(this.salesCode);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);
	
		xmlAttribute = xmlDoc.CreateAttribute(DF_DateUpdated);
		xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(this.DateUpdated, DateUtil.MMDDYYYY);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);
	
	}catch (XmlException ex){
		xmlDoc=null;//error
		throw new NujitException("Error in class Discount  <toXml> : " + ex.Message);		
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

			if (xmlAttribCollection[i].Name.Equals(DF_ID))
				this.id = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(DF_DiscCode))
				this.sdisCode = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(DF_DiscDesc))
				this.sdiscDes = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(DF_DiscRate))
				this.discRate = double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(DF_DrCr))
				this.sdrCr = xmlAttribCollection[i].Value.Trim();
			else if (xmlAttribCollection[i].Name.Equals(DF_BaseNet))
				this.sbaseNet = xmlAttribCollection[i].Value;			
			else if (xmlAttribCollection[i].Name.Equals(DF_DiscAmount))
				this.discAmount = double.Parse(xmlAttribCollection[i].Value);	           
			else if (xmlAttribCollection[i].Name.Equals(DF_FixedUnit))
				this.sfixedUnit = xmlAttribCollection[i].Value;	           
			else if (xmlAttribCollection[i].Name.Equals(DF_SalesCode))
				this.salesCode = xmlAttribCollection[i].Value;	           
			else if (xmlAttribCollection[i].Name.Equals(DF_DateUpdated))
				this.DateUpdated = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);	           
		}
	}catch (XmlException ex){
		bresult=false;
		throw new NujitException("Error in class Discount  <toXml> : " + ex.Message);		
	}   

	return bresult;
}

public
string getXmlHeader(){
	return "DISCOUNT";
}
#endif

} // class

} // namespace
