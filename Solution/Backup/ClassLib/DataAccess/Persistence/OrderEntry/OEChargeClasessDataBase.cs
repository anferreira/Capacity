using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
	
public class OEChargeClassesDataBase : GenericDataBaseElement{	

private int CC_ID;
private string CC_ChargeClass;
private string CC_ChargeType;
private string CC_Description;
private string CC_Customer;
private string CC_Supplier;
private decimal CC_Percentage;

public OEChargeClassesDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){

}

public 
void load(NotNullDataReader reader){
    this.CC_ID = reader.GetInt32("CC_ID");
    this.CC_ChargeClass = reader.GetString("CC_ChargeClass");
    this.CC_ChargeType = reader.GetString("CC_ChargeType ");
    this.CC_Description = reader.GetString("CC_Description");
    this.CC_Customer = reader.GetString("CC_Customer");
    this.CC_Supplier = reader.GetString("CC_Supplier");
    this.CC_Percentage = reader.GetDecimal("CC_Percentage");
    
}

public 
void read(){

    NotNullDataReader reader = null;
	try{
		string sql = "select * from oechargeclasses where " +
			"CC_ID = " + NumberUtil.toString(CC_ID);

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

public override 
void write(){
	try{
		string sql = "insert into oechargeclasses (CC_ChargeClass,CC_ChargeType,CC_Description, " +
		                                        "CC_Customer,CC_Supplier,CC_Percentage) " +
		                "values('" + 
                                Converter.fixString(CC_ChargeClass) +"', '" +
                                Converter.fixString(CC_ChargeType) +"', '" +
                                Converter.fixString(CC_Description) +"', '" +
                                Converter.fixString(CC_Customer) +"', '" +
                                Converter.fixString(CC_Supplier) +"', " +
                                NumberUtil.toString(CC_Percentage) + ")";
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message, mySqlExc);
	}
}

public override 
void update(){
	try{
		string sql = "update oechargeclasses set " +	
		                   "CC_ChargeClass ='" + Converter.fixString(CC_ChargeClass) +"', " +
                           "CC_ChargeType = '" + Converter.fixString(CC_ChargeType) +"', " +
                           "CC_Description = '" + Converter.fixString(CC_Description) +"', "  +	 
                           "CC_Customer = '" + Converter.fixString(CC_Customer) +"', " +
                           "CC_Supplier = '" + Converter.fixString(CC_Supplier) +"', " +
                           "CC_Percentage = " + NumberUtil.toString(CC_Percentage) +  " " +                         
    				"where " +  
        				"CC_ID = " + NumberUtil.toString(CC_ID);
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
void delete(){
	try{
		string sql = "delete from oechargeclasses where " +
						"CC_ID = " + NumberUtil.toString(CC_ID);
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message, mySqlExc);
	}
}

public
bool exists(){
    NotNullDataReader reader = null;
	try{
		bool ret = false;

		string sql = "select * from oechargeclasses " + 
			"where " +
			 "CC_ChargeClass ='" + Converter.fixString(CC_ChargeClass)+"' and " +
             "CC_ChargeType = '" + Converter.fixString(CC_ChargeType) +"'";

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read()){
			load(reader);
			ret = true;
		}
		return ret;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists>: " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists>: " + de.Message, de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <exists> : " + mySqlExc.Message, mySqlExc);
	}finally{
		if (reader != null)
			reader.Close();
	}
}


//Setters
public void setCC_ID (int CC_ID){
    this.CC_ID = CC_ID;
}

public void setCC_ChargeClass (string CC_ChargeClass){
    this.CC_ChargeClass = CC_ChargeClass;
}

public void setCC_Description (string CC_Description){
    this.CC_Description = CC_Description;
}


public void setCC_ChargeType (string CC_ChargeType){
    this.CC_ChargeType = CC_ChargeType;
}

public void setCC_Customer (string CC_Customer){
    this.CC_Customer = CC_Customer;
}

public void setCC_Supplier (string CC_Supplier){
    this.CC_Supplier = CC_Supplier;
}

public void setCC_Percentage (decimal CC_Percentage){
    this.CC_Percentage = CC_Percentage;
}


//Getters
public int getCC_ID(){
    return CC_ID;
}

public string getCC_ChargeClass(){
    return CC_ChargeClass;
}

public string getCC_Description(){
    return CC_Description;
}

public string getCC_ChargeType(){
    return CC_ChargeType;
}

public string getCC_Customer(){
    return CC_Customer;
}

public string getCC_Supplier(){
    return CC_Supplier;
}

public decimal getCC_Percentage(){
    return CC_Percentage;
}



}//end class
}//end namespace
