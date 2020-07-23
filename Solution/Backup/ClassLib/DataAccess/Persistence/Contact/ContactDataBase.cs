/*/////////////////////////////////////////////////////////////////////////////////
This class was copy from the Tooling Project. 
Claudia Melo
05-04-2005

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class ContactDataBase : GenericDataBaseElement {

private int CNT_Id;
private string CNT_FirstName;
private string CNT_SecondName;
private string CNT_LastName;
private string CNT_NickName;
private string CNT_DisplayName;
private string CNT_Title;
private string CNT_Address;
private string CNT_City;
private string CNT_State;
private string CNT_ZipCode;
private string CNT_Country;
private string CNT_Phone;
private string CNT_Fax;
private string CNT_Mobile;
private string CNT_Organization;
private string CNT_Office;
private string CNT_JobAddress;
private string CNT_JobCity;
private string CNT_JobState;
private string CNT_JobZipCode;
private string CNT_JobCountry;
private string CNT_JobPhone;
private string CNT_JobFax;
private string CNT_JobPosition;
private string CNT_JobDepartament;
private string CNT_JobLocalizator;
private string CNT_JobIpPhone;
private string CNT_Conyugue;
private DateTime CNT_Birthday;
private DateTime CNT_Anniversary;
private string CNT_Notes;
private string CNT_Sex;

public
ContactDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	NotNullDataReader reader = null;
	try {
		string sql = "select * from contact where " + getWhereCondition();

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
bool exists(){
	string sql = "select * from contact where " + getWhereCondition();
	return exists(sql);
}

public /*override*/
void load(NotNullDataReader reader){
	this.CNT_Id = reader.GetInt32("CNT_Id");
	this.CNT_FirstName = reader.GetString("CNT_FirstName");
	this.CNT_SecondName = reader.GetString("CNT_SecondName");
	this.CNT_LastName = reader.GetString("CNT_LastName");
	this.CNT_NickName = reader.GetString("CNT_NickName");
	this.CNT_DisplayName = reader.GetString("CNT_DisplayName");
	this.CNT_Title = reader.GetString("CNT_Title");
	this.CNT_Address = reader.GetString("CNT_Address");
	this.CNT_City = reader.GetString("CNT_City");
	this.CNT_State = reader.GetString("CNT_State");
	this.CNT_ZipCode = reader.GetString("CNT_ZipCode");
	this.CNT_Country = reader.GetString("CNT_Country");
	this.CNT_Phone = reader.GetString("CNT_Phone");
	this.CNT_Fax = reader.GetString("CNT_Fax");
	this.CNT_Mobile = reader.GetString("CNT_Mobile");
	this.CNT_Organization = reader.GetString("CNT_Organization");
	this.CNT_Office = reader.GetString("CNT_Office");
	this.CNT_JobAddress = reader.GetString("CNT_JobAddress");
	this.CNT_JobCity = reader.GetString("CNT_JobCity");
	this.CNT_JobState = reader.GetString("CNT_JobState");
	this.CNT_JobZipCode = reader.GetString("CNT_JobZipCode");
	this.CNT_JobCountry = reader.GetString("CNT_JobCountry");
	this.CNT_JobPhone = reader.GetString("CNT_JobPhone");
	this.CNT_JobFax = reader.GetString("CNT_JobFax");
	this.CNT_JobPosition = reader.GetString("CNT_JobPosition");
	this.CNT_JobDepartament = reader.GetString("CNT_JobDepartament");
	this.CNT_JobLocalizator = reader.GetString("CNT_JobLocalizator");
	this.CNT_JobIpPhone = reader.GetString("CNT_JobIpPhone");
	this.CNT_Conyugue = reader.GetString("CNT_Conyugue");
	this.CNT_Birthday = reader.GetDateTime("CNT_Birthday");
	this.CNT_Anniversary = reader.GetDateTime("CNT_Anniversary");
	this.CNT_Notes = reader.GetString("CNT_Notes");
	this.CNT_Sex = reader.GetString("CNT_Sex");
}

