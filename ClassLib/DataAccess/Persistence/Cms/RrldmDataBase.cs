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
class RrldmDataBase : GenericDataBaseElement {

private decimal BJ0KEYN;
private string BJ0REL;
private DateTime BJ0RDAT;
private decimal BJ0HHMM;
private DateTime BJ0TDAT;
private decimal BJ0QCUM;
private decimal BJ0QNET;
private decimal BJ0ADJN;
private string BJ0AUTC;
private string BJ0TIMC;
private string BJ0ATYP;
private string BJ0RAN;
private string BJ0USR1;
private string BJ0USR2;
private string BJ0USR3;
private string BJ0USR4;
private string BJ0FUT1;
private string BJ0FUT2;
private string BJ0FUT3;
private string BJ0FUT4;
private string BJ0FUT5;
private string BJ0FUT6;
private string BJ0FLG1;
private string BJ0FLG2;
private string BJ0FLG3;
private string BJ0FLG4;
private string BJ0FLG5;
private string BJ0FUT7;
private string BJ0FUT8;
private string BJ0FUT9;
private string BJ0FUTA;
private string BJ0FUTB;
private string BJ0FUTC;
private string BJ0FUTD;
private string BJ0FUTE;
private string BJ0FUTF;
private string BJ0FUTG;
private string BJ0FUTH;
private string BJ0FUTI;
private string BJ0FUTJ;
private string BJ0FUTK;
private string BJ0USR5;
private string BJ0USRF;
private string BJ0USRG;
private string BJ0USRH;
private string BJ0USRI;
private string BJ0USRJ;
private string BJ0USRK;
private string BJ0USRL;
private string BJ0USRM;
private string BJ0USRN;
private string BJ0TMZN;
private DateTime BJ0CHDT;
private decimal BJ0CHTM;
private DateTime BJ0DTTM;
private string BJ0USID;
private string BJ0ITYP;
private string BJ0OPCD;

public
RrldmDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from "+ getTablePrefix() + "rrldm where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from "+ getTablePrefix() + "rrldm where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.BJ0KEYN = reader.GetDecimal("BJ0KEYN");
	this.BJ0REL = reader.GetString("BJ0REL#");
	this.BJ0RDAT = reader.GetDateTime("BJ0RDAT");
	this.BJ0HHMM = reader.GetDecimal("BJ0HHMM");
	this.BJ0TDAT = reader.GetDateTime("BJ0TDAT");
	this.BJ0QCUM = reader.GetDecimal("BJ0QCUM");
	this.BJ0QNET = reader.GetDecimal("BJ0QNET");
	this.BJ0ADJN = reader.GetDecimal("BJ0ADJN");
	this.BJ0AUTC = reader.GetString("BJ0AUTC");
	this.BJ0TIMC = reader.GetString("BJ0TIMC");
	this.BJ0ATYP = reader.GetString("BJ0ATYP");
	this.BJ0RAN = reader.GetString("BJ0RAN#");
	this.BJ0USR1 = reader.GetString("BJ0USR1");
	this.BJ0USR2 = reader.GetString("BJ0USR2");
	this.BJ0USR3 = reader.GetString("BJ0USR3");
	this.BJ0USR4 = reader.GetString("BJ0USR4");
	this.BJ0FUT1 = reader.GetString("BJ0FUT1");
	this.BJ0FUT2 = reader.GetString("BJ0FUT2");
	this.BJ0FUT3 = reader.GetString("BJ0FUT3");
	this.BJ0FUT4 = reader.GetString("BJ0FUT4");
	this.BJ0FUT5 = reader.GetString("BJ0FUT5");
	this.BJ0FUT6 = reader.GetString("BJ0FUT6");
	this.BJ0FLG1 = reader.GetString("BJ0FLG1");
	this.BJ0FLG2 = reader.GetString("BJ0FLG2");
	this.BJ0FLG3 = reader.GetString("BJ0FLG3");
	this.BJ0FLG4 = reader.GetString("BJ0FLG4");
	this.BJ0FLG5 = reader.GetString("BJ0FLG5");
	this.BJ0FUT7 = reader.GetString("BJ0FUT7");
	this.BJ0FUT8 = reader.GetString("BJ0FUT8");
	this.BJ0FUT9 = reader.GetString("BJ0FUT9");
	this.BJ0FUTA = reader.GetString("BJ0FUTA");
	this.BJ0FUTB = reader.GetString("BJ0FUTB");
	this.BJ0FUTC = reader.GetString("BJ0FUTC");
	this.BJ0FUTD = reader.GetString("BJ0FUTD");
	this.BJ0FUTE = reader.GetString("BJ0FUTE");
	this.BJ0FUTF = reader.GetString("BJ0FUTF");
	this.BJ0FUTG = reader.GetString("BJ0FUTG");
	this.BJ0FUTH = reader.GetString("BJ0FUTH");
	this.BJ0FUTI = reader.GetString("BJ0FUTI");
	this.BJ0FUTJ = reader.GetString("BJ0FUTJ");
	this.BJ0FUTK = reader.GetString("BJ0FUTK");
	this.BJ0USR5 = reader.GetString("BJ0USR5");
	this.BJ0USRF = reader.GetString("BJ0USRF");
	this.BJ0USRG = reader.GetString("BJ0USRG");
	this.BJ0USRH = reader.GetString("BJ0USRH");
	this.BJ0USRI = reader.GetString("BJ0USRI");
	this.BJ0USRJ = reader.GetString("BJ0USRJ");
	this.BJ0USRK = reader.GetString("BJ0USRK");
	this.BJ0USRL = reader.GetString("BJ0USRL");
	this.BJ0USRM = reader.GetString("BJ0USRM");
	this.BJ0USRN = reader.GetString("BJ0USRN");
	this.BJ0TMZN = reader.GetString("BJ0TMZN");
	this.BJ0CHDT = reader.GetDateTime("BJ0CHDT");
	this.BJ0CHTM = reader.GetDecimal("BJ0CHTM");
	this.BJ0DTTM = reader.GetDateTime("BJ0DTTM");
	this.BJ0USID = reader.GetString("BJ0USID");
	this.BJ0ITYP = reader.GetString("BJ0ITYP");
	this.BJ0OPCD = reader.GetString("BJ0OPCD");
}

