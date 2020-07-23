/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class RoutingLabTool : BusinessObject {

private int id;
private int hdrId;
private int detail;
private string type;
private int reqId;
private decimal totEmployees;

private string nameShow; //just to show on screen

public const string LABOUR_TYPE = "L";
public const string TOOL_TYPE   = "T";

#if !WEB
internal
#else
public
#endif
RoutingLabTool(){
	this.id = 0;
	this.hdrId = 0;
	this.detail = 0;
	this.type = LABOUR_TYPE;
	this.reqId = 0;
	this.totEmployees = 0;
    this.nameShow = "";
}

internal
RoutingLabTool(
	int id,
	int hdrId,
	int detail,
	string type,
	int reqId,
	decimal totEmployees,
    string nameShow){
	this.id = id;
	this.hdrId = hdrId;
	this.detail = detail;
	this.type = type;
	this.reqId = reqId;
	this.totEmployees = totEmployees;
    this.nameShow = "";
}

[System.Runtime.Serialization.DataMember]
public
int Id {
	get { return id;}
	set { if (this.id != value){
			this.id = value;
			Notify("Id");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int HdrId {
	get { return hdrId;}
	set { if (this.hdrId != value){
			this.hdrId = value;
			Notify("HdrId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int Detail {
	get { return detail;}
	set { if (this.detail != value){
			this.detail = value;
			Notify("Detail");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Type {
	get { return type;}
	set { if (this.type != value){
			this.type = value;
			Notify("Type");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int ReqId {
	get { return reqId;}
	set { if (this.reqId != value){
			this.reqId = value;
			Notify("ReqId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal TotEmployees {
	get { return totEmployees;}
	set { if (this.totEmployees != value){
			this.totEmployees = value;
			Notify("TotEmployees");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string NameShow {
	get { return nameShow; }
	set { if (this.nameShow != value){
			this.nameShow = value;
			Notify("NameShow");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is RoutingLabTool)
		return	this.hdrId.Equals(((RoutingLabTool)obj).HdrId) &&
				this.detail.Equals(((RoutingLabTool)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
void copy(RoutingLabTool routingLabTool){	
	Id=routingLabTool.Id;
	HdrId=routingLabTool.HdrId;
	Detail=routingLabTool.Detail;
	Type=routingLabTool.Type;
	ReqId=routingLabTool.ReqId;
	TotEmployees=routingLabTool.TotEmployees;	
    NameShow = routingLabTool.NameShow;
}

} // class
} // package