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
class JitdmDataBase : GenericDataBaseElement {

private decimal BJ1KEYN;
private string BJ1REF;
private DateTime BJ1DATE;
private decimal BJ1HM;
private DateTime BJ1EDAT;
private decimal BJ1QTY;
private decimal BJ1QCUM;
private decimal BJ1NQTY;
private string BJ1SRC;
private decimal BJ1LOG;
private decimal BJ1ENT;
private decimal BJ1BOL;
private decimal BJ1BLIN;
private string BJ1RAN;
private string BJ1REF1;
private string BJ1REF2;
private string BJ1STAT;
private decimal BJ1KEY;
private string BJ1KBPR;
private string BJ1KBST;
private string BJ1KBEN;
private string BJ1SHPP;
private string BJ1SHPT;
private string BJ1TYPE;
private string BJ1TIMT;
private string BJ1TIMC;
private string BJ1RTEG;
private string BJ1SVCC;
private string BJ1MODE;
private string BJ1USR1;
private string BJ1USR2;
private string BJ1USR3;
private string BJ1USR4;
private string BJ1FUT1;
private string BJ1FUT2;
private string BJ1FUT3;
private string BJ1FUT4;
private string BJ1FUT5;
private string BJ1FUT6;
private string BJ1FUT7;
private string BJ1FUT8;
private string BJ1FUTA;
private string BJ1FUTB;
private string BJ1FUTC;
private string BJ1FUTD;
private string BJ1FUTE;
private string BJ1FUTF;
private string BJ1FUTG;
private string BJ1FUTH;
private string BJ1FUTI;
private string BJ1FUTJ;
private string BJ1FUTK;
private string BJ1FUTL;
private string BJ1FUTM;
private string BJ1FUTN;
private string BJ1FUTO;
private string BJ1FUTP;
private string BJ1FUTQ;
private string BJ1FUTR;
private string BJ1FUTS;
private string BJ1FUTT;
private string BJ1FUTU;
private string BJ1FLG1;
private string BJ1FLG2;
private string BJ1FLG3;
private string BJ1FLG4;
private string BJ1JITS;
private string BJ1TMZN;
private DateTime BJ1CHDT;
private decimal BJ1CHTM;
private DateTime BJ1DTTM;
private string BJ1USID;
private string BJ1ITYP;
private string BJ1OPCD;

public
JitdmDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from jitdm where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from jitdm where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.BJ1KEYN = reader.GetDecimal("BJ1KEYN");
	this.BJ1REF = reader.GetString("BJ1REF#");
	this.BJ1DATE = reader.GetDateTime("BJ1DATE");
	this.BJ1HM = reader.GetDecimal("BJ1HM");
	this.BJ1EDAT = reader.GetDateTime("BJ1EDAT");
	this.BJ1QTY = reader.GetDecimal("BJ1QTY");
	this.BJ1QCUM = reader.GetDecimal("BJ1QCUM");
	this.BJ1NQTY = reader.GetDecimal("BJ1NQTY");
	this.BJ1SRC = reader.GetString("BJ1SRC");
	this.BJ1LOG = reader.GetDecimal("BJ1LOG#");
	this.BJ1ENT = reader.GetDecimal("BJ1ENT#");
	this.BJ1BOL = reader.GetDecimal("BJ1BOL#");
	this.BJ1BLIN = reader.GetDecimal("BJ1BLIN");
	this.BJ1RAN = reader.GetString("BJ1RAN");
	this.BJ1REF1 = reader.GetString("BJ1REF1");
	this.BJ1REF2 = reader.GetString("BJ1REF2");
	this.BJ1STAT = reader.GetString("BJ1STAT");
	this.BJ1KEY = reader.GetDecimal("BJ1KEY#");
	this.BJ1KBPR = reader.GetString("BJ1KBPR");
	this.BJ1KBST = reader.GetString("BJ1KBST");
	this.BJ1KBEN = reader.GetString("BJ1KBEN");
	this.BJ1SHPP = reader.GetString("BJ1SHPP");
	this.BJ1SHPT = reader.GetString("BJ1SHPT");
	this.BJ1TYPE = reader.GetString("BJ1TYPE");
	this.BJ1TIMT = reader.GetString("BJ1TIMT");
	this.BJ1TIMC = reader.GetString("BJ1TIMC");
	this.BJ1RTEG = reader.GetString("BJ1RTEG");
	this.BJ1SVCC = reader.GetString("BJ1SVCC");
	this.BJ1MODE = reader.GetString("BJ1MODE");
	this.BJ1USR1 = reader.GetString("BJ1USR1");
	this.BJ1USR2 = reader.GetString("BJ1USR2");
	this.BJ1USR3 = reader.GetString("BJ1USR3");
	this.BJ1USR4 = reader.GetString("BJ1USR4");
	this.BJ1FUT1 = reader.GetString("BJ1FUT1");
	this.BJ1FUT2 = reader.GetString("BJ1FUT2");
	this.BJ1FUT3 = reader.GetString("BJ1FUT3");
	this.BJ1FUT4 = reader.GetString("BJ1FUT4");
	this.BJ1FUT5 = reader.GetString("BJ1FUT5");
	this.BJ1FUT6 = reader.GetString("BJ1FUT6");
	this.BJ1FUT7 = reader.GetString("BJ1FUT7");
	this.BJ1FUT8 = reader.GetString("BJ1FUT8");
	this.BJ1FUTA = reader.GetString("BJ1FUTA");
	this.BJ1FUTB = reader.GetString("BJ1FUTB");
	this.BJ1FUTC = reader.GetString("BJ1FUTC");
	this.BJ1FUTD = reader.GetString("BJ1FUTD");
	this.BJ1FUTE = reader.GetString("BJ1FUTE");
	this.BJ1FUTF = reader.GetString("BJ1FUTF");
	this.BJ1FUTG = reader.GetString("BJ1FUTG");
	this.BJ1FUTH = reader.GetString("BJ1FUTH");
	this.BJ1FUTI = reader.GetString("BJ1FUTI");
	this.BJ1FUTJ = reader.GetString("BJ1FUTJ");
	this.BJ1FUTK = reader.GetString("BJ1FUTK");
	this.BJ1FUTL = reader.GetString("BJ1FUTL");
	this.BJ1FUTM = reader.GetString("BJ1FUTM");
	this.BJ1FUTN = reader.GetString("BJ1FUTN");
	this.BJ1FUTO = reader.GetString("BJ1FUTO");
	this.BJ1FUTP = reader.GetString("BJ1FUTP");
	this.BJ1FUTQ = reader.GetString("BJ1FUTQ");
	this.BJ1FUTR = reader.GetString("BJ1FUTR");
	this.BJ1FUTS = reader.GetString("BJ1FUTS");
	this.BJ1FUTT = reader.GetString("BJ1FUTT");
	this.BJ1FUTU = reader.GetString("BJ1FUTU");
	this.BJ1FLG1 = reader.GetString("BJ1FLG1");
	this.BJ1FLG2 = reader.GetString("BJ1FLG2");
	this.BJ1FLG3 = reader.GetString("BJ1FLG3");
	this.BJ1FLG4 = reader.GetString("BJ1FLG4");
	this.BJ1JITS = reader.GetString("BJ1JITS");
	this.BJ1TMZN = reader.GetString("BJ1TMZN");
	this.BJ1CHDT = reader.GetDateTime("BJ1CHDT");
	this.BJ1CHTM = reader.GetDecimal("BJ1CHTM");
	this.BJ1DTTM = reader.GetDateTime("BJ1DTTM");
	this.BJ1USID = reader.GetString("BJ1USID");
	this.BJ1ITYP = reader.GetString("BJ1ITYP");
	this.BJ1OPCD = reader.GetString("BJ1OPCD");
}

