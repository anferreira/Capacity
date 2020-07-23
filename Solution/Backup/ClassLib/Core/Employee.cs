using System;
using Nujit.NujitERP.ClassLib.Util;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.Core{


public 
class Employee  :
#if OE_SYNC
	Serializable{
#else
	MarshalByRefObject{
#endif

private string		id;
private string		firstName;
private string		lastName;
private string		login;
private string		password;
private string		status;
private string		deptCode;
private string		postion;
private string		companyExt;
private string		homePhone;
private string		cellPhone;
private string		email;
private string		comment;
private string		styleSheet;
private int			rowsPerPage;
private string		isSalesRep;
private DateTime	dateUpdated;

#if OE_SYNC
public  const string ID				= "f1";
public  const string FIRST_NAME		= "f2";
public  const string LAST_NAME		= "f3";
public  const string LOGIN			= "f4";
public  const string PASSWORD		= "f5";
public  const string STATUS			= "f6";
public  const string DEPT_CODE		= "f7";
public  const string POSITION		= "f8";
public  const string COMPANY_EXT	= "f9";
public  const string HOME_PHONE		= "f10";
public  const string CELL_PHONE		= "f11";
public  const string EMAIL			= "f12";
public  const string COMMENT		= "f13";
public  const string STYLE_SHEET	= "f14";
public  const string ROWS_PER_PAGE	= "f15";
public  const string IS_SALES_REP	= "f16";
public  const string PERSON_CLASS	= "f17";
public  const string DATE_UPDATED	= "f18";
#endif
	
public 
Employee(){
	this.id = "";
	this.firstName = "";
	this.lastName = "";
	this.password = "";
	this.status = "";
	this.deptCode = "";
	this.postion = "";
	this.companyExt = "";
	this.homePhone = "";
	this.cellPhone = "";
	this.email = "";
	this.comment = "";
	this.styleSheet = "";	
	this.login = "";
	this.rowsPerPage = 0;
	this.isSalesRep = Constants.STRING_NO;	
	this.dateUpdated = DateTime.Today;
}

public 
Employee(string id, string firstName, string lastName, string login,
				string password, string status,
				string deptCode, string postion,
				string companyExt, string homePhone,
				string cellPhone, string email,
				string comment, string styleSheet,
				int rowsPerPage, string isSalesRep,
				DateTime dateUpdated){

	this.id = id;
	this.firstName = firstName;
	this.lastName = lastName;
	this.login = login;
	this.password = password;
	this.status = status;
	this.deptCode = deptCode;
	this.postion = postion;
	this.companyExt = companyExt;
	this.homePhone = homePhone;
	this.cellPhone = cellPhone;
	this.email = email;
	this.comment = comment;
	this.styleSheet	= styleSheet;		
	this.rowsPerPage = rowsPerPage;
	this.isSalesRep = isSalesRep;		
	this.dateUpdated = dateUpdated;
}

public
void setId(string id){
	this.id = id;
}

public
void setFirstName(string firstName){
	this.firstName = firstName;
}

public
void setLastName(string lastName){
	this.lastName = lastName;
}

public
void setPassword(string password){
	this.password = password;
}

public
void setStatus(string status){
	this.status = status;
}

public
void setDeptCode(string deptCode){
	this.deptCode = deptCode;
}

public
void setPostion(string postion){
	this.postion = postion;
}

public
void setCompanyExt(string companyExt){
	this.companyExt = companyExt;
}

public
void setHomePhone(string homePhone){
	this.homePhone = homePhone;
}

public
void setCellPhone(string cellPhone){
	this.cellPhone = cellPhone;
}

public
void setEmail(string email){
	this.email = email;
}

public
void setComment(string comment){
	this.comment = comment;
}

public
void setStyleSheet(string styleSheet){
	this.styleSheet = styleSheet;
}

public
void setLogin(string login){
	this.login = login;
}

public 
void setRowsPerPage(int rowsPerPage){
	this.rowsPerPage = rowsPerPage;
}

public
void setIsSalesRep(string isSalesRep){
	this.isSalesRep = isSalesRep;
}

public
void setDateUpdated(DateTime dateUpdated){
	this.dateUpdated = dateUpdated;
}


public
string getId(){
	return id;
}

public
string getFirstName(){
	return firstName;
}

public
string getLastName(){
	return lastName;
}

public
string getPassword(){
	return password;
}

public
string getStatus(){
	return status;
}

public
string getDeptCode(){
	return deptCode;
}

public
string getPostion(){
	return postion;
}

public
string getCompanyExt(){
	return companyExt;
}

public
string getHomePhone(){
	return homePhone;
}

public
string getCellPhone(){
	return cellPhone;
}

public
string getEmail(){
	return email;
}

public
string getComment(){
	return comment;
}

public
string getStyleSheet(){
	return styleSheet;
}
	
public
string getLogin(){
	return login;
}

public
int getRowsPerPage(){
	return rowsPerPage;
}

public
string getIsSalesRep(){
	return isSalesRep;
}

public
DateTime getDateUpdated(){
	return dateUpdated;
}

#if OE_SYNC
public 
XmlDocument toXml(){
	string sxml;
	XmlDocument	xmlDoc = new XmlDocument();
	XmlElement	xmlElement = xmlDoc.DocumentElement;
	XmlAttribute xmlAttribute = null;
					
	try{				
		sxml = "<" + getXmlHeader() + "></" + getXmlHeader() + ">";
		xmlDoc.LoadXml(sxml); 	

		xmlAttribute = xmlDoc.CreateAttribute(ID);
		xmlAttribute.Value = this.id;
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(FIRST_NAME);
		xmlAttribute.Value = Converter.fixString(this.firstName);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(LAST_NAME);
		xmlAttribute.Value = Converter.fixString(this.lastName);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(LOGIN);
		xmlAttribute.Value = this.login;
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(PASSWORD);
		xmlAttribute.Value = this.password;
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(STATUS);
		xmlAttribute.Value = Converter.fixString(this.status);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(DEPT_CODE);
		xmlAttribute.Value = Converter.fixString(this.deptCode);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(POSITION);
		xmlAttribute.Value = Converter.fixString(this.postion);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(COMPANY_EXT);
		xmlAttribute.Value = Converter.fixString(this.companyExt);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(HOME_PHONE);
		xmlAttribute.Value = Converter.fixString(this.homePhone);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(CELL_PHONE);
		xmlAttribute.Value = Converter.fixString(this.cellPhone);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(EMAIL);
		xmlAttribute.Value = Converter.fixString(this.email);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(COMMENT);
		xmlAttribute.Value = Converter.fixString(this.comment);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(STYLE_SHEET);
		xmlAttribute.Value = Converter.fixString(this.styleSheet);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(ROWS_PER_PAGE);
		xmlAttribute.Value = this.rowsPerPage.ToString();
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);

		xmlAttribute = xmlDoc.CreateAttribute(IS_SALES_REP);
		xmlAttribute.Value = Converter.fixString(this.isSalesRep);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);
				
		xmlAttribute = xmlDoc.CreateAttribute(DATE_UPDATED);
		xmlAttribute.Value = DateUtil.getCompleteDateRepresentation(this.dateUpdated, DateUtil.MMDDYYYY);
		xmlDoc.DocumentElement.SetAttributeNode(xmlAttribute);
	}catch(XmlException ex){
		xmlDoc=null;//error
		throw new NujitException("Error in class Employee  <toXml> : " + ex.Message);		
	}
			
	return xmlDoc;
}

public 
bool Parse(XmlDocument xmlDocument){
	bool bresult = false;

	try{		
		XmlAttributeCollection xmlAttribCollection = xmlDocument.DocumentElement.Attributes;
		//read all of the attribute
		for (int i=0; i < xmlAttribCollection.Count; i++){
			bresult=true;			

			if (xmlAttribCollection[i].Name.Equals(ID))
				this.id = xmlAttribCollection[i].Value;
			if (xmlAttribCollection[i].Name.Equals(FIRST_NAME))
				this.firstName = xmlAttribCollection[i].Value; 
			if (xmlAttribCollection[i].Name.Equals(LAST_NAME))
				this.lastName = xmlAttribCollection[i].Value; 
			if (xmlAttribCollection[i].Name.Equals(LOGIN))
				this.login = xmlAttribCollection[i].Value; 
			if (xmlAttribCollection[i].Name.Equals(PASSWORD))
				this.password = xmlAttribCollection[i].Value; 
			if (xmlAttribCollection[i].Name.Equals(STATUS))
				this.status = xmlAttribCollection[i].Value; 			
			if (xmlAttribCollection[i].Name.Equals(DEPT_CODE))
				this.deptCode = xmlAttribCollection[i].Value; 
			if (xmlAttribCollection[i].Name.Equals(POSITION))
				this.postion = xmlAttribCollection[i].Value; 
			if (xmlAttribCollection[i].Name.Equals(COMPANY_EXT))
				this.companyExt = xmlAttribCollection[i].Value; 
			if (xmlAttribCollection[i].Name.Equals(HOME_PHONE))
				this.homePhone = xmlAttribCollection[i].Value; 
			if (xmlAttribCollection[i].Name.Equals(CELL_PHONE))
				this.cellPhone = xmlAttribCollection[i].Value; 
			if (xmlAttribCollection[i].Name.Equals(EMAIL))
				this.email = xmlAttribCollection[i].Value; 
			if (xmlAttribCollection[i].Name.Equals(COMMENT))
				this.comment = xmlAttribCollection[i].Value; 
			if (xmlAttribCollection[i].Name.Equals(STYLE_SHEET))
				this.styleSheet = xmlAttribCollection[i].Value; 
			if (xmlAttribCollection[i].Name.Equals(ROWS_PER_PAGE))
				this.rowsPerPage = int.Parse(xmlAttribCollection[i].Value); 
			if (xmlAttribCollection[i].Name.Equals(IS_SALES_REP))
				this.isSalesRep = xmlAttribCollection[i].Value;
			if (xmlAttribCollection[i].Name.Equals(DATE_UPDATED))
				this.dateUpdated = DateUtil.parseCompleteDate(xmlAttribCollection[i].Value,DateUtil.MMDDYYYY);
		}
	}catch(XmlException ex){
		bresult=false;
		throw new NujitException("Error in class Employee  <toXml> : " + ex.Message);		
	}   

	return bresult;
}

public
string getXmlHeader(){
	return "EMPLOYEE";
}	
#endif
}//end Class

}//end sdeptCodespace
