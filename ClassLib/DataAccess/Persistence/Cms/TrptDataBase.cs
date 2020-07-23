using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class TrptDataBase : GenericDataBaseElement{

private string DB;
private string UATRPT;
private string UADESC;
private string UACNTC;
private string UAPHON;
private string UAFAXN;
private string UALOGO;
private string UAUPDS;
private string UABCUS;
private string UAUCPO;
private string UAFLG1;
private string UAFLG2;
private string UAPPRF;
private string UAATRD;
private string UATYPE;
private string UANPPO;
private string UANPEL;
private string UANPDK;
private string UADAAS;
private string UAFLG3;
private string UAFLG4;
private string UAFLG5;
private string UAFLG6;
private string UAFLG7;
private string UAFLG8;
private string UAFLG9;
private string UAFUT1;
private string UAFUT2;
private string UAFUT3;
private string UAFUT4;
private string UAFUT5;
private string UAFUT6;

public 
TrptDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){	
}

public
void load(NotNullDataReader reader){
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMSTEMP_DATABASE)
		this.DB = reader.GetString("DB");

    this.UATRPT = reader.GetString("UATRPT");
    this.UADESC = reader.GetString("UADESC");
    this.UACNTC = reader.GetString("UACNTC");
    this.UAPHON = reader.GetString("UAPHON");
    this.UAFAXN = reader.GetString("UAFAXN");
    this.UALOGO = reader.GetString("UALOGO");
    this.UAUPDS = reader.GetString("UAUPDS");
    this.UABCUS = reader.GetString("UABCUS");
    this.UAUCPO = reader.GetString("UAUCPO");
    this.UAFLG1 = reader.GetString("UAFLG1");
    this.UAFLG2 = reader.GetString("UAFLG2");
    this.UAPPRF = reader.GetString("UAPPRF");
    this.UAATRD = reader.GetString("UAATRD");
    this.UATYPE = reader.GetString("UATYPE");
    this.UANPPO = reader.GetString("UANPPO");
    this.UANPEL = reader.GetString("UANPEL");
    this.UANPDK = reader.GetString("UANPDK");
    this.UADAAS = reader.GetString("UADAAS");
    this.UAFLG3 = reader.GetString("UAFLG3");
    this.UAFLG4 = reader.GetString("UAFLG4");
    this.UAFLG5 = reader.GetString("UAFLG5");
    this.UAFLG6 = reader.GetString("UAFLG6");
    this.UAFLG7 = reader.GetString("UAFLG7");
    this.UAFLG8 = reader.GetString("UAFLG8");
    this.UAFLG9 = reader.GetString("UAFLG9");
    this.UAFUT1 = reader.GetString("UAFUT1");
    this.UAFUT2 = reader.GetString("UAFUT2");
    this.UAFUT3 = reader.GetString("UAFUT3");
    this.UAFUT4 = reader.GetString("UAFUT4");
    this.UAFUT5 = reader.GetString("UAFUT5");
    this.UAFUT6 = reader.GetString("UAFUT6");
}

public
void loadUATRPT(NotNullDataReader reader){
   this.UATRPT = reader.GetString("UATRPT");
}

