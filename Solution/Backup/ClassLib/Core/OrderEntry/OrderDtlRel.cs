using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Nujit.NujitERP.ClassLib.Util;
using System.Collections;

namespace Nujit.NujitERP.ClassLib.Core{


public 
class OrderDtlRel :
#if OE_SYNC
	Serializable{
#else
	MarshalByRefObject{
#endif

	
private int		ihId;
private int		id;
private string	sdb;
private string	scompany;
private string	splant;
private int		iorderNum;
private int		itemNum;
private int		itemNumRel;
private string  sorgId;
private string  sorgItemNum;
private string	sorgItemNumRel;
private string	shipToNum;
private string	shipToName;
private string	shipToAdd1;
private string	shipToAdd2;
private string	shipToAdd3;
private string	shipToAdd4;
private string	shipToAdd5;
private string	shipToAdd6;
private string	shipPostZip;
private string	sphoneNum;
private string	sattention;
private string	scustPO;
private double	dqtyOrd;
private string	sqtyOrdUom;
private double	dqtyOrdInv;
private string	sqtyOrdInvUom;
private double	dqtyShipped;
private double	dqtyShippedInv;
private double	dqtyBO;
private double	dqtyBOInv;
private DateTime DatePromise;
private DateTime DateRequest;
private DateTime DateShipping;
private DateTime DateCancel;
private DateTime DateChanged;
private DateTime DateNotBefore;
private DateTime DateAdded;
private int	iorderDtlID;
private string sprodDescription;
private string condition;
private string project;

#if OE_SYNC
	public const string  FieldDR_HID			="f1";
	public const string  FieldDR_ID				="f2";
	public const string  FieldDR_Db				="f3";
	public const string  FieldDR_Company		="f4";
	public const string  FieldDR_Plant			="f5";
	public const string  FieldDR_OrderNum		="f6";
	public const string  FieldDR_ItemNum		="f7";
	public const string  FieldDR_ItemNumRel		="f8";
	public const string  FieldDR_OrgId			="f9";
	public const string  FieldDR_OrgItemNum		="f10";
	public const string  FieldDR_OrgItemNumRel	="f11";
	public const string  FieldDR_ShpToNum		="f12";
	public const string  FieldDR_ShpToName		="f13";
	public const string  FieldDR_ShpToAdd1		="f14";
	public const string  FieldDR_ShpToAdd2		="f15";
	public const string  FieldDR_ShpToAdd3		="f16";
	public const string  FieldDR_ShpToAdd4		="f17";
	public const string  FieldDR_ShpToAdd5		="f18";
	public const string  FieldDR_ShpToAdd6		="f19";
	public const string  FieldDR_ShpPostZip		="f20";
	public const string  FieldDR_PhoneNum		="f21";
	public const string  FieldDR_Attention		="f22";
	public const string  FieldDR_CustPO			="f23";
	public const string  FieldDR_QtyOrd			="f24";
	public const string  FieldDR_QtyOrdUom		="f25";
	public const string  FieldDR_QtyOrdInv		="f26";
	public const string  FieldDR_QtyOrdInvUom	="f27";
	public const string  FieldDR_QtyShipped		="f28";
	public const string  FieldDR_QtyShippedInv	="f29";
	public const string  FieldDR_QtyBO			="f30";
	public const string  FieldDR_QtyBOInv		="f31";
	public const string  FieldDR_DatePromise	="f32";
	public const string  FieldDR_DateRequest	="f33";
	public const string  FieldDR_DateShipping	="f34";
	public const string  FieldDR_DateCancel		="f35";
	public const string  FieldDR_DateChanged	="f36";
	public const string  FieldDR_DateNotBefore	="f37";
	public const string  FieldDR_DateAdded		="f38";
	public const string	 FieldDR_OrderDtlRelID	="f39";
	public const string	 FieldDR_ProdDescription="f40";
#endif
	

public void setPerson(Person person)
{	
	this.setShipToNum(person.getId());	//id
	this.setShipToName(person.getName());//name

	this.setPlant(person.getPlt());		//plt
	this.setPhoneNum(person.getPhone());//phone		

	//address	
	this.setShipToAdd1(person.getAddress1());
	this.setShipToAdd2(person.getAddress2());
	this.setShipToAdd3(person.getAddress3());	
}	
public void getPerson(ref Person person)
{		
	person.setName(this.getShipToName());//name	
	person.setPhone(this.getPhoneNum());//phone		

	//address	
	person.setAddress1(this.getShipToAdd1());
	person.setAddress2(this.getShipToAdd2());
	person.setAddress3(this.getShipToAdd3());	
}	

public 
OrderDtlRel(){

	ihId=0;
	id=0;
	sdb="";
	scompany="";
	splant="";
	iorderNum=0;
	itemNum=0;
	itemNumRel=0;
	sorgId="";
	sorgItemNum="";
	sorgItemNumRel="";
	shipToNum="";
	shipToName="";
	shipToAdd1="";
	shipToAdd2="";
	shipToAdd3="";
	shipToAdd4="";
	shipToAdd5="";
	shipToAdd6="";
	shipPostZip="";
	sphoneNum="";
	sattention="";
	scustPO="";
	dqtyOrd=0;
	sqtyOrdUom="";
	dqtyOrdInv=0;
	sqtyOrdInvUom="";
	dqtyShipped = 0;
	dqtyShippedInv= 0;
	dqtyBO= 0;
	dqtyBOInv= 0;
	DatePromise= DateUtil.MinValue;
	DateRequest= DateUtil.MinValue;
	DateShipping= DateUtil.MinValue;
	DateCancel= DateUtil.MinValue;
	DateChanged= DateUtil.MinValue;
	DateNotBefore= DateUtil.MinValue;
	DateAdded = DateUtil.MinValue;
	iorderDtlID = 0;
	sprodDescription  ="";
	condition ="";
	project ="";

}
public void setHId(int ihId)
{
	this.ihId = ihId;
}
public void setId(int	id)
{
	this.id = id;
}
public void setDb(string sdb)
{
	this.sdb = sdb;
}
public void setCompany(string scompany)
{
	this.scompany = scompany;
}

public void setPlant(string splant)
{
	this.splant = splant;
}

public void setOrderNum(int iorderNum)
{
	this.iorderNum = iorderNum;
}
public void setItemNum(int itemNum)
{
	this.itemNum = itemNum;
}
public void setItemNumRel(int itemNumRel)
{
	this.itemNumRel = itemNumRel;
}
public void setOrgId(string sorgId)
{
	this.sorgId = sorgId;
}
public void setOrgItemNum(string sorgItemNum)
{
	this.sorgItemNum = sorgItemNum;
}
public void setOrgItemNumRel(string sorgItemNumRel)
{
	this.sorgItemNumRel = sorgItemNumRel;
}	

public void setShipToNum(string shipToNum)
{
	this.shipToNum = shipToNum;
}

public void setShipToName(string shipToName)
{
	this.shipToName = shipToName;
}

public void setShipToAdd1(string shipToAdd1)
{
	this.shipToAdd1 = shipToAdd1;
}

public void setShipToAdd2(string shipToAdd2)
{
	this.shipToAdd2 = shipToAdd2;
}
public void setShipToAdd3(string shipToAdd3)
{
	this.shipToAdd3 = shipToAdd3;
}

public void setShipToAdd4(string shipToAdd4)
{
	this.shipToAdd4 = shipToAdd4;
}
public void setShipToAdd5(string shipToAdd5)
{
	this.shipToAdd5 = shipToAdd5;
}
public void setShipToAdd6(string shipToAdd6)
{
	this.shipToAdd6 = shipToAdd6;
}
public void setShipPostZip(string shipPostZip)
{
	this.shipPostZip = shipPostZip;
}
public void setPhoneNum(string sphoneNum)
{
	this.sphoneNum = sphoneNum;
}
public void setAttention(string sattention)
{
	this.sattention = sattention;
}

public void setCustPO(string scustPO)
{
	this.scustPO = scustPO;
}

public void setQtyOrd(double dqtyOrd)
{
	this.dqtyOrd = dqtyOrd;
}

public void setQtyOrdUom(string sqtyOrdUom)
{
	this.sqtyOrdUom = sqtyOrdUom;
}

public void setQtyOrdInv(double dqtyOrdInv)
{
	this.dqtyOrdInv = dqtyOrdInv;
}

public void setQtyOrdInvUom(string sqtyOrdInvUom)
{
	this.sqtyOrdInvUom = sqtyOrdInvUom;
}

public void setQtyShipped(double dqtyShipped)
{
	this.dqtyShipped = dqtyShipped;
}
public void setQtyShippedInv(double dqtyShippedInv)
{
	this.dqtyShippedInv = dqtyShippedInv;
}
public void setQtyBO(double dqtyBO)
{
	this.dqtyBO = dqtyBO;
}	
public void setQtyBOInv(double dqtyBOInv)
{
	this.dqtyBOInv = dqtyBOInv;
}
public void setDatePromise(DateTime DatePromise)
{
	this.DatePromise = DatePromise;
}
	
public void setDateRequest(DateTime DateRequest)
{
	this.DateRequest = DateRequest;
}
	 
public void setDateShipping(DateTime DateShipping)
{
	this.DateShipping = DateShipping;
}

public void setDateCancel(DateTime DateCancel)
{
	this.DateCancel = DateCancel;
}
public void setDateChanged(DateTime DateChanged)
{
	this.DateChanged = DateChanged;
}
public void setDateNotBefore(DateTime DateNotBefore)
{
	this.DateNotBefore = DateNotBefore;
}
public void setDateAdded(DateTime DateAdded)
{
	this.DateAdded = DateAdded;
}
public void setOrderDtlID(int iorderDtlID)
{
	this.iorderDtlID = iorderDtlID;
}
public void setProdDescription(string sprodDescription)
{
	this.sprodDescription = sprodDescription;
}	

public 
void setCondition(string condition){
	this.condition = condition;
}	

public 
void setProject(string project){
	this.project = project;
}	

public int getHId()
{
	return ihId;
}
			
public int getId()
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

public int getItemNum()
{
	return itemNum;
}
public int getItemNumRel()
{
	return itemNumRel;
}
public string getOrgId()
{
	return sorgId;
}
public string getOrgItemNum()
{
	return sorgItemNum;
}
public string getOrgItemNumRel()
{
	return sorgItemNumRel;
}	

public string getShipToNum()
{
	return shipToNum;
}

public string getShipToName()
{
	return shipToName;
}

public string getShipToAdd1()
{
	return shipToAdd1;
}

public string getShipToAdd2()
{
	return shipToAdd2;
}
public string getShipToAdd3()
{
	return shipToAdd3;
}

public string getShipToAdd4()
{
	return shipToAdd4;
}
public string getShipToAdd5()
{
	return shipToAdd5;
}
public string getShipToAdd6()
{
	return shipToAdd6;
}
public string getShipPostZip()
{
	return shipPostZip;
}
public string getPhoneNum()
{
	return sphoneNum;
}
public string getAttention()
{
	return sattention;
}

public string getCustPO()
{
	return scustPO;
}

public double getQtyOrd()
{
	return dqtyOrd;
}

public string getQtyOrdUom()
{
	return sqtyOrdUom;
}

public double getQtyOrdInv()
{
	return dqtyOrdInv;
}

public string getQtyOrdInvUom()
{
	return sqtyOrdInvUom;
}

public double getQtyShipped()
{
	return dqtyShipped;
}
public double getQtyShippedInv()
{
	return dqtyShippedInv;
}
public double getQtyBO()
{
	return dqtyBO;
}	
public double getQtyBOInv()
{
	return dqtyBOInv;
}
public DateTime getDatePromise()
{
	return DatePromise;
}
	
public DateTime getDateRequest()
{
	return DateRequest;
}
	 
public DateTime getDateShipping()
{
	return DateShipping;
}

public DateTime getDateCancel()
{
	return DateCancel;
}
public DateTime getDateChanged()
{
	return DateChanged;
}
public DateTime getDateNotBefore()
{
	return DateNotBefore;
}
public DateTime getDateAdded()
{
	return DateAdded;
}
public int getOrderDtlRelID()
{
	return iorderDtlID;
}
public string getProdDescription()
{
	return sprodDescription;
}	

public string getCondition(){
	return condition;
}	

public string getProject(){
	return project;
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
		throw new NujitException("Error in class OrderDtlRel <toXml> : " + ex.Message);		
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
					 			
			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_HID);
			xmlAttribute.Value = this.getHId().ToString();
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_ID);
			xmlAttribute.Value = this.getId().ToString();
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_Db);
			xmlAttribute.Value = Converter.fixString(this.getDb());
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_Company);
			xmlAttribute.Value = Converter.fixString(this.getCompany());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_Plant);
			xmlAttribute.Value = Converter.fixString(this.getPlant());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_OrderNum);
			xmlAttribute.Value = this.getOrderNum().ToString();
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_ItemNum);
			xmlAttribute.Value = this.getItemNum().ToString();
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_ItemNumRel);
			xmlAttribute.Value = this.getItemNumRel().ToString();
			xmlElement.SetAttributeNode(xmlAttribute);		
		
			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_OrgId);
			xmlAttribute.Value = Converter.fixString(this.getOrgId());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_OrgItemNum);
			xmlAttribute.Value = Converter.fixString(this.getOrgItemNum());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_OrgItemNumRel);
			xmlAttribute.Value = Converter.fixString(this.getOrgItemNumRel());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_ShpToNum);
			xmlAttribute.Value = Converter.fixString(this.getShipToNum());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_ShpToName);
			xmlAttribute.Value = Converter.fixString(this.getShipToName());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_ShpToAdd1);
			xmlAttribute.Value = Converter.fixString(this.getShipToAdd1());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_ShpToAdd2);
			xmlAttribute.Value = Converter.fixString(this.getShipToAdd2());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_ShpToAdd3);
			xmlAttribute.Value = Converter.fixString(this.getShipToAdd3());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_ShpToAdd4);
			xmlAttribute.Value = Converter.fixString(this.getShipToAdd4());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_ShpToAdd5);
			xmlAttribute.Value = Converter.fixString(this.getShipToAdd5());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_ShpToAdd6);
			xmlAttribute.Value = Converter.fixString(this.getShipToAdd6());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_ShpPostZip);
			xmlAttribute.Value = Converter.fixString(this.getShipPostZip());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_PhoneNum);
			xmlAttribute.Value = Converter.fixString(this.getPhoneNum());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_Attention);
			xmlAttribute.Value = Converter.fixString(this.getAttention());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_CustPO);
			xmlAttribute.Value = Converter.fixString(this.getCustPO());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_QtyOrd);
			xmlAttribute.Value = NumberUtil.toString(this.getQtyOrd());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_QtyOrdUom);
			xmlAttribute.Value = Converter.fixString(this.getQtyOrdUom());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_QtyOrdInv);
			xmlAttribute.Value = NumberUtil.toString(this.getQtyOrdInv());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_QtyOrdInvUom);
			xmlAttribute.Value = Converter.fixString(this.getQtyOrdInvUom());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_QtyShipped);
			xmlAttribute.Value = NumberUtil.toString(this.getQtyShipped());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_QtyShippedInv);
			xmlAttribute.Value = NumberUtil.toString(this.getQtyShippedInv());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_QtyBO);
			xmlAttribute.Value = NumberUtil.toString(this.getQtyBO());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_QtyBOInv);
			xmlAttribute.Value = NumberUtil.toString(this.getQtyBOInv());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_DatePromise);
			xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(this.getDatePromise(), DateUtil.MMDDYYYY);
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_DateRequest);
			xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(this.getDateRequest(), DateUtil.MMDDYYYY);
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_DateShipping);
			xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(this.getDateShipping(), DateUtil.MMDDYYYY);
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_DateCancel);
			xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(this.getDateCancel(), DateUtil.MMDDYYYY);
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_DateChanged);
			xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(this.getDateChanged(), DateUtil.MMDDYYYY);
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_DateNotBefore);
			xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(this.getDateNotBefore(), DateUtil.MMDDYYYY);
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_DateAdded);
			xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(this.getDateAdded(), DateUtil.MMDDYYYY);
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_OrderDtlRelID);
			xmlAttribute.Value = this.getOrderDtlRelID().ToString();
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldDR_ProdDescription);
			xmlAttribute.Value = Converter.fixString(this.getProdDescription());
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
					
			if (xmlAttribCollection[i].Name.Equals(FieldDR_HID))
				this.ihId = int.Parse(xmlAttribCollection[i].Value);
			if (xmlAttribCollection[i].Name.Equals(FieldDR_ID))
				this.id = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_Db))
				this.sdb = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_Company))
				this.scompany = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_Plant))
				this.splant = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_OrderNum))
				this.iorderNum = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_OrderNum))
				this.iorderNum = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_ItemNum))
				this.itemNum = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_ItemNumRel))
				this.itemNumRel = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_OrgId))
				this.sorgId = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_OrgItemNum))
				this.sorgItemNum = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_OrgItemNumRel))
				this.sorgItemNumRel = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_ShpToNum))
				this.shipToNum = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_ShpToName))
				this.shipToName = xmlAttribCollection[i].Value;			
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_ShpToAdd1))
				this.shipToAdd1 = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_ShpToAdd2))
				this.shipToAdd2 = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_ShpToAdd3))
				this.shipToAdd3 = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_ShpToAdd4))
				this.shipToAdd4 = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_ShpToAdd5))
				this.shipToAdd5 = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_ShpToAdd6))
				this.shipToAdd6 = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_ShpPostZip))
				this.shipPostZip = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_PhoneNum))
				this.sphoneNum = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_Attention))
				this.sattention = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_CustPO))
				this.scustPO = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_QtyOrd))
				this.dqtyOrd = double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_QtyOrdUom))
				this.sqtyOrdUom = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_QtyOrdInv))
				this.dqtyOrdInv = double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_QtyOrdInvUom))
				this.sqtyOrdInvUom = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_QtyShipped))
				this.dqtyShipped = double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_QtyShippedInv))
				this.dqtyShippedInv = double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_QtyBO))
				this.dqtyBO = double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_QtyBOInv))
				this.dqtyBOInv = double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_DatePromise))
				this.DatePromise = 	DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_DateRequest))
				this.DateRequest = 	DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_DateShipping))
				this.DateShipping = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_DateCancel))
				this.DateCancel = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_DateChanged))
				this.DateCancel = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_DateNotBefore))
				this.DateNotBefore = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_DateAdded))
				this.DateAdded = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_OrderDtlRelID))
				this.iorderDtlID = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldDR_ProdDescription))
				this.sprodDescription = xmlAttribCollection[i].Value;
					
		}
	}
	catch (XmlException ex)
	{
		bresult=false;
		throw new NujitException("Error in class OrderDtlRel <toXml> : " + ex.Message);		
	}   

	return bresult;
}


