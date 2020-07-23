/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.ObjectModel;

namespace Nujit.NujitERP.ClassLib.Core.Sales.PackSlips{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class PackSlipDtlContainer : ObservableCollection<PackSlipDtl> { 
#else
class PackSlipDtlContainer : Collection<PackSlipDtl> { 
#endif

internal
PackSlipDtlContainer() : base(){
}

public
PackSlipDtl getByKey(int hdrId, int detail){
	PackSlipDtl packSlipDtl = null;
	int i = 0;
	while ((i < this.Count) && (packSlipDtl == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail))
			packSlipDtl = this[i];
		i++;
	}
	return packSlipDtl;
}

public
decimal getSumByShipQty(string spart){
	PackSlipDtl packSlipDtl = null;
    decimal     dshipQty=0;

	for (int i=0; i < this.Count;i++){
        packSlipDtl = this[i];
        if (packSlipDtl.Part.ToUpper().Equals(spart.ToUpper()))
            dshipQty+= packSlipDtl.ShipQty;

    }
	return dshipQty;
}

} // class
} // package