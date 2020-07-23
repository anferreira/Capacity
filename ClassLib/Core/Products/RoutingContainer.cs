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
class RoutingContainer : ObservableCollection<Routing> { 
#else
class RoutingContainer : Collection<Routing> { 
#endif

internal
RoutingContainer() : base(){
}

public
Routing getByKey(string prodID, string plt, string dept, string actID, int seq, string cfg){
	Routing routing = null;
	int i = 0;
	while ((i < this.Count) && (routing == null)){
		if (prodID.ToUpper().Equals(this[i].ProdID.ToUpper()) && plt.ToUpper().Equals(this[i].Plt) && 
            dept.ToUpper().Equals(this[i].Dept.ToUpper()) && actID.ToUpper().Equals(this[i].ActID.ToUpper()) && 
            seq.Equals(this[i].Seq) && cfg.ToUpper().Equals(this[i].Cfg.ToUpper()))
			routing = this[i];
		i++;
	}
	return routing;
}

public
Routing getByFirst(string prodID,int seq,string cfg){
	Routing routing = null;
	int i = 0;
	while ((i < this.Count) && (routing == null)){
		if (prodID.ToUpper().Equals(this[i].ProdID.ToUpper()) && seq.Equals(this[i].Seq) && cfg.ToUpper().Equals(this[i].Cfg.ToUpper()))
			routing = this[i];
		i++;
	}
	return routing;
}

public
Routing getByFirst(string prodID,int seq){
	Routing routing = null;
	int i = 0;
	while ((i < this.Count) && (routing == null)){
		if (prodID.ToUpper().Equals(this[i].ProdID.ToUpper()) && seq.Equals(this[i].Seq))
			routing = this[i];
		i++;
	}
	return routing;
}

} // class
} // package