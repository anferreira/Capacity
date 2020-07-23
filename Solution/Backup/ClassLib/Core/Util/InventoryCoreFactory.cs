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
class InventoryCoreFactory : HotListCoreFactory{

protected
InventoryCoreFactory() : base(){
}

/// <summary>
/// Insert an row in the InvPltLoc table
/// </summary>
public 
void updateInventory(Inventory inventory){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		InvPltLocDataBaseContainer oldInvPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);
		oldInvPltLocDataBaseContainer.setIPLProdID(inventory.getProdID());
		oldInvPltLocDataBaseContainer.readByProdId();	
		
		//Delete the old container
		oldInvPltLocDataBaseContainer.delete();
	
		//Inser the new information
		InvPltLocDataBaseContainer invPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);
		string[][] invPltLocContainer = inventory.getInvPltLocAsString();
		for(int i = 0; i < invPltLocContainer.Length; i++){
			InvPltLocDataBase invPltLocDataBase = new InvPltLocDataBase(dataBaseAccess);
			invPltLocDataBase.setIPL_ProdID(invPltLocContainer[i][0]);
			invPltLocDataBase.setIPL_Seq(int.Parse(invPltLocContainer[i][1]));
			invPltLocDataBase.setIPL_LotID(invPltLocContainer[i][2]);
			invPltLocDataBase.setIPL_MasPrOrd(invPltLocContainer[i][3]);
			invPltLocDataBase.setIPL_PrOrd(invPltLocContainer[i][4]);
			invPltLocDataBase.setIPL_StkLoc(invPltLocContainer[i][5]);
			invPltLocDataBase.setIPL_Qoh(decimal.Parse(invPltLocContainer[i][6]));
			invPltLocDataBase.setIPL_QohAvail(decimal.Parse(invPltLocContainer[i][7]));
			invPltLocDataBase.setIPL_Uom(invPltLocContainer[i][8]);
			invPltLocDataBase.setIPL_Qoh2(decimal.Parse(invPltLocContainer[i][9]));
			invPltLocDataBase.setIPL_QohAvail2(decimal.Parse(invPltLocContainer[i][10]));
			invPltLocDataBase.setIPL_Uom2(invPltLocContainer[i][11]);
			invPltLocDataBase.setIPL_Prod2(invPltLocContainer[i][12]);	
			invPltLocDataBaseContainer.Add(invPltLocDataBase);
		}

		invPltLocDataBaseContainer.write();		

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch (PersistenceException pe){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}


/// <summary>
/// Return true if exists any inventory in the  InvPltLoc table
/// <param name="prodID"></param>
/// </summary>
public 
bool existsInventory(string prodId){
    try{
	    InvPltLocDataBase invPltLocDataBase = new InvPltLocDataBase(dataBaseAccess);
	    invPltLocDataBase.setIPL_ProdID(prodId);
	    return invPltLocDataBase.existsProdID();
	}catch(PersistenceException persistenceException){
       throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
	}
		
}

/// <summary>
/// Return an Invnetory object searching for the prodID
/// <param name="prodID"></param>
/// </summary>
public 
Inventory readInventory(string prodId){
	try{
	    InvPltLocDataBaseContainer invPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);
	    invPltLocDataBaseContainer.setIPLProdID(prodId);
	    invPltLocDataBaseContainer.readByProdId();

	    string[][] vec = new string[invPltLocDataBaseContainer.Count][];
	    int index = 0;
	    for(IEnumerator en = invPltLocDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    InvPltLocDataBase invPltLocDataBase = (InvPltLocDataBase) en.Current;
		    string[] aux = new String[13];
		    aux[0] = invPltLocDataBase.getIPL_ProdID();
		    aux[1] = invPltLocDataBase.getIPL_Seq().ToString();
		    aux[2] = invPltLocDataBase.getIPL_LotID();
		    aux[3] = invPltLocDataBase.getIPL_MasPrOrd();
		    aux[4] = invPltLocDataBase.getIPL_PrOrd();
		    aux[5] = invPltLocDataBase.getIPL_StkLoc();
		    aux[6] = invPltLocDataBase.getIPL_Qoh().ToString("#,###,###,##0.00000");
		    aux[7] = invPltLocDataBase.getIPL_QohAvail().ToString("#,###,###,##0.00000");
		    aux[8] = invPltLocDataBase.getIPL_Uom();
		    aux[9] = invPltLocDataBase.getIPL_Qoh2().ToString("#,###,###,##0.00000");
		    aux[10] = invPltLocDataBase.getIPL_QohAvail2().ToString("#,###,###,##0.00000");
		    aux[11] = invPltLocDataBase.getIPL_Uom2();
		    aux[12] = invPltLocDataBase.getIPL_Prod2();			
		    vec[index] = aux;
		    index++;
	    }

	    Inventory inventory = new Inventory(prodId, vec);

	    return inventory;
	}catch(PersistenceException persistenceException){
		 throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
	}
}

