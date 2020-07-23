/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.ObjectModel;
using Nujit.NujitERP.ClassLib.Util;

namespace Nujit.NujitERP.ClassLib.Core.Sales.PackSlips{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class PackSlipContainer : ObservableCollection<PackSlip> { 
#else
class PackSlipContainer : Collection<PackSlip> { 
#endif

internal
PackSlipContainer() : base(){
}

public
PackSlip getByKey(int id){
	PackSlip packSlip = null;
	int i = 0;
	while ((i < this.Count) && (packSlip == null)){
		if (id.Equals(this[i].Id))
			packSlip = this[i];
		i++;
	}
	return packSlip;
}

public
Hashtable getHashByPostDate(){
    Hashtable               hashtable = new Hashtable();
    PackSlip                packSlip = null;
    PackSlipDtlContainer    packSlipDtlContainer = null;
    string                  skey="";
	
    for (int i=0; i < this.Count;i++){
        packSlip = this[i];
        skey = DateUtil.getDateRepresentation(packSlip.DatePosted,DateUtil.MMDDYYYY);
		if (hashtable.Contains(skey)){ 
            packSlipDtlContainer = (PackSlipDtlContainer)hashtable[skey];
        }else{
			packSlipDtlContainer = new PackSlipDtlContainer();
            hashtable.Add(skey,packSlipDtlContainer);
		}

        foreach(PackSlipDtl packSlipDtl in packSlip.PackSlipDtlContainer)
            packSlipDtlContainer.Add(packSlipDtl);
	}
	return hashtable;
}

} // class
} // package