public override
void write(){
	string sql = "insert into "+ getTablePrefix() + "rrldm(" + 
		"BJ0KEYN," +
		"BJ0REL#," +
		"BJ0RDAT," +
		"BJ0HHMM," +
		"BJ0TDAT," +
		"BJ0QCUM," +
		"BJ0QNET," +
		"BJ0ADJN," +
		"BJ0AUTC," +
		"BJ0TIMC," +
		"BJ0ATYP," +
		"BJ0RAN#," +
		"BJ0USR1," +
		"BJ0USR2," +
		"BJ0USR3," +
		"BJ0USR4," +
		"BJ0FUT1," +
		"BJ0FUT2," +
		"BJ0FUT3," +
		"BJ0FUT4," +
		"BJ0FUT5," +
		"BJ0FUT6," +
		"BJ0FLG1," +
		"BJ0FLG2," +
		"BJ0FLG3," +
		"BJ0FLG4," +
		"BJ0FLG5," +
		"BJ0FUT7," +
		"BJ0FUT8," +
		"BJ0FUT9," +
		"BJ0FUTA," +
		"BJ0FUTB," +
		"BJ0FUTC," +
		"BJ0FUTD," +
		"BJ0FUTE," +
		"BJ0FUTF," +
		"BJ0FUTG," +
		"BJ0FUTH," +
		"BJ0FUTI," +
		"BJ0FUTJ," +
		"BJ0FUTK," +
		"BJ0USR5," +
		"BJ0USRF," +
		"BJ0USRG," +
		"BJ0USRH," +
		"BJ0USRI," +
		"BJ0USRJ," +
		"BJ0USRK," +
		"BJ0USRL," +
		"BJ0USRM," +
		"BJ0USRN," +
		"BJ0TMZN," +
		"BJ0CHDT," +
		"BJ0CHTM," +
		"BJ0DTTM," +
		"BJ0USID," +
		"BJ0ITYP," +
		"BJ0OPCD" +

		") values (" + 

		"" + NumberUtil.toString(BJ0KEYN) + "," +
		"'" + Converter.fixString(BJ0REL) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(BJ0RDAT) + "'," +
		"" + NumberUtil.toString(BJ0HHMM) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(BJ0TDAT) + "'," +
		"" + NumberUtil.toString(BJ0QCUM) + "," +
		"" + NumberUtil.toString(BJ0QNET) + "," +
		"" + NumberUtil.toString(BJ0ADJN) + "," +
		"'" + Converter.fixString(BJ0AUTC) + "'," +
		"'" + Converter.fixString(BJ0TIMC) + "'," +
		"'" + Converter.fixString(BJ0ATYP) + "'," +
		"'" + Converter.fixString(BJ0RAN) + "'," +
		"'" + Converter.fixString(BJ0USR1) + "'," +
		"'" + Converter.fixString(BJ0USR2) + "'," +
		"'" + Converter.fixString(BJ0USR3) + "'," +
		"'" + Converter.fixString(BJ0USR4) + "'," +
		"'" + Converter.fixString(BJ0FUT1) + "'," +
		"'" + Converter.fixString(BJ0FUT2) + "'," +
		"'" + Converter.fixString(BJ0FUT3) + "'," +
		"'" + Converter.fixString(BJ0FUT4) + "'," +
		"'" + Converter.fixString(BJ0FUT5) + "'," +
		"'" + Converter.fixString(BJ0FUT6) + "'," +
		"'" + Converter.fixString(BJ0FLG1) + "'," +
		"'" + Converter.fixString(BJ0FLG2) + "'," +
		"'" + Converter.fixString(BJ0FLG3) + "'," +
		"'" + Converter.fixString(BJ0FLG4) + "'," +
		"'" + Converter.fixString(BJ0FLG5) + "'," +
		"'" + Converter.fixString(BJ0FUT7) + "'," +
		"'" + Converter.fixString(BJ0FUT8) + "'," +
		"'" + Converter.fixString(BJ0FUT9) + "'," +
		"'" + Converter.fixString(BJ0FUTA) + "'," +
		"'" + Converter.fixString(BJ0FUTB) + "'," +
		"'" + Converter.fixString(BJ0FUTC) + "'," +
		"'" + Converter.fixString(BJ0FUTD) + "'," +
		"'" + Converter.fixString(BJ0FUTE) + "'," +
		"'" + Converter.fixString(BJ0FUTF) + "'," +
		"'" + Converter.fixString(BJ0FUTG) + "'," +
		"'" + Converter.fixString(BJ0FUTH) + "'," +
		"'" + Converter.fixString(BJ0FUTI) + "'," +
		"'" + Converter.fixString(BJ0FUTJ) + "'," +
		"'" + Converter.fixString(BJ0FUTK) + "'," +
		"'" + Converter.fixString(BJ0USR5) + "'," +
		"'" + Converter.fixString(BJ0USRF) + "'," +
		"'" + Converter.fixString(BJ0USRG) + "'," +
		"'" + Converter.fixString(BJ0USRH) + "'," +
		"'" + Converter.fixString(BJ0USRI) + "'," +
		"'" + Converter.fixString(BJ0USRJ) + "'," +
		"'" + Converter.fixString(BJ0USRK) + "'," +
		"'" + Converter.fixString(BJ0USRL) + "'," +
		"'" + Converter.fixString(BJ0USRM) + "'," +
		"'" + Converter.fixString(BJ0USRN) + "'," +
		"'" + Converter.fixString(BJ0TMZN) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(BJ0CHDT) + "'," +
		"" + NumberUtil.toString(BJ0CHTM) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(BJ0DTTM) + "'," +
		"'" + Converter.fixString(BJ0USID) + "'," +
		"'" + Converter.fixString(BJ0ITYP) + "'," +
		"'" + Converter.fixString(BJ0OPCD) + "')";
	write(sql);	
}

