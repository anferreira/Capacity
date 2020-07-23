using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{


public 
class StkMPDataBase : GenericDataBaseElement{

private string AWPART;
private string AWDISC;
private string AWGLDC;
private string AWSCDT;
private string AWMAJG;
private string AWMING;
private string AWDES1;
private string AWDES2;
private string AWUNTI;
private string AWBK01;
private string AWTYPE;
private string AWUNTO;
private decimal AWCONV;
private string AWREQC;
private decimal AWOPTR;
private decimal AWLEAD;
private decimal AWQTYO;
private decimal AWQTYA;
private decimal AWQTYH;
private decimal AWMINQ;
private decimal AWMAXQ;
private decimal AWYTDU;
private decimal AWYTD1;
private decimal AWYTD2;
private string AWVEND;
private string AWCORG;
private string AWVPT;
private string AWHARM;
private string AWGLED;
private string AWBK02;
private string AWTAXR;
private string AWFEDC;
private string AWMAJS;
private string AWMINS;
private DateTime AWLDAT;
private decimal AWNWHT;
private string AWBK03;
private decimal AWOQTY;
private string AWCNTR;
private decimal AWOLA;
private string AWBK04;
private string AWDES3;
private string AWBK05;
private string AWUNTP;
private decimal AWSHRK;
private decimal AWLVL;
private decimal AWMOQT;
private decimal AWPACK;
private string AWPACU;
private decimal AWPRPT;
private string AWBUYR;
private string AWAUTY;
private string AWNWUN;
private decimal AWSVOL;
private string AWSVUN;
private decimal AWMPQT;
private string AWUPCC;
private string AWABCC;
private string AWCLSS;
private string AWSTAT;
private string AWINVT;
private string AWLOTF;
private string AWSERF;
private string AWPROC;
private string AWOLDD;
private string AWDRWS;
private string AWDRWL;
private string AWREVL;
private string AWREV;
private string AWENGC;
private DateTime AWRDAT;
private string AWCOIL;
private string AWMSPC;
private string AWLRSP;
private decimal AWLRSC;
private string AWLRSF;
private string AWLRMP;
private decimal AWLRMC;
private string AWLRMF;
private string AWLWSP;
private decimal AWLWSC;
private string AWLWSF;
private string AWLCSP;
private decimal AWLCSC;
private string AWLCSF;
private string AWLCMP;
private decimal AWLCMC;
private string AWLCMF;
private decimal AWLSSC;
private string AWLSSF;
private string AWLSMP;
private decimal AWLSMC;
private string AWLSMF;
private decimal AWMPCK;
private string AWMPKU;
private string AWORIG;
private decimal AWALTF;
private string AWUVER;
private string AWCATA;
private DateTime AWCDAT;
private decimal AWPERC;
private string AWDBUY;
private decimal AWSLIF;
private string AWREAS;
private string AWFUT1;
private string AWFUT2;
private string AWFUT3;
private string AWFUT4;
private string AWFUT5;
private decimal AWFUT6;
private string AWFUT7;
private string AWFUT8;
private string AWFUT9;
private string AWFUTA;
private string AWFUTB;
//-----------------add in 5.2
private string AWFUTC ;
private string AWFUTD ;
private decimal AWGTIN ;
private string AWFUTK ;
private string AWFUTN ;
private string AWPPAP ;
private string AWDPLT ;
private string AWGDFL ;
private string AWVDFL ;
private string AWWOQF ;
private string AWLCOIL ;
private string AWNMFC ;
private string AWSIZC ;
private string AWSTLC ;
private string AWCOLC ;
private string AWASSC ;
private string AWSASC ;
private string AWCUSR ;
private DateTime AWCTME ;
private string AWUUSR ;
private DateTime AWUDAT ;
private DateTime AWUTME ;
private decimal AWFUTH ;
private decimal AWFUTI ;
private string AWFUTL ;
private string AWFUTM ;
private string AWFUTO ;
private string AWFUTP ;
private DateTime AWFUTQ ;
private DateTime AWFUTR ;
private string AWOLDD2 ;
private string AWFUTJ ;
private decimal AWFUTG ;
private decimal AWFTMF ;
private string AWRECU ;
private string AWRECC ;
private string AWPSOR ;
private string AWDENC ;
private string AWDREL ;
private DateTime AWDDAT ;
private string AWDRWS2 ;
private string AWDRWL2 ;
private string AWDENC2 ;
private string AWDREL2 ;
private DateTime AWDDAT2 ;
private string AWFUTE ;
private string AWFUTF ;
private string AWSTCL ;
private string AWVLCD ;
private decimal AWSPPP ;
private string AWSPPC ;
private decimal AWMPPP ;
private string AWMPPC ;
private string AWFLG01 ;
private string AWFLG02 ;
private string AWFLG03 ;
private string AWFLG04 ;
private string AWFLG05 ;
private string AWFLG06 ;
private string AWFLG07 ;
private string AWFLG08 ;
private string AWFLG09 ;
private string AWFLG10 ;
private string AWFUT01 ;
private string AWFUT02 ;
private string AWFUT03 ;
private string AWFUT04 ;
private string AWFUT05 ;
private string AWFUT06 ;
private string AWFUT07 ;
private string AWFUT08 ;
private string AWFUT09 ;
private string AWFUT10 ;
private string AWFUT11 ;
private string AWFUT12 ;
private string AWFUT13 ;
private string AWFUT14 ;
private string AWFUT15 ;
private string AWFUT16 ;
private string AWFUT17 ;
private string AWFUT18 ;
private string AWFUT19 ;
private string AWFUT20 ;
private string AWFUT21 ;
private string AWFUT22 ;
private string AWFUT23 ;
private string AWFUT24 ;
private string AWFUT25 ;
private decimal AWFUT26 ;
private decimal AWFUT27 ;
private decimal AWFUT28 ;
private decimal AWFUT29 ;
private decimal AWFUT30 ;
private decimal AWFUT31 ;
private decimal AWFUT32 ;
private decimal AWFUT33 ;
private decimal AWFUT34 ;
private decimal AWFUT35 ;
private DateTime AWFUT36 ;
private DateTime AWFUT37 ;
private DateTime AWFUT38 ;
private DateTime AWFUT39 ;
private DateTime AWFUT40 ;
private DateTime AWFUT41 ;
private DateTime AWFUT42 ;
private DateTime AWFUT43 ;
private DateTime AWFUT44 ;
private DateTime AWFUT45 ;
private string AWUDFT ;
private string AWFRML ;
//-----------------

public
StkMPDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){
}
	
public
void load(NotNullDataReader reader){
	if (Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_2)){
		//delete columns
		this.AWMAJG = "";
		this.AWMING = "";
		this.AWUNTI = "";
		this.AWQTYO = 0;
		this.AWQTYA = 0;
		this.AWQTYH = 0;
		this.AWMINQ = 0;
		this.AWMAXQ = 0;
		this.AWYTDU = 0;
		this.AWYTD1 = 0;
		this.AWYTD2 = 0;
		this.AWMAJS = "";
		this.AWOQTY = 0;
		this.AWDES3 = "";
		//-----------------add in 5.2
		this.AWFUTC = reader.GetString("AWFUTC");
		this.AWFUTD = reader.GetString("AWFUTD");
		this.AWGTIN = reader.GetDecimal("AWGTIN");
		this.AWFUTK = reader.GetString("AWFUTK");
		this.AWFUTN = reader.GetString("AWFUTN");
		this.AWPPAP = reader.GetString("AWPPAP");
		this.AWDPLT = reader.GetString("AWDPLT");
		this.AWGDFL = reader.GetString("AWGDFL");
		this.AWVDFL = reader.GetString("AWVDFL");
		this.AWWOQF = reader.GetString("AWWOQF");
		this.AWLCOIL = reader.GetString("AWLCOIL");
		this.AWNMFC = reader.GetString("AWNMFC");
		this.AWSIZC = reader.GetString("AWSIZC");
		this.AWSTLC = reader.GetString("AWSTLC");
		this.AWCOLC = reader.GetString("AWCOLC");
		this.AWASSC = reader.GetString("AWASSC");
		this.AWSASC = reader.GetString("AWSASC");
		this.AWCUSR = reader.GetString("AWCUSR");
		if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
			this.AWCTME = DateUtil.parseDate(reader.GetString("AWCTME"), DateUtil.YYYYMMDD_AS);
			this.AWUDAT = DateUtil.parseDate(reader.GetString("AWUDAT"), DateUtil.YYYYMMDD_AS);
			this.AWUTME = DateUtil.parseDate(reader.GetString("AWUTME"), DateUtil.YYYYMMDD_AS);
			this.AWFUTQ = DateUtil.parseDate(reader.GetString("AWFUTQ"), DateUtil.YYYYMMDD_AS);
			this.AWFUTR = DateUtil.parseDate(reader.GetString("AWFUTR"), DateUtil.YYYYMMDD_AS);
			this.AWDDAT = DateUtil.parseDate(reader.GetString("AWDDAT"), DateUtil.YYYYMMDD_AS);
			this.AWDDAT2 = DateUtil.parseDate(reader.GetString("AWDDAT2"), DateUtil.YYYYMMDD_AS);
			this.AWFUT36 = DateUtil.parseDate(reader.GetString("AWFUT36"), DateUtil.YYYYMMDD_AS);
			this.AWFUT37 = DateUtil.parseDate(reader.GetString("AWFUT37"), DateUtil.YYYYMMDD_AS);
			this.AWFUT38 = DateUtil.parseDate(reader.GetString("AWFUT38"), DateUtil.YYYYMMDD_AS);
			this.AWFUT39 = DateUtil.parseDate(reader.GetString("AWFUT39"), DateUtil.YYYYMMDD_AS);
			this.AWFUT40 = DateUtil.parseDate(reader.GetString("AWFUT40"), DateUtil.YYYYMMDD_AS);
			this.AWFUT41 = DateUtil.parseDate(reader.GetString("AWFUT41"), DateUtil.YYYYMMDD_AS);
			this.AWFUT42 = DateUtil.parseDate(reader.GetString("AWFUT42"), DateUtil.YYYYMMDD_AS);
			this.AWFUT43 = DateUtil.parseDate(reader.GetString("AWFUT43"), DateUtil.YYYYMMDD_AS);
			this.AWFUT44 = DateUtil.parseDate(reader.GetString("AWFUT44"), DateUtil.YYYYMMDD_AS);
			this.AWFUT45 = DateUtil.parseDate(reader.GetString("AWFUT45"), DateUtil.YYYYMMDD_AS);
		}
		else{
			this.AWCTME = reader.GetDateTime("AWCTME");
			this.AWUDAT = reader.GetDateTime("AWUDAT");
			this.AWUTME = reader.GetDateTime("AWUTME");
			this.AWFUTQ = reader.GetDateTime("AWFUTQ");
			this.AWFUTR = reader.GetDateTime("AWFUTR");
			this.AWDDAT = reader.GetDateTime("AWDDAT");
			this.AWDDAT2 = reader.GetDateTime("AWDDAT2");
			this.AWFUT36 = reader.GetDateTime("AWFUT36");
			this.AWFUT37 = reader.GetDateTime("AWFUT37");
			this.AWFUT38 = reader.GetDateTime("AWFUT38");
			this.AWFUT39 = reader.GetDateTime("AWFUT39");
			this.AWFUT40 = reader.GetDateTime("AWFUT40");
			this.AWFUT41 = reader.GetDateTime("AWFUT41");
			this.AWFUT42 = reader.GetDateTime("AWFUT42");
			this.AWFUT43 = reader.GetDateTime("AWFUT43");
			this.AWFUT44 = reader.GetDateTime("AWFUT44");
			this.AWFUT45 = reader.GetDateTime("AWFUT45");
		}
		this.AWUUSR = reader.GetString("AWUUSR");
		this.AWFUTH = reader.GetDecimal("AWFUTH");
		this.AWFUTI = reader.GetDecimal("AWFUTI");
		this.AWFUTL = reader.GetString("AWFUTL");
		this.AWFUTM = reader.GetString("AWFUTM");
		this.AWFUTO = reader.GetString("AWFUTO");
		this.AWFUTP = reader.GetString("AWFUTP");
		this.AWOLDD2 = reader.GetString("AWOLDD2");
		this.AWFUTJ = reader.GetString("AWFUTJ");
		this.AWFUTG = reader.GetDecimal("AWFUTG");
		this.AWFTMF = reader.GetDecimal("AWFTMF");
		this.AWRECU = reader.GetString("AWRECU");
		this.AWRECC = reader.GetString("AWRECC");
		this.AWPSOR = reader.GetString("AWPSOR");
		this.AWDENC = reader.GetString("AWDENC");
		this.AWDREL = reader.GetString("AWDREL");
		this.AWDRWS2 = reader.GetString("AWDRWS2");
		this.AWDRWL2 = reader.GetString("AWDRWL2");
		this.AWDENC2 = reader.GetString("AWDENC2");
		this.AWDREL2 = reader.GetString("AWDREL2");
		this.AWFUTE = reader.GetString("AWFUTE");
		this.AWFUTF = reader.GetString("AWFUTF");
		this.AWSTCL = reader.GetString("AWSTCL");
		this.AWVLCD = reader.GetString("AWVLCD");
		this.AWSPPP = reader.GetDecimal("AWSPPP");
		this.AWSPPC = reader.GetString("AWSPPC");
		this.AWMPPP = reader.GetDecimal("AWMPPP");
		this.AWMPPC = reader.GetString("AWMPPC");
		this.AWFLG01 = reader.GetString("AWFLG01");
		this.AWFLG02 = reader.GetString("AWFLG02");
		this.AWFLG03 = reader.GetString("AWFLG03");
		this.AWFLG04 = reader.GetString("AWFLG04");
		this.AWFLG05 = reader.GetString("AWFLG05");
		this.AWFLG06 = reader.GetString("AWFLG06");
		this.AWFLG07 = reader.GetString("AWFLG07");
		this.AWFLG08 = reader.GetString("AWFLG08");
		this.AWFLG09 = reader.GetString("AWFLG09");
		this.AWFLG10 = reader.GetString("AWFLG10");
		this.AWFUT01 = reader.GetString("AWFUT01");
		this.AWFUT02 = reader.GetString("AWFUT02");
		this.AWFUT03 = reader.GetString("AWFUT03");
		this.AWFUT04 = reader.GetString("AWFUT04");
		this.AWFUT05 = reader.GetString("AWFUT05");
		this.AWFUT06 = reader.GetString("AWFUT06");
		this.AWFUT07 = reader.GetString("AWFUT07");
		this.AWFUT08 = reader.GetString("AWFUT08");
		this.AWFUT09 = reader.GetString("AWFUT09");
		this.AWFUT10 = reader.GetString("AWFUT10");
		this.AWFUT11 = reader.GetString("AWFUT11");
		this.AWFUT12 = reader.GetString("AWFUT12");
		this.AWFUT13 = reader.GetString("AWFUT13");
		this.AWFUT14 = reader.GetString("AWFUT14");
		this.AWFUT15 = reader.GetString("AWFUT15");
		this.AWFUT16 = reader.GetString("AWFUT16");
		this.AWFUT17 = reader.GetString("AWFUT17");
		this.AWFUT18 = reader.GetString("AWFUT18");
		this.AWFUT19 = reader.GetString("AWFUT19");
		this.AWFUT20 = reader.GetString("AWFUT20");
		this.AWFUT21 = reader.GetString("AWFUT21");
		this.AWFUT22 = reader.GetString("AWFUT22");
		this.AWFUT23 = reader.GetString("AWFUT23");
		this.AWFUT24 = reader.GetString("AWFUT24");
		this.AWFUT25 = reader.GetString("AWFUT25");
		this.AWFUT26 = reader.GetDecimal("AWFUT26");
		this.AWFUT27 = reader.GetDecimal("AWFUT27");
		this.AWFUT28 = reader.GetDecimal("AWFUT28");
		this.AWFUT29 = reader.GetDecimal("AWFUT29");
		this.AWFUT30 = reader.GetDecimal("AWFUT30");
		this.AWFUT31 = reader.GetDecimal("AWFUT31");
		this.AWFUT32 = reader.GetDecimal("AWFUT32");
		this.AWFUT33 = reader.GetDecimal("AWFUT33");
		this.AWFUT34 = reader.GetDecimal("AWFUT34");
		this.AWFUT35 = reader.GetDecimal("AWFUT35");
		this.AWUDFT = reader.GetString("AWUDFT");
		this.AWFRML = reader.GetString("AWFRML");
	}else{//CMS_VERSION != CMS_VERSION_5_2
		//-----------------remove in 5.2
		this.AWMAJG = reader.GetString("AWMAJG");
		this.AWMING = reader.GetString("AWMING");
		this.AWUNTI = reader.GetString("AWUNTI");
		this.AWQTYO = reader.GetDecimal("AWQTYO");
		this.AWQTYA = reader.GetDecimal("AWQTYA");
		this.AWQTYH = reader.GetDecimal("AWQTYH");
		this.AWMINQ = reader.GetDecimal("AWMINQ");
		this.AWMAXQ = reader.GetDecimal("AWMAXQ");
		this.AWYTDU = reader.GetDecimal("AWYTDU");
		this.AWYTD1 = reader.GetDecimal("AWYTD1");
		this.AWYTD2 = reader.GetDecimal("AWYTD2");
		this.AWMAJS = reader.GetString("AWMAJS");
		this.AWOQTY = reader.GetDecimal("AWOQTY");
		this.AWDES3 = reader.GetString("AWDES3");
		//-----------------add in 5.2		
		this.AWFUTC = "";
		this.AWFUTD = "";
		this.AWGTIN = 0;
		this.AWFUTK = "";
		this.AWFUTN = "";
		this.AWPPAP = "";
		this.AWDPLT = "";
		this.AWGDFL = "";
		this.AWVDFL = "";
		this.AWWOQF = "";
		this.AWLCOIL = "";
		this.AWNMFC = "";
		this.AWSIZC = "";
		this.AWSTLC = "";
		this.AWCOLC = "";
		this.AWASSC = "";
		this.AWSASC = "";
		this.AWCUSR = "";
		this.AWCTME = DateTime.MinValue;
		this.AWUDAT = DateTime.MinValue;
		this.AWUTME = DateTime.MinValue;
		this.AWFUTQ = DateTime.MinValue;
		this.AWFUTR = DateTime.MinValue;
		this.AWDDAT = DateTime.MinValue;
		this.AWDDAT2 = DateTime.MinValue;
		this.AWFUT36 = DateTime.MinValue;
		this.AWFUT37 = DateTime.MinValue;
		this.AWFUT38 = DateTime.MinValue;
		this.AWFUT39 = DateTime.MinValue;
		this.AWFUT40 = DateTime.MinValue;
		this.AWFUT41 = DateTime.MinValue;
		this.AWFUT42 = DateTime.MinValue;
		this.AWFUT43 = DateTime.MinValue;
		this.AWFUT44 = DateTime.MinValue;
		this.AWFUT45 = DateTime.MinValue;
		this.AWUUSR = "";
		this.AWFUTH = 0;
		this.AWFUTI = 0;
		this.AWFUTL = "";
		this.AWFUTM = "";
		this.AWFUTO = "";
		this.AWFUTP = "";
		this.AWOLDD2 = "";
		this.AWFUTJ = "";
		this.AWFUTG = 0;
		this.AWFTMF = 0;
		this.AWRECU = "";
		this.AWRECC = "";
		this.AWPSOR = "";
		this.AWDENC = "";
		this.AWDREL = "";
		this.AWDRWS2 = "";
		this.AWDRWL2 = "";
		this.AWDENC2 = "";
		this.AWDREL2 = "";
		this.AWFUTE = "";
		this.AWFUTF = "";
		this.AWSTCL = "";
		this.AWVLCD = "";
		this.AWSPPP = 0;
		this.AWSPPC = "";
		this.AWMPPP = 0;
		this.AWMPPC = "";
		this.AWFLG01 = "";
		this.AWFLG02 = "";
		this.AWFLG03 = "";
		this.AWFLG04 = "";
		this.AWFLG05 = "";
		this.AWFLG06 = "";
		this.AWFLG07 = "";
		this.AWFLG08 = "";
		this.AWFLG09 = "";
		this.AWFLG10 = "";
		this.AWFUT01 = "";
		this.AWFUT02 = "";
		this.AWFUT03 = "";
		this.AWFUT04 = "";
		this.AWFUT05 = "";
		this.AWFUT06 = "";
		this.AWFUT07 = "";
		this.AWFUT08 = "";
		this.AWFUT09 = "";
		this.AWFUT10 = "";
		this.AWFUT11 = "";
		this.AWFUT12 = "";
		this.AWFUT13 = "";
		this.AWFUT14 = "";
		this.AWFUT15 = "";
		this.AWFUT16 = "";
		this.AWFUT17 = "";
		this.AWFUT18 = "";
		this.AWFUT19 = "";
		this.AWFUT20 = "";
		this.AWFUT21 = "";
		this.AWFUT22 = "";
		this.AWFUT23 = "";
		this.AWFUT24 = "";
		this.AWFUT25 = "";
		this.AWFUT26 = 0;
		this.AWFUT27 = 0;
		this.AWFUT28 = 0;
		this.AWFUT29 = 0;
		this.AWFUT30 = 0;
		this.AWFUT31 = 0;
		this.AWFUT32 = 0;
		this.AWFUT33 = 0;
		this.AWFUT34 = 0;
		this.AWFUT35 = 0;
		this.AWUDFT = "";
		this.AWFRML = "";
	}
	this.AWPART = reader.GetString("AWPART");
	this.AWDISC = reader.GetString("AWDISC");
	this.AWGLDC = reader.GetString("AWGLDC");
	this.AWSCDT = reader.GetString("AWSCDT");
	this.AWDES1 = reader.GetString("AWDES1");
	this.AWDES2 = reader.GetString("AWDES2");
	this.AWBK01 = reader.GetString("AWBK01");
	this.AWTYPE = reader.GetString("AWTYPE");
	this.AWUNTO = reader.GetString("AWUNTO");
	this.AWCONV = reader.GetDecimal("AWCONV");
	this.AWREQC = reader.GetString("AWREQC");
	this.AWOPTR = reader.GetDecimal("AWOPTR");
	this.AWLEAD = reader.GetDecimal("AWLEAD");
	this.AWVEND = reader.GetString("AWVEND");
	this.AWCORG = reader.GetString("AWCORG");
	this.AWHARM = reader.GetString("AWHARM");
	this.AWGLED = reader.GetString("AWGLED");
	this.AWBK02 = reader.GetString("AWBK02");
	this.AWTAXR = reader.GetString("AWTAXR");
	this.AWFEDC = reader.GetString("AWFEDC");
	
	this.AWMINS = reader.GetString("AWMINS");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.AWLDAT = DateUtil.parseDate(reader.GetString(34), DateUtil.YYYYMMDD_AS);
	else
		this.AWLDAT = reader.GetDateTime("AWLDAT");
	this.AWNWHT = reader.GetDecimal("AWNWHT");
	this.AWBK03 = reader.GetString("AWBK03");
	
	this.AWCNTR = reader.GetString("AWCNTR");
	this.AWOLA = reader.GetDecimal("AWOLA");
	this.AWBK04 = reader.GetString("AWBK04");

	this.AWBK05 = reader.GetString("AWBK05");
	this.AWUNTP = reader.GetString("AWUNTP");
	this.AWSHRK = reader.GetDecimal("AWSHRK");
	this.AWLVL = reader.GetDecimal("AWLVL");
	this.AWMOQT = reader.GetDecimal("AWMOQT");
	this.AWPACK = reader.GetDecimal("AWPACK");
	this.AWPACU = reader.GetString("AWPACU");
	this.AWPRPT = reader.GetDecimal("AWPRPT");
	this.AWBUYR = reader.GetString("AWBUYR");
	this.AWAUTY = reader.GetString("AWAUTY");
	this.AWNWUN = reader.GetString("AWNWUN");
	this.AWSVOL = reader.GetDecimal("AWSVOL");
	this.AWSVUN = reader.GetString("AWSVUN");
	this.AWMPQT = reader.GetDecimal("AWMPQT");
	this.AWUPCC = reader.GetString("AWUPCC");
	this.AWABCC = reader.GetString("AWABCC");
	this.AWCLSS = reader.GetString("AWCLSS");
	this.AWSTAT = reader.GetString("AWSTAT");
	if (AWSTAT.Equals(String.Empty))
		this.AWSTAT = "A";
	this.AWINVT = reader.GetString("AWINVT");
	this.AWLOTF = reader.GetString("AWLOTF");
	this.AWSERF = reader.GetString("AWSERF");
	this.AWPROC = reader.GetString("AWPROC");
	this.AWOLDD = reader.GetString("AWOLDD");
	this.AWDRWS = reader.GetString("AWDRWS");
	this.AWDRWL = reader.GetString("AWDRWL");
	this.AWREVL = reader.GetString("AWREVL");

	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE){
		this.AWVPT = reader.GetString("AWVPT#");
		this.AWREV = reader.GetString("AWREV#");
	}else{
		this.AWVPT = reader.GetString("AWVPT_");
		this.AWREV = reader.GetString(68);
	}

	this.AWENGC = reader.GetString("AWENGC");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.AWRDAT = DateUtil.parseDate(reader.GetString("AWRDAT"), DateUtil.YYYYMMDD_AS);
	else
		this.AWRDAT = reader.GetDateTime("AWRDAT");
	this.AWCOIL = reader.GetString("AWCOIL");
	this.AWMSPC = reader.GetString("AWMSPC");
	this.AWLRSP = reader.GetString("AWLRSP");
	this.AWLRSC = reader.GetDecimal("AWLRSC");
	this.AWLRSF = reader.GetString("AWLRSF");
	this.AWLRMP = reader.GetString("AWLRMP");
	this.AWLRMC = reader.GetDecimal("AWLRMC");
	this.AWLRMF = reader.GetString("AWLRMF");
	this.AWLWSP = reader.GetString("AWLWSP");
	this.AWLWSC = reader.GetDecimal("AWLWSC");
	this.AWLWSF = reader.GetString("AWLWSF");
	this.AWLCSP = reader.GetString("AWLCSP");
	this.AWLCSC = reader.GetDecimal("AWLCSC");
	this.AWLCSF = reader.GetString("AWLCSF");
	this.AWLCMP = reader.GetString("AWLCMP");
	this.AWLCMC = reader.GetDecimal("AWLCMC");
	this.AWLCMF = reader.GetString("AWLCMF");
	this.AWLSSC = reader.GetDecimal("AWLSSC");
	this.AWLSSF = reader.GetString("AWLSSF");
	this.AWLSMP = reader.GetString("AWLSMP");
	this.AWLSMC = reader.GetDecimal("AWLSMC");
	this.AWLSMF = reader.GetString("AWLSMF");
	this.AWMPCK = reader.GetDecimal("AWMPCK");
	this.AWMPKU = reader.GetString("AWMPKU");
	this.AWORIG = reader.GetString("AWORIG");
	this.AWALTF = reader.GetDecimal("AWALTF");
	this.AWUVER = reader.GetString("AWUVER");
	this.AWCATA = reader.GetString("AWCATA");
	if (dataBaseAccess.getConnectionType() == DataBaseAccess.CMS_DATABASE)
		this.AWCDAT = DateUtil.parseDate(reader.GetString("AWCDAT"), DateUtil.YYYYMMDD_AS);
	else
		this.AWCDAT = reader.GetDateTime("AWCDAT");
	this.AWPERC = reader.GetDecimal("AWPERC");
	this.AWDBUY = reader.GetString("AWDBUY");
	this.AWSLIF = reader.GetDecimal("AWSLIF");
	this.AWREAS = reader.GetString("AWREAS");
	this.AWFUT1 = reader.GetString("AWFUT1");
	this.AWFUT2 = reader.GetString("AWFUT2");
	this.AWFUT3 = reader.GetString("AWFUT3");
	this.AWFUT4 = reader.GetString("AWFUT4");
	this.AWFUT5 = reader.GetString("AWFUT5");
	this.AWFUT6 = reader.GetDecimal("AWFUT6");
	this.AWFUT7 = reader.GetString("AWFUT7");
	this.AWFUT8 = reader.GetString("AWFUT8");
	this.AWFUT9 = reader.GetString("AWFUT9");
	this.AWFUTA = reader.GetString("AWFUTA");
	this.AWFUTB = reader.GetString("AWFUTB");
}

