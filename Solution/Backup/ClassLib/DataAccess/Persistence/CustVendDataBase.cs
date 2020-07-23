using System;
using MySql.Data;
using System.Data;
using System.Data.OleDb;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public 
class CustVendDataBase  : GenericDataBaseElement{

private string CV_Plt;
private string CV_ID;
private string CV_RecType;
private string CV_CustomerType;
private string CV_Status;
private string CV_Name;
private string CV_Address1;
private string CV_Address2;
private string CV_Address3;
private string CV_Address4;
private string CV_Address5;
private string CV_Address6;
private string CV_Address7;
private string CV_Address8;
private string CV_Phone;
private string CV_Fax;
private string CV_WebPage;
private string CV_Country;
private string CV_State_Prov;
private string CV_Currency;
private string CV_Territory;
private string CV_Class;
private DateTime CV_DateCreated;
private DateTime CV_DateUpdated;
private string CV_BillToCust;
private string CV_ZipCode;

public 
CustVendDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	this.CV_Plt = reader.GetString("CV_Plt");
	this.CV_ID = reader.GetString("CV_ID");
	this.CV_RecType = reader.GetString("CV_RecType").Trim();
	this.CV_CustomerType = reader.GetString("CV_CustomerType");
	this.CV_Status = reader.GetString("CV_Status");
	this.CV_Name = reader.GetString("CV_Name");
	this.CV_Address1 = reader.GetString("CV_Address1");
	this.CV_Address2 = reader.GetString("CV_Address2");
	this.CV_Address3 = reader.GetString("CV_Address3");
	this.CV_Address4 = reader.GetString("CV_Address4");
	this.CV_Address5 = reader.GetString("CV_Address5");
	this.CV_Address6 = reader.GetString("CV_Address6");
	this.CV_Address7 = reader.GetString("CV_Address7");
	this.CV_Address8 = reader.GetString("CV_Address8");
	this.CV_Phone = reader.GetString("CV_Phone");
	this.CV_Fax = reader.GetString("CV_Fax");
	this.CV_WebPage = reader.GetString("CV_WebPage");
	this.CV_Country = reader.GetString("CV_Country");
	this.CV_State_Prov = reader.GetString("CV_State_Prov");
	this.CV_Currency = reader.GetString("CV_Currency");
	this.CV_Territory = reader.GetString("CV_Territory");
	this.CV_Class = reader.GetString("CV_Class");
	this.CV_DateCreated = reader.GetDateTime("CV_DateCreated");
	this.CV_DateUpdated = reader.GetDateTime("CV_DateUpdated");
	this.CV_BillToCust = reader.GetString("CV_BillToCust");
	this.CV_ZipCode = reader.GetString("CV_ZipCode");
}

public
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from custvend " +
			"where CV_Plt = '" + CV_Plt + "' and " +
				"CV_ID = '" + CV_ID + "'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}