public override
void write(){
	string sql = "insert into contact (" + 
		"CNT_FirstName," +
		"CNT_SecondName," +
		"CNT_LastName," +
		"CNT_NickName," +
		"CNT_DisplayName," +
		"CNT_Title," +
		"CNT_Address," +
		"CNT_City," +
		"CNT_State," +
		"CNT_ZipCode," +
		"CNT_Country," +
		"CNT_Phone," +
		"CNT_Fax," +
		"CNT_Mobile," +
		"CNT_Organization," +
		"CNT_Office, " +
		"CNT_JobAddress," +
		"CNT_JobCity," +
		"CNT_JobState," +
		"CNT_JobZipCode," +
		"CNT_JobCountry," +
		"CNT_JobPhone," +
		"CNT_JobFax," +
		"CNT_JobPosition," +
		"CNT_JobDepartament," +
		"CNT_JobLocalizator," +
		"CNT_JobIpPhone," +
		"CNT_Conyugue," +
		"CNT_Birthday," +
		"CNT_Anniversary," +
		"CNT_Notes," +
		"CNT_Sex" +

		") values (" + 

		"'" + Converter.fixString(CNT_FirstName) + "'," +
		"'" + Converter.fixString(CNT_SecondName) + "'," +
		"'" + Converter.fixString(CNT_LastName) + "'," +
		"'" + Converter.fixString(CNT_NickName) + "'," +
		"'" + Converter.fixString(CNT_DisplayName) + "'," +
		"'" + Converter.fixString(CNT_Title) + "'," +
		"'" + Converter.fixString(CNT_Address) + "'," +
		"'" + Converter.fixString(CNT_City) + "'," +
		"'" + Converter.fixString(CNT_State) + "'," +
		"'" + Converter.fixString(CNT_ZipCode) + "'," +
		"'" + Converter.fixString(CNT_Country) + "'," +
		"'" + Converter.fixString(CNT_Phone) + "'," +
		"'" + Converter.fixString(CNT_Fax) + "'," +
		"'" + Converter.fixString(CNT_Mobile) + "'," +
		"'" + Converter.fixString(CNT_Organization) + "'," +
		"'" + Converter.fixString(CNT_Office) + "'," +
		"'" + Converter.fixString(CNT_JobAddress) + "'," +
		"'" + Converter.fixString(CNT_JobCity) + "'," +
		"'" + Converter.fixString(CNT_JobState) + "'," +
		"'" + Converter.fixString(CNT_JobZipCode) + "'," +
		"'" + Converter.fixString(CNT_JobCountry) + "'," +
		"'" + Converter.fixString(CNT_JobPhone) + "'," +
		"'" + Converter.fixString(CNT_JobFax) + "'," +
		"'" + Converter.fixString(CNT_JobPosition) + "'," +
		"'" + Converter.fixString(CNT_JobDepartament) + "'," +
		"'" + Converter.fixString(CNT_JobLocalizator) + "'," +
		"'" + Converter.fixString(CNT_JobIpPhone) + "'," +
		"'" + Converter.fixString(CNT_Conyugue) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(CNT_Birthday) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(CNT_Anniversary) + "'," +
		"'" + Converter.fixString(CNT_Notes) + "'," +
		"'" + Converter.fixString(CNT_Sex) + "')";
	write(sql);

	this.CNT_Id = dataBaseAccess.getLastId();
}