public override
void write(){
	string sql = "insert into jitdm(" + 
		"BJ1KEYN," +
		"BJ1REF#," +
		"BJ1DATE," +
		"BJ1HM," +
		"BJ1EDAT," +
		"BJ1QTY," +
		"BJ1QCUM," +
		"BJ1NQTY," +
		"BJ1SRC," +
		"BJ1LOG#," +
		"BJ1ENT#," +
		"BJ1BOL#," +
		"BJ1BLIN," +
		"BJ1RAN," +
		"BJ1REF1," +
		"BJ1REF2," +
		"BJ1STAT," +
		"BJ1KEY#," +
		"BJ1KBPR," +
		"BJ1KBST," +
		"BJ1KBEN," +
		"BJ1SHPP," +
		"BJ1SHPT," +
		"BJ1TYPE," +
		"BJ1TIMT," +
		"BJ1TIMC," +
		"BJ1RTEG," +
		"BJ1SVCC," +
		"BJ1MODE," +
		"BJ1USR1," +
		"BJ1USR2," +
		"BJ1USR3," +
		"BJ1USR4," +
		"BJ1FUT1," +
		"BJ1FUT2," +
		"BJ1FUT3," +
		"BJ1FUT4," +
		"BJ1FUT5," +
		"BJ1FUT6," +
		"BJ1FUT7," +
		"BJ1FUT8," +
		"BJ1FUTA," +
		"BJ1FUTB," +
		"BJ1FUTC," +
		"BJ1FUTD," +
		"BJ1FUTE," +
		"BJ1FUTF," +
		"BJ1FUTG," +
		"BJ1FUTH," +
		"BJ1FUTI," +
		"BJ1FUTJ," +
		"BJ1FUTK," +
		"BJ1FUTL," +
		"BJ1FUTM," +
		"BJ1FUTN," +
		"BJ1FUTO," +
		"BJ1FUTP," +
		"BJ1FUTQ," +
		"BJ1FUTR," +
		"BJ1FUTS," +
		"BJ1FUTT," +
		"BJ1FUTU," +
		"BJ1FLG1," +
		"BJ1FLG2," +
		"BJ1FLG3," +
		"BJ1FLG4," +
		"BJ1JITS," +
		"BJ1TMZN," +
		"BJ1CHDT," +
		"BJ1CHTM," +
		"BJ1DTTM," +
		"BJ1USID," +
		"BJ1ITYP," +
		"BJ1OPCD" +

		") values (" + 

		"" + NumberUtil.toString(BJ1KEYN) + "," +
		"'" + Converter.fixString(BJ1REF) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(BJ1DATE) + "'," +
		"" + NumberUtil.toString(BJ1HM) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(BJ1EDAT) + "'," +
		"" + NumberUtil.toString(BJ1QTY) + "," +
		"" + NumberUtil.toString(BJ1QCUM) + "," +
		"" + NumberUtil.toString(BJ1NQTY) + "," +
		"'" + Converter.fixString(BJ1SRC) + "'," +
		"" + NumberUtil.toString(BJ1LOG) + "," +
		"" + NumberUtil.toString(BJ1ENT) + "," +
		"" + NumberUtil.toString(BJ1BOL) + "," +
		"" + NumberUtil.toString(BJ1BLIN) + "," +
		"'" + Converter.fixString(BJ1RAN) + "'," +
		"'" + Converter.fixString(BJ1REF1) + "'," +
		"'" + Converter.fixString(BJ1REF2) + "'," +
		"'" + Converter.fixString(BJ1STAT) + "'," +
		"" + NumberUtil.toString(BJ1KEY) + "," +
		"'" + Converter.fixString(BJ1KBPR) + "'," +
		"'" + Converter.fixString(BJ1KBST) + "'," +
		"'" + Converter.fixString(BJ1KBEN) + "'," +
		"'" + Converter.fixString(BJ1SHPP) + "'," +
		"'" + Converter.fixString(BJ1SHPT) + "'," +
		"'" + Converter.fixString(BJ1TYPE) + "'," +
		"'" + Converter.fixString(BJ1TIMT) + "'," +
		"'" + Converter.fixString(BJ1TIMC) + "'," +
		"'" + Converter.fixString(BJ1RTEG) + "'," +
		"'" + Converter.fixString(BJ1SVCC) + "'," +
		"'" + Converter.fixString(BJ1MODE) + "'," +
		"'" + Converter.fixString(BJ1USR1) + "'," +
		"'" + Converter.fixString(BJ1USR2) + "'," +
		"'" + Converter.fixString(BJ1USR3) + "'," +
		"'" + Converter.fixString(BJ1USR4) + "'," +
		"'" + Converter.fixString(BJ1FUT1) + "'," +
		"'" + Converter.fixString(BJ1FUT2) + "'," +
		"'" + Converter.fixString(BJ1FUT3) + "'," +
		"'" + Converter.fixString(BJ1FUT4) + "'," +
		"'" + Converter.fixString(BJ1FUT5) + "'," +
		"'" + Converter.fixString(BJ1FUT6) + "'," +
		"'" + Converter.fixString(BJ1FUT7) + "'," +
		"'" + Converter.fixString(BJ1FUT8) + "'," +
		"'" + Converter.fixString(BJ1FUTA) + "'," +
		"'" + Converter.fixString(BJ1FUTB) + "'," +
		"'" + Converter.fixString(BJ1FUTC) + "'," +
		"'" + Converter.fixString(BJ1FUTD) + "'," +
		"'" + Converter.fixString(BJ1FUTE) + "'," +
		"'" + Converter.fixString(BJ1FUTF) + "'," +
		"'" + Converter.fixString(BJ1FUTG) + "'," +
		"'" + Converter.fixString(BJ1FUTH) + "'," +
		"'" + Converter.fixString(BJ1FUTI) + "'," +
		"'" + Converter.fixString(BJ1FUTJ) + "'," +
		"'" + Converter.fixString(BJ1FUTK) + "'," +
		"'" + Converter.fixString(BJ1FUTL) + "'," +
		"'" + Converter.fixString(BJ1FUTM) + "'," +
		"'" + Converter.fixString(BJ1FUTN) + "'," +
		"'" + Converter.fixString(BJ1FUTO) + "'," +
		"'" + Converter.fixString(BJ1FUTP) + "'," +
		"'" + Converter.fixString(BJ1FUTQ) + "'," +
		"'" + Converter.fixString(BJ1FUTR) + "'," +
		"'" + Converter.fixString(BJ1FUTS) + "'," +
		"'" + Converter.fixString(BJ1FUTT) + "'," +
		"'" + Converter.fixString(BJ1FUTU) + "'," +
		"'" + Converter.fixString(BJ1FLG1) + "'," +
		"'" + Converter.fixString(BJ1FLG2) + "'," +
		"'" + Converter.fixString(BJ1FLG3) + "'," +
		"'" + Converter.fixString(BJ1FLG4) + "'," +
		"'" + Converter.fixString(BJ1JITS) + "'," +
		"'" + Converter.fixString(BJ1TMZN) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(BJ1CHDT) + "'," +
		"" + NumberUtil.toString(BJ1CHTM) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(BJ1DTTM) + "'," +
		"'" + Converter.fixString(BJ1USID) + "'," +
		"'" + Converter.fixString(BJ1ITYP) + "'," +
		"'" + Converter.fixString(BJ1OPCD) + "')";
	write(sql);	
}

