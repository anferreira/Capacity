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

namespace Nujit.NujitERP.ClassLib.Core.CapacityDemand{

#if !POCKET_PC
[System.Runtime.Serialization.CollectionDataContract]
#endif

public
#if !POCKET_PC
class CapacityViewContainer : ObservableCollection<CapacityView> { 
#else
class CapacityViewContainer : Collection<CapacityView> { 
#endif

internal
CapacityViewContainer() : base(){
}

public
CapacityView getByKey(string plant, string dept, string reqType, string machine, string labour, string tool, string title){
	CapacityView capacityView = null;
	int i = 0;
	while ((i < this.Count) && (capacityView == null)){
		if (plant.Equals(this[i].Plant) && dept.Equals(this[i].Dept) && reqType.Equals(this[i].ReqType) && machine.Equals(this[i].Machine) && labour.Equals(this[i].Labour) && tool.Equals(this[i].Tool) && title.Equals(this[i].Title))
			capacityView = this[i];
		i++;
	}
	return capacityView;
}

public
CapacityView getForMatrix(string sreqName,string title){
	CapacityView capacityView = null;
	int i = 0;
            /*
    System.Windows.Forms.MessageBox.Show("Searching reqName=" + sreqName + "\n" +
                                         "title=" + title);*/

    while ((i < this.Count) && (capacityView == null)){
                /*
        System.Windows.Forms.MessageBox.Show("Searching reqName=" + sreqName + "\n" + "title=" + title + "\n" +
                                             "Current reqName=" + this[i].ReqName + "\n" +
                                             "title=" + this[i].Title+ "\n" +
                                             "Hours=" + this[i].Hours.ToString("0.00"));*/
		if (sreqName.ToUpper().Equals(this[i].ReqName.ToUpper()) && title.ToUpper().Equals(this[i].Title.ToUpper())){
			capacityView = this[i];
                    /*
            System.Windows.Forms.MessageBox.Show("Searching reqName=" + sreqName + "\n" + "title=" + title + "\n" +
                                                 "Found reqName=" + this[i].ReqName + "\n" +
                                                 "title=" + this[i].Title+ "\n" +
                                                 "Hours=" + this[i].Hours.ToString("0.00"));*/
        }
		i++;
	}
	return capacityView;
}

public
CapacityView getForMatrixByPlantDeptResoure(string splantDeptResource,string title){
	CapacityView    capacityView = null;
	int             i = 0;
    string[]        items = splantDeptResource.Split(Constants.DEFAULT_SEP);
    string          splantDept  = items.Length > 0 ? items[0] : "";
    string          sreqName    = items.Length > 1 ? items[1] : "";
            
    while ((i < this.Count) && (capacityView == null)){
                /*
        System.Windows.Forms.MessageBox.Show("Searching reqName=" + sreqName + "\n" + "title=" + title + "\n" +
                                             "Current reqName=" + this[i].ReqName + "\n" +
                                             "title=" + this[i].Title+ "\n" +
                                             "Hours=" + this[i].Hours.ToString("0.00"));*/
		if (splantDept.ToUpper().Equals(this[i].PlantDept.ToUpper()) &&
            sreqName.ToUpper().Equals(this[i].ReqName.ToUpper()) && title.ToUpper().Equals(this[i].Title.ToUpper())){
			capacityView = this[i];
                    /*
            System.Windows.Forms.MessageBox.Show("Searching reqName=" + sreqName + "\n" + "title=" + title + "\n" +
                                                 "Found reqName=" + this[i].ReqName + "\n" +
                                                 "title=" + this[i].Title+ "\n" +
                                                 "Hours=" + this[i].Hours.ToString("0.00"));*/
        }
		i++;
	}
	return capacityView;
}

public
CapacityView getByFirstTitle(string title){
	CapacityView    capacityView = null;
	            
    for (int i=0; i < this.Count && capacityView == null;i++){
        if (title.ToUpper().Equals(this[i].Title.ToUpper()))
		    capacityView = this[i];                                		
	}
	return capacityView;
}

public
CapacityViewContainer getListByPlantDept(string splantDept){
    CapacityViewContainer capacityViewContainer = new CapacityViewContainer();
	
	for (int i = 0; i < this.Count;i++){
	    if (splantDept.ToUpper().Equals(this[i].PlantDept.ToUpper()))
            capacityViewContainer.Add( this[i]);		
	}
	return capacityViewContainer;
}

public
CapacityViewContainer getListByReqType(string sreqType){
    CapacityViewContainer capacityViewContainer = new CapacityViewContainer();
	
	for (int i = 0; i < this.Count;i++){
	    if (sreqType.ToUpper().Equals(this[i].ReqType.ToUpper()))
            capacityViewContainer.Add( this[i]);		
	}
	return capacityViewContainer;
}

public
CapacityViewContainer getListByReqTypeId(string sreqType,int reqId){
    CapacityViewContainer capacityViewContainer = new CapacityViewContainer();
	
	for (int i = 0; i < this.Count;i++){
	    if (sreqType.ToUpper().Equals(this[i].ReqType.ToUpper()) && reqId == this[i].ReqId)
            capacityViewContainer.Add( this[i]);		
	}
	return capacityViewContainer;
}

public
ArrayList getDifferentsReqType(){
    ArrayList       arrayListTypes = new ArrayList();
    Hashtable       hashTable = new Hashtable(); 
	
	 foreach (CapacityView capacityView in this) {    
        if (!hashTable.ContainsKey(capacityView.ReqType)){         
            hashTable.Add(capacityView.ReqType, capacityView.ReqType);
            arrayListTypes.Add(capacityView.ReqType);
        }
    }
	return arrayListTypes;
}

public
ArrayList getDifferentsPlantDept(){
    ArrayList       arrayPlantDept = new ArrayList();
    Hashtable       hashPlantDept = new Hashtable(); 
	
	foreach (CapacityView capacityView in this) {
        if (!hashPlantDept.ContainsKey(capacityView.PlantDept)){         
            hashPlantDept.Add(capacityView.PlantDept, capacityView.PlantDept);
            arrayPlantDept.Add(capacityView.PlantDept);            
        }
    }
	return arrayPlantDept;
}

public
ArrayList getDifferentsPlantDeptResource(out Hashtable hashPlantDeptResource){
    hashPlantDeptResource = new Hashtable(); 
    ArrayList   arrayPlantDeptResource = new ArrayList();    
    string      saux = "";
	             
	foreach (CapacityView capacityView in this) {
        saux = capacityView.PlantDept + Constants.DEFAULT_SEP + capacityView.ReqName;

        if (!hashPlantDeptResource.ContainsKey(saux)){         
            hashPlantDeptResource.Add(saux, capacityView);
            arrayPlantDeptResource.Add(saux);            
        }
    }
	return arrayPlantDeptResource;
}

public
CapacityView getSummarizeByWeek(string stitle,string sreqType){
	CapacityView    capacityView = new CapacityView();
	    
    capacityView.Title = stitle;
    capacityView.ReqName = "Total";
    capacityView.ReqType = sreqType;
    
    for(int i = 0;i < this.Count;i++){
        if (stitle.ToUpper().Equals(this[i].Title.ToUpper()) && sreqType.ToUpper().Equals(this[i].ReqType.ToUpper())){
			capacityView.Hours+= this[i].Hours;                   
            capacityView.SDate = this[i].SDate;                   
        }
	}
	return capacityView;
}


public
int removeByRequirment(string splant,string sdept,string sreqType,string sreqName){
    int icountDeleted=0;

     for(int i = 0;i < this.Count;i++){

        if (splant.ToUpper().Equals(this[i].Plant.ToUpper()) &&
            sdept.ToUpper().Equals(this[i].Dept.ToUpper()) &&
            sreqType.ToUpper().Equals(this[i].ReqType.ToUpper()) &&
            sreqName.ToUpper().Equals(this[i].ReqName.ToUpper())){

            this.RemoveAt(i);
            i--;
        }
	}        
    return icountDeleted;
}

public
void sortByView1(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new CapacityView1Comparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((CapacityView)arrayToSort[i]);
	
}

#region CapacityView1Comparer
private
class CapacityView1Comparer : IComparer{

