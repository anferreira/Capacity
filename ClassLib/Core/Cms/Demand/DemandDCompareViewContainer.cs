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
class DemandDCompareViewContainer : ObservableCollection<DemandDCompareView>{
#else
class DemandDViewContainer : Collection<DemandDView> { 
#endif


internal
DemandDCompareViewContainer() : base(){
}

public
DemandDCompareView getFirstByDate(DateTime runDate,DateTime date){
    DemandDCompareView demandDCompareViewRet = null;

    for (int i=0; i < this.Count && demandDCompareViewRet==null; i++){
        DemandDCompareView demandDCompareView = this[i];
        if (demandDCompareView.getQtyByDate(runDate,date) != 0)
            demandDCompareViewRet = demandDCompareView;
    }
    return demandDCompareViewRet;
}

public
DemandDCompareView getFirstByFilters(string source,string stpartner,string shipLoc,string relNum,string spart){
    DemandDCompareView demandDCompareViewRet = null;

    for (int i=0; i < this.Count && demandDCompareViewRet==null; i++){
        DemandDCompareView demandDCompareView = this[i];

        if (demandDCompareView.Source.ToUpper().Equals(source.ToUpper()) &&
            demandDCompareView.TPartner.ToUpper().Equals(stpartner.ToUpper()) &&
            demandDCompareView.ShipLoc.ToUpper().Equals(shipLoc.ToUpper()) &&
            demandDCompareView.RelNum.ToUpper().Equals(relNum.ToUpper()) &&
            demandDCompareView.Part.ToUpper().Equals(spart.ToUpper()) )
            demandDCompareViewRet= demandDCompareView;
    }
    return demandDCompareViewRet;
}

public
void calculateNetsQty(DateTime runDate){
    for (int i=0; i < this.Count;i++){
        this[i].calculateNetsQty(runDate);      
    }
}

public
void showFullCumulativeQty(DateTime runDate){
    DemandDCompareView  demandDCompareView      = null;    
    decimal             qty                     = 0;    
    DateTime            dateFilter              = runDate;

    for (int i=0; i < this.Count; i++){
        demandDCompareView = this[i];

        for (int j=-1; j < Constants.MAX_HOTLIST_DAYS;j++){
            dateFilter = runDate.AddDays(j);
            qty = demandDCompareView.getQtyByDate(runDate,dateFilter);

            if (qty == 0){ 
                qty = demandDCompareView.getQtyByDateBackUntilFoundQty(runDate,dateFilter);//going back to get Qty
                if (qty == 0)
                    qty = demandDCompareView.getQtyByDateForwardUntilFoundQty(runDate,dateFilter);//not found yet, so going forward to get qty
                if (qty != 0)
                    demandDCompareView.setQtyByDate(runDate,dateFilter,qty);
            }            
        }           
    }    
}

public
DemandDCompareLeftViewContainer convertToDatesLeftSide(DateTime runDate){
    DemandDCompareLeftViewContainer demandDCompareLeftViewContainer = new DemandDCompareLeftViewContainer();
    DemandDCompareLeftView          demandDCompareLeftView          = null;
    DemandDCompareView              demandDCompareView              = null;
    decimal                         dqty                            = 0;
     
    for (int i=0; i < this.Count && i < 2; i++){ //only 2 releases will be processed
        demandDCompareView = this[i];

        for (int j=-1; j < Constants.MAX_HOTLIST_DAYS;j++){

            demandDCompareLeftView = demandDCompareLeftViewContainer.getFirstByRelDate(runDate.AddDays(j));
            if (demandDCompareLeftView == null){
                demandDCompareLeftView = new DemandDCompareLeftView();
                demandDCompareLeftViewContainer.Add(demandDCompareLeftView);
            }

            demandDCompareLeftView.RelDate  = runDate.AddDays(j);
            demandDCompareLeftView.NetQty   = demandDCompareView.getQtyByDate(runDate,runDate.AddDays(j));

            if (i== 0 && demandDCompareLeftView.DemandRelease1 == null){
                demandDCompareLeftView.DemandRelease1 = new DemandRelease();
                demandDCompareLeftView.DemandRelease1.copy(demandDCompareView,demandDCompareLeftView.NetQty);             
            }
            if (i== 1 && demandDCompareLeftView.DemandRelease2 == null){
                demandDCompareLeftView.DemandRelease2 = new DemandRelease();
                demandDCompareLeftView.DemandRelease2.copy(demandDCompareView,demandDCompareLeftView.NetQty);                                        
            }            
        }
    }
    return demandDCompareLeftViewContainer;
}

public
void adjustZeroValues(DateTime runDate){
    DemandDCompareView  demandDCompareView      = null;
    DemandDCompareView  demandDCompareViewAux   = null;
    decimal             qty                     = 0;    
    DateTime            dateFilter              = runDate;

    for (int i=0; i < this.Count; i++){
        demandDCompareView = this[i];

        for (int j=-1; j < Constants.MAX_HOTLIST_DAYS;j++){

            dateFilter = runDate.AddDays(j);
            qty = demandDCompareView.getQtyByDate(runDate,dateFilter);

            if (qty != 0){
                for (int h=0; h < this.Count; h++){
                    demandDCompareViewAux = this[h];

                    if (i != h) {       //different index
                        qty = demandDCompareViewAux.getQtyByDate(runDate,dateFilter);
                        if (qty == 0){ //if item has empty qty , adjust to get until prior qty filled
                            qty = demandDCompareViewAux.getQtyByDateBackUntilFoundQty(runDate,dateFilter);
                            demandDCompareViewAux.setQtyByDate(runDate,dateFilter,qty);
                        }
                    }
                }
            }
        }           
    }    
}

public
void sortByRelDate(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new RelDateComparer());
    this.Clear();	
	for(int i = arrayToSort.Count-1; i >=0;i--) //order date descendent
        this.Add((DemandDCompareView)arrayToSort[i]);
	
}

#region RelDateComparer Class
private
class RelDateComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is DemandDCompareView) && (y is DemandDCompareView)){
            DemandDCompareView d1 = (DemandDCompareView)x;
            DemandDCompareView d2 = (DemandDCompareView)y;

