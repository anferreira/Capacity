using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{
public 
class JitdDataBase : GenericDataBaseElement{
//Use in CMSTemp
private string DB;
//-----------------------
private decimal PYKEYN;
private string PYREF;
private DateTime PYDATE;
private decimal PYHM;
private DateTime PYEDAT;
private decimal PYQTY;
private decimal PYQCUM;
private decimal PYNQTY;
private string PYSRC;
private decimal PYLOG;
private decimal PYENT;
private decimal PYBOL;
private decimal PYBLIN;
private string PYRAN;
private string PYREF1;
private string PYREF2;
private string PYSTAT;
private decimal PYKEY;
private string PYKBPR;
private string PYKBST;
private string PYKBEN;
private string PYSHPP;
private string PYSHPT;
private string PYTYPE;
private string PYTIMT;
private string PYTIMC;
private string PYRTEG;
private string PYSVCC;
private string PYMODE;
private string PYUSR1;
private string PYUSR2;
private string PYUSR3;
private string PYUSR4;
private string PYFUT1;
private string PYFUT2;
private string PYFUT3;
private string PYFUT4;
private string PYFUT5;
private string PYFUT6;
public 
JitdDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
public
void load(NotNullDataReader reader){
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMSTEMP_DATABASE)
	    this.DB = reader.GetString("DB");
  
    this.PYKEYN = reader.GetDecimal("PYKEYN");
    
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
        this.PYREF = reader.GetString("PYREF#");
    else
            this.PYREF = reader.GetString("PYREF");
    
    this.PYDATE = reader.GetDateTime("PYDATE");
    this.PYHM = reader.GetDecimal("PYHM");
    this.PYEDAT = reader.GetDateTime("PYEDAT");
    this.PYQTY = reader.GetDecimal("PYQTY");
    this.PYQCUM = reader.GetDecimal("PYQCUM");
    this.PYNQTY = reader.GetDecimal("PYNQTY");
    this.PYSRC = reader.GetString("PYSRC");
    
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
        this.PYLOG = reader.GetDecimal("PYLOG#");
        this.PYENT = reader.GetDecimal("PYENT#");
        this.PYBOL = reader.GetDecimal("PYBOL#");
    }else{
        this.PYLOG = reader.GetDecimal("PYLOG");
        this.PYENT = reader.GetDecimal("PYENT");
        this.PYBOL = reader.GetDecimal("PYBOL");
    }  
    
    this.PYBLIN = reader.GetDecimal("PYBLIN");
    this.PYRAN = reader.GetString("PYRAN");
    this.PYREF1 = reader.GetString("PYREF1");
    this.PYREF2 = reader.GetString("PYREF2");
    this.PYSTAT = reader.GetString("PYSTAT");
    
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
        this.PYKEY = reader.GetDecimal("PYKEY#");
    else
        this.PYKEY = reader.GetDecimal("PYKEY_");
        
    this.PYKBPR = reader.GetString("PYKBPR");
    this.PYKBST = reader.GetString("PYKBST");
    this.PYKBEN = reader.GetString("PYKBEN");
    this.PYSHPP = reader.GetString("PYSHPP");
    this.PYSHPT = reader.GetString("PYSHPT");
    this.PYTYPE = reader.GetString("PYTYPE");
    this.PYTIMT = reader.GetString("PYTIMT");
    this.PYTIMC = reader.GetString("PYTIMC");
    this.PYRTEG = reader.GetString("PYRTEG");
    this.PYSVCC = reader.GetString("PYSVCC");
    this.PYMODE = reader.GetString("PYMODE");
    this.PYUSR1 = reader.GetString("PYUSR1");
    this.PYUSR2 = reader.GetString("PYUSR2");
    this.PYUSR3 = reader.GetString("PYUSR3");
    this.PYUSR4 = reader.GetString("PYUSR4");
    this.PYFUT1 = reader.GetString("PYFUT1");
    this.PYFUT2 = reader.GetString("PYFUT2");
    this.PYFUT3 = reader.GetString("PYFUT3");
    this.PYFUT4 = reader.GetString("PYFUT4");
    this.PYFUT5 = reader.GetString("PYFUT5");
    this.PYFUT6 = reader.GetString("PYFUT6");
}
public override
void write(){
	try{
		string sql = "insert into jitd values('" +
		    Converter.fixString(DB) +"', " +
            NumberUtil.toString(PYKEYN) +", '" +
            Converter.fixString(PYREF) +"', '" +
            DateUtil.getCompleteDateRepresentation(PYDATE) +"', " +
            NumberUtil.toString(PYHM) +", '" +
            DateUtil.getCompleteDateRepresentation(PYEDAT) +"', " +
            NumberUtil.toString(PYQTY) +", " +
            NumberUtil.toString(PYQCUM) +", " +
            NumberUtil.toString(PYNQTY) +", '" +
            Converter.fixString(PYSRC) +"', " +
            NumberUtil.toString(PYLOG) +", " +
            NumberUtil.toString(PYENT) +", " +
            NumberUtil.toString(PYBOL) +", " +
            NumberUtil.toString(PYBLIN) +", '" +
            Converter.fixString(PYRAN) +"', '" +
            Converter.fixString(PYREF1) +"', '" +
            Converter.fixString(PYREF2) +"', '" +
            Converter.fixString(PYSTAT) +"', " +
            NumberUtil.toString(PYKEY) +", '" +
            Converter.fixString(PYKBPR) +"', '" +
            Converter.fixString(PYKBST) +"', '" +
            Converter.fixString(PYKBEN) +"', '" +
            Converter.fixString(PYSHPP) +"', '" +
            Converter.fixString(PYSHPT) +"', '" +
            Converter.fixString(PYTYPE) +"', '" +
            Converter.fixString(PYTIMT) +"', '" +
            Converter.fixString(PYTIMC) +"', '" +
            Converter.fixString(PYRTEG) +"', '" +
            Converter.fixString(PYSVCC) +"', '" +
            Converter.fixString(PYMODE) +"', '" +
            Converter.fixString(PYUSR1) +"', '" +
            Converter.fixString(PYUSR2) +"', '" +
            Converter.fixString(PYUSR3) +"', '" +
            Converter.fixString(PYUSR4) +"', '" +
            Converter.fixString(PYFUT1) +"', '" +
            Converter.fixString(PYFUT2) +"', '" +
            Converter.fixString(PYFUT3) +"', '" +
            Converter.fixString(PYFUT4) +"', '" +
            Converter.fixString(PYFUT5) +"', '" +
            Converter.fixString(PYFUT6) +"')";
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
//Seters
public 
void setDB(string DB){
    this.DB = DB;
}
public 
void setPYKEYN(decimal PYKEYN){
    this.PYKEYN = PYKEYN;
}
public 
void setPYREF(string PYREF){
    this.PYREF = PYREF;
}
public 
void setPYDATE(DateTime PYDATE){
    this.PYDATE = PYDATE;
}
public 
void setPYHM(decimal PYHM){
    this.PYHM = PYHM;
}
public 
void setPYEDAT(DateTime PYEDAT){
    this.PYEDAT = PYEDAT;
}
public 
void setvPYQTY(decimal PYQTY){
    this.PYQTY = PYQTY;
}
public 
void setPYQCUM(decimal PYQCUM){
    this.PYQCUM = PYQCUM;
}
public 
void setPYNQTY(decimal PYNQTY){
    this.PYNQTY = PYNQTY;
}
public 
void setPYSRC(string PYSRC){
    this.PYSRC = PYSRC;
}
public 
void setvPYLOG(decimal PYLOG){
    this.PYLOG = PYLOG;
}
public 
void setPYENT(decimal PYENT){
    this.PYENT = PYENT;
}
public 
void setPYBOL(decimal PYBOL){
    this.PYBOL = PYBOL;
}
public 
void setPYBLIN(decimal PYBLIN){
    this.PYBLIN = PYBLIN;
}
public 
void setPYRAN(string PYRAN){
    this.PYRAN = PYRAN;
}
public 
void setPYREF1(string PYREF1){
    this.PYREF1 = PYREF1;
}
public 
void setPYREF2(string PYREF2){
    this.PYREF2 = PYREF2;
}
public 
void setPYSTAT(string PYSTAT){
    this.PYSTAT = PYSTAT;
}
public 
void setPYKEY(decimal PYKEY){
    this.PYKEY = PYKEY;
}
public 
void setPYKBPR(string PYKBPR){
    this.PYKBPR = PYKBPR;
}
public 
void setPYKBST(string PYKBST){
    this.PYKBST = PYKBST;
}
public 
void setPYKBEN(string PYKBEN){
    this.PYKBEN = PYKBEN;
}
public 
void setPYSHPP(string PYSHPP){
    this.PYSHPP = PYSHPP;
}
public 
void setPYSHPT(string PYSHPT){
    this.PYSHPT = PYSHPT;
}
public 
void setPYTYPE(string PYTYPE){
    this.PYTYPE = PYTYPE;
}
public 
void setPYTIMT(string PYTIMT){
    this.PYTIMT = PYTIMT;
}
public 
void setPYTIMC(string PYTIMC){
    this.PYTIMC = PYTIMC;
}
public 
void setPYRTEG(string PYRTEG){
    this.PYRTEG = PYRTEG;
}
public 
void setPYSVCC(string PYSVCC){
    this.PYSVCC = PYSVCC;
}
public 
void setPYMODE(string PYMODE){
    this.PYMODE = PYMODE;
}
public 
void setPYUSR1(string PYUSR1){
    this.PYUSR1 = PYUSR1;
}
public 
void setPYUSR2(string PYUSR2){
    this.PYUSR2 = PYUSR2;
}
public 
void setPYUSR3(string PYUSR3){
    this.PYUSR3 = PYUSR3;
}
public 
void setPYUSR4(string PYUSR4){
    this.PYUSR4 = PYUSR4;
}
public 
void setPYFUT1(string PYFUT1){
    this.PYFUT1 = PYFUT1;
}
public 
void setPYFUT2(string PYFUT2){
    this.PYFUT2 = PYFUT2;
}
public 
void setPYFUT3(string PYFUT3){
    this.PYFUT3 = PYFUT3;
}
public 
void setPYFUT4(string PYFUT4){
    this.PYFUT4 = PYFUT4;
}
public 
void setPYFUT5(string PYFUT5){
    this.PYFUT5 = PYFUT5;
}
public 
void setPYFUT6(string PYFUT6){
    this.PYFUT6 = PYFUT6;
}
//Getters
public 
string getDB(){
    return DB;
}
public 
decimal getPYKEYN(){
    return PYKEYN;
}
public 
string getPYREF(){
    return PYREF;
}
public 
DateTime getPYDATE(){
    return PYDATE;
}
public 
decimal getPYHM(){
    return PYHM;
}
public 
DateTime getPYEDAT(){
    return PYEDAT;
}
public 
decimal getPYQTY(){
    return PYQTY;
}
public 
decimal getPYQCUM(){
    return PYQCUM;
}
public 
decimal getPYNQTY(){
    return PYNQTY;
}
public 
string getPYSRC(){
    return PYSRC;
}
public 
decimal getPYLOG(){
    return PYLOG;
}
public 
decimal getPYENT(){
    return PYENT;
}
public 
decimal getPYBOL(){
    return PYBOL;
}
public 
decimal getPYBLIN(){
    return PYBLIN;
}
public 
string getPYRAN(){
    return PYRAN;
}
public 
string getPYREF1(){
    return PYREF1;
}
public 
string getPYREF2(){
    return PYREF2;
}
public 
string getPYSTAT(){
    return PYSTAT;
}
public 
decimal getPYKEY(){
    return PYKEY;
}
public 
string getPYKBPR(){
    return PYKBPR;
}
public 
string getPYKBST(){
    return PYKBST;
}
public 
string getPYKBEN(){
    return PYKBEN;
}
public 
string getPYSHPP(){
    return PYSHPP;
}
public 
string getPYSHPT(){
    return PYSHPT;
}
public 
string getPYTYPE(){
    return PYTYPE;
}
public 
string getPYTIMT(){
    return PYTIMT;
}
public 
string getPYTIMC(){
    return PYTIMC;
}
public 
string getPYRTEG(){
    return PYRTEG;
}
public 
string getPYSVCC(){
    return PYSVCC;
}
public 
string getPYMODE(){
    return PYMODE;
}
public 
string getPYUSR1(){
    return PYUSR1;
}
public 
string getPYUSR2(){
    return PYUSR2;
}
public 
string getPYUSR3(){
    return PYUSR3;
}
public 
string getPYUSR4(){
    return PYUSR4;
}
public 
string getPYFUT1(){
    return PYFUT1;
}
public 
string getPYFUT2(){
    return PYFUT2;
}
public 
string getPYFUT3(){
    return PYFUT3;
}
public 
string getPYFUT4(){
    return PYFUT4;
}
public 
string getPYFUT5(){
    return PYFUT5;
}
public 
string getPYFUT6(){
    return PYFUT6;
}
}//end Class
}//end namespace
