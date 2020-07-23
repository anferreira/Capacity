
using System;
using System.Collections.ObjectModel;

namespace Nujit.NujitERP.ClassLib.Core.Cms.EDI.CmsTransfer{

#if !POCKET_PC
    [System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class ShcrContainer : ObservableCollection<Shcr> { 
#else
class ShcrContainer : Collection<Shcr> { 
#endif

internal
ShcrContainer() : base(){
}

public
Shcr getAt(int index) {
    Shcr retObj = null;
    if (index < this.Count)
        retObj = this[index];
    return retObj;
}

public
void setAt(int index, Shcr value){    
    if (index < this.Count)
        this[index] = value;    
}

public
int getSize() {
    return this.Count;
}

public
Shcr getByKey(string rMCARC){
	Shcr shcr = null;
	int i = 0;
	while ((i < this.getSize()) && (shcr == null)){
		if (rMCARC.Equals(getAt(i).getRMCARC())){
			shcr = getAt(i);
			break;
		}
		i++;
	}
	return shcr;
}

} // class

} // package