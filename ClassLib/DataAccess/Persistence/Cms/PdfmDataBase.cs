using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class PdfmDataBase : GenericDataBaseElement{

private string PSFMPT;
private string PSDES1;
private string PSDES2;
private string PSDES3;
private decimal PSCMP;
private decimal PSRUNQ;
private string PSUNIT;
private string PSCTBY;
private DateTime PSCDAT;
private DateTime PSCTIM;
private string PSUPBY;
private DateTime PSUDAT;
private DateTime PSUTIM;
private string PSPLAN;

public 
PdfmDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
		
public 
void load(NotNullDataReader reader){
    this.PSFMPT = reader.GetString("PSFMPT");
    this.PSDES1 = reader.GetString("PSDES1");
    this.PSDES2 = reader.GetString("PSDES2");
    this.PSDES3 = reader.GetString("PSDES3");
	
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.PSCMP = reader.GetDecimal("PS#CMP");
	else
		this.PSCMP = reader.GetDecimal("PSCMP");
    
	this.PSRUNQ = reader.GetDecimal("PSRUNQ");
    this.PSUNIT = reader.GetString("PSUNIT");
    this.PSCTBY = reader.GetString("PSCTBY");
    
    if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
        DateTime dateAux = reader.GetDateTime("PSCDAT");
        string stime = reader.GetValue("PSCTIM").ToString();
        this.PSCDAT = DateUtil.getDateTimeFromAS4002Points(dateAux, stime);
        this.PSCTIM = PSCDAT;

        dateAux = reader.GetDateTime("PSUDAT");
        stime = reader.GetValue("PSUTIM").ToString();
        this.PSUDAT = DateUtil.getDateTimeFromAS4002Points(dateAux, stime);
        this.PSUTIM = PSUDAT;

        
    }else{
        this.PSCDAT = reader.GetDateTime("PSCDAT");
        this.PSCTIM = reader.GetDateTime("PSCTIM");
        this.PSUDAT = reader.GetDateTime("PSUDAT");
        this.PSUTIM = reader.GetDateTime("PSUTIM");

    }
    this.PSUPBY = reader.GetString("PSUPBY");  
    this.PSPLAN = reader.GetString("PSPLAN");
}

public override	
void write(){
	try{
		string sql = "insert into pdfm values('" +
			Converter.fixString(PSFMPT) + "', '" +
			Converter.fixString(PSDES1) + "', '" +
			Converter.fixString(PSDES2) + "', '" +
			Converter.fixString(PSDES3) + "', " +
			NumberUtil.toString(PSCMP) + ", " +
			NumberUtil.toString(PSRUNQ) + ", '" +
			Converter.fixString(PSUNIT) + "', '" +
			Converter.fixString(PSCTBY) + "', '" +
			DateUtil.getCompleteDateRepresentation(PSCDAT) + "', '" +
			DateUtil.getCompleteDateRepresentation(PSCTIM) + "', '" +
			Converter.fixString(PSUPBY) + "', '" +
			DateUtil.getCompleteDateRepresentation(PSUDAT) + "', '" +
			DateUtil.getCompleteDateRepresentation(PSUTIM) + "', '" +
			Converter.fixString(PSPLAN) + "')";

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
void setPSFMPT(string PSFMPT){
	this.PSFMPT = PSFMPT;
}

public
void setPSDES1(string PSDES1){
	this.PSDES1 = PSDES1;
}

public
void setPSDES2(string PSDES2){
	this.PSDES2 = PSDES2;
}

public
void setPSDES3(string PSDES3){
	this.PSDES3 = PSDES3;
}

public
void setPSCMP(decimal PSCMP){
	this.PSCMP = PSCMP;
}

public
void setPSRUNQ(decimal PSRUNQ){
	this.PSRUNQ = PSRUNQ;
}

public
void setPSUNIT(string PSUNIT){
	this.PSUNIT = PSUNIT;
}

public
void setPSCTBY(string PSCTBY){
	this.PSCTBY = PSCTBY;
}

public
void setPSCDAT(DateTime PSCDAT){
	this.PSCDAT = PSCDAT;
}

public
void setPSCTIM(DateTime PSCTIM){
	this.PSCTIM = PSCTIM;
}

public
void setPSUPBY(string PSUPBY){
	this.PSUPBY = PSUPBY;
}

public
void setPSUDAT(DateTime PSUDAT){
	this.PSUDAT = PSUDAT;
}

public
void setPSUTIM(DateTime PSUTIM){
	this.PSUTIM = PSUTIM;
}

public
void setPSPLAN(string PSPLAN){
	this.PSPLAN = PSPLAN;
}


public
string getPSFMPT(){
	return PSFMPT;
}

public
string getPSDES1(){
	return PSDES1;
}

public
string getPSDES2(){
	return PSDES2;
}

public
string getPSDES3(){
	return PSDES3;
}

public
decimal getPSCMP(){
	return PSCMP;
}

public
decimal getPSRUNQ(){
	return PSRUNQ;
}

public
string getPSUNIT(){
	return PSUNIT;
}

public
string getPSCTBY(){
	return PSCTBY;
}

public
DateTime getPSCDAT(){
	return PSCDAT;
}

public
DateTime getPSCTIM(){
	return PSCTIM;
}

public
string getPSUPBY(){
	return PSUPBY;
}

public
DateTime getPSUDAT(){
	return PSUDAT;
}

public
DateTime getPSUTIM(){
	return PSUTIM;
}

public
string getPSPLAN(){
	return PSPLAN;
}

}

}