/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: aferreira $ 
*   $Date: 2014-05-06 14:04:51 $ 
*   $Source: /usr/local/cvsroot/Projects/NujitWms2011/ClassLib/Core/Cms/Concord/TazmContainer.cs,v $ 
*   $State: Exp $ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.ObjectModel;
using Nujit.NujitERP.ClassLib.Util;
using System.Collections;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.Core.Cms{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class TazmContainer : ObservableCollection<Tazm> { 
#else
class TazmContainer : Collection<Tazm> { 
#endif

internal
TazmContainer() : base(){
}

public
Tazm getByKey(string zMEMPL){
	Tazm tazm = null;
	int i = 0;
	while ((i < this.Count) && (tazm == null)){
		if (zMEMPL.Equals(this[i].ZMEMPL))
			tazm = this[i];
		i++;
	}
	return tazm;
}

} // class
} // package