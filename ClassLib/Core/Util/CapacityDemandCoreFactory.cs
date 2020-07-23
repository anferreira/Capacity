using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Common;
using System.Threading;
using System.IO;
using Nujit.NujitERP.ClassLib.Core.Cms;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;
using Nujit.NujitERP.ClassLib.Core.ScheduleDemand;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.CapacityDemand;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.ScheduleDemand;
using Nujit.NujitERP.ClassLib.Core.Utility;
using Nujit.NujitERP.ClassLib.Core.Machines;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Machines;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Planned;

namespace Nujit.NujitERP.ClassLib.Core.Util{


public
class CapacityDemandCoreFactory : CapacityCoreFactory{


public
CapacityDemandCoreFactory(): base(){
}

public
CapacityHdr createCapacityHdr(){
	return new CapacityHdr();
}

public
CapacityHdrContainer createCapacityHdrContainer(){
	return new CapacityHdrContainer();
}


public
bool existsCapacityHdr(int id){
	try{
		CapacityHdrDataBase capacityHdrDataBase = new CapacityHdrDataBase(dataBaseAccess);

		capacityHdrDataBase.setId(id);

		return capacityHdrDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}


public
CapacityHdr readCapacityHdr(int id){
	try{
		CapacityHdrDataBase capacityHdrDataBase = new CapacityHdrDataBase(dataBaseAccess);
		capacityHdrDataBase.setId(id);

		if (!capacityHdrDataBase.read())
			return null;

		CapacityHdr capacityHdr = this.objectDataBaseToObject(capacityHdrDataBase);
        loadCapacityHdrChilds2(capacityHdr);
        
		return capacityHdr;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

private
void loadCapacityHdrChilds(CapacityHdr capacityHdr){
        CapacityPartDataBaseContainer capacityPartDataBaseContainer = new CapacityPartDataBaseContainer(dataBaseAccess);
        capacityPartDataBaseContainer.readByHdr(capacityHdr.Id);
        
        foreach(CapacityPartDataBase capacityPartDataBase in capacityPartDataBaseContainer){
            CapacityPart capacityPart = objectDataBaseToObject(capacityPartDataBase);
            capacityHdr.CapacityPartContainer.Add(capacityPart);

            CapacityPartDtlDataBaseContainer capacityPartDtlDataBaseContainer = new CapacityPartDtlDataBaseContainer(dataBaseAccess);
            capacityPartDtlDataBaseContainer.readByHdr(capacityPart.HdrId, capacityPart.Detail);
      
            foreach(CapacityPartDtlDataBase capacityPartDtlDataBase in capacityPartDtlDataBaseContainer){
                capacityPart.CapacityPartDtlContainer.Add(objectDataBaseToObject(capacityPartDtlDataBase));
            }

            CapacityReqDataBaseContainer capacityReqDataBaseContainer = new CapacityReqDataBaseContainer(dataBaseAccess);
            capacityReqDataBaseContainer.readByHdr(capacityPart.HdrId, capacityPart.Detail);
            foreach(CapacityReqDataBase capacityReqDataBase in capacityReqDataBaseContainer){
                capacityPart.CapacityReqContainer.Add(objectDataBaseToObject(capacityReqDataBase));
            }
        }
        loadCapacityHdrChildsMachPriority(capacityHdr);        
}

private
void loadCapacityHdrChilds2(CapacityHdr capacityHdr){
        Hashtable       hashParts = new Hashtable();
        CapacityPart    capacityPart = null;

        //read all parts
        CapacityPartDataBaseContainer capacityPartDataBaseContainer = new CapacityPartDataBaseContainer(dataBaseAccess);
        capacityPartDataBaseContainer.readByHdr(capacityHdr.Id);
        
        foreach(CapacityPartDataBase capacityPartDataBase in capacityPartDataBaseContainer){
            capacityPart = objectDataBaseToObject(capacityPartDataBase);
            capacityHdr.CapacityPartContainer.Add(capacityPart);

            hashParts.Add(capacityPart.Detail, capacityPart);
        }

        //read all dtls
        CapacityPartDtlDataBaseContainer capacityPartDtlDataBaseContainer = new CapacityPartDtlDataBaseContainer(dataBaseAccess);
        capacityPartDtlDataBaseContainer.readByHdrAll(capacityHdr.Id);
        foreach(CapacityPartDtlDataBase capacityPartDtlDataBase in capacityPartDtlDataBaseContainer){            
            if (hashParts.Contains(capacityPartDtlDataBase.getDetail())) { 
                capacityPart = (CapacityPart)hashParts[capacityPartDtlDataBase.getDetail()];
                capacityPart.CapacityPartDtlContainer.Add(objectDataBaseToObject(capacityPartDtlDataBase));
            }                              
        }
     
        //read all requirments
        CapacityReqDataBaseContainer capacityReqDataBaseContainer = new CapacityReqDataBaseContainer(dataBaseAccess);
        capacityReqDataBaseContainer.readByHdrAll(capacityHdr.Id);
        foreach(CapacityReqDataBase capacityReqDataBase in capacityReqDataBaseContainer){            
            if (hashParts.Contains(capacityReqDataBase.getDetail())) { 
                capacityPart = (CapacityPart)hashParts[capacityReqDataBase.getDetail()];
                capacityPart.CapacityReqContainer.Add(objectDataBaseToObject(capacityReqDataBase));
            }               
        }

        loadCapacityHdrChildsMachPriority(capacityHdr);        
}

private
void loadCapacityHdrChildsMachPriority(CapacityHdr capacityHdr){
    CapacityMachPriorityDataBaseContainer capacityMachPriorityDataBaseContainer = new CapacityMachPriorityDataBaseContainer(dataBaseAccess);
    capacityMachPriorityDataBaseContainer.readByHdr(capacityHdr.Id);
      
    foreach(CapacityMachPriorityDataBase capacityMachPriorityDataBase in capacityMachPriorityDataBaseContainer){
        CapacityMachPriority capacityMachPriority = objectDataBaseToObject(capacityMachPriorityDataBase);
        capacityHdr.CapacityMachPriorityContainer.Add(capacityMachPriority);

        PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);            
        if (pltDeptMachDataBase.readById(capacityMachPriority.MachineId))
            capacityMachPriority.MachineShow = pltDeptMachDataBase.getPDM_Mach();
    }
}

public 
void updateCapacityHdr(CapacityHdr capacityHdr){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
        updateCapacityHdrOnly(capacityHdr);

        deleteCapacityHdrChilds(capacityHdr.Id);
        writeCapacityHdrChilds(capacityHdr);

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
void updateCapacityHdrOnlyMachinePriority(CapacityHdr capacityHdr){ //because if we use generic update take so much time
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
        updateCapacityHdrOnly(capacityHdr);
        capacityHdr.fillRedundances();
        deleteCapacityMachine(capacityHdr.Id);
        writeCapacityMachine(capacityHdr);

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
CapacityMachPriority getCapacityMachPriority(int imachineId,string splant){
    try { 
        CapacityMachPriority    capacityMachPriority = null;

        CapacityHdr capacityHdr = readCapacityHdrLast(splant,true);
        if (capacityHdr!=null){
            CapacityMachPriorityDataBase capacityMachPriorityDataBase = new CapacityMachPriorityDataBase(dataBaseAccess);
            if (capacityMachPriorityDataBase.readByHdrMachine(capacityHdr.Id,imachineId))
                capacityMachPriority = objectDataBaseToObject(capacityMachPriorityDataBase);
        }
        return capacityMachPriority;

    }catch(PersistenceException persistenceException){		     
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
}

public 
bool updateCapacityPart(CapacityPart capacityPart){ //can not read full CapacityHdr, to change only 1 record, that will take so much time, so we update specific record here
    try{
        bool bresult=false;

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CapacityPartDataBase capacityPartDataBase = this.objectToObjectDataBase(capacityPart);
        if (capacityPartDataBase.read()) { 
            if (capacityPartDataBase.getPart().ToUpper().Equals(capacityPart.Part.ToUpper()) && 
                capacityPartDataBase.getSeq() == capacityPart.Seq){ //just in case, checking if nothing changed

                capacityPartDataBase = this.objectToObjectDataBase(capacityPart);
		        capacityPartDataBase.update();
                bresult=true;
            }
        }

	    if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

        return bresult;

	}catch(PersistenceException persistenceException){		
        dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

private
void writeCapacityHdrChilds(CapacityHdr capacityHdr){
    capacityHdr.fillRedundances();
    
    foreach(CapacityPart capacityPart in capacityHdr.CapacityPartContainer){        
        writeCapacityPart(capacityPart);        
    }
    writeCapacityMachine(capacityHdr);
}

private
void writeCapacityMachine(CapacityHdr capacityHdr){
    foreach(CapacityMachPriority capacityMachPriority in capacityHdr.CapacityMachPriorityContainer){
        CapacityMachPriorityDataBase capacityMachPriorityDataBase = this.objectToObjectDataBase(capacityMachPriority);
		capacityMachPriorityDataBase.write();   
    }   
}

private
void writeCapacityPart(CapacityPart capacityPart){
    capacityPart.fillRedundances();

    CapacityPartDataBase capacityPartDataBase = this.objectToObjectDataBase(capacityPart);
    capacityPartDataBase.write();
        
    foreach(CapacityPartDtl capacityPartDtl in capacityPart.CapacityPartDtlContainer){            
        CapacityPartDtlDataBase capacityPartDtlDataBase = this.objectToObjectDataBase(capacityPartDtl);
        capacityPartDtlDataBase.write();
    }

    foreach(CapacityReq capacityReq in capacityPart.CapacityReqContainer){           
        CapacityReqDataBase capacityReqDataBase = this.objectToObjectDataBase(capacityReq);
        capacityReqDataBase.write();
    }
}

public 
void deleteCapacityHdrChilds(int id){
    CapacityPartDtlDataBaseContainer capacityPartDtlDataBaseContainer = new CapacityPartDtlDataBaseContainer(dataBaseAccess);
    capacityPartDtlDataBaseContainer.deleteByHdr(id);

    CapacityReqDataBaseContainer capacityReqDataBaseContainer = new CapacityReqDataBaseContainer(dataBaseAccess);
    capacityReqDataBaseContainer.deleteByHdr(id);

    CapacityPartDataBaseContainer capacityPartDataBaseContainer = new CapacityPartDataBaseContainer(dataBaseAccess);
    capacityPartDataBaseContainer.deleteByHdr(id);    

    deleteCapacityMachine(id);
}

public 
void deleteCapacityMachine(int id){
    CapacityMachPriorityDataBaseContainer capacityMachPriorityDataBaseContainer = new CapacityMachPriorityDataBaseContainer(dataBaseAccess);
    capacityMachPriorityDataBaseContainer.deleteByHdr(id);
}

private 
void updateCapacityHdrOnly(CapacityHdr capacityHdr){
    CapacityHdrDataBase capacityHdrDataBase = this.objectToObjectDataBase(capacityHdr);
    checkDateTimeStamp(capacityHdr, capacityHdrDataBase);
	capacityHdrDataBase.update();
    capacityHdr.DateTimeStamp = capacityHdrDataBase.readDateTimeStamp();
}


private
bool checkDateTimeStamp(CapacityHdr capacityHdr, CapacityHdrDataBase capacityHdrDataBase) {
    bool bchanged=false;
    if (capacityHdr.DateTimeStamp != capacityHdrDataBase.readDateTimeStamp())
        throw new Exception("Capacity " + Constants.DATETIME_STAMP_TABLE_MESSAGE);

    return bchanged;
}

public 
void writeCapacityHdr(CapacityHdr capacityHdr){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CapacityHdrDataBase capacityHdrDataBase = this.objectToObjectDataBase(capacityHdr);
		capacityHdrDataBase.write();

		capacityHdr.Id=capacityHdrDataBase.getId();
        capacityHdr.DateTimeStamp = capacityHdrDataBase.readDateTimeStamp();
        writeCapacityHdrChilds(capacityHdr);

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
void deleteCapacityHdr(int id){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        deleteCapacityHdrChilds(id);
		CapacityHdrDataBase capacityHdrDataBase = new CapacityHdrDataBase(dataBaseAccess);
    
		capacityHdrDataBase.setId(id);
		capacityHdrDataBase.delete();

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
CapacityHdrContainer readCapacityHdrByFilters(string sid,string splant,string status, DateTime fromDate, DateTime toDate, bool bonlyHeader, int rows){
	try{
        CapacityHdrContainer capacityHdrContainer = new CapacityHdrContainer();

        CapacityHdrDataBaseContainer capacityHdrDataBaseContainer = new CapacityHdrDataBaseContainer(dataBaseAccess);
		capacityHdrDataBaseContainer.readByFilters(sid,splant,status, fromDate,toDate,rows);	
        
        foreach(CapacityHdrDataBase capacityHdrDataBase in capacityHdrDataBaseContainer){
            CapacityHdr capacityHdr = objectDataBaseToObject(capacityHdrDataBase);
            
            if (!bonlyHeader)
                capacityHdr = readCapacityHdr(capacityHdr.Id);

            if (capacityHdr != null)
                capacityHdrContainer.Add(capacityHdr);
        }

		return capacityHdrContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
CapacityHdr readCapacityHdrLast(string splant,bool bonlyHeadr){
	try{		
        CapacityHdrDataBase capacityHdrDataBase = new CapacityHdrDataBase(dataBaseAccess);

        if (!capacityHdrDataBase.readLastByFilter(splant))
            return null;        

        CapacityHdr capacityHdr = this.objectDataBaseToObject(capacityHdrDataBase);
        if (!bonlyHeadr)        
            loadCapacityHdrChilds2(capacityHdr);

		return capacityHdr;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
CapacityHdr readCapacityHdrLastDateCheck(CapacityHdr capacityHdr, string splant){
    CapacityHdr capacityHdrNew = null;
	try{
        capacityHdrNew = capacityHdr;
        bool                breadNew = false;
        CapacityHdrDataBase capacityHdrDataBase = new CapacityHdrDataBase(dataBaseAccess);		
        if (!capacityHdrDataBase.readLastByFilter(splant))
			return null;

        if (capacityHdr == null)
            breadNew = true;            
        else if (capacityHdr.DateTimeStamp != capacityHdrDataBase.getDateTimeStamp() || capacityHdr.Id != capacityHdrDataBase.getId())
            breadNew = true;    

        if (breadNew)
            capacityHdrNew = readCapacityHdr(capacityHdrDataBase.getId());

		return capacityHdrNew;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

private
CapacityHdr objectDataBaseToObject(CapacityHdrDataBase capacityHdrDataBase){
	CapacityHdr capacityHdr = new CapacityHdr();

	capacityHdr.Id=capacityHdrDataBase.getId();
	capacityHdr.DateCreated=capacityHdrDataBase.getDateCreated();
	capacityHdr.Status=capacityHdrDataBase.getStatus();
    capacityHdr.Plant =capacityHdrDataBase.getPlant();
    capacityHdr.DateTimeStamp = capacityHdrDataBase.getDateTimeStamp();

	return capacityHdr;
}

private
CapacityHdrDataBase objectToObjectDataBase(CapacityHdr capacityHdr){
	CapacityHdrDataBase capacityHdrDataBase = new CapacityHdrDataBase(dataBaseAccess);
	capacityHdrDataBase.setId(capacityHdr.Id);
	capacityHdrDataBase.setDateCreated(capacityHdr.DateCreated);
	capacityHdrDataBase.setStatus(capacityHdr.Status);
    capacityHdrDataBase.setPlant(capacityHdr.Plant);
    capacityHdrDataBase.setDateTimeStamp(capacityHdr.DateTimeStamp);

	return capacityHdrDataBase;
}

public
CapacityHdr cloneCapacityHdr(CapacityHdr capacityHdr){
	CapacityHdr capacityHdrClone = new CapacityHdr();
    capacityHdrClone.copy(capacityHdr);	
	return capacityHdrClone;
}

public
CapacityHdr processCapacityDemand(int ihotListId,string splantOriginal){
    try{
        
        CapacityHdr         capacityHdr = new CapacityHdr();
        HotListHdrDataBase  hotListHdrDataBase = new HotListHdrDataBase(dataBaseAccess);
        PltDeptMachDataBase pltDeptMachDataBase=null;
        DateTime            dstartDate = DateTime.Now;
        string[]            filterDept = new string[0];
        string[]            filterPart = new string[0];
        string[]            filterMg  = new string[0];
        string              splant = "";
           
        //read hot list hdr
        if (ihotListId <= 0){ // We get the last hotList, if returns 0 there are not hotHotlist record generated		    
            if (string.IsNullOrEmpty(splantOriginal))   ihotListId = hotListHdrDataBase.readLastId();
            else                                        ihotListId = hotListHdrDataBase.readLastIdByPlant(splantOriginal);
        }

        hotListHdrDataBase.setId(ihotListId);
        if (!hotListHdrDataBase.read())
            return capacityHdr;

        splant = hotListHdrDataBase.getHLR_Plant();
        dstartDate = hotListHdrDataBase.getHLR_HotlistRunDate();
        capacityHdr.Plant = splant;             //set plant
        
        //read hot list 
        HotListDataBaseContainer hotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);	
	    hotListDataBaseContainer.readReport(ihotListId, filterDept, filterPart, filterMg, "",false, "B");

        //read all parts
        ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
        prodFmInfoDataBaseContainer.read();

        //read all methdr/  ProdFmActSub       
        ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
        prodFmActSubDataBaseContainer.read();
        
        for (int i = 0; i < hotListDataBaseContainer.Count /*&& i < 500*/; i++){
            HotListDataBase hotListDataBase = (HotListDataBase)hotListDataBaseContainer[i];
                        
            //quantities
            decimal pastDue= hotListDataBase.getHOT_PastDue();
			decimal day001 = hotListDataBase.getHOT_Day001() - hotListDataBase.getHOT_PastDue();
			decimal day002 = hotListDataBase.getHOT_Day002() - hotListDataBase.getHOT_Day001();
			decimal day003 = hotListDataBase.getHOT_Day003() - hotListDataBase.getHOT_Day002();
			decimal day004 = hotListDataBase.getHOT_Day004() - hotListDataBase.getHOT_Day003();
			decimal day005 = hotListDataBase.getHOT_Day005() - hotListDataBase.getHOT_Day004();
			decimal day006 = hotListDataBase.getHOT_Day006() - hotListDataBase.getHOT_Day005();
			decimal day007 = hotListDataBase.getHOT_Day007() - hotListDataBase.getHOT_Day006();
			decimal day008 = hotListDataBase.getHOT_Day008() - hotListDataBase.getHOT_Day007();
			decimal day009 = hotListDataBase.getHOT_Day009() - hotListDataBase.getHOT_Day008();
			decimal day010 = hotListDataBase.getHOT_Day010() - hotListDataBase.getHOT_Day009();
			decimal day011 = hotListDataBase.getHOT_Day011() - hotListDataBase.getHOT_Day010();
			decimal day012 = hotListDataBase.getHOT_Day012() - hotListDataBase.getHOT_Day011();
			decimal day013 = hotListDataBase.getHOT_Day013() - hotListDataBase.getHOT_Day012();
			decimal day014 = hotListDataBase.getHOT_Day014() - hotListDataBase.getHOT_Day013();
			decimal day015 = hotListDataBase.getHOT_Day015() - hotListDataBase.getHOT_Day014();

			decimal day016 = hotListDataBase.getHOT_Day016() - hotListDataBase.getHOT_Day015();
			decimal day017 = hotListDataBase.getHOT_Day017() - hotListDataBase.getHOT_Day016();
			decimal day018 = hotListDataBase.getHOT_Day018() - hotListDataBase.getHOT_Day017();
			decimal day019 = hotListDataBase.getHOT_Day019() - hotListDataBase.getHOT_Day018();
			decimal day020 = hotListDataBase.getHOT_Day020() - hotListDataBase.getHOT_Day019();
			decimal day021 = hotListDataBase.getHOT_Day021() - hotListDataBase.getHOT_Day020();
			decimal day022 = hotListDataBase.getHOT_Day022() - hotListDataBase.getHOT_Day021();
			decimal day023 = hotListDataBase.getHOT_Day023() - hotListDataBase.getHOT_Day022();
			decimal day024 = hotListDataBase.getHOT_Day024() - hotListDataBase.getHOT_Day023();
			decimal day025 = hotListDataBase.getHOT_Day025() - hotListDataBase.getHOT_Day024();
			decimal day026 = hotListDataBase.getHOT_Day026() - hotListDataBase.getHOT_Day025();
			decimal day027 = hotListDataBase.getHOT_Day027() - hotListDataBase.getHOT_Day026();
			decimal day028 = hotListDataBase.getHOT_Day028() - hotListDataBase.getHOT_Day027();
			decimal day029 = hotListDataBase.getHOT_Day029() - hotListDataBase.getHOT_Day028();
			decimal day030 = hotListDataBase.getHOT_Day030() - hotListDataBase.getHOT_Day029();

			decimal day031 = hotListDataBase.getHOT_Day031() - hotListDataBase.getHOT_Day030();
			decimal day032 = hotListDataBase.getHOT_Day032() - hotListDataBase.getHOT_Day031();
			decimal day033 = hotListDataBase.getHOT_Day033() - hotListDataBase.getHOT_Day032();
			decimal day034 = hotListDataBase.getHOT_Day034() - hotListDataBase.getHOT_Day033();
			decimal day035 = hotListDataBase.getHOT_Day035() - hotListDataBase.getHOT_Day034();
			decimal day036 = hotListDataBase.getHOT_Day036() - hotListDataBase.getHOT_Day035();
			decimal day037 = hotListDataBase.getHOT_Day037() - hotListDataBase.getHOT_Day036();
			decimal day038 = hotListDataBase.getHOT_Day038() - hotListDataBase.getHOT_Day037();
			decimal day039 = hotListDataBase.getHOT_Day039() - hotListDataBase.getHOT_Day038();
			decimal day040 = hotListDataBase.getHOT_Day040() - hotListDataBase.getHOT_Day039();
			decimal day041 = hotListDataBase.getHOT_Day041() - hotListDataBase.getHOT_Day040();
			decimal day042 = hotListDataBase.getHOT_Day042() - hotListDataBase.getHOT_Day041();
			decimal day043 = hotListDataBase.getHOT_Day043() - hotListDataBase.getHOT_Day042();
			decimal day044 = hotListDataBase.getHOT_Day044() - hotListDataBase.getHOT_Day043();
			decimal day045 = hotListDataBase.getHOT_Day045() - hotListDataBase.getHOT_Day044();
				
			decimal day046 = hotListDataBase.getHOT_Day046() - hotListDataBase.getHOT_Day045();
			decimal day047 = hotListDataBase.getHOT_Day047() - hotListDataBase.getHOT_Day046();
			decimal day048 = hotListDataBase.getHOT_Day048() - hotListDataBase.getHOT_Day047();
			decimal day049 = hotListDataBase.getHOT_Day049() - hotListDataBase.getHOT_Day048();
			decimal day050 = hotListDataBase.getHOT_Day050() - hotListDataBase.getHOT_Day049();
			decimal day051 = hotListDataBase.getHOT_Day051() - hotListDataBase.getHOT_Day050();
			decimal day052 = hotListDataBase.getHOT_Day052() - hotListDataBase.getHOT_Day051();
			decimal day053 = hotListDataBase.getHOT_Day053() - hotListDataBase.getHOT_Day052();
			decimal day054 = hotListDataBase.getHOT_Day054() - hotListDataBase.getHOT_Day053();
			decimal day055 = hotListDataBase.getHOT_Day055() - hotListDataBase.getHOT_Day054();
			decimal day056 = hotListDataBase.getHOT_Day056() - hotListDataBase.getHOT_Day055();
			decimal day057 = hotListDataBase.getHOT_Day057() - hotListDataBase.getHOT_Day056();
			decimal day058 = hotListDataBase.getHOT_Day058() - hotListDataBase.getHOT_Day057();
			decimal day059 = hotListDataBase.getHOT_Day059() - hotListDataBase.getHOT_Day058();
			decimal day060 = hotListDataBase.getHOT_Day060() - hotListDataBase.getHOT_Day059();
            
            //AF 061 to 090
			decimal day061 = hotListDataBase.getHOT_Day061() - hotListDataBase.getHOT_Day060();
			decimal day062 = hotListDataBase.getHOT_Day062() - hotListDataBase.getHOT_Day061();
			decimal day063 = hotListDataBase.getHOT_Day063() - hotListDataBase.getHOT_Day062();
			decimal day064 = hotListDataBase.getHOT_Day064() - hotListDataBase.getHOT_Day063();
			decimal day065 = hotListDataBase.getHOT_Day065() - hotListDataBase.getHOT_Day064();
			decimal day066 = hotListDataBase.getHOT_Day066() - hotListDataBase.getHOT_Day065();
			decimal day067 = hotListDataBase.getHOT_Day067() - hotListDataBase.getHOT_Day066();
			decimal day068 = hotListDataBase.getHOT_Day068() - hotListDataBase.getHOT_Day067();
			decimal day069 = hotListDataBase.getHOT_Day069() - hotListDataBase.getHOT_Day068();
			decimal day070 = hotListDataBase.getHOT_Day070() - hotListDataBase.getHOT_Day069();

            decimal day071 = hotListDataBase.getHOT_Day071() - hotListDataBase.getHOT_Day070();
			decimal day072 = hotListDataBase.getHOT_Day072() - hotListDataBase.getHOT_Day071();
			decimal day073 = hotListDataBase.getHOT_Day073() - hotListDataBase.getHOT_Day072();
			decimal day074 = hotListDataBase.getHOT_Day074() - hotListDataBase.getHOT_Day073();
			decimal day075 = hotListDataBase.getHOT_Day075() - hotListDataBase.getHOT_Day074();
			decimal day076 = hotListDataBase.getHOT_Day076() - hotListDataBase.getHOT_Day075();
			decimal day077 = hotListDataBase.getHOT_Day077() - hotListDataBase.getHOT_Day076();
			decimal day078 = hotListDataBase.getHOT_Day078() - hotListDataBase.getHOT_Day077();
			decimal day079 = hotListDataBase.getHOT_Day079() - hotListDataBase.getHOT_Day078();
			decimal day080 = hotListDataBase.getHOT_Day080() - hotListDataBase.getHOT_Day079();

            decimal day081 = hotListDataBase.getHOT_Day081() - hotListDataBase.getHOT_Day080();
			decimal day082 = hotListDataBase.getHOT_Day082() - hotListDataBase.getHOT_Day081();
			decimal day083 = hotListDataBase.getHOT_Day083() - hotListDataBase.getHOT_Day082();
			decimal day084 = hotListDataBase.getHOT_Day084() - hotListDataBase.getHOT_Day083();
			decimal day085 = hotListDataBase.getHOT_Day085() - hotListDataBase.getHOT_Day084();
			decimal day086 = hotListDataBase.getHOT_Day086() - hotListDataBase.getHOT_Day085();
			decimal day087 = hotListDataBase.getHOT_Day087() - hotListDataBase.getHOT_Day086();
			decimal day088 = hotListDataBase.getHOT_Day088() - hotListDataBase.getHOT_Day087();
			decimal day089 = hotListDataBase.getHOT_Day089() - hotListDataBase.getHOT_Day088();
			decimal day090 = hotListDataBase.getHOT_Day090() - hotListDataBase.getHOT_Day089();

            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,pastDue,dstartDate.AddDays(-1));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day001, dstartDate            );
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day002, dstartDate.AddDays(1) );
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day003, dstartDate.AddDays(2) );
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day004, dstartDate.AddDays(3) );
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day005, dstartDate.AddDays(4) );
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day006, dstartDate.AddDays(5) );
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day007, dstartDate.AddDays(6) );
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day008, dstartDate.AddDays(7) );
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day009, dstartDate.AddDays(8) );
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day010, dstartDate.AddDays(9) );

            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day011, dstartDate.AddDays(10));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day012, dstartDate.AddDays(11));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day013, dstartDate.AddDays(12));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day014, dstartDate.AddDays(13));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day015, dstartDate.AddDays(14));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day016, dstartDate.AddDays(15));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day017, dstartDate.AddDays(16));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day018, dstartDate.AddDays(17));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day019, dstartDate.AddDays(18));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day020, dstartDate.AddDays(19));

            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day021, dstartDate.AddDays(20));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day022, dstartDate.AddDays(21));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day023, dstartDate.AddDays(22));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day024, dstartDate.AddDays(23));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day025, dstartDate.AddDays(24));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day026, dstartDate.AddDays(25));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day027, dstartDate.AddDays(26));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day028, dstartDate.AddDays(27));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day029, dstartDate.AddDays(28));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day030, dstartDate.AddDays(29));

            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day031, dstartDate.AddDays(30));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day032, dstartDate.AddDays(31));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day033, dstartDate.AddDays(32));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day034, dstartDate.AddDays(33));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day035, dstartDate.AddDays(34));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day036, dstartDate.AddDays(35));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day037, dstartDate.AddDays(36));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day038, dstartDate.AddDays(37));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day039, dstartDate.AddDays(38));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day040, dstartDate.AddDays(39));

            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day041, dstartDate.AddDays(40));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day042, dstartDate.AddDays(41));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day043, dstartDate.AddDays(42));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day044, dstartDate.AddDays(43));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day045, dstartDate.AddDays(44));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day046, dstartDate.AddDays(45));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day047, dstartDate.AddDays(46));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day048, dstartDate.AddDays(47));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day049, dstartDate.AddDays(48));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day050, dstartDate.AddDays(49));

            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day051, dstartDate.AddDays(50));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day052, dstartDate.AddDays(51));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day053, dstartDate.AddDays(52));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day054, dstartDate.AddDays(53));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day055, dstartDate.AddDays(54));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day056, dstartDate.AddDays(55));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day057, dstartDate.AddDays(56));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day058, dstartDate.AddDays(57));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day059, dstartDate.AddDays(58));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day060, dstartDate.AddDays(59));

            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day061, dstartDate.AddDays(60));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day062, dstartDate.AddDays(61));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day063, dstartDate.AddDays(62));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day064, dstartDate.AddDays(63));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day065, dstartDate.AddDays(64));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day066, dstartDate.AddDays(65));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day067, dstartDate.AddDays(66));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day068, dstartDate.AddDays(67));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day069, dstartDate.AddDays(68));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day070, dstartDate.AddDays(69));

            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day071, dstartDate.AddDays(70));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day072, dstartDate.AddDays(71));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day073, dstartDate.AddDays(72));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day074, dstartDate.AddDays(73));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day075, dstartDate.AddDays(74));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day076, dstartDate.AddDays(75));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day077, dstartDate.AddDays(76));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day078, dstartDate.AddDays(77));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day079, dstartDate.AddDays(78));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day080, dstartDate.AddDays(79));

            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day081, dstartDate.AddDays(80));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day082, dstartDate.AddDays(81));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day083, dstartDate.AddDays(82));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day084, dstartDate.AddDays(83));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day085, dstartDate.AddDays(84));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day086, dstartDate.AddDays(85));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day087, dstartDate.AddDays(86));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day088, dstartDate.AddDays(87));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day089, dstartDate.AddDays(88));
            addCapacityPartSummarize(prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(),hotListDataBase.getHOT_IdAut(),splant, capacityHdr,day090, dstartDate.AddDays(89));

            //hotListDataBase.setHOT_Qoh(hotListDataBase.getHOT_Qoh() / runStd);
        }

        //load machine priorites, based last Capacity
        CapacityHdr capacityHdrPrior = readCapacityHdrLast(capacityHdr.Plant,true);
        if (capacityHdrPrior!=null){
            loadCapacityHdrChildsMachPriority(capacityHdrPrior);
            capacityHdr.CapacityMachPriorityContainer = capacityHdrPrior.CapacityMachPriorityContainer;
        }

        writeCapacityHdr(capacityHdr);
        //System.Windows.Forms.MessageBox.Show("Finish process processCapacityDemand");

	    return capacityHdr;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}

}

