using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class TrlpDataBase : GenericDataBaseElement{

private string DB;

private string SMTRPT;
private string SMSTXL;
private string SMDOCK;
private string SMCPT;
private string SMYEAR;
private string SMCUST;
private string SMLOCN;
private string SMPART;
private string SMUPDS;
private string SMUPDP;
private decimal SMORD;
private decimal SMITM;
private string SMCPO;
private DateTime SMPDAT;
private string SMCPOL;
private string SMDOK;
private string SMKANB;
private string SMSHPP;
private string SMPRDP;
private decimal SMMDLY;
private string SMREV;
private DateTime SMVDAT;
private string SMMDLT;
private string SMDFTC;
private string SMDFTP;
private string SMEXPR;
private string SMEXPP;
private string SMPLNT;
private string SMLINE;
private string SMDROP;
private string SMUNIT;
private string SMLBLF;
private decimal SMLBPB;
private string SMMSTL;
private decimal SMSTDP;
private string SMALLA;
private string SMCREL;
private DateTime SMRDAT;
private DateTime SMLDAT;
private decimal SMLQTY;
private decimal SMLCUM;
private DateTime SMTDAT;
private decimal SMLTME;
private decimal SMLSHQ;
private decimal SMCCUM;
private decimal SMPCUM;
private decimal SMFABC;
private string SMFCRL;
private DateTime SMFCDT;
private decimal SMMTLC;
private string SMMCRL;
private DateTime SMMCDT;
private string SMSREF;
private DateTime SMSDAT;
private string SMCNST;
private string SMPTYP;
private string SMCNID;
private decimal SMCKEY;
private string SMCTYP;
private string SMSTYP;
private string SMAUTG;
private string SMPGMN;
private decimal SMPGMQ;
private decimal SMPO;
private decimal SMPITM;
private string SMFLG1;
private string SMFLG2;
private string SMFLG3;
private string SMFLG4;
private string SMFLG5;
private string SMFLD1;
private string SMFLD2;
private string SMFLD3;
private string SMFLD4;
private string SMFLD5;
private string SMFLD6;
private string SMFLD7;
private string SMFLD8;


public 
TrlpDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){	
}

