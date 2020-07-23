using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class PopTvnDataBase : GenericDataBaseElement{

private string JRPT;
private decimal JRVPTS;
private string JRVND;
private decimal JRPRYS;
private string JRQLTY;
private decimal JRDDYS;
private string JRVPT;
private string JRDES1;
private string JRDES2;
private string JRDES3;
private DateTime JRLDAT;
private decimal JRLPRC;
private string JRLPUN;
private decimal JRLQTO;
private string JRLOUN;
private decimal JRLDYS;
private decimal JRVSPT;
private string JRENGC;
private decimal JROSHP;
private decimal JRSEQ;
private string JRCONS;
private string JRTAXG;
private string JRTAXR;
private string JRFLG1;
private string JRFLG2;
private string JRFLG3;
private string JRFLG4;
private string JRTXT1;
private string JRTXT2;
private string JRTXT3;
private string JRTXT4;
//---------------add in 5.2
private string JRCORG;
private string JRUSER;
private DateTime JRCDAT;
private DateTime JRCTIM;
private string JRUSERU;
private DateTime JRCDATU;
private DateTime JRCTIMU;
private string JRFUT1;
private string JRFUT2;
private decimal	JRFUT3;
//-------------------------

public
PopTvnDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}

public
void load(NotNullDataReader reader){
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.JRPT = reader.GetString("JRPT#");
	else
		this.JRPT = reader.GetString("JRPT_");
	this.JRVPTS = reader.GetDecimal("JRVPTS");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
		this.JRVND = reader.GetString("JRVND#");
		this.JRVPT = reader.GetString("JRVPT#");
	}else{
		//this.JRVND = reader.GetString("JRVND_");
		//this.JRVPT = reader.GetString("JRVPT_");
		this.JRVND = reader.GetString("JRVND_");//AF added _
		this.JRVPT = reader.GetString("JRVPT_");
	}
	this.JRDES1 = reader.GetString("JRDES1");
	this.JRDES2 = reader.GetString("JRDES2");
	this.JRDES3 = reader.GetString("JRDES3");
	this.JRENGC = reader.GetString("JRENGC");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.JRSEQ = reader.GetDecimal("JRSEQ#");
	else
		this.JRSEQ = reader.GetDecimal("JRSEQ_");
	this.JRFLG1 = reader.GetString("JRFLG1");
	this.JRFLG2 = reader.GetString("JRFLG2");
	this.JRFLG3 = reader.GetString("JRFLG3");
	this.JRFLG4 = reader.GetString("JRFLG4");
	if (Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_2)){
		//-------remove in 5.2
		this.JRLDAT = DateTime.MinValue;
		this.JRLPRC = 0;
		this.JRLPUN = "";
		this.JRLQTO = 0;
		this.JRLOUN = "";
		this.JRLDYS = 0;
		this.JRVSPT = 0;
		this.JRCONS = "";
		this.JRTAXG = "";
		this.JRTAXR = "";
		this.JRTXT1 = "";
		this.JRTXT2 = "";
		this.JRTXT3 = "";
		this.JRTXT4 = "";
		this.JRPRYS = 0;
		this.JRQLTY = "";
		this.JRDDYS = 0;
		this.JROSHP = 0;
		//---------------add in 5.2
		this.JRCORG = reader.GetString("JRCORG");
		this.JRUSER = reader.GetString("JRUSER");
		this.JRCDAT = reader.GetDateTime("JRCDAT");		
        try{
            this.JRCTIM = reader.GetDateTime("JRCTIM");
        }catch {
            this.JRCTIM = DateUtil.decimalMinutesToHoursHHMM(reader.GetDecimal("JRCTIM"));
        }
		this.JRUSERU = reader.GetString("JRUSERU");
		this.JRCDATU = reader.GetDateTime("JRCDATU");		
        try{
            this.JRCTIMU = reader.GetDateTime("JRCTIMU");
        }catch {
            this.JRCTIMU = DateUtil.decimalMinutesToHoursHHMM(reader.GetDecimal("JRCTIMU"));
        }
		this.JRFUT1 = reader.GetString("JRFUT1");
		this.JRFUT2 = reader.GetString("JRFUT2");
		this.JRFUT3 = reader.GetDecimal("JRFUT3");
	}else{
		//-------remove in 5.2
		this.JRLDAT = reader.GetDateTime("JRLDAT");
		this.JRPRYS = reader.GetDecimal("JRPRYS");
		this.JRLPRC = reader.GetDecimal("JRLPRC");
		this.JRLPUN = reader.GetString("JRLPUN");
		this.JRLQTO = reader.GetDecimal("JRLQTO");
		this.JRLOUN = reader.GetString("JRLOUN");
		this.JRLDYS = reader.GetDecimal("JRLDYS");
		this.JRVSPT = reader.GetDecimal("JRVSPT");
		this.JRCONS = reader.GetString("JRCONS");
		this.JRTAXG = reader.GetString("JRTAXG");
		this.JRTAXR = reader.GetString("JRTAXR");
		this.JRTXT1 = reader.GetString("JRTXT1");
		this.JRTXT2 = reader.GetString("JRTXT2");
		this.JRTXT3 = reader.GetString("JRTXT3");
		this.JRTXT4 = reader.GetString("JRTXT4");
		this.JRQLTY = reader.GetString("JRQLTY");
		this.JRDDYS = reader.GetDecimal("JRDDYS");
		this.JROSHP = reader.GetDecimal("JROSHP");
		//---------------add in 5.2
		this.JRCORG = "";
		this.JRUSER = "";
		this.JRCDAT = DateTime.MinValue;
		this.JRCTIM = DateTime.MinValue;
		this.JRUSERU = "";
		this.JRCDATU = DateTime.MinValue;
		this.JRCTIMU = DateTime.MinValue;
		this.JRFUT1 = "";
		this.JRFUT2 = "";
		this.JRFUT3 = 0;
	}	
}