/*
private
CapacityPart addCapacityPart(ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer,HotListDataBase hotListDataBase,
                            CapacityHdr capacityHdr,decimal dqty,DateTime date){
    CapacityPart        capacityPart = null;
    CapacityPartDtl     capacityPartDtl = null;
    CapacityReq         capacityReq = null;
    string              splant="";
    string              sdept = "";
    string              smachine = "";    
    int                 ireqMachine = 0;
    int                 ireqTool = 0;
    int                 ireqLabour = 0;
    decimal             runStd = 0;
	int                 imenQty = 0;
	int                 imachQty= 0;     
    decimal             dhours = 0;

    dqty = Math.Abs(dqty);
          
    //read methdr/ProdFmActSub 
    ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(this.dataBaseAccess);
    prodFmActSubDataBase.setPC_ProdID(hotListDataBase.getHOT_ProdID());
    prodFmActSubDataBase.setPC_Seq(hotListDataBase.getHOT_Seq());                        
    if (prodFmActSubDataBase.read()){                

        runStd = prodFmActSubDataBase.getPC_RunStd();
		imenQty = prodFmActSubDataBase.getPC_QtyMen();
		imachQty= prodFmActSubDataBase.getPC_QtyMachines();

        //machine
        splant  = prodFmActSubDataBase.getPC_Plt();            
        sdept   = prodFmActSubDataBase.getPC_Dept();
        smachine= prodFmActSubDataBase.getPC_Cfg();
               
        if (!string.IsNullOrEmpty(smachine)){
            PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
            pltDeptMachDataBase.setPDM_Plt(splant);
            pltDeptMachDataBase.setPDM_Dept(sdept);
            pltDeptMachDataBase.setPDM_Mach(smachine);
            if (pltDeptMachDataBase.read()){
                ireqMachine = pltDeptMachDataBase.getPDM_ID();
            }
        }

        if (imenQty > 0 && imachQty > 0)                        
            ireqLabour = 1;          
    }            	
    
    
    if (dqty > 0 && runStd != 0 && (ireqMachine > 0 || ireqLabour > 0 || ireqTool > 0)){
        ProdFmInfoDataBase prodFmInfoDataBase = prodFmInfoDataBaseContainer.getProdFmInfo(hotListDataBase.getHOT_ProdID());

        capacityPart = new CapacityPart();               
        capacityPart.Part = hotListDataBase.getHOT_ProdID();
        capacityPart.Seq  = hotListDataBase.getHOT_Seq();
        capacityPart.StartDate = capacityPart.EndDate = date;
        capacityPart.HotListID = hotListDataBase.getHOT_Id();
        capacityPart.Qty = dqty;
        capacityPart.Plant = splant;
        capacityPart.Dept = sdept;
        capacityHdr.CapacityPartContainer.Add(capacityPart); //add capacity part

        if (prodFmInfoDataBase!= null){
            capacityPart.IsFamily = prodFmInfoDataBase.getPFS_FamProd();        
        }
        
        if (ireqMachine > 0){
            dhours = dqty / (runStd != 0 ? runStd : 1);
            capacityReq = addCapacityReq(CapacityReq.REQUIREMENT_MACHINE, ireqMachine,dhours, 0, 0);
            capacityPart.CapacityReqContainer.Add(capacityReq);                             
        }

        if (ireqLabour > 0){
            decimal daux = dqty / (runStd != 0 ? runStd : 1);
            dhours = daux * (imenQty * imachQty);
            capacityReq = addCapacityReq(CapacityReq.REQUIREMENT_LABOUR, ireqLabour, dhours,imenQty,imachQty);
            capacityPart.CapacityReqContainer.Add(capacityReq);                      
        }            
    }   
    return capacityPart;
}
*/

private
CapacityPart addCapacityPartSummarize(  ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer,
                                        ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer,
                                        HotListDataBase hotListDataBase, string splantOriginal,
                                        CapacityHdr capacityHdr, decimal dqty,DateTime date){
    CapacityPart        capacityPart = null;    
    string              splant="";
    string              sdept = "";
    string              smachine = "";    
    int                 ireqMachine = 0;
    int                 ireqTool = 0;
    int                 ireqLabour = 0;
    decimal             runStd = 0;
	int                 imenQty = 0;
	int                 imachQty= 0;     
    decimal             dhours = 0;    

    dqty = Math.Abs(dqty);
          
    //search for methdr/ProdFmActSub 
    ProdFmActSubDataBase    prodFmActSubDataBase = null;
    bool                    bfound = getProdFmActSubDataBase(out prodFmActSubDataBase, prodFmActSubDataBaseContainer, 
                                     hotListDataBase.getHOT_ProdID().Trim(),hotListDataBase.getHOT_Seq(), splantOriginal);          
    if (bfound){

        runStd = prodFmActSubDataBase.getPC_RunStd();
		imenQty = prodFmActSubDataBase.getPC_QtyMen();
		imachQty= prodFmActSubDataBase.getPC_QtyMachines();

        //machine
        splant  = prodFmActSubDataBase.getPC_Plt();            
        sdept   = prodFmActSubDataBase.getPC_Dept();
        smachine= prodFmActSubDataBase.getPC_Cfg();
               
        if (!string.IsNullOrEmpty(smachine)){
            PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
            pltDeptMachDataBase.setPDM_Plt(splant);
            pltDeptMachDataBase.setPDM_Dept(sdept);
            pltDeptMachDataBase.setPDM_Mach(smachine);
            if (pltDeptMachDataBase.read()){
                ireqMachine = pltDeptMachDataBase.getPDM_ID();
            }
        }

        if (imenQty > 0 && imachQty > 0)                        
            ireqLabour = 1;        
        /*
        //////////////////////////////
        string saux= "Part: " + hotListDataBase.getHOT_ProdID() + " Seq:" + hotListDataBase.getHOT_Seq() + "\nMachine:" + smachine +  "runStd:" + runStd;
        if (ireqLabour > 0)
            saux+= "\nLabour: menQty=" + imenQty + " machQty=" + imachQty;
        System.Windows.Forms.MessageBox.Show(saux);
        ////////////////////////////
        */
    }            	
    
    
    if (dqty > 0 && runStd != 0 && (ireqMachine > 0 || ireqLabour > 0 || ireqTool > 0)){
        ProdFmInfoDataBase prodFmInfoDataBase = prodFmInfoDataBaseContainer.getProdFmInfo(hotListDataBase.getHOT_ProdID());
 
        capacityPart = capacityHdr.CapacityPartContainer.getByPartSeqDateRangeWeek( hotListDataBase.getHOT_ProdID(), hotListDataBase.getHOT_Seq(),
                                                                                    splant,sdept,date);
        if (capacityPart==null){
            capacityPart = new CapacityPart();               
            capacityPart.Part = hotListDataBase.getHOT_ProdID();
            capacityPart.Seq  = hotListDataBase.getHOT_Seq();

            DateTime dpriortMonday = date;
            DateTime dnextSunday = date;
            Nujit.NujitERP.ClassLib.Util.DateUtil.getPriorMondayNextSundayFromDate(date, out dpriortMonday, out dnextSunday);

            /*
            System.Windows.Forms.MessageBox.Show("NoPart:" + capacityPart.Part + " Seq:" + capacityPart.Seq + "\n" +
                                          "Date:" + DateUtil.getCompleteDateRepresentation(date,DateUtil.DDMMYYYY) + "\n" +
                                          "Mon :" + DateUtil.getCompleteDateRepresentation(dfirstMonday, DateUtil.DDMMYYYY) + "\n" +
                                          "Sun :" + DateUtil.getCompleteDateRepresentation(dnextSunday, DateUtil.DDMMYYYY) + "\n" +
                                          ((date >= dfirstMonday && date <= dnextSunday) ? "In Range" : "No Range") );
            */

            capacityPart.StartDate = dpriortMonday;
            capacityPart.EndDate = dnextSunday;
            capacityPart.HotListID = hotListDataBase.getHOT_IdAut();
            capacityPart.Qty = dqty;
            capacityPart.Plant = splant;
            capacityPart.Dept = sdept;
            capacityHdr.CapacityPartContainer.Add(capacityPart); //add capacity part
        }else{            
            capacityPart.Qty = capacityPart.Qty+ dqty;
                    /*
            System.Windows.Forms.MessageBox.Show(
                "Part Found:" + capacityPart.Part + " Seq:" + capacityPart.Seq + "\n" +
                "Date:" + DateUtil.getCompleteDateRepresentation(date,DateUtil.DDMMYYYY) + "\n" +
                "Mon :" + DateUtil.getCompleteDateRepresentation(capacityPart.StartDate, DateUtil.DDMMYYYY) + "\n" +
                "Sund :" + DateUtil.getCompleteDateRepresentation(capacityPart.EndDate, DateUtil.DDMMYYYY) + "\n" +
                ((date >= capacityPart.StartDate && date <= capacityPart.EndDate) ? "In Range" : "No Range") );
                */
        }

        if (prodFmInfoDataBase!= null){
            capacityPart.IsFamily = prodFmInfoDataBase.getPFS_FamProd();  
            if (capacityPart.IsFamily.Equals("F"))
                addCapacityPartDtlSummarize(capacityPart,dqty);
        }
        
        if (ireqMachine > 0){
            dhours = dqty / (runStd != 0 ? runStd : 1);
            addCapacityReqSummarize(capacityPart,CapacityReq.REQUIREMENT_MACHINE, ireqMachine,dhours, 0, 0);        
        }

        if (ireqLabour > 0){
            decimal daux = dqty / (runStd != 0 ? runStd : 1);
            dhours = daux * (imenQty * imachQty);
            addCapacityReqSummarize(capacityPart,CapacityReq.REQUIREMENT_LABOUR, ireqLabour, dhours,imenQty,imachQty);            
        }            
    }   
    return capacityPart;
}

private
CapacityReq addCapacityReq(string stype,int reqId,decimal dhours,int itotEmployees,int iemployeeHours){
    CapacityReq capacityReq = new CapacityReq();
    capacityReq.Type = stype;
    capacityReq.ReqID= reqId;
    capacityReq.Hours = dhours;                

    capacityReq.TotEmployees = itotEmployees;
    capacityReq.EmployeeHours= Convert.ToDecimal(iemployeeHours);

    return capacityReq;
}

private
CapacityReq addCapacityReqSummarize(CapacityPart capacityPart, string stype,int reqId,decimal dhours,int itotEmployees,int iemployeeHours){
    CapacityReq capacityReq = capacityPart.CapacityReqContainer.getByReqId(stype,reqId);

    if (capacityReq==null){
        capacityReq = new CapacityReq();
        capacityReq.Type = stype;
        capacityReq.ReqID= reqId;
        capacityPart.CapacityReqContainer.Add(capacityReq);
    }
    capacityReq.Hours+= dhours;                
    capacityReq.TotEmployees+= itotEmployees;
    capacityReq.EmployeeHours+= Convert.ToDecimal(iemployeeHours);

    return capacityReq;
}

private
CapacityPartDtl addCapacityPartDtlSummarize(CapacityPart capacityPart,decimal dqty){
   CapacityPartDtl     capacityPartDtl = null; 

   if (capacityPart.IsFamily.Equals("F")){
        ProdFmActPlanDtDataBaseContainer prodFmActPlanDtDataBaseContainer = new ProdFmActPlanDtDataBaseContainer(dataBaseAccess);
		prodFmActPlanDtDataBaseContainer.readByFamilyPart(capacityPart.Part);
				
		for(IEnumerator en = prodFmActPlanDtDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
            ProdFmActPlanDtDataBase prodFmActPlanDtDataBase = (ProdFmActPlanDtDataBase) en.Current;

            capacityPartDtl = capacityPart.CapacityPartDtlContainer.getByPart(prodFmActPlanDtDataBase.getPFPD_ProdID());
            if (capacityPartDtl==null){
                capacityPartDtl = new CapacityPartDtl();
                capacityPartDtl.Part = prodFmActPlanDtDataBase.getPFPD_ProdID();//child part
                capacityPartDtl.Seq = prodFmActPlanDtDataBase.getPFPD_Seq();
                capacityPart.CapacityPartDtlContainer.Add(capacityPartDtl);
            }
            capacityPartDtl.Qty+= (dqty * prodFmActPlanDtDataBase.getPFPD_Qty()); //summarize qty
        }				                      
    }

    return capacityPartDtl;
}

/******************************************* CapacityPart ****************************************/

public
CapacityPart createCapacityPart(){
	return new CapacityPart();
}

public
CapacityPartContainer createCapacityPartContainer(){
	return new CapacityPartContainer();
}

private
CapacityPart objectDataBaseToObject(CapacityPartDataBase capacityPartDataBase){
	CapacityPart capacityPart = new CapacityPart();

	capacityPart.HdrId=capacityPartDataBase.getHdrId();
	capacityPart.Detail=capacityPartDataBase.getDetail();
	capacityPart.HotListID=capacityPartDataBase.getHotListID();
	capacityPart.Part=capacityPartDataBase.getPart();
	capacityPart.IsFamily=capacityPartDataBase.getIsFamily();
	capacityPart.Seq=capacityPartDataBase.getSeq();
	capacityPart.Qty=capacityPartDataBase.getQty();
	capacityPart.StartDate=capacityPartDataBase.getStartDate();
	capacityPart.EndDate=capacityPartDataBase.getEndDate();
    capacityPart.Plant = capacityPartDataBase.getPlant();
    capacityPart.Dept = capacityPartDataBase.getDept();
    capacityPart.QtyPlanned = capacityPartDataBase.getQtyPlanned();

    return capacityPart;
}

private
CapacityPartDataBase objectToObjectDataBase(CapacityPart capacityPart){
	CapacityPartDataBase capacityPartDataBase = new CapacityPartDataBase(dataBaseAccess);
	capacityPartDataBase.setHdrId(capacityPart.HdrId);
	capacityPartDataBase.setDetail(capacityPart.Detail);
	capacityPartDataBase.setHotListID(capacityPart.HotListID);
	capacityPartDataBase.setPart(capacityPart.Part);
	capacityPartDataBase.setIsFamily(capacityPart.IsFamily);
	capacityPartDataBase.setSeq(capacityPart.Seq);
	capacityPartDataBase.setQty(capacityPart.Qty);
	capacityPartDataBase.setStartDate(capacityPart.StartDate);
	capacityPartDataBase.setEndDate(capacityPart.EndDate);
    capacityPartDataBase.setPlant(capacityPart.Plant);
    capacityPartDataBase.setDept(capacityPart.Dept);
    capacityPartDataBase.setQtyPlanned(capacityPart.QtyPlanned);

	return capacityPartDataBase;
}

public
CapacityPart cloneCapacityPart(CapacityPart capacityPart){
	CapacityPart capacityPartClone = new CapacityPart();

    capacityPartClone.copy(capacityPart);	
    return capacityPartClone;
}

