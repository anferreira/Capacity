using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Customer;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms.PackSlip;
using Nujit.NujitERP.ClassLib.Core.Customer;


namespace Nujit.NujitERP.ClassLib.Core.Util{


public
class CmsCustomCoreFactory : CmsCoreFactory{

protected
CmsCustomCoreFactory() : base(){
}

public
UpCum01P createUpCum01P(){
	return new UpCum01P();
}

public
UpCum01PContainer createUpCum01PContainer(){
	return new UpCum01PContainer();
}

public
UpCum01PViewContainer createUpCum01PViewContainer(){
	return new UpCum01PViewContainer();
}

public
bool existsUpCum01P(decimal fGBOL, decimal fGENT){
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);  

		UpCum01PDataBase upCum01PDataBase = new UpCum01PDataBase(dataBaseAccess);

		upCum01PDataBase.setFGBOL(fGBOL);
		upCum01PDataBase.setFGENT(fGENT);

		return upCum01PDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);  
    }
}

public
UpCum01P readUpCum01P(decimal fGBOL, decimal fGENT){
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);  

		UpCum01PDataBase upCum01PDataBase = new UpCum01PDataBase(dataBaseAccess);
		upCum01PDataBase.setFGBOL(fGBOL);
		upCum01PDataBase.setFGENT(fGENT);

		if (!upCum01PDataBase.read())
			return null;

		UpCum01P upCum01P = this.objectDataBaseToObject(upCum01PDataBase);

		return upCum01P;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);  
    }
}

public 
void updateUpCum01P(UpCum01P upCum01P){
	try{

        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);  
		
		UpCum01PDataBase upCum01PDataBase = this.objectToObjectDataBase(upCum01P);
		upCum01PDataBase.update();

		
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);  
    }
}

public 
void writeUpCum01P(UpCum01P upCum01P){
	try{
		
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);  

		UpCum01PDataBase upCum01PDataBase = this.objectToObjectDataBase(upCum01P);
		upCum01PDataBase.write();

		
	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);  
    }
}

public
void deleteUpCum01P(decimal fGBOL, decimal fGENT){
	try{		
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);  

		UpCum01PDataBase upCum01PDataBase = new UpCum01PDataBase(dataBaseAccess);

		upCum01PDataBase.setFGBOL(fGBOL);
		upCum01PDataBase.setFGENT(fGENT);
		upCum01PDataBase.delete();

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);  
    }
}

private
UpCum01P objectDataBaseToObject(UpCum01PDataBase upCum01PDataBase){
	UpCum01P upCum01P = new UpCum01P();
    objectDataBaseToObject(upCum01PDataBase,upCum01P);

	return upCum01P;
}


private
UpCum01PView objectDataBaseToObject(UpCum01PViewDataBase upCum01PViewDataBase){
	UpCum01PView upCum01PView = new UpCum01PView();
    objectDataBaseToObject(upCum01PViewDataBase, upCum01PView);

    upCum01PView.FEBTYP = upCum01PViewDataBase.getFEBTYP();
    upCum01PView.FESIND = upCum01PViewDataBase.getFESIND();
    upCum01PView.FGPART = upCum01PViewDataBase.getFGPART();
    upCum01PView.FGCPT  = upCum01PViewDataBase.getFGCPT();   
    upCum01PView.FGQSHP = upCum01PViewDataBase.getFGQSHP();   
    upCum01PView.DDQTBI = upCum01PViewDataBase.getDDQTBI();   
    upCum01PView.FGPCUM = upCum01PViewDataBase.getFGPCUM();   

    upCum01PView.AVMAJG = upCum01PViewDataBase.getAVMAJG();
    upCum01PView.AVMING = upCum01PViewDataBase.getAVMING();
    upCum01PView.AVMAJS = upCum01PViewDataBase.getAVMAJS();
    upCum01PView.AVMINS = upCum01PViewDataBase.getAVMINS();
    upCum01PView.AVGLCD = upCum01PViewDataBase.getAVGLCD();
    upCum01PView.AVGLED = upCum01PViewDataBase.getAVGLED();
    upCum01PView.DCOTYP = upCum01PViewDataBase.getDCOTYP();
    upCum01PView.BVCLAS = upCum01PViewDataBase.getBVCLAS();
    upCum01PView.BVSLT  = upCum01PViewDataBase.getBVSLT();            
    upCum01PView.QtyOrder= upCum01PViewDataBase.getQtyOrder();
    upCum01PView.DCODAT = upCum01PViewDataBase.getDCODAT();
    upCum01PView.FEFUTR = upCum01PViewDataBase.getFEFUTR();
    upCum01PView.FGRLNO = upCum01PViewDataBase.getFGRLNO();

    upCum01PView.DC4TMSP = upCum01PViewDataBase.getDC4TMSP();
    upCum01PView.DC5TMSP = upCum01PViewDataBase.getDC5TMSP();

    upCum01PView.DDQTOI = upCum01PViewDataBase.getDDQTOI();
    upCum01PView.DC5QTOO= upCum01PViewDataBase.getDC5QTOO();

    upCum01PView.DCQDAT= upCum01PViewDataBase.getDCQDAT();
            
    upCum01PView.OCRITValues    = upCum01PViewDataBase.getOCRITValues();
    upCum01PView.OCRITValuesAny = upCum01PViewDataBase.getOCRITValuesAny();
    upCum01PView.OCRITValuesChange = upCum01PViewDataBase.getOCRITValuesChange();
    upCum01PView.OCRRTValues    = upCum01PViewDataBase.getOCRRTValues();
    upCum01PView.OCRRTValuesAny = upCum01PViewDataBase.getOCRRTValuesAny();

    upCum01PView.SMTRPT         = upCum01PViewDataBase.getSMTRPT();
    upCum01PView.SMSTXL         = upCum01PViewDataBase.getSMSTXL();
    upCum01PView.SMTRPT2        = upCum01PViewDataBase.getSMTRPT2();
    upCum01PView.SMTRPT3        = upCum01PViewDataBase.getSMTRPT3();
    upCum01PView.FGCPO          = upCum01PViewDataBase.getFGCPO();
    upCum01PView.Ppap           = upCum01PViewDataBase.getPpap();
    upCum01PView.DFQTOO         = upCum01PViewDataBase.getDFQTOO();
    upCum01PView.DFQTYR         = upCum01PViewDataBase.getDFQTYR();
    upCum01PView.QtyOrderOcrr   = upCum01PViewDataBase.getQtyOrderOcrr();
    upCum01PView.FESTDATOtherOrder = upCum01PViewDataBase.getFESTDATOtherOrder();
    upCum01PView.BOLOtherOrder  = upCum01PViewDataBase.getBOLOtherOrder();

    upCum01PView.DC5SDAT        = upCum01PViewDataBase.getDC5SDAT();//date request from 

    return upCum01PView;
}


private
UpCum01P objectDataBaseToObject(UpCum01PDataBase upCum01PDataBase, UpCum01P upCum01P){	
	upCum01P.FGBOL=upCum01PDataBase.getFGBOL();
	upCum01P.FEBCS=upCum01PDataBase.getFEBCS();
	upCum01P.FESCS=upCum01PDataBase.getFESCS();
	upCum01P.FGENT=upCum01PDataBase.getFGENT();
	upCum01P.FGORD=upCum01PDataBase.getFGORD();
	upCum01P.FGITEM=upCum01PDataBase.getFGITEM();
	upCum01P.FGCREL=upCum01PDataBase.getFGCREL();
	upCum01P.FEPLTC=upCum01PDataBase.getFEPLTC();
	upCum01P.FECDAT=upCum01PDataBase.getFECDAT();
	upCum01P.FESDAT=upCum01PDataBase.getFESDAT();
	upCum01P.FGRAN=upCum01PDataBase.getFGRAN();
	upCum01P.PYRAN=upCum01PDataBase.getPYRAN();
	upCum01P.USERAN=upCum01PDataBase.getUSERAN();
	upCum01P.FGCCUM=upCum01PDataBase.getFGCCUM();
	upCum01P.SMCKEY=upCum01PDataBase.getSMCKEY();
	upCum01P.SMRDAT=upCum01PDataBase.getSMRDAT();
	upCum01P.SPLDAT=upCum01PDataBase.getSPLDAT();
	upCum01P.SPTRPT=upCum01PDataBase.getSPTRPT();
	upCum01P.TPLOC=upCum01PDataBase.getTPLOC();
	upCum01P.SPOEMC=upCum01PDataBase.getSPOEMC();
	upCum01P.SPOEMS=upCum01PDataBase.getSPOEMS();
	upCum01P.SPOEMD=upCum01PDataBase.getSPOEMD();
	upCum01P.UPEXSD=upCum01PDataBase.getUPEXSD();
	upCum01P.UPEXNQ=upCum01PDataBase.getUPEXNQ();
	upCum01P.EXDATE=upCum01PDataBase.getEXDATE();
	upCum01P.JITCUM=upCum01PDataBase.getJITCUM();
	upCum01P.PRDATE=upCum01PDataBase.getPRDATE();
	upCum01P.PRDCUM=upCum01PDataBase.getPRDCUM();
	upCum01P.NEDATE=upCum01PDataBase.getNEDATE();
	upCum01P.NEDCUM=upCum01PDataBase.getNEDCUM();
	upCum01P.RANFDAT=upCum01PDataBase.getRANFDAT();
	upCum01P.RANFQTY=upCum01PDataBase.getRANFQTY();
	upCum01P.RANDAT=upCum01PDataBase.getRANDAT();
	upCum01P.RANQTY=upCum01PDataBase.getRANQTY();
	upCum01P.OZTRPT=upCum01PDataBase.getOZTRPT();
	upCum01P.PLPRDA=upCum01PDataBase.getPLPRDA();
	upCum01P.PLPCUM=upCum01PDataBase.getPLPCUM();
	upCum01P.PLNRDA=upCum01PDataBase.getPLNRDA();
	upCum01P.PLNCUM=upCum01PDataBase.getPLNCUM();
	upCum01P.PLRDAT=upCum01PDataBase.getPLRDAT();
	upCum01P.RRLCUM=upCum01PDataBase.getRRLCUM();
    
	return upCum01P;
}

private
UpCum01PDataBase objectToObjectDataBase(UpCum01P upCum01P){
	UpCum01PDataBase upCum01PDataBase = new UpCum01PDataBase(dataBaseAccess);
	upCum01PDataBase.setFGBOL(upCum01P.FGBOL);
	upCum01PDataBase.setFEBCS(upCum01P.FEBCS);
	upCum01PDataBase.setFESCS(upCum01P.FESCS);
	upCum01PDataBase.setFGENT(upCum01P.FGENT);
	upCum01PDataBase.setFGORD(upCum01P.FGORD);
	upCum01PDataBase.setFGITEM(upCum01P.FGITEM);
	upCum01PDataBase.setFGCREL(upCum01P.FGCREL);
	upCum01PDataBase.setFEPLTC(upCum01P.FEPLTC);
	upCum01PDataBase.setFECDAT(upCum01P.FECDAT);
	upCum01PDataBase.setFESDAT(upCum01P.FESDAT);
	upCum01PDataBase.setFGRAN(upCum01P.FGRAN);
	upCum01PDataBase.setPYRAN(upCum01P.PYRAN);
	upCum01PDataBase.setUSERAN(upCum01P.USERAN);
	upCum01PDataBase.setFGCCUM(upCum01P.FGCCUM);
	upCum01PDataBase.setSMCKEY(upCum01P.SMCKEY);
	upCum01PDataBase.setSMRDAT(upCum01P.SMRDAT);
	upCum01PDataBase.setSPLDAT(upCum01P.SPLDAT);
	upCum01PDataBase.setSPTRPT(upCum01P.SPTRPT);
	upCum01PDataBase.setTPLOC(upCum01P.TPLOC);
	upCum01PDataBase.setSPOEMC(upCum01P.SPOEMC);
	upCum01PDataBase.setSPOEMS(upCum01P.SPOEMS);
	upCum01PDataBase.setSPOEMD(upCum01P.SPOEMD);
	upCum01PDataBase.setUPEXSD(upCum01P.UPEXSD);
	upCum01PDataBase.setUPEXNQ(upCum01P.UPEXNQ);
	upCum01PDataBase.setEXDATE(upCum01P.EXDATE);
	upCum01PDataBase.setJITCUM(upCum01P.JITCUM);
	upCum01PDataBase.setPRDATE(upCum01P.PRDATE);
	upCum01PDataBase.setPRDCUM(upCum01P.PRDCUM);
	upCum01PDataBase.setNEDATE(upCum01P.NEDATE);
	upCum01PDataBase.setNEDCUM(upCum01P.NEDCUM);
	upCum01PDataBase.setRANFDAT(upCum01P.RANFDAT);
	upCum01PDataBase.setRANFQTY(upCum01P.RANFQTY);
	upCum01PDataBase.setRANDAT(upCum01P.RANDAT);
	upCum01PDataBase.setRANQTY(upCum01P.RANQTY);
	upCum01PDataBase.setOZTRPT(upCum01P.OZTRPT);
	upCum01PDataBase.setPLPRDA(upCum01P.PLPRDA);
	upCum01PDataBase.setPLPCUM(upCum01P.PLPCUM);
	upCum01PDataBase.setPLNRDA(upCum01P.PLNRDA);
	upCum01PDataBase.setPLNCUM(upCum01P.PLNCUM);
	upCum01PDataBase.setPLRDAT(upCum01P.PLRDAT);
	upCum01PDataBase.setRRLCUM(upCum01P.RRLCUM);

	return upCum01PDataBase;
}

public
UpCum01P cloneUpCum01P(UpCum01P upCum01P){
	UpCum01P upCum01PClone = new UpCum01P();

	upCum01PClone.FGBOL=upCum01P.FGBOL;
	upCum01PClone.FEBCS=upCum01P.FEBCS;
	upCum01PClone.FESCS=upCum01P.FESCS;
	upCum01PClone.FGENT=upCum01P.FGENT;
	upCum01PClone.FGORD=upCum01P.FGORD;
	upCum01PClone.FGITEM=upCum01P.FGITEM;
	upCum01PClone.FGCREL=upCum01P.FGCREL;
	upCum01PClone.FEPLTC=upCum01P.FEPLTC;
	upCum01PClone.FECDAT=upCum01P.FECDAT;
	upCum01PClone.FESDAT=upCum01P.FESDAT;
	upCum01PClone.FGRAN=upCum01P.FGRAN;
	upCum01PClone.PYRAN=upCum01P.PYRAN;
	upCum01PClone.USERAN=upCum01P.USERAN;
	upCum01PClone.FGCCUM=upCum01P.FGCCUM;
	upCum01PClone.SMCKEY=upCum01P.SMCKEY;
	upCum01PClone.SMRDAT=upCum01P.SMRDAT;
	upCum01PClone.SPLDAT=upCum01P.SPLDAT;
	upCum01PClone.SPTRPT=upCum01P.SPTRPT;
	upCum01PClone.TPLOC=upCum01P.TPLOC;
	upCum01PClone.SPOEMC=upCum01P.SPOEMC;
	upCum01PClone.SPOEMS=upCum01P.SPOEMS;
	upCum01PClone.SPOEMD=upCum01P.SPOEMD;
	upCum01PClone.UPEXSD=upCum01P.UPEXSD;
	upCum01PClone.UPEXNQ=upCum01P.UPEXNQ;
	upCum01PClone.EXDATE=upCum01P.EXDATE;
	upCum01PClone.JITCUM=upCum01P.JITCUM;
	upCum01PClone.PRDATE=upCum01P.PRDATE;
	upCum01PClone.PRDCUM=upCum01P.PRDCUM;
	upCum01PClone.NEDATE=upCum01P.NEDATE;
	upCum01PClone.NEDCUM=upCum01P.NEDCUM;
	upCum01PClone.RANFDAT=upCum01P.RANFDAT;
	upCum01PClone.RANFQTY=upCum01P.RANFQTY;
	upCum01PClone.RANDAT=upCum01P.RANDAT;
	upCum01PClone.RANQTY=upCum01P.RANQTY;
	upCum01PClone.OZTRPT=upCum01P.OZTRPT;
	upCum01PClone.PLPRDA=upCum01P.PLPRDA;
	upCum01PClone.PLPCUM=upCum01P.PLPCUM;
	upCum01PClone.PLNRDA=upCum01P.PLNRDA;
	upCum01PClone.PLNCUM=upCum01P.PLNCUM;
	upCum01PClone.PLRDAT=upCum01P.PLRDAT;
	upCum01PClone.RRLCUM=upCum01P.RRLCUM;

	return upCum01PClone;
}

/*
private
void objectDataBaseToObject(UpCum01PDataBase upCum01PDataBase,UpCum01P upCum01P){	
	upCum01P.FGBOL=upCum01PDataBase.getFGBOL();
	upCum01P.FEBCS=upCum01PDataBase.getFEBCS();
	upCum01P.FESCS=upCum01PDataBase.getFESCS();
	upCum01P.FGENT=upCum01PDataBase.getFGENT();
	upCum01P.FGORD=upCum01PDataBase.getFGORD();
	upCum01P.FGITEM=upCum01PDataBase.getFGITEM();
	upCum01P.FGCREL=upCum01PDataBase.getFGCREL();
	upCum01P.FEPLTC=upCum01PDataBase.getFEPLTC();
	upCum01P.FESDAT=upCum01PDataBase.getFESDAT();
	upCum01P.FGCCUM=upCum01PDataBase.getFGCCUM();
	upCum01P.SMCKEY=upCum01PDataBase.getSMCKEY();
	upCum01P.SMRDAT=upCum01PDataBase.getSMRDAT();
	upCum01P.SPTRPT=upCum01PDataBase.getSPTRPT();
	upCum01P.SPOEMC=upCum01PDataBase.getSPOEMC();
	upCum01P.SPOEMS=upCum01PDataBase.getSPOEMS();
	upCum01P.SPOEMD=upCum01PDataBase.getSPOEMD();
	//upCum01P.PYDATE=upCum01PDataBase.getPYDATE();
	upCum01P.JITCUM=upCum01PDataBase.getJITCUM();
	upCum01P.OZTRPT=upCum01PDataBase.getOZTRPT();
	//upCum01P.OZOEMC=upCum01PDataBase.getOZOEMC();
	//upCum01P.OZOEMS=upCum01PDataBase.getOZOEMS();
	//.OZCUMD=upCum01PDataBase.getOZCUMD();
	upCum01P.PLRDAT=upCum01PDataBase.getPLRDAT();
	upCum01P.RRLCUM= upCum01PDataBase.getRRLCUM();
	//upCum01P.UPLITI=upCum01PDataBase.getUPLITI();
//	upCum01P.UPARDA=upCum01PDataBase.getUPARDA();
	//upCum01P.UPOTST=upCum01PDataBase.getUPOTST();
//	upCum01P.UPQTST=upCum01PDataBase.getUPQTST();
//	upCum01P.UPEXSD=upCum01PDataBase.getUPEXSD();
	upCum01P.UPEXNQ=upCum01PDataBase.getUPEXNQ();
}

private
UpCum01PDataBase objectToObjectDataBase(UpCum01P upCum01P){
	UpCum01PDataBase upCum01PDataBase = new UpCum01PDataBase(dataBaseAccess);
	upCum01PDataBase.setFGBOL(upCum01P.FGBOL);
	upCum01PDataBase.setFEBCS(upCum01P.FEBCS);
	upCum01PDataBase.setFESCS(upCum01P.FESCS);
	upCum01PDataBase.setFGENT(upCum01P.FGENT);
	upCum01PDataBase.setFGORD(upCum01P.FGORD);
	upCum01PDataBase.setFGITEM(upCum01P.FGITEM);
	upCum01PDataBase.setFGCREL(upCum01P.FGCREL);
	upCum01PDataBase.setFEPLTC(upCum01P.FEPLTC);
	upCum01PDataBase.setFESDAT(upCum01P.FESDAT);
	upCum01PDataBase.setFGCCUM(upCum01P.FGCCUM);
	upCum01PDataBase.setSMCKEY(upCum01P.SMCKEY);
	upCum01PDataBase.setSMRDAT(upCum01P.SMRDAT);
	upCum01PDataBase.setSPTRPT(upCum01P.SPTRPT);
	upCum01PDataBase.setSPOEMC(upCum01P.SPOEMC);
	upCum01PDataBase.setSPOEMS(upCum01P.SPOEMS);
	upCum01PDataBase.setSPOEMD(upCum01P.SPOEMD);
	//upCum01PDataBase.setPYDATE(upCum01P.PYDATE);
	upCum01PDataBase.setJITCUM(upCum01P.JITCUM);
	upCum01PDataBase.setOZTRPT(upCum01P.OZTRPT);
	upCum01PDataBase.setOZOEMC(upCum01P.OZOEMC);
	upCum01PDataBase.setOZOEMS(upCum01P.OZOEMS);
	upCum01PDataBase.setOZCUMD(upCum01P.OZCUMD);
	upCum01PDataBase.setPLRDAT(upCum01P.PLRDAT);
	upCum01PDataBase.setRRLCUM(upCum01P.RRLCUM);
	upCum01PDataBase.setUPLITI(upCum01P.UPLITI);
	upCum01PDataBase.setUPARDA(upCum01P.UPARDA);
	upCum01PDataBase.setUPOTST(upCum01P.UPOTST);
	upCum01PDataBase.setUPQTST(upCum01P.UPQTST);
	upCum01PDataBase.setUPEXSD(upCum01P.UPEXSD);
	upCum01PDataBase.setUPEXNQ(upCum01P.UPEXNQ);

	return upCum01PDataBase;
}

public
UpCum01P cloneUpCum01P(UpCum01P upCum01P){
	UpCum01P upCum01PClone = new UpCum01P();

	upCum01PClone.FGBOL=upCum01P.FGBOL;
	upCum01PClone.FEBCS=upCum01P.FEBCS;
	upCum01PClone.FESCS=upCum01P.FESCS;
	upCum01PClone.FGENT=upCum01P.FGENT;
	upCum01PClone.FGORD=upCum01P.FGORD;
	upCum01PClone.FGITEM=upCum01P.FGITEM;
	upCum01PClone.FGCREL=upCum01P.FGCREL;
	upCum01PClone.FEPLTC=upCum01P.FEPLTC;
    upCum01PClone.FECDAT=upCum01P.FECDAT;
	upCum01PClone.FESDAT=upCum01P.FESDAT;
	upCum01PClone.FGCCUM=upCum01P.FGCCUM;
	upCum01PClone.SMCKEY=upCum01P.SMCKEY;
	upCum01PClone.SMRDAT=upCum01P.SMRDAT;
	upCum01PClone.SPTRPT=upCum01P.SPTRPT;
	upCum01PClone.SPOEMC=upCum01P.SPOEMC;
	upCum01PClone.SPOEMS=upCum01P.SPOEMS;
	upCum01PClone.SPOEMD=upCum01P.SPOEMD;
	upCum01PClone.PYDATE=upCum01P.PYDATE;
	upCum01PClone.JITCUM=upCum01P.JITCUM;
	upCum01PClone.OZTRPT=upCum01P.OZTRPT;
	upCum01PClone.OZOEMC=upCum01P.OZOEMC;
	upCum01PClone.OZOEMS=upCum01P.OZOEMS;
	upCum01PClone.OZCUMD=upCum01P.OZCUMD;
	upCum01PClone.PLRDAT=upCum01P.PLRDAT;
	upCum01PClone.RRLCUM= upCum01P.RRLCUM;
	upCum01PClone.UPLITI=upCum01P.UPLITI;
	upCum01PClone.UPARDA=upCum01P.UPARDA;
	upCum01PClone.UPOTST=upCum01P.UPOTST;
	upCum01PClone.UPQTST=upCum01P.UPQTST;
	upCum01PClone.UPEXSD=upCum01P.UPEXSD;
	upCum01PClone.UPEXNQ=upCum01P.UPEXNQ;

	return upCum01PClone;
}
*/
public
UpCum01PContainer readUpCum01PByFilters(decimal fGBOL, decimal fGENT,string sbillTo,string shipTo){
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);  

        UpCum01PContainer           upCum01PContainer = new UpCum01PContainer();
		UpCum01PDataBaseContainer   upCum01PDataBaseContainer = new UpCum01PDataBaseContainer(dataBaseAccess);

        foreach(UpCum01PDataBase upCum01PDataBase in upCum01PDataBaseContainer) {         		
		    UpCum01P upCum01P = this.objectDataBaseToObject(upCum01PDataBase);
            upCum01PContainer.Add(upCum01P);
        }

		return upCum01PContainer;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);  
    }
}

