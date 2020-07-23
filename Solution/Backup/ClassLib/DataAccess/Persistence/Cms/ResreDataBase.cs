using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class ResreDataBase : GenericDataBaseElement{

private string ABTYPE;
private string ABDEPT;
private string ABRESC;
private string ABDES;
private decimal ABBRDR;
private decimal ABCAPT;
private decimal ABCREW;
private decimal ABBRDP;
private string ABBLNK;
private DateTime ABSTIM;
private string ABMACG;
private DateTime ABRDAT;
private DateTime ABRTIM;
private string ABSCHD;
private string ABFINS;
private decimal ABLABS;
private decimal ABLABR;
private decimal ABVBRD;
private string ABFRML;
private string ABRCVL;
private decimal ABUTLP;
private decimal ABBDVP;
private string ABWPDR;
private string ABWPRV;

public
ResreDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
    this.ABTYPE = reader.GetString("ABTYPE");
    this.ABDEPT = reader.GetString("ABDEPT");
    this.ABRESC = reader.GetString("ABRESC");
    this.ABDES = reader.GetString("ABDES");
    this.ABBRDR = reader.GetDecimal("ABBRDR");
    this.ABCAPT = reader.GetDecimal("ABCAPT");
    this.ABCREW = reader.GetDecimal("ABCREW");
    this.ABBRDP = reader.GetDecimal("ABBRDP");
    this.ABBLNK = reader.GetString("ABBLNK");
    this.ABSTIM = reader.GetDateTime("ABSTIM");
    this.ABMACG = reader.GetString("ABMACG");
    this.ABRDAT = reader.GetDateTime("ABRDAT");
    this.ABRTIM = reader.GetDateTime("ABRTIM");
    this.ABSCHD = reader.GetString("ABSCHD");
    this.ABFINS = reader.GetString("ABFINS");
    this.ABLABS = reader.GetDecimal("ABLABS");
    this.ABLABR = reader.GetDecimal("ABLABR");
    this.ABVBRD = reader.GetDecimal("ABVBRD");
    this.ABFRML = reader.GetString("ABFRML");
    this.ABRCVL = reader.GetString("ABRCVL");
    this.ABUTLP = reader.GetDecimal("ABUTLP");
    this.ABBDVP = reader.GetDecimal("ABBDVP");
    this.ABWPDR = reader.GetString("ABWPDR");
    this.ABWPRV = reader.GetString("ABWPRV");
}

