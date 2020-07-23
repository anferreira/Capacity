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

namespace Nujit.NujitERP.ClassLib.Core.Customer{


#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class CustLeadContainer : ObservableCollection<CustLead> { 
#else
class CustLeadContainer : Collection<CustLead> { 
#endif

internal
CustLeadContainer() : base(){
}

public
CustLead getByKey(string custId, string smajSalesCode, string minGroup){
	CustLead custLead = null;
	int i = 0;
	while ((i < this.Count) && (custLead == null)){
		if (custId.ToUpper().Equals(this[i].CustId.ToUpper()) && smajSalesCode.ToUpper().Equals(this[i].MajSalesCode.ToUpper()) && 
                                                                 minGroup.ToUpper().Equals(this[i].MinSalesCode.ToUpper()))
			custLead = this[i];
		i++;
	}
	return custLead;
}

} // class
} // package