            string saux1 = d1.Source + Constants.DEFAULT_SEP+ DateUtil.getDateRepresentation(d1.RelDate, DateUtil.YYYYMMDD);
            string saux2 = d2.Source + Constants.DEFAULT_SEP +DateUtil.getDateRepresentation(d2.RelDate, DateUtil.YYYYMMDD);
            
            return saux1.CompareTo(saux2);            
        }else
            return -1;
    }
}
#endregion ShipPartDateComparer Class


public
DemandDCompareLeftViewContainer convertToDatesLeftSide2(DateTime runDate){
    DemandDCompareLeftViewContainer demandDCompareLeftViewContainer = new DemandDCompareLeftViewContainer();
    DemandDCompareLeftView          demandDCompareLeftView          = null;
    DemandDCompareView              demandDCompareView              = null;
    decimal                         dqty                            = 0;
     
    for (int i=0; i < this.Count && i < 2; i++){ //only 2 releases will be processed
        demandDCompareView = this[i];

        for (int j=-1; j < Constants.MAX_HOTLIST_DAYS;j++){

            demandDCompareLeftView = demandDCompareLeftViewContainer.getFirstByRelDate(runDate.AddDays(j));
            if (demandDCompareLeftView == null){
                demandDCompareLeftView = new DemandDCompareLeftView();
                demandDCompareLeftViewContainer.Add(demandDCompareLeftView);
            }

            demandDCompareLeftView.RelDate  = runDate.AddDays(j);
            demandDCompareLeftView.NetQty   = demandDCompareView.getQtyByDate(runDate,runDate.AddDays(j));

            if (i== 0 && demandDCompareLeftView.DemandRelease1 == null){
                demandDCompareLeftView.DemandRelease1 = new DemandRelease();
                demandDCompareLeftView.DemandRelease1.copy(demandDCompareView,demandDCompareLeftView.NetQty);             
            }
            if (i== 1 && demandDCompareLeftView.DemandRelease2 == null){
                demandDCompareLeftView.DemandRelease2 = new DemandRelease();
                demandDCompareLeftView.DemandRelease2.copy(demandDCompareView,demandDCompareLeftView.NetQty);                                        
            }            
        }
    }
    return demandDCompareLeftViewContainer;
}

