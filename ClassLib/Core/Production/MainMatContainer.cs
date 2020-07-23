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
class MainMatContainer : ObservableCollection<MainMat> { 
#else
class MainMatContainer : Collection<MainMat> { 
#endif

internal
MainMatContainer() : base(){
}

public
MainMat getByKey(string pART, int dTL){
	MainMat mainMat = null;
	int i = 0;
	while ((i < this.Count) && (mainMat == null)){
		if (pART.Equals(this[i].PART) && dTL.Equals(this[i].DTL))
			mainMat = this[i];
		i++;
	}
	return mainMat;
}

public
MainMat getByMainMaterial(string smainPart){
	MainMat mainMat = null;
	int i = 0;
	while ((i < this.Count) && (mainMat == null)){
		if (smainPart.Equals(this[i].MAINPART))
			mainMat = this[i];
		i++;
	}
	return mainMat;
}

} // class
} // package