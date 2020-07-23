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
using System.Collections;

namespace Nujit.NujitERP.ClassLib.Core.ScheduleDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class ScheduleMaterialConsumPart : BusinessObject {

private int hdrId;
private int detail;
private int subDetail;
private int subSubDetail;
private string matPart;
private int matSeq;
private decimal qtyReq;
private decimal qtyReported;
private decimal qtyConsum;
private string matType;

private DateTime startDate;

#if !WEB
internal
#else
public
#endif
ScheduleMaterialConsumPart(){
	this.hdrId = 0;
	this.detail = 0;
	this.subDetail = 0;
	this.subSubDetail = 0;	
	this.matPart = "";
	this.matSeq = 0;
	this.qtyReq = 0;
	this.qtyReported = 0;
	this.qtyConsum = 0;
	this.matType = "";

    this.startDate = DateUtil.MinValue;
}

internal
ScheduleMaterialConsumPart(
	int hdrId,
	int detail,
	int subDetail,
	int subSubDetail,	
	string matPart,
	int matSeq,
	decimal qtyReq,
	decimal qtyReported,
	decimal qtyConsum,
	string matType)
{
	this.hdrId = hdrId;
	this.detail = detail;
	this.subDetail = subDetail;
	this.subSubDetail = subSubDetail;	
	this.matPart = matPart;
	this.matSeq = matSeq;
	this.qtyReq = qtyReq;
	this.qtyReported = qtyReported;
	this.qtyConsum = qtyConsum;
	this.matType = matType;

    this.startDate = DateUtil.MinValue;
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
int SubDetail {
	get { return subDetail;}
	set { if (this.subDetail != value){
			this.subDetail = value;
			Notify("SubDetail");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int SubSubDetail {
	get { return subSubDetail;}
	set { if (this.subSubDetail != value){
			this.subSubDetail = value;
			Notify("SubSubDetail");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MatPart {
	get { return matPart;}
	set { if (this.matPart != value){
			this.matPart = value;
			Notify("MatPart");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int MatSeq {
	get { return matSeq;}
	set { if (this.matSeq != value){
			this.matSeq = value;
			Notify("MatSeq");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyReq {
	get { return qtyReq;}
	set { if (this.qtyReq != value){
			this.qtyReq = value;
			Notify("QtyReq");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyReported {
	get { return qtyReported;}
	set { if (this.qtyReported != value){
			this.qtyReported = value;
            RemainsQty= RemainsQty;
			Notify("QtyReported");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyConsum {
	get { return qtyConsum;}
	set { if (this.qtyConsum != value){
			this.qtyConsum = value;
            RemainsQty= RemainsQty;
            Notify("QtyConsum");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string MatType {
	get { return matType;}
	set { if (this.matType != value){
			this.matType = value;
			Notify("MatType");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime StartDate {
	get { return startDate; }
	set { if (this.startDate != value){
			this.startDate = value;
            StartShift= StartShift;                            
			Notify("StartDate");
		}
	}
}
[System.Runtime.Serialization.DataMember]
public
int StartShift {
	get { return calculateShift();}
	set { 
			Notify("StartShift");		
	}
}

public
string MatTypeDesc {
	get {
            string sdesc="";
            switch(MatType) {
                case "M": sdesc = "Manufactured";break;
                case "P": sdesc = "Purchased";break;                    
            }
        return sdesc;            
    }set {
	}
}

public
decimal RemainsQty {
	get { return QtyConsum - QtyReported;}
	set { 	
        Notify("RemainsQty");              	
	}
}

public override
bool Equals(object obj){
	if (obj is ScheduleMaterialConsumPart)
		return	this.hdrId.Equals(((ScheduleMaterialConsumPart)obj).HdrId) &&
				this.detail.Equals(((ScheduleMaterialConsumPart)obj).Detail) &&
				this.subDetail.Equals(((ScheduleMaterialConsumPart)obj).SubDetail) &&
				this.subSubDetail.Equals(((ScheduleMaterialConsumPart)obj).SubSubDetail);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}

public
int  calculateShift(){
    return  DateUtil.getShiftNum(StartDate);    
}

public
void copy(ScheduleMaterialConsumPart scheduleMaterialConsumPart){
	this.HdrId=scheduleMaterialConsumPart.HdrId;
	this.Detail=scheduleMaterialConsumPart.Detail;
	this.SubDetail=scheduleMaterialConsumPart.SubDetail;
	this.SubSubDetail=scheduleMaterialConsumPart.SubSubDetail;	
	this.MatPart=scheduleMaterialConsumPart.MatPart;
	this.MatSeq=scheduleMaterialConsumPart.MatSeq;
	this.QtyReq=scheduleMaterialConsumPart.QtyReq;
	this.QtyReported=scheduleMaterialConsumPart.QtyReported;
	this.QtyConsum=scheduleMaterialConsumPart.QtyConsum;
	this.MatType=scheduleMaterialConsumPart.MatType;
    this.StartDate = scheduleMaterialConsumPart.StartDate;    
}

} // class
} // package