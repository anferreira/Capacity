/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: aferreira $ 
*   $Date: 2012-10-30 15:17:29 $ 
*   $Source: /usr/local/cvsroot/Projects/NujitWms2011/ClassLib/Core/EDI/CmsTransfer/CustomerEdiContainer.cs,v $ 
*   $State: Exp $ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.ObjectModel;

namespace Nujit.NujitERP.ClassLib.Core.Cms.EDI.CmsTransfer{


#if !POCKET_PC
    [System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class CustomerEdiContainer : ObservableCollection<CustomerEdi> { 
#else
class CustomerEdiContainer : Collection<CustomerEdi> { 
#endif

internal
CustomerEdiContainer() : base(){
}

public
CustomerEdi getAt(int index) {
    CustomerEdi retObj = null;
    if (index < this.Count)
        retObj = this[index];
    return retObj;
}

public
void setAt(int index, CustomerEdi value){    
    if (index < this.Count)
        this[index] = value;    
}

public
int getSize() {
    return this.Count;
}

public
CustomerEdi getByKey(string bVCUST){
	CustomerEdi customer = null;
	int i = 0;
	while ((i < this.getSize()) && (customer == null)){
		if (bVCUST.Equals(getAt(i).getBVCUST())){
			customer = getAt(i);
			break;
		}
		i++;
	}
	return customer;
}

} // class

} // package