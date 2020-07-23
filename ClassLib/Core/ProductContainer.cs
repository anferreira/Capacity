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
class ProductContainer : ObservableCollection<Product> { 
#else
class ProductContainer : Collection<Product> { 
#endif

internal
ProductContainer() : base(){
}

public
Product getByKey(int id){
	Product product = null;
	int i = 0;
	while ((i < this.Count) && (product == null)){
		if (id.Equals(this[i].Id))
			product = this[i];
		i++;
	}
	return product;
}
        
public
Product getByCode(string spart){
	Product product = null;
	int     i = 0;
	while ((i < this.Count) && (product == null)){
		if (spart.ToUpper().Equals(this[i].ProdID.ToUpper()))
			product = this[i];
		i++;
	}
	return product;
}

} // class
} // package