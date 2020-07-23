using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Nujit.NujitERP.ClassLib.Util;
using System.Collections;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core{


public 
class OrderDtl : 
#if OE_SYNC
	Serializable{
#else
	MarshalByRefObject{
#endif

	
private	int ihId;
private	int id;
private	string sdb;
private	string scompany;
private	string splant;
private	int iorderNum;
private	int itemNum;	
private	string sorgId;
private	string sorgItemNum;
private	string sprodID;
private	string	sprodDescription;
private	int	iseq;
private	string sinternalRef;
private	string scustPart;
private	string scustPO;
private	double dqtyOrdSum;
private	double dqtyShippedSum;
private	string sqtyOrdUom;
private	double dunitPrice;
private	string sunitPriceUom;
private	double ditemNetTotal;
private	DateTime DateAdded;
private	double dtotalDiscounts;
private	double dtotalPromo;
private	double dtotalRoyalty;
private	double dtotalFreight;
private	double dtotalTax;
private	double dtotalStTax;
private	double dtotalFedTax;
private	string serpOrderNum;
private	int	 ierpOrderItemNum;
private	double dqtyPackSize;
private	double dcost;
private string condition;
private string project;
	
	
#if OE_SYNC
	public const string FieldD_HID				="f1";
	public const string FieldD_ID				="f2";
	public const string FieldD_Db				="f3";
	public const string FieldD_Company			="f4";
	public const string FieldD_Plant			="f5";
	public const string FieldD_OrderNum			="f6";
	public const string FieldD_ItemNum			="f7";	
	public const string FieldD_OrgId			="f8";	
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
	public const string FieldD_ErpOrderNum		="f30";
	public const string FieldD_ErpOrderItemNum	="f31";
	public const string FieldD_QtyPackSize		="f32";
	public const string FieldD_Cost				="f33";
#endif
		
	ArrayList		arrayOrderDtlRel= new ArrayList();
	ArrayList		arrayOrderDtlCharges= new ArrayList();
	NoteList		noteList = new NoteList();


public 
OrderDtl(){
	
	ihId=0;
	id=0;
	sdb="Db";
	scompany="Compay";
	splant="Plant";
	iorderNum=0;
	itemNum=0;	
	sprodID="";
	sorgId="";
	sorgItemNum="";
	sprodDescription="";
	iseq=0;
	sinternalRef="";
	scustPart="";
	scustPO="";
	dqtyOrdSum=0;
	dqtyShippedSum=0;
	sqtyOrdUom="";
	dunitPrice=0;
	sunitPriceUom="";
	ditemNetTotal=0;
	DateAdded= DateUtil.MinValue;
	dtotalDiscounts=0;
	dtotalPromo=0;
	dtotalRoyalty=0;
	dtotalFreight=0;
	dtotalTax=0;
	dtotalStTax=0;
	dtotalFedTax=0;	
	serpOrderNum="";
	ierpOrderItemNum=0;
	dqtyPackSize=0;
	dcost=0;
	condition ="";
	project ="";
}

public void setHId (int ihId){
	this.ihId =ihId;
}

public void setId (int id){
	this.id = id;
}

public void setDb (	string sdb){
	this.sdb = sdb;
}

public void setCompany (string scompany){
	this.scompany = scompany;
}

public void setPlant (string splant){
	this.splant = splant;
}

public void setOrderNum (int iorderNum){
	this.iorderNum = iorderNum;
}

public void setItemNum (int itemNum){
	this.itemNum = itemNum;
}

public void setOrgId (string sorgId){
	this.sorgId = sorgId;
}

public void setOrgItemNum (string sorgItemNum){
	this.sorgItemNum = sorgItemNum;
}
	
public void setProdID (string sprodID){
	this.sprodID = sprodID;
}

public void setProdDescription (string sprodDescription){
	this.sprodDescription = sprodDescription;
}

public void setSeq (int	iseq){
	this.iseq = iseq;
}

public void setInternalRef (string sinternalRef){
	this.sinternalRef = sinternalRef;
}

public void setCustPart (string scustPart){
	this.scustPart = scustPart;
}

public void setCustPO (string scustPO){
	this.scustPO = scustPO;
}

public void setQtyOrdSum (double dqtyOrdSum){
	this.dqtyOrdSum = dqtyOrdSum;
}

public void setQtyShippedSum (double dqtyShippedSum){
	this.dqtyShippedSum = dqtyShippedSum;
}

public void setQtyOrdUom (string sqtyOrdUom){
	this.sqtyOrdUom = sqtyOrdUom;
}

public void setUnitPrice (double dunitPrice){
	this.dunitPrice = dunitPrice;
}

public void setUnitPriceUom (string sunitPriceUom){
	this.sunitPriceUom = sunitPriceUom;
}

public void setItemNetTotal (double ditemNetTotal){
	this.ditemNetTotal = ditemNetTotal;
}

public void setDateAdded (DateTime DateAdded){
	this.DateAdded = DateAdded;
}

public void setTotalDiscounts (double dtotalDiscounts){
	this.dtotalDiscounts = dtotalDiscounts;
}

public void setTotalPromo (double dtotalPromo){
	this.dtotalPromo = dtotalPromo;
}

public void setTotalRoyalty (double dtotalRoyalty){
	this.dtotalRoyalty = dtotalRoyalty;
}

public void setTotalFreight (double dtotalFreight){
	this.dtotalFreight = dtotalFreight;
}

public void setTotalTax (double dtotalTax){
	this.dtotalTax = dtotalTax;
}

public void setTotalStTax (double dtotalStTax){
	this.dtotalStTax = dtotalStTax;
}

public void setTotalFedTax (double dtotalFedTax){
	this.dtotalFedTax = dtotalFedTax;
}

public void setErpOrderNum(string serpOrderNum){
	this.serpOrderNum = serpOrderNum;
}	

public void setErpOrderItemNum(int ierpOrderItemNum){
	this.ierpOrderItemNum = ierpOrderItemNum;
}	
	
public void setQtyPackSize(double dqtyPackSize){
	this.dqtyPackSize = dqtyPackSize;
}	

public void setCost(double dcost){
	this.dcost = dcost;
}	
 
public void setCondition(string condition){
	this.condition = condition;
}

public void setProject(string project){
	this.project = project;
}


public int getHId(){
	return ihId;
}
public int getId(){
	return id;
}

public string getDb(){
	return sdb;
}

public string getCompany(){
	return scompany;
}

public string getPlant(){
	return splant;
}

public int getOrderNum(){
	return iorderNum;
}

public int getItemNum(){
	return itemNum;
}

public string getOrgId(){
	return sorgId;
}

public string getOrgItemNum (){
	return sorgItemNum;
}


public string getProdID(){
	return sprodID;
}

public string getProdDescription (){
	return this.sprodDescription;
}

public
int	getSeq(){
	return iseq;
}

public string getInternalRef(){
	return sinternalRef;
}

public string getCustPart(){
	return scustPart;
}

public string getCustPO(){
	return scustPO;
}

public double getQtyOrdSum(){
	return dqtyOrdSum;
}

public double getQtyShippedSum(){
	return dqtyShippedSum;
}

public string getQtyOrdUom(){
	return sqtyOrdUom;
}

public double getUnitPrice(){
	return dunitPrice;
}

public string getUnitPriceUom(){
	return sunitPriceUom;
}

public double getItemNetTotal(){
	return ditemNetTotal;
}

public DateTime getDateAdded(){
	return DateAdded;
}

public double getTotalDiscounts(){
	return dtotalDiscounts;
}

public double getTotalPromo(){
	return dtotalPromo;
}

public double getTotalRoyalty(){
	return dtotalRoyalty;
}

public double getTotalFreight(){
	return dtotalFreight;
}

public double getTotalTax(){
	return dtotalTax;
}

public double getTotalStTax(){
	return dtotalStTax;
}

public double getTotalFedTax(){
	return dtotalFedTax;
}

public string getErpOrderNum(){
	return serpOrderNum;
}	

public int getErpOrderItemNum(){
	return ierpOrderItemNum;
}		
	
public double getQtyPackSize(){
	return dqtyPackSize;
}	

public double getCost(){
	return dcost;
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
			int				j=0;
			
	
			//Create a new node.
			xmlElement = xmlDoc.CreateElement(this.getXmlHeader());
							
			xmlAttribute = xmlDoc.CreateAttribute(FieldD_HID);
			xmlAttribute.Value = this.getHId().ToString();
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_ID);
			xmlAttribute.Value = this.getId().ToString();
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_Db);
			xmlAttribute.Value = Converter.fixString(this.getDb());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_Company);
			xmlAttribute.Value = Converter.fixString(this.getCompany());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_Plant);
			xmlAttribute.Value = Converter.fixString(this.getPlant());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_OrderNum);
			xmlAttribute.Value = this.getOrderNum().ToString();
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_ItemNum);
			xmlAttribute.Value = this.getItemNum().ToString();
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_OrgId);
			xmlAttribute.Value = this.getOrgId();				
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_OrgItemNum);
			xmlAttribute.Value = this.getOrgItemNum();				
			xmlElement.SetAttributeNode(xmlAttribute);		
						
			//product
			xmlAttribute = xmlDoc.CreateAttribute(FieldD_ProdID);
			xmlAttribute.Value = Converter.fixString(this.getProdID());
			xmlElement.SetAttributeNode(xmlAttribute);		
			
			xmlAttribute = xmlDoc.CreateAttribute(FieldD_ProdDescription);
			xmlAttribute.Value =  Converter.fixString(this.getProdDescription());
			xmlElement.SetAttributeNode(xmlAttribute);	

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_Seq);
			xmlAttribute.Value =  this.getSeq().ToString();
			xmlElement.SetAttributeNode(xmlAttribute);	

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_InternalRef);
			xmlAttribute.Value =  Converter.fixString(this.getInternalRef());
			xmlElement.SetAttributeNode(xmlAttribute);	

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_CustPart);
			xmlAttribute.Value =  Converter.fixString(this.getCustPart());
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_CustPO);
			xmlAttribute.Value =  Converter.fixString(this.getCustPO());
			xmlElement.SetAttributeNode(xmlAttribute);

			//quantity
			xmlAttribute = xmlDoc.CreateAttribute(FieldD_QtyOrdSum);
			xmlAttribute.Value =  NumberUtil.toString(this.getQtyOrdSum());
			xmlElement.SetAttributeNode(xmlAttribute);
	
			xmlAttribute = xmlDoc.CreateAttribute(FieldD_QtyShippedSum);
			xmlAttribute.Value =  NumberUtil.toString(this.getQtyShippedSum());
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_QtyOrdUom);
			xmlAttribute.Value =  Converter.fixString(this.getQtyOrdUom());
			xmlElement.SetAttributeNode(xmlAttribute);

			//prize
			xmlAttribute = xmlDoc.CreateAttribute(FieldD_UnitPrice);
			xmlAttribute.Value =  NumberUtil.toString(this.getUnitPrice());
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_UnitPriceUom);
			xmlAttribute.Value =  Converter.fixString(this.getUnitPriceUom());
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_ItemNetTotal);
			xmlAttribute.Value =  NumberUtil.toString(this.getItemNetTotal());
			xmlElement.SetAttributeNode(xmlAttribute);
	
			//date
			xmlAttribute = xmlDoc.CreateAttribute(FieldD_DateAdded);
			xmlAttribute.Value =  DateUtil.getCompleteDateRepresentation(this.getDateAdded(), DateUtil.MMDDYYYY);
			xmlElement.SetAttributeNode(xmlAttribute);	
	
			//totals
			xmlAttribute = xmlDoc.CreateAttribute(FieldD_TotalDiscounts);
			xmlAttribute.Value =  NumberUtil.toString(this.getTotalDiscounts());
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_TotalPromo);
			xmlAttribute.Value =  NumberUtil.toString(this.getTotalPromo());
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_TotalRoyalty);
			xmlAttribute.Value =  NumberUtil.toString(this.getTotalRoyalty());
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_TotalFreight);
			xmlAttribute.Value =  NumberUtil.toString(this.getTotalFreight());
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_TotalTax);
			xmlAttribute.Value =  NumberUtil.toString(this.getTotalTax());
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_TotalStTax);
			xmlAttribute.Value =  NumberUtil.toString(this.getTotalStTax());
			xmlElement.SetAttributeNode(xmlAttribute);

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_TotalFedTax);
			xmlAttribute.Value =  NumberUtil.toString(this.getTotalFedTax());
			xmlElement.SetAttributeNode(xmlAttribute);		
	
			xmlAttribute = xmlDoc.CreateAttribute(FieldD_ErpOrderNum);
			xmlAttribute.Value =  Converter.fixString(this.getErpOrderNum());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_ErpOrderItemNum);
			xmlAttribute.Value =  this.getErpOrderItemNum().ToString();
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_QtyPackSize);
			xmlAttribute.Value =  NumberUtil.toString(this.getQtyPackSize());
			xmlElement.SetAttributeNode(xmlAttribute);		

			xmlAttribute = xmlDoc.CreateAttribute(FieldD_Cost);
			xmlAttribute.Value =  NumberUtil.toString(this.getCost());
			xmlElement.SetAttributeNode(xmlAttribute);		
	

			//Add the node to the document.
			root.AppendChild(xmlElement);			

			//details
			for (j=0; j < this.getCountLines();j++)
			{
				root = xmlDoc.DocumentElement;			

				OrderDtlRel orderDtlRel = this.getDltRelByIndex(j);
				xmlDoc = orderDtlRel.toXml(xmlDoc);
			}			
			//charges			
			for (j=0; j < this.getCountCharges();j++)
			{
				root = xmlDoc.DocumentElement;			

				OrderDtlCharge orderDtlCharge = this.getDltChargeByIndex(j);
				xmlDoc = orderDtlCharge.toXml(xmlDoc);
			}				

			xmlDoc = noteList.toXml(xmlDoc);
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
		
			if (xmlAttribCollection[i].Name.Equals(FieldD_HID))
				this.ihId = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldD_ID))
				this.id = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldD_Db))
				this.sdb = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldD_Company))
				this.scompany = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldD_Plant))
				this.splant = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldD_OrderNum))
				this.iorderNum = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldD_ItemNum))
				this.itemNum = int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldD_OrgId))
				this.sorgId = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldD_OrgItemNum))
				this.sorgItemNum = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldD_ProdID))
				this.sprodID = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldD_ProdDescription))
				this.sprodDescription = xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldD_Seq))
				this.iseq= int.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldD_InternalRef))
				this.sinternalRef= xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldD_CustPart))
				this.scustPart= xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldD_CustPO))
				this.scustPO= xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldD_QtyOrdSum))
				this.dqtyOrdSum= double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldD_QtyShippedSum))
				this.dqtyShippedSum= double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldD_QtyOrdUom))
				this.sqtyOrdUom= xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldD_UnitPrice))
				this.dunitPrice= double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldD_UnitPriceUom))
				this.sunitPriceUom= xmlAttribCollection[i].Value;
			else if (xmlAttribCollection[i].Name.Equals(FieldD_ItemNetTotal))
				this.ditemNetTotal= double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldD_DateAdded))			
				this.DateAdded = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);
			else if (xmlAttribCollection[i].Name.Equals(FieldD_TotalDiscounts))
				this.dtotalDiscounts= double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldD_TotalPromo))
				this.dtotalPromo= double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldD_TotalRoyalty))
				this.dtotalRoyalty= double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldD_TotalFreight))
				this.dtotalFreight= double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldD_TotalTax))
				this.dtotalTax= double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldD_TotalStTax))
				this.dtotalStTax= double.Parse(xmlAttribCollection[i].Value);
			else if (xmlAttribCollection[i].Name.Equals(FieldD_TotalFedTax))
				this.dtotalFedTax= double.Parse(xmlAttribCollection[i].Value);	
			else if (xmlAttribCollection[i].Name.Equals(FieldD_ErpOrderNum))
				this.serpOrderNum= xmlAttribCollection[i].Value;	
			else if (xmlAttribCollection[i].Name.Equals(FieldD_ErpOrderItemNum))
				this.ierpOrderItemNum= int.Parse(xmlAttribCollection[i].Value);		
			else if (xmlAttribCollection[i].Name.Equals(FieldD_QtyPackSize))
				this.dqtyPackSize= double.Parse(xmlAttribCollection[i].Value);		
			else if (xmlAttribCollection[i].Name.Equals(FieldD_Cost))
				this.dcost= double.Parse(xmlAttribCollection[i].Value);					
		}
	}
	catch (XmlException ex)
	{
		bresult=false;
		throw new NujitException("Error in class OrderHeader  <toXml> : " + ex.Message);		
	}   

	return bresult;
}


