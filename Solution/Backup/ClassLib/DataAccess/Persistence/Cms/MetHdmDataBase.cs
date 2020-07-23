using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class MetHdmDataBase : GenericDataBaseElement{

private string AQTYPE;
private string AQPART;
private decimal AQSEQ;
private decimal AQLIN;
private string AQMTLP;
private string AQMTLD;
private decimal AQQPPC;
private string AQUNIT;
private decimal AQSQTY;
private decimal AQQTYM;
private string AQBLWT;
private string AQBK01;
private string AQSTYP;
private decimal AQLEAD;
private string AQMAJG;
private decimal AQITM;
private string AQITMX;
private string AQBK02;
private string AQALLC;
private string AQBACK;
private decimal AQSCRP;
private string AQRQBY;
private string AQSTKL;
private string AQBK03;
private string AQDRAW;
private string AQDFLC;

public
MetHdmDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
    this.AQTYPE = reader.GetString("AQTYPE");
    this.AQPART = reader.GetString("AQPART");
//    this.AQSEQ = reader.GetDecimal("AQSEQ#");
//    this.AQLIN = reader.GetDecimal("AQLIN#");
    this.AQSEQ = reader.GetDecimal(2);
    this.AQLIN = reader.GetDecimal(3);
    this.AQMTLP = reader.GetString("AQMTLP");
    this.AQMTLD = reader.GetString("AQMTLD");
    this.AQQPPC = reader.GetDecimal("AQQPPC");
    this.AQUNIT = reader.GetString("AQUNIT");
    this.AQSQTY = reader.GetDecimal("AQSQTY");
    this.AQQTYM = reader.GetDecimal("AQQTYM");
    this.AQBLWT = reader.GetString("AQBLWT");
    this.AQBK01 = reader.GetString("AQBK01");
    this.AQSTYP = reader.GetString("AQSTYP");
    this.AQLEAD = reader.GetDecimal("AQLEAD");
    this.AQMAJG = reader.GetString("AQMAJG");
    this.AQITM = reader.GetDecimal("AQITM");
    this.AQITMX = reader.GetString("AQITMX");
    this.AQBK02 = reader.GetString("AQBK02");
    this.AQALLC = reader.GetString("AQALLC");
    this.AQBACK = reader.GetString("AQBACK");
    this.AQSCRP = reader.GetDecimal("AQSCRP");
    this.AQRQBY = reader.GetString("AQRQBY");
    this.AQSTKL = reader.GetString("AQSTKL");
    this.AQBK03 = reader.GetString("AQBK03");
    this.AQDRAW = reader.GetString("AQDRAW");
    this.AQDFLC = reader.GetString("AQDFLC");
}

