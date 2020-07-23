/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class HotListHdr : BusinessObject {

private int id;
private DateTime hotlistRunDate;
private DateTime hotlistExpDate;
private string plant;

#if !WEB
internal
#else
public
#endif
HotListHdr(){
	this.id = 0;
	this.hotlistRunDate = DateUtil.MinValue;
	this.hotlistExpDate = DateUtil.MinValue;
	this.plant = "";
}

internal
HotListHdr(
	int id,
	DateTime hotlistRunDate,
	DateTime hotlistExpDate,
	string plant)
{
	this.id = id;
	this.hotlistRunDate = hotlistRunDate;
	this.hotlistExpDate = hotlistExpDate;
	this.plant = plant;
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
DateTime HotlistRunDate {
	get { return hotlistRunDate;}
	set { if (this.hotlistRunDate != value){
			this.hotlistRunDate = value;
			Notify("HotlistRunDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime HotlistExpDate {
	get { return hotlistExpDate;}
	set { if (this.hotlistExpDate != value){
			this.hotlistExpDate = value;
			Notify("HotlistExpDate");
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

public override
bool Equals(object obj){
	if (obj is HotListHdr)
		return	this.id.Equals(((HotListHdr)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package