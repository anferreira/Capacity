/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.ObjectModel;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.Customer{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class TradingPartner : BusinessObject {

private string tPartner;
private string exportMode;

#if !WEB
internal
#else
public
#endif
TradingPartner(){
	this.tPartner = "";
	this.exportMode = "";    
}

internal
TradingPartner(
	string tPartner,
	string exportMode){
	this.tPartner = tPartner;
	this.exportMode = exportMode;    
}

[System.Runtime.Serialization.DataMember]
public
string TPartner {
	get { return tPartner;}
	set { if (this.tPartner != value){
			this.tPartner = value;
			Notify("TPartner");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ExportMode {
	get { return exportMode;}
	set { if (this.exportMode != value){
			this.exportMode = value;
			Notify("ExportMode");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is TradingPartner)
		return	this.tPartner.Equals(((TradingPartner)obj).TPartner);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package