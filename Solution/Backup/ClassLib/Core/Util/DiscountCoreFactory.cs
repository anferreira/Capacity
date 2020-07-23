using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.ErpException;


namespace Nujit.NujitERP.ClassLib.Core.Util{

public 
class DiscountCoreFactory : DepartamentCoreFactory{

public
DiscountCoreFactory() : base(){
}

public
string[][] getDiscountsByDesc(string sdesc,int itop){
	try
	{
		DiscountsDataBaseContainer discountDataBaseContainer = new DiscountsDataBaseContainer(dataBaseAccess);
		discountDataBaseContainer.readByDesc(sdesc,itop);
				
		string[][] vec = new String[discountDataBaseContainer.Count][];
		//string sdiscount="";
		int index = 0;

		IEnumerator iEnum = discountDataBaseContainer.GetEnumerator();
		while (iEnum.MoveNext()){
			DiscountsDataBase discountDataBase = (DiscountsDataBase)iEnum.Current;		
				
			string[] v = new String[3];
			
			v[0] = discountDataBase.getDF_DiscCode();
			v[1] = discountDataBase.getDF_DiscDesc();

			if (discountDataBase.getDF_DiscRate() != 0)//by %
				v[2] = "% " + NumberUtil.toString(discountDataBase.getDF_DiscRate());
			else//by amount
				v[2] = Constants.MONEY_SYMBOL+ " " + NumberUtil.toString(discountDataBase.getDF_DiscAmount());		

			vec[index] = v;	
			index++;	
		}
		return vec;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}


public ArrayList getDiscountsInGroupDescByDesc(string sgroupId,string sdesc,int itop,string sorderBy){
	try
	{
		ArrayList	arrayList = new ArrayList();
		DiscountsDataBaseContainer discountsDataBaseContainer = new DiscountsDataBaseContainer(dataBaseAccess);

		discountsDataBaseContainer.readByIngGroupDesc(sgroupId,sdesc,itop,sorderBy);
				
		IEnumerator iEnum = discountsDataBaseContainer.GetEnumerator();
		while (iEnum.MoveNext()){
			DiscountsDataBase discountsDataBase = (DiscountsDataBase)iEnum.Current;		

			Discount discount = new Discount();

			discount.setId(discountsDataBase.getDF_ID());
			discount.setDiscCode(discountsDataBase.getDF_DiscCode());
			discount.setDiscDes(discountsDataBase.getDF_DiscDesc());
			discount.setDiscRate(discountsDataBase.getDF_DiscRate());
			discount.setDrCr(discountsDataBase.getDF_DrCr());
			discount.setBaseNet(discountsDataBase.getDF_BaseNet());
			discount.setDiscAmount(discountsDataBase.getDF_DiscAmount());
			discount.setFixedUnit(discountsDataBase.getDF_FixedUnit());
			discount.setSalesCode(discountsDataBase.getDF_SalesCode());
			discount.setDateUpdated(discountsDataBase.getDF_DateUpdated());
			
			arrayList.Add(discount);
		}

		return arrayList;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

#if OE_SYNC
public
ArrayList readToSynchronizeDiscount(LastRevision lastRevision,int iquantity)
{
	ArrayList	arrayList = new ArrayList();
	DiscountsDataBaseContainer discountsDataBaseContainer = new DiscountsDataBaseContainer(dataBaseAccess);

	discountsDataBaseContainer.readToSynchronize(lastRevision,iquantity);
			
	IEnumerator iEnum = discountsDataBaseContainer.GetEnumerator();
	while (iEnum.MoveNext()){
		DiscountsDataBase discountsDataBase = (DiscountsDataBase)iEnum.Current;		

		Discount discount = new Discount();

		discount.setId(discountsDataBase.getDF_ID());
		discount.setDiscCode(discountsDataBase.getDF_DiscCode());
		discount.setDiscDes(discountsDataBase.getDF_DiscDesc());
		discount.setDiscRate(discountsDataBase.getDF_DiscRate());
		discount.setDrCr(discountsDataBase.getDF_DrCr());
		discount.setBaseNet(discountsDataBase.getDF_BaseNet());
		discount.setDiscAmount(discountsDataBase.getDF_DiscAmount());
		discount.setFixedUnit(discountsDataBase.getDF_FixedUnit());
		discount.setSalesCode(discountsDataBase.getDF_SalesCode());
		discount.setDateUpdated(discountsDataBase.getDF_DateUpdated());
		
		arrayList.Add(discount);
	}

	return arrayList;
}
#endif

/// <summary>
/// Return if exists a Discount
/// </summary>
/// <param name="PDM_Plt"></param>
/// <param name="PDM_Dept"></param>
/// <param name="PDM_Mach"></param>
/// <returns></returns>
public
bool existsDiscount(string sdiscount){
	try{
		DiscountsDataBase discountsDataBase = new DiscountsDataBase(dataBaseAccess);

		discountsDataBase.setDF_DiscCode(sdiscount);
		
		return discountsDataBase.exists();

	}catch(PersistenceException pe){
		dataBaseAccess.rollbackTransaction();

		throw new NujitException(pe.Message);
	}
}

/// <summary>
/// Reads a discount object
/// </summary>
/// <param name="PDM_Plt"></param>
/// <param name="PDM_Dept"></param>
/// <param name="PDM_Mach"></param>
/// <returns></returns>
public
Discount readDiscount(string sdiscount){
    try{
		DiscountsDataBase discountsDataBase = new DiscountsDataBase(dataBaseAccess);

		discountsDataBase.setDF_DiscCode(sdiscount);

		if (!existsDiscount(sdiscount))
			return null;

		discountsDataBase.read();
		 
		Discount discount = new Discount();
		
		discount.setId(discountsDataBase.getDF_ID());
		discount.setDiscCode(discountsDataBase.getDF_DiscCode());
		discount.setDiscDes(discountsDataBase.getDF_DiscDesc());
		discount.setDiscRate(discountsDataBase.getDF_DiscRate());
		discount.setDrCr(discountsDataBase.getDF_DrCr());
		discount.setBaseNet(discountsDataBase.getDF_BaseNet());
		discount.setDiscAmount(discountsDataBase.getDF_DiscAmount());
		discount.setFixedUnit(discountsDataBase.getDF_FixedUnit());
		discount.setSalesCode(discountsDataBase.getDF_SalesCode());
		discount.setDateUpdated(discountsDataBase.getDF_DateUpdated());
		
		return discount;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Update a discount object
/// </summary>
/// <param name="machine"></param>
public
void updateDiscount(Discount discount){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		DiscountsDataBase discountsDataBase = new DiscountsDataBase(dataBaseAccess);

		discountsDataBase.setDF_ID(discount.getId());
		discountsDataBase.setDF_DiscCode(discount.getDiscCode());
		discountsDataBase.setDF_DiscDesc(discount.getDiscDes());
		discountsDataBase.setDF_DiscRate(discount.getDiscRate());
		discountsDataBase.setDF_DrCr(discount.getDrCr());
		discountsDataBase.setDF_BaseNet(discount.getBaseNet());
		discountsDataBase.setDF_DiscAmount(discount.getDiscAmount());
		discountsDataBase.setDF_FixedUnit(discount.getFixedUnit());
		discountsDataBase.setDF_SalesCode(discount.getSalesCode());
		discountsDataBase.setDF_DateUpdated(discount.getDateUpdated());

		discountsDataBase.update();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException pe){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message);
	}
}

/// <summary>
/// Write a discount object
/// </summary>
/// <param name="machine"></param>
public
void writeDiscount(Discount discount){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		DiscountsDataBase discountsDataBase = new DiscountsDataBase(dataBaseAccess);

		discountsDataBase.setDF_ID(discount.getId());
		discountsDataBase.setDF_DiscCode(discount.getDiscCode());
		discountsDataBase.setDF_DiscDesc(discount.getDiscDes());
		discountsDataBase.setDF_DiscRate(discount.getDiscRate());
		discountsDataBase.setDF_DrCr(discount.getDrCr());
		discountsDataBase.setDF_BaseNet(discount.getBaseNet());
		discountsDataBase.setDF_DiscAmount(discount.getDiscAmount());
		discountsDataBase.setDF_FixedUnit(discount.getFixedUnit());
		discountsDataBase.setDF_SalesCode(discount.getSalesCode());
		discountsDataBase.setDF_DateUpdated(discount.getDateUpdated());

		discountsDataBase.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException pe){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message);
	}
}

/// <summary>
/// Delete a discount object
/// </summary>
/// <param name="machine"></param>
public
void deleteDiscount(string sdiscount){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		DiscountsDataBase discountsDataBase = new DiscountsDataBase(dataBaseAccess);

		discountsDataBase.setDF_DiscCode(sdiscount);
		
		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException pe){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message);
	}
}

} // class

} // namespace
