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
class UserCoreFactory : TimeCodesCoreFactory{

protected
UserCoreFactory() : base(){
}

public
bool existsUser(int id){
    try{
	    UserDataBase userDataBase = new UserDataBase(dataBaseAccess);
	    userDataBase.setUserID(id);
	    return userDataBase.exists();
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}

}

public
bool existsUserByName(string loginName){
    try{
	    UserDataBase userDataBase = new UserDataBase(dataBaseAccess);
	    userDataBase.setLoginName(loginName);
	    return userDataBase.existsByLoginName();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}


public
User createUser(){
	return new User();
}

public
User readUserByName(string loginName){
	User user = null;
	try{
		user = new User();

		UserDataBase userDataBase = new UserDataBase(dataBaseAccess);
		userDataBase.setLoginName(loginName);
		
		userDataBase.readBylogin();
        user = objectDataBaseToObject(userDataBase);		
		//UserSignin
		user.setUserSignin(this.readUserSignin(user.getUserID()));
		
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
	return user;
}

public
User readUser(int id){
	User user = null;
	try{
		user = new User();

		UserDataBase userDataBase = new UserDataBase(dataBaseAccess);
		userDataBase.setUserID(id);
		
		userDataBase.read();

        user = objectDataBaseToObject(userDataBase);		
		user.setUserSignin(this.readUserSignin(user.getUserID()));

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){		
		throw new NujitException(exception.Message, exception);
	}
	return user;
}

public
void writeUser(User user){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		UserDataBase userDataBase = objectToObjectDataBase(user); 		
		userDataBase.write();

		//get autonumeric
		int id = this.dataBaseAccess.getLastId();
		user.setUserID(id);
		user.fillRedundances();

		UserSignin userSignin = user.getUserSignin();
		if (userSignin!= null)
		{		
			UserSigninDataBase userSigninDataBase = this.objectToObjectDataBase(userSignin);
			userSigninDataBase.write();
		}
		
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
void updateUser(User user){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		UserDataBase userDataBase = objectToObjectDataBase(user);
		userDataBase.update();

		user.fillRedundances();

		//UserSignin
		UserSigninDataBase userSigninDataBase = new UserSigninDataBase(dataBaseAccess);
		userSigninDataBase.setUC_UserId(user.getUserID());
		userSigninDataBase.delete();

		UserSignin userSignin = user.getUserSignin();

		if (userSignin!= null)
		{
			userSigninDataBase = this.objectToObjectDataBase(userSignin);

			if (userSigninDataBase.exists())	userSigninDataBase.update();
			else								userSigninDataBase.write();
		}
		
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
void deleteUser(User user){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		UserDataBase userDataBase	= new UserDataBase(dataBaseAccess);
		UserSignin	userSignin		= user.getUserSignin();

		if (userSignin!= null)
		{
			UserSigninDataBase userSigninDataBase = this.objectToObjectDataBase(userSignin);
			userSigninDataBase.delete();			
		}

		userDataBase.setUserID(user.getUserID());
		userDataBase.delete();
		
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
UserContainer readUsers(){
	try{
	    UserDataBaseContainer userDataBaseContainer = new UserDataBaseContainer(dataBaseAccess);
	    userDataBaseContainer.read();

	    UserContainer userContainer = new UserContainer();
	    for(IEnumerator en = userDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    UserDataBase userDataBase = (UserDataBase) en.Current;
    		
		    User user = objectDataBaseToObject(userDataBase);
		    user.setUserSignin(this.readUserSignin(user.getUserID()));//UserSignin

		    userContainer.Add(user);
	    }
        return userContainer;
    }catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}

}

private
User objectDataBaseToObject(UserDataBase userDataBase){
	User user = new User();
	user.setUserID(userDataBase.getUserID());
	user.setLoginName(userDataBase.getLoginName());
	user.setPassword(userDataBase.getPassword());
	user.setFirstName(userDataBase.getFirstName());
	user.setLastName(userDataBase.getLastName());
	user.setType(userDataBase.getType());
	user.setEmail(userDataBase.getEmail());
    user.EmpId = userDataBase.getEmpId();

    return user;
}

private
UserDataBase objectToObjectDataBase(User user){
	UserDataBase userDataBase = new UserDataBase(dataBaseAccess);
	userDataBase.setUserID(user.getUserID());
	userDataBase.setLoginName(user.getLoginName());
	userDataBase.setPassword(user.getPassword());
	userDataBase.setFirstName(user.getFirstName());
	userDataBase.setLastName(user.getLastName());
	userDataBase.setType(user.getType());
	userDataBase.setEmail(user.getEmail());
    userDataBase.setEmpId(user.EmpId);

	return userDataBase;
}

/***********************************************  UserSignIn	****************************/
/***********************************************				****************************/

private
bool existsUserSignin (int userId){

	try{
		UserSigninDataBase userSigninDataBase = new UserSigninDataBase(dataBaseAccess);

		userSigninDataBase.setUC_UserId(userId);

		return userSigninDataBase.exists();

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

private
UserSignin readUserSignin (int userId){

	try{
		UserSigninDataBase userSigninDataBase = new UserSigninDataBase(dataBaseAccess);

		userSigninDataBase.setUC_UserId(userId);

		if (!userSigninDataBase.exists())
			return null;

		userSigninDataBase.read();

		UserSignin userSignin = this.objectDataBaseToObject(userSigninDataBase);

		return userSignin;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

private
UserSignin objectDataBaseToObject (UserSigninDataBase userSigninDataBase){

	UserSignin userSignin = new UserSignin();

	userSignin.setUserId(userSigninDataBase.getUC_UserId());
	userSignin.setDefDatabase(userSigninDataBase.getUC_DefDatabase());
	userSignin.setDefCompany(userSigninDataBase.getUC_DefCompany());
	userSignin.setDefPlant(userSigninDataBase.getUC_DefPlant());
	userSignin.setDefLabelPrinter(userSigninDataBase.getUC_DefLabelPrinter());
	userSignin.setDefPrinter(userSigninDataBase.getUC_DefPrinter());
	userSignin.setTimeSignedIn(userSigninDataBase.getUC_TimeSignedIn());
	userSignin.setSecurityProfile(userSigninDataBase.getUC_SecurityProfile());

	return userSignin;
}

private
UserSigninDataBase objectToObjectDataBase (UserSignin userSignin){

UserSigninDataBase userSigninDataBase = new UserSigninDataBase(dataBaseAccess);

	userSigninDataBase.setUC_UserId(userSignin.getUserId());
	userSigninDataBase.setUC_DefDatabase(userSignin.getDefDatabase());
	userSigninDataBase.setUC_DefCompany(userSignin.getDefCompany());
	userSigninDataBase.setUC_DefPlant(userSignin.getDefPlant());
	userSigninDataBase.setUC_DefLabelPrinter(userSignin.getDefLabelPrinter());
	userSigninDataBase.setUC_DefPrinter(userSignin.getDefPrinter());
	userSigninDataBase.setUC_TimeSignedIn(userSignin.getTimeSignedIn());
	userSigninDataBase.setUC_SecurityProfile(userSignin.getSecurityProfile());

	return userSigninDataBase;
}

public
UserSignin createUserSignin(){
	return new UserSignin();
}

} // class

} // namespace