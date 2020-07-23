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
class DemandDCompareReportViewContainer : DemandDCompareViewContainer{

internal
DemandDCompareReportViewContainer() : base(){
}

public
DemandDCompareReportView getFirstWithQtyNonZero(DateTime date){
    DemandDCompareReportView    demandDCompareReportView    = null;
    DemandDCompareReportView    demandDCompareReportViewRet = null;
    CellDemandDCompareReport    cellDemandDCompareReport    = null;    

    for (int i=0; i < this.Count && demandDCompareReportViewRet== null; i++){
        demandDCompareReportView = (DemandDCompareReportView)this[i];

        cellDemandDCompareReport = demandDCompareReportView.getCellByDate(date);
        if (cellDemandDCompareReport!= null && (cellDemandDCompareReport.QtyNew !=0 || cellDemandDCompareReport.QtyOld != 0))
            demandDCompareReportViewRet= demandDCompareReportView;
    }
    return demandDCompareReportViewRet;
}

public
void convertToNetQty(){
    DemandDCompareReportView    demandDCompareReportView    = null;
    DemandDCompareReportView    demandDCompareReportViewRet = null;
    CellDemandDCompareReport    cellDemandDCompareReport    = null;    

    for (int i=0; i < this.Count && demandDCompareReportViewRet== null; i++){
        demandDCompareReportView = (DemandDCompareReportView)this[i];
        demandDCompareReportView.convertToNetQty(null,true);
        demandDCompareReportView.convertToNetQty(null,false);
    }    
}

public
void showFullCumulativeQty(){
    DemandDCompareReportView    demandDCompareReportView= null;    

    for (int i=0; i < this.Count; i++){
        demandDCompareReportView = (DemandDCompareReportView)this[i];
        demandDCompareReportView.showFullCumulativeQty(true);
        demandDCompareReportView.showFullCumulativeQty(false);
    }
}

public
string exportToExcel(DateTime runDate,bool bcolumnsWQty){
    string                      stotal = "";    
    string                      sline  ="";
    char                        sep    =',';
    char                        sepMult=' ';
    int                         i      = 0;
    int                         j      = 0;
    DemandDCompareReportView    demandDCompareReportView    = null;
    CellDemandDCompareReport    cellDemandDCompareReport    = null;
    bool                        bloadInfo                   = true;
    Hashtable                   hashRemoved                 = new Hashtable();

    sline = "TPartner" + sep + "ShipLoc" + sep + "Part" + sep + "Release" + sep;
    if (this.Count > 0){
        demandDCompareReportView=(DemandDCompareReportView)this[0];
        for (j=0; j < demandDCompareReportView.ArrayDays.Count; j++){
            cellDemandDCompareReport = (CellDemandDCompareReport)demandDCompareReportView.ArrayDays[j];

            bloadInfo= true;
            if (bcolumnsWQty && this.getFirstWithQtyNonZero(cellDemandDCompareReport.StartDate) == null){ 
                bloadInfo=false;
                hashRemoved.Add(DateUtil.minorHour(cellDemandDCompareReport.StartDate), DateUtil.minorHour(cellDemandDCompareReport.StartDate));
            }

            if (bloadInfo)
                sline+= DateUtil.getDateRepresentation(cellDemandDCompareReport.StartDate,DateUtil.MMDDYYYY).Substring(0,5) + sep;
        }       
    }
    stotal= sline + "\n";    

    for (i=0; i < this.Count;i++){
        
        demandDCompareReportView= (DemandDCompareReportView)this[i];
        sline = demandDCompareReportView.TPartner   + sep       + demandDCompareReportView.ShipLoc + sep + demandDCompareReportView.Part + sep;
        sline+= demandDCompareReportView.RelNum     + sepMult   + demandDCompareReportView.RelNum2 + sep;

        for (j=0; j < demandDCompareReportView.ArrayDays.Count; j++){
            cellDemandDCompareReport = (CellDemandDCompareReport)demandDCompareReportView.ArrayDays[j];                               

            bloadInfo= true;
            if (bcolumnsWQty && hashRemoved.Contains(DateUtil.minorHour(cellDemandDCompareReport.StartDate)))                        
                bloadInfo=false;

            if (bloadInfo)
                sline+= cellDemandDCompareReport.concatQtys(sepMult) + sep;            
        }
        stotal+= sline + "\n";
    }  
    return stotal;    
}       


} // class
} // package