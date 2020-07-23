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
class SeriContainer : ObservableCollection<Seri> { 
#else
class SeriContainer : Collection<Seri> { 
#endif

internal
SeriContainer() : base(){
}

public
Seri getByKey(decimal hTSERN){
	Seri seri = null;
	int i = 0;
	while ((i < this.Count) && (seri == null)){
		if (hTSERN.Equals(this[i].HTSERN))
			seri = this[i];
		i++;
	}
	return seri;
}

public
void getIfShorterValues(out bool bshortPart,out bool bshortSuppserial,out bool bshortLot){
	Seri    seri    = null;
    bshortPart = bshortSuppserial = bshortLot = true;
	int     i = 0;

    while ((i < this.Count)){
        seri = this[i];       
		
        //bshort = (seri.HTPART.Length <=10 && seri.HTLOTN.Length <=10 && seri.HTSUPS.Length <=10);            
        if (seri.HTPART.Length > 10)
            bshortPart = false;
        if (seri.HTSUPS.Length > 10)
            bshortSuppserial = false;
        if (seri.HTLOTN.Length > 10)
            bshortLot = false;
		i++;
	}    
}

} // class
} // package