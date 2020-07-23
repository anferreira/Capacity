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
class BollContainer : ObservableCollection<Boll> { 
#else
class BollContainer : Collection<Boll> { 
#endif

internal
BollContainer() : base(){
}

public
Boll getAt(int index) {
    Boll retObj = null;
    if (index < this.Count)
        retObj = this[index];
    return retObj;
}

public
void setAt(int index, Boll value){    
    if (index < this.Count)
        this[index] = value;    
}

public
int getSize() {
    return this.Count;
}

public
Boll getByKey(int qUBOL, int qUENT, int qUSEQ){
	Boll boll = null;
	int i = 0;
	while ((i < this.getSize()) && (boll == null)){
		if (qUBOL.Equals(getAt(i).getQUBOL()) && qUENT.Equals(getAt(i).getQUENT()) && qUSEQ.Equals(getAt(i).getQUSEQ())){
			boll = getAt(i);
			break;
		}
		i++;
	}
	return boll;
}

} // class

} // package