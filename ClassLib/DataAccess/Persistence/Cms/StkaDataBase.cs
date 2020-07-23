/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class StkaDataBase : GenericDataBaseElement {

private string V6PLNT;
private string V6PART;
private string V6UNTI;
private string V6RPLN;
private string V6TPLN;
private decimal V6TDYS;
private decimal V6MRPS;
private string V6ABCC;
private decimal V6CCPY;
private DateTime V6LCDT;
private DateTime V6DBCC;
private decimal V6ORDQ;
private string V6OPCY;
private decimal V6MULT;
private string V6FUT1;
private string V6FUT2;
private string V6SCDT;
private string V6PLAN;
private string V6CNTR;
private string V6UNTP;
private decimal V6LVL;
private decimal V6PACK;
private string V6PACU;
private decimal V6PRPT;
private string V6KITC;
private string V6PROC;
private string V6LRSP;
private decimal V6LRSC;
private string V6LRSF;
private string V6LRMP;
private decimal V6LRMC;
private string V6LRMF;
private string V6LWSP;
private decimal V6LWSC;
private string V6LWSF;
private string V6LCSP;
private decimal V6LCSC;
private string V6LCSF;
private string V6LCMP;
private decimal V6LCMC;
private string V6LCMF;
private decimal V6LSSC;
private string V6LSSF;
private string V6LSMP;
private decimal V6LSMC;
private string V6LSMF;
private decimal V6MPCK;
private string V6MPKU;
private decimal V6ALTF;
private string V6DBUY;
private decimal V6SCDP;
private string V6SELP;
private decimal V6RCPS;
private string V6RECU;
private string V6RECC;
private decimal V6FTMF;
private string V6CSMU;
private string V6NTKY;
private decimal V6MINQ;
private decimal V6MAXQ;
private decimal V6MOQT;
private decimal V6ESTV;
private string V6CORG;
private string V6PSOR;
private string V6STAT;
private string V6REAS;
private string V6AUTY;
private string V6UNTO;
private string V6REQC;
private string V6BUYR;
private decimal V6LEAD;
private decimal V6OPTR;
private decimal V6MULTP;
private decimal V6MINR;
private decimal V6PERC;
private decimal V6OLA;
private decimal V6MPQT;
private decimal V6DPST;
private DateTime V6SPDT;
private DateTime V6BBDT;
private decimal V6ORLT;
private string V6AUTR;
private string V6REPP;
private decimal V6REPT;
private decimal V6SHRK;
private decimal V6FCFN;
private decimal V6AUTO;
private decimal V6OLOK;
private string V6OEPY;
private string V6PRFR;
private string V6CMTL;
private string V6DRWS;
private string V6DRWL;
private string V6DENC;
private string V6DREL;
private DateTime V6DDAT;
private string V6DRWN;
private string V6DRWS2;
private string V6DRWL2;
private string V6DENC2;
private string V6DREL2;
private DateTime V6DDAT2;
private string V6DRWN2;
private string V6LOTF;
private string V6SERF;
private string V6LOTB;
private string V6LOTA;
private string V6LOTV;
private string V6STCL;
private string V6VLCD;
private decimal V6SPPP;
private string V6SPPC;
private decimal V6MPPP;
private string V6MPPC;
private string V6FRML;
private string V6ISTR;
private string V6ENGC;
private string V6REVL;
private DateTime V6RDAT;
private string V6RCVLC;
private string V6SFLC;
private string V6CUSR;
private DateTime V6CDAT;
private decimal V6CTME;
private string V6UUSR;
private DateTime V6UDAT;
private decimal V6UTME;
private string V6FUT3;
private string V6FUT4;
private string V6FUT5;
private string V6FLG1;
private string V6FLG2;
private string V6FLG3;
private string V6FLG4;
private string V6FLG5;
private string V6FLG6;
private string V6FLG7;
private string V6FLG8;
private string V6FLG9;
private string V6FLG10;
private decimal V6FUT6;
private string V6FUT7;
private string V6FUT8;
private string V6FUT9;
private string V6FUT10;
private string V6FUT11;
private string V6FUT12;
private string V6FUT13;
private string V6FUT14;
private string V6FUT15;
private string V6FUT16;
private string V6FUT17;
private string V6FUT18;
private string V6FUT19;
private string V6FUT20;
private string V6FUT21;
private string V6FUT22;
private string V6FUT23;
private string V6FUT24;
private string V6FUT25;
private decimal V6FUT26;
private decimal V6FUT27;
private decimal V6FUT28;
private decimal V6FUT29;
private decimal V6FUT30;
private decimal V6FUT31;
private decimal V6FUT32;
private decimal V6FUT33;
private decimal V6FUT34;
private decimal V6FUT35;
private DateTime V6FUT36;
private DateTime V6FUT37;
private DateTime V6FUT38;
private DateTime V6FUT39;
private DateTime V6FUT40;
private decimal V6FUT41;
private decimal V6FUT42;
private decimal V6FUT43;
private decimal V6FUT44;
private decimal V6FUT45;
private string V6PRCL;
private string V6DBAC;
private string V6SCDPT;
private string V6APSUP;
private string V6MATP;
private string V6MATM;
private string V6MESC;
private string V6CRTM;
private decimal V6LLED;
private string V6PCTR;
private string V6INQU;
private string V6CLEXP;

public
StkaDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

/*
public
bool read(){
	string sql = "select * from stka where " + getWhereCondition();
	return read(sql);
}*/

public
bool exists(){
    string sql = "select * from " + getTablePrefix() + "stka where " + getWhereCondition();
	return exists(sql);
}

public
void load(NotNullDataReader reader){
	this.V6PLNT = reader.GetString("V6PLNT");
	this.V6PART = reader.GetString("V6PART");
	this.V6UNTI = reader.GetString("V6UNTI");
	this.V6RPLN = reader.GetString("V6RPLN");
	this.V6TPLN = reader.GetString("V6TPLN");
	this.V6TDYS = reader.GetDecimal("V6TDYS");
	this.V6MRPS = reader.GetDecimal("V6MRPS");
	this.V6ABCC = reader.GetString("V6ABCC");
	this.V6CCPY = reader.GetDecimal("V6CCPY");
	this.V6LCDT = reader.GetDateTime("V6LCDT");
	this.V6DBCC = reader.GetDateTime("V6DBCC");
	this.V6ORDQ = reader.GetDecimal("V6ORDQ");
	this.V6OPCY = reader.GetString("V6OPCY");
	this.V6MULT = reader.GetDecimal("V6MULT");
	this.V6FUT1 = reader.GetString("V6FUT1");
	this.V6FUT2 = reader.GetString("V6FUT2");
	this.V6SCDT = reader.GetString("V6SCDT");
	this.V6PLAN = reader.GetString("V6PLAN");
	this.V6CNTR = reader.GetString("V6CNTR");
	this.V6UNTP = reader.GetString("V6UNTP");
	this.V6LVL = reader.GetDecimal("V6LVL");
	this.V6PACK = reader.GetDecimal("V6PACK");
	this.V6PACU = reader.GetString("V6PACU");
	this.V6PRPT = reader.GetDecimal("V6PRPT");
	this.V6KITC = reader.GetString("V6KITC");
	this.V6PROC = reader.GetString("V6PROC");
	this.V6LRSP = reader.GetString("V6LRSP");
	this.V6LRSC = reader.GetDecimal("V6LRSC");
	this.V6LRSF = reader.GetString("V6LRSF");
	this.V6LRMP = reader.GetString("V6LRMP");
	this.V6LRMC = reader.GetDecimal("V6LRMC");
	this.V6LRMF = reader.GetString("V6LRMF");
	this.V6LWSP = reader.GetString("V6LWSP");
	this.V6LWSC = reader.GetDecimal("V6LWSC");
	this.V6LWSF = reader.GetString("V6LWSF");
	this.V6LCSP = reader.GetString("V6LCSP");
	this.V6LCSC = reader.GetDecimal("V6LCSC");
	this.V6LCSF = reader.GetString("V6LCSF");
	this.V6LCMP = reader.GetString("V6LCMP");
	this.V6LCMC = reader.GetDecimal("V6LCMC");
	this.V6LCMF = reader.GetString("V6LCMF");
	this.V6LSSC = reader.GetDecimal("V6LSSC");
	this.V6LSSF = reader.GetString("V6LSSF");
	this.V6LSMP = reader.GetString("V6LSMP");
	this.V6LSMC = reader.GetDecimal("V6LSMC");
	this.V6LSMF = reader.GetString("V6LSMF");
	this.V6MPCK = reader.GetDecimal("V6MPCK");
	this.V6MPKU = reader.GetString("V6MPKU");
	this.V6ALTF = reader.GetDecimal("V6ALTF");
	this.V6DBUY = reader.GetString("V6DBUY");
	this.V6SCDP = reader.GetDecimal("V6SCDP");
	this.V6SELP = reader.GetString("V6SELP");
	this.V6RCPS = reader.GetDecimal("V6RCPS");
	this.V6RECU = reader.GetString("V6RECU");
	this.V6RECC = reader.GetString("V6RECC");
	this.V6FTMF = reader.GetDecimal("V6FTMF");
	this.V6CSMU = reader.GetString("V6CSMU");
	this.V6NTKY = reader.GetString("V6NTKY");
	this.V6MINQ = reader.GetDecimal("V6MINQ");
	this.V6MAXQ = reader.GetDecimal("V6MAXQ");
	this.V6MOQT = reader.GetDecimal("V6MOQT");
	this.V6ESTV = reader.GetDecimal("V6ESTV");
	this.V6CORG = reader.GetString("V6CORG");
	this.V6PSOR = reader.GetString("V6PSOR");
	this.V6STAT = reader.GetString("V6STAT");
	this.V6REAS = reader.GetString("V6REAS");
	this.V6AUTY = reader.GetString("V6AUTY");
	this.V6UNTO = reader.GetString("V6UNTO");
	this.V6REQC = reader.GetString("V6REQC");
	this.V6BUYR = reader.GetString("V6BUYR");
	this.V6LEAD = reader.GetDecimal("V6LEAD");
	this.V6OPTR = reader.GetDecimal("V6OPTR");
	this.V6MULTP = reader.GetDecimal("V6MULTP");
	this.V6MINR = reader.GetDecimal("V6MINR");
	this.V6PERC = reader.GetDecimal("V6PERC");
	this.V6OLA = reader.GetDecimal("V6OLA");
	this.V6MPQT = reader.GetDecimal("V6MPQT");
	this.V6DPST = reader.GetDecimal("V6DPST");
	this.V6SPDT = reader.GetDateTime("V6SPDT");
	this.V6BBDT = reader.GetDateTime("V6BBDT");
	this.V6ORLT = reader.GetDecimal("V6ORLT");
	this.V6AUTR = reader.GetString("V6AUTR");
	this.V6REPP = reader.GetString("V6REPP");
	this.V6REPT = reader.GetDecimal("V6REPT");
	this.V6SHRK = reader.GetDecimal("V6SHRK");
	this.V6FCFN = reader.GetDecimal("V6FCFN");
	this.V6AUTO = reader.GetDecimal("V6AUTO");
	this.V6OLOK = reader.GetDecimal("V6OLOK");
	this.V6OEPY = reader.GetString("V6OEPY");
	this.V6PRFR = reader.GetString("V6PRFR");
	this.V6CMTL = reader.GetString("V6CMTL");
	this.V6DRWS = reader.GetString("V6DRWS");
	this.V6DRWL = reader.GetString("V6DRWL");
	this.V6DENC = reader.GetString("V6DENC");
	this.V6DREL = reader.GetString("V6DREL");
	this.V6DDAT = reader.GetDateTime("V6DDAT");
	this.V6DRWN = reader.GetString("V6DRWN");
	this.V6DRWS2 = reader.GetString("V6DRWS2");
	this.V6DRWL2 = reader.GetString("V6DRWL2");
	this.V6DENC2 = reader.GetString("V6DENC2");
	this.V6DREL2 = reader.GetString("V6DREL2");
	this.V6DDAT2 = reader.GetDateTime("V6DDAT2");
	this.V6DRWN2 = reader.GetString("V6DRWN2");
	this.V6LOTF = reader.GetString("V6LOTF");
	this.V6SERF = reader.GetString("V6SERF");
	this.V6LOTB = reader.GetString("V6LOTB");
	this.V6LOTA = reader.GetString("V6LOTA");
	this.V6LOTV = reader.GetString("V6LOTV");
	this.V6STCL = reader.GetString("V6STCL");
	this.V6VLCD = reader.GetString("V6VLCD");
	this.V6SPPP = reader.GetDecimal("V6SPPP");
	this.V6SPPC = reader.GetString("V6SPPC");
	this.V6MPPP = reader.GetDecimal("V6MPPP");
	this.V6MPPC = reader.GetString("V6MPPC");
	this.V6FRML = reader.GetString("V6FRML");
	this.V6ISTR = reader.GetString("V6ISTR");
	this.V6ENGC = reader.GetString("V6ENGC");
	this.V6REVL = reader.GetString("V6REVL");
	this.V6RDAT = reader.GetDateTime("V6RDAT");
	this.V6RCVLC = reader.GetString("V6RCVLC");
	this.V6SFLC = reader.GetString("V6SFLC");
	this.V6CUSR = reader.GetString("V6CUSR");
	this.V6CDAT = reader.GetDateTime("V6CDAT");
	this.V6CTME = reader.GetDecimal("V6CTME");
	this.V6UUSR = reader.GetString("V6UUSR");
	this.V6UDAT = reader.GetDateTime("V6UDAT");
	this.V6UTME = reader.GetDecimal("V6UTME");
	this.V6FUT3 = reader.GetString("V6FUT3");
	this.V6FUT4 = reader.GetString("V6FUT4");
	this.V6FUT5 = reader.GetString("V6FUT5");
	this.V6FLG1 = reader.GetString("V6FLG1");
	this.V6FLG2 = reader.GetString("V6FLG2");
	this.V6FLG3 = reader.GetString("V6FLG3");
	this.V6FLG4 = reader.GetString("V6FLG4");
	this.V6FLG5 = reader.GetString("V6FLG5");
	this.V6FLG6 = reader.GetString("V6FLG6");
	this.V6FLG7 = reader.GetString("V6FLG7");
	this.V6FLG8 = reader.GetString("V6FLG8");
	this.V6FLG9 = reader.GetString("V6FLG9");
	this.V6FLG10 = reader.GetString("V6FLG10");
	this.V6FUT6 = reader.GetDecimal("V6FUT6");
	this.V6FUT7 = reader.GetString("V6FUT7");
	this.V6FUT8 = reader.GetString("V6FUT8");
	this.V6FUT9 = reader.GetString("V6FUT9");
	this.V6FUT10 = reader.GetString("V6FUT10");
	this.V6FUT11 = reader.GetString("V6FUT11");
	this.V6FUT12 = reader.GetString("V6FUT12");
	this.V6FUT13 = reader.GetString("V6FUT13");
	this.V6FUT14 = reader.GetString("V6FUT14");
	this.V6FUT15 = reader.GetString("V6FUT15");
	this.V6FUT16 = reader.GetString("V6FUT16");
	this.V6FUT17 = reader.GetString("V6FUT17");
	this.V6FUT18 = reader.GetString("V6FUT18");
	this.V6FUT19 = reader.GetString("V6FUT19");
	this.V6FUT20 = reader.GetString("V6FUT20");
	this.V6FUT21 = reader.GetString("V6FUT21");
	this.V6FUT22 = reader.GetString("V6FUT22");
	this.V6FUT23 = reader.GetString("V6FUT23");
	this.V6FUT24 = reader.GetString("V6FUT24");
	this.V6FUT25 = reader.GetString("V6FUT25");
	this.V6FUT26 = reader.GetDecimal("V6FUT26");
	this.V6FUT27 = reader.GetDecimal("V6FUT27");
	this.V6FUT28 = reader.GetDecimal("V6FUT28");
	this.V6FUT29 = reader.GetDecimal("V6FUT29");
	this.V6FUT30 = reader.GetDecimal("V6FUT30");
	this.V6FUT31 = reader.GetDecimal("V6FUT31");
	this.V6FUT32 = reader.GetDecimal("V6FUT32");
	this.V6FUT33 = reader.GetDecimal("V6FUT33");
	this.V6FUT34 = reader.GetDecimal("V6FUT34");
	this.V6FUT35 = reader.GetDecimal("V6FUT35");
	this.V6FUT36 = reader.GetDateTime("V6FUT36");
	this.V6FUT37 = reader.GetDateTime("V6FUT37");
	this.V6FUT38 = reader.GetDateTime("V6FUT38");
	this.V6FUT39 = reader.GetDateTime("V6FUT39");
	this.V6FUT40 = reader.GetDateTime("V6FUT40");
	this.V6FUT41 = reader.GetDecimal("V6FUT41");
	this.V6FUT42 = reader.GetDecimal("V6FUT42");
	this.V6FUT43 = reader.GetDecimal("V6FUT43");
	this.V6FUT44 = reader.GetDecimal("V6FUT44");
	this.V6FUT45 = reader.GetDecimal("V6FUT45");
	this.V6PRCL = reader.GetString("V6PRCL");
	this.V6DBAC = reader.GetString("V6DBAC");
	this.V6SCDPT = reader.GetString("V6SCDPT");
	this.V6APSUP = reader.GetString("V6APSUP");
	this.V6MATP = reader.GetString("V6MATP");
	this.V6MATM = reader.GetString("V6MATM");
	this.V6MESC = reader.GetString("V6MESC");
	this.V6CRTM = reader.GetString("V6CRTM");
	this.V6LLED = reader.GetDecimal("V6LLED");
	this.V6PCTR = reader.GetString("V6PCTR");
	this.V6INQU = reader.GetString("V6INQU");
	this.V6CLEXP = reader.GetString("V6CLEXP");
}

public override
void write(){    
	string sql = "insert into " + getTablePrefix() + "stka(" + 
		"V6PLNT," +
		"V6PART," +
		"V6UNTI," +
		"V6RPLN," +
		"V6TPLN," +
		"V6TDYS," +
		"V6MRPS," +
		"V6ABCC," +
		"V6CCPY," +
		"V6LCDT," +
		"V6DBCC," +
		"V6ORDQ," +
		"V6OPCY," +
		"V6MULT," +
		"V6FUT1," +
		"V6FUT2," +
		"V6SCDT," +
		"V6PLAN," +
		"V6CNTR," +
		"V6UNTP," +
		"V6LVL," +
		"V6PACK," +
		"V6PACU," +
		"V6PRPT," +
		"V6KITC," +
		"V6PROC," +
		"V6LRSP," +
		"V6LRSC," +
		"V6LRSF," +
		"V6LRMP," +
		"V6LRMC," +
		"V6LRMF," +
		"V6LWSP," +
		"V6LWSC," +
		"V6LWSF," +
		"V6LCSP," +
		"V6LCSC," +
		"V6LCSF," +
		"V6LCMP," +
		"V6LCMC," +
		"V6LCMF," +
		"V6LSSC," +
		"V6LSSF," +
		"V6LSMP," +
		"V6LSMC," +
		"V6LSMF," +
		"V6MPCK," +
		"V6MPKU," +
		"V6ALTF," +
		"V6DBUY," +
		"V6SCDP," +
		"V6SELP," +
		"V6RCPS," +
		"V6RECU," +
		"V6RECC," +
		"V6FTMF," +
		"V6CSMU," +
		"V6NTKY," +
		"V6MINQ," +
		"V6MAXQ," +
		"V6MOQT," +
		"V6ESTV," +
		"V6CORG," +
		"V6PSOR," +
		"V6STAT," +
		"V6REAS," +
		"V6AUTY," +
		"V6UNTO," +
		"V6REQC," +
		"V6BUYR," +
		"V6LEAD," +
		"V6OPTR," +
		"V6MULTP," +
		"V6MINR," +
		"V6PERC," +
		"V6OLA," +
		"V6MPQT," +
		"V6DPST," +
		"V6SPDT," +
		"V6BBDT," +
		"V6ORLT," +
		"V6AUTR," +
		"V6REPP," +
		"V6REPT," +
		"V6SHRK," +
		"V6FCFN," +
		"V6AUTO," +
		"V6OLOK," +
		"V6OEPY," +
		"V6PRFR," +
		"V6CMTL," +
		"V6DRWS," +
		"V6DRWL," +
		"V6DENC," +
		"V6DREL," +
		"V6DDAT," +
		"V6DRWN," +
		"V6DRWS2," +
		"V6DRWL2," +
		"V6DENC2," +
		"V6DREL2," +
		"V6DDAT2," +
		"V6DRWN2," +
		"V6LOTF," +
		"V6SERF," +
		"V6LOTB," +
		"V6LOTA," +
		"V6LOTV," +
		"V6STCL," +
		"V6VLCD," +
		"V6SPPP," +
		"V6SPPC," +
		"V6MPPP," +
		"V6MPPC," +
		"V6FRML," +
		"V6ISTR," +
		"V6ENGC," +
		"V6REVL," +
		"V6RDAT," +
		"V6RCVLC," +
		"V6SFLC," +
		"V6CUSR," +
		"V6CDAT," +
		"V6CTME," +
		"V6UUSR," +
		"V6UDAT," +
		"V6UTME," +
		"V6FUT3," +
		"V6FUT4," +
		"V6FUT5," +
		"V6FLG1," +
		"V6FLG2," +
		"V6FLG3," +
		"V6FLG4," +
		"V6FLG5," +
		"V6FLG6," +
		"V6FLG7," +
		"V6FLG8," +
		"V6FLG9," +
		"V6FLG10," +
		"V6FUT6," +
		"V6FUT7," +
		"V6FUT8," +
		"V6FUT9," +
		"V6FUT10," +
		"V6FUT11," +
		"V6FUT12," +
		"V6FUT13," +
		"V6FUT14," +
		"V6FUT15," +
		"V6FUT16," +
		"V6FUT17," +
		"V6FUT18," +
		"V6FUT19," +
		"V6FUT20," +
		"V6FUT21," +
		"V6FUT22," +
		"V6FUT23," +
		"V6FUT24," +
		"V6FUT25," +
		"V6FUT26," +
		"V6FUT27," +
		"V6FUT28," +
		"V6FUT29," +
		"V6FUT30," +
		"V6FUT31," +
		"V6FUT32," +
		"V6FUT33," +
		"V6FUT34," +
		"V6FUT35," +
		"V6FUT36," +
		"V6FUT37," +
		"V6FUT38," +
		"V6FUT39," +
		"V6FUT40," +
		"V6FUT41," +
		"V6FUT42," +
		"V6FUT43," +
		"V6FUT44," +
		"V6FUT45," +
		"V6PRCL," +
		"V6DBAC," +
		"V6SCDPT," +
		"V6APSUP," +
		"V6MATP," +
		"V6MATM," +
		"V6MESC," +
		"V6CRTM," +
		"V6LLED," +
		"V6PCTR," +
		"V6INQU," +
		"V6CLEXP" +

		") values (" + 

		"'" + Converter.fixString(V6PLNT) + "'," +
		"'" + Converter.fixString(V6PART) + "'," +
		"'" + Converter.fixString(V6UNTI) + "'," +
		"'" + Converter.fixString(V6RPLN) + "'," +
		"'" + Converter.fixString(V6TPLN) + "'," +
		"" + NumberUtil.toString(V6TDYS) + "," +
		"" + NumberUtil.toString(V6MRPS) + "," +
		"'" + Converter.fixString(V6ABCC) + "'," +
		"" + NumberUtil.toString(V6CCPY) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(V6LCDT) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(V6DBCC) + "'," +
		"" + NumberUtil.toString(V6ORDQ) + "," +
		"'" + Converter.fixString(V6OPCY) + "'," +
		"" + NumberUtil.toString(V6MULT) + "," +
		"'" + Converter.fixString(V6FUT1) + "'," +
		"'" + Converter.fixString(V6FUT2) + "'," +
		"'" + Converter.fixString(V6SCDT) + "'," +
		"'" + Converter.fixString(V6PLAN) + "'," +
		"'" + Converter.fixString(V6CNTR) + "'," +
		"'" + Converter.fixString(V6UNTP) + "'," +
		"" + NumberUtil.toString(V6LVL) + "," +
		"" + NumberUtil.toString(V6PACK) + "," +
		"'" + Converter.fixString(V6PACU) + "'," +
		"" + NumberUtil.toString(V6PRPT) + "," +
		"'" + Converter.fixString(V6KITC) + "'," +
		"'" + Converter.fixString(V6PROC) + "'," +
		"'" + Converter.fixString(V6LRSP) + "'," +
		"" + NumberUtil.toString(V6LRSC) + "," +
		"'" + Converter.fixString(V6LRSF) + "'," +
		"'" + Converter.fixString(V6LRMP) + "'," +
		"" + NumberUtil.toString(V6LRMC) + "," +
		"'" + Converter.fixString(V6LRMF) + "'," +
		"'" + Converter.fixString(V6LWSP) + "'," +
		"" + NumberUtil.toString(V6LWSC) + "," +
		"'" + Converter.fixString(V6LWSF) + "'," +
		"'" + Converter.fixString(V6LCSP) + "'," +
		"" + NumberUtil.toString(V6LCSC) + "," +
		"'" + Converter.fixString(V6LCSF) + "'," +
		"'" + Converter.fixString(V6LCMP) + "'," +
		"" + NumberUtil.toString(V6LCMC) + "," +
		"'" + Converter.fixString(V6LCMF) + "'," +
		"" + NumberUtil.toString(V6LSSC) + "," +
		"'" + Converter.fixString(V6LSSF) + "'," +
		"'" + Converter.fixString(V6LSMP) + "'," +
		"" + NumberUtil.toString(V6LSMC) + "," +
		"'" + Converter.fixString(V6LSMF) + "'," +
		"" + NumberUtil.toString(V6MPCK) + "," +
		"'" + Converter.fixString(V6MPKU) + "'," +
		"" + NumberUtil.toString(V6ALTF) + "," +
		"'" + Converter.fixString(V6DBUY) + "'," +
		"" + NumberUtil.toString(V6SCDP) + "," +
		"'" + Converter.fixString(V6SELP) + "'," +
		"" + NumberUtil.toString(V6RCPS) + "," +
		"'" + Converter.fixString(V6RECU) + "'," +
		"'" + Converter.fixString(V6RECC) + "'," +
		"" + NumberUtil.toString(V6FTMF) + "," +
		"'" + Converter.fixString(V6CSMU) + "'," +
		"'" + Converter.fixString(V6NTKY) + "'," +
		"" + NumberUtil.toString(V6MINQ) + "," +
		"" + NumberUtil.toString(V6MAXQ) + "," +
		"" + NumberUtil.toString(V6MOQT) + "," +
		"" + NumberUtil.toString(V6ESTV) + "," +
		"'" + Converter.fixString(V6CORG) + "'," +
		"'" + Converter.fixString(V6PSOR) + "'," +
		"'" + Converter.fixString(V6STAT) + "'," +
		"'" + Converter.fixString(V6REAS) + "'," +
		"'" + Converter.fixString(V6AUTY) + "'," +
		"'" + Converter.fixString(V6UNTO) + "'," +
		"'" + Converter.fixString(V6REQC) + "'," +
		"'" + Converter.fixString(V6BUYR) + "'," +
		"" + NumberUtil.toString(V6LEAD) + "," +
		"" + NumberUtil.toString(V6OPTR) + "," +
		"" + NumberUtil.toString(V6MULTP) + "," +
		"" + NumberUtil.toString(V6MINR) + "," +
		"" + NumberUtil.toString(V6PERC) + "," +
		"" + NumberUtil.toString(V6OLA) + "," +
		"" + NumberUtil.toString(V6MPQT) + "," +
		"" + NumberUtil.toString(V6DPST) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(V6SPDT) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(V6BBDT) + "'," +
		"" + NumberUtil.toString(V6ORLT) + "," +
		"'" + Converter.fixString(V6AUTR) + "'," +
		"'" + Converter.fixString(V6REPP) + "'," +
		"" + NumberUtil.toString(V6REPT) + "," +
		"" + NumberUtil.toString(V6SHRK) + "," +
		"" + NumberUtil.toString(V6FCFN) + "," +
		"" + NumberUtil.toString(V6AUTO) + "," +
		"" + NumberUtil.toString(V6OLOK) + "," +
		"'" + Converter.fixString(V6OEPY) + "'," +
		"'" + Converter.fixString(V6PRFR) + "'," +
		"'" + Converter.fixString(V6CMTL) + "'," +
		"'" + Converter.fixString(V6DRWS) + "'," +
		"'" + Converter.fixString(V6DRWL) + "'," +
		"'" + Converter.fixString(V6DENC) + "'," +
		"'" + Converter.fixString(V6DREL) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(V6DDAT) + "'," +
		"'" + Converter.fixString(V6DRWN) + "'," +
		"'" + Converter.fixString(V6DRWS2) + "'," +
		"'" + Converter.fixString(V6DRWL2) + "'," +
		"'" + Converter.fixString(V6DENC2) + "'," +
		"'" + Converter.fixString(V6DREL2) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(V6DDAT2) + "'," +
		"'" + Converter.fixString(V6DRWN2) + "'," +
		"'" + Converter.fixString(V6LOTF) + "'," +
		"'" + Converter.fixString(V6SERF) + "'," +
		"'" + Converter.fixString(V6LOTB) + "'," +
		"'" + Converter.fixString(V6LOTA) + "'," +
		"'" + Converter.fixString(V6LOTV) + "'," +
		"'" + Converter.fixString(V6STCL) + "'," +
		"'" + Converter.fixString(V6VLCD) + "'," +
		"" + NumberUtil.toString(V6SPPP) + "," +
		"'" + Converter.fixString(V6SPPC) + "'," +
		"" + NumberUtil.toString(V6MPPP) + "," +
		"'" + Converter.fixString(V6MPPC) + "'," +
		"'" + Converter.fixString(V6FRML) + "'," +
		"'" + Converter.fixString(V6ISTR) + "'," +
		"'" + Converter.fixString(V6ENGC) + "'," +
		"'" + Converter.fixString(V6REVL) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(V6RDAT) + "'," +
		"'" + Converter.fixString(V6RCVLC) + "'," +
		"'" + Converter.fixString(V6SFLC) + "'," +
		"'" + Converter.fixString(V6CUSR) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(V6CDAT) + "'," +
		"" + NumberUtil.toString(V6CTME) + "," +
		"'" + Converter.fixString(V6UUSR) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(V6UDAT) + "'," +
		"" + NumberUtil.toString(V6UTME) + "," +
		"'" + Converter.fixString(V6FUT3) + "'," +
		"'" + Converter.fixString(V6FUT4) + "'," +
		"'" + Converter.fixString(V6FUT5) + "'," +
		"'" + Converter.fixString(V6FLG1) + "'," +
		"'" + Converter.fixString(V6FLG2) + "'," +
		"'" + Converter.fixString(V6FLG3) + "'," +
		"'" + Converter.fixString(V6FLG4) + "'," +
		"'" + Converter.fixString(V6FLG5) + "'," +
		"'" + Converter.fixString(V6FLG6) + "'," +
		"'" + Converter.fixString(V6FLG7) + "'," +
		"'" + Converter.fixString(V6FLG8) + "'," +
		"'" + Converter.fixString(V6FLG9) + "'," +
		"'" + Converter.fixString(V6FLG10) + "'," +
		"" + NumberUtil.toString(V6FUT6) + "," +
		"'" + Converter.fixString(V6FUT7) + "'," +
		"'" + Converter.fixString(V6FUT8) + "'," +
		"'" + Converter.fixString(V6FUT9) + "'," +
		"'" + Converter.fixString(V6FUT10) + "'," +
		"'" + Converter.fixString(V6FUT11) + "'," +
		"'" + Converter.fixString(V6FUT12) + "'," +
		"'" + Converter.fixString(V6FUT13) + "'," +
		"'" + Converter.fixString(V6FUT14) + "'," +
		"'" + Converter.fixString(V6FUT15) + "'," +
		"'" + Converter.fixString(V6FUT16) + "'," +
		"'" + Converter.fixString(V6FUT17) + "'," +
		"'" + Converter.fixString(V6FUT18) + "'," +
		"'" + Converter.fixString(V6FUT19) + "'," +
		"'" + Converter.fixString(V6FUT20) + "'," +
		"'" + Converter.fixString(V6FUT21) + "'," +
		"'" + Converter.fixString(V6FUT22) + "'," +
		"'" + Converter.fixString(V6FUT23) + "'," +
		"'" + Converter.fixString(V6FUT24) + "'," +
		"'" + Converter.fixString(V6FUT25) + "'," +
		"" + NumberUtil.toString(V6FUT26) + "," +
		"" + NumberUtil.toString(V6FUT27) + "," +
		"" + NumberUtil.toString(V6FUT28) + "," +
		"" + NumberUtil.toString(V6FUT29) + "," +
		"" + NumberUtil.toString(V6FUT30) + "," +
		"" + NumberUtil.toString(V6FUT31) + "," +
		"" + NumberUtil.toString(V6FUT32) + "," +
		"" + NumberUtil.toString(V6FUT33) + "," +
		"" + NumberUtil.toString(V6FUT34) + "," +
		"" + NumberUtil.toString(V6FUT35) + "," +
		"'" + DateUtil.getCompleteDateRepresentation(V6FUT36) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(V6FUT37) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(V6FUT38) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(V6FUT39) + "'," +
		"'" + DateUtil.getCompleteDateRepresentation(V6FUT40) + "'," +
		"" + NumberUtil.toString(V6FUT41) + "," +
		"" + NumberUtil.toString(V6FUT42) + "," +
		"" + NumberUtil.toString(V6FUT43) + "," +
		"" + NumberUtil.toString(V6FUT44) + "," +
		"" + NumberUtil.toString(V6FUT45) + "," +
		"'" + Converter.fixString(V6PRCL) + "'," +
		"'" + Converter.fixString(V6DBAC) + "'," +
		"'" + Converter.fixString(V6SCDPT) + "'," +
		"'" + Converter.fixString(V6APSUP) + "'," +
		"'" + Converter.fixString(V6MATP) + "'," +
		"'" + Converter.fixString(V6MATM) + "'," +
		"'" + Converter.fixString(V6MESC) + "'," +
		"'" + Converter.fixString(V6CRTM) + "'," +
		"" + NumberUtil.toString(V6LLED) + "," +
		"'" + Converter.fixString(V6PCTR) + "'," +
		"'" + Converter.fixString(V6INQU) + "'," +
		"'" + Converter.fixString(V6CLEXP) + "')";
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
string getWhereCondition(){
	string sqlWhere =
		"V6PLNT = '" + Converter.fixString(V6PLNT) + "' and " +
		"V6PART = '" + Converter.fixString(V6PART) + "'";
	return sqlWhere;
}

public
void setV6PLNT(string V6PLNT){
	this.V6PLNT = V6PLNT;
}

public
void setV6PART(string V6PART){
	this.V6PART = V6PART;
}

public
void setV6UNTI(string V6UNTI){
	this.V6UNTI = V6UNTI;
}

public
void setV6RPLN(string V6RPLN){
	this.V6RPLN = V6RPLN;
}

public
void setV6TPLN(string V6TPLN){
	this.V6TPLN = V6TPLN;
}

public
void setV6TDYS(decimal V6TDYS){
	this.V6TDYS = V6TDYS;
}

public
void setV6MRPS(decimal V6MRPS){
	this.V6MRPS = V6MRPS;
}

public
void setV6ABCC(string V6ABCC){
	this.V6ABCC = V6ABCC;
}

public
void setV6CCPY(decimal V6CCPY){
	this.V6CCPY = V6CCPY;
}

public
void setV6LCDT(DateTime V6LCDT){
	this.V6LCDT = V6LCDT;
}

public
void setV6DBCC(DateTime V6DBCC){
	this.V6DBCC = V6DBCC;
}

public
void setV6ORDQ(decimal V6ORDQ){
	this.V6ORDQ = V6ORDQ;
}

public
void setV6OPCY(string V6OPCY){
	this.V6OPCY = V6OPCY;
}

public
void setV6MULT(decimal V6MULT){
	this.V6MULT = V6MULT;
}

public
void setV6FUT1(string V6FUT1){
	this.V6FUT1 = V6FUT1;
}

public
void setV6FUT2(string V6FUT2){
	this.V6FUT2 = V6FUT2;
}

public
void setV6SCDT(string V6SCDT){
	this.V6SCDT = V6SCDT;
}

public
void setV6PLAN(string V6PLAN){
	this.V6PLAN = V6PLAN;
}

public
void setV6CNTR(string V6CNTR){
	this.V6CNTR = V6CNTR;
}

public
void setV6UNTP(string V6UNTP){
	this.V6UNTP = V6UNTP;
}

public
void setV6LVL(decimal V6LVL){
	this.V6LVL = V6LVL;
}

public
void setV6PACK(decimal V6PACK){
	this.V6PACK = V6PACK;
}

public
void setV6PACU(string V6PACU){
	this.V6PACU = V6PACU;
}

public
void setV6PRPT(decimal V6PRPT){
	this.V6PRPT = V6PRPT;
}

public
void setV6KITC(string V6KITC){
	this.V6KITC = V6KITC;
}

public
void setV6PROC(string V6PROC){
	this.V6PROC = V6PROC;
}

public
void setV6LRSP(string V6LRSP){
	this.V6LRSP = V6LRSP;
}

public
void setV6LRSC(decimal V6LRSC){
	this.V6LRSC = V6LRSC;
}

public
void setV6LRSF(string V6LRSF){
	this.V6LRSF = V6LRSF;
}

public
void setV6LRMP(string V6LRMP){
	this.V6LRMP = V6LRMP;
}

public
void setV6LRMC(decimal V6LRMC){
	this.V6LRMC = V6LRMC;
}

public
void setV6LRMF(string V6LRMF){
	this.V6LRMF = V6LRMF;
}

public
void setV6LWSP(string V6LWSP){
	this.V6LWSP = V6LWSP;
}

public
void setV6LWSC(decimal V6LWSC){
	this.V6LWSC = V6LWSC;
}

public
void setV6LWSF(string V6LWSF){
	this.V6LWSF = V6LWSF;
}

public
void setV6LCSP(string V6LCSP){
	this.V6LCSP = V6LCSP;
}

public
void setV6LCSC(decimal V6LCSC){
	this.V6LCSC = V6LCSC;
}

public
void setV6LCSF(string V6LCSF){
	this.V6LCSF = V6LCSF;
}

public
void setV6LCMP(string V6LCMP){
	this.V6LCMP = V6LCMP;
}

public
void setV6LCMC(decimal V6LCMC){
	this.V6LCMC = V6LCMC;
}

public
void setV6LCMF(string V6LCMF){
	this.V6LCMF = V6LCMF;
}

public
void setV6LSSC(decimal V6LSSC){
	this.V6LSSC = V6LSSC;
}

public
void setV6LSSF(string V6LSSF){
	this.V6LSSF = V6LSSF;
}

public
void setV6LSMP(string V6LSMP){
	this.V6LSMP = V6LSMP;
}

public
void setV6LSMC(decimal V6LSMC){
	this.V6LSMC = V6LSMC;
}

public
void setV6LSMF(string V6LSMF){
	this.V6LSMF = V6LSMF;
}

public
void setV6MPCK(decimal V6MPCK){
	this.V6MPCK = V6MPCK;
}

public
void setV6MPKU(string V6MPKU){
	this.V6MPKU = V6MPKU;
}

public
void setV6ALTF(decimal V6ALTF){
	this.V6ALTF = V6ALTF;
}

public
void setV6DBUY(string V6DBUY){
	this.V6DBUY = V6DBUY;
}

public
void setV6SCDP(decimal V6SCDP){
	this.V6SCDP = V6SCDP;
}

public
void setV6SELP(string V6SELP){
	this.V6SELP = V6SELP;
}

public
void setV6RCPS(decimal V6RCPS){
	this.V6RCPS = V6RCPS;
}

public
void setV6RECU(string V6RECU){
	this.V6RECU = V6RECU;
}

public
void setV6RECC(string V6RECC){
	this.V6RECC = V6RECC;
}

public
void setV6FTMF(decimal V6FTMF){
	this.V6FTMF = V6FTMF;
}

public
void setV6CSMU(string V6CSMU){
	this.V6CSMU = V6CSMU;
}

public
void setV6NTKY(string V6NTKY){
	this.V6NTKY = V6NTKY;
}

public
void setV6MINQ(decimal V6MINQ){
	this.V6MINQ = V6MINQ;
}

public
void setV6MAXQ(decimal V6MAXQ){
	this.V6MAXQ = V6MAXQ;
}

public
void setV6MOQT(decimal V6MOQT){
	this.V6MOQT = V6MOQT;
}

public
void setV6ESTV(decimal V6ESTV){
	this.V6ESTV = V6ESTV;
}

public
void setV6CORG(string V6CORG){
	this.V6CORG = V6CORG;
}

public
void setV6PSOR(string V6PSOR){
	this.V6PSOR = V6PSOR;
}

public
void setV6STAT(string V6STAT){
	this.V6STAT = V6STAT;
}

public
void setV6REAS(string V6REAS){
	this.V6REAS = V6REAS;
}

public
void setV6AUTY(string V6AUTY){
	this.V6AUTY = V6AUTY;
}

public
void setV6UNTO(string V6UNTO){
	this.V6UNTO = V6UNTO;
}

public
void setV6REQC(string V6REQC){
	this.V6REQC = V6REQC;
}

public
void setV6BUYR(string V6BUYR){
	this.V6BUYR = V6BUYR;
}

public
void setV6LEAD(decimal V6LEAD){
	this.V6LEAD = V6LEAD;
}

public
void setV6OPTR(decimal V6OPTR){
	this.V6OPTR = V6OPTR;
}

public
void setV6MULTP(decimal V6MULTP){
	this.V6MULTP = V6MULTP;
}

public
void setV6MINR(decimal V6MINR){
	this.V6MINR = V6MINR;
}

public
void setV6PERC(decimal V6PERC){
	this.V6PERC = V6PERC;
}

public
void setV6OLA(decimal V6OLA){
	this.V6OLA = V6OLA;
}

public
void setV6MPQT(decimal V6MPQT){
	this.V6MPQT = V6MPQT;
}

public
void setV6DPST(decimal V6DPST){
	this.V6DPST = V6DPST;
}

public
void setV6SPDT(DateTime V6SPDT){
	this.V6SPDT = V6SPDT;
}

public
void setV6BBDT(DateTime V6BBDT){
	this.V6BBDT = V6BBDT;
}

public
void setV6ORLT(decimal V6ORLT){
	this.V6ORLT = V6ORLT;
}

public
void setV6AUTR(string V6AUTR){
	this.V6AUTR = V6AUTR;
}

public
void setV6REPP(string V6REPP){
	this.V6REPP = V6REPP;
}

public
void setV6REPT(decimal V6REPT){
	this.V6REPT = V6REPT;
}

public
void setV6SHRK(decimal V6SHRK){
	this.V6SHRK = V6SHRK;
}

public
void setV6FCFN(decimal V6FCFN){
	this.V6FCFN = V6FCFN;
}

public
void setV6AUTO(decimal V6AUTO){
	this.V6AUTO = V6AUTO;
}

public
void setV6OLOK(decimal V6OLOK){
	this.V6OLOK = V6OLOK;
}

public
void setV6OEPY(string V6OEPY){
	this.V6OEPY = V6OEPY;
}

public
void setV6PRFR(string V6PRFR){
	this.V6PRFR = V6PRFR;
}

public
void setV6CMTL(string V6CMTL){
	this.V6CMTL = V6CMTL;
}

public
void setV6DRWS(string V6DRWS){
	this.V6DRWS = V6DRWS;
}

public
void setV6DRWL(string V6DRWL){
	this.V6DRWL = V6DRWL;
}

public
void setV6DENC(string V6DENC){
	this.V6DENC = V6DENC;
}

public
void setV6DREL(string V6DREL){
	this.V6DREL = V6DREL;
}

public
void setV6DDAT(DateTime V6DDAT){
	this.V6DDAT = V6DDAT;
}

public
void setV6DRWN(string V6DRWN){
	this.V6DRWN = V6DRWN;
}

public
void setV6DRWS2(string V6DRWS2){
	this.V6DRWS2 = V6DRWS2;
}

public
void setV6DRWL2(string V6DRWL2){
	this.V6DRWL2 = V6DRWL2;
}

public
void setV6DENC2(string V6DENC2){
	this.V6DENC2 = V6DENC2;
}

public
void setV6DREL2(string V6DREL2){
	this.V6DREL2 = V6DREL2;
}

public
void setV6DDAT2(DateTime V6DDAT2){
	this.V6DDAT2 = V6DDAT2;
}

public
void setV6DRWN2(string V6DRWN2){
	this.V6DRWN2 = V6DRWN2;
}

public
void setV6LOTF(string V6LOTF){
	this.V6LOTF = V6LOTF;
}

public
void setV6SERF(string V6SERF){
	this.V6SERF = V6SERF;
}

public
void setV6LOTB(string V6LOTB){
	this.V6LOTB = V6LOTB;
}

public
void setV6LOTA(string V6LOTA){
	this.V6LOTA = V6LOTA;
}

public
void setV6LOTV(string V6LOTV){
	this.V6LOTV = V6LOTV;
}

public
void setV6STCL(string V6STCL){
	this.V6STCL = V6STCL;
}

public
void setV6VLCD(string V6VLCD){
	this.V6VLCD = V6VLCD;
}

public
void setV6SPPP(decimal V6SPPP){
	this.V6SPPP = V6SPPP;
}

public
void setV6SPPC(string V6SPPC){
	this.V6SPPC = V6SPPC;
}

public
void setV6MPPP(decimal V6MPPP){
	this.V6MPPP = V6MPPP;
}

public
void setV6MPPC(string V6MPPC){
	this.V6MPPC = V6MPPC;
}

public
void setV6FRML(string V6FRML){
	this.V6FRML = V6FRML;
}

public
void setV6ISTR(string V6ISTR){
	this.V6ISTR = V6ISTR;
}

public
void setV6ENGC(string V6ENGC){
	this.V6ENGC = V6ENGC;
}

public
void setV6REVL(string V6REVL){
	this.V6REVL = V6REVL;
}

public
void setV6RDAT(DateTime V6RDAT){
	this.V6RDAT = V6RDAT;
}

public
void setV6RCVLC(string V6RCVLC){
	this.V6RCVLC = V6RCVLC;
}

public
void setV6SFLC(string V6SFLC){
	this.V6SFLC = V6SFLC;
}

public
void setV6CUSR(string V6CUSR){
	this.V6CUSR = V6CUSR;
}

public
void setV6CDAT(DateTime V6CDAT){
	this.V6CDAT = V6CDAT;
}

public
void setV6CTME(decimal V6CTME){
	this.V6CTME = V6CTME;
}

public
void setV6UUSR(string V6UUSR){
	this.V6UUSR = V6UUSR;
}

public
void setV6UDAT(DateTime V6UDAT){
	this.V6UDAT = V6UDAT;
}

public
void setV6UTME(decimal V6UTME){
	this.V6UTME = V6UTME;
}

public
void setV6FUT3(string V6FUT3){
	this.V6FUT3 = V6FUT3;
}

public
void setV6FUT4(string V6FUT4){
	this.V6FUT4 = V6FUT4;
}

public
void setV6FUT5(string V6FUT5){
	this.V6FUT5 = V6FUT5;
}

public
void setV6FLG1(string V6FLG1){
	this.V6FLG1 = V6FLG1;
}

public
void setV6FLG2(string V6FLG2){
	this.V6FLG2 = V6FLG2;
}

public
void setV6FLG3(string V6FLG3){
	this.V6FLG3 = V6FLG3;
}

public
void setV6FLG4(string V6FLG4){
	this.V6FLG4 = V6FLG4;
}

public
void setV6FLG5(string V6FLG5){
	this.V6FLG5 = V6FLG5;
}

public
void setV6FLG6(string V6FLG6){
	this.V6FLG6 = V6FLG6;
}

public
void setV6FLG7(string V6FLG7){
	this.V6FLG7 = V6FLG7;
}

public
void setV6FLG8(string V6FLG8){
	this.V6FLG8 = V6FLG8;
}

public
void setV6FLG9(string V6FLG9){
	this.V6FLG9 = V6FLG9;
}

public
void setV6FLG10(string V6FLG10){
	this.V6FLG10 = V6FLG10;
}

public
void setV6FUT6(decimal V6FUT6){
	this.V6FUT6 = V6FUT6;
}

public
void setV6FUT7(string V6FUT7){
	this.V6FUT7 = V6FUT7;
}

public
void setV6FUT8(string V6FUT8){
	this.V6FUT8 = V6FUT8;
}

public
void setV6FUT9(string V6FUT9){
	this.V6FUT9 = V6FUT9;
}

public
void setV6FUT10(string V6FUT10){
	this.V6FUT10 = V6FUT10;
}

public
void setV6FUT11(string V6FUT11){
	this.V6FUT11 = V6FUT11;
}

public
void setV6FUT12(string V6FUT12){
	this.V6FUT12 = V6FUT12;
}

public
void setV6FUT13(string V6FUT13){
	this.V6FUT13 = V6FUT13;
}

public
void setV6FUT14(string V6FUT14){
	this.V6FUT14 = V6FUT14;
}

public
void setV6FUT15(string V6FUT15){
	this.V6FUT15 = V6FUT15;
}

public
void setV6FUT16(string V6FUT16){
	this.V6FUT16 = V6FUT16;
}

public
void setV6FUT17(string V6FUT17){
	this.V6FUT17 = V6FUT17;
}

public
void setV6FUT18(string V6FUT18){
	this.V6FUT18 = V6FUT18;
}

public
void setV6FUT19(string V6FUT19){
	this.V6FUT19 = V6FUT19;
}

public
void setV6FUT20(string V6FUT20){
	this.V6FUT20 = V6FUT20;
}

public
void setV6FUT21(string V6FUT21){
	this.V6FUT21 = V6FUT21;
}

public
void setV6FUT22(string V6FUT22){
	this.V6FUT22 = V6FUT22;
}

public
void setV6FUT23(string V6FUT23){
	this.V6FUT23 = V6FUT23;
}

public
void setV6FUT24(string V6FUT24){
	this.V6FUT24 = V6FUT24;
}

public
void setV6FUT25(string V6FUT25){
	this.V6FUT25 = V6FUT25;
}

public
void setV6FUT26(decimal V6FUT26){
	this.V6FUT26 = V6FUT26;
}

public
void setV6FUT27(decimal V6FUT27){
	this.V6FUT27 = V6FUT27;
}

public
void setV6FUT28(decimal V6FUT28){
	this.V6FUT28 = V6FUT28;
}

public
void setV6FUT29(decimal V6FUT29){
	this.V6FUT29 = V6FUT29;
}

public
void setV6FUT30(decimal V6FUT30){
	this.V6FUT30 = V6FUT30;
}

public
void setV6FUT31(decimal V6FUT31){
	this.V6FUT31 = V6FUT31;
}

public
void setV6FUT32(decimal V6FUT32){
	this.V6FUT32 = V6FUT32;
}

public
void setV6FUT33(decimal V6FUT33){
	this.V6FUT33 = V6FUT33;
}

public
void setV6FUT34(decimal V6FUT34){
	this.V6FUT34 = V6FUT34;
}

public
void setV6FUT35(decimal V6FUT35){
	this.V6FUT35 = V6FUT35;
}

public
void setV6FUT36(DateTime V6FUT36){
	this.V6FUT36 = V6FUT36;
}

public
void setV6FUT37(DateTime V6FUT37){
	this.V6FUT37 = V6FUT37;
}

public
void setV6FUT38(DateTime V6FUT38){
	this.V6FUT38 = V6FUT38;
}

public
void setV6FUT39(DateTime V6FUT39){
	this.V6FUT39 = V6FUT39;
}

public
void setV6FUT40(DateTime V6FUT40){
	this.V6FUT40 = V6FUT40;
}

public
void setV6FUT41(decimal V6FUT41){
	this.V6FUT41 = V6FUT41;
}

public
void setV6FUT42(decimal V6FUT42){
	this.V6FUT42 = V6FUT42;
}

public
void setV6FUT43(decimal V6FUT43){
	this.V6FUT43 = V6FUT43;
}

public
void setV6FUT44(decimal V6FUT44){
	this.V6FUT44 = V6FUT44;
}

public
void setV6FUT45(decimal V6FUT45){
	this.V6FUT45 = V6FUT45;
}

public
void setV6PRCL(string V6PRCL){
	this.V6PRCL = V6PRCL;
}

public
void setV6DBAC(string V6DBAC){
	this.V6DBAC = V6DBAC;
}

public
void setV6SCDPT(string V6SCDPT){
	this.V6SCDPT = V6SCDPT;
}

public
void setV6APSUP(string V6APSUP){
	this.V6APSUP = V6APSUP;
}

public
void setV6MATP(string V6MATP){
	this.V6MATP = V6MATP;
}

public
void setV6MATM(string V6MATM){
	this.V6MATM = V6MATM;
}

public
void setV6MESC(string V6MESC){
	this.V6MESC = V6MESC;
}

public
void setV6CRTM(string V6CRTM){
	this.V6CRTM = V6CRTM;
}

public
void setV6LLED(decimal V6LLED){
	this.V6LLED = V6LLED;
}

public
void setV6PCTR(string V6PCTR){
	this.V6PCTR = V6PCTR;
}

public
void setV6INQU(string V6INQU){
	this.V6INQU = V6INQU;
}

public
void setV6CLEXP(string V6CLEXP){
	this.V6CLEXP = V6CLEXP;
}

public
string getV6PLNT(){
	return V6PLNT;
}

public
string getV6PART(){
	return V6PART;
}

public
string getV6UNTI(){
	return V6UNTI;
}

public
string getV6RPLN(){
	return V6RPLN;
}

public
string getV6TPLN(){
	return V6TPLN;
}

public
decimal getV6TDYS(){
	return V6TDYS;
}

public
decimal getV6MRPS(){
	return V6MRPS;
}

public
string getV6ABCC(){
	return V6ABCC;
}

public
decimal getV6CCPY(){
	return V6CCPY;
}

public
DateTime getV6LCDT(){
	return V6LCDT;
}

public
DateTime getV6DBCC(){
	return V6DBCC;
}

public
decimal getV6ORDQ(){
	return V6ORDQ;
}

public
string getV6OPCY(){
	return V6OPCY;
}

public
decimal getV6MULT(){
	return V6MULT;
}

public
string getV6FUT1(){
	return V6FUT1;
}

public
string getV6FUT2(){
	return V6FUT2;
}

public
string getV6SCDT(){
	return V6SCDT;
}

public
string getV6PLAN(){
	return V6PLAN;
}

public
string getV6CNTR(){
	return V6CNTR;
}

public
string getV6UNTP(){
	return V6UNTP;
}

public
decimal getV6LVL(){
	return V6LVL;
}

public
decimal getV6PACK(){
	return V6PACK;
}

public
string getV6PACU(){
	return V6PACU;
}

public
decimal getV6PRPT(){
	return V6PRPT;
}

public
string getV6KITC(){
	return V6KITC;
}

public
string getV6PROC(){
	return V6PROC;
}

public
string getV6LRSP(){
	return V6LRSP;
}

public
decimal getV6LRSC(){
	return V6LRSC;
}

public
string getV6LRSF(){
	return V6LRSF;
}

public
string getV6LRMP(){
	return V6LRMP;
}

public
decimal getV6LRMC(){
	return V6LRMC;
}

public
string getV6LRMF(){
	return V6LRMF;
}

public
string getV6LWSP(){
	return V6LWSP;
}

public
decimal getV6LWSC(){
	return V6LWSC;
}

public
string getV6LWSF(){
	return V6LWSF;
}

public
string getV6LCSP(){
	return V6LCSP;
}

public
decimal getV6LCSC(){
	return V6LCSC;
}

public
string getV6LCSF(){
	return V6LCSF;
}

public
string getV6LCMP(){
	return V6LCMP;
}

public
decimal getV6LCMC(){
	return V6LCMC;
}

public
string getV6LCMF(){
	return V6LCMF;
}

public
decimal getV6LSSC(){
	return V6LSSC;
}

public
string getV6LSSF(){
	return V6LSSF;
}

public
string getV6LSMP(){
	return V6LSMP;
}

public
decimal getV6LSMC(){
	return V6LSMC;
}

public
string getV6LSMF(){
	return V6LSMF;
}

public
decimal getV6MPCK(){
	return V6MPCK;
}

public
string getV6MPKU(){
	return V6MPKU;
}

public
decimal getV6ALTF(){
	return V6ALTF;
}

public
string getV6DBUY(){
	return V6DBUY;
}

public
decimal getV6SCDP(){
	return V6SCDP;
}

public
string getV6SELP(){
	return V6SELP;
}

public
decimal getV6RCPS(){
	return V6RCPS;
}

public
string getV6RECU(){
	return V6RECU;
}

public
string getV6RECC(){
	return V6RECC;
}

public
decimal getV6FTMF(){
	return V6FTMF;
}

public
string getV6CSMU(){
	return V6CSMU;
}

public
string getV6NTKY(){
	return V6NTKY;
}

public
decimal getV6MINQ(){
	return V6MINQ;
}

public
decimal getV6MAXQ(){
	return V6MAXQ;
}

public
decimal getV6MOQT(){
	return V6MOQT;
}

public
decimal getV6ESTV(){
	return V6ESTV;
}

public
string getV6CORG(){
	return V6CORG;
}

public
string getV6PSOR(){
	return V6PSOR;
}

public
string getV6STAT(){
	return V6STAT;
}

public
string getV6REAS(){
	return V6REAS;
}

public
string getV6AUTY(){
	return V6AUTY;
}

public
string getV6UNTO(){
	return V6UNTO;
}

public
string getV6REQC(){
	return V6REQC;
}

public
string getV6BUYR(){
	return V6BUYR;
}

public
decimal getV6LEAD(){
	return V6LEAD;
}

public
decimal getV6OPTR(){
	return V6OPTR;
}

public
decimal getV6MULTP(){
	return V6MULTP;
}

public
decimal getV6MINR(){
	return V6MINR;
}

public
decimal getV6PERC(){
	return V6PERC;
}

public
decimal getV6OLA(){
	return V6OLA;
}

public
decimal getV6MPQT(){
	return V6MPQT;
}

public
decimal getV6DPST(){
	return V6DPST;
}

public
DateTime getV6SPDT(){
	return V6SPDT;
}

public
DateTime getV6BBDT(){
	return V6BBDT;
}

public
decimal getV6ORLT(){
	return V6ORLT;
}

public
string getV6AUTR(){
	return V6AUTR;
}

public
string getV6REPP(){
	return V6REPP;
}

public
decimal getV6REPT(){
	return V6REPT;
}

public
decimal getV6SHRK(){
	return V6SHRK;
}

public
decimal getV6FCFN(){
	return V6FCFN;
}

public
decimal getV6AUTO(){
	return V6AUTO;
}

public
decimal getV6OLOK(){
	return V6OLOK;
}

public
string getV6OEPY(){
	return V6OEPY;
}

public
string getV6PRFR(){
	return V6PRFR;
}

public
string getV6CMTL(){
	return V6CMTL;
}

public
string getV6DRWS(){
	return V6DRWS;
}

public
string getV6DRWL(){
	return V6DRWL;
}

public
string getV6DENC(){
	return V6DENC;
}

public
string getV6DREL(){
	return V6DREL;
}

public
DateTime getV6DDAT(){
	return V6DDAT;
}

public
string getV6DRWN(){
	return V6DRWN;
}

public
string getV6DRWS2(){
	return V6DRWS2;
}

public
string getV6DRWL2(){
	return V6DRWL2;
}

public
string getV6DENC2(){
	return V6DENC2;
}

public
string getV6DREL2(){
	return V6DREL2;
}

public
DateTime getV6DDAT2(){
	return V6DDAT2;
}

public
string getV6DRWN2(){
	return V6DRWN2;
}

public
string getV6LOTF(){
	return V6LOTF;
}

public
string getV6SERF(){
	return V6SERF;
}

public
string getV6LOTB(){
	return V6LOTB;
}

public
string getV6LOTA(){
	return V6LOTA;
}

public
string getV6LOTV(){
	return V6LOTV;
}

public
string getV6STCL(){
	return V6STCL;
}

public
string getV6VLCD(){
	return V6VLCD;
}

public
decimal getV6SPPP(){
	return V6SPPP;
}

public
string getV6SPPC(){
	return V6SPPC;
}

public
decimal getV6MPPP(){
	return V6MPPP;
}

public
string getV6MPPC(){
	return V6MPPC;
}

public
string getV6FRML(){
	return V6FRML;
}

public
string getV6ISTR(){
	return V6ISTR;
}

public
string getV6ENGC(){
	return V6ENGC;
}

public
string getV6REVL(){
	return V6REVL;
}

public
DateTime getV6RDAT(){
	return V6RDAT;
}

public
string getV6RCVLC(){
	return V6RCVLC;
}

public
string getV6SFLC(){
	return V6SFLC;
}

public
string getV6CUSR(){
	return V6CUSR;
}

public
DateTime getV6CDAT(){
	return V6CDAT;
}

public
decimal getV6CTME(){
	return V6CTME;
}

public
string getV6UUSR(){
	return V6UUSR;
}

public
DateTime getV6UDAT(){
	return V6UDAT;
}

public
decimal getV6UTME(){
	return V6UTME;
}

public
string getV6FUT3(){
	return V6FUT3;
}

public
string getV6FUT4(){
	return V6FUT4;
}

public
string getV6FUT5(){
	return V6FUT5;
}

public
string getV6FLG1(){
	return V6FLG1;
}

public
string getV6FLG2(){
	return V6FLG2;
}

public
string getV6FLG3(){
	return V6FLG3;
}

public
string getV6FLG4(){
	return V6FLG4;
}

public
string getV6FLG5(){
	return V6FLG5;
}

public
string getV6FLG6(){
	return V6FLG6;
}

public
string getV6FLG7(){
	return V6FLG7;
}

public
string getV6FLG8(){
	return V6FLG8;
}

public
string getV6FLG9(){
	return V6FLG9;
}

public
string getV6FLG10(){
	return V6FLG10;
}

public
decimal getV6FUT6(){
	return V6FUT6;
}

public
string getV6FUT7(){
	return V6FUT7;
}

public
string getV6FUT8(){
	return V6FUT8;
}

public
string getV6FUT9(){
	return V6FUT9;
}

public
string getV6FUT10(){
	return V6FUT10;
}

public
string getV6FUT11(){
	return V6FUT11;
}

public
string getV6FUT12(){
	return V6FUT12;
}

public
string getV6FUT13(){
	return V6FUT13;
}

public
string getV6FUT14(){
	return V6FUT14;
}

public
string getV6FUT15(){
	return V6FUT15;
}

public
string getV6FUT16(){
	return V6FUT16;
}

public
string getV6FUT17(){
	return V6FUT17;
}

public
string getV6FUT18(){
	return V6FUT18;
}

public
string getV6FUT19(){
	return V6FUT19;
}

public
string getV6FUT20(){
	return V6FUT20;
}

public
string getV6FUT21(){
	return V6FUT21;
}

public
string getV6FUT22(){
	return V6FUT22;
}

public
string getV6FUT23(){
	return V6FUT23;
}

public
string getV6FUT24(){
	return V6FUT24;
}

public
string getV6FUT25(){
	return V6FUT25;
}

public
decimal getV6FUT26(){
	return V6FUT26;
}

public
decimal getV6FUT27(){
	return V6FUT27;
}

public
decimal getV6FUT28(){
	return V6FUT28;
}

public
decimal getV6FUT29(){
	return V6FUT29;
}

public
decimal getV6FUT30(){
	return V6FUT30;
}

public
decimal getV6FUT31(){
	return V6FUT31;
}

public
decimal getV6FUT32(){
	return V6FUT32;
}

public
decimal getV6FUT33(){
	return V6FUT33;
}

public
decimal getV6FUT34(){
	return V6FUT34;
}

public
decimal getV6FUT35(){
	return V6FUT35;
}

public
DateTime getV6FUT36(){
	return V6FUT36;
}

public
DateTime getV6FUT37(){
	return V6FUT37;
}

public
DateTime getV6FUT38(){
	return V6FUT38;
}

public
DateTime getV6FUT39(){
	return V6FUT39;
}

public
DateTime getV6FUT40(){
	return V6FUT40;
}

public
decimal getV6FUT41(){
	return V6FUT41;
}

public
decimal getV6FUT42(){
	return V6FUT42;
}

public
decimal getV6FUT43(){
	return V6FUT43;
}

public
decimal getV6FUT44(){
	return V6FUT44;
}

public
decimal getV6FUT45(){
	return V6FUT45;
}

public
string getV6PRCL(){
	return V6PRCL;
}

public
string getV6DBAC(){
	return V6DBAC;
}

public
string getV6SCDPT(){
	return V6SCDPT;
}

public
string getV6APSUP(){
	return V6APSUP;
}

public
string getV6MATP(){
	return V6MATP;
}

public
string getV6MATM(){
	return V6MATM;
}

public
string getV6MESC(){
	return V6MESC;
}

public
string getV6CRTM(){
	return V6CRTM;
}

public
decimal getV6LLED(){
	return V6LLED;
}

public
string getV6PCTR(){
	return V6PCTR;
}

public
string getV6INQU(){
	return V6INQU;
}

public
string getV6CLEXP(){
	return V6CLEXP;
}

} // class
} // package