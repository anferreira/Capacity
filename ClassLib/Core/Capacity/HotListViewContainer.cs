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
using Nujit.NujitERP.ClassLib.Core.Machines;

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class HotListViewContainer : ObservableCollection<HotListView> { 
#else
class HotListViewContainer : Collection<HotListView> { 
#endif

internal
HotListViewContainer() : base(){
}

public
HotListView getByPartSeqDate(string spart, int seq,DateTime startDate){
	HotListView hotListView = null;
	int i = 0;
	while ((i < this.Count) && (hotListView == null)){
		if (spart.Equals(this[i].ProdID) && seq.Equals(this[i].Seq) && startDate.Equals(this[i].StartDate))
			hotListView = this[i];
		i++;
	}
	return hotListView;
}

public
HotListView getByMachineDate(string splant, string smach,DateTime startDate){
	HotListView hotListView = null;
	int i = 0;
	while ((i < this.Count) && (hotListView == null)){
		if (splant.Equals(this[i].Plant) && smach.Equals(this[i].Mach) && startDate.Equals(this[i].StartDate))
			hotListView = this[i];
		i++;
	}
	return hotListView;
}


public
ArrayList getDifferentsPlantDeptResource(out Hashtable hashPlantDeptResource){
    hashPlantDeptResource = new Hashtable(); 
    ArrayList   arrayPlantDeptResource = new ArrayList();    
    string      saux = "";
	             
	foreach (HotListView hotListView in this) {
        saux = hotListView.Dept + Constants.DEFAULT_SEP + hotListView.Mach;

        if (!hashPlantDeptResource.ContainsKey(saux)){         
            hashPlantDeptResource.Add(saux, hotListView);
            arrayPlantDeptResource.Add(saux);            
        }
    }
	return arrayPlantDeptResource;
}

public
HotListViewContainer getListByMachine(string sdeptMachine){
    HotListViewContainer    hotListViewContainer = new HotListViewContainer();
    string[]                items   = sdeptMachine.Split(Constants.DEFAULT_SEP);
    string                  sdept   = items.Length > 0 ? items[0] : "";
    string                  smachine= items.Length > 1 ? items[1] : "";

    hotListViewContainer = getListByMachine(sdept,smachine);    
    return hotListViewContainer;
}

public
HotListViewContainer getListByMachine(string sdept,string smachine){
    HotListViewContainer    hotListViewContainer = new HotListViewContainer();
    
    for (int i=0; i < this.Count;i++){      
        if (sdept.ToUpper().Equals(this[i].Dept.ToUpper()) && smachine.ToUpper().Equals(this[i].Mach.ToUpper()))
			hotListViewContainer.Add(this[i]);                                    
	}
    return hotListViewContainer;
}
public
HotListView getForMatrixByDeptMachine(string title){
	HotListView     hotListView = null;
	int             i = 0;   
    string          scurrWeek= "";

    while ((i < this.Count) && (hotListView == null)){
        if (string.IsNullOrEmpty(this[i].WeekTitle)){ //check if WeekTitle filled if not it will be generated, based on date
            scurrWeek = CapacityView.getTitleWeeekByDate(this[i].StartDate);
            this[i].WeekTitle = scurrWeek;
        }

        if (title.ToUpper().Equals(this[i].WeekTitle.ToUpper()))
			hotListView = this[i];                            
		i++;
	}
	return hotListView;
}

public
HotListViewContainer getByDatesRange(DateTime startDate,DateTime endDate){
	HotListViewContainer        hotListViewContainer = new HotListViewContainer();
	   
    for (int i=0; i < this.Count;i++){          
        if (startDate <= this[i].StartDate && this[i].EndDate <= endDate)
			hotListViewContainer.Add(this[i]);		
	}
	return hotListViewContainer;
}

public
HotListViewContainer getChildsByDatesRangeAndnMachine(Machine machine, DateTime startDate,DateTime endDate){
	HotListViewContainer        hotListViewContainer = new HotListViewContainer();
	   
    for (int i=0; i < this.Count;i++){          
        if ( (startDate <= this[i].StartDate && this[i].EndDate <= endDate) && 
            machine.Dept.ToUpper().Equals(this[i].Dept.ToUpper()) && machine.Mach.ToUpper().Equals(this[i].Mach.ToUpper())){
			        
            for (int j=0; j < this[i].HotListViewContainer.Count;j++){
                    HotListView hotListViewchild = this[i].HotListViewContainer[j];

                    if ((startDate <= hotListViewchild.StartDate && hotListViewchild.EndDate <= endDate) &&
                        machine.Dept.ToUpper().Equals(hotListViewchild.Dept.ToUpper()) && machine.Mach.ToUpper().Equals(hotListViewchild.Mach.ToUpper()))
                        hotListViewContainer.Add(hotListViewchild);
                }
        }
	}
	return hotListViewContainer;
}

public
void sortByLocationMachine(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new HotListviewLocationMachineComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((HotListView)arrayToSort[i]);	
}

private
class HotListviewLocationMachineComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is HotListView) && (y is HotListView)){
            HotListView v1 = (HotListView)x;
            HotListView v2 = (HotListView)y;