public
string exportToExcel(int imode){
    string              stotal = "";
    string              sline  ="";
    char                sep    =';';
    DemandDCompareView  demandDCompareView= null;

    for (int i=0; i < this.Count;i++){
        //Part;Cust Part;Source;Ship To;ShipLoc;Qoh;PastDue;CurrWk02/24;CurrWk02/25;CurrWk02/26;CurrWk02/27;CurrWk02/28;CurrWk02/29;CurrWk03/01;Week103/02;Week103/03;Week103/04;Week103/05;Week103/06;Week103/07;Week103/08;Week203/09;Week203/10;Week203/11;Week203/12;Week203/13;Week203/14;Week203/15;Week303/16;Week303/17;Week303/18;Week303/19;Week303/20;Week303/21;Week303/22;Week403/23;Week403/24;Week403/25;Week403/26;Week403/27;Week403/28;Week403/29;Week503/30;Week503/31;Week504/01;Week504/02;Week504/03;Week504/04;Week504/05;Week604/06;Week604/07;Week604/08;Week604/09;Week604/10;Week604/11;Week604/12;Week704/13;Week704/14;Week704/15;Week704/16;Week704/17;Week704/18;Week704/19;Week804/20;Week804/21;Week804/22;Week804/23;Week804/24;Week804/25;Week804/26;Week904/27;Week904/28;Week904/29;Week904/30;Week905/01;Week905/02;Week905/03;Week1005/04;Week1005/05;Week1005/06;Week1005/07;Week1005/08;Week1005/09;Week1005/10;Week1105/11;Week1105/12;Week1105/13;Week1105/14;Week1105/15;Week1105/16;Week1105/17;Week1205/18;Week1205/19;Week1205/20;Week1205/21;Week1205/22;Week1205/23;\n"
        demandDCompareView= this[i];
                    
        sline = demandDCompareView.RelNum      + sep;
        if (imode >= 1 && imode <= 2)
            sline+= DateUtil.getDateRepresentation( demandDCompareView.RelDate,DateUtil.MMDDYYYY) + sep;
        sline+= Convert.ToInt32(demandDCompareView.PastDue).ToString()     + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day001).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day002).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day003).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day004).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day005).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day006).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day007).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day008).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day009).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day010).ToString()      + sep;

        sline+= Convert.ToInt32(demandDCompareView.Day011).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day012).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day013).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day014).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day015).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day016).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day017).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day018).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day019).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day020).ToString()      + sep;

        sline+= Convert.ToInt32(demandDCompareView.Day021).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day022).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day023).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day024).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day025).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day026).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day027).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day028).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day029).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day030).ToString()      + sep;

        sline+= Convert.ToInt32(demandDCompareView.Day031).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day032).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day033).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day034).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day035).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day036).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day037).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day038).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day039).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day040).ToString()      + sep;

        sline+= Convert.ToInt32(demandDCompareView.Day041).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day042).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day043).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day044).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day045).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day046).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day047).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day048).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day049).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day050).ToString()      + sep;

        sline+= Convert.ToInt32(demandDCompareView.Day051).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day052).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day053).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day054).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day055).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day056).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day057).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day058).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day059).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day060).ToString()      + sep;

        sline+= Convert.ToInt32(demandDCompareView.Day061).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day062).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day063).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day064).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day065).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day066).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day067).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day068).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day069).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day070).ToString()      + sep;

        sline+= Convert.ToInt32(demandDCompareView.Day071).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day072).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day073).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day074).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day075).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day076).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day077).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day078).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day079).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day080).ToString()      + sep;

        sline+= Convert.ToInt32(demandDCompareView.Day081).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day082).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day083).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day084).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day085).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day086).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day087).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day088).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day089).ToString()      + sep;
        sline+= Convert.ToInt32(demandDCompareView.Day090).ToString()      + sep;
           
        stotal+= sline + "\n";
    }  
    return stotal;    
}       

} // class
} // package