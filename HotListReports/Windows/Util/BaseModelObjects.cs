using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Sales.PackSlips;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core.Cms;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;
using Nujit.NujitERP.ClassLib.Core.ScheduleDemand;
using Nujit.NujitERP.ClassLib.Core.Planned;

using Nujit.NujitWms.WinForms.Util.Grids;
using Nujit.NujitWms.WinForms.Util.Converters;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using System.Collections.ObjectModel;
using System.Collections;
using HotListReports.Windows.Util;
using Nujit.NujitERP.ClassLib.Common;
using HotListReports.Windows.Demand;



namespace HotListReports.Windows.Util{

class BaseModelObjects : BaseModel2{

protected CapacityHdr           capacityHdr;
protected PlannedHdr            plannedHdr;
protected InventoryObjectiveHdr inventoryObjectiveHdr;
protected ScheduleHdr           scheduleHdr;

public
BaseModelObjects(Window window) : base(window){    
    capacityHdr = null;
    plannedHdr = null;
    inventoryObjectiveHdr = null;    
    scheduleHdr = null;
}

public
CapacityHdr CapacityHdr{
	get { return capacityHdr; }
	set { if (this.capacityHdr != value){
			this.capacityHdr = value;		
		}
	}
}

public
PlannedHdr PlannedHdr{
	get { return plannedHdr; }
	set { if (this.plannedHdr != value){
			this.plannedHdr = value;		
		}
	}
}

public
ScheduleHdr ScheduleHdr{
	get { return scheduleHdr; }
	set { if (this.scheduleHdr != value){
			this.scheduleHdr = value;		
		}
	}
}


}
}