public
UpCum01PViewContainer readUpCum01PCustomByFilters(string splant,string stpartner,string sbillTo,string shipTo,string sbol,string sorder, string spo,string scustPO,string shipped,string sdocType,string srelease,decimal orderItem,bool blateOrders,string sppap,DateTime fromDate, DateTime toDate,int irows){
	try{        
        Hashtable                   hashLeadsPerBillTo              = new Hashtable();
        CustLeadDataBaseContainer   custLeadDataBaseContainerGeneric= new CustLeadDataBaseContainer(dataBaseAccess);
        loadCustLeadHash(out hashLeadsPerBillTo,out custLeadDataBaseContainerGeneric);

        TradingPartnerDataBaseContainer tradingPartnerDataBaseContainer = new TradingPartnerDataBaseContainer(dataBaseAccess);
        tradingPartnerDataBaseContainer.readByFilters("",0);
   
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        UpCum01PViewContainer upCum01PViewContainer =readUpCum01PCustomByFiltersInt(hashLeadsPerBillTo, custLeadDataBaseContainerGeneric, tradingPartnerDataBaseContainer,
                                                    splant,stpartner,sbillTo,shipTo,
                                                    sbol,sorder, spo,scustPO,shipped,sdocType,
                                                    srelease,orderItem,blateOrders,sppap,
                                                    fromDate, toDate,irows);
        return upCum01PViewContainer;

    } catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);  
    }
}

private
void loadCustLeadHash(out Hashtable hashLeadsPerBillTo,out CustLeadDataBaseContainer custLeadDataBaseContainerGeneric){
    hashLeadsPerBillTo = new Hashtable();
    custLeadDataBaseContainerGeneric = new CustLeadDataBaseContainer(dataBaseAccess);

    dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);  
    CustLeadDataBaseContainer custLeadDataBaseContainer = new CustLeadDataBaseContainer(dataBaseAccess);
    custLeadDataBaseContainer.read();

    hashLeadsPerBillTo = generateHashPerBillTo(custLeadDataBaseContainer);
    custLeadDataBaseContainerGeneric = new CustLeadDataBaseContainer(dataBaseAccess);

    if (hashLeadsPerBillTo.Contains("")) //load generic leads, billto is empty
        custLeadDataBaseContainerGeneric = (CustLeadDataBaseContainer)hashLeadsPerBillTo[""];
}

public
UpCum01PViewContainer readUpCum01PCustomByFiltersInt(Hashtable hashLeadsPerBillTo, CustLeadDataBaseContainer custLeadDataBaseContainerGeneric,TradingPartnerDataBaseContainer tradingPartnerDataBaseContainer,string splant,string stpartner,string sbillTo,string shipTo,string sbol,string sorder, string spo,string scustPO,string shipped,string sdocType,string srelease,decimal orderItem,bool blateOrders,string sppap,DateTime fromDate, DateTime toDate,int irows){	        
    UpCum01PViewContainer           upCum01PViewContainer       = new UpCum01PViewContainer();
	UpCum01PViewDataBaseContainer   upCum01PViewDataBaseContainer = new UpCum01PViewDataBaseContainer(dataBaseAccess);
    upCum01PViewDataBaseContainer.readByFilters(splant,stpartner, sbillTo, shipTo, sbol,sorder, spo, scustPO, shipped, sdocType, srelease,orderItem,blateOrders,sppap,fromDate, toDate, irows);
        
    foreach (UpCum01PViewDataBase upCum01PViewDataBase in upCum01PViewDataBaseContainer){
        UpCum01PView upCum01PView = objectDataBaseToObject(upCum01PViewDataBase);

        processsSubQueriesFields(upCum01PView);        
        loadLeadTimeForBillTo(upCum01PView,hashLeadsPerBillTo,custLeadDataBaseContainerGeneric);
        loadExportFlag(upCum01PView,tradingPartnerDataBaseContainer);
        loadBaseFields(upCum01PView);
        checkIfBobcatUPEXSDCalc(upCum01PView);
        upCum01PViewContainer.Add(upCum01PView);       
    }
               
    return upCum01PViewContainer;
}

private
void checkIfBobcatUPEXSDCalc(UpCum01PView upCum01PView){
    if (Configuration.valueInList(upCum01PView.FEBCS, Configuration.DataTransBillToOrdDateSameDateReq)){
        if ( DateUtil.minorHour(upCum01PView.UPEXSD) < DateUtil.minorHour(upCum01PView.FESDAT)){                
    
            if (DateUtil.getDayOfWeek(upCum01PView.UPEXSD) == 1)        //sunday
                upCum01PView.UPEXSD = DateUtil.minorHour(upCum01PView.UPEXSD).AddDays(4) >= DateUtil.minorHour(upCum01PView.FESDAT) ? upCum01PView.FESDAT: upCum01PView.UPEXSD;   
            else if (DateUtil.getDayOfWeek(upCum01PView.UPEXSD) == 7)   //saturday
                upCum01PView.UPEXSD = DateUtil.minorHour(upCum01PView.UPEXSD).AddDays(5) >= DateUtil.minorHour(upCum01PView.FESDAT) ? upCum01PView.FESDAT: upCum01PView.UPEXSD;   
            else
                upCum01PView.UPEXSD = DateUtil.minorHour(upCum01PView.UPEXSD).AddDays(3) >= DateUtil.minorHour(upCum01PView.FESDAT) ? upCum01PView.FESDAT: upCum01PView.UPEXSD;                                
        }
    }
}

private
void loadExportFlag(UpCum01PView upCum01PView,TradingPartnerDataBaseContainer tradingPartnerDataBaseContainer){
    string stpartner        = upCum01PView.SMTRPT;
    string sflagExport      = ShipExport.EXPORT_ORDER;    //assume order export
    
    if (string.IsNullOrEmpty(stpartner)) { 
        stpartner = upCum01PView.SMTRPT2;
        
        if (string.IsNullOrEmpty(stpartner)) 
            stpartner = upCum01PView.SMTRPT3;
                    
        upCum01PView.SMTRPT = stpartner;
    }
            
    if (!string.IsNullOrEmpty(stpartner)) { 
        TradingPartnerDataBase  tradingPartnerDataBase= null;        
        tradingPartnerDataBase= tradingPartnerDataBaseContainer.getTPartner(stpartner);
        if (tradingPartnerDataBase!= null)         
            sflagExport = tradingPartnerDataBase.getExportMode();            
    }    

    if (upCum01PView.DCOTYP.Equals("S"))
        sflagExport = ShipExport.EXPORT_ORDER;

    upCum01PView.ShipExportSource   = sflagExport;
}

private
void loadShipExportDtlContainersBySqlSteps(UpCum01PViewContainer upCum01PViewContainer,TradingPartnerDataBaseContainer tradingPartnerDataBaseContainer){
        
    //blank for now we process specific for each line, because could be 2 releases involved
    Hashtable   hashBlankShipExportDtlsPerOrder = new Hashtable();
    /*
    string      sql1 = "";
    ArrayList   arraySql1 = getSqlOCRRTArray(upCum01PViewContainer); //try to process differents sql, but not 1 at a time, because will take so much time 
        
    for (int i=0; i < arraySql1.Count; i++) { 
        sql1= (string)arraySql1[i];
        if (!string.IsNullOrEmpty(sql1)){
            ShipExportDtlDataBaseContainer shipExportDtlDataBaseContainer = new ShipExportDtlDataBaseContainer(dataBaseAccess);
            shipExportDtlDataBaseContainer.getSqlOCRRTByFilters(sql1);
            loadShipExportDtlContainerNew(hashBlankShipExportDtlsPerOrder,shipExportDtlDataBaseContainer);
        }
    }*/
    
    //standard
    string    sql2      = "";
    ArrayList arraySql2 = getSqlOCRITArray(upCum01PViewContainer);     
    Hashtable              hashStdShipExportDtlsPerOrder = new Hashtable();
    for (int i=0; i < arraySql2.Count; i++) { 
        sql2= (string)arraySql2[i];
        if (!string.IsNullOrEmpty(sql2)){
            ShipExportDtlDataBaseContainer shipExportDtlDataBaseContainer = new ShipExportDtlDataBaseContainer(dataBaseAccess);
            shipExportDtlDataBaseContainer.getSqlOCRITByFilters(sql2);            
            loadShipExportDtlContainerNew(hashStdShipExportDtlsPerOrder,shipExportDtlDataBaseContainer);
        }
    }    

    loadShipExportDtlContainersBasedLoadedNew( upCum01PViewContainer,
                                               hashBlankShipExportDtlsPerOrder,hashStdShipExportDtlsPerOrder,tradingPartnerDataBaseContainer); 
}

private
void loadShipExportDtlContainers(UpCum01PViewContainer upCum01PViewContainer){
    //blanket
    string      sql1                =getSqlOCRRT(upCum01PViewContainer);
    
    ShipExportDtlContainer      shipExportDtlContainerBlank = new ShipExportDtlContainer();
    if (!string.IsNullOrEmpty(sql1)){
        ShipExportDtlDataBaseContainer shipExportDtlDataBaseContainer = new ShipExportDtlDataBaseContainer(dataBaseAccess);
        shipExportDtlDataBaseContainer.getSqlOCRRTByFilters(sql1);    
        loadShipExportDtlContainer(shipExportDtlContainerBlank,shipExportDtlDataBaseContainer);
    }        
    //standard
    string                  sql2=getSqlOCRIT(upCum01PViewContainer);
    ShipExportDtlContainer  shipExportDtlContainerStd = new ShipExportDtlContainer();
    if (!string.IsNullOrEmpty(sql2)){
        ShipExportDtlDataBaseContainer shipExportDtlDataBaseContainer = new ShipExportDtlDataBaseContainer(dataBaseAccess);
        shipExportDtlDataBaseContainer.getSqlOCRITByFilters(sql2);    
        loadShipExportDtlContainer(shipExportDtlContainerStd,shipExportDtlDataBaseContainer);
    }

    loadShipExportDtlContainersBasedLoaded( upCum01PViewContainer, 
                                            shipExportDtlContainerBlank,shipExportDtlContainerStd);    
}

private
void loadShipExportDtlContainersBasedLoaded(UpCum01PViewContainer   upCum01PViewContainer, 
                                            ShipExportDtlContainer  shipExportDtlContainerBlank,ShipExportDtlContainer shipExportDtlContainerStd){

    for (int i=0; i < upCum01PViewContainer.Count;i++){

        UpCum01PView upCum01PView = upCum01PViewContainer[i];
        if (upCum01PView.DCOTYP.Equals("B"))
            loadShipExportDtlByProperlyOrder(upCum01PView, shipExportDtlContainerBlank,false);
        else
            loadShipExportDtlByProperlyOrder(upCum01PView, shipExportDtlContainerStd,false);

        upCum01PView.ShipExportDtlContainer.removeRecsWithNoChanges();
        upCum01PView.ShipExportDtlContainer.fillDetails();
    }
}

private
void loadShipExportDtlContainersBasedLoadedNew( UpCum01PViewContainer   upCum01PViewContainer,
                                                Hashtable  hashBlankShipExportDtlsPerOrder, Hashtable hashStdShipExportDtlsPerOrder,
                                                TradingPartnerDataBaseContainer tradingPartnerDataBaseContainer){
    string  stpartner       = "";        
    string  sflagExport     = ShipExport.EXPORT_ORDER;   
    string  sflagTrlpFound  = Constants.STRING_NO;   

    for (int i=0; i < upCum01PViewContainer.Count;i++){

        UpCum01PView upCum01PView = upCum01PViewContainer[i];

        loadTPartnerFlagExport(tradingPartnerDataBaseContainer,upCum01PView.DCOTYP,upCum01PView.FEBCS,upCum01PView.FESCS,upCum01PView.FGORD,upCum01PView.FGITEM,upCum01PView.SMTRPT,out stpartner,out sflagExport,out sflagTrlpFound);
        upCum01PView.ShipExportSource   = sflagExport;
        upCum01PView.Trlp               = sflagTrlpFound;
        
        if (upCum01PView.DCOTYP.Equals("B"))
            loadShipExportDtlByProperlyOrderNew(hashBlankShipExportDtlsPerOrder,upCum01PView,stpartner);
        else
            loadShipExportDtlByProperlyOrderNew(hashStdShipExportDtlsPerOrder,upCum01PView,stpartner);        
    }
}

private
TrlpDataBase getCustTPartner(string sbillTo,string shipTo,decimal order,decimal item,out string stpartner,out string shipLoc){
    bool bresult=false;
    stpartner  = shipLoc = "";

    TrlpDataBase            trlpDataBase = null;
    TrlpDataBaseContainer   trlpDataBaseContainer = new TrlpDataBaseContainer(dataBaseAccess);

    trlpDataBaseContainer.readByFilters("","",sbillTo,shipTo,"",order,item,"",0,"",1);
    if (trlpDataBaseContainer.Count > 0){
        trlpDataBase = (TrlpDataBase)trlpDataBaseContainer[0];

        stpartner   = trlpDataBase.getSMTRPT();
        shipLoc     = trlpDataBase.getSMSTXL();

        bresult=true;
    }


    /*
    CustDataBase    custDataBase    = new CustDataBase(dataBaseAccess);   
    
    custDataBase.setBVCUST(shipTo);//empty so we search for shipto tpartner
    if (custDataBase.read()) { 
        stpartner   = custDataBase.getBVTRDP();
        shipLoc     = custDataBase.getBVDUNS();
        bresult=true;
    }

    if (string.IsNullOrEmpty(stpartner)){ 
        custDataBase.setBVCUST(sbillTo);// upCum01PView.FEBCS); //try to get trading partner
        if (custDataBase.read())
            stpartner = custDataBase.getBVTRDP();
    }*/

    return trlpDataBase;
}

private
bool getCustStdTPartner(string sbillTo,string shipTo,out string stpartner,out string shipLoc){
    bool        bresult=false;
    stpartner  = shipLoc = "";
   
    CustDataBase    custDataBase    = new CustDataBase(dataBaseAccess);   
    
    custDataBase.setBVCUST(shipTo);//empty so we search for shipto tpartner
    if (custDataBase.read()) { 
        stpartner   = custDataBase.getBVTRDP();
        shipLoc     = custDataBase.getBVDUNS();
        bresult=true;
    }

    if (string.IsNullOrEmpty(stpartner)){ 
        custDataBase.setBVCUST(sbillTo);// upCum01PView.FEBCS); //try to get trading partner
        if (custDataBase.read()) {             
            stpartner   = custDataBase.getBVTRDP();
            shipLoc     = custDataBase.getBVDUNS();
            bresult=true;
        }
    }
    return bresult;
}

private
void loadTPartnerFlagExport(TradingPartnerDataBaseContainer tradingPartnerDataBaseContainer,string sorderType,string sbillTo,string shipTo,decimal order,decimal item,string stpartnerOld,out string stpartner,out string sflagExport,out string sflagTrlpFound){
    string shipLoc = "";

    stpartner       = "";
    sflagExport     = ShipExport.EXPORT_ORDER;   
    sflagTrlpFound  = Constants.STRING_NO;

    if (!string.IsNullOrEmpty(sorderType)) { 
        if (sorderType.Equals("B")) { //blanket get from trlp
            TrlpDataBase    trlpDataBase = getCustTPartner(sbillTo, shipTo, order, item, out stpartner, out shipLoc);

            if (trlpDataBase != null) 
                sflagTrlpFound = Constants.STRING_YES;    
            else
                getCustTPartner(sbillTo,shipTo,0,0,out stpartner,out shipLoc);

        }else {//standard
            getCustStdTPartner(sbillTo,shipTo,out stpartner,out shipLoc);                
            sflagTrlpFound = ""; //for std trlp is empty
        }
    }

    if (string.IsNullOrEmpty(stpartner))
        stpartner = stpartnerOld;
                     
    TradingPartnerDataBase  tradingPartnerDataBase= null;        
    tradingPartnerDataBase= tradingPartnerDataBaseContainer.getTPartner(stpartner);
    if (tradingPartnerDataBase!= null)         
        sflagExport = tradingPartnerDataBase.getExportMode();     
    
    if (sorderType.Equals("S"))    
        sflagExport     = ShipExport.EXPORT_ORDER; //if Std allways will be flag ship export Order                      
}

private
void loadShipExportDtlByProperlyOrder(UpCum01PView upCum01PView,ShipExportDtlContainer shipExportDtlContainer,bool bremoveIfFound){
    ShipExportDtl   shipExportDtl   =null;
    bool            bprocess        =true;

    for (int i=0; i < shipExportDtlContainer.Count && bprocess;i++) { 
        shipExportDtl= shipExportDtlContainer[i];

        if (shipExportDtl.OrderNum == upCum01PView.FGORD && shipExportDtl.Item == upCum01PView.FGITEM && shipExportDtl.Release.ToUpper().Equals(upCum01PView.FGRLNO.ToUpper())) { 
            upCum01PView.ShipExportDtlContainer.Add(shipExportDtl);   
            if (bremoveIfFound) { 
                shipExportDtlContainer.RemoveAt(i);
                i--;
            }
        }

        if ( shipExportDtl.OrderNum > upCum01PView.FGORD)
            bprocess=false;//info is order by order so, if bigger than order searching , stop searching
    }
}

private
void loadShipExportDtlContainer(ShipExportDtlContainer shipExportDtlContainer, ShipExportDtlDataBaseContainer shipExportDtlDataBaseContainer){       
    foreach(ShipExportDtlDataBase shipExportDtlDataBase in shipExportDtlDataBaseContainer)
        shipExportDtlContainer.Add(objectDataBaseToObject(shipExportDtlDataBase));
}

private
string getSqlOCRRT(UpCum01PViewContainer upCum01PViewContainer){
    string      sql     = "";
    int         icounter= 0;
    
    for (int i=0; i < upCum01PViewContainer.Count;i++){
        UpCum01PView upCum01PView = upCum01PViewContainer[i];

        if (upCum01PView.DCOTYP.Equals("B")) { 
            sql+= string.IsNullOrEmpty(sql) ? " where " : " or ";
            sql+= "(DC5ORD#=" + NumberUtil.toString(upCum01PView.FGORD) + " and DC5ITM#=" + NumberUtil.toString(upCum01PView.FGITEM) + " and DC5RLNO='" + Converter.fixString(upCum01PView.FGRLNO) + "')";        

            icounter++;
        }
    }
    return sql;
}

private
ArrayList getSqlOCRRTArray(UpCum01PViewContainer upCum01PViewContainer){
    string      sql     = "";
    int         icounter= 0;
    int         index   = 0;
    ArrayList   arraySql = new ArrayList();

    arraySql.Add(""); //empty
    for (int i=0; i < upCum01PViewContainer.Count;i++){
        UpCum01PView upCum01PView = upCum01PViewContainer[i];

        if (upCum01PView.DCOTYP.Equals("B")) { 
                    /*
            string sqlOrder = " cmsdat.OCRRT where DC5ORD#=" + NumberUtil.toString(upCum01PView.FGORD) +  " and DC5ITM#=" + NumberUtil.toString(upCum01PView.FGITEM);
            string sql2   = "(select distinct(DC5RLNO)  from " + sqlOrder +
            " and (DC5SDAT >= ((select  max(DC5SDAT) from " + sqlOrder + " and DC5RLNO='" + Converter.fixString(upCum01PView.FGRLNO) + "') - 7 days) " +
            " and  DC5SDAT <= (select  max(DC5SDAT)  from " + sqlOrder + " and DC5RLNO='" + Converter.fixString(upCum01PView.FGRLNO) + "') ))";
            */
            sql += string.IsNullOrEmpty(sql) ? " where " : " or ";
            sql+= "(DC5ORD#=" + NumberUtil.toString(upCum01PView.FGORD) + " and DC5ITM#=" + NumberUtil.toString(upCum01PView.FGITEM) + " and DC5RLNO='" + Converter.fixString(upCum01PView.FGRLNO) + "')";        
            //sql+= "(DC5ORD#=" + NumberUtil.toString(upCum01PView.FGORD) + " and DC5ITM#=" + NumberUtil.toString(upCum01PView.FGITEM) + " and DC5RLNO in " + sql2 + ")";        
    
            icounter++;
            if (icounter >= UpCum01PView.IMAX_RECORDS_PROCESS){
                arraySql[index] = sql;
                sql = "";
                arraySql.Add("");                            
                index++;
                icounter =0;    
                
            }
        }
    }
    
    if (index < arraySql.Count && !string.IsNullOrEmpty(sql))
        arraySql[index] = sql;

    return arraySql;
}

private
ArrayList getSqlOCRITArray(UpCum01PViewContainer upCum01PViewContainer){
    string      sql     = "";
    int         icounter= 0;
    int         index   = 0;
    ArrayList   arraySql = new ArrayList();

    arraySql.Add(""); //empty
    for (int i=0; i < upCum01PViewContainer.Count;i++){
        UpCum01PView upCum01PView = upCum01PViewContainer[i];

        if (!upCum01PView.DCOTYP.Equals("B")) { 
            sql+= string.IsNullOrEmpty(sql) ? " where " : " or ";
            sql+= "(DC4ORD#=" + NumberUtil.toString(upCum01PView.FGORD) + " and DC4ITM#=" + NumberUtil.toString(upCum01PView.FGITEM) + ")";        
           
            icounter++;
            if (icounter >= UpCum01PView.IMAX_RECORDS_PROCESS){
                arraySql[index] = sql;
                sql = "";
                arraySql.Add("");                            
                index++;
                icounter =0;                    
            }
        }
    }
    
    if (index < arraySql.Count && !string.IsNullOrEmpty(sql))
        arraySql[index] = sql;

    return arraySql;
}
                
private
string getSqlOCRIT(UpCum01PViewContainer upCum01PViewContainer){
    string  sql     = "";
    int     icounter= 0;

    for (int i=0; i < upCum01PViewContainer.Count;i++){
        UpCum01PView upCum01PView = upCum01PViewContainer[i];

        if (!upCum01PView.DCOTYP.Equals("B")) { 
            sql+= string.IsNullOrEmpty(sql) ? " where " : " or ";
            sql+= "(DC4ORD#=" + NumberUtil.toString(upCum01PView.FGORD) + " and DC4ITM#=" + NumberUtil.toString(upCum01PView.FGITEM) + ")";        

            icounter++;
        }
    }
    return sql;
}


public
Hashtable generateHashPerBillTo(CustLeadDataBaseContainer custLeadDataBaseContainer){
    Hashtable                   hashLeadsPerBillTo = new Hashtable();
    string                      skey ="";
    CustLeadDataBaseContainer   custLeadDataBaseContainerAux = null;

    foreach (CustLeadDataBase custLeadDataBase in custLeadDataBaseContainer){
        skey = custLeadDataBase.getCustId().ToUpper();
        if (hashLeadsPerBillTo.Contains(skey)){
            custLeadDataBaseContainerAux = (CustLeadDataBaseContainer)hashLeadsPerBillTo[skey];
        }else{
            custLeadDataBaseContainerAux = new CustLeadDataBaseContainer(dataBaseAccess);
            hashLeadsPerBillTo.Add(skey,custLeadDataBaseContainerAux);
        }
        custLeadDataBaseContainerAux.Add(custLeadDataBase);
    }
    
    return hashLeadsPerBillTo;
}

private
CustLeadDataBase getCustLeadBasedMajMinSalesCode(UpCum01PView upCum01PView, CustLeadDataBaseContainer custLeadDataBaseContainer){
    CustLeadDataBase            custLeadDataBaseFound = null;    
    bool                        bfound=false;

    for (int i = 0; i <  custLeadDataBaseContainer.Count && !bfound;i++){
        CustLeadDataBase custLeadDataBase = (CustLeadDataBase)custLeadDataBaseContainer[i];

        if (custLeadDataBase.getMajSalesCode().ToUpper().Equals(upCum01PView.AVMAJS.ToUpper())){
            custLeadDataBaseFound = custLeadDataBase;
            if (custLeadDataBase.getMinSalesCode().ToUpper().Equals(upCum01PView.AVMINS.ToUpper())) { 
                custLeadDataBaseFound= custLeadDataBase;
                bfound=true;//same similar MajGroup/MinGroup
            }
        }                                   
    }
    return custLeadDataBaseFound;
}

