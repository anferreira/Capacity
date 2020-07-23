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
class VersionCoreFactory : UtilityCoreFactory{

protected
VersionCoreFactory() : base(){
}

public 
CapacityVersion createCapacityVersion(){
	return new CapacityVersion();
}

public
CapacityVersion readCapacityVersion (string version)
{
    try{
		SchVersionDataBase schVersionDataBase = new SchVersionDataBase(dataBaseAccess);

		schVersionDataBase.setSCH_Version(version);
		schVersionDataBase.read();

		CapacityVersion capacityVersion = new CapacityVersion();
		capacityVersion.setPlt(schVersionDataBase.getSCH_Plt());
		capacityVersion.setVersion(schVersionDataBase.getSCH_Version());
		capacityVersion.setStatus(schVersionDataBase.getSCH_Status());
		capacityVersion.setSett(schVersionDataBase.getSCH_SysSett());
		capacityVersion.setDtStart(schVersionDataBase.getSCH_DtStart());
		capacityVersion.setDtEnd(schVersionDataBase.getSCH_DtEnd());
		capacityVersion.setDtCreat(schVersionDataBase.getSCH_DtCreat());
		capacityVersion.setUserCr(schVersionDataBase.getSCH_UserCr());
		capacityVersion.setDtUpdate(schVersionDataBase.getSCH_DtUpdate());
		capacityVersion.setUserUp(schVersionDataBase.getSCH_UserUp());

		return capacityVersion;

	}catch(PersistenceException pe){
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public 
void writeCapacityVersion(CapacityVersion capacityVersion){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		SchVersionDataBase schVersionDataBase = new SchVersionDataBase(dataBaseAccess);
		schVersionDataBase.setSCH_Plt(capacityVersion.getPlt());
		schVersionDataBase.setSCH_Version(capacityVersion.getVersion());
		schVersionDataBase.setSCH_Status(capacityVersion.getStatus());
		schVersionDataBase.setSCH_SysSett(capacityVersion.getSett());
		schVersionDataBase.setSCH_DtStart(capacityVersion.getDtStart());
		schVersionDataBase.setSCH_DtEnd(capacityVersion.getDtEnd());
		schVersionDataBase.setSCH_DtCreat(capacityVersion.getDtCreat());
		schVersionDataBase.setSCH_UserCr(capacityVersion.getUserCr());
		schVersionDataBase.setSCH_DtUpdate(capacityVersion.getDtUpdate());
		schVersionDataBase.setSCH_UserUp(capacityVersion.getUserUp());
		schVersionDataBase.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException pe){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message, exception);
	}
}

public 
bool existsCapacityVersion(string version){
	try{
		SchVersionDataBase schVersionDataBase = new SchVersionDataBase(dataBaseAccess);
		schVersionDataBase.setSCH_Version(version);
		return schVersionDataBase.exists();
	}catch(PersistenceException pe){
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
string[][] getActiveCapacityVersions(string plt){
	try{
	    SchVersionDataBaseContainer schVersionDataBaseContainer = new SchVersionDataBaseContainer(dataBaseAccess);
	    schVersionDataBaseContainer.readByPlt(plt);

	    string[][] list = new string[schVersionDataBaseContainer.Count][];
	    int count = 0;

	    for(IEnumerator en = schVersionDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    SchVersionDataBase schVersionDataBase = (SchVersionDataBase)en.Current;

		    string[] line = new string[8];	
		    line[0] = schVersionDataBase.getSCH_Version();
		    line[1] = schVersionDataBase.getSCH_SysSett();
		    line[2] = DateUtil.getDateRepresentation(schVersionDataBase.getSCH_DtStart(), DateUtil.MMDDYYYY);
		    line[3] = DateUtil.getDateRepresentation(schVersionDataBase.getSCH_DtEnd(), DateUtil.MMDDYYYY);
		    line[4] = DateUtil.getDateRepresentation(schVersionDataBase.getSCH_DtCreat(), DateUtil.MMDDYYYY);
		    line[5] = schVersionDataBase.getSCH_UserCr();
		    line[6] = DateUtil.getDateRepresentation(schVersionDataBase.getSCH_DtUpdate(), DateUtil.MMDDYYYY);
		    line[7] = schVersionDataBase.getSCH_UserUp();
		    list[count] = line;	
		    count++;
	    }

	    return list;
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}
} // class

} // namespace