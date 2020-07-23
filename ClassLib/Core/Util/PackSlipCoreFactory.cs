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
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Sales.PackSlips;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Sales.PackSlips;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms.PackSlip;

namespace Nujit.NujitERP.ClassLib.Core.Util{

public
class PackSlipCoreFactory : MachineCoreFactory {

public
PackSlipCoreFactory(): base(){
}

public
PackSlip createPackSlip(){
	return new PackSlip();
}

public
PackSlipContainer createPackSlipContainer(){
	return new PackSlipContainer();
}

public
bool existsPackSlip(int id){
	try{
		OePSHdrDataBase oePSHdrDataBase = new OePSHdrDataBase(dataBaseAccess);

		oePSHdrDataBase.setId(id);

		return oePSHdrDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
PackSlip readPackSlip(int id){
	try{
		OePSHdrDataBase oePSHdrDataBase = new OePSHdrDataBase(dataBaseAccess);
		oePSHdrDataBase.setId(id);

		if (!oePSHdrDataBase.read())
			return null;

		PackSlip packSlip = this.objectDataBaseToObject(oePSHdrDataBase);
        loadPackSlipChilds(packSlip);

		return packSlip;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

private
void loadPackSlipChilds(PackSlip packSlip){    
    OePsDtlDataBaseContainer oePsDtlDataBaseContainer = new OePsDtlDataBaseContainer(dataBaseAccess);
	oePsDtlDataBaseContainer.readByHdr(packSlip.Id);

    foreach(OePsDtlDataBase oePsDtlDataBase in oePsDtlDataBaseContainer){
        packSlip.PackSlipDtlContainer.Add(objectDataBaseToObject(oePsDtlDataBase));
    }

}

private
void writePackSlipChilds(PackSlip packSlip){
    packSlip.fillRedundances();

    foreach(PackSlipDtl packSlipDtl in packSlip.PackSlipDtlContainer){
       OePsDtlDataBase oePsDtlDataBase = objectToObjectDataBase(packSlipDtl);
        oePsDtlDataBase.write();
    }
}

private
void deletePackSlipChilds(int id){
    OePsDtlDataBaseContainer oePsDtlDataBaseContainer = new OePsDtlDataBaseContainer(dataBaseAccess);
    oePsDtlDataBaseContainer.deleteByHdr(id);    
}

internal 
void updatePackSlipInt(PackSlip packSlip){
    OePSHdrDataBase oePSHdrDataBase = this.objectToObjectDataBase(packSlip);
	oePSHdrDataBase.update();

    deletePackSlipChilds(packSlip.Id);
    writePackSlipChilds(packSlip);
}

internal 
void writePackSlipInt(PackSlip packSlip){
    OePSHdrDataBase oePSHdrDataBase = this.objectToObjectDataBase(packSlip);
	oePSHdrDataBase.write();

	packSlip.Id=oePSHdrDataBase.getId();
    writePackSlipChilds(packSlip);
}

public 
void updatePackSlip(PackSlip packSlip){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		updatePackSlipInt(packSlip);

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
void writePackSlip(PackSlip packSlip){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        writePackSlipInt(packSlip);

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
void deletePackSlip(int id){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        deletePackSlipChilds(id);
		OePSHdrDataBase oePSHdrDataBase = new OePSHdrDataBase(dataBaseAccess);        
		oePSHdrDataBase.setId(id);
		oePSHdrDataBase.delete();

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
PackSlipContainer generatePackSlipFromArray(ArrayList arrayItems){
    PackSlipContainer   packSlipContainer = new PackSlipContainer();
    PackSlip            packSlip = null;
    PackSlipDtl         packSlipDtl = null;
    int                 icurrentId = 0;

    foreach(string[] item in arrayItems) { 

        int         iexternalId =  Convert.ToInt32(item[0]);                                
        int         idetail  = Convert.ToInt32(item[20]);
        string      spart    = item[21];
        string      scustPart= item[22];
        decimal     dshipQty = Convert.ToDecimal(item[23]);
        decimal     dcum     = Convert.ToDecimal(item[24]);
        decimal     dpriorCum= Convert.ToDecimal(item[25]);

        packSlipDtl = new PackSlipDtl();                    
        packSlipDtl.ExternalDetail  = idetail;                    
        packSlipDtl.Part            = spart;
        packSlipDtl.CustPart        = scustPart;
        packSlipDtl.ShipQty         = dshipQty;
        packSlipDtl.FGCurCum        = dcum; 
        packSlipDtl.FGPrevCum       = dpriorCum;                

        if (icurrentId != iexternalId) { 
            string      splantQ  = item[1];
            string      sbillTo  = item[2];
            string      shipTo   = item[3];
            DateTime    shipDate = DateUtil.parseCompleteDate(item[4],DateUtil.MMDDYYYY);
            decimal     shipTime = Convert.ToDecimal(item[5]);
            DateTime    postDate = DateUtil.parseCompleteDate(item[6],DateUtil.MMDDYYYY);
            decimal     postTime = Convert.ToDecimal(item[7]);
            string      status   = item[8];

            packSlip = new PackSlip();
            packSlip.ExernalId  = iexternalId;
            packSlip.Plant      = splantQ;
            packSlip.BillTo     = sbillTo;
            packSlip.ShipTo     = shipTo;
            packSlip.ShipDate   = DateUtil.generateDateTimeFromCMS(shipDate,shipTime);
            packSlip.DatePosted = DateUtil.generateDateTimeFromCMS(postDate,postTime);                    
            packSlip.Status     = status;
            packSlipContainer.Add(packSlip);
        }
        packSlip.PackSlipDtlContainer.Add(packSlipDtl);                
        icurrentId = iexternalId;
    }
    return packSlipContainer;
}

private
PackSlipContainer generatePackSlipFromDataBaseContainers(   BolhDataBaseContainer bolhDataBaseContainer,
                                                            BoldDataBaseContainer boldDataBaseContainer){
    PackSlipContainer   packSlipContainer = new PackSlipContainer();
    PackSlip            packSlip = null;    
    PackSlipDtl         packSlipDtl = null;
    bool                bprocessDtl=true;
    int                 i=0;

    //both containers order by bolid , so we can process ordered            
    foreach (BolhDataBase bolhDataBase in bolhDataBaseContainer) { 
        packSlip = new PackSlip();
        packSlipContainer.Add(packSlip);

        packSlip.ExernalId  = Convert.ToInt32(bolhDataBase.getFEBOL());
        packSlip.Plant      = bolhDataBase.getFEPLNT();
        packSlip.BillTo     = bolhDataBase.getFEBCS();
        packSlip.ShipTo     = bolhDataBase.getFESCS();
        packSlip.DatePosted = DateUtil.generateDateTimeFromCMS(bolhDataBase.getFEPDAT(),bolhDataBase.getFEPTIM());
        packSlip.ShipDate   = DateUtil.generateDateTimeFromCMS(bolhDataBase.getFESDAT(),bolhDataBase.getFESTME());                    
        packSlip.Status     = bolhDataBase.getFESTS();

        bprocessDtl=true;
        for (; bprocessDtl && i < boldDataBaseContainer.Count; i++){
            BoldDataBase boldDataBase = (BoldDataBase)boldDataBaseContainer[i];

            if (boldDataBase.getFGBOL() == bolhDataBase.getFEBOL()) { 
                packSlipDtl = new PackSlipDtl();                    
                packSlipDtl.ExternalDetail = Convert.ToInt32(boldDataBase.getFGENT());                    
                packSlipDtl.Part = boldDataBase.getFGPART();
                packSlipDtl.CustPart = boldDataBase.getFGCPT();
                packSlipDtl.ShipQty = boldDataBase.getFGQSHP();
                packSlipDtl.FGCurCum = boldDataBase.getFGCCUM(); 
                packSlipDtl.FGPrevCum = boldDataBase.getFGPCUM();
                packSlip.PackSlipDtlContainer.Add(packSlipDtl);
            }else{
                i--; //decrement because this bold recort must be processed for next bol
                bprocessDtl=false;
            }       
        }           
    }

    return packSlipContainer;
}

public
PackSlipContainer transferPackSlipByFilters(string splant,DateTime fromDate,DateTime toDate,bool brunQuickProcess,int irows){
    PackSlipContainer packSlipContainer = new PackSlipContainer();
    try{
        ArrayList   arrayItems = new ArrayList();

        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);   

        BolhDataBaseContainer bolhDataBaseContainer = new BolhDataBaseContainer(dataBaseAccess);            
        BoldDataBaseContainer boldDataBaseContainer = new BoldDataBaseContainer(dataBaseAccess);

        if (brunQuickProcess)
            arrayItems = bolhDataBaseContainer.readByFiltersTransfer(splant,"",fromDate, toDate,irows);
        else{
            bolhDataBaseContainer.readByFiltersTransfer(0,splant,"",fromDate,toDate,irows);                
            if (bolhDataBaseContainer.Count > 0)
                boldDataBaseContainer.readByHeaders(bolhDataBaseContainer);
        }
        
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);   

        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        if (brunQuickProcess) 
            packSlipContainer =  generatePackSlipFromArray(arrayItems);                    
        else 
            packSlipContainer = generatePackSlipFromDataBaseContainers(bolhDataBaseContainer,boldDataBaseContainer);  
        
        //store packslips
        for (int i=0; i < packSlipContainer.Count; i++){
             PackSlip packSlip = packSlipContainer[i];

            OePSHdrDataBase oePSHdrDataBase = new OePSHdrDataBase(dataBaseAccess);
            if (oePSHdrDataBase.readExernalId(packSlip.ExernalId)){//check if BOL already imported, by external id
                packSlip.Id = oePSHdrDataBase.getId();
                updatePackSlipInt(packSlip);
            }else
                writePackSlipInt(packSlip);
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
    return packSlipContainer;
}

public
PackSlipContainer readPackSlipByFilters(string splant,DateTime fromDate,DateTime toDate,bool bonlyHeader,int irows){
    PackSlipContainer packSlipContainer = new PackSlipContainer();
    try{        
        OePSHdrDataBaseContainer oePSHdrDataBaseContainer = new OePSHdrDataBaseContainer(dataBaseAccess);
        oePSHdrDataBaseContainer.readByFilters(splant,fromDate,toDate,irows);

        foreach (OePSHdrDataBase oePSHdrDataBase in oePSHdrDataBaseContainer) {
            PackSlip packSlip = objectDataBaseToObject(oePSHdrDataBase);
            if (!bonlyHeader)
                loadPackSlipChilds(packSlip);

            packSlipContainer.Add(packSlip);
        }
                
	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
    return packSlipContainer;
}

private
PackSlip objectDataBaseToObject(OePSHdrDataBase oePSHdrDataBase){
	PackSlip packSlip = new PackSlip();

	packSlip.Id=oePSHdrDataBase.getId();
	packSlip.ExernalId=oePSHdrDataBase.getExernalId();
    packSlip.Plant = oePSHdrDataBase.getPlant();  
	packSlip.BillTo=oePSHdrDataBase.getBillTo();
	packSlip.ShipTo=oePSHdrDataBase.getShipTo();
	packSlip.DateCreated=oePSHdrDataBase.getDateCreated();
	packSlip.ShipDate=oePSHdrDataBase.getShipDate();
	packSlip.DatePosted=oePSHdrDataBase.getDatePosted();
	packSlip.Status=oePSHdrDataBase.getStatus();

	return packSlip;
}

private
OePSHdrDataBase objectToObjectDataBase(PackSlip packSlip){
	OePSHdrDataBase oePSHdrDataBase = new OePSHdrDataBase(dataBaseAccess);
	oePSHdrDataBase.setId(packSlip.Id);
	oePSHdrDataBase.setExernalId(packSlip.ExernalId);
    oePSHdrDataBase.setPlant(packSlip.Plant);
	oePSHdrDataBase.setBillTo(packSlip.BillTo);
	oePSHdrDataBase.setShipTo(packSlip.ShipTo);
	oePSHdrDataBase.setDateCreated(packSlip.DateCreated);
	oePSHdrDataBase.setShipDate(packSlip.ShipDate);
	oePSHdrDataBase.setDatePosted(packSlip.DatePosted);
	oePSHdrDataBase.setStatus(packSlip.Status);

	return oePSHdrDataBase;
}

public
PackSlip clonePackSlip(PackSlip packSlip){
	PackSlip packSlipClone = new PackSlip();

	packSlipClone.Id=packSlip.Id;
	packSlipClone.ExernalId=packSlip.ExernalId;
    packSlipClone.Plant=packSlip.Plant;
	packSlipClone.BillTo=packSlip.BillTo;
	packSlipClone.ShipTo=packSlip.ShipTo;
	packSlipClone.DateCreated=packSlip.DateCreated;
	packSlipClone.ShipDate=packSlip.ShipDate;
	packSlipClone.DatePosted=packSlip.DatePosted;
	packSlipClone.Status=packSlip.Status;

	return packSlipClone;
}

public
PackSlipDtl createPackSlipDtl(){
	return new PackSlipDtl();
}

public
PackSlipDtlContainer createPackSlipDtlContainer(){
	return new PackSlipDtlContainer();
}

private
PackSlipDtl objectDataBaseToObject(OePsDtlDataBase oePsDtlDataBase){
	PackSlipDtl packSlipDtl = new PackSlipDtl();

	packSlipDtl.HdrId=oePsDtlDataBase.getHdrId();
	packSlipDtl.Detail=oePsDtlDataBase.getDetail();
	packSlipDtl.ExternalDetail=oePsDtlDataBase.getExternalDetail();
	packSlipDtl.Part=oePsDtlDataBase.getPart();
	packSlipDtl.CustPart=oePsDtlDataBase.getCustPart();
	packSlipDtl.ShipQty=oePsDtlDataBase.getShipQty();
	packSlipDtl.FGCurCum=oePsDtlDataBase.getFGCurCum();
	packSlipDtl.FGPrevCum=oePsDtlDataBase.getFGPrevCum();

	return packSlipDtl;
}

private
OePsDtlDataBase objectToObjectDataBase(PackSlipDtl packSlipDtl){
	OePsDtlDataBase oePsDtlDataBase = new OePsDtlDataBase(dataBaseAccess);
	oePsDtlDataBase.setHdrId(packSlipDtl.HdrId);
	oePsDtlDataBase.setDetail(packSlipDtl.Detail);
	oePsDtlDataBase.setExternalDetail(packSlipDtl.ExternalDetail);
	oePsDtlDataBase.setPart(packSlipDtl.Part);
	oePsDtlDataBase.setCustPart(packSlipDtl.CustPart);
	oePsDtlDataBase.setShipQty(packSlipDtl.ShipQty);
	oePsDtlDataBase.setFGCurCum(packSlipDtl.FGCurCum);
	oePsDtlDataBase.setFGPrevCum(packSlipDtl.FGPrevCum);

	return oePsDtlDataBase;
}

public
PackSlipDtl clonePackSlipDtl(PackSlipDtl packSlipDtl){
	PackSlipDtl packSlipDtlClone = new PackSlipDtl();

	packSlipDtlClone.HdrId=packSlipDtl.HdrId;
	packSlipDtlClone.Detail=packSlipDtl.Detail;
	packSlipDtlClone.ExternalDetail=packSlipDtl.ExternalDetail;
	packSlipDtlClone.Part=packSlipDtl.Part;
	packSlipDtlClone.CustPart=packSlipDtl.CustPart;
	packSlipDtlClone.ShipQty=packSlipDtl.ShipQty;
	packSlipDtlClone.FGCurCum=packSlipDtl.FGCurCum;
	packSlipDtlClone.FGPrevCum=packSlipDtl.FGPrevCum;

	return packSlipDtlClone;
}

} // class
} // package