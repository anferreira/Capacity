using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;
namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{
public 
class IcstpDataBase: GenericDataBaseElement	{
private string CHPART;
private decimal CHLUC;
private decimal CHLCC;
private decimal CHLFC;
private decimal CHLDC;
private decimal CHSUC;
private decimal CHSCC;
private decimal CHSFC;
private decimal CHSDC;
private decimal CHSCR;
private decimal CHLCR;
private DateTime CHSDAT;
private decimal CHSTCS;
private decimal CHACCS;
private decimal CHAVCS;
private decimal CHSDR;
private decimal CHLDR;
private string CHA10;
private decimal CHSQTY;
private decimal CHAQTY;
private string CHTYPE;
private string CHCURR;
private decimal CHSDWC;
private decimal CHACWC;
private decimal CHSDOC;
private decimal CHACOC;
private string CHPLNT;
private string CHFUT1;
private string CHFUT2;
private string CHFUT3;
private decimal CHFUT4;
private decimal CHFUT5;
private string CHFLG1;
private string CHFLG2;
private string CHFLG3;
//---------------------------add in 5.2
private decimal CHL1C; 
private decimal CHL2C; 
private decimal CHS1C; 
private decimal CHS2C; 
private decimal CHS1R; 
private decimal CHS2R; 
private decimal CHL1R; 
private decimal CHL2R; 
private decimal CHAVUC; 
private decimal CHAVXC; 
private decimal CHAVDC; 
private decimal CHAV1C; 
private decimal CHAV2C; 
private decimal CHAVFC; 
private string CHFLG4; 
private string CHFLG5; 
private string CHFLG6; 
private string CHFLG7; 
//---------------------------
public 
IcstpDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
public
void load(NotNullDataReader reader){
    this.CHPART = reader.GetString("CHPART");
    this.CHLUC = reader.GetDecimal("CHLUC");
    this.CHLCC = reader.GetDecimal("CHLCC");
    this.CHLFC = reader.GetDecimal("CHLFC");
    this.CHLDC = reader.GetDecimal("CHLDC");
    this.CHSUC = reader.GetDecimal("CHSUC");
    this.CHSCC = reader.GetDecimal("CHSCC");
    this.CHSFC = reader.GetDecimal("CHSFC");
    this.CHSDC = reader.GetDecimal("CHSDC");
    this.CHSCR = reader.GetDecimal("CHSCR");
    this.CHLCR = reader.GetDecimal("CHLCR");
    this.CHSDAT = reader.GetDateTime("CHSDAT");
    this.CHSTCS = reader.GetDecimal("CHSTCS");
    this.CHACCS = reader.GetDecimal("CHACCS");
    this.CHAVCS = reader.GetDecimal("CHAVCS");
    this.CHSDR = reader.GetDecimal("CHSDR");
    this.CHLDR = reader.GetDecimal("CHLDR");
    
    this.CHSQTY = reader.GetDecimal("CHSQTY");
    this.CHAQTY = reader.GetDecimal("CHAQTY");
    this.CHTYPE = reader.GetString("CHTYPE");
    this.CHCURR = reader.GetString("CHCURR");
    this.CHSDWC = reader.GetDecimal("CHSDWC");
    this.CHACWC = reader.GetDecimal("CHACWC");
    this.CHPLNT = reader.GetString("CHPLNT");
    this.CHFUT1 = reader.GetString("CHFUT1");
    this.CHFUT2 = reader.GetString("CHFUT2");
    this.CHFUT3 = reader.GetString("CHFUT3");
    this.CHFUT4 = reader.GetDecimal("CHFUT4");
    this.CHFUT5 = reader.GetDecimal("CHFUT5");
    this.CHFLG1 = reader.GetString("CHFLG1");
    this.CHFLG2 = reader.GetString("CHFLG2");
    this.CHFLG3 = reader.GetString("CHFLG3");
	if (Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_2)){
		//--------add in 5.2
		this.CHL1C = reader.GetDecimal("CHL1C");
		this.CHL2C = reader.GetDecimal("CHL2C");
		this.CHS1C = reader.GetDecimal("CHS1C");
		this.CHS2C = reader.GetDecimal("CHS2C");
		this.CHS1R = reader.GetDecimal("CHS1R");
		this.CHS2R = reader.GetDecimal("CHS2R");
		this.CHL1R = reader.GetDecimal("CHL1R");
		this.CHL2R = reader.GetDecimal("CHL2R");
		this.CHAVUC = reader.GetDecimal("CHAVUC");
		this.CHAVXC = reader.GetDecimal("CHAVXC");
		this.CHAVDC = reader.GetDecimal("CHAVDC");
		this.CHAV1C = reader.GetDecimal("CHAV1C");
		this.CHAV2C = reader.GetDecimal("CHAV2C");
		this.CHAVFC = reader.GetDecimal("CHAVFC");
		this.CHFLG4 = reader.GetString("CHFLG4");
		this.CHFLG5 = reader.GetString("CHFLG5");
		this.CHFLG6 = reader.GetString("CHFLG6");
		this.CHFLG7 = reader.GetString("CHFLG7");
		//--------remove in 5.2
		this.CHA10 = "";
		this.CHSDOC = 0;
		this.CHACOC = 0;
	}else{
		this.CHL1C = 0;
		this.CHL2C = 0;
		this.CHS1C = 0;
		this.CHS2C = 0;
		this.CHS1R = 0;
		this.CHS2R = 0;
		this.CHL1R = 0;
		this.CHL2R = 0;
		this.CHAVUC = 0;
		this.CHAVXC = 0;
		this.CHAVDC = 0;
		this.CHAV1C = 0;
		this.CHAV2C = 0;
		this.CHAVFC = 0;
		this.CHFLG4 = "";
		this.CHFLG5 = "";
		this.CHFLG6 = "";
		this.CHFLG7 = "";
		//--------remove in 5.2
		this.CHA10 = reader.GetString("CHA10");	
		this.CHSDOC = reader.GetDecimal("CHSDOC");
		this.CHACOC = reader.GetDecimal("CHACOC");
	
	}
}
public override
void write(){
    try{
		string sql = "";
		if (Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_2)){
			sql = "insert into icstp(" +
				"CHPART, " +
				"CHLUC, " +
				"CHLCC, " +
				"CHLFC, " +
				"CHLDC, " +
				"CHSUC, " +
				"CHSCC, " +
				"CHSFC, " +
				"CHSDC, " +
				"CHSCR, " +
				"CHLCR, " +
				"CHSDAT, " +
				"CHSTCS, " +
				"CHACCS, " +
				"CHAVCS, " +
				"CHSDR, " +
				"CHLDR, " +
				"CHA10, " +
				"CHSQTY, " +
				"CHAQTY, " +
				"CHTYPE, " +
				"CHCURR, " +
				"CHSDWC, " +
				"CHACWC, " +
				"CHSDOC, " +
				"CHACOC, " +
				"CHPLNT, " +
				"CHFUT1, " +
				"CHFUT2, " +
				"CHFUT3, " +
				"CHFUT4, " +
				"CHFUT5, " +
				"CHFLG1, " +
				"CHFLG2, " +
				"CHFLG3, " +
				"CHL1C, " +
				"CHL2C, " +
				"CHS1C, " +
				"CHS2C, " +
				"CHS1R, " +
				"CHS2R, " +
				"CHL1R, " +
				"CHL2R, " +
				"CHAVUC, " +
				"CHAVXC, " +
				"CHAVDC, " +
				"CHAV1C, " +
				"CHAV2C, " +
				"CHAVFC, " +
				"CHFLG4, " +
				"CHFLG5, " +
				"CHFLG6, " +
				"CHFLG7) " +
			"values('" +
				Converter.fixString(CHPART) + "', " + 
				NumberUtil.toString(CHLUC) + ", " +
				NumberUtil.toString(CHLCC) + ", " +
				NumberUtil.toString(CHLFC) + ", " +
				NumberUtil.toString(CHLDC) + ", " +
				NumberUtil.toString(CHSUC) + ", " +
				NumberUtil.toString(CHSCC) + ", " +
				NumberUtil.toString(CHSFC) + ", " +
				NumberUtil.toString(CHSDC) + ", " +
				NumberUtil.toString(CHSCR) + ", " +
				NumberUtil.toString(CHLCR) + ", '" +
				DateUtil.getDateRepresentation(CHSDAT) + "', " +
				NumberUtil.toString(CHSTCS) + ", " +
				NumberUtil.toString(CHACCS) + ", " +
				NumberUtil.toString(CHAVCS) + ", " +
				NumberUtil.toString(CHSDR) + ", " +
				NumberUtil.toString(CHLDR) + ", '" +
				Converter.fixString(CHA10) + "', " + 
				NumberUtil.toString(CHSQTY) + ", " +
				NumberUtil.toString(CHAQTY) + ", '" +
				Converter.fixString(CHTYPE) + "', '" + 
				Converter.fixString(CHCURR) + "', " + 
				NumberUtil.toString(CHSDWC) + ", " +
				NumberUtil.toString(CHACWC) + ", " +
				NumberUtil.toString(CHSDOC) + ", " +
				NumberUtil.toString(CHACOC) + ", '" +
				Converter.fixString(CHPLNT) + "', '" + 
				Converter.fixString(CHFUT1) + "', '" + 
				Converter.fixString(CHFUT2) + "', '" + 
				Converter.fixString(CHFUT3) + "', " + 
				NumberUtil.toString(CHFUT4) + ", " +
				NumberUtil.toString(CHFUT5) + ", '" +
				Converter.fixString(CHFLG1) + "', '" + 
				Converter.fixString(CHFLG2) + "', '" + 
				Converter.fixString(CHFLG3) + "', " + 
				NumberUtil.toString(CHL1C) + ", " + 
				NumberUtil.toString(CHL2C) + ", " + 
				NumberUtil.toString(CHS1C) + ", " + 
				NumberUtil.toString(CHS2C) + ", " + 
				NumberUtil.toString(CHS1R) + ", " + 
				NumberUtil.toString(CHS2R) + ", " + 
				NumberUtil.toString(CHL1R) + ", " + 
				NumberUtil.toString(CHL2R) + ", " + 
				NumberUtil.toString(CHAVUC) + ", " + 
				NumberUtil.toString(CHAVXC) + ", " + 
				NumberUtil.toString(CHAVDC) + ", " + 
				NumberUtil.toString(CHAV1C) + ", " + 
				NumberUtil.toString(CHAV2C) + ", " + 
				NumberUtil.toString(CHAVFC) + ", '" + 
				Converter.fixString(CHFLG4) + "', '" + 
				Converter.fixString(CHFLG5) + "', '" + 
				Converter.fixString(CHFLG6) + "', '" + 
				Converter.fixString(CHFLG7) + "')";
		}else{
			sql = "insert into icstp values('" +
				Converter.fixString(CHPART) +"', " +
				NumberUtil.toString(CHLUC) +", " +
				NumberUtil.toString(CHLCC) +", " +
				NumberUtil.toString(CHLFC) +", " +
				NumberUtil.toString(CHLDC) +", " +
				NumberUtil.toString(CHSUC) +", " +
				NumberUtil.toString(CHSCC) +", " +
				NumberUtil.toString(CHSFC) +", " +
				NumberUtil.toString(CHSDC) +", " +
				NumberUtil.toString(CHSCR) +", " +
				NumberUtil.toString(CHLCR) +", '" +
				DateUtil.getCompleteDateRepresentation(CHSDAT) +"', " +
				NumberUtil.toString(CHSTCS) +", " +
				NumberUtil.toString(CHACCS) +", " +
				NumberUtil.toString(CHAVCS) +", " +
				NumberUtil.toString(CHSDR) +", " +
				NumberUtil.toString(CHLDR) +", '" +
				Converter.fixString(CHA10) +"', " +
				NumberUtil.toString(CHSQTY) +", " +
				NumberUtil.toString(CHAQTY) +", '" +
				Converter.fixString(CHTYPE) +"', '" +
				Converter.fixString(CHCURR) +"', " +
				NumberUtil.toString(CHSDWC) +", " +
				NumberUtil.toString(CHACWC) +", " +
				NumberUtil.toString(CHSDOC) +", " +
				NumberUtil.toString(CHACOC) +", '" +
				Converter.fixString(CHPLNT) +"', '" +
				Converter.fixString(CHFUT1) +"', '" +
				Converter.fixString(CHFUT2) +"', '" +
				Converter.fixString(CHFUT3) +"', " +
				NumberUtil.toString(CHFUT4) +", " +
				NumberUtil.toString(CHFUT5) +", '" +
				Converter.fixString(CHFLG1) +"', '" +
				Converter.fixString(CHFLG2) +"', '" +
				Converter.fixString(CHFLG3) +"')";
		}
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
void setCHPART(string CHPART){
    this.CHPART = CHPART;
}
public 
void setCHLUC(decimal CHLUC){
    this.CHLUC = CHLUC;
}
public 
void setCHLCC(decimal CHLCC){
    this.CHLCC = CHLCC;
}
public 
void setCHLFC(decimal CHLFC){
    this.CHLFC = CHLFC;
}
public 
void setCHLDC(decimal CHLDC){
    this.CHLDC = CHLDC;
}
public 
void setCHSUC(decimal CHSUC){
    this.CHSUC = CHSUC;
}
public 
void setCHSCC(decimal CHSCC){
    this.CHSCC = CHSCC;
}
public 
void setCHSFC(decimal CHSFC){
    this.CHSFC = CHSFC;
}
public 
void setCHSDC(decimal CHSDC){
    this.CHSDC = CHSDC;
}
public 
void setCHSCR(decimal CHSCR){
    this.CHSCR = CHSCR;
}
public 
void setCHLCR(decimal CHLCR){
    this.CHLCR = CHLCR;
}
public 
void setCHSDAT(DateTime CHSDAT){
    this.CHSDAT = CHSDAT;
}
public 
void setCHSTCS(decimal CHSTCS){
    this.CHSTCS = CHSTCS;
}
public 
void setCHACCS(decimal CHACCS){
    this.CHACCS = CHACCS;
}
public 
void setCHAVCS(decimal CHAVCS){
    this.CHAVCS = CHAVCS;
}
public 
void setCHSDR(decimal CHSDR){
    this.CHSDR = CHSDR;
}
public 
void setCHLDR(decimal CHLDR){
    this.CHLDR = CHLDR;
}
public 
void setCHA10(string CHA10){
    this.CHA10 = CHA10;
}
public 
void setCHSQTY(decimal CHSQTY){
    this.CHSQTY = CHSQTY;
}
public 
void setCHAQTY(decimal CHAQTY){
    this.CHAQTY = CHAQTY;
}
public 
void setCHTYPE(string CHTYPE){
    this.CHTYPE = CHTYPE;
}
public 
void setCHCURR(string CHCURR){
    this.CHCURR = CHCURR;
}
public 
void setCHSDWC(decimal CHSDWC){
    this.CHSDWC = CHSDWC;
}
public 
void setCHACWC(decimal CHACWC){
    this.CHACWC = CHACWC;
}
public 
void setCHSDOC(decimal CHSDOC){
    this.CHSDOC = CHSDOC;
}
public 
void setCHACOC(decimal CHACOC){
    this.CHACOC = CHACOC;
}
public 
void setCHPLNT(string CHPLNT){
    this.CHPLNT = CHPLNT;
}
public 
void setCHFUT1(string CHFUT1){
    this.CHFUT1 = CHFUT1;
}
public 
void setCHFUT2(string CHFUT2){
    this.CHFUT2 = CHFUT2;
}
public 
void setCHFUT3(string CHFUT3){
    this.CHFUT3 = CHFUT3;
}
public 
void setCHFUT4(decimal CHFUT4){
    this.CHFUT4 = CHFUT4;
}
public 
void setCHFUT5(decimal CHFUT5){
    this.CHFUT5 = CHFUT5;
}
public 
void setCHFLG1(string CHFLG1){
    this.CHFLG1 = CHFLG1;
}
public 
void setCHFLG2(string CHFLG2){
    this.CHFLG2 = CHFLG2;
}
public 
void setCHFLG3(string CHFLG3){
    this.CHFLG3 = CHFLG3;
}
//------------------add in 5.2
public
void setCHL1C(decimal CHL1C){
	this.CHL1C = CHL1C;
} 
public
decimal getCHL1C(){
	return this.CHL1C;
}
public
void setCHL2C(decimal CHL2C){
	this.CHL2C = CHL2C;
} 
public
decimal getCHL2C(){
	return this.CHL2C;
}
public
void setCHS1C(decimal CHS1C){
	this.CHS1C = CHS1C;
} 
public
decimal getCHS1C(){
	return this.CHS1C;
}
public
void setCHS2C(decimal CHS2C){
	this.CHS2C = CHS2C;
} 
public
decimal getCHS2C(){
	return this.CHS2C;
}
public
void setCHS1R(decimal CHS1R){
	this.CHS1R = CHS1R;
} 
public
decimal getCHS1R(){
	return this.CHS1R;
}
public
void setCHS2R(decimal CHS2R){
	this.CHS2R = CHS2R;
} 
public
decimal getCHS2R(){
	return this.CHS2R;
}
public
void setCHL1R(decimal CHL1R){
	this.CHL1R = CHL1R;
} 
public
decimal getCHL1R(){
	return this.CHL1R;
}
public
void setCHL2R(decimal CHL2R){
	this.CHL2R = CHL2R;
} 
public
decimal getCHL2R(){
	return this.CHL2R;
}
public
void setCHAVUC(decimal CHAVUC){
	this.CHAVUC = CHAVUC;
} 
public
decimal getCHAVUC(){
	return this.CHAVUC;
}
public
void setCHAVXC(decimal CHAVXC){
	this.CHAVXC = CHAVXC;
} 
public
decimal getCHAVXC(){
	return this.CHAVXC;
}
public
void setCHAVDC(decimal CHAVDC){
	this.CHAVDC = CHAVDC;
} 
public
decimal getCHAVDC(){
	return this.CHAVDC;
}
public
void setCHAV1C(decimal CHAV1C){
	this.CHAV1C = CHAV1C;
} 
public
decimal getCHAV1C(){
	return this.CHAV1C;
}
public
void setCHAV2C(decimal CHAV2C){
	this.CHAV2C = CHAV2C;
} 
public
decimal getCHAV2C(){
	return this.CHAV2C;
}

public
void setCHAVFC(decimal CHAVFC){
	this.CHAVFC = CHAVFC;
} 
public
decimal getCHAVFC(){
	return this.CHAVFC;
}
public 
void setCHFLG4(string CHFLG4){
	this.CHFLG4 = CHFLG4;
}
public
string getCHFLG4(){
	return this.CHFLG4;
} 
public 
void setCHFLG5(string CHFLG5){
	this.CHFLG5 = CHFLG5;
}
public
string getCHFLG5(){
	return this.CHFLG5;
} 
public 
void setCHFLG6(string CHFLG6){
	this.CHFLG6 = CHFLG6;
}
public
string getCHFLG6(){
	return this.CHFLG6;
} 
public 
void setCHFLG7(string CHFLG7){
	this.CHFLG7 = CHFLG7;
}
public
string getCHFLG7(){
	return this.CHFLG7;
} 
//----------------------------
//Getters
public 
string getCHPART(){
    return CHPART;
}
public 
decimal getCHLUC(){
    return CHLUC;
}
public 
decimal getCHLCC(){
    return CHLCC;
}
public 
decimal getCHLFC(){
    return CHLFC;
}
public 
decimal getCHLDC(){
    return CHLDC;
}
public 
decimal getCHSUC(){
    return CHSUC;
}
public 
decimal getCHSCC(){
    return CHSCC;
}
public 
decimal getCHSFC(){
    return CHSFC;
}
public 
decimal getCHSDC(){
    return CHSDC;
}
public 
decimal getCHSCR(){
    return CHSCR;
}
public 
decimal getCHLCR(){
    return CHLCR;
}
public 
DateTime getCHSDAT(){
    return CHSDAT;
}
public 
decimal getCHSTCS(){
    return CHSTCS;
}
public 
decimal getCHACCS(){
    return CHACCS;
}
public 
decimal getCHAVCS(){
    return CHAVCS;
}
public 
decimal getCHSDR(){
    return CHSDR;
}
public 
decimal getCHLDR(){
    return CHLDR;
}
public 
string getCHA10(){
    return CHA10;
}
public 
decimal getCHSQTY(){
    return CHSQTY;
}
public 
decimal getCHAQTY(){
    return CHAQTY;
}
public 
string getCHTYPE(){
    return CHTYPE;
}
public 
string getCHCURR(){
    return CHCURR;
}
public 
decimal getCHSDWC(){
    return CHSDWC;
}
public 
decimal getCHACWC(){
    return CHACWC;
}
public 
decimal getCHSDOC(){
    return CHSDOC;
}
public 
decimal getCHACOC(){
    return CHACOC;
}
public 
string getCHPLNT(){
    return CHPLNT;
}
public 
string getCHFUT1(){
    return CHFUT1;
}
public 
string getCHFUT2(){
    return CHFUT2;
}
public 
string getCHFUT3(){
    return CHFUT3;
}
public 
decimal getCHFUT4(){
    return CHFUT4;
}
public 
decimal getCHFUT5(){
    return CHFUT5;
}
public 
string getCHFLG1(){
    return CHFLG1;
}
public 
string getCHFLG2(){
    return CHFLG2;
}
public 
string getCHFLG3(){
    return CHFLG3;
}
}//end class
}//end namespace
