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
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class SchMaterialAvail : BusinessObject {

private int id;
private string plant;
private DateTime dateCreated;
private int parentSrcHotId;
private int parentSrcHotDtlId;
private string parentPart;
private int parentSeq;
private decimal parentQtyAdjust;
private decimal maxQty;
private string maxUOM;
private string childSource;
private string childPart;
private int childSeq;
private decimal childQty;
private decimal childCumulativeQOH;
private decimal childAvailQty;
private DateTime dateTime;
private int counterParentSrcHotId;

private decimal childQtyTotal=0;
private string childDescShow="";

#if !WEB
internal
#else
public
#endif
SchMaterialAvail(){
	this.id = 0;
    this.plant = "";
    this.dateCreated = DateTime.Now;
	this.parentSrcHotId = 0;
    this.parentSrcHotDtlId =0;
    this.parentPart = "";
	this.parentSeq = 0;
    this.parentQtyAdjust = 0;
    this.maxQty = 0;
	this.maxUOM = "";
	this.childSource = "";
	this.childPart = "";
	this.childSeq = 0;
	this.childQty = 0;
	this.childCumulativeQOH = 0;
	this.childAvailQty = 0;
	this.dateTime = DateUtil.MinValue;
	this.counterParentSrcHotId = 0;
}

internal
SchMaterialAvail(
	int id,
    string plant,
	DateTime dateCreated,
	int parentSrcHotId,
    int parentSrcHotDtlId,
    string parentPart,
	int parentSeq,
    decimal parentQtyAdjust,
    decimal maxQty,
	string maxUOM,
	string childSource,
	string childPart,
	int childSeq,
	decimal childQty,
	decimal childCumulativeQOH,
	decimal childAvailQty,
	DateTime dateTime,
	int counterParentSrcHotId){
	this.id = id;
	this.dateCreated = dateCreated;
	this.parentSrcHotId = parentSrcHotId;
    this.parentSrcHotDtlId = parentSrcHotDtlId;
    this.parentPart = parentPart;
	this.parentSeq = parentSeq;
    this.parentQtyAdjust = parentQtyAdjust;
    this.maxQty = maxQty;
	this.maxUOM = maxUOM;
	this.childSource = childSource;
	this.childPart = childPart;
	this.childSeq = childSeq;
	this.childQty = childQty;
	this.childCumulativeQOH = childCumulativeQOH;
	this.childAvailQty = childAvailQty;
	this.dateTime = dateTime;
	this.counterParentSrcHotId = counterParentSrcHotId;
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
int ParentSrcHotId {
	get { return parentSrcHotId;}
	set { if (this.parentSrcHotId != value){
			this.parentSrcHotId = value;
			Notify("ParentSrcHotId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int ParentSrcHotDtlId {
	get { return parentSrcHotDtlId; }
	set { if (this.parentSrcHotDtlId != value){
			this.parentSrcHotDtlId = value;
			Notify("ParentSrcHotDtlId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ParentPart {
	get { return parentPart;}
	set { if (this.parentPart != value){
			this.parentPart = value;
			Notify("ParentPart");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int ParentSeq {
	get { return parentSeq;}
	set { if (this.parentSeq != value){
			this.parentSeq = value;
			Notify("ParentSeq");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal ParentQtyAdjust {
	get { return parentQtyAdjust; }
	set { if (this.parentQtyAdjust != value){
			this.parentQtyAdjust = value;
			Notify("ParentQtyAdjust");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal MaxQty {
	get { return maxQty;}
	set { if (this.maxQty != value){
			this.maxQty = value;
			Notify("MaxQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MaxUOM {
	get { return maxUOM;}
	set { if (this.maxUOM != value){
			this.maxUOM = value;
			Notify("MaxUOM");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ChildSource {
	get { return childSource;}
	set { if (this.childSource != value){
			this.childSource = value;
			Notify("ChildSource");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ChildPart {
	get { return childPart;}
	set { if (this.childPart != value){
			this.childPart = value;
			Notify("ChildPart");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int ChildSeq {
	get { return childSeq;}
	set { if (this.childSeq != value){
			this.childSeq = value;
			Notify("ChildSeq");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal ChildQty {
	get { return childQty;}
	set { if (this.childQty != value){
			this.childQty = value;
			Notify("ChildQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal ChildCumulativeQOH {
	get { return childCumulativeQOH;}
	set { if (this.childCumulativeQOH != value){
			this.childCumulativeQOH = value;
			Notify("ChildCumulativeQOH");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal ChildAvailQty {
	get { return childAvailQty;}
	set { if (this.childAvailQty != value){
			this.childAvailQty = value;
			Notify("ChildAvailQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime DateTime {
	get { return dateTime;}
	set { if (this.dateTime != value){
			this.dateTime = value;
			Notify("DateTime");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int CounterParentSrcHotId {
	get { return counterParentSrcHotId;}
	set { if (this.counterParentSrcHotId != value){
			this.counterParentSrcHotId = value;
			Notify("CounterParentSrcHotId");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal ChildQtyTotal {
	get { return childQtyTotal; }
	set { if (this.childQtyTotal != value){
			this.childQtyTotal = value;
			Notify("ChildQtyTotal");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ChildDescShow {
	get { return childDescShow; }
	set { if (this.childDescShow != value){
			this.childDescShow = value;
			Notify("ChildDescShow");
		}
	}
}
        
public override
bool Equals(object obj){
	if (obj is SchMaterialAvail)
		return	this.id.Equals(((SchMaterialAvail)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

} // class
} // package