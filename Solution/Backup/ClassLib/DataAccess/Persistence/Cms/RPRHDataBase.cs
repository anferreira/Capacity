/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: bgularte $ 
*   $Date: 2006-12-21 19:56:24 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/Cms/RPRHDataBase.cs,v $ 
*   $State: Exp $ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public
class RPRHDataBase : GenericDataBaseElement{

private decimal NWBTID;
private string NWLABL;
private string NWBPRT;
private string NWPOST;
private decimal NWFSYY;
private decimal NWFSPP;
private DateTime NWRDAT;
private decimal NWSHFT;
private string NWSHGP;
private decimal NWNXT;
private string NWCRBY;
private DateTime NWCDAT;
private DateTime NWCTIM;
private string NWUPBY;
private DateTime NWUDAT;
private DateTime NWUTIM;
private string NWIUSE;
private string NWSRCE;
private string NWSTKL;
private string NWSCPR;

public
RPRHDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	throw new PersistenceException("Not implemented !");
}

public
bool exists(){
	string sql = "select * from rprh where " + getWhereCondition();
	return exists(sql);
}

public
void load(NotNullDataReader reader){
	this.NWBTID = reader.GetDecimal("NWBTID");
	this.NWLABL = reader.GetString("NWLABL");
	this.NWBPRT = reader.GetString("NWBPRT");
	this.NWPOST = reader.GetString("NWPOST");
	this.NWFSYY = reader.GetDecimal("NWFSYY");
	this.NWFSPP = reader.GetDecimal("NWFSPP");
	this.NWRDAT = reader.GetDateTime("NWRDAT");
	this.NWSHFT = reader.GetDecimal("NWSHFT");
	this.NWSHGP = reader.GetString("NWSHGP");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.NWNXT = reader.GetDecimal("NWNXT#");
	else
		this.NWNXT = reader.GetDecimal("NWNXT");
	this.NWCRBY = reader.GetString("NWCRBY");
	this.NWCDAT = reader.GetDateTime("NWCDAT");
	this.NWCTIM = reader.GetDateTime("NWCTIM");
	this.NWUPBY = reader.GetString("NWUPBY");
	this.NWUDAT = reader.GetDateTime("NWUDAT");
	this.NWUTIM = reader.GetDateTime("NWUTIM");
	this.NWIUSE = reader.GetString("NWIUSE");
	this.NWSRCE = reader.GetString("NWSRCE");
	this.NWSTKL = reader.GetString("NWSTKL");
	this.NWSCPR = reader.GetString("NWSCPR");
}

public override
void write(){
	string sql = "insert into rprh(" + 
		"NWBTID," +
		"NWLABL," +
		"NWBPRT," +
		"NWPOST," +
		"NWFSYY," +
		"NWFSPP," +
		"NWRDAT," +
		"NWSHFT," +
		"NWSHGP," +
		"NWNXT," +
		"NWCRBY," +
		"NWCDAT," +
		"NWCTIM," +
		"NWUPBY," +
		"NWUDAT," +
		"NWUTIM," +
		"NWIUSE," +
		"NWSRCE," +
		"NWSTKL," +
		"NWSCPR" +

		") values (" + 

		"" + NumberUtil.toString(NWBTID) + "," +
		"'" + Converter.fixString(NWLABL) + "'," +
		"'" + Converter.fixString(NWBPRT) + "'," +
		"'" + Converter.fixString(NWPOST) + "'," +
		"" + NumberUtil.toString(NWFSYY) + "," +
		"" + NumberUtil.toString(NWFSPP) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(NWRDAT) + "'," +
		"" + NumberUtil.toString(NWSHFT) + "," +
		"'" + Converter.fixString(NWSHGP) + "'," +
		"" + NumberUtil.toString(NWNXT) + "," +
		"'" + Converter.fixString(NWCRBY) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(NWCDAT) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(NWCTIM) + "'," +
		"'" + Converter.fixString(NWUPBY) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(NWUDAT) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(NWUTIM) + "'," +
		"'" + Converter.fixString(NWIUSE) + "'," +
		"'" + Converter.fixString(NWSRCE) + "'," +
		"'" + Converter.fixString(NWSTKL) + "'," +
		"'" + Converter.fixString(NWSCPR) + "')";
	write(sql);
}

