/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public
class StxhDataBase : GenericDataBaseElement {

private decimal OYLOG;
private decimal OYENT;
private string OYTRCD;
private string OYTRPR;
private string OYDOCN;
private string OYEXCD;
private string OYDCCL;
private string OYMAPT;
private DateTime OYCDAT;
private decimal OYCHRM;
private string OYSTAT;
private DateTime OYTDAT;
private decimal OYTHRM;
private string OYNOTE;
private string OYSUPL;
private string OYDOCC;
private string OYITYP;
private string OYFUT1;
private string OYFUT2;
private string OYFUT3;
private string OYFUT4;
private string OYFUT5;
private string OYFUT6;
private string OYFUT7;
private string OYFUT8;
private string OYFUT9;
private string OYPLNT;
private string OYMLBX;

public
StxhDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from stxh where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from stxh where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.OYLOG = reader.GetDecimal("OYLOG#");
	this.OYENT = reader.GetDecimal("OYENT#");
	this.OYTRCD = reader.GetString("OYTRCD");
	this.OYTRPR = reader.GetString("OYTRPR");
	this.OYDOCN = reader.GetString("OYDOCN");
	this.OYEXCD = reader.GetString("OYEXCD");
	this.OYDCCL = reader.GetString("OYDCCL");
	this.OYMAPT = reader.GetString("OYMAPT");
	this.OYCDAT = reader.GetDateTime("OYCDAT");
	this.OYCHRM = reader.GetDecimal("OYCHRM");
	this.OYSTAT = reader.GetString("OYSTAT");
	this.OYTDAT = reader.GetDateTime("OYTDAT");
	this.OYTHRM = reader.GetDecimal("OYTHRM");
	this.OYNOTE = reader.GetString("OYNOTE");
	this.OYSUPL = reader.GetString("OYSUPL");
	this.OYDOCC = reader.GetString("OYDOCC");
	this.OYITYP = reader.GetString("OYITYP");
	this.OYFUT1 = reader.GetString("OYFUT1");
	this.OYFUT2 = reader.GetString("OYFUT2");
	this.OYFUT3 = reader.GetString("OYFUT3");
	this.OYFUT4 = reader.GetString("OYFUT4");
	this.OYFUT5 = reader.GetString("OYFUT5");
	this.OYFUT6 = reader.GetString("OYFUT6");
	this.OYFUT7 = reader.GetString("OYFUT7");
	this.OYFUT8 = reader.GetString("OYFUT8");
	this.OYFUT9 = reader.GetString("OYFUT9");
	this.OYPLNT = reader.GetString("OYPLNT");
	this.OYMLBX = reader.GetString("OYMLBX");
}

public override
void write(){
	string sql = "insert into stxh(" + 
		"OYLOG#," +
		"OYENT#," +
		"OYTRCD," +
		"OYTRPR," +
		"OYDOCN," +
		"OYEXCD," +
		"OYDCCL," +
		"OYMAPT," +
		"OYCDAT," +
		"OYCHRM," +
		"OYSTAT," +
		"OYTDAT," +
		"OYTHRM," +
		"OYNOTE," +
		"OYSUPL," +
		"OYDOCC," +
		"OYITYP," +
		"OYFUT1," +
		"OYFUT2," +
		"OYFUT3," +
		"OYFUT4," +
		"OYFUT5," +
		"OYFUT6," +
		"OYFUT7," +
		"OYFUT8," +
		"OYFUT9," +
		"OYPLNT," +
		"OYMLBX" +

		") values (" + 

		"" + NumberUtil.toString(OYLOG) + "," +
		"" + NumberUtil.toString(OYENT) + "," +
		"'" + Converter.fixString(OYTRCD) + "'," +
		"'" + Converter.fixString(OYTRPR) + "'," +
		"'" + Converter.fixString(OYDOCN) + "'," +
		"'" + Converter.fixString(OYEXCD) + "'," +
		"'" + Converter.fixString(OYDCCL) + "'," +
		"'" + Converter.fixString(OYMAPT) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(OYCDAT) + "'," +
		"" + NumberUtil.toString(OYCHRM) + "," +
		"'" + Converter.fixString(OYSTAT) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(OYTDAT) + "'," +
		"" + NumberUtil.toString(OYTHRM) + "," +
		"'" + Converter.fixString(OYNOTE) + "'," +
		"'" + Converter.fixString(OYSUPL) + "'," +
		"'" + Converter.fixString(OYDOCC) + "'," +
		"'" + Converter.fixString(OYITYP) + "'," +
		"'" + Converter.fixString(OYFUT1) + "'," +
		"'" + Converter.fixString(OYFUT2) + "'," +
		"'" + Converter.fixString(OYFUT3) + "'," +
		"'" + Converter.fixString(OYFUT4) + "'," +
		"'" + Converter.fixString(OYFUT5) + "'," +
		"'" + Converter.fixString(OYFUT6) + "'," +
		"'" + Converter.fixString(OYFUT7) + "'," +
		"'" + Converter.fixString(OYFUT8) + "'," +
		"'" + Converter.fixString(OYFUT9) + "'," +
		"'" + Converter.fixString(OYPLNT) + "'," +
		"'" + Converter.fixString(OYMLBX) + "')";
	write(sql);	
}

