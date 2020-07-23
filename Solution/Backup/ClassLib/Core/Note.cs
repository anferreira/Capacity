using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core{


public 
class Note : 
#if OE_SYNC
	Serializable{	
#else
	MarshalByRefObject{
#endif

	private int			id;
	private string		stype;
	private int			ikey1;
	private int 		ikey2;
	private int			ikey3;
	private int			ilineNum;
	private string		snote;
	
#if OE_SYNC
	public  const string Field_ID		= "f1";
	public  const string Field_Type		= "f2";
	public  const string Field_Key1		= "f3";
	public  const string Field_Key2		= "f4";
	public	const string Field_Key3		= "f5";
	public	const string Field_LineNum	= "f6";
	public  const string Field_Note		= "f7";	
#endif

public 
Note(){
	
	id=0;
	stype="";
	ikey1 = 0;
	ikey2 = int.MinValue;//like NULL by defeault
	ikey3 = int.MinValue;//like NULL by defeault
	ilineNum=0;
	snote="";
}
public 
Note(int id ,string stype,int ikey1,int ikey2,int ikey3,int ilineNum,string snote)
{
	this.id			=id;
	this.stype		=stype;
	this.ikey1		=ikey1;
	this.ikey2		=ikey2;	
	this.ikey3		=ikey3;
	this.ilineNum	=ilineNum;
	this.snote		=snote;
}


public
void setId(int id){
	this.id = id;
}	

public
void setType(string stype){
	this.stype = stype;
}

public
void setKey1(int ikey1){
	this.ikey1 = ikey1;
}

public
	void setKey2(int ikey2)
{
	this.ikey2 = ikey2;
}
public 
void setKey3(int ikey3)
{
	this.ikey3 = ikey3;
}

public 
void setLineNum(int ilineNum)
{
	this.ilineNum = ilineNum;
}	

public 
void setNote(string snote)
{
	this.snote = snote;
}

public
int getId(){
	return this.id;
}	

public
	string  getType()
{
	return this.stype;
}

public
int getKey1(){
	return this.ikey1;
}
public
int getKey2()
{
	return this.ikey2;
}
public 
int getKey3()
{
	return this.ikey3;
}
public 
int getLineNum()
{
	return this.ilineNum;
}

public 
string getNote()
{
	return this.snote;
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
		throw new NujitException("Error in class OrderHeader  <toXml> : " + ex.Message);		
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
			
							
			xmlAttribute = xmlDoc.CreateAttribute(Field_ID);
			xmlAttribute.Value = this.id.ToString();			
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(Field_Type);
			xmlAttribute.Value = Converter.fixString(this.stype);
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(Field_Key1);
			xmlAttribute.Value = this.ikey1.ToString();
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(Field_Key2);
			xmlAttribute.Value = this.ikey2.ToString();
			xmlElement.SetAttributeNode(xmlAttribute);
		
			xmlAttribute = xmlDoc.CreateAttribute(Field_Key3);
			xmlAttribute.Value =  this.ikey3.ToString();
			xmlElement.SetAttributeNode(xmlAttribute);
			
			xmlAttribute = xmlDoc.CreateAttribute(Field_LineNum);
			xmlAttribute.Value = this.ilineNum.ToString();
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(Field_Note);
			xmlAttribute.Value = Converter.fixString(snote);
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
bool Parse(XmlDocument xmlDocument){
	bool	bresult=false;

	try
	{		
		XmlAttributeCollection xmlAttribCollection = xmlDocument.DocumentElement.Attributes;
		//read all of the attribute
		for (int i=0; i < xmlAttribCollection.Count; i++)
		{
			bresult=true;
				
			if (xmlAttribCollection[i].Name.Equals(Field_ID))
				this.id = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(Field_Type))
				this.stype =xmlAttribCollection[i].Value; 	
			else if (xmlAttribCollection[i].Name.Equals(Field_Key1))
				this.ikey1 = int.Parse(xmlAttribCollection[i].Value); 
			else if (xmlAttribCollection[i].Name.Equals(Field_Key2))
				this.ikey2 = int.Parse(xmlAttribCollection[i].Value); 
			else if (xmlAttribCollection[i].Name.Equals(Field_Key3))				
				this.ikey3 = int.Parse(xmlAttribCollection[i].Value); 
			else if (xmlAttribCollection[i].Name.Equals(Field_LineNum))				
				this.ilineNum = int.Parse(xmlAttribCollection[i].Value); 
			else if (xmlAttribCollection[i].Name.Equals(Field_Note))				
				this.snote = xmlAttribCollection[i].Value; 				
		}
	}
	catch (XmlException ex)
	{
		bresult=false;
		throw new NujitException("Error in class Note  <toXml> : " + ex.Message);		
	}   

	return bresult;
}

public
string getXmlHeader()
{
	string sxmlHeader="NOTE";

	if (stype.Equals(Constants.NOTE_TYPE_ORDER))				
		sxmlHeader = "ORDER_NOTE";
	else if (stype.Equals(Constants.NOTE_TYPE_ORDER_DTL))				
		sxmlHeader = "DETAIL_NOTE";

	return sxmlHeader;
}
#endif

} // class

} // namespace