public
bool loadLeadTimeForBillTo(UpCum01PView upCum01PView,Hashtable hashLeadsPerBillTo,CustLeadDataBaseContainer custLeadDataBaseContainerGeneric){
    string                      skey = upCum01PView.FEBCS.ToUpper();
    CustLeadDataBaseContainer   custLeadDataBaseContainer = null;
    CustLeadDataBase            custLeadDataBaseFound = null;    
    bool                        bfound=false;
    
    if (hashLeadsPerBillTo.Contains(skey))   
        custLeadDataBaseContainer = (CustLeadDataBaseContainer)hashLeadsPerBillTo[skey];//get CustLeads for billto

    if (custLeadDataBaseContainer != null)
        custLeadDataBaseFound = getCustLeadBasedMajMinSalesCode(upCum01PView,custLeadDataBaseContainer);    

    if (custLeadDataBaseFound == null)
        custLeadDataBaseFound = getCustLeadBasedMajMinSalesCode(upCum01PView, custLeadDataBaseContainerGeneric);  //search on generics
    
    if (custLeadDataBaseFound!= null) { 
        bfound=true;
        upCum01PView.LeadTime   = custLeadDataBaseFound.getLeadTime();                
        upCum01PView.LTBookQty  = upCum01PView.QtyOrder;
    }    
    upCum01PView.LTBookDate = upCum01PView.UPEXSD.AddDays(upCum01PView.LeadTime*-1);

    return bfound;
}


private
void processsSubQueriesFields(UpCum01PView upCum01PView){

    if (upCum01PView.DCOTYP.Equals("B")) { //if blanket process
        if (!string.IsNullOrEmpty(upCum01PView.OCRRTValues))
            processsSubQueriesOCRRTFields(upCum01PView, upCum01PView.OCRRTValues);
        else if (!string.IsNullOrEmpty(upCum01PView.OCRRTValuesAny))
            processsSubQueriesOCRRTFields(upCum01PView, upCum01PView.OCRRTValuesAny);

        if (upCum01PView.QtyOrderOcrr != decimal.MinValue)            //if OCRR record exists we use it
            upCum01PView.QtyOrder = upCum01PView.QtyOrderOcrr;
    }else{
        upCum01PView.DC4TMSP="";
        upCum01PView.DC4QDAT=DateUtil.MinValue;
        if (!string.IsNullOrEmpty(upCum01PView.OCRITValuesChange)) //wich has any change 
            processsSubQueriesOCRITValuesChange(upCum01PView, upCum01PView.OCRITValuesChange); 
        if (!string.IsNullOrEmpty(upCum01PView.OCRITValuesAny)) //last
            processsSubQueriesOCRITValues(upCum01PView, upCum01PView.OCRITValuesAny); 
        if (!string.IsNullOrEmpty(upCum01PView.OCRITValues))  //close to postdate             
            processsSubQueriesOCRITValues(upCum01PView, upCum01PView.OCRITValues);                       
    }
    upCum01PView.LTBookDate = upCum01PView.UPEXSD; //as a start is at least expected date, when lead load it will be recalculated
}

private
bool processsSubQueriesOCRRTFields(UpCum01PView upCum01PView,string oCRRTValues){
    bool        bresult = false;
    string[]    items   = oCRRTValues.Split(Constants.DEFAULT_SEP);    
    DateTime    date    = DateUtil.MinValue;

    if (items.Length > 2){
        upCum01PView.DC5TMSP= items[0];

        if (upCum01PView.DC5QTOO == decimal.MinValue) 
            try { upCum01PView.DC5QTOO = Convert.ToDecimal(items[1]); } catch { };                    
        upCum01PView.QtyOrder = upCum01PView.DC5QTOO;

        upCum01PView.UPEXSD = upCum01PView.DC5SDAT;
        if (upCum01PView.UPEXSD == DateUtil.MinValue) { 
            parseDate(items[2], out date);
            upCum01PView.UPEXSD = date;
        }

        parseDate(items[3], out date);
        upCum01PView.DC5QDAT = date;

        bresult=true;                
    }
    return bresult;
}

private
bool processsSubQueriesOCRITValues(UpCum01PView upCum01PView,string oCRITValues){
    bool        bresult = false;
    string[]    items   = oCRITValues.Split(Constants.DEFAULT_SEP);    
    DateTime    date    = DateUtil.MinValue;

    if (items.Length > 2){
        if (string.IsNullOrEmpty(upCum01PView.DC4TMSP))
            upCum01PView.DC4TMSP = items[0];     
        parseDate(items[1], out date);
        upCum01PView.UPEXSD = date;
        
        parseDate(items[2], out date);
        upCum01PView.DC4QDAT = date;        
                
        bresult=true;                
    }
    return bresult;
}

private
bool processsSubQueriesOCRITValuesChange(UpCum01PView upCum01PView,string oCRITValues){
    bool        bresult = false;
    string[]    items   = oCRITValues.Split(Constants.DEFAULT_SEP);    
    DateTime    date    = DateUtil.MinValue;

    if (items.Length > 2){
        if (upCum01PView.ChangeDate == DateUtil.MinValue)
            upCum01PView.ChangeDate = DateUtil.parseDateFromStringAS400(items[0]);
                
        bresult=true;                
    }
    return bresult;
}

private
bool parseDate(string sdate,out DateTime date){
    bool bresult=false;
    date = DateUtil.MinValue;
    try {
        sdate   = sdate.Replace('-','/');
        date    = DateUtil.parseDate(sdate, DateUtil.YYYYMMDD);
        bresult=true;
    } catch {        
    };
    return bresult;
}

private
void loadBaseFields(UpCum01PView upCum01PView){
    try {
        bool            b830Or862 = upCum01PView.ShipExportSource.Equals(ShipExport.EXPORT_830) || 
                                    upCum01PView.ShipExportSource.Equals(ShipExport.EXPORT_862) || upCum01PView.ShipExportSource.Equals(ShipExport.EXPORT_862_RAN);
        upCum01PView.ReleaseBase= "";
        upCum01PView.QtyOrdBase = 0;

        if (upCum01PView.DCOTYP.Equals("B")) { 
            if (!string.IsNullOrEmpty(upCum01PView.FGRLNO) && upCum01PView.FGRLNO.Length > 2){       

                if (b830Or862) {
                    if (string.IsNullOrEmpty(upCum01PView.BOLOtherOrder)){
                        upCum01PView.ReleaseBase= upCum01PView.FGRLNO;        
                        upCum01PView.QtyOrdBase = upCum01PView.DFQTYR != decimal.MinValue ? upCum01PView.DFQTYR : upCum01PView.QtyOrder;
                    }else
                        upCum01PView.ReleaseBase= upCum01PView.BOLOtherOrder;                    
                }else{
                    if (upCum01PView.QtyBack > 0 && !string.IsNullOrEmpty(upCum01PView.BOLOtherOrder)){ 
                        upCum01PView.ReleaseBase= upCum01PView.BOLOtherOrder; 
                    }else{
                        upCum01PView.ReleaseBase= upCum01PView.FGRLNO;        
                        upCum01PView.QtyOrdBase = upCum01PView.DFQTYR != decimal.MinValue ? upCum01PView.DFQTYR : upCum01PView.QtyOrder;
                    }
                }
                                                                                                    
            }else{
                upCum01PView.ReleaseBase= string.IsNullOrEmpty(upCum01PView.ReleaseBase) ? upCum01PView.FGRLNO: upCum01PView.ReleaseBase;
                upCum01PView.QtyOrdBase = upCum01PView.DFQTYR != decimal.MinValue ? upCum01PView.DFQTYR : upCum01PView.QtyOrder;
            }                                    
        }else{ //Standard            
            if (upCum01PView.FESTDATOtherOrder == DateUtil.MinValue || upCum01PView.FESTDATOtherOrder > upCum01PView.FESDAT) { 
                upCum01PView.ReleaseBase= upCum01PView.FGRLNO; //supposed not having release filled, just in case we stored it
                upCum01PView.QtyOrdBase = upCum01PView.DDQTOI;
            }
        }
    } catch {        
    };    
}   

/**************************************************** *******************************************************************/
public
ShipExport createShipExport(){
	return new ShipExport();
}

public
ShipExportContainer createShipExportContainer(){
	return new ShipExportContainer();
}

public
ShipExportDtl createShipExportDtl(){
	return new ShipExportDtl();
}

public
ShipExportDtlContainer createShipExportDtlContainer(){
	return new ShipExportDtlContainer();
}