    public int Compare(object x, object y){
        if ((x is CapacityView) && (y is CapacityView)){
            CapacityView v1 = (CapacityView)x;
            CapacityView v2 = (CapacityView)y;

            string saux1 = v1.Plant + Constants.DEFAULT_SEP + v1.Dept + Constants.DEFAULT_SEP + v1.ReqType + Constants.DEFAULT_SEP + v1.ReqName;
            string saux2 = v2.Plant + Constants.DEFAULT_SEP + v2.Dept + Constants.DEFAULT_SEP + v2.ReqType + Constants.DEFAULT_SEP + v2.ReqName;
            return saux1.CompareTo(saux2);
        }else
            return -1;
    }
}
#endregion CapacityView1Comparer


public
void sortByRequirment(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new CapacityViewRequrimentComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((CapacityView)arrayToSort[i]);	
}

private
class CapacityViewRequrimentComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is CapacityView) && (y is CapacityView)){
            CapacityView v1 = (CapacityView)x;
            CapacityView v2 = (CapacityView)y;

            string saux1 = v1.ReqType + Constants.DEFAULT_SEP + v1.ReqName;
            string saux2 = v2.ReqType + Constants.DEFAULT_SEP + v2.ReqName;
            return saux1.CompareTo(saux2);
        }else
            return -1;
    }
}

} // class
} // package