public
string getXmlHeader()
{
	return "ORDERDTL";
}	
#endif

public 
void addDtlRel(OrderDtlRel orderDtlRel)
{
	this.arrayOrderDtlRel.Add(orderDtlRel);	
}	

public 
void addDtlCharge(OrderDtlCharge orderDtlCharge)
{
	this.arrayOrderDtlCharges.Add(orderDtlCharge);	
}	

public 
void addNote(Note note)
{
	noteList.addNote(note);	
}

public 
OrderDtlCharge createDtlCharge(Discount discount,Person billPerson)
{
	OrderDtlCharge orderDtlCharge= new OrderDtlCharge();
	
	orderDtlCharge.setDb("");

	orderDtlCharge.setHId(this.ihId);
	orderDtlCharge.setOrderNum(this.iorderNum);
	orderDtlCharge.setItemNum (this.itemNum);
	orderDtlCharge.setItemChgNum(0);//temporal value

	orderDtlCharge.setChargeCode(discount.getDiscCode());
	orderDtlCharge.setChargeDesc(discount.getDiscDes());
	orderDtlCharge.setChargeType(discount.getDrCr());
	orderDtlCharge.setChargeTypeSub("");
	orderDtlCharge.setBaseNet(discount.getBaseNet());
	orderDtlCharge.setFixedUnit(discount.getFixedUnit());
	orderDtlCharge.setSaleCOS(discount.getSalesCode());
	orderDtlCharge.setAmount(discount.getDiscAmount());
	orderDtlCharge.setMaxAmount(discount.getDiscAmount());

	orderDtlCharge.setBeforeTax("");
	orderDtlCharge.setBeforeFreight("");
	orderDtlCharge.setBeforeDiscount("");
	orderDtlCharge.setPercent(discount.getDiscRate());
	orderDtlCharge.setExtension(0);

	orderDtlCharge.setApplytoCust(billPerson.getId());
	orderDtlCharge.setApplytoSupplier("");
	orderDtlCharge.setGLAccountNum(0);
	orderDtlCharge.setOnSalePaidInv(Constants.STRING_NO);
	orderDtlCharge.setPaid(Constants.STRING_NO);
	orderDtlCharge.setReceived(Constants.STRING_NO);

	return orderDtlCharge;
}	

