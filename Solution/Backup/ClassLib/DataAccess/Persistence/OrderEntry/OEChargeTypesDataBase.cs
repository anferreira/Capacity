using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{

public class OEChargeTypesDataBase: GenericDataBaseElement{

private int CT_ID;
private string CT_ChargeType;
private string CT_Desc;
private string CT_SalesCOS;
private string CT_IncDec;
private decimal CT_GLAccountNum;

public OEChargeTypesDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){

}

public 
void load(NotNullDataReader reader){

    this.CT_ID = reader.GetInt32("CT_ID");
    this.CT_ChargeType = reader.GetString("CT_ChargeType");
    this.CT_Desc = reader.GetString("CT_Desc");
    this.CT_SalesCOS = reader.GetString("CT_SalesCOS");
    this.CT_IncDec = reader.GetString("CT_IncDec");
    this.CT_GLAccountNum = reader.GetDecimal("CT_GLAccountNum");
   
}

public 
void read(){

    NotNullDataReader reader = null;
	try{
		string sql = "select * from oechargetypes " +
		             "where " +
		                    "CT_ID = " + NumberUtil.toString(CT_ID);
			
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

public override 
void write(){
	try{
		string sql = "insert into oechargetypes (CT_ChargeType,CT_Desc,CT_SalesCOS,CT_IncDec,CT_GLAccountNum) " +
		            " values ('" + 
                                Converter.fixString(CT_ChargeType) +"', '" +
                                Converter.fixString(CT_Desc) +"', '" +
                                Converter.fixString(CT_SalesCOS) +"', '" +
                                Converter.fixString(CT_IncDec) +"', " +
                                NumberUtil.toString(CT_GLAccountNum)+ ")";
				 							
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message,mySqlExc);
	}
}

public override 
void update(){
	try{
		string sql = "update oechargetypes set " +
                        "CT_ChargeType = '" + Converter.fixString(CT_ChargeType) +"', " +
                        "CT_Desc = '" + Converter.fixString(CT_Desc) +"', " +
                        "CT_SalesCOS = '" +Converter.fixString(CT_SalesCOS) +"', " +
                        "CT_IncDec ='" +Converter.fixString(CT_IncDec) +"', " +
                        "CT_GLAccountNum = " + NumberUtil.toString(CT_GLAccountNum)+ " " +
		 			"where " +  
        				"CT_ID = " + NumberUtil.toString(CT_ID);
			dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <update> : " + mySqlExc.Message,mySqlExc);
	}
}

public override 
void delete(){
	try{
		string sql = "delete from oechargetypes where " +
						"CT_ID = " + NumberUtil.toString(CT_ID);
		dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <delete> : " + mySqlExc.Message,mySqlExc);
	}
}

public
bool exists(){
    NotNullDataReader reader = null;
	try{
		bool ret = false;

		string sql = "select * from oechargetypes " + 
			"where " +
			 "CT_ChargeType = '" + Converter.fixString(CT_ChargeType) +"'";

		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read()){
			load(reader);
			ret = true;
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

//Setters
public void setCT_ID (int CT_ID){
    this.CT_ID = CT_ID;
}

public void setCT_ChargeType (string CT_ChargeType){
    this.CT_ChargeType = CT_ChargeType;
}

public void setCT_Desc (string CT_Desc){
    this.CT_Desc = CT_Desc;
}

public void setCT_SalesCOS (string CT_SalesCOS){
    this.CT_SalesCOS = CT_SalesCOS;
}

public void setCT_IncDec (string CT_IncDec){
    this.CT_IncDec = CT_IncDec;
}

public void setCT_GLAccountNum(decimal CT_GLAccountNum){
    this.CT_GLAccountNum = CT_GLAccountNum;
}




//Getters
public int getCT_ID(){
    return CT_ID;
}

public string getCT_ChargeType(){
    return CT_ChargeType;
}

public string getCT_Desc(){
    return CT_Desc;
}

public string getCT_SalesCOS(){
    return CT_SalesCOS;
}

public string getCT_IncDec(){
    return CT_IncDec;
}

public decimal getCT_GLAccountNum(){
    return CT_GLAccountNum;
}




}
}