public override
void update(){
	string sql = "update "+ getTablePrefix() + "rrldm set " +
		"BJ0KEYN = " + NumberUtil.toString(BJ0KEYN) + ", " +
		"BJ0REL# = '" + Converter.fixString(BJ0REL) + "', " +
		"BJ0RDAT = '" + DateUtil.getCompleteDateRepresentation(BJ0RDAT) + "', " +
		"BJ0HHMM = " + NumberUtil.toString(BJ0HHMM) + ", " +
		"BJ0TDAT = '" + DateUtil.getCompleteDateRepresentation(BJ0TDAT) + "', " +
		"BJ0QCUM = " + NumberUtil.toString(BJ0QCUM) + ", " +
		"BJ0QNET = " + NumberUtil.toString(BJ0QNET) + ", " +
		"BJ0ADJN = " + NumberUtil.toString(BJ0ADJN) + ", " +
		"BJ0AUTC = '" + Converter.fixString(BJ0AUTC) + "', " +
		"BJ0TIMC = '" + Converter.fixString(BJ0TIMC) + "', " +
		"BJ0ATYP = '" + Converter.fixString(BJ0ATYP) + "', " +
		"BJ0RAN# = '" + Converter.fixString(BJ0RAN) + "', " +
		"BJ0USR1 = '" + Converter.fixString(BJ0USR1) + "', " +
		"BJ0USR2 = '" + Converter.fixString(BJ0USR2) + "', " +
		"BJ0USR3 = '" + Converter.fixString(BJ0USR3) + "', " +
		"BJ0USR4 = '" + Converter.fixString(BJ0USR4) + "', " +
		"BJ0FUT1 = '" + Converter.fixString(BJ0FUT1) + "', " +
		"BJ0FUT2 = '" + Converter.fixString(BJ0FUT2) + "', " +
		"BJ0FUT3 = '" + Converter.fixString(BJ0FUT3) + "', " +
		"BJ0FUT4 = '" + Converter.fixString(BJ0FUT4) + "', " +
		"BJ0FUT5 = '" + Converter.fixString(BJ0FUT5) + "', " +
		"BJ0FUT6 = '" + Converter.fixString(BJ0FUT6) + "', " +
		"BJ0FLG1 = '" + Converter.fixString(BJ0FLG1) + "', " +
		"BJ0FLG2 = '" + Converter.fixString(BJ0FLG2) + "', " +
		"BJ0FLG3 = '" + Converter.fixString(BJ0FLG3) + "', " +
		"BJ0FLG4 = '" + Converter.fixString(BJ0FLG4) + "', " +
		"BJ0FLG5 = '" + Converter.fixString(BJ0FLG5) + "', " +
		"BJ0FUT7 = '" + Converter.fixString(BJ0FUT7) + "', " +
		"BJ0FUT8 = '" + Converter.fixString(BJ0FUT8) + "', " +
		"BJ0FUT9 = '" + Converter.fixString(BJ0FUT9) + "', " +
		"BJ0FUTA = '" + Converter.fixString(BJ0FUTA) + "', " +
		"BJ0FUTB = '" + Converter.fixString(BJ0FUTB) + "', " +
		"BJ0FUTC = '" + Converter.fixString(BJ0FUTC) + "', " +
		"BJ0FUTD = '" + Converter.fixString(BJ0FUTD) + "', " +
		"BJ0FUTE = '" + Converter.fixString(BJ0FUTE) + "', " +
		"BJ0FUTF = '" + Converter.fixString(BJ0FUTF) + "', " +
		"BJ0FUTG = '" + Converter.fixString(BJ0FUTG) + "', " +
		"BJ0FUTH = '" + Converter.fixString(BJ0FUTH) + "', " +
		"BJ0FUTI = '" + Converter.fixString(BJ0FUTI) + "', " +
		"BJ0FUTJ = '" + Converter.fixString(BJ0FUTJ) + "', " +
		"BJ0FUTK = '" + Converter.fixString(BJ0FUTK) + "', " +
		"BJ0USR5 = '" + Converter.fixString(BJ0USR5) + "', " +
		"BJ0USRF = '" + Converter.fixString(BJ0USRF) + "', " +
		"BJ0USRG = '" + Converter.fixString(BJ0USRG) + "', " +
		"BJ0USRH = '" + Converter.fixString(BJ0USRH) + "', " +
		"BJ0USRI = '" + Converter.fixString(BJ0USRI) + "', " +
		"BJ0USRJ = '" + Converter.fixString(BJ0USRJ) + "', " +
		"BJ0USRK = '" + Converter.fixString(BJ0USRK) + "', " +
		"BJ0USRL = '" + Converter.fixString(BJ0USRL) + "', " +
		"BJ0USRM = '" + Converter.fixString(BJ0USRM) + "', " +
		"BJ0USRN = '" + Converter.fixString(BJ0USRN) + "', " +
		"BJ0TMZN = '" + Converter.fixString(BJ0TMZN) + "', " +
		"BJ0CHDT = '" + DateUtil.getCompleteDateRepresentation(BJ0CHDT) + "', " +
		"BJ0CHTM = " + NumberUtil.toString(BJ0CHTM) + ", " +
		"BJ0DTTM = '" + DateUtil.getCompleteDateRepresentation(BJ0DTTM) + "', " +
		"BJ0USID = '" + Converter.fixString(BJ0USID) + "', " +
		"BJ0ITYP = '" + Converter.fixString(BJ0ITYP) + "', " +
		"BJ0OPCD = '" + Converter.fixString(BJ0OPCD) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from rrldm where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"BJ0KEYN = " + NumberUtil.toString(BJ0KEYN) + " and " +
		"BJ0REL# = '" + Converter.fixString(BJ0REL) + "' and " +
		"BJ0CHDT = '" + DateUtil.getCompleteDateRepresentation(BJ0CHDT) + "' and " +
		"BJ0CHTM = " + NumberUtil.toString(BJ0CHTM) + " and " +
		"BJ0DTTM = '" + DateUtil.getCompleteDateRepresentation(BJ0DTTM) + "'";
	return sqlWhere;
}

