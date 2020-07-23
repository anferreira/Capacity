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
class PrHistSumView : BusinessObject {

private decimal dWSEQN;
private string dWPART;
private decimal dWQTYC;
private decimal dWQTYS;

#if !WEB
internal
#else
public
#endif
PrHistSumView(){
    this.dWSEQN = 0;
    this.dWPART = "";
    this.dWQTYC = 0;
    this.dWQTYS =0;
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

public override
bool Equals(object obj){
	if (obj is PrHistSumView)
		return	this.DWPART.ToUpper().Equals(((PrHistSumView)obj).DWPART.ToUpper()) &&
                this.DWSEQN.Equals(((PrHistSumView)obj).DWSEQN);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package