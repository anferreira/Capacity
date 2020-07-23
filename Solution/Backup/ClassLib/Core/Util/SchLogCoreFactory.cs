using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Common;

namespace Nujit.NujitERP.ClassLib.Core.Util{


public
class SchLogCoreFactory : VersionCoreFactory{

public
SchLogCoreFactory() : base(){
}

public
SchLog createSchLog(){
	return new SchLog();
}

public
bool existsSchLog(string db, string jobcardID, string company, string plant){
	try{
		SchLogDataBase schLogDataBase = new SchLogDataBase(dataBaseAccess);

		schLogDataBase.setSL_Db(db);
		schLogDataBase.setSL_JobcardID(jobcardID);
		schLogDataBase.setSL_Company(company);
		schLogDataBase.setSL_Plant(plant);

		return schLogDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
SchLog readSchLog(string db, string jobcardID, string company, string plant){
	try{
		SchLogDataBase schLogDataBase = new SchLogDataBase(dataBaseAccess);
		schLogDataBase.setSL_Db(db);
		schLogDataBase.setSL_JobcardID(jobcardID);
		schLogDataBase.setSL_Company(company);
		schLogDataBase.setSL_Plant(plant);

		if (!schLogDataBase.exists())
			return null;

		schLogDataBase.read();

		SchLog schLog = this.objectDataBaseToObject(schLogDataBase);

		return schLog;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
string[] readSchLogForReport(string db, string jobcardID, string company, string plant){
	try{
		SchLogDataBase schLogDataBase = new SchLogDataBase(dataBaseAccess);
		schLogDataBase.setSL_Db(db);
		schLogDataBase.setSL_JobcardID(jobcardID);
		schLogDataBase.setSL_Company(company);
		schLogDataBase.setSL_Plant(plant);

		if (!schLogDataBase.exists())
			return null;

		schLogDataBase.read();
		
		string[] vec = new string[10];
		vec[0] = schLogDataBase.getSL_Part();
		vec[1] = schLogDataBase.getSL_Description();
		vec[2] = schLogDataBase.getSL_Operation();
		vec[3] = schLogDataBase.getSL_NextOperation();
		vec[4] = schLogDataBase.getSL_RunQty().ToString("##,##0.00");
		vec[5] = schLogDataBase.getSL_MainMaterial();
		vec[6] = schLogDataBase.getSL_MaterialReq().ToString("##,##0.00");
		vec[7] = schLogDataBase.getSL_DateReq().ToShortDateString();
		vec[8] = schLogDataBase.getSL_Machine();	
		vec[9] = (getProductsByProdId(schLogDataBase.getSL_MainMaterial()))[0][1];

		return vec;
		
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
string[][] getSchLogByDesc(string searchText, int rows){
	try{
		SchLogDataBaseContainer schLogDataBaseContainer = new SchLogDataBaseContainer(dataBaseAccess);
		schLogDataBaseContainer.readByDesc(searchText, rows);
		string[][] items = new string[schLogDataBaseContainer.Count][];
		int i = 0;
		for(IEnumerator en = schLogDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			SchLogDataBase schLogDataBase = (SchLogDataBase) en.Current;
			string[] item = new String[30];
			item[0] = schLogDataBase.getSL_ID().ToString();
			item[1] = schLogDataBase.getSL_Db();
			item[2] = schLogDataBase.getSL_JobcardID();
			item[3] = schLogDataBase.getSL_Company();
			item[4] = schLogDataBase.getSL_Plant();
			item[5] = schLogDataBase.getSL_Department();
			item[6] = schLogDataBase.getSL_Machine();
			item[7] = schLogDataBase.getSL_Part();
			item[8] = schLogDataBase.getSL_Description();
			item[9] = schLogDataBase.getSL_Part2();
			item[10] = schLogDataBase.getSL_Description2();
			item[11] = schLogDataBase.getSL_Part3();
			item[12] = schLogDataBase.getSL_Description3();
			item[13] = schLogDataBase.getSL_Part4();
			item[14] = schLogDataBase.getSL_Description4();
			item[15] = schLogDataBase.getSL_Family();
			item[16] = schLogDataBase.getSL_FamilyDescription();
			item[17] = schLogDataBase.getSL_RunQty().ToString();
			item[18] = schLogDataBase.getSL_UOM();
			item[19] = schLogDataBase.getSL_RunStandard().ToString();
			item[20] = schLogDataBase.getSL_MachineHrs().ToString();
			item[21] = schLogDataBase.getSL_MainTool();
			item[22] = schLogDataBase.getSL_QtyPerTool().ToString();
			item[23] = schLogDataBase.getSL_MainMaterial();
			item[24] = schLogDataBase.getSL_QtyPer().ToString();
			item[25] = schLogDataBase.getSL_MaterialReq().ToString();
			if (schLogDataBase.getSL_Status().Equals(Constants.STATUS_ACTIVE))
				item[26] = "Active";
			else
				item[26] = "Inactive";
			item[27] = schLogDataBase.getSL_DateReq().ToShortDateString();
			item[28] = schLogDataBase.getSL_Operation();
			item[29] = schLogDataBase.getSL_NextOperation();
			
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
void updateSchLog(SchLog schLog){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		SchLogDataBase schLogDataBase = this.objectToObjectDataBase(schLog);
		schLogDataBase.update();

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
void writeSchLog(SchLog schLog){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		SchLogDataBase schLogDataBase = this.objectToObjectDataBase(schLog);
		schLogDataBase.write();

		schLog.setID(schLogDataBase.getSL_ID());

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
void deleteSchLog(string db, string jobcardID, string company, string plant){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		SchLogDataBase schLogDataBase = new SchLogDataBase(dataBaseAccess);

		schLogDataBase.setSL_Db(db);
		schLogDataBase.setSL_JobcardID(jobcardID);
		schLogDataBase.setSL_Company(company);
		schLogDataBase.setSL_Plant(plant);
		schLogDataBase.delete();

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
SchLog objectDataBaseToObject(SchLogDataBase schLogDataBase){
	SchLog schLog = new SchLog();

	schLog.setID(schLogDataBase.getSL_ID());
	schLog.setDb(schLogDataBase.getSL_Db());
	schLog.setJobcardID(schLogDataBase.getSL_JobcardID());
	schLog.setCompany(schLogDataBase.getSL_Company());
	schLog.setPlant(schLogDataBase.getSL_Plant());
	schLog.setDepartment(schLogDataBase.getSL_Department());
	schLog.setMachine(schLogDataBase.getSL_Machine());
	schLog.setPart(schLogDataBase.getSL_Part());
	schLog.setDescription(schLogDataBase.getSL_Description());
	schLog.setPart2(schLogDataBase.getSL_Part2());
	schLog.setDescription2(schLogDataBase.getSL_Description2());
	schLog.setPart3(schLogDataBase.getSL_Part3());
	schLog.setDescription3(schLogDataBase.getSL_Description3());
	schLog.setPart4(schLogDataBase.getSL_Part4());
	schLog.setDescription4(schLogDataBase.getSL_Description4());
	schLog.setFamily(schLogDataBase.getSL_Family());
	schLog.setFamilyDescription(schLogDataBase.getSL_FamilyDescription());
	schLog.setRunQty(schLogDataBase.getSL_RunQty());
	schLog.setUOM(schLogDataBase.getSL_UOM());
	schLog.setRunStandard(schLogDataBase.getSL_RunStandard());
	schLog.setMachineHrs(schLogDataBase.getSL_MachineHrs());
	schLog.setMainTool(schLogDataBase.getSL_MainTool());
	schLog.setQtyPerTool(schLogDataBase.getSL_QtyPerTool());
	schLog.setMainMaterial(schLogDataBase.getSL_MainMaterial());
	schLog.setQtyPer(schLogDataBase.getSL_QtyPer());
	schLog.setMaterialReq(schLogDataBase.getSL_MaterialReq());
	schLog.setStatus(schLogDataBase.getSL_Status());
	schLog.setDateReq(schLogDataBase.getSL_DateReq());
	schLog.setOperation(schLogDataBase.getSL_Operation());
	schLog.setNextOperation(schLogDataBase.getSL_NextOperation());

	return schLog;
}

private
SchLogDataBase objectToObjectDataBase(SchLog schLog){
	SchLogDataBase schLogDataBase = new SchLogDataBase(dataBaseAccess);
	schLogDataBase.setSL_ID(schLog.getID());
	schLogDataBase.setSL_Db(schLog.getDb());
	schLogDataBase.setSL_JobcardID(schLog.getJobcardID());
	schLogDataBase.setSL_Company(schLog.getCompany());
	schLogDataBase.setSL_Plant(schLog.getPlant());
	schLogDataBase.setSL_Department(schLog.getDepartment());
	schLogDataBase.setSL_Machine(schLog.getMachine());
	schLogDataBase.setSL_Part(schLog.getPart());
	schLogDataBase.setSL_Description(schLog.getDescription());
	schLogDataBase.setSL_Part2(schLog.getPart2());
	schLogDataBase.setSL_Description2(schLog.getDescription2());
	schLogDataBase.setSL_Part3(schLog.getPart3());
	schLogDataBase.setSL_Description3(schLog.getDescription3());
	schLogDataBase.setSL_Part4(schLog.getPart4());
	schLogDataBase.setSL_Description4(schLog.getDescription4());
	schLogDataBase.setSL_Family(schLog.getFamily());
	schLogDataBase.setSL_FamilyDescription(schLog.getFamilyDescription());
	schLogDataBase.setSL_RunQty(schLog.getRunQty());
	schLogDataBase.setSL_UOM(schLog.getUOM());
	schLogDataBase.setSL_RunStandard(schLog.getRunStandard());
	schLogDataBase.setSL_MachineHrs(schLog.getMachineHrs());
	schLogDataBase.setSL_MainTool(schLog.getMainTool());
	schLogDataBase.setSL_QtyPerTool(schLog.getQtyPerTool());
	schLogDataBase.setSL_MainMaterial(schLog.getMainMaterial());
	schLogDataBase.setSL_QtyPer(schLog.getQtyPer());
	schLogDataBase.setSL_MaterialReq(schLog.getMaterialReq());
	schLogDataBase.setSL_Status(schLog.getStatus());
	schLogDataBase.setSL_DateReq(schLog.getDateReq());
	schLogDataBase.setSL_Operation(schLog.getOperation());
	schLogDataBase.setSL_NextOperation(schLog.getNextOperation());

	return schLogDataBase;
}

public
SchLog cloneSchLog(SchLog schLog){
	SchLog schLogClone = new SchLog();

	schLogClone.setID(schLog.getID());
	schLogClone.setDb(schLog.getDb());
	schLogClone.setJobcardID(schLog.getJobcardID());
	schLogClone.setCompany(schLog.getCompany());
	schLogClone.setPlant(schLog.getPlant());
	schLogClone.setDepartment(schLog.getDepartment());
	schLogClone.setMachine(schLog.getMachine());
	schLogClone.setPart(schLog.getPart());
	schLogClone.setDescription(schLog.getDescription());
	schLogClone.setPart2(schLog.getPart2());
	schLogClone.setDescription2(schLog.getDescription2());
	schLogClone.setPart3(schLog.getPart3());
	schLogClone.setDescription3(schLog.getDescription3());
	schLogClone.setPart4(schLog.getPart4());
	schLogClone.setDescription4(schLog.getDescription4());
	schLogClone.setFamily(schLog.getFamily());
	schLogClone.setFamilyDescription(schLog.getFamilyDescription());
	schLogClone.setRunQty(schLog.getRunQty());
	schLogClone.setUOM(schLog.getUOM());
	schLogClone.setRunStandard(schLog.getRunStandard());
	schLogClone.setMachineHrs(schLog.getMachineHrs());
	schLogClone.setMainTool(schLog.getMainTool());
	schLogClone.setQtyPerTool(schLog.getQtyPerTool());
	schLogClone.setMainMaterial(schLog.getMainMaterial());
	schLogClone.setQtyPer(schLog.getQtyPer());
	schLogClone.setMaterialReq(schLog.getMaterialReq());
	schLogClone.setStatus(schLog.getStatus());
	schLogClone.setDateReq(schLog.getDateReq());
	schLogClone.setOperation(schLog.getOperation());
	schLogClone.setNextOperation(schLog.getNextOperation());

	return schLogClone;
}

public
string[][] getPdToolByDesc(string searchText, int rows){
	try{
		PdToolDataBaseContainer pdToolDataBaseContainer = new PdToolDataBaseContainer(dataBaseAccess);
		pdToolDataBaseContainer.readByDesc(searchText, rows);
		string[][] items = new string[pdToolDataBaseContainer.Count][];
		int i = 0;
		for(IEnumerator en = pdToolDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			PdToolDataBase pdToolDataBase = (PdToolDataBase) en.Current;
			string[] item = new String[14];
			item[0] = pdToolDataBase.getTOO_ID().ToString();
			item[1] = pdToolDataBase.getTOO_Db();
			item[2] = pdToolDataBase.getTOO_Company();
			item[3] = pdToolDataBase.getTOO_Plant();
			item[4] = pdToolDataBase.getTOO_ToolNumber();
			item[5] = pdToolDataBase.getTOO_Desc1();
			item[6] = pdToolDataBase.getTOO_Desc2();
			item[7] = pdToolDataBase.getTOO_Desc3();
			item[8] = pdToolDataBase.getTOO_MaintenanceClass();
			item[9] = pdToolDataBase.getTOO_AssetID().ToString();
			item[10] = pdToolDataBase.getTOO_ToolStatus();
			item[11] = pdToolDataBase.getTOO_ScheduleStatus();
			item[12] = pdToolDataBase.getTOO_ProductionUom();
			item[13] = pdToolDataBase.getTOO_CurrentWorkOrder();
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
string[][] getPdToolByPart(string part1, string part2, string part3, string part4){
	try{
		PdToolDataBaseContainer pdToolDataBaseContainer = new PdToolDataBaseContainer(dataBaseAccess);
		pdToolDataBaseContainer.readByPart(part1, part2, part3, part4);
		string[][] items = new string[pdToolDataBaseContainer.Count][];
		int i = 0;
		for(IEnumerator en = pdToolDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			PdToolDataBase pdToolDataBase = (PdToolDataBase) en.Current;
			string[] item = new String[2];
			item[0] = pdToolDataBase.getTOO_ToolNumber();
			item[1] = pdToolDataBase.getTOO_Desc1();

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
string getToolDescription(string db, string company, string plant, string tool){
	try{
		PdToolDataBase pdToolDataBase = new PdToolDataBase(dataBaseAccess);
		pdToolDataBase.setTOO_Db(db);
		pdToolDataBase.setTOO_Company(company);
		pdToolDataBase.setTOO_Plant(plant);
		pdToolDataBase.setTOO_ToolNumber(tool);
		pdToolDataBase.read();
		
		return pdToolDataBase.getTOO_Desc1();
		
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}


} // class
} // package