public
void setBJ0KEYN(decimal BJ0KEYN){
	this.BJ0KEYN = BJ0KEYN;
}

public
void setBJ0REL(string BJ0REL){
	this.BJ0REL = BJ0REL;
}

public
void setBJ0RDAT(DateTime BJ0RDAT){
	this.BJ0RDAT = BJ0RDAT;
}

public
void setBJ0HHMM(decimal BJ0HHMM){
	this.BJ0HHMM = BJ0HHMM;
}

public
void setBJ0TDAT(DateTime BJ0TDAT){
	this.BJ0TDAT = BJ0TDAT;
}

public
void setBJ0QCUM(decimal BJ0QCUM){
	this.BJ0QCUM = BJ0QCUM;
}

public
void setBJ0QNET(decimal BJ0QNET){
	this.BJ0QNET = BJ0QNET;
}

public
void setBJ0ADJN(decimal BJ0ADJN){
	this.BJ0ADJN = BJ0ADJN;
}

public
void setBJ0AUTC(string BJ0AUTC){
	this.BJ0AUTC = BJ0AUTC;
}

public
void setBJ0TIMC(string BJ0TIMC){
	this.BJ0TIMC = BJ0TIMC;
}

public
void setBJ0ATYP(string BJ0ATYP){
	this.BJ0ATYP = BJ0ATYP;
}

