/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: gpiano $ 
*   $Date: 2006-05-30 13:09:39 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/Cms/RprrDataBase.cs,v $ 
*   $State: Exp $ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public
class RprrDataBase : GenericDataBaseElement{

private decimal OABTID;
private decimal OAENT;
private string OADEPT;
private string OARESC;
private DateTime OARDAT;
private decimal OASHFT;
private string OASHGP;
private string OAPART;
private string OAJOB;
private decimal OASEQ;
private decimal OAQTYG;
private decimal OAQTYS;
private string OAUNIT;
private decimal OATIME;
private DateTime OASDAT;
private DateTime OASTIM;
private DateTime OAEDAT;
private DateTime OAETIM;
private string OASRCE;
private string OASTAT;
private string OAPOST;

public
RprrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	throw new PersistenceException("Not implemented !");
}

public
bool exists(){
	string sql = "select * from rprr where " + getWhereCondition();
	return exists(sql);
}

internal
void load(NotNullDataReader reader){
	this.OABTID = reader.GetDecimal("OABTID");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.OAENT = reader.GetDecimal("OAENT#");
	else
		this.OAENT = reader.GetDecimal("OAENT");
	this.OADEPT = reader.GetString("OADEPT");
	this.OARESC = reader.GetString("OARESC");
	this.OARDAT = reader.GetDateTime("OARDAT");
	this.OASHFT = reader.GetDecimal("OASHFT");
	this.OASHGP = reader.GetString("OASHGP");
	this.OAPART = reader.GetString("OAPART");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
		this.OAJOB = reader.GetString("OAJOB#");
		this.OASEQ = reader.GetDecimal("OASEQ#");
	}else{
		this.OAJOB = reader.GetString("OAJOB");
		this.OASEQ = reader.GetDecimal("OASEQ");
	}
	this.OAQTYG = reader.GetDecimal("OAQTYG");
	this.OAQTYS = reader.GetDecimal("OAQTYS");
	this.OAUNIT = reader.GetString("OAUNIT");
	this.OATIME = reader.GetDecimal("OATIME");
	this.OASDAT = reader.GetDateTime("OASDAT");
	this.OASTIM = reader.GetDateTime("OASTIM");
	this.OAEDAT = reader.GetDateTime("OAEDAT");
	this.OAETIM = reader.GetDateTime("OAETIM");
	this.OASRCE = reader.GetString("OASRCE");
	this.OASTAT = reader.GetString("OASTAT");
	this.OAPOST = reader.GetString("OAPOST");
}

public override
void write(){
	string sql = "insert into rprr(" + 
		"OABTID," +
		"OAENT," +
		"OADEPT," +
		"OARESC," +
		"OARDAT," +
		"OASHFT," +
		"OASHGP," +
		"OAPART," +
		"OAJOB," +
		"OASEQ," +
		"OAQTYG," +
		"OAQTYS," +
		"OAUNIT," +
		"OATIME," +
		"OASDAT," +
		"OASTIM," +
		"OAEDAT," +
		"OAETIM," +
		"OASRCE," +
		"OASTAT," +
		"OAPOST" +

		") values (" + 

		"" + NumberUtil.toString(OABTID) + "," +
		"" + NumberUtil.toString(OAENT) + "," +
		"'" + Converter.fixString(OADEPT) + "'," +
		"'" + Converter.fixString(OARESC) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(OARDAT) + "'," +
		"" + NumberUtil.toString(OASHFT) + "," +
		"'" + Converter.fixString(OASHGP) + "'," +
		"'" + Converter.fixString(OAPART) + "'," +
		"'" + Converter.fixString(OAJOB) + "'," +
		"" + NumberUtil.toString(OASEQ) + "," +
		"" + NumberUtil.toString(OAQTYG) + "," +
		"" + NumberUtil.toString(OAQTYS) + "," +
		"'" + Converter.fixString(OAUNIT) + "'," +
		"" + NumberUtil.toString(OATIME) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(OASDAT) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(OASTIM) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(OAEDAT) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(OAETIM) + "'," +
		"'" + Converter.fixString(OASRCE) + "'," +
		"'" + Converter.fixString(OASTAT) + "'," +
		"'" + Converter.fixString(OAPOST) + "')";
	write(sql);
}

