using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Machines;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.CapacityDemand;


namespace Nujit.NujitERP.ClassLib.Core.Util{


public
class DepartamentCoreFactory : DemandCoreFactory{

protected
DepartamentCoreFactory() : base(){
}

public
bool existsDepartament(string plt, string dept){
    try{
	    PltDeptDataBase pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);
	    pltDeptDataBase.setDE_Plt(plt);
	    pltDeptDataBase.setDE_Dept(dept);
	    return pltDeptDataBase.exists();
	
	}catch(PersistenceException persistenceException){
		 throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }
}

public
Departament createDepartament(){
	return new Departament();
}

public
Departament readDepartament(string plt, string dept){
	Departament departament = null;
	try{
		departament = new Departament();

		PltDeptDataBase pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);
		pltDeptDataBase.setDE_Plt(plt);
		pltDeptDataBase.setDE_Dept(dept);
		pltDeptDataBase.read();
		
        /*
		departament.setDb(pltDeptDataBase.getDE_Db());
		departament.setCompany(pltDeptDataBase.getDE_Company());
		departament.setPlt(pltDeptDataBase.getDE_Plt());
		departament.setDept(pltDeptDataBase.getDE_Dept());
		departament.setDes1(pltDeptDataBase.getDE_Des1());
		departament.setUtilPer(pltDeptDataBase.getDE_UtilPer());
		departament.setDeptShort(pltDeptDataBase.getDE_DeptShort());
        */
        departament = objectDataBaseToObject(pltDeptDataBase);	
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
	return departament;
}

public
void writeDepartament(Departament departament){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		PltDeptDataBase pltDeptDataBase = objectToObjectDataBase(departament);                
		pltDeptDataBase.write();
		
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
void updateDepartament(Departament departament){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		PltDeptDataBase pltDeptDataBase = objectToObjectDataBase(departament);
		pltDeptDataBase.update();
		
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
void deleteDepartament(Departament departament){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		PltDeptDataBase pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);
		pltDeptDataBase.setDE_Plt(departament.getPlt());
		pltDeptDataBase.setDE_Dept(departament.getDept());
		pltDeptDataBase.delete();
		
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
DepartamentContainer readDepartamentsByFilters(string scompany,string splant,string sdept,string sdeptDesc,int rows){
	try{
	    PltDeptDataBaseContainer pltDeptDataBaseContainer = new PltDeptDataBaseContainer(dataBaseAccess);
	    pltDeptDataBaseContainer.readByFilters(scompany, splant, sdept, sdeptDesc, rows);

	    DepartamentContainer deptContainer = new DepartamentContainer();
	    for(IEnumerator en = pltDeptDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    PltDeptDataBase pltDeptDataBase = (PltDeptDataBase) en.Current;    		
            Departament departament = objectDataBaseToObject(pltDeptDataBase);			    
		    deptContainer.Add(departament);

            //get labour task name            
            if (departament.DftLabTaskId > 0) { 
                CapShiftTaskDataBase capShiftTaskDataBase = new CapShiftTaskDataBase(dataBaseAccess);
                capShiftTaskDataBase.setId(departament.DftLabTaskId);
                if (capShiftTaskDataBase.read())
                    departament.TaskNameShow = capShiftTaskDataBase.getTaskName();
            }
        }
    	
	    return deptContainer;
	}catch(PersistenceException persistenceException){
        throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }
}

private
PltDeptDataBase objectToObjectDataBase(Departament departament){
	PltDeptDataBase pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);
	pltDeptDataBase.setDE_Db(departament.getDb());
	pltDeptDataBase.setDE_Company(departament.getCompany());
	pltDeptDataBase.setDE_Plt(departament.getPlt());
	pltDeptDataBase.setDE_Dept(departament.getDept());
	pltDeptDataBase.setDE_Des1(departament.getDes1());
	pltDeptDataBase.setDE_UtilPer(departament.getUtilPer());
	pltDeptDataBase.setDE_DeptShort(departament.getDeptShort());
    pltDeptDataBase.setDE_DftLabTaskId(departament.DftLabTaskId);
    pltDeptDataBase.setDE_NonScheduledDT(departament.NonScheduledDT);
            
    return pltDeptDataBase;
}

private
Departament objectDataBaseToObject(PltDeptDataBase pltDeptDataBase){
	Departament departament = new Departament();

	departament.setDb(pltDeptDataBase.getDE_Db());
	departament.setCompany(pltDeptDataBase.getDE_Company());
	departament.setPlt(pltDeptDataBase.getDE_Plt());
	departament.setDept(pltDeptDataBase.getDE_Dept());
	departament.setDes1(pltDeptDataBase.getDE_Des1());
	departament.setUtilPer(pltDeptDataBase.getDE_UtilPer());
	departament.setDeptShort(pltDeptDataBase.getDE_DeptShort());
    departament.DftLabTaskId = pltDeptDataBase.getDE_DftLabTaskId();
    departament.NonScheduledDT = pltDeptDataBase.getDE_NonScheduledDT();

    return departament;
}

public
DepartamentContainer readDepartamentsByPlt(string plt){
	
	try{
	    PltDeptDataBaseContainer pltDeptDataBaseContainer = new PltDeptDataBaseContainer(dataBaseAccess);
	    pltDeptDataBaseContainer.setDE_Plt(plt);
	    pltDeptDataBaseContainer.readByPlt();

	    DepartamentContainer deptContainer = new DepartamentContainer();
	    for(IEnumerator en = pltDeptDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    PltDeptDataBase pltDeptDataBase = (PltDeptDataBase) en.Current;    		
		    Departament departament = objectDataBaseToObject(pltDeptDataBase);			
		    deptContainer.Add(departament);
	    }
    	
	    return deptContainer;
	 }catch(PersistenceException persistenceException){
		 throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }
}

/// <summary>
/// Read and return all Departaments codes
/// </summary>
/// <returns></returns>
public
string[] getDepartamentCodes(){
	try{
	    PltDeptDataBaseContainer pltDeptDataBaseContainer = new PltDeptDataBaseContainer(dataBaseAccess);
	    return pltDeptDataBaseContainer.getDepartamentCodes();
	
	}catch(PersistenceException persistenceException){
		 throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }
}

/// <summary>
/// Returns all departaments codes for an plant code
/// </summary>
/// <param name="plt"></param>
/// <returns></returns>
public
string[] getDepartamentCodesByPlt(string plt){
	
	try{
	    PltDeptDataBaseContainer pltDeptDataBaseContainer = new PltDeptDataBaseContainer(dataBaseAccess);
	    pltDeptDataBaseContainer.setDE_Plt(plt);
	    pltDeptDataBaseContainer.readByPlt();

	    ArrayList array = new ArrayList();

	    IEnumerator iEnum = pltDeptDataBaseContainer.GetEnumerator();
	    while(iEnum.MoveNext()){
		    PltDeptDataBase pltDeptDataBase = (PltDeptDataBase)iEnum.Current;
    		
		    if (!array.Contains(pltDeptDataBase.getDE_Dept()))
			    array.Add(pltDeptDataBase.getDE_Dept());
	    }

	    string[] vec = new String[array.Count];

	    int index = 0;
	    IEnumerator iEnum2 = array.GetEnumerator();
	    while(iEnum2.MoveNext()){
		    vec[index] = iEnum2.Current.ToString();
		    index++;
	    }
    	
	    return vec;
	}catch(PersistenceException persistenceException){
		 throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }	   
}

public 
string[] getAllDeptFromHotListAsString(){
	try{
		HotListDataBaseContainer hotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);
		hotListDataBaseContainer.readAllDepts();
		
		string[] returnArray = new string[hotListDataBaseContainer.Count];
		int i = 0;

		ArrayList lst = new ArrayList();
		for(IEnumerator en = hotListDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			HotListDataBase hotListDataBase = (HotListDataBase) en.Current;
			returnArray[i] = hotListDataBase.getHOT_Dept();
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
string getDepartamentDescription(string dept){
	
	try{
	
	    PltDeptDataBase pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);
	    pltDeptDataBase.setDE_Dept(dept);
	    pltDeptDataBase.readByDept();
	    return pltDeptDataBase.getDE_Des1();
	
	}catch(PersistenceException persistenceException){
		 throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }	
}

public
bool existsByDept(string sdept){
	try{
		PltDeptDataBase pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);
		pltDeptDataBase.setDE_Dept(sdept);

		return pltDeptDataBase.existsByDept();
	
	}catch(PersistenceException persistenceException){
		 throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }
}

//Veryfy if a plant-Dept has machines in PltDeptMach
public 
bool hasMachineForDept(Departament departament){
    
    try{
    
        PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
        pltDeptMachDataBase.setPDM_Plt(departament.getPlt());
        pltDeptMachDataBase.setPDM_Dept(departament.getDept());
        return pltDeptMachDataBase.hasMachinesForDept();
	
	}catch(PersistenceException persistenceException){
		 throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }      
}

//Veryfy if a plant-Dept has configuration in CapMacCfg table
public 
bool hasConfigurationForDept(Departament departament){
    try{
    
        CapMacCfgDataBase capMacCfgDataBase = new CapMacCfgDataBase(dataBaseAccess);
        capMacCfgDataBase.setCMC_Plt(departament.getPlt());
        capMacCfgDataBase.setCMC_Dept(departament.getDept());
        return capMacCfgDataBase.hasConfigurationForDept();
	
	}catch(PersistenceException persistenceException){
		 throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }      
}

public 
string getPlantCodeByDept(string departamentCode){
	try{
	    PltDeptDataBase pltDeptDataBase = new PltDeptDataBase(dataBaseAccess);
	    pltDeptDataBase.setDE_Dept(departamentCode);
    	
	    if (pltDeptDataBase.existsByDept()){
		    pltDeptDataBase.readByDept();
		    return pltDeptDataBase.getDE_Plt();
	    }else{
		    return "";
	    }
	}catch(PersistenceException persistenceException){
		 throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
    }	
}

public
string[][] getDepartmentByDesc(string desc, string db, int company, string plt){

	try{

		PltDeptDataBaseContainer pltDeptDataBaseContainer = new PltDeptDataBaseContainer(dataBaseAccess);
		pltDeptDataBaseContainer.readByDesc(desc, db, company, plt);

		string[][] items = new string[pltDeptDataBaseContainer.Count][];

		int i = 0;
		for(IEnumerator en = pltDeptDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			PltDeptDataBase pltDeptDataBase = (PltDeptDataBase) en.Current;

			string[] item = new String[5];
			item[0] = pltDeptDataBase.getDE_Db();
			item[1] = pltDeptDataBase.getDE_Company().ToString();
			item[2] = pltDeptDataBase.getDE_Plt();
			item[3] = pltDeptDataBase.getDE_Dept();
			item[4] = pltDeptDataBase.getDE_Des1();

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


} // class

} // namespace