public
void setBJ0RAN(string BJ0RAN){
	this.BJ0RAN = BJ0RAN;
}

public
void setBJ0USR1(string BJ0USR1){
	this.BJ0USR1 = BJ0USR1;
}

public
void setBJ0USR2(string BJ0USR2){
	this.BJ0USR2 = BJ0USR2;
}

public
void setBJ0USR3(string BJ0USR3){
	this.BJ0USR3 = BJ0USR3;
}

public
void setBJ0USR4(string BJ0USR4){
	this.BJ0USR4 = BJ0USR4;
}

public
void setBJ0FUT1(string BJ0FUT1){
	this.BJ0FUT1 = BJ0FUT1;
}

public
void setBJ0FUT2(string BJ0FUT2){
	this.BJ0FUT2 = BJ0FUT2;
}

public
void setBJ0FUT3(string BJ0FUT3){
	this.BJ0FUT3 = BJ0FUT3;
}

public
void setBJ0FUT4(string BJ0FUT4){
	this.BJ0FUT4 = BJ0FUT4;
}

public
void setBJ0FUT5(string BJ0FUT5){
	this.BJ0FUT5 = BJ0FUT5;
}

public
void setBJ0FUT6(string BJ0FUT6){
	this.BJ0FUT6 = BJ0FUT6;
}

public
void setBJ0FLG1(string BJ0FLG1){
	this.BJ0FLG1 = BJ0FLG1;
}

