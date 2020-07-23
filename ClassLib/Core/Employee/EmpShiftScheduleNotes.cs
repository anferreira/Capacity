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

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class EmpShiftScheduleNotes : BusinessObject {

private int hdrId;
private int detail;
private string topic;
private string notes;

private string name="";

#if !WEB
internal
#else
public
#endif
EmpShiftScheduleNotes(){
	this.hdrId = 0;
	this.detail = 0;
	this.topic = "";
	this.notes = "";
}

internal
EmpShiftScheduleNotes(
	int hdrId,
	int detail,
	string topic,
	string notes)
{
	this.hdrId = hdrId;
	this.detail = detail;
	this.topic = topic;
	this.notes = notes;
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
string Topic {
	get { return topic;}
	set { if (this.topic != value){
			this.topic = value;
			Notify("Topic");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Notes {
	get { return notes;}
	set { if (this.notes != value){
			this.notes = value;
			Notify("Notes");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is EmpShiftScheduleNotes)
		return	this.hdrId.Equals(((EmpShiftScheduleNotes)obj).HdrId) &&
				this.detail.Equals(((EmpShiftScheduleNotes)obj).Detail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}


[System.Runtime.Serialization.DataMember]
public
string Name {
	get { return name; }
	set { if (this.name != value){
			this.name = value;
			Notify("Name");
		}
	}
}

public
void copy(EmpShiftScheduleNotes empShiftScheduleNotes){	
	this.HdrId=empShiftScheduleNotes.HdrId;
	this.Detail=empShiftScheduleNotes.Detail;
	this.Topic=empShiftScheduleNotes.Topic;
	this.Notes=empShiftScheduleNotes.Notes;	

    this.Name= empShiftScheduleNotes.Name;
}

} // class
} // package