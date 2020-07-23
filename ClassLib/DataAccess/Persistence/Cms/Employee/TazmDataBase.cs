/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: aferreira $ 
*   $Date: 2014-05-06 14:58:08 $ 
*   $Source: /usr/local/cvsroot/Projects/NujitWms2011/ClassLib/Persistence/Cms/Concord/TazmDataBase.cs,v $ 
*   $State: Exp $ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class TazmDataBase : GenericDataBaseElement {

private string ZMEMPL;
private string ZMFNME;
private string ZMLNME;
private string ZMADR1;
private string ZMADR2;
private string ZMADR3;
private string ZMPOST;
private string ZMHPHO;
private string ZMHFAX;
private string ZMWPHO;
private string ZMWEXT;
private string ZMCONT;
private string ZMTELC;
private string ZMSOIN;
private DateTime ZMDTEH;
private DateTime ZMDTEB;
private string ZMTITL;
private string ZMETYP;
private string ZMCLCD;
private string ZMGRCD;
private decimal ZMBRTE;
private string ZMTAG;
private string ZMSTAT;
private string ZMREAS;
private string ZMBDEP;
private string ZMRPNT;
private string ZMUVER;

public
TazmDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}


public
string getTable() {
    string table = "tazm";
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
        table = Configuration.CMSLibrary + "." + table;
    return table;
}

private
string getFieldZMTAG() {
    string field = "ZMTAG";
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
        field += "#";
    return field;
}

public
bool read(){
	string sql = "select * from " + getTable() + " where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from " + getTable() + " where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.ZMEMPL = reader.GetString("ZMEMPL");
	this.ZMFNME = reader.GetString("ZMFNME");
	this.ZMLNME = reader.GetString("ZMLNME");
	this.ZMADR1 = reader.GetString("ZMADR1");
	this.ZMADR2 = reader.GetString("ZMADR2");
	this.ZMADR3 = reader.GetString("ZMADR3");
	this.ZMPOST = reader.GetString("ZMPOST");
	this.ZMHPHO = reader.GetString("ZMHPHO");
	this.ZMHFAX = reader.GetString("ZMHFAX");
	this.ZMWPHO = reader.GetString("ZMWPHO");
	this.ZMWEXT = reader.GetString("ZMWEXT");
	this.ZMCONT = reader.GetString("ZMCONT");
	this.ZMTELC = reader.GetString("ZMTELC");
	this.ZMSOIN = reader.GetString("ZMSOIN");
	this.ZMDTEH = reader.GetDateTime("ZMDTEH");
	this.ZMDTEB = reader.GetDateTime("ZMDTEB");
	this.ZMTITL = reader.GetString("ZMTITL");
	this.ZMETYP = reader.GetString("ZMETYP");
	this.ZMCLCD = reader.GetString("ZMCLCD");
	this.ZMGRCD = reader.GetString("ZMGRCD");
	this.ZMBRTE = reader.GetDecimal("ZMBRTE");
	this.ZMTAG = reader.GetString(getFieldZMTAG());
	this.ZMSTAT = reader.GetString("ZMSTAT");
	this.ZMREAS = reader.GetString("ZMREAS");
	this.ZMBDEP = reader.GetString("ZMBDEP");
	this.ZMRPNT = reader.GetString("ZMRPNT");
	this.ZMUVER = reader.GetString("ZMUVER");
}