public
void setBJ0FLG2(string BJ0FLG2){
	this.BJ0FLG2 = BJ0FLG2;
}

public
void setBJ0FLG3(string BJ0FLG3){
	this.BJ0FLG3 = BJ0FLG3;
}

public
void setBJ0FLG4(string BJ0FLG4){
	this.BJ0FLG4 = BJ0FLG4;
}

public
void setBJ0FLG5(string BJ0FLG5){
	this.BJ0FLG5 = BJ0FLG5;
}

public
void setBJ0FUT7(string BJ0FUT7){
	this.BJ0FUT7 = BJ0FUT7;
}

public
void setBJ0FUT8(string BJ0FUT8){
	this.BJ0FUT8 = BJ0FUT8;
}

public
void setBJ0FUT9(string BJ0FUT9){
	this.BJ0FUT9 = BJ0FUT9;
}

public
void setBJ0FUTA(string BJ0FUTA){
	this.BJ0FUTA = BJ0FUTA;
}

public
void setBJ0FUTB(string BJ0FUTB){
	this.BJ0FUTB = BJ0FUTB;
}

public
void setBJ0FUTC(string BJ0FUTC){
	this.BJ0FUTC = BJ0FUTC;
}

public
void setBJ0FUTD(string BJ0FUTD){
	this.BJ0FUTD = BJ0FUTD;
}

public
void setBJ0FUTE(string BJ0FUTE){
	this.BJ0FUTE = BJ0FUTE;
}

public
void setBJ0FUTF(string BJ0FUTF){
	this.BJ0FUTF = BJ0FUTF;
}

public
void setBJ0FUTG(string BJ0FUTG){
	this.BJ0FUTG = BJ0FUTG;
}

public
void setBJ0FUTH(string BJ0FUTH){
	this.BJ0FUTH = BJ0FUTH;
}

public
void setBJ0FUTI(string BJ0FUTI){
	this.BJ0FUTI = BJ0FUTI;
}

public
void setBJ0FUTJ(string BJ0FUTJ){
	this.BJ0FUTJ = BJ0FUTJ;
}

public
void setBJ0FUTK(string BJ0FUTK){
	this.BJ0FUTK = BJ0FUTK;
}

public
void setBJ0USR5(string BJ0USR5){
	this.BJ0USR5 = BJ0USR5;
}

public
void setBJ0USRF(string BJ0USRF){
	this.BJ0USRF = BJ0USRF;
}

public
void setBJ0USRG(string BJ0USRG){
	this.BJ0USRG = BJ0USRG;
}

public
void setBJ0USRH(string BJ0USRH){
	this.BJ0USRH = BJ0USRH;
}

public
void setBJ0USRI(string BJ0USRI){
	this.BJ0USRI = BJ0USRI;
}

public
void setBJ0USRJ(string BJ0USRJ){
	this.BJ0USRJ = BJ0USRJ;
}

public
void setBJ0USRK(string BJ0USRK){
	this.BJ0USRK = BJ0USRK;
}

public
void setBJ0USRL(string BJ0USRL){
	this.BJ0USRL = BJ0USRL;
}

public
void setBJ0USRM(string BJ0USRM){
	this.BJ0USRM = BJ0USRM;
}

public
void setBJ0USRN(string BJ0USRN){
	this.BJ0USRN = BJ0USRN;
}

public
void setBJ0TMZN(string BJ0TMZN){
	this.BJ0TMZN = BJ0TMZN;
}

public
void setBJ0CHDT(DateTime BJ0CHDT){
	this.BJ0CHDT = BJ0CHDT;
}

public
void setBJ0CHTM(decimal BJ0CHTM){
	this.BJ0CHTM = BJ0CHTM;
}

public
void setBJ0DTTM(DateTime BJ0DTTM){
	this.BJ0DTTM = BJ0DTTM;
}

public
void setBJ0USID(string BJ0USID){
	this.BJ0USID = BJ0USID;
}

public
void setBJ0ITYP(string BJ0ITYP){
	this.BJ0ITYP = BJ0ITYP;
}

public
void setBJ0OPCD(string BJ0OPCD){
	this.BJ0OPCD = BJ0OPCD;
}

