using System;
using System.Collections;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.ErpException;

namespace Nujit.NujitERP.ClassLib.Core.Util{


public 
class GroupDiscCoreFactory : GLCurrencyCoreFactory{

public
GroupDiscCoreFactory() : base(){
}

/// <summary>
/// return all ProdPrizes codes 
/// </summary>
/// <returns></returns>

#if OE_SYNC
public
ArrayList readToSynchronizeGroupDisc(LastRevision lastRevision,int iquantity)
{
		ArrayList	arrayList = new ArrayList();
		GroupDiscDataBaseContainer groupDiscDataBaseContainer = new GroupDiscDataBaseContainer(dataBaseAccess);
	
		groupDiscDataBaseContainer.readToSynchronize(lastRevision,iquantity);
		
		IEnumerator iEnum = groupDiscDataBaseContainer.GetEnumerator();
		while (iEnum.MoveNext()){
			GroupDiscDataBase groupDiscDataBase = (GroupDiscDataBase)iEnum.Current;	

			GroupDisc groupDisc = new GroupDisc();

			groupDisc.setId(groupDiscDataBase.getPRGD_id());
			groupDisc.setGroupCode(groupDiscDataBase.getPRGD_GroupCode());		
			groupDisc.setDiscNum(groupDiscDataBase.getPRGD_DiscNum());
			groupDisc.setDisCode(groupDiscDataBase.getPRGD_DiscCode());		
			groupDisc.setDateUpdated(groupDiscDataBase.getPRGD_DateUpdated());
			
			arrayList.Add(groupDisc);
		}

		return arrayList;
}
#endif

public
string[][] getGroupDiscByCode (string sgroupCode)
{
	try
	{
		GroupDiscDataBaseContainer groupDiscDataBaseContainer = new GroupDiscDataBaseContainer(dataBaseAccess);

		groupDiscDataBaseContainer.readByCode (sgroupCode);

		string[] codes = new string[groupDiscDataBaseContainer.Count];
		if (codes.Length > 0)
			codes[0] = ((GroupDiscDataBase)groupDiscDataBaseContainer[0]).getPRGD_GroupCode();
		int i, j=1;
		for (i=1; i<codes.Length;i++)
		{
			string auxCode = ((GroupDiscDataBase)groupDiscDataBaseContainer[i]).getPRGD_GroupCode();
			if (!auxCode.Equals(codes[j-1]))
			{
				codes[j] = auxCode;
				j++;
			}
		}

		string[][] vec = new String[j][];
		int index = 0;

		while (index < j)
		{
			string[] v = new String[6];
		
			v[0] = codes[index];

			i=1;
			ArrayList discVec = this.getDiscountsInGroupDescByDesc (v[0],"",5,"PRGD_DiscNum");
			IEnumerator enuDisc = discVec.GetEnumerator();
			while ((enuDisc.MoveNext()) && (i<6))
			{
				Discount discount = (Discount)enuDisc.Current;
				v[i] = discount.getDiscDes();
				i++;
			}
			for (i=i; i<6; i++)
				v[i]="";
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

public
GroupDisc readGroupDisc(string sgroupCode, int idisNum)
{
	try
	{
		GroupDiscDataBase groupDiscDataBase = new GroupDiscDataBase(dataBaseAccess);

		groupDiscDataBase.setPRGD_GroupCode(sgroupCode);		
		groupDiscDataBase.setPRGD_DiscNum(idisNum);	
		
		if (!groupDiscDataBase.exists())
			return null;

		groupDiscDataBase.read();

		GroupDisc groupDisc = new GroupDisc(	groupDiscDataBase.getPRGD_id(),
												groupDiscDataBase.getPRGD_GroupCode(),
												groupDiscDataBase.getPRGD_DiscNum(),
												groupDiscDataBase.getPRGD_DiscCode(),
												groupDiscDataBase.getPRGD_DateUpdated());
		return groupDisc;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Return if exists a GroupDisc
/// </summary>
/// <param name="GroupDisc"></param>
/// <param name="familyCode"></param>
/// <returns></returns>
public
bool existsGroupDisc(string sgroupCode, int idisNum){
	try
	{
		GroupDiscDataBase groupDiscDataBase = new GroupDiscDataBase(dataBaseAccess);

		groupDiscDataBase.setPRGD_GroupCode(sgroupCode);
		groupDiscDataBase.setPRGD_DiscNum(idisNum);	
			
		return groupDiscDataBase.exists();

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message);
	}
}

/// <summary>
/// Write to the database a GroupDisc object
/// </summary>
/// <param name="proccess"></param>
public
void writeGroupDisc(GroupDisc groupDisc){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		GroupDiscDataBase groupDiscDataBase = new GroupDiscDataBase(dataBaseAccess);		

		groupDiscDataBase.setPRGD_id(groupDisc.getId());
		groupDiscDataBase.setPRGD_GroupCode(groupDisc.getGroupCode());		
		groupDiscDataBase.setPRGD_DiscNum(groupDisc.getDiscNum());
		groupDiscDataBase.setPRGD_DiscCode(groupDisc.getDisCode());		
		groupDiscDataBase.setPRGD_DateUpdated(groupDisc.getDateUpdated());
				
		groupDiscDataBase.write();
				
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
/// Update a GroupDisc object
/// </summary>
/// <param name="proccess"></param>
public
void updateGroupDisc(GroupDisc groupDisc){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		GroupDiscDataBase groupDiscDataBase = new GroupDiscDataBase(dataBaseAccess);		

		groupDiscDataBase.setPRGD_id(groupDisc.getId());
		groupDiscDataBase.setPRGD_GroupCode(groupDisc.getGroupCode());		
		groupDiscDataBase.setPRGD_DiscNum(groupDisc.getDiscNum());
		groupDiscDataBase.setPRGD_DiscCode(groupDisc.getDisCode());		
		groupDiscDataBase.setPRGD_DateUpdated(groupDisc.getDateUpdated());

		groupDiscDataBase.update();
		
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
/// Delete a GroupDisc object
/// </summary>
/// <param name="proccess"></param>
public
void deleteGroupDisc(GroupDisc groupDisc){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		GroupDiscDataBase groupDiscDataBase = new GroupDiscDataBase(dataBaseAccess);
	
		groupDiscDataBase.setPRGD_GroupCode(groupDisc.getGroupCode());		
		groupDiscDataBase.setPRGD_DiscNum(groupDisc.getDiscNum());	
				
		groupDiscDataBase.delete();
			
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