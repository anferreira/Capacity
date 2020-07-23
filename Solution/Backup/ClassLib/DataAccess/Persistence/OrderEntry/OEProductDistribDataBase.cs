using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{
	
public 
class OEProductDistribDataBase : GenericDataBaseElement{

private int OEPD_ID;
private string OEPD_Plant;
private string OEPD_ProdID;
private int OEPD_Seq;
private string OEPD_Description;
private string OEPD_ProdIDSellas;
private string OEPD_Uom;
private decimal OEPD_Cost;
private decimal OEPD_SellPrice01;
private decimal OEPD_SellPrice02;
private decimal OEPD_SellPrice03;
private decimal OEPD_SellPrice04;
private decimal OEPD_SellPrice05;
private decimal OEPD_SellPrice06;
private decimal OEPD_SellPrice07;
private decimal OEPD_SellPrice08;
private decimal OEPD_SellPrice09;
private decimal OEPD_SellPrice10;


public
OEProductDistribDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
    this.OEPD_ID = reader.GetInt32("OEPD_ID");
    this.OEPD_Plant = reader.GetString("OEPD_Plant");
    this.OEPD_ProdID = reader.GetString("OEPD_ProdID");
    this.OEPD_Seq = reader.GetInt32("OEPD_Seq");
    this.OEPD_Description = reader.GetString("OEPD_Description");
    this.OEPD_ProdIDSellas = reader.GetString("OEPD_ProdIDSellas");
    this.OEPD_Uom = reader.GetString("OEPD_Uom");
    this.OEPD_Cost = reader.GetDecimal("OEPD_Cost");
    this.OEPD_SellPrice01 = reader.GetDecimal("OEPD_SellPrice01");
    this.OEPD_SellPrice02 = reader.GetDecimal("OEPD_SellPrice02");
    this.OEPD_SellPrice03 = reader.GetDecimal("OEPD_SellPrice03");
    this.OEPD_SellPrice04 = reader.GetDecimal("OEPD_SellPrice04");
    this.OEPD_SellPrice05 = reader.GetDecimal("OEPD_SellPrice05");
    this.OEPD_SellPrice06 = reader.GetDecimal("OEPD_SellPrice06");
    this.OEPD_SellPrice07 = reader.GetDecimal("OEPD_SellPrice07");
    this.OEPD_SellPrice08 = reader.GetDecimal("OEPD_SellPrice08");
    this.OEPD_SellPrice09 = reader.GetDecimal("OEPD_SellPrice09");
    this.OEPD_SellPrice10 = reader.GetDecimal("OEPD_SellPrice10");
}

public override
void write(){
    try{
	    string sql = "insert into oeproductdistrib " + 
	                    "(OEPD_Plant,OEPD_ProdID,OEPD_Seq,OEPD_Description,OEPD_ProdIDSellas,OEPD_Uom," +
                         "OEPD_Cost,OEPD_SellPrice01,OEPD_SellPrice02,OEPD_SellPrice03,OEPD_SellPrice04," +
                         "OEPD_SellPrice05,OEPD_SellPrice06,OEPD_SellPrice07,OEPD_SellPrice08,"+
                         "OEPD_SellPrice09,OEPD_SellPrice10)" +
	                " values('" +
                                Converter.fixString(OEPD_Plant) +"', '" +
                                Converter.fixString(OEPD_ProdID) +"', " +
                                NumberUtil.toString(OEPD_Seq) +", '" +
                                Converter.fixString(OEPD_Description) +"', '" +
                                Converter.fixString(OEPD_ProdIDSellas) +"', '" +
                                Converter.fixString(OEPD_Uom) +"', " +
                                NumberUtil.toString(OEPD_Cost) +", " +
                                NumberUtil.toString(OEPD_SellPrice01) +", " +
                                NumberUtil.toString(OEPD_SellPrice02) +", " +
                                NumberUtil.toString(OEPD_SellPrice03) +", " +
                                NumberUtil.toString(OEPD_SellPrice04) +", " +
                                NumberUtil.toString(OEPD_SellPrice05) +", " +
                                NumberUtil.toString(OEPD_SellPrice06) +", " +
                                NumberUtil.toString(OEPD_SellPrice07) +", " +
                                NumberUtil.toString(OEPD_SellPrice08) +", " +
                                NumberUtil.toString(OEPD_SellPrice09) +", " +
                                NumberUtil.toString(OEPD_SellPrice10) +")";
        dataBaseAccess.executeUpdate(sql);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + se.Message,se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write>: " + de.Message,de);
	}catch(MySql.Data.MySqlClient.MySqlException mySqlExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + mySqlExc.Message,mySqlExc);
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
void read(){
 throw new PersistenceException("Method not implemented");
}

//Setters
public 
void setOEPD_ID (int OEPD_ID){
    this.OEPD_ID = OEPD_ID;
}

public 
void setOEPD_Plant (string OEPD_Plant){
    this.OEPD_Plant = OEPD_Plant;
}

public 
void setOEPD_ProdID (string OEPD_ProdID){
    this.OEPD_ProdID = OEPD_ProdID;
}

public 
void setOEPD_Seq (int OEPD_Seq){
    this.OEPD_Seq = OEPD_Seq;
}

public 
void setOEPD_Description (string OEPD_Description){
    this.OEPD_Description = OEPD_Description;
}

public 
void setOEPD_ProdIDSellas (string OEPD_ProdIDSellas){
    this.OEPD_ProdIDSellas = OEPD_ProdIDSellas;
}

public 
void setOEPD_Uom (string OEPD_Uom){
    this.OEPD_Uom = OEPD_Uom;
}

public 
void setOEPD_Cost (decimal OEPD_Cost){
    this.OEPD_Cost = OEPD_Cost;
}

public 
void setOEPD_SellPrice01 (decimal OEPD_SellPrice01){
    this.OEPD_SellPrice01 = OEPD_SellPrice01;
}

public 
void setOEPD_SellPrice02 (decimal OEPD_SellPrice02){
    this.OEPD_SellPrice02 = OEPD_SellPrice02;
}

public 
void setOEPD_SellPrice03 (decimal OEPD_SellPrice03){
    this.OEPD_SellPrice03 = OEPD_SellPrice03;
}

public 
void setOEPD_SellPrice04 (decimal OEPD_SellPrice04){
    this.OEPD_SellPrice04 = OEPD_SellPrice04;
}

public 
void setOEPD_SellPrice05 (decimal OEPD_SellPrice05){
    this.OEPD_SellPrice05 = OEPD_SellPrice05;
}

public 
void setOEPD_SellPrice06 (decimal OEPD_SellPrice06){
    this.OEPD_SellPrice06 = OEPD_SellPrice06;
}

public 
void setOEPD_SellPrice07 (decimal OEPD_SellPrice07){
    this.OEPD_SellPrice07 = OEPD_SellPrice07;
}

public 
void setOEPD_SellPrice08 (decimal OEPD_SellPrice08){
    this.OEPD_SellPrice08 = OEPD_SellPrice08;
}

public 
void setOEPD_SellPrice09 (decimal OEPD_SellPrice09){
    this.OEPD_SellPrice09 = OEPD_SellPrice09;
}

public 
void setOEPD_SellPrice10 (decimal OEPD_SellPrice10){
    this.OEPD_SellPrice10 = OEPD_SellPrice10;
}


//Getters
public 
int getOEPD_ID(){
    return OEPD_ID;
}

public 
string getOEPD_Plant(){
    return OEPD_Plant;
}

public 
string getOEPD_ProdID(){
    return OEPD_ProdID;
}

public 
int getOEPD_Seq(){
    return OEPD_Seq;
}

public 
string getOEPD_Description(){
    return OEPD_Description;
}

public 
string getOEPD_ProdIDSellas(){
    return OEPD_ProdIDSellas;
}

public 
string getOEPD_Uom(){
    return OEPD_Uom;
}

public 
decimal getOEPD_Cost(){
    return OEPD_Cost;
}

public 
decimal getOEPD_SellPrice01(){
    return OEPD_SellPrice01;
}

public 
decimal getOEPD_SellPrice02(){
    return OEPD_SellPrice02;
}

public 
decimal getOEPD_SellPrice03(){
    return OEPD_SellPrice03;
}

public 
decimal getOEPD_SellPrice04(){
    return OEPD_SellPrice04;
}

public 
decimal getOEPD_SellPrice05(){
    return OEPD_SellPrice05;
}

public 
decimal getOEPD_SellPrice06(){
    return OEPD_SellPrice06;
}

public 
decimal getOEPD_SellPrice07(){
    return OEPD_SellPrice07;
}

public 
decimal getOEPD_SellPrice08(){
    return OEPD_SellPrice08;
}

public 
decimal getOEPD_SellPrice09(){
    return OEPD_SellPrice09;
}

public 
decimal getOEPD_SellPrice10(){
    return OEPD_SellPrice10;
}

}//end class

}//end namespace
