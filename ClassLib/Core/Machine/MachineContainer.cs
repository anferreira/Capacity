/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.ObjectModel;
using Nujit.NujitERP.ClassLib.Util;
using System.Collections;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core.Machines{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class MachineContainer : ObservableCollection<Machine> { 
#else
class MachineContainer : Collection<Machine> { 
#endif

internal
MachineContainer() : base(){
}

public
Machine getByKey(string plt,string dept,string mach){
	Machine Machine = null;
	int i = 0;
	while ((i < this.Count) && (Machine == null)){
		if (plt.ToUpper().Equals(this[i].getPlt().ToUpper())  && dept.ToUpper().Equals(this[i].getDept().ToUpper()) && mach.ToUpper().Equals(this[i].getMach().ToUpper()))
			Machine = this[i];
		i++;
	}
	return Machine;
}

public
int getMaxMachCodeLen(){	
    int         imaxLen = 0;
	
    foreach(Machine machine in this) { 
        if (machine.Mach.Length > imaxLen)
            imaxLen=machine.Mach.Length;
	}
	return imaxLen;
}

public
void sortByMachine(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new HotListviewMachineComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((Machine)arrayToSort[i]);	
}

private
class HotListviewMachineComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is Machine) && (y is Machine)){
            Machine v1 = (Machine)x;
            Machine v2 = (Machine)y;

            string saux1 = v1.Mach + Constants.DEFAULT_SEP + v1.Plt + Constants.DEFAULT_SEP + v1.Dept;
            string saux2 = v2.Mach + Constants.DEFAULT_SEP + v2.Plt + Constants.DEFAULT_SEP + v2.Dept;
            return saux1.CompareTo(saux2);
        }else
            return -1;
    }
}

public
void sortByRemainsShifts(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new HotListviewRemainsShiftComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((Machine)arrayToSort[i]);	
}

private
class HotListviewRemainsShiftComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is MachineView) && (y is MachineView)){
            MachineView v1 = (MachineView)x;
            MachineView v2 = (MachineView)y;          
            if (DateUtil.sameDate(v1.PlanDate, v2.PlanDate))        //prioriry is minor date then by major remainsshift                
                return v2.RemainsShifts.CompareTo(v1.RemainsShifts);

            return v1.PlanDate.CompareTo(v2.PlanDate);
        }else
            return -1;
    }
}

public
void sortByPriority(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new PriorityComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((Machine)arrayToSort[i]);	
}

private
class PriorityComparer : IComparer{
    public int Compare(object x, object y){
        int imaxLen = int.MaxValue.ToString().Length;

        if ((x is Machine) && (y is Machine)){
            Machine v1 = (Machine)x;
            Machine v2 = (Machine)y;          
            
            int     ipriority1  = v1.PriorityShow == 0 ? int.MaxValue : v1.PriorityShow;//if priorities = 0 , will show at the end
            int     ipriority2  = v2.PriorityShow == 0 ? int.MaxValue : v2.PriorityShow;
            string  saux1       = StringUtil.AddChar(ipriority1.ToString(), '0', imaxLen, false) + Constants.DEFAULT_SEP + v1.Mach;
            string  saux2       = StringUtil.AddChar(ipriority2.ToString(), '0', imaxLen, false) + Constants.DEFAULT_SEP + v2.Mach;            
            return saux1.CompareTo(saux2);
        }else
            return -1;
    }
}

} // class
} // package