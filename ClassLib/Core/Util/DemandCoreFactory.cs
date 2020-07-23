/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Cms;
using Nujit.NujitERP.ClassLib.Common;


namespace Nujit.NujitERP.ClassLib.Core.Util{


public
class DemandCoreFactory : CompanyCoreFactory{

protected
DemandCoreFactory() : base(){
}


public
DemandH createDemandH(){
	return new DemandH();
}

public
DemandHContainer createDemandHContainer(){
	return new DemandHContainer();
}

public
bool existsDemandH(int id){
	try{
		DemandHDataBase demandHDataBase = new DemandHDataBase(dataBaseAccess);

		demandHDataBase.setId(id);

		return demandHDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
DemandH readDemandH(int id){
	try{
      
        return readDemandHInternal(id);

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
DemandH readDemandHLast(string splant){
	try{
        DemandHDataBase demandHDataBase = new DemandHDataBase(dataBaseAccess);
		if (!demandHDataBase.readLastByFilter(splant))
			return null;

		return readDemandHInternal(demandHDataBase.getId());
        
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
DemandH readDemandHInternal(int id){

	DemandHDataBase demandHDataBase = new DemandHDataBase(dataBaseAccess);
	demandHDataBase.setId(id);

	if (!demandHDataBase.read())
		return null;

	DemandH demandH = this.objectDataBaseToObject(demandHDataBase);

    DemandDDataBaseContainer demandDDataBaseContainer = new DemandDDataBaseContainer(dataBaseAccess);
    demandDDataBaseContainer.readByHdr(demandH.Id);

    foreach(DemandDDataBase demandDDataBase in demandDDataBaseContainer)
        demandH.addDtl(this.objectDataBaseToObject(demandDDataBase));

    return demandH;	
}

public 
void updateDemandH(DemandH demandH){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        updateDemandHInternal(demandH);		

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
void updateDemandHSpecicDtl(DemandH demandH,DemandD demandD){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        DemandHDataBase demandHDataBase = this.objectToObjectDataBase(demandH);
	    demandHDataBase.update();

        if (demandD!= null){
            DemandDDataBase demandDDataBase = objectToObjectDataBase(demandD);
            demandDDataBase.update();
        }

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
void updateDemandHInternal(DemandH demandH){	
	DemandHDataBase demandHDataBase = this.objectToObjectDataBase(demandH);
	demandHDataBase.update();

    deleteDemandHChilds(demandH.Id);
    writeDemandHChilds(demandH);
}

internal
void updateDemandHHeader(DemandH demandH){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		DemandHDataBase demandHDataBase = this.objectToObjectDataBase(demandH);
		demandHDataBase.update();
        
	    if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
void writeDemandH(DemandH demandH){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		DemandHDataBase demandHDataBase = this.objectToObjectDataBase(demandH);
		demandHDataBase.write();

		if (!userHandleTransaction)
		    dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
void writeDemandHChilds(DemandH demandH){
    demandH.fillRedundances();

    foreach(DemandD demandD in demandH.DemandDContainer){
        DemandDDataBase DemandDDataBase = this.objectToObjectDataBase(demandD);
        DemandDDataBase.write();
    }
	
}


public 
void deleteDemandHChilds(int id){
    DemandDDataBaseContainer demandDDataBaseContainer = new DemandDDataBaseContainer(dataBaseAccess);
    demandDDataBaseContainer.deleteByHdr(id);   	
}

public
void deleteDemandH(int id){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		DemandHDataBase demandHDataBase = new DemandHDataBase(dataBaseAccess);

        deleteDemandHChilds(id);

		demandHDataBase.setId(id);
		demandHDataBase.delete();
		
		if (!userHandleTransaction)
		    dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
DemandH processDemand830862ByDate(string splant,DateTime startDate,DateTime endDate,bool bimportItems,bool bimportInventory){
    int ipriorConnectionType = ConnectionManager.getCURRENT_CONNECTION_TYPE();
    try{        
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);

        DemandH                         demandH     = new DemandH();
        DemandH                         demandHPrior= null;
        DemandHDataBaseContainer        demandHDataBaseContainer = new DemandHDataBaseContainer(dataBaseAccess);
        DemandDDataBaseContainer        demandDDataBaseContainer = new DemandDDataBaseContainer(dataBaseAccess);
        demandDDataBaseContainer.read830862ByDates(splant,startDate, endDate);        

        foreach (DemandDDataBase demandDDataBase in demandDDataBaseContainer)
            demandH.addDtl(objectDataBaseToObject(demandDDataBase));
        
        if (bimportItems)
            generateCMSItems(splant,false);
        if (bimportInventory)              
            generateCMSInventory2();
        
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

try{

        demandHPrior = readDemandHLast(splant); //read last demand , which will be prior created
       
        demandH.Id = demandHDataBaseContainer.readMAxId() + 1;
        demandH.DateTime = DateTime.Now;
        demandH.StaDate = startDate;
        demandH.EndDate = endDate;
        demandH.Status = Nujit.NujitERP.ClassLib.Common.Constants.STATUS_ACTIVE;
        demandH.Plant = splant;
        
        DemandHDataBase demandHDataBase = objectToObjectDataBase(demandH);
        demandHDataBase.write();
        demandH.Id = demandHDataBase.getId();
        writeDemandHChilds(demandH);

        if (demandHPrior!= null && demandH.removeDuplicates(demandHPrior))            
            updateDemandHInternal(demandHPrior);
        
    }catch(System.Exception exception){
            System.Windows.Forms.MessageBox.Show("processDemand830862ByDate write Demand" + "\n\n" + "Error:" + exception.Message);
		    throw new PersistenceException(exception.Message, exception);
	}  
       
		if (!userHandleTransaction)
		    dataBaseAccess.commitTransaction();

        return demandH;

	}catch(PersistenceException persistenceException){        
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}finally {
        if (ipriorConnectionType == DataBaseAccess.NUJIT_DATABASE)
            dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
    }
    return null;
}

public
DemandHContainer readDemandHByFilters(string id,string splant,string status,decimal dtrlpKeyId,DateTime fromDate,DateTime toDate,int rows){    
    try{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

        DemandHContainer                demandHContainer = new DemandHContainer();
        DemandHDataBaseContainer        demandHDataBaseContainer = new DemandHDataBaseContainer(dataBaseAccess);
        demandHDataBaseContainer.readByFilters(id, splant, status, dtrlpKeyId,fromDate, toDate,rows);        

        foreach (DemandHDataBase demandHDataBase in demandHDataBaseContainer)
            demandHContainer.Add(objectDataBaseToObject(demandHDataBase));

        return demandHContainer;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
}


private
DemandH objectDataBaseToObject(DemandHDataBase demandHDataBase){
	DemandH demandH = new DemandH();

	demandH.Id=demandHDataBase.getId();
	demandH.DateTime=demandHDataBase.getDateTime();	
	demandH.Status=demandHDataBase.getStatus();
	demandH.StaDate=demandHDataBase.getStaDate();	
	demandH.EndDate=demandHDataBase.getEndDate();	
    demandH.Plant = demandHDataBase.getPlant();
    
	return demandH;
}

internal
DemandHDataBase objectToObjectDataBase(DemandH demandH){
	DemandHDataBase demandHDataBase = new DemandHDataBase(dataBaseAccess);
	demandHDataBase.setId(demandH.Id);
	demandHDataBase.setDateTime(demandH.DateTime);	
	demandHDataBase.setStatus(demandH.Status);
	demandHDataBase.setStaDate(demandH.StaDate);	
	demandHDataBase.setEndDate(demandH.EndDate);	
    demandHDataBase.setPlant(demandH.Plant);

	return demandHDataBase;
}

public
DemandH cloneDemandH(DemandH demandH){
	DemandH demandHClone = new DemandH();

	demandHClone.Id=demandH.Id;
	demandHClone.DateTime=demandH.DateTime;	
	demandHClone.Status=demandH.Status;
	demandHClone.StaDate=demandH.StaDate;	
	demandHClone.EndDate=demandH.EndDate;	
    demandHClone.Plant = demandH.Plant;

	return demandHClone;
}

/************************************************************ DemandD ****************************************/
public
DemandD createDemandD(){
	return new DemandD();
}

public
DemandDContainer createDemandDContainer(){
	return new DemandDContainer();
}

protected
DemandD objectDataBaseToObject(DemandDDataBase demandDDataBase){
	DemandD demandD = new DemandD();

	demandD.HdrId=demandDDataBase.getHdrId();
	demandD.Detail=demandDDataBase.getDetail();
	demandD.Source=demandDDataBase.getSource();
	demandD.TPartner=demandDDataBase.getTPartner();
	demandD.RelDate=demandDDataBase.getRelDate();
	demandD.RelNum=demandDDataBase.getRelNum();
	demandD.BillTo=demandDDataBase.getBillTo();
	demandD.ShipTo=demandDDataBase.getShipTo();
	demandD.ShipLoc=demandDDataBase.getShipLoc();
	demandD.ShipLTim=demandDDataBase.getShipLTim();
	demandD.ShipLTUn=demandDDataBase.getShipLTUn();
	demandD.Part=demandDDataBase.getPart();
	demandD.CustPart=demandDDataBase.getCustPart();
	demandD.CurrCum=demandDDataBase.getCurrCum();
	demandD.FaAutCum=demandDDataBase.getFaAutCum();
	demandD.MaAutCum=demandDDataBase.getMaAutCum();
	demandD.CurShDoc=demandDDataBase.getCurShDoc();
	demandD.SDate=demandDDataBase.getSDate();
	demandD.EndDate=demandDDataBase.getEndDate();
	demandD.QtyCum=demandDDataBase.getQtyCum();
	demandD.AdjNQty=demandDDataBase.getAdjNQty();
    demandD.NetQty = demandDDataBase.getNetQty();
    demandD.TimeCode = demandDDataBase.getTimeCode();
    demandD.TrlpKeyId =  demandDDataBase.getTrlpKeyId();
    demandD.Discard = demandDDataBase.getDiscard();
    demandD.LogNum = demandDDataBase.getLogNum();
    
    return demandD;
}

protected
DemandDDataBase objectToObjectDataBase(DemandD demandD){
	DemandDDataBase demandDDataBase = new DemandDDataBase(dataBaseAccess);
	demandDDataBase.setHdrId(demandD.HdrId);
	demandDDataBase.setDetail(demandD.Detail);
	demandDDataBase.setSource(demandD.Source);
	demandDDataBase.setTPartner(demandD.TPartner);
	demandDDataBase.setRelDate(demandD.RelDate);
	demandDDataBase.setRelNum(demandD.RelNum);
	demandDDataBase.setBillTo(demandD.BillTo);
	demandDDataBase.setShipTo(demandD.ShipTo);
	demandDDataBase.setShipLoc(demandD.ShipLoc);
	demandDDataBase.setShipLTim(demandD.ShipLTim);
	demandDDataBase.setShipLTUn(demandD.ShipLTUn);
	demandDDataBase.setPart(demandD.Part);
	demandDDataBase.setCustPart(demandD.CustPart);
	demandDDataBase.setCurrCum(demandD.CurrCum);
	demandDDataBase.setFaAutCum(demandD.FaAutCum);
	demandDDataBase.setMaAutCum(demandD.MaAutCum);
	demandDDataBase.setCurShDoc(demandD.CurShDoc);
	demandDDataBase.setSDate(demandD.SDate);
	demandDDataBase.setEndDate(demandD.EndDate);
	demandDDataBase.setQtyCum(demandD.QtyCum);
	demandDDataBase.setAdjNQty(demandD.AdjNQty);
    demandDDataBase.setNetQty(demandD.NetQty);
    demandDDataBase.setTimeCode(demandD.TimeCode);
    demandDDataBase.setTrlpKeyId(demandD.TrlpKeyId);
    demandDDataBase.setDiscard(demandD.Discard);
    demandDDataBase.setLogNum(demandD.LogNum);

	return demandDDataBase;
}

public
DemandD cloneDemandD(DemandD demandD){
	DemandD demandDClone = new DemandD();

	demandDClone.HdrId=demandD.HdrId;
	demandDClone.Detail=demandD.Detail;
	demandDClone.Source=demandD.Source;
	demandDClone.TPartner=demandD.TPartner;
	demandDClone.RelDate=demandD.RelDate;
	demandDClone.RelNum=demandD.RelNum;
	demandDClone.BillTo=demandD.BillTo;
	demandDClone.ShipTo=demandD.ShipTo;
	demandDClone.ShipLoc=demandD.ShipLoc;
	demandDClone.ShipLTim=demandD.ShipLTim;
	demandDClone.ShipLTUn=demandD.ShipLTUn;
	demandDClone.Part=demandD.Part;
	demandDClone.CustPart=demandD.CustPart;
	demandDClone.CurrCum=demandD.CurrCum;
	demandDClone.FaAutCum=demandD.FaAutCum;
	demandDClone.MaAutCum=demandD.MaAutCum;
	demandDClone.CurShDoc=demandD.CurShDoc;
	demandDClone.SDate=demandD.SDate;
	demandDClone.EndDate=demandD.EndDate;
	demandDClone.QtyCum=demandD.QtyCum;
	demandDClone.AdjNQty=demandD.AdjNQty;
    demandDClone.NetQty = demandD.NetQty;
    demandDClone.TimeCode=demandD.TimeCode;    
    demandDClone.TrlpKeyId = demandD.TrlpKeyId;
    demandDClone.Discard = demandD.Discard;
    demandDClone.LogNum = demandD.LogNum;

	return demandDClone;
}

public
DemandDView createDemandDView(){
	return new DemandDView();
}

public
DemandDViewContainer createDemandDViewContainer(){
	return new DemandDViewContainer();
}

public
DemandDCompareViewContainer createDemandDCompareViewContainer(){
	return new DemandDCompareViewContainer();
}

public
DemandDCompareLeftViewContainer createDemandDCompareLeftViewContainer(){    
    return new DemandDCompareLeftViewContainer();
}

public
DemandDCompareReportViewContainer createDemandDCompareReportViewContainer(){    
    return new DemandDCompareReportViewContainer();
}

public
DemandDViewContainer getDemandDViewReportByFilters(int id,string source,string stimecode,string stpartner, string sbillTo,string shipTo,string spart,bool baddAuthorizations,bool baddTimeCode,int irows){
    try { 
    DemandDViewContainer            demandDViewContainer = new DemandDViewContainer();    
    DemandDView                     demandDView= null;
    DemandDView                     demandDViewPrior= null;
    DateTime                        priorMonday = DateTime.Now;
    DateTime                        nextSunday = DateTime.Now;           
    DemandDViewDataBaseContainer    demandDViewDataBaseContainer = new DemandDViewDataBaseContainer(dataBaseAccess);
    demandDViewDataBaseContainer.readByFiltersGroupBy(id,source,stimecode, stpartner,sbillTo,shipTo,spart, baddAuthorizations, baddTimeCode,irows);

    DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now,out priorMonday,out nextSunday);

    foreach (DemandDViewDataBase demandDViewDataBase in demandDViewDataBaseContainer){
        demandDView = objectDataBaseToObject(demandDViewDataBase);

        if (demandDViewPrior!= null && demandDViewPrior.Equals(demandDView)  && ( !baddAuthorizations || demandDViewPrior.EqualsAuhotization(demandDView)) ){
            demandDViewPrior.setSummarizeQtyByDate(priorMonday, demandDView.SDate, demandDView.NetQty);
        }else{
            demandDView.setSummarizeQtyByDate(priorMonday, demandDView.SDate, demandDView.NetQty);
            demandDViewPrior = demandDView;
            demandDViewContainer.Add(demandDView);
        }
    }

    return demandDViewContainer;

    }catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
}

private
string getKeyHash(string spant, DemandDCompareView demandDNew){
    char   sep  = Constants.DEFAULT_SEP;
    string skey = spant.ToUpper()           + sep + demandDNew.Source.ToUpper()    + sep + demandDNew.TPartner.ToUpper()+ sep +
                demandDNew.ShipLoc.ToUpper()+ sep + demandDNew.Part.ToUpper()      + sep + demandDNew.RelNum.ToUpper()  + sep +
                DateUtil.getDateRepresentation(demandDNew.SDate,DateUtil.MMDDYYYY) + sep + Convert.ToInt64(demandDNew.NetQty);
    return skey;
}
       
public
DemandDCompareViewContainer getDemandDCompareViewReportByFilters(string splant,string source,string stPartner,string shipLoc, string spart,DateTime runDate,DateTime startRelDate, DateTime endRelDate,bool bcumulative,int irows){
    try { 
    DemandDCompareViewContainer         demandDCompareViewContainer = new DemandDCompareViewContainer();    
    DemandDCompareView                  demandDCompareView  = null;
    DemandDCompareView                  demandDCompareViewPrior= null;
    DateTime                            priorMonday         = DateTime.Now;
    DateTime                            nextSunday          = DateTime.Now;   
    Hashtable                           hashProcessed       = new Hashtable();
    bool                                bprocess            =true;
    string                              skey                ="";
    DemandDCompareViewDataBaseContainer demandDCompareViewDataBaseContainer = new DemandDCompareViewDataBaseContainer(dataBaseAccess);
    demandDCompareViewDataBaseContainer.readByFiltersGroupBy(splant,source, stPartner,  shipLoc, spart, startRelDate, endRelDate,bcumulative,irows);      
    bool                                bis862              = false;
    DemandHContainer                    demandHContainer    = new DemandHContainer();
            
    DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now,out priorMonday,out nextSunday);                  

    foreach (DemandDCompareViewDataBase demandDCompareViewDataBase in demandDCompareViewDataBaseContainer){
        demandDCompareView = objectDataBaseToObject(demandDCompareViewDataBase);

        bprocess=true;
        bis862  = demandDCompareView.Source.ToUpper().Equals(DemandD.SOURCE_862.ToUpper());
        if (bis862 && string.IsNullOrEmpty(demandDCompareView.RelNum) && demandDCompareView.RelDate == DateUtil.MinValue) { 
            demandDCompareView.RelNum = "DUMP-" + demandDCompareView.HdrId.ToString();
            demandDCompareView.RelDate= getDemandHDate(demandDCompareView.HdrId,demandHContainer);
        }

        skey    = getKeyHash(splant,demandDCompareView);

        if (bis862){            
            if (hashProcessed.Contains(skey))   bprocess=false;
            else                                hashProcessed.Add(skey,demandDCompareView);                
        }

        if (bprocess) { 
            //if (demandDCompareViewPrior != null &&  ((!bis862 && demandDCompareViewPrior.Equals(demandDCompareView)) || (bis862 && demandDCompareViewPrior.Equals862(demandDCompareView)))){    
            if (demandDCompareViewPrior != null &&  demandDCompareViewPrior.Equals(demandDCompareView)){
                demandDCompareViewPrior.setSummarizeQtyByDate(runDate, demandDCompareView.SDate, demandDCompareView.NetQty);
            }else{
                demandDCompareView.setSummarizeQtyByDate(runDate, demandDCompareView.SDate, demandDCompareView.NetQty);
                demandDCompareViewPrior = demandDCompareView;
                demandDCompareViewContainer.Add(demandDCompareView);
            }
        }
    }

    if (string.IsNullOrEmpty(source)  || source.ToUpper().Equals(DemandD.SOURCE_830))
        demandDCompareViewContainer.sortByRelDate();
    return demandDCompareViewContainer;

    }catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
}

public
DemandDCompareViewContainer getAS400DemandDCompareViewReportByFilters(string splant,string source,string stPartner,string shipLoc, string spart,DateTime runDate,DateTime startRelDate, DateTime endRelDate, bool bcumulative, int irows){
    try { 
    dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);  

    DemandDCompareViewContainer         demandDCompareViewContainer = new DemandDCompareViewContainer();    
    DemandDCompareView                  demandDCompareView  = null;
    DemandDCompareView                  demandDCompareViewPrior= null;    
    Hashtable                           hashProcessed       = new Hashtable();
    bool                                bprocess            =true;
    string                              skey                ="";
    DemandDCompareViewDataBaseContainer demandDCompareViewDataBaseContainer = new DemandDCompareViewDataBaseContainer(dataBaseAccess);    
    bool                                bis862              = false;
    DemandHContainer                    demandHContainer    = new DemandHContainer();
                   
    bis862 = source.ToUpper().Equals(DemandD.SOURCE_862.ToUpper());
    if (bis862)
        demandDCompareViewDataBaseContainer.readAS400ByFilters862GroupBy(splant,source, stPartner,  shipLoc, spart, startRelDate, endRelDate,bcumulative,irows);      
    else
        demandDCompareViewDataBaseContainer.readAS400ByFiltersGroupBy(splant,source, stPartner,  shipLoc, spart, startRelDate, endRelDate,bcumulative,irows);      
                                  
    foreach (DemandDCompareViewDataBase demandDCompareViewDataBase in demandDCompareViewDataBaseContainer){
        demandDCompareView = objectDataBaseToObject(demandDCompareViewDataBase);

        bprocess=true;
        bis862  = demandDCompareView.Source.ToUpper().Equals(DemandD.SOURCE_862.ToUpper());
        if (bis862 && string.IsNullOrEmpty(demandDCompareView.RelNum) && demandDCompareView.RelDate == DateUtil.MinValue) { 
            demandDCompareView.RelNum = "DUMP-" + demandDCompareView.HdrId.ToString();
            demandDCompareView.RelDate= getDemandHDate(demandDCompareView.HdrId,demandHContainer);
        }

        skey    = getKeyHash(splant,demandDCompareView);                   

        if (bprocess)
            loadDemandDCompareViewContainer(demandDCompareViewContainer,demandDCompareView,runDate,bcumulative,ref demandDCompareViewPrior);
                        /*
                    {        
            //if cumulative just put the Qty, recors are being ordered by date too, so last date might be filled                             
            if (demandDCompareViewPrior != null &&  demandDCompareViewPrior.Equals(demandDCompareView)){
                if (bcumulative) demandDCompareViewPrior.setQtyByDate(runDate, demandDCompareView.SDate, demandDCompareView.NetQty);
                else    demandDCompareViewPrior.setSummarizeQtyByDate(runDate, demandDCompareView.SDate, demandDCompareView.NetQty);
            }else{
                if (bcumulative)     demandDCompareView.setQtyByDate(runDate, demandDCompareView.SDate, demandDCompareView.NetQty);
                else        demandDCompareView.setSummarizeQtyByDate(runDate, demandDCompareView.SDate, demandDCompareView.NetQty);
                demandDCompareViewPrior = demandDCompareView;
                demandDCompareViewContainer.Add(demandDCompareView);
            }
        }*/
    }
            
    return demandDCompareViewContainer;

    }catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);  
    }
}

public
DemandDCompareViewContainer getLocalDemandDCompareViewReportByFilters(string splant,string source,string stPartner,string shipLoc, string spart,DateTime runDate,DateTime startRelDate, DateTime endRelDate, bool bcumulative,bool bqtyDifferences,int irows){
    try { 
    
    DemandDCompareViewContainer         demandDCompareViewContainer = new DemandDCompareViewContainer();    
    DemandDCompareView                  demandDCompareView  = null;
    DemandDCompareView                  demandDCompareViewPrior= null;    
    Hashtable                           hashProcessed       = new Hashtable();
    bool                                bprocess            =true;
    string                              skey                ="";
    DemandDCompareViewDataBaseContainer demandDCompareViewDataBaseContainer = new DemandDCompareViewDataBaseContainer(dataBaseAccess);    
    bool                                bis862              = false;
    DemandHContainer                    demandHContainer    = new DemandHContainer();
                   
    demandDCompareViewDataBaseContainer.readDemandDayByFiltersGroupBy(splant,source, stPartner,  shipLoc, spart, startRelDate, endRelDate,bcumulative, bqtyDifferences,irows);      
                                  
    foreach (DemandDCompareViewDataBase demandDCompareViewDataBase in demandDCompareViewDataBaseContainer){
        demandDCompareView = objectDataBaseToObject(demandDCompareViewDataBase);

        bprocess=true;
        bis862  = demandDCompareView.Source.ToUpper().Equals(DemandD.SOURCE_862.ToUpper());
        if (bis862 && string.IsNullOrEmpty(demandDCompareView.RelNum) && demandDCompareView.RelDate == DateUtil.MinValue) { 
            demandDCompareView.RelNum = "DUMP-" + demandDCompareView.HdrId.ToString();
            demandDCompareView.RelDate= getDemandHDate(demandDCompareView.HdrId,demandHContainer);
        }

        skey    = getKeyHash(splant,demandDCompareView);                   

        if (bprocess)
            loadDemandDCompareViewContainer(demandDCompareViewContainer,demandDCompareView,runDate,bcumulative,ref demandDCompareViewPrior);                    
    }

    
    if (bcumulative)        
        calculateFullSummary(demandDCompareViewContainer, runDate);
    else
        calculateNetsQty(demandDCompareViewContainer, runDate);    
            
    return demandDCompareViewContainer;

    }catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);  
    }
}

private
void loadDemandDCompareViewContainer(DemandDCompareViewContainer demandDCompareViewContainer, DemandDCompareView demandDCompareView, DateTime runDate, bool bcumulative,ref DemandDCompareView demandDCompareViewPrior){
        //if cumulative just put the Qty, recors are being ordered by date too, so last date might be filled                             
    if (demandDCompareViewPrior != null &&  demandDCompareViewPrior.Equals(demandDCompareView)){
        if (bcumulative) demandDCompareViewPrior.setQtyByDate(runDate, demandDCompareView.SDate, demandDCompareView.NetQty);
        else    demandDCompareViewPrior.setSummarizeQtyByDate(runDate, demandDCompareView.SDate, demandDCompareView.NetQty);
    }else{
        if (bcumulative)     demandDCompareView.setQtyByDate(runDate, demandDCompareView.SDate, demandDCompareView.NetQty);
        else        demandDCompareView.setSummarizeQtyByDate(runDate, demandDCompareView.SDate, demandDCompareView.NetQty);
        demandDCompareViewPrior = demandDCompareView;
        demandDCompareViewContainer.Add(demandDCompareView);
    }
}

private
DateTime getDemandHDate(int id,DemandHContainer demandHContainer){
    DateTime    date    = DateUtil.MinValue;
    DemandH     demandH = demandHContainer.getByKey(id);

    if (demandH==null) {
        DemandHDataBase demandHDataBase = new DemandHDataBase(dataBaseAccess);
        demandHDataBase.setId(id);
        if (demandHDataBase.read()){ 
            demandH = objectDataBaseToObject(demandHDataBase);
            demandHContainer.Add(demandH);
        }
    }

    if (demandH!= null)
        date = demandH.DateTime;

    return date;
}

public
DemandDCompareViewContainer getAS400DemandDCompareViewReportBoldByFilters(string splant,string source,string stPartner,string shipLoc, string spart,DateTime runDate,DateTime startRelDate, DateTime endRelDate, bool bcumulative, int irows){
    try { 
    dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);  

    DemandDCompareViewContainer         demandDCompareViewContainer = new DemandDCompareViewContainer();    
    DemandDCompareView                  demandDCompareView  = null;
    DemandDCompareView                  demandDCompareViewPrior= null;        
    DemandDCompareViewDataBaseContainer demandDCompareViewDataBaseContainer = new DemandDCompareViewDataBaseContainer(dataBaseAccess);        
    DemandHContainer                    demandHContainer    = new DemandHContainer();
                   
    demandDCompareViewDataBaseContainer.readAS400BoldByFiltersGroupBy(splant,source, stPartner,  shipLoc, spart, startRelDate, endRelDate,bcumulative,irows);      
                                  
    foreach (DemandDCompareViewDataBase demandDCompareViewDataBase in demandDCompareViewDataBaseContainer){
        demandDCompareView = objectDataBaseToObject(demandDCompareViewDataBase);        
        loadDemandDCompareViewContainer(demandDCompareViewContainer,demandDCompareView,runDate,bcumulative,ref demandDCompareViewPrior);                    
    }
            
    return demandDCompareViewContainer;

    }catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);  
    }
}

       
public
ArrayList readDemandDTradingPartners(string splant,string source){
    try { 
        DemandDDataBaseContainer    demandDDataBaseContainer = new DemandDDataBaseContainer(dataBaseAccess);    
        ArrayList                   array = demandDDataBaseContainer.readDistinctTradingPartners(splant,source);
    
        return array;

    }catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
}

public
ArrayList readDemandDShipLocs(string splant,string source,string stpartner){
    try { 
        DemandDDataBaseContainer    demandDDataBaseContainer = new DemandDDataBaseContainer(dataBaseAccess);    
        ArrayList                   array = demandDDataBaseContainer.readDistinctShipLoc(splant,source,stpartner);
    
        return array;

    }catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
}

public
ArrayList readDemandDPartsByFilters(string splant, string source,string stpartner,string shipLoc){
    try { 
        DemandDDataBaseContainer    demandDDataBaseContainer = new DemandDDataBaseContainer(dataBaseAccess);    
        ArrayList                   array = demandDDataBaseContainer.readDistinctParts(splant,source,stpartner,shipLoc);
    
        return array;

    }catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
}

   

private
DemandDView objectDataBaseToObject(DemandDViewDataBase demandDViewDataBase){
	DemandDView demandDView = new DemandDView();

	demandDView.Source=demandDViewDataBase.getSource();
	demandDView.BillTo=demandDViewDataBase.getBillTo();
	demandDView.ShipTo=demandDViewDataBase.getShipTo();
    demandDView.ShipLoc = demandDViewDataBase.getShipLoc();
	demandDView.Part=demandDViewDataBase.getPart();
    demandDView.Seq = demandDViewDataBase.getSeq();
	demandDView.CustPart=demandDViewDataBase.getCustPart();
	demandDView.SDate=demandDViewDataBase.getSDate();
	demandDView.NetQty = demandDViewDataBase.getNetQty();
    demandDView.TimeCode = demandDViewDataBase.getTimeCode();
    demandDView.Qoh = demandDViewDataBase.getQoh();

    demandDView.FaAutCum = demandDViewDataBase.getFaAutCum();
    demandDView.MaAutCum = demandDViewDataBase.getMaAutCum();


    return demandDView;
}

private
DemandDCompareView objectDataBaseToObject(DemandDCompareViewDataBase demandDCompareViewDataBase){
	DemandDCompareView demandDCompareView = new DemandDCompareView();

    demandDCompareView.HdrId    = demandDCompareViewDataBase.getHdrId();
    demandDCompareView.Source   = demandDCompareViewDataBase.getSource();
    demandDCompareView.TPartner = demandDCompareViewDataBase.getTPartner();
    demandDCompareView.RelDate  = demandDCompareViewDataBase.getRelDate();
    demandDCompareView.RelNum   = demandDCompareViewDataBase.getRelNum();
	demandDCompareView.ShipLoc  = demandDCompareViewDataBase.getShipLoc();
	demandDCompareView.Part     = demandDCompareViewDataBase.getPart();
    demandDCompareView.SDate    = demandDCompareViewDataBase.getSDate();
	demandDCompareView.NetQty   = demandDCompareViewDataBase.getNetQty();    

    return demandDCompareView;
}

/******************************************  DemTransform  ***************************************************************/
public
DemTransformH createDemTransformH(){
	return new DemTransformH();
}

public
DemTransformHContainer createDemTransformHContainer(){
	return new DemTransformHContainer();
}

public
DemTransformOptions createDemTransformOptions(){
	return new DemTransformOptions();
}

public
bool existsDemTransformH(int id){
	try{
		DemTransformHDataBase demTransformHDataBase = new DemTransformHDataBase(dataBaseAccess);

		demTransformHDataBase.setId(id);

		return demTransformHDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
DemTransformH readDemTransformH(int id){
	try{		            
        return readDemTransformHInternal(id);
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
DemTransformH readDemTransformHInternal(int id){	
	DemTransformHDataBase demTransformHDataBase = new DemTransformHDataBase(dataBaseAccess);
	demTransformHDataBase.setId(id);

	if (!demTransformHDataBase.read())
		return null;

	DemTransformH demTransformH = this.objectDataBaseToObject(demTransformHDataBase);

    DemTransformDDataBaseContainer demTransformDDataBaseContainer = new DemTransformDDataBaseContainer(dataBaseAccess);
    demTransformDDataBaseContainer.readByHeader(id);

    foreach (DemTransformDDataBase demTransformDDataBase in demTransformDDataBaseContainer)
        demTransformH.DemTransformDContainer.Add(objectDataBaseToObject(demTransformDDataBase));
            
    return demTransformH;
	
}

public
string[][] getDemTransformHByDesc(string searchText, int rows){
	try{
		DemTransformHDataBaseContainer demTransformHDataBaseContainer = new DemTransformHDataBaseContainer(dataBaseAccess);
		demTransformHDataBaseContainer.readByDesc(searchText, rows);
		string[][] items = new string[demTransformHDataBaseContainer.Count][];
		int i = 0;
		for(IEnumerator en = demTransformHDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			DemTransformHDataBase demTransformHDataBase = (DemTransformHDataBase) en.Current;
			string[] item = new String[4];
			item[0] = demTransformHDataBase.getId().ToString();
			item[1] = demTransformHDataBase.getDateCreated().ToString();
			item[2] = demTransformHDataBase.getDemandHdr().ToString();
			item[3] = demTransformHDataBase.getStatus();
			items[i] = item;
			i++;
		}
		return items;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateDemTransformH(DemTransformH demTransformH){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		DemTransformHDataBase demTransformHDataBase = this.objectToObjectDataBase(demTransformH);
		demTransformHDataBase.update();

        deleteDemTransformHChilds(demTransformH.Id);
        writeDemTransformHChilds(demTransformH);

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public 
void writeDemTransformH(DemTransformH demTransformH){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		 writeDemTransformHInternal(demTransformH);

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public 
void writeDemTransformHInternal(DemTransformH demTransformH){

    DemTransformHDataBase demTransformHDataBase = this.objectToObjectDataBase(demTransformH);
	demTransformHDataBase.write();

	demTransformH.Id=demTransformHDataBase.getId();
    writeDemTransformHChilds(demTransformH);
}

public 
void writeDemTransformHChilds(DemTransformH demTransformH){
    demTransformH.fillRedundances();

    foreach(DemTransformD demTransformD in demTransformH.DemTransformDContainer){
        DemTransformDDataBase demTransformDDataBase = this.objectToObjectDataBase(demTransformD);
        demTransformDDataBase.write();
    }	
}

public 
void deleteDemTransformHChilds(int id){
     DemTransformDDataBaseContainer demTransformDDataBaseContainer = new DemTransformDDataBaseContainer(dataBaseAccess);
     demTransformDDataBaseContainer.deleteByHeader(id);
}

public
void deleteDemTransformH(int id){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        deleteDemTransformHChilds(id);

        DemTransformHDataBase demTransformHDataBase = new DemTransformHDataBase(dataBaseAccess);

		demTransformHDataBase.setId(id);
		demTransformHDataBase.delete();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

private
DemTransformH objectDataBaseToObject(DemTransformHDataBase demTransformHDataBase){
	DemTransformH demTransformH = new DemTransformH();

	demTransformH.Id=demTransformHDataBase.getId();
	demTransformH.DateCreated=demTransformHDataBase.getDateCreated();
	demTransformH.DemandHdr=demTransformHDataBase.getDemandHdr();
	demTransformH.Status=demTransformHDataBase.getStatus();
    demTransformH.Plant =demTransformHDataBase.getPlant();
    demTransformH.MonthMode= demTransformHDataBase.getMonthMode();
    demTransformH.WeekMode = demTransformHDataBase.getWeekMode();

	return demTransformH;
}

private
DemTransformHDataBase objectToObjectDataBase(DemTransformH demTransformH){
	DemTransformHDataBase demTransformHDataBase = new DemTransformHDataBase(dataBaseAccess);
	demTransformHDataBase.setId(demTransformH.Id);
	demTransformHDataBase.setDateCreated(demTransformH.DateCreated);
	demTransformHDataBase.setDemandHdr(demTransformH.DemandHdr);
	demTransformHDataBase.setStatus(demTransformH.Status);
    demTransformHDataBase.setPlant(demTransformH.Plant);
    demTransformHDataBase.setMonthMode(demTransformH.MonthMode);
    demTransformHDataBase.setWeekMode(demTransformH.WeekMode);

	return demTransformHDataBase;
}

public
DemTransformH cloneDemTransformH(DemTransformH demTransformH){
	DemTransformH demTransformHClone = new DemTransformH();

	demTransformHClone.Id=demTransformH.Id;
	demTransformHClone.DateCreated=demTransformH.DateCreated;
	demTransformHClone.DemandHdr=demTransformH.DemandHdr;
	demTransformHClone.Status=demTransformH.Status;
    demTransformHClone.Plant=demTransformH.Plant;
    demTransformHClone.MonthMode= demTransformH.MonthMode;
    demTransformHClone.WeekMode = demTransformH.WeekMode;

    for (int i=0; i < demTransformH.DemTransformDContainer.Count;i++)
        demTransformHClone.DemTransformDContainer.Add(cloneDemTransformD(demTransformH.DemTransformDContainer[i]));

	return demTransformHClone;
}


public
DemTransformD createDemTransformD(){
	return new DemTransformD();
}

public
DemTransformDContainer createDemTransformDContainer(){
	return new DemTransformDContainer();
}

private
DemTransformD objectDataBaseToObject(DemTransformDDataBase demTransformDDataBase){
	DemTransformD demTransformD = new DemTransformD();

	demTransformD.HdrId=demTransformDDataBase.getHdrId();
	demTransformD.Detail=demTransformDDataBase.getDetail();
	demTransformD.DemandHdr=demTransformDDataBase.getDemandHdr();
	demTransformD.DemandDetail=demTransformDDataBase.getDemandDetail();
	demTransformD.DemDate=demTransformDDataBase.getDemDate();
	demTransformD.Qty=demTransformDDataBase.getQty();

	return demTransformD;
}

private
DemTransformDDataBase objectToObjectDataBase(DemTransformD demTransformD){
	DemTransformDDataBase demTransformDDataBase = new DemTransformDDataBase(dataBaseAccess);
	demTransformDDataBase.setHdrId(demTransformD.HdrId);
	demTransformDDataBase.setDetail(demTransformD.Detail);
	demTransformDDataBase.setDemandHdr(demTransformD.DemandHdr);
	demTransformDDataBase.setDemandDetail(demTransformD.DemandDetail);
	demTransformDDataBase.setDemDate(demTransformD.DemDate);
	demTransformDDataBase.setQty(demTransformD.Qty);

	return demTransformDDataBase;
}

public
DemTransformD cloneDemTransformD(DemTransformD demTransformD){
	DemTransformD demTransformDClone = new DemTransformD();

	demTransformDClone.HdrId=demTransformD.HdrId;
	demTransformDClone.Detail=demTransformD.Detail;
	demTransformDClone.DemandHdr=demTransformD.DemandHdr;
	demTransformDClone.DemandDetail=demTransformD.DemandDetail;
	demTransformDClone.DemDate=demTransformD.DemDate;
	demTransformDClone.Qty=demTransformD.Qty;

	return demTransformDClone;
}

public
DemTransformH processDemandTransform(DemTransformOptions demTransformOptions){    
    try{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

        DemandH     demandH = demTransformOptions.DemandH;

        processDemandMerge830862Internal(demandH); //merge 830/862
        
        DemTransformH demTransformH = new DemTransformH();
        demTransformH.DateCreated = DateTime.Now;
        demTransformH.DemandHdr = Convert.ToInt32(demandH.Id);
        demTransformH.Plant = demandH.Plant;
        demTransformH.MonthMode= demTransformOptions.MonthMode;
        demTransformH.WeekMode = demTransformOptions.WeekMode;

        ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);        
        ProdFmInfoDataBase          prodFmInfoDataBase = null;
        decimal                     demandLowQtySplit =0;
        bool                        bdiscard = false;

        prodFmInfoDataBaseContainer.read();//read all parts, faster than read each part at a time

        bool bfinish=false;

        for (int i=0; i < demandH.DemandDContainer.Count && !bfinish; i++){
            DemandD     demandD = demandH.DemandDContainer[i];
            bdiscard    = demandD.Discard.Equals(Constants.STRING_YES);

            if (!bdiscard && demandD.NetQty != 0 && demandD.ProcessTransform){ //AF only process qty differents than zero

                prodFmInfoDataBase = prodFmInfoDataBaseContainer.getProdFmInfo(demandD.Part);
                demandLowQtySplit = prodFmInfoDataBase!= null ? prodFmInfoDataBase.getPFS_DemandLowQtySplit() : 1;
                
                switch(demandD.TimeCode.ToUpper().Trim()){                 
                    case Constants.TIME_CODE_DAILY:
                    case "":
                        processDemandDaily(demandD,demTransformH);
                        break;                                                    
                    case Constants.TIME_CODE_WEEKLY:
                        processDemandDailyOption(demTransformH.WeekMode,demandD,demTransformH,demandLowQtySplit);                        
                        break;                
                    case Constants.TIME_CODE_MONTHLY:
                        processDemandDailyOption(demTransformH.MonthMode,demandD,demTransformH,demandLowQtySplit);
                        break;
                }
            }            
        }

        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        writeDemTransformHInternal(demTransformH);        

        demandH.Status = Nujit.NujitERP.ClassLib.Common.Constants.STATUS_TRANSFORM;
        updateDemandHInternal(demandH);                                      

	    if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

        return demTransformH;

	}catch(PersistenceException persistenceException){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

private
void processDemandDailyOption(string stimeCode,DemandD demandD,DemTransformH demTransformH,decimal demandLowQtySplit){
    switch(stimeCode.ToUpper()){                 
        case Constants.TIME_CODE_DAILY:
        case "":
            processDemandDaily(demandD,demTransformH);
            break;                                       
        case Constants.TIME_CODE_WEEKLY:
            processDemandWeekly(demandD,demTransformH,demandLowQtySplit);
            break;                
        case Constants.TIME_CODE_MONTHLY:
            processDemandMonthly(demandD,demTransformH,demandLowQtySplit);                    
            break;
    }
}

private
DemTransformD createDemTransformD(DemandD demandD, DateTime demDate, decimal qty){
    DemTransformD demTransformD = new DemTransformD();

    demTransformD.DemandHdr= (int)demandD.HdrId;
    demTransformD.DemandDetail= (int)demandD.Detail;

    demTransformD.DemDate = demDate;
    demTransformD.Qty = qty;

    return demTransformD;
}


private
void processDemandDaily(DemandD demandD,DemTransformH demTransformH){
    DateTime    shipDate= demandD.SDate;    
    decimal     dqty = demandD.NetQty;
    
    while (shipDate.DayOfWeek == DayOfWeek.Saturday || shipDate.DayOfWeek == DayOfWeek.Sunday)
        shipDate = shipDate.AddDays(1);

    demTransformH.DemTransformDContainer.Add(createDemTransformD(demandD,shipDate, dqty));    
}

private
void processDemandWeekly(DemandD demandD,DemTransformH demTransformH,decimal demandLowQtySplit){
    DateTime    shipDate= demandD.SDate;
    int         idayOfWeek = (int)demandD.SDate.DayOfWeek;
    int         itotDaysOnWeek = 6 - idayOfWeek;  
    int         icounter=1;    
    decimal     dqty = 0;

    if (itotDaysOnWeek<=0)  itotDaysOnWeek=1;
    if (itotDaysOnWeek>=6)  itotDaysOnWeek=5;

    dqty = demandD.NetQty / itotDaysOnWeek;

    if (dqty < 1 || demandD.NetQty < demandLowQtySplit)
        processDemandDaily(demandD,demTransformH);
    else { 
        do {
            while (shipDate.DayOfWeek == DayOfWeek.Saturday || shipDate.DayOfWeek == DayOfWeek.Sunday)
                shipDate = shipDate.AddDays(1);

            demTransformH.DemTransformDContainer.Add(createDemTransformD(demandD, shipDate, dqty));
            shipDate = shipDate.AddDays(1);
            icounter++;

        } while (icounter <= itotDaysOnWeek);                
    }
}

private
void processDemandMonthly(DemandD demandD,DemTransformH demTransformH,decimal demandLowQtySplit){
    int         imonth  = demandD.SDate.Month;
    DateTime    shipDate= demandD.SDate;
    DateTime    shipDateAux= demandD.SDate;
    int         itotDaysOnMonth=0;    
    decimal     dqty = 0;

    //Sab Dom Lun
    //1   2   3
    //get day total on month, but not counting Saturday/Sunday
    do {                
        if (shipDateAux.DayOfWeek != DayOfWeek.Saturday && shipDateAux.DayOfWeek != DayOfWeek.Sunday)
           itotDaysOnMonth++;
         shipDateAux = shipDateAux.AddDays(1);
    } while (shipDateAux.Month == imonth); //until change month

    dqty = demandD.NetQty / itotDaysOnMonth;

    if (dqty < 1 || demandD.NetQty < demandLowQtySplit)
        processDemandDaily(demandD,demTransformH);
    else { 
        for (int i=0; i < itotDaysOnMonth; i++){      
            while (shipDate.DayOfWeek == DayOfWeek.Saturday || shipDate.DayOfWeek == DayOfWeek.Sunday)
                shipDate = shipDate.AddDays(1);

            demTransformH.DemTransformDContainer.Add(createDemTransformD(demandD, shipDate, dqty));
            shipDate = shipDate.AddDays(1);
        }
    }
}

public
DemTransformH getDemTransformHdrByMaxID(int demandHdr){
	try{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);              
    
        return getDemTransformHdrByMaxIDInternal(demandHdr);
                                    
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
DemTransformH getDemTransformHdrByMaxIDInternal(int demandHdr){
	
    DemTransformH demTransformH = null;
    
    DemTransformHDataBase demTransformHDataBase = new DemTransformHDataBase(dataBaseAccess);

    if (!demTransformHDataBase.readByDemandHdrMaxId(demandHdr))
        return null;

    demTransformH = readDemTransformHInternal(demTransformHDataBase.getId());
    
    return demTransformH;
}

public
DemandH processDemandMerge830862(DemandH demandH){    
    try{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

        processDemandMerge830862Internal(demandH);                
        return demandH;

    }catch(PersistenceException persistenceException){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!userHandleTransaction)
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public
void processDemandMerge830862Internal(DemandH demandH){    
    
        DemandD             demandD = null;
        DemandD             demandDShipPart = null;
        DemandDContainer    demandDContainer = new DemandDContainer();
        DemandDContainer    demandDContainerSameShipPart = new DemandDContainer();          
        DemandDContainer    demandDContainerRemove = new DemandDContainer();
        Hashtable           hashShipParts = new Hashtable();
        Hashtable           hashYearWeaks = new Hashtable();        

        int                 i=0;
        string              skey = "";
                               
        //get demandd records, grouped by Year/week
        for (i=0; i < demandH.DemandDContainer.Count; i++){
            demandD = demandH.DemandDContainer[i];

            skey = demandD.SDate.Year + "-" + DateUtil.weekNumber(demandD.SDate);
            if (hashYearWeaks.ContainsKey(skey)){
                demandDContainer = (DemandDContainer)hashYearWeaks[skey];
                demandDContainer.Add(demandD);
            }else{
                demandDContainer = new DemandDContainer();
                demandDContainer.Add(demandD);
                hashYearWeaks.Add(skey, demandDContainer);
            }             
        }
                
        //process for each Year/week
        foreach(DictionaryEntry entryYearWeaks in hashYearWeaks){

            demandDContainer = (DemandDContainer)entryYearWeaks.Value;
            hashShipParts = demandDContainer.getHashShipParts();  //get differents shipto/parts to be processed each one
                               	
	        foreach(DictionaryEntry entry in hashShipParts){

                demandDShipPart = (DemandD)entry.Value;

                demandDContainerSameShipPart.Clear();                    
                for (i=0;  i < demandDContainer.Count; i++){
                    demandD = demandDContainer[i];                    

                    //if same shipto and part
                    if (demandDShipPart.ShipTo.ToUpper().Equals(demandD.ShipTo.ToUpper()) && 
                        demandDShipPart.Part.ToUpper().Equals(demandD.Part.ToUpper())){

                        demandDContainerSameShipPart.Add(demandD);
                        
                        demandDContainer.RemoveAt(i);//dtl ready to be processed so I will remove, tring to make it faster
                        i--;
                    }                    
                }

                if (demandDContainerSameShipPart.Count > 0)
                    checkMerge830862(demandDContainerSameShipPart, demandDContainerRemove);                
	        }	
            
	    }	
        
        //System.Windows.Forms.MessageBox.Show("Remove Count:" + demandDContainerRemove.Count);  

        for (i=0;  i < demandDContainerRemove.Count; i++){
            demandD = demandDContainerRemove[i];
            demandD.ProcessTransform = false;
        }                
}

private
void checkMerge830862(DemandDContainer demandDContainer,DemandDContainer demandDContainerRemove){
    demandDContainer.sortByShipPartDateSource();
    
    DemandD     demandD830 = demandDContainer.getFirstBySourceTimeCodeTrlpKeyId(DemandD.SOURCE_830,"W",0);//get first 83o/Weekle found not matter TrlpKeyId=0
    DemandD     demandD862 = null;
    decimal     dqumulative = 0;
    decimal     dnetSummary = 0;

    if (demandD830!=null){
        demandD862 = demandDContainer.getFirstBySourceTimeCodeTrlpKeyId(DemandD.SOURCE_862, "D", (int)demandD830.TrlpKeyId);
        demandDContainer.getCumulativeNetQtySummaryBySourceTimeCodeTrlpKeyId(out dqumulative, out dnetSummary, DemandD.SOURCE_862,"D", (int)demandD830.TrlpKeyId);
    }  
            /*
    if (demandD862 != null && demandD830 != null){
        System.Windows.Forms.MessageBox.Show("On checkMerge830862 :" + "\n" +
                                            "Ship  To:" + demandD830.ShipTo+ "-" + demandD862.ShipTo + "\n" +
                                            "Part   :"  + demandD830.Part   +"-" + demandD862.Part   + "\n" +
                                            "Source:"   + demandD830.Source + "-" + demandD862.Source+ "\n" +
                                            "Qty Cum:"  + ((int)demandD830.NetQty).ToString() + "-" + ((int)dqumulative).ToString() + "\n" +
                                            "Ship Date:"+ DateUtil.getDateRepresentation(demandD830.SDate, DateUtil.YYYYMMDD) + "-"+ DateUtil.getDateRepresentation(demandD862.SDate, DateUtil.YYYYMMDD));                            


    }  */
        
    if (demandD862 != null && demandD830 != null && 
        DateUtil.getDateRepresentation(demandD862.SDate,DateUtil.YYYYMMDD).Equals(DateUtil.getDateRepresentation(demandD830.SDate, DateUtil.YYYYMMDD)) &&
        demandD830.NetQty == dqumulative){                    
        demandDContainerRemove.Add(demandD830);          
                
        demandD830.ProcessTransform = false;                        

        /*
        System.Windows.Forms.MessageBox.Show("Found To Remove:" + "\n" +
                                             "Date:" + DateUtil.getDateRepresentation(demandD862.SDate, DateUtil.YYYYMMDD) + 
                                             "Qty Cumulative:" + dqumulative.ToString("0.0") + "\n" +
                                             "Net Sum Qty:" + dnetSummary.ToString("0.0"));
        */
    }                                
}


public
void processDemandTransformH(DemandH demandH, DemTransformH demTransformH){    
    try{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);
        DemandDContainer    demandDContainer = new DemandDContainer();
        Hashtable           hashInventory = new Hashtable();
        int                 ilevel = 0;
        ProdFmInfoDataBase  prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
        string              spart="";    
        int                 iseq=0;                                

        ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    prodFmInfoDataBaseContainer.read(); 

        ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
	    prodFmActSubDataBaseContainer.read(); 

        demTransformH.DemTransformDContainer.sortByDemDatePart(); //sort by date
        demTransformH.DemTransformDContainer.linkToDemandD(demandH.DemandDContainer);
                //Hashtable hashParts = demTransformH.DemTransformDContainer.getHashByPart();

        InvPltLocDataBaseContainer invPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);

        for (int i=0;  i < demTransformH.DemTransformDContainer.Count; i++){
            DemTransformD demTransformD = demTransformH.DemTransformDContainer[i];
            
         
            if (demTransformD.DemandD!=null && demTransformD.DemandD.Part.ToUpper().Equals("CC1653")){
                spart= demTransformD.DemandD.Part;   
                iseq=0;

                prodFmInfoDataBase = prodFmInfoDataBaseContainer.getProdFmInfo(spart);
                if (prodFmInfoDataBase!= null){
                                                
                    iseq= prodFmInfoDataBase.getPFS_SeqLast();
                    ilevel = 0;
                    processDemandTransformInt(demTransformH.Plant,spart, iseq, demTransformD.DemandD.NetQty, demTransformD.DemDate, hashInventory, demandDContainer, ilevel, prodFmActSubDataBaseContainer);
                }
            }
            
        }

    }catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message,exception);
	}
}

private
decimal getInventory(string spart,int iseq,string splant,Hashtable hashInventory){
    decimal     dqoh=0;
    string      skey = spart + "-" + iseq;                   

    if (hashInventory.Contains(skey))
        dqoh = (decimal)hashInventory[skey];  
    else{
        InvPltLocDataBaseContainer invPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);          
        dqoh = invPltLocDataBaseContainer.getSumQtyByPartSeq(spart,iseq,splant);
        hashInventory.Add(skey, dqoh);
    }   
    return dqoh;
}

private
int getMinorSequence(ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer,string spart,int iseq){
    int iseqResult=0;

    for (int j=0;  j < prodFmActSubDataBaseContainer.Count ; j++){
        ProdFmActSubDataBase prodFmActSubDataBase = (ProdFmActSubDataBase)prodFmActSubDataBaseContainer[j];       
        if (prodFmActSubDataBase.getPC_ProdID().Equals(spart.ToUpper()) && prodFmActSubDataBase.getPC_Seq() < iseq && prodFmActSubDataBase.getPC_Seq() > iseqResult){
            iseqResult = prodFmActSubDataBase.getPC_Seq();           
        }
    }
    return iseqResult;
}

public
void processDemandTransformInt(string splant,string spart,int iseq,decimal dqty,DateTime shipDate, Hashtable hashInventory,DemandDContainer demandDContainer,int ilevel, ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer){    
    BomSumTempContainer bomSumTempContainer  = this.readBomSumTreeProdSeq(spart, iseq);
    decimal             dqoh = getInventory(spart, iseq,splant,hashInventory);
    decimal             dqtyBuild = dqty;
    string              skey = spart + "-" + iseq;   
    DemandD             demandD = null;

    if (dqtyBuild <= dqoh){
        dqoh-= dqtyBuild;
        dqtyBuild = 0;
    } else{
        dqtyBuild -= dqoh;
        dqoh = 0;        
    }

    if (hashInventory.Contains(skey))
        hashInventory[skey] = dqoh;

    while (bomSumTempContainer.Count <= 0 && iseq > 0){    
        iseq= getMinorSequence(prodFmActSubDataBaseContainer, spart, iseq);   
        bomSumTempContainer  = this.readBomSumTreeProdSeq(spart, iseq);
    }

    ArrayList arrayChils = bomSumTempContainer.getProductChildren(spart, iseq);        
    /*
    ArrayList arrayChils = new ArrayList();

    do{
        bomSumTempContainer  = this.readBomSumTreeProdSeq(spart, iseq);



        arrayChils = bomSumTempContainer.getProductChildren(spart, iseq);        
        if (bomSumTempContainer.Count < 1 && iseq > 0)       
            iseq= getMinorSequence(prodFmActSubDataBaseContainer, spart, iseq);                             
        
    } while(bomSumTempContainer.Count <= 0 && iseq > 0);

    arrayChils = bomSumTempContainer.getProductSubMaterials(spart, iseq);
    */

    ilevel++;
    for (int j=0;  j < arrayChils.Count; j++){
        BomSum bomSum = (BomSum)arrayChils[j];                               

        demandD = new DemandD();
        
        demandD.Part = bomSum.getBMS_MatID();
        //demandD.Seq  = bomSum.getBMS_MatSeq();
        demandD.SDate= shipDate;
        demandD.NetQty =  dqtyBuild * bomSum.getBMS_MatQty();


        /*System.Windows.Forms.MessageBox.Show(   "Part:" + spart + "\n" +
                                                "Seq:" + iseq + "\n" +
                                                "ShipDate:" + DateUtil.getDateRepresentation(shipDate,DateUtil.MMDDYYYY) + "\n" +
                                                "Qty:" + dqtyBuild.ToString("0.0") + "\n" +
                                                "Material:" + bomSum.getBMS_MatID() + "\n" +
                                                "Child Qty:" + demandD.NetQty.ToString("0.0") + "\n"); */                               

        processDemandTransformInt(splant,bomSum.getBMS_MatID(), bomSum.getBMS_MatSeq(), demandD.NetQty,shipDate,hashInventory, demandDContainer,ilevel, prodFmActSubDataBaseContainer);
    }                                         
}

/*
public
void processDemandTransformInt(string spart,DemTransformDContainer demTransformDContainer){        
    InvPltLocDataBaseContainer invPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);    
    int         iseq=0;
    decimal     dqtyBuild=0;    
    decimal     dqoh = invPltLocDataBaseContainer.getSumQtyByPartSeq(spart,iseq);
    decimal     dmatQty=0;
            
    for (int i=0;  i < demTransformDContainer.Count; i++){
        DemTransformD demTransformD = demTransformDContainer[i];

        dqtyBuild = demTransformD.Qty - dqoh;
        if (dqtyBuild < 0)
            dqoh-= demTransformD.Qty;
        else{
            
            BomSumTempContainer bomSumTempContainer  = this.readBomSumTreeProdSeq(spart,iseq);
            ArrayList arrayChils = bomSumTempContainer.getProductChildren(spart, iseq);

            for (int j=0;  j < arrayChils.Count; j++){
                BomSum bomSum = (BomSum)arrayChils[j];                
                dmatQty = bomSum.getBMS_MatQty() * dqtyBuild;

                

            }                                         
        }        
    }
}

private
void processDemandTransformRecursive(string spart,int iseq,decimal dqty,decimal dqoh,decimal ){        
    InvPltLocDataBaseContainer invPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);    
    
    decimal     dqtyBuild=0;    
    decimal     dqoh = invPltLocDataBaseContainer.getSumQtyByPartSeq(spart,iseq);
    decimal     dmatQty=0;
            
    for (int i=0;  i < demTransformDContainer.Count; i++){
        DemTransformD demTransformD = demTransformDContainer[i];

        dqtyBuild = demTransformD.Qty - dqoh;
        if (dqtyBuild < 0)
            dqoh-= demTransformD.Qty;
        else{
            
            BomSumTempContainer bomSumTempContainer  = this.readBomSumTreeProdSeq(spart,iseq);
            ArrayList arrayChils = bomSumTempContainer.getProductChildren(spart, iseq);

            for (int j=0;  j < arrayChils.Count; j++){
                BomSum bomSum = (BomSum)arrayChils[j];                
                dmatQty = bomSum.getBMS_MatQty() * dqtyBuild;

                

            }                                         
        }        
    }
}
*/

public
void convertDemandTransformDemDetail(DemandH demandH, DemTransformH demTransformH){ 
 try{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

     	SchDemDetailDataBaseContainer   schDemDetailDataBaseContainer = new SchDemDetailDataBaseContainer(dataBaseAccess);
		DemDetailDataBaseContainer      demDetailDataBaseContainer = new DemDetailDataBaseContainer(dataBaseAccess);

        string  spart = "";

        demTransformH.DemTransformDContainer.linkToDemandD(demandH.DemandDContainer);
        
        for (int i=0;  i < demTransformH.DemTransformDContainer.Count; i++){
            DemTransformD   demTransformD = demTransformH.DemTransformDContainer[i];
            DemandD         demandD = demTransformD.DemandD;
            
         
            if (demandD !=null){
                spart= demTransformD.DemandD.Part;   
                
                DemDetailDataBase demDetailDataBase = new DemDetailDataBase(dataBaseAccess);
                                 
                /*order
			    demDetailDataBase.setDEDT_OrdID(sschDataBase.getJYORDR());
			    demDetailDataBase.setDEDT_ItemID(sschDataBase.getJYITEM());
			    demDetailDataBase.setDEDT_RLID(sschDataBase.getJYRELN());
                */
			    demDetailDataBase.setDEDT_BusLoc(demTransformD.DemandD.ShipTo);
			    demDetailDataBase.setDEDT_ProdID(demandD.Part);
			    demDetailDataBase.setDEDT_QtyID(demandD.NetQty);
			    demDetailDataBase.setDEDT_CumID(demandD.QtyCum);
            
                //Date: 05/12/2005 
                //Change by: Claudia Melo
                //Requested by: Mauricio and Chuck.
                //JYDATE includes Lead-Time - JYODAT did't include
                demDetailDataBase.setDEDT_DtShip(demandD.SDate);
			    //demDetailDataBase.setDEDT_DtShip(sschDataBase.getJYODAT()); 

			    demDetailDataBase.setDEDT_InvLoc("");
			    demDetailDataBase.setDEDT_ShipTm(0);
			    
                demDetailDataBaseContainer.Add(demDetailDataBase);
			    schDemDetailDataBaseContainer.Add(new SchDemDetailDataBase(demDetailDataBase));
            }

            demDetailDataBaseContainer.truncate();
		    schDemDetailDataBaseContainer.truncate();
            demDetailDataBaseContainer.write();
		    schDemDetailDataBaseContainer.write();            
        }

    }catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message,exception);
	}            
            
}

/********************************************** DemandWeek *********************************************************************/          
public
DemandWeek createDemandWeek(){
	return new DemandWeek();
}

public
DemandWeekContainer createDemandWeekContainer(){
	return new DemandWeekContainer();
}

public
bool existsDemandWeek(int id){
	try{
		DemandWeekDataBase demandWeekDataBase = new DemandWeekDataBase(dataBaseAccess);

		demandWeekDataBase.setId(id);

		return demandWeekDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
DemandWeek readDemandWeek(int id){
	try{
		DemandWeekDataBase demandWeekDataBase = new DemandWeekDataBase(dataBaseAccess);
		demandWeekDataBase.setId(id);

		if (!demandWeekDataBase.read())
			return null;

		DemandWeek demandWeek = this.objectDataBaseToObject(demandWeekDataBase);

		return demandWeek;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateDemandWeek(DemandWeek demandWeek){
	try{
		 if (!userHandleTransaction)			
			dataBaseAccess.beginTransaction();

        updateDemandWeekInt(demandWeek);
		
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
void updateDemandWeekInt(DemandWeek demandWeek){	
    demandWeek.calcTotWeekReq();
	DemandWeekDataBase demandWeekDataBase = this.objectToObjectDataBase(demandWeek);
	demandWeekDataBase.update();	
}

public 
void writeDemandWeek(DemandWeek demandWeek){
	try{
		if (!userHandleTransaction)			
			dataBaseAccess.beginTransaction();

		writeDemandWeekInt(demandWeek);

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
void writeDemandWeekInt(DemandWeek demandWeek){
    demandWeek.calcTotWeekReq();
	DemandWeekDataBase demandWeekDataBase = this.objectToObjectDataBase(demandWeek);
	demandWeekDataBase.write();

	demandWeek.Id=demandWeekDataBase.getId();        
}

public
void deleteDemandWeek(int id){
	try{
		if (!userHandleTransaction)			
			dataBaseAccess.beginTransaction();

		DemandWeekDataBase demandWeekDataBase = new DemandWeekDataBase(dataBaseAccess);

		demandWeekDataBase.setId(id);
		demandWeekDataBase.delete();

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
DemandWeek objectDataBaseToObject(DemandWeekDataBase demandWeekDataBase){
	DemandWeek demandWeek = new DemandWeek();

	demandWeek.Id=demandWeekDataBase.getId();
	demandWeek.Plant=demandWeekDataBase.getPlant();
	demandWeek.Source=demandWeekDataBase.getSource();
	demandWeek.TPartner=demandWeekDataBase.getTPartner();
	demandWeek.OldRelNum=demandWeekDataBase.getOldRelNum();
	demandWeek.NewRelNum=demandWeekDataBase.getNewRelNum();
    demandWeek.RelDate = demandWeekDataBase.getRelDate();
    demandWeek.ShipLoc=demandWeekDataBase.getShipLoc();
	demandWeek.Part=demandWeekDataBase.getPart();
    demandWeek.FromDate=demandWeekDataBase.getFromDate();
	demandWeek.WeekShip=demandWeekDataBase.getWeekShip();
	demandWeek.PastDue=demandWeekDataBase.getPastDue();
	demandWeek.Monday=demandWeekDataBase.getMonday();
	demandWeek.Tuesday=demandWeekDataBase.getTuesday();
	demandWeek.Wednesday=demandWeekDataBase.getWednesday();
	demandWeek.Thursday=demandWeekDataBase.getThursday();
	demandWeek.Friday=demandWeekDataBase.getFriday();
	demandWeek.Saturday=demandWeekDataBase.getSaturday();
	demandWeek.Sunday=demandWeekDataBase.getSunday();
	demandWeek.TotWeekReq=demandWeekDataBase.getTotWeekReq();

    demandWeek.OrderNum=demandWeekDataBase.getOrderNum();
	demandWeek.Item=demandWeekDataBase.getItem();
	demandWeek.TrlpKeyId=demandWeekDataBase.getTrlpKeyId();

	return demandWeek;
}

private
DemandWeekDataBase objectToObjectDataBase(DemandWeek demandWeek){
	DemandWeekDataBase demandWeekDataBase = new DemandWeekDataBase(dataBaseAccess);
	demandWeekDataBase.setId(demandWeek.Id);
	demandWeekDataBase.setPlant(demandWeek.Plant);
	demandWeekDataBase.setSource(demandWeek.Source);
	demandWeekDataBase.setTPartner(demandWeek.TPartner);
	demandWeekDataBase.setOldRelNum(demandWeek.OldRelNum);
	demandWeekDataBase.setNewRelNum(demandWeek.NewRelNum);
    demandWeekDataBase.setRelDate(demandWeek.RelDate);
	demandWeekDataBase.setShipLoc(demandWeek.ShipLoc);
	demandWeekDataBase.setPart(demandWeek.Part);
    demandWeekDataBase.setFromDate(demandWeek.FromDate);
	demandWeekDataBase.setWeekShip(demandWeek.WeekShip);
	demandWeekDataBase.setPastDue(demandWeek.PastDue);
	demandWeekDataBase.setMonday(demandWeek.Monday);
	demandWeekDataBase.setTuesday(demandWeek.Tuesday);
	demandWeekDataBase.setWednesday(demandWeek.Wednesday);
	demandWeekDataBase.setThursday(demandWeek.Thursday);
	demandWeekDataBase.setFriday(demandWeek.Friday);
	demandWeekDataBase.setSaturday(demandWeek.Saturday);
	demandWeekDataBase.setSunday(demandWeek.Sunday);
	demandWeekDataBase.setTotWeekReq(demandWeek.TotWeekReq);

    demandWeekDataBase.setOrderNum(demandWeek.OrderNum);
	demandWeekDataBase.setItem(demandWeek.Item);
	demandWeekDataBase.setTrlpKeyId(demandWeek.TrlpKeyId);

	return demandWeekDataBase;
}

public
DemandWeek cloneDemandWeek(DemandWeek demandWeek){
	DemandWeek demandWeekClone = new DemandWeek();

	demandWeekClone.Id=demandWeek.Id;
	demandWeekClone.Plant=demandWeek.Plant;
	demandWeekClone.Source=demandWeek.Source;
	demandWeekClone.TPartner=demandWeek.TPartner;
	demandWeekClone.OldRelNum=demandWeek.OldRelNum;
	demandWeekClone.NewRelNum=demandWeek.NewRelNum;
    demandWeekClone.RelDate  = demandWeek.RelDate;
	demandWeekClone.ShipLoc=demandWeek.ShipLoc;
	demandWeekClone.Part=demandWeek.Part;
    demandWeekClone.FromDate=demandWeek.FromDate;
	demandWeekClone.WeekShip=demandWeek.WeekShip;
	demandWeekClone.PastDue=demandWeek.PastDue;
	demandWeekClone.Monday=demandWeek.Monday;
	demandWeekClone.Tuesday=demandWeek.Tuesday;
	demandWeekClone.Wednesday=demandWeek.Wednesday;
	demandWeekClone.Thursday=demandWeek.Thursday;
	demandWeekClone.Friday=demandWeek.Friday;
	demandWeekClone.Saturday=demandWeek.Saturday;
	demandWeekClone.Sunday=demandWeek.Sunday;
	demandWeekClone.TotWeekReq=demandWeek.TotWeekReq;

    demandWeekClone.OrderNum    = demandWeek.OrderNum;
	demandWeekClone.Item        = demandWeek.Item;
	demandWeekClone.TrlpKeyId   = demandWeek.TrlpKeyId;

	return demandWeekClone;
}


public
DemandWeekContainer readDemandWeekByFilters(string splant,string source,string stPartner,string soldRelNum,string snewRelNum,string shipLoc,string spart,DateTime fromDate,int rows){    
    try{        
        DemandWeekContainer             demandWeekContainer = new DemandWeekContainer();
        DemandWeekDataBaseContainer     demandWeekDataBaseContainer = new DemandWeekDataBaseContainer(dataBaseAccess);
        demandWeekDataBaseContainer.readByFilters(splant,source,stPartner,soldRelNum,snewRelNum,shipLoc,spart,fromDate,rows);        

        foreach (DemandWeekDataBase demandWeekDataBase in demandWeekDataBaseContainer)
            demandWeekContainer.Add(objectDataBaseToObject(demandWeekDataBase));

        return demandWeekContainer;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
}
        
public
DemandWeekContainer generateDemandWeek(DemandH demandH){
	try{		
        DateTime            fromDate                = DateTime.Now;        
        DemandWeekContainer demandWeekContainer     = null;        
        DemandD             demandDNew              = null;
        DemandWeekContainer demandWeekContainerRes  = new DemandWeekContainer();
        Hashtable           hashtableNewRels        = new Hashtable();
        
        for (int i=0; i < demandH.DemandDContainer.Count; i++) { 
            demandDNew = demandH.DemandDContainer[i];            
            generateDemandWeek(demandH,demandDNew,demandWeekContainer,hashtableNewRels);         
        }
                   
        return demandWeekContainerRes;
		
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
string getKeyHash(string spant,DemandD demandDNew){
    char   sep  = Constants.DEFAULT_SEP;
    string skey = spant.ToUpper()           + sep + demandDNew.Source.ToUpper()+ sep + demandDNew.TPartner.ToUpper() + sep +
                demandDNew.ShipLoc.ToUpper()+ sep + demandDNew.Part.ToUpper()  + sep + demandDNew.RelNum.ToUpper();
    return skey;
}
        
private
void generateDemandWeek(DemandH demandH,DemandD demandDNew,DemandWeekContainer demandWeekContainer,Hashtable hashtableNewRels){
	
    DateTime            fromDate                = DateTime.Now;        
    DemandWeek          demandWeek              = null;
    DemandWeekContainer demandWeekContainerRes  = new DemandWeekContainer();        
    string              skey                    = "";
    char                sep                     = Constants.DEFAULT_SEP;
    bool                bsave                   = false;    

    if (demandDNew.Source.Equals(DemandD.SOURCE_830) && demandDNew.NetQty != 0) {                 
        fromDate  = DateUtil.getPriorMondayFromDate(demandDNew.SDate);                    

        skey =  demandH.Plant.ToUpper()     + sep + demandDNew.Source.ToUpper()+ sep + demandDNew.TPartner.ToUpper() + sep +
                demandDNew.ShipLoc.ToUpper()+ sep + demandDNew.Part.ToUpper()  + sep + demandDNew.RelNum.ToUpper();

        demandWeekContainer = readDemandWeekByFilters(demandH.Plant,demandDNew.Source,demandDNew.TPartner,"","",demandDNew.ShipLoc,demandDNew.Part,fromDate,0);                        
        if (demandWeekContainer.Count > 0) { 
            demandWeek = demandWeekContainer[0];
            if (demandWeek.NewRelNum.ToUpper().Equals(demandDNew.RelNum.ToUpper())) { //check if same release
                if (hashtableNewRels.Contains(skey)) { //is new release, so summarize
                    bsave=true;
                    demandWeek.setSummarizeQtyByDate(demandDNew.SDate,demandDNew.NetQty);
                }
                        
            }else{                    
                if (!hashtableNewRels.Contains(skey))
                    hashtableNewRels.Add(skey,skey);
                bsave=true;                
                demandWeek.OldRelNum = demandWeek.NewRelNum;
                demandWeek.NewRelNum = demandDNew.RelNum;                        
                demandWeek.setQtyByDate(demandDNew.SDate,demandDNew.NetQty);                       
            }                                   
        }else {
            bsave=true;
            demandWeek = new DemandWeek();                    
            demandWeek.Plant    = demandH.Plant;
            demandWeek.Source   = demandDNew.Source;                
            demandWeek.NewRelNum= demandDNew.RelNum;
            demandWeek.TPartner = demandDNew.TPartner;
            demandWeek.ShipLoc  = demandDNew.ShipLoc;
            demandWeek.Part     = demandDNew.Part;
            demandWeek.FromDate = fromDate;         
            demandWeek.setQtyByDate(demandDNew.SDate,demandDNew.NetQty);         
                            
            if (!hashtableNewRels.Contains(skey))
                hashtableNewRels.Add(skey,skey);                                                              
        }
                
        if (bsave) { 
            if (demandWeek.Id > 0)
                updateDemandWeek(demandWeek);
            else
                writeDemandWeek(demandWeek);
        }else
            bsave=false;

        demandWeekContainerRes.Add(demandWeek);
    }
                                   			
}

public
void processDemandDCompareViewNetQtyDifferences(bool bcumulative,DateTime runDate,DemandDCompareViewContainer demandDCompareViewContainer){
    try { 
        DemandDCompareView  demandDCompareViewPrior     = null;
        DemandDCompareView  demandDCompareViewPriorAux  = null;
        decimal             dqtyDifferences             = 0;
        decimal             dqty                        = 0;
        decimal             dqtyPrior                   = 0;
        DateTime            dateFilter                  = DateTime.Now;

        for (int i=demandDCompareViewContainer.Count - 1; i >= 0; i--){
            DemandDCompareView          demandDCompareView = demandDCompareViewContainer[i];

            demandDCompareViewPriorAux  = new DemandDCompareView();
            demandDCompareViewPriorAux.copy(demandDCompareView);    //copy hotlist info qty

            if (demandDCompareViewPrior!= null) {                 
                for (int j=-1; j < Constants.MAX_HOTLIST_DAYS;j++){ //-1 becase process pastdue too
                    dateFilter = runDate.AddDays(j);
                    
                    dqty        = bcumulative ? demandDCompareViewPriorAux.getQtyByDateBackUntilFoundQty(runDate,dateFilter) :
                                                demandDCompareViewPriorAux.getQtyByDate(runDate,dateFilter);
                    dqtyPrior   = bcumulative ? demandDCompareViewPrior.getQtyByDateBackUntilFoundQty(runDate,dateFilter) : 
                                                demandDCompareViewPrior.getQtyByDate(runDate,dateFilter);                    
                    
                    dqtyDifferences = dqty - dqtyPrior;
                    demandDCompareView.setQtyByDate(runDate,dateFilter,dqtyDifferences);
                }
            }
            demandDCompareViewPrior = demandDCompareViewPriorAux;
        }    

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

/******************************************************* DemandDay ***********************************************************************/
public
DemandDay createDemandDay(){
	return new DemandDay();
}

public
DemandDayContainer createDemandDayContainer(){
	return new DemandDayContainer();
}

public
bool existsDemandDay(int id){
	try{
		DemandDayDataBase demandDayDataBase = new DemandDayDataBase(dataBaseAccess);

		demandDayDataBase.setId(id);

		return demandDayDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
DemandDay readDemandDay(int id){
	try{
		DemandDayDataBase demandDayDataBase = new DemandDayDataBase(dataBaseAccess);
		demandDayDataBase.setId(id);

		if (!demandDayDataBase.read())
			return null;

		DemandDay demandDay = this.objectDataBaseToObject(demandDayDataBase);

		return demandDay;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateDemandDayInt(DemandDay demandDay){
	DemandDayDataBase demandDayDataBase = this.objectToObjectDataBase(demandDay);
	demandDayDataBase.update();
}

public 
void updateDemandDay(DemandDay demandDay){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        updateDemandDayInt(demandDay);
		
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
void writeDemandDayInt(DemandDay demandDay){
	DemandDayDataBase demandDayDataBase = this.objectToObjectDataBase(demandDay);
	demandDayDataBase.write();

	demandDay.Id=demandDayDataBase.getId();
}

public 
void writeDemandDay(DemandDay demandDay){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
        writeDemandDayInt(demandDay);

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
void deleteDemandDay(int id){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		DemandDayDataBase demandDayDataBase = new DemandDayDataBase(dataBaseAccess);

		demandDayDataBase.setId(id);
		demandDayDataBase.delete();

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
DemandDay objectDataBaseToObject(DemandDayDataBase demandDayDataBase){
	DemandDay demandDay = new DemandDay();

	demandDay.Id=demandDayDataBase.getId();
	demandDay.Plant=demandDayDataBase.getPlant();
	demandDay.Source=demandDayDataBase.getSource();
	demandDay.TPartner=demandDayDataBase.getTPartner();
	demandDay.ShipLoc=demandDayDataBase.getShipLoc();
	demandDay.Part=demandDayDataBase.getPart();
	demandDay.Created=demandDayDataBase.getCreated();
	demandDay.OldRelNum=demandDayDataBase.getOldRelNum();
	demandDay.NewRelNum=demandDayDataBase.getNewRelNum();
	demandDay.OldRelDate=demandDayDataBase.getOldRelDate();
	demandDay.RelDate=demandDayDataBase.getRelDate();
	demandDay.OldCumRequired=demandDayDataBase.getOldCumRequired();
	demandDay.CumRequired=demandDayDataBase.getCumRequired();
	demandDay.OrderNum=demandDayDataBase.getOrderNum();
	demandDay.Item=demandDayDataBase.getItem();
	demandDay.TrlpKeyId=demandDayDataBase.getTrlpKeyId();
    demandDay.LogNum = demandDayDataBase.getLogNum();


    return demandDay;
}

private
DemandDayDataBase objectToObjectDataBase(DemandDay demandDay){
	DemandDayDataBase demandDayDataBase = new DemandDayDataBase(dataBaseAccess);
	demandDayDataBase.setId(demandDay.Id);
	demandDayDataBase.setPlant(demandDay.Plant);
	demandDayDataBase.setSource(demandDay.Source);
	demandDayDataBase.setTPartner(demandDay.TPartner);
	demandDayDataBase.setShipLoc(demandDay.ShipLoc);
	demandDayDataBase.setPart(demandDay.Part);
	demandDayDataBase.setCreated(demandDay.Created);
	demandDayDataBase.setOldRelNum(demandDay.OldRelNum);
	demandDayDataBase.setNewRelNum(demandDay.NewRelNum);
	demandDayDataBase.setOldRelDate(demandDay.OldRelDate);
	demandDayDataBase.setRelDate(demandDay.RelDate);
	demandDayDataBase.setOldCumRequired(demandDay.OldCumRequired);
	demandDayDataBase.setCumRequired(demandDay.CumRequired);
	demandDayDataBase.setOrderNum(demandDay.OrderNum);
	demandDayDataBase.setItem(demandDay.Item);
	demandDayDataBase.setTrlpKeyId(demandDay.TrlpKeyId);
    demandDayDataBase.setLogNum(demandDay.LogNum);

	return demandDayDataBase;
}

public
DemandDay cloneDemandDay(DemandDay demandDay){
	DemandDay demandDayClone = new DemandDay();

	demandDayClone.Id=demandDay.Id;
	demandDayClone.Plant=demandDay.Plant;
	demandDayClone.Source=demandDay.Source;
	demandDayClone.TPartner=demandDay.TPartner;
	demandDayClone.ShipLoc=demandDay.ShipLoc;
	demandDayClone.Part=demandDay.Part;
	demandDayClone.Created=demandDay.Created;
	demandDayClone.OldRelNum=demandDay.OldRelNum;
	demandDayClone.NewRelNum=demandDay.NewRelNum;
	demandDayClone.OldRelDate=demandDay.OldRelDate;
	demandDayClone.RelDate=demandDay.RelDate;
	demandDayClone.OldCumRequired=demandDay.OldCumRequired;
	demandDayClone.CumRequired=demandDay.CumRequired;
	demandDayClone.OrderNum=demandDay.OrderNum;
	demandDayClone.Item=demandDay.Item;
	demandDayClone.TrlpKeyId=demandDay.TrlpKeyId;
    demandDayClone.LogNum = demandDay.LogNum;

	return demandDayClone;
}

public
DemandDayContainer readDemandDayByFilters(string splant,string source,string stPartner, string shipLoc,string spart,string soldRelNum, string snewRelNum,decimal logNum,DateTime fromDate,DateTime toDate,bool bdescOrder,int rows){
	try{
        DemandDayContainer          demandDayContainer          = new DemandDayContainer();
		DemandDayDataBaseContainer  demandDayDataBaseContainer  = new DemandDayDataBaseContainer(dataBaseAccess);		
        demandDayDataBaseContainer.readByFilters(splant,source,stPartner, shipLoc,spart,soldRelNum,snewRelNum,logNum,fromDate,toDate,bdescOrder,rows);

        foreach(DemandDayDataBase demandDayDataBase in demandDayDataBaseContainer) { 
		    DemandDay demandDay = this.objectDataBaseToObject(demandDayDataBase);
            demandDayContainer.Add(demandDay);
        }

		return demandDayContainer;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
DemandDCompareViewContainer getLocalDemandDCompareAllViewReportByFilters(
    string splant,string source,string stPartner,string shipLoc, string spart,string snewRelNum,DateTime runDate,DateTime fromDate,DateTime toDate,int irows){
    try { 
        DemandDCompareViewContainer demandDCompareViewContainer = new DemandDCompareViewContainer();
        DemandDCompareView          demandDCompareView          = null;
        DemandDCompareView          demandDCompareViewPrior     = null;
        bool                        bcumulative                 = true;                        
        string                      skey                        = "";

        DemandDCompareViewDataBaseContainer demandDCompareViewDataBaseContainer = new DemandDCompareViewDataBaseContainer(dataBaseAccess);
        demandDCompareViewDataBaseContainer.readDemandDayAllChangesByFilters(splant, source, stPartner, shipLoc, spart,snewRelNum,fromDate, toDate, irows);

        foreach (DemandDCompareViewDataBase demandDCompareViewDataBase in demandDCompareViewDataBaseContainer){
            demandDCompareView = objectDataBaseToObject(demandDCompareViewDataBase);
            
            skey    = getKeyHash(splant,demandDCompareView);                   
            
            loadDemandDCompareViewContainer(demandDCompareViewContainer,demandDCompareView,runDate,bcumulative,ref demandDCompareViewPrior);                    
        }

        return demandDCompareViewContainer;

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}
   
public
DemandDCompareViewContainer getLocalDemandDCompareAllViewReportByFilters2(
    string splant,string source,string stPartner,string shipLoc, string spart,string snewRelNum,DateTime runDate,DateTime fromDate,DateTime toDate,
    bool bshowDifferences,bool bqtyDifferences,bool bcumulative,bool bcolumnsWQty, int irows){
    try { 
        DemandDCompareViewContainer demandDCompareViewContainer = new DemandDCompareViewContainer();
        DemandDCompareView          demandDCompareView          = null;
        DemandDCompareView          demandDCompareViewPrior     = null;
        DemandDay                   demandDay                   = null;
        DemandDay                   demandDayOld                = null;        
        string                      skey                        = "";
        decimal                     dqty=0,dqtyPrior=0;
        ArrayList                   arrayDiffernces             = new ArrayList();

        DemandDayDataBaseContainer demandDayDataBaseContainer = new DemandDayDataBaseContainer(dataBaseAccess);
        demandDayDataBaseContainer.readByFilters2(splant, source, stPartner, shipLoc, spart,snewRelNum,fromDate, toDate, irows);

        foreach (DemandDayDataBase demandDayDataBase in demandDayDataBaseContainer){

            demandDay = objectDataBaseToObject(demandDayDataBase);

            demandDCompareViewPrior = demandDCompareViewContainer.getFirstByFilters(demandDay.Source,demandDay.TPartner,demandDay.ShipLoc,demandDay.NewRelNum,demandDay.Part);
            if (demandDCompareViewPrior == null){
                demandDCompareViewPrior = new DemandDCompareView();
                demandDCompareViewPrior.copy(demandDay);
                demandDCompareViewContainer.Add(demandDCompareViewPrior);
            }            
            demandDCompareViewPrior.setQtyByDate(runDate,demandDay.RelDate, demandDay.CumRequired);
                                                //bqtyDifferences ? demandDay.CumRequired - demandDay.OldCumRequired : demandDay.CumRequired);
                        
            //old rel                
            demandDCompareViewPrior = demandDCompareViewContainer.getFirstByFilters(demandDay.Source,demandDay.TPartner,demandDay.ShipLoc,demandDay.OldRelNum,demandDay.Part);
            if (demandDCompareViewPrior == null){
                demandDCompareViewPrior = new DemandDCompareView();
                demandDCompareViewPrior.copy(demandDay);
                demandDCompareViewPrior.RelNum  = demandDay.OldRelNum;
                demandDCompareViewPrior.SDate   = demandDay.RelDate;
                demandDCompareViewPrior.NetQty  = demandDay.OldCumRequired;
                demandDCompareViewContainer.Add(demandDCompareViewPrior);
            }
            demandDCompareViewPrior.setQtyByDate(runDate,demandDay.RelDate,demandDay.OldCumRequired);    
                    /*
            if (bqtyDifferences){                
                demandDayOld=null;
                DemandDayContainer demandDayContainerOld = readDemandDayByFilters(demandDay.Plant, demandDay.Source,demandDay.TPartner, demandDay.ShipLoc, demandDay.Part,"", demandDay.OldRelNum,0,DateUtil.MinValue,demandDay.OldRelDate,true,1);
                if (demandDayContainerOld.Count > 0)
                    demandDayOld = demandDayContainerOld[0];                
                if (demandDayOld!= null)
                    demandDCompareViewPrior.setQtyByDate(runDate,demandDay.OldRelDate, demandDayOld.CumRequired - demandDayOld.OldCumRequired);                   
                else
                    demandDCompareViewPrior.setQtyByDate(runDate,demandDay.OldRelDate,0);
            }*/
        }

        if (bshowDifferences) { 
            bool bdifference=false;
            bool bpartFind  = false;
            for (int i=0; i < demandDCompareViewContainer.Count;i=i+2){
                demandDCompareViewPrior = demandDCompareViewContainer[i];

                bdifference=false;
                bpartFind  =false;

                int j=i+1;
                if (j < demandDCompareViewContainer.Count){
                    demandDCompareView  = demandDCompareViewContainer[j];
                    bpartFind           = demandDCompareView.Part.ToUpper().Equals(demandDCompareViewPrior.Part.ToUpper());

                    for (int h=0; bpartFind && h < Constants.MAX_HOTLIST_DAYS;h++){
                        dqtyPrior   = demandDCompareViewPrior.getQtyByDate(runDate,runDate.AddDays(h));             
                        dqty        = demandDCompareView.getQtyByDate(runDate,runDate.AddDays(h)); 
                                                                       
                        if (dqtyPrior != dqty){
                            bdifference=true;
                            demandDCompareViewPrior.setBoolByDate(runDate, runDate.AddDays(h),true);
                            demandDCompareView.setBoolByDate(runDate, runDate.AddDays(h),true);

                            demandDCompareViewPrior.setStringByDate(runDate, runDate.AddDays(h),"Red");
                            demandDCompareView.setStringByDate(runDate, runDate.AddDays(h),"Red");
                            if (dqtyPrior < dqty) { 
                                demandDCompareViewPrior.setStringByDate(runDate, runDate.AddDays(h),"Blue");
                                demandDCompareView.setStringByDate(runDate, runDate.AddDays(h), "Blue");
                            }
                        }
                    }                               

                    if (bdifference){
                        arrayDiffernces.Add(demandDCompareViewPrior);//store only records which differences
                        arrayDiffernces.Add(demandDCompareView);                        
                    }
                }              
            }
            //load differences
            demandDCompareViewContainer.Clear();
            for (int i=0; i < arrayDiffernces.Count;i++){
                demandDCompareView  = (DemandDCompareView)arrayDiffernces[i];
                demandDCompareViewContainer.Add(demandDCompareView);
            }          
        }

        if (bcumulative) { 
            if (!bcolumnsWQty)
                calculateFullSummary(demandDCompareViewContainer, runDate);
        }else{
            calculateNetsQty(demandDCompareViewContainer, runDate);
            paintCompareView(demandDCompareViewContainer,runDate);
        }

        if (bqtyDifferences)
            showDifferencesCompareView(demandDCompareViewContainer,runDate);
        return demandDCompareViewContainer;

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
DemandDCompareReportViewContainer getLocalDemandDCompareAllViewReportByFilters3(
    string splant,string source,string stPartner,string shipLoc, string spart,string snewRelNum,DateTime runDate,DateTime fromDate,DateTime toDate,
    bool bshowDifferences,bool bqtyDifferences,bool bcumulative,bool bcolumnsWQty, int irows){
    try { 
        DemandDCompareReportViewContainer   demandDCompareReportViewContainer   = new DemandDCompareReportViewContainer();
        DemandDCompareReportViewContainer   demandDCompareReportViewContainerNew= new DemandDCompareReportViewContainer();
        DemandDay                           demandDay                           = null;
        ArrayList                           arrayDiffernces                     = new ArrayList();
        DemandDCompareReportView            demandDCompareReportView            = null;
        DemandDCompareReportView            demandDCompareReportViewNew         = null;
        CellDemandDCompareReport            cellDemandDCompareReport            = null;

        DemandDayDataBaseContainer          demandDayDataBaseContainer = new DemandDayDataBaseContainer(dataBaseAccess);
        demandDayDataBaseContainer.readByFilters2(splant, source, stPartner, shipLoc, spart,snewRelNum,fromDate, toDate, irows);

        foreach (DemandDayDataBase demandDayDataBase in demandDayDataBaseContainer){

            demandDay = objectDataBaseToObject(demandDayDataBase);
            
            demandDCompareReportView = (DemandDCompareReportView)demandDCompareReportViewContainer.getFirstByFilters(demandDay.Source,demandDay.TPartner,demandDay.ShipLoc,demandDay.NewRelNum,demandDay.Part);
            if (demandDCompareReportView == null){
                demandDCompareReportView = new DemandDCompareReportView(runDate);
                demandDCompareReportView.copy(demandDay);
                demandDCompareReportViewContainer.Add(demandDCompareReportView);

                demandDCompareReportView.CellTitles.Title1 = demandDCompareReportView.RelNum;
                demandDCompareReportView.CellTitles.Title2 = demandDCompareReportView.RelNum2;                
            }            

            cellDemandDCompareReport = demandDCompareReportView.getCellByDate(demandDay.RelDate);   
            if (cellDemandDCompareReport!= null){
                cellDemandDCompareReport.QtyNew = demandDay.CumRequired;
                cellDemandDCompareReport.QtyOld = demandDay.OldCumRequired;            

                if (bshowDifferences && cellDemandDCompareReport.QtyNew != cellDemandDCompareReport.QtyOld){
                    demandDCompareReportViewNew = (DemandDCompareReportView)demandDCompareReportViewContainerNew.getFirstByFilters(demandDay.Source,demandDay.TPartner,demandDay.ShipLoc,demandDay.NewRelNum,demandDay.Part);
                    if (demandDCompareReportViewNew==null)
                        demandDCompareReportViewContainerNew.Add(demandDCompareReportView);
                }

                if (cellDemandDCompareReport.QtyNew > cellDemandDCompareReport.QtyOld)
                    cellDemandDCompareReport.Color = "Red";
                if (cellDemandDCompareReport.QtyNew < cellDemandDCompareReport.QtyOld)
                    cellDemandDCompareReport.Color = "Blue";                                
            }                             
        }        

        /*        
        if (bcumulative) { 
            if (!bcolumnsWQty)
                calculateFullSummary(demandDCompareViewContainer, runDate);
        }else{
            calculateNetsQty(demandDCompareViewContainer, runDate);
            paintCompareView(demandDCompareViewContainer,runDate);
        }

        if (bqtyDifferences)
            showDifferencesCompareView(demandDCompareViewContainer,runDate);
    */
        if (bshowDifferences)
            demandDCompareReportViewContainer= demandDCompareReportViewContainerNew;

        if (bcumulative)
            bcumulative= bcumulative;
        else
            calculateNetsQty(demandDCompareReportViewContainer,runDate,fromDate,toDate);                    

        return demandDCompareReportViewContainer;

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

private
void paintCompareView(DemandDCompareViewContainer demandDCompareViewContainer,DateTime runDate){    
    DemandDCompareView          demandDCompareView          = null;
    DemandDCompareView          demandDCompareViewPrior     = null;
    DemandDay                   demandDay                   = null;
    DemandDay                   demandDayOld                = null;        
    string                      skey                        = "";
    decimal                     dqty=0,dqtyPrior=0;
    bool                        bdifference=false;
    bool                        bpartFind  = false;
    ArrayList                   arrayDiffernces             = new ArrayList();

    for (int i=0; i < demandDCompareViewContainer.Count;i=i+2){
        demandDCompareViewPrior = demandDCompareViewContainer[i];

        bdifference=false;
        bpartFind  =false;

        int j=i+1;
        if (j < demandDCompareViewContainer.Count){
            demandDCompareView  = demandDCompareViewContainer[j];
            bpartFind           = demandDCompareView.Part.ToUpper().Equals(demandDCompareViewPrior.Part.ToUpper());

            for (int h=0; bpartFind && h < Constants.MAX_HOTLIST_DAYS;h++){
                dqtyPrior   = demandDCompareViewPrior.getQtyByDate(runDate,runDate.AddDays(h));             
                dqty        = demandDCompareView.getQtyByDate(runDate,runDate.AddDays(h)); 
                                                                       
                if (dqtyPrior != dqty){
                    bdifference=true;
                    demandDCompareViewPrior.setBoolByDate(runDate, runDate.AddDays(h),true);
                    demandDCompareView.setBoolByDate(runDate, runDate.AddDays(h),true);

                    demandDCompareViewPrior.setStringByDate(runDate, runDate.AddDays(h),"Red");
                    demandDCompareView.setStringByDate(runDate, runDate.AddDays(h),"Red");
                    if (dqtyPrior < dqty) { 
                        demandDCompareViewPrior.setStringByDate(runDate, runDate.AddDays(h),"Blue");
                        demandDCompareView.setStringByDate(runDate, runDate.AddDays(h), "Blue");
                    }
                }
            }                               

            if (bdifference){
                arrayDiffernces.Add(demandDCompareViewPrior);//store only records which differences
                arrayDiffernces.Add(demandDCompareView);                        
            }
        }      
    }                
}   

private
void showDifferencesCompareView(DemandDCompareViewContainer demandDCompareViewContainer,DateTime runDate){    
    DemandDCompareView          demandDCompareView          = null;
    DemandDCompareView          demandDCompareViewPrior     = null;
    DemandDay                   demandDay                   = null;
    DemandDay                   demandDayOld                = null;        
    string                      skey                        = "";
    decimal                     dqty=0,dqtyPrior=0;
    bool                        bdifference=false;
    bool                        bpartFind  = false;
    ArrayList                   arrayDiffernces             = new ArrayList();

    for (int i=0; i < demandDCompareViewContainer.Count;i=i+2){
        demandDCompareViewPrior = demandDCompareViewContainer[i];

        bdifference=false;
        bpartFind  =false;

        int j=i+1;
        if (j < demandDCompareViewContainer.Count){
            demandDCompareView  = demandDCompareViewContainer[j];
            bpartFind           = demandDCompareView.Part.ToUpper().Equals(demandDCompareViewPrior.Part.ToUpper());

            for (int h=0; bpartFind && h < Constants.MAX_HOTLIST_DAYS;h++){
                dqtyPrior   = demandDCompareViewPrior.getQtyByDate(runDate,runDate.AddDays(h));             
                dqty        = demandDCompareView.getQtyByDate(runDate,runDate.AddDays(h));
                if (dqty != dqtyPrior)
                    dqtyPrior= dqtyPrior;

                demandDCompareViewPrior.setQtyByDate(runDate, runDate.AddDays(h), dqtyPrior - dqty);
            }                               
        }      
    }                
}   
   
private
void calculateNetsQty(DemandDCompareViewContainer demandDCompareViewContainer,DateTime runDate){
    DemandDCompareView  demandDCompareView  = null;
    decimal             dqty                = 0;
    decimal             dpriorQty           = 0;    
    bool                bisPastDue          = false;
    DateTime            currDate            = DateTime.Now;
    Hashtable           hash                = new Hashtable();
    
    for (int k=0; k < demandDCompareViewContainer.Count; k++) {
        demandDCompareView = demandDCompareViewContainer[k];

        bisPastDue = false;
        for (int i= Constants.MAX_HOTLIST_DAYS; i >= -1;i--){ //-1 Pastdue                     
            bisPastDue = i < 0;                          
            currDate  = runDate.AddDays(i);
            if (bisPastDue && demandDCompareView.PastDueDateSet != DateUtil.MinValue)
                currDate = demandDCompareView.PastDueDateSet;

            dqty = demandDCompareView.getQtyByDate(runDate,currDate);            
            if (bisPastDue && dqty !=0)
                i=i;

            if (dqty !=  0){
                dpriorQty = findPriorQty(demandDCompareView,runDate,currDate,bisPastDue, hash);
                demandDCompareView.setQtyByDate(runDate,currDate,dqty-dpriorQty);
            }        
        }           
    }
}

private
string getKeyHash(DemandDCompareView demandDCompareView,string srel,DateTime toDate){
    char   sep  = Constants.DEFAULT_SEP;
    string skey = demandDCompareView.Plant.ToUpper()+ sep + demandDCompareView.Source.ToUpper() + sep + demandDCompareView.TPartner.ToUpper()   + sep +
                demandDCompareView.ShipLoc.ToUpper()+ sep + demandDCompareView.Part.ToUpper()   + sep + srel.ToUpper()                          + sep +
                DateUtil.getDateRepresentation(toDate,DateUtil.MMDDYYYY);
    return skey;
}

private
bool getFromHash(DemandDCompareView demandDCompareView,string srel,DateTime toDate,Hashtable hash,out DemandDay demandDay){ 
    demandDay   = null;
    string      skey        = getKeyHash(demandDCompareView,srel, toDate);
    bool        bresult     = false;

    if (hash.Contains(skey)){
        demandDay = (DemandDay)hash[skey];
        bresult=true;
    }
    return bresult;
}

private
void addToHash(DemandDCompareView demandDCompareView,string srel,DateTime toDate,Hashtable hash,DemandDay   demandDay){     
    string      skey        = getKeyHash(demandDCompareView,srel, toDate);

    if (!hash.Contains(skey))
        hash.Add(skey,demandDay);    
}
    
private
decimal findPriorQty(DemandDCompareView demandDCompareView,DateTime runDate,DateTime currDate,bool bisPastDue,Hashtable hash){
    decimal             dpriorQty   =0;
    DateTime            fromDate    = DateTime.Now;
    DateTime            toDate      = DateTime.Now;
    DemandDayContainer  demandDayContainer  = new DemandDayContainer();
    DemandDay           demandDay   = null;
    
    //check if we can find qty on container                
    dpriorQty = bisPastDue ? 0 : demandDCompareView.getQtyByDateBackUntilFoundQty(runDate,currDate.AddDays(-1));
    if (dpriorQty == 0){
        //qty not found yet, so we try to get from table using current release                     
        fromDate= bisPastDue ? demandDCompareView.PastDueDateSet.AddYears(-1) : currDate.AddYears(-1); 
        toDate  = bisPastDue ? demandDCompareView.PastDueDateSet.AddDays(-1)  : currDate.AddDays(-1); 
        fromDate= DateUtil.MinValue; //for now from date will be empty, so we get first record closer to toDate
        
        if (!getFromHash(demandDCompareView, demandDCompareView.RelNum, toDate, hash,out demandDay)){
            demandDayContainer = readDemandDayByFilters(demandDCompareView.Plant, demandDCompareView.Source, demandDCompareView.TPartner, demandDCompareView.ShipLoc, demandDCompareView.Part,"", demandDCompareView.RelNum,0, fromDate, toDate, true,1);
            if (demandDayContainer.Count > 0)
                demandDay = demandDayContainer[0];                                                                                 
            addToHash(demandDCompareView, demandDCompareView.RelNum, toDate, hash,demandDay);  
        }    
        
        if (demandDay == null && !string.IsNullOrEmpty(demandDCompareView.RelNum2)){//qty not found yet, so we try to get from old release                 
            if (!getFromHash(demandDCompareView, demandDCompareView.RelNum2, toDate, hash,out demandDay)){
                demandDayContainer = readDemandDayByFilters(demandDCompareView.Plant, demandDCompareView.Source, demandDCompareView.TPartner, demandDCompareView.ShipLoc, demandDCompareView.Part,"", demandDCompareView.RelNum2,0, fromDate, toDate, true,1);    
                if (demandDayContainer.Count > 0)
                    demandDay = demandDayContainer[0];                                   
                addToHash(demandDCompareView, demandDCompareView.RelNum2,toDate,hash,demandDay);
            }
        }                 
    
        if (demandDay == null && !getFromHash(demandDCompareView, "", toDate, hash, out demandDay)){//if qty not found yet,try to get qty for any date minor                        
            demandDayContainer = readDemandDayByFilters(demandDCompareView.Plant, demandDCompareView.Source, demandDCompareView.TPartner, demandDCompareView.ShipLoc, demandDCompareView.Part,"","",0,DateUtil.MinValue,toDate,true,1);    
            if (demandDayContainer.Count > 0)
                demandDay = demandDayContainer[0];                            
            addToHash(demandDCompareView,"",toDate, hash,demandDay);
        }

        if (demandDay!= null)
            dpriorQty = demandDay.CumRequired;               
    }
    return dpriorQty;
}

private
void calculateFullSummary(DemandDCompareViewContainer demandDCompareViewContainer,DateTime runDate){
    DemandDCompareView  demandDCompareView  = null;
    decimal             dqty                = 0;
    decimal             dpriorQty           = 0;
    DemandDayContainer  demandDayContainer  = new DemandDayContainer();
    bool                bisPastDue          = false;
    DateTime            currDate            = DateTime.Now;
    DateTime            fromDate            = DateTime.Now;
    DateTime            toDate              = DateTime.Now;
    Hashtable           hash                = new Hashtable();

    for (int k=0; k < demandDCompareViewContainer.Count; k++) {
        demandDCompareView = demandDCompareViewContainer[k];

        bisPastDue = false;
        for (int i= Constants.MAX_HOTLIST_DAYS; i >= -1;i--){ //-1 Pastdue                     
            bisPastDue = i < 0;                          
            currDate  = runDate.AddDays(i);
            if (bisPastDue && demandDCompareView.PastDueDateSet != DateUtil.MinValue)
                currDate = demandDCompareView.PastDueDateSet;

            dqty = demandDCompareView.getQtyByDate(runDate,currDate);
            bisPastDue = i < 0;
            
            if (dqty ==  0){
                dpriorQty = findPriorQty(demandDCompareView,runDate,currDate,bisPastDue,hash);              
                demandDCompareView.setQtyByDate(runDate,currDate,dpriorQty);
            }        
        }           
    }
}

private
void calculateNetsQty(DemandDCompareReportViewContainer demandDCompareReportViewContainer, DateTime runDate, DateTime fromDate, DateTime toDate){
    int                         i=0;
    int                         j=0;
    DemandDCompareReportView    demandDCompareReportView= null;
    CellDemandDCompareReport    cellDemandDCompareReport= null;
    Hashtable                   hash = new Hashtable();
    DemandDayContainer          demandDayContainer= null;
    DemandDay                   demandDay= null;
    DemandDayDataBaseContainer  demandDayDataBaseContainer = new DemandDayDataBaseContainer(dataBaseAccess);
    DateTime                    toDateAux   = DateUtil.MinValue;

    for (i=0; i < demandDCompareReportViewContainer.Count;i++){        
        demandDCompareReportView= (DemandDCompareReportView)demandDCompareReportViewContainer[i];
        
        toDateAux = DateUtil.highHour(fromDate.AddDays(-1));
        //new                   
        demandDay = null;
        demandDayContainer = readDemandDayByFilters(demandDCompareReportView.Plant, demandDCompareReportView.Source, demandDCompareReportView.TPartner, demandDCompareReportView.ShipLoc, demandDCompareReportView.Part,"","",0,DateUtil.MinValue,
                                                    toDateAux, true,1);    
        if (demandDayContainer.Count > 0)
            demandDay = demandDayContainer[0];                            
        demandDCompareReportView.convertToNetQty(demandDay,true);

        //old qty
        demandDay = null;
        demandDayDataBaseContainer.Clear();
        demandDayDataBaseContainer.readByFiltersLogMinor(demandDCompareReportView.Plant, demandDCompareReportView.Source, demandDCompareReportView.TPartner, demandDCompareReportView.ShipLoc, demandDCompareReportView.Part,"","",demandDCompareReportView.LogNum, DateUtil.MinValue,
                                                         toDateAux, true,1);    
        if (demandDayDataBaseContainer.Count > 0)
            demandDay = objectDataBaseToObject((DemandDayDataBase)demandDayDataBaseContainer[0]);       
        demandDCompareReportView.convertToNetQty(demandDay,false);
    }  

}

} // class
} // package
            