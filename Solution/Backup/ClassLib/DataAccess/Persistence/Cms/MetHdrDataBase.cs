using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class MetHdrDataBase : GenericDataBaseElement{

private string AOTYPE;
private string AOPART;
private decimal AOSEQ;
private decimal AOLIN;
private string AODEPT;
private string AORESC;
private string AOOPNM;
private decimal AOSETP;
private decimal AORUNS;
private string AORTYP;
private decimal AOSCRW;
private string AOREPP;
private decimal AOLAGT;
private decimal AOPRTY;
private decimal AOTBTH;
private string AOUNIT;
private string AOPRC;
private decimal AOEFF;
private string AOBK03;
private decimal AO_MEN;
private decimal AO_MCH;
private decimal AOEFC1;
private decimal AOEFC2;
private string AOBK04;
private decimal AOCTME;
private decimal AOMULT;
//---------------------add in 5.2
private decimal AOCNOR; // NUMERIC(5, 0) NOT NULL DEFAULT 0 , 
private decimal AOBCDR; // NUMERIC(15, 5) NOT NULL DEFAULT 0 , 
private string AOFUT1; //CHAR(1) CCSID 37 NOT NULL DEFAULT '' , 
private string AOFUT2; //CHAR(1) CCSID 37 NOT NULL DEFAULT '' , 
private string AOFUT3; //CHAR(1) CCSID 37 NOT NULL DEFAULT '' , 
private string AOFUT4; //CHAR(10) CCSID 37 NOT NULL DEFAULT '' , 
private string AOFUT5; //CHAR(10) CCSID 37 NOT NULL DEFAULT '' , 
private string AOFUT6; //CHAR(10) CCSID 37 NOT NULL DEFAULT '' , 
private string AOFUT7; //CHAR(20) CCSID 37 NOT NULL DEFAULT '' , 
private string AOFUT8; //CHAR(20) CCSID 37 NOT NULL DEFAULT '' , 
private string AOFUT9; //CHAR(30) CCSID 37 NOT NULL DEFAULT '' , 
private string AOFUTA; //CHAR(30) CCSID 37 NOT NULL DEFAULT '' , 
private string AOFUTB; //CHAR(30) CCSID 37 NOT NULL DEFAULT '' , 
private decimal AOFUTC; // NUMERIC(15, 5) NOT NULL DEFAULT 0 , 
private decimal AOFUTD; // NUMERIC(15, 5) NOT NULL DEFAULT 0 , 
private decimal AOFUTE; // NUMERIC(15, 5) NOT NULL DEFAULT 0 , 
private decimal AOFUTF; // NUMERIC(15, 5) NOT NULL DEFAULT 0 , 
private string AOPLNT; //CHAR(3) CCSID 37 NOT NULL DEFAULT '' , 
//----------------------------------

public
MetHdrDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.AOTYPE = reader.GetString("AOTYPE");
	this.AOPART = reader.GetString("AOPART");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
		this.AOSEQ = reader.GetDecimal("AOSEQ#");
		this.AOLIN = reader.GetDecimal("AOLIN#");
		this.AOPRC = reader.GetString("AOPRC#");
		this.AO_MEN = reader.GetDecimal("AO#MEN");
		this.AO_MCH = reader.GetDecimal("AO#MCH");	

		if (Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_2)){
			this.AOCNOR = reader.GetDecimal("AOCNOR"); 
			this.AOBCDR = reader.GetDecimal("AOBCDR"); 
			this.AOFUT1 = reader.GetString("AOFUT1"); 
			this.AOFUT2 = reader.GetString("AOFUT2"); 
			this.AOFUT3 = reader.GetString("AOFUT3"); 
			this.AOFUT4 = reader.GetString("AOFUT4"); 
			this.AOFUT5 = reader.GetString("AOFUT5"); 
			this.AOFUT6 = reader.GetString("AOFUT6"); 
			this.AOFUT7 = reader.GetString("AOFUT7"); 
			this.AOFUT8 = reader.GetString("AOFUT8"); 
			this.AOFUT9 = reader.GetString("AOFUT9"); 
			this.AOFUTA = reader.GetString("AOFUTA"); 
			this.AOFUTB = reader.GetString("AOFUTB"); 
			this.AOFUTC = reader.GetDecimal("AOFUTC"); 
			this.AOFUTD = reader.GetDecimal("AOFUTD"); 
			this.AOFUTE = reader.GetDecimal("AOFUTE"); 
			this.AOFUTF = reader.GetDecimal("AOFUTF"); 
			this.AOPLNT = reader.GetString("AOPLNT"); 
		}		
	}else{
		this.AOSEQ = reader.GetDecimal("AOSEQ");
		this.AOLIN = reader.GetDecimal("AOLIN");
		this.AOPRC = reader.GetString("AOPRC");
		this.AO_MEN = reader.GetDecimal("AO_MEN");
		this.AO_MCH = reader.GetDecimal("AO_MCH");	
		//-------------------add in 5.2
		this.AOCNOR = 0;
		this.AOBCDR = 0;
		this.AOFUT1 = "";
		this.AOFUT2 = "";
		this.AOFUT3 = "";
		this.AOFUT4 = "";
		this.AOFUT5 = "";
		this.AOFUT6 = "";
		this.AOFUT7 = "";
		this.AOFUT8 = "";
		this.AOFUT9 = "";
		this.AOFUTA = "";
		this.AOFUTB = "";
		this.AOFUTC = 0;
		this.AOFUTD = 0;
		this.AOFUTE = 0;
		this.AOFUTF = 0;
		this.AOPLNT = "";
	}	
	this.AODEPT = reader.GetString("AODEPT");
	this.AORESC = reader.GetString("AORESC");
	this.AOOPNM = reader.GetString("AOOPNM");
	this.AOSETP = reader.GetDecimal("AOSETP");
	this.AORUNS = reader.GetDecimal("AORUNS");
	this.AORTYP = reader.GetString("AORTYP");
	this.AOSCRW = reader.GetDecimal("AOSCRW");
	this.AOREPP = reader.GetString("AOREPP");
	this.AOLAGT = reader.GetDecimal("AOLAGT");

	if (Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_0)){
		this.AOPRTY = reader.GetDecimal("AOPRTY");
	}else{
		this.AOPRTY = 0;
	}

	this.AOTBTH = reader.GetDecimal("AOTBTH");
	this.AOUNIT = reader.GetString("AOUNIT");
	
	this.AOEFF = reader.GetDecimal("AOEFF");
	this.AOBK03 = reader.GetString("AOBK03");
	this.AOEFC1 = reader.GetDecimal("AOEFC1");
	this.AOEFC2 = reader.GetDecimal("AOEFC2");
	this.AOBK04 = reader.GetString("AOBK04");
	this.AOCTME = reader.GetDecimal("AOCTME");
	this.AOMULT = reader.GetDecimal("AOMULT");
}

