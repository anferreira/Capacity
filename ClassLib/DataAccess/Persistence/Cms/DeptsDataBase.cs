using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{
public 
class DeptsDataBase : GenericDataBaseElement{
private string AADEPT;
private string AABLNK;
private string AADNME;
private decimal AASTDR;
private decimal AABRDR;
private decimal AAMACH;
private decimal AABRDP;
private decimal AADFTC;
private DateTime AASTIM;
private decimal AAVBRD;
private string AAFRML;
private string AARCVL;
private string AAINSP;
private string AAPLNT;
private string AAOSRV;
private string AAFUT1;
private string AAFUT2;
private string AAFUT3;
private string AAFUT4;
private string AAFUT5;
private string AAFUT6;
private decimal AAFUT7;
private string AAFLG1;
private string AAFLG2;
private string AAFLG3;
private string AAFLG4;
private string AAFLG5;
private decimal AAVBRP;
private string AAWPDR;
private string AAWPRV;
		
public 
DeptsDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
			
public 
void load(NotNullDataReader reader){
	this.AADEPT = reader.GetString("AADEPT");
	this.AABLNK = reader.GetString("AABLNK");
	this.AADNME = reader.GetString("AADNME");
	this.AASTDR = reader.GetDecimal("AASTDR");
	this.AABRDR = reader.GetDecimal("AABRDR");
	this.AAMACH = reader.GetDecimal("AAMACH");
	this.AABRDP = reader.GetDecimal("AABRDP");
	this.AADFTC = reader.GetDecimal("AADFTC");	
    try{
        this.AASTIM = reader.GetDateTime("AASTIM");
    }catch {
        this.AASTIM = DateUtil.decimalMinutesToHoursHHMM(reader.GetDecimal("AASTIM"));
    }
	this.AAVBRD = reader.GetDecimal("AAVBRD");
	this.AAFRML = reader.GetString("AAFRML");
	this.AARCVL = reader.GetString("AARCVL");
	this.AAINSP = reader.GetString("AAINSP");
	this.AAPLNT = reader.GetString("AAPLNT");
	this.AAOSRV = reader.GetString("AAOSRV");
	this.AAFUT1 = reader.GetString("AAFUT1");
	this.AAFUT2 = reader.GetString("AAFUT2");
	this.AAFUT3 = reader.GetString("AAFUT3");
	this.AAFUT4 = reader.GetString("AAFUT4");
	this.AAFUT5 = reader.GetString("AAFUT5");
	this.AAFUT6 = reader.GetString("AAFUT6");
	this.AAFUT7 = reader.GetDecimal("AAFUT7");
	this.AAFLG1 = reader.GetString("AAFLG1");
	this.AAFLG2 = reader.GetString("AAFLG2");
	this.AAFLG3 = reader.GetString("AAFLG3");
	this.AAFLG4 = reader.GetString("AAFLG4");
	this.AAFLG5 = reader.GetString("AAFLG5");
	this.AAVBRP = reader.GetDecimal("AAVBRP");
	this.AAWPDR = reader.GetString("AAWPDR");
	this.AAWPRV = reader.GetString("AAWPRV");
}
public override	
void write(){
	try{
		string sql = "insert into depts values('" +
			Converter.fixString(AADEPT) + "', '" +
			Converter.fixString(AABLNK) + "', '" +
			Converter.fixString(AADNME) + "', " +
			NumberUtil.toString(AASTDR) + ", " +
			NumberUtil.toString(AABRDR) + ", " +
			NumberUtil.toString(AAMACH) + ", " +
			NumberUtil.toString(AABRDP) + ", " +
			NumberUtil.toString(AADFTC) + ", '" +
			DateUtil.getCompleteDateRepresentation(AASTIM) + "', " +
			NumberUtil.toString(AAVBRD) + ", '" +
			Converter.fixString(AAFRML) + "', '" +
			Converter.fixString(AARCVL) + "', '" +
			Converter.fixString(AAINSP) + "', '" +
			Converter.fixString(AAPLNT) + "', '" +
			Converter.fixString(AAOSRV) + "', '" +
			Converter.fixString(AAFUT1) + "', '" +
			Converter.fixString(AAFUT2) + "', '" +
			Converter.fixString(AAFUT3) + "', '" +
			Converter.fixString(AAFUT4) + "', '" +
			Converter.fixString(AAFUT5) + "', '" +
			Converter.fixString(AAFUT6) + "', " +
			NumberUtil.toString(AAFUT7) + ", '" +
			Converter.fixString(AAFLG1) + "', '" +
			Converter.fixString(AAFLG2) + "', '" +
			Converter.fixString(AAFLG3) + "', '" +
			Converter.fixString(AAFLG4) + "', '" +
			Converter.fixString(AAFLG5) + "', " +
			NumberUtil.toString(AAVBRP) + ", '" +
			Converter.fixString(AAWPDR) + "', '" +
			Converter.fixString(AAWPRV) + "')";
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
void setAADEPT(string AADEPT){
	this.AADEPT = AADEPT;
}
public
void setAABLNK(string AABLNK){
	this.AABLNK = AABLNK;
}
public
void setAADNME(string AADNME){
	this.AADNME = AADNME;
}
public
void setAASTDR(decimal AASTDR){
	this.AASTDR = AASTDR;
}
public
void setAABRDR(decimal AABRDR){
	this.AABRDR = AABRDR;
}
public
void setAAMACH(decimal AAMACH){
	this.AAMACH = AAMACH;
}
public
void setAABRDP(decimal AABRDP){
	this.AABRDP = AABRDP;
}
public
void setAADFTC(decimal AADFTC){
	this.AADFTC = AADFTC;
}
public
void setAASTIM(DateTime AASTIM){
	this.AASTIM = AASTIM;
}
public
void setAAVBRD(decimal AAVBRD){
	this.AAVBRD = AAVBRD;
}
public
void setAAFRML(string AAFRML){
	this.AAFRML = AAFRML;
}
public
void setAARCVL(string AARCVL){
	this.AARCVL = AARCVL;
}
public
void setAAINSP(string AAINSP){
	this.AAINSP = AAINSP;
}
public
void setAAPLNT(string AAPLNT){
	this.AAPLNT = AAPLNT;
}
public
void setAAOSRV(string AAOSRV){
	this.AAOSRV = AAOSRV;
}
public
void setAAFUT1(string AAFUT1){
	this.AAFUT1 = AAFUT1;
}
public
void setAAFUT2(string AAFUT2){
	this.AAFUT2 = AAFUT2;
}
public
void setAAFUT3(string AAFUT3){
	this.AAFUT3 = AAFUT3;
}
public
void setAAFUT4(string AAFUT4){
	this.AAFUT4 = AAFUT4;
}
public
void setAAFUT5(string AAFUT5){
	this.AAFUT5 = AAFUT5;
}
public
void setAAFUT6(string AAFUT6){
	this.AAFUT6 = AAFUT6;
}
public
void setAAFUT7(decimal AAFUT7){
	this.AAFUT7 = AAFUT7;
}
public
void setAAFLG1(string AAFLG1){
	this.AAFLG1 = AAFLG1;
}
public
void setAAFLG2(string AAFLG2){
	this.AAFLG2 = AAFLG2;
}
public
void setAAFLG3(string AAFLG3){
	this.AAFLG3 = AAFLG3;
}
public
void setAAFLG4(string AAFLG4){
	this.AAFLG4 = AAFLG4;
}
public
void setAAFLG5(string AAFLG5){
	this.AAFLG5 = AAFLG5;
}
public
void setAAVBRP(decimal AAVBRP){
	this.AAVBRP = AAVBRP;
}
public
void setAAWPDR(string AAWPDR){
	this.AAWPDR = AAWPDR;
}
public
void setAAWPRV(string AAWPRV){
	this.AAWPRV = AAWPRV;
}
public
string getAADEPT(){
	return AADEPT;
}
public
string getAABLNK(){
	return AABLNK;
}
public
string getAADNME(){
	return AADNME;
}
public
decimal getAASTDR(){
	return AASTDR;
}
public
decimal getAABRDR(){
	return AABRDR;
}
public
decimal getAAMACH(){
	return AAMACH;
}
public
decimal getAABRDP(){
	return AABRDP;
}
public
decimal getAADFTC(){
	return AADFTC;
}
public
DateTime getAASTIM(){
	return AASTIM;
}
public
decimal getAAVBRD(){
	return AAVBRD;
}
public
string getAAFRML(){
	return AAFRML;
}
public
string getAARCVL(){
	return AARCVL;
}
public
string getAAINSP(){
	return AAINSP;
}
public
string getAAPLNT(){
	return AAPLNT;
}
public
string getAAOSRV(){
	return AAOSRV;
}
public
string getAAFUT1(){
	return AAFUT1;
}
public
string getAAFUT2(){
	return AAFUT2;
}
public
string getAAFUT3(){
	return AAFUT3;
}
public
string getAAFUT4(){
	return AAFUT4;
}
public
string getAAFUT5(){
	return AAFUT5;
}
public
string getAAFUT6(){
	return AAFUT6;
}
public
decimal getAAFUT7(){
	return AAFUT7;
}
public
string getAAFLG1(){
	return AAFLG1;
}
public
string getAAFLG2(){
	return AAFLG2;
}
public
string getAAFLG3(){
	return AAFLG3;
}
public
string getAAFLG4(){
	return AAFLG4;
}
public
string getAAFLG5(){
	return AAFLG5;
}
public
decimal getAAVBRP(){
	return AAVBRP;
}
public
string getAAWPDR(){
	return AAWPDR;
}
public
string getAAWPRV(){
	return AAWPRV;
}
} // class
} // namespace