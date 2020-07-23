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

namespace Nujit.NujitERP.ClassLib.Core.Customer{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class TradingPartnerContainer : ObservableCollection<TradingPartner> { 
#else
class TradingPartnerContainer : Collection<TradingPartner> { 
#endif

internal
TradingPartnerContainer() : base(){
}

public
TradingPartner getByKey(string tPartner){
	TradingPartner tradingPartner = null;
	int i = 0;
	while ((i < this.Count) && (tradingPartner == null)){
		if (tPartner.Equals(this[i].TPartner))
			tradingPartner = this[i];
		i++;
	}
	return tradingPartner;
}

} // class
} // package