            string saux1 = v1.Plant + Constants.DEFAULT_SEP + v1.Dept + Constants.DEFAULT_SEP + v1.Mach + Constants.DEFAULT_SEP + DateUtil.getCompleteDateRepresentation(v1.StartDate,DateUtil.YYYYMMDD);
            string saux2 = v2.Plant + Constants.DEFAULT_SEP + v2.Dept + Constants.DEFAULT_SEP + v2.Mach + Constants.DEFAULT_SEP + DateUtil.getCompleteDateRepresentation(v2.StartDate,DateUtil.YYYYMMDD);
            return saux1.CompareTo(saux2);
        }else
            return -1;
    }
}


public
void sortByMachine(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new HotListviewMachineComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((HotListView)arrayToSort[i]);	
}

private
class HotListviewMachineComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is HotListView) && (y is HotListView)){
            HotListView v1 = (HotListView)x;
            HotListView v2 = (HotListView)y;

            string saux1 = v1.Mach + Constants.DEFAULT_SEP + DateUtil.getCompleteDateRepresentation(v1.StartDate,DateUtil.YYYYMMDD);
            string saux2 = v2.Mach + Constants.DEFAULT_SEP + DateUtil.getCompleteDateRepresentation(v2.StartDate,DateUtil.YYYYMMDD);
            return saux1.CompareTo(saux2);
        }else
            return -1;
    }
}

public
void sortByDate(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new HotListviewDateComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((HotListView)arrayToSort[i]);	
}

private
class HotListviewDateComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is HotListView) && (y is HotListView)){
            HotListView v1 = (HotListView)x;
            HotListView v2 = (HotListView)y;

            string saux1 = DateUtil.getCompleteDateRepresentation(v1.StartDate,DateUtil.YYYYMMDD) + Constants.DEFAULT_SEP + v1.Mach;
            string saux2 = DateUtil.getCompleteDateRepresentation(v2.StartDate,DateUtil.YYYYMMDD) + Constants.DEFAULT_SEP + v2.Mach;
            return saux1.CompareTo(saux2);
        }else
            return -1;
    }
}


public
HotListViewContainer applyFilters(string splant,string sdept,string smachine,DateTime weekDate){
    HotListViewContainer    hotListViewContainer = new HotListViewContainer();
    HotListView             hotListView = null;
    
    for (int i=0; i < this.Count;i++){      
        hotListView = this[i];

        if ((string.IsNullOrEmpty(splant)   || hotListView.Plant.ToUpper().IndexOf(splant.Replace("%","").ToUpper()) ==0 ) &&
            (string.IsNullOrEmpty(sdept)    || hotListView.Dept.ToUpper().IndexOf(sdept.Replace("%", "").ToUpper()) == 0 ) &&
            (string.IsNullOrEmpty(smachine) || hotListView.Mach.ToUpper().IndexOf(smachine.Replace("%", "").ToUpper()) == 0 ) &&
            (weekDate == DateUtil.MinValue  || hotListView.StartDate.Equals(weekDate)))        
			hotListViewContainer.Add(this[i]);                                    
	}
    return hotListViewContainer;
}

} // class
} // package