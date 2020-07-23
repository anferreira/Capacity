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
class JitdmContainer : ObservableCollection<Jitdm> { 
#else
class JitdmContainer : Collection<Jitdm> { 
#endif

internal
JitdmContainer() : base(){
}

public
Jitdm getByKey(decimal bJ1KEYN, string bJ1REF, DateTime bJ1CHDT, decimal bJ1CHTM, DateTime bJ1DTTM){
	Jitdm jitdm = null;
	int i = 0;
	while ((i < this.Count) && (jitdm == null)){
		if (bJ1KEYN.Equals(this[i].BJ1KEYN) && bJ1REF.Equals(this[i].BJ1REF) && bJ1CHDT.Equals(this[i].BJ1CHDT) && bJ1CHTM.Equals(this[i].BJ1CHTM) && bJ1DTTM.Equals(this[i].BJ1DTTM))
			jitdm = this[i];
		i++;
	}
	return jitdm;
}

public
void sortByTimeStamp(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new TimeStampComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((Jitdm)arrayToSort[i]);	
}

private
class TimeStampComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is Jitdm) && (y is Jitdm)){
            Jitdm v1 = (Jitdm)x;
            Jitdm v2 = (Jitdm)y;            
            return v1.BJ1DTTM.CompareTo(v2.BJ1DTTM);
        }else
            return -1;
    }
}

} // class
} // package