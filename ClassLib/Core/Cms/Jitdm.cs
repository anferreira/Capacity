/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.Cms{


#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class Jitdm : BusinessObject {

private decimal bJ1KEYN;
private string bJ1REF;
private DateTime bJ1DATE;
private decimal bJ1HM;
private DateTime bJ1EDAT;
private decimal bJ1QTY;
private decimal bJ1QCUM;
private decimal bJ1NQTY;
private string bJ1SRC;
private decimal bJ1LOG;
private decimal bJ1ENT;
private decimal bJ1BOL;
private decimal bJ1BLIN;
private string bJ1RAN;
private string bJ1REF1;
private string bJ1REF2;
private string bJ1STAT;
private decimal bJ1KEY;
private string bJ1KBPR;
private string bJ1KBST;
private string bJ1KBEN;
private string bJ1SHPP;
private string bJ1SHPT;
private string bJ1TYPE;
private string bJ1TIMT;
private string bJ1TIMC;
private string bJ1RTEG;
private string bJ1SVCC;
private string bJ1MODE;
private string bJ1USR1;
private string bJ1USR2;
private string bJ1USR3;
private string bJ1USR4;
private string bJ1FUT1;
private string bJ1FUT2;
private string bJ1FUT3;
private string bJ1FUT4;
private string bJ1FUT5;
private string bJ1FUT6;
private string bJ1FUT7;
private string bJ1FUT8;
private string bJ1FUTA;
private string bJ1FUTB;
private string bJ1FUTC;
private string bJ1FUTD;
private string bJ1FUTE;
private string bJ1FUTF;
private string bJ1FUTG;
private string bJ1FUTH;
private string bJ1FUTI;
private string bJ1FUTJ;
private string bJ1FUTK;
private string bJ1FUTL;
private string bJ1FUTM;
private string bJ1FUTN;
private string bJ1FUTO;
private string bJ1FUTP;
private string bJ1FUTQ;
private string bJ1FUTR;
private string bJ1FUTS;
private string bJ1FUTT;
private string bJ1FUTU;
private string bJ1FLG1;
private string bJ1FLG2;
private string bJ1FLG3;
private string bJ1FLG4;
private string bJ1JITS;
private string bJ1TMZN;
private DateTime bJ1CHDT;
private decimal bJ1CHTM;
private DateTime bJ1DTTM;
private string bJ1USID;
private string bJ1ITYP;
private string bJ1OPCD;

#if !WEB
internal
#else
public
#endif
Jitdm(){
	this.bJ1KEYN = 0;
	this.bJ1REF = "";
	this.bJ1DATE = DateUtil.MinValue;
	this.bJ1HM = 0;
	this.bJ1EDAT = DateUtil.MinValue;
	this.bJ1QTY = 0;
	this.bJ1QCUM = 0;
	this.bJ1NQTY = 0;
	this.bJ1SRC = "";
	this.bJ1LOG = 0;
	this.bJ1ENT = 0;
	this.bJ1BOL = 0;
	this.bJ1BLIN = 0;
	this.bJ1RAN = "";
	this.bJ1REF1 = "";
	this.bJ1REF2 = "";
	this.bJ1STAT = "";
	this.bJ1KEY = 0;
	this.bJ1KBPR = "";
	this.bJ1KBST = "";
	this.bJ1KBEN = "";
	this.bJ1SHPP = "";
	this.bJ1SHPT = "";
	this.bJ1TYPE = "";
	this.bJ1TIMT = "";
	this.bJ1TIMC = "";
	this.bJ1RTEG = "";
	this.bJ1SVCC = "";
	this.bJ1MODE = "";
	this.bJ1USR1 = "";
	this.bJ1USR2 = "";
	this.bJ1USR3 = "";
	this.bJ1USR4 = "";
	this.bJ1FUT1 = "";
	this.bJ1FUT2 = "";
	this.bJ1FUT3 = "";
	this.bJ1FUT4 = "";
	this.bJ1FUT5 = "";
	this.bJ1FUT6 = "";
	this.bJ1FUT7 = "";
	this.bJ1FUT8 = "";
	this.bJ1FUTA = "";
	this.bJ1FUTB = "";
	this.bJ1FUTC = "";
	this.bJ1FUTD = "";
	this.bJ1FUTE = "";
	this.bJ1FUTF = "";
	this.bJ1FUTG = "";
	this.bJ1FUTH = "";
	this.bJ1FUTI = "";
	this.bJ1FUTJ = "";
	this.bJ1FUTK = "";
	this.bJ1FUTL = "";
	this.bJ1FUTM = "";
	this.bJ1FUTN = "";
	this.bJ1FUTO = "";
	this.bJ1FUTP = "";
	this.bJ1FUTQ = "";
	this.bJ1FUTR = "";
	this.bJ1FUTS = "";
	this.bJ1FUTT = "";
	this.bJ1FUTU = "";
	this.bJ1FLG1 = "";
	this.bJ1FLG2 = "";
	this.bJ1FLG3 = "";
	this.bJ1FLG4 = "";
	this.bJ1JITS = "";
	this.bJ1TMZN = "";
	this.bJ1CHDT = DateUtil.MinValue;
	this.bJ1CHTM = 0;
	this.bJ1DTTM = DateUtil.MinValue;
	this.bJ1USID = "";
	this.bJ1ITYP = "";
	this.bJ1OPCD = "";
}

internal
Jitdm(
	decimal bJ1KEYN,
	string bJ1REF,
	DateTime bJ1DATE,
	decimal bJ1HM,
	DateTime bJ1EDAT,
	decimal bJ1QTY,
	decimal bJ1QCUM,
	decimal bJ1NQTY,
	string bJ1SRC,
	decimal bJ1LOG,
	decimal bJ1ENT,
	decimal bJ1BOL,
	decimal bJ1BLIN,
	string bJ1RAN,
	string bJ1REF1,
	string bJ1REF2,
	string bJ1STAT,
	decimal bJ1KEY,
	string bJ1KBPR,
	string bJ1KBST,
	string bJ1KBEN,
	string bJ1SHPP,
	string bJ1SHPT,
	string bJ1TYPE,
	string bJ1TIMT,
	string bJ1TIMC,
	string bJ1RTEG,
	string bJ1SVCC,
	string bJ1MODE,
	string bJ1USR1,
	string bJ1USR2,
	string bJ1USR3,
	string bJ1USR4,
	string bJ1FUT1,
	string bJ1FUT2,
	string bJ1FUT3,
	string bJ1FUT4,
	string bJ1FUT5,
	string bJ1FUT6,
	string bJ1FUT7,
	string bJ1FUT8,
	string bJ1FUTA,
	string bJ1FUTB,
	string bJ1FUTC,
	string bJ1FUTD,
	string bJ1FUTE,
	string bJ1FUTF,
	string bJ1FUTG,
	string bJ1FUTH,
	string bJ1FUTI,
	string bJ1FUTJ,
	string bJ1FUTK,
	string bJ1FUTL,
	string bJ1FUTM,
	string bJ1FUTN,
	string bJ1FUTO,
	string bJ1FUTP,
	string bJ1FUTQ,
	string bJ1FUTR,
	string bJ1FUTS,
	string bJ1FUTT,
	string bJ1FUTU,
	string bJ1FLG1,
	string bJ1FLG2,
	string bJ1FLG3,
	string bJ1FLG4,
	string bJ1JITS,
	string bJ1TMZN,
	DateTime bJ1CHDT,
	decimal bJ1CHTM,
	DateTime bJ1DTTM,
	string bJ1USID,
	string bJ1ITYP,
	string bJ1OPCD)
{
	this.bJ1KEYN = bJ1KEYN;
	this.bJ1REF = bJ1REF;
	this.bJ1DATE = bJ1DATE;
	this.bJ1HM = bJ1HM;
	this.bJ1EDAT = bJ1EDAT;
	this.bJ1QTY = bJ1QTY;
	this.bJ1QCUM = bJ1QCUM;
	this.bJ1NQTY = bJ1NQTY;
	this.bJ1SRC = bJ1SRC;
	this.bJ1LOG = bJ1LOG;
	this.bJ1ENT = bJ1ENT;
	this.bJ1BOL = bJ1BOL;
	this.bJ1BLIN = bJ1BLIN;
	this.bJ1RAN = bJ1RAN;
	this.bJ1REF1 = bJ1REF1;
	this.bJ1REF2 = bJ1REF2;
	this.bJ1STAT = bJ1STAT;
	this.bJ1KEY = bJ1KEY;
	this.bJ1KBPR = bJ1KBPR;
	this.bJ1KBST = bJ1KBST;
	this.bJ1KBEN = bJ1KBEN;
	this.bJ1SHPP = bJ1SHPP;
	this.bJ1SHPT = bJ1SHPT;
	this.bJ1TYPE = bJ1TYPE;
	this.bJ1TIMT = bJ1TIMT;
	this.bJ1TIMC = bJ1TIMC;
	this.bJ1RTEG = bJ1RTEG;
	this.bJ1SVCC = bJ1SVCC;
	this.bJ1MODE = bJ1MODE;
	this.bJ1USR1 = bJ1USR1;
	this.bJ1USR2 = bJ1USR2;
	this.bJ1USR3 = bJ1USR3;
	this.bJ1USR4 = bJ1USR4;
	this.bJ1FUT1 = bJ1FUT1;
	this.bJ1FUT2 = bJ1FUT2;
	this.bJ1FUT3 = bJ1FUT3;
	this.bJ1FUT4 = bJ1FUT4;
	this.bJ1FUT5 = bJ1FUT5;
	this.bJ1FUT6 = bJ1FUT6;
	this.bJ1FUT7 = bJ1FUT7;
	this.bJ1FUT8 = bJ1FUT8;
	this.bJ1FUTA = bJ1FUTA;
	this.bJ1FUTB = bJ1FUTB;
	this.bJ1FUTC = bJ1FUTC;
	this.bJ1FUTD = bJ1FUTD;
	this.bJ1FUTE = bJ1FUTE;
	this.bJ1FUTF = bJ1FUTF;
	this.bJ1FUTG = bJ1FUTG;
	this.bJ1FUTH = bJ1FUTH;
	this.bJ1FUTI = bJ1FUTI;
	this.bJ1FUTJ = bJ1FUTJ;
	this.bJ1FUTK = bJ1FUTK;
	this.bJ1FUTL = bJ1FUTL;
	this.bJ1FUTM = bJ1FUTM;
	this.bJ1FUTN = bJ1FUTN;
	this.bJ1FUTO = bJ1FUTO;
	this.bJ1FUTP = bJ1FUTP;
	this.bJ1FUTQ = bJ1FUTQ;
	this.bJ1FUTR = bJ1FUTR;
	this.bJ1FUTS = bJ1FUTS;
	this.bJ1FUTT = bJ1FUTT;
	this.bJ1FUTU = bJ1FUTU;
	this.bJ1FLG1 = bJ1FLG1;
	this.bJ1FLG2 = bJ1FLG2;
	this.bJ1FLG3 = bJ1FLG3;
	this.bJ1FLG4 = bJ1FLG4;
	this.bJ1JITS = bJ1JITS;
	this.bJ1TMZN = bJ1TMZN;
	this.bJ1CHDT = bJ1CHDT;
	this.bJ1CHTM = bJ1CHTM;
	this.bJ1DTTM = bJ1DTTM;
	this.bJ1USID = bJ1USID;
	this.bJ1ITYP = bJ1ITYP;
	this.bJ1OPCD = bJ1OPCD;
}

[System.Runtime.Serialization.DataMember]
public
decimal BJ1KEYN {
	get { return bJ1KEYN;}
	set { if (this.bJ1KEYN != value){
			this.bJ1KEYN = value;
			Notify("BJ1KEYN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1REF {
	get { return bJ1REF;}
	set { if (this.bJ1REF != value){
			this.bJ1REF = value;
			Notify("BJ1REF");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime BJ1DATE {
	get { return bJ1DATE;}
	set { if (this.bJ1DATE != value){
			this.bJ1DATE = value;
			Notify("BJ1DATE");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal BJ1HM {
	get { return bJ1HM;}
	set { if (this.bJ1HM != value){
			this.bJ1HM = value;
			Notify("BJ1HM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime BJ1EDAT {
	get { return bJ1EDAT;}
	set { if (this.bJ1EDAT != value){
			this.bJ1EDAT = value;
			Notify("BJ1EDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal BJ1QTY {
	get { return bJ1QTY;}
	set { if (this.bJ1QTY != value){
			this.bJ1QTY = value;
			Notify("BJ1QTY");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal BJ1QCUM {
	get { return bJ1QCUM;}
	set { if (this.bJ1QCUM != value){
			this.bJ1QCUM = value;
			Notify("BJ1QCUM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal BJ1NQTY {
	get { return bJ1NQTY;}
	set { if (this.bJ1NQTY != value){
			this.bJ1NQTY = value;
			Notify("BJ1NQTY");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1SRC {
	get { return bJ1SRC;}
	set { if (this.bJ1SRC != value){
			this.bJ1SRC = value;
			Notify("BJ1SRC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal BJ1LOG {
	get { return bJ1LOG;}
	set { if (this.bJ1LOG != value){
			this.bJ1LOG = value;
			Notify("BJ1LOG");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal BJ1ENT {
	get { return bJ1ENT;}
	set { if (this.bJ1ENT != value){
			this.bJ1ENT = value;
			Notify("BJ1ENT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal BJ1BOL {
	get { return bJ1BOL;}
	set { if (this.bJ1BOL != value){
			this.bJ1BOL = value;
			Notify("BJ1BOL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal BJ1BLIN {
	get { return bJ1BLIN;}
	set { if (this.bJ1BLIN != value){
			this.bJ1BLIN = value;
			Notify("BJ1BLIN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1RAN {
	get { return bJ1RAN;}
	set { if (this.bJ1RAN != value){
			this.bJ1RAN = value;
			Notify("BJ1RAN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1REF1 {
	get { return bJ1REF1;}
	set { if (this.bJ1REF1 != value){
			this.bJ1REF1 = value;
			Notify("BJ1REF1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1REF2 {
	get { return bJ1REF2;}
	set { if (this.bJ1REF2 != value){
			this.bJ1REF2 = value;
			Notify("BJ1REF2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1STAT {
	get { return bJ1STAT;}
	set { if (this.bJ1STAT != value){
			this.bJ1STAT = value;
			Notify("BJ1STAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal BJ1KEY {
	get { return bJ1KEY;}
	set { if (this.bJ1KEY != value){
			this.bJ1KEY = value;
			Notify("BJ1KEY");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1KBPR {
	get { return bJ1KBPR;}
	set { if (this.bJ1KBPR != value){
			this.bJ1KBPR = value;
			Notify("BJ1KBPR");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1KBST {
	get { return bJ1KBST;}
	set { if (this.bJ1KBST != value){
			this.bJ1KBST = value;
			Notify("BJ1KBST");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1KBEN {
	get { return bJ1KBEN;}
	set { if (this.bJ1KBEN != value){
			this.bJ1KBEN = value;
			Notify("BJ1KBEN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1SHPP {
	get { return bJ1SHPP;}
	set { if (this.bJ1SHPP != value){
			this.bJ1SHPP = value;
			Notify("BJ1SHPP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1SHPT {
	get { return bJ1SHPT;}
	set { if (this.bJ1SHPT != value){
			this.bJ1SHPT = value;
			Notify("BJ1SHPT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1TYPE {
	get { return bJ1TYPE;}
	set { if (this.bJ1TYPE != value){
			this.bJ1TYPE = value;
			Notify("BJ1TYPE");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1TIMT {
	get { return bJ1TIMT;}
	set { if (this.bJ1TIMT != value){
			this.bJ1TIMT = value;
			Notify("BJ1TIMT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1TIMC {
	get { return bJ1TIMC;}
	set { if (this.bJ1TIMC != value){
			this.bJ1TIMC = value;
			Notify("BJ1TIMC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1RTEG {
	get { return bJ1RTEG;}
	set { if (this.bJ1RTEG != value){
			this.bJ1RTEG = value;
			Notify("BJ1RTEG");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1SVCC {
	get { return bJ1SVCC;}
	set { if (this.bJ1SVCC != value){
			this.bJ1SVCC = value;
			Notify("BJ1SVCC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1MODE {
	get { return bJ1MODE;}
	set { if (this.bJ1MODE != value){
			this.bJ1MODE = value;
			Notify("BJ1MODE");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1USR1 {
	get { return bJ1USR1;}
	set { if (this.bJ1USR1 != value){
			this.bJ1USR1 = value;
			Notify("BJ1USR1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1USR2 {
	get { return bJ1USR2;}
	set { if (this.bJ1USR2 != value){
			this.bJ1USR2 = value;
			Notify("BJ1USR2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1USR3 {
	get { return bJ1USR3;}
	set { if (this.bJ1USR3 != value){
			this.bJ1USR3 = value;
			Notify("BJ1USR3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1USR4 {
	get { return bJ1USR4;}
	set { if (this.bJ1USR4 != value){
			this.bJ1USR4 = value;
			Notify("BJ1USR4");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUT1 {
	get { return bJ1FUT1;}
	set { if (this.bJ1FUT1 != value){
			this.bJ1FUT1 = value;
			Notify("BJ1FUT1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUT2 {
	get { return bJ1FUT2;}
	set { if (this.bJ1FUT2 != value){
			this.bJ1FUT2 = value;
			Notify("BJ1FUT2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUT3 {
	get { return bJ1FUT3;}
	set { if (this.bJ1FUT3 != value){
			this.bJ1FUT3 = value;
			Notify("BJ1FUT3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUT4 {
	get { return bJ1FUT4;}
	set { if (this.bJ1FUT4 != value){
			this.bJ1FUT4 = value;
			Notify("BJ1FUT4");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUT5 {
	get { return bJ1FUT5;}
	set { if (this.bJ1FUT5 != value){
			this.bJ1FUT5 = value;
			Notify("BJ1FUT5");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUT6 {
	get { return bJ1FUT6;}
	set { if (this.bJ1FUT6 != value){
			this.bJ1FUT6 = value;
			Notify("BJ1FUT6");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUT7 {
	get { return bJ1FUT7;}
	set { if (this.bJ1FUT7 != value){
			this.bJ1FUT7 = value;
			Notify("BJ1FUT7");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUT8 {
	get { return bJ1FUT8;}
	set { if (this.bJ1FUT8 != value){
			this.bJ1FUT8 = value;
			Notify("BJ1FUT8");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTA {
	get { return bJ1FUTA;}
	set { if (this.bJ1FUTA != value){
			this.bJ1FUTA = value;
			Notify("BJ1FUTA");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTB {
	get { return bJ1FUTB;}
	set { if (this.bJ1FUTB != value){
			this.bJ1FUTB = value;
			Notify("BJ1FUTB");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTC {
	get { return bJ1FUTC;}
	set { if (this.bJ1FUTC != value){
			this.bJ1FUTC = value;
			Notify("BJ1FUTC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTD {
	get { return bJ1FUTD;}
	set { if (this.bJ1FUTD != value){
			this.bJ1FUTD = value;
			Notify("BJ1FUTD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTE {
	get { return bJ1FUTE;}
	set { if (this.bJ1FUTE != value){
			this.bJ1FUTE = value;
			Notify("BJ1FUTE");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTF {
	get { return bJ1FUTF;}
	set { if (this.bJ1FUTF != value){
			this.bJ1FUTF = value;
			Notify("BJ1FUTF");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTG {
	get { return bJ1FUTG;}
	set { if (this.bJ1FUTG != value){
			this.bJ1FUTG = value;
			Notify("BJ1FUTG");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTH {
	get { return bJ1FUTH;}
	set { if (this.bJ1FUTH != value){
			this.bJ1FUTH = value;
			Notify("BJ1FUTH");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTI {
	get { return bJ1FUTI;}
	set { if (this.bJ1FUTI != value){
			this.bJ1FUTI = value;
			Notify("BJ1FUTI");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTJ {
	get { return bJ1FUTJ;}
	set { if (this.bJ1FUTJ != value){
			this.bJ1FUTJ = value;
			Notify("BJ1FUTJ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTK {
	get { return bJ1FUTK;}
	set { if (this.bJ1FUTK != value){
			this.bJ1FUTK = value;
			Notify("BJ1FUTK");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTL {
	get { return bJ1FUTL;}
	set { if (this.bJ1FUTL != value){
			this.bJ1FUTL = value;
			Notify("BJ1FUTL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTM {
	get { return bJ1FUTM;}
	set { if (this.bJ1FUTM != value){
			this.bJ1FUTM = value;
			Notify("BJ1FUTM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTN {
	get { return bJ1FUTN;}
	set { if (this.bJ1FUTN != value){
			this.bJ1FUTN = value;
			Notify("BJ1FUTN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTO {
	get { return bJ1FUTO;}
	set { if (this.bJ1FUTO != value){
			this.bJ1FUTO = value;
			Notify("BJ1FUTO");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTP {
	get { return bJ1FUTP;}
	set { if (this.bJ1FUTP != value){
			this.bJ1FUTP = value;
			Notify("BJ1FUTP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTQ {
	get { return bJ1FUTQ;}
	set { if (this.bJ1FUTQ != value){
			this.bJ1FUTQ = value;
			Notify("BJ1FUTQ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTR {
	get { return bJ1FUTR;}
	set { if (this.bJ1FUTR != value){
			this.bJ1FUTR = value;
			Notify("BJ1FUTR");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTS {
	get { return bJ1FUTS;}
	set { if (this.bJ1FUTS != value){
			this.bJ1FUTS = value;
			Notify("BJ1FUTS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTT {
	get { return bJ1FUTT;}
	set { if (this.bJ1FUTT != value){
			this.bJ1FUTT = value;
			Notify("BJ1FUTT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FUTU {
	get { return bJ1FUTU;}
	set { if (this.bJ1FUTU != value){
			this.bJ1FUTU = value;
			Notify("BJ1FUTU");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FLG1 {
	get { return bJ1FLG1;}
	set { if (this.bJ1FLG1 != value){
			this.bJ1FLG1 = value;
			Notify("BJ1FLG1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FLG2 {
	get { return bJ1FLG2;}
	set { if (this.bJ1FLG2 != value){
			this.bJ1FLG2 = value;
			Notify("BJ1FLG2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FLG3 {
	get { return bJ1FLG3;}
	set { if (this.bJ1FLG3 != value){
			this.bJ1FLG3 = value;
			Notify("BJ1FLG3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1FLG4 {
	get { return bJ1FLG4;}
	set { if (this.bJ1FLG4 != value){
			this.bJ1FLG4 = value;
			Notify("BJ1FLG4");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1JITS {
	get { return bJ1JITS;}
	set { if (this.bJ1JITS != value){
			this.bJ1JITS = value;
			Notify("BJ1JITS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1TMZN {
	get { return bJ1TMZN;}
	set { if (this.bJ1TMZN != value){
			this.bJ1TMZN = value;
			Notify("BJ1TMZN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime BJ1CHDT {
	get { return bJ1CHDT;}
	set { if (this.bJ1CHDT != value){
			this.bJ1CHDT = value;
			Notify("BJ1CHDT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal BJ1CHTM {
	get { return bJ1CHTM;}
	set { if (this.bJ1CHTM != value){
			this.bJ1CHTM = value;
			Notify("BJ1CHTM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime BJ1DTTM {
	get { return bJ1DTTM;}
	set { if (this.bJ1DTTM != value){
			this.bJ1DTTM = value;
			Notify("BJ1DTTM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1USID {
	get { return bJ1USID;}
	set { if (this.bJ1USID != value){
			this.bJ1USID = value;
			Notify("BJ1USID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1ITYP {
	get { return bJ1ITYP;}
	set { if (this.bJ1ITYP != value){
			this.bJ1ITYP = value;
			Notify("BJ1ITYP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ1OPCD {
	get { return bJ1OPCD;}
	set { if (this.bJ1OPCD != value){
			this.bJ1OPCD = value;
			Notify("BJ1OPCD");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is Jitdm)
		return	this.bJ1KEYN.Equals(((Jitdm)obj).BJ1KEYN) &&
				this.bJ1REF.Equals(((Jitdm)obj).BJ1REF) &&
				this.bJ1CHDT.Equals(((Jitdm)obj).BJ1CHDT) &&
				this.bJ1CHTM.Equals(((Jitdm)obj).BJ1CHTM) &&
				this.bJ1DTTM.Equals(((Jitdm)obj).BJ1DTTM);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package