/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.ObjectModel;
using System.Collections;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core.Cms{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class DemTransformDContainer : ObservableCollection<DemTransformD> { 
#else
class DemTransformDContainer : Collection<DemTransformD> { 
#endif

internal
DemTransformDContainer() : base(){
}

public
DemTransformD getByKey(int hdrId, int detail){
	DemTransformD demTransformD = null;
	int i = 0;
	while ((i < this.Count) && (demTransformD == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail))
			demTransformD = this[i];
		i++;
	}
	return demTransformD;
}

public
void linkToDemandD(DemandDContainer demandDContainer){
	DemTransformD demTransformD = null;
	
	for (int i=0; i < this.Count;i++){  
        demTransformD = this[i];
        DemandD demandD = demandDContainer.getByKey(demTransformD.DemandHdr, demTransformD.DemandDetail);
        demTransformD.DemandD = demandD;        
	}	
}

public
Hashtable getHashByPart(){    
    Hashtable               hashParts = new Hashtable();
    string                  skey="";
    DemTransformDContainer  demTransformDContainer=null;

    for (int i=0; i < this.Count; i++){
        DemTransformD demTransformD = this[i];

        if (demTransformD.DemandD != null){ 
            skey = demTransformD.DemandD.Part;

            if (hashParts.ContainsKey(skey)){
                demTransformDContainer = (DemTransformDContainer)hashParts[skey];
                demTransformDContainer.Add(demTransformD);                       
            }else{ 
                demTransformDContainer = new DemTransformDContainer();
                demTransformDContainer.Add(demTransformD);
                hashParts.Add(skey,demTransformDContainer);            
            }
        }
	}	
    return hashParts;
}


public
void sortByDemDatePart(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new DemDatePartComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((DemTransformD)arrayToSort[i]);
	
}

#region DemDatePartComparer Class
private
class DemDatePartComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is DemTransformD) && (y is DemTransformD)){
            DemTransformD d1 = (DemTransformD)x;
            DemTransformD d2 = (DemTransformD)y;

            string saux1 = DateUtil.getDateRepresentation(d1.DemDate,DateUtil.YYYYMMDD) + Constants.DEFAULT_SEP + (d1.DemandD!=null? d1.DemandD.Part : "");
            string saux2 = DateUtil.getDateRepresentation(d2.DemDate,DateUtil.YYYYMMDD) + Constants.DEFAULT_SEP + (d2.DemandD!=null? d2.DemandD.Part : "");
            
            return saux1.CompareTo(saux2);
        }else
            return -1;
    }
}
#endregion DemDatePartComparer Class

} // class
} // package