public override
void update(){
	string sql = "update contact set " +
		"CNT_FirstName = '" + Converter.fixString(CNT_FirstName) + "', " +
		"CNT_SecondName = '" + Converter.fixString(CNT_SecondName) + "', " +
		"CNT_LastName = '" + Converter.fixString(CNT_LastName) + "', " +
		"CNT_NickName = '" + Converter.fixString(CNT_NickName) + "', " +
		"CNT_DisplayName = '" + Converter.fixString(CNT_DisplayName) + "', " +
		"CNT_Title = '" + Converter.fixString(CNT_Title) + "', " +
		"CNT_Address = '" + Converter.fixString(CNT_Address) + "', " +
		"CNT_City = '" + Converter.fixString(CNT_City) + "', " +
		"CNT_State = '" + Converter.fixString(CNT_State) + "', " +
		"CNT_ZipCode = '" + Converter.fixString(CNT_ZipCode) + "', " +
		"CNT_Country = '" + Converter.fixString(CNT_Country) + "', " +
		"CNT_Phone = '" + Converter.fixString(CNT_Phone) + "', " +
		"CNT_Fax = '" + Converter.fixString(CNT_Fax) + "', " +
		"CNT_Mobile = '" + Converter.fixString(CNT_Mobile) + "', " +
		"CNT_Organization = '" + Converter.fixString(CNT_Organization) + "', " +
		"CNT_Office = '" + Converter.fixString(CNT_Office) + "', " +
		"CNT_JobAddress = '" + Converter.fixString(CNT_JobAddress) + "', " +
		"CNT_JobCity = '" + Converter.fixString(CNT_JobCity) + "', " +
		"CNT_JobState = '" + Converter.fixString(CNT_JobState) + "', " +
		"CNT_JobZipCode = '" + Converter.fixString(CNT_JobZipCode) + "', " +
		"CNT_JobCountry = '" + Converter.fixString(CNT_JobCountry) + "', " +
		"CNT_JobPhone = '" + Converter.fixString(CNT_JobPhone) + "', " +
		"CNT_JobFax = '" + Converter.fixString(CNT_JobFax) + "', " +
		"CNT_JobPosition = '" + Converter.fixString(CNT_JobPosition) + "', " +
		"CNT_JobDepartament = '" + Converter.fixString(CNT_JobDepartament) + "', " +
		"CNT_JobLocalizator = '" + Converter.fixString(CNT_JobLocalizator) + "', " +
		"CNT_JobIpPhone = '" + Converter.fixString(CNT_JobIpPhone) + "', " +
		"CNT_Conyugue = '" + Converter.fixString(CNT_Conyugue) + "', " +
		"CNT_Birthday = '" + DateUtil.getCompleteDateRepresentation(CNT_Birthday) + "', " +
		"CNT_Anniversary = '" + DateUtil.getCompleteDateRepresentation(CNT_Anniversary) + "', " +
		"CNT_Notes = '" + Converter.fixString(CNT_Notes) + "', " +
		"CNT_Sex = '" + Converter.fixString(CNT_Sex) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from contact where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"CNT_Id = " + NumberUtil.toString(CNT_Id) + "";
	return sqlWhere;
}

public
void setCNT_Id(int CNT_Id){
	this.CNT_Id = CNT_Id;
}

public
void setCNT_FirstName(string CNT_FirstName){
	this.CNT_FirstName = CNT_FirstName;
}

public
void setCNT_SecondName(string CNT_SecondName){
	this.CNT_SecondName = CNT_SecondName;
}

public
void setCNT_LastName(string CNT_LastName){
	this.CNT_LastName = CNT_LastName;
}

public
void setCNT_NickName(string CNT_NickName){
	this.CNT_NickName = CNT_NickName;
}

public
void setCNT_DisplayName(string CNT_DisplayName){
	this.CNT_DisplayName = CNT_DisplayName;
}

public
void setCNT_Title(string CNT_Title){
	this.CNT_Title = CNT_Title;
}

public
void setCNT_Address(string CNT_Address){
	this.CNT_Address = CNT_Address;
}

public
void setCNT_City(string CNT_City){
	this.CNT_City = CNT_City;
}

public
void setCNT_State(string CNT_State){
	this.CNT_State = CNT_State;
}

public
void setCNT_ZipCode(string CNT_ZipCode){
	this.CNT_ZipCode = CNT_ZipCode;
}

public
void setCNT_Country(string CNT_Country){
	this.CNT_Country = CNT_Country;
}

public
void setCNT_Phone(string CNT_Phone){
	this.CNT_Phone = CNT_Phone;
}

public
void setCNT_Fax(string CNT_Fax){
	this.CNT_Fax = CNT_Fax;
}

public
void setCNT_Mobile(string CNT_Mobile){
	this.CNT_Mobile = CNT_Mobile;
}

public
void setCNT_Organization(string CNT_Organization){
	this.CNT_Organization = CNT_Organization;
}

public
void setCNT_Office(string CNT_Office){
	this.CNT_Office = CNT_Office;
}

public
void setCNT_JobAddress(string CNT_JobAddress){
	this.CNT_JobAddress = CNT_JobAddress;
}

public
void setCNT_JobCity(string CNT_JobCity){
	this.CNT_JobCity = CNT_JobCity;
}

