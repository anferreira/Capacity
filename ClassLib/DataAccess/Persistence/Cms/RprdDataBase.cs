/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: gpiano $ 
*   $Date: 2006-05-30 13:09:39 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/DataAccess/Persistence/Cms/RprdDataBase.cs,v $ 
*   $State: Exp $ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public
class RprdDataBase : GenericDataBaseElement{

private decimal NXBTID;
private decimal NXENT;
private string NXDEPT;
private string NXRESC;
private DateTime NXRDAT;
private decimal NXSHFT;
private string NXSHGP;
private string NXINDC;
private decimal NXTIME;
private DateTime NXSDAT;
private DateTime NXSTIM;
private DateTime NXEDAT;
private DateTime NXETIM;
private string NXSRCE;
private string NXPOST;

public
RprdDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
void read(){
	throw new PersistenceException("Not implemented !");
}

public
bool exists(){
	string sql = "select * from rprd where " + getWhereCondition();
	return exists(sql);
}

internal
void load(NotNullDataReader reader){
	this.NXBTID = reader.GetDecimal("NXBTID");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.NXENT = reader.GetDecimal("NXENT#");
	else
		this.NXENT = reader.GetDecimal("NXENT");
	this.NXDEPT = reader.GetString("NXDEPT");
	this.NXRESC = reader.GetString("NXRESC");
	this.NXRDAT = reader.GetDateTime("NXRDAT");
	this.NXSHFT = reader.GetDecimal("NXSHFT");
	this.NXSHGP = reader.GetString("NXSHGP");
	this.NXINDC = reader.GetString("NXINDC");
	this.NXTIME = reader.GetDecimal("NXTIME");
	this.NXSDAT = reader.GetDateTime("NXSDAT");	
    try{
        this.NXSTIM = reader.GetDateTime("NXSTIM");
    }catch {
        this.NXSTIM = DateUtil.decimalMinutesToHoursHHMM(reader.GetDecimal("NXSTIM"));
    }
	this.NXEDAT = reader.GetDateTime("NXEDAT");	
    try{
        this.NXETIM = reader.GetDateTime("NXETIM");
    }catch {
        this.NXETIM = DateUtil.decimalMinutesToHoursHHMM(reader.GetDecimal("NXETIM"));
    }
	this.NXSRCE = reader.GetString("NXSRCE");
	this.NXPOST = reader.GetString("NXPOST");
}

public override
void write(){
	string sql = "insert into rprd(" + 
		"NXBTID," +
		"NXENT," +
		"NXDEPT," +
		"NXRESC," +
		"NXRDAT," +
		"NXSHFT," +
		"NXSHGP," +
		"NXINDC," +
		"NXTIME," +
		"NXSDAT," +
		"NXSTIM," +
		"NXEDAT," +
		"NXETIM," +
		"NXSRCE," +
		"NXPOST" +

		") values (" + 

		"" + NumberUtil.toString(NXBTID) + "," +
		"" + NumberUtil.toString(NXENT) + "," +
		"'" + Converter.fixString(NXDEPT) + "'," +
		"'" + Converter.fixString(NXRESC) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(NXRDAT) + "'," +
		"" + NumberUtil.toString(NXSHFT) + "," +
		"'" + Converter.fixString(NXSHGP) + "'," +
		"'" + Converter.fixString(NXINDC) + "'," +
		"" + NumberUtil.toString(NXTIME) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(NXSDAT) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(NXSTIM) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(NXEDAT) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(NXETIM) + "'," +
		"'" + Converter.fixString(NXSRCE) + "'," +
		"'" + Converter.fixString(NXPOST) + "')";
	write(sql);
}

public override
void update(){
	string sql = "update rprd set " +
		"NXBTID = " + NumberUtil.toString(NXBTID) + ", " +
		"NXENT = " + NumberUtil.toString(NXENT) + ", " +
		"NXDEPT = '" + Converter.fixString(NXDEPT) + "', " +
		"NXRESC = '" + Converter.fixString(NXRESC) + "', " +
		"NXRDAT = '" + DateUtil.getCompleteDateRepresentation(NXRDAT) + "', " +
		"NXSHFT = " + NumberUtil.toString(NXSHFT) + ", " +
		"NXSHGP = '" + Converter.fixString(NXSHGP) + "', " +
		"NXINDC = '" + Converter.fixString(NXINDC) + "', " +
		"NXTIME = " + NumberUtil.toString(NXTIME) + ", " +
		"NXSDAT = '" + DateUtil.getCompleteDateRepresentation(NXSDAT) + "', " +
		"NXSTIM = '" + DateUtil.getCompleteDateRepresentation(NXSTIM) + "', " +
		"NXEDAT = '" + DateUtil.getCompleteDateRepresentation(NXEDAT) + "', " +
		"NXETIM = '" + DateUtil.getCompleteDateRepresentation(NXETIM) + "', " +
		"NXSRCE = '" + Converter.fixString(NXSRCE) + "', " +
		"NXPOST = '" + Converter.fixString(NXPOST) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from rprd where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"NXBTID = " + NumberUtil.toString(NXBTID) + " and " +
		"NXENT = " + NumberUtil.toString(NXENT) + "";
	return sqlWhere;
}

public
void setNXBTID(decimal NXBTID){
	this.NXBTID = NXBTID;
}

public
void setNXENT(decimal NXENT){
	this.NXENT = NXENT;
}

public
void setNXDEPT(string NXDEPT){
	this.NXDEPT = NXDEPT;
}

public
void setNXRESC(string NXRESC){
	this.NXRESC = NXRESC;
}

public
void setNXRDAT(DateTime NXRDAT){
	this.NXRDAT = NXRDAT;
}

public
void setNXSHFT(decimal NXSHFT){
	this.NXSHFT = NXSHFT;
}

public
void setNXSHGP(string NXSHGP){
	this.NXSHGP = NXSHGP;
}

public
void setNXINDC(string NXINDC){
	this.NXINDC = NXINDC;
}

public
void setNXTIME(decimal NXTIME){
	this.NXTIME = NXTIME;
}

public
void setNXSDAT(DateTime NXSDAT){
	this.NXSDAT = NXSDAT;
}

public
void setNXSTIM(DateTime NXSTIM){
	this.NXSTIM = NXSTIM;
}

public
void setNXEDAT(DateTime NXEDAT){
	this.NXEDAT = NXEDAT;
}

public
void setNXETIM(DateTime NXETIM){
	this.NXETIM = NXETIM;
}

public
void setNXSRCE(string NXSRCE){
	this.NXSRCE = NXSRCE;
}

public
void setNXPOST(string NXPOST){
	this.NXPOST = NXPOST;
}

public
decimal getNXBTID(){
	return NXBTID;
}

public
decimal getNXENT(){
	return NXENT;
}

public
string getNXDEPT(){
	return NXDEPT;
}

public
string getNXRESC(){
	return NXRESC;
}

public
DateTime getNXRDAT(){
	return NXRDAT;
}

public
decimal getNXSHFT(){
	return NXSHFT;
}

public
string getNXSHGP(){
	return NXSHGP;
}

public
string getNXINDC(){
	return NXINDC;
}

public
decimal getNXTIME(){
	return NXTIME;
}

public
DateTime getNXSDAT(){
	return NXSDAT;
}

public
DateTime getNXSTIM(){
	return NXSTIM;
}

public
DateTime getNXEDAT(){
	return NXEDAT;
}

public
DateTime getNXETIM(){
	return NXETIM;
}

public
string getNXSRCE(){
	return NXSRCE;
}

public
string getNXPOST(){
	return NXPOST;
}

} // class

} // package