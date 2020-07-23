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

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class UpCum01PDataBase : GenericDataBaseElement {

private decimal FGBOL;
private string FEBCS;
private string FESCS;
private decimal FGENT;
private decimal FGORD;
private decimal FGITEM;
private string FGCREL;
private string FEPLTC;
private DateTime FECDAT;
private DateTime FESDAT;
private string FGRAN;
private string PYRAN;
private string USERAN;
private decimal FGCCUM;
private decimal SMCKEY;
private DateTime SMRDAT;
private DateTime SPLDAT;
private string SPTRPT;
private string TPLOC;
private decimal SPOEMC;
private decimal SPOEMS;
private decimal SPOEMD;
private DateTime UPEXSD;
private decimal UPEXNQ;
private DateTime EXDATE;
private decimal JITCUM;
private DateTime PRDATE;
private decimal PRDCUM;
private DateTime NEDATE;
private decimal NEDCUM;
private DateTime RANFDAT;
private decimal RANFQTY;
private DateTime RANDAT;
private decimal RANQTY;
private string OZTRPT;

private DateTime PLPRDA;
private decimal PLPCUM;
private DateTime PLNRDA;
private decimal PLNCUM;
private DateTime PLRDAT;
private decimal RRLCUM;
        /*
  PLPRDA          L         COLHDG('RRLD' 'PRIOR' 'REL. 
*A            PLPCUM        10S 0       COLHDG('RRLD' 'PRIOR' 'CUMU 
*A            PLNRDA          L         COLHDG('RRLD' 'NEXT ' 'REL. 
*A            PLNCUM        10S 0       COLHDG('RRLD' 'NEXT ' 'CUMU 
 A            PLRDAT          L         COLHDG('RRLD' 'RELEASE')    
 A            RRLCUM        10S 0       COLHDG('RRLD' 'CUMULATIVE ' 
 A*   
 A            UPLITI         6S 0       COLHDG('LEAD ' 'TIME  ')    
 A            UPARDA          L         COLHDG('ARRIVAL' 'DATE')    
 A            UPOTST         1A         COLHDG('ON TIME' 'STATUS')  
 A            UPQTST         1A         COLHDG('QUANTITY''STATUS')  */

public
UpCum01PDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
	string sql = "select * from " + getTablePrefix3()  +"upcum01p where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
	string sql = "select * from " + getTablePrefix3()  +"upcum01p where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){	
    try {
        this.FGBOL = reader.GetDecimal("FEBOL#");        
    }catch{
        this.FGBOL = reader.GetDecimal("FGBOL#");
    }
	try {this.FEBCS = reader.GetString("FEBCS#"); }catch{};
	try {this.FESCS = reader.GetString("FESCS#"); }catch{};
	try {this.FGENT = reader.GetDecimal("FGENT#"); }catch{};
	try {this.FGORD = reader.GetDecimal("FGORD#"); }catch{};
	try {this.FGITEM = reader.GetDecimal("FGITEM"); }catch{};
	try {this.FGCREL = reader.GetString("FGCREL"); }catch{};
	try {this.FEPLTC = reader.GetString("FEPLTC"); }catch{};
	try {this.FECDAT = reader.GetDateTime("FECDAT"); }catch{};
	try {this.FESDAT = reader.GetDateTime("FESDAT"); }catch{};

    try { this.FGRAN = reader.GetString("FGRAN#"); }catch{};
	try { this.PYRAN = reader.GetString("PYRAN"); }catch{};
	try { this.USERAN = reader.GetString("USERAN"); }catch{};
	try { this.FGCCUM = reader.GetDecimal("FGCCUM"); }catch{};
	try { this.SMCKEY = reader.GetDecimal("SMCKEY"); }catch{};
	try { this.SMRDAT = reader.GetDateTime("SMRDAT"); }catch{};
	try { this.SPLDAT = reader.GetDateTime("SPLDAT"); }catch{};
	try { this.SPTRPT = reader.GetString("SPTRPT"); }catch{};
	try { this.TPLOC = reader.GetString("TPLOC"); }catch{};
	try { this.SPOEMC = reader.GetDecimal("SPOEMC"); }catch{};
	try { this.SPOEMS = reader.GetDecimal("SPOEMS"); }catch{};
	try { this.SPOEMD = reader.GetDecimal("SPOEMD"); }catch{};
	try { this.UPEXSD = reader.GetDateTime("UPEXSD"); }catch{};
	try { this.UPEXNQ = reader.GetDecimal("UPEXNQ"); }catch{};
	try { this.EXDATE = reader.GetDateTime("EXDATE"); }catch{};
	try { this.JITCUM = reader.GetDecimal("JITCUM"); }catch{};
	try { this.PRDATE = reader.GetDateTime("PRDATE"); }catch{};
	try { this.PRDCUM = reader.GetDecimal("PRDCUM"); }catch{};
	try { this.NEDATE = reader.GetDateTime("NEDATE"); }catch{};
	try { this.NEDCUM = reader.GetDecimal("NEDCUM"); }catch{};
	try { this.RANFDAT = reader.GetDateTime("RANFDAT"); }catch{};
	try { this.RANFQTY = reader.GetDecimal("RANFQTY"); }catch{};
	try { this.RANDAT = reader.GetDateTime("RANDAT"); }catch{};
	try { this.RANQTY = reader.GetDecimal("RANQTY"); }catch{};
	try { this.OZTRPT = reader.GetString("OZTRPT"); }catch{};

	try { this.PLPRDA = reader.GetDateTime("PLPRDA"); }catch{};//no
	try { this.PLPCUM = reader.GetDecimal("PLPCUM"); }catch{};
	try { this.PLNRDA = reader.GetDateTime("PLNRDA"); }catch{};
	try { this.PLNCUM = reader.GetDecimal("PLNCUM"); }catch{};
	try { this.PLRDAT = reader.GetDateTime("PLRDAT"); }catch{};
	try { this.RRLCUM = reader.GetDecimal("RRLCUM"); }catch{};
}

