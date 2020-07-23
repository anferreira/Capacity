using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{
public 
class PlntDataBase : GenericDataBaseElement{
private string YAPLNT;
private string YAPNME;
private decimal YAADR;
private string YASLOC;
private string YARLOC;
private string YATLOC;
private string YATMZN;
private decimal YAMRPS;
private decimal YAMTHC;
private string YASLSF;
private string YACUSR;
private DateTime YACDAT;
private DateTime YACTME;
private string YAUUSR;
private DateTime YAUDAT;
private DateTime YAUTME;
private string YAFUT1;
private string YAFUT2;
private string YAFUT3;
private string YAFUT4;
private string YAFUT5;
private string YAFUT6;
private string YAFUT7;
private string YAFUT8;
private decimal YAFUT9;
private string YAFLG1;
private string YAFLG2;
private string YAFLG3;
private string YAFLG4;
private string YAFLG5;
		
public 
PlntDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
			
public override
void load(NotNullDataReader reader){
	this.YAPLNT = reader.GetString("YAPLNT");
	this.YAPNME = reader.GetString("YAPNME");	
    try{
        this.YAADR = reader.GetDecimal("YAADR#");
    }catch {
        this.YAADR = reader.GetDecimal("YAADR");
    }
	this.YASLOC = reader.GetString("YASLOC");
	this.YARLOC = reader.GetString("YARLOC");
	this.YATLOC = reader.GetString("YATLOC");
	this.YATMZN = reader.GetString("YATMZN");
	this.YAMRPS = reader.GetDecimal("YAMRPS");
	this.YAMTHC = reader.GetDecimal("YAMTHC");
	this.YASLSF = reader.GetString("YASLSF");
	this.YACUSR = reader.GetString("YACUSR");
    try{
        this.YACTME = reader.GetDateTime("YACTME");
    }catch {
        this.YACTME = DateUtil.decimalMinutesToHoursHHMM(reader.GetDecimal("YACTME"));
    }
	this.YAUUSR = reader.GetString("YAUUSR");
	this.YAUDAT = reader.GetDateTime("YAUDAT");	
    try{
        this.YAUTME = reader.GetDateTime("YAUTME");
    }catch {
        this.YAUTME = DateUtil.decimalMinutesToHoursHHMM(reader.GetDecimal("YAUTME"));
    }
	this.YAFUT1 = reader.GetString("YAFUT1");
	this.YAFUT2 = reader.GetString("YAFUT2");
	this.YAFUT3 = reader.GetString("YAFUT3");
	this.YAFUT4 = reader.GetString("YAFUT4");
	this.YAFUT5 = reader.GetString("YAFUT5");
	this.YAFUT6 = reader.GetString("YAFUT6");
	this.YAFUT7 = reader.GetString("YAFUT7");
	this.YAFUT8 = reader.GetString("YAFUT8");
	this.YAFUT9 = reader.GetDecimal("YAFUT9");
	this.YAFLG1 = reader.GetString("YAFLG1");
	this.YAFLG2 = reader.GetString("YAFLG2");
	this.YAFLG3 = reader.GetString("YAFLG3");
	this.YAFLG4 = reader.GetString("YAFLG4");
	this.YAFLG5 = reader.GetString("YAFLG5");
}
public override	
void write(){
	
	string sql = "insert into plnt values('" +
		Converter.fixString(YAPLNT) + "', '" +
		Converter.fixString(YAPNME) + "', " +
		NumberUtil.toString(YAADR) + ", '" +
		Converter.fixString(YASLOC) + "', '" +
		Converter.fixString(YARLOC) + "', '" +
		Converter.fixString(YATLOC) + "', '" +
		Converter.fixString(YATMZN) + "', " +
		NumberUtil.toString(YAMRPS) + ", " +
		NumberUtil.toString(YAMTHC) + ", '" +
		Converter.fixString(YASLSF) + "', '" +
		Converter.fixString(YACUSR) + "', '" +
		DateUtil.getCompleteDateRepresentation(YACDAT) + "', '" +
		DateUtil.getCompleteDateRepresentation(YACTME) + "', '" +
		Converter.fixString(YAUUSR) + "', '" +
		DateUtil.getCompleteDateRepresentation(YAUDAT) + "', '" +
		DateUtil.getCompleteDateRepresentation(YAUTME) + "', '" +
		Converter.fixString(YAFUT1) + "', '" +
		Converter.fixString(YAFUT2) + "', '" +
		Converter.fixString(YAFUT3) + "', '" +
		Converter.fixString(YAFUT4) + "', '" +
		Converter.fixString(YAFUT5) + "', '" +
		Converter.fixString(YAFUT6) + "', '" +
		Converter.fixString(YAFUT7) + "', '" +
		Converter.fixString(YAFUT8) + "', " +
		NumberUtil.toString(YAFUT9) + ", '" +
		Converter.fixString(YAFLG1) + "', '" +
		Converter.fixString(YAFLG2) + "', '" +
		Converter.fixString(YAFLG3) + "', '" +
		Converter.fixString(YAFLG4) + "', '" +
		Converter.fixString(YAFLG5) + "')";
		write(sql);
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
void setYAPLNT(string YAPLNT){
	this.YAPLNT = YAPLNT;
}
public
void setYAPNME(string YAPNME){
	this.YAPNME = YAPNME;
}
public
void setYAADR(decimal YAADR){
	this.YAADR = YAADR;
}
public
void setYASLOC(string YASLOC){
	this.YASLOC = YASLOC;
}
public
void setYARLOC(string YARLOC){
	this.YARLOC = YARLOC;
}
public
void setYATLOC(string YATLOC){
	this.YATLOC = YATLOC;
}
public
void setYATMZN(string YATMZN){
	this.YATMZN = YATMZN;
}
public
void setYAMRPS(decimal YAMRPS){
	this.YAMRPS = YAMRPS;
}
public
void setYAMTHC(decimal YAMTHC){
	this.YAMTHC = YAMTHC;
}
public
void setYASLSF(string YASLSF){
	this.YASLSF = YASLSF;
}
public
void setYACUSR(string YACUSR){
	this.YACUSR = YACUSR;
}
public
void setYACDAT(DateTime YACDAT){
	this.YACDAT = YACDAT;
}
public
void setYACTME(DateTime YACTME){
	this.YACTME = YACTME;
}
public
void setYAUUSR(string YAUUSR){
	this.YAUUSR = YAUUSR;
}
public
void setYAUDAT(DateTime YAUDAT){
	this.YAUDAT = YAUDAT;
}
public
void setYAUTME(DateTime YAUTME){
	this.YAUTME = YAUTME;
}
public
void setYAFUT1(string YAFUT1){
	this.YAFUT1 = YAFUT1;
}
public
void setYAFUT2(string YAFUT2){
	this.YAFUT2 = YAFUT2;
}
public
void setYAFUT3(string YAFUT3){
	this.YAFUT3 = YAFUT3;
}
public
void setYAFUT4(string YAFUT4){
	this.YAFUT4 = YAFUT4;
}
public
void setYAFUT5(string YAFUT5){
	this.YAFUT5 = YAFUT5;
}
public
void setYAFUT6(string YAFUT6){
	this.YAFUT6 = YAFUT6;
}
public
void setYAFUT7(string YAFUT7){
	this.YAFUT7 = YAFUT7;
}
public
void setYAFUT8(string YAFUT8){
	this.YAFUT8 = YAFUT8;
}
public
void setYAFUT9(decimal YAFUT9){
	this.YAFUT9 = YAFUT9;
}
public
void setYAFLG1(string YAFLG1){
	this.YAFLG1 = YAFLG1;
}
public
void setYAFLG2(string YAFLG2){
	this.YAFLG2 = YAFLG2;
}
public
void setYAFLG3(string YAFLG3){
	this.YAFLG3 = YAFLG3;
}
public
void setYAFLG4(string YAFLG4){
	this.YAFLG4 = YAFLG4;
}
public
void setYAFLG5(string YAFLG5){
	this.YAFLG5 = YAFLG5;
}
public
string getYAPLNT(){
	return YAPLNT;
}
public
string getYAPNME(){
	return YAPNME;
}
public
decimal getYAADR(){
	return YAADR;
}
public
string getYASLOC(){
	return YASLOC;
}
public
string getYARLOC(){
	return YARLOC;
}
public
string getYATLOC(){
	return YATLOC;
}
public
string getYATMZN(){
	return YATMZN;
}
public
decimal getYAMRPS(){
	return YAMRPS;
}
public
decimal getYAMTHC(){
	return YAMTHC;
}
public
string getYASLSF(){
	return YASLSF;
}
public
string getYACUSR(){
	return YACUSR;
}
public
DateTime getYACDAT(){
	return YACDAT;
}
public
DateTime getYACTME(){
	return YACTME;
}
public
string getYAUUSR(){
	return YAUUSR;
}
public
DateTime getYAUDAT(){
	return YAUDAT;
}
public
DateTime getYAUTME(){
	return YAUTME;
}
public
string getYAFUT1(){
	return YAFUT1;
}
public
string getYAFUT2(){
	return YAFUT2;
}
public
string getYAFUT3(){
	return YAFUT3;
}
public
string getYAFUT4(){
	return YAFUT4;
}
public
string getYAFUT5(){
	return YAFUT5;
}
public
string getYAFUT6(){
	return YAFUT6;
}
public
string getYAFUT7(){
	return YAFUT7;
}
public
string getYAFUT8(){
	return YAFUT8;
}
public
decimal getYAFUT9(){
	return YAFUT9;
}
public
string getYAFLG1(){
	return YAFLG1;
}
public
string getYAFLG2(){
	return YAFLG2;
}
public
string getYAFLG3(){
	return YAFLG3;
}
public
string getYAFLG4(){
	return YAFLG4;
}
public
string getYAFLG5(){
	return YAFLG5;
}
} // class
} // namespace