public override
void update(){
	string sql = "update jitdm set " +
		"BJ1KEYN = " + NumberUtil.toString(BJ1KEYN) + ", " +
		"BJ1REF# = '" + Converter.fixString(BJ1REF) + "', " +
		"BJ1DATE = '" + DateUtil.getCompleteDateRepresentation(BJ1DATE) + "', " +
		"BJ1HM = " + NumberUtil.toString(BJ1HM) + ", " +
		"BJ1EDAT = '" + DateUtil.getCompleteDateRepresentation(BJ1EDAT) + "', " +
		"BJ1QTY = " + NumberUtil.toString(BJ1QTY) + ", " +
		"BJ1QCUM = " + NumberUtil.toString(BJ1QCUM) + ", " +
		"BJ1NQTY = " + NumberUtil.toString(BJ1NQTY) + ", " +
		"BJ1SRC = '" + Converter.fixString(BJ1SRC) + "', " +
		"BJ1LOG# = " + NumberUtil.toString(BJ1LOG) + ", " +
		"BJ1ENT# = " + NumberUtil.toString(BJ1ENT) + ", " +
		"BJ1BOL# = " + NumberUtil.toString(BJ1BOL) + ", " +
		"BJ1BLIN = " + NumberUtil.toString(BJ1BLIN) + ", " +
		"BJ1RAN = '" + Converter.fixString(BJ1RAN) + "', " +
		"BJ1REF1 = '" + Converter.fixString(BJ1REF1) + "', " +
		"BJ1REF2 = '" + Converter.fixString(BJ1REF2) + "', " +
		"BJ1STAT = '" + Converter.fixString(BJ1STAT) + "', " +
		"BJ1KEY# = " + NumberUtil.toString(BJ1KEY) + ", " +
		"BJ1KBPR = '" + Converter.fixString(BJ1KBPR) + "', " +
		"BJ1KBST = '" + Converter.fixString(BJ1KBST) + "', " +
		"BJ1KBEN = '" + Converter.fixString(BJ1KBEN) + "', " +
		"BJ1SHPP = '" + Converter.fixString(BJ1SHPP) + "', " +
		"BJ1SHPT = '" + Converter.fixString(BJ1SHPT) + "', " +
		"BJ1TYPE = '" + Converter.fixString(BJ1TYPE) + "', " +
		"BJ1TIMT = '" + Converter.fixString(BJ1TIMT) + "', " +
		"BJ1TIMC = '" + Converter.fixString(BJ1TIMC) + "', " +
		"BJ1RTEG = '" + Converter.fixString(BJ1RTEG) + "', " +
		"BJ1SVCC = '" + Converter.fixString(BJ1SVCC) + "', " +
		"BJ1MODE = '" + Converter.fixString(BJ1MODE) + "', " +
		"BJ1USR1 = '" + Converter.fixString(BJ1USR1) + "', " +
		"BJ1USR2 = '" + Converter.fixString(BJ1USR2) + "', " +
		"BJ1USR3 = '" + Converter.fixString(BJ1USR3) + "', " +
		"BJ1USR4 = '" + Converter.fixString(BJ1USR4) + "', " +
		"BJ1FUT1 = '" + Converter.fixString(BJ1FUT1) + "', " +
		"BJ1FUT2 = '" + Converter.fixString(BJ1FUT2) + "', " +
		"BJ1FUT3 = '" + Converter.fixString(BJ1FUT3) + "', " +
		"BJ1FUT4 = '" + Converter.fixString(BJ1FUT4) + "', " +
		"BJ1FUT5 = '" + Converter.fixString(BJ1FUT5) + "', " +
		"BJ1FUT6 = '" + Converter.fixString(BJ1FUT6) + "', " +
		"BJ1FUT7 = '" + Converter.fixString(BJ1FUT7) + "', " +
		"BJ1FUT8 = '" + Converter.fixString(BJ1FUT8) + "', " +
		"BJ1FUTA = '" + Converter.fixString(BJ1FUTA) + "', " +
		"BJ1FUTB = '" + Converter.fixString(BJ1FUTB) + "', " +
		"BJ1FUTC = '" + Converter.fixString(BJ1FUTC) + "', " +
		"BJ1FUTD = '" + Converter.fixString(BJ1FUTD) + "', " +
		"BJ1FUTE = '" + Converter.fixString(BJ1FUTE) + "', " +
		"BJ1FUTF = '" + Converter.fixString(BJ1FUTF) + "', " +
		"BJ1FUTG = '" + Converter.fixString(BJ1FUTG) + "', " +
		"BJ1FUTH = '" + Converter.fixString(BJ1FUTH) + "', " +
		"BJ1FUTI = '" + Converter.fixString(BJ1FUTI) + "', " +
		"BJ1FUTJ = '" + Converter.fixString(BJ1FUTJ) + "', " +
		"BJ1FUTK = '" + Converter.fixString(BJ1FUTK) + "', " +
		"BJ1FUTL = '" + Converter.fixString(BJ1FUTL) + "', " +
		"BJ1FUTM = '" + Converter.fixString(BJ1FUTM) + "', " +
		"BJ1FUTN = '" + Converter.fixString(BJ1FUTN) + "', " +
		"BJ1FUTO = '" + Converter.fixString(BJ1FUTO) + "', " +
		"BJ1FUTP = '" + Converter.fixString(BJ1FUTP) + "', " +
		"BJ1FUTQ = '" + Converter.fixString(BJ1FUTQ) + "', " +
		"BJ1FUTR = '" + Converter.fixString(BJ1FUTR) + "', " +
		"BJ1FUTS = '" + Converter.fixString(BJ1FUTS) + "', " +
		"BJ1FUTT = '" + Converter.fixString(BJ1FUTT) + "', " +
		"BJ1FUTU = '" + Converter.fixString(BJ1FUTU) + "', " +
		"BJ1FLG1 = '" + Converter.fixString(BJ1FLG1) + "', " +
		"BJ1FLG2 = '" + Converter.fixString(BJ1FLG2) + "', " +
		"BJ1FLG3 = '" + Converter.fixString(BJ1FLG3) + "', " +
		"BJ1FLG4 = '" + Converter.fixString(BJ1FLG4) + "', " +
		"BJ1JITS = '" + Converter.fixString(BJ1JITS) + "', " +
		"BJ1TMZN = '" + Converter.fixString(BJ1TMZN) + "', " +
		"BJ1CHDT = '" + DateUtil.getCompleteDateRepresentation(BJ1CHDT) + "', " +
		"BJ1CHTM = " + NumberUtil.toString(BJ1CHTM) + ", " +
		"BJ1DTTM = '" + DateUtil.getCompleteDateRepresentation(BJ1DTTM) + "', " +
		"BJ1USID = '" + Converter.fixString(BJ1USID) + "', " +
		"BJ1ITYP = '" + Converter.fixString(BJ1ITYP) + "', " +
		"BJ1OPCD = '" + Converter.fixString(BJ1OPCD) + "' " +

		"where " + getWhereCondition();
    update(sql);
}