public override
void write(){
	string sql = "insert into " + getTablePrefix3()  +"upcum01p(" + 
		"FGBOL#," +
		"FEBCS#," +
		"FESCS#," +
		"FGENT#," +
		"FGORD#," +
		"FGITEM," +
		"FGCREL," +
		"FEPLTC," +
		"FECDAT," +
		"FESDAT," +
		"FGRAN#," +
		"PYRAN," +
		"USERAN," +
		"FGCCUM," +
		"SMCKEY," +
		"SMRDAT," +
		"SPLDAT," +
		"SPTRPT," +
		"TPLOC," +
		"SPOEMC," +
		"SPOEMS," +
		"SPOEMD," +
		"UPEXSD," +
		"UPEXNQ," +
		"EXDATE," +
		"JITCUM," +
		"PRDATE," +
		"PRDCUM," +
		"NEDATE," +
		"NEDCUM," +
		"RANFDAT," +
		"RANFQTY," +
		"RANDAT," +
		"RANQTY," +
		"OZTRPT," +
		"PLPRDA," +
		"PLPCUM," +
		"PLNRDA," +
		"PLNCUM," +
		"PLRDAT," +
		"RRLCUM" +

		") values (" + 

		"" + NumberUtil.toString(FGBOL) + "," +
		"'" + Converter.fixString(FEBCS) + "'," +
		"'" + Converter.fixString(FESCS) + "'," +
		"" + NumberUtil.toString(FGENT) + "," +
		"" + NumberUtil.toString(FGORD) + "," +
		"" + NumberUtil.toString(FGITEM) + "," +
		"'" + Converter.fixString(FGCREL) + "'," +
		"'" + Converter.fixString(FEPLTC) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(FECDAT) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(FESDAT) + "'," +
		"'" + Converter.fixString(FGRAN) + "'," +
		"'" + Converter.fixString(PYRAN) + "'," +
		"'" + Converter.fixString(USERAN) + "'," +
		"" + NumberUtil.toString(FGCCUM) + "," +
		"" + NumberUtil.toString(SMCKEY) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(SMRDAT) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(SPLDAT) + "'," +
		"'" + Converter.fixString(SPTRPT) + "'," +
		"'" + Converter.fixString(TPLOC) + "'," +
		"" + NumberUtil.toString(SPOEMC) + "," +
		"" + NumberUtil.toString(SPOEMS) + "," +
		"" + NumberUtil.toString(SPOEMD) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(UPEXSD) + "'," +
		"" + NumberUtil.toString(UPEXNQ) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(EXDATE) + "'," +
		"" + NumberUtil.toString(JITCUM) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(PRDATE) + "'," +
		"" + NumberUtil.toString(PRDCUM) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(NEDATE) + "'," +
		"" + NumberUtil.toString(NEDCUM) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(RANFDAT) + "'," +
		"" + NumberUtil.toString(RANFQTY) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(RANDAT) + "'," +
		"" + NumberUtil.toString(RANQTY) + "," +
		"'" + Converter.fixString(OZTRPT) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(PLPRDA) + "'," +
		"" + NumberUtil.toString(PLPCUM) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(PLNRDA) + "'," +
		"" + NumberUtil.toString(PLNCUM) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(PLRDAT) + "'," +
		"" + NumberUtil.toString(RRLCUM) + ")";
	write(sql);	
}

