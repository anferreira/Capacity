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

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class ProductPlanContainer : ObservableCollection<ProductPlan> { 
#else
class ProductPlanContainer : Collection<ProductPlan> { 
#endif

internal
ProductPlanContainer() : base(){
}

public
ProductPlan getByKey(int id){
	ProductPlan productPlan = null;
	int i = 0;
	while ((i < this.Count) && (productPlan == null)){
		if (id.Equals(this[i].ProdID))
			productPlan = this[i];
		i++;
	}
	return productPlan;
}

} // class
} // package