public override
void delete(){
	string sql = "delete from jitdm where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"BJ1KEYN = " + NumberUtil.toString(BJ1KEYN) + " and " +
		"BJ1REF# = '" + Converter.fixString(BJ1REF) + "' and " +
		"BJ1CHDT = '" + DateUtil.getCompleteDateRepresentation(BJ1CHDT) + "' and " +
		"BJ1CHTM = " + NumberUtil.toString(BJ1CHTM) + " and " +
		"BJ1DTTM = '" + DateUtil.getCompleteDateRepresentation(BJ1DTTM) + "'";
	return sqlWhere;
}

public
void setBJ1KEYN(decimal BJ1KEYN){
	this.BJ1KEYN = BJ1KEYN;
}

public
void setBJ1REF(string BJ1REF){
	this.BJ1REF = BJ1REF;
}

public
void setBJ1DATE(DateTime BJ1DATE){
	this.BJ1DATE = BJ1DATE;
}

public
void setBJ1HM(decimal BJ1HM){
	this.BJ1HM = BJ1HM;
}

public
void setBJ1EDAT(DateTime BJ1EDAT){
	this.BJ1EDAT = BJ1EDAT;
}

public
void setBJ1QTY(decimal BJ1QTY){
	this.BJ1QTY = BJ1QTY;
}

