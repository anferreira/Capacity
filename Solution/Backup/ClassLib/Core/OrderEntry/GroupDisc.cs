using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Nujit.NujitERP.ClassLib.Util;


namespace Nujit.NujitERP.ClassLib.Core{


public 
class GroupDisc : 
#if OE_SYNC
	Serializable{	
#else
	MarshalByRefObject{
#endif

	private int			id;
	private string		sgroupCode;
	private int			idiscNum;
	private string 		sdiscCode;
	private DateTime	DateUpdated;

#if OE_SYNC
	public  const string GROUPDISC_ID			= "f1";
	public  const string GROUPDISC_CODE			= "f2";
	public  const string GROUPDISC_NUM			= "f3";
	public  const string GROUPDISC_DISC_CODE	= "f4";
	public	const string GROUPDISC_DATE_UPDATED	= "f5";
#endif

public 
GroupDisc(){
	id=0;
	sgroupCode="";
	idiscNum=0;
	sdiscCode="";	
	DateUpdated = DateTime.Now;
}

public 
GroupDisc(int id ,string sgroupCode,int idiscNum,string sdiscCode,DateTime DateUpdated)
{
	this.id			=id;
	this.sgroupCode	=sgroupCode;
	this.idiscNum   =idiscNum;
	this.sdiscCode	=sdiscCode;	
	this.DateUpdated=DateUpdated;
}


public
void setId(int id){
	this.id = id;
}	

public
void setGroupCode(string sgroupCode){
	this.sgroupCode = sgroupCode;
}

public
void setDiscNum(int idiscNum){
	this.idiscNum = idiscNum;
}

public
	void setDisCode(string sdiscCode)
{
	this.sdiscCode = sdiscCode;
}
public 
void setDateUpdated(DateTime DateUpdated)
{
	this.DateUpdated = DateUpdated;
}
	
public
int getId(){
	return this.id;
}	

public
	string  getGroupCode()
{
	return this.sgroupCode;
}

public
int getDiscNum(){
	return this.idiscNum;
}
public
	string getDisCode()
{
	return this.sdiscCode;
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

		xmlAttribute = xmlDoc.CreateAttribute(GROUPDISC_ID);
		xmlAttribute.Value = this.id.ToString();
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(GROUPDISC_CODE);
		xmlAttribute.Value = Converter.fixString(this.sgroupCode);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);	

		xmlAttribute = xmlDoc.CreateAttribute(GROUPDISC_NUM);
		xmlAttribute.Value = this.idiscNum.ToString();
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);	

		xmlAttribute = xmlDoc.CreateAttribute(GROUPDISC_DISC_CODE);
		xmlAttribute.Value = Converter.fixString(this.sdiscCode);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);	
	
		xmlAttribute = xmlDoc.CreateAttribute(GROUPDISC_DATE_UPDATED);
		xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(this.DateUpdated, DateUtil.MMDDYYYY);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);			
	}
	catch (XmlException ex)
	{
		xmlDoc=null;//error
		throw new NujitException("Error in class GroupDisc  <toXml> : " + ex.Message);		
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
					
			if (xmlAttribCollection[i].Name.Equals(GROUPDISC_ID))
				this.id = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(GROUPDISC_CODE))
				this.sgroupCode =xmlAttribCollection[i].Value; 	
			else if (xmlAttribCollection[i].Name.Equals(GROUPDISC_NUM))
				this.idiscNum = int.Parse(xmlAttribCollection[i].Value); 
			else if (xmlAttribCollection[i].Name.Equals(GROUPDISC_DISC_CODE))
				this.sdiscCode =xmlAttribCollection[i].Value; 	
			else if (xmlAttribCollection[i].Name.Equals(GROUPDISC_DATE_UPDATED))				
				this.DateUpdated = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);	           
		}
	}
	catch (XmlException ex)
	{
		bresult=false;
		throw new NujitException("Error in class GroupDisc  <toXml> : " + ex.Message);		
	}   

	return bresult;
}

public
string getXmlHeader()
{
	return "GROUP_DISC";
}
#endif

} // class

} // namespace