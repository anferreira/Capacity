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

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class CapShiftProfileDtlContainer : ObservableCollection<CapShiftProfileDtl> { 
#else
class CapShiftProfileDtlContainer : Collection<CapShiftProfileDtl> { 
#endif

internal
CapShiftProfileDtlContainer() : base(){
}

public
CapShiftProfileDtl getByKey(int hdrId, int detail){
	CapShiftProfileDtl capShiftProfileDtl = null;
	int i = 0;
	while ((i < this.Count) && (capShiftProfileDtl == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail))
			capShiftProfileDtl = this[i];
		i++;
	}
	return capShiftProfileDtl;
}

public
CapShiftProfileDtl getByShiftTaskId(int ishiftTaskId){
	CapShiftProfileDtl capShiftProfileDtl = null;
	
	for (int i=0; i < this.Count && capShiftProfileDtl == null;i++){
		if (ishiftTaskId.Equals(this[i].ShiftTaskId))
			capShiftProfileDtl = this[i];		
	}
	return capShiftProfileDtl;
}

public
void sortByTaskName(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new CapShiftProfileDtlTaskNameComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((CapShiftProfileDtl)arrayToSort[i]);	
}

private
class CapShiftProfileDtlTaskNameComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is CapShiftProfileDtl) && (y is CapShiftProfileDtl)){
            CapShiftProfileDtl v1 = (CapShiftProfileDtl)x;
            CapShiftProfileDtl v2 = (CapShiftProfileDtl)y;            
            return v1.TaskNameShow.CompareTo(v2.TaskNameShow);
        }else
            return -1;
    }
}

} // class
} // package