public override
void write(){ 
	string sql = "insert into " + getTable() + "(" + 
		"ZMEMPL," +
		"ZMFNME," +
		"ZMLNME," +
		"ZMADR1," +
		"ZMADR2," +
		"ZMADR3," +
		"ZMPOST," +
		"ZMHPHO," +
		"ZMHFAX," +
		"ZMWPHO," +
		"ZMWEXT," +
		"ZMCONT," +
		"ZMTELC," +
		"ZMSOIN," +
		"ZMDTEH," +
		"ZMDTEB," +
		"ZMTITL," +
		"ZMETYP," +
		"ZMCLCD," +
		"ZMGRCD," +
		"ZMBRTE," +
		getFieldZMTAG()+"," +
		"ZMSTAT," +
		"ZMREAS," +
		"ZMBDEP," +
		"ZMRPNT," +
		"ZMUVER" +

		") values (" + 

		"'" + Converter.fixString(ZMEMPL) + "'," +
		"'" + Converter.fixString(ZMFNME) + "'," +
		"'" + Converter.fixString(ZMLNME) + "'," +
		"'" + Converter.fixString(ZMADR1) + "'," +
		"'" + Converter.fixString(ZMADR2) + "'," +
		"'" + Converter.fixString(ZMADR3) + "'," +
		"'" + Converter.fixString(ZMPOST) + "'," +
		"'" + Converter.fixString(ZMHPHO) + "'," +
		"'" + Converter.fixString(ZMHFAX) + "'," +
		"'" + Converter.fixString(ZMWPHO) + "'," +
		"'" + Converter.fixString(ZMWEXT) + "'," +
		"'" + Converter.fixString(ZMCONT) + "'," +
		"'" + Converter.fixString(ZMTELC) + "'," +
		"'" + Converter.fixString(ZMSOIN) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(ZMDTEH) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(ZMDTEB) + "'," +
		"'" + Converter.fixString(ZMTITL) + "'," +
		"'" + Converter.fixString(ZMETYP) + "'," +
		"'" + Converter.fixString(ZMCLCD) + "'," +
		"'" + Converter.fixString(ZMGRCD) + "'," +
		"" + NumberUtil.toString(ZMBRTE) + "," +
		"'" + Converter.fixString(ZMTAG) + "'," +
		"'" + Converter.fixString(ZMSTAT) + "'," +
		"'" + Converter.fixString(ZMREAS) + "'," +
		"'" + Converter.fixString(ZMBDEP) + "'," +
		"'" + Converter.fixString(ZMRPNT) + "'," +
		"'" + Converter.fixString(ZMUVER) + "')";
	write(sql);	
}

public override
void update(){
	string sql = "update " + getTable() + " set " +
		"ZMEMPL = '" + Converter.fixString(ZMEMPL) + "', " +
		"ZMFNME = '" + Converter.fixString(ZMFNME) + "', " +
		"ZMLNME = '" + Converter.fixString(ZMLNME) + "', " +
		"ZMADR1 = '" + Converter.fixString(ZMADR1) + "', " +
		"ZMADR2 = '" + Converter.fixString(ZMADR2) + "', " +
		"ZMADR3 = '" + Converter.fixString(ZMADR3) + "', " +
		"ZMPOST = '" + Converter.fixString(ZMPOST) + "', " +
		"ZMHPHO = '" + Converter.fixString(ZMHPHO) + "', " +
		"ZMHFAX = '" + Converter.fixString(ZMHFAX) + "', " +
		"ZMWPHO = '" + Converter.fixString(ZMWPHO) + "', " +
		"ZMWEXT = '" + Converter.fixString(ZMWEXT) + "', " +
		"ZMCONT = '" + Converter.fixString(ZMCONT) + "', " +
		"ZMTELC = '" + Converter.fixString(ZMTELC) + "', " +
		"ZMSOIN = '" + Converter.fixString(ZMSOIN) + "', " +
		"ZMDTEH = '" + DateUtil.getCompleteDateRepresentation(ZMDTEH) + "', " +
		"ZMDTEB = '" + DateUtil.getCompleteDateRepresentation(ZMDTEB) + "', " +
		"ZMTITL = '" + Converter.fixString(ZMTITL) + "', " +
		"ZMETYP = '" + Converter.fixString(ZMETYP) + "', " +
		"ZMCLCD = '" + Converter.fixString(ZMCLCD) + "', " +
		"ZMGRCD = '" + Converter.fixString(ZMGRCD) + "', " +
		"ZMBRTE = " + NumberUtil.toString(ZMBRTE) + ", " +
		getFieldZMTAG()+"= '" + Converter.fixString(ZMTAG) + "', " +
		"ZMSTAT = '" + Converter.fixString(ZMSTAT) + "', " +
		"ZMREAS = '" + Converter.fixString(ZMREAS) + "', " +
		"ZMBDEP = '" + Converter.fixString(ZMBDEP) + "', " +
		"ZMRPNT = '" + Converter.fixString(ZMRPNT) + "', " +
		"ZMUVER = '" + Converter.fixString(ZMUVER) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from " + getTable() + " where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"ZMEMPL = '" + Converter.fixString(ZMEMPL) + "'";
	return sqlWhere;
}

public
void setZMEMPL(string ZMEMPL){
	this.ZMEMPL = ZMEMPL;
}

public
void setZMFNME(string ZMFNME){
	this.ZMFNME = ZMFNME;
}