public override
void update(){
	string sql = "update stxh set " +
		"OYLOG# = " + NumberUtil.toString(OYLOG) + ", " +
		"OYENT# = " + NumberUtil.toString(OYENT) + ", " +
		"OYTRCD = '" + Converter.fixString(OYTRCD) + "', " +
		"OYTRPR = '" + Converter.fixString(OYTRPR) + "', " +
		"OYDOCN = '" + Converter.fixString(OYDOCN) + "', " +
		"OYEXCD = '" + Converter.fixString(OYEXCD) + "', " +
		"OYDCCL = '" + Converter.fixString(OYDCCL) + "', " +
		"OYMAPT = '" + Converter.fixString(OYMAPT) + "', " +
		"OYCDAT = '" + DateUtil.getCompleteDateRepresentation(OYCDAT) + "', " +
		"OYCHRM = " + NumberUtil.toString(OYCHRM) + ", " +
		"OYSTAT = '" + Converter.fixString(OYSTAT) + "', " +
		"OYTDAT = '" + DateUtil.getCompleteDateRepresentation(OYTDAT) + "', " +
		"OYTHRM = " + NumberUtil.toString(OYTHRM) + ", " +
		"OYNOTE = '" + Converter.fixString(OYNOTE) + "', " +
		"OYSUPL = '" + Converter.fixString(OYSUPL) + "', " +
		"OYDOCC = '" + Converter.fixString(OYDOCC) + "', " +
		"OYITYP = '" + Converter.fixString(OYITYP) + "', " +
		"OYFUT1 = '" + Converter.fixString(OYFUT1) + "', " +
		"OYFUT2 = '" + Converter.fixString(OYFUT2) + "', " +
		"OYFUT3 = '" + Converter.fixString(OYFUT3) + "', " +
		"OYFUT4 = '" + Converter.fixString(OYFUT4) + "', " +
		"OYFUT5 = '" + Converter.fixString(OYFUT5) + "', " +
		"OYFUT6 = '" + Converter.fixString(OYFUT6) + "', " +
		"OYFUT7 = '" + Converter.fixString(OYFUT7) + "', " +
		"OYFUT8 = '" + Converter.fixString(OYFUT8) + "', " +
		"OYFUT9 = '" + Converter.fixString(OYFUT9) + "', " +
		"OYPLNT = '" + Converter.fixString(OYPLNT) + "', " +
		"OYMLBX = '" + Converter.fixString(OYMLBX) + "' " +

		"where " + getWhereCondition();
	update(sql);
}

public override
void delete(){
	string sql = "delete from stxh where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"OYLOG# = " + NumberUtil.toString(OYLOG) + " and " +
		"OYENT# = " + NumberUtil.toString(OYENT) + "";
	return sqlWhere;
}

public
void setOYLOG(decimal OYLOG){
	this.OYLOG = OYLOG;
}

public
void setOYENT(decimal OYENT){
	this.OYENT = OYENT;
}

public
void setOYTRCD(string OYTRCD){
	this.OYTRCD = OYTRCD;
}

public
void setOYTRPR(string OYTRPR){
	this.OYTRPR = OYTRPR;
}

