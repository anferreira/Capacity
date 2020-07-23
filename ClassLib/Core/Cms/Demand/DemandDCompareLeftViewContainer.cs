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
class DemandDCompareLeftViewContainer : ObservableCollection<DemandDCompareLeftView>   {
#else
class DemandDViewContainer : Collection<DemandDCompareLeftView> { 
#endif


internal
DemandDCompareLeftViewContainer() : base(){
}

public
DemandDCompareLeftView getFirstByRelDate(DateTime relDate){
    DemandDCompareLeftView demandDCompareLeftView = null;

    for (int i=0; i < this.Count && demandDCompareLeftView == null; i++){    
        if (DateUtil.sameDate(this[i].RelDate, relDate))
            demandDCompareLeftView = this[i];
    }
    return demandDCompareLeftView;
}

        /*
public
DemandDCompareLeftView getFirstByRelDate(string source,string stpartner,string shipLoc,string spart,DateTime relDate){
    DemandDCompareLeftView demandDCompareLeftView = null;

    for (int i=0; i < this.Count && demandDCompareLeftView == null; i++){    
        if (DateUtil.sameDate(this[i].RelDate, relDate))
            demandDCompareLeftView = this[i];
    }
    return demandDCompareLeftView;
}
*/
public
void removeWithoutQty(){
    DemandDCompareLeftView demandDCompareLeftView = null;

    for (int i=0; i < this.Count; i++){    
        demandDCompareLeftView = this[i];

        DemandRelease demandRelease1 = demandDCompareLeftView.DemandRelease1;
        DemandRelease demandRelease2 = demandDCompareLeftView.DemandRelease2;

        if (demandRelease1 == null || demandRelease2 == null ||
           (demandRelease1.Qty == 0  && demandRelease2.Qty == 0)){
            this.RemoveItem(i);
            i--;
        }
    }    
}

public
string exportToExcel(int imode){
    string                  stotal = "";
    string                  sline  ="";
    char                    sep    =';';
    DemandDCompareLeftView  demandDCompareLeftView = null;
    
    for (int i=0; i < this.Count;i++){
        //                       
        demandDCompareLeftView= this[i];
                    
        sline = DateUtil.getDateRepresentation(demandDCompareLeftView.RelDate,DateUtil.MMDDYYYY) + sep;                    
        sline+= Convert.ToInt32(demandDCompareLeftView.DemandRelease1Qty).ToString()     + sep; 
        sline+= Convert.ToInt32(demandDCompareLeftView.DemandRelease2Qty).ToString()     + sep; 

        stotal+= sline + "\n";
    }  
    return stotal;    
}       


} // class
} // package