public override
void write(){
	string sql = "";

	try{
		string number ="#";
		if (dataBaseAccess.getConnectionType() != DataBaseAccess.CMS_DATABASE)
			number ="_";

		if (Configuration.CmsVersion.Equals(Constants.CMS_VERSION_5_2)){
			sql = "insert into stkmp (AWPART,AWDISC,AWGLDC,AWSCDT,AWDES1,AWDES2,AWBK01,AWTYPE,AWUNTO,"+
				"AWCONV,AWREQC,AWOPTR,AWLEAD,AWVEND,AWCORG,AWVPT"+ number +","+
				"AWHARM,AWGLED,AWBK02,AWTAXR,AWFEDC,AWMINS,AWLDAT,AWNWHT,AWBK03,AWCNTR,AWOLA,AWBK04,"+
				"AWBK05,AWUNTP,AWSHRK,AWLVL,AWMOQT,AWPACK,AWPACU,AWPRPT,AWBUYR,AWAUTY,AWNWUN,AWSVOL,AWSVUN,AWMPQT,AWUPCC,"+
				"AWABCC,AWCLSS,AWSTAT,AWINVT,AWLOTF,AWSERF,AWPROC,AWOLDD,AWDRWS,AWDRWL,AWREVL,AWREV"+ number +",AWENGC,AWRDAT,AWCOIL,AWMSPC,"+
				"AWLRSP,AWLRSC,AWLRSF,AWLRMP,AWLRMC,AWLRMF,AWLWSP,AWLWSC,AWLWSF,AWLCSP,AWLCSC,AWLCSF,AWLCMP,AWLCMC,AWLCMF,AWLSSC,"+
				"AWLSSF,AWLSMP,AWLSMC,AWLSMF,AWMPCK,AWMPKU,AWORIG,AWALTF,AWUVER,AWCATA,AWCDAT,AWPERC,AWDBUY,AWSLIF,AWREAS,AWFUT1,"+
				"AWFUT2,AWFUT3,AWFUT4,AWFUT5,AWFUT6,AWFUT7,AWFUT8,AWFUT9,AWFUTA,AWFUTB,"+
//-------------------------------------------remove in 5.2
				"AWMAJG, AWMING,AWUNTI,AWQTYO,AWQTYA,AWQTYH,AWMINQ,AWMAXQ,AWYTDU,AWYTD1,AWYTD2,AWMAJS,AWOQTY,AWDES3,"+		
//-------------------------------------------add in 5.2
				"AWFUTC,AWFUTD,AWGTIN,AWFUTK,AWFUTN,AWPPAP,AWDPLT,AWGDFL,AWVDFL,AWWOQF,AWLCOIL,AWNMFC,AWSIZC,"+
				"AWSTLC,AWCOLC,AWASSC,AWSASC,AWCUSR,AWCTME,AWUUSR,AWUDAT,AWUTME,AWFUTH,AWFUTI,AWFUTL,AWFUTM,AWFUTO,AWFUTP,AWFUTQ,"+
				"AWFUTR,AWOLDD2,AWFUTJ,AWFUTG,AWFTMF,AWRECU,AWRECC,AWPSOR,AWDENC,AWDREL,AWDDAT,AWDRWS2,AWDRWL2,AWDENC2,AWDREL2,"+
				"AWDDAT2,AWFUTE,AWFUTF,AWSTCL,AWVLCD,AWSPPP,AWSPPC,AWMPPP,AWMPPC,AWFLG01,AWFLG02,AWFLG03,AWFLG04,AWFLG05,AWFLG06,"+
				"AWFLG07,AWFLG08,AWFLG09,AWFLG10,AWFUT01,AWFUT02,AWFUT03,AWFUT04,AWFUT05,AWFUT06,AWFUT07,AWFUT08,AWFUT09,AWFUT10,"+
				"AWFUT11,AWFUT12,AWFUT13,AWFUT14,AWFUT15,AWFUT16,AWFUT17,AWFUT18,AWFUT19,AWFUT20,AWFUT21,AWFUT22,AWFUT23,AWFUT24,"+
				"AWFUT25,AWFUT26,AWFUT27,AWFUT28,AWFUT29,AWFUT30,AWFUT31,AWFUT32,AWFUT33,AWFUT34,AWFUT35,AWFUT36,AWFUT37,AWFUT38,"+
				"AWFUT39,AWFUT40,AWFUT41,AWFUT42,AWFUT43,AWFUT44,AWFUT45,AWUDFT,AWFRML)"+
//-------------------------------------------
				" values('" +
				Converter.fixString(AWPART) + "', '" +
				Converter.fixString(AWDISC) + "', '" +
				Converter.fixString(AWGLDC) + "', '" +
				Converter.fixString(AWSCDT) + "', '" +
				Converter.fixString(AWDES1) + "', '" +
				Converter.fixString(AWDES2) + "', '" +
				Converter.fixString(AWBK01) + "', '" +
				Converter.fixString(AWTYPE) + "', '" +
				Converter.fixString(AWUNTO) + "', " +
				NumberUtil.toString(AWCONV) + ", '" +
				Converter.fixString(AWREQC) + "', " +
				NumberUtil.toString(AWOPTR) + ", " +
				NumberUtil.toString(AWLEAD) + ", '" +
				Converter.fixString(AWVEND) + "', '" +
				Converter.fixString(AWCORG) + "', '" +
				Converter.fixString(AWVPT) + "', '" +
				Converter.fixString(AWHARM) + "', '" +
				Converter.fixString(AWGLED) + "', '" +
				Converter.fixString(AWBK02) + "', '" +
				Converter.fixString(AWTAXR) + "', '" +
				Converter.fixString(AWFEDC) + "', '" +
				Converter.fixString(AWMINS) + "', '" +
				DateUtil.getDateRepresentation(AWLDAT) + "', " +
				NumberUtil.toString(AWNWHT) + ", '" +
				Converter.fixString(AWBK03) + "', '" +
				Converter.fixString(AWCNTR) + "', " +
				NumberUtil.toString(AWOLA) + ", '" +
				Converter.fixString(AWBK04) + "', '" +
				Converter.fixString(AWBK05) + "', '" +
				Converter.fixString(AWUNTP) + "', " +
				NumberUtil.toString(AWSHRK) + ", " +
				NumberUtil.toString(AWLVL) + ", " +
				NumberUtil.toString(AWMOQT) + ", " +
				NumberUtil.toString(AWPACK) + ", '" +
				Converter.fixString(AWPACU) + "', " +
				NumberUtil.toString(AWPRPT) + ", '" +
				Converter.fixString(AWBUYR) + "', '" +
				Converter.fixString(AWAUTY) + "', '" +
				Converter.fixString(AWNWUN) + "', " +
				NumberUtil.toString(AWSVOL) + ", '" +
				Converter.fixString(AWSVUN) + "', " +
				NumberUtil.toString(AWMPQT) + ", '" +
				Converter.fixString(AWUPCC) + "', '" +
				Converter.fixString(AWABCC) + "', '" +
				Converter.fixString(AWCLSS) + "', '" +
				Converter.fixString(AWSTAT) + "', '" +
				Converter.fixString(AWINVT) + "', '" +
				Converter.fixString(AWLOTF) + "', '" +
				Converter.fixString(AWSERF) + "', '" +
				Converter.fixString(AWPROC) + "', '" +
				Converter.fixString(AWOLDD) + "', '" +
				Converter.fixString(AWDRWS) + "', '" +
				Converter.fixString(AWDRWL) + "', '" +
				Converter.fixString(AWREVL) + "', '" +
				Converter.fixString(AWREV) + "', '" +
				Converter.fixString(AWENGC) + "', '" +
				DateUtil.getDateRepresentation(AWRDAT) + "', '" +
				Converter.fixString(AWCOIL) + "', '" +
				Converter.fixString(AWMSPC) + "', '" +
				Converter.fixString(AWLRSP) + "', " +
				NumberUtil.toString(AWLRSC) + ", '" +
				Converter.fixString(AWLRSF) + "', '" +
				Converter.fixString(AWLRMP) + "', " +
				NumberUtil.toString(AWLRMC) + ", '" +
				Converter.fixString(AWLRMF) + "', '" +
				Converter.fixString(AWLWSP) + "', " +
				NumberUtil.toString(AWLWSC) + ", '" +
				Converter.fixString(AWLWSF) + "', '" +
				Converter.fixString(AWLCSP) + "', " +
				NumberUtil.toString(AWLCSC) + ", '" +
				Converter.fixString(AWLCSF) + "', '" +
				Converter.fixString(AWLCMP) + "', " +
				NumberUtil.toString(AWLCMC) + ", '" +
				Converter.fixString(AWLCMF) + "', " +
				NumberUtil.toString(AWLSSC) + ", '" +
				Converter.fixString(AWLSSF) + "', '" +
				Converter.fixString(AWLSMP) + "', " +
				NumberUtil.toString(AWLSMC) + ", '" +
				Converter.fixString(AWLSMF) + "', " +
				NumberUtil.toString(AWMPCK) + ", '" +
				Converter.fixString(AWMPKU) + "', '" +
				Converter.fixString(AWORIG) + "', " +
				NumberUtil.toString(AWALTF) + ", '" +
				Converter.fixString(AWUVER) + "', '" +
				Converter.fixString(AWCATA) + "', '" +
				DateUtil.getDateRepresentation(AWCDAT) + "', " +
				NumberUtil.toString(AWPERC) + ", '" +
				Converter.fixString(AWDBUY) + "', " +
				NumberUtil.toString(AWSLIF) + ", '" +
				Converter.fixString(AWREAS) + "', '" +
				Converter.fixString(AWFUT1) + "', '" +
				Converter.fixString(AWFUT2) + "', '" +
				Converter.fixString(AWFUT3) + "', '" +
				Converter.fixString(AWFUT4) + "', '" +
				Converter.fixString(AWFUT5) + "', " +
				NumberUtil.toString(AWFUT6) + ", '" +
				Converter.fixString(AWFUT7) + "', '" +
				Converter.fixString(AWFUT8) + "', '" +
				Converter.fixString(AWFUT9) + "', '" +
				Converter.fixString(AWFUTA) + "', '" +
				Converter.fixString(AWFUTB) + "', '"+
//-------------------------------------------remove in 5.2
				Converter.fixString(AWMAJG) + "', '" +
				Converter.fixString(AWMING) + "', '" +
				Converter.fixString(AWUNTI) + "', " +
				NumberUtil.toString(AWQTYO) + ", " +
				NumberUtil.toString(AWQTYA) + ", " +
				NumberUtil.toString(AWQTYH) + ", " +
				NumberUtil.toString(AWMINQ) + ", " +
				NumberUtil.toString(AWMAXQ) + ", " +
				NumberUtil.toString(AWYTDU) + ", " +
				NumberUtil.toString(AWYTD1) + ", " +
				NumberUtil.toString(AWYTD2) + ", '" +
				Converter.fixString(AWMAJS) + "', " +
				NumberUtil.toString(AWOQTY) + ", '" +
				Converter.fixString(AWDES3) + "', '" +
//-------------------------------------------add in 5.2
				Converter.fixString(AWFUTC) +"', '"+
				Converter.fixString(AWFUTD) +"',"+
				NumberUtil.toString(AWGTIN )+", '"+
				Converter.fixString(AWFUTK) +"', '"+
				Converter.fixString(AWFUTN) +"', '"+
				Converter.fixString(AWPPAP) +"', '"+
				Converter.fixString(AWDPLT) +"', '"+
				Converter.fixString(AWGDFL) +"', '"+
				Converter.fixString(AWVDFL) +"', '"+
				Converter.fixString(AWWOQF) +"', '"+
				Converter.fixString(AWLCOIL) +"', '"+
				Converter.fixString(AWNMFC) +"', '"+
				Converter.fixString(AWSIZC) +"', '"+
				Converter.fixString(AWSTLC) +"', '"+
				Converter.fixString(AWCOLC) +"', '"+
				Converter.fixString(AWASSC) +"', '"+
				Converter.fixString(AWSASC) +"', '"+
				Converter.fixString(AWCUSR) +"', '"+
				DateUtil.getDateRepresentation(AWCTME )+"', '"+
				Converter.fixString(AWUUSR) +"', '"+
				DateUtil.getDateRepresentation(AWUDAT )+"', '"+
				DateUtil.getDateRepresentation(AWUTME )+"',"+
				NumberUtil.toString(AWFUTH)+","+
				NumberUtil.toString(AWFUTI )+", '"+
				Converter.fixString(AWFUTL) +"', '"+
				Converter.fixString(AWFUTM) +"', '"+
				Converter.fixString(AWFUTO) +"', '"+
				Converter.fixString(AWFUTP) +"', '"+
				DateUtil.getDateRepresentation(AWFUTQ )+"', '"+
				DateUtil.getDateRepresentation(AWFUTR )+"', '"+
				Converter.fixString(AWOLDD2) +"', '"+
				Converter.fixString(AWFUTJ) +"',"+
				NumberUtil.toString(AWFUTG )+","+
				NumberUtil.toString(AWFTMF )+","+"'"+
				Converter.fixString(AWRECU) +"', '"+
				Converter.fixString(AWRECC) +"', '"+
				Converter.fixString(AWPSOR) +"', '"+
				Converter.fixString(AWDENC) +"', '"+
				Converter.fixString(AWDREL) +"', '"+
				DateUtil.getDateRepresentation(AWDDAT )+"', '"+
				Converter.fixString(AWDRWS2) +"', '"+
				Converter.fixString(AWDRWL2) +"', '"+
				Converter.fixString(AWDENC2) +"', '"+
				Converter.fixString(AWDREL2) +"', '"+
				DateUtil.getDateRepresentation(AWDDAT2 )+"', '"+
				Converter.fixString(AWFUTE) +"', '"+
				Converter.fixString(AWFUTF) +"', '"+
				Converter.fixString(AWSTCL) +"', '"+
				Converter.fixString(AWVLCD) +"',"+
				NumberUtil.toString(AWSPPP )+", '"+
				Converter.fixString(AWSPPC) +"',"+
				NumberUtil.toString(AWMPPP )+", '"+
				Converter.fixString(AWMPPC) +"', '"+
				Converter.fixString(AWFLG01) +"', '"+
				Converter.fixString(AWFLG02) +"', '"+
				Converter.fixString(AWFLG03) +"', '"+
				Converter.fixString(AWFLG04) +"', '"+
				Converter.fixString(AWFLG05) +"', '"+
				Converter.fixString(AWFLG06) +"', '"+
				Converter.fixString(AWFLG07) +"', '"+
				Converter.fixString(AWFLG08) +"', '"+
				Converter.fixString(AWFLG09) +"', '"+
				Converter.fixString(AWFLG10) +"', '"+
				Converter.fixString(AWFUT01) +"', '"+
				Converter.fixString(AWFUT02) +"', '"+
				Converter.fixString(AWFUT03) +"', '"+
				Converter.fixString(AWFUT04) +"', '"+
				Converter.fixString(AWFUT05) +"', '"+
				Converter.fixString(AWFUT06) +"', '"+
				Converter.fixString(AWFUT07) +"', '"+
				Converter.fixString(AWFUT08) +"', '"+
				Converter.fixString(AWFUT09) +"', '"+
				Converter.fixString(AWFUT10) +"', '"+
				Converter.fixString(AWFUT11) +"', '"+
				Converter.fixString(AWFUT12) +"', '"+
				Converter.fixString(AWFUT13) +"', '"+
				Converter.fixString(AWFUT14) +"', '"+
				Converter.fixString(AWFUT15) +"', '"+
				Converter.fixString(AWFUT16) +"', '"+
				Converter.fixString(AWFUT17) +"', '"+
				Converter.fixString(AWFUT18) +"', '"+
				Converter.fixString(AWFUT19) +"', '"+
				Converter.fixString(AWFUT20) +"', '"+
				Converter.fixString(AWFUT21) +"', '"+
				Converter.fixString(AWFUT22) +"', '"+
				Converter.fixString(AWFUT23) +"', '"+
				Converter.fixString(AWFUT24) +"', '"+
				Converter.fixString(AWFUT25) +"',"+
				NumberUtil.toString(AWFUT26 )+","+
				NumberUtil.toString(AWFUT27 )+","+
				NumberUtil.toString(AWFUT28 )+","+
				NumberUtil.toString(AWFUT29 )+","+
				NumberUtil.toString(AWFUT30 )+","+
				NumberUtil.toString(AWFUT31 )+","+
				NumberUtil.toString(AWFUT32 )+","+
				NumberUtil.toString(AWFUT33 )+","+
				NumberUtil.toString(AWFUT34 )+","+
				NumberUtil.toString(AWFUT35 )+", '"+
				DateUtil.getDateRepresentation(AWFUT36 )+"', '"+
				DateUtil.getDateRepresentation(AWFUT37 )+"', '"+
				DateUtil.getDateRepresentation(AWFUT38 )+"', '"+
				DateUtil.getDateRepresentation(AWFUT39 )+"', '"+
				DateUtil.getDateRepresentation(AWFUT40 )+"', '"+
				DateUtil.getDateRepresentation(AWFUT41 )+"', '"+
				DateUtil.getDateRepresentation(AWFUT42 )+"', '"+
				DateUtil.getDateRepresentation(AWFUT43 )+"', '"+
				DateUtil.getDateRepresentation(AWFUT44 )+"', '"+
				DateUtil.getDateRepresentation(AWFUT45 )+"', '"+
				Converter.fixString(AWUDFT) +"', '"+
				Converter.fixString(AWFRML) +"')";

//-------------------------------------------
		}else{
			sql = "insert into stkmp(" + 
				"AWPART, AWDISC, AWGLDC, AWSCDT, AWMAJG, AWMING, " +
				"AWDES1, AWDES2, AWUNTI, AWBK01, AWTYPE, AWUNTO, " +
				"AWCONV, AWREQC, AWOPTR, AWLEAD, AWQTYO, AWQTYA, " +
				"AWQTYH, AWMINQ, AWMAXQ, AWYTDU, AWYTD1, AWYTD2, " +
				"AWVEND, AWCORG, AWVPT_, AWHARM, AWGLED, AWBK02, " +
				"AWTAXR, AWFEDC, AWMAJS, AWMINS, AWLDAT, AWNWHT, " +
				"AWBK03, AWOQTY, AWCNTR, AWOLA, AWBK04, AWDES3, " +
				"AWBK05, AWUNTP, AWSHRK, AWLVL, AWMOQT, AWPACK, " +
				"AWPACU, AWPRPT, AWBUYR, AWAUTY, AWNWUN, AWSVOL, " +
				"AWSVUN, AWMPQT, AWUPCC, AWABCC, AWCLSS, AWSTAT, " +
				"AWINVT, AWLOTF, AWSERF, AWPROC, AWOLDD, AWDRWS, " +
				"AWDRWL, AWREVL, AWREV_, AWENGC, AWRDAT, AWCOIL, " +
				"AWMSPC, AWLRSP, AWLRSC, AWLRSF, AWLRMP, AWLRMC, " +
				"AWLRMF, AWLWSP, AWLWSC, AWLWSF, AWLCSP, AWLCSC, " +
				"AWLCSF, AWLCMP, AWLCMC, AWLCMF, AWLSSC, AWLSSF, " +
				"AWLSMP, AWLSMC, AWLSMF, AWMPCK, AWMPKU, AWORIG, " +
				"AWALTF, AWUVER, AWCATA, AWCDAT, AWPERC, AWDBUY, " +
				"AWSLIF, AWREAS, AWFUT1, AWFUT2, AWFUT3, AWFUT4, " +
				"AWFUT5, AWFUT6, AWFUT7, AWFUT8, AWFUT9, AWFUTA, AWFUTB" + 
			") values('" +
				Converter.fixString(AWPART) + "', '" +
				Converter.fixString(AWDISC) + "', '" +
				Converter.fixString(AWGLDC) + "', '" +
				Converter.fixString(AWSCDT) + "', '" +
				Converter.fixString(AWMAJG) + "', '" +
				Converter.fixString(AWMING) + "', '" +

				Converter.fixString(AWDES1) + "', '" +
				Converter.fixString(AWDES2) + "', '" +
				Converter.fixString(AWUNTI) + "', '" +
				Converter.fixString(AWBK01) + "', '" +
				Converter.fixString(AWTYPE) + "', '" +
				Converter.fixString(AWUNTO) + "', " +

				NumberUtil.toString(AWCONV) + ", '" +
				Converter.fixString(AWREQC) + "', " +
				NumberUtil.toString(AWOPTR) + ", " +
				NumberUtil.toString(AWLEAD) + ", " +
				NumberUtil.toString(AWQTYO) + ", " +
				NumberUtil.toString(AWQTYA) + ", " +

				NumberUtil.toString(AWQTYH) + ", " +
				NumberUtil.toString(AWMINQ) + ", " +
				NumberUtil.toString(AWMAXQ) + ", " +
				NumberUtil.toString(AWYTDU) + ", " +
				NumberUtil.toString(AWYTD1) + ", " +
				NumberUtil.toString(AWYTD2) + ", '" +

				Converter.fixString(AWVEND) + "', '" +
				Converter.fixString(AWCORG) + "', '" +
				Converter.fixString(AWVPT) + "', '" +
				Converter.fixString(AWHARM) + "', '" +
				Converter.fixString(AWGLED) + "', '" +
				Converter.fixString(AWBK02) + "', '" +

				Converter.fixString(AWTAXR) + "', '" +
				Converter.fixString(AWFEDC) + "', '" +
				Converter.fixString(AWMAJS) + "', '" +
				Converter.fixString(AWMINS) + "', '" +
				DateUtil.getDateRepresentation(AWLDAT) + "', " +
				NumberUtil.toString(AWNWHT) + ", '" +

				Converter.fixString(AWBK03) + "', " +
				NumberUtil.toString(AWOQTY) + ", '" +
				Converter.fixString(AWCNTR) + "', " +
				NumberUtil.toString(AWOLA) + ", '" +
				Converter.fixString(AWBK04) + "', '" +
				Converter.fixString(AWDES3) + "', '" +

				Converter.fixString(AWBK05) + "', '" +
				Converter.fixString(AWUNTP) + "', " +
				NumberUtil.toString(AWSHRK) + ", " +
				NumberUtil.toString(AWLVL) + ", " +
				NumberUtil.toString(AWMOQT) + ", " +
				NumberUtil.toString(AWPACK) + ", '" +

				Converter.fixString(AWPACU) + "', " +
				NumberUtil.toString(AWPRPT) + ", '" +
				Converter.fixString(AWBUYR) + "', '" +
				Converter.fixString(AWAUTY) + "', '" +
				Converter.fixString(AWNWUN) + "', " +
				NumberUtil.toString(AWSVOL) + ", '" +

				Converter.fixString(AWSVUN) + "', " +
				NumberUtil.toString(AWMPQT) + ", '" +
				Converter.fixString(AWUPCC) + "', '" +
				Converter.fixString(AWABCC) + "', '" +
				Converter.fixString(AWCLSS) + "', '" +
				Converter.fixString(AWSTAT) + "', '" +

				Converter.fixString(AWINVT) + "', '" +
				Converter.fixString(AWLOTF) + "', '" +
				Converter.fixString(AWSERF) + "', '" +
				Converter.fixString(AWPROC) + "', '" +
				Converter.fixString(AWOLDD) + "', '" +
				Converter.fixString(AWDRWS) + "', '" +

				Converter.fixString(AWDRWL) + "', '" +
				Converter.fixString(AWREVL) + "', '" +
				Converter.fixString(AWREV) + "', '" +
				Converter.fixString(AWENGC) + "', '" +
				DateUtil.getDateRepresentation(AWRDAT) + "', '" +
				Converter.fixString(AWCOIL) + "', '" +

				Converter.fixString(AWMSPC) + "', '" +
				Converter.fixString(AWLRSP) + "', " +
				NumberUtil.toString(AWLRSC) + ", '" +
				Converter.fixString(AWLRSF) + "', '" +
				Converter.fixString(AWLRMP) + "', " +
				NumberUtil.toString(AWLRMC) + ", '" +

				Converter.fixString(AWLRMF) + "', '" +
				Converter.fixString(AWLWSP) + "', " +
				NumberUtil.toString(AWLWSC) + ", '" +
				Converter.fixString(AWLWSF) + "', '" +
				Converter.fixString(AWLCSP) + "', " +
				NumberUtil.toString(AWLCSC) + ", '" +

				Converter.fixString(AWLCSF) + "', '" +
				Converter.fixString(AWLCMP) + "', " +
				NumberUtil.toString(AWLCMC) + ", '" +
				Converter.fixString(AWLCMF) + "', " +
				NumberUtil.toString(AWLSSC) + ", '" +
				Converter.fixString(AWLSSF) + "', '" +

				Converter.fixString(AWLSMP) + "', " +
				NumberUtil.toString(AWLSMC) + ", '" +
				Converter.fixString(AWLSMF) + "', " +
				NumberUtil.toString(AWMPCK) + ", '" +
				Converter.fixString(AWMPKU) + "', '" +
				Converter.fixString(AWORIG) + "', " +

				NumberUtil.toString(AWALTF) + ", '" +
				Converter.fixString(AWUVER) + "', '" +
				Converter.fixString(AWCATA) + "', '" +
				DateUtil.getDateRepresentation(AWCDAT) + "', " +
				NumberUtil.toString(AWPERC) + ", '" +
				Converter.fixString(AWDBUY) + "', " +

				NumberUtil.toString(AWSLIF) + ", '" +
				Converter.fixString(AWREAS) + "', '" +
				Converter.fixString(AWFUT1) + "', '" +
				Converter.fixString(AWFUT2) + "', '" +
				Converter.fixString(AWFUT3) + "', '" +
				Converter.fixString(AWFUT4) + "', '" +

				Converter.fixString(AWFUT5) + "', " +
				NumberUtil.toString(AWFUT6) + ", '" +
				Converter.fixString(AWFUT7) + "', '" +
				Converter.fixString(AWFUT8) + "', '" +
				Converter.fixString(AWFUT9) + "', '" +
				Converter.fixString(AWFUTA) + "', '" +
				Converter.fixString(AWFUTB) + "')";
		}
		dataBaseAccess.executeUpdate(sql);
	}catch(MySql.Data.MySqlClient.MySqlException myExc){
		throw new PersistenceException("Error in class " + this.GetType().Name + " <write> SQL : " + sql + myExc.Message, myExc);
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
void setAWPART(string AWPART){
	this.AWPART = AWPART;
}

public
void setAWDISC(string AWDISC){
	this.AWDISC = AWDISC;
}

public
void setAWGLDC(string AWGLDC){
	this.AWGLDC = AWGLDC;
}

public
void setAWSCDT(string AWSCDT){
	this.AWSCDT = AWSCDT;
}

public
void setAWMAJG(string AWMAJG){
	this.AWMAJG = AWMAJG;
}

public
void setAWMING(string AWMING){
	this.AWMING = AWMING;
}

public
void setAWDES1(string AWDES1){
	this.AWDES1 = AWDES1;
}

public
void setAWDES2(string AWDES2){
	this.AWDES2 = AWDES2;
}

public
void setAWUNTI(string AWUNTI){
	this.AWUNTI = AWUNTI;
}

public
void setAWBK01(string AWBK01){
	this.AWBK01 = AWBK01;
}

public
void setAWTYPE(string AWTYPE){
	this.AWTYPE = AWTYPE;
}

public
void setAWUNTO(string AWUNTO){
	this.AWUNTO = AWUNTO;
}

public
void setAWCONV(decimal AWCONV){
	this.AWCONV = AWCONV;
}

public
void setAWREQC(string AWREQC){
	this.AWREQC = AWREQC;
}

public
void setAWOPTR(decimal AWOPTR){
	this.AWOPTR = AWOPTR;
}

public
void setAWLEAD(decimal AWLEAD){
	this.AWLEAD = AWLEAD;
}

public
void setAWQTYO(decimal AWQTYO){
	this.AWQTYO = AWQTYO;
}

public
void setAWQTYA(decimal AWQTYA){
	this.AWQTYA = AWQTYA;
}

public
void setAWQTYH(decimal AWQTYH){
	this.AWQTYH = AWQTYH;
}

public
void setAWMINQ(decimal AWMINQ){
	this.AWMINQ = AWMINQ;
}

public
void setAWMAXQ(decimal AWMAXQ){
	this.AWMAXQ = AWMAXQ;
}

public
void setAWYTDU(decimal AWYTDU){
	this.AWYTDU = AWYTDU;
}

public
void setAWYTD1(decimal AWYTD1){
	this.AWYTD1 = AWYTD1;
}

public
void setAWYTD2(decimal AWYTD2){
	this.AWYTD2 = AWYTD2;
}

public
void setAWVEND(string AWVEND){
	this.AWVEND = AWVEND;
}

public
void setAWCORG(string AWCORG){
	this.AWCORG = AWCORG;
}

public
void setAWVPT(string AWVPT){
	this.AWVPT = AWVPT;
}

public
void setAWHARM(string AWHARM){
	this.AWHARM = AWHARM;
}

public
void setAWGLED(string AWGLED){
	this.AWGLED = AWGLED;
}

public
void setAWBK02(string AWBK02){
	this.AWBK02 = AWBK02;
}

public
void setAWTAXR(string AWTAXR){
	this.AWTAXR = AWTAXR;
}

public
void setAWFEDC(string AWFEDC){
	this.AWFEDC = AWFEDC;
}

public
void setAWMAJS(string AWMAJS){
	this.AWMAJS = AWMAJS;
}

public
void setAWMINS(string AWMINS){
	this.AWMINS = AWMINS;
}

public
void setAWLDAT(DateTime AWLDAT){
	this.AWLDAT = AWLDAT;
}

public
void setAWNWHT(decimal AWNWHT){
	this.AWNWHT = AWNWHT;
}

public
void setAWBK03(string AWBK03){
	this.AWBK03 = AWBK03;
}

public
void setAWOQTY(decimal AWOQTY){
	this.AWOQTY = AWOQTY;
}

public
void setAWCNTR(string AWCNTR){
	this.AWCNTR = AWCNTR;
}

public
void setAWOLA(decimal AWOLA){
	this.AWOLA = AWOLA;
}

public
void setAWBK04(string AWBK04){
	this.AWBK04 = AWBK04;
}

public
void setAWDES3(string AWDES3){
	this.AWDES3 = AWDES3;
}

public
void setAWBK05(string AWBK05){
	this.AWBK05 = AWBK05;
}

public
void setAWUNTP(string AWUNTP){
	this.AWUNTP = AWUNTP;
}

public
void setAWSHRK(decimal AWSHRK){
	this.AWSHRK = AWSHRK;
}

public
void setAWLVL(decimal AWLVL){
	this.AWLVL = AWLVL;
}

public
void setAWMOQT(decimal AWMOQT){
	this.AWMOQT = AWMOQT;
}

public
void setAWPACK(decimal AWPACK){
	this.AWPACK = AWPACK;
}

public
void setAWPACU(string AWPACU){
	this.AWPACU = AWPACU;
}

public
void setAWPRPT(decimal AWPRPT){
	this.AWPRPT = AWPRPT;
}

public
void setAWBUYR(string AWBUYR){
	this.AWBUYR = AWBUYR;
}

public
void setAWAUTY(string AWAUTY){
	this.AWAUTY = AWAUTY;
}

public
void setAWNWUN(string AWNWUN){
	this.AWNWUN = AWNWUN;
}

public
void setAWSVOL(decimal AWSVOL){
	this.AWSVOL = AWSVOL;
}

public
void setAWSVUN(string AWSVUN){
	this.AWSVUN = AWSVUN;
}

public
void setAWMPQT(decimal AWMPQT){
	this.AWMPQT = AWMPQT;
}

public
void setAWUPCC(string AWUPCC){
	this.AWUPCC = AWUPCC;
}

public
void setAWABCC(string AWABCC){
	this.AWABCC = AWABCC;
}

public
void setAWCLSS(string AWCLSS){
	this.AWCLSS = AWCLSS;
}

public
void setAWSTAT(string AWSTAT){
	this.AWSTAT = AWSTAT;
}

public
void setAWINVT(string AWINVT){
	this.AWINVT = AWINVT;
}

public
void setAWLOTF(string AWLOTF){
	this.AWLOTF = AWLOTF;
}

public
void setAWSERF(string AWSERF){
	this.AWSERF = AWSERF;
}

public
void setAWPROC(string AWPROC){
	this.AWPROC = AWPROC;
}

public
void setAWOLDD(string AWOLDD){
	this.AWOLDD = AWOLDD;
}

public
void setAWDRWS(string AWDRWS){
	this.AWDRWS = AWDRWS;
}

public
void setAWDRWL(string AWDRWL){
	this.AWDRWL = AWDRWL;
}

public
void setAWREVL(string AWREVL){
	this.AWREVL = AWREVL;
}

public
void setAWREV(string AWREV){
	this.AWREV = AWREV;
}

public
void setAWENGC(string AWENGC){
	this.AWENGC = AWENGC;
}

public
void setAWRDAT(DateTime AWRDAT){
	this.AWRDAT = AWRDAT;
}

public
void setAWCOIL(string AWCOIL){
	this.AWCOIL = AWCOIL;
}

public
void setAWMSPC(string AWMSPC){
	this.AWMSPC = AWMSPC;
}

public
void setAWLRSP(string AWLRSP){
	this.AWLRSP = AWLRSP;
}

public
void setAWLRSC(decimal AWLRSC){
	this.AWLRSC = AWLRSC;
}

public
void setAWLRSF(string AWLRSF){
	this.AWLRSF = AWLRSF;
}

public
void setAWLRMP(string AWLRMP){
	this.AWLRMP = AWLRMP;
}

public
void setAWLRMC(decimal AWLRMC){
	this.AWLRMC = AWLRMC;
}

public
void setAWLRMF(string AWLRMF){
	this.AWLRMF = AWLRMF;
}

public
void setAWLWSP(string AWLWSP){
	this.AWLWSP = AWLWSP;
}

public
void setAWLWSC(decimal AWLWSC){
	this.AWLWSC = AWLWSC;
}

public
void setAWLWSF(string AWLWSF){
	this.AWLWSF = AWLWSF;
}

public
void setAWLCSP(string AWLCSP){
	this.AWLCSP = AWLCSP;
}

public
void setAWLCSC(decimal AWLCSC){
	this.AWLCSC = AWLCSC;
}

public
void setAWLCSF(string AWLCSF){
	this.AWLCSF = AWLCSF;
}

public
void setAWLCMP(string AWLCMP){
	this.AWLCMP = AWLCMP;
}

public
void setAWLCMC(decimal AWLCMC){
	this.AWLCMC = AWLCMC;
}

public
void setAWLCMF(string AWLCMF){
	this.AWLCMF = AWLCMF;
}

public
void setAWLSSC(decimal AWLSSC){
	this.AWLSSC = AWLSSC;
}

public
void setAWLSSF(string AWLSSF){
	this.AWLSSF = AWLSSF;
}

public
void setAWLSMP(string AWLSMP){
	this.AWLSMP = AWLSMP;
}

public
void setAWLSMC(decimal AWLSMC){
	this.AWLSMC = AWLSMC;
}

public
void setAWLSMF(string AWLSMF){
	this.AWLSMF = AWLSMF;
}

public
void setAWMPCK(decimal AWMPCK){
	this.AWMPCK = AWMPCK;
}

public
void setAWMPKU(string AWMPKU){
	this.AWMPKU = AWMPKU;
}

public
void setAWORIG(string AWORIG){
	this.AWORIG = AWORIG;
}

public
void setAWALTF(decimal AWALTF){
	this.AWALTF = AWALTF;
}

public
void setAWUVER(string AWUVER){
	this.AWUVER = AWUVER;
}

public
void setAWCATA(string AWCATA){
	this.AWCATA = AWCATA;
}

public
void setAWCDAT(DateTime AWCDAT){
	this.AWCDAT = AWCDAT;
}

public
void setAWPERC(decimal AWPERC){
	this.AWPERC = AWPERC;
}

public
void setAWDBUY(string AWDBUY){
	this.AWDBUY = AWDBUY;
}

public
void setAWSLIF(decimal AWSLIF){
	this.AWSLIF = AWSLIF;
}

public
void setAWREAS(string AWREAS){
	this.AWREAS = AWREAS;
}

public
void setAWFUT1(string AWFUT1){
	this.AWFUT1 = AWFUT1;
}

public
void setAWFUT2(string AWFUT2){
	this.AWFUT2 = AWFUT2;
}

public
void setAWFUT3(string AWFUT3){
	this.AWFUT3 = AWFUT3;
}

public
void setAWFUT4(string AWFUT4){
	this.AWFUT4 = AWFUT4;
}

public
void setAWFUT5(string AWFUT5){
	this.AWFUT5 = AWFUT5;
}

public
void setAWFUT6(decimal AWFUT6){
	this.AWFUT6 = AWFUT6;
}

public
void setAWFUT7(string AWFUT7){
	this.AWFUT7 = AWFUT7;
}

public
void setAWFUT8(string AWFUT8){
	this.AWFUT8 = AWFUT8;
}

public
void setAWFUT9(string AWFUT9){
	this.AWFUT9 = AWFUT9;
}

public
void setAWFUTA(string AWFUTA){
	this.AWFUTA = AWFUTA;
}

public
void setAWFUTB(string AWFUTB){
	this.AWFUTB = AWFUTB;
}


//-----------------add in 5.2
public
void setAWFUTC(string AWFUTC){
	this.AWFUTC = AWFUTC;
}
public
string getAWFUTC(){
	return this.AWFUTC;
}
public
void setAWFUTD(string AWFUTD){
	this.AWFUTD = AWFUTD;
}
public
string getAWFUTD(){
	return this.AWFUTD;
}
public
void setAWGTIN(decimal AWGTIN){
	this.AWGTIN = AWGTIN;
}
public
decimal getAWGTIN(){
	return this.AWGTIN;
}
public
void setAWFUTK(string AWFUTK){
	this.AWFUTK = AWFUTK;
}
public
string getAWFUTK(){
	return this.AWFUTK;
}
public
void setAWFUTN(string AWFUTN){
	this.AWFUTN = AWFUTN;
}
public
string getAWFUTN(){
	return this.AWFUTN;
}
public
void setAWPPAP(string AWPPAP){
	this.AWPPAP = AWPPAP;
}
public
string getAWPPAP(){
	return this.AWPPAP;
}
public
void setAWDPLT(string AWDPLT){
	this.AWDPLT = AWDPLT;
}
public
string getAWDPLT(){
	return this.AWDPLT;
}
public
void setAWGDFL(string AWGDFL){
	this.AWGDFL = AWGDFL;
}
public
string getAWGDFL(){
	return this.AWGDFL;
}
public
void setAWVDFL(string AWVDFL){
	this.AWVDFL = AWVDFL;
}
public
string getAWVDFL(){
	return this.AWVDFL;
}
public
void setAWWOQF(string AWWOQF){
	this.AWWOQF = AWWOQF;
}
public
string getAWWOQF(){
	return this.AWWOQF;
}
public
void setAWLCOIL(string AWLCOIL){
	this.AWLCOIL = AWLCOIL;
}
public
string getAWLCOIL(){
	return this.AWLCOIL;
}
public
void setAWNMFC(string AWNMFC){
	this.AWNMFC = AWNMFC;
}
public
string getAWNMFC(){
	return this.AWNMFC;
}
public
void setAWSIZC(string AWSIZC){
	this.AWSIZC = AWSIZC;
}
public
string getAWSIZC(){
	return this.AWSIZC;
}
public
void setAWSTLC(string AWSTLC){
	this.AWSTLC = AWSTLC;
}
public
string getAWSTLC(){
	return this.AWSTLC;
}
public
void setAWCOLC(string AWCOLC){
	this.AWCOLC = AWCOLC;
}
public
string getAWCOLC(){
	return this.AWCOLC;
}
public
void setAWASSC(string AWASSC){
	this.AWASSC = AWASSC;
}
public
string getAWASSC(){
	return this.AWASSC;
}
public
void setAWSASC(string AWSASC){
	this.AWSASC = AWSASC;
}
public
string getAWSASC(){
	return this.AWSASC;
}
public
void setAWCUSR(string AWCUSR){
	this.AWCUSR = AWCUSR;
}
public
string getAWCUSR(){
	return this.AWCUSR;
}
public 
void setAWCTME(DateTime AWCTME){
	this.AWCTME = AWCTME;
}
public
DateTime getAWCTME(){
	return this.AWCTME;
}
public
void setAWUUSR(string AWUUSR){
	this.AWUUSR = AWUUSR;
}
public
string getAWUUSR(){
	return this.AWUUSR;
}
public 
void setAWUDAT(DateTime AWUDAT){
	this.AWUDAT = AWUDAT;
}
public
DateTime getAWUDAT(){
	return this.AWUDAT;
}
public 
void setAWUTME(DateTime AWUTME){
	this.AWUTME = AWUTME;
}
public
DateTime getAWUTME(){
	return this.AWUTME;
}
public
void setAWFUTH(decimal AWFUTH){
	this.AWFUTH = AWFUTH;
}
public
decimal getAWFUTH(){
	return this.AWFUTH;
}
public
void setAWFUTI(decimal AWFUTI){
	this.AWFUTI = AWFUTI;
}
public
decimal getAWFUTI(){
	return this.AWFUTI;
}
public
void setAWFUTL(string AWFUTL){
	this.AWFUTL = AWFUTL;
}
public
string getAWFUTL(){
	return this.AWFUTL;
}
public
void setAWFUTM(string AWFUTM){
	this.AWFUTM = AWFUTM;
}
public
string getAWFUTM(){
	return this.AWFUTM;
}
public
void setAWFUTO(string AWFUTO){
	this.AWFUTO = AWFUTO;
}
public
string getAWFUTO(){
	return this.AWFUTO;
}
public
void setAWFUTP(string AWFUTP){
	this.AWFUTP = AWFUTP;
}
public
string getAWFUTP(){
	return this.AWFUTP;
}
public 
void setAWFUTQ(DateTime AWFUTQ){
	this.AWFUTQ = AWFUTQ;
}
public
DateTime getAWFUTQ(){
	return this.AWFUTQ;
}
public 
void setAWFUTR(DateTime AWFUTR){
	this.AWFUTR = AWFUTR;
}
public
DateTime getAWFUTR(){
	return this.AWFUTR;
}
public
void setAWOLDD2(string AWOLDD2){
	this.AWOLDD2 = AWOLDD2;
}
public
string getAWOLDD2(){
	return this.AWOLDD2;
}
public
void setAWFUTJ(string AWFUTJ){
	this.AWFUTJ = AWFUTJ;
}
public
string getAWFUTJ(){
	return this.AWFUTJ;
}
public
void setAWFUTG(decimal AWFUTG){
	this.AWFUTG = AWFUTG;
}
public
decimal getAWFUTG(){
	return this.AWFUTG;
}
public
void setAWFTMF(decimal AWFTMF){
	this.AWFTMF = AWFTMF;
}
public
decimal getAWFTMF(){
	return this.AWFTMF;
}
public
void setAWRECU(string AWRECU){
	this.AWRECU = AWRECU;
}
public
string getAWRECU(){
	return this.AWRECU;
}
public
void setAWRECC(string AWRECC){
	this.AWRECC = AWRECC;
}
public
string getAWRECC(){
	return this.AWRECC;
}
public
void setAWPSOR(string AWPSOR){
	this.AWPSOR = AWPSOR;
}
public
string getAWPSOR(){
	return this.AWPSOR;
}
public
void setAWDENC(string AWDENC){
	this.AWDENC = AWDENC;
}
public
string getAWDENC(){
	return this.AWDENC;
}
public
void setAWDREL(string AWDREL){
	this.AWDREL = AWDREL;
}
public
string getAWDREL(){
	return this.AWDREL;
}

public 
void setAWDDAT(DateTime AWDDAT){
	this.AWDDAT = AWDDAT;
}
public
DateTime getAWDDAT(){
	return this.AWDDAT;
}

public
void setAWDRWS2(string AWDRWS2){
	this.AWDRWS2 = AWDRWS2;
}
public
string getAWDRWS2(){
	return this.AWDRWS2;
}

public
void setAWDRWL2(string AWDRWL2){
	this.AWDRWL2 = AWDRWL2;
}
public
string getAWDRWL2(){
	return this.AWDRWL2;
}

public
void setAWDENC2(string AWDENC2){
	this.AWDENC2 = AWDENC2;
}
public
string getAWDENC2(){
	return this.AWDENC2;
}

public
void setAWDREL2(string AWDREL2){
	this.AWDREL2 = AWDREL2;
}
public
string getAWDREL2(){
	return this.AWDREL2;
}

public 
void setAWDDAT2(DateTime AWDDAT2){
	this.AWDDAT2 = AWDDAT2;
}
public
DateTime getAWDDAT2(){
	return this.AWDDAT2;
}

public
void setAWFUTE(string AWFUTE){
	this.AWFUTE = AWFUTE;
}
public
string getAWFUTE(){
	return this.AWFUTE;
}

public
void setAWFUTF(string AWFUTF){
	this.AWFUTF = AWFUTF;
}
public
string getAWFUTF(){
	return this.AWFUTF;
}

public
void setAWSTCL(string AWSTCL){
	this.AWSTCL = AWSTCL;
}
public
string getAWSTCL(){
	return this.AWSTCL;
}

public
void setAWVLCD(string AWVLCD){
	this.AWVLCD = AWVLCD;
}
public
string getAWVLCD(){
	return this.AWVLCD;
}

public
void setAWSPPP(decimal AWSPPP){
	this.AWSPPP = AWSPPP;
}
public
decimal getAWSPPP(){
	return this.AWSPPP;
}

public
void setAWSPPC(string AWSPPC){
	this.AWSPPC = AWSPPC;
}
public
string getAWSPPC(){
	return this.AWSPPC;
}

public
void setAWMPPP(decimal AWMPPP){
	this.AWMPPP = AWMPPP;
}
public
decimal getAWMPPP(){
	return this.AWMPPP;
}

public
void setAWMPPC(string AWMPPC){
	this.AWMPPC = AWMPPC;
}
public
string getAWMPPC(){
	return this.AWMPPC;
}

public
void setAWFLG01(string AWFLG01){
	this.AWFLG01 = AWFLG01;
}
public
string getAWFLG01(){
	return this.AWFLG01;
}

public
void setAWFLG02(string AWFLG02){
	this.AWFLG02 = AWFLG02;
}
public
string getAWFLG02(){
	return this.AWFLG02;
}

public
void setAWFLG03(string AWFLG03){
	this.AWFLG03 = AWFLG03;
}
public
string getAWFLG03(){
	return this.AWFLG03;
}

public
void setAWFLG04(string AWFLG04){
	this.AWFLG04 = AWFLG04;
}
public
string getAWFLG04(){
	return this.AWFLG04;
}

public
void setAWFLG05(string AWFLG05){
	this.AWFLG05 = AWFLG05;
}
public
string getAWFLG05(){
	return this.AWFLG05;
}

public
void setAWFLG06(string AWFLG06){
	this.AWFLG06 = AWFLG06;
}
public
string getAWFLG06(){
	return this.AWFLG06;
}

public
void setAWFLG07(string AWFLG07){
	this.AWFLG07 = AWFLG07;
}
public
string getAWFLG07(){
	return this.AWFLG07;
}

public
void setAWFLG08(string AWFLG08){
	this.AWFLG08 = AWFLG08;
}
public
string getAWFLG08(){
	return this.AWFLG08;
}

public
void setAWFLG09(string AWFLG09){
	this.AWFLG09 = AWFLG09;
}
public
string getAWFLG09(){
	return this.AWFLG09;
}

public
void setAWFLG10(string AWFLG10){
	this.AWFLG10 = AWFLG10;
}
public
string getAWFLG10(){
	return this.AWFLG10;
}

public
void setAWFUT01(string AWFUT01){
	this.AWFUT01 = AWFUT01;
}
public
string getAWFUT01(){
	return this.AWFUT01;
}

public
void setAWFUT02(string AWFUT02){
	this.AWFUT02 = AWFUT02;
}
public
string getAWFUT02(){
	return this.AWFUT02;
}

public
void setAWFUT03(string AWFUT03){
	this.AWFUT03 = AWFUT03;
}
public
string getAWFUT03(){
	return this.AWFUT03;
}

public
void setAWFUT04(string AWFUT04){
	this.AWFUT04 = AWFUT04;
}
public
string getAWFUT04(){
	return this.AWFUT04;
}

public
void setAWFUT05(string AWFUT05){
	this.AWFUT05 = AWFUT05;
}
public
string getAWFUT05(){
	return this.AWFUT05;
}

public
void setAWFUT06(string AWFUT06){
	this.AWFUT06 = AWFUT06;
}
public
string getAWFUT06(){
	return this.AWFUT06;
}

public
void setAWFUT07(string AWFUT07){
	this.AWFUT07 = AWFUT07;
}
public
string getAWFUT07(){
	return this.AWFUT07;
}

public
void setAWFUT08(string AWFUT08){
	this.AWFUT08 = AWFUT08;
}
public
string getAWFUT08(){
	return this.AWFUT08;
}

public
void setAWFUT09(string AWFUT09){
	this.AWFUT09 = AWFUT09;
}
public
string getAWFUT09(){
	return this.AWFUT09;
}

public
void setAWFUT10(string AWFUT10){
	this.AWFUT10 = AWFUT10;
}
public
string getAWFUT10(){
	return this.AWFUT10;
}

public
void setAWFUT11(string AWFUT11){
	this.AWFUT11 = AWFUT11;
}
public
string getAWFUT11(){
	return this.AWFUT11;
}

public
void setAWFUT12(string AWFUT12){
	this.AWFUT12 = AWFUT12;
}
public
string getAWFUT12(){
	return this.AWFUT12;
}

public
void setAWFUT13(string AWFUT13){
	this.AWFUT13 = AWFUT13;
}
public
string getAWFUT13(){
	return this.AWFUT13;
}

public
void setAWFUT14(string AWFUT14){
	this.AWFUT14 = AWFUT14;
}
public
string getAWFUT14(){
	return this.AWFUT14;
}

public
void setAWFUT15(string AWFUT15){
	this.AWFUT15 = AWFUT15;
}
public
string getAWFUT15(){
	return this.AWFUT15;
}

public
void setAWFUT16(string AWFUT16){
	this.AWFUT16 = AWFUT16;
}
public
string getAWFUT16(){
	return this.AWFUT16;
}

public
void setAWFUT17(string AWFUT17){
	this.AWFUT17 = AWFUT17;
}
public
string getAWFUT17(){
	return this.AWFUT17;
}

public
void setAWFUT18(string AWFUT18){
	this.AWFUT18 = AWFUT18;
}
public
string getAWFUT18(){
	return this.AWFUT18;
}

public
void setAWFUT19(string AWFUT19){
	this.AWFUT19 = AWFUT19;
}
public
string getAWFUT19(){
	return this.AWFUT19;
}

public
void setAWFUT20(string AWFUT20){
	this.AWFUT20 = AWFUT20;
}
public
string getAWFUT20(){
	return this.AWFUT20;
}

public
void setAWFUT21(string AWFUT21){
	this.AWFUT21 = AWFUT21;
}
public
string getAWFUT21(){
	return this.AWFUT21;
}

public
void setAWFUT22(string AWFUT22){
	this.AWFUT22 = AWFUT22;
}
public
string getAWFUT22(){
	return this.AWFUT22;
}

public
void setAWFUT23(string AWFUT23){
	this.AWFUT23 = AWFUT23;
}
public
string getAWFUT23(){
	return this.AWFUT23;
}

public
void setAWFUT24(string AWFUT24){
	this.AWFUT24 = AWFUT24;
}
public
string getAWFUT24(){
	return this.AWFUT24;
}

public
void setAWFUT25(string AWFUT25){
	this.AWFUT25 = AWFUT25;
}
public
string getAWFUT25(){
	return this.AWFUT25;
}

public
void setAWFUT26(decimal AWFUT26){
	this.AWFUT26 = AWFUT26;
}
public
decimal getAWFUT26(){
	return this.AWFUT26;
}

public
void setAWFUT27(decimal AWFUT27){
	this.AWFUT27 = AWFUT27;
}
public
decimal getAWFUT27(){
	return this.AWFUT27;
}

public
void setAWFUT28(decimal AWFUT28){
	this.AWFUT28 = AWFUT28;
}
public
decimal getAWFUT28(){
	return this.AWFUT28;
}

public
void setAWFUT29(decimal AWFUT29){
	this.AWFUT29 = AWFUT29;
}
public
decimal getAWFUT29(){
	return this.AWFUT29;
}

public
void setAWFUT30(decimal AWFUT30){
	this.AWFUT30 = AWFUT30;
}
public
decimal getAWFUT30(){
	return this.AWFUT30;
}

public
void setAWFUT31(decimal AWFUT31){
	this.AWFUT31 = AWFUT31;
}
public
decimal getAWFUT31(){
	return this.AWFUT31;
}

public
void setAWFUT32(decimal AWFUT32){
	this.AWFUT32 = AWFUT32;
}
public
decimal getAWFUT32(){
	return this.AWFUT32;
}

public
void setAWFUT33(decimal AWFUT33){
	this.AWFUT33 = AWFUT33;
}
public
decimal getAWFUT33(){
	return this.AWFUT33;
}

public
void setAWFUT34(decimal AWFUT34){
	this.AWFUT34 = AWFUT34;
}
public
decimal getAWFUT34(){
	return this.AWFUT34;
}

public
void setAWFUT35(decimal AWFUT35){
	this.AWFUT35 = AWFUT35;
}
public
decimal getAWFUT35(){
	return this.AWFUT35;
}

public 
void setAWFUT36(DateTime AWFUT36){
	this.AWFUT36 = AWFUT36;
}
public
DateTime getAWFUT36(){
	return this.AWFUT36;
}

public 
void setAWFUT37(DateTime AWFUT37){
	this.AWFUT37 = AWFUT37;
}
public
DateTime getAWFUT37(){
	return this.AWFUT37;
}

public 
void setAWFUT38(DateTime AWFUT38){
	this.AWFUT38 = AWFUT38;
}
public
DateTime getAWFUT38(){
	return this.AWFUT38;
}

public 
void setAWFUT39(DateTime AWFUT39){
	this.AWFUT39 = AWFUT39;
}
public
DateTime getAWFUT39(){
	return this.AWFUT39;
}

public 
void setAWFUT40(DateTime AWFUT40){
	this.AWFUT40 = AWFUT40;
}
public
DateTime getAWFUT40(){
	return this.AWFUT40;
}

public 
void setAWFUT41(DateTime AWFUT41){
	this.AWFUT41 = AWFUT41;
}
public
DateTime getAWFUT41(){
	return this.AWFUT41;
}

public 
void setAWFUT42(DateTime AWFUT42){
	this.AWFUT42 = AWFUT42;
}
public
DateTime getAWFUT42(){
	return this.AWFUT42;
}

public 
void setAWFUT43(DateTime AWFUT43){
	this.AWFUT43 = AWFUT43;
}
public
DateTime getAWFUT43(){
	return this.AWFUT43;
}

public 
void setAWFUT44(DateTime AWFUT44){
	this.AWFUT44 = AWFUT44;
}
public
DateTime getAWFUT44(){
	return this.AWFUT44;
}

public 
void setAWFUT45(DateTime AWFUT45){
	this.AWFUT45 = AWFUT45;
}
public
DateTime getAWFUT45(){
	return this.AWFUT45;
}

public
void setAWUDFT(string AWUDFT){
	this.AWUDFT = AWUDFT;
}
public
string getAWUDFT(){
	return this.AWUDFT;
}

public
void setAWFRML(string AWFRML){
	this.AWFRML = AWFRML;
}
public
string getAWFRML(){
	return this.AWFRML;
}

//---------------------------
public
string getAWPART(){
	return AWPART;
}

public
string getAWDISC(){
	return AWDISC;
}

public
string getAWGLDC(){
	return AWGLDC;
}

public
string getAWSCDT(){
	return AWSCDT;
}

public
string getAWMAJG(){
	return AWMAJG;
}

public
string getAWMING(){
	return AWMING;
}

public
string getAWDES1(){
	return AWDES1;
}

public
string getAWDES2(){
	return AWDES2;
}

public
string getAWUNTI(){
	return AWUNTI;
}

public
string getAWBK01(){
	return AWBK01;
}

public
string getAWTYPE(){
	return AWTYPE;
}

public
string getAWUNTO(){
	return AWUNTO;
}

public
decimal getAWCONV(){
	return AWCONV;
}

public
string getAWREQC(){
	return AWREQC;
}

public
decimal getAWOPTR(){
	return AWOPTR;
}

public
decimal getAWLEAD(){
	return AWLEAD;
}

public
decimal getAWQTYO(){
	return AWQTYO;
}

public
decimal getAWQTYA(){
	return AWQTYA;
}

public
decimal getAWQTYH(){
	return AWQTYH;
}

public
decimal getAWMINQ(){
	return AWMINQ;
}

public
decimal getAWMAXQ(){
	return AWMAXQ;
}

public
decimal getAWYTDU(){
	return AWYTDU;
}

public
decimal getAWYTD1(){
	return AWYTD1;
}

public
decimal getAWYTD2(){
	return AWYTD2;
}

public
string getAWVEND(){
	return AWVEND;
}

public
string getAWCORG(){
	return AWCORG;
}

public
string getAWVPT(){
	return AWVPT;
}

public
string getAWHARM(){
	return AWHARM;
}

public
string getAWGLED(){
	return AWGLED;
}

public
string getAWBK02(){
	return AWBK02;
}

public
string getAWTAXR(){
	return AWTAXR;
}

public
string getAWFEDC(){
	return AWFEDC;
}

public
string getAWMAJS(){
	return AWMAJS;
}

public
string getAWMINS(){
	return AWMINS;
}

public
DateTime getAWLDAT(){
	return AWLDAT;
}

public
decimal getAWNWHT(){
	return AWNWHT;
}

public
string getAWBK03(){
	return AWBK03;
}

public
decimal getAWOQTY(){
	return AWOQTY;
}

public
string getAWCNTR(){
	return AWCNTR;
}

public
decimal getAWOLA(){
	return AWOLA;
}

public
string getAWBK04(){
	return AWBK04;
}

public
string getAWDES3(){
	return AWDES3;
}

public
string getAWBK05(){
	return AWBK05;
}

public
string getAWUNTP(){
	return AWUNTP;
}

public
decimal getAWSHRK(){
	return AWSHRK;
}

public
decimal getAWLVL(){
	return AWLVL;
}

public
decimal getAWMOQT(){
	return AWMOQT;
}

public
decimal getAWPACK(){
	return AWPACK;
}

public
string getAWPACU(){
	return AWPACU;
}

public
decimal getAWPRPT(){
	return AWPRPT;
}

public
string getAWBUYR(){
	return AWBUYR;
}

public
string getAWAUTY(){
	return AWAUTY;
}

public
string getAWNWUN(){
	return AWNWUN;
}

public
decimal getAWSVOL(){
	return AWSVOL;
}

public
string getAWSVUN(){
	return AWSVUN;
}

public
decimal getAWMPQT(){
	return AWMPQT;
}

public
string getAWUPCC(){
	return AWUPCC;
}

public
string getAWABCC(){
	return AWABCC;
}

public
string getAWCLSS(){
	return AWCLSS;
}

public
string getAWSTAT(){
	return AWSTAT;
}

public
string getAWINVT(){
	return AWINVT;
}

public
string getAWLOTF(){
	return AWLOTF;
}

public
string getAWSERF(){
	return AWSERF;
}

public
string getAWPROC(){
	return AWPROC;
}

public
string getAWOLDD(){
	return AWOLDD;
}

public
string getAWDRWS(){
	return AWDRWS;
}

public
string getAWDRWL(){
	return AWDRWL;
}

public
string getAWREVL(){
	return AWREVL;
}

public
string getAWREV(){
	return AWREV;
}

public
string getAWENGC(){
	return AWENGC;
}

public
DateTime getAWRDAT(){
	return AWRDAT;
}

public
string getAWCOIL(){
	return AWCOIL;
}

public
string getAWMSPC(){
	return AWMSPC;
}

public
string getAWLRSP(){
	return AWLRSP;
}

public
decimal getAWLRSC(){
	return AWLRSC;
}

public
string getAWLRSF(){
	return AWLRSF;
}

public
string getAWLRMP(){
	return AWLRMP;
}

public
decimal getAWLRMC(){
	return AWLRMC;
}

public
string getAWLRMF(){
	return AWLRMF;
}

public
string getAWLWSP(){
	return AWLWSP;
}

public
decimal getAWLWSC(){
	return AWLWSC;
}

public
string getAWLWSF(){
	return AWLWSF;
}

public
string getAWLCSP(){
	return AWLCSP;
}

public
decimal getAWLCSC(){
	return AWLCSC;
}

public
string getAWLCSF(){
	return AWLCSF;
}

public
string getAWLCMP(){
	return AWLCMP;
}

public
decimal getAWLCMC(){
	return AWLCMC;
}

public
string getAWLCMF(){
	return AWLCMF;
}

public
decimal getAWLSSC(){
	return AWLSSC;
}

public
string getAWLSSF(){
	return AWLSSF;
}

public
string getAWLSMP(){
	return AWLSMP;
}

public
decimal getAWLSMC(){
	return AWLSMC;
}

public
string getAWLSMF(){
	return AWLSMF;
}

public
decimal getAWMPCK(){
	return AWMPCK;
}

public
string getAWMPKU(){
	return AWMPKU;
}

public
string getAWORIG(){
	return AWORIG;
}

public
decimal getAWALTF(){
	return AWALTF;
}

public
string getAWUVER(){
	return AWUVER;
}

public
string getAWCATA(){
	return AWCATA;
}

public
DateTime getAWCDAT(){
	return AWCDAT;
}

public
decimal getAWPERC(){
	return AWPERC;
}

public
string getAWDBUY(){
	return AWDBUY;
}

public
decimal getAWSLIF(){
	return AWSLIF;
}

public
string getAWREAS(){
	return AWREAS;
}

public
string getAWFUT1(){
	return AWFUT1;
}

public
string getAWFUT2(){
	return AWFUT2;
}

public
string getAWFUT3(){
	return AWFUT3;
}

public
string getAWFUT4(){
	return AWFUT4;
}

public
string getAWFUT5(){
	return AWFUT5;
}

public
decimal getAWFUT6(){
	return AWFUT6;
}

public
string getAWFUT7(){
	return AWFUT7;
}

public
string getAWFUT8(){
	return AWFUT8;
}

public
string getAWFUT9(){
	return AWFUT9;
}

public
string getAWFUTA(){
	return AWFUTA;
}

public
string getAWFUTB(){
	return AWFUTB;
}

} // class

} // namespace