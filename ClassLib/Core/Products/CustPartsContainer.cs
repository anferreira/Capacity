/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.ObjectModel;

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class CustPartsContainer : ObservableCollection<CustParts> { 
#else
class CustPartsContainer : Collection<CustParts> { 
#endif

internal
CustPartsContainer() : base(){
}

public
CustParts getByKey(string prodID, string billToCust, string shipToCust){
	CustParts custPart = null;
	int i = 0;
	while ((i < this.Count) && (custPart == null)){
		if (prodID.Equals(this[i].ProdID) && billToCust.Equals(this[i].BillToCust) && shipToCust.Equals(this[i].ShipToCust))
			custPart = this[i];
		i++;
	}
	return custPart;
}

public
CustParts getByKeyOneOfCustomer(string prodID, string billToCust, string shipToCust){
	CustParts custPart = null;
	int i = 0;
	while ((i < this.Count) && (custPart == null)){
		if (prodID.ToUpper().Equals(this[i].ProdID.ToUpper()) &&  (billToCust.ToUpper().Equals(this[i].BillToCust.ToUpper()) || shipToCust.ToUpper().Equals(this[i].ShipToCust.ToUpper())))
			custPart = this[i];
		i++;
	}
	return custPart;
}

} // class
} // package