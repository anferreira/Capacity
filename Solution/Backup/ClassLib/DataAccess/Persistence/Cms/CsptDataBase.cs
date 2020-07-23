using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class CsptDataBase : GenericDataBaseElement{

private string DB;
private string RRPART;
private string RRCUST;
private string RRCPT;
private string RRBCP;
private string RRREV;
private DateTime RRRDAT;
private string RRDES1;
private string RRDES2;
private string RRDES3;
private string RRCONS;
private string RRCPTP;
private string RRCPTM;
private string RRCPTS;
private decimal RRSDPQ;
private string RRSDPU;
private string RRCNTR;
private string RRLBLF;
private decimal RRLBLC;
private string RRMLBF;
private decimal RRMLBC;
private string RRPRTM;
private string RRPLCC;
private string RRSLMN;
private decimal RRCPCT;
private decimal RRCRAT;
private string RRF0CM;
private string RRBLUP;
private string RRDBUY;
private string RRFUT1;
private string RRFUT2;
private string RRFUT3;
private string RRFUT4;
 
public 
CsptDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	if(dataBaseAccess.getConnectionType() == DataBaseAccess.CMSTEMP_DATABASE){
		this.DB = reader.GetString("DB");
	}
	
	this.RRPART = reader.GetString("RRPART");
	this.RRCUST = reader.GetString("RRCUST");
	if(dataBaseAccess.getConnectionType() == DataBaseAccess.CMSTEMP_DATABASE){
		this.RRCPT= reader.GetString("RRCPT");
		this.RRBCP= reader.GetString("RRBCP");
		this.RRREV= reader.GetString("RRREV");
	}else{
		this.RRCPT= reader.GetString("RRCPT#");
		this.RRBCP= reader.GetString("RRBCP#");
		this.RRREV= reader.GetString("RRREV#");
	}
	this.RRRDAT = reader.GetDateTime("RRRDAT");
	this.RRDES1 = reader.GetString("RRDES1");
	this.RRDES2 = reader.GetString("RRDES2");
	this.RRDES3 = reader.GetString("RRDES3");
	this.RRCONS = reader.GetString("RRCONS");
	this.RRCPTP = reader.GetString("RRCPTP");
	this.RRCPTM = reader.GetString("RRCPTM");
	this.RRCPTS = reader.GetString("RRCPTS");
	this.RRSDPQ = reader.GetDecimal("RRSDPQ");
	this.RRSDPU = reader.GetString("RRSDPU");
	this.RRCNTR = reader.GetString("RRCNTR");
	this.RRLBLF = reader.GetString("RRLBLF");
	this.RRLBLC = reader.GetDecimal("RRLBLC");
	this.RRMLBF = reader.GetString("RRMLBF");
	this.RRMLBC = reader.GetDecimal("RRMLBC");
	this.RRPRTM = reader.GetString("RRPRTM");
	this.RRPLCC = reader.GetString("RRPLCC");
	this.RRSLMN = reader.GetString("RRSLMN");
	this.RRCPCT = reader.GetDecimal("RRCPCT");
	this.RRCRAT = reader.GetDecimal("RRCRAT");
	this.RRF0CM = reader.GetString("RRF0CM");
	this.RRBLUP = reader.GetString("RRBLUP");
	this.RRDBUY = reader.GetString("RRDBUY");
	this.RRFUT1 = reader.GetString("RRFUT1");
	this.RRFUT2 = reader.GetString("RRFUT2");
	this.RRFUT3 = reader.GetString("RRFUT3");
	this.RRFUT4 = reader.GetString("RRFUT4");
}