public
void setBJ1QCUM(decimal BJ1QCUM){
	this.BJ1QCUM = BJ1QCUM;
}

public
void setBJ1NQTY(decimal BJ1NQTY){
	this.BJ1NQTY = BJ1NQTY;
}

public
void setBJ1SRC(string BJ1SRC){
	this.BJ1SRC = BJ1SRC;
}

public
void setBJ1LOG(decimal BJ1LOG){
	this.BJ1LOG = BJ1LOG;
}

public
void setBJ1ENT(decimal BJ1ENT){
	this.BJ1ENT = BJ1ENT;
}

public
void setBJ1BOL(decimal BJ1BOL){
	this.BJ1BOL = BJ1BOL;
}

public
void setBJ1BLIN(decimal BJ1BLIN){
	this.BJ1BLIN = BJ1BLIN;
}

public
void setBJ1RAN(string BJ1RAN){
	this.BJ1RAN = BJ1RAN;
}

public
void setBJ1REF1(string BJ1REF1){
	this.BJ1REF1 = BJ1REF1;
}

public
void setBJ1REF2(string BJ1REF2){
	this.BJ1REF2 = BJ1REF2;
}

public
void setBJ1STAT(string BJ1STAT){
	this.BJ1STAT = BJ1STAT;
}

public
void setBJ1KEY(decimal BJ1KEY){
	this.BJ1KEY = BJ1KEY;
}

