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
class PrHist : BusinessObject {

private string dB;
private string dWDEPT;
private string dWRESR;
private DateTime dWDATE;
private decimal dWSHFT;
private string dWMODE;
private string dWWREF;
private decimal dWSEQN;
private decimal dWTIME;
private string dWPART;
private decimal dWQTYC;
private decimal dWQTYS;
private decimal dWRATE;
private string dWSGRP;
private string dWMAJG;
private decimal dWFSYY;
private decimal dWFSPP;
private decimal dWCPRC;

#if !WEB
internal
#else
public
#endif
PrHist(){
    this.dB = "";
    this.dWDEPT= "";
    this.dWRESR = "";
    this.dWDATE = DateUtil.MinValue;
    this.dWSHFT = 0;
    this.dWMODE= "";
    this.dWWREF= "";
    this.dWSEQN = 0;
    this.dWTIME = 0;
    this.dWPART= "";
    this.dWQTYC = 0;
    this.dWQTYS = 0;
    this.dWRATE = 0;
    this.dWSGRP= "";
    this.dWMAJG= "";
    this.dWFSYY = 0;
    this.dWFSPP = 0;
    this.dWCPRC = 0;
}

[System.Runtime.Serialization.DataMember]
public
DateTime DWDATE {
	get { return dWDATE; }
	set { if (this.dWDATE != value){
			this.dWDATE = value;
			Notify("DWDATE");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string DWPART {
	get { return dWPART; }
	set { if (this.dWPART != value){
			this.dWPART = value;
			Notify("DWPART");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal DWSEQN {
	get { return dWSEQN; }
	set { if (this.dWSEQN != value){
			this.dWSEQN = value;
			Notify("DWSEQN");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal DWQTYC{
	get { return dWQTYC; }
	set { if (this.dWQTYC != value){
			this.dWQTYC = value;
			Notify("DWQTYC");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal DWQTYS{
	get { return dWQTYS; }
	set { if (this.dWQTYS != value){
			this.dWQTYS = value;
			Notify("DWQTYS");
		}
	}
}

        /*
public override
bool Equals(object obj){
	if (obj is Tazm)
		return	this.zMEMPL.Equals(((Tazm)obj).ZMEMPL);
	else
		return false;
}*/

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package