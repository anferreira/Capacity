/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.Sales.PackSlips{

#if !POCKET_PC
    [System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class Bolm : BusinessObject {

private decimal rAMBOL;
private DateTime rACDAT;
private string rAPIND;
private string rASIND;
private string rASHPL;
private string rABNME;
private DateTime rASDAT;
private string rASVIA;
private string rATKID;
private string rAROUT;
private decimal rANCTN;
private decimal rANETW;
private decimal rAGROW;
private decimal rATARW;
private string rADOCD;
private string rACARC;
private string rAPRTF;
private string rAPLNT;
private decimal rASTME;
private string rASTMZ;
private string rASBOL;
private string rABLTR;
private string rABSTS;
private string rABLAK;
private string rABSET;
private string rABLMD;
private string rASEAL;
private string rACPRO;

#if !WEB
internal
#else
public
#endif
Bolm(){
	this.rAMBOL = 0;
	this.rACDAT = DateUtil.MinValue;
	this.rAPIND = "";
	this.rASIND = "";
	this.rASHPL = "";
	this.rABNME = "";
	this.rASDAT = DateUtil.MinValue;
	this.rASVIA = "";
	this.rATKID = "";
	this.rAROUT = "";
	this.rANCTN = 0;
	this.rANETW = 0;
	this.rAGROW = 0;
	this.rATARW = 0;
	this.rADOCD = "";
	this.rACARC = "";
	this.rAPRTF = "";
	this.rAPLNT = "";
	this.rASTME = 0;
	this.rASTMZ = "";
	this.rASBOL = "";
	this.rABLTR = "";
	this.rABSTS = "";
	this.rABLAK = "";
	this.rABSET = "";
	this.rABLMD = "";
	this.rASEAL = "";
	this.rACPRO = "";
}

internal
Bolm(
	decimal rAMBOL,
	DateTime rACDAT,
	string rAPIND,
	string rASIND,
	string rASHPL,
	string rABNME,
	DateTime rASDAT,
	string rASVIA,
	string rATKID,
	string rAROUT,
	decimal rANCTN,
	decimal rANETW,
	decimal rAGROW,
	decimal rATARW,
	string rADOCD,
	string rACARC,
	string rAPRTF,
	string rAPLNT,
	decimal rASTME,
	string rASTMZ,
	string rASBOL,
	string rABLTR,
	string rABSTS,
	string rABLAK,
	string rABSET,
	string rABLMD,
	string rASEAL,
	string rACPRO)
{
	this.rAMBOL = rAMBOL;
	this.rACDAT = rACDAT;
	this.rAPIND = rAPIND;
	this.rASIND = rASIND;
	this.rASHPL = rASHPL;
	this.rABNME = rABNME;
	this.rASDAT = rASDAT;
	this.rASVIA = rASVIA;
	this.rATKID = rATKID;
	this.rAROUT = rAROUT;
	this.rANCTN = rANCTN;
	this.rANETW = rANETW;
	this.rAGROW = rAGROW;
	this.rATARW = rATARW;
	this.rADOCD = rADOCD;
	this.rACARC = rACARC;
	this.rAPRTF = rAPRTF;
	this.rAPLNT = rAPLNT;
	this.rASTME = rASTME;
	this.rASTMZ = rASTMZ;
	this.rASBOL = rASBOL;
	this.rABLTR = rABLTR;
	this.rABSTS = rABSTS;
	this.rABLAK = rABLAK;
	this.rABSET = rABSET;
	this.rABLMD = rABLMD;
	this.rASEAL = rASEAL;
	this.rACPRO = rACPRO;
}

[System.Runtime.Serialization.DataMember]
public
decimal RAMBOL {
	get { return rAMBOL;}
	set { if (this.rAMBOL != value){
			this.rAMBOL = value;
			Notify("RAMBOL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime RACDAT {
	get { return rACDAT;}
	set { if (this.rACDAT != value){
			this.rACDAT = value;
			Notify("RACDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RAPIND {
	get { return rAPIND;}
	set { if (this.rAPIND != value){
			this.rAPIND = value;
			Notify("RAPIND");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RASIND {
	get { return rASIND;}
	set { if (this.rASIND != value){
			this.rASIND = value;
			Notify("RASIND");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RASHPL {
	get { return rASHPL;}
	set { if (this.rASHPL != value){
			this.rASHPL = value;
			Notify("RASHPL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RABNME {
	get { return rABNME;}
	set { if (this.rABNME != value){
			this.rABNME = value;
			Notify("RABNME");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime RASDAT {
	get { return rASDAT;}
	set { if (this.rASDAT != value){
			this.rASDAT = value;
			Notify("RASDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RASVIA {
	get { return rASVIA;}
	set { if (this.rASVIA != value){
			this.rASVIA = value;
			Notify("RASVIA");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RATKID {
	get { return rATKID;}
	set { if (this.rATKID != value){
			this.rATKID = value;
			Notify("RATKID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RAROUT {
	get { return rAROUT;}
	set { if (this.rAROUT != value){
			this.rAROUT = value;
			Notify("RAROUT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RANCTN {
	get { return rANCTN;}
	set { if (this.rANCTN != value){
			this.rANCTN = value;
			Notify("RANCTN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RANETW {
	get { return rANETW;}
	set { if (this.rANETW != value){
			this.rANETW = value;
			Notify("RANETW");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RAGROW {
	get { return rAGROW;}
	set { if (this.rAGROW != value){
			this.rAGROW = value;
			Notify("RAGROW");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RATARW {
	get { return rATARW;}
	set { if (this.rATARW != value){
			this.rATARW = value;
			Notify("RATARW");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RADOCD {
	get { return rADOCD;}
	set { if (this.rADOCD != value){
			this.rADOCD = value;
			Notify("RADOCD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RACARC {
	get { return rACARC;}
	set { if (this.rACARC != value){
			this.rACARC = value;
			Notify("RACARC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RAPRTF {
	get { return rAPRTF;}
	set { if (this.rAPRTF != value){
			this.rAPRTF = value;
			Notify("RAPRTF");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RAPLNT {
	get { return rAPLNT;}
	set { if (this.rAPLNT != value){
			this.rAPLNT = value;
			Notify("RAPLNT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal RASTME {
	get { return rASTME;}
	set { if (this.rASTME != value){
			this.rASTME = value;
			Notify("RASTME");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RASTMZ {
	get { return rASTMZ;}
	set { if (this.rASTMZ != value){
			this.rASTMZ = value;
			Notify("RASTMZ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RASBOL {
	get { return rASBOL;}
	set { if (this.rASBOL != value){
			this.rASBOL = value;
			Notify("RASBOL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RABLTR {
	get { return rABLTR;}
	set { if (this.rABLTR != value){
			this.rABLTR = value;
			Notify("RABLTR");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RABSTS {
	get { return rABSTS;}
	set { if (this.rABSTS != value){
			this.rABSTS = value;
			Notify("RABSTS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RABLAK {
	get { return rABLAK;}
	set { if (this.rABLAK != value){
			this.rABLAK = value;
			Notify("RABLAK");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RABSET {
	get { return rABSET;}
	set { if (this.rABSET != value){
			this.rABSET = value;
			Notify("RABSET");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RABLMD {
	get { return rABLMD;}
	set { if (this.rABLMD != value){
			this.rABLMD = value;
			Notify("RABLMD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RASEAL {
	get { return rASEAL;}
	set { if (this.rASEAL != value){
			this.rASEAL = value;
			Notify("RASEAL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string RACPRO {
	get { return rACPRO;}
	set { if (this.rACPRO != value){
			this.rACPRO = value;
			Notify("RACPRO");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is Bolm)
		return	this.rAMBOL.Equals(((Bolm)obj).RAMBOL);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package