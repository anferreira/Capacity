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
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core.Cms{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class DemTransformH : BusinessObject {

private int id;
private DateTime dateCreated;
private int demandHdr;
private string status;
private string plant;
private string weekMode;
private string monthMode;

private DemTransformDContainer demTransformDContainer;

#if !WEB
internal
#else
public
#endif
DemTransformH(){
	this.id = 0;
	this.dateCreated = DateUtil.MinValue;
	this.demandHdr = 0;
	this.status = "";
    this.plant = "";
    this.weekMode = Constants.TIME_CODE_WEEKLY;
    this.monthMode = Constants.TIME_CODE_WEEKLY;
    this.demTransformDContainer = new DemTransformDContainer();
}

internal
DemTransformH(
	int id,
	DateTime dateCreated,
	int demandHdr,
	string status,
    string plant,
    string weekMode, string monthMode){
	this.id = id;
	this.dateCreated = dateCreated;
	this.demandHdr = demandHdr;
	this.status = status;
    this.plant = plant;
    this.weekMode = weekMode;
    this.monthMode = monthMode;
    this.demTransformDContainer = new DemTransformDContainer();
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
DateTime DateCreated {
	get { return dateCreated;}
	set { if (this.dateCreated != value){
			this.dateCreated = value;
			Notify("DateCreated");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int DemandHdr {
	get { return demandHdr;}
	set { if (this.demandHdr != value){
			this.demandHdr = value;
			Notify("DemandHdr");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Status {
	get { return status;}
	set { if (this.status != value){
			this.status = value;
			Notify("Status");
		}
	}
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
string WeekMode {
	get { return weekMode; }
	set { if (this.weekMode != value){
			this.weekMode = value;
			Notify("WeekMode");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MonthMode {
	get { return monthMode; }
	set { if (this.monthMode != value){
			this.monthMode = value;
			Notify("MonthMode");
		}
	}
}
  
[System.Runtime.Serialization.DataMember]
public
DemTransformDContainer DemTransformDContainer{
	get { return demTransformDContainer; }
	set { if (this.demTransformDContainer != value){
			this.demTransformDContainer = value;
			Notify("DemTransformDContainer");
		}
	}
}

public
void fillRedundances(){
    for (int i=0;i < demTransformDContainer.Count;i++){
        DemTransformD demTransformD = demTransformDContainer[i];
        demTransformD.HdrId = this.Id;
        demTransformD.Detail = i + 1; 
    }
}

public override
bool Equals(object obj){
	if (obj is DemTransformH)
		return	this.id.Equals(((DemTransformH)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package