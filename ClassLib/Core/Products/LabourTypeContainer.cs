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
class LabourTypeContainer : ObservableCollection<LabourType> { 
#else
class LabourTypeContainer : Collection<LabourType> { 
#endif

internal
LabourTypeContainer() : base(){
}

public
LabourType getByKey(int id){
	LabourType labourType = null;
	int i = 0;
	while ((i < this.Count) && (labourType == null)){
		if (id.Equals(this[i].Id))
			labourType = this[i];
		i++;
	}
	return labourType;
}

} // class
} // package