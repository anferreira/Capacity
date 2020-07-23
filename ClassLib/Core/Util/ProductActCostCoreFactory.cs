using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.ErpException;

namespace Nujit.NujitERP.ClassLib.Core.Util{


public 
class ProductActCostCoreFactory : ProccessCoreFactory{

public
ProductActCostCoreFactory() : base(){
}

/// <summary>
/// return all ProdPrizes codes 
/// </summary>
/// <returns></returns>

#if OE_SYNC
public
ArrayList readToSynchronizeProdFmActCost(LastRevision lastRevision,int iquantity)
{
		ArrayList	arrayList = new ArrayList();
		ProdFmActCostDataBaseContainer prodFmActCostDataBaseContainer = new ProdFmActCostDataBaseContainer(dataBaseAccess);
	
		prodFmActCostDataBaseContainer.readToSynchronize(lastRevision,iquantity);
		
		IEnumerator iEnum = prodFmActCostDataBaseContainer.GetEnumerator();
		while (iEnum.MoveNext()){
			ProdFmActCostDataBase prodFmActCostDataBase = (ProdFmActCostDataBase)iEnum.Current;	

			ProductActCost productActCost = new ProductActCost(prodFmActCostDataBase.getPAC_ProdID(),
											prodFmActCostDataBase.getPAC_ActID(),
											prodFmActCostDataBase.getPAC_Seq(),
											prodFmActCostDataBase.getPAC_PartType(),
											prodFmActCostDataBase.getPAC_Cost(),
											prodFmActCostDataBase.getPAC_DateUpdated());
			
			arrayList.Add(productActCost);
		}

		return arrayList;
}
#endif

public
ProductActCost readProductActCost(string sproduct, int iseq)
{
	try
	{
		ProdFmActCostDataBase prodFmActCostDataBase = new ProdFmActCostDataBase(dataBaseAccess);

		prodFmActCostDataBase.setPAC_ProdID(sproduct);		
		prodFmActCostDataBase.setPAC_Seq(iseq);	
		
		if (!prodFmActCostDataBase.exists())
			return null;

		prodFmActCostDataBase.read();


		ProductActCost productActCost = new ProductActCost(prodFmActCostDataBase.getPAC_ProdID(),
												prodFmActCostDataBase.getPAC_ActID(),
												prodFmActCostDataBase.getPAC_Seq(),
												prodFmActCostDataBase.getPAC_PartType(),
												prodFmActCostDataBase.getPAC_Cost(),
												prodFmActCostDataBase.getPAC_DateUpdated());
		return productActCost;

	}catch(PersistenceException pe){
		throw new NujitException(pe.Message,pe);
	}catch (System.Exception exc){
		throw new NujitException(exc.Message,exc);
	}	
}

/// <summary>
/// Return if exists a ProdFmActCost
/// </summary>
/// <param name="ProdFmActCost"></param>
/// <param name="familyCode"></param>
/// <returns></returns>
public
bool existsProdFmActCost(string sproduct, int iseq){
	try
	{
		ProdFmActCostDataBase prodFmActCostDataBase = new ProdFmActCostDataBase(dataBaseAccess);

		prodFmActCostDataBase.setPAC_ProdID(sproduct);		
		prodFmActCostDataBase.setPAC_Seq(iseq);	
			
		return prodFmActCostDataBase.exists();

	}catch(PersistenceException pe){
		throw new NujitException(pe.Message,pe);
	}catch (System.Exception exc){
		throw new NujitException(exc.Message,exc);
	}	
}

/// <summary>
/// Write to the database a ProdFmActCost object
/// </summary>
/// <param name="proccess"></param>
public
void writeProdFmActCost(ProductActCost productActCost){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdFmActCostDataBase prodFmActCostDataBase = new ProdFmActCostDataBase(dataBaseAccess);		

		prodFmActCostDataBase.setPAC_ProdID(productActCost.getProdId());
		prodFmActCostDataBase.setPAC_ActID(productActCost.getActId());
		prodFmActCostDataBase.setPAC_Seq(productActCost.getSeq());
		prodFmActCostDataBase.setPAC_PartType(productActCost.getPartType());
		prodFmActCostDataBase.setPAC_Cost(productActCost.getCost());
		prodFmActCostDataBase.setPAC_DateUpdated(productActCost.getDateUpdated());
						
		prodFmActCostDataBase.write();
				
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Update a ProdFmActCost object
/// </summary>
/// <param name="proccess"></param>
public
void updateProdFmActCost(ProductActCost productActCost){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdFmActCostDataBase prodFmActCostDataBase = new ProdFmActCostDataBase(dataBaseAccess);		

		prodFmActCostDataBase.setPAC_ProdID(productActCost.getProdId());
		prodFmActCostDataBase.setPAC_ActID(productActCost.getActId());
		prodFmActCostDataBase.setPAC_Seq(productActCost.getSeq());
		prodFmActCostDataBase.setPAC_PartType(productActCost.getPartType());
		prodFmActCostDataBase.setPAC_Cost(productActCost.getCost());
		prodFmActCostDataBase.setPAC_DateUpdated(productActCost.getDateUpdated());

		prodFmActCostDataBase.update();
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Delete a ProdFmActCost object
/// </summary>
/// <param name="proccess"></param>
public
void deleteProdFmActCost(ProductActCost productActCost){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdFmActCostDataBase prodFmActCostDataBase = new ProdFmActCostDataBase(dataBaseAccess);
	
		prodFmActCostDataBase.setPAC_ProdID(productActCost.getProdId());
		prodFmActCostDataBase.setPAC_Seq(productActCost.getSeq());		
				
		prodFmActCostDataBase.delete();
			
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

} // class

} // namespace