public override
void update(){
	string sql = "update rprr set " +
		"OABTID = " + NumberUtil.toString(OABTID) + ", " +
		"OAENT = " + NumberUtil.toString(OAENT) + ", " +
		"OADEPT = '" + Converter.fixString(OADEPT) + "', " +
		"OARESC = '" + Converter.fixString(OARESC) + "', " +
		"OARDAT = '" + DateUtil.getCompleteDateRepresentation(OARDAT) + "', " +
		"OASHFT = " + NumberUtil.toString(OASHFT) + ", " +
		"OASHGP = '" + Converter.fixString(OASHGP) + "', " +
		"OAPART = '" + Converter.fixString(OAPART) + "', " +
		"OAJOB = '" + Converter.fixString(OAJOB) + "', " +
		"OASEQ = " + NumberUtil.toString(OASEQ) + ", " +
		"OAQTYG = " + NumberUtil.toString(OAQTYG) + ", " +
		"OAQTYS = " + NumberUtil.toString(OAQTYS) + ", " +
		"OAUNIT = '" + Converter.fixString(OAUNIT) + "', " +
		"OATIME = " + NumberUtil.toString(OATIME) + ", " +
		"OASDAT = '" + DateUtil.getCompleteDateRepresentation(OASDAT) + "', " +
		"OASTIM = '" + DateUtil.getCompleteDateRepresentation(OASTIM) + "', " +
		"OAEDAT = '" + DateUtil.getCompleteDateRepresentation(OAEDAT) + "', " +
		"OAETIM = '" + DateUtil.getCompleteDateRepresentation(OAETIM) + "', " +
		"OASRCE = '" + Converter.fixString(OASRCE) + "', " +
		"OASTAT = '" + Converter.fixString(OASTAT) + "', " +
		"OAPOST = '" + Converter.fixString(OAPOST) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from rprr where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"OABTID = " + NumberUtil.toString(OABTID) + " and " +
		"OAENT = " + NumberUtil.toString(OAENT) + "";
	return sqlWhere;
}

public
void setOABTID(decimal OABTID){
	this.OABTID = OABTID;
}

public
void setOAENT(decimal OAENT){
	this.OAENT = OAENT;
}

public
void setOADEPT(string OADEPT){
	this.OADEPT = OADEPT;
}

public
void setOARESC(string OARESC){
	this.OARESC = OARESC;
}

public
void setOARDAT(DateTime OARDAT){
	this.OARDAT = OARDAT;
}

public
void setOASHFT(decimal OASHFT){
	this.OASHFT = OASHFT;
}

public
void setOASHGP(string OASHGP){
	this.OASHGP = OASHGP;
}

public
void setOAPART(string OAPART){
	this.OAPART = OAPART;
}

public
void setOAJOB(string OAJOB){
	this.OAJOB = OAJOB;
}

public
void setOASEQ(decimal OASEQ){
	this.OASEQ = OASEQ;
}

public
void setOAQTYG(decimal OAQTYG){
	this.OAQTYG = OAQTYG;
}

public
void setOAQTYS(decimal OAQTYS){
	this.OAQTYS = OAQTYS;
}

public
void setOAUNIT(string OAUNIT){
	this.OAUNIT = OAUNIT;
}

public
void setOATIME(decimal OATIME){
	this.OATIME = OATIME;
}

public
void setOASDAT(DateTime OASDAT){
	this.OASDAT = OASDAT;
}

public
void setOASTIM(DateTime OASTIM){
	this.OASTIM = OASTIM;
}

public
void setOAEDAT(DateTime OAEDAT){
	this.OAEDAT = OAEDAT;
}

public
void setOAETIM(DateTime OAETIM){
	this.OAETIM = OAETIM;
}

public
void setOASRCE(string OASRCE){
	this.OASRCE = OASRCE;
}

public
void setOASTAT(string OASTAT){
	this.OASTAT = OASTAT;
}

public
void setOAPOST(string OAPOST){
	this.OAPOST = OAPOST;
}

public
decimal getOABTID(){
	return OABTID;
}

public
decimal getOAENT(){
	return OAENT;
}

public
string getOADEPT(){
	return OADEPT;
}

public
string getOARESC(){
	return OARESC;
}

public
DateTime getOARDAT(){
	return OARDAT;
}

public
decimal getOASHFT(){
	return OASHFT;
}

public
string getOASHGP(){
	return OASHGP;
}

public
string getOAPART(){
	return OAPART;
}

public
string getOAJOB(){
	return OAJOB;
}

public
decimal getOASEQ(){
	return OASEQ;
}

public
decimal getOAQTYG(){
	return OAQTYG;
}

public
decimal getOAQTYS(){
	return OAQTYS;
}

public
string getOAUNIT(){
	return OAUNIT;
}

public
decimal getOATIME(){
	return OATIME;
}

public
DateTime getOASDAT(){
	return OASDAT;
}

public
DateTime getOASTIM(){
	return OASTIM;
}

public
DateTime getOAEDAT(){
	return OAEDAT;
}

public
DateTime getOAETIM(){
	return OAETIM;
}

public
string getOASRCE(){
	return OASRCE;
}

public
string getOASTAT(){
	return OASTAT;
}

public
string getOAPOST(){
	return OAPOST;
}

} // class

} // package