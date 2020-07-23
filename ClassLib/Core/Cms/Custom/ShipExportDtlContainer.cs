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
class ShipExportDtlContainer : ObservableCollection<ShipExportDtl> { 
#else
class ShipExportDtlContainer : Collection<ShipExportDtl> { 
#endif

internal
ShipExportDtlContainer() : base(){
}

public
ShipExportDtl getByKey(string site, decimal bol, decimal bolItem, int detail){
	ShipExportDtl shipExportDtl = null;
	int i = 0;
	while ((i < this.Count) && (shipExportDtl == null)){
		if (site.Equals(this[i].Site) && bol.Equals(this[i].Bol) && bolItem.Equals(this[i].BolItem) && detail.Equals(this[i].Detail))
			shipExportDtl = this[i];
		i++;
	}
	return shipExportDtl;
}

public
ShipExportDtl getByFilters( decimal order,decimal item,string srelase,string stimestamp,string saction,
                            decimal relQtyInvUnit,decimal qtyShippedInv,decimal qtyBackInv) {
    ShipExportDtl shipExportDtl = null;

	for (int i = 0; i < this.Count && shipExportDtl==null; i++) { 
        
		if (order.Equals(this[i].OrderNum) && item.Equals(this[i].Item) && srelase.ToUpper().Equals(this[i].Release.ToUpper()) &&
            stimestamp.Equals(this[i].TimeStamp) && saction.Equals(this[i].Action) && relQtyInvUnit == this[i].RelQtyInvUnit &&
            qtyShippedInv == this[i].QtyShippedInv && qtyBackInv == this[i].QtyBackInv)
            shipExportDtl = this[i];
	
	}
	return shipExportDtl;
}

public
DateTime getMaxShipDate(){
	DateTime    dateTime =DateUtil.MinValue;
	
    for (int i=0; i< this.Count; i++) { 
        if (this[i].ShipDate > dateTime)
            dateTime= this[i].ShipDate;
    }
	return dateTime;
}

public
DateTime calculateQtyChange(string scurrRelease){
	ShipExportDtl   shipExportDtl       = null;
    ShipExportDtl   shipExportDtlPrior  = null;
    ShipExportDtl   shipExportDtlChanged= null;
    DateTime        dateResult          = DateUtil.MinValue;

    fillDetails();

    for (int i= this.Count-1; i >=0; i--) { 
        shipExportDtl = this[i];
        if (!shipExportDtl.Release.ToUpper().Equals(scurrRelease.ToUpper())) //if not same curr release, could be deleted
            shipExportDtl.Delete = Constants.STRING_YES;

        if (shipExportDtlPrior!= null) {             
            shipExportDtlPrior.DaysShipChanged = Math.Abs(Convert.ToInt32((shipExportDtl.ShipDate- shipExportDtlPrior.ShipDate).TotalDays));

            if (shipExportDtlPrior.DaysShipChanged > 0 && dateResult == DateUtil.MinValue){
                dateResult = shipExportDtlPrior.getTimeStampAsDate();

                if (shipExportDtlChanged == null) { 
                    if (!shipExportDtl.Release.ToUpper().Equals(scurrRelease.ToUpper()))
                        shipExportDtlChanged= shipExportDtl;
                    if (!shipExportDtlPrior.Release.ToUpper().Equals(scurrRelease.ToUpper()))
                        shipExportDtlChanged= shipExportDtlPrior;
                }
            }
        }                
        shipExportDtlPrior= shipExportDtl;   
    }

    //remove shipExportDtl not needed, because belongs to other rel, which there are not DateChange
    for (int i=0; i < this.Count; i++) {  
        shipExportDtl = this[i];
        if (shipExportDtl.Delete.Equals(Constants.STRING_YES) && (shipExportDtlChanged == null || shipExportDtl.Detail != shipExportDtlChanged.Detail) ){
            this.RemoveAt(i);
            i--;
        }
    }
    fillDetails();

            /*
    for (int i=0; i < this.Count; i++) { 
        shipExportDtl = this[i];
        shipExportDtl.QtyChange =0;
        shipExportDtl.DateChange=DateUtil.MinValue;
        shipExportDtl.DaysShipChanged = 0;
        
        if (shipExportDtlPrior!= null) { 
            shipExportDtl.QtyChange = shipExportDtl.RelQtyInvUnit - shipExportDtlPrior.RelQtyInvUnit;
            if (shipExportDtl.QtyChange!= 0)
                shipExportDtl.DateChange= shipExportDtl.getTimeStampAsDate();

            shipExportDtl.DaysShipChanged = Math.Abs(Convert.ToInt32((shipExportDtl.ShipDate- shipExportDtlPrior.ShipDate).TotalDays));
        }                
        shipExportDtlPrior= shipExportDtl;                    
    }
    */
   
    return dateResult;
}

public
void calculateDaysShipChanged(){
	ShipExportDtl   shipExportDtl       = null;
    ShipExportDtl   shipExportDtlPrior  = null;    
    DateTime        dateResult          = DateUtil.MinValue;

    fillDetails();

    for (int i= this.Count-1; i >=0; i--) { 
        shipExportDtl = this[i];
        
        if (shipExportDtlPrior!= null)
            shipExportDtlPrior.DaysShipChanged = Math.Abs(Convert.ToInt32((shipExportDtl.ShipDate- shipExportDtlPrior.ShipDate).TotalDays));
                        
        shipExportDtlPrior= shipExportDtl;   
    }    
}

public
void removeDateTimeStampsRecordMinorThanShipDays(DateTime maxShipDate,int idays){
		
    for (int i=0; i< this.Count && maxShipDate != null; i++) { 
        if (this[i].getTimeStampAsDate() < maxShipDate.AddDays(idays * -1)) { 
            this.RemoveAt(i);
            i--;    
        }
    }	
}

public
void removeRecsWithNoChanges(){
	ShipExportDtl shipExportDtl     = null;
    ShipExportDtl shipExportDtlPrior= null;
	
	for (int i=0; i < this.Count; i++) { 
        shipExportDtl = this[i];

		if (shipExportDtlPrior!= null) { 
            //check if any difference, if not will be removed
            if (shipExportDtl.RelQtyInvUnit != shipExportDtlPrior.RelQtyInvUnit ||
                shipExportDtl.QtyShippedInv != shipExportDtlPrior.QtyShippedInv ||
                DateUtil.minorHour(shipExportDtl.ShipDate) != DateUtil.minorHour(shipExportDtlPrior.ShipDate) ||
                DateUtil.minorHour(shipExportDtl.DateRequest) != DateUtil.minorHour(shipExportDtlPrior.DateRequest))
                shipExportDtlPrior = shipExportDtl; //something was changed so not removed
            else{
                this.RemoveAt(i);
                i--;
            }		
        }

        shipExportDtlPrior = shipExportDtl;
    }
}

public
void removeWithNoActionLike(string saction){
	ShipExportDtl shipExportDtl     = null;    
	for (int i=0; i < this.Count; i++) { 
        shipExportDtl = this[i];
                		  
        if (!shipExportDtl.Action.Equals(saction)){
            this.RemoveAt(i);
            i--;
        }		        
    }
}


public
void fillDetails(){    	
    for (int i=0; i < this.Count; i++) {         
        ShipExportDtl shipExportDtl = this[i];       
        shipExportDtl.Detail    = i+1;        
	}  
}


public
void sortByOrderItemRel(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new OrderItemRelComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((ShipExportDtl)arrayToSort[i]);	
}

private
string getOrderItemKey(decimal order,decimal item){
    string saux1 =  StringUtil.AddChar(Convert.ToInt64(order).ToString(), '0', 15, false) + Constants.DEFAULT_SEP +
                    StringUtil.AddChar( Convert.ToInt64(item).ToString(), '0', 10, false);
    return saux1;
}

private
class OrderItemRelComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is ShipExportDtl) && (y is ShipExportDtl)){
            ShipExportDtl v1 = (ShipExportDtl)x;
            ShipExportDtl v2 = (ShipExportDtl)y;            

