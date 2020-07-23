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
class CustLead : BusinessObject {

private int id;
private string custId;
private string majSalesCode;
private string minSalesCode;
private int leadTime;

#if !WEB
internal
#else
public
#endif
CustLead(){
	this.id = 0;
	this.custId = "";
	this.majSalesCode = "";
	this.minSalesCode = "";
	this.leadTime = 0;
}

internal
CustLead(
	int id,
	string custId,
	string majSalesCode,
	string minSalesCode,
	int leadTime)
{
	this.id = id;
	this.custId = custId;
	this.majSalesCode = majSalesCode;
	this.minSalesCode = minSalesCode;
	this.leadTime = leadTime;
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
string CustId {
	get { return custId;}
	set { if (this.custId != value){
			this.custId = value;
			Notify("CustId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MajSalesCode {
	get { return majSalesCode;}
	set { if (this.majSalesCode != value){
			this.majSalesCode = value;
			Notify("MajSalesCode");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MinSalesCode {
	get { return minSalesCode;}
	set { if (this.minSalesCode != value){
			this.minSalesCode = value;
			Notify("MinSalesCode");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int LeadTime {
	get { return leadTime;}
	set { if (this.leadTime != value){
			this.leadTime = value;
			Notify("LeadTime");
		}
	}
}

public override
bool Equals(object obj){
	if (obj is CustLead)
		return	this.custId.Equals(((CustLead)obj).CustId) &&
				this.majSalesCode.Equals(((CustLead)obj).MajSalesCode) &&
				this.minSalesCode.Equals(((CustLead)obj).MinSalesCode);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package