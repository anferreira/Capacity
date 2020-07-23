using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
	
public class ProductsCodeDataBase : GenericDataBaseElement{	

private int PRDC_ID;
private string PRDC_ProdCode;
private string PRDC_Description;
private string PRDC_DescKey;
private string PRDC_Code1;
private string PRDC_Code2;
private string PRDC_Code3;
private string PRDC_Code4;
private string PRDC_Code5;
private string PRDC_Code6;

public ProductsCodeDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){

}

public 
void load(NotNullDataReader reader){
    this.PRDC_ID = reader.GetInt32("PRDC_ID");
    this.PRDC_ProdCode = reader.GetString("PRDC_ProdCode");
    this.PRDC_Description = reader.GetString("PRDC_Description");
    this.PRDC_DescKey = reader.GetString("PRDC_DescKey");
    this.PRDC_Code1 = reader.GetString("PRDC_Code1");
    this.PRDC_Code2 = reader.GetString("PRDC_Code2");
    this.PRDC_Code3 = reader.GetString("PRDC_Code3");
    this.PRDC_Code4 = reader.GetString("PRDC_Code4");
    this.PRDC_Code5 = reader.GetString("PRDC_Code5");
    this.PRDC_Code6 = reader.GetString("PRDC_Code6");
}

public 
void read(){

    NotNullDataReader reader = null;
	try{
		string sql = "select * from productscode where " +
			"PRDC_ID = " + NumberUtil.toString(PRDC_ID);

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
		string sql = "insert into productscode (PRDC_ProdCode,PRDC_Description,PRDC_DescKey,PRDC_Code1,PRDC_Code2,"+
		                                        "PRDC_Code3,PRDC_Code4,PRDC_Code5,PRDC_Code6) " +
		                "values('" + 
                                    Converter.fixString(PRDC_ProdCode) +"', '" +
                                    Converter.fixString(PRDC_Description) +"', '" +
                                    Converter.fixString(PRDC_DescKey) +"', '" +
                                    Converter.fixString(PRDC_Code1) +"', '" +
                                    Converter.fixString(PRDC_Code2) +"', '" +
                                    Converter.fixString(PRDC_Code3) +"', '" +
                                    Converter.fixString(PRDC_Code4) +"', '" +
                                    Converter.fixString(PRDC_Code5) +"', '" +
                                    Converter.fixString(PRDC_Code6) +"')";
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
	throw new PersistenceException("Method not implemented");
}

public override 
void delete(){
	throw new PersistenceException("Method not implemented");
}

public
bool exists(){
   throw new PersistenceException("Method not implemented");
}


//Setters
public void setPRDC_ID (int PRDC_ID){
    this.PRDC_ID = PRDC_ID;
}

public void setPRDC_ProdCode (string PRDC_ProdCode){
    this.PRDC_ProdCode = PRDC_ProdCode;
}

public void setPRDC_Description (string PRDC_Description){
    this.PRDC_Description = PRDC_Description;
}

public void setPRDC_DescKey (string PRDC_DescKey){
    this.PRDC_DescKey = PRDC_DescKey;
}

public void setPRDC_Code1 (string PRDC_Code1){
    this.PRDC_Code1 = PRDC_Code1;
}

public void setPRDC_Code2 (string PRDC_Code2){
    this.PRDC_Code2 = PRDC_Code2;
}

public void setPRDC_Code3 (string PRDC_Code3){
    this.PRDC_Code3 = PRDC_Code3;
}

public void setPRDC_Code4 (string PRDC_Code4){
    this.PRDC_Code4 = PRDC_Code4;
}

public void setPRDC_Code5 (string PRDC_Code5){
    this.PRDC_Code5 = PRDC_Code5;
}

public void setPRDC_Code6 (string PRDC_Code6){
    this.PRDC_Code6 = PRDC_Code6;
}


//Getters
public int getPRDC_ID(){
    return PRDC_ID;
}

public string getPRDC_ProdCode(){
    return PRDC_ProdCode;
}

public string getPRDC_Description(){
    return PRDC_Description;
}

public string getPRDC_DescKey(){
    return PRDC_DescKey;
}

public string getPRDC_Code1(){
    return PRDC_Code1;
}

public string getPRDC_Code2(){
    return PRDC_Code2;
}

public string getPRDC_Code3(){
    return PRDC_Code3;
}

public string getPRDC_Code4(){
    return PRDC_Code4;
}

public string getPRDC_Code5(){
    return PRDC_Code5;
}

public string getPRDC_Code6(){
    return PRDC_Code6;
}


}//end class
}//end namespace
