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

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class EmpShiftScheduleReportViewContainer : ObservableCollection<EmpShiftScheduleReportView> { 
#else
class EmpShiftScheduleReportViewContainer : Collection<EmpShiftScheduleReportView> { 
#endif

internal
EmpShiftScheduleReportViewContainer() : base(){
}

public
EmpShiftScheduleReportView getByKey(int id, int detail){
	EmpShiftScheduleReportView empShiftScheduleReportView = null;
	int i = 0;
	while ((i < this.Count) && (empShiftScheduleReportView == null)){
		if (id.Equals(this[i].Id) && detail.Equals(this[i].Detail))
			empShiftScheduleReportView = this[i];
		i++;
	}
	return empShiftScheduleReportView;
}

public
void sortByMachPriority(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new CapacityMachPriorityComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((EmpShiftScheduleReportView)arrayToSort[i]);	
}

private
class CapacityMachPriorityComparer : IComparer{

    public int Compare(object x, object y){
        int imaxLen = int.MaxValue.ToString().Length;
        if ((x is EmpShiftScheduleReportView) && (y is EmpShiftScheduleReportView)){
            EmpShiftScheduleReportView v1 = (EmpShiftScheduleReportView)x;
            EmpShiftScheduleReportView v2 = (EmpShiftScheduleReportView)y;                                            
            return v1.Mach.CompareTo(v2.Mach);
        }else
            return -1;
    }
}

} // class
} // package