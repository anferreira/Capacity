/*/////////////////////////////////////////////////////////////////////////////////

    CLASS BUILDER

*   $Author: gpiano $ 
*   $Date: 2006-05-29 18:33:27 $ 
*   $Source: /usr/local/cvsroot/Projects/Nujit/ClassLib/Core/Util/GLCurrencyCoreFactory.cs,v $ 
*   $State: Exp $ 
*   $Log: GLCurrencyCoreFactory.cs,v $
*   Revision 1.5  2006-05-29 18:33:27  gpiano
*   *** empty log message ***
*
*   Revision 1.4  2005/05/17 04:34:51  gmuller
*   ponga aqui un comentario
*
*   Revision 1.3  2005/04/05 20:00:40  cmelo
*   *** empty log message ***
*
*   Revision 1.2  2005/03/11 20:28:06  cmelo
*   *** empty log message ***
*
*   Revision 1.1  2005/03/11 03:28:12  cmelo
*   *** empty log message ***
* 

/*/////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;


namespace Nujit.NujitERP.ClassLib.Core.Util
{

public
class GLCurrencyCoreFactory: ExcelReportsCoreFactory
{

protected
GLCurrencyCoreFactory() : base(){
}

public
bool existsGLCurrency (string db, string currency){

	try{
		GLCurrencyDataBase gLCurrencyDataBase = new GLCurrencyDataBase(dataBaseAccess);

		gLCurrencyDataBase.setGLC_Db(db);
		gLCurrencyDataBase.setGLC_Currency(currency);

		return gLCurrencyDataBase.exists();

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
GLCurrency readGLCurrency (string db, string currency){

	try{
		GLCurrencyDataBase gLCurrencyDataBase = new GLCurrencyDataBase(dataBaseAccess);

		gLCurrencyDataBase.setGLC_Db(db);
		gLCurrencyDataBase.setGLC_Currency(currency);

		if (!gLCurrencyDataBase.exists())
			return null;

		gLCurrencyDataBase.read();

		GLCurrency gLCurrency = this.objectDataBaseToObject(gLCurrencyDataBase);

		return gLCurrency;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateGLCurrency(GLCurrency gLCurrency){

	try{

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		GLCurrencyDataBase gLCurrencyDataBase = this.objectToObjectDataBase(gLCurrency);

		gLCurrencyDataBase.update();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public 
void writeGLCurrency (GLCurrency gLCurrency){

	try{

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		GLCurrencyDataBase gLCurrencyDataBase = this.objectToObjectDataBase(gLCurrency);

		gLCurrencyDataBase.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public
void deleteGLCurrency (string db, string currency){

	try{

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		GLCurrencyDataBase gLCurrencyDataBase = new GLCurrencyDataBase(dataBaseAccess);

		gLCurrencyDataBase.setGLC_Db(db);
		gLCurrencyDataBase.setGLC_Currency(currency);

		gLCurrencyDataBase.delete();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

private
GLCurrency objectDataBaseToObject (GLCurrencyDataBase gLCurrencyDataBase){

	GLCurrency gLCurrency = new GLCurrency();

	gLCurrency.setDb(gLCurrencyDataBase.getGLC_Db());
	gLCurrency.setCurrency(gLCurrencyDataBase.getGLC_Currency());
	gLCurrency.setDescription(gLCurrencyDataBase.getGLC_Description());

	return gLCurrency;
}

private
GLCurrencyDataBase objectToObjectDataBase (GLCurrency gLCurrency){

GLCurrencyDataBase gLCurrencyDataBase = new GLCurrencyDataBase(dataBaseAccess);

	gLCurrencyDataBase.setGLC_Db(gLCurrency.getDb());
	gLCurrencyDataBase.setGLC_Currency(gLCurrency.getCurrency());
	gLCurrencyDataBase.setGLC_Description(gLCurrency.getDescription());

	return gLCurrencyDataBase;
}

public
GLCurrency createGLCurrency(){
	return new GLCurrency();
}


public string[][] getCurrencyByDesc(string text, string db){

	try{
	
	    GLCurrencyDataBaseContainer glCurrencyDataBaseContainer= new GLCurrencyDataBaseContainer(dataBaseAccess);
	    glCurrencyDataBaseContainer.readByDesc(text,db);

	    string[][] items = new string[glCurrencyDataBaseContainer.Count][];

	    int i = 0;
	    for(IEnumerator en = glCurrencyDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    GLCurrencyDataBase glCurrencyDataBase = (GLCurrencyDataBase) en.Current;
    			
		    string[] item = new String[3];
		    item[0] = glCurrencyDataBase.getGLC_Db();
		    item[1] = glCurrencyDataBase.getGLC_Currency();		    
		    item[2] = glCurrencyDataBase.getGLC_Description();
		    		        			
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


//---------------------------- GlCurrencyDlyExc -----------------------------------------------------------------
public
bool existsGLCurrencyDlyExc (string db, int company, DateTime startingDate, DateTime endingDate, string currencyBase){

	try{
		GLCurrencyDlyExcDataBase gLCurrencyDlyExcDataBase = new GLCurrencyDlyExcDataBase(dataBaseAccess);

		gLCurrencyDlyExcDataBase.setCDE_Db(db);
		gLCurrencyDlyExcDataBase.setCDE_Company(company);
		gLCurrencyDlyExcDataBase.setCDE_StartingDate(startingDate);
		gLCurrencyDlyExcDataBase.setCDE_EndingDate(endingDate);
		gLCurrencyDlyExcDataBase.setCDE_CurrencyBase(currencyBase);

		return gLCurrencyDlyExcDataBase.exists();

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
GLCurrencyDlyExc readGLCurrencyDlyExc (string db, int company, DateTime startingDate, DateTime endingDate, string currencyBase){

	try{
		GLCurrencyDlyExcDataBase gLCurrencyDlyExcDataBase = new GLCurrencyDlyExcDataBase(dataBaseAccess);

		gLCurrencyDlyExcDataBase.setCDE_Db(db);
		gLCurrencyDlyExcDataBase.setCDE_Company(company);
		gLCurrencyDlyExcDataBase.setCDE_StartingDate(startingDate);
		gLCurrencyDlyExcDataBase.setCDE_EndingDate(endingDate);
		gLCurrencyDlyExcDataBase.setCDE_CurrencyBase(currencyBase);

		if (!gLCurrencyDlyExcDataBase.exists())
			return null;

		gLCurrencyDlyExcDataBase.read();

		GLCurrencyDlyExc gLCurrencyDlyExc = this.objectDataBaseToObject(gLCurrencyDlyExcDataBase);

		return gLCurrencyDlyExc;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateGLCurrencyDlyExc(GLCurrencyDlyExc gLCurrencyDlyExc){

	try{

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		GLCurrencyDlyExcDataBase gLCurrencyDlyExcDataBase = this.objectToObjectDataBase(gLCurrencyDlyExc);

		gLCurrencyDlyExcDataBase.update();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public 
void writeGLCurrencyDlyExc (GLCurrencyDlyExc gLCurrencyDlyExc){

	try{

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		GLCurrencyDlyExcDataBase gLCurrencyDlyExcDataBase = this.objectToObjectDataBase(gLCurrencyDlyExc);

		gLCurrencyDlyExcDataBase.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public
void deleteGLCurrencyDlyExc (string db, int company, DateTime startingDate, DateTime endingDate, string currencyBase){

	try{

		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		GLCurrencyDlyExcDataBase gLCurrencyDlyExcDataBase = new GLCurrencyDlyExcDataBase(dataBaseAccess);

		gLCurrencyDlyExcDataBase.setCDE_Db(db);
		gLCurrencyDlyExcDataBase.setCDE_Company(company);
		gLCurrencyDlyExcDataBase.setCDE_StartingDate(startingDate);
		gLCurrencyDlyExcDataBase.setCDE_EndingDate(endingDate);
		gLCurrencyDlyExcDataBase.setCDE_CurrencyBase(currencyBase);

		gLCurrencyDlyExcDataBase.delete();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

private
GLCurrencyDlyExc objectDataBaseToObject (GLCurrencyDlyExcDataBase gLCurrencyDlyExcDataBase){

	GLCurrencyDlyExc gLCurrencyDlyExc = new GLCurrencyDlyExc();

	gLCurrencyDlyExc.setDb(gLCurrencyDlyExcDataBase.getCDE_Db());
	gLCurrencyDlyExc.setCompany(gLCurrencyDlyExcDataBase.getCDE_Company());
	gLCurrencyDlyExc.setStartingDate(gLCurrencyDlyExcDataBase.getCDE_StartingDate());
	gLCurrencyDlyExc.setEndingDate(gLCurrencyDlyExcDataBase.getCDE_EndingDate());
	gLCurrencyDlyExc.setCurrencyBase(gLCurrencyDlyExcDataBase.getCDE_CurrencyBase());
	gLCurrencyDlyExc.setExchangeRate(gLCurrencyDlyExcDataBase.getCDE_ExchangeRate());
	gLCurrencyDlyExc.setCurrencyCode(gLCurrencyDlyExcDataBase.getCDE_CurrencyCode());
	gLCurrencyDlyExc.setDateCreated(gLCurrencyDlyExcDataBase.getCDE_DateCreated());
	gLCurrencyDlyExc.setUserCreated(gLCurrencyDlyExcDataBase.getCDE_UserCreated());
	gLCurrencyDlyExc.setDateUpdated(gLCurrencyDlyExcDataBase.getCDE_DateUpdated());
	gLCurrencyDlyExc.setUserUpdated(gLCurrencyDlyExcDataBase.getCDE_UserUpdated());

	return gLCurrencyDlyExc;
}

private
GLCurrencyDlyExcDataBase objectToObjectDataBase (GLCurrencyDlyExc gLCurrencyDlyExc){

GLCurrencyDlyExcDataBase gLCurrencyDlyExcDataBase = new GLCurrencyDlyExcDataBase(dataBaseAccess);

	gLCurrencyDlyExcDataBase.setCDE_Db(gLCurrencyDlyExc.getDb());
	gLCurrencyDlyExcDataBase.setCDE_Company(gLCurrencyDlyExc.getCompany());
	gLCurrencyDlyExcDataBase.setCDE_StartingDate(gLCurrencyDlyExc.getStartingDate());
	gLCurrencyDlyExcDataBase.setCDE_EndingDate(gLCurrencyDlyExc.getEndingDate());
	gLCurrencyDlyExcDataBase.setCDE_CurrencyBase(gLCurrencyDlyExc.getCurrencyBase());
	gLCurrencyDlyExcDataBase.setCDE_ExchangeRate(gLCurrencyDlyExc.getExchangeRate());
	gLCurrencyDlyExcDataBase.setCDE_CurrencyCode(gLCurrencyDlyExc.getCurrencyCode());
	gLCurrencyDlyExcDataBase.setCDE_DateCreated(gLCurrencyDlyExc.getDateCreated());
	gLCurrencyDlyExcDataBase.setCDE_UserCreated(gLCurrencyDlyExc.getUserCreated());
	gLCurrencyDlyExcDataBase.setCDE_DateUpdated(gLCurrencyDlyExc.getDateUpdated());
	gLCurrencyDlyExcDataBase.setCDE_UserUpdated(gLCurrencyDlyExc.getUserUpdated());

	return gLCurrencyDlyExcDataBase;
}

public
GLCurrencyDlyExc createGLCurrencyDlyExc(){
	return new GLCurrencyDlyExc();
}

public string[][] getCurrencyDlyExcByDesc(string text, string db){

	try{
	
	    GLCurrencyDlyExcDataBaseContainer glCurrencyDlyExcDataBaseContainer = new GLCurrencyDlyExcDataBaseContainer(dataBaseAccess);
	    glCurrencyDlyExcDataBaseContainer.readByDesc(text,db);

	    string[][] items = new string[glCurrencyDlyExcDataBaseContainer.Count][];

	    int i = 0;
	    for(IEnumerator en = glCurrencyDlyExcDataBaseContainer.GetEnumerator(); en.MoveNext(); ){
		    GLCurrencyDlyExcDataBase glCurrencyDlyExcDataBase = (GLCurrencyDlyExcDataBase) en.Current;
    			
		    string[] item = new String[11];
		    item[0] = glCurrencyDlyExcDataBase.getCDE_Db();
		    item[1] = glCurrencyDlyExcDataBase.getCDE_Company().ToString();		    
		    item[2] = glCurrencyDlyExcDataBase.getCDE_StartingDate().ToShortDateString();
		    item[3] = glCurrencyDlyExcDataBase.getCDE_EndingDate().ToShortDateString();
		    item[4] = glCurrencyDlyExcDataBase.getCDE_CurrencyBase();
		    item[5] = glCurrencyDlyExcDataBase.getCDE_ExchangeRate().ToString();
		    item[6] = glCurrencyDlyExcDataBase.getCDE_CurrencyCode();
		    item[7] = glCurrencyDlyExcDataBase.getCDE_DateCreated().ToShortDateString();
		    item[8] = glCurrencyDlyExcDataBase.getCDE_UserCreated();
		    item[9] = glCurrencyDlyExcDataBase.getCDE_DateUpdated().ToShortDateString();
		    item[10] = glCurrencyDlyExcDataBase.getCDE_UserUpdated();
		    		        			
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
} // package