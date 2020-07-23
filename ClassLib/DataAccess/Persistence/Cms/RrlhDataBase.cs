using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{
public 
class RrlhDataBase: GenericDataBaseElement{
private string DB;
private decimal	OZKEYN;
private string OZTRPT;
private string OZSTXL;
private string OZCPT;
private string OZREL;
private string OZMTL;
private DateTime OZSDAT;
private DateTime OZEDAT;
private DateTime OZIDAT;
private string OZSETP;
private string OZINTC;
private string OZCPO;
private string OZPLNT;
private string OZDOK;
private string OZLINE;
private string OZDROP;
private string OZSRCE;
private decimal	OZLOG;
private decimal	OZLIN;
private decimal	OZYTDC;
private decimal	OZOEMC;
private decimal	OZOEMS;
private decimal	OZFABC;
private decimal	OZMTLC;
private decimal	OZRCVQ;
private DateTime OZLDAT;
private string OZLSHI;
private decimal OZCUMD;
private string OZCUME;
private string OZDTYP;
private string OZQTYP;
private string OZRELT;
private string OZPSTS;
private string OZSCAC;
private string OZFUT1;
private string OZFUT2;
private string OZFUT3;
private string OZFUT4;
private string OZFUT5;
private string OZFUT6;
private string OZCRCM;
public 
RrlhDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
public override
void load(NotNullDataReader reader){
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMSTEMP_DATABASE){
		this.DB = reader.GetString("DB");
	}
    this.OZKEYN = reader.GetDecimal("OZKEYN");
    this.OZTRPT = reader.GetString("OZTRPT");
    this.OZSTXL = reader.GetString("OZSTXL");
    
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
        this.OZCPT = reader.GetString("OZCPT#");
        this.OZREL = reader.GetString("OZREL#");
        this.OZMTL = reader.GetString("OZMTL#");
    }else{
        this.OZCPT = reader.GetString("OZCPT");
        this.OZREL = reader.GetString("OZREL");
        this.OZMTL = reader.GetString("OZMTL");
    }
    this.OZSDAT = reader.GetDateTime("OZSDAT");
    this.OZEDAT = reader.GetDateTime("OZEDAT");
    this.OZIDAT = reader.GetDateTime("OZIDAT");
    this.OZSETP = reader.GetString("OZSETP");
    this.OZINTC = reader.GetString("OZINTC");
    
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
        this.OZCPO = reader.GetString("OZCPO#");
    else
        this.OZCPO = reader.GetString("OZCPO");
        
    this.OZPLNT = reader.GetString("OZPLNT");
    this.OZDOK = reader.GetString("OZDOK");
    this.OZLINE = reader.GetString("OZLINE");
    this.OZDROP = reader.GetString("OZDROP");
    this.OZSRCE = reader.GetString("OZSRCE");
    
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
        this.OZLOG = reader.GetDecimal("OZLOG#");
        this.OZLIN = reader.GetDecimal("OZLIN#");
    }else{
        this.OZLOG = reader.GetDecimal("OZLOG");
        this.OZLIN = reader.GetDecimal("OZLIN");
    }
    this.OZYTDC = reader.GetDecimal("OZYTDC");
    this.OZOEMC = reader.GetDecimal("OZOEMC");
    this.OZOEMS = reader.GetDecimal("OZOEMS");
    this.OZFABC = reader.GetDecimal("OZFABC");
    this.OZMTLC = reader.GetDecimal("OZMTLC");
    this.OZRCVQ = reader.GetDecimal("OZRCVQ");
    this.OZLDAT = reader.GetDateTime("OZLDAT");
    this.OZLSHI = reader.GetString("OZLSHI");
    this.OZCUMD = reader.GetDecimal("OZCUMD");
    this.OZCUME = reader.GetString("OZCUME");
    this.OZDTYP = reader.GetString("OZDTYP");
    this.OZQTYP = reader.GetString("OZQTYP");
    this.OZRELT = reader.GetString("OZRELT");
    this.OZPSTS = reader.GetString("OZPSTS");
    this.OZSCAC = reader.GetString("OZSCAC");
    this.OZFUT1 = reader.GetString("OZFUT1");
    this.OZFUT2 = reader.GetString("OZFUT2");
    this.OZFUT3 = reader.GetString("OZFUT3");
    this.OZFUT4 = reader.GetString("OZFUT4");
    this.OZFUT5 = reader.GetString("OZFUT5");
    this.OZFUT6 = reader.GetString("OZFUT6");
    this.OZCRCM = reader.GetString("OZCRCM");
}
public override
void write(){
	try{
		string sql = "insert into rrlh values('" +
		            Converter.fixString(DB) +"', " + 
                    NumberUtil.toString(OZKEYN) +", '" +
                    Converter.fixString(OZTRPT) +"', '" +
                    Converter.fixString(OZSTXL) +"', '" +
                    Converter.fixString(OZCPT) +"', '" +
                    Converter.fixString(OZREL) +"', '" +
                    Converter.fixString(OZMTL) +"', '" +
                    DateUtil.getCompleteDateRepresentation(OZSDAT) +"', '" +
                    DateUtil.getCompleteDateRepresentation(OZEDAT) +"', '" +
                    DateUtil.getCompleteDateRepresentation(OZIDAT) +"', '" +
                    Converter.fixString(OZSETP) +"', '" +
                    Converter.fixString(OZINTC) +"', '" +
                    Converter.fixString(OZCPO) +"', '" +
                    Converter.fixString(OZPLNT) +"', '" +
                    Converter.fixString(OZDOK) +"', '" +
                    Converter.fixString(OZLINE) +"', '" +
                    Converter.fixString(OZDROP) +"', '" +
                    Converter.fixString(OZSRCE) +"', " +
                    NumberUtil.toString(OZLOG) +", " +
                    NumberUtil.toString(OZLIN) +", " +
                    NumberUtil.toString(OZYTDC) +", " +
                    NumberUtil.toString(OZOEMC) +", " +
                    NumberUtil.toString(OZOEMS) +", " +
                    NumberUtil.toString(OZFABC) +", " +
                    NumberUtil.toString(OZMTLC) +", " +
                    NumberUtil.toString(OZRCVQ) +", '" +
                    DateUtil.getCompleteDateRepresentation(OZLDAT) +"', '" +
                    Converter.fixString(OZLSHI) +"', " +
                    NumberUtil.toString(OZCUMD) +", '" +
                    Converter.fixString(OZCUME) +"', '" +
                    Converter.fixString(OZDTYP) +"', '" +
                    Converter.fixString(OZQTYP) +"', '" +
                    Converter.fixString(OZRELT) +"', '" +
                    Converter.fixString(OZPSTS) +"', '" +
                    Converter.fixString(OZSCAC) +"', '" +
                    Converter.fixString(OZFUT1) +"', '" +
                    Converter.fixString(OZFUT2) +"', '" +
                    Converter.fixString(OZFUT3) +"', '" +
                    Converter.fixString(OZFUT4) +"', '" +
                    Converter.fixString(OZFUT5) +"', '" +
                    Converter.fixString(OZFUT6) +"', '" +
                    Converter.fixString(OZCRCM) +"')";
         dataBaseAccess.executeUpdate(sql);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
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
//Setters
public 
void setDB(string DB){
    this.DB = DB;
}
public 
void setOZKEYN(decimal OZKEYN){
    this.OZKEYN = OZKEYN;
}
public 
void setOZTRPT(string OZTRPT){
    this.OZTRPT = OZTRPT;
}
public 
void setOZSTXL(string OZSTXL){
    this.OZSTXL = OZSTXL;
}
public 
void setOZCPT(string OZCPT){
    this.OZCPT = OZCPT;
}
public 
void setOZREL(string OZREL){
    this.OZREL = OZREL;
}
public 
void setOZMTL(string OZMTL){
    this.OZMTL = OZMTL;
}
public 
void setOZSDAT(DateTime OZSDAT){
    this.OZSDAT = OZSDAT;
}
public 
void setOZEDAT(DateTime OZEDAT){
    this.OZEDAT = OZEDAT;
}
public 
void setOZIDAT(DateTime OZIDAT){
    this.OZIDAT = OZIDAT;
}
public 
void setOZSETP(string OZSETP){
    this.OZSETP = OZSETP;
}
public 
void setOZINTC(string OZINTC){
    this.OZINTC = OZINTC;
}
public 
void setOZCPO(string OZCPO){
    this.OZCPO = OZCPO;
}
public 
void setOZPLNT(string OZPLNT){
    this.OZPLNT = OZPLNT;
}
public 
void setOZDOK(string OZDOK){
    this.OZDOK = OZDOK;
}
public 
void setOZLINE(string OZLINE){
    this.OZLINE = OZLINE;
}
public 
void setOZDROP(string OZDROP){
    this.OZDROP = OZDROP;
}
public 
void setOZSRCE(string OZSRCE){
    this.OZSRCE = OZSRCE;
}
public 
void setOZLOG(decimal OZLOG){
    this.OZLOG = OZLOG;
}
public 
void setOZLIN(decimal OZLIN){
    this.OZLIN = OZLIN;
}
public 
void setOZYTDC(decimal OZYTDC){
    this.OZYTDC = OZYTDC;
}
public 
void setOZOEMC(decimal	OZOEMC){
    this.OZOEMC = OZOEMC;
}
public 
void setOZOEMS(decimal	OZOEMS){
    this.OZOEMS = OZOEMS;
}
public 
void setOZFABC(decimal	OZFABC){
    this.OZFABC = OZFABC;
}
public 
void setOZMTLC(decimal	OZMTLC){
    this.OZMTLC = OZMTLC;
}
public 
void setOZRCVQ(decimal	OZRCVQ){
    this.OZRCVQ = OZRCVQ;
}
public 
void setOZLDAT(DateTime OZLDAT){
    this.OZLDAT = OZLDAT;
}
public 
void setOZLSHI(string OZLSHI){
    this.OZLSHI = OZLSHI;
}
public 
void setOZCUMD(decimal OZCUMD){
    this.OZCUMD = OZCUMD;
}
public 
void setOZCUME(string OZCUME){
    this.OZCUME = OZCUME;
}
public 
void setOZDTYP(string OZDTYP){
    this.OZDTYP = OZDTYP;
}
public 
void setOZQTYP(string OZQTYP){
    this.OZQTYP = OZQTYP;
}
public 
void setOZRELT(string OZRELT){
    this.OZRELT = OZRELT;
}
public 
void setOZPSTS(string OZPSTS){
    this.OZPSTS = OZPSTS;
}
public 
void setOZSCAC(string OZSCAC){
    this.OZSCAC = OZSCAC;
}
public 
void setOZFUT1(string OZFUT1){
    this.OZFUT1 = OZFUT1;
}
public 
void setOZFUT2(string OZFUT2){
    this.OZFUT2 = OZFUT2;
}
public 
void setOZFUT3(string OZFUT3){
    this.OZFUT3 = OZFUT3;
}
public 
void setOZFUT4(string OZFUT4){
    this.OZFUT4 = OZFUT4;
}
public 
void setOZFUT5(string OZFUT5){
    this.OZFUT5 = OZFUT5;
}
public 
void setOZFUT6(string OZFUT6){
    this.OZFUT6 = OZFUT6;
}
public 
void setOZCRCM(string OZCRCM){
    this.OZCRCM = OZCRCM;
}
//Getters
public 
string getDB(){
    return DB;
}
public 
decimal	getOZKEYN(){
    return OZKEYN;
}
public 
string getOZTRPT(){
    return OZTRPT;
}
public 
string getOZSTXL(){
    return OZSTXL;
}
public 
string getOZCPT(){
    return OZCPT;
}
public 
string getOZREL(){
    return OZREL;
}
public 
string getOZMTL(){
    return OZMTL;
}
public 
DateTime getOZSDAT(){
    return OZSDAT;
}
public 
DateTime getOZEDAT(){
    return OZEDAT;
}
public 
DateTime getOZIDAT(){
    return OZIDAT;
}
public 
string getOZSETP(){
    return OZSETP;
}
public 
string getOZINTC(){
    return OZINTC;
}
public 
string getOZCPO(){
    return OZCPO;
}
public 
string getOZPLNT(){
    return OZPLNT;
}
public 
string getOZDOK(){
    return OZDOK;
}
public 
string getOZLINE(){
    return OZLINE;
}
public 
string getOZDROP(){
    return OZDROP;
}
public 
string getOZSRCE(){
    return OZSRCE;
}
public 
decimal	getOZLOG(){
    return OZLOG;
}
public 
decimal	getOZLIN(){
    return OZLIN;
}
public 
decimal	getOZYTDC(){
    return OZYTDC;
}
public 
decimal	getOZOEMC(){
    return OZOEMC;
}
public 
decimal	getOZOEMS(){
    return OZOEMS;
}
public 
decimal	getOZFABC(){
    return OZFABC;
}
public 
decimal	getOZMTLC(){
    return OZMTLC;
}
public 
decimal	getOZRCVQ(){
    return OZRCVQ;
}
public 
DateTime getOZLDAT(){
    return OZLDAT;
}
public 
string getOZLSHI(){
    return OZLSHI;
}
public 
decimal getOZCUMD(){
    return OZCUMD;
}
public 
string getOZCUME(){
    return OZCUME;
}
public 
string getOZDTYP(){
    return OZDTYP;
}
public 
string getOZQTYP(){
    return OZQTYP;
}
public 
string getOZRELT(){
    return OZRELT;
}
public 
string getOZPSTS(){
    return OZPSTS;
}
public 
string getOZSCAC(){
    return OZSCAC;
}
public 
string getOZFUT1(){
    return OZFUT1;
}
public 
string getOZFUT2(){
    return OZFUT2;
}
public 
string getOZFUT3(){
    return OZFUT3;
}
public 
string getOZFUT4(){
    return OZFUT4;
}
public 
string getOZFUT5(){
    return OZFUT5;
}
public 
string getOZFUT6(){
    return OZFUT6;
}
public 
string getOZCRCM(){
    return OZCRCM;
}

public
bool getPriorRelease(string stpartner,string srelease,string shipToLoc,string spart,decimal dcum){ 
    string sqlGeneric   =   " from " + getTablePrefix() + "RRlH rh, " + getTablePrefix() + "RRLD as rd " +
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
}

public
bool getPriorRelease(string stpartner,string srelease,string shipToLoc,string spart){ 
    string sqlGeneric = " from " + getTablePrefix() + "RRlH rh where OZTRPT ='" + Converter.fixString(stpartner) + "'" +
                    (!string.IsNullOrEmpty(shipToLoc)? " and OZSTXL= '" + Converter.fixString(shipToLoc) + "'" : "") +
                    (!string.IsNullOrEmpty(spart)    ? " and OZCPT#= '" + Converter.fixString(spart) + "'" : "");

    string  sql  = "select * " + sqlGeneric + " and OZLOG# < (select min(OZLOG#) " + sqlGeneric +
                    " and OZREL#  ='" + Converter.fixString(srelease) + "')";

    sql+= " order by OZLOG# desc ";
    sql = DBFormatter.selectTopRows(sql,1);
            
    return read(sql);
}
        
}//end class
}//end namespace
