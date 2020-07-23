using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class TrplDataBase : GenericDataBaseElement{

private string DB;
private string SYTRDP;
private string SYSTXL;
private string SYNAME;
private string SYQUAL;
private string SYCUST;
private string SYSHPT;
private string SYPPRF;
private string SYFLG1;
private string SYFLG2;
private string SYFLG3;
private string SYFLG4;
private string SYFLG5;
private string SYFUT1;
private string SYFUT2;
private string SYFUT3;
private string SYFUT4;
private string SYFUT5;
private string SYFUT6;

public 
TrplDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){	
}


public
void load(NotNullDataReader reader){
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMSTEMP_DATABASE)
		this.DB = reader.GetString("DB");

    this.SYTRDP = reader.GetString("SYTRDP");
    this.SYSTXL = reader.GetString("SYSTXL");
    this.SYNAME = reader.GetString("SYNAME");
    this.SYQUAL = reader.GetString("SYQUAL");
    this.SYCUST = reader.GetString("SYCUST");
    this.SYSHPT = reader.GetString("SYSHPT");
    this.SYPPRF = reader.GetString("SYPPRF");
    this.SYFLG1 = reader.GetString("SYFLG1");
    this.SYFLG2 = reader.GetString("SYFLG2");
    this.SYFLG3 = reader.GetString("SYFLG3");
    this.SYFLG4 = reader.GetString("SYFLG4");
    this.SYFLG5 = reader.GetString("SYFLG5");
    this.SYFUT1 = reader.GetString("SYFUT1");
    this.SYFUT2 = reader.GetString("SYFUT2");
    this.SYFUT3 = reader.GetString("SYFUT3");
    this.SYFUT4 = reader.GetString("SYFUT4");
    this.SYFUT5 = reader.GetString("SYFUT5");
    this.SYFUT6 = reader.GetString("SYFUT6");

}

public
void loadBySYTRDP(NotNullDataReader reader){
	this.SYTRDP = reader.GetString("SYTRDP");
	this.SYSTXL = reader.GetString("SYSTXL");
}    

public override
void write(){
	try{
		string sql = "insert into trpl values('" +
		            Converter.fixString(DB) +"', '" +
                    Converter.fixString(SYTRDP) +"', '" +
                    Converter.fixString(SYSTXL) +"', '" +
                    Converter.fixString(SYNAME) +"', '" +
                    Converter.fixString(SYQUAL) +"', '" +
                    Converter.fixString(SYCUST) +"', '" +
                    Converter.fixString(SYSHPT) +"', '" +
                    Converter.fixString(SYPPRF) +"', '" +
                    Converter.fixString(SYFLG1) +"', '" +
                    Converter.fixString(SYFLG2) +"', '" +
                    Converter.fixString(SYFLG3) +"', '" +
                    Converter.fixString(SYFLG4) +"', '" +
                    Converter.fixString(SYFLG5) +"', '" +
                    Converter.fixString(SYFUT1) +"', '" +
                    Converter.fixString(SYFUT2) +"', '" +
                    Converter.fixString(SYFUT3) +"', '" +
                    Converter.fixString(SYFUT4) +"', '" +
                    Converter.fixString(SYFUT5) +"', '" +
                    Converter.fixString(SYFUT6) +"')";
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
void setSYTRDP(string SYTRDP){
	this.SYTRDP = SYTRDP;
}

public
void setSYSTXL(string SYSTXL){
	this.SYSTXL = SYSTXL;
}

public
void setSYNAME(string SYNAME){
	this.SYNAME = SYNAME;
}

public
void setSYQUAL(string SYQUAL){
	this.SYQUAL = SYQUAL;
}

public
void setSYCUST(string SYCUST){
	this.SYCUST = SYCUST;
}

public
void setSYSHPT(string SYSHPT){
	this.SYSHPT = SYSHPT;
}

public
void setSYPPRF(string SYPPRF){
	this.SYPPRF = SYPPRF;
}

public
void setSYFLG1(string SYFLG1){
	this.SYFLG1 = SYFLG1;
}

public
void setSYFLG2(string SYFLG2){
	this.SYFLG2 = SYFLG2;
}

public
void setSYFLG3(string SYFLG3){
	this.SYFLG3 = SYFLG3;
}

public
void setSYFLG4(string SYFLG4){
	this.SYFLG4 = SYFLG4;
}

public
void setSYFLG5(string SYFLG5){
	this.SYFLG5 = SYFLG5;
}

public
void setSYFUT1(string SYFUT1){
	this.SYFUT1 = SYFUT1;
}

public
void setSYFUT2(string SYFUT2){
	this.SYFUT2 = SYFUT2;
}

public
void setSYFUT3(string SYFUT3){
	this.SYFUT3 = SYFUT3;
}

public
void setSYFUT4(string SYFUT4){
	this.SYFUT4 = SYFUT4;
}

public
void setSYFUT5(string SYFUT5){
	this.SYFUT5 = SYFUT5;
}

public
void setSYFUT6(string SYFUT6){
	this.SYFUT6 = SYFUT6;
}


public
string getDB(){
	return DB;
}

public
string getSYTRDP(){
	return SYTRDP;
}

public
string getSYSTXL(){
	return SYSTXL;
}

public
string getSYNAME(){
	return SYNAME;
}

public
string getSYQUAL(){
	return SYQUAL;
}

public
string getSYCUST(){
	return SYCUST;
}

public
string getSYSHPT(){
	return SYSHPT;
}

public
string getSYPPRF(){
	return SYPPRF;
}

public
string getSYFLG1(){
	return SYFLG1;
}

public
string getSYFLG2(){
	return SYFLG2;
}

public
string getSYFLG3(){
	return SYFLG3;
}

public
string getSYFLG4(){
	return SYFLG4;
}

public
string getSYFLG5(){
	return SYFLG5;
}

public
string getSYFUT1(){
	return SYFUT1;
}

public
string getSYFUT2(){
	return SYFUT2;
}

public
string getSYFUT3(){
	return SYFUT3;
}

public
string getSYFUT4(){
	return SYFUT4;
}

public
string getSYFUT5(){
	return SYFUT5;
}

public
string getSYFUT6(){
	return SYFUT6;
}

}//end class

}//end namespace