            string saux1 =  StringUtil.AddChar(Convert.ToInt64(v1.OrderNum).ToString(),'0',15,false) + Constants.DEFAULT_SEP + 
                            StringUtil.AddChar(Convert.ToInt64(v1.Item).ToString(),    '0',10,false) + Constants.DEFAULT_SEP +
                            v1.Release  + Constants.DEFAULT_SEP + v1.TimeStamp                       + Constants.DEFAULT_SEP + 
                            StringUtil.AddChar(Convert.ToInt64(v1.QtyShippedInv).ToString(), '0', 15, false);

            string saux2 =  StringUtil.AddChar(Convert.ToInt64(v2.OrderNum).ToString(),'0',15,false) + Constants.DEFAULT_SEP + 
                            StringUtil.AddChar(Convert.ToInt64(v2.Item).ToString(),    '0',10,false) + Constants.DEFAULT_SEP +
                            v2.Release  + Constants.DEFAULT_SEP + v2.TimeStamp                       + Constants.DEFAULT_SEP + 
                            StringUtil.AddChar(Convert.ToInt64(v2.QtyShippedInv).ToString(), '0', 15, false);
            return saux1.CompareTo(saux2);
        }else
            return -1;
    }
}


public
void sortByOrderItemTimeStamp(bool bnormalOrder){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new OrderItemTimeStampComparer());
    this.Clear();	

    if (bnormalOrder) { 
	    for(int i = 0;i < arrayToSort.Count;i++) //normal order
            this.Add((ShipExportDtl)arrayToSort[i]);	
    }else{
        for(int i = arrayToSort.Count-1; i >=0;i--)//decreased,newest on top
            this.Add((ShipExportDtl)arrayToSort[i]);	
    }
}

private
class OrderItemTimeStampComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is ShipExportDtl) && (y is ShipExportDtl)){
            ShipExportDtl v1 = (ShipExportDtl)x;
            ShipExportDtl v2 = (ShipExportDtl)y;            

           string saux1 =  StringUtil.AddChar(Convert.ToInt64(v1.OrderNum).ToString(),'0',15,false) + Constants.DEFAULT_SEP + 
                            StringUtil.AddChar(Convert.ToInt64(v1.Item).ToString(),    '0',10,false) + Constants.DEFAULT_SEP +
                            v1.TimeStamp    + Constants.DEFAULT_SEP + 
                            StringUtil.AddChar(Convert.ToInt64(v1.QtyShippedInv).ToString(), '0', 15, false);

            string saux2 =  StringUtil.AddChar(Convert.ToInt64(v2.OrderNum).ToString(),'0',15,false)+ Constants.DEFAULT_SEP + 
                            StringUtil.AddChar(Convert.ToInt64(v2.Item).ToString(),    '0',10,false)+ Constants.DEFAULT_SEP +
                            v2.TimeStamp                                                            + Constants.DEFAULT_SEP + 
                            StringUtil.AddChar(Convert.ToInt64(v2.QtyShippedInv).ToString(), '0', 15, false);
            return saux1.CompareTo(saux2);
        }else
            return -1;
    }
}

} // class
} // package