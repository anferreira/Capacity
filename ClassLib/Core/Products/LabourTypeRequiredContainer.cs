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
class LabourTypeRequiredContainer : ObservableCollection<LabourTypeRequired> { 
#else
class RoutingLabToolContainer : Collection<RoutingLabTool> { 
#endif

internal
LabourTypeRequiredContainer() : base(){
}

public
LabourTypeRequired getByKey(int id){
	LabourTypeRequired labourTypeRequired = null;
	int i = 0;
	while ((i < this.Count) && (labourTypeRequired == null)){
		if (id.Equals(this[i].Id))
            labourTypeRequired = this[i];
		i++;
	}
	return labourTypeRequired;
}

} // class
} // package