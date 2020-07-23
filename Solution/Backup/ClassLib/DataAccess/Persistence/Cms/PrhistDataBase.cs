using System;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class PrhistDataBase : GenericDataBaseElement{

private string DB;
private string DWDEPT;
private string DWRESR;
private DateTime DWDATE;
private decimal DWSHFT;
private string DWMODE;
private string DWWREF;
private decimal DWSEQN;
private decimal DWTIME;
private string DWPART;
private decimal DWQTYC;
private decimal DWQTYS;
private decimal DWRATE;
private string DWSGRP;
private string DWMAJG;
private decimal DWFSYY;
private decimal DWFSPP;
private decimal DWCPRC;

//used for the report
private string	AAPLNT;


public 
PrhistDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){	
}

public
void load(NotNullDataReader reader){
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMSTEMP_DATABASE){
		this.DB = reader.GetString("DB");
	}
    this.DWDEPT = reader.GetString("DWDEPT");
    this.DWRESR = reader.GetString("DWRESR");
    this.DWDATE = reader.GetDateTime("DWDATE");
    this.DWSHFT = reader.GetDecimal("DWSHFT");
    this.DWMODE = reader.GetString("DWMODE");
    this.DWWREF = reader.GetString("DWWREF");
    this.DWSEQN = reader.GetDecimal("DWSEQN");
    this.DWTIME = reader.GetDecimal("DWTIME");
    this.DWPART = reader.GetString("DWPART");
    this.DWQTYC = reader.GetDecimal("DWQTYC");
    this.DWQTYS = reader.GetDecimal("DWQTYS");
    this.DWRATE = reader.GetDecimal("DWRATE");
    this.DWSGRP = reader.GetString("DWSGRP");
    this.DWMAJG = reader.GetString("DWMAJG");
    this.DWFSYY = reader.GetDecimal("DWFSYY");
    this.DWFSPP = reader.GetDecimal("DWFSPP");
    this.DWCPRC = reader.GetDecimal("DWCPRC");
}

public
void loadForReport(NotNullDataReader reader){
	load(reader);
	this.AAPLNT = reader.GetString("AAPLNT");	
}

public override
void write(){
	try{
		string sql = "insert into prhist values('" +
		    Converter.fixString(DB) +"', '" + 
            Converter.fixString(DWDEPT) +"', '" +
            Converter.fixString(DWRESR) +"', '" +
            DateUtil.getCompleteDateRepresentation(DWDATE) +"', " +
            NumberUtil.toString(DWSHFT) +", '" +
            Converter.fixString(DWMODE) +"', '" +
            Converter.fixString(DWWREF) +"', " +
            NumberUtil.toString(DWSEQN) +", " +
            NumberUtil.toString(DWTIME) +", '" +
            Converter.fixString(DWPART) +"', " +
            NumberUtil.toString(DWQTYC) +", " +
            NumberUtil.toString(DWQTYS) +", " +
            NumberUtil.toString(DWRATE) +", '" +
            Converter.fixString(DWSGRP) +"', '" +
            Converter.fixString(DWMAJG) +"', " +
            NumberUtil.toString(DWFSYY) +", " +
            NumberUtil.toString(DWFSPP) +", " +
            NumberUtil.toString(DWCPRC) +")";
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

//Setters
public 
void setDB (string DB){
    this.DB = DB;
}

public 
void setDWDEPT (string DWDEPT){
    this.DWDEPT = DWDEPT;
}

public 
void setDWRESR (string DWRESR){
    this.DWRESR = DWRESR;
}

public 
void setDWDATE (DateTime DWDATE){
    this.DWDATE = DWDATE;
}

public 
void setDWSHFT (decimal DWSHFT){
    this.DWSHFT = DWSHFT;
}

public 
void setDWMODE (string DWMODE){
    this.DWMODE = DWMODE;
}

public 
void setDWWREF (string DWWREF){
    this.DWWREF = DWWREF;
}

public 
void setDWSEQN (decimal DWSEQN){
    this.DWSEQN = DWSEQN;
}

public 
void setDWTIME (decimal DWTIME){
    this.DWTIME = DWTIME;
}

public 
void setDWPART (string DWPART){
    this.DWPART = DWPART;
}

public 
void setDWQTYC (decimal DWQTYC){
    this.DWQTYC = DWQTYC;
}

public 
void setDWQTYS (decimal DWQTYS){
    this.DWQTYS = DWQTYS;
}

public 
void setDWRATE (decimal DWRATE){
    this.DWRATE = DWRATE;
}

public 
void setDWSGRP (string DWSGRP){
    this.DWSGRP = DWSGRP;
}

public 
void setDWMAJG (string DWMAJG){
    this.DWMAJG = DWMAJG;
}

public 
void setDWFSYY (decimal DWFSYY){
    this.DWFSYY = DWFSYY;
}

public 
void setDWFSPP (decimal DWFSPP){
    this.DWFSPP = DWFSPP;
}

public 
void setDWCPRC (decimal DWCPRC){
    this.DWCPRC = DWCPRC;
}

public 
void setAAPLNT(string AAPLNT){
	this.AAPLNT = AAPLNT;
}

//Getters
public 
string getDB(){
    return DB;
}

public 
string getDWDEPT(){
    return DWDEPT;
}

public 
string getDWRESR(){
    return DWRESR;
}

public 
DateTime getDWDATE(){
    return DWDATE;
}

public 
decimal getDWSHFT(){
    return DWSHFT;
}

public 
string getDWMODE(){
    return DWMODE;
}

public 
string getDWWREF(){
    return DWWREF;
}

public 
decimal getDWSEQN(){
    return DWSEQN;
}

public 
decimal getDWTIME(){
    return DWTIME;
}

public 
string getDWPART(){
    return DWPART;
}

public 
decimal getDWQTYC(){
    return DWQTYC;
}

public 
decimal getDWQTYS(){
    return DWQTYS;
}

public 
decimal getDWRATE(){
    return DWRATE;
}

public 
string getDWSGRP(){
    return DWSGRP;
}

public 
string getDWMAJG(){
    return DWMAJG;
}

public 
decimal getDWFSYY(){
    return DWFSYY;
}

public 
decimal getDWFSPP(){
    return DWFSPP;
}

public 
decimal getDWCPRC(){
    return DWCPRC;
}

public 
string getAAPLNT(){
	return AAPLNT;
}

}//end class

}//end namespace