public override
void write(){
	try{
		string number ="#";
		if (dataBaseAccess.getConnectionType() != DataBaseAccess.CMS_DATABASE)
			number ="_";

		string sql = "";
		if (Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_2)){
			sql = "insert into poptvn (JRPT"+number+",JRVPTS,JRVND"+number+",JRVPT"+number+",JRDES1,JRDES2,JRDES3,JRENGC,"+
				"JRSEQ"+number+",JRFLG1,JRFLG2,JRFLG3,JRFLG4,"+
//---------------remove in 5.2
				"JRLDAT ,JRPRYS,JRLPRC,JRLPUN,JRLQTO,JRLOUN,JRLDYS,JRVSPT,JRCONS,JRTAXG,JRTAXR,JRTXT1,JRTXT2,JRTXT3,JRTXT4,"+
				"JRQLTY,JRDDYS,JROSHP,"+
//---------------add in 5.2
				"JRCORG,JRUSER,JRCDAT,JRCTIM,JRUSERU,JRCDATU,JRCTIMU,JRFUT1,JRFUT2,JRFUT3)"+
//-------------------
			" values('" +
			Converter.fixString(JRPT) + "', " +
			NumberUtil.toString(JRVPTS) + ", '" +
			Converter.fixString(JRVND) + "', '" +
			Converter.fixString(JRVPT) + "', '" +
            Converter.fixStringAscii127(JRDES1) + "', '" + //AF  there were some strange chars bigger than 127          
            //"', '" + //AF            
            Converter.fixStringAscii127(JRDES2) + "', '" +//AF            
            //"', '" + //AF            
            Converter.fixStringAscii127(JRDES3) + "', '" +
			Converter.fixString(JRENGC) + "', " +
			JRSEQ.ToString() + ", '" +
			Converter.fixString(JRFLG1) + "', '" +
			Converter.fixString(JRFLG2) + "', '" +
			Converter.fixString(JRFLG3) + "', '" +
			Converter.fixString(JRFLG4) + "', '" +
			//---------------------------------------remove in 5.2
			DateUtil.getCompleteDateRepresentation(JRLDAT) + "', " +
			JRPRYS.ToString() + ", " +
			NumberUtil.toString(JRLPRC) + ", '" +
			Converter.fixString(JRLPUN) + "', " +
			NumberUtil.toString(JRLQTO) + ", '" +
			Converter.fixString(JRLOUN) + "', " +
			JRLDYS.ToString() + ", " +
			JRVSPT.ToString() + ", '" +
			Converter.fixString(JRCONS) + "', '" +
			Converter.fixString(JRTAXG) + "', '" +
			Converter.fixString(JRTAXR) + "', '" +
			Converter.fixString(JRTXT1) + "', '" +
			Converter.fixString(JRTXT2) + "', '" +
			Converter.fixString(JRTXT3) + "', '" +
			Converter.fixString(JRTXT4) + "', '" +
			Converter.fixString(JRQLTY) + "', " +
			JRDDYS.ToString() + ", " +			
			JROSHP.ToString() + ", '" +
			//---------------------------------------add in 5.2
			Converter.fixString(JRCORG) +"', '" +
			Converter.fixString(JRUSER) +"', '" +
			DateUtil.getCompleteDateRepresentation(JRCDAT)+ "', '" +
			DateUtil.getCompleteDateRepresentation(JRCTIM)+ "', '" +
			Converter.fixString(JRUSERU) + "',"+"'"+
			DateUtil.getCompleteDateRepresentation(JRCDATU)+ "', '" +
			DateUtil.getCompleteDateRepresentation(JRCTIMU)+ "', '" +
			Converter.fixString(JRFUT1) + "', '" +
			Converter.fixString(JRFUT2) + "',"+
			NumberUtil.toString(JRFUT3)+")";
		}else{
			sql = "insert into poptvn(" +
				"JRPT_, JRVPTS, JRVND/*JRVND_*/, JRPRYS, " + 
				"JRQLTY, JRDDYS, JRVPT/*JRVPT_*/, JRDES1, " + 
				"JRDES2, JRDES3, JRLDAT, JRLPRC, " + 
				"JRLPUN, JRLQTO, JRLOUN, JRLDYS, " + 
				"JRVSPT,JRENGC, JROSHP, JRSEQ_, " + 
				"JRCONS, JRTAXG, JRTAXR, JRFLG1, " + 
				"JRFLG2, JRFLG3, JRFLG4, JRTXT1, " + 
				"JRTXT2, JRTXT3, JRTXT4)" + 
			" values('" +
				Converter.fixString(JRPT) + "', " +
				NumberUtil.toString(JRVPTS) + ", '" +
				Converter.fixString(JRVND) + "', " +
				JRPRYS.ToString() + ", '" +
				Converter.fixString(JRQLTY) + "', " +
				JRDDYS.ToString() + ", '" +
				Converter.fixString(JRVPT) + "', '" +
				Converter.fixString(JRDES1) + "', '" +
				Converter.fixString(JRDES2) + "', '" +
				Converter.fixString(JRDES3) + "', '" +
				DateUtil.getCompleteDateRepresentation(JRLDAT) + "', " +
				NumberUtil.toString(JRLPRC) + ", '" +
				Converter.fixString(JRLPUN) + "', " +
				NumberUtil.toString(JRLQTO) + ", '" +
				Converter.fixString(JRLOUN) + "', " +
				JRLDYS.ToString() + ", " +
				JRVSPT.ToString() + ", '" +
				Converter.fixString(JRENGC) + "', " +
				JROSHP.ToString() + ", " +
				JRSEQ.ToString() + ", '" +
				Converter.fixString(JRCONS) + "', '" +
				Converter.fixString(JRTAXG) + "', '" +
				Converter.fixString(JRTAXR) + "', '" +
				Converter.fixString(JRFLG1) + "', '" +
				Converter.fixString(JRFLG2) + "', '" +
				Converter.fixString(JRFLG3) + "', '" +
				Converter.fixString(JRFLG4) + "', '" +
				Converter.fixString(JRTXT1) + "', '" +
				Converter.fixString(JRTXT2) + "', '" +
				Converter.fixString(JRTXT3) + "', '" +
				Converter.fixString(JRTXT4) + "')";
		}

                try
                {
                    dataBaseAccess.executeUpdate(sql);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + sql);

                }
                
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
void setJRPT(string JRPT){
	this.JRPT = JRPT;
}

