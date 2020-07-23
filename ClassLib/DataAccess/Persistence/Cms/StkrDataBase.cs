using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class StkrDataBase : GenericDataBaseElement{

private string AXSTKL;
private string AXLOCN;
private DateTime AXLDAT;
private string AXPLNT;
private string AXSTTP;
private string AXBK01;
private string AXADR1;
private string AXADR2;
private string AXADR3;
private string AXPOST;
private decimal AXTEL;
private string AXHLD;
private string AXMRP;
private string AXQCSK;
private string AXBINC;
private string AXFLG1;
private string AXFLG2;
private string AXFLG3;
private string AXFLG4;
private string AXTXT1;
private string AXTXT2;
private string AXTXT3;
private string AXTXT4;

public 
StkrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public 
void load(NotNullDataReader reader){
    this.AXSTKL = reader.GetString("AXSTKL");
    this.AXLOCN = reader.GetString("AXLOCN");
    this.AXLDAT = reader.GetDateTime("AXLDAT");
    this.AXPLNT = reader.GetString("AXPLNT");
    this.AXSTTP = reader.GetString("AXSTTP");
    this.AXBK01 = reader.GetString("AXBK01");
    this.AXADR1 = reader.GetString("AXADR1");
    this.AXADR2 = reader.GetString("AXADR2");
    this.AXADR3 = reader.GetString("AXADR3");
    this.AXPOST = reader.GetString("AXPOST");
    this.AXTEL = reader.GetDecimal("AXTEL");
    this.AXHLD = reader.GetString("AXHLD");
    this.AXMRP = reader.GetString("AXMRP");
    this.AXQCSK = reader.GetString("AXQCSK");
    this.AXBINC = reader.GetString("AXBINC");
    this.AXFLG1 = reader.GetString("AXFLG1");
    this.AXFLG2 = reader.GetString("AXFLG2");
    this.AXFLG3 = reader.GetString("AXFLG3");
    this.AXFLG4 = reader.GetString("AXFLG4");
    this.AXTXT1 = reader.GetString("AXTXT1");
    this.AXTXT2 = reader.GetString("AXTXT2");
    this.AXTXT3 = reader.GetString("AXTXT3");
    this.AXTXT4 = reader.GetString("AXTXT4");
}

public override	
void write(){
	try{
		string sql = "insert into ";
		
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary + ".";
		
		sql += "stkr values('" +
			Converter.fixString(AXSTKL) + "', '" +
			Converter.fixString(AXLOCN) + "', '" +
			DateUtil.getCompleteDateRepresentation(AXLDAT) + "', '" +
			Converter.fixString(AXPLNT) + "', '" +
			Converter.fixString(AXSTTP) + "', '" +
			Converter.fixString(AXBK01) + "', '" +
			Converter.fixString(AXADR1) + "', '" +
			Converter.fixString(AXADR2) + "', '" +
			Converter.fixString(AXADR3) + "', '" +
			Converter.fixString(AXPOST) + "', " +
			NumberUtil.toString(AXTEL) + ", '" +
			Converter.fixString(AXHLD) + "', '" +
			Converter.fixString(AXMRP) + "', '" +
			Converter.fixString(AXQCSK) + "', '" +
			Converter.fixString(AXBINC) + "', '" +
			Converter.fixString(AXFLG1) + "', '" +
			Converter.fixString(AXFLG2) + "', '" +
			Converter.fixString(AXFLG3) + "', '" +
			Converter.fixString(AXFLG4) + "', '" +
			Converter.fixString(AXTXT1) + "', '" +
			Converter.fixString(AXTXT2) + "', '" +
			Converter.fixString(AXTXT3) + "', '" +
			Converter.fixString(AXTXT4) + "')";

		dataBaseAccess.executeUpdate(sql);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}
}

public override 
void update(){
	try{
		string sql = "update ";

		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
			sql += Configuration.CMSLibrary + ".";

		sql += "stkr set " +
			"AXLOCN = '" + Converter.fixString(AXLOCN) + "', " +
			"AXLDAT = '" + DateUtil.getCompleteDateRepresentation(AXLDAT) + "', " +
			"AXPLNT = '" + Converter.fixString(AXPLNT) + "', " +
			"AXSTTP = '" + Converter.fixString(AXSTTP) + "', " +
			"AXBK01 = '" + Converter.fixString(AXBK01) + "', " +
			"AXADR1 = '" + Converter.fixString(AXADR1) + "', " +
			"AXADR2 = '" + Converter.fixString(AXADR2) + "', " +
			"AXADR3 = '" + Converter.fixString(AXADR3) + "', " +
			"AXPOST = '" + Converter.fixString(AXPOST) + "', " +
			"AXTEL = " + NumberUtil.toString(AXTEL) + ", " +
			"AXHLD = '" + Converter.fixString(AXHLD) + "', " +
			"AXMRP = '" + Converter.fixString(AXMRP) + "', " +
			"AXQCSK = '" + Converter.fixString(AXQCSK) + "', " +
			"AXBINC = '" + Converter.fixString(AXBINC) + "', " +
			"AXFLG1 = '" + Converter.fixString(AXFLG1) + "', " +
			"AXFLG2 = '" + Converter.fixString(AXFLG2) + "', " +
			"AXFLG3 = '" + Converter.fixString(AXFLG3) + "', " +
			"AXFLG4 = '" + Converter.fixString(AXFLG4) + "', " +
			"AXTXT1 = '" + Converter.fixString(AXTXT1) + "', " +
			"AXTXT2 = '" + Converter.fixString(AXTXT2) + "', " +
			"AXTXT3 = '" + Converter.fixString(AXTXT3) + "', " +
			"AXTXT4 = '" + Converter.fixString(AXTXT4) + 
		"' where AXSTKL = '" + Converter.fixString(AXSTKL) + "'";

		dataBaseAccess.executeUpdate(sql);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}
}

public override 
void delete(){
		throw new PersistenceException("Method not implemented");
}

public 
void setAXSTKL(string AXSTKL){
	this.AXSTKL = AXSTKL;
}

public 
void setAXLOCN(string AXLOCN){
	this.AXLOCN = AXLOCN;
}

public 
void setAXLDAT(DateTime AXLDAT){
	this.AXLDAT = AXLDAT;
}

public 
void setAXPLNT(string AXPLNT){
	this.AXPLNT = AXPLNT;
}

public 
void setAXSTTP(string AXSTTP){
	this.AXSTTP = AXSTTP;
}

public 
void setAXBK01(string AXBK01){
	this.AXBK01 = AXBK01;
}

public 
void setAXADR1(string AXADR1){
	this.AXADR1 = AXADR1;
}

public 
void setAXADR2(string AXADR2){
	this.AXADR2 = AXADR2;
}

public 
void setAXADR3(string AXADR3){
	this.AXADR3 = AXADR3;
}

public 
void setAXPOST(string AXPOST){
	this.AXPOST = AXPOST;
}

public 
void setAXTEL(decimal AXTEL){
	this.AXTEL = AXTEL;
}

public 
void setAXHLD(string AXHLD){
	this.AXHLD = AXHLD;
}

public 
void setAXMRP(string AXMRP){
	this.AXMRP = AXMRP;
}

public 
void setAXQCSK(string AXQCSK){
	this.AXQCSK = AXQCSK;
}

public 
void setAXBINC(string AXBINC){
	this.AXBINC = AXBINC;
}

public 
void setAXFLG1(string AXFLG1){
	this.AXFLG1 = AXFLG1;
}

public 
void setAXFLG2(string AXFLG2){
	this.AXFLG2 = AXFLG2;
}

public 
void setAXFLG3(string AXFLG3){
	this.AXFLG3 = AXFLG3;
}

public 
void setAXFLG4(string AXFLG4){
	this.AXFLG4 = AXFLG4;
}

public 
void setAXTXT1(string AXTXT1){
	this.AXTXT1 = AXTXT1;
}

public 
void setAXTXT2(string AXTXT2){
	this.AXTXT2 = AXTXT2;
}

public 
void setAXTXT3(string AXTXT3){
	this.AXTXT3 = AXTXT3;
}

public 
void setAXTXT4(string AXTXT4){
	this.AXTXT4 = AXTXT4;
}


public 
string getAXSTKL(){
	return AXSTKL;
}

public 
string getAXLOCN(){
	return AXLOCN;
}

public 
DateTime getAXLDAT(){
	return AXLDAT;
}

public 
string getAXPLNT(){
	return AXPLNT;
}

public 
string getAXSTTP(){
	return AXSTTP;
}

public 
string getAXBK01(){
	return AXBK01;
}

public 
string getAXADR1(){
	return AXADR1;
}

public 
string getAXADR2(){
	return AXADR2;
}

public 
string getAXADR3(){
	return AXADR3;
}

public 
string getAXPOST(){
	return AXPOST;
}

public 
decimal getAXTEL(){
	return AXTEL;
}

public 
string getAXHLD(){
	return AXHLD;
}

public 
string getAXMRP(){
	return AXMRP;
}

public 
string getAXQCSK(){
	return AXQCSK;
}

public 
string getAXBINC(){
	return AXBINC;
}

public 
string getAXFLG1(){
	return AXFLG1;
}

public 
string getAXFLG2(){
	return AXFLG2;
}

public 
string getAXFLG3(){
	return AXFLG3;
}

public 
string getAXFLG4(){
	return AXFLG4;
}

public 
string getAXTXT1(){
	return AXTXT1;
}

public 
string getAXTXT2(){
	return AXTXT2;
}

public 
string getAXTXT3(){
	return AXTXT3;
}

public 
string getAXTXT4(){
	return AXTXT4;
}

} // class

} // namespace