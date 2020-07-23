using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence{


public
class SeriDataBase : GenericDataBaseElement {

private decimal HTSERN;
private string HTPART;
private string HTLOTN;
private decimal HTSEQ;
private string HTJOBN;
private decimal HTQTY;
private decimal HTQTYC;
private string HTUNIT;
private string HTCTNR;
private string HTLBLT;
private string HTSRC;
private decimal HTMSTN;
private string HTMSTS;
private string HTSTKL;
private string HTBINL;
private string HTSTS;
private DateTime HTADAT;
private decimal HTGWGT;
private string HTWUNT;
private decimal HTTWGT;
private decimal HTFUT1;
private string HTFUT2;
private string HTFUT3;
private string HTFUT4;
private string HTFUT5;
private string HTFUT6;
private string HTCORG;
private string HTPSRN;
private string HTRCLF;
private string HTPLNT;
private string HTHDRF;
private string HTHDRS;
private string HTSTRN;
private string HTSUPS;
private decimal HTFUT7;
private decimal HTFUT8;
private decimal HTFUT9;
private decimal HTFU10;
private string HTFU11;
private string HTFU12;
private string HTFU13;
private string HTFU14;
private string HTFU15;
private string HTFU16;

public
SeriDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

   
public 
bool read(){
    string sql = "select * from " + getTablePrefix() + "seri where " + getWhereCondition();
    return read(sql);        
}    

public
bool exists(){
    string sql = "select * from " + getTablePrefix() + "seri where " + getWhereCondition();
	return exists(sql);
}

public 
void load(NotNullDataReader reader){
	this.HTSERN = reader.GetDecimal("HTSERN");
	this.HTPART = reader.GetString("HTPART");
	this.HTLOTN = reader.GetString("HTLOTN");
	this.HTSEQ = reader.GetDecimal("HTSEQ");
	this.HTJOBN = reader.GetString("HTJOBN");
	this.HTQTY = reader.GetDecimal("HTQTY");
	this.HTQTYC = reader.GetDecimal("HTQTYC");
	this.HTUNIT = reader.GetString("HTUNIT");
	this.HTCTNR = reader.GetString("HTCTNR");
	this.HTLBLT = reader.GetString("HTLBLT");
	this.HTSRC = reader.GetString("HTSRC");
	this.HTMSTN = reader.GetDecimal("HTMSTN");
	this.HTMSTS = reader.GetString("HTMSTS");
	this.HTSTKL = reader.GetString("HTSTKL");
	this.HTBINL = reader.GetString("HTBINL");
	this.HTSTS = reader.GetString("HTSTS");
	this.HTADAT = reader.GetDateTime("HTADAT");
	this.HTGWGT = reader.GetDecimal("HTGWGT");
	this.HTWUNT = reader.GetString("HTWUNT");
	this.HTTWGT = reader.GetDecimal("HTTWGT");
	this.HTFUT1 = reader.GetDecimal("HTFUT1");
	this.HTFUT2 = reader.GetString("HTFUT2");
	this.HTFUT3 = reader.GetString("HTFUT3");
	this.HTFUT4 = reader.GetString("HTFUT4");
	this.HTFUT5 = reader.GetString("HTFUT5");
	this.HTFUT6 = reader.GetString("HTFUT6");
	this.HTCORG = reader.GetString("HTCORG");
	this.HTPSRN = reader.GetString("HTPSRN");
	this.HTRCLF = reader.GetString("HTRCLF");
	this.HTPLNT = reader.GetString("HTPLNT");
	this.HTHDRF = reader.GetString("HTHDRF");
	this.HTHDRS = reader.GetString("HTHDRS");
	this.HTSTRN = reader.GetString("HTSTRN");
	this.HTSUPS = reader.GetString("HTSUPS");
	this.HTFUT7 = reader.GetDecimal("HTFUT7");
	this.HTFUT8 = reader.GetDecimal("HTFUT8");
	this.HTFUT9 = reader.GetDecimal("HTFUT9");
	this.HTFU10 = reader.GetDecimal("HTFU10");
	this.HTFU11 = reader.GetString("HTFU11");
	this.HTFU12 = reader.GetString("HTFU12");
	this.HTFU13 = reader.GetString("HTFU13");
	this.HTFU14 = reader.GetString("HTFU14");
	this.HTFU15 = reader.GetString("HTFU15");
	this.HTFU16 = reader.GetString("HTFU16");
}

public override 
void write(){
	
	 string sql = "insert into " + getTablePrefix() + "seri(" + 
		"HTSERN," +
		"HTPART," +
		"HTLOTN," +
		"HTSEQ," +
		"HTJOBN," +
		"HTQTY," +
		"HTQTYC," +
		"HTUNIT," +
		"HTCTNR," +
		"HTLBLT," +
		"HTSRC," +
		"HTMSTN," +
		"HTMSTS," +
		"HTSTKL," +
		"HTBINL," +
		"HTSTS," +
		"HTADAT," +
		"HTGWGT," +
		"HTWUNT," +
		"HTTWGT," +
		"HTFUT1," +
		"HTFUT2," +
		"HTFUT3," +
		"HTFUT4," +
		"HTFUT5," +
		"HTFUT6," +
		"HTCORG," +
		"HTPSRN," +
		"HTRCLF," +
		"HTPLNT," +
		"HTHDRF," +
		"HTHDRS," +
		"HTSTRN," +
		"HTSUPS," +
		"HTFUT7," +
		"HTFUT8," +
		"HTFUT9," +
		"HTFU10," +
		"HTFU11," +
		"HTFU12," +
		"HTFU13," +
		"HTFU14," +
		"HTFU15," +
		"HTFU16" +

		") values (" + 

		"" + NumberUtil.toString(HTSERN) + "," +
		"'" + Converter.fixString(HTPART) + "'," +
		"'" + Converter.fixString(HTLOTN) + "'," +
		"" + NumberUtil.toString(HTSEQ) + "," +
		"'" + Converter.fixString(HTJOBN) + "'," +
		"" + NumberUtil.toString(HTQTY) + "," +
		"" + NumberUtil.toString(HTQTYC) + "," +
		"'" + Converter.fixString(HTUNIT) + "'," +
		"'" + Converter.fixString(HTCTNR) + "'," +
		"'" + Converter.fixString(HTLBLT) + "'," +
		"'" + Converter.fixString(HTSRC) + "'," +
		"" + NumberUtil.toString(HTMSTN) + "," +
		"'" + Converter.fixString(HTMSTS) + "'," +
		"'" + Converter.fixString(HTSTKL) + "'," +
		"'" + Converter.fixString(HTBINL) + "'," +
		"'" + Converter.fixString(HTSTS) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(HTADAT) + "'," +
		"" + NumberUtil.toString(HTGWGT) + "," +
		"'" + Converter.fixString(HTWUNT) + "'," +
		"" + NumberUtil.toString(HTTWGT) + "," +
		"" + NumberUtil.toString(HTFUT1) + "," +
		"'" + Converter.fixString(HTFUT2) + "'," +
		"'" + Converter.fixString(HTFUT3) + "'," +
		"'" + Converter.fixString(HTFUT4) + "'," +
		"'" + Converter.fixString(HTFUT5) + "'," +
		"'" + Converter.fixString(HTFUT6) + "'," +
		"'" + Converter.fixString(HTCORG) + "'," +
		"'" + Converter.fixString(HTPSRN) + "'," +
		"'" + Converter.fixString(HTRCLF) + "'," +
		"'" + Converter.fixString(HTPLNT) + "'," +
		"'" + Converter.fixString(HTHDRF) + "'," +
		"'" + Converter.fixString(HTHDRS) + "'," +
		"'" + Converter.fixString(HTSTRN) + "'," +
		"'" + Converter.fixString(HTSUPS) + "'," +
		"" + NumberUtil.toString(HTFUT7) + "," +
		"" + NumberUtil.toString(HTFUT8) + "," +
		"" + NumberUtil.toString(HTFUT9) + "," +
		"" + NumberUtil.toString(HTFU10) + "," +
		"'" + Converter.fixString(HTFU11) + "'," +
		"'" + Converter.fixString(HTFU12) + "'," +
		"'" + Converter.fixString(HTFU13) + "'," +
		"'" + Converter.fixString(HTFU14) + "'," +
		"'" + Converter.fixString(HTFU15) + "'," +
		"'" + Converter.fixString(HTFU16) + "')";

    write(sql);	
}

public override
void update(){
    string sql = "update " + getTablePrefix() + "seri set " +
		"HTSERN = " + NumberUtil.toString(HTSERN) + ", " +
		"HTPART = '" + Converter.fixString(HTPART) + "', " +
		"HTLOTN = '" + Converter.fixString(HTLOTN) + "', " +
		"HTSEQ = " + NumberUtil.toString(HTSEQ) + ", " +
		"HTJOBN = '" + Converter.fixString(HTJOBN) + "', " +
		"HTQTY = " + NumberUtil.toString(HTQTY) + ", " +
		"HTQTYC = " + NumberUtil.toString(HTQTYC) + ", " +
		"HTUNIT = '" + Converter.fixString(HTUNIT) + "', " +
		"HTCTNR = '" + Converter.fixString(HTCTNR) + "', " +
		"HTLBLT = '" + Converter.fixString(HTLBLT) + "', " +
		"HTSRC = '" + Converter.fixString(HTSRC) + "', " +
		"HTMSTN = " + NumberUtil.toString(HTMSTN) + ", " +
		"HTMSTS = '" + Converter.fixString(HTMSTS) + "', " +
		"HTSTKL = '" + Converter.fixString(HTSTKL) + "', " +
		"HTBINL = '" + Converter.fixString(HTBINL) + "', " +
		"HTSTS = '" + Converter.fixString(HTSTS) + "', " +
		"HTADAT = '" + DateUtil.getCompleteDateRepresentation(HTADAT) + "', " +
		"HTGWGT = " + NumberUtil.toString(HTGWGT) + ", " +
		"HTWUNT = '" + Converter.fixString(HTWUNT) + "', " +
		"HTTWGT = " + NumberUtil.toString(HTTWGT) + ", " +
		"HTFUT1 = " + NumberUtil.toString(HTFUT1) + ", " +
		"HTFUT2 = '" + Converter.fixString(HTFUT2) + "', " +
		"HTFUT3 = '" + Converter.fixString(HTFUT3) + "', " +
		"HTFUT4 = '" + Converter.fixString(HTFUT4) + "', " +
		"HTFUT5 = '" + Converter.fixString(HTFUT5) + "', " +
		"HTFUT6 = '" + Converter.fixString(HTFUT6) + "', " +
		"HTCORG = '" + Converter.fixString(HTCORG) + "', " +
		"HTPSRN = '" + Converter.fixString(HTPSRN) + "', " +
		"HTRCLF = '" + Converter.fixString(HTRCLF) + "', " +
		"HTPLNT = '" + Converter.fixString(HTPLNT) + "', " +
		"HTHDRF = '" + Converter.fixString(HTHDRF) + "', " +
		"HTHDRS = '" + Converter.fixString(HTHDRS) + "', " +
		"HTSTRN = '" + Converter.fixString(HTSTRN) + "', " +
		"HTSUPS = '" + Converter.fixString(HTSUPS) + "', " +
		"HTFUT7 = " + NumberUtil.toString(HTFUT7) + ", " +
		"HTFUT8 = " + NumberUtil.toString(HTFUT8) + ", " +
		"HTFUT9 = " + NumberUtil.toString(HTFUT9) + ", " +
		"HTFU10 = " + NumberUtil.toString(HTFU10) + ", " +
		"HTFU11 = '" + Converter.fixString(HTFU11) + "', " +
		"HTFU12 = '" + Converter.fixString(HTFU12) + "', " +
		"HTFU13 = '" + Converter.fixString(HTFU13) + "', " +
		"HTFU14 = '" + Converter.fixString(HTFU14) + "', " +
		"HTFU15 = '" + Converter.fixString(HTFU15) + "', " +
		"HTFU16 = '" + Converter.fixString(HTFU16) + "' " +

		"where " + getWhereCondition();

	update(sql);
}

public
void updateSuppSerial(string sHTSUPS){
    string sql = "update " + getTablePrefix() + "seri set " +        
        "HTSUPS = '" + Converter.fixString(HTSUPS) + "' " +
        "where " + getWhereCondition();
    update(sql);
}

public override
void delete(){
    string sql = "delete from " + getTablePrefix() + "seri where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string sqlWhere =
		"HTSERN = " + NumberUtil.toString(HTSERN) + "";
	return sqlWhere;
}

public
void setHTSERN(decimal HTSERN){
	this.HTSERN = HTSERN;
}

public
void setHTPART(string HTPART){
	this.HTPART = HTPART;
}

public
void setHTLOTN(string HTLOTN){
	this.HTLOTN = HTLOTN;
}

public
void setHTSEQ(decimal HTSEQ){
	this.HTSEQ = HTSEQ;
}

public
void setHTJOBN(string HTJOBN){
	this.HTJOBN = HTJOBN;
}

public
void setHTQTY(decimal HTQTY){
	this.HTQTY = HTQTY;
}

public
void setHTQTYC(decimal HTQTYC){
	this.HTQTYC = HTQTYC;
}

public
void setHTUNIT(string HTUNIT){
	this.HTUNIT = HTUNIT;
}

public
void setHTCTNR(string HTCTNR){
	this.HTCTNR = HTCTNR;
}

public
void setHTLBLT(string HTLBLT){
	this.HTLBLT = HTLBLT;
}

public
void setHTSRC(string HTSRC){
	this.HTSRC = HTSRC;
}

public
void setHTMSTN(decimal HTMSTN){
	this.HTMSTN = HTMSTN;
}

public
void setHTMSTS(string HTMSTS){
	this.HTMSTS = HTMSTS;
}

public
void setHTSTKL(string HTSTKL){
	this.HTSTKL = HTSTKL;
}

public
void setHTBINL(string HTBINL){
	this.HTBINL = HTBINL;
}

public
void setHTSTS(string HTSTS){
	this.HTSTS = HTSTS;
}

public
void setHTADAT(DateTime HTADAT){
	this.HTADAT = HTADAT;
}

public
void setHTGWGT(decimal HTGWGT){
	this.HTGWGT = HTGWGT;
}

public
void setHTWUNT(string HTWUNT){
	this.HTWUNT = HTWUNT;
}

public
void setHTTWGT(decimal HTTWGT){
	this.HTTWGT = HTTWGT;
}

public
void setHTFUT1(decimal HTFUT1){
	this.HTFUT1 = HTFUT1;
}

public
void setHTFUT2(string HTFUT2){
	this.HTFUT2 = HTFUT2;
}

public
void setHTFUT3(string HTFUT3){
	this.HTFUT3 = HTFUT3;
}

public
void setHTFUT4(string HTFUT4){
	this.HTFUT4 = HTFUT4;
}

public
void setHTFUT5(string HTFUT5){
	this.HTFUT5 = HTFUT5;
}

public
void setHTFUT6(string HTFUT6){
	this.HTFUT6 = HTFUT6;
}

public
void setHTCORG(string HTCORG){
	this.HTCORG = HTCORG;
}

public
void setHTPSRN(string HTPSRN){
	this.HTPSRN = HTPSRN;
}

public
void setHTRCLF(string HTRCLF){
	this.HTRCLF = HTRCLF;
}

public
void setHTPLNT(string HTPLNT){
	this.HTPLNT = HTPLNT;
}

public
void setHTHDRF(string HTHDRF){
	this.HTHDRF = HTHDRF;
}

public
void setHTHDRS(string HTHDRS){
	this.HTHDRS = HTHDRS;
}

public
void setHTSTRN(string HTSTRN){
	this.HTSTRN = HTSTRN;
}

public
void setHTSUPS(string HTSUPS){
	this.HTSUPS = HTSUPS;
}

public
void setHTFUT7(decimal HTFUT7){
	this.HTFUT7 = HTFUT7;
}

public
void setHTFUT8(decimal HTFUT8){
	this.HTFUT8 = HTFUT8;
}

public
void setHTFUT9(decimal HTFUT9){
	this.HTFUT9 = HTFUT9;
}

public
void setHTFU10(decimal HTFU10){
	this.HTFU10 = HTFU10;
}

public
void setHTFU11(string HTFU11){
	this.HTFU11 = HTFU11;
}

public
void setHTFU12(string HTFU12){
	this.HTFU12 = HTFU12;
}

public
void setHTFU13(string HTFU13){
	this.HTFU13 = HTFU13;
}

public
void setHTFU14(string HTFU14){
	this.HTFU14 = HTFU14;
}

public
void setHTFU15(string HTFU15){
	this.HTFU15 = HTFU15;
}

public
void setHTFU16(string HTFU16){
	this.HTFU16 = HTFU16;
}

public
decimal getHTSERN(){
	return HTSERN;
}

public
string getHTPART(){
	return HTPART;
}

public
string getHTLOTN(){
	return HTLOTN;
}

public
decimal getHTSEQ(){
	return HTSEQ;
}

public
string getHTJOBN(){
	return HTJOBN;
}

public
decimal getHTQTY(){
	return HTQTY;
}

public
decimal getHTQTYC(){
	return HTQTYC;
}

public
string getHTUNIT(){
	return HTUNIT;
}

public
string getHTCTNR(){
	return HTCTNR;
}

public
string getHTLBLT(){
	return HTLBLT;
}

public
string getHTSRC(){
	return HTSRC;
}

public
decimal getHTMSTN(){
	return HTMSTN;
}

public
string getHTMSTS(){
	return HTMSTS;
}

public
string getHTSTKL(){
	return HTSTKL;
}

public
string getHTBINL(){
	return HTBINL;
}

public
string getHTSTS(){
	return HTSTS;
}

public
DateTime getHTADAT(){
	return HTADAT;
}

public
decimal getHTGWGT(){
	return HTGWGT;
}

public
string getHTWUNT(){
	return HTWUNT;
}

public
decimal getHTTWGT(){
	return HTTWGT;
}

public
decimal getHTFUT1(){
	return HTFUT1;
}

public
string getHTFUT2(){
	return HTFUT2;
}

public
string getHTFUT3(){
	return HTFUT3;
}

public
string getHTFUT4(){
	return HTFUT4;
}

public
string getHTFUT5(){
	return HTFUT5;
}

public
string getHTFUT6(){
	return HTFUT6;
}

public
string getHTCORG(){
	return HTCORG;
}

public
string getHTPSRN(){
	return HTPSRN;
}

public
string getHTRCLF(){
	return HTRCLF;
}

public
string getHTPLNT(){
	return HTPLNT;
}

public
string getHTHDRF(){
	return HTHDRF;
}

public
string getHTHDRS(){
	return HTHDRS;
}

public
string getHTSTRN(){
	return HTSTRN;
}

public
string getHTSUPS(){
	return HTSUPS;
}

public
decimal getHTFUT7(){
	return HTFUT7;
}

public
decimal getHTFUT8(){
	return HTFUT8;
}

public
decimal getHTFUT9(){
	return HTFUT9;
}

public
decimal getHTFU10(){
	return HTFU10;
}

public
string getHTFU11(){
	return HTFU11;
}

public
string getHTFU12(){
	return HTFU12;
}

public
string getHTFU13(){
	return HTFU13;
}

public
string getHTFU14(){
	return HTFU14;
}

public
string getHTFU15(){
	return HTFU15;
}

public
string getHTFU16(){
	return HTFU16;
}

} // class
} // package