public 
OrderDtlRel createDtlRel(Person billPerson,Person shipPerson)
{
	OrderDtlRel orderDtlRel = new OrderDtlRel();

	orderDtlRel.setHId(this.ihId);
	orderDtlRel.setOrderNum(this.iorderNum);
	orderDtlRel.setItemNum(this.itemNum);
	orderDtlRel.setItemNumRel(0);//temporal value
	orderDtlRel.setOrgItemNum(this.sorgItemNum);		

	//person
	orderDtlRel.setShipToNum(shipPerson.getId());
	orderDtlRel.setShipToName(shipPerson.getName());
	orderDtlRel.setCustPO(this.getCustPO());
	
	//address
	orderDtlRel.setShipToAdd1(shipPerson.getAddress1());
	orderDtlRel.setShipToAdd2(shipPerson.getAddress2());
	orderDtlRel.setShipToAdd3(shipPerson.getAddress3());
	orderDtlRel.setPhoneNum(shipPerson.getPhone());	
	orderDtlRel.setPlant(shipPerson.getPlt());

	//date
	orderDtlRel.setDateAdded(this.DateAdded);		
	
	//product
	orderDtlRel.setQtyOrd(this.dqtyOrdSum);
	orderDtlRel.setProdDescription(this.getProdDescription());
	
	return orderDtlRel;
}	


