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
class TimeCodesCoreFactory : TaskCoreFactory{

protected
TimeCodesCoreFactory() : base(){
}

/// <summary>
/// Return all the Time codes
/// </summary>
/// <returns></returns>
public
string[][] getTimeCodes(){
	try {
		TimeTypeDataBaseContainer timeTypeDataBaseContainer = new TimeTypeDataBaseContainer(dataBaseAccess);
		timeTypeDataBaseContainer.read();

		string[][] vec = new string[timeTypeDataBaseContainer.Count][];
		int index = 0;
		
		IEnumerator iEnum = timeTypeDataBaseContainer.GetEnumerator();
		while(iEnum.MoveNext()){
			vec[index] = new string[3];
			TimeTypeDataBase timeTypeDataBase = (TimeTypeDataBase)iEnum.Current;
			vec[index][0] = timeTypeDataBase.getTT_TmType();
			vec[index][1] = timeTypeDataBase.getTT_Des();
			vec[index][2] = timeTypeDataBase.getTT_Color();
			vec[index][3] = NumberUtil.toString(timeTypeDataBase.getTT_HrPrPorc());
			index++;
		}
		return vec;
	}catch(PersistenceException pe){
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
TimeCode[] getTimeCodeObjects(){
	try {
		TimeTypeDataBaseContainer timeTypeDataBaseContainer = new TimeTypeDataBaseContainer(dataBaseAccess);
		timeTypeDataBaseContainer.read();

		TimeCode[] vec = new TimeCode[timeTypeDataBaseContainer.Count];
		int index = 0;
		
		IEnumerator iEnum = timeTypeDataBaseContainer.GetEnumerator();
		while(iEnum.MoveNext()){
			TimeTypeDataBase timeTypeDataBase = (TimeTypeDataBase)iEnum.Current;
			vec[index] = new TimeCode (
				timeTypeDataBase.getTT_TmType(),
				timeTypeDataBase.getTT_DirInd(),
				timeTypeDataBase.getTT_DeptLoc(),
				timeTypeDataBase.getTT_DeptAsg(),
				timeTypeDataBase.getTT_DRS(),
				timeTypeDataBase.getTT_SchYN(),
				timeTypeDataBase.getTT_UseProdID(),
				timeTypeDataBase.getTT_Des(),
				timeTypeDataBase.getTT_Color(),
				timeTypeDataBase.getTT_HrPrPorc());
			index++;
		}
		return vec;
	}catch(PersistenceException pe){
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
decimal getMachineTimeCodePorc (string plt, string dept, string machine, string timeCode){
	try {
		CapMacTimeTypePorcDataBase capMacTimeTypePorcDataBase = new CapMacTimeTypePorcDataBase(dataBaseAccess);

		capMacTimeTypePorcDataBase.setMTTP_Plt (plt);
		capMacTimeTypePorcDataBase.setMTTP_Dept (dept);
		capMacTimeTypePorcDataBase.setMTTP_Mach (machine);
		capMacTimeTypePorcDataBase.setMTTP_TmType (timeCode);

		if (!capMacTimeTypePorcDataBase.exists ())
			return -1M;

		capMacTimeTypePorcDataBase.read();

		return capMacTimeTypePorcDataBase.getMTTP_Porcentage();

	}catch(PersistenceException pe){
		throw new NujitException(pe.Message, pe);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}		

} // class

} // namespace