/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;


namespace Nujit.NujitERP.ClassLib.Core.Reports{

#if !POCKET_PC
    [System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class RP1268H : BusinessObject {

private int id;
private DateTime date;
private DateTime time;
private string status;

private RP1268DContainer rP1268DContainer;

#if !WEB
internal
#else
public
#endif
RP1268H(){
	this.id = 0;
	this.date = DateTime.Now;
    this.time = DateTime.Now;
    this.status = "";
    this.rP1268DContainer = new RP1268DContainer();
}

internal
RP1268H(
	int id,
	DateTime dateRun,DateTime time,string status){
	this.id = id;
	this.date = dateRun;
    this.time = time;
    this.status = status;
    this.rP1268DContainer = new RP1268DContainer();
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
DateTime Date {
	get { return date;}
	set { if (this.date != value){
			this.date = value;
			Notify("Date");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime Time {
	get { return time;}
	set { if (this.time != value){
			this.time = value;
			Notify("Time");
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

public override
bool Equals(object obj){
	if (obj is RP1268H)
		return	this.id.Equals(((RP1268H)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

[System.Runtime.Serialization.DataMember]
public
RP1268DContainer RP1268DContainer{
	get { return rP1268DContainer;}
	set { if (this.rP1268DContainer != value){
			this.rP1268DContainer = value;
			Notify("RP1268DContainer");
		}
	}
}

public
void fillRedundances(){
    for (int i=0; i < this.rP1268DContainer.Count;i++){
        this.rP1268DContainer[i].HdrId = this.Id;
        this.rP1268DContainer[i].Detail=i+1;
        this.rP1268DContainer[i].fillRedundances();

        if (this.rP1268DContainer[i].CDPast > 9999999999)
            this.rP1268DContainer[i].CDPast = 9999999999;
    }   
}        

} // class
} // package