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
	BusinessObject{
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
private int         assignShift;
private int         assignOTShift;
private string      dftDept;
private DateTime    lastLabourDate;
private int         dftLabourTypeId;

private string      tagNumber;
private int         dftMachId;
        

private bool        childsRead=false;
private string      dftLabourTypeNameShow;
private DateTime    approvDateShow;
private DateTime    approvUntilDateShow;
private bool        selectedShow;
private string      machShow;
private string      flagShow;

private EmployeeLabourContainer employeeLabourContainer;

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
    this.assignShift = 0;
    this.assignOTShift = 0;
    this.dftDept = "";
    this.lastLabourDate = DateUtil.MinValue;

    this.tagNumber = "";
    this.dftMachId = 0;

    this.dftLabourTypeId = 0;
    this.approvDateShow = DateUtil.MinValue;
    this.approvUntilDateShow = DateUtil.MinValue;
    this.selectedShow = false;
    this.machShow = "";
    this.flagShow = Constants.STRING_NO;

    this.employeeLabourContainer = new EmployeeLabourContainer();
}

public 
Employee(string id, string firstName, string lastName, string login,
				string password, string status,
				string deptCode, string postion,
				string companyExt, string homePhone,
				string cellPhone, string email,
				string comment, string styleSheet,
				int rowsPerPage, string isSalesRep,
				DateTime dateUpdated,int assignShift,int assignOTShift,
                string dftDept,DateTime lastLabourDate,int dftLabourTypeId,
                string tagNumber,int dftMachId){

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
    this.assignShift = assignShift;
    this.assignOTShift = assignOTShift;
    this.dftDept = dftDept;
    this.lastLabourDate = lastLabourDate;
    this.dftLabourTypeId = dftLabourTypeId;

    this.approvDateShow = DateUtil.MinValue;
    this.approvUntilDateShow = DateUtil.MinValue;
    this.selectedShow = false;
    this.flagShow = Constants.STRING_NO;

    this.tagNumber = tagNumber;
    this.dftMachId = dftMachId;

    this.employeeLabourContainer = new EmployeeLabourContainer();
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

[System.Runtime.Serialization.DataMember]
public
string Id {
	get { return id;}
	set { if (this.id != value){
			this.id = value;
			Notify("Id");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FirstName {
	get { return firstName;}
	set { if (this.firstName != value){
			this.firstName = value;
			Notify("FirstName");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string LastName {
	get { return lastName;}
	set { if (this.lastName != value){
			this.lastName = value;
			Notify("LastName");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Login {
	get { return login;}
	set { if (this.login != value){
			this.login = value;
			Notify("Login");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Password {
	get { return password;}
	set { if (this.password != value){
			this.password = value;
			Notify("Password");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Status {
	get { return status;}
	set { if (this.status != value){
			this.status = value;
			Notify("Status");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string DeptCode {
	get { return deptCode;}
	set { if (this.deptCode != value){
			this.deptCode = value;
			Notify("DeptCode");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Postion {
	get { return postion;}
	set { if (this.postion != value){
			this.postion = value;
			Notify("Postion");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string CompanyExt {
	get { return companyExt;}
	set { if (this.companyExt != value){
			this.companyExt = value;
			Notify("CompanyExt");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HomePhone {
	get { return homePhone;}
	set { if (this.homePhone != value){
			this.homePhone = value;
			Notify("HomePhone");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string CellPhone {
	get { return cellPhone;}
	set { if (this.cellPhone != value){
			this.cellPhone = value;
			Notify("CellPhone");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Email {
	get { return email;}
	set { if (this.email != value){
			this.email = value;
			Notify("Email");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Comment {
	get { return comment;}
	set { if (this.comment != value){
			this.comment = value;
			Notify("Comment");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string StyleSheet {
	get { return styleSheet;}
	set { if (this.styleSheet != value){
			this.styleSheet = value;
			Notify("StyleSheet");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int RowsPerPage {
	get { return rowsPerPage;}
	set { if (this.rowsPerPage != value){
			this.rowsPerPage = value;
			Notify("RowsPerPage");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string IsSalesRep {
	get { return isSalesRep;}
	set { if (this.isSalesRep != value){
			this.isSalesRep = value;
			Notify("IsSalesRep");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime DateUpdated {
	get { return dateUpdated;}
	set { if (this.dateUpdated != value){
			this.dateUpdated = value;
			Notify("DateUpdated");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int AssignShift {
	get { return assignShift; }
	set { if (this.assignShift != value){
			this.assignShift = value;
			Notify("AssignShift");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int AssignOTShift {
	get { return assignOTShift; }
	set { if (this.assignOTShift != value){
			this.assignOTShift = value;
			Notify("AssignOTShift");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string DftDept {
	get { return dftDept; }
	set { if (this.dftDept != value){
			this.dftDept = value;
			Notify("DftDept");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime LastLabourDate {
	get { return lastLabourDate; }
	set { if (this.lastLabourDate != value){
			this.lastLabourDate = value;
			Notify("LastLabourDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int DftLabourTypeId {
	get { return dftLabourTypeId; }
	set { if (this.dftLabourTypeId != value){
			this.dftLabourTypeId = value;
			Notify("DftLabourTypeId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string DftLabourTypeNameShow {
	get { return dftLabourTypeNameShow; }
	set { if (this.dftLabourTypeNameShow != value){
			this.dftLabourTypeNameShow = value;
			Notify("DftLabourTypeNameShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime ApprovDateShow {
	get { return approvDateShow; }
	set { if (this.approvDateShow != value){
			this.approvDateShow = value;
			Notify("ApprovDateShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime ApprovUntilDateShow {
	get { return approvUntilDateShow; }
	set { if (this.approvUntilDateShow != value){
			this.approvUntilDateShow = value;
			Notify("ApprovUntilDateShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string TagNumber {
	get { return tagNumber; }
	set { if (this.tagNumber != value){
			this.tagNumber = value;
			Notify("TagNumber");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int DftMachId {
	get { return dftMachId; }
	set { if (this.dftMachId != value){
			this.dftMachId = value;
			Notify("DftMachId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FullName{
	get { return FirstName+" " + LastName; }
	set { 
	}
}
       
public override
bool Equals(object obj){
	if (obj is Employee)
		return	this.Id.Equals(((Employee)obj).Id);
	else
		return false;
}


[System.Runtime.Serialization.DataMember]
public
EmployeeLabourContainer EmployeeLabourContainer {
	get { return employeeLabourContainer; }
	set { if (this.employeeLabourContainer != value){
			this.employeeLabourContainer = value;
			Notify("EmployeeLabourContainer");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool ChildsRead {
	get { return childsRead;}
	set { if (this.childsRead != value){
			this.childsRead = value;
			Notify("ChildsRead");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
bool SelectedShow {
	get { return selectedShow; }
	set { if (this.selectedShow != value){
			this.selectedShow = value;
			Notify("selectedShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MachShow {
	get { return machShow; }
	set { if (this.machShow != value){
			this.machShow = value;
			Notify("MachShow");
		}
	}
}

public
string FlagShow {
	get { return flagShow; }
	set { if (this.flagShow != value){
			this.flagShow = value;
			Notify("FlagShow");
		}
	}
}

public
void fillRedundances(){
    int i=0;
    for (i=0; i < employeeLabourContainer.Count;i++){
        EmployeeLabour employeeLabour = employeeLabourContainer[i];
        employeeLabour.EmpId= Id;
    }

}


}//end Class

}//end sdeptCodespace
