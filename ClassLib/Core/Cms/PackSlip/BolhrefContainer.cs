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
class BolhrefContainer : ObservableCollection<Bolhref> { 
#else
class BolhrefContainer : Collection<Bolhref> { 
#endif

internal
BolhrefContainer() : base(){
}

public
Bolhref getAt(int index) {
    Bolhref retObj = null;
    if (index < this.Count)
        retObj = this[index];
    return retObj;
}

public
void setAt(int index, Bolhref value){    
    if (index < this.Count)
        this[index] = value;    
}

public
int getSize() {
    return this.Count;
}

public
Bolhref getByKey(decimal x1BOLH){
	Bolhref bolhref = null;
	int i = 0;
	while ((i < this.getSize()) && (bolhref == null)){
		if (x1BOLH.Equals(getAt(i).getX1BOLH())){
			bolhref = getAt(i);
			break;
		}
		i++;
	}
	return bolhref;
}

} // class

} // package