public
void setJRVPTS(decimal JRVPTS){
	this.JRVPTS = JRVPTS;
}

public
void setJRVND(string JRVND){
	this.JRVND = JRVND;
}

public
void setJRPRYS(decimal JRPRYS){
	this.JRPRYS = JRPRYS;
}

public
void setJRQLTY(string JRQLTY){
	this.JRQLTY = JRQLTY;
}

public
void setJRDDYS(decimal JRDDYS){
	this.JRDDYS = JRDDYS;
}

public
void setJRVPT(string JRVPT){
	this.JRVPT = JRVPT;
}

public
void setJRDES1(string JRDES1){
	this.JRDES1 = JRDES1;
}

public
void setJRDES2(string JRDES2){
	this.JRDES2 = JRDES2;
}

public
void setJRDES3(string JRDES3){
	this.JRDES3 = JRDES3;
}

public
void setJRLDAT(DateTime JRLDAT){
	this.JRLDAT = JRLDAT;
}

public
void setJRLPRC(decimal JRLPRC){
	this.JRLPRC = JRLPRC;
}

public
void setJRLPUN(string JRLPUN){
	this.JRLPUN = JRLPUN;
}

public
void setJRLQTO(decimal JRLQTO){
	this.JRLQTO = JRLQTO;
}

public
void setJRLOUN(string JRLOUN){
	this.JRLOUN = JRLOUN;
}

public
void setJRLDYS(decimal JRLDYS){
	this.JRLDYS = JRLDYS;
}

public
void setJRVSPT(decimal JRVSPT){
	this.JRVSPT = JRVSPT;
}

public
void setJRENGC(string JRENGC){
	this.JRENGC = JRENGC;
}

public
void setJROSHP(decimal JROSHP){
	this.JROSHP = JROSHP;
}

public
void setJRSEQ(decimal JRSEQ){
	this.JRSEQ = JRSEQ;
}

public
void setJRCONS(string JRCONS){
	this.JRCONS = JRCONS;
}

