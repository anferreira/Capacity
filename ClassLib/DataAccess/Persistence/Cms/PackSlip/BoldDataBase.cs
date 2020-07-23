using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms.PackSlip{
	
public class BoldDataBase : GenericDataBaseElement{

private string DB;
private decimal FGBOL;
private decimal FGENT;
private decimal FGORD;
private decimal FGITEM;
private decimal FGPO;
private decimal FGPREL;
private decimal FGPITM;
private decimal FGQSHP;
private decimal FGQSHO;
private string FGCTNC;
private decimal FGCTNN;
private decimal FGNTWC;
private decimal FGGRSC;
private decimal FGTARC;
private decimal FGVOLC;
private decimal FGQTYC;
private decimal FGWGTP;
private decimal FGVOLP;
private string FGLSTS;
private string FGPART;
private string FGRLNO;
private decimal FGINV;
private decimal FGLIN;
private string FGORUN;
private decimal FGFTAM;
private string FGSTKL;
private string FGRAN;
private string FGCPT;
private string FGCNID;
private string FGECHG;
private decimal FGCCUM;
private decimal FGPCUM;
private string FGCPO;
private string FGCMPR;
private string FGDOCK;
private string FGISTS;
private string FGSREF;
private string FGCRCM;
private string FGUSR1;
private string FGUSR2;
private string FGUSR3;
private decimal FGREQ;
private decimal FGDREQ;
private string FGUSR4;
private string FGUSR5;
private string FGFUT1;
private string FGFUT2;
private string FGFUT3;
private string FGFUT4;
private string FGFUT5;

private string FGPSLP;
private decimal FGNWFP;


public BoldDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}

public override
void load(NotNullDataReader reader){
	
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMSTEMP_DATABASE){
		this.DB = reader.GetString("DB");
	}

	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
		this.FGBOL = reader.GetDecimal("FGBOL#");
		this.FGENT = reader.GetDecimal("FGENT#");
		this.FGORD = reader.GetDecimal("FGORD#");
	}
	else{
		this.FGBOL = reader.GetDecimal("FGBOL");
		this.FGENT = reader.GetDecimal("FGENT");
		this.FGORD = reader.GetDecimal("FGORD");
	}
	this.FGITEM = reader.GetDecimal("FGITEM");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.FGPO = reader.GetDecimal("FGPO#");
	else
		this.FGPO = reader.GetDecimal("FGPO");
	this.FGPREL = reader.GetDecimal("FGPREL");
	this.FGPITM = reader.GetDecimal("FGPITM");
	this.FGQSHP = reader.GetDecimal("FGQSHP");
	this.FGQSHO = reader.GetDecimal("FGQSHO");
	this.FGCTNC = reader.GetString("FGCTNC");
	this.FGCTNN = reader.GetDecimal("FGCTNN");
	this.FGNTWC = reader.GetDecimal("FGNTWC");
	this.FGGRSC = reader.GetDecimal("FGGRSC");
	this.FGTARC = reader.GetDecimal("FGTARC");
	this.FGVOLC = reader.GetDecimal("FGVOLC");
	this.FGQTYC = reader.GetDecimal("FGQTYC");
	this.FGWGTP = reader.GetDecimal("FGWGTP");
	this.FGVOLP = reader.GetDecimal("FGVOLP");
	this.FGLSTS = reader.GetString("FGLSTS");
	this.FGPART = reader.GetString("FGPART");
	this.FGRLNO = reader.GetString("FGRLNO");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
		this.FGINV = reader.GetDecimal("FGINV#");
		this.FGLIN = reader.GetDecimal("FGLIN#");
	}
	else{
		this.FGINV = reader.GetDecimal("FGINV");
		this.FGLIN = reader.GetDecimal("FGLIN");
	}
	this.FGORUN = reader.GetString("FGORUN");
	this.FGFTAM = reader.GetDecimal("FGFTAM");
	this.FGSTKL = reader.GetString("FGSTKL");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
		this.FGRAN = reader.GetString("FGRAN#");
		this.FGCPT = reader.GetString("FGCPT#");
	}
	else{
		this.FGRAN = reader.GetString("FGRAN");
		this.FGCPT = reader.GetString("FGCPT");
	}
	this.FGCNID = reader.GetString("FGCNID");
	this.FGECHG = reader.GetString("FGECHG");
	this.FGCCUM = reader.GetDecimal("FGCCUM");
	this.FGPCUM = reader.GetDecimal("FGPCUM");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.FGCPO = reader.GetString("FGCPO#");
	else
		this.FGCPO = reader.GetString("FGCPO");
	this.FGCMPR = reader.GetString("FGCMPR");
	this.FGDOCK = reader.GetString("FGDOCK");
	this.FGISTS = reader.GetString("FGISTS");
	this.FGSREF = reader.GetString("FGSREF");
	this.FGCRCM = reader.GetString("FGCRCM");
	this.FGUSR1 = reader.GetString("FGUSR1");
	this.FGUSR2 = reader.GetString("FGUSR2");
	this.FGUSR3 = reader.GetString("FGUSR3");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.FGREQ = reader.GetDecimal("FGREQ#");
	else
		this.FGREQ = reader.GetDecimal("FGREQ");
	this.FGDREQ = reader.GetDecimal("FGDREQ");
	this.FGUSR4 = reader.GetString("FGUSR4");
	this.FGUSR5 = reader.GetString("FGUSR5");
	this.FGFUT1 = reader.GetString("FGFUT1");
	this.FGFUT2 = reader.GetString("FGFUT2");
	this.FGFUT3 = reader.GetString("FGFUT3");
	this.FGFUT4 = reader.GetString("FGFUT4");
	this.FGFUT5 = reader.GetString("FGFUT5");

    this.FGPSLP = reader.GetString("FGPSLP");
    this.FGNWFP = reader.GetDecimal("FGNWFP");
}