public
CapacityPartContainer getCapacityPartContainerByFilters(int ihdrId,string spart,int iseq,string stype,int ireqId,int rows){  
     try{
         CapacityPartContainer           capacityPartContainer = new CapacityPartContainer();
        CapacityPartDataBaseContainer   capacityPartDataBaseContainer = new CapacityPartDataBaseContainer(dataBaseAccess);

        capacityPartDataBaseContainer.readByFilters(ihdrId, spart, iseq, stype, ireqId, rows);

        foreach(CapacityPartDataBase capacityPartDataBase in capacityPartDataBaseContainer)
            capacityPartContainer.Add(objectDataBaseToObject(capacityPartDataBase));

        return capacityPartContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

/******************************************* CapacityPartDtl ****************************************/
public
CapacityPartDtl createCapacityPartDtl(){
	return new CapacityPartDtl();
}

public
CapacityPartDtlContainer createCapacityPartDtlContainer(){
	return new CapacityPartDtlContainer();
}


private
CapacityPartDtl objectDataBaseToObject(CapacityPartDtlDataBase capacityPartDtlDataBase){
	CapacityPartDtl capacityPartDtl = new CapacityPartDtl();

	capacityPartDtl.HdrId=capacityPartDtlDataBase.getHdrId();
	capacityPartDtl.Detail=capacityPartDtlDataBase.getDetail();
	capacityPartDtl.SubDetail=capacityPartDtlDataBase.getSubDetail();
	capacityPartDtl.CPHdrID=capacityPartDtlDataBase.getCPHdrID();
	capacityPartDtl.CPDtlID=capacityPartDtlDataBase.getCPDtlID();
	capacityPartDtl.Part=capacityPartDtlDataBase.getPart();
    capacityPartDtl.Seq = capacityPartDtlDataBase.getSeq();
	capacityPartDtl.Qty=capacityPartDtlDataBase.getQty();

    return capacityPartDtl;
}

private
CapacityPartDtlDataBase objectToObjectDataBase(CapacityPartDtl capacityPartDtl){
	CapacityPartDtlDataBase capacityPartDtlDataBase = new CapacityPartDtlDataBase(dataBaseAccess);
	capacityPartDtlDataBase.setHdrId(capacityPartDtl.HdrId);
	capacityPartDtlDataBase.setDetail(capacityPartDtl.Detail);
	capacityPartDtlDataBase.setSubDetail(capacityPartDtl.SubDetail);
	capacityPartDtlDataBase.setCPHdrID(capacityPartDtl.CPHdrID);
	capacityPartDtlDataBase.setCPDtlID(capacityPartDtl.CPDtlID);
	capacityPartDtlDataBase.setPart(capacityPartDtl.Part);
    capacityPartDtlDataBase.setSeq(capacityPartDtl.Seq);
	capacityPartDtlDataBase.setQty(capacityPartDtl.Qty);

	return capacityPartDtlDataBase;
}

public
CapacityPartDtl cloneCapacityPartDtl(CapacityPartDtl capacityPartDtl){
	CapacityPartDtl capacityPartDtlClone = new CapacityPartDtl();
    capacityPartDtlClone.copy(capacityPartDtl);
	
	return capacityPartDtlClone;
}

/*******************************************      CapacityReq    *************************************************************/
public
CapacityReq createCapacityReq(){
	return new CapacityReq();
}

public
CapacityReqContainer createCapacityReqContainer(){
	return new CapacityReqContainer();
}

private
CapacityReq objectDataBaseToObject(CapacityReqDataBase capacityReqDataBase){
	CapacityReq capacityReq = new CapacityReq();

	capacityReq.HdrId=capacityReqDataBase.getHdrId();
	capacityReq.Detail=capacityReqDataBase.getDetail();
	capacityReq.SubDetail=capacityReqDataBase.getSubDetail();
	capacityReq.Type=capacityReqDataBase.getType();
	capacityReq.ReqID=capacityReqDataBase.getReqID();
	capacityReq.Time=capacityReqDataBase.getTime();
	capacityReq.Hours=capacityReqDataBase.getHours();
    capacityReq.TotEmployees =capacityReqDataBase.getTotEmployees();
    capacityReq.EmployeeHours =capacityReqDataBase.getEmployeeHours();

	return capacityReq;
}

private
CapacityReqDataBase objectToObjectDataBase(CapacityReq capacityReq){
	CapacityReqDataBase capacityReqDataBase = new CapacityReqDataBase(dataBaseAccess);
	capacityReqDataBase.setHdrId(capacityReq.HdrId);
	capacityReqDataBase.setDetail(capacityReq.Detail);
	capacityReqDataBase.setSubDetail(capacityReq.SubDetail);
	capacityReqDataBase.setType(capacityReq.Type);
	capacityReqDataBase.setReqID(capacityReq.ReqID);
	capacityReqDataBase.setTime(capacityReq.Time);
	capacityReqDataBase.setHours(capacityReq.Hours);
    capacityReqDataBase.setTotEmployees(capacityReq.TotEmployees);
    capacityReqDataBase.setEmployeeHours(capacityReq.EmployeeHours);

	return capacityReqDataBase;
}

public
CapacityReq cloneCapacityReq(CapacityReq capacityReq){
	CapacityReq capacityReqClone = new CapacityReq();
    capacityReqClone.copy(capacityReq);
	
	return capacityReqClone;
}

/*******************************************      CapacityView    *************************************************************/
public
CapacityViewContainer processCapacityReport(int icapacityHdrId,string splant,string sdept,string srequirment,string stype,string spart){
    try{
        CapacityViewContainer capacityViewContainer = new CapacityViewContainer();

        CapacityViewDataBaseContainer capacityViewDataBaseContainer = new CapacityViewDataBaseContainer(dataBaseAccess);
        capacityViewDataBaseContainer.readForReport(icapacityHdrId,splant,sdept,srequirment,-1,stype,spart,DateUtil.MinValue,true,CapacityView.SORT_TYPE.DEPT_REQUIRMENT);

        foreach(CapacityViewDataBase capacityViewDataBase in capacityViewDataBaseContainer)
            capacityViewContainer.Add(objectDataBaseToObject(capacityViewDataBase));

	    return capacityViewContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}

}

public
CapacityViewContainer processCapacityReportGroupByReqTypeDept(int icapacityHdrId,string splant,string sdept,string srequirment,int ireqId,string stype,string spart,DateTime dateWeek,CapacityView.SORT_TYPE sortType){
    try{
        CapacityViewContainer capacityViewContainer = new CapacityViewContainer();

        CapacityViewDataBaseContainer capacityViewDataBaseContainer = new CapacityViewDataBaseContainer(dataBaseAccess);
        capacityViewDataBaseContainer.readForReport(icapacityHdrId,splant,sdept,srequirment, ireqId,stype, spart, dateWeek,false, sortType);

        foreach(CapacityViewDataBase capacityViewDataBase in capacityViewDataBaseContainer)
            capacityViewContainer.Add(objectDataBaseToObject(capacityViewDataBase));

	    return capacityViewContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}

}

public
CapacityViewContainer readCapacityViewPartByFilters(int icapacityHdrId,string splant,string sdept,string srequirment,string stype, MachineContainer machineContainer, DateTime startDate,DateTime endDate){
    CapacityViewContainer       capacityViewContainer = new CapacityViewContainer();
    try{                                            
        CapacityViewPartDataBaseContainer capacityViewPartDataBaseContainer = new CapacityViewPartDataBaseContainer(dataBaseAccess);
        capacityViewPartDataBaseContainer.readForPart(icapacityHdrId,splant,sdept,srequirment,stype, machineContainer, startDate,endDate,false,CapacityView.SORT_TYPE.REQUIRMENT);
               
        foreach(CapacityViewPartDataBase capacityViewPartDataBase in capacityViewPartDataBaseContainer)
            capacityViewContainer.Add(objectDataBaseToObject(capacityViewPartDataBase));

           return capacityViewContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
void addFamilyChildParts(SchedulePart schedulePart){          
    ProdFmActPlanDtDataBaseContainer prodFmActPlanDtDataBaseContainer = new ProdFmActPlanDtDataBaseContainer(dataBaseAccess);
	prodFmActPlanDtDataBaseContainer.readByFamily(schedulePart.Part);
    	
	for(IEnumerator en = prodFmActPlanDtDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		ProdFmActPlanDtDataBase prodFmActPlanDtDataBase = (ProdFmActPlanDtDataBase) en.Current;

        SchedulePartDtl schedulePartDtl = schedulePart.SchedulePartDtlContainer.getByPartSeq(prodFmActPlanDtDataBase.getPFPD_ProdID(), prodFmActPlanDtDataBase.getPFPD_FamSeq());
        if (schedulePartDtl==null){ 
            schedulePartDtl = new SchedulePartDtl();        
            schedulePartDtl.Part = prodFmActPlanDtDataBase.getPFPD_ProdID();
            schedulePartDtl.Seq = prodFmActPlanDtDataBase.getPFPD_FamSeq();		
            schedulePartDtl.Qty = prodFmActPlanDtDataBase.getPFPD_Qty();
            schedulePart.SchedulePartDtlContainer.Add(schedulePartDtl);
        }		
	}	                                
}

public
CapacityView createCapacityView(){
	return new CapacityView();
}

public
CapacityViewContainer createCapacityViewContainer(){
	return new CapacityViewContainer();
}

private
CapacityView objectDataBaseToObject(CapacityViewDataBase capacityViewDataBase){
	CapacityView capacityView = new CapacityView();

    copyObjectDataBaseToObject(capacityView, capacityViewDataBase);        
	
	return capacityView;
}

private
void copyObjectDataBaseToObject(CapacityView capacityView,CapacityViewDataBase capacityViewDataBase){
    capacityView.Plant=capacityViewDataBase.getPlant();
	capacityView.Dept=capacityViewDataBase.getDept();
    capacityView.ReqId = capacityViewDataBase.getReqId();
	capacityView.ReqType=capacityViewDataBase.getReqType();
	capacityView.Machine=capacityViewDataBase.getMachine();
	capacityView.Labour=capacityViewDataBase.getLabour();
	capacityView.Tool=capacityViewDataBase.getTool();
	capacityView.Title=capacityViewDataBase.getTitle();
	capacityView.Hours=capacityViewDataBase.getHours();
	capacityView.SDate=capacityViewDataBase.getSDate();
    capacityView.DirectHoursToShifts = capacityViewDataBase.getDirectHoursToShifts();

}


private
CapacityViewDataBase objectToObjectDataBase(CapacityView capacityView){
	CapacityViewDataBase capacityViewDataBase = new CapacityViewDataBase(dataBaseAccess);
	capacityViewDataBase.setPlant(capacityView.Plant);
	capacityViewDataBase.setDept(capacityView.Dept);
    capacityViewDataBase.setReqId(capacityView.ReqId);
	capacityViewDataBase.setReqType(capacityView.ReqType);
	capacityViewDataBase.setMachine(capacityView.Machine);
	capacityViewDataBase.setLabour(capacityView.Labour);
	capacityViewDataBase.setTool(capacityView.Tool);
	capacityViewDataBase.setTitle(capacityView.Title);
	capacityViewDataBase.setHours(capacityView.Hours);
	capacityViewDataBase.setSDate(capacityView.SDate);
    capacityViewDataBase.setDirectHoursToShifts(capacityView.DirectHoursToShifts);

	return capacityViewDataBase;
}

public
CapacityView cloneCapacityView(CapacityView capacityView){
	CapacityView capacityViewClone = new CapacityView();

    capacityViewClone.copy(capacityView);            	
	return capacityViewClone;
}

public
CapacityViewPart createCapacityViewPart(){
	return new CapacityViewPart();
}

public
CapacityViewPart objectDataBaseToObject(CapacityViewPartDataBase capacityViewPartDataBase){
	CapacityViewPart capacityViewPart = new CapacityViewPart();

    copyObjectDataBaseToObject(capacityViewPart, capacityViewPartDataBase);            
	capacityViewPart.Part= capacityViewPartDataBase.getPart();
	capacityViewPart.Seq= capacityViewPartDataBase.getSeq();
    capacityViewPart.Qty = capacityViewPartDataBase.getQty();

	return capacityViewPart;
}

/******************************************* CapacityShiftProfile ***********************************************/
public
CapShiftProfile createCapShiftProfile(){
	return new CapShiftProfile();
}

public
CapShiftProfileContainer createCapShiftProfileContainer(){
	return new CapShiftProfileContainer();
}

public
CapShiftProfileView createCapShiftProfileView(){
	return new CapShiftProfileView();
}

public
bool existsCapShiftProfile(int id){
	try{
		CapShiftProfileDataBase capShiftProfileDataBase = new CapShiftProfileDataBase(dataBaseAccess);

		capShiftProfileDataBase.setId(id);

		return capShiftProfileDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
CapShiftProfile readCapShiftProfile(int id){
	try{
		CapShiftProfileDataBase capShiftProfileDataBase = new CapShiftProfileDataBase(dataBaseAccess);
		capShiftProfileDataBase.setId(id);

		if (!capShiftProfileDataBase.read())
			return null;

		CapShiftProfile capShiftProfile = this.objectDataBaseToObject(capShiftProfileDataBase);
        loadCapShiftProfileChilds(capShiftProfile);

		return capShiftProfile;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
CapShiftProfile readCapShiftProfileLast(string splant){
	try{
		CapShiftProfileDataBase capShiftProfileDataBase = new CapShiftProfileDataBase(dataBaseAccess);		
		if (!capShiftProfileDataBase.readLastByFilter(splant))
			return null;

		CapShiftProfile capShiftProfile = this.objectDataBaseToObject(capShiftProfileDataBase);
       loadCapShiftProfileChilds(capShiftProfile);

		return capShiftProfile;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateCapShiftProfile(CapShiftProfile capShiftProfile){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CapShiftProfileDataBase capShiftProfileDataBase = this.objectToObjectDataBase(capShiftProfile);
		capShiftProfileDataBase.update();

        deleteCapShiftProfileChilds(capShiftProfile.Id);
        writeCapShiftProfileChilds(capShiftProfile);

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
void writeCapShiftProfile(CapShiftProfile capShiftProfile){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CapShiftProfileDataBase capShiftProfileDataBase = this.objectToObjectDataBase(capShiftProfile);
		capShiftProfileDataBase.write();
        capShiftProfile.Id = capShiftProfileDataBase.getId();
        
        writeCapShiftProfileChilds(capShiftProfile);

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
void loadCapShiftProfileChilds(CapShiftProfile capShiftProfile){
    Hashtable                           hashMachPlan= new Hashtable();
    
    CapShiftProfileDtlDataBaseContainer capShiftProfileDtlDataBaseContainer = new CapShiftProfileDtlDataBaseContainer(dataBaseAccess);
    capShiftProfileDtlDataBaseContainer.readByHdr(capShiftProfile.Id);  

    foreach (CapShiftProfileDtlDataBase capShiftProfileDtlDataBase in capShiftProfileDtlDataBaseContainer){
        capShiftProfile.CapShiftProfileDtlContainer.Add( this.objectDataBaseToObject(capShiftProfileDtlDataBase));        
    }

    CapShiftProfileMachPlanDataBaseContainer capShiftProfileMachPlanDataBaseContainer = new CapShiftProfileMachPlanDataBaseContainer(dataBaseAccess);
    capShiftProfileMachPlanDataBaseContainer.readByHdr(capShiftProfile.Id);  
    foreach (CapShiftProfileMachPlanDataBase capShiftProfileMachPlanDataBase in capShiftProfileMachPlanDataBaseContainer){

        CapShiftProfileMachPlan capShiftProfileMachPlan = this.objectDataBaseToObject(capShiftProfileMachPlanDataBase);
        capShiftProfile.CapShiftProfileMachPlanContainer.Add(capShiftProfileMachPlan);        

        capShiftProfileMachPlan.ShiftNumShow= capShiftProfile.ShiftNum;
        PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);        
        if (pltDeptMachDataBase.readById(capShiftProfileMachPlan.MachId)) { 
            capShiftProfileMachPlan.MachShow = pltDeptMachDataBase.getPDM_Mach();
            capShiftProfileMachPlan.MachNameShow= pltDeptMachDataBase.getPDM_Des1();
        }
        
        if (!hashMachPlan.Contains(capShiftProfileMachPlan.Detail))
            hashMachPlan.Add(capShiftProfileMachPlan.Detail, capShiftProfileMachPlan);
    }

    //mach plan employee   
    CapShiftProfileMachPlanEmployee                     capShiftProfileMachPlanEmployee = null;
    CapShiftProfileMachPlanEmployeeDataBaseContainer    capShiftProfileMachPlanEmployeeDataBaseContainer = new CapShiftProfileMachPlanEmployeeDataBaseContainer(dataBaseAccess);
    capShiftProfileMachPlanEmployeeDataBaseContainer.readByHdrAll(capShiftProfile.Id);
    foreach(CapShiftProfileMachPlanEmployeeDataBase capShiftProfileMachPlanEmployeeDataBase in capShiftProfileMachPlanEmployeeDataBaseContainer){
        capShiftProfileMachPlanEmployee = objectDataBaseToObject(capShiftProfileMachPlanEmployeeDataBase);
        
        if (hashMachPlan.Contains(capShiftProfileMachPlanEmployee.Detail)) {
            CapShiftProfileMachPlan capShiftProfileMachPlan = (CapShiftProfileMachPlan)hashMachPlan[capShiftProfileMachPlanEmployee.Detail];            
            capShiftProfileMachPlan.CapShiftProfileMachPlanEmployeeContainer.Add(capShiftProfileMachPlanEmployee);
        }        
    }

}

private
void writeCapShiftProfileChilds(CapShiftProfile capShiftProfile){
    ArrayList arrayListMachPlanDetails = new ArrayList();
    capShiftProfile.fillRedundances();    

    if (capShiftProfile.ShiftDefault.Equals(Constants.STRING_YES)){
        CapShiftProfileDataBaseContainer capShiftProfileDataBaseContainer = new CapShiftProfileDataBaseContainer(dataBaseAccess);
        capShiftProfileDataBaseContainer.updateDefaults(capShiftProfile.Plant,capShiftProfile.Id,capShiftProfile.ShiftNum,Constants.STRING_NO);
    }

    //System.Windows.Forms.MessageBox.Show("writeCapShiftProfileChilds count " + capShiftProfile.CapShiftProfileDtlContainer.Count);
    foreach (CapShiftProfileDtl capShiftProfileDtl in capShiftProfile.CapShiftProfileDtlContainer){        
        CapShiftProfileDtlDataBase capShiftProfileDtlDataBase = this.objectToObjectDataBase(capShiftProfileDtl);
        capShiftProfileDtlDataBase.write();               
    }

    foreach (CapShiftProfileMachPlan capShiftProfileMachPlan in capShiftProfile.CapShiftProfileMachPlanContainer){        
        CapShiftProfileMachPlanDataBase capShiftProfileMachPlanDataBase = this.objectToObjectDataBase(capShiftProfileMachPlan);
        capShiftProfileMachPlanDataBase.write();       
                
        arrayListMachPlanDetails.Add(capShiftProfileMachPlan.Detail);                        

        foreach (CapShiftProfileMachPlanEmployee capShiftProfileMachPlanEmployee in capShiftProfileMachPlan.CapShiftProfileMachPlanEmployeeContainer){        
            CapShiftProfileMachPlanEmployeeDataBase capShiftProfileMachPlanEmployeeDataBase = this.objectToObjectDataBase(capShiftProfileMachPlanEmployee);
            capShiftProfileMachPlanEmployeeDataBase.write(); 
        }
    }

    //update Planned Part which were removed
    PlannedPartDataBaseContainer plannedPartDataBaseContainer = new PlannedPartDataBaseContainer(dataBaseAccess);
    plannedPartDataBaseContainer.updateShifProfileRemoved(capShiftProfile.Id,arrayListMachPlanDetails);
}

public 
void deleteCapShiftProfileChilds(int id){
    CapShiftProfileDtlDataBaseContainer capShiftProfileDtlDataBaseContainer = new CapShiftProfileDtlDataBaseContainer(dataBaseAccess);
    capShiftProfileDtlDataBaseContainer.deleteByHdr(id);    

    CapShiftProfileMachPlanDataBaseContainer capShiftProfileMachPlanDataBaseContainer = new CapShiftProfileMachPlanDataBaseContainer(dataBaseAccess);
    capShiftProfileMachPlanDataBaseContainer.deleteByHdr(id);   

    CapShiftProfileMachPlanEmployeeDataBaseContainer capShiftProfileMachPlanEmployeeDataBaseContainer = new CapShiftProfileMachPlanEmployeeDataBaseContainer(dataBaseAccess);
    capShiftProfileMachPlanEmployeeDataBaseContainer.deleteByHdr(id);   
}

public
void deleteCapShiftProfile(int id){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        //update Planned Part which were removed
        PlannedPartDataBaseContainer plannedPartDataBaseContainer = new PlannedPartDataBaseContainer(dataBaseAccess);
        plannedPartDataBaseContainer.updateShifProfileRemoved(id,new ArrayList()); 

        deleteCapShiftProfileChilds(id);        
		CapShiftProfileDataBase capShiftProfileDataBase = new CapShiftProfileDataBase(dataBaseAccess);

		capShiftProfileDataBase.setId(id);
		capShiftProfileDataBase.delete();

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
CapShiftProfileContainer readCapShiftProfileByFilters(string sid,string splant,int ishiftNum,string status,DateTime dstartDate,DateTime sendDate, int ishiftTaskId,string shiftDefault,bool bonlyHeader,int rows){
	try{
        CapShiftProfileContainer capShiftProfileContainer = new CapShiftProfileContainer();

        CapShiftProfileDataBaseContainer capShiftProfileDataBaseContainer = new CapShiftProfileDataBaseContainer(dataBaseAccess);
		capShiftProfileDataBaseContainer.readByFilters(sid,splant,ishiftNum, status, dstartDate, sendDate, ishiftTaskId, shiftDefault,rows);	
        
        foreach(CapShiftProfileDataBase capShiftProfileDataBase in capShiftProfileDataBaseContainer){
            CapShiftProfile capShiftProfile =objectDataBaseToObject(capShiftProfileDataBase);            

            if (!bonlyHeader)
                loadCapShiftProfileChilds(capShiftProfile);
            capShiftProfileContainer.Add(capShiftProfile);
        }

		return capShiftProfileContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
CapShiftProfileContainer readCapShiftProfileByExactlyDatesFilters(string splant,int ishiftNum,string status,DateTime dateTime,bool bonlyHeader,int rows){
	try{
        CapShiftProfileContainer    capShiftProfileContainer = new CapShiftProfileContainer();        
        DateTime                    priorMonday = dateTime;
        DateTime                    nextSunday = dateTime;

        for (int i=0; i <= rows; i++,priorMonday = priorMonday.AddDays(7)){                    

            DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday,out nextSunday);                                        
            CapShiftProfileDataBaseContainer capShiftProfileDataBaseContainer = new CapShiftProfileDataBaseContainer(dataBaseAccess);
		    capShiftProfileDataBaseContainer.readByFiltersExactlyDates(splant,ishiftNum, status, priorMonday, nextSunday);

            if (capShiftProfileDataBaseContainer.Count > 0){
                CapShiftProfile capShiftProfile = objectDataBaseToObject((CapShiftProfileDataBase)capShiftProfileDataBaseContainer[0]);
                if (!bonlyHeader)
                    loadCapShiftProfileChilds(capShiftProfile);
                capShiftProfileContainer.Add(capShiftProfile);
             }                             
        }       

		return capShiftProfileContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
CapShiftProfileContainer readCapShiftProfilesForWeek(string splant,string status,DateTime dateTime,bool bonlyHeader){
	try{
        CapShiftProfileContainer    capShiftProfileContainer = new CapShiftProfileContainer();        
        DateTime                    priorMonday = dateTime;
        DateTime                    nextSunday  = dateTime;
        int                         imaxShift   = 5;

        DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday,out nextSunday);

        for (int i=1; i <= imaxShift;i++){                    
            
            CapShiftProfileDataBaseContainer capShiftProfileDataBaseContainer = new CapShiftProfileDataBaseContainer(dataBaseAccess);
		    capShiftProfileDataBaseContainer.readByFiltersExactlyDates(splant,i,status,priorMonday,nextSunday);

            if (capShiftProfileDataBaseContainer.Count > 0){
                CapShiftProfile capShiftProfile = objectDataBaseToObject((CapShiftProfileDataBase)capShiftProfileDataBaseContainer[0]);
                if (!bonlyHeader)
                    loadCapShiftProfileChilds(capShiftProfile);
                capShiftProfileContainer.Add(capShiftProfile);
             }                             
        }       

		return capShiftProfileContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
Hashtable readCapShiftProfilesForWeekHash(string splant,string status,DateTime fromDate,DateTime toDate,int imachineId,bool bonlyHeader){
	try{
        Hashtable                           hashProfilesByDates = new Hashtable();
        CapShiftProfileContainer            capShiftProfileContainer = new CapShiftProfileContainer();        
        CapShiftProfile                     capShiftProfile = null;
        CapShiftProfile                     capShiftProfileAux = null;
        DateTime                            priorMonday = fromDate;
        DateTime                            nextSunday  = fromDate;        
        CapShiftProfileContainer            capShiftProfileContainerDefaults= new CapShiftProfileContainer();
        Hashtable                           hashProfiles = new Hashtable();
        string                              sprofileIdList ="";

        //read cap shift profile defaults
        CapShiftProfileDataBaseContainer    capShiftProfileDataBaseContainerDefaults = new CapShiftProfileDataBaseContainer(dataBaseAccess);
        capShiftProfileDataBaseContainerDefaults.readByFilters("",splant,0,"",DateUtil.MinValue, DateUtil.MinValue,0,Constants.STRING_YES,0);
        
        foreach (CapShiftProfileDataBase capShiftProfileDataBase in capShiftProfileDataBaseContainerDefaults){
            capShiftProfile = objectDataBaseToObject(capShiftProfileDataBase);
            if (capShiftProfile.ShiftNum <= 3 &&                                                  // 
                capShiftProfileContainerDefaults.getByShiftNum(capShiftProfile.ShiftNum) == null) //might not happens but we do not repeat shift ir already added
                capShiftProfileContainerDefaults.Add(capShiftProfile);
        }
        capShiftProfileContainerDefaults.sortByShiftNum();

        DateUtil.getPriorMondayNextSundayFromDate(fromDate, out priorMonday,out nextSunday);
        for (;priorMonday <= toDate; priorMonday = priorMonday.AddDays(7), DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday)){
                                   
            if (!hashProfilesByDates.Contains(priorMonday)){
                capShiftProfileContainer = new CapShiftProfileContainer(); 
                for (int i=0;i < capShiftProfileContainerDefaults.Count;i++) //copy cap shift profiles per week
                    capShiftProfileContainer.Add(capShiftProfileContainerDefaults[i]);

                hashProfilesByDates.Add(priorMonday,capShiftProfileContainer);
            }                        
        };

        //read all cap shift profile by range date
        DateUtil.getPriorMondayNextSundayFromDate(fromDate, out priorMonday,out nextSunday);
        CapShiftProfileDataBaseContainer    capShiftProfileDataBaseContainer = new CapShiftProfileDataBaseContainer(dataBaseAccess);
        capShiftProfileDataBaseContainer.readByFilters("",splant,0,Constants.STATUS_ACTIVE, priorMonday, toDate,0,"",0);
        foreach (CapShiftProfileDataBase capShiftProfileDataBase in capShiftProfileDataBaseContainer){
            capShiftProfile = objectDataBaseToObject(capShiftProfileDataBase);        
                
            if (hashProfilesByDates.Contains(capShiftProfile.StartDate)){
                capShiftProfileContainer = (CapShiftProfileContainer)hashProfilesByDates[capShiftProfile.StartDate];
                
                capShiftProfileAux = capShiftProfileContainer.getByShiftNum(capShiftProfile.ShiftNum);
                if (capShiftProfileAux!= null)
                    capShiftProfileContainer.Remove(capShiftProfileAux);

                capShiftProfileContainer.Add(capShiftProfile);
                capShiftProfileContainer.sortByShiftNum();                

                if (!hashProfiles.Contains(capShiftProfile.Id)){
                   hashProfiles.Add(capShiftProfile.Id,capShiftProfile);
                   sprofileIdList+= (string.IsNullOrEmpty(sprofileIdList) ? "" : ",") + capShiftProfile.Id.ToString();
                }
            }
        }

        //to do it faster, we read  CapShiftProfileMachPlan for profilelist, then we add it to appropiate capshift object
        if (!string.IsNullOrEmpty(sprofileIdList) && imachineId > 0 ){
            CapShiftProfileMachPlanDataBaseContainer capShiftProfileMachPlanDataBaseContainer = new CapShiftProfileMachPlanDataBaseContainer(dataBaseAccess);
            capShiftProfileMachPlanDataBaseContainer.readByHdrsMachine(sprofileIdList,imachineId);

            foreach (CapShiftProfileMachPlanDataBase capShiftProfileMachPlanDataBase in capShiftProfileMachPlanDataBaseContainer){
                CapShiftProfileMachPlan capShiftProfileMachPlan = objectDataBaseToObject(capShiftProfileMachPlanDataBase);
                if (hashProfiles.Contains(capShiftProfileMachPlan.HdrId)){
                    capShiftProfile = (CapShiftProfile)hashProfiles[capShiftProfileMachPlan.HdrId];
                    capShiftProfile.CapShiftProfileMachPlanContainer.Add(capShiftProfileMachPlan);
                }
            }
        }

        return hashProfilesByDates;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}


private
CapShiftProfile objectDataBaseToObject(CapShiftProfileDataBase capShiftProfileDataBase){
	CapShiftProfile capShiftProfile = new CapShiftProfile();

	capShiftProfile.Id=capShiftProfileDataBase.getId();
	capShiftProfile.ShiftNum=capShiftProfileDataBase.getShiftNum();
	capShiftProfile.Status=capShiftProfileDataBase.getStatus();
	capShiftProfile.StartDate=capShiftProfileDataBase.getStartDate();
	capShiftProfile.EndDate=capShiftProfileDataBase.getEndDate();
    capShiftProfile.Plant = capShiftProfileDataBase.getPlant();
    capShiftProfile.ShiftStart = capShiftProfileDataBase.getShiftStart();
    capShiftProfile.ShiftEnd= capShiftProfileDataBase.getShiftEnd();

    capShiftProfile.MonWork = capShiftProfileDataBase.getMonWork();
    capShiftProfile.TueWork = capShiftProfileDataBase.getTueWork();
    capShiftProfile.WedWork = capShiftProfileDataBase.getWedWork();
    capShiftProfile.ThuWork = capShiftProfileDataBase.getThuWork();
    capShiftProfile.FriWork = capShiftProfileDataBase.getFriWork();
    capShiftProfile.SatWork = capShiftProfileDataBase.getSatWork();
    capShiftProfile.SunWork = capShiftProfileDataBase.getSunWork();
    capShiftProfile.ShiftDefault = capShiftProfileDataBase.getShiftDefault();
    capShiftProfile.ShiftType = capShiftProfileDataBase.getShiftType();
    capShiftProfile.ShiftNumId = capShiftProfileDataBase.getShiftNumId();
            
    return capShiftProfile;
}

private
CapShiftProfileDataBase objectToObjectDataBase(CapShiftProfile capShiftProfile){
	CapShiftProfileDataBase capShiftProfileDataBase = new CapShiftProfileDataBase(dataBaseAccess);
	capShiftProfileDataBase.setId(capShiftProfile.Id);
	capShiftProfileDataBase.setShiftNum(capShiftProfile.ShiftNum);
	capShiftProfileDataBase.setStatus(capShiftProfile.Status);
	capShiftProfileDataBase.setStartDate(capShiftProfile.StartDate);
	capShiftProfileDataBase.setEndDate(capShiftProfile.EndDate);
    capShiftProfileDataBase.setPlant(capShiftProfile.Plant);
    capShiftProfileDataBase.setShiftStart(capShiftProfile.ShiftStart);
    capShiftProfileDataBase.setShiftEnd(capShiftProfile.ShiftEnd);

    capShiftProfileDataBase.setMonWork(capShiftProfile.MonWork);
    capShiftProfileDataBase.setTueWork(capShiftProfile.TueWork);
    capShiftProfileDataBase.setWedWork(capShiftProfile.WedWork);
    capShiftProfileDataBase.setThuWork(capShiftProfile.ThuWork);
    capShiftProfileDataBase.setFriWork(capShiftProfile.FriWork);
    capShiftProfileDataBase.setSatWork(capShiftProfile.SatWork);
    capShiftProfileDataBase.setSunWork(capShiftProfile.SunWork);
    capShiftProfileDataBase.setShiftDefault(capShiftProfile.ShiftDefault);
    capShiftProfileDataBase.setShiftType(capShiftProfile.ShiftType);
    capShiftProfileDataBase.setShiftNumId(capShiftProfile.ShiftNumId);

	return capShiftProfileDataBase;
}

public
CapShiftProfile cloneCapShiftProfile(CapShiftProfile capShiftProfile){
	CapShiftProfile capShiftProfileClone = new CapShiftProfile();

	capShiftProfileClone.Id=capShiftProfile.Id;
	capShiftProfileClone.ShiftNum=capShiftProfile.ShiftNum;
	capShiftProfileClone.Status=capShiftProfile.Status;
	capShiftProfileClone.StartDate=capShiftProfile.StartDate;
	capShiftProfileClone.EndDate=capShiftProfile.EndDate;
    capShiftProfileClone.Plant = capShiftProfile.Plant;
    capShiftProfileClone.ShiftStart = capShiftProfile.ShiftStart;
    capShiftProfileClone.ShiftEnd = capShiftProfile.ShiftEnd;

    capShiftProfileClone.MonWork=capShiftProfile.MonWork;
    capShiftProfileClone.TueWork=capShiftProfile.TueWork;
    capShiftProfileClone.WedWork=capShiftProfile.WedWork;
    capShiftProfileClone.ThuWork=capShiftProfile.ThuWork;
    capShiftProfileClone.FriWork=capShiftProfile.FriWork;
    capShiftProfileClone.SatWork=capShiftProfile.SatWork;
    capShiftProfileClone.SunWork=capShiftProfile.SunWork;
    capShiftProfileClone.ShiftDefault = capShiftProfile.ShiftDefault;
    capShiftProfileClone.ShiftType = capShiftProfile.ShiftType;
    capShiftProfileClone.ShiftNumId= capShiftProfile.ShiftNumId;

    foreach (CapShiftProfileDtl capShiftProfileDtl in capShiftProfile.CapShiftProfileDtlContainer)
        capShiftProfileClone.CapShiftProfileDtlContainer.Add(cloneCapShiftProfileDtl(capShiftProfileDtl));

	return capShiftProfileClone;
}

public
CapShiftProfileView cloneCapShiftProfileView(CapShiftProfile capShiftProfile){
	CapShiftProfileView capShiftProfileViewClone = new CapShiftProfileView(capShiftProfile);

    if (capShiftProfile is CapShiftProfileView){
        CapShiftProfileView capShiftProfileView = (CapShiftProfileView) capShiftProfile;
        capShiftProfileViewClone.TotDirectPeopleView = capShiftProfileView.TotDirectPeopleView;
        capShiftProfileViewClone.TotIndirectPeopleView = capShiftProfileView.TotIndirectPeopleView;
        capShiftProfileViewClone.TotAvailableDirectHoursView = capShiftProfileView.TotAvailableDirectHoursView;
    }

    foreach (CapShiftProfileDtl capShiftProfileDtl in capShiftProfile.CapShiftProfileDtlContainer)
        capShiftProfileViewClone.CapShiftProfileDtlContainer.Add(cloneCapShiftProfileDtl(capShiftProfileDtl));

	return capShiftProfileViewClone;
}

public
CapShiftProfileDtl createCapShiftProfileDtl(){
	return new CapShiftProfileDtl();
}

public
CapShiftProfileDtlContainer createCapShiftProfileDtlContainer(){
	return new CapShiftProfileDtlContainer();
}

public
CapShiftProfileDtlView createCapShiftProfileDtlView(CapShiftProfileDtl capShiftProfileDtl){
	return new CapShiftProfileDtlView(capShiftProfileDtl);
}
 

private
CapShiftProfileDtl objectDataBaseToObject(CapShiftProfileDtlDataBase capShiftProfileDtlDataBase){
	CapShiftProfileDtl capShiftProfileDtl = new CapShiftProfileDtl();

	capShiftProfileDtl.HdrId=capShiftProfileDtlDataBase.getHdrId();
	capShiftProfileDtl.Detail=capShiftProfileDtlDataBase.getDetail();
	capShiftProfileDtl.ShiftTaskId=capShiftProfileDtlDataBase.getShiftTaskId();
	capShiftProfileDtl.NumPeople=capShiftProfileDtlDataBase.getNumPeople();
	capShiftProfileDtl.NewPeople = capShiftProfileDtlDataBase.getNewPeople();
	capShiftProfileDtl.Hours=capShiftProfileDtlDataBase.getHours();
    capShiftProfileDtl.TaskNameShow = capShiftProfileDtlDataBase.getTaskNameShow();
    capShiftProfileDtl.DirIndShow = capShiftProfileDtlDataBase.getDirIndShow();

	return capShiftProfileDtl;
}

private
CapShiftProfileDtlDataBase objectToObjectDataBase(CapShiftProfileDtl capShiftProfileDtl){
	CapShiftProfileDtlDataBase capShiftProfileDtlDataBase = new CapShiftProfileDtlDataBase(dataBaseAccess);
	capShiftProfileDtlDataBase.setHdrId(capShiftProfileDtl.HdrId);
	capShiftProfileDtlDataBase.setDetail(capShiftProfileDtl.Detail);
	capShiftProfileDtlDataBase.setShiftTaskId(capShiftProfileDtl.ShiftTaskId);
	capShiftProfileDtlDataBase.setNumPeople(capShiftProfileDtl.NumPeople);
	capShiftProfileDtlDataBase.setNewPeople(capShiftProfileDtl.NewPeople);
	capShiftProfileDtlDataBase.setHours(capShiftProfileDtl.Hours);

	return capShiftProfileDtlDataBase;
}

public
CapShiftProfileDtl cloneCapShiftProfileDtl(CapShiftProfileDtl capShiftProfileDtl){
	CapShiftProfileDtl capShiftProfileDtlClone = new CapShiftProfileDtl();
    
    capShiftProfileDtlClone.copy(capShiftProfileDtl);	
	return capShiftProfileDtlClone;
}

/*******************************************     CapShiftTask       ************************************************/
public
CapShiftTask createCapShiftTask(){
	return new CapShiftTask();
}

public
CapShiftTaskContainer createCapShiftTaskContainer(){
	return new CapShiftTaskContainer();
}

public
bool existsCapShiftTask(int id){
	try{
		CapShiftTaskDataBase capShiftTaskDataBase = new CapShiftTaskDataBase(dataBaseAccess);

		capShiftTaskDataBase.setId(id);

		return capShiftTaskDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
CapShiftTask readCapShiftTask(int id){
	try{
		CapShiftTaskDataBase capShiftTaskDataBase = new CapShiftTaskDataBase(dataBaseAccess);
		capShiftTaskDataBase.setId(id);

		if (!capShiftTaskDataBase.read())
			return null;

		CapShiftTask capShiftTask = this.objectDataBaseToObject(capShiftTaskDataBase);

		return capShiftTask;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
CapShiftTaskContainer readCapShiftTaskByFilters(string sid, string staskName,string sdirInd,int rows){
	try{
        CapShiftTaskContainer capShiftTaskContainer = new CapShiftTaskContainer();

        CapShiftTaskDataBaseContainer capShiftTaskDataBaseContainer = new CapShiftTaskDataBaseContainer(dataBaseAccess);
		capShiftTaskDataBaseContainer.readByFilters(sid,staskName, sdirInd, rows);	
        
        foreach(CapShiftTaskDataBase capShiftTaskDataBase in capShiftTaskDataBaseContainer){
            capShiftTaskContainer.Add(objectDataBaseToObject(capShiftTaskDataBase));            
        }

		return capShiftTaskContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateCapShiftTask(CapShiftTask capShiftTask){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CapShiftTaskDataBase capShiftTaskDataBase = this.objectToObjectDataBase(capShiftTask);
		capShiftTaskDataBase.update();

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
void writeCapShiftTask(CapShiftTask capShiftTask){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CapShiftTaskDataBase capShiftTaskDataBase = this.objectToObjectDataBase(capShiftTask);
		capShiftTaskDataBase.write();
        capShiftTask.Id = capShiftTaskDataBase.getId();

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
void deleteCapShiftTask(int id){
	 try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CapShiftTaskDataBase capShiftTaskDataBase = new CapShiftTaskDataBase(dataBaseAccess);

		capShiftTaskDataBase.setId(id);
		capShiftTaskDataBase.delete();

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
CapShiftTask objectDataBaseToObject(CapShiftTaskDataBase capShiftTaskDataBase){
	CapShiftTask capShiftTask = new CapShiftTask();

	capShiftTask.Id=capShiftTaskDataBase.getId();
	capShiftTask.TaskName=capShiftTaskDataBase.getTaskName();
	capShiftTask.DirInd=capShiftTaskDataBase.getDirInd();
    capShiftTask.RatePerHr = capShiftTaskDataBase.getRatePerHr();
    capShiftTask.ManufactProcess = capShiftTaskDataBase.getManufactProcess();
    capShiftTask.EmpTempCanPerform = capShiftTaskDataBase.getEmpTempCanPerform();

    return capShiftTask;
}

private
CapShiftTaskDataBase objectToObjectDataBase(CapShiftTask capShiftTask){
	CapShiftTaskDataBase capShiftTaskDataBase = new CapShiftTaskDataBase(dataBaseAccess);
	capShiftTaskDataBase.setId(capShiftTask.Id);
	capShiftTaskDataBase.setTaskName(capShiftTask.TaskName);
	capShiftTaskDataBase.setDirInd(capShiftTask.DirInd);
    capShiftTaskDataBase.setRatePerHr(capShiftTask.RatePerHr);
    capShiftTaskDataBase.setManufactProcess(capShiftTask.ManufactProcess);
    capShiftTaskDataBase.setEmpTempCanPerform(capShiftTask.EmpTempCanPerform);

	return capShiftTaskDataBase;
}

public
CapShiftTask cloneCapShiftTask(CapShiftTask capShiftTask){
	CapShiftTask capShiftTaskClone = new CapShiftTask();

	capShiftTaskClone.Id=capShiftTask.Id;
	capShiftTaskClone.TaskName=capShiftTask.TaskName;
	capShiftTaskClone.DirInd=capShiftTask.DirInd;
    capShiftTaskClone.RatePerHr = capShiftTask.RatePerHr;
    capShiftTaskClone.ManufactProcess= capShiftTask.ManufactProcess;
    capShiftTaskClone.EmpTempCanPerform = capShiftTask.EmpTempCanPerform;

	return capShiftTaskClone;
}

/******************************************* CapProfileHoliday ********************************************************************/
public
CapProfileHoliday createCapProfileHoliday(){
	return new CapProfileHoliday();
}

public
CapProfileHolidayContainer createCapProfileHolidayContainer(){
	return new CapProfileHolidayContainer();
}

public
bool existsCapProfileHoliday(int id){
	try{
		CapProfileHolidayDataBase capProfileHolidayDataBase = new CapProfileHolidayDataBase(dataBaseAccess);

		capProfileHolidayDataBase.setId(id);

		return capProfileHolidayDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
CapProfileHoliday readCapProfileHoliday(int id){
	try{
		CapProfileHolidayDataBase capProfileHolidayDataBase = new CapProfileHolidayDataBase(dataBaseAccess);
		capProfileHolidayDataBase.setId(id);

		if (!capProfileHolidayDataBase.read())
			return null;

		CapProfileHoliday capProfileHoliday = this.objectDataBaseToObject(capProfileHolidayDataBase);

		return capProfileHoliday;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateCapProfileHoliday(CapProfileHoliday capProfileHoliday){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CapProfileHolidayDataBase capProfileHolidayDataBase = this.objectToObjectDataBase(capProfileHoliday);
		capProfileHolidayDataBase.update();

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
void writeCapProfileHoliday(CapProfileHoliday capProfileHoliday){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CapProfileHolidayDataBase capProfileHolidayDataBase = this.objectToObjectDataBase(capProfileHoliday);
		capProfileHolidayDataBase.write();

		capProfileHoliday.Id=capProfileHolidayDataBase.getId();

        applyHolidayForDate(capProfileHoliday,Constants.STRING_NO);

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
void applyHolidayForDate(CapProfileHoliday capProfileHoliday,string swork){
    DateTime                    priorMonday = DateTime.Now;
    DateTime                    nextSunday = DateTime.Now;        
    CapShiftProfileContainer    capShiftProfileContainer = new CapShiftProfileContainer();
    CapShiftProfile             capShiftProfile = null;
    CapShiftProfileDataBase     capShiftProfileDataBase = null;
    DateTime                    startTime   = capProfileHoliday.StartDate;
    DateTime                    endDate     = capProfileHoliday.EndDate;

    for (int idays=0; startTime <= endDate; idays++, startTime= startTime.AddDays(idays)) {     //loop just in case holiday range dates

        startTime = capProfileHoliday.StartDate.AddDays(idays);
        DateUtil.getPriorMondayNextSundayFromDate(startTime,out priorMonday,out nextSunday);

        for (int i=1; i <= 5; i++) { //not more than 5 shifts
            CapShiftProfileContainer capShiftProfileContainerAux = readCapShiftProfileByExactlyDatesFilters(capProfileHoliday.Plant, i,"",priorMonday,false,0);
            if (capShiftProfileContainerAux.Count > 0){
                capShiftProfile = capShiftProfileContainerAux[0];
                    
                capShiftProfile.setDayWork(startTime.DayOfWeek, swork);
                capShiftProfileDataBase = objectToObjectDataBase(capShiftProfile);
                capShiftProfileDataBase.update();
            }
        }
    }
}

public
void deleteCapProfileHoliday(int id){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CapProfileHolidayDataBase capProfileHolidayDataBase = new CapProfileHolidayDataBase(dataBaseAccess);

		capProfileHolidayDataBase.setId(id);
        if (capProfileHolidayDataBase.read())
            applyHolidayForDate(objectDataBaseToObject(capProfileHolidayDataBase),Constants.STRING_YES); //just in case cancel holiday

		capProfileHolidayDataBase.delete();
              
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
CapProfileHoliday objectDataBaseToObject(CapProfileHolidayDataBase capProfileHolidayDataBase){
	CapProfileHoliday capProfileHoliday = new CapProfileHoliday();

	capProfileHoliday.Id=capProfileHolidayDataBase.getId();
    capProfileHoliday.Plant = capProfileHolidayDataBase.getPlant();
	capProfileHoliday.StartDate=capProfileHolidayDataBase.getStartDate();
	capProfileHoliday.EndDate=capProfileHolidayDataBase.getEndDate();
	capProfileHoliday.HolidayType=capProfileHolidayDataBase.getHolidayType();

	return capProfileHoliday;
}

private
CapProfileHolidayDataBase objectToObjectDataBase(CapProfileHoliday capProfileHoliday){
	CapProfileHolidayDataBase capProfileHolidayDataBase = new CapProfileHolidayDataBase(dataBaseAccess);
	capProfileHolidayDataBase.setId(capProfileHoliday.Id);
    capProfileHolidayDataBase.setPlant(capProfileHoliday.Plant);
	capProfileHolidayDataBase.setStartDate(capProfileHoliday.StartDate);
	capProfileHolidayDataBase.setEndDate(capProfileHoliday.EndDate);
	capProfileHolidayDataBase.setHolidayType(capProfileHoliday.HolidayType);

	return capProfileHolidayDataBase;
}

public
CapProfileHoliday cloneCapProfileHoliday(CapProfileHoliday capProfileHoliday){
	CapProfileHoliday capProfileHolidayClone = new CapProfileHoliday();

	capProfileHolidayClone.Id=capProfileHoliday.Id;
    capProfileHolidayClone.Plant = capProfileHoliday.Plant;
    capProfileHolidayClone.StartDate=capProfileHoliday.StartDate;
	capProfileHolidayClone.EndDate=capProfileHoliday.EndDate;
	capProfileHolidayClone.HolidayType=capProfileHoliday.HolidayType;

	return capProfileHolidayClone;
}


public
CapProfileHolidayContainer readCapProfileHolidayByFilters(string sid,string splant,string sholidayType,DateTime startDate,DateTime endDate,int rows){
	try{
        CapProfileHolidayContainer          capProfileHolidayContainer = new CapProfileHolidayContainer();
        CapProfileHolidayDataBaseContainer  capProfileHolidayDataBaseContainer = new CapProfileHolidayDataBaseContainer(dataBaseAccess);
        capProfileHolidayDataBaseContainer.readByFilters(sid,splant,sholidayType,startDate,endDate,rows);
           
        foreach(CapProfileHolidayDataBase capProfileHolidayDataBase in capProfileHolidayDataBaseContainer){
            CapProfileHoliday capProfileHoliday = objectDataBaseToObject(capProfileHolidayDataBase);                        
            capProfileHolidayContainer.Add(capProfileHoliday);
        }

		return capProfileHolidayContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
CapProfileHolidayContainer readIfHoliday(string splant,DateTime date,int rows){
	try{
        CapProfileHolidayContainer          capProfileHolidayContainer = new CapProfileHolidayContainer();
        CapProfileHolidayDataBaseContainer  capProfileHolidayDataBaseContainer = new CapProfileHolidayDataBaseContainer(dataBaseAccess);
        capProfileHolidayDataBaseContainer.readIfHoliday(splant,date,rows);
           
        foreach(CapProfileHolidayDataBase capProfileHolidayDataBase in capProfileHolidayDataBaseContainer){
            CapProfileHoliday capProfileHoliday = objectDataBaseToObject(capProfileHolidayDataBase);                        
            capProfileHolidayContainer.Add(capProfileHoliday);
        }

		return capProfileHolidayContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
double getCapProfileHolidayDatesAffects(string splant,DateTime startDate,DateTime endDate){
    double totalDays =0;
	try{        
        DateTime                    currDate = startDate;
        CapProfileHolidayContainer  capProfileHolidayContainer = new CapProfileHolidayContainer();

        if (endDate > startDate) { 
            for (int i=0; currDate.CompareTo(endDate) <=0 ;i++) { 
                currDate = startDate.AddDays(i);

                capProfileHolidayContainer = readIfHoliday(splant,currDate,0);
                if (capProfileHolidayContainer.Count > 0)
                    totalDays = totalDays + 1;
            }                                                          
        }                                        
		return totalDays;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

/*******************************************    CapacityViewHdr   **************************************************************/
public
CapacityViewHdr createCapacityViewHdr(){
	return new CapacityViewHdr();
}

public
CapacityViewHdrContainer createCapacityViewHdrContainer(){
	return new CapacityViewHdrContainer();
}


/*******************************************    ScheduleHdr   **************************************************************/

public
ScheduleHdr createScheduleHdr(){
	return new ScheduleHdr();
}

public
ScheduleHdrContainer createScheduleHdrContainer(){
	return new ScheduleHdrContainer();
}

public
bool existsScheduleHdr(int id){
	try{
		ScheduleHdrDataBase scheduleHdrDataBase = new ScheduleHdrDataBase(dataBaseAccess);

		scheduleHdrDataBase.setId(id);

		return scheduleHdrDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
ScheduleHdr readScheduleHdr(int id){
	try{
		ScheduleHdrDataBase scheduleHdrDataBase = new ScheduleHdrDataBase(dataBaseAccess);
		scheduleHdrDataBase.setId(id);

		if (!scheduleHdrDataBase.read())
			return null;

		ScheduleHdr scheduleHdr = this.objectDataBaseToObject(scheduleHdrDataBase);

        loadScheduleHdrChilds2(scheduleHdr);

		return scheduleHdr;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
ScheduleHdr readScheduleHdrLast(string splant){
	try{
		ScheduleHdrDataBase scheduleHdrDataBase = new ScheduleHdrDataBase(dataBaseAccess);

        if (!scheduleHdrDataBase.readLastByFilter(splant))
            return null;
        
		ScheduleHdr scheduleHdr = this.objectDataBaseToObject(scheduleHdrDataBase);
        loadScheduleHdrChilds2(scheduleHdr);

		return scheduleHdr;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}
        
public
ScheduleHdr readScheduleHdrLastDateCheck(ScheduleHdr scheduleHdr, string splant){
    ScheduleHdr scheduleHdrNew = null;
	try{
        scheduleHdrNew = scheduleHdr;
        bool                breadNew = false;
        ScheduleHdrDataBase scheduleHdrDataBase = new ScheduleHdrDataBase(dataBaseAccess);		
        if (!scheduleHdrDataBase.readLastByFilter(splant))
			return null;

        if (scheduleHdr == null)
            breadNew = true;            
        else if (scheduleHdr.DateTimeStamp != scheduleHdrDataBase.getDateTimeStamp() || scheduleHdr.Id != scheduleHdrDataBase.getId())
            breadNew = true;    

        if (breadNew)
            scheduleHdrNew = readScheduleHdr(scheduleHdrDataBase.getId());

		return scheduleHdrNew;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
string[][] getScheduleHdrByDesc(string searchText, int rows){
	try{
		ScheduleHdrDataBaseContainer scheduleHdrDataBaseContainer = new ScheduleHdrDataBaseContainer(dataBaseAccess);
		scheduleHdrDataBaseContainer.readByDesc(searchText, rows);
		string[][] items = new string[scheduleHdrDataBaseContainer.Count][];
		int i = 0;
		for(IEnumerator en = scheduleHdrDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			ScheduleHdrDataBase scheduleHdrDataBase = (ScheduleHdrDataBase) en.Current;
			string[] item = new String[3];
			item[0] = scheduleHdrDataBase.getId().ToString();
			item[1] = scheduleHdrDataBase.getDateCreated().ToString();
			item[2] = scheduleHdrDataBase.getStatus();
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

private 
void updateScheduleHdrOnly(ScheduleHdr scheduleHdr){
    ScheduleHdrDataBase scheduleHdrDataBase = this.objectToObjectDataBase(scheduleHdr);
    checkDateTimeStamp(scheduleHdr, scheduleHdrDataBase);
	scheduleHdrDataBase.update();
    scheduleHdr.DateTimeStamp = scheduleHdrDataBase.readDateTimeStamp();
}

public 
void updateScheduleHdr(ScheduleHdr scheduleHdr){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        updateScheduleHdrOnly(scheduleHdr);
		
        deleteScheduleHdrChilds(scheduleHdr.Id);
        writeScheduleHdrChilds(scheduleHdr);

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
void writeScheduleHdr(ScheduleHdr scheduleHdr){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        writeScheduleHdrInt(scheduleHdr);
		
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
void writeScheduleHdrInt(ScheduleHdr scheduleHdr){  
	ScheduleHdrDataBase scheduleHdrDataBase = this.objectToObjectDataBase(scheduleHdr);
	scheduleHdrDataBase.write();
	scheduleHdr.Id=scheduleHdrDataBase.getId();

    writeScheduleHdrChilds(scheduleHdr);		
}
        /*
private
void loadScheduleHdrChilds(ScheduleHdr scheduleHdr){
    
    //requirments
    ScheduleReqDataBaseContainer scheduleReqDataBaseContainer = new ScheduleReqDataBaseContainer(dataBaseAccess);
    scheduleReqDataBaseContainer.readByHdr(scheduleHdr.Id);   
    foreach(ScheduleReqDataBase scheduleReqDataBase in scheduleReqDataBaseContainer){
        ScheduleReq scheduleReq = objectDataBaseToObject(scheduleReqDataBase);
        loadReqDesc(scheduleReq);
        scheduleHdr.ScheduleReqContainer.Add(scheduleReq);            

        //parts
        SchedulePartDataBaseContainer schedulePartDataBaseContainer = new SchedulePartDataBaseContainer(dataBaseAccess);
        schedulePartDataBaseContainer.readByHdr(scheduleReq.HdrId, scheduleReq.Detail);   
        foreach(SchedulePartDataBase schedulePartDataBase in schedulePartDataBaseContainer){
            SchedulePart schedulePart = objectDataBaseToObject(schedulePartDataBase);
            if (scheduleReq.Type.Equals(CapacityReq.REQUIREMENT_MACHINE) && schedulePart.RunStd <=0){
                decimal drunStd=0,dcavities=0;
                getRunStdCavNumInt(scheduleHdr.Plant,schedulePart.Part, schedulePart.Seq,scheduleReq.ReqID,out drunStd,out dcavities);
                schedulePart.RunStd  = drunStd;
                schedulePart.CavityNum = dcavities;
            } 
            scheduleReq.SchedulePartContainer.Add(schedulePart);

            //part details
            SchedulePartDtlDataBaseContainer schedulePartDtlDataBaseContainer = new SchedulePartDtlDataBaseContainer(dataBaseAccess);
            schedulePartDtlDataBaseContainer.readByHdr(schedulePart.HdrId, schedulePart.Detail, schedulePart.SubDetail);   
            foreach(SchedulePartDtlDataBase schedulePartDtlDataBase in schedulePartDtlDataBaseContainer){
                SchedulePartDtl schedulePartDtl = objectDataBaseToObject(schedulePartDtlDataBase);
                schedulePart.SchedulePartDtlContainer.Add(schedulePartDtl);            
            }        

            //Schedule receipt part
            ScheduleReceiptPartDataBaseContainer scheduleReceiptPartDataBaseContainer = new ScheduleReceiptPartDataBaseContainer(dataBaseAccess);
            scheduleReceiptPartDataBaseContainer.readByHdr(schedulePart.HdrId, schedulePart.Detail, schedulePart.SubDetail);
            foreach(ScheduleReceiptPartDataBase scheduleReceiptPartDataBase in scheduleReceiptPartDataBaseContainer){
                ScheduleReceiptPart scheduleReceiptPart = objectDataBaseToObject(scheduleReceiptPartDataBase);
                schedulePart.ScheduleReceiptPartContainer.Add(scheduleReceiptPart);

                ScheduleMaterialConsumPartDataBaseContainer scheduleMaterialConsumPartDataBaseContainer = new ScheduleMaterialConsumPartDataBaseContainer(dataBaseAccess);
                scheduleMaterialConsumPartDataBaseContainer.readByHdr(scheduleReceiptPart.HdrId, scheduleReceiptPart.Detail, scheduleReceiptPart.SubDetail, scheduleReceiptPart.SubSubdDetail);

                foreach(ScheduleMaterialConsumPartDataBase scheduleMaterialConsumPartDataBase in scheduleMaterialConsumPartDataBaseContainer){
                    ScheduleMaterialConsumPart scheduleMaterialConsumPart = objectDataBaseToObject(scheduleMaterialConsumPartDataBase);
                    scheduleReceiptPart.ScheduleMaterialConsumPartContainer.Add(scheduleMaterialConsumPart);
                }
            }  
            
        }

        //tasks
        ScheduleTaskDataBaseContainer scheduleTaskDataBaseContainer = new ScheduleTaskDataBaseContainer(dataBaseAccess);
        scheduleTaskDataBaseContainer.readByHdr(scheduleReq.HdrId, scheduleReq.Detail);
        foreach(ScheduleTaskDataBase scheduleTaskDataBase in scheduleTaskDataBaseContainer){
            ScheduleTask scheduleTask = objectDataBaseToObject(scheduleTaskDataBase);
            scheduleReq.ScheduleTaskContainer.Add(scheduleTask);           

            scheduleTask.TaskDescription = getTaskDesc(scheduleTask.TaskId);
        }
    } 
}
*/
private
void loadScheduleHdrChilds2(ScheduleHdr scheduleHdr){        
    Hashtable           hashParts   = new Hashtable();
    Hashtable           hashRecParts= new Hashtable();
    SchedulePart        schedulePart= null;
    ScheduleReceiptPart scheduleReceiptPart = null;
    string              skey="";
              
    //parts
    SchedulePartDataBaseContainer schedulePartDataBaseContainer = new SchedulePartDataBaseContainer(dataBaseAccess);
    schedulePartDataBaseContainer.readByHdrAll(scheduleHdr.Id);

    foreach(SchedulePartDataBase schedulePartDataBase in schedulePartDataBaseContainer){
        schedulePart = objectDataBaseToObject(schedulePartDataBase);
        scheduleHdr.SchedulePartContainer.Add(schedulePart);

        if (schedulePart.RunStd <=0){
            decimal drunStd=0,dcavities=0;
            getRunStdCavNumInt(scheduleHdr.Plant,schedulePart.Part, schedulePart.Seq,schedulePart.MachId,out drunStd,out dcavities);
            schedulePart.RunStd  = drunStd;
            schedulePart.CavityNum = dcavities;
        } 

        if (!hashParts.Contains(schedulePart.Detail))
            hashParts.Add(schedulePart.Detail, schedulePart);     
    }

    //part details
    SchedulePartDtlDataBaseContainer schedulePartDtlDataBaseContainer = new SchedulePartDtlDataBaseContainer(dataBaseAccess);
    schedulePartDtlDataBaseContainer.readByHdrAll(scheduleHdr.Id);
    foreach(SchedulePartDtlDataBase schedulePartDtlDataBase in schedulePartDtlDataBaseContainer){
        SchedulePartDtl schedulePartDtl = objectDataBaseToObject(schedulePartDtlDataBase);
        
        if (hashParts.Contains(schedulePartDtl.Detail)) {
            schedulePart = (SchedulePart)hashParts[schedulePartDtl.Detail];
            schedulePart.SchedulePartDtlContainer.Add(schedulePartDtl);            
        }
    }        

    //Schedule receipt part
    ScheduleReceiptPartDataBaseContainer scheduleReceiptPartDataBaseContainer = new ScheduleReceiptPartDataBaseContainer(dataBaseAccess);
    scheduleReceiptPartDataBaseContainer.readByHdrAll(scheduleHdr.Id);
    foreach(ScheduleReceiptPartDataBase scheduleReceiptPartDataBase in scheduleReceiptPartDataBaseContainer){
        scheduleReceiptPart = objectDataBaseToObject(scheduleReceiptPartDataBase);

        if (hashParts.Contains(scheduleReceiptPart.Detail)) {
            schedulePart = (SchedulePart)hashParts[scheduleReceiptPart.Detail];
            schedulePart.ScheduleReceiptPartContainer.Add(scheduleReceiptPart);      
                    
            skey = scheduleReceiptPart.Detail.ToString() +  Constants.DEFAULT_SEP + scheduleReceiptPart.SubDetail.ToString();
            if (!hashRecParts.Contains(skey))
                hashRecParts.Add(skey,scheduleReceiptPart);
        }        
    }

    //schedule materials
    ScheduleMaterialConsumPartDataBaseContainer scheduleMaterialConsumPartDataBaseContainer = new ScheduleMaterialConsumPartDataBaseContainer(dataBaseAccess);
    scheduleMaterialConsumPartDataBaseContainer.readByHdrAll(scheduleHdr.Id);
    foreach (ScheduleMaterialConsumPartDataBase scheduleMaterialConsumPartDataBase in scheduleMaterialConsumPartDataBaseContainer){
        ScheduleMaterialConsumPart scheduleMaterialConsumPart = objectDataBaseToObject(scheduleMaterialConsumPartDataBase);

        skey = scheduleMaterialConsumPart.Detail.ToString() +Constants.DEFAULT_SEP + scheduleMaterialConsumPart.SubDetail.ToString();       
        if (hashRecParts.Contains(skey)) {
            scheduleReceiptPart = (ScheduleReceiptPart)hashRecParts[skey];
            scheduleReceiptPart.ScheduleMaterialConsumPartContainer.Add(scheduleMaterialConsumPart);
        }
    }
    
    //tasks
    ScheduleTaskDataBaseContainer scheduleTaskDataBaseContainer = new ScheduleTaskDataBaseContainer(dataBaseAccess);
    scheduleTaskDataBaseContainer.readByHdrAll(scheduleHdr.Id);
    foreach(ScheduleTaskDataBase scheduleTaskDataBase in scheduleTaskDataBaseContainer){
        ScheduleTask scheduleTask = objectDataBaseToObject(scheduleTaskDataBase);
        scheduleHdr.ScheduleTaskContainer.Add(scheduleTask);
    }    

    //down
    ScheduleDownDataBaseContainer scheduleDownDataBaseContainer = new ScheduleDownDataBaseContainer(dataBaseAccess);
    scheduleDownDataBaseContainer.readByHdrAll(scheduleHdr.Id);
    foreach(ScheduleDownDataBase scheduleDownDataBase in scheduleDownDataBaseContainer){
        ScheduleDown scheduleDown = objectDataBaseToObject(scheduleDownDataBase);
        scheduleHdr.ScheduleDownContainer.Add(scheduleDown);        
    }   
}

private
void loadReqDesc(ScheduleReqView scheduleReqView){

    switch(scheduleReqView.ScheduleType){
        case CapacityReq.REQUIREMENT_LABOUR:
            scheduleReqView.MachDescShow= "Labour";
            break;
        case CapacityReq.REQUIREMENT_MACHINE:
            PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
            if (pltDeptMachDataBase.readById(scheduleReqView.MachId));
                scheduleReqView.MachShow= pltDeptMachDataBase.getPDM_Mach();
            break;
         case CapacityReq.REQUIREMENT_TASK:
            scheduleReqView.MachShow = getTaskDesc(scheduleReqView.MachId);
            break;
         case CapacityReq.REQUIREMENT_TOOL:
            scheduleReqView.MachShow = "Tool";
            break;
    }
}

public
bool loadBuildMachineInfo(string splantOriginal,string spart,int seq,int imachineId,out string splant,out string sdept,out string smachine,out decimal drunStd, out decimal dcavities,out decimal optRunQty){
    bool bresult = false;

    splant = sdept = smachine = "";
    drunStd= dcavities = optRunQty=0;

    try {         
        ProdFmActSubDataBase            prodFmActSubDataBase = null;
        ProdFmActSubDataBaseContainer   prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
        prodFmActSubDataBaseContainer.readByFilters(spart, seq, imachineId, splantOriginal,"",false,false,1);

        if (prodFmActSubDataBaseContainer.Count > 0)
            prodFmActSubDataBase = (ProdFmActSubDataBase)prodFmActSubDataBaseContainer[0];

        if (prodFmActSubDataBase!= null){
            splant  = prodFmActSubDataBase.getPC_Plt();
            sdept   = prodFmActSubDataBase.getPC_Dept();
            smachine= prodFmActSubDataBase.getPC_Cfg();
            drunStd= prodFmActSubDataBase.getPC_RunStd();
            dcavities = prodFmActSubDataBase.getPC_CavityNum();
            optRunQty = prodFmActSubDataBase.getPC_OptRunQty();

            bresult = true;
        }
                
    }catch(PersistenceException persistenceException){	
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		 
		throw new NujitException(exception.Message,exception);
	}
    return bresult;
}

public
decimal getRunStd(string splant,string spart, int seq,int machineId){
	try{		
        decimal dRunStd=0,dcavities =0;
		getRunStdCavNumInt(splant,spart, seq, machineId,out dRunStd,out dcavities);

        return dRunStd;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
bool getRunStdCavNumInt(string splantOriginal,string spart,int seq,int machineId,out decimal dRunStd,out decimal dcavities){
    bool bresult = false;

    string      splant = "";
    string      sdept = "";
    string      smachine = "";
    decimal     doptRunQty =0;
    dRunStd= dcavities = 0;        
    bresult = loadBuildMachineInfo(splantOriginal, spart, seq, machineId, out splant, out sdept, out smachine, out dRunStd, out dcavities,out doptRunQty);        

    return bresult;
}

private
string getTaskDesc(int taskId){
    string sdesc="";
    CapShiftTaskDataBase capShiftTaskDataBase = new CapShiftTaskDataBase(dataBaseAccess);
    capShiftTaskDataBase.setId(taskId);
    if (capShiftTaskDataBase.read())
        sdesc= capShiftTaskDataBase.getTaskName();    
    return sdesc;
}

private
void writeScheduleHdrChilds(ScheduleHdr scheduleHdr){
    scheduleHdr.fillRedundances();
                               
    foreach(SchedulePart schedulePart in scheduleHdr.SchedulePartContainer){                        
        SchedulePartDataBase schedulePartDataBase = this.objectToObjectDataBase(schedulePart);
        schedulePartDataBase.write();

        foreach(SchedulePartDtl schedulePartDtl in schedulePart.SchedulePartDtlContainer){
            SchedulePartDtlDataBase schedulePartDtlDataBase = this.objectToObjectDataBase(schedulePartDtl);
            schedulePartDtlDataBase.write();
        }

        foreach(ScheduleReceiptPart scheduleReceiptPart in schedulePart.ScheduleReceiptPartContainer){
            ScheduleReceiptPartDataBase scheduleReceiptPartDataBase = this.objectToObjectDataBase(scheduleReceiptPart);
            scheduleReceiptPartDataBase.write();

            foreach(ScheduleMaterialConsumPart scheduleMaterialConsumPart in scheduleReceiptPart.ScheduleMaterialConsumPartContainer){
                ScheduleMaterialConsumPartDataBase scheduleMaterialConsumPartDataBase = this.objectToObjectDataBase(scheduleMaterialConsumPart);
                scheduleMaterialConsumPartDataBase.write();
            }
        }
    }
    
    foreach(ScheduleTask scheduleTask in scheduleHdr.ScheduleTaskContainer){            
        ScheduleTaskDataBase scheduleTaskDataBase = this.objectToObjectDataBase(scheduleTask);
        scheduleTaskDataBase.write();                                
    }    
        
    foreach(ScheduleDown scheduleDown in scheduleHdr.ScheduleDownContainer){            
        ScheduleDownDataBase scheduleDownDataBase = this.objectToObjectDataBase(scheduleDown);
        scheduleDownDataBase.write();                                
    }                   
                       
}

public 
void deleteScheduleHdrChilds(int id){
    ScheduleMaterialConsumPartDataBaseContainer scheduleMaterialConsumPartDataBaseContainer = new ScheduleMaterialConsumPartDataBaseContainer(dataBaseAccess);
    scheduleMaterialConsumPartDataBaseContainer.deleteByHdr(id);

    ScheduleReceiptPartDataBaseContainer scheduleReceiptPartDataBaseContainer = new ScheduleReceiptPartDataBaseContainer(dataBaseAccess);
    scheduleReceiptPartDataBaseContainer.deleteByHdr(id);

    SchedulePartDtlDataBaseContainer schedulePartDtlDataBaseContainer = new SchedulePartDtlDataBaseContainer(dataBaseAccess);
    schedulePartDtlDataBaseContainer.deleteByHdr(id);    
                                
    SchedulePartDataBaseContainer schedulePartDataBaseContainer = new SchedulePartDataBaseContainer(dataBaseAccess);
    schedulePartDataBaseContainer.deleteByHdr(id);    
    
    ScheduleTaskDataBaseContainer scheduleTaskDataBaseContainer = new ScheduleTaskDataBaseContainer(dataBaseAccess);
    scheduleTaskDataBaseContainer.deleteByHdr(id);

    ScheduleDownDataBaseContainer scheduleDownDataBaseContainer = new ScheduleDownDataBaseContainer(dataBaseAccess);
    scheduleDownDataBaseContainer.deleteByHdr(id);
    
}

public
void deleteScheduleHdr(int id){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();


        deleteScheduleHdrChilds(id);
		ScheduleHdrDataBase scheduleHdrDataBase = new ScheduleHdrDataBase(dataBaseAccess);

		scheduleHdrDataBase.setId(id);
		scheduleHdrDataBase.delete();

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
ScheduleHdr objectDataBaseToObject(ScheduleHdrDataBase scheduleHdrDataBase){
	ScheduleHdr scheduleHdr = new ScheduleHdr();

	scheduleHdr.Id=scheduleHdrDataBase.getId();
	scheduleHdr.DateCreated=scheduleHdrDataBase.getDateCreated();
	scheduleHdr.Status=scheduleHdrDataBase.getStatus();
    scheduleHdr.Plant = scheduleHdrDataBase.getPlant();
    scheduleHdr.DateTimeStamp = scheduleHdrDataBase.getDateTimeStamp();

    return scheduleHdr;
}

private
ScheduleHdrDataBase objectToObjectDataBase(ScheduleHdr scheduleHdr){
	ScheduleHdrDataBase scheduleHdrDataBase = new ScheduleHdrDataBase(dataBaseAccess);
	scheduleHdrDataBase.setId(scheduleHdr.Id);
	scheduleHdrDataBase.setDateCreated(scheduleHdr.DateCreated);
	scheduleHdrDataBase.setStatus(scheduleHdr.Status);
    scheduleHdrDataBase.setPlant(scheduleHdr.Plant);
    scheduleHdrDataBase.setDateTimeStamp(scheduleHdr.DateTimeStamp);

	return scheduleHdrDataBase;
}

public
ScheduleHdr cloneScheduleHdr(ScheduleHdr scheduleHdr){
	ScheduleHdr scheduleHdrClone = new ScheduleHdr();

	scheduleHdrClone.Id=scheduleHdr.Id;
	scheduleHdrClone.DateCreated=scheduleHdr.DateCreated;
	scheduleHdrClone.Status=scheduleHdr.Status;
    scheduleHdrClone.Plant = scheduleHdr.Plant;
    scheduleHdrClone.DateTimeStamp = scheduleHdr.DateTimeStamp;
    
    for (int i=0; i < scheduleHdr.SchedulePartContainer.Count;i++)        
        scheduleHdrClone.SchedulePartContainer.Add(cloneSchedulePart(scheduleHdr.SchedulePartContainer[i]));        

    for (int i=0; i < scheduleHdr.ScheduleTaskContainer.Count;i++)        
        scheduleHdrClone.ScheduleTaskContainer.Add(cloneScheduleTask(scheduleHdr.ScheduleTaskContainer[i]));        

    for (int i=0; i < scheduleHdr.ScheduleDownContainer.Count;i++)        
        scheduleHdrClone.ScheduleDownContainer.Add(cloneScheduleDown(scheduleHdr.ScheduleDownContainer[i]));        
    
	return scheduleHdrClone;
}

public
ScheduleHdrContainer readScheduleHdrByFilters(string sid,string splant, string status, int icapacityHdr, int ihotListId,DateTime fromDate, DateTime toDate, bool bonlyHeader, int rows){
	try{
        ScheduleHdrContainer scheduleHdrContainer = new ScheduleHdrContainer();

        ScheduleHdrDataBaseContainer scheduleHdrDataBaseContainer = new ScheduleHdrDataBaseContainer(dataBaseAccess);
		scheduleHdrDataBaseContainer.readByFilters(sid,splant,status, icapacityHdr, ihotListId,fromDate, toDate,rows);	
        
        foreach(ScheduleHdrDataBase scheduleHdrDataBase in scheduleHdrDataBaseContainer){
            ScheduleHdr scheduleHdr = objectDataBaseToObject(scheduleHdrDataBase);
            
            if (!bonlyHeader)
                loadScheduleHdrChilds2(scheduleHdr);            
            scheduleHdrContainer.Add(scheduleHdr);
        }

		return scheduleHdrContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
void loadScheduleHdrAdditionalInfo(ScheduleHdr scheduleHdr,Hashtable hashMachinesById){
	try{                       
        ArrayList               arrayMachines=new ArrayList();
        Hashtable               hashPltDeptMachById = new Hashtable();
        Machine                 machine=null;                
        ArrayList               arrayScheduleMachines = new ArrayList();
        CapShiftTaskContainer   capShiftTaskContainer = readCapShiftTaskByFilters("","","",0);
        CapShiftTask            capShiftTask = null;
                                                     
        for (int i=0;i < scheduleHdr.SchedulePartContainer.Count;i++){
            SchedulePart schedulePart = scheduleHdr.SchedulePartContainer[i];

            BomSumDataBaseContainer bomSumDataBaseContainer = new BomSumDataBaseContainer(dataBaseAccess);
            bomSumDataBaseContainer.readForMaterials(schedulePart.Part, schedulePart.Seq);
            schedulePart.MaterialFlag = bomSumDataBaseContainer.Count > 0 ? Constants.STRING_YES : Constants.STRING_NO;

            if (!hashMachinesById.Contains(schedulePart.MachId))
                arrayMachines.Add(schedulePart.MachId);

            arrayScheduleMachines.Add(schedulePart);
        }
          
        for (int i=0;i < scheduleHdr.ScheduleTaskContainer.Count;i++){
            ScheduleTask scheduleTask = scheduleHdr.ScheduleTaskContainer[i];
            if (!hashMachinesById.Contains(scheduleTask.MachId))
                arrayMachines.Add(scheduleTask.MachId);    
            
            arrayScheduleMachines.Add(scheduleTask);     

            capShiftTask = capShiftTaskContainer.getByKey(scheduleTask.TaskId);
            if (capShiftTask!= null)
                scheduleTask.TaskDescription = capShiftTask.TaskName;
        }
        
        for (int i=0;i < scheduleHdr.ScheduleDownContainer.Count;i++){
            ScheduleDown scheduleDown = scheduleHdr.ScheduleDownContainer[i];
            if (!hashMachinesById.Contains(scheduleDown.MachId))
                arrayMachines.Add(scheduleDown.MachId); 
            
            arrayScheduleMachines.Add(scheduleDown);             
        }

        if (arrayMachines.Count > 0) { //read list of machines for found on   hashMachinesById         
            PltDeptMachDataBaseContainer    pltDeptMachDataBaseContainer = new PltDeptMachDataBaseContainer(dataBaseAccess);            
            pltDeptMachDataBaseContainer.readByIds(arrayMachines);
            foreach (PltDeptMachDataBase pltDeptMachDataBase in pltDeptMachDataBaseContainer)
                hashPltDeptMachById.Add(pltDeptMachDataBase.getPDM_ID(),pltDeptMachDataBase);            
        }

        //load machine code and desc from hashs
        for (int i=0; i < arrayScheduleMachines.Count; i++){
            ScheduleMachine scheduleMachine = (ScheduleMachine)arrayScheduleMachines[i];

            if (hashMachinesById.Contains(scheduleMachine.MachId)) { 
                machine = (Machine)hashMachinesById[scheduleMachine.MachId];
                if (machine!= null) { 
                    scheduleMachine.MachShow    = machine.Mach;
                    scheduleMachine.MachDescShow= machine.Des1;
                }

            }else if (hashPltDeptMachById.Contains(scheduleMachine.MachId)) { 
                PltDeptMachDataBase pltDeptMachDataBase = (PltDeptMachDataBase)hashPltDeptMachById[scheduleMachine.MachId];
                if (pltDeptMachDataBase != null) { 
                    scheduleMachine.MachShow    = pltDeptMachDataBase.getPDM_Mach();
                    scheduleMachine.MachDescShow= pltDeptMachDataBase.getPDM_Des1();
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
bool checkDateTimeStamp(ScheduleHdr scheduleHdr, ScheduleHdrDataBase scheduleHdrDataBase) {
    bool bchanged=false;
    if (scheduleHdr.DateTimeStamp != scheduleHdrDataBase.readDateTimeStamp())
        throw new Exception("Schedule " + Constants.DATETIME_STAMP_TABLE_MESSAGE);

    return bchanged;
}
       
/*******************************************    SchedulePart   **************************************************************/
public
SchedulePart createSchedulePart(){
	return new SchedulePart();
}

public
SchedulePartContainer createSchedulePartContainer(){
	return new SchedulePartContainer();
}

private
SchedulePart objectDataBaseToObject(SchedulePartDataBase schedulePartDataBase){
	SchedulePart schedulePart = new SchedulePart();

	schedulePart.HdrId=schedulePartDataBase.getHdrId();
	schedulePart.Detail=schedulePartDataBase.getDetail();    
	schedulePart.Part=schedulePartDataBase.getPart();
	schedulePart.IsFamily=schedulePartDataBase.getIsFamily();
	schedulePart.Seq=schedulePartDataBase.getSeq();
	schedulePart.Qty=schedulePartDataBase.getQty();
	schedulePart.StartDate=schedulePartDataBase.getStartDate();
	schedulePart.EndDate=schedulePartDataBase.getEndDate();
	schedulePart.StartShift=schedulePartDataBase.getStartShift();
    schedulePart.Priority =schedulePartDataBase.getPriority();
    schedulePart.Queue =schedulePartDataBase.getQueue();
    schedulePart.RunStd = schedulePartDataBase.getRunStd();
    schedulePart.CavityNum = schedulePartDataBase.getCavityNum();
    schedulePart.QtyReported = schedulePartDataBase.getQtyReported();
    schedulePart.Uom = schedulePartDataBase.getUom();
    schedulePart.CapacityHdrId = schedulePartDataBase.getCapacityHdrId();    
    schedulePart.HotListId = schedulePartDataBase.getHotListId();
    schedulePart.MachId = schedulePartDataBase.getMachId();

    schedulePart.SchNonChargeDT = schedulePartDataBase.getSchNonChargeDT();
    schedulePart.SchChargeDT = schedulePartDataBase.getSchChargeDT();   

    return schedulePart;
}

private
SchedulePartDataBase objectToObjectDataBase(SchedulePart schedulePart){
	SchedulePartDataBase schedulePartDataBase = new SchedulePartDataBase(dataBaseAccess);
	schedulePartDataBase.setHdrId(schedulePart.HdrId);
	schedulePartDataBase.setDetail(schedulePart.Detail);    
	schedulePartDataBase.setPart(schedulePart.Part);
	schedulePartDataBase.setIsFamily(schedulePart.IsFamily);
	schedulePartDataBase.setSeq(schedulePart.Seq);
	schedulePartDataBase.setQty(schedulePart.Qty);
	schedulePartDataBase.setStartDate(schedulePart.StartDate);
	schedulePartDataBase.setEndDate(schedulePart.EndDate);
	schedulePartDataBase.setStartShift(schedulePart.StartShift);
    schedulePartDataBase.setPriority(schedulePart.Priority);
    schedulePartDataBase.setQueue(schedulePart.Queue);
    schedulePartDataBase.setRunStd(schedulePart.RunStd);
    schedulePartDataBase.setCavityNum(schedulePart.CavityNum);
    schedulePartDataBase.setQtyReported(schedulePart.QtyReported);
    schedulePartDataBase.setUom(schedulePart.Uom);
    schedulePartDataBase.setCapacityHdrId(schedulePart.CapacityHdrId);
    schedulePartDataBase.setHotListId(schedulePart.HotListId);
    schedulePartDataBase.setMachId(schedulePart.MachId);

    schedulePartDataBase.setSchNonChargeDT(schedulePart.SchNonChargeDT);
    schedulePartDataBase.setSchChargeDT(schedulePart.SchChargeDT);   

    return schedulePartDataBase;
}

public
SchedulePart cloneSchedulePart(SchedulePart schedulePart){
	SchedulePart schedulePartClone = new SchedulePart();
    schedulePartClone.copy(schedulePart);
    	
	return schedulePartClone;
}

public
bool generateAutomaticReceiptPart(SchedulePart schedulePart){
            //decimal             dminutes = Convert.ToInt64((EndDate - StartDate).TotalMinutes);
    try{ 
        bool                bresult = false;
        decimal             dminutes = Convert.ToInt64( (schedulePart.Qty / (schedulePart.RunStd != 0 ? schedulePart.RunStd : 1) ) * 60); //converted to minutes
        int                 icurrShift = DateUtil.getShiftNum(schedulePart.StartDate);
        int                 ilastShift = -1;
        int                 iminutes = 0;
        int                 itotMinutes= 0;
        ScheduleReceiptPart scheduleReceiptPart = null;
        DateTime            lastDate = schedulePart.StartDate;
        decimal             dqtyRepAux = schedulePart.QtyReported;
    
    
        schedulePart.ScheduleReceiptPartContainer.Clear();        
        if (schedulePart.Qty > 0){
            for (int i=0;i <= dminutes && schedulePart.RunStd != 0; i++,itotMinutes++){
                bresult = true;
    
                if (ilastShift != icurrShift){
                    if (scheduleReceiptPart!= null)
                        lastDate = scheduleReceiptPart.RecDate.AddSeconds(1);

                    scheduleReceiptPart = new ScheduleReceiptPart();          
                    scheduleReceiptPart.StartDate = lastDate;
                    schedulePart.ScheduleReceiptPartContainer.Add(scheduleReceiptPart);                    
                    ilastShift = icurrShift;
                    iminutes=0;
                }else
                    iminutes++;

                if ( (i+1) > dminutes)
                    i=i;      
                if (scheduleReceiptPart!= null){
                    if (i==dminutes)
                        scheduleReceiptPart.RecDate= schedulePart.StartDate.AddMinutes(itotMinutes).AddSeconds(-1);   
                    else
                        scheduleReceiptPart.RecDate= schedulePart.StartDate.AddMinutes(itotMinutes+1).AddSeconds(-1);   

                     if (i==dminutes)
                        scheduleReceiptPart.RecQty = Convert.ToDecimal((scheduleReceiptPart.RecDate.AddSeconds(1) - lastDate).TotalHours) * schedulePart.RunStd;            
                     else
                        scheduleReceiptPart.RecQty = Convert.ToDecimal((scheduleReceiptPart.RecDate - lastDate).TotalHours) * schedulePart.RunStd;            
                    scheduleReceiptPart.RecQty = Convert.ToInt64(scheduleReceiptPart.RecQty);

                    generateReportedReceiptPart(ref dqtyRepAux,scheduleReceiptPart);
                }
                icurrShift = DateUtil.getShiftNum(schedulePart.StartDate.AddMinutes(i+1));
            }      

            decimal dtotRecQty = schedulePart.ScheduleReceiptPartContainer.getTotalRecQty();
            if (schedulePart.Qty != dtotRecQty && scheduleReceiptPart!= null)
                scheduleReceiptPart.RecQty+= (schedulePart.Qty - dtotRecQty);
            generateReportedReceiptPart(ref dqtyRepAux,scheduleReceiptPart);
        }
        schedulePart.fillRedundances();                
        generateSchChargeDT(schedulePart);

        return bresult;            

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}                    
} 

private
void generateReportedReceiptPart(ref decimal dqtyRepAux,ScheduleReceiptPart scheduleReceiptPart){       
    if (scheduleReceiptPart!= null){ 
        dqtyRepAux+=scheduleReceiptPart.RepQty;
        if (dqtyRepAux!=0){
            if (scheduleReceiptPart.RecQty >= dqtyRepAux){                                                   
                scheduleReceiptPart.RepQty =  dqtyRepAux;
                dqtyRepAux =0;
            }else{
                scheduleReceiptPart.RepQty =  scheduleReceiptPart.RecQty;
                dqtyRepAux-= scheduleReceiptPart.RepQty;
            }
        }
    }
} 

public
void generateSchChargeDT(SchedulePart schedulePart){    
    if (schedulePart!= null){        
        decimal                 down     =0;
        decimal                 downNonScheduled =0;
        decimal                 dtotMins =0;
        decimal                 dpartialMins =0;
        ScheduleReceiptPart     scheduleReceiptPart = null;
        TimeSpan                timeSpan=new TimeSpan();
        PltDeptMachDefDataBase  pltDeptMachDefDataBase = new PltDeptMachDefDataBase(dataBaseAccess);
        PltDeptMachDataBase     pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
        PltDeptDataBase         pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);

        schedulePart.SchChargeDT =0;
        schedulePart.SchNonChargeDT =0;

        pltDeptMachDefDataBase.setMachId(schedulePart.MachId);
        if (pltDeptMachDefDataBase.read())
            down = pltDeptMachDefDataBase.getDownHrsPerShift(); 
        
        if (pltDeptMachDataBase.readById(schedulePart.MachId)) {         //read machine
            pltDeptDataBase.setDE_Plt(pltDeptMachDataBase.getPDM_Plt());//read department
            pltDeptDataBase.setDE_Dept(pltDeptMachDataBase.getPDM_Dept());
            if (pltDeptDataBase.read())   
                downNonScheduled = pltDeptDataBase.getDE_NonScheduledDT();
        }

        for (int i=0; i < schedulePart.ScheduleReceiptPartContainer.Count; i++){
            scheduleReceiptPart = schedulePart.ScheduleReceiptPartContainer[i];

            timeSpan = (scheduleReceiptPart.RecDate.AddSeconds(1) - scheduleReceiptPart.StartDate);
            dtotMins = Convert.ToDecimal(timeSpan.TotalMinutes);                

            dpartialMins = dtotMins / (8*60);
            schedulePart.SchChargeDT+= (dpartialMins*down);

            schedulePart.SchNonChargeDT+= (dpartialMins* downNonScheduled);
        }
              
    }
            
}
        /*
public
bool generateAutomaticMaterialConsumition(SchedulePart schedulePart,string[][] materials){
    try{ 
        bool                bresult = false;
        decimal             dqtyRemains=0;
        string              spart="";
        int                 seq=0;
        decimal             dqtyReq=0;
        decimal             dqoh=0;
        string[]            line = new string[7];
        string              stype="";

        if (schedulePart==null || materials == null)
            return bresult;
        
        for (int i=0; i < schedulePart.ScheduleReceiptPartContainer.Count;i++){
            ScheduleReceiptPart scheduleReceiptPart = schedulePart.ScheduleReceiptPartContainer[i];
            scheduleReceiptPart.ScheduleMaterialConsumPartContainer.Clear();

            dqtyRemains = scheduleReceiptPart.RemainsQty;

             for (int j=0; j < materials.Length;j++){
                line = materials[j];
                spart = line[0];                        // prod
                seq = Convert.ToInt32(line[5]);         // sequence
                dqtyReq = Convert.ToDecimal(line[3]);   // qty req
                dqoh = Convert.ToDecimal(line[4]);      // inventory
                stype = line[6];                        // "Purchased" : "Manufatured";

                ScheduleMaterialConsumPart scheduleMaterialConsumPart = new ScheduleMaterialConsumPart();

                scheduleMaterialConsumPart.MatPart = spart;
                scheduleMaterialConsumPart.MatSeq = seq;
                scheduleMaterialConsumPart.QtyReq = dqtyReq;
                scheduleMaterialConsumPart.QtyConsum = scheduleReceiptPart.RecQty * scheduleMaterialConsumPart.QtyReq;
                scheduleMaterialConsumPart.QtyReported = scheduleReceiptPart.RepQty * scheduleMaterialConsumPart.QtyReq;
                scheduleMaterialConsumPart.MatType = string.IsNullOrEmpty(stype) ? "" : stype.Substring(0,1);

                scheduleReceiptPart.ScheduleMaterialConsumPartContainer.Add(scheduleMaterialConsumPart);
            }
        }
        schedulePart.fillRedundances();

        return bresult;            

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}       
} */

public
bool generateAutomaticMaterialConsumition(SchedulePart schedulePart,BomSumContainer bomSumContainer){
    try{ 
        bool                bresult = false;
        decimal             dqtyRemains=0;
        string              spart="";
        int                 seq=0;
        decimal             dqtyReq=0;
        decimal             dqoh=0;
        BomSum              bomSum=null;
        string              stype="";

        if (schedulePart==null || bomSumContainer == null)
            return bresult;
        
        for (int i=0; i < schedulePart.ScheduleReceiptPartContainer.Count;i++){
            ScheduleReceiptPart scheduleReceiptPart = schedulePart.ScheduleReceiptPartContainer[i];
            scheduleReceiptPart.ScheduleMaterialConsumPartContainer.Clear();

            dqtyRemains = scheduleReceiptPart.RemainsQty;

             for (int j=0; j < bomSumContainer.Count;j++){
                bomSum = bomSumContainer[j];
                spart = bomSum.MatID;                           // prod
                seq = Convert.ToInt32(bomSum.MatSeq);           // sequence
                dqtyReq = Convert.ToDecimal(bomSum.MatQty);     // qty req
                dqoh = Convert.ToDecimal(bomSum.MatQohShow);    // inventory
                stype = bomSum.MatTypeShow;                     // "Purchased" : "Manufatured";

                ScheduleMaterialConsumPart scheduleMaterialConsumPart = new ScheduleMaterialConsumPart();

                scheduleMaterialConsumPart.MatPart = spart;
                scheduleMaterialConsumPart.MatSeq = seq;
                scheduleMaterialConsumPart.QtyReq = dqtyReq;
                scheduleMaterialConsumPart.QtyConsum = scheduleReceiptPart.RecQty * scheduleMaterialConsumPart.QtyReq;
                scheduleMaterialConsumPart.QtyReported = scheduleReceiptPart.RepQty * scheduleMaterialConsumPart.QtyReq;
                scheduleMaterialConsumPart.MatType = string.IsNullOrEmpty(stype) ? "" : stype.Substring(0,1);

                scheduleReceiptPart.ScheduleMaterialConsumPartContainer.Add(scheduleMaterialConsumPart);
            }
        }
        schedulePart.fillRedundances();

        return bresult;            

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}       
} 

/*******************************************    SchedulePartDtl   **************************************************************/
public
SchedulePartDtl createSchedulePartDtl(){
	return new SchedulePartDtl();
}

public
SchedulePartDtlContainer createSchedulePartDtlContainer(){
	return new SchedulePartDtlContainer();
}


private
SchedulePartDtl objectDataBaseToObject(SchedulePartDtlDataBase schedulePartDtlDataBase){
	SchedulePartDtl schedulePartDtl = new SchedulePartDtl();

	schedulePartDtl.HdrId=schedulePartDtlDataBase.getHdrId();
	schedulePartDtl.Detail=schedulePartDtlDataBase.getDetail();
	schedulePartDtl.SubDetail=schedulePartDtlDataBase.getSubDetail();    
	schedulePartDtl.Part=schedulePartDtlDataBase.getPart();
	schedulePartDtl.Seq=schedulePartDtlDataBase.getSeq();
	schedulePartDtl.Qty=schedulePartDtlDataBase.getQty();

	return schedulePartDtl;
}

private
SchedulePartDtlDataBase objectToObjectDataBase(SchedulePartDtl schedulePartDtl){
	SchedulePartDtlDataBase schedulePartDtlDataBase = new SchedulePartDtlDataBase(dataBaseAccess);
	schedulePartDtlDataBase.setHdrId(schedulePartDtl.HdrId);
	schedulePartDtlDataBase.setDetail(schedulePartDtl.Detail);
	schedulePartDtlDataBase.setSubDetail(schedulePartDtl.SubDetail);    
	schedulePartDtlDataBase.setPart(schedulePartDtl.Part);
	schedulePartDtlDataBase.setSeq(schedulePartDtl.Seq);
	schedulePartDtlDataBase.setQty(schedulePartDtl.Qty);

	return schedulePartDtlDataBase;
}

public
SchedulePartDtl cloneSchedulePartDtl(SchedulePartDtl schedulePartDtl){
	SchedulePartDtl schedulePartDtlClone = new SchedulePartDtl();
    schedulePartDtlClone.copy(schedulePartDtl);

	return schedulePartDtlClone;
}

/*******************************************    ScheduleReqsd    **************************************************************/
public
ScheduleReqView createScheduleReqView(){
	return new ScheduleReqView();
}

public
ScheduleReqViewContainer createScheduleReqViewContainer(){
	return new ScheduleReqViewContainer();
}

/*******************************************    ScheduleTask    **************************************************************/
public
ScheduleTask createScheduleTask(){
	return new ScheduleTask();
}

public
ScheduleTaskContainer createScheduleTaskContainer(){
	return new ScheduleTaskContainer();
}

private
ScheduleTask objectDataBaseToObject(ScheduleTaskDataBase scheduleTaskDataBase){
	ScheduleTask scheduleTask = new ScheduleTask();

	scheduleTask.HdrId=scheduleTaskDataBase.getHdrId();
	scheduleTask.Detail=scheduleTaskDataBase.getDetail();    
	scheduleTask.StartDate=scheduleTaskDataBase.getStartDate();
	scheduleTask.EndDate=scheduleTaskDataBase.getEndDate();
	scheduleTask.StartShift=scheduleTaskDataBase.getStartShift();
    scheduleTask.TaskId =scheduleTaskDataBase.getTaskId();
    scheduleTask.Hours= scheduleTaskDataBase.getHours();
    scheduleTask.TotEmployees= scheduleTaskDataBase.getTotEmployees();
    scheduleTask.EmployeeHours= scheduleTaskDataBase.getEmployeeHours();
    scheduleTask.Priority = scheduleTaskDataBase.getPriority();
    scheduleTask.Queue = scheduleTaskDataBase.getQueue();
    scheduleTask.MachId = scheduleTaskDataBase.getMachId();

    return scheduleTask;
}

private
ScheduleTaskDataBase objectToObjectDataBase(ScheduleTask scheduleTask){
	ScheduleTaskDataBase scheduleTaskDataBase = new ScheduleTaskDataBase(dataBaseAccess);
	scheduleTaskDataBase.setHdrId(scheduleTask.HdrId);
	scheduleTaskDataBase.setDetail(scheduleTask.Detail);    
	scheduleTaskDataBase.setStartDate(scheduleTask.StartDate);
	scheduleTaskDataBase.setEndDate(scheduleTask.EndDate);
	scheduleTaskDataBase.setStartShift(scheduleTask.StartShift);
    scheduleTaskDataBase.setTaskId(scheduleTask.TaskId);
    scheduleTaskDataBase.setHours(scheduleTask.Hours);
    scheduleTaskDataBase.setTotEmployees(scheduleTask.TotEmployees);
    scheduleTaskDataBase.setEmployeeHours(scheduleTask.EmployeeHours);
    scheduleTaskDataBase.setPriority(scheduleTask.Priority);
    scheduleTaskDataBase.setQueue(scheduleTask.Queue);
    scheduleTaskDataBase.setMachId(scheduleTask.MachId);

	return scheduleTaskDataBase;
}

public
ScheduleTask cloneScheduleTask(ScheduleTask scheduleTask){
	ScheduleTask scheduleTaskClone = new ScheduleTask();
    scheduleTaskClone.copy(scheduleTask);

	return scheduleTaskClone;
}

public
HotListView createHotListView(){
	return new HotListView();
}

public
HotListViewContainer createHotListViewContainer(){
	return new HotListViewContainer();
}

public
HotListViewHdr createHotListViewHdr(){
	return new HotListViewHdr();
}

public
HotListViewHdrContainer createHotListViewHdrContainer(){
	return new HotListViewHdrContainer();
}

public
HotListView cloneHotListView(HotListView hotListView){
	HotListView hotListViewClone = new HotListView();

    hotListViewClone.copy(hotListView);

    return hotListViewClone;
}

public
HotListViewContainer processHotListSchedule(int ihotListId,string splantOriginal,string sdept,string smachine, string spart,int iseq,string sreportedPoint){
    try{        
        HotListViewContainer    hotListViewContainer = new HotListViewContainer();
        HotListHdrDataBase      hotListHdrDataBase = new HotListHdrDataBase(dataBaseAccess);
        DateTime                dstartDate = DateTime.Now;      
        Hashtable               hashTable = new Hashtable();
                           
        //read hot list hdr
        if (ihotListId <= 0){ // We get the last hotList, if returns 0 there are not hotHotlist record generated
		    hotListHdrDataBase = new HotListHdrDataBase(dataBaseAccess);
            ihotListId = hotListHdrDataBase.readLastIdByPlant(splantOriginal);
		}
        hotListHdrDataBase.setId(ihotListId);
        if (!hotListHdrDataBase.read())
            return hotListViewContainer;

        dstartDate = hotListHdrDataBase.getHLR_HotlistRunDate();
        //System.Windows.Forms.MessageBox.Show("Hot List StartDate:" + DateUtil.getDateRepresentation(dstartDate,DateUtil.MMDDYYYY));

        //read hot list 
        HotListDataBaseContainer hotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);	
        //hotListDataBaseContainer.read(ihotListId, filterDept, filterPart, filterMg, false, "B");
        hotListDataBaseContainer.readByFilters(ihotListId, "", sdept, smachine, 0, spart, iseq,"","",sreportedPoint,"","",false, 0);

        for (int i = 0; i < hotListDataBaseContainer.Count /*&& i < 500*/; i++){
            HotListDataBase hotListDataBase = (HotListDataBase)hotListDataBaseContainer[i];
                                               
            //quantities
            decimal pastDue= hotListDataBase.getHOT_PastDue();
			decimal day001 = hotListDataBase.getHOT_Day001() - hotListDataBase.getHOT_PastDue();
			decimal day002 = hotListDataBase.getHOT_Day002() - hotListDataBase.getHOT_Day001();
			decimal day003 = hotListDataBase.getHOT_Day003() - hotListDataBase.getHOT_Day002();
			decimal day004 = hotListDataBase.getHOT_Day004() - hotListDataBase.getHOT_Day003();
			decimal day005 = hotListDataBase.getHOT_Day005() - hotListDataBase.getHOT_Day004();
			decimal day006 = hotListDataBase.getHOT_Day006() - hotListDataBase.getHOT_Day005();
			decimal day007 = hotListDataBase.getHOT_Day007() - hotListDataBase.getHOT_Day006();
			decimal day008 = hotListDataBase.getHOT_Day008() - hotListDataBase.getHOT_Day007();
			decimal day009 = hotListDataBase.getHOT_Day009() - hotListDataBase.getHOT_Day008();
			decimal day010 = hotListDataBase.getHOT_Day010() - hotListDataBase.getHOT_Day009();
			decimal day011 = hotListDataBase.getHOT_Day011() - hotListDataBase.getHOT_Day010();
			decimal day012 = hotListDataBase.getHOT_Day012() - hotListDataBase.getHOT_Day011();
			decimal day013 = hotListDataBase.getHOT_Day013() - hotListDataBase.getHOT_Day012();
			decimal day014 = hotListDataBase.getHOT_Day014() - hotListDataBase.getHOT_Day013();
			decimal day015 = hotListDataBase.getHOT_Day015() - hotListDataBase.getHOT_Day014();

			decimal day016 = hotListDataBase.getHOT_Day016() - hotListDataBase.getHOT_Day015();
			decimal day017 = hotListDataBase.getHOT_Day017() - hotListDataBase.getHOT_Day016();
			decimal day018 = hotListDataBase.getHOT_Day018() - hotListDataBase.getHOT_Day017();
			decimal day019 = hotListDataBase.getHOT_Day019() - hotListDataBase.getHOT_Day018();
			decimal day020 = hotListDataBase.getHOT_Day020() - hotListDataBase.getHOT_Day019();
			decimal day021 = hotListDataBase.getHOT_Day021() - hotListDataBase.getHOT_Day020();
			decimal day022 = hotListDataBase.getHOT_Day022() - hotListDataBase.getHOT_Day021();
			decimal day023 = hotListDataBase.getHOT_Day023() - hotListDataBase.getHOT_Day022();
			decimal day024 = hotListDataBase.getHOT_Day024() - hotListDataBase.getHOT_Day023();
			decimal day025 = hotListDataBase.getHOT_Day025() - hotListDataBase.getHOT_Day024();
			decimal day026 = hotListDataBase.getHOT_Day026() - hotListDataBase.getHOT_Day025();
			decimal day027 = hotListDataBase.getHOT_Day027() - hotListDataBase.getHOT_Day026();
			decimal day028 = hotListDataBase.getHOT_Day028() - hotListDataBase.getHOT_Day027();
			decimal day029 = hotListDataBase.getHOT_Day029() - hotListDataBase.getHOT_Day028();
			decimal day030 = hotListDataBase.getHOT_Day030() - hotListDataBase.getHOT_Day029();

			decimal day031 = hotListDataBase.getHOT_Day031() - hotListDataBase.getHOT_Day030();
			decimal day032 = hotListDataBase.getHOT_Day032() - hotListDataBase.getHOT_Day031();
			decimal day033 = hotListDataBase.getHOT_Day033() - hotListDataBase.getHOT_Day032();
			decimal day034 = hotListDataBase.getHOT_Day034() - hotListDataBase.getHOT_Day033();
			decimal day035 = hotListDataBase.getHOT_Day035() - hotListDataBase.getHOT_Day034();
			decimal day036 = hotListDataBase.getHOT_Day036() - hotListDataBase.getHOT_Day035();
			decimal day037 = hotListDataBase.getHOT_Day037() - hotListDataBase.getHOT_Day036();
			decimal day038 = hotListDataBase.getHOT_Day038() - hotListDataBase.getHOT_Day037();
			decimal day039 = hotListDataBase.getHOT_Day039() - hotListDataBase.getHOT_Day038();
			decimal day040 = hotListDataBase.getHOT_Day040() - hotListDataBase.getHOT_Day039();
			decimal day041 = hotListDataBase.getHOT_Day041() - hotListDataBase.getHOT_Day040();
			decimal day042 = hotListDataBase.getHOT_Day042() - hotListDataBase.getHOT_Day041();
			decimal day043 = hotListDataBase.getHOT_Day043() - hotListDataBase.getHOT_Day042();
			decimal day044 = hotListDataBase.getHOT_Day044() - hotListDataBase.getHOT_Day043();
			decimal day045 = hotListDataBase.getHOT_Day045() - hotListDataBase.getHOT_Day044();
				
			decimal day046 = hotListDataBase.getHOT_Day046() - hotListDataBase.getHOT_Day045();
			decimal day047 = hotListDataBase.getHOT_Day047() - hotListDataBase.getHOT_Day046();
			decimal day048 = hotListDataBase.getHOT_Day048() - hotListDataBase.getHOT_Day047();
			decimal day049 = hotListDataBase.getHOT_Day049() - hotListDataBase.getHOT_Day048();
			decimal day050 = hotListDataBase.getHOT_Day050() - hotListDataBase.getHOT_Day049();
			decimal day051 = hotListDataBase.getHOT_Day051() - hotListDataBase.getHOT_Day050();
			decimal day052 = hotListDataBase.getHOT_Day052() - hotListDataBase.getHOT_Day051();
			decimal day053 = hotListDataBase.getHOT_Day053() - hotListDataBase.getHOT_Day052();
			decimal day054 = hotListDataBase.getHOT_Day054() - hotListDataBase.getHOT_Day053();
			decimal day055 = hotListDataBase.getHOT_Day055() - hotListDataBase.getHOT_Day054();
			decimal day056 = hotListDataBase.getHOT_Day056() - hotListDataBase.getHOT_Day055();
			decimal day057 = hotListDataBase.getHOT_Day057() - hotListDataBase.getHOT_Day056();
			decimal day058 = hotListDataBase.getHOT_Day058() - hotListDataBase.getHOT_Day057();
			decimal day059 = hotListDataBase.getHOT_Day059() - hotListDataBase.getHOT_Day058();
			decimal day060 = hotListDataBase.getHOT_Day060() - hotListDataBase.getHOT_Day059();
            
            //AF 061 to 090
			decimal day061 = hotListDataBase.getHOT_Day061() - hotListDataBase.getHOT_Day060();
			decimal day062 = hotListDataBase.getHOT_Day062() - hotListDataBase.getHOT_Day061();
			decimal day063 = hotListDataBase.getHOT_Day063() - hotListDataBase.getHOT_Day062();
			decimal day064 = hotListDataBase.getHOT_Day064() - hotListDataBase.getHOT_Day063();
			decimal day065 = hotListDataBase.getHOT_Day065() - hotListDataBase.getHOT_Day064();
			decimal day066 = hotListDataBase.getHOT_Day066() - hotListDataBase.getHOT_Day065();
			decimal day067 = hotListDataBase.getHOT_Day067() - hotListDataBase.getHOT_Day066();
			decimal day068 = hotListDataBase.getHOT_Day068() - hotListDataBase.getHOT_Day067();
			decimal day069 = hotListDataBase.getHOT_Day069() - hotListDataBase.getHOT_Day068();
			decimal day070 = hotListDataBase.getHOT_Day070() - hotListDataBase.getHOT_Day069();

            decimal day071 = hotListDataBase.getHOT_Day071() - hotListDataBase.getHOT_Day070();
			decimal day072 = hotListDataBase.getHOT_Day072() - hotListDataBase.getHOT_Day071();
			decimal day073 = hotListDataBase.getHOT_Day073() - hotListDataBase.getHOT_Day072();
			decimal day074 = hotListDataBase.getHOT_Day074() - hotListDataBase.getHOT_Day073();
			decimal day075 = hotListDataBase.getHOT_Day075() - hotListDataBase.getHOT_Day074();
			decimal day076 = hotListDataBase.getHOT_Day076() - hotListDataBase.getHOT_Day075();
			decimal day077 = hotListDataBase.getHOT_Day077() - hotListDataBase.getHOT_Day076();
			decimal day078 = hotListDataBase.getHOT_Day078() - hotListDataBase.getHOT_Day077();
			decimal day079 = hotListDataBase.getHOT_Day079() - hotListDataBase.getHOT_Day078();
			decimal day080 = hotListDataBase.getHOT_Day080() - hotListDataBase.getHOT_Day079();

            decimal day081 = hotListDataBase.getHOT_Day081() - hotListDataBase.getHOT_Day080();
			decimal day082 = hotListDataBase.getHOT_Day082() - hotListDataBase.getHOT_Day081();
			decimal day083 = hotListDataBase.getHOT_Day083() - hotListDataBase.getHOT_Day082();
			decimal day084 = hotListDataBase.getHOT_Day084() - hotListDataBase.getHOT_Day083();
			decimal day085 = hotListDataBase.getHOT_Day085() - hotListDataBase.getHOT_Day084();
			decimal day086 = hotListDataBase.getHOT_Day086() - hotListDataBase.getHOT_Day085();
			decimal day087 = hotListDataBase.getHOT_Day087() - hotListDataBase.getHOT_Day086();
			decimal day088 = hotListDataBase.getHOT_Day088() - hotListDataBase.getHOT_Day087();
			decimal day089 = hotListDataBase.getHOT_Day089() - hotListDataBase.getHOT_Day088();
			decimal day090 = hotListDataBase.getHOT_Day090() - hotListDataBase.getHOT_Day089();

                    
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, pastDue,dstartDate.AddDays(-1));
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day001, dstartDate            );
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day002, dstartDate.AddDays(1) );
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day003, dstartDate.AddDays(2) );
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day004, dstartDate.AddDays(3) );
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day005, dstartDate.AddDays(4) );
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day006, dstartDate.AddDays(5) );
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day007, dstartDate.AddDays(6) );
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day008, dstartDate.AddDays(7) );
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day009, dstartDate.AddDays(8) );
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day010, dstartDate.AddDays(9) );

            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day011, dstartDate.AddDays(10));
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day012, dstartDate.AddDays(11));
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day013, dstartDate.AddDays(12));
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day014, dstartDate.AddDays(13));
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day015, dstartDate.AddDays(14));
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day016, dstartDate.AddDays(15));
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day017, dstartDate.AddDays(16));
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day018, dstartDate.AddDays(17));
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day019, dstartDate.AddDays(18));
            summarizeHotListByPartSeqDate(hotListDataBase,hotListViewContainer,hashTable, day020, dstartDate.AddDays(19));

            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day021, dstartDate.AddDays(20));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day022, dstartDate.AddDays(21));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day023, dstartDate.AddDays(22));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day024, dstartDate.AddDays(23));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day025, dstartDate.AddDays(24));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day026, dstartDate.AddDays(25));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day027, dstartDate.AddDays(26));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day028, dstartDate.AddDays(27));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day029, dstartDate.AddDays(28));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day030, dstartDate.AddDays(29));

            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day031, dstartDate.AddDays(30));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day032, dstartDate.AddDays(31));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day033, dstartDate.AddDays(32));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day034, dstartDate.AddDays(33));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day035, dstartDate.AddDays(34));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day036, dstartDate.AddDays(35));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day037, dstartDate.AddDays(36));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day038, dstartDate.AddDays(37));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day039, dstartDate.AddDays(38));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day040, dstartDate.AddDays(39));

            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day041, dstartDate.AddDays(40));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day042, dstartDate.AddDays(41));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day043, dstartDate.AddDays(42));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day044, dstartDate.AddDays(43));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day045, dstartDate.AddDays(44));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day046, dstartDate.AddDays(45));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day047, dstartDate.AddDays(46));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day048, dstartDate.AddDays(47));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day049, dstartDate.AddDays(48));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day050, dstartDate.AddDays(49));

            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day051, dstartDate.AddDays(50));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day052, dstartDate.AddDays(51));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day053, dstartDate.AddDays(52));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day054, dstartDate.AddDays(53));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day055, dstartDate.AddDays(54));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day056, dstartDate.AddDays(55));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day057, dstartDate.AddDays(56));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day058, dstartDate.AddDays(57));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day059, dstartDate.AddDays(58));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day060, dstartDate.AddDays(59));

            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day061, dstartDate.AddDays(60));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day062, dstartDate.AddDays(61));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day063, dstartDate.AddDays(62));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day064, dstartDate.AddDays(63));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day065, dstartDate.AddDays(64));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day066, dstartDate.AddDays(65));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day067, dstartDate.AddDays(66));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day068, dstartDate.AddDays(67));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day069, dstartDate.AddDays(68));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day070, dstartDate.AddDays(69));

            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day071, dstartDate.AddDays(70));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day072, dstartDate.AddDays(71));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day073, dstartDate.AddDays(72));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day074, dstartDate.AddDays(73));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day075, dstartDate.AddDays(74));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day076, dstartDate.AddDays(75));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day077, dstartDate.AddDays(76));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day078, dstartDate.AddDays(77));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day079, dstartDate.AddDays(78));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day080, dstartDate.AddDays(79));

            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day081, dstartDate.AddDays(80));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day082, dstartDate.AddDays(81));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day083, dstartDate.AddDays(82));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day084, dstartDate.AddDays(83));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day085, dstartDate.AddDays(84));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day086, dstartDate.AddDays(85));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day087, dstartDate.AddDays(86));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day088, dstartDate.AddDays(87));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day089, dstartDate.AddDays(88));
            summarizeHotListByPartSeqDate( hotListDataBase,hotListViewContainer,hashTable, day090, dstartDate.AddDays(89));

            //hotListDataBase.setHOT_Qoh(hotListDataBase.getHOT_Qoh() / runStd);
            
        }
       
	    return hotListViewContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}

}

