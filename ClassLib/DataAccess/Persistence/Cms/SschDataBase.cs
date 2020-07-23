using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class SschDataBase : GenericDataBaseElement{

private string JYCODE;
private DateTime JYDATE;
private decimal JYTIME;
private decimal JYENTR;
private DateTime JYODAT;
private decimal JYOTME;
private decimal JYSQTY;
private string JYBSUN;
private string JYORUN;
private string JYOWCD;
private string JYAPPR;
private string JYORWS;
private decimal JYORDR;
private decimal JYITEM;
private string JYRELN;
private string JYAUTH;
private decimal JYPORL;
private string JYPART;
private string JYSCUS;
private string JYSTKL;
private string JYTERR;
private decimal JYCUMQ;
private string JYCUMY;
private string JYDOCK;
private decimal JYSEQN;
private string JYRANY;
private string JYRAN;
private string JYKANB;
private string JYINTC;
private string JYLATF;

public
SschDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
    this.JYCODE = reader.GetString("JYCODE");
    this.JYDATE = reader.GetDateTime("JYDATE");
    this.JYTIME = reader.GetDecimal("JYTIME");
    this.JYENTR = reader.GetDecimal("JYENTR");
    this.JYODAT = reader.GetDateTime("JYODAT");
    this.JYOTME = reader.GetDecimal("JYOTME");
    this.JYSQTY = reader.GetDecimal("JYSQTY");
    this.JYBSUN = reader.GetString("JYBSUN");
    this.JYORUN = reader.GetString("JYORUN");
    this.JYOWCD = reader.GetString("JYOWCD");
    this.JYAPPR = reader.GetString("JYAPPR");
    this.JYORWS = reader.GetString("JYORWS");
    this.JYORDR = reader.GetDecimal("JYORDR");
    this.JYITEM = reader.GetDecimal("JYITEM");
    this.JYRELN = reader.GetString("JYRELN");
    this.JYAUTH = reader.GetString("JYAUTH");
    this.JYPORL = reader.GetDecimal("JYPORL");
    this.JYPART = reader.GetString("JYPART");
    this.JYSCUS = reader.GetString("JYSCUS");
    this.JYSTKL = reader.GetString("JYSTKL");
    this.JYTERR = reader.GetString("JYTERR");
    this.JYCUMQ = reader.GetDecimal("JYCUMQ");
    this.JYCUMY = reader.GetString("JYCUMY");
    this.JYDOCK = reader.GetString("JYDOCK");
    this.JYSEQN = reader.GetDecimal("JYSEQN");
    this.JYRANY = reader.GetString("JYRANY");
    this.JYRAN = reader.GetString("JYRAN");
    this.JYKANB = reader.GetString("JYKANB");
    this.JYINTC = reader.GetString("JYINTC");
    this.JYLATF = reader.GetString("JYLATF");

}