public
void setCNT_JobState(string CNT_JobState){
	this.CNT_JobState = CNT_JobState;
}

public
void setCNT_JobZipCode(string CNT_JobZipCode){
	this.CNT_JobZipCode = CNT_JobZipCode;
}

public
void setCNT_JobCountry(string CNT_JobCountry){
	this.CNT_JobCountry = CNT_JobCountry;
}

public
void setCNT_JobPhone(string CNT_JobPhone){
	this.CNT_JobPhone = CNT_JobPhone;
}

public
void setCNT_JobFax(string CNT_JobFax){
	this.CNT_JobFax = CNT_JobFax;
}

public
void setCNT_JobPosition(string CNT_JobPosition){
	this.CNT_JobPosition = CNT_JobPosition;
}

public
void setCNT_JobDepartament(string CNT_JobDepartament){
	this.CNT_JobDepartament = CNT_JobDepartament;
}

public
void setCNT_JobLocalizator(string CNT_JobLocalizator){
	this.CNT_JobLocalizator = CNT_JobLocalizator;
}

public
void setCNT_JobIpPhone(string CNT_JobIpPhone){
	this.CNT_JobIpPhone = CNT_JobIpPhone;
}

public
void setCNT_Conyugue(string CNT_Conyugue){
	this.CNT_Conyugue = CNT_Conyugue;
}

public
void setCNT_Birthday(DateTime CNT_Birthday){
	this.CNT_Birthday = CNT_Birthday;
}

public
void setCNT_Anniversary(DateTime CNT_Anniversary){
	this.CNT_Anniversary = CNT_Anniversary;
}

public
void setCNT_Notes(string CNT_Notes){
	this.CNT_Notes = CNT_Notes;
}

public
void setCNT_Sex(string CNT_Sex){
	this.CNT_Sex = CNT_Sex;
}

public
int getCNT_Id(){
	return CNT_Id;
}

public
string getCNT_FirstName(){
	return CNT_FirstName;
}

public
string getCNT_SecondName(){
	return CNT_SecondName;
}

public
string getCNT_LastName(){
	return CNT_LastName;
}

public
string getCNT_NickName(){
	return CNT_NickName;
}

public
string getCNT_DisplayName(){
	return CNT_DisplayName;
}

public
string getCNT_Title(){
	return CNT_Title;
}

public
string getCNT_Address(){
	return CNT_Address;
}

public
string getCNT_City(){
	return CNT_City;
}

public
string getCNT_State(){
	return CNT_State;
}

public
string getCNT_ZipCode(){
	return CNT_ZipCode;
}

public
string getCNT_Country(){
	return CNT_Country;
}

public
string getCNT_Phone(){
	return CNT_Phone;
}

public
string getCNT_Fax(){
	return CNT_Fax;
}

public
string getCNT_Mobile(){
	return CNT_Mobile;
}

public
string getCNT_Organization(){
	return CNT_Organization;
}

public
string getCNT_Office(){
	return CNT_Office;
}

public
string getCNT_JobAddress(){
	return CNT_JobAddress;
}

public
string getCNT_JobCity(){
	return CNT_JobCity;
}

public
string getCNT_JobState(){
	return CNT_JobState;
}

public
string getCNT_JobZipCode(){
	return CNT_JobZipCode;
}

public
string getCNT_JobCountry(){
	return CNT_JobCountry;
}

public
string getCNT_JobPhone(){
	return CNT_JobPhone;
}

public
string getCNT_JobFax(){
	return CNT_JobFax;
}

public
string getCNT_JobPosition(){
	return CNT_JobPosition;
}

public
string getCNT_JobDepartament(){
	return CNT_JobDepartament;
}

public
string getCNT_JobLocalizator(){
	return CNT_JobLocalizator;
}

public
string getCNT_JobIpPhone(){
	return CNT_JobIpPhone;
}

public
string getCNT_Conyugue(){
	return CNT_Conyugue;
}

public
DateTime getCNT_Birthday(){
	return CNT_Birthday;
}

public
DateTime getCNT_Anniversary(){
	return CNT_Anniversary;
}

public
string getCNT_Notes(){
	return CNT_Notes;
}

public
string getCNT_Sex(){
	return CNT_Sex;
}

} // class

} // package