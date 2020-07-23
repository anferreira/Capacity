using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class StkMMDataBase : GenericDataBaseElement{

private string AVPART;
private string AVDISC;
private decimal AVLEAD;
private string AVSCDT;
private string AVMAJG;
private string AVMING;
private string AVDES1;
private string AVDES2;
private string AVUNTI;
private string AVBK01;
private string AVTYPE;
private decimal AVTOTP;
private decimal AVSHRK;
private string AVBILL;
private string AVTAXR;
private decimal AVOPTR;
private decimal AVMULT;
private decimal AVQTYP;
private decimal AVQTYA;
private decimal AVQTYH;
private decimal AVMINQ;
private decimal AVMAXQ;
private decimal AVYTDU;
private decimal AVYTD1;
private decimal AVYTD2;
private string AVCUST;
private string AVCORG;
private string AVPLAN;
private string AVCPT;
private string AVREV;
private decimal AVPRUN;
private string AVGLED;
private string AVENGC;
private decimal AVESTV;
private string AVGLCD;
private string AVFEDC;
private string AVMAJS;
private string AVMINS;
private DateTime AVLDAT;
private decimal AVMINR;
private decimal AVOQTY;
private string AVCNTR;
private string AVBK04;
private string AVREVL;
private DateTime AVRDAT;
private decimal AVNWHT;
private string AVDES3;
private string AVHARM;
private string AVBK06;
private string AVOLDD;
private string AVDRWS;
private string AVDRWL;
private string AVUNTP;
private decimal AVLVL;
private decimal AVMOQT;
private decimal AVQTPO;
private decimal AVPACK;
private string AVPACU;
private decimal AVPRPT;
private string AVNWUN;
private decimal AVSVOL;
private string AVSVUN;
private string AVKITC;
private string AVUPCC;
private string AVABCC;
private string AVCLSS;
private string AVSTAT;
private string AVINVT;
private string AVLOTF;
private string AVSERF;
private string AVPROC;
private string AVCOIL;
private string AVMSPC;
private string AVLRSP;
private decimal AVLRSC;
private string AVLRSF;
private string AVLRMP;
private decimal AVLRMC;
private string AVLRMF;
private string AVLWSP;
private decimal AVLWSC;
private string AVLWSF;
private string AVLCSP;
private decimal AVLCSC;
private string AVLCSF;
private string AVLCMP;
private decimal AVLCMC;
private string AVLCMF;
private decimal AVLSSC;
private string AVLSSF;
private string AVLSMP;
private decimal AVLSMC;
private string AVLSMF;
private decimal AVMPCK;
private string AVMPKU;
private string AVORIG;
private decimal AVALTF;
private string AVUVER;
private string AVCATA;
private DateTime AVCDAT;
private decimal AVPERC;
private string AVDBUY;
private decimal AVSLIF;
private string AVREAS;
private string AVFUT1;
private string AVFUT2;
private string AVFUT3;
private string AVFUT4;
private string AVFUT5;
private decimal AVFUT6;
private string AVFUT7;
private string AVFUT8;
private string AVFUT9;
private string AVFUTA;
private string AVFUTB;
//--------------------add in 5.2
private string AVFUTC;
private string AVFUTD;
private decimal AVGTIN;
private string AVDPLT;
private string AVFUTK;
private string AVFUTN;
private string AVPPAP;
private string AVCUSR;
private DateTime AVCTME;
private string AVUUSR;
private DateTime AVUDAT;
private DateTime AVUTME;
private string AVSIZC;
private string AVSTLC;
private string AVCOLC;
private string AVASSC;
private string AVSASC;
private string AVLCOIL;
private string AVGDFL;
private string AVVDFL; 
private string AVWOQF;
private string AVNMFC;
private decimal AVFUTH;
private decimal AVFUTI;
private string AVFUTL;
private string AVFUTM;
private string AVFUTP;
private DateTime AVFUTQ;
private DateTime AVFUTR;
private string AVOLDD2;
private decimal AVFUTG;
private string AVRECU;
private decimal AVFTMF;
private string AVRECC;
private string AVFUTJ;
private DateTime AVSPDT;
private DateTime AVBBDT;
private string AVPSOR;
private string AVFUTO;
private string AVDENC;
private string AVDREL;
private DateTime AVDDAT;
private string AVFUTE;
private string AVDRWS2;
private string AVDRWL2;
private string AVDENC2;
private string AVDREL2;
private DateTime AVDDAT2;
private string AVFUTF;
private string AVSTCL;
private string AVVLCD;
private decimal AVSPPP;
private string AVSPPC;
private decimal AVMPPP;
private string AVMPPC;
private string AVFLG01;
private string AVFLG02;
private string AVFLG03;
private string AVFLG04;
private string AVFLG05;
private string AVFLG06;
private string AVFLG07;
private string AVFLG08;
private string AVFLG09;
private string AVFLG10;
private string AVFUT01;
private string AVFUT02;
private string AVFUT03;
private string AVFUT04;
private string AVFUT05;
private string AVFUT06;
private string AVFUT07;
private string AVFUT08;
private string AVFUT09;
private string AVFUT10;
private string AVFUT11;
private string AVFUT12;
private string AVFUT13;
private string AVFUT14;
private string AVFUT15;
private string AVFUT16;
private string AVFUT17;
private string AVFUT18;
private string AVFUT19;
private string AVFUT20;
private string AVFUT21;
private string AVFUT22;
private string AVFUT23;
private string AVFUT24;
private string AVFUT25;
private decimal AVFUT26;
private decimal AVFUT27;
private decimal AVFUT28;
private decimal AVFUT29;
private decimal AVFUT30;
private decimal AVFUT31; 
private decimal AVFUT32; 
private decimal AVFUT33; 
private decimal AVFUT34; 
private decimal AVFUT35; 
private DateTime AVFUT36;
private DateTime AVFUT37;
private DateTime AVFUT38;
private DateTime AVFUT39;
private DateTime AVFUT40;
private DateTime AVFUT41;
private DateTime AVFUT42;
private DateTime AVFUT43;
private DateTime AVFUT44;
private DateTime AVFUT45;
private string AVUDFT;
private string AVFRML;	
//--------------------

public
StkMMDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	this.AVPART = reader.GetString("AVPART");
	this.AVDISC = reader.GetString("AVDISC");
	this.AVLEAD = reader.GetDecimal("AVLEAD");
	this.AVSCDT = reader.GetString("AVSCDT");
	this.AVMAJG = reader.GetString("AVMAJG");
	this.AVMING = reader.GetString("AVMING");
	this.AVDES1 = reader.GetString("AVDES1");
	this.AVDES2 = reader.GetString("AVDES2");
	this.AVUNTI = reader.GetString("AVUNTI");
	this.AVBK01 = reader.GetString("AVBK01");
	this.AVTYPE = reader.GetString("AVTYPE");
	this.AVTOTP = reader.GetDecimal("AVTOTP");
	this.AVSHRK = reader.GetDecimal("AVSHRK");
	this.AVBILL = reader.GetString("AVBILL");
	this.AVTAXR = reader.GetString("AVTAXR");
	this.AVOPTR = reader.GetDecimal("AVOPTR");
	this.AVMULT = reader.GetDecimal("AVMULT");
	this.AVSTAT = reader.GetString("AVSTAT");

	if (Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_2)){
		//delete columns
		this.AVQTYP = 0;
		this.AVQTYA = 0;
		this.AVQTYH = 0;
		this.AVYTDU = 0;
		this.AVYTD1 = 0;
		this.AVYTD2 = 0;
		this.AVOQTY = 0;
		this.AVQTPO = 0;
		//add columns
		this.AVFUTC = reader.GetString("AVFUTC");
		this.AVFUTD = reader.GetString("AVFUTD");
		this.AVGTIN = reader.GetDecimal("AVGTIN");
		this.AVDPLT = reader.GetString("AVDPLT"); 
		this.AVFUTK = reader.GetString("AVFUTK");
		this.AVFUTN = reader.GetString("AVFUTN");
		this.AVPPAP= reader.GetString("AVPPAP"); 
		this.AVCUSR= reader.GetString("AVCUSR"); 
		this.AVCTME = reader.GetDateTime("AVCTME");
		this.AVUUSR = reader.GetString("AVUUSR"); 
		this.AVUDAT = reader.GetDateTime("AVUDAT"); 
		this.AVUTME = reader.GetDateTime("AVUTME");
		this.AVSIZC = reader.GetString("AVSIZC"); 
		this.AVSTLC = reader.GetString("AVSTLC"); 
		this.AVCOLC= reader.GetString("AVCOLC"); 
		this.AVASSC = reader.GetString("AVASSC"); 
		this.AVSASC = reader.GetString("AVSASC"); 
		this.AVLCOIL = reader.GetString("AVLCOIL"); 
		this.AVGDFL = reader.GetString("AVGDFL"); 
		this.AVVDFL = reader.GetString("AVVDFL"); 
		this.AVWOQF = reader.GetString("AVWOQF"); 
		this.AVNMFC = reader.GetString("AVNMFC");
		this.AVFUTH = reader.GetDecimal("AVFUTH");
		this.AVFUTI = reader.GetDecimal("AVFUTI");
		this.AVFUTL = reader.GetString("AVFUTL");
		this.AVFUTM = reader.GetString("AVFUTM");
		this.AVFUTP = reader.GetString("AVFUTP");
		this.AVFUTQ = reader.GetDateTime("AVFUTQ");
		this.AVFUTR = reader.GetDateTime("AVFUTR");
		this.AVOLDD2 = reader.GetString("AVOLDD2");
		this.AVFUTG = reader.GetDecimal("AVFUTG");
		this.AVRECU = reader.GetString("AVRECU");
		this.AVFTMF = reader.GetDecimal("AVFTMF") ;
		this.AVRECC = reader.GetString("AVRECC");
		this.AVFUTJ = reader.GetString("AVFUTJ");
		this.AVSPDT = reader.GetDateTime("AVSPDT");
		this.AVBBDT = reader.GetDateTime("AVBBDT");
		this.AVPSOR = reader.GetString("AVPSOR");
		this.AVFUTO = reader.GetString("AVFUTO");
		this.AVDENC = reader.GetString("AVDENC");
		this.AVDREL = reader.GetString("AVDREL");
		this.AVDDAT = reader.GetDateTime("AVDDAT");
		this.AVFUTE = reader.GetString("AVFUTE");
		this.AVDRWS2 = reader.GetString("AVDRWS2");
		this.AVDRWL2 = reader.GetString("AVDRWL2");
		this.AVDENC2 = reader.GetString("AVDENC2");
		this.AVDREL2 = reader.GetString("AVDREL2");
		this.AVDDAT2 = reader.GetDateTime("AVDDAT2");
		this.AVFUTF = reader.GetString("AVFUTF");
		this.AVSTCL = reader.GetString("AVSTCL");
		this.AVVLCD = reader.GetString("AVVLCD");
		this.AVSPPP = reader.GetDecimal("AVSPPP") ;
		this.AVSPPC = reader.GetString("AVSPPC");
		this.AVMPPP = reader.GetDecimal("AVMPPP") ;
		this.AVMPPC = reader.GetString("AVMPPC");
		this.AVFLG01 = reader.GetString("AVFLG01");
		this.AVFLG02 = reader.GetString("AVFLG02");
		this.AVFLG03 = reader.GetString("AVFLG03");
		this.AVFLG04 = reader.GetString("AVFLG04");
		this.AVFLG05 = reader.GetString("AVFLG05");
		this.AVFLG06 = reader.GetString("AVFLG06");
		this.AVFLG07 = reader.GetString("AVFLG07");
		this.AVFLG08 = reader.GetString("AVFLG08");
		this.AVFLG09 = reader.GetString("AVFLG09");
		this.AVFLG10 = reader.GetString("AVFLG10");
		this.AVFUT01 = reader.GetString("AVFUT01");
		this.AVFUT02 = reader.GetString("AVFUT02");
		this.AVFUT03 = reader.GetString("AVFUT03");
		this.AVFUT04 = reader.GetString("AVFUT04");
		this.AVFUT05 = reader.GetString("AVFUT05");
		this.AVFUT06 = reader.GetString("AVFUT06");
		this.AVFUT07 = reader.GetString("AVFUT07");
		this.AVFUT08 = reader.GetString("AVFUT08");
		this.AVFUT09 = reader.GetString("AVFUT09");
		this.AVFUT10 = reader.GetString("AVFUT10");
		this.AVFUT11 = reader.GetString("AVFUT11");
		this.AVFUT12 = reader.GetString("AVFUT12");
		this.AVFUT13 = reader.GetString("AVFUT13");
		this.AVFUT14 = reader.GetString("AVFUT14");
		this.AVFUT15 = reader.GetString("AVFUT15");
		this.AVFUT16 = reader.GetString("AVFUT16");
		this.AVFUT17 = reader.GetString("AVFUT17");
		this.AVFUT18 = reader.GetString("AVFUT18");
		this.AVFUT19 = reader.GetString("AVFUT19");
		this.AVFUT20 = reader.GetString("AVFUT20");
		this.AVFUT21 = reader.GetString("AVFUT21");
		this.AVFUT22 = reader.GetString("AVFUT22");
		this.AVFUT23 = reader.GetString("AVFUT23");
		this.AVFUT24 = reader.GetString("AVFUT24");
		this.AVFUT25 = reader.GetString("AVFUT25");
		this.AVFUT26 = reader.GetDecimal("AVFUT26");
		this.AVFUT27 = reader.GetDecimal("AVFUT27");
		this.AVFUT28 = reader.GetDecimal("AVFUT28");
		this.AVFUT29 = reader.GetDecimal("AVFUT29");
		this.AVFUT30 = reader.GetDecimal("AVFUT30");
		this.AVFUT31 = reader.GetDecimal("AVFUT31"); 
		this.AVFUT32 = reader.GetDecimal("AVFUT32"); 
		this.AVFUT33 = reader.GetDecimal("AVFUT33"); 
		this.AVFUT34 = reader.GetDecimal("AVFUT34"); 
		this.AVFUT35 = reader.GetDecimal("AVFUT35"); 
		this.AVFUT36 = reader.GetDateTime("AVFUT36"); 
		this.AVFUT37 = reader.GetDateTime("AVFUT37"); 
		this.AVFUT38 = reader.GetDateTime("AVFUT38"); 
		this.AVFUT39 = reader.GetDateTime("AVFUT39"); 
		this.AVFUT40 = reader.GetDateTime("AVFUT40"); 
		this.AVFUT41 = reader.GetDateTime("AVFUT41"); 
		this.AVFUT42 = reader.GetDateTime("AVFUT42"); 
		this.AVFUT43 = reader.GetDateTime("AVFUT43"); 
		this.AVFUT44 = reader.GetDateTime("AVFUT44"); 
		this.AVFUT45 = reader.GetDateTime("AVFUT45");
		this.AVUDFT = reader.GetString("AVUDFT");
		this.AVFRML = reader.GetString("AVFRML");

		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE) 
			this.AVSTAT = reader.GetString("V6STAT");
	}else{
		//remove in 5.2
		this.AVQTYP = reader.GetDecimal("AVQTYP");
		this.AVQTYA = reader.GetDecimal("AVQTYA");
		this.AVQTYH = reader.GetDecimal("AVQTYH");
		this.AVYTDU = reader.GetDecimal("AVYTDU");
		this.AVYTD1 = reader.GetDecimal("AVYTD1");
		this.AVYTD2 = reader.GetDecimal("AVYTD2");
		this.AVOQTY = reader.GetDecimal("AVOQTY");
		this.AVQTPO = reader.GetDecimal("AVQTPO");
		//add in 5.2
		this.AVFUTC = "";
		this.AVFUTD = "";
		this.AVGTIN = 0;
		this.AVDPLT = ""; 
		this.AVFUTK = "";
		this.AVFUTN = "";
		this.AVPPAP= ""; 
		this.AVCUSR= ""; 
		this.AVCTME = DateTime.MinValue;
		this.AVUUSR =""; 
		this.AVUDAT = DateTime.MinValue;
		this.AVUTME = DateTime.MinValue;
		this.AVSIZC =""; 
		this.AVSTLC =""; 
		this.AVCOLC= ""; 
		this.AVASSC =""; 
		this.AVSASC =""; 
		this.AVLCOIL = ""; 
		this.AVGDFL =""; 
		this.AVVDFL =""; 
		this.AVWOQF =""; 
		this.AVNMFC ="";
		this.AVFUTH = 0;
		this.AVFUTI = 0;
		this.AVFUTL ="";
		this.AVFUTM = "";
		this.AVFUTP = "";
		this.AVFUTQ = DateTime.MinValue;
		this.AVFUTR = DateTime.MinValue;
		this.AVOLDD2 ="";
		this.AVFUTG = 0;
		this.AVRECU = "";
		this.AVFTMF = 0;
		this.AVRECC = "";
		this.AVFUTJ = "";
		this.AVSPDT = DateTime.MinValue;
		this.AVBBDT = DateTime.MinValue;
		this.AVPSOR = "";
		this.AVFUTO = "";
		this.AVDENC = "";
		this.AVDREL = "";
		this.AVDDAT = DateTime.MinValue;
		this.AVFUTE = "";
		this.AVDRWS2 ="";
		this.AVDRWL2 ="";
		this.AVDENC2 ="";
		this.AVDREL2 ="";
		this.AVDDAT2 =DateTime.MinValue;
		this.AVFUTF = "";
		this.AVSTCL = "";
		this.AVVLCD = "";
		this.AVSPPP = 0;
		this.AVSPPC = "";
		this.AVMPPP = 0;
		this.AVMPPC = "";
		this.AVFLG01 ="";
		this.AVFLG02 ="";
		this.AVFLG03 ="";
		this.AVFLG04 ="";
		this.AVFLG05 ="";
		this.AVFLG06 ="";
		this.AVFLG07 ="";
		this.AVFLG08 ="";
		this.AVFLG09 ="";
		this.AVFLG10 ="";
		this.AVFUT01 ="";
		this.AVFUT02 ="";
		this.AVFUT03 ="";
		this.AVFUT04 ="";
		this.AVFUT05 = "";
		this.AVFUT06 = "";
		this.AVFUT07 = "";
		this.AVFUT08 = "";
		this.AVFUT09 = "";
		this.AVFUT10 = "";
		this.AVFUT11 = "";
		this.AVFUT12 = "";
		this.AVFUT13 = "";
		this.AVFUT14 = "";
		this.AVFUT15 = "";
		this.AVFUT16 = "";
		this.AVFUT17 = "";
		this.AVFUT18 = "";
		this.AVFUT19 = "";
		this.AVFUT20 = "";
		this.AVFUT21 = "";
		this.AVFUT22 = "";
		this.AVFUT23 = "";
		this.AVFUT24 = "";
		this.AVFUT25 = "";
		this.AVFUT26 = 0;
		this.AVFUT27 = 0;
		this.AVFUT28 = 0;
		this.AVFUT29 = 0;
		this.AVFUT30 = 0;
		this.AVFUT31 = 0; 
		this.AVFUT32 = 0; 
		this.AVFUT33 = 0; 
		this.AVFUT34 = 0; 
		this.AVFUT35 = 0; 
		this.AVFUT36 = DateTime.MinValue; 
		this.AVFUT37 = DateTime.MinValue; 
		this.AVFUT38 = DateTime.MinValue; 
		this.AVFUT39 = DateTime.MinValue; 
		this.AVFUT40 = DateTime.MinValue; 
		this.AVFUT41 = DateTime.MinValue; 
		this.AVFUT42 = DateTime.MinValue; 
		this.AVFUT43 = DateTime.MinValue; 
		this.AVFUT44 = DateTime.MinValue; 
		this.AVFUT45 = DateTime.MinValue;
		this.AVUDFT = "";
		this.AVFRML = "";
	}	

	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
		this.AVCPT = reader.GetString("AVCPT#"); 
		this.AVREV = reader.GetString("AVREV#");
	}else{
		this.AVCPT = reader.GetString("AVCPT"); 
		this.AVREV = reader.GetString("AVREV");
	}
		
	this.AVMINQ = reader.GetDecimal("AVMINQ");
	this.AVMAXQ = reader.GetDecimal("AVMAXQ");	
	this.AVCUST = reader.GetString("AVCUST");
	this.AVCORG = reader.GetString("AVCORG");
	this.AVPLAN = reader.GetString("AVPLAN");
	this.AVPRUN = reader.GetDecimal("AVPRUN");
	this.AVGLED = reader.GetString("AVGLED");
	this.AVENGC = reader.GetString("AVENGC");
	this.AVESTV = reader.GetDecimal("AVESTV");
	this.AVGLCD = reader.GetString("AVGLCD");
	this.AVFEDC = reader.GetString("AVFEDC");
	this.AVMAJS = reader.GetString("AVMAJS");
	this.AVMINS = reader.GetString("AVMINS");
	this.AVLDAT = reader.GetDateTime("AVLDAT");
	this.AVMINR = reader.GetDecimal("AVMINR");

	this.AVCNTR = reader.GetString("AVCNTR");
	this.AVBK04 = reader.GetString("AVBK04");
	this.AVREVL = reader.GetString("AVREVL");
	this.AVRDAT = reader.GetDateTime("AVRDAT");
	this.AVNWHT = reader.GetDecimal("AVNWHT");
	this.AVDES3 = reader.GetString("AVDES3");
	this.AVHARM = reader.GetString("AVHARM");
	this.AVBK06 = reader.GetString("AVBK06");
	this.AVOLDD = reader.GetString("AVOLDD");
	this.AVDRWS = reader.GetString("AVDRWS");
	this.AVDRWL = reader.GetString("AVDRWL");
	this.AVUNTP = reader.GetString("AVUNTP");
	this.AVLVL = reader.GetDecimal("AVLVL");
	this.AVMOQT = reader.GetDecimal("AVMOQT");
	
	this.AVPACK = reader.GetDecimal("AVPACK");
	this.AVPACU = reader.GetString("AVPACU");
	this.AVPRPT = reader.GetDecimal("AVPRPT");
	this.AVNWUN = reader.GetString("AVNWUN");
	this.AVSVOL = reader.GetDecimal("AVSVOL");
	this.AVSVUN = reader.GetString("AVSVUN");
	this.AVKITC = reader.GetString("AVKITC");
	this.AVUPCC = reader.GetString("AVUPCC");

	this.AVABCC = reader.GetString("AVABCC");
	this.AVCLSS = reader.GetString("AVCLSS");

	if (AVSTAT.Equals(""))
		AVSTAT = "A";

	this.AVINVT = reader.GetString("AVINVT");
	this.AVLOTF = reader.GetString("AVLOTF");
	this.AVSERF = reader.GetString("AVSERF");
	this.AVPROC = reader.GetString("AVPROC");
	this.AVCOIL = reader.GetString("AVCOIL");
	this.AVMSPC = reader.GetString("AVMSPC");
	this.AVLRSP = reader.GetString("AVLRSP");
	this.AVLRSC = reader.GetDecimal("AVLRSC");
	this.AVLRSF = reader.GetString("AVLRSF");
	this.AVLRMP = reader.GetString("AVLRMP");
	this.AVLRMC = reader.GetDecimal("AVLRMC");
	this.AVLRMF = reader.GetString("AVLRMF");
	this.AVLWSP = reader.GetString("AVLWSP");
	this.AVLWSC = reader.GetDecimal("AVLWSC");
	this.AVLWSF = reader.GetString("AVLWSF");
	this.AVLCSP = reader.GetString("AVLCSP");
	this.AVLCSC = reader.GetDecimal("AVLCSC");
	this.AVLCSF = reader.GetString("AVLCSF");
	this.AVLCMP = reader.GetString("AVLCMP");
	this.AVLCMC = reader.GetDecimal("AVLCMC");
	this.AVLCMF = reader.GetString("AVLCMF");
	this.AVLSSC = reader.GetDecimal("AVLSSC");
	this.AVLSSF = reader.GetString("AVLSSF");
	this.AVLSMP = reader.GetString("AVLSMP");
	this.AVLSMC = reader.GetDecimal("AVLSMC");
	this.AVLSMF = reader.GetString("AVLSMF");
	this.AVMPCK = reader.GetDecimal("AVMPCK");
	this.AVMPKU = reader.GetString("AVMPKU");
	this.AVORIG = reader.GetString("AVORIG");
	this.AVALTF = reader.GetDecimal("AVALTF");
	this.AVUVER = reader.GetString("AVUVER");
	this.AVCATA = reader.GetString("AVCATA");
	this.AVCDAT = reader.GetDateTime("AVCDAT");
	this.AVPERC = reader.GetDecimal("AVPERC");
	this.AVDBUY = reader.GetString("AVDBUY");
	this.AVSLIF = reader.GetDecimal("AVSLIF");
	this.AVREAS = reader.GetString("AVREAS");
	this.AVFUT1 = reader.GetString("AVFUT1");
	this.AVFUT2 = reader.GetString("AVFUT2");
	this.AVFUT3 = reader.GetString("AVFUT3");
	this.AVFUT4 = reader.GetString("AVFUT4");
	this.AVFUT5 = reader.GetString("AVFUT5");
	this.AVFUT6 = reader.GetDecimal("AVFUT6");
	this.AVFUT7 = reader.GetString("AVFUT7");
	this.AVFUT8 = reader.GetString("AVFUT8");
	this.AVFUT9 = reader.GetString("AVFUT9");
	this.AVFUTA = reader.GetString("AVFUTA");
	this.AVFUTB = reader.GetString("AVFUTB");
}


