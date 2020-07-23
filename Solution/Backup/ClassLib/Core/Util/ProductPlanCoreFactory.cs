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
class ProductPlanCoreFactory : ProductCoreFactory{

protected
ProductPlanCoreFactory() : base(){
}

/// <summary>
/// Return if exists a ProductPlan
/// </summary>
/// <returns></returns>
public
bool existsProductPlan(string	prodID, int seq){
	try{
		ProdFmActPlanDataBase prodFmActPlanDataBase = new ProdFmActPlanDataBase(dataBaseAccess);

		prodFmActPlanDataBase.setPAPL_ProdID(prodID);		
		prodFmActPlanDataBase.setPAPL_ActID("");
		prodFmActPlanDataBase.setPAPL_Seq(seq);
		
		return prodFmActPlanDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
ProductPlan createProductPlan(){
	return new ProductPlan();
}

/// <summary>
/// Reads a productPlan object
/// </summary>
/// <returns></returns>
public
ProductPlan readProductPlan(string	prodID, int seq){
    try{
		ProdFmActPlanDataBase prodFmActPlanDataBase = new ProdFmActPlanDataBase(dataBaseAccess);

		prodFmActPlanDataBase.setPAPL_ProdID(prodID);		
		prodFmActPlanDataBase.setPAPL_ActID("");
		prodFmActPlanDataBase.setPAPL_Seq(seq);

		prodFmActPlanDataBase.read();
							
		ProductPlan productPlan = new ProductPlan(prodFmActPlanDataBase.getPAPL_ProdID(),
				prodFmActPlanDataBase.getPAPL_ActID(), prodFmActPlanDataBase.getPAPL_Seq(),
				prodFmActPlanDataBase.getPAPL_StdPack(), prodFmActPlanDataBase.getPAPL_PackType(),
				prodFmActPlanDataBase.getPAPL_SkidQty(), prodFmActPlanDataBase.getPAPL_SkidType(),
				prodFmActPlanDataBase.getPAPL_MinInv(), prodFmActPlanDataBase.getPAPL_MaxInv(),
				prodFmActPlanDataBase.getPAPL_InvUom(), prodFmActPlanDataBase.getPAPL_MinCon(),
				prodFmActPlanDataBase.getPAPL_MaxCon(), prodFmActPlanDataBase.getPAPL_DohMin(),
				prodFmActPlanDataBase.getPAPL_DohMax(), prodFmActPlanDataBase.getPAPL_PackWip(),
				prodFmActPlanDataBase.getPAPL_ContWip(), prodFmActPlanDataBase.getPAPL_TarRunQty(),
				prodFmActPlanDataBase.getPAPL_Colour(), prodFmActPlanDataBase.getPAPL_DayLT(),
				prodFmActPlanDataBase.getPAPL_HourLT(), prodFmActPlanDataBase.getPAPL_DayLTCum(),
				prodFmActPlanDataBase.getPAPL_HourLTCum(),

				prodFmActPlanDataBase.getPAPL_ProcessLoc(), prodFmActPlanDataBase.getPAPL_NumofMachines(), 
				prodFmActPlanDataBase.getPAPL_ScheduleType(), prodFmActPlanDataBase.getPAPL_ScheduleOrder(), 
				prodFmActPlanDataBase.getPAPL_LaborDep(), prodFmActPlanDataBase.getPAPL_MachineDep(), 
				prodFmActPlanDataBase.getPAPL_ToolDep(), prodFmActPlanDataBase.getPAPL_QtyOption(), 
				prodFmActPlanDataBase.getPAPL_DaysInAdvance(), prodFmActPlanDataBase.getPAPL_PartsonSpecShift(), 
				prodFmActPlanDataBase.getPAPL_LongSetup(), prodFmActPlanDataBase.getPAPL_ShortSetup(), 
				prodFmActPlanDataBase.getPAPL_BatchOperation(), prodFmActPlanDataBase.getPAPL_BatchSize(), 
				prodFmActPlanDataBase.getPAPL_NextOpQtyTransfer(), prodFmActPlanDataBase.getPAPL_SeqSched(), 
				prodFmActPlanDataBase.getPAPL_MainMaterial(), prodFmActPlanDataBase.getPAPL_MainMatSeq(), 
				prodFmActPlanDataBase.getPAPL_MainMatQty(), prodFmActPlanDataBase.getPAPL_MainToolType(), 
				prodFmActPlanDataBase.getPAPL_NumofTools(), prodFmActPlanDataBase.getPAPL_SchGroup1(), 
				prodFmActPlanDataBase.getPAPL_SchGroup2(), prodFmActPlanDataBase.getPAPL_SchGroup3(), 
				prodFmActPlanDataBase.getPAPL_SchGroup4(), prodFmActPlanDataBase.getPAPL_SchGroup5(), 
				prodFmActPlanDataBase.getPAPL_SchGroup6(), prodFmActPlanDataBase.getPAPL_Forecast(), 
				prodFmActPlanDataBase.getPAPL_ForeTimeFence(), prodFmActPlanDataBase.getPAPL_ReportingPoint(),
				prodFmActPlanDataBase.getPAPL_ExcludeAlloc(), prodFmActPlanDataBase.getPAPL_CapacityRestrict(),
				prodFmActPlanDataBase.getPAPL_TransferToNext(), prodFmActPlanDataBase.getPAPL_ExcludeSats(),
				prodFmActPlanDataBase.getPAPL_ExcludeSuns()
			);

		return productPlan;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Update a productPlan object
/// </summary>
/// <param name="machine"></param>
public
void updateProductPlan(ProductPlan productPlan){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdFmActPlanDataBase prodFmActPlanDataBase = new ProdFmActPlanDataBase(dataBaseAccess);
		prodFmActPlanDataBase.setPAPL_ProdID(productPlan.getProdID());
		prodFmActPlanDataBase.setPAPL_ActID(productPlan.getActID());
		prodFmActPlanDataBase.setPAPL_Seq(productPlan.getSeq());
		prodFmActPlanDataBase.setPAPL_StdPack(productPlan.getStdPack());
		prodFmActPlanDataBase.setPAPL_PackType(productPlan.getPackType());
		prodFmActPlanDataBase.setPAPL_SkidQty(productPlan.getSkidQty());
		prodFmActPlanDataBase.setPAPL_SkidType(productPlan.getSkidType());
		prodFmActPlanDataBase.setPAPL_MinInv(productPlan.getMinInv());
		prodFmActPlanDataBase.setPAPL_MaxInv(productPlan.getMaxInv());
		prodFmActPlanDataBase.setPAPL_InvUom(productPlan.getInvUom());
		prodFmActPlanDataBase.setPAPL_MinCon(productPlan.getMinCon());
		prodFmActPlanDataBase.setPAPL_MaxCon(productPlan.getMaxCon());
		prodFmActPlanDataBase.setPAPL_DohMin(productPlan.getDohMin());
		prodFmActPlanDataBase.setPAPL_DohMax(productPlan.getDohMax());
		prodFmActPlanDataBase.setPAPL_PackWip(productPlan.getPackWip());
		prodFmActPlanDataBase.setPAPL_ContWip(productPlan.getContWip());
		prodFmActPlanDataBase.setPAPL_TarRunQty(productPlan.getTarRunQty());
		prodFmActPlanDataBase.setPAPL_Colour(productPlan.getColour());
		prodFmActPlanDataBase.setPAPL_DayLT(productPlan.getDayLT());
		prodFmActPlanDataBase.setPAPL_HourLT(productPlan.getHourLT());
		prodFmActPlanDataBase.setPAPL_DayLTCum(productPlan.getDayLTCum());
		prodFmActPlanDataBase.setPAPL_HourLTCum(productPlan.getHourLTCum());

		prodFmActPlanDataBase.setPAPL_ProcessLoc(productPlan.getProcessLoc());
		prodFmActPlanDataBase.setPAPL_NumofMachines(productPlan.getNumofMachines());
		prodFmActPlanDataBase.setPAPL_ScheduleType(productPlan.getScheduleType());
		prodFmActPlanDataBase.setPAPL_ScheduleOrder(productPlan.getScheduleOrder());
		prodFmActPlanDataBase.setPAPL_LaborDep(productPlan.getLaborDep());
		prodFmActPlanDataBase.setPAPL_MachineDep(productPlan.getMachineDep());
		prodFmActPlanDataBase.setPAPL_ToolDep(productPlan.getToolDep());
		prodFmActPlanDataBase.setPAPL_QtyOption(productPlan.getQtyOption());
		prodFmActPlanDataBase.setPAPL_DaysInAdvance(productPlan.getDaysInAdvance());
		prodFmActPlanDataBase.setPAPL_PartsonSpecShift(productPlan.getPartsonSpecShift());
		prodFmActPlanDataBase.setPAPL_LongSetup(productPlan.getLongSetup());
		prodFmActPlanDataBase.setPAPL_ShortSetup(productPlan.getShortSetup());
		prodFmActPlanDataBase.setPAPL_BatchOperation(productPlan.getBatchOperation());
		prodFmActPlanDataBase.setPAPL_BatchSize(productPlan.getBatchSize());
		prodFmActPlanDataBase.setPAPL_NextOpQtyTransfer(productPlan.getNextOpQtyTransfer());
		prodFmActPlanDataBase.setPAPL_SeqSched(productPlan.getSeqSched());
		prodFmActPlanDataBase.setPAPL_MainMaterial(productPlan.getMainMaterial());
		prodFmActPlanDataBase.setPAPL_MainMatSeq(productPlan.getMainMatSeq());
		prodFmActPlanDataBase.setPAPL_MainMatQty(productPlan.getMainMatQty());
		prodFmActPlanDataBase.setPAPL_MainToolType(productPlan.getMainToolType());
		prodFmActPlanDataBase.setPAPL_NumofTools(productPlan.getNumofTools());
		prodFmActPlanDataBase.setPAPL_SchGroup1(productPlan.getSchGroup1());
		prodFmActPlanDataBase.setPAPL_SchGroup2(productPlan.getSchGroup2());
		prodFmActPlanDataBase.setPAPL_SchGroup3(productPlan.getSchGroup3());
		prodFmActPlanDataBase.setPAPL_SchGroup4(productPlan.getSchGroup4());
		prodFmActPlanDataBase.setPAPL_SchGroup5(productPlan.getSchGroup5());
		prodFmActPlanDataBase.setPAPL_SchGroup6(productPlan.getSchGroup6());
		prodFmActPlanDataBase.setPAPL_Forecast(productPlan.getForecast());
		prodFmActPlanDataBase.setPAPL_ForeTimeFence(productPlan.getForeTimeFence());
		prodFmActPlanDataBase.setPAPL_ReportingPoint(productPlan.getReportingPoint());
		prodFmActPlanDataBase.setPAPL_ExcludeAlloc(productPlan.getExcludeAlloc());
		prodFmActPlanDataBase.setPAPL_CapacityRestrict(productPlan.getCapacityRestrict());
		prodFmActPlanDataBase.setPAPL_TransferToNext(productPlan.getTransferToNext());
		prodFmActPlanDataBase.setPAPL_ExcludeSats(productPlan.getExcludeSats());
		prodFmActPlanDataBase.setPAPL_ExcludeSuns(productPlan.getExcludeSuns());

		prodFmActPlanDataBase.update();

		ProdFmActPlanDataBaseContainer prodFmActPlanDataBaseContainer = new ProdFmActPlanDataBaseContainer(dataBaseAccess);
		prodFmActPlanDataBaseContainer.readByProductSeqInverse(productPlan.getProdID());
		
		decimal cumulative = 0;
		for(int i = 0; i < prodFmActPlanDataBaseContainer.Count; i++){
			ProdFmActPlanDataBase prodFmActPlanDataBase2 = (ProdFmActPlanDataBase)prodFmActPlanDataBaseContainer[i];
			
			cumulative += prodFmActPlanDataBase2.getPAPL_DayLT();
			prodFmActPlanDataBase2.setPAPL_DayLTCum(cumulative);
		}
		
		prodFmActPlanDataBaseContainer.update();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException pe){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Write a productPlan object
/// </summary>
/// <param name="machine"></param>
public
void writeProductPlan(ProductPlan productPlan){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdFmActPlanDataBase prodFmActPlanDataBase = new ProdFmActPlanDataBase(dataBaseAccess);
		
		prodFmActPlanDataBase.setPAPL_ProdID(productPlan.getProdID());
		prodFmActPlanDataBase.setPAPL_ActID(productPlan.getActID());
		prodFmActPlanDataBase.setPAPL_Seq(productPlan.getSeq());
		prodFmActPlanDataBase.setPAPL_StdPack(productPlan.getStdPack());
		prodFmActPlanDataBase.setPAPL_PackType(productPlan.getPackType());
		prodFmActPlanDataBase.setPAPL_SkidQty(productPlan.getSkidQty());
		prodFmActPlanDataBase.setPAPL_SkidType(productPlan.getSkidType());
		prodFmActPlanDataBase.setPAPL_MinInv(productPlan.getMinInv());
		prodFmActPlanDataBase.setPAPL_MaxInv(productPlan.getMaxInv());
		prodFmActPlanDataBase.setPAPL_InvUom(productPlan.getInvUom());
		prodFmActPlanDataBase.setPAPL_MinCon(productPlan.getMinCon());
		prodFmActPlanDataBase.setPAPL_MaxCon(productPlan.getMaxCon());
		prodFmActPlanDataBase.setPAPL_DohMin(productPlan.getDohMin());
		prodFmActPlanDataBase.setPAPL_DohMax(productPlan.getDohMax());
		prodFmActPlanDataBase.setPAPL_PackWip(productPlan.getPackWip());
		prodFmActPlanDataBase.setPAPL_ContWip(productPlan.getContWip());
		prodFmActPlanDataBase.setPAPL_TarRunQty(productPlan.getTarRunQty());
		prodFmActPlanDataBase.setPAPL_Colour(productPlan.getColour());
		prodFmActPlanDataBase.setPAPL_DayLT(productPlan.getDayLT());
		prodFmActPlanDataBase.setPAPL_HourLT(productPlan.getHourLT());
		prodFmActPlanDataBase.setPAPL_DayLTCum(productPlan.getDayLTCum());
		prodFmActPlanDataBase.setPAPL_HourLTCum(productPlan.getHourLTCum());

		prodFmActPlanDataBase.setPAPL_ProcessLoc(productPlan.getProcessLoc());
		prodFmActPlanDataBase.setPAPL_NumofMachines(productPlan.getNumofMachines());
		prodFmActPlanDataBase.setPAPL_ScheduleType(productPlan.getScheduleType());
		prodFmActPlanDataBase.setPAPL_ScheduleOrder(productPlan.getScheduleOrder());
		prodFmActPlanDataBase.setPAPL_LaborDep(productPlan.getLaborDep());
		prodFmActPlanDataBase.setPAPL_MachineDep(productPlan.getMachineDep());
		prodFmActPlanDataBase.setPAPL_ToolDep(productPlan.getToolDep());
		prodFmActPlanDataBase.setPAPL_QtyOption(productPlan.getQtyOption());
		prodFmActPlanDataBase.setPAPL_DaysInAdvance(productPlan.getDaysInAdvance());
		prodFmActPlanDataBase.setPAPL_PartsonSpecShift(productPlan.getPartsonSpecShift());
		prodFmActPlanDataBase.setPAPL_LongSetup(productPlan.getLongSetup());
		prodFmActPlanDataBase.setPAPL_ShortSetup(productPlan.getShortSetup());
		prodFmActPlanDataBase.setPAPL_BatchOperation(productPlan.getBatchOperation());
		prodFmActPlanDataBase.setPAPL_BatchSize(productPlan.getBatchSize());
		prodFmActPlanDataBase.setPAPL_NextOpQtyTransfer(productPlan.getNextOpQtyTransfer());
		prodFmActPlanDataBase.setPAPL_SeqSched(productPlan.getSeqSched());
		prodFmActPlanDataBase.setPAPL_MainMaterial(productPlan.getMainMaterial());
		prodFmActPlanDataBase.setPAPL_MainMatSeq(productPlan.getMainMatSeq());
		prodFmActPlanDataBase.setPAPL_MainMatQty(productPlan.getMainMatQty());
		prodFmActPlanDataBase.setPAPL_MainToolType(productPlan.getMainToolType());
		prodFmActPlanDataBase.setPAPL_NumofTools(productPlan.getNumofTools());
		prodFmActPlanDataBase.setPAPL_SchGroup1(productPlan.getSchGroup1());
		prodFmActPlanDataBase.setPAPL_SchGroup2(productPlan.getSchGroup2());
		prodFmActPlanDataBase.setPAPL_SchGroup3(productPlan.getSchGroup3());
		prodFmActPlanDataBase.setPAPL_SchGroup4(productPlan.getSchGroup4());
		prodFmActPlanDataBase.setPAPL_SchGroup5(productPlan.getSchGroup5());
		prodFmActPlanDataBase.setPAPL_SchGroup6(productPlan.getSchGroup6());
		prodFmActPlanDataBase.setPAPL_Forecast(productPlan.getForecast());
		prodFmActPlanDataBase.setPAPL_ForeTimeFence(productPlan.getForeTimeFence());
		
		prodFmActPlanDataBase.setPAPL_ReportingPoint(productPlan.getReportingPoint());
		prodFmActPlanDataBase.setPAPL_ExcludeAlloc(productPlan.getExcludeAlloc());
		prodFmActPlanDataBase.setPAPL_CapacityRestrict(productPlan.getCapacityRestrict());
		prodFmActPlanDataBase.setPAPL_TransferToNext(productPlan.getTransferToNext());

		prodFmActPlanDataBase.setPAPL_ExcludeSats(productPlan.getExcludeSats());
		prodFmActPlanDataBase.setPAPL_ExcludeSuns(productPlan.getExcludeSuns());

		prodFmActPlanDataBase.write();

		ProdFmActPlanDataBaseContainer prodFmActPlanDataBaseContainer = new ProdFmActPlanDataBaseContainer(dataBaseAccess);
		prodFmActPlanDataBaseContainer.readByProductSeqInverse(productPlan.getProdID());
		
		decimal cumulative = 0;
		for(int i = 0; i < prodFmActPlanDataBaseContainer.Count; i++){
			ProdFmActPlanDataBase prodFmActPlanDataBase2 = (ProdFmActPlanDataBase)prodFmActPlanDataBaseContainer[i];
			
			cumulative += prodFmActPlanDataBase2.getPAPL_DayLT();
			prodFmActPlanDataBase2.setPAPL_DayLTCum(cumulative);
		}
		
		prodFmActPlanDataBaseContainer.update();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException pe){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Delete a productPlan object
/// </summary>
/// <param name="machine"></param>
public
void deleteProductPlan(string prodID, int seq){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdFmActPlanDataBase prodFmActPlanDataBase = new ProdFmActPlanDataBase(dataBaseAccess);

		prodFmActPlanDataBase.setPAPL_ProdID(prodID);
		prodFmActPlanDataBase.setPAPL_ActID("");
		prodFmActPlanDataBase.setPAPL_Seq(seq);

		prodFmActPlanDataBase.delete();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException pe){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
void clearLeadTimes(){
    try{
        ProdFmActPlanDataBaseContainer prodFmActPlanDataBaseContainer = new ProdFmActPlanDataBaseContainer(dataBaseAccess);
        prodFmActPlanDataBaseContainer.clearLeadTimes();
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}	
}

public
string[][] getProductPlanAsString(string prod){
	string[][] v = null;
	
	try{
		ProdFmActPlanDataBaseContainer prodFmActPlanDataBaseContainer = new ProdFmActPlanDataBaseContainer(dataBaseAccess);
		prodFmActPlanDataBaseContainer.readByProduct(prod);
		
		v = new string[prodFmActPlanDataBaseContainer.Count][];
		
		for(int i = 0; i < prodFmActPlanDataBaseContainer.Count; i++){
			ProdFmActPlanDataBase prodFmActPlanDataBase = (ProdFmActPlanDataBase)prodFmActPlanDataBaseContainer[i];
			string[] line = new string[5];
			line[0] = prodFmActPlanDataBase.getPAPL_Seq().ToString();
			line[1] = prodFmActPlanDataBase.getPAPL_DayLT().ToString();
			line[2] = prodFmActPlanDataBase.getPAPL_DayLTCum().ToString();
			line[3] = prodFmActPlanDataBase.getPAPL_MinInv().ToString();
			line[4] = prodFmActPlanDataBase.getPAPL_MaxInv().ToString();
			v[i] = line;
		}
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}	
	return v;
}

public
string[][] getFamilyPartsByDesc(string desc){
	string[][] v = null;
	
	try{
		ProdFmActPlanDtDataBaseContainer prodFmActPlanDtDataBaseContainer = new ProdFmActPlanDtDataBaseContainer(dataBaseAccess);
		v = prodFmActPlanDtDataBaseContainer.readByDesc(desc);
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
	
	return v;
}

public
string[][] getProductsByFamilyId(string family){
	string[][] v = null;
	
	try{
		ProdFmActPlanDtDataBaseContainer prodFmActPlanDtDataBaseContainer = new ProdFmActPlanDtDataBaseContainer(dataBaseAccess);
		v = prodFmActPlanDtDataBaseContainer.readPartsByFamilyPart(family);
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
	
	return v;
}

public
decimal[] getSeqQOHs(string part){
	decimal[] v = {0, 0, 0};
	Inventory inventory = readInventory(part);	
	v[0] = inventory.getTotalInventory(20);
	v[1] = inventory.getTotalInventory(10);
	v[2] = inventory.getTotalInventory(30);
	
	return v;
}

public
decimal getRunStdByPart(string part, string seq){
	decimal res = 0;
	
	try{
		ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
		prodFmActSubDataBaseContainer.readByPart(part, seq);
		
		for(int i = 0; i < prodFmActSubDataBaseContainer.Count; i ++){
			ProdFmActSubDataBase prodFmActSubDataBase = (ProdFmActSubDataBase) prodFmActSubDataBaseContainer[i];
			res += prodFmActSubDataBase.getPC_RunStd();
		}
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}	
	
	return res;
}

public
string[][] getAllProductPlansAsString(){
	string[][] v = null;
	
	try{
		ProdFmActPlanDataBaseContainer prodFmActPlanDataBaseContainer = new ProdFmActPlanDataBaseContainer(dataBaseAccess);
		prodFmActPlanDataBaseContainer.read();
		
		v = new string[prodFmActPlanDataBaseContainer.Count][];
		
		for(int i = 0; i < prodFmActPlanDataBaseContainer.Count; i++){
			ProdFmActPlanDataBase prodFmActPlanDataBase = (ProdFmActPlanDataBase)prodFmActPlanDataBaseContainer[i];
			string[] line = new string[8];
			line[0] = prodFmActPlanDataBase.getPAPL_ProdID();
			line[1] = prodFmActPlanDataBase.getPAPL_Seq().ToString();
			line[2] = prodFmActPlanDataBase.getPAPL_DayLT().ToString();
			line[3] = prodFmActPlanDataBase.getPAPL_DayLTCum().ToString();
			line[4] = prodFmActPlanDataBase.getPAPL_MinInv().ToString();
			line[5] = prodFmActPlanDataBase.getPAPL_MaxInv().ToString();
			line[6] = prodFmActPlanDataBase.getPAPL_HourLT().ToString();
			line[7] = prodFmActPlanDataBase.getPAPL_HourLTCum().ToString();
			v[i] = line;
		}
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}	
	return v;
}

} // class

} // namespace