public override
void load(NotNullDataReader reader){	
	
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMSTEMP_DATABASE){
		this.DB = reader.GetString("DB");
	}
    this.SMTRPT = reader.GetString("SMTRPT");
    this.SMSTXL = reader.GetString("SMSTXL");
    this.SMDOCK = reader.GetString("SMDOCK");
    
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
        this.SMCPT = reader.GetString("SMCPT#");
    else
        this.SMCPT = reader.GetString("SMCPT");
        
    this.SMYEAR = reader.GetString("SMYEAR");
    this.SMCUST = reader.GetString("SMCUST");
    this.SMLOCN = reader.GetString("SMLOCN");
    this.SMPART = reader.GetString("SMPART");
    this.SMUPDS = reader.GetString("SMUPDS");
    this.SMUPDP = reader.GetString("SMUPDP");
    
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
        this.SMORD = reader.GetDecimal("SMORD#");
        this.SMITM = reader.GetDecimal("SMITM#");
        this.SMCPO = reader.GetString("SMCPO#");
    }else{
        this.SMORD = reader.GetDecimal("SMORD");
        this.SMITM = reader.GetDecimal("SMITM");
        this.SMCPO = reader.GetString("SMCPO");
    }
    this.SMPDAT = reader.GetDateTime("SMPDAT");
    this.SMCPOL = reader.GetString("SMCPOL");
    this.SMDOK = reader.GetString("SMDOK");
    this.SMKANB = reader.GetString("SMKANB");
    this.SMSHPP = reader.GetString("SMSHPP");
    this.SMPRDP = reader.GetString("SMPRDP");
    this.SMMDLY = reader.GetDecimal("SMMDLY");
    
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
        this.SMREV = reader.GetString("SMREV#");
    else
        this.SMREV = reader.GetString("SMREV");
        
    this.SMVDAT = reader.GetDateTime("SMVDAT");
    this.SMMDLT = reader.GetString("SMMDLT");
    this.SMDFTC = reader.GetString("SMDFTC");
    this.SMDFTP = reader.GetString("SMDFTP");
    this.SMEXPR = reader.GetString("SMEXPR");
    this.SMEXPP = reader.GetString("SMEXPP");
    this.SMPLNT = reader.GetString("SMPLNT");
    this.SMLINE = reader.GetString("SMLINE");
    this.SMDROP = reader.GetString("SMDROP");
    this.SMUNIT = reader.GetString("SMUNIT");
    this.SMLBLF = reader.GetString("SMLBLF");
    this.SMLBPB = reader.GetDecimal("SMLBPB");
    this.SMMSTL = reader.GetString("SMMSTL");
    this.SMSTDP = reader.GetDecimal("SMSTDP");
    this.SMALLA = reader.GetString("SMALLA");
    this.SMCREL = reader.GetString("SMCREL");
    this.SMRDAT = reader.GetDateTime("SMRDAT");
    this.SMLDAT = reader.GetDateTime("SMLDAT");
    this.SMLQTY = reader.GetDecimal("SMLQTY");
    this.SMLCUM = reader.GetDecimal("SMLCUM");
    this.SMTDAT = reader.GetDateTime("SMTDAT");
    this.SMLTME = reader.GetDecimal("SMLTME");
    this.SMLSHQ = reader.GetDecimal("SMLSHQ");
    this.SMCCUM = reader.GetDecimal("SMCCUM");
    this.SMPCUM = reader.GetDecimal("SMPCUM");
    this.SMFABC = reader.GetDecimal("SMFABC");
    this.SMFCRL = reader.GetString("SMFCRL");
    this.SMFCDT = reader.GetDateTime("SMFCDT");
    this.SMMTLC = reader.GetDecimal("SMMTLC");
    this.SMMCRL = reader.GetString("SMMCRL");
    this.SMMCDT = reader.GetDateTime("SMMCDT");
    this.SMSREF = reader.GetString("SMSREF");
    this.SMSDAT = reader.GetDateTime("SMSDAT");
    this.SMCNST = reader.GetString("SMCNST");
    this.SMPTYP = reader.GetString("SMPTYP");
    this.SMCNID = reader.GetString("SMCNID");
    this.SMCKEY = reader.GetDecimal("SMCKEY");
    this.SMCTYP = reader.GetString("SMCTYP");
    this.SMSTYP = reader.GetString("SMSTYP");
    this.SMAUTG = reader.GetString("SMAUTG");
    this.SMPGMN = reader.GetString("SMPGMN");
    this.SMPGMQ = reader.GetDecimal("SMPGMQ");
    
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
        this.SMPO= reader.GetDecimal("SMPO#");
    else
        this.SMPO= reader.GetDecimal("SMPO");
        
    this.SMPITM = reader.GetDecimal("SMPITM");
    this.SMFLG1 = reader.GetString("SMFLG1");
    this.SMFLG2 = reader.GetString("SMFLG2");
    this.SMFLG3 = reader.GetString("SMFLG3");
    this.SMFLG4 = reader.GetString("SMFLG4");
    this.SMFLG5 = reader.GetString("SMFLG5");
    this.SMFLD1 = reader.GetString("SMFLD1");
    this.SMFLD2 = reader.GetString("SMFLD2");
    this.SMFLD3 = reader.GetString("SMFLD3");
    this.SMFLD4 = reader.GetString("SMFLD4");
    this.SMFLD5 = reader.GetString("SMFLD5");
    this.SMFLD6 = reader.GetString("SMFLD6");
    this.SMFLD7 = reader.GetString("SMFLD7");
    this.SMFLD8 = reader.GetString("SMFLD8");
}

