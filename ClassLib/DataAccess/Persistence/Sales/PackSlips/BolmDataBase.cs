/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Sales.PackSlips{

    public
class BolmDataBase : GenericDataBaseElement {

private decimal RAMBOL;
private DateTime RACDAT;
private string RAPIND;
private string RASIND;
private string RASHPL;
private string RABNME;
private DateTime RASDAT;
private string RASVIA;
private string RATKID;
private string RAROUT;
private decimal RANCTN;
private decimal RANETW;
private decimal RAGROW;
private decimal RATARW;
private string RADOCD;
private string RACARC;
private string RAPRTF;
private string RAPLNT;
private decimal RASTME;
private string RASTMZ;
private string RASBOL;
private string RABLTR;
private string RABSTS;
private string RABLAK;
private string RABSET;
private string RABLMD;
private string RASEAL;
private string RACPRO;

public
BolmDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){	
    string sql = "select * from " + getTablePrefix() + "bolm where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from " + getTablePrefix() + "bolm where " + getWhereCondition();
	return exists(sql);
}

public
void load(NotNullDataReader reader){
	this.RAMBOL = reader.GetDecimal("RAMBOL");
	this.RACDAT = reader.GetDateTime("RACDAT");
	this.RAPIND = reader.GetString("RAPIND");
	this.RASIND = reader.GetString("RASIND");
	this.RASHPL = reader.GetString("RASHPL");
	this.RABNME = reader.GetString("RABNME");
	this.RASDAT = reader.GetDateTime("RASDAT");
	this.RASVIA = reader.GetString("RASVIA");
	this.RATKID = reader.GetString("RATKID");
	this.RAROUT = reader.GetString("RAROUT");
	this.RANCTN = reader.GetDecimal("RANCTN");
	this.RANETW = reader.GetDecimal("RANETW");
	this.RAGROW = reader.GetDecimal("RAGROW");
	this.RATARW = reader.GetDecimal("RATARW");
	this.RADOCD = reader.GetString("RADOCD");
	this.RACARC = reader.GetString("RACARC");
	this.RAPRTF = reader.GetString("RAPRTF");
	this.RAPLNT = reader.GetString("RAPLNT");
	this.RASTME = reader.GetDecimal("RASTME");
	this.RASTMZ = reader.GetString("RASTMZ");
	this.RASBOL = reader.GetString("RASBOL");
	this.RABLTR = reader.GetString("RABLTR");
	this.RABSTS = reader.GetString("RABSTS");
	this.RABLAK = reader.GetString("RABLAK");
	this.RABSET = reader.GetString("RABSET");
	this.RABLMD = reader.GetString("RABLMD");
	this.RASEAL = reader.GetString("RASEAL");
	this.RACPRO = reader.GetString("RACPRO");
}

public override
void write(){
	string sql = "insert into " + getTablePrefix() + "bolm(" + 
		"RAMBOL," +
		"RACDAT," +
		"RAPIND," +
		"RASIND," +
		"RASHPL," +
		"RABNME," +
		"RASDAT," +
		"RASVIA," +
		"RATKID," +
		"RAROUT," +
		"RANCTN," +
		"RANETW," +
		"RAGROW," +
		"RATARW," +
		"RADOCD," +
		"RACARC," +
		"RAPRTF," +
		"RAPLNT," +
		"RASTME," +
		"RASTMZ," +
		"RASBOL," +
		"RABLTR," +
		"RABSTS," +
		"RABLAK," +
		"RABSET," +
		"RABLMD," +
		"RASEAL," +
		"RACPRO" +

		") values (" + 

		"" + NumberUtil.toString(RAMBOL) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(RACDAT) + "'," +
		"'" + Converter.fixString(RAPIND) + "'," +
		"'" + Converter.fixString(RASIND) + "'," +
		"'" + Converter.fixString(RASHPL) + "'," +
		"'" + Converter.fixString(RABNME) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(RASDAT) + "'," +
		"'" + Converter.fixString(RASVIA) + "'," +
		"'" + Converter.fixString(RATKID) + "'," +
		"'" + Converter.fixString(RAROUT) + "'," +
		"" + NumberUtil.toString(RANCTN) + "," +
		"" + NumberUtil.toString(RANETW) + "," +
		"" + NumberUtil.toString(RAGROW) + "," +
		"" + NumberUtil.toString(RATARW) + "," +
		"'" + Converter.fixString(RADOCD) + "'," +
		"'" + Converter.fixString(RACARC) + "'," +
		"'" + Converter.fixString(RAPRTF) + "'," +
		"'" + Converter.fixString(RAPLNT) + "'," +
		"" + NumberUtil.toString(RASTME) + "," +
		"'" + Converter.fixString(RASTMZ) + "'," +
		"'" + Converter.fixString(RASBOL) + "'," +
		"'" + Converter.fixString(RABLTR) + "'," +
		"'" + Converter.fixString(RABSTS) + "'," +
		"'" + Converter.fixString(RABLAK) + "'," +
		"'" + Converter.fixString(RABSET) + "'," +
		"'" + Converter.fixString(RABLMD) + "'," +
		"'" + Converter.fixString(RASEAL) + "'," +
		"'" + Converter.fixString(RACPRO) + "')";
	write(sql);	
}

public override
void update(){
	string sql = "update " + getTablePrefix() + "bolm set " +
		"RAMBOL = " + NumberUtil.toString(RAMBOL) + ", " +
		"RACDAT = '" + DateUtil.getCompleteDateRepresentation(RACDAT) + "', " +
		"RAPIND = '" + Converter.fixString(RAPIND) + "', " +
		"RASIND = '" + Converter.fixString(RASIND) + "', " +
		"RASHPL = '" + Converter.fixString(RASHPL) + "', " +
		"RABNME = '" + Converter.fixString(RABNME) + "', " +
		"RASDAT = '" + DateUtil.getCompleteDateRepresentation(RASDAT) + "', " +
		"RASVIA = '" + Converter.fixString(RASVIA) + "', " +
		"RATKID = '" + Converter.fixString(RATKID) + "', " +
		"RAROUT = '" + Converter.fixString(RAROUT) + "', " +
		"RANCTN = " + NumberUtil.toString(RANCTN) + ", " +
		"RANETW = " + NumberUtil.toString(RANETW) + ", " +
		"RAGROW = " + NumberUtil.toString(RAGROW) + ", " +
		"RATARW = " + NumberUtil.toString(RATARW) + ", " +
		"RADOCD = '" + Converter.fixString(RADOCD) + "', " +
		"RACARC = '" + Converter.fixString(RACARC) + "', " +
		"RAPRTF = '" + Converter.fixString(RAPRTF) + "', " +
		"RAPLNT = '" + Converter.fixString(RAPLNT) + "', " +
		"RASTME = " + NumberUtil.toString(RASTME) + ", " +
		"RASTMZ = '" + Converter.fixString(RASTMZ) + "', " +
		"RASBOL = '" + Converter.fixString(RASBOL) + "', " +
		"RABLTR = '" + Converter.fixString(RABLTR) + "', " +
		"RABSTS = '" + Converter.fixString(RABSTS) + "', " +
		"RABLAK = '" + Converter.fixString(RABLAK) + "', " +
		"RABSET = '" + Converter.fixString(RABSET) + "', " +
		"RABLMD = '" + Converter.fixString(RABLMD) + "', " +
		"RASEAL = '" + Converter.fixString(RASEAL) + "', " +
		"RACPRO = '" + Converter.fixString(RACPRO) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from bolm where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"RAMBOL = " + NumberUtil.toString(RAMBOL) + "";
	return sqlWhere;
}

public
void setRAMBOL(decimal RAMBOL){
	this.RAMBOL = RAMBOL;
}

public
void setRACDAT(DateTime RACDAT){
	this.RACDAT = RACDAT;
}

public
void setRAPIND(string RAPIND){
	this.RAPIND = RAPIND;
}

public
void setRASIND(string RASIND){
	this.RASIND = RASIND;
}

public
void setRASHPL(string RASHPL){
	this.RASHPL = RASHPL;
}

public
void setRABNME(string RABNME){
	this.RABNME = RABNME;
}

public
void setRASDAT(DateTime RASDAT){
	this.RASDAT = RASDAT;
}

public
void setRASVIA(string RASVIA){
	this.RASVIA = RASVIA;
}

public
void setRATKID(string RATKID){
	this.RATKID = RATKID;
}

public
void setRAROUT(string RAROUT){
	this.RAROUT = RAROUT;
}

public
void setRANCTN(decimal RANCTN){
	this.RANCTN = RANCTN;
}

public
void setRANETW(decimal RANETW){
	this.RANETW = RANETW;
}

public
void setRAGROW(decimal RAGROW){
	this.RAGROW = RAGROW;
}

public
void setRATARW(decimal RATARW){
	this.RATARW = RATARW;
}

public
void setRADOCD(string RADOCD){
	this.RADOCD = RADOCD;
}

public
void setRACARC(string RACARC){
	this.RACARC = RACARC;
}

public
void setRAPRTF(string RAPRTF){
	this.RAPRTF = RAPRTF;
}

public
void setRAPLNT(string RAPLNT){
	this.RAPLNT = RAPLNT;
}

public
void setRASTME(decimal RASTME){
	this.RASTME = RASTME;
}

public
void setRASTMZ(string RASTMZ){
	this.RASTMZ = RASTMZ;
}

public
void setRASBOL(string RASBOL){
	this.RASBOL = RASBOL;
}

public
void setRABLTR(string RABLTR){
	this.RABLTR = RABLTR;
}

public
void setRABSTS(string RABSTS){
	this.RABSTS = RABSTS;
}

public
void setRABLAK(string RABLAK){
	this.RABLAK = RABLAK;
}

public
void setRABSET(string RABSET){
	this.RABSET = RABSET;
}

public
void setRABLMD(string RABLMD){
	this.RABLMD = RABLMD;
}

public
void setRASEAL(string RASEAL){
	this.RASEAL = RASEAL;
}

public
void setRACPRO(string RACPRO){
	this.RACPRO = RACPRO;
}

public
decimal getRAMBOL(){
	return RAMBOL;
}

public
DateTime getRACDAT(){
	return RACDAT;
}

public
string getRAPIND(){
	return RAPIND;
}

public
string getRASIND(){
	return RASIND;
}

public
string getRASHPL(){
	return RASHPL;
}

public
string getRABNME(){
	return RABNME;
}

public
DateTime getRASDAT(){
	return RASDAT;
}

public
string getRASVIA(){
	return RASVIA;
}

public
string getRATKID(){
	return RATKID;
}

public
string getRAROUT(){
	return RAROUT;
}

public
decimal getRANCTN(){
	return RANCTN;
}

public
decimal getRANETW(){
	return RANETW;
}

public
decimal getRAGROW(){
	return RAGROW;
}

public
decimal getRATARW(){
	return RATARW;
}

public
string getRADOCD(){
	return RADOCD;
}

public
string getRACARC(){
	return RACARC;
}

public
string getRAPRTF(){
	return RAPRTF;
}

public
string getRAPLNT(){
	return RAPLNT;
}

public
decimal getRASTME(){
	return RASTME;
}

public
string getRASTMZ(){
	return RASTMZ;
}

public
string getRASBOL(){
	return RASBOL;
}

public
string getRABLTR(){
	return RABLTR;
}

public
string getRABSTS(){
	return RABSTS;
}

public
string getRABLAK(){
	return RABLAK;
}

public
string getRABSET(){
	return RABSET;
}

public
string getRABLMD(){
	return RABLMD;
}

public
string getRASEAL(){
	return RASEAL;
}

public
string getRACPRO(){
	return RACPRO;
}

} // class
} // package