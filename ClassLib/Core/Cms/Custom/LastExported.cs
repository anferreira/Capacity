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
class LastExported : BusinessObject {

public const string LAST_SHIPEXPORT="SHIPEXPORT";

private string code;
private DateTime lastProces;
private string lastId;

#if !WEB
internal
#else
public
#endif
LastExported(){
	this.code = "";
	this.lastProces = DateUtil.MinValue;
	this.lastId = "";
}

internal
LastExported(
	string code,
	DateTime lastProces,
	string lastId)
{
	this.code = code;
	this.lastProces = lastProces;
	this.lastId = lastId;
}

[System.Runtime.Serialization.DataMember]
public
string Code {
	get { return code;}
	set { if (this.code != value){
			this.code = value;
			Notify("Code");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime LastProces {
	get { return lastProces;}
	set { if (this.lastProces != value){
			this.lastProces = value;
			Notify("LastProces");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string LastId {
	get { return lastId;}
	set { if (this.lastId != value){
			this.lastId = value;
			Notify("LastId");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is LastExported)
		return	this.code.Equals(((LastExported)obj).Code);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package