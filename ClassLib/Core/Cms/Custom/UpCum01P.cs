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
class UpCum01P : LeadTimeBase {

private decimal fGBOL;
private string fEBCS;
private string fESCS;
private decimal fGENT;
private decimal fGORD;
private decimal fGITEM;
private string fGCREL;
private string fEPLTC;
private DateTime fECDAT;
private DateTime fESDAT;
private string fGRAN;
private string pYRAN;
private string uSERAN;
private decimal fGCCUM;
private decimal sMCKEY;
private DateTime sMRDAT;
private DateTime sPLDAT;
private string sPTRPT;
private string tPLOC;
private decimal sPOEMC;
private decimal sPOEMS;
private decimal sPOEMD;
private DateTime uPEXSD;
private decimal uPEXNQ;
private DateTime eXDATE;
private decimal jITCUM;
private DateTime pRDATE;
private decimal pRDCUM;
private DateTime nEDATE;
private decimal nEDCUM;
private DateTime rANFDAT;
private decimal rANFQTY;
private DateTime rANDAT;
private decimal rANQTY;
private string oZTRPT;
private DateTime pLPRDA;
private decimal pLPCUM;
private DateTime pLNRDA;
private decimal pLNCUM;
private DateTime pLRDAT;
private decimal rRLCUM;

protected ShipExportDtlContainer shipExportDtlContainer;
protected ShipExportReleaseContainer shipExportReleaseContainer;

#if !WEB
internal
#else
public
#endif
UpCum01P(){
	this.fGBOL = 0;
	this.fEBCS = "";
	this.fESCS = "";
	this.fGENT = 0;
	this.fGORD = 0;
	this.fGITEM = 0;
	this.fGCREL = "";
	this.fEPLTC = "";
	this.fECDAT = DateUtil.MinValue;
	this.fESDAT = DateUtil.MinValue;
	this.fGRAN = "";
	this.pYRAN = "";
	this.uSERAN = "";
	this.fGCCUM = 0;
	this.sMCKEY = 0;
	this.sMRDAT = DateUtil.MinValue;
	this.sPLDAT = DateUtil.MinValue;
	this.sPTRPT = "";
	this.tPLOC = "";
	this.sPOEMC = 0;
	this.sPOEMS = 0;
	this.sPOEMD = 0;
	this.uPEXSD = DateUtil.MinValue;
	this.uPEXNQ = 0;
	this.eXDATE = DateUtil.MinValue;
	this.jITCUM = 0;
	this.pRDATE = DateUtil.MinValue;
	this.pRDCUM = 0;
	this.nEDATE = DateUtil.MinValue;
	this.nEDCUM = 0;
	this.rANFDAT = DateUtil.MinValue;
	this.rANFQTY = 0;
	this.rANDAT = DateUtil.MinValue;
	this.rANQTY = 0;
	this.oZTRPT = "";
	this.pLPRDA = DateUtil.MinValue;
	this.pLPCUM = 0;
	this.pLNRDA = DateUtil.MinValue;
	this.pLNCUM = 0;
	this.pLRDAT = DateUtil.MinValue;
	this.rRLCUM = 0;

    this.shipExportDtlContainer = new ShipExportDtlContainer();
    this.shipExportReleaseContainer = new ShipExportReleaseContainer();
}

internal
UpCum01P(
	decimal fGBOL,
	string fEBCS,
	string fESCS,
	decimal fGENT,
	decimal fGORD,
	decimal fGITEM,
	string fGCREL,
	string fEPLTC,
	DateTime fECDAT,
	DateTime fESDAT,
	string fGRAN,
	string pYRAN,
	string uSERAN,
	decimal fGCCUM,
	decimal sMCKEY,
	DateTime sMRDAT,
	DateTime sPLDAT,
	string sPTRPT,
	string tPLOC,
	decimal sPOEMC,
	decimal sPOEMS,
	decimal sPOEMD,
	DateTime uPEXSD,
	decimal uPEXNQ,
	DateTime eXDATE,
	decimal jITCUM,
	DateTime pRDATE,
	decimal pRDCUM,
	DateTime nEDATE,
	decimal nEDCUM,
	DateTime rANFDAT,
	decimal rANFQTY,
	DateTime rANDAT,
	decimal rANQTY,
	string oZTRPT,
	DateTime pLPRDA,
	decimal pLPCUM,
	DateTime pLNRDA,
	decimal pLNCUM,
	DateTime pLRDAT,
	decimal rRLCUM)
{
	this.fGBOL = fGBOL;
	this.fEBCS = fEBCS;
	this.fESCS = fESCS;
	this.fGENT = fGENT;
	this.fGORD = fGORD;
	this.fGITEM = fGITEM;
	this.fGCREL = fGCREL;
	this.fEPLTC = fEPLTC;
	this.fECDAT = fECDAT;
	this.fESDAT = fESDAT;
	this.fGRAN = fGRAN;
	this.pYRAN = pYRAN;
	this.uSERAN = uSERAN;
	this.fGCCUM = fGCCUM;
	this.sMCKEY = sMCKEY;
	this.sMRDAT = sMRDAT;
	this.sPLDAT = sPLDAT;
	this.sPTRPT = sPTRPT;
	this.tPLOC = tPLOC;
	this.sPOEMC = sPOEMC;
	this.sPOEMS = sPOEMS;
	this.sPOEMD = sPOEMD;
	this.uPEXSD = uPEXSD;
	this.uPEXNQ = uPEXNQ;
	this.eXDATE = eXDATE;
	this.jITCUM = jITCUM;
	this.pRDATE = pRDATE;
	this.pRDCUM = pRDCUM;
	this.nEDATE = nEDATE;
	this.nEDCUM = nEDCUM;
	this.rANFDAT = rANFDAT;
	this.rANFQTY = rANFQTY;
	this.rANDAT = rANDAT;
	this.rANQTY = rANQTY;
	this.oZTRPT = oZTRPT;
	this.pLPRDA = pLPRDA;
	this.pLPCUM = pLPCUM;
	this.pLNRDA = pLNRDA;
	this.pLNCUM = pLNCUM;
	this.pLRDAT = pLRDAT;
	this.rRLCUM = rRLCUM;
}

[System.Runtime.Serialization.DataMember]
public
decimal FGBOL {
	get { return fGBOL;}
	set { if (this.fGBOL != value){
			this.fGBOL = value;
			Notify("FGBOL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEBCS {
	get { return fEBCS;}
	set { if (this.fEBCS != value){
			this.fEBCS = value;
			Notify("FEBCS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESCS {
	get { return fESCS;}
	set { if (this.fESCS != value){
			this.fESCS = value;
			Notify("FESCS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGENT {
	get { return fGENT;}
	set { if (this.fGENT != value){
			this.fGENT = value;
			Notify("FGENT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGORD {
	get { return fGORD;}
	set { if (this.fGORD != value){
			this.fGORD = value;
			Notify("FGORD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGITEM {
	get { return fGITEM;}
	set { if (this.fGITEM != value){
			this.fGITEM = value;
			Notify("FGITEM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGCREL {
	get { return fGCREL;}
	set { if (this.fGCREL != value){
			this.fGCREL = value;
			Notify("FGCREL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEPLTC {
	get { return fEPLTC;}
	set { if (this.fEPLTC != value){
			this.fEPLTC = value;
			Notify("FEPLTC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime FECDAT {
	get { return fECDAT;}
	set { if (this.fECDAT != value){
			this.fECDAT = value;
			Notify("FECDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime FESDAT {
	get { return fESDAT;}
	set { if (this.fESDAT != value){
			this.fESDAT = value;
			Notify("FESDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGRAN {
	get { return fGRAN;}
	set { if (this.fGRAN != value){
			this.fGRAN = value;
			Notify("FGRAN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string PYRAN {
	get { return pYRAN;}
	set { if (this.pYRAN != value){
			this.pYRAN = value;
			Notify("PYRAN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string USERAN {
	get { return uSERAN;}
	set { if (this.uSERAN != value){
			this.uSERAN = value;
			Notify("USERAN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGCCUM {
	get { return fGCCUM;}
	set { if (this.fGCCUM != value){
			this.fGCCUM = value;
			Notify("FGCCUM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal SMCKEY {
	get { return sMCKEY;}
	set { if (this.sMCKEY != value){
			this.sMCKEY = value;
			Notify("SMCKEY");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime SMRDAT {
	get { return sMRDAT;}
	set { if (this.sMRDAT != value){
			this.sMRDAT = value;
			Notify("SMRDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime SPLDAT {
	get { return sPLDAT;}
	set { if (this.sPLDAT != value){
			this.sPLDAT = value;
			Notify("SPLDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string SPTRPT {
	get { return sPTRPT;}
	set { if (this.sPTRPT != value){
			this.sPTRPT = value;
			Notify("SPTRPT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string TPLOC {
	get { return tPLOC;}
	set { if (this.tPLOC != value){
			this.tPLOC = value;
			Notify("TPLOC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal SPOEMC {
	get { return sPOEMC;}
	set { if (this.sPOEMC != value){
			this.sPOEMC = value;
			Notify("SPOEMC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal SPOEMS {
	get { return sPOEMS;}
	set { if (this.sPOEMS != value){
			this.sPOEMS = value;
			Notify("SPOEMS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal SPOEMD {
	get { return sPOEMD;}
	set { if (this.sPOEMD != value){
			this.sPOEMD = value;
			Notify("SPOEMD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime UPEXSD {
	get { return uPEXSD;}
	set { if (this.uPEXSD != value){
			this.uPEXSD = value;
			Notify("UPEXSD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal UPEXNQ {
	get { return uPEXNQ;}
	set { if (this.uPEXNQ != value){
			this.uPEXNQ = value;
			Notify("UPEXNQ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime EXDATE {
	get { return eXDATE;}
	set { if (this.eXDATE != value){
			this.eXDATE = value;
			Notify("EXDATE");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal JITCUM {
	get { return jITCUM;}
	set { if (this.jITCUM != value){
			this.jITCUM = value;
			Notify("JITCUM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime PRDATE {
	get { return pRDATE;}
	set { if (this.pRDATE != value){
			this.pRDATE = value;
			Notify("PRDATE");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal PRDCUM {
	get { return pRDCUM;}
	set { if (this.pRDCUM != value){
			this.pRDCUM = value;
			Notify("PRDCUM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime NEDATE {
	get { return nEDATE;}
	set { if (this.nEDATE != value){
			this.nEDATE = value;
			Notify("NEDATE");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal NEDCUM {
	get { return nEDCUM;}
	set { if (this.nEDCUM != value){
			this.nEDCUM = value;
			Notify("NEDCUM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime RANFDAT {
	get { return rANFDAT;}
	set { if (this.rANFDAT != value){
			this.rANFDAT = value;
			Notify("RANFDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RANFQTY {
	get { return rANFQTY;}
	set { if (this.rANFQTY != value){
			this.rANFQTY = value;
			Notify("RANFQTY");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime RANDAT {
	get { return rANDAT;}
	set { if (this.rANDAT != value){
			this.rANDAT = value;
			Notify("RANDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RANQTY {
	get { return rANQTY;}
	set { if (this.rANQTY != value){
			this.rANQTY = value;
			Notify("RANQTY");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OZTRPT {
	get { return oZTRPT;}
	set { if (this.oZTRPT != value){
			this.oZTRPT = value;
			Notify("OZTRPT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime PLPRDA {
	get { return pLPRDA;}
	set { if (this.pLPRDA != value){
			this.pLPRDA = value;
			Notify("PLPRDA");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal PLPCUM {
	get { return pLPCUM;}
	set { if (this.pLPCUM != value){
			this.pLPCUM = value;
			Notify("PLPCUM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime PLNRDA {
	get { return pLNRDA;}
	set { if (this.pLNRDA != value){
			this.pLNRDA = value;
			Notify("PLNRDA");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal PLNCUM {
	get { return pLNCUM;}
	set { if (this.pLNCUM != value){
			this.pLNCUM = value;
			Notify("PLNCUM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime PLRDAT {
	get { return pLRDAT;}
	set { if (this.pLRDAT != value){
			this.pLRDAT = value;
			Notify("PLRDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RRLCUM {
	get { return rRLCUM;}
	set { if (this.rRLCUM != value){
			this.rRLCUM = value;
			Notify("RRLCUM");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is UpCum01P)
		return	this.fGBOL.Equals(((UpCum01P)obj).FGBOL) &&
				this.fGENT.Equals(((UpCum01P)obj).FGENT);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

[System.Runtime.Serialization.DataMember]
public
UpCum01P Object{
	get { return this;}
	set { if (this != value){			
			Notify("Object");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
ShipExportDtlContainer ShipExportDtlContainer {
	get { return shipExportDtlContainer; }
	set { if (this.shipExportDtlContainer != value){
			this.shipExportDtlContainer = value;
			Notify("ShipExportDtlContainer");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
ShipExportReleaseContainer ShipExportReleaseContainer {
	get { return shipExportReleaseContainer; }
	set { if (this.shipExportReleaseContainer != value){
			this.shipExportReleaseContainer = value;
			Notify("ShipExportReleaseContainer");
		}
	}
}

public
string FGORDAndFGITEM{
	get {
        string stext = Convert.ToInt64(FGORD).ToString() + "/" + Convert.ToInt32(FGITEM).ToString();
        return stext;
    }
	set {
	}
}


} // class
} // package