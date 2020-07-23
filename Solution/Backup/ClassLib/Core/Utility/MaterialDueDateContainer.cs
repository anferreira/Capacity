using System;

using System.Collections;

namespace Nujit.NujitERP.ClassLib.Core.Utility{

public 
class MaterialDueDateContainer : CumulativeInventoryContainer{

public 
MaterialDueDateContainer() : base(){
}

public 
MaterialDueDate getMaterialDueDate(string product,
			int seq){

	for(IEnumerator en = this.GetEnumerator(); en.MoveNext(); ){
		MaterialDueDate materialDueDate = (MaterialDueDate)en.Current;

		if ((materialDueDate.getProduct().Equals(product)) &&
				(materialDueDate.getSeq() == seq)){

			return materialDueDate;
		}
	}
	return null;
}

} // class

} // namespace