public
void setJRTAXG(string JRTAXG){
	this.JRTAXG = JRTAXG;
}

public
void setJRTAXR(string JRTAXR){
	this.JRTAXR = JRTAXR;
}

public
void setJRFLG1(string JRFLG1){
	this.JRFLG1 = JRFLG1;
}

public
void setJRFLG2(string JRFLG2){
	this.JRFLG2 = JRFLG2;
}

public
void setJRFLG3(string JRFLG3){
	this.JRFLG3 = JRFLG3;
}

public
void setJRFLG4(string JRFLG4){
	this.JRFLG4 = JRFLG4;
}

public
void setJRTXT1(string JRTXT1){
	this.JRTXT1 = JRTXT1;
}

public
void setJRTXT2(string JRTXT2){
	this.JRTXT2 = JRTXT2;
}

public
void setJRTXT3(string JRTXT3){
	this.JRTXT3 = JRTXT3;
}

public
void setJRTXT4(string JRTXT4){
	this.JRTXT4 = JRTXT4;
}

//---------------add in 5.2
public
void setJRCORG(string JRCORG){
	this.JRCORG = JRCORG;
}

public
string getJRCORG(){
	return this.JRCORG;
}

public
void setJRUSER(string JRUSER){
	this.JRUSER = JRUSER;
}

public
string getJRUSER(){
	return this.JRUSER;
}

public
void setJRCDAT(DateTime JRCDAT){
	this.JRCDAT = JRCDAT;
}

public
DateTime getJRCDAT(){
	return this.JRCDAT;
}

public
void setJRCTIM(DateTime JRCTIM){
	this.JRCTIM = JRCTIM;
}

public
DateTime getJRCTIM(){
	return this.JRCTIM;
}

public
void setJRUSERU(string JRUSERU){
	this.JRUSERU = JRUSERU;
}

public
string getJRUSERU(){
	return this.JRUSERU;
}

public
void setJRCDATU(DateTime JRCDATU){
	this.JRCDATU = JRCDATU;
}

public 
DateTime getJRCDATU(){
	return this.JRCDATU;
}

public
void setJRCTIMU(DateTime JRCTIMU){
	this.JRCTIMU = JRCTIMU;
}

public 
DateTime getJRCTIMU(){
	return this.JRCTIMU;
}

public
void setJRFUT1(string JRFUT1){
	this.JRFUT1 = JRFUT1;
}

public
string getJRFUT1(){
	return this.JRFUT1;
}

public
void setJRFUT2(string JRFUT2){
	this.JRFUT2 = JRFUT2;
}

public
string getJRFUT2(){
	return this.JRFUT2;
}

public
void setJRFUT3(decimal	JRFUT3){
	this.JRFUT3 = JRFUT3;
}

public
decimal getJRFUT3(){
	return this.JRFUT3;
}

//-------------------------
public
string getJRPT(){
	return JRPT;
}

public
decimal getJRVPTS(){
	return JRVPTS;
}

public
string getJRVND(){
	return JRVND;
}

public
decimal getJRPRYS(){
	return JRPRYS;
}

public
string getJRQLTY(){
	return JRQLTY;
}

public
decimal getJRDDYS(){
	return JRDDYS;
}

public
string getJRVPT(){
	return JRVPT;
}

public
string getJRDES1(){
	return JRDES1;
}

public
string getJRDES2(){
	return JRDES2;
}

public
string getJRDES3(){
	return JRDES3;
}

public
DateTime getJRLDAT(){
	return JRLDAT;
}

public
decimal getJRLPRC(){
	return JRLPRC;
}

public
string getJRLPUN(){
	return JRLPUN;
}

public
decimal getJRLQTO(){
	return JRLQTO;
}

public
string getJRLOUN(){
	return JRLOUN;
}

public
decimal getJRLDYS(){
	return JRLDYS;
}

public
decimal getJRVSPT(){
	return JRVSPT;
}

public
string getJRENGC(){
	return JRENGC;
}

public
decimal getJROSHP(){
	return JROSHP;
}

public
decimal getJRSEQ(){
	return JRSEQ;
}

public
string getJRCONS(){
	return JRCONS;
}

public
string getJRTAXG(){
	return JRTAXG;
}

public
string getJRTAXR(){
	return JRTAXR;
}

public
string getJRFLG1(){
	return JRFLG1;
}

public
string getJRFLG2(){
	return JRFLG2;
}

public
string getJRFLG3(){
	return JRFLG3;
}

public
string getJRFLG4(){
	return JRFLG4;
}

public
string getJRTXT1(){
	return JRTXT1;
}

public
string getJRTXT2(){
	return JRTXT2;
}

public
string getJRTXT3(){
	return JRTXT3;
}

public
string getJRTXT4(){
	return JRTXT4;
}


} // class

} // namespace