/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: gpiano $ 
*   $Date: 2006-05-30 13:09:39 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/Cms/RprsDataBase.cs,v $ 
*   $State: Exp $ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public
class RprsDataBase : GenericDataBaseElement{

private decimal NZBTID;
private decimal NZENT;
private string NZDEPT;
private string NZRESC;
private DateTime NZRDAT;
private decimal NZSHFT;
private string NZSHGP;
private string NZPART;
private string NZJOB;
private decimal NZSEQ;
private decimal NZQTYG;
private decimal NZQTYS;
private string NZUNIT;
private decimal NZTIME;
private DateTime NZSDAT;
private DateTime NZSTIM;
private DateTime NZEDAT;
private DateTime NZETIM;
private string NZSRCE;
private string NZSTAT;
private string NZPOST;

public
RprsDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	throw new PersistenceException("Not implemented !");
}

public
bool exists(){
	string sql = "select * from rprs where " + getWhereCondition();
	return exists(sql);
}

internal
void load(NotNullDataReader reader){
	this.NZBTID = reader.GetDecimal("NZBTID");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.NZENT = reader.GetDecimal("NZENT#");
	else
		this.NZENT = reader.GetDecimal("NZENT");
	this.NZDEPT = reader.GetString("NZDEPT");
	this.NZRESC = reader.GetString("NZRESC");
	this.NZRDAT = reader.GetDateTime("NZRDAT");
	this.NZSHFT = reader.GetDecimal("NZSHFT");
	this.NZSHGP = reader.GetString("NZSHGP");
	this.NZPART = reader.GetString("NZPART");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
		this.NZJOB = reader.GetString("NZJOB#");
		this.NZSEQ = reader.GetDecimal("NZSEQ#");
	}else{
		this.NZJOB = reader.GetString("NZJOB");
		this.NZSEQ = reader.GetDecimal("NZSEQ");
	}
	this.NZQTYG = reader.GetDecimal("NZQTYG");
	this.NZQTYS = reader.GetDecimal("NZQTYS");
	this.NZUNIT = reader.GetString("NZUNIT");
	this.NZTIME = reader.GetDecimal("NZTIME");
	this.NZSDAT = reader.GetDateTime("NZSDAT");
	this.NZSTIM = reader.GetDateTime("NZSTIM");
	this.NZEDAT = reader.GetDateTime("NZEDAT");
	this.NZETIM = reader.GetDateTime("NZETIM");
	this.NZSRCE = reader.GetString("NZSRCE");
	this.NZSTAT = reader.GetString("NZSTAT");
	this.NZPOST = reader.GetString("NZPOST");
}

public override
void write(){
	string sql = "insert into rprs(" + 
		"NZBTID," +
		"NZENT," +
		"NZDEPT," +
		"NZRESC," +
		"NZRDAT," +
		"NZSHFT," +
		"NZSHGP," +
		"NZPART," +
		"NZJOB," +
		"NZSEQ," +
		"NZQTYG," +
		"NZQTYS," +
		"NZUNIT," +
		"NZTIME," +
		"NZSDAT," +
		"NZSTIM," +
		"NZEDAT," +
		"NZETIM," +
		"NZSRCE," +
		"NZSTAT," +
		"NZPOST" +

		") values (" + 

		"" + NumberUtil.toString(NZBTID) + "," +
		"" + NumberUtil.toString(NZENT) + "," +
		"'" + Converter.fixString(NZDEPT) + "'," +
		"'" + Converter.fixString(NZRESC) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(NZRDAT) + "'," +
		"" + NumberUtil.toString(NZSHFT) + "," +
		"'" + Converter.fixString(NZSHGP) + "'," +
		"'" + Converter.fixString(NZPART) + "'," +
		"'" + Converter.fixString(NZJOB) + "'," +
		"" + NumberUtil.toString(NZSEQ) + "," +
		"" + NumberUtil.toString(NZQTYG) + "," +
		"" + NumberUtil.toString(NZQTYS) + "," +
		"'" + Converter.fixString(NZUNIT) + "'," +
		"" + NumberUtil.toString(NZTIME) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(NZSDAT) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(NZSTIM) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(NZEDAT) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(NZETIM) + "'," +
		"'" + Converter.fixString(NZSRCE) + "'," +
		"'" + Converter.fixString(NZSTAT) + "'," +
		"'" + Converter.fixString(NZPOST) + "')";
	write(sql);
}

