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
class Seri : BusinessObject {

private decimal hTSERN;
private string hTPART;
private string hTLOTN;
private decimal hTSEQ;
private string hTJOBN;
private decimal hTQTY;
private decimal hTQTYC;
private string hTUNIT;
private string hTCTNR;
private string hTLBLT;
private string hTSRC;
private decimal hTMSTN;
private string hTMSTS;
private string hTSTKL;
private string hTBINL;
private string hTSTS;
private DateTime hTADAT;
private decimal hTGWGT;
private string hTWUNT;
private decimal hTTWGT;
private decimal hTFUT1;
private string hTFUT2;
private string hTFUT3;
private string hTFUT4;
private string hTFUT5;
private string hTFUT6;
private string hTCORG;
private string hTPSRN;
private string hTRCLF;
private string hTPLNT;
private string hTHDRF;
private string hTHDRS;
private string hTSTRN;
private string hTSUPS;
private decimal hTFUT7;
private decimal hTFUT8;
private decimal hTFUT9;
private decimal hTFU10;
private string hTFU11;
private string hTFU12;
private string hTFU13;
private string hTFU14;
private string hTFU15;
private string hTFU16;

#if !WEB
internal
#else
public
#endif
Seri(){
	this.hTSERN = 0;
	this.hTPART = "";
	this.hTLOTN = "";
	this.hTSEQ = 0;
	this.hTJOBN = "";
	this.hTQTY = 0;
	this.hTQTYC = 0;
	this.hTUNIT = "";
	this.hTCTNR = "";
	this.hTLBLT = "";
	this.hTSRC = "";
	this.hTMSTN = 0;
	this.hTMSTS = "";
	this.hTSTKL = "";
	this.hTBINL = "";
	this.hTSTS = "";
	this.hTADAT = DateUtil.MinValue;
	this.hTGWGT = 0;
	this.hTWUNT = "";
	this.hTTWGT = 0;
	this.hTFUT1 = 0;
	this.hTFUT2 = "";
	this.hTFUT3 = "";
	this.hTFUT4 = "";
	this.hTFUT5 = "";
	this.hTFUT6 = "";
	this.hTCORG = "";
	this.hTPSRN = "";
	this.hTRCLF = "";
	this.hTPLNT = "";
	this.hTHDRF = "";
	this.hTHDRS = "";
	this.hTSTRN = "";
	this.hTSUPS = "";
	this.hTFUT7 = 0;
	this.hTFUT8 = 0;
	this.hTFUT9 = 0;
	this.hTFU10 = 0;
	this.hTFU11 = "";
	this.hTFU12 = "";
	this.hTFU13 = "";
	this.hTFU14 = "";
	this.hTFU15 = "";
	this.hTFU16 = "";
}

internal
Seri(
	decimal hTSERN,
	string hTPART,
	string hTLOTN,
	decimal hTSEQ,
	string hTJOBN,
	decimal hTQTY,
	decimal hTQTYC,
	string hTUNIT,
	string hTCTNR,
	string hTLBLT,
	string hTSRC,
	decimal hTMSTN,
	string hTMSTS,
	string hTSTKL,
	string hTBINL,
	string hTSTS,
	DateTime hTADAT,
	decimal hTGWGT,
	string hTWUNT,
	decimal hTTWGT,
	decimal hTFUT1,
	string hTFUT2,
	string hTFUT3,
	string hTFUT4,
	string hTFUT5,
	string hTFUT6,
	string hTCORG,
	string hTPSRN,
	string hTRCLF,
	string hTPLNT,
	string hTHDRF,
	string hTHDRS,
	string hTSTRN,
	string hTSUPS,
	decimal hTFUT7,
	decimal hTFUT8,
	decimal hTFUT9,
	decimal hTFU10,
	string hTFU11,
	string hTFU12,
	string hTFU13,
	string hTFU14,
	string hTFU15,
	string hTFU16)
{
	this.hTSERN = hTSERN;
	this.hTPART = hTPART;
	this.hTLOTN = hTLOTN;
	this.hTSEQ = hTSEQ;
	this.hTJOBN = hTJOBN;
	this.hTQTY = hTQTY;
	this.hTQTYC = hTQTYC;
	this.hTUNIT = hTUNIT;
	this.hTCTNR = hTCTNR;
	this.hTLBLT = hTLBLT;
	this.hTSRC = hTSRC;
	this.hTMSTN = hTMSTN;
	this.hTMSTS = hTMSTS;
	this.hTSTKL = hTSTKL;
	this.hTBINL = hTBINL;
	this.hTSTS = hTSTS;
	this.hTADAT = hTADAT;
	this.hTGWGT = hTGWGT;
	this.hTWUNT = hTWUNT;
	this.hTTWGT = hTTWGT;
	this.hTFUT1 = hTFUT1;
	this.hTFUT2 = hTFUT2;
	this.hTFUT3 = hTFUT3;
	this.hTFUT4 = hTFUT4;
	this.hTFUT5 = hTFUT5;
	this.hTFUT6 = hTFUT6;
	this.hTCORG = hTCORG;
	this.hTPSRN = hTPSRN;
	this.hTRCLF = hTRCLF;
	this.hTPLNT = hTPLNT;
	this.hTHDRF = hTHDRF;
	this.hTHDRS = hTHDRS;
	this.hTSTRN = hTSTRN;
	this.hTSUPS = hTSUPS;
	this.hTFUT7 = hTFUT7;
	this.hTFUT8 = hTFUT8;
	this.hTFUT9 = hTFUT9;
	this.hTFU10 = hTFU10;
	this.hTFU11 = hTFU11;
	this.hTFU12 = hTFU12;
	this.hTFU13 = hTFU13;
	this.hTFU14 = hTFU14;
	this.hTFU15 = hTFU15;
	this.hTFU16 = hTFU16;
}

[System.Runtime.Serialization.DataMember]
public
decimal HTSERN {
	get { return hTSERN;}
	set { if (this.hTSERN != value){
			this.hTSERN = value;
			Notify("HTSERN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTPART {
	get { return hTPART;}
	set { if (this.hTPART != value){
			this.hTPART = value;
			Notify("HTPART");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTLOTN {
	get { return hTLOTN;}
	set { if (this.hTLOTN != value){
			this.hTLOTN = value;
			Notify("HTLOTN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal HTSEQ {
	get { return hTSEQ;}
	set { if (this.hTSEQ != value){
			this.hTSEQ = value;
			Notify("HTSEQ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTJOBN {
	get { return hTJOBN;}
	set { if (this.hTJOBN != value){
			this.hTJOBN = value;
			Notify("HTJOBN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal HTQTY {
	get { return hTQTY;}
	set { if (this.hTQTY != value){
			this.hTQTY = value;
			Notify("HTQTY");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal HTQTYC {
	get { return hTQTYC;}
	set { if (this.hTQTYC != value){
			this.hTQTYC = value;
			Notify("HTQTYC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTUNIT {
	get { return hTUNIT;}
	set { if (this.hTUNIT != value){
			this.hTUNIT = value;
			Notify("HTUNIT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTCTNR {
	get { return hTCTNR;}
	set { if (this.hTCTNR != value){
			this.hTCTNR = value;
			Notify("HTCTNR");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTLBLT {
	get { return hTLBLT;}
	set { if (this.hTLBLT != value){
			this.hTLBLT = value;
			Notify("HTLBLT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTSRC {
	get { return hTSRC;}
	set { if (this.hTSRC != value){
			this.hTSRC = value;
			Notify("HTSRC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal HTMSTN {
	get { return hTMSTN;}
	set { if (this.hTMSTN != value){
			this.hTMSTN = value;
			Notify("HTMSTN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTMSTS {
	get { return hTMSTS;}
	set { if (this.hTMSTS != value){
			this.hTMSTS = value;
			Notify("HTMSTS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTSTKL {
	get { return hTSTKL;}
	set { if (this.hTSTKL != value){
			this.hTSTKL = value;
			Notify("HTSTKL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTBINL {
	get { return hTBINL;}
	set { if (this.hTBINL != value){
			this.hTBINL = value;
			Notify("HTBINL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTSTS {
	get { return hTSTS;}
	set { if (this.hTSTS != value){
			this.hTSTS = value;
			Notify("HTSTS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime HTADAT {
	get { return hTADAT;}
	set { if (this.hTADAT != value){
			this.hTADAT = value;
			Notify("HTADAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal HTGWGT {
	get { return hTGWGT;}
	set { if (this.hTGWGT != value){
			this.hTGWGT = value;
			Notify("HTGWGT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTWUNT {
	get { return hTWUNT;}
	set { if (this.hTWUNT != value){
			this.hTWUNT = value;
			Notify("HTWUNT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal HTTWGT {
	get { return hTTWGT;}
	set { if (this.hTTWGT != value){
			this.hTTWGT = value;
			Notify("HTTWGT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal HTFUT1 {
	get { return hTFUT1;}
	set { if (this.hTFUT1 != value){
			this.hTFUT1 = value;
			Notify("HTFUT1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTFUT2 {
	get { return hTFUT2;}
	set { if (this.hTFUT2 != value){
			this.hTFUT2 = value;
			Notify("HTFUT2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTFUT3 {
	get { return hTFUT3;}
	set { if (this.hTFUT3 != value){
			this.hTFUT3 = value;
			Notify("HTFUT3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTFUT4 {
	get { return hTFUT4;}
	set { if (this.hTFUT4 != value){
			this.hTFUT4 = value;
			Notify("HTFUT4");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTFUT5 {
	get { return hTFUT5;}
	set { if (this.hTFUT5 != value){
			this.hTFUT5 = value;
			Notify("HTFUT5");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTFUT6 {
	get { return hTFUT6;}
	set { if (this.hTFUT6 != value){
			this.hTFUT6 = value;
			Notify("HTFUT6");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTCORG {
	get { return hTCORG;}
	set { if (this.hTCORG != value){
			this.hTCORG = value;
			Notify("HTCORG");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTPSRN {
	get { return hTPSRN;}
	set { if (this.hTPSRN != value){
			this.hTPSRN = value;
			Notify("HTPSRN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTRCLF {
	get { return hTRCLF;}
	set { if (this.hTRCLF != value){
			this.hTRCLF = value;
			Notify("HTRCLF");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTPLNT {
	get { return hTPLNT;}
	set { if (this.hTPLNT != value){
			this.hTPLNT = value;
			Notify("HTPLNT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTHDRF {
	get { return hTHDRF;}
	set { if (this.hTHDRF != value){
			this.hTHDRF = value;
			Notify("HTHDRF");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTHDRS {
	get { return hTHDRS;}
	set { if (this.hTHDRS != value){
			this.hTHDRS = value;
			Notify("HTHDRS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTSTRN {
	get { return hTSTRN;}
	set { if (this.hTSTRN != value){
			this.hTSTRN = value;
			Notify("HTSTRN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTSUPS {
	get { return hTSUPS;}
	set { if (this.hTSUPS != value){
			this.hTSUPS = value;
			Notify("HTSUPS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal HTFUT7 {
	get { return hTFUT7;}
	set { if (this.hTFUT7 != value){
			this.hTFUT7 = value;
			Notify("HTFUT7");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal HTFUT8 {
	get { return hTFUT8;}
	set { if (this.hTFUT8 != value){
			this.hTFUT8 = value;
			Notify("HTFUT8");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal HTFUT9 {
	get { return hTFUT9;}
	set { if (this.hTFUT9 != value){
			this.hTFUT9 = value;
			Notify("HTFUT9");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal HTFU10 {
	get { return hTFU10;}
	set { if (this.hTFU10 != value){
			this.hTFU10 = value;
			Notify("HTFU10");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTFU11 {
	get { return hTFU11;}
	set { if (this.hTFU11 != value){
			this.hTFU11 = value;
			Notify("HTFU11");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTFU12 {
	get { return hTFU12;}
	set { if (this.hTFU12 != value){
			this.hTFU12 = value;
			Notify("HTFU12");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTFU13 {
	get { return hTFU13;}
	set { if (this.hTFU13 != value){
			this.hTFU13 = value;
			Notify("HTFU13");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTFU14 {
	get { return hTFU14;}
	set { if (this.hTFU14 != value){
			this.hTFU14 = value;
			Notify("HTFU14");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTFU15 {
	get { return hTFU15;}
	set { if (this.hTFU15 != value){
			this.hTFU15 = value;
			Notify("HTFU15");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string HTFU16 {
	get { return hTFU16;}
	set { if (this.hTFU16 != value){
			this.hTFU16 = value;
			Notify("HTFU16");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal WEIGHT_SHOW {
	get {
        decimal dweightShow = HTQTY - HTQTYC;
        return dweightShow;
    }set {
        decimal dweightShow = HTQTY - HTQTYC;

        if (dweightShow != value){
            Notify("WEIGHT_SHOW");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is Seri)
		return	this.hTSERN.Equals(((Seri)obj).HTSERN);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package