public
bool existsShipExport(string site, decimal bol, decimal bolItem){
	try{
		ShipExportDataBase shipExportDataBase = new ShipExportDataBase(dataBaseAccess);

		shipExportDataBase.setSite(site);
		shipExportDataBase.setBol(bol);
		shipExportDataBase.setBolItem(bolItem);

		return shipExportDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
ShipExport readShipExport(string site, decimal bol, decimal bolItem){
	try{
		ShipExportDataBase shipExportDataBase = new ShipExportDataBase(dataBaseAccess);
		shipExportDataBase.setSite(site);
		shipExportDataBase.setBol(bol);
		shipExportDataBase.setBolItem(bolItem);

		if (!shipExportDataBase.read())
			return null;

		ShipExport shipExport = this.objectDataBaseToObject(shipExportDataBase);

        ShipExportDtlDataBaseContainer shipExportDtlDataBaseContainer = new ShipExportDtlDataBaseContainer(dataBaseAccess);
        shipExportDtlDataBaseContainer.readByHdr(site,bol,bolItem);

        foreach(ShipExportDtlDataBase shipExportDtlDataBase in shipExportDtlDataBaseContainer)
            shipExport.ShipExportDtlContainer.Add(objectDataBaseToObject(shipExportDtlDataBase));

        return shipExport;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateShipExport(ShipExport shipExport){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		 updateShipExportInt(shipExport);

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
void updateShipExportInt(ShipExport shipExport){
    shipExport.fillRedundances(); //because some values need to be calculated before save hdr

    ShipExportDataBase shipExportDataBase = this.objectToObjectDataBase(shipExport);
	shipExportDataBase.update();

    deleteShipExportChilds(shipExport.Site, shipExport.Bol,shipExport.BolItem);
    writeShipExportChilds(shipExport);
}

public 
void deleteShipExportChilds(string site, decimal bol, decimal bolItem){
    ShipExportDtlDataBaseContainer shipExportDtlDataBaseContainer = new ShipExportDtlDataBaseContainer(dataBaseAccess);
	shipExportDtlDataBaseContainer.deleteByHdr(site,bol,bolItem);

    ShipExportReleaseDataBaseContainer shipExportReleaseDataBaseContainer = new ShipExportReleaseDataBaseContainer(dataBaseAccess);
    shipExportReleaseDataBaseContainer.deleteByHdr(site,bol,bolItem);
}

public 
void writeShipExportChilds(ShipExport shipExport){
    shipExport.fillRedundances();

    foreach(ShipExportDtl shipExportDtl in shipExport.ShipExportDtlContainer) { 
        ShipExportDtlDataBase shipExportDtlDataBase = objectToObjectDataBase(shipExportDtl);
        shipExportDtlDataBase.write();
    }    

    foreach(ShipExportRelease shipExportRelease in shipExport.ShipExportReleaseContainer) { 
        ShipExportReleaseDataBase shipExportReleaseDataBase = objectToObjectDataBase(shipExportRelease);
        shipExportReleaseDataBase.write();
    }
}

public 
void writeShipExport(ShipExport shipExport){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		writeShipExportInt(shipExport);

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
void writeShipExportInt(ShipExport shipExport){
    shipExport.fillRedundances(); //because some values need to be calculated before save hdr

    ShipExportDataBase shipExportDataBase = this.objectToObjectDataBase(shipExport);
	shipExportDataBase.write();

    writeShipExportChilds(shipExport);
}

public
void deleteShipExport(string site, decimal bol, decimal bolItem){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        deleteShipExportChilds(site,bol,bolItem);

		ShipExportDataBase shipExportDataBase = new ShipExportDataBase(dataBaseAccess);
		shipExportDataBase.setSite(site);
		shipExportDataBase.setBol(bol);
		shipExportDataBase.setBolItem(bolItem);
		shipExportDataBase.delete();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

private
ShipExport objectDataBaseToObject(ShipExportDataBase shipExportDataBase){
	ShipExport shipExport = new ShipExport();

	shipExport.Site=shipExportDataBase.getSite();
	shipExport.Bol=shipExportDataBase.getBol();
	shipExport.BolItem=shipExportDataBase.getBolItem();
	shipExport.BillTo=shipExportDataBase.getBillTo();
	shipExport.ShipTo=shipExportDataBase.getShipTo();
	shipExport.ShipDate=shipExportDataBase.getShipDate();
	shipExport.DateRequest=shipExportDataBase.getDateRequest();
	shipExport.CreateDate=shipExportDataBase.getCreateDate();
	shipExport.PostDate=shipExportDataBase.getPostDate();
	shipExport.OrderNum=shipExportDataBase.getOrderNum();
	shipExport.Item=shipExportDataBase.getItem();
	shipExport.Release=shipExportDataBase.getRelease();
	shipExport.OrdType=shipExportDataBase.getOrdType();
	shipExport.Product=shipExportDataBase.getProduct();
	shipExport.CustPart=shipExportDataBase.getCustPart();
	shipExport.QtyShipped=shipExportDataBase.getQtyShipped();
	shipExport.QtyBack=shipExportDataBase.getQtyBack();
	shipExport.QtyExpec=shipExportDataBase.getQtyExpec();
	shipExport.QtyOrder=shipExportDataBase.getQtyOrder();
	shipExport.ProdType=shipExportDataBase.getProdType();
	shipExport.BackFlag=shipExportDataBase.getBackFlag();
	shipExport.LineBookDate=shipExportDataBase.getLineBookDate();
	shipExport.CustReqDate=shipExportDataBase.getCustReqDate();
	shipExport.BackOrderFlag=shipExportDataBase.getBackOrderFlag();
	shipExport.Market=shipExportDataBase.getMarket();
	shipExport.ExportDate=shipExportDataBase.getExportDate();

    shipExport.OrderDate= shipExportDataBase.getOrderDate();
	shipExport.FirstQty = shipExportDataBase.getFirstQty();
	shipExport.MajGroup = shipExportDataBase.getMajGroup();
	shipExport.MinGroup = shipExportDataBase.getMinGroup();
	shipExport.MinSales = shipExportDataBase.getMinSales();
    shipExport.MajSales = shipExportDataBase.getMajSales();

    shipExport.TradPartner  =shipExportDataBase.getTradPartner();
    shipExport.ShipToLoc    =shipExportDataBase.getShipToLoc();
    shipExport.CumQty       = shipExportDataBase.getCumQty();
    shipExport.Ran          =shipExportDataBase.getRan();
    shipExport.LTBookDate   =shipExportDataBase.getLTBookDate();
    shipExport.LTBookQty    =shipExportDataBase.getLTBookQty();

    shipExport.LastDateChange       =shipExportDataBase.getLastDateChange();
    shipExport.LastQtyDateChange    =shipExportDataBase.getLastQtyDateChange();
    shipExport.LastQtyChange        =shipExportDataBase.getLastQtyChange();
    shipExport.CustPO               =shipExportDataBase.getCustPO();
    shipExport.Ppap                 =shipExportDataBase.getPpap();
    shipExport.Trlp                 =shipExportDataBase.getTrlp();
    shipExport.EdiRelease           =shipExportDataBase.getEdiRelease();
    shipExport.LeadTime             =shipExportDataBase.getLeadTime();
    shipExport.LeadTime2            =shipExportDataBase.getLeadTime2();
    shipExport.LeadTime3            =shipExportDataBase.getLeadTime3();

    shipExport.ReleaseBase          =shipExportDataBase.getReleaseBase();
    shipExport.QtyOrdBase           =shipExportDataBase.getQtyOrdBase();

    shipExport.CumRequired          = shipExportDataBase.getCumRequired();
    shipExport.QtyOrderedFromCum    = shipExportDataBase.getQtyOrderedFromCum();
           
    shipExport.CumPrior             = shipExportDataBase.getCumPrior();
    shipExport.QtyRequired          = shipExportDataBase.getQtyRequired();

    shipExport.ShipTo               =shipExportDataBase.getShipTo();
    shipExport.CreateDate           =shipExportDataBase.getCreateDate();
    shipExport.TradPartner          =shipExportDataBase.getTradPartner();
                
    return shipExport;
}

private
ShipExportDataBase objectToObjectDataBase(ShipExport shipExport){
	ShipExportDataBase shipExportDataBase = new ShipExportDataBase(dataBaseAccess);
	shipExportDataBase.setSite(shipExport.Site);
	shipExportDataBase.setBol(shipExport.Bol);
	shipExportDataBase.setBolItem(shipExport.BolItem);
	shipExportDataBase.setBillTo(shipExport.BillTo);
	shipExportDataBase.setShipTo(shipExport.ShipTo);
	shipExportDataBase.setShipDate(shipExport.ShipDate);
	shipExportDataBase.setDateRequest(shipExport.DateRequest);
	shipExportDataBase.setCreateDate(shipExport.CreateDate);
	shipExportDataBase.setPostDate(shipExport.PostDate);
	shipExportDataBase.setOrderNum(shipExport.OrderNum);
	shipExportDataBase.setItem(shipExport.Item);
	shipExportDataBase.setRelease(shipExport.Release);
	shipExportDataBase.setOrdType(shipExport.OrdType);
	shipExportDataBase.setProduct(shipExport.Product);
	shipExportDataBase.setCustPart(shipExport.CustPart);
	shipExportDataBase.setQtyShipped(shipExport.QtyShipped);
	shipExportDataBase.setQtyBack(shipExport.QtyBack);
	shipExportDataBase.setQtyExpec(shipExport.QtyExpec);
	shipExportDataBase.setQtyOrder(shipExport.QtyOrder);
	shipExportDataBase.setProdType(shipExport.ProdType);
	shipExportDataBase.setBackFlag(shipExport.BackFlag);
	shipExportDataBase.setLineBookDate(shipExport.LineBookDate);
	shipExportDataBase.setCustReqDate(shipExport.CustReqDate);
	shipExportDataBase.setBackOrderFlag(shipExport.BackOrderFlag);
	shipExportDataBase.setMarket(shipExport.Market);
	shipExportDataBase.setExportDate(shipExport.ExportDate);

    shipExportDataBase.setOrderDate(shipExport.OrderDate);
	shipExportDataBase.setFirstQty(shipExport.FirstQty);
	shipExportDataBase.setMajGroup(shipExport.MajGroup);
	shipExportDataBase.setMinGroup(shipExport.MinGroup);
	shipExportDataBase.setMinSales(shipExport.MinSales);
    shipExportDataBase.setMajSales(shipExport.MajSales);

    shipExportDataBase.setTradPartner(shipExport.TradPartner);
    shipExportDataBase.setShipToLoc(shipExport.ShipToLoc);
    shipExportDataBase.setCumQty(shipExport.CumQty);
    shipExportDataBase.setRan(shipExport.Ran);
    shipExportDataBase.setLTBookDate(shipExport.LTBookDate);
    shipExportDataBase.setLTBookQty(shipExport.LTBookQty);

    shipExportDataBase.setLastDateChange(shipExport.LastDateChange);
    shipExportDataBase.setLastQtyDateChange(shipExport.LastQtyDateChange);
    shipExportDataBase.setLastQtyChange(shipExport.LastQtyChange);
    shipExportDataBase.setCustPO(shipExport.CustPO);
    shipExportDataBase.setPpap(shipExport.Ppap);
    shipExportDataBase.setTrlp(shipExport.Trlp);
    shipExportDataBase.setEdiRelease(shipExport.EdiRelease);
    shipExportDataBase.setLeadTime(shipExport.LeadTime);
    shipExportDataBase.setLeadTime2(shipExport.LeadTime2);
    shipExportDataBase.setLeadTime3(shipExport.LeadTime3);

    shipExportDataBase.setReleaseBase(shipExport.ReleaseBase);
    shipExportDataBase.setQtyOrdBase(shipExport.QtyOrdBase);

    shipExportDataBase.setCumRequired(shipExport.CumRequired);
    shipExportDataBase.setQtyOrderedFromCum(shipExport.QtyOrderedFromCum);

    shipExportDataBase.setCumPrior(shipExport.CumPrior);
    shipExportDataBase.setQtyRequired(shipExport.QtyRequired);

    shipExportDataBase.setShipTo(shipExport.ShipTo);
    shipExportDataBase.setCreateDate(shipExport.CreateDate);
    shipExportDataBase.setTradPartner(shipExport.TradPartner);

    return shipExportDataBase;
}

public
ShipExport cloneShipExport(ShipExport shipExport){
	ShipExport shipExportClone = new ShipExport();

	shipExportClone.Site=shipExport.Site;
	shipExportClone.Bol=shipExport.Bol;
	shipExportClone.BolItem=shipExport.BolItem;
	shipExportClone.BillTo=shipExport.BillTo;
	shipExportClone.ShipTo=shipExport.ShipTo;
	shipExportClone.ShipDate=shipExport.ShipDate;
	shipExportClone.DateRequest=shipExport.DateRequest;
	shipExportClone.CreateDate=shipExport.CreateDate;
	shipExportClone.PostDate=shipExport.PostDate;
	shipExportClone.OrderNum=shipExport.OrderNum;
	shipExportClone.Item=shipExport.Item;
	shipExportClone.Release=shipExport.Release;
	shipExportClone.OrdType=shipExport.OrdType;
	shipExportClone.Product=shipExport.Product;
	shipExportClone.CustPart=shipExport.CustPart;
	shipExportClone.QtyShipped=shipExport.QtyShipped;
	shipExportClone.QtyBack=shipExport.QtyBack;
	shipExportClone.QtyExpec=shipExport.QtyExpec;
	shipExportClone.QtyOrder=shipExport.QtyOrder;
	shipExportClone.ProdType=shipExport.ProdType;
	shipExportClone.BackFlag=shipExport.BackFlag;
	shipExportClone.LineBookDate=shipExport.LineBookDate;
	shipExportClone.CustReqDate=shipExport.CustReqDate;
	shipExportClone.BackOrderFlag=shipExport.BackOrderFlag;
	shipExportClone.Market=shipExport.Market;
	shipExportClone.ExportDate=shipExport.ExportDate;

    shipExportClone.OrderDate= shipExport.OrderDate;
	shipExportClone.FirstQty = shipExport.FirstQty;
	shipExportClone.MajGroup = shipExport.MajGroup;
	shipExportClone.MinGroup = shipExport.MinGroup;
	shipExportClone.MinSales = shipExport.MinSales;
    shipExportClone.MajSales = shipExport.MajSales;

    shipExportClone.TradPartner  = shipExport.TradPartner;
    shipExportClone.ShipToLoc    = shipExport.ShipToLoc;
    shipExportClone.CumQty       = shipExport.CumQty;
    shipExportClone.Ran          = shipExport.Ran;
    shipExportClone.LTBookDate   = shipExport.LTBookDate;
    shipExportClone.LTBookQty    = shipExport.LTBookQty;

    shipExportClone.LastDateChange      =shipExport.LastDateChange;
    shipExportClone.LastQtyDateChange   =shipExport.LastQtyDateChange;
    shipExportClone.LastQtyChange       =shipExport.LastQtyChange;
    shipExportClone.CustPO              =shipExport.CustPO;
    shipExportClone.Ppap                =shipExport.Ppap;
    shipExportClone.ShipExportSource    =shipExport.ShipExportSource;
    shipExportClone.Trlp                =shipExport.Trlp;
    shipExportClone.EdiRelease          =shipExport.EdiRelease;
    shipExportClone.LeadTime            =shipExport.LeadTime;
    shipExportClone.LeadTime2           =shipExport.LeadTime2;
    shipExportClone.LeadTime3           =shipExport.LeadTime3;

    shipExportClone.ReleaseBase         =shipExport.ReleaseBase;
    shipExportClone.QtyOrdBase          =shipExport.QtyOrdBase;

    shipExportClone.CumRequired         =shipExport.CumRequired;
    shipExportClone.QtyOrderedFromCum   =shipExport.QtyOrderedFromCum;

    shipExportClone.CumPrior            =shipExport.CumPrior;
    shipExportClone.QtyRequired         =shipExport.QtyRequired;

    shipExportClone.ShipTo              =shipExport.ShipTo;
    shipExportClone.CreateDate          =shipExport.CreateDate;
    shipExportClone.TradPartner         =shipExport.TradPartner;
            
    return shipExportClone;
}

public
bool loadShipExportDtlsFromAS400(UpCum01PViewContainer upCum01PViewContainer){
    bool bresult=false;
    try{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

        TradingPartnerDataBaseContainer tradingPartnerDataBaseContainer = new TradingPartnerDataBaseContainer(dataBaseAccess);
        tradingPartnerDataBaseContainer.readByFilters("",0);

        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        loadShipExportDtlContainersBySqlSteps(upCum01PViewContainer,tradingPartnerDataBaseContainer);//load OCRIT/OCRRT which will be loaded/stored on ShipExportDtl

        bresult=true;

    }catch(PersistenceException persistenceException){
    	throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
    	throw new NujitException(exception.Message, exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE); 
    }
    return bresult;
}

public
bool loadShipExportReleasesFromAS400(UpCum01PViewContainer upCum01PViewContainer){
    bool bresult=false;
    try{
        
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        for (int i=0; i < upCum01PViewContainer.Count;i++){ 
            UpCum01PView upCum01PView= upCum01PViewContainer[i];
            load830Info(upCum01PView);                                            
        }
        bresult=true;

    }catch(PersistenceException persistenceException){
    	throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
    	throw new NujitException(exception.Message, exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE); 
    }
    return bresult;
}

private
void removeFixedManuals(UpCum01PViewContainer upCum01PViewContainer){
    dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE); 

    ShipExportSumDataBase   shipExportSumDataBase  = new ShipExportSumDataBase(dataBaseAccess); 

    for (int i=0; i < upCum01PViewContainer.Count; i++) { 
        UpCum01PView upCum01PView = upCum01PViewContainer[i];                        
           
        if (shipExportSumDataBase.existsFixManual(upCum01PView.FGORD, upCum01PView.FGITEM, upCum01PView.ReleaseBase)) {
            upCum01PViewContainer.RemoveAt(i);
            i--;
        }
    }
}

private
void loadCustLeadAndTradingPartner(out CustLeadDataBaseContainer custLeadDataBaseContainerGeneric,out Hashtable hashLeadsPerBillTo,out TradingPartnerDataBaseContainer tradingPartnerDataBaseContainer){
    custLeadDataBaseContainerGeneric= new CustLeadDataBaseContainer(dataBaseAccess);
    loadCustLeadHash(out hashLeadsPerBillTo,out custLeadDataBaseContainerGeneric);

    tradingPartnerDataBaseContainer = new TradingPartnerDataBaseContainer(dataBaseAccess);
    tradingPartnerDataBaseContainer.read();
}

public
ShipExportContainer reprocessShipExportSum(ShipExportSumContainer shipExportSumContainerProcess){
    try{       
        ShipExportSumContainer          shipExportSumContainer      = new ShipExportSumContainer();
        ShipExportSum                   shipExportSum               = null;
        ShipExportContainer             shipExportContainer         = new ShipExportContainer();
        UpCum01PViewContainer           upCum01PViewContainer       = new UpCum01PViewContainer();
        UpCum01PViewContainer           upCum01PViewContainerSearch = new UpCum01PViewContainer();
        int                             i=0;

        CustLeadDataBaseContainer       custLeadDataBaseContainerGeneric= new CustLeadDataBaseContainer(dataBaseAccess);
        Hashtable                       hashLeadsPerBillTo              = new Hashtable();
        TradingPartnerDataBaseContainer tradingPartnerDataBaseContainer = new TradingPartnerDataBaseContainer(dataBaseAccess);

        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

        loadCustLeadAndTradingPartner(out custLeadDataBaseContainerGeneric,out hashLeadsPerBillTo,out tradingPartnerDataBaseContainer);

        //first we check what records could be adjusted
        for (i=0; i < shipExportSumContainerProcess.Count; i++){
            shipExportSum= shipExportSumContainerProcess[i];
            if (!fixedManual(shipExportSum))
                shipExportSumContainer.Add(shipExportSum);
        }      

        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        //try to load each upCum01PView record for each ShipExportSum
        for (i=0; i < shipExportSumContainer.Count; i++){
            shipExportSum= shipExportSumContainer[i];
            upCum01PViewContainerSearch = readUpCum01PCustomByFiltersInt(hashLeadsPerBillTo,custLeadDataBaseContainerGeneric,tradingPartnerDataBaseContainer,
                shipExportSum.Site,"", shipExportSum.BillTo,"","", shipExportSum.OrderNum.ToString(),"","","","",shipExportSum.Release, shipExportSum.Item,
                false,"",DateUtil.MinValue,DateUtil.MinValue,1);

            if (upCum01PViewContainerSearch.Count > 0)
                upCum01PViewContainer.Add(upCum01PViewContainerSearch[0]);
        }

        shipExportContainer = bolsShipExport(upCum01PViewContainer);

        return shipExportContainer;

	}catch(PersistenceException persistenceException){
     	throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
     	throw new NujitException(exception.Message, exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE); 
    }
}

private
bool fixedManual(ShipExportSum shipExportSum){
    ShipExportSumDataBase shipExportSumDataBase = new ShipExportSumDataBase(dataBaseAccess);    
    return shipExportSumDataBase.existsFixManual(shipExportSum.OrderNum, shipExportSum.Item, shipExportSum.Release);
}


private
bool fixedManual(ShipExport shipExport){
    ShipExportSumDataBase shipExportSumDataBase = new ShipExportSumDataBase(dataBaseAccess);    
    return shipExportSumDataBase.existsFixManual(shipExport.OrderNum,shipExport.Item,shipExport.ReleaseBase);
}

public
ShipExportContainer bolsShipExport(UpCum01PViewContainer upCum01PViewContainerProcess){
    bool   btranscationStarted=false;

	try{
        UpCum01PViewContainer   upCum01PViewContainer   = new UpCum01PViewContainer();
        ShipExportContainer     shipExportContainer = new ShipExportContainer();
        ShipExport              shipExport= null;
        int                     i=0;
        ShipExportSumContainer  shipExportSumContainer = new ShipExportSumContainer();
    
        foreach(UpCum01PView upCum01PViewAux in upCum01PViewContainerProcess)
            upCum01PViewContainer.Add(upCum01PViewAux);
                       
        removeFixedManuals(upCum01PViewContainer);
        loadShipExportDtlsFromAS400(upCum01PViewContainer);//load OCRIT/OCRRT which will be loaded/stored on ShipExportDtl        
       
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE); 
        for (i=0; i < upCum01PViewContainer.Count; i++) { 
            UpCum01PView upCum01PView = upCum01PViewContainer[i];
            
            shipExport = new ShipExport();
            shipExport.copy(upCum01PView);                                                   
            upCum01PView.ShipExport = shipExport;
            if (!fixedManual(shipExport))
                shipExportContainer.Add(shipExport);
        }

        //load summary
        shipExportSumContainer = loadShipExportSumContainer(upCum01PViewContainer);
                
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE); 

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        btranscationStarted=true;
        for (i=0; i < shipExportContainer.Count; i++) { 
            shipExport = shipExportContainer[i];

            if (!fixedManual(shipExport)) { 
                if (existsShipExport(shipExport.Site, shipExport.Bol, shipExport.BolItem))
                    updateShipExportInt(shipExport);
                else
                    writeShipExportInt(shipExport);            
            }
        }
             
        for (i=0; i < shipExportSumContainer.Count; i++) { //write summaries
            ShipExportSum shipExportSum = shipExportSumContainer[i];

            if (existsShipExportSum(shipExportSum.OrderNum,shipExportSum.Item,shipExportSum.Release))
                updateShipExportSumInt(shipExportSum);
            else
                writeShipExportSumInt(shipExportSum);
        }

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

        return shipExportContainer;

	}catch(PersistenceException persistenceException){
        if (btranscationStarted && !userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
        if (btranscationStarted && !userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE); 
    }
}

public
void loadShipExportToUpCum01PList(UpCum01PViewContainer upCum01PViewContainer){
	try{        
        int                             i=0;        
        ShipExportDataBaseContainer     shipExportDataBaseContainer = new ShipExportDataBaseContainer(dataBaseAccess);
        Hashtable                       hashKeys = new Hashtable();
        ArrayList                       arrayBolIds= new ArrayList();        
        string                          skey="";
        UpCum01PView                    upCum01PView = null;

        for (i= 0;i < upCum01PViewContainer.Count;i++) { 
            upCum01PView            = upCum01PViewContainer[i];
            upCum01PView.ExportShow =Constants.STRING_NO;

            arrayBolIds.Add(upCum01PView.FGBOL);    
            
            //load on hash so later we can access quickly
            skey = upCum01PView.FEPLTC.ToUpper() +  Constants.DEFAULT_SEP + Convert.ToInt32(upCum01PView.FGBOL).ToString() + 
                                                    Constants.DEFAULT_SEP + Convert.ToInt32(upCum01PView.FGENT).ToString();
            if (!hashKeys.Contains(skey))
                hashKeys.Add(skey, upCum01PView);            
        }
        
        if (upCum01PViewContainer.Count < 1000)     //check because if so match records sql could give an error, because of length of sql                                       
            shipExportDataBaseContainer.readByBolIds(arrayBolIds);
        else
            shipExportDataBaseContainer.read();
        
        foreach(ShipExportDataBase shipExportDataBase in shipExportDataBaseContainer){
            skey = shipExportDataBase.getSite().ToUpper() + Constants.DEFAULT_SEP + Convert.ToInt32(shipExportDataBase.getBol()).ToString() + 
                                                            Constants.DEFAULT_SEP + Convert.ToInt32(shipExportDataBase.getBolItem()).ToString();
            if (hashKeys.Contains(skey)) {
                upCum01PView = (UpCum01PView)hashKeys[skey];

                upCum01PView.ExportShow     =Constants.STRING_YES;
                upCum01PView.ExportDateShow = shipExportDataBase.getExportDate();
                upCum01PView.Included       =Constants.STRING_NO; //by default not included , because already exported 

                upCum01PView.LeadTime2      = shipExportDataBase.getLeadTime2();
                upCum01PView.LeadTime3      = shipExportDataBase.getLeadTime3();
            }
        }                

    } catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);  
    }
}
        
private
ShipExportDtl objectDataBaseToObject(ShipExportDtlDataBase shipExportDtlDataBase){
	ShipExportDtl shipExportDtl = new ShipExportDtl();

	shipExportDtl.Site=shipExportDtlDataBase.getSite();
	shipExportDtl.Bol=shipExportDtlDataBase.getBol();
	shipExportDtl.BolItem=shipExportDtlDataBase.getBolItem();
	shipExportDtl.Detail=shipExportDtlDataBase.getDetail();
	shipExportDtl.OrderNum=shipExportDtlDataBase.getOrderNum();
	shipExportDtl.Item=shipExportDtlDataBase.getItem();
	shipExportDtl.Release=shipExportDtlDataBase.getRelease();
	shipExportDtl.TimeStamp=shipExportDtlDataBase.getTimeStamp();
	shipExportDtl.Action=shipExportDtlDataBase.getAction();
	shipExportDtl.RelDate=shipExportDtlDataBase.getRelDate();
	shipExportDtl.RelQtyInvUnit=shipExportDtlDataBase.getRelQtyInvUnit();
	shipExportDtl.QtyShippedInv=shipExportDtlDataBase.getQtyShippedInv();
	shipExportDtl.QtyBackInv=shipExportDtlDataBase.getQtyBackInv();
	shipExportDtl.DateRequest=shipExportDtlDataBase.getDateRequest();
	shipExportDtl.ShipDate=shipExportDtlDataBase.getShipDate();
	shipExportDtl.Ran=shipExportDtlDataBase.getRan();

    shipExportDtl.User= shipExportDtlDataBase.getUser();

	return shipExportDtl;
}

private
ShipExportDtlDataBase objectToObjectDataBase(ShipExportDtl shipExportDtl){
	ShipExportDtlDataBase shipExportDtlDataBase = new ShipExportDtlDataBase(dataBaseAccess);
	shipExportDtlDataBase.setSite(shipExportDtl.Site);
	shipExportDtlDataBase.setBol(shipExportDtl.Bol);
	shipExportDtlDataBase.setBolItem(shipExportDtl.BolItem);
	shipExportDtlDataBase.setDetail(shipExportDtl.Detail);
	shipExportDtlDataBase.setOrderNum(shipExportDtl.OrderNum);
	shipExportDtlDataBase.setItem(shipExportDtl.Item);
	shipExportDtlDataBase.setRelease(shipExportDtl.Release);
	shipExportDtlDataBase.setTimeStamp(shipExportDtl.TimeStamp);
	shipExportDtlDataBase.setAction(shipExportDtl.Action);
	shipExportDtlDataBase.setRelDate(shipExportDtl.RelDate);
	shipExportDtlDataBase.setRelQtyInvUnit(shipExportDtl.RelQtyInvUnit);
	shipExportDtlDataBase.setQtyShippedInv(shipExportDtl.QtyShippedInv);
	shipExportDtlDataBase.setQtyBackInv(shipExportDtl.QtyBackInv);
	shipExportDtlDataBase.setDateRequest(shipExportDtl.DateRequest);
	shipExportDtlDataBase.setShipDate(shipExportDtl.ShipDate);
	shipExportDtlDataBase.setRan(shipExportDtl.Ran);
    shipExportDtlDataBase.setUser(shipExportDtl.User);

	return shipExportDtlDataBase;
}

public
ShipExportDtl cloneShipExportDtl(ShipExportDtl shipExportDtl){
	ShipExportDtl shipExportDtlClone = new ShipExportDtl();

	shipExportDtlClone.Site=shipExportDtl.Site;
	shipExportDtlClone.Bol=shipExportDtl.Bol;
	shipExportDtlClone.BolItem=shipExportDtl.BolItem;
	shipExportDtlClone.Detail=shipExportDtl.Detail;
	shipExportDtlClone.OrderNum=shipExportDtl.OrderNum;
	shipExportDtlClone.Item=shipExportDtl.Item;
	shipExportDtlClone.Release=shipExportDtl.Release;
	shipExportDtlClone.TimeStamp=shipExportDtl.TimeStamp;
	shipExportDtlClone.Action=shipExportDtl.Action;
	shipExportDtlClone.RelDate=shipExportDtl.RelDate;
	shipExportDtlClone.RelQtyInvUnit=shipExportDtl.RelQtyInvUnit;
	shipExportDtlClone.QtyShippedInv=shipExportDtl.QtyShippedInv;
	shipExportDtlClone.QtyBackInv=shipExportDtl.QtyBackInv;
	shipExportDtlClone.DateRequest=shipExportDtl.DateRequest;
	shipExportDtlClone.ShipDate=shipExportDtl.ShipDate;
	shipExportDtlClone.Ran=shipExportDtl.Ran;
    shipExportDtlClone.User=shipExportDtl.User;

	return shipExportDtlClone;
}

private
string getOrderKey(decimal orderNum,decimal item,string relase){
    string skey =   Convert.ToInt64(orderNum).ToString()  + Constants.DEFAULT_SEP + 
                    Convert.ToInt64(item).ToString()      + Constants.DEFAULT_SEP + relase.ToUpper();
    return skey;    

}

private
void loadShipExportDtlContainerNew(Hashtable hashShipExportDtlsPerOrder, ShipExportDtlDataBaseContainer shipExportDtlDataBaseContainer){       
    ShipExportDtlContainer  shipExportDtlContainer = new ShipExportDtlContainer();
    ShipExportDtl           shipExportDtl = null;
    string                  skey = "";

    foreach (ShipExportDtlDataBase shipExportDtlDataBase in shipExportDtlDataBaseContainer) {
        shipExportDtl= objectDataBaseToObject(shipExportDtlDataBase);

        skey = getOrderKey(shipExportDtl.OrderNum,shipExportDtl.Item,shipExportDtl.Release);                    
        if (hashShipExportDtlsPerOrder.Contains(skey))
            shipExportDtlContainer = (ShipExportDtlContainer)hashShipExportDtlsPerOrder[skey];
        else{
            shipExportDtlContainer = new ShipExportDtlContainer();
            hashShipExportDtlsPerOrder.Add(skey,shipExportDtlContainer);
        }
        shipExportDtlContainer.Add(shipExportDtl);
    }
}

private
void copyContainer( ShipExportDtlContainer shipExportDtlContainer,
                    ShipExportDtlContainer shipExportDtlContainerCopyFrom){
    foreach(ShipExportDtl shipExportDtlAux in shipExportDtlContainerCopyFrom)
        shipExportDtlContainer.Add(shipExportDtlAux);              
}

private
void loadShipExportDtlByProperlyOrderNew(Hashtable hashShipExportDtlsPerOrder,UpCum01PView upCum01PView,string stpartner){    
    ShipExportDtlContainer  shipExportDtlContainer      = new ShipExportDtlContainer();  
    ShipExportDtlContainer  shipExportDtlContainerAux   = new ShipExportDtlContainer();               
    string                  skey                    = getOrderKey(upCum01PView.FGORD,upCum01PView.FGITEM,upCum01PView.FGRLNO);
    ArrayList               arrayRels               = new ArrayList();
    DateTime                maxShipDate             = DateUtil.MinValue;
    bool                    borderModeProcessed     = true;
    
    if (hashShipExportDtlsPerOrder.Contains(skey))  //current release
        shipExportDtlContainer = (ShipExportDtlContainer)hashShipExportDtlsPerOrder[skey];        
    
    maxShipDate = shipExportDtlContainer.getMaxShipDate();
    shipExportDtlContainer.removeDateTimeStampsRecordMinorThanShipDays(maxShipDate,90);
    shipExportDtlContainer.removeRecsWithNoChanges();

    if (upCum01PView.DCOTYP.Equals("B")) { //only for blanket orders
        shipExportDtlContainer.Clear();

        if (upCum01PView.Trlp.Equals(Constants.STRING_YES)) {         
            borderModeProcessed     = false;
            switch(upCum01PView.ShipExportSource){
                case ShipExport.EXPORT_830:     shipExportDtlContainer = load830Info(upCum01PView); //only new code
                                                break;
                case ShipExport.EXPORT_862:     shipExportDtlContainer = load862Info(upCum01PView);
                                                break;
                case ShipExport.EXPORT_862_RAN: shipExportDtlContainer = load862RanInfo(upCum01PView);
                                                break;                        
                default:
                    borderModeProcessed     = true;
                    shipExportDtlContainer  = loadOrderInfo(upCum01PView);              
                    break;
            }                                           
        }else
            shipExportDtlContainer = loadOrderInfo(upCum01PView);
    }        
           
    shipExportDtlContainer.sortByOrderItemTimeStamp(true);
    upCum01PView.ShipExportDtlContainer = shipExportDtlContainer;
    upCum01PView.searchByDateLoadLTBookQty();
    if (!borderModeProcessed) 
        upCum01PView.ShipExportDtlContainer.calculateDaysShipChanged();
    else { 
        upCum01PView.LastDateChange = upCum01PView.ShipExportDtlContainer.calculateQtyChange(upCum01PView.FGRLNO);    
        shipExportDtlContainer.removeRecsWithNoChanges();   
    }                                    
    shipExportDtlContainer.fillDetails();
}

public
ShipExportContainer processShipExportAutomatically(string splant){
    ShipExportContainer     shipExportContainer = new ShipExportContainer();
    try { 
        //DateTime                fromDate = DateTime.Now.AddMonths(-3);
        //DateTime                toDate = DateTime.Now;
        UpCum01PViewContainer   upCum01PViewContainerToBeExported = new UpCum01PViewContainer();
        LastExported            lastExported = readLastExported(LastExported.LAST_SHIPEXPORT);
        UpCum01PView            upCum01PViewLast = null;

        if (lastExported == null){
            lastExported            = new LastExported();          
            lastExported.Code       = LastExported.LAST_SHIPEXPORT;
            lastExported.LastProces = DateTime.Now;
        }

        UpCum01PViewContainer upCum01PViewContainer = readUpCum01PCustomByFilters(splant,"","", "","","","","",Constants.STRING_YES,"","",0,false,"",lastExported.LastProces.AddDays(-1),DateTime.Now.AddDays(1), 0);        

        if (upCum01PViewContainer.Count > 0) {     

            loadShipExportToUpCum01PList(upCum01PViewContainer);

            foreach(UpCum01PView upCum01PView in upCum01PViewContainer) {//load records to be exported
                if (upCum01PView.Included.Equals(Constants.STRING_YES))
                    upCum01PViewContainerToBeExported.Add(upCum01PView);
            }

            if (upCum01PViewContainerToBeExported.Count > 0) { 
                upCum01PViewLast = upCum01PViewContainerToBeExported[0];
                shipExportContainer =  bolsShipExport(upCum01PViewContainerToBeExported);
            }
        }
        
        if (lastExported != null){
            lastExported.LastProces = DateTime.Now;
            lastExported.LastId     =   upCum01PViewLast== null ? lastExported.LastId :
                                        (Convert.ToInt32(upCum01PViewLast.FGBOL).ToString() + "-" + Convert.ToInt32(upCum01PViewLast.FGENT).ToString()); 
                                        
            if (existsLastExported(lastExported.Code))
                updateLastExported(lastExported);
            else
                writeLastExported(lastExported);
        }

    } catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);  
    }
    return shipExportContainer;
}

        /*
public
int loadCustPOToShipExport(){
    int icounter=0;    
    try { 

        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        BoldDataBaseContainer boldDataBaseContainer = new BoldDataBaseContainer(dataBaseAccess);
        boldDataBaseContainer.readAllloadCustPOs();

        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
        bool    btransOpen=false;

        System.Windows.Forms.MessageBox.Show("All Bold Reads:" + boldDataBaseContainer.Count);        

        foreach(BoldDataBase boldDataBase in boldDataBaseContainer) { 
            ShipExportDataBase shipExportDataBase = new ShipExportDataBase(dataBaseAccess);           
                                        
            shipExportDataBase.setBol(boldDataBase.getFGBOL());
            shipExportDataBase.setBolItem(boldDataBase.getFGENT());
            if (shipExportDataBase.existsBolIds()){
               
                if ((icounter % 1000) == 0 ){                     
			        dataBaseAccess.beginTransaction();
                    btransOpen=true;
                }
                shipExportDataBase.setBol(boldDataBase.getFGBOL());
                shipExportDataBase.setBolItem(boldDataBase.getFGENT());
                shipExportDataBase.setCustPO(boldDataBase.getFGCPO());
                shipExportDataBase.updateCustPO();
                icounter++;

                 
                if ((icounter % 1000) == 0 ){ 
                    dataBaseAccess.commitTransaction();
                    btransOpen=false;
                }
            }            
        }

        //if (btransOpen)          
		    //dataBaseAccess.commitTransaction();

        System.Windows.Forms.MessageBox.Show("CustPo Updated:" + icounter.ToString());        

    } catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);  
    }    
    return icounter;
}
        */
public
int loadCustPOToShipExport(){
    int icounter=0;    
    try { 

        ArrayList   arrayFound = new ArrayList();
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);    
        ShipExportDataBaseContainer shipExportDataBaseContainer = new ShipExportDataBaseContainer(dataBaseAccess);
        shipExportDataBaseContainer.read();
                
        System.Windows.Forms.MessageBox.Show("All Ship Exports:" + shipExportDataBaseContainer.Count);        

        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
                
        for (int i=0; i < shipExportDataBaseContainer.Count;i++) { 
            ShipExportDataBase shipExportDataBase =(ShipExportDataBase)shipExportDataBaseContainer[i];

            BoldDataBaseContainer boldDataBaseContainer = new BoldDataBaseContainer(dataBaseAccess);
            boldDataBaseContainer.readAllloadCustPOs(shipExportDataBase.getBol(), shipExportDataBase.getBolItem());
            if (boldDataBaseContainer.Count > 0){

                BoldDataBase boldDataBase = (BoldDataBase)boldDataBaseContainer[0];                                                   
                shipExportDataBase.setBol(boldDataBase.getFGBOL());
                shipExportDataBase.setBolItem(boldDataBase.getFGENT());
                shipExportDataBase.setCustPO(boldDataBase.getFGCPO());
                arrayFound.Add(shipExportDataBase);                
                icounter++;

                if (icounter == 100){ 
                    System.Windows.Forms.MessageBox.Show("CustPo Found:" + icounter.ToString());     
                }    
            }    
        }

        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE); 
        
        for (int i=0; i < arrayFound.Count;i++) { 
            ShipExportDataBase shipExportDataBase =(ShipExportDataBase)arrayFound[i];
            shipExportDataBase.updateCustPO();
        }
        

        System.Windows.Forms.MessageBox.Show("CustPo Updated:" + icounter.ToString());        

    } catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);  
    }    
    return icounter;
}

