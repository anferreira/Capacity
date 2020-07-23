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
class ProductPlanDtContainer : ObservableCollection<ProductPlanDt> { 
#else
class ProductPlanDtContainer : Collection<ProductPlanDt> { 
#endif

internal
ProductPlanDtContainer() : base(){
}

public
ProductPlanDt getByKey(string famCfg, int famSeq, string prodID, int seq){
	ProductPlanDt productPlanDt = null;
	int i = 0;
	while ((i < this.Count) && (productPlanDt == null)){
		if (famCfg.Equals(this[i].FamCfg) && famSeq.Equals(this[i].FamSeq) && prodID.Equals(this[i].ProdID) && seq.Equals(this[i].Seq))
			productPlanDt = this[i];
		i++;
	}
	return productPlanDt;
}

} // class
} // package