public override
void update(){
	string sql = "update rprs set " +
		"NZBTID = " + NumberUtil.toString(NZBTID) + ", " +
		"NZENT = " + NumberUtil.toString(NZENT) + ", " +
		"NZDEPT = '" + Converter.fixString(NZDEPT) + "', " +
		"NZRESC = '" + Converter.fixString(NZRESC) + "', " +
		"NZRDAT = '" + DateUtil.getCompleteDateRepresentation(NZRDAT) + "', " +
		"NZSHFT = " + NumberUtil.toString(NZSHFT) + ", " +
		"NZSHGP = '" + Converter.fixString(NZSHGP) + "', " +
		"NZPART = '" + Converter.fixString(NZPART) + "', " +
		"NZJOB = '" + Converter.fixString(NZJOB) + "', " +
		"NZSEQ = " + NumberUtil.toString(NZSEQ) + ", " +
		"NZQTYG = " + NumberUtil.toString(NZQTYG) + ", " +
		"NZQTYS = " + NumberUtil.toString(NZQTYS) + ", " +
		"NZUNIT = '" + Converter.fixString(NZUNIT) + "', " +
		"NZTIME = " + NumberUtil.toString(NZTIME) + ", " +
		"NZSDAT = '" + DateUtil.getCompleteDateRepresentation(NZSDAT) + "', " +
		"NZSTIM = '" + DateUtil.getCompleteDateRepresentation(NZSTIM) + "', " +
		"NZEDAT = '" + DateUtil.getCompleteDateRepresentation(NZEDAT) + "', " +
		"NZETIM = '" + DateUtil.getCompleteDateRepresentation(NZETIM) + "', " +
		"NZSRCE = '" + Converter.fixString(NZSRCE) + "', " +
		"NZSTAT = '" + Converter.fixString(NZSTAT) + "', " +
		"NZPOST = '" + Converter.fixString(NZPOST) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from rprs where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"NZBTID = " + NumberUtil.toString(NZBTID) + " and " +
		"NZENT = " + NumberUtil.toString(NZENT) + "";
	return sqlWhere;
}

public
void setNZBTID(decimal NZBTID){
	this.NZBTID = NZBTID;
}

public
void setNZENT(decimal NZENT){
	this.NZENT = NZENT;
}

public
void setNZDEPT(string NZDEPT){
	this.NZDEPT = NZDEPT;
}

public
void setNZRESC(string NZRESC){
	this.NZRESC = NZRESC;
}

public
void setNZRDAT(DateTime NZRDAT){
	this.NZRDAT = NZRDAT;
}

public
void setNZSHFT(decimal NZSHFT){
	this.NZSHFT = NZSHFT;
}

public
void setNZSHGP(string NZSHGP){
	this.NZSHGP = NZSHGP;
}

public
void setNZPART(string NZPART){
	this.NZPART = NZPART;
}

public
void setNZJOB(string NZJOB){
	this.NZJOB = NZJOB;
}

public
void setNZSEQ(decimal NZSEQ){
	this.NZSEQ = NZSEQ;
}

public
void setNZQTYG(decimal NZQTYG){
	this.NZQTYG = NZQTYG;
}

public
void setNZQTYS(decimal NZQTYS){
	this.NZQTYS = NZQTYS;
}

public
void setNZUNIT(string NZUNIT){
	this.NZUNIT = NZUNIT;
}

public
void setNZTIME(decimal NZTIME){
	this.NZTIME = NZTIME;
}

public
void setNZSDAT(DateTime NZSDAT){
	this.NZSDAT = NZSDAT;
}

public
void setNZSTIM(DateTime NZSTIM){
	this.NZSTIM = NZSTIM;
}

public
void setNZEDAT(DateTime NZEDAT){
	this.NZEDAT = NZEDAT;
}

public
void setNZETIM(DateTime NZETIM){
	this.NZETIM = NZETIM;
}

public
void setNZSRCE(string NZSRCE){
	this.NZSRCE = NZSRCE;
}

public
void setNZSTAT(string NZSTAT){
	this.NZSTAT = NZSTAT;
}

public
void setNZPOST(string NZPOST){
	this.NZPOST = NZPOST;
}

public
decimal getNZBTID(){
	return NZBTID;
}

public
decimal getNZENT(){
	return NZENT;
}

public
string getNZDEPT(){
	return NZDEPT;
}

public
string getNZRESC(){
	return NZRESC;
}

public
DateTime getNZRDAT(){
	return NZRDAT;
}

public
decimal getNZSHFT(){
	return NZSHFT;
}

public
string getNZSHGP(){
	return NZSHGP;
}

public
string getNZPART(){
	return NZPART;
}

public
string getNZJOB(){
	return NZJOB;
}

public
decimal getNZSEQ(){
	return NZSEQ;
}

public
decimal getNZQTYG(){
	return NZQTYG;
}

public
decimal getNZQTYS(){
	return NZQTYS;
}

public
string getNZUNIT(){
	return NZUNIT;
}

public
decimal getNZTIME(){
	return NZTIME;
}

public
DateTime getNZSDAT(){
	return NZSDAT;
}

public
DateTime getNZSTIM(){
	return NZSTIM;
}

public
DateTime getNZEDAT(){
	return NZEDAT;
}

public
DateTime getNZETIM(){
	return NZETIM;
}

public
string getNZSRCE(){
	return NZSRCE;
}

public
string getNZSTAT(){
	return NZSTAT;
}

public
string getNZPOST(){
	return NZPOST;
}

} // class

} // package