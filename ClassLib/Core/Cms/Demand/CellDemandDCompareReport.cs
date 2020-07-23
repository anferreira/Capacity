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
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;


namespace Nujit.NujitERP.ClassLib.Core.Cms{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class CellDemandDCompareReport : BusinessObject {

protected decimal qtyNew;
protected decimal qtyOld;
protected decimal qtyDiff;
protected DateTime startDate;
protected DateTime endDate;
protected int index;
protected int xindex;
protected string scolor;


public
CellDemandDCompareReport(): base(){            
    this.qtyNew = 0;
    this.qtyOld = 0;
    this.qtyDiff= 0;
    this.index =0;
    this.xindex = 0;
    
    this.startDate = DateUtil.MinValue;
    this.endDate = DateUtil.MinValue;
    this.scolor  = "Black";
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyNew {
	get { return qtyNew; }
	set { if (this.qtyNew != value){
			this.qtyNew = value;            
			Notify("QtyNew");
            Notify("QtyDiff");
            Notify("QtyDiffResult");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyOld {
	get { return qtyOld; }
	set { if (this.qtyOld != value){
			this.qtyOld = value;
			Notify("QtyOld");   
            Notify("QtyDiff");
            Notify("QtyDiffResult");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyDiff {
	get { return qtyDiff; }
	set { if (this.qtyDiff != value){
			this.qtyDiff = value;            
			Notify("QtyDiff");            
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyDiffResult {
	get {
        qtyDiff = QtyNew - QtyOld;
        return qtyDiff;
    }
}

[System.Runtime.Serialization.DataMember]
public
DateTime StartDate {
	get { return startDate;}
	set { if (this.startDate != value){
			this.startDate = value;
			Notify("StartDate");
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
int Index {
	get { return index;}
	set { if (this.index != value){
			this.index = value;
			Notify("Index");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int XIndex {
	get { return xindex; }
	set { if (this.xindex != value){
			this.xindex = value;
			Notify("xindex");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Color {
	get { return scolor; }
	set { if (this.scolor != value){
			this.scolor = value;
			Notify("Color");
		}
	}
}

public
string concatQtys(char sep){
    string saux =   Convert.ToInt32(QtyNew).ToString() + sep + Convert.ToInt32(QtyOld).ToString() + sep + 
                    Convert.ToInt32(QtyDiffResult).ToString();
    return saux;
}

} // class
} // package