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
class Rrldm : BusinessObject {

private decimal bJ0KEYN;
private string bJ0REL;
private DateTime bJ0RDAT;
private decimal bJ0HHMM;
private DateTime bJ0TDAT;
private decimal bJ0QCUM;
private decimal bJ0QNET;
private decimal bJ0ADJN;
private string bJ0AUTC;
private string bJ0TIMC;
private string bJ0ATYP;
private string bJ0RAN;
private string bJ0USR1;
private string bJ0USR2;
private string bJ0USR3;
private string bJ0USR4;
private string bJ0FUT1;
private string bJ0FUT2;
private string bJ0FUT3;
private string bJ0FUT4;
private string bJ0FUT5;
private string bJ0FUT6;
private string bJ0FLG1;
private string bJ0FLG2;
private string bJ0FLG3;
private string bJ0FLG4;
private string bJ0FLG5;
private string bJ0FUT7;
private string bJ0FUT8;
private string bJ0FUT9;
private string bJ0FUTA;
private string bJ0FUTB;
private string bJ0FUTC;
private string bJ0FUTD;
private string bJ0FUTE;
private string bJ0FUTF;
private string bJ0FUTG;
private string bJ0FUTH;
private string bJ0FUTI;
private string bJ0FUTJ;
private string bJ0FUTK;
private string bJ0USR5;
private string bJ0USRF;
private string bJ0USRG;
private string bJ0USRH;
private string bJ0USRI;
private string bJ0USRJ;
private string bJ0USRK;
private string bJ0USRL;
private string bJ0USRM;
private string bJ0USRN;
private string bJ0TMZN;
private DateTime bJ0CHDT;
private decimal bJ0CHTM;
private DateTime bJ0DTTM;
private string bJ0USID;
private string bJ0ITYP;
private string bJ0OPCD;

#if !WEB
internal
#else
public
#endif
Rrldm(){
	this.bJ0KEYN = 0;
	this.bJ0REL = "";
	this.bJ0RDAT = DateUtil.MinValue;
	this.bJ0HHMM = 0;
	this.bJ0TDAT = DateUtil.MinValue;
	this.bJ0QCUM = 0;
	this.bJ0QNET = 0;
	this.bJ0ADJN = 0;
	this.bJ0AUTC = "";
	this.bJ0TIMC = "";
	this.bJ0ATYP = "";
	this.bJ0RAN = "";
	this.bJ0USR1 = "";
	this.bJ0USR2 = "";
	this.bJ0USR3 = "";
	this.bJ0USR4 = "";
	this.bJ0FUT1 = "";
	this.bJ0FUT2 = "";
	this.bJ0FUT3 = "";
	this.bJ0FUT4 = "";
	this.bJ0FUT5 = "";
	this.bJ0FUT6 = "";
	this.bJ0FLG1 = "";
	this.bJ0FLG2 = "";
	this.bJ0FLG3 = "";
	this.bJ0FLG4 = "";
	this.bJ0FLG5 = "";
	this.bJ0FUT7 = "";
	this.bJ0FUT8 = "";
	this.bJ0FUT9 = "";
	this.bJ0FUTA = "";
	this.bJ0FUTB = "";
	this.bJ0FUTC = "";
	this.bJ0FUTD = "";
	this.bJ0FUTE = "";
	this.bJ0FUTF = "";
	this.bJ0FUTG = "";
	this.bJ0FUTH = "";
	this.bJ0FUTI = "";
	this.bJ0FUTJ = "";
	this.bJ0FUTK = "";
	this.bJ0USR5 = "";
	this.bJ0USRF = "";
	this.bJ0USRG = "";
	this.bJ0USRH = "";
	this.bJ0USRI = "";
	this.bJ0USRJ = "";
	this.bJ0USRK = "";
	this.bJ0USRL = "";
	this.bJ0USRM = "";
	this.bJ0USRN = "";
	this.bJ0TMZN = "";
	this.bJ0CHDT = DateUtil.MinValue;
	this.bJ0CHTM = 0;
	this.bJ0DTTM = DateUtil.MinValue;
	this.bJ0USID = "";
	this.bJ0ITYP = "";
	this.bJ0OPCD = "";
}

internal
Rrldm(
	decimal bJ0KEYN,
	string bJ0REL,
	DateTime bJ0RDAT,
	decimal bJ0HHMM,
	DateTime bJ0TDAT,
	decimal bJ0QCUM,
	decimal bJ0QNET,
	decimal bJ0ADJN,
	string bJ0AUTC,
	string bJ0TIMC,
	string bJ0ATYP,
	string bJ0RAN,
	string bJ0USR1,
	string bJ0USR2,
	string bJ0USR3,
	string bJ0USR4,
	string bJ0FUT1,
	string bJ0FUT2,
	string bJ0FUT3,
	string bJ0FUT4,
	string bJ0FUT5,
	string bJ0FUT6,
	string bJ0FLG1,
	string bJ0FLG2,
	string bJ0FLG3,
	string bJ0FLG4,
	string bJ0FLG5,
	string bJ0FUT7,
	string bJ0FUT8,
	string bJ0FUT9,
	string bJ0FUTA,
	string bJ0FUTB,
	string bJ0FUTC,
	string bJ0FUTD,
	string bJ0FUTE,
	string bJ0FUTF,
	string bJ0FUTG,
	string bJ0FUTH,
	string bJ0FUTI,
	string bJ0FUTJ,
	string bJ0FUTK,
	string bJ0USR5,
	string bJ0USRF,
	string bJ0USRG,
	string bJ0USRH,
	string bJ0USRI,
	string bJ0USRJ,
	string bJ0USRK,
	string bJ0USRL,
	string bJ0USRM,
	string bJ0USRN,
	string bJ0TMZN,
	DateTime bJ0CHDT,
	decimal bJ0CHTM,
	DateTime bJ0DTTM,
	string bJ0USID,
	string bJ0ITYP,
	string bJ0OPCD)
{
	this.bJ0KEYN = bJ0KEYN;
	this.bJ0REL = bJ0REL;
	this.bJ0RDAT = bJ0RDAT;
	this.bJ0HHMM = bJ0HHMM;
	this.bJ0TDAT = bJ0TDAT;
	this.bJ0QCUM = bJ0QCUM;
	this.bJ0QNET = bJ0QNET;
	this.bJ0ADJN = bJ0ADJN;
	this.bJ0AUTC = bJ0AUTC;
	this.bJ0TIMC = bJ0TIMC;
	this.bJ0ATYP = bJ0ATYP;
	this.bJ0RAN = bJ0RAN;
	this.bJ0USR1 = bJ0USR1;
	this.bJ0USR2 = bJ0USR2;
	this.bJ0USR3 = bJ0USR3;
	this.bJ0USR4 = bJ0USR4;
	this.bJ0FUT1 = bJ0FUT1;
	this.bJ0FUT2 = bJ0FUT2;
	this.bJ0FUT3 = bJ0FUT3;
	this.bJ0FUT4 = bJ0FUT4;
	this.bJ0FUT5 = bJ0FUT5;
	this.bJ0FUT6 = bJ0FUT6;
	this.bJ0FLG1 = bJ0FLG1;
	this.bJ0FLG2 = bJ0FLG2;
	this.bJ0FLG3 = bJ0FLG3;
	this.bJ0FLG4 = bJ0FLG4;
	this.bJ0FLG5 = bJ0FLG5;
	this.bJ0FUT7 = bJ0FUT7;
	this.bJ0FUT8 = bJ0FUT8;
	this.bJ0FUT9 = bJ0FUT9;
	this.bJ0FUTA = bJ0FUTA;
	this.bJ0FUTB = bJ0FUTB;
	this.bJ0FUTC = bJ0FUTC;
	this.bJ0FUTD = bJ0FUTD;
	this.bJ0FUTE = bJ0FUTE;
	this.bJ0FUTF = bJ0FUTF;
	this.bJ0FUTG = bJ0FUTG;
	this.bJ0FUTH = bJ0FUTH;
	this.bJ0FUTI = bJ0FUTI;
	this.bJ0FUTJ = bJ0FUTJ;
	this.bJ0FUTK = bJ0FUTK;
	this.bJ0USR5 = bJ0USR5;
	this.bJ0USRF = bJ0USRF;
	this.bJ0USRG = bJ0USRG;
	this.bJ0USRH = bJ0USRH;
	this.bJ0USRI = bJ0USRI;
	this.bJ0USRJ = bJ0USRJ;
	this.bJ0USRK = bJ0USRK;
	this.bJ0USRL = bJ0USRL;
	this.bJ0USRM = bJ0USRM;
	this.bJ0USRN = bJ0USRN;
	this.bJ0TMZN = bJ0TMZN;
	this.bJ0CHDT = bJ0CHDT;
	this.bJ0CHTM = bJ0CHTM;
	this.bJ0DTTM = bJ0DTTM;
	this.bJ0USID = bJ0USID;
	this.bJ0ITYP = bJ0ITYP;
	this.bJ0OPCD = bJ0OPCD;
}

[System.Runtime.Serialization.DataMember]
public
decimal BJ0KEYN {
	get { return bJ0KEYN;}
	set { if (this.bJ0KEYN != value){
			this.bJ0KEYN = value;
			Notify("BJ0KEYN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0REL {
	get { return bJ0REL;}
	set { if (this.bJ0REL != value){
			this.bJ0REL = value;
			Notify("BJ0REL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime BJ0RDAT {
	get { return bJ0RDAT;}
	set { if (this.bJ0RDAT != value){
			this.bJ0RDAT = value;
			Notify("BJ0RDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal BJ0HHMM {
	get { return bJ0HHMM;}
	set { if (this.bJ0HHMM != value){
			this.bJ0HHMM = value;
			Notify("BJ0HHMM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime BJ0TDAT {
	get { return bJ0TDAT;}
	set { if (this.bJ0TDAT != value){
			this.bJ0TDAT = value;
			Notify("BJ0TDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal BJ0QCUM {
	get { return bJ0QCUM;}
	set { if (this.bJ0QCUM != value){
			this.bJ0QCUM = value;
			Notify("BJ0QCUM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal BJ0QNET {
	get { return bJ0QNET;}
	set { if (this.bJ0QNET != value){
			this.bJ0QNET = value;
			Notify("BJ0QNET");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal BJ0ADJN {
	get { return bJ0ADJN;}
	set { if (this.bJ0ADJN != value){
			this.bJ0ADJN = value;
			Notify("BJ0ADJN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0AUTC {
	get { return bJ0AUTC;}
	set { if (this.bJ0AUTC != value){
			this.bJ0AUTC = value;
			Notify("BJ0AUTC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0TIMC {
	get { return bJ0TIMC;}
	set { if (this.bJ0TIMC != value){
			this.bJ0TIMC = value;
			Notify("BJ0TIMC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0ATYP {
	get { return bJ0ATYP;}
	set { if (this.bJ0ATYP != value){
			this.bJ0ATYP = value;
			Notify("BJ0ATYP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0RAN{
	get { return bJ0RAN;}
	set { if (this.bJ0RAN != value){
			this.bJ0RAN = value;
			Notify("BJ0RAN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0USR1 {
	get { return bJ0USR1;}
	set { if (this.bJ0USR1 != value){
			this.bJ0USR1 = value;
			Notify("BJ0USR1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0USR2 {
	get { return bJ0USR2;}
	set { if (this.bJ0USR2 != value){
			this.bJ0USR2 = value;
			Notify("BJ0USR2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0USR3 {
	get { return bJ0USR3;}
	set { if (this.bJ0USR3 != value){
			this.bJ0USR3 = value;
			Notify("BJ0USR3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0USR4 {
	get { return bJ0USR4;}
	set { if (this.bJ0USR4 != value){
			this.bJ0USR4 = value;
			Notify("BJ0USR4");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUT1 {
	get { return bJ0FUT1;}
	set { if (this.bJ0FUT1 != value){
			this.bJ0FUT1 = value;
			Notify("BJ0FUT1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUT2 {
	get { return bJ0FUT2;}
	set { if (this.bJ0FUT2 != value){
			this.bJ0FUT2 = value;
			Notify("BJ0FUT2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUT3 {
	get { return bJ0FUT3;}
	set { if (this.bJ0FUT3 != value){
			this.bJ0FUT3 = value;
			Notify("BJ0FUT3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUT4 {
	get { return bJ0FUT4;}
	set { if (this.bJ0FUT4 != value){
			this.bJ0FUT4 = value;
			Notify("BJ0FUT4");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUT5 {
	get { return bJ0FUT5;}
	set { if (this.bJ0FUT5 != value){
			this.bJ0FUT5 = value;
			Notify("BJ0FUT5");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUT6 {
	get { return bJ0FUT6;}
	set { if (this.bJ0FUT6 != value){
			this.bJ0FUT6 = value;
			Notify("BJ0FUT6");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FLG1 {
	get { return bJ0FLG1;}
	set { if (this.bJ0FLG1 != value){
			this.bJ0FLG1 = value;
			Notify("BJ0FLG1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FLG2 {
	get { return bJ0FLG2;}
	set { if (this.bJ0FLG2 != value){
			this.bJ0FLG2 = value;
			Notify("BJ0FLG2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FLG3 {
	get { return bJ0FLG3;}
	set { if (this.bJ0FLG3 != value){
			this.bJ0FLG3 = value;
			Notify("BJ0FLG3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FLG4 {
	get { return bJ0FLG4;}
	set { if (this.bJ0FLG4 != value){
			this.bJ0FLG4 = value;
			Notify("BJ0FLG4");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FLG5 {
	get { return bJ0FLG5;}
	set { if (this.bJ0FLG5 != value){
			this.bJ0FLG5 = value;
			Notify("BJ0FLG5");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUT7 {
	get { return bJ0FUT7;}
	set { if (this.bJ0FUT7 != value){
			this.bJ0FUT7 = value;
			Notify("BJ0FUT7");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUT8 {
	get { return bJ0FUT8;}
	set { if (this.bJ0FUT8 != value){
			this.bJ0FUT8 = value;
			Notify("BJ0FUT8");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUT9 {
	get { return bJ0FUT9;}
	set { if (this.bJ0FUT9 != value){
			this.bJ0FUT9 = value;
			Notify("BJ0FUT9");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUTA {
	get { return bJ0FUTA;}
	set { if (this.bJ0FUTA != value){
			this.bJ0FUTA = value;
			Notify("BJ0FUTA");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUTB {
	get { return bJ0FUTB;}
	set { if (this.bJ0FUTB != value){
			this.bJ0FUTB = value;
			Notify("BJ0FUTB");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUTC {
	get { return bJ0FUTC;}
	set { if (this.bJ0FUTC != value){
			this.bJ0FUTC = value;
			Notify("BJ0FUTC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUTD {
	get { return bJ0FUTD;}
	set { if (this.bJ0FUTD != value){
			this.bJ0FUTD = value;
			Notify("BJ0FUTD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUTE {
	get { return bJ0FUTE;}
	set { if (this.bJ0FUTE != value){
			this.bJ0FUTE = value;
			Notify("BJ0FUTE");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUTF {
	get { return bJ0FUTF;}
	set { if (this.bJ0FUTF != value){
			this.bJ0FUTF = value;
			Notify("BJ0FUTF");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUTG {
	get { return bJ0FUTG;}
	set { if (this.bJ0FUTG != value){
			this.bJ0FUTG = value;
			Notify("BJ0FUTG");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUTH {
	get { return bJ0FUTH;}
	set { if (this.bJ0FUTH != value){
			this.bJ0FUTH = value;
			Notify("BJ0FUTH");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUTI {
	get { return bJ0FUTI;}
	set { if (this.bJ0FUTI != value){
			this.bJ0FUTI = value;
			Notify("BJ0FUTI");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUTJ {
	get { return bJ0FUTJ;}
	set { if (this.bJ0FUTJ != value){
			this.bJ0FUTJ = value;
			Notify("BJ0FUTJ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0FUTK {
	get { return bJ0FUTK;}
	set { if (this.bJ0FUTK != value){
			this.bJ0FUTK = value;
			Notify("BJ0FUTK");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0USR5 {
	get { return bJ0USR5;}
	set { if (this.bJ0USR5 != value){
			this.bJ0USR5 = value;
			Notify("BJ0USR5");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0USRF {
	get { return bJ0USRF;}
	set { if (this.bJ0USRF != value){
			this.bJ0USRF = value;
			Notify("BJ0USRF");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0USRG {
	get { return bJ0USRG;}
	set { if (this.bJ0USRG != value){
			this.bJ0USRG = value;
			Notify("BJ0USRG");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0USRH {
	get { return bJ0USRH;}
	set { if (this.bJ0USRH != value){
			this.bJ0USRH = value;
			Notify("BJ0USRH");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0USRI {
	get { return bJ0USRI;}
	set { if (this.bJ0USRI != value){
			this.bJ0USRI = value;
			Notify("BJ0USRI");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0USRJ {
	get { return bJ0USRJ;}
	set { if (this.bJ0USRJ != value){
			this.bJ0USRJ = value;
			Notify("BJ0USRJ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0USRK {
	get { return bJ0USRK;}
	set { if (this.bJ0USRK != value){
			this.bJ0USRK = value;
			Notify("BJ0USRK");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0USRL {
	get { return bJ0USRL;}
	set { if (this.bJ0USRL != value){
			this.bJ0USRL = value;
			Notify("BJ0USRL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0USRM {
	get { return bJ0USRM;}
	set { if (this.bJ0USRM != value){
			this.bJ0USRM = value;
			Notify("BJ0USRM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0USRN {
	get { return bJ0USRN;}
	set { if (this.bJ0USRN != value){
			this.bJ0USRN = value;
			Notify("BJ0USRN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0TMZN {
	get { return bJ0TMZN;}
	set { if (this.bJ0TMZN != value){
			this.bJ0TMZN = value;
			Notify("BJ0TMZN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime BJ0CHDT {
	get { return bJ0CHDT;}
	set { if (this.bJ0CHDT != value){
			this.bJ0CHDT = value;
			Notify("BJ0CHDT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal BJ0CHTM {
	get { return bJ0CHTM;}
	set { if (this.bJ0CHTM != value){
			this.bJ0CHTM = value;
			Notify("BJ0CHTM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime BJ0DTTM {
	get { return bJ0DTTM;}
	set { if (this.bJ0DTTM != value){
			this.bJ0DTTM = value;
			Notify("BJ0DTTM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0USID {
	get { return bJ0USID;}
	set { if (this.bJ0USID != value){
			this.bJ0USID = value;
			Notify("BJ0USID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0ITYP {
	get { return bJ0ITYP;}
	set { if (this.bJ0ITYP != value){
			this.bJ0ITYP = value;
			Notify("BJ0ITYP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BJ0OPCD {
	get { return bJ0OPCD;}
	set { if (this.bJ0OPCD != value){
			this.bJ0OPCD = value;
			Notify("BJ0OPCD");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is Rrldm)
		return	this.bJ0KEYN.Equals(((Rrldm)obj).BJ0KEYN) &&
				this.bJ0REL.Equals(((Rrldm)obj).BJ0REL) &&
				this.bJ0CHDT.Equals(((Rrldm)obj).BJ0CHDT) &&
				this.bJ0CHTM.Equals(((Rrldm)obj).BJ0CHTM) &&
				this.bJ0DTTM.Equals(((Rrldm)obj).BJ0DTTM);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package