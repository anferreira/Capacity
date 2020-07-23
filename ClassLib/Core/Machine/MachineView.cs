using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.Machines{

public class MachineView : Machine  {

private DateTime dateLastPlanned;
private DateTime planDate;
private int priority;
private int availableShifts;
private int remainsShifts;
private string part;


public
MachineView(): base(){
    this.dateLastPlanned = DateUtil.MinValue;
    this.planDate = DateUtil.MinValue;
    this.priority = 0;
    this.availableShifts = 0;
    this.remainsShifts = 0;
    this.part = "";
}

public
DateTime DateLastPlanned {
	get { return dateLastPlanned; }
	set { if (this.dateLastPlanned != value){
			this.dateLastPlanned = value;			
		}
	}
}

public
DateTime PlanDate {
	get { return planDate; }
	set { if (this.planDate != value){
			this.planDate = value;			
		}
	}
}

public
int Priority {
	get { return priority; }
	set { if (this.priority != value){
			this.priority = value;			
		}
	}
}

public
int AvailableShifts{
	get { return availableShifts; }
	set { if (this.availableShifts != value){
			this.availableShifts = value;			
		}
	}
}

public
int RemainsShifts{
	get { return remainsShifts; }
	set { if (this.remainsShifts != value){
			this.remainsShifts = value;			
		}
	}
}

public
string Part{
	get { return part; }
	set { if (this.part != value){
			this.part = value;			
		}
	}
}


}
}
