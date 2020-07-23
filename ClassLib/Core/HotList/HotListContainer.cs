/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.ObjectModel;
using System.Collections;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class HotListContainer : ObservableCollection<HotList> { 
#else
class HotListContainer : Collection<HotList> { 
#endif

internal
HotListContainer() : base(){
}

public
HotList getByKey(int idAut){
	HotList hotList = null;
	int i = 0;
	while ((i < this.Count) && (hotList == null)){
		if (idAut.Equals(this[i].IdAut))
			hotList = this[i];
		i++;
	}
	return hotList;
}

public
HotList getByPartSeq(string spart,int iseq){
	HotList hotList = null;
	
    for (int i=0; i < this.Count && hotList == null; i++){
		if (spart.ToUpper().Equals(this[i].ProdID.ToUpper()) && iseq == this[i].Seq)
			hotList = this[i];		
	}
	return hotList;
}

public
void sortByMachine(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new HotListMachineComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((HotList)arrayToSort[i]);    
}

#region HotListMachineComparer
private
class HotListMachineComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is HotList) && (y is HotList)){
            HotList v1 = (HotList)x;
            HotList v2 = (HotList)y;

            string saux1 = v1.Dept + Constants.DEFAULT_SEP + v1.Mach;
            string saux2 = v2.Dept + Constants.DEFAULT_SEP + v2.Mach;
            return saux1.CompareTo(saux2);
        }else
            return -1;
    }
}
#endregion ScheduleDateComparer

/*
public
void setQohAffectsNets(bool bcumulativeQty){
	HotList     hotList = null;
    decimal     dpastDue= 0;
    decimal     dnet    = 0;
    string      sfield  = "";        
    
    for (int i=0; i < this.Count; i++){
        hotList = this[i];
        if (bcumulativeQty)
            hotList.calculateNonCumulative();

        dpastDue= hotList.PastDue; // hotList.PastDue = -57 Qoh=92
        if (hotList.Qoh > Math.Abs(hotList.PastDue))
            hotList.PastDue = 0;
        dpastDue+= hotList.Qoh;                 

        for (int j=0; j < Constants.MAX_HOTLIST_DAYS; j++){
            sfield  = "Day" + (j+1).ToString("000");
            dnet    = hotList.getQtyByFieldName(sfield);

            if (dpastDue > Math.Abs(dnet)) { 
                //hotList.setQtyByDate(runDate,runDate.AddDays(j),0);
                hotList.setQtyByFieldName(sfield,0);
                dpastDue+=dnet;
            }else{
                dpastDue+=dnet;
                //hotList.setQtyByDate(runDate,runDate.AddDays(j),dpastDue);            
                hotList.setQtyByFieldName(sfield,dpastDue);
            }                        
        }
        if (!bcumulativeQty)
            hotList.calculateNonCumulative();
    }
}*/

public
void setQohAffectsNets(bool bcumulativeQty){	          
    for (int i=0; i < this.Count; i++){
        this[i].setQohAffectsNets(bcumulativeQty);
    }
}

} // class
} // package