public
string getXmlHeader()
{
	return "ORDERDTLREL";
}	
#endif

public OrderDtlRel clone()
{
	OrderDtlRel newOrderDtlRel = new OrderDtlRel();

	newOrderDtlRel.ihId = this.ihId;
	newOrderDtlRel.id = this.id;
	newOrderDtlRel.sdb = this.sdb;
	newOrderDtlRel.scompany = this.scompany;
	newOrderDtlRel.splant = this.splant;
	newOrderDtlRel.iorderNum = this.iorderNum;
	newOrderDtlRel.itemNum = this.itemNum;
	newOrderDtlRel.itemNumRel = this.itemNumRel;
	newOrderDtlRel.sorgId = this.sorgId;
	newOrderDtlRel.sorgItemNum = this.sorgItemNum;
	newOrderDtlRel.sorgItemNumRel = this.sorgItemNumRel;
	newOrderDtlRel.shipToNum = this.shipToNum;
	newOrderDtlRel.shipToName = this.shipToName;
	newOrderDtlRel.shipToAdd1 = this.shipToAdd1;
	newOrderDtlRel.shipToAdd2 = this.shipToAdd2;
	newOrderDtlRel.shipToAdd3 = this.shipToAdd3;
	newOrderDtlRel.shipToAdd4 = this.shipToAdd4;
	newOrderDtlRel.shipToAdd5 = this.shipToAdd5;
	newOrderDtlRel.shipToAdd6 = this.shipToAdd6;
	newOrderDtlRel.shipPostZip= this.shipPostZip;
	newOrderDtlRel.sphoneNum = this.sphoneNum;
	newOrderDtlRel.sattention = this.sattention;
	newOrderDtlRel.scustPO = this.scustPO;
	newOrderDtlRel.dqtyOrd = this.dqtyOrd;
	newOrderDtlRel.sqtyOrdUom = this.sqtyOrdUom;
	newOrderDtlRel.dqtyOrdInv = this.dqtyOrdInv;
	newOrderDtlRel.sqtyOrdInvUom = this.sqtyOrdInvUom;
	newOrderDtlRel.dqtyShipped = this.dqtyShipped;
	newOrderDtlRel.dqtyShippedInv = this.dqtyShippedInv;
	newOrderDtlRel.dqtyBO = this.dqtyBO;
	newOrderDtlRel.dqtyBOInv = this.dqtyBOInv;
	newOrderDtlRel.DatePromise = this.DatePromise;
	newOrderDtlRel.DateRequest = this.DateRequest;
	newOrderDtlRel.DateShipping = this.DateShipping;
	newOrderDtlRel.DateCancel = this.DateCancel;
	newOrderDtlRel.DateChanged = this.DateChanged;
	newOrderDtlRel.DateNotBefore = this.DateNotBefore;
	newOrderDtlRel.DateAdded = this.DateAdded;
	newOrderDtlRel.iorderDtlID = this.iorderDtlID;
	newOrderDtlRel.sprodDescription = this.sprodDescription;
	newOrderDtlRel.condition = this.condition ;
	newOrderDtlRel.project = this.project;

	return newOrderDtlRel;
}

} // class

} // namespace



