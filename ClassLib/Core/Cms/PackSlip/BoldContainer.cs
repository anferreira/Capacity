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
class BoldContainer : ObservableCollection<Bold> { 
#else
class BoldContainer : Collection<Bold> { 
#endif

internal
BoldContainer() : base(){
}

public
Bold getAt(int index) {
    Bold retObj = null;
    if (index < this.Count)
        retObj = this[index];
    return retObj;
}

public
void setAt(int index, Bold value){    
    if (index < this.Count)
        this[index] = value;    
}

public
int getSize() {
    return this.Count;
}

public
Bold getByInvoiceDtl(int fGINV, int fGLIN){
	Bold bold = null;
	int i = 0;
	while ((i < this.getSize()) && (bold == null)){
		if (fGINV == getAt(i).getFGINV() && fGLIN == getAt(i).getFGLIN()){
			bold = getAt(i);
			break;
		}
		i++;
	}
	return bold;
}

} // class

} // package