public override
void write(){
	try{
		string sql = "insert into trlp values('" +
                Converter.fixString(DB) + "', '" +
                Converter.fixString(SMTRPT) +"', '" +
                Converter.fixString(SMSTXL) +"', '" +
                Converter.fixString(SMDOCK) +"', '" +
                Converter.fixString(SMCPT) +"', '" +
                Converter.fixString(SMYEAR) +"', '" +
                Converter.fixString(SMCUST) +"', '" +
                Converter.fixString(SMLOCN) +"', '" +
                Converter.fixString(SMPART) +"', '" +
                Converter.fixString(SMUPDS) +"', '" +
                Converter.fixString(SMUPDP) +"', " +
                NumberUtil.toString(SMORD) +", " +
                NumberUtil.toString(SMITM) +", '" +
                Converter.fixString(SMCPO) +"', '" +
                DateUtil.getCompleteDateRepresentation(SMPDAT) +"', '" +
                Converter.fixString(SMCPOL) +"', '" +
                Converter.fixString(SMDOK) +"', '" +
                Converter.fixString(SMKANB) +"', '" +
                Converter.fixString(SMSHPP) +"', '" +
                Converter.fixString(SMPRDP) +"', " +
                NumberUtil.toString(SMMDLY) +", '" +
                Converter.fixString(SMREV) +"', '" +
                DateUtil.getCompleteDateRepresentation(SMVDAT) +"', '" +
                Converter.fixString(SMMDLT) +"', '" +
                Converter.fixString(SMDFTC) +"', '" +
                Converter.fixString(SMDFTP) +"', '" +
                Converter.fixString(SMEXPR) +"', '" +
                Converter.fixString(SMEXPP) +"', '" +
                Converter.fixString(SMPLNT) +"', '" +
                Converter.fixString(SMLINE) +"', '" +
                Converter.fixString(SMDROP) +"', '" +
                Converter.fixString(SMUNIT) +"', '" +
                Converter.fixString(SMLBLF) +"', " +
                NumberUtil.toString(SMLBPB) +", '" +
                Converter.fixString(SMMSTL) +"', " +
                NumberUtil.toString(SMSTDP) +", '" +
                Converter.fixString(SMALLA) +"', '" +
                Converter.fixString(SMCREL) +"', '" +
                DateUtil.getCompleteDateRepresentation(SMRDAT) +"', '" +
                DateUtil.getCompleteDateRepresentation(SMLDAT) +"', " +
                NumberUtil.toString(SMLQTY) +", " +
                NumberUtil.toString(SMLCUM) +", '" +
                DateUtil.getCompleteDateRepresentation(SMTDAT) +"', " +
                NumberUtil.toString(SMLTME) +", " +
                NumberUtil.toString(SMLSHQ) +", " +
                NumberUtil.toString(SMCCUM) +", " +
                NumberUtil.toString(SMPCUM) +", " +
                NumberUtil.toString(SMFABC) +", '" +
                Converter.fixString(SMFCRL) +"', '" +
                DateUtil.getCompleteDateRepresentation(SMFCDT) +"', " +
                NumberUtil.toString(SMMTLC) +", '" +
                Converter.fixString(SMMCRL) +"', '" +
                DateUtil.getCompleteDateRepresentation(SMMCDT) +"', '" +
                Converter.fixString(SMSREF) +"', '" +
                DateUtil.getCompleteDateRepresentation(SMSDAT) +"', '" +
                Converter.fixString(SMCNST) +"', '" +
                Converter.fixString(SMPTYP) +"', '" +
                Converter.fixString(SMCNID) +"', " +
                NumberUtil.toString(SMCKEY) +", '" +
                Converter.fixString(SMCTYP) +"', '" +
                Converter.fixString(SMSTYP) +"', '" +
                Converter.fixString(SMAUTG) +"', '" +
                Converter.fixString(SMPGMN) +"', " +
                NumberUtil.toString(SMPGMQ) +", " +
                NumberUtil.toString(SMPO) +", " +
                NumberUtil.toString(SMPITM) +", '" +
                Converter.fixString(SMFLG1) +"', '" +
                Converter.fixString(SMFLG2) +"', '" +
                Converter.fixString(SMFLG3) +"', '" +
                Converter.fixString(SMFLG4) +"', '" +
                Converter.fixString(SMFLG5) +"', '" +
                Converter.fixString(SMFLD1) +"', '" +
                Converter.fixString(SMFLD2) +"', '" +
                Converter.fixString(SMFLD3) +"', '" +
                Converter.fixString(SMFLD4) +"', '" +
                Converter.fixString(SMFLD5) +"', '" +
                Converter.fixString(SMFLD6) +"', '" +
                Converter.fixString(SMFLD7) +"', '" +
                Converter.fixString(SMFLD8) +"')";

        dataBaseAccess.executeUpdate(sql);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}catch(System.Exception other){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + other.Message, other);
	}
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
void setDB(string DB){
	this.DB = DB;
}

