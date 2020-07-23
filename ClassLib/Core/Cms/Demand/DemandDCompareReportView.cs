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
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;
using System.Collections;

namespace Nujit.NujitERP.ClassLib.Core.Cms{

#if !POCKET_PC
[System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class DemandDCompareReportView :  DemandDCompareView {
       
private ArrayList arrayDays;
private CellTitles cellTitles;
private decimal logNum;

public
DemandDCompareReportView(DateTime runDate): base(){        
    this.logNum = 0;

    arrayDays = new ArrayList(); //generate for 90 days
    for (int i=0; i < 90; i++){
        CellDemandDCompareReport cellDemandDCompareReport = new CellDemandDCompareReport();        
        cellDemandDCompareReport.StartDate = cellDemandDCompareReport.EndDate = runDate.AddDays(i);
        arrayDays.Add(cellDemandDCompareReport);
        cellDemandDCompareReport.XIndex = i;
    }
    
    this.cellTitles = new CellTitles();    
    this.cellTitles.Title1 = "";
    this.cellTitles.Title2 = "";
    this.cellTitles.Title3 = "";        
}

[System.Runtime.Serialization.DataMember]
public
decimal LogNum {
	get { return logNum; }
	set { if (this.logNum != value){
			this.logNum = value;
			Notify("LogNum");
		}
	}
}

public
CellDemandDCompareReport getCellByIndex(int i){
    CellDemandDCompareReport cell = null;
    if (i >= 0 && i < arrayDays.Count)
        cell = (CellDemandDCompareReport)arrayDays[i];
    return cell;
}

public
void setCellByIndex(int i,CellDemandDCompareReport cell){    
    if (i >= 0 && i < arrayDays.Count)
        arrayDays[i]= cell;    
}

public
CellDemandDCompareReport getCellByDate(DateTime date){    
    CellDemandDCompareReport cellDemandDCompareReport   = null;  
    CellDemandDCompareReport cellDemandDCompareReportRet= null;  
    
    for (int i=0; i < Constants.MAX_HOTLIST_DAYS && cellDemandDCompareReportRet==null; i++){
        cellDemandDCompareReport = (CellDemandDCompareReport)arrayDays[i];        
        if ( DateUtil.minorHour(cellDemandDCompareReport.StartDate) == DateUtil.minorHour(date))       
            cellDemandDCompareReportRet = cellDemandDCompareReport;
    }
    return cellDemandDCompareReportRet;
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day001 {
	get { return getCellByIndex(0);}
	set {
        setCell(0,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day002 {
	get { return getCellByIndex(1);}
	set {
        setCell(1,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day003 {
	get { return getCellByIndex(2);}
	set {
        setCell(2,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day004 {
	get { return getCellByIndex(3);}
	set {
        setCell(3,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day005 {
	get { return getCellByIndex(4);}
	set {
        setCell(4,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day006 {
	get { return getCellByIndex(5);}
	set {
        setCell(5,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day007 {
	get { return getCellByIndex(6);}
	set {
        setCell(6,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day008 {
	get { return getCellByIndex(7);}
	set {
        setCell(7,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day009 {
	get { return getCellByIndex(8);}
	set {
        setCell(8,value);
	}
}


[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day010 {
	get { return getCellByIndex(9);}
	set {
        setCell(9,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day011 {
	get { return getCellByIndex(10);}
	set {
        setCell(10,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day012 {
	get { return getCellByIndex(11);}
	set {
        setCell(11,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day013 {
	get { return getCellByIndex(12);}
	set {
        setCell(12,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day014 {
	get { return getCellByIndex(13);}
	set {
        setCell(13,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day015 {
	get { return getCellByIndex(14);}
	set {
        setCell(14,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day016 {
	get { return getCellByIndex(15);}
	set {
        setCell(15,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day017 {
	get { return getCellByIndex(16);}
	set {
        setCell(16,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day018 {
	get { return getCellByIndex(17);}
	set {
        setCell(17,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day019 {
	get { return getCellByIndex(18);}
	set {
        setCell(18,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day020 {
	get { return getCellByIndex(19);}
	set {
        setCell(19,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day021 {
	get { return getCellByIndex(20);}
	set {
        setCell(20,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day022 {
	get { return getCellByIndex(21);}
	set {
        setCell(21,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day023 {
	get { return getCellByIndex(22);}
	set {
        setCell(22,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day024 {
	get { return getCellByIndex(23);}
	set {
        setCell(23,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day025 {
	get { return getCellByIndex(24);}
	set {
        setCell(24,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day026 {
	get { return getCellByIndex(25);}
	set {
        setCell(25,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day027 {
	get { return getCellByIndex(26);}
	set {
        setCell(26,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day028 {
	get { return getCellByIndex(27);}
	set {
        setCell(27,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day029 {
	get { return getCellByIndex(28);}
	set {
        setCell(28,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day030 {
	get { return getCellByIndex(29);}
	set {
        setCell(29,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day031 {
	get { return getCellByIndex(30);}
	set {
        setCell(30,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day032 {
	get { return getCellByIndex(31);}
	set {
        setCell(31,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day033 {
	get { return getCellByIndex(32);}
	set {
        setCell(32,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day034 {
	get { return getCellByIndex(33);}
	set {
        setCell(33,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day035 {
	get { return getCellByIndex(34);}
	set {
        setCell(34,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day036 {
	get { return getCellByIndex(35);}
	set {
        setCell(35,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day037 {
	get { return getCellByIndex(36);}
	set {
        setCell(36,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day038 {
	get { return getCellByIndex(37);}
	set {
        setCell(37,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day039 {
	get { return getCellByIndex(38);}
	set {
        setCell(38,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day040 {
	get { return getCellByIndex(39);}
	set {
        setCell(39,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day041 {
	get { return getCellByIndex(40);}
	set {
        setCell(40,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day042 {
	get { return getCellByIndex(41);}
	set {
        setCell(41,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day043 {
	get { return getCellByIndex(42);}
	set {
        setCell(42,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day044 {
	get { return getCellByIndex(43);}
	set {
        setCell(43,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day045 {
	get { return getCellByIndex(44);}
	set {
        setCell(44,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day046 {
	get { return getCellByIndex(45);}
	set {
        setCell(45,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day047 {
	get { return getCellByIndex(46);}
	set {
        setCell(46,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day048 {
	get { return getCellByIndex(47);}
	set {
        setCell(47,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day049 {
	get { return getCellByIndex(48);}
	set {
        setCell(48,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day050 {
	get { return getCellByIndex(49);}
	set {
        setCell(49,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day051 {
	get { return getCellByIndex(50);}
	set {
        setCell(50,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day052 {
	get { return getCellByIndex(51);}
	set {
        setCell(51,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day053 {
	get { return getCellByIndex(52);}
	set {
        setCell(52,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day054 {
	get { return getCellByIndex(53);}
	set {
        setCell(53,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day055 {
	get { return getCellByIndex(54);}
	set {
        setCell(54,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day056 {
	get { return getCellByIndex(55);}
	set {
        setCell(55,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day057 {
	get { return getCellByIndex(56);}
	set {
        setCell(56,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day058 {
	get { return getCellByIndex(57);}
	set {
        setCell(57,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day059 {
	get { return getCellByIndex(58);}
	set {
        setCell(58,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day060 {
	get { return getCellByIndex(59);}
	set {
        setCell(59,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day061 {
	get { return getCellByIndex(60);}
	set {
        setCell(60,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day062 {
	get { return getCellByIndex(61);}
	set {
        setCell(61,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day063 {
	get { return getCellByIndex(62);}
	set {
        setCell(62,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day064 {
	get { return getCellByIndex(63);}
	set {
        setCell(63,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day065 {
	get { return getCellByIndex(64);}
	set {
        setCell(64,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day066 {
	get { return getCellByIndex(65);}
	set {
        setCell(65,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day067 {
	get { return getCellByIndex(66);}
	set {
        setCell(66,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day068 {
	get { return getCellByIndex(67);}
	set {
        setCell(67,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day069 {
	get { return getCellByIndex(68);}
	set {
        setCell(68,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day070 {
	get { return getCellByIndex(69);}
	set {
        setCell(69,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day071 {
	get { return getCellByIndex(70);}
	set {
        setCell(70,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day072 {
	get { return getCellByIndex(71);}
	set {
        setCell(71,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day073 {
	get { return getCellByIndex(72);}
	set {
        setCell(72,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day074 {
	get { return getCellByIndex(73);}
	set {
        setCell(73,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day075 {
	get { return getCellByIndex(74);}
	set {
        setCell(74,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day076 {
	get { return getCellByIndex(75);}
	set {
        setCell(75,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day077 {
	get { return getCellByIndex(76);}
	set {
        setCell(76,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day078 {
	get { return getCellByIndex(77);}
	set {
        setCell(77,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day079 {
	get { return getCellByIndex(78);}
	set {
        setCell(78,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day080 {
	get { return getCellByIndex(79);}
	set {
        setCell(79,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day081 {
	get { return getCellByIndex(80);}
	set {
        setCell(80,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day082 {
	get { return getCellByIndex(81);}
	set {
        setCell(81,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day083 {
	get { return getCellByIndex(82);}
	set {
        setCell(82,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day084 {
	get { return getCellByIndex(83);}
	set {
        setCell(83,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day085 {
	get { return getCellByIndex(84);}
	set {
        setCell(84,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day086 {
	get { return getCellByIndex(85);}
	set {
        setCell(85,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day087 {
	get { return getCellByIndex(86);}
	set {
        setCell(86,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day088 {
	get { return getCellByIndex(87);}
	set {
        setCell(87,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day089 {
	get { return getCellByIndex(88);}
	set {
        setCell(88,value);
	}
}

[System.Runtime.Serialization.DataMember]
public
CellDemandDCompareReport Day090 {
	get { return getCellByIndex(89);}
	set {
        setCell(89,value);
	}
}


public
void setCell(int index,CellDemandDCompareReport cellNew){
    CellDemandDCompareReport cell = getCellByIndex(22);
    if (cell != cellNew){
        setCellByIndex(index, cell);
		Notify("Day" + (index+1).ToString("000"));
	}
}

[System.Runtime.Serialization.DataMember]
public
CellTitles CellTitles {
	get { return cellTitles; }
	set { if (this.cellTitles != value){
			this.cellTitles = value;
			Notify("CellTitles");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
ArrayList ArrayDays {
	get { return arrayDays;}
	set {
        arrayDays = value;
	}
}

public
void convertToNetQty(DemandDay demandDay,bool bqtyNew){    
    CellDemandDCompareReport    cellDemandDCompareReport        = null;    
    CellDemandDCompareReport    cellDemandDCompareReportPrior   = null;    
    bool                        bfound                          = false;
    decimal                     dqty                            = 0;
    decimal                     dpriorQty                       = 0;
    

    for (int i= ArrayDays.Count-1; i >=0; i--){
        cellDemandDCompareReport = (CellDemandDCompareReport)ArrayDays[i];

        dqty = bqtyNew ? cellDemandDCompareReport.QtyNew : cellDemandDCompareReport.QtyOld;
        if (dqty!= 0){
            bfound=false;
            for (int j=(i-1); j >=0 && !bfound; j--){
                cellDemandDCompareReportPrior = (CellDemandDCompareReport)ArrayDays[j];
                dpriorQty = bqtyNew ? cellDemandDCompareReportPrior.QtyNew : cellDemandDCompareReportPrior.QtyOld;
                if (dpriorQty != 0){
                    bfound=true;

                    if (bqtyNew)    cellDemandDCompareReport.QtyNew = dqty - dpriorQty;
                    else            cellDemandDCompareReport.QtyOld = dqty - dpriorQty;
                }      
            }      

            if (!bfound && demandDay!= null) {                
                if (bqtyNew)    cellDemandDCompareReport.QtyNew = dqty - demandDay.CumRequired;
                else            cellDemandDCompareReport.QtyOld = dqty - demandDay.CumRequired;
            }
        }
    }    
}

public
void copy(DemandDay demandDay){    
    this.LogNum = demandDay.LogNum;
    base.copy(demandDay);
}


public
void showFullCumulativeQty(bool bqtyNew){
    CellDemandDCompareReport    cellDemandDCompareReport        = null;    
    CellDemandDCompareReport    cellDemandDCompareReportPrior   = null;    
    bool                        bfound                          = false;
    decimal                     dqty                            = 0;
    decimal                     dpriorQty                       = 0;
    decimal                     dlastQty                        = 0;

    // 1  0  4 0 0 7 0 0
    
    for (int i= ArrayDays.Count-1; i >=0; i--){
        cellDemandDCompareReport = (CellDemandDCompareReport)ArrayDays[i];

        dqty = bqtyNew ? cellDemandDCompareReport.QtyNew : cellDemandDCompareReport.QtyOld;
        
        if (dqty== 0){
            bfound=false;
            for (int j=(i-1); j >=0 && !bfound; j--){//seach back for first qty filled
                cellDemandDCompareReportPrior = (CellDemandDCompareReport)ArrayDays[j];
                dpriorQty = bqtyNew ? cellDemandDCompareReportPrior.QtyNew : cellDemandDCompareReportPrior.QtyOld;
                if (dpriorQty != 0){
                    bfound=true;

                    dqty = dpriorQty;
                    if (bqtyNew)    cellDemandDCompareReport.QtyNew = dpriorQty;
                    else            cellDemandDCompareReport.QtyOld = dpriorQty;
                }      
            }                  
        }

        if (dqty!=0)
            dlastQty=dqty;
    }    

    //fill first recs where not qty filled
    bfound=false;
    for (int i=0; i < ArrayDays.Count && !bfound; i++){
        cellDemandDCompareReport = (CellDemandDCompareReport)ArrayDays[i];
        dqty = bqtyNew ? cellDemandDCompareReport.QtyNew : cellDemandDCompareReport.QtyOld;
        if (dqty == 0) { 
            if (bqtyNew)    cellDemandDCompareReport.QtyNew = dlastQty;
            else            cellDemandDCompareReport.QtyOld = dlastQty;
        }else
            bfound = true;            

    }         
}

} // class
} // package