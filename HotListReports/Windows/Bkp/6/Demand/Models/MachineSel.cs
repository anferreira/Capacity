using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Machines;

namespace HotListReports.Windows.Demand{

class MachineSel : Machine{

private bool   isChecked;


public MachineSel() : base(){    
    this.isChecked = true;
}

public MachineSel(Machine machine) : base(){
    this.Id = machine.Id;
    this.setPlt(machine.Plt);
    this.setDept(machine.Dept);
    this.setMach(machine.Mach);
    this.setDes1(machine.Des1);
    this.setDes2(machine.Des2);
    this.setDes3(machine.Des3);
    this.setDes4(machine.Des4);    
    this.setInOut(machine.InOut);
    this.setMachTyp(machine.MachTyp);
    this.setSchType(machine.SchType);
    this.setUtilPer(machine.UtilPer);
    this.setInvDrFr(machine.InvDrFr);
    this.setInvRecTo(machine.InvRecTo);
    this.setCableLn(machine.CableLn);
    this.setLnUom(machine.LnUom);
    this.setSpeed(machine.Speed);
    this.setMaxRacks(machine.MaxRacks);
    this.setDefSpaceRack(machine.DefSpaceRack);
    this.setDefSpaceUom(machine.DefSpaceUom);
    this.setMaxWgt(machine.MaxWgt);
    this.setMaxWgtUom(machine.MaxWgtUom);
    this.isChecked = true;
}

public
bool IsChecked {
	get { return isChecked; }
	set { if (this.isChecked != value){
			this.isChecked = value;
			//Notify("IsChecked");
		}
	}
}




}
}
