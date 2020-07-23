using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class OeInvTypeDataBase : GenericDataBaseElement{

private string IT_Db;
private string IT_InvoiceType;
private string IT_Description;
private string IT_FromOrder;
private string IT_FromPackSlip;
private string IT_InvoiceAdd;
private string IT_InvStatement;

public OeInvTypeDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}

public
void load(NotNullDataReader reader){

    this.IT_Db = reader.GetString("IT_Db");
    this.IT_InvoiceType = reader.GetString("IT_InvoiceType");
    this.IT_Description = reader.GetString("IT_Description");
    this.IT_FromOrder = reader.GetString("IT_FromOrder");
    this.IT_FromPackSlip = reader.GetString("IT_FromPackSlip");
    this.IT_InvoiceAdd = reader.GetString("IT_InvoiceAdd");
    this.IT_InvStatement = reader.GetString("IT_InvStatement");
}

public override
void write(){

	string sql = "insert into oeinvtype (IT_Db,IT_InvoiceType, IT_Description,IT_FromOrder,IT_FromPackSlip, " +
                                        "IT_InvoiceAdd,IT_InvStatement )" +
		            "values('" +
                        Converter.fixString(IT_Db) +"', '" +
                        Converter.fixString(IT_InvoiceType) +"', '" +
                        Converter.fixString(IT_Description) +"', '" +
                        Converter.fixString(IT_FromOrder) +"', '" +
                        Converter.fixString(IT_FromPackSlip) +"', '" +
                        Converter.fixString(IT_InvoiceAdd) +"', '" +
                        Converter.fixString(IT_InvStatement) +"')";
    write(sql);
}


public override
void update(){
	string sql = "update oeinvtype set " +
                    "IT_Description = '" + Converter.fixString(IT_Description) +"', " +
                    "IT_FromOrder = '" + Converter.fixString(IT_FromOrder) +"', " +
                    "IT_FromPackSlip = '" + Converter.fixString(IT_FromPackSlip) +"', " +
                    "IT_InvoiceAdd = '" + Converter.fixString(IT_InvoiceAdd) +"', '" +
                    "IT_InvStatement = '" +Converter.fixString(IT_InvStatement) +"' " +
				"where " + getWhereCondition();
	update(sql);
}


public override
void delete(){
	string sql = "delete from oeinvtype " +
			         "where " + getWhereCondition();
	delete(sql);
}


public
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from oeinvtype " + 
			         "where " + getWhereCondition();

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);

	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <read> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


public
bool exists(){
	string sql = "select * from oeinvtype " + 
			"where " + getWhereCondition();
    return exists(sql);
}

private string getWhereCondition(){

string sql =   "IT_Db = '" + Converter.fixString(IT_Db) +"' and " +
                 "IT_InvoiceType = '" + Converter.fixString(IT_InvoiceType) +"'";
return sql;               
}

//Setters
public void setIT_Db (string IT_Db){
    this.IT_Db = IT_Db;
}

public void setIT_InvoiceType (string IT_InvoiceType){
    this.IT_InvoiceType = IT_InvoiceType;
}

public void setIT_Description (string IT_Description){
    this.IT_Description = IT_Description;
}

public void setIT_FromOrder (string IT_FromOrder){
    this.IT_FromOrder = IT_FromOrder;
}

public void setIT_FromPackSlip (string IT_FromPackSlip){
    this.IT_FromPackSlip = IT_FromPackSlip;
}

public void setIT_InvoiceAdd (string IT_InvoiceAdd){
    this.IT_InvoiceAdd = IT_InvoiceAdd;
}

public void setIT_InvStatement (string IT_InvStatement){
    this.IT_InvStatement = IT_InvStatement;
}



//Getters

public string getIT_Db(){
    return IT_Db;
}

public string getIT_InvoiceType(){
    return IT_InvoiceType;
}

public string getIT_Description(){
    return IT_Description;
}

public string getIT_FromOrder(){
    return IT_FromOrder;
}

public string getIT_FromPackSlip(){
    return IT_FromPackSlip;
}

public string getIT_InvoiceAdd(){
    return IT_InvoiceAdd;
}

public string getIT_InvStatement(){
    return IT_InvStatement;
}




}//end class
}//end namespace