public override
void write(){
	try{
		string sql = "insert into resre values('" +
			Converter.fixString(ABTYPE) + "', '" +
			Converter.fixString(ABDEPT) + "', '" +
			Converter.fixString(ABRESC) + "', '" +
			Converter.fixString(ABDES) + "', " +
			NumberUtil.toString(ABBRDR) + ", " +
			NumberUtil.toString(ABCAPT) + ", " +
			NumberUtil.toString(ABCREW) + ", " +
			NumberUtil.toString(ABBRDP) + ", '" +
			Converter.fixString(ABBLNK) + "', '" +
			DateUtil.getCompleteDateRepresentation(ABSTIM/*, DateUtil.MMDDYYYY*/) + "', '" +
			Converter.fixString(ABMACG) + "', '" +
			DateUtil.getCompleteDateRepresentation(ABRDAT/*, DateUtil.MMDDYYYY*/) + "', '" +
			DateUtil.getCompleteDateRepresentation(ABRTIM/*, DateUtil.MMDDYYYY*/) + "', '" +
			Converter.fixString(ABSCHD) + "', '" +
			Converter.fixString(ABFINS) + "', " +
			NumberUtil.toString(ABLABS) + ", " +
			NumberUtil.toString(ABLABR) + ", " +
			NumberUtil.toString(ABVBRD) + ", '" +
			Converter.fixString(ABFRML) + "', '" +
			Converter.fixString(ABRCVL) + "', " +
			NumberUtil.toString(ABUTLP) + ", " +
			NumberUtil.toString(ABBDVP) + ", '" +
			Converter.fixString(ABWPDR) + "', '" +
			Converter.fixString(ABWPRV) + "')";
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
void setABTYPE(string ABTYPE){
	this.ABTYPE = ABTYPE;
}

public
void setABDEPT(string ABDEPT){
	this.ABDEPT = ABDEPT;
}

public
void setABRESC(string ABRESC){
	this.ABRESC = ABRESC;
}

public
void setABDES(string ABDES){
	this.ABDES = ABDES;
}

public
void setABBRDR(decimal ABBRDR){
	this.ABBRDR = ABBRDR;
}

public
void setABCAPT(decimal ABCAPT){
	this.ABCAPT = ABCAPT;
}

public
void setABCREW(decimal ABCREW){
	this.ABCREW = ABCREW;
}

public
void setABBRDP(decimal ABBRDP){
	this.ABBRDP = ABBRDP;
}

public
void setABBLNK(string ABBLNK){
	this.ABBLNK = ABBLNK;
}

public
void setABSTIM(DateTime ABSTIM){
	this.ABSTIM = ABSTIM;
}

public
void setABMACG(string ABMACG){
	this.ABMACG = ABMACG;
}

public
void setABRDAT(DateTime ABRDAT){
	this.ABRDAT = ABRDAT;
}

public
void setABRTIM(DateTime ABRTIM){
	this.ABRTIM = ABRTIM;
}

public
void setABSCHD(string ABSCHD){
	this.ABSCHD = ABSCHD;
}

public
void setABFINS(string ABFINS){
	this.ABFINS = ABFINS;
}

public
void setABLABS(decimal ABLABS){
	this.ABLABS = ABLABS;
}

public
void setABLABR(decimal ABLABR){
	this.ABLABR = ABLABR;
}

public
void setABVBRD(decimal ABVBRD){
	this.ABVBRD = ABVBRD;
}

public
void setABFRML(string ABFRML){
	this.ABFRML = ABFRML;
}

public
void setABRCVL(string ABRCVL){
	this.ABRCVL = ABRCVL;
}

public
void setABUTLP(decimal ABUTLP){
	this.ABUTLP = ABUTLP;
}

public
void setABBDVP(decimal ABBDVP){
	this.ABBDVP = ABBDVP;
}

public
void setABWPDR(string ABWPDR){
	this.ABWPDR = ABWPDR;
}

public
void setABWPRV(string ABWPRV){
	this.ABWPRV = ABWPRV;
}


public
string getABTYPE(){
	return ABTYPE;
}

public
string getABDEPT(){
	return ABDEPT;
}

public
string getABRESC(){
	return ABRESC;
}

public
string getABDES(){
	return ABDES;
}

public
decimal getABBRDR(){
	return ABBRDR;
}

public
decimal getABCAPT(){
	return ABCAPT;
}

public
decimal getABCREW(){
	return ABCREW;
}

public
decimal getABBRDP(){
	return ABBRDP;
}

public
string getABBLNK(){
	return ABBLNK;
}

public
DateTime getABSTIM(){
	return ABSTIM;
}

public
string getABMACG(){
	return ABMACG;
}

public
DateTime getABRDAT(){
	return ABRDAT;
}

public
DateTime getABRTIM(){
	return ABRTIM;
}

public
string getABSCHD(){
	return ABSCHD;
}

public
string getABFINS(){
	return ABFINS;
}

public
decimal getABLABS(){
	return ABLABS;
}

public
decimal getABLABR(){
	return ABLABR;
}

public
decimal getABVBRD(){
	return ABVBRD;
}

public
string getABFRML(){
	return ABFRML;
}

public
string getABRCVL(){
	return ABRCVL;
}

public
decimal getABUTLP(){
	return ABUTLP;
}

public
decimal getABBDVP(){
	return ABBDVP;
}

public
string getABWPDR(){
	return ABWPDR;
}

public
string getABWPRV(){
	return ABWPRV;
}

} // class

} // namespace