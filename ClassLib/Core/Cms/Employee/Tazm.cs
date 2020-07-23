/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: aferreira $ 
*   $Date: 2014-05-06 14:04:51 $ 
*   $Source: /usr/local/cvsroot/Projects/NujitWms2011/ClassLib/Core/Cms/Concord/Tazm.cs,v $ 
*   $State: Exp $ 

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
class Tazm : BusinessObject {

private string zMEMPL;
private string zMFNME;
private string zMLNME;
private string zMADR1;
private string zMADR2;
private string zMADR3;
private string zMPOST;
private string zMHPHO;
private string zMHFAX;
private string zMWPHO;
private string zMWEXT;
private string zMCONT;
private string zMTELC;
private string zMSOIN;
private DateTime zMDTEH;
private DateTime zMDTEB;
private string zMTITL;
private string zMETYP;
private string zMCLCD;
private string zMGRCD;
private decimal zMBRTE;
private string zMTAG;
private string zMSTAT;
private string zMREAS;
private string zMBDEP;
private string zMRPNT;
private string zMUVER;

#if !WEB
internal
#else
public
#endif
Tazm(){
	this.zMEMPL = "";
	this.zMFNME = "";
	this.zMLNME = "";
	this.zMADR1 = "";
	this.zMADR2 = "";
	this.zMADR3 = "";
	this.zMPOST = "";
	this.zMHPHO = "";
	this.zMHFAX = "";
	this.zMWPHO = "";
	this.zMWEXT = "";
	this.zMCONT = "";
	this.zMTELC = "";
	this.zMSOIN = "";
	this.zMDTEH = DateUtil.MinValue;
	this.zMDTEB = DateUtil.MinValue;
	this.zMTITL = "";
	this.zMETYP = "";
	this.zMCLCD = "";
	this.zMGRCD = "";
	this.zMBRTE = 0;
	this.zMTAG = "";
	this.zMSTAT = "";
	this.zMREAS = "";
	this.zMBDEP = "";
	this.zMRPNT = "";
	this.zMUVER = "";
}

internal
Tazm(
	string zMEMPL,
	string zMFNME,
	string zMLNME,
	string zMADR1,
	string zMADR2,
	string zMADR3,
	string zMPOST,
	string zMHPHO,
	string zMHFAX,
	string zMWPHO,
	string zMWEXT,
	string zMCONT,
	string zMTELC,
	string zMSOIN,
	DateTime zMDTEH,
	DateTime zMDTEB,
	string zMTITL,
	string zMETYP,
	string zMCLCD,
	string zMGRCD,
	decimal zMBRTE,
	string zMTAG,
	string zMSTAT,
	string zMREAS,
	string zMBDEP,
	string zMRPNT,
	string zMUVER)
{
	this.zMEMPL = zMEMPL;
	this.zMFNME = zMFNME;
	this.zMLNME = zMLNME;
	this.zMADR1 = zMADR1;
	this.zMADR2 = zMADR2;
	this.zMADR3 = zMADR3;
	this.zMPOST = zMPOST;
	this.zMHPHO = zMHPHO;
	this.zMHFAX = zMHFAX;
	this.zMWPHO = zMWPHO;
	this.zMWEXT = zMWEXT;
	this.zMCONT = zMCONT;
	this.zMTELC = zMTELC;
	this.zMSOIN = zMSOIN;
	this.zMDTEH = zMDTEH;
	this.zMDTEB = zMDTEB;
	this.zMTITL = zMTITL;
	this.zMETYP = zMETYP;
	this.zMCLCD = zMCLCD;
	this.zMGRCD = zMGRCD;
	this.zMBRTE = zMBRTE;
	this.zMTAG = zMTAG;
	this.zMSTAT = zMSTAT;
	this.zMREAS = zMREAS;
	this.zMBDEP = zMBDEP;
	this.zMRPNT = zMRPNT;
	this.zMUVER = zMUVER;
}

[System.Runtime.Serialization.DataMember]
public
string ZMEMPL {
	get { return zMEMPL;}
	set { if (this.zMEMPL != value){
			this.zMEMPL = value;
			Notify("ZMEMPL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMFNME {
	get { return zMFNME;}
	set { if (this.zMFNME != value){
			this.zMFNME = value;
			Notify("ZMFNME");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMLNME {
	get { return zMLNME;}
	set { if (this.zMLNME != value){
			this.zMLNME = value;
			Notify("ZMLNME");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMADR1 {
	get { return zMADR1;}
	set { if (this.zMADR1 != value){
			this.zMADR1 = value;
			Notify("ZMADR1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMADR2 {
	get { return zMADR2;}
	set { if (this.zMADR2 != value){
			this.zMADR2 = value;
			Notify("ZMADR2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMADR3 {
	get { return zMADR3;}
	set { if (this.zMADR3 != value){
			this.zMADR3 = value;
			Notify("ZMADR3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMPOST {
	get { return zMPOST;}
	set { if (this.zMPOST != value){
			this.zMPOST = value;
			Notify("ZMPOST");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMHPHO {
	get { return zMHPHO;}
	set { if (this.zMHPHO != value){
			this.zMHPHO = value;
			Notify("ZMHPHO");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMHFAX {
	get { return zMHFAX;}
	set { if (this.zMHFAX != value){
			this.zMHFAX = value;
			Notify("ZMHFAX");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMWPHO {
	get { return zMWPHO;}
	set { if (this.zMWPHO != value){
			this.zMWPHO = value;
			Notify("ZMWPHO");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMWEXT {
	get { return zMWEXT;}
	set { if (this.zMWEXT != value){
			this.zMWEXT = value;
			Notify("ZMWEXT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMCONT {
	get { return zMCONT;}
	set { if (this.zMCONT != value){
			this.zMCONT = value;
			Notify("ZMCONT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMTELC {
	get { return zMTELC;}
	set { if (this.zMTELC != value){
			this.zMTELC = value;
			Notify("ZMTELC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMSOIN {
	get { return zMSOIN;}
	set { if (this.zMSOIN != value){
			this.zMSOIN = value;
			Notify("ZMSOIN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime ZMDTEH {
	get { return zMDTEH;}
	set { if (this.zMDTEH != value){
			this.zMDTEH = value;
			Notify("ZMDTEH");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime ZMDTEB {
	get { return zMDTEB;}
	set { if (this.zMDTEB != value){
			this.zMDTEB = value;
			Notify("ZMDTEB");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMTITL {
	get { return zMTITL;}
	set { if (this.zMTITL != value){
			this.zMTITL = value;
			Notify("ZMTITL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMETYP {
	get { return zMETYP;}
	set { if (this.zMETYP != value){
			this.zMETYP = value;
			Notify("ZMETYP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMCLCD {
	get { return zMCLCD;}
	set { if (this.zMCLCD != value){
			this.zMCLCD = value;
			Notify("ZMCLCD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMGRCD {
	get { return zMGRCD;}
	set { if (this.zMGRCD != value){
			this.zMGRCD = value;
			Notify("ZMGRCD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal ZMBRTE {
	get { return zMBRTE;}
	set { if (this.zMBRTE != value){
			this.zMBRTE = value;
			Notify("ZMBRTE");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMTAG {
	get { return zMTAG;}
	set { if (this.zMTAG != value){
			this.zMTAG = value;
			Notify("zMTAG");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMSTAT {
	get { return zMSTAT;}
	set { if (this.zMSTAT != value){
			this.zMSTAT = value;
			Notify("ZMSTAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMREAS {
	get { return zMREAS;}
	set { if (this.zMREAS != value){
			this.zMREAS = value;
			Notify("ZMREAS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMBDEP {
	get { return zMBDEP;}
	set { if (this.zMBDEP != value){
			this.zMBDEP = value;
			Notify("ZMBDEP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMRPNT {
	get { return zMRPNT;}
	set { if (this.zMRPNT != value){
			this.zMRPNT = value;
			Notify("ZMRPNT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ZMUVER {
	get { return zMUVER;}
	set { if (this.zMUVER != value){
			this.zMUVER = value;
			Notify("ZMUVER");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is Tazm)
		return	this.zMEMPL.Equals(((Tazm)obj).ZMEMPL);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package