public 
OrderDtlRel getDltRelByIndex(int index)
{
	OrderDtlRel orderDtlRel=null;

	if (index < arrayOrderDtlRel.Count)
		return (OrderDtlRel)arrayOrderDtlRel[index];

	return (orderDtlRel);	
}	

public 
Note getNoteByIndex(int index)
{
	return noteList.getNoteByIndex(index);
}

public
IEnumerator getDtlRelsEnumerator()
{
	return arrayOrderDtlRel.GetEnumerator();
}

public 
OrderDtlCharge getDltChargeByIndex(int index)
{
	OrderDtlCharge orderDtlCharge=null;

	if (index < arrayOrderDtlCharges.Count)
		return (OrderDtlCharge)arrayOrderDtlCharges[index];

	return (orderDtlCharge);	
}	

public
IEnumerator getDtlChargesEnumerator()
{
	return arrayOrderDtlCharges.GetEnumerator();
}

public 
bool removeDltRelByIndex(int index)
{
	bool	bresult=false;
	
	if (index < arrayOrderDtlRel.Count)
	{
		arrayOrderDtlRel.RemoveAt(index);
		bresult=true;
	}	

	return bresult;	
}

public 
bool removeDltChargeByIndex(int index)
{
	bool	bresult=false;
	
	if (index < arrayOrderDtlCharges.Count)
	{
		arrayOrderDtlCharges.RemoveAt(index);
		bresult=true;
	}	

	return bresult;	
}		

