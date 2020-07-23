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

namespace Nujit.NujitERP.ClassLib.Core.Cms.PackSlips{

#if !POCKET_PC
    [System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class BolmContainer : ObservableCollection<Bolm> { 
#else
class BolmContainer : Collection<Bolm> { 
#endif

internal
BolmContainer() : base(){
}

public
Bolm getByKey(decimal rAMBOL){
	Bolm bolm = null;
	int i = 0;
	while ((i < this.Count) && (bolm == null)){
		if (rAMBOL.Equals(this[i].RAMBOL))
			bolm = this[i];
		i++;
	}
	return bolm;
}

} // class
} // package