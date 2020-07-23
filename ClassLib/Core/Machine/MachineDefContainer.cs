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
using System.Collections;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core.Machines{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class MachineDefContainer : ObservableCollection<MachineDef> { 
#else
class MachineDefContainer : Collection<MachineDef> { 
#endif

internal
MachineDefContainer() : base(){
}

public
MachineDef getByKey(int machId){
	MachineDef machineDef = null;
	int i = 0;
	while ((i < this.Count) && (machineDef == null)){
		if (machId.Equals(this[i].MachId))
			machineDef = this[i];
		i++;
	}
	return machineDef;
}

} // class
} // package