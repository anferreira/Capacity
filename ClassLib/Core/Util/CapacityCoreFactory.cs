using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using System.Collections;
using System;


namespace Nujit.NujitERP.ClassLib.Core.Util{


public 
class CapacityCoreFactory : BomCoreFactory{

public 
CapacityCoreFactory(): base(){
}

public 
Capacity createCapacity(){
	CapMacHrDataBaseContainer capMacHrDataBaseContainer = new CapMacHrDataBaseContainer(dataBaseAccess);
    return new Capacity(capMacHrDataBaseContainer);
}

public
bool existsCapacity(string version, string plt, string dept, string mach){
	try{
	    CapMacHrDataBaseContainer capMacHrDataBaseContainer = new CapMacHrDataBaseContainer(dataBaseAccess);
		capMacHrDataBaseContainer.setCMH_Plt(plt);
		capMacHrDataBaseContainer.setCMH_Dept(dept);
		capMacHrDataBaseContainer.setCMH_Mach(mach);
		capMacHrDataBaseContainer.setCMH_SchVersion(version);
		capMacHrDataBaseContainer.readByPltDeptMachVersion();
		return capMacHrDataBaseContainer.Count > 0;
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
Capacity readCapacity(string version, string plt, string dept, string mach){
	try{
	    CapMacHrDataBaseContainer capMacHrDataBaseContainer = new CapMacHrDataBaseContainer(dataBaseAccess);
		capMacHrDataBaseContainer.setCMH_Plt(plt);
		capMacHrDataBaseContainer.setCMH_Dept(dept);
		capMacHrDataBaseContainer.setCMH_Mach(mach);
		capMacHrDataBaseContainer.setCMH_SchVersion(version);
		capMacHrDataBaseContainer.readByPltDeptMachVersion();
		return new Capacity(version, plt, dept, mach, capMacHrDataBaseContainer);
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
void writeCapacity(Capacity capacity){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

	    CapMacHrDataBaseContainer capMacHrDataBaseContainer = capacity.getCapMacHrDataBaseContainer();
		capMacHrDataBaseContainer.write();
		
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
void updateCapacity(Capacity capacity){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		/*
		CapMacCfgDataBase capMacCfgDataBase = null;
		CapMacCfgADataBase capMacCfgADataBase = new CapMacCfgADataBase(dataBaseAccess);
	    capMacCfgADataBase.setCMCA_Plt(capacity.getPlt());
	    capMacCfgADataBase.setCMCA_Dept(capacity.getDept());
	    capMacCfgADataBase.setCMCA_Mach(capacity.getMach());
		if (capMacCfgADataBase.existsByPltDeptMach()){
		    capMacCfgADataBase.readByPltDeptMach();

			capMacCfgDataBase = new CapMacCfgDataBase(dataBaseAccess);
			capMacCfgDataBase.setCMC_Cfg(capMacCfgADataBase.getCMCA_Cfg());
			capMacCfgDataBase.setCMC_Plt(capacity.getPlt());
			capMacCfgDataBase.setCMC_Dept(capacity.getDept());
			capMacCfgDataBase.read();
		}
		*/

		CapMacHrDataBaseContainer forDeleteContainer = new CapMacHrDataBaseContainer(dataBaseAccess);
		forDeleteContainer.setCMH_Plt(capacity.getPlt());
		forDeleteContainer.setCMH_Dept(capacity.getDept());
		forDeleteContainer.setCMH_Mach(capacity.getMach());
		forDeleteContainer.setCMH_SchVersion(capacity.getVersion());
		forDeleteContainer.readByPltDeptMachVersion();

		/*
		for(int i = 0; i < forDeleteContainer.Count; i++){
			CapMacHrDataBase forDelete = (CapMacHrDataBase)forDeleteContainer[i];

			//-------------------------------------------- ----------------------------------------------
			CapMacDayDataBase capMacDayDataBase = new CapMacDayDataBase(forDelete.getDataBaseAccess());
			capMacDayDataBase.setCMD_SchVersion(capacity.getVersion());
			capMacDayDataBase.setCMD_Plt(capacity.getPlt());
			capMacDayDataBase.setCMD_Dept(capacity.getDept());
			capMacDayDataBase.setCMD_Mach(capacity.getMach());
			capMacDayDataBase.setCMD_TmType(forDelete.getCMH_TmType());
			capMacDayDataBase.setCMD_Dt(forDelete.getCMH_Dt());
			if (capMacDayDataBase.exists()){
				capMacDayDataBase.read();
				capMacDayDataBase.setCMD_Hr(capMacDayDataBase.getCMD_Hr() - forDelete.getCMH_Hr());
				capMacDayDataBase.setCMD_HrPr(capMacDayDataBase.getCMD_HrPr() - forDelete.getCMH_HrPr());
				capMacDayDataBase.update();
			}

			//------------------------------------------------------------------------------------------
			CapMacShfDataBase capMacShfDataBase = new CapMacShfDataBase(forDelete.getDataBaseAccess());
			capMacShfDataBase.setCMS_SchVersion(capacity.getVersion());
			capMacShfDataBase.setCMS_Plt(capacity.getPlt());
			capMacShfDataBase.setCMS_Dept(capacity.getDept());
			capMacShfDataBase.setCMS_Mach(capacity.getMach());
			capMacShfDataBase.setCMS_TmType(forDelete.getCMH_TmType());
			capMacShfDataBase.setCMS_Dt(forDelete.getCMH_Dt());
			capMacShfDataBase.setCMS_Shf(forDelete.getCMH_Shf());
			if (capMacShfDataBase.exists()){
				capMacShfDataBase.read();
				capMacShfDataBase.setCMS_Hr(capMacShfDataBase.getCMS_Hr() - forDelete.getCMH_Hr());
				capMacShfDataBase.setCMS_HrPr(capMacShfDataBase.getCMS_HrPr() - forDelete.getCMH_HrPr());
				capMacShfDataBase.update();
			}

			//------------------------------------------------------------------------------------------
			CapMacWkDataBase capMacWkDataBase = new CapMacWkDataBase(forDelete.getDataBaseAccess());
			capMacWkDataBase.setCMW_SchVersion(capacity.getVersion());
			capMacWkDataBase.setCMW_Plt(capacity.getPlt());
			capMacWkDataBase.setCMW_Dept(capacity.getDept());
			capMacWkDataBase.setCMW_Mach(capacity.getMach());
			capMacWkDataBase.setCMW_TmType(forDelete.getCMH_TmType());
			capMacWkDataBase.setCMW_Wk(forDelete.getCMH_Wk());
			capMacWkDataBase.setCMW_Year(forDelete.getCMH_Dt().Year);
			if (capMacWkDataBase.exists()){
				capMacWkDataBase.read();
				capMacWkDataBase.setCMW_Hr(capMacWkDataBase.getCMW_Hr() - forDelete.getCMH_Hr());
				capMacWkDataBase.setCMW_HrPr(capMacWkDataBase.getCMW_HrPr() - forDelete.getCMH_HrPr());
				capMacWkDataBase.update();
			}

			if (capMacCfgDataBase != null){
				//------------------------------------------------------------------------------------------
				CapCfgDayDataBase capCfgDayDataBase = new CapCfgDayDataBase(forDelete.getDataBaseAccess());
				capCfgDayDataBase.setCCD_SchVersion(capacity.getVersion());
				capCfgDayDataBase.setCCD_Plt(capacity.getPlt());
				capCfgDayDataBase.setCCD_Dept(capacity.getDept());
				capCfgDayDataBase.setCCD_Cfg(capMacCfgDataBase.getCMC_Cfg());
				capCfgDayDataBase.setCCD_Dt(forDelete.getCMH_Dt());
				capCfgDayDataBase.setCCD_TmType(forDelete.getCMH_TmType());
				if (capCfgDayDataBase.exists()){
					capCfgDayDataBase.read();
					capCfgDayDataBase.setCCD_Hr(capCfgDayDataBase.getCCD_Hr() - forDelete.getCMH_Hr());
					capCfgDayDataBase.setCCD_HrPr(capCfgDayDataBase.getCCD_HrPr() - forDelete.getCMH_HrPr());
					capCfgDayDataBase.update();
				}

				//------------------------------------------------------------------------------------------
				CapCfgShfDataBase capCfgShfDataBase = new CapCfgShfDataBase(forDelete.getDataBaseAccess());
				capCfgShfDataBase.setCCH_SchVersion(capacity.getVersion());
				capCfgShfDataBase.setCCH_Plt(capacity.getPlt());
				capCfgShfDataBase.setCCH_Dept(capacity.getDept());
				capCfgShfDataBase.setCCH_Cfg(capMacCfgDataBase.getCMC_Cfg());
				capCfgShfDataBase.setCCH_Dt(forDelete.getCMH_Dt());
				capCfgShfDataBase.setCCH_Shf(forDelete.getCMH_Shf());
				capCfgShfDataBase.setCCH_TmType(forDelete.getCMH_TmType());
				if (capCfgShfDataBase.exists()){
					capCfgShfDataBase.read();
					capCfgShfDataBase.setCCH_Hr(capCfgShfDataBase.getCCH_Hr() - forDelete.getCMH_Hr());
					capCfgShfDataBase.setCCH_HrPr(capCfgShfDataBase.getCCH_HrPr() - forDelete.getCMH_HrPr());
					capCfgShfDataBase.update();
				}

				//------------------------------------------------------------------------------------------
				CapCfgWkDataBase capCfgWkDataBase = new CapCfgWkDataBase(forDelete.getDataBaseAccess());
				capCfgWkDataBase.setCCW_SchVersion(capacity.getVersion());
				capCfgWkDataBase.setCCW_Plt(capacity.getPlt());
				capCfgWkDataBase.setCCW_Dept(capacity.getDept());
				capCfgWkDataBase.setCCW_Cfg(capMacCfgDataBase.getCMC_Cfg());
				capCfgWkDataBase.setCCW_Wk(forDelete.getCMH_Wk());
				capCfgWkDataBase.setCCW_Year(forDelete.getCMH_Dt().Year);
				capCfgWkDataBase.setCCW_TmType(forDelete.getCMH_TmType());
				if (capCfgWkDataBase.exists()){
					capCfgWkDataBase.read();
					capCfgWkDataBase.setCCW_Hr(capCfgWkDataBase.getCCW_Hr() - forDelete.getCMH_Hr());
					capCfgWkDataBase.setCCW_HrPr(capCfgWkDataBase.getCCW_HrPr() - forDelete.getCMH_HrPr());
					capCfgWkDataBase.update();
				}

				capMacCfgDataBase.setCMC_TotalHrs(capMacCfgDataBase.getCMC_TotalHrs() - forDelete.getCMH_Hr());
				capMacCfgDataBase.setCMC_TotalHrsPr(capMacCfgDataBase.getCMC_TotalHrsPr() - forDelete.getCMH_HrPr());
			}
		}
		*/
		
		forDeleteContainer.delete();
		/*
		capMacCfgDataBase.update();
		*/
		
		CapMacHrDataBaseContainer forWriteContainer = capacity.getCapMacHrDataBaseContainer();

		/*
		for(int i = 0; i < forWriteContainer.Count; i++){
			CapMacHrDataBase forWrite = (CapMacHrDataBase)forWriteContainer[i];

			//------------------------------------------------------------------------------------------
			CapMacDayDataBase capMacDayDataBase = new CapMacDayDataBase(forWrite.getDataBaseAccess());
			capMacDayDataBase.setCMD_SchVersion(capacity.getVersion());
			capMacDayDataBase.setCMD_Plt(capacity.getPlt());
			capMacDayDataBase.setCMD_Dept(capacity.getDept());
			capMacDayDataBase.setCMD_Mach(capacity.getMach());
			capMacDayDataBase.setCMD_TmType(forWrite.getCMH_TmType());
			capMacDayDataBase.setCMD_Dt(forWrite.getCMH_Dt());
			capMacDayDataBase.setCMD_Wk(forWrite.getCMH_Wk());
			if (capMacDayDataBase.exists()){
				capMacDayDataBase.read();
				capMacDayDataBase.setCMD_Hr(capMacDayDataBase.getCMD_Hr() + forWrite.getCMH_Hr());
				capMacDayDataBase.setCMD_HrPr(capMacDayDataBase.getCMD_HrPr() + forWrite.getCMH_HrPr());
				capMacDayDataBase.update();
			}else{
				capMacDayDataBase.setCMD_Hr(forWrite.getCMH_Hr());
				capMacDayDataBase.setCMD_HrPr(forWrite.getCMH_HrPr());
				capMacDayDataBase.write();
			}

			//------------------------------------------------------------------------------------------
			CapMacShfDataBase capMacShfDataBase = new CapMacShfDataBase(forWrite.getDataBaseAccess());
			capMacShfDataBase.setCMS_SchVersion(capacity.getVersion());
			capMacShfDataBase.setCMS_Plt(capacity.getPlt());
			capMacShfDataBase.setCMS_Dept(capacity.getDept());
			capMacShfDataBase.setCMS_Mach(capacity.getMach());
			capMacShfDataBase.setCMS_TmType(forWrite.getCMH_TmType());
			capMacShfDataBase.setCMS_Dt(forWrite.getCMH_Dt());
			capMacShfDataBase.setCMS_Shf(forWrite.getCMH_Shf());
			capMacShfDataBase.setCMS_Wk(forWrite.getCMH_Wk());
			if (capMacShfDataBase.exists()){
				capMacShfDataBase.read();
				capMacShfDataBase.setCMS_Hr(capMacShfDataBase.getCMS_Hr() + forWrite.getCMH_Hr());
				capMacShfDataBase.setCMS_HrPr(capMacShfDataBase.getCMS_HrPr() + forWrite.getCMH_HrPr());
				capMacShfDataBase.update();
			}else{
				capMacShfDataBase.setCMS_Hr(forWrite.getCMH_Hr());
				capMacShfDataBase.setCMS_HrPr(forWrite.getCMH_HrPr());
				capMacShfDataBase.write();
			}

			//------------------------------------------------------------------------------------------
			CapMacWkDataBase capMacWkDataBase = new CapMacWkDataBase(forWrite.getDataBaseAccess());
			capMacWkDataBase.setCMW_SchVersion(capacity.getVersion());
			capMacWkDataBase.setCMW_Plt(capacity.getPlt());
			capMacWkDataBase.setCMW_Dept(capacity.getDept());
			capMacWkDataBase.setCMW_Mach(capacity.getMach());
			capMacWkDataBase.setCMW_TmType(forWrite.getCMH_TmType());
			capMacWkDataBase.setCMW_Wk(forWrite.getCMH_Wk());
			capMacWkDataBase.setCMW_Year(forWrite.getCMH_Dt().Year);
			if (capMacWkDataBase.exists()){
				capMacWkDataBase.read();
				capMacWkDataBase.setCMW_Hr(capMacWkDataBase.getCMW_Hr() + forWrite.getCMH_Hr());
				capMacWkDataBase.setCMW_HrPr(capMacWkDataBase.getCMW_HrPr() + forWrite.getCMH_HrPr());
				capMacWkDataBase.update();
			}else{
				capMacWkDataBase.setCMW_WkAcc(forWrite.getCMH_Wk());
				capMacWkDataBase.setCMW_Hr(forWrite.getCMH_Hr());
				capMacWkDataBase.setCMW_HrPr(forWrite.getCMH_HrPr());
				capMacWkDataBase.write();
			}
		
			if (capMacCfgDataBase != null){
				//------------------------------------------------------------------------------------------
				CapCfgDayDataBase capCfgDayDataBase = new CapCfgDayDataBase(forWrite.getDataBaseAccess());
				capCfgDayDataBase.setCCD_SchVersion(capacity.getVersion());
				capCfgDayDataBase.setCCD_Plt(capacity.getPlt());
				capCfgDayDataBase.setCCD_Dept(capacity.getDept());
				capCfgDayDataBase.setCCD_Cfg(capMacCfgDataBase.getCMC_Cfg());
				capCfgDayDataBase.setCCD_Dt(forWrite.getCMH_Dt());
				capCfgDayDataBase.setCCD_TmType(forWrite.getCMH_TmType());
				if (capCfgDayDataBase.exists()){
					capCfgDayDataBase.read();
					capCfgDayDataBase.setCCD_Hr(capCfgDayDataBase.getCCD_Hr() + forWrite.getCMH_Hr());
					capCfgDayDataBase.setCCD_HrPr(capCfgDayDataBase.getCCD_HrPr() + forWrite.getCMH_HrPr());
					capCfgDayDataBase.update();
				}else{
					capCfgDayDataBase.setCCD_Hr(forWrite.getCMH_Hr());
					capCfgDayDataBase.setCCD_HrPr(forWrite.getCMH_HrPr());
					capCfgDayDataBase.write();
				}

				//------------------------------------------------------------------------------------------
				CapCfgShfDataBase capCfgShfDataBase = new CapCfgShfDataBase(forWrite.getDataBaseAccess());
				capCfgShfDataBase.setCCH_SchVersion(capacity.getVersion());
				capCfgShfDataBase.setCCH_Plt(capacity.getPlt());
				capCfgShfDataBase.setCCH_Dept(capacity.getDept());
				capCfgShfDataBase.setCCH_Cfg(capMacCfgDataBase.getCMC_Cfg());
				capCfgShfDataBase.setCCH_Dt(forWrite.getCMH_Dt());
				capCfgShfDataBase.setCCH_Shf(forWrite.getCMH_Shf());
				capCfgShfDataBase.setCCH_TmType(forWrite.getCMH_TmType());
				if (capCfgShfDataBase.exists()){
					capCfgShfDataBase.read();
					capCfgShfDataBase.setCCH_Hr(capCfgShfDataBase.getCCH_Hr() + forWrite.getCMH_Hr());
					capCfgShfDataBase.setCCH_HrPr(capCfgShfDataBase.getCCH_HrPr() + forWrite.getCMH_HrPr());
					capCfgShfDataBase.update();
				}else{
					capCfgShfDataBase.setCCH_Hr(forWrite.getCMH_Hr());
					capCfgShfDataBase.setCCH_HrPr(forWrite.getCMH_HrPr());
					capCfgShfDataBase.write();
				}

				//------------------------------------------------------------------------------------------
				CapCfgWkDataBase capCfgWkDataBase = new CapCfgWkDataBase(forWrite.getDataBaseAccess());
				capCfgWkDataBase.setCCW_SchVersion(capacity.getVersion());
				capCfgWkDataBase.setCCW_Plt(capacity.getPlt());
				capCfgWkDataBase.setCCW_Dept(capacity.getDept());
				capCfgWkDataBase.setCCW_Cfg(capMacCfgDataBase.getCMC_Cfg());
				capCfgWkDataBase.setCCW_Wk(forWrite.getCMH_Wk());
				capCfgWkDataBase.setCCW_Year(forWrite.getCMH_Dt().Year);
				capCfgWkDataBase.setCCW_TmType(forWrite.getCMH_TmType());
				if (capCfgWkDataBase.exists()){
					capCfgWkDataBase.read();
					capCfgWkDataBase.setCCW_Hr(capCfgWkDataBase.getCCW_Hr() + forWrite.getCMH_Hr());
					capCfgWkDataBase.setCCW_HrPr(capCfgWkDataBase.getCCW_HrPr() + forWrite.getCMH_HrPr());
					capCfgWkDataBase.update();
				}else{
					capCfgWkDataBase.setCCW_Hr(forWrite.getCMH_Hr());
					capCfgWkDataBase.setCCW_HrPr(forWrite.getCMH_HrPr());
					capCfgWkDataBase.write();
				}

				capMacCfgDataBase.setCMC_TotalHrs(capMacCfgDataBase.getCMC_TotalHrs() - forWrite.getCMH_Hr());
				capMacCfgDataBase.setCMC_TotalHrsPr(capMacCfgDataBase.getCMC_TotalHrsPr() - forWrite.getCMH_HrPr());
			}
		}
		*/

		forWriteContainer.write();

		/*
		capMacCfgDataBase.update();
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

public
void deleteCapacity(Capacity capacity){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

	    CapMacHrDataBaseContainer capMacHrDataBaseContainer = new CapMacHrDataBaseContainer(dataBaseAccess);
		capMacHrDataBaseContainer.setCMH_Plt(capacity.getPlt());
		capMacHrDataBaseContainer.setCMH_Dept(capacity.getDept());
		capMacHrDataBaseContainer.setCMH_Mach(capacity.getMach());
		capMacHrDataBaseContainer.setCMH_SchVersion(capacity.getVersion());
		capMacHrDataBaseContainer.readByPltDeptMachVersion();
		capMacHrDataBaseContainer.delete();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
string[] getShiftCodesByPltDeptEnd(string plt, string dept, DateTime endDate){
    try{
	    ShiftHdrDataBaseContainer shiftHdrDataBaseContainer = new ShiftHdrDataBaseContainer(dataBaseAccess);
	    shiftHdrDataBaseContainer.setSH_Plt(plt);
	    shiftHdrDataBaseContainer.setSH_Dept(dept);
	    shiftHdrDataBaseContainer.readByPltDept();

	    int count = 0;
	    IEnumerator iEnum = shiftHdrDataBaseContainer.GetEnumerator();
	    while(iEnum.MoveNext()){
		    ShiftHdrDataBase shiftHdrDataBase = (ShiftHdrDataBase)iEnum.Current;
			
			if (shiftHdrDataBase.getSH_EndPeriod().CompareTo(endDate) <= 0)
				continue;

		    count++;
	    }
	    
	    int index = 0;
		string[] vec = new string[count];
	    iEnum = shiftHdrDataBaseContainer.GetEnumerator();
	    while(iEnum.MoveNext()){
		    ShiftHdrDataBase shiftHdrDataBase = (ShiftHdrDataBase)iEnum.Current;
			
			if (shiftHdrDataBase.getSH_EndPeriod().CompareTo(endDate) <= 0)
				continue;

		    vec[index] = shiftHdrDataBase.getSH_Shf();
		    index++;
	    }

		return vec;
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}


}//end class

}//end namespace
