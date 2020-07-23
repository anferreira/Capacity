using System;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{
	
public 
class VendDataBase : GenericDataBaseElement{
private decimal BTPYTD;
private string BTNAME;
private string BTADR1;
private string BTADR2;
private string BTADR3;
private string BTADR4;
private string BTADR5;
private string BTADR6;
private string BTADR7;
private string BTADR8;
private string BTADR9;
private string BTADR10;
private string BTPOST;
private string BTTEL;
private string BTBANK;
private decimal BTPERC;
private decimal BTTERM;
private decimal BTCYTD;
private DateTime BTLDAT;
private string BTCLAS;
private string BTGSTF;
private decimal BTNETD;
private string BTCURR;
private decimal BTSORT;
private string BTCONT;
private string BTVEND;
private string BTFAX;
private string BTGSTL;
private string BTTRMC;
private string BTFOBC;
private string BTTAXG;
private string BTTAXR;
private string BTTAXS;
private string BTRMIT;
private string BTOSSL;
private string BTDUNS;
private string BTAUVF;
private string BTCPVR;
private string BTCARC;
private string BTCBRC;
private decimal BTAPPD;
private string BTMINF;
private string BTPAYT;
private string BTVNRM;
private string BTBKRM;
private string BTINSP;
private string BTPSAC;
private string BTPSFR;
private string BTPSDY;
private string BTPSDR;
private string BTSSAC;
private string BTSSFR;
private string BTSSDY;
private string BTSSDR;
private string BTPEDI;
private string BTSEDI;
private string BTCNTC;
private string BTFAXP;
private string BTEMAL;
private string BTWPAG;
private string BTFLG1;
private DateTime BTCDAT;
private string BTPRCL;
private string BTFLG2;
private string BTFLG3;
private string BTFLG4;
private string BTUVER;
private string BTPRCD;
private string BTSTAT;
private string BTREAS;
public 
VendDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
public
void load(NotNullDataReader reader){
	this.BTPYTD = reader.GetDecimal("BTPYTD");
	this.BTNAME = reader.GetString("BTNAME");
	this.BTADR1 = reader.GetString("BTADR1");
	this.BTADR2 = reader.GetString("BTADR2");
	this.BTADR3 = reader.GetString("BTADR3");
	this.BTADR4 = reader.GetString("BTADR4");
	this.BTADR5 = reader.GetString("BTADR5");
	this.BTADR6 = reader.GetString("BTADR6");
	this.BTADR7 = reader.GetString("BTADR7");
	this.BTADR8 = reader.GetString("BTADR8");
	this.BTADR9 = reader.GetString("BTADR9");
	this.BTADR10 = reader.GetString("BTADR10");
	this.BTPOST  = reader.GetString("BTPOST");
    try{
        this.BTTEL = reader.GetString("BTTEL#");
    }catch{
        this.BTTEL = reader.GetString("BTTEL");
    }
	this.BTBANK = reader.GetString("BTBANK");
	this.BTPERC = reader.GetDecimal("BTPERC");
	this.BTTERM = reader.GetDecimal("BTTERM");
	this.BTCYTD = reader.GetDecimal("BTCYTD");
	if ((dataBaseAccess.getConnectionType() == DataBaseAccess.NUJIT_DATABASE)|| 
		(dataBaseAccess.getConnectionType() == DataBaseAccess.CMSTEMP_DATABASE)){
		this.BTLDAT = reader.GetDateTime("BTLDAT");
	}else{
        try{//AF 2017-11-09
		    string dateAs = reader.GetString("BTLDAT").Trim();
		    this.BTLDAT = DateUtil.parseDate(dateAs, DateUtil.YYYYMMDD_AS);
        }catch{
            this.BTLDAT = reader.GetDateTime("BTLDAT");
        }
	}
	this.BTCLAS = reader.GetString("BTCLAS");
	this.BTGSTF = reader.GetString("BTGSTF");
	this.BTNETD = reader.GetDecimal("BTNETD");
	this.BTCURR = reader.GetString("BTCURR");
	this.BTSORT = reader.GetDecimal("BTSORT");
	this.BTCONT = reader.GetString("BTCONT");
	this.BTVEND = reader.GetString("BTVEND");	
    try{
        this.BTFAX = reader.GetString("BTFAX#");
    }catch{
        this.BTFAX = reader.GetString("BTFAX");
    }
	this.BTGSTL = reader.GetString("BTGSTL");
	this.BTTRMC = reader.GetString("BTTRMC");
	this.BTFOBC = reader.GetString("BTFOBC");
	this.BTTAXG = reader.GetString("BTTAXG");
	this.BTTAXR = reader.GetString("BTTAXR");
	this.BTTAXS = reader.GetString("BTTAXS");
	this.BTRMIT  = reader.GetString("BTRMIT");
	this.BTOSSL = reader.GetString("BTOSSL");
	this.BTDUNS = reader.GetString("BTDUNS");
	this.BTAUVF = reader.GetString("BTAUVF");
	this.BTCPVR = reader.GetString("BTCPVR");
	this.BTCARC = reader.GetString("BTCARC");
	this.BTCBRC = reader.GetString("BTCBRC");
	this.BTAPPD = reader.GetDecimal("BTAPPD");
	this.BTMINF = reader.GetString("BTMINF");
	if (Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_0))
		this.BTPAYT = reader.GetString("BTPAYT");
	this.BTVNRM = reader.GetString("BTVNRM");
	this.BTBKRM = reader.GetString("BTBKRM");
	this.BTINSP  = reader.GetString("BTINSP");
	this.BTPSAC = reader.GetString("BTPSAC");
	this.BTPSFR = reader.GetString("BTPSFR");
	this.BTPSDY = reader.GetString("BTPSDY");
	this.BTPSDR = reader.GetString("BTPSDR");
	this.BTSSAC = reader.GetString("BTSSAC");
	this.BTSSFR = reader.GetString("BTSSFR");
	this.BTSSDY = reader.GetString("BTSSDY");
	this.BTSSDR = reader.GetString("BTSSDR");
	this.BTPEDI = reader.GetString("BTPEDI");
	this.BTSEDI = reader.GetString("BTSEDI");
	this.BTCNTC = reader.GetString("BTCNTC");
	this.BTFAXP = reader.GetString("BTFAXP");
	this.BTEMAL = reader.GetString("BTEMAL");
	this.BTWPAG = reader.GetString("BTWPAG");
	this.BTFLG1 = reader.GetString("BTFLG1");
	this.BTCDAT = reader.GetDateTime("BTCDAT");
	this.BTPRCL = reader.GetString("BTPRCL");
	this.BTFLG2 = reader.GetString("BTFLG2");
	this.BTFLG3 = reader.GetString("BTFLG3");
	this.BTFLG4 = reader.GetString("BTFLG4");
	this.BTUVER = reader.GetString("BTUVER");
	this.BTPRCD = reader.GetString("BTPRCD");
	this.BTSTAT = reader.GetString("BTSTAT");
	this.BTREAS  = reader.GetString("BTREAS");
}
public override
void update(){
	throw new PersistenceException("Method not implemented");
}
public override
void delete(){
	throw new PersistenceException("Method not implemented");
}
public override
void write(){
	try{
		string sql = "insert into vend values(" +
			NumberUtil.toString(BTPYTD) + ", '" +
			Converter.fixString(BTNAME) + "', '" + 
			Converter.fixString(BTADR1) + "', '" +
			Converter.fixString(BTADR2) + "', '" +
			Converter.fixString(BTADR3) + "', '" +
			Converter.fixString(BTADR4) + "', '" +
			Converter.fixString(BTADR5) + "', '" +
			Converter.fixString(BTADR6) + "', '" +
			Converter.fixString(BTADR7) + "', '" +
			Converter.fixString(BTADR8) + "', '" +
			Converter.fixString(BTADR9) + "', '" +
			Converter.fixString(BTADR10) + "', '" +
			Converter.fixString(BTPOST) + "', '" +
			Converter.fixString(BTTEL) + "', '" +
			Converter.fixString(BTBANK) + "', " +
			NumberUtil.toString(BTPERC) +", " +
			NumberUtil.toString(BTTERM) +", " +
			NumberUtil.toString(BTCYTD) +", '" +
			DateUtil.getCompleteDateRepresentation(BTLDAT) + "', '" +
			Converter.fixString(BTCLAS) + "', '" +
			Converter.fixString(BTGSTF) + "', " +
			NumberUtil.toString(BTNETD) +", '" +
			Converter.fixString(BTCURR) + "', " +
			NumberUtil.toString(BTSORT) +", '" +
			Converter.fixString(BTCONT) + "', '" +
			Converter.fixString(BTVEND) + "', '" +
			Converter.fixString(BTFAX) + "', '" +
			Converter.fixString(BTGSTL) + "', '" +
			Converter.fixString(BTTRMC) + "', '" +
			Converter.fixString(BTFOBC) + "', '" +
			Converter.fixString(BTTAXG) + "', '" +
			Converter.fixString(BTTAXR) + "', '" +
			Converter.fixString(BTTAXS) + "', '" +
			Converter.fixString(BTRMIT) + "', '" +
			Converter.fixString(BTOSSL) + "', '" +
			Converter.fixString(BTDUNS) + "', '" +
			Converter.fixString(BTAUVF) + "', '" +
			Converter.fixString(BTCPVR) + "', '" +
			Converter.fixString(BTCARC) + "', '" +
			Converter.fixString(BTCBRC) + "', " +
			NumberUtil.toString(BTAPPD) +", '" +
			Converter.fixString(BTMINF) + "', '" +
			Converter.fixString(BTPAYT) + "', '" +
			Converter.fixString(BTVNRM) + "', '" +
			Converter.fixString(BTBKRM) + "', '" +
			Converter.fixString(BTINSP) + "', '" +
			Converter.fixString(BTPSAC) + "', '" +
			Converter.fixString(BTPSFR) + "', '" +
			Converter.fixString(BTPSDY) + "', '" +
			Converter.fixString(BTPSDR) + "', '" + 
			Converter.fixString(BTSSAC) + "', '" +
			Converter.fixString(BTSSFR) + "', '" +
			Converter.fixString(BTSSDY) + "', '" +
			Converter.fixString(BTSSDR) + "', '" +
			Converter.fixString(BTPEDI) + "', '" +
			Converter.fixString(BTSEDI) + "', '" +
			Converter.fixString(BTCNTC) + "', '" +
			Converter.fixString(BTFAXP) + "', '" +
			Converter.fixString(BTEMAL) + "', '" +
			Converter.fixString(BTWPAG) + "', '" +
			Converter.fixString(BTFLG1) + "', '" +
			DateUtil.getCompleteDateRepresentation(BTCDAT) + "', '" +
			Converter.fixString(BTPRCL) + "', '" +
			Converter.fixString(BTFLG2) + "', '" +
			Converter.fixString(BTFLG3) + "', '" +
			Converter.fixString(BTFLG4) + "', '" +
			Converter.fixString(BTUVER) + "', '" +
			Converter.fixString(BTPRCD) + "', '" +
			Converter.fixString(BTSTAT) + "', '" +
			Converter.fixString(BTREAS) + "')";
			
		dataBaseAccess.executeUpdate(sql);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}
}
public
void setBTPYTD(decimal BTPYTD){
	this.BTPYTD = BTPYTD;
}
public
void setBTNAME(string BTNAME){
	this.BTNAME = BTNAME;
}
public
void setBTADR1(string BTADR1){
	this.BTADR1 = BTADR1;
}
public
void setBTADR2(string BTADR2){
	this.BTADR2 = BTADR2;
}
public
void setBTADR3(string BTADR3){
	this.BTADR3 = BTADR3;
}
public
void setBTADR4(string BTADR4){
	this.BTADR4 = BTADR4;
}
public
void setBTADR5(string BTADR5){
	this.BTADR5 = BTADR5;
}
public
void setBTADR6(string BTADR6){
	this.BTADR6 = BTADR6;
}
public
void setBTADR7(string BTADR7){
	this.BTADR7 = BTADR7;
}
public
void setBTADR8(string BTADR8){
	this.BTADR8 = BTADR8;
}
public
void setBTADR9(string BTADR9){
	this.BTADR9 = BTADR9;
}
public
void setBTADR10(string BTADR10){
	this.BTADR10 = BTADR10;
}
public
void setBTPOST(string BTPOST){
	this.BTPOST = BTPOST;
}
public
void setBTTEL(string BTTEL){
	this.BTTEL = BTTEL;
}
public
void setBTBANK(string BTBANK){
	this.BTBANK = BTBANK;
}
public
void setBTPERC(decimal BTPERC){
	this.BTPERC = BTPERC;
}
public
void setBTTERM(decimal BTTERM){
	this.BTTERM = BTTERM;
}
public
void setBTCYTD(decimal BTCYTD){
	this.BTCYTD = BTCYTD;
}
public
void setBTLDAT(DateTime BTLDAT){
	this.BTLDAT = BTLDAT;
}
public
void setBTCLAS(string BTCLAS){
	this.BTCLAS = BTCLAS;
}
public
void setBTGSTF(string BTGSTF){
	this.BTGSTF = BTGSTF;
}
public
void setBTNETD(decimal BTNETD){
	this.BTNETD = BTNETD;
}
public
void setBTCURR(string BTCURR){
	this.BTCURR = BTCURR;
}
public
void setBTSORT(decimal BTSORT){
	this.BTSORT = BTSORT;
}
public
void setBTCONT(string BTCONT){
	this.BTCONT = BTCONT;
}
public
void setBTVEND(string BTVEND){
	this.BTVEND = BTVEND;
}
public
void setBTFAX(string BTFAX){
	this.BTFAX = BTFAX;
}
public
void setBTGSTL(string BTGSTL){
	this.BTGSTL = BTGSTL;
}
public
void setBTTRMC(string BTTRMC){
	this.BTTRMC = BTTRMC;
}
public
void setBTFOBC(string BTFOBC){
	this.BTFOBC = BTFOBC;
}
public
void setBTTAXG(string BTTAXG){
	this.BTTAXG = BTTAXG;
}
public
void setBTTAXR(string BTTAXR){
	this.BTTAXR = BTTAXR;
}
public
void setBTTAXS(string BTTAXS){
	this.BTTAXS = BTTAXS;
}
public
void setBTRMIT(string BTRMIT){
	this.BTRMIT = BTRMIT;
}
public
void setBTOSSL(string BTOSSL){
	this.BTOSSL = BTOSSL;
}
public
void setBTDUNS(string BTDUNS){
	this.BTDUNS = BTDUNS;
}
public
void setBTAUVF(string BTAUVF){
	this.BTAUVF = BTAUVF;
}
public
void setBTCPVR(string BTCPVR){
	this.BTCPVR = BTCPVR;
}
public
void setBTCARC(string BTCARC){
	this.BTCARC = BTCARC;
}
public
void setBTCBRC(string BTCBRC){
	this.BTCBRC = BTCBRC;
}
public
void setBTAPPD(decimal BTAPPD){
	this.BTAPPD = BTAPPD;
}
public
void setBTMINF(string BTMINF){
	this.BTMINF = BTMINF;
}
public
void setBTPAYT(string BTPAYT){
	this.BTPAYT = BTPAYT;
}
public
void setBTVNRM(string BTVNRM){
	this.BTVNRM = BTVNRM;
}
public
void setBTBKRM(string BTBKRM){
	this.BTBKRM = BTBKRM;
}
public
void setBTINSP(string BTINSP){
	this.BTINSP = BTINSP;
}
public
void setBTPSAC(string BTPSAC){
	this.BTPSAC = BTPSAC;
}
public
void setBTPSFR(string BTPSFR){
	this.BTPSFR = BTPSFR;
}
public
void setBTPSDY(string BTPSDY){
	this.BTPSDY = BTPSDY;
}
public
void setBTPSDR(string BTPSDR){
	this.BTPSDR = BTPSDR;
}
public
void setBTSSAC(string BTSSAC){
	this.BTSSAC = BTSSAC;
}
public
void setBTSSFR(string BTSSFR){
	this.BTSSFR = BTSSFR;
}
public
void setBTSSDY(string BTSSDY){
	this.BTSSDY = BTSSDY;
}
public
void setBTSSDR(string BTSSDR){
	this.BTSSDR = BTSSDR;
}
public
void setBTPEDI(string BTPEDI){
	this.BTPEDI = BTPEDI;
}
public
void setBTSEDI(string BTSEDI){
	this.BTSEDI = BTSEDI;
}
public
void setBTCNTC(string BTCNTC){
	this.BTCNTC = BTCNTC;
}
public
void setBTFAXP(string BTFAXP){
	this.BTFAXP = BTFAXP;
}
public
void setBTEMAL(string BTEMAL){
	this.BTEMAL = BTEMAL;
}
public
void setBTWPAG(string BTWPAG){
	this.BTWPAG = BTWPAG;
}
public
void setBTFLG1(string BTFLG1){
	this.BTFLG1 = BTFLG1;
}
public
void setBTCDAT(DateTime BTCDAT){
	this.BTCDAT = BTCDAT;
}
public
void setBTPRCL(string BTPRCL){
	this.BTPRCL = BTPRCL;
}
public
void setBTFLG2(string BTFLG2){
	this.BTFLG2 = BTFLG2;
}
public
void setBTFLG3(string BTFLG3){
	this.BTFLG3 = BTFLG3;
}
public
void setBTFLG4(string BTFLG4){
	this.BTFLG4 = BTFLG4;
}
public
void setBTUVER(string BTUVER){
	this.BTUVER = BTUVER;
}
public
void setBTPRCD(string BTPRCD){
	this.BTPRCD = BTPRCD;
}
public
void setBTSTAT(string BTSTAT){
	this.BTSTAT = BTSTAT;
}
public
void setBTREAS(string BTREAS){
	this.BTREAS = BTREAS;
}
public
decimal getBTPYTD(){
	return BTPYTD;
}
public
string getBTNAME(){
	return BTNAME;
}
public
string getBTADR1(){
	return BTADR1;
}
public
string getBTADR2(){
	return BTADR2;
}
public
string getBTADR3(){
	return BTADR3;
}
public
string getBTADR4(){
	return BTADR4;
}
public
string getBTADR5(){
	return BTADR5;
}
public
string getBTADR6(){
	return BTADR6;
}
public
string getBTADR7(){
	return BTADR7;
}
public
string getBTADR8(){
	return BTADR8;
}
public
string getBTADR9(){
	return BTADR9;
}
public
string getBTADR10(){
	return BTADR10;
}
public
string getBTPOST(){
	return BTPOST;
}
public
string getBTTEL(){
	return BTTEL;
}
public
string getBTBANK(){
	return BTBANK;
}
public
decimal getBTPERC(){
	return BTPERC;
}
public
decimal getBTTERM(){
	return BTTERM;
}
public
decimal getBTCYTD(){
	return BTCYTD;
}
public
DateTime getBTLDAT(){
	return BTLDAT;
}
public
string getBTCLAS(){
	return BTCLAS;
}
public
string getBTGSTF(){
	return BTGSTF;
}
public
decimal getBTNETD(){
	return BTNETD;
}
public
string getBTCURR(){
	return BTCURR;
}
public
decimal getBTSORT(){
	return BTSORT;
}
public
string getBTCONT(){
	return BTCONT;
}
public
string getBTVEND(){
	return BTVEND;
}
public
string getBTFAX(){
	return BTFAX;
}
public
string getBTGSTL(){
	return BTGSTL;
}
public
string getBTTRMC(){
	return BTTRMC;
}
public
string getBTFOBC(){
	return BTFOBC;
}
public
string getBTTAXG(){
	return BTTAXG;
}
public
string getBTTAXR(){
	return BTTAXR;
}
public
string getBTTAXS(){
	return BTTAXS;
}
public
string getBTRMIT(){
	return BTRMIT;
}
public
string getBTOSSL(){
	return BTOSSL;
}
public
string getBTDUNS(){
	return BTDUNS;
}
public
string getBTAUVF(){
	return BTAUVF;
}
public
string getBTCPVR(){
	return BTCPVR;
}
public
string getBTCARC(){
	return BTCARC;
}
public
string getBTCBRC(){
	return BTCBRC;
}
public
decimal getBTAPPD(){
	return BTAPPD;
}
public
string getBTMINF(){
	return BTMINF;
}
public
string getBTPAYT(){
	return BTPAYT;
}
public
string getBTVNRM(){
	return BTVNRM;
}
public
string getBTBKRM(){
	return BTBKRM;
}
public
string getBTINSP(){
	return BTINSP;
}
public
string getBTPSAC(){
	return BTPSAC;
}
public
string getBTPSFR(){
	return BTPSFR;
}
public
string getBTPSDY(){
	return BTPSDY;
}
public
string getBTPSDR(){
	return BTPSDR;
}
public
string getBTSSAC(){
	return BTSSAC;
}
public
string getBTSSFR(){
	return BTSSFR;
}
public
string getBTSSDY(){
	return BTSSDY;
}
public
string getBTSSDR(){
	return BTSSDR;
}
public
string getBTPEDI(){
	return BTPEDI;
}
public
string getBTSEDI(){
	return BTSEDI;
}
public
string getBTCNTC(){
	return BTCNTC;
}
public
string getBTFAXP(){
	return BTFAXP;
}
public
string getBTEMAL(){
	return BTEMAL;
}
public
string getBTWPAG(){
	return BTWPAG;
}
public
string getBTFLG1(){
	return BTFLG1;
}
public
DateTime getBTCDAT(){
	return BTCDAT;
}
public
string getBTPRCL(){
	return BTPRCL;
}
public
string getBTFLG2(){
	return BTFLG2;
}
public
string getBTFLG3(){
	return BTFLG3;
}
public
string getBTFLG4(){
	return BTFLG4;
}
public
string getBTUVER(){
	return BTUVER;
}
public
string getBTPRCD(){
	return BTPRCD;
}
public
string getBTSTAT(){
	return BTSTAT;
}
public
string getBTREAS(){
	return BTREAS;
}
}//end class
}//end namespace
