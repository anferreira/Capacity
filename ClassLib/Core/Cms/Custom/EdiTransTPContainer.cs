/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Util;
using System.Collections.ObjectModel;

namespace Nujit.NujitERP.ClassLib.Core.Cms{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class EdiTransTPContainer : ObservableCollection<EdiTransTP> { 
#else
class EdiTransTPContainer : Collection<EdiTransTP> { 
#endif

internal
EdiTransTPContainer() : base(){
}

public
EdiTransTP getByKey(string splant,string stPartner, int detail){
	EdiTransTP ediTransTP = null;
	int i = 0;
	while ((i < this.Count) && (ediTransTP == null)){
		if (splant.ToUpper().Equals(this[i].Plant.ToUpper()) &&
            stPartner.ToUpper().Equals(this[i].TPartner.ToUpper()) && detail.Equals(this[i].Detail))
			ediTransTP = this[i];
		i++;
	}
	return ediTransTP;
}

public
EdiTransTP getByPlantTPartner(string splant,string stPartner){
	EdiTransTP ediTransTP = null;
	int i = 0;
	while ((i < this.Count) && (ediTransTP == null)){
		if (splant.ToUpper().Equals(this[i].Plant.ToUpper()) && stPartner.ToUpper().Equals(this[i].TPartner.ToUpper()))
			ediTransTP = this[i];
		i++;
	}
	return ediTransTP;
}

} // class
} // package