public
void setZMLNME(string ZMLNME){
	this.ZMLNME = ZMLNME;
}

public
void setZMADR1(string ZMADR1){
	this.ZMADR1 = ZMADR1;
}

public
void setZMADR2(string ZMADR2){
	this.ZMADR2 = ZMADR2;
}

public
void setZMADR3(string ZMADR3){
	this.ZMADR3 = ZMADR3;
}

public
void setZMPOST(string ZMPOST){
	this.ZMPOST = ZMPOST;
}

public
void setZMHPHO(string ZMHPHO){
	this.ZMHPHO = ZMHPHO;
}

public
void setZMHFAX(string ZMHFAX){
	this.ZMHFAX = ZMHFAX;
}

public
void setZMWPHO(string ZMWPHO){
	this.ZMWPHO = ZMWPHO;
}

public
void setZMWEXT(string ZMWEXT){
	this.ZMWEXT = ZMWEXT;
}

public
void setZMCONT(string ZMCONT){
	this.ZMCONT = ZMCONT;
}

public
void setZMTELC(string ZMTELC){
	this.ZMTELC = ZMTELC;
}

public
void setZMSOIN(string ZMSOIN){
	this.ZMSOIN = ZMSOIN;
}

public
void setZMDTEH(DateTime ZMDTEH){
	this.ZMDTEH = ZMDTEH;
}

public
void setZMDTEB(DateTime ZMDTEB){
	this.ZMDTEB = ZMDTEB;
}

public
void setZMTITL(string ZMTITL){
	this.ZMTITL = ZMTITL;
}

public
void setZMETYP(string ZMETYP){
	this.ZMETYP = ZMETYP;
}

public
void setZMCLCD(string ZMCLCD){
	this.ZMCLCD = ZMCLCD;
}

public
void setZMGRCD(string ZMGRCD){
	this.ZMGRCD = ZMGRCD;
}

public
void setZMBRTE(decimal ZMBRTE){
	this.ZMBRTE = ZMBRTE;
}

public
void setZMTAG(string ZMTAG){
	this.ZMTAG = ZMTAG;
}

public
void setZMSTAT(string ZMSTAT){
	this.ZMSTAT = ZMSTAT;
}

public
void setZMREAS(string ZMREAS){
	this.ZMREAS = ZMREAS;
}

public
void setZMBDEP(string ZMBDEP){
	this.ZMBDEP = ZMBDEP;
}

public
void setZMRPNT(string ZMRPNT){
	this.ZMRPNT = ZMRPNT;
}

public
void setZMUVER(string ZMUVER){
	this.ZMUVER = ZMUVER;
}

public
string getZMEMPL(){
	return ZMEMPL;
}

public
string getZMFNME(){
	return ZMFNME;
}

public
string getZMLNME(){
	return ZMLNME;
}

public
string getZMADR1(){
	return ZMADR1;
}

public
string getZMADR2(){
	return ZMADR2;
}

public
string getZMADR3(){
	return ZMADR3;
}

public
string getZMPOST(){
	return ZMPOST;
}

public
string getZMHPHO(){
	return ZMHPHO;
}

public
string getZMHFAX(){
	return ZMHFAX;
}

public
string getZMWPHO(){
	return ZMWPHO;
}

public
string getZMWEXT(){
	return ZMWEXT;
}

public
string getZMCONT(){
	return ZMCONT;
}

public
string getZMTELC(){
	return ZMTELC;
}

public
string getZMSOIN(){
	return ZMSOIN;
}

public
DateTime getZMDTEH(){
	return ZMDTEH;
}

public
DateTime getZMDTEB(){
	return ZMDTEB;
}

public
string getZMTITL(){
	return ZMTITL;
}

public
string getZMETYP(){
	return ZMETYP;
}

public
string getZMCLCD(){
	return ZMCLCD;
}

public
string getZMGRCD(){
	return ZMGRCD;
}

public
decimal getZMBRTE(){
	return ZMBRTE;
}

public
string getZMTAG(){
	return ZMTAG;
}

public
string getZMSTAT(){
	return ZMSTAT;
}

public
string getZMREAS(){
	return ZMREAS;
}

public
string getZMBDEP(){
	return ZMBDEP;
}

public
string getZMRPNT(){
	return ZMRPNT;
}

public
string getZMUVER(){
	return ZMUVER;
}

} // class
} // package