private
bool tryLoadRrldRrldm(out RrldDataBase rrldDataBase,out RrldmDataBaseContainer rrldmDataBaseContainerOut, UpCum01PView upCum01PView,string stpartner,decimal dkeyNum,string scurrRelease){
    bool                    bresult = false;
    RrldDataBaseContainer   rrldDataBaseContainer = new RrldDataBaseContainer(dataBaseAccess);
    RrldmDataBaseContainer  rrldmDataBaseContainer= new RrldmDataBaseContainer(dataBaseAccess);
    
    rrldDataBase = null;    
    rrldmDataBaseContainerOut=null;

    rrldDataBaseContainer.readByFilters(stpartner,upCum01PView.FGCPT,dkeyNum,scurrRelease,DateUtil.MinValue,">",upCum01PView.FGPCUM,"PLQCUM",1);  
    if (rrldDataBaseContainer.Count > 0) {         
        rrldDataBase = (RrldDataBase)rrldDataBaseContainer[0];
        bresult = true;
    }
        
    rrldmDataBaseContainer.readByFilters(stpartner,upCum01PView.FGCPT,dkeyNum,scurrRelease,">",upCum01PView.FGPCUM, "BJ0QCUM",0);
    if (rrldmDataBaseContainer.Count > 0 && rrldDataBase!= null) {                                 
        RrldmContainer  rrldmContainerAux   = new RrldmContainer(); //order by time stamp
        RrldmContainer  rrldmContainer      = new RrldmContainer(); //order by time stamp
        Rrldm           rrldm               = null;
        Rrldm           rrldmNext           = null;
        string          stimeCFound         = "";
        
        for (int i=0; i < rrldmDataBaseContainer.Count; i++){
            RrldmDataBase rrldmDataBaseAux  = (RrldmDataBase)rrldmDataBaseContainer[i];
            if (rrldmDataBaseAux.getBJ0ITYP().Equals("1") || rrldmDataBaseAux.getBJ0ITYP().Equals("2"))
                rrldmContainerAux.Add(objectDataBaseToObject(rrldmDataBaseAux));            
        }
        rrldmContainerAux.sortByTimeStamp();

        for (int i=0; i < rrldmContainerAux.Count; i++){
            rrldm       = rrldmContainerAux[i];
            rrldmNext   = (i+1) < rrldmContainerAux.Count ? rrldmContainerAux[i+1] : null;

            if (rrldmNext!= null && rrldm.BJ0ITYP.Equals("1") && rrldmNext.BJ0ITYP.Equals("2")  &&  //if 1 and 2 pair sequence
                rrldm.BJ0TIMC.Equals(rrldmNext.BJ0TIMC) && DateUtil.sameDate(rrldDataBase.getPLRDAT(),rrldmNext.BJ0RDAT)) //same timec
                rrldmContainer.Add(rrldm);
        }

        for (int i=0; i < rrldmContainer.Count; i++){
            if (i == 0)
                rrldmDataBaseContainerOut = new RrldmDataBaseContainer(dataBaseAccess);
            rrldmDataBaseContainerOut.Add(objectToObjectDataBase(rrldmContainer[i]));
        }                        
    }

    return bresult;
}

private
ShipExportDtlContainer load830Info(UpCum01PView upCum01PView){        
    TrlpDataBase                trlpDataBase                = null;    
    RrlhDataBase                rrlhDataBase                = new RrlhDataBase(dataBaseAccess);
    RrlhDataBase                rrlPriorhDataBase           = new RrlhDataBase(dataBaseAccess);
    RrldDataBaseContainer       rrldDataBaseContainer       = new RrldDataBaseContainer(dataBaseAccess);
    RrldDataBaseContainer       rrldPriorDataBaseContainer  = new RrldDataBaseContainer(dataBaseAccess);
    RrldmDataBaseContainer      rrldmDataBaseContainer      = new RrldmDataBaseContainer(dataBaseAccess);
    RrldDataBase                rrldDataBase                = null;            
    
    string                      stpartner                   = "";
    string                      scurrRelease                = upCum01PView.FGCREL;        
    string                      spriorRelease               = "";        
    StxhDataBase                stxhDataBase                = new StxhDataBase(dataBaseAccess);
    decimal                     dkeyNum                     = 0;//rrlhDataBase!= null ? rrlhDataBase.getOZKEYN(): 0;
    decimal                     dlogNum                     = 0;//rrlhDataBase!= null ? rrlhDataBase.getOZLOG() : 0;
    string                      shipLoc                     = "";
    string                      scustPO                     = "";
    
    upCum01PView.ShipExportReleaseContainer.Clear();

    trlpDataBase = getCustTPartner(upCum01PView.FEBCS,upCum01PView.FESCS,upCum01PView.FGORD, upCum01PView.FGITEM,out stpartner,out shipLoc);
    if (trlpDataBase!= null) {     
        dkeyNum = trlpDataBase.getSMCKEY();
        
        if (!string.IsNullOrEmpty(stpartner)) { 
            bool        bprocess    = true;
            int         icounter    = 0;
            DateTime    startDate   = upCum01PView.FESDAT;
            DateTime    lastDate    = upCum01PView.FESDAT.AddDays(-90);

            scurrRelease= upCum01PView.FGCREL;
            rrlhDataBase= loadRrlh(dkeyNum,stpartner,scurrRelease,shipLoc,upCum01PView.FGCPT);
                        
            dkeyNum     = rrlhDataBase!= null ? rrlhDataBase.getOZKEYN(): 0;
            dlogNum     = rrlhDataBase!= null ? rrlhDataBase.getOZLOG() : 0;            
            scustPO     = upCum01PView.FGCPO;

            bprocess    = tryLoadRrldRrldm(out rrldDataBase,out rrldmDataBaseContainer,upCum01PView,stpartner,dkeyNum,scurrRelease);                               
            stxhDataBase= loadStxh(upCum01PView,dlogNum,stpartner,scurrRelease,"",shipLoc,scustPO);
            loadShipExportReleaseInfo(upCum01PView,rrlhDataBase,rrldDataBase, rrldmDataBaseContainer, stxhDataBase);
    
            do {
                rrlhDataBase= null;
                rrldDataBase= null;
                rrldmDataBaseContainer = null;
                stxhDataBase= null;
                bprocess    = rrlPriorhDataBase.getPriorRelease(stpartner,scurrRelease,shipLoc,upCum01PView.FGCPT);

                if (bprocess){ //rrlhDataBase.getPriorRelease(stpartner, scurrRelease, upCum01PView.FGCPT, upCum01PView.FGCCUM)){
                    rrlhDataBase= rrlPriorhDataBase;
                    spriorRelease = rrlhDataBase.getOZREL();

                    dkeyNum     = rrlhDataBase!= null ? rrlhDataBase.getOZKEYN(): 0;
                    dlogNum     = rrlhDataBase!= null ? rrlhDataBase.getOZLOG() : 0;                
                    scustPO     = rrlhDataBase!= null ? rrlhDataBase.getOZCPO() : scustPO;

                    tryLoadRrldRrldm(out rrldDataBase,out rrldmDataBaseContainer, upCum01PView,stpartner,dkeyNum,rrlhDataBase.getOZREL());                
                }
            
                if (bprocess)
                    stxhDataBase= loadStxh(upCum01PView,dlogNum,stpartner,spriorRelease,"",shipLoc,scustPO);             
                        
                scurrRelease = spriorRelease;                        
                if (bprocess)
                    loadShipExportReleaseInfo(upCum01PView,rrlhDataBase,rrldDataBase, rrldmDataBaseContainer, stxhDataBase);

                if (stxhDataBase!= null && stxhDataBase.getOYCDAT() < startDate.AddDays(-90))
                    bprocess=false;
            
                //if (bprocess)                
                    //bprocess=!loadDetailsBasedOn830Info(upCum01PView,false);  //if date changed and qty changed found, stop loop            
                icounter++;

            } while (icounter < ShipExport.IMAX_EXPORT_LOOP_COUNTER && bprocess); //bprocess);
                
            //862
            //jitdDataBaseContainer.readByFilters(stpartner, upCum01PView.FGCPT, 0, upCum01PView.FGCREL,"", upCum01PView.FGCCUM,1);
        }
            
        loadDetailsBasedOn830Info(upCum01PView,true);
    }
    return upCum01PView.ShipExportDtlContainer;
}

private
bool loadDetailsBasedOn830Info(UpCum01PView upCum01PView,bool bloadShippedRecord){
    ShipExportDtlContainer          shipExportDtlContainer          = new ShipExportDtlContainer();    
    ShipExportRelease               shipExportRelease               = null;
    ShipExportRelease               shipExportReleaseNext           = null;
    ShipExportRelease               shipExportReleaseDataChange     = null;
    ShipExportRelease               shipExportReleaseQtyChange      = null;
    ShipExportDtlDataBaseContainer  shipExportDtlDataBaseContainer  = new ShipExportDtlDataBaseContainer(dataBaseAccess);
    ShipExportReleaseContainer      shipExportReleaseContainerClone = new ShipExportReleaseContainer();

    DateTime                        lastDateChangeFound             = DateUtil.MinValue;
    DateTime                        lastQtyDateChangeFound          = DateUtil.MinValue;
    decimal                         lastQtyChangeFound              = 0;         

    upCum01PView.ShipExportDtlContainer.Clear();
        
    if (bloadShippedRecord) { 
        //get shipped record from OCRRT
        shipExportDtlDataBaseContainer.getlOCRRTShippedRecord(upCum01PView.FGORD, upCum01PView.FGITEM, upCum01PView.FGRLNO);
        if (shipExportDtlDataBaseContainer.Count > 0)        
            shipExportDtlContainer.Add(objectDataBaseToObject((ShipExportDtlDataBase)shipExportDtlDataBaseContainer[0]));           
    }
            
    upCum01PView.ShipExportReleaseContainer.fillDetails();
    upCum01PView.ShipExportReleaseContainer.sortByTimeStamp(false);//show sorted on UI too

    for (int i=0; i < upCum01PView.ShipExportReleaseContainer.Count;i++)
        shipExportReleaseContainerClone.Add(cloneShipExportRelease(upCum01PView.ShipExportReleaseContainer[i]));
    shipExportReleaseContainerClone.sortByTimeStamp(false);

    for (int i=0; i < shipExportReleaseContainerClone.Count && (shipExportReleaseDataChange== null || shipExportReleaseQtyChange == null); i++){
        shipExportRelease       = shipExportReleaseContainerClone[i];
        shipExportReleaseNext   = (i+1) < shipExportReleaseContainerClone.Count ? shipExportReleaseContainerClone[i+1] : null;

        if (shipExportReleaseNext!= null){
            if (shipExportReleaseDataChange== null && !DateUtil.sameDate(shipExportReleaseNext.RelDate,shipExportRelease.RelDate))                
                shipExportReleaseDataChange = shipExportRelease;

            if (upCum01PView.ShipExportSource.Equals(ShipExport.EXPORT_862_RAN)){ 
                if (shipExportReleaseQtyChange== null && shipExportReleaseNext.RelQty != shipExportRelease.RelQty)
                    shipExportReleaseQtyChange = shipExportRelease;    
            }else if (shipExportReleaseQtyChange== null && shipExportReleaseNext.RelCum != shipExportRelease.RelCum)                
                shipExportReleaseQtyChange = shipExportRelease;        
        }
    }

    if (shipExportReleaseDataChange == null && upCum01PView.ShipExportSource.Equals(ShipExport.EXPORT_862_RAN)  && shipExportReleaseContainerClone.Count > 0)//if not date changed, we get from last value
        shipExportReleaseDataChange = shipExportReleaseContainerClone[shipExportReleaseContainerClone.Count-1];
    
    if (shipExportReleaseDataChange!= null) { //add date changed if found
        shipExportDtlContainer.Add(convertShipExportReleaseToShipExportDtl(upCum01PView,shipExportReleaseDataChange));
        upCum01PView.LastDateChange = shipExportReleaseDataChange.StDateCreated;
        
        ShipExportRelease shipExportReleaseAux = upCum01PView.ShipExportReleaseContainer.getByDetail(shipExportReleaseDataChange.Detail);
        if (shipExportReleaseAux!= null)
            shipExportReleaseAux.BDateChangeShow=true;
    }

    if (shipExportReleaseQtyChange == null && upCum01PView.ShipExportSource.Equals(ShipExport.EXPORT_862_RAN) && shipExportReleaseContainerClone.Count > 0)//if not changes on qty, we get from last value
        shipExportReleaseQtyChange = shipExportReleaseContainerClone[shipExportReleaseContainerClone.Count-1];
    
    if (shipExportReleaseQtyChange != null) {//add qty changed if found
        if (shipExportReleaseDataChange == null || shipExportReleaseDataChange.Detail != shipExportReleaseQtyChange.Detail) //just in case same record
            shipExportDtlContainer.Add(convertShipExportReleaseToShipExportDtl(upCum01PView, shipExportReleaseQtyChange));

        upCum01PView.LastQtyChange     = shipExportReleaseQtyChange.RelQty;
        upCum01PView.LastQtyDateChange = shipExportReleaseQtyChange.StDateCreated;

        ShipExportRelease shipExportReleaseAux = upCum01PView.ShipExportReleaseContainer.getByDetail(shipExportReleaseQtyChange.Detail);
        if (shipExportReleaseAux!= null)
            shipExportReleaseAux.BQtyChangeShow=true;
    }
    
    upCum01PView.ShipExportDtlContainer = shipExportDtlContainer;    
    upCum01PView.fillRedundances();

    return shipExportReleaseDataChange!= null && shipExportReleaseQtyChange != null;
}

private
ShipExportDtl convertShipExportReleaseToShipExportDtl(UpCum01PView upCum01PView,ShipExportRelease shipExportRelease) {
    ShipExportDtl  shipExportDtl   = new ShipExportDtl();

    shipExportDtl.TimeStamp     =   DateUtil.getCompleteDateRepresentation(shipExportRelease.StDateCreated,DateUtil.YYYYMMDD).Replace('/','-').Replace(':','.').Replace(' ','-');
    shipExportDtl.RelDate       =   shipExportRelease.RelDate;

    shipExportDtl.DateRequest   =   shipExportRelease.RelDate;
    shipExportDtl.ShipDate      =   shipExportRelease.RelDate;

    shipExportDtl.RelQtyInvUnit =   shipExportRelease.RelQty;
    shipExportDtl.Ran           =   shipExportRelease.Ran;

    shipExportDtl.OrderNum      =   upCum01PView.FGORD;   //order info
    shipExportDtl.Item          =   upCum01PView.FGITEM;

    return shipExportDtl;
}

private
ShipExportDtlContainer loadOrderInfo(UpCum01PView upCum01PView){
    ShipExportDtlContainer  shipExportDtlContainer      = new ShipExportDtlContainer();  
    ShipExportDtlContainer  shipExportDtlContainerAux   = new ShipExportDtlContainer();               
    
    ArrayList               arrayRels               = new ArrayList();
    DateTime                maxShipDate             = DateUtil.MinValue;
    int                     i                       = 0;
    ShipExportDtl           shipExportDtl           = null;
    ShipExportDtl           shipExportDtlAdd        = null;    
    string                  sadd                    = "4"; //actions
    string                  sdel                    = "3";
    string                  spriorRelease           = "";

    //get last difference on qty
    ShipExportDtlDataBaseContainer shipExportDtlDataBaseContainerDiffQty = new ShipExportDtlDataBaseContainer(dataBaseAccess);
    shipExportDtlDataBaseContainerDiffQty.getlOCRRTDifferentQtyForOrderItemRel(upCum01PView.FGORD, upCum01PView.FGITEM, upCum01PView.FGRLNO);
    if (shipExportDtlDataBaseContainerDiffQty.Count > 0) {
        shipExportDtl = objectDataBaseToObject((ShipExportDtlDataBase)shipExportDtlDataBaseContainerDiffQty[0]);
        upCum01PView.LastQtyChange      = shipExportDtl.RelQtyInvUnit;
        upCum01PView.LastQtyDateChange  = shipExportDtl.getTimeStampAsDate();
    }

    //load last 4 records based on Shipped Record form Current Release
    ShipExportDtlDataBaseContainer shipExportDtlDataBaseContainer = new ShipExportDtlDataBaseContainer(dataBaseAccess);
    shipExportDtlDataBaseContainer.getSqlOCRITPairedByFilters(upCum01PView.FGORD,upCum01PView.FGITEM,upCum01PView.FGRLNO,0);
    foreach(ShipExportDtlDataBase shipExportDtlDataBase in shipExportDtlDataBaseContainer)
        shipExportDtlContainerAux.Add(objectDataBaseToObject(shipExportDtlDataBase));

    for (i=0; i<shipExportDtlContainerAux.Count; i++){
        shipExportDtl = shipExportDtlContainerAux[i];
                   
        if (shipExportDtlAdd != null &&  (shipExportDtlAdd.Detail+1) == i && string.IsNullOrEmpty(spriorRelease) &&
            (shipExportDtl.Action.Equals(sdel) /*|| shipExportDtl.Action.Equals("1")*/) && !shipExportDtl.Release.ToUpper().Equals(upCum01PView.FGRLNO.ToUpper()))                                        
            spriorRelease= shipExportDtl.Release;
             
        if (shipExportDtl.Action.Equals(sadd) && shipExportDtl.Release.ToUpper().Equals(upCum01PView.FGRLNO.ToUpper())){ 
            shipExportDtlAdd= shipExportDtl;                
            shipExportDtlAdd.Detail = i;
        }

        if (shipExportDtl.Release.ToUpper().Equals(upCum01PView.FGRLNO.ToUpper()) ||
            (!string.IsNullOrEmpty(spriorRelease) && shipExportDtl.Release.ToUpper().Equals(spriorRelease.ToUpper()))) //current release we add               
            shipExportDtlContainer.Add(shipExportDtl);           
    }     
    return shipExportDtlContainer;
}               

private
StxhDataBase loadStxh(UpCum01PView upCum01PView, decimal log,string stparnter,string srelease,string sdoc,string shipLoc,string scustPO){
    StxhDataBase            stxhDataBase            = null;
    StxhDataBaseContainer   stxhDataBaseContainer   = new StxhDataBaseContainer(dataBaseAccess);

    stxhDataBaseContainer.readByFilters(log,0,stparnter,sdoc,DateUtil.MinValue,DateUtil.MinValue, scustPO, upCum01PView.FGCPT, srelease, upCum01PView.FEBCS,upCum01PView.FESCS,shipLoc, 5);
    if (stxhDataBaseContainer.Count > 0) 
        stxhDataBase = (StxhDataBase)stxhDataBaseContainer[0];

    //stxhDataBase.setOYLOG();
    //stxhDataBase.setOYENT();    
    return stxhDataBase;
}

private
RrlhDataBase loadRrlh(decimal dkeyNum,string stparnter,string srelease,string shipLoc,string spart){
    RrlhDataBase                rrlhDataBase                = null;
    RrlhDataBaseContainer       rrlhDataBaseContainer       = new RrlhDataBaseContainer(dataBaseAccess);

    rrlhDataBaseContainer.readByFilters("",dkeyNum,stparnter,srelease, shipLoc,spart,0,0, 5);
    if (rrlhDataBaseContainer.Count > 0) 
        rrlhDataBase = (RrlhDataBase)rrlhDataBaseContainer[0];
    
    return rrlhDataBase;
}

private
ShipExportRelease loadShipExportReleaseInfo(UpCum01PView upCum01PView, RrlhDataBase rrlhDataBase,RrldDataBase rrldDataBase,RrldmDataBaseContainer rrldmDataBaseContainer, StxhDataBase stxhDataBase){
    ShipExportRelease           shipExportRelease       = new ShipExportRelease();
    ShipExportRelease           shipExportReleaseManual = null;
    ShipExportReleaseContainer  shipExportReleaseContainerManual = new ShipExportReleaseContainer();

    if (rrlhDataBase != null){                
        shipExportRelease.OurShipCum= rrlhDataBase.getOZYTDC();
        shipExportRelease.OemYtdReq = rrlhDataBase.getOZOEMC();
        shipExportRelease.OemYtdShip= rrlhDataBase.getOZOEMS();       
                
        shipExportRelease.Release   = rrlhDataBase.getOZREL();                 
    }

    if (rrldDataBase != null){
        shipExportRelease.Release = rrldDataBase.getPLREL();
        shipExportRelease.RelDate = rrldDataBase.getPLRDAT();
        shipExportRelease.RelCum  = rrldDataBase.getPLQCUM();
        shipExportRelease.RelQty  = rrldDataBase.getPLQNET();
        shipExportRelease.UserId  = rrldDataBase.getPLUSR1();        
    }

    if (rrldmDataBaseContainer != null){ 
        foreach(RrldmDataBase rrldmDataBase in rrldmDataBaseContainer) { 
            shipExportReleaseManual         = cloneShipExportRelease(shipExportRelease);
            shipExportReleaseManual.Release = rrldmDataBase.getBJ0REL();
            shipExportReleaseManual.RelDate = rrldmDataBase.getBJ0RDAT();
            shipExportReleaseManual.RelCum  = rrldmDataBase.getBJ0QCUM();
            shipExportReleaseManual.RelQty  = rrldmDataBase.getBJ0QNET();
            shipExportReleaseManual.UserId  = rrldmDataBase.getBJ0USID();        

            shipExportReleaseManual.StDateCreated  = rrldmDataBase.getBJ0DTTM();
            shipExportReleaseContainerManual.Add(shipExportReleaseManual);
        }
    }

    if (stxhDataBase != null){                
        shipExportRelease.StDateCreated     = DateUtil.generateDateTimeFromCMS(stxhDataBase.getOYCDAT(),stxhDataBase.getOYCHRM());
        shipExportRelease.StTranslated      = stxhDataBase.getOYSTAT();
        shipExportRelease.StTranslatedDate  = stxhDataBase.getOYTDAT();        
    }else{ 
        shipExportRelease.StDateCreated     = DateUtil.MinValue;
        shipExportRelease.StTranslated      = Constants.STRING_NO;
        shipExportRelease.StTranslatedDate  = DateUtil.MinValue;
    }

    upCum01PView.ShipExportReleaseContainer.Add(shipExportRelease);
    foreach(ShipExportRelease shipExportReleaseAux in shipExportReleaseContainerManual)
        upCum01PView.ShipExportReleaseContainer.Add(shipExportReleaseAux);

    upCum01PView.ShipExportReleaseContainer.fillDetails();

    return shipExportRelease;
}

private
JithDataBase loadJith(decimal dkeyNum,string sreference,string stparnter,string srelease,string shipLoc,string spart){
    JithDataBase                jithDataBase                = null;
    JithDataBaseContainer       jithDataBaseContainer       = new JithDataBaseContainer(dataBaseAccess);

    jithDataBaseContainer.readByFilters(dkeyNum,sreference,stparnter, srelease,shipLoc,spart, 5);
    if (jithDataBaseContainer.Count > 0) 
        jithDataBase = (JithDataBase)jithDataBaseContainer[0];
    
    return jithDataBase;
}

private
bool tryLoadJitd(out JitdDataBase jitdDataBase,out JitdmDataBaseContainer jitdmDataBaseContainerOut, UpCum01PView upCum01PView,string stpartner,decimal dkeyNum,decimal logNum,string sreference,string sran){
    bool                    bresult = false;
    JitdDataBaseContainer   jitdDataBaseContainer = new JitdDataBaseContainer(dataBaseAccess);
        
    jitdDataBase = null;        
    jitdmDataBaseContainerOut = null;
    jitdDataBaseContainer.readByFilters(stpartner,upCum01PView.FGCPT,dkeyNum,logNum,sreference,sran,">",upCum01PView.FGPCUM,"PYQCUM",1);  
    if (jitdDataBaseContainer.Count < 1) {        
        if (!string.IsNullOrEmpty(sran))
            jitdDataBaseContainer.readByFilters(stpartner,upCum01PView.FGCPT,dkeyNum,logNum,sreference,sran,"",decimal.MinValue,"",1);
            //if (jitdDataBaseContainer.Count < 1)
                //jitdDataBaseContainer.readByFilters(stpartner,upCum01PView.FGCPT,dkeyNum,logNum,sreference,"",">", upCum01PView.FGPCUM,"PYQCUM",1);                                    
    }

    if (jitdDataBaseContainer.Count > 0)
        jitdDataBase = (JitdDataBase)jitdDataBaseContainer[0];
    bresult = jitdDataBaseContainer.Count > 0;

    if (jitdDataBase != null) { 
        JitdmDataBaseContainer jitdmDataBaseContainer = new JitdmDataBaseContainer(dataBaseAccess);        
        jitdmDataBaseContainer.readByFilters(stpartner,upCum01PView.FGCPT,dkeyNum,  jitdDataBase.getPYLOG(), 
                                                                                    jitdDataBase.getPYENT(),
                                                                                    sreference,"",decimal.MinValue,"", 0);
        if (jitdmDataBaseContainer.Count > 0 && jitdDataBase != null) {                                 
            JitdmContainer  jitdmContainerAux   = new JitdmContainer(); //order by time stamp
            JitdmContainer  jitdmContainer      = new JitdmContainer(); //order by time stamp
            Jitdm           jitdm               = null;
            Jitdm           jitdNext            = null;
            string          stimeCFound         = "";
        
            for (int i=0; i < jitdmDataBaseContainer.Count; i++){
                JitdmDataBase jitdmDataBaseAux = (JitdmDataBase)jitdmDataBaseContainer[i];
                if (jitdmDataBaseAux.getBJ1ITYP().Equals("1") || jitdmDataBaseAux.getBJ1ITYP().Equals("2"))
                    jitdmContainerAux.Add(objectDataBaseToObject(jitdmDataBaseAux));            
            }
            jitdmContainerAux.sortByTimeStamp();

            for (int i=0; i < jitdmContainerAux.Count; i++){
                jitdm       = jitdmContainerAux[i];
                jitdNext    = (i+1) < jitdmContainerAux.Count ? jitdmContainerAux[i+1] : null;

                if (jitdNext != null && jitdm.BJ1ITYP.Equals("1") && jitdNext.BJ1ITYP.Equals("2")  &&  //if 1 and 2 pair sequence
                    jitdm.BJ1TIMC.Equals(jitdNext.BJ1TIMC) && DateUtil.sameDate(jitdDataBase.getPYDATE(), jitdNext.BJ1DATE)) //same timec
                    jitdmContainer.Add(jitdm);
            }

            for (int i=0; i < jitdmContainer.Count; i++){
                if (i == 0)
                    jitdmDataBaseContainerOut = new JitdmDataBaseContainer(dataBaseAccess);
                jitdmDataBaseContainerOut.Add(objectToObjectDataBase(jitdmContainer[i]));
            }                        
        }
    }

    return bresult;
}

