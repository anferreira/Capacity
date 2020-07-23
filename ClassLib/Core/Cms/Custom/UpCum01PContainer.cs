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


namespace Nujit.NujitERP.ClassLib.Core.Cms{


#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class UpCum01PContainer : ObservableCollection<UpCum01P> { 
#else
class UpCum01PContainer : Collection<UpCum01P> { 
#endif

internal
UpCum01PContainer() : base(){
}

public
UpCum01P getByKey(decimal fGBOL, decimal fGENT){
	UpCum01P upCum01P = null;
	int i = 0;
	while ((i < this.Count) && (upCum01P == null)){
		if (fGBOL.Equals(this[i].FGBOL) && fGENT.Equals(this[i].FGENT))
			upCum01P = this[i];
		i++;
	}
	return upCum01P;
}

} // class
} // package