public 
void removeAllDltCharge()
{
	if (arrayOrderDtlCharges.Count > 0)
	{
		arrayOrderDtlCharges.Clear();		
	}		
}		

public 
void removeAllDltRel()
{
	if (arrayOrderDtlRel.Count > 0)
	{
		arrayOrderDtlRel.Clear();		
	}		
}		

public 
void removeAllNotes()
{
	noteList.removeAllNotes();		
}	

public 
int getCountLines()
{
	return arrayOrderDtlRel.Count;
}	

public 
int getCountCharges()
{
	return arrayOrderDtlCharges.Count;
}	

public void recalculate()
{
	ditemNetTotal = dqtyOrdSum * dunitPrice;
	double parcTotal = ditemNetTotal;
	IEnumerator enu = arrayOrderDtlCharges.GetEnumerator();
	while (enu.MoveNext())
	{
		OrderDtlCharge orderDtlCharge = (OrderDtlCharge)enu.Current;
		if (orderDtlCharge.getPercent() > 0)
		{
			if (orderDtlCharge.getBaseNet().Equals(Constants.DISCOUNT_TYPE_TOTAL_BASE))
				orderDtlCharge.setExtension(ditemNetTotal * orderDtlCharge.getPercent() / 100);
			else
				orderDtlCharge.setExtension(parcTotal * orderDtlCharge.getPercent() / 100);
		}
		else
		{
			if (orderDtlCharge.getFixedUnit().Equals(Constants.DISCOUNT_TYPE_FIXEDUNIT_ALL))
				orderDtlCharge.setExtension(orderDtlCharge.getAmount());
			else
				orderDtlCharge.setExtension(orderDtlCharge.getAmount() * dqtyOrdSum);
		}
		parcTotal -= orderDtlCharge.getExtension();
	}
	dtotalDiscounts = ditemNetTotal - parcTotal;
//	ditemNetTotal = parcTotal;
	dqtyShippedSum = 0;
	dqtyOrdSum = 0;
	enu = arrayOrderDtlRel.GetEnumerator();
	while (enu.MoveNext())
	{
		dqtyShippedSum += ((OrderDtlRel)enu.Current).getQtyShipped();
		dqtyOrdSum += ((OrderDtlRel)enu.Current).getQtyOrd();
	}

	if (dtotalDiscounts > ditemNetTotal)//if the discounts is greater than the total net
		dtotalDiscounts = ditemNetTotal;//set the max discount	
}

