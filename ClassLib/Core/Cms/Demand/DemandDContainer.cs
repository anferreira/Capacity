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
class DemandDContainer : ObservableCollection<DemandD>{
#else
class DemandDContainer : Collection<DemandD> { 
#endif


internal
DemandDContainer() : base(){
}

public
DemandD getByKey(decimal hdrId, decimal detail){
	DemandD demandD = null;
	int i = 0;
	while ((i < this.Count) && (demandD == null)){
		if (hdrId.Equals(this[i].HdrId) && detail.Equals(this[i].Detail))
			demandD = this[i];
		i++;
	}
	return demandD;
}

public
void getMinMaxShipDate(out DateTime minDate,out DateTime maxDate){
    minDate = DateTime.MaxValue;
    maxDate = DateTime.MinValue;
		
	for (int i=0; i < this.Count; i++){
        DemandD demandD = this[i];
		if (minDate > demandD.SDate)
            minDate = demandD.SDate;		

        if (maxDate < demandD.SDate)
            maxDate = demandD.SDate;	
	}	
}

public
DemandDContainer getListByYearWeekNum(int iyear,int iweekOfYear){  
    DemandDContainer demandDContainer = new DemandDContainer();
		
	for (int i=0; i < this.Count; i++){
        DemandD demandD = this[i];

		if (demandD.SDate.Year == iyear && DateUtil.weekNumber(demandD.SDate) == iweekOfYear)
            demandDContainer.Add(demandD);        
	}	
    return demandDContainer;
}

public
Hashtable getHashShipParts(){    
    Hashtable           hashShipParts = new Hashtable();
    string              skey="";

    for (int i=0; i < this.Count; i++){
        DemandD demandD = this[i];
        skey = demandD.ShipTo + "-" + demandD.Part;
        if (!hashShipParts.ContainsKey(skey))
            hashShipParts.Add(skey, demandD);            
	}	
    return hashShipParts;
}


public
void sortByShipPartDateSource(){
	ArrayList arrayToSort = new ArrayList();
	for(int i = 0;i < this.Count;i++)
		arrayToSort.Add(this[i]);

    arrayToSort.Sort(new ShipPartDateSourceComparer());
    this.Clear();	
	for(int i = 0;i < arrayToSort.Count;i++)
        this.Add((DemandD)arrayToSort[i]);
	
}

#region ShipPartDateComparer Class
private
class ShipPartDateSourceComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is DemandD) && (y is DemandD)){
            DemandD d1 = (DemandD)x;
            DemandD d2 = (DemandD)y;

            string saux1 =  d1.ShipTo + Constants.DEFAULT_SEP + d1.Part + Constants.DEFAULT_SEP + 
                            DateUtil.getDateRepresentation(d1.SDate,DateUtil.YYYYMMDD) + Constants.DEFAULT_SEP + d1.Source;                            
            string saux2 =  d2.ShipTo + Constants.DEFAULT_SEP + d2.Part + Constants.DEFAULT_SEP +
                            DateUtil.getDateRepresentation(d2.SDate, DateUtil.YYYYMMDD)+ Constants.DEFAULT_SEP + d2.Source; 
            return saux1.CompareTo(saux2);
        }else
            return -1;
    }
}
#endregion ShipPartDateComparer Class

public
void getCumulativeNetQtySummaryBySourceTimeCodeTrlpKeyId(out decimal dqumulative,out decimal dnetSummary,string source,string stimeCode,int itrlpKeyId){
    dqumulative = 0;
    dnetSummary = 0;
		
	for (int i=0; i < this.Count; i++){
        DemandD demandD = this[i];
		if (demandD.Source.ToUpper().Equals(source.ToUpper()) && demandD.TimeCode.ToUpper().Equals(stimeCode.ToUpper())
            && (itrlpKeyId <= 0 || (itrlpKeyId > 0 && demandD.TrlpKeyId == itrlpKeyId))){
            dqumulative = demandD.QtyCum;		
            dnetSummary+= demandD.NetQty;
        }	        
	}	
}

