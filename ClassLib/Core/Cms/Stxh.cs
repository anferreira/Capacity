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
class Stxh : BusinessObject {

private decimal oYLOG;
private decimal oYENT;
private string oYTRCD;
private string oYTRPR;
private string oYDOCN;
private string oYEXCD;
private string oYDCCL;
private string oYMAPT;
private DateTime oYCDAT;
private decimal oYCHRM;
private string oYSTAT;
private DateTime oYTDAT;
private decimal oYTHRM;
private string oYNOTE;
private string oYSUPL;
private string oYDOCC;
private string oYITYP;
private string oYFUT1;
private string oYFUT2;
private string oYFUT3;
private string oYFUT4;
private string oYFUT5;
private string oYFUT6;
private string oYFUT7;
private string oYFUT8;
private string oYFUT9;
private string oYPLNT;
private string oYMLBX;

#if !WEB
internal
#else
public
#endif
Stxh(){
	this.oYLOG = 0;
	this.oYENT = 0;
	this.oYTRCD = "";
	this.oYTRPR = "";
	this.oYDOCN = "";
	this.oYEXCD = "";
	this.oYDCCL = "";
	this.oYMAPT = "";
	this.oYCDAT = DateUtil.MinValue;
	this.oYCHRM = 0;
	this.oYSTAT = "";
	this.oYTDAT = DateUtil.MinValue;
	this.oYTHRM = 0;
	this.oYNOTE = "";
	this.oYSUPL = "";
	this.oYDOCC = "";
	this.oYITYP = "";
	this.oYFUT1 = "";
	this.oYFUT2 = "";
	this.oYFUT3 = "";
	this.oYFUT4 = "";
	this.oYFUT5 = "";
	this.oYFUT6 = "";
	this.oYFUT7 = "";
	this.oYFUT8 = "";
	this.oYFUT9 = "";
	this.oYPLNT = "";
	this.oYMLBX = "";
}

internal
Stxh(
	decimal oYLOG,
	decimal oYENT,
	string oYTRCD,
	string oYTRPR,
	string oYDOCN,
	string oYEXCD,
	string oYDCCL,
	string oYMAPT,
	DateTime oYCDAT,
	decimal oYCHRM,
	string oYSTAT,
	DateTime oYTDAT,
	decimal oYTHRM,
	string oYNOTE,
	string oYSUPL,
	string oYDOCC,
	string oYITYP,
	string oYFUT1,
	string oYFUT2,
	string oYFUT3,
	string oYFUT4,
	string oYFUT5,
	string oYFUT6,
	string oYFUT7,
	string oYFUT8,
	string oYFUT9,
	string oYPLNT,
	string oYMLBX)
{
	this.oYLOG = oYLOG;
	this.oYENT = oYENT;
	this.oYTRCD = oYTRCD;
	this.oYTRPR = oYTRPR;
	this.oYDOCN = oYDOCN;
	this.oYEXCD = oYEXCD;
	this.oYDCCL = oYDCCL;
	this.oYMAPT = oYMAPT;
	this.oYCDAT = oYCDAT;
	this.oYCHRM = oYCHRM;
	this.oYSTAT = oYSTAT;
	this.oYTDAT = oYTDAT;
	this.oYTHRM = oYTHRM;
	this.oYNOTE = oYNOTE;
	this.oYSUPL = oYSUPL;
	this.oYDOCC = oYDOCC;
	this.oYITYP = oYITYP;
	this.oYFUT1 = oYFUT1;
	this.oYFUT2 = oYFUT2;
	this.oYFUT3 = oYFUT3;
	this.oYFUT4 = oYFUT4;
	this.oYFUT5 = oYFUT5;
	this.oYFUT6 = oYFUT6;
	this.oYFUT7 = oYFUT7;
	this.oYFUT8 = oYFUT8;
	this.oYFUT9 = oYFUT9;
	this.oYPLNT = oYPLNT;
	this.oYMLBX = oYMLBX;
}

[System.Runtime.Serialization.DataMember]
public
decimal OYLOG {
	get { return oYLOG;}
	set { if (this.oYLOG != value){
			this.oYLOG = value;
			Notify("OYLOG");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal OYENT {
	get { return oYENT;}
	set { if (this.oYENT != value){
			this.oYENT = value;
			Notify("OYENT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYTRCD {
	get { return oYTRCD;}
	set { if (this.oYTRCD != value){
			this.oYTRCD = value;
			Notify("OYTRCD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYTRPR {
	get { return oYTRPR;}
	set { if (this.oYTRPR != value){
			this.oYTRPR = value;
			Notify("OYTRPR");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYDOCN {
	get { return oYDOCN;}
	set { if (this.oYDOCN != value){
			this.oYDOCN = value;
			Notify("OYDOCN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYEXCD {
	get { return oYEXCD;}
	set { if (this.oYEXCD != value){
			this.oYEXCD = value;
			Notify("OYEXCD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYDCCL {
	get { return oYDCCL;}
	set { if (this.oYDCCL != value){
			this.oYDCCL = value;
			Notify("OYDCCL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYMAPT {
	get { return oYMAPT;}
	set { if (this.oYMAPT != value){
			this.oYMAPT = value;
			Notify("OYMAPT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime OYCDAT {
	get { return oYCDAT;}
	set { if (this.oYCDAT != value){
			this.oYCDAT = value;
			Notify("OYCDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal OYCHRM {
	get { return oYCHRM;}
	set { if (this.oYCHRM != value){
			this.oYCHRM = value;
			Notify("OYCHRM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYSTAT {
	get { return oYSTAT;}
	set { if (this.oYSTAT != value){
			this.oYSTAT = value;
			Notify("OYSTAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime OYTDAT {
	get { return oYTDAT;}
	set { if (this.oYTDAT != value){
			this.oYTDAT = value;
			Notify("OYTDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal OYTHRM {
	get { return oYTHRM;}
	set { if (this.oYTHRM != value){
			this.oYTHRM = value;
			Notify("OYTHRM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYNOTE {
	get { return oYNOTE;}
	set { if (this.oYNOTE != value){
			this.oYNOTE = value;
			Notify("OYNOTE");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYSUPL {
	get { return oYSUPL;}
	set { if (this.oYSUPL != value){
			this.oYSUPL = value;
			Notify("OYSUPL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYDOCC {
	get { return oYDOCC;}
	set { if (this.oYDOCC != value){
			this.oYDOCC = value;
			Notify("OYDOCC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYITYP {
	get { return oYITYP;}
	set { if (this.oYITYP != value){
			this.oYITYP = value;
			Notify("OYITYP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYFUT1 {
	get { return oYFUT1;}
	set { if (this.oYFUT1 != value){
			this.oYFUT1 = value;
			Notify("OYFUT1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYFUT2 {
	get { return oYFUT2;}
	set { if (this.oYFUT2 != value){
			this.oYFUT2 = value;
			Notify("OYFUT2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYFUT3 {
	get { return oYFUT3;}
	set { if (this.oYFUT3 != value){
			this.oYFUT3 = value;
			Notify("OYFUT3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYFUT4 {
	get { return oYFUT4;}
	set { if (this.oYFUT4 != value){
			this.oYFUT4 = value;
			Notify("OYFUT4");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYFUT5 {
	get { return oYFUT5;}
	set { if (this.oYFUT5 != value){
			this.oYFUT5 = value;
			Notify("OYFUT5");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYFUT6 {
	get { return oYFUT6;}
	set { if (this.oYFUT6 != value){
			this.oYFUT6 = value;
			Notify("OYFUT6");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYFUT7 {
	get { return oYFUT7;}
	set { if (this.oYFUT7 != value){
			this.oYFUT7 = value;
			Notify("OYFUT7");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYFUT8 {
	get { return oYFUT8;}
	set { if (this.oYFUT8 != value){
			this.oYFUT8 = value;
			Notify("OYFUT8");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYFUT9 {
	get { return oYFUT9;}
	set { if (this.oYFUT9 != value){
			this.oYFUT9 = value;
			Notify("OYFUT9");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYPLNT {
	get { return oYPLNT;}
	set { if (this.oYPLNT != value){
			this.oYPLNT = value;
			Notify("OYPLNT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OYMLBX {
	get { return oYMLBX;}
	set { if (this.oYMLBX != value){
			this.oYMLBX = value;
			Notify("OYMLBX");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is Stxh)
		return	this.oYLOG.Equals(((Stxh)obj).oYLOG) &&
				this.oYENT.Equals(((Stxh)obj).oYENT);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package