using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Cms;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;
using System.Collections;


namespace Nujit.NujitERP.ClassLib.Core.Util{


public 
class MacConfigurationCoreFactory: InvoiceCoreFactory{

	public MacConfigurationCoreFactory(): base(){
	}

	public MacConfiguration createConfiguration(){
		return new MacConfiguration();
	}

	public MacConfiguration[] readAllConfigurations(string plt, string dept){
		try
		{
			CapMacCfgDataBaseContainer capMacCfgDataBaseContainer = new CapMacCfgDataBaseContainer(dataBaseAccess);
			capMacCfgDataBaseContainer.setDept(dept);
			capMacCfgDataBaseContainer.setPlt(plt);
			capMacCfgDataBaseContainer.readByPltDept();

			MacConfiguration[] vec = new MacConfiguration[capMacCfgDataBaseContainer.Count];
			IEnumerator enu = capMacCfgDataBaseContainer.GetEnumerator();
			int i = 0;
			while(enu.MoveNext())
			{
   				CapMacCfgDataBase capMacDB= (CapMacCfgDataBase)enu.Current;

				vec[i] = this.objectDataBaseToObject(capMacDB);
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

	public bool existsConfiguration (string plt, string dept, string cfg)
	{
		try
		{
			CapMacCfgDataBase capMacCfgDataBase = new CapMacCfgDataBase(dataBaseAccess);
			capMacCfgDataBase.setCMC_Dept (dept);
			capMacCfgDataBase.setCMC_Plt (plt);
			capMacCfgDataBase.setCMC_Cfg (cfg);
			
			return capMacCfgDataBase.exists();
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

	public MacConfiguration readConfiguration (string plt, string dept, string cfg)
	{
		try
		{
			CapMacCfgDataBase capMacCfgDataBase = new CapMacCfgDataBase(dataBaseAccess);
			capMacCfgDataBase.setCMC_Dept (dept);
			capMacCfgDataBase.setCMC_Plt (plt);
			capMacCfgDataBase.setCMC_Cfg (cfg);
			
			capMacCfgDataBase.read();
		
			MacConfiguration conf = this.objectDataBaseToObject (capMacCfgDataBase);

			return conf;
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

	public void writeConfiguration (MacConfiguration conf)
	{
		try
		{
			dataBaseAccess.beginTransaction();

			CapMacCfgDataBase capMacCfgDataBase = this.objectToObjectDataBase (conf);
			capMacCfgDataBase.write ();
		
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

	public void updateConfiguration (MacConfiguration conf)
	{
		try
		{
			dataBaseAccess.beginTransaction();

			CapMacCfgDataBase capMacCfgDataBase = this.objectToObjectDataBase (conf);
			capMacCfgDataBase.update();
		
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

	public void deleteConfiguration (MacConfiguration conf)
	{
		try
		{
			dataBaseAccess.beginTransaction();

			CapMacCfgDataBase capMacCfgDataBase = this.objectToObjectDataBase (conf);
			capMacCfgDataBase.delete();

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

	public bool configurationHasMachines (MacConfiguration conf)
	{
		try
		{
			CapMacCfgADataBase capMacCfgADataBase = new CapMacCfgADataBase(dataBaseAccess);
			capMacCfgADataBase.setCMCA_Dept (conf.getDept());
			capMacCfgADataBase.setCMCA_Plt (conf.getPlt());
			capMacCfgADataBase.setCMCA_Cfg (conf.getCfg());
			
			return capMacCfgADataBase.hasMachines();
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

	private MacConfiguration objectDataBaseToObject (CapMacCfgDataBase capMacCfgDataBase)
	{
		MacConfiguration conf = new MacConfiguration();
		
		conf.setCfg (capMacCfgDataBase.getCMC_Cfg());
		conf.setDept (capMacCfgDataBase.getCMC_Dept());
		conf.setDes1 (capMacCfgDataBase.getCMC_Des1());
		conf.setExact (capMacCfgDataBase.getCMC_Exact());
		conf.setPlt (capMacCfgDataBase.getCMC_Plt());
		conf.setSet (capMacCfgDataBase.getCMC_Set());
		conf.setTotalHrs (capMacCfgDataBase.getCMC_TotalHrs());
		conf.setTotalHrsPr (capMacCfgDataBase.getCMC_TotalHrsPr());

		return conf;
	}

	private CapMacCfgDataBase objectToObjectDataBase (MacConfiguration conf)
	{	
		CapMacCfgDataBase capMacCfgDataBase = new CapMacCfgDataBase (dataBaseAccess);
		capMacCfgDataBase.setCMC_Cfg (conf.getCfg());
		capMacCfgDataBase.setCMC_Dept (conf.getDept());
		capMacCfgDataBase.setCMC_Des1 (conf.getDes1());
		capMacCfgDataBase.setCMC_Exact (conf.getExact());
		capMacCfgDataBase.setCMC_Plt (conf.getPlt());
		capMacCfgDataBase.setCMC_Set (conf.getSet());
		capMacCfgDataBase.setCMC_TotalHrs (conf.getTotalHrs());
		capMacCfgDataBase.setCMC_TotalHrsPr (conf.getTotalHrsPr());

		return capMacCfgDataBase;
	}


	}//end class

}//end namespace
