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
class ProccessCoreFactory : PrhistCoreFactory{

protected
ProccessCoreFactory() : base(){
}

/// <summary>
/// Return if exists a proccess
/// </summary>
/// <param name="productCode"></param>
/// <param name="familyCode"></param>
/// <returns></returns>
public
bool existsProccess(string code, bool family){

    try{
	    SchPrFmHrDataBase schPrFmHrDataBase = new SchPrFmHrDataBase(dataBaseAccess);
    	
	    if (family)
		    return schPrFmHrDataBase.existsByFamily(code);
	    else
		    return schPrFmHrDataBase.existsByProduct(code);
    
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Read and return a Proccess object
/// </summary>
/// <param name="productCode"></param>
/// <param name="familyCode"></param>
/// <returns></returns>
public
Proccess readProccess(string code, bool family){
	try{
	    ProdFmActSubDataBaseContainer prodFmActSubDataBaseContainer = new ProdFmActSubDataBaseContainer(dataBaseAccess);
	    BomSumDataBaseContainer bomSumDataBaseContainer = new BomSumDataBaseContainer(dataBaseAccess);
	    SchPrFmHrDataBase schPrFmHrDataBase = new SchPrFmHrDataBase(dataBaseAccess);
    	
	    if (family){
		    bomSumDataBaseContainer.readByFamId(code);
		    prodFmActSubDataBaseContainer.readByFamilyCode(code);
		    schPrFmHrDataBase.readByFamily(code);
    		
		    return new Proccess(code, "", bomSumDataBaseContainer, 
			    prodFmActSubDataBaseContainer, schPrFmHrDataBase);
	    }else{
		    bomSumDataBaseContainer.readByProdId(code);
		    schPrFmHrDataBase.readByProduct(code);
	    }

	    return new Proccess("", code, bomSumDataBaseContainer, 
		    prodFmActSubDataBaseContainer, schPrFmHrDataBase);
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Write to the database a Proccess object
/// </summary>
/// <param name="proccess"></param>
public
void writeProccess(Proccess proccess){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// todo : add here code for insert a proccess
		
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
/// Update a Proccess object
/// </summary>
/// <param name="proccess"></param>
public
void updateProccess(Proccess proccess){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// todo : add here code for update a proccess
		
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
/// Delete a Proccess object
/// </summary>
/// <param name="proccess"></param>
public
void deleteProccess(Proccess proccess){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		// todo : add here code for delete a proccess
		
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

} // class

} // namespace