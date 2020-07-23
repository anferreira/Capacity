using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public class TPartnerDataBase : GenericDataBaseElement{

private string TP_TpartnerType;
private string TP_Tpartner;
private string TP_TPartnerName;
private string TP_TPContact;
private string TP_PhoneNumber;
private string TP_FaxNumber;


public TPartnerDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}


public
void load(NotNullDataReader reader){

this.TP_TpartnerType = reader.GetString("TP_TpartnerType");
this.TP_Tpartner = reader.GetString("TP_Tpartner");
this.TP_TPartnerName = reader.GetString("TP_TPartnerName");
this.TP_TPContact = reader.GetString("TP_TPContact");
this.TP_PhoneNumber = reader.GetString("TP_PhoneNumber");
this.TP_FaxNumber = reader.GetString("TP_FaxNumber");
}

public override
void write(){
	try{
		string sql = "insert into tpartner values('" + 
                Converter.fixString(TP_TpartnerType) +"', '" +
                Converter.fixString(TP_Tpartner) +"', '" +
                Converter.fixString(TP_TPartnerName) +"', '" +
                Converter.fixString(TP_TPContact) +"', '" +
                Converter.fixString(TP_PhoneNumber) +"', '" +
                Converter.fixString(TP_FaxNumber) +"')";
            dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de)	{
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public override
void update(){
	throw new PersistenceException("Method not implemented");
}

public override
void delete(){
	throw new PersistenceException("Method not implemented");
}

//Setters
public void setTP_TpartnerType (string TP_TpartnerType){
    this.TP_TpartnerType = TP_TpartnerType;
}

public void setTP_Tpartner (string TP_Tpartner){
    this.TP_Tpartner = TP_Tpartner;
}

public void setTP_TPartnerName (string TP_TPartnerName){
    this.TP_TPartnerName = TP_TPartnerName;
}

public void setTP_TPContact (string TP_TPContact){
    this.TP_TPContact = TP_TPContact;
}

public void setTP_PhoneNumber (string TP_PhoneNumber){
    this.TP_PhoneNumber = TP_PhoneNumber;
}

public void setTP_FaxNumber (string TP_FaxNumber){
    this.TP_FaxNumber = TP_FaxNumber;
}


//Getters
public string getTP_TpartnerType(){
    return TP_TpartnerType;
}

public string getTP_Tpartner(){
    return TP_Tpartner;
}

public string getTP_TPartnerName(){
    return TP_TPartnerName;
}

public string getTP_TPContact(){
    return TP_TPContact;
}

public string getTP_PhoneNumber(){
    return TP_PhoneNumber;
}

public string getTP_FaxNumber(){
    return TP_FaxNumber;
}


}//end class
}//end namepsace
