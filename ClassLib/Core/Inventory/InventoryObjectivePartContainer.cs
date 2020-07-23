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
class InventoryObjectivePartContainer : ObservableCollection<InventoryObjectivePart> { 
#else
class InventoryObjectivePartContainer : Collection<InventoryObjectivePart> { 
#endif

internal
InventoryObjectivePartContainer() : base(){
}

public
InventoryObjectivePart getByKey(int hdrId, int detail){
	InventoryObjectivePart inventoryObjectivePart = null;
	int i = 0;
	while ((i < this.Count) && (inventoryObjectivePart == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail))
			inventoryObjectivePart = this[i];
		i++;
	}
	return inventoryObjectivePart;
}

public
InventoryObjectivePart getByPartSeq(string spart,int iseq){
	InventoryObjectivePart inventoryObjectivePart = null;
	
    for (int i=0; i < this.Count && inventoryObjectivePart == null;i++){
		if (spart.ToUpper().Equals(this[i].Part.ToUpper()) && iseq.Equals(this[i].Seq))
			inventoryObjectivePart = this[i];	
	}
	return inventoryObjectivePart;
}

public
void sortByPart(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new PartComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((InventoryObjectivePart)arrayToSort[i]);	
}

private
class PartComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is InventoryObjectivePart) && (y is InventoryObjectivePart)){
            InventoryObjectivePart v1 = (InventoryObjectivePart)x;
            InventoryObjectivePart v2 = (InventoryObjectivePart)y;            
            return v1.Part.CompareTo(v2.Part);
        }else
            return -1;
    }
}

} // class
} // package