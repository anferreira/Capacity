using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections;
using Nujit.NujitERP.ClassLib.Util;

namespace HotListReports.Windows.Demand{

public
class HotListCellSel{

private string[]    items;
private int         xindex;
private int         yindex;
private TextBox     textBox;

private string      part;
private int         seq;
private string      mach;
private int         machId;
private string      dept;
private decimal     qty;
private DateTime    dateTime;
private int         hotLisHdrId;
private int         hotListId;

public HotListCellSel(){
    items= null;
    xindex=0;
    yindex=0;
    textBox= null;

    part = "";
    seq = 0;
    mach = "";
    machId =0;
    dept = "";
    qty = 0;
    dateTime  = DateUtil.MinValue;
    hotLisHdrId =0;
    hotListId =0;
} 

public
string[] Items{
	get { return items; }
	set { 
        this.items = value;					
	}
}

public
int XIndex {
	get { return xindex; }
	set { if (this.xindex != value){
			this.xindex = value;			
		}
	}
}

public
int Yindex {
	get { return yindex; }
	set { if (this.yindex != value){
			this.yindex = value;			
		}
	}
}

public
TextBox TextBox{
	get { return textBox; }
	set { 
        this.textBox = value;					
	}
}


public
string Part {
	get { return part; }
	set { if (this.part != value){
			this.part = value;			
		}
	}
}

public
int Seq {
	get { return seq; }
	set { if (this.seq != value){
			this.seq = value;			
		}
	}
}

public
string Mach {
	get { return mach; }
	set { if (this.mach != value){
			this.mach = value;			
		}
	}
}

public
int MachId{
	get { return machId; }
	set { if (this.machId != value){
			this.machId = value;			
		}
	}
}

public
string Dept {
	get { return dept; }
	set { if (this.dept != value){
			this.dept = value;			
		}
	}
}

public
decimal Qty {
	get { return qty; }
	set { if (this.qty != value){
			this.qty = value;			
		}
	}
}

public
DateTime DateTime {
	get { return dateTime; }
	set { if (this.dateTime != value){
			this.dateTime = value;			
		}
	}
}

public
int HotLisHdrId {
	get { return hotLisHdrId; }
	set { if (this.hotLisHdrId != value){
			this.hotLisHdrId = value;			
		}
	}
}

public
int HotListId {
	get { return hotListId; }
	set { if (this.hotListId != value){
			this.hotListId = value;			
		}
	}
}

}
}
