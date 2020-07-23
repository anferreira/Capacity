using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class LbHistDataBase : GenericDataBaseElement{

private string Db;
private string DVDEPT;
private string DVEMPL;
private DateTime DVDATE;
private decimal DVSHFT;
private string DVMODE;
private string DVWREF;
private decimal DVSEQN;
private decimal DVTIME;
private string DVPART;
private decimal DVQTYC;
private decimal DVQTYS;
private decimal DVRATE;
private decimal DVMEN;
private decimal DVMACH;
private string DVEMGP;
private string DVMAJG;
private decimal DVFSYY;
private decimal DVFSPP;
private string DVDPTS;
private string DVRESC;
private decimal DVCPRC;
private decimal DVLBRT;

public 
LbHistDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMSTEMP_DATABASE){
		this.Db = reader.GetString("DB");
	}
	this.DVDEPT = reader.GetString("DVDEPT");
	this.DVEMPL = reader.GetString("DVEMPL");
	this.DVDATE = reader.GetDateTime("DVDATE");
	this.DVSHFT = reader.GetDecimal("DVSHFT");
	this.DVMODE = reader.GetString("DVMODE");
	this.DVWREF = reader.GetString("DVWREF");
	this.DVSEQN = reader.GetDecimal("DVSEQN");
	this.DVTIME = reader.GetDecimal("DVTIME");
	this.DVPART = reader.GetString("DVPART");
	this.DVQTYC = reader.GetDecimal("DVQTYC");
	this.DVQTYS = reader.GetDecimal("DVQTYS");
	this.DVRATE = reader.GetDecimal("DVRATE");
	this.DVMEN = reader.GetDecimal("DVMEN");
	this.DVMACH = reader.GetDecimal("DVMACH");
	this.DVEMGP = reader.GetString("DVEMGP");
	this.DVMAJG = reader.GetString("DVMAJG");
	this.DVFSYY = reader.GetDecimal("DVFSYY");
	this.DVFSPP = reader.GetDecimal("DVFSPP");
	this.DVDPTS = reader.GetString("DVDPTS");
	this.DVRESC = reader.GetString("DVRESC");
	this.DVCPRC = reader.GetDecimal("DVCPRC");
	this.DVLBRT = reader.GetDecimal("DVLBRT");
}

public override
void write(){
	try{
		string sql = "insert into lbhist values('" +
            Converter.fixString(Db) +"', '" +
            Converter.fixString(DVDEPT) +"', '" +
            Converter.fixString(DVEMPL) +"', '" +
            DateUtil.getCompleteDateRepresentation(DVDATE) +"', " +
            NumberUtil.toString(DVSHFT) +", '" +
            Converter.fixString(DVMODE) +"', '" +
            Converter.fixString(DVWREF) +"', " +
            NumberUtil.toString(DVSEQN) +", " +
            NumberUtil.toString(DVTIME) +", '" +
            Converter.fixString(DVPART) +"', " +
            NumberUtil.toString(DVQTYC) +", " +
            NumberUtil.toString(DVQTYS) +", " +
            NumberUtil.toString(DVRATE) +", " +
            NumberUtil.toString(DVMEN) +", " +
            NumberUtil.toString(DVMACH) +", '" +
            Converter.fixString(DVEMGP) +"', '" +
            Converter.fixString(DVMAJG) +"', " +
            NumberUtil.toString(DVFSYY) +", " +
            NumberUtil.toString(DVFSPP) +", '" +
            Converter.fixString(DVDPTS) +"', '" +
            Converter.fixString(DVRESC) +"', " +
            NumberUtil.toString(DVCPRC) +", " +
            NumberUtil.toString(DVLBRT) +")";
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
void setDb(string Db){
    this.Db = Db;
}

public 
void setDVDEPT(string DVDEPT){
    this.DVDEPT = DVDEPT;
}

public 
void setDVEMPL(string DVEMPL){
    this.DVEMPL = DVEMPL;
}

public 
void setDVDATE(DateTime DVDATE){
    this.DVDATE = DVDATE;
}

public
void setDVSHFT(decimal DVSHFT){
    this.DVSHFT = DVSHFT;
}

public 
void setDVMODE(string DVMODE){
    this.DVMODE = DVMODE;
}

public 
void setDVWREF(string DVWREF){
    this.DVWREF = DVWREF;
}

public 
void setDVSEQN(decimal DVSEQN){
    this.DVSEQN = DVSEQN;
}

public 
void setDVTIME(decimal DVTIME){
    this.DVTIME = DVTIME;
}

public 
void setDVPART(string DVPART){
    this.DVPART = DVPART;
}

public 
void setDVQTYC(decimal DVQTYC){
    this.DVQTYC = DVQTYC;
}

public 
void setDVQTYS(decimal DVQTYS){
    this.DVQTYS = DVQTYS;
}

public 
void setDVRATE(decimal DVRATE){
    this.DVRATE = DVRATE;
}

public
void setDVMEN(decimal DVMEN){
    this.DVMEN = DVMEN;
}

public 
void setDVMACH(decimal DVMACH){
    this.DVMACH = DVMACH;
}

public 
void setDVEMGP(string DVEMGP){
    this.DVEMGP = DVEMGP;
}

public 
void setDVMAJG(string DVMAJG){
    this.DVMAJG = DVMAJG;
}

public 
void setDVFSYY(decimal DVFSYY){
    this.DVFSYY = DVFSYY;
}

public 
void setDVFSPP(decimal DVFSPP){
    this.DVFSPP = DVFSPP;
}

public 
void setDVDPTS(string DVDPTS){
    this.DVDPTS = DVDPTS;
}

public 
void setDVRESC(string DVRESC){
    this.DVRESC = DVRESC;
}

public
void setDVCPRC(decimal DVCPRC){
    this.DVCPRC = DVCPRC;
}

public 
void setDVLBRT(decimal DVLBRT){
    this.DVLBRT = DVLBRT;
}


//Getters
public 
string getDb(){
    return Db;
}

public
string getDVDEPT(){
    return DVDEPT;
}

public 
string getDVEMPL(){
    return DVEMPL;
}

public 
DateTime getDVDATE(){
    return DVDATE;
}

public 
decimal getDVSHFT(){
    return DVSHFT;
}

public 
string getDVMODE(){
    return DVMODE;
}

public 
string getDVWREF(){
    return DVWREF;
}

public 
decimal getDVSEQN(){
    return DVSEQN;
}

public 
decimal getDVTIME(){
    return DVTIME;
}

public 
string getDVPART(){
    return DVPART;
}

public 
decimal getDVQTYC(){
    return DVQTYC;
}

public 
decimal getDVQTYS(){
    return DVQTYS;
}

public 
decimal getDVRATE(){
    return DVRATE;
}

public 
decimal getDVMEN(){
    return DVMEN;
}

public 
decimal getDVMACH(){
    return DVMACH;
}

public 
string getDVEMGP(){
    return DVEMGP;
}

public 
string getDVMAJG(){
    return DVMAJG;
}

public 
decimal getDVFSYY(){
    return DVFSYY;
}

public 
decimal getDVFSPP(){
    return DVFSPP;
}

public 
string getDVDPTS(){
    return DVDPTS;
}

public 
string getDVRESC(){
    return DVRESC;
}

public 
decimal getDVCPRC(){
    return DVCPRC;
}

public 
decimal getDVLBRT(){
    return DVLBRT;
}

} // class

} // namespace