public override
void write(){
	try{
		string sql = "insert into cspt values('" +
	            Converter.fixString(DB) +"', '" +
                Converter.fixString(RRPART) +"', '" +
                Converter.fixString(RRCUST) +"', '" +
                Converter.fixString(RRCPT) +"', '" +
                Converter.fixString(RRBCP) +"', '" +
                Converter.fixString(RRREV) +"', '" +
                DateUtil.getCompleteDateRepresentation(RRRDAT) +"', '" +
                Converter.fixString(RRDES1) +"', '" +
                Converter.fixString(RRDES2) +"', '" +
                Converter.fixString(RRDES3) +"', '" +
                Converter.fixString(RRCONS) +"', '" +
                Converter.fixString(RRCPTP) +"', '" +
                Converter.fixString(RRCPTM) +"', '" +
                Converter.fixString(RRCPTS) +"', " +
                NumberUtil.toString(RRSDPQ) +", '" +
                Converter.fixString(RRSDPU) +"', '" +
                Converter.fixString(RRCNTR) +"', '" +
                Converter.fixString(RRLBLF) +"', " +
                NumberUtil.toString(RRLBLC) +", '" +
                Converter.fixString(RRMLBF) +"', " +
                NumberUtil.toString(RRMLBC) +", '" +
                Converter.fixString(RRPRTM) +"', '" +
                Converter.fixString(RRPLCC) +"', '" +
                Converter.fixString(RRSLMN) +"', " +
                NumberUtil.toString(RRCPCT) +", " +
                NumberUtil.toString(RRCRAT) +", '" +
                Converter.fixString(RRF0CM) +"', '" +
                Converter.fixString(RRBLUP) +"', '" +
                Converter.fixString(RRDBUY) +"', '" +
                Converter.fixString(RRFUT1) +"', '" +
                Converter.fixString(RRFUT2) +"', '" +
                Converter.fixString(RRFUT3) +"', '" +
                Converter.fixString(RRFUT4) +"')";
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
void setRRPART(string RRPART){
    this.RRPART = RRPART;
}

public 
void setRRCUST(string RRCUST){
    this.RRCUST = RRCUST;
}

public 
void setRRCPT(string RRCPT){
    this.RRCPT = RRCPT;
}

public 
void setRRBCP(string RRBCP){
    this.RRBCP = RRBCP;
}

public 
void setRRREV(string RRREV){
    this.RRREV = RRREV;
}

public 
void setRRRDAT(DateTime RRRDAT){
    this.RRRDAT = RRRDAT;
}

public 
void setRRDES1(string RRDES1){
    this.RRDES1 = RRDES1;
}

public 
void setRRDES2(string RRDES2){
    this.RRDES2 = RRDES2;
}

public 
void setRRDES3(string RRDES3){
    this.RRDES3 = RRDES3;
}

public 
void setRRCONS(string RRCONS){
    this.RRCONS = RRCONS;
}

public 
void setRRCPTP(string RRCPTP){
    this.RRCPTP = RRCPTP;
}

public 
void setRRCPTM(string RRCPTM){
    this.RRCPTM = RRCPTM;
}

public 
void setRRCPTS(string RRCPTS){
    this.RRCPTS = RRCPTS;
}

public 
void setRRSDPQ(decimal RRSDPQ){
    this.RRSDPQ = RRSDPQ;
}

public 
void setRRSDPU(string RRSDPU){
    this.RRSDPU = RRSDPU;
}

public 
void setRRCNTR(string RRCNTR){
    this.RRCNTR = RRCNTR;
}

public 
void setRRLBLF(string RRLBLF){
    this.RRLBLF = RRLBLF;
}

public 
void setRRLBLC(decimal RRLBLC){
    this.RRLBLC = RRLBLC;
}

public 
void setRRMLBF(string RRMLBF){
    this.RRMLBF = RRMLBF;
}

public 
void setRRMLBC(decimal RRMLBC){
    this.RRMLBC = RRMLBC;
}

public 
void setRRPRTM(string RRPRTM){
    this.RRPRTM = RRPRTM;
}

public 
void setRRPLCC(string RRPLCC){
    this.RRPLCC = RRPLCC;
}

public 
void setRRSLMN(string RRSLMN){
    this.RRSLMN = RRSLMN;
}

public 
void setRRCPCT(decimal RRCPCT){
    this.RRCPCT = RRCPCT;
}

public 
void setRRCRAT(decimal RRCRAT){
    this.RRCRAT = RRCRAT;
}

public 
void setRRF0CM(string RRF0CM){
    this.RRF0CM = RRF0CM;
}

public 
void setRRBLUP(string RRBLUP){
    this.RRBLUP = RRBLUP;
}

public 
void setRRDBUY(string RRDBUY){
    this.RRDBUY = RRDBUY;
}

public 
void setRRFUT1(string RRFUT1){
    this.RRFUT1 = RRFUT1;
}

public 
void setRRFUT2(string RRFUT2){
    this.RRFUT2 = RRFUT2;
}

public 
void setRRFUT3(string RRFUT3){
    this.RRFUT3 = RRFUT3;
}

public 
void setRRFUT4(string RRFUT4){
    this.RRFUT4 = RRFUT4;
}


//Getters
public 
string getDB(){
    return DB;
}

public 
string getRRPART(){
    return RRPART;
}

public 
string getRRCUST(){
    return RRCUST;
}

public 
string getRRCPT(){
    return RRCPT;
}

public 
string getRRBCP(){
    return RRBCP;
}

public 
string getRRREV(){
    return RRREV;
}

public 
DateTime getRRRDAT(){
    return RRRDAT;
}

public 
string getRRDES1(){
    return RRDES1;
}

public 
string getRRDES2(){
    return RRDES2;
}

public 
string getRRDES3(){
    return RRDES3;
}

public 
string getRRCONS(){
    return RRCONS;
}

public 
string getRRCPTP(){
    return RRCPTP;
}

public 
string getRRCPTM(){
    return RRCPTM;
}

public 
string getRRCPTS(){
    return RRCPTS;
}

public 
decimal getRRSDPQ(){
    return RRSDPQ;
}

public 
string getRRSDPU(){
    return RRSDPU;
}

public 
string getRRCNTR(){
    return RRCNTR;
}

public 
string getRRLBLF(){
    return RRLBLF;
}

public 
decimal getRRLBLC(){
    return RRLBLC;
}

public 
string getRRMLBF(){
    return RRMLBF;
}

public 
decimal getRRMLBC(){
    return RRMLBC;
}

public 
string getRRPRTM(){
    return RRPRTM;
}

public 
string getRRPLCC(){
    return RRPLCC;
}

public 
string getRRSLMN(){
    return RRSLMN;
}

public 
decimal getRRCPCT(){
    return RRCPCT;
}

public 
decimal getRRCRAT(){
    return RRCRAT;
}

public 
string getRRF0CM(){
    return RRF0CM;
}

public 
string getRRBLUP(){
    return RRBLUP;
}

public 
string getRRDBUY(){
    return RRDBUY;
}

public 
string getRRFUT1(){
    return RRFUT1;
}

public 
string getRRFUT2(){
    return RRFUT2;
}

public 
string getRRFUT3(){
    return RRFUT3;
}

public 
string getRRFUT4(){
    return RRFUT4;
}

}//end class

}//end namespace
