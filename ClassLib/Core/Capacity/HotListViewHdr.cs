/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////


using System;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class HotListViewHdr : HotListViewBase {

private HotListViewContainer hotListViewContainer;


#if !WEB
internal
#else
public
#endif
HotListViewHdr() : base(){
    init();
}

private
void init(){
    this.hotListViewContainer = new HotListViewContainer();
}

internal
HotListViewHdr( int hotListIdAut,
                int hotListId,
                int machineId,
                string plant,
                string dept,
                string mach) : base (hotListIdAut,hotListId, machineId, plant,dept,mach){    
}

public
void addToList(HotListView hotListView){
    switch(hotListView.ShowType){
        case CapacityView.SHOW_TYPE.TYPE_NORMAL:
            hotListViewContainer.Add(hotListView);    
            break;                            
    }
}

public
HotListViewContainer getList(CapacityView.SHOW_TYPE showType){    
    switch(showType){
        case CapacityView.SHOW_TYPE.TYPE_NORMAL:
            return hotListViewContainer;                               
    }
    return null;
}


} // class
} // package