public override
void update(){
	string sql = "update rprh set " +
		"NWBTID = " + NumberUtil.toString(NWBTID) + ", " +
		"NWLABL = '" + Converter.fixString(NWLABL) + "', " +
		"NWBPRT = '" + Converter.fixString(NWBPRT) + "', " +
		"NWPOST = '" + Converter.fixString(NWPOST) + "', " +
		"NWFSYY = " + NumberUtil.toString(NWFSYY) + ", " +
		"NWFSPP = " + NumberUtil.toString(NWFSPP) + ", " +
		"NWRDAT = '" + DateUtil.getCompleteDateRepresentation(NWRDAT) + "', " +
		"NWSHFT = " + NumberUtil.toString(NWSHFT) + ", " +
		"NWSHGP = '" + Converter.fixString(NWSHGP) + "', " +
		"NWNXT = " + NumberUtil.toString(NWNXT) + ", " +
		"NWCRBY = '" + Converter.fixString(NWCRBY) + "', " +
		"NWCDAT = '" + DateUtil.getCompleteDateRepresentation(NWCDAT) + "', " +
		"NWCTIM = '" + DateUtil.getCompleteDateRepresentation(NWCTIM) + "', " +
		"NWUPBY = '" + Converter.fixString(NWUPBY) + "', " +
		"NWUDAT = '" + DateUtil.getCompleteDateRepresentation(NWUDAT) + "', " +
		"NWUTIM = '" + DateUtil.getCompleteDateRepresentation(NWUTIM) + "', " +
		"NWIUSE = '" + Converter.fixString(NWIUSE) + "', " +
		"NWSRCE = '" + Converter.fixString(NWSRCE) + "', " +
		"NWSTKL = '" + Converter.fixString(NWSTKL) + "', " +
		"NWSCPR = '" + Converter.fixString(NWSCPR) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from rprh where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"NWBTID = " + NumberUtil.toString(NWBTID) + "";
	return sqlWhere;
}

public
void setNWBTID(decimal NWBTID){
	this.NWBTID = NWBTID;
}

public
void setNWLABL(string NWLABL){
	this.NWLABL = NWLABL;
}

public
void setNWBPRT(string NWBPRT){
	this.NWBPRT = NWBPRT;
}

public
void setNWPOST(string NWPOST){
	this.NWPOST = NWPOST;
}

public
void setNWFSYY(decimal NWFSYY){
	this.NWFSYY = NWFSYY;
}

public
void setNWFSPP(decimal NWFSPP){
	this.NWFSPP = NWFSPP;
}

public
void setNWRDAT(DateTime NWRDAT){
	this.NWRDAT = NWRDAT;
}

public
void setNWSHFT(decimal NWSHFT){
	this.NWSHFT = NWSHFT;
}

public
void setNWSHGP(string NWSHGP){
	this.NWSHGP = NWSHGP;
}

public
void setNWNXT(decimal NWNXT){
	this.NWNXT = NWNXT;
}

public
void setNWCRBY(string NWCRBY){
	this.NWCRBY = NWCRBY;
}

public
void setNWCDAT(DateTime NWCDAT){
	this.NWCDAT = NWCDAT;
}

public
void setNWCTIM(DateTime NWCTIM){
	this.NWCTIM = NWCTIM;
}

public
void setNWUPBY(string NWUPBY){
	this.NWUPBY = NWUPBY;
}

public
void setNWUDAT(DateTime NWUDAT){
	this.NWUDAT = NWUDAT;
}

public
void setNWUTIM(DateTime NWUTIM){
	this.NWUTIM = NWUTIM;
}

public
void setNWIUSE(string NWIUSE){
	this.NWIUSE = NWIUSE;
}

public
void setNWSRCE(string NWSRCE){
	this.NWSRCE = NWSRCE;
}

public
void setNWSTKL(string NWSTKL){
	this.NWSTKL = NWSTKL;
}

public
void setNWSCPR(string NWSCPR){
	this.NWSCPR = NWSCPR;
}

public
decimal getNWBTID(){
	return NWBTID;
}

public
string getNWLABL(){
	return NWLABL;
}

public
string getNWBPRT(){
	return NWBPRT;
}

public
string getNWPOST(){
	return NWPOST;
}

public
decimal getNWFSYY(){
	return NWFSYY;
}

public
decimal getNWFSPP(){
	return NWFSPP;
}

public
DateTime getNWRDAT(){
	return NWRDAT;
}

public
decimal getNWSHFT(){
	return NWSHFT;
}

public
string getNWSHGP(){
	return NWSHGP;
}

public
decimal getNWNXT(){
	return NWNXT;
}

public
string getNWCRBY(){
	return NWCRBY;
}

public
DateTime getNWCDAT(){
	return NWCDAT;
}

public
DateTime getNWCTIM(){
	return NWCTIM;
}

public
string getNWUPBY(){
	return NWUPBY;
}

public
DateTime getNWUDAT(){
	return NWUDAT;
}

public
DateTime getNWUTIM(){
	return NWUTIM;
}

public
string getNWIUSE(){
	return NWIUSE;
}

public
string getNWSRCE(){
	return NWSRCE;
}

public
string getNWSTKL(){
	return NWSTKL;
}

public
string getNWSCPR(){
	return NWSCPR;
}

} // class

} // package