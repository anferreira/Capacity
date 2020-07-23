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
class RoutingLabToolContainer : ObservableCollection<RoutingLabTool> { 
#else
class RoutingLabToolContainer : Collection<RoutingLabTool> { 
#endif

internal
RoutingLabToolContainer() : base(){
}

public
RoutingLabTool getByKey(int hdrId, int detail){
	RoutingLabTool routingLabTool = null;
	int i = 0;
	while ((i < this.Count) && (routingLabTool == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail))
			routingLabTool = this[i];
		i++;
	}
	return routingLabTool;
}

public
RoutingLabTool getByTypeReqId(string stype,int ireqId){
	RoutingLabTool routingLabTool = null;
	int i = 0;
	while ((i < this.Count) && (routingLabTool == null)){
		if (stype.Equals(this[i].Type) && ireqId.Equals(this[i].ReqId))
			routingLabTool = this[i];
		i++;
	}
	return routingLabTool;
}

public
int getTotalByType(string stype){	
	int     i = 0;
    int     icounter=0;        
	while (i < this.Count){
		if (stype.Equals(this[i].Type))
            icounter++;
		i++;
	}
	return icounter;
}

public
decimal getTotEmployees(){	
	decimal dtot =0;    
	for (int i=0; i < this.Count;i++){
		dtot+= this[i].TotEmployees;		
	}
	return dtot;
}

} // class
} // package