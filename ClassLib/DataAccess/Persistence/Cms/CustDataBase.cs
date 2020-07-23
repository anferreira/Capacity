using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{
public
class CustDataBase : GenericDataBaseElement{
private decimal BVCOMP;
private string BVCUST; 
private string BVNAME;
private string BVADR1;
private string BVADR2;
private string BVADR3;
private string BVADR4;
private string BVADR5;
private string BVADR6;
private string BVADR7;
private string BVADR8;
private string BVADR9;
private string BVADR10;
private string BVPOST;
private string BVTELP;
private string BVBORD;
private string BVPRAR;
private string BVPSTE;
private string BVPRCD;
private string BVPSTL;
private string BVFSTE;
private string BVTXGR;
private string BVTXRT;
private string BVPACK;
private string BVNU10;
private string BVSALM; 
private string BVTERR;
private string BVSNOT;
private string BVCURR;
private string BVSCOM;
private string BVTYPE;
private string BVCRLE;
private string BVGSTE;
private decimal BVCREL;
private string BVOEM;
private string BVLANG;
private decimal BVSHLT;
private string BVINPO;
private string BVTERM;
private string BVSHCL;
private string BV1B;
private decimal BVDISL; 
private string BVARCD;
private string BVINT;
private decimal BVSDAY;
private string BVPORQ;
private string BVCLAS;
private string BVPSTC;
private DateTime BVLDAT; 
private decimal BVLINA;
private DateTime BVPDAT; 
private decimal BVLPAA; 
private decimal BVYTDS;
private decimal BVLYTD;
private decimal BVOUTB;
private string BV15;
private string BVDUNN;
private string BVFAX;
private DateTime BVMDAT; 
private string BVBILL;
private string BVGSTL;
private string BV3;
private decimal BVLARA;
private string BVCONT;
private string BVSUPP;
private string BVSFOR;
private decimal BVSFCP;
private string BVMFOR;
private decimal BVMFCP;
private string BVXFOR;
private decimal BVXFCP;
private string BVCARC;
private string BVSERC;
private string BVSUPA;
private string BVTRDP;
private string BVDUNS;
private string BVSFID;
private string BVUSEC;
private string BVSHPR;
private string BVASNY;
private string BVINVY;
private string BVFLG1;
private string BVFLG2;
private string BVFLG3;
private string BVFLG4;
private string BVFLG5;
private string BVFLG6;
private string BVSUMR;
private string BVPLNT;
private string BVDOCK;
private string BVLINE;
private string BVDROP;
private string BVTMOD; 
private string BVTTYP; 
private string BVEQPI; 
private string BVROUT;
private string BVPOOL; 
private string BVPOLL;
private string BVJITF; 
private string BVAPLG; 
private string BVAVER;
private string BVUVER;
private string BVFOBC; 
private string BVEMAL;
private string BVWEB; 
private string BVFL01; 
private string BVADJC; 
private string BVPPCL; 
private DateTime BVCDAT;
private string BVIBRQ; 
private string BVORSM; 
private string BVFL04; 
private string BVSTAT; 
private string BVREAS; 
private string BVFL05; 
private string BVFL06; 
private string BVFL07; 
private string BVFL08; 
private string BVFL09; 
private string BVFL10; 
public 
CustDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}


public
bool read(){
	string sql = "select * from "+ getTablePrefix() + "CUST where " + getWhereCondition();
	return read(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
        "BVCUST = '" + Converter.fixString(BVCUST) + "'";
	return sqlWhere;
}


public override
void load(NotNullDataReader reader){
//if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMSTEMP_DATABASE){
//		this.DB = reader.GetString("DB");
//	}
	this.BVCOMP = reader.GetDecimal("BVCOMP");
	this.BVCUST = reader.GetString("BVCUST");
	this.BVNAME = reader.GetString("BVNAME");
	this.BVADR1 = reader.GetString("BVADR1");
	this.BVADR2 = reader.GetString("BVADR2");
	this.BVADR3 = reader.GetString("BVADR3");
	this.BVADR4 = reader.GetString("BVADR4");
	this.BVADR5 = reader.GetString("BVADR5");
	this.BVADR6 = reader.GetString("BVADR6");
	this.BVADR7 = reader.GetString("BVADR7");
	this.BVADR8 = reader.GetString("BVADR8");
	this.BVADR9 = reader.GetString("BVADR9");
	this.BVADR10 = reader.GetString("BVADR10");
	this.BVPOST = reader.GetString("BVPOST");
	this.BVTELP = reader.GetString("BVTELP");
	this.BVBORD = reader.GetString("BVBORD");
	this.BVPRAR = reader.GetString("BVPRAR");
	this.BVPSTE = reader.GetString("BVPSTE");
	this.BVPRCD = reader.GetString("BVPRCD");
	this.BVPSTL = reader.GetString("BVPSTL");
	this.BVFSTE = reader.GetString("BVFSTE");
	this.BVTXGR = reader.GetString("BVTXGR");
	this.BVTXRT = reader.GetString("BVTXRT");
	this.BVPACK = reader.GetString("BVPACK");
	this.BVNU10 = reader.GetString("BVNU10");
	this.BVSALM = reader.GetString("BVSALM");
	this.BVTERR = reader.GetString("BVTERR");
	this.BVSNOT = reader.GetString("BVSNOT");
	this.BVCURR = reader.GetString("BVCURR");
	this.BVSCOM = reader.GetString("BVSCOM");
	this.BVTYPE = reader.GetString("BVTYPE");
	this.BVCRLE = reader.GetString("BVCRLE");
	this.BVGSTE = reader.GetString("BVGSTE");
	this.BVCREL = reader.GetDecimal("BVCREL");
	this.BVOEM = reader.GetString("BVOEM");
	this.BVLANG = reader.GetString("BVLANG");
	this.BVSHLT = reader.GetDecimal("BVSHLT");
	this.BVINPO = reader.GetString("BVINPO");
	this.BVTERM = reader.GetString("BVTERM");
	this.BVSHCL = reader.GetString("BVSHCL");
	this.BV1B = reader.GetString("BV1B");
	this.BVDISL = reader.GetDecimal("BVDISL"); 
	this.BVARCD = reader.GetString("BVARCD");
	this.BVINT = reader.GetString("BVINT");
	this.BVSDAY = reader.GetDecimal("BVSDAY");
	this.BVPORQ = reader.GetString("BVPORQ");
	this.BVCLAS = reader.GetString("BVCLAS");
	this.BVPSTC = reader.GetString("BVPSTC");
	this.BVLDAT = reader.GetDateTime("BVLDAT"); 
	this.BVLINA = reader.GetDecimal("BVLINA");
	this.BVPDAT = reader.GetDateTime("BVPDAT"); 
	this.BVLPAA = reader.GetDecimal("BVLPAA");
	this.BVYTDS = reader.GetDecimal("BVYTDS");
	this.BVLYTD = reader.GetDecimal("BVLYTD");
	this.BVOUTB = reader.GetDecimal("BVOUTB");
	this.BV15 = reader.GetString("BV15");
	this.BVDUNN = reader.GetString("BVDUNN");
	this.BVFAX = reader.GetString("BVFAX");
	this.BVMDAT = reader.GetDateTime("BVMDAT"); 
	this.BVBILL = reader.GetString("BVBILL");
	this.BVGSTL = reader.GetString("BVGSTL");
	this.BV3 = reader.GetString("BV3");
	this.BVLARA = reader.GetDecimal("BVLARA");
	this.BVCONT = reader.GetString("BVCONT");
	this.BVSUPP = reader.GetString("BVSUPP");
	this.BVSFOR = reader.GetString("BVSFOR");
	this.BVSFCP = reader.GetDecimal("BVSFCP");
	this.BVMFOR = reader.GetString("BVMFOR");
	this.BVMFCP = reader.GetDecimal("BVMFCP");
	this.BVXFOR = reader.GetString("BVXFOR");
	this.BVXFCP = reader.GetDecimal("BVXFCP");
	this.BVCARC = reader.GetString("BVCARC");
	this.BVSERC = reader.GetString("BVSERC");
	this.BVSUPA = reader.GetString("BVSUPA");
	this.BVTRDP = reader.GetString("BVTRDP");
	this.BVDUNS = reader.GetString("BVDUNS");
	this.BVSFID = reader.GetString("BVSFID");
	this.BVUSEC = reader.GetString("BVUSEC");
	this.BVSHPR = reader.GetString("BVSHPR");
	this.BVASNY = reader.GetString("BVASNY");
	this.BVINVY = reader.GetString("BVINVY");
	this.BVFLG1 = reader.GetString("BVFLG1");
	this.BVFLG2 = reader.GetString("BVFLG2");
	this.BVFLG3 = reader.GetString("BVFLG3");
	this.BVFLG4 = reader.GetString("BVFLG4");
	this.BVFLG5 = reader.GetString("BVFLG5");
	this.BVFLG6 = reader.GetString("BVFLG6");
	this.BVSUMR = reader.GetString("BVSUMR");
	this.BVPLNT = reader.GetString("BVPLNT");
	this.BVDOCK = reader.GetString("BVDOCK");
	this.BVLINE = reader.GetString("BVLINE");
	this.BVDROP = reader.GetString("BVDROP");
	this.BVTMOD = reader.GetString("BVTMOD");
	this.BVTTYP = reader.GetString("BVTTYP");
	this.BVEQPI = reader.GetString("BVEQPI"); 
	this.BVROUT = reader.GetString("BVROUT");
	this.BVPOOL = reader.GetString("BVPOOL");
	this.BVPOLL = reader.GetString("BVPOLL");
	this.BVJITF = reader.GetString("BVJITF"); 
	this.BVAPLG = reader.GetString("BVAPLG");
	this.BVAVER = reader.GetString("BVAVER");
	this.BVUVER = reader.GetString("BVUVER");
	this.BVFOBC = reader.GetString("BVFOBC");
	this.BVEMAL = reader.GetString("BVEMAL");
	this.BVWEB = reader.GetString("BVWEB");
	this.BVFL01 = reader.GetString("BVFL01"); 
	this.BVADJC = reader.GetString("BVADJC");
	this.BVPPCL = reader.GetString("BVPPCL");
	this.BVCDAT = reader.GetDateTime("BVCDAT");
	this.BVIBRQ = reader.GetString("BVIBRQ"); 
	this.BVORSM = reader.GetString("BVORSM"); 
	this.BVFL04 = reader.GetString("BVFL04");
	this.BVSTAT = reader.GetString("BVSTAT"); 
	this.BVREAS = reader.GetString("BVREAS"); 
	this.BVFL05 = reader.GetString("BVFL05"); 
	this.BVFL06 = reader.GetString("BVFL06"); 
	this.BVFL07 = reader.GetString("BVFL07"); 
	this.BVFL08 = reader.GetString("BVFL08"); 
	this.BVFL09 = reader.GetString("BVFL09"); 
	this.BVFL10 = reader.GetString("BVFL10"); 
}
public override
void write(){
	
		string sql = "insert into cust values(" +
			NumberUtil.toString(BVCOMP) + ", '" +
			Converter.fixString(BVCUST) + "', '" + 
			Converter.fixString(BVNAME) + "', '" +
			Converter.fixString(BVADR1) + "', '" +
			Converter.fixString(BVADR2) + "', '" +
			Converter.fixString(BVADR3) + "', '" +
			Converter.fixString(BVADR4) + "', '" +
			Converter.fixString(BVADR5) + "', '" +
			Converter.fixString(BVADR6) + "', '" +
			Converter.fixString(BVADR7) + "', '" +
			Converter.fixString(BVADR8) + "', '" +
			Converter.fixString(BVADR9) + "', '" +
			Converter.fixString(BVADR10) + "', '" +
			Converter.fixString(BVPOST) + "', '" +
			Converter.fixString(BVTELP) + "', '" +
			Converter.fixString(BVBORD) + "', '" +
			Converter.fixString(BVPRAR) + "', '" +
			Converter.fixString(BVPSTE) + "', '" +
			Converter.fixString(BVPRCD) + "', '" +
			Converter.fixString(BVPSTL) + "', '" +
			Converter.fixString(BVFSTE) + "', '" +
			Converter.fixString(BVTXGR) + "', '" +
			Converter.fixString(BVTXRT) + "', '" +
			Converter.fixString(BVPACK) + "', '" +
			Converter.fixString(BVNU10) + "', '" +
			Converter.fixString(BVSALM) + "', '" +
			Converter.fixString(BVTERR) + "', '" +
			Converter.fixString(BVSNOT) + "', '" +
			Converter.fixString(BVCURR) + "', '" +
			Converter.fixString(BVSCOM) + "', '" +
			Converter.fixString(BVTYPE) + "', '" +
			Converter.fixString(BVCRLE) + "', '" +
			Converter.fixString(BVGSTE) + "', " +
			NumberUtil.toString(BVCREL)  + ", '" +
			Converter.fixString(BVOEM) + "', '" +
			Converter.fixString(BVLANG) + "', " +
			NumberUtil.toString(BVSHLT)  + ", '" +
			Converter.fixString(BVINPO) + "', '" +
			Converter.fixString(BVTERM) + "', '" +
			Converter.fixString(BVSHCL) + "', '" +
			Converter.fixString(BV1B) + "', " +
			NumberUtil.toString(BVDISL) + ", '" +
			Converter.fixString(BVARCD) + "', '" +
			Converter.fixString(BVINT) + "', " +
			NumberUtil.toString(BVSDAY)  + ", '" +
			Converter.fixString(BVPORQ) + "', '" +
			Converter.fixString(BVCLAS) + "', '" +
			Converter.fixString(BVPSTC) + "', '" +
			DateUtil.getCompleteDateRepresentation(BVLDAT) + "', " + 
			NumberUtil.toString(BVLINA)  + ", '" +
			DateUtil.getCompleteDateRepresentation(BVPDAT) + "', " + 
			NumberUtil.toString(BVLPAA)  + ", " +
			NumberUtil.toString(BVYTDS)  + ", " +
			NumberUtil.toString(BVLYTD)  + ", " +
			NumberUtil.toString(BVOUTB)  + ", '" +
			Converter.fixString(BV15) + "', '" +
			Converter.fixString(BVDUNN) + "', '" +
			Converter.fixString(BVFAX) + "', '" +
			DateUtil.getCompleteDateRepresentation(BVMDAT) + "', '"+
			Converter.fixString(BVBILL) + "', '" +
			Converter.fixString(BVGSTL) + "', '" +
			Converter.fixString(BV3) + "', " +
			NumberUtil.toString(BVLARA) + ", '" +
			Converter.fixString(BVCONT) + "', '" +
			Converter.fixString(BVSUPP) + "', '" +
			Converter.fixString(BVSFOR) + "', " +
			NumberUtil.toString(BVSFCP)  + ", '" +
			Converter.fixString(BVMFOR) + "', " +
			NumberUtil.toString(BVMFCP)  + ", '" +
			Converter.fixString(BVXFOR) + "', " +
			NumberUtil.toString(BVXFCP)  + ", '" +
			Converter.fixString(BVCARC) + "', '" +
			Converter.fixString(BVSERC) + "', '" +
			Converter.fixString(BVSUPA) + "', '" +
			Converter.fixString(BVTRDP) + "', '" +
			Converter.fixString(BVDUNS) + "', '" +
			Converter.fixString(BVSFID) + "', '" +
			Converter.fixString(BVUSEC) + "', '" +
			Converter.fixString(BVSHPR) + "', '" +
			Converter.fixString(BVASNY) + "', '" +
			Converter.fixString(BVINVY) + "', '" +
			Converter.fixString(BVFLG1) + "', '" +
			Converter.fixString(BVFLG2) + "', '" +
			Converter.fixString(BVFLG3) + "', '" +
			Converter.fixString(BVFLG4) + "', '" +
			Converter.fixString(BVFLG5) + "', '" +
			Converter.fixString(BVFLG6) + "', '" +
			Converter.fixString(BVSUMR) + "', '" +
			Converter.fixString(BVPLNT) + "', '" +
			Converter.fixString(BVDOCK) + "', '" +
			Converter.fixString(BVLINE) + "', '" +
			Converter.fixString(BVDROP) + "', '" +
			Converter.fixString(BVTMOD) + "', '" +
			Converter.fixString(BVTTYP) + "', '" + 
			Converter.fixString(BVEQPI) + "', '" +
			Converter.fixString(BVROUT) + "', '" +
			Converter.fixString(BVPOOL) + "', '" +
			Converter.fixString(BVPOLL) + "', '" +
			Converter.fixString(BVJITF) + "', '" +
			Converter.fixString(BVAPLG) + "', '" +
			Converter.fixString(BVAVER) + "', '" +
			Converter.fixString(BVUVER) + "', '" +
			Converter.fixString(BVFOBC) + "', '" +
			Converter.fixString(BVEMAL) + "', '" +
			Converter.fixString(BVWEB) + "', '" +
			Converter.fixString(BVFL01) + "', '" +
			Converter.fixString(BVADJC) + "', '" +
			Converter.fixString(BVPPCL) + "', '" +
			DateUtil.getCompleteDateRepresentation(BVCDAT) + "', '" +
			Converter.fixString(BVIBRQ) + "', '" +
			Converter.fixString(BVORSM) + "', '" +
			Converter.fixString(BVFL04) + "', '" +
			Converter.fixString(BVSTAT) + "', '" +
			Converter.fixString(BVREAS) + "', '" +
			Converter.fixString(BVFL05) + "', '" +
			Converter.fixString(BVFL06) + "', '" +
			Converter.fixString(BVFL07) + "', '" +
			Converter.fixString(BVFL08) + "', '" +
			Converter.fixString(BVFL09) + "', '" +
			Converter.fixString(BVFL10) + "')";
		write(sql);
}
public override
void update(){
	throw new PersistenceException("Method not implemented");
}
public override
void delete(){
	throw new PersistenceException("Method not implemented");
}
public 
void setBVCOMP(decimal BVCOMP){
   this.BVCOMP = BVCOMP;
}
public 
void setBVCUST(string BVCUST){
   this.BVCUST = BVCUST; 
}
public 
void setBVNAME(string BVNAME){
   this.BVNAME = BVNAME;
}
public 
void setBVADR1(string BVADR1){
   this.BVADR1 = BVADR1;
}
public 
void setBVADR2(string BVADR2){
   this.BVADR2 = BVADR2;
}
public 
void setBVADR3(string BVADR3){
   this.BVADR3 = BVADR3;
}
public 
void setBVADR4(string BVADR4){
   this.BVADR4 = BVADR4;
}
public 
void setBVADR5(string BVADR5){
   this.BVADR5 = BVADR5;
}
public 
void setBVADR6(string BVADR6){
   this.BVADR6 = BVADR6;
}
public 
void setBVADR7(string BVADR7){
   this.BVADR7 = BVADR7;
}
public 
void setBVADR8(string BVADR8){
   this.BVADR8 = BVADR8;
}
public 
void setBVADR9(string BVADR9){
   this.BVADR9 = BVADR9;
}
public 
void setBVADR10(string BVADR10){
   this.BVADR10 = BVADR10;
}
public 
void setBVPOST(string BVPOST){
   this.BVPOST = BVPOST;
}
public 
void setBVTELP(string BVTELP){
   this.BVTELP = BVTELP;
}
public 
void setBVBORD(string BVBORD){
   this.BVBORD = BVBORD;
}
public 
void setBVPRAR(string BVPRAR){
   this.BVPRAR = BVPRAR;
}
public 
void setBVPSTE(string BVPSTE){
   this.BVPSTE = BVPSTE;
}
public 
void setBVPRCD(string BVPRCD){
   this.BVPRCD = BVPRCD;
}
public 
void setBVPSTL(string BVPSTL){
   this.BVPSTL = BVPSTL;
}
public 
void setBVFSTE(string BVFSTE){
   this.BVFSTE = BVFSTE;
}
public 
void setBVTXGR(string BVTXGR){
   this.BVTXGR = BVTXGR;
}
public 
void setBVTXRT(string BVTXRT){
   this.BVTXRT = BVTXRT;
}
public 
void setBVPACK(string BVPACK){
   this.BVPACK = BVPACK;
}
public 
void setBVNU10(string BVNU10){
   this.BVNU10 = BVNU10;
}
public 
void setBVSALM(string BVSALM){
   this.BVSALM = BVSALM; 
}
public 
void setBVTERR(string BVTERR){
   this.BVTERR = BVTERR;
}
public 
void setBVSNOT(string BVSNOT){
   this.BVSNOT = BVSNOT;
}
public 
void setBVCURR(string BVCURR){
   this.BVCURR = BVCURR;
}
public 
void setBVSCOM(string BVSCOM){
   this.BVSCOM = BVSCOM;
}
public 
void setBVTYPE(string BVTYPE){
   this.BVTYPE = BVTYPE;
}
public 
void setBVCRLE(string BVCRLE){
   this.BVCRLE = BVCRLE;
}
public 
void setBVGSTE(string BVGSTE){
   this.BVGSTE = BVGSTE;
}
public 
void setBVCREL(decimal BVCREL){
   this.BVCREL = BVCREL;
}
public 
void setBVOEM(string BVOEM){
   this.BVOEM = BVOEM;
}
public 
void setBVLANG(string BVLANG){
   this.BVLANG = BVLANG;
}
public 
void setBVSHLT(decimal BVSHLT){
   this.BVSHLT = BVSHLT;
}
public 
void setBVINPO(string BVINPO){
   this.BVINPO = BVINPO;
}
public 
void setBVTERM(string BVTERM){
   this.BVTERM = BVTERM;
}
public 
void setBVSHCL(string BVSHCL){
   this.BVSHCL = BVSHCL;
}
public 
void setBV1B(string BV1B){
   this.BV1B = BV1B;
}
public 
void setBVDISL(decimal BVDISL){
   this.BVDISL = BVDISL; 
}
public 
void setBVARCD(string BVARCD){
   this.BVARCD = BVARCD;
}
public 
void setBVINT(string BVINT){
   this.BVINT = BVINT;
}
public 
void setBVSDAY(decimal BVSDAY){
   this.BVSDAY = BVSDAY;
}
public 
void setBVPORQ(string BVPORQ){
   this.BVPORQ = BVPORQ;
}
public 
void setBVCLAS(string BVCLAS){
   this.BVCLAS = BVCLAS;
}
public 
void setBVPSTC(string BVPSTC){
   this.BVPSTC = BVPSTC;
}
public 
void setBVLDAT(DateTime BVLDAT){
   this.BVLDAT = BVLDAT; 
}
public 
void setBVLINA(decimal BVLINA){
   this.BVLINA = BVLINA;
}
public 
void setBVPDAT(DateTime BVPDAT){
   this.BVPDAT = BVPDAT; 
}
public 
void setBVLPAA(decimal BVLPAA){
   this.BVLPAA = BVLPAA; 
}
public 
void setBVYTDS(decimal BVYTDS){
   this.BVYTDS = BVYTDS;
}
public 
void setBVLYTD(decimal BVLYTD){
   this.BVLYTD = BVLYTD;
}
public 
void setBVOUTB(decimal BVOUTB){
   this.BVOUTB = BVOUTB;
}
public 
void setBV15(string BV15){
   this.BV15 = BV15;
}
public 
void setBVDUNN(string BVDUNN){
   this.BVDUNN = BVDUNN;
}
public 
void setBVFAX(string BVFAX){
   this.BVFAX = BVFAX;
}
public 
void setBVMDAT(DateTime BVMDAT){
   this.BVMDAT = BVMDAT; 
}
public 
void setBVBILL(string BVBILL){
   this.BVBILL = BVBILL;
}
public 
void setBVGSTL(string BVGSTL){
   this.BVGSTL = BVGSTL;
}
public 
void setBV3(string BV3){
   this.BV3 = BV3;
}
public 
void setBVLARA(decimal BVLARA){
   this.BVLARA = BVLARA;
}
public 
void setBVCONT(string BVCONT){
   this.BVCONT = BVCONT;
}
public 
void setBVSUPP(string BVSUPP){
   this.BVSUPP = BVSUPP;
}
public 
void setBVSFOR(string BVSFOR){
   this.BVSFOR = BVSFOR;
}
public 
void setBVSFCP(decimal BVSFCP){
   this.BVSFCP = BVSFCP;
}
public 
void setBVMFOR(string BVMFOR){
   this.BVMFOR = BVMFOR;
}
public 
void setBVMFCP(decimal BVMFCP){
   this.BVMFCP = BVMFCP;
}
public 
void setBVXFOR(string BVXFOR){
   this.BVXFOR = BVXFOR;
}
public 
void setBVXFCP(decimal BVXFCP){
   this.BVXFCP = BVXFCP;
}
public 
void setBVCARC(string BVCARC){
   this.BVCARC = BVCARC;
}
public 
void setBVSERC(string BVSERC){
   this.BVSERC = BVSERC;
}
public 
void setBVSUPA(string BVSUPA){
   this.BVSUPA = BVSUPA;
}
public 
void setBVTRDP(string BVTRDP){
   this.BVTRDP = BVTRDP;
}
public 
void setBVDUNS(string BVDUNS){
   this.BVDUNS = BVDUNS;
}
public 
void setBVSFID(string BVSFID){
   this.BVSFID = BVSFID;
}
public 
void setBVUSEC(string BVUSEC){
   this.BVUSEC = BVUSEC;
}
public 
void setBVSHPR(string BVSHPR){
   this.BVSHPR = BVSHPR;
}
public 
void setBVASNY(string BVASNY){
   this.BVASNY = BVASNY;
}
public 
void setBVINVY(string BVINVY){
   this.BVINVY = BVINVY;
}
public 
void setBVFLG1(string BVFLG1){
   this.BVFLG1 = BVFLG1;
}
public 
void setBVFLG2(string BVFLG2){
   this.BVFLG2 = BVFLG2;
}
public 
void setBVFLG3(string BVFLG3){
   this.BVFLG3 = BVFLG3;
}
public 
void setBVFLG4(string BVFLG4){
   this.BVFLG4 = BVFLG4;
}
public 
void setBVFLG5(string BVFLG5){
   this.BVFLG5 = BVFLG5;
}
public 
void setBVFLG6(string BVFLG6){
   this.BVFLG6 = BVFLG6;
}
public 
void setBVSUMR(string BVSUMR){
   this.BVSUMR = BVSUMR;
}
public 
void setBVPLNT(string BVPLNT){
   this.BVPLNT = BVPLNT;
}
public 
void setBVDOCK(string BVDOCK){
   this.BVDOCK = BVDOCK;
}
public 
void setBVLINE(string BVLINE){
   this.BVLINE = BVLINE;
}
public 
void setBVDROP(string BVDROP){
   this.BVDROP = BVDROP;
}
public 
void setBVTMOD(string BVTMOD){
   this.BVTMOD = BVTMOD; 
}
public 
void setBVTTYP(string BVTTYP){
   this.BVTTYP = BVTTYP; 
}
public 
void setBVEQPI(string BVEQPI){
   this.BVEQPI = BVEQPI; 
}
public 
void setBVROUT(string BVROUT){
   this.BVROUT = BVROUT;
}
public 
void setBVPOOL(string BVPOOL){
   this.BVPOOL = BVPOOL; 
}
public 
void setBVPOLL(string BVPOLL){
   this.BVPOLL = BVPOLL;
}
public 
void setBVJITF(string BVJITF){
   this.BVJITF = BVJITF; 
}
public 
void setBVAPLG(string BVAPLG){
   this.BVAPLG = BVAPLG; 
}
public 
void setBVAVER(string BVAVER){
   this.BVAVER = BVAVER;
}
public 
void setBVUVER(string BVUVER){
   this.BVUVER = BVUVER;
}
public 
void setBVFOBC(string BVFOBC){
   this.BVFOBC = BVFOBC; 
}
public 
void setBVEMAL(string BVEMAL){
   this.BVEMAL = BVEMAL;
}
public 
void setBVWEB(string BVWEB){
   this.BVWEB = BVWEB; 
}
public 
void setBVFL01(string BVFL01){
   this.BVFL01 = BVFL01; 
}
public 
void setBVADJC(string BVADJC){
   this.BVADJC = BVADJC; 
}
public 
void setBVPPCL(string BVPPCL){
   this.BVPPCL = BVPPCL; 
}
public 
void setBVCDAT(DateTime BVCDAT){
   this.BVCDAT = BVCDAT;
}
public 
void setBVIBRQ(string BVIBRQ){
   this.BVIBRQ = BVIBRQ; 
}
public 
void setBVORSM(string BVORSM){
   this.BVORSM = BVORSM; 
}
public 
void setBVFL04(string BVFL04){
   this.BVFL04 = BVFL04; 
}
public 
void setBVSTAT(string BVSTAT){
   this.BVSTAT = BVSTAT; 
}
public 
void setBVREAS(string BVREAS){
   this.BVREAS = BVREAS; 
}
public 
void setBVFL05(string BVFL05){
   this.BVFL05 = BVFL05; 
}
public 
void setBVFL06(string BVFL06){
   this.BVFL06 = BVFL06; 
}
public 
void setBVFL07(string BVFL07){
   this.BVFL07 = BVFL07; 
}
public 
void setBVFL08(string BVFL08){
   this.BVFL08 = BVFL08; 
}
public 
void setBVFL09(string BVFL09){
   this.BVFL09 = BVFL09; 
}
public 
void setBVFL10(string BVFL10){
   this.BVFL10 = BVFL10; 
}
//getters
public 
decimal getBVCOMP(){
   return BVCOMP;
}
public 
string getBVCUST(){
	return BVCUST;
}
public 
string getBVNAME(){
	return BVNAME;
}
public 
string getBVADR1(){
	return BVADR1;
}
public 
string getBVADR2(){
	return BVADR2;
}
public 
string getBVADR3(){
	return BVADR3;
}
public 
string getBVADR4(){
	return BVADR4;
}
public 
string  getBVADR5(){
	return BVADR5;
}
public 
string getBVADR6(){
	return BVADR6;
}
public
string getBVADR7(){
	return BVADR7;
}
public
string getBVADR8(){
   return BVADR8;
}
public
string getBVADR9(){
   return BVADR9;
}
public
string getBVADR10(){
   return BVADR10;
}
public
string getBVPOST(){
   return BVPOST;
}
public
string getBVTELP(){
   return BVTELP;
}
public
string getBVBORD(){
   return BVBORD;
}
public
string getBVPRAR(){
   return BVPRAR;
}
public
string getBVPSTE(){
   return BVPSTE;
}
public
string getBVPRCD(){
   return BVPRCD;
}
public
string getBVPSTL(){
   return BVPSTL;
}
public
string getBVFSTE(){
   return BVFSTE;
}
public
string getBVTXGR(){
   return BVTXGR;
}
public
string getBVTXRT(){
   return BVTXRT;
}
public
string getBVPACK(){
   return BVPACK;
}
public
string getBVNU10(){
   return BVNU10;
}
public
string getBVSALM(){
   return BVSALM;
}
public
string getBVTERR(){
   return BVTERR;
}
public
string getBVSNOT(){
   return BVSNOT;
}
public
string getBVCURR(){
   return BVCURR;
}
public
string getBVSCOM(){
   return BVSCOM;
}
public
string getBVTYPE(){
   return BVTYPE;
}
public
string getBVCRLE(){
   return BVCRLE;
}
public
string getBVGSTE(){
   return BVGSTE;
}
public
decimal getBVCREL(){
   return BVCREL;
}
public
string getBVOEM(){
   return BVOEM;
}
public
string getBVLANG(){
   return BVLANG;
}
public
decimal getBVSHLT(){
   return BVSHLT;
}
public
string getBVINPO(){
   return BVINPO;
}
public
string getBVTERM(){
   return BVTERM;
}
public
string getBVSHCL(){
   return BVSHCL;
}
public
string getBV1B(){
   return BV1B;
}
public
decimal getBVDISL(){
   return BVDISL;
}
public
string getBVARCD(){
   return BVARCD;
}
public
string getBVINT(){
   return BVINT;
}
public
decimal getBVSDAY(){
   return BVSDAY;
}
public
string getBVPORQ(){
   return BVPORQ;
}
public
string getBVCLAS(){
   return BVCLAS;
}
public
string getBVPSTC(){
   return BVPSTC;
}
public
DateTime getBVLDAT(){
   return BVLDAT;
}
public
decimal getBVLINA(){
   return BVLINA;
}
public
DateTime getBVPDAT(){
   return BVPDAT;
}
public
decimal getBVLPAA(){
   return BVLPAA;
}
public
decimal getBVYTDS(){
   return BVYTDS;
}
public
decimal getBVLYTD(){
   return BVLYTD;
}
public
decimal getBVOUTB(){
   return BVOUTB;
}
public
string getBV15(){
   return BV15;
}
public
string getBVDUNN(){
   return BVDUNN;
}
public
string getBVFAX(){
   return BVFAX;
}
public
DateTime getBVMDAT(){
   return BVMDAT;
}
public
string getBVBILL(){
   return BVBILL;
}
public
string getBVGSTL(){
   return BVGSTL;
}
public
string getBV3(){
   return BV3;
}
public
decimal getBVLARA(){
   return BVLARA;
}
public
string getBVCONT(){
   return BVCONT;
}
public
string getBVSUPP(){
   return BVSUPP;
}
public
string getBVSFOR(){
   return BVSFOR;
}
public
decimal getBVSFCP(){
   return BVSFCP;
}
public
string getBVMFOR(){
   return BVMFOR;
}
public
decimal getBVMFCP(){
   return BVMFCP;
}
public
string getBVXFOR(){
   return BVXFOR;
}
public
decimal getBVXFCP(){
   return BVXFCP;
}
public
string getBVCARC(){
   return BVCARC;
}
public
string getBVSERC(){
   return BVSERC;
}
public
string getBVSUPA(){
   return BVSUPA;
}
public
string getBVTRDP(){
   return BVTRDP;
}
public
string getBVDUNS(){
   return BVDUNS;
}
public
string getBVSFID(){
   return BVSFID;
}
public
string getBVUSEC(){
   return BVUSEC;
}
public
string getBVSHPR(){
   return BVSHPR;
}
public
string getBVASNY(){
   return BVASNY;
}
public
string getBVINVY(){
   return BVINVY;
}
public
string getBVFLG1(){
   return BVFLG1;
}
public
string getBVFLG2(){
   return BVFLG2;
}
public
string getBVFLG3(){
   return BVFLG3;
}
public
string getBVFLG4(){
   return BVFLG4;
}
public
string getBVFLG5(){
   return BVFLG5;
}
public
string getBVFLG6(){
   return BVFLG6;
}
public
string getBVSUMR(){
   return BVSUMR;
}
public
string getBVPLNT(){
   return BVPLNT;
}
public
string getBVDOCK(){
   return BVDOCK;
}
public
string getBVLINE(){
   return BVLINE;
}
public
string getBVDROP(){
   return BVDROP;
}
public
string getBVTMOD(){
   return BVTMOD;
}
public
string getBVTTYP(){
   return BVTTYP;
}
public
string getBVEQPI(){
   return BVEQPI;
}
public
string getBVROUT(){
   return BVROUT;
}
public
string getBVPOOL(){
   return BVPOOL;
}
public
string getBVPOLL(){
   return BVPOLL;
}
public
string getBVJITF(){
   return BVJITF;
}
public
string getBVAPLG(){
   return BVAPLG;
}
public
string getBVAVER(){
   return BVAVER;
}
public
string getBVUVER(){
   return BVUVER;
}
public
string getBVFOBC(){
   return BVFOBC;
}
public
string getBVEMAL(){
   return BVEMAL;
}
public
string getBVWEB(){
   return BVWEB;
}
public
string getBVFL01(){
   return BVFL01;
}
public
string getBVADJC(){
   return BVADJC;
}
public
string getBVPPCL(){
   return BVPPCL;
}
public
DateTime getBVCDAT(){
   return BVCDAT;
}
public
string getBVIBRQ(){
   return BVIBRQ;
}
public
string getBVORSM(){
   return BVORSM;
}
public
string getBVFL04(){
   return BVFL04;
}
public
string getBVSTAT(){
   return BVSTAT;
}
public
string getBVREAS(){
   return BVREAS;
}
public
string getBVFL05(){
   return BVFL05;
}
public
string getBVFL06(){
   return BVFL06;
}
public
string getBVFL07(){
   return BVFL07;
}
public
string getBVFL08(){
   return BVFL08;
}
public
string getBVFL09(){
   return BVFL09;
}
public
string getBVFL10(){
   return BVFL10;
}
}//end class
}//end namespace