public override
void write(){
	try{
		string sql = "insert into trpt values('" +
		            Converter.fixString(DB) +"', '" + 
                    Converter.fixString(UATRPT) +"', '" +
                    Converter.fixString(UADESC) +"', '" +
                    Converter.fixString(UACNTC) +"', '" +
                    Converter.fixString(UAPHON) +"', '" +
                    Converter.fixString(UAFAXN) +"', '" +
                    Converter.fixString(UALOGO) +"', '" +
                    Converter.fixString(UAUPDS) +"', '" +
                    Converter.fixString(UABCUS) +"', '" +
                    Converter.fixString(UAUCPO) +"', '" +
                    Converter.fixString(UAFLG1) +"', '" +
                    Converter.fixString(UAFLG2) +"', '" +
                    Converter.fixString(UAPPRF) +"', '" +
                    Converter.fixString(UAATRD) +"', '" +
                    Converter.fixString(UATYPE) +"', '" +
                    Converter.fixString(UANPPO) +"', '" +
                    Converter.fixString(UANPEL) +"', '" +
                    Converter.fixString(UANPDK) +"', '" +
                    Converter.fixString(UADAAS) +"', '" +
                    Converter.fixString(UAFLG3) +"', '" +
                    Converter.fixString(UAFLG4) +"', '" +
                    Converter.fixString(UAFLG5) +"', '" +
                    Converter.fixString(UAFLG6) +"', '" +
                    Converter.fixString(UAFLG7) +"', '" +
                    Converter.fixString(UAFLG8) +"', '" +
                    Converter.fixString(UAFLG9) +"', '" +
                    Converter.fixString(UAFUT1) +"', '" +
                    Converter.fixString(UAFUT2) +"', '" +
                    Converter.fixString(UAFUT3) +"', '" +
                    Converter.fixString(UAFUT4) +"', '" +
                    Converter.fixString(UAFUT5) +"', '" +
                    Converter.fixString(UAFUT6) +"')";     
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
void setDB(string DB){
	this.DB = DB;
}

public
void setUATRPT(string UATRPT){
	this.UATRPT = UATRPT;
}

public
void setUADESC(string UADESC){
	this.UADESC = UADESC;
}

public
void setUACNTC(string UACNTC){
	this.UACNTC = UACNTC;
}

public
void setUAPHON(string UAPHON){
	this.UAPHON = UAPHON;
}

public
void setUAFAXN(string UAFAXN){
	this.UAFAXN = UAFAXN;
}

public
void setUALOGO(string UALOGO){
	this.UALOGO = UALOGO;
}

public
void setUAUPDS(string UAUPDS){
	this.UAUPDS = UAUPDS;
}

public
void setUABCUS(string UABCUS){
	this.UABCUS = UABCUS;
}

public
void setUAUCPO(string UAUCPO){
	this.UAUCPO = UAUCPO;
}

public
void setUAFLG1(string UAFLG1){
	this.UAFLG1 = UAFLG1;
}

public
void setUAFLG2(string UAFLG2){
	this.UAFLG2 = UAFLG2;
}

public
void setUAPPRF(string UAPPRF){
	this.UAPPRF = UAPPRF;
}

public
void setUAATRD(string UAATRD){
	this.UAATRD = UAATRD;
}

public
void setUATYPE(string UATYPE){
	this.UATYPE = UATYPE;
}

public
void setUANPPO(string UANPPO){
	this.UANPPO = UANPPO;
}

public
void setUANPEL(string UANPEL){
	this.UANPEL = UANPEL;
}

public
void setUANPDK(string UANPDK){
	this.UANPDK = UANPDK;
}

public
void setUADAAS(string UADAAS){
	this.UADAAS = UADAAS;
}

public
void setUAFLG3(string UAFLG3){
	this.UAFLG3 = UAFLG3;
}

public
void setUAFLG4(string UAFLG4){
	this.UAFLG4 = UAFLG4;
}

public
void setUAFLG5(string UAFLG5){
	this.UAFLG5 = UAFLG5;
}

public
void setUAFLG6(string UAFLG6){
	this.UAFLG6 = UAFLG6;
}

public
void setUAFLG7(string UAFLG7){
	this.UAFLG7 = UAFLG7;
}

public
void setUAFLG8(string UAFLG8){
	this.UAFLG8 = UAFLG8;
}

public
void setUAFLG9(string UAFLG9){
	this.UAFLG9 = UAFLG9;
}

public
void setUAFUT1(string UAFUT1){
	this.UAFUT1 = UAFUT1;
}

public
void setUAFUT2(string UAFUT2){
	this.UAFUT2 = UAFUT2;
}

public
void setUAFUT3(string UAFUT3){
	this.UAFUT3 = UAFUT3;
}

public
void setUAFUT4(string UAFUT4){
	this.UAFUT4 = UAFUT4;
}

public
void setUAFUT5(string UAFUT5){
	this.UAFUT5 = UAFUT5;
}

public
void setUAFUT6(string UAFUT6){
	this.UAFUT6 = UAFUT6;
}


public
string getDB(){
	return DB;
}

public
string getUATRPT(){
	return UATRPT;
}

public
string getUADESC(){
	return UADESC;
}

public
string getUACNTC(){
	return UACNTC;
}

public
string getUAPHON(){
	return UAPHON;
}

public
string getUAFAXN(){
	return UAFAXN;
}

public
string getUALOGO(){
	return UALOGO;
}

public
string getUAUPDS(){
	return UAUPDS;
}

public
string getUABCUS(){
	return UABCUS;
}

public
string getUAUCPO(){
	return UAUCPO;
}

public
string getUAFLG1(){
	return UAFLG1;
}

public
string getUAFLG2(){
	return UAFLG2;
}

public
string getUAPPRF(){
	return UAPPRF;
}

public
string getUAATRD(){
	return UAATRD;
}

public
string getUATYPE(){
	return UATYPE;
}

public
string getUANPPO(){
	return UANPPO;
}

public
string getUANPEL(){
	return UANPEL;
}

public
string getUANPDK(){
	return UANPDK;
}

public
string getUADAAS(){
	return UADAAS;
}

public
string getUAFLG3(){
	return UAFLG3;
}

public
string getUAFLG4(){
	return UAFLG4;
}

public
string getUAFLG5(){
	return UAFLG5;
}

public
string getUAFLG6(){
	return UAFLG6;
}

public
string getUAFLG7(){
	return UAFLG7;
}

public
string getUAFLG8(){
	return UAFLG8;
}

public
string getUAFLG9(){
	return UAFLG9;
}

public
string getUAFUT1(){
	return UAFUT1;
}

public
string getUAFUT2(){
	return UAFUT2;
}

public
string getUAFUT3(){
	return UAFUT3;
}

public
string getUAFUT4(){
	return UAFUT4;
}

public
string getUAFUT5(){
	return UAFUT5;
}

public
string getUAFUT6(){
	return UAFUT6;
}

}//end class

}//end namespace