public
void setBJ1KBPR(string BJ1KBPR){
	this.BJ1KBPR = BJ1KBPR;
}

public
void setBJ1KBST(string BJ1KBST){
	this.BJ1KBST = BJ1KBST;
}

public
void setBJ1KBEN(string BJ1KBEN){
	this.BJ1KBEN = BJ1KBEN;
}

public
void setBJ1SHPP(string BJ1SHPP){
	this.BJ1SHPP = BJ1SHPP;
}

public
void setBJ1SHPT(string BJ1SHPT){
	this.BJ1SHPT = BJ1SHPT;
}

public
void setBJ1TYPE(string BJ1TYPE){
	this.BJ1TYPE = BJ1TYPE;
}

public
void setBJ1TIMT(string BJ1TIMT){
	this.BJ1TIMT = BJ1TIMT;
}

public
void setBJ1TIMC(string BJ1TIMC){
	this.BJ1TIMC = BJ1TIMC;
}

public
void setBJ1RTEG(string BJ1RTEG){
	this.BJ1RTEG = BJ1RTEG;
}

public
void setBJ1SVCC(string BJ1SVCC){
	this.BJ1SVCC = BJ1SVCC;
}

public
void setBJ1MODE(string BJ1MODE){
	this.BJ1MODE = BJ1MODE;
}

public
void setBJ1USR1(string BJ1USR1){
	this.BJ1USR1 = BJ1USR1;
}

public
void setBJ1USR2(string BJ1USR2){
	this.BJ1USR2 = BJ1USR2;
}

public
void setBJ1USR3(string BJ1USR3){
	this.BJ1USR3 = BJ1USR3;
}

public
void setBJ1USR4(string BJ1USR4){
	this.BJ1USR4 = BJ1USR4;
}

public
void setBJ1FUT1(string BJ1FUT1){
	this.BJ1FUT1 = BJ1FUT1;
}

public
void setBJ1FUT2(string BJ1FUT2){
	this.BJ1FUT2 = BJ1FUT2;
}

public
void setBJ1FUT3(string BJ1FUT3){
	this.BJ1FUT3 = BJ1FUT3;
}

public
void setBJ1FUT4(string BJ1FUT4){
	this.BJ1FUT4 = BJ1FUT4;
}

public
void setBJ1FUT5(string BJ1FUT5){
	this.BJ1FUT5 = BJ1FUT5;
}

public
void setBJ1FUT6(string BJ1FUT6){
	this.BJ1FUT6 = BJ1FUT6;
}

public
void setBJ1FUT7(string BJ1FUT7){
	this.BJ1FUT7 = BJ1FUT7;
}

public
void setBJ1FUT8(string BJ1FUT8){
	this.BJ1FUT8 = BJ1FUT8;
}

public
void setBJ1FUTA(string BJ1FUTA){
	this.BJ1FUTA = BJ1FUTA;
}