public override
void write(){
	try{
		string sql = "insert into methdm values('" +
			Converter.fixString(AQTYPE) + "', '" +
			Converter.fixString(AQPART) + "', " +
			NumberUtil.toString(AQSEQ) + ", " +
			NumberUtil.toString(AQLIN) + ", '" +
			Converter.fixString(AQMTLP) + "', '" +
			Converter.fixString(AQMTLD) + "', " +
			NumberUtil.toString(AQQPPC) + ", '" +
			Converter.fixString(AQUNIT) + "', " +
			NumberUtil.toString(AQSQTY) + ", " +
			NumberUtil.toString(AQQTYM) + ", '" +
			Converter.fixString(AQBLWT) + "', '" +
			Converter.fixString(AQBK01) + "', '" +
			Converter.fixString(AQSTYP) + "', " +
			NumberUtil.toString(AQLEAD) + ", '" +
			Converter.fixString(AQMAJG) + "', " +
			NumberUtil.toString(AQITM) + ", '" +
			Converter.fixString(AQITMX) + "', '" +
			Converter.fixString(AQBK02) + "', '" +
			Converter.fixString(AQALLC) + "', '" +
			Converter.fixString(AQBACK) + "', " +
			NumberUtil.toString(AQSCRP) + ", '" +
			Converter.fixString(AQRQBY) + "', '" +
			Converter.fixString(AQSTKL) + "', '" +
			Converter.fixString(AQBK03) + "', '" +
			Converter.fixString(AQDRAW) + "', '" +
			Converter.fixString(AQDFLC) + "')";
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
void setAQTYPE(string AQTYPE){
	this.AQTYPE = AQTYPE;
}

public
void setAQPART(string AQPART){
	this.AQPART = AQPART;
}

public
void setAQSEQ(decimal AQSEQ){
	this.AQSEQ = AQSEQ;
}

public
void setAQLIN(decimal AQLIN){
	this.AQLIN = AQLIN;
}

public
void setAQMTLP(string AQMTLP){
	this.AQMTLP = AQMTLP;
}

public
void setAQMTLD(string AQMTLD){
	this.AQMTLD = AQMTLD;
}

public
void setAQQPPC(decimal AQQPPC){
	this.AQQPPC = AQQPPC;
}

public
void setAQUNIT(string AQUNIT){
	this.AQUNIT = AQUNIT;
}

public
void setAQSQTY(decimal AQSQTY){
	this.AQSQTY = AQSQTY;
}

public
void setAQQTYM(decimal AQQTYM){
	this.AQQTYM = AQQTYM;
}

public
void setAQBLWT(string AQBLWT){
	this.AQBLWT = AQBLWT;
}

public
void setAQBK01(string AQBK01){
	this.AQBK01 = AQBK01;
}

public
void setAQSTYP(string AQSTYP){
	this.AQSTYP = AQSTYP;
}

public
void setAQLEAD(decimal AQLEAD){
	this.AQLEAD = AQLEAD;
}

public
void setAQMAJG(string AQMAJG){
	this.AQMAJG = AQMAJG;
}

public
void setAQITM(decimal AQITM){
	this.AQITM = AQITM;
}

public
void setAQITMX(string AQITMX){
	this.AQITMX = AQITMX;
}

public
void setAQBK02(string AQBK02){
	this.AQBK02 = AQBK02;
}

public
void setAQALLC(string AQALLC){
	this.AQALLC = AQALLC;
}

public
void setAQBACK(string AQBACK){
	this.AQBACK = AQBACK;
}

public
void setAQSCRP(decimal AQSCRP){
	this.AQSCRP = AQSCRP;
}

public
void setAQRQBY(string AQRQBY){
	this.AQRQBY = AQRQBY;
}

public
void setAQSTKL(string AQSTKL){
	this.AQSTKL = AQSTKL;
}

public
void setAQBK03(string AQBK03){
	this.AQBK03 = AQBK03;
}

public
void setAQDRAW(string AQDRAW){
	this.AQDRAW = AQDRAW;
}

public
void setAQDFLC(string AQDFLC){
	this.AQDFLC = AQDFLC;
}


public
string getAQTYPE(){
	return AQTYPE;
}

public
string getAQPART(){
	return AQPART;
}

public
decimal getAQSEQ(){
	return AQSEQ;
}

public
decimal getAQLIN(){
	return AQLIN;
}

public
string getAQMTLP(){
	return AQMTLP;
}

public
string getAQMTLD(){
	return AQMTLD;
}

public
decimal getAQQPPC(){
	return AQQPPC;
}

public
string getAQUNIT(){
	return AQUNIT;
}

public
decimal getAQSQTY(){
	return AQSQTY;
}

public
decimal getAQQTYM(){
	return AQQTYM;
}

public
string getAQBLWT(){
	return AQBLWT;
}

public
string getAQBK01(){
	return AQBK01;
}

public
string getAQSTYP(){
	return AQSTYP;
}

public
decimal getAQLEAD(){
	return AQLEAD;
}

public
string getAQMAJG(){
	return AQMAJG;
}

public
decimal getAQITM(){
	return AQITM;
}

public
string getAQITMX(){
	return AQITMX;
}

public
string getAQBK02(){
	return AQBK02;
}

public
string getAQALLC(){
	return AQALLC;
}

public
string getAQBACK(){
	return AQBACK;
}

public
decimal getAQSCRP(){
	return AQSCRP;
}

public
string getAQRQBY(){
	return AQRQBY;
}

public
string getAQSTKL(){
	return AQSTKL;
}

public
string getAQBK03(){
	return AQBK03;
}

public
string getAQDRAW(){
	return AQDRAW;
}

public
string getAQDFLC(){
	return AQDFLC;
}


}

}