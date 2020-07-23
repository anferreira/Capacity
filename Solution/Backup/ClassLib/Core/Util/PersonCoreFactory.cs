using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;


namespace Nujit.NujitERP.ClassLib.Core.Util{


public 
class PersonCoreFactory : PackSlipCoreFactory {

protected
PersonCoreFactory() : base(){
}

/// <summary>
/// Return if exists a Person
/// </summary>
/// <param name="PDM_Plt"></param>
/// <param name="PDM_Dept"></param>
/// <param name="PDM_Mach"></param>
/// <returns></returns>
public
bool existsPerson(string plt, string id){
	try{
	
		CustVendDataBase custVendDataBase = new CustVendDataBase(dataBaseAccess);
		custVendDataBase.setCV_Plt(plt);
		custVendDataBase.setCV_ID(id);
		return custVendDataBase.exists();
	
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
Person createPerson(){
	return new Person();
}

/// <summary>
/// Reads a person object
/// </summary>
/// <param name="PDM_Plt"></param>
/// <param name="PDM_Dept"></param>
/// <param name="PDM_Mach"></param>
/// <returns></returns>
public
Person readPerson(string plt, string id){
    try{
		CustVendDataBase custVendDataBase = new CustVendDataBase(dataBaseAccess);
		custVendDataBase.setCV_Plt(plt);
		custVendDataBase.setCV_ID(id);

		if (!custVendDataBase.exists())
			return null;

		custVendDataBase.read();

		Person person = new Person();
		
		person.setPlt(custVendDataBase.getCV_Plt());
		person.setId(custVendDataBase.getCV_ID());
		person.setRecType(custVendDataBase.getCV_RecType());
		person.setCustomerType(custVendDataBase.getCV_CustomerType());
		person.setStatus(custVendDataBase.getCV_Status());
		person.setName(custVendDataBase.getCV_Name());
		person.setAddress1(custVendDataBase.getCV_Address1());
		person.setAddress2(custVendDataBase.getCV_Address2());
		person.setAddress3(custVendDataBase.getCV_Address3());
		person.setPhone(custVendDataBase.getCV_Phone());
		person.setFax(custVendDataBase.getCV_Fax());
		person.setWebPage(custVendDataBase.getCV_WebPage());
		person.setCountry(custVendDataBase.getCV_Country());
		person.setState_Prov(custVendDataBase.getCV_State_Prov());
		person.setCurrency(custVendDataBase.getCV_Currency());
		person.setTerritory(custVendDataBase.getCV_Territory());
		person.setPersonClass(custVendDataBase.getCV_Class());
		person.setDateCreated(custVendDataBase.getCV_DateCreated());
		person.setDateUpdated(custVendDataBase.getCV_DateUpdated());
		
		return person;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

public
Person[] readPersonsById(string id){
    try{
		CustVendDataBaseContainer custVendDataBaseContainer = new CustVendDataBaseContainer(dataBaseAccess);
		custVendDataBaseContainer.readById(id);
	

		if (custVendDataBaseContainer.Count == 0)
			return null;

		Person[] vec = new Person[custVendDataBaseContainer.Count];
		int i = 0;

		IEnumerator enu = custVendDataBaseContainer.GetEnumerator();
		while (enu.MoveNext())
		{
			CustVendDataBase custVendDataBase = (CustVendDataBase)enu.Current;

			Person person = new Person();
			
			person.setPlt(custVendDataBase.getCV_Plt());
			person.setId(custVendDataBase.getCV_ID());
			person.setRecType(custVendDataBase.getCV_RecType());
			person.setCustomerType(custVendDataBase.getCV_CustomerType());
			person.setStatus(custVendDataBase.getCV_Status());
			person.setName(custVendDataBase.getCV_Name());
			person.setAddress1(custVendDataBase.getCV_Address1());
			person.setAddress2(custVendDataBase.getCV_Address2());
			person.setAddress3(custVendDataBase.getCV_Address3());
			person.setPhone(custVendDataBase.getCV_Phone());
			person.setFax(custVendDataBase.getCV_Fax());
			person.setWebPage(custVendDataBase.getCV_WebPage());
			person.setCountry(custVendDataBase.getCV_Country());
			person.setState_Prov(custVendDataBase.getCV_State_Prov());
			person.setCurrency(custVendDataBase.getCV_Currency());
			person.setTerritory(custVendDataBase.getCV_Territory());
			person.setPersonClass(custVendDataBase.getCV_Class());
			person.setDateCreated(custVendDataBase.getCV_DateCreated());
			person.setDateUpdated(custVendDataBase.getCV_DateUpdated());

			vec[i] = person;
			i++;
		}		
		return vec;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/// <summary>
/// Update a person object
/// </summary>
/// <param name="machine"></param>
public
void updatePerson(Person person){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CustVendDataBase custVendDataBase = new CustVendDataBase(dataBaseAccess);
		custVendDataBase.setCV_Plt(person.getPlt());
		custVendDataBase.setCV_ID(person.getId());
		custVendDataBase.setCV_RecType(person.getRecType());
		custVendDataBase.setCV_CustomerType(person.getCustomerType());
		custVendDataBase.setCV_Status(person.getStatus());
		custVendDataBase.setCV_Name(person.getName());
		custVendDataBase.setCV_Address1(person.getAddress1());
		custVendDataBase.setCV_Address2(person.getAddress2());
		custVendDataBase.setCV_Address3(person.getAddress3());
		custVendDataBase.setCV_Phone(person.getPhone());
		custVendDataBase.setCV_Fax(person.getFax());
		custVendDataBase.setCV_WebPage(person.getWebPage());
		custVendDataBase.setCV_Country(person.getCountry());
		custVendDataBase.setCV_State_Prov(person.getState_Prov());
		custVendDataBase.setCV_Currency(person.getCurrency());
		custVendDataBase.setCV_Territory(person.getTerritory());
		custVendDataBase.setCV_Class(person.getPersonClass());
		custVendDataBase.setCV_DateCreated(person.getDateCreated());
		custVendDataBase.setCV_DateUpdated(person.getDateUpdated());
		custVendDataBase.update();

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
/// Write a person object
/// </summary>
/// <param name="machine"></param>
public
void writePerson(Person person){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CustVendDataBase custVendDataBase = new CustVendDataBase(dataBaseAccess);
		custVendDataBase.setCV_Plt(person.getPlt());
		custVendDataBase.setCV_ID(person.getId());
		custVendDataBase.setCV_RecType(person.getRecType());
		custVendDataBase.setCV_CustomerType(person.getCustomerType());
		custVendDataBase.setCV_Status(person.getStatus());
		custVendDataBase.setCV_Name(person.getName());
		custVendDataBase.setCV_Address1(person.getAddress1());
		custVendDataBase.setCV_Address2(person.getAddress2());
		custVendDataBase.setCV_Address3(person.getAddress3());
		custVendDataBase.setCV_Phone(person.getPhone());
		custVendDataBase.setCV_Fax(person.getFax());
		custVendDataBase.setCV_WebPage(person.getWebPage());
		custVendDataBase.setCV_Country(person.getCountry());
		custVendDataBase.setCV_State_Prov(person.getState_Prov());
		custVendDataBase.setCV_Currency(person.getCurrency());
		custVendDataBase.setCV_Territory(person.getTerritory());
		custVendDataBase.setCV_Class(person.getPersonClass());
		custVendDataBase.setCV_DateCreated(person.getDateCreated());
		custVendDataBase.setCV_DateUpdated(person.getDateUpdated());
		custVendDataBase.write();

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
/// Delete a person object
/// </summary>
/// <param name="machine"></param>
public
void deletePerson(string plt, string id){
    try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CustVendDataBase custVendDataBase = new CustVendDataBase(dataBaseAccess);
		custVendDataBase.setCV_Plt(plt);
		custVendDataBase.setCV_ID(id);
		custVendDataBase.delete();

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
	string[][] getPersonsByDesc(string desc)
{
	return getPersonsByDesc(desc,"","","");
}
public
	string[][] getPersonsByDesc(string desc, string type, string plant, string billToCust)
{
	try
	{
		CustVendDataBaseContainer custVendDataBaseContainer = new CustVendDataBaseContainer(dataBaseAccess);
		custVendDataBaseContainer.readByDesc(desc,type,plant,billToCust);
			string[][] vec = new String[custVendDataBaseContainer.Count][];
		int index = 0;
			IEnumerator iEnum = custVendDataBaseContainer.GetEnumerator();
		while(iEnum.MoveNext())
		{
			CustVendDataBase custVendDataBase = (CustVendDataBase)iEnum.Current;
   		
			string[] v = new String[9];
			v[0] = custVendDataBase.getCV_Plt();
			v[1] = custVendDataBase.getCV_ID();
			v[2] = custVendDataBase.getCV_Name();
   		
			if (!custVendDataBase.getCV_Address1().Equals(System.DBNull.Value))
				v[3] = custVendDataBase.getCV_Address1();
			else
				v[3] = "";
   		
			if (!custVendDataBase.getCV_Address2().Equals(System.DBNull.Value))
				v[4] = custVendDataBase.getCV_Address2();
			else
				v[4] = "";
   		
			if (!custVendDataBase.getCV_Address3().Equals(System.DBNull.Value))
				v[5] = custVendDataBase.getCV_Address3();
			else
				v[5] = "";
   		
			if (!custVendDataBase.getCV_Phone().Equals(System.DBNull.Value))
				v[6] = custVendDataBase.getCV_Phone();
			else
				v[6] = "";
   		
			if (!custVendDataBase.getCV_Fax().Equals(System.DBNull.Value))
				v[7] = custVendDataBase.getCV_Fax();
			else
				v[7] = "";
   		
			if (!custVendDataBase.getCV_WebPage().Equals(System.DBNull.Value))
				v[8] = custVendDataBase.getCV_WebPage();
			else
				v[8] = "";
			
			vec[index] = v;
			index++;
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

} // class

} // namespace