private
void summarizeHotListByPartSeqDate(HotListDataBase hotListDataBase,HotListViewContainer hotListViewContainer,
                                   Hashtable hashTable,decimal dqty,DateTime date){

    if (dqty != 0){        
        HotListView hotListView = null;
        HotListView hotListViewChild = null;
        DateTime    priorMonday = date;
        DateTime    nextSunday = date;
        DateTime    pastDue = DateTime.Now;       
        string      splant = hotListDataBase.getHOT_Plt();                 
        string      sdept = hotListDataBase.getHOT_Dept();
        string      smach = hotListDataBase.getHOT_Mach();
        string      spart = hotListDataBase.getHOT_ProdID();
        decimal     dmachCycle = hotListDataBase.getHOT_MachCyc();
        int         iseq = hotListDataBase.getHOT_Seq();        
        string      skey = "";

        DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now, out pastDue, out nextSunday);        
        pastDue = nextSunday.AddDays(-7);                   

        DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);                

        //if (date <= pastDue)
            //priorMonday = nextSunday= pastDue;
                   
        skey = sdept + "-" + smach + "-" + DateUtil.getCompleteDateRepresentation(priorMonday,DateUtil.MMDDYYYY);
        if (hashTable.Contains(skey))
            hotListView = (HotListView)hashTable[skey];            

        if (hotListView == null){
            hotListView = new HotListView();

            hotListView.HotListIdAut = hotListDataBase.getHOT_IdAut();  
            hotListView.HotListId = hotListDataBase.getHOT_Id();
            hotListView.Plant = splant;
            hotListView.Dept = sdept;
            hotListView.Mach = smach;
            hotListView.MachCyc = dmachCycle;
            hotListView.StartDate = priorMonday;
            hotListView.EndDate = nextSunday;            
            hotListView.MinorGroup = hotListDataBase.getHOT_MinorGroup();
            hotListView.MajorGroup = hotListDataBase.getHOT_MajorGroup();
            hotListViewContainer.Add(hotListView);
            hashTable.Add(skey,hotListView);

        }
        hotListView.Qty+= System.Math.Abs(dqty);

        //add part/seq as child
        hotListViewChild = hotListView.HotListViewContainer.getByPartSeqDate(spart,iseq, priorMonday);
        if (hotListViewChild==null){
            hotListViewChild = new HotListView();
            hotListViewChild.HotListIdAut = hotListDataBase.getHOT_IdAut();  
            hotListViewChild.HotListId = hotListDataBase.getHOT_Id();
            hotListViewChild.Plant = splant;
            hotListViewChild.Dept = sdept;
            hotListViewChild.Mach = smach;
            hotListView.MachCyc = dmachCycle;
            hotListViewChild.StartDate = priorMonday;
            hotListViewChild.EndDate = nextSunday;
            hotListViewChild.DateTime = date;
            hotListViewChild.ProdID = spart;
            hotListViewChild.Seq = iseq;
            hotListViewChild.Uom = hotListDataBase.getHOT_Uom();
            hotListView.Qoh = hotListDataBase.getHOT_Qoh();
            hotListView.MinorGroup = hotListDataBase.getHOT_MinorGroup();
            hotListView.MajorGroup = hotListDataBase.getHOT_MajorGroup();            
            loadHotListviewScheduled(hotListView); 

            hotListView.HotListViewContainer.Add(hotListViewChild);            
        }
        hotListViewChild.Qty+= System.Math.Abs(dqty);
    }
}

