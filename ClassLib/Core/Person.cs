using System;
using Nujit.NujitERP.ClassLib.Util;


namespace Nujit.NujitERP.ClassLib.Core{

public 
class Person : BusinessObject{

public const string TYPE_CUSTOMER		= "C";
public const string TYPE_VENDOR			= "V";

public const string CUSTOMER_TYPE_BILLTO= "B";
public const string CUSTOMER_TYPE_SHIPTO= "S";

private string plt;
private string id;
private string recType;
private string customerType;
private string status;
private string name;
private string address1;
private string address2;
private string address3;
private string address4;
private string address5;
private string address6;
private string address7;
private string address8;
private string phone;
private string fax;
private string webPage;
private string country;
private string state_Prov;
private string currency;
private string territory;
private string personClass;
private DateTime dateCreated;
private DateTime dateUpdated;
private string billToCust;
private string zipCode;
private string tPartner;

public 
Person(){
	this.plt = "";
	this.id = "";
	this.recType = "";
	this.customerType = "";
	this.status = "";
	this.name = "";
	this.address1 = "";
	this.address2 = "";
	this.address3 = "";
	this.address4 = "";
	this.address5 = "";
	this.address6 = "";
	this.address7 = "";
	this.address8 = "";
	this.phone = "";
	this.fax = "";
	this.webPage = "";
	this.country = "";
	this.state_Prov = "";
	this.currency = "";
	this.territory = "";
	this.personClass = "";
	this.dateCreated = DateTime.Today;
	this.dateUpdated = DateTime.Today;
	this.billToCust = "";
	this.zipCode = "";
    this.tPartner = "";
}

public 
Person(string plt, string id, string recType, string customerType,
		string status, string name, string address1, string address2,
		string address3, string address4, string address5, string address6,
		string address7, string address8, string phone, string fax, 
		string webPage,	string country, string state_Prov, string currency,
		string territory, string personClass, DateTime dateCreated,
		DateTime dateUpdated, string billToCust, string zipCode,string tPartner)
        {

	this.plt = plt;
	this.id = id;
	this.recType = recType;
	this.customerType = customerType;
	this.status = status;
	this.name = name;
	this.address1 = address1;
	this.address2 = address2;
	this.address3 = address3;
	this.address4 = address4;
	this.address5 = address5;
	this.address6 = address6;
	this.address7 = address7;
	this.address8 = address8;
	this.phone = phone;
	this.fax = fax;
	this.webPage = webPage;
	this.country = country;
	this.state_Prov = state_Prov;
	this.currency = currency;
	this.territory = territory;
	this.personClass = personClass;
	this.dateCreated = dateCreated;
	this.dateUpdated = dateUpdated;
	this.billToCust = billToCust;
	this.zipCode = zipCode;
    this.tPartner = tPartner;
}

public
void setPlt(string plt){
	this.plt = plt;
}

public
void setId(string id){
	this.id = id;
}

public
void setRecType(string recType){
	this.recType = recType;
}

public
void setCustomerType(string customerType){
	this.customerType = customerType;
}

public
void setStatus(string status){
	this.status = status;
}

public
void setName(string name){
	this.name = name;
}

public
void setAddress1(string address1){
	this.address1 = address1;
}

public
void setAddress2(string address2){
	this.address2 = address2;
}

public
void setAddress3(string address3){
	this.address3 = address3;
}

public
void setAddress4(string address4){
	this.address4 = address4;
}

public
void setAddress5(string address5){
	this.address5 = address5;
}

public
void setAddress6(string address6){
	this.address6 = address6;
}

public
void setAddress7(string address7){
	this.address7 = address7;
}

public
void setAddress8(string address8){
	this.address8 = address8;	
}

public
void setPhone(string phone){
	this.phone = phone;
}

public
void setFax(string fax){
	this.fax = fax;
}

public
void setWebPage(string webPage){
	this.webPage = webPage;
}

public
void setCountry(string country){
	this.country = country;
}

public
void setState_Prov(string state_Prov){
	this.state_Prov = state_Prov;
}

public
void setCurrency(string currency){
	this.currency = currency;
}

public
void setTerritory(string territory){
	this.territory = territory;
}

public
void setPersonClass(string personClass){
	this.personClass = personClass;
}

public
void setDateCreated(DateTime dateCreated){
	this.dateCreated = dateCreated;
}

public
void setDateUpdated(DateTime dateUpdated){
	this.dateUpdated = dateUpdated;
}

public
void setBillToCust(string billToCust){
	this.billToCust = billToCust;
}

public
void setZipCode(string zipCode){
	this.zipCode = zipCode;
}


public
string getPlt(){
	return plt;
}

public
string getId(){
	return id;
}

public
string getRecType(){
	return recType;
}

public
string getCustomerType(){
	return customerType;
}

public
string getStatus(){
	return status;
}

public
string getName(){
	return name;
}

public
string getAddress1(){
	return address1;
}

public
string getAddress2(){
	return address2;
}

public
string getAddress3(){
	return address3;
}

public
string getAddress4(){
	return address4;
}

public
string getAddress5(){
	return address5;
}

public
string getAddress6(){
	return address6;
}

public
string getAddress7(){
	return address7;
}

public
string getAddress8(){
	return address8;
}

public
string getPhone(){
	return phone;
}

public
string getFax(){
	return fax;
}

public
string getWebPage(){
	return webPage;
}

public
string getCountry(){
	return country;
}

public
string getState_Prov(){
	return state_Prov;
}

public
string getCurrency(){
	return currency;
}

public
string getTerritory(){
	return territory;
}

public
string getPersonClass(){
	return personClass;
}

public
DateTime getDateCreated(){
	return dateCreated;
}

public
DateTime getDateUpdated(){
	return dateUpdated;
}

public
string getBillToCust(){
	return billToCust;
}

public
string getZipCode(){
	return zipCode;
}

#region Properties

[System.Runtime.Serialization.DataMember]
public
string Id
{
    get { return this.id; }
    set
    {
        if (this.id != value)
        {
            this.id = value;
            //Notify("Id");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string RecType
{
    get { return this.recType; }
    set
    {
        if (this.recType != value)
        {
            this.recType = value;
            //Notify("RecType");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string CustomerType{
    get { return this.customerType; }
    set {
        if (this.customerType != value){
            this.customerType = value;
            //Notify("customerType");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string Status
{
    get { return this.status; }
    set
    {
        if (this.status != value)
        {
            this.status = value;
            //Notify("Status");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string Name
{
    get { return this.name; }
    set
    {
        if (this.name != value)
        {
            this.name = value;
            //Notify("Name");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string Address1
{
    get { return this.address1; }
    set
    {
        if (this.address1 != value)
        {
            this.address1 = value;
            //Notify("Address1");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string Address2
{
    get { return this.address2; }
    set
    {
        if (this.address2 != value)
        {
            this.address2 = value;
            //Notify("Address2");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string Address3
{
    get { return this.address3; }
    set
    {
        if (this.address3 != value)
        {
            this.address3 = value;
            //Notify("Address3");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string Address4
{
    get { return this.address4; }
    set
    {
        if (this.address4 != value)
        {
            this.address4 = value;
            //Notify("Address4");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string Address5
{
    get { return this.address5; }
    set
    {
        if (this.address5 != value)
        {
            this.address5 = value;
            //Notify("Address5");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string Address6
{
    get { return this.address6; }
    set
    {
        if (this.address6 != value)
        {
            this.address6 = value;
            //Notify("Address6");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string Address7
{
    get { return this.address7; }
    set
    {
        if (this.address7 != value)
        {
            this.address7 = value;
            //Notify("Address6");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string Address8
{
    get { return this.address8; }
    set
    {
        if (this.address8 != value)
        {
            this.address8 = value;
            //Notify("Address6");
        }
    }
}


[System.Runtime.Serialization.DataMember]
public
string Phone
{
    get { return this.phone; }
    set
    {
        if (this.phone != value)
        {
            this.phone = value;
            //Notify("Phone");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string Fax
{
    get { return this.fax; }
    set
    {
        if (this.fax != value)
        {
            this.fax = value;
            //Notify("Fax");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string WebPage
{
    get { return this.webPage; }
    set
    {
        if (this.webPage != value)
        {
            this.webPage = value;
            //Notify("WebPage");
        }
    }
}

/*

[System.Runtime.Serialization.DataMember]
public
string City
{
    get { return this.city; }
    set
    {
        if (this.city != value)
        {
            this.city = value;
            //Notify("City");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string Region
{
    get { return this.region; }
    set
    {
        if (this.region != value)
        {
            this.region = value;
            //Notify("Region");
        }
    }
}
*/

[System.Runtime.Serialization.DataMember]
public
string Country
{
    get { return this.country; }
    set
    {
        if (this.country != value)
        {
            this.country = value;
            //Notify("Country");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string State_Prov
{
    get { return this.state_Prov; }
    set
    {
        if (this.state_Prov != value)
        {
            this.state_Prov = value;
            //Notify("State_Prov");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string Currency
{
    get { return this.currency; }
    set
    {
        if (this.currency != value)
        {
            this.currency = value;
            //Notify("Currency");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string Territory
{
    get { return this.territory; }
    set
    {
        if (this.territory != value)
        {
            this.territory = value;
            //Notify("Territory");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
DateTime DateCreated
{
    get { return this.dateCreated; }
    set
    {
        if (this.dateCreated != value)
        {
            this.dateCreated = value;
            //Notify("DateCreated");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
DateTime DateUpdated
{
    get { return this.dateUpdated; }
    set
    {
        if (this.dateUpdated != value)
        {
            this.dateUpdated = value;
            //Notify("DateUpdated");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string ZipCode
{
    get { return this.zipCode; }
    set
    {
        if (this.zipCode != value)
        {
            this.zipCode = value;
            //Notify("ZipCode");
        }
    }
}

/*
[System.Runtime.Serialization.DataMember]
public
string Company
{
    get { return this.company; }
    set
    {
        if (this.company != value)
        {
            this.company = value;
            //Notify("Company");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string Plant
{
    get { return this.plant; }
    set
    {
        if (this.plant != value)
        {
            this.plant = value;
            //Notify("Plant");
        }
    }
}
 
[System.Runtime.Serialization.DataMember]
public
string PoTerms
{
    get { return this.poTerms; }
    set
    {
        if (this.poTerms != value)
        {
            this.poTerms = value;
            //Notify("PoTerms");
        }
    }
}
        
[System.Runtime.Serialization.DataMember]
public
string FreightOnBounds
{
    get { return this.freightOnBounds; }
    set
    {
        if (this.freightOnBounds != value)
        {
            this.freightOnBounds = value;
            //Notify("FreightOnBounds");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string PhoneExt
{
    get { return this.phoneExt; }
    set
    {
        if (this.phoneExt != value)
        {
            this.phoneExt = value;
            //Notify("PhoneExt");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string Mobile
{
    get { return this.mobile; }
    set
    {
        if (this.mobile != value)
        {
            this.mobile = value;
            //Notify("Mobile");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string Email
{
    get { return this.email; }
    set
    {
        if (this.email != value)
        {
            this.email = value;
            //Notify("Email");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string County
{
    get { return this.county; }
    set
    {
        if (this.county != value)
        {
            this.county = value;
            //Notify("County");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string DftContactName
{
    get { return this.dftContactName; }
    set
    {
        if (this.dftContactName != value)
        {
            this.dftContactName = value;
            //Notify("DftContactName");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string DftContactPhone
{
    get { return this.dftContactPhone; }
    set
    {
        if (this.dftContactPhone != value)
        {
            this.dftContactPhone = value;
            //Notify("DftContactPhone");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string DftContactEmail
{
    get { return this.dftContactEmail; }
    set
    {
        if (this.dftContactEmail != value)
        {
            this.dftContactEmail = value;
            //Notify("DftContactEmail");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
int ContactID
{
    get { return this.contactID; }
    set
    {
        if (this.contactID != value)
        {
            this.contactID = value;
            //Notify("ContactID");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
CRMGroupStatic CRMGroupStatic
{
    get { return this.cRMGroupStatic; }
    set
    {
        if (this.cRMGroupStatic != value)
        {
            this.cRMGroupStatic = value;
            //Notify("CRMGroupStatic");
        }
    }
}
*/

[System.Runtime.Serialization.DataMember]
public
string BillToCust{
    get { return this.billToCust; }
    set
    {
        if (this.billToCust != value){
            this.billToCust = value;
            //Notify("DftContactEmail");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string PersonClass{
    get { return this.personClass; }
    set{
        if (this.personClass != value){
            this.personClass = value;
            //Notify("PersonClass");
        }
    }
}

[System.Runtime.Serialization.DataMember]
public
string TPartner{
    get { return this.tPartner; }
    set{
        if (this.tPartner != value){
            this.tPartner = value;
            //Notify("PersonClass");
        }
    }
}

#endregion Properties

public override
bool Equals(object obj){
	if (obj is Person)
		return	this.Id.Equals(((Person)obj).Id);
	else
		return false;
}


}//end Class

}//end namespace