private
TrlpDataBase loadTrlpInfo(UpCum01PView upCum01PView, out string stpartner, out string shipLoc, out decimal dkeyNum){
    stpartner = shipLoc = "";
    dkeyNum     = 0;                  
    TrlpDataBase                trlpDataBase                = null;    
        
    trlpDataBase = getCustTPartner( upCum01PView.FEBCS,upCum01PView.FESCS,upCum01PView.FGORD, upCum01PView.FGITEM,
                                    out stpartner,out shipLoc);
    if (trlpDataBase!= null)      
        dkeyNum = trlpDataBase.getSMCKEY();
    
    return trlpDataBase;
}
        
private
ShipExportRelease loadShipExportReleaseInfo(UpCum01PView upCum01PView, JithDataBase jithDataBase, JitdDataBase jitdDataBase, JitdmDataBaseContainer jitdmDataBaseContainer, StxhDataBase stxhDataBase){
    ShipExportRelease           shipExportRelease       = new ShipExportRelease();
    ShipExportRelease           shipExportReleaseManual = null;
    ShipExportReleaseContainer  shipExportReleaseContainerManual = new ShipExportReleaseContainer();   
    bool                        baddRelase              = true;

    if (jithDataBase != null){                
        shipExportRelease.OurShipCum= jithDataBase.getSPYTDC();
        shipExportRelease.OemYtdReq = jithDataBase.getSPOEMC();
        shipExportRelease.OemYtdShip= jithDataBase.getSPOEMS();       
                         
        shipExportRelease.Release   = jithDataBase.getSPREF();
    }

    if (jitdDataBase != null){
        shipExportRelease.Release = jitdDataBase.getPYREF();
        shipExportRelease.RelDate = jitdDataBase.getPYDATE();
        shipExportRelease.RelCum  = jitdDataBase.getPYQCUM();
        shipExportRelease.RelQty  = jitdDataBase.getPYQTY();
        shipExportRelease.UserId  = jitdDataBase.getPYUSR1();        
        shipExportRelease.Ran     = jitdDataBase.getPYRAN();
    }

    if (jitdmDataBaseContainer != null){ 
        foreach(JitdmDataBase jitdmDataBase in jitdmDataBaseContainer) { 
            shipExportReleaseManual         = cloneShipExportRelease(shipExportRelease);
            shipExportReleaseManual.Release = jitdmDataBase.getBJ1REF();
            shipExportReleaseManual.RelDate = jitdmDataBase.getBJ1DATE();
            shipExportReleaseManual.RelCum  = jitdmDataBase.getBJ1QCUM();
            shipExportReleaseManual.RelQty  = jitdmDataBase.getBJ1NQTY();
            shipExportReleaseManual.UserId  = jitdmDataBase.getBJ1USID();        

            shipExportReleaseManual.StDateCreated  = jitdmDataBase.getBJ1DTTM();
            shipExportReleaseContainerManual.Add(shipExportReleaseManual);
        }
    }

    if (stxhDataBase != null){                
        shipExportRelease.StDateCreated     = DateUtil.generateDateTimeFromCMS(stxhDataBase.getOYCDAT(),stxhDataBase.getOYCHRM());
        shipExportRelease.StTranslated      = stxhDataBase.getOYSTAT();
        shipExportRelease.StTranslatedDate  = stxhDataBase.getOYTDAT();        
    }else{ 
        shipExportRelease.StDateCreated     = DateUtil.MinValue;
        shipExportRelease.StTranslated      = Constants.STRING_NO;
        shipExportRelease.StTranslatedDate  = DateUtil.MinValue;
    }

    if (upCum01PView.ShipExportSource.Equals(ShipExport.EXPORT_862) && 
        (shipExportRelease.StDateCreated > upCum01PView.FESDAT && !DateUtil.sameDate(shipExportRelease.StDateCreated,upCum01PView.FESDAT))) //only for 862 normal mode, if ShipDate < StDateCreated we do not need to process it
        baddRelase=false;            

    if (baddRelase) { 
        upCum01PView.ShipExportReleaseContainer.Add(shipExportRelease);
        foreach(ShipExportRelease shipExportReleaseAux in shipExportReleaseContainerManual)
            upCum01PView.ShipExportReleaseContainer.Add(shipExportReleaseAux);

        upCum01PView.ShipExportReleaseContainer.fillDetails();
    }

    return shipExportRelease;
}

private
ShipExportDtlContainer load862Info(UpCum01PView upCum01PView){        
    TrlpDataBase                trlpDataBase                = null;
    string                      stpartner                   = "";
    JithDataBase                jithDataBase                = new JithDataBase(dataBaseAccess);
    JithDataBase                jithPriorhDataBase          = new JithDataBase(dataBaseAccess);
    JitdDataBaseContainer       jitdDataBaseContainer       = new JitdDataBaseContainer(dataBaseAccess);
    JitdDataBase                jitdDataBase                = null;  
    JitdmDataBaseContainer      jitdmDataBaseContainer      = new JitdmDataBaseContainer(dataBaseAccess);
        
    string                      scurrRelease                = upCum01PView.FGCREL;        
    string                      spriorRelease               = "";        
    StxhDataBase                stxhDataBase                = new StxhDataBase(dataBaseAccess);
    decimal                     dkeyNum                     = 0;//rrlhDataBase!= null ? rrlhDataBase.getOZKEYN(): 0;
    decimal                     dlogNum                     = 0;//rrlhDataBase!= null ? rrlhDataBase.getOZLOG() : 0;
    string                      shipLoc                     = "";
    string                      scustPO                     = "";
    string                      scurrReference              = "";
    string                      spriorReference             = "";
    
    upCum01PView.ShipExportReleaseContainer.Clear();
    trlpDataBase = loadTrlpInfo(upCum01PView,out stpartner,out shipLoc,out dkeyNum);
       
    if (trlpDataBase!= null) { //if trlp not found we stop           
        upCum01PView.SMTRPT = string.IsNullOrEmpty(upCum01PView.SMTRPT) ? stpartner : upCum01PView.SMTRPT;
        upCum01PView.SMSTXL = string.IsNullOrEmpty(upCum01PView.SMSTXL) ? shipLoc   : upCum01PView.SMSTXL;
        scurrReference      = trlpDataBase.getSMSREF();

        bool        bprocess    = true;
        int         icounter    = 0;
        DateTime    startDate   = upCum01PView.FESDAT;
        DateTime    lastDate    = upCum01PView.FESDAT.AddDays(-90);

        scurrRelease= upCum01PView.FGCREL;                
        jithDataBase= loadJith(dkeyNum,scurrReference,stpartner,"","",upCum01PView.FGCPT);  //scurrRelease,shipLoc,upCum01PView.FGCPT);
                        
        dkeyNum     = jithDataBase!= null ? jithDataBase.getSPKEYN(): 0;
        dlogNum     = jithDataBase!= null ? jithDataBase.getSPLOG() : 0;        
        scustPO     = upCum01PView.FGCPO;

        bprocess    = tryLoadJitd(out jitdDataBase,out jitdmDataBaseContainer,upCum01PView, stpartner,dkeyNum,dlogNum,scurrReference, "");                               
        stxhDataBase= loadStxh(upCum01PView,dlogNum,stpartner,"",scurrReference,shipLoc,scustPO);
        loadShipExportReleaseInfo(upCum01PView, jithDataBase, jitdDataBase, jitdmDataBaseContainer, stxhDataBase);
                    
        do{
            jithDataBase= null;
            jitdDataBase= null;
            jitdmDataBaseContainer= null;
            stxhDataBase= null;
            //bprocess    = jithPriorhDataBase.getPriorRelease(stpartner,scurrReference,shipLoc,upCum01PView.FGCPT);
            bprocess    = jithPriorhDataBase.getPriorRelease(stpartner,"", shipLoc, upCum01PView.FGCPT,dlogNum,scurrReference);
                    
            if (bprocess){
                jithDataBase    = jithPriorhDataBase;
                spriorRelease   = jithDataBase.getSPREL();
                spriorReference = jithDataBase.getSPREF();

                dkeyNum     = jithDataBase != null ? jithDataBase.getSPKEYN(): 0;
                dlogNum     = jithDataBase != null ? jithDataBase.getSPLOG() : 0;                
                scustPO     = jithDataBase != null ? jithDataBase.getSPCPO() : scustPO;

                tryLoadJitd(out jitdDataBase,out jitdmDataBaseContainer,upCum01PView, stpartner,dkeyNum,dlogNum,spriorReference, "");       
            }
            
            if (bprocess) 
                stxhDataBase= loadStxh(upCum01PView,dlogNum,stpartner,"", spriorReference, shipLoc,scustPO);
            scurrRelease    = spriorRelease;                        
            scurrReference  = spriorReference;                        
                   
            if (bprocess)
                loadShipExportReleaseInfo(upCum01PView, jithDataBase, jitdDataBase, jitdmDataBaseContainer, stxhDataBase);
                
            if (stxhDataBase!= null && stxhDataBase.getOYCDAT() < startDate.AddDays(-90))
                bprocess=false;
                      
            icounter++;

        } while (icounter < ShipExport.IMAX_EXPORT_LOOP_COUNTER && bprocess);
                              
    }
            
    loadDetailsBasedOn830Info(upCum01PView,true);
    return upCum01PView.ShipExportDtlContainer;
}


private
ShipExportDtlContainer load862RanInfo(UpCum01PView upCum01PView){        
    TrlpDataBase                trlpDataBase                = null;
    string                      stpartner                   = "";
    JithDataBase                jithDataBase                = new JithDataBase(dataBaseAccess);
    JithDataBase                jithPriorhDataBase          = new JithDataBase(dataBaseAccess);
    JitdDataBaseContainer       jitdDataBaseContainer       = new JitdDataBaseContainer(dataBaseAccess);
    JitdDataBase                jitdDataBase                = null;  
    JitdmDataBaseContainer      jitdmDataBaseContainer      = new JitdmDataBaseContainer(dataBaseAccess);
        
    string                      scurrRelease                = upCum01PView.FGCREL;        
    string                      spriorRelease               = "";        
    StxhDataBase                stxhDataBase                = new StxhDataBase(dataBaseAccess);
    decimal                     dkeyNum                     = 0;
    decimal                     dlogNum                     = 0;
    string                      shipLoc                     = "";
    string                      scustPO                     = "";
    string                      scurrReference              = "";
    string                      spriorReference             = "";
    string                      sran                        = upCum01PView.FGRAN;
    int                         icounter                    = 0;
    bool                        bprocess                    = true;        
    DateTime                    startDate                   = upCum01PView.FESDAT;
    DateTime                    lastDate                    = upCum01PView.FESDAT.AddDays(-90);

    upCum01PView.ShipExportReleaseContainer.Clear();
    trlpDataBase = loadTrlpInfo(upCum01PView,out stpartner,out shipLoc,out dkeyNum);
       
    if (trlpDataBase!= null) { //if trlp not found we stop           
        upCum01PView.SMTRPT = string.IsNullOrEmpty(upCum01PView.SMTRPT) ? stpartner : upCum01PView.SMTRPT;
        upCum01PView.SMSTXL = string.IsNullOrEmpty(upCum01PView.SMSTXL) ? shipLoc   : upCum01PView.SMSTXL;
        scurrReference      = trlpDataBase.getSMSREF();     

        scurrRelease= upCum01PView.FGCREL;                
        bprocess    = tryLoadJitd(out jitdDataBase,out jitdmDataBaseContainer,upCum01PView, stpartner,dkeyNum,dlogNum,scurrReference, sran);      
        dkeyNum     = jitdDataBase!= null ? jitdDataBase.getPYKEYN() : dkeyNum;

        jithDataBase = loadJith(dkeyNum,scurrReference,stpartner,"","",upCum01PView.FGCPT);  //scurrRelease,shipLoc,upCum01PView.FGCPT);
                        
        dkeyNum     = jithDataBase!= null ? jithDataBase.getSPKEYN(): dkeyNum;
        dlogNum     = jithDataBase!= null ? jithDataBase.getSPLOG() : dlogNum;        
        scustPO     = upCum01PView.FGCPO;
                        
        stxhDataBase= loadStxh(upCum01PView,dlogNum,stpartner,"",scurrReference,shipLoc,scustPO);
        if (jitdDataBase!= null)
            loadShipExportReleaseInfo(upCum01PView, jithDataBase, jitdDataBase, jitdmDataBaseContainer, stxhDataBase);                    
        do{
            jithDataBase= null;
            jitdDataBase= null;
            jitdmDataBaseContainer= null;
            stxhDataBase= null;            
            bprocess  = jithPriorhDataBase.getPriorRelease(stpartner,"", shipLoc, upCum01PView.FGCPT,dlogNum,scurrReference);
                    
            if (bprocess){
                jithDataBase    = jithPriorhDataBase;
                spriorRelease   = jithDataBase.getSPREL();
                spriorReference = jithDataBase.getSPREF();

                dkeyNum     = jithDataBase != null ? jithDataBase.getSPKEYN(): 0;
                dlogNum     = jithDataBase != null ? jithDataBase.getSPLOG() : 0;                
                scustPO     = jithDataBase != null ? jithDataBase.getSPCPO() : scustPO;

                tryLoadJitd(out jitdDataBase,out jitdmDataBaseContainer,upCum01PView, stpartner,dkeyNum,dlogNum,spriorReference,sran);                    
            }
            
            if (bprocess) 
                stxhDataBase= loadStxh(upCum01PView,dlogNum,stpartner,"", spriorReference, shipLoc,scustPO);
            scurrRelease    = spriorRelease;                        
            scurrReference  = spriorReference;                        
                   
            if (bprocess && jitdDataBase != null) //check if Ran found
                loadShipExportReleaseInfo(upCum01PView, jithDataBase, jitdDataBase, jitdmDataBaseContainer, stxhDataBase);
                
            if (stxhDataBase!= null && stxhDataBase.getOYCDAT() < startDate.AddDays(-90))
                bprocess=false;
                      
            icounter++;

        } while (icounter < ShipExport.IMAX_EXPORT_LOOP_COUNTER && bprocess); //bprocess);
                              
    }
            
    loadDetailsBasedOn830Info(upCum01PView,true);
    return upCum01PView.ShipExportDtlContainer;
}
/****************************************************** EdiTransTP **********************************************************************/

public
EdiTransTP createEdiTransTP(){
    return new EdiTransTP();
}

public
EdiTransTPContainer createEdiTransTPContainer(){
	return new EdiTransTPContainer();
}

