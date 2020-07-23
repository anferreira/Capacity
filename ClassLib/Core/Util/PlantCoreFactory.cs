using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;


namespace Nujit.NujitERP.ClassLib.Core.Util{

/// <summary>
/// Contains all the "plants" functions
/// </summary>
public
class PlantCoreFactory : PlannedCoreFactory{

/// <summary>
/// Constructor
/// </summary>
protected
PlantCoreFactory() : base(){
}

/// <summary>
/// Create a blank Plant object
/// </summary>
/// <returns></returns>
public
Plant createPlant(){
	return new Plant();
}

public
Plt createPlt(){
	return new Plt();
}

/// <summary>
/// Return true if the plant "plt" exists in the database
/// </summary>
/// <param name="plt"></param>
/// <returns></returns>
public
bool existsPlant(string plt){
	
	try{
		PltDataBase pltDataBase = new PltDataBase(dataBaseAccess);
		pltDataBase.setP_Plt(plt);
		return pltDataBase.exists();
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
bool existsPlt(string sdb,int icompany, string splt){
	
	try{
		PlantDataBase plantDataBase = new PlantDataBase(dataBaseAccess);

		plantDataBase.setPL_Db(sdb);
		plantDataBase.setPL_Company(icompany);
		plantDataBase.setPL_Plant(splt);
		
		return plantDataBase.exists();
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Read and return a Plant object
/// </summary>
/// <param name="plt"></param>
/// <returns></returns>
public
Plant readPlant(string plt){
    try{
		PltDataBase pltDataBase = new PltDataBase(dataBaseAccess);
		pltDataBase.setP_Plt(plt);
		pltDataBase.read();

		Plant plant = new Plant();
		
		plant.setPlt(pltDataBase.getP_Plt());
		plant.setName(pltDataBase.getP_PltName());
		plant.setAds1(pltDataBase.getP_Ads1());
		plant.setAds2(pltDataBase.getP_Ads2());
		plant.setAds3(pltDataBase.getP_Ads3());
		plant.setAds4(pltDataBase.getP_Ads4());
		plant.setPltShort(pltDataBase.getP_PltShort());
		
		return plant;
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
Plt readPlt(string sdb,int icompany, string splt){
    try{
		PlantDataBase plantDataBase = new PlantDataBase(dataBaseAccess);

		plantDataBase.setPL_Db(sdb);
		plantDataBase.setPL_Company(icompany);
		plantDataBase.setPL_Plant(splt);

		if (!plantDataBase.exists())
			return null;		

		plantDataBase.read();

		Plt plt = this.objectDataBaseToObject(plantDataBase);
				
		return plt;
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getPltByDesc(string desc,string sdb,int icompany){
	try{
	    PlantDataBaseContainer plantDataBaseContainer = new PlantDataBaseContainer(dataBaseAccess);
	    plantDataBaseContainer.readByDesc(desc,sdb,icompany);

	    string[][] items = new string[plantDataBaseContainer.Count][];

	    int i = 0;
	    for(IEnumerator en = plantDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    PlantDataBase plantDataBase = (PlantDataBase) en.Current;
    			
		    string[] item = new String[4];
		    item[0] = plantDataBase.getPL_Db();
		    item[1] = plantDataBase.getPL_Company().ToString();
		    item[2] = plantDataBase.getPL_Plant();
		    item[3] = plantDataBase.getPL_PltName();
					        			
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

/// <summary>
/// Read and return all Plant codes
/// </summary>
/// <returns></returns>
public
string[] getPlantCodes(){
	try{
	    PltDataBaseContainer pltDataBaseContainer = new PltDataBaseContainer(dataBaseAccess);
	    pltDataBaseContainer.read();

	    string[] vec = new String[pltDataBaseContainer.Count];
	    int index = 0;

	    IEnumerator iEnum = pltDataBaseContainer.GetEnumerator();
	    while(iEnum.MoveNext()){
		    PltDataBase pltDataBase = (PltDataBase)iEnum.Current;
		    vec[index] = pltDataBase.getP_Plt();
		    index++;
	    }

	    return vec;
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Read and return all Plant codes by all fields
/// </summary>
/// <returns></returns>
public
string[][] getPlantsByDesc(string desc){
	try{
	    PltDataBaseContainer pltDataBaseContainer = new PltDataBaseContainer(dataBaseAccess);
	    pltDataBaseContainer.readByDesc(desc);

	    string[][] vec = new String[pltDataBaseContainer.Count][];
	    int index = 0;

	    IEnumerator iEnum = pltDataBaseContainer.GetEnumerator();
	    while(iEnum.MoveNext()){
		    PltDataBase pltDataBase = (PltDataBase)iEnum.Current;
    		
		    string[] v = new String[6];
		    v[0] = pltDataBase.getP_Plt();
		    v[1] = pltDataBase.getP_PltName();
		    v[2] = pltDataBase.getP_Ads1();
		    v[3] = pltDataBase.getP_Ads2();
		    v[4] = pltDataBase.getP_Ads3();
		    v[5] = pltDataBase.getP_Ads4();

		    vec[index] = v;
		    index++;
	    }

	    return vec;
	 }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}


/// <summary>
/// Read and return all the plants in database
/// </summary>
/// <param name="plt"></param>
/// <returns></returns>
public
PlantContainer readAllPlants(){
    PlantContainer plantContainer= new PlantContainer();
    try{
        PltDataBaseContainer pltDBC = new PltDataBaseContainer(dataBaseAccess);
        pltDBC.read();
        
   	    for(IEnumerator en = pltDBC.GetEnumerator(); en.MoveNext(); ){
   	        PltDataBase plt= (PltDataBase)en.Current;
            Plant plant = new Plant(plt.getP_Plt(),plt.getP_PltName(),plt.getP_Ads1(),plt.getP_Ads2(),
                                    plt.getP_Ads3(),plt.getP_Ads4(),plt.getP_PltShort(), plt.getP_DateUpdated());
           
            plantContainer.Add(plant);
        }
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
    return plantContainer;
}

/// <summary>
/// Update the plant object
/// </summary>
/// <param name="plt"></param>
/// <returns></returns>
public 
void updatePlant(Plant plant){
   try{
   
        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
        
        PltDataBase pltDataBase = new PltDataBase(dataBaseAccess);
        pltDataBase.setP_Plt(plant.getPlt());
        pltDataBase.setP_PltName(plant.getName());
        pltDataBase.setP_PltShort(plant.getPltShort());
        pltDataBase.setP_Ads1(plant.getAds1());
        pltDataBase.setP_Ads2(plant.getAds2());
        pltDataBase.setP_Ads3(plant.getAds3());
        pltDataBase.setP_Ads4(plant.getAds4());
        
        pltDataBase.update();
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
void updatePlt(Plt plt){
	try{
   
        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
        
        PlantDataBase plantDataBase = this.objectToObjectDataBase(plt);
        
        plantDataBase.update();
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
/// Insert a new Plant in the database
/// </summary>
/// <param name="plt"></param>
/// <returns></returns>
public 
void insertPlant(Plant plant){
   try{
       if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
			
        PltDataBase pltDataBase = new PltDataBase(dataBaseAccess);
        pltDataBase.setP_Plt(plant.getPlt());
        pltDataBase.setP_PltName(plant.getName());
        pltDataBase.setP_PltShort(plant.getPltShort());
        pltDataBase.setP_Ads1(plant.getAds1());
        pltDataBase.setP_Ads2(plant.getAds2());
        pltDataBase.setP_Ads3(plant.getAds3());
        pltDataBase.setP_Ads4(plant.getAds4());
      		
        pltDataBase.write();
        
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
void writePlt(Plt plt){
	try{
   
        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
        
        PlantDataBase plantDataBase = this.objectToObjectDataBase(plt);
        
        plantDataBase.write();
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
/// Delete a plant from database
/// </summary>
/// <param name="plt"></param>
/// <returns></returns>
public 
void deletePlant(Plant plant){
   try{
   
         if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
			
        PltDataBase pltDataBase = new PltDataBase(dataBaseAccess);
        pltDataBase.setP_Plt(plant.getPlt());
        
        pltDataBase.delete();
        
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
void deletePlt(Plt plt){
	try{
   
        if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
        
        PlantDataBase plantDataBase = this.objectToObjectDataBase(plt);
        
        plantDataBase.delete();
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
/// Check if exist any dept for this plant in the PltDetp table.
/// </summary>
/// <param name="plant"></param>
/// <returns></returns>
public 
bool hasDeptForPlant(string plant){
    try{
     
        PltDeptDataBase pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);
        pltDeptDataBase.setDE_Plt(plant);
        return pltDeptDataBase.hasDeptsForPlant();
     
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

//Plant table ------------------------------------------------------------------------------------------
/// <summary>
/// New methods for the new table Plant 
/// </summary>
/// <param name="companyCode"></param>
/// <returns></returns>

public string[][] getPlantsFromCompanyAsString(string db,int company){
     try{

		PlantDataBaseContainer plantDataBaseContainer= new PlantDataBaseContainer(dataBaseAccess);
		plantDataBaseContainer.read(db,company);
		
		string[][] v = new string[plantDataBaseContainer.Count][];
		for(int i = 0; i < plantDataBaseContainer.Count; i++){
			PlantDataBase plantDataBase = (PlantDataBase)plantDataBaseContainer[i];

			string[] line = new string[4];
			line[0] = plantDataBase.getPL_Plant();
			line[1] = plantDataBase.getPL_PltName();
			line[2] = plantDataBase.getPL_PltShort();
			line[3] = plantDataBase.getPL_Address();
			
			v[i] = line;
		}

		return v;	
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public bool existPlantByCompany(string db,int company){
     try{

		PlantDataBaseContainer plantDataBaseContainer= new PlantDataBaseContainer(dataBaseAccess);
		return plantDataBaseContainer.existPlant(db,company);
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

protected Plt objectDataBaseToObject (PlantDataBase plantDataBase)
{
	Plt plt = new Plt();
		
	plt.setDb(plantDataBase.getPL_Db());
    plt.setCompany(plantDataBase.getPL_Company());
	plt.setPlant(plantDataBase.getPL_Plant());
	plt.setPltName(plantDataBase.getPL_PltName());
	plt.setPltShort(plantDataBase.getPL_PltShort());
	plt.setDateUpdated(plantDataBase.getPL_DateUpdated());
	plt.setAddress(plantDataBase.getPL_Address());
	plt.setDftForSalesForecast(plantDataBase.getPL_DftForSalesForecast());
	plt.setTimezone(plantDataBase.getPL_Timezone());
	plt.setDftReceivetoStkRoom(plantDataBase.getPL_DftReceivetoStkRoom());
	plt.setIntransit(plantDataBase.getPL_Intransit());
	plt.setOutsideServiceStkRoom(plantDataBase.getPL_OutsideServiceStkRoom());
	plt.setShipFromStkLoc(plantDataBase.getPL_ShipFromStkLoc());
	plt.setProdFulFillmentGrp(plantDataBase.getPL_ProdFulFillmentGrp());
	plt.setDistFulFillmentGrp(plantDataBase.getPL_DistFulFillmentGrp());
	plt.setWhsStorageGrp(plantDataBase.getPL_WhsStorageGrp());
	plt.setOutsideStorageGrp(plantDataBase.getPL_OutsideStorageGrp());

	return plt;
}

protected PlantDataBase objectToObjectDataBase (Plt plt)
{	
	PlantDataBase plantDataBase = new PlantDataBase(dataBaseAccess);
		
	plantDataBase.setPL_Db(plt.getDb());
    plantDataBase.setPL_Company(plt.getCompany());
	plantDataBase.setPL_Plant(plt.getPlant());
	plantDataBase.setPL_PltName(plt.getPltName());
	plantDataBase.setPL_PltShort(plt.getPltShort());
	plantDataBase.setPL_DateUpdated(plt.getDateUpdated());
	plantDataBase.setPL_Address(plt.getAddress());
	plantDataBase.setPL_DftForSalesForecast(plt.getDftForSalesForecast());
	plantDataBase.setPL_Timezone(plt.getTimezone());
	plantDataBase.setPL_DftReceivetoStkRoom(plt.getDftReceivetoStkRoom());
	plantDataBase.setPL_Intransit(plt.getIntransit());
	plantDataBase.setPL_OutsideServiceStkRoom(plt.getOutsideServiceStkRoom());
	plantDataBase.setPL_ShipFromStkLoc(plt.getShipFromStkLoc());
	plantDataBase.setPL_ProdFulFillmentGrp(plt.getProdFulFillmentGrp());
	plantDataBase.setPL_DistFulFillmentGrp(plt.getDistFulFillmentGrp());
	plantDataBase.setPL_WhsStorageGrp(plt.getWhsStorageGrp());
	plantDataBase.setPL_OutsideStorageGrp(plt.getOutsideStorageGrp());

	return plantDataBase;
}

} // class

} // namespace