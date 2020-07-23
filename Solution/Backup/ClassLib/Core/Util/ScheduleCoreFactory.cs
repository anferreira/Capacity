using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;


namespace Nujit.NujitERP.ClassLib.Core.Util{


public
class ScheduleCoreFactory : ReportsCoreFactory{

protected
ScheduleCoreFactory() : base(){
}


/// <summary>
/// read and return an Schedule object by plant code
/// </summary>
/// <param name="departament"></param>
/// <returns></returns>
public
Schedule readSchedule(string plt, string version){
    try{
		PltDeptMachDataBaseContainer pltDeptMachDataBaseContainer = new PltDeptMachDataBaseContainer(dataBaseAccess);
		pltDeptMachDataBaseContainer.setPDM_Plt(plt);
		pltDeptMachDataBaseContainer.readByPlt();
		return readSchedule(pltDeptMachDataBaseContainer, plt, version);
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// read and return an Schedule object by plant code
/// </summary>
/// <param name="pltDeptMachDataBaseContainer"></param>
/// <param name="departament"></param>
/// <returns></returns>
private
Schedule readSchedule(PltDeptMachDataBaseContainer pltDeptMachDataBaseContainer, 
		string plt, string version){
    
    try{
	    SchMachHrDataBaseContainer schMachHrDataBaseContainer = new SchMachHrDataBaseContainer(dataBaseAccess);
	    schMachHrDataBaseContainer.setSMH_SchVersion(version);
	    schMachHrDataBaseContainer.readByVersion();

	    SchPrMasDataBaseContainer schPrMasDataBaseContainer = new SchPrMasDataBaseContainer(dataBaseAccess);
	    schPrMasDataBaseContainer.setSMO_SchVersion(version);
	    schPrMasDataBaseContainer.readByVersion();

	    SchPrFmHrDataBaseContainer schPrFmHrDataBaseContainer = new SchPrFmHrDataBaseContainer(dataBaseAccess);
	    schPrFmHrDataBaseContainer.setSPH_SchVersion(version);
	    schPrFmHrDataBaseContainer.readByVersion();

	    // Family components
	    SchPrFmHrDtDataBaseContainer schPrFmHrDtDataBaseContainer = new SchPrFmHrDtDataBaseContainer(dataBaseAccess);
	    schPrFmHrDtDataBaseContainer.setSPHD_SchVersion(version);
	    schPrFmHrDtDataBaseContainer.readBySchVersion();
	    // Family components

	    SchPrOrdDataBaseContainer schPrOrdDataBaseContainer = new SchPrOrdDataBaseContainer(dataBaseAccess);
	    schPrOrdDataBaseContainer.setSPO_SchVersion(version);
	    schPrOrdDataBaseContainer.readByVersion();

	    // Family components
	    SchPrOrdDetDataBaseContainer schPrOrdDetDataBaseContainer = new SchPrOrdDetDataBaseContainer(dataBaseAccess);
	    schPrOrdDetDataBaseContainer.setSPOD_SchVersion(version);
	    schPrOrdDetDataBaseContainer.read();
	    // Family components

	    SchVersionDataBase schVersionDataBase = new SchVersionDataBase(dataBaseAccess);
	    schVersionDataBase.setSCH_Version(version);
	    schVersionDataBase.read();

	    ProdPackDtlDataBaseContainer prodPackDtlDataBaseContainer = new ProdPackDtlDataBaseContainer(dataBaseAccess);
	    prodPackDtlDataBaseContainer.setPCK_SchVersion(schVersionDataBase.getSCH_Version());
	    prodPackDtlDataBaseContainer.readBySchVersion();

	    SchMatReqDayDataBaseContainer schMatReqDayDataBaseContainer = new SchMatReqDayDataBaseContainer(dataBaseAccess);
	    schMatReqDayDataBaseContainer.readByVersion(schVersionDataBase.getSCH_Version());

	    Schedule schedule = new Schedule(plt, schVersionDataBase.getSCH_Version(), pltDeptMachDataBaseContainer, 
			schMachHrDataBaseContainer, schPrMasDataBaseContainer, schPrFmHrDataBaseContainer, 
			schPrFmHrDtDataBaseContainer, schPrOrdDataBaseContainer, schPrOrdDetDataBaseContainer, 
			schVersionDataBase, prodPackDtlDataBaseContainer, schMatReqDayDataBaseContainer);
    	
	    return schedule;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Writes an new schedule
/// </summary>
/// <param name="schedule"></param>
public
void writeSchedule(Schedule schedule){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
		
		SchMachHrDataBaseContainer objSchMachHrDataBaseContaner = schedule.getSchMachHrDataBaseContainer();
		SchPrMasDataBaseContainer objSchPrMasDataBaseContainer = schedule.getSchPrMasDataBaseContainer();
		SchPrFmHrDataBaseContainer objSchPrFmHrDataBaseContainer = schedule.getSchPrFmHrDataBaseContainer();
		SchPrFmHrDtDataBaseContainer objSchPrFmHrDtDataBaseContainer = schedule.getSchPrFmHrDtDataBaseContainer();
		SchPrOrdDataBaseContainer objSchPrOrdDataBaseContainer = schedule.getSchPrOrdDataBaseContainer();
		SchPrOrdDetDataBaseContainer objSchPrOrdDetDataBaseContainer = schedule.getSchPrOrdDetDataBaseContainer();

		objSchPrMasDataBaseContainer.write();
		objSchMachHrDataBaseContaner.write();
		objSchPrFmHrDataBaseContainer.write();
		objSchPrOrdDataBaseContainer.write();
		objSchPrFmHrDtDataBaseContainer.write();
		objSchPrOrdDetDataBaseContainer.write();
		
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

/// <summary>
/// Updates a schedule Version
/// </summary>
/// <param name="schedule"></param>
public
void updateSchedule(Schedule schedule){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		SchMachHrDataBaseContainer dbSchMachHrDataBaseContaner = new SchMachHrDataBaseContainer(dataBaseAccess);
		dbSchMachHrDataBaseContaner.setSMH_SchVersion(schedule.getSchVersion());
		dbSchMachHrDataBaseContaner.readByVersion();

		SchPrMasDataBaseContainer dbSchPrMasDataBaseContainer = new SchPrMasDataBaseContainer(dataBaseAccess);
		dbSchPrMasDataBaseContainer.setSMO_SchVersion(schedule.getSchVersion());
		dbSchPrMasDataBaseContainer.readByVersion();

		SchPrFmHrDataBaseContainer dbSchPrFmHrDataBaseContainer = new SchPrFmHrDataBaseContainer(dataBaseAccess);
		dbSchPrFmHrDataBaseContainer.setSPH_SchVersion(schedule.getSchVersion());
		dbSchPrFmHrDataBaseContainer.readByVersion();

		SchPrFmHrDtDataBaseContainer dbSchPrFmHrDtDataBaseContainer = new SchPrFmHrDtDataBaseContainer(dataBaseAccess);
		dbSchPrFmHrDtDataBaseContainer.setSPHD_SchVersion(schedule.getSchVersion());
		dbSchPrFmHrDtDataBaseContainer.readBySchVersion();

		SchPrOrdDataBaseContainer dbSchPrOrdDataBaseContainer = new SchPrOrdDataBaseContainer(dataBaseAccess);
		dbSchPrOrdDataBaseContainer.setSPO_SchVersion(schedule.getSchVersion());
		dbSchPrOrdDataBaseContainer.readByVersion();

		SchPrOrdDetDataBaseContainer dbSchPrOrdDetDataBaseContainer = new SchPrOrdDetDataBaseContainer(dataBaseAccess);
		dbSchPrOrdDetDataBaseContainer.setSPOD_SchVersion(schedule.getSchVersion());
		dbSchPrOrdDetDataBaseContainer.readBySchVersion();

		ProdPackDtlDataBaseContainer dbProdPackDtlDataBaseContainer = new ProdPackDtlDataBaseContainer(dataBaseAccess);
		dbProdPackDtlDataBaseContainer.setPCK_SchVersion(schedule.getSchVersion());
		dbProdPackDtlDataBaseContainer.readBySchVersion();

		SchMatReqDayDataBaseContainer dbSchMatReqDayDataBaseContainer = new SchMatReqDayDataBaseContainer(dataBaseAccess);
		dbSchMatReqDayDataBaseContainer.readByVersion(schedule.getSchVersion());

		dbSchPrFmHrDtDataBaseContainer.delete();
		dbSchPrFmHrDataBaseContainer.delete();
		dbSchMachHrDataBaseContaner.delete();
		dbSchPrOrdDetDataBaseContainer.delete();
		dbSchPrOrdDataBaseContainer.delete();
		dbSchPrMasDataBaseContainer.delete();
		dbProdPackDtlDataBaseContainer.delete();

		SchMachHrDataBaseContainer objSchMachHrDataBaseContaner = schedule.getSchMachHrDataBaseContainer();
		SchPrMasDataBaseContainer objSchPrMasDataBaseContainer = schedule.getSchPrMasDataBaseContainer();
		SchPrFmHrDataBaseContainer objSchPrFmHrDataBaseContainer = schedule.getSchPrFmHrDataBaseContainer();
		SchPrFmHrDtDataBaseContainer objSchPrFmHrDtDataBaseContainer = schedule.getSchPrFmHrDtDataBaseContainer();
		SchPrOrdDataBaseContainer objSchPrOrdDataBaseContainer = schedule.getSchPrOrdDataBaseContainer();
		SchPrOrdDetDataBaseContainer objSchPrOrdDetDataBaseContainer = schedule.getSchPrOrdDetDataBaseContainer();
		ProdPackDtlDataBaseContainer objProdPackDtlDataBaseContainer = schedule.getProdPackDtlDataBaseContainer();
		SchMatReqDayDataBaseContainer objSchMatReqDayDataBaseContainer = schedule.getSchMatReqDayDataBaseContainer();
/*
		for(IEnumerator en = dbSchMatReqDayDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			SchMatReqDayDataBase dbSchMatReqDayDataBase = (SchMatReqDayDataBase)en.Current;

			SchMatReqDayDataBase objSchMatReqDayDataBase = objSchMatReqDayDataBaseContainer.getRecord(dbSchMatReqDayDataBase.getSMD_ProdID(), dbSchMatReqDayDataBase.getSMD_ProdSeq(), dbSchMatReqDayDataBase.getSMD_MatReqDate());
			if ((objSchMatReqDayDataBase != null) && ((dbSchMatReqDayDataBase.getSMD_Usage().Equals("B")) ||
					(dbSchMatReqDayDataBase.getSMD_Usage().Equals("D")))){
				objSchMatReqDayDataBase.setSMD_Usage("B");
				objSchMatReqDayDataBase.setSMD_DemMatReq(dbSchMatReqDayDataBase.getSMD_DemMatReq());
			}
		}
*/
		objSchPrMasDataBaseContainer.write();
		objSchMachHrDataBaseContaner.write();
		objSchPrFmHrDataBaseContainer.write();
		objSchPrFmHrDtDataBaseContainer.write();
		objSchPrOrdDataBaseContainer.write();
		objSchPrOrdDetDataBaseContainer.write();
		objProdPackDtlDataBaseContainer.write();
/*		
		for(IEnumerator en = objSchMatReqDayDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			SchMatReqDayDataBase objSchMatReqDayDataBase = (SchMatReqDayDataBase)en.Current;

			SchMatReqDayDataBase dbSchMatReqDayDataBase = new SchMatReqDayDataBase(dataBaseAccess);
			dbSchMatReqDayDataBase.setSMD_SchVersion(objSchMatReqDayDataBase.getSMD_SchVersion());
			dbSchMatReqDayDataBase.setSMD_Plt(objSchMatReqDayDataBase.getSMD_Plt());
			dbSchMatReqDayDataBase.setSMD_Dept(objSchMatReqDayDataBase.getSMD_Dept());
			dbSchMatReqDayDataBase.setSMD_ProdID(objSchMatReqDayDataBase.getSMD_ProdID());
			dbSchMatReqDayDataBase.setSMD_ProdSeq(objSchMatReqDayDataBase.getSMD_ProdSeq());
			dbSchMatReqDayDataBase.setSMD_MatID(objSchMatReqDayDataBase.getSMD_MatID());
			dbSchMatReqDayDataBase.setSMD_MatSeq(objSchMatReqDayDataBase.getSMD_MatSeq());
			dbSchMatReqDayDataBase.setSMD_MatReqDate(objSchMatReqDayDataBase.getSMD_MatReqDate());
			if (dbSchMatReqDayDataBase.exists()){
				dbSchMatReqDayDataBase.read();

				dbSchMatReqDayDataBase.setSMD_SchMatReq(objSchMatReqDayDataBase.getSMD_SchMatReq());
				if (dbSchMatReqDayDataBase.getSMD_Usage().Equals("D") || dbSchMatReqDayDataBase.getSMD_Usage().Equals("B"))
					dbSchMatReqDayDataBase.setSMD_Usage("B");
				else
					dbSchMatReqDayDataBase.setSMD_Usage("S");

				dbSchMatReqDayDataBase.update();
			}else{
				dbSchMatReqDayDataBase.setSMD_Usage("S");
				objSchMatReqDayDataBase.write();
			}
		}
*/
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

/// <summary>
/// Deletes a Schedule Version
/// </summary>
/// <param name="schedule"></param>
public
void deleteSchedule(Schedule schedule){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		SchMachHrDataBaseContainer dbSchMachHrDataBaseContaner = new SchMachHrDataBaseContainer(dataBaseAccess);
		dbSchMachHrDataBaseContaner.setSMH_SchVersion(schedule.getSchVersion());
		dbSchMachHrDataBaseContaner.readByVersion();

		SchPrMasDataBaseContainer dbSchPrMasDataBaseContainer = new SchPrMasDataBaseContainer(dataBaseAccess);
		dbSchPrMasDataBaseContainer.setSMO_SchVersion(schedule.getSchVersion());
		dbSchPrMasDataBaseContainer.readByVersion();

		SchPrFmHrDataBaseContainer dbSchPrFmHrDataBaseContainer = new SchPrFmHrDataBaseContainer(dataBaseAccess);
		dbSchPrFmHrDataBaseContainer.setSPH_SchVersion(schedule.getSchVersion());
		dbSchPrFmHrDataBaseContainer.readByVersion();

		SchPrOrdDataBaseContainer dbSchPrOrdDataBaseContainer = new SchPrOrdDataBaseContainer(dataBaseAccess);
		dbSchPrOrdDataBaseContainer.setSPO_SchVersion(schedule.getSchVersion());
		dbSchPrOrdDataBaseContainer.readByVersion();

		dbSchPrFmHrDataBaseContainer.delete();
		dbSchMachHrDataBaseContaner.delete();
		dbSchPrOrdDataBaseContainer.delete();
		dbSchPrMasDataBaseContainer.delete();
		
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
string[] getCfgFromProd(string plt, string prod){  // [Department][Configuration]
    try{
	
	    ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
	    return prodFmActSubDataBase.getCfgFromProd(plt, prod);
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
decimal getProductionHours(string plt, string prod, decimal qty){
   
    try{
    
	    ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
	    decimal runStd = prodFmActSubDataBase.getRunStdFromProd(plt, prod);
    	
	    decimal hrPr = 0;
	    if (runStd > 0)
		    hrPr = qty / runStd;
	    else
		    hrPr = 0;
    	
	    return hrPr;
	    
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[] getMachineCodesFromConfiguration(string plt, string dept, string cfg){
    
    try{
	    CapMacCfgADataBaseContainer capMacCfgADataBaseContainer = new CapMacCfgADataBaseContainer(dataBaseAccess);
	    capMacCfgADataBaseContainer.setCMCA_Plt(plt);
	    capMacCfgADataBaseContainer.setCMCA_Dept(dept);
	    capMacCfgADataBaseContainer.setCMCA_Cfg(cfg);
	    capMacCfgADataBaseContainer.readByPltDeptCfg();

	    int i = 0;
	    string[] vec = new string[capMacCfgADataBaseContainer.Count];
	    for(IEnumerator en2 = capMacCfgADataBaseContainer.GetEnumerator(); en2.MoveNext(); ){
		    CapMacCfgADataBase capMacCfgADataBase = (CapMacCfgADataBase) en2.Current;
		    vec[i] = capMacCfgADataBase.getCMCA_Mach();
		    i++;
	    }
	    return vec;
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getScheduleForReport(string plantCode,string deptCode){
	
	try{
	
	    SchPrFmHrDataBaseContainer schPrFmHrDataBaseContainer= new SchPrFmHrDataBaseContainer(dataBaseAccess);
        return schPrFmHrDataBaseContainer.readForReport(plantCode,deptCode);
    
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
		
}

public
SchQohAssignation createSchQohAssignation()
{
	SchQohAssignDataBaseContainer schQohAssignDataBaseContainer = new SchQohAssignDataBaseContainer(dataBaseAccess);
	return new SchQohAssignation(schQohAssignDataBaseContainer);
}

public
void writeSchQohAssignation (SchQohAssignation schQohAssignation){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		schQohAssignation.getSchQohAssignDataBaseContainer().write();

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
void updateSchQohAssignation (SchQohAssignation schQohAssignation){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		SchQohAssignDataBaseContainer dbSchQohAssignDataBaseContainer = new SchQohAssignDataBaseContainer(dataBaseAccess);
		dbSchQohAssignDataBaseContainer.readByPltDeptVersion (schQohAssignation.getPlant(), schQohAssignation.getDepartament(), schQohAssignation.getSchVersion());
		
		dbSchQohAssignDataBaseContainer.delete();

		SchQohAssignDataBaseContainer objSchQohAssignDataBaseContainer = schQohAssignation.getSchQohAssignDataBaseContainer();
		for(int i = 0; i < objSchQohAssignDataBaseContainer.Count; i++){
			SchQohAssignDataBase objSchQohAssignDataBase = (SchQohAssignDataBase) objSchQohAssignDataBaseContainer[i];
			objSchQohAssignDataBase.setDataBaseAccess(dataBaseAccess);
			objSchQohAssignDataBase.write();
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
}

public
SchQohAssignation readSchQohAssignation (string plant, string department, string version){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		SchQohAssignDataBaseContainer schQohAssignDataBaseContainer = new SchQohAssignDataBaseContainer(dataBaseAccess);
		schQohAssignDataBaseContainer.readByPltDeptVersion (plant, department, version);
		
		return new SchQohAssignation (plant, department, version, schQohAssignDataBaseContainer);

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

} // class

} // namespace