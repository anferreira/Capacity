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

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class InventoryObjectivePartDtlContainer : ObservableCollection<InventoryObjectivePartDtl> { 
#else
class InventoryObjectivePartDtlContainer : Collection<InventoryObjectivePartDtl> { 
#endif

internal
InventoryObjectivePartDtlContainer() : base(){
}

public
InventoryObjectivePartDtl getByKey(int hdrId, int detail, int subDtl){
	InventoryObjectivePartDtl inventoryObjectivePartDtl = null;
	int i = 0;
	while ((i < this.Count) && (inventoryObjectivePartDtl == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail) && subDtl.Equals(this[i].SubDtl))
			inventoryObjectivePartDtl = this[i];
		i++;
	}
	return inventoryObjectivePartDtl;
}


public
InventoryObjectivePartDtl getBySubDtl(int subDtl){
	InventoryObjectivePartDtl inventoryObjectivePartDtl = null;
	int i = 0;
	while ((i < this.Count) && (inventoryObjectivePartDtl == null)){
		if (subDtl.Equals(this[i].SubDtl))
			inventoryObjectivePartDtl = this[i];
		i++;
	}
	return inventoryObjectivePartDtl;
}

public
InventoryObjectivePartDtl getByDate(DateTime dateObjective){
	InventoryObjectivePartDtl inventoryObjectivePartDtl = null;
	int i = 0;
	while ((i < this.Count) && (inventoryObjectivePartDtl == null)){
		if (DateUtil.sameDate(dateObjective,this[i].DateObjective))
			inventoryObjectivePartDtl = this[i];
		i++;
	}
	return inventoryObjectivePartDtl;
}

public
decimal getQtyByRangeDate(DateTime startDate,DateTime endDate){	
    decimal                     dtotQty= 0;
    InventoryObjectivePartDtl   inventoryObjectivePartDtl=null;
                        	    
    for (int i=0; i < this.Count; i++){
        inventoryObjectivePartDtl = this[i];
        if (startDate <= inventoryObjectivePartDtl.DateObjective && inventoryObjectivePartDtl.DateObjective <= endDate)
            dtotQty+= inventoryObjectivePartDtl.Qty;
    }    	
	return dtotQty;
}

public
InventoryObjectivePartDtl getByRangeDate(DateTime startDate,DateTime endDate){	    
    InventoryObjectivePartDtl   inventoryObjectivePartDtl=null;
                        	    
    for (int i=0; i < this.Count && inventoryObjectivePartDtl== null; i++){        
        if (this[i].DateObjective >= startDate && this[i].DateObjective <= endDate)
            inventoryObjectivePartDtl = this[i];
    }    	
	return inventoryObjectivePartDtl;
}

public
void sortByDate(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new PartDtlDateComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((InventoryObjectivePartDtl)arrayToSort[i]);	
}

private
class PartDtlDateComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is InventoryObjectivePartDtl) && (y is InventoryObjectivePartDtl)){
            InventoryObjectivePartDtl v1 = (InventoryObjectivePartDtl)x;
            InventoryObjectivePartDtl v2 = (InventoryObjectivePartDtl)y;            
            return v1.DateObjective.CompareTo(v2.DateObjective);
        }else
            return -1;
    }
}

} // class
} // package