public
void setBJ1FUTB(string BJ1FUTB){
	this.BJ1FUTB = BJ1FUTB;
}

public
void setBJ1FUTC(string BJ1FUTC){
	this.BJ1FUTC = BJ1FUTC;
}

public
void setBJ1FUTD(string BJ1FUTD){
	this.BJ1FUTD = BJ1FUTD;
}

public
void setBJ1FUTE(string BJ1FUTE){
	this.BJ1FUTE = BJ1FUTE;
}

public
void setBJ1FUTF(string BJ1FUTF){
	this.BJ1FUTF = BJ1FUTF;
}

public
void setBJ1FUTG(string BJ1FUTG){
	this.BJ1FUTG = BJ1FUTG;
}

public
void setBJ1FUTH(string BJ1FUTH){
	this.BJ1FUTH = BJ1FUTH;
}

public
void setBJ1FUTI(string BJ1FUTI){
	this.BJ1FUTI = BJ1FUTI;
}

public
void setBJ1FUTJ(string BJ1FUTJ){
	this.BJ1FUTJ = BJ1FUTJ;
}

public
void setBJ1FUTK(string BJ1FUTK){
	this.BJ1FUTK = BJ1FUTK;
}

public
void setBJ1FUTL(string BJ1FUTL){
	this.BJ1FUTL = BJ1FUTL;
}

public
void setBJ1FUTM(string BJ1FUTM){
	this.BJ1FUTM = BJ1FUTM;
}

public
void setBJ1FUTN(string BJ1FUTN){
	this.BJ1FUTN = BJ1FUTN;
}

public
void setBJ1FUTO(string BJ1FUTO){
	this.BJ1FUTO = BJ1FUTO;
}

public
void setBJ1FUTP(string BJ1FUTP){
	this.BJ1FUTP = BJ1FUTP;
}

public
void setBJ1FUTQ(string BJ1FUTQ){
	this.BJ1FUTQ = BJ1FUTQ;
}

public
void setBJ1FUTR(string BJ1FUTR){
	this.BJ1FUTR = BJ1FUTR;
}

public
void setBJ1FUTS(string BJ1FUTS){
	this.BJ1FUTS = BJ1FUTS;
}

public
void setBJ1FUTT(string BJ1FUTT){
	this.BJ1FUTT = BJ1FUTT;
}

public
void setBJ1FUTU(string BJ1FUTU){
	this.BJ1FUTU = BJ1FUTU;
}

public
void setBJ1FLG1(string BJ1FLG1){
	this.BJ1FLG1 = BJ1FLG1;
}

public
void setBJ1FLG2(string BJ1FLG2){
	this.BJ1FLG2 = BJ1FLG2;
}

public
void setBJ1FLG3(string BJ1FLG3){
	this.BJ1FLG3 = BJ1FLG3;
}

public
void setBJ1FLG4(string BJ1FLG4){
	this.BJ1FLG4 = BJ1FLG4;
}

public
void setBJ1JITS(string BJ1JITS){
	this.BJ1JITS = BJ1JITS;
}

public
void setBJ1TMZN(string BJ1TMZN){
	this.BJ1TMZN = BJ1TMZN;
}

public
void setBJ1CHDT(DateTime BJ1CHDT){
	this.BJ1CHDT = BJ1CHDT;
}

public
void setBJ1CHTM(decimal BJ1CHTM){
	this.BJ1CHTM = BJ1CHTM;
}

public
void setBJ1DTTM(DateTime BJ1DTTM){
	this.BJ1DTTM = BJ1DTTM;
}

public
void setBJ1USID(string BJ1USID){
	this.BJ1USID = BJ1USID;
}

public
void setBJ1ITYP(string BJ1ITYP){
	this.BJ1ITYP = BJ1ITYP;
}

public
void setBJ1OPCD(string BJ1OPCD){
	this.BJ1OPCD = BJ1OPCD;
}

public
decimal getBJ1KEYN(){
	return BJ1KEYN;
}

public
string getBJ1REF(){
	return BJ1REF;
}

public
DateTime getBJ1DATE(){
	return BJ1DATE;
}

public
decimal getBJ1HM(){
	return BJ1HM;
}

public
DateTime getBJ1EDAT(){
	return BJ1EDAT;
}

public
decimal getBJ1QTY(){
	return BJ1QTY;
}

public
decimal getBJ1QCUM(){
	return BJ1QCUM;
}

public
decimal getBJ1NQTY(){
	return BJ1NQTY;
}

public
string getBJ1SRC(){
	return BJ1SRC;
}

public
decimal getBJ1LOG(){
	return BJ1LOG;
}

