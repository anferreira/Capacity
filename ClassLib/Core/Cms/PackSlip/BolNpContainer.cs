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
class BolNpContainer : ObservableCollection<BolNp> { 
#else
class BolNpContainer : Collection<BolNp> { 
#endif

internal
BolNpContainer() : base(){
}

public
BolNp getAt(int index) {
    BolNp retObj = null;
    if (index < this.Count)
        retObj = this[index];
    return retObj;
}

public
void setAt(int index, BolNp value){    
    if (index < this.Count)
        this[index] = value;    
}

public
int getSize() {
    return this.Count;
}

public
BolNp getByKey(string gGKEY, decimal gGPAG, decimal gGLIN){
	BolNp bolNp = null;
	int i = 0;
	while ((i < this.getSize()) && (bolNp == null)){
		if (gGKEY.Equals(getAt(i).getGGKEY()) && gGPAG.Equals(getAt(i).getGGPAG()) && gGLIN.Equals(getAt(i).getGGLIN())){
			bolNp = getAt(i);
			break;
		}
		i++;
	}
	return bolNp;
}

} // class

} // package