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


namespace Nujit.NujitERP.ClassLib.Core.Cms{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class ShipExportReleaseContainer : ObservableCollection<ShipExportRelease> { 
#else
class ShipExportReleaseContainer : Collection<ShipExportRelease> { 
#endif

internal
ShipExportReleaseContainer() : base(){
}

public
ShipExportRelease getByKey(string site, decimal bol, decimal bolItem, int detail){
	ShipExportRelease shipExportRelease = null;
	int i = 0;
	while ((i < this.Count) && (shipExportRelease == null)){
		if (site.Equals(this[i].Site) && bol.Equals(this[i].Bol) && bolItem.Equals(this[i].BolItem) && detail.Equals(this[i].Detail))
			shipExportRelease = this[i];
		i++;
	}
	return shipExportRelease;
}

public
ShipExportRelease getByDetail(int detail){
	ShipExportRelease shipExportRelease = null;
	int i = 0;
	while ((i < this.Count) && (shipExportRelease == null)){
		if (detail.Equals(this[i].Detail))
			shipExportRelease = this[i];
		i++;
	}
	return shipExportRelease;
}

public
ShipExportRelease getFirstByRelCum(decimal relCum){
	ShipExportRelease shipExportRelease = null;

    for (int i=0; i < this.Count && shipExportRelease == null; i++) { 
		if (this[i].RelCum == relCum)
            shipExportRelease = this[i];
                    
	}
	return shipExportRelease;
}


public
void fillDetails(){    	
    for (int i=0; i < this.Count; i++) {         
        ShipExportRelease shipExportRelease = this[i];       
        shipExportRelease.Detail    = i+1;        
	}  
}



public
void sortByTimeStamp(bool bnormalOrder){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new OrderItemTimeStampComparer());
    this.Clear();	

    if (bnormalOrder) { 
	    for(int i = 0;i < arrayToSort.Count;i++) //normal order
            this.Add((ShipExportRelease)arrayToSort[i]);	
    }else{
        for(int i = arrayToSort.Count-1; i >=0;i--)//decreased,newest on top
            this.Add((ShipExportRelease)arrayToSort[i]);	
    }
}

private
class OrderItemTimeStampComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is ShipExportRelease) && (y is ShipExportRelease)){
           ShipExportRelease v1 = (ShipExportRelease)x;
           ShipExportRelease v2 = (ShipExportRelease)y;            

           string saux1 = DateUtil.getCompleteDateRepresentation(v1.StDateCreated,DateUtil.YYYYMMDD) + Constants.DEFAULT_SEP + v1.Release;
           string saux2 = DateUtil.getCompleteDateRepresentation(v2.StDateCreated,DateUtil.YYYYMMDD) + Constants.DEFAULT_SEP + v2.Release;

            return saux1.CompareTo(saux2);
        }else
            return -1;
    }
}

} // class
} // package