public
void setSMTRPT(string SMTRPT){
	this.SMTRPT = SMTRPT;
}

public
void setSMSTXL(string SMSTXL){
	this.SMSTXL = SMSTXL;
}

public
void setSMDOCK(string SMDOCK){
	this.SMDOCK = SMDOCK;
}

public
void setSMCPT(string SMCPT){
	this.SMCPT = SMCPT;
}

public
void setSMYEAR(string SMYEAR){
	this.SMYEAR = SMYEAR;
}

public
void setSMCUST(string SMCUST){
	this.SMCUST = SMCUST;
}

public
void setSMLOCN(string SMLOCN){
	this.SMLOCN = SMLOCN;
}

public
void setSMPART(string SMPART){
	this.SMPART = SMPART;
}

public
void setSMUPDS(string SMUPDS){
	this.SMUPDS = SMUPDS;
}

public
void setSMUPDP(string SMUPDP){
	this.SMUPDP = SMUPDP;
}

public
void setSMORD(decimal SMORD){
	this.SMORD = SMORD;
}

public
void setSMITM(decimal SMITM){
	this.SMITM = SMITM;
}

public
void setSMCPO(string SMCPO){
	this.SMCPO = SMCPO;
}

public
void setSMPDAT(DateTime SMPDAT){
	this.SMPDAT = SMPDAT;
}

public
void setSMCPOL(string SMCPOL){
	this.SMCPOL = SMCPOL;
}

public
void setSMDOK(string SMDOK){
	this.SMDOK = SMDOK;
}

public
void setSMKANB(string SMKANB){
	this.SMKANB = SMKANB;
}

public
void setSMSHPP(string SMSHPP){
	this.SMSHPP = SMSHPP;
}

public
void setSMPRDP(string SMPRDP){
	this.SMPRDP = SMPRDP;
}

public
void setSMMDLY(decimal SMMDLY){
	this.SMMDLY = SMMDLY;
}

public
void setSMREV(string SMREV){
	this.SMREV = SMREV;
}

public
void setSMVDAT(DateTime SMVDAT){
	this.SMVDAT = SMVDAT;
}

public
void setSMMDLT(string SMMDLT){
	this.SMMDLT = SMMDLT;
}

public
void setSMDFTC(string SMDFTC){
	this.SMDFTC = SMDFTC;
}

public
void setSMDFTP(string SMDFTP){
	this.SMDFTP = SMDFTP;
}

public
void setSMEXPR(string SMEXPR){
	this.SMEXPR = SMEXPR;
}

public
void setSMEXPP(string SMEXPP){
	this.SMEXPP = SMEXPP;
}

public
void setSMPLNT(string SMPLNT){
	this.SMPLNT = SMPLNT;
}

public
void setSMLINE(string SMLINE){
	this.SMLINE = SMLINE;
}

public
void setSMDROP(string SMDROP){
	this.SMDROP = SMDROP;
}

public
void setSMUNIT(string SMUNIT){
	this.SMUNIT = SMUNIT;
}

public
void setSMLBLF(string SMLBLF){
	this.SMLBLF = SMLBLF;
}

public
void setSMLBPB(decimal SMLBPB){
	this.SMLBPB = SMLBPB;
}

public
void setSMMSTL(string SMMSTL){
	this.SMMSTL = SMMSTL;
}

public
void setSMSTDP(decimal SMSTDP){
	this.SMSTDP = SMSTDP;
}

public
void setSMALLA(string SMALLA){
	this.SMALLA = SMALLA;
}

public
void setSMCREL(string SMCREL){
	this.SMCREL = SMCREL;
}

public
void setSMRDAT(DateTime SMRDAT){
	this.SMRDAT = SMRDAT;
}

public
void setSMLDAT(DateTime SMLDAT){
	this.SMLDAT = SMLDAT;
}

public
void setSMLQTY(decimal SMLQTY){
	this.SMLQTY = SMLQTY;
}

public
void setSMLCUM(decimal SMLCUM){
	this.SMLCUM = SMLCUM;
}

public
void setSMTDAT(DateTime SMTDAT){
	this.SMTDAT = SMTDAT;
}

public
void setSMLTME(decimal SMLTME){
	this.SMLTME = SMLTME;
}

public
void setSMLSHQ(decimal SMLSHQ){
	this.SMLSHQ = SMLSHQ;
}