public override
void update(){
	string sql = "update " + getTablePrefix3()  +"upcum01p set " +
		"FGBOL# = " + NumberUtil.toString(FGBOL) + ", " +
		"FEBCS# = '" + Converter.fixString(FEBCS) + "', " +
		"FESCS# = '" + Converter.fixString(FESCS) + "', " +
		"FGENT# = " + NumberUtil.toString(FGENT) + ", " +
		"FGORD# = " + NumberUtil.toString(FGORD) + ", " +
		"FGITEM = " + NumberUtil.toString(FGITEM) + ", " +
		"FGCREL = '" + Converter.fixString(FGCREL) + "', " +
		"FEPLTC = '" + Converter.fixString(FEPLTC) + "', " +
		"FECDAT = '" + DateUtil.getCompleteDateRepresentation(FECDAT) + "', " +
		"FESDAT = '" + DateUtil.getCompleteDateRepresentation(FESDAT) + "', " +
		"FGRAN# = '" + Converter.fixString(FGRAN) + "', " +
		"PYRAN = '" + Converter.fixString(PYRAN) + "', " +
		"USERAN = '" + Converter.fixString(USERAN) + "', " +
		"FGCCUM = " + NumberUtil.toString(FGCCUM) + ", " +
		"SMCKEY = " + NumberUtil.toString(SMCKEY) + ", " +
		"SMRDAT = '" + DateUtil.getCompleteDateRepresentation(SMRDAT) + "', " +
		"SPLDAT = '" + DateUtil.getCompleteDateRepresentation(SPLDAT) + "', " +
		"SPTRPT = '" + Converter.fixString(SPTRPT) + "', " +
		"TPLOC = '" + Converter.fixString(TPLOC) + "', " +
		"SPOEMC = " + NumberUtil.toString(SPOEMC) + ", " +
		"SPOEMS = " + NumberUtil.toString(SPOEMS) + ", " +
		"SPOEMD = " + NumberUtil.toString(SPOEMD) + ", " +
		"UPEXSD = '" + DateUtil.getCompleteDateRepresentation(UPEXSD) + "', " +
		"UPEXNQ = " + NumberUtil.toString(UPEXNQ) + ", " +
		"EXDATE = '" + DateUtil.getCompleteDateRepresentation(EXDATE) + "', " +
		"JITCUM = " + NumberUtil.toString(JITCUM) + ", " +
		"PRDATE = '" + DateUtil.getCompleteDateRepresentation(PRDATE) + "', " +
		"PRDCUM = " + NumberUtil.toString(PRDCUM) + ", " +
		"NEDATE = '" + DateUtil.getCompleteDateRepresentation(NEDATE) + "', " +
		"NEDCUM = " + NumberUtil.toString(NEDCUM) + ", " +
		"RANFDAT = '" + DateUtil.getCompleteDateRepresentation(RANFDAT) + "', " +
		"RANFQTY = " + NumberUtil.toString(RANFQTY) + ", " +
		"RANDAT = '" + DateUtil.getCompleteDateRepresentation(RANDAT) + "', " +
		"RANQTY = " + NumberUtil.toString(RANQTY) + ", " +
		"OZTRPT = '" + Converter.fixString(OZTRPT) + "', " +
		"PLPRDA = '" + DateUtil.getCompleteDateRepresentation(PLPRDA) + "', " +
		"PLPCUM = " + NumberUtil.toString(PLPCUM) + ", " +
		"PLNRDA = '" + DateUtil.getCompleteDateRepresentation(PLNRDA) + "', " +
		"PLNCUM = " + NumberUtil.toString(PLNCUM) + ", " +
		"PLRDAT = '" + DateUtil.getCompleteDateRepresentation(PLRDAT) + "', " +
		"RRLCUM = " + NumberUtil.toString(RRLCUM) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from " + getTablePrefix3()  +"upcum01p where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"FGBOL# = " + NumberUtil.toString(FGBOL) + " and " +
		"FGENT# = " + NumberUtil.toString(FGENT) + "";
	return sqlWhere;
}

