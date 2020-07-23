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
class Raca : BusinessObject {

private decimal qFENT;
private decimal qFCKEY;
private DateTime qFSDAT;
private decimal qFSTIM;
private decimal qFPCUM;
private decimal qFNCUM;
private decimal qFADJQ;
private string qFREAS;

#if !WEB
internal
#else
public
#endif
Raca(){
	this.qFENT = 0;
	this.qFCKEY = 0;
	this.qFSDAT = DateUtil.MinValue;
	this.qFSTIM = 0;
	this.qFPCUM = 0;
	this.qFNCUM = 0;
	this.qFADJQ = 0;
	this.qFREAS = "";
}

internal
Raca(
	decimal qFENT,
	decimal qFCKEY,
	DateTime qFSDAT,
	decimal qFSTIM,
	decimal qFPCUM,
	decimal qFNCUM,
	decimal qFADJQ,
	string qFREAS)
{
	this.qFENT = qFENT;
	this.qFCKEY = qFCKEY;
	this.qFSDAT = qFSDAT;
	this.qFSTIM = qFSTIM;
	this.qFPCUM = qFPCUM;
	this.qFNCUM = qFNCUM;
	this.qFADJQ = qFADJQ;
	this.qFREAS = qFREAS;
}

[System.Runtime.Serialization.DataMember]
public
decimal QFENT {
	get { return qFENT;}
	set { if (this.qFENT != value){
			this.qFENT = value;
			Notify("QFENT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QFCKEY {
	get { return qFCKEY;}
	set { if (this.qFCKEY != value){
			this.qFCKEY = value;
			Notify("QFCKEY");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime QFSDAT {
	get { return qFSDAT;}
	set { if (this.qFSDAT != value){
			this.qFSDAT = value;
			Notify("QFSDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QFSTIM {
	get { return qFSTIM;}
	set { if (this.qFSTIM != value){
			this.qFSTIM = value;
			Notify("QFSTIM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QFPCUM {
	get { return qFPCUM;}
	set { if (this.qFPCUM != value){
			this.qFPCUM = value;
			Notify("QFPCUM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QFNCUM {
	get { return qFNCUM;}
	set { if (this.qFNCUM != value){
			this.qFNCUM = value;
			Notify("QFNCUM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QFADJQ {
	get { return qFADJQ;}
	set { if (this.qFADJQ != value){
			this.qFADJQ = value;
			Notify("QFADJQ");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string QFREAS {
	get { return qFREAS;}
	set { if (this.qFREAS != value){
			this.qFREAS = value;
			Notify("QFREAS");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is Raca)
		return	this.qFENT.Equals(((Raca)obj).QFENT);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package