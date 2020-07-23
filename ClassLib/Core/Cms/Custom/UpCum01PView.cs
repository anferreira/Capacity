/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core.Cms{

#if !POCKET_PC
    [System.Runtime.Serialization.DataContract(IsReference = true)]
#endif

public
class UpCum01PView : UpCum01P {

public const int IMAX_RECORDS_PROCESS=1000;

private string fEBTYP;
private string fESIND;
private string fGPART;
private string fGCPT;  
private decimal fGQSHP;
private decimal dDQTBI;
private decimal fGPCUM;

private string aVMAJG;
private string aVMING;
private string aVMAJS;
private string aVMINS;
private string aVGLCD;
private string aVGLED;
private string dCOTYP;
private string bVCLAS;
private decimal bVSLT;

private decimal qtyOrder;
private DateTime dCODAT;
private string fEFUTR;
private string fGRLNO;

private string custGroup;
private string dC4TMSP; //firsts dates on txt format
private string dC5TMSP;

private decimal dDQTOI;//firts qtys
private decimal dC5QTOO;

private DateTime dCQDAT; //request date

private string exportShow;
private DateTime exportDateShow;

private DateTime dC4QDAT;//request dates from oCRIT /oCRRT
private DateTime dC5QDAT;
private DateTime dC5SDAT;        

private string oCRITValues;
private string oCRITValuesAny;
private string oCRITValuesChange;

private string oCRRTValues;
private string oCRRTValuesAny;

private string sMTRPT;//trading partner
private string sMSTXL;
private string sMTRPT2;
private string sMTRPT3;
private string fGCPO;
private string included;
private DateTime lTBookDate;
private decimal lTBookQty;

private DateTime lastDateChange;
private DateTime lastQtyDateChange;
private decimal lastQtyChange;
private string shipExportSource;
private string ppap;
private string trlp;
private decimal dFQTOO;
private decimal dFQTYR;
private decimal qtyOrderOcrr;

private string releaseBase;
private decimal qtyOrdBase;
private DateTime fESTDATOtherOrder;
private string bOLOtherOrder;
private int actualDays;
private DateTime changeDate;

private ShipExport shipExport;


internal
UpCum01PView(): base(){
    this.fEBTYP="";
    this.fESIND="";
    this.fGPART="";
    this.fGCPT="";  
    this.fGQSHP=0;
    this.dDQTBI=0;
    this.fGPCUM=0;

    this.aVMAJG="";
    this.aVMING="";
    this.aVMAJS="";
    this.aVMINS="";
    this.aVGLCD="";
    this.aVGLED="";
    this.dCOTYP="";
    this.bVCLAS="";
    this.bVSLT = 0;                    
    this.qtyOrder = 0;
    this.dCODAT = DateUtil.MinValue;
    this.fEFUTR = "";
    this.fGRLNO = "";    
    this.custGroup="";

    this.dC4TMSP = "";
    this.dC5TMSP = "";

    this.dDQTOI = 0;
    this.dC5QTOO= 0;

    this.dCQDAT = DateUtil.MinValue;
    this.dC4QDAT= DateUtil.MinValue;
    this.dC5QDAT= DateUtil.MinValue;
    this.dC5SDAT= DateUtil.MinValue;

    this.oCRITValues    = "";
    this.oCRITValuesAny = "";
    this.oCRITValuesChange = "";
    this.oCRRTValues    = "";
    this.oCRRTValuesAny = "";

    this.sMTRPT = "";
    this.sMSTXL = "";
    this.sMTRPT2= "";
    this.sMTRPT3= "";
    this.fGCPO  = "";
    this.included = Constants.STRING_YES;

    this.lTBookDate = DateUtil.MinValue;
    this.lTBookQty  = 0;

    this.exportShow = Constants.STRING_NO;
    this.exportDateShow = DateUtil.MinValue;    
            
    this.lastDateChange = DateUtil.MinValue;
    this.lastQtyDateChange = DateUtil.MinValue;
    this.lastQtyChange = 0;             
    this.shipExportSource = Constants.STRING_NO;    
    this.ppap = Constants.STRING_NO;   
    this.trlp = Constants.STRING_NO;
    this.dFQTOO = 0;
    this.dFQTYR = 0;
    this.qtyOrderOcrr = 0;

    this.releaseBase = "";
    this.qtyOrdBase = 0;
    this.fESTDATOtherOrder  = DateUtil.MinValue;
    this.bOLOtherOrder      = "";
    this.actualDays         = 0;
    this.changeDate         = DateUtil.MinValue;
    this.shipExport         = null;
}
        
[System.Runtime.Serialization.DataMember]
public
string FEBTYP {
	get { return fEBTYP;}
	set { if (this.fEBTYP != value){
			this.fEBTYP = value;
			Notify("FEBTYP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FESIND {
	get { return fESIND;}
	set { if (this.fESIND != value){
			this.fESIND = value;
			Notify("FESIND");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGPART {
	get { return fGPART;}
	set { if (this.fGPART != value){
			this.fGPART = value;
			Notify("FGPART");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGCPT {
	get { return fGCPT;}
	set { if (this.fGCPT != value){
			this.fGCPT = value;
			Notify("FGCPT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGQSHP {
	get { return fGQSHP; }
	set { if (this.fGQSHP != value){
			this.fGQSHP = value;
			Notify("FGQSHP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal DDQTBI {
	get { return dDQTBI; }
	set { if (this.dDQTBI != value){
			this.dDQTBI = value;
			Notify("DDQTBI");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal FGPCUM
        {
	get { return fGPCUM; }
	set { if (this.fGPCUM != value){
			this.fGPCUM = value;
			Notify("FGPCUM");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
string AVMAJG {
	get { return aVMAJG; }
	set { if (this.aVMAJG != value){
			this.aVMAJG = value;
			Notify("AVMAJG");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string AVMING {
	get { return aVMING; }
	set { if (this.aVMING != value){
			this.aVMING = value;
			Notify("AVMING");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string AVMAJS {
	get { return aVMAJS; }
	set { if (this.aVMAJS != value){
			this.aVMAJS = value;
			Notify("AVMAJS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string AVMINS {
	get { return aVMINS; }
	set { if (this.aVMINS != value){
			this.aVMINS = value;
			Notify("AVMINS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string AVGLCD {
	get { return aVGLCD; }
	set { if (this.aVGLCD != value){
			this.aVGLCD = value;
			Notify("AVGLCD");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string AVGLED {
	get { return aVGLED; }
	set { if (this.aVGLED != value){
			this.aVGLED = value;
			Notify("AVGLED");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string DCOTYP {
	get { return dCOTYP; }
	set { if (this.dCOTYP != value){
			this.dCOTYP = value;
			Notify("DCOTYP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BVCLAS {
	get { return bVCLAS; }
	set { if (this.bVCLAS != value){
			this.bVCLAS = value;
			Notify("BVCLAS");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal BVSLT {
	get { return bVSLT; }
	set { if (this.bVSLT != value){
			this.bVSLT = value;
			Notify("BVSLT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyOrder {
	get { return qtyOrder; }
	set { if (this.qtyOrder != value){
			this.qtyOrder = value;
			Notify("QtyOrder");
            Notify("QtyBack");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime DCODAT {
	get { return dCODAT; }
	set { if (this.dCODAT != value){
			this.dCODAT = value;
			Notify("DCODAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FEFUTR {
	get { return fEFUTR; }
	set { if (this.fEFUTR != value){
			this.fEFUTR = value;
			Notify("FEFUTR");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGRLNO {
	get { return fGRLNO; }
	set { if (this.fGRLNO != value){
			this.fGRLNO = value;
			Notify("FGRLNO");
		}
	}
}

public
string FEFUTRShow {
	get { 
        string sret = "";
        try { 
            if (!string.IsNullOrEmpty(FEFUTR) && FEFUTR.Length >=8) { 
                    sret = FEFUTR.Substring(0,8);

                    string[]sitems = FEFUTR.Split('/');
                    if (sitems.Length > 2) {             
                        string syear=  DateTime.Now.Year.ToString().Substring(0,2) + sitems[0];
                        sitems[0] = syear;
                        sret =  sitems[1] + "/" + (sitems[2].Length >=2 ? sitems[2].Substring(0,2):"") + "/"+ syear ;
                    }        
              }
         }catch{ };

         return sret;
    }set {
		
	}
}   


[System.Runtime.Serialization.DataMember]
public
string CustGroup {
	get { return custGroup; }
	set { if (this.custGroup != value){
			this.custGroup = value;
			Notify("CustGroup");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
string DC4TMSP {
	get { return dC4TMSP; }
	set { if (this.dC4TMSP != value){
			this.dC4TMSP = value;
			Notify("DC4TMSP");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string DC5TMSP {
	get { return dC5TMSP; }
	set { if (this.dC5TMSP != value){
			this.dC5TMSP = value;
			Notify("dC5TMSP");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
DateTime DCQDAT {
	get { return dCQDAT; }
	set { if (this.dCQDAT != value){
			this.dCQDAT = value;
			Notify("DCQDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime DC4QDAT {
	get { return dC4QDAT; }
	set { if (this.dC4QDAT != value){
			this.dC4QDAT = value;
			Notify("DC4QDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime DC5QDAT {
	get { return dC5QDAT; }
	set { if (this.dC5QDAT != value){
			this.dC5QDAT = value;
			Notify("dC5QDAT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime DC5SDAT {
	get { return dC5SDAT; }
	set { if (this.dC5SDAT != value){
			this.dC5SDAT = value;
			Notify("DC5SDAT");
		}
	}
}

public
DateTime FirstDate{
	get { 
        string      sret    = DCOTYP.Equals("B") ? DC5TMSP : DC4TMSP;
        DateTime    dateRet = DateUtil.MinValue;
        try { 
            checkIfBillToOrdDateSameDateReq(out dateRet);

            if (dateRet == DateUtil.MinValue) {             
                //2020-03-02-05.26.24.308000
                if (!string.IsNullOrEmpty(sret) && sret.Length >=10) {               
                    string[]sitems = sret.Split('-');//split 
                    if (sitems.Length <= 1)
                        sitems = sret.Split('/');

                    if (sitems.Length > 2)
                        dateRet = new DateTime( Convert.ToInt32(sitems[0]), Convert.ToInt32(sitems[1]), Convert.ToInt32(sitems[2].Substring(0,2)));                            
                  }
            }
         }catch{ };

         return dateRet;
    }set {
		
	}
}  

[System.Runtime.Serialization.DataMember]
public
decimal DDQTOI {
	get { return dDQTOI; }
	set { if (this.dDQTOI != value){
			this.dDQTOI = value;
			Notify("DDQTOI");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
decimal DC5QTOO {
	get { return dC5QTOO; }
	set { if (this.dC5QTOO != value){
			this.dC5QTOO = value;
			Notify("DC5QTOO");
		}
	}
}
  
public
decimal FirstQty{
	get { 
        return DCOTYP.Equals("B") ? DC5QTOO : DDQTOI;        
    }set {
		
	}
} 
      
public
decimal QtyBack{
	get {
        decimal qtyBack = QtyOrder - FGQSHP;
        if (qtyBack < 0)
            qtyBack =0;

        return qtyBack;            
    }set {
		
	}
} 

public
int DayLate{
	get {
        int idayLate=0;
        try { 
            if (FESDAT > UPEXSD && UPEXSD > DateUtil.MinValue){
                idayLate = Convert.ToInt32((FESDAT - UPEXSD).TotalDays);
            }
        }catch{ };

        return idayLate;            
    }set {
		
	}
} 

[System.Runtime.Serialization.DataMember]
public
string ExportShow {
	get { return exportShow; }
	set { if (this.exportShow != value){
			this.exportShow = value;
			Notify("ExportShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime ExportDateShow {
	get { return exportDateShow; }
	set { if (this.exportDateShow != value){
			this.exportDateShow = value;
			Notify("ExportDateShow");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OCRITValues {
	get { return oCRITValues; }
	set { if (this.oCRITValues != value){
			this.oCRITValues = value;
			Notify("OCRITValues");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OCRITValuesAny {
	get { return oCRITValuesAny; }
	set { if (this.oCRITValuesAny != value){
			this.oCRITValuesAny = value;
			Notify("OCRITValuesAny");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OCRITValuesChange{
	get { return oCRITValuesChange; }
	set { if (this.oCRITValuesChange != value){
			this.oCRITValuesChange = value;
			Notify("OCRITValuesChange");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OCRRTValues {
	get { return oCRRTValues; }
	set { if (this.oCRRTValues != value){
			this.oCRRTValues = value;
			Notify("OCRRTValues");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string OCRRTValuesAny {
	get { return oCRRTValuesAny; }
	set { if (this.oCRRTValuesAny != value){
			this.oCRRTValuesAny = value;
			Notify("OCRRTValuesAny");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string SMTRPT {
	get { return sMTRPT; }
	set { if (this.sMTRPT != value){
			this.sMTRPT = value;
			Notify("SMTRPT");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string SMSTXL {
	get { return sMSTXL; }
	set { if (this.sMSTXL != value){
			this.sMSTXL = value;
			Notify("SMSTXL");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string SMTRPT2 {
	get { return sMTRPT2; }
	set { if (this.sMTRPT2 != value){
			this.sMTRPT2 = value;
			Notify("SMTRPT2");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string SMTRPT3 {
	get { return sMTRPT3; }
	set { if (this.sMTRPT3 != value){
			this.sMTRPT3 = value;
			Notify("SMTRPT3");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string FGCPO {
	get { return fGCPO; }
	set { if (this.fGCPO != value){
			this.fGCPO = value;
			Notify("FGCPO");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Included {
	get { return included; }
	set { if (this.included != value){
			this.included = value;
			Notify("Included");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime LTBookDate {
	get { return lTBookDate; }
	set { if (this.lTBookDate != value){
			this.lTBookDate = value;
			Notify("LTBookDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal LTBookQty {
	get { return lTBookQty; }
	set { if (this.lTBookQty != value){
			this.lTBookQty = value;
			Notify("LTBookQty");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime LastDateChange {
	get { return lastDateChange; }
	set { if (this.lastDateChange != value){
			this.lastDateChange = value;
			Notify("LastDateChange");
		}
	}
}


[System.Runtime.Serialization.DataMember]
public
DateTime LastQtyDateChange {
	get { return lastQtyDateChange; }
	set { if (this.lastQtyDateChange != value){
			this.lastQtyDateChange = value;
			Notify("LastQtyDateChange");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal LastQtyChange {
	get { return lastQtyChange; }
	set { if (this.lastQtyChange != value){
			this.lastQtyChange = value;
			Notify("LastQtyChange");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ShipExportSource {
	get { return shipExportSource;}
	set { if (this.shipExportSource != value){
			this.shipExportSource = value;
			Notify("ShipExportSource");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Ppap {
	get { return ppap;}
	set { if (this.ppap != value){
			this.ppap = value;
			Notify("Ppap");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string Trlp {
	get { return trlp; }
	set { if (this.trlp != value){
			this.trlp = value;
			Notify("Trlp");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal DFQTOO {
	get { return dFQTOO; }
	set { if (this.dFQTOO != value){
			this.dFQTOO = value;
			Notify("DFQTOO");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal DFQTYR {
	get { return dFQTYR; }
	set { if (this.dFQTYR != value){
			this.dFQTYR = value;
			Notify("DFQTYR");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyOrderOcrr {
	get { return qtyOrderOcrr; }
	set { if (this.qtyOrderOcrr != value){
			this.qtyOrderOcrr = value;
			Notify("QtyOrderOcrr");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string ReleaseBase {
	get { return releaseBase; }
	set { if (this.releaseBase != value){
			this.releaseBase = value;
			Notify("ReleaseBase");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
decimal QtyOrdBase {
	get { return qtyOrdBase; }
	set { if (this.qtyOrdBase != value){
			this.qtyOrdBase = value;
			Notify("QtyOrdBase");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime FESTDATOtherOrder {
	get { return fESTDATOtherOrder; }
	set { if (this.fESTDATOtherOrder != value){
			this.fESTDATOtherOrder = value;
			Notify("FESTDATOtherOrder");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
string BOLOtherOrder {
	get { return bOLOtherOrder; }
	set { if (this.bOLOtherOrder != value){
			this.bOLOtherOrder = value;
			Notify("BOLOtherOrder");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
int ActualDays {
	get { return actualDays; }
	set { if (this.actualDays != value){
			this.actualDays = value;
			Notify("ActualDays");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
DateTime ChangeDate {
	get { return changeDate; }
	set { if (this.changeDate != value){
			this.changeDate = value;
			Notify("ChangeDate");
		}
	}
}

[System.Runtime.Serialization.DataMember]
public
ShipExport ShipExport {
	get { return shipExport;
    } set { 
		this.shipExport = value;
        Notify("ShipExport");		
	}
}

public
DateTime CustDate{
	get {
        DateTime date = DCOTYP.Equals("B") ? DC5QDAT : DC4QDAT;
        return date;
    }set {
		
	}
} 

public
bool searchByDateLoadLTBookQty(){
    bool    bresult=false;
    try { 
        LTBookQty = QtyOrder;//initialize
        
        for (int i=0; i < shipExportDtlContainer.Count && !bresult; i++){
            ShipExportDtl shipExportDtl = shipExportDtlContainer[i];

            DateTime dateTimeStamp = DateUtil.parseDateFromStringAS400(shipExportDtl.TimeStamp);            
            if (dateTimeStamp <= DateUtil.highHour(LTBookDate)){ 
                LTBookQty = shipExportDtl.RelQtyInvUnit;
                if (DateUtil.sameDate(LTBookDate, dateTimeStamp))                
                    bresult =true;
            }
        }

    }catch{ };

    return bresult;
}

public
void fillRedundances(){    	
    ShipExportDtlContainer.fillDetails();
    ShipExportReleaseContainer.fillDetails();

    if (LastDateChange == DateUtil.MinValue) // last date change not found, fill created date by default
        LastDateChange = FirstDate;
    if (LastQtyDateChange == DateUtil.MinValue) // last date qty change not found, fill created date by default
        LastQtyDateChange = FirstDate;    
}

public
void checkIfBillToOrdDateSameDateReq(out DateTime dateOut){
    dateOut = DateUtil.MinValue;
    if (Configuration.valueInList(FEBCS, Configuration.DataTransBillToOrdDateSameDateReq))                
        dateOut = UPEXSD;    
}

} // class
} // package