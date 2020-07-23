using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms.PackSlip{
	
public class BolhDataBase : GenericDataBaseElement {
private string DB;
private decimal FEBOL;
private string FEBTYP;
private DateTime FECDAT;
private string FEPIND;
private string FESIND;
private string FEBCS;
private string FESCS;
private string FESVND;
private string FERVND;
private string FEBNME;
private string FEBPTC;
private string FEATTN;
private string FESNME;
private string FESAD1;
private string FESAD2;
private string FESAD3;
private string FESAD4;
private string FESAD5;
private string FESAD6;
private string FESAD7;
private string FESAD8;
private string FESAD9;
private string FESAD10;
private string FESPTC;
private DateTime FESDAT;
private string FESVIA;
private string FETKID;
private decimal FENCTN;
private decimal FENETW;
private decimal FEGROW;
private decimal FETARW;
private string FEWTUN;
private string FEDOCD;
private string FEFTCD;
private decimal FEORD;
private string FESTKL;
private decimal FEFTAM;
private string FEFOB;
private string FECARC;
private string FESERC;
private decimal FESTME;
private string FEJITF;
private string FESID_NUM;
private string FETRPT;
private string FEBID;
private string FESID;
private string FESFID;
private string FEPLNT;
private string FEITMC;
private string FESUPP;
private string FEULTD;
private DateTime FEEDAT;
private decimal FEETIM;
private DateTime FEADAT;
private decimal FEATIM;
private string FETRNM;
private string FERTEG;
private string FEPLPT;
private string FEPLOC;
private string FEEQPD;
private string FEEQPI;
private string FEEQID;
private decimal FEMBOL;
private string FEPSLP;
private string FEFRTB;
private string FEAIRB;
private string FETSPR;
private string FEETRR;
private string FEEXTR;
private string FEAETC;
private string FEMTHP;
private string FETRNT;
private string FETRLQ;
private string FECCT;
private string FECCDE;
private string FESASN;
private string FESNTF;
private string FESTS;
private string FEXMOD;
private string FEATYP;
private string FEFLD1;
private string FEFLD2;
private string FEFLD3;
private string FEFLD4;
private string FEFLD5;
private string FEFLD6;
private string FEMANW;
private string FES204;
private string FEBTRP;
private string FEBSTS;
private string FEBACK;
private string FEBSET;
private string FEBMOD;
private decimal FESKDQ;
private string FESKDT;
private decimal FELOSQ;
private string FELOST;
private string FECRCM;
private string FEUSE;
private string FESLCS;
private string FECRTY;
private string FECRDT;
private string FECRD;
private string FEEXPR;
private string FEHODR;
private decimal FECRNM;
private string FESHBF;
private string FECLEN;

private string FEFUTK;//this is new field needed but there are lot of new fields not added yet
private string FEFUTP;
private string FERTS;

private string FESCTY;
private string FESPOV;
private string FETAMT;

private DateTime FEPDAT;
private decimal FEPTIM;


public BolhDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
	
}

private
string getTable(){
    string table = getTablePrefix() + "bolh";    
    return table;
}

public
bool read(){
    string sql = "select * from "  + getTable() + " where " + getWhereCondition();
    return read(sql);
}

public
bool exists(){
    string sql = "select * from " + getTable() + " where " + getWhereCondition();
    return exists(sql);
}

public override
void load(NotNullDataReader reader){
	
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMSTEMP_DATABASE){
		this.DB = reader.GetString("DB");
	}	
	if(dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.FEBOL = reader.GetDecimal("FEBOL#");
	else
		this.FEBOL = reader.GetDecimal("FEBOL");
	this.FEBTYP = reader.GetString("FEBTYP");
	this.FECDAT = reader.GetDateTime("FECDAT");
	this.FEPIND = reader.GetString("FEPIND");
	this.FESIND = reader.GetString("FESIND");
	if(dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
	{
		this.FEBCS = reader.GetString("FEBCS#");
		this.FESCS = reader.GetString("FESCS#");
	}
	else
	{
		this.FEBCS = reader.GetString("FEBCS");
		this.FESCS = reader.GetString("FESCS");
	}
	this.FESVND = reader.GetString("FESVND");
	this.FERVND = reader.GetString("FERVND");
	this.FEBNME = reader.GetString("FEBNME");
	this.FEBPTC = reader.GetString("FEBPTC");
	this.FEATTN = reader.GetString("FEATTN");
	this.FESNME = reader.GetString("FESNME");
	this.FESAD1 = reader.GetString("FESAD1");
	this.FESAD2 = reader.GetString("FESAD2");
	this.FESAD3 = reader.GetString("FESAD3");
	this.FESAD4 = reader.GetString("FESAD4");
	this.FESAD5 = reader.GetString("FESAD5");
	this.FESAD6 = reader.GetString("FESAD6");
	this.FESAD7 = reader.GetString("FESAD7");
	this.FESAD8 = reader.GetString("FESAD8");
	this.FESAD9 = reader.GetString("FESAD9");
	this.FESAD10 = reader.GetString("FESAD10");
	this.FESPTC = reader.GetString("FESPTC");
	this.FESDAT = reader.GetDateTime("FESDAT");
	this.FESVIA = reader.GetString("FESVIA");
	this.FETKID = reader.GetString("FETKID");
	this.FENCTN = reader.GetDecimal("FENCTN");
	this.FENETW = reader.GetDecimal("FENETW");
	this.FEGROW = reader.GetDecimal("FEGROW");
	this.FETARW = reader.GetDecimal("FETARW");
	this.FEWTUN = reader.GetString("FEWTUN");
	this.FEDOCD = reader.GetString("FEDOCD");
	this.FEFTCD = reader.GetString("FEFTCD");
	if(dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.FEORD = reader.GetDecimal("FEORD#");
	else
		this.FEORD = reader.GetDecimal("FEORD");
	this.FESTKL = reader.GetString("FESTKL");
	this.FEFTAM = reader.GetDecimal("FEFTAM");
	this.FEFOB = reader.GetString("FEFOB");
	this.FECARC = reader.GetString("FECARC");
	this.FESERC = reader.GetString("FESERC");
	this.FESTME = reader.GetDecimal("FESTME");
	this.FEJITF = reader.GetString("FEJITF");
	if(dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.FESID_NUM = reader.GetString("FESID#");
	else
		this.FESID_NUM = reader.GetString("FESIDNUM");
	this.FETRPT = reader.GetString("FETRPT");
	this.FEBID = reader.GetString("FEBID");
	this.FESID = reader.GetString("FESID");
	this.FESFID = reader.GetString("FESFID");
	this.FEPLNT = reader.GetString("FEPLNT");
	this.FEITMC = reader.GetString("FEITMC");
	this.FESUPP = reader.GetString("FESUPP");
	this.FEULTD = reader.GetString("FEULTD");
	this.FEEDAT = reader.GetDateTime("FEEDAT");
	this.FEETIM = reader.GetDecimal("FEETIM");
	this.FEADAT = reader.GetDateTime("FEADAT");
	this.FEATIM = reader.GetDecimal("FEATIM");
	this.FETRNM = reader.GetString("FETRNM");
	this.FERTEG = reader.GetString("FERTEG");
	this.FEPLPT = reader.GetString("FEPLPT");
	this.FEPLOC = reader.GetString("FEPLOC");
	this.FEEQPD = reader.GetString("FEEQPD");
	this.FEEQPI = reader.GetString("FEEQPI");
	this.FEEQID = reader.GetString("FEEQID");
	this.FEMBOL = reader.GetDecimal("FEMBOL");
	this.FEPSLP = reader.GetString("FEPSLP");
	this.FEFRTB = reader.GetString("FEFRTB");
	this.FEAIRB = reader.GetString("FEAIRB");
	this.FETSPR = reader.GetString("FETSPR");
	this.FEETRR = reader.GetString("FEETRR");
	this.FEEXTR = reader.GetString("FEEXTR");
	this.FEAETC = reader.GetString("FEAETC");
	this.FEMTHP = reader.GetString("FEMTHP");
	this.FETRNT = reader.GetString("FETRNT");
	this.FETRLQ = reader.GetString("FETRLQ");
	this.FECCT = reader.GetString("FECCT");
	this.FECCDE = reader.GetString("FECCDE");
	this.FESASN = reader.GetString("FESASN");
	this.FESNTF = reader.GetString("FESNTF");
	this.FESTS = reader.GetString("FESTS");
	this.FEXMOD = reader.GetString("FEXMOD");
	this.FEATYP = reader.GetString("FEATYP");
	this.FEFLD1 = reader.GetString("FEFLD1");
	this.FEFLD2 = reader.GetString("FEFLD2");
	this.FEFLD3 = reader.GetString("FEFLD3");
	this.FEFLD4 = reader.GetString("FEFLD4");
	this.FEFLD5 = reader.GetString("FEFLD5");
	this.FEFLD6 = reader.GetString("FEFLD6");
	this.FEMANW = reader.GetString("FEMANW");
	this.FES204 = reader.GetString("FES204");
	this.FEBTRP = reader.GetString("FEBTRP");
	this.FEBSTS = reader.GetString("FEBSTS");
	this.FEBACK = reader.GetString("FEBACK");
	this.FEBSET = reader.GetString("FEBSET");
	this.FEBMOD = reader.GetString("FEBMOD");
	this.FESKDQ = reader.GetDecimal("FESKDQ");
	this.FESKDT = reader.GetString("FESKDT");
	this.FELOSQ = reader.GetDecimal("FELOSQ");
	this.FELOST = reader.GetString("FELOST");
	this.FECRCM = reader.GetString("FECRCM");
	this.FEUSE = reader.GetString("FEUSE");
	this.FESLCS = reader.GetString("FESLCS");
	this.FECRTY = reader.GetString("FECRTY");
	this.FECRDT = reader.GetString("FECRDT");
	if(dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.FECRD = reader.GetString("FECRD#");
	else
		this.FECRD = reader.GetString("FECRD");
	this.FEEXPR = reader.GetString("FEEXPR");
	this.FEHODR = reader.GetString("FEHODR");
	this.FECRNM = reader.GetDecimal("FECRNM");
	this.FESHBF = reader.GetString("FESHBF");
	this.FECLEN = reader.GetString("FECLEN");
    this.FEFUTK = reader.GetString("FEFUTK");
    this.FEFUTP = reader.GetString("FEFUTP");
    this.FERTS = reader.GetString("FERTS");

    this.FESCTY = reader.GetString("FESCTY");
    this.FESPOV = reader.GetString("FESPOV");
    this.FETAMT = reader.GetString("FETAMT");

    this.FEPDAT = reader.GetDateTime("FEPDAT");
    this.FEPTIM = reader.GetDecimal("FEPTIM");
}
public override
void write(){
    string sql = "insert into " + getTable() + "( " +
        "DB,FEBOL,FEBTYP,FECDAT,FEPIND,FESIND,FEBCS,FESCS,FESVND,FERVND,FEBNME,FEBPTC,"+
	    "FEATTN,FESNME,FESAD1,FESAD2,FESAD3,FESAD4,FESAD5,FESAD6,FESAD7,FESAD8,FESAD9,FESAD10,FESPTC,FESDAT,"+
	    "FESVIA,FETKID,FENCTN,FENETW,FEGROW,FETARW,FEWTUN,FEDOCD,FEFTCD,FEORD,FESTKL,FEFTAM,FEFOB,FECARC,FESERC,FESTME,FEJITF,FESIDNUM,"+
        "FETRPT,FEBID,FESID,FESFID,FEPLNT,FEITMC,FESUPP,FEULTD,FEEDAT,FEETIM,FEADAT,FEATIM,FETRNM,FERTEG,FEPLPT,FEPLOC,FEEQPD,FEEQPI," +
        "FEEQID, FEMBOL, FEPSLP, FEFRTB, FEAIRB, FETSPR, FEETRR, FEEXTR, FEAETC, FEMTHP, FETRNT, FETRLQ, FECCT, FECCDE, FESASN, FESNTF, FESTS,"+
        "FEXMOD,FEATYP,FEFLD1,FEFLD2,FEFLD3,FEFLD4,FEFLD5,FEFLD6,FEMANW,FES204,FEBTRP,FEBSTS,FEBACK,FEBSET,FEBMOD,FESKDQ,FESKDT," +                
        "FELOSQ,FELOST,FECRCM,FEUSE,FESLCS,FECRTY,FECRDT,FECRD,FEEXPR,FEHODR,FECRNM,FESHBF,FECLEN" +
        "FEPDAT,FEPTIM"+
        ") values('" +
		Converter.fixString(DB) + "', " +
		NumberUtil.toString(FEBOL) + " ,'" +
		Converter.fixString(FEBTYP) +"', '" +
		DateUtil.getCompleteDateRepresentation(FECDAT) +"', '" +
		Converter.fixString(FEPIND) +"', '" +
		Converter.fixString(FESIND) +"', '" +
		Converter.fixString(FEBCS) +"', '" +
		Converter.fixString(FESCS) +"', '" +
		Converter.fixString(FESVND) +"', '" +
		Converter.fixString(FERVND) +"', '" +
		Converter.fixString(FEBNME) +"', '" +
		Converter.fixString(FEBPTC) +"', '" + //
		Converter.fixString(FEATTN) +"', '" +
		Converter.fixString(FESNME) +"', '" +
		Converter.fixString(FESAD1) +"', '" +
		Converter.fixString(FESAD2) +"', '" +
		Converter.fixString(FESAD3) +"', '" +
		Converter.fixString(FESAD4) +"', '" +
		Converter.fixString(FESAD5) +"', '" +
		Converter.fixString(FESAD6) +"', '" +
		Converter.fixString(FESAD7) +"', '" +
		Converter.fixString(FESAD8) +"', '" +
		Converter.fixString(FESAD9) +"', '" +
		Converter.fixString(FESAD10) +"', '" +
		Converter.fixString(FESPTC) +"', '" +
		DateUtil.getCompleteDateRepresentation(FESDAT) +"', '" + //
        Converter.fixString(FESVIA) +"', '" +
		Converter.fixString(FETKID) +"', " +
		NumberUtil.toString(FENCTN) +", " +
		NumberUtil.toString(FENETW) +", " +
		NumberUtil.toString(FEGROW) +", " +
		NumberUtil.toString(FETARW) +", '" +
		Converter.fixString(FEWTUN) +"', '" +
		Converter.fixString(FEDOCD) +"', '" +
		Converter.fixString(FEFTCD) +"', " +
		NumberUtil.toString(FEORD) +", '" +
		Converter.fixString(FESTKL) +"', " +
		NumberUtil.toString(FEFTAM) +", '" +
		Converter.fixString(FEFOB) +"', '" +
		Converter.fixString(FECARC) +"', '" +
		Converter.fixString(FESERC) +"', " +
		NumberUtil.toString(FESTME) +", '" +
		Converter.fixString(FEJITF) +"', '" +
		Converter.fixString(FESID_NUM) +"', '" + //
               
        Converter.fixString(FETRPT) +"', '" +
		Converter.fixString(FEBID) +"', '" +
		Converter.fixString(FESID) +"', '" +
		Converter.fixString(FESFID) +"', '" +
		Converter.fixString(FEPLNT) +"', '" +
		Converter.fixString(FEITMC) +"', '" +
		Converter.fixString(FESUPP) +"', '" +
		Converter.fixString(FEULTD) +"', '" +
		DateUtil.getCompleteDateRepresentation(FEEDAT) +"', " +
		NumberUtil.toString(FEETIM) +", '" +
		DateUtil.getCompleteDateRepresentation(FEADAT) +"', " +
		NumberUtil.toString(FEATIM) +", '" +
		Converter.fixString(FETRNM) +"', '" +
		Converter.fixString(FERTEG) +"', '" +
		Converter.fixString(FEPLPT) +"', '" +
		Converter.fixString(FEPLOC) +"', '" +
		Converter.fixString(FEEQPD) +"', '" +
		Converter.fixString(FEEQPI) +"', '" + //

        
        Converter.fixString(FEEQID) +"', " +
		NumberUtil.toString(FEMBOL) +", '" +
		Converter.fixString(FEPSLP) +"', '" +
		Converter.fixString(FEFRTB) +"', '" +
		Converter.fixString(FEAIRB) +"', '" +
		Converter.fixString(FETSPR) +"', '" +
		Converter.fixString(FEETRR) +"', '" +
		Converter.fixString(FEEXTR) +"', '" +
		Converter.fixString(FEAETC) +"', '" +
		Converter.fixString(FEMTHP) +"', '" +
		Converter.fixString(FETRNT) +"', '" +
		Converter.fixString(FETRLQ) +"', '" +
		Converter.fixString(FECCT) +"', '" +
		Converter.fixString(FECCDE) +"', '" +
		Converter.fixString(FESASN) +"', '" +
		Converter.fixString(FESNTF) +"', '" +
		Converter.fixString(FESTS) +"', '" +
        
        Converter.fixString(FEXMOD) +"', '" +
		Converter.fixString(FEATYP) +"', '" +
		Converter.fixString(FEFLD1) +"', '" +
		Converter.fixString(FEFLD2) +"', '" +
		Converter.fixString(FEFLD3) +"', '" +
		Converter.fixString(FEFLD4) +"', '" +
		Converter.fixString(FEFLD5) +"', '" +
		Converter.fixString(FEFLD6) +"', '" +
		Converter.fixString(FEMANW) +"', '" +
		Converter.fixString(FES204) +"', '" +
		Converter.fixString(FEBTRP) +"', '" +
		Converter.fixString(FEBSTS) +"', '" +
		Converter.fixString(FEBACK) +"', '" +
		Converter.fixString(FEBSET) +"', '" +
		Converter.fixString(FEBMOD) +"', " +
		NumberUtil.toString(FESKDQ) +", '" +
		Converter.fixString(FESKDT) +"', " + //
        
        NumberUtil.toString(FELOSQ) +", '" +
		Converter.fixString(FELOST) +"', '" +
		Converter.fixString(FECRCM) +"', '" +
		Converter.fixString(FEUSE) +"', '" +
		Converter.fixString(FESLCS) +"', '" +
		Converter.fixString(FECRTY) +"', '" +
		Converter.fixString(FECRDT) +"', '" +
		Converter.fixString(FECRD) +"', '" +
		Converter.fixString(FEEXPR) +"', '" +
		Converter.fixString(FEHODR) +"', " +
		NumberUtil.toString(FECRNM) +", '" +
		Converter.fixString(FESHBF) +"', '" +
        Converter.fixString(FECLEN) + "', '" +

        DateUtil.getCompleteDateRepresentation(FEPDAT) +"', " +
	    NumberUtil.toString(FEPTIM) + ")";
    
        /*
        Converter.fixString(FEFUTK) + "', '" +        
        Converter.fixString(FEFUTP) + "', '" +

        Converter.fixString(FERTS) + "', '" +
        Converter.fixString(FESCTY) + "', '" +
        Converter.fixString(FESPOV) + "', '" +
        Converter.fixString(FETAMT) + "')";        */

        write(sql);	
}
/*
public
bool exists(){
	try{
		bool ret = false;
		string febolField = "FEBOL";
		if(dataBaseAccess.getConnectionType() == DataBaseAccess.CMSTEMP_DATABASE)
			febolField = "FEBOL#";
		string sql = "select * from bolh " + 
			"where " +
			"DB ='" + Converter.fixString(DB)+ "' and " +
			febolField+" ="+ NumberUtil.toString(FEBOL) + " and " +
			"FEBTYP ='" +Converter.fixString(FEBTYP)+ "'";
		NotNullDataReader reader = dataBaseAccess.executeQuery(sql);
		if (reader.Read())
			ret = true;
		reader.Close();
		return ret;
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + myExc.Message, myExc);
	}catch(System.Data.SqlClient.SqlException se){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + se.Message, se);
	}catch(System.Data.DataException de){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> : " + de.Message, de);
	}
}
*/

public override
void update(){            
    string sql = "update bolh set " + //assume not update on CMS side
       " DB ='" +       Converter.fixString(DB) + "', " +
       " FEBOL =" + NumberUtil.toString(FEBOL) + " ," +
       " FEBTYP ='" + Converter.fixString(FEBTYP) + "'," +
       " FECDAT ='" + DateUtil.getCompleteDateRepresentation(FECDAT) + "', " +
       " FEPIND ='" + Converter.fixString(FEPIND) + "'," +
        " FESIND ='" + Converter.fixString(FESIND) + "'," +
        " FEBCS ='" + Converter.fixString(FEBCS) + "'," +
        " FESCS ='" + Converter.fixString(FESCS) + "'," +
        " FESVND ='" + Converter.fixString(FESVND) + "'," +
        " FERVND ='" + Converter.fixString(FERVND) + "'," +
        " FEBNME ='" + Converter.fixString(FEBNME) + "'," +
        " FEBPTC ='" + Converter.fixString(FEBPTC) + "'," + //
        " FEATTN ='" + Converter.fixString(FEATTN) + "'," +
        " FESNME ='" + Converter.fixString(FESNME) + "'," +
        " FESAD1 ='" + Converter.fixString(FESAD1) + "'," +
        " FESAD2 ='" + Converter.fixString(FESAD2) + "'," +
        " FESAD3 ='" + Converter.fixString(FESAD3) + "'," +
        " FESAD4 ='" + Converter.fixString(FESAD4) + "'," +
        " FESAD5 ='" + Converter.fixString(FESAD5) + "'," +
        " FESAD6 ='" + Converter.fixString(FESAD6) + "'," +
        " FESAD7 ='" + Converter.fixString(FESAD7) + "'," +
        " FESAD8 ='" + Converter.fixString(FESAD8) + "'," +
        " FESAD9 ='" + Converter.fixString(FESAD9) + "'," +
        " FESAD10 ='" + Converter.fixString(FESAD10) + "'," +
        " FESPTC ='" + Converter.fixString(FESPTC) + "'," +
        " FESDAT ='" + DateUtil.getCompleteDateRepresentation(FESDAT) + "'," + //
        " FESVIA ='" + Converter.fixString(FESVIA) + "'," +
        " FETKID ='" + Converter.fixString(FETKID) + "'," +
        " FENCTN =" + NumberUtil.toString(FENCTN) + ", " +
        " FENETW =" + NumberUtil.toString(FENETW) + ", " +
        " FEGROW =" + NumberUtil.toString(FEGROW) + ", " +
        " FETARW =" + NumberUtil.toString(FETARW) + "," +
        " FEWTUN ='" + Converter.fixString(FEWTUN) + "'," +
        " FEDOCD ='" + Converter.fixString(FEDOCD) + "'," +
        " FEFTCD ='" + Converter.fixString(FEFTCD) + "', " +
        " FEORD =" + NumberUtil.toString(FEORD) + "," +
        " FESTKL ='" + Converter.fixString(FESTKL) + "', " +
        " FEFTAM =" + NumberUtil.toString(FEFTAM) + "," +
        " FEFOB ='" + Converter.fixString(FEFOB) + "'," +
        " FECARC ='" + Converter.fixString(FECARC) + "'," +
        " FESERC ='" + Converter.fixString(FESERC) + "', " +
        " FESTME =" + NumberUtil.toString(FESTME) + "," +
        " FEJITF ='" + Converter.fixString(FEJITF) + "'," +
        " FESIDNUM ='" + Converter.fixString(FESID_NUM) + "'," + //

        " FETRPT ='" + Converter.fixString(FETRPT) + "'," +
        " FEBID ='" + Converter.fixString(FEBID) + "'," +
        " FESID ='" + Converter.fixString(FESID) + "'," +
        " FESFID ='" + Converter.fixString(FESFID) + "'," +
        " FEPLNT ='" + Converter.fixString(FEPLNT) + "'," +
        " FEITMC ='" + Converter.fixString(FEITMC) + "'," +
        " FESUPP ='" + Converter.fixString(FESUPP) + "'," +
        " FEULTD ='" + Converter.fixString(FEULTD) + "'," +
        " FEEDAT ='" + DateUtil.getCompleteDateRepresentation(FEEDAT) + "', " +
        " FEETIM =" + NumberUtil.toString(FEETIM) + "," +
        " FEADAT ='" + DateUtil.getCompleteDateRepresentation(FEADAT) + "', " +
        " FEATIM =" + NumberUtil.toString(FEATIM) + "," +
        " FETRNM ='" + Converter.fixString(FETRNM) + "'," +
        " FERTEG ='" + Converter.fixString(FERTEG) + "'," +
        " FEPLPT ='" + Converter.fixString(FEPLPT) + "'," +
        " FEPLOC ='" + Converter.fixString(FEPLOC) + "'," +
        " FEEQPD ='" + Converter.fixString(FEEQPD) + "'," +
        " FEEQPI ='" + Converter.fixString(FEEQPI) + "'," + //


        " FEEQID ='" + Converter.fixString(FEEQID) + "', " +
        " FEMBOL =" + NumberUtil.toString(FEMBOL) + "," +
        " FEPSLP ='" + Converter.fixString(FEPSLP) + "'," +
        " FEFRTB ='" + Converter.fixString(FEFRTB) + "'," +
        " FEAIRB ='" + Converter.fixString(FEAIRB) + "'," +
        " FETSPR ='" + Converter.fixString(FETSPR) + "'," +
        " FEETRR ='" + Converter.fixString(FEETRR) + "'," +
        " FEEXTR ='" + Converter.fixString(FEEXTR) + "'," +
        " FEAETC ='" + Converter.fixString(FEAETC) + "'," +
        " FEMTHP ='" + Converter.fixString(FEMTHP) + "'," +
        " FETRNT ='" + Converter.fixString(FETRNT) + "'," +
        " FETRLQ ='" + Converter.fixString(FETRLQ) + "'," +
        " FECCT ='" + Converter.fixString(FECCT) + "'," +
        " FECCDE ='" + Converter.fixString(FECCDE) + "'," +
        " FESASN ='" + Converter.fixString(FESASN) + "'," +
        " FESNTF ='" + Converter.fixString(FESNTF) + "'," +
        " FESTS ='" + Converter.fixString(FESTS) + "'," +

        " FEXMOD ='" + Converter.fixString(FEXMOD) + "'," +
        " FEATYP ='" + Converter.fixString(FEATYP) + "'," +
        " FEFLD1 ='" + Converter.fixString(FEFLD1) + "'," +
        " FEFLD2 ='" + Converter.fixString(FEFLD2) + "'," +
        " FEFLD3 ='" + Converter.fixString(FEFLD3) + "'," +
        " FEFLD4 ='" + Converter.fixString(FEFLD4) + "'," +
        " FEFLD5 ='" + Converter.fixString(FEFLD5) + "'," +
        " FEFLD6 ='" + Converter.fixString(FEFLD6) + "'," +
        " FEMANW ='" + Converter.fixString(FEMANW) + "'," +
        " FES204 ='" + Converter.fixString(FES204) + "'," +
        " FEBTRP ='" + Converter.fixString(FEBTRP) + "'," +
        " FEBSTS ='" + Converter.fixString(FEBSTS) + "'," +
        " FEBACK ='" + Converter.fixString(FEBACK) + "'," +
        " FEBSET ='" + Converter.fixString(FEBSET) + "'," +
        " FEBMOD ='" + Converter.fixString(FEBMOD) + "'," +
        " FESKDQ =" + NumberUtil.toString(FESKDQ) + "," +
        " FESKDT ='" + Converter.fixString(FESKDT) + "'," + //

        " FELOSQ =" + NumberUtil.toString(FELOSQ) + "," +
        " FELOST ='" + Converter.fixString(FELOST) + "'," +
        " FECRCM ='" + Converter.fixString(FECRCM) + "'," +
        " FEUSE ='" + Converter.fixString(FEUSE) + "'," +
        " FESLCS ='" + Converter.fixString(FESLCS) + "'," +
        " FECRTY ='" + Converter.fixString(FECRTY) + "'," +
        " FECRDT ='" + Converter.fixString(FECRDT) + "'," +
        " FECRD ='" + Converter.fixString(FECRD) + "'," +
        " FEEXPR ='" + Converter.fixString(FEEXPR) + "'," +
        " FEHODR ='" + Converter.fixString(FEHODR) + "', " +
        " FECRNM =" + NumberUtil.toString(FECRNM) + "," +
        " FESHBF ='" + Converter.fixString(FESHBF) + "'," +
        " FECLEN ='" + Converter.fixString(FECLEN) + "'," +

        " FEPDAT ='" + DateUtil.getCompleteDateRepresentation(FEPDAT) + "', " +
        " FEPTIM =" + NumberUtil.toString(FEPTIM) + " " +

        " where " + getWhereCondition();

    update(sql);

}

public 
void updateFERTEG(string FERTEG){
	string sql = "update " + getTable()+ " set " +
        "FERTEG = '" + Converter.fixString(FERTEG) + "' " +
		"where " + getWhereCondition();

    //System.Windows.Forms.MessageBox.Show("updateFERTEG:" + sql);
	update(sql);
}

public
void updateSomeFields(string sfERTEG, string skdidSpot){
	string sql = "update " + getTable()+ " set " +
        "FERTEG = '" + Converter.fixString(FERTEG) + "' ," +
        "FEFUTK = '" + Converter.fixString(skdidSpot) + "' " +
		"where " + getWhereCondition();

    //System.Windows.Forms.MessageBox.Show("updateSomeFields:" + sql);
	update(sql);
}

public override
void delete(){
    string sql = "delete from " + getTable() + " where " + getWhereCondition();
	delete(sql);
}

public
string getWhereCondition(){
	string febolField = "FEBOL";
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		febolField = "FEBOL#";
	string sqlWhere =
			febolField + " = " + NumberUtil.toString(FEBOL);
		return sqlWhere;
}
//Setters
public void setDB(string DB){
   this.DB = DB;
}
public void setFEBOL(decimal FEBOL){
   this.FEBOL = FEBOL;
}
public void setFEBTYP(string FEBTYP){
   this.FEBTYP = FEBTYP;
}
public void setFECDAT(DateTime FECDAT){
   this.FECDAT = FECDAT;
}
public void setFEPIND(string FEPIND){
   this.FEPIND = FEPIND;
}
public void setFESIND(string FESIND){
   this.FESIND = FESIND;
}
public void setFEBCS(string FEBCS){
   this.FEBCS = FEBCS;
}
public void setFESCS(string FESCS){
   this.FESCS = FESCS;
}
public void setFESVND(string FESVND){
   this.FESVND = FESVND;
}
public void setFERVND(string FERVND){
   this.FERVND = FERVND;
}
public void setFEBNME(string FEBNME){
   this.FEBNME = FEBNME;
}
public void setFEBPTC(string FEBPTC){
   this.FEBPTC = FEBPTC;
}
public void setFEATTN(string FEATTN){
   this.FEATTN = FEATTN;
}
public void setFESNME(string FESNME){
   this.FESNME = FESNME;
}
public void setFESAD1(string FESAD1){
   this.FESAD1 = FESAD1;
}
public void setFESAD2(string FESAD2){
   this.FESAD2 = FESAD2;
}
public void setFESAD3(string FESAD3){
   this.FESAD3 = FESAD3;
}
public void setFESAD4(string FESAD4){
   this.FESAD4 = FESAD4;
}
public void setFESAD5(string FESAD5){
   this.FESAD5 = FESAD5;
}
public void setFESAD6(string FESAD6){
   this.FESAD6 = FESAD6;
}
public void setFESAD7(string FESAD7){
   this.FESAD7 = FESAD7;
}
public void setFESAD8(string FESAD8){
   this.FESAD8 = FESAD8;
}
public void setFESAD9(string FESAD9){
   this.FESAD9 = FESAD9;
}
public void setFESAD10(string FESAD10){
   this.FESAD10 = FESAD10;
}
public void setFESPTC(string FESPTC){
   this.FESPTC = FESPTC;
}
public void setFESDAT(DateTime FESDAT){
   this.FESDAT = FESDAT;
}
public void setFESVIA(string FESVIA){
   this.FESVIA = FESVIA;
}
public void setFETKID(string FETKID){
   this.FETKID = FETKID;
}
public void setFENCTN(decimal FENCTN){
   this.FENCTN = FENCTN;
}
public void setFENETW(decimal FENETW){
   this.FENETW = FENETW;
}
public void setFEGROW(decimal FEGROW){
   this.FEGROW = FEGROW;
}
public void setFETARW(decimal FETARW){
   this.FETARW = FETARW;
}
public void setFEWTUN(string FEWTUN){
   this.FEWTUN = FEWTUN;
}
public void setFEDOCD(string FEDOCD){
   this.FEDOCD = FEDOCD;
}
public void setFEFTCD(string FEFTCD){
   this.FEFTCD = FEFTCD;
}
public void setFEORD(decimal FEORD){
   this.FEORD = FEORD;
}
public void setFESTKL(string FESTKL){
   this.FESTKL = FESTKL;
}
public void setFEFTAM(decimal FEFTAM){
   this.FEFTAM = FEFTAM;
}
public void setFEFOB(string FEFOB){
   this.FEFOB = FEFOB;
}
public void setFECARC(string FECARC){
   this.FECARC = FECARC;
}
public void setFESERC(string FESERC){
   this.FESERC = FESERC;
}
public void setFESTME(decimal FESTME){
   this.FESTME = FESTME;
}
public void setFEJITF(string FEJITF){
   this.FEJITF = FEJITF;
}
public void setFESID_NUM(string FESID_NUM){
   this.FESID_NUM = FESID_NUM;
}
public void setFETRPT(string FETRPT){
   this.FETRPT = FETRPT;
}
public void setFEBID(string FEBID){
   this.FEBID = FEBID;
}
public void setFESID(string FESID){
   this.FESID = FESID;
}
public void setFESFID(string FESFID){
   this.FESFID = FESFID;
}
public void setFEPLNT(string FEPLNT){
   this.FEPLNT = FEPLNT;
}
public void setFEITMC(string FEITMC){
   this.FEITMC = FEITMC;
}
public void setFESUPP(string FESUPP){
   this.FESUPP = FESUPP;
}
public void setFEULTD(string FEULTD){
   this.FEULTD = FEULTD;
}
public void setFEEDAT(DateTime FEEDAT){
   this.FEEDAT = FEEDAT;
}
public void setFEETIM(decimal FEETIM){
   this.FEETIM = FEETIM;
}
public void setFEADAT(DateTime FEADAT){
   this.FEADAT = FEADAT;
}
public void setFEATIM(decimal FEATIM){
   this.FEATIM = FEATIM;
}
public void setFETRNM(string FETRNM){
   this.FETRNM = FETRNM;
}
public void setFERTEG(string FERTEG){
   this.FERTEG = FERTEG;
}
public void setFEPLPT(string FEPLPT){
   this.FEPLPT = FEPLPT;
}
public void setFEPLOC(string FEPLOC){
   this.FEPLOC = FEPLOC;
}
public void setFEEQPD(string FEEQPD){
   this.FEEQPD = FEEQPD;
}
public void setFEEQPI(string FEEQPI){
   this.FEEQPI = FEEQPI;
}
public void setFEEQID(string FEEQID){
   this.FEEQID = FEEQID;
}
public void setFEMBOL(decimal FEMBOL){
   this.FEMBOL = FEMBOL;
}
public void setFEPSLP(string FEPSLP){
   this.FEPSLP = FEPSLP;
}
public void setFEFRTB(string FEFRTB){
   this.FEFRTB = FEFRTB;
}
public void setFEAIRB(string FEAIRB){
   this.FEAIRB = FEAIRB;
}
public void setFETSPR(string FETSPR){
   this.FETSPR = FETSPR;
}
public void setFEETRR(string FEETRR){
   this.FEETRR = FEETRR;
}
public void setFEEXTR(string FEEXTR){
   this.FEEXTR = FEEXTR;
}
public void setFEAETC(string FEAETC){
   this.FEAETC = FEAETC;
}
public void setFEMTHP(string FEMTHP){
   this.FEMTHP = FEMTHP;
}
public void setFETRNT(string FETRNT){
   this.FETRNT = FETRNT;
}
public void setFETRLQ(string FETRLQ){
   this.FETRLQ = FETRLQ;
}
public void setFECCT(string FECCT){
   this.FECCT = FECCT;
}
public void setFECCDE(string FECCDE){
   this.FECCDE = FECCDE;
}
public void setFESASN(string FESASN){
   this.FESASN = FESASN;
}
public void setFESNTF(string FESNTF){
   this.FESNTF = FESNTF;
}
public void setFESTS(string FESTS){
   this.FESTS = FESTS;
}
public void setFEXMOD(string FEXMOD){
   this.FEXMOD = FEXMOD;
}
public void setFEATYP(string FEATYP){
   this.FEATYP = FEATYP;
}
public void setFEFLD1(string FEFLD1){
   this.FEFLD1 = FEFLD1;
}
public void setFEFLD2(string FEFLD2){
   this.FEFLD2 = FEFLD2;
}
public void setFEFLD3(string FEFLD3){
   this.FEFLD3 = FEFLD3;
}
public void setFEFLD4(string FEFLD4){
   this.FEFLD4 = FEFLD4;
}
public void setFEFLD5(string FEFLD5){
   this.FEFLD5 = FEFLD5;
}
public void setFEFLD6(string FEFLD6){
   this.FEFLD6 = FEFLD6;
}
public void setFEMANW(string FEMANW){
   this.FEMANW = FEMANW;
}
public void setFES204(string FES204){
   this.FES204 = FES204;
}
public void setFEBTRP(string FEBTRP){
   this.FEBTRP = FEBTRP;
}
public void setFEBSTS(string FEBSTS){
   this.FEBSTS = FEBSTS;
}
public void setFEBACK(string FEBACK){
   this.FEBACK = FEBACK;
}
public void setFEBSET(string FEBSET){
   this.FEBSET = FEBSET;
}
public void setFEBMOD(string FEBMOD){
   this.FEBMOD = FEBMOD;
}
public void setFESKDQ(decimal FESKDQ){
   this.FESKDQ = FESKDQ;
}
public void setFESKDT(string FESKDT){
   this.FESKDT = FESKDT;
}
public void setFELOSQ(decimal FELOSQ){
   this.FELOSQ = FELOSQ;
}
public void setFELOST(string FELOST){
   this.FELOST = FELOST;
}
public void setFECRCM(string FECRCM){
   this.FECRCM = FECRCM;
}
public void setFEUSE(string FEUSE){
   this.FEUSE = FEUSE;
}
public void setFESLCS(string FESLCS){
   this.FESLCS = FESLCS;
}
public void setFECRTY(string FECRTY){
   this.FECRTY = FECRTY;
}
public void setFECRDT(string FECRDT){
   this.FECRDT = FECRDT;
}
public void setFECRD(string FECRD){
   this.FECRD = FECRD;
}
public void setFEEXPR(string FEEXPR){
   this.FEEXPR = FEEXPR;
}
public void setFEHODR(string FEHODR){
   this.FEHODR = FEHODR;
}
public void setFECRNM(decimal FECRNM){
   this.FECRNM = FECRNM;
}
public void setFESHBF(string FESHBF){
   this.FESHBF = FESHBF;
}
public void setFECLEN(string FECLEN){
   this.FECLEN = FECLEN;
}
public void setFEFUTK(string FEFUTK){
    this.FEFUTK = FEFUTK;
}
public void setFEFUTP(string FEFUTP){
    this.FEFUTP = FEFUTP;
}
public void setFERTS(string FERTS){
    this.FERTS = FERTS;
}

public void setFESCTY(string FESCTY){
    this.FESCTY = FESCTY;
}
public void setFESPOV(string FESPOV){
    this.FESPOV = FESPOV;
}

public void setFETAMT(string FETAMT){
    this.FETAMT = FETAMT;
}
    
public void setFEPDAT(DateTime FEPDAT){
    this.FEPDAT = FEPDAT;
}

public void setFEPTIM(decimal FEPTIM){
    this.FEPTIM = FEPTIM;
}

//Getters
public
string getDB(){
   return DB;
}
public
decimal getFEBOL(){
   return FEBOL;
}
public
string getFEBTYP(){
   return FEBTYP;
}
public
DateTime getFECDAT(){
   return FECDAT;
}
public
string getFEPIND(){
   return FEPIND;
}
public
string getFESIND(){
   return FESIND;
}
public
string getFEBCS(){
   return FEBCS;
}
public
string getFESCS(){
   return FESCS;
}
public
string getFESVND(){
   return FESVND;
}
public
string getFERVND(){
   return FERVND;
}
public
string getFEBNME(){
   return FEBNME;
}
public
string getFEBPTC(){
   return FEBPTC;
}
public
string getFEATTN(){
   return FEATTN;
}
public
string getFESNME(){
   return FESNME;
}
public
string getFESAD1(){
   return FESAD1;
}
public
string getFESAD2(){
   return FESAD2;
}
public
string getFESAD3(){
   return FESAD3;
}
public
string getFESAD4(){
   return FESAD4;
}
public
string getFESAD5(){
   return FESAD5;
}
public
string getFESAD6(){
   return FESAD6;
}
public
string getFESAD7(){
   return FESAD7;
}
public
string getFESAD8(){
   return FESAD8;
}
public
string getFESAD9(){
   return FESAD9;
}
public
string getFESAD10(){
   return FESAD10;
}
public
string getFESPTC(){
   return FESPTC;
}
public
DateTime getFESDAT(){
   return FESDAT;
}
public
string getFESVIA(){
   return FESVIA;
}
public
string getFETKID(){
   return FETKID;
}
public
decimal getFENCTN(){
   return FENCTN;
}
public
decimal getFENETW(){
   return FENETW;
}
public
decimal getFEGROW(){
   return FEGROW;
}
public
decimal getFETARW(){
   return FETARW;
}
public
string getFEWTUN(){
   return FEWTUN;
}
public
string getFEDOCD(){
   return FEDOCD;
}
public
string getFEFTCD(){
   return FEFTCD;
}
public
decimal getFEORD(){
   return FEORD;
}
public
string getFESTKL(){
   return FESTKL;
}
public
decimal getFEFTAM(){
   return FEFTAM;
}
public
string getFEFOB(){
   return FEFOB;
}
public
string getFECARC(){
   return FECARC;
}
public
string getFESERC(){
   return FESERC;
}
public
decimal getFESTME(){
   return FESTME;
}
public
string getFEJITF(){
   return FEJITF;
}
public
string getFESID_NUM(){
   return FESID_NUM;
}
public
string getFETRPT(){
   return FETRPT;
}
public
string getFEBID(){
   return FEBID;
}
public
string getFESID(){
   return FESID;
}
public
string getFESFID(){
   return FESFID;
}
public
string getFEPLNT(){
   return FEPLNT;
}
public
string getFEITMC(){
   return FEITMC;
}
public
string getFESUPP(){
   return FESUPP;
}
public
string getFEULTD(){
   return FEULTD;
}
public
DateTime getFEEDAT(){
   return FEEDAT;
}
public
decimal getFEETIM(){
   return FEETIM;
}
public
DateTime getFEADAT(){
   return FEADAT;
}
public
decimal getFEATIM(){
   return FEATIM;
}
public
string getFETRNM(){
   return FETRNM;
}
public
string getFERTEG(){
   return FERTEG;
}
public
string getFEPLPT(){
   return FEPLPT;
}
public
string getFEPLOC(){
   return FEPLOC;
}
public
string getFEEQPD(){
   return FEEQPD;
}
public
string getFEEQPI(){
   return FEEQPI;
}
public
string getFEEQID(){
   return FEEQID;
}
public
decimal getFEMBOL(){
   return FEMBOL;
}
public
string getFEPSLP(){
   return FEPSLP;
}
public
string getFEFRTB(){
   return FEFRTB;
}
public
string getFEAIRB(){
   return FEAIRB;
}
public
string getFETSPR(){
   return FETSPR;
}
public
string getFEETRR(){
   return FEETRR;
}
public
string getFEEXTR(){
   return FEEXTR;
}
public
string getFEAETC(){
   return FEAETC;
}
public
string getFEMTHP(){
   return FEMTHP;
}
public
string getFETRNT(){
   return FETRNT;
}
public
string getFETRLQ(){
   return FETRLQ;
}
public
string getFECCT(){
   return FECCT;
}
public
string getFECCDE(){
   return FECCDE;
}
public
string getFESASN(){
   return FESASN;
}
public
string getFESNTF(){
   return FESNTF;
}
public
string getFESTS(){
   return FESTS;
}
public
string getFEXMOD(){
   return FEXMOD;
}
public
string getFEATYP(){
   return FEATYP;
}
public
string getFEFLD1(){
   return FEFLD1;
}
public
string getFEFLD2(){
   return FEFLD2;
}
public
string getFEFLD3(){
   return FEFLD3;
}
public
string getFEFLD4(){
   return FEFLD4;
}
public
string getFEFLD5(){
   return FEFLD5;
}
public
string getFEFLD6(){
   return FEFLD6;
}
public
string getFEMANW(){
   return FEMANW;
}
public
string getFES204(){
   return FES204;
}
public
string getFEBTRP(){
   return FEBTRP;
}
public
string getFEBSTS(){
   return FEBSTS;
}
public
string getFEBACK(){
   return FEBACK;
}
public
string getFEBSET(){
   return FEBSET;
}
public
string getFEBMOD(){
   return FEBMOD;
}
public
decimal getFESKDQ(){
   return FESKDQ;
}
public
string getFESKDT(){
   return FESKDT;
}
public
decimal getFELOSQ(){
   return FELOSQ;
}
public
string getFELOST(){
   return FELOST;
}
public
string getFECRCM(){
   return FECRCM;
}
public
string getFEUSE(){
   return FEUSE;
}
public
string getFESLCS(){
   return FESLCS;
}
public
string getFECRTY(){
   return FECRTY;
}
public
string getFECRDT(){
   return FECRDT;
}
public
string getFECRD(){
   return FECRD;
}
public
string getFEEXPR(){
   return FEEXPR;
}
public
string getFEHODR(){
   return FEHODR;
}
public
decimal getFECRNM(){
   return FECRNM;
}
public
string getFESHBF(){
   return FESHBF;
}
public
string getFECLEN(){
   return FECLEN;
}

public
string getFEFUTK(){
    return FEFUTK;
}

public
string getFEFUTP(){
    return FEFUTP;
}

public
string getFERTS(){
    return FERTS;
}
public
string getFESCTY(){
    return FESCTY;
}
public
string getFESPOV(){
    return FESPOV;
}

public 
string getFETAMT(){
    return FETAMT;
}
    
public 
DateTime getFEPDAT(){
    return FEPDAT;
}

public 
decimal getFEPTIM(){
    return FEPTIM;
}

}//end class
}//end namespace