public override
void write(){
	try{
		string number ="AVCPT#,AVREV#,";
		if (!dataBaseAccess.getConnectionType().Equals(DataBaseAccess.CMS_DATABASE)){
			number ="AVCPT,AVREV,";
		}
		string 	sql = "";
		if (Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_2)){
			sql = "insert into stkmm (AVPART,AVDISC,AVLEAD,AVSCDT,AVMAJG,AVMING,AVDES1,AVDES2,AVUNTI,AVBK01,AVTYPE,AVTOTP," +
				"AVSHRK,AVBILL,AVTAXR,AVOPTR,AVMULT,AVMINQ,AVMAXQ,AVCUST,AVCORG," +
				"AVPLAN," + number + "AVPRUN,AVGLED,AVENGC,AVESTV,AVGLCD,AVFEDC,AVMAJS,AVMINS,AVLDAT,AVMINR,AVCNTR," +
				"AVBK04,AVREVL,AVRDAT,AVNWHT,AVDES3,AVHARM,AVBK06,AVOLDD,AVDRWS,AVDRWL,AVUNTP,AVLVL,AVMOQT,AVPACK,"+
				"AVPACU,AVPRPT,AVNWUN,AVSVOL,AVSVUN,AVKITC,AVUPCC,AVABCC,AVCLSS,AVSTAT,AVINVT,AVLOTF,AVSERF,AVPROC,AVCOIL,"+
				"AVMSPC,AVLRSP,AVLRSC,AVLRSF,AVLRMP,AVLRMC,AVLRMF,AVLWSP,AVLWSC,AVLWSF,AVLCSP,AVLCSC,AVLCSF,AVLCMP,AVLCMC,"+
				"AVLCMF,AVLSSC,AVLSSF,AVLSMP,AVLSMC,AVLSMF,AVMPCK,AVMPKU,AVORIG,AVALTF,AVUVER,AVCATA,AVCDAT,AVPERC,AVDBUY,"+
				"AVSLIF,AVREAS,AVFUT1,AVFUT2,AVFUT3,AVFUT4,AVFUT5,AVFUT6,AVFUT7,AVFUT8,AVFUT9,AVFUTA,AVFUTB,"+ 
//-------------------------------------------remove in 5.2
				"AVQTYP,AVQTYA ,AVQTYH ,AVYTDU ,AVYTD1 ,AVYTD2 ,AVOQTY ,AVQTPO ,"+		
//-------------------------------------------add in 5.2
				"AVFUTC ,AVFUTD,AVGTIN,AVDPLT,AVFUTK,AVFUTN,AVPPAP,AVCUSR,AVCTME,AVUUSR,AVUDAT,AVUTME,"+
				"AVSIZC,AVSTLC,AVCOLC,AVASSC,AVSASC,AVLCOIL ,AVGDFL,AVVDFL,AVWOQF,AVNMFC,AVFUTH,AVFUTI,AVFUTL,AVFUTM,AVFUTP,"+
				"AVFUTQ,AVFUTR,AVOLDD2,AVFUTG,AVRECU,AVFTMF,AVRECC,AVFUTJ,AVSPDT,AVBBDT,AVPSOR,AVFUTO,AVDENC,AVDREL,AVDDAT,"+
				"AVFUTE,AVDRWS2,AVDRWL2,AVDENC2,AVDREL2,AVDDAT2,AVFUTF,AVSTCL,AVVLCD,AVSPPP,AVSPPC,AVMPPP,AVMPPC,AVFLG01,AVFLG02,"+
				"AVFLG03,AVFLG04,AVFLG05,AVFLG06,AVFLG07,AVFLG08,AVFLG09,AVFLG10,AVFUT01,AVFUT02,AVFUT03,AVFUT04,AVFUT05,AVFUT06,"+
				"AVFUT07,AVFUT08,AVFUT09,AVFUT10,AVFUT11,AVFUT12,AVFUT13,AVFUT14,AVFUT15,AVFUT16,AVFUT17,AVFUT18,AVFUT19,AVFUT20,"+
				"AVFUT21,AVFUT22,AVFUT23,AVFUT24,AVFUT25,AVFUT26,AVFUT27,AVFUT28,AVFUT29,AVFUT30,AVFUT31,AVFUT32,AVFUT33,AVFUT34,"+
				"AVFUT35,AVFUT36,AVFUT37,AVFUT38,AVFUT39,AVFUT40,AVFUT41,AVFUT42,AVFUT43,AVFUT44,AVFUT45,AVUDFT,AVFRML )"
//-------------------------------------------
				+ " values('" +
				Converter.fixString(AVPART) + "', '" +
				Converter.fixString(AVDISC) + "', " +
				NumberUtil.toString(AVLEAD)  + ", '" +
				Converter.fixString(AVSCDT) + "', '" +
				Converter.fixString(AVMAJG) + "', '" +
				Converter.fixString(AVMING) + "', '" +
				Converter.fixString(AVDES1) + "', '" +
				Converter.fixString(AVDES2) + "', '" +
				Converter.fixString(AVUNTI) + "', '" +
				Converter.fixString(AVBK01) + "', '" +
				Converter.fixString(AVTYPE) + "', " +
				NumberUtil.toString(AVTOTP) + ", " +
				NumberUtil.toString(AVSHRK) + ", '" +
				Converter.fixString(AVBILL) + "', '" +
				Converter.fixString(AVTAXR) + "', " +
				NumberUtil.toString(AVOPTR)+ ", " +
				NumberUtil.toString(AVMULT)+ ", " +
				NumberUtil.toString(AVMINQ)+ ", " +
				NumberUtil.toString(AVMAXQ)+ ", '" +
				Converter.fixString(AVCUST) + "', '" +
				Converter.fixString(AVCORG) + "', '" +
				Converter.fixString(AVPLAN) + "', '" +
				Converter.fixString(AVCPT) + "', '" +
				Converter.fixString(AVREV) + "', " +
				NumberUtil.toString(AVPRUN)+ ", '" +
				Converter.fixString(AVGLED) + "', '" +
				Converter.fixString(AVENGC) + "', " +
				NumberUtil.toString(AVESTV)+ ", '" +
				Converter.fixString(AVGLCD) + "', '" +
				Converter.fixString(AVFEDC) + "', '" +
				Converter.fixString(AVMAJS) + "', '" +
				Converter.fixString(AVMINS) + "', '" +
				DateUtil.getDateRepresentation(AVLDAT)+ "', " +
				NumberUtil.toString(AVMINR)+ ", '" +
				Converter.fixString(AVCNTR)+ "', '" +
				Converter.fixString(AVBK04)+ "', '" +
				Converter.fixString(AVREVL)+ "', '" +
				DateUtil.getDateRepresentation(AVRDAT)+ "', " +
				NumberUtil.toString(AVNWHT)+ ", '" +
				Converter.fixString(AVDES3) + "', '" +
				Converter.fixString(AVHARM) + "', '" +
				Converter.fixString(AVBK06) + "', '" +
				Converter.fixString(AVOLDD) + "', '" +
				Converter.fixString(AVDRWS) + "', '" +
				Converter.fixString(AVDRWL) + "', '" +
				Converter.fixString(AVUNTP) + "', " +
				NumberUtil.toString(AVLVL)+ ", " +
				NumberUtil.toString(AVMOQT)+ ", " +
				NumberUtil.toString(AVPACK)+ ", '" +
				Converter.fixString(AVPACU) + "', " +
				NumberUtil.toString(AVPRPT)+ ", '" +
				Converter.fixString(AVNWUN) + "', " +
				NumberUtil.toString(AVSVOL)+ ", '" +
				Converter.fixString(AVSVUN) + "', '" +
				Converter.fixString(AVKITC) + "', '" +
				Converter.fixString(AVUPCC) + "', '" +
				Converter.fixString(AVABCC) + "', '" +
				Converter.fixString(AVCLSS) + "', '" +
				Converter.fixString(AVSTAT) + "', '" +
				Converter.fixString(AVINVT) + "', '" +
				Converter.fixString(AVLOTF) + "', '" +
				Converter.fixString(AVSERF) + "', '" +
				Converter.fixString(AVPROC) + "', '" +
				Converter.fixString(AVCOIL) + "', '" +
				Converter.fixString(AVMSPC) + "', '" +
				Converter.fixString(AVLRSP) + "', " +
				NumberUtil.toString(AVLRSC)+ ", '" +
				Converter.fixString(AVLRSF) + "', '" +
				Converter.fixString(AVLRMP) + "', " +
				NumberUtil.toString(AVLRMC)+ ", '" +
				Converter.fixString(AVLRMF) + "', '" +
				Converter.fixString(AVLWSP) + "', " +
				NumberUtil.toString(AVLWSC)+ ", '" +
				Converter.fixString(AVLWSF) + "', '" +
				Converter.fixString(AVLCSP) + "', " +
				NumberUtil.toString(AVLCSC)+ ", '" +
				Converter.fixString(AVLCSF) + "', '" +
				Converter.fixString(AVLCMP) + "', " +
				NumberUtil.toString(AVLCMC)+ ", '" +
				Converter.fixString(AVLCMF) + "', " +
				NumberUtil.toString(AVLSSC)+ ", '" +
				Converter.fixString(AVLSSF) + "', '" +
				Converter.fixString(AVLSMP) + "', " +
				NumberUtil.toString(AVLSMC)+ ", '" +
				Converter.fixString(AVLSMF) + "', '" +
				NumberUtil.toString(AVMPCK)+ "', '" +
				Converter.fixString(AVMPKU) + "', '" +
				Converter.fixString(AVORIG) + "', " +
				NumberUtil.toString(AVALTF)+ ", '" +
				Converter.fixString(AVUVER) + "', '" +
				Converter.fixString(AVCATA) + "', '" +
				DateUtil.getDateRepresentation(AVCDAT)+ "', " +
				NumberUtil.toString(AVPERC)+ ", '" +
				Converter.fixString(AVDBUY) + "', " +
				NumberUtil.toString(AVSLIF)+ ", '" +
				Converter.fixString(AVREAS) + "', '" +
				Converter.fixString(AVFUT1) + "', '" +
				Converter.fixString(AVFUT2) + "', '" +
				Converter.fixString(AVFUT3) + "', '" +
				Converter.fixString(AVFUT4) + "', '" +
				Converter.fixString(AVFUT5) + "', " +
				NumberUtil.toString(AVFUT6)+ ", '" +
				Converter.fixString(AVFUT7) + "', '" +
				Converter.fixString(AVFUT8) + "', '" +
				Converter.fixString(AVFUT9) + "', '" +
				Converter.fixString(AVFUTA) + "', '" +
				Converter.fixString(AVFUTB) + "', " +
//-------------------------------------------remove in 5.2
				NumberUtil.toString(AVQTYP)+ ", " +
				NumberUtil.toString(AVQTYA)+ ", " +
				NumberUtil.toString(AVQTYH)+ ", " +
				NumberUtil.toString(AVYTDU)+ ", " +
				NumberUtil.toString(AVYTD1)+ ", " +
				NumberUtil.toString(AVYTD2)+ ", " +
				NumberUtil.toString(AVOQTY)+ ", " +
				NumberUtil.toString(AVQTPO)+ ", '" +
//-------------------------------------------add in 5.2 
				Converter.fixString(AVFUTC) + "', '" + 
				Converter.fixString(AVFUTD) + "', " + 
				NumberUtil.toString(AVGTIN) + ", '" + 
				Converter.fixString(AVDPLT) + "', '" + 
				Converter.fixString(AVFUTK) + "', '" + 
				Converter.fixString(AVFUTN) + "', '" + 
				Converter.fixString(AVPPAP) + "', '" + 
				Converter.fixString(AVCUSR) + "', '" + 
				DateUtil.getDateRepresentation(AVCTME) + "', '" + 
				Converter.fixString(AVUUSR) + "', '" + 
				DateUtil.getDateRepresentation(AVUDAT)  + "', '" + 
				DateUtil.getDateRepresentation(AVUTME) + "', '" + 
				Converter.fixString(AVSIZC) + "', '" + 
				Converter.fixString(AVSTLC) + "', '" + 
				Converter.fixString(AVCOLC) + "', '" + 
				Converter.fixString(AVASSC) + "', '" + 
				Converter.fixString(AVSASC) + "', '" + 
				Converter.fixString(AVLCOIL) + "', '" + 
				Converter.fixString(AVGDFL) + "', '" + 
				Converter.fixString(AVVDFL) + "', '" + 
				Converter.fixString(AVWOQF) + "', '" + 
				Converter.fixString(AVNMFC) + "', " + 
				NumberUtil.toString(AVFUTH) + ", " + 
				NumberUtil.toString(AVFUTI) + ", '" + 
				Converter.fixString(AVFUTL) + "', '" + 
				Converter.fixString(AVFUTM) + "', '" + 
				Converter.fixString(AVFUTP) + "', '" + 
				DateUtil.getDateRepresentation(AVFUTQ) + "', '" + 
				DateUtil.getDateRepresentation(AVFUTR) + "', '" + 
				Converter.fixString(AVOLDD2) + "', " + 
				NumberUtil.toString(AVFUTG) + ", '" + 
				Converter.fixString(AVRECU) + "', " + 
				NumberUtil.toString(AVFTMF) + ", '" + 
				Converter.fixString(AVRECC) + "', '" + 
				Converter.fixString(AVFUTJ) + "', '" + 
				DateUtil.getDateRepresentation(AVSPDT) + "', '" + 
				DateUtil.getDateRepresentation(AVBBDT) + "', '" + 
				Converter.fixString(AVPSOR) + "', '" + 
				Converter.fixString(AVFUTO) + "', '" + 
				Converter.fixString(AVDENC) + "', '" + 
				Converter.fixString(AVDREL) + "', '" + 
				DateUtil.getDateRepresentation(AVDDAT) + "', '" + 
				Converter.fixString(AVFUTE) + "', '" + 
				Converter.fixString(AVDRWS2) + "', '" + 
				Converter.fixString(AVDRWL2) + "', '" + 
				Converter.fixString(AVDENC2) + "', '" + 
				Converter.fixString(AVDREL2) + "', '" + 
				DateUtil.getDateRepresentation(AVDDAT2) + "', '" + 
				Converter.fixString(AVFUTF) + "', '" + 
				Converter.fixString(AVSTCL) + "', '" + 
				Converter.fixString(AVVLCD) + "', " + 
				NumberUtil.toString(AVSPPP) + ", '" + 
				Converter.fixString(AVSPPC) + "', " + 
				NumberUtil.toString(AVMPPP) + ", '" + 
				Converter.fixString(AVMPPC) + "', '" + 
				Converter.fixString(AVFLG01) + "', '" + 
				Converter.fixString(AVFLG02) + "', '" + 
				Converter.fixString(AVFLG03) + "', '" + 
				Converter.fixString(AVFLG04) + "', '" + 
				Converter.fixString(AVFLG05) + "', '" + 
				Converter.fixString(AVFLG06) + "', '" + 
				Converter.fixString(AVFLG07) + "', '" + 
				Converter.fixString(AVFLG08) + "', '" + 
				Converter.fixString(AVFLG09) + "', '" + 
				Converter.fixString(AVFLG10) + "', '" + 
				Converter.fixString(AVFUT01) + "', '" + 
				Converter.fixString(AVFUT02) + "', '" + 
				Converter.fixString(AVFUT03) + "', '" + 
				Converter.fixString(AVFUT04) + "', '" + 
				Converter.fixString(AVFUT05) + "', '" + 
				Converter.fixString(AVFUT06) + "', '" + 
				Converter.fixString(AVFUT07) + "', '" + 
				Converter.fixString(AVFUT08) + "', '" + 
				Converter.fixString(AVFUT09) + "', '" + 
				Converter.fixString(AVFUT10) + "', '" + 
				Converter.fixString(AVFUT11) + "', '" + 
				Converter.fixString(AVFUT12) + "', '" + 
				Converter.fixString(AVFUT13) + "', '" + 
				Converter.fixString(AVFUT14) + "', '" + 
				Converter.fixString(AVFUT15) + "', '" + 
				Converter.fixString(AVFUT16) + "', '" + 
				Converter.fixString(AVFUT17) + "', '" + 
				Converter.fixString(AVFUT18) + "', '" + 
				Converter.fixString(AVFUT19) + "', '" + 
				Converter.fixString(AVFUT20) + "', '" + 
				Converter.fixString(AVFUT21) + "', '" + 
				Converter.fixString(AVFUT22) + "', '" + 
				Converter.fixString(AVFUT23) + "', '" + 
				Converter.fixString(AVFUT24) + "', '" + 
				Converter.fixString(AVFUT25) + "', " + 
				NumberUtil.toString(AVFUT26) + ", " + 
				NumberUtil.toString(AVFUT27) + ", " + 
				NumberUtil.toString(AVFUT28) + ", " + 
				NumberUtil.toString(AVFUT29) + ", " + 
				NumberUtil.toString(AVFUT30) + ", " + 
				NumberUtil.toString(AVFUT31)  + ", " + 
				NumberUtil.toString(AVFUT32)  + ", " + 
				NumberUtil.toString(AVFUT33)  + ", " + 
				NumberUtil.toString(AVFUT34)  + ", " + 
				NumberUtil.toString(AVFUT35)  + ", '" + 
				DateUtil.getDateRepresentation(AVFUT36)  + "', '" + 
				DateUtil.getDateRepresentation(AVFUT37)  + "', '" + 
				DateUtil.getDateRepresentation(AVFUT38)  + "', '" + 
				DateUtil.getDateRepresentation(AVFUT39)  + "', '" + 
				DateUtil.getDateRepresentation(AVFUT40)  + "', '" + 
				DateUtil.getDateRepresentation(AVFUT41)  + "', '" + 
				DateUtil.getDateRepresentation(AVFUT42)  + "', '" + 
				DateUtil.getDateRepresentation(AVFUT43)  + "', '" + 
				DateUtil.getDateRepresentation(AVFUT44)  + "', '" + 
				DateUtil.getDateRepresentation(AVFUT45) + "', '" + 
				Converter.fixString(AVUDFT) + "', '" + 
				Converter.fixString(AVFRML) + "')";
//-------------------------------------------
		}else{
			sql = "insert into stkmm(" +
				"AVPART, AVDISC, AVLEAD, AVSCDT, AVMAJG, AVMING, AVDES1, AVDES2, AVUNTI, " +
				"AVBK01, AVTYPE, AVTOTP, AVSHRK, AVBILL, AVTAXR, AVOPTR, AVMULT, AVQTYP, " +
				"AVQTYA, AVQTYH, AVMINQ, AVMAXQ, AVYTDU, AVYTD1, AVYTD2, AVCUST, AVCORG, " +
				"AVPLAN, AVCPT, AVREV, AVPRUN, AVGLED, AVENGC, AVESTV, AVGLCD, AVFEDC, " +
				"AVMAJS, AVMINS, AVLDAT, AVMINR, AVOQTY, AVCNTR, AVBK04, AVREVL, AVRDAT, " +
				"AVNWHT, AVDES3, AVHARM, AVBK06, AVOLDD, AVDRWS, AVDRWL, AVUNTP, AVLVL, " +
				"AVMOQT, AVQTPO, AVPACK, AVPACU, AVPRPT, AVNWUN, AVSVOL, AVSVUN, AVKITC, " +
				"AVUPCC, AVABCC, AVCLSS, AVSTAT, AVINVT, AVLOTF, AVSERF, AVPROC, AVCOIL, " +
				"AVMSPC, AVLRSP, AVLRSC, AVLRSF, AVLRMP, AVLRMC, AVLRMF, AVLWSP, AVLWSC, " +
				"AVLWSF, AVLCSP, AVLCSC, AVLCSF, AVLCMP, AVLCMC, AVLCMF, AVLSSC, AVLSSF, " +
				"AVLSMP, AVLSMC, AVLSMF, AVMPCK, AVMPKU, AVORIG, AVALTF, AVUVER, AVCATA, " +
				"AVCDAT, AVPERC, AVDBUY, AVSLIF, AVREAS, AVFUT1, AVFUT2, AVFUT3, AVFUT4, " +
				"AVFUT5, AVFUT6, AVFUT7, AVFUT8, AVFUT9, AVFUTA, AVFUTB" +
			")values('" +
				Converter.fixString(AVPART) + "', '" +
				Converter.fixString(AVDISC) + "', " +
				NumberUtil.toString(AVLEAD)  + ", '" +
				Converter.fixString(AVSCDT) + "', '" +
				Converter.fixString(AVMAJG) + "', '" +
				Converter.fixString(AVMING) + "', '" +
				Converter.fixString(AVDES1) + "', '" +
				Converter.fixString(AVDES2) + "', '" +
				Converter.fixString(AVUNTI) + "', '" +
				Converter.fixString(AVBK01) + "', '" +
				Converter.fixString(AVTYPE) + "', " +
				NumberUtil.toString(AVTOTP) + ", " +
				NumberUtil.toString(AVSHRK) + ", '" +
				Converter.fixString(AVBILL) + "', '" +
				Converter.fixString(AVTAXR) + "', " +
				NumberUtil.toString(AVOPTR)+ ", " +
				NumberUtil.toString(AVMULT)+ ", " +
				NumberUtil.toString(AVQTYP)+ ", " +
				NumberUtil.toString(AVQTYA)+ ", " +
				NumberUtil.toString(AVQTYH)+ ", " +
				NumberUtil.toString(AVMINQ)+ ", " +
				NumberUtil.toString(AVMAXQ)+ ", " +
				NumberUtil.toString(AVYTDU)+ ", " +
				NumberUtil.toString(AVYTD1)+ ", " +
				NumberUtil.toString(AVYTD2)+ ", '" +
				Converter.fixString(AVCUST) + "', '" +
				Converter.fixString(AVCORG) + "', '" +
				Converter.fixString(AVPLAN) + "', '" +
				Converter.fixString(AVCPT) + "', '" +
				Converter.fixString(AVREV) + "', " +
				NumberUtil.toString(AVPRUN)+ ", '" +
				Converter.fixString(AVGLED) + "', '" +
				Converter.fixString(AVENGC) + "', " +
				NumberUtil.toString(AVESTV)+ ", '" +
				Converter.fixString(AVGLCD) + "', '" +
				Converter.fixString(AVFEDC) + "', '" +
				Converter.fixString(AVMAJS) + "', '" +
				Converter.fixString(AVMINS) + "', '" +
				DateUtil.getDateRepresentation(AVLDAT)+ "', " +
				NumberUtil.toString(AVMINR)+ ", " +
				NumberUtil.toString(AVOQTY)+ ", '" +
				Converter.fixString(AVCNTR)+ "', '" +
				Converter.fixString(AVBK04)+ "', '" +
				Converter.fixString(AVREVL)+ "', '" +
				DateUtil.getDateRepresentation(AVRDAT)+ "', " +
				NumberUtil.toString(AVNWHT)+ ", '" +
				Converter.fixString(AVDES3) + "', '" +
				Converter.fixString(AVHARM) + "', '" +
				Converter.fixString(AVBK06) + "', '" +
				Converter.fixString(AVOLDD) + "', '" +
				Converter.fixString(AVDRWS) + "', '" +
				Converter.fixString(AVDRWL) + "', '" +
				Converter.fixString(AVUNTP) + "', " +
				NumberUtil.toString(AVLVL)+ ", " +
				NumberUtil.toString(AVMOQT)+ ", " +
				NumberUtil.toString(AVQTPO)+ ", " +
				NumberUtil.toString(AVPACK)+ ", '" +
				Converter.fixString(AVPACU) + "', " +
				NumberUtil.toString(AVPRPT)+ ", '" +
				Converter.fixString(AVNWUN) + "', " +
				NumberUtil.toString(AVSVOL)+ ", '" +
				Converter.fixString(AVSVUN) + "', '" +
				Converter.fixString(AVKITC) + "', '" +
				Converter.fixString(AVUPCC) + "', '" +
				Converter.fixString(AVABCC) + "', '" +
				Converter.fixString(AVCLSS) + "', '" +
				Converter.fixString(AVSTAT) + "', '" +
				Converter.fixString(AVINVT) + "', '" +
				Converter.fixString(AVLOTF) + "', '" +
				Converter.fixString(AVSERF) + "', '" +
				Converter.fixString(AVPROC) + "', '" +
				Converter.fixString(AVCOIL) + "', '" +
				Converter.fixString(AVMSPC) + "', '" +
				Converter.fixString(AVLRSP) + "', " +
				NumberUtil.toString(AVLRSC)+ ", '" +
				Converter.fixString(AVLRSF) + "', '" +
				Converter.fixString(AVLRMP) + "', " +
				NumberUtil.toString(AVLRMC)+ ", '" +
				Converter.fixString(AVLRMF) + "', '" +
				Converter.fixString(AVLWSP) + "', " +
				NumberUtil.toString(AVLWSC)+ ", '" +
				Converter.fixString(AVLWSF) + "', '" +
				Converter.fixString(AVLCSP) + "', " +
				NumberUtil.toString(AVLCSC)+ ", '" +
				Converter.fixString(AVLCSF) + "', '" +
				Converter.fixString(AVLCMP) + "', " +
				NumberUtil.toString(AVLCMC)+ ", '" +
				Converter.fixString(AVLCMF) + "', " +
				NumberUtil.toString(AVLSSC)+ ", '" +
				Converter.fixString(AVLSSF) + "', '" +
				Converter.fixString(AVLSMP) + "', " +
				NumberUtil.toString(AVLSMC)+ ", '" +
				Converter.fixString(AVLSMF) + "', '" +
				NumberUtil.toString(AVMPCK)+ "', '" +
				Converter.fixString(AVMPKU) + "', '" +
				Converter.fixString(AVORIG) + "', " +
				NumberUtil.toString(AVALTF)+ ", '" +
				Converter.fixString(AVUVER) + "', '" +
				Converter.fixString(AVCATA) + "', '" +
				DateUtil.getDateRepresentation(AVCDAT)+ "', " +
				NumberUtil.toString(AVPERC)+ ", '" +
				Converter.fixString(AVDBUY) + "', " +
				NumberUtil.toString(AVSLIF)+ ", '" +
				Converter.fixString(AVREAS) + "', '" +
				Converter.fixString(AVFUT1) + "', '" +
				Converter.fixString(AVFUT2) + "', '" +
				Converter.fixString(AVFUT3) + "', '" +
				Converter.fixString(AVFUT4) + "', '" +
				Converter.fixString(AVFUT5) + "', " +
				NumberUtil.toString(AVFUT6)+ ", '" +
				Converter.fixString(AVFUT7) + "', '" +
				Converter.fixString(AVFUT8) + "', '" +
				Converter.fixString(AVFUT9) + "', '" +
				Converter.fixString(AVFUTA) + "', '" +
				Converter.fixString(AVFUTB) + "')";
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

public
void setAVPART(string AVPART){
	this.AVPART = AVPART;
}

public
void setAVDISC(string AVDISC){
	this.AVDISC = AVDISC;
}

public
void setAVLEAD(decimal AVLEAD){
	this.AVLEAD = AVLEAD;
}

public
void setAVSCDT(string AVSCDT){
	this.AVSCDT = AVSCDT;
}

public
void setAVMAJG(string AVMAJG){
	this.AVMAJG = AVMAJG;
}

public
void setAVMING(string AVMING){
	this.AVMING = AVMING;
}

public
void setAVDES1(string AVDES1){
	this.AVDES1 = AVDES1;
}

public
void setAVDES2(string AVDES2){
	this.AVDES2 = AVDES2;
}

public
void setAVUNTI(string AVUNTI){
	this.AVUNTI = AVUNTI;
}

public
void setAVBK01(string AVBK01){
	this.AVBK01 = AVBK01;
}

public
void setAVTYPE(string AVTYPE){
	this.AVTYPE = AVTYPE;
}

public
void setAVTOTP(decimal AVTOTP){
	this.AVTOTP = AVTOTP;
}

public
void setAVSHRK(decimal AVSHRK){
	this.AVSHRK = AVSHRK;
}

public
void setAVBILL(string AVBILL){
	this.AVBILL = AVBILL;
}

public
void setAVTAXR(string AVTAXR){
	this.AVTAXR = AVTAXR;
}

public
void setAVOPTR(decimal AVOPTR){
	this.AVOPTR = AVOPTR;
}

public
void setAVMULT(decimal AVMULT){
	this.AVMULT = AVMULT;
}

public
void setAVQTYP(decimal AVQTYP){
	this.AVQTYP = AVQTYP;
}

public
void setAVQTYA(decimal AVQTYA){
	this.AVQTYA = AVQTYA;
}

public
void setAVQTYH(decimal AVQTYH){
	this.AVQTYH = AVQTYH;
}

public
void setAVMINQ(decimal AVMINQ){
	this.AVMINQ = AVMINQ;
}

public
void setAVMAXQ(decimal AVMAXQ){
	this.AVMAXQ = AVMAXQ;
}

public
void setAVYTDU(decimal AVYTDU){
	this.AVYTDU = AVYTDU;
}

public
void setAVYTD1(decimal AVYTD1){
	this.AVYTD1 = AVYTD1;
}

public
void setAVYTD2(decimal AVYTD2){
	this.AVYTD2 = AVYTD2;
}

public
void setAVCUST(string AVCUST){
	this.AVCUST = AVCUST;
}

public
void setAVCORG(string AVCORG){
	this.AVCORG = AVCORG;
}

public
void setAVPLAN(string AVPLAN){
	this.AVPLAN = AVPLAN;
}

public
void setAVCPT(string AVCPT){
	this.AVCPT = AVCPT;
}

public
void setAVREV(string AVREV){
	this.AVREV = AVREV;
}

public
void setAVPRUN(decimal AVPRUN){
	this.AVPRUN = AVPRUN;
}

public
void setAVGLED(string AVGLED){
	this.AVGLED = AVGLED;
}

public
void setAVENGC(string AVENGC){
	this.AVENGC = AVENGC;
}

public
void setAVESTV(decimal AVESTV){
	this.AVESTV = AVESTV;
}

public
void setAVGLCD(string AVGLCD){
	this.AVGLCD = AVGLCD;
}

public
void setAVFEDC(string AVFEDC){
	this.AVFEDC = AVFEDC;
}

public
void setAVMAJS(string AVMAJS){
	this.AVMAJS = AVMAJS;
}

public
void setAVMINS(string AVMINS){
	this.AVMINS = AVMINS;
}

public
void setAVLDAT(DateTime AVLDAT){
	this.AVLDAT = AVLDAT;
}

public
void setAVMINR(decimal AVMINR){
	this.AVMINR = AVMINR;
}

public
void setAVOQTY(decimal AVOQTY){
	this.AVOQTY = AVOQTY;
}

public
void setAVCNTR(string AVCNTR){
	this.AVCNTR = AVCNTR;
}

public
void setAVBK04(string AVBK04){
	this.AVBK04 = AVBK04;
}

public
void setAVREVL(string AVREVL){
	this.AVREVL = AVREVL;
}

public
void setAVRDAT(DateTime AVRDAT){
	this.AVRDAT = AVRDAT;
}

public
void setAVNWHT(decimal AVNWHT){
	this.AVNWHT = AVNWHT;
}

public
void setAVDES3(string AVDES3){
	this.AVDES3 = AVDES3;
}

public
void setAVHARM(string AVHARM){
	this.AVHARM = AVHARM;
}

public
void setAVBK06(string AVBK06){
	this.AVBK06 = AVBK06;
}

public
void setAVOLDD(string AVOLDD){
	this.AVOLDD = AVOLDD;
}

public
void setAVDRWS(string AVDRWS){
	this.AVDRWS = AVDRWS;
}

public
void setAVDRWL(string AVDRWL){
	this.AVDRWL = AVDRWL;
}

public
void setAVUNTP(string AVUNTP){
	this.AVUNTP = AVUNTP;
}

public
void setAVLVL(decimal AVLVL){
	this.AVLVL = AVLVL;
}

public
void setAVMOQT(decimal AVMOQT){
	this.AVMOQT = AVMOQT;
}

public
void setAVQTPO(decimal AVQTPO){
	this.AVQTPO = AVQTPO;
}

public
void setAVPACK(decimal AVPACK){
	this.AVPACK = AVPACK;
}

public
void setAVPACU(string AVPACU){
	this.AVPACU = AVPACU;
}

public
void setAVPRPT(decimal AVPRPT){
	this.AVPRPT = AVPRPT;
}

public
void setAVNWUN(string AVNWUN){
	this.AVNWUN = AVNWUN;
}

public
void setAVSVOL(decimal AVSVOL){
	this.AVSVOL = AVSVOL;
}

public
void setAVSVUN(string AVSVUN){
	this.AVSVUN = AVSVUN;
}

public
void setAVKITC(string AVKITC){
	this.AVKITC = AVKITC;
}

public
void setAVUPCC(string AVUPCC){
	this.AVUPCC = AVUPCC;
}

public
void setAVABCC(string AVABCC){
	this.AVABCC = AVABCC;
}

public
void setAVCLSS(string AVCLSS){
	this.AVCLSS = AVCLSS;
}

public
void setAVSTAT(string AVSTAT){
	this.AVSTAT = AVSTAT;
}

public
void setAVINVT(string AVINVT){
	this.AVINVT = AVINVT;
}

public
void setAVLOTF(string AVLOTF){
	this.AVLOTF = AVLOTF;
}

public
void setAVSERF(string AVSERF){
	this.AVSERF = AVSERF;
}

public
void setAVPROC(string AVPROC){
	this.AVPROC = AVPROC;
}

public
void setAVCOIL(string AVCOIL){
	this.AVCOIL = AVCOIL;
}

public
void setAVMSPC(string AVMSPC){
	this.AVMSPC = AVMSPC;
}

public
void setAVLRSP(string AVLRSP){
	this.AVLRSP = AVLRSP;
}

public
void setAVLRSC(decimal AVLRSC){
	this.AVLRSC = AVLRSC;
}

public
void setAVLRSF(string AVLRSF){
	this.AVLRSF = AVLRSF;
}

public
void setAVLRMP(string AVLRMP){
	this.AVLRMP = AVLRMP;
}

public
void setAVLRMC(decimal AVLRMC){
	this.AVLRMC = AVLRMC;
}

public
void setAVLRMF(string AVLRMF){
	this.AVLRMF = AVLRMF;
}

public
void setAVLWSP(string AVLWSP){
	this.AVLWSP = AVLWSP;
}

public
void setAVLWSC(decimal AVLWSC){
	this.AVLWSC = AVLWSC;
}

public
void setAVLWSF(string AVLWSF){
	this.AVLWSF = AVLWSF;
}

public
void setAVLCSP(string AVLCSP){
	this.AVLCSP = AVLCSP;
}

public
void setAVLCSC(decimal AVLCSC){
	this.AVLCSC = AVLCSC;
}

public
void setAVLCSF(string AVLCSF){
	this.AVLCSF = AVLCSF;
}

public
void setAVLCMP(string AVLCMP){
	this.AVLCMP = AVLCMP;
}

public
void setAVLCMC(decimal AVLCMC){
	this.AVLCMC = AVLCMC;
}

public
void setAVLCMF(string AVLCMF){
	this.AVLCMF = AVLCMF;
}

public
void setAVLSSC(decimal AVLSSC){
	this.AVLSSC = AVLSSC;
}

public
void setAVLSSF(string AVLSSF){
	this.AVLSSF = AVLSSF;
}

public
void setAVLSMP(string AVLSMP){
	this.AVLSMP = AVLSMP;
}

public
void setAVLSMC(decimal AVLSMC){
	this.AVLSMC = AVLSMC;
}

public
void setAVLSMF(string AVLSMF){
	this.AVLSMF = AVLSMF;
}

public
void setAVMPCK(decimal AVMPCK){
	this.AVMPCK = AVMPCK;
}

public
void setAVMPKU(string AVMPKU){
	this.AVMPKU = AVMPKU;
}

public
void setAVORIG(string AVORIG){
	this.AVORIG = AVORIG;
}

public
void setAVALTF(decimal AVALTF){
	this.AVALTF = AVALTF;
}

public
void setAVUVER(string AVUVER){
	this.AVUVER = AVUVER;
}

public
void setAVCATA(string AVCATA){
	this.AVCATA = AVCATA;
}

public
void setAVCDAT(DateTime AVCDAT){
	this.AVCDAT = AVCDAT;
}

public
void setAVPERC(decimal AVPERC){
	this.AVPERC = AVPERC;
}

public
void setAVDBUY(string AVDBUY){
	this.AVDBUY = AVDBUY;
}

public
void setAVSLIF(decimal AVSLIF){
	this.AVSLIF = AVSLIF;
}

public
void setAVREAS(string AVREAS){
	this.AVREAS = AVREAS;
}

public
void setAVFUT1(string AVFUT1){
	this.AVFUT1 = AVFUT1;
}

public
void setAVFUT2(string AVFUT2){
	this.AVFUT2 = AVFUT2;
}

public
void setAVFUT3(string AVFUT3){
	this.AVFUT3 = AVFUT3;
}

public
void setAVFUT4(string AVFUT4){
	this.AVFUT4 = AVFUT4;
}

public
void setAVFUT5(string AVFUT5){
	this.AVFUT5 = AVFUT5;
}

public
void setAVFUT6(decimal AVFUT6){
	this.AVFUT6 = AVFUT6;
}

public
void setAVFUT7(string AVFUT7){
	this.AVFUT7 = AVFUT7;
}

public
void setAVFUT8(string AVFUT8){
	this.AVFUT8 = AVFUT8;
}

public
void setAVFUT9(string AVFUT9){
	this.AVFUT9 = AVFUT9;
}

public
void setAVFUTA(string AVFUTA){
	this.AVFUTA = AVFUTA;
}

public
void setAVFUTB(string AVFUTB){
	this.AVFUTB = AVFUTB;
}

//------------------------------------------set add in 5.2
public 
void setAVFUTC(string AVFUTC){
	this.AVFUTC = AVFUTC;
}
public 
void setAVFUTD(string AVFUTD){
	this.AVFUTD = AVFUTD;
}
public 
void setAVGTIN(decimal AVGTIN){
	this.AVGTIN = AVGTIN;
}

public 
void setAVDPLT(string AVDPLT){
	this.AVDPLT = AVDPLT;
}

public 
void setAVFUTK(string AVFUTK){
	this.AVFUTK = AVFUTK;
}
public 
void setAVFUTN(string AVFUTN){
	this.AVFUTN = AVFUTN;
}
public 
void setAVPPAP(string AVPPAP){
	this.AVPPAP = AVPPAP;
}
public 
void setAVCUSR(string AVCUSR){
	this.AVCUSR = AVCUSR;
}
public
void setAVCTME(DateTime AVCTME){
	this.AVCTME = AVCTME;
}
public 
void setAVUUSR(string AVUUSR){
	this.AVUUSR = AVUUSR;
}

public
void setAVUDAT(DateTime AVUDAT){
	this.AVUDAT = AVUDAT;
}
public
void setAVUTME(DateTime AVUTME){
	this.AVUTME = AVUTME;
}
public 
void setAVSIZC(string AVSIZC){
	this.AVSIZC = AVSIZC;
}
public 
void setAVSTLC(string AVSTLC){
	this.AVSTLC = AVSTLC;
}
public 
void setAVCOLC(string AVCOLC){
	this.AVCOLC = AVCOLC;
}
public 
void setAVASSC(string AVASSC){
	this.AVASSC = AVASSC;
}
public 
void setAVSASC(string AVSASC){
	this.AVSASC = AVSASC;
}
public 
void setAVLCOIL(string AVLCOIL){
	this.AVLCOIL = AVLCOIL;
}

public 
void setAVGDFL(string AVGDFL){
	this.AVGDFL = AVGDFL;
}
public 
void setAVVDFL(string AVVDFL){
	this.AVVDFL = AVVDFL;
}
public 
void setAVWOQF(string AVWOQF){
	this.AVWOQF = AVWOQF;
}
public 
void setAVNMFC(string AVNMFC){
	this.AVNMFC = AVNMFC;
}

public 
void setAVFUTH(decimal AVFUTH){
	this.AVFUTH = AVFUTH;
}

public 
void setAVFUTI(decimal AVFUTI){
	this.AVFUTI = AVFUTI;
}
public 
void setAVFUTL(string AVFUTL){
	this.AVFUTL = AVFUTL;
}
public 
void setAVFUTM(string AVFUTM){
	this.AVFUTM = AVFUTM;
}
public 
void setAVFUTP(string AVFUTP){
	this.AVFUTP = AVFUTP;
}
public
void setAVFUTQ(DateTime AVFUTQ){
	this.AVFUTQ = AVFUTQ;
}
public
void setAVFUTR(DateTime AVFUTR){
	this.AVFUTR = AVFUTR;
}

public 
void setAVOLDD2(string AVOLDD2){
	this.AVOLDD2 = AVOLDD2;
}
public 
void setAVFUTG(decimal AVFUTG){
	this.AVFUTG = AVFUTG;
}
public 
void setAVRECU(string AVRECU){
	this.AVRECU = AVRECU;
}
public 
void setAVFTMF(decimal AVFTMF){
	this.AVFTMF = AVFTMF;
}
public 
void setAVRECC(string AVRECC){
	this.AVRECC = AVRECC;
}
public 
void setAVFUTJ(string AVFUTJ){
	this.AVFUTJ = AVFUTJ;
}
public
void setAVSPDT(DateTime AVSPDT){
	this.AVSPDT = AVSPDT;
}
public
void setAVBBDT(DateTime AVBBDT){
	this.AVBBDT = AVBBDT;
}
public 
void setAVPSOR(string AVPSOR){
	this.AVPSOR = AVPSOR;
}
public 
void setAVFUTO(string AVFUTO){
	this.AVFUTO = AVFUTO;
}

public 
void setAVDENC(string AVDENC){
	this.AVDENC = AVDENC;
}
public 
void setAVDREL(string AVDREL){
	this.AVDREL = AVDREL;
}
public
void setAVDDAT(DateTime AVDDAT){
	this.AVDDAT = AVDDAT;
}
public 
void setAVFUTE(string AVFUTE){
	this.AVFUTE = AVFUTE;
}
public 
void setAVDRWS2(string AVDRWS2){
	this.AVDRWS2 = AVDRWS2;
}
public 
void setAVDRWL2(string AVDRWL2){
	this.AVDRWL2 = AVDRWL2;
}
public 
void setAVDENC2(string AVDENC2){
	this.AVDENC2 = AVDENC2;
}
public 
void setAVDREL2(string AVDREL2){
	this.AVDREL2 = AVDREL2;
}
public
void setAVDDAT2(DateTime AVDDAT2){
	this.AVDDAT2 = AVDDAT2;
}
public 
void setAVFUTF(string AVFUTF){
	this.AVFUTF = AVFUTF;
}
public 
void setAVSTCL(string AVSTCL){
	this.AVSTCL = AVSTCL;
}
public 
void setAVVLCD(string AVVLCD){
	this.AVVLCD = AVVLCD;
}
public 
void setAVSPPP(decimal AVSPPP){
	this.AVSPPP = AVSPPP;
}
public 
void setAVSPPC(string AVSPPC){
	this.AVSPPC = AVSPPC;
}
public 
void setAVMPPP(decimal AVMPPP){
	this.AVMPPP = AVMPPP;
}
public 
void setAVMPPC(string AVMPPC){
	this.AVMPPC = AVMPPC;
}
public 
void setAVFLG01(string AVFLG01){
	this.AVFLG01 = AVFLG01;
}
public 
void setAVFLG02(string AVFLG02){
	this.AVFLG02 = AVFLG02;
}
public 
void setAVFLG03(string AVFLG03){
	this.AVFLG03 = AVFLG03;
}
public 
void setAVFLG04(string AVFLG04){
	this.AVFLG04 = AVFLG04;
}
public 
void setAVFLG05(string AVFLG05){
	this.AVFLG05 = AVFLG05;
}
public 
void setAVFLG06(string AVFLG06){
	this.AVFLG06 = AVFLG06;
}
public 
void setAVFLG07(string AVFLG07){
	this.AVFLG07 = AVFLG07;
}
public 
void setAVFLG08(string AVFLG08){
	this.AVFLG08 = AVFLG08;
}
public 
void setAVFLG09(string AVFLG09){
	this.AVFLG09 = AVFLG09;
}
public 
void setAVFLG10(string AVFLG10){
	this.AVFLG10 = AVFLG10;
}
public 
void setAVFUT01(string AVFUT01){
	this.AVFUT01 = AVFUT01;
}
public 
void setAVFUT02(string AVFUT02){
	this.AVFUT02 = AVFUT02;
}
public 
void setAVFUT03(string AVFUT03){
	this.AVFUT03 = AVFUT03;
}
public 
void setAVFUT04(string AVFUT04){
	this.AVFUT04 = AVFUT04;
}
public 
void setAVFUT05(string AVFUT05){
	this.AVFUT05 = AVFUT05;
}
public 
void setAVFUT06(string AVFUT06){
	this.AVFUT06 = AVFUT06;
}
public 
void setAVFUT07(string AVFUT07){
	this.AVFUT07 = AVFUT07;
}
public 
void setAVFUT08(string AVFUT08){
	this.AVFUT08 = AVFUT08;
}
public 
void setAVFUT09(string AVFUT09){
	this.AVFUT09 = AVFUT09;
}
public 
void setAVFUT10(string AVFUT10){
	this.AVFUT10 = AVFUT10;
}
public 
void setAVFUT11(string AVFUT11){
	this.AVFUT11 = AVFUT11;
}
public 
void setAVFUT12(string AVFUT12){
	this.AVFUT12 = AVFUT12;
}
public 
void setAVFUT13(string AVFUT13){
	this.AVFUT13 = AVFUT13;
}
public 
void setAVFUT14(string AVFUT14){
	this.AVFUT14 = AVFUT14;
}
public 
void setAVFUT15(string AVFUT15){
	this.AVFUT15 = AVFUT15;
}
public 
void setAVFUT16(string AVFUT16){
	this.AVFUT16 = AVFUT16;
}
public 
void setAVFUT17(string AVFUT17){
	this.AVFUT17 = AVFUT17;
}
public 
void setAVFUT18(string AVFUT18){
	this.AVFUT18 = AVFUT18;
}
public 
void setAVFUT19(string AVFUT19){
	this.AVFUT19 = AVFUT19;
}
public 
void setAVFUT20(string AVFUT20){
	this.AVFUT20 = AVFUT20;
}
public 
void setAVFUT21(string AVFUT21){
	this.AVFUT21 = AVFUT21;
}
public 
void setAVFUT22(string AVFUT22){
	this.AVFUT22 = AVFUT22;
}
public 
void setAVFUT23(string AVFUT23){
	this.AVFUT23 = AVFUT23;
}
public 
void setAVFUT24(string AVFUT24){
	this.AVFUT24 = AVFUT24;
}
public 
void setAVFUT25(string AVFUT25){
	this.AVFUT25 = AVFUT25;
}
public 
void setAVFUT26(decimal AVFUT26){
	this.AVFUT26 = AVFUT26;
}
public 
void setAVFUT27(decimal AVFUT27){
	this.AVFUT27 = AVFUT27;
}
public 
void setAVFUT28(decimal AVFUT28){
	this.AVFUT28 = AVFUT28;
}
public 
void setAVFUT29(decimal AVFUT29){
	this.AVFUT29 = AVFUT29;
}
public 
void setAVFUT30(decimal AVFUT30){
	this.AVFUT30 = AVFUT30;
}
public 
void set(decimal AVFUT31){
	this.AVFUT31 = AVFUT31;
}
public 
void setAVFUT32(decimal AVFUT32){
	this.AVFUT32 = AVFUT32;
}
public 
void setAVFUT33(decimal AVFUT33){
	this.AVFUT33 = AVFUT33;
}
public 
void setAVFUT34(decimal AVFUT34){
	this.AVFUT34 = AVFUT34;
}
public 
void setAVFUT35(decimal AVFUT35){
	this.AVFUT35 = AVFUT35;
}
public
void setAVFUT36(DateTime AVFUT36){
	this.AVFUT36 = AVFUT36;
}
public
void setAVFUT37(DateTime AVFUT37){
	this.AVFUT37 = AVFUT37;
}
public
void setAVFUT38(DateTime AVFUT38){
	this.AVFUT38 = AVFUT38;
}
public
void setAVFUT39(DateTime AVFUT39){
	this.AVFUT39 = AVFUT39;
}
public
void setAVFUT40(DateTime AVFUT40){
	this.AVFUT40 = AVFUT40;
}
public
void setAVFUT41(DateTime AVFUT41){
	this.AVFUT41 = AVFUT41;
}
public
void setAVFUT42(DateTime AVFUT42){
	this.AVFUT42 = AVFUT42;
}
public
void setAVFUT43(DateTime AVFUT43){
	this.AVFUT43 = AVFUT43;
}
public
void setAVFUT44(DateTime AVFUT44){
	this.AVFUT44 = AVFUT44;
}
public
void setAVFUT45(DateTime AVFUT45){
	this.AVFUT45 = AVFUT45;
}
public 
void setAVUDFT(string AVUDFT){
	this.AVUDFT = AVUDFT;
}
public 
void setAVFRML(string AVFRML){
	this.AVFRML = AVFRML;
}

//-------------------------------------------get add in 5.2
public
string getAVFUTC(){
	return this.AVFUTC;
}
public
string getAVFUTD(){
	return this.AVFUTD;
}
public
decimal getAVGTIN(){
	return this.AVGTIN;
}

public
string getAVDPLT(){
	return this.AVDPLT;
}

public
string getAVFUTK(){
	return this.AVFUTK;
}
public
string getAVFUTN(){
	return this.AVFUTN;
}
public
string getAVPPAP(){
	return this.AVPPAP;
}
public
string getAVCUSR(){
	return this.AVCUSR;
}
public
DateTime getAVCTME(){
	return this.AVCTME;
}
public
string getAVUUSR(){
	return this.AVUUSR;
}

public
DateTime getAVUDAT(){
	return this.AVUDAT;
}
public
DateTime getAVUTME(){
	return this.AVUTME;
}
public
string getAVSIZC(){
	return this.AVSIZC;
}
public
string getAVSTLC(){
	return this.AVSTLC;
}
public
string getAVCOLC(){
	return this.AVCOLC;
}
public
string getAVASSC(){
	return this.AVASSC;
}
public
string getAVSASC(){
	return this.AVSASC;
}
public
string getAVLCOIL(){
	return this.AVLCOIL;
}

public
string getAVGDFL(){
	return this.AVGDFL;
}
public
string getAVVDFL(){
	return this.AVVDFL;
}
public
string getAVWOQF(){
	return this.AVWOQF;
}
public
string getAVNMFC(){
	return this.AVNMFC;
}

public
decimal getAVFUTH(){
	return this.AVFUTH;
}

public
decimal getAVFUTI(){
	return this.AVFUTI;
}
public
string getAVFUTL(){
	return this.AVFUTL;
}
public
string getAVFUTM(){
	return this.AVFUTM;
}
public
string getAVFUTP(){
	return this.AVFUTP;
}
public
DateTime getAVFUTQ(){
	return this.AVFUTQ;
}
public
DateTime getAVFUTR(){
	return this.AVFUTR;
}

public
string getAVOLDD2(){
	return this.AVOLDD2;
}
public
decimal getAVFUTG(){
	return this.AVFUTG;
}
public
string getAVRECU(){
	return this.AVRECU;
}
public
decimal getAVFTMF(){
	return this.AVFTMF;
}
public
string getAVRECC(){
	return this.AVRECC;
}
public
string getAVFUTJ(){
	return this.AVFUTJ;
}
public
DateTime getAVSPDT(){
	return this.AVSPDT;
}
public
DateTime getAVBBDT(){
	return this.AVBBDT;
}
public
string getAVPSOR(){
	return this.AVPSOR;
}
public
string getAVFUTO(){
	return this.AVFUTO;
}

public
string getAVDENC(){
	return this.AVDENC;
}
public
string getAVDREL(){
	return this.AVDREL;
}
public
DateTime getAVDDAT(){
	return this.AVDDAT;
}
public
string getAVFUTE(){
	return this.AVFUTE;
}
public
string getAVDRWS2(){
	return this.AVDRWS2;
}
public
string getAVDRWL2(){
	return this.AVDRWL2;
}
public
string getAVDENC2(){
	return this.AVDENC2;
}
public
string getAVDREL2(){
	return this.AVDREL2;
}
public
DateTime getAVDDAT2(){
	return this.AVDDAT2;
}
public
string getAVFUTF(){
	return this.AVFUTF;
}
public
string getAVSTCL(){
	return this.AVSTCL;
}
public
string getAVVLCD(){
	return this.AVVLCD;
}
public
decimal getAVSPPP(){
	return this.AVSPPP;
}
public
string getAVSPPC(){
	return this.AVSPPC;
}
public
decimal getAVMPPP(){
	return this.AVMPPP;
}
public
string getAVMPPC(){
	return this.AVMPPC;
}
public
string getAVFLG01(){
	return this.AVFLG01;
}
public
string getAVFLG02(){
	return this.AVFLG02;
}
public
string getAVFLG03(){
	return this.AVFLG03;
}
public
string getAVFLG04(){
	return this.AVFLG04;
}
public
string getAVFLG05(){
	return this.AVFLG05;
}
public
string getAVFLG06(){
	return this.AVFLG06;
}
public
string getAVFLG07(){
	return this.AVFLG07;
}
public
string getAVFLG08(){
	return this.AVFLG08;
}
public
string getAVFLG09(){
	return this.AVFLG09;
}
public
string getAVFLG10(){
	return this.AVFLG10;
}
public
string getAVFUT01(){
	return this.AVFUT01;
}
public
string getAVFUT02(){
	return this.AVFUT02;
}
public
string getAVFUT03(){
	return this.AVFUT03;
}
public
string getAVFUT04(){
	return this.AVFUT04;
}
public
string getAVFUT05(){
	return this.AVFUT05;
}
public
string getAVFUT06(){
	return this.AVFUT06;
}
public
string getAVFUT07(){
	return this.AVFUT07;
}
public
string getAVFUT08(){
	return this.AVFUT08;
}
public
string getAVFUT09(){
	return this.AVFUT09;
}
public
string getAVFUT10(){
	return this.AVFUT10;
}
public
string getAVFUT11(){
	return this.AVFUT11;
}
public
string getAVFUT12(){
	return this.AVFUT12;
}
public
string getAVFUT13(){
	return this.AVFUT13;
}
public
string getAVFUT14(){
	return this.AVFUT14;
}
public
string getAVFUT15(){
	return this.AVFUT15;
}
public
string getAVFUT16(){
	return this.AVFUT16;
}
public
string getAVFUT17(){
	return this.AVFUT17;
}
public
string getAVFUT18(){
	return this.AVFUT18;
}
public
string getAVFUT19(){
	return this.AVFUT19;
}
public
string getAVFUT20(){
	return this.AVFUT20;
}
public
string getAVFUT21(){
	return this.AVFUT21;
}
public
string getAVFUT22(){
	return this.AVFUT22;
}
public
string getAVFUT23(){
	return this.AVFUT23;
}
public
string getAVFUT24(){
	return this.AVFUT24;
}
public
string getAVFUT25(){
	return this.AVFUT25;
}
public
decimal getAVFUT26(){
	return this.AVFUT26;
}
public
decimal getAVFUT27(){
	return this.AVFUT27;
}
public
decimal getAVFUT28(){
	return this.AVFUT28;
}
public
decimal getAVFUT29(){
	return this.AVFUT29;
}
public
decimal getAVFUT30(){
	return this.AVFUT30;
}
public
decimal getAVFUT31(){
	return this.AVFUT31;
}
 
public
decimal getAVFUT32(){
	return this.AVFUT32;
}
 
public
decimal getAVFUT33(){
	return this.AVFUT33;
}
 
public
decimal getAVFUT34(){
	return this.AVFUT34;
}
 
public
decimal getAVFUT35(){
	return this.AVFUT35;
}
 
public
DateTime getAVFUT36(){
	return this.AVFUT36;
}
public
DateTime getAVFUT37(){
	return this.AVFUT37;
}
public
DateTime getAVFUT38(){
	return this.AVFUT38;
}
public
DateTime getAVFUT39(){
	return this.AVFUT39;
}
public
DateTime getAVFUT40(){
	return this.AVFUT40;
}
public
DateTime getAVFUT41(){
	return this.AVFUT41;
}
public
DateTime getAVFUT42(){
	return this.AVFUT42;
}
public
DateTime getAVFUT43(){
	return this.AVFUT43;
}
public
DateTime getAVFUT44(){
	return this.AVFUT44;
}
public
DateTime getAVFUT45(){
	return this.AVFUT45;
}
public
string getAVUDFT(){
	return this.AVUDFT;
}
public
string getAVFRML(){
	return this.AVFRML;
}


//----------------------------------------------
public
string getAVPART(){
	return AVPART;
}

public
string getAVDISC(){
	return AVDISC;
}

public
decimal getAVLEAD(){
	return AVLEAD;
}

public
string getAVSCDT(){
	return AVSCDT;
}

public
string getAVMAJG(){
	return AVMAJG;
}

public
string getAVMING(){
	return AVMING;
}

public
string getAVDES1(){
	return AVDES1;
}

public
string getAVDES2(){
	return AVDES2;
}

public
string getAVUNTI(){
	return AVUNTI;
}

public
string getAVBK01(){
	return AVBK01;
}

public
string getAVTYPE(){
	return AVTYPE;
}

public
decimal getAVTOTP(){
	return AVTOTP;
}

public
decimal getAVSHRK(){
	return AVSHRK;
}

public
string getAVBILL(){
	return AVBILL;
}

public
string getAVTAXR(){
	return AVTAXR;
}

public
decimal getAVOPTR(){
	return AVOPTR;
}

public
decimal getAVMULT(){
	return AVMULT;
}

public
decimal getAVQTYP(){
	return AVQTYP;
}

public
decimal getAVQTYA(){
	return AVQTYA;
}

public
decimal getAVQTYH(){
	return AVQTYH;
}

public
decimal getAVMINQ(){
	return AVMINQ;
}

public
decimal getAVMAXQ(){
	return AVMAXQ;
}

public
decimal getAVYTDU(){
	return AVYTDU;
}

public
decimal getAVYTD1(){
	return AVYTD1;
}

public
decimal getAVYTD2(){
	return AVYTD2;
}

public
string getAVCUST(){
	return AVCUST;
}

public
string getAVCORG(){
	return AVCORG;
}

public
string getAVPLAN(){
	return AVPLAN;
}

public
string getAVCPT(){
	return AVCPT;
}

public
string getAVREV(){
	return AVREV;
}

public
decimal getAVPRUN(){
	return AVPRUN;
}

public
string getAVGLED(){
	return AVGLED;
}

public
string getAVENGC(){
	return AVENGC;
}

public
decimal getAVESTV(){
	return AVESTV;
}

public
string getAVGLCD(){
	return AVGLCD;
}

public
string getAVFEDC(){
	return AVFEDC;
}

public
string getAVMAJS(){
	return AVMAJS;
}

public
string getAVMINS(){
	return AVMINS;
}

public
DateTime getAVLDAT(){
	return AVLDAT;
}

public
decimal getAVMINR(){
	return AVMINR;
}

public
decimal getAVOQTY(){
	return AVOQTY;
}

public
string getAVCNTR(){
	return AVCNTR;
}

public
string getAVBK04(){
	return AVBK04;
}

public
string getAVREVL(){
	return AVREVL;
}

public
DateTime getAVRDAT(){
	return AVRDAT;
}

public
decimal getAVNWHT(){
	return AVNWHT;
}

public
string getAVDES3(){
	return AVDES3;
}

public
string getAVHARM(){
	return AVHARM;
}

public
string getAVBK06(){
	return AVBK06;
}

public
string getAVOLDD(){
	return AVOLDD;
}

public
string getAVDRWS(){
	return AVDRWS;
}

public
string getAVDRWL(){
	return AVDRWL;
}

public
string getAVUNTP(){
	return AVUNTP;
}

public
decimal getAVLVL(){
	return AVLVL;
}

public
decimal getAVMOQT(){
	return AVMOQT;
}

public
decimal getAVQTPO(){
	return AVQTPO;
}

public
decimal getAVPACK(){
	return AVPACK;
}

public
string getAVPACU(){
	return AVPACU;
}

public
decimal getAVPRPT(){
	return AVPRPT;
}

public
string getAVNWUN(){
	return AVNWUN;
}

public
decimal getAVSVOL(){
	return AVSVOL;
}

public
string getAVSVUN(){
	return AVSVUN;
}

public
string getAVKITC(){
	return AVKITC;
}

public
string getAVUPCC(){
	return AVUPCC;
}

public
string getAVABCC(){
	return AVABCC;
}

public
string getAVCLSS(){
	return AVCLSS;
}

public
string getAVSTAT(){
	return AVSTAT;
}

public
string getAVINVT(){
	return AVINVT;
}

public
string getAVLOTF(){
	return AVLOTF;
}

public
string getAVSERF(){
	return AVSERF;
}

public
string getAVPROC(){
	return AVPROC;
}

public
string getAVCOIL(){
	return AVCOIL;
}

public
string getAVMSPC(){
	return AVMSPC;
}

public
string getAVLRSP(){
	return AVLRSP;
}

public
decimal getAVLRSC(){
	return AVLRSC;
}

public
string getAVLRSF(){
	return AVLRSF;
}

public
string getAVLRMP(){
	return AVLRMP;
}

public
decimal getAVLRMC(){
	return AVLRMC;
}

public
string getAVLRMF(){
	return AVLRMF;
}

public
string getAVLWSP(){
	return AVLWSP;
}

public
decimal getAVLWSC(){
	return AVLWSC;
}

public
string getAVLWSF(){
	return AVLWSF;
}

public
string getAVLCSP(){
	return AVLCSP;
}

public
decimal getAVLCSC(){
	return AVLCSC;
}

public
string getAVLCSF(){
	return AVLCSF;
}

public
string getAVLCMP(){
	return AVLCMP;
}

public
decimal getAVLCMC(){
	return AVLCMC;
}

public
string getAVLCMF(){
	return AVLCMF;
}

public
decimal getAVLSSC(){
	return AVLSSC;
}

public
string getAVLSSF(){
	return AVLSSF;
}

public
string getAVLSMP(){
	return AVLSMP;
}

public
decimal getAVLSMC(){
	return AVLSMC;
}

public
string getAVLSMF(){
	return AVLSMF;
}

public
decimal getAVMPCK(){
	return AVMPCK;
}

public
string getAVMPKU(){
	return AVMPKU;
}

public
string getAVORIG(){
	return AVORIG;
}

public
decimal getAVALTF(){
	return AVALTF;
}

public
string getAVUVER(){
	return AVUVER;
}

public
string getAVCATA(){
	return AVCATA;
}

public
DateTime getAVCDAT(){
	return AVCDAT;
}

public
decimal getAVPERC(){
	return AVPERC;
}

public
string getAVDBUY(){
	return AVDBUY;
}

public
decimal getAVSLIF(){
	return AVSLIF;
}

public
string getAVREAS(){
	return AVREAS;
}

public
string getAVFUT1(){
	return AVFUT1;
}

public
string getAVFUT2(){
	return AVFUT2;
}

public
string getAVFUT3(){
	return AVFUT3;
}

public
string getAVFUT4(){
	return AVFUT4;
}

public
string getAVFUT5(){
	return AVFUT5;
}

public
decimal getAVFUT6(){
	return AVFUT6;
}

public
string getAVFUT7(){
	return AVFUT7;
}

public
string getAVFUT8(){
	return AVFUT8;
}

public
string getAVFUT9(){
	return AVFUT9;
}

public
string getAVFUTA(){
	return AVFUTA;
}

public
string getAVFUTB(){
	return AVFUTB;
}

} // class

} // namespace