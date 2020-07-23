using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{
public 
class IcstmDataBase : GenericDataBaseElement{
private string CGPART;
private decimal CGLABS;
private decimal CGMATS;
private decimal CGBURS;
private decimal CGLABA;
private decimal CGMATA;
private decimal CGBURA;
private decimal CGLABV;
private decimal CGMATV;
private decimal CGBURV;
private decimal CGTPTD;
private DateTime CGSDAT;
private decimal CGSTCS;
private decimal CGACCS;
private decimal CGAVCS;
private decimal CGSTOC;
private decimal CGACOC;
private decimal CGAVOC;
private decimal CGSQTY;
private decimal CGAQTY;
private string CGTYPE;
private decimal CGBRFS;
private decimal CGBRVS;
private decimal CGBRFA;
private decimal CGBRVA;
private decimal CGBRFV;
private decimal CGBRVV;
private decimal CGFUTS;
private decimal CGFUTA;
private decimal CGFUTV;
private string CGPLNT;
private string CGFUT1;
private string CGFUT2;
private string CGFUT3;
private decimal CGFUT4;
private decimal CGFUT5;
private string CGFLG1;
private string CGFLG2;
private string CGFLG3;
public 
IcstmDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
public
void load(NotNullDataReader reader){
  	this.CGPART = reader.GetString("CGPART");
    this.CGLABS = reader.GetDecimal("CGLABS");
    this.CGMATS = reader.GetDecimal("CGMATS");
    this.CGBURS = reader.GetDecimal("CGBURS");
    this.CGLABA = reader.GetDecimal("CGLABA");
    this.CGMATA = reader.GetDecimal("CGMATA");
    this.CGBURA = reader.GetDecimal("CGBURA");
    this.CGLABV = reader.GetDecimal("CGLABV");
    this.CGMATV = reader.GetDecimal("CGMATV");
    this.CGBURV = reader.GetDecimal("CGBURV");
    this.CGTPTD = reader.GetDecimal("CGTPTD");
    this.CGSDAT = reader.GetDateTime("CGSDAT");
    this.CGSTCS = reader.GetDecimal("CGSTCS");
    this.CGACCS = reader.GetDecimal("CGACCS");
    this.CGAVCS = reader.GetDecimal("CGAVCS");
    this.CGSTOC = reader.GetDecimal("CGSTOC");
    this.CGACOC = reader.GetDecimal("CGACOC");
    this.CGAVOC = reader.GetDecimal("CGAVOC");
    this.CGSQTY = reader.GetDecimal("CGSQTY");
    this.CGAQTY = reader.GetDecimal("CGAQTY");
    this.CGTYPE = reader.GetString("CGTYPE");
    this.CGBRFS = reader.GetDecimal("CGBRFS");
    this.CGBRVS = reader.GetDecimal("CGBRVS");
    this.CGBRFA = reader.GetDecimal("CGBRFA");
    this.CGBRVA = reader.GetDecimal("CGBRVA");
    this.CGBRFV = reader.GetDecimal("CGBRFV");
    this.CGBRVV = reader.GetDecimal("CGBRVV");
    this.CGFUTS = reader.GetDecimal("CGFUTS");
    this.CGFUTA = reader.GetDecimal("CGFUTA");
    this.CGFUTV = reader.GetDecimal("CGFUTV");
    this.CGPLNT = reader.GetString("CGPLNT");
    this.CGFUT1 = reader.GetString("CGFUT1");
    this.CGFUT2 = reader.GetString("CGFUT2");
    this.CGFUT3 = reader.GetString("CGFUT3");
    this.CGFUT4 = reader.GetDecimal("CGFUT4");
    this.CGFUT5 = reader.GetDecimal("CGFUT5");
    this.CGFLG1 = reader.GetString("CGFLG1");
    this.CGFLG2 = reader.GetString("CGFLG2");
    this.CGFLG3 = reader.GetString("CGFLG3");
}
public override
void write(){
    try{
		string sql = "insert into icstm values('" +
                Converter.fixString(CGPART) +"', " +
                NumberUtil.toString(CGLABS) +", " +
                NumberUtil.toString(CGMATS) +", " +
                NumberUtil.toString(CGBURS) +", " +
                NumberUtil.toString(CGLABA) +", " +
                NumberUtil.toString(CGMATA) +", " +
                NumberUtil.toString(CGBURA) +", " +
                NumberUtil.toString(CGLABV) +", " +
                NumberUtil.toString(CGMATV) +", " +
                NumberUtil.toString(CGBURV) +", " +
                NumberUtil.toString(CGTPTD) +", '" +
                DateUtil.getCompleteDateRepresentation(CGSDAT) +"', " +
                NumberUtil.toString(CGSTCS) +", " +
                NumberUtil.toString(CGACCS) +", " +
                NumberUtil.toString(CGAVCS) +", " +
                NumberUtil.toString(CGSTOC) +", " +
                NumberUtil.toString(CGACOC) +", " +
                NumberUtil.toString(CGAVOC) +", " +
                NumberUtil.toString(CGSQTY) +", " +
                NumberUtil.toString(CGAQTY) +", '" +
                Converter.fixString(CGTYPE) +"', " +
                NumberUtil.toString(CGBRFS) +", " +
                NumberUtil.toString(CGBRVS) +", " +
                NumberUtil.toString(CGBRFA) +", " +
                NumberUtil.toString(CGBRVA) +", " +
                NumberUtil.toString(CGBRFV) +", " +
                NumberUtil.toString(CGBRVV) +", " +
                NumberUtil.toString(CGFUTS) +", " +
                NumberUtil.toString(CGFUTA) +", " +
                NumberUtil.toString(CGFUTV) +", '" +
                Converter.fixString(CGPLNT) +"', '" +
                Converter.fixString(CGFUT1) +"', '" +
                Converter.fixString(CGFUT2) +"', '" +
                Converter.fixString(CGFUT3) +"', " +
                NumberUtil.toString(CGFUT4) +", " +
                NumberUtil.toString(CGFUT5) +", '" +
                Converter.fixString(CGFLG1) +"', '" +
                Converter.fixString(CGFLG2) +"', '" +
                Converter.fixString(CGFLG3) +"')";
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
void setCGPART(string CGPART){
    this.CGPART = CGPART;
}
public 
void setCGLABS(decimal CGLABS){
    this.CGLABS = CGLABS;
}
public 
void setCGMATS(decimal CGMATS){
    this.CGMATS = CGMATS;
}
public 
void setCGBURS(decimal CGBURS){
    this.CGBURS = CGBURS;
}
public 
void setCGLABA(decimal CGLABA){
    this.CGLABA = CGLABA;
}
public 
void setCGMATA(decimal CGMATA){
    this.CGMATA = CGMATA;
}
public 
void setCGBURA(decimal CGBURA){
    this.CGBURA = CGBURA;
}
public 
void setCGLABV(decimal CGLABV){
    this.CGLABV = CGLABV;
}
public 
void setCGMATV(decimal CGMATV){
    this.CGMATV = CGMATV;
}
public 
void setCGBURV(decimal CGBURV){
    this.CGBURV = CGBURV;
}
public 
void setCGTPTD(decimal CGTPTD){
    this.CGTPTD = CGTPTD;
}
public 
void setCGSDAT(DateTime CGSDAT){
    this.CGSDAT = CGSDAT;
}
public 
void setCGSTCS(decimal CGSTCS){
    this.CGSTCS = CGSTCS;
}
public 
void setCGACCS(decimal CGACCS){
    this.CGACCS = CGACCS;
}
public 
void setCGAVCS(decimal CGAVCS){
    this.CGAVCS = CGAVCS;
}
public 
void setCGSTOC(decimal CGSTOC){
    this.CGSTOC = CGSTOC;
}
public 
void setCGACOC(decimal CGACOC){
    this.CGACOC = CGACOC;
}
public 
void setCGAVOC(decimal CGAVOC){
    this.CGAVOC = CGAVOC;
}
public 
void setCGSQTY(decimal CGSQTY){
    this.CGSQTY = CGSQTY;
}
public 
void setCGAQTY(decimal CGAQTY){
    this.CGAQTY = CGAQTY;
}
public 
void setCGTYPE(string CGTYPE){
    this.CGTYPE = CGTYPE;
}
public 
void setCGBRFS(decimal CGBRFS){
    this.CGBRFS = CGBRFS;
}
public 
void setCGBRVS(decimal CGBRVS){
    this.CGBRVS = CGBRVS;
}
public 
void setCGBRFA(decimal CGBRFA){
    this.CGBRFA = CGBRFA;
}
public 
void setCGBRVA(decimal CGBRVA){
    this.CGBRVA = CGBRVA;
}
public 
void setCGBRFV(decimal CGBRFV){
    this.CGBRFV = CGBRFV;
}
public 
void setCGBRVV(decimal CGBRVV){
    this.CGBRVV = CGBRVV;
}
public 
void setCGFUTS(decimal CGFUTS){
    this.CGFUTS = CGFUTS;
}
public 
void setCGFUTA(decimal CGFUTA){
    this.CGFUTA = CGFUTA;
}
public 
void setCGFUTV(decimal CGFUTV){
    this.CGFUTV = CGFUTV;
}
public 
void setCGPLNT(string CGPLNT){
    this.CGPLNT = CGPLNT;
}
public 
void setCGFUT1(string CGFUT1){
    this.CGFUT1 = CGFUT1;
}
public 
void setCGFUT2(string CGFUT2){
    this.CGFUT2 = CGFUT2;
}
public 
void setCGFUT3(string CGFUT3){
    this.CGFUT3 = CGFUT3;
}
public 
void setCGFUT4(decimal CGFUT4){
    this.CGFUT4 = CGFUT4;
}
public 
void setCGFUT5(decimal CGFUT5){
    this.CGFUT5 = CGFUT5;
}
public 
void setCGFLG1(string CGFLG1){
    this.CGFLG1 = CGFLG1;
}
public 
void setCGFLG2(string CGFLG2){
    this.CGFLG2 = CGFLG2;
}
public 
void setCGFLG3(string CGFLG3){
    this.CGFLG3 = CGFLG3;
}
//Getters
public 
string getCGPART(){
    return CGPART;
}
public 
decimal getCGLABS(){
    return CGLABS;
}
public 
decimal getCGMATS(){
    return CGMATS;
}
public 
decimal getCGBURS(){
    return CGBURS;
}
public 
decimal getCGLABA(){
    return CGLABA;
}
public 
decimal getCGMATA(){
    return CGMATA;
}
public 
decimal getCGBURA(){
    return CGBURA;
}
public 
decimal getCGLABV(){
    return CGLABV;
}
public 
decimal getCGMATV(){
    return CGMATV;
}
public 
decimal getCGBURV(){
    return CGBURV;
}
public 
decimal getCGTPTD(){
    return CGTPTD;
}
public 
DateTime getCGSDAT(){
    return CGSDAT;
}
public 
decimal getCGSTCS(){
    return CGSTCS;
}
public 
decimal getCGACCS(){
    return CGACCS;
}
public 
decimal getCGAVCS(){
    return CGAVCS;
}
public 
decimal getCGSTOC(){
    return CGSTOC;
}
public 
decimal getCGACOC(){
    return CGACOC;
}
public 
decimal getCGAVOC(){
    return CGAVOC;
}
public 
decimal getCGSQTY(){
    return CGSQTY;
}
public 
decimal getCGAQTY(){
    return CGAQTY;
}
public 
string getCGTYPE(){
    return CGTYPE;
}
public 
decimal getCGBRFS(){
    return CGBRFS;
}
public 
decimal getCGBRVS(){
    return CGBRVS;
}
public 
decimal getCGBRFA(){
    return CGBRFA;
}
public 
decimal getCGBRVA(){
    return CGBRVA;
}
public 
decimal getCGBRFV(){
    return CGBRFV;
}
public 
decimal getCGBRVV(){
    return CGBRVV;
}
public 
decimal getCGFUTS(){
    return CGFUTS;
}
public 
decimal getCGFUTA(){
    return CGFUTA;
}
public 
decimal getCGFUTV(){
    return CGFUTV;
}
public 
string getCGPLNT(){
    return CGPLNT;
}
public 
string getCGFUT1(){
    return CGFUT1;
}
public 
string getCGFUT2(){
    return CGFUT2;
}
public 
string getCGFUT3(){
    return CGFUT3;
}
public 
decimal getCGFUT4(){
    return CGFUT4;
}
public 
decimal getCGFUT5(){
    return CGFUT5;
}
public 
string getCGFLG1(){
    return CGFLG1;
}
public 
string getCGFLG2(){
    return CGFLG2;
}
public 
string getCGFLG3(){
    return CGFLG3;
}
}//end class
}//end namespace