public
decimal getBJ1ENT(){
	return BJ1ENT;
}

public
decimal getBJ1BOL(){
	return BJ1BOL;
}

public
decimal getBJ1BLIN(){
	return BJ1BLIN;
}

public
string getBJ1RAN(){
	return BJ1RAN;
}

public
string getBJ1REF1(){
	return BJ1REF1;
}

public
string getBJ1REF2(){
	return BJ1REF2;
}

public
string getBJ1STAT(){
	return BJ1STAT;
}

public
decimal getBJ1KEY(){
	return BJ1KEY;
}

public
string getBJ1KBPR(){
	return BJ1KBPR;
}

public
string getBJ1KBST(){
	return BJ1KBST;
}

public
string getBJ1KBEN(){
	return BJ1KBEN;
}

public
string getBJ1SHPP(){
	return BJ1SHPP;
}

public
string getBJ1SHPT(){
	return BJ1SHPT;
}

public
string getBJ1TYPE(){
	return BJ1TYPE;
}

public
string getBJ1TIMT(){
	return BJ1TIMT;
}

public
string getBJ1TIMC(){
	return BJ1TIMC;
}

public
string getBJ1RTEG(){
	return BJ1RTEG;
}

public
string getBJ1SVCC(){
	return BJ1SVCC;
}

public
string getBJ1MODE(){
	return BJ1MODE;
}

public
string getBJ1USR1(){
	return BJ1USR1;
}

public
string getBJ1USR2(){
	return BJ1USR2;
}

public
string getBJ1USR3(){
	return BJ1USR3;
}

public
string getBJ1USR4(){
	return BJ1USR4;
}

public
string getBJ1FUT1(){
	return BJ1FUT1;
}

public
string getBJ1FUT2(){
	return BJ1FUT2;
}

public
string getBJ1FUT3(){
	return BJ1FUT3;
}

public
string getBJ1FUT4(){
	return BJ1FUT4;
}

public
string getBJ1FUT5(){
	return BJ1FUT5;
}

public
string getBJ1FUT6(){
	return BJ1FUT6;
}

public
string getBJ1FUT7(){
	return BJ1FUT7;
}

public
string getBJ1FUT8(){
	return BJ1FUT8;
}

public
string getBJ1FUTA(){
	return BJ1FUTA;
}

public
string getBJ1FUTB(){
	return BJ1FUTB;
}

public
string getBJ1FUTC(){
	return BJ1FUTC;
}

public
string getBJ1FUTD(){
	return BJ1FUTD;
}

public
string getBJ1FUTE(){
	return BJ1FUTE;
}

public
string getBJ1FUTF(){
	return BJ1FUTF;
}

public
string getBJ1FUTG(){
	return BJ1FUTG;
}

public
string getBJ1FUTH(){
	return BJ1FUTH;
}

public
string getBJ1FUTI(){
	return BJ1FUTI;
}

public
string getBJ1FUTJ(){
	return BJ1FUTJ;
}

public
string getBJ1FUTK(){
	return BJ1FUTK;
}

public
string getBJ1FUTL(){
	return BJ1FUTL;
}

public
string getBJ1FUTM(){
	return BJ1FUTM;
}

public
string getBJ1FUTN(){
	return BJ1FUTN;
}

public
string getBJ1FUTO(){
	return BJ1FUTO;
}

public
string getBJ1FUTP(){
	return BJ1FUTP;
}

public
string getBJ1FUTQ(){
	return BJ1FUTQ;
}

public
string getBJ1FUTR(){
	return BJ1FUTR;
}

public
string getBJ1FUTS(){
	return BJ1FUTS;
}

public
string getBJ1FUTT(){
	return BJ1FUTT;
}

public
string getBJ1FUTU(){
	return BJ1FUTU;
}

public
string getBJ1FLG1(){
	return BJ1FLG1;
}

public
string getBJ1FLG2(){
	return BJ1FLG2;
}

public
string getBJ1FLG3(){
	return BJ1FLG3;
}

public
string getBJ1FLG4(){
	return BJ1FLG4;
}

public
string getBJ1JITS(){
	return BJ1JITS;
}

public
string getBJ1TMZN(){
	return BJ1TMZN;
}

public
DateTime getBJ1CHDT(){
	return BJ1CHDT;
}

public
decimal getBJ1CHTM(){
	return BJ1CHTM;
}

public
DateTime getBJ1DTTM(){
	return BJ1DTTM;
}

public
string getBJ1USID(){
	return BJ1USID;
}

public
string getBJ1ITYP(){
	return BJ1ITYP;
}

public
string getBJ1OPCD(){
	return BJ1OPCD;
}

} // class
} // package