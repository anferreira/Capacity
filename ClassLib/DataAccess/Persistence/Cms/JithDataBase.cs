using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{
public 
class JithDataBase : GenericDataBaseElement{
//used in CMSTemp
private string DB;
//----------------
private decimal SPKEYN;
private string SPTRPT;
private string SPSTXL;
private string SPCPT;
private string SPREF;
private string SPSETP;
private string SPREL;
private DateTime SPSDAT;
private DateTime SPEDAT;
private DateTime SPRDAT;
private string SPDOK;
private string SPINTC;
private string SPCPO;
private decimal SPLOG;
private decimal SPLIN;
private decimal SPOEMC;
private decimal SPOEMS;
private decimal SPLRCQ;
private DateTime SPLDAT;
private string SPLSHI ;
private decimal SPYTDC;
private decimal SPFABC;
private decimal SPMTLC;
private decimal SPCUMD;
private string SPCUME;
private string SPDTYP;
private string SPQTYP;
private string SPSCAC;
private string SPFUT1;
private string SPFUT2;
private string SPFUT3;
private string SPFUT4;
private string SPFUT5;
private string SPFUT6;
private string SPCRCM;
public 
JithDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMSTEMP_DATABASE)
	    this.DB = reader.GetString("DB");
    
    this.SPKEYN = reader.GetDecimal("SPKEYN");
    this.SPTRPT = reader.GetString("SPTRPT");
    this.SPSTXL = reader.GetString("SPSTXL");
    
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
        this.SPCPT = reader.GetString("SPCPT#");
        this.SPREF = reader.GetString("SPREF#");
    }else{
        this.SPCPT = reader.GetString("SPCPT");
        this.SPREF = reader.GetString("SPREF");
    }
    
    this.SPSETP = reader.GetString("SPSETP");
    
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
        this.SPREL = reader.GetString("SPREL#");
    else
        this.SPREL = reader.GetString("SPREL");
    
    this.SPSDAT = reader.GetDateTime("SPSDAT");
    this.SPEDAT = reader.GetDateTime("SPEDAT");
    this.SPRDAT = reader.GetDateTime("SPRDAT");
    this.SPDOK = reader.GetString("SPDOK");
    this.SPINTC = reader.GetString("SPINTC");
    
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
        this.SPCPO = reader.GetString("SPCPO#");
        this.SPLOG = reader.GetDecimal("SPLOG#");
        this.SPLIN = reader.GetDecimal("SPLIN#");
    }else{
        this.SPCPO = reader.GetString("SPCPO");
        this.SPLOG = reader.GetDecimal("SPLOG");
        this.SPLIN = reader.GetDecimal("SPLIN");
    }
    
    this.SPOEMC = reader.GetDecimal("SPOEMC");
    this.SPOEMS = reader.GetDecimal("SPOEMS");
    this.SPLRCQ = reader.GetDecimal("SPLRCQ");
    this.SPLDAT = reader.GetDateTime("SPLDAT");
    this.SPLSHI  = reader.GetString("SPLSHI ");
    this.SPYTDC = reader.GetDecimal("SPYTDC");
    this.SPFABC = reader.GetDecimal("SPFABC");
    this.SPMTLC = reader.GetDecimal("SPMTLC");
    this.SPCUMD = reader.GetDecimal("SPCUMD");
    this.SPCUME = reader.GetString("SPCUME");
    this.SPDTYP = reader.GetString("SPDTYP");
    this.SPQTYP = reader.GetString("SPQTYP");
    this.SPSCAC = reader.GetString("SPSCAC");
    this.SPFUT1 = reader.GetString("SPFUT1");
    this.SPFUT2 = reader.GetString("SPFUT2");
    this.SPFUT3 = reader.GetString("SPFUT3");
    this.SPFUT4 = reader.GetString("SPFUT4");
    this.SPFUT5 = reader.GetString("SPFUT5");
    this.SPFUT6 = reader.GetString("SPFUT6");
    this.SPCRCM = reader.GetString("SPCRCM");
}
public override
void write(){

		string sql = "insert into jith values('" +
		            Converter.fixString(DB) + "', " + 
                    NumberUtil.toString(SPKEYN) +", '" +
                    Converter.fixString(SPTRPT) +"', '" +
                    Converter.fixString(SPSTXL) +"', '" +
                    Converter.fixString(SPCPT) +"', '" +
                    Converter.fixString(SPREF) +"', '" +
                    Converter.fixString(SPSETP) +"', '" +
                    Converter.fixString(SPREL) +"', '" +
                    DateUtil.getCompleteDateRepresentation(SPSDAT) +"', '" +
                    DateUtil.getCompleteDateRepresentation(SPEDAT) +"', '" +
                    DateUtil.getCompleteDateRepresentation(SPRDAT) +"', '" +
                    Converter.fixString(SPDOK) +"', '" +
                    Converter.fixString(SPINTC) +"', '" +
                    Converter.fixString(SPCPO) +"', " +
                    NumberUtil.toString(SPLOG) +", " +
                    NumberUtil.toString(SPLIN) +", " +
                    NumberUtil.toString(SPOEMC) +", " +
                    NumberUtil.toString(SPOEMS) +", " +
                    NumberUtil.toString(SPLRCQ) +", '" +
                    DateUtil.getCompleteDateRepresentation(SPLDAT) +"', '" +
                    Converter.fixString(SPLSHI ) +"', " +
                    NumberUtil.toString(SPYTDC) +", " +
                    NumberUtil.toString(SPFABC) +", " +
                    NumberUtil.toString(SPMTLC) +", " +
                    NumberUtil.toString(SPCUMD) +", '" +
                    Converter.fixString(SPCUME) +"', '" +
                    Converter.fixString(SPDTYP) +"', '" +
                    Converter.fixString(SPQTYP) +"', '" +
                    Converter.fixString(SPSCAC) +"', '" +
                    Converter.fixString(SPFUT1) +"', '" +
                    Converter.fixString(SPFUT2) +"', '" +
                    Converter.fixString(SPFUT3) +"', '" +
                    Converter.fixString(SPFUT4) +"', '" +
                    Converter.fixString(SPFUT5) +"', '" +
                    Converter.fixString(SPFUT6) +"', '" +
                    Converter.fixString(SPCRCM) +"')";
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
//Setters
public 
void setSPKEYN(decimal SPKEYN){
    this.SPKEYN = SPKEYN;
}
public 
void setSPTRPT(string SPTRPT){
    this.SPTRPT = SPTRPT;
}
public 
void setSPSTXL(string SPSTXL){
    this.SPSTXL = SPSTXL;
}
public 
void setSPCPT(string SPCPT){
    this.SPCPT = SPCPT;
}
public 
void setSPREF(string SPREF){
    this.SPREF = SPREF;
}
public 
void setSPSETP(string SPSETP){
    this.SPSETP = SPSETP;
}
public 
void setSPREL(string SPREL){
    this.SPREL = SPREL;
}
public 
void setSPSDAT(DateTime SPSDAT){
    this.SPSDAT = SPSDAT;
}
public 
void setSPEDAT(DateTime SPEDAT){
    this.SPEDAT = SPEDAT;
}
public 
void setSPRDAT(DateTime SPRDAT){
    this.SPRDAT = SPRDAT;
}
public 
void setSPDOK(string SPDOK){
    this.SPDOK = SPDOK;
}
public 
void setSPINTC(string SPINTC){
    this.SPINTC = SPINTC;
}
public 
void setSPCPO(string SPCPO){
    this.SPCPO = SPCPO;
}
public 
void setSPLOG(decimal SPLOG){
    this.SPLOG = SPLOG;
}
public 
void setSPLIN(decimal SPLIN){
    this.SPLIN = SPLIN;
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
void setSPLRCQ(decimal SPLRCQ){
    this.SPLRCQ = SPLRCQ;
}
public 
void setaSPLDAT(DateTime SPLDAT){
    this.SPLDAT = SPLDAT;
}
public 
void setSPLSHI(string SPLSHI ){
    this.SPLSHI = SPLSHI ;
}
public 
void setSPYTDC(decimal SPYTDC){
    this.SPYTDC = SPYTDC;
}
public 
void setSPFABC(decimal SPFABC){
    this.SPFABC = SPFABC;
}
public 
void setSPMTLC(decimal SPMTLC){
    this.SPMTLC = SPMTLC;
}
public 
void setSPCUMD(decimal SPCUMD){
    this.SPCUMD = SPCUMD;
}
public 
void setSPCUME(string SPCUME){
    this.SPCUME = SPCUME;
}
public 
void setSPDTYP(string SPDTYP){
    this.SPDTYP = SPDTYP;
}
public 
void setSPQTYP(string SPQTYP){
    this.SPQTYP = SPQTYP;
}
public 
void setSPSCAC(string SPSCAC){
    this.SPSCAC = SPSCAC;
}
public 
void setSPFUT1(string SPFUT1){
    this.SPFUT1 = SPFUT1;
}
public 
void setSPFUT2(string SPFUT2){
    this.SPFUT2 = SPFUT2;
}
public 
void setSPFUT3(string SPFUT3){
    this.SPFUT3 = SPFUT3;
}
public 
void setSPFUT4(string SPFUT4){
    this.SPFUT4 = SPFUT4;
}
public 
void setSPFUT5(string SPFUT5){
    this.SPFUT5 = SPFUT5;
}
public 
void setSPFUT6(string SPFUT6){
    this.SPFUT6 = SPFUT6;
}
public 
void setSPCRCM(string SPCRCM){
    this.SPCRCM = SPCRCM;
}
public 
void setDB(string DB){
    this.DB = DB;
}
//Getters
public 
decimal getSPKEYN(){
    return SPKEYN;
}
public 
string getSPTRPT(){
    return SPTRPT;
}
public 
string getSPSTXL(){
    return SPSTXL;
}
public 
string getSPCPT(){
    return SPCPT;
}
public 
string getSPREF(){
    return SPREF;
}
public 
string getSPSETP(){
    return SPSETP;
}
public 
string getSPREL(){
    return SPREL;
}
public 
DateTime getSPSDAT(){
    return SPSDAT;
}
public 
DateTime getSPEDAT(){
    return SPEDAT;
}
public 
DateTime getSPRDAT(){
    return SPRDAT;
}
public 
string getSPDOK(){
    return SPDOK;
}
public 
string getSPINTC(){
    return SPINTC;
}
public 
string getSPCPO(){
    return SPCPO;
}
public 
decimal getSPLOG(){
    return SPLOG;
}
public 
decimal getSPLIN(){
    return SPLIN;
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
decimal getSPLRCQ(){
    return SPLRCQ;
}
public 
DateTime getSPLDAT(){
    return SPLDAT;
}
public 
string getSPLSHI (){
    return SPLSHI ;
}
public 
decimal getSPYTDC(){
    return SPYTDC;
}
public 
decimal getSPFABC(){
    return SPFABC;
}
public 
decimal getSPMTLC(){
    return SPMTLC;
}
public 
decimal getSPCUMD(){
    return SPCUMD;
}
public 
string getSPCUME(){
    return SPCUME;
}
public 
string getSPDTYP(){
    return SPDTYP;
}
public 
string getSPQTYP(){
    return SPQTYP;
}
public 
string getSPSCAC(){
    return SPSCAC;
}
public 
string getSPFUT1(){
    return SPFUT1;
}
public 
string getSPFUT2(){
    return SPFUT2;
}
public 
string getSPFUT3(){
    return SPFUT3;
}
public 
string getSPFUT4(){
    return SPFUT4;
}
public 
string getSPFUT5(){
    return SPFUT5;
}
public 
string getSPFUT6(){
    return SPFUT6;
}
public 
string getSPCRCM(){
    return SPCRCM;
}
public 
string getDB(){
    return DB;
}
        /*
public
bool getPriorRelease(string stpartner,string srelease,string shipToLoc,string spart,decimal dcum){ 
    string sqlGeneric   =   " from " + getTablePrefix() + "jith jh, " + getTablePrefix() + "RRLD as rd " +
                            " where OZTRPT ='" + Converter.fixString(stpartner) + "'" +
                              (!string.IsNullOrEmpty(shipToLoc) ? " and OZSTXL= '" + Converter.fixString(shipToLoc) + "' " : "");

    string sqlPart      =   " OZCPT#= '" + spart + "'";
    string sqlHdrDtlJOin=   " rh.OZKEYN=rd.PLKEYN and rh.OZREL#=rd.PLREL# ";

    string sql          =   "select * " + sqlGeneric + " and "   + sqlPart +  " and rd.PLQCUM < ";

    
    string sqlSubQuery =    "select min(rd.PLQCUM)" + sqlGeneric +     
                            " and OZREL#='" + Converter.fixString(srelease) + "' and " + sqlPart + " and " + sqlHdrDtlJOin;
    
    sql+= " (" + sqlSubQuery  + ") and "  + sqlHdrDtlJOin;
    sql+= " order by rh.OZLOG# desc";
    sql = DBFormatter.selectTopRows(sql,1);

    return read(sql);
}*/

public
bool getPriorRelease(string stpartner,string sreference,string shipToLoc,string spart){ 
   string sqlGeneric = " from " + getTablePrefix() + "jith jh where SPTRPT ='" + Converter.fixString(stpartner) + "'" +
                    (!string.IsNullOrEmpty(shipToLoc)? " and SPSTXL= '" + Converter.fixString(shipToLoc) + "'" : "") +
                    (!string.IsNullOrEmpty(spart)    ? " and SPCPT#= '" + Converter.fixString(spart) + "'" : "");

    string  sql  = "select * " + sqlGeneric + " and SPLOG# < (select min(SPLOG#) " + sqlGeneric +
                    " and SPREF#  ='" + Converter.fixString(sreference) + "')";

    sql+= " order by SPLOG# desc ";
    sql = DBFormatter.selectTopRows(sql,1);
            
    return read(sql);
}

public
bool getPriorRelease(string stpartner,string sreference,string shipToLoc,string spart,decimal dminorThanLog,string sameLogReferenceBigger){ 
   string sqlGeneric = " from " + getTablePrefix() + "jith jh where " + DBFormatter.equalLikeSql("SPTRPT", stpartner) +
                    (!string.IsNullOrEmpty(shipToLoc)? " and " + DBFormatter.equalLikeSql("SPSTXL", shipToLoc)  : "") +
                    (!string.IsNullOrEmpty(spart)    ? " and " + DBFormatter.equalLikeSql("SPCPT#", spart)      : "");

    string  sqlLog = "";
    if (dminorThanLog != decimal.MinValue){
        sqlLog =  " and (SPLOG# < " + NumberUtil.toString(dminorThanLog);
        if (!string.IsNullOrEmpty(sameLogReferenceBigger))
            sqlLog+= " or (SPLOG# = " + NumberUtil.toString(dminorThanLog) + " and SPREF# < '" + Converter.fixString(sameLogReferenceBigger) +"')";
        sqlLog+=")";

        sqlLog+= " and SPREF# <>''";
    }

    string  sql  = "select * " + sqlGeneric + sqlLog;
                                    
    sql+= " order by SPLOG# desc,SPREF# desc";
    sql = DBFormatter.selectTopRows(sql,1);
            
    return read(sql);
}
}
}