public
decimal getQtyOnHandForProduct(string prodId){

    try{
	    ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
	    prodFmInfoDataBase.setPFS_ProdID(prodId);
	    prodFmInfoDataBase.read();
    	
	    decimal inv = 0;
	    InvPltLocDataBase invPltLocDataBase = new InvPltLocDataBase(dataBaseAccess);
	    invPltLocDataBase.setIPL_ProdID(prodId);
	    invPltLocDataBase.setIPL_Seq(prodFmInfoDataBase.getPFS_SeqLast());
    	
	    if (invPltLocDataBase.exists()){
		    invPltLocDataBase.read();
		    inv = invPltLocDataBase.getIPL_Qoh();
	    }
    	
	    return inv;
	}catch(PersistenceException persistenceException){
		 throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }
}


public 
string[][] getAllPltInvLocAsString(){
	try{
		dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

		PltInvLocDataBaseContainer  pltInvLocDataBaseContainer = new PltInvLocDataBaseContainer(dataBaseAccess);
		pltInvLocDataBaseContainer.read();

		string[][] returnArray = new string[pltInvLocDataBaseContainer.Count][];
		int i = 0;

		ArrayList lst = new ArrayList();
		for(IEnumerator en = pltInvLocDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			PltInvLocDataBase pltInvLocDataBase = (PltInvLocDataBase)en.Current;

			string[] lineArray = new string[3];
			lineArray[0] = pltInvLocDataBase.getPL_Loc();
			lineArray[1] = pltInvLocDataBase.getPL_LocName();
			lineArray[2] = pltInvLocDataBase.getPL_HotListUse();

			returnArray[i] = lineArray;
			i++;
		}
	
		return returnArray;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
string[][] getInventoryReport(string prodId){
	try{
		InvPltLocDataBaseContainer invPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);
		invPltLocDataBaseContainer.setIPLProdID(prodId);
		invPltLocDataBaseContainer.readForReport();

		string[][] returnArray = new string[invPltLocDataBaseContainer.Count][];
		int i = 0;

		ArrayList lst = new ArrayList();
		for(IEnumerator en = invPltLocDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			InvPltLocDataBase invPltLocDataBase = (InvPltLocDataBase) en.Current;

			string[] lineArray = new string[15];
			lineArray[0] = invPltLocDataBase.getIPL_ProdID();
			lineArray[1] = invPltLocDataBase.getIPL_Seq().ToString();
			lineArray[2] = invPltLocDataBase.getIPL_StkLoc();
			lineArray[3] = invPltLocDataBase.getIPL_ActID();
			lineArray[4] = invPltLocDataBase.getIPL_LotID();
			lineArray[5] = invPltLocDataBase.getIPL_MasPrOrd();
			lineArray[6] = invPltLocDataBase.getIPL_PrOrd();
			lineArray[7] = invPltLocDataBase.getIPL_Qoh().ToString();
			lineArray[8] = invPltLocDataBase.getIPL_QohAvail().ToString();
			lineArray[9] = invPltLocDataBase.getIPL_Uom();
			lineArray[10] = invPltLocDataBase.getIPL_Qoh2().ToString();
			lineArray[11] = invPltLocDataBase.getIPL_QohAvail2().ToString();
			lineArray[12] = invPltLocDataBase.getIPL_Uom2();
			lineArray[13] = invPltLocDataBase.getIPL_Prod2();
			lineArray[14] = invPltLocDataBase.getPFS_Des1();
			returnArray[i] = lineArray;
			i++;
		}

		return returnArray;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
decimal getMinInventory(string prodId, int seq){
	try{
		ProdFmActPlanDataBase prodFmActPlanDataBase = new ProdFmActPlanDataBase(dataBaseAccess);
		prodFmActPlanDataBase.setPAPL_ProdID(prodId);
		prodFmActPlanDataBase.setPAPL_Seq(seq);
		if (prodFmActPlanDataBase.exists()){
			prodFmActPlanDataBase.read();
			return prodFmActPlanDataBase.getPAPL_MinInv();
		}
		return 0;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
decimal getMinInventoryCum(string prodId, int seq){
	try{
		ProdFmActPlanDataBase prodFmActPlanDataBase = new ProdFmActPlanDataBase(dataBaseAccess);
		prodFmActPlanDataBase.setPAPL_ProdID(prodId);
		prodFmActPlanDataBase.setPAPL_Seq(seq);
		
		return prodFmActPlanDataBase.getMinInvCum();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

} // class

} // namespace