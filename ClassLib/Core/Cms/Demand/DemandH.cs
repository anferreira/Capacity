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
class DemandH : BusinessObject {

private int id;
private DateTime dateTime;
private string status;
private DateTime staDate;
private DateTime endDate;
private string plant;

private DemandDContainer demandDContainer;

#if !WEB
internal
#else
public
#endif
DemandH(){
	this.id = 0;
	this.dateTime = DateUtil.MinValue;
	this.status = "";
	this.staDate = DateUtil.MinValue;	
	this.endDate = DateUtil.MinValue;
    this.plant = "";
	
    this.demandDContainer = new DemandDContainer();
}

internal
DemandH(
	int id,
	DateTime dateTime,	
	string status,
	DateTime staDate,	
	DateTime endDate,
    string splant)
{
	this.id = id;
    this.dateTime = dateTime;	
	this.status = status;
	this.staDate = staDate;	
	this.endDate = endDate;	
    this.plant = plant;
    this.demandDContainer = new DemandDContainer();
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
DateTime StaDate {
	get { return staDate;}
	set { if (this.staDate != value){
			this.staDate = value;
			Notify("StaDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime EndDate {
	get { return endDate;}
	set { if (this.endDate != value){
			this.endDate = value;
			Notify("EndDate");
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
	if (obj is DemandH)
		return	this.id.Equals(((DemandH)obj).Id);
	else
		return false;
}

public override
int GetHashCode(){
	return base.GetHashCode();
}


[System.Runtime.Serialization.DataMember]
public
DemandDContainer DemandDContainer {
    get { return demandDContainer; }
	set { if (this.demandDContainer != value){
			this.demandDContainer = value;
            Notify("DemandDContainer");
		}
	}
}

public
void addDtl(DemandD demandD){
    demandDContainer.Add(demandD);
}

public
int getMaxDetail(){
    int imaxDetail=0;

    for (int i=0;i < demandDContainer.Count;i++){
        DemandD demandD  = demandDContainer[i];
        if ((int)demandD.Detail > imaxDetail)
            imaxDetail= (int)demandD.Detail;
    }
    return imaxDetail;
}

public
void fillRedundances(){
    int icounter= getMaxDetail();

    for (int i=0;i < demandDContainer.Count;i++){
        DemandD demandD  = demandDContainer[i];
        demandD.HdrId = this.Id;
    
        if (demandD.Detail <= 0){ //so if Detail value filled, we never change it, because Hdr/Detail references on DemTransformD record
            icounter++;
            demandD.Detail = icounter; 
        }
    }
}


public
string DateTimeStr {
	get { return DateUtil.getCompleteDateRepresentation(dateTime,DateUtil.MMDDYYYY);}
	set {        
	    Notify("DateTimeStr");
	}
}

public
int countProcessTransform(bool bprocess){
    int icounter=0;

    for (int i = 0; i<demandDContainer.Count;i++){
        DemandD demandD = demandDContainer[i];            
        if (demandD.ProcessTransform == bprocess)
            icounter++;
    }
    return icounter;
}

public
bool removeDuplicates(DemandH demandH){
    ArrayList   arrayOldRemoved     = new ArrayList();
    DemandD     demandD             = null;
    DemandD     demandDFound        = null;
    bool        batLeastOneRemoved  = false;

    if (demandH!= null){
        for (int i=0; i < demandH.DemandDContainer.Count; i++){
            demandD = demandH.DemandDContainer[i];
            
            demandDFound = this.DemandDContainer.getByExact(demandD.Source,demandD.RelNum,demandD.TrlpKeyId, demandD.BillTo, demandD.ShipTo, demandD.Part, demandD.SDate, demandD.NetQty);
            if (demandDFound != null) { 
                batLeastOneRemoved=true;
                demandH.DemandDContainer.RemoveAt(i);
                i--;
                arrayOldRemoved.Add(demandD);
            }                     
        }        
    }
    return batLeastOneRemoved;
}

} // class
} // package