public void addNewDtlCharge (OrderDtlCharge orderDtlCharge)
{
	if (arrayOrderDtlCharges.Count == 0)
		orderDtlCharge.setItemChgNum(1);
	else
		orderDtlCharge.setItemChgNum(((OrderDtlCharge)arrayOrderDtlCharges[arrayOrderDtlCharges.Count-1]).getItemChgNum()+1);
	arrayOrderDtlCharges.Add(orderDtlCharge);
}

public void addNewDtlRel (OrderDtlRel orderDtlRel)
{
	if (arrayOrderDtlRel.Count == 0)
		orderDtlRel.setItemNumRel(1);
	else
		orderDtlRel.setItemNumRel(((OrderDtlRel)arrayOrderDtlRel[arrayOrderDtlRel.Count-1]).getItemNumRel() +1);
	arrayOrderDtlRel.Add(orderDtlRel);
}

public void addNewNote (Note note)
{
	noteList.addNewNote(note);	
}

public 
Note createNote(string snote)
{
	Note note= new Note();

	note.setType(Constants.NOTE_TYPE_ORDER_DTL);
	note.setKey1(this.getHId());
	note.setKey2(this.getItemNum());
	note.setKey3(int.MinValue);

	return note;
}

public OrderDtlRel getDtlRelByID (int itemNum)
{
	IEnumerator enu = arrayOrderDtlRel.GetEnumerator();
	while (enu.MoveNext())
	{
		if (itemNum.Equals(((OrderDtlRel)enu.Current).getItemNumRel()))
			return (OrderDtlRel)enu.Current;
	}
	return null;
}

