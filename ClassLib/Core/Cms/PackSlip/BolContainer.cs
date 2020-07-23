using System;
using System.Collections.ObjectModel;
using Nujit.NujitERP.ClassLib.Util;
using System.Collections;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core.Cms.PackSlips{

#if !POCKET_PC
    [System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class BolContainer : ObservableCollection<Bol> { 
#else
class BolContainer : Collection<Bol> { 
#endif

internal
BolContainer() : base(){
}

public
Bol getAt(int index) {
    Bol retObj = null;
    if (index < this.Count)
        retObj = this[index];
    return retObj;
}

public
void setAt(int index, Bol value){    
    if (index < this.Count)
        this[index] = value;    
}

public
int getSize() {
    return this.Count;
}

public
Bol getByKey(int fEBOL){
	Bol bol = null;
	int i = 0;
	while ((i < this.getSize()) && (bol == null)){
		if (fEBOL == (int)getAt(i).getFEBOL()){
			bol = getAt(i);
			break;
		}
		i++;
	}
	return bol;
}

public
void sortBySeqLoad(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new SeqLoadComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
		this.Add((Bol)arrayToSort[i]);
	
}

#region SerialsComparer Class
private
class SeqLoadComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is Bol) && (y is Bol)){
            Bol s1 = (Bol)x;
            Bol s2 = (Bol)y;

            return s1.FEFUTP.CompareTo(s2.FEFUTP);                
        }else
            return -1;
    }
}
#endregion SerialsComparer Class

} // class

} // package