/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class MetHdaDataBase : GenericDataBaseElement {

private string ARTYPE;
private string ARPLNT;
private string ARPART;
private decimal ARSEQ;
private decimal ARLIN;
private string ARDEPT;
private string ARRESC;
private string AROPNM;
private decimal ARSETP;
private decimal ARRUNS;
private string ARRTYP;
private decimal ARSCRW;
private string ARREPP;
private decimal ARLAGT;
private decimal ARTBTH;
private string ARUNIT;
private string ARPRC;
private decimal AREFF;
private string ARBK03;
private decimal ARMEN;
private decimal ARMCH;
private string ARBK04;
private decimal ARCTME;
private decimal ARMULT;
private decimal ARCNOR;
private decimal ARBCDR;
private string ARFUT1;
private string ARFUT2;
private string ARFUT3;
private string ARFUT4;
private string ARFUT5;
private string ARFUT6;
private string ARFUT7;
private string ARFUT8;
private string ARFUT9;
private string ARFUTA;
private string ARFUTB;
private decimal ARFUTC;
private decimal ARFUTD;
private decimal ARFUTE;
private decimal ARFUTF;
private decimal ARSMCH;

public
MetHdaDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public
bool read(){
    string sql = "select * from " + getTablePrefix() + "methda where " + getWhereCondition();
	return read(sql);
}

public
bool exists(){
    string sql = "select * from " + getTablePrefix() + "methda where " + getWhereCondition();
	return exists(sql);
}

public override
void load(NotNullDataReader reader){
	this.ARTYPE = reader.GetString("ARTYPE");
	this.ARPLNT = reader.GetString("ARPLNT");
	this.ARPART = reader.GetString("ARPART");
	this.ARSEQ = reader.GetDecimal(getFieldDigit("ARSEQ"));
	this.ARLIN = reader.GetDecimal(getFieldDigit("ARLIN"));
	this.ARDEPT = reader.GetString("ARDEPT");
	this.ARRESC = reader.GetString("ARRESC");
	this.AROPNM = reader.GetString("AROPNM");
	this.ARSETP = reader.GetDecimal("ARSETP");
	this.ARRUNS = reader.GetDecimal("ARRUNS");
	this.ARRTYP = reader.GetString("ARRTYP");
	this.ARSCRW = reader.GetDecimal("ARSCRW");
	this.ARREPP = reader.GetString("ARREPP");
	this.ARLAGT = reader.GetDecimal("ARLAGT");
	this.ARTBTH = reader.GetDecimal("ARTBTH");
	this.ARUNIT = reader.GetString("ARUNIT");
	this.ARPRC = reader.GetString(getFieldDigit("ARPRC"));
	this.AREFF = reader.GetDecimal("AREFF");
	this.ARBK03 = reader.GetString("ARBK03");
	this.ARMEN = reader.GetDecimal(getFieldReplaceDigit("AR#MEN"));
	this.ARMCH = reader.GetDecimal(getFieldReplaceDigit("AR#MCH"));
	this.ARBK04 = reader.GetString("ARBK04");
	this.ARCTME = reader.GetDecimal("ARCTME");
	this.ARMULT = reader.GetDecimal("ARMULT");
	this.ARCNOR = reader.GetDecimal("ARCNOR");
	this.ARBCDR = reader.GetDecimal("ARBCDR");
	this.ARFUT1 = reader.GetString("ARFUT1");
	this.ARFUT2 = reader.GetString("ARFUT2");
	this.ARFUT3 = reader.GetString("ARFUT3");
	this.ARFUT4 = reader.GetString("ARFUT4");
	this.ARFUT5 = reader.GetString("ARFUT5");
	this.ARFUT6 = reader.GetString("ARFUT6");
	this.ARFUT7 = reader.GetString("ARFUT7");
	this.ARFUT8 = reader.GetString("ARFUT8");
	this.ARFUT9 = reader.GetString("ARFUT9");
	this.ARFUTA = reader.GetString("ARFUTA");
	this.ARFUTB = reader.GetString("ARFUTB");
	this.ARFUTC = reader.GetDecimal("ARFUTC");
	this.ARFUTD = reader.GetDecimal("ARFUTD");
	this.ARFUTE = reader.GetDecimal("ARFUTE");
	this.ARFUTF = reader.GetDecimal("ARFUTF");
	this.ARSMCH = reader.GetDecimal("ARSMCH");
}

public override
void write(){
    string sql = "insert into " + getTablePrefix() + "methda(" + 
		"ARTYPE," +
		"ARPLNT," +
		"ARPART," +
        getFieldDigit("ARSEQ") + "," +
        getFieldDigit("ARLIN") + "," +        
		"ARDEPT," +
		"ARRESC," +
		"AROPNM," +
		"ARSETP," +
		"ARRUNS," +
		"ARRTYP," +
		"ARSCRW," +
		"ARREPP," +
		"ARLAGT," +
		"ARTBTH," +
		"ARUNIT," +
        getFieldDigit("ARPRC") + "," +        
		"AREFF," +
		"ARBK03," +
        getFieldReplaceDigit("AR#MEN") + "," +
        getFieldReplaceDigit("AR#MCH") + "," +        
		"ARBK04," +
		"ARCTME," +
		"ARMULT," +
		"ARCNOR," +
		"ARBCDR," +
		"ARFUT1," +
		"ARFUT2," +
		"ARFUT3," +
		"ARFUT4," +
		"ARFUT5," +
		"ARFUT6," +
		"ARFUT7," +
		"ARFUT8," +
		"ARFUT9," +
		"ARFUTA," +
		"ARFUTB," +
		"ARFUTC," +
		"ARFUTD," +
		"ARFUTE," +
		"ARFUTF," +
		"ARSMCH" +

		") values (" + 

		"'" + Converter.fixString(ARTYPE) + "'," +
		"'" + Converter.fixString(ARPLNT) + "'," +
		"'" + Converter.fixString(ARPART) + "'," +
		"" + NumberUtil.toString(ARSEQ) + "," +
		"" + NumberUtil.toString(ARLIN) + "," +
		"'" + Converter.fixString(ARDEPT) + "'," +
		"'" + Converter.fixString(ARRESC) + "'," +
		"'" + Converter.fixString(AROPNM) + "'," +
		"" + NumberUtil.toString(ARSETP) + "," +
		"" + NumberUtil.toString(ARRUNS) + "," +
		"'" + Converter.fixString(ARRTYP) + "'," +
		"" + NumberUtil.toString(ARSCRW) + "," +
		"'" + Converter.fixString(ARREPP) + "'," +
		"" + NumberUtil.toString(ARLAGT) + "," +
		"" + NumberUtil.toString(ARTBTH) + "," +
		"'" + Converter.fixString(ARUNIT) + "'," +
		"'" + Converter.fixString(ARPRC) + "'," +
		"" + NumberUtil.toString(AREFF) + "," +
		"'" + Converter.fixString(ARBK03) + "'," +
		"" + NumberUtil.toString(ARMEN) + "," +
		"" + NumberUtil.toString(ARMCH) + "," +
		"'" + Converter.fixString(ARBK04) + "'," +
		"" + NumberUtil.toString(ARCTME) + "," +
		"" + NumberUtil.toString(ARMULT) + "," +
		"" + NumberUtil.toString(ARCNOR) + "," +
		"" + NumberUtil.toString(ARBCDR) + "," +
		"'" + Converter.fixString(ARFUT1) + "'," +
		"'" + Converter.fixString(ARFUT2) + "'," +
		"'" + Converter.fixString(ARFUT3) + "'," +
		"'" + Converter.fixString(ARFUT4) + "'," +
		"'" + Converter.fixString(ARFUT5) + "'," +
		"'" + Converter.fixString(ARFUT6) + "'," +
		"'" + Converter.fixString(ARFUT7) + "'," +
		"'" + Converter.fixString(ARFUT8) + "'," +
		"'" + Converter.fixString(ARFUT9) + "'," +
		"'" + Converter.fixString(ARFUTA) + "'," +
		"'" + Converter.fixString(ARFUTB) + "'," +
		"" + NumberUtil.toString(ARFUTC) + "," +
		"" + NumberUtil.toString(ARFUTD) + "," +
		"" + NumberUtil.toString(ARFUTE) + "," +
		"" + NumberUtil.toString(ARFUTF) + "," +
		"" + NumberUtil.toString(ARSMCH) + ")";
	write(sql);	
}

public override
void update(){
    string sql = "update " + getTablePrefix() + "methda set " +
		"ARTYPE = '" + Converter.fixString(ARTYPE) + "', " +
		"ARPLNT = '" + Converter.fixString(ARPLNT) + "', " +
		"ARPART = '" + Converter.fixString(ARPART) + "', " +
        getFieldDigit("ARSEQ") +" = " + NumberUtil.toString(ARSEQ) + ", " +
        getFieldDigit("ARLIN") +" = " + NumberUtil.toString(ARLIN) + ", " +
		"ARDEPT = '" + Converter.fixString(ARDEPT) + "', " +
		"ARRESC = '" + Converter.fixString(ARRESC) + "', " +
		"AROPNM = '" + Converter.fixString(AROPNM) + "', " +
		"ARSETP = " + NumberUtil.toString(ARSETP) + ", " +
		"ARRUNS = " + NumberUtil.toString(ARRUNS) + ", " +
		"ARRTYP = '" + Converter.fixString(ARRTYP) + "', " +
		"ARSCRW = " + NumberUtil.toString(ARSCRW) + ", " +
		"ARREPP = '" + Converter.fixString(ARREPP) + "', " +
		"ARLAGT = " + NumberUtil.toString(ARLAGT) + ", " +
		"ARTBTH = " + NumberUtil.toString(ARTBTH) + ", " +
		"ARUNIT = '" + Converter.fixString(ARUNIT) + "', " +
        getFieldDigit("ARPRC") + " = '" + Converter.fixString(ARPRC) + "', " +
		"AREFF = " + NumberUtil.toString(AREFF) + ", " +
		"ARBK03 = '" + Converter.fixString(ARBK03) + "', " +
        getFieldReplaceDigit("AR#MEN") + "= " + NumberUtil.toString(ARMEN) + ", " +
        getFieldReplaceDigit("AR#MCH") + "= " + NumberUtil.toString(ARMCH) + ", " +
		"ARBK04 = '" + Converter.fixString(ARBK04) + "', " +
		"ARCTME = " + NumberUtil.toString(ARCTME) + ", " +
		"ARMULT = " + NumberUtil.toString(ARMULT) + ", " +
		"ARCNOR = " + NumberUtil.toString(ARCNOR) + ", " +
		"ARBCDR = " + NumberUtil.toString(ARBCDR) + ", " +
		"ARFUT1 = '" + Converter.fixString(ARFUT1) + "', " +
		"ARFUT2 = '" + Converter.fixString(ARFUT2) + "', " +
		"ARFUT3 = '" + Converter.fixString(ARFUT3) + "', " +
		"ARFUT4 = '" + Converter.fixString(ARFUT4) + "', " +
		"ARFUT5 = '" + Converter.fixString(ARFUT5) + "', " +
		"ARFUT6 = '" + Converter.fixString(ARFUT6) + "', " +
		"ARFUT7 = '" + Converter.fixString(ARFUT7) + "', " +
		"ARFUT8 = '" + Converter.fixString(ARFUT8) + "', " +
		"ARFUT9 = '" + Converter.fixString(ARFUT9) + "', " +
		"ARFUTA = '" + Converter.fixString(ARFUTA) + "', " +
		"ARFUTB = '" + Converter.fixString(ARFUTB) + "', " +
		"ARFUTC = " + NumberUtil.toString(ARFUTC) + ", " +
		"ARFUTD = " + NumberUtil.toString(ARFUTD) + ", " +
		"ARFUTE = " + NumberUtil.toString(ARFUTE) + ", " +
		"ARFUTF = " + NumberUtil.toString(ARFUTF) + ", " +
		"ARSMCH = " + NumberUtil.toString(ARSMCH) + " " +

		"where " + getWhereCondition();

	update(sql);
}

public override
void delete(){
	string sql = "delete from methda where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"ARTYPE = '" + Converter.fixString(ARTYPE) + "' and " +
		"ARPLNT = '" + Converter.fixString(ARPLNT) + "' and " +
		"ARPART = '" + Converter.fixString(ARPART) + "' and " +
        getFieldDigit("ARSEQ")+ " = " + NumberUtil.toString(ARSEQ) + " and " +
        getFieldDigit("ARLIN")+ " = " + NumberUtil.toString(ARLIN) + "";
	return sqlWhere;
}

public
void setARTYPE(string ARTYPE){
	this.ARTYPE = ARTYPE;
}

public
void setARPLNT(string ARPLNT){
	this.ARPLNT = ARPLNT;
}

public
void setARPART(string ARPART){
	this.ARPART = ARPART;
}

public
void setARSEQ(decimal ARSEQ){
	this.ARSEQ = ARSEQ;
}

public
void setARLIN(decimal ARLIN){
	this.ARLIN = ARLIN;
}

public
void setARDEPT(string ARDEPT){
	this.ARDEPT = ARDEPT;
}

public
void setARRESC(string ARRESC){
	this.ARRESC = ARRESC;
}

public
void setAROPNM(string AROPNM){
	this.AROPNM = AROPNM;
}

public
void setARSETP(decimal ARSETP){
	this.ARSETP = ARSETP;
}

public
void setARRUNS(decimal ARRUNS){
	this.ARRUNS = ARRUNS;
}

public
void setARRTYP(string ARRTYP){
	this.ARRTYP = ARRTYP;
}

public
void setARSCRW(decimal ARSCRW){
	this.ARSCRW = ARSCRW;
}

public
void setARREPP(string ARREPP){
	this.ARREPP = ARREPP;
}

public
void setARLAGT(decimal ARLAGT){
	this.ARLAGT = ARLAGT;
}

public
void setARTBTH(decimal ARTBTH){
	this.ARTBTH = ARTBTH;
}

public
void setARUNIT(string ARUNIT){
	this.ARUNIT = ARUNIT;
}

public
void setARPRC(string ARPRC){
	this.ARPRC = ARPRC;
}

public
void setAREFF(decimal AREFF){
	this.AREFF = AREFF;
}

public
void setARBK03(string ARBK03){
	this.ARBK03 = ARBK03;
}

public
void setARMEN(decimal ARMEN){
	this.ARMEN = ARMEN;
}

public
void setARMCH(decimal ARMCH){
	this.ARMCH = ARMCH;
}

public
void setARBK04(string ARBK04){
	this.ARBK04 = ARBK04;
}

public
void setARCTME(decimal ARCTME){
	this.ARCTME = ARCTME;
}

public
void setARMULT(decimal ARMULT){
	this.ARMULT = ARMULT;
}

public
void setARCNOR(decimal ARCNOR){
	this.ARCNOR = ARCNOR;
}

public
void setARBCDR(decimal ARBCDR){
	this.ARBCDR = ARBCDR;
}

public
void setARFUT1(string ARFUT1){
	this.ARFUT1 = ARFUT1;
}

public
void setARFUT2(string ARFUT2){
	this.ARFUT2 = ARFUT2;
}

public
void setARFUT3(string ARFUT3){
	this.ARFUT3 = ARFUT3;
}

public
void setARFUT4(string ARFUT4){
	this.ARFUT4 = ARFUT4;
}

public
void setARFUT5(string ARFUT5){
	this.ARFUT5 = ARFUT5;
}

public
void setARFUT6(string ARFUT6){
	this.ARFUT6 = ARFUT6;
}

public
void setARFUT7(string ARFUT7){
	this.ARFUT7 = ARFUT7;
}

public
void setARFUT8(string ARFUT8){
	this.ARFUT8 = ARFUT8;
}

public
void setARFUT9(string ARFUT9){
	this.ARFUT9 = ARFUT9;
}

public
void setARFUTA(string ARFUTA){
	this.ARFUTA = ARFUTA;
}

public
void setARFUTB(string ARFUTB){
	this.ARFUTB = ARFUTB;
}

public
void setARFUTC(decimal ARFUTC){
	this.ARFUTC = ARFUTC;
}

public
void setARFUTD(decimal ARFUTD){
	this.ARFUTD = ARFUTD;
}

public
void setARFUTE(decimal ARFUTE){
	this.ARFUTE = ARFUTE;
}

public
void setARFUTF(decimal ARFUTF){
	this.ARFUTF = ARFUTF;
}

public
void setARSMCH(decimal ARSMCH){
	this.ARSMCH = ARSMCH;
}

public
string getARTYPE(){
	return ARTYPE;
}

public
string getARPLNT(){
	return ARPLNT;
}

public
string getARPART(){
	return ARPART;
}

public
decimal getARSEQ(){
	return ARSEQ;
}

public
decimal getARLIN(){
	return ARLIN;
}

public
string getARDEPT(){
	return ARDEPT;
}

public
string getARRESC(){
	return ARRESC;
}

public
string getAROPNM(){
	return AROPNM;
}

public
decimal getARSETP(){
	return ARSETP;
}

public
decimal getARRUNS(){
	return ARRUNS;
}

public
string getARRTYP(){
	return ARRTYP;
}

public
decimal getARSCRW(){
	return ARSCRW;
}

public
string getARREPP(){
	return ARREPP;
}

public
decimal getARLAGT(){
	return ARLAGT;
}

public
decimal getARTBTH(){
	return ARTBTH;
}

public
string getARUNIT(){
	return ARUNIT;
}

public
string getARPRC(){
	return ARPRC;
}

public
decimal getAREFF(){
	return AREFF;
}

public
string getARBK03(){
	return ARBK03;
}

public
decimal getARMEN(){
	return ARMEN;
}

public
decimal getARMCH(){
	return ARMCH;
}

public
string getARBK04(){
	return ARBK04;
}

public
decimal getARCTME(){
	return ARCTME;
}

public
decimal getARMULT(){
	return ARMULT;
}

public
decimal getARCNOR(){
	return ARCNOR;
}

public
decimal getARBCDR(){
	return ARBCDR;
}

public
string getARFUT1(){
	return ARFUT1;
}

public
string getARFUT2(){
	return ARFUT2;
}

public
string getARFUT3(){
	return ARFUT3;
}

public
string getARFUT4(){
	return ARFUT4;
}

public
string getARFUT5(){
	return ARFUT5;
}

public
string getARFUT6(){
	return ARFUT6;
}

public
string getARFUT7(){
	return ARFUT7;
}

public
string getARFUT8(){
	return ARFUT8;
}

public
string getARFUT9(){
	return ARFUT9;
}

public
string getARFUTA(){
	return ARFUTA;
}

public
string getARFUTB(){
	return ARFUTB;
}

public
decimal getARFUTC(){
	return ARFUTC;
}

public
decimal getARFUTD(){
	return ARFUTD;
}

public
decimal getARFUTE(){
	return ARFUTE;
}

public
decimal getARFUTF(){
	return ARFUTF;
}

public
decimal getARSMCH(){
	return ARSMCH;
}

} // class
} // package