public
void setSMCCUM(decimal SMCCUM){
	this.SMCCUM = SMCCUM;
}

public
void setSMPCUM(decimal SMPCUM){
	this.SMPCUM = SMPCUM;
}

public
void setSMFABC(decimal SMFABC){
	this.SMFABC = SMFABC;
}

public
void setSMFCRL(string SMFCRL){
	this.SMFCRL = SMFCRL;
}

public
void setSMFCDT(DateTime SMFCDT){
	this.SMFCDT = SMFCDT;
}

public
void setSMMTLC(decimal SMMTLC){
	this.SMMTLC = SMMTLC;
}

public
void setSMMCRL(string SMMCRL){
	this.SMMCRL = SMMCRL;
}

public
void setSMMCDT(DateTime SMMCDT){
	this.SMMCDT = SMMCDT;
}

public
void setSMSREF(string SMSREF){
	this.SMSREF = SMSREF;
}

public
void setSMSDAT(DateTime SMSDAT){
	this.SMSDAT = SMSDAT;
}

public
void setSMCNST(string SMCNST){
	this.SMCNST = SMCNST;
}

public
void setSMPTYP(string SMPTYP){
	this.SMPTYP = SMPTYP;
}

public
void setSMCNID(string SMCNID){
	this.SMCNID = SMCNID;
}

public
void setSMCKEY(decimal SMCKEY){
	this.SMCKEY = SMCKEY;
}

public
void setSMCTYP(string SMCTYP){
	this.SMCTYP = SMCTYP;
}

public
void setSMSTYP(string SMSTYP){
	this.SMSTYP = SMSTYP;
}

public
void setSMAUTG(string SMAUTG){
	this.SMAUTG = SMAUTG;
}

public
void setSMPGMN(string SMPGMN){
	this.SMPGMN = SMPGMN;
}

public
void setSMPGMQ(decimal SMPGMQ){
	this.SMPGMQ = SMPGMQ;
}

public
void setSMPO(decimal SMPO){
	this.SMPO = SMPO;
}

public
void setSMPITM(decimal SMPITM){
	this.SMPITM = SMPITM;
}

public
void setSMFLG1(string SMFLG1){
	this.SMFLG1 = SMFLG1;
}

public
void setSMFLG2(string SMFLG2){
	this.SMFLG2 = SMFLG2;
}

public
void setSMFLG3(string SMFLG3){
	this.SMFLG3 = SMFLG3;
}

public
void setSMFLG4(string SMFLG4){
	this.SMFLG4 = SMFLG4;
}

public
void setSMFLG5(string SMFLG5){
	this.SMFLG5 = SMFLG5;
}

public
void setSMFLD1(string SMFLD1){
	this.SMFLD1 = SMFLD1;
}

public
void setSMFLD2(string SMFLD2){
	this.SMFLD2 = SMFLD2;
}

public
void setSMFLD3(string SMFLD3){
	this.SMFLD3 = SMFLD3;
}

public
void setSMFLD4(string SMFLD4){
	this.SMFLD4 = SMFLD4;
}

public
void setSMFLD5(string SMFLD5){
	this.SMFLD5 = SMFLD5;
}

public
void setSMFLD6(string SMFLD6){
	this.SMFLD6 = SMFLD6;
}

public
void setSMFLD7(string SMFLD7){
	this.SMFLD7 = SMFLD7;
}

public
void setSMFLD8(string SMFLD8){
	this.SMFLD8 = SMFLD8;
}


public
string getDB(){
	return DB;
}

public
string getSMTRPT(){
	return SMTRPT;
}

public
string getSMSTXL(){
	return SMSTXL;
}

public
string getSMDOCK(){
	return SMDOCK;
}

public
string getSMCPT(){
	return SMCPT;
}

public
string getSMYEAR(){
	return SMYEAR;
}

public
string getSMCUST(){
	return SMCUST;
}

public
string getSMLOCN(){
	return SMLOCN;
}

public
string getSMPART(){
	return SMPART;
}

public
string getSMUPDS(){
	return SMUPDS;
}

public
string getSMUPDP(){
	return SMUPDP;
}

public
decimal getSMORD(){
	return SMORD;
}

public
decimal getSMITM(){
	return SMITM;
}