/*
public
void loadReadBy(NotNullDataReader reader){
	this.FGCPT = reader.GetString("FGCPT#");
}
*/

/*
public
string getWhereCondition(){
	string sqlWhere =
        getFieldDigit("FGBOL") + " = " + NumberUtil.toString(FGBOL) + " and " +
        getFieldDigit("FGENT") + " = " + NumberUtil.toString(FGENT);
	return sqlWhere;
}
*/

public
bool read(){
	string sql = "select * from " + getTablePrefix() + "bold where " + getWhereCondition();
	return read(sql);
}

public override
void write(){	
	string sql = "insert into bold values('" +
		Converter.fixString(DB) + "', " +
		NumberUtil.toString(FGBOL) + ", " +
		NumberUtil.toString(FGENT) + ", " +
		NumberUtil.toString(FGORD) + ", " +
		NumberUtil.toString(FGITEM) + ", " +
		NumberUtil.toString(FGPO) + ", " +
		NumberUtil.toString(FGPREL) + ", " +
		NumberUtil.toString(FGPITM) + ", " +
		NumberUtil.toString(FGQSHP) + ", " +
		NumberUtil.toString(FGQSHO) + ", '" +
		Converter.fixString(FGCTNC) + "', " +
		NumberUtil.toString(FGCTNN) + ", " +
		NumberUtil.toString(FGNTWC) + ", " +
		NumberUtil.toString(FGGRSC) + ", " +
		NumberUtil.toString(FGTARC) + ", " +
		NumberUtil.toString(FGVOLC) + ", " +
		NumberUtil.toString(FGQTYC) + ", " +
		NumberUtil.toString(FGWGTP) + ", " +
		NumberUtil.toString(FGVOLP) + ", '" +
		Converter.fixString(FGLSTS) + "', '" +
		Converter.fixString(FGPART) + "', '" +
		Converter.fixString(FGRLNO) + "', " +
		NumberUtil.toString(FGINV) + ", " +
		NumberUtil.toString(FGLIN) + ", '" +
		Converter.fixString(FGORUN) + "', " +
		NumberUtil.toString(FGFTAM) + ", '" +
		Converter.fixString(FGSTKL) + "', '" +
		Converter.fixString(FGRAN) + "', '" +
		Converter.fixString(FGCPT) + "', '" +
		Converter.fixString(FGCNID) + "', '" +
		Converter.fixString(FGECHG) + "', " +
		NumberUtil.toString(FGCCUM) + ", " +
		NumberUtil.toString(FGPCUM) + ", '" +
		Converter.fixString(FGCPO) + "', '" +
		Converter.fixString(FGCMPR) + "', '" +
		Converter.fixString(FGDOCK) + "', '" +
		Converter.fixString(FGISTS) + "', '" +
		Converter.fixString(FGSREF) + "', '" +
		Converter.fixString(FGCRCM) + "', '" +
		Converter.fixString(FGUSR1) + "', '" +
		Converter.fixString(FGUSR2) + "', '" +
		Converter.fixString(FGUSR3) + "', " +
		NumberUtil.toString(FGREQ) + ", " +
		NumberUtil.toString(FGDREQ) + ", '" +
		Converter.fixString(FGUSR4) + "', '" +
		Converter.fixString(FGUSR5) + "', '" +
		Converter.fixString(FGFUT1) + "', '" +
		Converter.fixString(FGFUT2) + "', '" +
		Converter.fixString(FGFUT3) + "', '" +
		Converter.fixString(FGFUT4) + "', '" +
		Converter.fixString(FGFUT5) + "')";

        //NumberUtil.toString(FGNWFP) + ")";
    
	write(sql);	
}

