using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core;
using System.Windows.Forms;
using Nujit.NujitERP.ClassLib.ErpException;

namespace Nujit.NujitERP.ClassLib.Core.Util{


public
class ProdPriceCoreFactory : ProccessCoreFactory{

public
ProdPriceCoreFactory() : base(){
}

/// <summary>
/// return all ProdPrices codes 
/// </summary>
/// <returns></returns>

#if OE_SYNC
public
ArrayList readToSynchronizeProdPrice(LastRevision lastRevision,int iquantity){
		ArrayList	arrayList = new ArrayList();
		ProdPrice	prodPrice=null;
		ProdPriceDataBaseContainer prodPriceInfoDataBaseContainer = new ProdPriceDataBaseContainer(dataBaseAccess);		

		prodPriceInfoDataBaseContainer.readToSynchronize(lastRevision,iquantity);
		
		IEnumerator iEnum = prodPriceInfoDataBaseContainer.GetEnumerator();
		while (iEnum.MoveNext()){
			ProdPriceDataBase prodPriceDataBase = (ProdPriceDataBase)iEnum.Current;	

			prodPrice = objectDataBaseToObject(prodPriceDataBase);			
			
			arrayList.Add(prodPrice);	
		}

		return arrayList;
}
#endif

public
string[][] readProductPriceByCustomer(string sproduct,string scustomer,string scustomersClass,string sdateTime,string sactive, decimal quantity)
{
	try
	{
		string[][] slistPrices;

		//get price by customer
		slistPrices = readProductPrice(sproduct,scustomer,"",sdateTime,sactive,quantity);
		if (slistPrices.Length < 1)
		{
			//get price by class
			slistPrices = readProductPrice(sproduct,"",scustomersClass,sdateTime,sactive,quantity);
		}
		
		if (slistPrices.Length < 1)
		{
			//everyone
			slistPrices = readProductPrice(sproduct,"","",sdateTime,sactive,quantity);
		}
				
		return slistPrices;

	}catch(PersistenceException pe){
		throw new NujitException(pe.Message,pe);
	}catch (System.Exception exc){
		throw new NujitException(exc.Message,exc);
	}	
}

public
string[][] readProductPrice(string sproduct,string scustomer,string scustomersClass,string sdateTime,string sactive,decimal quantity){
	try
	{
		ProdPriceDataBaseContainer prodPriceDataBaseContainer= new ProdPriceDataBaseContainer(dataBaseAccess);	
		prodPriceDataBaseContainer.readProductPrice(sproduct,scustomer,scustomersClass,sdateTime,sactive,quantity);
		
		string[][] items = new String[prodPriceDataBaseContainer.Count][];
		int index = 0;

		IEnumerator iEnum = prodPriceDataBaseContainer.GetEnumerator();
		while (iEnum.MoveNext()){
			ProdPriceDataBase prodPriceDataBase = (ProdPriceDataBase)iEnum.Current;	
		
			string[] item = new String[3];

			item[0] = prodPriceDataBase.getPrc_Price().ToString();
			item[1] = prodPriceDataBase.getPrc_PricingUnit();
			item[2] = prodPriceDataBase.getPrc_Volume().ToString();

			items[index] = item;
			index++;
		}
		return items;

	}catch(PersistenceException pe){
		throw new NujitException(pe.Message,pe);
	}catch (System.Exception exc){
		throw new NujitException(exc.Message,exc);
	}	
}

/// <summary>
/// Return if exists a ProdPrice
/// </summary>
/// <param name="ProdPriceCode"></param>
/// <param name="familyCode"></param>
/// <returns></returns>
public
bool existsProdPrice(string product,string customer,string type,DateTime EffecFrmDatem,DateTime EffecToDate,decimal volume){
	try
	{
		ProdPriceDataBase prodPriceDataBase = new ProdPriceDataBase(dataBaseAccess);

		prodPriceDataBase.setPrc_Product(product);
		prodPriceDataBase.setPrc_CustClassID(customer);
		prodPriceDataBase.setPrc_Type(type);
		prodPriceDataBase.setPrc_EffecFrmDate(EffecFrmDatem);
		prodPriceDataBase.setPrc_EffecToDate(EffecToDate);
		prodPriceDataBase.setPrc_Volume(volume);		
		
		return prodPriceDataBase.exists();

	}catch(PersistenceException pe){
		throw new NujitException(pe.Message,pe);
	}catch (System.Exception exc){
		throw new NujitException(exc.Message,exc);
	}	
}

/// <summary>
/// Read and return a ProdPrice object
/// </summary>
/// <param name="ProdPriceCode"></param>
/// <param name="familyCode"></param>
/// <returns></returns>

/// <summary>
/// Write to the database a ProdPrice object
/// </summary>
/// <param name="proccess"></param>
public
void writeProdPrice(ProdPrice prodPrice){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdPriceDataBase prodPriceDataBase = objectToObjectDatabase(prodPrice);
		
		prodPriceDataBase.write();
				
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}
	catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Update a ProdPrice object
/// </summary>
/// <param name="proccess"></param>
public
void updateProdPrice(ProdPrice prodPrice){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdPriceDataBase prodPriceDataBase = objectToObjectDatabase(prodPrice);
		
		prodPriceDataBase.update();
		
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
/// Delete a ProdPrice object
/// </summary>
/// <param name="proccess"></param>
public
void deleteProdPrice(ProdPrice prodPrice){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdPriceDataBase prodPriceDataBase = new ProdPriceDataBase(dataBaseAccess);

		prodPriceDataBase.setPrc_Product(prodPrice.getProduct());
		prodPriceDataBase.setPrc_CustClassID(prodPrice.getCustClassID());
		prodPriceDataBase.setPrc_EffecFrmDate(prodPrice.getEffecFrmDate());
		prodPriceDataBase.setPrc_EffecToDate(prodPrice.getEffecToDate());

		prodPriceDataBase.delete();
			
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

public
void deleteProdPriceOldies(DateTime dateTime){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdPriceDataBase prodPriceDataBase = new ProdPriceDataBase(dataBaseAccess);
				
		prodPriceDataBase.deleteProdPriceOldies(dateTime);
			
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

private 
ProdPrice objectDataBaseToObject(ProdPriceDataBase prodPriceDataBase)
{
	ProdPrice prodPrice = new ProdPrice();

	prodPrice.setId(prodPriceDataBase.getPrc_ID());
	prodPrice.setCustClassID(prodPriceDataBase.getPrc_CustClassID());
	prodPrice.setProduct(prodPriceDataBase.getPrc_Product());
	prodPrice.setPricingUnit(prodPriceDataBase.getPrc_PricingUnit());
	prodPrice.setCurrency(prodPriceDataBase.getPrc_Currency());
	prodPrice.setPrice(prodPriceDataBase.getPrc_Price());
	prodPrice.setActive(prodPriceDataBase.getPrc_Active());
	prodPrice.setEffecFrmDate(prodPriceDataBase.getPrc_EffecFrmDate());
	prodPrice.setEffecToDate(prodPriceDataBase.getPrc_EffecToDate());
	prodPrice.setLastChgDate(prodPriceDataBase.getPrc_LastChgDate());
	prodPrice.setLastChgUser(prodPriceDataBase.getPrc_LastChgUser());
	prodPrice.setVolume(prodPriceDataBase.getPrc_Volume());
	prodPrice.setDiscode(prodPriceDataBase.getPrc_Discode());
	prodPrice.setType(prodPriceDataBase.getPrc_Type());

	return prodPrice;
}
private 
ProdPriceDataBase objectToObjectDatabase(ProdPrice prodPrice)
{
	ProdPriceDataBase prodPriceDataBase = new ProdPriceDataBase(dataBaseAccess);		

	prodPriceDataBase.setPrc_ID(prodPrice.getId());
	prodPriceDataBase.setPrc_CustClassID(prodPrice.getCustClassID());
	prodPriceDataBase.setPrc_Product(prodPrice.getProduct());
	prodPriceDataBase.setPrc_PricingUnit(prodPrice.getPricingUnit());
	prodPriceDataBase.setPrc_Currency(prodPrice.getCurrency());
	prodPriceDataBase.setPrc_Price(prodPrice.getPrice());
	prodPriceDataBase.setPrc_Active(prodPrice.getActive());
	prodPriceDataBase.setPrc_EffecFrmDate(prodPrice.getEffecFrmDate());
	prodPriceDataBase.setPrc_EffecToDate(prodPrice.getEffecToDate());
	prodPriceDataBase.setPrc_LastChgDate(prodPrice.getLastChgDate());
	prodPriceDataBase.setPrc_LastChgUser(prodPrice.getLastChgUser());
	prodPriceDataBase.setPrc_Volume(prodPrice.getVolume());
	prodPriceDataBase.setPrc_Discode(prodPrice.getDiscode());
	prodPriceDataBase.setPrc_Type(prodPrice.getType());

	return prodPriceDataBase;
}
		

} // class

} // namespace