public
ScheduleHdr getIfAlreadyScheduled(int ihotListId,int icapacityHdrId){
    ScheduleHdr scheduleHdr = null;
    try{
        if (icapacityHdrId > 0 || ihotListId > 0){
            ScheduleHdrContainer scheduleHdrContainer = new ScheduleHdrContainer();

            if (ihotListId > 0)
                scheduleHdrContainer = readScheduleHdrByFilters("","", "", 0, ihotListId, DateUtil.MinValue, DateUtil.MinValue, false, 1);//try to get if already exist Schedule for that hotList

            if (icapacityHdrId > 0 && scheduleHdrContainer.Count< 1)
                scheduleHdrContainer = readScheduleHdrByFilters("","","", icapacityHdrId, 0, DateUtil.MinValue,DateUtil.MinValue,false,1);//try to get if already exist Schedule for that capacityreport

            if (scheduleHdrContainer.Count > 0)
                scheduleHdr = scheduleHdrContainer[0];        
        }

    }catch(PersistenceException persistenceException){
	
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
    return scheduleHdr;


}

public
HotListViewContainer getHotListOrderedByDate(int ihotListId,string splantOriginal,string sdept,string smachine){
    try{
        
        HotListViewContainer hotListViewContainer = new HotListViewContainer();
        HotListHdrDataBase  hotListHdrDataBase = new HotListHdrDataBase(dataBaseAccess);
        DateTime            dstartDate = DateTime.Now;
        string[]            filterDept = new string[0];
        string[]            filterPart = new string[0];
        string[]            filterMg  = new string[0];
        Hashtable           hashTable = new Hashtable();

        if (!string.IsNullOrEmpty(sdept)){
            filterDept  = new string[1];   
            filterDept[0] = sdept;
        }            
           
        //read hot list hdr
        if (ihotListId <= 0){ // We get the last hotList, if returns 0 there are not hotHotlist record generated
		    hotListHdrDataBase = new HotListHdrDataBase(dataBaseAccess);
            ihotListId = hotListHdrDataBase.readLastIdByPlant(splantOriginal);
		}
        hotListHdrDataBase.setId(ihotListId);
        if (!hotListHdrDataBase.read())
            return hotListViewContainer;

        dstartDate = hotListHdrDataBase.getHLR_HotlistRunDate();
        //System.Windows.Forms.MessageBox.Show("Hot List StartDate:" + DateUtil.getDateRepresentation(dstartDate,DateUtil.MMDDYYYY));

        //read hot list         
        HotListDataBaseContainer hotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);	
		hotListDataBaseContainer.read(ihotListId, filterDept, filterPart, filterMg, false, "B");

        for (int i = 0; i < hotListDataBaseContainer.Count /*&& i < 500*/; i++){
            HotListDataBase hotListDataBase = (HotListDataBase)hotListDataBaseContainer[i];
                                               
            //quantities
            decimal pastDue= hotListDataBase.getHOT_PastDue();
			decimal day001 = hotListDataBase.getHOT_Day001() - hotListDataBase.getHOT_PastDue();
			decimal day002 = hotListDataBase.getHOT_Day002() - hotListDataBase.getHOT_Day001();
			decimal day003 = hotListDataBase.getHOT_Day003() - hotListDataBase.getHOT_Day002();
			decimal day004 = hotListDataBase.getHOT_Day004() - hotListDataBase.getHOT_Day003();
			decimal day005 = hotListDataBase.getHOT_Day005() - hotListDataBase.getHOT_Day004();
			decimal day006 = hotListDataBase.getHOT_Day006() - hotListDataBase.getHOT_Day005();
			decimal day007 = hotListDataBase.getHOT_Day007() - hotListDataBase.getHOT_Day006();
			decimal day008 = hotListDataBase.getHOT_Day008() - hotListDataBase.getHOT_Day007();
			decimal day009 = hotListDataBase.getHOT_Day009() - hotListDataBase.getHOT_Day008();
			decimal day010 = hotListDataBase.getHOT_Day010() - hotListDataBase.getHOT_Day009();
			decimal day011 = hotListDataBase.getHOT_Day011() - hotListDataBase.getHOT_Day010();
			decimal day012 = hotListDataBase.getHOT_Day012() - hotListDataBase.getHOT_Day011();
			decimal day013 = hotListDataBase.getHOT_Day013() - hotListDataBase.getHOT_Day012();
			decimal day014 = hotListDataBase.getHOT_Day014() - hotListDataBase.getHOT_Day013();
			decimal day015 = hotListDataBase.getHOT_Day015() - hotListDataBase.getHOT_Day014();

			decimal day016 = hotListDataBase.getHOT_Day016() - hotListDataBase.getHOT_Day015();
			decimal day017 = hotListDataBase.getHOT_Day017() - hotListDataBase.getHOT_Day016();
			decimal day018 = hotListDataBase.getHOT_Day018() - hotListDataBase.getHOT_Day017();
			decimal day019 = hotListDataBase.getHOT_Day019() - hotListDataBase.getHOT_Day018();
			decimal day020 = hotListDataBase.getHOT_Day020() - hotListDataBase.getHOT_Day019();
			decimal day021 = hotListDataBase.getHOT_Day021() - hotListDataBase.getHOT_Day020();
			decimal day022 = hotListDataBase.getHOT_Day022() - hotListDataBase.getHOT_Day021();
			decimal day023 = hotListDataBase.getHOT_Day023() - hotListDataBase.getHOT_Day022();
			decimal day024 = hotListDataBase.getHOT_Day024() - hotListDataBase.getHOT_Day023();
			decimal day025 = hotListDataBase.getHOT_Day025() - hotListDataBase.getHOT_Day024();
			decimal day026 = hotListDataBase.getHOT_Day026() - hotListDataBase.getHOT_Day025();
			decimal day027 = hotListDataBase.getHOT_Day027() - hotListDataBase.getHOT_Day026();
			decimal day028 = hotListDataBase.getHOT_Day028() - hotListDataBase.getHOT_Day027();
			decimal day029 = hotListDataBase.getHOT_Day029() - hotListDataBase.getHOT_Day028();
			decimal day030 = hotListDataBase.getHOT_Day030() - hotListDataBase.getHOT_Day029();

			decimal day031 = hotListDataBase.getHOT_Day031() - hotListDataBase.getHOT_Day030();
			decimal day032 = hotListDataBase.getHOT_Day032() - hotListDataBase.getHOT_Day031();
			decimal day033 = hotListDataBase.getHOT_Day033() - hotListDataBase.getHOT_Day032();
			decimal day034 = hotListDataBase.getHOT_Day034() - hotListDataBase.getHOT_Day033();
			decimal day035 = hotListDataBase.getHOT_Day035() - hotListDataBase.getHOT_Day034();
			decimal day036 = hotListDataBase.getHOT_Day036() - hotListDataBase.getHOT_Day035();
			decimal day037 = hotListDataBase.getHOT_Day037() - hotListDataBase.getHOT_Day036();
			decimal day038 = hotListDataBase.getHOT_Day038() - hotListDataBase.getHOT_Day037();
			decimal day039 = hotListDataBase.getHOT_Day039() - hotListDataBase.getHOT_Day038();
			decimal day040 = hotListDataBase.getHOT_Day040() - hotListDataBase.getHOT_Day039();
			decimal day041 = hotListDataBase.getHOT_Day041() - hotListDataBase.getHOT_Day040();
			decimal day042 = hotListDataBase.getHOT_Day042() - hotListDataBase.getHOT_Day041();
			decimal day043 = hotListDataBase.getHOT_Day043() - hotListDataBase.getHOT_Day042();
			decimal day044 = hotListDataBase.getHOT_Day044() - hotListDataBase.getHOT_Day043();
			decimal day045 = hotListDataBase.getHOT_Day045() - hotListDataBase.getHOT_Day044();
				
			decimal day046 = hotListDataBase.getHOT_Day046() - hotListDataBase.getHOT_Day045();
			decimal day047 = hotListDataBase.getHOT_Day047() - hotListDataBase.getHOT_Day046();
			decimal day048 = hotListDataBase.getHOT_Day048() - hotListDataBase.getHOT_Day047();
			decimal day049 = hotListDataBase.getHOT_Day049() - hotListDataBase.getHOT_Day048();
			decimal day050 = hotListDataBase.getHOT_Day050() - hotListDataBase.getHOT_Day049();
			decimal day051 = hotListDataBase.getHOT_Day051() - hotListDataBase.getHOT_Day050();
			decimal day052 = hotListDataBase.getHOT_Day052() - hotListDataBase.getHOT_Day051();
			decimal day053 = hotListDataBase.getHOT_Day053() - hotListDataBase.getHOT_Day052();
			decimal day054 = hotListDataBase.getHOT_Day054() - hotListDataBase.getHOT_Day053();
			decimal day055 = hotListDataBase.getHOT_Day055() - hotListDataBase.getHOT_Day054();
			decimal day056 = hotListDataBase.getHOT_Day056() - hotListDataBase.getHOT_Day055();
			decimal day057 = hotListDataBase.getHOT_Day057() - hotListDataBase.getHOT_Day056();
			decimal day058 = hotListDataBase.getHOT_Day058() - hotListDataBase.getHOT_Day057();
			decimal day059 = hotListDataBase.getHOT_Day059() - hotListDataBase.getHOT_Day058();
			decimal day060 = hotListDataBase.getHOT_Day060() - hotListDataBase.getHOT_Day059();
            
            //AF 061 to 090
			decimal day061 = hotListDataBase.getHOT_Day061() - hotListDataBase.getHOT_Day060();
			decimal day062 = hotListDataBase.getHOT_Day062() - hotListDataBase.getHOT_Day061();
			decimal day063 = hotListDataBase.getHOT_Day063() - hotListDataBase.getHOT_Day062();
			decimal day064 = hotListDataBase.getHOT_Day064() - hotListDataBase.getHOT_Day063();
			decimal day065 = hotListDataBase.getHOT_Day065() - hotListDataBase.getHOT_Day064();
			decimal day066 = hotListDataBase.getHOT_Day066() - hotListDataBase.getHOT_Day065();
			decimal day067 = hotListDataBase.getHOT_Day067() - hotListDataBase.getHOT_Day066();
			decimal day068 = hotListDataBase.getHOT_Day068() - hotListDataBase.getHOT_Day067();
			decimal day069 = hotListDataBase.getHOT_Day069() - hotListDataBase.getHOT_Day068();
			decimal day070 = hotListDataBase.getHOT_Day070() - hotListDataBase.getHOT_Day069();

            decimal day071 = hotListDataBase.getHOT_Day071() - hotListDataBase.getHOT_Day070();
			decimal day072 = hotListDataBase.getHOT_Day072() - hotListDataBase.getHOT_Day071();
			decimal day073 = hotListDataBase.getHOT_Day073() - hotListDataBase.getHOT_Day072();
			decimal day074 = hotListDataBase.getHOT_Day074() - hotListDataBase.getHOT_Day073();
			decimal day075 = hotListDataBase.getHOT_Day075() - hotListDataBase.getHOT_Day074();
			decimal day076 = hotListDataBase.getHOT_Day076() - hotListDataBase.getHOT_Day075();
			decimal day077 = hotListDataBase.getHOT_Day077() - hotListDataBase.getHOT_Day076();
			decimal day078 = hotListDataBase.getHOT_Day078() - hotListDataBase.getHOT_Day077();
			decimal day079 = hotListDataBase.getHOT_Day079() - hotListDataBase.getHOT_Day078();
			decimal day080 = hotListDataBase.getHOT_Day080() - hotListDataBase.getHOT_Day079();

            decimal day081 = hotListDataBase.getHOT_Day081() - hotListDataBase.getHOT_Day080();
			decimal day082 = hotListDataBase.getHOT_Day082() - hotListDataBase.getHOT_Day081();
			decimal day083 = hotListDataBase.getHOT_Day083() - hotListDataBase.getHOT_Day082();
			decimal day084 = hotListDataBase.getHOT_Day084() - hotListDataBase.getHOT_Day083();
			decimal day085 = hotListDataBase.getHOT_Day085() - hotListDataBase.getHOT_Day084();
			decimal day086 = hotListDataBase.getHOT_Day086() - hotListDataBase.getHOT_Day085();
			decimal day087 = hotListDataBase.getHOT_Day087() - hotListDataBase.getHOT_Day086();
			decimal day088 = hotListDataBase.getHOT_Day088() - hotListDataBase.getHOT_Day087();
			decimal day089 = hotListDataBase.getHOT_Day089() - hotListDataBase.getHOT_Day088();
			decimal day090 = hotListDataBase.getHOT_Day090() - hotListDataBase.getHOT_Day089();

                    
            convertToView(hotListDataBase,hotListViewContainer, pastDue,dstartDate.AddDays(-1));
            convertToView(hotListDataBase,hotListViewContainer, day001, dstartDate            );
            convertToView(hotListDataBase,hotListViewContainer, day002, dstartDate.AddDays(1) );
            convertToView(hotListDataBase,hotListViewContainer, day003, dstartDate.AddDays(2) );
            convertToView(hotListDataBase,hotListViewContainer, day004, dstartDate.AddDays(3) );
            convertToView(hotListDataBase,hotListViewContainer, day005, dstartDate.AddDays(4) );
            convertToView(hotListDataBase,hotListViewContainer, day006, dstartDate.AddDays(5) );
            convertToView(hotListDataBase,hotListViewContainer, day007, dstartDate.AddDays(6) );
            convertToView(hotListDataBase,hotListViewContainer, day008, dstartDate.AddDays(7) );
            convertToView(hotListDataBase,hotListViewContainer, day009, dstartDate.AddDays(8) );
            convertToView(hotListDataBase,hotListViewContainer, day010, dstartDate.AddDays(9) );

            convertToView(hotListDataBase,hotListViewContainer, day011, dstartDate.AddDays(10));
            convertToView(hotListDataBase,hotListViewContainer, day012, dstartDate.AddDays(11));
            convertToView(hotListDataBase,hotListViewContainer, day013, dstartDate.AddDays(12));
            convertToView(hotListDataBase,hotListViewContainer, day014, dstartDate.AddDays(13));
            convertToView(hotListDataBase,hotListViewContainer, day015, dstartDate.AddDays(14));
            convertToView(hotListDataBase,hotListViewContainer, day016, dstartDate.AddDays(15));
            convertToView(hotListDataBase,hotListViewContainer, day017, dstartDate.AddDays(16));
            convertToView(hotListDataBase,hotListViewContainer, day018, dstartDate.AddDays(17));
            convertToView(hotListDataBase,hotListViewContainer, day019, dstartDate.AddDays(18));
            convertToView(hotListDataBase,hotListViewContainer, day020, dstartDate.AddDays(19));

            convertToView( hotListDataBase,hotListViewContainer, day021, dstartDate.AddDays(20));
            convertToView( hotListDataBase,hotListViewContainer, day022, dstartDate.AddDays(21));
            convertToView( hotListDataBase,hotListViewContainer, day023, dstartDate.AddDays(22));
            convertToView( hotListDataBase,hotListViewContainer, day024, dstartDate.AddDays(23));
            convertToView( hotListDataBase,hotListViewContainer, day025, dstartDate.AddDays(24));
            convertToView( hotListDataBase,hotListViewContainer, day026, dstartDate.AddDays(25));
            convertToView( hotListDataBase,hotListViewContainer, day027, dstartDate.AddDays(26));
            convertToView( hotListDataBase,hotListViewContainer, day028, dstartDate.AddDays(27));
            convertToView( hotListDataBase,hotListViewContainer, day029, dstartDate.AddDays(28));
            convertToView( hotListDataBase,hotListViewContainer, day030, dstartDate.AddDays(29));

            convertToView( hotListDataBase,hotListViewContainer, day031, dstartDate.AddDays(30));
            convertToView( hotListDataBase,hotListViewContainer, day032, dstartDate.AddDays(31));
            convertToView( hotListDataBase,hotListViewContainer, day033, dstartDate.AddDays(32));
            convertToView( hotListDataBase,hotListViewContainer, day034, dstartDate.AddDays(33));
            convertToView( hotListDataBase,hotListViewContainer, day035, dstartDate.AddDays(34));
            convertToView( hotListDataBase,hotListViewContainer, day036, dstartDate.AddDays(35));
            convertToView( hotListDataBase,hotListViewContainer, day037, dstartDate.AddDays(36));
            convertToView( hotListDataBase,hotListViewContainer, day038, dstartDate.AddDays(37));
            convertToView( hotListDataBase,hotListViewContainer, day039, dstartDate.AddDays(38));
            convertToView( hotListDataBase,hotListViewContainer, day040, dstartDate.AddDays(39));

            convertToView( hotListDataBase,hotListViewContainer, day041, dstartDate.AddDays(40));
            convertToView( hotListDataBase,hotListViewContainer, day042, dstartDate.AddDays(41));
            convertToView( hotListDataBase,hotListViewContainer, day043, dstartDate.AddDays(42));
            convertToView( hotListDataBase,hotListViewContainer, day044, dstartDate.AddDays(43));
            convertToView( hotListDataBase,hotListViewContainer, day045, dstartDate.AddDays(44));
            convertToView( hotListDataBase,hotListViewContainer, day046, dstartDate.AddDays(45));
            convertToView( hotListDataBase,hotListViewContainer, day047, dstartDate.AddDays(46));
            convertToView( hotListDataBase,hotListViewContainer, day048, dstartDate.AddDays(47));
            convertToView( hotListDataBase,hotListViewContainer, day049, dstartDate.AddDays(48));
            convertToView( hotListDataBase,hotListViewContainer, day050, dstartDate.AddDays(49));

            convertToView( hotListDataBase,hotListViewContainer, day051, dstartDate.AddDays(50));
            convertToView( hotListDataBase,hotListViewContainer, day052, dstartDate.AddDays(51));
            convertToView( hotListDataBase,hotListViewContainer, day053, dstartDate.AddDays(52));
            convertToView( hotListDataBase,hotListViewContainer, day054, dstartDate.AddDays(53));
            convertToView( hotListDataBase,hotListViewContainer, day055, dstartDate.AddDays(54));
            convertToView( hotListDataBase,hotListViewContainer, day056, dstartDate.AddDays(55));
            convertToView( hotListDataBase,hotListViewContainer, day057, dstartDate.AddDays(56));
            convertToView( hotListDataBase,hotListViewContainer, day058, dstartDate.AddDays(57));
            convertToView( hotListDataBase,hotListViewContainer, day059, dstartDate.AddDays(58));
            convertToView( hotListDataBase,hotListViewContainer, day060, dstartDate.AddDays(59));

            convertToView( hotListDataBase,hotListViewContainer, day061, dstartDate.AddDays(60));
            convertToView( hotListDataBase,hotListViewContainer, day062, dstartDate.AddDays(61));
            convertToView( hotListDataBase,hotListViewContainer, day063, dstartDate.AddDays(62));
            convertToView( hotListDataBase,hotListViewContainer, day064, dstartDate.AddDays(63));
            convertToView( hotListDataBase,hotListViewContainer, day065, dstartDate.AddDays(64));
            convertToView( hotListDataBase,hotListViewContainer, day066, dstartDate.AddDays(65));
            convertToView( hotListDataBase,hotListViewContainer, day067, dstartDate.AddDays(66));
            convertToView( hotListDataBase,hotListViewContainer, day068, dstartDate.AddDays(67));
            convertToView( hotListDataBase,hotListViewContainer, day069, dstartDate.AddDays(68));
            convertToView( hotListDataBase,hotListViewContainer, day070, dstartDate.AddDays(69));

            convertToView( hotListDataBase,hotListViewContainer, day071, dstartDate.AddDays(70));
            convertToView( hotListDataBase,hotListViewContainer, day072, dstartDate.AddDays(71));
            convertToView( hotListDataBase,hotListViewContainer, day073, dstartDate.AddDays(72));
            convertToView( hotListDataBase,hotListViewContainer, day074, dstartDate.AddDays(73));
            convertToView( hotListDataBase,hotListViewContainer, day075, dstartDate.AddDays(74));
            convertToView( hotListDataBase,hotListViewContainer, day076, dstartDate.AddDays(75));
            convertToView( hotListDataBase,hotListViewContainer, day077, dstartDate.AddDays(76));
            convertToView( hotListDataBase,hotListViewContainer, day078, dstartDate.AddDays(77));
            convertToView( hotListDataBase,hotListViewContainer, day079, dstartDate.AddDays(78));
            convertToView( hotListDataBase,hotListViewContainer, day080, dstartDate.AddDays(79));

            convertToView( hotListDataBase,hotListViewContainer, day081, dstartDate.AddDays(80));
            convertToView( hotListDataBase,hotListViewContainer, day082, dstartDate.AddDays(81));
            convertToView( hotListDataBase,hotListViewContainer, day083, dstartDate.AddDays(82));
            convertToView( hotListDataBase,hotListViewContainer, day084, dstartDate.AddDays(83));
            convertToView( hotListDataBase,hotListViewContainer, day085, dstartDate.AddDays(84));
            convertToView( hotListDataBase,hotListViewContainer, day086, dstartDate.AddDays(85));
            convertToView( hotListDataBase,hotListViewContainer, day087, dstartDate.AddDays(86));
            convertToView( hotListDataBase,hotListViewContainer, day088, dstartDate.AddDays(87));
            convertToView( hotListDataBase,hotListViewContainer, day089, dstartDate.AddDays(88));
            convertToView( hotListDataBase,hotListViewContainer, day090, dstartDate.AddDays(89));
            //hotListDataBase.setHOT_Qoh(hotListDataBase.getHOT_Qoh() / runStd);            
        }       
        hotListViewContainer.sortByDate();

	    return hotListViewContainer;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}

}

