using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class OePayTypeDataBase : GenericDataBaseElement{

private string OPT_Db;
private string OPT_PayType;
private string OPT_PayDesc;

public OePayTypeDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}

public
void load(NotNullDataReader reader){

    this.OPT_Db = reader.GetString("OPT_Db");
    this.OPT_PayType = reader.GetString("OPT_PayType");
    this.OPT_PayDesc = reader.GetString("OPT_PayDesc");
}

public override
void write(){

	string sql = "insert into oepaytype (OPT_Db,OPT_PayType, OPT_PayDesc)" +
		            "values('" +
                        Converter.fixString(OPT_Db) +"', '" +
                        Converter.fixString(OPT_PayType) +"', '" +
                        Converter.fixString(OPT_PayDesc) +"')";
    write(sql);
}


public override
void update(){
	string sql = "update oepaytype set " +
                    "OPT_PayDesc = '" + Converter.fixString(OPT_PayDesc) +"' " +
				"where " + getWhereCondition();
	update(sql);
}


public override
void delete(){
	string sql = "delete from oepaytype " +
			         "where " + getWhereCondition();
	delete(sql);
}


public
void read(){
    NotNullDataReader reader = null;
	try{
		string sql = "select * from oepaytype " + 
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
	string sql = "select * from oepaytype " + 
			"where " + getWhereCondition();
    return exists(sql);
}

private string getWhereCondition(){

string sql =   "OPT_Db = '" + Converter.fixString(OPT_Db) +"' and " +
                 "OPT_PayType = '" + Converter.fixString(OPT_PayType) +"'";
return sql;               
}

//Setters

public void setOPT_Db (string OPT_Db){
    this.OPT_Db = OPT_Db;
}

public void setOPT_PayType (string OPT_PayType){
    this.OPT_PayType = OPT_PayType;
}

public void setOPT_PayDesc (string OPT_PayDesc){
    this.OPT_PayDesc = OPT_PayDesc;
}


//Getters


public string getOPT_Db(){
    return OPT_Db;
}

public string getOPT_PayType(){
    return OPT_PayType;
}

public string getOPT_PayDesc(){
    return OPT_PayDesc;
}


}//end class
}//end namespace
