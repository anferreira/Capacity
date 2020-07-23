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
class EdiTransTP : BusinessObject {

private string plant;
private string tPartner;
private int detail;
private int logFrom;
private int logTo;
private DateTime dateProces;
private DateTime dateCreated;

#if !WEB
internal
#else
public
#endif
EdiTransTP(){    
    this.plant = "";
    this.tPartner = "";
	this.detail = 0;
	this.logFrom = 0;
	this.logTo = 0;
    this.dateProces = DateUtil.MinValue;
    this.dateCreated = DateTime.Now;
}

internal
EdiTransTP(
    string plant,
    string tPartner,
	int detail,
	int logFrom,
	int logTo,
    DateTime dateProces,
    DateTime dateCreated){
    this.plant = plant;
    this.tPartner = tPartner;
	this.detail = detail;
	this.logFrom = logFrom;
	this.logTo = logTo;
    this.dateProces = dateProces;
    this.dateCreated = dateCreated;
}

[System.Runtime.Serialization.DataMember]
public
string Plant {
	get { return plant;}
	set { if (this.plant != value){
			this.plant = value;
			Notify("Plant");
		}
	}
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
int LogFrom {
	get { return logFrom;}
	set { if (this.logFrom != value){
			this.logFrom = value;
			Notify("LogFrom");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int LogTo {
	get { return logTo;}
	set { if (this.logTo != value){
			this.logTo = value;
			Notify("LogTo");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime DateProces {
	get { return dateProces; }
	set { if (this.dateProces != value){
			this.dateProces = value;
			Notify("DateProces");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime DateCreated {
	get { return dateCreated;}
	set { if (this.dateCreated != value){
			this.dateCreated = value;
			Notify("DateCreated");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is EdiTransTP)
		return  this.plant.Equals(((EdiTransTP)obj).Plant) &&
                this.tPartner.Equals(((EdiTransTP)obj).TPartner) &&
				this.detail.Equals(((EdiTransTP)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package