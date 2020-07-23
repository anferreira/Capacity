using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Planned;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Planned;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Machines;

namespace Nujit.NujitERP.ClassLib.Core.Util{


public 
class PlannedCoreFactory : PersonCoreFactory{

public
PlannedCoreFactory():base(){
}

public
PlannedHdr createPlannedHdr(){
	return new PlannedHdr();
}

public
PlannedHdrContainer createPlannedHdrContainer(){
	return new PlannedHdrContainer();
}

public
bool existsPlannedHdr(int id){
	try{
		PlannedHdrDataBase plannedHdrDataBase = new PlannedHdrDataBase(dataBaseAccess);

		plannedHdrDataBase.setId(id);

		return plannedHdrDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
PlannedHdr readPlannedHdr(int id){
	try{
		PlannedHdrDataBase plannedHdrDataBase = new PlannedHdrDataBase(dataBaseAccess);
		plannedHdrDataBase.setId(id);

		if (!plannedHdrDataBase.read())
			return null;

		PlannedHdr plannedHdr = this.objectDataBaseToObject(plannedHdrDataBase);
        readPlannedHdrChilds2(plannedHdr);

		return plannedHdr;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
PlannedHdr readPlannedHdrLast(string splant){
	try{
		PlannedHdrDataBase plannedHdrDataBase = new PlannedHdrDataBase(dataBaseAccess);		
		if (!plannedHdrDataBase.readLastByFilter(splant))
			return null;

		PlannedHdr plannedHdr = this.objectDataBaseToObject(plannedHdrDataBase);
        readPlannedHdrChilds2(plannedHdr);

		return plannedHdr;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
PlannedHdr readPlannedHdrLastDateCheck(PlannedHdr plannedHdr, string splant){
    PlannedHdr          plannedHdrNew = null;
	try{
        plannedHdrNew = plannedHdr;
        bool                breadNew = false;
        PlannedHdrDataBase  plannedHdrDataBase = new PlannedHdrDataBase(dataBaseAccess);		
        if (!plannedHdrDataBase.readLastByFilter(splant))
			return null;

        if (plannedHdr == null)
            breadNew = true;            
        else if (plannedHdr.DateTimeStamp != plannedHdrDataBase.getDateTimeStamp() || plannedHdr.Id != plannedHdrDataBase.getId())
            breadNew = true;    

        if (breadNew)
            plannedHdrNew = readPlannedHdr(plannedHdrDataBase.getId());

		return plannedHdrNew;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

private
void readPlannedHdrChilds(PlannedHdr plannedHdr){
    PlannedReqDataBaseContainer plannedReqDataBaseContainer = new PlannedReqDataBaseContainer(dataBaseAccess);
    plannedReqDataBaseContainer.readByHdr(plannedHdr.Id);

    foreach(PlannedReqDataBase plannedReqDataBase in plannedReqDataBaseContainer){
        PlannedReq plannedReq = objectDataBaseToObject(plannedReqDataBase);

        //parts                        
        PlannedPartDataBaseContainer plannedPartDataBaseContainer = new PlannedPartDataBaseContainer(dataBaseAccess);
        plannedPartDataBaseContainer.readByHdr(plannedReq.HdrId, plannedReq.Detail);
        foreach(PlannedPartDataBase plannedPartDataBase in plannedPartDataBaseContainer){
            PlannedPart plannedPart = objectDataBaseToObject(plannedPartDataBase);
            plannedReq.PlannedPartContainer.Add(plannedPart);
        }

        //labour
        PlannedLabourDataBaseContainer plannedLabourDataBaseContainer = new PlannedLabourDataBaseContainer(dataBaseAccess);
        plannedLabourDataBaseContainer.readByHdr(plannedReq.HdrId, plannedReq.Detail);
        foreach(PlannedLabourDataBase plannedLabourDataBase in plannedLabourDataBaseContainer){
            PlannedLabour plannedLabour = objectDataBaseToObject(plannedLabourDataBase);
            plannedReq.PlannedLabourContainer.Add(plannedLabour);
        }

        plannedHdr.PlannedReqContainer.Add(plannedReq);
    }
}

private
void readPlannedHdrChilds2(PlannedHdr plannedHdr){
    Hashtable   hashReq = new Hashtable();
    PlannedReq  plannedReq = null;

    PlannedReqDataBaseContainer plannedReqDataBaseContainer = new PlannedReqDataBaseContainer(dataBaseAccess);
    plannedReqDataBaseContainer.readByHdr(plannedHdr.Id);

    foreach(PlannedReqDataBase plannedReqDataBase in plannedReqDataBaseContainer){
        plannedReq = objectDataBaseToObject(plannedReqDataBase);      
        plannedHdr.PlannedReqContainer.Add(plannedReq);
        hashReq.Add(plannedReq.Detail,plannedReq);
    }

    //parts                        
    PlannedPartDataBaseContainer plannedPartDataBaseContainer = new PlannedPartDataBaseContainer(dataBaseAccess);
    plannedPartDataBaseContainer.readByHdrAll(plannedHdr.Id);
    foreach(PlannedPartDataBase plannedPartDataBase in plannedPartDataBaseContainer){

        if (hashReq.Contains(plannedPartDataBase.getDetail())) { 
            plannedReq = (PlannedReq)hashReq[plannedPartDataBase.getDetail()];

            PlannedPart plannedPart = objectDataBaseToObject(plannedPartDataBase);
            plannedReq.PlannedPartContainer.Add(plannedPart);
        }        
    }

    //labours
    PlannedLabourDataBaseContainer plannedLabourDataBaseContainer = new PlannedLabourDataBaseContainer(dataBaseAccess);
    plannedLabourDataBaseContainer.readByHdrAll(plannedHdr.Id);
    foreach(PlannedLabourDataBase plannedLabourDataBase in plannedLabourDataBaseContainer){

        if (hashReq.Contains(plannedLabourDataBase.getDetail())) { 
            plannedReq = (PlannedReq)hashReq[plannedLabourDataBase.getDetail()];

            PlannedLabour plannedLabour = objectDataBaseToObject(plannedLabourDataBase);
            plannedReq.PlannedLabourContainer.Add(plannedLabour);
        }
    }
}

private
void writePlannedHdrChilds(PlannedHdr plannedHdr){
    plannedHdr.fillRedundances();
    
    foreach(PlannedReq plannedReq in plannedHdr.PlannedReqContainer){
        writePlannedReqChilds(plannedReq);                     
    }
}

private
void writePlannedReqChilds(PlannedReq plannedReq){
    plannedReq.fillRedundances();
    PlannedReqDataBase plannedReqDataBase = objectToObjectDataBase(plannedReq);
    plannedReqDataBase.write();

    foreach(PlannedPart plannedPart in plannedReq.PlannedPartContainer){
        PlannedPartDataBase plannedPartDataBase = objectToObjectDataBase(plannedPart);
        plannedPartDataBase.write();
    }        

    foreach(PlannedLabour plannedLabour in plannedReq.PlannedLabourContainer){
        PlannedLabourDataBase plannedLabourDataBase = objectToObjectDataBase(plannedLabour);
        plannedLabourDataBase.write();
    }  
}

public
string[][] getPlannedHdrByDesc(string searchText, int rows){
	try{
		PlannedHdrDataBaseContainer plannedHdrDataBaseContainer = new PlannedHdrDataBaseContainer(dataBaseAccess);
		plannedHdrDataBaseContainer.readByDesc(searchText, rows);
		string[][] items = new string[plannedHdrDataBaseContainer.Count][];
		int i = 0;
		for(IEnumerator en = plannedHdrDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			PlannedHdrDataBase plannedHdrDataBase = (PlannedHdrDataBase) en.Current;
			string[] item = new String[7];
			item[0] = plannedHdrDataBase.getId().ToString();
			item[1] = plannedHdrDataBase.getDateCreated().ToString();
			item[2] = plannedHdrDataBase.getStatus();
			item[3] = plannedHdrDataBase.getPlant();
			item[4] = plannedHdrDataBase.getTotMachines().ToString();
			item[5] = plannedHdrDataBase.getMachPlanned().ToString();
			item[6] = plannedHdrDataBase.getLastMachPlannedId().ToString();
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
void updatePlannedHdrOnly(PlannedHdr plannedHdr){
    PlannedHdrDataBase plannedHdrDataBase = this.objectToObjectDataBase(plannedHdr);
    checkDateTimeStamp(plannedHdr,plannedHdrDataBase);
	plannedHdrDataBase.update();
    plannedHdr.DateTimeStamp = plannedHdrDataBase.readDateTimeStamp();
}

public 
void updatePlannedHdr(PlannedHdr plannedHdr){
	try{
        if (!userHandleTransaction)
		    dataBaseAccess.beginTransaction();

		updatePlannedHdrOnly(plannedHdr);

        deletePlannedHdrChilds(plannedHdr.Id);
        writePlannedHdrChilds(plannedHdr);

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
void writePlannedHdrInternal(PlannedHdr plannedHdr){
	PlannedHdrDataBase plannedHdrDataBase = this.objectToObjectDataBase(plannedHdr);
	plannedHdrDataBase.write();        
	plannedHdr.Id=plannedHdrDataBase.getId();
    plannedHdr.DateTimeStamp = plannedHdrDataBase.readDateTimeStamp();

    writePlannedHdrChilds(plannedHdr);
}

public 
void writePlannedHdr(PlannedHdr plannedHdr){
	try{
		if (!userHandleTransaction)
		    dataBaseAccess.beginTransaction();

	    writePlannedHdrInternal(plannedHdr);

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
void deletePlannedHdr(int id){
	try{
		if (!userHandleTransaction)
		    dataBaseAccess.beginTransaction();

		PlannedHdrDataBase plannedHdrDataBase = new PlannedHdrDataBase(dataBaseAccess);

        deletePlannedHdrChilds(id);
		plannedHdrDataBase.setId(id);
		plannedHdrDataBase.delete();

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
void deletePlannedHdrChilds(int id){
    PlannedPartDataBaseContainer plannedPartDataBaseContainer = new PlannedPartDataBaseContainer(dataBaseAccess);
    plannedPartDataBaseContainer.deleteByHdr(id);

    PlannedLabourDataBaseContainer plannedLabourDataBaseContainer = new PlannedLabourDataBaseContainer(dataBaseAccess);
    plannedLabourDataBaseContainer.deleteByHdr(id);

    PlannedReqDataBaseContainer plannedReqDataBaseContainer = new PlannedReqDataBaseContainer(dataBaseAccess);
    plannedReqDataBaseContainer.deleteByHdr(id);    
}

private
void deletePlannedReqChilds(int id,int idtl){
    PlannedReqDataBase plannedReqDataBase = new PlannedReqDataBase(dataBaseAccess);
    plannedReqDataBase.setHdrId(id);
    plannedReqDataBase.setDetail(idtl);            
    plannedReqDataBase.delete();

    PlannedPartDataBaseContainer plannedPartDataBaseContainer = new PlannedPartDataBaseContainer(dataBaseAccess);
    plannedPartDataBaseContainer.deleteByReqHdr(id,idtl);

    PlannedLabourDataBaseContainer plannedLabourDataBaseContainer = new PlannedLabourDataBaseContainer(dataBaseAccess);
    plannedLabourDataBaseContainer.deleteByReqHdr(id,idtl);
}

private
PlannedHdr objectDataBaseToObject(PlannedHdrDataBase plannedHdrDataBase){
	PlannedHdr plannedHdr = new PlannedHdr();

	plannedHdr.Id=plannedHdrDataBase.getId();
	plannedHdr.DateCreated=plannedHdrDataBase.getDateCreated();
	plannedHdr.Status=plannedHdrDataBase.getStatus();
	plannedHdr.Plant=plannedHdrDataBase.getPlant();
	plannedHdr.TotMachines=plannedHdrDataBase.getTotMachines();
	plannedHdr.MachPlanned=plannedHdrDataBase.getMachPlanned();
	plannedHdr.LastMachPlannedId=plannedHdrDataBase.getLastMachPlannedId();
    plannedHdr.DateTimeStamp = plannedHdrDataBase.getDateTimeStamp();

	return plannedHdr;
}

private
PlannedHdrDataBase objectToObjectDataBase(PlannedHdr plannedHdr){
	PlannedHdrDataBase plannedHdrDataBase = new PlannedHdrDataBase(dataBaseAccess);
	plannedHdrDataBase.setId(plannedHdr.Id);
	plannedHdrDataBase.setDateCreated(plannedHdr.DateCreated);
	plannedHdrDataBase.setStatus(plannedHdr.Status);
	plannedHdrDataBase.setPlant(plannedHdr.Plant);
	plannedHdrDataBase.setTotMachines(plannedHdr.TotMachines);
	plannedHdrDataBase.setMachPlanned(plannedHdr.MachPlanned);
	plannedHdrDataBase.setLastMachPlannedId(plannedHdr.LastMachPlannedId);
    plannedHdrDataBase.setDateTimeStamp(plannedHdr.DateTimeStamp);

	return plannedHdrDataBase;
}

public
PlannedHdr clonePlannedHdr(PlannedHdr plannedHdr){
	PlannedHdr plannedHdrClone = new PlannedHdr();
    plannedHdrClone.copy(plannedHdr);	
	return plannedHdrClone;
}

private
bool checkDateTimeStamp(PlannedHdr plannedHdr, PlannedHdrDataBase plannedHdrDataBase) {
    bool bchanged=false;
    if (plannedHdr.DateTimeStamp != plannedHdrDataBase.readDateTimeStamp())
        throw new Exception("Planned " + Constants.DATETIME_STAMP_TABLE_MESSAGE);

    return bchanged;
}

public 
bool updatePlannedPart(PlannedHdr plannedHdr, PlannedPart plannedPart){ //can not read full CapacityHdr, to change only 1 record, that will take so much time, so we update specific record here
    try{
        bool        bresult=false;
        Hashtable   hashProdFmActPlan   = new Hashtable();
        Hashtable   hashProdFmActSub    = new Hashtable();
        Hashtable   hashBomSum          = new Hashtable();
        Hashtable   hashMachines        = new Hashtable();

		if (!userHandleTransaction)
		    dataBaseAccess.beginTransaction();

        updatePlannedHdrOnly(plannedHdr);        

		PlannedPartDataBase plannedPartDataBase = this.objectToObjectDataBase(plannedPart);
        if (plannedPartDataBase.read()) { 
            if (plannedPartDataBase.getPart().ToUpper().Equals(plannedPart.Part.ToUpper()) &&
                plannedPartDataBase.getSeq() == plannedPart.Seq){ //just in case, checking if nothing changed

                plannedPartDataBase = this.objectToObjectDataBase(plannedPart);
		        plannedPartDataBase.update();
                bresult=true;

                //generatePlannedPartsForChildsSeqInternal(plannedHdr,plannedPart,hashProdFmActPlan, hashProdFmActSub, hashBomSum,hashMachines);
            }
        }

	    if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

        return bresult;

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

internal
PlannedPart generateNewPlannedPartBasedPlannedInternal(PlannedHdr plannedHdr, string splant,int imachineId,string spart,int iseq,decimal dqty,decimal dqtyOvertime,DateTime startDate,bool bgenerateForChilds){
    PlannedPart plannedPart = null;
    Hashtable   hashProdFmActPlan   = new Hashtable();
    Hashtable   hashProdFmActSub    = new Hashtable();
    Hashtable   hashBomSum          = new Hashtable();
    Hashtable   hashMachines        = new Hashtable();
    
    /* we do not read Capacity because take so much time, so we add Capacity record at the end                      
    if (capacityHdr.CapacityPartContainer.Count < 1) //check if info already read, just to not spend so much time, ever time
        capacityHdr = readCapacityHdr(capacityHdr.Id);
    */        
    if (plannedHdr==null)
        plannedHdr = createNewPlannedHdr(splant);

    if (plannedHdr != null){             
        plannedHdr.LastMachPlannedId = imachineId;
        PlannedReq      plannedReq= plannedHdr.PlannedReqContainer.getByRequirment(Constants.TYPE_MACHINE,imachineId);
        bool            bisNewReq=false;                    
           
        if (plannedReq == null) { 
            plannedReq = createNewPlannedReq(plannedHdr,Constants.TYPE_MACHINE,imachineId);                    
            bisNewReq=false; 
        }

        plannedPart = plannedReq.PlannedPartContainer.getByPartSeqDateRangeWeek(spart,iseq,startDate);
        if (plannedPart != null) { 
            plannedPart.QtyPlanned = dqty;
            plannedPart.QtyOvertime= dqtyOvertime;
        }else{
            plannedPart = createNewPlannedPart(spart,iseq, dqty, dqty, dqtyOvertime,startDate);                    
            plannedReq.PlannedPartContainer.Add(plannedPart);            
        }

        if (plannedPart!= null && plannedPart.QtyPlanned ==0 && plannedPart.QtyOvertime == 0)
            plannedReq.PlannedPartContainer.Remove(plannedPart);   //could be qtyplanned=0 to delete

        if (plannedHdr.Id > 0)
            updatePlannedHdrOnlyPlannedReqInternal(plannedHdr,plannedReq,bisNewReq);                    
        else
            writePlannedHdrInternal(plannedHdr);                                            

        //if (bgenerateForChilds)
            //generatePlannedPartsForChildsSeqInternal(plannedHdr,plannedPart,hashProdFmActPlan,hashProdFmActSub,hashBomSum,hashMachines);
    }

    return plannedPart;
}

public
PlannedPart generateNewPlannedPartBasedPlanned(PlannedHdr plannedHdr, string splant,int imachineId,string spart,int iseq,decimal dqty,decimal dqtyOvertime,DateTime startDate,bool bgenerateForChilds){
    PlannedPart plannedPart = null;
    try{
		if (!userHandleTransaction)
		    dataBaseAccess.beginTransaction();

        plannedPart = generateNewPlannedPartBasedPlannedInternal(plannedHdr,splant,imachineId,spart,iseq,dqty, dqtyOvertime,startDate, bgenerateForChilds);

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

    return plannedPart;
}

public
PlannedLabour generateNewPlannedLabourBasedPlanned(PlannedHdr plannedHdr,string splant,int imachineId,int ishiftNum,CapacityView capacityView, CellPlanningLabType cellPlanningLabType){
    PlannedLabour plannedLabour = null;    
    try{           
        /* we do not read Capacity because take so much time, so we add Capacity record at the end                      
        if (capacityHdr.CapacityPartContainer.Count < 1) //check if info already read, just to not spend so much time, ever time
            capacityHdr = readCapacityHdr(capacityHdr.Id);
        */        
        if (plannedHdr==null)
            plannedHdr = createNewPlannedHdr(splant);

        if (plannedHdr != null){             
            if (imachineId > 0)
                plannedHdr.LastMachPlannedId = imachineId;
            PlannedReq  plannedReq= null;
            bool        bisNewReq=false;

            if (imachineId > 0) plannedReq = plannedHdr.PlannedReqContainer.getByRequirment(Constants.TYPE_MACHINE,imachineId);
            else if (capacityView != null)
                                plannedReq = plannedHdr.PlannedReqContainer.getByRequirment(Constants.TYPE_LABOUR, capacityView.ReqId);

            if (capacityView != null && cellPlanningLabType!= null){
                if (plannedReq == null) { 
                    if (imachineId > 0) plannedReq = createNewPlannedReq(plannedHdr,Constants.TYPE_MACHINE,imachineId);
                    else                plannedReq = createNewPlannedReq(plannedHdr,Constants.TYPE_LABOUR ,capacityView.ReqId);                   
                    bisNewReq=true;
                }

                plannedLabour = plannedReq.PlannedLabourContainer.getByLabourTypeShiftDateRangeWeek(capacityView.ReqId,ishiftNum,cellPlanningLabType.StartDate);
                if (plannedLabour == null) {                     
                    plannedLabour = createNewPlannedLabour(capacityView.ReqId,cellPlanningLabType.StartDate,ishiftNum);
                    plannedReq.PlannedLabourContainer.Add(plannedLabour);
                }                
                plannedLabour.TotEmployPlan = cellPlanningLabType.Planned;//(cellPlanningLabType.Planned  * cellPlanningLabType.DaysPerWeek);
                plannedLabour.TotEmployOver = cellPlanningLabType.Overtime;
                plannedLabour.TotEmployTemp = cellPlanningLabType.Temp;

                plannedLabour.TotEmployHire     = cellPlanningLabType.NewHire;
                plannedLabour.TotEmployVacation = cellPlanningLabType.Vacation;
                plannedLabour.TotEmployAbsent   = cellPlanningLabType.SickAbsent;                

                if (plannedHdr.Id > 0)
                    updatePlannedHdrOnlyPlannedReq(plannedHdr,plannedReq,bisNewReq);
                else
                    writePlannedHdr(plannedHdr);                        
            }        
        }

        
	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
    return plannedLabour;
}

internal
void plannedMoveQtyChangeToPlannedInternal(PlannedHdr plannedHdr, string splant,int imachineId,DateTime fromDate){
    PlannedPart plannedPart = null;
        
    if (plannedHdr==null)
        plannedHdr = createNewPlannedHdr(splant);

    if (plannedHdr != null){             
        plannedHdr.LastMachPlannedId = imachineId;
        PlannedReq      plannedReq= plannedHdr.PlannedReqContainer.getByRequirment(Constants.TYPE_MACHINE,imachineId);
        bool            bisNewReq=false;                    
           
        if (plannedReq != null) { 
            for (int i=0; i < plannedReq.PlannedPartContainer.Count; i++){
                plannedPart = plannedReq.PlannedPartContainer[i];

                if (plannedPart.StartDate >= fromDate && plannedPart.QtyChange > 0) { 
                    plannedPart.QtyPlanned+= plannedPart.QtyChange;
                    plannedPart.QtyChange  =0;
                }
            }   
        }
        
        if (plannedHdr.Id > 0)
            updatePlannedHdrOnlyPlannedReqInternal(plannedHdr,plannedReq,bisNewReq);                    
        else
            writePlannedHdrInternal(plannedHdr);                                                    
    }    
}

public
void plannedMoveQtyChangeToPlanned(PlannedHdr plannedHdr, string splant,int imachineId,DateTime fromDate){    
    try{
		if (!userHandleTransaction)
		    dataBaseAccess.beginTransaction();

        plannedMoveQtyChangeToPlannedInternal(plannedHdr, splant,imachineId,fromDate);
               
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
ProdFmActPlanDataBaseContainer getHashProdFmActPlan(Hashtable hashProdFmActPlan,string spart){
    ProdFmActPlanDataBaseContainer  prodFmActPlanDataBaseContainer = new ProdFmActPlanDataBaseContainer(dataBaseAccess); 
    string                          skey= spart.ToUpper();

    if (hashProdFmActPlan.Contains(skey))
        prodFmActPlanDataBaseContainer = (ProdFmActPlanDataBaseContainer)hashProdFmActPlan[skey];
    else{
        prodFmActPlanDataBaseContainer.readByProduct(spart); //read sequences for part
        hashProdFmActPlan.Add(skey,prodFmActPlanDataBaseContainer);
    }
    return prodFmActPlanDataBaseContainer;
}

private
ProdFmActSubDataBaseContainer getHashProdFmActSub(Hashtable hashProdFmActSub, string spart,string splant){
    ProdFmActSubDataBaseContainer   prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess); 
    string                          skey= spart.ToUpper();

    if (hashProdFmActSub.Contains(skey))
        prodFmActSubDataBaseContainer = (ProdFmActSubDataBaseContainer)hashProdFmActSub[skey];
    else{
        prodFmActSubDataBaseContainer.readByFilters(spart,splant, "", -1, "", Routing.ROUTING_TYPE_MAIN, false, 0);
        hashProdFmActSub.Add(skey, prodFmActSubDataBaseContainer);
    }
    return prodFmActSubDataBaseContainer;
}                   

//procedure to process lower levels part/seq and material but not used for now
internal
void generatePlannedPartsForChildsSeqInternal2(PlannedHdr plannedHdr,PlannedPart plannedPart,Hashtable hashProdFmActPlan, Hashtable hashProdFmActSub, Hashtable hashBomSum,Hashtable hashMachines){    
    if (plannedHdr!= null && plannedPart!= null){
        int                             iseq=0;
        PlannedPart                     plannedPartNew = null;
        ProdFmActPlanDataBaseContainer  prodFmActPlanDataBaseContainer = new ProdFmActPlanDataBaseContainer(dataBaseAccess);        
        ProdFmActSubDataBase            prodFmActSubDataBase= null;
        ProdFmActSubDataBaseContainer   prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
        ProdFmInfoDataBaseContainer     prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);        
        ProdFmInfoDataBase              prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);

        prodFmInfoDataBase.setPFS_ProdID(plannedPart.Part);
        if (prodFmInfoDataBase.read() && prodFmInfoDataBase.getPFS_SeqLast() == plannedPart.Seq) { //if is last seq
        
            prodFmActPlanDataBaseContainer = getHashProdFmActPlan(hashProdFmActPlan,plannedPart.Part); //get sequences for part                
            if (prodFmActPlanDataBaseContainer.Count > 1) { //at least might be 2 seqs
                
                prodFmActSubDataBaseContainer = getHashProdFmActSub(hashProdFmActSub,plannedPart.Part,plannedHdr.Plant);//read routing for part

                foreach (ProdFmActPlanDataBase prodFmActPlanDataBase in prodFmActPlanDataBaseContainer){
                    iseq = prodFmActPlanDataBase.getPAPL_Seq();

                    if (iseq < plannedPart.Seq){

                        prodFmActSubDataBase = prodFmActSubDataBaseContainer.getProdFmActSub(plannedPart.Part,iseq);//get routing for part/seq
                        if (prodFmActSubDataBase!= null) {                    
                            //read machine
                            PltDeptMachDataBase pltDeptMachDataBase = getHashMachine(hashMachines,prodFmActSubDataBase.getPC_Plt(), prodFmActSubDataBase.getPC_Dept(),prodFmActSubDataBase.getPC_Cfg());                            		                    
		                    if (pltDeptMachDataBase!= null) {                                                                         
                                plannedPartNew = generateNewPlannedPartBasedPlannedInternal(plannedHdr,plannedHdr.Plant, pltDeptMachDataBase.getPDM_ID(), plannedPart.Part,iseq,plannedPart.QtyPlanned, plannedPart.QtyOvertime, plannedPart.StartDate,false);
                                generatePlannedPartsMaterialsForChildsSeqInternal2(plannedHdr, plannedPart.Part,iseq, plannedPart.QtyPlanned,plannedPart.StartDate,hashBomSum,prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer);
                            }                      
                        }
                    }
                }
            }
        }
    }    
}

private
void generatePlannedPartsMaterialsForChildsSeqInternal2(PlannedHdr plannedHdr,string spart,int iseq,decimal dqty,DateTime startDate,Hashtable hashBomSum,ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer,ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer){ 
    PlannedPart                     plannedPartNew=null;    
    ProdFmActSubDataBase            prodFmActSubDataBase= null;
    bool                            bfoundRouting = true;
    Bom                             bom = makeBom(  spart,iseq,plannedHdr.Plant,
			                                        prodFmInfoDataBaseContainer, prodFmActSubDataBaseContainer, hashBomSum);
                
    foreach(Bom bomChild in bom.getBomContainer()) {
        bfoundRouting = getProdFmActSubDataBase(out prodFmActSubDataBase, prodFmActSubDataBaseContainer,bomChild.Prod,bomChild.Seq,plannedHdr.Plant);//get routing        
        if (bfoundRouting){             
            if (prodFmActSubDataBase!= null) {                    
                //read machine
                PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);		
		        pltDeptMachDataBase.setPDM_Plt(prodFmActSubDataBase.getPC_Plt());
		        pltDeptMachDataBase.setPDM_Dept(prodFmActSubDataBase.getPC_Dept());
		        pltDeptMachDataBase.setPDM_Mach(prodFmActSubDataBase.getPC_Cfg());
		        if (pltDeptMachDataBase.read()) {                                                                         
                    plannedPartNew = generateNewPlannedPartBasedPlannedInternal(plannedHdr,plannedHdr.Plant, pltDeptMachDataBase.getPDM_ID(), bomChild.Prod, bomChild.Seq, dqty * bomChild.Qty,0,startDate,false);
                }                      
            }
        }
        generatePlannedPartsMaterialsForChildsSeqInternal2(plannedHdr, bomChild.Prod, bomChild.Seq, bomChild.Qty,startDate,hashBomSum,prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer);
    }
}

private
void generatePlannedPartsMaterialsForChildsSeqInternal(PlannedHdr plannedHdr,PlannedPart plannedPart, Hashtable hashBomSum,ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer,ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer){ 
    PlannedPart             plannedPartNew=null;
    ProdFmActSubDataBase    prodFmActSubDataBase= null;
    Bom                     bom = makeBom(plannedPart.Part, plannedPart.Seq,plannedHdr.Plant,
			                              prodFmInfoDataBaseContainer, prodFmActSubDataBaseContainer, hashBomSum);
            
    foreach(Bom bomChild in bom.getBomContainer()) {
        //read routing for part
        prodFmActSubDataBaseContainer.readByFilters(bomChild.Prod, plannedHdr.Plant,"", bomChild.Seq, "", Routing.ROUTING_TYPE_MAIN,false,1);
        if (prodFmActSubDataBaseContainer.Count > 0) { 
            if (prodFmActSubDataBase!= null) {                    
                //read machine
                PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);		
		        pltDeptMachDataBase.setPDM_Plt(prodFmActSubDataBase.getPC_Plt());
		        pltDeptMachDataBase.setPDM_Dept(prodFmActSubDataBase.getPC_Dept());
		        pltDeptMachDataBase.setPDM_Mach(prodFmActSubDataBase.getPC_Cfg());
		        if (pltDeptMachDataBase.read()) {                                                                         
                    plannedPartNew = generateNewPlannedPartBasedPlannedInternal(plannedHdr,plannedHdr.Plant, pltDeptMachDataBase.getPDM_ID(), bomChild.Prod, bomChild.Seq, plannedPart.QtyPlanned* bomChild.Qty, plannedPart.QtyOvertime,plannedPart.StartDate,false);
                }                      
            }
        }
    }
}

public
PlannedHdr createNewPlannedHdr(string splant){
    PlannedHdr plannedHdr = new PlannedHdr();
    plannedHdr.Plant = splant;
    return plannedHdr;
}

public
PlannedReq createNewPlannedReq(PlannedHdr plannedHdr, string stype,int ireqId){
    PlannedReq plannedReq = new PlannedReq();

    plannedReq.Type = stype;
    plannedReq.ReqID = ireqId;
            
    //get new detail value , get last requirment and increase detail value                                       
    int idetaild = plannedHdr.PlannedReqContainer.Count > 0 ? plannedHdr.PlannedReqContainer[plannedHdr.PlannedReqContainer.Count-1].Detail+1 : 1;
    plannedReq.HdrId  = plannedHdr.Id;
    plannedReq.Detail = idetaild;
    plannedHdr.PlannedReqContainer.Add(plannedReq);

    return plannedReq;
}

public
PlannedPart createNewPlannedPart(string spart,int iseq,decimal dqtyOriginal,decimal dqtyPlanned,decimal dqtyOvertime, DateTime date){
    PlannedPart         plannedPart = new PlannedPart();
    DateTime            dpriortMonday = date;
    DateTime            dnextSunday = date;
    ProdFmInfoDataBase  prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
    prodFmInfoDataBase.setPFS_ProdID(spart);

    plannedPart.Part = spart;
    plannedPart.Seq = iseq;
    plannedPart.QtyOriginal = dqtyOriginal;
    plannedPart.QtyPlanned  = dqtyPlanned;
    plannedPart.QtyOvertime = dqtyOvertime;

    Nujit.NujitERP.ClassLib.Util.DateUtil.getPriorMondayNextSundayFromDate(date, out dpriortMonday, out dnextSunday);
        
    plannedPart.StartDate = dpriortMonday;
    plannedPart.EndDate = dnextSunday;
            
    if (prodFmInfoDataBase.read()){
        plannedPart.IsFamily = prodFmInfoDataBase.getPFS_FamProd();
    }

    return plannedPart;
}

public
PlannedLabour createNewPlannedLabour(int ilabourTypeId,DateTime date,int ishiftNum){
    PlannedLabour       plannedLabour = new PlannedLabour();
    DateTime            dpriortMonday = date;
    DateTime            dnextSunday = date;

    plannedLabour.LabourTypeId = ilabourTypeId;    
        
    Nujit.NujitERP.ClassLib.Util.DateUtil.getPriorMondayNextSundayFromDate(date, out dpriortMonday, out dnextSunday);
        
    plannedLabour.StartDate = dpriortMonday;
    plannedLabour.EndDate = dnextSunday;
    plannedLabour.ShiftNum= ishiftNum;
             
    return plannedLabour;
}

public
void getPlannedPartViewByFilters(string splant,string spart,int seq){
    try { 
        PlannedPartViewDataBaseContainer    plannedPartViewDataBaseContainer = new PlannedPartViewDataBaseContainer(dataBaseAccess);
        int                                 ihdrId =0;

        PlannedHdrDataBase plannedHdrDataBase = new PlannedHdrDataBase(dataBaseAccess);
        if (plannedHdrDataBase.readLastByFilter(splant))
            ihdrId = plannedHdrDataBase.getId();

        plannedPartViewDataBaseContainer.readForReport(splant,ihdrId,spart,seq);
    

    }catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
}

internal
void updatePlannedHdrOnlyPlannedReqInternal(PlannedHdr plannedHdr,PlannedReq plannedReq,bool bisNewReq){	
	updatePlannedHdrOnly(plannedHdr);

    if (!bisNewReq)
        deletePlannedReqChilds(plannedReq.HdrId,plannedReq.Detail);        
    writePlannedReqChilds(plannedReq);
}

public 
void updatePlannedHdrOnlyPlannedReq(PlannedHdr plannedHdr,PlannedReq plannedReq,bool bisNewReq){
	try{
        if (!userHandleTransaction)
		    dataBaseAccess.beginTransaction();

		updatePlannedHdrOnlyPlannedReqInternal(plannedHdr,plannedReq,bisNewReq);

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
bool readPlannedPartsHash(string splant,ref DateTime plannedDateTimeStamp,ref Hashtable hashPlannedParts){
    try{ 
        //we will summarize plannedpart records by part/seq 
        PlannedHdrDataBase      plannedHdrDataBase = new PlannedHdrDataBase(dataBaseAccess);
        PlannedPartContainer    plannedPartContainer = new PlannedPartContainer();
        PlannedPart             plannedPart = null;
        string                  skey = "";       
        bool                    bresult = plannedHdrDataBase.readLastByFilter(splant);

        if (bresult &&  plannedDateTimeStamp != plannedHdrDataBase.getDateTimeStamp()) {                                    
            plannedDateTimeStamp = plannedHdrDataBase.getDateTimeStamp();//store datetimestamp
                                
            PlannedPartDataBaseContainer plannedPartDataBaseContainer = new PlannedPartDataBaseContainer(dataBaseAccess);
            plannedPartDataBaseContainer.readByHdrAll(plannedHdrDataBase.getId());    //read all parts

            foreach(PlannedPartDataBase plannedPartDataBase in plannedPartDataBaseContainer){

                plannedPart = objectDataBaseToObject(plannedPartDataBase);
                skey = plannedPart.Part.ToUpper() + Constants.DEFAULT_SEP + plannedPart.Seq.ToString();         

                if (hashPlannedParts.Contains(skey))
                    plannedPartContainer = (PlannedPartContainer)hashPlannedParts[skey];                
                else{
                    plannedPartContainer = new PlannedPartContainer();
                    hashPlannedParts.Add(skey,plannedPartContainer);
                }
                plannedPartContainer.Add(plannedPart);
            }
        }       
        return bresult;

    }catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
}

/****************************************** PlannedPriority ******************************************************************/

public
PlannedPriority createPlannedPriority(){
	return new PlannedPriority();
}

public
PlannedPriorityContainer createPlannedPriorityContainer(){
	return new PlannedPriorityContainer();
}

private
PlannedPriority objectDataBaseToObject(PlannedPriorityDataBase plannedPriorityDataBase){
	PlannedPriority plannedPriority = new PlannedPriority();

	plannedPriority.HdrId=plannedPriorityDataBase.getHdrId();
	plannedPriority.Detail=plannedPriorityDataBase.getDetail();
	plannedPriority.MachineId=plannedPriorityDataBase.getMachineId();
	plannedPriority.MachPriority=plannedPriorityDataBase.getMachPriority();
	plannedPriority.Planned=plannedPriorityDataBase.getPlanned();
	plannedPriority.Labour=plannedPriorityDataBase.getLabour();
	plannedPriority.Part=plannedPriorityDataBase.getPart();
	plannedPriority.QtyPlanned=plannedPriorityDataBase.getQtyPlanned();

	return plannedPriority;
}

private
PlannedPriorityDataBase objectToObjectDataBase(PlannedPriority plannedPriority){
	PlannedPriorityDataBase plannedPriorityDataBase = new PlannedPriorityDataBase(dataBaseAccess);
	plannedPriorityDataBase.setHdrId(plannedPriority.HdrId);
	plannedPriorityDataBase.setDetail(plannedPriority.Detail);
	plannedPriorityDataBase.setMachineId(plannedPriority.MachineId);
	plannedPriorityDataBase.setMachPriority(plannedPriority.MachPriority);
	plannedPriorityDataBase.setPlanned(plannedPriority.Planned);
	plannedPriorityDataBase.setLabour(plannedPriority.Labour);
	plannedPriorityDataBase.setPart(plannedPriority.Part);
	plannedPriorityDataBase.setQtyPlanned(plannedPriority.QtyPlanned);

	return plannedPriorityDataBase;
}

public
PlannedPriority clonePlannedPriority(PlannedPriority plannedPriority){
	PlannedPriority plannedPriorityClone = new PlannedPriority();

	plannedPriorityClone.HdrId=plannedPriority.HdrId;
	plannedPriorityClone.Detail=plannedPriority.Detail;
	plannedPriorityClone.MachineId=plannedPriority.MachineId;
	plannedPriorityClone.MachPriority=plannedPriority.MachPriority;
	plannedPriorityClone.Planned=plannedPriority.Planned;
	plannedPriorityClone.Labour=plannedPriority.Labour;
	plannedPriorityClone.Part=plannedPriority.Part;
	plannedPriorityClone.QtyPlanned=plannedPriority.QtyPlanned;

	return plannedPriorityClone;
}


/************************************************     PlannedReq    *********************************************************/
public
PlannedReq createPlannedReq(){
	return new PlannedReq();
}

public
PlannedReqContainer createPlannedReqContainer(){
	return new PlannedReqContainer();
}

private
PlannedReq objectDataBaseToObject(PlannedReqDataBase plannedReqDataBase){
	PlannedReq plannedReq = new PlannedReq();

	plannedReq.HdrId=plannedReqDataBase.getHdrId();
	plannedReq.Detail=plannedReqDataBase.getDetail();
	plannedReq.Type=plannedReqDataBase.getType();
	plannedReq.ReqID=plannedReqDataBase.getReqID();

	return plannedReq;
}

private
PlannedReqDataBase objectToObjectDataBase(PlannedReq plannedReq){
	PlannedReqDataBase plannedReqDataBase = new PlannedReqDataBase(dataBaseAccess);
	plannedReqDataBase.setHdrId(plannedReq.HdrId);
	plannedReqDataBase.setDetail(plannedReq.Detail);
	plannedReqDataBase.setType(plannedReq.Type);
	plannedReqDataBase.setReqID(plannedReq.ReqID);

	return plannedReqDataBase;
}

public
PlannedReq clonePlannedReq(PlannedReq plannedReq){
	PlannedReq plannedReqClone = new PlannedReq();
    plannedReqClone.copy(plannedReq);
	
	return plannedReqClone;
}

/*************************************************        ***********************************************************************/

public
PlannedPart createPlannedPart(){
	return new PlannedPart();
}

public
PlannedPartContainer createPlannedPartContainer(){
	return new PlannedPartContainer();
}


private
PlannedPart objectDataBaseToObject(PlannedPartDataBase plannedPartDataBase){
	PlannedPart plannedPart = new PlannedPart();

	plannedPart.HdrId=plannedPartDataBase.getHdrId();
	plannedPart.Detail=plannedPartDataBase.getDetail();
	plannedPart.SubDetail=plannedPartDataBase.getSubDetail();
	plannedPart.Part=plannedPartDataBase.getPart();
	plannedPart.Seq=plannedPartDataBase.getSeq();
	plannedPart.IsFamily=plannedPartDataBase.getIsFamily();
	plannedPart.QtyOriginal=plannedPartDataBase.getQtyOriginal();
	plannedPart.QtyPlanned=plannedPartDataBase.getQtyPlanned();
    plannedPart.QtyChange=plannedPartDataBase.getQtyChange();
    plannedPart.QtyOvertime=plannedPartDataBase.getQtyOvertime();
	plannedPart.StartDate=plannedPartDataBase.getStartDate();
	plannedPart.EndDate=plannedPartDataBase.getEndDate();
    plannedPart.ProfMachPlanHdrId = plannedPartDataBase.getProfMachPlanHdrId();
    plannedPart.ProfMachPlanHdrDtl =plannedPartDataBase.getProfMachPlanHdrDtl();

	return plannedPart;
}

private
PlannedPartDataBase objectToObjectDataBase(PlannedPart plannedPart){
	PlannedPartDataBase plannedPartDataBase = new PlannedPartDataBase(dataBaseAccess);
	plannedPartDataBase.setHdrId(plannedPart.HdrId);
	plannedPartDataBase.setDetail(plannedPart.Detail);
	plannedPartDataBase.setSubDetail(plannedPart.SubDetail);
	plannedPartDataBase.setPart(plannedPart.Part);
	plannedPartDataBase.setSeq(plannedPart.Seq);
	plannedPartDataBase.setIsFamily(plannedPart.IsFamily);
	plannedPartDataBase.setQtyOriginal(plannedPart.QtyOriginal);
	plannedPartDataBase.setQtyPlanned(plannedPart.QtyPlanned);
    plannedPartDataBase.setQtyChange(plannedPart.QtyChange);
    plannedPartDataBase.setQtyOvertime(plannedPart.QtyOvertime);
	plannedPartDataBase.setStartDate(plannedPart.StartDate);
	plannedPartDataBase.setEndDate(plannedPart.EndDate);
    plannedPartDataBase.setProfMachPlanHdrId(plannedPart.ProfMachPlanHdrId);
    plannedPartDataBase.setProfMachPlanHdrDtl(plannedPart.ProfMachPlanHdrDtl);

	return plannedPartDataBase;
}

public
PlannedPart clonePlannedPart(PlannedPart plannedPart){
	PlannedPart plannedPartClone = new PlannedPart();
    plannedPartClone.copy(plannedPart);
	return plannedPartClone;
}

/******************************************* PlannedLabour *****************************************************************/
public
PlannedLabour createPlannedLabour(){
	return new PlannedLabour();
}

public
PlannedLabourContainer createPlannedLabourContainer(){
	return new PlannedLabourContainer();
}

private
PlannedLabour objectDataBaseToObject(PlannedLabourDataBase plannedLabourDataBase){
	PlannedLabour plannedLabour = new PlannedLabour();

	plannedLabour.HdrId=plannedLabourDataBase.getHdrId();
	plannedLabour.Detail=plannedLabourDataBase.getDetail();
	plannedLabour.SubDetail=plannedLabourDataBase.getSubDetail();
	plannedLabour.LabourTypeId=plannedLabourDataBase.getLabourTypeId();
	plannedLabour.Hours=plannedLabourDataBase.getHours();
    plannedLabour.TotEmployPlan = plannedLabourDataBase.getTotEmployPlan();
    plannedLabour.TotEmployOver = plannedLabourDataBase.getTotEmployOver();
    plannedLabour.TotEmployTemp = plannedLabourDataBase.getTotEmployTemp();

    plannedLabour.TotEmployHire = plannedLabourDataBase.getTotEmployHire();
    plannedLabour.TotEmployVacation = plannedLabourDataBase.getTotEmployVacation();
    plannedLabour.TotEmployAbsent = plannedLabourDataBase.getTotEmployAbsent();        
    plannedLabour.ShiftNum = plannedLabourDataBase.getShiftNum();

	plannedLabour.StartDate=plannedLabourDataBase.getStartDate();
	plannedLabour.EndDate=plannedLabourDataBase.getEndDate();

	return plannedLabour;
}

private
PlannedLabourDataBase objectToObjectDataBase(PlannedLabour plannedLabour){
	PlannedLabourDataBase plannedLabourDataBase = new PlannedLabourDataBase(dataBaseAccess);
	plannedLabourDataBase.setHdrId(plannedLabour.HdrId);
	plannedLabourDataBase.setDetail(plannedLabour.Detail);
	plannedLabourDataBase.setSubDetail(plannedLabour.SubDetail);
	plannedLabourDataBase.setLabourTypeId(plannedLabour.LabourTypeId);
	plannedLabourDataBase.setHours(plannedLabour.Hours);
    plannedLabourDataBase.setTotEmployPlan(plannedLabour.TotEmployPlan);
    plannedLabourDataBase.setTotEmployOver(plannedLabour.TotEmployOver);
    plannedLabourDataBase.setTotEmployTemp(plannedLabour.TotEmployTemp);

    plannedLabourDataBase.setTotEmployHire(plannedLabour.TotEmployHire);
    plannedLabourDataBase.setTotEmployVacation(plannedLabour.TotEmployVacation);
    plannedLabourDataBase.setTotEmployAbsent(plannedLabour.TotEmployAbsent);
    plannedLabourDataBase.setShiftNum(plannedLabour.ShiftNum);
    
	plannedLabourDataBase.setStartDate(plannedLabour.StartDate);
	plannedLabourDataBase.setEndDate(plannedLabour.EndDate);

	return plannedLabourDataBase;
}

public
PlannedLabour clonePlannedLabour(PlannedLabour plannedLabour){
	PlannedLabour plannedLabourClone = new PlannedLabour();
    plannedLabourClone.copy(plannedLabour);
	
	return plannedLabourClone;
}

private
decimal getHotListQtyRequired(string splant,string spart,int iseq,DateTime from,DateTime to){
    HotListHdr          hotListHdr = readLastHotList(splant);
    decimal             dqtyRequired = 0;

    if (hotListHdr!= null) { 
        HotListContainer    hotListContainer = readHotListByFilters(hotListHdr.Id,"","","","",-1,spart,iseq,"","",true,false,0);          
        HotList             hotList = null;
         
        if (hotListContainer.Count  > 0){
            hotList = hotListContainer[0];
            dqtyRequired = hotList.getQtyByRangeDate(hotListHdr.HotlistRunDate,from,to);
        }
    }
    return dqtyRequired;
}

private 
decimal getInventory(string spart,int iseq,string splant){        
    Inventory   inventory = readInventory(spart,splant);
    decimal     dqoh = inventory!= null ? inventory.getTotalInventory(iseq) : 0;
    
    return dqoh;                    
}

public
bool compareNewHotListVsPriorHotListFillPlannedQtyChange(string splant){
    bool                bresult = false;
    try{
        PlannedHdr          plannedHdr = readPlannedHdrLast(splant);
        HotListHdr          hotListHdrPrior = readPriorLastHotList(splant);
        HotListHdr          hotListHdr      = readLastHotList(splant);
        HotListContainer    hotListContainerPrior = null;
        HotListContainer    hotListContainer = null;
        HotList             hotListPrior=null;
        HotList             hotList=null;
        PlannedReq          plannedReq = null;
        PlannedPart         plannedPart= null;
        ArrayList           arrayDates = CapacityView.getDateTimeWeekList(false);
        DateTime            priorMonday= (DateTime)arrayDates[0]; //first monday
        DateTime            currMonday= DateTime.Now;
        DateTime            currSunday= DateTime.Now;
        decimal             dqtyPrior=0;
        decimal             dqty=0;
        decimal             dqtyDifference=0;
        bool                bchanged=false;

        if (plannedHdr!= null && hotListHdrPrior!= null && hotListHdr!= null){
            hotListContainerPrior   = readHotListByFilters(hotListHdrPrior.Id, hotListHdrPrior.Plant,"","","",0,"",-1,"","",true,false,0);
            hotListContainer        = readHotListByFilters(hotListHdr.Id     , hotListHdr.Plant     ,"","","",0,"",-1,"","",true,false,0);

            for (int i=0; i < plannedHdr.PlannedReqContainer.Count; i++){
                plannedReq = plannedHdr.PlannedReqContainer[i];
                if (plannedReq.Type.Equals(Constants.TYPE_MACHINE)){

                    for (int j=0; j < plannedReq.PlannedPartContainer.Count; j++){
                
                        plannedPart = plannedReq.PlannedPartContainer[j];
                        if (plannedPart.StartDate >= priorMonday){

                            hotListPrior= hotListContainerPrior.getByPartSeq(plannedPart.Part,plannedPart.Seq);
                            hotList     = hotListContainer.getByPartSeq(plannedPart.Part,plannedPart.Seq);

                            dqtyPrior   = hotListPrior!= null? hotListPrior.getQtyByRangeDate(hotListHdrPrior.HotlistRunDate,plannedPart.StartDate,plannedPart.EndDate) : 0;
                            dqty        = hotList!= null     ? hotList.getQtyByRangeDate     (hotListHdr.HotlistRunDate,plannedPart.StartDate,plannedPart.EndDate) : 0;
                            dqtyPrior   = Math.Abs(dqtyPrior);
                            dqty        = Math.Abs(dqty);

                            dqtyDifference = dqty - dqtyPrior;
                            if (dqtyDifference > 0 && plannedPart.QtyPlanned < dqty){
                                plannedPart.QtyChange = dqtyDifference;
                                bchanged=true;
                            }
                        }                                        
                    }
                }           
            }

            if (bchanged)
                updatePlannedHdr(plannedHdr);
            bresult=true;
        }

    }catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
    return bresult;
}

public
bool existsPlannedPartSfiftProfileMachine(int iprofShiftHdrId,int iprofShiftHdrDtl){
	try{
		PlannedPartDataBase plannedHdrDataBase = new PlannedPartDataBase(dataBaseAccess);
        return plannedHdrDataBase.existsShifrProfile(iprofShiftHdrId,iprofShiftHdrDtl);
		
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

} // class

} // namespace
