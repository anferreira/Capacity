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
using Nujit.NujitERP.ClassLib.Core.Machines;


namespace HotListReports.Windows.Util{

class BaseModelDatesReport : BaseModelObjects{

protected Machine machine;

protected DateTime dPastDue = DateTime.Now;
protected DateTime dSweek0 = DateTime.Now, dEweek0 = DateTime.Now;//weeks from/monday  - to/sunday
protected DateTime dSweek1 = DateTime.Now, dEweek1 = DateTime.Now;
protected DateTime dSweek2 = DateTime.Now, dEweek2 = DateTime.Now;
protected DateTime dSweek3 = DateTime.Now, dEweek3 = DateTime.Now;
protected DateTime dSweek4 = DateTime.Now, dEweek4 = DateTime.Now;
protected DateTime dSweek5 = DateTime.Now, dEweek5 = DateTime.Now;
protected DateTime dSweek6 = DateTime.Now, dEweek6 = DateTime.Now;
protected DateTime dSweek7 = DateTime.Now, dEweek7 = DateTime.Now;
protected DateTime dSweek8 = DateTime.Now, dEweek8 = DateTime.Now;
protected DateTime dSweek9 = DateTime.Now, dEweek9 = DateTime.Now;
protected DateTime dSweek10 = DateTime.Now, dEweek10 = DateTime.Now;
protected DateTime dSweek11 = DateTime.Now, dEweek11 = DateTime.Now;
protected DateTime dSweek12 = DateTime.Now, dEweek12 = DateTime.Now;
protected DateTime dSweek13 = DateTime.Now, dEweek13 = DateTime.Now;

public 
BaseModelDatesReport(Window window) : base(window){        
    machine = null;    
}

public
Machine Machine {
	get { return machine; }
	set { if (this.machine != value){
			this.machine = value;		
		}
	}
}

public
decimal getHrsPerShift(){
    decimal dvalue = (machine!=null ? machine.getHrsPerShift() : (decimal)7.25);
    return dvalue;
}

public
decimal getStdShiftPerWeek(){
    decimal dvalue = (machine!=null ? machine.getStdShiftPerWeek() : (5*3));
    return dvalue;
}

public
void loadSearchByCombo(ComboBox searchByComboBox){
    searchByComboBox.Items.Add("Machine");
    searchByComboBox.Items.Add("Desc1");
    
    if (searchByComboBox.Items.Count > 0)
        searchByComboBox.SelectedIndex=0;
}

protected
void realodWeeksRanges(){
    //dates
    DateTime    priorMonday = DateTime.Now;
    DateTime    nextSunday = DateTime.Now;

    dPastDue = DateTime.Now;            
    DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now, out dPastDue, out nextSunday);        
    dPastDue = nextSunday.AddDays(-7);             

    CapacityView.loadWeeksDates(out dPastDue,
                                out dSweek0, out  dEweek0,
                                out  dSweek1, out  dEweek1,
                                out  dSweek2, out  dEweek2,
                                out  dSweek3, out  dEweek3,
                                out  dSweek4, out  dEweek4,
                                out  dSweek5, out  dEweek5,
                                out  dSweek6, out  dEweek6,
                                out  dSweek7, out  dEweek7,
                                out  dSweek8, out  dEweek8,
                                out  dSweek9, out  dEweek9,
                                out  dSweek10,out  dEweek10,
                                out  dSweek11,out  dEweek11,
                                out  dSweek12,out  dEweek12,
                                out  dSweek13,out  dEweek13);
}

public
Machine getMachineByFilters(string smachine,string smachDesc,out RoutingContainer routingContainer, string splant,string sdept,string spart){   
    routingContainer=  getCoreFactory().createRoutingContainer();
    Machine machine = null;
    try{ 
        MachineContainer    machineContainer = getCoreFactory().readMachinesByFilters(smachine,smachDesc, splant, sdept,"",false,1);    

        if (machineContainer.Count > 0)
            machine = machineContainer[0];        
            
        if (machine!= null){           
            if (!string.IsNullOrEmpty(spart))                     
                routingContainer= getCoreFactory().getBuildByFilters("",spart,-1,machine.Id,true,false);
            if (routingContainer.Count < 1)
                routingContainer= getCoreFactory().getBuildByFilters("","",-1,machine.Id,true,false);
        }

    } catch (Exception ex) {
        MessageBox.Show("getMachineByFilters Exception: " + ex.Message);        
    }  

    return machine;
}

public
string getPlant(){
    string splant = machine!= null ? machine.Plt : "";

    if (string.IsNullOrEmpty(splant) && capacityHdr!= null)
        splant= capacityHdr.Plant;
    if (string.IsNullOrEmpty(splant) && plannedHdr!= null)
        splant= plannedHdr.Plant;

    if (string.IsNullOrEmpty(splant))
        splant= Configuration.DftPlant;

    return splant;
}       
    

}
}
