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

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class CapacityMachPriorityContainer : ObservableCollection<CapacityMachPriority> { 
#else
class CapacityMachPriorityContainer : Collection<CapacityMachPriority> { 
#endif

internal
CapacityMachPriorityContainer() : base(){
}

public
CapacityMachPriority getByKey(int hdrId, int detail){
	CapacityMachPriority capacityMachPriority = null;
	int i = 0;
	while ((i < this.Count) && (capacityMachPriority == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail))
			capacityMachPriority = this[i];
		i++;
	}
	return capacityMachPriority;
}

public
CapacityMachPriority getByMachine(int imachineId){
	CapacityMachPriority capacityMachPriority = null;
	int i = 0;
	while ((i < this.Count) && (capacityMachPriority == null)){
		if (imachineId.Equals(this[i].MachineId))
			capacityMachPriority = this[i];
		i++;
	}
	return capacityMachPriority;
}

public
void adjustPriorities(CapacityMachPriority capacityMachPriority){	
    int     icurrentPriority=0;
    bool    bneedPriorityUpdate=false;

    for (int i=0; i < this.Count;i++, icurrentPriority++){
        CapacityMachPriority capacityMachPriorityCurrent = this[i];

        if (bneedPriorityUpdate) { 
            if (capacityMachPriorityCurrent.Equals(capacityMachPriority) ) //chech if same CapacityMachPriority as parameter, so we do not change priority
                icurrentPriority--;
            else
                capacityMachPriorityCurrent.Priority = icurrentPriority;
        }else{
            icurrentPriority = capacityMachPriorityCurrent.Priority;

            if (!capacityMachPriorityCurrent.Equals(capacityMachPriority) && capacityMachPriorityCurrent.Priority == capacityMachPriority.Priority) {
                icurrentPriority = capacityMachPriorityCurrent.Priority= capacityMachPriority.Priority+1;            
                bneedPriorityUpdate=true;
            }
        }	
    }	
}

public
CapacityMachPriorityContainer getByFilters(string smachine){
    CapacityMachPriorityContainer capacityPartContainerReturn = new CapacityMachPriorityContainer();
		
	for (int i=0; i < this.Count; i++){
        CapacityMachPriority capacityMachPriority = this[i];

		if ( (string.IsNullOrEmpty(smachine)  || (StringUtil.ifMatch(capacityMachPriority.MachineShow.ToUpper(), smachine.ToUpper()))))             
            capacityPartContainerReturn.Add(capacityMachPriority);        
	}	
    return capacityPartContainerReturn;
}

public
void sortByPriority(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new CapacityMachPriorityComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((CapacityMachPriority)arrayToSort[i]);	
}

private
class CapacityMachPriorityComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is CapacityMachPriority) && (y is CapacityMachPriority)){
            CapacityMachPriority v1 = (CapacityMachPriority)x;
            CapacityMachPriority v2 = (CapacityMachPriority)y;            
            return v1.Priority.CompareTo(v2.Priority);
        }else
            return -1;
    }
}
} // class
} // package