public
decimal getBJ0KEYN(){
	return BJ0KEYN;
}

public
string getBJ0REL(){
	return BJ0REL;
}

public
DateTime getBJ0RDAT(){
	return BJ0RDAT;
}

public
decimal getBJ0HHMM(){
	return BJ0HHMM;
}

public
DateTime getBJ0TDAT(){
	return BJ0TDAT;
}

public
decimal getBJ0QCUM(){
	return BJ0QCUM;
}

public
decimal getBJ0QNET(){
	return BJ0QNET;
}

public
decimal getBJ0ADJN(){
	return BJ0ADJN;
}

public
string getBJ0AUTC(){
	return BJ0AUTC;
}

public
string getBJ0TIMC(){
	return BJ0TIMC;
}

public
string getBJ0ATYP(){
	return BJ0ATYP;
}

public
string getBJ0RAN(){
	return BJ0RAN;
}

public
string getBJ0USR1(){
	return BJ0USR1;
}

public
string getBJ0USR2(){
	return BJ0USR2;
}

public
string getBJ0USR3(){
	return BJ0USR3;
}

public
string getBJ0USR4(){
	return BJ0USR4;
}

public
string getBJ0FUT1(){
	return BJ0FUT1;
}

public
string getBJ0FUT2(){
	return BJ0FUT2;
}

public
string getBJ0FUT3(){
	return BJ0FUT3;
}

public
string getBJ0FUT4(){
	return BJ0FUT4;
}

public
string getBJ0FUT5(){
	return BJ0FUT5;
}

public
string getBJ0FUT6(){
	return BJ0FUT6;
}

public
string getBJ0FLG1(){
	return BJ0FLG1;
}

public
string getBJ0FLG2(){
	return BJ0FLG2;
}

public
string getBJ0FLG3(){
	return BJ0FLG3;
}

public
string getBJ0FLG4(){
	return BJ0FLG4;
}

public
string getBJ0FLG5(){
	return BJ0FLG5;
}

public
string getBJ0FUT7(){
	return BJ0FUT7;
}

public
string getBJ0FUT8(){
	return BJ0FUT8;
}

public
string getBJ0FUT9(){
	return BJ0FUT9;
}

public
string getBJ0FUTA(){
	return BJ0FUTA;
}

public
string getBJ0FUTB(){
	return BJ0FUTB;
}

public
string getBJ0FUTC(){
	return BJ0FUTC;
}

public
string getBJ0FUTD(){
	return BJ0FUTD;
}

public
string getBJ0FUTE(){
	return BJ0FUTE;
}

public
string getBJ0FUTF(){
	return BJ0FUTF;
}

public
string getBJ0FUTG(){
	return BJ0FUTG;
}

public
string getBJ0FUTH(){
	return BJ0FUTH;
}

public
string getBJ0FUTI(){
	return BJ0FUTI;
}

public
string getBJ0FUTJ(){
	return BJ0FUTJ;
}

public
string getBJ0FUTK(){
	return BJ0FUTK;
}

public
string getBJ0USR5(){
	return BJ0USR5;
}

public
string getBJ0USRF(){
	return BJ0USRF;
}

public
string getBJ0USRG(){
	return BJ0USRG;
}

public
string getBJ0USRH(){
	return BJ0USRH;
}

public
string getBJ0USRI(){
	return BJ0USRI;
}

public
string getBJ0USRJ(){
	return BJ0USRJ;
}

public
string getBJ0USRK(){
	return BJ0USRK;
}

public
string getBJ0USRL(){
	return BJ0USRL;
}

public
string getBJ0USRM(){
	return BJ0USRM;
}

public
string getBJ0USRN(){
	return BJ0USRN;
}

public
string getBJ0TMZN(){
	return BJ0TMZN;
}

public
DateTime getBJ0CHDT(){
	return BJ0CHDT;
}

public
decimal getBJ0CHTM(){
	return BJ0CHTM;
}

public
DateTime getBJ0DTTM(){
	return BJ0DTTM;
}

public
string getBJ0USID(){
	return BJ0USID;
}

public
string getBJ0ITYP(){
	return BJ0ITYP;
}

public
string getBJ0OPCD(){
	return BJ0OPCD;
}

} // class
} // package