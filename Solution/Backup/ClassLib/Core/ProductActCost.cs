using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{

public 
class ProductActCost : 
#if OE_SYNC
	Serializable{	
#else
	MarshalByRefObject{
#endif

	private string		sprodId;
	private string		sactId;
	private int			iseq;
	private string 		spartType;
	private decimal		deCost;
	private DateTime	DateUpdated;
	
#if OE_SYNC
	public  const string PAC_ProdID		= "f1";
	public  const string PAC_ActID		= "f2";
	public  const string PAC_Seq		= "f3";
	public  const string PAC_PartType	= "f4";
	public	const string PAC_Cost		= "f5";
	public	const string PAC_DateUpdated= "f6";
#endif

public 
ProductActCost(){
	
	sprodId="";
	sactId="";
	iseq=0;
	spartType="";	
	deCost = 0;
	DateUpdated= DateTime.Now;
}
public 
ProductActCost(string sprodId ,string sactId,int iseq,string spartType,decimal deCost,DateTime DateUpdated)
{
	this.sprodId=sprodId;
	this.sactId	=sactId;
	this.iseq   =iseq;
	this.spartType=spartType;	
	this.deCost=deCost;
	this.DateUpdated = DateUpdated;
}


public
void setProdId(string sprodId){
	this.sprodId = sprodId;
}	

public
void setActId(string sactId){
	this.sactId = sactId;
}

public
void setSeq(int iseq){
	this.iseq = iseq;
}

public
	void setPartType(string spartType)
{
	this.spartType = spartType;
}
public 
void setCost(decimal deCost)
{
	this.deCost = deCost;
}
public 
void setDateUpdated(DateTime DateUpdated)
{
	this.DateUpdated = DateUpdated;
}	

public
string getProdId(){
	return this.sprodId;
}	

public
	string  getActId()
{
	return this.sactId;
}

public
int getSeq(){
	return this.iseq;
}
public
	string getPartType()
{
	return this.spartType;
}
public 
decimal getCost()
{
	return this.deCost;
}
public 
DateTime getDateUpdated()
{
	return this.DateUpdated;
}

#if OE_SYNC
public 
XmlDocument toXml()
{	
	string			sxml;
	XmlDocument		xmlDoc = new XmlDocument();
	XmlElement		xmlElement = xmlDoc.DocumentElement;
	XmlAttribute	xmlAttribute=null;
					
	try
	{				
		sxml = "<" + getXmlHeader() + "></" + getXmlHeader() + ">";
		xmlDoc.LoadXml(sxml); 			


		xmlAttribute = xmlDoc.CreateAttribute(PAC_ProdID);
		xmlAttribute.Value = Converter.fixString(this.sprodId);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(PAC_ActID);
		xmlAttribute.Value = Converter.fixString(this.sactId);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);	

		xmlAttribute = xmlDoc.CreateAttribute(PAC_Seq);
		xmlAttribute.Value = this.iseq.ToString();
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);	

		xmlAttribute = xmlDoc.CreateAttribute(PAC_PartType);
		xmlAttribute.Value = Converter.fixString(this.spartType);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);	
	
		xmlAttribute = xmlDoc.CreateAttribute(PAC_Cost);
		xmlAttribute.Value =  this.deCost.ToString();
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);	
		
		xmlAttribute = xmlDoc.CreateAttribute(PAC_DateUpdated);
		xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(this.DateUpdated, DateUtil.MMDDYYYY);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);	
		
	}
	catch (XmlException ex)
	{
		xmlDoc=null;//error
		throw new NujitException("Error in class ProductActCost  <toXml> : " + ex.Message);		
	}
			
	return xmlDoc;
}


public 
bool Parse(XmlDocument xmlDocument){
	bool	bresult=false;

	try
	{		
		XmlAttributeCollection xmlAttribCollection = xmlDocument.DocumentElement.Attributes;
		//read all of the attribute
		for (int i=0; i < xmlAttribCollection.Count; i++)
		{
			bresult=true;
				
			if (xmlAttribCollection[i].Name.Equals(PAC_ProdID))
				this.sprodId = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(PAC_ActID))
				this.sactId =xmlAttribCollection[i].Value; 	
			else if (xmlAttribCollection[i].Name.Equals(PAC_Seq))
				this.iseq = int.Parse(xmlAttribCollection[i].Value); 
			else if (xmlAttribCollection[i].Name.Equals(PAC_PartType))
				this.spartType =xmlAttribCollection[i].Value; 	
			else if (xmlAttribCollection[i].Name.Equals(PAC_Cost))				
				this.deCost = decimal.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(PAC_DateUpdated))				
				this.DateUpdated = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);	           
		}
	}
	catch (XmlException ex)
	{
		bresult=false;
		throw new NujitException("Error in class ProductActCost  <toXml> : " + ex.Message);		
	}   

	return bresult;
}

public
string getXmlHeader()
{
	return "PRODUCT_ACT_COST";
}
#endif
} // class

} // namespace
