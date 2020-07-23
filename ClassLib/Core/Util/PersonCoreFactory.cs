using System;
using System.Collections;

using Nujit.NujitERP.ClassLib.DataAccess.Persistence;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Access;
using Nujit.NujitERP.ClassLib.ErpException;
using Nujit.NujitERP.ClassLib.Util;
using Nujit.NujitERP.ClassLib.Core;

using Nujit.NujitERP.ClassLib.Core.Customer;
using Nujit.NujitERP.ClassLib.DataAccess.Persistence.Customer;


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

public
PersonContainer readPersonsByFilters(string splant,string sid,string stype,string scustType,string status,string sname,string saddress1,string sbillToCust,string sphone,int irows){
    try{
        PersonContainer             personContainer = new PersonContainer();
		CustVendDataBaseContainer   custVendDataBaseContainer = new CustVendDataBaseContainer(dataBaseAccess);
		custVendDataBaseContainer.readByFilters(splant, sid,stype, scustType, status, sname, saddress1, sbillToCust, sphone, irows);
	
		IEnumerator enu = custVendDataBaseContainer.GetEnumerator();
		while (enu.MoveNext()){
			CustVendDataBase custVendDataBase = (CustVendDataBase)enu.Current;
            personContainer.Add(objectDataBaseToObject(custVendDataBase));

        }		
		return personContainer;

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

public 
Person objectDataBaseToObject (CustVendDataBase custVendDataBase){
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
}

public
CustVendDataBase objectToObjectDataBase (Person person){
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

    return custVendDataBase;
}

/*************************************** **************************************************************************/
public
CustParts createCustParts(){
	return new CustParts();
}

public
CustPartsContainer createCustPartsContainer(){
	return new CustPartsContainer();
}

public
bool existsCustPart(string prodID, string billToCust, string shipToCust){
	try{
		CustPartDataBase custPartDataBase = new CustPartDataBase(dataBaseAccess);

		custPartDataBase.setCP_ProdID(prodID);
		custPartDataBase.setCP_BillToCust(billToCust);
		custPartDataBase.setCP_ShipToCust(shipToCust);

		return custPartDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
CustParts readCustPart(string prodID, string billToCust, string shipToCust){
	try{
		CustPartDataBase custPartDataBase = new CustPartDataBase(dataBaseAccess);
		custPartDataBase.setCP_ProdID(prodID);
		custPartDataBase.setCP_BillToCust(billToCust);
		custPartDataBase.setCP_ShipToCust(shipToCust);

		if (!custPartDataBase.read())
			return null;

		CustParts custPart = this.objectDataBaseToObject(custPartDataBase);

		return custPart;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateCustPart(CustParts custPart){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CustPartDataBase custPartDataBase = this.objectToObjectDataBase(custPart);
		custPartDataBase.update();

		if (!userHandleTransaction)			
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		if (!userHandleTransaction)		
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!userHandleTransaction)		
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public 
void writeCustPart(CustParts custPart){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CustPartDataBase custPartDataBase = this.objectToObjectDataBase(custPart);
		custPartDataBase.write();

		custPart.ID=custPartDataBase.getID();

		if (!userHandleTransaction)			
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		if (!userHandleTransaction)		
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!userHandleTransaction)		
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public
void deleteCustPart(string prodID, string billToCust, string shipToCust){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CustPartDataBase custPartDataBase = new CustPartDataBase(dataBaseAccess);

		custPartDataBase.setCP_ProdID(prodID);
		custPartDataBase.setCP_BillToCust(billToCust);
		custPartDataBase.setCP_ShipToCust(shipToCust);
		custPartDataBase.delete();

		if (!userHandleTransaction)			
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		if (!userHandleTransaction)		
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!userHandleTransaction)		
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

private
CustParts objectDataBaseToObject(CustPartDataBase custPartDataBase){
	CustParts custPart = new CustParts();

	custPart.ID=custPartDataBase.getID();
	custPart.Db=custPartDataBase.getCP_Db();
	custPart.ProdID=custPartDataBase.getCP_ProdID();
	custPart.ProdIDAlias=custPartDataBase.getCP_ProdIDAlias();
	custPart.BillToCust=custPartDataBase.getCP_BillToCust();
	custPart.ShipToCust=custPartDataBase.getCP_ShipToCust();
	custPart.DropShipCust=custPartDataBase.getCP_DropShipCust();
	custPart.CustPart=custPartDataBase.getCP_CustPart();
	custPart.CustPartRev=custPartDataBase.getCP_CustPartRev();
	custPart.CustPartRevDate=custPartDataBase.getCP_CustPartRevDate();
	custPart.CustPartDes1=custPartDataBase.getCP_CustPartDes1();
	custPart.CustPartDes2=custPartDataBase.getCP_CustPartDes2();
	custPart.CustPartDes3=custPartDataBase.getCP_CustPartDes3();
	custPart.Consignment=custPartDataBase.getCP_Consignment();
	custPart.StdPackQty=custPartDataBase.getCP_StdPackQty();
	custPart.StdPackUnit=custPartDataBase.getCP_StdPackUnit();
	custPart.StdPackCont=custPartDataBase.getCP_StdPackCont();
	custPart.StdPackSkidCode=custPartDataBase.getCP_StdPackSkidCode();
	custPart.StdPackSkidQty=custPartDataBase.getCP_StdPackSkidQty();
	custPart.StdPackSkidUom=custPartDataBase.getCP_StdPackSkidUom();
	custPart.LeadTime=custPartDataBase.getCP_LeadTime();
	custPart.WeeklyQtyCommit=custPartDataBase.getCP_WeeklyQtyCommit();

	return custPart;
}

private
CustPartDataBase objectToObjectDataBase(CustParts custPart){
	CustPartDataBase custPartDataBase = new CustPartDataBase(dataBaseAccess);
	custPartDataBase.setID(custPart.ID);
	custPartDataBase.setCP_Db(custPart.Db);
	custPartDataBase.setCP_ProdID(custPart.ProdID);
	custPartDataBase.setCP_ProdIDAlias(custPart.ProdIDAlias);
	custPartDataBase.setCP_BillToCust(custPart.BillToCust);
	custPartDataBase.setCP_ShipToCust(custPart.ShipToCust);
	custPartDataBase.setCP_DropShipCust(custPart.DropShipCust);
	custPartDataBase.setCP_CustPart(custPart.CustPart);
	custPartDataBase.setCP_CustPartRev(custPart.CustPartRev);
	custPartDataBase.setCP_CustPartRevDate(custPart.CustPartRevDate);
	custPartDataBase.setCP_CustPartDes1(custPart.CustPartDes1);
	custPartDataBase.setCP_CustPartDes2(custPart.CustPartDes2);
	custPartDataBase.setCP_CustPartDes3(custPart.CustPartDes3);
	custPartDataBase.setCP_Consignment(custPart.Consignment);
	custPartDataBase.setCP_StdPackQty(custPart.StdPackQty);
	custPartDataBase.setCP_StdPackUnit(custPart.StdPackUnit);
	custPartDataBase.setCP_StdPackCont(custPart.StdPackCont);
	custPartDataBase.setCP_StdPackSkidCode(custPart.StdPackSkidCode);
	custPartDataBase.setCP_StdPackSkidQty(custPart.StdPackSkidQty);
	custPartDataBase.setCP_StdPackSkidUom(custPart.StdPackSkidUom);
	custPartDataBase.setCP_LeadTime(custPart.LeadTime);
	custPartDataBase.setCP_WeeklyQtyCommit(custPart.WeeklyQtyCommit);

	return custPartDataBase;
}

public
CustParts cloneCustParts(CustParts custPart){
	CustParts custPartClone = new CustParts();

	custPartClone.ID=custPart.ID;
	custPartClone.Db=custPart.Db;
	custPartClone.ProdID=custPart.ProdID;
	custPartClone.ProdIDAlias=custPart.ProdIDAlias;
	custPartClone.BillToCust=custPart.BillToCust;
	custPartClone.ShipToCust=custPart.ShipToCust;
	custPartClone.DropShipCust=custPart.DropShipCust;
	custPartClone.CustPart=custPart.CustPart;
	custPartClone.CustPartRev=custPart.CustPartRev;
	custPartClone.CustPartRevDate=custPart.CustPartRevDate;
	custPartClone.CustPartDes1=custPart.CustPartDes1;
	custPartClone.CustPartDes2=custPart.CustPartDes2;
	custPartClone.CustPartDes3=custPart.CustPartDes3;
	custPartClone.Consignment=custPart.Consignment;
	custPartClone.StdPackQty=custPart.StdPackQty;
	custPartClone.StdPackUnit=custPart.StdPackUnit;
	custPartClone.StdPackCont=custPart.StdPackCont;
	custPartClone.StdPackSkidCode=custPart.StdPackSkidCode;
	custPartClone.StdPackSkidQty=custPart.StdPackSkidQty;
	custPartClone.StdPackSkidUom=custPart.StdPackSkidUom;
	custPartClone.LeadTime=custPart.LeadTime;
	custPartClone.WeeklyQtyCommit=custPart.WeeklyQtyCommit;

	return custPartClone;
}


public
CustPartsContainer readCustPartByFilters(string spart,string sbillTo,string shipTo,string scustPart,int irows){
    try{
        CustPartsContainer          custPartsContainer = new CustPartsContainer();
		CustPartDataBaseContainer   custPartDataBaseContainer = new CustPartDataBaseContainer(dataBaseAccess);
		custPartDataBaseContainer.readByFilters(spart, sbillTo, shipTo, scustPart, irows);
			
		foreach(CustPartDataBase custPartDataBase in custPartDataBaseContainer){			
            custPartsContainer.Add(objectDataBaseToObject(custPartDataBase));

        }		
		return custPartsContainer;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}


/********************************************************** *****************************************************************/
public
CustLead createCustLead(){
	return new CustLead();
}

public
CustLeadContainer createCustLeadContainer(){
	return new CustLeadContainer();
}

public
bool existsCustLead(string custId, string majSalesCode, string minSalesCode){
	try{
		CustLeadDataBase custLeadDataBase = new CustLeadDataBase(dataBaseAccess);

		custLeadDataBase.setCustId(custId);
		custLeadDataBase.setMajSalesCode(majSalesCode);
		custLeadDataBase.setMinSalesCode(minSalesCode);

		return custLeadDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
CustLead readCustLead(string custId, string majSalesCode, string minSalesCode){
	try{
		CustLeadDataBase custLeadDataBase = new CustLeadDataBase(dataBaseAccess);
		custLeadDataBase.setCustId(custId);
		custLeadDataBase.setMajSalesCode(majSalesCode);
		custLeadDataBase.setMinSalesCode(minSalesCode);

		if (!custLeadDataBase.read())
			return null;

		CustLead custLead = this.objectDataBaseToObject(custLeadDataBase);

		return custLead;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateCustLead(CustLead custLead){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CustLeadDataBase custLeadDataBase = this.objectToObjectDataBase(custLead);
		custLeadDataBase.update();

		if (!userHandleTransaction)			
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		if (!userHandleTransaction)		
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!userHandleTransaction)		
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public 
void writeCustLead(CustLead custLead){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CustLeadDataBase custLeadDataBase = this.objectToObjectDataBase(custLead);
		custLeadDataBase.write();

		custLead.Id=custLeadDataBase.getId();

		if (!userHandleTransaction)			
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		if (!userHandleTransaction)		
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!userHandleTransaction)		
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public
void deleteCustLead(string custId, string majSalesCode, string minSalesCode){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		CustLeadDataBase custLeadDataBase = new CustLeadDataBase(dataBaseAccess);

		custLeadDataBase.setCustId(custId);
		custLeadDataBase.setMajSalesCode(majSalesCode);
		custLeadDataBase.setMinSalesCode(minSalesCode);
		custLeadDataBase.delete();

		if (!userHandleTransaction)			
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		if (!userHandleTransaction)		
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!userHandleTransaction)		
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

private
CustLead objectDataBaseToObject(CustLeadDataBase custLeadDataBase){
	CustLead custLead = new CustLead();

	custLead.Id=custLeadDataBase.getId();
	custLead.CustId=custLeadDataBase.getCustId();
	custLead.MajSalesCode=custLeadDataBase.getMajSalesCode();
	custLead.MinSalesCode=custLeadDataBase.getMinSalesCode();
	custLead.LeadTime=custLeadDataBase.getLeadTime();

	return custLead;
}

private
CustLeadDataBase objectToObjectDataBase(CustLead custLead){
	CustLeadDataBase custLeadDataBase = new CustLeadDataBase(dataBaseAccess);
	custLeadDataBase.setId(custLead.Id);
	custLeadDataBase.setCustId(custLead.CustId);
	custLeadDataBase.setMajSalesCode(custLead.MajSalesCode);
	custLeadDataBase.setMinSalesCode(custLead.MinSalesCode);
	custLeadDataBase.setLeadTime(custLead.LeadTime);

	return custLeadDataBase;
}

public
CustLead cloneCustLead(CustLead custLead){
	CustLead custLeadClone = new CustLead();

	custLeadClone.Id=custLead.Id;
	custLeadClone.CustId=custLead.CustId;
	custLeadClone.MajSalesCode=custLead.MajSalesCode;
	custLeadClone.MinSalesCode=custLead.MinSalesCode;
	custLeadClone.LeadTime=custLead.LeadTime;

	return custLeadClone;
}

public
CustLeadContainer readCustLeadByFilters(string scustID,string sexactCustId,string smajSalesCode,string sminSalesCode,int irows){
    try{
        CustLeadContainer           custLeadContainer = new CustLeadContainer();
        CustLeadDataBaseContainer   custLeadDataBaseContainer = new CustLeadDataBaseContainer(dataBaseAccess);

		custLeadDataBaseContainer.readByFilters(scustID,sexactCustId,smajSalesCode, sminSalesCode, irows);
			
		foreach(CustLeadDataBase custLeadDataBase in custLeadDataBaseContainer){			
            custLeadContainer.Add(objectDataBaseToObject(custLeadDataBase));
        }		
		return custLeadContainer;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}


public
CustLeadContainer readCustLeadByCustomerFilters(string scustID,string smajSalesCode){
    try{
        CustLeadContainer           custLeadContainer = new CustLeadContainer();
        CustLeadDataBaseContainer   custLeadDataBaseContainer = new CustLeadDataBaseContainer(dataBaseAccess);

		custLeadDataBaseContainer.readByCustomerFilters(scustID, smajSalesCode);
			
		foreach(CustLeadDataBase custLeadDataBase in custLeadDataBaseContainer){			
            custLeadContainer.Add(objectDataBaseToObject(custLeadDataBase));
        }		
		return custLeadContainer;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

/********************************************** TradingPartner ***************************************************************************/

public
TradingPartner createTradingPartner(){
	return new TradingPartner();
}

public
TradingPartnerContainer createTradingPartnerContainer(){
	return new TradingPartnerContainer();
}

public
bool existsTradingPartner(string tPartner){
	try{
		TradingPartnerDataBase tradingPartnerDataBase = new TradingPartnerDataBase(dataBaseAccess);

		tradingPartnerDataBase.setTPartner(tPartner);

		return tradingPartnerDataBase.exists();
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public
TradingPartner readTradingPartner(string tPartner){
	try{
		TradingPartnerDataBase tradingPartnerDataBase = new TradingPartnerDataBase(dataBaseAccess);
		tradingPartnerDataBase.setTPartner(tPartner);

		if (!tradingPartnerDataBase.read())
			return null;

		TradingPartner tradingPartner = this.objectDataBaseToObject(tradingPartnerDataBase);

		return tradingPartner;
	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message,exception);
	}
}

public 
void updateTradingPartner(TradingPartner tradingPartner){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		TradingPartnerDataBase tradingPartnerDataBase = this.objectToObjectDataBase(tradingPartner);
		tradingPartnerDataBase.update();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		if (!userHandleTransaction)		
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!userHandleTransaction)		
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public 
void writeTradingPartner(TradingPartner tradingPartner){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		TradingPartnerDataBase tradingPartnerDataBase = this.objectToObjectDataBase(tradingPartner);
		tradingPartnerDataBase.write();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		if (!userHandleTransaction)		
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!userHandleTransaction)		
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public
void deleteTradingPartner(string tPartner){
	try{
		if (!userHandleTransaction)
			dataBaseAccess.beginTransaction();

		TradingPartnerDataBase tradingPartnerDataBase = new TradingPartnerDataBase(dataBaseAccess);

		tradingPartnerDataBase.setTPartner(tPartner);
		tradingPartnerDataBase.delete();

		if (!userHandleTransaction)
			dataBaseAccess.commitTransaction();

	}catch(PersistenceException persistenceException){
		if (!userHandleTransaction)		
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(persistenceException.Message,persistenceException);
	}catch(System.Exception exception){
		if (!userHandleTransaction)		
			dataBaseAccess.rollbackTransaction();
		throw new NujitException(exception.Message,exception);
	}
}

public
TradingPartnerContainer readTradingPartnerByFilters(string stpartner,int irows){
    try{
        TradingPartnerContainer         tradingPartnerContainer = new TradingPartnerContainer();
		TradingPartnerDataBaseContainer tradingPartnerDataBaseContainer = new TradingPartnerDataBaseContainer(dataBaseAccess);
		tradingPartnerDataBaseContainer.readByFilters(stpartner,irows);
	
		foreach(TradingPartnerDataBase tradingPartnerDataBase in tradingPartnerDataBaseContainer) { 
            tradingPartnerContainer.Add(objectDataBaseToObject(tradingPartnerDataBase));
        }		
		return tradingPartnerContainer;

	}catch(PersistenceException persistenceException){
		throw new NujitException(persistenceException.Message, persistenceException);
	}catch(System.Exception exception){
		throw new NujitException(exception.Message, exception);
	}
}

private
TradingPartner objectDataBaseToObject(TradingPartnerDataBase tradingPartnerDataBase){
	TradingPartner tradingPartner = new TradingPartner();

	tradingPartner.TPartner=tradingPartnerDataBase.getTPartner();
	tradingPartner.ExportMode = tradingPartnerDataBase.getExportMode();    

	return tradingPartner;
}

private
TradingPartnerDataBase objectToObjectDataBase(TradingPartner tradingPartner){
	TradingPartnerDataBase tradingPartnerDataBase = new TradingPartnerDataBase(dataBaseAccess);
	tradingPartnerDataBase.setTPartner(tradingPartner.TPartner);
	tradingPartnerDataBase.setExportMode(tradingPartner.ExportMode);
    
	return tradingPartnerDataBase;
}

public
TradingPartner cloneTradingPartner(TradingPartner tradingPartner){
	TradingPartner tradingPartnerClone = new TradingPartner();

	tradingPartnerClone.TPartner=tradingPartner.TPartner;
	tradingPartnerClone.ExportMode = tradingPartner.ExportMode;    

	return tradingPartnerClone;
}


} // class

} // namespace
