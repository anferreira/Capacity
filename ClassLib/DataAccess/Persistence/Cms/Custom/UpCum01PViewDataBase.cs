/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using MySql.Data;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.UtilDB;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms{

public
class UpCum01PViewDataBase : UpCum01PDataBase {

private string FEBTYP;
private string FESIND;
private string FGPART;
private string FGCPT;  
private decimal FGQSHP;
private decimal DDQTBI;
private decimal FGPCUM;

private string AVMAJG;
private string AVMING;
private string AVMAJS;
private string AVMINS;
private string AVGLCD;
private string AVGLED;
private string DCOTYP;
private string BVCLAS;
private decimal BVSLT;
private DateTime DCODAT;//create date

private decimal QtyOrder;
private string  FEFUTR; //post date , string format 20/05/05143920
private string FGRLNO;
private string DC4TMSP; //first dates, string format
private string DC5TMSP;

private decimal DDQTOI; //first qtys
private decimal DC5QTOO;
private DateTime DC5SDAT;

private DateTime DCQDAT; //request date

private string OCRITValues;
private string OCRITValuesAny;
private string OCRITValuesChange;
private string OCRRTValues;
private string OCRRTValuesAny;

private string SMTRPT;//trading partner, this is priority
private string SMTRPT2;//trading partner 2 , just in case
private string SMTRPT3;//trading partner 3 , just in case        
private string SMSTXL;

private string FGCPO;
private string Ppap;
private decimal DFQTOO;
private decimal DFQTYR;
private decimal QtyOrderOcrr;
private DateTime FESTDATOtherOrder;
private string BOLOtherOrder;

public
UpCum01PViewDataBase(DataBaseAccess dataBaseAccess) : base(dataBaseAccess){}

public override
void load(NotNullDataReader reader){
    base.load(reader);
    try { this.FEBTYP = reader.GetString("FEBTYP"); }catch{};
    this.FESIND= reader.GetString("FESIND");
    try { this.FGPART = reader.GetString("FGPART"); }catch{};   
    try { this.FGCPT = reader.GetString("FGCPT#"); }catch{};
    try { this.FGQSHP = reader.GetDecimal("FGQSHP"); }catch{};

    try { this.DDQTBI= reader.GetDecimal("DDQTBI"); }catch{};//qty back order std
    try { this.FGPCUM = reader.GetDecimal("FGPCUM"); }catch{};

    try { this.AVMAJG = reader.GetString("AVMAJG"); }catch{};
    try { this.AVMING = reader.GetString("AVMING"); }catch{};
    try { this.AVMAJS = reader.GetString("AVMAJS"); }catch{};
    try { this.AVMINS = reader.GetString("AVMINS"); }catch{};
    try { this.AVGLCD = reader.GetString("AVGLCD"); }catch{};
    try { this.AVGLED = reader.GetString("AVGLED"); }catch{};

    try { this.DCOTYP = reader.GetString("DCOTYP"); }catch{};
    try { this.BVCLAS = reader.GetString("BVCLAS"); }catch{};
    try { this.BVSLT  = reader.GetDecimal("BVSLT"); }catch{};

    try { this.QtyOrder = reader.GetDecimal("QtyOrder"); }catch{};
    try { this.DCODAT = reader.GetDateTime("DCODAT"); }catch{};   
    try { this.FEFUTR = reader.GetString("FEFUTR"); }catch{};
    try { this.FGRLNO = reader.GetString("FGRLNO"); }catch{}; //release 

    try { this.DC4TMSP = reader.GetString("DC4TMSP"); }catch{ DC4TMSP = "";};//date for std and blanket
    try { this.DC5TMSP = reader.GetString("DC5TMSP"); }catch{ DC5TMSP = "";};

    try { this.DDQTOI = reader.GetDecimal("DDQTOI"); }catch{ DDQTOI =0;};   //firsts qtys

    try {
        DC5QTOO = decimal.MinValue;
        if (!reader.isNull("DC5QTOO")) 
            this.DC5QTOO = reader.GetDecimal("DC5QTOO");
    } catch{ DC5QTOO = decimal.MinValue;};

    try {
        if (DC5QTOO == decimal.MinValue) 
            DC5QTOO =  reader.GetDecimal("DC5QTOO2");
    }catch { DC5QTOO = decimal.MinValue; };

     try {
        DC5SDAT = DateUtil.MinValue;            //date request closer to post date
        if (!reader.isNull("DC5SDAT")) 
            this.DC5SDAT = reader.GetDateTime("DC5SDAT");
    } catch{ DC5SDAT = DateUtil.MinValue; };
            

    try { this.DCQDAT = reader.GetDateTime("DCQDAT"); }catch{ DCQDAT = DateUtil.MinValue;};
            
    //request date
    DateTime DFSDAT=DateUtil.MinValue;// blanket
    DateTime DDSDAT = DateUtil.MinValue;//standard order
    try { DFSDAT = reader.GetDateTime("DFSDAT"); }catch{};   
    try { DDSDAT = reader.GetDateTime("DDSDAT"); }catch{};

    setUPEXSD(DDSDAT);
    if (!string.IsNullOrEmpty(DCOTYP) && DCOTYP.Trim().Equals("B")) { //blanket
        try { this.QtyOrder = reader.GetDecimal("DFQTYR"); }catch{}; 
        this.QtyOrder = DC5QTOO; //for now we use qty from OCRRT
        setUPEXSD(DFSDAT);

       try { this.DDQTBI = reader.GetDecimal("DFQTBO"); }catch{};  //qty back order
    }
            
    try { OCRITValues   = reader.GetString("OCRITValues");      }catch{ OCRITValues = "";};
    try { OCRITValuesAny= reader.GetString("OCRITValuesAny");   }catch{ OCRITValuesAny = "";};
    try { OCRITValuesChange = reader.GetString("OCRITValuesChange");   }catch{ OCRITValuesChange = "";};            
    try { OCRRTValues   = reader.GetString("OCRRTValues");      }catch{ OCRRTValues = "";};   
    try { OCRRTValuesAny= reader.GetString("OCRRTValuesAny");   }catch{ OCRRTValuesAny = "";};         

    try { SMTRPT = reader.GetString("SMTRPT");  }catch{ SMTRPT = "";};   
    try { SMSTXL = reader.GetString("SMSTXL");  }catch{ SMSTXL = "";};
    try { SMTRPT2= reader.GetString("SMTRPT2"); }catch{ SMTRPT2= "";};   
    try { SMTRPT3= reader.GetString("SMTRPT3"); }catch{ SMTRPT3 = "";};   

    try { FGCPO = reader.GetString("FGCPO#");   }catch{ FGCPO = "";};     
    try { Ppap = reader.GetString("Ppap");
          Ppap = string.IsNullOrEmpty(Ppap) ? Constants.STRING_NO : Ppap;
    } catch{ Ppap = Constants.STRING_NO;};     

    try {
        DFQTOO = decimal.MinValue; //assume null
        if (!reader.isNull("DFQTOO"))
            DFQTOO = reader.GetDecimal("DFQTOO");
    } catch { DFQTOO = decimal.MinValue;};       

    try {
        DFQTYR = decimal.MinValue; //assume null
        if (!reader.isNull("DFQTYR"))
            DFQTYR = reader.GetDecimal("DFQTYR");
    } catch { DFQTYR = decimal.MinValue;};   

    try {
        QtyOrderOcrr = decimal.MinValue; //assume null
        if (!reader.isNull("QtyOrderOcrr"))
            QtyOrderOcrr = reader.GetDecimal("QtyOrderOcrr");
    } catch { QtyOrderOcrr = decimal.MinValue;};                 
            
    try {
        FESTDATOtherOrder = DateUtil.MinValue; //assume null
        if (!reader.isNull("FESTDATOtherOrder"))
            FESTDATOtherOrder = reader.GetDateTime("FESTDATOtherOrder");
    } catch { FESTDATOtherOrder = DateUtil.MinValue;};        
            

    try {
        BOLOtherOrder = ""; //assume null
        if (!reader.isNull("BOLOtherOrder"))
            BOLOtherOrder = reader.GetString("BOLOtherOrder");
    } catch { BOLOtherOrder = "";}; 
                                               
}

public override
void write(){
    throw new PersistenceException("write Function not enabled");    
}

public override
void update(){
    throw new PersistenceException("update Function not enabled");    
}

public override
void delete(){
   throw new PersistenceException("delete Function not enabled");    
}

public 
string getFEBTYP(){
   return FEBTYP;
}

public 
string getFESIND(){
   return FESIND;
}


public 
string getFGPART(){
   return FGPART;
}

public 
string getFGCPT(){
   return FGCPT;
}

public 
decimal getFGQSHP(){
   return FGQSHP;
}

public 
decimal getDDQTBI(){
   return DDQTBI;
}

public 
decimal getFGPCUM(){
   return FGPCUM;
}

public
string getAVMAJG(){
	return AVMAJG;
}

public
string getAVMING(){
	return AVMING;
}
 
public
string getAVMAJS(){
	return AVMAJS;
}

public
string getAVMINS(){
	return AVMINS;
}

public
string getAVGLCD(){
	return AVGLCD;
}

public
string getAVGLED(){
	return AVGLED;
}

public
string getDCOTYP(){
	return DCOTYP;
}

public
string getBVCLAS(){
	return BVCLAS;
}

public
decimal getBVSLT(){
	return BVSLT;
}

public
decimal getQtyOrder(){
	return QtyOrder;
}

public
DateTime getDCODAT(){
	return DCODAT;
}

public
string getFEFUTR(){
	return FEFUTR;
}

public
string getFGRLNO(){
	return FGRLNO;
}

public
string getDC4TMSP(){
	return DC4TMSP;
}

public
string getDC5TMSP(){
	return DC5TMSP;
}

public
decimal getDDQTOI(){
	return DDQTOI;
}

public
decimal getDC5QTOO(){
	return DC5QTOO;
}

public
DateTime getDCQDAT(){
	return DCQDAT;
}

public
string getOCRITValues(){
	return OCRITValues;
}

public
string getOCRITValuesAny(){
	return OCRITValuesAny;
}

public
string getOCRITValuesChange(){
	return OCRITValuesChange;
}
        
public
string getOCRRTValues(){
	return OCRRTValues;
}

public
string getOCRRTValuesAny(){
	return OCRRTValuesAny;
}

public
string getSMTRPT(){
	return SMTRPT;
}

public
string getSMSTXL(){
	return SMSTXL;
}      

public
string getSMTRPT2(){
	return SMTRPT2;
}

public
string getSMTRPT3(){
	return SMTRPT3;
}
  
public
string getFGCPO(){
	return FGCPO;
}          

public
string getPpap(){
	return Ppap;
}                        
     
public
decimal getDFQTOO(){
	return DFQTOO;
}    

public
decimal getDFQTYR(){
	return DFQTYR;
}  
       
public
decimal getQtyOrderOcrr(){
	return QtyOrderOcrr;
}          

public
DateTime getFESTDATOtherOrder(){
	return FESTDATOtherOrder;
}
         
public
string getBOLOtherOrder(){
	return BOLOtherOrder;
}
    
public
DateTime getDC5SDAT(){
	return DC5SDAT;
}

                              

} // class
} // package