public
bool existsEdiTransTP(string splant,string tPartner, int detail){
	try{
		EdiTransTPDataBase ediTransTPDataBase = new EdiTransTPDataBase(dataBaseAccess);

        ediTransTPDataBase.setPlant(splant);
		ediTransTPDataBase.setTPartner(tPartner);
		ediTransTPDataBase.setDetail(detail);

		return ediTransTPDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
EdiTransTP readEdiTransTP(string splant,string tPartner, int detail){
	try{
		EdiTransTPDataBase ediTransTPDataBase = new EdiTransTPDataBase(dataBaseAccess);
		ediTransTPDataBase.setPlant(splant);
		ediTransTPDataBase.setTPartner(tPartner);
		ediTransTPDataBase.setDetail(detail);

		if (!ediTransTPDataBase.read())
			return null;

		EdiTransTP ediTransTP = this.objectDataBaseToObject(ediTransTPDataBase);

		return ediTransTP;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateEdiTransTP(EdiTransTP ediTransTP){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		updateEdiTransTPInternal(ediTransTP);

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
void updateEdiTransTPInternal(EdiTransTP ediTransTP){
	EdiTransTPDataBase ediTransTPDataBase = this.objectToObjectDataBase(ediTransTP);
    ediTransTPDataBase.update();
}

public 
void writeEdiTransTP(EdiTransTP ediTransTP){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        writeEdiTransTPInternal(ediTransTP);
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
void writeEdiTransTPInternal(EdiTransTP ediTransTP){
	EdiTransTPDataBase ediTransTPDataBase = this.objectToObjectDataBase(ediTransTP);
    ediTransTPDataBase.write();
}

public
void deleteEdiTransTP(string splant,string tPartner, int detail){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		EdiTransTPDataBase ediTransTPDataBase = new EdiTransTPDataBase(dataBaseAccess);

		ediTransTPDataBase.setPlant(splant);
		ediTransTPDataBase.setTPartner(tPartner);
		ediTransTPDataBase.setDetail(detail);
		ediTransTPDataBase.delete();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

protected
EdiTransTP objectDataBaseToObject(EdiTransTPDataBase ediTransTPDataBase){
	EdiTransTP ediTransTP = new EdiTransTP();

    ediTransTP.Plant=ediTransTPDataBase.getPlant();
	ediTransTP.TPartner=ediTransTPDataBase.getTPartner();
	ediTransTP.Detail=ediTransTPDataBase.getDetail();
	ediTransTP.LogFrom=ediTransTPDataBase.getLogFrom();
	ediTransTP.LogTo=ediTransTPDataBase.getLogTo();
    ediTransTP.DateProces = ediTransTPDataBase.getDateProces();
	ediTransTP.DateCreated=ediTransTPDataBase.getDateCreated();

	return ediTransTP;
}

protected
EdiTransTPDataBase objectToObjectDataBase(EdiTransTP ediTransTP){
	EdiTransTPDataBase ediTransTPDataBase = new EdiTransTPDataBase(dataBaseAccess);

    ediTransTPDataBase.setPlant(ediTransTP.Plant);
	ediTransTPDataBase.setTPartner(ediTransTP.TPartner);
	ediTransTPDataBase.setDetail(ediTransTP.Detail);
	ediTransTPDataBase.setLogFrom(ediTransTP.LogFrom);
	ediTransTPDataBase.setLogTo(ediTransTP.LogTo);
    ediTransTPDataBase.setDateProces(ediTransTP.DateProces);
	ediTransTPDataBase.setDateCreated(ediTransTP.DateCreated);

	return ediTransTPDataBase;
}

public
EdiTransTP cloneEdiTransTP(EdiTransTP ediTransTP){
	EdiTransTP ediTransTPClone = new EdiTransTP();

    ediTransTPClone.Plant=ediTransTP.Plant;
	ediTransTPClone.TPartner=ediTransTP.TPartner;
	ediTransTPClone.Detail=ediTransTP.Detail;
	ediTransTPClone.LogFrom=ediTransTP.LogFrom;
	ediTransTPClone.LogTo=ediTransTP.LogTo;
    ediTransTPClone.DateProces=ediTransTP.DateProces;
	ediTransTPClone.DateCreated=ediTransTP.DateCreated;

	return ediTransTPClone;
}


/********************************************************* LastExported ***************************************************************/

public
LastExported createLastExported(){
	return new LastExported();
}

public
LastExportedContainer createLastExportedContainer(){
	return new LastExportedContainer();
}

public
bool existsLastExported(string code){
	try{
		LastExportedDataBase lastExportedDataBase = new LastExportedDataBase(dataBaseAccess);

		lastExportedDataBase.setCode(code);

		return lastExportedDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
LastExported readLastExported(string code){
	try{
		LastExportedDataBase lastExportedDataBase = new LastExportedDataBase(dataBaseAccess);
		lastExportedDataBase.setCode(code);

		if (!lastExportedDataBase.read())
			return null;

		LastExported lastExported = this.objectDataBaseToObject(lastExportedDataBase);

		return lastExported;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateLastExported(LastExported lastExported){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		LastExportedDataBase lastExportedDataBase = this.objectToObjectDataBase(lastExported);
		lastExportedDataBase.update();

        if (!userHandleTransaction)
		    dataBaseAccess.commitTransaction();

    }catch(PersistenceException persistenceException){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
void writeLastExported(LastExported lastExported){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		LastExportedDataBase lastExportedDataBase = this.objectToObjectDataBase(lastExported);
		lastExportedDataBase.write();

		if (!userHandleTransaction)
		    dataBaseAccess.commitTransaction();

    }catch(PersistenceException persistenceException){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
void deleteLastExported(string code){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		LastExportedDataBase lastExportedDataBase = new LastExportedDataBase(dataBaseAccess);

		lastExportedDataBase.setCode(code);
		lastExportedDataBase.delete();

		if (!userHandleTransaction)
		    dataBaseAccess.commitTransaction();

    }catch(PersistenceException persistenceException){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

private
LastExported objectDataBaseToObject(LastExportedDataBase lastExportedDataBase){
	LastExported lastExported = new LastExported();

	lastExported.Code=lastExportedDataBase.getCode();
	lastExported.LastProces=lastExportedDataBase.getLastProces();
	lastExported.LastId=lastExportedDataBase.getLastId();

	return lastExported;
}

private
LastExportedDataBase objectToObjectDataBase(LastExported lastExported){
	LastExportedDataBase lastExportedDataBase = new LastExportedDataBase(dataBaseAccess);
	lastExportedDataBase.setCode(lastExported.Code);
	lastExportedDataBase.setLastProces(lastExported.LastProces);
	lastExportedDataBase.setLastId(lastExported.LastId);

	return lastExportedDataBase;
}

public
LastExported cloneLastExported(LastExported lastExported){
	LastExported lastExportedClone = new LastExported();

	lastExportedClone.Code=lastExported.Code;
	lastExportedClone.LastProces=lastExported.LastProces;
	lastExportedClone.LastId=lastExported.LastId;

	return lastExportedClone;
}

/***************************************** ShipExportRelease ***********************************************************************/
public
ShipExportRelease createShipExportRelease(){
	return new ShipExportRelease();
}

public
ShipExportReleaseContainer createShipExportReleaseContainer(){
	return new ShipExportReleaseContainer();
}

private
ShipExportRelease objectDataBaseToObject(ShipExportReleaseDataBase shipExportReleaseDataBase){
	ShipExportRelease shipExportRelease = new ShipExportRelease();

	shipExportRelease.Site=shipExportReleaseDataBase.getSite();
	shipExportRelease.Bol=shipExportReleaseDataBase.getBol();
	shipExportRelease.BolItem=shipExportReleaseDataBase.getBolItem();
	shipExportRelease.Detail=shipExportReleaseDataBase.getDetail();
	shipExportRelease.Release=shipExportReleaseDataBase.getRelease();
	shipExportRelease.RelDate=shipExportReleaseDataBase.getRelDate();
	shipExportRelease.RelCum=shipExportReleaseDataBase.getRelCum();
	shipExportRelease.RelQty=shipExportReleaseDataBase.getRelQty();
	shipExportRelease.OurShipCum=shipExportReleaseDataBase.getOurShipCum();
	shipExportRelease.OemYtdReq=shipExportReleaseDataBase.getOemYtdReq();
	shipExportRelease.OemYtdShip=shipExportReleaseDataBase.getOemYtdShip();
	shipExportRelease.StDateCreated=shipExportReleaseDataBase.getStDateCreated();
	shipExportRelease.StTranslated=shipExportReleaseDataBase.getStTranslated();
	shipExportRelease.StTranslatedDate=shipExportReleaseDataBase.getStTranslatedDate();
    shipExportRelease.UserId= shipExportReleaseDataBase.getUserId();
    shipExportRelease.Ran   = shipExportReleaseDataBase.getRan();

    return shipExportRelease;
}

private
ShipExportReleaseDataBase objectToObjectDataBase(ShipExportRelease shipExportRelease){
	ShipExportReleaseDataBase shipExportReleaseDataBase = new ShipExportReleaseDataBase(dataBaseAccess);
	shipExportReleaseDataBase.setSite(shipExportRelease.Site);
	shipExportReleaseDataBase.setBol(shipExportRelease.Bol);
	shipExportReleaseDataBase.setBolItem(shipExportRelease.BolItem);
	shipExportReleaseDataBase.setDetail(shipExportRelease.Detail);
	shipExportReleaseDataBase.setRelease(shipExportRelease.Release);
	shipExportReleaseDataBase.setRelDate(shipExportRelease.RelDate);
	shipExportReleaseDataBase.setRelCum(shipExportRelease.RelCum);
	shipExportReleaseDataBase.setRelQty(shipExportRelease.RelQty);
	shipExportReleaseDataBase.setOurShipCum(shipExportRelease.OurShipCum);
	shipExportReleaseDataBase.setOemYtdReq(shipExportRelease.OemYtdReq);
	shipExportReleaseDataBase.setOemYtdShip(shipExportRelease.OemYtdShip);
	shipExportReleaseDataBase.setStDateCreated(shipExportRelease.StDateCreated);
	shipExportReleaseDataBase.setStTranslated(shipExportRelease.StTranslated);
	shipExportReleaseDataBase.setStTranslatedDate(shipExportRelease.StTranslatedDate);
    shipExportReleaseDataBase.setUserId(shipExportRelease.UserId);
    shipExportReleaseDataBase.setRan(shipExportRelease.Ran);

	return shipExportReleaseDataBase;
}

public
ShipExportRelease cloneShipExportRelease(ShipExportRelease shipExportRelease){
	ShipExportRelease shipExportReleaseClone = new ShipExportRelease();

	shipExportReleaseClone.Site=shipExportRelease.Site;
	shipExportReleaseClone.Bol=shipExportRelease.Bol;
	shipExportReleaseClone.BolItem=shipExportRelease.BolItem;
	shipExportReleaseClone.Detail=shipExportRelease.Detail;
	shipExportReleaseClone.Release=shipExportRelease.Release;
	shipExportReleaseClone.RelDate=shipExportRelease.RelDate;
	shipExportReleaseClone.RelCum=shipExportRelease.RelCum;
	shipExportReleaseClone.RelQty=shipExportRelease.RelQty;
	shipExportReleaseClone.OurShipCum=shipExportRelease.OurShipCum;
	shipExportReleaseClone.OemYtdReq=shipExportRelease.OemYtdReq;
	shipExportReleaseClone.OemYtdShip=shipExportRelease.OemYtdShip;
	shipExportReleaseClone.StDateCreated=shipExportRelease.StDateCreated;
	shipExportReleaseClone.StTranslated=shipExportRelease.StTranslated;
	shipExportReleaseClone.StTranslatedDate=shipExportRelease.StTranslatedDate;
    shipExportReleaseClone.UserId= shipExportRelease.UserId;
    shipExportReleaseClone.Ran   = shipExportRelease.Ran;
    shipExportReleaseClone.BQtyChangeShow   = shipExportRelease.BQtyChangeShow;
    shipExportReleaseClone.BDateChangeShow  = shipExportRelease.BDateChangeShow;
    
	return shipExportReleaseClone;
}

  
public
void adjustNewShipExportFields(UpCum01PViewContainer upCum01PViewContainer){
    try{
        UpCum01PView            upCum01PView= null;
        ShipExportDataBase      shipExportDataBase = new ShipExportDataBase(dataBaseAccess);


        for (int i=0; i < upCum01PViewContainer.Count; i++){
            upCum01PView = upCum01PViewContainer[i];
            
            shipExportDataBase.setSite(upCum01PView.FEPLTC);//plant
            shipExportDataBase.setBol(upCum01PView.FGBOL);
            shipExportDataBase.setBolItem(upCum01PView.FGENT); 
            
            if (shipExportDataBase.read()){
                        /*
                shipExportDataBase.setQtyOrder(upCum01PView.QtyOrder);
                shipExportDataBase.setEdiRelease(upCum01PView.FGCREL);
                shipExportDataBase.setLeadTime(upCum01PView.LeadTime);
                shipExportDataBase.setReleaseBase(upCum01PView.ReleaseBase);
                shipExportDataBase.setQtyOrdBase(upCum01PView.QtyOrdBase);*/
                shipExportDataBase.setLTBookDate(upCum01PView.LTBookDate);
                shipExportDataBase.setLTBookQty(upCum01PView.LTBookQty);
                shipExportDataBase.setLeadTime(upCum01PView.LeadTime);
                shipExportDataBase.updateLeadTimeFields();                
            }            
        }	
	
    }catch(PersistenceException persistenceException){
    	throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
    	throw new NujitException(exception.Message, exception);
	}
    
}

/******************************************************** ShipExportSum ****************************************************/
public
ShipExportSum createShipExportSum(){
	return new ShipExportSum();
}

public
ShipExportSumContainer createShipExportSumContainer(){
	return new ShipExportSumContainer();
}

public
bool existsShipExportSum(decimal orderNum, decimal item, string release){
	try{
		ShipExportSumDataBase shipExportSumDataBase = new ShipExportSumDataBase(dataBaseAccess);

		shipExportSumDataBase.setOrderNum(orderNum);
		shipExportSumDataBase.setItem(item);
		shipExportSumDataBase.setRelease(release);

		return shipExportSumDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
ShipExportSum readShipExportSum(decimal orderNum, decimal item, string release){
	try{
		ShipExportSumDataBase shipExportSumDataBase = new ShipExportSumDataBase(dataBaseAccess);
		shipExportSumDataBase.setOrderNum(orderNum);
		shipExportSumDataBase.setItem(item);
		shipExportSumDataBase.setRelease(release);

		if (!shipExportSumDataBase.read())
			return null;

		ShipExportSum shipExportSum = this.objectDataBaseToObject(shipExportSumDataBase);

		return shipExportSum;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateShipExportSumInt(ShipExportSum shipExportSum){
    shipExportSum.adjustCalcsValues();

    ShipExportSumDataBase shipExportSumDataBase = this.objectToObjectDataBase(shipExportSum);
    shipExportSumDataBase.update();
}

public 
void updateShipExportSumForcedInt(ShipExportSum shipExportSum){
    //shipExportSum.adjustCalcsValues();

    ShipExportSumDataBase shipExportSumDataBase = this.objectToObjectDataBase(shipExportSum);
    shipExportSumDataBase.updateForced();
}


public 
void updateShipExportSumNoteInt(ShipExportSum shipExportSum){   
    ShipExportSumDataBase shipExportSumDataBase = this.objectToObjectDataBase(shipExportSum);
    shipExportSumDataBase.updateNote();
}

public 
void updateShipExportSum(ShipExportSum shipExportSum){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		 updateShipExportSumInt(shipExportSum);

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
void updateShipExportSumForced(ShipExportSum shipExportSum){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		 updateShipExportSumForcedInt(shipExportSum);

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
void updateShipExportSumNote(ShipExportSum shipExportSum){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		 updateShipExportSumNoteInt(shipExportSum);

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
void writeShipExportSumInt(ShipExportSum shipExportSum){
    shipExportSum.adjustCalcsValues();

    ShipExportSumDataBase shipExportSumDataBase = this.objectToObjectDataBase(shipExportSum);
	shipExportSumDataBase.write();
}

public 
void writeShipExportSum(ShipExportSum shipExportSum){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		writeShipExportSumInt(shipExportSum);

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
void deleteShipExportSum(decimal orderNum, decimal item, string release){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ShipExportSumDataBase shipExportSumDataBase = new ShipExportSumDataBase(dataBaseAccess);

		shipExportSumDataBase.setOrderNum(orderNum);
		shipExportSumDataBase.setItem(item);
		shipExportSumDataBase.setRelease(release);
		shipExportSumDataBase.delete();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
        if (!userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

private
ShipExportSumCompare objectDataBaseToObject(ShipExportSumCompareDataBase shipExportSumCompareDataBase){
	ShipExportSumCompare shipExportSumCompare = new ShipExportSumCompare();

    objectDataBaseToObject(shipExportSumCompare,shipExportSumCompareDataBase);
	shipExportSumCompare.QtyOrderedExcel=shipExportSumCompareDataBase.getQtyOrderedExcel();
	shipExportSumCompare.QtyShippedExcel=shipExportSumCompareDataBase.getQtyShippedExcel();
	shipExportSumCompare.OrderDateExcel =shipExportSumCompareDataBase.getOrderDateExcel();
	shipExportSumCompare.CustRequestDateExcel=shipExportSumCompareDataBase.getCustRequestDateExcel();
	shipExportSumCompare.ShipDateExcel  =shipExportSumCompareDataBase.getShipDateExcel();
	shipExportSumCompare.PPMQtyExcel    = shipExportSumCompareDataBase.getPPMQtyExcel();

    shipExportSumCompare.ActLeadTimeExcel   = shipExportSumCompareDataBase.getActLeadTimeExcel();
    shipExportSumCompare.PPAPExcel          = shipExportSumCompareDataBase.getPPAPExcel();

	return shipExportSumCompare;
}

private
void objectDataBaseToObject(ShipExportSum shipExportSum,ShipExportSumDataBase shipExportSumDataBase){	
	shipExportSum.OrderNum=shipExportSumDataBase.getOrderNum();
	shipExportSum.Item=shipExportSumDataBase.getItem();
	shipExportSum.Release=shipExportSumDataBase.getRelease();
    shipExportSum.Site=shipExportSumDataBase.getSite();
	shipExportSum.BillTo=shipExportSumDataBase.getBillTo();
	shipExportSum.CustPO=shipExportSumDataBase.getCustPO();
	shipExportSum.OrdType=shipExportSumDataBase.getOrdType();
	shipExportSum.Product=shipExportSumDataBase.getProduct();
	shipExportSum.DateRequest=shipExportSumDataBase.getDateRequest();
	shipExportSum.ChangeDate=shipExportSumDataBase.getChangeDate();
	shipExportSum.ShipDate=shipExportSumDataBase.getShipDate();
	shipExportSum.DtWkMonthWkDesc=shipExportSumDataBase.getDtWkMonthWkDesc();
    shipExportSum.MajGroup = shipExportSumDataBase.getMajGroup();
	shipExportSum.MinGroup = shipExportSumDataBase.getMinGroup();
    shipExportSum.MinSales=shipExportSumDataBase.getMinSales();
	shipExportSum.MajSales=shipExportSumDataBase.getMajSales();
	shipExportSum.Ppap=shipExportSumDataBase.getPpap();
	shipExportSum.QtyOrder=shipExportSumDataBase.getQtyOrder();
	shipExportSum.QtyShipped=shipExportSumDataBase.getQtyShipped();
	shipExportSum.QtyOrderSh=shipExportSumDataBase.getQtyOrderSh();
	shipExportSum.QtyShippedSh=shipExportSumDataBase.getQtyShippedSh();
	shipExportSum.QtyPpm=shipExportSumDataBase.getQtyPpm();
	shipExportSum.ActualDays=shipExportSumDataBase.getActualDays();
	shipExportSum.Compliance=shipExportSumDataBase.getCompliance();
	shipExportSum.Include=shipExportSumDataBase.getInclude();
	shipExportSum.Sale=shipExportSumDataBase.getSale();
	shipExportSum.Change=shipExportSumDataBase.getChange();
	shipExportSum.Backord=shipExportSumDataBase.getBackord();
	shipExportSum.ExcludeComment=shipExportSumDataBase.getExcludeComment();
	shipExportSum.ParentRelease=shipExportSumDataBase.getParentRelease();
    shipExportSum.LeadTime  = shipExportSumDataBase.getLeadTime();
    shipExportSum.LeadTime2 = shipExportSumDataBase.getLeadTime2();
    shipExportSum.LeadTime3 = shipExportSumDataBase.getLeadTime3();

    shipExportSum.QtyShippedOnTime  = shipExportSumDataBase.getQtyShippedOnTime();
    shipExportSum.QtyShippedLate    = shipExportSumDataBase.getQtyShippedLate();
    shipExportSum.FixManual         = shipExportSumDataBase.getFixManual();
    shipExportSum.CumQty            = shipExportSumDataBase.getCumQty();
    shipExportSum.QtyOrderedFromCum = shipExportSumDataBase.getQtyOrderedFromCum();
    shipExportSum.Note              = shipExportSumDataBase.getNote();

    shipExportSum.ShipTo            = shipExportSumDataBase.getShipTo();
    shipExportSum.CreateDate        = shipExportSumDataBase.getCreateDate();
    shipExportSum.TradPartner       = shipExportSumDataBase.getTradPartner();
    shipExportSum.DateRequestFromCum= shipExportSumDataBase.getDateRequestFromCum();            
}

private
ShipExportSum objectDataBaseToObject(ShipExportSumDataBase shipExportSumDataBase){
	ShipExportSum shipExportSum = new ShipExportSum();
    objectDataBaseToObject(shipExportSum,shipExportSumDataBase);
	
    return shipExportSum;
}

private
ShipExportSumDataBase objectToObjectDataBase(ShipExportSum shipExportSum){
	ShipExportSumDataBase shipExportSumDataBase = new ShipExportSumDataBase(dataBaseAccess);
	shipExportSumDataBase.setOrderNum(shipExportSum.OrderNum);
	shipExportSumDataBase.setItem(shipExportSum.Item);
	shipExportSumDataBase.setRelease(shipExportSum.Release);
    shipExportSumDataBase.setSite(shipExportSum.Site);
	shipExportSumDataBase.setBillTo(shipExportSum.BillTo);
	shipExportSumDataBase.setCustPO(shipExportSum.CustPO);
	shipExportSumDataBase.setOrdType(shipExportSum.OrdType);
	shipExportSumDataBase.setProduct(shipExportSum.Product);
	shipExportSumDataBase.setDateRequest(shipExportSum.DateRequest);
	shipExportSumDataBase.setChangeDate(shipExportSum.ChangeDate);
	shipExportSumDataBase.setShipDate(shipExportSum.ShipDate);
	shipExportSumDataBase.setDtWkMonthWkDesc(shipExportSum.DtWkMonthWkDesc);
    shipExportSumDataBase.setMajGroup(shipExportSum.MajGroup);
	shipExportSumDataBase.setMinGroup(shipExportSum.MinGroup);
	shipExportSumDataBase.setMinSales(shipExportSum.MinSales);
	shipExportSumDataBase.setMajSales(shipExportSum.MajSales);
	shipExportSumDataBase.setPpap(shipExportSum.Ppap);
	shipExportSumDataBase.setQtyOrder(shipExportSum.QtyOrder);
	shipExportSumDataBase.setQtyShipped(shipExportSum.QtyShipped);
	shipExportSumDataBase.setQtyOrderSh(shipExportSum.QtyOrderSh);
	shipExportSumDataBase.setQtyShippedSh(shipExportSum.QtyShippedSh);
	shipExportSumDataBase.setQtyPpm(shipExportSum.QtyPpm);
	shipExportSumDataBase.setActualDays(shipExportSum.ActualDays);
	shipExportSumDataBase.setCompliance(shipExportSum.Compliance);
	shipExportSumDataBase.setInclude(shipExportSum.Include);
	shipExportSumDataBase.setSale(shipExportSum.Sale);
	shipExportSumDataBase.setChange(shipExportSum.Change);
	shipExportSumDataBase.setBackord(shipExportSum.Backord);
	shipExportSumDataBase.setExcludeComment(shipExportSum.ExcludeComment);
	shipExportSumDataBase.setParentRelease(shipExportSum.ParentRelease);
    shipExportSumDataBase.setLeadTime(shipExportSum.LeadTime);
    shipExportSumDataBase.setLeadTime2(shipExportSum.LeadTime2);
    shipExportSumDataBase.setLeadTime3(shipExportSum.LeadTime3);

    shipExportSumDataBase.setQtyShippedOnTime(shipExportSum.QtyShippedOnTime);
    shipExportSumDataBase.setQtyShippedLate(shipExportSum.QtyShippedLate);
    shipExportSumDataBase.setFixManual(shipExportSum.FixManual);
    shipExportSumDataBase.setCumQty(shipExportSum.CumQty);
    shipExportSumDataBase.setQtyOrderedFromCum(shipExportSum.QtyOrderedFromCum);
    shipExportSumDataBase.setNote(shipExportSum.Note);

    shipExportSumDataBase.setShipTo(shipExportSum.ShipTo);
    shipExportSumDataBase.setCreateDate(shipExportSum.CreateDate);
    shipExportSumDataBase.setTradPartner(shipExportSum.TradPartner);
    shipExportSumDataBase.setDateRequestFromCum(shipExportSum.DateRequestFromCum);

	return shipExportSumDataBase;
}

public
ShipExportSum cloneShipExportSum(ShipExportSum shipExportSum){
	ShipExportSum shipExportSumClone = new ShipExportSum();

	shipExportSumClone.OrderNum=shipExportSum.OrderNum;
	shipExportSumClone.Item=shipExportSum.Item;
	shipExportSumClone.Release=shipExportSum.Release;
    shipExportSumClone.Site=shipExportSum.Site;
	shipExportSumClone.BillTo=shipExportSum.BillTo;
	shipExportSumClone.CustPO=shipExportSum.CustPO;
	shipExportSumClone.OrdType=shipExportSum.OrdType;
	shipExportSumClone.Product=shipExportSum.Product;
	shipExportSumClone.DateRequest=shipExportSum.DateRequest;
	shipExportSumClone.ChangeDate=shipExportSum.ChangeDate;
	shipExportSumClone.ShipDate=shipExportSum.ShipDate;
	shipExportSumClone.DtWkMonthWkDesc=shipExportSum.DtWkMonthWkDesc;    
    shipExportSumClone.MinGroup=shipExportSum.MinGroup;
    shipExportSumClone.MajGroup=shipExportSum.MajGroup;
    shipExportSumClone.MinSales=shipExportSum.MinSales;
	shipExportSumClone.MajSales=shipExportSum.MajSales;
	shipExportSumClone.Ppap=shipExportSum.Ppap;
	shipExportSumClone.QtyOrder=shipExportSum.QtyOrder;
	shipExportSumClone.QtyShipped=shipExportSum.QtyShipped;
	shipExportSumClone.QtyOrderSh=shipExportSum.QtyOrderSh;
	shipExportSumClone.QtyShippedSh=shipExportSum.QtyShippedSh;
	shipExportSumClone.QtyPpm=shipExportSum.QtyPpm;
	shipExportSumClone.ActualDays=shipExportSum.ActualDays;
	shipExportSumClone.Compliance=shipExportSum.Compliance;
	shipExportSumClone.Include=shipExportSum.Include;
	shipExportSumClone.Sale=shipExportSum.Sale;
	shipExportSumClone.Change=shipExportSum.Change;
	shipExportSumClone.Backord=shipExportSum.Backord;
	shipExportSumClone.ExcludeComment=shipExportSum.ExcludeComment;
	shipExportSumClone.ParentRelease=shipExportSum.ParentRelease;
    shipExportSumClone.LeadTime = shipExportSum.LeadTime;
    shipExportSumClone.LeadTime2 = shipExportSum.LeadTime2;
    shipExportSumClone.LeadTime2 = shipExportSum.LeadTime3;

    shipExportSumClone.QtyShippedOnTime = shipExportSum.QtyShippedOnTime;
    shipExportSumClone.QtyShippedLate   = shipExportSum.QtyShippedLate;
    shipExportSumClone.FixManual        = shipExportSum.FixManual;
    shipExportSumClone.CumQty           = shipExportSum.CumQty;
    shipExportSumClone.QtyOrderedFromCum= shipExportSum.QtyOrderedFromCum;
    shipExportSumClone.Note             = shipExportSum.Note;

    shipExportSumClone.ShipTo               = shipExportSum.ShipTo;
    shipExportSumClone.CreateDate           = shipExportSum.CreateDate;
    shipExportSumClone.TradPartner          = shipExportSum.TradPartner;
    shipExportSumClone.DateRequestFromCum   =shipExportSum.DateRequestFromCum;

    return shipExportSumClone;
}

private
bool loadShipExportSum(ShipExport shipExport,ShipExportSumContainer shipExportSumContainer){
    bool            bresult = false;
    ShipExportSum   shipExportSum = readShipExportSum(shipExport.OrderNum, shipExport.Item, shipExport.Release);

    if (shipExportSum == null) { 
        shipExportSum = new ShipExportSum();

        shipExportSum.OrderNum      = shipExport.OrderNum;
        shipExportSum.Item          = shipExport.Item;
        shipExportSum.Release       = shipExport.Release;

        shipExportSum.BillTo        = shipExport.BillTo;
	    shipExportSum.CustPO        = shipExport.CustPO;
	    shipExportSum.OrdType       = shipExport.OrdType;
	    shipExportSum.Product       = shipExport.Product;
	    shipExportSum.DateRequest   = shipExport.DateRequest;
	    shipExportSum.ChangeDate    = DateTime.Now;
	    shipExportSum.ShipDate      = shipExport.ShipDate;
	    //shipExportSum.DtWkMonthWkDesc=shipExport.DtWkMonthWkDesc;
	    shipExportSum.MinSales      = shipExport.MinSales;
	    shipExportSum.MajSales      = shipExport.MajSales;
	    shipExportSum.Ppap          = shipExport.Ppap;
	    shipExportSum.QtyOrder      = shipExport.QtyOrder;
	    shipExportSum.QtyShipped    = shipExport.QtyShipped;
	    //shipExportSum.QtyOrderSh=shipExport.QtyOrderSh;
	    //shipExportSum.QtyShippedSh=shipExport.QtyShippedSh;
	    //shipExportSum.QtyPpm=shipExport.QtyPpm;

	    shipExportSum.ActualDays=1;
	    shipExportSum.Compliance        =Constants.STRING_NO;
	    shipExportSum.Include           =Constants.STRING_NO;
	    shipExportSum.Sale              =Constants.STRING_NO;
	    shipExportSum.Change            =Constants.STRING_NO;
	    shipExportSum.Backord           =Constants.STRING_NO;
	    shipExportSum.ExcludeComment    ="";
	    shipExportSum.ParentRelease     ="";

        bresult=true;
    }
    shipExportSumContainer.Add(shipExportSum);

    return bresult;
}

private
bool loadShipExportSum(ShipExport shipExport, UpCum01PViewContainer upCum01PViewContainerHistory,
                       UpCum01PViewContainer upCum01PViewContainer,ShipExportSumContainer shipExportSumContainer,
                       TradingPartnerDataBaseContainer tradingPartnerDataBaseContainer){
    bool                    bresult                 = false;
    ShipExportSum           shipExportSum           = null;//readShipExportSum(shipExport.OrderNum, shipExport.Item, shipExport.Release);
    UpCum01PViewContainer   upCum01PViewContainerCurrent = new UpCum01PViewContainer();
    decimal                 dqtyOrderMainBase       = shipExport.QtyOrder;    
    string                  srelease                = shipExport.ReleaseBase;
    bool                    bprocess                = true;
    bool                    bprocessDetail          = false;
    UpCum01PView            upCum01PView            = null;
    UpCum01PView            upCum01PViewMainRelease = null;
    bool                    b830Or862           = shipExport.ShipExportSource.Equals(ShipExport.EXPORT_830) ||
                                                  shipExport.ShipExportSource.Equals(ShipExport.EXPORT_862) || shipExport.ShipExportSource.Equals(ShipExport.EXPORT_862_RAN);
        
    if (shipExport.OrdType.Equals("B"))
        bprocess = (!string.IsNullOrEmpty(shipExport.Release) && !string.IsNullOrEmpty(shipExport.ReleaseBase));
    else
        b830Or862=false;
        
    if (bprocess) { 
        
        shipExportSum               = new ShipExportSum();        
        shipExportSum.copy(shipExport);       
        bresult =true;        

        if (shipExport.OrdType.Equals("B") && shipExport.Release.ToUpper().Equals(shipExport.ReleaseBase.ToUpper()))
            shipExportSumContainer.Remove(shipExportSum);//remove just in case already processed for childs, because this is main record
        
        for (int i=0; i < upCum01PViewContainer.Count; i++){
            ShipExport shipExportAux = new ShipExport();
            upCum01PView = upCum01PViewContainer[i];
            shipExportAux.copy(upCum01PViewContainer[i]);
            
            bprocessDetail  = false;
            if (shipExport.OrdType.Equals("B")) { 
                if (shipExport.ReleaseBase.ToUpper().Equals(shipExportAux.ReleaseBase.ToUpper())) { 

                    bprocessDetail  = true;  
                    if (shipExportAux.Release.ToUpper().Equals(shipExport.ReleaseBase.ToUpper())) { 
                        upCum01PViewMainRelease = upCum01PView;

                        if (!b830Or862)
                            shipExportSum.QtyOrder   = dqtyOrderMainBase = shipExportAux.QtyOrdBase;                                 
                        shipExportSum.ChangeDate = shipExport.LastDateChange > shipExport.LastQtyDateChange? shipExport.LastDateChange : shipExport.LastQtyDateChange;
                        shipExportSum.ChangeDate = shipExportSum.ChangeDate != DateUtil.MinValue           ? shipExportSum.ChangeDate  : shipExportAux.CreateDate;
                        shipExportSum.DateRequest= shipExportAux.DateRequest;
                    }  
        
                    if (string.IsNullOrEmpty(shipExportSum.Release)) { 
                        srelease    = shipExportAux.ReleaseBase;
                        shipExportSum.Release = srelease;
                    }	               
                }
            }else{            
                bprocessDetail  = true;                            
                if (shipExportAux.QtyOrdBase > 0) { 
                    shipExportSum.Release   = shipExportAux.ReleaseBase;
                    shipExportSum.QtyOrder  = shipExportAux.QtyOrdBase;
                    
                    shipExportSum.ChangeDate = shipExportAux.ChangeDate != DateUtil.MinValue ? shipExportAux.ChangeDate : shipExportAux.CreateDate;                    
                    if (shipExportSum.ChangeDate == DateUtil.MinValue)
                        shipExportSum.ChangeDate = shipExportSum.CreateDate;                    
                }                
            }

            if (bprocessDetail) { 
                shipExportSum.ShipExportContainer.Add(shipExportAux);
                upCum01PViewContainerCurrent.Add(upCum01PView);

                if (b830Or862)
                    shipExportSum.QtyOrder   = shipExportSum.QtyOrder + shipExportAux.QtyOrder;                              
                shipExportSum.QtyShipped    = shipExportSum.QtyShipped+ shipExportAux.QtyShipped;                     

                if (shipExportSum.ShipDate < shipExportAux.ShipDate)
                    shipExportSum.ShipDate = shipExportAux.ShipDate;

                if (shipExportSum.CreateDate > shipExportAux.CreateDate)
                    shipExportSum.CreateDate = shipExportAux.CreateDate;

                if (upCum01PView.DayLate > 0)
                    shipExportSum.QtyShippedLate    = shipExportSum.QtyShippedLate  + shipExportAux.QtyShipped;
                else
                    shipExportSum.QtyShippedOnTime  = shipExportSum.QtyShippedOnTime+ shipExportAux.QtyShipped;
            }
        }

        if (b830Or862 && shipExportSum.ShipExportContainer.Count > 1 && shipExportSum.sameChildsReleases())
            shipExportSum.QtyOrder = dqtyOrderMainBase;

        if (b830Or862 && upCum01PViewContainerCurrent.Count > 0)
            processQtyOrderMultiplesReleases(shipExport,shipExportSum, upCum01PViewContainerHistory,
                                             upCum01PViewContainerCurrent,upCum01PViewMainRelease,
                                             tradingPartnerDataBaseContainer);
  

        shipExportSumContainer.Add(shipExportSum);
    }

    return bresult;
}

private
void processQtyOrderMultiplesReleases(  ShipExport shipExport,  ShipExportSum  shipExportSum,UpCum01PViewContainer upCum01PViewContainerHistory,
                                        UpCum01PViewContainer   upCum01PViewContainerCurrent,UpCum01PView upCum01PViewMainRelease,
                                        TradingPartnerDataBaseContainer tradingPartnerDataBaseContainer){
    if (upCum01PViewMainRelease!= null) { 
        ShipExport          shipExportLast              = shipExportSum.sameChildsReleases() ? shipExportSum.getLastChildsPosted() : shipExportSum.getLastChildsRelease(upCum01PViewMainRelease.ReleaseBase);
        UpCum01PView        upCum01PViewLast            = null;      
        ShipExportRelease   shipExportReleaseFromLast   = null;
        ShipExportRelease   shipExportReleasMainRel     = null;
        decimal             dqtyOrderPriority1          = shipExportSum.QtyOrder;
        decimal             dqtyOrderPriority2Release   = 0;
        decimal             dqtyOrderPriority3FromCum   = 0;

        if (shipExportLast!= null) { 

            if (upCum01PViewContainerCurrent.Count == 1 && upCum01PViewContainerCurrent[0].FGRLNO.ToUpper().Equals(shipExport.Release.ToUpper()) && shipExport.ShipExportReleaseContainer.Count > 0)
                upCum01PViewMainRelease.ShipExportReleaseContainer = shipExport.ShipExportReleaseContainer; //just to not load release stuff again
            else
                loadShipExportDtlContainersBySqlSteps(upCum01PViewContainerCurrent,tradingPartnerDataBaseContainer);//load 830/862 info

            if (upCum01PViewMainRelease.ShipExportReleaseContainer.Count > 0) { 
                shipExport.CumRequired          = upCum01PViewMainRelease.ShipExportReleaseContainer[0].RelCum;//Cumulative from Main ReleaseBase
                shipExportSum.QtyOrderedFromCum = shipExport.CumRequired - upCum01PViewMainRelease.FGPCUM;
                shipExportSum.DateRequestFromCum= upCum01PViewMainRelease.ShipExportReleaseContainer[0].RelDate;
            }

            upCum01PViewLast= upCum01PViewContainerCurrent.getByRelease(shipExportLast.Release);

            if (upCum01PViewLast!= null && upCum01PViewLast.ShipExportReleaseContainer.Count > 0){

                shipExportReleaseFromLast   = upCum01PViewLast.ShipExportReleaseContainer[0];
                shipExportReleasMainRel     = upCum01PViewMainRelease.ShipExportReleaseContainer.getFirstByRelCum(shipExportReleaseFromLast.RelCum);

                dqtyOrderPriority2Release   = shipExportReleasMainRel!= null ? shipExportReleasMainRel.RelQty : 0;
                if (shipExportReleasMainRel!= null && shipExportSum.QtyOrder!= shipExportSum.QtyShipped)
                    shipExportSum.QtyOrder = shipExportReleasMainRel.RelQty;                
            }

            dqtyOrderPriority3FromCum   = shipExportSum.QtyOrderedFromCum;
            if (shipExportSum.QtyOrder!= shipExportSum.QtyShipped && shipExportSum.QtyShipped == shipExportSum.QtyOrderedFromCum)
                shipExportSum.QtyOrder = shipExportSum.QtyOrderedFromCum;

            loadQtyOrderBasedPriorities(shipExportSum,dqtyOrderPriority1,dqtyOrderPriority2Release,dqtyOrderPriority3FromCum);
        }    
    }
}

private
void loadQtyOrderBasedPriorities(ShipExportSum shipExportSum,decimal dqtyOrderPriority1,
                                decimal dqtyOrderPriority2Release,decimal dqtyOrderPriority3FromCum){
    decimal     difference1=0;
    decimal     difference2=0;
    decimal     difference3=0;

    if (shipExportSum.QtyOrder != shipExportSum.QtyShipped){

        shipExportSum.QtyOrder = dqtyOrderPriority1;
        if (shipExportSum.QtyOrder != shipExportSum.QtyShipped){

            shipExportSum.QtyOrder = dqtyOrderPriority2Release;

            if (shipExportSum.QtyOrder != shipExportSum.QtyShipped){
                shipExportSum.QtyOrder = dqtyOrderPriority3FromCum > 0 ? dqtyOrderPriority3FromCum : shipExportSum.QtyOrder;
                
                if (shipExportSum.QtyOrder != shipExportSum.QtyShipped){
                    //continue not equal , so set QtyOrder value which is more closer to QtyShipped
                    difference1= Math.Abs(dqtyOrderPriority1- shipExportSum.QtyShipped);

                    shipExportSum.QtyOrder = dqtyOrderPriority1;
                    difference2 = dqtyOrderPriority2Release > 0 ? Math.Abs(dqtyOrderPriority2Release - shipExportSum.QtyShipped) : decimal.MaxValue;
                    if (difference2 < difference1)
                        shipExportSum.QtyOrder = dqtyOrderPriority2Release;

                    difference3= dqtyOrderPriority3FromCum > 0 ? Math.Abs(dqtyOrderPriority3FromCum - shipExportSum.QtyShipped) : decimal.MaxValue;
                    if (difference3 < difference2 && difference3  < difference1)
                        shipExportSum.QtyOrder = dqtyOrderPriority3FromCum;                                                   
                }
            }
        }
    }
}

private
void updateBase(UpCum01PView upCum01PView){
    ShipExportDataBase shipExportDataBase = new ShipExportDataBase(dataBaseAccess);

    shipExportDataBase.setSite(upCum01PView.FEPLTC);//plant
    shipExportDataBase.setBol(upCum01PView.FGBOL);
    shipExportDataBase.setBolItem(upCum01PView.FGENT); 
            
    if (shipExportDataBase.read()){
        shipExportDataBase.setReleaseBase(upCum01PView.ReleaseBase);
        shipExportDataBase.setQtyOrdBase(upCum01PView.QtyOrdBase);
        shipExportDataBase.updateBaseFields();                
    }  
}

private
ShipExportSumContainer loadShipExportSumContainer(UpCum01PViewContainer upCum01PViewContainer){
    UpCum01PView                upCum01PView                    = null;
    UpCum01PViewContainer       upCum01PViewContainerOrder      = new UpCum01PViewContainer();
    ShipExportDataBase          shipExportDataBase              = new ShipExportDataBase(dataBaseAccess);
    ShipExport                  shipExport                      = null;
    int                         i                               = 0;
    ShipExportSumContainer      shipExportSumContainer          = new ShipExportSumContainer();
    string                      skey                            = "";
    Hashtable                   hashOrders                      = new Hashtable();
    Hashtable                   hashLeadsPerBillTo              = new Hashtable();
    CustLeadDataBaseContainer   custLeadDataBaseContainerGeneric= new CustLeadDataBaseContainer(dataBaseAccess);
    loadCustLeadHash(out hashLeadsPerBillTo,out custLeadDataBaseContainerGeneric);

    TradingPartnerDataBaseContainer tradingPartnerDataBaseContainer = new TradingPartnerDataBaseContainer(dataBaseAccess);
    tradingPartnerDataBaseContainer.read();

    dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

    //load summary
    for (i=0; i < upCum01PViewContainer.Count; i++) { 
        upCum01PView= upCum01PViewContainer[i];
        shipExport  = upCum01PView.ShipExport;

        if (shipExport == null) { 
            shipExport = new ShipExport();
            shipExport.copy(upCum01PView);        
        }
        
        skey = Convert.ToInt64(upCum01PView.FGORD).ToString() + Constants.DEFAULT_SEP + Convert.ToInt64(upCum01PView.FGITEM).ToString();
        if (hashOrders.Contains(skey)) //check if order/item already searched
            upCum01PViewContainerOrder = (UpCum01PViewContainer)hashOrders[skey];
        else {
            upCum01PViewContainerOrder = readUpCum01PCustomByFiltersInt(hashLeadsPerBillTo,custLeadDataBaseContainerGeneric,tradingPartnerDataBaseContainer,
                    "","","","","",Convert.ToInt32(shipExport.OrderNum).ToString(),
                    "","",Constants.STRING_YES,shipExport.OrdType,"",shipExport.Item,
                    false,"",DateUtil.MinValue,DateUtil.MinValue,0);

            hashOrders.Add(skey,upCum01PViewContainerOrder);
        }
        loadShipExportSum(shipExport, upCum01PViewContainer,upCum01PViewContainerOrder,shipExportSumContainer,tradingPartnerDataBaseContainer);                                    
    }
    return shipExportSumContainer;
}

/*
public
ShipExportSumContainer createShipExportSumNewFields(UpCum01PViewContainer upCum01PViewContainer){
    try{
        UpCum01PView                upCum01PView                    = null;
        UpCum01PViewContainer       upCum01PViewContainerOrder      = new UpCum01PViewContainer();
        ShipExportDataBase          shipExportDataBase              = new ShipExportDataBase(dataBaseAccess);
        ShipExport                  shipExport                      = null;
        int                         i                               = 0;
        ShipExportSumContainer      shipExportSumContainer          = new ShipExportSumContainer();
        string                      skey                            = "";
        Hashtable                   hashOrders                      = new Hashtable();
        Hashtable                   hashLeadsPerBillTo              = new Hashtable();
        CustLeadDataBaseContainer   custLeadDataBaseContainerGeneric= new CustLeadDataBaseContainer(dataBaseAccess);
        loadCustLeadHash(out hashLeadsPerBillTo,out custLeadDataBaseContainerGeneric);

        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        //load summary
        for (i=0; i < upCum01PViewContainer.Count; i++) { 
            upCum01PView = upCum01PViewContainer[i];
            shipExport = new ShipExport();
            shipExport.copy(upCum01PView);

            skey = Convert.ToInt64(upCum01PView.FGORD).ToString() + Constants.DEFAULT_SEP + Convert.ToInt64(upCum01PView.FGITEM).ToString();
            if (hashOrders.Contains(skey)) //check if order/item already searched
                upCum01PViewContainerOrder = (UpCum01PViewContainer)hashOrders[skey];
            else {
                upCum01PViewContainerOrder = readUpCum01PCustomByFiltersInt(hashLeadsPerBillTo,custLeadDataBaseContainerGeneric,
                        "","","","","",Convert.ToInt32(shipExport.OrderNum).ToString(),
                        "","",Constants.STRING_YES,shipExport.OrdType,"",shipExport.Item,
                        false,"",DateUtil.MinValue,DateUtil.MinValue,0);

                hashOrders.Add(skey,upCum01PViewContainerOrder);
            }
            loadShipExportSum(shipExport, upCum01PViewContainerOrder,shipExportSumContainer);                            
        }

        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

        for (i=0; i < shipExportSumContainer.Count; i++){
            ShipExportSum shipExportSum = shipExportSumContainer[i];

            if (existsShipExportSum(shipExportSum.OrderNum,shipExportSum.Item,shipExportSum.Release))
                updateShipExportSumInt(shipExportSum);
            else
                writeShipExportSumInt(shipExportSum);
        }

        return shipExportSumContainer;

    }catch(PersistenceException persistenceException){
    	throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
    	throw new NujitException(exception.Message, exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
    
}
*/
public
ShipExportSumContainer createShipExportSumNewFields(UpCum01PViewContainer upCum01PViewContainer){
    try{
        ShipExportSumContainer      shipExportSumContainer  = loadShipExportSumContainer(upCum01PViewContainer);
        int                         i                       = 0;

        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
 
        for (i=0; i < upCum01PViewContainer.Count; i++)           
            updateBase(upCum01PViewContainer[i]);

        for (i=0; i < shipExportSumContainer.Count; i++){
            ShipExportSum shipExportSum = shipExportSumContainer[i];

            if (existsShipExportSum(shipExportSum.OrderNum,shipExportSum.Item,shipExportSum.Release))
                updateShipExportSumInt(shipExportSum);
            else
                writeShipExportSumInt(shipExportSum);
        }

        return shipExportSumContainer;

    }catch(PersistenceException persistenceException){
    	throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
    	throw new NujitException(exception.Message, exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}

public
ShipExportContainer adjustShipExporAndSumLeadTime(ShipExport shipExport){
    try{                    
        ShipExportContainer     shipExportContainer         = readShipExportByFilters(shipExport.BillTo,"", shipExport.MajSales, shipExport.ShipDate, shipExport.DateRequest,0);
        ShipExportContainer     shipExportContainerResult   = new ShipExportContainer();
        ShipExportSumDataBase   shipExportSumDataBase = new ShipExportSumDataBase(dataBaseAccess);
        bool                    badjustLeadTime     = false;
                        
        for (int i=0; i < shipExportContainer.Count; i++){
            ShipExport shipExportNew = shipExportContainer[i];

            badjustLeadTime     = false;

            if (string.IsNullOrEmpty(shipExport.MajSales) && string.IsNullOrEmpty(shipExport.MinSales)) //both empty
                badjustLeadTime = true;
            if (shipExportNew.MajSales.ToUpper().Equals(shipExport.MajSales.ToUpper()) &&               //match both
                shipExportNew.MajSales.ToUpper().Equals(shipExport.MinSales.ToUpper())) 
                badjustLeadTime = true;
            if (string.IsNullOrEmpty(shipExport.MinSales) &&                                           //match maj sales
                !string.IsNullOrEmpty(shipExport.MajSales) && shipExportNew.MajSales.ToUpper().Equals(shipExport.MajSales.ToUpper())) 
                badjustLeadTime = true;
            if (string.IsNullOrEmpty(shipExport.MajSales)  &&                                           //match min sales
                !string.IsNullOrEmpty(shipExport.MinSales) && shipExportNew.MinSales.ToUpper().Equals(shipExport.MinSales.ToUpper()))
                badjustLeadTime = true;

            if (badjustLeadTime) { 
                switch(shipExport.BackFlag){
                    case "1": shipExportNew.LeadTime = shipExport.LeadTime;break;
                    case "2": shipExportNew.LeadTime2= shipExport.LeadTime;break;
                    case "3": shipExportNew.LeadTime3= shipExport.LeadTime;break;
                }
                
                ShipExportDataBase shipExportDataBase = this.objectToObjectDataBase(shipExportNew);
	            shipExportDataBase.update();
                shipExportContainerResult.Add(shipExportNew);

                if (shipExportNew.Release.ToUpper().Equals(shipExportNew.ReleaseBase.ToUpper())){
                    shipExportSumDataBase.setOrderNum(shipExportNew.OrderNum);
                    shipExportSumDataBase.setItem(shipExportNew.Item);
                    shipExportSumDataBase.setRelease(shipExportNew.ReleaseBase);

                    if (shipExportSumDataBase.read()){
                        //if (shipExportSumDataBase.getOrdType().Equals("S") && string.IsNullOrEmpty(shipExportSumDataBase.getRelease()) &&  !DateUtil.sameDate(shipExportSumDataBase.getShipDate(),shipExportDataBase.getShipDate())) //if Standard 
                            //badjustLeadTime = false;

                        switch (shipExport.BackFlag){
                            case "1": shipExportSumDataBase.setLeadTime(shipExport.LeadTime);break;
                            case "2": shipExportSumDataBase.setLeadTime2(shipExport.LeadTime);break;
                            case "3": shipExportSumDataBase.setLeadTime3(shipExport.LeadTime);break;
                        }

                        if (badjustLeadTime)
                            shipExportSumDataBase.update();
                    }
                }
            }
        }

        return shipExportContainerResult;

    }catch(PersistenceException persistenceException){
    	throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
    	throw new NujitException(exception.Message, exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }    
}

public
ShipExportContainer readShipExportByFilters(string sbillTo,string shipTo,string smajSales,DateTime fromShipDate,DateTime toShipDate,int rows){
    try{   
        ShipExportContainer             shipExportContainer         = new ShipExportContainer();
        ShipExportDataBaseContainer     shipExportDataBaseContainer = new ShipExportDataBaseContainer(dataBaseAccess);

        shipExportDataBaseContainer.readByFilters(sbillTo, shipTo, smajSales,"",fromShipDate, toShipDate,rows);

        foreach(ShipExportDataBase shipExportDataBase in shipExportDataBaseContainer)
            shipExportContainer.Add(objectDataBaseToObject(shipExportDataBase));
                    
        return shipExportContainer;

    }catch(PersistenceException persistenceException){
    	throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
    	throw new NujitException(exception.Message, exception);
	}

}

public
void loadGenericPriorCum(){
    try{   
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

        ShipExportDataBase          shipExportDataBase = new ShipExportDataBase(dataBaseAccess);
        ShipExportDataBaseContainer shipExportDataBaseContainer = new ShipExportDataBaseContainer(dataBaseAccess);
        shipExportDataBaseContainer.readByFilters("","","","B",DateUtil.MinValue,DateUtil.MinValue,0);
                    
        System.Windows.Forms.MessageBox.Show("ShipExport REad :" + shipExportDataBaseContainer.Count);        

        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);
    
        BoldDataBase boldDataBase = new BoldDataBase(dataBaseAccess);
        for (int i=0; i < shipExportDataBaseContainer.Count;i++){

            shipExportDataBase= (ShipExportDataBase)shipExportDataBaseContainer[i];

            boldDataBase.setFGBOL(shipExportDataBase.getBol());
            boldDataBase.setFGENT(shipExportDataBase.getBolItem());
            if (boldDataBase.read()){
                        
                shipExportDataBase.setCumQty(boldDataBase.getFGCCUM());
                shipExportDataBase.setCumPrior(boldDataBase.getFGPCUM());
                shipExportDataBase.setQtyRequired(shipExportDataBase.getCumQty() - shipExportDataBase.getCumPrior());
                shipExportDataBase.setQtyOrderedFromCum(shipExportDataBase.getCumRequired() - shipExportDataBase.getCumPrior());                        
            }            
        }                  

        System.Windows.Forms.MessageBox.Show("End Load From Bold :" + shipExportDataBaseContainer.Count); 
        
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);     
                
        for (int i=0; i < shipExportDataBaseContainer.Count;i++){
            shipExportDataBase= (ShipExportDataBase)shipExportDataBaseContainer[i];  
            shipExportDataBase.updateCums();
        }

        System.Windows.Forms.MessageBox.Show("End Updates :" + shipExportDataBaseContainer.Count); 

    }catch(PersistenceException persistenceException){
    	throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
    	throw new NujitException(exception.Message, exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
}


public
ShipExportSumContainer readShipExportSumByFilters(string splant,string sbillTo, string shipTo,string sbol,string sorder,string scustPO,string sdocType,string srelease,decimal orderItem,bool blateOrders,string sppap,DateTime fromDate, DateTime toDate,int irows){
    try{   
        ShipExportSumContainer          shipExportSumContainer          = new ShipExportSumContainer();
        ShipExportSumDataBaseContainer  shipExportSumDataBaseContainer  = new ShipExportSumDataBaseContainer(dataBaseAccess);

        shipExportSumDataBaseContainer.readByFilters(splant,sbillTo, shipTo, sbol, sorder,scustPO, sdocType, srelease, orderItem, blateOrders, sppap, fromDate, toDate, irows);

        foreach(ShipExportSumDataBase shipExportSumDataBase in shipExportSumDataBaseContainer)
            shipExportSumContainer.Add(objectDataBaseToObject(shipExportSumDataBase));
                    
        return shipExportSumContainer;

    }catch(PersistenceException persistenceException){
    	throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
    	throw new NujitException(exception.Message, exception);
	}

}

public
ShipExportSumContainer readShipExportSumCompareByFilters(string splant,string sbillTo, string shipTo,string sbol,string sorder,string scustPO,string sdocType,string srelease,decimal orderItem,bool blateOrders,string sppap,DateTime fromDate, DateTime toDate,
                                                        bool bqtyOrder, bool bqtyShip, bool bdateReq, bool bdateShip,bool bqtyPpm,bool bleadTime, bool bppap, int irows){
    try{   
        ShipExportSumContainer                  shipExportSumContainer                  = new ShipExportSumContainer();
        ShipExportSumCompareDataBaseContainer   shipExportSumCompareDataBaseContainer   = new ShipExportSumCompareDataBaseContainer(dataBaseAccess);

        shipExportSumCompareDataBaseContainer.readByFilters(splant,sbillTo, shipTo, sbol,sorder, scustPO, sdocType, srelease, orderItem, blateOrders, sppap, fromDate, toDate,
                                                            bqtyOrder, bqtyShip, bdateReq, bdateShip, bqtyPpm, bleadTime, bppap,irows);

        foreach(ShipExportSumCompareDataBase shipExportSumCompareDataBase in shipExportSumCompareDataBaseContainer)
            shipExportSumContainer.Add(objectDataBaseToObject(shipExportSumCompareDataBase));
                    
        return shipExportSumContainer;

    }catch(PersistenceException persistenceException){
    	throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
    	throw new NujitException(exception.Message, exception);
	}

}


} // class

} // namespace