public
void setFGBOL(decimal FGBOL){
	this.FGBOL = FGBOL;
}

public
void setFEBCS(string FEBCS){
	this.FEBCS = FEBCS;
}

public
void setFESCS(string FESCS){
	this.FESCS = FESCS;
}

public
void setFGENT(decimal FGENT){
	this.FGENT = FGENT;
}

public
void setFGORD(decimal FGORD){
	this.FGORD = FGORD;
}

public
void setFGITEM(decimal FGITEM){
	this.FGITEM = FGITEM;
}

public
void setFGCREL(string FGCREL){
	this.FGCREL = FGCREL;
}

public
void setFEPLTC(string FEPLTC){
	this.FEPLTC = FEPLTC;
}

public
void setFECDAT(DateTime FECDAT){
	this.FECDAT = FECDAT;
}

public
void setFESDAT(DateTime FESDAT){
	this.FESDAT = FESDAT;
}

public
void setFGRAN(string FGRAN){
	this.FGRAN = FGRAN;
}

public
void setPYRAN(string PYRAN){
	this.PYRAN = PYRAN;
}

public
void setUSERAN(string USERAN){
	this.USERAN = USERAN;
}

public
void setFGCCUM(decimal FGCCUM){
	this.FGCCUM = FGCCUM;
}

public
void setSMCKEY(decimal SMCKEY){
	this.SMCKEY = SMCKEY;
}

public
void setSMRDAT(DateTime SMRDAT){
	this.SMRDAT = SMRDAT;
}

public
void setSPLDAT(DateTime SPLDAT){
	this.SPLDAT = SPLDAT;
}

public
void setSPTRPT(string SPTRPT){
	this.SPTRPT = SPTRPT;
}

public
void setTPLOC(string TPLOC){
	this.TPLOC = TPLOC;
}

public
void setSPOEMC(decimal SPOEMC){
	this.SPOEMC = SPOEMC;
}

public
void setSPOEMS(decimal SPOEMS){
	this.SPOEMS = SPOEMS;
}

public
void setSPOEMD(decimal SPOEMD){
	this.SPOEMD = SPOEMD;
}

public
void setUPEXSD(DateTime UPEXSD){
	this.UPEXSD = UPEXSD;
}

public
void setUPEXNQ(decimal UPEXNQ){
	this.UPEXNQ = UPEXNQ;
}

public
void setEXDATE(DateTime EXDATE){
	this.EXDATE = EXDATE;
}

public
void setJITCUM(decimal JITCUM){
	this.JITCUM = JITCUM;
}

public
void setPRDATE(DateTime PRDATE){
	this.PRDATE = PRDATE;
}

public
void setPRDCUM(decimal PRDCUM){
	this.PRDCUM = PRDCUM;
}

