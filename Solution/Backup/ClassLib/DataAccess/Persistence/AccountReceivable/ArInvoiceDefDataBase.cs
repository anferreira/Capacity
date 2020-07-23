using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class ArInvoiceDefDataBase : GenericDataBaseElement	{
    
private string ARID_Db;
private string ARID_InvType;
private string ARID_CustNum;
private string ARID_Plt;

public ArInvoiceDefDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){

}

public	void load(NotNullDataReader reader){
	this.ARID_Db = reader.GetString("ARID_Db");
	this.ARID_InvType = reader.GetString("ARID_InvType");
	this.ARID_CustNum = reader.GetString("ARID_CustNum");
	this.ARID_Plt = reader.GetString("ARID_Plt");
}

 public override   
    void write()  {
    	throw new PersistenceException("Method not implemented");
}

public override   
    void delete() {
    	throw new PersistenceException("Method not implemented");
}
public override   
    void update()  {
    	throw new PersistenceException("Method not implemented");
}

public
bool exists(){
    NotNullDataReader reader = null;
	try{
		bool ret = false;

		string sql = "select * from arinvoicedef " + 
			"where " +
			"ARID_Db = '" +Converter.fixString(ARID_Db) + "' and " +
			"ARID_CustNum = '" +Converter.fixString(ARID_CustNum) + "' and " +
			"ARID_InvType = '" +Converter.fixString(ARID_InvType)+"'";

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read()){
			ret = true;
			ArInvoiceDefDataBase arInvoiceDefDataBase = new ArInvoiceDefDataBase(dataBaseAccess);
			arInvoiceDefDataBase.load(reader);
         }
		return ret;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message,mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}
//Getters

public void setARID_Db(string	ARID_Db){
    this.ARID_Db = ARID_Db;
}
public void setARID_InvType(string	ARID_InvType){
    this.ARID_InvType = ARID_InvType;
}

public void setARID_CustNum(string ARID_CustNum){
    this.ARID_CustNum = ARID_CustNum;
}
public void setARID_Plt(string ARID_Plt){
    this.ARID_Plt = ARID_Plt;
}


//Setters
public string getARID_Db() {
    return ARID_Db;
}
public string getARID_InvType() {
    return ARID_InvType;
}

public string getARID_CustNum() {
    return ARID_CustNum;
}
public string getARID_Plt() {
    return ARID_Plt;
}
}
}