public override
void update(){
	throw new PersistenceException("Method not implemented");
}

public override
void delete(){
	string sql = "delete from bold where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string fgbolField = "FGBOL";
	string fgentField = "FGENT";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
		fgbolField = "FGBOL#";
		fgentField = "FGENT#";
	}
	string sqlWhere =
		fgbolField + " = " + NumberUtil.toString(FGBOL) + " and " +
		fgentField + " = " + NumberUtil.toString(FGENT);
	return sqlWhere;
}

/*
public
bool exists(){
	try{
		bool ret = false;

		string sql = "select * from dbo.BOLD " + 
			"where " +
			"DB ='" + Converter.fixString(DB)+ "' and " +
			"FGBOL# ="+ NumberUtil.toString(FGBOL) + " and " +
			"FGENT# =" +NumberUtil.toString(FGENT)+ "";

		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			ret = true;
		reader.Close();
		return ret;
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class BoldDataBase <exists>: " + se.Message);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class BoldDataBase <exists>: " + de.Message);
	}
}
*/

//Setters

public void setDB(string DB){
   this.DB = DB;
}

public void setFGBOL(decimal FGBOL){
   this.FGBOL = FGBOL;
}

public void setFGENT(decimal FGENT){
   this.FGENT = FGENT;
}

public void setFGORD(decimal FGORD){
   this.FGORD = FGORD;
}

public void setFGITEM(decimal FGITEM){
   this.FGITEM = FGITEM;
}

public void setFGPO(decimal FGPO){
   this.FGPO = FGPO;
}

public void setFGPREL(decimal FGPREL){
   this.FGPREL = FGPREL;
}

public void setFGPITM(decimal FGPITM){
   this.FGPITM = FGPITM;
}

public void setFGQSHP(decimal FGQSHP){
   this.FGQSHP = FGQSHP;
}

public void setFGQSHO(decimal FGQSHO){
   this.FGQSHO = FGQSHO;
}

public void setFGCTNC(string FGCTNC){
   this.FGCTNC = FGCTNC;
}

public void setFGCTNN(decimal FGCTNN){
   this.FGCTNN = FGCTNN;
}

public void setFGNTWC(decimal FGNTWC){
   this.FGNTWC = FGNTWC;
}

public void setFGGRSC(decimal FGGRSC){
   this.FGGRSC = FGGRSC;
}

public void setFGTARC(decimal FGTARC){
   this.FGTARC = FGTARC;
}

public void setFGVOLC(decimal FGVOLC){
   this.FGVOLC = FGVOLC;
}

public void setFGQTYC(decimal FGQTYC){
   this.FGQTYC = FGQTYC;
}

public void setFGWGTP(decimal FGWGTP){
   this.FGWGTP = FGWGTP;
}

public void setFGVOLP(decimal FGVOLP){
   this.FGVOLP = FGVOLP;
}

public void setFGLSTS(string FGLSTS){
   this.FGLSTS = FGLSTS;
}

public void setFGPART(string FGPART){
   this.FGPART = FGPART;
}

public void setFGRLNO(string FGRLNO){
   this.FGRLNO = FGRLNO;
}

public void setFGINV(decimal FGINV){
   this.FGINV = FGINV;
}

public void setFGLIN(decimal FGLIN){
   this.FGLIN = FGLIN;
}

public void setFGORUN(string FGORUN){
   this.FGORUN = FGORUN;
}

public void setFGFTAM(decimal FGFTAM){
   this.FGFTAM = FGFTAM;
}

public void setFGSTKL(string FGSTKL){
   this.FGSTKL = FGSTKL;
}

public void setFGRAN(string FGRAN){
   this.FGRAN = FGRAN;
}

public void setFGCPT(string FGCPT){
   this.FGCPT = FGCPT;
}

public void setFGCNID(string FGCNID){
   this.FGCNID = FGCNID;
}

public void setFGECHG(string FGECHG){
   this.FGECHG = FGECHG;
}

public void setFGCCUM(decimal FGCCUM){
   this.FGCCUM = FGCCUM;
}

public void setFGPCUM(decimal FGPCUM){
   this.FGPCUM = FGPCUM;
}

public void setFGCPO(string FGCPO){
   this.FGCPO = FGCPO;
}

public void setFGCMPR(string FGCMPR){
   this.FGCMPR = FGCMPR;
}

public void setFGDOCK(string FGDOCK){
   this.FGDOCK = FGDOCK;
}

public void setFGISTS(string FGISTS){
   this.FGISTS = FGISTS;
}

public void setFGSREF(string FGSREF){
   this.FGSREF = FGSREF;
}

