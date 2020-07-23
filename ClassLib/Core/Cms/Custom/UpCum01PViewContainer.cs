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
class UpCum01PViewContainer : ObservableCollection<UpCum01PView> { 
#else
class UpCum01PViewContainer : Collection<UpCum01PView> { 
#endif

internal
UpCum01PViewContainer() : base(){
}

public
UpCum01PView getByKey(decimal fGBOL, decimal fGENT){
	UpCum01PView upCum01PView = null;
	int i = 0;
	while ((i < this.Count) && (upCum01PView == null)){
		if (fGBOL.Equals(this[i].FGBOL) && fGENT.Equals(this[i].FGENT))
			upCum01PView = this[i];
		i++;
	}
	return upCum01PView;
}

public
UpCum01PView getByRelease(string sfGRLNO){
	UpCum01PView upCum01PView = null;
	int i = 0;
	while ((i < this.Count) && (upCum01PView == null)){
		if (sfGRLNO.ToUpper().Equals(this[i].FGRLNO.ToUpper()))
			upCum01PView = this[i];
		i++;
	}
	return upCum01PView;
}

public
UpCum01PView getByBolItemRelease(decimal fGBOL,decimal fGENT,string sfGRLNO){
	UpCum01PView upCum01PView = null;
	int i = 0;
	while ((i < this.Count) && (upCum01PView == null)){
		if (upCum01PView.FGBOL == fGBOL  && upCum01PView.FGENT == fGENT &&
            sfGRLNO.ToUpper().Equals(this[i].FGRLNO.ToUpper()))
			upCum01PView = this[i];
		i++;
	}
	return upCum01PView;
}

} // class
} // package