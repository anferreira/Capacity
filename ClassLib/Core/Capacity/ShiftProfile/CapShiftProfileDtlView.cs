/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class CapShiftProfileDtlView : CapShiftProfileDtl {

private CellShiftProfileDtl dayCell1;
private CellShiftProfileDtl dayCell2;
private CellShiftProfileDtl dayCell3;
private CellShiftProfileDtl dayCell4;
private CellShiftProfileDtl dayCell5;
private CellShiftProfileDtl dayCell6;
private CellShiftProfileDtl dayCell7;

private CellTitles cellTitles;

#if !WEB
        internal
#else
public
#endif
CapShiftProfileDtlView() : base(){
    init();
}

private
void init(){
    this.dayCell1 = new CellShiftProfileDtl();dayCell1.XIndex=1;
    this.dayCell2 = new CellShiftProfileDtl();dayCell2.XIndex=2;
    this.dayCell3 = new CellShiftProfileDtl();dayCell3.XIndex=3;
    this.dayCell4 = new CellShiftProfileDtl();dayCell4.XIndex=4;
    this.dayCell5 = new CellShiftProfileDtl();dayCell5.XIndex=5;
    this.dayCell6 = new CellShiftProfileDtl();dayCell6.XIndex=6;
    this.dayCell7 = new CellShiftProfileDtl();dayCell7.XIndex=7;
    
    this.cellTitles = new CellTitles();        
    this.cellTitles.Title1 = "Required";
    this.cellTitles.Title2 = "Planned";            
}

internal
CapShiftProfileDtlView(CapShiftProfileDtl capShiftProfileDtl) : base (capShiftProfileDtl.HdrId,
                                                                        capShiftProfileDtl.Detail,
                                                                        capShiftProfileDtl.ShiftTaskId,
                                                                        capShiftProfileDtl.NumPeople,
                                                                        capShiftProfileDtl.NewPeople,
                                                                        capShiftProfileDtl.Hours,
                                                                        capShiftProfileDtl.TaskNameShow,
                                                                        capShiftProfileDtl.DirIndShow,
                                                                        capShiftProfileDtl.ShiftNumShow){
    init(); 
}

[System.Runtime.Serialization.DataMember]
public
CellTitles CellTitles {
	get { return cellTitles; }
	set { if (this.cellTitles != value){
			this.cellTitles = value;
			Notify("CellTitles");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellShiftProfileDtl DayCell1 {
	get { return dayCell1; }
	set { if (this.dayCell1 != value){
			this.dayCell1 = value;
			Notify("DayCell1");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellShiftProfileDtl DayCell2 {
	get { return dayCell2; }
	set { if (this.dayCell2 != value){
			this.dayCell2 = value;
			Notify("DayCell2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellShiftProfileDtl DayCell3 {
	get { return dayCell3; }
	set { if (this.dayCell3 != value){
			this.dayCell3 = value;
			Notify("DayCell3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellShiftProfileDtl DayCell4 {
	get { return dayCell4; }
	set { if (this.dayCell4 != value){
			this.dayCell4 = value;
			Notify("DayCell4");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellShiftProfileDtl DayCell5 {
	get { return dayCell5; }
	set { if (this.dayCell5 != value){
			this.dayCell5 = value;
			Notify("DayCell5");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellShiftProfileDtl DayCell6 {
	get { return dayCell6; }
	set { if (this.dayCell6 != value){
			this.dayCell6 = value;
			Notify("DayCell6");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CellShiftProfileDtl DayCell7 {
	get { return dayCell7; }
	set { if (this.dayCell7 != value){
			this.dayCell7 = value;
			Notify("DayCell7");
		}
	}
}


} // class
} // package