using System;
using Nujit.NujitERP.ClassLib.Util;


namespace Nujit.NujitERP.ClassLib.Core{

public 
class Person : MarshalByRefObject{


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
}

public 
Person(string plt, string id, string recType, string customerType,
		string status, string name, string address1, string address2,
		string address3, string address4, string address5, string address6,
		string address7, string address8, string phone, string fax, 
		string webPage,	string country, string state_Prov, string currency,
		string territory, string personClass, DateTime dateCreated,
		DateTime dateUpdated, string billToCust, string zipCode){

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


}//end Class

}//end namespace
