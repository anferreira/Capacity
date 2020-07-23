using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{
public 
class PsscDataBase : GenericDataBaseElement{
private string UZPART;
private int UZSEQ;
private decimal UZI1LB;
private decimal UZI1BD;
private decimal UZI1MT;
private decimal UZI1OT;
private decimal UZI2LB;
private decimal UZI2BD;
private decimal UZI2MT;
private decimal UZI2OT;
private decimal UZL1LB;
private decimal UZL1BD;
private decimal UZL1MT;
private decimal UZL1OT;
private decimal UZL2LB;
private decimal UZL2BD;
private decimal UZL2MT;
private decimal UZL2OT;
private decimal UZI1BF;
private decimal UZI1BV;
private decimal UZI2BF;
private decimal UZI2BV;
private decimal UZL1BF;
private decimal UZL1BV;
private decimal UZL2BF;
private decimal UZL2BV;
private string UZPLNT;
private string UZFUT1;
private string UZFUT2;
private string UZFUT3;
private decimal UZFUT4;
private decimal UZFUT5;
private string UZFLG1;
private string UZFLG2;
private string UZFLG3;
public 
PsscDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
public
void load(NotNullDataReader reader){
    this.UZPART = reader.GetString("UZPART");
    this.UZSEQ = decimal.ToInt32(reader.GetDecimal(1));
    this.UZI1LB = reader.GetDecimal("UZI1LB");
    this.UZI1BD = reader.GetDecimal("UZI1BD");
    this.UZI1MT = reader.GetDecimal("UZI1MT");
    this.UZI1OT = reader.GetDecimal("UZI1OT");
    this.UZI2LB = reader.GetDecimal("UZI2LB");
    this.UZI2BD = reader.GetDecimal("UZI2BD");
    this.UZI2MT = reader.GetDecimal("UZI2MT");
    this.UZI2OT = reader.GetDecimal("UZI2OT");
    this.UZL1LB = reader.GetDecimal("UZL1LB");
    this.UZL1BD = reader.GetDecimal("UZL1BD");
    this.UZL1MT = reader.GetDecimal("UZL1MT");
    this.UZL1OT = reader.GetDecimal("UZL1OT");
    this.UZL2LB = reader.GetDecimal("UZL2LB");
    this.UZL2BD = reader.GetDecimal("UZL2BD");
    this.UZL2MT = reader.GetDecimal("UZL2MT");
    this.UZL2OT = reader.GetDecimal("UZL2OT");
    this.UZI1BF = reader.GetDecimal("UZI1BF");
    this.UZI1BV = reader.GetDecimal("UZI1BV");
    this.UZI2BF = reader.GetDecimal("UZI2BF");
    this.UZI2BV = reader.GetDecimal("UZI2BV");
    this.UZL1BF = reader.GetDecimal("UZL1BF");
    this.UZL1BV = reader.GetDecimal("UZL1BV");
    this.UZL2BF = reader.GetDecimal("UZL2BF");
    this.UZL2BV = reader.GetDecimal("UZL2BV");
    this.UZPLNT = reader.GetString("UZPLNT");
    this.UZFUT1 = reader.GetString("UZFUT1");
    this.UZFUT2 = reader.GetString("UZFUT2");
    this.UZFUT3 = reader.GetString("UZFUT3");
    this.UZFUT4 = reader.GetDecimal("UZFUT4");
    this.UZFUT5 = reader.GetDecimal("UZFUT5");
    this.UZFLG1 = reader.GetString("UZFLG1");
    this.UZFLG2 = reader.GetString("UZFLG2");
    this.UZFLG3 = reader.GetString("UZFLG3");
}
public override
void write(){
   try{
		string sql = "insert into pssc values('" +
            Converter.fixString(UZPART) +"',' " +
            NumberUtil.toString(UZSEQ) +"', " +
            NumberUtil.toString(UZI1LB) +", " +
            NumberUtil.toString(UZI1BD) +", " +
            NumberUtil.toString(UZI1MT) +", " +
            NumberUtil.toString(UZI1OT) +", " +
            NumberUtil.toString(UZI2LB) +", " +
            NumberUtil.toString(UZI2BD) +", " +
            NumberUtil.toString(UZI2MT) +", " +
            NumberUtil.toString(UZI2OT) +", " +
            NumberUtil.toString(UZL1LB) +", " +
            NumberUtil.toString(UZL1BD) +", " +
            NumberUtil.toString(UZL1MT) +", " +
            NumberUtil.toString(UZL1OT) +", " +
            NumberUtil.toString(UZL2LB) +", " +
            NumberUtil.toString(UZL2BD) +", " +
            NumberUtil.toString(UZL2MT) +", " +
            NumberUtil.toString(UZL2OT) +", " +
            NumberUtil.toString(UZI1BF) +", " +
            NumberUtil.toString(UZI1BV) +", " +
            NumberUtil.toString(UZI2BF) +", " +
            NumberUtil.toString(UZI2BV) +", " +
            NumberUtil.toString(UZL1BF) +", " +
            NumberUtil.toString(UZL1BV) +", " +
            NumberUtil.toString(UZL2BF) +", " +
            NumberUtil.toString(UZL2BV) +", '" +
            Converter.fixString(UZPLNT) +"', '" +
            Converter.fixString(UZFUT1) +"', '" +
            Converter.fixString(UZFUT2) +"', '" +
            Converter.fixString(UZFUT3) +"', " +
            NumberUtil.toString(UZFUT4) +", " +
            NumberUtil.toString(UZFUT5) +", '" +
            Converter.fixString(UZFLG1) +"', '" +
            Converter.fixString(UZFLG2) +"', '" +
            Converter.fixString(UZFLG3) +"')";
       dataBaseAccess.executeUpdate(sql);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}
}
public 
void read(){
	NotNullDataReader reader = null;
	try{
		string sql = "select * from ";
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary + ".";
		sql += "pssc where " +
			"UZPLNT = '" + Converter.fixString(UZPLNT) + "' and " +
			"UZPART = '" + Converter.fixString(UZPART) + "' and " +
			"UZSEQ = " + NumberUtil.toString(UZSEQ);
		
		reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			load(reader);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}finally{
		if (reader != null)
			reader.Close();
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
public 
void setUZPART (string UZPART){
    this.UZPART = UZPART;
}
public 
void setUZSEQ (int UZSEQ){
    this.UZSEQ = UZSEQ;
}
public 
void setUZI1LB (decimal UZI1LB){
    this.UZI1LB = UZI1LB;
}
public 
void setUZI1BD (decimal UZI1BD){
    this.UZI1BD = UZI1BD;
}
public 
void setUZI1MT (decimal UZI1MT){
    this.UZI1MT = UZI1MT;
}
public 
void setUZI1OT (decimal UZI1OT){
    this.UZI1OT = UZI1OT;
}
public 
void setUZI2LB (decimal UZI2LB){
    this.UZI2LB = UZI2LB;
}
public 
void setUZI2BD (decimal UZI2BD){
    this.UZI2BD = UZI2BD;
}
public 
void setUZI2MT (decimal UZI2MT){
    this.UZI2MT = UZI2MT;
}
public 
void setUZI2OT (decimal UZI2OT){
    this.UZI2OT = UZI2OT;
}
public 
void setUZL1LB (decimal UZL1LB){
    this.UZL1LB = UZL1LB;
}
public 
void setUZL1BD (decimal UZL1BD){
    this.UZL1BD = UZL1BD;
}
public 
void setUZL1MT (decimal UZL1MT){
    this.UZL1MT = UZL1MT;
}
public 
void setUZL1OT (decimal UZL1OT){
    this.UZL1OT = UZL1OT;
}
public 
void setUZL2LB (decimal UZL2LB){
    this.UZL2LB = UZL2LB;
}
public 
void setUZL2BD (decimal UZL2BD){
    this.UZL2BD = UZL2BD;
}
public 
void setUZL2MT (decimal UZL2MT){
    this.UZL2MT = UZL2MT;
}
public 
void setUZL2OT (decimal UZL2OT){
    this.UZL2OT = UZL2OT;
}
public 
void setUZI1BF (decimal UZI1BF){
    this.UZI1BF = UZI1BF;
}
public 
void setUZI1BV (decimal UZI1BV){
    this.UZI1BV = UZI1BV;
}
public 
void setUZI2BF (decimal UZI2BF){
    this.UZI2BF = UZI2BF;
}
public 
void setUZI2BV (decimal UZI2BV){
    this.UZI2BV = UZI2BV;
}
public 
void setUZL1BF (decimal UZL1BF){
    this.UZL1BF = UZL1BF;
}
public 
void setUZL1BV (decimal UZL1BV){
    this.UZL1BV = UZL1BV;
}
public 
void setUZL2BF (decimal UZL2BF){
    this.UZL2BF = UZL2BF;
}
public 
void setUZL2BV (decimal UZL2BV){
    this.UZL2BV = UZL2BV;
}
public 
void setUZPLNT (string UZPLNT){
    this.UZPLNT = UZPLNT;
}
public 
void setUZFUT1 (string UZFUT1){
    this.UZFUT1 = UZFUT1;
}
public 
void setUZFUT2 (string UZFUT2){
    this.UZFUT2 = UZFUT2;
}
public 
void setUZFUT3 (string UZFUT3){
    this.UZFUT3 = UZFUT3;
}
public 
void setUZFUT4 (decimal UZFUT4){
    this.UZFUT4 = UZFUT4;
}
public 
void setUZFUT5 (decimal UZFUT5){
    this.UZFUT5 = UZFUT5;
}
public 
void setUZFLG1 (string UZFLG1){
    this.UZFLG1 = UZFLG1;
}
public 
void setUZFLG2 (string UZFLG2){
    this.UZFLG2 = UZFLG2;
}
public 
void setUZFLG3 (string UZFLG3){
    this.UZFLG3 = UZFLG3;
}
//Getters
public 
string getUZPART(){
    return UZPART;
}
public 
int getUZSEQ(){
    return UZSEQ;
}
public 
decimal getUZI1LB(){
    return UZI1LB;
}
public 
decimal getUZI1BD(){
    return UZI1BD;
}
public 
decimal getUZI1MT(){
    return UZI1MT;
}
public 
decimal getUZI1OT(){
    return UZI1OT;
}
public 
decimal getUZI2LB(){
    return UZI2LB;
}
public 
decimal getUZI2BD(){
    return UZI2BD;
}
public 
decimal getUZI2MT(){
    return UZI2MT;
}
public 
decimal getUZI2OT(){
    return UZI2OT;
}
public 
decimal getUZL1LB(){
    return UZL1LB;
}
public 
decimal getUZL1BD(){
    return UZL1BD;
}
public 
decimal getUZL1MT(){
    return UZL1MT;
}
public 
decimal getUZL1OT(){
    return UZL1OT;
}
public 
decimal getUZL2LB(){
    return UZL2LB;
}
public 
decimal getUZL2BD(){
    return UZL2BD;
}
public 
decimal getUZL2MT(){
    return UZL2MT;
}
public 
decimal getUZL2OT(){
    return UZL2OT;
}
public 
decimal getUZI1BF(){
    return UZI1BF;
}
public 
decimal getUZI1BV(){
    return UZI1BV;
}
public 
decimal getUZI2BF(){
    return UZI2BF;
}
public 
decimal getUZI2BV(){
    return UZI2BV;
}
public 
decimal getUZL1BF(){
    return UZL1BF;
}
public 
decimal getUZL1BV(){
    return UZL1BV;
}
public 
decimal getUZL2BF(){
    return UZL2BF;
}
public 
decimal getUZL2BV(){
    return UZL2BV;
}
public 
string getUZPLNT(){
    return UZPLNT;
}
public 
string getUZFUT1(){
    return UZFUT1;
}
public 
string getUZFUT2(){
    return UZFUT2;
}
public 
string getUZFUT3(){
    return UZFUT3;
}
public 
decimal getUZFUT4(){
    return UZFUT4;
}
public 
decimal getUZFUT5(){
    return UZFUT5;
}
public 
string getUZFLG1(){
    return UZFLG1;
}
public 
string getUZFLG2(){
    return UZFLG2;
}
public 
string getUZFLG3(){
    return UZFLG3;
}
}//end class
}//end namesapce