public
void setOYDOCN(string OYDOCN){
	this.OYDOCN = OYDOCN;
}

public
void setOYEXCD(string OYEXCD){
	this.OYEXCD = OYEXCD;
}

public
void setOYDCCL(string OYDCCL){
	this.OYDCCL = OYDCCL;
}

public
void setOYMAPT(string OYMAPT){
	this.OYMAPT = OYMAPT;
}

public
void setOYCDAT(DateTime OYCDAT){
	this.OYCDAT = OYCDAT;
}

public
void setOYCHRM(decimal OYCHRM){
	this.OYCHRM = OYCHRM;
}

public
void setOYSTAT(string OYSTAT){
	this.OYSTAT = OYSTAT;
}

public
void setOYTDAT(DateTime OYTDAT){
	this.OYTDAT = OYTDAT;
}

public
void setOYTHRM(decimal OYTHRM){
	this.OYTHRM = OYTHRM;
}

public
void setOYNOTE(string OYNOTE){
	this.OYNOTE = OYNOTE;
}

public
void setOYSUPL(string OYSUPL){
	this.OYSUPL = OYSUPL;
}

public
void setOYDOCC(string OYDOCC){
	this.OYDOCC = OYDOCC;
}

public
void setOYITYP(string OYITYP){
	this.OYITYP = OYITYP;
}

public
void setOYFUT1(string OYFUT1){
	this.OYFUT1 = OYFUT1;
}

public
void setOYFUT2(string OYFUT2){
	this.OYFUT2 = OYFUT2;
}

public
void setOYFUT3(string OYFUT3){
	this.OYFUT3 = OYFUT3;
}

public
void setOYFUT4(string OYFUT4){
	this.OYFUT4 = OYFUT4;
}

public
void setOYFUT5(string OYFUT5){
	this.OYFUT5 = OYFUT5;
}

public
void setOYFUT6(string OYFUT6){
	this.OYFUT6 = OYFUT6;
}

public
void setOYFUT7(string OYFUT7){
	this.OYFUT7 = OYFUT7;
}

public
void setOYFUT8(string OYFUT8){
	this.OYFUT8 = OYFUT8;
}

public
void setOYFUT9(string OYFUT9){
	this.OYFUT9 = OYFUT9;
}

public
void setOYPLNT(string OYPLNT){
	this.OYPLNT = OYPLNT;
}

public
void setOYMLBX(string OYMLBX){
	this.OYMLBX = OYMLBX;
}

public
decimal getOYLOG(){
	return OYLOG;
}

public
decimal getOYENT(){
	return OYENT;
}

public
string getOYTRCD(){
	return OYTRCD;
}

public
string getOYTRPR(){
	return OYTRPR;
}

public
string getOYDOCN(){
	return OYDOCN;
}

public
string getOYEXCD(){
	return OYEXCD;
}

public
string getOYDCCL(){
	return OYDCCL;
}

public
string getOYMAPT(){
	return OYMAPT;
}

public
DateTime getOYCDAT(){
	return OYCDAT;
}

public
decimal getOYCHRM(){
	return OYCHRM;
}

public
string getOYSTAT(){
	return OYSTAT;
}

public
DateTime getOYTDAT(){
	return OYTDAT;
}

public
decimal getOYTHRM(){
	return OYTHRM;
}

public
string getOYNOTE(){
	return OYNOTE;
}

public
string getOYSUPL(){
	return OYSUPL;
}

public
string getOYDOCC(){
	return OYDOCC;
}

public
string getOYITYP(){
	return OYITYP;
}

public
string getOYFUT1(){
	return OYFUT1;
}

public
string getOYFUT2(){
	return OYFUT2;
}

public
string getOYFUT3(){
	return OYFUT3;
}

public
string getOYFUT4(){
	return OYFUT4;
}

public
string getOYFUT5(){
	return OYFUT5;
}

public
string getOYFUT6(){
	return OYFUT6;
}

public
string getOYFUT7(){
	return OYFUT7;
}

public
string getOYFUT8(){
	return OYFUT8;
}

public
string getOYFUT9(){
	return OYFUT9;
}

public
string getOYPLNT(){
	return OYPLNT;
}

public
string getOYMLBX(){
	return OYMLBX;
}

} // class
} // package