public
string getSMCPO(){
	return SMCPO;
}

public
DateTime getSMPDAT(){
	return SMPDAT;
}

public
string getSMCPOL(){
	return SMCPOL;
}

public
string getSMDOK(){
	return SMDOK;
}

public
string getSMKANB(){
	return SMKANB;
}

public
string getSMSHPP(){
	return SMSHPP;
}

public
string getSMPRDP(){
	return SMPRDP;
}

public
decimal getSMMDLY(){
	return SMMDLY;
}

public
string getSMREV(){
	return SMREV;
}

public
DateTime getSMVDAT(){
	return SMVDAT;
}

public
string getSMMDLT(){
	return SMMDLT;
}

public
string getSMDFTC(){
	return SMDFTC;
}

public
string getSMDFTP(){
	return SMDFTP;
}

public
string getSMEXPR(){
	return SMEXPR;
}

public
string getSMEXPP(){
	return SMEXPP;
}

public
string getSMPLNT(){
	return SMPLNT;
}

public
string getSMLINE(){
	return SMLINE;
}

public
string getSMDROP(){
	return SMDROP;
}

public
string getSMUNIT(){
	return SMUNIT;
}

public
string getSMLBLF(){
	return SMLBLF;
}

public
decimal getSMLBPB(){
	return SMLBPB;
}

public
string getSMMSTL(){
	return SMMSTL;
}

public
decimal getSMSTDP(){
	return SMSTDP;
}

public
string getSMALLA(){
	return SMALLA;
}

public
string getSMCREL(){
	return SMCREL;
}

public
DateTime getSMRDAT(){
	return SMRDAT;
}

public
DateTime getSMLDAT(){
	return SMLDAT;
}

public
decimal getSMLQTY(){
	return SMLQTY;
}

public
decimal getSMLCUM(){
	return SMLCUM;
}

public
DateTime getSMTDAT(){
	return SMTDAT;
}

public
decimal getSMLTME(){
	return SMLTME;
}

public
decimal getSMLSHQ(){
	return SMLSHQ;
}

public
decimal getSMCCUM(){
	return SMCCUM;
}

public
decimal getSMPCUM(){
	return SMPCUM;
}

public
decimal getSMFABC(){
	return SMFABC;
}

public
string getSMFCRL(){
	return SMFCRL;
}

public
DateTime getSMFCDT(){
	return SMFCDT;
}

public
decimal getSMMTLC(){
	return SMMTLC;
}

public
string getSMMCRL(){
	return SMMCRL;
}

public
DateTime getSMMCDT(){
	return SMMCDT;
}

public
string getSMSREF(){
	return SMSREF;
}

public
DateTime getSMSDAT(){
	return SMSDAT;
}

public
string getSMCNST(){
	return SMCNST;
}

public
string getSMPTYP(){
	return SMPTYP;
}

public
string getSMCNID(){
	return SMCNID;
}

public
decimal getSMCKEY(){
	return SMCKEY;
}

public
string getSMCTYP(){
	return SMCTYP;
}

public
string getSMSTYP(){
	return SMSTYP;
}

public
string getSMAUTG(){
	return SMAUTG;
}

public
string getSMPGMN(){
	return SMPGMN;
}

public
decimal getSMPGMQ(){
	return SMPGMQ;
}

public
decimal getSMPO(){
	return SMPO;
}

public
decimal getSMPITM(){
	return SMPITM;
}

public
string getSMFLG1(){
	return SMFLG1;
}

public
string getSMFLG2(){
	return SMFLG2;
}

public
string getSMFLG3(){
	return SMFLG3;
}

public
string getSMFLG4(){
	return SMFLG4;
}

public
string getSMFLG5(){
	return SMFLG5;
}

public
string getSMFLD1(){
	return SMFLD1;
}

public
string getSMFLD2(){
	return SMFLD2;
}

public
string getSMFLD3(){
	return SMFLD3;
}

public
string getSMFLD4(){
	return SMFLD4;
}

public
string getSMFLD5(){
	return SMFLD5;
}

public
string getSMFLD6(){
	return SMFLD6;
}

public
string getSMFLD7(){
	return SMFLD7;
}

public
string getSMFLD8(){
	return SMFLD8;
}

}//end class

}//end namespace