public void setFGCRCM(string FGCRCM){
   this.FGCRCM = FGCRCM;
}

public void setFGUSR1(string FGUSR1){
   this.FGUSR1 = FGUSR1;
}

public void setFGUSR2(string FGUSR2){
   this.FGUSR2 = FGUSR2;
}

public void setFGUSR3(string FGUSR3){
   this.FGUSR3 = FGUSR3;
}

public void setFGREQ(decimal FGREQ){
   this.FGREQ = FGREQ;
}

public void setFGDREQ(decimal FGDREQ){
   this.FGDREQ = FGDREQ;
}

public void setFGUSR4(string FGUSR4){
   this.FGUSR4 = FGUSR4;
}

public void setFGUSR5(string FGUSR5){
   this.FGUSR5 = FGUSR5;
}

public void setFGFUT1(string FGFUT1){
   this.FGFUT1 = FGFUT1;
}

public void setFGFUT2(string FGFUT2){
   this.FGFUT2 = FGFUT2;
}

public void setFGFUT3(string FGFUT3){
   this.FGFUT3 = FGFUT3;
}

public void setFGFUT4(string FGFUT4){
   this.FGFUT4 = FGFUT4;
}

public void setFGFUT5(string FGFUT5){
   this.FGFUT5 = FGFUT5;
}

public void setFGPSLP(string FGPSLP){
    this.FGFUT5 = FGPSLP;
}

public void setFGNWFP(decimal FGNWFP){
    this.FGNWFP = FGNWFP;
}


//Getters

public
string getDB(){
   return DB;
}

public
decimal getFGBOL(){
   return FGBOL;
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
decimal getFGPO(){
   return FGPO;
}

public
decimal getFGPREL(){
   return FGPREL;
}

public
decimal getFGPITM(){
   return FGPITM;
}

public
decimal getFGQSHP(){
   return FGQSHP;
}

public
decimal getFGQSHO(){
   return FGQSHO;
}

public
string getFGCTNC(){
   return FGCTNC;
}

public
decimal getFGCTNN(){
   return FGCTNN;
}

public
decimal getFGNTWC(){
   return FGNTWC;
}

public
decimal getFGGRSC(){
   return FGGRSC;
}

public
decimal getFGTARC(){
   return FGTARC;
}

public
decimal getFGVOLC(){
   return FGVOLC;
}

public
decimal getFGQTYC(){
   return FGQTYC;
}

public
decimal getFGWGTP(){
   return FGWGTP;
}

public
decimal getFGVOLP(){
   return FGVOLP;
}

public
string getFGLSTS(){
   return FGLSTS;
}

public
string getFGPART(){
   return FGPART;
}

public
string getFGRLNO(){
   return FGRLNO;
}

public
decimal getFGINV(){
   return FGINV;
}

public
decimal getFGLIN(){
   return FGLIN;
}

public
string getFGORUN(){
   return FGORUN;
}

public
decimal getFGFTAM(){
   return FGFTAM;
}

public
string getFGSTKL(){
   return FGSTKL;
}

public
string getFGRAN(){
   return FGRAN;
}

public
string getFGCPT(){
   return FGCPT;
}

public
string getFGCNID(){
   return FGCNID;
}

public
string getFGECHG(){
   return FGECHG;
}

public
decimal getFGCCUM(){
   return FGCCUM;
}

public
decimal getFGPCUM(){
   return FGPCUM;
}

public
string getFGCPO(){
   return FGCPO;
}

public
string getFGCMPR(){
   return FGCMPR;
}

public
string getFGDOCK(){
   return FGDOCK;
}

public
string getFGISTS(){
   return FGISTS;
}

public
string getFGSREF(){
   return FGSREF;
}

public
string getFGCRCM(){
   return FGCRCM;
}

public
string getFGUSR1(){
   return FGUSR1;
}

public
string getFGUSR2(){
   return FGUSR2;
}

public
string getFGUSR3(){
   return FGUSR3;
}

public
decimal getFGREQ(){
   return FGREQ;
}

public
decimal getFGDREQ(){
   return FGDREQ;
}

public
string getFGUSR4(){
   return FGUSR4;
}

public
string getFGUSR5(){
   return FGUSR5;
}

public
string getFGFUT1(){
   return FGFUT1;
}

public
string getFGFUT2(){
   return FGFUT2;
}

public
string getFGFUT3(){
   return FGFUT3;
}

public
string getFGFUT4(){
   return FGFUT4;
}

public
string getFGFUT5(){
   return FGFUT5;
}

public
string getFGPSLP(){
    return FGPSLP;
}

public
decimal getFGNWFP(){
    return FGNWFP;
}


}//end Class

}//end namespace
