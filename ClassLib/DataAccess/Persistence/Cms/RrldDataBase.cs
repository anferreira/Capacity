using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{
public 
class RrldDataBase : GenericDataBaseElement{
private string DB;
private decimal PLKEYN;
private string PLREL;
private DateTime PLRDAT;
private decimal PLHHMM;
private DateTime PLTDAT;
private decimal PLQCUM;
private decimal PLQNET;
private decimal PLADJN;
private string PLAUTC;
private string PLTIMC;
private string PLATYP;
private string PLRAN;
private string PLUSR1;
private string PLUSR2;
private string PLUSR3;
private string PLUSR4;
private string PLFUT1;
private string PLFUT2;
private string PLFUT3;
private string PLFUT4;
private string PLFUT5;
private string PLFUT6;

private string stype="";
	
public 
RrldDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public override
void load(NotNullDataReader reader){
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMSTEMP_DATABASE){
		this.DB = reader.GetString("DB");
	}
    this.PLKEYN = reader.GetDecimal("PLKEYN");
    
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
        this.PLREL = reader.GetString("PLREL#");
    else
        this.PLREL = reader.GetString("PLREL");
            
    this.PLRDAT = reader.GetDateTime("PLRDAT");
    this.PLHHMM = reader.GetDecimal("PLHHMM");
    this.PLTDAT = reader.GetDateTime("PLTDAT");
    this.PLQCUM = reader.GetDecimal("PLQCUM");
    this.PLQNET = reader.GetDecimal("PLQNET");
    this.PLADJN = reader.GetDecimal("PLADJN");
    this.PLAUTC = reader.GetString("PLAUTC");
    this.PLTIMC = reader.GetString("PLTIMC");
    this.PLATYP = reader.GetString("PLATYP");
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
        this.PLRAN = reader.GetString("PLRAN#");
    else
        this.PLRAN = reader.GetString("PLRAN");
    this.PLUSR1 = reader.GetString("PLUSR1");
    this.PLUSR2 = reader.GetString("PLUSR2");
    this.PLUSR3 = reader.GetString("PLUSR3");
    this.PLUSR4 = reader.GetString("PLUSR4");
    this.PLFUT1 = reader.GetString("PLFUT1");
    this.PLFUT2 = reader.GetString("PLFUT2");
    this.PLFUT3 = reader.GetString("PLFUT3");
    this.PLFUT4 = reader.GetString("PLFUT4");
    this.PLFUT5 = reader.GetString("PLFUT5");
    this.PLFUT6 = reader.GetString("PLFUT6");
}
public override
void write(){
	try{
		string sql = "insert into rrld values('" +
		    Converter.fixString(DB) + "', " + 
            NumberUtil.toString(PLKEYN) +", '" +
            Converter.fixString(PLREL) +"', '" +
            DateUtil.getCompleteDateRepresentation(PLRDAT) +"', " +
            NumberUtil.toString(PLHHMM) +", '" +
            DateUtil.getCompleteDateRepresentation(PLTDAT) +"', " +
            NumberUtil.toString(PLQCUM) +", " +
            NumberUtil.toString(PLQNET) +", " +
            NumberUtil.toString(PLADJN) +", '" +
            Converter.fixString(PLAUTC) +"', '" +
            Converter.fixString(PLTIMC) +"', '" +
            Converter.fixString(PLATYP) +"', '" +
            Converter.fixString(PLRAN) +"', '" +
            Converter.fixString(PLUSR1) +"', '" +
            Converter.fixString(PLUSR2) +"', '" +
            Converter.fixString(PLUSR3) +"', '" +
            Converter.fixString(PLUSR4) +"', '" +
            Converter.fixString(PLFUT1) +"', '" +
            Converter.fixString(PLFUT2) +"', '" +
            Converter.fixString(PLFUT3) +"', '" +
            Converter.fixString(PLFUT4) +"', '" +
            Converter.fixString(PLFUT5) +"', '" +
            Converter.fixString(PLFUT6) +"')";
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
void setPLKEYN(decimal PLKEYN){
    this.PLKEYN = PLKEYN;
}
public 
void setPLREL(string PLREL){
    this.PLREL = PLREL;
}
public 
void setPLRDAT(DateTime PLRDAT){
    this.PLRDAT = PLRDAT;
}
public 
void setPLHHMM(decimal PLHHMM){
    this.PLHHMM = PLHHMM;
}
public 
void setPLTDAT(DateTime PLTDAT){
    this.PLTDAT = PLTDAT;
}
public 
void setPLQCUM(decimal PLQCUM){
    this.PLQCUM = PLQCUM;
}
public 
void setPLQNET(decimal PLQNET){
    this.PLQNET = PLQNET;
}
public 
void setPLADJN(decimal PLADJN){
    this.PLADJN = PLADJN;
}
public 
void setPLAUTC(string PLAUTC){
    this.PLAUTC = PLAUTC;
}
public 
void setPLTIMC(string PLTIMC){
    this.PLTIMC = PLTIMC;
}
public 
void setPLATYP(string PLATYP){
    this.PLATYP = PLATYP;
}
public 
void setPLRAN(string PLRAN){
    this.PLRAN = PLRAN;
}
public 
void setPLUSR1(string PLUSR1){
    this.PLUSR1 = PLUSR1;
}
public 
void setPLUSR2(string PLUSR2){
    this.PLUSR2 = PLUSR2;
}
public 
void setPLUSR3(string PLUSR3){
    this.PLUSR3 = PLUSR3;
}
public 
void setPLUSR4(string PLUSR4){
    this.PLUSR4 = PLUSR4;
}
public 
void setPLFUT1(string PLFUT1){
    this.PLFUT1 = PLFUT1;
}
public 
void setPLFUT2(string PLFUT2){
    this.PLFUT2 = PLFUT2;
}
public 
void setPLFUT3(string PLFUT3){
    this.PLFUT3 = PLFUT3;
}
public 
void setPLFUT4(string PLFUT4){
    this.PLFUT4 = PLFUT4;
}
public 
void setPLFUT5(string PLFUT5){
    this.PLFUT5 = PLFUT5;
}
public 
void setPLFUT6(string PLFUT6){
    this.PLFUT6 = PLFUT6;
}
//Getters
public 
string getDB(){
    return DB;
}
public 
decimal getPLKEYN(){
    return PLKEYN;
}
public 
string getPLREL(){
    return PLREL;
}
public 
DateTime getPLRDAT(){
    return PLRDAT;
}
public 
decimal getPLHHMM(){
    return PLHHMM;
}
public 
DateTime getPLTDAT(){
    return PLTDAT;
}
public 
decimal getPLQCUM(){
    return PLQCUM;
}
public 
decimal getPLQNET(){
    return PLQNET;
}
public 
decimal getPLADJN(){
    return PLADJN;
}
public 
string getPLAUTC(){
    return PLAUTC;
}
public 
string getPLTIMC(){
    return PLTIMC;
}
public 
string getPLATYP(){
    return PLATYP;
}
public 
string getPLRAN(){
    return PLRAN;
}
public 
string getPLUSR1(){
    return PLUSR1;
}
public 
string getPLUSR2(){
    return PLUSR2;
}
public 
string getPLUSR3(){
    return PLUSR3;
}
public 
string getPLUSR4(){
    return PLUSR4;
}
public 
string getPLFUT1(){
    return PLFUT1;
}
public 
string getPLFUT2(){
    return PLFUT2;
}
public 
string getPLFUT3(){
    return PLFUT3;
}
public 
string getPLFUT4(){
    return PLFUT4;
}
public 
string getPLFUT5(){
    return PLFUT5;
}
public 
string getPLFUT6(){
    return PLFUT6;
}

public
string STYPE {
	get { return stype;}
	set { if (this.stype != value){
			this.stype = value;		
		}
	}
}
}//end class
}//end namespace