private
void convertToView(HotListDataBase hotListDataBase,HotListViewContainer hotListViewContainer,decimal dqty,DateTime date){
    if (dqty != 0){        
        HotListView hotListView = new HotListView();
        DateTime    priorMonday = date;
        DateTime    nextSunday = date;
                      
        DateUtil.getPriorMondayNextSundayFromDate(priorMonday, out priorMonday, out nextSunday);                
                   
        hotListView.HotListIdAut = hotListDataBase.getHOT_IdAut();                 
        hotListView.HotListId = hotListDataBase.getHOT_Id();
        hotListView.Plant = hotListDataBase.getHOT_Plt();
        hotListView.Dept = hotListDataBase.getHOT_Dept();
        hotListView.Mach = hotListDataBase.getHOT_Mach();
        hotListView.MachCyc = hotListDataBase.getHOT_MachCyc();
        hotListView.StartDate = priorMonday;
        hotListView.EndDate = nextSunday;
        hotListView.DateTime = date;
        hotListView.ProdID = hotListDataBase.getHOT_ProdID();
        hotListView.Seq = hotListDataBase.getHOT_Seq();
        hotListView.Uom = hotListDataBase.getHOT_Uom();
        hotListView.Qty = System.Math.Abs(dqty);
        hotListView.Qoh = hotListDataBase.getHOT_Qoh();
        hotListView.MinorGroup = hotListDataBase.getHOT_MinorGroup();
        hotListView.MajorGroup = hotListDataBase.getHOT_MajorGroup();        
        loadHotListviewScheduled(hotListView);             
                    
        hotListViewContainer.Add(hotListView);
    }                                   
}