public override
void write(){
	try{
		string sql = "insert into ssch values('" +
			Converter.fixString(JYCODE) + "', '" +
			DateUtil.getDateRepresentation(JYDATE) + "', " + 
			JYTIME + ", " +
			JYENTR + ", '" +
			DateUtil.getDateRepresentation(JYODAT) + "', " + 
			JYOTME + ", " +
			JYSQTY + ", '" +
			Converter.fixString(JYBSUN) + "', '" +
			Converter.fixString(JYORUN) + "', '" +
			Converter.fixString(JYOWCD) + "', '" +
			Converter.fixString(JYAPPR) + "', '" +
			Converter.fixString(JYORWS) + "', " +
			JYORDR + ", " +
			JYITEM + ", '" +
			Converter.fixString(JYRELN) + "', '" +
			Converter.fixString(JYAUTH) + "', " +
			JYPORL + ", '" +
			Converter.fixString(JYPART) + "', '" +
			Converter.fixString(JYSCUS) + "', '" +
			Converter.fixString(JYSTKL) + "', '" +
			Converter.fixString(JYTERR) + "', " +
			JYCUMQ + ", '" +
			Converter.fixString(JYCUMY) + "', '" +
			Converter.fixString(JYDOCK) + "', " +
			JYSEQN + ", '" +
			Converter.fixString(JYRANY) + "', '" +
			Converter.fixString(JYRAN) + "', '" +
			Converter.fixString(JYKANB) + "', '" +
			Converter.fixString(JYINTC) + "', '" +
			Converter.fixString(JYLATF) + "')";
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
	throw new PersistenceException("Method not implemented");
}

public override
void delete(){
	throw new PersistenceException("Method not implemented");
}

public
void setJYCODE(string JYCODE){
	this.JYCODE = JYCODE;
}

public
void setJYDATE(DateTime JYDATE){
	this.JYDATE = JYDATE;
}

public
void setJYTIME(decimal JYTIME){
	this.JYTIME = JYTIME;
}

public
void setJYENTR(decimal JYENTR){
	this.JYENTR = JYENTR;
}

public
void setJYODAT(DateTime JYODAT){
	this.JYODAT = JYODAT;
}

public
void setJYOTME(decimal JYOTME){
	this.JYOTME = JYOTME;
}

public
void setJYSQTY(decimal JYSQTY){
	this.JYSQTY = JYSQTY;
}

public
void setJYBSUN(string JYBSUN){
	this.JYBSUN = JYBSUN;
}

public
void setJYORUN(string JYORUN){
	this.JYORUN = JYORUN;
}

public
void setJYOWCD(string JYOWCD){
	this.JYOWCD = JYOWCD;
}

public
void setJYAPPR(string JYAPPR){
	this.JYAPPR = JYAPPR;
}

public
void setJYORWS(string JYORWS){
	this.JYORWS = JYORWS;
}

public
void setJYORDR(decimal JYORDR){
	this.JYORDR = JYORDR;
}

public
void setJYITEM(decimal JYITEM){
	this.JYITEM = JYITEM;
}

public
void setJYRELN(string JYRELN){
	this.JYRELN = JYRELN;
}

public
void setJYAUTH(string JYAUTH){
	this.JYAUTH = JYAUTH;
}

public
void setJYPORL(decimal JYPORL){
	this.JYPORL = JYPORL;
}

public
void setJYPART(string JYPART){
	this.JYPART = JYPART;
}

public
void setJYSCUS(string JYSCUS){
	this.JYSCUS = JYSCUS;
}

public
void setJYSTKL(string JYSTKL){
	this.JYSTKL = JYSTKL;
}

public
void setJYTERR(string JYTERR){
	this.JYTERR = JYTERR;
}

public
void setJYCUMQ(decimal JYCUMQ){
	this.JYCUMQ = JYCUMQ;
}

public
void setJYCUMY(string JYCUMY){
	this.JYCUMY = JYCUMY;
}

public
void setJYDOCK(string JYDOCK){
	this.JYDOCK = JYDOCK;
}

public
void setJYSEQN(decimal JYSEQN){
	this.JYSEQN = JYSEQN;
}

public
void setJYRANY(string JYRANY){
	this.JYRANY = JYRANY;
}

public
void setJYRAN(string JYRAN){
	this.JYRAN = JYRAN;
}

public
void setJYKANB(string JYKANB){
	this.JYKANB = JYKANB;
}

public
void setJYINTC(string JYINTC){
	this.JYINTC = JYINTC;
}

public
void setJYLATF(string JYLATF){
	this.JYLATF = JYLATF;
}


public
string getJYCODE(){
	return JYCODE;
}

public
DateTime getJYDATE(){
	return JYDATE;
}

public
decimal getJYTIME(){
	return JYTIME;
}

public
decimal getJYENTR(){
	return JYENTR;
}

public
DateTime getJYODAT(){
	return JYODAT;
}

public
decimal getJYOTME(){
	return JYOTME;
}

public
decimal getJYSQTY(){
	return JYSQTY;
}

public
string getJYBSUN(){
	return JYBSUN;
}

public
string getJYORUN(){
	return JYORUN;
}

public
string getJYOWCD(){
	return JYOWCD;
}

public
string getJYAPPR(){
	return JYAPPR;
}

public
string getJYORWS(){
	return JYORWS;
}

public
decimal getJYORDR(){
	return JYORDR;
}

public
decimal getJYITEM(){
	return JYITEM;
}

public
string getJYRELN(){
	return JYRELN;
}

public
string getJYAUTH(){
	return JYAUTH;
}

public
decimal getJYPORL(){
	return JYPORL;
}

public
string getJYPART(){
	return JYPART;
}

public
string getJYSCUS(){
	return JYSCUS;
}

public
string getJYSTKL(){
	return JYSTKL;
}

public
string getJYTERR(){
	return JYTERR;
}

public
decimal getJYCUMQ(){
	return JYCUMQ;
}

public
string getJYCUMY(){
	return JYCUMY;
}

public
string getJYDOCK(){
	return JYDOCK;
}

public
decimal getJYSEQN(){
	return JYSEQN;
}

public
string getJYRANY(){
	return JYRANY;
}

public
string getJYRAN(){
	return JYRAN;
}

public
string getJYKANB(){
	return JYKANB;
}

public
string getJYINTC(){
	return JYINTC;
}

public
string getJYLATF(){
	return JYLATF;
}

} // class

} // namespace