public
void setNEDATE(DateTime NEDATE){
	this.NEDATE = NEDATE;
}

public
void setNEDCUM(decimal NEDCUM){
	this.NEDCUM = NEDCUM;
}

public
void setRANFDAT(DateTime RANFDAT){
	this.RANFDAT = RANFDAT;
}

public
void setRANFQTY(decimal RANFQTY){
	this.RANFQTY = RANFQTY;
}

public
void setRANDAT(DateTime RANDAT){
	this.RANDAT = RANDAT;
}

public
void setRANQTY(decimal RANQTY){
	this.RANQTY = RANQTY;
}

public
void setOZTRPT(string OZTRPT){
	this.OZTRPT = OZTRPT;
}

public
void setPLPRDA(DateTime PLPRDA){
	this.PLPRDA = PLPRDA;
}

public
void setPLPCUM(decimal PLPCUM){
	this.PLPCUM = PLPCUM;
}

public
void setPLNRDA(DateTime PLNRDA){
	this.PLNRDA = PLNRDA;
}

public
void setPLNCUM(decimal PLNCUM){
	this.PLNCUM = PLNCUM;
}

public
void setPLRDAT(DateTime PLRDAT){
	this.PLRDAT = PLRDAT;
}

public
void setRRLCUM(decimal RRLCUM){
	this.RRLCUM = RRLCUM;
}

public
decimal getFGBOL(){
	return FGBOL;
}

public
string getFEBCS(){
	return FEBCS;
}

public
string getFESCS(){
	return FESCS;
}

public
decimal getFGENT(){
	return FGENT;
}

public
decimal getFGORD(){
	return FGORD;
}

public
decimal getFGITEM(){
	return FGITEM;
}

public
string getFGCREL(){
	return FGCREL;
}

public
string getFEPLTC(){
	return FEPLTC;
}

public
DateTime getFECDAT(){
	return FECDAT;
}

public
DateTime getFESDAT(){
	return FESDAT;
}

public
string getFGRAN(){
	return FGRAN;
}

public
string getPYRAN(){
	return PYRAN;
}

public
string getUSERAN(){
	return USERAN;
}

public
decimal getFGCCUM(){
	return FGCCUM;
}

public
decimal getSMCKEY(){
	return SMCKEY;
}

public
DateTime getSMRDAT(){
	return SMRDAT;
}

public
DateTime getSPLDAT(){
	return SPLDAT;
}

public
string getSPTRPT(){
	return SPTRPT;
}

public
string getTPLOC(){
	return TPLOC;
}

public
decimal getSPOEMC(){
	return SPOEMC;
}

public
decimal getSPOEMS(){
	return SPOEMS;
}

public
decimal getSPOEMD(){
	return SPOEMD;
}

public
DateTime getUPEXSD(){
	return UPEXSD;
}

public
decimal getUPEXNQ(){
	return UPEXNQ;
}

public
DateTime getEXDATE(){
	return EXDATE;
}

public
decimal getJITCUM(){
	return JITCUM;
}

public
DateTime getPRDATE(){
	return PRDATE;
}

public
decimal getPRDCUM(){
	return PRDCUM;
}

public
DateTime getNEDATE(){
	return NEDATE;
}

public
decimal getNEDCUM(){
	return NEDCUM;
}

public
DateTime getRANFDAT(){
	return RANFDAT;
}

public
decimal getRANFQTY(){
	return RANFQTY;
}

public
DateTime getRANDAT(){
	return RANDAT;
}

public
decimal getRANQTY(){
	return RANQTY;
}

public
string getOZTRPT(){
	return OZTRPT;
}

public
DateTime getPLPRDA(){
	return PLPRDA;
}

public
decimal getPLPCUM(){
	return PLPCUM;
}

public
DateTime getPLNRDA(){
	return PLNRDA;
}

public
decimal getPLNCUM(){
	return PLNCUM;
}

public
DateTime getPLRDAT(){
	return PLRDAT;
}

public
decimal getRRLCUM(){
	return RRLCUM;
}

} // class
} // package