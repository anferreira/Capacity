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
class RrldmContainer : ObservableCollection<Rrldm> { 
#else
class RrldmContainer : Collection<Rrldm> { 
#endif

internal
RrldmContainer() : base(){
}

public
Rrldm getByKey(decimal bJ0KEYN, string bJ0REL, DateTime bJ0CHDT, decimal bJ0CHTM, DateTime bJ0DTTM){
	Rrldm rrldm = null;
	int i = 0;
	while ((i < this.Count) && (rrldm == null)){
		if (bJ0KEYN.Equals(this[i].BJ0KEYN) && bJ0REL.Equals(this[i].BJ0REL) && bJ0CHDT.Equals(this[i].BJ0CHDT) && bJ0CHTM.Equals(this[i].BJ0CHTM) && bJ0DTTM.Equals(this[i].BJ0DTTM))
			rrldm = this[i];
		i++;
	}
	return rrldm;
}


public
void sortByTimeStamp(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new TimeStampComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((Rrldm)arrayToSort[i]);	
}

private
class TimeStampComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is Rrldm) && (y is Rrldm)){
            Rrldm v1 = (Rrldm)x;
            Rrldm v2 = (Rrldm)y;            
            return v1.BJ0DTTM.CompareTo(v2.BJ0DTTM);
        }else
            return -1;
    }
}

} // class
} // package