public
DemandD getFirstBySourceTimeCodeTrlpKeyId(string source,string stimeCode,int itrlpKeyId){
    DemandD demandDResult = null;
		
	for (int i=0; i < this.Count && demandDResult == null; i++){
        DemandD demandD = this[i];
		if (demandD.Source.ToUpper().Equals(source.ToUpper()) && demandD.TimeCode.ToUpper().Equals(stimeCode.ToUpper())
            && (itrlpKeyId <= 0 || (itrlpKeyId > 0 && demandD.TrlpKeyId== itrlpKeyId)) )
            demandDResult = demandD;                    
	}	
    return demandDResult;
}

public
DemandDContainer getByFilters(string source,string stimeCode,string sdiscard,string stpartner,string sbillTo,string shipTo,string spart,decimal dtrlpKey,string sqtyBiggerZero,bool bincludeZerotQty){  
    DemandDContainer demandDContainerReturn = new DemandDContainer();
		
	for (int i=0; i < this.Count; i++){
        DemandD demandD = this[i];

		if ( (string.IsNullOrEmpty(source)   || (StringUtil.ifMatch(demandD.Source.ToUpper(),source.ToUpper()))) &&
             (string.IsNullOrEmpty(stimeCode)|| (StringUtil.ifMatch(demandD.TimeCode.ToUpper(), stimeCode.ToUpper()))) &&
             (string.IsNullOrEmpty(sdiscard) || (StringUtil.ifMatch(demandD.Discard.ToUpper(), sdiscard.ToUpper()))) &&
             (string.IsNullOrEmpty(spart)    || (StringUtil.ifMatch(demandD.Part.ToUpper(), spart.ToUpper()))) &&
             (string.IsNullOrEmpty(stpartner)|| (StringUtil.ifMatch(demandD.TPartner.ToUpper(),stpartner.ToUpper()))) &&
             (string.IsNullOrEmpty(sbillTo)  || (StringUtil.ifMatch(demandD.BillTo.ToUpper(),sbillTo.ToUpper()))) &&
             (string.IsNullOrEmpty(shipTo)   || (StringUtil.ifMatch(demandD.ShipTo.ToUpper(),shipTo.ToUpper()))) &&
             (dtrlpKey == 0                  || demandD.TrlpKeyId == dtrlpKey ) &&
             (bincludeZerotQty               || (!bincludeZerotQty && demandD.NetQty > 0)) &&
             (string.IsNullOrEmpty(sqtyBiggerZero) ||  (sqtyBiggerZero.Equals(Constants.STRING_NO) || (sqtyBiggerZero.Equals(Constants.STRING_YES) && demandD.NetQty > 0)))
             )
            demandDContainerReturn.Add(demandD);        
	}	
    return demandDContainerReturn;
}


public
DemandD getByExact(string source,string srelNum,decimal trlpKeyId,string sbillTo, string shipTo,string spart,DateTime sDate, decimal dnetQty){  
    DemandD demandDFound = null;
		
	for (int i=0; i < this.Count && demandDFound == null; i++){
        DemandD demandD = this[i];

		if (demandD.Source.ToUpper().Equals(source.ToUpper()) &&
            demandD.RelNum.ToUpper().Equals(srelNum.ToUpper()) &&
            demandD.TrlpKeyId == trlpKeyId  &&
            demandD.Part.ToUpper().Equals(spart.ToUpper()) &&

            demandD.BillTo.ToUpper().Equals(sbillTo.ToUpper()) &&
            demandD.ShipTo.ToUpper().Equals(shipTo.ToUpper()) &&

            DateUtil.sameDate(demandD.SDate,sDate) &&
            demandD.NetQty == dnetQty)
            demandDFound = demandD;        
	}	
    return demandDFound;
}

} // class
} // package