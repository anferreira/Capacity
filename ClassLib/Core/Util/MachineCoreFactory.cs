using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using Nujit.NujitERP.ClassLib.Core.Machines;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Machines;
using Nujit.NujitERP.ClassLib.Core.CapacityDemand;
using Nujit.NujitERP.ClassLib.Common;
using Nujit.NujitERP.ClassLib.Core.Planned;


namespace Nujit.NujitERP.ClassLib.Core.Util{


public
class MachineCoreFactory : MacConfigurationCoreFactory{

protected
MachineCoreFactory() : base(){
}

/// <summary>
/// Read and return all the machine codes
/// </summary>
/// <returns></returns>
public
string[] getMachineCodes(){
    
    try{
	    PltDeptMachDataBaseContainer pltDeptMachDataBaseContainer = new PltDeptMachDataBaseContainer(dataBaseAccess);
	    pltDeptMachDataBaseContainer.read();

	    ArrayList array = new ArrayList();
    	
	    IEnumerator iEnum = pltDeptMachDataBaseContainer.GetEnumerator();
	    while(iEnum.MoveNext()){
		    PltDeptMachDataBase pltDeptMachDataBase = (PltDeptMachDataBase)iEnum.Current;
    		
		    if (!array.Contains(pltDeptMachDataBase.getPDM_Mach()))
			    array.Add(pltDeptMachDataBase.getPDM_Mach());
	    }

	    string[] vec = new String[array.Capacity];

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
string[] getMachineByPartAndSeq(string plant, string dept, string part, int seq){
	try{
		ProdFmActSubDataBase prodFmActSubDataBase = new ProdFmActSubDataBase(dataBaseAccess);
        getProdFmActSubDataBase(out prodFmActSubDataBase, part, seq,plant);
		
		PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
		pltDeptMachDataBase.setPDM_Plt(plant);
		pltDeptMachDataBase.setPDM_Dept(dept);
		pltDeptMachDataBase.setPDM_Mach(prodFmActSubDataBase.getPC_Cfg());
		pltDeptMachDataBase.read();
		
		string[] mach = new string[2];
		mach[0] = pltDeptMachDataBase.getPDM_Mach();
		mach[1] = pltDeptMachDataBase.getPDM_Des1();
		return mach;
				
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[] getMachineCodesByPlt(string plt){
	try{
	    PltDeptMachDataBaseContainer pltDeptMachDataBaseContainer = new PltDeptMachDataBaseContainer(dataBaseAccess);
	    pltDeptMachDataBaseContainer.setPDM_Plt(plt);
	    pltDeptMachDataBaseContainer.readByPlt();

	    int i = 0;
	    string[] vec = new string[pltDeptMachDataBaseContainer.Count];
	    for(IEnumerator en2 = pltDeptMachDataBaseContainer.GetEnumerator(); en2.MoveNext(); ){
		    PltDeptMachDataBase pltDeptMachDataBase = (PltDeptMachDataBase) en2.Current;
		    vec[i] = pltDeptMachDataBase.getPDM_Mach();
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
string[] getMachineCodesByPltDept(string plt, string dept){
	try{
	    PltDeptMachDataBaseContainer pltDeptMachDataBaseContainer = new PltDeptMachDataBaseContainer(dataBaseAccess);
	    pltDeptMachDataBaseContainer.setPDM_Plt(plt);
	    pltDeptMachDataBaseContainer.setPDM_Dept(dept);
	    pltDeptMachDataBaseContainer.readByPltDept();

	    int i = 0;
	    string[] vec = new string[pltDeptMachDataBaseContainer.Count];
	    for(IEnumerator en2 = pltDeptMachDataBaseContainer.GetEnumerator(); en2.MoveNext(); ){
		    PltDeptMachDataBase pltDeptMachDataBase = (PltDeptMachDataBase) en2.Current;
		    vec[i] = pltDeptMachDataBase.getPDM_Mach();
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
string[][] getMachinesByPltDeptAndDesc(string plt, string dept, string searchText){
	try{
		PltDeptMachDataBaseContainer pltDeptMachDataBaseContainer = new PltDeptMachDataBaseContainer(dataBaseAccess);
		pltDeptMachDataBaseContainer.setPDM_Plt(plt);
		pltDeptMachDataBaseContainer.setPDM_Dept(dept);
		pltDeptMachDataBaseContainer.readByPltDeptAndDesc(searchText);

		int i = 0;
		string[][] vec = new string[pltDeptMachDataBaseContainer.Count][];
		for(IEnumerator en2 = pltDeptMachDataBaseContainer.GetEnumerator(); en2.MoveNext(); )
		{
			vec[i] = new string[4];
			vec[i][0] = ((PltDeptMachDataBase)en2.Current).getPDM_Plt();
			vec[i][1] = ((PltDeptMachDataBase)en2.Current).getPDM_Dept();
			vec[i][2] = ((PltDeptMachDataBase)en2.Current).getPDM_Mach();
			vec[i][3] = ((PltDeptMachDataBase)en2.Current).getPDM_Des1();
			i++;
		}
		return vec;
	}
	catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}
	catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getMachinesByPltDept(string plt, string dept){
	try{
		PltDeptMachDataBaseContainer pltDeptMachDataBaseContainer = new PltDeptMachDataBaseContainer(dataBaseAccess);
		pltDeptMachDataBaseContainer.setPDM_Plt(plt);
		pltDeptMachDataBaseContainer.setPDM_Dept(dept);
		pltDeptMachDataBaseContainer.readByPltDept();

		int i = 0;
		string[][] vec = new string[pltDeptMachDataBaseContainer.Count][];
		for(IEnumerator en2 = pltDeptMachDataBaseContainer.GetEnumerator(); en2.MoveNext(); )
		{
			vec[i] = new string[4];
			vec[i][0] = ((PltDeptMachDataBase)en2.Current).getPDM_Plt();
			vec[i][1] = ((PltDeptMachDataBase)en2.Current).getPDM_Dept();
			vec[i][2] = ((PltDeptMachDataBase)en2.Current).getPDM_Mach();
			vec[i][3] = ((PltDeptMachDataBase)en2.Current).getPDM_Des1();
			i++;
		}
		return vec;
	}
	catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}
	catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
Machine[] getMachinesNotInAnyConfiguration(string plt, string dept)
{
	try
	{
		PltDeptMachDataBaseContainer pltDeptMachDataBaseContainer = new PltDeptMachDataBaseContainer(dataBaseAccess);
		pltDeptMachDataBaseContainer.setPDM_Plt(plt);
		pltDeptMachDataBaseContainer.setPDM_Dept(dept);
		pltDeptMachDataBaseContainer.readByPltDeptNotInConfiguration();

		int i = 0;
		Machine[] vec = new Machine[pltDeptMachDataBaseContainer.Count];
		for(IEnumerator en2 = pltDeptMachDataBaseContainer.GetEnumerator(); en2.MoveNext(); )
		{
			//vec[i] = this.objectDatabaseToObject((PltDeptMachDataBase)en2.Current);
			Machine machine = new Machine();
            machine.setId(((PltDeptMachDataBase)en2.Current).getPDM_ID());
			machine.setPlt(((PltDeptMachDataBase)en2.Current).getPDM_Plt());
			machine.setDept(((PltDeptMachDataBase)en2.Current).getPDM_Dept());
			machine.setMach(((PltDeptMachDataBase)en2.Current).getPDM_Mach());
			machine.setDes1(((PltDeptMachDataBase)en2.Current).getPDM_Des1());
			vec[i] = machine;
			i++;
		}
		return vec;

	}
	catch(PersistenceException persistenceException)
	{
		throw new NujitException(persistenceException.Message, persistenceException);
	}
	catch(System.Exception exception)
	{
		throw new NujitException(exception.Message, exception);
	}
}


public
Machine[] getMachinesNotInConfiguration(string plt, string dept, string cfg)
{
	try
	{
		PltDeptMachDataBaseContainer pltDeptMachDataBaseContainer = new PltDeptMachDataBaseContainer(dataBaseAccess);
		pltDeptMachDataBaseContainer.setPDM_Plt(plt);
		pltDeptMachDataBaseContainer.setPDM_Dept(dept);
		pltDeptMachDataBaseContainer.readByPltDeptNotInConfiguration(cfg);

		int i = 0;
		Machine[] vec = new Machine[pltDeptMachDataBaseContainer.Count];
		for(IEnumerator en2 = pltDeptMachDataBaseContainer.GetEnumerator(); en2.MoveNext(); )
		{
			//vec[i] = this.objectDatabaseToObject((PltDeptMachDataBase)en2.Current);
			Machine machine = new Machine();
            machine.setId(((PltDeptMachDataBase)en2.Current).getPDM_ID());
			machine.setPlt(((PltDeptMachDataBase)en2.Current).getPDM_Plt());
			machine.setDept(((PltDeptMachDataBase)en2.Current).getPDM_Dept());
			machine.setMach(((PltDeptMachDataBase)en2.Current).getPDM_Mach());
			machine.setDes1(((PltDeptMachDataBase)en2.Current).getPDM_Des1());
			vec[i] = machine;
			i++;
		}
		return vec;

	}
	catch(PersistenceException persistenceException)
	{
		throw new NujitException(persistenceException.Message, persistenceException);
	}
	catch(System.Exception exception)
	{
		throw new NujitException(exception.Message, exception);
	}
}

public
Machine[] getMachinesFromConfiguration(string plt, string dept, string cfg)
{
	try
	{
		CapMacCfgADataBaseContainer capMacCfgADataBaseContainer = new CapMacCfgADataBaseContainer(dataBaseAccess);
		capMacCfgADataBaseContainer.setCMCA_Plt (plt);
		capMacCfgADataBaseContainer.setCMCA_Dept (dept);
		capMacCfgADataBaseContainer.setCMCA_Cfg (cfg);
		
		capMacCfgADataBaseContainer.readByPltDeptCfg();

		int i = 0;
		Machine[] vec = new Machine[capMacCfgADataBaseContainer.Count];
		for(IEnumerator en2 = capMacCfgADataBaseContainer.GetEnumerator(); en2.MoveNext(); )
		{
			PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
			pltDeptMachDataBase.setPDM_Plt(plt);
			pltDeptMachDataBase.setPDM_Dept(dept);
			pltDeptMachDataBase.setPDM_Mach (((CapMacCfgADataBase)en2.Current).getCMCA_Mach());
			pltDeptMachDataBase.read();
			
			Machine machine = new Machine();
            machine.setId(pltDeptMachDataBase.getPDM_ID());
			machine.setPlt(pltDeptMachDataBase.getPDM_Plt());
			machine.setDept(pltDeptMachDataBase.getPDM_Dept());
			machine.setMach(pltDeptMachDataBase.getPDM_Mach());
			machine.setDes1(pltDeptMachDataBase.getPDM_Des1());
			vec[i] = machine;
			i++;
		}
		return vec;

	}
	catch(PersistenceException persistenceException)
	{
		throw new NujitException(persistenceException.Message, persistenceException);
	}
	catch(System.Exception exception)
	{
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Return if exists a Machine
/// </summary>
/// <param name="PDM_Plt"></param>
/// <param name="PDM_Dept"></param>
/// <param name="PDM_Mach"></param>
/// <returns></returns>
public
bool existsMachine(string PDM_Plt, string PDM_Dept, string PDM_Mach){
	try{
		PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
		
		pltDeptMachDataBase.setPDM_Plt(PDM_Plt);
		pltDeptMachDataBase.setPDM_Dept(PDM_Dept);
		pltDeptMachDataBase.setPDM_Mach(PDM_Mach);

		return pltDeptMachDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Create a blank instance of Machine class : capacity and configuration machine
/// </summary>
/// <returns></returns>
public
Machine createMachine(){
	try{
	    CapMacCfgADataBaseContainer capMacCfgADataBaseContainer = new CapMacCfgADataBaseContainer(dataBaseAccess);
	    CapMacCfgDataBaseContainer capMacCfgDataBaseContainer = new CapMacCfgDataBaseContainer(dataBaseAccess);

	    CapMacShfDataBaseContainer capMacShfDataBaseContainer = new CapMacShfDataBaseContainer(dataBaseAccess);
	    CapMacHrDataBaseContainer capMacHrDataBaseContainer = new CapMacHrDataBaseContainer(dataBaseAccess);
	    CapMacDayDataBaseContainer capMacDayDataBaseContainer = new CapMacDayDataBaseContainer(dataBaseAccess);
	    CapMacWkDataBaseContainer capMacWkDataBaseContainer = new CapMacWkDataBaseContainer(dataBaseAccess);

	    CapCfgShfDataBaseContainer capCfgShfDataBaseContainer = new CapCfgShfDataBaseContainer(dataBaseAccess);
	    CapCfgDayDataBaseContainer capCfgDayDataBaseContainer = new CapCfgDayDataBaseContainer(dataBaseAccess);
	    CapCfgWkDataBaseContainer capCfgWkDataBaseContainer = new CapCfgWkDataBaseContainer(dataBaseAccess);

	    return new Machine(capMacCfgDataBaseContainer, capMacCfgADataBaseContainer, capMacShfDataBaseContainer,
		    capMacHrDataBaseContainer, capMacDayDataBaseContainer, capMacWkDataBaseContainer,
		    capCfgShfDataBaseContainer, capCfgDayDataBaseContainer, capCfgWkDataBaseContainer);
    
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
MachineContainer createMachineContainer(){
	return new MachineContainer();
}

/// <summary>
/// Reads a capacity and configuration machine
/// </summary>
/// <param name="PDM_Plt"></param>
/// <param name="PDM_Dept"></param>
/// <param name="PDM_Mach"></param>
/// <returns></returns>
public
Machine readMachine(string PDM_Plt, string PDM_Dept, string PDM_Mach){
    try{
		PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
		
		pltDeptMachDataBase.setPDM_Plt(PDM_Plt);
		pltDeptMachDataBase.setPDM_Dept(PDM_Dept);
		pltDeptMachDataBase.setPDM_Mach(PDM_Mach);
		pltDeptMachDataBase.read();


		// machine capacity
		CapMacShfDataBaseContainer capMacShfDataBaseContainer = new CapMacShfDataBaseContainer(dataBaseAccess);
		capMacShfDataBaseContainer.setCMS_Plt(PDM_Plt);
		capMacShfDataBaseContainer.setCMS_Dept(PDM_Dept);
		capMacShfDataBaseContainer.setCMS_Mach(PDM_Mach);
		capMacShfDataBaseContainer.readByPltDeptMach();

		CapMacCfgADataBaseContainer capMacCfgADataBaseContainer = new CapMacCfgADataBaseContainer(dataBaseAccess);
		capMacCfgADataBaseContainer.setCMCA_Plt(PDM_Plt);
		capMacCfgADataBaseContainer.setCMCA_Dept(PDM_Dept);
		capMacCfgADataBaseContainer.setCMCA_Mach(PDM_Mach);
		capMacCfgADataBaseContainer.readByPltDeptMach();

		CapMacCfgDataBaseContainer capMacCfgDataBaseContainer = new CapMacCfgDataBaseContainer(dataBaseAccess);
		capMacCfgDataBaseContainer.setPlt(PDM_Plt);
		capMacCfgDataBaseContainer.setDept(PDM_Dept);
		capMacCfgDataBaseContainer.setMach(PDM_Mach);
		capMacCfgDataBaseContainer.readByPltDeptMach();

		CapMacDayDataBaseContainer capMacDayDataBaseContainer = new CapMacDayDataBaseContainer(dataBaseAccess);
		capMacDayDataBaseContainer.setCMD_Plt(PDM_Plt);
		capMacDayDataBaseContainer.setCMD_Dept(PDM_Dept);
		capMacDayDataBaseContainer.setCMD_Mach(PDM_Mach);
		capMacDayDataBaseContainer.readByPltDeptMach();
		
		CapMacHrDataBaseContainer capMacHrDataBaseContainer = new CapMacHrDataBaseContainer(dataBaseAccess);
		capMacHrDataBaseContainer.setCMH_Plt(PDM_Plt);
		capMacHrDataBaseContainer.setCMH_Dept(PDM_Dept);
		capMacHrDataBaseContainer.setCMH_Mach(PDM_Mach);
		capMacHrDataBaseContainer.readByPltDeptMach();
		
		CapMacWkDataBaseContainer capMacWkDataBaseContainer = new CapMacWkDataBaseContainer(dataBaseAccess);
		capMacWkDataBaseContainer.setCMW_Plt(PDM_Plt);
		capMacWkDataBaseContainer.setCMW_Dept(PDM_Dept);
		capMacWkDataBaseContainer.setCMW_Mach(PDM_Mach);
		capMacWkDataBaseContainer.readByPltdeptMach();

		// Cfg capacity
		CapCfgShfDataBaseContainer capCfgShfDataBaseContainer = new CapCfgShfDataBaseContainer(dataBaseAccess);
		capCfgShfDataBaseContainer.setPlt(PDM_Plt);
		capCfgShfDataBaseContainer.setDept(PDM_Dept);
		capCfgShfDataBaseContainer.setMach(PDM_Mach);
		capCfgShfDataBaseContainer.readByPltDeptMach();

		CapCfgDayDataBaseContainer capCfgDayDataBaseContainer = new CapCfgDayDataBaseContainer(dataBaseAccess);
		capCfgDayDataBaseContainer.setPlt(PDM_Plt);
		capCfgDayDataBaseContainer.setDept(PDM_Dept);
		capCfgDayDataBaseContainer.setMach(PDM_Mach);
		capCfgDayDataBaseContainer.readByPltDeptMach();
		
		CapCfgWkDataBaseContainer capCfgWkDataBaseContainer = new CapCfgWkDataBaseContainer(dataBaseAccess);
		capCfgWkDataBaseContainer.setPlt(PDM_Plt);
		capCfgWkDataBaseContainer.setDept(PDM_Dept);
		capCfgWkDataBaseContainer.setMach(PDM_Mach);
		
		Machine machine = new Machine(capMacCfgDataBaseContainer, 
			capMacCfgADataBaseContainer, capMacShfDataBaseContainer, 
			capMacHrDataBaseContainer, capMacDayDataBaseContainer, 
			capMacWkDataBaseContainer, capCfgShfDataBaseContainer, 
			capCfgDayDataBaseContainer, capCfgWkDataBaseContainer);

        copyObjectDatabaseToObject(machine,pltDeptMachDataBase);

        /*
        machine.setId(pltDeptMachDataBase.getPDM_ID());
		machine.setPlt(pltDeptMachDataBase.getPDM_Plt());
		machine.setDept(pltDeptMachDataBase.getPDM_Dept());
		machine.setMach(pltDeptMachDataBase.getPDM_Mach());
		machine.setDes1(pltDeptMachDataBase.getPDM_Des1());
		machine.setDes2(pltDeptMachDataBase.getPDM_Des2());
		machine.setDes3(pltDeptMachDataBase.getPDM_Des3());
		machine.setDes4(pltDeptMachDataBase.getPDM_Des4());
		machine.setPltLoc(pltDeptMachDataBase.getPDM_PltInvLoc());
		machine.setInOut(pltDeptMachDataBase.getPDM_InOut());
		machine.setMachTyp(pltDeptMachDataBase.getPDM_MachTyp());
		machine.setSchType(pltDeptMachDataBase.getPDM_SchType());
		machine.setUtilPer(pltDeptMachDataBase.getPDM_UtilPer());
		machine.setInvDrFr(pltDeptMachDataBase.getPDM_InvDrFr());
		machine.setInvRecTo(pltDeptMachDataBase.getPDM_InvRecTo());
		machine.setCableLn(pltDeptMachDataBase.getPDM_CableLn());
		machine.setLnUom(pltDeptMachDataBase.getPDM_LnUom());
		machine.setSpeed(pltDeptMachDataBase.getPDM_Speed());
		machine.setMaxRacks(pltDeptMachDataBase.getPDM_MaxRacks());
		machine.setDefSpaceRack(pltDeptMachDataBase.getPDM_DefSpaceRack());
		machine.setDefSpaceUom(pltDeptMachDataBase.getPDM_DefSpaceUom());
		machine.setMaxWgt(pltDeptMachDataBase.getPDM_MaxWgt());
		machine.setMaxWgtUom(pltDeptMachDataBase.getPDM_MaxWgtUom());
        machine.setDirectHoursToShifts(pltDeptMachDataBase.getPDM_DirectHoursToShifts());
        */

        loadMachineChilds(machine);

        return machine;
		
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
void loadMachineChilds(Machine machine){
    PltDeptMachDefDataBase pltDeptMachDefDataBase = new PltDeptMachDefDataBase(dataBaseAccess);
        
    pltDeptMachDefDataBase.setMachId(machine.Id);
    if (pltDeptMachDefDataBase.read())
        machine.MachineDef = objectDataBaseToObject(pltDeptMachDefDataBase);
}

private
void loadMachineChilds(MachineContainer machineContainer){
    ArrayList       arrayIds = new ArrayList();
    Hashtable       hashMachines = new Hashtable();
    Machine         machine= null;

    //get machine ids to search for        
    for (int i=0; i < machineContainer.Count; i++){
        machine= machineContainer[i];
        arrayIds.Add(machine.Id);
        if (!hashMachines.Contains(machine.Id))
            hashMachines.Add(machine.Id,machine);
    }

    //read list of mach def and assing to properly machine
    PltDeptMachDefDataBaseContainer pltDeptMachDefDataBaseContainer = new PltDeptMachDefDataBaseContainer(dataBaseAccess);
    pltDeptMachDefDataBaseContainer.readByMachIdIds(arrayIds);
    foreach(PltDeptMachDefDataBase pltDeptMachDefDataBase in pltDeptMachDefDataBaseContainer){
       MachineDef machineDef = objectDataBaseToObject(pltDeptMachDefDataBase);

        if (hashMachines.Contains(machineDef.MachId)) {
            machine = (Machine)hashMachines[machineDef.MachId];
            machine.MachineDef = machineDef;
        }
        
    }
}


public
Machine readMachineById(int id){
    try{
        Machine             machine = null;
		PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);        
        if (!pltDeptMachDataBase.readById(id))
            return null;
        machine = objectDatabaseToObject(pltDeptMachDataBase);
        loadMachineChilds(machine);

        return machine;
		
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
Machine objectDatabaseToObjectOri(PltDeptMachDataBase pltDeptMachDataBase){
    Machine machine = new Machine();
    copyObjectDatabaseToObject(machine,pltDeptMachDataBase);
    return machine;
}

private
void copyObjectDatabaseToObject(Machine machine,PltDeptMachDataBase pltDeptMachDataBase){
    machine.setId(pltDeptMachDataBase.getPDM_ID());
	machine.setPlt(pltDeptMachDataBase.getPDM_Plt());
	machine.setDept(pltDeptMachDataBase.getPDM_Dept());
	machine.setMach(pltDeptMachDataBase.getPDM_Mach());
	machine.setDes1(pltDeptMachDataBase.getPDM_Des1());
	machine.setDes2(pltDeptMachDataBase.getPDM_Des2());
	machine.setDes3(pltDeptMachDataBase.getPDM_Des3());
	machine.setDes4(pltDeptMachDataBase.getPDM_Des4());
	machine.setPltLoc(pltDeptMachDataBase.getPDM_PltInvLoc());
	machine.setInOut(pltDeptMachDataBase.getPDM_InOut());
	machine.setMachTyp(pltDeptMachDataBase.getPDM_MachTyp());
	machine.setSchType(pltDeptMachDataBase.getPDM_SchType());
	machine.setUtilPer(pltDeptMachDataBase.getPDM_UtilPer());
	machine.setInvDrFr(pltDeptMachDataBase.getPDM_InvDrFr());
	machine.setInvRecTo(pltDeptMachDataBase.getPDM_InvRecTo());
	machine.setCableLn(pltDeptMachDataBase.getPDM_CableLn());
	machine.setLnUom(pltDeptMachDataBase.getPDM_LnUom());
	machine.setSpeed(pltDeptMachDataBase.getPDM_Speed());
	machine.setMaxRacks(pltDeptMachDataBase.getPDM_MaxRacks());
	machine.setDefSpaceRack(pltDeptMachDataBase.getPDM_DefSpaceRack());
	machine.setDefSpaceUom(pltDeptMachDataBase.getPDM_DefSpaceUom());
	machine.setMaxWgt(pltDeptMachDataBase.getPDM_MaxWgt());
	machine.setMaxWgtUom(pltDeptMachDataBase.getPDM_MaxWgtUom());
    machine.setDirectHoursToShifts(pltDeptMachDataBase.getPDM_DirectHoursToShifts());    
    machine.Scheduled = pltDeptMachDataBase.getPDM_Scheduled();
}

private
MachineView objectDatabaseToObject(PltDeptMachViewDataBase pltDeptMachViewDataBase){
    MachineView machineView = new MachineView();

    copyObjectDatabaseToObject(machineView, pltDeptMachViewDataBase);
    machineView.DateLastPlanned = pltDeptMachViewDataBase.getDateLastPlanned();
    machineView.Priority = pltDeptMachViewDataBase.getPriority();
    return machineView;
}

/// <summary>
/// Update a capacity and configuration machine
/// </summary>
/// <param name="machine"></param>
public
void updateMachine(Machine machine)
{
	try
	{
		dataBaseAccess.beginTransaction();

		// obtain modified containers, only update's
		CapMacCfgDataBaseContainer machCapMacCfgDataBaseContainer = machine.getCapMacCfgDataBaseContainer();
		CapMacCfgADataBaseContainer machCapMacCfgADataBaseContainer = machine.getCapMacCfgADataBaseContainer();
	
		CapMacHrDataBaseContainer machCapMacHrDataBaseContainer = machine.getCapMacHrDataBaseContainer();
		CapMacShfDataBaseContainer machCapMacShfDataBaseContainer = machine.getCapMacShfDataBaseContainer();
		CapMacDayDataBaseContainer machCapMacDayDataBaseContainer = machine.getCapMacDayDataBaseContainer();

		CapCfgDayDataBaseContainer machCapCfgDayDataBaseContainer = machine.getCapCfgDayDataBaseContainer();
		CapCfgShfDataBaseContainer machCapCfgShfDataBaseContainer = machine.getCapCfgShfDataBaseContainer();
		CapCfgWkDataBaseContainer machCapCfgWkDataBaseContainer = machine.getCapCfgWkDataBaseContainer();

		// obtains old containers
		
		// hours
		CapMacHrDataBaseContainer dbCapMacHrDataBaseContainer = null;
		if (machCapMacHrDataBaseContainer != null)
		{
			dbCapMacHrDataBaseContainer = new CapMacHrDataBaseContainer(machCapMacHrDataBaseContainer.getDataBaseAccess());
			dbCapMacHrDataBaseContainer.setCMH_Plt(machine.getPlt());
			dbCapMacHrDataBaseContainer.setCMH_Dept(machine.getDept());
			dbCapMacHrDataBaseContainer.setCMH_Mach(machine.getMach());
			dbCapMacHrDataBaseContainer.readByPltDeptMach();
		}

		// shifts
		CapMacShfDataBaseContainer dbCapMacShfDataBaseContainer = null;
		if (machCapMacHrDataBaseContainer != null)
		{
			dbCapMacShfDataBaseContainer = new CapMacShfDataBaseContainer(machCapMacHrDataBaseContainer.getDataBaseAccess());
			dbCapMacShfDataBaseContainer.setCMS_Plt(machine.getPlt());
			dbCapMacShfDataBaseContainer.setCMS_Dept(machine.getDept());
			dbCapMacShfDataBaseContainer.setCMS_Mach(machine.getMach());
			dbCapMacShfDataBaseContainer.readByPltDeptMach();
		}
	
		// days
		CapMacDayDataBaseContainer dbCapMacDayDataBaseContainer = null;
		if (machCapMacHrDataBaseContainer != null)
		{
			dbCapMacDayDataBaseContainer = new CapMacDayDataBaseContainer(machCapMacHrDataBaseContainer.getDataBaseAccess());
			dbCapMacDayDataBaseContainer.setCMD_Plt(machine.getPlt());
			dbCapMacDayDataBaseContainer.setCMD_Dept(machine.getDept());
			dbCapMacDayDataBaseContainer.setCMD_Mach(machine.getMach());
			dbCapMacDayDataBaseContainer.readByPltDeptMach();
		}

		// shfifts configurations
		CapCfgShfDataBaseContainer dbCapCfgShfDataBaseContainer = null;
		if (machCapMacHrDataBaseContainer != null)
		{
			dbCapCfgShfDataBaseContainer = new CapCfgShfDataBaseContainer(machCapMacHrDataBaseContainer.getDataBaseAccess());
			dbCapCfgShfDataBaseContainer.setPlt(machine.getPlt());
			dbCapCfgShfDataBaseContainer.setDept(machine.getDept());
			dbCapCfgShfDataBaseContainer.setMach(machine.getMach());
			dbCapCfgShfDataBaseContainer.readByPltDeptMach();
		}

		// days configurations
		CapCfgDayDataBaseContainer dbCapCfgDayDataBaseContainer = null;
		if (machCapMacHrDataBaseContainer != null)
		{
			dbCapCfgDayDataBaseContainer = new CapCfgDayDataBaseContainer(machCapMacHrDataBaseContainer.getDataBaseAccess());
			dbCapCfgDayDataBaseContainer.setPlt(machine.getPlt());
			dbCapCfgDayDataBaseContainer.setDept(machine.getDept());
			dbCapCfgDayDataBaseContainer.setMach(machine.getMach());
			dbCapCfgDayDataBaseContainer.readByPltDeptMach();
		}

		// weeks configurations
		CapCfgWkDataBaseContainer dbCapCfgWkDataBaseContainer = null;
		if (machCapMacHrDataBaseContainer != null)
		{
			dbCapCfgWkDataBaseContainer = new CapCfgWkDataBaseContainer(machCapMacHrDataBaseContainer.getDataBaseAccess());
			dbCapCfgWkDataBaseContainer.setPlt(machine.getPlt());
			dbCapCfgWkDataBaseContainer.setDept(machine.getDept());
			dbCapCfgWkDataBaseContainer.setMach(machine.getMach());
			dbCapCfgWkDataBaseContainer.readByPltDeptMach();
		}

		// old configurations
		if (dbCapCfgDayDataBaseContainer != null)
			dbCapCfgDayDataBaseContainer.delete();
		if (dbCapCfgShfDataBaseContainer != null)
			dbCapCfgShfDataBaseContainer.delete();
		if (dbCapCfgWkDataBaseContainer != null)
			dbCapCfgWkDataBaseContainer.delete();
	
		// new configurations
		if (machCapCfgDayDataBaseContainer != null)
			machCapCfgDayDataBaseContainer.write();
		if (machCapCfgShfDataBaseContainer != null)
			machCapCfgShfDataBaseContainer.write();
		if (machCapCfgWkDataBaseContainer != null)
			machCapCfgWkDataBaseContainer.write();

		// old containers
		if (dbCapMacShfDataBaseContainer != null)
			dbCapMacShfDataBaseContainer.delete();
		if (dbCapMacHrDataBaseContainer != null)
			dbCapMacHrDataBaseContainer.delete();
		if (dbCapMacDayDataBaseContainer != null)
			dbCapMacDayDataBaseContainer.delete();

		// new containers
		if (machCapMacHrDataBaseContainer != null)
			machCapMacHrDataBaseContainer.write();
		if (machCapMacDayDataBaseContainer != null)
			machCapMacDayDataBaseContainer.write();
		if (machCapMacShfDataBaseContainer != null)
			machCapMacShfDataBaseContainer.write();

		// update totals
		if (machCapMacCfgDataBaseContainer != null)
			machCapMacCfgDataBaseContainer.update();

		// FN 01.31.05
		// update machine data
		updateMachineInternal(machine);

		// commits all changes to disk
		dataBaseAccess.commitTransaction();
	}
	catch(PersistenceException persistenceException)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}
	catch(System.Exception exception)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
void updateMachineInternal(Machine machine){
    PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
	
	pltDeptMachDataBase.setPDM_CableLn (machine.getCableLn());
	pltDeptMachDataBase.setPDM_DefSpaceRack (machine.getDefSpaceRack());
	pltDeptMachDataBase.setPDM_DefSpaceUom (machine.getDefSpaceUom());
	pltDeptMachDataBase.setPDM_Dept (machine.getDept());
	pltDeptMachDataBase.setPDM_Des1 (machine.getDes1());
	pltDeptMachDataBase.setPDM_Des2 (machine.getDes2());
	pltDeptMachDataBase.setPDM_Des3 (machine.getDes3());
	pltDeptMachDataBase.setPDM_Des4 (machine.getDes4());
	pltDeptMachDataBase.setPDM_InOut (machine.getInOut());
	pltDeptMachDataBase.setPDM_InvDrFr (machine.getInvDrFr());
	pltDeptMachDataBase.setPDM_InvRecTo (machine.getInvRecTo());
	pltDeptMachDataBase.setPDM_LnUom (machine.getLnUom());
	pltDeptMachDataBase.setPDM_Mach (machine.getMach());
	//		pltDeptMachDataBase.setPDM_MachShort (machine.get
	pltDeptMachDataBase.setPDM_MachTyp (machine.getMachTyp());
	pltDeptMachDataBase.setPDM_MaxRacks (machine.getMaxRacks());
	pltDeptMachDataBase.setPDM_MaxWgt (machine.getMaxWgt());
	pltDeptMachDataBase.setPDM_MaxWgtUom (machine.getMaxWgtUom());
	pltDeptMachDataBase.setPDM_Plt (machine.getPlt());
	pltDeptMachDataBase.setPDM_PltInvLoc (machine.getPltLoc());
	pltDeptMachDataBase.setPDM_SchType (machine.getSchType());
	pltDeptMachDataBase.setPDM_Speed (machine.getSpeed());
	pltDeptMachDataBase.setPDM_UtilPer (machine.getUtilPer());
    pltDeptMachDataBase.setPDM_Scheduled(machine.Scheduled);

    if (machine.MachineDef!=null){//machine default
        PltDeptMachDefDataBase pltDeptMachDefDataBase = objectToObjectDataBase(machine.MachineDef);
        if (pltDeptMachDefDataBase.exists())    pltDeptMachDefDataBase.update();
        else                                    pltDeptMachDefDataBase.write();
    }

	pltDeptMachDataBase.update();

}

public
void writeMachine(Machine machine)
{
	try
	{
		dataBaseAccess.beginTransaction();

		// obtain modified containers, only update's
		CapMacCfgDataBaseContainer machCapMacCfgDataBaseContainer = machine.getCapMacCfgDataBaseContainer();
		CapMacCfgADataBaseContainer machCapMacCfgADataBaseContainer = machine.getCapMacCfgADataBaseContainer();
	
		CapMacHrDataBaseContainer machCapMacHrDataBaseContainer = machine.getCapMacHrDataBaseContainer();
		CapMacShfDataBaseContainer machCapMacShfDataBaseContainer = machine.getCapMacShfDataBaseContainer();
		CapMacDayDataBaseContainer machCapMacDayDataBaseContainer = machine.getCapMacDayDataBaseContainer();

		CapCfgDayDataBaseContainer machCapCfgDayDataBaseContainer = machine.getCapCfgDayDataBaseContainer();
		CapCfgShfDataBaseContainer machCapCfgShfDataBaseContainer = machine.getCapCfgShfDataBaseContainer();
		CapCfgWkDataBaseContainer machCapCfgWkDataBaseContainer = machine.getCapCfgWkDataBaseContainer();

		if (machCapCfgDayDataBaseContainer != null)
			machCapCfgDayDataBaseContainer.write();
		if (machCapCfgShfDataBaseContainer != null)
			machCapCfgShfDataBaseContainer.write();
		if (machCapCfgWkDataBaseContainer != null)
			machCapCfgWkDataBaseContainer.write();
		if (machCapMacHrDataBaseContainer != null)
			machCapMacHrDataBaseContainer.write();
		if (machCapMacDayDataBaseContainer != null)
			machCapMacDayDataBaseContainer.write();
		if (machCapMacShfDataBaseContainer != null)
			machCapMacShfDataBaseContainer.write();

		if (machCapMacCfgDataBaseContainer != null)
			machCapMacCfgDataBaseContainer.write();

		PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
	
		pltDeptMachDataBase.setPDM_CableLn (machine.getCableLn());
		pltDeptMachDataBase.setPDM_DefSpaceRack (machine.getDefSpaceRack());
		pltDeptMachDataBase.setPDM_DefSpaceUom (machine.getDefSpaceUom());
		pltDeptMachDataBase.setPDM_Dept (machine.getDept());
		pltDeptMachDataBase.setPDM_Des1 (machine.getDes1());
		pltDeptMachDataBase.setPDM_Des2 (machine.getDes2());
		pltDeptMachDataBase.setPDM_Des3 (machine.getDes3());
		pltDeptMachDataBase.setPDM_Des4 (machine.getDes4());
		pltDeptMachDataBase.setPDM_InOut (machine.getInOut());
		pltDeptMachDataBase.setPDM_InvDrFr (machine.getInvDrFr());
		pltDeptMachDataBase.setPDM_InvRecTo (machine.getInvRecTo());
		pltDeptMachDataBase.setPDM_LnUom (machine.getLnUom());
		pltDeptMachDataBase.setPDM_Mach (machine.getMach());
		//		pltDeptMachDataBase.setPDM_MachShort (machine.get
		pltDeptMachDataBase.setPDM_MachTyp (machine.getMachTyp());
		pltDeptMachDataBase.setPDM_MaxRacks (machine.getMaxRacks());
		pltDeptMachDataBase.setPDM_MaxWgt (machine.getMaxWgt());
		pltDeptMachDataBase.setPDM_MaxWgtUom (machine.getMaxWgtUom());
		pltDeptMachDataBase.setPDM_Plt (machine.getPlt());
		pltDeptMachDataBase.setPDM_PltInvLoc (machine.getPltLoc());
		pltDeptMachDataBase.setPDM_SchType (machine.getSchType());
		pltDeptMachDataBase.setPDM_Speed (machine.getSpeed());
		pltDeptMachDataBase.setPDM_UtilPer (machine.getUtilPer());

        //default
        if (machine.MachineDef != null){
            PltDeptMachDefDataBase pltDeptMachDefDataBase = objectToObjectDataBase(machine.MachineDef);
            pltDeptMachDefDataBase.write();
        }            

		pltDeptMachDataBase.write();

       
		// commits all changes to disk
		dataBaseAccess.commitTransaction();
	}
	catch(PersistenceException persistenceException)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}
	catch(System.Exception exception)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public
void deleteMachine (Machine machine)
{
	try
	{
		dataBaseAccess.beginTransaction();

		CapMacCfgADataBase capMacCfgADataBase = new CapMacCfgADataBase(dataBaseAccess);

		capMacCfgADataBase.setCMCA_Plt (machine.getPlt());
		capMacCfgADataBase.setCMCA_Dept (machine.getDept());
		capMacCfgADataBase.setCMCA_Mach (machine.getMach());

		capMacCfgADataBase.deleteFromAllCfgs();

		PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);

		pltDeptMachDataBase.setPDM_Plt (machine.getPlt());
		pltDeptMachDataBase.setPDM_Dept (machine.getDept());
		pltDeptMachDataBase.setPDM_Mach (machine.getMach());

        //default
        PltDeptMachDefDataBase pltDeptMachDefDataBase = new PltDeptMachDefDataBase(dataBaseAccess);
        pltDeptMachDefDataBase.setMachId(machine.Id);
        pltDeptMachDefDataBase.delete();

		pltDeptMachDataBase.delete();

		dataBaseAccess.commitTransaction();
	}
	catch(PersistenceException persistenceException)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}
	catch(System.Exception exception)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
bool existPltDeptMachShf(string plt,string dept, string mach,string shift,DateTime start,DateTime end){
	bool exit = false;

	try{	
		CapMacHrDataBaseContainer capMacHr = new CapMacHrDataBaseContainer(dataBaseAccess);
		
		capMacHr.setCMH_Plt(plt);
		capMacHr.setCMH_Dept(dept);	
		capMacHr.setCMH_Mach(mach);
		capMacHr.setCMH_Shf(shift);
		capMacHr.readByPltDeptMachShf(start,end);

		if (capMacHr.Count > 0)
			exit = true;
		return exit;

	}catch(PersistenceException persistenceException){
		    throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
	}
}

public
string[] getAllCfgFromHotListAsString(){
    
    try{
	
	    HotListDataBaseContainer hotListDataBaseContainer = new HotListDataBaseContainer(dataBaseAccess);
	    return hotListDataBaseContainer.getAllCfgFromHotListAsString();
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
	}
}

public override
string generateShcByMachine(string plt, string dept,string part, int seq){

    try{
        string machine ="";
        MeHistMachDtlDataBaseContainer meHistMachDtlDataBaseContainer= new MeHistMachDtlDataBaseContainer(dataBaseAccess);
        string[][] vecMachines =  meHistMachDtlDataBaseContainer.generateShcByMachine(plt,dept,part,seq);
      
        if (vecMachines.Length==0)//there are no machines for that plt,dept,part,seq.
            return machine;
       
        machine = vecMachines[0][0];
        decimal totHours=decimal.Parse(vecMachines[0][4]);
        
        for (int i = 0; i < vecMachines.Length ; i++){
            string[] lineMach = vecMachines[i];
            if (totHours <  decimal.Parse(lineMach[4])){
                totHours = decimal.Parse(lineMach[4]);
                machine = lineMach[0];
            }
        }
        return machine;
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
    }catch(System.Exception exception){
	    throw new NujitException(exception.Message, exception);
	}

}

public void removeMachineFromConfiguration (Machine machine, MacConfiguration configuration)
{
	try
	{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CapMacCfgADataBase capMacCfgADataBase = new CapMacCfgADataBase(dataBaseAccess);

		capMacCfgADataBase.setCMCA_Plt (machine.getPlt());
		capMacCfgADataBase.setCMCA_Dept (machine.getDept());
		capMacCfgADataBase.setCMCA_Mach (machine.getMach());
		capMacCfgADataBase.setCMCA_Cfg (configuration.getCfg());

		capMacCfgADataBase.delete();

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
	}
	catch(PersistenceException persistenceException)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}
	catch(System.Exception exception)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public void removeMachineFromAllConfigurations (Machine machine)
{
	try
	{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CapMacCfgADataBase capMacCfgADataBase = new CapMacCfgADataBase(dataBaseAccess);

		capMacCfgADataBase.setCMCA_Plt (machine.getPlt());
		capMacCfgADataBase.setCMCA_Dept (machine.getDept());
		capMacCfgADataBase.setCMCA_Mach (machine.getMach());

		capMacCfgADataBase.deleteFromAllCfgs();

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
	}
	catch(PersistenceException persistenceException)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}
	catch(System.Exception exception)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
void addMachineToCfg (Machine machine, MacConfiguration configuration)
{
	try
	{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CapMacCfgADataBase capMacCfgADataBase = new CapMacCfgADataBase(dataBaseAccess);

		capMacCfgADataBase.setCMCA_Plt (machine.getPlt());
		capMacCfgADataBase.setCMCA_Dept (machine.getDept());
		capMacCfgADataBase.setCMCA_Mach (machine.getMach());
		capMacCfgADataBase.setCMCA_Cfg (configuration.getCfg());
		capMacCfgADataBase.setCMCA_MachTyp (machine.getMachTyp());

		capMacCfgADataBase.write();

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();
	}
	catch(PersistenceException persistenceException)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message, persistenceException);
	}
	catch(System.Exception exception)
	{
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

private Machine objectDatabaseToObject (PltDeptMachDataBase pltDeptMachDataBase)
{
	string PDM_Plt = pltDeptMachDataBase.getPDM_Plt();
	string PDM_Dept = pltDeptMachDataBase.getPDM_Dept();
	string PDM_Mach = pltDeptMachDataBase.getPDM_Mach();

	CapMacShfDataBaseContainer capMacShfDataBaseContainer = new CapMacShfDataBaseContainer(dataBaseAccess);
	capMacShfDataBaseContainer.setCMS_Plt(PDM_Plt);
	capMacShfDataBaseContainer.setCMS_Dept(PDM_Dept);
	capMacShfDataBaseContainer.setCMS_Mach(PDM_Mach);
	capMacShfDataBaseContainer.readByPltDeptMach();

	CapMacCfgADataBaseContainer capMacCfgADataBaseContainer = new CapMacCfgADataBaseContainer(dataBaseAccess);
	capMacCfgADataBaseContainer.setCMCA_Plt(PDM_Plt);
	capMacCfgADataBaseContainer.setCMCA_Dept(PDM_Dept);
	capMacCfgADataBaseContainer.setCMCA_Mach(PDM_Mach);
	capMacCfgADataBaseContainer.readByPltDeptMach();

	CapMacCfgDataBaseContainer capMacCfgDataBaseContainer = new CapMacCfgDataBaseContainer(dataBaseAccess);
	capMacCfgDataBaseContainer.setPlt(PDM_Plt);
	capMacCfgDataBaseContainer.setDept(PDM_Dept);
	capMacCfgDataBaseContainer.setMach(PDM_Mach);
	capMacCfgDataBaseContainer.readByPltDeptMach();

	CapMacDayDataBaseContainer capMacDayDataBaseContainer = new CapMacDayDataBaseContainer(dataBaseAccess);
	capMacDayDataBaseContainer.setCMD_Plt(PDM_Plt);
	capMacDayDataBaseContainer.setCMD_Dept(PDM_Dept);
	capMacDayDataBaseContainer.setCMD_Mach(PDM_Mach);
	capMacDayDataBaseContainer.readByPltDeptMach();
	
	CapMacHrDataBaseContainer capMacHrDataBaseContainer = new CapMacHrDataBaseContainer(dataBaseAccess);
	capMacHrDataBaseContainer.setCMH_Plt(PDM_Plt);
	capMacHrDataBaseContainer.setCMH_Dept(PDM_Dept);
	capMacHrDataBaseContainer.setCMH_Mach(PDM_Mach);
	capMacHrDataBaseContainer.readByPltDeptMach();
	
	CapMacWkDataBaseContainer capMacWkDataBaseContainer = new CapMacWkDataBaseContainer(dataBaseAccess);
	capMacWkDataBaseContainer.setCMW_Plt(PDM_Plt);
	capMacWkDataBaseContainer.setCMW_Dept(PDM_Dept);
	capMacWkDataBaseContainer.setCMW_Mach(PDM_Mach);
	capMacWkDataBaseContainer.readByPltdeptMach();

	// Cfg capacity
	CapCfgShfDataBaseContainer capCfgShfDataBaseContainer = new CapCfgShfDataBaseContainer(dataBaseAccess);
	capCfgShfDataBaseContainer.setPlt(PDM_Plt);
	capCfgShfDataBaseContainer.setDept(PDM_Dept);
	capCfgShfDataBaseContainer.setMach(PDM_Mach);
	capCfgShfDataBaseContainer.readByPltDeptMach();

	CapCfgDayDataBaseContainer capCfgDayDataBaseContainer = new CapCfgDayDataBaseContainer(dataBaseAccess);
	capCfgDayDataBaseContainer.setPlt(PDM_Plt);
	capCfgDayDataBaseContainer.setDept(PDM_Dept);
	capCfgDayDataBaseContainer.setMach(PDM_Mach);
	capCfgDayDataBaseContainer.readByPltDeptMach();
	
	CapCfgWkDataBaseContainer capCfgWkDataBaseContainer = new CapCfgWkDataBaseContainer(dataBaseAccess);
	capCfgWkDataBaseContainer.setPlt(PDM_Plt);
	capCfgWkDataBaseContainer.setDept(PDM_Dept);
	capCfgWkDataBaseContainer.setMach(PDM_Mach);
	
	Machine machine = new Machine(capMacCfgDataBaseContainer, 
		capMacCfgADataBaseContainer, capMacShfDataBaseContainer, 
		capMacHrDataBaseContainer, capMacDayDataBaseContainer, 
		capMacWkDataBaseContainer, capCfgShfDataBaseContainer, 
		capCfgDayDataBaseContainer, capCfgWkDataBaseContainer);

    machine.setId(pltDeptMachDataBase.getPDM_ID());
	machine.setPlt(pltDeptMachDataBase.getPDM_Plt());
	machine.setDept(pltDeptMachDataBase.getPDM_Dept());
	machine.setMach(pltDeptMachDataBase.getPDM_Mach());
	machine.setDes1(pltDeptMachDataBase.getPDM_Des1());
	machine.setDes2(pltDeptMachDataBase.getPDM_Des2());
	machine.setDes3(pltDeptMachDataBase.getPDM_Des3());
	machine.setDes4(pltDeptMachDataBase.getPDM_Des4());
	machine.setPltLoc(pltDeptMachDataBase.getPDM_PltInvLoc());
	machine.setInOut(pltDeptMachDataBase.getPDM_InOut());
	machine.setMachTyp(pltDeptMachDataBase.getPDM_MachTyp());
	machine.setSchType(pltDeptMachDataBase.getPDM_SchType());
	machine.setUtilPer(pltDeptMachDataBase.getPDM_UtilPer());
	machine.setInvDrFr(pltDeptMachDataBase.getPDM_InvDrFr());
	machine.setInvRecTo(pltDeptMachDataBase.getPDM_InvRecTo());
	machine.setCableLn(pltDeptMachDataBase.getPDM_CableLn());
	machine.setLnUom(pltDeptMachDataBase.getPDM_LnUom());
	machine.setSpeed(pltDeptMachDataBase.getPDM_Speed());
	machine.setMaxRacks(pltDeptMachDataBase.getPDM_MaxRacks());
	machine.setDefSpaceRack(pltDeptMachDataBase.getPDM_DefSpaceRack());
	machine.setDefSpaceUom(pltDeptMachDataBase.getPDM_DefSpaceUom());
	machine.setMaxWgt(pltDeptMachDataBase.getPDM_MaxWgt());
	machine.setMaxWgtUom(pltDeptMachDataBase.getPDM_MaxWgtUom());

	return machine;
}

public
MachineContainer readMachinesByFilters(string smachine, string sdes1, string plant, string sdept,string scheduled,bool bonlyHeader,int rows){
	try{
        MachineContainer machineContainer = new MachineContainer();
        PltDeptMachDataBaseContainer pltDeptMachDataBaseContainer = new PltDeptMachDataBaseContainer(dataBaseAccess);
		pltDeptMachDataBaseContainer.readByFilters(smachine, sdes1, plant, sdept, scheduled,rows);

        foreach(PltDeptMachDataBase pltDeptMachDataBase in pltDeptMachDataBaseContainer){
            Machine machine = objectDatabaseToObjectOri(pltDeptMachDataBase);
            if (!bonlyHeader)
                loadMachineChilds(machine);
            machineContainer.Add(machine);
        }
		return machineContainer;

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
MachineContainer readMachinesViewByFilters(string smachine, string sdes1, string plant, string sdept,string scheduled,DateTime planDate,ArrayList arrayMachineIds,bool bonlyHeader,int rows){
	try{
        MachineContainer                    machineContainer = new MachineContainer();
        PltDeptMachViewDataBaseContainer    pltDeptMachViewDataBaseContainer = new PltDeptMachViewDataBaseContainer(dataBaseAccess);
		pltDeptMachViewDataBaseContainer.readByFilters(smachine, sdes1, plant, sdept,scheduled, planDate, arrayMachineIds,rows);
       
        //read cap shift profile
        DateTime                    priorMonday = DateTime.Now;
        DateTime                    nextSunday = DateTime.Now;        
        CapShiftProfileContainer    capShiftProfileContainer = new CapShiftProfileContainer();
        CapShiftProfile             capShiftProfile = null;
        int                         icountShifts=0;
        int                         icountRemainsShifts=0;

        DateUtil.getPriorMondayNextSundayFromDate(DateTime.Now,out priorMonday,out nextSunday);

        for (int i=1; i <= 5; i++) { //not more than 5 shifts
            CapShiftProfileContainer capShiftProfileContainerAux = readCapShiftProfileByExactlyDatesFilters(plant,i,"",priorMonday,false,0);
            if (capShiftProfileContainerAux.Count > 0)
                capShiftProfileContainer.Add(capShiftProfileContainerAux[0]);
        }

        for (int i=0; i < capShiftProfileContainer.Count; i++){
            capShiftProfile = capShiftProfileContainer[i];
            icountShifts+= capShiftProfile.getCountOfDaysWork(Constants.STRING_YES);
        }

        //shift remains today
        for (int i=0; i < capShiftProfileContainer.Count; i++){
            capShiftProfile = capShiftProfileContainer[i];
            icountRemainsShifts+= capShiftProfile.getRemainsShifts(DateTime.Now,Constants.STRING_YES);
        }
         
        foreach(PltDeptMachViewDataBase pltDeptMachViewDataBase in pltDeptMachViewDataBaseContainer){
            MachineView machineView = objectDatabaseToObject(pltDeptMachViewDataBase);           
            machineContainer.Add(machineView);

            machineView.AvailableShifts = icountShifts;
            machineView.RemainsShifts   = icountRemainsShifts;          
        }                    

        if (!bonlyHeader)        
            loadMachineChilds(machineContainer);

		return machineContainer;

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
Machine readMachineForce(string splant, string sdept, string smachine){
    try{
        Machine machine = null;

        PltDeptMachDataBase pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
		
		pltDeptMachDataBase.setPDM_Plt(splant);
		pltDeptMachDataBase.setPDM_Dept(sdept);
		pltDeptMachDataBase.setPDM_Mach(smachine);
		if (pltDeptMachDataBase.read())
            machine = objectDatabaseToObjectOri(pltDeptMachDataBase);
              
        if (machine == null){             
            MachineContainer machineContainer = readMachinesByFilters(smachine, "", "",sdept,"",false,1);            
            if (machineContainer.Count > 0)
                machine = machineContainer[0];
        }
		return machine;

    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}

}

/******************************************** MachineDef *****************************************************************/
public
MachineDef createMachineDef(){
	return new MachineDef();
}

public
MachineDefContainer createMachineDefContainer(){
	return new MachineDefContainer();
}


private
MachineDef objectDataBaseToObject(PltDeptMachDefDataBase pltDeptMachDefDataBase){
	MachineDef machineDef = new MachineDef();

	machineDef.MachId=pltDeptMachDefDataBase.getMachId();
	machineDef.PlanRunHrs=pltDeptMachDefDataBase.getPlanRunHrs();
	machineDef.HrsPerShift=pltDeptMachDefDataBase.getHrsPerShift();
	machineDef.PlanDownHrs=pltDeptMachDefDataBase.getPlanDownHrs();
	machineDef.PlanChanOvHrs=pltDeptMachDefDataBase.getPlanChanOvHrs();
	machineDef.StdShiftPerWeek=pltDeptMachDefDataBase.getStdShiftPerWeek();
	machineDef.UnitChanOverTime=pltDeptMachDefDataBase.getUnitChanOverTime();
	machineDef.DirectHoursToShifts=pltDeptMachDefDataBase.getDirectHoursToShifts();
	machineDef.Oee=pltDeptMachDefDataBase.getOee();
	machineDef.PerfOa=pltDeptMachDefDataBase.getPerfOa();
	machineDef.ScrapRate=pltDeptMachDefDataBase.getScrapRate();
	machineDef.NetPressRate=pltDeptMachDefDataBase.getNetPressRate();
    machineDef.WeeklyCapacity=pltDeptMachDefDataBase.getWeeklyCapacity();
    machineDef.DownHrsPerShift = pltDeptMachDefDataBase.getDownHrsPerShift();
    machineDef.ShowOnTvReport = pltDeptMachDefDataBase.getShowOnTvReport();
    machineDef.DateLastPlanned = pltDeptMachDefDataBase.getDateLastPlanned();

	return machineDef;
}

private
PltDeptMachDefDataBase objectToObjectDataBase(MachineDef machineDef){
	PltDeptMachDefDataBase pltDeptMachDefDataBase = new PltDeptMachDefDataBase(dataBaseAccess);
	pltDeptMachDefDataBase.setMachId(machineDef.MachId);
	pltDeptMachDefDataBase.setPlanRunHrs(machineDef.PlanRunHrs);
	pltDeptMachDefDataBase.setHrsPerShift(machineDef.HrsPerShift);
	pltDeptMachDefDataBase.setPlanDownHrs(machineDef.PlanDownHrs);
	pltDeptMachDefDataBase.setPlanChanOvHrs(machineDef.PlanChanOvHrs);
	pltDeptMachDefDataBase.setStdShiftPerWeek(machineDef.StdShiftPerWeek);
	pltDeptMachDefDataBase.setUnitChanOverTime(machineDef.UnitChanOverTime);
	pltDeptMachDefDataBase.setDirectHoursToShifts(machineDef.DirectHoursToShifts);
	pltDeptMachDefDataBase.setOee(machineDef.Oee);
	pltDeptMachDefDataBase.setPerfOa(machineDef.PerfOa);
	pltDeptMachDefDataBase.setScrapRate(machineDef.ScrapRate);
	pltDeptMachDefDataBase.setNetPressRate(machineDef.NetPressRate);
    pltDeptMachDefDataBase.setWeeklyCapacity(machineDef.WeeklyCapacity);
    pltDeptMachDefDataBase.setDownHrsPerShift(machineDef.DownHrsPerShift);
    pltDeptMachDefDataBase.setShowOnTvReport(machineDef.ShowOnTvReport);
    pltDeptMachDefDataBase.setDateLastPlanned(machineDef.DateLastPlanned);

	return pltDeptMachDefDataBase;
}

public
MachineDef cloneMachineDef(MachineDef machineDef){
	MachineDef machineDefClone = new MachineDef();

	machineDefClone.MachId=machineDef.MachId;
	machineDefClone.PlanRunHrs=machineDef.PlanRunHrs;
	machineDefClone.HrsPerShift=machineDef.HrsPerShift;
	machineDefClone.PlanDownHrs=machineDef.PlanDownHrs;
	machineDefClone.PlanChanOvHrs=machineDef.PlanChanOvHrs;
	machineDefClone.StdShiftPerWeek=machineDef.StdShiftPerWeek;
	machineDefClone.UnitChanOverTime=machineDef.UnitChanOverTime;
	machineDefClone.DirectHoursToShifts=machineDef.DirectHoursToShifts;
	machineDefClone.Oee=machineDef.Oee;
	machineDefClone.PerfOa=machineDef.PerfOa;
	machineDefClone.ScrapRate=machineDef.ScrapRate;
	machineDefClone.NetPressRate=machineDef.NetPressRate;
    machineDefClone.WeeklyCapacity=machineDef.WeeklyCapacity;
    machineDefClone.DownHrsPerShift = machineDef.DownHrsPerShift;
    machineDefClone.ShowOnTvReport = machineDef.ShowOnTvReport;
    machineDefClone.DateLastPlanned = machineDef.DateLastPlanned;

    return machineDefClone;
}

public
PltDeptMachDataBase getHashMachine(Hashtable hash,string splantH, string sdeptH, string smachH){
    PltDeptMachDataBase     pltDeptMachDataBase = null;
    PltDeptMachDataBase     pltDeptMachDataBaseResult = null;
    string                  skey= splantH.ToUpper() + Constants.DEFAULT_SEP + sdeptH.ToUpper() + Constants.DEFAULT_SEP + smachH.ToUpper();
    
    if (hash.Contains(skey))
        pltDeptMachDataBaseResult = (PltDeptMachDataBase)hash[skey];
    else{
        pltDeptMachDataBase = new PltDeptMachDataBase(dataBaseAccess);
        pltDeptMachDataBase.setPDM_Plt(splantH);
        pltDeptMachDataBase.setPDM_Dept(sdeptH);
        pltDeptMachDataBase.setPDM_Mach(smachH);
        if (pltDeptMachDataBase.read()){
            pltDeptMachDataBaseResult= pltDeptMachDataBase;
            hash.Add(skey,pltDeptMachDataBaseResult);
        }else     
            hash.Add(skey,null); ////we store null values too, so not wasting time to search when we already know there is not info
    } 
    return pltDeptMachDataBaseResult;
} 

} // class

} // namespace