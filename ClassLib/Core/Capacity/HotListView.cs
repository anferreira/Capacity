
using System;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
    [System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class HotListView : HotListViewBase {

private string prodID;
private int seq;
private string uom;
private decimal machCyc;
private decimal qty;
private decimal qoh;
private DateTime dateTime;
private DateTime startDate;
private DateTime endDate;
private string minorGroup;
private string majorGroup;
private string weekTitle;    
private string scheduled;
private CapacityView.SHOW_TYPE showType;

private HotListViewContainer hotListViewContainer;


#if !WEB
internal
#else
public
#endif
HotListView() : base(){
	prodID="";
    seq = 0;
    uom = "";  
    machCyc=0;
    qty = 0;
    qoh=0;    
    dateTime = DateUtil.MinValue;
    startDate = DateUtil.MinValue; 
    endDate = DateUtil.MinValue; 
    minorGroup="";
    majorGroup="";
    weekTitle = "";
    scheduled = Constants.STRING_NO;
    showType = CapacityView.SHOW_TYPE.TYPE_NORMAL;
    hotListViewContainer = new HotListViewContainer();
}

[System.Runtime.Serialization.DataMember]
public
string ProdID {
	get { return prodID; }
	set { if (this.prodID != value){
			this.prodID = value;
			Notify("ProdID");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int Seq {
	get { return seq; }
	set { if (this.seq != value){
			this.seq = value;
			Notify("Seq");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
string Uom {
	get { return uom; }
	set { if (this.uom != value){
			this.uom = value;
			Notify("Uom");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal MachCyc {
	get { return machCyc; }
	set { if (this.machCyc != value){
			this.machCyc = value;
			Notify("MachCyc");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
decimal Qty {
	get { return qty; }
	set { if (this.qty != value){
			this.qty = value;
			Notify("Qty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal Qoh {
	get { return qoh; }
	set { if (this.qoh != value){
			this.qoh = value;
			Notify("Qoh");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime DateTime {
	get { return dateTime; }
	set { if (this.dateTime != value){
			this.dateTime = value;
			Notify("DateTime");   
        }
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime StartDate {
	get { return startDate; }
	set { if (this.startDate != value){
			this.startDate = value;
			Notify("StartDate");   
        }
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime EndDate {
	get { return endDate; }
	set { if (this.endDate != value){
			this.endDate = value;
			Notify("EndDate");
		}
	}
}
 
[System.Runtime.Serialization.DataMember]
public
string MinorGroup {
	get { return minorGroup; }
	set { if (this.minorGroup != value){
			this.minorGroup = value;
			Notify("MinorGroup");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
string MajorGroup {
	get { return majorGroup; }
	set { if (this.majorGroup != value){
			this.majorGroup = value;
			Notify("MajorGroup");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string WeekTitle {
	get { return weekTitle; }
	set { if (this.weekTitle != value){
			this.weekTitle = value;
			Notify("WeekTitle");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
string Scheduled {
	get { return scheduled; }
	set { if (this.scheduled != value){
			this.scheduled = value;
			Notify("Scheduled");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
CapacityView.SHOW_TYPE ShowType {
	get { return showType; }
	set { if (this.showType != value){
			this.showType = value;
			Notify("ShowType");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
HotListViewContainer HotListViewContainer {
	get { return hotListViewContainer; }
	set { if (this.hotListViewContainer != value){
			this.hotListViewContainer = value;
			Notify("HotListViewContainer");
		}
	}
}

public
string getCellValue(){
    string stext = "";

    switch(showType){
        case CapacityView.SHOW_TYPE.TYPE_NORMAL:
            stext = Convert.ToInt64(qty).ToString();
            break;     
    }

    return stext;        
}

public
void copy(HotListView hotListView){
    base.copy(hotListView);
    this.ProdID = hotListView.ProdID;
    this.Seq = hotListView.Seq;
    this.Uom = hotListView.Uom;
    this.MachineId = hotListView.MachineId;
    this.Plant = hotListView.Plant;
    this.Dept = hotListView.Dept;
    this.Mach = hotListView.Mach;
    this.MachCyc = hotListView.MachCyc;
    this.Qty = hotListView.Qty;
    this.Qoh = hotListView.Qoh;
    this.DateTime = hotListView.DateTime;
    this.StartDate = hotListView.StartDate;
    this.EndDate = hotListView.EndDate;
    this.MinorGroup = hotListView.MinorGroup;
    this.MajorGroup = hotListView.MajorGroup;      
}


}
}
