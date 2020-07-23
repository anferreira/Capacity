/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author$ 
*   $Date$ 
*   $Source$ 
*   $State$ 

/*/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;

using Nujit.NujitWms.ClassLib.Persistence;
using Nujit.NujitWms.ClassLib.Persistence.Access;
using Nujit.NujitWms.ClassLib.Util;
using Nujit.NujitWms.ClassLib.Core;
using Nujit.NujitWms.ClassLib.Core.Remote;

namespace Nujit.NujitWms.ClassLib.Core.Util{

internal
class RP1268HCoreFactory : BaseCoreFactory {

public
RP1268HCoreFactory(DataBaseAccess dataBaseAccess, CommonAttributesContainer commonAtributes) : base(dataBaseAccess, commonAtributes){
}

public
RP1268H createRP1268H(){
	return new RP1268H();
}

public
RP1268HContainer createRP1268HContainer(){
	return new RP1268HContainer();
}

public
bool existsRP1268H(int id){
	try{
		RP1268HDataBase rP1268HDataBase = new RP1268HDataBase(dataBaseAccess);

		rP1268HDataBase.setId(id);

		return rP1268HDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
RP1268H readRP1268H(int id){
	try{
		RP1268HDataBase rP1268HDataBase = new RP1268HDataBase(dataBaseAccess);
		rP1268HDataBase.setId(id);

		if (!rP1268HDataBase.read())
			return null;

		RP1268H rP1268H = this.objectDataBaseToObject(rP1268HDataBase);

		return rP1268H;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
string[][] getRP1268HByDesc(string searchText, int rows){
	try{
		RP1268HDataBaseContainer rP1268HDataBaseContainer = new RP1268HDataBaseContainer(dataBaseAccess);
		rP1268HDataBaseContainer.readByDesc(searchText, rows);
		string[][] items = new string[rP1268HDataBaseContainer.Count][];
		int i = 0;
		for(IEnumerator en = rP1268HDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
			RP1268HDataBase rP1268HDataBase = (RP1268HDataBase) en.Current;
			string[] item = new String[2];
			item[0] = rP1268HDataBase.getId().ToString();
			item[1] = rP1268HDataBase.getDateRun().ToString();
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

public 
void updateRP1268H(RP1268H rP1268H){
	try{
		if (!commonAttributesContainer.isUserHandledTransaction())
			dataBaseAccess.beginTransaction();

		RP1268HDataBase rP1268HDataBase = this.objectToObjectDataBase(rP1268H);
		rP1268HDataBase.update();

		if (!commonAttributesContainer.isUserHandledTransaction())
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		if (!commonAttributesContainer.isUserHandledTransaction())
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!commonAttributesContainer.isUserHandledTransaction())
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public 
void writeRP1268H(RP1268H rP1268H){
	try{
		if (!commonAttributesContainer.isUserHandledTransaction())
			dataBaseAccess.beginTransaction();

		RP1268HDataBase rP1268HDataBase = this.objectToObjectDataBase(rP1268H);
		rP1268HDataBase.write();

		if (!commonAttributesContainer.isUserHandledTransaction())
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		if (!commonAttributesContainer.isUserHandledTransaction())
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!commonAttributesContainer.isUserHandledTransaction())
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public
void deleteRP1268H(int id){
	try{
		if (!commonAttributesContainer.isUserHandledTransaction())
			dataBaseAccess.beginTransaction();

		RP1268HDataBase rP1268HDataBase = new RP1268HDataBase(dataBaseAccess);

		rP1268HDataBase.setId(id);
		rP1268HDataBase.delete();

		if (!commonAttributesContainer.isUserHandledTransaction())
			dataBaseAccess.commitTransaction();
	}catch(PersistenceException persistenceException){
		if (!commonAttributesContainer.isUserHandledTransaction())
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!commonAttributesContainer.isUserHandledTransaction())
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

private
RP1268H objectDataBaseToObject(RP1268HDataBase rP1268HDataBase){
	RP1268H rP1268H = new RP1268H();

	rP1268H.Id=rP1268HDataBase.getId();
	rP1268H.DateRun=rP1268HDataBase.getDateRun();

	return rP1268H;
}

private
RP1268HDataBase objectToObjectDataBase(RP1268H rP1268H){
	RP1268HDataBase rP1268HDataBase = new RP1268HDataBase(dataBaseAccess);
	rP1268HDataBase.setId(rP1268H.Id);
	rP1268HDataBase.setDateRun(rP1268H.DateRun);

	return rP1268HDataBase;
}

public
RP1268H cloneRP1268H(RP1268H rP1268H){
	RP1268H rP1268HClone = new RP1268H();

	rP1268HClone.Id=rP1268H.Id;
	rP1268HClone.DateRun=rP1268H.DateRun;

	return rP1268HClone;
}

/****** This code goes in CoreFactory ******
#region RP1268H

[OperationContract]
RP1268H createRP1268H();

[OperationContract]
RP1268HContainer createRP1268HContainer();

[OperationContract]
bool existsRP1268H(int id);

[OperationContract]
RP1268H readRP1268H(int id);

[OperationContract]
string[][] getRP1268HByDesc(string searchText, int rows);

[OperationContract]
void updateRP1268H(RP1268H rP1268H);

[OperationContract]
void writeRP1268H(RP1268H rP1268H);

[OperationContract]
void deleteRP1268H(int id);

[OperationContract]
RP1268H cloneRP1268H(RP1268H rP1268H);

#endregion RP1268H

*/

} // class
} // package