using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.ScheduleDemand;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;
using Nujit.NujitERP.ClassLib.Core.Planned;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.CapacityDemand;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.ScheduleDemand;
using System.Collections.Generic;
using Nujit.NujitERP.ClassLib.Core.Machines;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Machines;
using Nujit.NujitERP.ClassLib.Core.Cms;

namespace Nujit.NujitERP.ClassLib.Core.Util{


public
class ProductCoreFactory : ProductActCostCoreFactory{

protected
ProductCoreFactory() : base(){
}

/// <summary>
/// return all products codes 
/// </summary>
/// <returns></returns>
public
string[] getProductCodes(){
    
    try{
	
	    ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    return prodFmInfoDataBaseContainer.getProductCodes();
    
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[] getManufacturedProductCodes(string plantCode){
	try{
	
	    ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    return prodFmInfoDataBaseContainer.getManufacturedProductCodes(plantCode);
    
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getProductsByDescOrId(string desc, string retailProductType){
	
	try{
	
	    ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    prodFmInfoDataBaseContainer.readByDescOrId(desc, retailProductType);

	    string[][] items = new string[prodFmInfoDataBaseContainer.Count][];

	    int i = 0;
	    for(IEnumerator en = prodFmInfoDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    ProdFmInfoDataBase prodFmInfoDataBase = (ProdFmInfoDataBase) en.Current;
    			
		    string[] item = new String[9];
		    item[0] = prodFmInfoDataBase.getPFS_ProdID();
		    item[1] = prodFmInfoDataBase.getPFS_Des1();
		    item[2] = prodFmInfoDataBase.getPFS_Des2();
		    item[3] = prodFmInfoDataBase.getPFS_Des3();
		    item[4] = prodFmInfoDataBase.getPFS_SeqLast().ToString();
		    item[5] = prodFmInfoDataBase.getPFS_FamProd();
		    item[6] = prodFmInfoDataBase.getPFS_PartType();
		    item[7] = prodFmInfoDataBase.getPFS_MajorGroup();
		    item[8] = prodFmInfoDataBase.getPFS_MinorGroup();
    			
		    items[i] = item;
		    i++;
	    }
	    return items;
	 
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getProductsByProdId(string prod){
	try{
	    ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    prodFmInfoDataBaseContainer.readByProdId(prod);

	    string[][] items = new string[prodFmInfoDataBaseContainer.Count][];

	    int i = 0;
	    for(IEnumerator en = prodFmInfoDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    ProdFmInfoDataBase prodFmInfoDataBase = (ProdFmInfoDataBase)en.Current;
    			
		    string[] item = new String[9];
		    item[0] = prodFmInfoDataBase.getPFS_ProdID();
		    item[1] = prodFmInfoDataBase.getPFS_Des1();
		    item[2] = prodFmInfoDataBase.getPFS_Des2();
		    item[3] = prodFmInfoDataBase.getPFS_Des3();
		    item[4] = prodFmInfoDataBase.getPFS_SeqLast().ToString();
		    item[5] = prodFmInfoDataBase.getPFS_FamProd();
		    item[6] = prodFmInfoDataBase.getPFS_PartType();
		    item[7] = prodFmInfoDataBase.getPFS_MajorGroup();
		    item[8] = prodFmInfoDataBase.getPFS_MinorGroup();
    			
		    items[i] = item;
		    i++;
	    }
	    return items;
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getProductsByProdIdAndFamily(string prod, bool family){
	try{
	    ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    prodFmInfoDataBaseContainer.readByProdIdAndFamily(prod, family);

	    string[][] items = new string[prodFmInfoDataBaseContainer.Count][];

	    int i = 0;
	    for(IEnumerator en = prodFmInfoDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    ProdFmInfoDataBase prodFmInfoDataBase = (ProdFmInfoDataBase)en.Current;
    			
		    string[] item = new String[9];
		    item[0] = prodFmInfoDataBase.getPFS_ProdID();
		    item[1] = prodFmInfoDataBase.getPFS_Des1();
		    item[2] = prodFmInfoDataBase.getPFS_Des2();
		    item[3] = prodFmInfoDataBase.getPFS_Des3();
		    item[4] = prodFmInfoDataBase.getPFS_SeqLast().ToString();
		    item[5] = prodFmInfoDataBase.getPFS_FamProd();
		    item[6] = prodFmInfoDataBase.getPFS_PartType();
		    item[7] = prodFmInfoDataBase.getPFS_MajorGroup();
		    item[8] = prodFmInfoDataBase.getPFS_MinorGroup();
    			
		    items[i] = item;
		    i++;
	    }
	    return items;
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getProductsByDesc(string desc){

    try{
	    ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    prodFmInfoDataBaseContainer.readByDesc(desc);

	    string[][] items = new string[prodFmInfoDataBaseContainer.Count][];

	    int i = 0;
	    for(IEnumerator en = prodFmInfoDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    ProdFmInfoDataBase prodFmInfoDataBase = (ProdFmInfoDataBase)en.Current;
    			
		    string[] item = new String[9];
		    item[0] = prodFmInfoDataBase.getPFS_ProdID();
		    item[1] = prodFmInfoDataBase.getPFS_Des1();
		    item[2] = prodFmInfoDataBase.getPFS_Des2();
		    item[3] = prodFmInfoDataBase.getPFS_Des3();
		    item[4] = prodFmInfoDataBase.getPFS_SeqLast().ToString();
		    item[5] = prodFmInfoDataBase.getPFS_FamProd();
		    item[6] = prodFmInfoDataBase.getPFS_PartType();
		    item[7] = prodFmInfoDataBase.getPFS_MajorGroup();
		    item[8] = prodFmInfoDataBase.getPFS_MinorGroup();
    			
		    items[i] = item;
		    i++;
	    }
	    return items;
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// return all family codes
/// </summary>
/// <returns></returns>
public
string[] getProductFamilyCodes(){
    try{
	
	    ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    return prodFmInfoDataBaseContainer.getProductFamilyCodes();
    
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Returns true is the part number is a family of products
/// </summary>
/// <param name="partNum"></param>
/// <returns></returns>
public 
bool isFamilyPart(string partNum){
    try{
	    ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);

	    prodFmInfoDataBase.setPFS_ProdID(partNum);
	    if (prodFmInfoDataBase.exists()) {
            prodFmInfoDataBase.read();
		    return (prodFmInfoDataBase.getPFS_FamProd() == "F");
	    }
	    else
		    return false;
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Return all seqs valids for a product code
/// </summary>
/// <param name="productCode"></param>
/// <returns></returns>
public
string[] getValidsSeqsForProduct(string productCode){
    try{
	    ProdFmActHDataBaseContainer prodFmActHDataBaseContainer = new ProdFmActHDataBaseContainer(dataBaseAccess);
	    prodFmActHDataBaseContainer.readByProduct(productCode);

	    string[] vec = new string[prodFmActHDataBaseContainer.Count];
	    int i = 0;
	    for(IEnumerator en = prodFmActHDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    ProdFmActHDataBase prodFmActHDataBase = (ProdFmActHDataBase) en.Current;
		    vec[i] = prodFmActHDataBase.getPAH_Seq().ToString();
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
string[] getValidsSeqsByProdAndDept(string productCode, string department){
    try{
	    ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
	    prodFmActSubDataBaseContainer.readByProdAndDept(productCode, department);

	    string[] vec = new string[prodFmActSubDataBaseContainer.Count];
	    int i = 0;
	    for(IEnumerator en = prodFmActSubDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    ProdFmActSubDataBase prodFmActSubDataBase = (ProdFmActSubDataBase) en.Current;
		    vec[i] = prodFmActSubDataBase.getPC_Seq().ToString();
		    i++;
	    }
	    return vec;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Return if exists a product
/// </summary>
/// <param name="productCode"></param>
/// <param name="familyCode"></param>
/// <returns></returns>
public
bool existsProduct(string id){
	try{
	
	    ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
	    prodFmInfoDataBase.setPFS_ProdID(id);
	    return prodFmInfoDataBase.exists();
    
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
Product createProduct(){
	return new Product();
}

/// <summary>
/// Read and return a Product object
/// </summary>
/// <param name="productCode"></param>
/// <param name="familyCode"></param>
/// <returns></returns>
public
Product readProduct(string id){
	try{
	
	    ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
	    prodFmInfoDataBase.setPFS_ProdID(id);
    	
	    if (!prodFmInfoDataBase.exists())
		    return null;

	    prodFmInfoDataBase.read();

	    Product product = new Product(prodFmInfoDataBase.getPFS_Id(), prodFmInfoDataBase.getPFS_ProdID(),prodFmInfoDataBase.getPFS_Db(),
	        prodFmInfoDataBase.getPFS_Des1(),
		    prodFmInfoDataBase.getPFS_Des2(), prodFmInfoDataBase.getPFS_Des3(),
		    prodFmInfoDataBase.getPFS_VarFam(), prodFmInfoDataBase.getPFS_SeqLast(),
		    prodFmInfoDataBase.getPFS_ActIDLast(), prodFmInfoDataBase.getPFS_FamProd(),
		    prodFmInfoDataBase.getPFS_PartType(), prodFmInfoDataBase.getPFS_InvStatus(),
		    prodFmInfoDataBase.getPFS_ABCCode(), prodFmInfoDataBase.getPFS_MajorGroup(),
		    prodFmInfoDataBase.getPFS_MinorGroup(), prodFmInfoDataBase.getPFS_GLExp(),
		    prodFmInfoDataBase.getPFS_GLDistr(), prodFmInfoDataBase.getPFS_MajorSales(),
		    prodFmInfoDataBase.getPFS_MinorSales(), prodFmInfoDataBase.getPFS_LastRevision(),
		    prodFmInfoDataBase.getPFS_RetailProductType(), prodFmInfoDataBase.getPFS_StdPackSize(),
		    prodFmInfoDataBase.getPFS_StdPackUnit(),prodFmInfoDataBase.getPFS_ProdCode(),

            prodFmInfoDataBase.getPFS_Plant(),
            prodFmInfoDataBase.getPFS_OptimRunPurchSize(),
            prodFmInfoDataBase.getPFS_ProdMultiplier(),
            prodFmInfoDataBase.getPFS_MinRunPurchQty(),
            prodFmInfoDataBase.getPFS_MatlPrepLdTime(),
            prodFmInfoDataBase.getPFS_PallPackSize(),
            prodFmInfoDataBase.getPFS_PalletPackUnit(),
            prodFmInfoDataBase.getPFS_MinQty(),
            prodFmInfoDataBase.getPFS_MaxQty(),
            prodFmInfoDataBase.getPFS_VirtKanDemProf(),
            prodFmInfoDataBase.getPFS_VirtKanManDem(),
            prodFmInfoDataBase.getPFS_DaysOnHand(),
            prodFmInfoDataBase.getPFS_ObectivesAutomaticCalc(),
            prodFmInfoDataBase.getPFS_DemandLowQtySplit(),
            prodFmInfoDataBase.getPFS_Level());

            return product;
	 }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
ProdFmInfoDataBase objectToObjectDataBase(Product product){
    ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);

    prodFmInfoDataBase.setPFS_Id(product.Id);
    prodFmInfoDataBase.setPFS_ProdID(product.getProdID());
    prodFmInfoDataBase.setPFS_Db(product.getDb());
    prodFmInfoDataBase.setPFS_Des1(product.getDes1());
    prodFmInfoDataBase.setPFS_Des2(product.getDes2());
    prodFmInfoDataBase.setPFS_Des3(product.getDes3());
    prodFmInfoDataBase.setPFS_VarFam(product.getVarFam());
    prodFmInfoDataBase.setPFS_SeqLast(product.getSeqLast());
    prodFmInfoDataBase.setPFS_ActIDLast(product.getActIDLast());
    prodFmInfoDataBase.setPFS_FamProd(product.getFamProd());
    prodFmInfoDataBase.setPFS_PartType(product.getPartType());
    prodFmInfoDataBase.setPFS_InvStatus(product.getInvStatus());
    prodFmInfoDataBase.setPFS_ABCCode(product.getABCCode());
    prodFmInfoDataBase.setPFS_MajorGroup(product.getMajorGroup());
    prodFmInfoDataBase.setPFS_MinorGroup(product.getMinorGroup());
    prodFmInfoDataBase.setPFS_GLExp(product.getGLExp());
    prodFmInfoDataBase.setPFS_GLDistr(product.getGLDistr());
    prodFmInfoDataBase.setPFS_MajorSales(product.getMajorSales());
    prodFmInfoDataBase.setPFS_MinorSales(product.getMinorSales());
    prodFmInfoDataBase.setPFS_LastRevision(product.getLastRevision());
    prodFmInfoDataBase.setPFS_RetailProductType(product.getRetailProductType());
    prodFmInfoDataBase.setPFS_StdPackSize(product.getStdPackSize());
    prodFmInfoDataBase.setPFS_StdPackUnit(product.getStdPackUnit());
    prodFmInfoDataBase.setPFS_ProdCode(product.getProdCode());

    prodFmInfoDataBase.setPFS_Plant(product.Plant);
	prodFmInfoDataBase.setPFS_OptimRunPurchSize(product.OptimRunPurchSize);
	prodFmInfoDataBase.setPFS_ProdMultiplier(product.ProdMultiplier);
	prodFmInfoDataBase.setPFS_MinRunPurchQty(product.MinRunPurchQty);
	prodFmInfoDataBase.setPFS_MatlPrepLdTime(product.MatlPrepLdTime);
	prodFmInfoDataBase.setPFS_PallPackSize(product.PallPackSize);
	prodFmInfoDataBase.setPFS_PalletPackUnit(product.PalletPackUnit);
	prodFmInfoDataBase.setPFS_MinQty(product.MinQty);
	prodFmInfoDataBase.setPFS_MaxQty(product.MaxQty);
	prodFmInfoDataBase.setPFS_VirtKanDemProf(product.VirtKanDemProf);
	prodFmInfoDataBase.setPFS_VirtKanManDem(product.VirtKanManDem);
    prodFmInfoDataBase.setPFS_DaysOnHand(product.DaysOnHand);
    prodFmInfoDataBase.setPFS_ObectivesAutomaticCalc(product.ObectivesAutomaticCalc);
    prodFmInfoDataBase.setPFS_DemandLowQtySplit(product.DemandLowQtySplit);
    prodFmInfoDataBase.setPFS_Level(product.Level);

    return prodFmInfoDataBase;
}

private
Product objectDataBaseToObject(ProdFmInfoDataBase prodFmInfoDataBase){
     Product product = new Product(prodFmInfoDataBase.getPFS_Id(),prodFmInfoDataBase.getPFS_ProdID(),prodFmInfoDataBase.getPFS_Db(),
	        prodFmInfoDataBase.getPFS_Des1(),
		    prodFmInfoDataBase.getPFS_Des2(), prodFmInfoDataBase.getPFS_Des3(),
		    prodFmInfoDataBase.getPFS_VarFam(), prodFmInfoDataBase.getPFS_SeqLast(),
		    prodFmInfoDataBase.getPFS_ActIDLast(), prodFmInfoDataBase.getPFS_FamProd(),
		    prodFmInfoDataBase.getPFS_PartType(), prodFmInfoDataBase.getPFS_InvStatus(),
		    prodFmInfoDataBase.getPFS_ABCCode(), prodFmInfoDataBase.getPFS_MajorGroup(),
		    prodFmInfoDataBase.getPFS_MinorGroup(), prodFmInfoDataBase.getPFS_GLExp(),
		    prodFmInfoDataBase.getPFS_GLDistr(), prodFmInfoDataBase.getPFS_MajorSales(),
		    prodFmInfoDataBase.getPFS_MinorSales(), prodFmInfoDataBase.getPFS_LastRevision(),
		    prodFmInfoDataBase.getPFS_RetailProductType(), prodFmInfoDataBase.getPFS_StdPackSize(),
		    prodFmInfoDataBase.getPFS_StdPackUnit(),prodFmInfoDataBase.getPFS_ProdCode(),

            prodFmInfoDataBase.getPFS_Plant(),
            prodFmInfoDataBase.getPFS_OptimRunPurchSize(),
            prodFmInfoDataBase.getPFS_ProdMultiplier(),
            prodFmInfoDataBase.getPFS_MinRunPurchQty(),
            prodFmInfoDataBase.getPFS_MatlPrepLdTime(),
            prodFmInfoDataBase.getPFS_PallPackSize(),
            prodFmInfoDataBase.getPFS_PalletPackUnit(),
            prodFmInfoDataBase.getPFS_MinQty(),
            prodFmInfoDataBase.getPFS_MaxQty(),
            prodFmInfoDataBase.getPFS_VirtKanDemProf(),
            prodFmInfoDataBase.getPFS_VirtKanManDem(),
            prodFmInfoDataBase.getPFS_DaysOnHand(),
            prodFmInfoDataBase.getPFS_ObectivesAutomaticCalc(),
            prodFmInfoDataBase.getPFS_DemandLowQtySplit(),
            prodFmInfoDataBase.getPFS_Level());

            return product;
}

private
ProductView objectDataBaseToObject(ProdFmInfoViewDataBase prodFmInfoViewDataBase){
     ProductView productView = new ProductView(prodFmInfoViewDataBase.getPFS_Id(),prodFmInfoViewDataBase.getPFS_ProdID(),prodFmInfoViewDataBase.getPFS_Db(),
	        prodFmInfoViewDataBase.getPFS_Des1(),
		    prodFmInfoViewDataBase.getPFS_Des2(), prodFmInfoViewDataBase.getPFS_Des3(),
		    prodFmInfoViewDataBase.getPFS_VarFam(), prodFmInfoViewDataBase.getPFS_SeqLast(),
		    prodFmInfoViewDataBase.getPFS_ActIDLast(), prodFmInfoViewDataBase.getPFS_FamProd(),
		    prodFmInfoViewDataBase.getPFS_PartType(), prodFmInfoViewDataBase.getPFS_InvStatus(),
		    prodFmInfoViewDataBase.getPFS_ABCCode(), prodFmInfoViewDataBase.getPFS_MajorGroup(),
		    prodFmInfoViewDataBase.getPFS_MinorGroup(), prodFmInfoViewDataBase.getPFS_GLExp(),
		    prodFmInfoViewDataBase.getPFS_GLDistr(), prodFmInfoViewDataBase.getPFS_MajorSales(),
		    prodFmInfoViewDataBase.getPFS_MinorSales(), prodFmInfoViewDataBase.getPFS_LastRevision(),
		    prodFmInfoViewDataBase.getPFS_RetailProductType(), prodFmInfoViewDataBase.getPFS_StdPackSize(),
		    prodFmInfoViewDataBase.getPFS_StdPackUnit(),prodFmInfoViewDataBase.getPFS_ProdCode(),

            prodFmInfoViewDataBase.getPFS_Plant(),
            prodFmInfoViewDataBase.getPFS_OptimRunPurchSize(),
            prodFmInfoViewDataBase.getPFS_ProdMultiplier(),
            prodFmInfoViewDataBase.getPFS_MinRunPurchQty(),
            prodFmInfoViewDataBase.getPFS_MatlPrepLdTime(),
            prodFmInfoViewDataBase.getPFS_PallPackSize(),
            prodFmInfoViewDataBase.getPFS_PalletPackUnit(),
            prodFmInfoViewDataBase.getPFS_MinQty(),
            prodFmInfoViewDataBase.getPFS_MaxQty(),
            prodFmInfoViewDataBase.getPFS_VirtKanDemProf(),
            prodFmInfoViewDataBase.getPFS_VirtKanManDem(),
            prodFmInfoViewDataBase.getPFS_DaysOnHand(),
            prodFmInfoViewDataBase.getPFS_ObectivesAutomaticCalc(),
            prodFmInfoViewDataBase.getPFS_DemandLowQtySplit(),
            prodFmInfoViewDataBase.getPFS_Level(),
            prodFmInfoViewDataBase.getQoh(),
            prodFmInfoViewDataBase.getSchMaterialAvailId(), 
            prodFmInfoViewDataBase.getSchMaterialAvailId() > 0 ? Constants.STRING_YES:Constants.STRING_NO);

    return productView;
}

/// <summary>
/// Write to the database a Product object
/// </summary>
/// <param name="proccess"></param>
public
void writeProduct(Product product){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdFmInfoDataBase prodFmInfoDataBase = objectToObjectDataBase(product);
		prodFmInfoDataBase.write();
		
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
/// Update a Product object
/// </summary>
/// <param name="proccess"></param>
public
void updateProduct(Product product){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdFmInfoDataBase prodFmInfoDataBase = objectToObjectDataBase(product);		
		prodFmInfoDataBase.update();
		
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
/// Delete a Product object
/// </summary>
/// <param name="proccess"></param>
public
void deleteProduct(Product product){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
		prodFmInfoDataBase.setPFS_ProdID(product.getProdID());
		prodFmInfoDataBase.delete();
		
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
string[][] getComponentsFromFamily(string familyCode){
	
	try{
	    ProdFmActPlanDtDataBaseContainer prodFmActPlanDtDataBaseContainer = new ProdFmActPlanDtDataBaseContainer(dataBaseAccess);
	    prodFmActPlanDtDataBaseContainer.readByFamily(familyCode);

	    string[][] components = new string[prodFmActPlanDtDataBaseContainer.Count][];
	    int i = 0;
    	
	    for(IEnumerator en = prodFmActPlanDtDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    ProdFmActPlanDtDataBase prodFmActPlanDtDataBase = (ProdFmActPlanDtDataBase) en.Current;
    		
		    string[] line = new string[3];
		    line[0] = prodFmActPlanDtDataBase.getPFPD_ProdID();
		    line[1] = prodFmActPlanDtDataBase.getPFPD_FamSeq().ToString();
            line[2] = Convert.ToString(prodFmActPlanDtDataBase.getPFPD_Qty());
		    components[i] = line;
		    i++;
	    }	
    	
	    return components;
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getAllMaterialsForProduct(string prodId, int seqId,string splant){
	try{
	    ProdFmInfoDataBase prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
	    prodFmInfoDataBase.setPFS_ProdID(prodId);
	    if (!prodFmInfoDataBase.read())
            return new string[0][];
    	
	    ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    prodFmInfoDataBaseContainer.Add(prodFmInfoDataBase, prodFmInfoDataBase.getPFS_ProdID());
    	
	    ProdFmActSubDataBase prodFmActSubDataBase = null;
        getProdFmActSubDataBase(out prodFmActSubDataBase, prodId, seqId,splant);	    

	    ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
	    prodFmActSubDataBaseContainer.Add(prodFmActSubDataBase);

        Hashtable hashBomSum= new Hashtable();
	    Bom bom = this.makeBom(prodId, seqId,splant,prodFmInfoDataBaseContainer, prodFmActSubDataBaseContainer, hashBomSum);
    	
	    string[][] v = bom.toArray();
	    string[][] returnArray = new string[v.Length][];
        ArrayList arrayValid = new ArrayList();//work around because for any reason old coade loading null records
                
    	
	    for(int i = 0; i < v.Length; i++){
		    string[] line = new string[7];

		    decimal inv = 0;
		    string desc = "";
			string type = "";

            if (v[i] != null){ //AF 2019-07-22 added if becuase some recors having null
		        ProdFmInfoDataBase seeked = 
			        prodFmInfoDataBaseContainer.getProdFmInfo(v[i][1]);

		        if (seeked != null){
			        seeked.read();
			        desc = seeked.getPFS_Des1();
				    type = seeked.getPFS_PartType();
		        }

		        InvPltLocDataBaseContainer invPltLocDataBaseContainer = new InvPltLocDataBaseContainer(dataBaseAccess);
                inv = invPltLocDataBaseContainer.getSumQtyByPartSeq(v[i][1],NumberUtil.isIntegerNumber(v[i][2]) ? int.Parse(v[i][2]):0, splant);		        

		        line[0] = v[i][1];         // prod
		        line[1] = v[i][0];         // level
		        line[2] = desc;            // desc
		        line[3] = v[i][3];         // qty req
		        line[4] = decimal.Round(inv, 2).ToString();  // inventory
		        line[5] = v[i][2];  // sequence
			    line[6] = type.Equals("P") ? "Purchased" : "Manufatured";

		        returnArray[i] = line;

                arrayValid.Add(line);
            }
	    }

        //work around because for any reason old coade loading null records
        returnArray = new string[arrayValid.Count][];
        for (int i=0; i < arrayValid.Count;i++){            
            returnArray[i] = (string[])arrayValid[i];
        }
        
	    return returnArray;
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
string[] getMainMaterial(string prodId, string seq){
	try{
		BomSumDataBase bomSumDataBase = new BomSumDataBase(dataBaseAccess);
		bomSumDataBase.setBMS_ProdID(prodId.Trim());
		bomSumDataBase.setBMS_Seq(int.Parse(seq.Trim()));
		
		string[] returnArray = new string[2];

		if (bomSumDataBase.exists()){
			bomSumDataBase.read();
			returnArray[0] = bomSumDataBase.getBMS_MatID();
			returnArray[1] = bomSumDataBase.getBMS_MatSeq().ToString();
		}else{
			returnArray[0] = prodId;
			returnArray[1] = seq;
		}

		return returnArray;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
string[][] getProductsForReportAsString(string infMayGroup,string infMinGroup,string supMayGroup,string supMinGroup, string[] prodsID){
	try{
		ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
		prodFmInfoDataBaseContainer.readForReport(infMayGroup,infMinGroup,supMayGroup,supMinGroup,prodsID);

		string[][] returnArray = new string[prodFmInfoDataBaseContainer.Count][];
		int i = 0;

		ArrayList lst = new ArrayList();
		for(IEnumerator en = prodFmInfoDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			ProdFmInfoDataBase prodFmInfoDataBase = (ProdFmInfoDataBase)  en.Current;

			string[] lineArray = new string[18];
			lineArray[0] = prodFmInfoDataBase.getPFS_ProdID();
			lineArray[1] = prodFmInfoDataBase.getPFS_Des1();
			lineArray[2] = prodFmInfoDataBase.getPFS_Des2();
			lineArray[3] = prodFmInfoDataBase.getPFS_Des3();
			lineArray[4] = prodFmInfoDataBase.getPFS_VarFam();
			lineArray[5] = prodFmInfoDataBase.getPFS_SeqLast().ToString();
			lineArray[6] = prodFmInfoDataBase.getPFS_ActIDLast();
			lineArray[7] = prodFmInfoDataBase.getPFS_FamProd();
			lineArray[8] = prodFmInfoDataBase.getPFS_PartType();
			lineArray[9] = prodFmInfoDataBase.getPFS_InvStatus();
			lineArray[10] = prodFmInfoDataBase.getPFS_ABCCode();
			lineArray[11] = prodFmInfoDataBase.getPFS_MajorGroup();
			lineArray[12] = prodFmInfoDataBase.getPFS_MinorGroup();
			lineArray[13] = prodFmInfoDataBase.getPFS_GLExp();
			lineArray[14] = prodFmInfoDataBase.getPFS_GLDistr();
			lineArray[15] = prodFmInfoDataBase.getPFS_MajorSales();
			lineArray[16] = prodFmInfoDataBase.getPFS_MinorSales();
			lineArray[17] = prodFmInfoDataBase.getPFS_LastRevision().ToString();
	
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

//------------------ Select the Major Group from ProdFmInfo

public 
string[] getMajorGroupASString(string major){
	try{
		ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
		return prodFmInfoDataBaseContainer.readMajorGroup(major);
		
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

//------------------ Select the Minor Group from ProdFmInfo

public 
string[] getMinorGroupASString(){
	try{
		ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
		return prodFmInfoDataBaseContainer.readMinorGroup();
		
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
ArrayList readGLExps(){
	try{
		ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
		return prodFmInfoDataBaseContainer.readGLExps();
		
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
ProductContainer readProductByFilters(string sprodId,string sdes1,int imachineId,string smajGroup,string stype,int rows){
	try{
        ProductContainer productContainer = new ProductContainer();
        ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
		prodFmInfoDataBaseContainer.readByFilters(sprodId, sdes1, imachineId, smajGroup,stype,rows);

        foreach(ProdFmInfoDataBase prodFmInfoDataBase in prodFmInfoDataBaseContainer){
            Product product = objectDataBaseToObject(prodFmInfoDataBase);
            productContainer.Add(product);
        }
		return productContainer;

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
ProductContainer readProductViewByFilters(string splant,string sprodId,string sdes1,int imachineId,string smajGroup,string stype,string schMatAvailFlag,int rows){
	try{
        ProductContainer                productContainer = new ProductContainer();
        ProdFmInfoViewDataBaseContainer prodFmInfoViewDataBaseContainer = new ProdFmInfoViewDataBaseContainer(dataBaseAccess);
		prodFmInfoViewDataBaseContainer.readByFilters(splant,sprodId, sdes1, imachineId, smajGroup,stype, schMatAvailFlag,rows);

        foreach(ProdFmInfoViewDataBase prodFmInfoViewDataBase in prodFmInfoViewDataBaseContainer){
            ProductView productView = objectDataBaseToObject(prodFmInfoViewDataBase);
            productContainer.Add(productView);
        }
		return productContainer;

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}
        /*
public
void loadSchMaterialForProductList(ProductContainer productContainer,string splant,string smatPlanned,int rows){
	try{
        HotListHdr                  hotListHdr = readLastHotList(splant);
        SchMaterialAvailContainer   schMaterialAvailContainer = readSchMaterialAvailByFilters(splant, hotListHdr!= null ? hotListHdr.Id:0,0,0,"",-1,"",-1,DateTime.Now,true,0);

        for (int i=0; i < productContainer.Count;i++){
            Product             product = productContainer[i];
            SchMaterialAvail    schMaterialAvail = schMaterialAvailContainer.getFistByPartSeq(product.ProdID, product.pare){
            

        }
              
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}*/

public
RoutingContainer getBuildByFilters(string splant,string sprodId, int seq, int imachineId,bool bincludeAlternative,bool bonlyMachAlternative){   
	try{
        RoutingContainer    routingContainer = new RoutingContainer();
        Routing             routing=null;
        string              sroutingType = "";

        if (!bincludeAlternative)
            sroutingType = Routing.ROUTING_TYPE_MAIN;
        if (bonlyMachAlternative)
            sroutingType = Routing.ROUTING_TYPE_ALTERNATIVE;
            
	    ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
	    prodFmActSubDataBaseContainer.readByFilters(sprodId, seq, imachineId,splant, sroutingType,false,false,0);
	    
	    foreach(ProdFmActSubDataBase prodFmActSubDataBase in prodFmActSubDataBaseContainer){
            routing  = objectDataBaseToObject(prodFmActSubDataBase);
            routingContainer.Add(routing);
	
            if (imachineId > 0)
                routing.MachIdShow = imachineId; 
            else { 
                PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
                pltDeptMachDataBase.setPDM_Plt(prodFmActSubDataBase.getPC_Plt());
                pltDeptMachDataBase.setPDM_Dept(prodFmActSubDataBase.getPC_Dept());
                pltDeptMachDataBase.setPDM_Mach(prodFmActSubDataBase.getPC_Cfg());
                if (pltDeptMachDataBase.read())
                    routing.MachIdShow = pltDeptMachDataBase.getPDM_ID();                    
            }
	    }
        
	    return routingContainer;
	 
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}
public
ScheduleHdr processScheduleByHotListView(int icapacityHdrId,HotListViewContainer hotListViewContainer, MachineContainer machineContainer,DateTime startDate,DateTime endDate,CapacityView.SORT_TYPE sortType){
    ScheduleHdr             scheduleHdr = null;
    try{
        ScheduleHdr                 scheduleHdrOld = new ScheduleHdr();   
        ScheduleHdr                 scheduleHdrAux = null;                                    
        ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);
        HotListView                 hotListViewId = hotListViewContainer.Count > 0 ? hotListViewContainer[0] : null;
        int                         ihotListId = hotListViewId != null ? hotListViewId.HotListId : 0;

        //check if already exists Schedule created    
        scheduleHdr = new ScheduleHdr();

        CapacityHdrDataBase capacityHdrDataBase = new CapacityHdrDataBase(dataBaseAccess); //read capacity hdr
        capacityHdrDataBase.setId(icapacityHdrId);
        if (capacityHdrDataBase.read())
            scheduleHdr.Plant = capacityHdrDataBase.getPlant(); //set plant
            
        //scheduleHdrAux = getIfAlreadyScheduled(ihotListId,icapacityHdrId);                 
        scheduleHdrAux = readScheduleHdrLast(capacityHdrDataBase.getPlant());
        if (scheduleHdrAux!= null)
            scheduleHdr = scheduleHdrAux;
        scheduleHdrOld = cloneScheduleHdr(scheduleHdr);        

        if (hotListViewContainer.Count > 0 && machineContainer.Count > 0){                        
            SchedulePart            schedulePart = null;        
            int                     ireqId=0;
            HotListViewContainer    hotListViewContainerOnRangeMachine = new HotListViewContainer(); 
            
            //get list of records on range,but we need to check if properly machine too


            for (int i=0; i < machineContainer.Count;i++){
                Machine machine = (Machine)machineContainer[i];

                hotListViewContainerOnRangeMachine = hotListViewContainer.getChildsByDatesRangeAndnMachine(machine,startDate,endDate);                
                hotListViewContainerOnRangeMachine.sortByMachine(); //order by date too

                for (int j=0; j < hotListViewContainerOnRangeMachine.Count;j++){
                    HotListView     hotListView = hotListViewContainerOnRangeMachine[j];
            
                    //read machine
                    PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);                                        
                    pltDeptMachDataBase.setPDM_Plt(hotListView.Plant);
                    pltDeptMachDataBase.setPDM_Dept(hotListView.Dept);
                    pltDeptMachDataBase.setPDM_Mach(hotListView.Mach);
                    if (!pltDeptMachDataBase.read()){
                        PltDeptMachDataBaseContainer pltDeptMachDataBaseContainer = new PltDeptMachDataBaseContainer(dataBaseAccess);
                        pltDeptMachDataBaseContainer.readByFilters(hotListView.Mach,"", hotListView.Plant, hotListView.Dept,"",1);                        
                        if (pltDeptMachDataBaseContainer.Count > 0)
                            pltDeptMachDataBase = (PltDeptMachDataBase)pltDeptMachDataBaseContainer[0];
                    }

                    if (!string.IsNullOrEmpty(hotListView.Mach) && pltDeptMachDataBase.read()){
                
                        ireqId = pltDeptMachDataBase.getPDM_ID();
                        
                        //read part
                        ProdFmInfoDataBase prodFmInfoDataBase = prodFmInfoDataBaseContainer.getProdFmInfo(hotListView.ProdID);
                        if (prodFmInfoDataBase== null){
                            prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
		                    prodFmInfoDataBase.setPFS_ProdID(hotListView.ProdID);
                            if (prodFmInfoDataBase.read())
                                prodFmInfoDataBaseContainer.Add(prodFmInfoDataBase);
                            else
                                continue; //can not found product
                        }

                        //check if part/seq/date already added                        
                        if (scheduleHdrOld != null){
                            schedulePart = scheduleHdrOld.SchedulePartContainer.getByMachinePartSeqDate(ireqId,hotListView.ProdID, hotListView.Seq, hotListView.StartDate);
                            if (schedulePart!= null)
                                continue; //continue with next item, because already added
                        }

                        //process SchedulePart
                        schedulePart = scheduleHdr.SchedulePartContainer.getByMachinePartSeqDate(ireqId,hotListView.ProdID,hotListView.Seq,hotListView.StartDate);
                        if (schedulePart == null){                  
                            schedulePart = new SchedulePart();
                            schedulePart.Part = hotListView.ProdID;
                            schedulePart.Seq = hotListView.Seq;                            
                            schedulePart.HotListId      = hotListView.HotListIdAut;
                            schedulePart.StartDate      = hotListView.StartDate;
                            schedulePart.EndDate        = hotListView.StartDate.AddDays(7);
                            schedulePart.Priority       = 3; //urgent
                            schedulePart.MachId         = ireqId;
                            schedulePart.MachShow       = pltDeptMachDataBase.getPDM_Mach();
                            schedulePart.CapacityHdrId  = icapacityHdrId;

                            //dates from monday/sun                        
                            DateTime date1=DateTime.Now,date2=DateTime.Now;
                            DateUtil.getPriorMondayNextSundayFromDate(schedulePart.StartDate,out date1,out date2);
                            schedulePart.EndDate = date2;
                            if (DateUtil.weekNumber(schedulePart.StartDate) == DateUtil.weekNumber(DateTime.Now)){
                                schedulePart.StartDate = DateTime.Now;                            
                            }
    
                            schedulePart.IsFamily = prodFmInfoDataBase.getPFS_FamProd();
                            schedulePart.Uom = prodFmInfoDataBase.getPFS_StdPackUnit();//uom
                            if (string.IsNullOrEmpty(schedulePart.Uom))
                                schedulePart.Uom= Constants.DEFAULT_UOM;

                            if (schedulePart.IsFamily.Equals("F")) //if is family add part childs                
                                addFamilyChildParts(schedulePart);

                            decimal drunStd=0,dcavities=0; //runstd and cavities
                            getRunStdCavNumInt(scheduleHdr.Plant,schedulePart.Part, schedulePart.Seq, schedulePart.MachId,out drunStd,out dcavities);
                            schedulePart.RunStd  = drunStd;
                            schedulePart.CavityNum = dcavities;

                            scheduleHdr.SchedulePartContainer.Add(schedulePart);
                        }

                        schedulePart.Qty+= hotListView.Qty;
                        schedulePart.EndDate = schedulePart.calculateEndDataMachineBuild();
                        generateAutomaticReceiptPartMaterialConsumition(schedulePart,scheduleHdr.Plant);                        
                    }
                }
           
            }                       

            scheduleHdr.buildReqContainer();
            if (scheduleHdr.Id > 0)
                updateScheduleHdr(scheduleHdr);
            else
                writeScheduleHdr(scheduleHdr);

        } 
	    return scheduleHdr;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}

}

public
ScheduleHdr processScheduleByCapacityReportParts(int icapacityHdrId,string splant,string sdept,string srequirment,string stype, MachineContainer machineContainer,DateTime startDate,DateTime endDate,CapacityView.SORT_TYPE sortType){
    ScheduleHdr             scheduleHdr = null;
    try{
        ScheduleHdr                 scheduleHdrOld = new ScheduleHdr();   
        ScheduleHdr                 scheduleHdrAux = null;                            
        CapacityViewContainer       capacityViewContainer = new CapacityViewContainer();
        ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer = new ProdFmInfoDataBaseContainer(dataBaseAccess);

        CapacityViewPartDataBaseContainer capacityViewPartDataBaseContainer = new CapacityViewPartDataBaseContainer(dataBaseAccess);
        capacityViewPartDataBaseContainer.readForPart(icapacityHdrId,splant,sdept,srequirment,stype, machineContainer, startDate,endDate,false, sortType);
               
        foreach(CapacityViewPartDataBase capacityViewPartDataBase in capacityViewPartDataBaseContainer)
            capacityViewContainer.Add(objectDataBaseToObject(capacityViewPartDataBase));

        scheduleHdr = new ScheduleHdr();
        CapacityHdrDataBase capacityHdrDataBase = new CapacityHdrDataBase(dataBaseAccess); //read capacity hdr
        capacityHdrDataBase.setId(icapacityHdrId);
        if (capacityHdrDataBase.read())
            scheduleHdr.Plant = capacityHdrDataBase.getPlant(); //set plant

        //scheduleHdrAux = getIfAlreadyScheduled(0,icapacityHdrId);                 
        scheduleHdrAux = readScheduleHdrLast(capacityHdrDataBase.getPlant());
        if (scheduleHdrAux!= null)
            scheduleHdr = scheduleHdrAux;
        scheduleHdrOld = cloneScheduleHdr(scheduleHdr);   
       
        if (capacityViewContainer.Count > 0){
                        
            SchedulePart            schedulePart = null;        
            int                     imachId=0;

            for (int i=0; i < capacityViewContainer.Count;i++){
                CapacityViewPart capacityViewPart = (CapacityViewPart)capacityViewContainer[i];
            
                //read machine
                PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);                                        
                pltDeptMachDataBase.setPDM_Plt(capacityViewPart.Plant);
                pltDeptMachDataBase.setPDM_Dept(capacityViewPart.Dept);
                pltDeptMachDataBase.setPDM_Mach(capacityViewPart.Machine);
                if (!string.IsNullOrEmpty(capacityViewPart.Machine) && pltDeptMachDataBase.read()){
                
                    imachId = pltDeptMachDataBase.getPDM_ID();
                    
                    //read part
                    ProdFmInfoDataBase prodFmInfoDataBase = prodFmInfoDataBaseContainer.getProdFmInfo(capacityViewPart.Part);
                    if (prodFmInfoDataBase== null){
                        prodFmInfoDataBase = new ProdFmInfoDataBase(dataBaseAccess);
		                prodFmInfoDataBase.setPFS_ProdID(capacityViewPart.Part);
                        if (prodFmInfoDataBase.read())
                            prodFmInfoDataBaseContainer.Add(prodFmInfoDataBase);
                        else
                            continue; //can not found product
                    }

                    //check if part/seq/date already added                    
                    if (scheduleHdrOld != null){
                        schedulePart = scheduleHdrOld.SchedulePartContainer.getByMachinePartSeqQtyRangeDate(imachId,capacityViewPart.Part, capacityViewPart.Seq, capacityViewPart.Qty,capacityViewPart.SDate);
                        if (schedulePart!= null)
                            continue; //continue with next item, because already added
                    }

                    //process SchedulePart
                    schedulePart = scheduleHdr.SchedulePartContainer.getByMachinePartSeqDate(imachId,capacityViewPart.Part, capacityViewPart.Seq,capacityViewPart.SDate);
                    if (schedulePart == null){                  
                        schedulePart = new SchedulePart();
                        schedulePart.Part           = capacityViewPart.Part;
                        schedulePart.Seq            = capacityViewPart.Seq;
                        schedulePart.CapacityHdrId  = icapacityHdrId;
                        schedulePart.StartDate      = capacityViewPart.SDate;                        
                        schedulePart.EndDate        = capacityViewPart.SDate.AddDays(7);

                        schedulePart.MachId         = imachId;
                        schedulePart.MachShow       = pltDeptMachDataBase.getPDM_Mach();

                        //dates from monday/sun                        
                        DateTime date1=DateTime.Now,date2=DateTime.Now;
                        DateUtil.getPriorMondayNextSundayFromDate(schedulePart.StartDate,out date1,out date2);
                        schedulePart.EndDate = date2;
                        if (DateUtil.weekNumber(schedulePart.StartDate) == DateUtil.weekNumber(DateTime.Now)){
                            schedulePart.StartDate = DateTime.Now;                            
                        }
                                                
                        schedulePart.IsFamily = prodFmInfoDataBase.getPFS_FamProd();
                        schedulePart.Uom = prodFmInfoDataBase.getPFS_StdPackUnit();//uom
                        if (string.IsNullOrEmpty(schedulePart.Uom))
                            schedulePart.Uom= Constants.DEFAULT_UOM;

                        if (schedulePart.IsFamily.Equals("F")) //if is family add part childs                
                            addFamilyChildParts(schedulePart);

                        decimal drunStd=0,dcavities=0; //runstd and cavities
                        getRunStdCavNumInt(scheduleHdr.Plant,schedulePart.Part, schedulePart.Seq, schedulePart.MachId,out drunStd,out dcavities);
                        schedulePart.RunStd  = drunStd;
                        schedulePart.CavityNum = dcavities;

                        scheduleHdr.SchedulePartContainer.Add(schedulePart);
                    }

                    schedulePart.Qty+= capacityViewPart.Qty;
                    schedulePart.EndDate = schedulePart.calculateEndDataMachineBuild(); 
                    generateAutomaticReceiptPartMaterialConsumition(schedulePart,scheduleHdr.Plant);
                }
           
            }                       

            scheduleHdr.buildReqContainer();
            if (scheduleHdr.Id > 0)
                updateScheduleHdr(scheduleHdr);
            else
                writeScheduleHdr(scheduleHdr);

        } 
	    return scheduleHdr;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}

}

private
void generateAutomaticReceiptPartMaterialConsumition(SchedulePart schedulePart,string splant){
    generateAutomaticReceiptPart(schedulePart);

    BomSumContainer bomSumContainer = getSubMaterialsMainLevelAndLowerSeqButNotLowerBom(schedulePart.Part, schedulePart.Seq,splant,Constants.STRING_YES,1);    
    generateAutomaticMaterialConsumition(schedulePart, bomSumContainer);
}

/****************************************** Routing ******************************************************************/
public
Routing createRouting(){
	return new Routing();
}

public
RoutingContainer createRoutingContainer(){
	return new RoutingContainer();
}


public
bool existsRouting(string prodID, string plt, string dept, string actID, int seq, string cfg){
	try{
		ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);

		prodFmActSubDataBase.setPC_ProdID(prodID);
		prodFmActSubDataBase.setPC_Plt(plt);
		prodFmActSubDataBase.setPC_Dept(dept);
		prodFmActSubDataBase.setPC_ActID(actID);
		prodFmActSubDataBase.setPC_Seq(seq);
		prodFmActSubDataBase.setPC_Cfg(cfg);

		return prodFmActSubDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
Routing readRouting(int id){
	try{
		ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
        
        prodFmActSubDataBase.setPC_Id(id);
		if (!prodFmActSubDataBase.readById())
			return null;

		Routing routing = this.objectDataBaseToObject(prodFmActSubDataBase);
        loadRoutingChilds(routing);

		return routing;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
RoutingContainer readRoutingByFilters(string spart,string splant,string sdept,int seq,string smach,string sroutingType,bool blabToolInvolved,bool bonlyHdr,int rows){    
    try{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

        RoutingContainer                routingContainer = new RoutingContainer();
        ProdFmActSubDataBaseContainer   prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
        prodFmActSubDataBaseContainer.readByFilters(spart, splant, sdept, seq, smach, sroutingType, blabToolInvolved, rows);
                
        foreach (ProdFmActSubDataBase prodFmActSubDataBase in prodFmActSubDataBaseContainer){
            Routing routing = objectDataBaseToObject(prodFmActSubDataBase);
            if (!bonlyHdr)
                loadRoutingChilds(routing);                     
            routingContainer.Add(routing);
        }
        return routingContainer;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
}

public 
void updateRouting(Routing routing){
	try{			
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdFmActSubDataBase prodFmActSubDataBase = this.objectToObjectDataBase(routing);
		prodFmActSubDataBase.update();
        deleteRoutingChilds(routing.Id);
        writeRoutingChilds(routing);

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
void writeRouting(Routing routing){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		ProdFmActSubDataBase prodFmActSubDataBase = this.objectToObjectDataBase(routing);
		prodFmActSubDataBase.write();
		routing.Id=prodFmActSubDataBase.getPC_Id();
        writeRoutingChilds(routing);

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
void writeRoutingChilds(Routing routing){
    routing.fillRedundances();

    foreach(RoutingLabTool routingLabTool in routing.RoutingLabToolContainer){
        ProdFmactSubLabToolDataBase prodFmactSubLabToolDataBase = this.objectToObjectDataBase(routingLabTool);
        prodFmactSubLabToolDataBase.write();
    }	
}

public 
void deleteRoutingChilds(int id){
    ProdFmactSubLabToolDataBaseContainer prodFmactSubLabToolDataBaseContainer = new ProdFmactSubLabToolDataBaseContainer(dataBaseAccess);
    prodFmactSubLabToolDataBaseContainer.deleteByHdr(id);   	
}

public 
void loadRoutingChilds(Routing routing){
    ProdFmactSubLabToolDataBaseContainer prodFmactSubLabToolDataBaseContainer = new ProdFmactSubLabToolDataBaseContainer(dataBaseAccess);
    prodFmactSubLabToolDataBaseContainer.readByHdr(routing.Id);   	

    foreach(ProdFmactSubLabToolDataBase prodFmactSubLabToolDataBase in prodFmactSubLabToolDataBaseContainer)  {
        RoutingLabTool routingLabTool = objectDataBaseToObject(prodFmactSubLabToolDataBase);
        loadRoutingLabToolNameShow(routingLabTool); //load name from labourtype or tool
        routing.RoutingLabToolContainer.Add(routingLabTool);                
    }
}

public
void deleteRouting(int id){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        deleteRoutingChilds(id);
		ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
        prodFmActSubDataBase.setPC_Id(id);
        prodFmActSubDataBase.deleteById();       		

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
Routing objectDataBaseToObject(ProdFmActSubDataBase prodFmActSubDataBase){
	Routing routing = new Routing();

	routing.Id=prodFmActSubDataBase.getPC_Id();
	routing.ProdID=prodFmActSubDataBase.getPC_ProdID();
	routing.Plt=prodFmActSubDataBase.getPC_Plt();
	routing.Dept=prodFmActSubDataBase.getPC_Dept();
	routing.ActID=prodFmActSubDataBase.getPC_ActID();
	routing.Seq=prodFmActSubDataBase.getPC_Seq();
	routing.SubID=prodFmActSubDataBase.getPC_SubID();
	routing.SubIDRank=prodFmActSubDataBase.getPC_SubIDRank();
	routing.SubOrdNum=prodFmActSubDataBase.getPC_SubOrdNum();
	routing.MethodRank=prodFmActSubDataBase.getPC_MethodRank();
	routing.Cfg=prodFmActSubDataBase.getPC_Cfg();
	routing.VarFam=prodFmActSubDataBase.getPC_VarFam();
	routing.CycleTm=prodFmActSubDataBase.getPC_CycleTm();
	routing.CycleUom=prodFmActSubDataBase.getPC_CycleUom();
	routing.RunStd=prodFmActSubDataBase.getPC_RunStd();
	routing.CavityNum=prodFmActSubDataBase.getPC_CavityNum();
	routing.CavUnavail=prodFmActSubDataBase.getPC_CavUnavail();
	routing.CavAvail=prodFmActSubDataBase.getPC_CavAvail();
	routing.CycleHr=prodFmActSubDataBase.getPC_CycleHr();
	routing.BatchProc=prodFmActSubDataBase.getPC_BatchProc();
	routing.BatchTm=prodFmActSubDataBase.getPC_BatchTm();
	routing.BatchQty=prodFmActSubDataBase.getPC_BatchQty();
	routing.BatchUom=prodFmActSubDataBase.getPC_BatchUom();
	routing.RepPoint=prodFmActSubDataBase.getPC_RepPoint();
	routing.ECNCurr=prodFmActSubDataBase.getPC_ECNCurr();
	routing.YieldPer=prodFmActSubDataBase.getPC_YieldPer();
	routing.ReworkPer=prodFmActSubDataBase.getPC_ReworkPer();
	routing.SchSort1=prodFmActSubDataBase.getPC_SchSort1();
	routing.SchSort2=prodFmActSubDataBase.getPC_SchSort2();
	routing.ProdLev=prodFmActSubDataBase.getPC_ProdLev();
	routing.SubIDDes=prodFmActSubDataBase.getPC_SubIDDes();
	routing.ActType=prodFmActSubDataBase.getPC_ActType();
	routing.OneTm=prodFmActSubDataBase.getPC_OneTm();
	routing.Tm=prodFmActSubDataBase.getPC_Tm();
	routing.UseMach=prodFmActSubDataBase.getPC_UseMach();
	routing.MachCyc=prodFmActSubDataBase.getPC_MachCyc();
	routing.IndDept=prodFmActSubDataBase.getPC_IndDept();
	routing.LabOnly=prodFmActSubDataBase.getPC_LabOnly();
	routing.FamOnly=prodFmActSubDataBase.getPC_FamOnly();
	routing.QtyMen=prodFmActSubDataBase.getPC_QtyMen();
	routing.QtyMachines=prodFmActSubDataBase.getPC_QtyMachines();
    routing.RoutingType = prodFmActSubDataBase.getPC_RoutingType();
    routing.ScrapPercent= prodFmActSubDataBase.getPC_ScrapPercent();
    routing.Efficiency= prodFmActSubDataBase.getPC_Efficiency();
    routing.OptRunQty= prodFmActSubDataBase.getPC_OptRunQty();

    return routing;
}
        
private
ProdFmActSubDataBase objectToObjectDataBase(Routing routing){
	ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
	prodFmActSubDataBase.setPC_Id(routing.Id);
	prodFmActSubDataBase.setPC_ProdID(routing.ProdID);
	prodFmActSubDataBase.setPC_Plt(routing.Plt);
	prodFmActSubDataBase.setPC_Dept(routing.Dept);
	prodFmActSubDataBase.setPC_ActID(routing.ActID);
	prodFmActSubDataBase.setPC_Seq(routing.Seq);
	prodFmActSubDataBase.setPC_SubID(routing.SubID);
	prodFmActSubDataBase.setPC_SubIDRank(routing.SubIDRank);
	prodFmActSubDataBase.setPC_SubOrdNum(routing.SubOrdNum);
	prodFmActSubDataBase.setPC_MethodRank(routing.MethodRank);
	prodFmActSubDataBase.setPC_Cfg(routing.Cfg);
	prodFmActSubDataBase.setPC_VarFam(routing.VarFam);
	prodFmActSubDataBase.setPC_CycleTm(routing.CycleTm);
	prodFmActSubDataBase.setPC_CycleUom(routing.CycleUom);
	prodFmActSubDataBase.setPC_RunStd(routing.RunStd);
	prodFmActSubDataBase.setPC_CavityNum(routing.CavityNum);
	prodFmActSubDataBase.setPC_CavUnavail(routing.CavUnavail);
	prodFmActSubDataBase.setPC_CavAvail(routing.CavAvail);
	prodFmActSubDataBase.setPC_CycleHr(routing.CycleHr);
	prodFmActSubDataBase.setPC_BatchProc(routing.BatchProc);
	prodFmActSubDataBase.setPC_BatchTm(routing.BatchTm);
	prodFmActSubDataBase.setPC_BatchQty(routing.BatchQty);
	prodFmActSubDataBase.setPC_BatchUom(routing.BatchUom);
	prodFmActSubDataBase.setPC_RepPoint(routing.RepPoint);
	prodFmActSubDataBase.setPC_ECNCurr(routing.ECNCurr);
	prodFmActSubDataBase.setPC_YieldPer(routing.YieldPer);
	prodFmActSubDataBase.setPC_ReworkPer(routing.ReworkPer);
	prodFmActSubDataBase.setPC_SchSort1(routing.SchSort1);
	prodFmActSubDataBase.setPC_SchSort2(routing.SchSort2);
	prodFmActSubDataBase.setPC_ProdLev(routing.ProdLev);
	prodFmActSubDataBase.setPC_SubIDDes(routing.SubIDDes);
	prodFmActSubDataBase.setPC_ActType(routing.ActType);
	prodFmActSubDataBase.setPC_OneTm(routing.OneTm);
	prodFmActSubDataBase.setPC_Tm(routing.Tm);
	prodFmActSubDataBase.setPC_UseMach(routing.UseMach);
	prodFmActSubDataBase.setPC_MachCyc(routing.MachCyc);
	prodFmActSubDataBase.setPC_IndDept(routing.IndDept);
	prodFmActSubDataBase.setPC_LabOnly(routing.LabOnly);
	prodFmActSubDataBase.setPC_FamOnly(routing.FamOnly);
	prodFmActSubDataBase.setPC_QtyMen(routing.QtyMen);
	prodFmActSubDataBase.setPC_QtyMachines(routing.QtyMachines);
    prodFmActSubDataBase.setPC_RoutingType(routing.RoutingType);
    prodFmActSubDataBase.setPC_ScrapPercent(routing.ScrapPercent);
    prodFmActSubDataBase.setPC_Efficiency(routing.Efficiency);
    prodFmActSubDataBase.setPC_OptRunQty(routing.OptRunQty);

	return prodFmActSubDataBase;
}

public
Routing cloneRouting(Routing routing){
	Routing routingClone = new Routing();

	routingClone.Id=routing.Id;
	routingClone.ProdID=routing.ProdID;
	routingClone.Plt=routing.Plt;
	routingClone.Dept=routing.Dept;
	routingClone.ActID=routing.ActID;
	routingClone.Seq=routing.Seq;
	routingClone.SubID=routing.SubID;
	routingClone.SubIDRank=routing.SubIDRank;
	routingClone.SubOrdNum=routing.SubOrdNum;
	routingClone.MethodRank=routing.MethodRank;
	routingClone.Cfg=routing.Cfg;
	routingClone.VarFam=routing.VarFam;
	routingClone.CycleTm=routing.CycleTm;
	routingClone.CycleUom=routing.CycleUom;
	routingClone.RunStd=routing.RunStd;
	routingClone.CavityNum=routing.CavityNum;
	routingClone.CavUnavail=routing.CavUnavail;
	routingClone.CavAvail=routing.CavAvail;
	routingClone.CycleHr=routing.CycleHr;
	routingClone.BatchProc=routing.BatchProc;
	routingClone.BatchTm=routing.BatchTm;
	routingClone.BatchQty=routing.BatchQty;
	routingClone.BatchUom=routing.BatchUom;
	routingClone.RepPoint=routing.RepPoint;
	routingClone.ECNCurr=routing.ECNCurr;
	routingClone.YieldPer=routing.YieldPer;
	routingClone.ReworkPer=routing.ReworkPer;
	routingClone.SchSort1=routing.SchSort1;
	routingClone.SchSort2=routing.SchSort2;
	routingClone.ProdLev=routing.ProdLev;
	routingClone.SubIDDes=routing.SubIDDes;
	routingClone.ActType=routing.ActType;
	routingClone.OneTm=routing.OneTm;
	routingClone.Tm=routing.Tm;
	routingClone.UseMach=routing.UseMach;
	routingClone.MachCyc=routing.MachCyc;
	routingClone.IndDept=routing.IndDept;
	routingClone.LabOnly=routing.LabOnly;
	routingClone.FamOnly=routing.FamOnly;
	routingClone.QtyMen=routing.QtyMen;
	routingClone.QtyMachines=routing.QtyMachines;
    routingClone.MachIdShow = routing.MachIdShow;
    routingClone.RoutingType = routing.RoutingType;
    routingClone.ScrapPercent= routing.ScrapPercent;
    routingClone.Efficiency= routing.Efficiency;
    routingClone.OptRunQty = routing.OptRunQty;

	return routingClone;
}

public
RoutingLabTool createRoutingLabTool(){
	return new RoutingLabTool();
}

public
RoutingLabToolContainer createRoutingLabToolContainer(){
	return new RoutingLabToolContainer();
}

private
RoutingLabTool objectDataBaseToObject(ProdFmactSubLabToolDataBase prodFmactSubLabToolDataBase){
	RoutingLabTool routingLabTool = new RoutingLabTool();

	routingLabTool.Id=prodFmactSubLabToolDataBase.getId();
	routingLabTool.HdrId=prodFmactSubLabToolDataBase.getHdrId();
	routingLabTool.Detail=prodFmactSubLabToolDataBase.getDetail();
	routingLabTool.Type=prodFmactSubLabToolDataBase.getType();
	routingLabTool.ReqId=prodFmactSubLabToolDataBase.getReqId();
	routingLabTool.TotEmployees=prodFmactSubLabToolDataBase.getTotEmployees();

	return routingLabTool;
}

private
ProdFmactSubLabToolDataBase objectToObjectDataBase(RoutingLabTool routingLabTool){
	ProdFmactSubLabToolDataBase prodFmactSubLabToolDataBase = new ProdFmactSubLabToolDataBase(dataBaseAccess);
	prodFmactSubLabToolDataBase.setId(routingLabTool.Id);
	prodFmactSubLabToolDataBase.setHdrId(routingLabTool.HdrId);
	prodFmactSubLabToolDataBase.setDetail(routingLabTool.Detail);
	prodFmactSubLabToolDataBase.setType(routingLabTool.Type);
	prodFmactSubLabToolDataBase.setReqId(routingLabTool.ReqId);
	prodFmactSubLabToolDataBase.setTotEmployees(routingLabTool.TotEmployees);

	return prodFmactSubLabToolDataBase;
}

public
RoutingLabTool cloneRoutingLabTool(RoutingLabTool routingLabTool){
	RoutingLabTool routingLabToolClone = new RoutingLabTool();
    routingLabToolClone.copy(routingLabTool);
	
	return routingLabToolClone;
}

public
void loadRoutingLabToolNameShow(RoutingLabTool routingLabTool){
    string saux="";
	
    switch (routingLabTool.Type){
        case RoutingLabTool.LABOUR_TYPE:
            /*
            LabourTypeDataBase labourTypeDataBase = new LabourTypeDataBase(dataBaseAccess);
            labourTypeDataBase.setId(routingLabTool.ReqId);
            if (labourTypeDataBase.read())
                saux= labourTypeDataBase.getLabName();
            */
            CapShiftTaskDataBase capShiftTaskDataBase = new CapShiftTaskDataBase(dataBaseAccess);
            capShiftTaskDataBase.setId(routingLabTool.ReqId);
            if (capShiftTaskDataBase.read())
                saux= capShiftTaskDataBase.getTaskName();
            break;
        case RoutingLabTool.TOOL_TYPE:
            PdToolDataBase pdToolDataBase = new PdToolDataBase(dataBaseAccess);
            pdToolDataBase.setTOO_ID(routingLabTool.ReqId);
            if (pdToolDataBase.readById())
                saux= pdToolDataBase.getTOO_Desc1();
            break;
    }	
    routingLabTool.NameShow = saux;
}

/****************************************** LabourType ******************************************************************/
/*
public
LabourType createLabourType(){
	return new LabourType();
}

public
LabourTypeContainer createLabourTypeContainer(){
	return new LabourTypeContainer();
}
*/
public
LabourTypeRequired createLabourTypeRequired(){
	return new LabourTypeRequired();
}

public
LabourTypeRequiredContainer createLabourTypeRequiredContainer(){
	return new LabourTypeRequiredContainer();
}

/*
public
bool existsLabourType(int id){
	try{
		LabourTypeDataBase labourTypeDataBase = new LabourTypeDataBase(dataBaseAccess);

		labourTypeDataBase.setId(id);

		return labourTypeDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
LabourType readLabourType(int id){
	try{
		LabourTypeDataBase labourTypeDataBase = new LabourTypeDataBase(dataBaseAccess);
		labourTypeDataBase.setId(id);

		if (!labourTypeDataBase.read())
			return null;

		LabourType labourType = this.objectDataBaseToObject(labourTypeDataBase);

		return labourType;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateLabourType(LabourType labourType){
	try{
        if (!userHandleTransaction)
            dataBaseAccess.beginTransaction();

        LabourTypeDataBase labourTypeDataBase = this.objectToObjectDataBase(labourType);
		labourTypeDataBase.update();

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
void writeLabourType(LabourType labourType){
	try{
		if (!userHandleTransaction)
            dataBaseAccess.beginTransaction();

		LabourTypeDataBase labourTypeDataBase = this.objectToObjectDataBase(labourType);
		labourTypeDataBase.write();

		labourType.Id=labourTypeDataBase.getId();

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
void deleteLabourType(int id){
	try{
		if (!userHandleTransaction)
            dataBaseAccess.beginTransaction();

		LabourTypeDataBase labourTypeDataBase = new LabourTypeDataBase(dataBaseAccess);

		labourTypeDataBase.setId(id);
		labourTypeDataBase.delete();

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
LabourTypeContainer readLabourTypeByFilters(string scode,string slabName,string sdirInd,int rows){    
    try{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

        LabourTypeContainer             labourTypeContainer = new LabourTypeContainer();
        LabourTypeDataBaseContainer     labourTypeDataBaseContainer = new LabourTypeDataBaseContainer(dataBaseAccess);
        labourTypeDataBaseContainer.readByFilters(scode, slabName, sdirInd, rows);
                
        foreach (LabourTypeDataBase labourTypeDataBase in labourTypeDataBaseContainer)
            labourTypeContainer.Add(objectDataBaseToObject(labourTypeDataBase));
            
        return labourTypeContainer;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
}

private
LabourType objectDataBaseToObject(LabourTypeDataBase labourTypeDataBase){
	LabourType labourType = new LabourType();

	labourType.Id=labourTypeDataBase.getId();
	labourType.Code=labourTypeDataBase.getCode();
	labourType.LabName=labourTypeDataBase.getLabName();
	labourType.DirInd=labourTypeDataBase.getDirInd();

	return labourType;
}

private
LabourTypeDataBase objectToObjectDataBase(LabourType labourType){
	LabourTypeDataBase labourTypeDataBase = new LabourTypeDataBase(dataBaseAccess);
	labourTypeDataBase.setId(labourType.Id);
	labourTypeDataBase.setCode(labourType.Code);
	labourTypeDataBase.setLabName(labourType.LabName);
	labourTypeDataBase.setDirInd(labourType.DirInd);

	return labourTypeDataBase;
}

public
LabourType cloneLabourType(LabourType labourType){
	LabourType labourTypeClone = new LabourType();
    labourTypeClone.copy(labourType);	
	return labourTypeClone;
}
*/

public
string[][] readToolByFilters(string scompany,string splant,string stoolNumber, string sdesc1,int rows){    
    try{
        PdToolDataBaseContainer pdToolDataBaseContainer = new PdToolDataBaseContainer(dataBaseAccess);
        pdToolDataBaseContainer.readByFilters(scompany, splant, stoolNumber, sdesc1, rows);

        string[][]  items = new string[pdToolDataBaseContainer.Count][];                
        string[]    item = null;
        int         i=0;
        foreach (PdToolDataBase pdToolDataBase in pdToolDataBaseContainer){
            item = new string[8];
            item[0] = pdToolDataBase.getTOO_ID().ToString();
            item[1] = pdToolDataBase.getTOO_Db();
            item[2] = pdToolDataBase.getTOO_Company();
            item[3] = pdToolDataBase.getTOO_Plant();
            item[4] = pdToolDataBase.getTOO_ToolNumber();
            item[5] = pdToolDataBase.getTOO_Desc1();
            item[6] = pdToolDataBase.getTOO_Desc2();
            item[7] = pdToolDataBase.getTOO_Desc3();

            items[i] = item;
            i++;            
        }       

        return items;

	}catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
}

private
string[] initArray(string stype,int ireqID,string sreqDesc,string splant,string sdept){
    string[] lineArray = new string[Constants.INDEX_HOTLIST_MAX];
    for (int i=0; i < lineArray.Length;i++)         //initialize array
        lineArray[i] =decimal.Floor(0).ToString();

    lineArray[0] = stype;
    lineArray[1] = ireqID.ToString();
    lineArray[2] = sreqDesc;
    lineArray[3] = !string.IsNullOrEmpty(sdept) ? splant + '\\' + sdept : "";    

    return lineArray;
}

private
string[][] initArrays(string stype,int ireqID,string sreqDesc,string splant,string sdept){
    string[][] lineArrays = new string[5][];
    
    lineArrays[0] = initArray(stype, ireqID, sreqDesc,splant,sdept); //hotlist qty
    lineArrays[1] = initArray(stype, ireqID, sreqDesc, "", ""); //might be tot labour

    lineArrays[2] = initArray(stype, ireqID, sreqDesc, "", ""); //shift 1
    lineArrays[2][2] = "Sh 1";
    lineArrays[3] = initArray(stype, ireqID, sreqDesc, "", ""); //shift 2
    lineArrays[3][2] = "Sh 2";
    lineArrays[4] = initArray(stype, ireqID, sreqDesc, "", ""); //shift 3
    lineArrays[4][2] = "Sh 3";

    for (int i=1; i < lineArrays.Length;i++)
        lineArrays[i][0] = lineArrays[i][1] = "";

    return lineArrays;
}

private
string[][] getArraysNew(Hashtable hashHdrLabourType,string stype,int ireqID,string sreqDesc,string splant,string sdept){
    string[][]  linesArrayNew = null;
    string      skey = splant + Constants.DEFAULT_SEP + sdept + Constants.DEFAULT_SEP + stype + Constants.DEFAULT_SEP + ireqID.ToString();

    if (hashHdrLabourType.ContainsKey(skey))
        linesArrayNew = (string[][])hashHdrLabourType[skey];
    else{
        linesArrayNew = initArrays(stype,ireqID,sreqDesc,splant,sdept);
        hashHdrLabourType.Add(skey, linesArrayNew);
    }
    return linesArrayNew;
}
        /*
private
LabourType fillLabourTypeDesc(string[] lineArrayNew,int ireqId,LabourTypeContainer labourTypeContainer){
    LabourType labourType = labourTypeContainer.getByKey(ireqId);

    if (labourType==null)  {              

    }
}*/

public 
string[][] getHotListLabourType(int id,string splantHotList,string splant,string sdept,string smachine,int imachineId,string spart,int iseq,string sglExp,string sreportedPoint,bool borderByDemand,bool bgetCumulativeQty, bool baddReceipParts,bool baddMaterialConsumPart,int rows){

	try{
        DateTime            runDate = DateUtil.MinValue;
        HotListHdrDataBase  hotListHdrDataBase = new HotListHdrDataBase(dataBaseAccess);
        Hashtable           hashHdrLabourType = new Hashtable();
        Hashtable           hashHdrScheduleLabourType = new Hashtable();
        DateTime            currentDate = DateTime.Now;
        MachineContainer    machineContainer = new MachineContainer();
        Machine             machine = null;
        int                 ischeduleId=0;
        DateTime            fromDate= DateTime.Now , toDate = DateTime.Now;
        string[][]          linesArrayNew = null;
        string[]            lineArrayNew = null;        
        RoutingContainer    routingContainer = new RoutingContainer();
        Routing             routing = null;            
        int                 i = 0;
        ScheduleHdr         scheduleHdr= new ScheduleHdr();
        ScheduleReceiptPart             scheduleReceiptPart= null;
        ScheduleReceiptPartContainer    scheduleReceiptPartContainer = new ScheduleReceiptPartContainer();
        string[][]          hitems = new string[0][];        
                                    
        if (id == 0) // We get the last hotList, if returns 0 there are not hotHotlist record generated			 
            id = hotListHdrDataBase.readLastIdByPlant(splantHotList);            
                
        hotListHdrDataBase.setId(id);
        if (!hotListHdrDataBase.read())                
            return hitems; //can not found hot list
        runDate = hotListHdrDataBase.getHLR_HotlistRunDate();

        fromDate= new DateTime(runDate.AddDays(-1).Year, runDate.AddDays(-1).Month, runDate.AddDays(-1).Day,0,0,0);
        toDate  = new DateTime(runDate.AddDays(90).Year, runDate.AddDays(90).Month, runDate.AddDays(90).Day,23,59,59); //last day from hotlist   

        //read last shedule
        ScheduleHdrDataBase scheduleHdrDataBase = new ScheduleHdrDataBase(dataBaseAccess);
        if (scheduleHdrDataBase.readLastByFilter(splantHotList)){ 
            ischeduleId = scheduleHdrDataBase.getId();
            scheduleHdr = readScheduleHdr(ischeduleId);
        }

        hitems = getHotListAsStringNew(id, splantHotList, splant, sdept, smachine, imachineId, spart, iseq,sglExp,sreportedPoint,"",0,borderByDemand, false,false,baddReceipParts, baddMaterialConsumPart, rows);
        string[]    lineArray = null;

        for (i=0; i < hitems.Length;i++){
            lineArray = hitems[i];

            string  sdeptH  =  lineArray[0];
			string  spartH  =  lineArray[4];
			int     iseqH   = Convert.ToInt32(lineArray[5]);
            string  smachH  = lineArray[7];
            decimal runStdH = Convert.ToDecimal(lineArray[8]);
			string  splantH = lineArray[106];
            decimal dqty    = 0;
            decimal dtotEmpl=0;                      

            machine = machineContainer.getByKey(splantH, sdeptH,smachH);//get machine
            if (machine==null){
                machine = readMachine(splantH, sdeptH, smachH);                
                if (machine!=null)
                    machineContainer.Add(machine);
            }

            routing = null;
            routingContainer = readRoutingByFilters(spartH,splantH, sdeptH,iseqH, smachH,Routing.ROUTING_TYPE_MAIN,false,false,1);//get routing
            if (routingContainer.Count > 0)
                routing = routingContainer[0];

            if (machine != null && routing!=null){
                
                scheduleReceiptPartContainer = getScheduleReceiptParts(scheduleHdr, machine.Id, spartH, iseqH);
                //scheduleReceiptPartContainer = getReceiptPartByFilters(ischeduleId, CapacityReq.REQUIREMENT_MACHINE, machine.Id, spartH, iseqH, fromDate, toDate);

                for (int j= Constants.INDEX_HOTLIST_START_PASTUE; routing!= null && j < (lineArray.Length-2);j++){ //-2 because last 2 values, related to HotID/Plant
                    currentDate = runDate.AddDays(j- (Constants.INDEX_HOTLIST_START_PASTUE + 1));
                    dqty =  Convert.ToDecimal(lineArray[j]);
                    dqty =  dqty < 0 ? Math.Abs(dqty) : 0;      //only searching when negative qty

                    for (int h=0; h < routing.RoutingLabToolContainer.Count;h++) {
                        RoutingLabTool routingLabTool = routing.RoutingLabToolContainer[h];
                        if (!routingLabTool.Type.Equals(RoutingLabTool.LABOUR_TYPE))
                            continue;

                        if (dqty!= 0){
                            dtotEmpl = (dqty /  (runStdH ==0? 1: runStdH)) * routingLabTool.TotEmployees;

                            linesArrayNew = getArraysNew(hashHdrLabourType, routingLabTool.Type,routingLabTool.ReqId, routingLabTool.NameShow,splantH,sdeptH);                   

                            //hotlist
                            lineArrayNew = linesArrayNew[0];
                            lineArrayNew[j] =(Convert.ToDecimal(lineArrayNew[j]) + dqty).ToString("0.00");

                            //labour type
                            lineArrayNew = linesArrayNew[1];         
                            if (Convert.ToDecimal(lineArrayNew[j]) > 0)
                                lineArrayNew[j] = lineArrayNew[j];
                            lineArrayNew[j] = (Convert.ToDecimal(lineArrayNew[j]) + dtotEmpl).ToString("0.00"); //summarize
                        }                        

                        //process schedule records , one line per shift
                        for (int ishift=1; ishift <=3; ishift++){
                            scheduleReceiptPart = scheduleReceiptPartContainer.getSummarizedByPartSeqByDate("",0,currentDate,ishift);
                            if (scheduleReceiptPart!=null){
                                linesArrayNew = getArraysNew(hashHdrLabourType, routingLabTool.Type, routingLabTool.ReqId, routingLabTool.NameShow,splantH, sdeptH);
                                lineArrayNew = linesArrayNew[1+ishift];

                                dtotEmpl = ( (scheduleReceiptPart.RecQty- scheduleReceiptPart.RepQty) / (runStdH == 0 ? 1 : runStdH)) * routingLabTool.TotEmployees;
                                lineArrayNew[j] =(Convert.ToDecimal(lineArrayNew[j]) + dtotEmpl).ToString("0.00");
                            }
                        }
                    }
                }                                        
            }
        }

        hitems =  loadSortLabourTypeHash(hashHdrLabourType);

        return hitems;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}      
} 

private
 string[][] loadSortLabourTypeHash(Hashtable hashtable){
    string[][]      hitems = new string[0][];
    string[][]      linesArrayNew = new string[0][];
    int             i=0;                                
    ArrayList       arrayList = new ArrayList();    
    string          sdept="";

    foreach (DictionaryEntry entry in hashtable)
        arrayList.Add(entry);
    arrayList.Sort(new LabourTypeDeptComparer());

    hitems = new string[arrayList.Count*5][]; //5 lines per item
    i=0;        
    foreach( DictionaryEntry de in arrayList){
        linesArrayNew=(string[][])de.Value;       
               
        for (int j=0; j < linesArrayNew.Length;j++,i++)   {                    
            hitems[i] = linesArrayNew[j];

            if ( j==0 ) {   //to not repeat department
                if (!linesArrayNew[j][3].Equals(sdept))
                    sdept = linesArrayNew[j][3];
                else
                    linesArrayNew[j][3] = "";
            }           
        }            
    }

    return hitems;
} 

private
ScheduleReceiptPartContainer getScheduleReceiptParts(ScheduleHdr scheduleHdr,int imachineId,string spart,int seq){    
    SchedulePart                    schedulePart = null;
    ScheduleReceiptPartContainer    scheduleReceiptPartContainer = new ScheduleReceiptPartContainer();

    scheduleReceiptPartContainer = new ScheduleReceiptPartContainer();
    if (scheduleHdr != null){

        for (int i=0; i < scheduleHdr.SchedulePartContainer.Count; i++){
            schedulePart = scheduleHdr.SchedulePartContainer[i];

            if (schedulePart.MachId == imachineId && schedulePart.Part.ToUpper().Equals(spart.ToUpper()) && schedulePart.Seq == seq){
                foreach(ScheduleReceiptPart scheduleReceiptPart in schedulePart.ScheduleReceiptPartContainer)
                    scheduleReceiptPartContainer.Add(scheduleReceiptPart);
            }
        }
    }

    return scheduleReceiptPartContainer;
}

private
class LabourTypeDeptComparer : IComparer{

    public int Compare(object x, object y){
        if ((x is DictionaryEntry) && (y is DictionaryEntry)){
            DictionaryEntry v1 = (DictionaryEntry)x;
            DictionaryEntry v2 = (DictionaryEntry)y;

            string saux1 = (string)v1.Key;
            string saux2 = (string)v2.Key;
            return saux1.CompareTo(saux2);
        }else
            return -1;
    }
}

public
LabourTypeRequiredContainer getHotListLabourType2(Hashtable hashMachines,Hashtable hashRoutings,Hashtable hashTasks,ScheduleHdr scheduleHdrFilter,int id,string splantHotList,string splant,string sdept,string smachine,int imachineId,string spart,int iseq,string sglExp,string sreportedPoint,string sprodFamily,bool borderByDemand,bool bgetCumulativeQty, bool baddReceipParts,bool baddMaterialConsumPart,int rows){

	try{
        LabourTypeRequiredContainer     labourTypeRequiredContainer = new LabourTypeRequiredContainer();
        LabourTypeRequired              labourTypeRequired = null;

        HotListContainer                hotListContainer= new HotListContainer();

        DateTime                        runDate = DateUtil.MinValue;
        HotListHdrDataBase              hotListHdrDataBase = new HotListHdrDataBase(dataBaseAccess);        
        Hashtable                       hashHdrLabourType = new Hashtable();
        Hashtable                       hashHdrScheduleLabourType = new Hashtable();
        DateTime                        currentDate = DateTime.Now;                
        DateTime                        fromDate= DateTime.Now , toDate = DateTime.Now;        
        RoutingContainer                routingContainer = new RoutingContainer();
        Routing                         routing = null;            
        int                             i = 0;
        ScheduleHdr                     scheduleHdr= scheduleHdrFilter!= null ? scheduleHdrFilter : new ScheduleHdr();        
        ScheduleReceiptPartContainer    scheduleReceiptPartContainer = new ScheduleReceiptPartContainer();                
        ScheduleReceiptPart             scheduleReceiptPart= null;
        PltDeptMachDataBase             pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
        bool                            ballRoutingWithLabourLoaded=false;
        CapShiftTask                    capShiftTask = null;
        Hashtable                       hashScheduleReceiptParts = new Hashtable();
                                            
        if (id == 0) // We get the last hotList, if returns 0 there are not hotHotlist record generated			 
            id = hotListHdrDataBase.readLastIdByPlant(splantHotList);            
                
        hotListHdrDataBase.setId(id);
        if (!hotListHdrDataBase.read())                
            return labourTypeRequiredContainer; //can not found hot list
        runDate = hotListHdrDataBase.getHLR_HotlistRunDate();

        fromDate= new DateTime(runDate.AddDays(-1).Year, runDate.AddDays(-1).Month, runDate.AddDays(-1).Day,0,0,0);
        toDate  = new DateTime(runDate.AddDays(90).Year, runDate.AddDays(90).Month, runDate.AddDays(90).Day,23,59,59); //last day from hotlist   

        //read last shedule
        scheduleHdr = readScheduleHdrLastDateCheck(scheduleHdr,splantHotList);
               
        if (hashMachines.Count < 1 && imachineId ==0)
            loadAllMachines(hashMachines);
        
        //if (imachineId ==0)
           // hashRoutings.Clear(); //for now always trying to load routings
        if (hashRoutings.Count < 1 && imachineId ==0){
            loadAllRoutingsWtihLabourTool(hashRoutings,"");
            ballRoutingWithLabourLoaded=true;
        }
        
        hotListContainer = getHotListAsStringNew2(id, splantHotList, splant, sdept, smachine, imachineId, spart, iseq,"",sglExp,sreportedPoint, sprodFamily, borderByDemand, false, baddReceipParts, baddMaterialConsumPart, rows);
        
        for (i=0; i < hotListContainer.Count;i++){
            HotList hotList = hotListContainer[i];

            string  sdeptH  = hotList.Dept;
			string  spartH  = hotList.ProdID;
			int     iseqH   = hotList.Seq;
            string  smachH  = hotList.Mach;
            decimal runStdH = hotList.MachCyc;
			string  splantH = hotList.Plt;
            decimal dqty    = 0;
            decimal dtotEmployees = 0;
            
            pltDeptMachDataBase = null;
            routing = null;
            if (!string.IsNullOrEmpty(smachH)) { 
                pltDeptMachDataBase = getHashMachine(hashMachines,splantH, sdeptH, smachH);
                if (ballRoutingWithLabourLoaded)    routing = getRoutingHash(hashRoutings,spartH,iseqH,splantH,sdeptH,smachH);                
                else                                routing = getRouting(hashRoutings,spartH,iseqH,splantH,sdeptH,smachH);                
            }
                       
            if (pltDeptMachDataBase != null && routing!=null && routing.RoutingLabToolContainer.Count > 0){
                
                //scheduleReceiptPartContainer = getScheduleReceiptParts(scheduleHdr, pltDeptMachDataBase.getPDM_ID(), spartH, iseqH);

                HotListDayContainer hotListDayContainer = hotList.getQtyDatesNonZero(runDate);                                
                foreach( HotListDay hotListDay in hotListDayContainer) {
                    currentDate = hotListDay.DateTime;
                    dqty = hotListDay.Qty;                               
                    dqty =  dqty < 0 ? Math.Abs(dqty) : 0;      //only searching when negative qty

                    for (int h=0; dqty != 0 && h < routing.RoutingLabToolContainer.Count;h++) {
                        RoutingLabTool routingLabTool = routing.RoutingLabToolContainer[h];
                        if (routingLabTool.Type.Equals(RoutingLabTool.LABOUR_TYPE)) {   //process if labour

                            labourTypeRequired = labourTypeRequiredContainer.getByKey(routingLabTool.ReqId);
                            if (labourTypeRequired == null){
                                labourTypeRequired = new LabourTypeRequired();
                            
                          	    labourTypeRequired.Id = routingLabTool.ReqId;	                        
                                capShiftTask = getTaskHash(hashTasks,routingLabTool.ReqId);//get labour task                                    
                                labourTypeRequired.Code     = capShiftTask!= null ? capShiftTask.Id.ToString() : "";
	                            labourTypeRequired.LabName  = capShiftTask!= null ? capShiftTask.TaskName : "";
	                            labourTypeRequired.DirInd   = capShiftTask!= null ? capShiftTask.DirInd : "";

                                labourTypeRequiredContainer.Add(labourTypeRequired);
                            }                                                    
                            dtotEmployees = (dqty /  (runStdH ==0? 1: runStdH)) * routingLabTool.TotEmployees;   //calc employees involved                     
                            labourTypeRequired.setSummarizeQtyByDate(runDate,currentDate, dtotEmployees);                        
                        }
                    }
                }                                        
            }
        }
        
        return labourTypeRequiredContainer;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}      
} 

private
LabourPlanningReportView getLabourPlanningReportView(LabourPlanningReportViewContainer labourPlanningReportViewContainer,CapShiftTask capShiftTask,string stype,int ireqId){
    LabourPlanningReportView labourPlanningReportView =labourPlanningReportViewContainer.getByKey(stype,ireqId);     
    
    if (capShiftTask!= null && labourPlanningReportView == null) {                
        labourPlanningReportView = new LabourPlanningReportView();
        labourPlanningReportView.ReqId  = ireqId;
        labourPlanningReportView.ReqType= stype;                        
        labourPlanningReportView.Labour = capShiftTask != null? capShiftTask.Id.ToString() :"";
        labourPlanningReportView.LabName= capShiftTask != null? capShiftTask.TaskName : "";                    
        labourPlanningReportView.DirInd = capShiftTask != null? capShiftTask.DirInd : "";                    
        labourPlanningReportViewContainer.Add(labourPlanningReportView);                                                                                                
    }
    return labourPlanningReportView;
} 

private
void getPlannedLabourTypeProcessLabour( LabourPlanningReportViewContainer labourPlanningReportViewContainer,
                                        Hashtable hashTasks,PlannedReq plannedReq,bool bgenericShiftNum){
    CapShiftTask                capShiftTask=null;
    LabourPlanningReportView    labourPlanningReportView= null;
    CellPlanningLabType         cellPlanningLabType = null;

    for (int j = 0; j < plannedReq.PlannedLabourContainer.Count; j++) {
        PlannedLabour plannedLabour = plannedReq.PlannedLabourContainer[j];

        if (( bgenericShiftNum && plannedLabour.ShiftNum ==0) || (!bgenericShiftNum && plannedLabour.ShiftNum != 0)){ 

            capShiftTask = getTaskHash(hashTasks,plannedLabour.LabourTypeId);

            labourPlanningReportView = getLabourPlanningReportView(labourPlanningReportViewContainer,capShiftTask,Constants.TYPE_LABOUR,plannedLabour.LabourTypeId);
            if (labourPlanningReportView != null) {

                cellPlanningLabType = labourPlanningReportView.getCellWeekByDate(plannedLabour.StartDate, plannedLabour.EndDate, false);
                if (cellPlanningLabType!= null) { 
                    //cellPlanningLabType.Planned +=  plannedLabour.TotEmployPlan;
                    cellPlanningLabType.Overtime+=  plannedLabour.TotEmployOver;
                    cellPlanningLabType.Temp    +=  plannedLabour.TotEmployTemp;

                    cellPlanningLabType.NewHire +=  plannedLabour.TotEmployHire;
                    cellPlanningLabType.SickAbsent+=plannedLabour.TotEmployAbsent;
                    cellPlanningLabType.Vacation+=  plannedLabour.TotEmployVacation;

                    cellPlanningLabType.PlannedLabourContainer.Add(plannedLabour);
                }                        
            }   
        }
    }   

}

public
LabourPlanningReportViewContainer getPlannedLabourType(LabourPlanningReportViewContainer labourPlanningReportViewContainer, PlannedHdr plannedHdrFilter ,Hashtable hashMachinesById,Hashtable hashRoutings,Hashtable hashTasks,string splant,string sdept,int imachineId,string spart,int iseq,string sreportedPoint,bool bgenericShiftNum,int rows){

	try{        
        PlannedHdr                      plannedHdr = readPlannedHdrLastDateCheck(plannedHdrFilter,splant);
        PlannedReq                      plannedReq = null;
        LabourPlanningReportView        labourPlanningReportView = null;
        LabourPlanningReportView        labourPlanningReportViewAux = new LabourPlanningReportView(); //jut to check if on date range
        Hashtable                       hashHdrLabourType = new Hashtable();
        Hashtable                       hashHdrScheduleLabourType = new Hashtable();
        DateTime                        currentDate = DateTime.Now;                
        DateTime                        fromDate= DateTime.Now , toDate = DateTime.Now;        
        RoutingContainer                routingContainer = new RoutingContainer();
        Routing                         routing = null;            
        int                             i = 0;        
        PltDeptMachDataBase             pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
        bool                            ballRoutingWithLabourLoaded=false;
        CapShiftTask                    capShiftTask = null;
        CellPlanningLabType             cellPlanningLabType = null;
        
        if (hashMachinesById.Count < 1 && imachineId ==0)
            loadAllMachinesById(hashMachinesById);
        
        if (hashRoutings.Count < 1 && imachineId ==0){
            loadAllRoutingsWtihLabourTool(hashRoutings,"");
            ballRoutingWithLabourLoaded=true;
        }        
                
        for (i=0; i < plannedHdr.PlannedReqContainer.Count;i++){                                
            plannedReq = plannedHdr.PlannedReqContainer[i];

            //checking filters
            if (imachineId != 0 && (!plannedReq.Type.Equals(Constants.TYPE_MACHINE) || (plannedReq.Type.Equals(Constants.TYPE_MACHINE) && imachineId != plannedReq.ReqID)))
                continue;

            if (plannedReq.Type.Equals(Constants.TYPE_LABOUR)) {        //labour type           

                getPlannedLabourTypeProcessLabour(labourPlanningReportViewContainer, hashTasks, plannedReq,bgenericShiftNum);
                
            }else if (plannedReq.Type.Equals(Constants.TYPE_MACHINE)) { //machine type           
                
                getPlannedLabourTypeProcessLabour(labourPlanningReportViewContainer, hashTasks, plannedReq,bgenericShiftNum);
                             
                for (int j = 0; j < plannedReq.PlannedPartContainer.Count; j++) {
                    PlannedPart         plannedPart = plannedReq.PlannedPartContainer[j];
                    cellPlanningLabType = labourPlanningReportViewAux.getCellWeekByDate(plannedPart.StartDate,plannedPart.EndDate,false);
                         
                    pltDeptMachDataBase = getMachineById(hashMachinesById, plannedReq.ReqID);
                    if (cellPlanningLabType!= null && pltDeptMachDataBase != null) { 

                        string splantH  = pltDeptMachDataBase.getPDM_Plt();
                        string sdeptH   = pltDeptMachDataBase.getPDM_Dept();
                        string smachH   = pltDeptMachDataBase.getPDM_Mach();
                        string spartH   = plannedPart.Part;
                        int     iseqH   = plannedPart.Seq;
                        decimal runStdH = 0;
                        decimal dqty    = plannedPart.QtyPlanned;
                        
                        if (ballRoutingWithLabourLoaded) routing = getRoutingHash(hashRoutings, spartH, iseqH, splantH, sdeptH, smachH);
                        else routing = getRouting(hashRoutings, spartH, iseqH, splantH, sdeptH, smachH);

                        if (routing != null && routing.RoutingLabToolContainer.Count > 0) {
                            runStdH = routing.RunStd;                            
                                                        
                            for (int h = 0; dqty != 0 && cellPlanningLabType != null && h < routing.RoutingLabToolContainer.Count; h++){
                                RoutingLabTool routingLabTool = routing.RoutingLabToolContainer[h];

                                if (routingLabTool.Type.Equals(RoutingLabTool.LABOUR_TYPE)) {   //process if labour                                    

                                    capShiftTask = getTaskHash(hashTasks,routingLabTool.ReqId);//get labour task
                                    if (capShiftTask!= null) {                                         
                                        labourPlanningReportView = getLabourPlanningReportView(labourPlanningReportViewContainer,capShiftTask,Constants.TYPE_LABOUR, routingLabTool.ReqId);                                        
                                        if (labourPlanningReportView != null) {
                                            cellPlanningLabType = labourPlanningReportView.getCellWeekByDate(plannedPart.StartDate, plannedPart.EndDate, false);
                                            if (cellPlanningLabType!= null)                        
                                                cellPlanningLabType.Planned += (dqty / (runStdH == 0 ? 1 : runStdH)) * routingLabTool.TotEmployees;
                                        } 
                                    }
                                }
                            }
                            
                        }
                    }
                }
            }
        }
        
        return labourPlanningReportViewContainer;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}      
} 

public
void loadAllTasks(Hashtable hash){
    CapShiftTaskContainer   capShiftTaskContainer = readCapShiftTaskByFilters("","","",0);      
    foreach(CapShiftTask capShiftTask in capShiftTaskContainer) {          
        if (!hash.Contains(capShiftTask.Id))
            hash.Add(capShiftTask.Id,capShiftTask);        
    }
}

public
CapShiftTask getTaskHash(Hashtable hash,int id){
    CapShiftTask capShiftTask = null;        

    if (hash.Contains(id))
        capShiftTask = (CapShiftTask)hash[id];
    else{
        capShiftTask = readCapShiftTask(id);
        hash.Add(id,capShiftTask);
    }
    
    return capShiftTask;
}

public
void loadAllMachines(Hashtable hash){
    PltDeptMachDataBaseContainer    pltDeptMachDataBaseContainer = new PltDeptMachDataBaseContainer(dataBaseAccess);
    string                          skey="";

    pltDeptMachDataBaseContainer.read();
    foreach(PltDeptMachDataBase pltDeptMachDataBase in pltDeptMachDataBaseContainer) { 
        skey= pltDeptMachDataBase.getPDM_Plt().ToUpper() + Constants.DEFAULT_SEP + pltDeptMachDataBase.getPDM_Dept().ToUpper() + Constants.DEFAULT_SEP + pltDeptMachDataBase.getPDM_Mach().ToUpper();    
        if (!hash.Contains(skey))
           hash.Add(skey, pltDeptMachDataBase);
    }    
}

public
void loadAllMachinesById(Hashtable hash){
    PltDeptMachDataBaseContainer    pltDeptMachDataBaseContainer = new PltDeptMachDataBaseContainer(dataBaseAccess);
    
    pltDeptMachDataBaseContainer.read();
    foreach(PltDeptMachDataBase pltDeptMachDataBase in pltDeptMachDataBaseContainer) {         
        if (!hash.Contains(pltDeptMachDataBase.getPDM_ID()))
           hash.Add(pltDeptMachDataBase.getPDM_ID(), pltDeptMachDataBase);
    }    
}

public
void loadAllRoutingsWtihLabourTool(Hashtable hash,string splant){
    RoutingContainer    routingContainer = readRoutingByFilters("",splant,"",-1,"","",true,true,0);//get routing only header
    string              skey=""; 
    Hashtable           hashRoutingId = new Hashtable();
                    	    
    foreach(Routing routing in routingContainer) {
        skey = routing.ProdID.ToUpper() + Constants.DEFAULT_SEP + routing.Seq + Constants.DEFAULT_SEP + routing.Plt.ToUpper() + Constants.DEFAULT_SEP + routing.Dept.ToUpper() + Constants.DEFAULT_SEP + routing.Cfg.ToUpper();        
        if (!hash.Contains(skey))
           hash.Add(skey,routing);
        
        hashRoutingId.Add(routing.Id,routing);
    }

    //load all tasks(to be processed faster) and add to routings
    ProdFmactSubLabToolDataBaseContainer prodFmactSubLabToolDataBaseContainer = new ProdFmactSubLabToolDataBaseContainer(dataBaseAccess);
    prodFmactSubLabToolDataBaseContainer.read(); 
    foreach(ProdFmactSubLabToolDataBase prodFmactSubLabToolDataBase in prodFmactSubLabToolDataBaseContainer)  {
        RoutingLabTool routingLabTool = objectDataBaseToObject(prodFmactSubLabToolDataBase);

        if (hashRoutingId.Contains(routingLabTool.HdrId)) {
            Routing routing = (Routing)hashRoutingId[routingLabTool.HdrId];
            routing.RoutingLabToolContainer.Add(routingLabTool);                
        }
    }

}

public
PltDeptMachDataBase getMachineById(Hashtable hash,int id){
    PltDeptMachDataBase     pltDeptMachDataBase = null;
    PltDeptMachDataBase     pltDeptMachDataBaseResult = null;
        
    if (hash.Contains(id))
        pltDeptMachDataBaseResult = (PltDeptMachDataBase)hash[id];
    else{
        pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
        pltDeptMachDataBase.setPDM_ID(id);        
        if (pltDeptMachDataBase.readById(id)){
            pltDeptMachDataBaseResult= pltDeptMachDataBase;
            hash.Add(id, pltDeptMachDataBaseResult);
        }else     
            hash.Add(id, null); ////we store null values too, so not wasting time to search when we already know there is not info
    } 
    return pltDeptMachDataBaseResult;
}

public
Routing getRouting(Hashtable hash,string spartH,int iseqH,string splantH,string sdeptH, string smachH){
    Routing     routing = getRoutingHash(hash, spartH, iseqH, splantH, sdeptH, smachH);   
     string     skey = spartH.ToUpper()+    Constants.DEFAULT_SEP + iseqH + Constants.DEFAULT_SEP + splantH.ToUpper() +
                                            Constants.DEFAULT_SEP + sdeptH.ToUpper() + Constants.DEFAULT_SEP + smachH.ToUpper();            
 

    if (routing == null){
        RoutingContainer routingContainer = readRoutingByFilters(spartH,splantH, sdeptH,iseqH, smachH,Routing.ROUTING_TYPE_MAIN,false,false,1);//get routing
        if (routingContainer.Count > 0) 
            routing = routingContainer[0];

        if (!hash.Contains(skey))
            hash.Add(skey,routing);//we store null values too, so not wasting time to search when we already know there is not info
    } 
    return routing;
} 

public
Routing getRoutingHash(Hashtable hash,string spartH,int iseqH,string splantH,string sdeptH, string smachH){
    Routing     routing = null;        
    string      skey = spartH.ToUpper()+    Constants.DEFAULT_SEP + iseqH + Constants.DEFAULT_SEP + splantH.ToUpper() +
                                            Constants.DEFAULT_SEP + sdeptH.ToUpper() + Constants.DEFAULT_SEP + smachH.ToUpper();            
    if (hash.Contains(skey))
        routing = (Routing)hash[skey];
    
    return routing;
} 

public
Routing getRoutingHashNullIfNotFound(Hashtable hash,string spartH,int iseqH,string splantH,string sdeptH, string smachH){
    Routing     routing = null;        
    string      skey = spartH.ToUpper()+    Constants.DEFAULT_SEP + iseqH + Constants.DEFAULT_SEP + splantH.ToUpper() +
                                            Constants.DEFAULT_SEP + sdeptH.ToUpper() + Constants.DEFAULT_SEP + smachH.ToUpper();            
    if (hash.Contains(skey))
        routing = (Routing)hash[skey];
    else 
        hash.Add(skey,null);

    return routing;
} 

public
decimal loadPlannedHdrHoursByMachineRangeDate(PlannedHdr plannedHdr,Hashtable hashPrHistSum, int imachineId,DateTime startDate,DateTime endDate,Hashtable hashRoutings){
    try { 
        decimal dhours = 0;        

        if (plannedHdr!= null) { 
            PlannedReq          plannedReq = plannedHdr.PlannedReqContainer.getByRequirment(Constants.TYPE_MACHINE, imachineId);
            RoutingContainer    routingContainer = null;
            Routing             routing = null;
            PlannedPart         plannedPart= null;
            string              skey = "";            
            decimal             drunStd=0;            
            PrHistSumView       prHistSumView = null;
            decimal             dqtyProduced =0;

            if (plannedReq!= null){

                for (int i=0; i < plannedReq.PlannedPartContainer.Count;i++){               
                    plannedPart = plannedReq.PlannedPartContainer[i];

                    if (plannedPart.StartDate >= startDate && plannedPart.EndDate <= endDate){

                        routing=null;
                        skey = plannedPart.Part.ToUpper() + Constants.DEFAULT_SEP + plannedPart.Seq;
                        if (hashRoutings.Contains(skey))
                            routing = (Routing)hashRoutings[skey];
                        else { 
                            routingContainer  = getBuildByFilters("", plannedPart.Part, plannedPart.Seq,imachineId,true,false);    
                            if (routingContainer.Count > 0)
                                routing = routingContainer[0];
                            hashRoutings.Add(skey,routing); //store not matter if found or not
                        }

                        drunStd=1;
                        if (routing!= null)
                            drunStd = routing.RunStd;
                        
                        //check produced
                        dqtyProduced =0;                        
                        if (hashPrHistSum!= null && hashPrHistSum.Contains(skey)){
                            prHistSumView= (PrHistSumView)hashPrHistSum[skey];
                            dqtyProduced = prHistSumView.DWQTYC;
                        }
                                              
                        plannedPart.HoursShow =  (plannedPart.QtyPlanned - dqtyProduced) / (drunStd!=0 ? drunStd : 1);                       
                        dhours+= plannedPart.HoursShow;
                    }
                }                       
            }
        }

        return dhours;

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}


public
PlannedHdr machinePlannedFillAutomatic(PlannedHdr plannedHdrFilter, InventoryObjectiveHdr inventoryObjectiveHdrFilter,string splant,Machine machine,MachineReportPartView machineReportPartView){
    PlannedHdr plannedHdr = null;
    try {
        PlannedReq              plannedReq = null;        
        RoutingContainer        routingContainer = null;
        Routing                 routing = null;
        InventoryObjectiveHdr   inventoryObjectiveHdr = null;        
        decimal                 drunStd=0;    
        decimal                 dtotBuildPerWeek = 0;    
        bool                    bisNewReq=false;

        if (machine!= null && machineReportPartView!= null) {             

            plannedHdr = readPlannedHdrLastDateCheck(plannedHdrFilter,splant);

            if (plannedHdr==null)
                plannedHdr = createNewPlannedHdr(splant); //if PlannedHdr does not exist, we crete new one

            inventoryObjectiveHdr = readInventoryObjectiveHdrLastDateCheck(inventoryObjectiveHdrFilter,splant);
            if (inventoryObjectiveHdr == null)
                inventoryObjectiveHdr = createNewInventoryObjectiveHdr(splant);

            //just in case refill inventory objectives info
            fillInventoryObjectives(machineReportPartView, inventoryObjectiveHdr);
            machineReportPartView.recalcNet();

            //get routing
            routingContainer =   getBuildByFilters("",machineReportPartView.Part,machineReportPartView.Seq,machine.Id,true,false);            
            if (routingContainer.Count > 0)
                routing = routingContainer[0];

            if (routing!= null){ 
                                
                plannedReq = plannedHdr.PlannedReqContainer.getByRequirment(Constants.TYPE_MACHINE, machine.Id);
                if (plannedReq == null) { 
                    plannedReq = createNewPlannedReq(plannedHdr,Constants.TYPE_MACHINE,machine.Id);
                    bisNewReq=true;
                }

                drunStd = routing.RunStd;    
                dtotBuildPerWeek = routing.RunStd * machine.getHrsPerShift() * machine.getStdShiftPerWeek();

                fillPlannedPartBasedRequirmentsObjectives(plannedHdr,inventoryObjectiveHdr,plannedReq,machineReportPartView,drunStd,dtotBuildPerWeek);
            }
        }

        if (plannedHdr.Id > 0)
            this.updatePlannedHdrOnlyPlannedReq(plannedHdr,plannedReq,bisNewReq);
        else
            writePlannedHdr(plannedHdr);

        return plannedHdr;

    }catch(PersistenceException persistenceException){		
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
}

private
void fillInventoryObjectives(MachineReportPartView machineReportPartView,InventoryObjectiveHdr inventoryObjectiveHdr){
    InventoryObjectivePart      inventoryObjectivePart = inventoryObjectiveHdr.InventoryObjectivePartContainer.getByPartSeq(machineReportPartView.Part, machineReportPartView.Seq);
    decimal                     dinvObjectives =0;
  
    for (int i=0; i < CapacityView.TITLE_COUNTS;i++){
        CellMachinePart cellMachinePart = machineReportPartView.getCellMachinePartByXIndex(i);

        if (cellMachinePart!= null){
            dinvObjectives =0;
            if (inventoryObjectivePart != null)
                dinvObjectives =  inventoryObjectivePart.InventoryObjectivePartDtlContainer.getQtyByRangeDate(cellMachinePart.StartDate,cellMachinePart.EndDate);

            cellMachinePart.InvObjectives = dinvObjectives;
        }
    }
}
            
private
void fillPlannedPartBasedRequirmentsObjectives(PlannedHdr plannedHdr,InventoryObjectiveHdr inventoryObjectiveHdr,PlannedReq plannedReq,MachineReportPartView machineReportPartView,decimal drunStd,decimal dtotBuildPerWeek){             
    CellMachinePart cellMachinePartPrior=null;

    for (int i=0; i < CapacityView.TITLE_COUNTS;i++){
        CellMachinePart cellMachinePart = machineReportPartView.getCellMachinePartByXIndex(i);

        if (cellMachinePart!= null){
            if (cellMachinePartPrior!= null)
                cellMachinePart.PriorWeekNet = cellMachinePartPrior.Net;
                        
            machineReportPartView.recalcNet();
            fillPlannedPartBasedRequirmentObjective(plannedHdr,inventoryObjectiveHdr,plannedReq,machineReportPartView,cellMachinePart,drunStd,dtotBuildPerWeek);
        }
        cellMachinePartPrior = cellMachinePart;
    }

}
private
PlannedPart fillPlannedPartBasedRequirmentObjective(PlannedHdr plannedHdr,InventoryObjectiveHdr inventoryObjectiveHdr,PlannedReq plannedReq,MachineReportPartView machineReportPartView,CellMachinePart cellMachinePart,decimal drunStd,decimal dtotBuildPerWeek){
    PlannedPart                 plannedPart = null;
    
    if (plannedHdr!= null && inventoryObjectiveHdr!= null && plannedReq!= null) { 
        plannedPart = plannedReq.PlannedPartContainer.getByPartSeqDateRangeWeek(machineReportPartView.Part,machineReportPartView.Seq,cellMachinePart.StartDate);
        
        cellMachinePart.Planned = 0;
        machineReportPartView.recalcNet();
        if (plannedPart != null) 
            plannedPart.QtyPlanned=0;                     

        if (cellMachinePart.Net < 0) { 
           
            if (plannedPart == null) { 
                plannedPart = createNewPlannedPart(machineReportPartView.Part, machineReportPartView.Seq, 0,0,0,cellMachinePart.StartDate);
                plannedReq.PlannedPartContainer.Add(plannedPart);
            }           
            plannedPart.QtyPlanned = Math.Abs(cellMachinePart.Net);
            if (plannedPart.QtyPlanned > dtotBuildPerWeek)
               plannedPart.QtyPlanned = dtotBuildPerWeek;

            cellMachinePart.Planned = plannedPart.QtyPlanned;
            machineReportPartView.recalcNet();
        }
    }

    return plannedPart;
}


public
PlannedHdr machinePlannedFillFullAutomatic(PlannedHdr plannedHdrFilter, InventoryObjectiveHdr inventoryObjectiveHdrFilter,string splant,Machine machine, MachineReportViewContainer machineReportViewContainer,bool bcheckMaxBuilds){
    PlannedHdr plannedHdr = null;
     try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        PlannedReq                  plannedReq = null;        
        RoutingContainer            routingContainer = null;
        Routing                     routing = null;
        InventoryObjectiveHdr       inventoryObjectiveHdr = null;
        CellMachinePart             cellMachinePart= null;
        decimal                     drunStd=0;    
        decimal                     dtotBuildPerWeek = 0;   
        decimal                     dtotMachineHoursWeek=0;                 
        decimal                     dfreeMachineHoursWeek=0;
        bool                        bisNewReq=false;
        Hashtable                   hashProdFmActPlan   = new Hashtable();
        Hashtable                   hashProdFmActSub    = new Hashtable();
        Hashtable                   hashBomSum          = new Hashtable();
        Hashtable                   hashMachines        = new Hashtable();
        MachineReportViewContainer  machineReportViewContainerLastSeqs = new MachineReportViewContainer();
        MachineReportPartView       machineReportPartViewLastSeq= null;

        if (machine!= null && machineReportViewContainer != null && machineReportViewContainer.Count > 0) {             
            
            //get planned info
            plannedHdr = readPlannedHdrLastDateCheck(plannedHdrFilter,splant);
            if (plannedHdr==null)
                plannedHdr = createNewPlannedHdr(splant); //if PlannedHdr does not exist, we crete new one
            plannedReq = plannedHdr.PlannedReqContainer.getByRequirment(Constants.TYPE_MACHINE, machine.Id);
            if (plannedReq == null) { 
                plannedReq = createNewPlannedReq(plannedHdr,Constants.TYPE_MACHINE,machine.Id);                                        
                bisNewReq=true;
            }

            //get inventory objectives
            inventoryObjectiveHdr = readInventoryObjectiveHdrLastDateCheck(inventoryObjectiveHdrFilter,splant);
            if (inventoryObjectiveHdr == null)
                inventoryObjectiveHdr = createNewInventoryObjectiveHdr(splant);
            
            routingContainer =  getBuildByFilters("","",-1,machine.Id,true,false);//get routings

            //check who are last sequences, because if minor sequences for same part, we might not process
            for (int j=0; j < machineReportViewContainer.Count; j++) {
                MachineReportPartView machineReportPartView = (MachineReportPartView)machineReportViewContainer[j];
                if (machineReportPartView.SeqLast == machineReportPartView.Seq)
                    machineReportViewContainerLastSeqs.Add(machineReportPartView);
            }

            for (int i=0; i <= CapacityView.TITLE_COUNTS;i++){  //loop for every week
                                            
                for (int j=0; j < machineReportViewContainer.Count; j++) { //loop on every part build by machine
                    MachineReportPartView   machineReportPartView = (MachineReportPartView)machineReportViewContainer[j];
                    bool                    bprocess=true;

                    machineReportPartViewLastSeq = machineReportViewContainerLastSeqs.getByFirtPart(machineReportPartView.Part);
                    if (machineReportPartViewLastSeq != null && machineReportPartView.Seq != machineReportPartViewLastSeq.Seq)
                           bprocess=false; //do not process that part/seq, because already exists last seq, so will be processed anyway
                        
                    bprocess=true; // for now always process
                    if (bprocess) { 
                        cellMachinePart = machineReportPartView.getCellMachinePartByXIndex(i);
                        if (cellMachinePart!= null) { 

                            if (j == 0) {//on first time for week initialize
                                dtotMachineHoursWeek = machine.getHrsPerShift() * machine.getStdShiftPerWeek();
                                dfreeMachineHoursWeek= dtotMachineHoursWeek;                            
                            }                                        

                            if (i == 0)
                                fillInventoryObjectives(machineReportPartView, inventoryObjectiveHdr);    //just in case refill inventory objectives info

                            routing = routingContainer.getByFirst(machineReportPartView.Part,machineReportPartView.Seq,machine.Mach);
                            if (routing!= null){                                                    
                                drunStd = routing.RunStd;    
                                dtotBuildPerWeek = routing.RunStd * machine.getHrsPerShift() * machine.getStdShiftPerWeek();

                                machinePlannedPartBasedRequirmentObjective(plannedHdr,inventoryObjectiveHdr,plannedReq,machineReportPartView,cellMachinePart,ref dfreeMachineHoursWeek,drunStd, dtotBuildPerWeek,bcheckMaxBuilds,hashProdFmActPlan,hashProdFmActSub,hashBomSum,hashMachines);                        
                            }
                        }
                    }
                }
            }

           
        }

        if (plannedHdr!= null) { 
            if (plannedHdr.Id > 0)
                updatePlannedHdrOnlyPlannedReqInternal(plannedHdr,plannedReq,bisNewReq);
            else
                writePlannedHdrInternal(plannedHdr);
        }

        if (machine!= null && machine.MachineDef!= null) { 
            machine.MachineDef.DateLastPlanned = DateTime.Now;
            updateMachineInternal(machine);
        }

        if (!userHandleTransaction)
		    dataBaseAccess.commitTransaction();

        return plannedHdr;

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
PlannedHdr machinePlannedClearAutomatic(PlannedHdr plannedHdrFilter, InventoryObjectiveHdr inventoryObjectiveHdrFilter,string splant,Machine machine, MachineReportViewContainer machineReportViewContainer){
    PlannedHdr plannedHdr = null;
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

        Hashtable   hashProdFmActPlan   = new Hashtable();
        Hashtable   hashProdFmActSub    = new Hashtable();
        Hashtable   hashBomSum          = new Hashtable();
        Hashtable   hashMachines        = new Hashtable();

        PlannedReq              plannedReq = null;
        PlannedPart             plannedPart = null;                
        CellMachinePart         cellMachinePart= null;
               
        if (machine!= null && machineReportViewContainer != null && machineReportViewContainer.Count > 0) {                         
            //get planned info
            plannedHdr = readPlannedHdrLastDateCheck(plannedHdrFilter,splant);
            if (plannedHdr==null)
                plannedHdr = createNewPlannedHdr(splant); //if PlannedHdr does not exist, we crete new one
            plannedReq = plannedHdr.PlannedReqContainer.getByRequirment(Constants.TYPE_MACHINE, machine.Id);
                                    
            for (int i=0; plannedReq!=null &&  i <= CapacityView.TITLE_COUNTS;i++){  //loop for every week
                                            
                for (int j=0; j < machineReportViewContainer.Count; j++) { //loop on every part build by machine
                    MachineReportPartView machineReportPartView = (MachineReportPartView)machineReportViewContainer[j];

                    cellMachinePart = machineReportPartView.getCellMachinePartByXIndex(i);
                    if (cellMachinePart!= null) { 
                        plannedPart = plannedReq.PlannedPartContainer.getByPartSeqDateRangeWeek(machineReportPartView.Part,machineReportPartView.Seq,cellMachinePart.StartDate);

                        if (plannedPart != null) { 
                            plannedReq.PlannedPartContainer.Remove(plannedPart);
                           
                            if (machineReportPartView.SeqLast == machineReportPartView.Seq) { 
                                plannedPart.QtyPlanned=0; //removed all childs
                                //generatePlannedPartsForChildsSeqInternal(plannedHdr,plannedPart, hashProdFmActPlan, hashProdFmActSub, hashBomSum,hashMachines);
                            }
                        }
                    }
                }
            }            
        }

        if (plannedHdr.Id > 0)
            updatePlannedHdrOnlyPlannedReqInternal(plannedHdr,plannedReq,false);
        else
            writePlannedHdrInternal(plannedHdr);

        if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

        return plannedHdr;

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
PlannedPart machinePlannedPartBasedRequirmentObjective(PlannedHdr plannedHdr,InventoryObjectiveHdr inventoryObjectiveHdr,PlannedReq plannedReq,MachineReportPartView machineReportPartView,CellMachinePart cellMachinePart,
                                                    ref decimal dfreeMachineHoursWeek,decimal drunStd,decimal dtotBuildPerWeek,bool bcheckMaxBuilds,
                                                    Hashtable hashProdFmActPlan, Hashtable hashProdFmActSub, Hashtable hashBomSum, Hashtable hashMachines){
    PlannedPart             plannedPart = null;
    decimal                 dmaxQtyBuildThisWeek = dfreeMachineHoursWeek * drunStd; //hours free on machine X RunStd
    bool                    bisNewPlannedPart =false;

    if (plannedHdr!= null && inventoryObjectiveHdr!= null && plannedReq!= null) { 
        plannedPart = plannedReq.PlannedPartContainer.getByPartSeqDateRangeWeek(machineReportPartView.Part,machineReportPartView.Seq,cellMachinePart.StartDate);
        
        cellMachinePart.Planned = 0;
        machineReportPartView.recalcNetIncludeInvObjectives();
        if (plannedPart != null) 
            plannedPart.QtyPlanned=0;                     

        if (cellMachinePart.Net < 0 && (!bcheckMaxBuilds || dfreeMachineHoursWeek > 0)) { //check if there is free time on machine yet
           
            if (plannedPart == null) { 
                plannedPart = createNewPlannedPart(machineReportPartView.Part, machineReportPartView.Seq, 0,0,0,cellMachinePart.StartDate);
                plannedReq.PlannedPartContainer.Add(plannedPart);
                bisNewPlannedPart =true;
            }           
            plannedPart.QtyPlanned = Math.Abs(cellMachinePart.Net);
            if (plannedPart.QtyPlanned > dmaxQtyBuildThisWeek && bcheckMaxBuilds)
               plannedPart.QtyPlanned = dmaxQtyBuildThisWeek;

            dfreeMachineHoursWeek-= plannedPart.QtyPlanned / (drunStd!=0 ? drunStd : 1); //new hours free on that machine , for current week            
            cellMachinePart.Planned = plannedPart.QtyPlanned;            
            machineReportPartView.recalcNetIncludeInvObjectives();

            if (bisNewPlannedPart)
                plannedPart.QtyOriginal =plannedPart.QtyPlanned;
            plannedPart.QtyChange = 0;

            //if (machineReportPartView.SeqLast == machineReportPartView.Seq)
                //generatePlannedPartsForChildsSeqInternal(plannedHdr,plannedPart,hashProdFmActPlan,hashProdFmActSub,hashBomSum,hashMachines);
        }
        
    }

    return plannedPart;
}

public
LabourTypeRequiredContainer getHotListShiftsTask(Hashtable hashMachines,Hashtable hashRoutings,ScheduleHdr scheduleHdrFilter,int id,string splantHotList,string splant,string sdept,string smachine,int imachineId,string spart,int iseq,string sreportedPoint,bool borderByDemand,bool bgetCumulativeQty, bool baddReceipParts,bool baddMaterialConsumPart,int rows){

	try{
        LabourTypeRequiredContainer     labourTypeRequiredContainer = new LabourTypeRequiredContainer();
        LabourTypeRequired              labourTypeRequired = null;

        HotListContainer                hotListContainer= new HotListContainer();

        DateTime            runDate = DateUtil.MinValue;
        HotListHdrDataBase  hotListHdrDataBase = new HotListHdrDataBase(dataBaseAccess);        
        Hashtable           hashHdrLabourType = new Hashtable();
        Hashtable           hashHdrScheduleLabourType = new Hashtable();
        DateTime            currentDate = DateTime.Now;        
        int                 ischeduleId=0;
        DateTime            fromDate= DateTime.Now , toDate = DateTime.Now;        
        RoutingContainer    routingContainer = new RoutingContainer();
        Routing             routing = null;            
        int                 i = 0;
        ScheduleHdr         scheduleHdr= scheduleHdrFilter!= null ? scheduleHdrFilter : new ScheduleHdr();        
        ScheduleReceiptPartContainer    scheduleReceiptPartContainer = new ScheduleReceiptPartContainer();        
        PltDeptMachDataBase             pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
        bool                            ballRoutingWithLabourLoaded=false;
                                            
        if (id == 0) // We get the last hotList, if returns 0 there are not hotHotlist record generated			 
            id = hotListHdrDataBase.readLastIdByPlant(splantHotList);            
                
        hotListHdrDataBase.setId(id);
        if (!hotListHdrDataBase.read())                
            return labourTypeRequiredContainer; //can not found hot list
        runDate = hotListHdrDataBase.getHLR_HotlistRunDate();

        fromDate= new DateTime(runDate.AddDays(-1).Year, runDate.AddDays(-1).Month, runDate.AddDays(-1).Day,0,0,0);
        toDate  = new DateTime(runDate.AddDays(90).Year, runDate.AddDays(90).Month, runDate.AddDays(90).Day,23,59,59); //last day from hotlist   

        //read last shedule
        scheduleHdr = readScheduleHdrLastDateCheck(scheduleHdr,splantHotList);
        /*
        ScheduleHdrDataBase scheduleHdrDataBase = new ScheduleHdrDataBase(dataBaseAccess);
        if (scheduleHdrDataBase.readLastByFilter(splantHotList)){ 
            ischeduleId = scheduleHdrDataBase.getId();
            scheduleHdr = readScheduleHdr(ischeduleId);
        }*/

        if (hashMachines.Count < 1 && imachineId ==0)
            loadAllMachines(hashMachines);
        
        if (imachineId ==0)
            hashRoutings.Clear(); //for now always trying to load routings
        if (hashRoutings.Count < 1 && imachineId ==0){
            loadAllRoutingsWtihLabourTool(hashRoutings,"");
            ballRoutingWithLabourLoaded=true;
        }

        hotListContainer = getHotListAsStringNew2(id, splantHotList, splant, sdept, smachine, imachineId, spart, iseq,"","", sreportedPoint,"", borderByDemand, false, baddReceipParts, baddMaterialConsumPart, rows);
        
        for (i=0; i < hotListContainer.Count;i++){
            HotList hotList = hotListContainer[i];

            string  sdeptH  = hotList.Dept;
			string  spartH  = hotList.ProdID;
			int     iseqH   = hotList.Seq;
            string  smachH  = hotList.Mach;
            decimal runStdH = hotList.MachCyc;
			string  splantH = hotList.Plt;
            decimal dqty    = 0;
            decimal dtotEmpl=0;                     
            decimal dtotEmplOld = 0;
            
            pltDeptMachDataBase = null;
            routing = null;
            if (!string.IsNullOrEmpty(smachH)) { 
                pltDeptMachDataBase = getHashMachine(hashMachines,splantH, sdeptH, smachH);
                if (ballRoutingWithLabourLoaded)    routing = getRoutingHash(hashRoutings,spartH,iseqH,splantH,sdeptH,smachH);                
                else                                routing = getRouting(hashRoutings,spartH,iseqH,splantH,sdeptH,smachH);                
            }
                       
            if (pltDeptMachDataBase != null && routing!=null && routing.RoutingLabToolContainer.Count > 0){
                
                scheduleReceiptPartContainer = getScheduleReceiptParts(scheduleHdr, pltDeptMachDataBase.getPDM_ID(), spartH, iseqH);
                //scheduleReceiptPartContainer = getReceiptPartByFilters(ischeduleId, CapacityReq.REQUIREMENT_MACHINE, machine.Id, spartH, iseqH, fromDate, toDate);
                
                HotListDayContainer hotListDayContainer = hotList.getQtyDatesNonZero(runDate);                                
                foreach( HotListDay hotListDay in hotListDayContainer) {
                    currentDate = hotListDay.DateTime;
                    dqty = hotListDay.Qty;                               
                    dqty =  dqty < 0 ? Math.Abs(dqty) : 0;      //only searching when negative qty

                    for (int h=0; dqty != 0 && h < routing.RoutingLabToolContainer.Count;h++) {
                        RoutingLabTool routingLabTool = routing.RoutingLabToolContainer[h];
                        if (!routingLabTool.Type.Equals(RoutingLabTool.LABOUR_TYPE))
                            continue;

                        labourTypeRequired = labourTypeRequiredContainer.getByKey(routingLabTool.ReqId);
                        if (labourTypeRequired == null){
                            labourTypeRequired = new LabourTypeRequired();
                            
                          	labourTypeRequired.Id = routingLabTool.ReqId;	                        
                            CapShiftTask capShiftTask = readCapShiftTask(routingLabTool.ReqId);   //read labour task                            
                            labourTypeRequired.Code     = capShiftTask != null ? capShiftTask.Id.ToString() : "";
	                        labourTypeRequired.LabName  = capShiftTask != null ? capShiftTask.TaskName : "";
	                        labourTypeRequired.DirInd   = capShiftTask != null ? capShiftTask.DirInd : "";

                            labourTypeRequiredContainer.Add(labourTypeRequired);
                        }

                        dtotEmpl = (dqty /  (runStdH ==0? 1: runStdH)) * routingLabTool.TotEmployees;
                        dtotEmplOld = labourTypeRequired.getQtyByDate(runDate,currentDate);

                        dtotEmpl+= dtotEmplOld;
                        labourTypeRequired.setQtyByDate(runDate,currentDate,dtotEmpl);                        
                    }
                }                                        
            }
        }
        
        return labourTypeRequiredContainer;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}      
} 

private
void loadFirtsWeekScheduleReceiptsToHotListDays(HotList hotList,ScheduleReceiptPartContainer scheduleReceiptPartContainer,DateTime runDate,DateTime toDate,string spart,int iseq){    
    DateTime priorMonday=DateTime.Now,nextSunday=DateTime.Now;
    DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now,out priorMonday, out nextSunday);    

    foreach (ScheduleReceiptPart scheduleReceiptPart in scheduleReceiptPartContainer){
        if (scheduleReceiptPart.Part.Equals(spart) && scheduleReceiptPart.Seq == iseq &&
            (scheduleReceiptPart.RecDate >= priorMonday && scheduleReceiptPart.RecDate <= nextSunday))
            hotList.setSummarizeQtyByDate(runDate,scheduleReceiptPart.RecDate,scheduleReceiptPart.RecQty);

    }
            
}

public
MachineContainer loadMachinePlannedHdrShiftRemainings(PlannedHdr plannedHdr,CapacityHdr capacityHdr,string splant,Hashtable hashPrHistSum,Hashtable hashRoutings){
    try {         
        MachineContainer    machineContainer = new MachineContainer();
        MachineView         machineView= null;
        MachineView         machineViewAux= null;
        DateTime            startDate   = DateTime.Now;
        DateTime            endDate     = DateTime.Now;   
        decimal             dremHours   = 0;
        Hashtable           hashMachinesView = new Hashtable();
        ArrayList           arrayMachineIds = new ArrayList();

        DateUtil.getPriorMondayNextSundayFromDate(startDate,out startDate,out endDate);
        plannedHdr = readPlannedHdrLastDateCheck(plannedHdr,splant);
    
        if (plannedHdr!= null){ 
            for (int j=0; j < 2; j++) { //we process for week1 and week2
                foreach (PlannedReq plannedReq in plannedHdr.PlannedReqContainer){

                    if (plannedReq.Type.Equals(Constants.TYPE_MACHINE)) {

                        machineView = new MachineView();

                        machineView.Id = plannedReq.ReqID;
                        machineView.PlanDate = startDate;
                        dremHours = loadPlannedHdrHoursByMachineRangeDate(plannedHdr,hashPrHistSum,plannedReq.ReqID,startDate,endDate,hashRoutings);

                        if (dremHours != 0) { 
                            machineView.RemainsShifts = Convert.ToInt32(dremHours); //for now we store hours, then we need to converto to shifts                            
                            if (!hashMachinesView.Contains(machineView.Id)) { 
                                arrayMachineIds.Add(machineView.Id);
                                hashMachinesView.Add(machineView.Id,machineView);
                            }
                        }
                    }
                }
                DateUtil.getPriorMondayNextSundayFromDate(startDate.AddDays(7),out startDate,out endDate);
            }

            machineContainer = readMachinesViewByFilters("","","","","",DateUtil.MinValue,arrayMachineIds,false,0);
            for (int i=0; i < machineContainer.Count;i++){
                machineView = (MachineView)machineContainer[i];
                    
                if (hashMachinesView.Contains(machineView.Id)){ 
                    machineViewAux = (MachineView)hashMachinesView[machineView.Id];
                    machineView.RemainsShifts = Convert.ToInt32(machineViewAux.RemainsShifts / machineView.getHrsPerShift());
                    machineView.PlanDate = machineViewAux.PlanDate;
                }                                    
            }
            machineContainer.sortByRemainsShifts();

            if (capacityHdr!= null) { 
                capacityHdr.CapacityMachPriorityContainer.Clear(); //remove priorities and create new ones
                for (int i=0; i < machineContainer.Count;i++){
                    machineView = (MachineView)machineContainer[i];
                    
                    CapacityMachPriority capacityMachPriority = new CapacityMachPriority();
                    capacityMachPriority.Priority   = (i+1);
                    capacityMachPriority.MachineId  = machineView.Id;
                    capacityMachPriority.MachineShow= machineView.Mach;
                    capacityMachPriority.Planned    = Constants.STRING_YES;
                    capacityHdr.CapacityMachPriorityContainer.Add(capacityMachPriority);

                    machineView.Priority = capacityMachPriority.Priority;
                }
                updateCapacityHdrOnlyMachinePriority(capacityHdr);
            }            
        }

        return machineContainer;

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}   
}


private
void getPlannedLabourTypeSpecificProcessLabour( LabourPlanningReportShiftViewContainer labourPlanningReportShiftViewContainer,
                                                Hashtable hashTasks,PlannedReq plannedReq){
    CapShiftTask                        capShiftTask=null;
    LabourPlanningReportShiftView       labourPlanningReportShiftView = null;
    CellPlanningLabType                 cellPlanningLabType = null;
    DateTime                            startDate = DateTime.Now;
    DateTime                            endDate = DateTime.Now;

    for (int j = 0; j < plannedReq.PlannedLabourContainer.Count; j++) {
        PlannedLabour plannedLabour = plannedReq.PlannedLabourContainer[j];

        capShiftTask = getTaskHash(hashTasks,plannedLabour.LabourTypeId);

        DateUtil.getPriorMondayNextSundayFromDate(plannedLabour.StartDate,out startDate,out endDate);

        labourPlanningReportShiftView = getLabourPlanningReportShiftView(labourPlanningReportShiftViewContainer,capShiftTask,startDate);
        if (labourPlanningReportShiftView != null) {

            cellPlanningLabType = labourPlanningReportShiftView.getCellPlanningLabTypeByIndex(plannedLabour.ShiftNum);
            if (cellPlanningLabType!= null) { 
                //cellPlanningLabType.Planned +=  plannedLabour.TotEmployPlan;
                cellPlanningLabType.Overtime+=  plannedLabour.TotEmployOver;
                cellPlanningLabType.Temp    +=  plannedLabour.TotEmployTemp;

                cellPlanningLabType.NewHire +=  plannedLabour.TotEmployHire;
                cellPlanningLabType.SickAbsent+=plannedLabour.TotEmployAbsent;
                cellPlanningLabType.Vacation+=  plannedLabour.TotEmployVacation;

                cellPlanningLabType.PlannedLabourContainer.Add(plannedLabour);
            }                        
        }   
    }   

}

private
LabourPlanningReportShiftView getLabourPlanningReportShiftView(LabourPlanningReportShiftViewContainer labourPlanningReportShiftViewContainer, CapShiftTask capShiftTask,DateTime date){
    LabourPlanningReportShiftView labourPlanningReportShiftView = labourPlanningReportShiftViewContainer.getByDate(date);     
    
    if (capShiftTask!= null && labourPlanningReportShiftView == null) {                
        labourPlanningReportShiftView = new LabourPlanningReportShiftView();
        labourPlanningReportShiftView.StartDate = date;
        labourPlanningReportShiftViewContainer.Add(labourPlanningReportShiftView);                                                                                                
    }
    return labourPlanningReportShiftView;
} 
        /*
public
LabourPlanningReportShiftViewContainer getPlannedLabourTypeSpecific(int ilabourTypeId,ref PlannedHdr plannedHdr,Hashtable hashMachinesById, Hashtable hashRoutings, Hashtable hashTasks, string splant, string sdept, int imachineId, string spart, int iseq, string sreportedPoint, int rows){

	try{        
        LabourPlanningReportShiftViewContainer labourPlanningReportShiftViewContainer = new LabourPlanningReportShiftViewContainer();
        plannedHdr = readPlannedHdrLastDateCheck(plannedHdr, splant);
        PlannedReq                      plannedReq = null;
        LabourPlanningReportShiftView   labourPlanningReportShiftView = null;
        LabourPlanningReportShiftView   labourPlanningReportShiftViewAux = new LabourPlanningReportShiftView(); //jut to check if on date range
        Hashtable                       hashHdrLabourType = new Hashtable();
        Hashtable                       hashHdrScheduleLabourType = new Hashtable();
        DateTime                        currentDate = DateTime.Now;                
        DateTime                        fromDate= DateTime.Now , toDate = DateTime.Now;        
        RoutingContainer                routingContainer = new RoutingContainer();
        Routing                         routing = null;            
        int                             i = 0;        
        PltDeptMachDataBase             pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
        bool                            ballRoutingWithLabourLoaded=false;
        CapShiftTask                    capShiftTask = null;
        CellPlanningLabType             cellPlanningLabType = null;
        
        if (hashMachinesById.Count < 1 && imachineId ==0)
            loadAllMachinesById(hashMachinesById);
        
        if (hashRoutings.Count < 1 && imachineId ==0){
            loadAllRoutingsWtihLabourTool(hashRoutings,"");
            ballRoutingWithLabourLoaded=true;
        }        
                
        for (i=0; plannedHdr!= null && i < plannedHdr.PlannedReqContainer.Count;i++){                                
            plannedReq = plannedHdr.PlannedReqContainer[i];

            //checking filters
            if (imachineId != 0 && (!plannedReq.Type.Equals(Constants.TYPE_MACHINE) || (plannedReq.Type.Equals(Constants.TYPE_MACHINE) && imachineId != plannedReq.ReqID)))
                continue;

            if (ilabourTypeId != 0 && (!plannedReq.Type.Equals(Constants.TYPE_LABOUR) || (plannedReq.Type.Equals(Constants.TYPE_LABOUR) && ilabourTypeId != plannedReq.ReqID)))
                continue;

            if (plannedReq.Type.Equals(Constants.TYPE_LABOUR)) {        //labour type           
                getPlannedLabourTypeSpecificProcessLabour(labourPlanningReportShiftViewContainer, hashTasks, plannedReq);
                
            }else if (plannedReq.Type.Equals(Constants.TYPE_MACHINE)) { //machine type           
                
                getPlannedLabourTypeSpecificProcessLabour(labourPlanningReportShiftViewContainer, hashTasks, plannedReq);
                             
                for (int j = 0; j < plannedReq.PlannedPartContainer.Count; j++) {
                    PlannedPart         plannedPart = plannedReq.PlannedPartContainer[j];

                    cellPlanningLabType = labourPlanningReportViewAux.getCellWeekByDate(plannedPart.StartDate,plannedPart.EndDate,false);
                         
                    pltDeptMachDataBase = getMachineById(hashMachinesById, plannedReq.ReqID);
                    if (cellPlanningLabType!= null && pltDeptMachDataBase != null) { 

                        string splantH  = pltDeptMachDataBase.getPDM_Plt();
                        string sdeptH   = pltDeptMachDataBase.getPDM_Dept();
                        string smachH   = pltDeptMachDataBase.getPDM_Mach();
                        string spartH   = plannedPart.Part;
                        int     iseqH   = plannedPart.Seq;
                        decimal runStdH = 0;
                        decimal dqty    = plannedPart.QtyPlanned;
                        
                        if (ballRoutingWithLabourLoaded) routing = getRoutingHash(hashRoutings, spartH, iseqH, splantH, sdeptH, smachH);
                        else routing = getRouting(hashRoutings, spartH, iseqH, splantH, sdeptH, smachH);

                        if (routing != null && routing.RoutingLabToolContainer.Count > 0) {
                            runStdH = routing.RunStd;                            
                                                        
                            for (int h = 0; dqty != 0 && cellPlanningLabType != null && h < routing.RoutingLabToolContainer.Count; h++){
                                RoutingLabTool routingLabTool = routing.RoutingLabToolContainer[h];

                                if (routingLabTool.Type.Equals(RoutingLabTool.LABOUR_TYPE)) {   //process if labour                                    

                                    capShiftTask = getTaskHash(hashTasks,routingLabTool.ReqId);//get labour task
                                    if (capShiftTask!= null) {                                         
                                        labourPlanningReportView = getLabourPlanningReportView(labourPlanningReportViewContainer,capShiftTask,Constants.TYPE_LABOUR, routingLabTool.ReqId);                                        
                                        if (labourPlanningReportView != null) {
                                            cellPlanningLabType = labourPlanningReportView.getCellWeekByDate(plannedPart.StartDate, plannedPart.EndDate, false);
                                            if (cellPlanningLabType!= null)                        
                                                cellPlanningLabType.Planned += (dqty / (runStdH == 0 ? 1 : runStdH)) * routingLabTool.TotEmployees;
                                        } 
                                    }
                                }
                            }
                            
                        }
                    }
                }
            }
        }
        
        return labourPlanningReportViewContainer;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}      
} */

public
SchMaterialAvailContainer processSchMaterialAvail(SchMaterialAvailContainer schMaterialAvailTotUsedContainer, BomSumContainer matBomSumContainer,HotListHdr hotListHdr,string spart,int seq,DateTime dateTime,decimal dqty){
    try { 
        SchMaterialAvailContainer       schMaterialAvailContainer = new SchMaterialAvailContainer();
        HotListContainer                hotListContainer = new HotListContainer();
        Product                         product = readProduct(spart);
        DateTime                        runDate = hotListHdr!= null ? hotListHdr.HotlistRunDate:DateTime.Now;
        decimal                         dparentQty= Math.Abs(dqty);
        ProdFmActSubDataBaseContainer   prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
        prodFmActSubDataBaseContainer.read();

        if (product!= null && hotListHdr != null){
            hotListContainer = readHotListByFilters(hotListHdr.Id,"","","","",0,"",-1,"","",false,false,0);
                     
            processSchPartNew(schMaterialAvailContainer,schMaterialAvailTotUsedContainer, matBomSumContainer, hotListHdr, prodFmActSubDataBaseContainer,spart, seq,dparentQty,dateTime, hotListContainer,runDate);
        }

        return schMaterialAvailContainer;

    }catch(PersistenceException persistenceException){	
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message,exception);
	}
}

private
void processSchPartNew(SchMaterialAvailContainer schMaterialAvailContainer,SchMaterialAvailContainer schMaterialAvailTotUsedContainer,
                       BomSumContainer materials, HotListHdr hotListHdr,ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer, string spart,int seq,decimal dqty,DateTime dateTime,HotListContainer hotListContainer,DateTime runDate){

    HotList                         hotList         = hotListContainer.getByPartSeq(spart,seq);
    HotList                         hotListChild    = null;
    BomSumContainer                 materialsNews   = materials!= null && materials.Count > 0 ? materials : getSubMaterialsMainLevel(hotList.ProdID, hotList.Seq, hotListHdr.Plant);    
    BomSum                          materialNew     = null;    
    decimal                         dparentQty      = dqty;
    decimal                         dparentQoh      = 0;
    decimal                         dchildQoh       = 0;
    decimal                         dchildQtyNeeded = 0;
    decimal                         dmatUsed        = 0;
    Inventory                       inventory       = readInventory(spart, hotListHdr.Plant);    
    SchMaterialAvail                schMaterialAvail= new SchMaterialAvail();
    BomContainer                    sumBomContainer = new BomContainer();
    BomContainer                    currBomContainer= new BomContainer();

    DateTime                        fromDate        = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,0,0,0);
    DateTime                        toDate          = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,23,59,59);

    //we check receipts parts and material consume, which affects qoh
    ScheduleReceiptPartContainer        scheduleReceiptPartContainer        = getReceiptPartContainerByFilters(0, hotListHdr.Plant,"",-1,"",0, fromDate,toDate);
    ScheduleMaterialConsumPartContainer scheduleMaterialConsumPartContainer = getMaterialConsumPartContainerByFilters(0, hotListHdr.Plant,"",-1,"",0,fromDate,toDate);
            
    schMaterialAvail.Plant              = hotListHdr.Plant;
    schMaterialAvail.ParentSrcHotId     = hotListHdr.Id;
    schMaterialAvail.ParentSrcHotDtlId  = hotList!= null ? hotList.IdAut : 0;
    schMaterialAvail.ParentPart         = spart;
    schMaterialAvail.ParentSeq          = seq;    
    schMaterialAvail.ParentQtyAdjust    = dparentQty;
    schMaterialAvail.DateTime           = dateTime;    
    schMaterialAvailContainer.Add(schMaterialAvail);    //add to container       
    schMaterialAvailContainer.fillRedundances();
    if (inventory!= null)
        dparentQoh = inventory.getTotalInventory(seq);
    
    dparentQty  = dparentQoh >= dparentQty ?  0 : (dparentQty - dparentQoh);
            
    for(int i=0; materialsNews!= null && i < materialsNews.Count;i++){
        materialNew = materialsNews[i];

        string      schildPart = materialNew.MatID;
        int         ichildSeq  = materialNew.MatSeq;
        decimal     dqtyPer    = materialNew.MatQty;

        dchildQoh = Convert.ToDecimal(materialNew.MatQohShow);                                
        dchildQoh+= scheduleReceiptPartContainer.getTotalRemainsQty(schildPart,ichildSeq);
        dchildQoh-= scheduleMaterialConsumPartContainer.getTotalRemainsQty(schildPart,ichildSeq);

        hotListChild = hotListContainer.getByPartSeq(schildPart,ichildSeq);
                            
        if (i > 0) { 
            schMaterialAvail= new SchMaterialAvail();              
            schMaterialAvailContainer.Add(schMaterialAvail);                
            schMaterialAvailContainer.fillRedundances();
        }

        SchMaterialAvailContainer schMaterialAvailAuxContainer = getMaterialUsedFromOthers(out dmatUsed, hotListHdr, schildPart, ichildSeq,schMaterialAvail.ParentSrcHotDtlId, dateTime);
        foreach(SchMaterialAvail schMaterialAvailAux in schMaterialAvailAuxContainer)
            schMaterialAvailTotUsedContainer.Add(schMaterialAvailAux);
            
        if (dmatUsed > 0)
            dchildQoh = dmatUsed > 0 ? (dchildQoh- dmatUsed) : 0;

        dchildQtyNeeded                 = dqtyPer * dparentQty;
        dchildQtyNeeded                 = dchildQoh >= dchildQtyNeeded ?  0 : (dchildQtyNeeded-dchildQoh);

        schMaterialAvail.ParentPart     = spart;
        schMaterialAvail.ParentSeq      = seq;    
        schMaterialAvail.MaxQty         = dchildQoh / (dqtyPer != 0 ? dqtyPer:1);        
        schMaterialAvail.ChildPart      = schildPart;
        schMaterialAvail.ChildSeq       = ichildSeq;
        schMaterialAvail.ChildQty       = dqtyPer;
        schMaterialAvail.ChildAvailQty  = dchildQoh;                   
        schMaterialAvail.ChildCumulativeQOH = dchildQtyNeeded;
        schMaterialAvail.ChildQtyTotal  =  (dqtyPer* dparentQty);  

        //for now process level 1
        //processSchPartChild(schMaterialAvailContainer,splant,prodFmActSubDataBaseContainer,bomChild, dchildQtyNeeded,dateTime, hotListContainer,runDate);                
    }          
    schMaterialAvailContainer.fillRedundances();
}

private
SchMaterialAvailContainer getMaterialUsedFromOthers(out decimal dmatUsed,HotListHdr hotListHdr,string schildPart,int ichildSeq, int iparentSrcHotDtlId, DateTime dateTime){
    dmatUsed = 0;

    SchMaterialAvailContainer schMaterialAvailContainer = new SchMaterialAvailContainer();
    schMaterialAvailContainer = readSchMaterialAvailByFilters(hotListHdr.Plant, hotListHdr.Id, 0, iparentSrcHotDtlId, "",-1, schildPart,ichildSeq,dateTime,false,0);

    dmatUsed = schMaterialAvailContainer.getTotalChildPartButNotId(schildPart,ichildSeq, iparentSrcHotDtlId); 
            
    return schMaterialAvailContainer;
}

private
void processSchPartChild(SchMaterialAvailContainer schMaterialAvailContainer,string splant, ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer,Bom bomParent,decimal dqty,DateTime dateTime,HotListContainer hotListContainer,DateTime runDate){
    Bom                         bom             = makeBom(prodFmActSubDataBaseContainer,bomParent.Prod,bomParent.Seq,splant);
    string                      spart           = bomParent.Prod;
    int                         seq             = bomParent.Seq;
    HotList                     hotListChild    = null;
    Bom                         bomChild        = null;
    decimal                     dparentQty      = dqty;
    decimal                     dparentQoh      = 0;
    decimal                     dchildQoh       = 0;
    decimal                     dchildQtyNeeded = 0;
    Inventory                   inventory       = readInventory(spart,splant);
    Inventory                   inventoryChild  = null;    
    SchMaterialAvail            schMaterialAvail= new SchMaterialAvail();
    BomContainer                sumBomContainer = new BomContainer();
    BomContainer                currBomContainer= new BomContainer();  
            
    if (bom!= null && bom.getBomContainer().Count > 0){                           
        if (inventory!= null)
            dparentQoh = inventory.getTotalInventory(seq);

	    BomContainer bomContainer = bom.getBomContainer();
	    for(int i=0; i <  bomContainer.Count;i++){
            bomChild = (Bom)bomContainer[i];
                    
            hotListChild = hotListContainer.getByPartSeq(bomChild.Prod,bomChild.Seq);

            inventoryChild = readInventory(bomChild.Prod,splant);
            if (inventoryChild != null)
                dchildQoh = inventoryChild.getTotalInventory(bomChild.Seq);

            if (i > 0) { 
                schMaterialAvail= new SchMaterialAvail();
                schMaterialAvailContainer.Add(schMaterialAvail);
            }

            schMaterialAvail.ParentPart = spart;
            schMaterialAvail.ParentSeq  = seq;    
            schMaterialAvail.DateTime = dateTime;
                        
            dchildQtyNeeded                 = bomChild.Qty * dparentQty;
            dchildQtyNeeded                 = dchildQoh >= dchildQtyNeeded ?  0 : (dchildQtyNeeded-dchildQoh);

            schMaterialAvail.MaxQty        = dchildQoh / (bomChild.Qty != 0 ? bomChild.Qty:1);
            schMaterialAvail.ChildPart     = bomChild.Prod;
            schMaterialAvail.ChildSeq      = bomChild.Seq;
            schMaterialAvail.ChildQty      = bomChild.Qty;
            schMaterialAvail.ChildAvailQty = dchildQoh;    
            schMaterialAvail.ChildCumulativeQOH = dchildQtyNeeded;          
            schMaterialAvail.ChildQtyTotal  =  (bomChild.Qty* dparentQty);                                            
            processSchPartChild(schMaterialAvailContainer,splant,prodFmActSubDataBaseContainer,bomChild, dchildQtyNeeded,dateTime, hotListContainer,runDate);                
        }

    }    
}

/***************************************************** ProductPlanDt ********************************************/

public
ProductPlanDt createProductPlanDt(){
	return new ProductPlanDt();
}

public
ProductPlanDtContainer createProductPlanDtContainer(){
	return new ProductPlanDtContainer();
}

public
ProductPlanDtContainer readProductPlanDtByFilters(string sfamCfg, int ifamSeq,string spart,int iseq,int rows){
	try{
        ProductPlanDtContainer              productPlanDtContainer = new ProductPlanDtContainer();
        ProdFmActPlanDtDataBaseContainer    prodFmActPlanDtDataBaseContainer = new ProdFmActPlanDtDataBaseContainer(dataBaseAccess);
		prodFmActPlanDtDataBaseContainer.readByFilters(sfamCfg, ifamSeq, spart, iseq, rows);
             
        foreach(ProdFmActPlanDtDataBase prodFmActPlanDtDataBase in prodFmActPlanDtDataBaseContainer){
            ProductPlanDt productPlanDt = objectDataBaseToObject(prodFmActPlanDtDataBase);
            productPlanDtContainer.Add(productPlanDt);
        }
		return productPlanDtContainer;

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}


private
ProductPlanDt objectDataBaseToObject(ProdFmActPlanDtDataBase prodFmActPlanDtDataBase){
	ProductPlanDt productPlanDt = new ProductPlanDt();

	productPlanDt.FamCfg=prodFmActPlanDtDataBase.getPFPD_FamCfg();
	productPlanDt.FamSeq=prodFmActPlanDtDataBase.getPFPD_FamSeq();
	productPlanDt.ProdID=prodFmActPlanDtDataBase.getPFPD_ProdID();
	productPlanDt.Seq=prodFmActPlanDtDataBase.getPFPD_Seq();
	productPlanDt.Qty=prodFmActPlanDtDataBase.getPFPD_Qty();
	productPlanDt.InvUOM=prodFmActPlanDtDataBase.getPFPD_InvUOM();
	productPlanDt.QtyAvail=prodFmActPlanDtDataBase.getPFPD_QtyAvail();
	productPlanDt.ShutYN=prodFmActPlanDtDataBase.getPFPD_ShutYN();
	productPlanDt.MinQty=prodFmActPlanDtDataBase.getPFPD_MinQty();
	productPlanDt.MaxQty=prodFmActPlanDtDataBase.getPFPD_MaxQty();

	return productPlanDt;
}

private
ProdFmActPlanDtDataBase objectToObjectDataBase(ProductPlanDt productPlanDt){
	ProdFmActPlanDtDataBase prodFmActPlanDtDataBase = new ProdFmActPlanDtDataBase(dataBaseAccess);
	prodFmActPlanDtDataBase.setPFPD_FamCfg(productPlanDt.FamCfg);
	prodFmActPlanDtDataBase.setPFPD_FamSeq(productPlanDt.FamSeq);
	prodFmActPlanDtDataBase.setPFPD_ProdID(productPlanDt.ProdID);
	prodFmActPlanDtDataBase.setPFPD_Seq(productPlanDt.Seq);
	prodFmActPlanDtDataBase.setPFPD_Qty(productPlanDt.Qty);
	prodFmActPlanDtDataBase.setPFPD_InvUOM(productPlanDt.InvUOM);
	prodFmActPlanDtDataBase.setPFPD_QtyAvail(productPlanDt.QtyAvail);
	prodFmActPlanDtDataBase.setPFPD_ShutYN(productPlanDt.ShutYN);
	prodFmActPlanDtDataBase.setPFPD_MinQty(productPlanDt.MinQty);
	prodFmActPlanDtDataBase.setPFPD_MaxQty(productPlanDt.MaxQty);

	return prodFmActPlanDtDataBase;
}

public
ProductPlanDt cloneProductPlanDt(ProductPlanDt productPlanDt){
	ProductPlanDt productPlanDtClone = new ProductPlanDt();

	productPlanDtClone.FamCfg=productPlanDt.FamCfg;
	productPlanDtClone.FamSeq=productPlanDt.FamSeq;
	productPlanDtClone.ProdID=productPlanDt.ProdID;
	productPlanDtClone.Seq=productPlanDt.Seq;
	productPlanDtClone.Qty=productPlanDt.Qty;
	productPlanDtClone.InvUOM=productPlanDt.InvUOM;
	productPlanDtClone.QtyAvail=productPlanDt.QtyAvail;
	productPlanDtClone.ShutYN=productPlanDt.ShutYN;
	productPlanDtClone.MinQty=productPlanDt.MinQty;
	productPlanDtClone.MaxQty=productPlanDt.MaxQty;

	return productPlanDtClone;
}

public
SchedulePart scheduleAddSchedulePart(ref ScheduleHdr scheduleHdr,string splant,int imachId,string spart,int seq,decimal qty,DateTime dateTime,bool fromHotList,bool badd,out string smessError){
    SchedulePart   schedulePart = null;
    smessError = "";                        
    try{                        
        SchedulePart        schedulePartOld = null;                        
        Routing             routing         = null;
        string              smessage        = "Part :" + spart + " Seq :" + seq.ToString();

        scheduleHdr = readScheduleHdrLastDateCheck(scheduleHdr,splant);
        if (scheduleHdr == null) { 
            scheduleHdr  = new ScheduleHdr();
            scheduleHdr.Plant = splant;
        }
                                          
        RoutingContainer    routingContainer = getBuildByFilters(splant,spart,seq, imachId,true,false);//find machine        
        if  (routingContainer.Count > 0) {                                                        

            routing = routingContainer[0];
       
            //check if already scheduled
            schedulePartOld = scheduleHdr.SchedulePartContainer.getByMachinePartSeqSameDateBelongsToHotList(imachId,spart,seq,dateTime);
            if (fromHotList && schedulePartOld != null && schedulePartOld.HotListId > 0) 
                smessError = " Already Scheduled : " + smessage;      
            else { 
                
                scheduleHdr.fillRedundances();
                Product product = readProduct(spart);
                if (product!= null){                                    
                    schedulePart = new SchedulePart();
                    schedulePart.MachId     = imachId;
                    schedulePart.MachShow   = routing.Cfg;

                    schedulePart.HdrId      = 0;
                    schedulePart.HotListId  = 0;
                    schedulePart.StartDate  = dateTime;                            
                    schedulePart.Part       = spart;
                    schedulePart.Seq        = seq;                                                            
                    schedulePart.RunStd     = routing.RunStd;
                    schedulePart.CavityNum  = routing.CavityNum;
                    schedulePart.Qty        = Math.Abs(qty);
                    schedulePart.EndDate    = schedulePart.calculateEndDataMachineBuild();
                                       
                    ScheduleReqView scheduleReqViewNew = new ScheduleReqView();
                    scheduleReqViewNew.copy(schedulePart);
                    scheduleHdr.getJobDate(scheduleReqViewNew);   //get Dates to be stored
                    schedulePart.StartDate  = scheduleReqViewNew.StartDate;
                    schedulePart.EndDate    = scheduleReqViewNew.EndDate;

                    //schedule receipts and material consumition
                    generateAutomaticReceiptPart(schedulePart); 
                    BomSumContainer matBomSumContainer = getSubMaterialsMainLevelAndLowerSeqButNotLowerBom(schedulePart.Part,schedulePart.Seq,scheduleHdr.Plant,Constants.STRING_YES,1);
                    generateAutomaticMaterialConsumition(schedulePart,matBomSumContainer);   

                    if (badd) { 
                        scheduleHdr.SchedulePartContainer.Add(schedulePart);
                        scheduleHdr.fillRedundances();
                    }
                }   
            }                                                                                                       
        }else
            smessError = "Sorry, Can Not Find Machine/Routing To Build Part = " + smessage +  ".";        
    
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
    return schedulePart;   
}

/*
public
void recalcAllPartsLevel(string splant){
    try{
        ProductContainer    productContainer= readProductByFilters("","",0,"","",0);
        BomContainer        sumBomContainer = createBomContainer();
        BomContainer        currBomContainer= createBomContainer();
        Product             product         = null;
        Product             productChild    = null;
        Bom                 bom             = null;
        Bom                 bomChild        = null;
        int                 imaxLevel       = 0;
        Hashtable           hashBomSum      = new Hashtable();
        ProdFmInfoDataBaseContainer         prodFmInfoDataBaseContainer   = new ProdFmInfoDataBaseContainer(dataBaseAccess);
	    ProdFmActSubDataBaseContainer       prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
        BomSumDataBaseContainer             bomSumDataBaseContainer = new BomSumDataBaseContainer(dataBaseAccess);
        ArrayList                           arrayListBomsRecords = bomSumDataBaseContainer.readByDisctinctPartSeq();

        prodFmActSubDataBaseContainer.read();        
       
        for (int i=0;i < arrayListBomsRecordsz.Count; i++){
            product= productContainer[i];
            
            bom = getBom(product.ProdID,product.SeqLast,splant,prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,hashBomSum);
            if (bom!= null){
                imaxLevel = 0;
                bom.getMaxLevel(bom,ref imaxLevel);

                for (int ilev=1; ilev <= imaxLevel; ilev++){
                    currBomContainer.Clear();
                    bom.getFromLevel(bom,i,currBomContainer);
                    sumBomContainer.AddRange(currBomContainer);

                    for (int j=0; j < currBomContainer.Count; j++){
                        bomChild = (Bom) currBomContainer[j];

                        productChild = productContainer.getByCode(bomChild.Prod);
                        if (productChild!= null){
                            ProdFmInfoDataBase prodFmInfoDataBase = objectToObjectDataBase(productChild);
                        }
                    }
                }
            }
        }
        
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}
*/

public
void recalcAllPartsLevel(){
    try{        
        BomContainer        sumBomContainer     = createBomContainer();
        BomContainer        currBomContainer    = createBomContainer();                
        Bom                 bom                 = null;
        Bom                 bomChild            = null;
        int                 imaxLevel           = 0;
        string[]            sline               = null;
        string              spart               = "";
        string              splant              = "";
        int                 iseq                = 0;
        Hashtable           hashBomSum          = new Hashtable();
        ProdFmInfoDataBase  prodFmInfoDataBase  = new ProdFmInfoDataBase(dataBaseAccess);
        ProdFmInfoDataBaseContainer         prodFmInfoDataBaseContainer     = new ProdFmInfoDataBaseContainer(dataBaseAccess);
        ProdFmActSubDataBase                prodFmActSubDataBase            = new ProdFmActSubDataBase(dataBaseAccess);
	    ProdFmActSubDataBaseContainer       prodFmActSubDataBaseContainer   = new ProdFmActSubDataBaseContainer(dataBaseAccess);
        BomSumDataBaseContainer             bomSumDataBaseContainer         = new BomSumDataBaseContainer(dataBaseAccess);
        ArrayList                           arrayListBomsRecords            = bomSumDataBaseContainer.readByDisctinctPartSeq();
        PltDataBaseContainer                pltDataBaseContainer            = new PltDataBaseContainer(dataBaseAccess);
        
        
        pltDataBaseContainer.read();
        prodFmInfoDataBaseContainer.read();
        
        prodFmActSubDataBaseContainer.read();
        prodFmInfoDataBase.updateAllLevels(0);     
        prodFmActSubDataBase.updateAllLevels("",0);                  
    
        foreach (PltDataBase pltDataBase in pltDataBaseContainer){            
            splant = pltDataBase.getP_Plt();
           
            for (int i=0;i < arrayListBomsRecords.Count; i++){

                sline   = (string[])arrayListBomsRecords[i];
                spart   = sline[0];
                iseq    = Convert.ToInt32(sline[1]);

                if (spart.ToUpper().Equals("V7346"))
                    spart= spart;
                              
                try{
                    bom = getBom(spart,iseq,splant,prodFmInfoDataBaseContainer,prodFmActSubDataBaseContainer,hashBomSum);
                } catch {
                    bom = null;
                }
                if (bom!= null){
                    imaxLevel = 0;
                    bom.getMaxLevel(bom,ref imaxLevel);

                    for (int ilev=1; ilev <= imaxLevel; ilev++){
                        currBomContainer.Clear();
                        bom.getFromLevel(bom, ilev, currBomContainer);
                    
                        for (int j=0; j < currBomContainer.Count; j++){
                            bomChild = (Bom) currBomContainer[j];

                            prodFmInfoDataBase = prodFmInfoDataBaseContainer.getProdFmInfo(bomChild.Prod);                            
                            if (prodFmInfoDataBase != null){                                
                                prodFmInfoDataBase.setPFS_Level(ilev);
                                prodFmInfoDataBase.updateLevel();                           
                            }

                            prodFmActSubDataBase.setPC_Plt(splant);
                            prodFmActSubDataBase.setPC_ProdID(bomChild.Prod);
                            prodFmActSubDataBase.setPC_Seq(-1); //so will update fro all seqs from that part 
                            prodFmActSubDataBase.setPC_ProdLev(ilev);
                            prodFmActSubDataBase.updateLevelPartSeq();
                        }
                    }
                }
            }
        }
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
Bom getBom( string prodId, int seqId, string splant,
            ProdFmInfoDataBaseContainer prodFmInfoDataBaseContainer, ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer,
            Hashtable hashBomSum){
                          
    Bom bom = makeBom(prodId, seqId, splant,
			    prodFmInfoDataBaseContainer, prodFmActSubDataBaseContainer, hashBomSum);

	return bom;
}


/**************************************** Demand Automatic ****************************************************************/
public
EdiTransTPContainer createEdiTransTPartnerAutomatic(){
    EdiTransTPContainer ediTransTPContainerNew  = new EdiTransTPContainer();
    bool                btransactionStart       =false;
    try{
        EdiTransTPContainer     ediTransTPContainer     = new EdiTransTPContainer();        
        EdiTransTP              ediTransTP              = null;
        int                     j                       = 0;
        int                     i                       = 0;
        string                  stPartner               = "";
        PltDataBaseContainer    pltDataBaseContainer    = new PltDataBaseContainer(dataBaseAccess);
        Hashtable               hashDemandDays          = new Hashtable();
       
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

        pltDataBaseContainer.read();//read all plants

        //load last EdiTransTP per trading partner
        EdiTransTPDataBaseContainer ediTransTPDataBaseContainer = new EdiTransTPDataBaseContainer(dataBaseAccess);
        ediTransTPDataBaseContainer.lastTransTps();
        foreach(EdiTransTPDataBase ediTransTPDataBase in ediTransTPDataBaseContainer)
            ediTransTPContainer.Add(objectDataBaseToObject(ediTransTPDataBase));
    
        dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);  
        
        PlntDataBaseContainer   plntDataBaseContainer   = new PlntDataBaseContainer(dataBaseAccess);        
        RrlhDataBaseContainer   rrlhDataBaseContainer   = new RrlhDataBaseContainer(dataBaseAccess);
        StxhDataBaseContainer   stxhDataBaseContainer   = new StxhDataBaseContainer(dataBaseAccess);
        ArrayList               arrayTParnters          = rrlhDataBaseContainer.getDifferentsTParnter();  
        string                  splant                  = "";
        int                     ilogFrom                = 0;
        int                     ilogTo                  = 0;
        DateTime                dateProcess             = DateUtil.MinValue;
        bool                    bnewAdded               = false;
        ArrayList               arrayTParntersChanged   = new ArrayList();      
        DemandDayContainer      demandDayContainer      = new DemandDayContainer();      
        Hashtable               hashDemand              = new Hashtable();           
    
        plntDataBaseContainer.read();

        for (j=0; j < plntDataBaseContainer.Count; j++) { //loop en each plant
            splant = ((PlntDataBase)plntDataBaseContainer[j]).getYAPLNT();
            //splant = "01";

            if (!splant.Equals("01"))
                continue;

            for (i=0; i < arrayTParnters.Count; i++){//lopp on each trading partner
                stPartner = (string)arrayTParnters[i];
                        
                if (!validTPartners(stPartner))
                   continue; 

                bnewAdded = false;
                ediTransTP= ediTransTPContainer.getByPlantTPartner(splant,stPartner);
                if (ediTransTP == null){    //new tpartner
                    ediTransTP          = new EdiTransTP(); 
                    ediTransTP.Plant    = splant;                                           
                    ediTransTP.TPartner = stPartner;
                    ediTransTP.LogFrom  = 0;
                    ediTransTP.LogTo    = 0;
                    ediTransTPContainerNew.Add(ediTransTP);

                    bnewAdded=true;
                }            

                if (stxhDataBaseContainer.getMinMaxLogsByTrPartner(ediTransTP.Plant,ediTransTP.TPartner,ediTransTP.LogTo, out ilogFrom,out ilogTo,out dateProcess)){
                    if (ilogTo > ediTransTP.LogTo) { 
                        ediTransTP.LogFrom      = bnewAdded ? ilogFrom : ediTransTP.LogTo;
                        ediTransTP.LogTo        = ilogTo;
                        ediTransTP.DateProces   = dateProcess;
                        ediTransTP.DateCreated  = DateTime.Now;
                        if (!bnewAdded)
                            ediTransTPContainerNew.Add(ediTransTP);
                    }
                }            

                if (ediTransTP.LogTo == ilogTo && ilogTo == 0) //if all zero, we do not need to store it
                    ediTransTPContainerNew.Remove(ediTransTP);
            }
            //break;
        }
        //ediTransTP.LogFrom = ediTransTP.LogTo = 116030;//  116192 - 116246;
        //System.Windows.Forms.MessageBox.Show("loadDemandWeek:" + ediTransTPContainerNew.Count);
        for (i=0; i < ediTransTPContainerNew.Count; i++){//lopp on each trading partner
            ediTransTP = ediTransTPContainerNew[i];
                    
            if (!validTPartners(ediTransTP.TPartner))
                continue;
            //System.Windows.Forms.MessageBox.Show("processDemandDayNew Trading:\n\n Plant:" + ediTransTP .Plant + "\n TPartner:" +  ediTransTP.TPartner +"\n LogNum:" + ediTransTP.LogTo.ToString());

            dataBaseAccess.switchConnection(DataBaseAccess.CMS_DATABASE);  
            demandDayContainer = processDemandDayNew(ediTransTP);

            //if anuy changes will be written
            dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);

            processDemandDayLocalDb(demandDayContainer,ediTransTP,hashDemandDays);
            processDemandDayLocalDbEmptyNewRecords(demandDayContainer,hashDemandDays);
            
		    if (!userHandleTransaction)
			    dataBaseAccess.beginTransaction();

            btransactionStart = true;            
            
            ediTransTP.Detail = ediTransTP.Detail + 1;
            if (existsEdiTransTP(ediTransTP.Plant,ediTransTP.TPartner,ediTransTP.Detail))
                updateEdiTransTPInternal(ediTransTP);
            else
                writeEdiTransTPInternal(ediTransTP);                       
                  
            for (j=0; j < demandDayContainer.Count; j++){
                DemandDay demandDay = demandDayContainer[j];         
                if (demandDay.Id > 0)
                    updateDemandDayInt(demandDay);
                else
                    writeDemandDayInt(demandDay);
            }
       
     	    if (!userHandleTransaction)
			    dataBaseAccess.commitTransaction();

            btransactionStart = false;

        }
          
        //System.Windows.Forms.MessageBox.Show("End Save");

        return ediTransTPContainerNew;

    }catch(PersistenceException persistenceException){
        if (btransactionStart && !userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
        if (btransactionStart && !userHandleTransaction)
		    dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}finally{
        dataBaseAccess.switchConnection(DataBaseAccess.NUJIT_DATABASE);  
    }

}

private
bool validTPartners(string stp){
    string      svaluesTp   = "JDAUGUSTA2,JDFOREST,JDHORICON,JDREMAN,JDWATERLOO,JDWORLD";
    string      svalueTp    = "";
    char        csep        = ',';
    string      []slist     = svaluesTp.Split(csep);
    bool        bresult     = false;

    for (int i=0; i < slist.Length && !bresult; i++){
        svalueTp = slist[i];
        if (svalueTp.ToUpper().Equals(stp.ToUpper()))
            bresult = true;
    }

    return bresult;
}

        /*
private
void loadDemandWeek(EdiTransTP ediTransTP,Hashtable hashDemand){
    string                  skey = "";
    ArrayList               arrayTPartner = new ArrayList();
    arrayTPartner.Add(ediTransTP.TPartner);               
    DemandDDataBaseContainer demandDDataBaseContainer = new DemandDDataBaseContainer(dataBaseAccess);
    demandDDataBaseContainer.read830862ByDates(ediTransTP.Plant,DateTime.Now.AddMonths(-2), DateTime.Now.AddMonths(2),DemandD.SOURCE_830,ediTransTP.LogFrom+1,0,arrayTPartner);

    skey = ediTransTP.Plant.ToUpper() + Constants.DEFAULT_SEP + ediTransTP.TPartner.ToUpper();

    if (!hashDemand.Contains(skey))
        hashDemand.Add(skey,demandDDataBaseContainer);
}
*/
private
void processDemandWeek(EdiTransTP ediTransTP,Hashtable hashDemand){
    string                      skey                    = "";
    DemandDDataBaseContainer    demandDDataBaseContainer= new DemandDDataBaseContainer(dataBaseAccess);
    DemandD                     demandD                 = null;
    string                      splant                  = ediTransTP.Plant;
    DemandWeekContainer         demandWeekContainer     = new DemandWeekContainer();
    DemandWeek                  demandWeek              = null;
    DateTime                    monday                  = DateTime.Now;
    Hashtable                   hashNewRels             = new Hashtable();
    DemandWeekContainer         demandWeekContainerNew  = new DemandWeekContainer();
        
    
    skey = ediTransTP.Plant.ToUpper() + Constants.DEFAULT_SEP + ediTransTP.TPartner.ToUpper();

    if (hashDemand.Contains(skey))
        demandDDataBaseContainer = (DemandDDataBaseContainer) hashDemand[skey];

    if (demandDDataBaseContainer.Count > 0){

        for (int i=0; i < demandDDataBaseContainer.Count; i++){
            DemandDDataBase demandDDataBase = (DemandDDataBase)demandDDataBaseContainer[i];
            demandD             = objectDataBaseToObject(demandDDataBase);
            demandWeek          = null;
            monday              = DateUtil.getPriorMondayFromDate(demandD.SDate);

            //check if already loaded
            demandWeek = demandWeekContainerNew.getByFilters(splant, demandD.TPartner, demandD.ShipLoc, demandD.Part, monday);
            if (demandWeek== null) { 
                //search if on db
                demandWeekContainer = readDemandWeekByFilters(splant,"", demandD.TPartner,"","",demandD.ShipLoc,demandD.Part,monday,1);
                if (demandWeekContainer.Count > 0) { 
                    demandWeek = demandWeekContainer[0];
                    demandWeekContainerNew.Add(demandWeek);
                }
            }

            skey = demandD.RelNum.ToUpper() + Constants.DEFAULT_SEP +  DateUtil.getDateRepresentation(demandD.RelDate,DateUtil.MMDDYYYY);

            if (demandWeek == null){
                demandWeek = new DemandWeek();                         
                demandWeek.Plant    = splant;
                demandWeek.Source   = demandD.Source;
                demandWeek.TPartner = demandD.TPartner;                
                demandWeek.NewRelNum= demandD.RelNum;
                demandWeek.RelDate  = demandD.RelDate;
                demandWeek.ShipLoc  = demandD.ShipLoc;
                demandWeek.Part     = demandD.Part;
                demandWeek.FromDate = monday;
                demandWeek.TrlpKeyId= demandD.TrlpKeyId;
                demandWeek.setQtyByDate(demandWeek.FromDate,demandD.NetQty);        
                        
                demandWeekContainerNew.Add(demandWeek);
                if (!hashNewRels.Contains(skey))
                    hashNewRels.Add(skey,demandD);

            }else{                                                      
                if (demandD.RelDate > demandWeek.RelDate && demandD.RelDate != demandWeek.RelDate){
                    if (!hashNewRels.Contains(skey))
                        hashNewRels.Add(skey,demandD);
                }

                if (hashNewRels.Contains(skey)){
                    if (!demandWeek.NewRelNum.ToUpper().Equals(demandD.RelNum.ToUpper())){
                        demandWeek.OldRelNum= demandWeek.NewRelNum;
                        demandWeek.NewRelNum= demandD.RelNum;
                        demandWeek.RelDate  = demandD.RelDate;
                    }                
                    demandWeek.setQtyByDate(demandWeek.FromDate,demandD.NetQty);                
                }
            }
        }

        for (int i=0; i < demandWeekContainerNew.Count; i++){
            demandWeek = demandWeekContainerNew[i];         
            if (demandWeek.Id > 0)
                updateDemandWeek(demandWeek);
            else                
                writeDemandWeek(demandWeek);
        }

    }
}

private
void processDemandDay(DemandDayContainer demandDayContainer,EdiTransTP ediTransTP,Hashtable hashDemand){
    string                      skey                    = "";
    DemandDDataBaseContainer    demandDDataBaseContainer= new DemandDDataBaseContainer(dataBaseAccess);
    DemandD                     demandD                 = null;
    string                      splant                  = ediTransTP.Plant;    
    DemandDay                   demandDay               = null;
    DateTime                    monday                  = DateTime.Now;
    Hashtable                   hashNewRels             = new Hashtable();
    DemandWeekContainer         demandWeekContainerNew  = new DemandWeekContainer();        
    RrlhDataBase                rrlhDataBase            = new RrlhDataBase(dataBaseAccess);
    
    skey = ediTransTP.Plant.ToUpper() + Constants.DEFAULT_SEP + ediTransTP.TPartner.ToUpper();

    if (hashDemand.Contains(skey))
        demandDDataBaseContainer = (DemandDDataBaseContainer) hashDemand[skey];

    if (demandDDataBaseContainer.Count > 0){

        for (int i=0; i < demandDDataBaseContainer.Count; i++){
            DemandDDataBase demandDDataBase = (DemandDDataBase)demandDDataBaseContainer[i];
            demandD             = objectDataBaseToObject(demandDDataBase);
            demandDay           = null;
            monday              = DateUtil.getPriorMondayFromDate(demandD.SDate);

            skey = demandD.RelNum.ToUpper() + Constants.DEFAULT_SEP +  DateUtil.getDateRepresentation(demandD.RelDate,DateUtil.MMDDYYYY);

            demandDay = new DemandDay();
                                
            RrlhDataBaseContainer       rrlhDataBaseContainer       = new RrlhDataBaseContainer(dataBaseAccess);
            rrlhDataBaseContainer.readByFilters("",0,demandD.TPartner,"", demandD.ShipLoc,demandD.Part,0,demandD.LogNum,1);
            if (rrlhDataBaseContainer.Count > 0){
                rrlhDataBase        = (RrlhDataBase)rrlhDataBaseContainer[0];
                demandDay.OldRelNum = rrlhDataBase.getOZREL();

                RrldDataBaseContainer   rrldDataBaseContainer= new RrldDataBaseContainer(dataBaseAccess);
                RrldDataBase            rrldDataBase = null;
                rrldDataBaseContainer.readByFilters(demandD.TPartner,demandD.Part,rrlhDataBase.getOZKEYN(), demandDay.OldRelNum,demandD.SDate,"",decimal.MinValue,"",1);  
                if (rrldDataBaseContainer.Count > 0) {         
                    rrldDataBase = (RrldDataBase)rrldDataBaseContainer[0];
                    demandDay.OldRelDate        = demandD.SDate;
                    demandDay.OldCumRequired    = rrldDataBase.getPLQCUM();
                }
            }

            demandDay.Plant         = splant;
            demandDay.Source        = demandD.Source;
            demandDay.TPartner      = demandD.TPartner;                
            demandDay.NewRelNum     = demandD.RelNum;
            demandDay.RelDate       = demandD.RelDate;
            demandDay.ShipLoc       = demandD.ShipLoc;
            demandDay.Part          = demandD.Part;
            demandDay.RelDate       = demandD.SDate;
            demandDay.CumRequired   = demandD.CurrCum;
            demandDay.TrlpKeyId     = demandD.TrlpKeyId;
            demandDay.LogNum        = demandD.LogNum;

            demandDayContainer.Add(demandDay);            
        }      
    }
}

private
void loadTrlpInfo(Hashtable hash,DemandDay demandDay){         
    string          skey            = Convert.ToInt64(demandDay.TrlpKeyId).ToString()  + Constants.DEFAULT_SEP + demandDay.NewRelNum;
    TrlpDataBase    trlpDataBase    = null;

    if (hash.Contains(skey))
        trlpDataBase = (TrlpDataBase)hash[skey];
    else{
        TrlpDataBaseContainer trlpDataBaseContainer = new TrlpDataBaseContainer(dataBaseAccess);
        trlpDataBaseContainer.readByFilters(demandDay.TPartner,demandDay.ShipLoc,"","", demandDay.Part,0,0,"",demandDay.TrlpKeyId,demandDay.NewRelNum,1);
        if (trlpDataBaseContainer.Count > 0){
            trlpDataBase = (TrlpDataBase)trlpDataBaseContainer[0];

            hash.Add(skey,trlpDataBase);
        }
    }

    if (trlpDataBase!= null){                
        demandDay.OrderNum  = trlpDataBase.getSMORD();
        demandDay.Item      = trlpDataBase.getSMITM();
    }
}
        
private
DemandDayContainer processDemandDayNew(EdiTransTP ediTransTP){
    DemandDayContainer          demandDayContainer      = new DemandDayContainer();    
    DemandDDataBaseContainer    demandDDataBaseContainer= new DemandDDataBaseContainer(dataBaseAccess);    
    string                      splant                  = ediTransTP.Plant;    
    DemandDay                   demandDay               = null;
    DateTime                    monday                  = DateTime.Now;
    Hashtable                   hashNewRels             = new Hashtable();
    DemandWeekContainer         demandWeekContainerNew  = new DemandWeekContainer();        
    RrlhDataBase                rrlhDataBase            = new RrlhDataBase(dataBaseAccess);
    DemandDayContainer          demandDayContainerFound = new DemandDayContainer();
       
    RrlhDataBaseContainer       rrlhDataBaseContainer   = new RrlhDataBaseContainer(dataBaseAccess);
    RrldDataBaseContainer       rrldDataBaseContainer   = new RrldDataBaseContainer(dataBaseAccess);
    RrldDataBase                rrldDataBase            = new RrldDataBase(dataBaseAccess);

    RrlhDataBaseContainer       rrlhDataBaseContainerPrior  = new RrlhDataBaseContainer(dataBaseAccess);
    RrlhDataBase                rrlhDataBasePrior           = new RrlhDataBase(dataBaseAccess);
    Hashtable                   hashTrlp                    = new Hashtable();
        
    rrlhDataBaseContainer.readByFilters(splant,0,ediTransTP.TPartner,"","","",ediTransTP.LogTo,0,0);

    for (int i=0; i < rrlhDataBaseContainer.Count; i++){
        rrlhDataBase = (RrlhDataBase)rrlhDataBaseContainer[i];

        rrldDataBaseContainer   = new RrldDataBaseContainer(dataBaseAccess);
        rrldDataBaseContainer.readByFilters(rrlhDataBase.getOZTRPT(), rrlhDataBase.getOZCPT(),
                                            rrlhDataBase.getOZKEYN(), rrlhDataBase.getOZREL(),DateUtil.MinValue,0);

        rrlhDataBasePrior = null;
        rrlhDataBaseContainerPrior  = new RrlhDataBaseContainer(dataBaseAccess);
        rrlhDataBaseContainerPrior.readByFilters(splant,0,ediTransTP.TPartner,"","",rrlhDataBase.getOZCPT(),0,rrlhDataBase.getOZLOG(),1);
        if (rrlhDataBaseContainerPrior.Count > 0)
            rrlhDataBasePrior = (RrlhDataBase)rrlhDataBaseContainerPrior[0];

        for (int j = 0; j < rrldDataBaseContainer.Count; j++) { 
            rrldDataBase = (RrldDataBase)rrldDataBaseContainer[j];

            demandDay = new DemandDay();
            demandDay.Plant         = splant;
            demandDay.Source        = DemandD.SOURCE_830;
            demandDay.TPartner      = ediTransTP.TPartner;                
            demandDay.NewRelNum     = rrlhDataBase.getOZREL();
            demandDay.OldRelNum     = rrlhDataBasePrior!= null ? rrlhDataBasePrior.getOZREL() : "";
            demandDay.RelDate       = rrldDataBase.getPLRDAT();
            demandDay.ShipLoc       = rrlhDataBase.getOZSTXL();
            demandDay.Part          = rrlhDataBase.getOZCPT();            
            demandDay.CumRequired   = rrldDataBase.getPLQCUM();
            demandDay.TrlpKeyId     = rrlhDataBase.getOZKEYN();
            demandDay.LogNum        = rrlhDataBase.getOZLOG();

            loadTrlpInfo(hashTrlp,demandDay);
           
            demandDayContainer.Add(demandDay);
        }
    }        
    return demandDayContainer;
}

private
void processDemandDayLocalDb(DemandDayContainer demandDayContainer,EdiTransTP ediTransTP,Hashtable hashDemandDays){
    hashDemandDays.Clear();

    DemandDayContainer          demandDayContainerOld   = new DemandDayContainer();
    DemandDay                   demandDay               = null;
    DemandDay                   demandDayPrior          = null;
    DateTime                    monday                  = DateTime.Now;
    DateTime                    sunday                  = DateTime.Now;

    //System.Windows.Forms.MessageBox.Show("On processDemandDayLocalDb , demandDayContainer :" + demandDayContainer.Count);
    
    for (int i=0; i < demandDayContainer.Count; i++){
        demandDay = demandDayContainer[i];

        //try to read prior release, from monday/sunday range
        //DateUtil.getPriorMondayNextSundayFromDate(demandDay.RelDate,out monday,out sunday);
        monday= sunday = demandDay.RelDate; //for now search same date
        demandDayContainerOld = readDemandDayByFilters( demandDay.Plant,demandDay.Source,demandDay.TPartner,demandDay.ShipLoc,
                                                        demandDay.Part,"",demandDay.OldRelNum,0, monday,sunday,false,0);
        if (demandDayContainerOld.Count > 0){            
            //if not found same date , use last date
            bool bprocess=true;
            for (int j=0; j < demandDayContainerOld.Count && bprocess; j++){
                demandDayPrior = demandDayContainerOld[j]; 
                if (DateUtil.sameDate(demandDay.RelDate,demandDayPrior.RelDate))
                    bprocess=false; //fround same date
            }
            demandDay.OldCumRequired = demandDayPrior.CumRequired;
            demandDay.OldRelDate     = demandDayPrior.RelDate;
        }else {
            //check if new rel already added
            demandDayContainerOld = readDemandDayByFilters( demandDay.Plant,demandDay.Source,demandDay.TPartner,demandDay.ShipLoc,
                                                            demandDay.Part,"",demandDay.NewRelNum,0,monday,sunday,false,0);
            if (demandDayContainerOld.Count > 0){                                
                //if not found same date , use last date
                bool bprocess=true;
                for (int j=0; j < demandDayContainerOld.Count && bprocess; j++){
                    demandDayPrior = demandDayContainerOld[j]; 
                    if (DateUtil.sameDate(demandDay.RelDate,demandDayPrior.RelDate))
                        bprocess=false; //fround same date
                }
                demandDay.Id             = demandDayPrior.Id; //so will be updated
                demandDay.OldCumRequired = demandDayPrior.OldCumRequired;
                demandDay.OldRelDate     = demandDayPrior.OldRelDate;
            }

            //if not found we get minor date from RelDate
            demandDayContainerOld = readDemandDayByFilters( demandDay.Plant,demandDay.Source,demandDay.TPartner,demandDay.ShipLoc,
                                                            demandDay.Part,"",demandDay.OldRelNum,0,DateUtil.MinValue,demandDay.RelDate,true,1);
            if (demandDayContainerOld.Count > 0) { 
                demandDayPrior = demandDayContainerOld[0]; 
                demandDay.OldCumRequired = demandDayPrior.CumRequired;
                demandDay.OldRelDate     = demandDayPrior.RelDate;
            }
            
        }    
                
        loadHashDemandDay(hashDemandDays,demandDay);
    }            

    //System.Windows.Forms.MessageBox.Show("End processDemandDayLocalDb , demandDayContainer :" + demandDayContainer.Count);
}

private
void loadHashDemandDay(Hashtable hash,DemandDay demandDay){
    string              skey                = getDemandDayKey(demandDay);
    DemandDayContainer  demandDayContainer  = new DemandDayContainer();

    if (!string.IsNullOrEmpty(demandDay.NewRelNum) && !string.IsNullOrEmpty(demandDay.OldRelNum)) { 
        if (hash.Contains(skey))
            demandDayContainer = (DemandDayContainer)hash[skey];
        else
            hash.Add(skey,demandDayContainer);
    
        demandDayContainer.Add(demandDay);
    }
}

private
string getDemandDayKey(DemandDay demandDay){
    string skey =   demandDay.Plant.ToUpper()   + Constants.DEFAULT_SEP + demandDay.Source.ToUpper() + Constants.DEFAULT_SEP +
                    demandDay.TPartner.ToUpper()+ Constants.DEFAULT_SEP + demandDay.ShipLoc.ToUpper()+ Constants.DEFAULT_SEP +
                    demandDay.Part.ToUpper()    + Constants.DEFAULT_SEP + demandDay.OldRelNum.ToUpper();            
    return skey;
}


private
DemandDayContainer processDemandDayLocalDbEmptyNewRecords(DemandDayContainer demandDayContainer,Hashtable hash){
    DemandDayContainer          demandDayContainerOld   = new DemandDayContainer();
    DemandDay                   demandDay               = null;
    DemandDay                   demandDayFound          = null;
    DemandDay                   demandDayAux            = null;        
    DemandDayContainer          demandDayContainerNew   = new DemandDayContainer();
    DemandDay                   demandDayMinDay         = null;
    DemandDay                   demandDayMaxDay         = null;

    foreach (DemandDayContainer demandDayContainerProcessed in hash.Values){

        demandDayMinDay = demandDayContainerProcessed.getMinorRelDate();
        demandDayMaxDay = demandDayContainerProcessed.getMaxRelDate();                

        if (demandDayContainerProcessed.Count > 0 && demandDayMinDay != null && demandDayMaxDay!= null && 
            !string.IsNullOrEmpty(demandDayContainerProcessed[0].OldRelNum)) { 

            demandDay = demandDayContainerProcessed[0];

            demandDayContainerOld = readDemandDayByFilters( demandDay.Plant,demandDay.Source,demandDay.TPartner,demandDay.ShipLoc,
                                                            demandDay.Part,"",demandDay.OldRelNum,0,DateUtil.minorHour(demandDayMinDay.RelDate),DateUtil.highHour(demandDayMaxDay.RelDate),false,0);

            for (int i=0; i < demandDayContainerOld.Count;i++){
                demandDay       = demandDayContainerOld[i];

                if (demandDay.RelDate >= demandDayMinDay.RelDate){ //rel date old must be at least biggerOrEqual to minor reldate from recently processed

                    demandDayFound  = demandDayContainerProcessed.getIfOldRelAdded(demandDay);
                    if (demandDayFound == null){
                        demandDayAux = cloneDemandDay(demandDayContainerProcessed[0]);

                        demandDayAux.Id = 0;
                        demandDayAux.OldCumRequired                     = demandDay.CumRequired;
                        demandDayAux.RelDate = demandDayAux.OldRelDate  = demandDay.RelDate;

                        demandDayFound = demandDayContainerProcessed.getFirstCloseMinorDate(demandDayAux);
                        if (demandDayFound!= null){
                            demandDayAux.CumRequired = demandDayFound.CumRequired;
                            demandDayContainerNew.Add(demandDayAux);
                        }
                    }
                }
            }
        }            
    } 

    for (int i=0; i < demandDayContainerNew.Count;i++){ //add new added
        demandDay   = demandDayContainerNew[i];
        demandDayContainer.Add(demandDay);                
    }    

    return demandDayContainerNew;
}


public
void justTestDemandDay(){    
    DemandDayContainer          demandDayContainerNew   = new DemandDayContainer();
    Hashtable                   hashDemandDays          = new Hashtable();
    string                      splant                  = "01";

    DemandDayContainer          demandDayContainer = readDemandDayByFilters(splant, "","","","","","",0,DateUtil.MinValue, DateUtil.MinValue,false,0);

    foreach (DemandDay demandDayAux in demandDayContainer)
        loadHashDemandDay(hashDemandDays,demandDayAux);

    demandDayContainerNew = processDemandDayLocalDbEmptyNewRecords(demandDayContainer,hashDemandDays);         

    System.Windows.Forms.MessageBox.Show("demandDayContainerNew Plant : " + splant + "\n" + "new counter:" + demandDayContainerNew.Count);        
    for (int i=0; i < demandDayContainerNew.Count; i++){
        DemandDay demandDay = demandDayContainerNew[i];
        if (demandDay.Id <= 0)
            writeDemandDayInt(demandDay);
    }
    System.Windows.Forms.MessageBox.Show("justTestDemandDay End : " + splant + "\n" + "new counter:" + demandDayContainerNew.Count);        
}

} // class
} // namespace
              