private
void loadHotListviewScheduled(HotListView hotListView){
    SchedulePartDataBaseContainer schedulePartDataBaseContainer = new SchedulePartDataBaseContainer(dataBaseAccess);                                       
    schedulePartDataBaseContainer.readByFilters(0, hotListView.HotListIdAut);
    if (schedulePartDataBaseContainer.Count > 0)
        hotListView.Scheduled = Constants.STRING_YES;  
}

public
void moveDatesFromSchedulePartTask(ScheduleHdr scheduleHdr,ScheduleReqViewContainer scheduleReqViewContainer, ScheduleReqView scheduleReqViewSelected){
    try{     
        bool                        bstartMove = false;       
        DateTime                    lastEndDate = DateUtil.MinValue; 
        decimal                     dhours = 0;                                  
        BomSumContainer             matBomSumContainer = new BomSumContainer();         
        int                         ireqId = 0;                           
        string                      type = "";
        DateTime                    startDate = DateUtil.MinValue;
        DateTime                    endDate = DateUtil.MinValue;
        ScheduleReqView             scheduleReqViewLast = null;

        if (scheduleHdr!= null && scheduleReqViewSelected!= null){
            ireqId  = scheduleReqViewSelected.MachId;  //get req id and type
            type    = scheduleReqViewSelected.ScheduleType;

            for (int i=0; i < scheduleReqViewContainer.Count;i++){
                ScheduleReqView scheduleReqView = scheduleReqViewContainer[i];

                if (ireqId == scheduleReqView.MachId && type.Equals(scheduleReqView.ScheduleType)){ //only adjust part/tasks from similar req id/scheduletype

                    if (scheduleReqView.Equals(scheduleReqViewSelected)) { 
                        bstartMove = true;           
                        lastEndDate = scheduleReqViewSelected.EndDate;                                     
                    }

                    if (bstartMove){ 
                        if (lastEndDate > scheduleReqView.StartDate)  {  //check if need to be moved
                            lastEndDate = scheduleReqView.EndDate;

                            if (scheduleReqView.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_PART)){ 
                                SchedulePart schedulePart = scheduleHdr.getSchedulePart(scheduleReqView);
                                if (schedulePart!= null){ 
                                    dhours= schedulePart.HoursSubtract;
                                    schedulePart.StartDate = lastEndDate;
                                    schedulePart.EndDate = schedulePart.StartDate.AddHours(Convert.ToDouble(dhours));

                                    matBomSumContainer = getSubMaterialsMainLevelAndLowerSeqButNotLowerBom(schedulePart.Part, schedulePart.Seq,scheduleHdr.Plant,Constants.STRING_YES,1);
                                    generateAutomaticReceiptPart(schedulePart);
                                    generateAutomaticMaterialConsumition(schedulePart,matBomSumContainer);                                
                                    lastEndDate= schedulePart.EndDate;
                                }
                            }else if (scheduleReqView.ScheduleType.Equals(ScheduleReqView.SCHEDULE_TYPE_TASK)){ 
                                ScheduleTask scheduleTask = scheduleHdr.getScheduleTask(scheduleReqView);
                                if (scheduleTask != null){ 
                                    dhours= scheduleTask.HoursSubtract;
                                    scheduleTask.StartDate = lastEndDate;
                                    scheduleTask.EndDate = scheduleTask.StartDate.AddHours(Convert.ToDouble(dhours));                        
                                    lastEndDate= scheduleTask.EndDate;
                                }
                            }
                        }
                    }
                }
            }

            if (scheduleHdr.Id > 0)
                updateScheduleHdr(scheduleHdr);
            else
                writeScheduleHdr(scheduleHdr);
      }  

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

/******************************************************** ScheduleReceiptPart *****************************************************/

public
ScheduleReceiptPart createScheduleReceiptPart(){
	return new ScheduleReceiptPart();
}

public
ScheduleReceiptPartContainer createScheduleReceiptPartContainer(){
	return new ScheduleReceiptPartContainer();
}

private
ScheduleReceiptPart objectDataBaseToObject(ScheduleReceiptPartDataBase scheduleReceiptPartDataBase){
	ScheduleReceiptPart scheduleReceiptPart = new ScheduleReceiptPart();

	scheduleReceiptPart.HdrId=scheduleReceiptPartDataBase.getHdrId();
	scheduleReceiptPart.Detail=scheduleReceiptPartDataBase.getDetail();
	scheduleReceiptPart.SubDetail=scheduleReceiptPartDataBase.getSubDetail();    
    scheduleReceiptPart.StartDate = scheduleReceiptPartDataBase.getStartDate();
	scheduleReceiptPart.RecDate=scheduleReceiptPartDataBase.getRecDate();
	scheduleReceiptPart.RecShift=scheduleReceiptPartDataBase.getRecShift();
	scheduleReceiptPart.RecQty=scheduleReceiptPartDataBase.getRecQty();
    scheduleReceiptPart.RepQty=scheduleReceiptPartDataBase.getRepQty();

    if (scheduleReceiptPartDataBase is ScheduleReceiptPartViewDataBase) {               
        ScheduleReceiptPartViewDataBase scheduleReceiptPartViewDataBase = (ScheduleReceiptPartViewDataBase)scheduleReceiptPartDataBase;
        scheduleReceiptPart.Part = scheduleReceiptPartViewDataBase.getPart();
        scheduleReceiptPart.Seq  = scheduleReceiptPartViewDataBase.getSeq();
    }

	return scheduleReceiptPart;
}

private
ScheduleReceiptPartDataBase objectToObjectDataBase(ScheduleReceiptPart scheduleReceiptPart){
	ScheduleReceiptPartDataBase scheduleReceiptPartDataBase = new ScheduleReceiptPartDataBase(dataBaseAccess);
	scheduleReceiptPartDataBase.setHdrId(scheduleReceiptPart.HdrId);
	scheduleReceiptPartDataBase.setDetail(scheduleReceiptPart.Detail);
	scheduleReceiptPartDataBase.setSubDetail(scheduleReceiptPart.SubDetail);    
    scheduleReceiptPartDataBase.setStartDate(scheduleReceiptPart.StartDate);
	scheduleReceiptPartDataBase.setRecDate(scheduleReceiptPart.RecDate);
	scheduleReceiptPartDataBase.setRecShift(scheduleReceiptPart.RecShift);
	scheduleReceiptPartDataBase.setRecQty(scheduleReceiptPart.RecQty);
    scheduleReceiptPartDataBase.setRepQty(scheduleReceiptPart.RepQty);

	return scheduleReceiptPartDataBase;
}

public
ScheduleReceiptPart cloneScheduleReceiptPart(ScheduleReceiptPart scheduleReceiptPart){
	ScheduleReceiptPart scheduleReceiptPartClone = new ScheduleReceiptPart();
    scheduleReceiptPartClone.copy(scheduleReceiptPart);
    return scheduleReceiptPartClone;
}

public
ScheduleReceiptPartContainer getReceiptPartContainerByFilters(int ischeduleId,string splantOriginal, string spart,int seq,string smachine,int imachineId,DateTime startDate,DateTime endDate){
    try { 
        ScheduleReceiptPartContainer    scheduleReceiptPartContainer   = new ScheduleReceiptPartContainer();    
        ScheduleReceiptPart             scheduleReceiptPart= null;
        Hashtable                       hashtable = new Hashtable();
            
        int ischeduleIdAux  = ischeduleId;
        if (ischeduleIdAux <=0)
            ischeduleIdAux = getLastScheduleHdrIdByPlant(splantOriginal);
           
        if (ischeduleIdAux > 0){
            ScheduleReceiptPartViewDataBaseContainer scheduleReceiptPartViewDataBaseContainer = new ScheduleReceiptPartViewDataBaseContainer(dataBaseAccess);
            scheduleReceiptPartViewDataBaseContainer.readByFilters(ischeduleIdAux,spart,seq,smachine,imachineId,startDate, endDate);

            foreach(ScheduleReceiptPartViewDataBase scheduleReceiptPartViewDataBase in scheduleReceiptPartViewDataBaseContainer){
                scheduleReceiptPart = objectDataBaseToObject(scheduleReceiptPartViewDataBase);
                scheduleReceiptPartContainer.Add(scheduleReceiptPart);
            }       
        }

        return scheduleReceiptPartContainer;


    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
ScheduleReceiptPartContainer getReceiptPartByFilters(int id,string splant,int imachId,string part,int iseq,DateTime startDate,DateTime endDate){
    try { 
        int                                     idAux = id;
        ScheduleReceiptPartContainer            scheduleReceiptPartContainer   = new ScheduleReceiptPartContainer();    
        ScheduleReceiptPartDataBaseContainer scheduleReceiptPartDataBaseContainer = new ScheduleReceiptPartDataBaseContainer(dataBaseAccess);
        
        if (idAux <= 0)
            idAux = getLastScheduleHdrIdByPlant(splant);
   
        scheduleReceiptPartDataBaseContainer.readByFilters(idAux,imachId, part, iseq, startDate, endDate);

        foreach(ScheduleReceiptPartDataBase scheduleReceiptPartDataBase in scheduleReceiptPartDataBaseContainer){
            ScheduleReceiptPart scheduleReceiptPart = objectDataBaseToObject(scheduleReceiptPartDataBase);
            scheduleReceiptPartContainer.Add(scheduleReceiptPart);
        }       
        
        return scheduleReceiptPartContainer;

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

  

/********************************************* ScheduleMaterialConsumPart ********************************************/
public
ScheduleMaterialConsumPart createScheduleMaterialConsumPart(){
	return new ScheduleMaterialConsumPart();
}

public
ScheduleMaterialConsumPartContainer createScheduleMaterialConsumPartContainer(){
	return new ScheduleMaterialConsumPartContainer();
}  

private
ScheduleMaterialConsumPart objectDataBaseToObject(ScheduleMaterialConsumPartDataBase scheduleMaterialConsumPartDataBase){
	ScheduleMaterialConsumPart scheduleMaterialConsumPart = new ScheduleMaterialConsumPart();

	scheduleMaterialConsumPart.HdrId=scheduleMaterialConsumPartDataBase.getHdrId();
	scheduleMaterialConsumPart.Detail=scheduleMaterialConsumPartDataBase.getDetail();
	scheduleMaterialConsumPart.SubDetail=scheduleMaterialConsumPartDataBase.getSubDetail();
	scheduleMaterialConsumPart.SubSubDetail=scheduleMaterialConsumPartDataBase.getSubSubDetail();	
	scheduleMaterialConsumPart.MatPart=scheduleMaterialConsumPartDataBase.getMatPart();
	scheduleMaterialConsumPart.MatSeq=scheduleMaterialConsumPartDataBase.getMatSeq();
	scheduleMaterialConsumPart.QtyReq=scheduleMaterialConsumPartDataBase.getQtyReq();
	scheduleMaterialConsumPart.QtyReported=scheduleMaterialConsumPartDataBase.getQtyReported();
	scheduleMaterialConsumPart.QtyConsum=scheduleMaterialConsumPartDataBase.getQtyConsum();
	scheduleMaterialConsumPart.MatType=scheduleMaterialConsumPartDataBase.getMatType();

    if (scheduleMaterialConsumPartDataBase is ScheduleMaterialConsumPartViewDataBase) {
        ScheduleMaterialConsumPartViewDataBase scheduleMaterialConsumPartViewDataBase = (ScheduleMaterialConsumPartViewDataBase)scheduleMaterialConsumPartDataBase;
        scheduleMaterialConsumPart.StartDate = scheduleMaterialConsumPartViewDataBase.getStartDate();        
    }

	return scheduleMaterialConsumPart;
}

private
ScheduleMaterialConsumPartDataBase objectToObjectDataBase(ScheduleMaterialConsumPart scheduleMaterialConsumPart){
	ScheduleMaterialConsumPartDataBase scheduleMaterialConsumPartDataBase = new ScheduleMaterialConsumPartDataBase(dataBaseAccess);
	scheduleMaterialConsumPartDataBase.setHdrId(scheduleMaterialConsumPart.HdrId);
	scheduleMaterialConsumPartDataBase.setDetail(scheduleMaterialConsumPart.Detail);
	scheduleMaterialConsumPartDataBase.setSubDetail(scheduleMaterialConsumPart.SubDetail);
	scheduleMaterialConsumPartDataBase.setSubSubDetail(scheduleMaterialConsumPart.SubSubDetail);	
	scheduleMaterialConsumPartDataBase.setMatPart(scheduleMaterialConsumPart.MatPart);
	scheduleMaterialConsumPartDataBase.setMatSeq(scheduleMaterialConsumPart.MatSeq);
	scheduleMaterialConsumPartDataBase.setQtyReq(scheduleMaterialConsumPart.QtyReq);
	scheduleMaterialConsumPartDataBase.setQtyReported(scheduleMaterialConsumPart.QtyReported);
	scheduleMaterialConsumPartDataBase.setQtyConsum(scheduleMaterialConsumPart.QtyConsum);
	scheduleMaterialConsumPartDataBase.setMatType(scheduleMaterialConsumPart.MatType);

	return scheduleMaterialConsumPartDataBase;
}

public
ScheduleMaterialConsumPart cloneScheduleMaterialConsumPart(ScheduleMaterialConsumPart scheduleMaterialConsumPart){
	ScheduleMaterialConsumPart scheduleMaterialConsumPartClone = new ScheduleMaterialConsumPart();
    scheduleMaterialConsumPartClone.copy(scheduleMaterialConsumPart);
	
	return scheduleMaterialConsumPartClone;
}

public
ScheduleMaterialConsumPartContainer getMaterialConsumPartContainerByFilters(int ischeduleId,string splantOriginal, string spart,int seq,string smachine,int imachineId,DateTime startDate,DateTime endDate){
    try { 
        ScheduleMaterialConsumPartContainer     scheduleMaterialConsumPartContainer = new ScheduleMaterialConsumPartContainer();    
        ScheduleMaterialConsumPart              scheduleMaterialConsumPart= null;    
    
        int ischeduleIdAux  = ischeduleId;
        if (ischeduleIdAux <=0){
            ScheduleHdrDataBase scheduleHdrDataBase = new ScheduleHdrDataBase(dataBaseAccess);
            if (scheduleHdrDataBase.readLastByFilter(splantOriginal))
                ischeduleIdAux = scheduleHdrDataBase.getId();
        }

        if (ischeduleIdAux > 0){
            ScheduleMaterialConsumPartViewDataBaseContainer scheduleMaterialConsumPartViewDataBaseContainer = new ScheduleMaterialConsumPartViewDataBaseContainer(dataBaseAccess);
            scheduleMaterialConsumPartViewDataBaseContainer.readByFilters(ischeduleIdAux,spart,seq,smachine,imachineId,startDate, endDate);

            foreach(ScheduleMaterialConsumPartViewDataBase scheduleMaterialConsumPartViewDataBase in scheduleMaterialConsumPartViewDataBaseContainer){
                scheduleMaterialConsumPart = objectDataBaseToObject(scheduleMaterialConsumPartViewDataBase);
                scheduleMaterialConsumPartContainer.Add(scheduleMaterialConsumPart);
            }       
        }

        return scheduleMaterialConsumPartContainer;


    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

/********************************************* ScheduleDown ****************************************************************************/
public
ScheduleDown createScheduleDown(){
	return new ScheduleDown();
}

public
ScheduleDownContainer createScheduleDownContainer(){
	return new ScheduleDownContainer();
}

private
ScheduleDown objectDataBaseToObject(ScheduleDownDataBase scheduleDownDataBase){
	ScheduleDown scheduleDown = new ScheduleDown();

	scheduleDown.HdrId=scheduleDownDataBase.getHdrId();
	scheduleDown.Detail=scheduleDownDataBase.getDetail();	
	scheduleDown.StartDate=scheduleDownDataBase.getStartDate();
	scheduleDown.EndDate=scheduleDownDataBase.getEndDate();
	scheduleDown.StartShift=scheduleDownDataBase.getStartShift();
	scheduleDown.Type=scheduleDownDataBase.getType();
	scheduleDown.TypeName=scheduleDownDataBase.getTypeName();
	scheduleDown.Hours=scheduleDownDataBase.getHours();
	scheduleDown.TotEmployees=scheduleDownDataBase.getTotEmployees();
	scheduleDown.EmployeeHours=scheduleDownDataBase.getEmployeeHours();
	scheduleDown.Priority=scheduleDownDataBase.getPriority();
	scheduleDown.Queue=scheduleDownDataBase.getQueue();
    scheduleDown.MachId = scheduleDownDataBase.getMachId();

	return scheduleDown;
}

private
ScheduleDownDataBase objectToObjectDataBase(ScheduleDown scheduleDown){
	ScheduleDownDataBase scheduleDownDataBase = new ScheduleDownDataBase(dataBaseAccess);
	scheduleDownDataBase.setHdrId(scheduleDown.HdrId);
	scheduleDownDataBase.setDetail(scheduleDown.Detail);	
	scheduleDownDataBase.setStartDate(scheduleDown.StartDate);
	scheduleDownDataBase.setEndDate(scheduleDown.EndDate);
	scheduleDownDataBase.setStartShift(scheduleDown.StartShift);
	scheduleDownDataBase.setType(scheduleDown.Type);
	scheduleDownDataBase.setTypeName(scheduleDown.TypeName);
	scheduleDownDataBase.setHours(scheduleDown.Hours);
	scheduleDownDataBase.setTotEmployees(scheduleDown.TotEmployees);
	scheduleDownDataBase.setEmployeeHours(scheduleDown.EmployeeHours);
	scheduleDownDataBase.setPriority(scheduleDown.Priority);
	scheduleDownDataBase.setQueue(scheduleDown.Queue);
    scheduleDownDataBase.setMachId(scheduleDown.MachId);

	return scheduleDownDataBase;
}

public
ScheduleDown cloneScheduleDown(ScheduleDown scheduleDown){
	ScheduleDown scheduleDownClone = new ScheduleDown();
	scheduleDownClone.copy(scheduleDown);
	return scheduleDownClone;
}


public
string[][] getFutureInventoryByWeek(int id,string splantOriginal,string spartFilter,int iseqFilter,string smachine, int imachineId,string sglExp,DateTime startDate,DateTime endDate,int rows){
    try{
        string[][]                                  items=null;
        string[]                                    item=null;
        int                                         istartWeeK  = DateUtil. weekNumber(startDate);               
        int                                         iendWeeK    = DateUtil. weekNumber(endDate) + (endDate.Year > startDate.Year ? DateUtil.weekNumber( new DateTime(startDate.Year,12,31)) -1 : 0);      
        int                                         imaxIndex   = (iendWeeK - istartWeeK);
        int                                         index       = 0;
        int                                         iweek = 0;
        Hashtable                                   hashInventory= new Hashtable();
        ArrayList                                   arrayList = new ArrayList();
        string                                      skey ="";
        string                                      stype="";
        string                                      spart="";
        int                                         iseq =0;
        decimal                                     dqty =0;
        string                                      sdesc = "";
        DateTime                                    dateRec = DateTime.Now;
        int                                         i=0;
        int                                         isheduleIdAux = id;

        if (isheduleIdAux <= 0)
            isheduleIdAux = getLastScheduleHdrIdByPlant(splantOriginal);

        SchedulePartInventoryViewDataBaseContainer  schedulePartInventoryViewDataBaseContainer = new SchedulePartInventoryViewDataBaseContainer(dataBaseAccess);
        schedulePartInventoryViewDataBaseContainer.readByFilters(isheduleIdAux, spartFilter, iseqFilter, smachine, imachineId, sglExp,startDate, endDate,rows);

        foreach(SchedulePartInventoryViewDataBase schedulePartInventoryViewDataBase in schedulePartInventoryViewDataBaseContainer){
            
            stype   = schedulePartInventoryViewDataBase.getType(); 
            spart   = schedulePartInventoryViewDataBase.getPart();
            iseq    = schedulePartInventoryViewDataBase.getSeq();
            dqty    = (schedulePartInventoryViewDataBase.getRecQty() - schedulePartInventoryViewDataBase.getRepQty());
            dateRec = schedulePartInventoryViewDataBase.getRecDate();
            sdesc   = schedulePartInventoryViewDataBase.getDes1();
            skey    = spart + Constants.DEFAULT_SEP + iseq.ToString();
            
            if (hashInventory.Contains(skey))
                item= (string[])hashInventory[skey];
            else{
                item = initInventoryArray(imaxIndex,spart,iseq, sdesc);
                hashInventory.Add(skey,item);
            }
            iweek = DateUtil.weekNumber(dateRec) + (dateRec.Year > startDate.Year ? DateUtil.weekNumber( new DateTime(startDate.Year,12,31))  +   (dateRec.Day == 1 && dateRec.DayOfWeek == DayOfWeek.Monday ? 0 : - 1) : 0);
            index = (iweek - istartWeeK) + Constants.INDEX_INVENTORY_FUTURE; //  +3 because part/seq/qoh
            if (index < item.Length)
                item[index] = (Convert.ToInt64(item[index]) + Convert.ToInt64(dqty)).ToString();

            if (stype.Equals("QOH"))    //if QOH store on index 2
                item[Constants.INDEX_INVENTORY_FUTURE-1] = Convert.ToInt64(dqty).ToString(); 
        }

        foreach (DictionaryEntry entry in hashInventory)
            arrayList.Add(entry);
        arrayList.Sort(new InventoryByWeekComparer());

        items = new string[arrayList.Count][];
        i=0;
        foreach (DictionaryEntry de in arrayList){
            items[i] = (string[])de.Value;
            i++;
        }
        
        return items;                                  

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}      
} 

private
string[] initInventoryArray(int imaxIndex,string spart,int iseq,string sdesc){
    string[] item = new string[imaxIndex+Constants.INDEX_INVENTORY_FUTURE]; //count weeks + part + seq + qoh

    item[0] = spart;
    item[1] = iseq.ToString();
    item[2] = sdesc;
    for (int i= (Constants.INDEX_INVENTORY_FUTURE-1); i < item.Length; i++)
        item[i] = "0";

    return item;
} 

private
class InventoryByWeekComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is DictionaryEntry) && (y is DictionaryEntry)){
            DictionaryEntry v1 = (DictionaryEntry)x;
            DictionaryEntry v2 = (DictionaryEntry)y;

            string saux1 = (string)v1.Key;
            string saux2 = (string)v2.Key;
            return saux1.CompareTo(saux2);
        }else
            return -1;
    }
}

private
int getLastScheduleHdrId(){ 
    int ischeduleIdAux  = 0;    
    ScheduleHdrDataBase scheduleHdrDataBase = new ScheduleHdrDataBase(dataBaseAccess);
    if (scheduleHdrDataBase.readLastByFilter(""))
        ischeduleIdAux = scheduleHdrDataBase.getId();
    return ischeduleIdAux;
}

private
int getLastScheduleHdrIdByPlant(string splant){ 
    int ischeduleIdAux  = 0;    
    ScheduleHdrDataBase scheduleHdrDataBase = new ScheduleHdrDataBase(dataBaseAccess);    
    if (scheduleHdrDataBase.readLastByFilter(splant))
        ischeduleIdAux = scheduleHdrDataBase.getId();
    return ischeduleIdAux;
}

/**************************************************** MachineReportView ******************************************************************/
public
ReportWeeksView createReportWeeksView(){
	return new ReportWeeksView();
}

public
ReportWeeksViewContainer createReportWeeksViewContainer(){
	return new ReportWeeksViewContainer();
}

public
PartReportWeeksViewContainer createPartReportWeeksViewContainer(){
	return new PartReportWeeksViewContainer();
}

public
MachineReportView createMachineReportView(){
	return new MachineReportView();
}

public
MachineReportPartView createMachineReportPartView(){
	return new MachineReportPartView();
}

public
MachineReportViewContainer createMachineReportViewContainer(){
	return new MachineReportViewContainer();
}

public
MachineReportPartView cloneMachineReportPartView(MachineReportPartView machineReportPartView){
    MachineReportPartView cloneMachineReportPartView= new MachineReportPartView();
    cloneMachineReportPartView.copy(machineReportPartView);
    return cloneMachineReportPartView;
}

public
CapacityPart generateNewCapacityPartBasedPlanned(CapacityHdr capacityHdr,MachineReportPartView machineReportPartView,CellMachinePart cellMachinePart){
    CapacityPart capacityPart=null;
    try{           
        /* we do not read Capacity because take so much time, so we add Capacity record at the end                      
        if (capacityHdr.CapacityPartContainer.Count < 1) //check if info already read, just to not spend so much time, ever time
            capacityHdr = readCapacityHdr(capacityHdr.Id);
        */

        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        CapacityPartDataBaseContainer capacityPartDataBaseContainer = new CapacityPartDataBaseContainer(dataBaseAccess);

        if (capacityHdr!= null){ 
            ProdFmInfoDataBaseContainer     prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
            ProdFmActSubDataBaseContainer   prodFmActSubDataBaseContainer= new ProdFmActSubDataBaseContainer(dataBaseAccess);
            PltDeptMachDataBase             pltDeptMachDataBase=null;

            if (capacityHdr!= null && machineReportPartView!= null && cellMachinePart!= null){

                capacityPart = addCapacityPartSummarize(    prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,ref pltDeptMachDataBase,
                                                            machineReportPartView.Part, machineReportPartView.Seq,0,capacityHdr.Plant,
                                                            capacityHdr,cellMachinePart.Planned,cellMachinePart.StartDate);
                capacityPart.HdrId = capacityHdr.Id;
                capacityPart.Detail = capacityPartDataBaseContainer.readMaxDetailFromHdr(capacityPart.HdrId) + 1;
                writeCapacityPart(capacityPart);
            }        
        }

        if (!userHandleTransaction)
		    dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){		
        dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
    return capacityPart;
}

private
CapacityPart addCapacityPartSummarize(  ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer,
                                        ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer,
                                        ref PltDeptMachDataBase pltDeptMachDataBase,
                                        string spart,int seq,int ihotListId,string splantOriginal,                                    
                                        CapacityHdr capacityHdr, decimal dqty,DateTime date){
    CapacityPart        capacityPart = null;    
    string              splant="";
    string              sdept = "";
    string              smachine = "";    
    int                 ireqMachine = 0;
    int                 ireqTool = 0;
    int                 ireqLabour = 0;
    decimal             runStd = 0;
	int                 imenQty = 0;
	int                 imachQty= 0;     
    decimal             dhours = 0;    
    
    dqty = Math.Abs(dqty);
    
    if (dqty > 0) { 
        //search for methdr/ProdFmActSub 
        ProdFmActSubDataBase    prodFmActSubDataBase = null;
        bool                    bfound = getProdFmActSubDataBase(out prodFmActSubDataBase, prodFmActSubDataBaseContainer, 
                                         spart,seq,splantOriginal);          
        if (bfound){

            runStd = prodFmActSubDataBase.getPC_RunStd();
		    imenQty = prodFmActSubDataBase.getPC_QtyMen();
		    imachQty= prodFmActSubDataBase.getPC_QtyMachines();

            //machine
            splant  = prodFmActSubDataBase.getPC_Plt();            
            sdept   = prodFmActSubDataBase.getPC_Dept();
            smachine= prodFmActSubDataBase.getPC_Cfg();
               
            if (!string.IsNullOrEmpty(smachine)){
                if (pltDeptMachDataBase!= null &&  pltDeptMachDataBase.getPDM_Plt().ToUpper().Equals(splant.ToUpper()) && 
                    pltDeptMachDataBase.getPDM_Dept().ToUpper().Equals(sdept.ToUpper()) &&  pltDeptMachDataBase.getPDM_Mach().ToUpper().Equals(smachine.ToUpper()))
                    ireqMachine = pltDeptMachDataBase.getPDM_ID();
                else{
                    pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
                    pltDeptMachDataBase.setPDM_Plt(splant);
                    pltDeptMachDataBase.setPDM_Dept(sdept);
                    pltDeptMachDataBase.setPDM_Mach(smachine);
                    if (pltDeptMachDataBase.read())
                        ireqMachine = pltDeptMachDataBase.getPDM_ID();                    
                }
            }

            if (imenQty > 0 && imachQty > 0)                        
                ireqLabour = 1;        
            /*
            //////////////////////////////
            string saux= "Part: " + hotListDataBase.getHOT_ProdID() + " Seq:" + hotListDataBase.getHOT_Seq() + "\nMachine:" + smachine +  "runStd:" + runStd;
            if (ireqLabour > 0)
                saux+= "\nLabour: menQty=" + imenQty + " machQty=" + imachQty;
            System.Windows.Forms.MessageBox.Show(saux);
            ////////////////////////////
            */
        }            	
    
    
        if (dqty > 0 && runStd != 0 && (ireqMachine > 0 || ireqLabour > 0 || ireqTool > 0)){
            ProdFmInfoDataBase prodFmInfoDataBase = prodFmInfoDataBaseContainer.getProdFmInfo(spart);
            if (prodFmInfoDataBase== null) {    //if not found, try to read it
                prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
                prodFmInfoDataBase.setPFS_ProdID(spart);
                if (prodFmInfoDataBase.read())
                    prodFmInfoDataBaseContainer.Add(prodFmInfoDataBase,prodFmInfoDataBase.getPFS_ProdID());
            }

 
            capacityPart = capacityHdr.CapacityPartContainer.getByPartSeqDateRangeWeek(spart,seq,splant,sdept,date);
            if (capacityPart==null){
                capacityPart = new CapacityPart();               
                capacityPart.Part = spart;
                capacityPart.Seq  = seq;

                DateTime dpriortMonday = date;
                DateTime dnextSunday = date;
                Nujit.NujitERP.ClassLib.Util.DateUtil.getPriorMondayNextSundayFromDate(date, out dpriortMonday, out dnextSunday);

                /*
                System.Windows.Forms.MessageBox.Show("NoPart:" + capacityPart.Part + " Seq:" + capacityPart.Seq + "\n" +
                                              "Date:" + DateUtil.getCompleteDateRepresentation(date,DateUtil.DDMMYYYY) + "\n" +
                                              "Mon :" + DateUtil.getCompleteDateRepresentation(dfirstMonday, DateUtil.DDMMYYYY) + "\n" +
                                              "Sun :" + DateUtil.getCompleteDateRepresentation(dnextSunday, DateUtil.DDMMYYYY) + "\n" +
                                              ((date >= dfirstMonday && date <= dnextSunday) ? "In Range" : "No Range") );
                */

                capacityPart.StartDate = dpriortMonday;
                capacityPart.EndDate = dnextSunday;
                capacityPart.HotListID = ihotListId;//hotListDataBase.getHOT_IdAut();
                capacityPart.Qty = capacityPart.QtyPlanned = dqty;
                capacityPart.Plant = splant;
                capacityPart.Dept = sdept;
                capacityHdr.CapacityPartContainer.Add(capacityPart); //add capacity part
            }else{
                capacityPart.QtyPlanned  = capacityPart.Qty = capacityPart.Qty+ dqty;
                        /*
                System.Windows.Forms.MessageBox.Show(
                    "Part Found:" + capacityPart.Part + " Seq:" + capacityPart.Seq + "\n" +
                    "Date:" + DateUtil.getCompleteDateRepresentation(date,DateUtil.DDMMYYYY) + "\n" +
                    "Mon :" + DateUtil.getCompleteDateRepresentation(capacityPart.StartDate, DateUtil.DDMMYYYY) + "\n" +
                    "Sund :" + DateUtil.getCompleteDateRepresentation(capacityPart.EndDate, DateUtil.DDMMYYYY) + "\n" +
                    ((date >= capacityPart.StartDate && date <= capacityPart.EndDate) ? "In Range" : "No Range") );
                    */
            }

            if (prodFmInfoDataBase!= null){
                capacityPart.IsFamily = prodFmInfoDataBase.getPFS_FamProd();  
                if (capacityPart.IsFamily.Equals("F"))
                    addCapacityPartDtlSummarize(capacityPart,dqty);
            }
        
            if (ireqMachine > 0){
                dhours = dqty / (runStd != 0 ? runStd : 1);
                addCapacityReqSummarize(capacityPart,CapacityReq.REQUIREMENT_MACHINE, ireqMachine,dhours, 0, 0);        
            }

            if (ireqLabour > 0){
                decimal daux = dqty / (runStd != 0 ? runStd : 1);
                dhours = daux * (imenQty * imachQty);
                addCapacityReqSummarize(capacityPart,CapacityReq.REQUIREMENT_LABOUR, ireqLabour, dhours,imenQty,imachQty);            
            }            
        }   
    }   
    return capacityPart;
}

/*//////////////////////////////////////////////////// LabourTypePlanning ////////////////////////////////////////////////////*/
public
LabourPlanningReportView createLabourPlanningReportView(){
	return new LabourPlanningReportView();
}

public
LabourPlanningReportViewContainer createLabourPlanningReportViewContainer(){
	return new LabourPlanningReportViewContainer();
}

public
CellPlanningLabType createCellPlanningLabType(){
	return new CellPlanningLabType();
}


/*************************************************** CapacityMachPriority ******************************************/
public
CapacityMachPriority createCapacityMachPriority(){
	return new CapacityMachPriority();
}

public
CapacityMachPriorityContainer createCapacityMachPriorityContainer(){
	return new CapacityMachPriorityContainer();
}

private
CapacityMachPriority objectDataBaseToObject(CapacityMachPriorityDataBase capacityMachPriorityDataBase){
	CapacityMachPriority capacityMachPriority = new CapacityMachPriority();

	capacityMachPriority.HdrId=capacityMachPriorityDataBase.getHdrId();
	capacityMachPriority.Detail=capacityMachPriorityDataBase.getDetail();
	capacityMachPriority.MachineId=capacityMachPriorityDataBase.getMachineId();
	capacityMachPriority.Priority=capacityMachPriorityDataBase.getPriority();
	capacityMachPriority.Planned=capacityMachPriorityDataBase.getPlanned();
	capacityMachPriority.Labour=capacityMachPriorityDataBase.getLabour();
	capacityMachPriority.Part=capacityMachPriorityDataBase.getPart();
	capacityMachPriority.Qty=capacityMachPriorityDataBase.getQty();

	return capacityMachPriority;
}

private
CapacityMachPriorityDataBase objectToObjectDataBase(CapacityMachPriority capacityMachPriority){
	CapacityMachPriorityDataBase capacityMachPriorityDataBase = new CapacityMachPriorityDataBase(dataBaseAccess);
	capacityMachPriorityDataBase.setHdrId(capacityMachPriority.HdrId);
	capacityMachPriorityDataBase.setDetail(capacityMachPriority.Detail);
	capacityMachPriorityDataBase.setMachineId(capacityMachPriority.MachineId);
	capacityMachPriorityDataBase.setPriority(capacityMachPriority.Priority);
	capacityMachPriorityDataBase.setPlanned(capacityMachPriority.Planned);
	capacityMachPriorityDataBase.setLabour(capacityMachPriority.Labour);
	capacityMachPriorityDataBase.setPart(capacityMachPriority.Part);
	capacityMachPriorityDataBase.setQty(capacityMachPriority.Qty);

	return capacityMachPriorityDataBase;
}

public
CapacityMachPriority cloneCapacityMachPriority(CapacityMachPriority capacityMachPriority){
	CapacityMachPriority capacityMachPriorityClone = new CapacityMachPriority();
    capacityMachPriorityClone.copy(capacityMachPriority);	
	return capacityMachPriorityClone;
}

/*************************************** CapShiftProfileMachPlan **********************************************/
public
CapShiftProfileMachPlan createCapShiftProfileMachPlan(){
    return new CapShiftProfileMachPlan();
} 

private
CapShiftProfileMachPlan objectDataBaseToObject(CapShiftProfileMachPlanDataBase capShiftProfileMachPlanDataBase){
	CapShiftProfileMachPlan capShiftProfileMachPlan = new CapShiftProfileMachPlan();

	capShiftProfileMachPlan.HdrId=capShiftProfileMachPlanDataBase.getHdrId();
	capShiftProfileMachPlan.Detail=capShiftProfileMachPlanDataBase.getDetail();
	capShiftProfileMachPlan.Date=capShiftProfileMachPlanDataBase.getDate();
	capShiftProfileMachPlan.MachId=capShiftProfileMachPlanDataBase.getMachId();
	capShiftProfileMachPlan.FullShift=capShiftProfileMachPlanDataBase.getFullShift();
    capShiftProfileMachPlan.ShiftType= capShiftProfileMachPlanDataBase.getShiftType();

	return capShiftProfileMachPlan;
}

private
CapShiftProfileMachPlanDataBase objectToObjectDataBase(CapShiftProfileMachPlan capShiftProfileMachPlan){
	CapShiftProfileMachPlanDataBase capShiftProfileMachPlanDataBase = new CapShiftProfileMachPlanDataBase(dataBaseAccess);
	capShiftProfileMachPlanDataBase.setHdrId(capShiftProfileMachPlan.HdrId);
	capShiftProfileMachPlanDataBase.setDetail(capShiftProfileMachPlan.Detail);
	capShiftProfileMachPlanDataBase.setDate(capShiftProfileMachPlan.Date);
	capShiftProfileMachPlanDataBase.setMachId(capShiftProfileMachPlan.MachId);
	capShiftProfileMachPlanDataBase.setFullShift(capShiftProfileMachPlan.FullShift);
    capShiftProfileMachPlanDataBase.setShiftType(capShiftProfileMachPlan.ShiftType);

	return capShiftProfileMachPlanDataBase;
}

public
CapShiftProfileMachPlan cloneCapShiftProfileMachPlan(CapShiftProfileMachPlan capShiftProfileMachPlan){
	CapShiftProfileMachPlan capShiftProfileMachPlanClone = new CapShiftProfileMachPlan();    
    capShiftProfileMachPlanClone.copy(capShiftProfileMachPlan);

	return capShiftProfileMachPlanClone;
}

/******************************************* CapShiftProfileMachPlanEmployee ***************************************************/
public
CapShiftProfileMachPlanEmployee createCapShiftProfileMachPlanEmployee(){
	return new CapShiftProfileMachPlanEmployee();
}

public
CapShiftProfileMachPlanEmployeeContainer createCapShiftProfileMachPlanEmployeeContainer(){
	return new CapShiftProfileMachPlanEmployeeContainer();
}

private
CapShiftProfileMachPlanEmployee objectDataBaseToObject(CapShiftProfileMachPlanEmployeeDataBase capShiftProfileMachPlanEmployeeDataBase){
	CapShiftProfileMachPlanEmployee capShiftProfileMachPlanEmployee = new CapShiftProfileMachPlanEmployee();

	capShiftProfileMachPlanEmployee.HdrId=capShiftProfileMachPlanEmployeeDataBase.getHdrId();
	capShiftProfileMachPlanEmployee.Detail=capShiftProfileMachPlanEmployeeDataBase.getDetail();
	capShiftProfileMachPlanEmployee.SubDetail=capShiftProfileMachPlanEmployeeDataBase.getSubDetail();
	capShiftProfileMachPlanEmployee.EmpId=capShiftProfileMachPlanEmployeeDataBase.getEmpId();

	return capShiftProfileMachPlanEmployee;
}

private
CapShiftProfileMachPlanEmployeeDataBase objectToObjectDataBase(CapShiftProfileMachPlanEmployee capShiftProfileMachPlanEmployee){
	CapShiftProfileMachPlanEmployeeDataBase capShiftProfileMachPlanEmployeeDataBase = new CapShiftProfileMachPlanEmployeeDataBase(dataBaseAccess);
	capShiftProfileMachPlanEmployeeDataBase.setHdrId(capShiftProfileMachPlanEmployee.HdrId);
	capShiftProfileMachPlanEmployeeDataBase.setDetail(capShiftProfileMachPlanEmployee.Detail);
	capShiftProfileMachPlanEmployeeDataBase.setSubDetail(capShiftProfileMachPlanEmployee.SubDetail);
	capShiftProfileMachPlanEmployeeDataBase.setEmpId(capShiftProfileMachPlanEmployee.EmpId);

	return capShiftProfileMachPlanEmployeeDataBase;
}

public
CapShiftProfileMachPlanEmployee cloneCapShiftProfileMachPlanEmployee(CapShiftProfileMachPlanEmployee capShiftProfileMachPlanEmployee){
	CapShiftProfileMachPlanEmployee capShiftProfileMachPlanEmployeeClone = new CapShiftProfileMachPlanEmployee();

	capShiftProfileMachPlanEmployeeClone.HdrId=capShiftProfileMachPlanEmployee.HdrId;
	capShiftProfileMachPlanEmployeeClone.Detail=capShiftProfileMachPlanEmployee.Detail;
	capShiftProfileMachPlanEmployeeClone.SubDetail=capShiftProfileMachPlanEmployee.SubDetail;
	capShiftProfileMachPlanEmployeeClone.EmpId=capShiftProfileMachPlanEmployee.EmpId;

	return capShiftProfileMachPlanEmployeeClone;
}
/******************************************* LabourPlanningReportShiftView ***************************************************/
public
LabourPlanningReportShiftView createLabourPlanningReportShiftView(){
    return new LabourPlanningReportShiftView();
} 

public
LabourPlanningReportShiftViewContainer createLabourPlanningReportShiftViewContainer(){
    return new LabourPlanningReportShiftViewContainer();
}

} // class
} // package