public override
void write(){
	try{
		string sql = "";
			sql = "insert into methdr(" +  
				"AOTYPE, AOPART, AOSEQ, AOLIN, " +
				"AODEPT, AORESC, AOOPNM, AOSETP, " +
				"AORUNS, AORTYP, AOSCRW, AOREPP, " +
				"AOLAGT, AOPRTY, AOTBTH, AOUNIT, " +
				"AOPRC, AOEFF, AOBK03, AO_MEN, " +
				"AO_MCH, AOEFC1, AOEFC2, AOBK04, " +
				"AOCTME, AOMULT)" +
			" values('" +
				Converter.fixString(AOTYPE) + "', '" +
				Converter.fixString(AOPART) + "', " +
				NumberUtil.toString(AOSEQ) + ", " +
				NumberUtil.toString(AOLIN) + ", '" +
				Converter.fixString(AODEPT) + "', '" +
				Converter.fixString(AORESC) + "', '" +
				Converter.fixString(AOOPNM) + "', " +
				NumberUtil.toString(AOSETP) + ", " +
				NumberUtil.toString(AORUNS) + ", '" +
				Converter.fixString(AORTYP) + "', " +
				NumberUtil.toString(AOSCRW) + ", '" +
				Converter.fixString(AOREPP) + "', " +
				NumberUtil.toString(AOLAGT) + ", " +
				NumberUtil.toString(AOPRTY) + ", " +
				NumberUtil.toString(AOTBTH) + ", '" +
				Converter.fixString(AOUNIT) + "', '" +
				Converter.fixString(AOPRC) + "', " +
				NumberUtil.toString(AOEFF) + ", '" +
				Converter.fixString(AOBK03) + "', " +
				NumberUtil.toString(AO_MEN) + ", " +
				NumberUtil.toString(AO_MCH) + ", " +
				NumberUtil.toString(AOEFC1) + ", " +
				NumberUtil.toString(AOEFC2) + ", '" +
				Converter.fixString(AOBK04) + "', " +
				NumberUtil.toString(AOCTME) + ", " +
				NumberUtil.toString(AOMULT) + ")";

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

public
void setAOTYPE(string AOTYPE){
	this.AOTYPE = AOTYPE;
}

public
void setAOPART(string AOPART){
	this.AOPART = AOPART;
}

public
void setAOSEQ(decimal AOSEQ){
	this.AOSEQ = AOSEQ;
}

public
void setAOLIN(decimal AOLIN){
	this.AOLIN = AOLIN;
}

public
void setAODEPT(string AODEPT){
	this.AODEPT = AODEPT;
}

public
void setAORESC(string AORESC){
	this.AORESC = AORESC;
}

public
void setAOOPNM(string AOOPNM){
	this.AOOPNM = AOOPNM;
}

public
void setAOSETP(decimal AOSETP){
	this.AOSETP = AOSETP;
}

public
void setAORUNS(decimal AORUNS){
	this.AORUNS = AORUNS;
}

public
void setAORTYP(string AORTYP){
	this.AORTYP = AORTYP;
}

public
void setAOSCRW(decimal AOSCRW){
	this.AOSCRW = AOSCRW;
}

public
void setAOREPP(string AOREPP){
	this.AOREPP = AOREPP;
}

public
void setAOLAGT(decimal AOLAGT){
	this.AOLAGT = AOLAGT;
}

public
void setAOPRTY(decimal AOPRTY){
	this.AOPRTY = AOPRTY;
}

public
void setAOTBTH(decimal AOTBTH){
	this.AOTBTH = AOTBTH;
}

public
void setAOUNIT(string AOUNIT){
	this.AOUNIT = AOUNIT;
}

public
void setAOPRC(string AOPRC){
	this.AOPRC = AOPRC;
}

public
void setAOEFF(decimal AOEFF){
	this.AOEFF = AOEFF;
}

public
void setAOBK03(string AOBK03){
	this.AOBK03 = AOBK03;
}

public
void setAO_MEN(decimal AO_MEN){
	this.AO_MEN = AO_MEN;
}

public
void setAO_MCH(decimal AO_MCH){
	this.AO_MCH = AO_MCH;
}

public
void setAOEFC1(decimal AOEFC1){
	this.AOEFC1 = AOEFC1;
}

public
void setAOEFC2(decimal AOEFC2){
	this.AOEFC2 = AOEFC2;
}

public
void setAOBK04(string AOBK04){
	this.AOBK04 = AOBK04;
}

public
void setAOCTME(decimal AOCTME){
	this.AOCTME = AOCTME;
}

public
void setAOMULT(decimal AOMULT){
	this.AOMULT = AOMULT;
}

public 
void setAOCNOR(decimal AOCNOR){
	this.AOCNOR = AOCNOR;
}
public
decimal getAOCNOR(){
	return this.AOCNOR;
}
public 
void setAOBCDR(decimal AOBCDR){
	this.AOBCDR = AOBCDR;
}
public
decimal getAOBCDR(){
	return this.AOBCDR;
}
public
void setAOFUT1(string AOFUT1){
	this.AOFUT1 = AOFUT1;
}
public
string getAOFUT1(){
	return this.AOFUT1;
}
public
void setAOFUT2(string AOFUT2){
	this.AOFUT2 = AOFUT2;
}
public
string getAOFUT2(){
	return this.AOFUT2;
}
public
void setAOFUT3(string AOFUT3){
	this.AOFUT3 = AOFUT3;
}
public
string getAOFUT3(){
	return this.AOFUT3;
}
public
void setAOFUT4(string AOFUT4){
	this.AOFUT4 = AOFUT4;
}
public
string getAOFUT4(){
	return this.AOFUT4;
}
public
void setAOFUT5(string AOFUT5){
	this.AOFUT5 = AOFUT5;
}
public
string getAOFUT5(){
	return this.AOFUT5;
}
public
void setAOFUT6(string AOFUT6){
	this.AOFUT6 = AOFUT6;
}
public
string getAOFUT6(){
	return this.AOFUT6;
}
public
void setAOFUT7(string AOFUT7){
	this.AOFUT7 = AOFUT7;
}
public
string getAOFUT7(){
	return this.AOFUT7;
}
public
void setAOFUT8(string AOFUT8){
	this.AOFUT8 = AOFUT8;
}
public
string getAOFUT8(){
	return this.AOFUT8;
}
public
void setAOFUT9(string AOFUT9){
	this.AOFUT9 = AOFUT9;
}
public
string getAOFUT9(){
	return this.AOFUT9;
}
public
void setAOFUTA(string AOFUTA){
	this.AOFUTA = AOFUTA;
}
public
string getAOFUTA(){
	return this.AOFUTA;
}
public
void setAOFUTB(string AOFUTB){
	this.AOFUTB = AOFUTB;
}
public
string getAOFUTB(){
	return this.AOFUTB;
}
public 
void setAOFUTC(decimal AOFUTC){
	this.AOFUTC = AOFUTC;
}
public
decimal getAOFUTC(){
	return this.AOFUTC;
}
public 
void setAOFUTD(decimal AOFUTD){
	this.AOFUTD = AOFUTD;
}
public
decimal getAOFUTD(){
	return this.AOFUTD;
}
public 
void setAOFUTE(decimal AOFUTE){
	this.AOFUTE = AOFUTE;
}
public
decimal getAOFUTE(){
	return this.AOFUTE;
}
public 
void setAOFUTF(decimal AOFUTF){
	this.AOFUTF = AOFUTF;
}
public
decimal getAOFUTF(){
	return this.AOFUTF;
}
public
void setAOPLNT(string AOPLNT){
	this.AOPLNT = AOPLNT;
}  
public
string getAOPLNT(){
	return this.AOPLNT;
}
//----------------------------------
public
string getAOTYPE(){
	return AOTYPE;
}

public
string getAOPART(){
	return AOPART;
}

public
decimal getAOSEQ(){
	return AOSEQ;
}

public
decimal getAOLIN(){
	return AOLIN;
}

public
string getAODEPT(){
	return AODEPT;
}

public
string getAORESC(){
	return AORESC;
}

public
string getAOOPNM(){
	return AOOPNM;
}

public
decimal getAOSETP(){
	return AOSETP;
}

public
decimal getAORUNS(){
	return AORUNS;
}

public
string getAORTYP(){
	return AORTYP;
}

public
decimal getAOSCRW(){
	return AOSCRW;
}

public
string getAOREPP(){
	return AOREPP;
}

public
decimal getAOLAGT(){
	return AOLAGT;
}

public
decimal getAOPRTY(){
	return AOPRTY;
}

public
decimal getAOTBTH(){
	return AOTBTH;
}

public
string getAOUNIT(){
	return AOUNIT;
}

public
string getAOPRC(){
	return AOPRC;
}

public
decimal getAOEFF(){
	return AOEFF;
}

public
string getAOBK03(){
	return AOBK03;
}

public
decimal getAO_MEN(){
	return AO_MEN;
}

public
decimal getAO_MCH(){
	return AO_MCH;
}

public
decimal getAOEFC1(){
	return AOEFC1;
}

public
decimal getAOEFC2(){
	return AOEFC2;
}

public
string getAOBK04(){
	return AOBK04;
}

public
decimal getAOCTME(){
	return AOCTME;
}

public
decimal getAOMULT(){
	return AOMULT;
}

}

}