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
class ShipExportSumCompare : ShipExportSum {

private int qtyOrderedExcel;
private int qtyShippedExcel;
private DateTime orderDateExcel;
private DateTime custRequestDateExcel;
private DateTime shipDateExcel;
private int pPMQtyExcel;
private int actLeadTimeExcel;
private string pPAPExcel;

internal ShipExportSumCompare() : base(){
	this.qtyOrderedExcel = 0;
	this.qtyShippedExcel = 0;
	this.orderDateExcel = DateUtil.MinValue;
	this.custRequestDateExcel = DateUtil.MinValue;
	this.shipDateExcel = DateUtil.MinValue;
	this.pPMQtyExcel = 0;
    this.actLeadTimeExcel = 0;
    this.pPAPExcel = "";
}

[System.Runtime.Serialization.DataMember]
public
int QtyOrderedExcel {
	get { return qtyOrderedExcel;}
	set { if (this.qtyOrderedExcel != value){
			this.qtyOrderedExcel = value;
			Notify("QtyOrderedExcel");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int QtyShippedExcel {
	get { return qtyShippedExcel;}
	set { if (this.qtyShippedExcel != value){
			this.qtyShippedExcel = value;
			Notify("QtyShippedExcel");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime OrderDateExcel {
	get { return orderDateExcel;}
	set { if (this.orderDateExcel != value){
			this.orderDateExcel = value;
			Notify("OrderDateExcel");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime CustRequestDateExcel {
	get { return custRequestDateExcel;}
	set { if (this.custRequestDateExcel != value){
			this.custRequestDateExcel = value;
			Notify("CustRequestDateExcel");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime ShipDateExcel {
	get { return shipDateExcel;}
	set { if (this.shipDateExcel != value){
			this.shipDateExcel = value;
			Notify("ShipDateExcel");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int PPMQtyExcel {
	get { return pPMQtyExcel;}
	set { if (this.pPMQtyExcel != value){
			this.pPMQtyExcel = value;
			Notify("PPMQtyExcel");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int ActLeadTimeExcel {
	get { return actLeadTimeExcel; }
	set { if (this.actLeadTimeExcel != value){
			this.actLeadTimeExcel = value;
			Notify("ActLeadTimeExcel");
		}
	}
}
   
[System.Runtime.Serialization.DataMember]
public
string PPAPExcel {
	get { return pPAPExcel; }
	set { if (this.pPAPExcel != value){
			this.pPAPExcel = value;
			Notify("PPAPExcel");
		}
	}
}


} // class
} // package