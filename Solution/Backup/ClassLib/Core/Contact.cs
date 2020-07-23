using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;



namespace Nujit.NujitERP.ClassLib.Core{


public 
class Contact{

//---------------------------------------------------------------------------

private int contactId;
private string firstName;
private string secondName;
private string lastName;
private string nickName;
private string displayName;
private string title;
private ContactsEmailsDataBaseContainer contactsEmailsDataBaseContainer;

//---------------------------------------------------------------------------

private string address;
private string city;
private string state;
private string zipCode;
private string country;
private string phone;
private string fax;
private string mobile;

//---------------------------------------------------------------------------

private string organization;
private string office;
private string jobAddress;
private string jobCity;
private string jobState;
private string jobZipCode;
private string jobCountry;
private string jobPhone;
private string jobFax;
private string jobPosition;
private string jobDepartament;
private string jobLocalizator;
private string jobIpPhone;

//---------------------------------------------------------------------------

private ContactsSonsDataBaseContainer contactsSonsDataBaseContainer;
private string conyugue;
private string sex;
private DateTime birthday;
private DateTime anniversary;

//---------------------------------------------------------------------------

private string notes;

//---------------------------------------------------------------------------

internal
Contact(ContactsSonsDataBaseContainer contactsSonsDataBaseContainer,
			ContactsEmailsDataBaseContainer contactsEmailsDataBaseContainer){
	this.contactId = 0;
	this.firstName = "";
	this.secondName = "";
	this.lastName = "";
	this.nickName = "";
	this.displayName = "";
	this.title  = "" ;
	this.address = "";
	this.city = "";
	this.state = "";
	this.zipCode = "";
	this.country = "";
	this.phone = "";
	this.fax = "";
	this.mobile = "";
	this.organization = "";
	this.office = "";
	this.jobAddress = "";
	this.jobCity = "";
	this.jobState = "";
	this.jobZipCode = "";
	this.jobCountry = "";
	this.jobPhone = "";
	this.jobFax = "";
	this.jobPosition  = "" ;
	this.jobDepartament = "";
	this.jobLocalizator = "";
	this.jobIpPhone = "";
	this.conyugue = "";
	this.birthday = DateTime.Now;
	this.anniversary = DateTime.Now;
	this.notes = "";
	this.sex = "M";

	this.contactsSonsDataBaseContainer = contactsSonsDataBaseContainer;
	this.contactsEmailsDataBaseContainer = contactsEmailsDataBaseContainer;
}

internal
Contact(int contactId, string firstName, string secondName, string lastName, string nickName, string displayName, string title, 
		ContactsEmailsDataBaseContainer contactsEmailsDataBaseContainer, string address, string city, string state, string zipCode, string country, 
		string phone, string fax, string mobile, string organization, string office, string jobAddress, string jobCity, 
		string jobState, string jobZipCode, string jobCountry, string jobPhone, string jobFax, string jobPosition, 
		string jobDepartament, string jobLocalizator, string jobIpPhone, ContactsSonsDataBaseContainer contactsSonsDataBaseContainer, string conyugue, 
		DateTime birthday, DateTime anniversary, string notes, string sex){


	this.contactId = contactId;
	this.firstName = firstName;
	this.secondName = secondName;
	this.lastName = lastName;
	this.nickName = nickName;
	this.displayName = displayName;
	this.title  = title ;
	this.address = address;
	this.city = city;
	this.state = state;
	this.zipCode = zipCode;
	this.country = country;
	this.phone = phone;
	this.fax = fax;
	this.mobile = mobile;
	this.organization = organization;
	this.office = office;
	this.jobAddress = jobAddress;
	this.jobCity = jobCity;
	this.jobState = jobState;
	this.jobZipCode = jobZipCode;
	this.jobCountry = jobCountry;
	this.jobPhone = jobPhone;
	this.jobFax = jobFax;
	this.jobPosition  = jobPosition ;
	this.jobDepartament = jobDepartament;
	this.jobLocalizator = jobLocalizator;
	this.jobIpPhone = jobIpPhone;
	this.conyugue = conyugue;
	this.birthday = birthday;
	this.anniversary = anniversary;
	this.notes = notes;
	this.sex = sex;

	this.contactsEmailsDataBaseContainer = contactsEmailsDataBaseContainer;
	this.contactsSonsDataBaseContainer = contactsSonsDataBaseContainer;
}


public
void setContactId(int contactId){
	this.contactId = contactId;
}

public
void setFirstName(string firstName){
	this.firstName = firstName;
}

public
void setSecondName(string secondName){
	this.secondName = secondName;
}

public
void setLastName(string lastName){
	this.lastName = lastName;
}

public
void setNickName(string nickName){
	this.nickName = nickName;
}

public
void setDisplayName(string displayName){
	this.displayName = displayName;
}

public
void setTitle(string title){
	this.title = title;
}

internal
void setContactsEmailsDataBaseContainer(ContactsEmailsDataBaseContainer contactsEmailsDataBaseContainer){
	this.contactsEmailsDataBaseContainer = contactsEmailsDataBaseContainer;
}

public
void setAddress(string address){
	this.address = address;
}

public
void setCity(string city){
	this.city = city;
}

public
void setState(string state){
	this.state = state;
}

public
void setZipCode(string zipCode){
	this.zipCode = zipCode;
}

public
void setCountry(string country){
	this.country = country;
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
void setMobile(string mobile){
	this.mobile = mobile;
}

public
void setOrganization(string organization){
	this.organization = organization;
}

public
void setOffice(string office){
	this.office = office;
}

public
void setJobAddress(string jobAddress){
	this.jobAddress = jobAddress;
}

public
void setJobCity(string jobCity){
	this.jobCity = jobCity;
}

public
void setJobState(string jobState){
	this.jobState = jobState;
}

public
void setJobZipCode(string jobZipCode){
	this.jobZipCode = jobZipCode;
}

public
void setJobCountry(string jobCountry){
	this.jobCountry = jobCountry;
}

public
void setJobPhone(string jobPhone){
	this.jobPhone = jobPhone;
}

public
void setJobFax(string jobFax){
	this.jobFax = jobFax;
}

public
void setJobPosition(string jobPosition){
	this.jobPosition = jobPosition;
}

public
void setJobDepartament(string jobDepartament){
	this.jobDepartament = jobDepartament;
}

public
void setJobLocalizator(string jobLocalizator){
	this.jobLocalizator = jobLocalizator;
}

public
void setJobIpPhone(string jobIpPhone){
	this.jobIpPhone = jobIpPhone;
}

internal
void setContactsSonsDataBaseContainer(ContactsSonsDataBaseContainer contactsSonsDataBaseContainer){
	this.contactsSonsDataBaseContainer = contactsSonsDataBaseContainer;
}

public
void setConyugue(string conyugue){
	this.conyugue = conyugue;
}

public
void setBirthday(DateTime birthday){
	this.birthday = birthday;
}

public
void setAnniversary(DateTime anniversary){
	this.anniversary = anniversary;
}

public
void setNotes(string notes){
	this.notes = notes;
}

public
void setSex(string sex){
	this.sex = sex;
}


public
int getContactId(){
	return contactId;
}

public
string getFirstName(){
	return firstName;
}

public
string getSecondName(){
	return secondName;
}

public
string getLastName(){
	return lastName;
}

public
string getNickName(){
	return nickName;
}

public
string getDisplayName(){
	return displayName;
}

public
string getTitle(){
	return title;
}

internal
ContactsEmailsDataBaseContainer getContactsEmailsDataBaseContainer(){
	return contactsEmailsDataBaseContainer;
}

public
string getAddress(){
	return address;
}

public
string getCity(){
	return city;
}

public
string getState(){
	return state;
}

public
string getZipCode(){
	return zipCode;
}

public
string getCountry(){
	return country;
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
string getMobile(){
	return mobile;
}

public
string getOrganization(){
	return organization;
}

public
string getOffice(){
	return office;
}

public
string getJobAddress(){
	return jobAddress;
}

public
string getJobCity(){
	return jobCity;
}

public
string getJobState(){
	return jobState;
}

public
string getJobZipCode(){
	return jobZipCode;
}

public
string getJobCountry(){
	return jobCountry;
}

public
string getJobPhone(){
	return jobPhone;
}

public
string getJobFax(){
	return jobFax;
}

public
string getJobPosition(){
	return jobPosition;
}

public
string getJobDepartament(){
	return jobDepartament;
}

public
string getJobLocalizator(){
	return jobLocalizator;
}

public
string getJobIpPhone(){
	return jobIpPhone;
}

internal
ContactsSonsDataBaseContainer getContactsSonsDataBaseContainer(){
	return contactsSonsDataBaseContainer;
}

public
string getConyugue(){
	return conyugue;
}

public
DateTime getBirthday(){
	return birthday;
}

public
DateTime getAnniversary(){
	return anniversary;
}

public
string getNotes(){
	return notes;
}

public
string getSex(){
	return sex;
}

public 
bool addEmail(string email, string isdefault){
	for(int i = 0; i < contactsEmailsDataBaseContainer.Count; i++){
		ContactsEmailsDataBase contactsEmailsDataBase = (ContactsEmailsDataBase)contactsEmailsDataBaseContainer[i];
		if (contactsEmailsDataBase.getCE_Email().Equals(email))
			return false;
	}

	if (isdefault.Equals("Y")){
		for(int i = 0; i < contactsEmailsDataBaseContainer.Count; i++){
			ContactsEmailsDataBase contactsEmailsDataBase = (ContactsEmailsDataBase)contactsEmailsDataBaseContainer[i];
			contactsEmailsDataBase.setCE_Predetermined("N");
		}
	}

	ContactsEmailsDataBase forAdd = new ContactsEmailsDataBase(contactsEmailsDataBaseContainer.getDataBaseAccess());
	forAdd.setCE_ContactId(this.contactId);
	forAdd.setCE_Email(email);
	forAdd.setCE_Predetermined(isdefault);
	contactsEmailsDataBaseContainer.Add(forAdd);

	return true;
}

public 
void clearEmails(){
	contactsEmailsDataBaseContainer.Clear();
}

public 
string[][] getEmails(){
	string[][] mails = new string[contactsEmailsDataBaseContainer.Count][];

	for(int i = 0; i < contactsEmailsDataBaseContainer.Count; i++){
		ContactsEmailsDataBase contactsEmailsDataBase = (ContactsEmailsDataBase)contactsEmailsDataBaseContainer[i];
		
		string[] line = new string[2];
		line[0] = contactsEmailsDataBase.getCE_Email();
		line[1] = contactsEmailsDataBase.getCE_Predetermined();
		mails[i] = line;
	}
	return mails;
}

public 
bool addSon(string son){
	for(int i = 0; i < contactsSonsDataBaseContainer.Count; i++){
		ContactsSonsDataBase contactsSonsDataBase = (ContactsSonsDataBase)contactsSonsDataBaseContainer[i];
		if (contactsSonsDataBase.getCE_Son().Equals(son))
			return false;
	}

	ContactsSonsDataBase forAdd = new ContactsSonsDataBase(contactsSonsDataBaseContainer.getDataBaseAccess());
	forAdd.setCE_ContactId(this.contactId);
	forAdd.setCE_Son(son);
	contactsSonsDataBaseContainer.Add(forAdd);

	return true;
}

public 
void clearSons(){
	contactsSonsDataBaseContainer.Clear();
}

public 
string[] getSons(){
	string[] sons = new string[contactsSonsDataBaseContainer.Count];

	for(int i = 0; i < contactsSonsDataBaseContainer.Count; i++){
		ContactsSonsDataBase contactsSonsDataBase = (ContactsSonsDataBase)contactsSonsDataBaseContainer[i];
		
		sons[i] = contactsSonsDataBase.getCE_Son();
	}
	return sons;
}



}

} // namespace