public
void readByIdRecType(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from custvend " + 
		                "where CV_Id = '" + Converter.fixString(CV_ID) + "' and " +
		                      "CV_RecType = '" + Converter.fixString(CV_RecType) +"'";
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByIdRecType> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByIdRecType> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <readByIdRecType> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


public override
void delete(){
	try{
		string sql = "delete from custvend  " +
			"where CV_Plt = '" + CV_Plt + "' and " +
				    "CV_ID = '" + CV_ID + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void update(){
	try{
		string sql = "update custvend set " +
			"CV_Status = '" + Converter.fixString(CV_Status) + "', " +
			"CV_Name = '" + Converter.fixString(CV_Name) + "', " +
			"CV_Address1 = '" + Converter.fixString(CV_Address1) + "', " +
			"CV_Address2 = '" + Converter.fixString(CV_Address2) + "', " +
			"CV_Address3 = '" + Converter.fixString(CV_Address3) + "', " +
			"CV_Address4 = '" + Converter.fixString(CV_Address4) + "', " +
			"CV_Address5 = '" + Converter.fixString(CV_Address5) + "', " +
			"CV_Address6 = '" + Converter.fixString(CV_Address6) + "', " +
			"CV_Address7 = '" + Converter.fixString(CV_Address7) + "', " +
			"CV_Address8 = '" + Converter.fixString(CV_Address8) + "', " +
			"CV_Phone = '" + Converter.fixString(CV_Phone) + "', " +
			"CV_Fax = '" + Converter.fixString(CV_Fax) + "', " +
			"CV_WebPage = '" + Converter.fixString(CV_WebPage) + "', " +
			"CV_Country = '" + Converter.fixString(CV_Country) + "', " +
			"CV_State_Prov = '" + Converter.fixString(CV_State_Prov) + "', " +
			"CV_Currency = '" + Converter.fixString(CV_Currency) + "', " +
			"CV_Territory = '" + Converter.fixString(CV_Territory) + "', " +
			"CV_Class = '" + Converter.fixString(CV_Class) + "', " +
			"CV_RecType = '" + Converter.fixString(CV_RecType) + "', " +
			"CV_DateCreated = '" + DateUtil.getCompleteDateRepresentation(CV_DateCreated) + "', " +
			"CV_DateUpdated = '" + DateUtil.getCompleteDateRepresentation(CV_DateUpdated) + "', " +
			"CV_BillToCust = '" + Converter.fixString(CV_BillToCust) + "', " +
			"CV_ZipCode = '" + Converter.fixString(CV_ZipCode) + "' " +
			"where CV_Plt = '" + CV_Plt + "' and " +
				"CV_ID = '" + CV_ID + "'";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message, mySqlExc);
	}
}


public override
void write(){
	try{
		string sql = "insert into custvend values('" + 
			Converter.fixString(CV_Plt) + "', '" +
			Converter.fixString(CV_ID) + "', '" +
			Converter.fixString(CV_RecType) + "', '" +
			Converter.fixString(CV_CustomerType) + "', '" +
			Converter.fixString(CV_Status) + "', '" +
			Converter.fixString(CV_Name) + "', '" +
			Converter.fixString(CV_Address1) + "', '" +
			Converter.fixString(CV_Address2) + "', '" +
			Converter.fixString(CV_Address3) + "', '" +
			Converter.fixString(CV_Address4) + "', '" +
			Converter.fixString(CV_Address5) + "', '" +
			Converter.fixString(CV_Address6) + "', '" +
			Converter.fixString(CV_Address7) + "', '" +
			Converter.fixString(CV_Address8) + "', '" +
			Converter.fixString(CV_Phone) + "', '" +
			Converter.fixString(CV_Fax) + "', '" +
			Converter.fixString(CV_WebPage) + "', '" +
			Converter.fixString(CV_Country) + "', '" +
			Converter.fixString(CV_State_Prov) + "', '" +
			Converter.fixString(CV_Currency) + "', '" +
			Converter.fixString(CV_Territory) + "', '" +
			Converter.fixString(CV_Class) + "', '" +
			DateUtil.getDateRepresentation(CV_DateCreated) + "', '" +
			DateUtil.getDateRepresentation(CV_DateUpdated) + "','" +
			Converter.fixString(CV_BillToCust) + "', '" +
			Converter.fixString(CV_ZipCode) + "')";
		
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public
bool exists(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from custvend " +
			"where CV_Plt = '" + CV_Plt + "' and " +
			"CV_ID = '" + CV_ID + "'";

		bool founded = false;
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			founded = true;
		return founded;
	}catch(System.Data.SqlClient.SqlException){
		return false;
	}catch(System.Data.DataException){
		return false;
	}catch(MySql.Data.MySqlClient.MySqlException){
		return false;
	}finally{
		if (reader != null)
			reader.Close();
	}
}

//Setters
public 
void setCV_Plt(string CV_Plt){
   this.CV_Plt = CV_Plt;
}

public 
void setCV_ID(string CV_ID){
   this.CV_ID = CV_ID;
}

public 
void setCV_RecType(string CV_RecType){
   this.CV_RecType = CV_RecType;
}

public 
void setCV_CustomerType(string CV_CustomerType){
   this.CV_CustomerType = CV_CustomerType;
}

public 
void setCV_Status(string CV_Status){
   this.CV_Status = CV_Status;
}

public 
void setCV_Name(string CV_Name){
   this.CV_Name = CV_Name;
}

public 
void setCV_Address1(string CV_Address1){
   this.CV_Address1 = CV_Address1;
}

public 
void setCV_Address2(string CV_Address2){
   this.CV_Address2 = CV_Address2;
}

public 
void setCV_Address3(string CV_Address3){
   this.CV_Address3 = CV_Address3;
}

public 
void setCV_Address4(string CV_Address4){
   this.CV_Address4 = CV_Address4;
}

public 
void setCV_Address5(string CV_Address5){
   this.CV_Address5 = CV_Address5;
}

public 
void setCV_Address6(string CV_Address6){
   this.CV_Address6 = CV_Address6;
}

public 
void setCV_Address7(string CV_Address7){
   this.CV_Address7 = CV_Address7;
}

public 
void setCV_Address8(string CV_Address8){
   this.CV_Address8 = CV_Address8;
}

public 
void setCV_Phone(string CV_Phone){
   this.CV_Phone = CV_Phone;
}

public 
void setCV_Fax(string CV_Fax){
   this.CV_Fax = CV_Fax;
}

public 
void setCV_WebPage(string CV_WebPage){
   this.CV_WebPage = CV_WebPage;
}

public 
void setCV_Country(string CV_Country){
   this.CV_Country = CV_Country;
}

public 
void setCV_State_Prov(string CV_State_Prov){
   this.CV_State_Prov = CV_State_Prov;
}

public 
void setCV_Currency(string CV_Currency){
   this.CV_Currency = CV_Currency;
}

public 
void setCV_Territory(string CV_Territory){
   this.CV_Territory = CV_Territory;
}

public 
void setCV_Class(string CV_Class){
   this.CV_Class = CV_Class;
}

public 
void setCV_DateCreated(DateTime CV_DateCreated){
   this.CV_DateCreated = CV_DateCreated;
}

public 
void setCV_DateUpdated(DateTime CV_DateUpdated)
{
	this.CV_DateUpdated = CV_DateUpdated;
}

public 
void setCV_BillToCust(string CV_BillToCust){
	this.CV_BillToCust = CV_BillToCust;
}

public 
void setCV_ZipCode(string CV_ZipCode){
	this.CV_ZipCode = CV_ZipCode;
}

	//Getters
public
string getCV_Plt(){
   return CV_Plt;
}

public
string getCV_ID(){
   return CV_ID;
}

public
string getCV_RecType(){
   return CV_RecType;
}

public
string getCV_CustomerType(){
   return CV_CustomerType;
}

public
string getCV_Status(){
   return CV_Status;
}

public
string getCV_Name(){
   return CV_Name;
}

public
string getCV_Address1(){
   return CV_Address1;
}

public
string getCV_Address2(){
   return CV_Address2;
}

public
string getCV_Address3(){
   return CV_Address3;
}

public
string getCV_Address4(){
   return CV_Address4;
}

public
string getCV_Address5(){
   return CV_Address5;
}

public
string getCV_Address6(){
   return CV_Address6;
}

public
string getCV_Address7(){
   return CV_Address7;
}

public
string getCV_Address8(){
   return CV_Address8;
}

public
string getCV_Phone(){
   return CV_Phone;
}

public
string getCV_Fax(){
   return CV_Fax;
}

public
string getCV_WebPage(){
   return CV_WebPage;
}

public
string getCV_Country(){
   return CV_Country;
}

public
string getCV_State_Prov(){
   return CV_State_Prov;
}

public
string getCV_Currency(){
   return CV_Currency;
}

public
string getCV_Territory(){
   return CV_Territory;
}

public
string getCV_Class(){
   return CV_Class;
}

public
DateTime getCV_DateCreated(){
   return CV_DateCreated;
}

public
DateTime getCV_DateUpdated(){
   return CV_DateUpdated;
}

public
string getCV_BillToCust(){
	return CV_BillToCust;
}

public
string getCV_ZipCode(){
	return CV_ZipCode;
}

	public  DataBaseAccess DataBaseAccess
	{
		set
		{
			this.dataBaseAccess = value;
		}
	}

}//end Class

}//end namespace
