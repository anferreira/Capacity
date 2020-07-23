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

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class SchMaterialAvailContainer : ObservableCollection<SchMaterialAvail> { 
#else
class SchMaterialAvailContainer : Collection<SchMaterialAvail> { 
#endif

internal
SchMaterialAvailContainer() : base(){
}

public
SchMaterialAvail getByKey(int id){
	SchMaterialAvail schMaterialAvail = null;
	int i = 0;
	while ((i < this.Count) && (schMaterialAvail == null)){
		if (id.Equals(this[i].Id))
			schMaterialAvail = this[i];
		i++;
	}
	return schMaterialAvail;
}

public
decimal getTotalChildPartButNotId(string schildPart,int childSeq,int inotParentSrcHotDtlId){	
    decimal                     dtotQty= 0;
    SchMaterialAvail            schMaterialAvail = null;
                        	    
    for (int i=0; i < this.Count; i++){
        schMaterialAvail = this[i];
        if ((inotParentSrcHotDtlId == 0 || inotParentSrcHotDtlId != schMaterialAvail.ParentSrcHotDtlId) &&
            schMaterialAvail.ChildPart.ToUpper().Equals(schildPart.ToUpper()) && schMaterialAvail.ChildSeq == childSeq)
            dtotQty+= (schMaterialAvail.ParentQtyAdjust * schMaterialAvail.ChildQty);
    }    	
	return dtotQty;
}

public
SchMaterialAvail getByChildPartButNotId(string schildPart,int childSeq){	    
    SchMaterialAvail            schMaterialAvail = null;
                        	    
    for (int i=0; i < this.Count; i++){        
        if (this[i].ChildPart.ToUpper().Equals(schildPart.ToUpper()) && this[i].ChildSeq == childSeq)
            schMaterialAvail = this[i];
    }    	
	return schMaterialAvail;
}

public
void calculateChildQtyTotal(){	                                	    
    for (int i=0; i < this.Count; i++){        
        SchMaterialAvail schMaterialAvail = this[i];
        schMaterialAvail.ChildQtyTotal = schMaterialAvail.ParentQtyAdjust * schMaterialAvail.ChildQty;
    }    		
}

public
decimal getMinMaxQty(){	
    decimal dminMaxQty= this.Count > 0 ? this[0].MaxQty:0;
                          	    
    for (int i=0; i < this.Count; i++){  
        if (this[i].MaxQty < dminMaxQty)            
            dminMaxQty = this[i].MaxQty;
    }    	
	return dminMaxQty;
}

public
void fillRedundances(){    
    SchMaterialAvail    schMaterialAvail = this.Count > 0 ? this[0]:null;                        	    
    for (int i=0;i < this.Count;i++){
         SchMaterialAvail    schMaterialAvailAux  = this[i];
        
        schMaterialAvailAux.Plant            = schMaterialAvail.Plant;
        schMaterialAvailAux.ParentSrcHotId   = schMaterialAvail.ParentSrcHotId;
        schMaterialAvailAux.ParentSrcHotDtlId= schMaterialAvail.ParentSrcHotDtlId;
        schMaterialAvailAux.ParentQtyAdjust  = schMaterialAvail.ParentQtyAdjust;
        schMaterialAvailAux.DateTime         = schMaterialAvail.DateTime;                     
        schMaterialAvailAux.CounterParentSrcHotId=i+1;                      
    }    
}

public
SchMaterialAvail getFistByPartSeq(string sparentPart,int iparentSeq){
	SchMaterialAvail schMaterialAvail = null;

    for (int i=0;i < this.Count && schMaterialAvail==null; i++){                
		if (sparentPart.ToUpper().Equals(this[i].ParentPart.ToUpper()) && iparentSeq == this[i].ParentSeq)
			schMaterialAvail = this[i];		
	}
	return schMaterialAvail;
}

} // class
} // package