public Note getNoteByID (int ilineNum)
{
	return noteList.getNoteByID(ilineNum);	
}

public bool removeDtlRelByID (int itemNum)
{
	int i=0;
	bool found = false;
	while ((i<arrayOrderDtlRel.Count) && (!found))
	{
		if (itemNum.Equals(((OrderDtlRel)arrayOrderDtlRel[i]).getItemNumRel()))
		{
			found = true;
			arrayOrderDtlRel.RemoveAt(i);
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
bool hasDtlCharge (string chargeCode)
{
	IEnumerator enu = arrayOrderDtlCharges.GetEnumerator();
	while (enu.MoveNext())
	{
		if (((OrderDtlCharge)enu.Current).getChargeCode().Equals(chargeCode))
			return true;
	}
	return false;
}

public
bool hasDtlRel (string shipToNum)
{
	IEnumerator enu = arrayOrderDtlRel.GetEnumerator();
	while (enu.MoveNext())
	{
		if (((OrderDtlRel)enu.Current).getShipToNum().Equals(shipToNum))
			return true;
	}
	return false;
}

public
IEnumerator getNoteEnumerator()
{
	return noteList.getNoteEnumerator();
}

public 
int getCountNotes()
{
	return noteList.getCountNotes();
}	

} // class

} // namespace



